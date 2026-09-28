module Comfy.Scripts.Ui.Components.ButtonGroupJs

let file = """// Shim for scripts/ui/components/buttonGroup.ts
console.warn('[ComfyUI Deprecated] Importing from "scripts/ui/components/buttonGroup.js" is deprecated and will be removed in v1.34.');
export const ComfyButtonGroup = window.comfyAPI.buttonGroup.ComfyButtonGroup;
"""

let render() = file
