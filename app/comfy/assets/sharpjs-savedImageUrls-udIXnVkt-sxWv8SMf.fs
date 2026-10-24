module ComfyUI.Assets.SavedImageUrlsUdIXnVktSxWv8SMfJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{o as e}from"./vendor-zod-DZAk-s84-Cq4H6kfT.js";import{o as t,t as n}from"./api-Cwoz8_OZ-_ARMy4Sb.js";import{t as r}from"./app-B21aUVlo-C_4svxRR.js";var i=[],a=e(t);function o(e){let t=a.safeParse(e);if(!t.success)return i;let o=r.getRandParam(),s=r.getPreviewFormatParam();return t.data.map(e=>{let t=new URLSearchParams(e);return n.apiURL(`/view?${t}${s}${o}`)})}export{o as t};"""

let render() = file
