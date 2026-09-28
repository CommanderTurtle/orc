module Make.Assets.KraCq1PZNFlJs

let file = """import{o as e}from"./rolldown-runtime-C0FnF6B9.js";import{n as t}from"./CommonFormats-bmLAkhpe.js";import{t as n}from"./jszip.min-B7Fa2WXl.js";var r=e(n(),1),i=class{name=`kra`;supportedFormats;ready=!1;offload=!0;async init(){this.supportedFormats=[t.PNG.builder(`png`).allowFrom(!1).allowTo(!0),{name:`Krita Raster Archive (KRA)`,format:`kra`,extension:`kra`,mime:`application/x-krita`,from:!0,to:!1,internal:`kra`,category:[`archive`],lossless:!1}],this.ready=!0}async doConvert(e,t,n){let i=[];if(t.format==`kra`&&n.format==`png`)for(let t of e){let e=await new r.default().loadAsync(t.bytes),n;try{if(n=e.file(`mergedimage.png`),!n)throw Error()}catch{if(n=e.file(`preview.png`),!n)throw Error(`Could not find image in KRA file`)}let a=await n.async(`uint8array`);i.push({name:t.name.replace(/\.kra$/,`.png`),bytes:a})}return i}};export{i as default};"""

let render() = file
