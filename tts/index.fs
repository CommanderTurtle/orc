module TTS.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width,initial-scale=1" ]
            meta [ attr "name" "color-scheme"; attr "content" "dark light" ]
            title [] [
                str "speakingwasm"
            ]
            link [ attr "rel" "stylesheet"; _href "./style.css" ]
        ]
        body [] [
            header [] [
                a [ _class "brand"; _href "./" ] [
                    span [ _class "mark"; attr "aria-hidden" "true" ] [
                        str "≋"
                    ]
                    str "speakingwasm"
                ]
                span [ _class "local" ] [
                    i [] []
                    str "on device"
                ]
                button [ _id "clear-cache"; _class "quiet" ] [
                    str "Clear downloads"
                ]
            ]
            main [] [
                div [ _class "intro" ] [
                    div [] [
                        p [ _class "eyebrow" ] [
                            str "SPEECH / TEXT / TOOLS"
                        ]
                        h1 [] [
                            str "A space for your voice."
                        ]
                        p [ _class "muted" ] [
                            str "Local models. One at a time."
                        ]
                    ]
                    div [ _class "ambient"; attr "aria-hidden" "true" ] [
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                        b [] []
                    ]
                ]
                nav [ _class "modes"; attr "aria-label" "Studio mode" ] [
                    button [ attr "data-mode" "speak"; attr "aria-pressed" "true" ] [
                        str "01"
                        strong [] [
                            str "Speak"
                        ]
                        span [] [
                            str "Text → audio"
                        ]
                    ]
                    button [ attr "data-mode" "listen"; attr "aria-pressed" "false" ] [
                        str "02"
                        strong [] [
                            str "Listen"
                        ]
                        span [] [
                            str "Audio → text"
                        ]
                    ]
                    button [ attr "data-mode" "translate"; attr "aria-pressed" "false" ] [
                        str "03"
                        strong [] [
                            str "Translate request"
                        ]
                        span [] [
                            str "Text → tool call"
                        ]
                    ]
                ]
                section [ _id "speak"; _class "studio" ] [
                    aside [] [
                        h2 [] [
                            str "Voice"
                        ]
                        label [] [
                            str "Model"
                            select [ _id "tts-model" ] [
                                option [ attr "value" "paradee" ] [
                                    str "Paradee 1.3 · 8M"
                                ]
                                option [ attr "value" "kokoro" ] [
                                    str "Kokoro · full 82M"
                                ]
                            ]
                        ]
                        p [ _class "hint"; _id "tts-size" ] [
                            str "INT8 · 8.5 MB · embedded voices"
                        ]
                        label [] [
                            str "Voice"
                            select [ _id "voice" ] []
                        ]
                        label [] [
                            str "Input"
                            select [ _id "input-mode" ] [
                                option [ attr "value" "text" ] [
                                    str "Text"
                                ]
                                option [ attr "value" "phonemes" ] [
                                    str "Model phonemes"
                                ]
                            ]
                        ]
                        p [ _id "phoneme-hint"; _class "hint" ] [
                            str "Voice language determines pronunciation."
                        ]
                        label [ _class "range-label" ] [
                            str "Speed"
                            output [ _id "speed-value" ] [
                                str "1.00×"
                            ]
                            input [ _id "speed"; _type "range"; attr "min" "0.5"; attr "max" "2"; attr "step" "0.05"; attr "value" "1" ]
                        ]
                        p [ _class "hint" ] [
                            str "Only the selected model and voice load when you press Speak."
                        ]
                    ]
                    div [ _class "workspace" ] [
                        div [ _class "section-head" ] [
                            h2 [] [
                                str "Script"
                            ]
                            label [ _class "file-button" ] [
                                str "Open text"
                                input [ _id "tts-file"; _type "file"; attr "accept" ".txt,.md,text/plain,text/markdown" ]
                            ]
                        ]
                        tag "textarea" [ _id "script"; attr "placeholder" "Write something worth hearing…"; attr "spellcheck" "true"; attr "aria-label" "Speech text" ] []
                        div [ _class "actions" ] [
                            span [ _id "chars"; _class "hint" ] [
                                str "0 characters"
                            ]
                            button [ _id "speak-run"; _class "primary" ] [
                                str "Speak"
                                span [ attr "aria-hidden" "true" ] [
                                    str "↗"
                                ]
                            ]
                        ]
                        div [ _id "player"; _class "player"; attr "hidden" "" ] [
                            div [ _class "section-head" ] [
                                span [] [
                                    str "Generated audio"
                                ]
                                button [ _id "close-audio"; _class "quiet" ] [
                                    str "Close"
                                ]
                            ]
                            audio [ _id "audio"; attr "controls" ""; attr "preload" "metadata" ] []
                            div [ _class "actions" ] [
                                div [] [
                                    button [ _id "rewind"; _class "quiet" ] [
                                        str "−10 s"
                                    ]
                                    button [ _id "forward"; _class "quiet" ] [
                                        str "+10 s"
                                    ]
                                ]
                                a [ _id "save-audio"; _class "button"; attr "download" "speech.wav" ] [
                                    str "Save WAV"
                                ]
                            ]
                        ]
                    ]
                ]
                section [ _id "listen"; _class "studio"; attr "hidden" "" ] [
                    aside [] [
                        h2 [] [
                            str "Transcription"
                        ]
                        label [] [
                            str "Model"
                            select [ _id "stt-model" ] [
                                option [ attr "value" "whistle" ] [
                                    str "Whistle"
                                ]
                                option [ attr "value" "bark" ] [
                                    str "Bark 3.0 · Base"
                                ]
                                option [ attr "value" "bark-plus" ] [
                                    str "Bark 3.0 · Plus"
                                ]
                                option [ attr "value" "bark-clean" ] [
                                    str "Bark 3.0 · Clean"
                                ]
                            ]
                        ]
                        p [ _id "stt-size"; _class "hint" ] [
                            str "17 MB · WASM · live updates"
                        ]
                        label [] [
                            str "Language"
                            select [ _id "stt-language" ] [
                                option [ attr "value" "" ] [
                                    str "Detect"
                                ]
                                option [ attr "value" "en" ] [
                                    str "English"
                                ]
                                option [ attr "value" "de" ] [
                                    str "German"
                                ]
                                option [ attr "value" "fr" ] [
                                    str "French"
                                ]
                                option [ attr "value" "es" ] [
                                    str "Spanish"
                                ]
                                option [ attr "value" "it" ] [
                                    str "Italian"
                                ]
                                option [ attr "value" "nl" ] [
                                    str "Dutch"
                                ]
                                option [ attr "value" "pl" ] [
                                    str "Polish"
                                ]
                            ]
                        ]
                        label [] [
                            str "Keywords"
                            tag "textarea" [ _id "keywords"; attr "rows" "3"; attr "placeholder" "Names or phrases, one per line" ] []
                        ]
                        p [ _class "hint" ] [
                            str "Microphone audio stays in this page. Stop recording to flush the\n            final phrase."
                        ]
                    ]
                    div [ _class "workspace" ] [
                        div [ _class "capture" ] [
                            canvas [ _id "wave"; attr "aria-label" "Live microphone waveform" ] []
                            button [ _id "microphone"; _class "mic"; attr "aria-label" "Start microphone" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24"; attr "aria-hidden" "true" ] [
                                    voidTag "rect" [ attr "x" "9"; attr "y" "2"; attr "width" "6"; attr "height" "12"; attr "rx" "3" ]
                                    voidTag "path" [ attr "d" "M5 10v2a7 7 0 0 0 14 0v-2M12 19v3m-4 0h8" ]
                                ]
                            ]
                            p [ _id "mic-label" ] [
                                str "Tap to record"
                            ]
                        ]
                        label [ _class "drop"; _id "drop" ] [
                            str "Or drop an audio file"
                            span [] [
                                str "WAV · MP3 · M4A · FLAC"
                            ]
                            input [ _id "audio-file"; _type "file"; attr "accept" "audio/*,.wav,.mp3,.m4a,.flac" ]
                        ]
                        div [ _class "section-head" ] [
                            h2 [] [
                                str "Transcript"
                            ]
                            button [ _id "clear-transcript"; _class "quiet" ] [
                                str "Clear"
                            ]
                        ]
                        tag "textarea" [ _id "transcript"; attr "aria-label" "Transcript"; attr "placeholder" "Your words appear here. Edit them whenever you like." ] []
                        p [ _id "pending"; _class "pending"; attr "aria-live" "polite" ] []
                        div [ _class "actions" ] [
                            div [] [
                                button [ _id "copy-transcript" ] [
                                    str "Copy"
                                ]
                                button [ _id "save-transcript" ] [
                                    str "Save .txt"
                                ]
                            ]
                            button [ _id "use-translation"; _class "primary" ] [
                                str "Use in translation →"
                            ]
                        ]
                    ]
                ]
                section [ _id "translate"; _class "studio"; attr "hidden" "" ] [
                    aside [] [
                        h2 [] [
                            str "Translate request"
                        ]
                        p [ _class "hint" ] [
                            str "Needle 3 prepares a structured tool call. It does not generate the\n            translated document."
                        ]
                        label [] [
                            str "From"
                            select [ _id "from" ] []
                        ]
                        label [] [
                            str "To"
                            select [ _id "to" ] []
                        ]
                        label [] [
                            str "Pre-prompt"
                            tag "textarea" [ _id "prompt"; attr "rows" "11"; attr "aria-label" "Editable translation pre-prompt" ] []
                        ]
                        button [ _id "reset-prompt"; _class "quiet" ] [
                            str "Reset from options"
                        ]
                    ]
                    div [ _class "workspace" ] [
                        div [ _class "section-head" ] [
                            h2 [] [
                                str "Document"
                            ]
                            label [ _class "file-button" ] [
                                str "Open .txt / .md"
                                input [ _id "translation-file"; _type "file"; attr "accept" ".txt,.md,text/plain,text/markdown" ]
                            ]
                        ]
                        tag "textarea" [ _id "document"; attr "spellcheck" "false"; attr "placeholder" "Paste or type multiline Markdown…"; attr "aria-label" "Translation source document" ] []
                        div [ _class "actions" ] [
                            span [ _class "hint" ] [
                                str "Ctrl / ⌘ + Enter"
                            ]
                            button [ _id "translate-run"; _class "primary" ] [
                                str "Prepare request ↗"
                            ]
                        ]
                        div [ _id "request-output"; attr "hidden" "" ] [
                            div [ _class "section-head" ] [
                                h2 [] [
                                    str "Tool call"
                                ]
                                div [] [
                                    button [ _id "copy-request" ] [
                                        str "Copy"
                                    ]
                                    button [ _id "save-request" ] [
                                        str "Save JSON"
                                    ]
                                ]
                            ]
                            pre [ _id "request-json"; attr "tabindex" "0" ] []
                        ]
                    ]
                ]
                div [ _class "status-bar"; attr "role" "status" ] [
                    span [ _id "status" ] [
                        str "Ready · nothing loaded"
                    ]
                    progress [ _id "progress"; attr "hidden" "" ] []
                    button [ _id "cancel"; attr "hidden" "" ] [
                        str "Cancel"
                    ]
                ]
            ]
            footer [] [
                span [] [
                    str "speakingwasm"
                ]
                a [ _href "https://github.com/CommanderTurtle/tts" ] [
                    str "View source on GitHub"
                ]
                a [ _href "./LICENSE" ] [
                    str "AGPL-3.0"
                ]
            ]
            script [ _type "module"; _src "./app.js" ] [ rawText ("""""") ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
