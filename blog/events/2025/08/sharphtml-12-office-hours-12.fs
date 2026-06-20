module ConvertedFiles.N2025.N08.N12OfficeHours12Html

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"sHEL Office Hours #12\"\nsubtitle: \"🌐 Virtual • 4:00 PM UTC • August 12, 2025\"\npermalink: /events/2025/08/12-office-hours-12.html\n---"
            div [ _class "container-narrow" ] [
                div [ _class "admonition admonition-note" ] [
                    div [ _class "admonition-title" ] [
                        str "Past Event"
                    ]
                    div [ _class "admonition-content" ] [
                        p [] [
                            str "This event has concluded. Office hours continue every other Thursday — see the"
                            a [ _href "/events/" ] [
                                str "events page"
                            ]
                            str "for upcoming sessions."
                        ]
                    ]
                ]
                h2 [] [
                    str "Topics Discussed"
                ]
                ul [] [
                    li [] [
                        str "Schema design best practices for nested data structures"
                    ]
                    li [] [
                        str "Performance tuning tips for high-throughput pipelines"
                    ]
                    li [] [
                        str "Contributing to sHEL — how to get started"
                    ]
                    li [] [
                        str "Upcoming v1.0 timeline discussion"
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
