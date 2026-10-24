module ComfyUI.Assets.CloudFeedbackTopbarButtonCIl2l24CNoc8JrtJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{m as e}from"./i18n-D6QG9v-J-FWl07wji.js";import{n as t}from"./settingStore-CaB68G5y-6K2aa72C.js";import{pr as n}from"./executionErrorStore-AFzyih5Y-BuCsP0h7.js";import{r}from"./feedbackDialog-CR9OllMB-DWW3gmfZ.js";var i=[{icon:`icon-[hugeicons--megaphone-03]`,label:e(`actionbar.feedback`),tooltip:e(`actionbar.feedbackTooltip`),onClick:()=>r(`action-bar`)}];n().registerExtension({name:`Comfy.FeedbackButton`,get actionBarButtons(){return t().get(`Comfy.UI.TabBarLayout`)===`Legacy`?i:[]}});"""

let render() = file
