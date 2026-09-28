module Comfy.Extensions.Core.Load3d.CameraFromMatricesJs

let file = """// Shim for extensions/core/load3d/cameraFromMatrices.ts
console.warn('[ComfyUI Notice] "extensions/core/load3d/cameraFromMatrices.js" is an internal module, not part of the public API. Future updates may break this import.');
export const computeCameraFromMatrices = window.comfyAPI.cameraFromMatrices.computeCameraFromMatrices;
"""

let render() = file
