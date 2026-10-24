module ComfyUI.Assets.ResolveWidgetValueAssetBwQkdQqmBU10ayM8Js

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{Ot as e}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";import{t}from"./api-Cwoz8_OZ-_ARMy4Sb.js";import{r as n}from"./useFeatureFlags-BSa5Y3eR-DZv27_Yo.js";import{_n as r,jn as i,o as a,st as o}from"./executionErrorStore-AFzyih5Y-BuCsP0h7.js";async function s(s,{signal:c}={}){let{filepath:l}=i(s),u=e=>l===(e.hash||e.name),d=r(),f=e(d.inputAssets.items).find(u)??e(d.outputAssets.items).find(u);if(f)return f;if(!n().flags.assetsEnabled)return;let p=o({limit:1,hash:l}),m=await(await t.fetchApi(`/assets?${p}`,{signal:c})).json().catch(()=>{}),h=a.safeParse(m);return h.success?h.data.assets[0]??null:void 0}export{s as t};"""

let render() = file
