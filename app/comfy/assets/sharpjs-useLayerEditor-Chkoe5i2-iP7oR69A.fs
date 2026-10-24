module ComfyUI.Assets.UseLayerEditorChkoe5i2IP7oR69AJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{m as e}from"./i18n-D6QG9v-J-FWl07wji.js";import{n as t}from"./toastStore-BZFn5ETr-DnIiwXtS.js";import{t as n}from"./dialogStore-CwBmO6N3-Bglr8nzn.js";import{it as r,k as i}from"./executionErrorStore-AFzyih5Y-BuCsP0h7.js";import{n as a,r as o,t as s}from"./layerEditorDialog-CJH_Pm90-f7KDDWlp.js";function c(){return{openLayerEditor:c=>{if(!c){console.error(`[LayerEditor] No node provided`);return}let l=i().getNodeImageUrls(c);!l||l.length<2?t().info(e(`layerEditor.title`),{description:e(`layerEditor.needsTwoImages`)}):n().showDialog({key:r,headerComponent:o,component:a,props:{node:c},dialogComponentProps:s})}}}export{c as useLayerEditor};"""

let render() = file
