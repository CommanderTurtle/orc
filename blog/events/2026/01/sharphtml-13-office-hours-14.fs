module ConvertedFiles.N2026.N01.N13OfficeHours14Html

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"sHEL Office Hours #14\"\nsubtitle: \"🌐 Virtual • 4:00 PM UTC • January 13, 2026\"\npermalink: /events/2026/01/13-office-hours-14.html\n---"
            div [ _class "container-narrow" ] [
                h2 [] [
                    str "About Office Hours"
                ]
                p [] [
                    str "Open Q&A with the sHEL core team. Bring any questions — getting started, schema design, performance, contributing, or just to chat."
                ]
                p [] [
                    a [ _href "https://slack.shel.sh"; attr "target" "_blank"; attr "rel" "noopener" ] [
                        str "Join us on Slack"
                    ]
                    str "for the video link."
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
