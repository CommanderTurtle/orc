module ComfyUI.Assets.LightInfoOverlayPdFuIARCJs

let file = """console.warn(`[ComfyUI Notice] "extensions/core/lightInfo/LightInfoOverlay.js" is an internal module, not part of the public API. Future updates may break this import.`);var e=window.comfyAPI.LightInfoOverlay.LightInfoOverlay;export{e as LightInfoOverlay};"""

let render() = file
