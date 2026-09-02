module ConvertedFiles.Plugins.AksharRadioAtlas.App.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1" ]
            meta [ attr "name" "color-scheme"; attr "content" "dark" ]
            meta [ attr "http-equiv" "Content-Security-Policy"; attr "content" "default-src 'self'; script-src 'self'; style-src 'self'; connect-src 'self' https://all.api.radio-browser.info https://*.api.radio-browser.info; media-src https: http:; img-src 'self' data: https:; object-src 'none'; base-uri 'none'; form-action 'none'" ]
            meta [ attr "name" "description"; attr "content" "A static, browser-native port of Radio Atlas for Omarchy." ]
            title [] [
                str "Radio Atlas"
            ]
            script [ _type "module"; attr "crossorigin" ""; _src "/radio/assets/page-1-BKuWIuLD.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/radio/assets/style-BdwIugra.css" ]
        ]
        body [] [
            main [ _class "radio-stage"; _id "radio-stage" ] [
                section [ _class "radio-card"; _id "radio-card"; attr "aria-label" "Radio Atlas" ] [
                    header [ _class "radio-header" ] [
                        h1 [] [
                            str "RADIO ATLAS"
                        ]
                        label [ _class "search-field" ] [
                            span [ _class "sr-only" ] [
                                str "Search station, country, or genre"
                            ]
                            input [ _id "search"; _type "search"; attr "maxlength" "128"; attr "autocomplete" "off"; attr "placeholder" "Search station, country, or genre" ]
                        ]
                        button [ _class "icon-button"; _id "random"; _type "button"; attr "title" "Tune randomly (R)"; attr "aria-label" "Tune randomly" ] [
                            str "⇄"
                        ]
                        button [ _class "icon-button icon-button--text"; _id "help"; _type "button"; attr "title" "Show controls (?)"; attr "aria-label" "Show controls" ] [
                            str "?"
                        ]
                        button [ _class "icon-button"; _id "close"; _type "button"; attr "title" "Close"; attr "aria-label" "Close Radio Atlas" ] [
                            str "×"
                        ]
                    ]
                    div [ _class "radio-body"; _id "radio-body" ] [
                        section [ _class "map-pane"; attr "aria-label" "Interactive world radio globe" ] [
                            canvas [ _id "globe"; attr "tabindex" "0"; attr "aria-label" "Drag to rotate, use the mouse wheel to zoom, and select a station signal or country" ] []
                            div [ _class "globe-tooltip"; _id "globe-tooltip"; attr "hidden" "" ] []
                            p [ _class "map-hint"; _id "map-hint" ] [
                                str "Drag to rotate · wheel to zoom · click a signal or country"
                            ]
                            p [ _class "signal-count"; _id "signal-count" ] [
                                str "0 signals"
                            ]
                        ]
                        aside [ _class "sidebar"; attr "aria-label" "Stations and player" ] [
                            nav [ _class "station-tabs"; attr "aria-label" "Station lists" ] [
                                button [ _type "button"; attr "data-mode" "world"; attr "aria-current" "page" ] [
                                    str "World"
                                ]
                                button [ _type "button"; attr "data-mode" "favorites" ] [
                                    str "Favorites"
                                ]
                                button [ _type "button"; attr "data-mode" "recent" ] [
                                    str "Recent"
                                ]
                            ]
                            section [ _class "station-list"; _id "station-list"; attr "tabindex" "0"; attr "role" "listbox"; attr "aria-label" "Radio stations" ] [
                                div [ _class "station-list__content"; _id "station-list-content" ] []
                                p [ _class "station-list__empty"; _id "station-list-empty" ] [
                                    str "Loading stations"
                                ]
                            ]
                            section [ _class "player"; attr "aria-label" "Radio player" ] [
                                div [ _class "player__identity" ] [
                                    p [ _class "player__station"; _id "player-station" ] [
                                        str "Nothing playing"
                                    ]
                                    p [ _class "player__status"; _id "player-status" ] [
                                        str "Choose a signal to begin"
                                    ]
                                    button [ _class "favorite-button player__favorite"; _id "player-favorite"; _type "button"; attr "aria-label" "Favorite playing station"; attr "title" "Favorite playing station"; attr "hidden" "" ] [
                                        str "☆"
                                    ]
                                ]
                                div [ _class "player__controls" ] [
                                    div [ _class "player__transport" ] [
                                        button [ _class "icon-button"; _id "previous"; _type "button"; attr "title" "Previous station"; attr "aria-label" "Previous station" ] [
                                            str "◀│"
                                        ]
                                        button [ _class "icon-button"; _id "play-pause"; _type "button"; attr "title" "Play or pause"; attr "aria-label" "Play or pause" ] [
                                            str "▶"
                                        ]
                                        button [ _class "icon-button"; _id "next"; _type "button"; attr "title" "Next station"; attr "aria-label" "Next station" ] [
                                            str "│▶"
                                        ]
                                        button [ _class "icon-button"; _id "stop"; _type "button"; attr "title" "Stop"; attr "aria-label" "Stop" ] [
                                            str "■"
                                        ]
                                    ]
                                    div [ _class "player__volume" ] [
                                        button [ _class "icon-button"; _id "mute"; _type "button"; attr "title" "Mute (M)"; attr "aria-label" "Mute" ] [
                                            str "◖"
                                        ]
                                        input [ _id "volume"; _type "range"; attr "min" "0"; attr "max" "100"; attr "step" "1"; attr "value" "70"; attr "aria-label" "Radio volume" ]
                                        output [ _id "volume-value"; attr "for" "volume" ] [
                                            str "70%"
                                        ]
                                    ]
                                ]
                                audio [ _id "audio"; attr "preload" "none" ] []
                            ]
                        ]
                    ]
                    section [ _class "controls-pane"; _id "controls-pane"; attr "aria-label" "Radio Atlas controls"; attr "hidden" "" ] [
                        div [ _class "controls-content" ] [
                            h2 [] [
                                str "CONTROLS"
                            ]
                            div [ _class "controls-grid" ] [
                                section [] [
                                    h3 [] [
                                        str "KEYBOARD"
                                    ]
                                    dl [] [
                                        div [] [
                                            dt [] [
                                                str "/"
                                            ]
                                            dd [] [
                                                str "Search"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "UP / DOWN"
                                            ]
                                            dd [] [
                                                str "Select station"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "ENTER"
                                            ]
                                            dd [] [
                                                str "Play selected station"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "SPACE"
                                            ]
                                            dd [] [
                                                str "Play or pause"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "R"
                                            ]
                                            dd [] [
                                                str "Tune randomly"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "F"
                                            ]
                                            dd [] [
                                                str "Favorite selected station"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "M"
                                            ]
                                            dd [] [
                                                str "Mute or unmute"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "+ / -"
                                            ]
                                            dd [] [
                                                str "Change volume"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "ESC"
                                            ]
                                            dd [] [
                                                str "Back, clear, or close"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "?"
                                            ]
                                            dd [] [
                                                str "Show or hide controls"
                                            ]
                                        ]
                                    ]
                                ]
                                section [] [
                                    h3 [] [
                                        str "MOUSE AND WEB"
                                    ]
                                    dl [] [
                                        div [] [
                                            dt [] [
                                                str "DRAG GLOBE"
                                            ]
                                            dd [] [
                                                str "Rotate"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "GLOBE WHEEL"
                                            ]
                                            dd [] [
                                                str "Zoom"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "CLICK SIGNAL"
                                            ]
                                            dd [] [
                                                str "Play station"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "CLICK COUNTRY"
                                            ]
                                            dd [] [
                                                str "Browse stations"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "APP BUTTON"
                                            ]
                                            dd [] [
                                                str "Open or focus"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "RANDOM"
                                            ]
                                            dd [] [
                                                str "Tune randomly"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "STOP"
                                            ]
                                            dd [] [
                                                str "Stop playback"
                                            ]
                                        ]
                                        div [] [
                                            dt [] [
                                                str "VOLUME"
                                            ]
                                            dd [] [
                                                str "Independent radio level"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
                section [ _class "closed-card"; _id "closed-card"; attr "hidden" "" ] [
                    p [] [
                        str "RADIO ATLAS IS CLOSED"
                    ]
                    button [ _type "button"; _id "reopen" ] [
                        str "Open Radio Atlas"
                    ]
                ]
                div [ _class "sr-only"; _id "announcer"; attr "role" "status"; attr "aria-live" "polite" ] []
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
