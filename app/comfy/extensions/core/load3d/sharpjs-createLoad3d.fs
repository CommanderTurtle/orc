module Comfy.Extensions.Core.Load3d.CreateLoad3dJs

let file = """// Shim for extensions/core/load3d/createLoad3d.ts
console.warn('[ComfyUI Notice] "extensions/core/load3d/createLoad3d.js" is an internal module, not part of the public API. Future updates may break this import.');
export const createLoad3d = window.comfyAPI.createLoad3d.createLoad3d;
"""

let render() = file
