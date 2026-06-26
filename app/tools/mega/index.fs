module ConvertedFiles.Mega.IndexHtml.Mega

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            link [ attr "rel" "icon"; _type "image/png"; _href "/tools/mega/favicon-96x96.png"; attr "sizes" "96x96" ]
            link [ attr "rel" "icon"; _type "image/svg+xml"; _href "/tools/mega/favicon.svg" ]
            link [ attr "rel" "shortcut icon"; _href "/tools/mega/favicon.ico" ]
            link [ attr "rel" "apple-touch-icon"; attr "sizes" "180x180"; _href "/tools/mega/apple-touch-icon.png" ]
            meta [ attr "name" "apple-mobile-web-app-title"; attr "content" "OmniTools" ]
            link [ attr "rel" "manifest"; _href "/tools/mega/site.webmanifest" ]
            link [ _href "/tools/mega/assets/fonts/quicksand/quick-sand.css"; attr "rel" "stylesheet" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "OmniTools"
            ]
            script [ _type "module"; attr "crossorigin" ""; _src "/tools/mega/assets/index-aHpeEV8y.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/tools/mega/assets/index-D_bD5HeT.css" ]
        ]
        body [] [
            div [ _id "root" ] []
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
