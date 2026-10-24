module ComfyUI.Assets.LinkFrameHREPGAyJs

let file = """import{r as e}from"./links-BKrIYetb.js";window.addEventListener(`message`,async t=>{if(t.source!==parent||t.data?.type!==`comfystatic:resolve-link`)return;let{id:n,input:r}=t.data;if(typeof n==`string`&&typeof r==`string`)try{let t=await e(r);parent.postMessage({type:`comfystatic:link-result`,id:n,result:t},`*`,[t.bytes.buffer])}catch(e){parent.postMessage({type:`comfystatic:link-result`,id:n,error:e instanceof Error?e.message:String(e)},`*`)}});"""

let render() = file
