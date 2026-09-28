module Comfy.Scripts.Ui.DraggableListJs

let file = """// Shim for scripts/ui/draggableList.ts
console.warn('[ComfyUI Deprecated] Importing from "scripts/ui/draggableList.js" is deprecated and will be removed in v1.34.');
export const DraggableList = window.comfyAPI.draggableList.DraggableList;
"""

let render() = file
