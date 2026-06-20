module Imported.Projects.Captcha.Source.IndexHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            str "setInterval(p=h=>{for(p[I++*I%17+578]=h=i=89;i++<630;h+=i%30?+!(p[i]=p[i]+p[i+1]+p[i+29]+p[i+30]>>2):\"\\n\");console.log(h)},I=30)"
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
