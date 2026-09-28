module Comfy.Extensions.Core.Load3d.SceneManagerJs

let file = """// Shim for extensions/core/load3d/SceneManager.ts
console.warn('[ComfyUI Notice] "extensions/core/load3d/SceneManager.js" is an internal module, not part of the public API. Future updates may break this import.');
export const SceneManager = window.comfyAPI.SceneManager.SceneManager;
"""

let render() = file
