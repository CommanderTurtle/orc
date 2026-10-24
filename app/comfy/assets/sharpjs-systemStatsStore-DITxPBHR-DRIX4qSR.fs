module ComfyUI.Assets.SystemStatsStoreDITxPBHRDRIX4qSRJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{P as e}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";import{x as t}from"./vendor-vueuse-C6_JFg54-DSeevOl6.js";import{t as n}from"./api-Cwoz8_OZ-_ARMy4Sb.js";var r=e(`systemStats`,()=>{let{state:e,isLoading:r,error:i,isReady:a,execute:o}=t(async()=>{try{return await n.getSystemStats()}catch(e){throw console.error(`Error fetching system stats:`,e),e}},null,{immediate:!0});function s(){if(!e.value?.system.os)return`other`;let t=e.value.system.os.toLowerCase();return t.includes(`windows`)?`git-windows`:t.includes(`darwin`)||t.includes(`mac`)?`git-mac`:t.includes(`linux`)?`git-linux`:`other`}return{systemStats:e,isLoading:r,error:i,isInitialized:a,refetchSystemStats:o,getFormFactor:s}});export{r as t};"""

let render() = file
