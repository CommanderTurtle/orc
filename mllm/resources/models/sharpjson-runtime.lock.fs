module MLLM.Resources.Models.RuntimeLockJson

let file = """{
  "transformers": "4.3.2",
  "onnxruntime": "1.31.0-dev.20260914-8d85527a0",
  "backend": "wasm",
  "files": {
    "transformers.js": {
      "size": 653157,
      "sha256": "42a5c0814a1975d86b89565718839986fce21f5a780a9ece61e423436fcc300c"
    },
    "ort-wasm-simd-threaded.mjs": {
      "size": 24381,
      "sha256": "c57ca56328877353a575e51bbca6f18450027d6c9bf2307a2cb2c41363b4de9f"
    },
    "ort-wasm-simd-threaded.wasm": {
      "size": 14264838,
      "sha256": "06ba057753da3847e4c24f02d91ab133455b0817c69a44993a9a53a2146df9e3"
    }
  },
  "onnxruntimeCommit": "8d85527a010e294a26b274749f74294b2a32cec5"
}
"""

let render() = file
