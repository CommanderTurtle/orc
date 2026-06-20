module ConvertedFiles.N2026.N01.N15ReleasePartyHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"sHEL v1.0 Release Party\"\nsubtitle: \"Virtual • 6:00 PM UTC • January 15, 2026\"\npermalink: /events/2026/01/15-release-party.html\n---"
            div [ _class "container-narrow" ] [
                div [ _class "admonition admonition-tip" ] [
                    div [ _class "admonition-title" ] [
                        str "Upcoming Event"
                    ]
                    div [ _class "admonition-content" ] [
                        p [] [
                            str "This is an upcoming event."
                            a [ _href "https://slack.shel.sh"; attr "target" "_blank"; attr "rel" "noopener" ] [
                                str "Join our Slack"
                            ]
                            str "to get reminded when it's about to start."
                        ]
                    ]
                ]
                h2 [] [
                    str "About This Event"
                ]
                p [] [
                    str "Join the sHEL core team and community to celebrate the"
                    strong [] [
                        str "v1.0 release"
                    ]
                    str "! This is a milestone we've been working toward for over a year, and we can't wait to share it with you."
                ]
                h2 [] [
                    str "Agenda"
                ]
                ul [] [
                    li [] [
                        strong [] [
                            str "6:00 PM"
                        ]
                        str "— Welcome & community highlights"
                    ]
                    li [] [
                        strong [] [
                            str "6:20 PM"
                        ]
                        str "— v1.0 feature walkthrough with live demos"
                    ]
                    li [] [
                        strong [] [
                            str "7:00 PM"
                        ]
                        str "— Roadmap preview: what's next for 2026"
                    ]
                    li [] [
                        strong [] [
                            str "7:30 PM"
                        ]
                        str "— Open Q&A and community hangout"
                    ]
                ]
                h2 [] [
                    str "How to Join"
                ]
                p [] [
                    str "This event is held virtually. A Zoom link will be shared in"
                    a [ _href "https://slack.shel.sh"; attr "target" "_blank"; attr "rel" "noopener" ] [
                        str "#events on Slack"
                    ]
                    str "24 hours before the event."
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
