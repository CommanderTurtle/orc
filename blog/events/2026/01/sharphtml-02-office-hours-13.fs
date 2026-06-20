module ConvertedFiles.N2026.N01.N02OfficeHours13Html

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"sHEL Office Hours #13\"\nsubtitle: \"🌐 Virtual • 4:00 PM UTC • January 2, 2026\"\npermalink: /events/2026/01/02-office-hours-13.html\n---"
            div [ _class "container-narrow" ] [
                div [ _class "admonition admonition-note" ] [
                    div [ _class "admonition-title" ] [
                        str "Recurring Event"
                    ]
                    div [ _class "admonition-content" ] [
                        p [] [
                            str "Office Hours happen every other Thursday."
                            a [ _href "https://slack.shel.sh"; attr "target" "_blank"; attr "rel" "noopener" ] [
                                str "Join Slack"
                            ]
                            str "to get the recurring calendar invite."
                        ]
                    ]
                ]
                h2 [] [
                    str "About Office Hours"
                ]
                p [] [
                    str "Open Q&A with the sHEL core team. No agenda, no preparation needed — just bring your questions about sHEL, whether they're about schema design, performance tuning, contributing, or just getting started."
                ]
                h2 [] [
                    str "Join"
                ]
                p [] [
                    a [ _href "https://slack.shel.sh"; attr "target" "_blank"; attr "rel" "noopener" ] [
                        str "Join us on Slack"
                    ]
                    str "— the video link is posted in #office-hours 15 minutes before we start."
                ]
                p [] [
                    a [ _href "/events/"; _class "btn btn-ghost" ] [
                        str "← Back to Events"
                    ]
                ]
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
