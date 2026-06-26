module ConvertedFiles.Mega.Assets.IndexCQgyOMpsJs

let file = """import{r,j as t,B as h}from"./index-aHpeEV8y.js";import{T as d}from"./ToolContent-B4ORy3df.js";import{T as g}from"./ToolCodeInput-CpT4hCek.js";import{T as O}from"./ToolTextResult-CwqjGqb-.js";import{C as x}from"./CheckboxWithDesc-BstBhCI6.js";import"./TextField-3OI-XynG.js";import"./ContentPaste-DKqpSfyH.js";import"./InputFooter-BDHup-Ls.js";import"./ResultFooter-CLp_AWC-.js";import"./FormControlLabel-zEBePngt.js";import"./Checkbox-BjITWEtX.js";import"./SwitchBase-BAC9Dj1s.js";const S=(a,s)=>{const e=JSON.stringify(a);return s?e:e.slice(1,-1)},b={wrapInQuotesFlag:!1},f=[{title:"Escape a Simple JSON Object",description:`In this example, we escape all quotes (") around the keys and values in a simple JSON object. This ensures that the JSON data is interpreted correctly if it's used in another JSON object or assigned to a variable as a string.`,sampleText:'{"country": "Spain", "capital": "Madrid"}',sampleResult:'{{\\"country\\": \\"Spain\\", \\"capital\\": \\"Madrid\\"}',sampleOptions:{wrapInQuotesFlag:!1}},{title:"Escape a Complex JSON Object",description:`In this example, we escape a more complex JSON object with nested elements containing data about the Margherita pizza recipe. We escape all quotes within the object as well as convert all line breaks into special "
" characters. Additionally, we wrap the entire output in double quotes by enabling the "Wrap Output in Quotes" option.`,sampleText:`{
  "name": "Pizza Margherita",
  "ingredients": [
    "tomato sauce",
    "mozzarella cheese",
    "fresh basil"
  ],
  "price": 12.50,
  "vegetarian": true
}`,sampleResult:'"{\\n  \\"name\\": \\"Pizza Margherita\\",\\n  \\"ingredients\\": [\\n\\"tomato sauce\\",\\n    \\"mozzarella cheese\\",\\n    \\"fresh basil\\"\\n  ],\\n  \\"price\\": 12.50,\\n  \\"vegetarian\\": true\\n}"',sampleOptions:{wrapInQuotesFlag:!0}},{title:"Escape a JSON Array of Numbers",description:"This example showcases that escaping isn't necessary for JSON arrays containing only numbers. Since numbers themselves don't hold special meaning in JSON, the tool doesn't modify the input and the output remains the same as the original JSON array.",sampleText:"[1, 2, 3]",sampleResult:"[1, 2, 3]",sampleOptions:{wrapInQuotesFlag:!1}}];function F({title:a,longDescription:s}){const[e,i]=r.useState(""),[p,l]=r.useState(""),u=(n,o)=>{l(S(o,n.wrapInQuotesFlag))},c=({values:n,updateField:o})=>[{title:"Quote Output",component:t.jsx(h,{children:t.jsx(x,{onChange:m=>o("wrapInQuotesFlag",m),checked:n.wrapInQuotesFlag,title:"Wrap Output In Quotes",description:"Add double quotes around the output JSON data."})})}];return t.jsx(d,{title:a,inputComponent:t.jsx(g,{title:"Input JSON",value:e,onChange:i,language:"json"}),resultComponent:t.jsx(O,{title:"Escaped JSON",value:p,keepSpecialCharacters:!0,extension:"json"}),initialValues:b,getGroups:c,toolInfo:{title:"What is a JSON Escaper?",description:s},exampleCards:f,input:e,setInput:i,compute:u})}export{F as default};
"""

let render() = file
