module Comfy.Extensions.Core.Load3d.ViewHelperManagerJs

let file = """// Shim for extensions/core/load3d/ViewHelperManager.ts
console.warn('[ComfyUI Notice] "extensions/core/load3d/ViewHelperManager.js" is an internal module, not part of the public API. Future updates may break this import.');
export const ViewHelperManager = window.comfyAPI.ViewHelperManager.ViewHelperManager;
"""

let render() = file
