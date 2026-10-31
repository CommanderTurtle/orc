module LLM.Src.LintParsersJs

let file = """export const LANGUAGE_ALIASES = {
  js: "javascript", mjs: "javascript", cjs: "javascript", jsx: "javascript",
  ts: "typescript", py: "python", rs: "rust", rb: "ruby", sh: "bash", shell: "bash",
  "c++": "cpp", cc: "cpp", cxx: "cpp", hpp: "cpp", h: "c",
  cs: "c_sharp", csharp: "c_sharp", "c#": "c_sharp",
  fs: "fsharp", fsx: "fsharp", "f#": "fsharp", fsi: "fsharp_signature",
  yml: "yaml", kt: "kotlin", ex: "elixir", exs: "elixir", golang: "go",
  objectivec: "objc", "objective-c": "objc", ml: "ocaml", el: "elisp", sol: "solidity",
};
export const PARSER_LANGUAGES = new Set([
  "bash", "c_sharp", "c", "cpp", "css", "dart", "elisp", "elixir", "embedded_template",
  "go", "html", "java", "javascript", "json", "kotlin", "lua", "objc", "ocaml", "php",
  "python", "rescript", "ruby", "rust", "scala", "solidity", "swift", "systemrdl",
  "tlaplus", "toml", "tsx", "typescript", "vue", "yaml", "zig", "fsharp", "fsharp_signature",
]);
export function parserLanguage(language) {
  const key = String(language).toLowerCase();
  const name = LANGUAGE_ALIASES[key] || key;
  return PARSER_LANGUAGES.has(name) ? name : null;
}

let runtime;
const languages = new Map();
export async function parseDiagnostics(source, language) {
  const name = parserLanguage(language);
  if (!name) return { supported: false, diagnostics: [] };
  const runtimeUrl = new URL("../vendor/lint/web-tree-sitter.js", import.meta.url).href;
  const { Parser, Language } = await import(runtimeUrl);
  runtime ??= Parser.init({ locateFile: () => new URL("../vendor/lint/web-tree-sitter.wasm", import.meta.url).href });
  await runtime;
  if (!languages.has(name)) languages.set(name, Language.load(new URL(`../vendor/lint/tree-sitter-${name}.wasm`, import.meta.url).href));
  const parser = new Parser();
  let tree;
  try {
    parser.setLanguage(await languages.get(name));
    tree = parser.parse(source);
    if (!tree) throw new Error("Parser did not produce a syntax tree.");
    const diagnostics = [];
    const visit = (node) => {
      if (diagnostics.length >= 40) return;
      if (node.isError || node.isMissing) {
        diagnostics.push({
          line: node.startPosition.row + 1, column: node.startPosition.column + 1,
          severity: "error", source: `Tree-sitter ${name}`,
          message: node.isMissing ? `Missing ${node.type}.` : `Unexpected syntax near ${JSON.stringify(node.text.slice(0, 100))}.`,
        });
        return;
      }
      if (node.hasError) for (const child of node.children) visit(child);
    };
    visit(tree.rootNode);
    return { supported: true, diagnostics };
  } finally { tree?.delete(); parser.delete(); }
}
"""

let render() = file
