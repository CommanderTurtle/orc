module Comfy.Extensions.Core.CameraInfo.Handles.OrbitHandlesJs

let file = """// Shim for extensions/core/cameraInfo/handles/OrbitHandles.ts
console.warn('[ComfyUI Notice] "extensions/core/cameraInfo/handles/OrbitHandles.js" is an internal module, not part of the public API. Future updates may break this import.');
export const OrbitHandles = window.comfyAPI.OrbitHandles.OrbitHandles;
"""

let render() = file
