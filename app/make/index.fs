module Make.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0, maximum-scale=1.0" ]
            link [ attr "rel" "shortcut icon"; _href "/make/assets/favicon-Bfod-rsk.ico"; _type "image/x-icon" ]
            title [] [
                str "mk.it · private browser tools"
            ]
            link [ attr "rel" "canonical"; _href "https://app.shel.sh/make/" ]
            meta [ attr "name" "application-name"; attr "content" "mk.it" ]
            meta [ attr "name" "url"; attr "content" "https://app.shel.sh/make/" ]
            meta [ attr "name" "identifier-URL"; attr "content" "https://app.shel.sh/make/" ]
            meta [ attr "name" "og:url"; attr "content" "https://app.shel.sh/make/" ]
            meta [ attr "name" "og:title"; attr "content" "mk.it" ]
            meta [ attr "name" "og:site_name"; attr "content" "mk.it" ]
            meta [ attr "name" "og:description"; attr "content" "Private, on-device conversion, OCR, base64, and archive tools." ]
            meta [ attr "name" "og:image"; attr "content" "https://app.shel.sh/make/favicon.ico" ]
            meta [ attr "name" "theme-color"; attr "content" "#1C77FF" ]
            meta [ attr "name" "og:type"; attr "content" "website" ]
            script [ _type "module"; attr "crossorigin" ""; _src "/make/assets/index-DrIwzG2e.js" ] [ rawText ("""""") ]
            link [ attr "rel" "modulepreload"; attr "crossorigin" ""; _href "/make/assets/rolldown-runtime-C0FnF6B9.js" ]
            link [ attr "rel" "modulepreload"; attr "crossorigin" ""; _href "/make/assets/CommonFormats-bmLAkhpe.js" ]
            link [ attr "rel" "modulepreload"; attr "crossorigin" ""; _href "/make/assets/preload-helper-CumowRSw.js" ]
            link [ attr "rel" "modulepreload"; attr "crossorigin" ""; _href "/make/assets/src-CxRAzd7v.js" ]
            link [ attr "rel" "modulepreload"; attr "crossorigin" ""; _href "/make/assets/pako.esm-l17wVnKK.js" ]
            link [ attr "rel" "modulepreload"; attr "crossorigin" ""; _href "/make/assets/jszip.min-B7Fa2WXl.js" ]
            link [ attr "rel" "modulepreload"; attr "crossorigin" ""; _href "/make/assets/dist-BMuveqLk.js" ]
            link [ attr "rel" "modulepreload"; attr "crossorigin" ""; _href "/make/assets/archiveCombine-CVSZed9W.js" ]
            link [ attr "rel" "modulepreload"; attr "crossorigin" ""; _href "/make/assets/normalizeMimeType-COJfimbo.js" ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/make/assets/index-CP4ciorh.css" ]
        ]
        body [] []
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
