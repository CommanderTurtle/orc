module MLLM.Src.LocalModelCatalogJs

let file = """export const LOCAL_ENDPOINT = "browser:wasm";
export const DEFAULT_LOCAL_MODEL = "needle-bonsai";
export const LOCAL_MODELS = Object.freeze([
  { id: "needle-bonsai", label: "Needle 3 + Bonsai 1.7B", bytes: 335520456, contextWindow: 8192, description: "Needle toolcalling · Bonsai chat and editing · ~336 MB download" },
  { id: "needle3", label: "Needle 3", bytes: 35335380, contextWindow: 8192, description: "Structured tool calls and results · 35 MB download" },
  { id: "bonsai1.7b", label: "Bonsai 1.7B", bytes: 300185076, contextWindow: 8192, description: "Chat, code and tool calls · ONNX q1 · ~300 MB download" },
]);
export const localModel = (id) => LOCAL_MODELS.find((item) => item.id === id);
export const BONSAI = { id: "onnx-community/Bonsai-1.7B-ONNX", revision: "89d9efdafdad2249a8c8f1568ecf2f1707866d31" };
export const MODEL_FILES = Object.freeze({
  "needle3.cact": { url: "https://huggingface.co/Cactus-Compute/needle3/resolve/d6c7d6a2e9655505e0f8e23339356dd1705900eb/needle3.cact", size: 35335380, sha256: "c9d915eca282ed42d1a09b143b592adb4cc6744ffe2d294adf5cfc5548170c38" },
  ...Object.fromEntries([
    ["config.json", 1981, "350e2a749fdd4ad38923b6a74e8d93facac09412812f548d212f42313aff86a1"],
    ["generation_config.json", 290, "43cf14e5ad6d0091ca997355a685b90bfcac78e7a3d438c9f58aeb5e97251e88"],
    ["tokenizer.json", 9117036, "40ae5d1ee027b985684a3bbeef4ee16b2b5697d1d90658bec5bc5d2a73018bd7"],
    ["tokenizer_config.json", 5261, "7343eff85c6176483a9aee630687f10389cfded03c7ff88b39d8ccf74ad227ad"],
    ["chat_template.jinja", 4063, "30a75d10e60b57e2f260420163dd59720dacf9f63b9a8de070d65dd80a7b30f7"],
    ["onnx/model_q1.onnx", 503681, "4218d8b0977f7d6aee1721b9e53154c2cac093bb781aa23f2fe0024d6f06693e"],
    ["onnx/model_q1.onnx_data", 290552764, "a0eab4c2b960f72f6061615c3094076e8bcb834871ddf7bdad14cd1d37839be0"],
  ].map(([file, size, sha256]) => [file, { url: `https://huggingface.co/${BONSAI.id}/resolve/${BONSAI.revision}/${file}`, size, sha256 } ])),
});
export const MODEL_CACHE = "mllm-models-v1";
"""

let render() = file
