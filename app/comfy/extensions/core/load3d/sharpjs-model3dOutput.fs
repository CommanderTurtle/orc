module ComfyUI.Extensions.Core.Load3d.Model3dOutputJs

let file = """// Shim for extensions/core/load3d/model3dOutput.ts
console.warn('[ComfyUI Notice] "extensions/core/load3d/model3dOutput.js" is an internal module, not part of the public API. Future updates may break this import.');
export const readModel3DOutput = window.comfyAPI.model3dOutput.readModel3DOutput;
"""

let render() = file
