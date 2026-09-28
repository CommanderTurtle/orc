module Comfy.Scripts.ApiJs

let file = """// Shim for scripts/api.ts
export const UnauthorizedError = window.comfyAPI.api.UnauthorizedError;
export const PromptExecutionError = window.comfyAPI.api.PromptExecutionError;
export const ComfyApi = window.comfyAPI.api.ComfyApi;
export const api = window.comfyAPI.api.api;
"""

let render() = file
