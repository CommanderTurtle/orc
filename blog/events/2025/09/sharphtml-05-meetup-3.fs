module ConvertedFiles.N2025.N09.N05Meetup3Html

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"Community Meetup #3\"\nsubtitle: \"🌐 Virtual • September 5, 2025\"\npermalink: /events/2025/09/05-meetup-3.html\n---"
            div [ _class "container-narrow" ] [
                div [ _class "admonition admonition-note" ] [
                    div [ _class "admonition-title" ] [
                        str "Past Event"
                    ]
                    div [ _class "admonition-content" ] [
                        p [] [
                            str "This event has concluded. Join us for the next one — check the"
                            a [ _href "/events/" ] [
                                str "events page"
                            ]
                            str "for upcoming meetups."
                        ]
                    ]
                ]
                h2 [] [
                    str "Recap"
                ]
                p [] [
                    str "Great turnout for our third community meetup! Topics covered:"
                ]
                ul [] [
                    li [] [
                        str "Schema validation deep dive — new conditional validators coming in v0.9"
                    ]
                    li [] [
                        str "Plugin API preview — third-party extensions are almost here"
                    ]
                    li [] [
                        str "Community contributions showcase — highlighting first-time contributors"
                    ]
                    li [] [
                        str "Q&A with the core team"
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
