module ComfyUI.Assets.NumberUtilDp4m46lkBrRjEHVMJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{En as e}from"./vendor-other-DMCJdr63-rGllg5-G.js";var t=t=>e(Math.round(t??0),0,100),n=(e,n)=>{let r=t(n);return new Intl.NumberFormat(e,{style:`percent`,maximumFractionDigits:0}).format((r||0)/100)},r=(e,t,n)=>{let r=t%100!=0;return new Intl.NumberFormat(e,{style:`currency`,currency:n.toUpperCase(),minimumFractionDigits:r?2:0,maximumFractionDigits:r?2:0}).format(t/100)},i=(e,t)=>r(e,t,`USD`);export{i,r as n,n as r,t};"""

let render() = file
