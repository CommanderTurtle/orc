module Muz.Workbench.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            meta [ attr "name" "theme-color"; attr "content" "#ffffff" ]
            link [ attr "rel" "icon"; _href "./icon.svg" ]
            title [] [
                str "muzpad"
            ]
            script [ _type "module"; attr "crossorigin" ""; _src "./assets/index-NpRA1AWG.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "./assets/index-D4iHmGI1.css" ]
        ]
        body [] [
            div [ _id "app" ] []
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
