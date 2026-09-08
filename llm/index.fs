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
                button [ _id "copy-markdown"; _class "icon-button"; _type "button"; attr "title" "Copy conversation Markdown"; attr "aria-label" "Copy conversation Markdown"; attr "hidden" "" ] [
                    str "⧉"
                ]
                button [ _id "share-markdown"; _class "icon-button"; _type "button"; attr "title" "Open conversation Markdown in a.shel.sh"; attr "aria-label" "Open conversation Markdown in a.shel.sh"; attr "hidden" "" ] [
                    str "↗"
                ]
                button [ _id "undo"; _class "icon-button"; _type "button"; attr "title" "Undo last deleted turn"; attr "aria-label" "Undo last deleted turn"; attr "disabled" ""; attr "hidden" "" ] [
                    str "↶"
                ]
                button [ _id "open-workspace"; _type "button"; attr "hidden" "" ] [
                    str "Workspace"
                ]
                button [ _id "open-navigator"; _type "button"; attr "hidden" "" ] [
                    str "Timeline"
                ]
                button [ _id "context-meter"; _class "context-meter"; _type "button"; attr "title" "View context and compaction"; attr "aria-label" "View context and compaction"; attr "hidden" "" ] [
                    span [ _id "context-ring"; _class "context-ring" ] [
                        span [ _id "context-percent" ] [
                            str "0%"
                        ]
                    ]
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
                            label [ _id "context-window-label"; attr "for" "context-window"; attr "hidden" "" ] [
                                str "Context window"
                            ]
                            input [ _id "context-window"; _type "number"; attr "min" "1"; attr "step" "1"; attr "value" "131072"; attr "hidden" "" ]
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
                    details [ _id "feature-matrix" ] [
                        summary [] [
                            str "Feature matrix"
                        ]
                        p [ _class "hint" ] [
                            str "Every enhancement is opt-in. Drag across boxes to paint a choice; Shift-click selects every feature in the same group. With all boxes clear, requests and interaction match the last baseline release."
                        ]
                        div [ _class "feature-matrix" ] [
                            label [ _class "feature-row"; attr "data-feature-group" "reliability" ] [
                                input [ _id "feature-stream-recovery"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Interrupted-response recovery"
                                    ]
                                    small [] [
                                        str "Recognize missing terminal signals or output limits and offer Continue on the latest assistant turn."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "reliability" ] [
                                input [ _id "feature-auto-max-tokens"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Server-decided output allowance"
                                    ]
                                    small [] [
                                        str "Omit"
                                        code [] [
                                            str "max_tokens"
                                        ]
                                        str "; disabling restores the 8192 baseline."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "presentation" ] [
                                input [ _id "feature-rich-markdown"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Rich Markdown"
                                    ]
                                    small [] [
                                        str "Syntax highlighting, Mermaid, math, task lists, and inline diagnostics."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "reliability" ] [
                                input [ _id "feature-parallel-sessions"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Parallel chats"
                                    ]
                                    small [] [
                                        str "Switch or create chats while other sessions continue generating, with no per-token session-list repaint."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "presentation" ] [
                                input [ _id "feature-markdown-actions"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Complete Markdown export"
                                    ]
                                    small [] [
                                        str "Copy, download, or open a rich transcript containing every original turn, reasoning block, tool call, and compaction record."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "reliability" ] [
                                input [ _id "feature-vision-retry"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Vision resize recovery"
                                    ]
                                    small [] [
                                        str "Retry dimension ValueErrors in-browser, reducing the longest side by 128px each time."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "reliability" ] [
                                input [ _id "feature-stable-scroll"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Stable streaming scroll"
                                    ]
                                    small [] [
                                        str "Follow only near the bottom; preserve the reasoning node, disclosure, and nested scroll position."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "context" ] [
                                input [ _id "feature-context-meter"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Context meter"
                                    ]
                                    small [] [
                                        str "Show per-chat token estimates and the circular context gauge."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "context" ] [
                                input [ _id "feature-compaction"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Composable context controls"
                                    ]
                                    small [] [
                                        str "Stack lossless Soft collapses and selected Normal summaries without reopening earlier groups."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "tools" ] [
                                input [ _id "feature-image-reads"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Scraped image reads"
                                    ]
                                    small [] [
                                        str "Expose source-bound"
                                        code [] [
                                            str "view_image"
                                        ]
                                        str "for images discovered in earlier Firecrawl results."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "tools" ] [
                                input [ _id "read-tools-enabled"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Browser read tools"
                                    ]
                                    small [] [
                                        str "Let the model reopen exact context, reasoning, instructions, and documents."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "tools" ] [
                                input [ _id "write-tools-enabled"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Document write tools"
                                    ]
                                    small [] [
                                        str "Store a formal response ending in DONE directly, or make precise hashline edits after reading."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "tools" ] [
                                input [ _id "todo-tools-enabled"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "TODO tool"
                                    ]
                                    small [] [
                                        str "Expose the per-chat checklist, including one-click cleanup that keeps the latest item."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "editing" ] [
                                input [ _id "feature-undo-delete"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Undo deleted turns"
                                    ]
                                    small [] [
                                        str "Keep a short browser-local undo stack for transcript deletions."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "editing" ] [
                                input [ _id "feature-turn-controls"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Advanced turn controls"
                                    ]
                                    small [] [
                                        str "Copy/edit reasoning and edit or remove individual malformed tool requests without deleting their assistant turn."
                                    ]
                                ]
                            ]
                            label [ _class "feature-row"; attr "data-feature-group" "presentation" ] [
                                input [ _id "feature-transcript-navigator"; _type "checkbox" ]
                                span [] [
                                    strong [] [
                                        str "Timeline + search"
                                    ]
                                    small [] [
                                        str "Open a color-coded jump bar and fuzzy transcript search; quote a phrase for exact matching."
                                    ]
                                ]
                            ]
                        ]
                        div [ _class "matrix-actions" ] [
                            button [ _id "feature-enable-all"; _type "button" ] [
                                str "Enable all"
                            ]
                            button [ _id "feature-disable-all"; _type "button" ] [
                                str "Clear all"
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
                    h2 [ _id "edit-dialog-title" ] [
                        str "Edit transcript message"
                    ]
                    p [ _id "edit-dialog-hint"; _class "hint" ] [
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
                    div [ _id "tool-dialog-context"; _class "tool-approval-context"; attr "hidden" "" ] []
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
            dialog [ _id "context-dialog"; _class "wide-dialog" ] [
                div [ _class "dialog-card" ] [
                    h2 [] [
                        str "Context"
                    ]
                    p [ _id "context-detail"; _class "hint" ] []
                    div [ _id "context-timeline"; _class "context-timeline"; attr "aria-label" "Conversation timeline" ] []
                    section [ _id "transcript-search-section"; _class "transcript-search"; attr "hidden" "" ] [
                        label [ attr "for" "transcript-search" ] [
                            str "Search this transcript"
                        ]
                        input [ _id "transcript-search"; _type "search"; attr "placeholder" "Fuzzy words, or “an exact phrase”"; attr "autocomplete" "off" ]
                        div [ _id "transcript-search-results"; _class "transcript-search-results"; attr "aria-live" "polite" ] []
                    ]
                    div [ _id "compaction-controls" ] [
                        div [ _class "context-actions" ] [
                            button [ _id "compact-soft"; _type "button" ] [
                                str "Soft · index Firecrawl"
                            ]
                            button [ _id "compact-context-reads"; _type "button" ] [
                                str "Soft · collapse context reads"
                            ]
                            button [ _id "compact-normal"; _class "primary"; _type "button" ] [
                                str "Normal · summarize selected"
                            ]
                            button [ _id "restore-context"; _type "button" ] [
                                str "Restore originals"
                            ]
                        ]
                        label [ attr "for" "compaction-prompt" ] [
                            str "Stateless summarizer prompt"
                        ]
                        tag "textarea" [ _id "compaction-prompt"; attr "rows" "5" ] []
                        div [ _class "panel-heading compact-heading" ] [
                            h3 [] [
                                str "Select exact entries for Normal compaction"
                            ]
                            button [ _id "select-older-context"; _type "button" ] [
                                str "Select older"
                            ]
                            button [ _id "clear-context-selection"; _type "button" ] [
                                str "Clear selection"
                            ]
                        ]
                        p [ _class "hint" ] [
                            str "Drag across boxes to paint a selection. Shift-click selects every available entry of the same role or tool type."
                        ]
                        div [ _id "compaction-messages"; _class "compaction-list" ] []
                        div [ _id "active-compaction"; _class "active-compaction" ] []
                    ]
                    div [ _class "dialog-actions" ] [
                        button [ _id "close-context"; _type "button" ] [
                            str "Close"
                        ]
                    ]
                ]
            ]
            dialog [ _id "workspace-dialog"; _class "wide-dialog" ] [
                div [ _class "dialog-card" ] [
                    div [ _class "dialog-title-row" ] [
                        div [] [
                            h2 [] [
                                str "Browser workspace"
                            ]
                            p [ _class "hint" ] [
                                str "TODOs, instructions, documents, and every revision live only in this saved chat."
                            ]
                        ]
                        button [ _id "close-workspace"; _type "button"; attr "aria-label" "Close workspace" ] [
                            str "×"
                        ]
                    ]
                    section [ _id "todo-workspace-section"; _class "workspace-section" ] [
                        div [ _class "workspace-section-heading" ] [
                            h3 [] [
                                str "TODO"
                            ]
                            button [ _id "clear-todos-except-recent"; _type "button" ] [
                                str "Clear all but recent"
                            ]
                        ]
                        div [ _id "todo-list"; _class "todo-list" ] []
                        div [ _class "workspace-add-row" ] [
                            input [ _id "todo-input"; _type "text"; attr "placeholder" "Add a task" ]
                            button [ _id "add-todo"; _type "button" ] [
                                str "Add"
                            ]
                        ]
                    ]
                    section [ _id "document-workspace-section"; _class "workspace-section" ] [
                        div [ _class "document-toolbar" ] [
                            select [ _id "document-select"; attr "aria-label" "Document" ] []
                            button [ _id "new-document"; _type "button" ] [
                                str "New"
                            ]
                            button [ _id "open-instructions"; _type "button" ] [
                                str "Instructions"
                            ]
                            select [ _id "document-revision"; attr "aria-label" "Revision" ] []
                        ]
                        div [ _class "document-fields" ] [
                            input [ _id "document-name"; _type "text"; attr "placeholder" "document.md" ]
                            input [ _id "document-language"; _type "text"; attr "placeholder" "markdown" ]
                        ]
                        tag "textarea" [ _id "document-content"; _class "document-editor"; attr "rows" "16"; attr "spellcheck" "false"; attr "placeholder" "A model can create a document with put_document, or you can write one here." ] []
                        div [ _class "document-actions" ] [
                            span [ _id "document-diagnostics"; _class "hint" ] []
                            span [ _class "topbar-spacer" ] []
                            button [ _id "save-document"; _class "primary"; _type "button" ] [
                                str "Save revision"
                            ]
                        ]
                        details [ _id "document-diff-details" ] [
                            summary [] [
                                str "Revision diff"
                            ]
                            div [ _id "document-diff"; _class "diff-view" ] []
                        ]
                        div [ _id "document-preview"; _class "document-preview message-body" ] []
                    ]
                ]
            ]
            div [ _id "toast"; _class "toast"; attr "role" "status"; attr "aria-live" "polite" ] []
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
