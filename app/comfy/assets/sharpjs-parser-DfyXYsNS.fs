module ComfyUI.Assets.ParserDfyXYsNSJs

let file = """console.warn(`[ComfyUI Notice] "scripts/metadata/parser.js" is an internal module, not part of the public API. Future updates may break this import.`);var e=window.comfyAPI.parser.getWorkflowDataFromFile;export{e as getWorkflowDataFromFile};"""

let render() = file
