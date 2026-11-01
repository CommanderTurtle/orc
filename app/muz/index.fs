module Muz.IndexHtml

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
            link [ attr "rel" "stylesheet"; _href "./assets/studio.css" ]
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
                    button [ _id "catalog" ] [
                        str "Library"
                    ]
                    button [ _id "share"; _class "accent" ] [
                        str "Share"
                    ]
                    button [ _id "reference" ] [
                        str "Reference"
                    ]
                    button [ _id "open-workbench"; attr "title" "Open this project in the bundled upstream muzpad workbench" ] [
                        str "Workbench ↗"
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
                button [ _id "edit-tempo"; attr "title" "Set the source tempo" ] [
                    str "Tempo"
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
                button [ _id "export-stems" ] [
                    str "Stems ↓"
                ]
                button [ _id "export-daw" ] [
                    str "DAWProject ↓"
                ]
                button [ _id "save-project" ] [
                    str "Project ↓"
                ]
            ]
            section [ _class "timeline-bar"; attr "aria-label" "Timeline transport" ] [
                input [ _id "seek"; _type "range"; attr "min" "0"; attr "max" "1"; attr "step" "1"; attr "value" "0"; attr "disabled" ""; attr "aria-label" "Playback position"; attr "title" "Drag to seek; arrow keys move the playhead" ]
                label [] [
                    input [ _id "loop-enabled"; _type "checkbox" ]
                    str "Loop"
                ]
                button [ _id "loop-in"; attr "title" "Set loop start at playhead" ] [
                    str "In"
                ]
                button [ _id "loop-out"; attr "title" "Set loop end at playhead" ] [
                    str "Out"
                ]
                output [ _id "loop-label" ] [
                    str "Whole song"
                ]
                select [ _id "section"; attr "aria-label" "Jump to section" ] [
                    option [ attr "value" "" ] [
                        str "Sections"
                    ]
                ]
                label [ attr "title" "Valid edits apply atomically; errors keep the accepted audio" ] [
                    input [ _id "live"; _type "checkbox" ]
                    str "Live"
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
                    div [ _class "source-tools" ] [
                        button [ _id "undo"; attr "disabled" "" ] [
                            str "Undo"
                        ]
                        button [ _id "redo"; attr "disabled" "" ] [
                            str "Redo"
                        ]
                        button [ _id "format-source" ] [
                            str "Format"
                        ]
                        button [ _id "studio-source"; attr "title" "View generated native muz edits" ] [
                            str "Studio source"
                        ]
                        button [ _id "detach-studio"; attr "title" "Keep the generated source and stop managing it visually"; attr "hidden" "" ] [
                            str "Detach"
                        ]
                    ]
                    div [ _class "revision-tools" ] [
                        select [ _id "revisions"; attr "aria-label" "Accepted source revision" ] [
                            option [ attr "value" "" ] [
                                str "Accepted revisions"
                            ]
                        ]
                        button [ _id "restore-revision"; attr "disabled" "" ] [
                            str "Restore source"
                        ]
                        span [ _class "tag" ] [
                            str "Session history"
                        ]
                    ]
                    div [ _class "editor-wrap" ] [
                        pre [ _id "line-numbers"; attr "aria-hidden" "true" ] [
                            str "1"
                        ]
                        div [ _class "code-stack" ] [
                            pre [ _id "code-colors"; attr "aria-hidden" "true" ] []
                            tag "textarea" [ _id "editor"; attr "aria-label" "Muz source"; attr "aria-describedby" "lint-state"; attr "spellcheck" "false"; attr "autocapitalize" "off"; attr "autocomplete" "off"; attr "autocorrect" "off"; attr "wrap" "off" ] []
                        ]
                    ]
                    div [ _class "editor-footer" ] [
                        span [ _id "file-info" ] [
                            str "UTF-8"
                        ]
                        button [ _id "lint-state"; attr "title" "Native muz parser" ] [
                            str "Syntax"
                        ]
                        span [] [
                            str "Ctrl+S compile · Ctrl+Enter play"
                        ]
                    ]
                ]
                section [ _class "output-panel"; attr "aria-label" "Compiled music" ] [
                    div [ _class "panel-heading" ] [
                        div [ _class "view-tabs" ] [
                            button [ _id "view-arrangement"; attr "aria-pressed" "true" ] [
                                str "Arrangement"
                            ]
                            button [ _id "view-piano"; attr "aria-pressed" "false" ] [
                                str "Piano roll"
                            ]
                            button [ _id "view-inspect"; attr "aria-pressed" "false" ] [
                                str "Inspect"
                            ]
                        ]
                        span [ _id "score-info"; _class "tag" ] [
                            str "Not compiled"
                        ]
                    ]
                    div [ _id "arrangement-panel"; _class "score-scroll" ] [
                        div [ _id "tracks"; _class "tracks" ] []
                        div [ _id "empty-score" ] [
                            str "Compile a .muz file to view its score."
                        ]
                    ]
                    section [ _id "piano-panel"; _class "studio-panel"; attr "hidden" "" ] [
                        div [ _class "studio-toolbar" ] [
                            select [ _id "piano-track"; attr "aria-label" "Piano-roll track" ] []
                            button [ _id "add-track" ] [
                                str "+ Track"
                            ]
                            label [] [
                                str "Snap"
                                select [ _id "grid" ] [
                                    option [ attr "value" "0.25" ] [
                                        str "1/16"
                                    ]
                                    option [ attr "value" "0.5" ] [
                                        str "1/8"
                                    ]
                                    option [ attr "value" "1" ] [
                                        str "1/4"
                                    ]
                                    option [ attr "value" "0" ] [
                                        str "Off"
                                    ]
                                ]
                            ]
                            label [] [
                                str "Zoom"
                                input [ _id "zoom"; _type "range"; attr "min" "12"; attr "max" "160"; attr "value" "44"; attr "aria-label" "Piano-roll zoom" ]
                            ]
                        ]
                        div [ _id "piano-scroll"; _class "piano-scroll" ] [
                            div [ _id "piano-space" ] [
                                canvas [ _id "piano-roll"; attr "tabindex" "0"; attr "role" "application"; attr "aria-label" "Piano roll. Double-click to add a note; drag to move or resize; Delete removes selected note." ] []
                            ]
                        ]
                        form [ _id "note-form"; _class "note-form" ] [
                            label [] [
                                str "Beat"
                                input [ _id "note-beat"; _type "number"; attr "min" "0"; attr "max" "100000"; attr "step" "any"; attr "required" "" ]
                            ]
                            label [] [
                                str "Length"
                                input [ _id "note-length"; _type "number"; attr "min" "0.000001"; attr "max" "100000"; attr "step" "any"; attr "required" "" ]
                            ]
                            label [] [
                                str "Key"
                                input [ _id "note-pitch"; _type "number"; attr "min" "0"; attr "max" "127"; attr "step" "1"; attr "required" "" ]
                            ]
                            label [] [
                                str "Velocity"
                                input [ _id "note-velocity"; _type "number"; attr "min" "0"; attr "max" "1"; attr "step" "any"; attr "required" "" ]
                            ]
                            button [ _type "submit" ] [
                                str "Set note"
                            ]
                            button [ _id "delete-note"; _type "button" ] [
                                str "Delete"
                            ]
                        ]
                        div [ _class "studio-toolbar" ] [
                            button [ _id "apply-notes"; _class "primary" ] [
                                str "Apply notes"
                            ]
                            button [ _id "quantize-notes" ] [
                                str "Quantize"
                            ]
                            button [ _id "revert-notes" ] [
                                str "Revert"
                            ]
                            button [ _id "delete-track" ] [
                                str "Remove track"
                            ]
                            span [ _id "piano-info"; _class "tag" ] [
                                str "Select a track."
                            ]
                        ]
                        p [ _class "studio-help" ] [
                            str "Double-click adds; drag moves; drag a note’s right edge resizes. Apply writes a native .muz wrapper and preserves original source. Replacing notes freezes the displayed performance; MIDI and kit internals stay source-edited."
                        ]
                    ]
                    section [ _id "inspect-panel"; _class "studio-panel"; attr "hidden" "" ] [
                        div [ _class "studio-toolbar" ] [
                            select [ _id "inspect-view"; attr "aria-label" "Engine inspection view" ] [
                                option [] [
                                    str "graph"
                                ]
                                option [] [
                                    str "automation"
                                ]
                                option [] [
                                    str "automation_points"
                                ]
                                option [] [
                                    str "sections"
                                ]
                                option [] [
                                    str "track_groups"
                                ]
                                option [] [
                                    str "patches"
                                ]
                                option [] [
                                    str "patch_nodes"
                                ]
                                option [] [
                                    str "diagnostics"
                                ]
                            ]
                            button [ _id "inspect-refresh" ] [
                                str "Refresh"
                            ]
                            button [ _id "inspect-prev" ] [
                                str "Previous"
                            ]
                            button [ _id "inspect-next" ] [
                                str "Next"
                            ]
                            span [ _id "inspect-info"; _class "tag" ] []
                        ]
                        pre [ _id "inspect-output" ] [
                            str "Compile a song to inspect the engine graph."
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
                button [ _id "download-module" ] [
                    str "Download .muz"
                ]
                pre [ _id "library-source" ] []
                p [] [
                    str "WAV/FLAC samples, MIDI, and SFZ can be imported with a project folder or Library. DAWProject includes rendered audio and editable note lanes; native VST3/CLAP binaries remain desktop-only."
                ]
                a [ _href "https://github.com/apage43/muz/blob/main/docs/language.md"; attr "target" "_blank"; attr "rel" "noreferrer" ] [
                    str "Full muz language reference ↗"
                ]
                p [ _id "provenance" ] []
            ]
            dialog [ _id "catalog-dialog"; _class "reference-dialog" ] [
                div [ _class "dialog-heading" ] [
                    h2 [] [
                        str "Library"
                    ]
                    button [ _class "close"; attr "aria-label" "Close" ] [
                        str "×"
                    ]
                ]
                p [] [
                    str "Browse pinned upstream sample manifests, or open a CORS-readable catalog. Downloads happen only for selected resources and become project-local assets."
                ]
                form [ _id "catalog-form" ] [
                    label [] [
                        str "Catalog URL"
                        input [ _id "catalog-url"; _type "url"; attr "placeholder" "https://…/catalog.json" ]
                    ]
                    div [ _class "dialog-actions" ] [
                        select [ _id "catalog-pack"; attr "aria-label" "Bundled sample catalog" ] [
                            option [ attr "value" "" ] [
                                str "Choose a bundled catalog"
                            ]
                        ]
                        button [ _type "submit" ] [
                            str "Open URL"
                        ]
                    ]
                ]
                p [ _id "catalog-info"; attr "role" "status" ] []
                input [ _id "catalog-search"; _type "text"; attr "aria-label" "Filter catalog"; attr "placeholder" "Filter resources…" ]
                div [ _class "catalog-controls" ] [
                    button [ _id "catalog-select" ] [
                        str "Select visible"
                    ]
                    button [ _id "catalog-clear" ] [
                        str "Clear selection"
                    ]
                    span [ _id "catalog-count" ] []
                ]
                div [ _id "catalog-files" ] []
                div [ _class "dialog-actions" ] [
                    button [ _id "catalog-import"; _class "primary" ] [
                        str "Import selected"
                    ]
                    button [ _id "catalog-cancel"; attr "hidden" "" ] [
                        str "Cancel download"
                    ]
                ]
                p [ _id "catalog-status"; attr "role" "status" ] []
            ]
            input [ _id "file-input"; _type "file"; attr "multiple" ""; attr "hidden" "" ]
            input [ _id "folder-input"; _type "file"; attr "webkitdirectory" ""; attr "multiple" ""; attr "hidden" "" ]
            script [ _type "module"; _src "./assets/app.js" ] [ rawText ("""""") ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
