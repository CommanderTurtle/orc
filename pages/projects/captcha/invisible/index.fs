module ConvertedFiles.Projects.Captcha.Invisible.IndexHtml

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

    a:visited, a:link {
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
            str "A hoisted JavaScript payload \n  to write invisible code:\n\n  <script>"
            script [] [
                    rawText ("""with (ㅤ`` ) {
    ㅤㅤㅤㅤㅤㅤㅤ
    ㅤㅤ
    ㅤㅤㅤㅤㅤㅤㅤ
    ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ
    ㅤㅤㅤㅤㅤㅤㅤ
    ㅤㅤㅤㅤㅤㅤ
    ㅤㅤㅤㅤㅤㅤㅤㅤ             // this
    ㅤㅤㅤ                      // is
    ㅤㅤㅤㅤㅤㅤㅤㅤ        // invisible
    ㅤㅤㅤㅤㅤ                 // code
    ㅤㅤㅤ
    ㅤㅤㅤㅤㅤㅤㅤㅤㅤ
    ㅤㅤㅤㅤ
    ㅤㅤ
    ㅤㅤㅤ
    ㅤㅤㅤㅤㅤㅤㅤㅤㅤㅤ
    ㅤ
    ㅤ
  } // encode and run an `alert(1);`


  // hoisted parser
  function \u3164(){return f="",p=[]  
  ,new Proxy({},{has:(t,n)=>(p.push(
  n.length-1),2==p.length&&(p[0]||p[
  1]||eval(f),f+=String.fromCharCode
  (p[0]<<4|p[1]),p=[]),!0)})}//aem1k""")
            ]
            str "</script>"
            p [] [
                str "HINT: Select the script tag to see the underlying code.\n\n    It uses invisible Hangul Filler characters (U+3164) in combination with JavaScript's with statement and a Proxy object to encode and evaluate a payload.\n\n    Read more about it"
                a [ _href "https://x.com/aemkei/status/1843756978147078286 " ] [
                    str "on Twitter"
                ]
                str "."
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
