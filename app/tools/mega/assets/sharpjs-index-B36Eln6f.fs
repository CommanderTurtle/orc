module ConvertedFiles.Mega.Assets.IndexB36Eln6fJs

let file = """import{a as C,r as b,j as r,B as f}from"./index-aHpeEV8y.js";import{T as j}from"./ToolTextInput-BkooUYLb.js";import{T as W}from"./ToolTextResult-CwqjGqb-.js";import{S as O}from"./SimpleRadio-bgT63ITl.js";import{T as u}from"./TextFieldWithDesc-Br8sqQWl.js";import{C as S}from"./CheckboxWithDesc-BstBhCI6.js";import{f as I}from"./number-8xlk3Zkp.js";import{T as N}from"./ToolContent-B4ORy3df.js";import"./ContentPaste-DKqpSfyH.js";import"./InputFooter-BDHup-Ls.js";import"./TextField-3OI-XynG.js";import"./ResultFooter-CLp_AWC-.js";import"./Radio-43K3h4aU.js";import"./SwitchBase-BAC9Dj1s.js";import"./FormControlLabel-zEBePngt.js";import"./Checkbox-BjITWEtX.js";function E(o,e){const i=[];for(let a=0;a<o.length;a+=e)i.push(o.slice(a,a+e));return i}function D(o,e,i,a=""){if(i){const n=o[o.length-1];if(n.length<e)for(let m=n.length;m<e;m++)n.push(a);o[o.length-1]=n}return o}function G(o,e="",i="",a=""){return o.map(n=>i+n.join(e)+a)}function v(o,e,i,a,n="",m="",c="",p,s,t,h=""){if(!e)return"";let l;switch(o){case"symbol":l=i.split(e);break;case"regex":l=i.split(new RegExp(e));break}s&&(l=l.filter(x=>x!==""));const d=E(l,a),g=D(d,a,t,h);return G(g,n,m,c).join(p)}const A={splitOperatorType:"symbol",splitSeparator:",",groupNumber:2,itemSeparator:",",leftWrap:"[",rightWrap:"]",groupSeparator:"\\n",deleteEmptyItems:!0,padNonFullGroup:!1,paddingChar:"..."},R=["symbol","regex"],z=[{title:"Group Hexagon Coordinates",description:'In this example, we group the coordinates of a regular hexagon. The input coordinates are given as a space-separated list "x1 y1 x2 y2 x3 y3 …". What we want to do is create vector point pairs such as "(x1, y1); (x2, y2); (x3, y3); …". To do that, we use the space character as the input coordinate separator, and to create vectors, we group them by pairs. We wrap the coordinates in parentheses, put a comma between the x and y group items, and a semicolon between individual groups.',sampleText:"2.5 9.33 0 5 2.5 0.66 7.5 0.66 10 5 7.5 9.33",sampleResult:"(2.5, 9.33); (0, 5); (2.5, 0.66); (7.5, 0.66); (10, 5); (7.5, 9.33)",sampleOptions:{splitOperatorType:"symbol",splitSeparator:" ",groupNumber:2,itemSeparator:", ",leftWrap:"(",rightWrap:")",groupSeparator:"; ",deleteEmptyItems:!0,padNonFullGroup:!1,paddingChar:"x"}},{title:"Chunks of Size 3",description:"This example demonstrates grouping of list items and creates 9 groups of 3 items. The input list contains all alphabet letters (26 letters, separated by a semicolon) and the output is groups of letter trigrams. As the last group is missing one letter, we enable padding and add the underscore symbol as the padding element.",sampleText:"a;b;c;d;e;f;g;h;i;j;k;l;m;n;o;p;q;r;s;t;u;v;w;x;y;z",sampleResult:`[a, b, c]
[d, e, f]
[g, h, i]
[j, k, l]
[m, n, o]
[p, q, r]
[s, t, u]
[v, w, x]
[y, z, _]`,sampleOptions:{splitOperatorType:"symbol",splitSeparator:";",groupNumber:3,itemSeparator:",",leftWrap:"[",rightWrap:"]",groupSeparator:"\\n",deleteEmptyItems:!1,padNonFullGroup:!0,paddingChar:"_"}},{title:"Convert a List to a TSV",description:'In this example, we use our list item grouper to convert a food list to tab-separated values (TSV). As spaces are chaotically used between the items of the input list, we use the item separating regular expression "\\s+" to match them. We create a TSV with three columns (three groups), separate them with a tab character, and put newlines between the groups.',sampleText:`beef	  buns
  cake	 	corn
 crab
dill  
fish
	kiwi 	kale

  lime  	meat
mint
   milk
  pear	plum
	  	pate
  pork	   	rice  
soup
  tuna   
  tart`,sampleResult:`beef	buns	cake
corn	crab	dill
fish	kiwi	kale
lime	meat	mint
milk	pear  plum
pate	pork	rice
soup	tuna	tart`,sampleOptions:{splitOperatorType:"regex",splitSeparator:"\\s+",groupNumber:3,itemSeparator:"\\t",leftWrap:"",rightWrap:"",groupSeparator:"\\n",deleteEmptyItems:!0,padNonFullGroup:!1,paddingChar:"x"}}];function Z({title:o}){const{t:e}=C("list"),[i,a]=b.useState(""),[n,m]=b.useState(""),c=(p,s)=>{const{splitOperatorType:t,splitSeparator:h,groupNumber:l,itemSeparator:d,leftWrap:g,rightWrap:k,groupSeparator:x,deleteEmptyItems:y,padNonFullGroup:T,paddingChar:w}=p;m(v(t,h,s,l,d,g,k,x,y,T,w))};return r.jsx(N,{title:o,input:i,exampleCards:z,inputComponent:r.jsx(j,{title:e("chunk.inputTitle"),value:i,onChange:a}),resultComponent:r.jsx(W,{title:e("chunk.resultTitle"),value:n}),initialValues:A,getGroups:({values:p,updateField:s})=>[{title:e("chunk.inputItemSeparator"),component:r.jsxs(f,{children:[R.map(t=>r.jsx(O,{onClick:()=>s("splitOperatorType",t),title:e(`chunk.splitOperators.${t}.title`),description:e(`chunk.splitOperators.${t}.description`),checked:p.splitOperatorType===t},t)),r.jsx(u,{description:e("chunk.splitSeparatorDescription"),value:p.splitSeparator,onOwnChange:t=>s("splitSeparator",t)})]})},{title:e("chunk.groupSizeAndSeparators"),component:r.jsxs(f,{children:[r.jsx(u,{value:p.groupNumber,description:e("chunk.groupNumberDescription"),type:"number",onOwnChange:t=>s("groupNumber",I(t,1))}),r.jsx(u,{value:p.itemSeparator,description:e("chunk.itemSeparatorDescription"),onOwnChange:t=>s("itemSeparator",t)}),r.jsx(u,{value:p.groupSeparator,description:e("chunk.groupSeparatorDescription"),onOwnChange:t=>s("groupSeparator",t)}),r.jsx(u,{value:p.leftWrap,description:e("chunk.leftWrapDescription"),onOwnChange:t=>s("leftWrap",t)}),r.jsx(u,{value:p.rightWrap,description:e("chunk.rightWrapDescription"),onOwnChange:t=>s("rightWrap",t)})]})},{title:e("chunk.emptyItemsAndPadding"),component:r.jsxs(f,{children:[r.jsx(S,{title:e("chunk.deleteEmptyItems"),description:e("chunk.deleteEmptyItemsDescription"),checked:p.deleteEmptyItems,onChange:t=>s("deleteEmptyItems",t)}),r.jsx(S,{title:e("chunk.padNonFullGroups"),description:e("chunk.padNonFullGroupsDescription"),checked:p.padNonFullGroup,onChange:t=>s("padNonFullGroup",t)}),r.jsx(u,{value:p.paddingChar,description:e("chunk.paddingCharDescription"),onOwnChange:t=>s("paddingChar",t)})]})}],compute:c,setInput:a})}export{Z as default};
"""

let render() = file
