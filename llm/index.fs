module LLM.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            meta [ attr "name" "color-scheme"; attr "content" "light dark" ]
            meta [ attr "name" "description"; attr "content" "A persistent static browser harness for private-LAN OpenAI-compatible language models and tools." ]
            title [] [
                str "llm.shel.sh"
            ]
            script [ _type "module"; attr "crossorigin" ""; _src "/assets/index.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/assets/index.css" ]
        ]
        body [] [
            header [ _class "topbar" ] [
                a [ _class "brand"; _href "./"; attr "aria-label" "llm.shel.sh home" ] [
                    str "llm.shel.sh"
                ]
                button [ _id "new-chat"; _type "button" ] [
                    str "+ New chat"
                ]
                button [ _id "connect-local"; _class "primary"; _type "button" ] [
                    str "Connect"
                ]
                span [ _id "connection-status"; _class "status"; attr "data-state" "idle"; attr "role" "status"; attr "aria-live" "polite" ] [
                    str "Not connected"
                ]
                span [ _class "topbar-spacer" ] []
                button [ _id "export-markdown"; _type "button" ] [
                    str "Markdown"
                ]
                button [ _id "print-chat"; _type "button" ] [
                    str "Save PDF"
                ]
                button [ _id "import-state"; _type "button" ] [
                    str "Import state"
                ]
                button [ _id "export-state"; _type "button" ] [
                    str "Save state"
                ]
                input [ _id "import-file"; _type "file"; attr "accept" "application/json,.json"; attr "hidden" "" ]
            ]
            div [ _class "app-shell" ] [
                aside [ _class "sessions-panel"; attr "aria-label" "Saved chat sessions" ] [
                    div [ _class "panel-heading" ] [
                        h2 [] [
                            str "Chats"
                        ]
                        span [ _id "session-count"; _class "hint" ] [
                            str "1"
                        ]
                    ]
                    div [ _id "sessions"; _class "session-list" ] []
                    div [ _class "session-actions" ] [
                        button [ _id "rename-chat"; _type "button" ] [
                            str "Rename"
                        ]
                        button [ _id "delete-chat"; _class "danger"; _type "button" ] [
                            str "Delete"
                        ]
                    ]
                    p [ _id "storage-status"; _class "storage-note" ] [
                        str "Loading browser storage…"
                    ]
                ]
                main [ _class "chat-panel" ] [
                    div [ _id "messages"; _class "messages"; attr "aria-live" "polite" ] [
                        div [ _id "empty-state"; _class "empty-state" ] [
                            h1 [] [
                                str "Local agent harness"
                            ]
                            p [] [
                                str "Connect to a private OpenAI-compatible endpoint, attach local files, or enable browser tools. Chats resume after refresh."
                            ]
                        ]
                    ]
                    form [ _id "composer"; _class "composer" ] [
                        div [ _id "pending-attachments"; _class "attachment-strip"; attr "aria-live" "polite" ] []
                        p [ _id "attachment-status"; _class "hint attachment-status"; attr "hidden" "" ] []
                        label [ _class "sr-only"; attr "for" "prompt" ] [
                            str "Message"
                        ]
                        tag "textarea" [ _id "prompt"; attr "rows" "4"; attr "placeholder" "Message the local model…" ] []
                        div [ _class "composer-actions" ] [
                            button [ _id "attach"; _type "button"; attr "aria-label" "Attach files" ] [
                                str "+ Files"
                            ]
                            input [ _id "attachment-files"; _type "file"; attr "multiple" ""; attr "hidden" "" ]
                            span [ _id "conversation-stats"; _class "hint" ] [
                                str "0 messages"
                            ]
                            span [ _id "tool-count"; _class "hint" ] [
                                str "1 browser tool"
                            ]
                            span [ _class "topbar-spacer" ] []
                            button [ _id "stop"; _type "button"; attr "disabled" "" ] [
                                str "Stop"
                            ]
                            button [ _id "send"; _class "primary"; _type "submit" ] [
                                str "Send"
                            ]
                        ]
                    ]
                ]
                aside [ _class "settings"; attr "aria-label" "Connection, generation, and tool settings" ] [
                    section [] [
                        h2 [] [
                            str "Local model"
                        ]
                        label [ attr "for" "endpoint" ] [
                            str "OpenAI-compatible base URL"
                        ]
                        input [ _id "endpoint"; _type "url"; attr "value" "http://localhost:8000/v1"; attr "spellcheck" "false"; attr "autocomplete" "off" ]
                        p [ _class "hint" ] [
                            str "Localhost and private LAN only. The model path is normalized to"
                            code [] [
                                str "/v1"
                            ]
                            str "."
                        ]
                        label [ attr "for" "model" ] [
                            str "Model"
                        ]
                        input [ _id "model"; _type "text"; attr "list" "model-options"; attr "placeholder" "Connect to discover models"; attr "spellcheck" "false"; attr "autocomplete" "off" ]
                        datalist [ _id "model-options" ] []
                        p [ _id "model-count"; _class "hint" ] [
                            str "No models discovered yet."
                        ]
                    ]
                    section [] [
                        h2 [] [
                            str "Prompt"
                        ]
                        label [ attr "for" "system-prompt" ] [
                            str "System prompt"
                        ]
                        tag "textarea" [ _id "system-prompt"; attr "rows" "5"; attr "placeholder" "Optional system instructions" ] []
                    ]
                    details [] [
                        summary [] [
                            str "Generation settings"
                        ]
                        div [ _class "field-grid" ] [
                            label [ attr "for" "temperature" ] [
                                str "Temperature"
                            ]
                            input [ _id "temperature"; _type "number"; attr "min" "0"; attr "max" "2"; attr "step" "0.05"; attr "value" "0.6" ]
                            label [ attr "for" "top-p" ] [
                                str "Top P"
                            ]
                            input [ _id "top-p"; _type "number"; attr "min" "0"; attr "max" "1"; attr "step" "0.01"; attr "value" "0.95" ]
                            label [ attr "for" "max-tokens" ] [
                                str "Max tokens"
                            ]
                            input [ _id "max-tokens"; _type "number"; attr "min" "1"; attr "step" "1"; attr "value" "8192" ]
                            label [ attr "for" "seed" ] [
                                str "Seed"
                            ]
                            input [ _id "seed"; _type "number"; attr "step" "1"; attr "placeholder" "Random" ]
                            label [ attr "for" "reasoning-effort" ] [
                                str "Reasoning effort"
                            ]
                            select [ _id "reasoning-effort" ] [
                                option [ attr "value" "" ] [
                                    str "Endpoint default"
                                ]
                                option [ attr "value" "none" ] [
                                    str "None"
                                ]
                                option [ attr "value" "minimal" ] [
                                    str "Minimal"
                                ]
                                option [ attr "value" "low" ] [
                                    str "Low"
                                ]
                                option [ attr "value" "medium" ] [
                                    str "Medium"
                                ]
                                option [ attr "value" "high" ] [
                                    str "High"
                                ]
                                option [ attr "value" "xhigh" ] [
                                    str "XHigh"
                                ]
                            ]
                        ]
                        label [ _class "check-row" ] [
                            input [ _id "enable-thinking"; _type "checkbox"; attr "checked" "" ]
                            str "Pass"
                            code [] [
                                str "enable_thinking"
                            ]
                        ]
                    ]
                    details [ _id "tools-settings"; attr "open" "" ] [
                        summary [] [
                            str "Browser tools"
                        ]
                        label [ attr "for" "tool-approval" ] [
                            str "Tool approval"
                        ]
                        select [ _id "tool-approval" ] [
                            option [ attr "value" "ask" ] [
                                str "Ask before every call"
                            ]
                            option [ attr "value" "always" ] [
                                str "Allow enabled tools"
                            ]
                        ]
                        label [ attr "for" "max-tool-rounds" ] [
                            str "Maximum tool rounds"
                        ]
                        input [ _id "max-tool-rounds"; _type "number"; attr "min" "1"; attr "max" "16"; attr "step" "1"; attr "value" "8" ]
                        label [ _class "check-row" ] [
                            input [ _id "ocr-enabled"; _type "checkbox"; attr "checked" "" ]
                            str "Local image OCR"
                        ]
                        p [ _class "hint" ] [
                            str "Tesseract worker, core, and English data are bundled locally and load only when called."
                        ]
                        div [ _class "tool-group" ] [
                            label [ _class "check-row" ] [
                                input [ _id "firecrawl-enabled"; _type "checkbox" ]
                                str "Firecrawl search + scrape"
                            ]
                            label [ attr "for" "firecrawl-url" ] [
                                str "Firecrawl URL"
                            ]
                            input [ _id "firecrawl-url"; _type "url"; attr "value" "http://localhost:3002"; attr "spellcheck" "false" ]
                            div [ _class "inline-fields" ] [
                                input [ _id "firecrawl-limit"; _type "number"; attr "min" "1"; attr "max" "10"; attr "value" "5"; attr "aria-label" "Default Firecrawl result count" ]
                                button [ _id "test-firecrawl"; _type "button" ] [
                                    str "Test"
                                ]
                            ]
                            p [ _id "firecrawl-status"; _class "hint" ] [
                                str "Disabled."
                            ]
                        ]
                        div [ _class "tool-group" ] [
                            h3 [] [
                                str "MCP Streamable HTTP"
                            ]
                            label [ attr "for" "mcp-name" ] [
                                str "Name"
                            ]
                            input [ _id "mcp-name"; _type "text"; attr "placeholder" "Firebending bridge" ]
                            label [ attr "for" "mcp-url" ] [
                                str "Local MCP URL"
                            ]
                            input [ _id "mcp-url"; _type "url"; attr "placeholder" "http://localhost:3001/mcp"; attr "spellcheck" "false" ]
                            button [ _id "add-mcp"; _type "button" ] [
                                str "Add and discover"
                            ]
                            div [ _id "mcp-list"; _class "mcp-list" ] []
                        ]
                    ]
                    details [ _id "connection-help" ] [
                        summary [] [
                            str "Connection help"
                        ]
                        p [] [
                            str "Connect directly fetches"
                            code [] [
                                str "/v1/models"
                            ]
                            str "with the destination labeled"
                            code [] [
                                str "loopback"
                            ]
                            str "or"
                            code [] [
                                str "local"
                            ]
                            str ". On a public HTTPS page, that is the browser's permission trigger. A page already served from localhost normally does not need a prompt."
                        ]
                        p [] [
                            code [] [
                                str "ERR_BLOCKED_BY_CLIENT"
                            ]
                            str "means the request stopped inside the browser. Allow Local network access in this site's permissions and check content-blocking extensions. Modern Chromium can relax HTTPS-to-HTTP local mixed-content blocking after permission is granted; browsers without that support require an HTTPS endpoint or the locally served page."
                        ]
                        p [ _id "connection-detail" ] [
                            str "No request has been made."
                        ]
                    ]
                    p [ _class "storage-note" ] [
                        strong [] [
                            str "Local-first:"
                        ]
                        str "chats and attachments are stored in this browser's IndexedDB. Importing state never contacts a service."
                    ]
                ]
            ]
            dialog [ _id "edit-dialog" ] [
                form [ attr "method" "dialog"; _class "dialog-card" ] [
                    h2 [] [
                        str "Edit transcript message"
                    ]
                    p [ _class "hint" ] [
                        str "The edited text becomes the exact context sent on future turns."
                    ]
                    tag "textarea" [ _id "edit-content"; attr "rows" "14" ] []
                    div [ _class "dialog-actions" ] [
                        button [ attr "value" "cancel" ] [
                            str "Cancel"
                        ]
                        button [ _id "save-edit"; _class "primary"; attr "value" "default" ] [
                            str "Save"
                        ]
                    ]
                ]
            ]
            dialog [ _id "tool-dialog" ] [
                form [ attr "method" "dialog"; _class "dialog-card" ] [
                    h2 [] [
                        str "Allow local tool call?"
                    ]
                    p [ _id "tool-dialog-name"; _class "tool-call-name" ] []
                    pre [ _id "tool-dialog-arguments" ] []
                    div [ _class "dialog-actions" ] [
                        button [ attr "value" "deny" ] [
                            str "Deny"
                        ]
                        button [ _class "primary"; attr "value" "allow" ] [
                            str "Allow"
                        ]
                    ]
                ]
            ]
            div [ _id "toast"; _class "toast"; attr "role" "status"; attr "aria-live" "polite" ] []
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
