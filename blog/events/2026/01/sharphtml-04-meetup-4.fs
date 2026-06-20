module ConvertedFiles.N2026.N01.N04Meetup4Html

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"Community Meetup #4\"\nsubtitle: \"🌐 Virtual • January 4, 2026\"\npermalink: /events/2026/01/04-meetup-4.html\n---"
            div [ _class "container-narrow" ] [
                h2 [] [
                    str "About"
                ]
                p [] [
                    str "Our monthly virtual community meetup. This month we'll be discussing the upcoming v1.0 release, community contributions highlights, and open floor for any topics."
                ]
                h2 [] [
                    str "Topics"
                ]
                ul [] [
                    li [] [
                        str "v1.0 release preview and what's new"
                    ]
                    li [] [
                        str "Community contribution spotlight"
                    ]
                    li [] [
                        str "Open floor discussion"
                    ]
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
