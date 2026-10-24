module ComfyUI.Assets.UseDismissableOverlayD1omIAMo88M4dKtQJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{Ot as e}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";import{j as t}from"./vendor-vueuse-C6_JFg54-DSeevOl6.js";var n=e=>e instanceof Node,r=(e,t)=>!!t?.contains(e);function i({isOpen:i,getOverlayEl:a,onDismiss:o,getTriggerEl:s,dismissOnScroll:c=!1}){let l=t=>{if(!e(i))return;let c=a();if(c){if(!n(t.target)){o();return}r(t.target,c)||r(t.target,s?.())||o()}};t(window,`pointerdown`,l,{capture:!0}),c&&t(window,`scroll`,l,{capture:!0,passive:!0})}export{i as t};"""

let render() = file
