module Make.Assets.KrzCuuMlwK8Js

let file = """import{o as e}from"./rolldown-runtime-C0FnF6B9.js";import{n as t}from"./CommonFormats-bmLAkhpe.js";import{t as n}from"./jszip.min-B7Fa2WXl.js";var r=e(n(),1),i=class{name=`krz`;supportedFormats;ready=!1;offload=!0;async init(){this.supportedFormats=[t.PNG.builder(`png`).allowFrom(!1).allowTo(!0),{name:`Krita Raster Archive (krz)`,format:`krz`,extension:`krz`,mime:`application/x-krita`,from:!0,to:!1,internal:`krz`,category:[`archive`],lossless:!1}],this.ready=!0}async doConvert(e,t,n){let i=[];if(t.format==`krz`&&n.format==`png`)for(let t of e){let e=(await new r.default().loadAsync(t.bytes)).file(`preview.png`);if(!e)throw Error(`Could not find image in krz file`);let n=await e.async(`uint8array`);i.push({name:t.name.replace(/\.krz$/,`.png`),bytes:n})}return i}};export{i as default};"""

let render() = file
