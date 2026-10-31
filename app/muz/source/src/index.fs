module Muz.Source.Src.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1" ]
            meta [ attr "name" "theme-color"; attr "content" "#101419" ]
            meta [ attr "name" "description"; attr "content" "A static, local-first workspace for the muz music language." ]
            title [] [
                str "muzstatic"
            ]
            link [ attr "rel" "stylesheet"; _href "./assets/style.css" ]
        ]
        body [] [
            header [ _class "topbar" ] [
                div [ _class "brand" ] [
                    span [ _class "mark"; attr "aria-hidden" "true" ] [
                        str "m"
                        span [] [
                            str "∿"
                        ]
                    ]
                    strong [] [
                        str "muzstatic"
                    ]
                    span [ _class "tag" ] [
                        str "web workspace"
                    ]
                ]
                nav [ attr "aria-label" "Project actions" ] [
                    button [ _id "new" ] [
                        str "New"
                    ]
                    button [ _id "open-link" ] [
                        str "Open link"
                    ]
                    button [ _id "open-files" ] [
                        str "Files"
                    ]
                    button [ _id "open-folder" ] [
                        str "Folder"
                    ]
                    button [ _id "share"; _class "accent" ] [
                        str "Share"
                    ]
                    button [ _id "reference" ] [
                        str "Reference"
                    ]
                ]
            ]
            section [ _class "transport"; attr "aria-label" "Playback" ] [
                button [ _id "play"; _class "primary"; attr "title" "Play / pause (Ctrl+Enter)" ] [
                    str "▶ Play"
                ]
                button [ _id "stop"; attr "title" "Stop and return to start" ] [
                    str "■"
                ]
                button [ _id "compile"; attr "title" "Compile (Ctrl+S)" ] [
                    str "Compile"
                ]
                div [ _class "time" ] [
                    output [ _id "position" ] [
                        str "0:00.0"
                    ]
                    span [] [
                        str "/"
                    ]
                    output [ _id "duration" ] [
                        str "—"
                    ]
                ]
                span [ _id "tempo"; _class "tag" ] [
                    str "— BPM"
                ]
                label [ _class "volume" ] [
                    str "Vol"
                    input [ _id "volume"; _type "range"; attr "min" "0"; attr "max" "100"; attr "value" "70"; attr "aria-label" "Volume" ]
                ]
                div [ _class "spacer" ] []
                button [ _id "export-midi" ] [
                    str "MIDI ↓"
                ]
                button [ _id "export-wav" ] [
                    str "WAV ↓"
                ]
                button [ _id "save-project" ] [
                    str "Project ↓"
                ]
            ]
            main [] [
                section [ _class "editor-panel"; attr "aria-label" "Source editor" ] [
                    div [ _class "panel-heading" ] [
                        label [] [
                            str "PROJECT"
                            input [ _id "project-title"; attr "aria-label" "Project title"; attr "value" "Untitled" ]
                        ]
                        div [] [
                            button [ _id "add-file"; attr "title" "Add a source file" ] [
                                str "+"
                            ]
                            button [ _id "remove-file"; attr "title" "Remove selected file" ] [
                                str "−"
                            ]
                        ]
                    ]
                    div [ _class "filebar" ] [
                        select [ _id "file"; attr "aria-label" "Selected source file" ] []
                        label [ _class "entry-label" ] [
                            str "entry"
                            select [ _id "entry"; attr "aria-label" "Entry file" ] []
                        ]
                    ]
                    div [ _class "editor-wrap" ] [
                        pre [ _id "line-numbers"; attr "aria-hidden" "true" ] [
                            str "1"
                        ]
                        tag "textarea" [ _id "editor"; attr "aria-label" "Muz source"; attr "spellcheck" "false"; attr "autocapitalize" "off"; attr "autocomplete" "off"; attr "autocorrect" "off"; attr "wrap" "off" ] []
                    ]
                    div [ _class "editor-footer" ] [
                        span [ _id "file-info" ] [
                            str "UTF-8"
                        ]
                        span [] [
                            str "Ctrl+S compile · Ctrl+Enter play"
                        ]
                    ]
                ]
                section [ _class "output-panel"; attr "aria-label" "Compiled music" ] [
                    div [ _class "panel-heading" ] [
                        span [] [
                            str "SCORE"
                        ]
                        span [ _id "score-info"; _class "tag" ] [
                            str "Not compiled"
                        ]
                    ]
                    div [ _class "score-scroll" ] [
                        div [ _id "tracks"; _class "tracks" ] []
                        div [ _id "empty-score" ] [
                            str "Compile a .muz file to view its score."
                        ]
                    ]
                    section [ _class "console"; attr "aria-label" "Compiler output" ] [
                        div [ _class "panel-heading" ] [
                            span [] [
                                str "OUTPUT"
                            ]
                            button [ _id "cancel"; attr "hidden" "" ] [
                                str "Cancel"
                            ]
                        ]
                        pre [ _id "messages"; attr "role" "status"; attr "aria-live" "polite" ] [
                            str "Ready."
                        ]
                    ]
                ]
            ]
            footer [] [
                span [] [
                    span [ _class "dot" ] []
                    span [ _id "status" ] [
                        str "Local workspace"
                    ]
                ]
                span [ _id "link-state" ] [
                    str "Embedded links use ln.kr v4"
                ]
                a [ _href "./source/index.html"; attr "target" "_blank"; attr "rel" "noreferrer" ] [
                    str "Source"
                ]
                a [ _href "https://github.com/apage43/muz"; attr "target" "_blank"; attr "rel" "noreferrer" ] [
                    str "muz engine ↗"
                    span [ _id "engine-version" ] []
                ]
            ]
            dialog [ _id "link-dialog" ] [
                form [ _id "link-form" ] [
                    div [ _class "dialog-heading" ] [
                        h2 [] [
                            str "Open a project"
                        ]
                        button [ _type "button"; _class "close"; attr "aria-label" "Close" ] [
                            str "×"
                        ]
                    ]
                    label [] [
                        str "Raw URL, ln.kr link, fragment, or gist"
                        input [ _id "link-input"; _type "text"; attr "placeholder" "https://… / #s:… / #ss:…"; attr "required" ""; attr "autocomplete" "off" ]
                    ]
                    p [] [
                        str "Public sources must allow browser CORS. Links import data only; playback starts when you press Play."
                    ]
                    div [ _class "dialog-actions" ] [
                        button [ _type "submit"; _class "primary" ] [
                            str "Open"
                        ]
                    ]
                ]
            ]
            dialog [ _id "share-dialog" ] [
                div [ _class "dialog-heading" ] [
                    h2 [] [
                        str "Share project"
                    ]
                    button [ _class "close"; attr "aria-label" "Close" ] [
                        str "×"
                    ]
                ]
                p [] [
                    str "Embedded includes the project files and assets. Source links point to a raw .muz or project JSON. Superlinks point to a one-line link document."
                ]
                label [] [
                    str "Source or pointer URL (optional)"
                    input [ _id "source-input"; _type "url"; attr "placeholder" "https://…" ]
                ]
                div [ _class "dialog-actions" ] [
                    button [ _id "share-embedded"; _class "primary" ] [
                        str "Copy embedded"
                    ]
                    button [ _id "share-source" ] [
                        str "Copy source link"
                    ]
                    button [ _id "share-super" ] [
                        str "Copy superlink"
                    ]
                ]
                label [] [
                    str "Share URL"
                    tag "textarea" [ _id "share-output"; attr "readonly" ""; attr "rows" "4"; attr "aria-label" "Share URL" ] []
                ]
                p [ _id "share-status"; attr "role" "status" ] []
            ]
            dialog [ _id "reference-dialog"; _class "reference-dialog" ] [
                div [ _class "dialog-heading" ] [
                    h2 [] [
                        str "Reference"
                    ]
                    button [ _class "close"; attr "aria-label" "Close" ] [
                        str "×"
                    ]
                ]
                p [] [
                    str "The bundled standard library is the engine’s own source. Copy code into your project, or import its module name without the .muz suffix."
                ]
                select [ _id "library"; attr "aria-label" "Standard library module" ] []
                pre [ _id "library-source" ] []
                p [] [
                    str "WAV/FLAC samples, MIDI, and SFZ can be imported with a project folder. Native VST3/CLAP hosts and DAWProject compilation remain in the desktop engine."
                ]
                a [ _href "https://github.com/apage43/muz/blob/main/docs/language.md"; attr "target" "_blank"; attr "rel" "noreferrer" ] [
                    str "Full muz language reference ↗"
                ]
                p [ _id "provenance" ] []
            ]
            input [ _id "file-input"; _type "file"; attr "multiple" ""; attr "hidden" "" ]
            input [ _id "folder-input"; _type "file"; attr "webkitdirectory" ""; attr "multiple" ""; attr "hidden" "" ]
            script [ _type "module"; _src "./assets/app.js" ] [ rawText ("""""") ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
