module Radio.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1" ]
            meta [ attr "name" "color-scheme"; attr "content" "dark" ]
            meta [ attr "http-equiv" "Content-Security-Policy"; attr "content" "default-src 'self'; script-src 'self'; style-src 'self'; frame-src 'self'; img-src 'self' data:; object-src 'none'; base-uri 'none'; form-action 'none'" ]
            meta [ attr "name" "description"; attr "content" "Static browser host for portable Omarchy web applications." ]
            title [] [
                str "Omarchy Web Apps"
            ]
            script [ _type "module"; attr "crossorigin" ""; _src "/radio/assets/index-Dwrfc347.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/radio/assets/style-BdwIugra.css" ]
        ]
        body [] [
            div [ _class "shell"; _id "shell"; attr "aria-busy" "true" ] [
                header [ _class "shell__bar" ] [
                    a [ _class "shell__brand"; _href "./"; attr "aria-label" "Omarchy Web Apps home" ] [
                        span [ _class "shell__brand-mark"; attr "aria-hidden" "true" ] [
                            str "OMA"
                        ]
                        span [] [
                            str "WEB APPS"
                        ]
                    ]
                    nav [ _class "shell__apps"; _id "app-tabs"; attr "aria-label" "Applications" ] []
                    label [ _class "shell__theme" ] [
                        span [] [
                            str "THEME"
                        ]
                        select [ _id "theme-select"; attr "aria-label" "Omarchy theme" ] []
                    ]
                ]
                main [ _class "shell__stage" ] [
                    div [ _class "shell__message"; _id "shell-message"; attr "role" "status" ] [
                        str "Loading applications…"
                    ]
                    iframe [ _id "app-frame"; _class "shell__frame"; attr "title" "Selected Omarchy application"; attr "allow" "autoplay"; attr "referrerpolicy" "strict-origin-when-cross-origin" ] []
                ]
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
