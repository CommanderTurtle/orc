module Link.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1" ]
            meta [ attr "name" "color-scheme"; attr "content" "dark light" ]
            meta [ attr "name" "theme-color"; attr "content" "#111512" ]
            meta [ attr "http-equiv" "Content-Security-Policy"; attr "content" "default-src 'self'; connect-src data: https: http:; img-src 'self' data: blob: https: http:; media-src data: blob: https: http:; font-src 'self' data: https: http:; style-src 'self' 'unsafe-inline' data: https: http:; script-src 'self' 'unsafe-inline' 'unsafe-eval' data: https: http:; worker-src 'self' blob: https: http:; frame-src 'self' data: blob: https: http:; object-src 'none'; base-uri 'self' https: http:; form-action 'none'" ]
            meta [ attr "name" "description"; attr "content" "Lossless text and code carried entirely in a link." ]
            title [] [
                str "ln.kr · text in the link"
            ]
            link [ attr "rel" "icon"; _href "/assets/favicon.svg"; _type "image/svg+xml" ]
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
                p [ _id "site-mode-label" ] [
                    str "text in the link"
                ]
                button [ _id "link-mode-toggle"; _class "header-button mode-toggle"; _type "button"; attr "aria-pressed" "false" ] [
                    str "Link"
                ]
                a [ _class "header-button"; _href "https://app.shel.sh/make"; attr "target" "_blank"; attr "rel" "noopener noreferrer" ] [
                    str "/make/"
                ]
                div [ _class "header-actions" ] [
                    a [ _class "header-link"; _href "https://github.com/CommanderTurtle/ln.kr"; attr "target" "_blank"; attr "rel" "noopener noreferrer" ] [
                        str "GitHub ↗"
                    ]
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
                            fieldset [ _id "codec-control"; _class "codec-control" ] [
                                legend [] [
                                    str "Encoder"
                                ]
                                div [ _class "codec-dial" ] [
                                    input [ _type "radio"; attr "name" "codec-version"; _id "codec-v1"; attr "value" "v1"; attr "autocomplete" "off"; attr "checked" "" ]
                                    label [ attr "for" "codec-v1" ] [
                                        str "v1"
                                    ]
                                    input [ _type "radio"; attr "name" "codec-version"; _id "codec-v2"; attr "value" "v2"; attr "autocomplete" "off" ]
                                    label [ attr "for" "codec-v2" ] [
                                        str "v2"
                                    ]
                                    input [ _type "radio"; attr "name" "codec-version"; _id "codec-v3"; attr "value" "v3"; attr "autocomplete" "off" ]
                                    label [ attr "for" "codec-v3" ] [
                                        str "v3"
                                    ]
                                    span [ _class "codec-dial-thumb"; attr "aria-hidden" "true" ] []
                                ]
                            ]
                            div [ _class "deflate-control" ] [
                                label [ _class "toggle" ] [
                                    input [ _type "checkbox"; _id "setting-deflate"; attr "autocomplete" "off"; attr "aria-describedby" "deflate-tooltip" ]
                                    span [ _class "toggle-track"; attr "aria-hidden" "true" ] []
                                    span [] [
                                        str "DEFLATE v4"
                                    ]
                                ]
                                span [ _id "deflate-tooltip"; _class "control-tooltip"; attr "role" "tooltip" ] [
                                    str "Sometimes traditional DEFLATE works better when token entropy is too high."
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
                section [ _id "link-composer"; _class "composer link-composer"; attr "hidden" "" ] [
                    form [ _id "link-composer-form"; _class "editor-card" ] [
                        div [ _class "editor-bar" ] [
                            label [ attr "for" "link-source-input" ] [
                                str "Link"
                            ]
                            span [] [
                                str "Original ha.mr URL codec · encoded locally"
                            ]
                        ]
                        input [ _id "link-source-input"; _class "url-input"; _type "url"; attr "inputmode" "url"; attr "placeholder" "https://example.com/path/to/resource.webp"; attr "spellcheck" "false"; attr "autocomplete" "url" ]
                        div [ _class "controls" ] [
                            label [ _class "toggle" ] [
                                input [ _type "checkbox"; _id "link-setting-emoji"; attr "autocomplete" "off" ]
                                span [ _class "toggle-track"; attr "aria-hidden" "true" ] []
                                span [] [
                                    str "Emoji alphabet"
                                ]
                            ]
                            label [ _class "toggle" ] [
                                input [ _type "checkbox"; _id "link-setting-qr"; attr "autocomplete" "off" ]
                                span [ _class "toggle-track"; attr "aria-hidden" "true" ] []
                                span [] [
                                    str "Build QR"
                                ]
                            ]
                            label [ _class "select-control" ] [
                                span [] [
                                    str "Source as"
                                ]
                                select [ _id "link-source-format"; attr "autocomplete" "off" ] [
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
                                ]
                            ]
                            label [ _id "link-qr-correct-container"; _class "select-control qr-level"; attr "hidden" "" ] [
                                span [] [
                                    str "QR correction"
                                ]
                                input [ _id "link-qr-correct"; _type "range"; attr "min" "0"; attr "max" "3"; attr "step" "1"; attr "value" "1"; attr "autocomplete" "off" ]
                                output [ _id "link-qr-correct-label"; attr "for" "link-qr-correct" ] [
                                    str "M"
                                ]
                            ]
                            button [ _id "create-link-link"; _class "primary"; _type "submit" ] [
                                str "Compress link"
                            ]
                        ]
                    ]
                    section [ _id "url-result"; _class "result-card"; attr "aria-live" "polite"; attr "hidden" "" ] [
                        a [ _id "guarded-link-output"; _class "url-output"; attr "target" "_blank"; attr "rel" "noopener" ] []
                        p [ _id "url-result-meta"; _class "result-meta" ] []
                        div [ _class "result-actions" ] [
                            button [ _id "copy-guarded-link"; _class "primary"; _type "button" ] [
                                str "Copy link"
                            ]
                            button [ _id "copy-resolved-link"; _type "button" ] [
                                str "Copy direct"
                            ]
                            button [ _id "copy-source-link"; _type "button" ] [
                                str "Copy source"
                            ]
                            button [ _id "copy-live-source-link"; _type "button" ] [
                                str "Copy live"
                            ]
                            button [ _id "copy-framed-link"; _type "button" ] [
                                str "Copy in-frame"
                            ]
                            button [ _id "copy-super-link"; _type "button"; attr "hidden" "" ] [
                                str "Copy superlink"
                            ]
                            button [ _id "copy-image-link"; _type "button"; attr "hidden" "" ] [
                                str "Copy image"
                            ]
                            button [ _id "copy-media-link"; _type "button"; attr "hidden" "" ] [
                                str "Copy media"
                            ]
                            button [ _id "copy-pdf-link"; _type "button"; attr "hidden" "" ] [
                                str "Copy PDF"
                            ]
                        ]
                        p [ _id "link-query-warning"; _class "warning"; attr "hidden" "" ] [
                            str "Links with several query parameters can compress less efficiently."
                        ]
                        figure [ _id "link-qr-wrap"; _class "qr-wrap"; attr "hidden" "" ] [
                            canvas [ _id "link-qrcode" ] []
                            figcaption [] [
                                str "QR uses ha.mr’s alphanumeric URL alphabet and the selected correction level."
                            ]
                        ]
                    ]
                ]
                section [ _id "link-gate"; _class "link-gate"; attr "hidden" "" ] [
                    div [ _class "linkage-card" ] [
                        h1 [] [
                            str "Redirecting to"
                        ]
                        a [ _id "link-gate-target"; _class "link-target"; attr "target" "_blank"; attr "rel" "noopener noreferrer" ] []
                        div [ _class "result-actions" ] [
                            a [ _id "link-gate-proceed"; _class "button primary" ] [
                                str "Yes, redirect me →"
                            ]
                        ]
                    ]
                ]
                section [ _id "link-resolved"; _class "link-resolved"; attr "hidden" "" ] [
                    div [ _class "linkage-bar" ] [
                        div [] [
                            span [ _id "link-resolved-label"; _class "eyebrow" ] [
                                str "Linkage · #lr:"
                            ]
                            span [ _id "link-resolved-target"; _class "resolved-target" ] []
                        ]
                        div [ _class "result-actions" ] [
                            button [ _id "link-resolved-copy"; _type "button" ] [
                                str "Copy source"
                            ]
                            button [ _id "link-resolved-download"; _type "button" ] [
                                str "Download"
                            ]
                            button [ _id "link-resolved-expand"; _type "button"; attr "aria-expanded" "false" ] [
                                str "Expand frame"
                            ]
                            a [ _id "link-resolved-open"; _class "button"; attr "target" "_blank"; attr "rel" "noopener noreferrer" ] [
                                str "Open directly ↗"
                            ]
                            button [ _id "link-resolved-close"; _class "runner-close"; _type "button"; attr "aria-label" "Close expanded frame"; attr "hidden" "" ] [
                                str "×"
                            ]
                        ]
                    ]
                    iframe [ _id "link-resolved-frame"; attr "title" "Resolved link source" ] []
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
                        button [ _id "hoist-make"; _type "button"; attr "title" "Open this exact text as a file in mk.it" ] [
                            str "Hoist to Make"
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
                        div [ _class "document-head" ] [
                            div [ _class "tabs"; attr "role" "tablist"; attr "aria-label" "Document view" ] [
                                button [ _id "tab-rendered"; attr "role" "tab"; attr "aria-selected" "true"; _type "button" ] [
                                    str "Rendered"
                                ]
                                button [ _id "tab-source"; attr "role" "tab"; attr "aria-selected" "false"; _type "button" ] [
                                    str "Exact source"
                                ]
                            ]
                            div [ _id "preview-appearance"; _class "appearance-slot"; attr "hidden" "" ] []
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
                                div [ _id "runner-appearance"; _class "appearance-slot"; attr "hidden" "" ] []
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
                        iframe [ _id "runner-frame"; attr "title" "Sandboxed document output"; attr "sandbox" "allow-scripts"; attr "allow" "clipboard-write" ] []
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
                    str "Document payloads stay in fragments—there is no paste database."
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
