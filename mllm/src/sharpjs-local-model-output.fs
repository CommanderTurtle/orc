module MLLM.Src.LocalModelOutputJs

let file = """export function toolCalls(values, tools, createValidator) {
  const schemas = new Map(tools.map((tool) => [tool.function.name, tool.function.parameters]));
  const validators = new Map();
  if (!Array.isArray(values) || values.length > 32) throw Error("Invalid model tool-call list.");
  return values.map((value) => {
    if (!value || !schemas.has(value.name)) throw Error(`Model requested an unavailable tool: ${value?.name || "(missing name)"}`);
    const args = typeof value.arguments === "string" ? JSON.parse(value.arguments) : value.arguments;
    if (!args || typeof args !== "object" || Array.isArray(args)) throw Error(`Invalid argument object for ${value.name}.`);
    // Schema registrations live only for this bounded call list; repeated MCP $ids cannot accumulate across turns.
    if (!validators.has(value.name)) validators.set(value.name, createValidator(schemas.get(value.name)));
    const validator = validators.get(value.name);
    if (!validator.validate(args)) throw Error(`Invalid arguments for ${value.name}: ${validator.errorsText(validator.validate.errors)}`);
    return { id: `call-${crypto.randomUUID()}`, type: "function", function: { name: value.name, arguments: JSON.stringify(args) } };
  });
}
export function aggregate(model) {
  return { id: `local-${crypto.randomUUID()}`, model, content: "", reasoning: "", toolCalls: [], finishReason: null, usage: null, sawDone: true, sawFinishReason: true, terminal: true };
}

// Delimiters may straddle token chunks. Hold only the unfinished tag, and keep tool JSON out of visible prose.
export function outputStream(emit) {
  let pending = "", mode = "content", tool = "", quoted = false, escaped = false;
  let lineStart = true, fence = null, inlineTicks = 0;
  const calls = [];
  const tags = ["<think>", "</think>", "<tool_call>", "</tool_call>", "<|im_end|>", "<|endoftext|>"];
  const visible = { content: "", reasoning: "" };
  function write(text) {
    if (mode === "tool") tool += text;
    else if (text) { visible[mode] += text; lineStart = text.endsWith("\n"); }
  }
  function drain(final = false) {
      while (pending) {
        if (mode === "tool") {
          const end = "</tool_call>";
          if (!quoted && pending.startsWith(end)) {
            calls.push(tool); tool = ""; mode = "content"; pending = pending.slice(end.length); continue;
          }
          if (!quoted && end.startsWith(pending) && !final) break;
          const character = pending[0];
          if (escaped) escaped = false;
          else if (quoted && character === "\\") escaped = true;
          else if (character === '"') quoted = !quoted;
          tool += character; pending = pending.slice(1); continue;
        }
        // Wait only at a possible fence boundary, including fences split across token chunks.
        if (lineStart && !inlineTicks) {
          if (/^ {0,3}$/.test(pending) && !final) break;
          const prefix = /^ {0,3}(`+|~+)/.exec(pending);
          if (prefix && prefix[0].length === pending.length && !final) break;
          if (prefix && prefix[1].length >= 3) {
            const newline = pending.indexOf("\n");
            if (newline < 0 && !final) break;
            const line = pending.slice(0, newline < 0 ? pending.length : newline + 1);
            const marker = /^ {0,3}(`{3,}|~{3,})(.*)/.exec(line);
            if (fence || marker) {
              if (!fence) fence = { mark: marker[1][0], length: marker[1].length };
              else if (marker && marker[1][0] === fence.mark && marker[1].length >= fence.length && !marker[2].trim()) fence = null;
              write(line); pending = pending.slice(line.length); continue;
            }
          }
        }
        if (fence) { write(pending[0]); pending = pending.slice(1); continue; }
        if (pending[0] === "`") {
          const run = /^`+/.exec(pending)[0];
          if (run.length === pending.length && !final) break;
          inlineTicks = inlineTicks ? (inlineTicks === run.length ? 0 : inlineTicks) : run.length;
          write(run); pending = pending.slice(run.length); continue;
        }
        if (!inlineTicks) {
          const tag = tags.find((value) => pending.startsWith(value));
          if (tag) {
            pending = pending.slice(tag.length);
            if (tag === "<think>" && mode === "content") mode = "reasoning";
            else if (tag === "</think>" && mode === "reasoning") mode = "content";
            else if (tag === "<tool_call>" && mode === "content") { mode = "tool"; tool = ""; quoted = false; escaped = false; }
            else if (!["<|im_end|>", "<|endoftext|>"].includes(tag)) write(tag);
            continue;
          }
          if (!final && tags.some((tag) => tag.startsWith(pending))) break;
        }
        write(pending[0]); pending = pending.slice(1);
      }
      for (const key of ["reasoning", "content"]) if (visible[key]) { emit(key, visible[key]); visible[key] = ""; }
  }
  return {
    push(text) {
      pending += text; drain();
    },
    finish() {
      drain(true);
      if (mode === "tool") throw Error("Model output ended inside a tool call; nothing from this response was executed.");
      if (calls.length > 32) throw Error("Model returned too many tool calls.");
      return calls.map((call) => JSON.parse(call));
    },
  };
}
"""

let render() = file
