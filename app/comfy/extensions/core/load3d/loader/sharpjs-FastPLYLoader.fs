module Comfy.Extensions.Core.Load3d.Loader.FastPLYLoaderJs

let file = """// Shim for extensions/core/load3d/loader/FastPLYLoader.ts
console.warn('[ComfyUI Notice] "extensions/core/load3d/loader/FastPLYLoader.js" is an internal module, not part of the public API. Future updates may break this import.');
export const FastPLYLoader = window.comfyAPI.FastPLYLoader.FastPLYLoader;
"""

let render() = file
