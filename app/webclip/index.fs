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
    .archive-lab{margin-top:28px;padding-top:25px;border-top:1px solid var(--line)}.section-kicker{margin:0 0 5px;color:var(--heat);font-family:var(--mono);font-size:11px;font-weight:700;letter-spacing:.12em;text-transform:uppercase}.section-head{display:flex;align-items:end;justify-content:space-between;gap:20px;margin-bottom:15px}.section-head h2{margin:0;font-size:24px;letter-spacing:-.035em}.section-head p{max-width:660px;margin:0;color:var(--muted);font-size:13px}
    .archive-grid{display:grid;grid-template-columns:1fr 1fr;gap:16px}.route{border:1px solid var(--line);border-radius:16px;background:var(--surface);box-shadow:var(--shadow);overflow:hidden}.route.wide{grid-column:1/-1}.route-head{display:flex;align-items:flex-start;gap:12px;padding:17px;border-bottom:1px solid var(--line);background:var(--raised)}.route-number{display:grid;place-items:center;flex:0 0 30px;height:30px;border-radius:8px;background:var(--heat);color:#fff;font-family:var(--mono);font-size:11px;font-weight:700}.route h3{margin:0;font-size:15px}.route-head p{margin:2px 0 0;color:var(--muted);font-size:11px}.route-body{padding:17px}.route-note{margin:0 0 14px;color:var(--muted);font-size:12px}.route-note a{color:var(--heat)}.route-note.tail{margin:11px 0 0;font-size:10px}.route-note.tail a:before,.route-note.tail a:after{content:" "}.url-row{display:grid;grid-template-columns:minmax(0,1fr) auto;gap:8px;margin-bottom:10px}.text-input,.number-input{min-width:0;border:1px solid var(--line);border-radius:9px;background:var(--raised);color:var(--text);padding:9px 11px;font-family:var(--mono);font-size:11px;outline:0}.text-input:focus,.number-input:focus{border-color:var(--heat)}.route-actions{display:flex;flex-wrap:wrap;gap:8px}.route-actions+.route-actions{margin-top:8px}.route-steps{margin:14px 0 0;padding-left:19px;color:var(--muted);font-size:11px}.route-steps li+li{margin-top:5px}.asset-drop{display:block;border:1px dashed var(--line);border-radius:11px;background:var(--raised);padding:17px;text-align:center;cursor:pointer}.asset-drop:hover,.asset-drop.over{border-color:var(--heat);background:var(--heat-soft)}.asset-drop strong{display:block;font-size:13px}.asset-drop span{display:block;margin-top:3px;color:var(--muted);font-size:11px}.asset-options{display:grid;grid-template-columns:1fr 1fr;gap:8px;margin:12px 0}.option{display:flex;align-items:center;gap:8px;border:1px solid var(--line);border-radius:9px;padding:8px 10px;background:var(--raised);color:var(--muted);font-size:10px}.option input[type=number]{width:58px;padding:2px 4px;border:0;border-bottom:1px solid var(--line);background:transparent;color:var(--text);font-family:var(--mono);font-size:10px}.option input[type=checkbox]{accent-color:var(--heat)}.asset-report{min-height:38px;margin:12px 0 0;padding:9px 11px;border-radius:9px;background:var(--raised);color:var(--muted);font-family:var(--mono);font-size:10px;line-height:1.55;overflow-wrap:anywhere}.asset-report strong{color:var(--text)}.replay-frame{display:block;width:100%;height:480px;border:1px solid var(--line);border-radius:11px;background:#fff}.replay-status{display:flex;align-items:center;gap:8px;margin:0 0 11px;color:var(--muted);font-family:var(--mono);font-size:10px}.replay-status i{width:7px;height:7px;border-radius:50%;background:var(--muted)}.replay-status.ready i{background:var(--ok)}
    .formats{margin-top:28px;border-top:1px solid var(--line);padding-top:25px}.formats h2{font-size:15px;margin:0 0 12px}.format-grid{display:flex;flex-wrap:wrap;gap:7px}.format-grid span{padding:5px 9px;border:1px solid var(--line);border-radius:7px;background:var(--surface);font-family:var(--mono);font-size:10px;color:var(--muted)}
    .toast{position:fixed;right:22px;bottom:22px;padding:10px 14px;border-radius:9px;background:var(--text);color:var(--bg);font-size:12px;font-weight:650;box-shadow:var(--shadow);transform:translateY(20px);opacity:0;pointer-events:none;transition:.2s}.toast.show{transform:none;opacity:1}
    .busy:after{content:"";display:inline-block;width:10px;height:10px;margin-left:8px;border:2px solid currentColor;border-right-color:transparent;border-radius:50%;animation:spin .7s linear infinite}@keyframes spin{to{transform:rotate(360deg)}}
    @media(max-width:850px){.hero{grid-template-columns:1fr}.privacy{white-space:normal}.workspace,.archive-grid{grid-template-columns:1fr}.panel{min-height:560px}.output{max-height:none}.toplinks .secondary{display:none}.section-head{align-items:flex-start;flex-direction:column;gap:6px}}
    @media(max-width:520px){.shell{width:min(100% - 20px,1280px);padding-top:12px}.hero{padding-top:28px}.panel-head,.actions{padding-left:13px;padding-right:13px}.drop{margin-left:13px;margin-right:13px}.source{padding:16px}.hero h1{font-size:42px}.url-row,.asset-options{grid-template-columns:1fr}.url-row .btn{width:100%}}
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
                section [ _class "archive-lab" ] [
                    p [ _class "section-kicker" ] [
                        str "Offline archive lab"
                    ]
                    div [ _class "section-head" ] [
                        h2 [] [
                            str "Capture the page you actually saw."
                        ]
                        p [] [
                            str "Capture live browser state, build a portable archive, export DeepWiki diagrams, or replay a captured page inside an isolated local frame."
                        ]
                    ]
                    div [ _class "archive-grid" ] [
                        article [ _class "route" ] [
                            div [ _class "route-head" ] [
                                span [ _class "route-number" ] [
                                    str "01"
                                ]
                                div [] [
                                    h3 [] [
                                        str "Source-page capture kit"
                                    ]
                                    p [] [
                                        str "Maximum reach · original browser context"
                                    ]
                                ]
                            ]
                            div [ _class "route-body" ] [
                                p [ _class "route-note" ] [
                                    str "Open the page without an opener or referrer, interact until lazy media is visible, then run the copied commands in that page’s developer console."
                                ]
                                div [ _class "url-row" ] [
                                    input [ _class "text-input"; _id "target-url"; _type "url"; attr "inputmode" "url"; attr "placeholder" "https://example.com/article"; attr "aria-label" "Source page URL" ]
                                    button [ _class "btn"; _id "open-page"; _type "button" ] [
                                        str "Open interactive page"
                                    ]
                                ]
                                div [ _class "route-actions" ] [
                                    button [ _class "btn primary"; _id "copy-serialize"; _type "button" ] [
                                        str "Copy serialize command"
                                    ]
                                    button [ _class "btn"; _id "copy-media-command"; _type "button" ] [
                                        str "Copy media command"
                                    ]
                                    button [ _class "btn"; _id "paste-capture"; _type "button" ] [
                                        str "Paste captured HTML"
                                    ]
                                ]
                                ol [ _class "route-steps" ] [
                                    li [] [
                                        str "Scroll, expand, or play the source until its real state is loaded."
                                    ]
                                    li [] [
                                        str "Serialize that exact DOM to the clipboard; optionally download media over 12 KB."
                                    ]
                                    li [] [
                                        str "Return here, paste the capture, then use route 02 for a one-file archive."
                                    ]
                                ]
                            ]
                        ]
                        article [ _class "route"; _id "archive-route" ] [
                            div [ _class "route-head" ] [
                                span [ _class "route-number" ] [
                                    str "02"
                                ]
                                div [] [
                                    h3 [] [
                                        str "Local self-contained archive"
                                    ]
                                    p [] [
                                        str "Canvas compression · Base64 portability"
                                    ]
                                ]
                            ]
                            div [ _class "route-body" ] [
                                p [ _class "route-note" ] [
                                    str "Supply the files downloaded by route 01, or let Webclip fetch CORS-readable URLs. PNG becomes JPEG; existing JPEG is only replaced when smaller. Video, audio, SVG, AVIF, GIF, and PDF remain in their native formats."
                                ]
                                button [ _class "asset-drop"; _id "asset-drop"; _type "button" ] [
                                    strong [] [
                                        str "Add downloaded media"
                                    ]
                                    span [] [
                                        str "Select files or drag them here; matching is based on the serialized URL’s filename."
                                    ]
                                ]
                                input [ _id "assets"; _type "file"; attr "hidden" ""; attr "multiple" ""; attr "accept" "image/*,video/*,audio/*,.pdf,application/pdf" ]
                                div [ _class "asset-options" ] [
                                    label [ _class "option" ] [
                                        str "minimum"
                                        input [ _id "min-media"; _type "number"; attr "min" "0"; attr "step" "1"; attr "value" "12" ]
                                        str "KB"
                                    ]
                                    label [ _class "option" ] [
                                        str "JPEG quality"
                                        input [ _id "image-quality"; _type "number"; attr "min" "35"; attr "max" "95"; attr "step" "1"; attr "value" "78" ]
                                        str "%"
                                    ]
                                    label [ _class "option" ] [
                                        input [ _id "fetch-remote"; _type "checkbox"; attr "checked" "" ]
                                        str "fetch CORS-readable media"
                                    ]
                                    label [ _class "option" ] [
                                        input [ _id "append-unmatched"; _type "checkbox"; attr "checked" "" ]
                                        str "append unmatched local files"
                                    ]
                                ]
                                div [ _class "route-actions" ] [
                                    button [ _class "btn primary"; _id "build-archive"; _type "button" ] [
                                        str "Build self-contained Markdown"
                                    ]
                                    button [ _class "btn"; _id "clear-assets"; _type "button" ] [
                                        str "Clear media"
                                    ]
                                ]
                                div [ _class "asset-report"; _id "asset-report"; attr "aria-live" "polite" ] [
                                    str "No local media selected. Remote media will be attempted only when its server permits browser access."
                                ]
                                p [ _class "route-note tail" ] [
                                    str "For H.264/AAC, M4A, animated AVIF, response recording, and authenticated dynamic captures, use the full"
                                    a [ _href "https://github.com/CommanderTurtle/web-archive"; attr "target" "_blank"; attr "rel" "noopener noreferrer" ] [
                                        str "Web Archive"
                                    ]
                                    str "pipeline."
                                ]
                            ]
                        ]
                        article [ _class "route"; _id "deepwiki-route" ] [
                            div [ _class "route-head" ] [
                                span [ _class "route-number" ] [
                                    str "03"
                                ]
                                div [] [
                                    h3 [] [
                                        str "DeepWiki chart exporter"
                                    ]
                                    p [] [
                                        str "Inline SVG → high-resolution PNG ZIP"
                                    ]
                                ]
                            ]
                            div [ _class "route-body" ] [
                                p [ _class "route-note" ] [
                                    str "Paste a DeepWiki page, then run one page-native exporter after its diagrams render. Interface icons are ignored; large charts are rasterized with their computed styles and bundled with a manifest."
                                ]
                                div [ _class "url-row" ] [
                                    input [ _class "text-input"; _id "deepwiki-url"; _type "url"; attr "inputmode" "url"; attr "placeholder" "https://deepwiki.com/owner/repo/page"; attr "aria-label" "DeepWiki page URL" ]
                                    button [ _class "btn primary"; _id "deepwiki-open-copy"; _type "button" ] [
                                        str "Open + copy exporter"
                                    ]
                                ]
                                div [ _class "route-actions" ] [
                                    label [ _class "option" ] [
                                        str "scale"
                                        input [ _id "deepwiki-scale"; _type "number"; attr "min" "2"; attr "max" "6"; attr "step" "1"; attr "value" "4" ]
                                        str "×"
                                    ]
                                    button [ _class "btn"; _id "deepwiki-copy"; _type "button" ] [
                                        str "Copy exporter only"
                                    ]
                                ]
                                div [ _class "asset-report"; _id "deepwiki-report"; attr "aria-live" "polite" ] [
                                    str "The command runs in DeepWiki’s own page context, preserving chart fonts and styles without a cloud conversion service."
                                ]
                                ol [ _class "route-steps" ] [
                                    li [] [
                                        str "Open the page and let every diagram become visible."
                                    ]
                                    li [] [
                                        str "Paste the copied exporter into that page’s developer console."
                                    ]
                                    li [] [
                                        str "Receive one named ZIP containing PNG charts and"
                                        code [] [
                                            str "manifest.json"
                                        ]
                                        str "."
                                    ]
                                ]
                            ]
                        ]
                        article [ _class "route"; _id "replay-route" ] [
                            div [ _class "route-head" ] [
                                span [ _class "route-number" ] [
                                    str "04"
                                ]
                                div [] [
                                    h3 [] [
                                        str "Captured-page browser"
                                    ]
                                    p [] [
                                        str "Interactive replay · isolated origin"
                                    ]
                                ]
                            ]
                            div [ _class "route-body" ] [
                                p [ _class "route-note" ] [
                                    str "Load the serialized HTML currently in Source into a sandboxed browser-within-Webclip. Links, forms, scripts, and UI can run without giving the captured page access to Webclip’s origin."
                                ]
                                div [ _class "replay-status"; _id "replay-status" ] [
                                    i [] []
                                    span [] [
                                        str "No captured page loaded"
                                    ]
                                ]
                                div [ _class "route-actions" ] [
                                    button [ _class "btn primary"; _id "load-replay"; _type "button" ] [
                                        str "Load captured page"
                                    ]
                                    button [ _class "btn"; _id "capture-replay"; _type "button"; attr "disabled" "" ] [
                                        str "Serialize replay state"
                                    ]
                                    button [ _class "btn"; _id "export-replay"; _type "button"; attr "disabled" "" ] [
                                        str "Export replay charts"
                                    ]
                                    button [ _class "btn"; _id "clear-replay"; _type "button"; attr "disabled" "" ] [
                                        str "Clear replay"
                                    ]
                                ]
                                p [ _class "route-note tail" ] [
                                    str "Remote pages cannot be inspected through a cross-origin iframe. This replays the captured document locally and uses a narrow message bridge for serialization."
                                ]
                            ]
                        ]
                        article [ _class "route wide"; _id "replay-view"; attr "hidden" "" ] [
                            div [ _class "route-head" ] [
                                span [ _class "route-number" ] [
                                    str "↳"
                                ]
                                div [] [
                                    h3 [] [
                                        str "Interactive captured page"
                                    ]
                                    p [ _id "replay-title" ] [
                                        str "Sandboxed replay"
                                    ]
                                ]
                            ]
                            div [ _class "route-body" ] [
                                iframe [ _class "replay-frame"; _id "replay-frame"; attr "title" "Interactive captured page"; attr "sandbox" "allow-scripts allow-forms allow-modals allow-popups allow-popups-to-escape-sandbox allow-downloads" ] []
                            ]
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
    const state = { markdown:'', file:null, assetFiles:[], baseName:'web-clip', title:'Web Clip', url:'', busy:false };
    const textExtensions = new Set(['html','htm','txt','md','markdown','json']);

    const escapeHtml = value => { const node=document.createElement('div'); node.textContent=value; return node.innerHTML; };
    const bytesLabel = bytes => bytes < 1024 ? `${bytes} B` : bytes < 1048576 ? `${(bytes/1024).toFixed(1)} KB` : `${(bytes/1048576).toFixed(1)} MB`;
    const dateStamp = () => new Date().toISOString().replace(/:/g,'-').replace(/\.\d{3}Z$/,'Z');
    const safeBase = name => (name || 'web-clip').replace(/\.[^.]+$/,'').replace(/[\\/:*?"<>|]+/g,'-') || 'web-clip';
    const extensionOf = name => (name.split('.').pop() || '').toLowerCase();
    const serializeCommand = "copy(new XMLSerializer().serializeToString(document)); console.log('Webclip: serialized live DOM copied to the clipboard.');";
    const mediaDownloadCommand = `(async()=>{
  const threshold=12*1024, urls=new Set(), mediaPattern=/\\.(?:avif|bmp|gif|jpe?g|png|svg|webp|m4a|mov|mp3|mp4|ogg|wav|webm|pdf)(?:$|[?#])/i;
  const add=value=>{try{const url=new URL(value,document.baseURI);if(/^https?:$/.test(url.protocol))urls.add(url.href)}catch{}};
  document.querySelectorAll('img').forEach(node=>{add(node.currentSrc||node.src);(node.srcset||'').split(',').forEach(item=>add(item.trim().split(/\\s+/)[0]))});
  document.querySelectorAll('video,audio').forEach(node=>{add(node.currentSrc||node.src);if(node.poster)add(node.poster);node.querySelectorAll('source').forEach(source=>add(source.src))});
  document.querySelectorAll('picture source').forEach(node=>(node.srcset||'').split(',').forEach(item=>add(item.trim().split(/\\s+/)[0])));
  document.querySelectorAll('a[href],object[data],embed[src]').forEach(node=>{const value=node.href||node.data||node.src;if(mediaPattern.test(value||''))add(value)});
  const cssPattern=/url\\((?:"|')?([^"')]+)(?:"|')?\\)/g;
  Array.from(document.querySelectorAll('*')).slice(0,5000).forEach(node=>{const style=getComputedStyle(node);[style.backgroundImage,style.maskImage].forEach(value=>{for(const match of value.matchAll(cssPattern))add(match[1])})});
  performance.getEntriesByType('resource').forEach(entry=>{if(mediaPattern.test(entry.name)||['img','video','audio'].includes(entry.initiatorType))add(entry.name)});
  let saved=0,skipped=0,failed=0;
  for(const url of urls){try{const response=await fetch(url,{credentials:'same-origin'});if(!response.ok)throw new Error('HTTP '+response.status);const blob=await response.blob();if(blob.size<threshold){skipped++;console.log('Webclip skipped (<12 KB):',url,blob.size);continue}const pathname=new URL(url).pathname;let name=decodeURIComponent(pathname.split('/').pop()||'media').replace(/[\\/:*?"<>|]+/g,'-');if(!name.includes('.')){const ext={'image/jpeg':'jpg','image/png':'png','image/webp':'webp','image/gif':'gif','image/avif':'avif','video/mp4':'mp4','video/webm':'webm','audio/mpeg':'mp3','audio/mp4':'m4a','application/pdf':'pdf'}[blob.type]||'bin';name+='.'+ext}const href=URL.createObjectURL(blob);const link=Object.assign(document.createElement('a'),{href,download:name});document.body.appendChild(link);link.click();link.remove();await new Promise(resolve=>setTimeout(resolve,120));URL.revokeObjectURL(href);saved++}catch(error){failed++;console.warn('Webclip failed:',url,error)}}
  console.log('Webclip media pass complete:',{found:urls.size,saved,skipped,failed,threshold});
})()`;

    async function runDeepWikiExporter(requestedScale){
      'use strict';
      const scale=Math.min(6,Math.max(2,Number(requestedScale)||4));
      const charts=[...document.querySelectorAll('svg')].map((svg,index)=>({svg,index,rect:svg.getBoundingClientRect()})).filter(item=>item.rect.width>=180&&item.rect.height>=80);
      if(!charts.length)throw new Error('No rendered DeepWiki charts were found. Scroll through the page once, then retry.');
      const encoder=new TextEncoder();
      const slug=value=>(String(value||'chart').normalize('NFKD').replace(/[^\w\s-]/g,'').trim().replace(/[\s_]+/g,'-').replace(/-+/g,'-').toLowerCase().slice(0,72)||'chart');
      const headings=[...document.querySelectorAll('h1,h2,h3,h4')];
      const headingFor=svg=>{const y=svg.getBoundingClientRect().top+scrollY;return headings.filter(node=>node.getBoundingClientRect().top+scrollY<y).at(-1)?.textContent?.trim()||document.title||'DeepWiki chart'};
      const backgroundFor=svg=>{let node=svg;while(node){const color=getComputedStyle(node).backgroundColor;if(color&&!/rgba?\(0, 0, 0(?:, 0)?\)|transparent/.test(color))return color;node=node.parentElement}return'#ffffff'};
      const inlineStyles=(source,clone)=>{const originals=[source,...source.querySelectorAll('*')],copies=[clone,...clone.querySelectorAll('*')];originals.forEach((node,index)=>{const style=getComputedStyle(node),target=copies[index];for(const property of style)target.style.setProperty(property,style.getPropertyValue(property),style.getPropertyPriority(property))})};
      const flattenForeignObjects=clone=>{const namespace='http://www.w3.org/2000/svg';clone.querySelectorAll('foreignObject').forEach(node=>{const x=Number.parseFloat(node.getAttribute('x'))||0,y=Number.parseFloat(node.getAttribute('y'))||0,width=Number.parseFloat(node.getAttribute('width'))||160,height=Number.parseFloat(node.getAttribute('height'))||40,words=(node.textContent||'').replace(/\s+/g,' ').trim().split(' ').filter(Boolean),maxChars=Math.max(10,Math.floor(width/8));const lines=[];let line='';for(const word of words){if(line&&(line+' '+word).length>maxChars){lines.push(line);line=word}else line+=(line?' ':'')+word}if(line)lines.push(line);const visible=lines.slice(0,Math.max(1,Math.floor(height/16))),text=document.createElementNS(namespace,'text');text.setAttribute('x',String(x+width/2));text.setAttribute('y',String(y+height/2-(visible.length-1)*8));text.setAttribute('text-anchor','middle');text.setAttribute('dominant-baseline','middle');text.setAttribute('fill',node.querySelector('*')?.style?.color||'#333333');text.setAttribute('font-family','ui-sans-serif, system-ui, sans-serif');text.setAttribute('font-size','14');visible.forEach((value,index)=>{const span=document.createElementNS(namespace,'tspan');span.setAttribute('x',String(x+width/2));span.setAttribute('dy',index?'1.15em':'0');span.textContent=value;text.appendChild(span)});node.replaceWith(text)});return clone};
      const loadSvg=async clone=>{const sourceBlob=new Blob([new XMLSerializer().serializeToString(clone)],{type:'image/svg+xml;charset=utf-8'}),objectUrl=URL.createObjectURL(sourceBlob),image=new Image();image.decoding='async';try{await new Promise((resolve,reject)=>{image.onload=resolve;image.onerror=()=>reject(new Error('SVG rasterization failed'));image.src=objectUrl});return image}finally{URL.revokeObjectURL(objectUrl)}};
      const rasterize=async(item,sequence)=>{
        const {svg,rect}=item,clone=svg.cloneNode(true);inlineStyles(svg,clone);clone.setAttribute('xmlns','http://www.w3.org/2000/svg');clone.setAttribute('xmlns:xlink','http://www.w3.org/1999/xlink');
        const width=Math.min(6000,Math.max(1,Math.round(rect.width*scale))),height=Math.min(6000,Math.max(1,Math.round(rect.height*scale)));clone.setAttribute('width',String(rect.width));clone.setAttribute('height',String(rect.height));
        if(!clone.getAttribute('viewBox'))clone.setAttribute('viewBox','0 0 '+rect.width+' '+rect.height);
        const fallback=Boolean(clone.querySelector('foreignObject'));if(fallback)flattenForeignObjects(clone);const image=await loadSvg(clone);
        const canvas=document.createElement('canvas');canvas.width=width;canvas.height=height;const context=canvas.getContext('2d',{alpha:false});context.fillStyle=backgroundFor(svg);context.fillRect(0,0,width,height);context.imageSmoothingEnabled=true;context.imageSmoothingQuality='high';context.drawImage(image,0,0,width,height);
        const blob=await new Promise((resolve,reject)=>canvas.toBlob(value=>value?resolve(value):reject(new Error('PNG encoding failed')),'image/png'));
        const heading=headingFor(svg),filename=String(sequence).padStart(2,'0')+'-'+slug(heading)+'.png';return{filename,heading,width,height,sourceWidth:Math.round(rect.width),sourceHeight:Math.round(rect.height),fallback,data:new Uint8Array(await blob.arrayBuffer())};
      };
      const crcTable=Array.from({length:256},(_,value)=>{let crc=value;for(let bit=0;bit<8;bit++)crc=(crc&1)?0xedb88320^(crc>>>1):crc>>>1;return crc>>>0});
      const crc32=data=>{let crc=0xffffffff;for(const byte of data)crc=crcTable[(crc^byte)&255]^(crc>>>8);return(crc^0xffffffff)>>>0};
      const concat=parts=>{const size=parts.reduce((sum,part)=>sum+part.length,0),joined=new Uint8Array(size);let offset=0;for(const part of parts){joined.set(part,offset);offset+=part.length}return joined};
      const zip=files=>{const localParts=[],centralParts=[];let offset=0,centralSize=0;const now=new Date(),dosTime=(now.getHours()<<11)|(now.getMinutes()<<5)|(now.getSeconds()>>1),dosDate=((now.getFullYear()-1980)<<9)|((now.getMonth()+1)<<5)|now.getDate();
        for(const file of files){const name=encoder.encode(file.name),data=file.data,crc=crc32(data),local=new Uint8Array(30+name.length),lv=new DataView(local.buffer);lv.setUint32(0,0x04034b50,true);lv.setUint16(4,20,true);lv.setUint16(6,0x0800,true);lv.setUint16(8,0,true);lv.setUint16(10,dosTime,true);lv.setUint16(12,dosDate,true);lv.setUint32(14,crc,true);lv.setUint32(18,data.length,true);lv.setUint32(22,data.length,true);lv.setUint16(26,name.length,true);local.set(name,30);localParts.push(local,data);
          const central=new Uint8Array(46+name.length),cv=new DataView(central.buffer);cv.setUint32(0,0x02014b50,true);cv.setUint16(4,20,true);cv.setUint16(6,20,true);cv.setUint16(8,0x0800,true);cv.setUint16(10,0,true);cv.setUint16(12,dosTime,true);cv.setUint16(14,dosDate,true);cv.setUint32(16,crc,true);cv.setUint32(20,data.length,true);cv.setUint32(24,data.length,true);cv.setUint16(28,name.length,true);cv.setUint32(42,offset,true);central.set(name,46);centralParts.push(central);centralSize+=central.length;offset+=local.length+data.length}
        const end=new Uint8Array(22),ev=new DataView(end.buffer);ev.setUint32(0,0x06054b50,true);ev.setUint16(8,files.length,true);ev.setUint16(10,files.length,true);ev.setUint32(12,centralSize,true);ev.setUint32(16,offset,true);return concat([...localParts,...centralParts,end])};
      const rendered=[];for(let index=0;index<charts.length;index++){try{rendered.push(await rasterize(charts[index],index+1))}catch(error){console.warn('Webclip skipped chart '+(index+1)+':',error)}}
      if(!rendered.length)throw new Error('The charts were found, but none could be rasterized.');
      const pageSlug=slug(location.pathname.split('/').filter(Boolean).slice(-3).join('-')||document.title),folder='deepwiki-'+pageSlug+'-charts';
      const manifest={source:location.href,title:document.title,capturedAt:new Date().toISOString(),scale,charts:rendered.map(({data,...entry})=>entry)};
      const files=rendered.map(chart=>({name:folder+'/'+chart.filename,data:chart.data}));files.push({name:folder+'/manifest.json',data:encoder.encode(JSON.stringify(manifest,null,2))});
      const archive=new Blob([zip(files)],{type:'application/zip'}),href=URL.createObjectURL(archive),link=Object.assign(document.createElement('a'),{href,download:folder+'.zip'});document.body.appendChild(link);link.click();link.remove();setTimeout(()=>URL.revokeObjectURL(href),1000);console.table(manifest.charts);console.log('Webclip exported '+rendered.length+' DeepWiki chart(s) to '+folder+'.zip');return manifest;
    }

    const deepWikiCommand=scale=>'('+runDeepWikiExporter.toString()+')('+JSON.stringify(Math.min(6,Math.max(2,Number(scale)||4)))+').catch(error=>console.error("Webclip DeepWiki export failed:",error))';

    function replayBridge(exportCharts){
      'use strict';
      const send=(type,payload={})=>parent.postMessage({channel:'webclip:replay',type,...payload},'*');
      addEventListener('message',event=>{if(event.source!==parent||event.data?.channel!=='webclip:host')return;if(event.data.type==='serialize'){
        const clone=document.documentElement.cloneNode(true),live=[...document.querySelectorAll('input,textarea,select,details')],copy=[...clone.querySelectorAll('input,textarea,select,details')];
        live.forEach((node,index)=>{const target=copy[index];if(!target)return;if(node.matches('input')){target.setAttribute('value',node.value);if(node.checked)target.setAttribute('checked','');else target.removeAttribute('checked')}else if(node.matches('textarea'))target.textContent=node.value;else if(node.matches('select'))[...target.options].forEach((option,i)=>option.toggleAttribute('selected',node.options[i]?.selected));else target.toggleAttribute('open',node.open)});
        clone.querySelectorAll('script[data-webclip-bridge]').forEach(node=>node.remove());send('serialized',{requestId:event.data.requestId,html:'<!doctype html>'+clone.outerHTML,title:document.title});
      }else if(event.data.type==='export-svg'){exportCharts(event.data.scale).then(manifest=>send('exported',{count:manifest.charts.length})).catch(error=>send('export-error',{message:error?.message||String(error)}))}});send('ready',{title:document.title,url:location.href});
    }

    function replayDocument(html,baseUrl){
      const doc=new DOMParser().parseFromString(html,'text/html');doc.querySelectorAll('meta[http-equiv="content-security-policy" i],base').forEach(node=>node.remove());
      const base=doc.createElement('base');base.href=baseUrl||document.baseURI;doc.head.prepend(base);const bridge=doc.createElement('script');bridge.dataset.webclipBridge='';bridge.textContent='('+replayBridge.toString()+')('+runDeepWikiExporter.toString()+')';(doc.body||doc.documentElement).appendChild(bridge);return'<!doctype html>'+doc.documentElement.outerHTML;
    }

    function toast(message){ const el=$('toast'); el.textContent=message; el.classList.add('show'); clearTimeout(toast.timer); toast.timer=setTimeout(()=>el.classList.remove('show'),1800); }
    function setState(message,error=false){ $('state').textContent=message; $('state').classList.toggle('error',error); }
    function setBusy(on,label='Converting'){ state.busy=on; $('convert').disabled=on; $('convert').classList.toggle('busy',on); $('convert').textContent=on?label:'Convert'; }
    function updateInputStats(bytes){ $('input-stats').textContent=bytesLabel(bytes); }
    function archiveReport(message,error=false){ const report=$('asset-report'); report.innerHTML=error?`<strong>Stopped.</strong> ${escapeHtml(message)}`:message; report.style.color=error?'var(--danger)':''; }
    async function writeClipboard(value,label){
      try{ await navigator.clipboard.writeText(value); toast(label); }
      catch{
        const field=Object.assign(document.createElement('textarea'),{value}); field.style.cssText='position:fixed;opacity:0;pointer-events:none'; document.body.appendChild(field); field.select();
        const copied=document.execCommand('copy'); field.remove(); if(!copied) throw new Error('Clipboard access was denied.'); toast(label);
      }
    }
    function normalizedAssetName(name){ return String(name||'').toLowerCase().replace(/^\d{3,4}[-_]/,''); }
    function addAssetFiles(files){
      const merged=new Map(state.assetFiles.map(file=>[`${file.name.toLowerCase()}:${file.size}:${file.lastModified}`,file]));
      for(const file of files){ if(/^(?:image|video|audio)\//.test(file.type)||file.type==='application/pdf'||/\.pdf$/i.test(file.name)) merged.set(`${file.name.toLowerCase()}:${file.size}:${file.lastModified}`,file); }
      state.assetFiles=[...merged.values()]; $('assets').value='';
      const total=state.assetFiles.reduce((sum,file)=>sum+file.size,0);
      archiveReport(state.assetFiles.length?`<strong>${state.assetFiles.length} local file${state.assetFiles.length===1?'':'s'}</strong> ready · ${bytesLabel(total)} total`:'No local media selected. Remote media will be attempted only when its server permits browser access.');
    }

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

    function archiveCandidates(html,baseUrl){
      const doc=new DOMParser().parseFromString(html,'text/html'); const candidates=new Map();
      const mediaPattern=/\.(?:avif|bmp|gif|jpe?g|png|svg|webp|m4a|mov|mp3|mp4|ogg|wav|webm|pdf)(?:$|[?#])/i;
      const resolve=raw=>{ try{return new URL(raw,baseUrl||document.baseURI).href}catch{return raw} };
      const kindFor=(element,url)=>element?.matches('img,picture')||/\.(?:avif|bmp|gif|jpe?g|png|svg|webp)(?:$|[?#])/i.test(url)?'image':element?.matches('video')||element?.closest('video')||/\.(?:mov|mp4|webm)(?:$|[?#])/i.test(url)?'video':element?.matches('audio')||element?.closest('audio')||/\.(?:m4a|mp3|ogg|wav)(?:$|[?#])/i.test(url)?'audio':/\.pdf(?:$|[?#])/i.test(url)?'pdf':'other';
      const add=(element,attr,raw,origin='dom')=>{ if(!raw||/^data:/i.test(raw))return; const resolved=resolve(raw); const key=resolved||raw; const current=candidates.get(key)||{raw,resolved,kind:kindFor(element,resolved),alt:element?.getAttribute?.('alt')||'',origin,refs:[]}; current.refs.push({element,attr}); candidates.set(key,current); };
      doc.querySelectorAll('img[src]').forEach(node=>add(node,'src',node.getAttribute('src')));
      doc.querySelectorAll('img[srcset],picture source[srcset]').forEach(node=>(node.getAttribute('srcset')||'').split(',').forEach(item=>add(node,'srcset',item.trim().split(/\s+/)[0])));
      doc.querySelectorAll('video[src],audio[src],video source[src],audio source[src]').forEach(node=>add(node,'src',node.getAttribute('src')));
      doc.querySelectorAll('video[poster]').forEach(node=>add(node,'poster',node.getAttribute('poster')));
      doc.querySelectorAll('a[href],object[data],embed[src]').forEach(node=>{ const attr=node.hasAttribute('href')?'href':node.hasAttribute('data')?'data':'src'; const raw=node.getAttribute(attr); if(mediaPattern.test(raw||''))add(node,attr,raw); });
      const cssPattern=/url\((?:"|')?([^"')]+)(?:"|')?\)/g;
      doc.querySelectorAll('[style],style').forEach(node=>{ const value=node.tagName==='STYLE'?node.textContent||'':node.getAttribute('style')||''; for(const match of value.matchAll(cssPattern))add(null,'css',match[1],'css'); });
      return {doc,candidates:[...candidates.values()]};
    }

    function localAssetFor(candidate){
      let basename=''; try{basename=decodeURIComponent(new URL(candidate.resolved).pathname.split('/').pop()||'')}catch{basename=String(candidate.raw).split('/').pop().split('?')[0]}
      const expected=normalizedAssetName(basename); return state.assetFiles.find(file=>normalizedAssetName(file.name)===expected||file.name.toLowerCase()===basename.toLowerCase());
    }
    function assetKind(type,name,fallback='other'){
      if(/^image\//.test(type)||/\.(?:avif|bmp|gif|jpe?g|png|svg|webp)$/i.test(name))return'image';
      if(/^video\//.test(type)||/\.(?:mov|mp4|webm)$/i.test(name))return'video';
      if(/^audio\//.test(type)||/\.(?:m4a|mp3|ogg|wav)$/i.test(name))return'audio';
      if(type==='application/pdf'||/\.pdf$/i.test(name))return'pdf'; return fallback;
    }
    async function sanitizeSvg(blob){
      const doc=new DOMParser().parseFromString(await blob.text(),'image/svg+xml'); doc.querySelectorAll('script,foreignObject').forEach(node=>node.remove());
      doc.querySelectorAll('*').forEach(node=>{ for(const attr of [...node.attributes]){ if(/^on/i.test(attr.name)||( /^(?:href|xlink:href)$/i.test(attr.name)&&/^\s*(?:javascript:|https?:)/i.test(attr.value)))node.removeAttribute(attr.name); } if(node.hasAttribute('style'))node.setAttribute('style',node.getAttribute('style').replace(/url\(\s*(?:"|')?\s*https?:[^)]+\)/gi,'none')); });
      return new Blob([new XMLSerializer().serializeToString(doc)],{type:'image/svg+xml'});
    }
    async function optimizeAsset(blob,kind){
      const mime=(blob.type||'application/octet-stream').split(';')[0].toLowerCase();
      if(mime==='image/svg+xml')return{blob:await sanitizeSvg(blob),mime,optimized:true};
      if(kind!=='image'||!['image/png','image/jpeg','image/bmp'].includes(mime))return{blob,mime,optimized:false};
      const bitmap=await createImageBitmap(blob); const scale=Math.min(1,1600/Math.max(1,bitmap.width)); const canvas=document.createElement('canvas'); canvas.width=Math.max(1,Math.round(bitmap.width*scale)); canvas.height=Math.max(1,Math.round(bitmap.height*scale));
      const context=canvas.getContext('2d',{alpha:false}); context.fillStyle='#fff'; context.fillRect(0,0,canvas.width,canvas.height); context.drawImage(bitmap,0,0,canvas.width,canvas.height); bitmap.close?.();
      const quality=Math.min(.95,Math.max(.35,Number($('image-quality').value||78)/100)); const jpeg=await new Promise((resolve,reject)=>canvas.toBlob(result=>result?resolve(result):reject(new Error('Canvas JPEG conversion failed.')),'image/jpeg',quality));
      if(mime!=='image/png'&&mime!=='image/bmp'&&jpeg.size>=blob.size)return{blob,mime,optimized:false}; return{blob:jpeg,mime:'image/jpeg',optimized:true};
    }
    function dataUrl(blob){ return new Promise((resolve,reject)=>{ const reader=new FileReader(); reader.onerror=()=>reject(reader.error); reader.onload=()=>resolve(String(reader.result)); reader.readAsDataURL(blob); }); }
    function appendixBlock(asset){
      const label=escapeHtml(asset.label||'Captured media'),src=asset.dataUri,mime=escapeHtml(asset.mime);
      if(asset.kind==='image')return `<figure>\n<img src="${src}" alt="${label}" style="max-width:640px;width:100%;height:auto">\n<figcaption>${label}</figcaption>\n</figure>`;
      if(asset.kind==='video')return `<figure>\n<video controls preload="metadata" width="640"><source src="${src}" type="${mime}"></video>\n<figcaption>${label}</figcaption>\n</figure>`;
      if(asset.kind==='audio')return `<figure>\n<audio controls preload="metadata"><source src="${src}" type="${mime}"></audio>\n<figcaption>${label}</figcaption>\n</figure>`;
      return `<figure>\n<object data="${src}" type="application/pdf" width="100%" height="720"><a href="${src}">${label}</a></object>\n<figcaption>${label}</figcaption>\n</figure>`;
    }
    async function buildBrowserArchive(){
      const html=$('source').value.trim(); if(!html||detectText(html)!=='HTML'){ archiveReport('Paste a serialized HTML document before building an archive.',true); return; }
      const button=$('build-archive'); button.disabled=true; button.classList.add('busy'); button.textContent='Building'; setState('Archiving'); const started=performance.now();
      try{
        const meta=extractHtmlMeta(html),base=$('target-url').value.trim()||meta.url||document.baseURI,{doc,candidates}=archiveCandidates(html,base); const threshold=Math.max(0,Number($('min-media').value||12))*1024; const localMatched=new Set(); const embedded=[]; const failures=[]; let skipped=0,optimized=0;
        for(const candidate of candidates){
          try{
            const local=localAssetFor(candidate); let blob;
            if(local){blob=local;localMatched.add(local)} else if($('fetch-remote').checked&&/^https?:/i.test(candidate.resolved)){const response=await fetch(candidate.resolved,{mode:'cors',credentials:'omit'});if(!response.ok)throw new Error(`HTTP ${response.status}`);blob=await response.blob()} else {throw new Error('No matching local file')}
            const kind=assetKind(blob.type,local?.name||candidate.resolved,candidate.kind); if(['image','video','audio'].includes(kind)&&blob.size<threshold){skipped++;continue}
            const result=await optimizeAsset(blob,kind); if(result.optimized)optimized++; const uri=await dataUrl(result.blob); const asset={candidate,kind,mime:result.mime||blob.type||'application/octet-stream',dataUri:uri,label:candidate.alt||local?.name||decodeURIComponent(String(candidate.resolved).split('/').pop().split('?')[0])||kind,append:candidate.origin==='css'||kind!=='image'}; embedded.push(asset);
            for(const ref of candidate.refs){ if(!ref.element)continue; ref.element.setAttribute(ref.attr,uri); if(ref.element.matches('img')&&ref.attr==='src')ref.element.removeAttribute('srcset'); }
          }catch(error){failures.push(`${candidate.resolved}: ${error?.message||error}`)}
        }
        if($('append-unmatched').checked){
          for(const file of state.assetFiles.filter(file=>!localMatched.has(file))){ try{const kind=assetKind(file.type,file.name);if(kind==='other'||(['image','video','audio'].includes(kind)&&file.size<threshold)){skipped++;continue}const result=await optimizeAsset(file,kind);if(result.optimized)optimized++;embedded.push({kind,mime:result.mime||file.type||'application/octet-stream',dataUri:await dataUrl(result.blob),label:file.name,append:true});}catch(error){failures.push(`${file.name}: ${error?.message||error}`)} }
        }
        let markdown=firecrawlConverter().turndown(doc.body?.innerHTML||html); const seen=new Set(); const appendix=[];
        for(const asset of embedded){if(asset.append&&!seen.has(asset.dataUri)){seen.add(asset.dataUri);appendix.push(appendixBlock(asset))}}
        if(appendix.length)markdown+=`\n\n## Additional captured media\n\n${appendix.join('\n\n')}`;
        const metadata=frontmatter(meta.title,base,'Webclip browser archive').split('\n'); metadata.splice(-1,0,`media_candidates: ${candidates.length}`,`embedded_assets: ${embedded.length}`,`optimized_images: ${optimized}`,`skipped_assets: ${skipped}`,`unavailable_assets: ${failures.length}`); markdown=`${metadata.join('\n')}\n\n# ${meta.title}\n\n${markdown}`;
        state.baseName=safeBase(meta.title); present(markdown,'Browser archive',performance.now()-started,new TextEncoder().encode(html).length+state.assetFiles.reduce((sum,file)=>sum+file.size,0));
        archiveReport(`<strong>${embedded.length} embedded</strong> · ${optimized} image${optimized===1?'':'s'} optimized · ${skipped} below threshold · ${failures.length} unavailable${failures.length?' (supply their downloaded files to retry)':''}`);
      }catch(error){setState(error?.message||String(error),true);archiveReport(error?.message||String(error),true)}finally{button.disabled=false;button.classList.remove('busy');button.textContent='Build self-contained Markdown'}
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

    function deepWikiReport(message,error=false){const report=$('deepwiki-report');report.innerHTML=error?`<strong>Stopped.</strong> ${escapeHtml(message)}`:message;report.style.color=error?'var(--danger)':''}
    function checkedDeepWikiUrl(){const value=$('deepwiki-url').value.trim(),url=new URL(value);if(url.protocol!=='https:'||!(url.hostname==='deepwiki.com'||url.hostname.endsWith('.deepwiki.com')))throw new Error('Use an HTTPS page on deepwiki.com.');return url}
    async function copyDeepWikiExporter(openPage=false){
      try{let url;if(openPage){url=checkedDeepWikiUrl();const opened=window.open(url.href,'_blank','noopener,noreferrer');if(opened===null)throw new Error('The browser blocked the DeepWiki tab.')}const scale=Math.min(6,Math.max(2,Number($('deepwiki-scale').value)||4));await writeClipboard(deepWikiCommand(scale),'DeepWiki exporter copied');deepWikiReport(`<strong>${scale}× exporter ready.</strong> Paste it in the loaded DeepWiki page console to download one PNG ZIP.`)}catch(error){deepWikiReport(error?.message||String(error),true)}
    }

    function loadReplay(){
      try{const html=$('source').value.trim();if(!html||detectText(html)!=='HTML')throw new Error('Paste or capture an HTML document in Source first.');const meta=extractHtmlMeta(html),base=$('target-url').value.trim()||meta.url||document.baseURI,frame=$('replay-frame');$('replay-view').hidden=false;$('replay-status').classList.remove('ready');$('replay-status').querySelector('span').textContent='Loading isolated replay…';$('replay-title').textContent=meta.title||'Sandboxed replay';$('capture-replay').disabled=true;$('export-replay').disabled=true;$('clear-replay').disabled=false;frame.srcdoc=replayDocument(html,base);frame.scrollIntoView({behavior:'smooth',block:'start'})}catch(error){archiveReport(error?.message||String(error),true)}
    }
    function clearReplay(){const frame=$('replay-frame');frame.removeAttribute('srcdoc');frame.src='about:blank';$('replay-view').hidden=true;$('replay-status').classList.remove('ready');$('replay-status').querySelector('span').textContent='No captured page loaded';$('capture-replay').disabled=true;$('export-replay').disabled=true;$('clear-replay').disabled=true;state.replayRequest='';toast('Replay cleared')}

    $('open-page').addEventListener('click',()=>{try{const url=new URL($('target-url').value.trim());if(!/^https?:$/.test(url.protocol))throw new Error('Use an HTTP or HTTPS address.');const opened=window.open(url.href,'_blank','noopener,noreferrer');if(opened===null)toast('Page opened, or the popup was blocked');else toast('Interactive page opened')}catch(error){archiveReport(error?.message||String(error),true)}});
    $('copy-serialize').addEventListener('click',()=>writeClipboard(serializeCommand,'Serialize command copied').catch(error=>archiveReport(error.message,true)));
    $('copy-media-command').addEventListener('click',()=>writeClipboard(mediaDownloadCommand,'Media command copied').catch(error=>archiveReport(error.message,true)));
    $('paste-capture').addEventListener('click',async()=>{try{const captured=await navigator.clipboard.readText();if(!captured.trim())throw new Error('The clipboard does not contain serialized HTML.');$('source').value=captured;$('input-meta').textContent=detectText(captured);updateInputStats(new TextEncoder().encode(captured).length);convertText();toast('Captured HTML pasted')}catch(error){archiveReport(error?.message||String(error),true)}});
    const assets=$('assets'),assetDrop=$('asset-drop'); assetDrop.addEventListener('click',()=>assets.click()); assets.addEventListener('change',()=>addAssetFiles(assets.files));
    ['dragenter','dragover','dragleave','drop'].forEach(name=>assetDrop.addEventListener(name,event=>{event.preventDefault();event.stopPropagation()})); assetDrop.addEventListener('dragover',()=>assetDrop.classList.add('over')); assetDrop.addEventListener('dragleave',()=>assetDrop.classList.remove('over')); assetDrop.addEventListener('drop',event=>{assetDrop.classList.remove('over');addAssetFiles(event.dataTransfer.files)});
    $('clear-assets').addEventListener('click',()=>{state.assetFiles=[];assets.value='';archiveReport('No local media selected. Remote media will be attempted only when its server permits browser access.');toast('Local media cleared')}); $('build-archive').addEventListener('click',buildBrowserArchive);
    $('deepwiki-open-copy').addEventListener('click',()=>copyDeepWikiExporter(true));$('deepwiki-copy').addEventListener('click',()=>copyDeepWikiExporter(false));
    $('replay-frame').addEventListener('load',()=>{const frame=$('replay-frame');if(!frame.srcdoc)return;$('replay-status').classList.add('ready');$('replay-status').querySelector('span').textContent='Interactive replay ready';$('capture-replay').disabled=false;$('export-replay').disabled=false});
    $('load-replay').addEventListener('click',loadReplay);$('clear-replay').addEventListener('click',clearReplay);$('capture-replay').addEventListener('click',()=>{state.replayRequest=crypto.randomUUID?.()||String(Date.now());$('replay-frame').contentWindow?.postMessage({channel:'webclip:host',type:'serialize',requestId:state.replayRequest},'*');$('replay-status').querySelector('span').textContent='Serializing current replay state…'});$('export-replay').addEventListener('click',()=>{$('replay-frame').contentWindow?.postMessage({channel:'webclip:host',type:'export-svg',scale:Math.min(6,Math.max(2,Number($('deepwiki-scale').value)||4))},'*');$('replay-status').querySelector('span').textContent='Rasterizing replay charts…'});
    window.addEventListener('message',event=>{const frame=$('replay-frame');if(event.source!==frame.contentWindow||event.data?.channel!=='webclip:replay')return;if(event.data.type==='ready'){$('replay-status').classList.add('ready');$('replay-status').querySelector('span').textContent='Interactive replay ready';$('replay-title').textContent=event.data.title||'Sandboxed replay';$('capture-replay').disabled=false;$('export-replay').disabled=false}else if(event.data.type==='serialized'&&event.data.requestId===state.replayRequest){const html=String(event.data.html||'');if(!html||html.length>30000000){archiveReport('Replay serialization was empty or exceeded the 30 MB safety limit.',true);return}$('source').value=html;$('input-meta').textContent='Replay capture';updateInputStats(new TextEncoder().encode(html).length);convertText();$('replay-status').querySelector('span').textContent='Replay state captured back to Source';toast('Replay state serialized')}else if(event.data.type==='exported'){$('replay-status').querySelector('span').textContent=`${event.data.count} replay chart${event.data.count===1?'':'s'} exported`;toast('Replay chart ZIP downloaded')}else if(event.data.type==='export-error'){$('replay-status').querySelector('span').textContent=event.data.message;archiveReport(event.data.message,true)}});
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
