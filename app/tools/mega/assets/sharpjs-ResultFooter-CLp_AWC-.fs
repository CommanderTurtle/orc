module ConvertedFiles.Mega.Assets.ResultFooterCLpAWCJs

let file = """import{Q as F,R as N,r as U,U as E,V as q,_ as c,j as t,s as x,X as H,Y as d,Z as V,ao as b,ap as $,i as B,k as K,a as W,S as Z,h as S}from"./index-aHpeEV8y.js";import{d as G}from"./ContentPaste-DKqpSfyH.js";function L(r){return F("MuiCircularProgress",r)}N("MuiCircularProgress",["root","determinate","indeterminate","colorPrimary","colorSecondary","svg","circle","circleDeterminate","circleIndeterminate","circleDisableShrink"]);const O=["className","color","disableShrink","size","style","thickness","value","variant"];let f=r=>r,_,j,D,R;const a=44,Q=$(_||(_=f`
  0% {
    transform: rotate(0deg);
  }

  100% {
    transform: rotate(360deg);
  }
`)),T=$(j||(j=f`
  0% {
    stroke-dasharray: 1px, 200px;
    stroke-dashoffset: 0;
  }

  50% {
    stroke-dasharray: 100px, 200px;
    stroke-dashoffset: -15px;
  }

  100% {
    stroke-dasharray: 100px, 200px;
    stroke-dashoffset: -125px;
  }
`)),X=r=>{const{classes:e,variant:s,color:o,disableShrink:n}=r,i={root:["root",s,`color${d(o)}`],svg:["svg"],circle:["circle",`circle${d(s)}`,n&&"circleDisableShrink"]};return V(i,L,e)},Y=x("span",{name:"MuiCircularProgress",slot:"Root",overridesResolver:(r,e)=>{const{ownerState:s}=r;return[e.root,e[s.variant],e[`color${d(s.color)}`]]}})(({ownerState:r,theme:e})=>c({display:"inline-block"},r.variant==="determinate"&&{transition:e.transitions.create("transform")},r.color!=="inherit"&&{color:(e.vars||e).palette[r.color].main}),({ownerState:r})=>r.variant==="indeterminate"&&b(D||(D=f`
      animation: ${0} 1.4s linear infinite;
    `),Q)),A=x("svg",{name:"MuiCircularProgress",slot:"Svg",overridesResolver:(r,e)=>e.svg})({display:"block"}),J=x("circle",{name:"MuiCircularProgress",slot:"Circle",overridesResolver:(r,e)=>{const{ownerState:s}=r;return[e.circle,e[`circle${d(s.variant)}`],s.disableShrink&&e.circleDisableShrink]}})(({ownerState:r,theme:e})=>c({stroke:"currentColor"},r.variant==="determinate"&&{transition:e.transitions.create("stroke-dashoffset")},r.variant==="indeterminate"&&{strokeDasharray:"80px, 200px",strokeDashoffset:0}),({ownerState:r})=>r.variant==="indeterminate"&&!r.disableShrink&&b(R||(R=f`
      animation: ${0} 1.4s ease-in-out infinite;
    `),T)),or=U.forwardRef(function(e,s){const o=E({props:e,name:"MuiCircularProgress"}),{className:n,color:i="primary",disableShrink:w=!1,size:p=40,style:I,thickness:l=3.6,value:m=0,variant:k="indeterminate"}=o,z=q(o,O),u=c({},o,{color:i,disableShrink:w,size:p,thickness:l,value:m,variant:k}),v=X(u),h={},C={},y={};if(k==="determinate"){const P=2*Math.PI*((a-l)/2);h.strokeDasharray=P.toFixed(3),y["aria-valuenow"]=Math.round(m),h.strokeDashoffset=`${((100-m)/100*P).toFixed(3)}px`,C.transform="rotate(-90deg)"}return t.jsx(Y,c({className:H(v.root,n),style:c({width:p,height:p},C,I),ownerState:u,ref:s,role:"progressbar"},y,z,{children:t.jsx(A,{className:v.svg,ownerState:u,viewBox:`${a/2} ${a/2} ${a} ${a}`,children:t.jsx(J,{className:v.circle,style:h,ownerState:u,cx:a,cy:a,r:(a-l)/2,fill:"none",strokeWidth:l})})}))});var g={},rr=B;Object.defineProperty(g,"__esModule",{value:!0});var M=g.default=void 0,er=rr(K()),sr=t;M=g.default=(0,er.default)((0,sr.jsx)("path",{d:"M5 20h14v-2H5zM19 9h-4V3H9v6H5l7 7z"}),"Download");function ir({handleDownload:r,handleCopy:e,disabled:s,hideCopy:o,downloadLabel:n}){const{t:i}=W();return t.jsxs(Z,{mt:1,direction:"row",spacing:2,children:[t.jsx(S,{disabled:s,onClick:r,startIcon:t.jsx(M,{}),children:n||i("resultFooter.download")}),!o&&t.jsx(S,{disabled:s,onClick:e,startIcon:t.jsx(G,{}),children:i("resultFooter.copy")})]})}export{or as C,ir as R};
"""

let render() = file
