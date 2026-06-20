module ConvertedFiles.Wtg.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Wilson Technology Group"
            ]
            link [ attr "rel" "preconnect"; _href "https://fonts.googleapis.com" ]
            link [ attr "rel" "preconnect"; _href "https://fonts.gstatic.com"; attr "crossorigin" "" ]
            link [ _href "https://fonts.googleapis.com/css2?family=Instrument+Serif&family=DM+Sans:wght@400;500;600;700&display=swap"; attr "rel" "stylesheet" ]
            script [ _type "module"; attr "crossorigin" ""; _src "/wtg/assets/index-oiDirSjt.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/wtg/assets/index-Du2ZtWuT.css" ]
        ]
        body [] [
            div [ _id "root" ] []
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
