module ConvertedFiles.Mega.Assets.IndexDAbWKKcEJs

let file = """import{r as d,j as c,B as f}from"./index-aHpeEV8y.js";import{T}from"./ToolContent-B4ORy3df.js";import{T as x}from"./ToolCodeInput-CpT4hCek.js";import{T as y}from"./ToolTextResult-CwqjGqb-.js";import{C as j}from"./CheckboxWithDesc-BstBhCI6.js";import{S as m}from"./SimpleRadio-bgT63ITl.js";import"./TextField-3OI-XynG.js";import"./ContentPaste-DKqpSfyH.js";import"./InputFooter-BDHup-Ls.js";import"./ResultFooter-CLp_AWC-.js";import"./FormControlLabel-zEBePngt.js";import"./Checkbox-BjITWEtX.js";import"./SwitchBase-BAC9Dj1s.js";import"./Radio-43K3h4aU.js";const M=(s,e)=>{const o=JSON.parse(s);return p(o,e)},u=(s,e)=>{switch(s.indentationType){case"space":return"  ".repeat(e+1);case"tab":return"	".repeat(e+1);case"none":default:return""}},p=(s,e,o=0)=>{let n="";const a=e.indentationType==="none"?"":`
`;o===0&&(e.addMetaTag&&(n+='<?xml version="1.0" encoding="UTF-8"?>'+a),n+="<root>"+a);for(const l in s){const i=s[l],t=isNaN(Number(l))?l:`row-${l}`;if(i===null){n+=`${u(e,o)}<${t}></${t}>${a}`;continue}if(Array.isArray(i)){i.forEach(r=>{n+=`${u(e,o)}<${t}>`,r===null?n+=`</${t}>${a}`:typeof r=="object"?(n+=`${a}${p(r,e,o+1)}${u(e,o)}`,n+=`</${t}>${a}`):n+=`${g(String(r))}</${t}>${a}`});continue}if(typeof i=="object"){n+=`${u(e,o)}<${t}>${a}`,n+=p(i,e,o+1),n+=`${u(e,o)}</${t}>${a}`;continue}n+=`${u(e,o)}<${t}>${g(String(i))}</${t}>${a}`}return o===0?`${n}</root>`:n},g=s=>s.replace(/&/g,"&amp;").replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/"/g,"&quot;").replace(/'/g,"&apos;"),$={indentationType:"space",addMetaTag:!1},h=[{title:"Basic JSON to XML",description:"Convert a simple JSON object into an XML format.",sampleText:`
{
  "users": [
    {
      "name": "John",
      "age": 30,
      "city": "New York"
    },
    {
      "name": "Alice",
      "age": 25,
      "city": "London"
    }
  ]
}`,sampleResult:`<root>
	<users>
		<name>John</name>
		<age>30</age>
		<city>New York</city>
	</users>
	<users>
		<name>Alice</name>
		<age>25</age>
		<city>London</city>
	</users>
</root>`,sampleOptions:{...$}}];function E({title:s}){const[e,o]=d.useState(""),[n,a]=d.useState(""),l=(i,t)=>{if(t)try{const r=M(t,i);a(r)}catch(r){a(`Error: ${r instanceof Error?r.message:"Invalid Json format"}`)}};return c.jsx(T,{title:s,input:e,setInput:o,initialValues:$,compute:l,exampleCards:h,inputComponent:c.jsx(x,{title:"Input Json",value:e,onChange:o,language:"json"}),resultComponent:c.jsx(y,{title:"Output XML",value:n,extension:"xml"}),getGroups:({values:i,updateField:t})=>[{title:"Output XML Indentation",component:c.jsxs(f,{children:[c.jsx(m,{checked:i.indentationType==="space",title:"Use Spaces for indentation",description:"Use spaces to visualize the hierarchical structure of XML.",onClick:()=>t("indentationType","space")}),c.jsx(m,{checked:i.indentationType==="tab",title:"Use Tabs for indentation",description:"Use tabs to visualize the hierarchical structure of XML.",onClick:()=>t("indentationType","tab")}),c.jsx(m,{checked:i.indentationType==="none",title:"No indentation",description:"Output XML without any indentation.",onClick:()=>t("indentationType","none")})]})},{title:"XML Meta Information",component:c.jsx(f,{children:c.jsx(j,{checked:i.addMetaTag,onChange:r=>t("addMetaTag",r),title:"Add an XML Meta Tag",description:"Add a meta tag at the beginning of the XML output."})})}]})}export{E as default};
"""

let render() = file
