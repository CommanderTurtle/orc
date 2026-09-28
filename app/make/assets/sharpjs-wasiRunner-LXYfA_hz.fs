module Make.Assets.WasiRunnerLXYfAHzJs

let file = """import{n as e,t}from"./CommonFormats-bmLAkhpe.js";import{i as n,o as r,r as i,t as a}from"./dist-CRk9oVtL.js";var o=class{name=`wasiRunner`;supportedFormats=[{name:`WebAssembly Binary (Wasm)`,format:`wasm`,extension:`wasm`,mime:`application/wasm`,from:!0,to:!1,internal:`wasm`,category:t.CODE,lossless:!0},e.TEXT.builder(`txt`).allowTo()];ready=!1;offload=!0;async init(){this.ready=!0}async doConvert(e,t,o){let s=[];for(let t of e){let e=[],o=[new n(new i([])),new a(t=>e.push(...t)),new a(t=>e.push(...t))],c=new r([t.name],[],o),l=await WebAssembly.compile(new Uint8Array(t.bytes)),u=await WebAssembly.instantiate(l,{wasi_snapshot_preview1:c.wasiImport});c.start(u),s.push({name:t.name.replace(/\.[^.]+$/,``)+`.txt`,bytes:new Uint8Array(e)})}return s}};export{o as default};"""

let render() = file
