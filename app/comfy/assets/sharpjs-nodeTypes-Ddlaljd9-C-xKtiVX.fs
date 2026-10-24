module ComfyUI.Assets.NodeTypesDdlaljd9CXKtiVXJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";var e=new Set([`Preview3D`,`PreviewGaussianSplat`,`PreviewPointCloud`,`Save3DAdvanced`,`SaveGaussianSplat`,`SavePointCloud`]),t=new Set([...e,`Load3D`,`Load3DAdvanced`,`SaveGLB`]),n=t=>e.has(t),r=e=>t.has(e),i=new Set([`CreateCameraInfo`,`CameraAngle`,`CreateLightInfo`]),a=e=>r(e)||i.has(e);window.comfyAPI=window.comfyAPI||{},window.comfyAPI.nodeTypes=window.comfyAPI.nodeTypes||{},window.comfyAPI.nodeTypes.isLoad3dResultViewerNode=n,window.comfyAPI.nodeTypes.isLoad3dNode=r,window.comfyAPI.nodeTypes.isThreeJsNode=a;export{n,a as r,r as t};"""

let render() = file
