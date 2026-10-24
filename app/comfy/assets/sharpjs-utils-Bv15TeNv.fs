module ComfyUI.Assets.UtilsBv15TeNvJs

let file = """console.warn(`[ComfyUI Notice] "scripts/utils.js" is an internal module, not part of the public API. Future updates may break this import.`);var e=window.comfyAPI.utils.clone,t=window.comfyAPI.utils.applyTextReplacements,n=window.comfyAPI.utils.addStylesheet,r=window.comfyAPI.utils.uploadFile,i=window.comfyAPI.utils.prop,a=window.comfyAPI.utils.getStorageValue,o=window.comfyAPI.utils.setStorageValue;export{n as addStylesheet,t as applyTextReplacements,e as clone,a as getStorageValue,i as prop,o as setStorageValue,r as uploadFile};"""

let render() = file
