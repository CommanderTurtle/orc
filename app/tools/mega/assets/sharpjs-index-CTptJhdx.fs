module ConvertedFiles.Mega.Assets.IndexCTptJhdxJs

let file = """import{r as u,j as i,B as h}from"./index-aHpeEV8y.js";import{T as g}from"./ToolContent-B4ORy3df.js";import{T}from"./ToolTextInput-BkooUYLb.js";import{T as v}from"./ToolTextResult-CwqjGqb-.js";import{C as x}from"./CheckboxWithDesc-BstBhCI6.js";import{T as c}from"./TextFieldWithDesc-Br8sqQWl.js";import"./TextField-3OI-XynG.js";import"./ContentPaste-DKqpSfyH.js";import"./InputFooter-BDHup-Ls.js";import"./ResultFooter-CLp_AWC-.js";import"./FormControlLabel-zEBePngt.js";import"./Checkbox-BjITWEtX.js";import"./SwitchBase-BAC9Dj1s.js";const y=(l,s)=>{const a=l.split(`
`).map(e=>e.trim());let o=`<?xml version="1.0" encoding="UTF-8" ?>
<root>
`,m=[];const r=a.filter(e=>e&&!e.startsWith(s.comment)&&(!s.skipEmptyLines||e.trim()!==""));return r.length===0?`<?xml version="1.0" encoding="UTF-8" ?>
<root></root>`:(s.useHeaders&&(m=d(r[0],s),r.shift()),r.forEach((e,n)=>{const t=d(e,s);o+=`  <row id="${n}">
`,m.forEach((p,f)=>{o+=`    <${p}>${t[f]||""}</${p}>
`}),o+=`  </row>
`}),o+="</root>",o)},d=(l,s)=>{const a=[];let o="",m=!1;for(let r=0;r<l.length;r++){const e=l[r];e===s.quote?m=!m:e===s.delimiter&&!m?(a.push(o.trim()),o=""):o+=e}return a.push(o.trim()),a},C={delimiter:",",quote:'"',comment:"#",useHeaders:!0,skipEmptyLines:!0},j=[{title:"Basic CSV to XML",description:"Convert a simple CSV file into an XML format.",sampleText:`name,age,city
John,30,New York
Alice,25,London`,sampleResult:`<root>
  <row>
    <name>John</name>
    <age>30</age>
    <city>New York</city>
  </row>
  <row>
    <name>Alice</name>
    <age>25</age>
    <city>London</city>
  </row>
</root>`,sampleOptions:{...C,useHeaders:!0}}];function B({title:l}){const[s,a]=u.useState(""),[o,m]=u.useState(""),r=(e,n)=>{if(n)try{const t=y(n,e);m(t)}catch(t){m(`Error: ${t instanceof Error?t.message:"Invalid CSV format"}`)}};return i.jsx(g,{title:l,input:s,setInput:a,initialValues:C,compute:r,exampleCards:j,inputComponent:i.jsx(T,{title:"Input CSV",value:s,onChange:a}),resultComponent:i.jsx(v,{title:"Output XML",value:o,extension:"xml"}),getGroups:({values:e,updateField:n})=>[{title:"Input CSV Format",component:i.jsxs(h,{children:[i.jsx(c,{description:"Column Separator",value:e.delimiter,onOwnChange:t=>n("delimiter",t)}),i.jsx(c,{description:"Field Quote",onOwnChange:t=>n("quote",t),value:e.quote}),i.jsx(c,{description:"Comment Symbol",value:e.comment,onOwnChange:t=>n("comment",t)})]})},{title:"Conversion Options",component:i.jsxs(h,{children:[i.jsx(x,{checked:e.useHeaders,onChange:t=>n("useHeaders",t),title:"Use Headers",description:"First row is treated as column headers"}),i.jsx(x,{checked:e.skipEmptyLines,onChange:t=>n("skipEmptyLines",t),title:"Skip Empty Lines",description:"Don't process empty lines in the CSV"})]})}]})}export{B as default};
"""

let render() = file
