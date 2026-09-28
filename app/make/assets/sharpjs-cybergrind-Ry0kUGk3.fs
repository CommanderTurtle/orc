module Make.Assets.CybergrindRy0kUGk3Js

let file = """import{n as e,t}from"./CommonFormats-BHch0KU5.js";import{r as n}from"./errors-DEotwJ0n.js";var r=class{name=`cybergrind`;supportedFormats;ready=!1;offload=!0;#e;#t;async init(){this.supportedFormats=[e.PNG.supported(`png`,!0,!1),{name:`ULTRAKILL CyberGrind Pattern`,format:`cgp`,extension:`cgp`,mime:`text/plain`,category:t.DATA,from:!1,to:!0,internal:`cgp`,lossless:!1}],this.#e=new OffscreenCanvas(16,16),this.#t=this.#e.getContext(`2d`)||void 0,this.ready=!0}async doConvert(e,t,r){let i=new TextEncoder,a=[];if(t.internal!==`png`||r.internal!==`cgp`)throw TypeError(`Unsupported output format: ${r.internal}`);if(!this.#e||!this.#t)throw new n(`Handler not initialized.`);for(let n of e){let e=new Blob([n.bytes],{type:t.mime}),r=await createImageBitmap(e);this.#e.width=16,this.#e.height=16,this.#t.drawImage(r,0,0,16,16);let o=this.#t.getImageData(0,0,16,16),s=[],c=[],l=[],u=[];for(let e=0;e<o.data.length;e+=4){let t=o.data[e],n=o.data[e+1],r=o.data[e+2],i=.299*t+.587*n+.114*r,a=Math.round(i/255*10);s.push(a),c.push({index:e/4,value:t}),l.push({index:e/4,value:n}),u.push({index:e/4,value:r})}c.sort((e,t)=>t.value-e.value),c=c.slice(0,5);let d=new Set(c.map(e=>e.index));l.sort((e,t)=>t.value-e.value),l=l.filter(e=>!d.has(e.index)).slice(0,5),l.forEach(e=>d.add(e.index)),u.sort((e,t)=>t.value-e.value),u=u.filter(e=>!d.has(e.index)).slice(0,5);let f=``,p=``;for(let e=0;e<s.length;e++){e>0&&e%16==0&&(f+=`
`,p+=`
`);let t=s[e];f+=`${t>=10?`(${t})`:`${t}`}`,p+=u.some(t=>t.index===e)?`H`:l.some(t=>t.index===e)?`n`:c.some(t=>t.index===e)?`H`:`0`}let m=i.encode(f+`

`+p),h=n.name.replace(/\.[^/.]+$/,``)+`.cgp`;a.push({bytes:m,name:h})}return a}};export{r as default};"""

let render() = file
