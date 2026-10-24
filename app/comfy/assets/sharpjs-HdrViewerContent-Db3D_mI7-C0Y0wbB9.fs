module ComfyUI.Assets.HdrViewerContentDb3DMI7C0Y0wbB9Js

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{At as e,Ct as t,E as n,Jt as r,K as i,N as a,Q as o,Rt as s,Ut as c,Wt as l,_ as u,b as d,dt as f,h as p,i as m,it as h,k as g,lt as _,n as v,s as y,u as b,y as x,yt as S,zt as ee}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";import{A as C,D as w,Dt as T,Ht as E,J as D,Mt as O,Pt as te,at as k,g as A,i as j,jt as M,kt as ne,lt as re,ot as ie,p as N,ut as ae,z as oe}from"./vendor-three-zoI3eWBk-BVQBizAn.js";import{t as P}from"./Button-BXQ0rlkG-CIWom5KZ.js";import{r as F}from"./vendor-i18n-D0rAmGhT-Dg6vqr98.js";import{n as I}from"./downloadUtil-DgEIt99l-CMH5ByQd.js";import{r as L,s as R}from"./hdrFormatUtil-lH9_7sz--DhZ5Qqyt.js";import{t as z}from"./histogramUtil-ChFnB6_u-CCSFuTAZ.js";var B=[.3127,.329],V={sRGB:{red:[.64,.33],green:[.3,.6],blue:[.15,.06],white:B},"Rec.2020":{red:[.708,.292],green:[.17,.797],blue:[.131,.046],white:B}},H=Object.keys(V),U=[1,0,0,0,1,0,0,0,1];function W(e){let[t,n]=e.red,[r,i]=e.green,[a,o]=e.blue,[s,c]=e.white,l=s/c,u=(1-s-c)/c,d=t*(o-i)+a*(i-n)+r*(n-o),f=l*(o-i)-r*(o-1+o*(l+u))+a*(i-1+i*(l+u)),p=l*(n-o)+t*(o-1+o*(l+u))-a*(n-1+n*(l+u)),m=l*(i-n)-t*(i-1+i*(l+u))+r*(n-1+n*(l+u)),h=f/d,g=p/d,_=m/d;return[h*t,g*r,_*a,h*n,g*i,_*o,h*(1-t-n),g*(1-r-i),_*(1-a-o)]}function se(e,t){let n=Array.from({length:9},()=>0);for(let r=0;r<3;r++)for(let i=0;i<3;i++){let a=0;for(let n=0;n<3;n++)a+=e[r*3+n]*t[n*3+i];n[r*3+i]=a}return n}function G(e){let[t,n,r,i,a,o,s,c,l]=e,u=t*(a*l-o*c)-n*(i*l-o*s)+r*(i*c-a*s);if(u===0)return U;let d=1/u;return[(a*l-o*c)*d,(r*c-n*l)*d,(n*o-r*a)*d,(o*s-i*l)*d,(t*l-r*s)*d,(r*i-t*o)*d,(i*c-a*s)*d,(n*s-t*c)*d,(t*a-n*i)*d]}var ce=G(W(V.sRGB));function le(e){return e===`sRGB`?U:se(ce,W(V[e]))}function ue(e,t){let n=V[t],r=.01;return Math.abs(e.redX-n.red[0])<r&&Math.abs(e.redY-n.red[1])<r&&Math.abs(e.greenX-n.green[0])<r&&Math.abs(e.greenY-n.green[1])<r&&Math.abs(e.blueX-n.blue[0])<r&&Math.abs(e.blueY-n.blue[1])<r&&Math.abs(e.whiteX-n.white[0])<r&&Math.abs(e.whiteY-n.white[1])<r}function de(e){return e?H.find(t=>ue(e,t))??`sRGB`:`sRGB`}var fe=`
out vec2 vUv;

void main() {
  vUv = uv;
  gl_Position = projectionMatrix * modelViewMatrix * vec4(position, 1.0);
}
`,pe=`
in vec2 vUv;
out vec4 frag_color;

uniform sampler2D uImage;
uniform mat3 uGamutToSRGB;
uniform float uGain;
uniform int uChannel;
uniform bool uDither;
uniform bool uClipWarnings;
uniform vec2 uClipRange;
uniform bool uCheckerboard;
uniform float uCheckerSize;

