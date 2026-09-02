module ConvertedFiles.Link.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1" ]
            meta [ attr "name" "color-scheme"; attr "content" "dark light" ]
            meta [ attr "name" "theme-color"; attr "content" "#111512" ]
            meta [ attr "http-equiv" "Content-Security-Policy"; attr "content" "default-src 'self'; connect-src https: http:; img-src 'self' data: blob: https: http:; media-src data: blob: https: http:; style-src 'self' 'unsafe-inline'; script-src 'self' 'unsafe-inline' 'unsafe-eval' https:; frame-src 'self' data: blob:; object-src 'none'; base-uri 'self'; form-action 'none'" ]
            meta [ attr "name" "description"; attr "content" "Lossless text and code carried entirely in a link." ]
            title [] [
                str "ln.kr · text in the link"
            ]
            script [ _type "module"; attr "crossorigin" ""; _src "/assets/index.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/assets/index.css" ]
        ]
        body [] [
            header [ _class "site-header" ] [
                a [ _class "wordmark"; _href "./"; attr "aria-label" "ln.kr home" ] [
                    span [ _class "wordmark-mark" ] [
                        str "ln"
                    ]
                    span [ _class "wordmark-dot" ] [
                        str "."
                    ]
                    span [] [
                        str "kr"
                    ]
                ]
                span [ _class "project-note" ] [
                    str "(a.shel.sh project)"
                ]
                span [ _class "header-rule"; attr "aria-hidden" "true" ] []
                p [] [
                    str "text in the link"
                ]
                div [ _class "header-actions" ] [
                    button [ _id "about-open"; _class "header-button"; _type "button"; attr "aria-haspopup" "dialog" ] [
                        str "About"
                    ]
                    a [ _class "header-link"; _href "https://github.com/p2r3/ha.mr"; attr "target" "_blank"; attr "rel" "noopener noreferrer" ] [
                        str "ha.mr lineage ↗"
                    ]
                ]
            ]
            main [] [
                section [ _id "composer"; _class "composer"; attr "hidden" "" ] [
                    form [ _id "composer-form"; _class "editor-card" ] [
                        div [ _class "editor-bar" ] [
                            label [ attr "for" "source-input" ] [
                                str "Source"
                            ]
                            span [ _id "source-count" ] [
                                str "0 characters · 0 UTF-8 bytes"
                            ]
                        ]
                        tag "textarea" [ _id "source-input"; attr "placeholder" "# A small document\n\nPaste Markdown, JavaScript, HTML, or exact plain text here…"; attr "spellcheck" "false"; attr "autofocus" "" ] []
                        div [ _class "controls" ] [
                            label [ _class "select-control" ] [
                                span [] [
                                    str "Render as"
                                ]
                                select [ _id "source-format"; attr "autocomplete" "off" ] [
                                    option [ attr "value" "auto" ] [
                                        str "Auto detect"
                                    ]
                                    option [ attr "value" "markdown" ] [
                                        str "Markdown"
                                    ]
                                    option [ attr "value" "javascript" ] [
                                        str "JavaScript"
                                    ]
                                    option [ attr "value" "html" ] [
                                        str "HTML"
                                    ]
                                    option [ attr "value" "text" ] [
                                        str "Plain text"
                                    ]
                                ]
                            ]
                            label [ _class "toggle" ] [
                                input [ _type "checkbox"; _id "setting-emoji"; attr "autocomplete" "off" ]
                                span [ _class "toggle-track"; attr "aria-hidden" "true" ] []
                                span [] [
                                    str "Emoji alphabet"
                                ]
                            ]
                            label [ _class "toggle" ] [
                                input [ _type "checkbox"; _id "setting-qr"; attr "autocomplete" "off" ]
                                span [ _class "toggle-track"; attr "aria-hidden" "true" ] []
                                span [] [
                                    str "Build QR"
                                ]
                            ]
                            button [ _id "create-link"; _class "primary"; _type "submit" ] [
                                str "Create ln.kr link"
                            ]
                        ]
                    ]
                    section [ _id "link-result"; _class "result-card"; attr "aria-live" "polite"; attr "hidden" "" ] [
                        div [ _class "result-heading" ] [
                            div [] [
                                p [ _class "eyebrow" ] [
                                    str "Encoded locally"
                                ]
                                h2 [] [
                                    str "Your document is the URL."
                                ]
                            ]
                            span [ _class "success-dot"; attr "aria-label" "ready" ] []
                        ]
                        label [ _class "link-field" ] [
                            span [] [
                                str "Share link"
                            ]
                            tag "textarea" [ _id "output-link"; attr "rows" "3"; attr "readonly" "" ] []
                        ]
                        p [ _id "result-meta"; _class "result-meta" ] []
                        p [ _id "result-warning"; _class "warning"; attr "hidden" "" ] [
                            str "This is a very long URL. The codec is valid, but a chat app, browser, or QR scanner may impose its own length limit."
                        ]
                        div [ _class "result-actions" ] [
                            button [ _id "copy-link"; _class "primary"; _type "button" ] [
                                str "Copy link"
                            ]
                            button [ _id "copy-run-link"; _class "auto-run-action"; _type "button"; attr "hidden" "" ] [
                                str "Copy auto-run link"
                            ]
                            a [ _id "open-link"; _class "button"; attr "target" "_blank"; attr "rel" "noopener" ] [
                                str "Open viewer ↗"
                            ]
                        ]
                        figure [ _id "qr-wrap"; _class "qr-wrap"; attr "hidden" "" ] [
                            canvas [ _id "qrcode" ] []
                            figcaption [] [
                                str "QR uses ha.mr’s alphanumeric alphabet and automatic error correction."
                            ]
                        ]
                    ]
                ]
                section [ _id "viewer"; _class "viewer"; attr "hidden" "" ] [
                    details [ _class "viewer-details" ] [
                        summary [] [
                            span [] [
                                str "Document details"
                            ]
                            span [ _id "viewer-summary"; _class "viewer-summary" ] [
                                str "text · format v1"
                            ]
                        ]
                        div [ _class "viewer-heading" ] [
                            div [] [
                                p [ _class "eyebrow" ] [
                                    str "Self-contained document"
                                ]
                                h1 [] [
                                    span [ _id "viewer-kind" ] [
                                        str "text"
                                    ]
                                    em [] [
                                        str "from the link."
                                    ]
                                ]
                                p [ _id "viewer-meta"; _class "viewer-meta" ] []
                            ]
                            button [ _id "edit-source"; _class "button"; _type "button" ] [
                                str "Edit a copy"
                            ]
                        ]
                        aside [ _class "scope-note" ] [
                            strong [] [
                                str "NOTE"
                            ]
                            p [] [
                                b [] [
                                    str "Run in parent scope"
                                ]
                                str "executes shared JavaScript directly on ln.kr with access to this page, its URL, browser APIs, and ordinary network requests. It can replace the interface or navigate away. Leave it unchecked to use the isolated sandbox."
                                b [] [
                                    str "Allow network requests"
                                ]
                                str "opens remote resources inside that otherwise unique-origin sandbox."
                            ]
                        ]
                    ]
                    div [ _class "action-bar"; attr "aria-label" "Document actions" ] [
                        button [ _id "copy-raw"; _type "button" ] [
                            str "Copy raw"
                        ]
                        button [ _id "copy-rich"; _type "button" ] [
                            str "Copy rich"
                        ]
                        button [ _id "copy-jsfuck"; _type "button" ] [
                            str "Copy JSFuck"
                        ]
                        button [ _id "copy-invisible"; _type "button" ] [
                            str "Copy invisible"
                        ]
                        label [ _id "run-scope-control"; _class "action-toggle" ] [
                            input [ _id "run-parent-scope"; _type "checkbox"; attr "autocomplete" "off" ]
                            span [] [
                                str "Run in parent scope"
                            ]
                        ]
                        label [ _id "network-control"; _class "action-toggle" ] [
                            input [ _id "run-network"; _type "checkbox"; attr "autocomplete" "off" ]
                            span [] [
                                str "Allow network requests"
                            ]
                        ]
                        button [ _id "run-code"; _class "run-button"; _type "button" ] [
                            str "Run in sandbox"
                        ]
                    ]
                    div [ _class "document-shell" ] [
                        div [ _class "tabs"; attr "role" "tablist"; attr "aria-label" "Document view" ] [
                            button [ _id "tab-rendered"; attr "role" "tab"; attr "aria-selected" "true"; _type "button" ] [
                                str "Rendered"
                            ]
                            button [ _id "tab-source"; attr "role" "tab"; attr "aria-selected" "false"; _type "button" ] [
                                str "Exact source"
                            ]
                        ]
                        article [ _id "preview"; _class "preview" ] []
                        pre [ _id "source-view"; _class "source-view"; attr "hidden" "" ] []
                    ]
                    section [ _id "runner"; _class "runner"; attr "hidden" "" ] [
                        div [ _class "runner-head" ] [
                            div [] [
                                span [ _class "live-dot" ] []
                                strong [] [
                                    str "Isolated preview"
                                ]
                                small [ _id "runner-status" ] [
                                    str "Scripts allowed · network blocked · unique origin"
                                ]
                            ]
                            div [ _class "runner-actions" ] [
                                button [ _id "expand-run"; _type "button"; attr "aria-expanded" "false" ] [
                                    str "Expand viewer"
                                ]
                                button [ _id "stop-run"; _type "button" ] [
                                    str "Stop & clear"
                                ]
                                button [ _id "collapse-run"; _class "runner-close"; _type "button"; attr "aria-label" "Close expanded viewer"; attr "hidden" "" ] [
                                    str "×"
                                ]
                            ]
                        ]
                        iframe [ _id "runner-frame"; attr "title" "Sandboxed document output"; attr "sandbox" "allow-scripts" ] []
                        div [ _id "runner-log"; _class "runner-log"; attr "aria-live" "polite" ] []
                    ]
                ]
            ]
            dialog [ _id "about-dialog"; _class "modal about-dialog"; attr "aria-labelledby" "about-title" ] [
                div [ _class "modal-head" ] [
                    span [ _class "eyebrow" ] [
                        str "About ln.kr"
                    ]
                    button [ _id "about-close"; _class "icon-button"; _type "button"; attr "aria-label" "Close About" ] [
                        str "×"
                    ]
                ]
                div [ _class "hero" ] [
                    p [ _class "eyebrow" ] [
                        str "No account. No paste database. No server payload."
                    ]
                    h1 [ _id "about-title" ] [
                        str "Turn exact source into"
                        br []
                        em [] [
                            str "one self-contained link."
                        ]
                    ]
                    p [ _class "hero-copy" ] [
                        str "Code, Markdown, notes, whitespace, line endings, and Unicode survive byte-for-byte. Repeated blocks collapse into references; the browser does everything."
                    ]
                ]
                p [ _class "modal-copy" ] [
                    str "The payload stays in the URL fragment and is decoded locally. ln.kr retains ha.mr’s BigInt engine and its ASCII, QR, and emoji alphabets, then adds an exact code-and-text grammar above it."
                ]
            ]
            footer [] [
                span [] [
                    str "ln.kr keeps payloads in the fragment—nothing is uploaded."
                ]
                span [] [
                    str "Codec lineage:"
                    a [ _href "https://github.com/p2r3/ha.mr"; attr "target" "_blank"; attr "rel" "noopener noreferrer" ] [
                        str "p2r3/ha.mr"
                    ]
                ]
            ]
            div [ _id "toast"; _class "toast"; attr "role" "status"; attr "hidden" "" ] []
            script [ _src "/vendor/marked.umd.js" ] [ rawText ("""""") ]
            script [ _src "/vendor/highlight.min.js" ] [ rawText ("""""") ]
            script [ _src "/vendor/jsfuck.js" ] [ rawText ("""""") ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
