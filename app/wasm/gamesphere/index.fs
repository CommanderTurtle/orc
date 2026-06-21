module ConvertedFiles.Wasm.Gamesphere.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Aether GC - GameCube Emulator"
            ]
            style [] [
                    rawText ("""/* ============================================================
   AETHER GC EMULATOR
   A standalone Nintendo GameCube emulator shell
   Built for Dolphin WebAssembly core integration
   Supports .iso/.gcm/.dol files with memory card management
   ============================================================ */
*, *::before, *::after { margin: 0; padding: 0; box-sizing: border-box; }
:root {
  --bg-primary: #0a0e1a; --bg-secondary: #111827; --bg-card: rgba(17,24,39,0.85);
  --accent: #7c3aed; --accent-glow: rgba(124,58,237,0.4); --accent-secondary: #06b6d4;
  --gc-purple: #6b21a8; --gc-indigo: #4c1d95;
  --text-primary: #e2e8f0; --text-secondary: #94a3b8;
  --success: #10b981; --warning: #f59e0b; --danger: #ef4444;
  --border: rgba(255,255,255,0.08); --glass: rgba(17,24,39,0.7); --glass-border: rgba(255,255,255,0.1);
}
html, body { width: 100%; height: 100%; font-family: 'Segoe UI', system-ui, sans-serif;
  background: var(--bg-primary); color: var(--text-primary); overflow-x: hidden; }

.particles { position: fixed; inset: 0; z-index: 0; pointer-events: none; overflow: hidden; }
.particle { position: absolute; width: 2px; height: 2px; background: var(--accent); border-radius: 50%;
  opacity: 0; animation: float linear infinite; }
@keyframes float { 0% { transform: translateY(100vh) scale(0); opacity: 0; } 10% { opacity: 0.5; }
  90% { opacity: 0.5; } 100% { transform: translateY(-10vh) scale(1); opacity: 0; } }
.particle:nth-child(1){left:5%;animation-duration:18s;animation-delay:0s;width:3px;height:3px;background:var(--accent-secondary);}
.particle:nth-child(2){left:15%;animation-duration:22s;animation-delay:2s;}
.particle:nth-child(3){left:25%;animation-duration:16s;animation-delay:4s;width:4px;height:4px;}
.particle:nth-child(4){left:35%;animation-duration:24s;animation-delay:1s;background:var(--accent-secondary);}
.particle:nth-child(5){left:45%;animation-duration:14s;animation-delay:3s;width:3px;height:3px;}
.particle:nth-child(6){left:55%;animation-duration:20s;animation-delay:5s;}
.particle:nth-child(7){left:65%;animation-duration:17s;animation-delay:2s;width:3px;height:3px;background:var(--accent-secondary);}
.particle:nth-child(8){left:75%;animation-duration:21s;animation-delay:6s;}
.particle:nth-child(9){left:85%;animation-duration:15s;animation-delay:3s;width:4px;height:4px;}
.particle:nth-child(10){left:95%;animation-duration:25s;animation-delay:1s;background:var(--accent-secondary);}
.particle:nth-child(11){left:10%;animation-duration:13s;animation-delay:4s;width:3px;height:3px;}
.particle:nth-child(12){left:40%;animation-duration:19s;animation-delay:7s;}
.particle:nth-child(13){left:60%;animation-duration:23s;animation-delay:0s;}
.particle:nth-child(14){left:80%;animation-duration:12s;animation-delay:5s;width:3px;height:3px;background:var(--accent-secondary);}
.particle:nth-child(15){left:30%;animation-duration:26s;animation-delay:3s;}

.grid-bg { position: fixed; inset: 0; z-index: 0; pointer-events: none;
  background-image: linear-gradient(rgba(124,58,237,0.025) 1px, transparent 1px),
    linear-gradient(90deg, rgba(124,58,237,0.025) 1px, transparent 1px);
  background-size: 40px 40px; }

.app { position: relative; z-index: 1; min-height: 100vh; display: flex; flex-direction: column; }

.header { display: flex; align-items: center; justify-content: space-between;
  padding: 16px 24px; background: var(--glass); backdrop-filter: blur(20px);
  border-bottom: 1px solid var(--glass-border); position: sticky; top: 0; z-index: 100; }
.header-left { display: flex; align-items: center; gap: 12px; }
.logo-icon { width: 36px; height: 36px; border-radius: 10px;
  background: linear-gradient(135deg, var(--accent), var(--accent-secondary));
  display: flex; align-items: center; justify-content: center;
  font-size: 16px; font-weight: 800; color: white; box-shadow: 0 0 20px var(--accent-glow); }
.header-title { font-size: 20px; font-weight: 700; letter-spacing: -0.5px; }
.header-subtitle { font-size: 11px; color: var(--text-secondary); letter-spacing: 1px; text-transform: uppercase; }
.header-right { display: flex; gap: 8px; align-items: center; }

.btn { display: inline-flex; align-items: center; gap: 6px; padding: 8px 16px;
  border-radius: 8px; border: 1px solid var(--border); background: var(--bg-secondary);
  color: var(--text-primary); font-size: 13px; font-weight: 600; cursor: pointer;
  transition: all 0.2s ease; font-family: inherit; }
.btn:hover { background: var(--accent); border-color: var(--accent); transform: translateY(-1px);
  box-shadow: 0 4px 12px var(--accent-glow); }
.btn:active { transform: translateY(0); }
.btn-primary { background: var(--accent); border-color: var(--accent); }
.btn-primary:hover { background: #6d28d9; }
.btn-small { padding: 6px 12px; font-size: 12px; }

.main { flex: 1; display: flex; flex-direction: column; align-items: center; padding: 20px; gap: 16px; }

.status-bar { width: 100%; max-width: 800px; display: flex; align-items: center;
  justify-content: space-between; padding: 10px 18px; background: var(--glass);
  backdrop-filter: blur(12px); border-radius: 10px; border: 1px solid var(--glass-border);
  font-size: 12px; color: var(--text-secondary); }
.status-item { display: flex; align-items: center; gap: 6px; }
.status-dot { width: 8px; height: 8px; border-radius: 50%; background: var(--danger); transition: background 0.3s; }
.status-dot.ready { background: var(--success); box-shadow: 0 0 8px rgba(16,185,129,0.5); }
.status-dot.active { background: var(--accent); box-shadow: 0 0 8px var(--accent-glow); animation: pulse 2s infinite; }
@keyframes pulse { 0%,100% { opacity: 1; } 50% { opacity: 0.5; } }

.viewport { position: relative; border-radius: 16px; overflow: hidden;
  box-shadow: 0 20px 60px rgba(0,0,0,0.5), 0 0 40px rgba(124,58,237,0.1);
  border: 1px solid var(--glass-border); background: #000; }
#gc-canvas { display: block; image-rendering: pixelated; image-rendering: crisp-edges;
  width: 640px; height: 480px; background: #000; }

.crt-overlay { position: absolute; inset: 0; pointer-events: none; z-index: 10;
  background: repeating-linear-gradient(0deg, rgba(0,0,0,0.12) 0px, rgba(0,0,0,0.12) 1px, transparent 1px, transparent 3px);
  opacity: 0; transition: opacity 0.3s; }
.crt-overlay.active { opacity: 1; }
.crt-overlay::after { content: ''; position: absolute; inset: 0;
  background: radial-gradient(ellipse at center, transparent 50%, rgba(0,0,0,0.3) 100%); }

.drop-zone { width: 100%; max-width: 600px; padding: 36px 24px; border: 2px dashed var(--border);
  border-radius: 16px; text-align: center; transition: all 0.3s ease;
  background: var(--glass); backdrop-filter: blur(8px); }
.drop-zone.drag-over { border-color: var(--accent); background: rgba(124,58,237,0.1);
  transform: scale(1.02); box-shadow: 0 0 30px var(--accent-glow); }
.drop-zone-icon { font-size: 44px; margin-bottom: 10px; opacity: 0.5; }
.drop-zone-title { font-size: 16px; font-weight: 600; margin-bottom: 6px; }
.drop-zone-hint { font-size: 12px; color: var(--text-secondary); }
.drop-zone-input { display: none; }

.control-bar { width: 100%; max-width: 800px; display: flex; flex-wrap: wrap;
  align-items: center; gap: 8px; padding: 12px 18px; background: var(--glass);
  backdrop-filter: blur(12px); border-radius: 12px; border: 1px solid var(--glass-border); }
.control-group { display: flex; align-items: center; gap: 6px; padding: 0 8px;
  border-right: 1px solid var(--border); }
.control-group:last-child { border-right: none; }
.control-label { font-size: 11px; color: var(--text-secondary); text-transform: uppercase;
  letter-spacing: 0.5px; margin-right: 4px; }

.mc-panel { width: 100%; max-width: 800px; padding: 16px; background: var(--glass);
  backdrop-filter: blur(12px); border-radius: 12px; border: 1px solid var(--glass-border); }
.mc-panel-title { font-size: 14px; font-weight: 600; margin-bottom: 12px; color: var(--accent); }
.mc-grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(100px, 1fr)); gap: 8px; }
.mc-slot { aspect-ratio: 1; border-radius: 8px; border: 1px solid var(--border);
  background: var(--bg-secondary); display: flex; flex-direction: column;
  align-items: center; justify-content: center; padding: 8px; cursor: pointer;
  transition: all 0.2s; }
.mc-slot:hover { border-color: var(--accent); background: rgba(124,58,237,0.1); }
.mc-slot-number { font-size: 10px; color: var(--text-secondary); }
.mc-slot-status { font-size: 11px; margin-top: 4px; }
.mc-slot-status.empty { color: var(--text-secondary); }
.mc-slot-status.occupied { color: var(--success); }

.log-panel { width: 100%; max-width: 800px; max-height: 120px; overflow-y: auto;
  padding: 12px 16px; background: var(--glass); backdrop-filter: blur(8px);
  border-radius: 10px; border: 1px solid var(--glass-border);
  font-family: 'Consolas', 'Monaco', monospace; font-size: 11px; }
.log-entry { padding: 2px 0; border-bottom: 1px solid rgba(255,255,255,0.03); }
.log-entry.info { color: var(--text-secondary); }
.log-entry.success { color: var(--success); }
.log-entry.warn { color: var(--warning); }
.log-entry.error { color: var(--danger); }

.settings-panel { position: fixed; top: 0; right: -420px; width: 400px; height: 100vh;
  background: var(--glass); backdrop-filter: blur(30px); border-left: 1px solid var(--glass-border);
  z-index: 200; transition: right 0.3s ease; overflow-y: auto; padding: 80px 24px 24px; }
.settings-panel.open { right: 0; }
.settings-overlay { position: fixed; inset: 0; background: rgba(0,0,0,0.5); z-index: 199;
  opacity: 0; pointer-events: none; transition: opacity 0.3s; }
.settings-overlay.open { opacity: 1; pointer-events: all; }
.settings-title { font-size: 20px; font-weight: 700; margin-bottom: 24px; }
.settings-section { margin-bottom: 24px; }
.settings-section-title { font-size: 12px; color: var(--text-secondary); text-transform: uppercase;
  letter-spacing: 1px; margin-bottom: 12px; }
.setting-item { display: flex; align-items: center; justify-content: space-between;
  padding: 10px 0; border-bottom: 1px solid var(--border); }
.setting-label { font-size: 13px; }
.toggle { width: 44px; height: 24px; border-radius: 12px; background: var(--border);
  position: relative; cursor: pointer; transition: background 0.3s; }
.toggle.active { background: var(--accent); }
.toggle-knob { width: 20px; height: 20px; border-radius: 50%; background: white;
  position: absolute; top: 2px; left: 2px; transition: left 0.3s; }
.toggle.active .toggle-knob { left: 22px; }
.select { padding: 6px 12px; border-radius: 6px; border: 1px solid var(--border);
  background: var(--bg-secondary); color: var(--text-primary); font-family: inherit; font-size: 13px; }

.key-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 8px; font-size: 12px; }
.key-grid-item { display: flex; justify-content: space-between; align-items: center;
  padding: 6px 10px; background: var(--bg-secondary); border-radius: 6px; }
.key-grid-action { color: var(--text-secondary); }
.key-badge { padding: 2px 8px; border-radius: 4px; background: var(--bg-secondary);
  border: 1px solid var(--border); font-family: monospace; font-size: 11px; }

@media (max-width: 900px) {
  #gc-canvas { width: 480px; height: 360px; }
  .settings-panel { width: 100%; right: -100%; }
}
@media (max-width: 600px) {
  #gc-canvas { width: 320px; height: 240px; }
  .control-bar { justify-content: center; }
}

.hidden { display: none !important; }
::-webkit-scrollbar { width: 6px; }
::-webkit-scrollbar-track { background: transparent; }
::-webkit-scrollbar-thumb { background: var(--border); border-radius: 3px; }""")
            ]
        ]
        body [] [
            div [ _class "particles" ] [
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
                div [ _class "particle" ] []
            ]
            div [ _class "grid-bg" ] []
            div [ _class "app" ] [
                header [ _class "header" ] [
                    div [ _class "header-left" ] [
                        div [ _class "logo-icon" ] [
                            str "GC"
                        ]
                        div [] [
                            div [ _class "header-title" ] [
                                str "Aether GC"
                            ]
                            div [ _class "header-subtitle" ] [
                                str "Nintendo GameCube Emulator"
                            ]
                        ]
                    ]
                    div [ _class "header-right" ] [
                        button [ _class "btn btn-small"; _id "btn-load-wasm" ] [
                            str "Load Core"
                        ]
                        button [ _class "btn btn-small"; _id "btn-settings" ] [
                            str "Settings"
                        ]
                        button [ _class "btn btn-small"; _id "btn-help" ] [
                            str "?"
                        ]
                    ]
                ]
                main [ _class "main" ] [
                    div [ _class "status-bar" ] [
                        div [ _class "status-item" ] [
                            div [ _class "status-dot"; _id "core-status-dot" ] []
                            span [ _id "core-status-text" ] [
                                str "No core loaded"
                            ]
                        ]
                        div [ _class "status-item" ] [
                            span [ _id "rom-status-text" ] [
                                str "No disc loaded"
                            ]
                        ]
                        div [ _class "status-item" ] [
                            span [ _id "gamepad-status" ] [
                                str "No gamepad"
                            ]
                        ]
                        div [ _class "status-item" ] [
                            span [ _id "fps-counter" ] [
                                str "-- fps"
                            ]
                        ]
                    ]
                    div [ _class "drop-zone"; _id "wasm-drop-zone" ] [
                        div [ _class "drop-zone-icon" ] [
                            str "⚙"
                        ]
                        div [ _class "drop-zone-title" ] [
                            str "Load Emulator Core"
                        ]
                        div [ _class "drop-zone-hint" ] [
                            str "Drop"
                            b [] [
                                str "dolphin.wasm"
                            ]
                            str "+"
                            b [] [
                                str "dolphin.js"
                            ]
                            str "here or click to browse"
                            br []
                            small [] [
                                str "Emscripten-compiled Dolphin WebAssembly files"
                            ]
                        ]
                        input [ _type "file"; _class "drop-zone-input"; _id "wasm-input"; attr "accept" ".wasm,.js"; attr "multiple" "" ]
                    ]
                    div [ _class "drop-zone hidden"; _id "rom-drop-zone" ] [
                        div [ _class "drop-zone-icon" ] [
                            str "💿"
                        ]
                        div [ _class "drop-zone-title" ] [
                            str "Load Game Disc"
                        ]
                        div [ _class "drop-zone-hint" ] [
                            str "Drop"
                            b [] [
                                str ".iso"
                            ]
                            str ","
                            b [] [
                                str ".gcm"
                            ]
                            str ", or"
                            b [] [
                                str ".dol"
                            ]
                            str "here or click to browse"
                            br []
                            small [] [
                                str "GameCube disc images and executable files"
                            ]
                        ]
                        input [ _type "file"; _class "drop-zone-input"; _id "rom-input"; attr "accept" ".iso,.gcm,.dol" ]
                    ]
                    div [ _class "viewport hidden"; _id "emulator-viewport" ] [
                        canvas [ _id "gc-canvas"; attr "width" "640"; attr "height" "480" ] []
                        div [ _class "crt-overlay"; _id "crt-overlay" ] []
                    ]
                    div [ _class "mc-panel hidden"; _id "mc-panel" ] [
                        div [ _class "mc-panel-title" ] [
                            str "Memory Card Manager (Slot A)"
                        ]
                        div [ _class "mc-grid"; _id "mc-grid" ] []
                    ]
                    div [ _class "control-bar"; _id "control-bar" ] [
                        div [ _class "control-group" ] [
                            span [ _class "control-label" ] [
                                str "Disc"
                            ]
                            button [ _class "btn btn-small"; _id "btn-load-rom" ] [
                                str "Load Disc"
                            ]
                            button [ _class "btn btn-small"; _id "btn-eject" ] [
                                str "Eject"
                            ]
                        ]
                        div [ _class "control-group" ] [
                            span [ _class "control-label" ] [
                                str "Memory Card"
                            ]
                            button [ _class "btn btn-small"; _id "btn-import-gci" ] [
                                str "Import .gci"
                            ]
                            button [ _class "btn btn-small"; _id "btn-export-gci" ] [
                                str "Export .gci"
                            ]
                            input [ _type "file"; _class "drop-zone-input"; _id "gci-input"; attr "accept" ".gci,.sav" ]
                        ]
                        div [ _class "control-group" ] [
                            span [ _class "control-label" ] [
                                str "State"
                            ]
                            button [ _class "btn btn-small"; _id "btn-save-state" ] [
                                str "Save State"
                            ]
                            button [ _class "btn btn-small"; _id "btn-load-state" ] [
                                str "Load State"
                            ]
                            select [ _class "select"; _id "state-slot" ] [
                                option [ attr "value" "1" ] [
                                    str "Slot 1"
                                ]
                                option [ attr "value" "2" ] [
                                    str "Slot 2"
                                ]
                                option [ attr "value" "3" ] [
                                    str "Slot 3"
                                ]
                            ]
                        ]
                        div [ _class "control-group" ] [
                            span [ _class "control-label" ] [
                                str "Emu"
                            ]
                            button [ _class "btn btn-small"; _id "btn-play-pause" ] [
                                str "▶ Play"
                            ]
                            button [ _class "btn btn-small"; _id "btn-reset" ] [
                                str "Reset"
                            ]
                        ]
                        div [ _class "control-group" ] [
                            span [ _class "control-label" ] [
                                str "Display"
                            ]
                            button [ _class "btn btn-small"; _id "btn-fullscreen" ] [
                                str "Fullscreen"
                            ]
                            button [ _class "btn btn-small"; _id "btn-crt" ] [
                                str "CRT Off"
                            ]
                            button [ _class "btn btn-small"; _id "btn-mc" ] [
                                str "Memory Card"
                            ]
                        ]
                        div [ _class "control-group" ] [
                            span [ _class "control-label" ] [
                                str "Audio"
                            ]
                            button [ _class "btn btn-small"; _id "btn-audio" ] [
                                str "Audio Off"
                            ]
                        ]
                    ]
                    div [ _class "log-panel"; _id "log-panel" ] [
                        div [ _class "log-entry info" ] [
                            str "Welcome to Aether GC. Load a Dolphin WASM core to begin."
                        ]
                    ]
                ]
            ]
            div [ _class "settings-overlay"; _id "settings-overlay" ] []
            div [ _class "settings-panel"; _id "settings-panel" ] [
                div [ _class "settings-title" ] [
                    str "Settings"
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-section-title" ] [
                        str "Display"
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "CRT Scanline Overlay"
                        ]
                        div [ _class "toggle"; _id "toggle-crt" ] [
                            div [ _class "toggle-knob" ] []
                        ]
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "Smooth Scaling"
                        ]
                        div [ _class "toggle"; _id "toggle-smooth" ] [
                            div [ _class "toggle-knob" ] []
                        ]
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "Canvas Scale"
                        ]
                        select [ _class "select"; _id "select-scale" ] [
                            option [ attr "value" "1" ] [
                                str "1x (640x480)"
                            ]
                            option [ attr "value" "2"; attr "selected" "" ] [
                                str "2x (1280x960)"
                            ]
                            option [ attr "value" "3" ] [
                                str "3x"
                            ]
                        ]
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "Widescreen (16:9)"
                        ]
                        div [ _class "toggle"; _id "toggle-widescreen" ] [
                            div [ _class "toggle-knob" ] []
                        ]
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-section-title" ] [
                        str "Controls - Keyboard"
                    ]
                    div [ _class "key-grid" ] [
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "A Button"
                            ]
                            span [ _class "key-badge" ] [
                                str "Z"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "B Button"
                            ]
                            span [ _class "key-badge" ] [
                                str "X"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "X Button"
                            ]
                            span [ _class "key-badge" ] [
                                str "S"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "Y Button"
                            ]
                            span [ _class "key-badge" ] [
                                str "A"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "L Trigger"
                            ]
                            span [ _class "key-badge" ] [
                                str "Q"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "R Trigger"
                            ]
                            span [ _class "key-badge" ] [
                                str "W"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "Start"
                            ]
                            span [ _class "key-badge" ] [
                                str "Enter"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "D-Pad"
                            ]
                            span [ _class "key-badge" ] [
                                str "Arrow Keys"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "Main Stick"
                            ]
                            span [ _class "key-badge" ] [
                                str "TFGH"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "C-Stick"
                            ]
                            span [ _class "key-badge" ] [
                                str "IJKL"
                            ]
                        ]
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-section-title" ] [
                        str "Controls - Gamepad"
                    ]
                    div [ attr "style" "font-size:12px;color:var(--text-secondary);line-height:1.6;" ] [
                        str "GameCube controller layout is automatically mapped when a gamepad is connected."
                        br []
                        str "A-A, B-B, X-X, Y-Y, L/R-L/R Triggers, Start-Start/Z"
                        br []
                        str "Left Stick - Main Analog, Right Stick - C-Stick"
                        br []
                        br []
                        str "Press any button on your gamepad to connect."
                    ]
                    div [ _class "setting-item"; attr "style" "margin-top:12px;" ] [
                        span [ _class "setting-label" ] [
                            str "Rumble"
                        ]
                        div [ _class "toggle"; _id "toggle-rumble" ] [
                            div [ _class "toggle-knob" ] []
                        ]
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-section-title" ] [
                        str "Emulation"
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "Auto-save to IndexedDB"
                        ]
                        div [ _class "toggle active"; _id "toggle-autosave" ] [
                            div [ _class "toggle-knob" ] []
                        ]
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "Memory Card emulation"
                        ]
                        div [ _class "toggle active"; _id "toggle-memcard" ] [
                            div [ _class "toggle-knob" ] []
                        ]
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "CPU Clock Override"
                        ]
                        select [ _class "select"; _id "select-cpu" ] [
                            option [ attr "value" "1.0"; attr "selected" "" ] [
                                str "100% (Default)"
                            ]
                            option [ attr "value" "1.5" ] [
                                str "150%"
                            ]
                            option [ attr "value" "2.0" ] [
                                str "200%"
                            ]
                        ]
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-section-title" ] [
                        str "About"
                    ]
                    div [ attr "style" "font-size:12px;color:var(--text-secondary);line-height:1.6;" ] [
                        strong [] [
                            str "Aether GC"
                        ]
                        str "v1.0 - GameCube emulator shell."
                        br []
                        br []
                        strong [] [
                            str "Architecture:"
                        ]
                        br []
                        str "WASM Core: Emscripten-compiled Dolphin (or compatible)"
                        br []
                        str "Rendering: HTML5 Canvas 2D at 640x480"
                        br []
                        str "FS: Emscripten MEMFS + IndexedDB persistence"
                        br []
                        str "Input: Keyboard + Gamepad API"
                        br []
                        str "Memory Card: Virtual Slot A/B with .gci import/export"
                        br []
                        br []
                        strong [] [
                            str "Expected WASM Interface:"
                        ]
                        br []
                        str "Module.FS - POSIX virtual filesystem"
                        br []
                        str "Module._runFrame() - execute one frame"
                        br []
                        str "Module._loadROM(path, len) - load disc image"
                        br []
                        str "Module.FS.writeFile / readFile - memory card I/O"
                        br []
                        br []
                        str "Load"
                        code [] [
                            str "dolphin.wasm"
                        ]
                        str "+"
                        code [] [
                            str "dolphin.js"
                        ]
                        str "to begin."
                    ]
                ]
            ]
            script [] [
                    rawText ("""/* ============================================================
   AETHER GC - JavaScript Core
   Nintendo GameCube emulator shell with:
   - Emscripten Module pattern for Dolphin WASM core
   - 640x480 Canvas rendering
   - Memory card management (.gci import/export)
   - Keyboard + Gamepad API dual input
   - Virtual FS with IndexedDB persistence
   ============================================================ */

const State = {
  wasmLoaded: false, romLoaded: false, running: false, paused: false,
  audioEnabled: false, crtEnabled: false, smoothScaling: false, widescreen: false,
  autosaveEnabled: true, memcardEnabled: true, rumbleEnabled: false,
  frameCount: 0, lastFpsTime: 0, fps: 0,
  module: null, wasmMemory: null, coreFiles: { js: null, wasm: null },
  currentRomName: '', saveStates: {}, memcardSlots: [],
  pressedKeys: new Set(), gamepadIndex: null,
  keyMap: {
    'z':'A','x':'B','s':'X','a':'Y',
    'q':'L','w':'R','Enter':'Start',
    'ArrowUp':'up','ArrowDown':'down','ArrowLeft':'left','ArrowRight':'right',
    't':'stick_up','g':'stick_down','f':'stick_left','h':'stick_right',
    'i':'cstick_up','k':'cstick_down','j':'cstick_left','l':'cstick_right'
  },
  stickX: 128, stickY: 128, cstickX: 128, cstickY: 128
};

function log(msg, type='info') {
  const panel = document.getElementById('log-panel');
  const entry = document.createElement('div');
  entry.className = `log-entry ${type}`;
  entry.textContent = `[${new Date().toLocaleTimeString()}] ${msg}`;
  panel.appendChild(entry);
  panel.scrollTop = panel.scrollHeight;
  console.log(`[AetherGC] ${msg}`);
}
function setStatus(id, text, dotClass) {
  const el = document.getElementById(id);
  if (el) el.textContent = text;
  if (id==='core-status-text' && dotClass) {
    document.getElementById('core-status-dot').className = 'status-dot '+dotClass;
  }
}
function show(id) { document.getElementById(id)?.classList.remove('hidden'); }
function hide(id) { document.getElementById(id)?.classList.add('hidden'); }

const DB_NAME='AetherGC'; let db=null;
function openDB() {
  return new Promise((resolve,reject)=>{
    const req=indexedDB.open(DB_NAME,1);
    req.onerror=()=>reject(req.error);
    req.onsuccess=()=>{db=req.result;resolve(db);};
    req.onupgradeneeded=(e)=>{
      const d=e.target.result;
      if(!d.objectStoreNames.contains('saves')) d.createObjectStore('saves');
      if(!d.objectStoreNames.contains('savestates')) d.createObjectStore('savestates');
      if(!d.objectStoreNames.contains('memcard')) d.createObjectStore('memcard');
    };
  });
}
async function dbPut(store,key,data){
  if(!db)await openDB();
  return new Promise((resolve,reject)=>{
    const tx=db.transaction(store,'readwrite');
    const req=tx.objectStore(store).put(data,key);
    req.onsuccess=()=>resolve(); req.onerror=()=>reject(req.error);
  });
}
async function dbGet(store,key){
  if(!db)await openDB();
  return new Promise((resolve,reject)=>{
    const tx=db.transaction(store,'readonly');
    const req=tx.objectStore(store).get(key);
    req.onsuccess=()=>resolve(req.result); req.onerror=()=>reject(req.error);
  });
}

function downloadFile(data,filename,mime){
  const blob=new Blob([data],{type:mime||'application/octet-stream'});
  const url=URL.createObjectURL(blob);
  const a=document.createElement('a'); a.href=url; a.download=filename;
  document.body.appendChild(a); a.click(); document.body.removeChild(a);
  URL.revokeObjectURL(url); log(`Downloaded: ${filename}`,'success');
}

function setupDropZone(zoneId,inputId,handler){
  const zone=document.getElementById(zoneId);
  const input=document.getElementById(inputId);
  zone.addEventListener('click',()=>input.click());
  input.addEventListener('change',(e)=>{if(e.target.files.length)handler(e.target.files);});
  zone.addEventListener('dragover',(e)=>{e.preventDefault();zone.classList.add('drag-over');});
  zone.addEventListener('dragleave',()=>zone.classList.remove('drag-over'));
  zone.addEventListener('drop',(e)=>{
    e.preventDefault();zone.classList.remove('drag-over');
    if(e.dataTransfer.files.length)handler(e.dataTransfer.files);
  });
}

// WASM Core Loading
setupDropZone('wasm-drop-zone','wasm-input',async(files)=>{
  for(const file of files){
    const buf=await file.arrayBuffer();
    if(file.name.endsWith('.js')) State.coreFiles.js={name:file.name,data:buf};
    else if(file.name.endsWith('.wasm')) State.coreFiles.wasm={name:file.name,data:buf};
  }
  if(State.coreFiles.js&&State.coreFiles.wasm) await initEmulatorCore();
  else log('Need both .js glue and .wasm binary','warn');
});

async function initEmulatorCore(){
  log('Initializing GameCube core...');
  try{
    const jsBlob=new Blob([State.coreFiles.js.data],{type:'application/javascript'});
    const jsUrl=URL.createObjectURL(jsBlob);
    const wasmBlob=new Blob([State.coreFiles.wasm.data],{type:'application/wasm'});
    const wasmUrl=URL.createObjectURL(wasmBlob);
    
    window.Module=window.Module||{};
    Object.assign(window.Module,{
      canvas:document.getElementById('gc-canvas'),
      locateFile:(filename)=>{ if(filename.endsWith('.wasm'))return wasmUrl; return filename; },
      print:(msg)=>log(msg), printErr:(msg)=>log(msg,'warn'),
      onRuntimeInitialized:()=>{ onCoreInitialized(); }
    });
    await import(jsUrl);
    log('Emscripten glue loaded, waiting for runtime...');
  }catch(err){
    log(`Core init error: ${err.message}`,'error'); console.error(err);
  }
}

function onCoreInitialized(){
  State.module=window.Module;
  State.wasmLoaded=true;
  State.wasmMemory=State.module.HEAPU8;
  log('WASM GameCube core initialized!','success');
  setStatus('core-status-text','Core ready','ready');
  initFileSystem();
  hide('wasm-drop-zone'); show('rom-drop-zone');
  initMemoryCardUI();
}

function initFileSystem(){
  if(!State.module||!State.module.FS){ log('FS API not available, using virtual FS','warn'); createVirtualFS(); return; }
  try{
    State.module.FS.mkdir('/data'); State.module.FS.mkdir('/data/saves');
    State.module.FS.mkdir('/data/roms'); State.module.FS.mkdir('/data/states');
    State.module.FS.mkdir('/data/memcard');
    if(State.module.IDBFS){
      State.module.FS.mount(State.module.IDBFS,{},'/data');
      State.module.FS.syncfs(true,(err)=>{ if(err)log(`FS sync: ${err}`,'warn'); else log('Save data synced from IndexedDB'); });
    }
    log('Filesystem initialized');
  }catch(e){ log(`FS init: ${e.message}`,'warn'); createVirtualFS(); }
}
function createVirtualFS(){ State.vfs={'/data':{},'/data/saves':{},'/data/roms':{},'/data/states':{},'/data/memcard':{}}; }
function vfsWrite(path,data){
  if(State.module&&State.module.FS){ State.module.FS.writeFile(path,data);
    if(State.module.IDBFS&&State.autosaveEnabled) State.module.FS.syncfs(false,()=>{});
  }else{ State.vfs[path]=new Uint8Array(data); }
}
function vfsRead(path){
  if(State.module&&State.module.FS) return State.module.FS.readFile(path);
  return State.vfs[path]||null;
}
function vfsExists(path){
  if(State.module&&State.module.FS){ try{return State.module.FS.analyzePath(path).exists;}catch{return false;} }
  return path in State.vfs;
}

// ROM Loading (ISO/GCM/DOL)
setupDropZone('rom-drop-zone','rom-input',async(files)=>{
  const file=files[0];
  const validExts=['.iso','.gcm','.dol'];
  if(!validExts.some(ext=>file.name.toLowerCase().endsWith(ext))){log('Only .iso/.gcm/.dol files','warn');return;}
  await loadRomFile(file);
});
document.getElementById('btn-load-rom')?.addEventListener('click',()=>document.getElementById('rom-input')?.click());

async function loadRomFile(file){
  try{
    const buf=await file.arrayBuffer();
    const romData=new Uint8Array(buf);
    State.currentRomName=file.name;
    const romPath=`/data/roms/${file.name}`;
    vfsWrite(romPath,romData);
    log(`Disc loaded: ${file.name} (${(romData.length/1024/1024).toFixed(0)} MB)`);
    
    if(State.module&&State.module.uploadRom){
      await new Promise((resolve,reject)=>{
        State.module.uploadRom(new File([romData],file.name),(err)=>{if(err)reject(err);else resolve();});
      });
    }
    if(State.module&&State.module.loadGame) State.module.loadGame(romPath);
    if(State.module&&State.module._loadROM) State.module._loadROM(romPath,romData.length);
    
    State.romLoaded=true;
    setStatus('rom-status-text',`Disc: ${file.name}`);
    hide('rom-drop-zone'); show('emulator-viewport');
    log('Disc ready - press Play to start','success');
  }catch(err){ log(`Disc load error: ${err.message}`,'error'); }
}

document.getElementById('btn-eject')?.addEventListener('click',()=>{
  if(State.module&&State.module._eject) State.module._eject();
  State.romLoaded=false;
  hide('emulator-viewport'); show('rom-drop-zone');
  setStatus('rom-status-text','No disc loaded');
  log('Disc ejected');
});

// Memory Card Management
function initMemoryCardUI(){
  const grid=document.getElementById('mc-grid');
  grid.innerHTML='';
  State.memcardSlots=[];
  for(let i=0;i<16;i++){
    const slot=document.createElement('div');
    slot.className='mc-slot';
    slot.innerHTML='<div class="mc-slot-number">Block '+(i+1)+'</div><div class="mc-slot-status empty">Empty</div>';
    slot.addEventListener('click',()=>selectMemcardSlot(i));
    grid.appendChild(slot);
    State.memcardSlots.push({occupied:false,data:null,name:''});
  }
}

async function selectMemcardSlot(index){
  const slot=State.memcardSlots[index];
  if(slot.occupied){
    if(confirm('Block '+(index+1)+': '+slot.name+'\n\nExport this save as .gci?')){
      downloadFile(slot.data,(slot.name||'save'+index)+'.gci');
    }
  }else{
    log('Memory Card Block '+(index+1)+': empty');
  }
}

document.getElementById('btn-import-gci')?.addEventListener('click',()=>document.getElementById('gci-input')?.click());
document.getElementById('gci-input')?.addEventListener('change',async(e)=>{
  const file=e.target.files[0]; if(!file)return;
  try{
    const buf=await file.arrayBuffer();
    const gciData=new Uint8Array(buf);
    const gciPath='/data/memcard/'+file.name;
    vfsWrite(gciPath,gciData);
    const emptyIdx=State.memcardSlots.findIndex(s=>!s.occupied);
    if(emptyIdx>=0){
      State.memcardSlots[emptyIdx]={occupied:true,data:gciData,name:file.name};
      const gridSlots=document.querySelectorAll('.mc-slot');
      const statusEl=gridSlots[emptyIdx]?.querySelector('.mc-slot-status');
      if(statusEl){ statusEl.textContent=file.name.substring(0,12); statusEl.className='mc-slot-status occupied'; }
    }
    log('GCI imported: '+file.name+' to block '+(emptyIdx+1),'success');
  }catch(err){ log('GCI import error: '+err.message,'error'); }
});

document.getElementById('btn-export-gci')?.addEventListener('click',async()=>{
  const occupied=State.memcardSlots.filter((s,i)=>{s.index=i;return s.occupied;});
  if(!occupied.length){ log('No saves to export','warn'); return; }
  for(const slot of occupied){
    if(slot.data) downloadFile(slot.data,(slot.name||'save'+slot.index)+'.gci');
  }
  log('Exported '+occupied.length+' saves','success');
});

document.getElementById('btn-mc')?.addEventListener('click',()=>{
  document.getElementById('mc-panel')?.classList.toggle('hidden');
});

// Save States
document.getElementById('btn-save-state')?.addEventListener('click',async()=>{
  if(!State.romLoaded){log('Load a disc first','warn');return;}
  try{
    const slot=document.getElementById('state-slot')?.value||'1';
    let stateData=null;
    if(State.module&&State.module.saveStateSlot) stateData=State.module.saveStateSlot(parseInt(slot),0);
    else if(State.module&&State.module.saveState) stateData=State.module.saveState(parseInt(slot));
    if(stateData){
      State.saveStates[slot]=stateData;
      await dbPut('savestates',State.currentRomName+'_slot'+slot,stateData);
      log('Save state saved to slot '+slot,'success');
    }else{
      const snapshot=serializeEmulatorState();
      State.saveStates[slot]=snapshot;
      await dbPut('savestates',State.currentRomName+'_slot'+slot,snapshot);
      log('Save state '+slot+' stored (memory)','success');
    }
  }catch(err){ log('Save state error: '+err.message,'error'); }
});

document.getElementById('btn-load-state')?.addEventListener('click',async()=>{
  if(!State.romLoaded){log('Load a disc first','warn');return;}
  try{
    const slot=document.getElementById('state-slot')?.value||'1';
    let stateData=State.saveStates[slot];
    if(!stateData) stateData=await dbGet('savestates',State.currentRomName+'_slot'+slot);
    if(!stateData){log('No save state in slot '+slot,'warn');return;}
    if(State.module&&State.module.loadStateSlot){ State.module.loadStateSlot(parseInt(slot),0); log('State loaded from slot '+slot,'success'); }
    else if(State.module&&State.module.loadState){ State.module.loadState(parseInt(slot)); log('State loaded from slot '+slot,'success'); }
    else log('State loading not supported','warn');
  }catch(err){ log('Load state error: '+err.message,'error'); }
});

function serializeEmulatorState(){
  if(!State.module||!State.wasmMemory)return null;
  const snapshot=new Uint8Array(State.wasmMemory.length);
  snapshot.set(State.wasmMemory); return snapshot;
}

// Emulation Controls
document.getElementById('btn-play-pause')?.addEventListener('click',()=>{
  if(!State.romLoaded){log('Load a disc first','warn');return;}
  State.paused=!State.paused;
  const btn=document.getElementById('btn-play-pause');
  if(State.paused){ btn.textContent='\u25B6 Play'; State.running=false;
    if(State.module&&State.module.pauseGame)State.module.pauseGame(); log('Paused'); }
  else{ btn.textContent='\u23F8 Pause'; State.running=true;
    if(State.module&&State.module.resumeGame)State.module.resumeGame();
    setStatus('core-status-dot','','active'); startLoop(); log('Started'); }
});
document.getElementById('btn-reset')?.addEventListener('click',()=>{
  if(!State.romLoaded)return;
  if(State.module&&State.module.quickReload){State.module.quickReload();log('Reset');}
  else log('Reset not supported','warn');
});

function startLoop(){
  if(!State.running)return;
  function frame(){
    if(!State.running)return;
    try{ /* Core handles rendering */ }catch(e){console.error(e);}
    State.frameCount++;
    const now=performance.now();
    if(now-State.lastFpsTime>=1000){
      State.fps=State.frameCount; State.frameCount=0; State.lastFpsTime=now;
      document.getElementById('fps-counter').textContent=State.fps+' fps';
    }
    requestAnimationFrame(frame);
  }
  State.lastFpsTime=performance.now(); requestAnimationFrame(frame);
}

// Keyboard Input (GameCube mapping)
document.addEventListener('keydown',(e)=>{
  const key=e.key.length===1?e.key.toLowerCase():e.key;
  if(State.pressedKeys.has(key))return; State.pressedKeys.add(key);
  const gcBtn=State.keyMap[key]; if(!gcBtn)return; e.preventDefault();
  if(State.module&&State.module.buttonPress)State.module.buttonPress(gcBtn);
  if(gcBtn==='stick_up') State.stickY=0; if(gcBtn==='stick_down') State.stickY=255;
  if(gcBtn==='stick_left') State.stickX=0; if(gcBtn==='stick_right') State.stickX=255;
  if(gcBtn==='cstick_up') State.cstickY=0; if(gcBtn==='cstick_down') State.cstickY=255;
  if(gcBtn==='cstick_left') State.cstickX=0; if(gcBtn==='cstick_right') State.cstickX=255;
  if(State.module&&State.module.setStick) State.module.setStick(State.stickX,State.stickY);
  if(State.module&&State.module.setCStick) State.module.setCStick(State.cstickX,State.cstickY);
});
document.addEventListener('keyup',(e)=>{
  const key=e.key.length===1?e.key.toLowerCase():e.key;
  State.pressedKeys.delete(key);
  const gcBtn=State.keyMap[key]; if(!gcBtn)return; e.preventDefault();
  if(State.module&&State.module.buttonUnpress)State.module.buttonUnpress(gcBtn);
  if(gcBtn==='stick_up'||gcBtn==='stick_down') State.stickY=128;
  if(gcBtn==='stick_left'||gcBtn==='stick_right') State.stickX=128;
  if(gcBtn==='cstick_up'||gcBtn==='cstick_down') State.cstickY=128;
  if(gcBtn==='cstick_left'||gcBtn==='cstick_right') State.cstickX=128;
  if(State.module&&State.module.setStick) State.module.setStick(State.stickX,State.stickY);
  if(State.module&&State.module.setCStick) State.module.setCStick(State.cstickX,State.cstickY);
});
window.addEventListener('keydown',(e)=>{
  if(['ArrowUp','ArrowDown','ArrowLeft','ArrowRight',' '].includes(e.key)){if(State.running)e.preventDefault();}
});

// Gamepad API
function pollGamepad(){
  const pads=navigator.getGamepads?navigator.getGamepads():[];
  let connected=false;
  for(const pad of pads){
    if(pad&&pad.connected){ connected=true;
      if(State.gamepadIndex===null){ State.gamepadIndex=pad.index;
        document.getElementById('gamepad-status').textContent=pad.id.substring(0,24);
        log('Gamepad connected: '+pad.id.substring(0,30),'success'); }
      if(State.module){
        if(pad.buttons[0]?.pressed) State.module.buttonPress('A'); else State.module.buttonUnpress('A');
        if(pad.buttons[1]?.pressed) State.module.buttonPress('B'); else State.module.buttonUnpress('B');
        if(pad.buttons[2]?.pressed) State.module.buttonPress('X'); else State.module.buttonUnpress('X');
        if(pad.buttons[3]?.pressed) State.module.buttonPress('Y'); else State.module.buttonUnpress('Y');
        if(pad.buttons[4]?.pressed) State.module.buttonPress('L'); else State.module.buttonUnpress('L');
        if(pad.buttons[5]?.pressed) State.module.buttonPress('R'); else State.module.buttonUnpress('R');
        if(pad.buttons[6]?.pressed) State.module.buttonPress('ZL'); else State.module.buttonUnpress('ZL');
        if(pad.buttons[7]?.pressed) State.module.buttonPress('ZR'); else State.module.buttonUnpress('ZR');
        if(pad.buttons[8]?.pressed||pad.buttons[9]?.pressed) State.module.buttonPress('Start'); else State.module.buttonUnpress('Start');
        const lx=Math.floor((pad.axes[0]+1)*127.5);
        const ly=Math.floor((pad.axes[1]+1)*127.5);
        const rx=Math.floor(((pad.axes[2]||0)+1)*127.5);
        const ry=Math.floor(((pad.axes[3]||0)+1)*127.5);
        if(State.module.setStick) State.module.setStick(lx,ly);
        if(State.module.setCStick) State.module.setCStick(rx,ry);
        if(pad.buttons[12]?.pressed) State.module.buttonPress('up'); else State.module.buttonUnpress('up');
        if(pad.buttons[13]?.pressed) State.module.buttonPress('down'); else State.module.buttonUnpress('down');
        if(pad.buttons[14]?.pressed) State.module.buttonPress('left'); else State.module.buttonUnpress('left');
        if(pad.buttons[15]?.pressed) State.module.buttonPress('right'); else State.module.buttonUnpress('right');
      }
      break;
    }
  }
  if(!connected&&State.gamepadIndex!==null){
    State.gamepadIndex=null;
    document.getElementById('gamepad-status').textContent='No gamepad';
  }
  requestAnimationFrame(pollGamepad);
}
window.addEventListener('gamepadconnected',(e)=>{ log('Gamepad: '+e.gamepad.id,'success'); });
window.addEventListener('gamepaddisconnected',()=>{ State.gamepadIndex=null; document.getElementById('gamepad-status').textContent='No gamepad'; });
pollGamepad();

// Display Controls
document.getElementById('btn-fullscreen')?.addEventListener('click',()=>{
  const vp=document.getElementById('emulator-viewport');
  if(document.fullscreenElement)document.exitFullscreen(); else vp?.requestFullscreen();
});
document.getElementById('btn-crt')?.addEventListener('click',()=>{
  State.crtEnabled=!State.crtEnabled;
  document.getElementById('crt-overlay')?.classList.toggle('active',State.crtEnabled);
  const btn=document.getElementById('btn-crt');
  btn.textContent=State.crtEnabled?'CRT On':'CRT Off';
  btn.classList.toggle('btn-primary',State.crtEnabled);
});
document.getElementById('select-scale')?.addEventListener('change',(e)=>{
  const scale=parseInt(e.target.value);
  const c=document.getElementById('gc-canvas');
  c.style.width=(640*scale)+'px'; c.style.height=(480*scale)+'px';
});
document.getElementById('toggle-widescreen')?.addEventListener('click',function(){
  this.classList.toggle('active');
  State.widescreen=this.classList.contains('active');
  const c=document.getElementById('gc-canvas');
  if(State.widescreen){ c.style.width='1280px'; c.style.height='720px'; }
  else{ c.style.width='640px'; c.style.height='480px'; }
});
document.getElementById('btn-audio')?.addEventListener('click',()=>{
  State.audioEnabled=!State.audioEnabled;
  const btn=document.getElementById('btn-audio');
  btn.textContent=State.audioEnabled?'Audio On':'Audio Off';
  btn.classList.toggle('btn-primary',State.audioEnabled);
  if(State.module&&State.module.resumeAudio&&State.audioEnabled)State.module.resumeAudio();
  if(State.module&&State.module.pauseAudio&&!State.audioEnabled)State.module.pauseAudio();
});

// Settings Panel
document.getElementById('btn-settings')?.addEventListener('click',()=>{
  document.getElementById('settings-panel')?.classList.add('open');
  document.getElementById('settings-overlay')?.classList.add('open');
});
document.getElementById('settings-overlay')?.addEventListener('click',()=>{
  document.getElementById('settings-panel')?.classList.remove('open');
  document.getElementById('settings-overlay')?.classList.remove('open');
});
document.querySelectorAll('.toggle').forEach(t=>{
  t.addEventListener('click',()=>{
    t.classList.toggle('active');
    if(t.id==='toggle-crt'){ State.crtEnabled=t.classList.contains('active');
      document.getElementById('crt-overlay')?.classList.toggle('active',State.crtEnabled); }
    else if(t.id==='toggle-autosave') State.autosaveEnabled=t.classList.contains('active');
    else if(t.id==='toggle-memcard') State.memcardEnabled=t.classList.contains('active');
    else if(t.id==='toggle-rumble') State.rumbleEnabled=t.classList.contains('active');
    else if(t.id==='toggle-smooth'){
      State.smoothScaling=t.classList.contains('active');
      document.getElementById('gc-canvas').style.imageRendering=State.smoothScaling?'auto':'pixelated';
    }
  });
});
document.getElementById('select-cpu')?.addEventListener('change',(e)=>{
  const mult=parseFloat(e.target.value);
  if(State.module&&State.module.setClockOverride) State.module.setClockOverride(mult);
  log('CPU clock: '+(mult*100)+'%');
});

// Help
document.getElementById('btn-help')?.addEventListener('click',()=>{
  alert('Aether GC - Quick Help\n\n1. Load dolphin.wasm + dolphin.js (Emscripten files)\n2. Drop a .iso, .gcm, or .dol file\n3. Keyboard: Z=A, X=B, S=X, A=Y, Q=L, W=R, Enter=Start\n   TFGH=Main Stick, IJKL=C-Stick, Arrows=D-Pad\n4. Gamepad: Automatically mapped when connected\n5. Memory Card: Use Import/Export .gci buttons\n6. Save states: Save/Load with slot selector\n\nNote: Dolphin WASM core availability is limited.\nThis shell supports any Emscripten GC emulator core.');
});

// Init
(async function init(){
  await openDB();
  initMemoryCardUI();
  log('Aether GC initialized');
  log('Drop dolphin.wasm + dolphin.js to begin');
  log('Supports .iso / .gcm / .dol disc images');
})();
window.AetherGC=State;""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
