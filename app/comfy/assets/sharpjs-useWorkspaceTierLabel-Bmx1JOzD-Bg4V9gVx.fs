module ComfyUI.Assets.UseWorkspaceTierLabelBmx1JOzDBg4V9gVxJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{r as e}from"./vendor-i18n-D0rAmGhT-Dg6vqr98.js";var t={FREE:`free`,STANDARD:`standard`,CREATOR:`creator`,PRO:`pro`,FOUNDER:`founder`,FOUNDERS_EDITION:`founder`,ENTERPRISE:`enterprise`};function n(){let{t:n}=e();function r(e,r){if(!e)return``;if(e===`TEAM`)return n(`subscription.teamPlanName`);let i=t[e];if(!i)return``;let a=n(`subscription.tiers.${i}.name`);return r?n(`subscription.tierNameYearly`,{name:a}):a}function i(e){if(!e.isSubscribed)return null;if(e.subscriptionTier)return r(e.subscriptionTier,!1);if(!e.subscriptionPlan)return null;let n=e.subscriptionPlan.toUpperCase(),i=Object.keys(t).sort((e,t)=>t.length-e.length).find(e=>n===e||n.startsWith(`${e}_`));return i?r(i,n.includes(`YEARLY`)||n.includes(`ANNUAL`)):null}return{formatTierName:r,getTierLabel:i}}export{n as t};"""

let render() = file
