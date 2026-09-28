module Comfy.Extensions.Core.Load3d.MeshModelAdapterJs

let file = """// Shim for extensions/core/load3d/MeshModelAdapter.ts
console.warn('[ComfyUI Notice] "extensions/core/load3d/MeshModelAdapter.js" is an internal module, not part of the public API. Future updates may break this import.');
export const MeshModelAdapter = window.comfyAPI.MeshModelAdapter.MeshModelAdapter;
"""

let render() = file
