module ComfyUI.Assets.UseCopyToClipboardBuDFXNGCZ9GzMZEJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{m as e}from"./i18n-D6QG9v-J-FWl07wji.js";import{n as t}from"./toastStore-BZFn5ETr-DnIiwXtS.js";function n(e){let t=document.createElement(`textarea`);t.setAttribute(`readonly`,``),t.value=e,t.style.position=`fixed`,t.style.left=`-9999px`,t.style.top=`-9999px`,document.body.appendChild(t),t.select();try{return document.execCommand(`copy`)}finally{t.remove()}}function r(){let r=t();async function i(t,{toastOnSuccess:i=!0}={}){let a=!1;try{await navigator.clipboard.writeText(t),a=!0}catch{}if(!a)try{a=n(t)}catch{}return a&&!i?!0:(a?r.success(e(`g.success`),{description:e(`clipboard.successMessage`),duration:3e3}):r.error(e(`g.error`),{description:e(`clipboard.errorMessage`)}),a)}return{copyToClipboard:i}}export{r as t};"""

let render() = file
