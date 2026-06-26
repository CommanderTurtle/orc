module ConvertedFiles.Mega.Assets.IndexDTUDQrVqJs

let file = """import{a as J,r as g,j as c,B as h}from"./index-aHpeEV8y.js";import{T as S}from"./ToolCodeInput-CpT4hCek.js";import{T as j}from"./ToolTextResult-CwqjGqb-.js";import{S as d}from"./SelectWithDesc-DRymgm_6.js";import{T as k}from"./ToolContent-B4ORy3df.js";import{g as x}from"./json-CsgXvmwA.js";import"./ContentPaste-DKqpSfyH.js";import"./InputFooter-BDHup-Ls.js";import"./ResultFooter-CLp_AWC-.js";import"./TextField-3OI-XynG.js";const b=(a,u)=>{const e=Object.keys(a).sort((s,t)=>{const p=s.localeCompare(t);return u==="asc"?p:-p}),o={};for(const s of e)o[s]=a[s];return o},O=(a,u)=>{const{mode:e,order:o,key:s}=u;let t;try{t=JSON.parse(a)}catch{throw new Error("Invalid JSON string")}if(e==="key"){if(Array.isArray(t)){if(t.length===0)throw new Error("Array is empty");return JSON.stringify(t.map(m=>b(m,o)),null,2)}if(typeof t!="object"||t===null)throw new Error("Input must be a JSON object or array of objects");return JSON.stringify(b(t,o),null,2)}if(!Array.isArray(t))throw new Error("Input must be a JSON array");if(t.length===0)throw new Error("Array is empty");const p=[...t].sort((m,f)=>{const i=m[s],l=f[s];if(i==null)return 1;if(l==null)return-1;if(typeof i=="object"&&typeof l=="object"){const r=JSON.stringify(i),n=JSON.stringify(l);return r<n?o==="asc"?-1:1:r>n?o==="asc"?1:-1:0}return i<l?o==="asc"?-1:1:i>l?o==="asc"?1:-1:0});return JSON.stringify(p,null,2)},C={mode:"value",key:"",order:"asc"},T=[{title:"Sort by name ascending",description:'Sort a JSON array of objects alphabetically by the "name" key.',sampleText:'[{"name":"Charlie","age":30},{"name":"Alice","age":25},{"name":"Bob","age":35}]',sampleResult:`[
  {
    "name": "Alice",
    "age": 25
  },
  {
    "name": "Bob",
    "age": 35
  },
  {
    "name": "Charlie",
    "age": 30
  }
]`,sampleOptions:{mode:"value",key:"name",order:"asc"}},{title:"Sort object keys alphabetically",description:"Sort the keys of a JSON object alphabetically in ascending order.",sampleText:'{"zebra":1,"apple":2,"mango":3}',sampleResult:`{
  "apple": 2,
  "mango": 3,
  "zebra": 1
}`,sampleOptions:{mode:"key",key:"",order:"asc"}}];function z({title:a,longDescription:u}){const{t:e}=J("json"),[o,s]=g.useState(""),[t,p]=g.useState(""),m=(r,n)=>{n.trim()&&p(O(n,r))},f=x(o),i=f.length>0?f.map(r=>({label:r,value:r})):[],l=({values:r,updateField:n})=>[{title:e("sortJson.options.title"),component:c.jsxs(h,{children:[c.jsx(d,{selected:r.mode,options:[{label:e("sortJson.options.sortByValue"),value:"value"},{label:e("sortJson.options.sortByKey"),value:"key"}],onChange:y=>{n("mode",y),n("key","")},description:e("sortJson.options.modeDescription")}),r.mode==="value"&&c.jsx(d,{selected:r.key,options:[{label:"Please select a key",value:""},...i],onChange:y=>n("key",y),description:e("sortJson.options.keyDescription")}),c.jsx(d,{selected:r.order,options:[{label:e("sortJson.options.ascending"),value:"asc"},{label:e("sortJson.options.descending"),value:"desc"}],onChange:y=>n("order",y),description:e("sortJson.options.orderDescription")})]})}];return c.jsx(k,{title:a,inputComponent:c.jsx(S,{title:e("sortJson.inputTitle"),value:o,onChange:s,language:"json"}),resultComponent:c.jsx(j,{title:e("sortJson.resultTitle"),value:t,extension:"json"}),initialValues:C,getGroups:l,compute:m,input:o,setInput:s,exampleCards:T,toolInfo:{title:`What is a ${a}?`,description:u}})}export{z as default};
"""

let render() = file
