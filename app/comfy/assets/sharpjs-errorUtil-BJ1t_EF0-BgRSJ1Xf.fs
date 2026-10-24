module ComfyUI.Assets.ErrorUtilBJ1tEF0BgRSJ1XfJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";function e(e){if(e instanceof Error)return e;if(typeof e==`string`)return Error(e);if(e===void 0)return Error(`undefined`);try{let t=JSON.stringify(e);return Error(t)}catch{return Error(String(e))}}function t(e){if(e instanceof Error)return e.message;if(typeof e==`string`)return e;if(typeof e==`object`&&e&&`message`in e&&typeof e.message==`string`)return e.message}export{e as n,t};"""

let render() = file
