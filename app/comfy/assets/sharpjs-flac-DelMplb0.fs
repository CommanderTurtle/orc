module ComfyUI.Assets.FlacDelMplb0Js

let file = """console.warn(`[ComfyUI Notice] "scripts/metadata/flac.js" is an internal module, not part of the public API. Future updates may break this import.`);var e=window.comfyAPI.flac.getFromFlacBuffer,t=window.comfyAPI.flac.getFromFlacFile;export{e as getFromFlacBuffer,t as getFromFlacFile};"""

let render() = file
