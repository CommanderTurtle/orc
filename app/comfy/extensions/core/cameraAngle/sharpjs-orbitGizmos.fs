module ComfyUI.Extensions.Core.CameraAngle.OrbitGizmosJs

let file = """// Shim for extensions/core/cameraAngle/orbitGizmos.ts
console.warn('[ComfyUI Notice] "extensions/core/cameraAngle/orbitGizmos.js" is an internal module, not part of the public API. Future updates may break this import.');
export const OrbitSphere = window.comfyAPI.orbitGizmos.OrbitSphere;
export const CameraMarker = window.comfyAPI.orbitGizmos.CameraMarker;
"""

let render() = file
