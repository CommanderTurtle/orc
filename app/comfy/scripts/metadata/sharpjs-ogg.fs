module Comfy.Scripts.Metadata.OggJs

let file = """// Shim for scripts/metadata/ogg.ts
console.warn('[ComfyUI Notice] "scripts/metadata/ogg.js" is an internal module, not part of the public API. Future updates may break this import.');
export const getOggMetadata = window.comfyAPI.ogg.getOggMetadata;
"""

let render() = file
