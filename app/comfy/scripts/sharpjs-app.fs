module ComfyUI.Scripts.AppJs

let file = """// Shim for scripts/app.ts
export const sanitizeNodeName = window.comfyAPI.app.sanitizeNodeName;
export const ComfyApp = window.comfyAPI.app.ComfyApp;
export const app = window.comfyAPI.app.app;
"""

let render() = file
