module ComfyUI.Extensions.Core.LightInfo.LightsValueJs

let file = """// Shim for extensions/core/lightInfo/lightsValue.ts
console.warn('[ComfyUI Notice] "extensions/core/lightInfo/lightsValue.js" is an internal module, not part of the public API. Future updates may break this import.');
export const normalizeLightsValue = window.comfyAPI.lightsValue.normalizeLightsValue;
"""

let render() = file
