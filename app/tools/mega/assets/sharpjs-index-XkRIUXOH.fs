module ConvertedFiles.Mega.Assets.IndexXkRIUXOHJs

let file = """import{a as u,r,j as a,B as h,aH as f}from"./index-aHpeEV8y.js";import{T as y}from"./ToolCodeInput-CpT4hCek.js";import{T as g}from"./ToolTextResult-CwqjGqb-.js";import{b as T}from"./service-by4TTpxy.js";import{R as x}from"./RadioWithTextField-Y4FaF9ER.js";import{S as b}from"./SimpleRadio-bgT63ITl.js";import{T as j}from"./ToolContent-B4ORy3df.js";import"./ContentPaste-DKqpSfyH.js";import"./InputFooter-BDHup-Ls.js";import"./ResultFooter-CLp_AWC-.js";import"./TextField-3OI-XynG.js";import"./TextFieldWithDesc-Br8sqQWl.js";import"./Radio-43K3h4aU.js";import"./SwitchBase-BAC9Dj1s.js";const w={indentationType:"space",spacesCount:2},k=[{title:"Beautify an Ugly JSON Array",description:"In this example, we prettify an ugly JSON array. The input data is a one-dimensional array of numbers [1,2,3] but they are all over the place. This array gets cleaned up and transformed into a more readable format where each element is on a new line with an appropriate indentation using four spaces.",sampleText:`[
 1,
2,3
]`,sampleResult:`[
    1,
    2,
    3
]`,sampleOptions:{indentationType:"space",spacesCount:4}},{title:"Prettify a Complex JSON Object",description:"In this example, we prettify a complex JSON data structure consisting of arrays and objects. The input data is a minified JSON object with multiple data structure depth levels. To make it neat and readable, we add two spaces for indentation to each depth level, making the JSON structure clear and easy to understand.",sampleText:'{"names":["jack","john","alex"],"hobbies":{"jack":["programming","rock climbing"],"john":["running","racing"],"alex":["dancing","fencing"]}}',sampleResult:`{
  "names": [
    "jack",
    "john",
    "alex"
  ],
  "hobbies": {
    "jack": [
      "programming",
      "rock climbing"
    ],
    "john": [
      "running",
      "racing"
    ],
    "alex": [
      "dancing",
      "fencing"
    ]
  }
}`,sampleOptions:{indentationType:"space",spacesCount:2}},{title:"Beautify a JSON with Excessive Whitespace",description:"In this example, we show how the JSON prettify tool can handle code with excessive whitespace. The input file has many leading and trailing spaces as well as spaces within the objects. The excessive whitespace makes the file bulky and hard to read and leads to a bad impression of the programmer who wrote it. The program removes all these unnecessary spaces and creates a proper data hierarchy that's easy to work with by adding indentation via tabs.",sampleText:`
{
     "name":  "The Name of the Wind",
 "author"  : "Patrick Rothfuss",
     "genre"  :  "Fantasy",
     "published"   : 2007,
   "rating"    :  {
 "average"   :   4.6,
 "goodreads"         :   4.58,
      "amazon"   :  4.4
 },
      "is_fiction" : true
    }


`,sampleResult:`{
	"name": "The Name of the Wind",
	"author": "Patrick Rothfuss",
	"genre": "Fantasy",
	"published": 2007,
	"rating": {
		"average": 4.6,
		"goodreads": 4.58,
		"amazon": 4.4
	},
	"is_fiction": true
}`,sampleOptions:{indentationType:"tab",spacesCount:0}}];function F({title:p}){const{t:e}=u("json"),[s,o]=r.useState(""),[l,c]=r.useState(""),m=(n,t)=>{const{indentationType:i,spacesCount:d}=n;t&&c(T(t,i,d))};return a.jsx(j,{title:p,input:s,inputComponent:a.jsx(y,{title:e("prettify.inputTitle"),value:s,onChange:o,language:"json"}),resultComponent:a.jsx(g,{title:e("prettify.resultTitle"),value:l,extension:"json"}),initialValues:w,getGroups:({values:n,updateField:t})=>[{title:e("prettify.indentation"),component:a.jsxs(h,{children:[a.jsx(x,{checked:n.indentationType==="space",title:e("prettify.useSpaces"),fieldName:"indentationType",description:e("prettify.useSpacesDescription"),value:n.spacesCount.toString(),onRadioClick:()=>t("indentationType","space"),onTextChange:i=>f(i,"spacesCount",t)}),a.jsx(b,{onClick:()=>t("indentationType","tab"),checked:n.indentationType==="tab",description:e("prettify.useTabsDescription"),title:e("prettify.useTabs")})]})}],compute:m,setInput:o,exampleCards:k,toolInfo:{title:e("prettify.toolInfo.title"),description:e("prettify.toolInfo.description")}})}export{F as default};
"""

let render() = file
