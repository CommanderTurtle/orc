module ConvertedFiles.N2025.N11.N10DataengconfHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"sHEL at DataEngConf\"\nsubtitle: \"📍 Berlin, Germany • November 10, 2025\"\npermalink: /events/2025/11/10-dataengconf.html\n---"
            div [ _class "container-narrow" ] [
                div [ _class "admonition admonition-note" ] [
                    div [ _class "admonition-title" ] [
                        str "Past Event"
                    ]
                    div [ _class "admonition-content" ] [
                        p [] [
                            str "This event has concluded."
                            a [ _href "/blog/" ] [
                                str "Check our blog"
                            ]
                            str "for a recap post."
                        ]
                    ]
                ]
                h2 [] [
                    str "Presentation"
                ]
                p [] [
                    strong [] [
                        str "\"Literal-Safe Data Substrates: A New Approach\""
                    ]
                ]
                p [] [
                    str "sHEL core maintainer presented sHEL's approach to data safety — how literal-by-default design eliminates an entire class of injection vulnerabilities without sacrificing developer experience."
                ]
                h2 [] [
                    str "Key Takeaways"
                ]
                ul [] [
                    li [] [
                        str "Injection attacks cost the industry billions annually — and most are preventable with better data handling"
                    ]
                    li [] [
                        str "sHEL's"
                        code [] [
                            str "literal<T>"
                        ]
                        str "type guarantee makes injection impossible at the type level"
                    ]
                    li [] [
                        str "Performance benchmarks show zero overhead from safety guarantees"
                    ]
                    li [] [
                        str "Drop-in compatibility with existing Unix tools enables gradual adoption"
                    ]
                ]
                h2 [] [
                    str "Slides & Recording"
                ]
                p [] [
                    a [ _href "https://github.com/CommanderTurtle/docs-pages/discussions"; attr "target" "_blank"; attr "rel" "noopener" ] [
                        str "View slides on GitHub Discussions"
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
