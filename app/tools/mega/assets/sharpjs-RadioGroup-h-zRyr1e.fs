module ConvertedFiles.Mega.Assets.RadioGroupHZRyr1eJs

let file = """import{Q as v,R as y,r as t,V as j,M as V,a0 as w,K as M,j as f,_ as P,X as U,Z as _}from"./index-aHpeEV8y.js";import{a as b}from"./Radio-43K3h4aU.js";import{F}from"./FormGroup-DTy4K67C.js";function N(s){return v("MuiRadioGroup",s)}y("MuiRadioGroup",["root","row","error"]);const S=["actions","children","className","defaultValue","name","onChange","value"],k=s=>{const{classes:o,row:a,error:r}=s;return _({root:["root",a&&"row",r&&"error"]},N,o)},H=t.forwardRef(function(o,a){const{actions:r,children:l,className:m,defaultValue:p,name:R,onChange:n,value:x}=o,h=j(o,S),u=t.useRef(null),C=k(o),[i,c]=V({controlled:x,default:p,name:"RadioGroup"});t.useImperativeHandle(r,()=>({focus:()=>{let e=u.current.querySelector("input:not(:disabled):checked");e||(e=u.current.querySelector("input:not(:disabled)")),e&&e.focus()}}),[]);const g=w(a,u),d=M(R),G=t.useMemo(()=>({name:d,onChange(e){c(e.target.value),n&&n(e,e.target.value)},value:i}),[d,n,c,i]);return f.jsx(b.Provider,{value:G,children:f.jsx(F,P({role:"radiogroup",ref:g,className:U(C.root,m)},h,{children:l}))})});export{H as R};
"""

let render() = file
