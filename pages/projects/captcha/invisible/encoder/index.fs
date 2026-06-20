module Imported.Projects.Captcha.Invisible.Encoder.IndexHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] [
            title [] [
                str "INVISIBLE.js - Encode and Run Invisible Code"
            ]
            meta [ attr "name" "description"; attr "content" "An encoder and tiny payload to hide JavaScript code. Created by Martin Kleppe aka @aemkei." ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width,initial-scale=1.0" ]
            meta [ attr "name" "theme-color"; attr "content" "#222222" ]
            meta [ attr "property" "og:title"; attr "content" "INVISIBLE.js - Encode and Execute Invisible Code" ]
            meta [ attr "property" "og:description"; attr "content" "An encoder and tiny payload to hide JavaScript code" ]
            meta [ attr "property" "og:image"; attr "content" "https://aem1k.com/invisible/encoder/preview-large.png" ]
            meta [ attr "name" "twitter:card"; attr "content" "summary_large_image" ]
            meta [ attr "name" "twitter:site"; attr "content" "@aemkei" ]
            meta [ attr "property" "twitter:image"; attr "content" "https://aem1k.com/invisible/encoder/preview-large.png" ]
            link [ _href "https://fonts.googleapis.com/css?family=Inconsolata"; attr "rel" "stylesheet"; _type "text/css" ]
            link [ _href "styles.css"; attr "rel" "stylesheet"; _type "text/css" ]
        ]
        body [] [
            div [ _id "container" ] [
                h1 [] [
                    str "INVISIBLE.js"
                ]
                h2 [] [
                    str "Encode and Run Invisible Code"
                ]
                p [] [
                    str "A super compact (116-byte) bootstrap that hides JavaScript using a Proxy trap to run code. When an invisible property is accessed, the property name is converted to binary, decoded into text, and executed with eval."
                ]
                p [] [
                    str "Created by\n      Martin Kleppe aka"
                    a [ _href "https://twitter.com/aemkei" ] [
                        str "@aemkei"
                    ]
                    str "."
                ]
                div [] [
                    p [] [
                        h3 [] [
                            str "Example"
                        ]
                        tag "textarea" [ _id "input" ] [
                            str "alert(\"invisible\")"
                        ]
                        a [ _href "#"; _id "convert" ] [
                            str "Click to Convert ↓↓↓↓↓"
                        ]
                        span [ _id "count" ] [
                            str "..."
                        ]
                        tag "textarea" [ _id "output"; attr "cols" "10"; attr "onclick" "this.select();" ] []
                        div [ _id "your-output" ] [
                            str "↑ Run"
                            a [ _href "#"; _id "run" ] [
                                str "the code"
                            ]
                            str "on this site."
                        ]
                    ]
                    hr []
                    h3 [ _id "explanation" ] [
                        str "Explanation"
                    ]
                    pre [] [
                        str "// use a Proxy"
                        b [] [
                            str "new Proxy({}, {"
                        ]
                        str "// property trap"
                        b [] [
                            str "get: (_, n) =>"
                        ]
                        str "// execute code"
                        b [] [
                            str "eval([...n]"
                        ]
                        str "// convert to 0 and 1"
                        b [] [
                            str ".map(n => +(\"ﾠ\" > n)).join(``)"
                        ]
                        str "// get byte sequences"
                        b [] [
                            str ".replace(/.{8}/g, n =>"
                        ]
                        str "// convert binary to string"
                        b [] [
                            str "String.fromCharCode(+(\"0b\" + n))"
                        ]
                        b [] [
                            str ")"
                        ]
                        b [] [
                            str ")"
                        ]
                        b [] [
                            str "})."
                        ]
                    ]
                    p [] [
                        b [] [
                            str "Proxy Trap"
                        ]
                        str ": A `Proxy` object is created with a `get` trap, which intercepts any attempt to access a property. When a property is accessed on this proxy, the trap receives the property name as input."
                    ]
                    p [] [
                        b [] [
                            str "Invisible Character Encoding"
                        ]
                        str ": The property name is made up of specific invisible characters. Each character in the name is compared against a reference invisible character (Hangul filler), and the result of this comparison is used to produce either a 1 or a 0."
                    ]
                    p [] [
                        b [] [
                            str "Binary to Text Conversion"
                        ]
                        str ": The resulting binary sequence is joined into a single string, which is then grouped into segments of 8 bits, representing individual bytes. Each byte is then converted into its corresponding ASCII character."
                    ]
                    p [] [
                        b [] [
                            str "Code Evaluation"
                        ]
                        str ": The decoded characters from each accessed property name are accumulated into a larger string, representing executable JavaScript code. Once all characters are decoded, this string is passed to `eval`, which executes the code."
                    ]
                    p [] [
                        b [] [
                            str "Obfuscation"
                        ]
                        str ": This approach obfuscates the actual code by hiding it within seemingly blank or meaningless property names. The use of a `Proxy` and `eval` enables this hidden code to be executed without any readable JavaScript code directly visible in the source."
                    ]
                    h3 [ _id "relatedlinks" ] [
                        str "Related Links"
                    ]
                    ul [] [
                        li [] [
                            str "Follow"
                            a [ _href "https://twitter.com/aemkei" ] [
                                str "@aemkei"
                            ]
                            str "on Twitter"
                        ]
                        li [] [
                            str "Visit"
                            a [ _href "https://aem1k.com" ] [
                                str "aem1k.com"
                            ]
                            str "for more hacks"
                        ]
                    ]
                    hr []
                    pre [ _id "logo" ] [
                        b [] [
                            str "#"
                        ]
                        b [] [
                            str "#"
                        ]
                        b [] [
                            str "##"
                        ]
                        b [] [
                            str "#"
                        ]
                        str "#\n   ##"
                        b [] [
                            str "#"
                        ]
                        str "#\n ## #"
                        b [] [
                            str "#"
                        ]
                        str "# #\n# # #"
                        b [] [
                            str "#"
                        ]
                        str "##\n# # #"
                        b [] [
                            str "#"
                        ]
                        str "# #\n# # #"
                        b [] [
                            str "#"
                        ]
                        str "#  #"
                    ]
                    str "2024 - Martin Kleppe"
                ]
                script [ _src "index.js" ] [ rawText ("""""") ]
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
