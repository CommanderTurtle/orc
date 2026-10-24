module ComfyUI.Assets.UseClickDragGuardByD94fY5BD3N45HcJs

let file = """import"./rolldown-runtime-CM1DJQSe-DW4eb1zL.js";function e(e,t){let n=e.x-t.x,r=e.y-t.y;return n*n+r*r}function t(t,n,r){return e(t,n)>r*r}function n(e=5){let n=null;function r(e){n={x:e.clientX,y:e.clientY}}function i(r){return n?t(n,{x:r.clientX,y:r.clientY},e):!1}function a(){n=null}return{recordStart:r,wasDragged:i,reset:a}}export{n,t};"""

let render() = file
