module App.Macro

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Macrohard Visual Assembly"
            ]
            script [ _type "module"; attr "crossorigin" ""; _src "/macro/assets/index-LyU7yEna.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/macro/assets/index-Cllx_LW0.css" ]
        ]
        body [] [
            div [ _id "root" ] []
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
