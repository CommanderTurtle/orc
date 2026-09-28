module Make.Assets.ShToElfSWw4PdsJs

let file = """import{n as e,t}from"./CommonFormats-bmLAkhpe.js";var n=`/make/assets/stub-Ct91vE4z.elf`;function r(e,t,n){let r=Buffer.alloc(4);r.writeUint32LE(t,0);let i=Buffer.alloc(4);i.writeUint32LE(n,0);let a=e.indexOf(r);i.copy(e,a)}var i=class{name=`shToElf`;supportedFormats=[e.SH.builder(`sh`).allowFrom().markLossless(),{name:`x86-64 Linux Executable and Linkable Format`,format:`elf`,extension:`elf`,mime:`application/x-elf`,from:!1,to:!0,internal:`elf`,category:t.CODE}];ready=!1;offload=!0;#e;async init(){this.ready=!0,this.#e=Buffer.from(await(await fetch(n)).bytes())}async doConvert(e,t,n){let i=[];for(let t of e){let e=Buffer.from(new Uint8Array(this.#e));r(e,1273991571,t.bytes.length);let n=Buffer.concat([e,t.bytes]);i.push({name:t.name.replace(/\.[^.]+$/,``)+`.elf`,bytes:n})}return i}};export{i as default};"""

let render() = file
