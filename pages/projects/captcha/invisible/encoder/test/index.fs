module ConvertedFiles.Projects.Captcha.Invisible.Encoder.TestHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            title [] [
                str "INVISIBLE.js - Execute Invisible Code"
            ]
            style [] [
                    rawText ("""body {

      font-family: monospace;
      white-space: pre;
      background-color: #000;
      color: #F0F;
    }

    p {
      width: 270px;
      white-space: normal;
      padding: 16px;
    }

    a:visited,
    a:link {
      color: #F0F;
    }

    script {
      display: block;
      color: #FF0
    }

    h1 {
      color: #0FF;
    }""")
            ]
        ]
        body [] [
            h1 [] [
                str "INVISIBLE.js 🫥"
            ]
            str "A hoisted JavaScript payload\n  to write invisible code:\n\n  <script>"
            script [] [
                    rawText ("""// todo: encoder

  new Proxy({},{get:(_,n)=>eval
  ([...n].map(n=>+("ﾠ">n)).join
  ``.replace(/.{8}/g,n=>String.
  fromCharCode(+("0b"+n))))}).
  
  // start of invisible code
ﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤㅤﾠﾠㅤﾠﾠㅤㅤㅤﾠㅤﾠﾠﾠﾠㅤﾠㅤﾠﾠﾠﾠﾠㅤㅤﾠﾠﾠㅤﾠﾠㅤﾠㅤﾠﾠㅤ
  // end of invisible code""")
            ]
            str "</script>"
            p [] [
                str "HINT: Select the script tag to see the underlying code.\n\n    It uses invisible Hangul Filler characters (U+3164) in combination with JavaScript's with statement and a Proxy\n    object to encode and evaluate a payload.\n\n    Read more about it"
                a [ _href "https://x.com/aemkei/status/1843756978147078286 " ] [
                    str "on Twitter"
                ]
                str "."
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
