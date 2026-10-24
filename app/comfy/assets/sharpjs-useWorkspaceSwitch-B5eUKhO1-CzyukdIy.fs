module ComfyUI.Assets.UseWorkspaceSwitchB5eUKhO1CzyukdIyJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{xt as e}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";import{d as t}from"./apiKeyAuthStore-BK5iKaP0-DzwBOk3-.js";function n(){let n=t(),{activeWorkspace:r}=e(n);async function i(e){if(r.value?.id===e)return!0;try{return await n.switchWorkspace(e),!0}catch{return!1}}return{switchWorkspace:i}}export{n as t};"""

let render() = file
