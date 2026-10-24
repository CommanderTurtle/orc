module ComfyUI.Assets.AudioServiceBxaNkVkbBB7wiKo4Js

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{at as e,ut as t}from"./vendor-other-DMCJdr63-rGllg5-G.js";import{n}from"./Load3dUtils-CUFiVR0e-ClZvO5Il.js";var r=!1,i=()=>{let i=(e,t,n)=>{console.error(`Audio Service Error (${e}):`,t,n)};return{convertBlobToFileAndSubmit:async e=>{let t=`recording-${Date.now()}.wav`,r=new File([e],t,{type:e.type||`audio/wav`}),i=await n(r,`audio`);if(!i.ok)throw Error(`Error uploading temp file: ${i.reason}`);return`audio/${i.file.name} [temp]`},registerWavEncoder:async()=>{if(!r)try{await t(await e()),r=!0}catch(e){e instanceof Error&&e.message.includes(`already an encoder stored`)?r=!0:i(`encoder`,`Failed to register WAV encoder`,e)}},stopAllTracks:e=>{e&&e.getTracks().forEach(e=>{e.stop()})}}};export{i as t};"""

let render() = file
