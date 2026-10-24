module ComfyUI.Assets.ToastStoreBZFn5ETrDnIiwXtSJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{P as e,lt as t}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";var n=0;function r(){return n+=1,n}var i=e(`toast`,()=>{let e=t([]),n=t(!1);function i(t,n,i={}){let a=i.id??r();return e.value=[...e.value.filter(e=>e.id!==a),{action:i.action,closable:i.closable??!0,description:i.description,duration:i.duration??1/0,id:a,instance:Symbol(),kind:t,title:n}],a}function a(e,t){return i(`success`,e,t)}function o(e,t){return i(`error`,e,t)}function s(e,t){return i(`info`,e,t)}function c(e,t){return i(`warning`,e,t)}function l(e,t){return i(`loading`,e,t)}function u(t){let n=e.value.filter(e=>e.id!==t),r=n.length<e.value.length;return e.value=n,r}function d(){e.value=[]}return{held:n,toasts:e,success:a,error:o,info:s,warning:c,loading:l,dismiss:u,dismissAll:d}});export{i as n,r as t};"""

let render() = file
