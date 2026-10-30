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
            script [ _type "module"; attr "crossorigin" ""; _src "/ocr/assets/index.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/ocr/assets/index.css" ]
        ]
        body [] [
            main [] [
                header [] [
                    div [] [
                        p [ _class "eyebrow" ] [
                            str "PP-OCRv6 · local inference"
                        ]
                        h1 [] [
                            str "OCR"
                        ]
                    ]
                    a [ _href "./README.md" ] [
                        str "API & deployment"
                    ]
                ]
                section [ _class "toolbar" ] [
                    label [ _class "file" ] [
                        str "Choose image"
                        input [ _id "file"; _type "file"; attr "accept" "image/*" ]
                    ]
                    label [] [
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
                p [ _id "status"; attr "role" "status" ] [
                    str "Choose, drop, or paste an image. Nothing is uploaded."
                ]
                div [ _class "panels" ] [
                    section [ _id "drop"; _class "source" ] [
                        h2 [] [
                            str "Source"
                        ]
                        div [ _class "image" ] [
                            img [ _id "preview"; _alt "Selected image"; attr "hidden" "" ]
                            p [ _id "placeholder" ] [
                                str "Drop an image here"
                            ]
                        ]
                    ]
                    section [] [
                        div [ _class "heading" ] [
                            h2 [] [
                                str "Text"
                            ]
                            button [ _id "copy"; attr "disabled" "" ] [
                                str "Copy"
                            ]
                            button [ _id "save"; attr "disabled" "" ] [
                                str "JSON"
                            ]
                        ]
                        tag "textarea" [ _id "text"; attr "aria-label" "Recognized text"; attr "spellcheck" "false"; attr "placeholder" "Recognized text appears here" ] []
                    ]
                ]
                footer [ _id "details" ] [
                    str "CPU is the default. Models stay loaded until you change runtime or close the page."
                ]
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
