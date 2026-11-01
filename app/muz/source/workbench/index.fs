module Muz.Source.Workbench.IndexHtml

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
        ]
        body [] [
            div [ _id "app" ] []
            script [ _type "module"; _src "/src/main.ts" ] [ rawText ("""""") ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
