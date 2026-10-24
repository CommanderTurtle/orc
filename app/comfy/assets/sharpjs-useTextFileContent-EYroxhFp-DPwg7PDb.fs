module ComfyUI.Assets.UseTextFileContentEYroxhFpDPwg7PDbJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{Ot as e,lt as t}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";import{a as n}from"./vendor-vueuse-C6_JFg54-DSeevOl6.js";function r(r){let i=t(!1),a=t(!1);return{textContent:n(async()=>{a.value=!1;let{content:t,url:n}=e(r)??{};if(t!==void 0)return t;if(!n)return``;let i=await fetch(n);return i.ok?await i.text():(a.value=!0,``)},``,{evaluating:i,onError:()=>{a.value=!0}}),isLoading:i,hasError:a}}export{r as t};"""

let render() = file
