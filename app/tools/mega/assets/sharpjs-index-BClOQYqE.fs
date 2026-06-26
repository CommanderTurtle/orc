module ConvertedFiles.Mega.Assets.IndexBClOQYqEJs

let file = """import{z as c,r as u,j as o}from"./index-aHpeEV8y.js";import{T}from"./ToolTextInput-BkooUYLb.js";import{T as g}from"./ToolTextResult-CwqjGqb-.js";import{C as d}from"./CheckboxWithDesc-BstBhCI6.js";import{T as P}from"./ToolContent-B4ORy3df.js";import"./ContentPaste-DKqpSfyH.js";import"./InputFooter-BDHup-Ls.js";import"./TextField-3OI-XynG.js";import"./ResultFooter-CLp_AWC-.js";import"./FormControlLabel-zEBePngt.js";import"./Checkbox-BjITWEtX.js";import"./SwitchBase-BAC9Dj1s.js";function h(e,a){if(!e)return"";let r,t;return t=a?c(e):c(e.slice(0,-1)),r=e.concat(t),r}function v(e,a,r){if(!e)return"";let t;const i=[];if(r){t=e.split(`
`);for(const p of t)i.push(h(p,a))}else return h(e,a);return i.join(`
`)}const m={lastChar:!0,multiLine:!1},j=[{title:"Create Simple Palindrome",description:"Creates a palindrome by repeating the text in reverse order, including the last character.",sampleText:"level",sampleResult:"levellevel",sampleOptions:{...m,lastChar:!0}},{title:"Create Palindrome Without Last Character Duplication",description:"Creates a palindrome without repeating the last character in the reverse part.",sampleText:"radar",sampleResult:"radarada",sampleOptions:{...m,lastChar:!1}},{title:"Multi-line Palindrome Creation",description:"Creates palindromes for each line independently.",sampleText:`mom
dad
wow`,sampleResult:`mommom
daddad
wowwow`,sampleOptions:{...m,lastChar:!0,multiLine:!0}}];function z({title:e,longDescription:a}){const[r,t]=u.useState(""),[i,p]=u.useState(""),C=(l,s)=>{const{lastChar:n,multiLine:f}=l;p(v(s,n,f))},x=({values:l,updateField:s})=>[{title:"Palindrome options",component:[o.jsx(d,{checked:l.lastChar,title:"Include last character",description:"Repeat the last character in the reversed part",onChange:n=>s("lastChar",n)},"lastChar"),o.jsx(d,{checked:l.multiLine,title:"Process multi-line text",description:"Create palindromes for each line independently",onChange:n=>s("multiLine",n)},"multiLine")]}];return o.jsx(P,{title:e,initialValues:m,getGroups:x,compute:C,input:r,setInput:t,inputComponent:o.jsx(T,{title:"Input text",value:r,onChange:t}),resultComponent:o.jsx(g,{title:"Palindrome text",value:i}),toolInfo:{title:"What Is a String Palindrome Creator?",description:a},exampleCards:j})}export{z as default};
"""

let render() = file
