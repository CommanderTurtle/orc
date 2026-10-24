module ComfyUI.Assets.UtilsOaoCCplvJs

let file = """console.warn(`[ComfyUI Deprecated] Importing from "scripts/ui/utils.js" is deprecated and will be removed in v1.34.`);var e=window.comfyAPI.utils.$el,t=window.comfyAPI.utils.applyClasses,n=window.comfyAPI.utils.toggleElement;export{e as $el,t as applyClasses,n as toggleElement};"""

let render() = file
