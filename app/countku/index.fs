module ConvertedFiles.Countku.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0, viewport-fit=cover" ]
            meta [ attr "name" "theme-color"; attr "content" "#12132c" ]
            meta [ attr "name" "apple-mobile-web-app-capable"; attr "content" "yes" ]
            meta [ attr "name" "apple-mobile-web-app-status-bar-style"; attr "content" "black-translucent" ]
            title [] [
                str "桜 COUNT 忍者 - Sakura Count Ninja"
            ]
            link [ _href "manifest.webmanifest"; attr "rel" "manifest" ]
            link [ _href "game/assets/countku-mark.svg"; attr "rel" "icon"; _type "image/svg+xml" ]
            link [ _href "https://fonts.googleapis.com/css2?family=Press+Start+2P&family=VT323&display=swap"; attr "rel" "stylesheet" ]
            style [] [
                    rawText ("""* { margin: 0; padding: 0; box-sizing: border-box; }
        body { font-family: 'VT323', monospace; overflow: hidden; background: linear-gradient(180deg, #1a0a1a 0%, #2d1b2d 30%, #3d243d 60%, #4a2c4a 100%); min-height: 100vh; color: #fff; }
        .pixel-font { font-family: 'Press Start 2P', cursive; }
        .retro-text { text-shadow: 2px 2px 0px rgba(0, 0, 0, 0.5), 0 0 10px rgba(255, 183, 213, 0.5); }
        .bg-tree { position: fixed; bottom: -100px; right: -200px; width: 700px; height: auto; opacity: 0.2; pointer-events: none; z-index: 0; }
        @keyframes fallDiagonal { 0% { transform: translate(0, -10vh) rotate(0deg); opacity: 0; } 10% { opacity: 0.6; } 100% { transform: translate(-70vw, 110vh) rotate(720deg); opacity: 0; } }
        .petal { position: fixed; width: 20px; height: 20px; background-size: contain; background-repeat: no-repeat; pointer-events: none; z-index: 1; animation: fallDiagonal linear infinite; }
        @keyframes swirl { 0% { transform: scale(0) rotate(0deg); opacity: 0; } 20% { opacity: 0.3; } 80% { opacity: 0.3; } 100% { transform: scale(1.5) rotate(360deg); opacity: 0; } }
        .wind-swirl { position: fixed; width: 80px; height: 80px; background-size: contain; background-repeat: no-repeat; pointer-events: none; z-index: 1; animation: swirl 3s ease-out forwards; }
        @keyframes ninjaRun { 0% { transform: translateX(-100px); } 100% { transform: translateX(calc(50vw - 50px)); } }
        @keyframes ninjaJump { 0% { transform: translateX(calc(50vw - 50px)) translateY(0) scaleY(1); } 30% { transform: translateX(calc(50vw - 30px)) translateY(-100px) scaleY(1.1); } 60% { transform: translateX(calc(50vw - 10px)) translateY(-70px) scaleY(0.9); } 100% { transform: translateX(calc(50vw + 20px)) translateY(0) scaleY(1); } }
        @keyframes ninjaIdle { 0%, 100% { transform: translateX(-50%) translateY(0); } 50% { transform: translateX(-50%) translateY(-5px); } }
        .ninja-run { animation: ninjaRun 0.8s ease-in-out forwards; }
        .ninja-jump { animation: ninjaJump 0.6s ease-in-out forwards; }
        .ninja-idle { animation: ninjaIdle 2s ease-in-out infinite; }
        @keyframes bubblePop { 0% { transform: scale(0.5); opacity: 0; } 70% { transform: scale(1.1); } 100% { transform: scale(1); opacity: 1; } }
        @keyframes bubbleFade { 0% { opacity: 1; transform: scale(1); } 100% { opacity: 0; transform: scale(0.9); } }
        .chat-bubble { background: linear-gradient(135deg, #ffb7d5 0%, #ff9ec8 100%); border-radius: 20px; padding: 12px 20px; position: relative; box-shadow: 0 4px 15px rgba(255, 183, 213, 0.4), inset 0 1px 0 rgba(255, 255, 255, 0.3); animation: bubblePop 0.3s ease-out; }
        .chat-bubble::after { content: ''; position: absolute; bottom: -10px; left: 30px; width: 0; height: 0; border-left: 10px solid transparent; border-right: 10px solid transparent; border-top: 15px solid #ff9ec8; }
        .chat-bubble.fade-out { animation: bubbleFade 1s ease-out forwards; }
        @keyframes checkmark { 0% { transform: scale(0); opacity: 0; } 50% { transform: scale(1.2); } 100% { transform: scale(1); opacity: 1; } }
        .checkmark { animation: checkmark 0.4s ease-out forwards; }
        @keyframes dashboardSwoop { 0% { transform: translateY(100%) scale(0.9); opacity: 0; } 60% { transform: translateY(-5%) scale(1.02); } 100% { transform: translateY(0) scale(1); opacity: 1; } }
        .dashboard-swoop { animation: dashboardSwoop 0.8s cubic-bezier(0.34, 1.56, 0.64, 1) forwards; }
        @keyframes numberGlow { 0%, 100% { text-shadow: 0 0 10px rgba(255, 183, 213, 0.5), 0 0 20px rgba(255, 183, 213, 0.3), 0 0 30px rgba(255, 183, 213, 0.2); } 50% { text-shadow: 0 0 20px rgba(255, 183, 213, 0.8), 0 0 40px rgba(255, 183, 213, 0.5), 0 0 60px rgba(255, 183, 213, 0.3); } }
        .number-glow { animation: numberGlow 2s ease-in-out infinite; }
        @keyframes shake { 0%, 100% { transform: translateX(0); } 10%, 30%, 50%, 70%, 90% { transform: translateX(-5px); } 20%, 40%, 60%, 80% { transform: translateX(5px); } }
        .shake { animation: shake 0.5s ease-in-out; }
        @keyframes pulse { 0%, 100% { transform: scale(1); } 50% { transform: scale(1.05); } }
        .pulse { animation: pulse 1.5s ease-in-out infinite; }
        @keyframes barGrow { 0% { height: 0; } 100% { height: var(--bar-height); } }
        .bar-grow { animation: barGrow 0.8s ease-out forwards; }
        .game-container { position: relative; z-index: 10; display: flex; flex-direction: column; align-items: center; justify-content: center; min-height: 100vh; padding: 20px; }
        .game-input { width: 100%; max-width: 450px; padding: 16px 70px 16px 24px; background: rgba(20, 20, 30, 0.9); border: 2px solid rgba(255, 100, 150, 0.5); border-radius: 16px; color: #ffb7d5; font-size: 1.3rem; font-family: 'VT323', monospace; outline: none; transition: all 0.3s; box-shadow: 4px 4px 0 rgba(0, 0, 0, 0.3), inset 0 0 0 2px rgba(255, 255, 255, 0.05); }
        .game-input::placeholder { color: rgba(255, 183, 213, 0.4); }
        .game-input:focus { border-color: rgba(255, 100, 150, 0.8); box-shadow: 0 0 0 3px rgba(255, 100, 150, 0.3), 0 0 20px rgba(255, 100, 150, 0.2), 4px 4px 0 rgba(0, 0, 0, 0.3); }
        .input-wrapper { position: relative; width: 100%; max-width: 450px; }
        .go-btn { position: absolute; right: 8px; top: 50%; transform: translateY(-50%); padding: 10px 20px; background: linear-gradient(135deg, #ff6496 0%, #ff8ab3 100%); border: none; border-radius: 10px; color: white; font-family: 'Press Start 2P', cursive; font-size: 0.7rem; cursor: pointer; transition: all 0.2s; box-shadow: 0 4px 10px rgba(255, 100, 150, 0.4); }
        .go-btn:hover { transform: translateY(-50%) scale(1.05); box-shadow: 0 6px 15px rgba(255, 100, 150, 0.5); }
        .help-btn { position: fixed; top: 20px; left: 20px; width: 40px; height: 40px; background: rgba(255, 100, 150, 0.2); border: 2px solid rgba(255, 100, 150, 0.4); border-radius: 50%; color: #ffb7d5; font-size: 1.2rem; cursor: pointer; transition: all 0.3s; z-index: 100; display: flex; align-items: center; justify-content: center; }
        .help-btn:hover { background: rgba(255, 100, 150, 0.4); transform: scale(1.1); }
        .help-modal { position: fixed; inset: 0; background: rgba(0, 0, 0, 0.7); backdrop-filter: blur(5px); z-index: 200; display: none; align-items: center; justify-content: center; padding: 20px; }
        .help-modal.active { display: flex; }
        .help-content { background: linear-gradient(135deg, #2d1b2d 0%, #3d243d 100%); border: 2px solid rgba(255, 100, 150, 0.5); border-radius: 20px; padding: 30px; max-width: 500px; max-height: 80vh; overflow-y: auto; box-shadow: 0 20px 60px rgba(0, 0, 0, 0.5); }
        .help-content h2 { color: #ffb7d5; margin-bottom: 20px; text-align: center; }
        .help-section { margin-bottom: 20px; }
        .help-section h3 { color: #ff8ab3; margin-bottom: 10px; font-size: 1.1rem; }
        .help-section code { background: rgba(0, 0, 0, 0.3); padding: 2px 8px; border-radius: 4px; color: #ffb7d5; font-family: 'VT323', monospace; font-size: 1.1rem; }
        .help-section ul { list-style: none; padding-left: 0; }
        .help-section li { padding: 5px 0; color: rgba(255, 255, 255, 0.8); }
        .close-help { width: 100%; padding: 12px; background: linear-gradient(135deg, #ff6496 0%, #ff8ab3 100%); border: none; border-radius: 10px; color: white; font-family: 'Press Start 2P', cursive; font-size: 0.7rem; cursor: pointer; margin-top: 20px; }
        .dashboard-overlay { position: fixed; inset: 0; background: rgba(0, 0, 0, 0.6); backdrop-filter: blur(5px); z-index: 50; display: none; align-items: center; justify-content: center; padding: 20px; }
        .dashboard-overlay.active { display: flex; }
        .dashboard { background: linear-gradient(135deg, rgba(45, 27, 45, 0.95) 0%, rgba(61, 36, 61, 0.95) 100%); border: 2px solid rgba(255, 100, 150, 0.5); border-radius: 20px; padding: 25px; width: 100%; max-width: 450px; box-shadow: 0 20px 60px rgba(0, 0, 0, 0.5), 4px 4px 0 rgba(0, 0, 0, 0.3); }
        .dashboard-header { text-align: center; margin-bottom: 20px; }
        .dashboard-header .x-icon { width: 50px; height: 50px; background: rgba(255, 80, 80, 0.2); border-radius: 50%; display: flex; align-items: center; justify-content: center; margin: 0 auto 15px; font-size: 1.5rem; color: #ff5050; }
        .stats-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 12px; margin-bottom: 20px; }
        .stat-card { background: rgba(255, 100, 150, 0.1); border-radius: 12px; padding: 15px; text-align: center; }
        .stat-card .stat-icon { font-size: 1.3rem; margin-bottom: 8px; }
        .stat-card .stat-label { color: rgba(255, 183, 213, 0.6); font-size: 0.75rem; margin-bottom: 5px; }
        .stat-card .stat-value { color: #ffb7d5; font-size: 1.5rem; font-weight: bold; }
        .graph-container { background: rgba(255, 100, 150, 0.05); border-radius: 12px; padding: 15px; margin-bottom: 15px; }
        .graph-container p { color: rgba(255, 183, 213, 0.6); font-size: 0.75rem; text-align: center; margin-bottom: 10px; }
        .graph-bars { display: flex; align-items: flex-end; justify-content: center; gap: 4px; height: 100px; }
        .graph-bar { width: 12px; background: linear-gradient(to top, #ff6496, #ffb7d5); border-radius: 3px 3px 0 0; min-height: 5px; }
        .extra-stats { display: flex; justify-content: space-between; color: rgba(255, 183, 213, 0.5); font-size: 0.85rem; margin-bottom: 20px; padding: 0 10px; }
        .play-again-btn { width: 100%; padding: 16px; background: linear-gradient(135deg, #ff6496 0%, #ff8ab3 100%); border: none; border-radius: 12px; color: white; font-family: 'Press Start 2P', cursive; font-size: 0.8rem; cursor: pointer; display: flex; align-items: center; justify-content: center; gap: 10px; box-shadow: 0 8px 25px rgba(255, 100, 150, 0.4); transition: all 0.3s; }
        .play-again-btn:hover { transform: scale(1.02); box-shadow: 0 10px 30px rgba(255, 100, 150, 0.5); }
        .streak-indicator { position: fixed; top: 20px; right: 20px; background: rgba(255, 100, 150, 0.2); backdrop-filter: blur(5px); border: 1px solid rgba(255, 100, 150, 0.3); border-radius: 20px; padding: 8px 16px; color: #ffb7d5; font-size: 1rem; z-index: 20; }
        .game-title { font-size: 2rem; color: #ffb7d5; text-align: center; margin-bottom: 20px; }
        .number-display { text-align: center; margin-bottom: 30px; }
        .number-display .label { color: rgba(255, 183, 213, 0.6); font-size: 1.1rem; margin-bottom: 10px; }
        .number-display .current-number { font-size: 5rem; color: #ffb7d5; font-weight: bold; line-height: 1; }
        .number-display .next-number { color: rgba(255, 183, 213, 0.4); font-size: 0.9rem; margin-top: 10px; }
        .ninja-area { position: relative; width: 100%; max-width: 400px; height: 150px; margin-bottom: 20px; }
        .ninja { position: absolute; bottom: 0; width: 80px; height: 80px; transition: all 0.3s; }
        .ninja img { width: 100%; height: 100%; object-fit: contain; }
        .target-platform { position: absolute; bottom: 0; right: 40px; width: 60px; height: 12px; background: linear-gradient(90deg, rgba(255, 100, 150, 0.5), rgba(255, 150, 180, 0.5)); border-radius: 6px; }
        .target-number { position: absolute; bottom: 20px; right: 55px; color: #ffb7d5; font-size: 1.3rem; font-weight: bold; }
        .checkmark-icon { position: absolute; bottom: 70px; left: 50%; transform: translateX(-50%); width: 45px; height: 45px; background: #4ade80; border-radius: 50%; display: flex; align-items: center; justify-content: center; font-size: 1.5rem; box-shadow: 0 4px 15px rgba(74, 222, 128, 0.5); }
        .input-hint { color: rgba(255, 183, 213, 0.4); font-size: 0.85rem; text-align: center; margin-top: 10px; }
        ::-webkit-scrollbar { width: 8px; }
        ::-webkit-scrollbar-track { background: rgba(0, 0, 0, 0.2); }
        ::-webkit-scrollbar-thumb { background: rgba(255, 100, 150, 0.5); border-radius: 4px; }

        /* Mobile responsiveness */
        @media (max-width: 600px) {
            .game-container { padding: 10px; }
            .game-title { font-size: 1.4rem; }
            .number-display .current-number { font-size: 3.5rem; }
            .game-input { font-size: 1rem; padding: 12px 60px 12px 16px; }
            .go-btn { padding: 8px 14px; font-size: 0.6rem; }
            .mode-btn { padding: 8px 14px; font-size: 0.85rem; }
            .help-content { padding: 20px; max-width: 90vw; }
            .ninja-area { height: 120px; }
            .chat-bubble { padding: 10px 14px; }
            .input-hint { font-size: 0.75rem; }
        }

        /* Mode selector buttons */
        .mode-selector { display: flex; gap: 10px; margin-bottom: 20px; justify-content: center; flex-wrap: wrap; }
        .mode-btn { padding: 10px 20px; background: rgba(255, 100, 150, 0.15); border: 2px solid rgba(255, 100, 150, 0.3); border-radius: 12px; color: rgba(255, 183, 213, 0.7); font-family: 'VT323', monospace; font-size: 1rem; cursor: pointer; transition: all 0.3s; }
        .mode-btn:hover { background: rgba(255, 100, 150, 0.25); border-color: rgba(255, 100, 150, 0.5); color: #ffb7d5; }
        .mode-btn.active { background: linear-gradient(135deg, #ff6496 0%, #ff8ab3 100%); border-color: #ff6496; color: white; box-shadow: 0 4px 15px rgba(255, 100, 150, 0.4); }
        .mode-label { font-size: 0.7rem; opacity: 0.7; display: block; margin-top: 2px; }""")
            ]
            link [ _href "game/countku-app.css?v=0.6.1"; attr "rel" "stylesheet" ]
        ]
        body [] [
            img [ _src ("data:image/png;base64," + Image.SakuraTreeBackground); _alt "Sakura Tree"; _class "bg-tree" ]
            div [ _id "petals-container" ] []
            div [ _id "wind-container" ] []
            button [ _class "help-btn"; attr "onclick" "showHelp()" ] [
                str "?"
            ]
            div [ _class "help-modal"; _id "helpModal" ] [
                div [ _class "help-content"; _id "helpContent" ] [
                    rawText ("""<!--  Help content will be dynamically updated based on mode  -->""")
                ]
            ]
            div [ _class "streak-indicator"; _id "streakIndicator"; attr "style" "display: none;" ] [
                str "🔥 Streak:"
                span [ _id "streakValue" ] [
                    str "0"
                ]
            ]
            div [ _class "game-container" ] [
                rawText ("""<!--  Mode Selector  -->""")
                div [ _class "mode-selector" ] [
                    button [ _class "mode-btn active"; _id "mode-normal"; attr "onclick" "setMode('normal')" ] [
                        str "Normal"
                        span [ _class "mode-label" ] [
                            str "Base 10"
                        ]
                    ]
                    button [ _class "mode-btn"; _id "mode-hard"; attr "onclick" "setMode('hard')" ] [
                        str "Hard"
                        span [ _class "mode-label" ] [
                            str "Base 2"
                        ]
                    ]
                    button [ _class "mode-btn"; _id "mode-wtf"; attr "onclick" "setMode('wtf')" ] [
                        str "wtf"
                        span [ _class "mode-label" ] [
                            str "Base 16"
                        ]
                    ]
                    button [ _class "mode-btn"; _id "mode-countku"; attr "onclick" "setMode('countku')" ] [
                        str "countku"
                        span [ _class "mode-label" ] [
                            str "Word Haiku"
                        ]
                    ]
                ]
                h1 [ _class "game-title pixel-font retro-text" ] [
                    str "桜 COUNT 忍者"
                ]
                div [ _class "number-display" ] [
                    div [ _class "label" ] [
                        str "The last correct number was:"
                    ]
                    div [ _class "current-number pixel-font number-glow"; _id "currentNumber" ] [
                        str "0"
                    ]
                    div [ _class "next-number" ] [
                        str "Next:"
                        span [ _id "nextNumber" ] [
                            str "1"
                        ]
                    ]
                ]
                div [ _class "ninja-area" ] [
                    div [ _id "chatBubble"; attr "style" "display: none; position: absolute; top: 0; left: 50%; transform: translateX(-50%); z-index: 10;" ] [
                        div [ _class "chat-bubble"; _id "bubbleContent" ] [
                            div [ _id "bubbleExpr"; attr "style" "color: #333; font-weight: bold; font-size: 1.1rem;" ] []
                            div [ _id "bubbleResult"; attr "style" "color: #666; font-size: 0.85rem; text-align: right;" ] []
                        ]
                    ]
                    div [ _id "checkmark"; attr "style" "display: none;" ] [
                        div [ _class "checkmark-icon" ] [
                            str "✓"
                        ]
                    ]
                    div [ _class "ninja ninja-idle"; _id "ninja"; attr "style" "left: 50%; transform: translateX(-50%);" ] [
                        img [ _src ("data:image/png;base64," + Image.NinjaIdle); _alt "Ninja"; _id "ninjaImg" ]
                    ]
                    div [ _class "target-platform" ] []
                    div [ _class "target-number"; _id "targetNumber" ] [
                        str "1"
                    ]
                ]
                form [ _id "gameForm"; attr "onsubmit" "handleSubmit(event)" ] [
                    div [ _class "input-wrapper"; _id "inputWrapper" ] [
                        input [ _type "text"; _id "gameInput"; _class "game-input"; attr "placeholder" "Enter expression (e.g., 1+46+8)"; attr "autocomplete" "off"; attr "inputmode" "text"; attr "enterkeyhint" "go"; attr "autocapitalize" "sentences"; attr "spellcheck" "true"; attr "aria-label" "Count or compose a Countku" ]
                        button [ _type "submit"; _class "go-btn" ] [
                            str "GO"
                        ]
                    ]
                    div [ _id "haikuDisplay"; attr "style" "display:none; margin:8px auto; padding:8px 12px; background:rgba(255,100,150,0.08); border:1px solid rgba(255,138,179,0.2); border-radius:10px; text-align:center; max-width:450px;" ] [
                        div [ _id "haikuLine1"; attr "style" "color:#ffb7d5; font-size:0.85rem; margin:2px 0;" ] []
                        div [ _id "haikuLine2"; attr "style" "color:#ffb7d5; font-size:0.85rem; margin:2px 0;" ] []
                        div [ _id "haikuLine3"; attr "style" "color:#ffb7d5; font-size:0.85rem; margin:2px 0;" ] []
                        div [ _id "haikuStatus"; attr "style" "color:#ff8ab3; font-size:0.78rem; margin-top:4px;" ] []
                        div [ _id "debugConsole"; attr "style" "display:none; margin-top:6px; padding:6px 8px; background:rgba(0,0,0,0.4); border:1px solid rgba(100,255,150,0.3); border-radius:6px; font-family:'VT323',monospace; font-size:0.75rem; color:#4ade80; text-align:left; overflow-wrap:break-word;" ] [
                            div [ attr "style" "color:#6ee7b7; font-size:0.65rem; margin-bottom:3px; border-bottom:1px solid rgba(100,255,150,0.2); padding-bottom:2px;" ] [
                                str "> debug console"
                            ]
                            div [ _id "debugMath"; attr "style" "color:#86efac;" ] []
                            div [ _id "debugLatex"; attr "style" "color:#c4b5fd; margin-top:2px;" ] []
                            div [ _id "debugEval"; attr "style" "color:#fcd34d; margin-top:2px;" ] []
                        ]
                    ]
                    p [ _class "input-hint"; _id "inputHint" ] [
                        str "Supports: +, -, *, /, ^, ln(), log(), sqrt(), sin(), cos(), arcsin(), pi, e"
                    ]
                ]
            ]
            div [ _class "dashboard-overlay"; _id "dashboard" ] [
                div [ _class "dashboard dashboard-swoop" ] [
                    div [ _class "dashboard-header" ] [
                        div [ _class "x-icon" ] [
                            str "✕"
                        ]
                        h2 [ _class "pixel-font retro-text"; attr "style" "color: #ffb7d5; font-size: 1.5rem;" ] [
                            str "GAME OVER"
                        ]
                        p [ attr "style" "color: rgba(255, 183, 213, 0.6); margin-top: 8px;" ] [
                            str "Wrong answer! Expected:"
                            span [ _id "expectedNumber" ] [
                                str "1"
                            ]
                        ]
                    ]
                    div [ _class "stats-grid" ] [
                        div [ _class "stat-card" ] [
                            div [ _class "stat-icon" ] [
                                str "#"
                            ]
                            div [ _class "stat-label" ] [
                                str "Final Count"
                            ]
                            div [ _class "stat-value"; _id "finalCount" ] [
                                str "0"
                            ]
                        ]
                        div [ _class "stat-card" ] [
                            div [ _class "stat-icon" ] [
                                str "📈"
                            ]
                            div [ _class "stat-label" ] [
                                str "Max Streak"
                            ]
                            div [ _class "stat-value"; _id "maxStreak" ] [
                                str "0"
                            ]
                        ]
                        div [ _class "stat-card" ] [
                            div [ _class "stat-icon" ] [
                                str "🎯"
                            ]
                            div [ _class "stat-label" ] [
                                str "Accuracy"
                            ]
                            div [ _class "stat-value"; _id "accuracy" ] [
                                str "0%"
                            ]
                        ]
                        div [ _class "stat-card" ] [
                            div [ _class "stat-icon" ] [
                                str "⏱"
                            ]
                            div [ _class "stat-label" ] [
                                str "Duration"
                            ]
                            div [ _class "stat-value"; _id "duration" ] [
                                str "0s"
                            ]
                        ]
                    ]
                    div [ _class "graph-container" ] [
                        p [] [
                            str "Count Progress"
                        ]
                        div [ _class "graph-bars"; _id "graphBars" ] []
                    ]
                    div [ _class "extra-stats" ] [
                        span [] [
                            str "Speed:"
                            span [ _id "speed" ] [
                                str "0"
                            ]
                            str "/min"
                        ]
                        span [] [
                            str "Total:"
                            span [ _id "totalAttempts" ] [
                                str "0"
                            ]
                            str "attempts"
                        ]
                    ]
                    button [ _class "play-again-btn"; attr "onclick" "resetGame()" ] [
                        span [] [
                            str "↻"
                        ]
                        str "PLAY AGAIN"
                    ]
                ]
            ]
            script [] [
                    rawText ("""// Game state
let currentNumber = 0, input = '', lastEntry = null, showBubble = false, bubbleTimeout = null;
let ninjaState = 'idle', gameOver = false, history = [0], startTime = new Date();
let streak = 0, maxStreak = 0, totalAttempts = 0, correctAttempts = 0;
let currentMode = 'normal'; // 'normal', 'hard', 'wtf', 'countku'
// ============================================================================
// COUNTKU ENGINE v8.0 — executable Tables 1–6
// One table-driven language feeds syllables, parsing, evaluation, and LaTeX.
// ============================================================================

// === TABLES 1–6: one lexicon, one grammar, one AST ===
// The markdown matrices are executable data; the parser only supplies precedence.
// Countku's tables are the language.  The parser only supplies precedence and state.
const wordGroups = [
  [1, `a add and base by cube cubed e eight fifth first five for four fourth
       from half halved ninth nth of oh on one pi plus point root shit sine sixth
       square squared sum tan ten tenth the third three times to total twelfth
       twice two type with zed mod six nine log an twelve`],
  [2, `after added adding cosine double doubled effect fourteen fifteen halving
       minus over performed power product quadratic quartic quintic secant septic
       sextic seven thirteen thirty forty fifty sixty eighty ninety tangent tripled
       tripling twenty under using zero cubic octic nonic decic natural value
       hundred thousand million billion subtract thirteen fourteen fifteen sixteen
       eighteen nineteen thirteenth number second seventh trillion`],
  [3, `absolute arccosine arctangent addition decadic difference divided division
       duodecic eleven executed hexadic influence inverse modulo nonary octadic
       pentadic quadrantal quinary senary sextantal subtracted subtracting
       subtraction tetradic tetragonal tessaric thirtieth fortieth fiftieth
       sixtieth quadrupled quadrupling seventeenth twentieth quadratic seventy
       seventeen eleventh`],
  [4, `cosecant cotangent dodecadic enneadic heptadic heptagonal hendecadic
       logarithm multiplied multiplying octonary pentagonal quadrillion septenary
       seventieth eightieth ninetieth undergoing undecic undenary`],
  [5, `dodecagonal duodenary hendecagonal multiplication undecagonal`],
  [6, `duodecagonal`]
];

const SYLLABLES = new Map();
for (const [count, source] of wordGroups) {
  for (const word of source.trim().split(/\s+/)) SYLLABLES.set(word, count);
}

const CARDINALS = new Map([
  [`zero`, 0], [`zed`, 0], [`one`, 1], [`two`, 2], [`three`, 3], [`four`, 4],
  [`five`, 5], [`six`, 6], [`seven`, 7], [`eight`, 8], [`nine`, 9], [`ten`, 10],
  [`eleven`, 11], [`twelve`, 12], [`thirteen`, 13], [`fourteen`, 14],
  [`fifteen`, 15], [`sixteen`, 16], [`seventeen`, 17], [`eighteen`, 18],
  [`nineteen`, 19], [`twenty`, 20], [`thirty`, 30], [`forty`, 40],
  [`fifty`, 50], [`sixty`, 60], [`seventy`, 70], [`eighty`, 80], [`ninety`, 90]
]);

const SCALES = new Map([
  [`hundred`, 100], [`thousand`, 1e3], [`million`, 1e6], [`billion`, 1e9],
  [`trillion`, 1e12], [`quadrillion`, 1e15]
]);

const ordinalRows = [
  [0, `zeroth`],
  [1, `first`],
  [2, `second half quadratic square`],
  [3, `third cubic`],
  [4, `fourth quartic quadrantal tetragonal tetradic tessaric`],
  [5, `fifth quintic quinary pentagonal pentadic`],
  [6, `sixth sextic senary hexagonal hexadic sextantal`],
  [7, `seventh septic septenary heptagonal heptadic`],
  [8, `eighth octic octonary octagonal octadic`],
  [9, `ninth nonic nonary enneadic`],
  [10, `tenth decic denary decadic`],
  [11, `eleventh undecic undenary hendecadic hendecagonal undecagonal`],
  [12, `twelfth duodecic duodenary dodecagonal dodecadic duodecagonal`],
  [13, `thirteenth`],
  [14, `fourteenth`], [15, `fifteenth`], [16, `sixteenth`],
  [17, `seventeenth`], [18, `eighteenth`], [19, `nineteenth`],
  [20, `twentieth`], [30, `thirtieth`], [40, `fortieth`],
  [50, `fiftieth`], [60, `sixtieth`], [70, `seventieth`],
  [80, `eightieth`], [90, `ninetieth`]
];
const ORDINALS = new Map(
  ordinalRows.flatMap(([value, source]) =>
    source.split(/\s+/).map(word => [word, value])
  )
);

// Words used by the operator matrix but absent from the base/ordinal tables.
for (const [word, count] of [
  [`arcsine`, 2], [`arccosine`, 3], [`arctangent`, 3], [`cosecant`, 3],
  [`cotangent`, 3], [`denary`, 3], [`doubled`, 2], [`eighteen`, 2],
  [`eighteenth`, 2], [`eighth`, 1], [`euler's`, 3], [`fifteenth`, 2], [`fourteenth`, 2],
  [`heptadic`, 3], [`hexagonal`, 3], [`nineteenth`, 2], [`octagonal`, 3],
  [`quadrupled`, 3], [`seventeenth`, 3], [`sixteenth`, 2], [`twelfth`, 1],
  [`undecic`, 3], [`undenary`, 4], [`zeroth`, 2]
]) SYLLABLES.set(word, count);

const T = Object.freeze({
  ROOT2: `@root:2`, ROOT3: `@root:3`, ROOT_OF: `@root-of`,
  POWER_OF: `@power-of`, POW: `@pow`, LN: `@ln`, LOG10: `@log:10`,
  LOG_BASE: `@log-base`, OF: `@of`, ABS: `@abs`, INV: `@inv`,
  HALF: `@half`, DOUBLE: `@double`, TWICE: `@twice`,
  SUM: `@sum`, PRODUCT: `@product`,
  HALVED: `@scale:.5`, DOUBLED: `@scale:2`,
  TRIPLED: `@scale:3`, QUADRUPLED: `@scale:4`,
  SIN: `@sin`, COS: `@cos`, TAN: `@tan`, SEC: `@sec`, CSC: `@csc`,
  COT: `@cot`, ASIN: `@asin`, ACOS: `@acos`, ATAN: `@atan`,
  FLIP_SUB: `@flip:-`, FLIP_DIV: `@flip:/`, AFTER: `@after`, E: `@e`
});

const phraseRows = [
  [`under the influence of division from`, T.FLIP_DIV],
  [`subtracted from`, T.FLIP_SUB],
  [`subtracted by`, `-`],
  [`added to`, `+`],
  [`added with`, `+`],
  [`to the natural logarithm of`, `@pow-ln`],
  [`to the natural log of`, `@pow-ln`],
  [`to the logarithm of`, `@pow-log`],
  [`to the log of`, `@pow-log`],
  [`natural logarithm of`, T.LN],
  [`absolute value of`, T.ABS],
  [`with undergoing quadrupling`, T.QUADRUPLED],
  [`undergoing with quadrupling`, T.QUADRUPLED],
  [`with undergoing tripling`, T.TRIPLED],
  [`undergoing with tripling`, T.TRIPLED],
  [`with undergoing doubling`, T.DOUBLED],
  [`undergoing with doubling`, T.DOUBLED],
  [`with undergoing halving`, T.HALVED],
  [`undergoing with halving`, T.HALVED],
  [`under the influence of`, null],
  [`to the power of`, T.POW],
  [`arccosine of`, T.ACOS], [`arctangent of`, T.ATAN],
  [`natural log of`, T.LN], [`cube root of`, T.ROOT3],
  [`square root of`, T.ROOT2], [`the influence of`, null],
  [`cosecant of`, T.CSC], [`cotangent of`, T.COT],
  [`undergoing quadrupling`, T.QUADRUPLED],
  [`undergoing tripling`, T.TRIPLED],
  [`undergoing doubling`, T.DOUBLED],
  [`undergoing halving`, T.HALVED],
  [`under quadrupling`, T.QUADRUPLED], [`under tripling`, T.TRIPLED],
  [`under doubling`, T.DOUBLED], [`under halving`, T.HALVED],
  [`logarithm of`, T.LOG10], [`a total of`, null],
  [`an effect of`, null], [`the number`, null],
  [`multiplied by`, `*`], [`divided over`, `/`], [`divided by`, `/`],
  [`arcsine of`, T.ASIN], [`cosine of`, T.COS], [`tangent of`, T.TAN],
  [`secant of`, T.SEC], [`inverse of`, T.INV],
  [`log base`, T.LOG_BASE], [`log of`, T.LOG10],
  [`root of`, T.ROOT_OF], [`power of`, T.POWER_OF],
  [`half of`, T.HALF], [`euler's number`, T.E],
  [`product of`, T.PRODUCT], [`sum of`, T.SUM],
  [`sine of`, T.SIN], [`type shit`, null],
  [`to power of`, T.POW], [`after`, T.AFTER],
  [`adding`, null], [`subtracting`, null]
];

// Table 4 is a Cartesian grammar, not a list of bespoke cases.
const connectors = [``, `using`, `with`, `by`, `undergoing`, `under`,
  `using with`, `with using`, `with undergoing`, `undergoing with`];
const nounRows = [
  [`addition`, [``, `to`, `with`, `of`], `+`],
  [`subtraction`, [``, `with`, `of`, `by`], `-`],
  [`subtraction`, [`from`], T.FLIP_SUB],
  [`multiplication`, [``, `with`, `by`, `of`], `*`],
  [`division`, [``, `with`, `by`, `of`, `from`], `/`]
];
for (const connector of connectors) {
  for (const article of [``, `the`]) {
    for (const [noun, tails, token] of nounRows) {
      for (const tail of tails) {
        const phrase = [connector, article, noun, tail].filter(Boolean).join(` `);
        phraseRows.push([phrase, token]);
      }
    }
  }
}

const PHRASES = phraseRows
  .map(([phrase, token]) => [phrase.split(` `), token])
  .sort((a, b) => b[0].length - a[0].length);

function rawWords(source) {
  return source
    .replace(/[’]/g, `'`)
    .toLowerCase()
    .replace(/([/])/g, ` $1 `)
    .replace(/[,.!?;:()[\]{}"]/g, ` `)
    .trim()
    .split(/\s+/)
    .filter(Boolean);
}

function semanticTokens(words) {
  const singles = new Map([
    [`plus`, `+`], [`minus`, `-`], [`times`, `*`], [`over`, `/`],
    [`modulo`, `%`], [`mod`, `%`]
  ]);
  const out = [];
  for (let i = 0; i < words.length;) {
    if (words[i] === `/`) { i++; continue; }
    let hit = null;
    for (const row of PHRASES) {
      const [pattern] = row;
      if (pattern.every((word, offset) => words[i + offset] === word)) {
        hit = row;
        break;
      }
    }
    if (!hit) {
      out.push(singles.get(words[i]) || words[i]);
      i++;
      continue;
    }
    if (hit[1] !== null) out.push(hit[1]);
    i += hit[0].length;
  }
  return out;
}

const N = value => ({ t: `n`, v: String(value) });
const C = value => ({ t: `c`, v: value });
const U = (op, arg, degree) => ({ t: `u`, o: op, a: arg, d: degree });
const B = (op, left, right, implicit = false) =>
  ({ t: `b`, o: op, a: left, b: right, i: implicit });

class CountkuSyntaxError extends Error {
  constructor(message, token = null) {
    super(token ? `${message} near “${token}”` : message);
    this.name = `CountkuSyntaxError`;
  }
}

class CountkuParser {
  constructor(tokens, state) {
    this.tokens = tokens;
    this.state = state;
    this.i = 0;
  }

  peek(offset = 0) { return this.tokens[this.i + offset]; }
  take() { return this.tokens[this.i++]; }
  match(token) {
    if (this.peek() !== token) return false;
    this.i++;
    return true;
  }

  parse() {
    if (!this.tokens.length) throw new CountkuSyntaxError(`No mathematical terms remain`);
    const ast = this.expression(0);
    while (this.match(T.AFTER)) {}
    if (this.i !== this.tokens.length) {
      throw new CountkuSyntaxError(`Unexpected word`, this.peek());
    }
    return ast;
  }

  expression(minPrecedence) {
    let left = this.prefix();
    for (;;) {
      while (this.match(T.AFTER)) {}

      const ordinalPower = this.readPostfixOrdinalPower();
      if (ordinalPower !== null) {
        left = U(`root-power`, left, ordinalPower);
        continue;
      }

      if (this.match(`@pow-ln`)) {
        left = B(`^`, left, U(`ln`, this.prefix()));
        continue;
      }
      if (this.match(`@pow-log`)) {
        left = B(`^`, left, this.logarithm(this.prefix()));
        continue;
      }

      const postfix = new Map([
        [`squared`, [`root-power`, 2]], [`cubed`, [`root-power`, 3]],
        [`halved`, [`scale`, 0.5]], [`doubled`, [`scale`, 2]],
        [`tripled`, [`scale`, 3]], [`quadrupled`, [`scale`, 4]],
        [T.HALVED, [`scale`, 0.5]], [T.DOUBLED, [`scale`, 2]],
        [T.TRIPLED, [`scale`, 3]], [T.QUADRUPLED, [`scale`, 4]]
      ]).get(this.peek());
      if (postfix) {
        this.take();
        left = U(postfix[0], left, postfix[1]);
        continue;
      }

      let op = this.peek();
      let implicit = false;
      if (!new Set([`+`, `-`, `*`, `/`, `%`, T.POW, T.FLIP_SUB, T.FLIP_DIV]).has(op)) {
        if (!this.atomStarts()) break;
        op = `*`;
        implicit = true;
      }

      const precedence = op === T.POW ? 30 :
        (op === `*` || op === `/` || op === `%` || op === T.FLIP_DIV) ? 20 : 10;
      if (precedence < minPrecedence) break;
      if (!implicit) this.take();

      const right = this.expression(precedence + (op === T.POW ? 0 : 1));
      if (op === T.FLIP_SUB) left = B(`-`, right, left);
      else if (op === T.FLIP_DIV) left = B(`/`, right, left);
      else left = B(op === T.POW ? `^` : op, left, right, implicit);
    }
    return left;
  }

  prefix() {
    while (this.peek() === `the` &&
      (this.atomStarts(1) || ORDINALS.has(this.peek(1)))) this.take();

    if (this.match(`-`)) return U(`neg`, this.prefix());
    if (this.match(`add`)) {
      const added = this.prefix();
      if (!this.match(`to`)) throw new CountkuSyntaxError(`“add” requires “to”`, this.peek());
      return B(`+`, this.prefix(), added);
    }
    if (this.match(`subtract`)) {
      const subtracted = this.prefix();
      if (!this.match(`from`)) throw new CountkuSyntaxError(`“subtract” requires “from”`, this.peek());
      return B(`-`, this.prefix(), subtracted);
    }

    const fractionalRoot = this.readFractionalRoot();
    if (fractionalRoot) return fractionalRoot;

    if (this.match(T.SUM)) return B(`+`, this.prefix(), this.prefix());
    if (this.match(T.PRODUCT)) return B(`*`, this.prefix(), this.prefix());

    const token = this.peek();
    const fixedPrefixes = new Map([
      [T.ROOT2, [`root`, 2]], [T.ROOT3, [`root`, 3]],
      [T.LN, [`ln`]], [T.LOG10, [`log`, 10]], [T.ABS, [`abs`]],
      [T.INV, [`inverse`]], [T.HALF, [`scale`, 0.5]],
      [T.DOUBLE, [`scale`, 2]], [T.TWICE, [`scale`, 2]],
      [T.SIN, [`sin`]], [T.COS, [`cos`]], [T.TAN, [`tan`]],
      [T.SEC, [`sec`]], [T.CSC, [`csc`]], [T.COT, [`cot`]],
      [T.ASIN, [`asin`]], [T.ACOS, [`acos`]], [T.ATAN, [`atan`]]
    ]);
    if (token === T.LOG10) {
      this.take();
      return this.logarithm(this.prefix());
    }
    if (fixedPrefixes.has(token)) {
      this.take();
      const [op, degree] = fixedPrefixes.get(token);
      return U(op, this.prefix(), degree);
    }

    if (this.match(T.LOG_BASE)) {
      const base = this.prefix();
      if (!this.match(T.OF) && !this.match(`of`)) {
        throw new CountkuSyntaxError(`“log base” requires “of”`, this.peek());
      }
      return { t: `log`, a: this.prefix(), b: base };
    }

    const ordinal = this.readOrdinalOperator();
    if (ordinal) {
      const [degree, operator] = ordinal;
      const argument = this.prefix();
      return operator === `ordinal-log`
        ? { t: `log`, a: argument, b: N(degree) }
        : U(operator, argument, degree);
    }

    if (this.match(`double`)) return U(`scale`, this.prefix(), 2);
    if (this.match(`twice`)) return U(`scale`, this.prefix(), 2);
    if (this.match(T.E)) return C(`e`);
    if (this.match(`e`)) return C(`e`);
    if (this.match(`pi`)) return C(`pi`);

    if (CARDINALS.has(token) || SCALES.has(token) || token === `a` || token === `point`) {
      return this.number();
    }

    throw new CountkuSyntaxError(`Expected a number or function`, token);
  }

  logarithm(argument) {
    if (!this.match(`base`)) return U(`log`, argument);
    return { t: `log`, a: argument, b: this.prefix() };
  }

  readFractionalRoot() {
    const start = this.i;
    if (this.peek() !== `a` && this.peek() !== `one`) return null;
    this.take();
    if (this.match(T.HALF)) return U(`root`, this.prefix(), 2);
    for (let ofIndex = this.i + 1; ofIndex < Math.min(this.tokens.length, this.i + 8); ofIndex++) {
      if (this.tokens[ofIndex] !== `of`) continue;
      const degree = parseOrdinalWords(this.tokens.slice(this.i, ofIndex));
      if (degree === null) break;
      this.i = ofIndex + 1;
      return U(`root`, this.prefix(), degree);
    }
    this.i = start;
    return null;
  }

  readOrdinalOperator() {
    const start = this.i;
    if (this.match(`the`)) {}
    for (let trigger = this.i + 1; trigger < Math.min(this.tokens.length, this.i + 10); trigger++) {
      const operator = this.tokens[trigger];
      if (operator !== T.ROOT_OF && operator !== T.POWER_OF && operator !== T.LOG10) continue;
      const degree = parseOrdinalWords(this.tokens.slice(this.i, trigger));
      if (degree === null) continue;
      this.i = trigger + 1;
      return [degree, operator === T.ROOT_OF ? `root` :
        operator === T.POWER_OF ? `root-power` : `ordinal-log`];
    }
    this.i = start;
    return null;
  }

  readPostfixOrdinalPower() {
    const start = this.i;
    if (!this.match(`to`)) return null;
    this.match(`the`);
    for (let trigger = this.i + 1; trigger < Math.min(this.tokens.length, this.i + 10); trigger++) {
      if (this.tokens[trigger] !== `power`) continue;
      const degree = parseOrdinalWords(this.tokens.slice(this.i, trigger));
      if (degree === null) break;
      this.i = trigger + 1;
      this.match(`of`);
      return degree;
    }
    this.i = start;
    return null;
  }

  ordinalOperatorAhead(index = this.i) {
    for (let trigger = index + 1; trigger < Math.min(this.tokens.length, index + 10); trigger++) {
      if (this.tokens[trigger] !== T.ROOT_OF && this.tokens[trigger] !== T.POWER_OF &&
          this.tokens[trigger] !== T.LOG10) continue;
      return parseOrdinalWords(this.tokens.slice(index, trigger)) !== null;
    }
    return false;
  }

  atomStarts(offset = 0) {
    const token = this.peek(offset);
    if (!token) return false;
    // “the” is an optional prefix, never a silent binary operator.  Prefix()
    // consumes it at the beginning of an atom; adjacency such as “four the
    // five” must not become accidental implicit multiplication.
    if (token === `the`) return false;
    if (this.ordinalOperatorAhead(this.i + offset)) return true;
    return CARDINALS.has(token) || SCALES.has(token) ||
      new Set([
        `a`, `point`, `-`, `add`, `subtract`, `double`, `twice`, `e`, `pi`,
        T.ROOT2, T.ROOT3, T.LN, T.LOG10, T.LOG_BASE, T.ABS, T.INV, T.HALF,
        T.DOUBLE, T.TWICE, T.SIN, T.COS, T.TAN, T.SEC, T.CSC, T.COT,
        T.ASIN, T.ACOS, T.ATAN, T.E, T.SUM, T.PRODUCT
      ]).has(token);
  }

  number() {
    let total = 0;
    let group = 0;
    let saw = false;
    let lastClass = null;
    let groupHadHundred = false;
    let groupAnd = false;

    const finishGroup = position => {
      if (groupHadHundred) this.state.and(position, groupAnd);
      groupHadHundred = false;
      groupAnd = false;
    };

    while (this.i < this.tokens.length) {
      const word = this.peek();
      if (word === `a` && this.peek(1) === `hundred`) {
        group += 1;
        saw = true;
        lastClass = `one`;
        this.take();
        continue;
      }
      if (word === `oh`) {
        if (!saw) throw new CountkuSyntaxError(`“oh” is only legal after “point”`, word);
        break;
      }
      if (word === `and`) {
        if (!saw || (lastClass !== `hundred` && lastClass !== `high`)) break;
        groupAnd = true;
        lastClass = `and`;
        this.take();
        continue;
      }
      if (word === `point`) break;
      if (SCALES.has(word)) {
        const scale = SCALES.get(word);
        if (scale === 100) {
          if (!saw) group = 1;
          else if (![`one`, `teen`, `ten`, `tens`].includes(lastClass)) {
            throw new CountkuSyntaxError(`Invalid number before “hundred”`, word);
          }
          group = (group || 1) * 100;
          groupHadHundred = true;
          saw = true;
          lastClass = `hundred`;
        } else {
          const position = Math.round(Math.log10(scale) / 3);
          finishGroup(position);
          total += (group || 1) * scale;
          group = 0;
          saw = true;
          lastClass = `high`;
        }
        this.take();
        continue;
      }
      if (!CARDINALS.has(word)) break;
      if (saw && this.ordinalOperatorAhead()) break;

      const value = CARDINALS.get(word);
      const cls = value < 10 ? `one` : value === 10 ? `ten` : value < 20 ? `teen` : `tens`;
      const allowed = !lastClass || lastClass === `hundred` || lastClass === `high` ||
        lastClass === `and` || (lastClass === `tens` && cls === `one`);
      if (!allowed) {
        throw new CountkuSyntaxError(`Invalid cardinal composition`, word);
      }
      group += value;
      saw = true;
      lastClass = cls;
      this.take();
    }

    if (!saw && this.peek() !== `point`) {
      throw new CountkuSyntaxError(`Expected a number`, this.peek());
    }

    finishGroup(0);
    let literal = String(total + group);
    if (this.match(`point`)) {
      let digits = ``;
      while (this.i < this.tokens.length) {
        const word = this.peek();
        if (word === `oh` || word === `zero` || word === `zed`) {
          digits += `0`;
          this.take();
        } else if (CARDINALS.has(word) && CARDINALS.get(word) >= 1 && CARDINALS.get(word) <= 9) {
          digits += String(CARDINALS.get(word));
          this.take();
        } else if (word === `ten`) {
          digits += `10`;
          this.take();
        } else if (CARDINALS.has(word) || SCALES.has(word) || ORDINALS.has(word)) {
          throw new CountkuSyntaxError(`Only digits or “ten” may follow “point”`, word);
        } else break;
      }
      if (!digits) throw new CountkuSyntaxError(`“point” requires decimal digits`, this.peek());
      literal += `.${digits}`;
    }
    return N(literal);
  }
}

function parseOrdinalWords(words) {
  if (!words.length || words.some(word => word.startsWith(`@`))) return null;
  if (words.length === 1 && ORDINALS.has(words[0])) return ORDINALS.get(words[0]);
  const last = words.at(-1);
  if (!ORDINALS.has(last)) return null;
  const tail = ORDINALS.get(last);
  if (words.length === 2 && CARDINALS.has(words[0]) && CARDINALS.get(words[0]) >= 20 &&
      CARDINALS.get(words[0]) % 10 === 0 && tail < 10) {
    return CARDINALS.get(words[0]) + tail;
  }
  return null;
}

function renderJs(node) {
  if (node.t === `n`) return node.v;
  if (node.t === `c`) return node.v === `pi` ? `Math.PI` : `Math.E`;
  if (node.t === `log`) return `(Math.log(${renderJs(node.a)})/Math.log(${renderJs(node.b)}))`;
  if (node.t === `b`) {
    const a = renderJs(node.a), b = renderJs(node.b);
    return node.o === `^` ? `Math.pow(${a},${b})` : `(${a}${node.o}${b})`;
  }
  const a = renderJs(node.a);
  if (node.o === `root`) return `Math.pow(${a},1/${node.d})`;
  if (node.o === `root-power`) return `Math.pow(${a},${node.d})`;
  if (node.o === `scale`) return `(${node.d}*${a})`;
  if (node.o === `inverse`) return `(1/${a})`;
  if (node.o === `neg`) return `(-${a})`;
  const functions = {
    ln: `Math.log`, log: `Math.log10`, abs: `Math.abs`,
    sin: `Math.sin`, cos: `Math.cos`, tan: `Math.tan`,
    asin: `Math.asin`, acos: `Math.acos`, atan: `Math.atan`
  };
  if (functions[node.o]) return `${functions[node.o]}(${a})`;
  if (node.o === `sec`) return `(1/Math.cos(${a}))`;
  if (node.o === `csc`) return `(1/Math.sin(${a}))`;
  if (node.o === `cot`) return `(1/Math.tan(${a}))`;
  throw new CountkuSyntaxError(`Unknown AST operator “${node.o}”`);
}

function evaluateAst(node) {
  if (node.t === `n`) return Number(node.v);
  if (node.t === `c`) return node.v === `pi` ? Math.PI : Math.E;
  if (node.t === `log`) return Math.log(evaluateAst(node.a)) / Math.log(evaluateAst(node.b));
  if (node.t === `b`) {
    const a = evaluateAst(node.a), b = evaluateAst(node.b);
    return ({ "+": () => a + b, "-": () => a - b, "*": () => a * b,
      "/": () => a / b, "%": () => a % b, "^": () => a ** b })[node.o]();
  }
  const a = evaluateAst(node.a);
  if (node.o === `root`) return a ** (1 / node.d);
  if (node.o === `root-power`) return a ** node.d;
  if (node.o === `scale`) return node.d * a;
  if (node.o === `inverse`) return 1 / a;
  if (node.o === `neg`) return -a;
  if (node.o === `ln`) return Math.log(a);
  if (node.o === `log`) return Math.log10(a);
  if (node.o === `abs`) return Math.abs(a);
  if (node.o === `sin`) return Math.sin(a);
  if (node.o === `cos`) return Math.cos(a);
  if (node.o === `tan`) return Math.tan(a);
  if (node.o === `sec`) return 1 / Math.cos(a);
  if (node.o === `csc`) return 1 / Math.sin(a);
  if (node.o === `cot`) return 1 / Math.tan(a);
  if (node.o === `asin`) return Math.asin(a);
  if (node.o === `acos`) return Math.acos(a);
  if (node.o === `atan`) return Math.atan(a);
  throw new CountkuSyntaxError(`Unknown AST operator “${node.o}”`);
}

function renderLatex(node, parent = 0) {
  if (node.t === `n`) return node.v;
  if (node.t === `c`) return node.v === `pi` ? `\\pi` : `e`;
  if (node.t === `log`) {
    return `\\log_{${renderLatex(node.b)}}\\!\\left(${renderLatex(node.a)}\\right)`;
  }
  if (node.t === `b`) {
    if (node.o === `/`) return `\\frac{${renderLatex(node.a)}}{${renderLatex(node.b)}}`;
    if (node.o === `^`) return `{${renderLatex(node.a, 30)}}^{${renderLatex(node.b)}}`;
    const precedence = node.o === `+` || node.o === `-` ? 10 : 20;
    const symbol = node.o === `*` ? (node.i ? `\\,` : `\\cdot `) :
      node.o === `%` ? `\\bmod ` : node.o;
    const body = `${renderLatex(node.a, precedence)}${symbol}${renderLatex(node.b, precedence + 1)}`;
    return precedence < parent ? `\\left(${body}\\right)` : body;
  }
  const a = renderLatex(node.a);
  if (node.o === `root`) {
    return node.d === 2 ? `\\sqrt{${a}}` : `\\sqrt[${node.d}]{${a}}`;
  }
  if (node.o === `root-power`) return `{${a}}^{${node.d}}`;
  if (node.o === `scale`) return node.d === 0.5 ? `\\frac{${a}}{2}` : `${node.d}\\cdot ${a}`;
  if (node.o === `inverse`) return `\\frac{1}{${a}}`;
  if (node.o === `neg`) return `-${a}`;
  const names = {
    ln: `ln`, log: `log`, abs: `operatorname{abs}`, sin: `sin`, cos: `cos`,
    tan: `tan`, sec: `sec`, csc: `csc`, cot: `cot`, asin: `arcsin`,
    acos: `arccos`, atan: `arctan`
  };
  return `\\${names[node.o]}\\!\\left(${a}\\right)`;
}

class CountkuConverter {
  constructor() { this.resetVariants(); }
  resetVariants() {
    this.locks = { zero: null, multiply: null, euler: null, and: {} };
    this.last = null;
  }
  getSyllables(word) { return SYLLABLES.get(word.toLowerCase()) ?? null; }
  tokenize(source) { return semanticTokens(rawWords(source)); }

  candidate(source) {
    const words = rawWords(source).filter(word => word !== `/`);
    const values = { zero: null, multiply: null, euler: null, and: {} };
    const locks = this.locks;
    const select = (group, choice) => {
      if (values[group] && values[group] !== choice) {
        throw new CountkuSyntaxError(
          `Variant conflict: “${values[group]}” and “${choice}” cannot share a Countku`
        );
      }
      if (this.locks[group] && this.locks[group] !== choice) {
        throw new CountkuSyntaxError(
          `Variant lock: this run uses “${this.locks[group]}”, not “${choice}”`
        );
      }
      values[group] = choice;
    };
    for (let i = 0; i < words.length; i++) {
      const word = words[i];
      if ([`zero`, `zed`, `oh`].includes(word)) select(`zero`, word);
      if (word === `times`) select(`multiply`, `times`);
      if (word === `multiplied`) select(`multiply`, `multiplied by`);
      if (word === `e`) select(`euler`, `e`);
      if (word === `euler's` && words[i + 1] === `number`) {
        select(`euler`, `euler's number`);
      }
    }
    return {
      values,
      and(position, enabled) {
        const key = String(position);
        if (key in values.and && values.and[key] !== enabled) {
          throw new CountkuSyntaxError(`AndMatrix conflict at 10^${position * 3}`);
        }
        if (key in locks.and && locks.and[key] !== enabled) {
          throw new CountkuSyntaxError(`AndMatrix lock at 10^${position * 3}`);
        }
        values.and[key] = enabled;
      }
    };
  }

  analyze(source) {
    try {
      const candidate = this.candidate(source);
      const tokens = this.tokenize(source);
      const ast = new CountkuParser(tokens, candidate).parse();
      const value = evaluateAst(ast);
      if (!Number.isFinite(value)) throw new CountkuSyntaxError(`The expression is not finite`);
      const result = {
        ast, tokens, expr: renderJs(ast), latex: renderLatex(ast), value,
        variants: candidate.values
      };
      this.last = result;
      return result;
    } catch (error) {
      return { error: error.message };
    }
  }

  convertPhrase(source) {
    const result = this.analyze(source);
    return result.error ? result : result.expr;
  }

  commit(result = this.last) {
    if (!result || result.error) return;
    for (const group of [`zero`, `multiply`, `euler`]) {
      if (result.variants[group]) this.locks[group] = result.variants[group];
    }
    Object.assign(this.locks.and, result.variants.and);
  }
}

class HaikuValidator {
  constructor(converter) { this.converter = converter; }
  validate(source) {
    const words = rawWords(source);
    if (!words.length) return { isHaiku: false, error: `Empty input`, lines: [] };
    const explicit = words.includes(`/`);
    const targets = [5, 7, 5];
    const lines = [{ words: [], syllables: 0 }];

    for (const original of words) {
      if (original === `/`) {
        if (!explicit || lines.at(-1).words.length === 0 || lines.length === 3) {
          return { isHaiku: false, error: `Invalid explicit line break`, lines };
        }
        lines.push({ words: [], syllables: 0 });
        continue;
      }
      if (original.includes(`-`)) {
        return { isHaiku: false, error: `Words are indivisible: “${original}”`, lines };
      }
      const syllables = this.converter.getSyllables(original);
      if (syllables === null) {
        return { isHaiku: false, error: `Unknown word: “${original}”`, lines };
      }

      let line = lines.at(-1);
      const target = targets[lines.length - 1];
      if (!explicit && line.syllables === target && lines.length < 3) {
        lines.push({ words: [], syllables: 0 });
        line = lines.at(-1);
      }
      const activeTarget = targets[lines.length - 1];
      if (line.syllables + syllables > activeTarget) {
        return {
          isHaiku: false,
          error: `“${original}” crosses line ${lines.length}: ${line.syllables}+${syllables}>${activeTarget}`,
          lines
        };
      }
      line.words.push(original);
      line.syllables += syllables;
    }

    const exact = lines.length === 3 &&
      lines.every((line, index) => line.syllables === targets[index]);
    const error = exact ? null :
      lines.length !== 3 ? `Expected 3 lines (5-7-5), got ${lines.length}` :
      lines.map((line, i) => `${line.syllables}/${targets[i]}`).join(` · `);
    return { isHaiku: exact, error, lines };
  }
}

const countkuConverter = new CountkuConverter();
const haikuValidator = new HaikuValidator(countkuConverter);


// ============================================================================
// COUNTKU UI — Live haiku display
// ============================================================================

function updateHaikuDisplay(input) {
    const display = document.getElementById('haikuDisplay');
    if (currentMode !== 'countku') { display.style.display = 'none'; return; }
    if (!input.trim()) { display.style.display = 'none'; return; }

    const result = haikuValidator.validate(input);
    const analysis = countkuConverter.analyze(input);
    display.style.display = 'block';

    for (let i = 0; i < 3; i++) {
        const el = document.getElementById('haikuLine' + (i + 1));
        if (result.lines && result.lines[i]) {
            const line = result.lines[i];
            const target = [5, 7, 5][i];
            el.textContent = line.words.join(' ') + ' (' + line.syllables + '/' + target + ')';
            el.style.color = line.syllables === target ? '#4ade80' : '#ff8ab3';
        } else {
            el.textContent = '';
        }
    }

    const statusEl = document.getElementById('haikuStatus');
    if (result.isHaiku && !analysis.error) {
        statusEl.textContent = 'Valid 5-7-5 · exact mathematical grammar';
        statusEl.style.color = '#4ade80';
    } else if (result.error || analysis.error) {
        statusEl.textContent = result.error || analysis.error;
        statusEl.style.color = '#ff5050';
    } else if (result.lines.length > 0) {
        const total = result.lines.reduce((s, l) => s + l.syllables, 0);
        statusEl.textContent = 'Syllables: ' + total + '/17';
        statusEl.style.color = '#ff8ab3';
    } else {
        statusEl.textContent = 'Type to form a 5-7-5 haiku...';
    }

    // One AST supplies all three views, so the display cannot drift from execution.
    const debugConsole = document.getElementById('debugConsole');
    const debugMath = document.getElementById('debugMath');
    const debugLatex = document.getElementById('debugLatex');
    const debugEval = document.getElementById('debugEval');
    if (debugConsole && debugMath && debugLatex && debugEval) {
        debugConsole.style.display = 'block';
        if (!analysis.error) {
            const target = currentNumber + 1;
            const hit = Math.abs(analysis.value - target) < 0.0001
                ? ' TARGET HIT!' : ' (target: ' + target + ')';
            debugMath.textContent = 'JS  > ' + analysis.expr;
            debugLatex.textContent = 'TeX > ' + analysis.latex;
            debugEval.textContent = '= ' + analysis.value + hit;
        } else {
            debugMath.textContent = '> [grammar: ' + analysis.error + ']';
            debugLatex.textContent = '';
            debugEval.textContent = '';
        }
    }
}

// Direct execution (script is at end of body, DOM is ready)
(function() {
    const inputEl = document.getElementById('gameInput');
    if (inputEl) {
        inputEl.addEventListener('input', function(e) {
            if (currentMode === 'countku') updateHaikuDisplay(e.target.value);
        });
    }
})();



const petalImg = "data:image/png;base64,""" + Image.Petal + """";
const windImg = "data:image/png;base64,""" + Image.Wind + """";
const ninjaRunImg = "data:image/png;base64,""" + Image.NinjaRun + """";
const ninjaJumpImg = "data:image/png;base64,""" + Image.NinjaJump + """";
const ninjaIdleImg = "data:image/png;base64,""" + Image.NinjaIdle + """";

// Help content for each mode
const helpContent = {
    normal: `
        <h2 class="pixel-font">SYNTAX HELP (NORMAL - Base 10)</h2>
        <div class="help-section">
            <h3>Basic Operators</h3>
            <ul>
                <li><code>+</code> Addition: <code>1+2</code> = 3</li>
                <li><code>-</code> Subtraction: <code>5-3</code> = 2</li>
                <li><code>*</code> Multiplication: <code>2*3</code> = 6</li>
                <li><code>/</code> Division: <code>6/2</code> = 3</li>
                <li><code>^</code> Power: <code>2^3</code> = 8</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Functions</h3>
            <ul>
                <li><code>sqrt(a)</code> Square root: <code>sqrt(16)</code> = 4</li>
                <li><code>log(a)</code> Natural log (ln): <code>log(e)</code> = 1</li>
                <li><code>ln(a)</code> Same as log(a): <code>ln(e)</code> = 1</li>
                <li><code>log_b(a)</code> Log base b: <code>log_2(8)</code> = 3</li>
                <li><code>abs(a)</code> Absolute value: <code>abs(-5)</code> = 5</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Trigonometry</h3>
            <ul>
                <li><code>sin(a)</code>, <code>cos(a)</code>, <code>tan(a)</code></li>
                <li><code>arcsin(a)</code>, <code>arccos(a)</code>, <code>arctan(a)</code> (inverse)</li>
                <li><code>sin^-1(a)</code> Same as arcsin (wraps function)</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Constants</h3>
            <ul>
                <li><code>pi</code> or <code>π</code> ≈ 3.14159...</li>
                <li><code>e</code> ≈ 2.71828...</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Examples</h3>
            <ul>
                <li><code>1+46+8</code> = 55</li>
                <li><code>2^3+3^2</code> = 17</li>
                <li><code>(cos(1))^2+(sin(1))^2</code> = 1</li>
                <li><code>sqrt(16)+log(e)</code> = 5</li>
            </ul>
        </div>
    `,
    hard: `
        <h2 class="pixel-font">SYNTAX HELP (HARD - Base 2)</h2>
        <div class="help-section">
            <p style="color: #ff8ab3; margin-bottom: 15px;">All numbers are interpreted as BINARY and converted to decimal before calculation!</p>
            <h3>Binary Digits</h3>
            <ul>
                <li>Use only <code>0</code> and <code>1</code></li>
                <li><code>01</code> = 1, <code>10</code> = 2, <code>11</code> = 3</li>
                <li><code>101</code> = 5, <code>1111</code> = 15</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Operators (work on converted values)</h3>
            <ul>
                <li><code>01+10</code> → 1+2 = <code>3</code></li>
                <li><code>11*10</code> → 3*2 = <code>6</code></li>
                <li><code>100/10</code> → 4/2 = <code>2</code></li>
                <li><code>10^11</code> → 2^3 = <code>8</code></li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Functions (input converted to decimal)</h3>
            <ul>
                <li><code>sqrt(100)</code> → sqrt(4) = <code>2</code></li>
                <li><code>sin(01)</code> → sin(1) ≈ <code>0.84</code></li>
                <li><code>log(10)</code> → log(2) ≈ <code>0.69</code></li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Examples</h3>
            <ul>
                <li><code>01+10+11</code> → 1+2+3 = 6</li>
                <li><code>101*10</code> → 5*2 = 10</li>
                <li><code>1111-1010</code> → 15-10 = 5</li>
            </ul>
        </div>
    `,
    wtf: `
        <h2 class="pixel-font">SYNTAX HELP (WTF - Base 16)</h2>
        <div class="help-section">
            <p style="color: #ff8ab3; margin-bottom: 15px;">All numbers are interpreted as HEXADECIMAL and converted to decimal before calculation!</p>
            <h3>Hex Digits</h3>
            <ul>
                <li><code>0-9</code> and <code>a-f</code> (or <code>A-F</code>)</li>
                <li><code>a</code> = 10, <code>f</code> = 15</li>
                <li><code>10</code> = 16, <code>ff</code> = 255</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Operators (work on converted values)</h3>
            <ul>
                <li><code>a+5</code> → 10+5 = <code>15</code></li>
                <li><code>f*2</code> → 15*2 = <code>30</code></li>
                <li><code>10+10</code> → 16+16 = <code>32</code></li>
                <li><code>ff/10</code> → 255/16 ≈ <code>15.9</code></li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Functions (input converted to decimal)</h3>
            <ul>
                <li><code>sqrt(10)</code> → sqrt(16) = <code>4</code></li>
                <li><code>sin(a)</code> → sin(10) ≈ <code>-0.54</code></li>
                <li><code>log(f)</code> → log(15) ≈ <code>2.71</code></li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Examples</h3>
            <ul>
                <li><code>a+b</code> → 10+11 = 21</li>
                <li><code>f*10</code> → 15*16 = 240</li>
                <li><code>ff-80</code> → 255-128 = 127</li>
            </ul>
        </div>
    `,
    countku: `
        <h2 class="pixel-font">SYNTAX HELP (COUNTKU - Word Math Haiku)</h2>
        <div class="help-section">
            <p style="color: #ff8ab3; margin-bottom: 15px;">Type math as ENGLISH WORDS in 5-7-5 syllable format!</p>
            <h3>Numbers (0-19)</h3>
            <ul>
                <li><code>zero</code> 0(2) <code>one</code> 1(1) <code>two</code> 2(1) <code>three</code> 3(1) <code>four</code> 4(1)</li>
                <li><code>five</code> 5(1) <code>six</code> 6(1) <code>seven</code> 7(2) <code>eight</code> 8(1) <code>nine</code> 9(1)</li>
                <li><code>ten</code> 10(1) <code>eleven</code> 11(3) <code>twelve</code> 12(1) <code>thirteen</code> 13(2) <code>fourteen</code> 14(2)</li>
                <li><code>fifteen</code> 15(2) <code>sixteen</code> 16(2) <code>seventeen</code> 17(3) <code>eighteen</code> 18(2) <code>nineteen</code> 19(2)</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Tens, Large Numbers &amp; Composition</h3>
            <ul>
                <li><code>twenty</code> 20(2) <code>thirty</code> 30(2) <code>forty</code> 40(2) <code>fifty</code> 50(2) <code>sixty</code> 60(2) <code>seventy</code> 70(3) <code>eighty</code> 80(2) <code>ninety</code> 90(2)</li>
                <li><code>hundred</code> &times;100(2) <code>thousand</code> &times;1000(2) <code>million</code> &times;1M(2)</li>
                <li>Composed: <code>twenty one</code> = 21, <code>thirty five</code> = 35, <code>one hundred</code> = 100</li>
                <li>Nested: <code>one hundred twenty three</code> = 123</li>
                <li>Large: <code>one hundred thousand eight hundred and sixty two</code> = 100,862</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Decimals &amp; Special Zero</h3>
            <ul>
                <li><code>point</code> = decimal(1) — <code>one point five</code> = 1.5</li>
                <li><code>oh</code> = 0(1) — ONLY after decimal: <code>one point oh oh</code> = 1.00</li>
                <li><code>oh</code> outside decimal = error!</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Basic Operators</h3>
            <ul>
                <li><code>plus</code> = +(1) | <code>minus</code> = -(2) | <code>times</code> = &times;(1)</li>
                <li><code>divided by</code> = &divide;(4) | <code>over</code> = &divide;(2)</li>
                <li><code>multiplied by</code> = &times;(5) | <code>modulo</code> = %(3)</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Powers &amp; Roots</h3>
            <ul>
                <li><code>squared</code> = &sup2;(1) | <code>cubed</code> = &sup3;(1)</li>
                <li><code>to the power of</code> = ^(5) — <code>two to the power of three</code> = 8</li>
                <li><code>square root of</code> = &radic;(3) — <code>square root of sixteen</code> = 4</li>
                <li><code>cube root of</code> = &#x221B;(3)</li>
                <li><code>nth root of</code> = <sup>n</sup>&radic;(3)</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Ordinal Powers &amp; Roots (Systematic &amp; Latin Forms)</h3>
            <p style="color: #b0b0b0; font-size: 0.85em; margin-bottom: 8px;">Use any ordinal as a degree for power/root operations. All forms of the same degree are interchangeable.</p>
            <ul>
                <li><strong>2nd:</strong> <code>second</code>(2) <code>half</code>(1) <code>quadratic</code>(3) <code>square</code>(1) — <code>quadratic power of five</code> = Math.pow(5,2)</li>
                <li><strong>3rd:</strong> <code>third</code>(1) <code>cubic</code>(2) — <code>cubic root of eight</code> = Math.pow(8,1/3)</li>
                <li><strong>4th:</strong> <code>fourth</code>(1) <code>quartic</code>(2) <code>quadrantal</code>(3) <code>tetragonal</code>(3) <code>tetradic</code>(3) <code>tessaric</code>(3)</li>
                <li><strong>5th:</strong> <code>fifth</code>(1) <code>quintic</code>(2) <code>quinary</code>(3) <code>pentagonal</code>(4) <code>pentadic</code>(3)</li>
                <li><strong>6th:</strong> <code>sixth</code>(1) <code>sextic</code>(2) <code>senary</code>(3) <code>hexagonal</code>(3) <code>hexadic</code>(3) <code>sextantal</code>(3)</li>
                <li><strong>7th:</strong> <code>seventh</code>(2) <code>septic</code>(2) <code>septenary</code>(4) <code>heptagonal</code>(4) <code>heptadic</code>(3)</li>
                <li><strong>8th:</strong> <code>eighth</code>(1) <code>octic</code>(2) <code>octonary</code>(4) <code>octagonal</code>(3) <code>octadic</code>(3)</li>
                <li><strong>9th:</strong> <code>ninth</code>(1) <code>nonic</code>(2) <code>nonary</code>(3) <code>enneadic</code>(4)</li>
                <li><strong>10th:</strong> <code>tenth</code>(1) <code>decic</code>(2) <code>denary</code>(3) <code>decadic</code>(3)</li>
                <li><strong>11th:</strong> <code>eleventh</code>(3) <code>undecic</code>(3) <code>undenary</code>(4) <code>hendecadic</code>(4) <code>hendecagonal</code>(5) <code>undecagonal</code>(5)</li>
                <li><strong>12th:</strong> <code>twelfth</code>(1) <code>duodecic</code>(3) <code>duodenary</code>(5) <code>dodecagonal</code>(5) <code>dodecadic</code>(4) <code>duodecagonal</code>(6)</li>
            </ul>
            <p style="color: #b0b0b0; font-size: 0.85em; margin-top: 8px;"><strong>Grammar:</strong> <code>[ordinal] power of [base]</code> → Math.pow(base, N) | <code>[ordinal] root of [radicand]</code> → Math.pow(radicand, 1/N)</p>
        </div>
        <div class="help-section">
            <h3>Scaling (Postfix / Prefix)</h3>
            <ul>
                <li><code>halved</code> = /2(1) | <code>doubled</code> = &times;2(2) | <code>tripled</code> = &times;3(2) | <code>quadrupled</code> = &times;4(3)</li>
                <li><code>half of</code> = (1/2)&times;(2) | <code>double</code> = 2&times;(2) | <code>twice</code> = 2&times;(1)</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Functions</h3>
            <ul>
                <li><code>natural log of</code> = ln(4) — <code>natural log of e</code> = 1</li>
                <li><code>logarithm of</code> = log(5)</li>
                <li><code>log base N of</code> = log<sub>N</sub>(4) — <code>log base two of eight</code> = 3</li>
                <li><code>absolute value of</code> = |x|(6)</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Trigonometry</h3>
            <ul>
                <li><code>sine of</code> = sin(2) | <code>cosine of</code> = cos(3) | <code>tangent of</code> = tan(3)</li>
                <li><code>secant of</code> = sec(3) | <code>cosecant of</code> = csc(4) | <code>cotangent of</code> = cot(4)</li>
                <li><code>arcsine of</code> = asin(3) | <code>arccosine of</code> = acos(4) | <code>arctangent of</code> = atan(4)</li>
                <li><code>inverse of</code> = 1/x(4)</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Constants</h3>
            <ul>
                <li><code>pi</code> = &pi;(1) ≈ 3.14159</li>
                <li><code>e</code> = e(1) ≈ 2.71828 | <code>euler's number</code> = e(5)</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Noise &amp; Filler Words (counted for syllables, stripped from math)</h3>
            <ul>
                <li><code>type shit</code> = 2 free syllables! No math effect whatsoever.</li>
                <li><code>the influence of</code> = 5 syl | <code>under the influence of</code> = 7 syl</li>
                <li><code>a total of</code> = 3 syl | <code>an effect of</code> = 4 syl</li>
                <li><code>the number</code> = 3 syl — "the number seven" = 7</li>
                <li><code>adding</code> = 2 syl | <code>subtracting</code> = 3 syl</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Chaining &amp; Noun Operators</h3>
            <ul>
                <li><code>after</code> = closes function parens (2 syl) — for chaining functions</li>
                <li><code>using addition of</code> = +(6) | <code>using the addition of</code> = +(7)</li>
                <li><code>using subtraction of</code> = -(6) | <code>using the subtraction of</code> = -(7)</li>
                <li><code>undergoing division</code> passive: <code>one undergoing division with two</code> = 1/2</li>
                <li><code>under the influence of division from</code> passive: B/A flip</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Variant Rules (Pick One &mdash; Cannot Mix!)</h3>
            <ul>
                <li><code>zero</code> OR <code>zed</code> OR <code>oh</code> — pick one form of zero</li>
                <li><code>times</code> OR <code>multiplied by</code> — pick one multiplication word</li>
                <li><code>e</code> OR <code>euler's number</code> — pick one form of Euler's constant</li>
                <li><code>... hundred and ...</code> OR <code>... hundred ...</code> — pick one "and" style</li>
            </ul>
        </div>
        <div class="help-section">
            <h3>The Rules</h3>
            <ul>
                <li>Your input MUST form a 5-7-5 haiku (17 syllables total, 3 lines)</li>
                <li>The math must equal the next target number</li>
                <li>Multi-syllable words cannot be split across lines (anti-splice)</li>
                <li>Functions auto-close after their argument completes</li>
                <li>Both checks must pass: valid haiku AND correct math</li>
                <li><a href="https://app.shel.sh/countku/1" title="[logic]">[logic]</a> . <a href="https://app.shel.sh/countku/2" title="[changelog]">[changelog]</a> . <a href="https://app.shel.sh/countku/3" title="[guidebook]">[guidebook]</a></li>
            </ul>
        </div>
        <div class="help-section">
            <h3>Examples</h3>
            <ul>
                <li><code>The sine of zero / minus three point zero plus / one plus one plus two</code> = 1</li>
                <li><code>Two minus three point / zero zero zero plus / one plus one plus one</code> = 2</li>
                <li><code>The square root of one / plus zero plus zero plus / zero plus zero</code> = 1</li>
            </ul>
        </div>
    `
};

// Input hints for each mode
const inputHints = {
    normal: 'Supports: +, -, *, /, ^, ln(), log(), sqrt(), sin(), cos(), arcsin(), pi, e',
    hard: 'BINARY MODE: Use 0-1 only. Ex: 01+10=3, 101*11=15',
    wtf: 'HEX MODE: Use 0-9, a-f. Ex: a+b=21, ff-80=127',
    countku: 'WORD HAIKU: 5-7-5 syllables. E.g., "The sine of zero minus three point..."'
};

// Input placeholders for each mode
const inputPlaceholders = {
    normal: 'Enter expression (e.g., 1+46+8)',
    hard: 'Enter binary (e.g., 01+10+11)',
    wtf: 'Enter hex (e.g., a+b+c)',
    countku: 'Enter 5-7-5 word haiku (e.g., the sine of zero minus...)'
};

// Set game mode
function setMode(mode) {
    currentMode = mode;

    // Update button states
    document.querySelectorAll('.mode-btn').forEach(btn => btn.classList.remove('active'));
    document.getElementById('mode-' + mode).classList.add('active');

    // Update input hint and placeholder
    document.getElementById('inputHint').textContent = inputHints[mode];
    document.getElementById('gameInput').placeholder = inputPlaceholders[mode];

    // Hide haiku display when not in countku mode
    if (mode !== 'countku') {
        document.getElementById('haikuDisplay').style.display = 'none';
    }

    // Reset game
    resetGame();
}

// Convert binary string to decimal
function binaryToDecimal(binStr) {
    return parseInt(binStr, 2).toString();
}

// Convert hex string to decimal
function hexToDecimal(hexStr) {
    return parseInt(hexStr, 16).toString();
}

// Convert expression based on current mode
function convertExpression(expr) {
    if (currentMode === 'normal') return expr;

    // Countku mode: convert English words to math expression
    if (currentMode === 'countku') {
        const result = countkuConverter.convertPhrase(expr);
        if (result && typeof result === 'object' && result.error) {
            return result;
        }
        return result || expr;
    }

    // For hard (binary) and wtf (hex) modes, we need to convert number literals
    // but preserve operators, functions, and parentheses

    let converted = expr;

    if (currentMode === 'hard') {
        // Binary mode: convert binary numbers to decimal
        // Reject if any digits 2-9 are present (not valid binary)
        if (/\b[2-9]\b/.test(converted)) {
            return { error: 'Binary mode: digits 2-9 are not allowed! Use only 0 and 1.' };
        }
        converted = converted.replace(/\b[01]+\b/g, match => binaryToDecimal(match));
    } else if (currentMode === 'wtf') {
        // Hex mode: convert hex numbers to decimal
        converted = converted.replace(/\b[0-9a-fA-F]+\b/g, match => hexToDecimal(match));
    }

    return converted;
}

// Petal spawning
function spawnPetal() {
    const container = document.getElementById('petals-container');
    const petal = document.createElement('div');
    petal.className = 'petal';
    petal.style.backgroundImage = 'url(' + petalImg + ')';
    const startX = 60 + Math.random() * 30;
    const delay = Math.random() * 2;
    const duration = 10 + Math.random() * 6;
    petal.style.left = startX + '%';
    petal.style.animationDelay = delay + 's';
    petal.style.animationDuration = duration + 's';
    container.appendChild(petal);
    setTimeout(() => petal.remove(), (duration + delay) * 1000);
}
setInterval(spawnPetal, 800);

// Wind swirl spawning
function spawnWindSwirl() {
    if (Math.random() < 0.3) {
        const container = document.getElementById('wind-container');
        const swirl = document.createElement('div');
        swirl.className = 'wind-swirl';
        swirl.style.backgroundImage = 'url(' + windImg + ')';
        swirl.style.left = Math.random() * window.innerWidth + 'px';
        swirl.style.top = Math.random() * window.innerHeight * 0.6 + 100 + 'px';
        container.appendChild(swirl);
        setTimeout(() => swirl.remove(), 3000);
    }
}
setInterval(spawnWindSwirl, 3000);

function evaluateExpression(expr) {
    try {
        // First, convert the expression based on current mode
        let convertedExpr = convertExpression(expr);

        // Check if conversion returned an error
        if (convertedExpr && typeof convertedExpr === 'object' && convertedExpr.error) {
            return null;
        }

        // Remove whitespace
        let cleanExpr = convertedExpr.replace(/\s/g, '');

        // Replace constants FIRST (before function replacements)
        cleanExpr = cleanExpr.replace(/π/g, '(Math.PI)');
        cleanExpr = cleanExpr.replace(/\be\b/g, '(Math.E)');
        cleanExpr = cleanExpr.replace(/\bpi\b/g, '(Math.PI)');

        // Handle log base notation BEFORE simple log
        cleanExpr = cleanExpr.replace(/log_([\d.]+)\(([^)]+)\)/g, '(Math.log($2)/Math.log($1))');

        // Handle ln (natural log) - must be before log
        cleanExpr = cleanExpr.replace(/ln\(/g, 'Math.log(');

        // Handle simple log (now safe because ln is already converted)
        cleanExpr = cleanExpr.replace(/(?<!Math\.)log\(/g, 'Math.log(');

        // Handle inverse trig functions
        cleanExpr = cleanExpr.replace(/arcsin\(/g, 'Math.asin(');
        cleanExpr = cleanExpr.replace(/arccos\(/g, 'Math.acos(');
        cleanExpr = cleanExpr.replace(/arctan\(/g, 'Math.atan(');

        // Handle sin^-1, cos^-1, tan^-1 notation
        cleanExpr = cleanExpr.replace(/sin\^-1\(/g, 'Math.asin(');
        cleanExpr = cleanExpr.replace(/cos\^-1\(/g, 'Math.acos(');
        cleanExpr = cleanExpr.replace(/tan\^-1\(/g, 'Math.atan(');

        // Handle power operator
        cleanExpr = cleanExpr.replace(/\^/g, '**');

        // Other functions
        cleanExpr = cleanExpr.replace(/sqrt\(/g, 'Math.sqrt(');
        cleanExpr = cleanExpr.replace(/abs\(/g, 'Math.abs(');
        cleanExpr = cleanExpr.replace(/(?<!Math\.)sin\(/g, 'Math.sin(');
        cleanExpr = cleanExpr.replace(/(?<!Math\.)cos\(/g, 'Math.cos(');
        cleanExpr = cleanExpr.replace(/(?<!Math\.)tan\(/g, 'Math.tan(');

        const result = eval(cleanExpr);
        if (typeof result !== 'number' || !isFinite(result)) return null;
        return Math.round(result * 1000000) / 1000000;
    } catch (e) { return null; }
}

function playSound(type) {
    const audio = document.getElementById('sound-' + type);
    if (audio) { audio.currentTime = 0; audio.play().catch(() => {}); }
}

function showChatBubble(text, result) {
    if (bubbleTimeout) clearTimeout(bubbleTimeout);
    const bubble = document.getElementById('chatBubble');
    document.getElementById('bubbleExpr').textContent = text;
    document.getElementById('bubbleResult').textContent = '= ' + result;
    document.getElementById('bubbleContent').classList.remove('fade-out');
    bubble.style.display = 'block';
    bubbleTimeout = setTimeout(() => {
        document.getElementById('bubbleContent').classList.add('fade-out');
        setTimeout(() => bubble.style.display = 'none', 1000);
    }, 9000);
}

function handleSubmit(e) {
    e.preventDefault();
    if (gameOver) return;
    const inputEl = document.getElementById('gameInput');
    const value = inputEl.value.trim();
    if (!value) return;
    totalAttempts++;

    let exprToEvaluate = value;
    let countkuAnalysis = null;

    // === COUNTKU MODE: Check BOTH haiku validation AND plaintext math ===
    if (currentMode === 'countku') {
        // --- Check 1: Haiku Validation (5-7-5 structure) ---
        const haikuCheck = haikuValidator.validate(value);
        if (!haikuCheck.isHaiku) {
            const wrapper = document.getElementById('inputWrapper');
            wrapper.classList.add('shake');
            setTimeout(() => wrapper.classList.remove('shake'), 500);
            showChatBubble('Countku Error', haikuCheck.error || 'Not a valid 5-7-5 haiku');
            playSound('failure');
            return;
        }

        // --- Check 2: Authoritative sentence → AST conversion ---
        countkuAnalysis = countkuConverter.analyze(value);
        if (countkuAnalysis.error) {
            const wrapper = document.getElementById('inputWrapper');
            wrapper.classList.add('shake');
            setTimeout(() => wrapper.classList.remove('shake'), 500);
            showChatBubble('Countku Error', countkuAnalysis.error);
            playSound('failure');
            return;
        }
        exprToEvaluate = countkuAnalysis.expr;
    }

    const result = countkuAnalysis ? countkuAnalysis.value : evaluateExpression(exprToEvaluate);
    if (result === null) {
        const wrapper = document.getElementById('inputWrapper');
        wrapper.classList.add('shake');
        setTimeout(() => wrapper.classList.remove('shake'), 500);
        return;
    }
    const targetNumber = currentNumber + 1;
    if (Math.abs(result - targetNumber) < 0.0001) {
        if (countkuAnalysis) countkuConverter.commit(countkuAnalysis);
        correctAttempts++; streak++; maxStreak = Math.max(maxStreak, streak);
        playSound('ding'); showChatBubble(value, result);
        currentNumber = targetNumber; history.push(targetNumber);
        updateDisplay(); inputEl.value = '';
        document.getElementById('streakIndicator').style.display = 'block';
        document.getElementById('streakValue').textContent = streak;
        animateNinja();
    } else {
        streak = 0; document.getElementById('streakIndicator').style.display = 'none';
        const wrapper = document.getElementById('inputWrapper');
        wrapper.classList.add('shake');
        setTimeout(() => wrapper.classList.remove('shake'), 500);
        playSound('failure'); endGame();
    }
}

function animateNinja() {
    const ninja = document.getElementById('ninja');
    const ninjaImg = document.getElementById('ninjaImg');
    ninja.classList.remove('ninja-idle'); ninja.classList.add('ninja-run'); ninjaImg.src = ninjaRunImg;
    setTimeout(() => {
        ninja.classList.remove('ninja-run'); ninja.classList.add('ninja-jump'); ninjaImg.src = ninjaJumpImg;
        document.getElementById('checkmark').style.display = 'block';
        setTimeout(() => {
            ninja.classList.remove('ninja-jump'); ninja.classList.add('ninja-idle'); ninjaImg.src = ninjaIdleImg;
            document.getElementById('checkmark').style.display = 'none';
        }, 600);
    }, 800);
}

function updateDisplay() {
    document.getElementById('currentNumber').textContent = currentNumber;
    document.getElementById('nextNumber').textContent = currentNumber + 1;
    document.getElementById('targetNumber').textContent = currentNumber + 1;
}

function endGame() {
    gameOver = true;
    const gameDuration = Math.floor((new Date().getTime() - startTime.getTime()) / 1000);
    const accuracy = totalAttempts > 0 ? Math.round((correctAttempts / totalAttempts) * 100) : 0;
    const speed = gameDuration > 0 ? Math.round((correctAttempts / gameDuration) * 60 * 10) / 10 : 0;
    document.getElementById('expectedNumber').textContent = currentNumber + 1;
    document.getElementById('finalCount').textContent = currentNumber;
    document.getElementById('maxStreak').textContent = maxStreak;
    document.getElementById('accuracy').textContent = accuracy + '%';
    document.getElementById('duration').textContent = gameDuration + 's';
    document.getElementById('speed').textContent = speed;
    document.getElementById('totalAttempts').textContent = totalAttempts;
    const graphContainer = document.getElementById('graphBars');
    graphContainer.innerHTML = '';
    const maxVal = Math.max(...history, 10), minVal = Math.min(...history, 0), range = maxVal - minVal || 1;
    history.slice(-20).forEach((val, i) => {
        const height = Math.max(((val - minVal) / range) * 100, 5);
        const bar = document.createElement('div');
        bar.className = 'graph-bar bar-grow';
        bar.style.setProperty('--bar-height', height + '%');
        bar.style.animationDelay = (i * 0.05) + 's';
        graphContainer.appendChild(bar);
    });
    document.getElementById('dashboard').classList.add('active');
}

function resetGame() {
    currentNumber = 0; input = ''; lastEntry = null; showBubble = false; ninjaState = 'idle';
    gameOver = false; history = [0]; startTime = new Date(); streak = 0; maxStreak = 0;
    totalAttempts = 0; correctAttempts = 0;
    if (bubbleTimeout) clearTimeout(bubbleTimeout);
    document.getElementById('gameInput').value = '';
    document.getElementById('chatBubble').style.display = 'none';
    document.getElementById('bubbleContent').classList.remove('fade-out');
    document.getElementById('streakIndicator').style.display = 'none';
    document.getElementById('streakValue').textContent = '0';
    document.getElementById('dashboard').classList.remove('active');
    document.getElementById('haikuDisplay').style.display = 'none';
    if (countkuConverter) countkuConverter.resetVariants();
    updateDisplay(); document.getElementById('gameInput').focus();
}

function showHelp() {
    document.getElementById('helpContent').innerHTML = helpContent[currentMode];
    document.getElementById('helpModal').classList.add('active');
}

function hideHelp() { document.getElementById('helpModal').classList.remove('active'); }

window.CountkuHost = Object.freeze({
    setMode,
    handleSubmit,
    resetGame,
    showHelp,
    hideHelp
});

document.getElementById('helpModal').addEventListener('click', function(e) { if (e.target === this) hideHelp(); });
document.getElementById('gameInput').focus();""")
            ]
            script [ _src "game/countku-app.js?v=0.6.1"; _type "module" ] []
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
