module Generated.Views

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width,initial-scale=1" ]
            meta [ attr "name" "description"; attr "content" "Convert HTML and office documents to clean Markdown entirely in your browser." ]
            title [] [
                str "Webclip — local Markdown conversion"
            ]
            script [ _src "./vendor/turndown.js" ] [ rawText ("""""") ]
            script [ _src "./vendor/turndown-plugin-gfm.js" ] [ rawText ("""""") ]
            style [] [
                    rawText (""":root {
      color-scheme: light dark;
      --heat:#fa5d19; --heat-soft:rgba(250,93,25,.10); --bg:#f6f6f4; --surface:#fff;
      --raised:#fafaf9; --text:#252525; --muted:#737373; --line:#e6e6e3; --ok:#16805b;
      --danger:#d83b2d; --shadow:0 18px 60px rgba(20,20,18,.08);
      --sans:Inter,ui-sans-serif,system-ui,-apple-system,"Segoe UI",sans-serif;
      --mono:"SFMono-Regular",Consolas,"Liberation Mono",monospace;
    }
    @media(prefers-color-scheme:dark){:root{--bg:#090909;--surface:#151515;--raised:#1b1b1b;--text:#f5f5f3;--muted:#a3a3a0;--line:#30302d;--ok:#55d7a4;--danger:#ff7468;--shadow:0 18px 70px rgba(0,0,0,.34)}}
    *{box-sizing:border-box} [hidden]{display:none!important} body{margin:0;background:var(--bg);color:var(--text);font-family:var(--sans);font-size:15px;line-height:1.55;-webkit-font-smoothing:antialiased}
    button,textarea,input{font:inherit} button{color:inherit} a{color:inherit} :focus-visible{outline:2px solid var(--heat);outline-offset:2px}
    .shell{width:min(1280px,calc(100% - 32px));margin:0 auto;padding:22px 0 40px}
    .topbar{display:flex;align-items:center;justify-content:space-between;gap:18px;padding:4px 2px 22px}
    .brand{display:flex;align-items:center;gap:10px;font-weight:700;letter-spacing:-.02em}.brand-mark{display:grid;place-items:center;width:32px;height:32px;border-radius:9px;background:var(--heat);color:#fff;box-shadow:0 8px 24px rgba(250,93,25,.28)}
    .toplinks{display:flex;gap:16px;color:var(--muted);font-size:13px}.toplinks a{text-decoration:none}.toplinks a:hover{color:var(--heat)}
    .hero{display:grid;grid-template-columns:minmax(0,1fr) auto;align-items:end;gap:28px;padding:42px 0 28px}
    .hero h1{margin:0;font-size:clamp(38px,6vw,70px);line-height:1;letter-spacing:-.055em;font-weight:650;max-width:850px}.hero h1 span{color:var(--heat)}
    .lede{max-width:720px;margin:20px 0 0;color:var(--muted);font-size:17px}.privacy{display:flex;align-items:center;gap:8px;white-space:nowrap;color:var(--ok);font-size:13px;font-weight:650}.privacy i{width:8px;height:8px;border-radius:50%;background:currentColor;box-shadow:0 0 0 5px color-mix(in srgb,currentColor 14%,transparent)}
    .engine-row{display:flex;flex-wrap:wrap;gap:8px;margin:0 0 24px}.engine{display:inline-flex;align-items:center;gap:7px;padding:7px 11px;border:1px solid var(--line);border-radius:999px;background:var(--surface);color:var(--muted);font-size:12px}.engine strong{color:var(--text);font-weight:650}.engine em{width:6px;height:6px;border-radius:50%;background:var(--ok)}
    .workspace{display:grid;grid-template-columns:minmax(0,1fr) minmax(0,1fr);gap:16px;align-items:stretch}
    .panel{min-width:0;background:var(--surface);border:1px solid var(--line);border-radius:16px;box-shadow:var(--shadow);overflow:hidden;display:flex;flex-direction:column;min-height:610px}
    .panel-head{display:flex;align-items:center;justify-content:space-between;gap:12px;padding:15px 17px;border-bottom:1px solid var(--line);background:var(--raised)}
    .panel-title{font-size:12px;text-transform:uppercase;letter-spacing:.11em;color:var(--muted);font-weight:700}.panel-meta{font-family:var(--mono);font-size:11px;color:var(--muted)}
    .input-body{display:flex;flex:1;flex-direction:column;min-height:0}.source{width:100%;flex:1;min-height:330px;resize:none;border:0;background:transparent;color:var(--text);padding:20px;font-family:var(--mono);font-size:13px;line-height:1.65;outline:0}.source::placeholder{color:color-mix(in srgb,var(--muted) 72%,transparent)}
    .divider{display:flex;align-items:center;gap:12px;color:var(--muted);font-size:11px;text-transform:uppercase;letter-spacing:.09em;padding:0 20px}.divider:before,.divider:after{content:"";height:1px;background:var(--line);flex:1}
    .drop{margin:15px 20px 18px;border:1px dashed var(--line);border-radius:12px;background:var(--raised);padding:22px 18px;text-align:center;cursor:pointer;transition:.16s ease}.drop:hover,.drop.over{border-color:var(--heat);background:var(--heat-soft)}.drop strong{display:block;font-size:14px}.drop span{display:block;margin-top:4px;color:var(--muted);font-size:12px}.drop .format-line{font-family:var(--mono);font-size:10px;line-height:1.6;margin-top:9px}
    .file-chip{display:none;margin:-5px 20px 15px;padding:9px 11px;border-radius:9px;background:var(--heat-soft);color:var(--heat);font-family:var(--mono);font-size:11px;overflow-wrap:anywhere}.file-chip.show{display:block}
    .actions{display:flex;align-items:center;flex-wrap:wrap;gap:9px;padding:14px 17px;border-top:1px solid var(--line);background:var(--raised)}
    .btn{border:1px solid var(--line);background:var(--surface);border-radius:9px;padding:8px 13px;font-size:12px;font-weight:650;cursor:pointer;transition:.14s ease}.btn:hover{border-color:var(--heat);color:var(--heat)}.btn.primary{background:var(--heat);border-color:var(--heat);color:#fff}.btn.primary:hover{filter:brightness(1.06);color:#fff}.btn:disabled{opacity:.45;cursor:not-allowed}.spacer{flex:1}.toggle{display:flex;align-items:center;gap:7px;color:var(--muted);font-size:11px;cursor:pointer}.toggle input{accent-color:var(--heat)}
    .tabs{display:flex;border-bottom:1px solid var(--line);background:var(--raised)}.tab{border:0;border-right:1px solid var(--line);background:transparent;padding:12px 17px;color:var(--muted);font-size:12px;font-weight:650;cursor:pointer}.tab.active{color:var(--heat);background:var(--surface)}
    .output-wrap{position:relative;flex:1;min-height:0}.output{height:100%;max-height:520px;overflow:auto;padding:20px}.raw{margin:0;white-space:pre-wrap;overflow-wrap:anywhere;font-family:var(--mono);font-size:12px;line-height:1.65}.empty{display:grid;place-items:center;height:100%;min-height:390px;text-align:center;color:var(--muted);padding:30px}.empty-icon{display:grid;place-items:center;width:54px;height:54px;border:1px solid var(--line);border-radius:14px;margin:0 auto 12px;color:var(--heat);font-size:25px}
    .preview{font-size:14px}.preview h1,.preview h2,.preview h3{line-height:1.25;letter-spacing:-.02em}.preview h1{font-size:28px}.preview h2{font-size:21px;border-bottom:1px solid var(--line);padding-bottom:7px}.preview h3{font-size:17px;color:var(--heat)}.preview a{color:var(--heat)}.preview code{font-family:var(--mono);font-size:.9em;background:var(--raised);border:1px solid var(--line);border-radius:5px;padding:2px 5px}.preview pre{overflow:auto;padding:14px;border:1px solid var(--line);border-radius:10px;background:var(--raised)}.preview pre code{border:0;padding:0}.preview blockquote{margin-left:0;border-left:3px solid var(--heat);padding:8px 14px;color:var(--muted);background:var(--heat-soft)}.preview table{width:100%;border-collapse:collapse;font-size:12px}.preview th,.preview td{border:1px solid var(--line);padding:7px 9px;text-align:left}.preview th{background:var(--raised)}.preview img{max-width:100%}
    .status{display:flex;flex-wrap:wrap;align-items:center;gap:10px 18px;margin-top:15px;padding:12px 16px;border:1px solid var(--line);border-radius:12px;background:var(--surface);color:var(--muted);font-size:11px}.status strong{color:var(--text);font-weight:650}.status .state{color:var(--ok)}.status .state.error{color:var(--danger)}
    .formats{margin-top:28px;border-top:1px solid var(--line);padding-top:25px}.formats h2{font-size:15px;margin:0 0 12px}.format-grid{display:flex;flex-wrap:wrap;gap:7px}.format-grid span{padding:5px 9px;border:1px solid var(--line);border-radius:7px;background:var(--surface);font-family:var(--mono);font-size:10px;color:var(--muted)}
    .toast{position:fixed;right:22px;bottom:22px;padding:10px 14px;border-radius:9px;background:var(--text);color:var(--bg);font-size:12px;font-weight:650;box-shadow:var(--shadow);transform:translateY(20px);opacity:0;pointer-events:none;transition:.2s}.toast.show{transform:none;opacity:1}
    .busy:after{content:"";display:inline-block;width:10px;height:10px;margin-left:8px;border:2px solid currentColor;border-right-color:transparent;border-radius:50%;animation:spin .7s linear infinite}@keyframes spin{to{transform:rotate(360deg)}}
    @media(max-width:850px){.hero{grid-template-columns:1fr}.privacy{white-space:normal}.workspace{grid-template-columns:1fr}.panel{min-height:560px}.output{max-height:none}.toplinks .secondary{display:none}}
    @media(max-width:520px){.shell{width:min(100% - 20px,1280px);padding-top:12px}.hero{padding-top:28px}.panel-head,.actions{padding-left:13px;padding-right:13px}.drop{margin-left:13px;margin-right:13px}.source{padding:16px}.hero h1{font-size:42px}}
    @media(prefers-reduced-motion:reduce){*{scroll-behavior:auto!important;transition:none!important;animation:none!important}}""")
            ]
        ]
        body [] [
            main [ _class "shell" ] [
                header [ _class "topbar" ] [
                    div [ _class "brand" ] [
                        span [ _class "brand-mark" ] [
                            str "↳"
                        ]
                        span [] [
                            str "Webclip"
                        ]
                    ]
                    nav [ _class "toplinks" ] [
                        a [ _href "https://github.com/firecrawl/anydoc" ] [
                            str "AnyDoc"
                        ]
                        a [ _class "secondary"; _href "https://github.com/firecrawl/firecrawl" ] [
                            str "Firecrawl"
                        ]
                    ]
                ]
                section [ _class "hero" ] [
                    div [] [
                        h1 [] [
                            str "Anything useful in."
                            br []
                            span [] [
                                str "Clean Markdown out."
                            ]
                        ]
                        p [ _class "lede" ] [
                            str "Paste HTML or rich text, or drop an office document, spreadsheet, presentation, EPUB, CSV, RTF, or text PDF. One private interface; no server round-trip."
                        ]
                    ]
                    div [ _class "privacy" ] [
                        i [] []
                        str "Conversion stays on this device"
                    ]
                ]
                div [ _class "engine-row" ] [
                    span [ _class "engine" ] [
                        em [] []
                        strong [] [
                            str "Firecrawl"
                        ]
                        str "HTML → GFM"
                    ]
                    span [ _class "engine"; _id "anydoc-engine" ] [
                        em [] []
                        strong [] [
                            str "AnyDoc"
                        ]
                        str "Rust/WASM loading"
                    ]
                    span [ _class "engine" ] [
                        strong [] [
                            str "Static"
                        ]
                        str "no account · no API"
                    ]
                ]
                section [ _class "workspace" ] [
                    article [ _class "panel"; _id "input-panel" ] [
                        div [ _class "panel-head" ] [
                            span [ _class "panel-title" ] [
                                str "Source"
                            ]
                            span [ _class "panel-meta"; _id "input-meta" ] [
                                str "paste or drop"
                            ]
                        ]
                        div [ _class "input-body" ] [
                            tag "textarea" [ _class "source"; _id "source"; attr "spellcheck" "false"; attr "placeholder" "Paste HTML, rich text, Markdown, or plain text here…\n\nRich clipboard HTML is captured automatically." ] []
                            div [ _class "divider" ] [
                                str "or"
                            ]
                            button [ _class "drop"; _id "drop"; _type "button" ] [
                                strong [] [
                                    str "Drop a document or browse"
                                ]
                                span [] [
                                    str "Binary documents are read directly by AnyDoc WebAssembly."
                                ]
                                span [ _class "format-line" ] [
                                    str "DOC · DOCX · PPT · PPTX · XLS · XLSX · ODT · ODS · ODP · RTF · EPUB · CSV · PDF · HTML"
                                ]
                            ]
                            input [ _id "file"; _type "file"; attr "hidden" ""; attr "accept" ".html,.htm,.txt,.md,.markdown,.json,.doc,.docx,.docm,.odt,.rtf,.epub,.pdf,.ppt,.pps,.pot,.pptx,.pptm,.ppsx,.ppsm,.odp,.xls,.xlsx,.xlsm,.xlsb,.ods,.csv" ]
                            div [ _class "file-chip"; _id "file-chip" ] []
                        ]
                        div [ _class "actions" ] [
                            button [ _class "btn primary"; _id "convert"; _type "button" ] [
                                str "Convert"
                            ]
                            button [ _class "btn"; _id "clear"; _type "button" ] [
                                str "Clear"
                            ]
                            span [ _class "spacer" ] []
                            label [ _class "toggle" ] [
                                input [ _id "metadata"; _type "checkbox"; attr "checked" "" ]
                                str "add clip metadata"
                            ]
                        ]
                    ]
                    article [ _class "panel" ] [
                        div [ _class "panel-head" ] [
                            span [ _class "panel-title" ] [
                                str "Markdown"
                            ]
                            span [ _class "panel-meta"; _id "output-meta" ] [
                                str "waiting"
                            ]
                        ]
                        div [ _class "tabs" ] [
                            button [ _class "tab active"; attr "data-tab" "preview"; _type "button" ] [
                                str "Preview"
                            ]
                            button [ _class "tab"; attr "data-tab" "raw"; _type "button" ] [
                                str "Raw"
                            ]
                        ]
                        div [ _class "output-wrap" ] [
                            div [ _class "empty"; _id "empty" ] [
                                div [] [
                                    span [ _class "empty-icon" ] [
                                        str "#"
                                    ]
                                    strong [] [
                                        str "Converted Markdown appears here."
                                    ]
                                    br []
                                    str "Use Ctrl/⌘ + Enter to convert pasted content."
                                ]
                            ]
                            div [ _class "output preview"; _id "preview"; attr "hidden" "" ] []
                            pre [ _class "output raw"; _id "raw"; attr "hidden" "" ] []
                        ]
                        div [ _class "actions" ] [
                            button [ _class "btn"; _id "copy"; _type "button"; attr "disabled" "" ] [
                                str "Copy"
                            ]
                            button [ _class "btn primary"; _id "download"; _type "button"; attr "disabled" "" ] [
                                str "Download .md"
                            ]
                        ]
                    ]
                ]
                div [ _class "status"; attr "aria-live" "polite" ] [
                    span [] [
                        str "Status"
                        strong [ _class "state"; _id "state" ] [
                            str "Ready"
                        ]
                    ]
                    span [] [
                        str "Engine"
                        strong [ _id "engine" ] [
                            str "—"
                        ]
                    ]
                    span [] [
                        str "Input"
                        strong [ _id "input-stats" ] [
                            str "0 B"
                        ]
                    ]
                    span [] [
                        str "Output"
                        strong [ _id "output-stats" ] [
                            str "0 chars"
                        ]
                    ]
                    span [] [
                        str "Time"
                        strong [ _id "time" ] [
                            str "—"
                        ]
                    ]
                ]
                section [ _class "formats" ] [
                    h2 [] [
                        str "Local conversion coverage"
                    ]
                    div [ _class "format-grid" ] [
                        span [] [
                            str "HTML"
                        ]
                        span [] [
                            str "RICH TEXT"
                        ]
                        span [] [
                            str "MARKDOWN"
                        ]
                        span [] [
                            str "DOC/X/M"
                        ]
                        span [] [
                            str "PPT/X/M"
                        ]
                        span [] [
                            str "XLS/X/M/B"
                        ]
                        span [] [
                            str "ODT/S/P"
                        ]
                        span [] [
                            str "RTF"
                        ]
                        span [] [
                            str "EPUB"
                        ]
                        span [] [
                            str "CSV"
                        ]
                        span [] [
                            str "TEXT PDF"
                        ]
                    ]
                ]
            ]
            div [ _class "toast"; _id "toast" ] []
            script [] [
                    rawText ("""(() => {
    'use strict';
    const $ = id => document.getElementById(id);
    const state = { markdown:'', file:null, baseName:'web-clip', title:'Web Clip', url:'', busy:false };
    const textExtensions = new Set(['html','htm','txt','md','markdown','json']);

    const escapeHtml = value => { const node=document.createElement('div'); node.textContent=value; return node.innerHTML; };
    const bytesLabel = bytes => bytes < 1024 ? `${bytes} B` : bytes < 1048576 ? `${(bytes/1024).toFixed(1)} KB` : `${(bytes/1048576).toFixed(1)} MB`;
    const dateStamp = () => new Date().toISOString().replace(/:/g,'-').replace(/\.\d{3}Z$/,'Z');
    const safeBase = name => (name || 'web-clip').replace(/\.[^.]+$/,'').replace(/[\\/:*?"<>|]+/g,'-') || 'web-clip';
    const extensionOf = name => (name.split('.').pop() || '').toLowerCase();

    function toast(message){ const el=$('toast'); el.textContent=message; el.classList.add('show'); clearTimeout(toast.timer); toast.timer=setTimeout(()=>el.classList.remove('show'),1800); }
    function setState(message,error=false){ $('state').textContent=message; $('state').classList.toggle('error',error); }
    function setBusy(on,label='Converting'){ state.busy=on; $('convert').disabled=on; $('convert').classList.toggle('busy',on); $('convert').textContent=on?label:'Convert'; }
    function updateInputStats(bytes){ $('input-stats').textContent=bytesLabel(bytes); }

    function firecrawlConverter(){
      if(!window.TurndownService || !window.turndownPluginGfm) throw new Error('The Firecrawl HTML transformer did not load.');
      const service = new window.TurndownService();
      service.addRule('inlineLink', {
        filter(node,options){ return options.linkStyle === 'inlined' && node.nodeName === 'A' && node.getAttribute('href'); },
        replacement(content,node){ const href=node.getAttribute('href').trim(); const title=node.title?` "${node.title}"`:''; return `[${content.trim()}](${href}${title})\n`; }
      });
      service.use(window.turndownPluginGfm.gfm);
      return service;
    }

    function detectText(value){
      const text=value.trim();
      if(!text) return 'empty';
      if(/^<!doctype|^<html|<\/?(?:article|main|section|div|p|h[1-6]|table|ul|ol|blockquote)\b/i.test(text)) return 'HTML';
      if(/^---\s*$[\s\S]*?^---\s*$/m.test(text) || /^#{1,6}\s/m.test(text) || /\[[^\]]+\]\([^)]+\)/.test(text)) return 'Markdown';
      return 'Plain text';
    }

    function extractHtmlMeta(html){
      const doc=new DOMParser().parseFromString(html,'text/html');
      return { title:(doc.querySelector('meta[property="og:title"]')?.content || doc.title || doc.querySelector('h1')?.textContent || 'Web Clip').trim(), url:(doc.querySelector('meta[property="og:url"]')?.content || doc.querySelector('link[rel="canonical"]')?.href || '').trim() };
    }

    function frontmatter(title,url,source){
      const lines=['---',`title: ${JSON.stringify(title || 'Web Clip')}`];
      if(url) lines.push(`url: ${JSON.stringify(url)}`);
      lines.push(`date: ${new Date().toISOString()}`,`source: ${JSON.stringify(source)}`,'---');
      return lines.join('\n');
    }

    function convertText(){
      const input=$('source').value;
      if(!input.trim()){ setState('Add some content first',true); return; }
      const started=performance.now(); const kind=detectText(input); let markdown=''; let meta={title:'Web Clip',url:''};
      if(kind==='HTML'){ meta=extractHtmlMeta(input); markdown=firecrawlConverter().turndown(input); }
      else markdown=input.trim();
      state.title=meta.title; state.url=meta.url; state.baseName=safeBase(meta.title);
      if($('metadata').checked && !/^---\s*$/m.test(markdown.slice(0,8))) markdown=`${frontmatter(meta.title,meta.url,kind==='HTML'?'Firecrawl HTML converter':'Webclip')}\n\n${markdown}`;
      present(markdown,kind==='HTML'?'Firecrawl GFM':kind,performance.now()-started,input.length);
    }

    function present(markdown,engine,elapsed,inputBytes){
      state.markdown=markdown; $('raw').textContent=markdown; $('preview').innerHTML=render(markdown); $('empty').hidden=true;
      const rawActive=document.querySelector('.tab.active')?.dataset.tab==='raw'; $('raw').hidden=!rawActive; $('preview').hidden=rawActive;
      $('copy').disabled=false; $('download').disabled=false; $('engine').textContent=engine; $('output-meta').textContent=`${markdown.length.toLocaleString()} chars`;
      $('output-stats').textContent=`${markdown.length.toLocaleString()} chars`; $('time').textContent=`${Math.max(1,Math.round(elapsed))} ms`; updateInputStats(inputBytes); setState('Done'); setBusy(false);
    }

    function render(markdown){
      let html=escapeHtml(markdown).replace(/^---\n([\s\S]*?)\n---\n?/m,(_,m)=>`<pre><code>${m}</code></pre>`);
      const blocks=[]; html=html.replace(/```([^\n]*)\n([\s\S]*?)```/g,(_,lang,code)=>{ const id=blocks.push(`<pre><code data-language="${lang}">${code}</code></pre>`)-1; return `@@BLOCK${id}@@`; });
      html=html.replace(/^###### (.+)$/gm,'<h6>$1</h6>').replace(/^##### (.+)$/gm,'<h5>$1</h5>').replace(/^#### (.+)$/gm,'<h4>$1</h4>').replace(/^### (.+)$/gm,'<h3>$1</h3>').replace(/^## (.+)$/gm,'<h2>$1</h2>').replace(/^# (.+)$/gm,'<h1>$1</h1>');
      html=html.replace(/!\[([^\]]*)\]\(([^)\s]+)(?:\s+&quot;([^&]*)&quot;)?\)/g,'<img src="$2" alt="$1" title="$3">').replace(/\[([^\]]+)\]\(([^)\s]+)(?:\s+&quot;([^&]*)&quot;)?\)/g,'<a href="$2" title="$3" target="_blank" rel="noreferrer">$1</a>');
      html=html.replace(/\*\*\*(.+?)\*\*\*/g,'<strong><em>$1</em></strong>').replace(/\*\*(.+?)\*\*/g,'<strong>$1</strong>').replace(/~~(.+?)~~/g,'<del>$1</del>').replace(/`([^`]+)`/g,'<code>$1</code>');
      html=html.replace(/^&gt;\s?(.+)$/gm,'<blockquote>$1</blockquote>').replace(/^---+$/gm,'<hr>');
      html=html.replace(/^(\|[^\n]+\|)\n(\|[-:|\s]+\|)\n((?:\|[^\n]+\|\n?)+)/gm,(_,head,_sep,body)=>{ const cells=row=>row.split('|').slice(1,-1).map(c=>c.trim()); return `<table><thead><tr>${cells(head).map(c=>`<th>${c}</th>`).join('')}</tr></thead><tbody>${body.trim().split('\n').map(row=>`<tr>${cells(row).map(c=>`<td>${c}</td>`).join('')}</tr>`).join('')}</tbody></table>`; });
      html=html.split(/\n{2,}/).map(part=>{ const p=part.trim(); if(!p)return''; if(/^<(?:h\d|pre|table|blockquote|hr)/.test(p)||/^@@BLOCK\d+@@$/.test(p))return p; if(/^(?:[-*+] |\d+\. )/m.test(p)){ const items=p.split('\n').map(line=>line.replace(/^(?:[-*+] |\d+\. )/,'')).map(line=>`<li>${line}</li>`).join(''); return `<ul>${items}</ul>`; } return `<p>${p.replace(/\n/g,'<br>')}</p>`; }).join('\n');
      blocks.forEach((block,index)=>{ html=html.replace(`@@BLOCK${index}@@`,block); }); return html;
    }

    function waitForAnyDoc(){
      if(window.WebclipAnyDoc?.ready) return Promise.resolve(window.WebclipAnyDoc);
      if(window.WebclipAnyDoc?.error) return Promise.reject(window.WebclipAnyDoc.error);
      return new Promise((resolve,reject)=>{ const timer=setTimeout(()=>reject(new Error('AnyDoc WASM did not finish loading.')),30000); const ready=()=>{clearTimeout(timer);resolve(window.WebclipAnyDoc)}; const failed=e=>{clearTimeout(timer);reject(e.detail || new Error('AnyDoc WASM failed to load.'))}; window.addEventListener('webclip:anydoc-ready',ready,{once:true}); window.addEventListener('webclip:anydoc-error',failed,{once:true}); });
    }

    async function convertFile(file){
      state.file=file; state.baseName=safeBase(file.name); state.title=state.baseName; $('file-chip').textContent=`${file.name} · ${bytesLabel(file.size)}`; $('file-chip').classList.add('show'); $('input-meta').textContent=file.name; updateInputStats(file.size); setBusy(true,'Reading'); setState('Reading file');
      try{
        const ext=extensionOf(file.name);
        if(textExtensions.has(ext)){
          const text=await file.text(); $('source').value=text; if(ext==='html'||ext==='htm') convertText(); else { let output=text.trim(); if($('metadata').checked&&!/^---\s*$/m.test(output.slice(0,8))) output=`${frontmatter(state.baseName,'','Webclip')}\n\n${output}`; present(output,ext==='md'||ext==='markdown'?'Markdown':'Plain text',1,file.size); }
          return;
        }
        const api=await waitForAnyDoc(); const bytes=new Uint8Array(await file.arrayBuffer()); const format=api.formatFromBytes(bytes) || api.formatFromPath(file.name); const started=performance.now(); let markdown=api.toMarkdownBytes(bytes,format);
        if($('metadata').checked) markdown=`${frontmatter(state.baseName,'',`AnyDoc ${format || 'document'}`)}\n\n${markdown}`;
        present(markdown,`AnyDoc ${String(format || ext).toUpperCase()}`,performance.now()-started,file.size);
      }catch(error){ setBusy(false); setState(error?.message || String(error),true); $('engine').textContent='Conversion failed'; $('time').textContent='—'; }
    }

    function clearAll(){ state.markdown='';state.file=null;state.baseName='web-clip';$('source').value='';$('file').value='';$('file-chip').classList.remove('show');$('file-chip').textContent='';$('input-meta').textContent='paste or drop';$('raw').textContent='';$('preview').innerHTML='';$('raw').hidden=true;$('preview').hidden=true;$('empty').hidden=false;$('copy').disabled=true;$('download').disabled=true;$('engine').textContent='—';$('output-meta').textContent='waiting';$('input-stats').textContent='0 B';$('output-stats').textContent='0 chars';$('time').textContent='—';setState('Ready');setBusy(false); }
    function download(){ if(!state.markdown)return; const url=URL.createObjectURL(new Blob([state.markdown],{type:'text/markdown;charset=utf-8'})); const link=Object.assign(document.createElement('a'),{href:url,download:`${state.baseName || 'web-clip'}.md`}); link.click(); setTimeout(()=>URL.revokeObjectURL(url),0); toast('Markdown downloaded'); }

    $('convert').addEventListener('click',()=>{setBusy(true);try{convertText()}catch(error){setBusy(false);setState(error.message,true)}}); $('clear').addEventListener('click',clearAll);
    $('copy').addEventListener('click',async()=>{if(!state.markdown)return;await navigator.clipboard.writeText(state.markdown);toast('Markdown copied')}); $('download').addEventListener('click',download);
    document.querySelectorAll('.tab').forEach(tab=>tab.addEventListener('click',()=>{document.querySelectorAll('.tab').forEach(t=>t.classList.toggle('active',t===tab));const raw=tab.dataset.tab==='raw';$('raw').hidden=!raw;$('preview').hidden=raw||!state.markdown;$('empty').hidden=!!state.markdown}));
    const file=$('file'),drop=$('drop'); drop.addEventListener('click',()=>file.click()); file.addEventListener('change',()=>file.files[0]&&convertFile(file.files[0]));
    ['dragenter','dragover','dragleave','drop'].forEach(name=>$('input-panel').addEventListener(name,event=>{event.preventDefault();event.stopPropagation()})); $('input-panel').addEventListener('dragover',()=>drop.classList.add('over')); $('input-panel').addEventListener('dragleave',event=>{if(!event.currentTarget.contains(event.relatedTarget))drop.classList.remove('over')}); $('input-panel').addEventListener('drop',event=>{drop.classList.remove('over');const dropped=event.dataTransfer.files[0];if(dropped)convertFile(dropped)});
    $('source').addEventListener('input',()=>{state.file=null;$('file-chip').classList.remove('show');$('input-meta').textContent=detectText($('source').value);updateInputStats(new TextEncoder().encode($('source').value).length)});
    $('source').addEventListener('paste',event=>{const html=event.clipboardData?.getData('text/html');if(html){event.preventDefault();const input=$('source'),start=input.selectionStart,end=input.selectionEnd;input.value=input.value.slice(0,start)+html+input.value.slice(end);input.selectionStart=input.selectionEnd=start+html.length;setTimeout(()=>{updateInputStats(new TextEncoder().encode(input.value).length);convertText()},0)}});
    document.addEventListener('keydown',event=>{if((event.ctrlKey||event.metaKey)&&event.key==='Enter'){event.preventDefault();$('convert').click()}});
    window.addEventListener('webclip:anydoc-ready',()=>{const el=$('anydoc-engine');el.innerHTML='<em></em><strong>AnyDoc</strong> Rust/WASM ready'}); window.addEventListener('webclip:anydoc-error',event=>{const el=$('anydoc-engine');el.innerHTML='<strong>AnyDoc</strong> unavailable';el.title=event.detail?.message||String(event.detail)});
  })();""")
            ]
            script [ _type "module" ] [
                    rawText ("""window.WebclipAnyDoc={ready:false,error:null};
    try{
      const module=await import('./anydoc/anydoc_wasm.js');
      await module.default();
      Object.assign(window.WebclipAnyDoc,{ready:true,formatFromBytes:module.formatFromBytes,formatFromPath:module.formatFromPath,toMarkdownBytes:module.toMarkdownBytes});
      window.dispatchEvent(new CustomEvent('webclip:anydoc-ready'));
    }catch(error){window.WebclipAnyDoc.error=error;window.dispatchEvent(new CustomEvent('webclip:anydoc-error',{detail:error}));}""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
