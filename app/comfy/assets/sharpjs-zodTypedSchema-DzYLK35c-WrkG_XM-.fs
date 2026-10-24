module ComfyUI.Assets.ZodTypedSchemaDzYLK35cWrkGXMJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";function e(e){return e.reduce((e,t,n)=>typeof t==`number`?`${e}[${t}]`:n===0?String(t):`${e}.${String(t)}`,``)}function t(n,r=[]){return n.flatMap(n=>{let i=[...r,...n.path],a=e(i),o={path:a,message:n.message};if(n.code!==`invalid_union`)return[o];let s=t(n.errors.flat(),i);return a||s.length===0?[...s,o]:s})}function n(e){let n=new Map;for(let{path:r,message:i}of t(e))n.set(r,[...n.get(r)??[],i]);return Array.from(n,([e,t])=>({path:e,errors:t}))}function r(e){return{__type:`VVTypedSchema`,async parse(t){let r=await e.safeParseAsync(t);return r.success?{value:r.data,errors:[]}:{errors:n(r.error.issues)}}}}export{r as t};"""

let render() = file
