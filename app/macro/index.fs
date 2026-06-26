module ConvertedFiles.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Macrohard Visual Assembly"
            ]
            script [ _type "module"; attr "crossorigin" ""; _src "/macro/assets/index-DonpFP42.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/macro/assets/index-AJdfNqds.css" ]
        ]
        body [] [
            div [ _id "root" ] []
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
