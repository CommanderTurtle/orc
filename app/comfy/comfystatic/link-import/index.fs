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
            script [ _type "module"; attr "crossorigin" ""; _src "/comfy/assets/preload-helper-DPTP7w0o.js" ] [ rawText ("""""") ]
            script [ _type "module"; attr "crossorigin" ""; _src "/comfy/assets/inline-runtime-B-nOndV4.js" ] [ rawText ("""""") ]
            script [ _type "module"; attr "crossorigin" ""; _src "/comfy/assets/links-BKrIYetb.js" ] [ rawText ("""""") ]
            script [ _type "module"; attr "crossorigin" ""; _src "/comfy/assets/link-frame-H-REPGAy.js" ] [ rawText ("""""") ]
        ]
        body [] []
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
