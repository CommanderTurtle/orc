module Jev.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width,initial-scale=1" ]
            meta [ attr "name" "color-scheme"; attr "content" "light dark" ]
            meta [ attr "name" "referrer"; attr "content" "no-referrer" ]
            meta [ attr "name" "description"; attr "content" "A local-first playground for finite decisions, autonomous racing, pixel painting, data inference and live chat replay." ]
            title [] [
                str "jev infer"
            ]
            script [ _type "module"; attr "crossorigin" ""; _src "/jev/assets/index.js" ] [ rawText ("""""") ]
            link [ attr "rel" "stylesheet"; attr "crossorigin" ""; _href "/jev/assets/index.css" ]
        ]
        body [] [
            header [ _class "topbar" ] [
                a [ _class "brand"; _href "#playground" ] [
                    span [ _class "brand-mark" ] [
                        str "j"
                    ]
                    str "jev"
                    span [] [
                        str "infer"
                    ]
                ]
                nav [ attr "aria-label" "Experiments" ] [
                    button [ _class "tab active"; attr "data-tab" "playground" ] [
                        small [] [
                            str "01"
                        ]
                        str "Playground"
                    ]
                    button [ _class "tab"; attr "data-tab" "drive" ] [
                        small [] [
                            str "02"
                        ]
                        str "Drive"
                    ]
                    button [ _class "tab"; attr "data-tab" "paint" ] [
                        small [] [
                            str "03"
                        ]
                        str "Paint"
                    ]
                    button [ _class "tab"; attr "data-tab" "tornado" ] [
                        small [] [
                            str "04"
                        ]
                        str "Tornado"
                    ]
                    button [ _class "tab"; attr "data-tab" "chat" ] [
                        small [] [
                            str "05"
                        ]
                        str "Chat"
                    ]
                    button [ _class "tab"; attr "data-tab" "green-light" ] [
                        small [] [
                            str "06"
                        ]
                        str "Green Light"
                    ]
                    button [ _class "tab"; attr "data-tab" "pacman" ] [
                        small [] [
                            str "07"
                        ]
                        str "Pac-Man"
                    ]
                ]
                button [ _id "settings-open"; _class "connection" ] [
                    i [ _id "connection-dot" ] []
                    span [ _id "connection-label" ] [
                        str "Connect endpoint"
                    ]
                    span [] [
                        str "↗"
                    ]
                ]
            ]
            main [] [
                section [ _id "playground"; _class "pane active" ] [
                    div [ _class "page-title" ] [
                        h1 [] [
                            str "Playground"
                        ]
                    ]
                    div [ _class "play-grid" ] [
                        div [ _class "card input-card" ] [
                            div [ _class "card-top" ] [
                                h2 [] [
                                    span [ _class "step" ] [
                                        str "01"
                                    ]
                                    str "The state"
                                ]
                                select [ _id "preset"; attr "aria-label" "Example scenario" ] [
                                    option [ attr "value" "support" ] [
                                        str "Support ticket"
                                    ]
                                    option [ attr "value" "invoice" ] [
                                        str "Invoice review"
                                    ]
                                    option [ attr "value" "robot" ] [
                                        str "Robot handoff"
                                    ]
                                    option [ attr "value" "blank" ] [
                                        str "Start empty"
                                    ]
                                ]
                            ]
                            tag "textarea" [ _id "state-input"; _class "state-text"; attr "aria-label" "Current state"; attr "spellcheck" "false" ] []
                            div [ _class "card-top questions-heading" ] [
                                h2 [] [
                                    span [ _class "step" ] [
                                        str "02"
                                    ]
                                    str "The questions"
                                ]
                                button [ _id "add-question"; _class "text-button" ] [
                                    str "＋ Add question"
                                ]
                            ]
                            div [ _id "question-list" ] []
                            div [ _class "form-actions" ] [
                                button [ _id "run-play"; _class "primary" ] [
                                    str "Run inference"
                                    span [] [
                                        str "↗"
                                    ]
                                ]
                                button [ _id "stop-play"; attr "disabled" "" ] [
                                    str "Stop"
                                ]
                                button [ _id "export-schema"; _class "quiet" ] [
                                    str "Save setup"
                                ]
                                label [ _class "button quiet" ] [
                                    str "Load setup"
                                    input [ _type "file"; _id "import-schema"; attr "accept" ".json"; attr "hidden" "" ]
                                ]
                            ]
                        ]
                        div [ _class "results-column" ] [
                            div [ _class "results-heading" ] [
                                div [] [
                                    h2 [] [
                                        str "Results"
                                    ]
                                ]
                                span [ _id "play-latency"; _class "badge" ] [
                                    str "Not run"
                                ]
                            ]
                            div [ _id "answers"; _class "answer-stack" ] [
                                div [ _class "empty-result" ] [
                                    div [ _class "orbit-icon" ] [
                                        str "◌"
                                    ]
                                    h3 [] [
                                        str "Ready"
                                    ]
                                    div [ _class "placeholder-bars" ] [
                                        i [] []
                                        i [] []
                                        i [] []
                                    ]
                                ]
                            ]
                            details [ _class "raw-card" ] [
                                summary [] [
                                    str "Request & response"
                                    span [] [
                                        str "JSON ↗"
                                    ]
                                ]
                                pre [ _id "raw-output" ] [
                                    str "{}"
                                ]
                                button [ _id "export-result"; attr "disabled" "" ] [
                                    str "Download result"
                                ]
                            ]
                        ]
                    ]
                ]
                section [ _id "drive"; _class "pane" ] [
                    div [ _class "compact-title" ] [
                        h1 [] [
                            str "Drive"
                        ]
                    ]
                    div [ _class "lab-grid" ] [
                        div [ _class "race-stage" ] [
                            canvas [ _id "race-canvas"; attr "aria-label" "3D driving simulator" ] []
                            div [ _class "race-hud" ] [
                                span [] [
                                    str "DRIVE"
                                    b [ _id "race-mode" ] [
                                        str "PARKED"
                                    ]
                                ]
                                span [] [
                                    b [ _id "race-speed" ] [
                                        str "0"
                                    ]
                                    str "km/h"
                                ]
                                span [] [
                                    b [ _id "race-distance" ] [
                                        str "0"
                                    ]
                                    str "m"
                                ]
                            ]
                            canvas [ _id "race-map"; attr "width" "160"; attr "height" "160"; attr "aria-label" "Course minimap" ] []
                            div [ _class "race-bottom" ] [
                                span [ _id "race-command" ] [
                                    str "Ready"
                                ]
                                span [ _id "race-latency" ] [
                                    str "—"
                                ]
                            ]
                        ]
                        aside [ _class "card lab-controls" ] [
                            h2 [] [
                                str "Control"
                            ]
                            div [ _class "two-cols" ] [
                                label [] [
                                    str "Course"
                                    select [ _id "race-course" ] [
                                        option [ attr "value" "traffic" ] [
                                            str "Traffic"
                                        ]
                                        option [ attr "value" "race" ] [
                                            str "2 km sprint"
                                        ]
                                        option [ attr "value" "parking" ] [
                                            str "Parking"
                                        ]
                                        option [ attr "value" "slalom" ] [
                                            str "Cone slalom"
                                        ]
                                        option [ attr "value" "kart" ] [
                                            str "Kart circuit"
                                        ]
                                        option [ attr "value" "city" ] [
                                            str "City blocks"
                                        ]
                                        option [ attr "value" "pirate" ] [
                                            str "Pirate getaway"
                                        ]
                                    ]
                                ]
                                label [] [
                                    str "Traffic"
                                    select [ _id "race-density" ] [
                                        option [ attr "value" "low" ] [
                                            str "Low"
                                        ]
                                        option [ attr "value" "medium"; attr "selected" "" ] [
                                            str "Medium"
                                        ]
                                        option [ attr "value" "high" ] [
                                            str "High"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "two-cols" ] [
                                label [] [
                                    str "Simulation speed"
                                    select [ _id "race-timescale" ] [
                                        option [ attr "value" ".5" ] [
                                            str "0.5×"
                                        ]
                                        option [ attr "value" "1"; attr "selected" "" ] [
                                            str "1×"
                                        ]
                                        option [ attr "value" "2" ] [
                                            str "2×"
                                        ]
                                        option [ attr "value" "3" ] [
                                            str "3×"
                                        ]
                                        option [ attr "value" "5" ] [
                                            str "5×"
                                        ]
                                    ]
                                ]
                                label [] [
                                    str "Decision interval"
                                    select [ _id "race-interval" ] [
                                        option [ attr "value" "0"; attr "selected" "" ] [
                                            str "As ready"
                                        ]
                                        option [ attr "value" "100" ] [
                                            str "100 ms"
                                        ]
                                        option [ attr "value" "200" ] [
                                            str "200 ms"
                                        ]
                                        option [ attr "value" "500" ] [
                                            str "500 ms"
                                        ]
                                        option [ attr "value" "1000" ] [
                                            str "1 second"
                                        ]
                                    ]
                                ]
                            ]
                            label [] [
                                str "Camera"
                                select [ _id "race-camera" ] [
                                    option [ attr "value" "chase" ] [
                                        str "Chase"
                                    ]
                                    option [ attr "value" "hood" ] [
                                        str "Bonnet"
                                    ]
                                    option [ attr "value" "overhead" ] [
                                        str "Overhead"
                                    ]
                                ]
                            ]
                            output [ _id "race-actuators"; _class "micro" ] [
                                str "Direct controls"
                            ]
                            button [ _id "race-start"; _class "primary" ] [
                                str "Jev drive"
                            ]
                            div [ _class "button-row" ] [
                                button [ _id "race-stop"; attr "disabled" "" ] [
                                    str "Pause"
                                ]
                                button [ _id "race-demo" ] [
                                    str "Manual drive"
                                ]
                                button [ _id "race-reset" ] [
                                    str "Reset"
                                ]
                                button [ _id "race-recover" ] [
                                    str "Recover"
                                ]
                            ]
                            div [ _id "race-manual"; _class "manual-panel"; attr "aria-label" "Vehicle controls" ] []
                            label [ _class "drive-check" ] [
                                input [ _type "checkbox"; _id "race-assist" ]
                                str "Recovery assist"
                            ]
                            label [ _class "drive-check"; attr "hidden" "" ] [
                                input [ _type "checkbox"; _id "race-police-lights"; attr "checked" "" ]
                                str "Police flashers"
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Time"
                                ]
                                strong [ _id "race-clock" ] [
                                    str "0 s"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Progress"
                                ]
                                strong [ _id "race-position" ] [
                                    str "0 passed"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Telemetry"
                                ]
                                strong [ _id "race-detail" ] [
                                    str "—"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Collisions"
                                ]
                                strong [ _id "race-hits" ] [
                                    str "0"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Decisions"
                                ]
                                strong [ _id "race-decisions" ] [
                                    str "0"
                                ]
                            ]
                            div [ _id "race-log"; _class "event-log"; attr "aria-live" "polite" ] []
                            details [ _id "race-sensor-panel" ] [
                                summary [] [
                                    str "Model state"
                                ]
                                pre [ _id "race-sensors" ] []
                            ]
                        ]
                    ]
                ]
                section [ _id "pacman"; _class "pane" ] [
                    div [ _class "compact-title" ] [
                        h1 [] [
                            str "Pac-Man"
                        ]
                        a [ _class "micro"; _href "https://github.com/opper-ai/jevman-benchmark/tree/b202e2cefd3dcf62b99835b319450b687960f40a"; attr "target" "_blank"; attr "rel" "noopener noreferrer" ] [
                            str "Jevman ↗"
                        ]
                    ]
                    div [ _class "pacman-grid" ] [
                        div [ _class "pacman-stage" ] [
                            div [ _class "pacman-hud" ] [
                                span [] [
                                    str "SCORE"
                                    b [ _id "pacman-score" ] [
                                        str "0"
                                    ]
                                ]
                                span [] [
                                    str "LIVES"
                                    b [ _id "pacman-lives" ] [
                                        str "3"
                                    ]
                                ]
                                span [] [
                                    str "LEVEL"
                                    b [ _id "pacman-level" ] [
                                        str "1"
                                    ]
                                ]
                            ]
                            canvas [ _id "pacman-canvas"; attr "width" "560"; attr "height" "620"; attr "tabindex" "0"; attr "aria-label" "Pac-Man maze. Arrow keys or WASD to steer in human mode. Space pauses, R restarts." ] []
                            output [ _id "pacman-status"; attr "aria-live" "polite" ] [
                                str "READY"
                            ]
                        ]
                        aside [ _class "card lab-controls" ] [
                            h2 [] [
                                str "Control"
                            ]
                            label [] [
                                str "Players"
                                select [ _id "pacman-mode" ] [
                                    option [ attr "value" "pacman" ] [
                                        str "Jev Pac-Man · classic ghosts"
                                    ]
                                    option [ attr "value" "classic" ] [
                                        str "Human Pac-Man · classic ghosts"
                                    ]
                                    option [ attr "value" "ghosts" ] [
                                        str "Human Pac-Man · Jev ghosts"
                                    ]
                                    option [ attr "value" "both" ] [
                                        str "Jev · both sides"
                                    ]
                                ]
                            ]
                            label [] [
                                str "Simulation speed"
                                select [ _id "pacman-speed" ] [
                                    option [ attr "value" ".5" ] [
                                        str "0.5×"
                                    ]
                                    option [ attr "value" "1"; attr "selected" "" ] [
                                        str "1×"
                                    ]
                                    option [ attr "value" "2" ] [
                                        str "2×"
                                    ]
                                ]
                            ]
                            div [ _class "button-row" ] [
                                button [ _id "pacman-start"; _class "primary" ] [
                                    str "Start"
                                ]
                                button [ _id "pacman-pause"; attr "disabled" "" ] [
                                    str "Pause"
                                ]
                                button [ _id "pacman-reset" ] [
                                    str "Reset"
                                ]
                            ]
                            div [ _class "button-row" ] [
                                button [ _id "pacman-sound"; attr "aria-pressed" "true" ] [
                                    str "Sound on"
                                ]
                                label [ _class "drive-check" ] [
                                    input [ _id "pacman-odds"; _type "checkbox"; attr "checked" "" ]
                                    str "Decision arrows"
                                ]
                            ]
                            div [ _id "pacman-pad"; _class "pacman-pad"; attr "hidden" ""; attr "aria-label" "Pac-Man controls" ] [
                                button [ attr "data-pacman-dir" "up"; attr "aria-label" "Up" ] [
                                    str "↑"
                                    kbd [] [
                                        str "W"
                                    ]
                                ]
                                button [ attr "data-pacman-dir" "left"; attr "aria-label" "Left" ] [
                                    str "←"
                                    kbd [] [
                                        str "A"
                                    ]
                                ]
                                button [ attr "data-pacman-dir" "down"; attr "aria-label" "Down" ] [
                                    str "↓"
                                    kbd [] [
                                        str "S"
                                    ]
                                ]
                                button [ attr "data-pacman-dir" "right"; attr "aria-label" "Right" ] [
                                    str "→"
                                    kbd [] [
                                        str "D"
                                    ]
                                ]
                            ]
                            p [ _class "micro" ] [
                                str "WASD / arrows · swipe · Space pause · R restart"
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Pellets"
                                ]
                                strong [ _id "pacman-pellets" ] [
                                    str "244"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Requests"
                                ]
                                strong [ _id "pacman-calls" ] [
                                    str "0"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "In flight"
                                ]
                                strong [ _id "pacman-pending" ] [
                                    str "0"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Round trip"
                                ]
                                strong [ _id "pacman-latency" ] [
                                    str "—"
                                ]
                            ]
                            div [ _id "pacman-decisions"; attr "aria-label" "Latest decisions" ] []
                            details [ _id "pacman-inspect" ] [
                                summary [] [
                                    str "State & inference"
                                ]
                                pre [ _id "pacman-state" ] [
                                    str "{}"
                                ]
                            ]
                        ]
                    ]
                ]
                section [ _id "green-light"; _class "pane" ] [
                    div [ _class "green-heading" ] [
                        h1 [] [
                            str "Green Light"
                        ]
                        div [ _class "button-row" ] [
                            button [ _id "green-sound"; attr "aria-pressed" "false" ] [
                                str "Enable sound"
                            ]
                            button [ _id "green-pause" ] [
                                str "Pause"
                            ]
                            button [ _id "green-restart" ] [
                                str "Restart"
                            ]
                            button [ _id "green-fullscreen"; attr "title" "Fullscreen" ] [
                                str "⛶"
                            ]
                        ]
                    ]
                    div [ _id "green-stage"; _class "green-stage" ] [
                        canvas [ _id "green-canvas"; attr "tabindex" "0"; attr "aria-label" "Green Light backyard. WASD to walk, mouse or drag to look. Left and right arrows also turn. Stop moving to disappear from the motion camera. Reach the back door." ] []
                        div [ _class "green-vignette"; attr "aria-hidden" "true" ] []
                        div [ _class "green-grain"; attr "aria-hidden" "true" ] []
                        div [ _class "green-hud" ] [
                            span [] [
                                i [] []
                                str "GREEN LIGHT"
                            ]
                            span [ _id "green-status" ] [
                                str "READY"
                            ]
                        ]
                        div [ _class "green-reticle"; attr "aria-hidden" "true" ] [
                            str "·"
                        ]
                        div [ _class "green-controls" ] [
                            div [ _class "green-pad"; attr "aria-label" "Walking controls" ] [
                                button [ attr "data-green-key" "KeyW"; attr "aria-label" "Walk forward"; attr "aria-pressed" "false" ] [
                                    str "W"
                                ]
                                button [ attr "data-green-key" "KeyA"; attr "aria-label" "Walk left"; attr "aria-pressed" "false" ] [
                                    str "A"
                                ]
                                button [ attr "data-green-key" "KeyS"; attr "aria-label" "Walk backward"; attr "aria-pressed" "false" ] [
                                    str "S"
                                ]
                                button [ attr "data-green-key" "KeyD"; attr "aria-label" "Walk right"; attr "aria-pressed" "false" ] [
                                    str "D"
                                ]
                                button [ _id "green-sprint"; attr "data-green-key" "ShiftLeft"; attr "aria-label" "Sprint"; attr "aria-pressed" "false"; attr "disabled" "" ] [
                                    str "Shift"
                                ]
                            ]
                            span [] [
                                span [ _id "green-model-action" ] [
                                    str "Jev · Awaiting motion"
                                ]
                                br []
                                str "WASD walk · Shift sprint · mouse / drag look · Esc pause"
                            ]
                        ]
                        div [ _id "green-overlay"; _class "green-overlay"; attr "role" "status"; attr "aria-live" "polite"; attr "hidden" "" ] [
                            div [ _class "green-smoke"; attr "aria-hidden" "true" ] []
                            button [ _id "green-exit-intro"; _class "green-skip" ] [
                                str "Skip / pause"
                            ]
                            div [ _class "green-story" ] [
                                h2 [ _id "green-story-title" ] []
                                p [ _id "green-story-line" ] []
                                button [ _id "green-action"; attr "hidden" "" ] [
                                    str "Enter yard"
                                ]
                            ]
                        ]
                    ]
                    div [ _class "green-footer" ] [
                        span [ _id "green-network" ] [
                            str "0 decisions · —"
                        ]
                        label [] [
                            input [ _id "green-flashes"; _type "checkbox" ]
                            str "Reduced flashes"
                        ]
                        details [] [
                            summary [] [
                                str "Model state"
                            ]
                            span [ _id "green-mechanics" ] []
                            pre [ _id "green-inspection" ] []
                        ]
                    ]
                ]
                section [ _id "paint"; _class "pane" ] [
                    div [ _class "compact-title" ] [
                        h1 [] [
                            str "Paint"
                        ]
                        span [ _id "paint-status"; _class "badge" ] [
                            str "Ready"
                        ]
                    ]
                    div [ _class "lab-grid" ] [
                        div [ _class "paint-stage" ] [
                            div [ _class "canvas-mat" ] [
                                canvas [ _id "paint-canvas"; attr "width" "1024"; attr "height" "1024"; attr "aria-label" "Editable pixel or skin painting" ] []
                                span [ _id "paint-watermark" ] []
                            ]
                            div [ _class "paint-caption" ] [
                                span [ _id "paint-progress" ] [
                                    str "0 pixels inferred"
                                ]
                                span [ _id "paint-time" ] [
                                    str "—"
                                ]
                            ]
                            canvas [ _id "skin-preview"; attr "width" "192"; attr "height" "256"; attr "aria-label" "Skin front preview"; attr "hidden" "" ] []
                        ]
                        aside [ _class "card lab-controls"; _id "paint-controls" ] [
                            tag "textarea" [ _id "paint-prompt"; attr "rows" "3"; attr "aria-label" "Painting description" ] [
                                str "A tiny pink house on a green hill, a golden sun and a deep blue sky. Bold simple shapes."
                            ]
                            label [] [
                                str "Canvas preset"
                                select [ _id "paint-template" ] [
                                    option [ attr "value" "square" ] [
                                        str "Standard square canvas"
                                    ]
                                    option [ attr "value" "classic" ] [
                                        str "Minecraft · classic arms"
                                    ]
                                    option [ attr "value" "slim" ] [
                                        str "Minecraft · slim arms"
                                    ]
                                    option [ attr "value" "custom" ] [
                                        str "Custom canvas & regions"
                                    ]
                                ]
                            ]
                            div [ _id "paint-square" ] [
                                label [] [
                                    str "Inference grid (pixels per side)"
                                    input [ _id "paint-grid"; _type "number"; attr "min" "1"; attr "max" "1024"; attr "value" "16" ]
                                ]
                            ]
                            div [ _id "paint-custom"; attr "hidden" "" ] [
                                div [ _class "two-cols" ] [
                                    label [] [
                                        str "Width"
                                        input [ _id "paint-width"; _type "number"; attr "min" "1"; attr "max" "1024"; attr "value" "32" ]
                                    ]
                                    label [] [
                                        str "Height"
                                        input [ _id "paint-height"; _type "number"; attr "min" "1"; attr "max" "1024"; attr "value" "16" ]
                                    ]
                                ]
                                label [] [
                                    str "Named regions (optional JSON)"
                                    tag "textarea" [ _id "paint-regions"; attr "rows" "3"; attr "spellcheck" "false" ] [
                                        str "[]"
                                    ]
                                ]
                                p [ _class "micro" ] [
                                    str "Example: [{\"name\":\"Head\",\"x\":0,\"y\":0,\"width\":8,\"height\":8}]"
                                ]
                                div [ _class "button-row" ] [
                                    button [ _id "paint-save-layout" ] [
                                        str "Save layout"
                                    ]
                                    button [ _id "paint-load-layout" ] [
                                        str "Load saved"
                                    ]
                                ]
                            ]
                            div [ _class "button-row" ] [
                                button [ _id "paint-apply" ] [
                                    str "Apply / New canvas"
                                ]
                                label [ _class "button" ] [
                                    str "Import PNG"
                                    input [ _type "file"; _id "paint-import"; attr "accept" "image/png"; attr "hidden" "" ]
                                ]
                            ]
                            label [] [
                                str "Edit region"
                                select [ _id "paint-region" ] []
                            ]
                            div [ _class "two-cols" ] [
                                label [] [
                                    str "Brush"
                                    select [ _id "paint-tool" ] [
                                        option [ attr "value" "paint" ] [
                                            str "Paint"
                                        ]
                                        option [ attr "value" "erase" ] [
                                            str "Erase"
                                        ]
                                        option [ attr "value" "pick" ] [
                                            str "Pick color"
                                        ]
                                    ]
                                ]
                                label [] [
                                    str "Color"
                                    input [ _type "color"; _id "paint-color"; attr "value" "#e490bd" ]
                                ]
                            ]
                            div [ _class "button-row" ] [
                                button [ _id "paint-undo"; attr "disabled" "" ] [
                                    str "Undo edit"
                                ]
                                label [ _class "paint-check" ] [
                                    input [ _type "checkbox"; _id "paint-guides"; attr "checked" "" ]
                                    str "UV guides"
                                ]
                            ]
                            label [ _class "paint-check" ] [
                                input [ _type "checkbox"; _id "paint-preserve" ]
                                str "Allow Jev to keep existing pixels"
                            ]
                            div [ _class "two-cols" ] [
                                label [] [
                                    str "Surface"
                                    select [ _id "paint-surface" ] [
                                        option [ attr "value" "splatter" ] [
                                            str "Pigment"
                                        ]
                                        option [ attr "value" "pixels" ] [
                                            str "Crisp pixels"
                                        ]
                                        option [ attr "value" "blend" ] [
                                            str "Probability blend"
                                        ]
                                    ]
                                ]
                                label [] [
                                    str "Export long edge"
                                    select [ _id "paint-size" ] [
                                        option [] [
                                            str "512"
                                        ]
                                        option [ attr "selected" "" ] [
                                            str "1024"
                                        ]
                                        option [] [
                                            str "2048"
                                        ]
                                        option [] [
                                            str "4096"
                                        ]
                                    ]
                                ]
                            ]
                            label [] [
                                str "Representation"
                                select [ _id "paint-method" ] [
                                    option [ attr "value" "palette" ] [
                                        str "16-color palette"
                                    ]
                                    option [ attr "value" "hsl" ] [
                                        str "HSL distributions"
                                    ]
                                    option [ attr "value" "rgb" ] [
                                        str "Binary RGB"
                                    ]
                                    option [ attr "value" "silhouette" ] [
                                        str "Silhouette"
                                    ]
                                ]
                            ]
                            label [] [
                                str "Edit palette"
                                select [ _id "paint-palette" ] [
                                    option [ attr "value" "reference" ] [
                                        str "Reference · 16 colors"
                                    ]
                                    option [ attr "value" "candy" ] [
                                        str "Pastels"
                                    ]
                                    option [ attr "value" "earth" ] [
                                        str "Earth & sky"
                                    ]
                                    option [ attr "value" "mono" ] [
                                        str "Ink on paper"
                                    ]
                                    option [ attr "value" "skin" ] [
                                        str "Skin & clothing"
                                    ]
                                ]
                            ]
                            p [ _id "paint-estimate"; _class "micro" ] []
                            button [ _id "paint-start"; _class "primary" ] [
                                str "Paint with Jev ↗"
                            ]
                            div [ _class "button-row" ] [
                                button [ _id "paint-stop"; attr "disabled" "" ] [
                                    str "Stop"
                                ]
                                button [ _id "paint-export" ] [
                                    str "Save PNG"
                                ]
                                button [ _id "paint-data"; attr "disabled" "" ] [
                                    str "Save scores"
                                ]
                            ]
                            p [ _class "micro" ] [
                                str "Pigment: /v1/systemone · full distributions"
                            ]
                        ]
                    ]
                ]
                section [ _id "tornado"; _class "pane" ] [
                    div [ _class "compact-title" ] [
                        h1 [] [
                            str "Tornado"
                        ]
                        div [ _class "button-row" ] [
                            button [ _id "vortex-motion"; _class "quiet"; attr "aria-pressed" "false" ] [
                                str "Pause motion"
                            ]
                            button [ _id "vortex-portrait"; _class "quiet"; attr "aria-pressed" "false" ] [
                                str "Portrait"
                            ]
                            button [ _id "tornado-fullscreen"; _class "quiet" ] [
                                str "Immersive ↗"
                            ]
                        ]
                    ]
                    div [ _class "tornado-stage"; _id "vortex-stage" ] [
                        canvas [ _id "tornado-canvas"; attr "aria-label" "Animated pink inference tornado" ] []
                        div [ _class "vortex-heading" ] [
                            span [ _class "pink-logo" ] [
                                str "J"
                            ]
                            div [] [
                                str "JEV"
                                br []
                                str "INFERENCE DESK"
                            ]
                            span [ _class "live-pill"; _id "vortex-mode" ] [
                                str "READY"
                            ]
                        ]
                        div [ _class "glass operators" ] [
                            p [] [
                                str "OPERATORS"
                                span [] [
                                    str "LOCAL"
                                ]
                            ]
                            div [ _class "operator" ] [
                                str "READER"
                                b [ _id "op-reader" ] [
                                    str "IDLE"
                                ]
                                i [] []
                            ]
                            div [ _class "operator" ] [
                                str "CLASSIFIER"
                                b [ _id "op-classifier" ] [
                                    str "IDLE"
                                ]
                                i [] []
                            ]
                            div [ _class "operator" ] [
                                str "JOURNAL"
                                b [ _id "op-journal" ] [
                                    str "IDLE"
                                ]
                                i [] []
                            ]
                            div [ _class "operator" ] [
                                str "RENDER"
                                b [] [
                                    str "ACTIVE"
                                ]
                                i [] []
                            ]
                            p [] [
                                str "EVIDENCE MATRIX"
                            ]
                            div [ _id "evidence-matrix"; _class "evidence-matrix" ] []
                            span [ _class "micro" ] []
                        ]
                        div [ _class "glass vortex-metrics" ] [
                            p [] [
                                str "REQUESTS / SESSION"
                            ]
                            strong [ _id "vortex-completed" ] [
                                str "0"
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Measured rate"
                                ]
                                b [ _id "vortex-rate" ] [
                                    str "0.0 /s"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Last round trip"
                                ]
                                b [ _id "vortex-latency" ] [
                                    str "—"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "In flight"
                                ]
                                b [ _id "vortex-pending" ] [
                                    str "0"
                                ]
                            ]
                            div [ _class "stat-line" ] [
                                span [] [
                                    str "Errors"
                                ]
                                b [ _id "vortex-errors" ] [
                                    str "0"
                                ]
                            ]
                            canvas [ _id "vortex-spark"; attr "width" "240"; attr "height" "60"; attr "aria-label" "Recent latency trend" ] []
                        ]
                        div [ _class "glass vortex-result" ] [
                            p [] [
                                str "LATEST DECISION"
                            ]
                            strong [ _id "vortex-choice" ] [
                                str "Waiting for data"
                            ]
                            span [ _id "vortex-confidence" ] [
                                str "—"
                            ]
                            pre [ _id "vortex-latest" ] []
                        ]
                        div [ _class "glass vortex-feed" ] [
                            p [] [
                                str "LIVE JOURNAL"
                                span [] [
                                    str "●"
                                ]
                            ]
                            div [ _id "vortex-feed" ] []
                        ]
                        div [ _class "vortex-runtime" ] [
                            span [ _id "vortex-flow" ] [
                                str "READ → INFER → SAVE / IDLE"
                            ]
                            span [ _id "vortex-fps" ] [
                                str "— FPS"
                            ]
                        ]
                        div [ _id "vortex-ticker"; _class "vortex-ticker" ] [
                            span [] []
                        ]
                        div [ _class "vortex-foot" ] [
                            span [] []
                            span [ _id "vortex-row" ] [
                                str "0 rows read"
                            ]
                            span [ _id "vortex-render" ] [
                                str "READY"
                            ]
                        ]
                    ]
                    div [ _class "tornado-bottom" ] [
                        div [ _class "card data-card" ] [
                            div [ _class "card-top" ] [
                                h2 [] [
                                    str "Data"
                                ]
                                button [ _id "sample-data" ] [
                                    str "Try sample CSV"
                                ]
                            ]
                            label [ _class "drop-zone"; _id "drop-zone" ] [
                                span [] [
                                    str "↥"
                                ]
                                strong [ _id "file-label" ] [
                                    str "Drop CSV, TSV, JSONL or JSON here"
                                ]
                                small [] [
                                    str "Streamed locally. Only selected columns go to your endpoint."
                                ]
                                input [ _type "file"; _id "data-file"; attr "accept" ".csv,.tsv,.jsonl,.ndjson,.json,.txt"; attr "hidden" "" ]
                            ]
                            div [ _id "column-picker"; _class "column-picker" ] []
                            p [ _id "file-preview"; _class "micro" ] []
                        ]
                        div [ _class "card data-card" ] [
                            div [ _class "card-top" ] [
                                h2 [] [
                                    str "Judgment"
                                ]
                                span [ _class "badge" ] [
                                    str "One row / one request"
                                ]
                            ]
                            label [] [
                                str "Instructions"
                                tag "textarea" [ _id "vortex-instructions"; attr "rows" "2" ] [
                                    str "Classify this market snapshot as RISING, FALLING, or UNCLEAR using only the supplied evidence. Choose UNCLEAR if evidence is insufficient. Do not invent future prices."
                                ]
                            ]
                            div [ _class "two-cols" ] [
                                label [] [
                                    str "Choices, comma separated"
                                    input [ _id "vortex-labels"; attr "value" "RISING, FALLING, UNCLEAR" ]
                                ]
                                label [] [
                                    str "Arrival pacing"
                                    select [ _id "vortex-pacing" ] [
                                        option [ attr "value" "0" ] [
                                            str "As fast as responses allow"
                                        ]
                                        option [ attr "value" "8" ] [
                                            str "8 rows / second"
                                        ]
                                        option [ attr "value" "24" ] [
                                            str "24 rows / second"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "form-actions" ] [
                                button [ _id "vortex-start"; _class "primary" ] [
                                    str "Start inference ↗"
                                ]
                                button [ _id "vortex-pause"; attr "disabled" "" ] [
                                    str "Pause"
                                ]
                                button [ _id "vortex-stop"; attr "disabled" "" ] [
                                    str "Stop"
                                ]
                                button [ _id "vortex-export"; attr "disabled" "" ] [
                                    str "Export JSONL"
                                ]
                            ]
                            p [ _class "micro" ] []
                        ]
                    ]
                ]
                section [ _id "chat"; _class "pane" ] [
                    div [ _class "compact-title" ] [
                        h1 [] [
                            str "Chat goes brrr."
                        ]
                    ]
                    div [ _id "chat-stage"; _class "chat-stage" ] [
                        div [ _class "chat-stage-top" ] [
                            div [] [
                                span [ _class "chat-live-dot" ] []
                                strong [] [
                                    str "JEV / CHAT DESK"
                                ]
                                span [ _id "chat-state"; attr "role" "status" ] [
                                    str "READY"
                                ]
                            ]
                            span [ _id "chat-protocol" ] []
                        ]
                        div [ _class "chat-meters" ] [
                            div [] [
                                span [] [
                                    str "ARRIVED"
                                ]
                                strong [ _id "chat-arrived" ] [
                                    str "0"
                                ]
                            ]
                            div [] [
                                span [] [
                                    str "JUDGED"
                                ]
                                strong [ _id "chat-completed" ] [
                                    str "0"
                                ]
                            ]
                            div [] [
                                span [] [
                                    str "KEPT"
                                ]
                                strong [ _id "chat-kept" ] [
                                    str "0"
                                ]
                            ]
                            div [] [
                                span [] [
                                    str "HELD"
                                ]
                                strong [ _id "chat-held" ] [
                                    str "0"
                                ]
                            ]
                            div [] [
                                span [] [
                                    str "MEAN HTTP"
                                ]
                                strong [ _id "chat-rtt" ] [
                                    str "—"
                                ]
                            ]
                            div [] [
                                span [] [
                                    str "MEAN OUTPUT DELAY"
                                ]
                                strong [ _id "chat-lag" ] [
                                    str "—"
                                ]
                            ]
                        ]
                        div [ _class "chat-filter-bar" ] [
                            span [] [
                                str "Keep"
                            ]
                            div [ _id "chat-filter-chips"; _class "filter-chips" ] []
                            label [ _class "chat-check" ] [
                                input [ _id "chat-follow"; _type "checkbox"; attr "checked" "" ]
                                str "Follow"
                            ]
                            select [ _id "chat-order"; attr "aria-label" "Result delivery" ] [
                                option [ attr "value" "immediate" ] [
                                    str "As ready"
                                ]
                                option [ attr "value" "ordered" ] [
                                    str "Arrival order"
                                ]
                            ]
                        ]
                        div [ _class "chat-streams" ] [
                            div [ _class "chat-column" ] [
                                div [ _class "chat-column-title" ] [
                                    div [] [
                                        span [ _class "chat-icon" ] [
                                            str "≋"
                                        ]
                                        h2 [] [
                                            str "Raw chat"
                                        ]
                                    ]
                                    span [ _id "chat-burst-live" ] [
                                        str "SOURCE PACE"
                                    ]
                                ]
                                div [ _id "chat-raw"; _class "chat-feed"; attr "aria-label" "Raw incoming chat"; attr "tabindex" "0" ] [
                                    div [ _class "chat-empty" ] [
                                        span [] [
                                            str "↘"
                                        ]
                                        strong [] [
                                            str "Raw chat"
                                        ]
                                    ]
                                ]
                            ]
                            div [ _class "chat-buffer" ] [
                                span [] [
                                    str "BUFFER"
                                ]
                                div [ _class "chat-wire" ] []
                                div [ _id "chat-buffer-dots"; attr "aria-hidden" "true" ] []
                                strong [ _id "chat-queued" ] [
                                    str "0"
                                ]
                                span [ _id "chat-buffer-label" ] [
                                    str "Buffer clear"
                                ]
                                div [ _class "chat-wire outgoing" ] []
                                small [] [
                                    str "IN FLIGHT"
                                    b [ _id "chat-inflight" ] [
                                        str "0"
                                    ]
                                ]
                            ]
                            div [ _class "chat-column" ] [
                                div [ _class "chat-column-title" ] [
                                    div [] [
                                        span [ _class "chat-icon signal" ] [
                                            str "✳"
                                        ]
                                        h2 [] [
                                            str "Jev chat"
                                        ]
                                    ]
                                    label [ _class "chat-check" ] [
                                        input [ _type "checkbox"; _id "chat-show-held" ]
                                        str "Show held"
                                    ]
                                ]
                                div [ _id "chat-filtered"; _class "chat-feed"; attr "aria-label" "Ordered, filtered chat"; attr "tabindex" "0" ] [
                                    div [ _class "chat-empty" ] [
                                        span [] [
                                            str "✳"
                                        ]
                                        strong [] [
                                            str "Filtered chat"
                                        ]
                                    ]
                                ]
                            ]
                        ]
                        div [ _class "chat-stage-foot" ] [
                            span [] [
                                str "ELAPSED"
                                b [ _id "chat-elapsed" ] [
                                    str "0.0s"
                                ]
                            ]
                            span [] [
                                str "COMPLETED"
                                b [ _id "chat-rate" ] [
                                    str "0 /s"
                                ]
                            ]
                            span [] [
                                str "PEAK QUEUE"
                                b [ _id "chat-peak" ] [
                                    str "0"
                                ]
                            ]
                            span [] [
                                str "ERRORS"
                                b [ _id "chat-errors" ] [
                                    str "0"
                                ]
                            ]
                            span [] [
                                str "LAST 120 VISIBLE / FULL RUN EXPORTABLE"
                            ]
                        ]
                    ]
                    div [ _class "chat-transport" ] [
                        div [] [
                            progress [ _id "chat-progress"; attr "max" "1"; attr "value" "0"; attr "aria-label" "Messages judged" ] []
                            p [ _id "chat-caption" ] [
                                str "Ready"
                            ]
                        ]
                        div [ _class "button-row" ] [
                            button [ _id "chat-start"; _class "primary" ] [
                                str "Start replay ↗"
                            ]
                            button [ _id "chat-pause"; attr "disabled" "" ] [
                                str "Pause"
                            ]
                            button [ _id "chat-stop"; attr "disabled" "" ] [
                                str "Stop"
                            ]
                            button [ _id "chat-export"; attr "disabled" "" ] [
                                str "Export JSONL"
                            ]
                        ]
                    ]
                    p [ _id "chat-last-error"; _class "error micro"; attr "role" "status"; attr "hidden" "" ] []
                    div [ _class "chat-config" ] [
                        div [ _class "card"; _id "chat-source-config" ] [
                            div [ _class "card-top" ] [
                                h2 [] [
                                    span [ _class "step" ] [
                                        str "01"
                                    ]
                                    str "Transcript"
                                ]
                                div [ _class "button-row" ] [
                                    button [ _id "chat-barrage"; _class "quiet" ] [
                                        str "Barrage"
                                    ]
                                    button [ _id "chat-sample"; _class "quiet" ] [
                                        str "Short sample"
                                    ]
                                    button [ _id "chat-long-test"; _class "quiet" ] [
                                        str "Long test · 1,344"
                                    ]
                                ]
                            ]
                            label [] [
                                str "Chat transcript"
                                tag "textarea" [ _id "chat-source"; attr "rows" "8"; attr "spellcheck" "false"; attr "placeholder" "viewer_one: How did you build this?\nviewer_two: chat is flying\nviewer_three: Try reducing the sensitivity." ] []
                            ]
                            p [ _id "chat-source-note"; _class "micro" ] [
                                str "Text / JSONL · up to 16 MiB"
                            ]
                            div [ _class "two-cols" ] [
                                label [] [
                                    str "Format"
                                    select [ _id "chat-format" ] [
                                        option [ attr "value" "auto" ] [
                                            str "Auto-detect"
                                        ]
                                        option [ attr "value" "plain" ] [
                                            str "Plain text"
                                        ]
                                        option [ attr "value" "jsonl" ] [
                                            str "JSONL"
                                        ]
                                    ]
                                ]
                                label [ _class "button quiet chat-upload" ] [
                                    str "Upload transcript"
                                    input [ _type "file"; _id "chat-file"; attr "accept" ".txt,.jsonl,.ndjson,.log"; attr "hidden" "" ]
                                ]
                            ]
                            div [ _class "chat-fields" ] [
                                label [] [
                                    str "Arrival mode"
                                    select [ _id "chat-timing" ] [
                                        option [ attr "value" "bursts" ] [
                                            str "Steady + bursts"
                                        ]
                                        option [ attr "value" "steady" ] [
                                            str "Steady stream"
                                        ]
                                        option [ attr "value" "timestamps" ] [
                                            str "Original timestamps"
                                        ]
                                    ]
                                ]
                                label [] [
                                    str "Base messages / second"
                                    input [ _id "chat-arrival-rate"; _type "number"; attr "min" "0.1"; attr "max" "500"; attr "step" "0.1"; attr "value" "24" ]
                                ]
                                label [] [
                                    str "Playback speed"
                                    select [ _id "chat-speed" ] [
                                        option [ attr "value" "0.5" ] [
                                            str "0.5×"
                                        ]
                                        option [ attr "value" "1"; attr "selected" "" ] [
                                            str "1×"
                                        ]
                                        option [ attr "value" "2" ] [
                                            str "2×"
                                        ]
                                        option [ attr "value" "4" ] [
                                            str "4×"
                                        ]
                                    ]
                                ]
                                label [] [
                                    str "Burst every (seconds)"
                                    input [ _id "chat-period"; _type "number"; attr "min" "1"; attr "value" "8" ]
                                ]
                                label [] [
                                    str "Burst duration (seconds)"
                                    input [ _id "chat-duration"; _type "number"; attr "min" "0.1"; attr "step" "0.1"; attr "value" "2" ]
                                ]
                                label [] [
                                    str "Burst multiplier"
                                    input [ _id "chat-multiplier"; _type "number"; attr "min" "1"; attr "max" "20"; attr "value" "3" ]
                                ]
                            ]
                            p [ _class "micro" ] [
                                str "A burst occupies the end of each period. Original timestamps ignore rate and burst settings. Replay pauses when this page is hidden to avoid browser timer throttling; in-flight requests may finish."
                            ]
                        ]
                        div [ _class "card"; _id "chat-policy-config" ] [
                            div [ _class "card-top" ] [
                                h2 [] [
                                    span [ _class "step" ] [
                                        str "02"
                                    ]
                                    str "Policy"
                                ]
                                select [ _id "chat-preset"; attr "aria-label" "Chat inference preset" ] [
                                    option [ attr "value" "signal" ] [
                                        str "Six-category signal"
                                    ]
                                    option [ attr "value" "safety" ] [
                                        str "Safety triage"
                                    ]
                                ]
                            ]
                            label [] [
                                str "Stream context"
                                tag "textarea" [ _id "chat-context"; attr "rows" "2" ] []
                            ]
                            label [] [
                                str "Classification instructions"
                                tag "textarea" [ _id "chat-instructions"; attr "rows" "4" ] []
                            ]
                            details [ _class "chat-policy-details" ] [
                                summary [] [
                                    str "Category definitions & extra questions"
                                ]
                                label [] [
                                    str "Categories (JSON object)"
                                    tag "textarea" [ _id "chat-criteria"; attr "rows" "10"; attr "spellcheck" "false" ] []
                                ]
                                label [] [
                                    str "Additional Choice, Noul or Score questions (JSON object)"
                                    tag "textarea" [ _id "chat-extras"; attr "rows" "3"; attr "spellcheck" "false" ] [
                                        str "{}"
                                    ]
                                ]
                                p [ _class "micro" ] [
                                    str "The category key is reserved. Extra questions use the same message state; their results appear in Inspect judgment and exports."
                                ]
                            ]
                            div [ _class "two-cols" ] [
                                label [] [
                                    str "Keep categories (comma separated)"
                                    input [ _id "chat-keep" ]
                                ]
                                label [] [
                                    str "Minimum selected probability (%)"
                                    input [ _id "chat-threshold"; _type "number"; attr "min" "0"; attr "max" "100"; attr "step" "1"; attr "value" "0" ]
                                ]
                            ]
                            label [] [
                                str "Chat worker override (0 = global)"
                                input [ _id "chat-workers"; _type "number"; attr "min" "0"; attr "value" "0" ]
                            ]
                            p [ _class "micro" ] [
                                str "Workers = HTTP concurrency. Source timing is independent."
                            ]
                        ]
                    ]
                ]
            ]
            footer [] [
                span [] [
                    i [ _class "local-dot" ] []
                    str "Local-first"
                ]
                span [ _id "session-metrics" ] [
                    str "No inference requests yet"
                ]
                button [ _id "forget"; _class "text-button" ] [
                    str "Clear local settings"
                ]
            ]
            div [ _id "toast"; attr "role" "status"; attr "aria-live" "polite"; attr "hidden" "" ] []
            dialog [ _id "settings" ] [
                form [ attr "method" "dialog" ] [
                    div [ _class "card-top" ] [
                        h2 [] [
                            str "Endpoint"
                        ]
                        button [ attr "value" "cancel"; _class "close"; attr "aria-label" "Close settings" ] [
                            str "×"
                        ]
                    ]
                    p [] [
                        str "NInfer"
                        code [] [
                            str "--jev --cors"
                        ]
                    ]
                    label [] [
                        str "Endpoint origin"
                        input [ _id "endpoint-url"; _type "url"; attr "placeholder" "http://localhost:8000"; attr "required" "" ]
                    ]
                    div [ _class "two-cols" ] [
                        label [] [
                            str "Protocol"
                            select [ _id "endpoint-protocol" ] [
                                option [ attr "value" "systemone" ] [
                                    str "/v1/systemone · full distributions"
                                ]
                                option [ attr "value" "decision" ] [
                                    str "/v1/decision · selected scores"
                                ]
                            ]
                        ]
                        label [] [
                            str "Global request limit (0 = auto)"
                            input [ _id "endpoint-concurrency"; _type "number"; attr "min" "0"; attr "step" "1"; attr "value" "0" ]
                        ]
                    ]
                    label [] [
                        str "Model alias (optional)"
                        input [ _id "endpoint-model"; attr "list" "endpoint-models"; attr "placeholder" "Connect to discover models" ]
                        datalist [ _id "endpoint-models" ] []
                    ]
                    label [] [
                        str "API key (optional; this tab only)"
                        input [ _id "endpoint-key"; _type "password"; attr "autocomplete" "off"; attr "placeholder" "Never saved to disk" ]
                    ]
                    label [] [
                        str "Request timeout, seconds"
                        input [ _id "endpoint-timeout"; _type "number"; attr "min" "5"; attr "max" "180"; attr "value" "30" ]
                    ]
                    div [ _class "two-cols" ] [
                        label [] [
                            str "Auto probe ceiling"
                            input [ _id "endpoint-probe-ceiling"; _type "number"; attr "min" "1"; attr "value" "64" ]
                        ]
                        label [] [
                            str "Driving control expiry (ms)"
                            input [ _id "endpoint-max-age"; _type "number"; attr "min" "1"; attr "value" "4000" ]
                        ]
                    ]
                    label [] [
                        input [ _id "endpoint-parallel"; _type "checkbox"; attr "checked" "" ]
                        str "Parallel independent questions"
                    ]
                    p [ _class "micro" ] [
                        str "Auto measures a small Jev request for up to 12 seconds; it is not a GPU worker count. Every mode shares this budget. Sequential controls wait for fresh state. A manual limit skips the capacity probe."
                    ]
                    p [ _class "micro" ] [
                        str "Connection settings are saved in this browser; keys, prompts and paintings are not. CSV results stay in IndexedDB until cleared. HTTPS hosting may block HTTP LAN endpoints: use the local page or an HTTPS endpoint."
                    ]
                    div [ _class "form-actions" ] [
                        button [ _type "button"; _id "endpoint-save"; _class "primary" ] [
                            str "Save & connect ↗"
                        ]
                        button [ _type "button"; _id "endpoint-cancel"; attr "disabled" "" ] [
                            str "Cancel"
                        ]
                        button [ _type "button"; _id "clear-journal" ] [
                            str "Clear CSV results"
                        ]
                    ]
                    p [ _id "settings-status"; attr "role" "status" ] []
                    details [] [
                        summary [] [
                            str "Connection details"
                        ]
                        p [ _class "micro" ] [
                            str "Connect discovers /v1/models and verifies the selected Jev route. Approve browser local-network access if prompted. Keys stay in this tab. No proxy or telemetry."
                        ]
                        pre [ _id "endpoint-report" ] []
                    ]
                ]
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