const float CHECK_DARK_LINEAR = 0.1329;
const float CHECK_LIGHT_LINEAR = 0.3185;

float linearToS(float a) {
  float s = sign(a);
  a = abs(a);
  return s * (a < 0.0031308 ? 12.92 * a : 1.055 * pow(a, 1.0 / 2.4) - 0.055);
}

vec3 linearToSRGB(vec3 c) {
  return vec3(linearToS(c.r), linearToS(c.g), linearToS(c.b));
}

float ign(vec2 p) {
  return fract(52.9829189 * fract(0.06711056 * p.x + 0.00583715 * p.y));
}

float tent(float r) {
  float rp = sqrt(2.0 * r);
  float rn = sqrt(2.0 * r + 1.0) - 1.0;
  return (r < 0.0) ? 0.5 * rn : 0.5 * rp;
}

void main() {
  vec4 texel = texture(uImage, vUv);
  vec3 mapped = uGamutToSRGB * texel.rgb;

  vec3 selected;
  if (uChannel == 1) selected = vec3(mapped.r);
  else if (uChannel == 2) selected = vec3(mapped.g);
  else if (uChannel == 3) selected = vec3(mapped.b);
  else if (uChannel == 4) selected = vec3(texel.a);
  else if (uChannel == 5)
    selected = vec3(dot(mapped, vec3(0.2126, 0.7152, 0.0722)));
  else selected = mapped;

  vec3 exposed = selected * uGain;

  vec3 composited = exposed;
  if (uCheckerboard && uChannel == 0) {
    vec2 cell = floor(gl_FragCoord.xy / uCheckerSize);
    float check = mod(cell.x + cell.y, 2.0) == 0.0
      ? CHECK_DARK_LINEAR
      : CHECK_LIGHT_LINEAR;
    composited += (1.0 - clamp(texel.a, 0.0, 1.0)) * vec3(check);
  }

  vec3 display = linearToSRGB(composited);

  if (uDither) {
    float r = ign(gl_FragCoord.xy) - 0.5;
    display += vec3(tent(r) / 255.0);
  }

  display = clamp(display, 0.0, 1.0);

  if (uClipWarnings) {
    float zebra1 =
      mod(floor((gl_FragCoord.x + gl_FragCoord.y) / 8.0), 2.0) == 0.0 ? 0.0 : 1.0;
    float zebra2 =
      mod(floor((gl_FragCoord.x - gl_FragCoord.y) / 8.0), 2.0) == 0.0 ? 0.0 : 1.0;
    bvec3 over = greaterThan(exposed, vec3(uClipRange.y));
    bvec3 under = lessThan(exposed, vec3(uClipRange.x));
    display = mix(display, vec3(zebra1), vec3(over));
    display = mix(display, vec3(zebra2), vec3(under));
  }

  frag_color = vec4(display, 1.0);
}
`;function me(e,t,n){let r=1/0,i=-1/0,a=0,o=0,s=0,c=0,l=0;for(let u=0;u<t;u++){let t=e(u);Number.isNaN(t)?c++:Number.isFinite(t)?(n!==4||u%n!==3)&&(t<r&&(r=t),t>i&&(i=t),a+=t,o+=t*t,s++):l++}if(s===0)return{min:0,max:0,mean:0,stdDev:0,nanCount:c,infCount:l};let u=a/s,d=Math.max(0,o/s-u*u);return{min:r,max:i,mean:u,stdDev:Math.sqrt(d),nanCount:c,infCount:l}}function he(e,t,n,r=256){let i=r-1,a=new Uint32Array(r),o=new Uint32Array(r),s=new Uint32Array(r),c=new Uint32Array(r),l=n===4?new Uint32Array(r):null,u=(e,t)=>{if(Number.isNaN(t))return;let n=Math.floor(Math.max(0,t)*r);e[n>i?i:n]++};for(let r=0;r+n-1<t;r+=n){let t=e(r),i=n>=3?e(r+1):t,d=n>=3?e(r+2):t;u(a,t),u(o,i),u(s,d),l&&u(l,e(r+3)),u(c,n>=3?.2126*t+.7152*i+.0722*d:t)}return{r:a,g:o,b:s,a:l,luminance:c}}var ge=class{renderer;resizeObserver=null;constructor(e){this.renderer=e}observeResize(e,t){typeof ResizeObserver>`u`||(this.resizeObserver?.disconnect(),this.resizeObserver=new ResizeObserver(()=>t()),this.resizeObserver.observe(e))}disposeRenderer(){this.resizeObserver?.disconnect(),this.resizeObserver=null,this.renderer.forceContextLoss(),this.renderer.domElement.dispatchEvent(new Event(`webglcontextlost`,{bubbles:!0,cancelable:!0})),this.renderer.dispose(),this.renderer.domElement.remove()}},_e=.05,ve=64,ye=8,be=[`rgb`,`r`,`g`,`b`,`a`,`luminance`],xe={rgb:0,r:1,g:2,b:3,a:4,luminance:5};function K(e){if(L(e)?.toLowerCase().endsWith(`.hdr`))return new k;let t=new A;return t.setDataType(O),t}function Se(e,t){return t===1016?t=>N.fromHalfFloat(e[t]):t=>e[t]}function Ce(e){return new Promise((t,n)=>{K(e).load(e,(e,n)=>{let r=n.header?.chromaticities;t({texture:e,gamut:de(r)})},void 0,n)})}function q(){let e=_(0),t=_(!0),n=_(!1),r=_(!0),i=_(`sRGB`),a=_(`rgb`),o=_(!0),s=_(null),c=_(null),l=_(null),u=S(null),d=_(null),f=p(()=>{let e=u.value;if(!e)return null;switch(a.value){case`r`:return e.r;case`g`:return e.g;case`b`:return e.b;case`a`:return e.a;default:return e.luminance}}),m=S(null),h=null,v=null,y=null,b=null,x=null,O=null,k=null,A=1,N=!1,P=null,F=0,I=0,L=4,R=new ie,z=new j;function B(){!h||N||(N=!0,requestAnimationFrame(()=>{N=!1,h&&y&&b&&h.render(y,b)}))}function V(){let e=m.value;return{width:e?.clientWidth||1,height:e?.clientHeight||1}}function H(){if(!b)return;let{width:e,height:t}=V(),n=.5*e/t;b.left=-n,b.right=n,b.top=.5,b.bottom=-.5,b.updateProjectionMatrix()}function U(){if(!b)return;let{width:e,height:t}=V(),n=e/t;b.zoom=Math.min(1,n/A),b.position.set(0,0,1),b.updateProjectionMatrix(),B()}function W(){if(!x)return;x.uniforms.uGain.value=2**e.value,x.uniforms.uDither.value=t.value,x.uniforms.uClipWarnings.value=n.value,x.uniforms.uCheckerboard.value=r.value,x.uniforms.uChannel.value=xe[a.value];let o=le(i.value);x.uniforms.uGamutToSRGB.value.set(o[0],o[1],o[2],o[3],o[4],o[5],o[6],o[7],o[8]),B()}function se(){h=new T({antialias:!1,alpha:!1}),v=new ge(h),h.outputColorSpace=C,h.setPixelRatio(window.devicePixelRatio),h.setClearColor(657930,1),y=new re,b=new D(-1,1,1,-1,.1,10),b.position.set(0,0,1),x=new ae({glslVersion:ne,vertexShader:fe,fragmentShader:pe,uniforms:{uImage:{value:null},uGamutToSRGB:{value:new w},uGain:{value:1},uChannel:{value:0},uDither:{value:!0},uClipWarnings:{value:!1},uClipRange:{value:new j(0,1)},uCheckerboard:{value:!0},uCheckerSize:{value:ye*h.getPixelRatio()}}}),O=new oe(new te(1,1),x),y.add(O)}function G(){if(!h)return;let{width:e,height:t}=V();h.setSize(e,t,!1),H(),B()}function ce(e){if(!x||!O)return;e.colorSpace=C,e.minFilter=E,e.magFilter=E,e.needsUpdate=!0;let{width:t,height:n,data:r}=e.image;k=e,A=t/n,O.scale.set(A,1,1),x.uniforms.uImage.value=e,c.value=`${t} x ${n}`,r&&(F=t,I=n,L=r.length/(t*n),P=Se(r,e.type),l.value=me(P,r.length,L),u.value=he(P,r.length,L))}async function ue(e,t){m.value=e,o.value=!0,s.value=null;try{se(),e.appendChild(h.domElement),h.domElement.classList.add(`block`,`size-full`),G(),W(),be(h.domElement),v.observeResize(e,G);let{texture:n,gamut:r}=await Ce(t);if(!x||!O){n.dispose();return}i.value=r,ce(n),W(),U()}catch(e){s.value=e instanceof Error?e.message:String(e),$()}finally{o.value=!1}}function de(){let t=l.value?.max??0;e.value=t>0?-Math.log2(t):0}function be(e){e.addEventListener(`wheel`,K,{passive:!1}),e.addEventListener(`pointerdown`,J),e.addEventListener(`pointermove`,Z),e.addEventListener(`pointerleave`,Q)}function K(e){if(!b)return;e.preventDefault();let t=Math.exp(-e.deltaY*.001),n=M.clamp(b.zoom*t,_e,ve);b.zoom=n,b.updateProjectionMatrix(),B()}let q=null;function J(e){b&&(q={x:e.clientX,y:e.clientY,camX:b.position.x,camY:b.position.y},window.addEventListener(`pointermove`,Y),window.addEventListener(`pointerup`,X))}function Y(e){if(!b||!q)return;let{height:t}=V(),n=1/(t*b.zoom);b.position.x=q.camX-(e.clientX-q.x)*n,b.position.y=q.camY+(e.clientY-q.y)*n,B()}function X(){q=null,window.removeEventListener(`pointermove`,Y),window.removeEventListener(`pointerup`,X)}function Z(e){if(!b||!O||!h||q||!P)return;let t=h.domElement.getBoundingClientRect();z.x=(e.clientX-t.left)/t.width*2-1,z.y=-((e.clientY-t.top)/t.height*2-1),R.setFromCamera(z,b);let n=R.intersectObject(O).at(0);if(!n?.uv){d.value=null;return}let r=M.clamp(Math.floor(n.uv.x*F),0,F-1),i=M.clamp(Math.floor(n.uv.y*I),0,I-1),a=(i*F+r)*L;d.value={x:r,y:I-1-i,r:P(a),g:P(a+1),b:P(a+2),a:L===4?P(a+3):null}}function Q(){d.value=null}function $(){window.removeEventListener(`pointermove`,Y),window.removeEventListener(`pointerup`,X),h&&(h.domElement.removeEventListener(`wheel`,K),h.domElement.removeEventListener(`pointerdown`,J),h.domElement.removeEventListener(`pointermove`,Z),h.domElement.removeEventListener(`pointerleave`,Q)),v?.disposeRenderer(),k?.dispose(),x?.dispose(),O?.geometry.dispose(),h=null,v=null,y=null,b=null,x=null,O=null,k=null,P=null}return ee([e,t,n,r,i,a],W),g($),{exposureStops:e,dither:t,clipWarnings:n,checkerboard:r,gamut:i,channel:a,loading:o,error:s,dimensions:c,stats:l,histogram:f,pixel:d,mount:ue,dispose:$,fitView:U,normalizeExposure:de}}var J={class:`flex size-full bg-base-background`},Y={class:`relative flex-1`},X={key:0,class:`absolute inset-0 flex items-center justify-center text-base-foreground`},Z={key:1,role:`alert`,class:`absolute inset-0 flex flex-col items-center justify-center gap-2 text-base-foreground`},Q={class:`text-sm`},$={key:2,class:`absolute top-2 left-2 rounded-sm bg-base-background/80 px-2 py-1 font-mono text-xs text-base-foreground`,"data-testid":`hdr-pixel-readout`},we={class:`flex w-72 flex-col`,"data-testid":`hdr-viewer-sidebar`},Te={class:`flex-1 overflow-y-auto p-4`},Ee={class:`space-y-2`},De={class:`space-y-4 p-2`},Oe={class:`flex flex-col gap-2`},ke=[`aria-label`],Ae={class:`space-y-4 p-2`},je={class:`flex flex-col gap-2`},Me=[`aria-label`],Ne=[`value`],Pe={class:`flex flex-col gap-2`},Fe=[`aria-label`],Ie=[`value`],Le={class:`space-y-4 p-2`},Re={class:`flex items-center gap-2`},ze={for:`hdr-dither`,class:`cursor-pointer`},Be={class:`flex items-center gap-2`},Ve={for:`hdr-clip`,class:`cursor-pointer`},He={class:`flex items-center gap-2`},Ue={for:`hdr-checkerboard`,class:`cursor-pointer`},We={key:0,class:`space-y-2 p-2`},Ge={viewBox:`0 0 1 1`,preserveAspectRatio:`none`,class:`aspect-3/2 w-full rounded-sm bg-secondary-background`},Ke=[`d`],qe={key:1,class:`space-y-1 p-2 text-xs tabular-nums`},Je={key:0,class:`flex justify-between`},Ye={class:`flex justify-between`},Xe={class:`flex justify-between`},Ze={class:`flex justify-between`},Qe={class:`flex justify-between`},$e={key:1,class:`flex justify-between text-error`},et={key:2,class:`flex justify-between text-error`},tt={class:`p-4`},nt={class:`flex gap-2`},rt=a({__name:`HdrViewerContent`,props:{imageUrl:{}},setup(a){let{t:g}=F(),_=q(),S=H,ee=be,C=s(`containerRef`),w=p(()=>{let e=_.exposureStops.value;return`${e>0?`+`:``}${e.toFixed(1)}`}),T=p(()=>_.histogram.value?z(_.histogram.value):``),E=p(()=>{switch(_.channel.value){case`r`:return`text-red-500`;case`g`:return`text-green-500`;case`b`:return`text-blue-500`;default:return`text-base-foreground`}}),D=p(()=>({rgb:g(`hdrViewer.channels.rgb`),r:g(`hdrViewer.channels.r`),g:g(`hdrViewer.channels.g`),b:g(`hdrViewer.channels.b`),a:g(`hdrViewer.channels.a`),luminance:g(`hdrViewer.channels.luminance`)}));function O(e){return Number.isFinite(e)?Math.abs(e)>=1e3||e!==0&&Math.abs(e)<.001?e.toExponential(3):e.toFixed(4):String(e)}function te(){I(R(a.imageUrl))}return i(()=>{C.value&&_.mount(C.value,a.imageUrl)}),(i,a)=>(h(),d(`div`,J,[u(`div`,Y,[u(`div`,{ref_key:`containerRef`,ref:C,class:`absolute size-full`,"data-testid":`hdr-viewer-canvas`},null,512),e(_).loading.value?(h(),d(`div`,X,t(i.$t(`g.loading`))+`... `,1)):e(_).error.value?(h(),d(`div`,Z,[a[6]||=u(`i`,{class:`icon-[lucide--image-off] size-12`},null,-1),u(`p`,Q,t(i.$t(`hdrViewer.failedToLoad`)),1)])):x(``,!0),e(_).pixel.value?(h(),d(`div`,$,[u(`div`,null,t(e(_).pixel.value.x)+`, `+t(e(_).pixel.value.y),1),u(`div`,null,[n(t(O(e(_).pixel.value.r))+` `+t(O(e(_).pixel.value.g))+` `+t(O(e(_).pixel.value.b))+` `,1),e(_).pixel.value.a===null?x(``,!0):(h(),d(y,{key:0},[n(t(O(e(_).pixel.value.a)),1)],64))])])):x(``,!0)]),u(`div`,we,[u(`div`,Te,[u(`div`,Ee,[u(`div`,De,[u(`div`,Oe,[u(`label`,null,t(i.$t(`hdrViewer.exposure`))+`: `+t(w.value),1),l(u(`input`,{"onUpdate:modelValue":a[0]||=t=>e(_).exposureStops.value=t,type:`range`,min:`-10`,max:`10`,step:`0.1`,class:`w-full`,"aria-label":i.$t(`hdrViewer.exposure`)},null,8,ke),[[v,e(_).exposureStops.value,void 0,{number:!0}]])]),b(P,{variant:`secondary`,class:`w-full`,onClick:e(_).normalizeExposure},{default:c(()=>[n(t(i.$t(`hdrViewer.normalizeExposure`)),1)]),_:1},8,[`onClick`])]),u(`div`,Ae,[u(`div`,je,[u(`label`,null,t(i.$t(`hdrViewer.channel`)),1),l(u(`select`,{"onUpdate:modelValue":a[1]||=t=>e(_).channel.value=t,class:`w-full rounded-sm bg-secondary-background px-2 py-1`,"aria-label":i.$t(`hdrViewer.channel`)},[(h(!0),d(y,null,f(e(ee),e=>(h(),d(`option`,{key:e,value:e},t(D.value[e]),9,Ne))),128))],8,Me),[[m,e(_).channel.value]])]),u(`div`,Pe,[u(`label`,null,t(i.$t(`hdrViewer.sourceGamut`)),1),l(u(`select`,{"onUpdate:modelValue":a[2]||=t=>e(_).gamut.value=t,class:`w-full rounded-sm bg-secondary-background px-2 py-1`,"aria-label":i.$t(`hdrViewer.sourceGamut`)},[(h(!0),d(y,null,f(e(S),e=>(h(),d(`option`,{key:e,value:e},t(e),9,Ie))),128))],8,Fe),[[m,e(_).gamut.value]])])]),u(`div`,Le,[u(`div`,Re,[l(u(`input`,{id:`hdr-dither`,"onUpdate:modelValue":a[3]||=t=>e(_).dither.value=t,type:`checkbox`,class:`size-4 cursor-pointer accent-node-component-surface-highlight`},null,512),[[r,e(_).dither.value]]),u(`label`,ze,t(i.$t(`hdrViewer.dither`)),1)]),u(`div`,Be,[l(u(`input`,{id:`hdr-clip`,"onUpdate:modelValue":a[4]||=t=>e(_).clipWarnings.value=t,type:`checkbox`,class:`size-4 cursor-pointer accent-node-component-surface-highlight`},null,512),[[r,e(_).clipWarnings.value]]),u(`label`,Ve,t(i.$t(`hdrViewer.clipWarnings`)),1)]),u(`div`,He,[l(u(`input`,{id:`hdr-checkerboard`,"onUpdate:modelValue":a[5]||=t=>e(_).checkerboard.value=t,type:`checkbox`,class:`size-4 cursor-pointer accent-node-component-surface-highlight`},null,512),[[r,e(_).checkerboard.value]]),u(`label`,Ue,t(i.$t(`hdrViewer.checkerboard`)),1)])]),T.value?(h(),d(`div`,We,[u(`label`,null,t(i.$t(`hdrViewer.histogram`)),1),(h(),d(`svg`,Ge,[u(`path`,{d:T.value,class:o(E.value),fill:`currentColor`,"fill-opacity":`0.5`,stroke:`none`},null,10,Ke)]))])):x(``,!0),e(_).stats.value?(h(),d(`div`,qe,[e(_).dimensions.value?(h(),d(`div`,Je,[u(`span`,null,t(i.$t(`hdrViewer.resolution`)),1),u(`span`,null,t(e(_).dimensions.value),1)])):x(``,!0),u(`div`,Ye,[u(`span`,null,t(i.$t(`hdrViewer.min`)),1),u(`span`,null,t(O(e(_).stats.value.min)),1)]),u(`div`,Xe,[u(`span`,null,t(i.$t(`hdrViewer.max`)),1),u(`span`,null,t(O(e(_).stats.value.max)),1)]),u(`div`,Ze,[u(`span`,null,t(i.$t(`hdrViewer.mean`)),1),u(`span`,null,t(O(e(_).stats.value.mean)),1)]),u(`div`,Qe,[u(`span`,null,t(i.$t(`hdrViewer.stdDev`)),1),u(`span`,null,t(O(e(_).stats.value.stdDev)),1)]),e(_).stats.value.nanCount?(h(),d(`div`,$e,[u(`span`,null,t(i.$t(`hdrViewer.nan`)),1),u(`span`,null,t(e(_).stats.value.nanCount),1)])):x(``,!0),e(_).stats.value.infCount?(h(),d(`div`,et,[u(`span`,null,t(i.$t(`hdrViewer.inf`)),1),u(`span`,null,t(e(_).stats.value.infCount),1)])):x(``,!0)])):x(``,!0)])]),u(`div`,tt,[u(`div`,nt,[b(P,{variant:`secondary`,class:`flex-1`,onClick:e(_).fitView},{default:c(()=>[n(t(i.$t(`hdrViewer.fitView`)),1)]),_:1},8,[`onClick`]),b(P,{variant:`secondary`,class:`flex-1`,onClick:te},{default:c(()=>[n(t(i.$t(`g.downloadImage`)),1)]),_:1})])])])]))}});export{rt as default};"""

let render() = file
