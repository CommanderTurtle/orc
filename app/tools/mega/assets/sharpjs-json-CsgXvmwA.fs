module ConvertedFiles.Mega.Assets.JsonCsgXvmwAJs

let file = """function o(e){let t;if(typeof e=="string")try{const r=JSON.parse(e);t=Array.isArray(r)?r:[r]}catch{return[]}else t=e;return Array.from(t.reduce((r,a)=>(Object.keys(a).forEach(s=>r.add(s)),r),new Set))}export{o as g};
"""

let render() = file
