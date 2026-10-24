module ComfyUI.Assets.ClipspaceCIQIDQeJs

let file = """console.warn(`[ComfyUI Notice] "scripts/clipspace.js" is an internal module, not part of the public API. Future updates may break this import.`);var e=window.comfyAPI.clipspace.clipspace,t=window.comfyAPI.clipspace.copyToClipspace,n=window.comfyAPI.clipspace.pasteFromClipspace;export{e as clipspace,t as copyToClipspace,n as pasteFromClipspace};"""

let render() = file
