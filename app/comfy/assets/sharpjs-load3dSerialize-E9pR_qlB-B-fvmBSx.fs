module ComfyUI.Assets.Load3dSerializeE9pRQlBBFvmBSxJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";import{Tt as e}from"./vendor-vue-core-y4MynkKA-BstGHdqw.js";function t(t,n){let r=e(t.properties),i=r[`Camera Config`]||{cameraType:n.getCurrentCameraType(),fov:n.cameraManager.perspectiveCamera.fov};i.state=n.getCameraState(),r[`Camera Config`]=i,n.stopRecording();let a=n.getModelInfo(),o=a?[a]:[];return{camera_info:i.state??null,model_3d_info:o}}window.comfyAPI=window.comfyAPI||{},window.comfyAPI.load3dSerialize=window.comfyAPI.load3dSerialize||{},window.comfyAPI.load3dSerialize.snapshotLoad3dState=t;export{t};"""

let render() = file
