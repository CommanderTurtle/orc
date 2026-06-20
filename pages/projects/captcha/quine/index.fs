module Imported.Projects.Captcha.Quine.IndexHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            body [ attr "bgcolor" "🔥"; attr "onload" "setInterval(e='for(h=\"\",a[I++*I%17+578]=i=89;i++<630;h+=i%30?(x=a[i]=~~((a[i]+a[i+1]+a[i+29]+a[i+30])/4))&&e[i%142].fontcolor(5<x&&\"#FF0\"):\"\\\\n\")p.innerHTML=h',a=[I=30])" ] [
                pre [ _id "p" ] []
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
