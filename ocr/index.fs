module PPOCR.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width,initial-scale=1" ]
            title [] [
                str "OCR"
            ]
            link [ attr "rel" "icon"; _href "data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg'/%3E" ]
            link [ attr "rel" "stylesheet"; _href "./style.css" ]
        ]
        body [] [
            main [] [
                header [] [
                    div [] [
                        p [ _class "eyebrow" ] [
                            str "Local vision · CPU / WASM"
                        ]
                        h1 [] [
                            str "OCR"
                            span [] [
                                str "& perception"
                            ]
                        ]
                    ]
                    a [ _href "./README.md" ] [
                        str "API & deployment ↗"
                    ]
                ]
                section [ _class "toolbar" ] [
                    label [] [
                        str "Engine"
                        select [ _id "engine" ] [
                            option [ attr "value" "paddle" ] [
                                str "Paddle · text"
                            ]
                            option [ attr "value" "mirage" ] [
                                str "Mirage · perception"
                            ]
                        ]
                    ]
                    label [ _class "file" ] [
                        str "Choose image"
                        input [ _id "file"; _type "file"; attr "accept" "image/*" ]
                    ]
                    label [ _id "backend-field" ] [
                        str "Runtime"
                        select [ _id "backend" ] [
                            option [ attr "value" "wasm" ] [
                                str "CPU / WASM"
                            ]
                            option [ attr "value" "auto" ] [
                                str "WebGPU with CPU fallback"
                            ]
                            option [ attr "value" "webgpu" ] [
                                str "WebGPU only"
                            ]
                        ]
                    ]
                    button [ _id "run"; attr "disabled" "" ] [
                        str "Recognize"
                    ]
                    button [ _id "cancel"; attr "disabled" "" ] [
                        str "Cancel"
                    ]
                ]
                div [ _id "mirage-options"; attr "hidden" "" ] [
                    div [ _class "settings-row" ] [
                        label [] [
                            str "Task"
                            select [ _id "task" ] [
                                option [ attr "value" "describe" ] [
                                    str "Describe image"
                                ]
                                option [ attr "value" "extract" ] [
                                    str "Answer a structured form"
                                ]
                            ]
                        ]
                        label [] [
                            str "Language"
                            select [ _id "language" ] [
                                option [ attr "value" "en" ] [
                                    str "English"
                                ]
                                option [ attr "value" "de" ] [
                                    str "Deutsch"
                                ]
                                option [ attr "value" "fr" ] [
                                    str "Français"
                                ]
                                option [ attr "value" "es" ] [
                                    str "Español"
                                ]
                                option [ attr "value" "it" ] [
                                    str "Italiano"
                                ]
                                option [ attr "value" "nl" ] [
                                    str "Nederlands"
                                ]
                                option [ attr "value" "pl" ] [
                                    str "Polski"
                                ]
                            ]
                        ]
                        span [ _class "model-note" ] [
                            str "51M · 22 MB · on-device"
                        ]
                    ]
                    fieldset [ _id "sections" ] [
                        legend [] [
                            str "Include"
                        ]
                        label [] [
                            input [ _type "checkbox"; attr "value" "scene"; attr "checked" "" ]
                            str "Scene"
                        ]
                        label [] [
                            input [ _type "checkbox"; attr "value" "objects"; attr "checked" "" ]
                            str "Objects"
                        ]
                        label [] [
                            input [ _type "checkbox"; attr "value" "text"; attr "checked" "" ]
                            str "Text"
                        ]
                        label [] [
                            input [ _type "checkbox"; attr "value" "regions" ]
                            str "Regions"
                        ]
                        label [] [
                            input [ _type "checkbox"; attr "value" "relations"; attr "checked" "" ]
                            str "Relations"
                        ]
                        label [] [
                            input [ _type "checkbox"; attr "value" "events" ]
                            str "Events"
                        ]
                        label [] [
                            input [ _type "checkbox"; attr "value" "reasoning" ]
                            str "Reasoning"
                        ]
                    ]
                    div [ _id "form-field"; attr "hidden" "" ] [
                        div [ _class "settings-row" ] [
                            label [] [
                                str "Preset"
                                select [ _id "preset" ] [
                                    option [ attr "value" "sign" ] [
                                        str "Sign type"
                                    ]
                                    option [ attr "value" "scene" ] [
                                        str "Scene & count"
                                    ]
                                    option [ attr "value" "custom" ] [
                                        str "Custom form"
                                    ]
                                ]
                            ]
                            span [ _class "model-note" ] [
                                str "Choices, bounded counts, strings and box references"
                            ]
                        ]
                        tag "textarea" [ _id "schema"; attr "aria-label" "Structured form JSON"; attr "spellcheck" "false" ] [
                            str "{\"sign\":{\"enum\":[\"stop\",\"yield\",\"speed limit\"]}}"
                        ]
                    ]
                    details [ _id "advanced" ] [
                        summary [] [
                            str "Detection settings"
                        ]
                        div [ _class "settings-row" ] [
                            label [] [
                                str "Object confidence"
                                input [ _id "confidence"; _type "number"; attr "min" "0"; attr "max" "1"; attr "step" "0.05"; attr "value" "0.5"; attr "required" "" ]
                            ]
                            label [] [
                                str "Text confidence"
                                input [ _id "text-confidence"; _type "number"; attr "min" "0"; attr "max" "1"; attr "step" "0.05"; attr "value" "0.35"; attr "required" "" ]
                            ]
                            label [] [
                                str "Objects"
                                input [ _id "max-objects"; _type "number"; attr "min" "1"; attr "max" "200"; attr "value" "20"; attr "required" "" ]
                            ]
                            label [] [
                                str "Text lines"
                                input [ _id "max-lines"; _type "number"; attr "min" "1"; attr "max" "500"; attr "value" "40"; attr "required" "" ]
                            ]
                            label [] [
                                str "Tokens"
                                input [ _id "max-tokens"; _type "number"; attr "min" "16"; attr "max" "4096"; attr "value" "512"; attr "required" "" ]
                            ]
                            label [] [
                                str "Masks"
                                select [ _id "mask-format" ] [
                                    option [ attr "value" "polygons" ] [
                                        str "Polygons"
                                    ]
                                    option [ attr "value" "largest" ] [
                                        str "Largest"
                                    ]
                                    option [ attr "value" "merged" ] [
                                        str "Merged"
                                    ]
                                ]
                            ]
                            label [] [
                                input [ _id "nms"; _type "checkbox"; attr "checked" "" ]
                                str "Suppress duplicate boxes"
                            ]
                            label [] [
                                str "Keyword hints"
                                input [ _id "keywords"; _type "text"; attr "placeholder" "Names, signs, labels"; attr "maxlength" "2000" ]
                            ]
                        ]
                    ]
                ]
                p [ _id "status"; attr "role" "status" ] [
                    str "Choose, drop, or paste an image. Nothing is uploaded."
                ]
                div [ _class "panels" ] [
                    section [ _id "drop"; _class "source" ] [
                        div [ _class "heading" ] [
                            h2 [] [
                                str "Source"
                            ]
                            label [ _id "overlay-field"; attr "hidden" "" ] [
                                input [ _id "show-overlay"; _type "checkbox"; attr "checked" "" ]
                                str "Overlays"
                            ]
                        ]
                        div [ _class "image" ] [
                            div [ _id "image-stage"; attr "hidden" "" ] [
                                img [ _id "preview"; _alt "Selected image" ]
                                tag "svg" [ _id "overlay"; attr "viewBox" "0 0 1000 1000"; attr "preserveAspectRatio" "none"; attr "aria-label" "Detected regions" ] []
                            ]
                            p [ _id "placeholder" ] [
                                str "Drop an image here"
                                br []
                                span [] [
                                    str "or paste from your clipboard"
                                ]
                            ]
                        ]
                    ]
                    section [ _class "output" ] [
                        div [ _class "heading" ] [
                            h2 [ _id "output-title" ] [
                                str "Text"
                            ]
                            button [ _id "copy"; attr "disabled" "" ] [
                                str "Copy"
                            ]
                            button [ _id "save"; attr "disabled" "" ] [
                                str "JSON"
                            ]
                        ]
                        nav [ _id "result-tabs"; attr "aria-label" "Result views"; attr "hidden" "" ] [
                            button [ attr "data-view" "overview"; attr "aria-pressed" "true" ] [
                                str "Overview"
                            ]
                            button [ attr "data-view" "objects"; attr "aria-pressed" "false" ] [
                                str "Objects"
                            ]
                            button [ attr "data-view" "text"; attr "aria-pressed" "false" ] [
                                str "Text"
                            ]
                            button [ attr "data-view" "relations"; attr "aria-pressed" "false" ] [
                                str "Relations"
                            ]
                            button [ attr "data-view" "form"; attr "aria-pressed" "false" ] [
                                str "Decisions"
                            ]
                            button [ attr "data-view" "json"; attr "aria-pressed" "false" ] [
                                str "JSON"
                            ]
                        ]
                        div [ _id "insights"; attr "hidden" "" ] []
                        tag "textarea" [ _id "text"; attr "aria-label" "Recognized text"; attr "spellcheck" "false"; attr "placeholder" "Recognized text appears here" ] []
                    ]
                ]
                footer [] [
                    span [ _id "details" ] [
                        str "Only the selected engine loads, when you run it. Model memory is released after each run."
                    ]
                    span [] [
                        str "PP-OCRv6 ·"
                        a [ _href "https://cactuscompute.com/blog/mirage"; attr "target" "_blank"; attr "rel" "noopener noreferrer" ] [
                            str "Cactus Mirage"
                        ]
                    ]
                ]
            ]
            script [ _type "module"; _src "./demo.js" ] [ rawText ("""""") ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
