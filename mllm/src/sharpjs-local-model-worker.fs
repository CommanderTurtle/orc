module MLLM.Src.LocalModelWorkerJs

let file = """let runtime, tokenizer, model, cactus, catalog, assets, output;
let loaded = "", needleState = null;
const notify = (id, status, progress) => self.postMessage({ id, status, progress });

async function load(id, selection) {
  [catalog, assets, output] = await Promise.all([import("./local-model-catalog.js"), import("./local-model-assets.js"), import("./local-model-output.js")]);
  if (!catalog.localModel(selection)) throw Error("Select a supported browser model.");
  runtime = await import("../resources/models/transformers.js");
  const progress = (status, value) => notify(id, status, value);
  if (selection !== "bonsai1.7b") {
    progress("Loading Needle 3 · WASM");
    importScripts(new URL("../resources/speech/cactus.js", self.location.href).href);
    const response = await fetch(new URL("../resources/speech/cactus.wasm", self.location.href));
    if (!response.ok) throw Error("The Cactus WASM runtime is missing from this deployment.");
    cactus = await self.createCactus({ wasmBinary: await response.arrayBuffer() });
    const bytes = await assets.modelBytes("needle3.cact", progress);
    const ptr = cactus._malloc(bytes.length);
    if (!ptr) throw Error("Insufficient memory for Needle 3.");
    try {
      cactus.HEAPU8.set(bytes, ptr);
      if (cactus._cactus_load(ptr, BigInt(bytes.length)) < 0) throw Error(cactus.UTF8ToString(cactus._cactus_last_error()));
    } finally { cactus._free(ptr); }
    if (!(cactus._cactus_models() & 1)) throw Error("Needle weights were not loaded.");
    cactus._cactus_set_threads(1);
  }
  if (selection !== "needle3") {
    runtime.env.allowLocalModels = false;
    runtime.env.useBrowserCache = false;
    runtime.env.useWasmCache = false;
    runtime.env.fetch = assets.modelFetch(progress);
    runtime.env.backends.onnx.wasm.wasmPaths = new URL("../resources/models/", self.location.href).href;
    runtime.env.backends.onnx.wasm.numThreads = self.crossOriginIsolated ? Math.max(1, Math.min(4, navigator.hardwareConcurrency || 1)) : 1;
    runtime.env.backends.onnx.wasm.proxy = false;
    tokenizer = await runtime.AutoTokenizer.from_pretrained(catalog.BONSAI.id, { revision: catalog.BONSAI.revision });
    progress("Preparing Bonsai 1.7B · ONNX/WASM");
    model = await runtime.AutoModelForCausalLM.from_pretrained(catalog.BONSAI.id, {
      revision: catalog.BONSAI.revision, dtype: "q1", device: "wasm", use_external_data_format: true,
    });
  }
  loaded = selection;
  return { model: loaded };
}

function createValidator(schema) {
  const draft = String(schema?.$schema || "");
  const Validator = draft.includes("2020-12") ? runtime.Ajv2020 : draft.includes("2019-09") ? runtime.Ajv2019 : runtime.Ajv;
  const instance = new Validator({ strict: false, validateFormats: false, allErrors: false });
  return { validate: instance.compile(schema), errorsText: instance.errorsText.bind(instance) };
}

function needleComplete(text, maxTokens) {
  const capacity = 2 * 1024 * 1024;
  const ptr = cactus._malloc(capacity);
  if (!ptr) throw Error("Insufficient memory for Needle output.");
  try {
    const length = cactus.ccall("cactus_complete", "number", ["string", "number", "number", "number", "number", "number"], [text, 0, 0, maxTokens, ptr, capacity]);
    if (length < 0) throw Error(cactus.UTF8ToString(cactus._cactus_last_error()));
    if (length >= capacity) throw Error("Needle output exceeded its buffer.");
    // Non-finite calibration metrics are nullable; string contents and tool arguments stay verbatim.
    const raw = cactus.UTF8ToString(ptr);
    const safe = raw.replace(/"(?:[^"\\]|\\.)*"|\b(?:NaN|Infinity)\b|-Infinity/g, (token) => token.startsWith('"') ? token : "null");
    const result = JSON.parse(safe);
    if (result.success === false) throw Error(result.error || "Needle did not complete.");
    return result;
  } finally { cactus._free(ptr); }
}

function needle(body, messages) {
  const tools = (body.tools || []).map((tool) => tool.function);
  if (!tools.length) return null;
  const system = messages.filter((m) => m.role === "system").map((m) => m.content).join("\n\n");
  const key = JSON.stringify([body.session_id, tools, system]);
  const turns = messages.filter((m) => m.role !== "system");
  let added;
  const unseen = turns.slice(needleState?.turns.length || 0);
  if (needleState?.key === key && needleState.turns.every((turn, i) => JSON.stringify(turn) === JSON.stringify(turns[i]))
      && !unseen.some((m) => m.role === "assistant" && m.content)) {
    added = turns.slice(needleState.turns.length).filter((m) => m.role !== "assistant");
  } else {
    const code = cactus.ccall("cactus_init", "number", ["string", "string", "string"], [system, JSON.stringify(tools), null]);
    if (code < 0) throw Error(cactus.UTF8ToString(cactus._cactus_last_error()));
    added = turns;
  }
  let text;
  if (added.length === 1 && added[0].role === "user") text = added[0].content;
  else text = JSON.stringify(added.map((m) => ({ role: m.role, content: m.content, ...(m.name ? { name: m.name } : {}), ...(m.tool_calls ? { tool_calls: m.tool_calls } : {}) })));
  const result = needleComplete(text, Math.min(2048, body.max_tokens || 1024));
  needleState = { key, sessionId: body.session_id, turns: structuredClone(turns) };
  if (result.validation?.ungrounded?.length) throw Error(`Needle withheld ungrounded fields: ${result.validation.ungrounded.join(", ")}. Rephrase with explicit values.`);
  if (result.suppressed_calls?.length) throw Error("Needle withheld a low-confidence tool request. Nothing was executed; provide more explicit details.");
  return result;
}

async function generate(id, body) {
  if (body.model !== loaded) throw Error("Load this model before sending.");
  const tools = body.tools || [];
  const messages = body.messages.map((message) => ({ ...message, content: message.content ?? "" }));
  if (messages.some((m) => typeof m.content !== "string")) throw Error("Browser chat models accept text. Enable local OCR for image attachments.");
  const result = output.aggregate(loaded);
  const emit = (key, text) => { result[key] += text; self.postMessage({ id, delta: { content: key === "content" ? text : "", reasoning: key === "reasoning" ? text : "", toolCalls: [] } }); };
  if (cactus && tools.length) {
    notify(id, "Needle · selecting tools");
    const decision = needle(body, messages);
    if (decision?.function_calls?.length) {
      result.toolCalls = output.toolCalls(decision.function_calls, tools, createValidator);
      if (decision.reasoning) emit("reasoning", decision.reasoning);
      self.postMessage({ id, delta: { content: "", reasoning: "", toolCalls: result.toolCalls } });
      result.finishReason = "tool_calls"; return result;
    }
  }
  if (!model) {
    emit("content", messages.at(-1)?.role === "tool" ? "Tool results are shown above." : tools.length ? "Needle did not select a tool. Try an explicit request with the required values, or load Needle + Bonsai for chat and editing." : "Enable a browser tool for Needle, or load Needle + Bonsai for chat and editing.");
    result.finishReason = "stop"; return result;
  }
  notify(id, "Bonsai · preparing context");
  const inputs = tokenizer.apply_chat_template(messages, { tools, tokenize: true, return_dict: true, add_generation_prompt: true });
  const promptTokens = inputs.input_ids.dims.at(-1);
  const context = Math.max(256, Math.min(32768, body.context_window || 8192));
  if (promptTokens >= context) throw Error(`Context length exceeded: ${promptTokens} tokens, window ${context}. Compact the chat or raise its context window; nothing was silently trimmed.`);
  const allowance = Math.min(body.max_tokens || 1024, context - promptTokens);
  runtime.random.seed(body.seed ?? undefined);
  const stream = output.outputStream(emit);
  let tokens = 0;
  const streamer = new runtime.TextStreamer(tokenizer, { skip_prompt: true, skip_special_tokens: false, callback_function: (text) => stream.push(text), token_callback_function: (ids) => { tokens += ids.length; } });
  // Generation owns its KV cache for this call only. Queued chats never share conversation tensors.
  notify(id, "Bonsai · generating");
  let generated;
  try {
    generated = await model.generate({ ...inputs, max_new_tokens: allowance, do_sample: (body.temperature ?? 0) > 0, temperature: Math.max(0.01, body.temperature || 1), top_p: body.top_p ?? 1, streamer });
  } catch (error) {
    // A failed native evaluation may retain partial KV allocations. Release the worker before another call.
    error.releaseRuntime = true;
    throw error;
  }
  const values = stream.finish();
  const last = Number(generated.data.at(-1));
  const ended = [151645, 151643].includes(last);
  if (values.length && !ended) throw Error("Output allowance ended before the tool response completed; no calls were executed. Increase the allowance and retry.");
  result.toolCalls = output.toolCalls(values, tools, createValidator);
  if (result.toolCalls.length) self.postMessage({ id, delta: { content: "", reasoning: "", toolCalls: result.toolCalls } });
  result.finishReason = values.length ? "tool_calls" : ended ? "stop" : "length";
  result.usage = { prompt_tokens: promptTokens, completion_tokens: tokens, total_tokens: promptTokens + tokens };
  return result;
}

self.onmessage = async ({ data }) => {
  if (data.action === "forget") {
    if (needleState?.sessionId === data.sessionId) { cactus._cactus_reset(); needleState = null; }
    return;
  }
  try {
    const result = data.action === "load" ? await load(data.id, data.model) : await generate(data.id, data.body);
    self.postMessage({ id: data.id, result });
  } catch (error) {
    let releaseRuntime = error?.releaseRuntime === true;
    try { cactus?._cactus_reset(); } catch { releaseRuntime = true; }
    needleState = null;
    self.postMessage({ id: data.id, error: error instanceof Error ? error.message : String(error), releaseRuntime });
  }
};
"""

let render() = file
