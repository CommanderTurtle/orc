module ConvertedFiles.Mega.Assets.IndexDNQzGXogJs

let file = """import{a as j,r as g,j as l,B as u}from"./index-aHpeEV8y.js";import{T as y}from"./ToolContent-B4ORy3df.js";import{T}from"./ToolCodeInput-CpT4hCek.js";import{T as w}from"./ToolTextResult-CwqjGqb-.js";import{g as b}from"./json-CsgXvmwA.js";import{C as S}from"./CheckboxWithDesc-BstBhCI6.js";import{T as N}from"./TextFieldWithDesc-Br8sqQWl.js";import{S as h}from"./SimpleRadio-bgT63ITl.js";import"./TextField-3OI-XynG.js";import"./ContentPaste-DKqpSfyH.js";import"./InputFooter-BDHup-Ls.js";import"./ResultFooter-CLp_AWC-.js";import"./FormControlLabel-zEBePngt.js";import"./Checkbox-BjITWEtX.js";import"./SwitchBase-BAC9Dj1s.js";import"./Radio-43K3h4aU.js";function d(o,e="",t={}){if(o==null)return e&&(t[e]=""),t;if(typeof o!="object")return e&&(t[e]=String(o)),t;if(Array.isArray(o))return o.forEach((r,s)=>{const i=e?`${e}[${s}]`:`[${s}]`;d(r,i,t)}),t;for(const[r,s]of Object.entries(o)){const i=e?`${e}.${r}`:r;d(s,i,t)}return t}function k(o){if(Array.isArray(o))return o.map(e=>d(e));if(typeof o=="object"&&o!==null)return[d(o)];throw new Error("JSON input must be an object or array of objects, not a bare primitive.")}function f(o,e){const{delimiter:t,quoteStrings:r}=e,s=o.replace(/"/g,'""'),i=o.includes(t)||o.includes('"')||o.includes(`
`)||o.includes("\r");return r==="always"?`"${s}"`:i?`"${s}"`:o}function v(o,e){const{delimiter:t,includeHeaders:r}=e;if(!t)throw new Error("No CSV delimiter.");let s;try{s=JSON.parse(o)}catch{throw new Error("Invalid JSON input.")}const i=k(s).filter(n=>Object.keys(n).length>0);if(i.length===0)throw new Error("No data found in the provided JSON.");const p=b(i),a=[];r&&a.push(p.map(n=>f(n,e)).join(t));for(const n of i){const c=p.map(C=>f(n[C]??"",e)).join(t);a.push(c)}return a.join(`\r
`)}const m={delimiter:",",includeHeaders:!0,quoteStrings:"auto"},x=[{title:"Array of objects",description:"Convert multiple JSON objects into CSV rows, one row per object.",sampleText:`[
  { "name": "John Doe", "age": 25, "city": "New York" },
  { "name": "Jane Doe", "age": 30, "city": "Los Angeles" },
  { "name": "Bob Smith", "age": 22, "city": "Chicago" }
]`,sampleResult:`name,age,city
John Doe,25,New York
Jane Doe,30,Los Angeles
Bob Smith,22,Chicago`,sampleOptions:{...m}},{title:"Nested object (dot notation)",description:"Nested keys are flattened using dot notation (e.g. address.city).",sampleText:`[
  {
    "name": "John Doe",
    "age": 25,
    "address": {
      "street": "123 Main St",
      "city": "New York",
      "state": "NY",
      "postalCode": "10001"
    },
    "hobbies": ["reading", "running"]
  }
]`,sampleResult:`name,age,address.street,address.city,address.state,address.postalCode,hobbies[0],hobbies[1]
John Doe,25,123 Main St,New York,NY,10001,reading,running`,sampleOptions:{...m}},{title:"Sparse rows",description:"Missing keys are filled with empty values to keep columns aligned.",sampleText:`[
  { "name": "Alice", "age": 30 },
  { "name": "Bob", "city": "Paris" },
  { "name": "Carol", "age": 25, "city": "Rome" }
]`,sampleResult:`name,age,city
Alice,30,
Bob,,Paris
Carol,25,Rome`,sampleOptions:{...m}}];function L({title:o}){const{t:e}=j("json"),[t,r]=g.useState(""),[s,i]=g.useState(""),p=(a,n)=>{if(n)try{const c=v(n,a);i(c)}catch(c){i(`Error: ${c instanceof Error?c.message:"Invalid JSON format"}`)}};return l.jsx(y,{title:o,input:t,setInput:r,initialValues:m,compute:p,exampleCards:x,inputComponent:l.jsx(T,{title:e("jsonToCsv.inputTitle"),value:t,onChange:r,language:"json"}),resultComponent:l.jsx(w,{title:e("jsonToCsv.outputTitle"),value:s,extension:"csv"}),getGroups:({values:a,updateField:n})=>[{title:e("jsonToCsv.delimiterOption"),component:l.jsx(u,{children:l.jsx(N,{description:e("jsonToCsv.options.delimiter"),value:a.delimiter,onOwnChange:c=>n("delimiter",c)})})},{title:e("jsonToCsv.quotingOption"),component:l.jsxs(u,{children:[l.jsx(h,{checked:a.quoteStrings==="auto",title:e("jsonToCsv.options.autoQuote.label"),description:e("jsonToCsv.options.autoQuote.description"),onClick:()=>n("quoteStrings","auto")}),l.jsx(h,{checked:a.quoteStrings==="always",title:e("jsonToCsv.options.alwaysQuote.label"),description:e("jsonToCsv.options.alwaysQuote.description"),onClick:()=>n("quoteStrings","always")})]})},{title:e("jsonToCsv.headerOption"),component:l.jsx(u,{children:l.jsx(S,{checked:a.includeHeaders,onChange:c=>n("includeHeaders",c),title:e("jsonToCsv.options.header.label"),description:e("jsonToCsv.options.header.description")})})}]})}export{L as default};
"""

let render() = file
