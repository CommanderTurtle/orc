module Imported.Projects.Captcha.Demo.IndexHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            pre [ _id "p" ] [
                tag "svg" [ attr "onload" "a=[setInterval('h=\"\";for(a[I++*I%17+578]=i=89;i++<630;h+=i%30?\"`*\"[a[i]=~~((a[i]+a[i+1]+a[i+29]+a[i+30])/4)]||8:\"\\\\n\")p.innerHTML=h',I=30)]" ] [
                    str "// adapted source to work in the browser\n// original: aem1k.com/fire"
                ]
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
