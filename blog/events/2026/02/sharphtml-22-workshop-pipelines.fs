module ConvertedFiles.N2026.N02.N22WorkshopPipelinesHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"sHEL Workshop: Building Data Pipelines\"\nsubtitle: \"📍 San Francisco, CA • 10:00 AM PST • February 22, 2026\"\npermalink: /events/2026/02/22-workshop-pipelines.html\n---"
            div [ _class "container-narrow" ] [
                div [ _class "admonition admonition-tip" ] [
                    div [ _class "admonition-title" ] [
                        str "Upcoming Workshop"
                    ]
                    div [ _class "admonition-content" ] [
                        p [] [
                            str "In-person workshop with limited seats."
                            a [ _href "https://slack.shel.sh"; attr "target" "_blank"; attr "rel" "noopener" ] [
                                str "RSVP on Slack"
                            ]
                            str "to reserve your spot."
                        ]
                    ]
                ]
                h2 [] [
                    str "Workshop Overview"
                ]
                p [] [
                    str "A hands-on, full-day workshop where you'll learn to build production-grade data pipelines with sHEL. We'll cover everything from basic pipe composition to advanced stream processing patterns."
                ]
                h2 [] [
                    str "Schedule"
                ]
                ul [] [
                    li [] [
                        strong [] [
                            str "10:00 AM"
                        ]
                        str "— Registration & coffee"
                    ]
                    li [] [
                        strong [] [
                            str "10:30 AM"
                        ]
                        str "— Session 1: Pipeline fundamentals"
                    ]
                    li [] [
                        strong [] [
                            str "12:00 PM"
                        ]
                        str "— Lunch break"
                    ]
                    li [] [
                        strong [] [
                            str "1:00 PM"
                        ]
                        str "— Session 2: Advanced patterns & performance"
                    ]
                    li [] [
                        strong [] [
                            str "3:00 PM"
                        ]
                        str "— Session 3: Real-world use cases"
                    ]
                    li [] [
                        strong [] [
                            str "4:30 PM"
                        ]
                        str "— Wrap-up & networking"
                    ]
                ]
                h2 [] [
                    str "Prerequisites"
                ]
                ul [] [
                    li [] [
                        str "sHEL CLI installed (we'll help at registration)"
                    ]
                    li [] [
                        str "Familiarity with command-line basics"
                    ]
                    li [] [
                        str "Bring a laptop"
                    ]
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
