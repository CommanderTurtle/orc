module ConvertedFiles.N2026.N01.N09VirtualHangoutHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"Weekly Virtual Hangout\"\nsubtitle: \"🌐 Virtual • January 9, 2026\"\npermalink: /events/2026/01/09-virtual-hangout.html\n---"
            div [ _class "container-narrow" ] [
                h2 [] [
                    str "About"
                ]
                p [] [
                    str "A casual, no-agenda hangout for sHEL community members. Come chat about whatever — sHEL, data engineering, programming, or just say hi."
                ]
                p [] [
                    a [ _href "https://slack.shel.sh"; attr "target" "_blank"; attr "rel" "noopener" ] [
                        str "Join #hangout on Slack"
                    ]
                    str "for the link."
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
