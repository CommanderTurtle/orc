module ComfyUI.Comfystatic.LinkImportHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "http-equiv" "Content-Security-Policy"; attr "content" "default-src 'none'; script-src 'self'; connect-src https: http:; base-uri 'none'; form-action 'none'" ]
            title [] [
                str "Workflow link importer"
            ]
            script [ attr "defer" ""; _src "./link-import.js" ] [ rawText ("""""") ]
        ]
        body [] []
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
