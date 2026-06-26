module ConvertedFiles.IndexHtml.Tools

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Omni-Suite | Developer Tools Dashboard"
            ]
            style [] [
                    rawText ("""/* ============================================================
   OMNISUITE v1.0 - Unified Developer Tools Dashboard
   Integrates: Omni-Tools, CyberChef, Webcrack, JS-Obfuscator
   ============================================================ */

*, *::before, *::after { margin:0; padding:0; box-sizing:border-box; }

:root {
  --bg: #0c0c14;
  --bg2: #12121e;
  --bg3: #1a1a2c;
  --surface: rgba(255,255,255,0.04);
  --surface-hover: rgba(255,255,255,0.08);
  --accent: #6366f1;
  --accent2: #8b5cf6;
  --accent3: #ec4899;
  --success: #22c55e;
  --warning: #f59e0b;
  --danger: #ef4444;
  --info: #3b82f6;
  --text: #e2e8f0;
  --text2: #94a3b8;
  --text3: #64748b;
  --border: rgba(255,255,255,0.06);
  --glass: rgba(18,18,30,0.85);
  --glow: rgba(99,102,241,0.25);
  --radius: 12px;
  --shadow: 0 4px 20px rgba(0,0,0,0.3);
}

html, body { width:100%; height:100%; font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, sans-serif; background:var(--bg); color:var(--text); overflow-x:hidden; }

/* ---- Background ---- */
.bg { position:fixed; inset:0; z-index:0; pointer-events:none; }
.bg::before { content:""; position:absolute; inset:0; background:radial-gradient(ellipse at 20% 50%, rgba(99,102,241,0.06), transparent 60%), radial-gradient(ellipse at 80% 20%, rgba(236,72,153,0.04), transparent 50%), radial-gradient(ellipse at 50% 100%, rgba(139,92,246,0.04), transparent 50%); }
.bg-grid { position:absolute; inset:0; background-image:linear-gradient(rgba(99,102,241,0.015) 1px, transparent 1px), linear-gradient(90deg, rgba(99,102,241,0.015) 1px, transparent 1px); background-size:50px 50px; }

.app { position:relative; z-index:2; display:flex; min-height:100vh; }

/* ---- Sidebar ---- */
.sidebar { width:240px; background:var(--glass); backdrop-filter:blur(30px); border-right:1px solid var(--border); display:flex; flex-direction:column; position:fixed; top:0; bottom:0; left:0; z-index:100; overflow-y:auto; transition:transform 0.3s; }
.sidebar::-webkit-scrollbar { width:3px; }
.sidebar::-webkit-scrollbar-thumb { background:rgba(255,255,255,0.08); border-radius:3px; }

.sb-header { padding:20px 16px 12px; border-bottom:1px solid var(--border); }
.sb-logo { display:flex; align-items:center; gap:10px; margin-bottom:4px; }
.sb-icon { width:34px; height:34px; border-radius:10px; background:linear-gradient(135deg, var(--accent), var(--accent3)); display:flex; align-items:center; justify-content:center; font-size:16px; box-shadow:0 2px 10px var(--glow); }
.sb-title { font-size:16px; font-weight:700; letter-spacing:-0.3px; }
.sb-version { font-size:10px; color:var(--text3); text-transform:uppercase; letter-spacing:1px; }

.sb-search { padding:12px 16px; }
.sb-search input { width:100%; background:var(--surface); border:1px solid var(--border); border-radius:8px; padding:8px 12px; color:var(--text); font-size:12px; outline:none; transition:all 0.2s; }
.sb-search input:focus { border-color:var(--accent); background:var(--surface-hover); }
.sb-search input::placeholder { color:var(--text3); }

.sb-nav { padding:0 8px 12px; display:flex; flex-direction:column; gap:2px; flex:1; }
.nav-btn { display:flex; align-items:center; gap:10px; padding:8px 12px; border-radius:8px; border:none; background:transparent; color:var(--text2); font-size:12px; cursor:pointer; transition:all 0.15s; text-align:left; font-family:inherit; }
.nav-btn:hover { background:var(--surface-hover); color:var(--text); }
.nav-btn.active { background:linear-gradient(135deg, rgba(99,102,241,0.2), rgba(139,92,246,0.15)); color:var(--text); border:1px solid rgba(99,102,241,0.2); }
.nav-icon { font-size:16px; width:20px; text-align:center; }
.nav-text { font-weight:500; }

.sb-external { padding:12px 16px; border-top:1px solid var(--border); display:flex; flex-direction:column; gap:6px; }
.sb-ext-title { font-size:9px; color:var(--text3); text-transform:uppercase; letter-spacing:1.5px; font-weight:600; padding:0 8px; margin-bottom:2px; }
.ext-link { display:flex; align-items:center; gap:10px; padding:8px 12px; border-radius:8px; color:var(--text2); font-size:12px; text-decoration:none; transition:all 0.15s; cursor:pointer; border:none; background:transparent; font-family:inherit; }
.ext-link:hover { background:var(--surface-hover); color:var(--text); }
.ext-link.active { background:linear-gradient(135deg, rgba(236,72,153,0.15), rgba(99,102,241,0.1)); color:#fff; border:1px solid rgba(236,72,153,0.2); }
.ext-icon { font-size:16px; width:20px; text-align:center; }

/* ---- Main Content ---- */
.main { flex:1; margin-left:240px; display:flex; flex-direction:column; min-height:100vh; }

/* Top bar */
.topbar { display:flex; align-items:center; justify-content:space-between; padding:16px 28px; border-bottom:1px solid var(--border); background:rgba(12,12,20,0.8); backdrop-filter:blur(20px); position:sticky; top:0; z-index:50; }
.top-search { flex:1; max-width:400px; }
.top-search input { width:100%; background:var(--surface); border:1px solid var(--border); border-radius:10px; padding:10px 16px 10px 36px; color:var(--text); font-size:13px; outline:none; transition:all 0.2s; background-image:url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='14' height='14' fill='%2364748b' viewBox='0 0 16 16'%3E%3Cpath d='M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z'/%3E%3C/svg%3E"); background-repeat:no-repeat; background-position:12px center; }
.top-search input:focus { border-color:var(--accent); }
.top-search input::placeholder { color:var(--text3); }
.top-actions { display:flex; gap:8px; }
.top-btn { background:var(--surface); border:1px solid var(--border); color:var(--text2); border-radius:8px; padding:8px 14px; font-size:12px; cursor:pointer; transition:all 0.2s; }
.top-btn:hover { background:var(--surface-hover); color:var(--text); }

/* Content area */
.content { flex:1; padding:24px 28px; }

/* Section titles */
.section-title { font-size:22px; font-weight:700; margin-bottom:6px; display:flex; align-items:center; gap:10px; }
.section-sub { font-size:13px; color:var(--text2); margin-bottom:20px; }

/* Category sections */
.cat-section { margin-bottom:28px; }
.cat-header { display:flex; align-items:center; gap:10px; margin-bottom:14px; padding-bottom:10px; border-bottom:1px solid var(--border); }
.cat-icon { font-size:22px; }
.cat-title { font-size:16px; font-weight:600; }
.cat-count { margin-left:auto; background:var(--surface); color:var(--text2); font-size:11px; padding:3px 10px; border-radius:20px; font-weight:600; }

/* Tool grid */
.tool-grid { display:grid; grid-template-columns:repeat(auto-fill, minmax(200px, 1fr)); gap:10px; }
.tool-card { background:var(--surface); border:1px solid var(--border); border-radius:var(--radius); padding:14px 16px; text-decoration:none; color:var(--text); transition:all 0.2s; display:flex; flex-direction:column; gap:4px; cursor:pointer; }
.tool-card:hover { background:var(--surface-hover); border-color:rgba(99,102,241,0.3); transform:translateY(-2px); box-shadow:var(--shadow); }
.tool-card.hidden { display:none; }
.tool-name { font-size:13px; font-weight:600; color:var(--text); }
.tool-desc { font-size:11px; color:var(--text2); line-height:1.4; }

/* External tool embeds */
.embed-frame { width:100%; height:70vh; border:1px solid var(--border); border-radius:var(--radius); background:var(--bg2); }
.embed-section { display:none; }
.embed-section.active { display:block; animation:fadeIn 0.3s ease; }
@keyframes fadeIn { from{opacity:0;transform:translateY(8px)} to{opacity:1;transform:translateY(0)} }

.embed-bar { display:flex; align-items:center; justify-content:space-between; margin-bottom:12px; }
.embed-title { font-size:16px; font-weight:600; }
.embed-actions { display:flex; gap:8px; }

/* Code playground (for obfuscator) */
.code-area { display:grid; grid-template-columns:1fr 1fr; gap:16px; margin-top:16px; }
.code-panel { background:var(--bg3); border:1px solid var(--border); border-radius:var(--radius); overflow:hidden; display:flex; flex-direction:column; }
.code-header { display:flex; align-items:center; justify-content:space-between; padding:10px 14px; background:rgba(255,255,255,0.02); border-bottom:1px solid var(--border); }
.code-label { font-size:11px; font-weight:600; color:var(--text2); text-transform:uppercase; letter-spacing:0.5px; }
.code-actions { display:flex; gap:6px; }
.code-btn { background:var(--surface); border:1px solid var(--border); color:var(--text2); border-radius:6px; padding:4px 10px; font-size:11px; cursor:pointer; transition:all 0.15s; }
.code-btn:hover { background:var(--surface-hover); color:var(--text); }
.code-btn.primary { background:var(--accent); color:#fff; border-color:var(--accent); }
.code-btn.primary:hover { opacity:0.9; }
textarea.code-input { width:100%; flex:1; min-height:300px; background:transparent; border:none; color:var(--text); font-family:"Fira Code", "Consolas", monospace; font-size:12px; line-height:1.6; padding:14px; outline:none; resize:none; }
.code-options { display:grid; grid-template-columns:repeat(auto-fill, minmax(180px, 1fr)); gap:8px; margin-bottom:16px; }
.opt-row { display:flex; align-items:center; justify-content:space-between; background:var(--surface); border:1px solid var(--border); border-radius:8px; padding:8px 12px; font-size:12px; }
.opt-label { color:var(--text2); }

/* Toggle switch */
.tog { width:36px; height:20px; background:rgba(255,255,255,0.12); border-radius:10px; position:relative; cursor:pointer; transition:background 0.2s; flex-shrink:0; }
.tog::after { content:""; position:absolute; width:16px; height:16px; background:#fff; border-radius:50%; top:2px; left:2px; transition:transform 0.2s; }
.tog.on { background:var(--accent); }
.tog.on::after { transform:translateX(16px); }

/* Footer */
.footer { padding:16px 28px; border-top:1px solid var(--border); font-size:11px; color:var(--text3); text-align:center; }

/* Mobile */
.menu-toggle { display:none; position:fixed; top:14px; left:14px; z-index:200; width:36px; height:36px; background:var(--glass); border:1px solid var(--border); border-radius:8px; color:var(--text); font-size:18px; cursor:pointer; align-items:center; justify-content:center; backdrop-filter:blur(20px); }
@media(max-width:900px) {
  .menu-toggle { display:flex; }
  .sidebar { transform:translateX(-100%); z-index:150; }
  .sidebar.open { transform:translateX(0); }
  .main { margin-left:0; }
  .tool-grid { grid-template-columns:repeat(auto-fill, minmax(160px, 1fr)); }
  .code-area { grid-template-columns:1fr; }
  .topbar { padding:12px 16px; padding-left:56px; }
  .content { padding:16px; }
}""")
            ]
        ]
        body [] [
            div [ _class "bg" ] [
                div [ _class "bg-grid" ] []
            ]
            button [ _class "menu-toggle"; _id "menuToggle" ] [
                str "☰"
            ]
            div [ _class "app" ] [
                rawText ("""<!--  Sidebar  -->""")
                nav [ _class "sidebar"; _id "sidebar" ] [
                    div [ _class "sb-header" ] [
                        div [ _class "sb-logo" ] [
                            div [ _class "sb-icon" ] [
                                str "⚡"
                            ]
                            div [] [
                                div [ _class "sb-title" ] [
                                    str "OmniSuite"
                                ]
                                div [ _class "sb-version" ] [
                                    str "v1.0 Unified"
                                ]
                            ]
                        ]
                    ]
                    div [ _class "sb-search" ] [
                        input [ _type "text"; _id "sbSearch"; attr "placeholder" "Search tools..." ]
                    ]
                    div [ _class "sb-nav"; _id "sbNav" ] [
                        button [ _class "nav-btn"; attr "data-target" "cat-audio" ] [
                            span [ _class "nav-icon" ] [
                                str "🎵"
                            ]
                            span [ _class "nav-text" ] [
                                str "Audio"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-converters" ] [
                            span [ _class "nav-icon" ] [
                                str "🔄"
                            ]
                            span [ _class "nav-text" ] [
                                str "Converters"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-csv" ] [
                            span [ _class "nav-icon" ] [
                                str "📊"
                            ]
                            span [ _class "nav-text" ] [
                                str "CSV"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-json" ] [
                            span [ _class "nav-icon" ] [
                                str "{}"
                            ]
                            span [ _class "nav-text" ] [
                                str "JSON"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-list" ] [
                            span [ _class "nav-icon" ] [
                                str "☰"
                            ]
                            span [ _class "nav-text" ] [
                                str "List"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-number" ] [
                            span [ _class "nav-icon" ] [
                                str "#"
                            ]
                            span [ _class "nav-text" ] [
                                str "Number"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-pdf" ] [
                            span [ _class "nav-icon" ] [
                                str "📄"
                            ]
                            span [ _class "nav-text" ] [
                                str "PDF"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-string" ] [
                            span [ _class "nav-icon" ] [
                                str "📝"
                            ]
                            span [ _class "nav-text" ] [
                                str "String"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-time" ] [
                            span [ _class "nav-icon" ] [
                                str "⏰"
                            ]
                            span [ _class "nav-text" ] [
                                str "Time"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-video" ] [
                            span [ _class "nav-icon" ] [
                                str "🎥"
                            ]
                            span [ _class "nav-text" ] [
                                str "Video"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-xml" ] [
                            span [ _class "nav-icon" ] [
                                str "</>"
                            ]
                            span [ _class "nav-text" ] [
                                str "XML"
                            ]
                        ]
                        button [ _class "nav-btn"; attr "data-target" "cat-image" ] [
                            span [ _class "nav-icon" ] [
                                str "🎨"
                            ]
                            span [ _class "nav-text" ] [
                                str "Image"
                            ]
                        ]
                    ]
                    div [ _class "sb-external" ] [
                        div [ _class "sb-ext-title" ] [
                            str "External Tools"
                        ]
                        button [ _class "ext-link"; attr "data-tool" "cyberchef" ] [
                            span [ _class "ext-icon" ] [
                                str "🏃"
                            ]
                            str "CyberChef"
                        ]
                        button [ _class "ext-link"; attr "data-tool" "webcrack" ] [
                            span [ _class "ext-icon" ] [
                                str "🔓"
                            ]
                            str "Webcrack"
                        ]
                        button [ _class "ext-link"; attr "data-tool" "obfuscator" ] [
                            span [ _class "ext-icon" ] [
                                str "🔏"
                            ]
                            str "JS Obfuscator"
                        ]
                        div [ _class "sb-ext-title"; attr "style" "margin-top:8px" ] [
                            str "Dev Tools"
                        ]
                        button [ _class "ext-link"; attr "data-tool" "webcrack-ui" ] [
                            span [ _class "ext-icon" ] [
                                str "💻"
                            ]
                            str "Webcrack UI"
                        ]
                    ]
                ]
                rawText ("""<!--  Main  -->""")
                div [ _class "main" ] [
                    div [ _class "topbar" ] [
                        div [ _class "top-search" ] [
                            input [ _type "text"; _id "topSearch"; attr "placeholder" "Search all 107 tools..." ]
                        ]
                        div [ _class "top-actions" ] [
                            button [ _class "top-btn"; _id "btnHome"; attr "title" "Show all tools" ] [
                                str "🏠 All Tools"
                            ]
                            button [ _class "top-btn"; _id "btnIframe"; attr "title" "Toggle embed mode" ] [
                                str "🔎 Embed"
                            ]
                        ]
                    ]
                    div [ _class "content"; _id "mainContent" ] [
                        rawText ("""<!--  Omni-Tools Section  -->""")
                        div [ _id "toolsSection"; _class "embed-section active" ] [
                            div [ _class "section-title" ] [
                                str "🔧 Omni-Tools"
                                span [ attr "style" "font-size:13px;color:var(--text3);font-weight:400" ] [
                                    str "107 tools across 12 categories"
                                ]
                            ]
                            div [ _class "section-sub" ] [
                                str "Click any tool to open it on the omni-tools GitHub Pages. All tools run client-side."
                            ]
                            div [ _class "cat-section"; _id "cat-audio" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "🎵"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "Audio"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "4"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/audio/change-speed"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "change speed adjust audio playback speed" ] [
                                        div [ _class "tool-name" ] [
                                            str "Change Speed"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Adjust audio playback speed"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/audio/extract-audio"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "extract audio extract audio from video files" ] [
                                        div [ _class "tool-name" ] [
                                            str "Extract Audio"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Extract audio from video files"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/audio/merge-audio"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "merge audio combine multiple audio files" ] [
                                        div [ _class "tool-name" ] [
                                            str "Merge Audio"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Combine multiple audio files"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/audio/trim"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "trim audio cut audio to desired length" ] [
                                        div [ _class "tool-name" ] [
                                            str "Trim Audio"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Cut audio to desired length"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-converters" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "🔄"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "Converters"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "3"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/converters/audio-converter"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "audio converter convert between audio formats" ] [
                                        div [ _class "tool-name" ] [
                                            str "Audio Converter"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert between audio formats"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/converters/convert-to-jpg"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "convert to jpg convert images to jpeg format" ] [
                                        div [ _class "tool-name" ] [
                                            str "Convert to JPG"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert images to JPEG format"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/converters/convert-to-webp"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "convert to webp convert images to webp format" ] [
                                        div [ _class "tool-name" ] [
                                            str "Convert to WebP"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert images to WebP format"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-csv" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "📊"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "CSV"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "11"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/change-csv-separator"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "change csv separator change delimiter in csv files" ] [
                                        div [ _class "tool-name" ] [
                                            str "Change CSV Separator"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Change delimiter in CSV files"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/csv-rows-to-columns"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "rows to columns transform csv rows into columns" ] [
                                        div [ _class "tool-name" ] [
                                            str "Rows to Columns"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Transform CSV rows into columns"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/csv-to-json"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "csv to json convert csv data to json format" ] [
                                        div [ _class "tool-name" ] [
                                            str "CSV to JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert CSV data to JSON format"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/csv-to-tsv"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "csv to tsv convert csv to tab-separated values" ] [
                                        div [ _class "tool-name" ] [
                                            str "CSV to TSV"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert CSV to tab-separated values"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/csv-to-xml"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "csv to xml convert csv data to xml format" ] [
                                        div [ _class "tool-name" ] [
                                            str "CSV to XML"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert CSV data to XML format"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/csv-to-yaml"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "csv to yaml convert csv data to yaml format" ] [
                                        div [ _class "tool-name" ] [
                                            str "CSV to YAML"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert CSV data to YAML format"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/find-incomplete-csv-records"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "find incomplete records locate missing csv fields" ] [
                                        div [ _class "tool-name" ] [
                                            str "Find Incomplete Records"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Locate missing CSV fields"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/insert-csv-columns"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "insert columns add columns to csv data" ] [
                                        div [ _class "tool-name" ] [
                                            str "Insert Columns"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Add columns to CSV data"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/swap-csv-columns"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "swap columns exchange csv column positions" ] [
                                        div [ _class "tool-name" ] [
                                            str "Swap Columns"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Exchange CSV column positions"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/transpose-csv"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "transpose csv flip rows and columns in csv" ] [
                                        div [ _class "tool-name" ] [
                                            str "Transpose CSV"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Flip rows and columns in CSV"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/csv/tsv-to-json"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "tsv to json convert tsv to json format" ] [
                                        div [ _class "tool-name" ] [
                                            str "TSV to JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert TSV to JSON format"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-json" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "{}"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "JSON"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "9"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/json/escape-json"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "escape json escape json special characters" ] [
                                        div [ _class "tool-name" ] [
                                            str "Escape JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Escape JSON special characters"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/json/json-comparison"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "json comparison compare two json objects" ] [
                                        div [ _class "tool-name" ] [
                                            str "JSON Comparison"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Compare two JSON objects"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/json/json-to-csv"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "json to csv convert json to csv format" ] [
                                        div [ _class "tool-name" ] [
                                            str "JSON to CSV"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert JSON to CSV format"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/json/json-to-xml"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "json to xml convert json to xml format" ] [
                                        div [ _class "tool-name" ] [
                                            str "JSON to XML"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert JSON to XML format"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/json/minify"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "minify json compress json by removing whitespace" ] [
                                        div [ _class "tool-name" ] [
                                            str "Minify JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Compress JSON by removing whitespace"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/json/prettify"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "prettify json format json with indentation" ] [
                                        div [ _class "tool-name" ] [
                                            str "Prettify JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Format JSON with indentation"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/json/sort"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "sort json sort json keys alphabetically" ] [
                                        div [ _class "tool-name" ] [
                                            str "Sort JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Sort JSON keys alphabetically"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/json/stringify"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "stringify json convert object to json string" ] [
                                        div [ _class "tool-name" ] [
                                            str "Stringify JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert object to JSON string"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/json/validateJson"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "validate json check json syntax validity" ] [
                                        div [ _class "tool-name" ] [
                                            str "Validate JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Check JSON syntax validity"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-list" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "☰"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "List"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "11"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/duplicate"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "duplicate remover remove duplicate items from list" ] [
                                        div [ _class "tool-name" ] [
                                            str "Duplicate Remover"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Remove duplicate items from list"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/find-most-popular"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "most popular find most frequent list items" ] [
                                        div [ _class "tool-name" ] [
                                            str "Most Popular"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Find most frequent list items"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/find-unique"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "find unique extract unique items from list" ] [
                                        div [ _class "tool-name" ] [
                                            str "Find Unique"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Extract unique items from list"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/group"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "group/chunk split list into groups" ] [
                                        div [ _class "tool-name" ] [
                                            str "Group/Chunk"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Split list into groups"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/reverse"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "reverse list reverse item order in list" ] [
                                        div [ _class "tool-name" ] [
                                            str "Reverse List"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Reverse item order in list"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/rotate"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "rotate list rotate list items" ] [
                                        div [ _class "tool-name" ] [
                                            str "Rotate List"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Rotate list items"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/shuffle"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "shuffle list randomize list item order" ] [
                                        div [ _class "tool-name" ] [
                                            str "Shuffle List"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Randomize list item order"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/sort"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "sort list alphabetically sort list items" ] [
                                        div [ _class "tool-name" ] [
                                            str "Sort List"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Alphabetically sort list items"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/truncate"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "truncate list limit list to n items" ] [
                                        div [ _class "tool-name" ] [
                                            str "Truncate List"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Limit list to N items"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/unwrap"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "unwrap list flatten nested list structure" ] [
                                        div [ _class "tool-name" ] [
                                            str "Unwrap List"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Flatten nested list structure"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/list/wrap"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "wrap list group items with prefix/suffix" ] [
                                        div [ _class "tool-name" ] [
                                            str "Wrap List"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Group items with prefix/suffix"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-number" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "#"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "Number"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "7"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/number/arithmetic-sequence"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "arithmetic sequence generate number sequences" ] [
                                        div [ _class "tool-name" ] [
                                            str "Arithmetic Sequence"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Generate number sequences"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/number/byte-converter"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "byte converter convert between data size units" ] [
                                        div [ _class "tool-name" ] [
                                            str "Byte Converter"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert between data size units"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/number/generate"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "number generator generate random numbers" ] [
                                        div [ _class "tool-name" ] [
                                            str "Number Generator"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Generate random numbers"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/number/generic-calc"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "calculator basic arithmetic calculator" ] [
                                        div [ _class "tool-name" ] [
                                            str "Calculator"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Basic arithmetic calculator"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/number/random-number-generator"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "random number generate random integers" ] [
                                        div [ _class "tool-name" ] [
                                            str "Random Number"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Generate random integers"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/number/random-port-generator"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "random port generate random network ports" ] [
                                        div [ _class "tool-name" ] [
                                            str "Random Port"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Generate random network ports"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/number/sum"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "sum calculator calculate sum of numbers" ] [
                                        div [ _class "tool-name" ] [
                                            str "Sum Calculator"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Calculate sum of numbers"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-pdf" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "📄"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "PDF"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "10"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/compress-pdf"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "compress pdf reduce pdf file size" ] [
                                        div [ _class "tool-name" ] [
                                            str "Compress PDF"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Reduce PDF file size"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/convert-to-pdf"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "convert to pdf convert files to pdf format" ] [
                                        div [ _class "tool-name" ] [
                                            str "Convert to PDF"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert files to PDF format"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/editor"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "pdf editor edit pdf document content" ] [
                                        div [ _class "tool-name" ] [
                                            str "PDF Editor"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Edit PDF document content"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/extract-images-from-pdf"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "extract images pull images from pdf files" ] [
                                        div [ _class "tool-name" ] [
                                            str "Extract Images"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Pull images from PDF files"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/merge-pdf"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "merge pdf combine multiple pdfs into one" ] [
                                        div [ _class "tool-name" ] [
                                            str "Merge PDF"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Combine multiple PDFs into one"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/pdf-to-epub"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "pdf to epub convert pdf to e-book format" ] [
                                        div [ _class "tool-name" ] [
                                            str "PDF to EPUB"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert PDF to e-book format"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/pdf-to-png"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "pdf to png convert pdf pages to images" ] [
                                        div [ _class "tool-name" ] [
                                            str "PDF to PNG"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert PDF pages to images"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/protect-pdf"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "protect pdf add password to pdf" ] [
                                        div [ _class "tool-name" ] [
                                            str "Protect PDF"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Add password to PDF"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/rotate-pdf"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "rotate pdf rotate pdf pages" ] [
                                        div [ _class "tool-name" ] [
                                            str "Rotate PDF"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Rotate PDF pages"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/pdf/split-pdf"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "split pdf separate pdf into pages" ] [
                                        div [ _class "tool-name" ] [
                                            str "Split PDF"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Separate PDF into pages"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-string" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "📝"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "String"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "20"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/base64"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "base64 encode/decode convert text to/from base64" ] [
                                        div [ _class "tool-name" ] [
                                            str "Base64 Encode/Decode"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert text to/from Base64"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/censor"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "text censor redact sensitive words from text" ] [
                                        div [ _class "tool-name" ] [
                                            str "Text Censor"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Redact sensitive words from text"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/create-palindrome"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "create palindrome generate palindrome strings" ] [
                                        div [ _class "tool-name" ] [
                                            str "Create Palindrome"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Generate palindrome strings"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/extract-substring"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "extract substring pull text between markers" ] [
                                        div [ _class "tool-name" ] [
                                            str "Extract Substring"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Pull text between markers"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/hidden-character-detector"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "hidden char detector find invisible unicode chars" ] [
                                        div [ _class "tool-name" ] [
                                            str "Hidden Char Detector"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Find invisible Unicode chars"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/join"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "join text combine lines with separator" ] [
                                        div [ _class "tool-name" ] [
                                            str "Join Text"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Combine lines with separator"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/palindrome"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "check palindrome verify if text is palindrome" ] [
                                        div [ _class "tool-name" ] [
                                            str "Check Palindrome"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Verify if text is palindrome"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/password-generator"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "password generator create secure passwords" ] [
                                        div [ _class "tool-name" ] [
                                            str "Password Generator"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Create secure passwords"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/quote"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "quote text add quotation marks to text" ] [
                                        div [ _class "tool-name" ] [
                                            str "Quote Text"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Add quotation marks to text"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/randomize-case"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "random case randomize letter capitalization" ] [
                                        div [ _class "tool-name" ] [
                                            str "Random Case"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Randomize letter capitalization"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/remove-duplicate-lines"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "remove duplicates delete repeated lines" ] [
                                        div [ _class "tool-name" ] [
                                            str "Remove Duplicates"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Delete repeated lines"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/repeat"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "repeat text duplicate text n times" ] [
                                        div [ _class "tool-name" ] [
                                            str "Repeat Text"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Duplicate text N times"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/reverse"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "reverse text flip text backwards" ] [
                                        div [ _class "tool-name" ] [
                                            str "Reverse Text"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Flip text backwards"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/rot13"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "rot13 cipher simple letter substitution cipher" ] [
                                        div [ _class "tool-name" ] [
                                            str "ROT13 Cipher"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Simple letter substitution cipher"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/rotate"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "rotate text shift text characters" ] [
                                        div [ _class "tool-name" ] [
                                            str "Rotate Text"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Shift text characters"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/slug-generator"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "slug generator create url-friendly slugs" ] [
                                        div [ _class "tool-name" ] [
                                            str "Slug Generator"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Create URL-friendly slugs"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/split"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "split text divide text by delimiter" ] [
                                        div [ _class "tool-name" ] [
                                            str "Split Text"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Divide text by delimiter"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/trim"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "trim text remove leading/trailing whitespace" ] [
                                        div [ _class "tool-name" ] [
                                            str "Trim Text"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Remove leading/trailing whitespace"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/truncate"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "truncate text limit text length" ] [
                                        div [ _class "tool-name" ] [
                                            str "Truncate Text"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Limit text length"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/string/yaml-to-json"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "yaml to json convert yaml to json" ] [
                                        div [ _class "tool-name" ] [
                                            str "YAML to JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert YAML to JSON"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-time" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "⏰"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "Time"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "7"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/time/add-to-date"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "add to date add time to a date" ] [
                                        div [ _class "tool-name" ] [
                                            str "Add to Date"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Add time to a date"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/time/countdown"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "countdown timer calculate time remaining" ] [
                                        div [ _class "tool-name" ] [
                                            str "Countdown Timer"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Calculate time remaining"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/time/date-difference"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "date difference find time between dates" ] [
                                        div [ _class "tool-name" ] [
                                            str "Date Difference"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Find time between dates"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/time/stopwatch"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "stopwatch track elapsed time" ] [
                                        div [ _class "tool-name" ] [
                                            str "Stopwatch"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Track elapsed time"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/time/timestamp-to-date"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "timestamp to date convert unix timestamp" ] [
                                        div [ _class "tool-name" ] [
                                            str "Timestamp to Date"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert Unix timestamp"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/time/timezone-converter"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "timezone converter convert between timezones" ] [
                                        div [ _class "tool-name" ] [
                                            str "Timezone Converter"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert between timezones"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/time/unix-timestamp"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "unix timestamp get current unix timestamp" ] [
                                        div [ _class "tool-name" ] [
                                            str "Unix Timestamp"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Get current Unix timestamp"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-video" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "🎥"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "Video"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "10"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/change-resolution"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "change resolution resize video dimensions" ] [
                                        div [ _class "tool-name" ] [
                                            str "Change Resolution"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Resize video dimensions"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/compress-video"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "compress video reduce video file size" ] [
                                        div [ _class "tool-name" ] [
                                            str "Compress Video"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Reduce video file size"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/cut-video"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "cut video trim video segments" ] [
                                        div [ _class "tool-name" ] [
                                            str "Cut Video"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Trim video segments"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/extract-frames"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "extract frames pull frames from video" ] [
                                        div [ _class "tool-name" ] [
                                            str "Extract Frames"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Pull frames from video"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/merge-video"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "merge video combine video files" ] [
                                        div [ _class "tool-name" ] [
                                            str "Merge Video"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Combine video files"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/remove-background"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "remove background ai background removal" ] [
                                        div [ _class "tool-name" ] [
                                            str "Remove Background"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "AI background removal"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/rotate-video"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "rotate video rotate video orientation" ] [
                                        div [ _class "tool-name" ] [
                                            str "Rotate Video"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Rotate video orientation"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/speed-video"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "speed change adjust video playback speed" ] [
                                        div [ _class "tool-name" ] [
                                            str "Speed Change"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Adjust video playback speed"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/watermark-video"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "add watermark overlay text on video" ] [
                                        div [ _class "tool-name" ] [
                                            str "Add Watermark"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Overlay text on video"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/video/webcam-recorder"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "webcam recorder record from webcam" ] [
                                        div [ _class "tool-name" ] [
                                            str "Webcam Recorder"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Record from webcam"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-xml" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "</>"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "XML"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "2"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/xml/json-to-xml"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "json to xml convert json to xml" ] [
                                        div [ _class "tool-name" ] [
                                            str "JSON to XML"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert JSON to XML"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/xml/xml-to-json"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "xml to json convert xml to json format" ] [
                                        div [ _class "tool-name" ] [
                                            str "XML to JSON"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Convert XML to JSON format"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "cat-section"; _id "cat-image" ] [
                                div [ _class "cat-header" ] [
                                    span [ _class "cat-icon" ] [
                                        str "🎨"
                                    ]
                                    span [ _class "cat-title" ] [
                                        str "Image"
                                    ]
                                    span [ _class "cat-count" ] [
                                        str "13"
                                    ]
                                ]
                                div [ _class "tool-grid" ] [
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/add-noise"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "add noise add noise to images" ] [
                                        div [ _class "tool-name" ] [
                                            str "Add Noise"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Add noise to images"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/blur"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "blur image apply blur effect" ] [
                                        div [ _class "tool-name" ] [
                                            str "Blur Image"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Apply blur effect"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/brightness"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "adjust brightness change image brightness" ] [
                                        div [ _class "tool-name" ] [
                                            str "Adjust Brightness"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Change image brightness"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/compress"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "compress image reduce image file size" ] [
                                        div [ _class "tool-name" ] [
                                            str "Compress Image"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Reduce image file size"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/convert"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "convert format change image format" ] [
                                        div [ _class "tool-name" ] [
                                            str "Convert Format"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Change image format"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/crop"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "crop image cut image region" ] [
                                        div [ _class "tool-name" ] [
                                            str "Crop Image"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Cut image region"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/filter"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "apply filter photo filters and effects" ] [
                                        div [ _class "tool-name" ] [
                                            str "Apply Filter"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Photo filters and effects"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/flip"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "flip image mirror image horizontally" ] [
                                        div [ _class "tool-name" ] [
                                            str "Flip Image"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Mirror image horizontally"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/gif-maker"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "gif maker create animated gifs" ] [
                                        div [ _class "tool-name" ] [
                                            str "GIF Maker"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Create animated GIFs"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/invert"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "invert colors negative image effect" ] [
                                        div [ _class "tool-name" ] [
                                            str "Invert Colors"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Negative image effect"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/resize"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "resize image change image dimensions" ] [
                                        div [ _class "tool-name" ] [
                                            str "Resize Image"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Change image dimensions"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/rotate"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "rotate image rotate image degrees" ] [
                                        div [ _class "tool-name" ] [
                                            str "Rotate Image"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Rotate image degrees"
                                        ]
                                    ]
                                    a [ _href "https://app.shel.sh/tools/mega/tools/image/screenshot"; _class "tool-card"; attr "target" "_blank"; attr "rel" "noopener"; attr "data-search" "screenshot tool capture screen area" ] [
                                        div [ _class "tool-name" ] [
                                            str "Screenshot Tool"
                                        ]
                                        div [ _class "tool-desc" ] [
                                            str "Capture screen area"
                                        ]
                                    ]
                                ]
                            ]
                        ]
                        rawText ("""<!--  CyberChef Section  -->""")
                        div [ _id "cyberchefSection"; _class "embed-section" ] [
                            div [ _class "embed-bar" ] [
                                div [] [
                                    div [ _class "section-title" ] [
                                        str "🏃 CyberChef"
                                    ]
                                    div [ _class "section-sub" ] [
                                        str "The Cyber Swiss Army Knife - encryption, encoding, compression and data analysis"
                                    ]
                                ]
                                div [ _class "embed-actions" ] [
                                    button [ _class "top-btn"; attr "onclick" "openExternal('https://gchq.github.io/CyberChef/')" ] [
                                        str "↗ Open in New Tab"
                                    ]
                                    button [ _class "top-btn"; attr "onclick" "reloadEmbed('cyberchefFrame'))" ] [
                                        str "↻ Reload"
                                    ]
                                ]
                            ]
                            iframe [ _id "cyberchefFrame"; _class "embed-frame"; _src "https://gchq.github.io/CyberChef/"; attr "sandbox" "allow-scripts allow-same-origin allow-forms allow-downloads allow-popups"; attr "loading" "lazy" ] []
                        ]
                        rawText ("""<!--  Webcrack Section  -->""")
                        div [ _id "webcrackSection"; _class "embed-section" ] [
                            div [ _class "embed-bar" ] [
                                div [] [
                                    div [ _class "section-title" ] [
                                        str "🔓 Webcrack"
                                    ]
                                    div [ _class "section-sub" ] [
                                        str "JavaScript deobfuscation and code recovery tool"
                                    ]
                                ]
                                div [ _class "embed-actions" ] [
                                    button [ _class "top-btn"; attr "onclick" "openExternal('https://webcrack.netlify.app/')" ] [
                                        str "↗ Open in New Tab"
                                    ]
                                ]
                            ]
                            iframe [ _id "webcrackFrame"; _class "embed-frame"; _src "https://webcrack.netlify.app/"; attr "sandbox" "allow-scripts allow-same-origin allow-forms"; attr "loading" "lazy" ] []
                        ]
                        rawText ("""<!--  JS Obfuscator Section  -->""")
                        div [ _id "obfuscatorSection"; _class "embed-section" ] [
                            div [ _class "section-title" ] [
                                str "🔏 JS Obfuscator / Deobfuscator"
                            ]
                            div [ _class "section-sub" ] [
                                str "Transform JavaScript code. Use the options below to configure obfuscation settings."
                            ]
                            div [ _class "code-options" ] [
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Compact Code"
                                    ]
                                    div [ _class "tog on"; attr "data-opt" "compact" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Control Flow Flattening"
                                    ]
                                    div [ _class "tog"; attr "data-opt" "controlFlow" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Dead Code Injection"
                                    ]
                                    div [ _class "tog"; attr "data-opt" "deadCode" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Debug Protection"
                                    ]
                                    div [ _class "tog"; attr "data-opt" "debug" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Disable Console Output"
                                    ]
                                    div [ _class "tog"; attr "data-opt" "console" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Identifier Names Generator"
                                    ]
                                    select [ _class "sel"; _id "nameGen"; attr "style" "background:transparent;border:none;color:var(--text);font-size:12px;outline:none;" ] [
                                        option [ attr "value" "hexadecimal" ] [
                                            str "Hexadecimal"
                                        ]
                                        option [ attr "value" "mangled" ] [
                                            str "Mangled"
                                        ]
                                        option [ attr "value" "dictionary" ] [
                                            str "Dictionary"
                                        ]
                                    ]
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Rotate String Array"
                                    ]
                                    div [ _class "tog on"; attr "data-opt" "rotate" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Self Defending"
                                    ]
                                    div [ _class "tog"; attr "data-opt" "selfDefend" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Simplify"
                                    ]
                                    div [ _class "tog on"; attr "data-opt" "simplify" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Source Map"
                                    ]
                                    div [ _class "tog"; attr "data-opt" "sourceMap" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Split Strings"
                                    ]
                                    div [ _class "tog"; attr "data-opt" "splitStrings" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "String Array"
                                    ]
                                    div [ _class "tog on"; attr "data-opt" "stringArray" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Transform Object Keys"
                                    ]
                                    div [ _class "tog"; attr "data-opt" "objKeys" ] []
                                ]
                                div [ _class "opt-row" ] [
                                    span [ _class "opt-label" ] [
                                        str "Unicode Escape Sequence"
                                    ]
                                    div [ _class "tog"; attr "data-opt" "unicode" ] []
                                ]
                            ]
                            div [ attr "style" "display:flex;gap:10px;margin-bottom:16px;flex-wrap:wrap;" ] [
                                button [ _class "code-btn primary"; _id "btnObfuscate" ] [
                                    str "🔏 Obfuscate"
                                ]
                                button [ _class "code-btn"; _id "btnBeautify" ] [
                                    str "✍ Beautify"
                                ]
                                button [ _class "code-btn"; _id "btnMinify" ] [
                                    str "🔄 Minify"
                                ]
                                button [ _class "code-btn"; _id "btnClearCode" ] [
                                    str "🗑 Clear"
                                ]
                                button [ _class "code-btn"; _id "btnLoadSample" ] [
                                    str "📦 Load Sample"
                                ]
                            ]
                            div [ _class "code-area" ] [
                                div [ _class "code-panel" ] [
                                    div [ _class "code-header" ] [
                                        span [ _class "code-label" ] [
                                            str "Input (JavaScript)"
                                        ]
                                        div [ _class "code-actions" ] [
                                            button [ _class "code-btn"; attr "onclick" "copyCode('codeInput')" ] [
                                                str "Copy"
                                            ]
                                            button [ _class "code-btn"; attr "onclick" "pasteCode()" ] [
                                                str "Paste"
                                            ]
                                        ]
                                    ]
                                    tag "textarea" [ _class "code-input"; _id "codeInput"; attr "placeholder" "// Paste your JavaScript code here...\nfunction hello(name) {\n  console.log('Hello, ' + name + '!');\n}\nhello('World');" ] []
                                ]
                                div [ _class "code-panel" ] [
                                    div [ _class "code-header" ] [
                                        span [ _class "code-label" ] [
                                            str "Output"
                                        ]
                                        div [ _class "code-actions" ] [
                                            button [ _class "code-btn"; attr "onclick" "copyCode('codeOutput')" ] [
                                                str "Copy"
                                            ]
                                            button [ _class "code-btn"; attr "onclick" "downloadCode()" ] [
                                                str "Download"
                                            ]
                                        ]
                                    ]
                                    tag "textarea" [ _class "code-input"; _id "codeOutput"; attr "placeholder" "// Obfuscated output will appear here..."; attr "readonly" "" ] []
                                ]
                            ]
                        ]
                        rawText ("""<!--  Webcrack UI Section  -->""")
                        div [ _id "webcrackUiSection"; _class "embed-section" ] [
                            div [ _class "embed-bar" ] [
                                div [] [
                                    div [ _class "section-title" ] [
                                        str "💻 Webcrack Playground"
                                    ]
                                    div [ _class "section-sub" ] [
                                        str "Interactive code transformation and deobfuscation playground"
                                    ]
                                ]
                                div [ _class "embed-actions" ] [
                                    button [ _class "top-btn"; attr "onclick" "openExternal('https://webcrack.netlify.app/')" ] [
                                        str "↗ Open Full App"
                                    ]
                                ]
                            ]
                            iframe [ _id "webcrackUiFrame"; _class "embed-frame"; _src "https://webcrack.netlify.app/"; attr "sandbox" "allow-scripts allow-same-origin allow-forms"; attr "loading" "lazy" ] []
                        ]
                    ]
                    div [ _class "footer" ] [
                        str "OmniSuite v1.0 • Integrates"
                        a [ _href "https://app.shel.sh/tools/mega/"; attr "style" "color:var(--accent)"; attr "target" "_blank" ] [
                            str "Omni-Tools"
                        ]
                        str ","
                        a [ _href "https://gchq.github.io/CyberChef/"; attr "style" "color:var(--accent)"; attr "target" "_blank" ] [
                            str "CyberChef"
                        ]
                        str ","
                        a [ _href "https://webcrack.netlify.app/"; attr "style" "color:var(--accent)"; attr "target" "_blank" ] [
                            str "Webcrack"
                        ]
                        str ","
                        a [ _href "https://obfuscator.io/legacy-playground/"; attr "style" "color:var(--accent)"; attr "target" "_blank" ] [
                            str "JS-Obfuscator"
                        ]
                        a [ _href "https://aem1k.com/"; attr "style" "color:var(--accent)"; attr "target" "_blank" ] [
                            str "JS-Codegolfing"
                        ]
                        str "• All tools run client-side"
                    ]
                ]
            ]
            rawText ("""<!--  /app  -->""")
            script [] [
                    rawText ("""// ===== NAVIGATION =====
const sections = {
  tools: document.getElementById('toolsSection'),
  cyberchef: document.getElementById('cyberchefSection'),
  webcrack: document.getElementById('webcrackSection'),
  obfuscator: document.getElementById('obfuscatorSection'),
  webcrackUi: document.getElementById('webcrackUiSection')
};

function showSection(name) {
  Object.values(sections).forEach(s => s.classList.remove('active'));
  if (sections[name]) sections[name].classList.add('active');
  // Update nav active state
  document.querySelectorAll('.nav-btn, .ext-link').forEach(b => b.classList.remove('active'));
  const activeBtn = document.querySelector(`[data-tool="${name}"]`) || document.querySelector(`[data-target="${name}"]`);
  if (activeBtn) activeBtn.classList.add('active');
}

// Internal nav buttons
document.querySelectorAll('.nav-btn').forEach(btn => {
  btn.addEventListener('click', () => {
    showSection('tools');
    // Scroll to category
    const target = document.getElementById(btn.dataset.target);
    if (target) target.scrollIntoView({ behavior: 'smooth', block: 'start' });
    // Highlight active
    document.querySelectorAll('.nav-btn').forEach(b => b.classList.remove('active'));
    btn.classList.add('active');
  });
});

// External tool buttons
document.querySelectorAll('.ext-link').forEach(btn => {
  btn.addEventListener('click', () => showSection(btn.dataset.tool));
});

// Home button
document.getElementById('btnHome').addEventListener('click', () => showSection('tools'));

// Mobile menu
document.getElementById('menuToggle').addEventListener('click', () => {
  document.getElementById('sidebar').classList.toggle('open');
});

// ===== SEARCH =====
function filterTools(query) {
  const q = query.toLowerCase().trim();
  document.querySelectorAll('.tool-card').forEach(card => {
    const search = card.dataset.search || '';
    card.classList.toggle('hidden', q && !search.includes(q));
  });
  // Hide empty categories
  document.querySelectorAll('.cat-section').forEach(cat => {
    const visible = cat.querySelectorAll('.tool-card:not(.hidden)').length;
    cat.style.display = visible === 0 && q ? 'none' : '';
  });
}

document.getElementById('topSearch').addEventListener('input', e => filterTools(e.target.value));
document.getElementById('sbSearch').addEventListener('input', e => filterTools(e.target.value));

// ===== TOGGLE SWITCHES =====
document.querySelectorAll('.tog').forEach(tog => {
  tog.addEventListener('click', () => tog.classList.toggle('on'));
});

// ===== JS OBFUSCATOR / CODE TOOLS =====
const sampleCode = `// Sample JavaScript code
function calculateSum(a, b) {
  const result = a + b;
  console.log("Sum: " + result);
  return result;
}

class Calculator {
  multiply(x, y) {
    return x * y;
  }

  greet(name) {
    return "Hello, " + name + "!";
  }
}

const calc = new Calculator();
console.log(calc.greet("World"));
console.log(calculateSum(10, 20));
console.log(calc.multiply(5, 7));`;

document.getElementById('btnLoadSample').addEventListener('click', () => {
  document.getElementById('codeInput').value = sampleCode;
});

document.getElementById('btnClearCode').addEventListener('click', () => {
  document.getElementById('codeInput').value = '';
  document.getElementById('codeOutput').value = '';
});

document.getElementById('btnBeautify').addEventListener('click', () => {
  const input = document.getElementById('codeInput').value;
  if (!input.trim()) return;
  try {
    const beautified = simpleBeautify(input);
    document.getElementById('codeOutput').value = beautified;
  } catch(e) { document.getElementById('codeOutput').value = "Error: " + e.message; }
});

document.getElementById('btnMinify').addEventListener('click', () => {
  const input = document.getElementById('codeInput').value;
  if (!input.trim()) return;
  try {
    const minified = input.replace(/\/\*[\s\S]*?\*\//g, '').replace(/\s+/g, ' ').trim();
    document.getElementById('codeOutput').value = minified;
  } catch(e) { document.getElementById('codeOutput').value = "Error: " + e.message; }
});

document.getElementById('btnObfuscate').addEventListener('click', () => {
  const input = document.getElementById('codeInput').value;
  if (!input.trim()) { alert('Please enter JavaScript code to obfuscate'); return; }
  try {
    const opts = getObfuscationOptions();
    const result = simpleObfuscate(input, opts);
    document.getElementById('codeOutput').value = result;
  } catch(e) { document.getElementById('codeOutput').value = "Error: " + e.message; }
});

function getObfuscationOptions() {
  const opts = {};
  document.querySelectorAll('.tog').forEach(tog => {
    opts[tog.dataset.opt] = tog.classList.contains('on');
  });
  opts.nameGen = document.getElementById('nameGen').value;
  return opts;
}

// Simple obfuscation (client-side, no external deps)
function simpleObfuscate(code, opts) {
  let result = code;

  // Extract identifiers
  const identifiers = [...result.matchAll(/\b(?!(?:var|let|const|function|return|if|else|for|while|do|switch|case|break|continue|default|try|catch|finally|throw|new|this|class|extends|super|static|import|export|from|async|await|true|false|null|undefined|typeof|instanceof|in|of|void|delete|yield|debugger)\b)[a-zA-Z_$][a-zA-Z0-9_$]*\b/g)].map(m => m[0]);
  const unique = [...new Set(identifiers)].filter(id => id.length > 1);

  // Generate obfuscated names
  const nameMap = {};
  let counter = 0;
  const genName = () => {
    if (opts.nameGen === 'hexadecimal') return '_0x' + (counter++).toString(16).padStart(4, '0');
    if (opts.nameGen === 'mangled') return '_' + String.fromCharCode(97 + (counter % 26)) + (counter++ > 25 ? Math.floor(counter/26) : '');
    return 'id_' + (counter++);
  };

  unique.forEach(id => { if (!nameMap[id]) nameMap[id] = genName(); });

  // Replace identifiers
  Object.entries(nameMap).forEach(([orig, obf]) => {
    const regex = new RegExp(`\b${orig.replace(/[.*+?^${}()|[\]\\]/g, \\'\\$&\')}\b`, 'g');
    result = result.replace(regex, obf);
  });

  // String array encoding
  if (opts.stringArray) {
    const strings = [...result.matchAll(/["']([^"']+)["']/g)].map(m => m[1]);
    const uniqueStrings = [...new Set(strings)];
    if (uniqueStrings.length > 0) {
      const arrName = '_0x' + Math.random().toString(36).substr(2, 4);
      const arrDecl = `var ${arrName}=[${uniqueStrings.map(s => '"' + s.replace(/"/g, \\'\\"\') + '"').join(',')}];`;
      uniqueStrings.forEach((s, i) => {
        result = result.replace(new RegExp(`["']${s.replace(/[.*+?^${}()|[\]\\]/g, \\'\\$&\')}["']`, 'g'), `${arrName}[${i}]`);
      });
      result = arrDecl + "\n" + result;
    }
  }

  // Compact
  if (opts.compact) {
    result = result.replace(/\n\s*/g, ' ').replace(/\s{2,}/g, ' ').trim();
  }

  // Add self-defending wrapper
  if (opts.selfDefend) {
    result = `(function(){var _0x=` + Date.now() + `;if(+new Date-_0x>10000)return;${result}})();`;
  }

  return result;
}

function simpleBeautify(code) {
  let result = code;
  // Add spacing around operators
  result = result.replace(/([{}();,])/g, ' $1 ');
  // Fix multiple spaces
  result = result.replace(/\s{2,}/g, ' ');
  // Add newlines after braces
  result = result.replace(/\s*\{\s*/g, ' {\n');
  result = result.replace(/\s*\}\s*/g, '\n}\n');
  result = result.replace(/;\s*/g, ';\n');
  // Simple indentation
  const lines = result.split('\n');
  let indent = 0;
  result = lines.map(line => {
    const trimmed = line.trim();
    if (trimmed.startsWith('}')) indent = Math.max(0, indent - 1);
    const spaced = '  '.repeat(indent) + trimmed;
    if (trimmed.endsWith('{')) indent++;
    return spaced;
  }).join('\n');
  return result;
}

function copyCode(id) {
  const el = document.getElementById(id);
  el.select();
  document.execCommand('copy');
}

async function pasteCode() {
  try {
    const text = await navigator.clipboard.readText();
    document.getElementById('codeInput').value = text;
  } catch(e) { alert('Clipboard access denied'); }
}

function downloadCode() {
  const code = document.getElementById('codeOutput').value;
  if (!code) return;
  const blob = new Blob([code], {type: 'text/javascript'});
  const a = document.createElement('a');
  a.href = URL.createObjectURL(blob);
  a.download = 'obfuscated.js';
  a.click();
}

function openExternal(url) { window.open(url, '_blank', 'noopener,noreferrer'); }
function reloadEmbed(id) { document.getElementById(id).src += ''; }

// ===== IFRAME TOGGLE =====
let embedMode = false;
document.getElementById('btnIframe').addEventListener('click', () => {
  embedMode = !embedMode;
  document.querySelectorAll('.embed-frame').forEach(f => {
    f.style.height = embedMode ? '85vh' : '70vh';
  });
});

// ===== INIT =====
showSection('tools');""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
