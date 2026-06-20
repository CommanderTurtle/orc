module ConvertedFiles.N2026.N01.N09SigSchemaHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "---\nlayout: page\ntitle: \"sHEL SIG-Schema Meeting\"\nsubtitle: \"🌐 Virtual • January 9, 2026\"\npermalink: /events/2026/01/09-sig-schema.html\n---"
            div [ _class "container-narrow" ] [
                h2 [] [
                    str "About SIG-Schema"
                ]
                p [] [
                    str "The Schema Special Interest Group meets biweekly to discuss sHEL's schema system, validation pipeline, type system, and related standards."
                ]
                h2 [] [
                    str "This Week's Agenda"
                ]
                ul [] [
                    li [] [
                        str "Review open schema proposals"
                    ]
                    li [] [
                        str "Conditional validation RFC discussion"
                    ]
                    li [] [
                        str "Custom type plugin API design"
                    ]
                    li [] [
                        str "Open issues triage"
                    ]
                ]
                p [] [
                    a [ _href "https://github.com/CommanderTurtle/docs-pages/issues?q=label%3Asig%2Fschema"; attr "target" "_blank"; attr "rel" "noopener" ] [
                        str "View open issues"
                    ]
                    str "or"
                    a [ _href "https://slack.shel.sh"; attr "target" "_blank"; attr "rel" "noopener" ] [
                        str "join #sig-schema on Slack"
                    ]
                    str "."
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
