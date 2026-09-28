module Comfy.Extensions.Core.Load3d.GizmoManagerJs

let file = """// Shim for extensions/core/load3d/GizmoManager.ts
console.warn('[ComfyUI Notice] "extensions/core/load3d/GizmoManager.js" is an internal module, not part of the public API. Future updates may break this import.');
export const GizmoManager = window.comfyAPI.GizmoManager.GizmoManager;
"""

let render() = file
