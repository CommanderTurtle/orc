module ComfyUI.Assets.CameraInfoBDESW8Ui47eo6gYJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{Z as e}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";import{L as t,a as n,pr as r}from"./executionErrorStore-AFzyih5Y-BuCsP0h7.js";import{t as i}from"./CameraInfo-D7GGthdL-CDmVE-7T.js";r().registerExtension({name:`Comfy.CreateCameraInfo`,getCustomWidgets(){return{CAMERA_INFO_STATE(e){let r=new n({node:e,name:`camera_info_state`,component:i,inputSpec:{name:`camera_info_state`,type:`CAMERA_INFO_STATE`,isPreview:!1},options:{serialize:!1}});return r.type=`cameraInfo`,r.serialize=!1,t(e,r),{widget:r}}}},async nodeCreated(t){if(t.constructor.comfyClass!==`CreateCameraInfo`)return;let[n,r]=t.size;t.setSize([Math.max(n,360),Math.max(r,480)]),await e()}});"""

let render() = file
