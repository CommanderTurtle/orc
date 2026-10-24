module ComfyUI.Assets.ComfyApiBNqOevDXDGaZmDlJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{n as e,r as t}from"./remoteConfig-BNa4-Pry-BYD5-tMC.js";var n=`https://api.comfy.org`,r=`https://cloud.comfy.org`,i=`https://platform.comfy.org`,a=n,o=r,s=i;function c(n,r){let i=t(e.value,n,r);try{let e=new URL(i);return e.protocol!==`https:`||!e.hostname?r:e.href.replace(/\/$/,``)}catch{return r}}function l(){return c(`comfy_api_base_url`,a)}function u(){return c(`comfy_cloud_base_url`,o)}function d(){return c(`comfy_platform_base_url`,s)}export{u as n,d as r,l as t};"""

let render() = file
