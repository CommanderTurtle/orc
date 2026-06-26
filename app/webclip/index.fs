module App.Webclip

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Web Clipper - HTML to Markdown Converter"
            ]
            style [] [
                    rawText ("""/* ===== SCOPED CSS - Embed-safe with .wc- prefix ===== */
.wc-wrap {
  --bg: #0f0f1a;
  --bg2: #1a1a2e;
  --bg3: #16213e;
  --panel: rgba(26,26,46,0.7);
  --input: rgba(15,15,26,0.8);
  --accent: #e94560;
  --accent2: #ff6b81;
  --text: #eaeaea;
  --text2: #a0a0b8;
  --muted: #6a6a80;
  --border: rgba(255,255,255,0.08);
  --glass: rgba(26,26,46,0.55);
  --success: #00d9a3;
  --codebg: #0d1117;
  --radius: 12px;
  --radius-sm: 8px;
  --font: -apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,Helvetica,Arial,sans-serif;
  --mono: "SFMono-Regular",Consolas,"Liberation Mono",Menlo,Courier,monospace;
}
.wc-wrap {
  font-family: var(--font);
  background:
    radial-gradient(ellipse at 20% 20%, rgba(233,69,96,0.08) 0%, transparent 50%),
    radial-gradient(ellipse at 80% 80%, rgba(22,33,62,0.6) 0%, transparent 50%),
    #0f0f1a;
  color: var(--text);
  line-height: 1.6;
}
.wc-wrap ::-webkit-scrollbar { width: 8px; height: 8px; }
.wc-wrap ::-webkit-scrollbar-track { background: var(--bg2); border-radius: 4px; }
.wc-wrap ::-webkit-scrollbar-thumb { background: var(--bg3); border-radius: 4px; }
.wc-wrap { scrollbar-width: thin; scrollbar-color: var(--bg3) var(--bg2); }

.wc-container { max-width: 1400px; margin: 0 auto; padding: 20px; min-height: 100vh; display: flex; flex-direction: column; }
.wc-header { text-align: center; padding: 30px 0 25px; animation: wc-fadeInDown 0.6s ease; }
.wc-logo { display: inline-flex; align-items: center; gap: 12px; margin-bottom: 8px; }
.wc-logo-icon { width: 42px; height: 42px; background: linear-gradient(135deg, var(--accent), #c73e54); border-radius: var(--radius-sm); display: flex; align-items: center; justify-content: center; box-shadow: 0 0 20px rgba(233,69,96,0.3); }
.wc-header h1 { font-size: 2rem; font-weight: 700; letter-spacing: -0.5px; background: linear-gradient(135deg, var(--text), var(--accent)); -webkit-background-clip: text; -webkit-text-fill-color: transparent; background-clip: text; margin: 0; }
.wc-header p { color: var(--text2); font-size: 0.95rem; max-width: 500px; margin: 0 auto; }

.wc-main-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 20px; flex: 1; animation: wc-fadeInUp 0.6s ease 0.1s both; }
.wc-panel { background: var(--glass); backdrop-filter: blur(20px); -webkit-backdrop-filter: blur(20px); border: 1px solid rgba(255,255,255,0.1); border-radius: var(--radius); display: flex; flex-direction: column; overflow: hidden; transition: border-color 0.3s, box-shadow 0.3s; }
.wc-panel:hover { border-color: rgba(233,69,96,0.4); box-shadow: 0 8px 32px rgba(0,0,0,0.4); }
.wc-panel-header { display: flex; align-items: center; justify-content: space-between; padding: 14px 18px; border-bottom: 1px solid var(--border); background: rgba(22,33,62,0.4); flex-wrap: wrap; gap: 8px; }
.wc-panel-title { font-size: 0.85rem; font-weight: 600; text-transform: uppercase; letter-spacing: 1px; color: var(--text2); display: flex; align-items: center; gap: 8px; }
.wc-panel-body { flex: 1; overflow: hidden; position: relative; min-height: 300px; }

/* Input section */
.wc-input-section { display: flex; flex-direction: column; height: 100%; min-height: 300px; position: relative; }
.wc-input-area { flex: 1; min-height: 200px; width: 100%; background: var(--input); border: 1px solid transparent; color: var(--text); font-family: var(--mono); font-size: 0.875rem; line-height: 1.7; padding: 16px 18px; resize: vertical; outline: none; tab-size: 2; display: block; transition: border-color 0.2s; box-sizing: border-box; }
.wc-input-area:focus { border-color: var(--accent); }
.wc-input-area::placeholder { color: var(--muted); }
.wc-drop-zone { display: flex; flex-direction: row; align-items: center; justify-content: center; gap: 12px; padding: 12px 16px; border-top: 1px dashed var(--border); background: rgba(233,69,96,0.02); transition: all 0.3s; cursor: pointer; flex-shrink: 0; }
.wc-drop-zone:hover, .wc-drop-zone.drag-over { background: rgba(233,69,96,0.06); border-top-color: var(--accent); }
.wc-drop-zone-text { color: var(--text2); font-size: 0.8rem; }
.wc-drop-zone-hint { color: var(--muted); font-size: 0.7rem; }

/* Drag overlay */
.wc-drag-overlay { position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(233,69,96,0.12); border: 3px dashed var(--accent); display: none; align-items: center; justify-content: center; z-index: 100; border-radius: var(--radius); backdrop-filter: blur(2px); pointer-events: none; }
.wc-drag-overlay.active { display: flex; }

/* Output tabs */
.wc-output-tabs { display: flex; background: rgba(22,33,62,0.4); border-bottom: 1px solid var(--border); }
.wc-tab-btn { flex: 1; padding: 10px 16px; background: none; border: none; color: var(--muted); font-size: 0.8rem; font-weight: 600; cursor: pointer; transition: all 0.2s; position: relative; font-family: inherit; }
.wc-tab-btn:hover { color: var(--text2); background: rgba(255,255,255,0.03); }
.wc-tab-btn.active { color: var(--accent); background: rgba(233,69,96,0.08); }
.wc-tab-btn.active::after { content: ''; position: absolute; bottom: 0; left: 20%; right: 20%; height: 2px; background: var(--accent); border-radius: 2px; }
.wc-output-content { flex: 1; overflow: auto; padding: 16px 18px; }

/* Preview styles */
.wc-preview h1,.wc-preview h2,.wc-preview h3,.wc-preview h4,.wc-preview h5,.wc-preview h6 { margin: 1.2em 0 0.5em; font-weight: 600; line-height: 1.3; }
.wc-preview h1 { font-size: 1.5em; border-bottom: 2px solid var(--accent); padding-bottom: 0.2em; }
.wc-preview h2 { font-size: 1.25em; border-bottom: 1px solid var(--border); padding-bottom: 0.2em; }
.wc-preview h3 { font-size: 1.1em; color: var(--accent); }
.wc-preview p { margin: 0.7em 0; }
.wc-preview a { color: var(--accent); text-decoration: none; border-bottom: 1px solid transparent; transition: border-color 0.2s; }
.wc-preview a:hover { border-bottom-color: var(--accent); }
.wc-preview strong { color: #fff; font-weight: 600; }
.wc-preview code { background: var(--codebg); padding: 2px 7px; border-radius: 4px; font-family: var(--mono); font-size: 0.85em; color: #ff7b72; }
.wc-preview pre { background: var(--codebg); border: 1px solid var(--border); border-radius: var(--radius-sm); padding: 16px; overflow-x: auto; margin: 1em 0; }
.wc-preview pre code { background: none; padding: 0; color: #e6edf3; font-size: 0.8rem; line-height: 1.6; }
.wc-preview blockquote { border-left: 3px solid var(--accent); margin: 1em 0; padding: 8px 16px; background: rgba(233,69,96,0.05); border-radius: 0 var(--radius-sm) var(--radius-sm) 0; color: var(--text2); }
.wc-preview ul,.wc-preview ol { margin: 0.7em 0; padding-left: 2em; }
.wc-preview li { margin: 0.25em 0; }
.wc-preview table { width: 100%; border-collapse: collapse; margin: 1em 0; font-size: 0.85rem; }
.wc-preview th,.wc-preview td { padding: 8px 12px; border: 1px solid var(--border); text-align: left; }
.wc-preview th { background: rgba(233,69,96,0.1); font-weight: 600; color: var(--accent); }
.wc-preview tr:nth-child(even) { background: rgba(255,255,255,0.02); }
.wc-preview hr { border: none; border-top: 2px solid var(--border); margin: 1.5em 0; }
.wc-preview img { max-width: 100%; border-radius: var(--radius-sm); }

/* Raw output */
.wc-raw { font-family: var(--mono); font-size: 0.8rem; line-height: 1.7; color: var(--text); white-space: pre-wrap; word-break: break-word; }

/* Buttons */
.wc-actions { display: flex; flex-wrap: wrap; gap: 10px; padding: 14px 18px; border-top: 1px solid var(--border); background: rgba(22,33,62,0.4); }
.wc-btn { display: inline-flex; align-items: center; gap: 6px; padding: 9px 16px; border-radius: var(--radius-sm); font-size: 0.8rem; font-weight: 600; cursor: pointer; transition: all 0.2s; border: 1px solid transparent; font-family: inherit; color: inherit; }
.wc-btn:hover { transform: translateY(-1px); }
.wc-btn:active { transform: translateY(0); }
.wc-btn-primary { background: var(--accent); color: white; border-color: var(--accent); }
.wc-btn-primary:hover { background: var(--accent2); box-shadow: 0 0 20px rgba(233,69,96,0.3); }
.wc-btn-secondary { background: rgba(255,255,255,0.06); color: var(--text2); border-color: var(--border); }
.wc-btn-secondary:hover { background: rgba(255,255,255,0.1); border-color: rgba(233,69,96,0.4); color: var(--text); }
.wc-file-input { display: none; }
.wc-file-btn { display: inline-flex; align-items: center; gap: 6px; padding: 8px 16px; background: var(--accent); color: white; border: none; border-radius: var(--radius-sm); font-size: 0.8rem; font-weight: 600; cursor: pointer; transition: all 0.2s; font-family: inherit; }
.wc-file-btn:hover { background: var(--accent2); transform: translateY(-1px); }

/* Status bar */
.wc-status { display: flex; flex-wrap: wrap; align-items: center; justify-content: space-between; gap: 10px; padding: 12px 18px; margin-top: 16px; background: var(--glass); backdrop-filter: blur(20px); border: 1px solid rgba(255,255,255,0.1); border-radius: var(--radius); font-size: 0.78rem; color: var(--muted); animation: wc-fadeInUp 0.6s ease 0.2s both; }
.wc-status-left,.wc-status-right { display: flex; flex-wrap: wrap; gap: 16px; align-items: center; }
.wc-status-dot { width: 7px; height: 7px; border-radius: 50%; background: var(--success); animation: wc-pulse 2s infinite; }
.wc-label { color: var(--muted); }
.wc-value { color: var(--text2); font-weight: 600; }

/* Modal */
.wc-modal-overlay { position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: rgba(0,0,0,0.7); backdrop-filter: blur(5px); display: flex; align-items: center; justify-content: center; z-index: 1000; opacity: 0; visibility: hidden; transition: all 0.3s; padding: 20px; }
.wc-modal-overlay.active { opacity: 1; visibility: visible; }
.wc-modal { background: var(--bg2); border: 1px solid rgba(255,255,255,0.1); border-radius: var(--radius); width: 100%; max-width: 900px; max-height: 85vh; display: flex; flex-direction: column; transform: translateY(20px) scale(0.97); transition: transform 0.3s; box-shadow: 0 8px 32px rgba(0,0,0,0.4); }
.wc-modal-overlay.active .wc-modal { transform: translateY(0) scale(1); }
.wc-modal-header { display: flex; align-items: center; justify-content: space-between; padding: 14px 18px; border-bottom: 1px solid var(--border); }
.wc-modal-title { font-size: 0.95rem; font-weight: 600; }
.wc-modal-close { background: none; border: none; color: var(--muted); cursor: pointer; padding: 4px; border-radius: var(--radius-sm); transition: all 0.2s; display: flex; font-family: inherit; }
.wc-modal-close:hover { background: rgba(255,255,255,0.08); color: var(--text); }
.wc-modal-body { flex: 1; overflow: auto; padding: 0; }
.wc-modal-code { display: flex; }
.wc-line-numbers { padding: 18px 10px 18px 14px; text-align: right; color: var(--muted); font-family: var(--mono); font-size: 0.75rem; line-height: 1.7; border-right: 1px solid var(--border); background: rgba(0,0,0,0.2); user-select: none; }
.wc-modal-content { font-family: var(--mono); font-size: 0.8rem; line-height: 1.7; padding: 18px; white-space: pre-wrap; word-break: break-word; color: var(--text); flex: 1; }

/* Toast */
.wc-toast { position: fixed; bottom: 30px; right: 30px; background: var(--bg2); border: 1px solid var(--success); color: var(--success); padding: 12px 20px; border-radius: var(--radius-sm); font-size: 0.85rem; font-weight: 600; display: flex; align-items: center; gap: 8px; box-shadow: 0 4px 20px rgba(0,217,163,0.2); transform: translateY(100px); opacity: 0; transition: all 0.4s cubic-bezier(0.175,0.885,0.32,1.275); z-index: 2000; }
.wc-toast.show { transform: translateY(0); opacity: 1; }

/* Spinner */
.wc-spinner-overlay { position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(15,15,26,0.8); display: flex; align-items: center; justify-content: center; z-index: 10; opacity: 0; visibility: hidden; transition: all 0.3s; backdrop-filter: blur(3px); }
.wc-spinner-overlay.active { opacity: 1; visibility: visible; }
.wc-spinner { width: 40px; height: 40px; border: 3px solid var(--border); border-top-color: var(--accent); border-radius: 50%; animation: wc-spin 0.8s linear infinite; }

/* Empty state */
.wc-empty { display: flex; flex-direction: column; align-items: center; justify-content: center; height: 100%; min-height: 200px; color: var(--muted); text-align: center; padding: 20px; }

/* Filename display */
.wc-filename { font-size: 0.75rem; color: var(--success); padding: 4px 18px; min-height: 22px; }

/* Responsive */
@media (max-width: 768px) { .wc-main-grid { grid-template-columns: 1fr; } .wc-header h1 { font-size: 1.5rem; } .wc-actions { justify-content: center; } .wc-status { flex-direction: column; align-items: flex-start; } }

@keyframes wc-fadeInDown { from { opacity: 0; transform: translateY(-20px); } to { opacity: 1; transform: translateY(0); } }
@keyframes wc-fadeInUp { from { opacity: 0; transform: translateY(20px); } to { opacity: 1; transform: translateY(0); } }
@keyframes wc-spin { to { transform: rotate(360deg); } }
@keyframes wc-pulse { 0%,100% { opacity: 1; } 50% { opacity: 0.4; } }
.wc-wrap ::selection { background: rgba(233,69,96,0.3); color: #fff; }""")
            ]
        ]
        body [] [
            div [ _class "wc-wrap" ] [
                div [ _class "wc-container" ] [
                    header [ _class "wc-header" ] [
                        div [ _class "wc-logo" ] [
                            div [ _class "wc-logo-icon" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "color:white;width:24px;height:24px" ] [
                                    voidTag "polyline" [ attr "points" "16 18 22 12 16 6" ]
                                    voidTag "polyline" [ attr "points" "8 6 2 12 8 18" ]
                                    voidTag "line" [ attr "x1" "9"; attr "y1" "3"; attr "x2" "15"; attr "y2" "21" ]
                                ]
                            ]
                            h1 [] [
                                str "Web Clipper"
                            ]
                        ]
                        p [] [
                            str "Convert HTML, rich text, and web content to clean Markdown - Readthedocs:"
                            a [ _href "https://example.com"; attr "title" "this is sparta, no, this is thumbnail" ] [
                                str "docs.shel.sh/automate"
                            ]
                        ]
                    ]
                    div [ _class "wc-main-grid" ] [
                        rawText ("""<!--  INPUT PANEL  -->""")
                        div [ _class "wc-panel"; _id "wc-inputPanel" ] [
                            div [ _class "wc-panel-header" ] [
                                div [ _class "wc-panel-title" ] [
                                    tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:16px;height:16px;opacity:0.7" ] [
                                        voidTag "path" [ attr "d" "M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z" ]
                                        voidTag "polyline" [ attr "points" "14 2 14 8 20 8" ]
                                        voidTag "line" [ attr "x1" "16"; attr "y1" "13"; attr "x2" "8"; attr "y2" "13" ]
                                        voidTag "line" [ attr "x1" "16"; attr "y1" "17"; attr "x2" "8"; attr "y2" "17" ]
                                    ]
                                    str "Input"
                                ]
                                button [ _class "wc-file-btn"; attr "onclick" "document.getElementById('wc-fileInput').click()" ] [
                                    tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:14px;height:14px" ] [
                                        voidTag "path" [ attr "d" "M13 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V9z" ]
                                        voidTag "polyline" [ attr "points" "13 2 13 9 20 9" ]
                                    ]
                                    str "Choose File"
                                ]
                                input [ _type "file"; _id "wc-fileInput"; _class "wc-file-input"; attr "accept" ".html,.htm,.txt,.md,.json" ]
                            ]
                            div [ _class "wc-panel-body" ] [
                                div [ _class "wc-input-section" ] [
                                    tag "textarea" [ _id "wc-inputArea"; _class "wc-input-area"; attr "placeholder" "Paste HTML, rich text, or plain content here...\n\nTip: Drag & drop files anywhere on this panel, or use the Choose File button."; attr "spellcheck" "false" ] []
                                    div [ _class "wc-drop-zone"; _id "wc-dropZone" ] [
                                        tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "1.5"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:20px;height:20px;opacity:0.5" ] [
                                            voidTag "path" [ attr "d" "M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" ]
                                            voidTag "polyline" [ attr "points" "17 8 12 3 7 8" ]
                                            voidTag "line" [ attr "x1" "12"; attr "y1" "3"; attr "x2" "12"; attr "y2" "15" ]
                                        ]
                                        span [ _class "wc-drop-zone-text" ] [
                                            str "Drop files here"
                                        ]
                                        span [ _class "wc-drop-zone-hint" ] [
                                            str ".html .txt .md .json"
                                        ]
                                    ]
                                    div [ _class "wc-drag-overlay"; _id "wc-dragOverlay" ] [
                                        div [ attr "style" "text-align:center;color:var(--accent)" ] [
                                            tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:64px;height:64px;margin:0 auto 12px" ] [
                                                voidTag "path" [ attr "d" "M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" ]
                                                voidTag "polyline" [ attr "points" "17 8 12 3 7 8" ]
                                                voidTag "line" [ attr "x1" "12"; attr "y1" "3"; attr "x2" "12"; attr "y2" "15" ]
                                            ]
                                            div [ attr "style" "font-size:1.2rem;font-weight:600" ] [
                                                str "Drop files to convert"
                                            ]
                                        ]
                                    ]
                                    div [ _class "wc-spinner-overlay"; _id "wc-inputSpinner" ] [
                                        div [ _class "wc-spinner" ] []
                                    ]
                                ]
                            ]
                            div [ _class "wc-filename"; _id "wc-filenameDisplay" ] []
                            div [ _class "wc-actions"; attr "style" "justify-content:center;gap:8px" ] [
                                button [ _class "wc-btn wc-btn-primary"; _id "wc-convertBtn" ] [
                                    tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:14px;height:14px" ] [
                                        voidTag "polyline" [ attr "points" "16 18 22 12 16 6" ]
                                        voidTag "polyline" [ attr "points" "8 6 2 12 8 18" ]
                                    ]
                                    str "Convert"
                                ]
                                button [ _class "wc-btn wc-btn-secondary"; _id "wc-clearBtn" ] [
                                    tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:14px;height:14px" ] [
                                        voidTag "polyline" [ attr "points" "3 6 5 6 21 6" ]
                                        voidTag "path" [ attr "d" "M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2" ]
                                    ]
                                    str "Clear"
                                ]
                            ]
                        ]
                        rawText ("""<!--  OUTPUT PANEL  -->""")
                        div [ _class "wc-panel"; _id "wc-outputPanel" ] [
                            div [ _class "wc-panel-header" ] [
                                div [ _class "wc-panel-title" ] [
                                    tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:16px;height:16px;opacity:0.7" ] [
                                        voidTag "path" [ attr "d" "M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z" ]
                                        voidTag "polyline" [ attr "points" "14 2 14 8 20 8" ]
                                    ]
                                    str "Output"
                                ]
                                div [ attr "style" "display:flex;align-items:center;gap:6px" ] [
                                    button [ _class "wc-btn wc-btn-secondary"; _id "wc-viewRawBtn" ] [
                                        tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:14px;height:14px" ] [
                                            voidTag "path" [ attr "d" "M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z" ]
                                            voidTag "circle" [ attr "cx" "12"; attr "cy" "12"; attr "r" "3" ]
                                        ]
                                        str "View Raw"
                                    ]
                                    button [ _class "wc-btn wc-btn-secondary"; _id "wc-copyBtn" ] [
                                        tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:14px;height:14px" ] [
                                            voidTag "rect" [ attr "x" "9"; attr "y" "9"; attr "width" "13"; attr "height" "13"; attr "rx" "2"; attr "ry" "2" ]
                                            voidTag "path" [ attr "d" "M5 15H4a2 2 0 0 1-2-2V4a2 2 0 0 1 2-2h9a2 2 0 0 1 2 2v1" ]
                                        ]
                                        str "Copy Raw"
                                    ]
                                    button [ _class "wc-btn wc-btn-primary"; _id "wc-downloadBtn" ] [
                                        tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:14px;height:14px" ] [
                                            voidTag "path" [ attr "d" "M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" ]
                                            voidTag "polyline" [ attr "points" "7 10 12 15 17 10" ]
                                            voidTag "line" [ attr "x1" "12"; attr "y1" "15"; attr "x2" "12"; attr "y2" "3" ]
                                        ]
                                        str "Download .md"
                                    ]
                                ]
                            ]
                            div [ _class "wc-output-tabs" ] [
                                button [ _class "wc-tab-btn active"; attr "data-tab" "rendered" ] [
                                    str "Rendered"
                                ]
                                button [ _class "wc-tab-btn"; attr "data-tab" "raw" ] [
                                    str "Raw Markdown"
                                ]
                            ]
                            div [ _class "wc-panel-body"; attr "style" "position:relative" ] [
                                div [ _class "wc-output-content"; _id "wc-renderedOutput"; attr "style" "display:block" ] [
                                    div [ _class "wc-empty"; _id "wc-emptyState" ] [
                                        tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "1.5"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:48px;height:48px;opacity:0.3;margin-bottom:12px" ] [
                                            voidTag "path" [ attr "d" "M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z" ]
                                            voidTag "polyline" [ attr "points" "14 2 14 8 20 8" ]
                                            voidTag "line" [ attr "x1" "16"; attr "y1" "13"; attr "x2" "8"; attr "y2" "13" ]
                                            voidTag "line" [ attr "x1" "16"; attr "y1" "17"; attr "x2" "8"; attr "y2" "17" ]
                                        ]
                                        p [] [
                                            str "Converted Markdown will appear here."
                                            br []
                                            str "Paste content, drop a file, or type above to get started."
                                        ]
                                    ]
                                    div [ _class "wc-preview"; _id "wc-previewArea"; attr "style" "display:none" ] []
                                ]
                                div [ _class "wc-output-content"; _id "wc-rawOutput"; attr "style" "display:none" ] [
                                    div [ _class "wc-raw"; _id "wc-rawArea" ] []
                                ]
                                div [ _class "wc-spinner-overlay"; _id "wc-outputSpinner" ] [
                                    div [ _class "wc-spinner" ] []
                                ]
                            ]
                        ]
                    ]
                    rawText ("""<!--  Status Bar  -->""")
                    div [ _class "wc-status" ] [
                        div [ _class "wc-status-left" ] [
                            div [ attr "style" "display:flex;align-items:center;gap:5px" ] [
                                div [ _class "wc-status-dot" ] []
                                span [] [
                                    str "Ready"
                                ]
                            ]
                            div [] [
                                span [ _class "wc-label" ] [
                                    str "Input:"
                                ]
                                span [ _class "wc-value"; _id "wc-inputStats" ] [
                                    str "0 chars / 0 words"
                                ]
                            ]
                            div [] [
                                span [ _class "wc-label" ] [
                                    str "Output:"
                                ]
                                span [ _class "wc-value"; _id "wc-outputStats" ] [
                                    str "0 chars / 0 words"
                                ]
                            ]
                        ]
                        div [ _class "wc-status-right" ] [
                            div [] [
                                span [ _class "wc-label" ] [
                                    str "Detected:"
                                ]
                                span [ _class "wc-value"; _id "wc-detectedType" ] [
                                    str "—"
                                ]
                            ]
                            div [] [
                                span [ _class "wc-label" ] [
                                    str "Status:"
                                ]
                                span [ _class "wc-value"; _id "wc-convertStatus" ] [
                                    str "Waiting"
                                ]
                            ]
                        ]
                    ]
                ]
                rawText ("""<!--  Modal  -->""")
                div [ _class "wc-modal-overlay"; _id "wc-rawModal" ] [
                    div [ _class "wc-modal" ] [
                        div [ _class "wc-modal-header" ] [
                            span [ _class "wc-modal-title" ] [
                                str "Raw Markdown"
                            ]
                            button [ _class "wc-modal-close"; _id "wc-modalClose" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "style" "width:18px;height:18px" ] [
                                    voidTag "line" [ attr "x1" "18"; attr "y1" "6"; attr "x2" "6"; attr "y2" "18" ]
                                    voidTag "line" [ attr "x1" "6"; attr "y1" "6"; attr "x2" "18"; attr "y2" "18" ]
                                ]
                            ]
                        ]
                        div [ _class "wc-modal-body" ] [
                            div [ _class "wc-modal-code" ] [
                                div [ _class "wc-line-numbers"; _id "wc-lineNumbers" ] []
                                div [ _class "wc-modal-content"; _id "wc-modalContent" ] []
                            ]
                        ]
                    ]
                ]
                rawText ("""<!--  Toast  -->""")
                div [ _class "wc-toast"; _id "wc-toast" ] [
                    span [ _id "wc-toastMsg" ] [
                        str "Copied!"
                    ]
                ]
            ]
            rawText ("""<!--  /wc-wrap  -->""")
            script [] [
                    rawText ("""// ===== WEB CLIPPER v3 - Complete Clean Build =====
(function() {
  'use strict';

  // ===== STATE =====
  var currentMD = '', currentFile = '', currentTitle = 'Web Clip';

  // ===== DOM HELPERS =====
  function $(id) { return document.getElementById(id); }
  function debounce(fn, ms) {
    var t;
    return function() { clearTimeout(t); t = setTimeout(fn.bind(this), ms); };
  }
  function escHtml(t) { var d = document.createElement('div'); d.textContent = t; return d.innerHTML; }
  function countWords(s) { return s.trim().split(/\s+/).filter(function(w) { return w.length; }).length; }
  function fmtDate(d) {
    var p = function(n) { return String(n).padStart(2, '0'); };
    return d.getFullYear() + '-' + p(d.getMonth() + 1) + '-' + p(d.getDate()) + 'T' + p(d.getHours()) + '-' + p(d.getMinutes());
  }
  function toast(msg) {
    var t = $('wc-toast'), m = $('wc-toastMsg');
    m.textContent = msg; t.classList.add('show');
    setTimeout(function() { t.classList.remove('show'); }, 2500);
  }
  function spinner(id, on) { $(id).classList.toggle('active', on); }
  function setStatus(type, msg) {
    if (type) $('wc-detectedType').textContent = type;
    if (msg) $('wc-convertStatus').textContent = msg;
  }
  function setStats(inp, out) {
    if (inp !== undefined) $('wc-inputStats').textContent = inp.length + ' chars / ' + countWords(inp) + ' words';
    if (out !== undefined) $('wc-outputStats').textContent = out.length + ' chars / ' + countWords(out) + ' words';
  }

  // ===== FRONTMATTER =====
  function makeFrontmatter(title, url) {
    var lines = ['---', 'title: ' + JSON.stringify(title || 'Web Clip')];
    if (url) lines.push('url: ' + JSON.stringify(url));
    lines.push('date: ' + fmtDate(new Date()), 'source: "Web Clipper"', '---');
    return lines.join('\n');
  }

  // ===== DETECT INPUT TYPE =====
  function detectType(text) {
    if (!text || !text.trim()) return 'empty';
    var t = text.trim();
    if (t.indexOf('<!DOCTYPE') === 0 || t.indexOf('<html') === 0 || (t[0] === '<' && t.indexOf('</') > 0)) return 'HTML';
    if (t.indexOf('---') === 0 && t.indexOf('\n---\n') > 0) return 'Markdown (frontmatter)';
    if (/^#{1,6}\s/m.test(t) || /\[.*?\]\(.*?\)/.test(t) || /\*\*.*?\*\*/.test(t) || /^[-*+]\s/m.test(t)) return 'Markdown';
    return 'Plain Text';
  }

  // ===== HTML TO MARKDOWN CONVERTER =====
  var Converter = (function() {
    function isH(n) { return /^H[1-6]$/i.test(n.nodeName); }
    function getLang(node) {
      var cls = node.className || '';
      var m = cls.match(/(?:lang|language)-([a-zA-Z0-9_-]+)/);
      return m ? m[1] : '';
    }

    // Inline
    function inline(node) {
      if (node.nodeType === 3) return escInline(node.textContent);
      if (node.nodeType !== 1) return '';
      var name = node.nodeName, c = inlineContent(node);
      if (name === 'STRONG' || name === 'B') return '**' + c + '**';
      if (name === 'EM' || name === 'I' || name === 'CITE') return '*' + c + '*';
      if (name === 'DEL' || name === 'S' || name === 'STRIKE') return '~~' + c + '~~';
      if (name === 'CODE') return '`' + c.replace(/`/g, '\\`') + '`';
      if (name === 'A') {
        var h = node.getAttribute('href') || '', t = node.getAttribute('title');
        if (!h) return c;
        return '[' + c + '](' + h + (t ? ' "' + t.replace(/"/g, '\\"') + '"' : '') + ')';
      }
      if (name === 'IMG') {
        var s = node.getAttribute('src') || '', a = node.getAttribute('alt') || '', t2 = node.getAttribute('title');
        return '![' + a + '](' + s + (t2 ? ' "' + t2.replace(/"/g, '\\"') + '"' : '') + ')';
      }
      if (name === 'BR') return '  \n';
      if (name === 'SUP') return '^' + c + '^';
      if (name === 'SUB') return '~' + c + '~';
      if (name === 'ABBR') { var at = node.getAttribute('title'); return at ? c + ' (' + at + ')' : c; }
      if (name === 'TIME') { var dt = node.getAttribute('datetime'); return dt || c; }
      if (name === 'MARK') return '==' + c + '==';
      if (name === 'KBD') return '<kbd>' + c + '</kbd>';
      if (['SPAN','FONT','BIG','SMALL','VAR','SAMP','DATA','Q','DFN','INS','OUTPUT','RUBY','RT','RP','BDI','BDO','WBR'].indexOf(name) !== -1) return c;
      return c;
    }
    function inlineContent(node) {
      var r = '';
      for (var i = 0; i < node.childNodes.length; i++) r += inline(node.childNodes[i]);
      return r;
    }
    function escInline(t) {
      return t.replace(/\\/g, '\\\\').replace(/\*/g, '\\*').replace(/_/g, '\\_').replace(/\[/g, '\\[').replace(/\]/g, '\\]').replace(/^>/gm, '\\>');
    }
    function escCell(t) { return t.replace(/\|/g, '\\|').replace(/\n/g, '<br>'); }

    // Block
    function blocks(container) {
      var items = container.nodeType === 1 || container.nodeType === 11 || container.nodeType === 9
        ? Array.from(container.childNodes) : [container];
      var r = [];
      for (var i = 0; i < items.length; i++) {
        var b = block(items[i]);
        if (b !== null && b !== '') r.push(b);
      }
      return r.join('\n\n');
    }
    function isNavTable(n) {
      var cls = (n.getAttribute('class') || '');
      if (/\b(sidebar|navbox|navbar|metadata|infobox|mbox|ambox|tmbox|fmbox|dmbox|ombox)\b/i.test(cls)) return true;
      if (n.querySelector('.sidebar, .navbox, .navbar, .nv-view, .nv-talk, .nv-edit')) return true;
      return false;
    }
    function block(node) {
      if (!node) return '';
      if (node.nodeType === 3) { var t = node.textContent.trim(); return t || ''; }
      if (node.nodeType === 8) return '';
      if (node.nodeType !== 1) return '';
      var name = node.nodeName;

      if (['SCRIPT','STYLE','NOSCRIPT','IFRAME','SVG','MATH','TEMPLATE','CANVAS','VIDEO','AUDIO','EMBED','OBJECT','PARAM','SOURCE','TRACK','MAP','AREA','FRAME','FRAMESET','LINK'].indexOf(name) !== -1) return '';

      var cls = node.getAttribute('class') || '';
      if (/\b(shortdescription|mw-empty-elt|noprint|nomobile|noexcerpt|searchaux|mw-editsection|visualhide|sronly)\b/.test(cls)) return '';
      if (node.getAttribute('style') === 'display:none') return '';
      if (node.getAttribute('role') === 'navigation') return '';
      if (node.getAttribute('typeof') === 'mw:Transclusion') return '';
      if (name === 'TABLE' && isNavTable(node)) return '';
      if ((name === 'DIV' || name === 'SPAN') && !node.querySelector('img, br, table, ul, ol, pre, blockquote, h1, h2, h3, h4, h5, h6, p, figure') && !node.textContent.trim()) return '';

      if (isH(node)) { var lv = parseInt(name[1]); var h = inlineContent(node).trim(); return h ? '#'.repeat(lv) + ' ' + h : ''; }
      if (name === 'P') { var p = inlineContent(node).trim(); return p || ''; }
      if (name === 'HR') return '---';
      if (name === 'PRE') {
        var ce = node.querySelector('code');
        if (ce) { var lg = getLang(ce); return '```' + lg + '\n' + ce.textContent + '\n```'; }
        return '```\n' + node.textContent + '\n```';
      }
      if (name === 'CODE') return '```\n' + node.textContent + '\n```';
      if (name === 'BLOCKQUOTE') {
        var bq = blocks(node);
        if (!bq) return '';
        return bq.split('\n').map(function(l) { return l.trim() ? '> ' + l : '>'; }).join('\n');
      }
      if (name === 'FIGURE') {
        var img = node.querySelector('img'), cap = node.querySelector('figcaption'), res = '';
        if (img) { var isrc = img.getAttribute('src') || '', ialt = img.getAttribute('alt') || '', it = img.getAttribute('title'); res += '![' + ialt + '](' + isrc + (it ? ' "' + it.replace(/"/g, '\\"') + '"' : '') + ')'; }
        if (cap) res += (res ? '\n\n' : '') + '*' + inlineContent(cap).trim() + '*';
        return res || inlineContent(node).trim();
      }
      if (name === 'FIGCAPTION') return '*' + inlineContent(node).trim() + '*';
      if (name === 'UL') return Array.from(node.children).filter(function(c) { return c.nodeName === 'LI'; }).map(function(li) { return listIndent(li) + '- ' + listItem(li); }).join('\n');
      if (name === 'OL') { var st = parseInt(node.getAttribute('start')) || 1; return Array.from(node.children).filter(function(c) { return c.nodeName === 'LI'; }).map(function(li, idx) { return listIndent(li) + (idx + st) + '. ' + listItem(li); }).join('\n'); }
      if (name === 'TABLE') return procTable(node);
      if (name === 'DL') return Array.from(node.children).map(function(c) { if (c.nodeName === 'DT') return '**' + inlineContent(c).trim() + '**'; if (c.nodeName === 'DD') return ': ' + inlineContent(c).trim(); return ''; }).join('\n');
      if (name === 'DETAILS') { var sum = node.querySelector('summary'); var stx = sum ? inlineContent(sum).trim() : 'Details'; var tmp = document.createElement('div'); for (var ci = 0; ci < node.childNodes.length; ci++) { if (node.childNodes[ci] !== sum) tmp.appendChild(node.childNodes[ci].cloneNode(true)); } return '**' + stx + '**\n\n' + blocks(tmp); }
      if (name === 'SUMMARY') return inlineContent(node).trim();
      if (name === 'IMG') { var ms = node.getAttribute('src') || '', ma = node.getAttribute('alt') || '', mt = node.getAttribute('title'); return '![' + ma + '](' + ms + (mt ? ' "' + mt.replace(/"/g, '\\"') + '"' : '') + ')'; }
      if (name === 'A') { var ah = node.getAttribute('href') || '', at2 = node.getAttribute('title') || '', ax = inlineContent(node); return '[' + ax + '](' + ah + (at2 ? ' "' + at2.replace(/"/g, '\\"') + '"' : '') + ')'; }
      if (name === 'BR') return '';
      if (name === 'DIV') return blocks(node);
      if (['NAV','HEADER','FOOTER','ASIDE'].indexOf(name) !== -1) return '';
      if (['SECTION','ARTICLE','MAIN'].indexOf(name) !== -1) return blocks(node);
      if (name === 'FIELDSET' || name === 'FORM') return blocks(node);
      if (name === 'LEGEND') return '**' + inlineContent(node).trim() + '**';
      return inlineContent(node).trim() || '';
    }

    function listIndent(li) { var d = 0, p = li.parentElement; while (p) { if (p.nodeName === 'UL' || p.nodeName === 'OL') d++; p = p.parentElement; } return '  '.repeat(Math.max(0, d - 1)); }
    function listItem(li) {
      var r = '';
      for (var i = 0; i < li.childNodes.length; i++) {
        var c = li.childNodes[i];
        if (c.nodeType === 3) r += c.textContent;
        else if (c.nodeType === 1) { var cn = c.nodeName; if (cn === 'UL' || cn === 'OL') r += '\n' + block(c); else if (cn === 'P') r += inlineContent(c); else r += inline(c); }
      }
      return r.trim();
    }
    function procTable(table) {
      if (isNavTable(table)) return '';
      var headers = [], aligns = [];
      var thead = table.querySelector('thead'), tbody = table.querySelector('tbody'), allTrs = table.querySelectorAll('tr');
      if (thead) { var hr = thead.querySelector('tr'); if (hr) { headers = Array.from(hr.children).map(function(th) { aligns.push(getAlign(th)); return escCell(inlineContent(th).trim()); }); } }
      var dRows = [];
      if (tbody) dRows = Array.from(tbody.querySelectorAll('tr'));
      else { var ar = Array.from(allTrs); if (headers.length > 0 && ar.length > 0) dRows = ar.slice(1); else dRows = ar; }
      if (headers.length === 0 && dRows.length > 0) { var fr = dRows[0]; var fc = Array.from(fr.children); headers = fc.map(function(c) { aligns.push(getAlign(c)); return escCell(inlineContent(c).trim()); }); dRows = dRows.slice(1); }
      if (headers.length === 0) return '';
      var sep = aligns.map(function(a) { if (a === 'center') return ':---:'; if (a === 'right') return '---:'; if (a === 'left') return ':---'; return '---'; }).join(' | ');
      var bl = dRows.map(function(row) { var rc = Array.from(row.children); var vals = rc.map(function(c) { return escCell(inlineContent(c).trim()); }); while (vals.length < headers.length) vals.push(''); return '| ' + vals.join(' | ') + ' |'; });
      return '| ' + headers.join(' | ') + ' |\n| ' + sep + ' |\n' + bl.join('\n');
    }
    function getAlign(cell) {
      var s = (cell.getAttribute('align') || '').toLowerCase();
      if (s === 'center') return 'center'; if (s === 'right') return 'right'; if (s === 'left') return 'left';
      var css = (cell.getAttribute('style') || '').toLowerCase();
      if (css.indexOf('text-align:center') !== -1) return 'center'; if (css.indexOf('text-align:right') !== -1) return 'right'; if (css.indexOf('text-align:left') !== -1) return 'left';
      return '';
    }

    // 3-phase extraction
    function phase1(html) {
      var doc = new DOMParser().parseFromString('<div id="__root">' + html + '</div>', 'text/html');
      var root = doc.getElementById('__root');
      var rm = ['script','style','noscript','iframe','svg','math','template','canvas','video','audio','embed','object','param','source','track','map','area','frame','frameset','link'];
      for (var i = 0; i < rm.length; i++) { var els = root.querySelectorAll(rm[i]); for (var j = els.length - 1; j >= 0; j--) els[j].remove(); }
      var all = root.querySelectorAll('*'); for (var a = 0; a < all.length; a++) if (all[a].getAttribute('style') === 'display:none') all[a].remove();
      var w = doc.createTreeWalker(root, 128, null, false); var comments = [];
      while (w.nextNode()) comments.push(w.currentNode); for (var c = 0; c < comments.length; c++) comments[c].remove();
      return root;
    }
    function stripNoise(el) {
      var noise = ['.shortdescription','.mw-empty-elt','.noprint','.mw-editsection','.visualhide','.sronly','.navbar','.navbox','.sidebar','[role="navigation"]','[typeof="mw:Transclusion"]','.infobox'];
      for (var n = 0; n < noise.length; n++) { var nel = el.querySelectorAll(noise[n]); for (var k = nel.length - 1; k >= 0; k--) nel[k].remove(); }
    }
    function phase2(root) {
      var sel = ['.mw-parser-output','article','[role="main"]','main','#content','.content','.article','.post-content','.entry-content','.page-content','#article'];
      for (var i = 0; i < sel.length; i++) { var f = root.querySelector(sel[i]); if (f && f.textContent.trim().length > 100) { stripNoise(f); return f; } }
      stripNoise(root);
      return root;
    }
    function phase3(node) {
      var all = node.querySelectorAll('*');
      for (var i = 0; i < all.length; i++) {
        var el = all[i]; el.removeAttribute('style');
        var cls = el.getAttribute('class') || '';
        if (!cls.match(/(?:lang|language)-/)) el.removeAttribute('class');
        el.removeAttribute('id');
        var attrs = Array.from(el.attributes);
        for (var at = attrs.length - 1; at >= 0; at--) { var nm = attrs[at].name; if (nm.indexOf('data-') === 0 || nm.indexOf('on') === 0) el.removeAttribute(nm); }
      }
      var empty = node.querySelectorAll(':empty');
      for (var e = empty.length - 1; e >= 0; e--) { var en = empty[e]; if (['BR','HR','IMG','INPUT','META','LINK','COL','SOURCE','TRACK','WBR','AREA','BASE'].indexOf(en.nodeName) === -1) en.remove(); }
    }
    function extractTitle(html, fb) {
      var tm = html.match(/<title[^>]*>([^<]*)<\/title>/i);
      if (tm && tm[1].trim()) return tm[1].trim();
      var h1m = html.match(/<h1[^>]*>([\s\S]*?)<\/h1>/i);
      if (h1m) { var tx = document.createElement('div'); tx.innerHTML = h1m[1]; var txx = tx.textContent.trim(); if (txx) return txx; }
      var ogm = html.match(/<meta[^>]*property=["']og:title["'][^>]*content=["']([^"']+)["']/i);
      if (ogm) return ogm[1];
      return fb || 'Web Clip';
    }
    function extractUrl(html) { var m = html.match(/<meta[^>]*property=["']og:url["'][^>]*content=["']([^"']+)["']/i); return m ? m[1] : ''; }

    return {
      convert: function(html) {
        if (!html || !html.trim()) return '';
        var root = phase1(html);
        var article = phase2(root);
        phase3(article);
        var md = blocks(article);
        md = md.replace(/\n{5,}/g, '\n\n\n\n').replace(/^\s+|\s+$/g, '').replace(/```\n*```/g, '').replace(/\n{3,}/g, '\n\n');
        return md;
      },
      extractTitle: extractTitle,
      extractUrl: extractUrl
    };
  })();

  // ===== PREVIEW RENDERER =====
  function renderPreview(md) {
    var h = escHtml(md);
    h = h.replace(/^---\n[\s\S]*?\n---\n?/m, function(m) { return '<pre style="background:rgba(233,69,96,0.08);border-left:3px solid var(--accent);padding:12px 16px;border-radius:0 var(--radius-sm) var(--radius-sm) 0;margin-bottom:1em;font-size:0.78rem;color:var(--text2)">' + m.replace(/\n/g, '<br>') + '</pre>'; });
    h = h.replace(/```(\w*)\n([\s\S]*?)```/g, function(m, lang, code) { var lt = lang ? '<div style="color:var(--accent);font-size:0.7rem;margin-bottom:4px;text-transform:uppercase;letter-spacing:1px">' + lang + '</div>' : ''; return '<pre style="background:var(--codebg);border:1px solid var(--border);border-radius:var(--radius-sm);padding:16px;overflow-x:auto;margin:1em 0">' + lt + '<code>' + code.replace(/</g, '&lt;') + '</code></pre>'; });
    h = h.replace(/^###### (.+)$/gm, '<h6>$1</h6>').replace(/^##### (.+)$/gm, '<h5>$1</h5>').replace(/^#### (.+)$/gm, '<h4>$1</h4>').replace(/^### (.+)$/gm, '<h3>$1</h3>').replace(/^## (.+)$/gm, '<h2>$1</h2>').replace(/^# (.+)$/gm, '<h1>$1</h1>');
    h = h.replace(/\*\*\*(.+?)\*\*\*/g, '<strong><em>$1</em></strong>').replace(/\*\*(.+?)\*\*/g, '<strong>$1</strong>').replace(/\*(.+?)\*/g, '<em>$1</em>').replace(/~~(.+?)~~/g, '<del>$1</del>');
    h = h.replace(/`([^`]+)`/g, '<code>$1</code>');
    h = h.replace(/\[([^\]]+)\]\(([^)"]+)(?: "([^"]+)")?\)/g, '<a href="$2" title="$3">$1</a>');
    h = h.replace(/!\[([^\]]*)\]\(([^)"]+)(?: "([^"]+)")?\)/g, '<img src="$2" alt="$1" title="$3">');
    h = h.replace(/^---+/gm, '<hr>');
    h = h.replace(/^&gt; (.+)$/gm, '<blockquote>$1</blockquote>');
    h = h.replace(/^(\s*)-\s+(.+)$/gm, function(m, ind, c) { var d = ind.length / 2; return '<li style="margin-left:' + (d * 20) + 'px">' + c + '</li>'; });
    h = h.replace(/^(\s*)\d+\.\s+(.+)$/gm, function(m, ind, c) { var d = ind.length / 2; return '<li style="margin-left:' + (d * 20) + 'px;list-style-type:decimal">' + c + '</li>'; });
    h = h.replace(/^(\|[^\n]+\|)\n(\|[-:\|\s]+\|)\n((?:\|[^\n]+\|\n?)+)/gm, function(m, header, sep, body) { var hs = header.split('|').filter(function(c) { return c.trim(); }).map(function(c) { return '<th>' + c.trim() + '</th>'; }).join(''); var rs = body.trim().split('\n').map(function(row) { var cs = row.split('|').filter(function(c) { return c.trim(); }).map(function(c) { return '<td>' + c.trim() + '</td>'; }).join(''); return '<tr>' + cs + '</tr>'; }).join(''); return '<table><thead><tr>' + hs + '</tr></thead><tbody>' + rs + '</tbody></table>'; });
    var bl = h.split('\n\n');
    h = bl.map(function(b) { b = b.trim(); if (!b) return ''; if (b[0] === '<') { if (/^<[hpuobltdisemr]/.test(b)) return b; } return '<p>' + b.replace(/\n/g, '<br>') + '</p>'; }).join('\n\n');
    h = h.replace(/<\/blockquote>\n<blockquote>/g, '<br>');
    return h;
  }

  // ===== CONVERSION FLOW =====
  function doConvert() {
    var input = $('wc-inputArea').value;
    if (!input.trim()) { setStatus('empty', 'Empty input'); return; }
    spinner('wc-inputSpinner', true);
    spinner('wc-outputSpinner', true);
    setStatus(null, 'Converting...');

    setTimeout(function() {
      try {
        var type = detectType(input);
        setStatus(type, 'Converting...');
        var md = '', title = 'Web Clip', url = '';

        if (type === 'HTML') {
          title = Converter.extractTitle(input, 'Web Clip');
          url = Converter.extractUrl(input);
          md = Converter.convert(input);
        } else if (type === 'Markdown (frontmatter)' || type === 'Markdown') {
          md = input.trim();
          var h1m = md.match(/^#\s+(.+)$/m);
          if (h1m) title = h1m[1].trim();
        } else {
          var paras = input.split(/\n\s*\n/).filter(function(p) { return p.trim(); });
          md = paras.map(function(p) { return p.trim(); }).join('\n\n');
        }

        var finalMD = md;
        if (!md.startsWith('---')) finalMD = makeFrontmatter(title, url) + '\n\n' + md;

        currentMD = finalMD;
        currentTitle = title;

        $('wc-rawArea').textContent = finalMD;
        $('wc-previewArea').innerHTML = renderPreview(finalMD);
        $('wc-emptyState').style.display = 'none';
        $('wc-previewArea').style.display = 'block';
        setStats(input, finalMD);
        setStatus(type, 'Done');

        if (!md.trim()) {
          $('wc-previewArea').innerHTML = '<div class="wc-empty"><svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" style="width:48px;height:48px;opacity:0.3;margin-bottom:12px"><circle cx="12" cy="12" r="10"/><line x1="12" y1="8" x2="12" y2="12"/><line x1="12" y1="16" x2="12.01" y2="16"/></svg><p>No content found. Input may have contained only scripts or navigation elements.</p></div>';
          $('wc-previewArea').style.display = 'block';
        }
      } catch (err) {
        console.error(err);
        setStatus('Error', err.message);
        $('wc-previewArea').innerHTML = '<div class="wc-empty"><p>Error: ' + escHtml(err.message) + '</p></div>';
        $('wc-emptyState').style.display = 'none';
        $('wc-previewArea').style.display = 'block';
      } finally {
        spinner('wc-inputSpinner', false);
        spinner('wc-outputSpinner', false);
      }
    }, 50);
  }

  // ===== TAB SWITCHING =====
  function switchTab(tab, btn) {
    document.querySelectorAll('.wc-tab-btn').forEach(function(b) { b.classList.remove('active'); });
    btn.classList.add('active');
    if (tab === 'rendered') { $('wc-renderedOutput').style.display = 'block'; $('wc-rawOutput').style.display = 'none'; }
    else { $('wc-renderedOutput').style.display = 'none'; $('wc-rawOutput').style.display = 'block'; }
  }

  // ===== ACTIONS =====
  function showRawModal() {
    if (!currentMD) { toast('Nothing to show yet!'); return; }
    $('wc-modalContent').textContent = currentMD;
    var lines = currentMD.split('\n');
    $('wc-lineNumbers').innerHTML = lines.map(function(_, i) { return i + 1; }).join('<br>');
    $('wc-rawModal').classList.add('active');
  }
  function closeRawModal() { $('wc-rawModal').classList.remove('active'); }
  function copyToClipboard() {
    if (!currentMD) { toast('Nothing to copy!'); return; }
    try {
      navigator.clipboard.writeText(currentMD).then(function() { toast('Copied!'); }).catch(function() { copyFallback(); });
    } catch (e) { copyFallback(); }
  }
  function copyFallback() {
    var ta = document.createElement('textarea');
    ta.value = currentMD; document.body.appendChild(ta); ta.select();
    document.execCommand('copy'); document.body.removeChild(ta);
    toast('Copied!');
  }
  function downloadMD() {
    if (!currentMD) { toast('Nothing to download!'); return; }
    var fn = currentFile || 'web-clip-' + fmtDate(new Date()) + '.md';
    var blob = new Blob([currentMD], { type: 'text/markdown;charset=utf-8' });
    var url = URL.createObjectURL(blob);
    var a = document.createElement('a');
    a.href = url; a.download = fn; document.body.appendChild(a); a.click();
    document.body.removeChild(a); URL.revokeObjectURL(url);
    toast('Downloaded ' + fn);
  }
  function clearAll() {
    $('wc-inputArea').value = '';
    $('wc-filenameDisplay').textContent = '';
    currentFile = ''; currentMD = ''; currentTitle = 'Web Clip';
    $('wc-rawArea').textContent = '';
    $('wc-previewArea').innerHTML = '';
    $('wc-previewArea').style.display = 'none';
    $('wc-emptyState').style.display = 'flex';
    setStats('', '');
    setStatus('\u2014', 'Waiting');
  }

  // ===== FILE HANDLING =====
  function handleFile(file) {
    currentFile = file.name;
    $('wc-filenameDisplay').textContent = file.name;
    var reader = new FileReader();
    reader.onload = function(e) {
      $('wc-inputArea').value = e.target.result;
      setStats(e.target.result);
      setTimeout(doConvert, 100);
    };
    reader.readAsText(file);
  }

  // ===== EVENT WIRING =====
  document.addEventListener('DOMContentLoaded', function() {
    $('wc-convertBtn').addEventListener('click', doConvert);
    $('wc-clearBtn').addEventListener('click', clearAll);
    $('wc-viewRawBtn').addEventListener('click', showRawModal);
    $('wc-copyBtn').addEventListener('click', copyToClipboard);
    $('wc-downloadBtn').addEventListener('click', downloadMD);
    $('wc-modalClose').addEventListener('click', closeRawModal);
    $('wc-rawModal').addEventListener('click', function(e) { if (e.target === $('wc-rawModal')) closeRawModal(); });

    document.querySelectorAll('.wc-tab-btn').forEach(function(btn) {
      btn.addEventListener('click', function() { switchTab(this.dataset.tab, this); });
    });

    var fileInput = $('wc-fileInput');
    fileInput.addEventListener('change', function(e) {
      if (e.target.files.length > 0) handleFile(e.target.files[0]);
      e.target.value = '';
    });
    $('wc-dropZone').addEventListener('click', function() { fileInput.click(); });

    var inputPanel = $('wc-inputPanel');
    var dragOverlay = $('wc-dragOverlay');
    ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(function(ev) {
      inputPanel.addEventListener(ev, function(e) { e.preventDefault(); e.stopPropagation(); });
    });
    inputPanel.addEventListener('dragenter', function() { dragOverlay.classList.add('active'); });
    inputPanel.addEventListener('dragleave', function(e) { if (e.target === dragOverlay || e.target === inputPanel) dragOverlay.classList.remove('active'); });
    inputPanel.addEventListener('drop', function(e) {
      dragOverlay.classList.remove('active');
      var files = e.dataTransfer.files;
      if (files.length > 0) handleFile(files[0]);
    });

    var inputArea = $('wc-inputArea');
    inputArea.addEventListener('input', debounce(function() {
      setStats(this.value);
      if (this.value.trim()) setTimeout(doConvert, 300);
    }, 200));

    inputArea.addEventListener('paste', function(e) {
      var html = '';
      try { html = e.clipboardData.getData('text/html'); } catch (err) {}
      if (html && html.trim() && html[0] === '<') {
        e.preventDefault();
        var start = this.selectionStart, before = this.value.substring(0, start), after = this.value.substring(this.selectionEnd);
        this.value = before + html + after;
        this.selectionStart = this.selectionEnd = start + html.length;
      }
      setTimeout(function() { setStats(inputArea.value); setTimeout(doConvert, 200); }, 50);
    });

    document.addEventListener('keydown', function(e) {
      var t = e.target;
      if (!t.closest || !t.closest('.wc-wrap')) return;
      if ((e.ctrlKey || e.metaKey) && e.key === 'Enter') { e.preventDefault(); doConvert(); }
      if (e.key === 'Escape') closeRawModal();
    });

    setStats('', '');
  });
})();""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
