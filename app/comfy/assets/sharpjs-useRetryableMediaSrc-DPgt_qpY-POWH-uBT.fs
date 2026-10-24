module ComfyUI.Assets.UseRetryableMediaSrcDPgtQpYPOWHUBTJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{Ot as e,Z as t,ct as n,lt as r,zt as i}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";import{at as a}from"./vendor-vueuse-C6_JFg54-DSeevOl6.js";var o=[500,1e3,2e3,4e3,8e3];function s(s){let c=r(),l=r(`idle`),u=0,d=0,f=r(o[0]),p=async()=>{let n=++d;c.value=void 0,await t(),n===d&&(c.value=e(s),l.value=`loading`)},{start:m,stop:h}=a(p,f,{immediate:!1});return i(()=>e(s),e=>{h(),d++,u=0,c.value=e,l.value=e?`loading`:`idle`},{immediate:!0,flush:`sync`}),{src:n(c),status:n(l),onError:()=>{if(l.value===`loading`){if(u>=o.length){l.value=`failed`;return}f.value=o[u],u++,l.value=`retrying`,m()}},retry:()=>{l.value!==`idle`&&(h(),u=0,l.value=`retrying`,p())}}}export{s as t};"""

let render() = file
