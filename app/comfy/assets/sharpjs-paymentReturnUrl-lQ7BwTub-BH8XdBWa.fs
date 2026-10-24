module ComfyUI.Assets.PaymentReturnUrlLQ7BwTubBH8XdBWaJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{r as e}from"./comfyApi-BNqOevDX-DGaZm-dl.js";var t=[`payment_intent`,`payment_intent_client_secret`,`redirect_status`],n=[`billing_result`,`billing_ref`],r=!1;function i(){let e=new URL(globalThis.location.href),i=t.filter(t=>e.searchParams.has(t)),a=n.filter(t=>e.searchParams.has(t));if(i.length!==0||a.length!==0){i.length>0&&(r=!0);for(let t of[...i,...a])e.searchParams.delete(t);globalThis.history.replaceState(globalThis.history.state,``,e)}}function a(){i();let e=r;return r=!1,e}function o(){let{origin:t,pathname:n}=globalThis.location;return t.startsWith(`https://`)||t.startsWith(`http://`)?`${t}${n}`:`${e()}/payment/success`}export{t as i,n,o as r,a as t};"""

let render() = file
