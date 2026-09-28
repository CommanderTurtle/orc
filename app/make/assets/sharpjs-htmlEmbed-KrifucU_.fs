module Make.Assets.HtmlEmbedKrifucUJs

let file = """import{n as e}from"./CommonFormats-BHch0KU5.js";var t=class t{name=`htmlEmbed`;supportedFormats=[e.HTML.supported(`html`,!1,!0,!0),e.PNG.supported(`png`,!0,!1),e.JPEG.supported(`jpeg`,!0,!1),e.WEBP.supported(`webp`,!0,!1),e.GIF.supported(`gif`,!0,!1),e.SVG.supported(`svg`,!0,!1),e.TEXT.supported(`text`,!0,!1),e.MP4.builder(`mp4`).allowFrom(),e.MP3.supported(`mp3`,!0,!1)];ready=!1;offload=!0;async init(){this.ready=!0}static bytesToBase64(e){let t=[];for(let n=0;n<e.length;n+=32768){let r=e.subarray(n,n+32768);t.push(String.fromCharCode(...r))}return btoa(t.join(``))}async doConvert(e,n,r){if(r.internal!==`html`)throw TypeError(`Unsupported output format: ${r.internal}`);let i=new TextEncoder,a=``;if(n.internal===`text`){let t=new TextDecoder;for(let n of e){let e=t.decode(n.bytes).replaceAll(`&`,`&amp;`).replaceAll(`<`,`&lt;`).replaceAll(`>`,`&gt;`);a+=`<pre>${e}</pre>`}}else for(let r of e){let e=t.bytesToBase64(r.bytes);n.mime.startsWith(`image/`)?a+=`<img src="data:${n.mime};base64,${e}"><br>`:n.mime.startsWith(`audio/`)?a+=`<audio controls>
            <source src="data:${n.mime};base64,${e}" type="${n.mime}"></source>
          </audio><br>`:a+=`<video controls>
            <source src="data:${n.mime};base64,${e}" type="${n.mime}"></source>
          </video><br>`}return[{bytes:i.encode(a),name:e[0].name.split(`.`).slice(0,-1).join(`.`)+`.`+r.extension}]}};export{t as default};"""

let render() = file
