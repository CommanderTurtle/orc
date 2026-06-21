module ConvertedFiles.Wasm.Ds.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Aether NDS - Nintendo DS Emulator"
            ]
            style [] [
                    rawText ("""/* ============================================================
   AETHER NDS EMULATOR
   A standalone Nintendo DS emulator shell
   Supports DeSmuME/melonDS WebAssembly core integration
   Dual-screen layout with touchscreen simulation
   ============================================================ */
*, *::before, *::after { margin: 0; padding: 0; box-sizing: border-box; }
:root {
  --bg-primary: #0a0e1a; --bg-secondary: #111827; --bg-card: rgba(17,24,39,0.85);
  --accent: #3b82f6; --accent-glow: rgba(59,130,246,0.4); --accent-secondary: #ec4899;
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
.particle:nth-child(1){left:8%;animation-duration:16s;animation-delay:0s;width:3px;height:3px;background:var(--accent-secondary);}
.particle:nth-child(2){left:18%;animation-duration:21s;animation-delay:3s;}
.particle:nth-child(3){left:28%;animation-duration:17s;animation-delay:1s;width:4px;height:4px;}
.particle:nth-child(4){left:38%;animation-duration:23s;animation-delay:5s;background:var(--accent-secondary);}
.particle:nth-child(5){left:48%;animation-duration:15s;animation-delay:2s;width:3px;height:3px;}
.particle:nth-child(6){left:58%;animation-duration:19s;animation-delay:4s;}
.particle:nth-child(7){left:68%;animation-duration:22s;animation-delay:1s;width:3px;height:3px;background:var(--accent-secondary);}
.particle:nth-child(8){left:78%;animation-duration:18s;animation-delay:6s;}
.particle:nth-child(9){left:88%;animation-duration:24s;animation-delay:3s;width:4px;height:4px;}
.particle:nth-child(10){left:13%;animation-duration:14s;animation-delay:2s;}
.particle:nth-child(11){left:33%;animation-duration:20s;animation-delay:7s;width:3px;height:3px;background:var(--accent-secondary);}
.particle:nth-child(12){left:53%;animation-duration:16s;animation-delay:4s;}
.particle:nth-child(13){left:73%;animation-duration:25s;animation-delay:0s;}
.particle:nth-child(14){left:93%;animation-duration:13s;animation-delay:5s;background:var(--accent-secondary);}
.particle:nth-child(15){left:3%;animation-duration:19s;animation-delay:3s;width:3px;height:3px;}

.grid-bg { position: fixed; inset: 0; z-index: 0; pointer-events: none;
  background-image: linear-gradient(rgba(59,130,246,0.025) 1px, transparent 1px),
    linear-gradient(90deg, rgba(59,130,246,0.025) 1px, transparent 1px);
  background-size: 40px 40px; }

.app { position: relative; z-index: 1; min-height: 100vh; display: flex; flex-direction: column; }

.header { display: flex; align-items: center; justify-content: space-between;
  padding: 16px 24px; background: var(--glass); backdrop-filter: blur(20px);
  border-bottom: 1px solid var(--glass-border); position: sticky; top: 0; z-index: 100; }
.header-left { display: flex; align-items: center; gap: 12px; }
.logo-icon { width: 36px; height: 36px; border-radius: 10px;
  background: linear-gradient(135deg, var(--accent), var(--accent-secondary));
  display: flex; align-items: center; justify-content: center;
  font-size: 18px; font-weight: 800; color: white; box-shadow: 0 0 20px var(--accent-glow); }
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
.btn-primary:hover { background: #2563eb; }
.btn-small { padding: 6px 12px; font-size: 12px; }

.main { flex: 1; display: flex; flex-direction: column; align-items: center; padding: 20px; gap: 16px; }

.status-bar { width: 100%; max-width: 720px; display: flex; align-items: center;
  justify-content: space-between; padding: 10px 18px; background: var(--glass);
  backdrop-filter: blur(12px); border-radius: 10px; border: 1px solid var(--glass-border);
  font-size: 12px; color: var(--text-secondary); }
.status-item { display: flex; align-items: center; gap: 6px; }
.status-dot { width: 8px; height: 8px; border-radius: 50%; background: var(--danger); transition: background 0.3s; }
.status-dot.ready { background: var(--success); box-shadow: 0 0 8px rgba(16,185,129,0.5); }
.status-dot.active { background: var(--accent); box-shadow: 0 0 8px var(--accent-glow); animation: pulse 2s infinite; }
@keyframes pulse { 0%,100% { opacity: 1; } 50% { opacity: 0.5; } }

.screen-container { display: flex; gap: 8px; align-items: center; position: relative;
  border-radius: 16px; overflow: hidden;
  box-shadow: 0 20px 60px rgba(0,0,0,0.5), 0 0 40px rgba(59,130,246,0.1);
  border: 1px solid var(--glass-border); background: #000; }
.screen-container.layout-vertical { flex-direction: column; }
.screen-container.layout-horizontal { flex-direction: row; }
.screen-container.layout-top-only .nds-screen-bottom { display: none; }
.nds-screen { display: block; image-rendering: pixelated; image-rendering: crisp-edges; background: #0a0a0a; }
.nds-screen-top { width: 512px; height: 384px; }
.nds-screen-bottom { width: 512px; height: 384px; cursor: crosshair; }

.touch-indicator { position: absolute; width: 20px; height: 20px; border-radius: 50%;
  border: 2px solid var(--accent); background: rgba(59,130,246,0.3);
  pointer-events: none; transform: translate(-50%,-50%); display: none; z-index: 20; }
.touch-indicator.active { display: block; }

.crt-overlay { position: absolute; inset: 0; pointer-events: none; z-index: 10;
  background: repeating-linear-gradient(0deg, rgba(0,0,0,0.1) 0px, rgba(0,0,0,0.1) 1px, transparent 1px, transparent 3px);
  opacity: 0; transition: opacity 0.3s; }
.crt-overlay.active { opacity: 1; }

.drop-zone { width: 100%; max-width: 540px; padding: 36px 24px; border: 2px dashed var(--border);
  border-radius: 16px; text-align: center; transition: all 0.3s ease;
  background: var(--glass); backdrop-filter: blur(8px); }
.drop-zone.drag-over { border-color: var(--accent); background: rgba(59,130,246,0.1);
  transform: scale(1.02); box-shadow: 0 0 30px var(--accent-glow); }
.drop-zone-icon { font-size: 44px; margin-bottom: 10px; opacity: 0.5; }
.drop-zone-title { font-size: 16px; font-weight: 600; margin-bottom: 6px; }
.drop-zone-hint { font-size: 12px; color: var(--text-secondary); }
.drop-zone-input { display: none; }

.control-bar { width: 100%; max-width: 720px; display: flex; flex-wrap: wrap;
  align-items: center; gap: 8px; padding: 12px 18px; background: var(--glass);
  backdrop-filter: blur(12px); border-radius: 12px; border: 1px solid var(--glass-border); }
.control-group { display: flex; align-items: center; gap: 6px; padding: 0 8px;
  border-right: 1px solid var(--border); }
.control-group:last-child { border-right: none; }
.control-label { font-size: 11px; color: var(--text-secondary); text-transform: uppercase;
  letter-spacing: 0.5px; margin-right: 4px; }

.settings-panel { position: fixed; top: 0; right: -400px; width: 380px; height: 100vh;
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

.log-panel { width: 100%; max-width: 720px; max-height: 120px; overflow-y: auto;
  padding: 12px 16px; background: var(--glass); backdrop-filter: blur(8px);
  border-radius: 10px; border: 1px solid var(--glass-border);
  font-family: 'Consolas', 'Monaco', monospace; font-size: 11px; }
.log-entry { padding: 2px 0; border-bottom: 1px solid rgba(255,255,255,0.03); }
.log-entry.info { color: var(--text-secondary); }
.log-entry.success { color: var(--success); }
.log-entry.warn { color: var(--warning); }
.log-entry.error { color: var(--danger); }

@media (max-width: 1100px) {
  .screen-container.layout-horizontal { flex-direction: column; }
  .nds-screen-top, .nds-screen-bottom { width: 384px; height: 288px; }
}
@media (max-width: 768px) {
  .nds-screen-top, .nds-screen-bottom { width: 320px; height: 240px; }
  .control-bar { justify-content: center; }
  .settings-panel { width: 100%; right: -100%; }
}
@media (max-width: 480px) {
  .nds-screen-top, .nds-screen-bottom { width: 256px; height: 192px; }
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
                            str "DS"
                        ]
                        div [] [
                            div [ _class "header-title" ] [
                                str "Aether NDS"
                            ]
                            div [ _class "header-subtitle" ] [
                                str "Nintendo DS Emulator"
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
                                str "No ROM loaded"
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
                                str "desmond.wasm"
                            ]
                            str "+"
                            b [] [
                                str "desmond.js"
                            ]
                            str "here or click to browse"
                            br []
                            small [] [
                                str "Emscripten-compiled DeSmuME WebAssembly files"
                            ]
                        ]
                        input [ _type "file"; _class "drop-zone-input"; _id "wasm-input"; attr "accept" ".wasm,.js"; attr "multiple" "" ]
                    ]
                    div [ _class "drop-zone hidden"; _id "rom-drop-zone" ] [
                        div [ _class "drop-zone-icon" ] [
                            str "🎮"
                        ]
                        div [ _class "drop-zone-title" ] [
                            str "Load DS ROM"
                        ]
                        div [ _class "drop-zone-hint" ] [
                            str "Drop a"
                            b [] [
                                str ".nds"
                            ]
                            str "file here or click to browse"
                            br []
                            small [] [
                                str "Supports .nds ROM files"
                            ]
                        ]
                        input [ _type "file"; _class "drop-zone-input"; _id "rom-input"; attr "accept" ".nds" ]
                    ]
                    div [ _class "screen-container layout-vertical hidden"; _id "screen-container" ] [
                        canvas [ _class "nds-screen nds-screen-top"; _id "screen-top"; attr "width" "256"; attr "height" "192" ] []
                        canvas [ _class "nds-screen nds-screen-bottom"; _id "screen-bottom"; attr "width" "256"; attr "height" "192" ] []
                        div [ _class "touch-indicator"; _id "touch-indicator" ] []
                        div [ _class "crt-overlay"; _id "crt-overlay" ] []
                    ]
                    div [ _class "control-bar"; _id "control-bar" ] [
                        div [ _class "control-group" ] [
                            span [ _class "control-label" ] [
                                str "File"
                            ]
                            button [ _class "btn btn-small"; _id "btn-load-rom" ] [
                                str "Load ROM"
                            ]
                            button [ _class "btn btn-small"; _id "btn-import-save" ] [
                                str "Import Save"
                            ]
                            button [ _class "btn btn-small"; _id "btn-export-save" ] [
                                str "Export Save"
                            ]
                            input [ _type "file"; _class "drop-zone-input"; _id "save-input"; attr "accept" ".sav,.dsv" ]
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
                                option [ attr "value" "4" ] [
                                    str "Slot 4"
                                ]
                                option [ attr "value" "5" ] [
                                    str "Slot 5"
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
                                str "Layout"
                            ]
                            button [ _class "btn btn-small"; _id "btn-layout" ] [
                                str "Vertical"
                            ]
                            button [ _class "btn btn-small"; _id "btn-fullscreen" ] [
                                str "Fullscreen"
                            ]
                            button [ _class "btn btn-small"; _id "btn-crt" ] [
                                str "CRT Off"
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
                            str "Welcome to Aether NDS. Load an emulator core to begin."
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
                            str "Screen Layout"
                        ]
                        select [ _class "select"; _id "select-layout" ] [
                            option [ attr "value" "vertical"; attr "selected" "" ] [
                                str "Vertical (stacked)"
                            ]
                            option [ attr "value" "horizontal" ] [
                                str "Horizontal (side-by-side)"
                            ]
                            option [ attr "value" "top-only" ] [
                                str "Top screen only"
                            ]
                        ]
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
                                str "1x (256x192 each)"
                            ]
                            option [ attr "value" "2"; attr "selected" "" ] [
                                str "2x (512x384 each)"
                            ]
                            option [ attr "value" "3" ] [
                                str "3x"
                            ]
                        ]
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-section-title" ] [
                        str "Controls"
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
                                str "L Shoulder"
                            ]
                            span [ _class "key-badge" ] [
                                str "Q"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "R Shoulder"
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
                                str "Select"
                            ]
                            span [ _class "key-badge" ] [
                                str "Space"
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
                    ]
                    div [ attr "style" "margin-top:12px;font-size:11px;color:var(--text-secondary);" ] [
                        str "Touchscreen: Click and drag on the bottom screen to simulate stylus input."
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-section-title" ] [
                        str "Emulation"
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "Auto-save SRAM to IndexedDB"
                        ]
                        div [ _class "toggle active"; _id "toggle-autosave" ] [
                            div [ _class "toggle-knob" ] []
                        ]
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-section-title" ] [
                        str "About"
                    ]
                    div [ attr "style" "font-size:12px;color:var(--text-secondary);line-height:1.6;" ] [
                        strong [] [
                            str "Aether NDS"
                        ]
                        str "v1.0 - Nintendo DS emulator shell."
                        br []
                        str "Built for DeSmuME/melonDS WebAssembly cores."
                        br []
                        br []
                        strong [] [
                            str "Architecture:"
                        ]
                        br []
                        str "- WASM core: Emscripten-compiled DeSmuME or melonDS"
                        br []
                        str "- Dual screen: HTML5 Canvas x2 (top + bottom)"
                        br []
                        str "- Touch: Mouse event simulation on bottom screen"
                        br []
                        str "- FS: Emscripten MEMFS + IndexedDB persistence"
                        br []
                        br []
                        str "Load"
                        code [] [
                            str "desmond.wasm"
                        ]
                        str "+"
                        code [] [
                            str "desmond.js"
                        ]
                        str "to begin."
                    ]
                ]
            ]
            script [] [
                    rawText ("""/* ============================================================
   AETHER NDS - JavaScript Core
   Implements dual-screen DS emulation with:
   - Two HTML5 Canvas elements (top: 256x192, bottom: 256x192)
   - Touchscreen simulation via mouse events on bottom screen
   - Emscripten Module pattern for WASM core loading
   - Virtual FS for ROM/save management
   - IndexedDB persistence for saves
   - Screen layout toggle (vertical/horizontal/top-only)
   ============================================================ */

const State = {
  wasmLoaded: false, romLoaded: false, running: false, paused: false,
  audioEnabled: false, crtEnabled: false, smoothScaling: false,
  autosaveEnabled: true, frameCount: 0, lastFpsTime: 0, fps: 0,
  module: null, wasmMemory: null, coreFiles: { js: null, wasm: null },
  layoutMode: 'vertical', currentRomName: '', saveStates: {},
  pressedKeys: new Set(), touchActive: false, touchX: 0, touchY: 0,
  keyMap: {
    'z':'A','x':'B','a':'Y','s':'X','q':'L','w':'R',
    'Enter':'Start',' ':'Select',
    'ArrowUp':'up','ArrowDown':'down','ArrowLeft':'left','ArrowRight':'right'
  }
};

function log(msg, type='info') {
  const panel = document.getElementById('log-panel');
  const entry = document.createElement('div');
  entry.className = 'log-entry ' + type;
  entry.textContent = '[' + new Date().toLocaleTimeString() + '] ' + msg;
  panel.appendChild(entry);
  panel.scrollTop = panel.scrollHeight;
  console.log('[AetherNDS] ' + msg);
}
function setStatus(id, text, dotClass) {
  const el = document.getElementById(id);
  if (el) el.textContent = text;
  if (id==='core-status-text' && dotClass) {
    document.getElementById('core-status-dot').className = 'status-dot ' + dotClass;
  }
}
function show(id) { document.getElementById(id)?.classList.remove('hidden'); }
function hide(id) { document.getElementById(id)?.classList.add('hidden'); }

const DB_NAME='AetherNDS'; let db=null;
function openDB() {
  return new Promise((resolve,reject)=>{
    const req=indexedDB.open(DB_NAME,1);
    req.onerror=()=>reject(req.error);
    req.onsuccess=()=>{db=req.result;resolve(db);};
    req.onupgradeneeded=(e)=>{
      const d=e.target.result;
      if(!d.objectStoreNames.contains('saves')) d.createObjectStore('saves');
      if(!d.objectStoreNames.contains('savestates')) d.createObjectStore('savestates');
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
  URL.revokeObjectURL(url); log('Downloaded: ' + filename,'success');
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
  log('Initializing NDS core...');
  try{
    const jsBlob=new Blob([State.coreFiles.js.data],{type:'application/javascript'});
    const jsUrl=URL.createObjectURL(jsBlob);
    const wasmBlob=new Blob([State.coreFiles.wasm.data],{type:'application/wasm'});
    const wasmUrl=URL.createObjectURL(wasmBlob);
    
    window.Module=window.Module||{};
    Object.assign(window.Module,{
      canvas:document.getElementById('screen-top'),
      canvas2:document.getElementById('screen-bottom'),
      locateFile:(filename)=>{ if(filename.endsWith('.wasm'))return wasmUrl; return filename; },
      print:(msg)=>log(msg), printErr:(msg)=>log(msg,'warn'),
      onRuntimeInitialized:()=>{ onCoreInitialized(); }
    });
    await import(jsUrl);
    log('Emscripten glue loaded, waiting for runtime...');
  }catch(err){
    log('Core init error: ' + err.message,'error'); console.error(err);
  }
}

function onCoreInitialized(){
  State.module=window.Module;
  State.wasmLoaded=true;
  State.wasmMemory=State.module.HEAPU8;
  log('WASM NDS core initialized!','success');
  setStatus('core-status-text','Core ready','ready');
  initFileSystem();
  hide('wasm-drop-zone'); show('rom-drop-zone');
}

function initFileSystem(){
  if(!State.module||!State.module.FS){ log('FS API not available, using virtual FS','warn'); createVirtualFS(); return; }
  try{
    State.module.FS.mkdir('/data'); State.module.FS.mkdir('/data/saves');
    State.module.FS.mkdir('/data/roms'); State.module.FS.mkdir('/data/states');
    if(State.module.IDBFS){
      State.module.FS.mount(State.module.IDBFS,{},'/data');
      State.module.FS.syncfs(true,(err)=>{ if(err)log('FS sync: ' + err,'warn'); else log('Save data synced from IndexedDB'); });
    }
    log('Filesystem initialized');
  }catch(e){ log('FS init: ' + e.message,'warn'); createVirtualFS(); }
}
function createVirtualFS(){ State.vfs={'/data':{},'/data/saves':{},'/data/roms':{},'/data/states':{}}; }
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

setupDropZone('rom-drop-zone','rom-input',async(files)=>{
  const file=files[0]; if(!file.name.endsWith('.nds')){log('Only .nds files supported','warn');return;}
  await loadRomFile(file);
});
document.getElementById('btn-load-rom')?.addEventListener('click',()=>document.getElementById('rom-input')?.click());

async function loadRomFile(file){
  try{
    const buf=await file.arrayBuffer();
    const romData=new Uint8Array(buf);
    State.currentRomName=file.name;
    const romPath='/data/roms/' + file.name;
    vfsWrite(romPath,romData);
    log('ROM loaded: ' + file.name + ' (' + (romData.length/1024/1024).toFixed(2) + ' MB)');
    
    if(State.module&&State.module.uploadRom){
      await new Promise((resolve,reject)=>{
        State.module.uploadRom(new File([romData],file.name),(err)=>{if(err)reject(err);else resolve();});
      });
    }
    if(State.module&&State.module.loadGame) State.module.loadGame(romPath);
    
    State.romLoaded=true;
    setStatus('rom-status-text','ROM: ' + file.name);
    hide('rom-drop-zone'); show('screen-container');
    
    const saveName=file.name.replace('.nds','.sav');
    const savePath='/data/saves/' + saveName;
    if(vfsExists(savePath)){
      const saveData=vfsRead(savePath);
      if(saveData&&State.module&&State.module.uploadSaveOrSaveState){
        State.module.uploadSaveOrSaveState(new File([saveData],saveName),()=>{});
        log('Previous save restored');
      }
    }
    log('ROM ready - press Play to start','success');
  }catch(err){ log('ROM load error: ' + err.message,'error'); }
}

document.getElementById('btn-import-save')?.addEventListener('click',()=>document.getElementById('save-input')?.click());
document.getElementById('save-input')?.addEventListener('change',async(e)=>{
  const file=e.target.files[0]; if(!file)return;
  try{
    const buf=await file.arrayBuffer();
    const saveName=State.currentRomName.replace('.nds','.sav')||'game.sav';
    const savePath='/data/saves/' + saveName;
    vfsWrite(savePath,new Uint8Array(buf));
    if(State.module&&State.module.uploadSaveOrSaveState){
      State.module.uploadSaveOrSaveState(file,()=>log('Save imported and loaded'));
    }else log('Save imported','success');
  }catch(err){ log('Import error: ' + err.message,'error'); }
});

document.getElementById('btn-export-save')?.addEventListener('click',async()=>{
  try{
    let saveData=null;
    if(State.module&&State.module.getSave) saveData=State.module.getSave();
    if(!saveData){
      const saveName=State.currentRomName.replace('.nds','.sav')||'game.sav';
      if(vfsExists('/data/saves/' + saveName)) saveData=vfsRead('/data/saves/' + saveName);
    }
    if(saveData){ downloadFile(saveData,State.currentRomName.replace('.nds','.sav')||'game.sav'); }
    else log('No save data found','warn');
  }catch(err){ log('Export error: ' + err.message,'error'); }
});

setInterval(()=>{
  if(!State.romLoaded||!State.autosaveEnabled)return;
  try{ if(State.module&&State.module.FS&&State.module.IDBFS) State.module.FS.syncfs(false,()=>{}); }
  catch(e){}
},30000);

document.getElementById('btn-save-state')?.addEventListener('click',async()=>{
  if(!State.romLoaded){log('Load a ROM first','warn');return;}
  try{
    const slot=document.getElementById('state-slot')?.value||'1';
    let stateData=null;
    if(State.module&&State.module.saveStateSlot) stateData=State.module.saveStateSlot(parseInt(slot),0);
    else if(State.module&&State.module.saveState) stateData=State.module.saveState(parseInt(slot));
    if(stateData){
      State.saveStates[slot]=stateData;
      await dbPut('savestates',State.currentRomName + '_slot' + slot,stateData);
      log('Save state saved to slot ' + slot,'success');
    }else{
      const snapshot=serializeEmulatorState();
      State.saveStates[slot]=snapshot;
      await dbPut('savestates',State.currentRomName + '_slot' + slot,snapshot);
      log('Save state ' + slot + ' stored (memory)','success');
    }
  }catch(err){ log('Save state error: ' + err.message,'error'); }
});

document.getElementById('btn-load-state')?.addEventListener('click',async()=>{
  if(!State.romLoaded){log('Load a ROM first','warn');return;}
  try{
    const slot=document.getElementById('state-slot')?.value||'1';
    let stateData=State.saveStates[slot];
    if(!stateData) stateData=await dbGet('savestates',State.currentRomName + '_slot' + slot);
    if(!stateData){log('No save state in slot ' + slot,'warn');return;}
    if(State.module&&State.module.loadStateSlot){ State.module.loadStateSlot(parseInt(slot),0); log('State loaded from slot ' + slot,'success'); }
    else if(State.module&&State.module.loadState){ State.module.loadState(parseInt(slot)); log('State loaded from slot ' + slot,'success'); }
    else log('State loading not supported','warn');
  }catch(err){ log('Load state error: ' + err.message,'error'); }
});

function serializeEmulatorState(){
  if(!State.module||!State.wasmMemory)return null;
  const snapshot=new Uint8Array(State.wasmMemory.length);
  snapshot.set(State.wasmMemory); return snapshot;
}

document.getElementById('btn-play-pause')?.addEventListener('click',()=>{
  if(!State.romLoaded){log('Load a ROM first','warn');return;}
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
    try{ /* Core handles internal rendering */ }catch(e){console.error(e);}
    State.frameCount++;
    const now=performance.now();
    if(now-State.lastFpsTime>=1000){
      State.fps=State.frameCount; State.frameCount=0; State.lastFpsTime=now;
      document.getElementById('fps-counter').textContent=State.fps + ' fps';
    }
    requestAnimationFrame(frame);
  }
  State.lastFpsTime=performance.now(); requestAnimationFrame(frame);
}

document.addEventListener('keydown',(e)=>{
  const key=e.key.length===1?e.key.toLowerCase():e.key;
  if(State.pressedKeys.has(key))return; State.pressedKeys.add(key);
  const ndsBtn=State.keyMap[key]; if(!ndsBtn)return; e.preventDefault();
  if(State.module&&State.module.buttonPress)State.module.buttonPress(ndsBtn);
});
document.addEventListener('keyup',(e)=>{
  const key=e.key.length===1?e.key.toLowerCase():e.key;
  State.pressedKeys.delete(key);
  const ndsBtn=State.keyMap[key]; if(!ndsBtn)return; e.preventDefault();
  if(State.module&&State.module.buttonUnpress)State.module.buttonUnpress(ndsBtn);
});
window.addEventListener('keydown',(e)=>{
  if(['ArrowUp','ArrowDown','ArrowLeft','ArrowRight',' '].includes(e.key)){if(State.running)e.preventDefault();}
});

// Touchscreen Simulation
const bottomCanvas=document.getElementById('screen-bottom');
const touchIndicator=document.getElementById('touch-indicator');

function getTouchPos(evt,canvas){
  const rect=canvas.getBoundingClientRect();
  const scaleX=256/rect.width; const scaleY=192/rect.height;
  const clientX=evt.touches?evt.touches[0].clientX:evt.clientX;
  const clientY=evt.touches?evt.touches[0].clientY:evt.clientY;
  return { x:Math.floor((clientX-rect.left)*scaleX), y:Math.floor((clientY-rect.top)*scaleY) };
}

function updateTouchIndicator(pos){
  const sc=document.getElementById('screen-container');
  const rect=sc.getBoundingClientRect();
  const brect=bottomCanvas.getBoundingClientRect();
  touchIndicator.style.left=(brect.left-rect.left+pos.x*(brect.width/256))+'px';
  touchIndicator.style.top=(brect.top-rect.top+pos.y*(brect.height/192))+'px';
}

bottomCanvas?.addEventListener('mousedown',(e)=>{
  if(!State.romLoaded)return;
  State.touchActive=true;
  const pos=getTouchPos(e,bottomCanvas);
  State.touchX=pos.x; State.touchY=pos.y;
  touchIndicator.classList.add('active');
  updateTouchIndicator(pos);
  if(State.module&&State.module.touchDown) State.module.touchDown(pos.x,pos.y);
  if(State.module&&State.module.buttonPress) State.module.buttonPress('touch');
});

bottomCanvas?.addEventListener('mousemove',(e)=>{
  if(!State.touchActive||!State.romLoaded)return;
  const pos=getTouchPos(e,bottomCanvas);
  State.touchX=pos.x; State.touchY=pos.y;
  updateTouchIndicator(pos);
  if(State.module&&State.module.touchMove) State.module.touchMove(pos.x,pos.y);
});

window?.addEventListener('mouseup',()=>{
  if(!State.touchActive)return;
  State.touchActive=false;
  touchIndicator.classList.remove('active');
  if(State.module&&State.module.touchUp) State.module.touchUp();
  if(State.module&&State.module.buttonUnpress) State.module.buttonUnpress('touch');
});

bottomCanvas?.addEventListener('touchstart',(e)=>{
  e.preventDefault(); if(!State.romLoaded)return;
  State.touchActive=true;
  const pos=getTouchPos(e,bottomCanvas);
  touchIndicator.classList.add('active');
  updateTouchIndicator(pos);
  if(State.module&&State.module.touchDown)State.module.touchDown(pos.x,pos.y);
},{passive:false});
bottomCanvas?.addEventListener('touchmove',(e)=>{
  e.preventDefault(); if(!State.touchActive)return;
  const pos=getTouchPos(e,bottomCanvas);
  updateTouchIndicator(pos);
  if(State.module&&State.module.touchMove)State.module.touchMove(pos.x,pos.y);
},{passive:false});
bottomCanvas?.addEventListener('touchend',(e)=>{
  e.preventDefault(); State.touchActive=false;
  touchIndicator.classList.remove('active');
  if(State.module&&State.module.touchUp)State.module.touchUp();
},{passive:false});

// Display Controls
document.getElementById('btn-fullscreen')?.addEventListener('click',()=>{
  const sc=document.getElementById('screen-container');
  if(document.fullscreenElement)document.exitFullscreen(); else sc?.requestFullscreen();
});

document.getElementById('btn-crt')?.addEventListener('click',()=>{
  State.crtEnabled=!State.crtEnabled;
  document.getElementById('crt-overlay')?.classList.toggle('active',State.crtEnabled);
  const btn=document.getElementById('btn-crt');
  btn.textContent=State.crtEnabled?'CRT On':'CRT Off';
  btn.classList.toggle('btn-primary',State.crtEnabled);
});

document.getElementById('btn-layout')?.addEventListener('click',()=>{
  const modes=['vertical','horizontal','top-only'];
  const idx=modes.indexOf(State.layoutMode);
  State.layoutMode=modes[(idx+1)%modes.length];
  applyLayout();
});

function applyLayout(){
  const sc=document.getElementById('screen-container');
  sc.className='screen-container hidden';
  if(State.layoutMode==='vertical') sc.classList.add('layout-vertical');
  else if(State.layoutMode==='horizontal') sc.classList.add('layout-horizontal');
  else sc.classList.add('layout-top-only');
  if(State.romLoaded) sc.classList.remove('hidden');
  document.getElementById('btn-layout').textContent=
    State.layoutMode==='vertical'?'Vertical':State.layoutMode==='horizontal'?'Horizontal':'Top Only';
}

document.getElementById('select-layout')?.addEventListener('change',(e)=>{
  State.layoutMode=e.target.value; applyLayout();
});

document.getElementById('select-scale')?.addEventListener('change',(e)=>{
  const scale=parseInt(e.target.value);
  document.getElementById('screen-top').style.width=(256*scale)+'px';
  document.getElementById('screen-top').style.height=(192*scale)+'px';
  document.getElementById('screen-bottom').style.width=(256*scale)+'px';
  document.getElementById('screen-bottom').style.height=(192*scale)+'px';
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
    else if(t.id==='toggle-smooth'){
      State.smoothScaling=t.classList.contains('active');
      document.querySelectorAll('.nds-screen').forEach(c=>{
        c.style.imageRendering=State.smoothScaling?'auto':'pixelated'; });
    }
  });
});

document.getElementById('btn-help')?.addEventListener('click',()=>{
  alert('Aether NDS - Quick Help\n\n1. Load desmond.wasm + desmond.js (Emscripten files)\n2. Drop a .nds ROM file\n3. Controls: Z=A, X=B, A=Y, S=X, Q=L, W=R, Enter=Start, Space=Select\n4. Touchscreen: Click/drag on bottom screen\n5. Use screen layout button to toggle vertical/horizontal/top-only\n\nNote: Some cores may require DS BIOS files (firmware.nds, bios7.bin, bios9.bin).');
});

(async function init(){
  await openDB();
  log('Aether NDS initialized');
  log('Drop desmond.wasm + desmond.js (Emscripten files) to begin');
})();
window.AetherNDS=State;""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
