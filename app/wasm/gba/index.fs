module ConvertedFiles.Wasm.Gba.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Aether GBA - Game Boy Advance Emulator"
            ]
            style [] [
                    rawText ("""/* ============================================================
   AETHER GBA EMULATOR
   A standalone, self-contained Game Boy Advance emulator shell
   Built for mGBA WebAssembly core integration
   ============================================================ */

/* ---- CSS Reset & Base ---- */
*, *::before, *::after { margin: 0; padding: 0; box-sizing: border-box; }
:root {
  --bg-primary: #0a0e1a;
  --bg-secondary: #111827;
  --bg-card: rgba(17,24,39,0.85);
  --accent: #3b82f6;
  --accent-glow: rgba(59,130,246,0.4);
  --accent-secondary: #8b5cf6;
  --text-primary: #e2e8f0;
  --text-secondary: #94a3b8;
  --success: #10b981;
  --warning: #f59e0b;
  --danger: #ef4444;
  --border: rgba(255,255,255,0.08);
  --glass: rgba(17,24,39,0.7);
  --glass-border: rgba(255,255,255,0.1);
}
html, body {
  width: 100%; height: 100%;
  font-family: 'Segoe UI', system-ui, -apple-system, sans-serif;
  background: var(--bg-primary);
  color: var(--text-primary);
  overflow-x: hidden;
}

/* ---- Animated Particle Background (CSS-only) ---- */
.particles {
  position: fixed; inset: 0; z-index: 0; pointer-events: none; overflow: hidden;
}
.particle {
  position: absolute; width: 2px; height: 2px;
  background: var(--accent); border-radius: 50%;
  opacity: 0; animation: float linear infinite;
}
@keyframes float {
  0% { transform: translateY(100vh) scale(0); opacity: 0; }
  10% { opacity: 0.6; }
  90% { opacity: 0.6; }
  100% { transform: translateY(-10vh) scale(1); opacity: 0; }
}
.particle:nth-child(1) { left: 10%; animation-duration: 15s; animation-delay: 0s; }
.particle:nth-child(2) { left: 20%; animation-duration: 20s; animation-delay: 2s; width: 3px; height: 3px; }
.particle:nth-child(3) { left: 30%; animation-duration: 18s; animation-delay: 4s; }
.particle:nth-child(4) { left: 40%; animation-duration: 22s; animation-delay: 1s; width: 4px; height: 4px; background: var(--accent-secondary); }
.particle:nth-child(5) { left: 50%; animation-duration: 16s; animation-delay: 3s; }
.particle:nth-child(6) { left: 60%; animation-duration: 19s; animation-delay: 5s; width: 3px; height: 3px; }
.particle:nth-child(7) { left: 70%; animation-duration: 21s; animation-delay: 2s; background: var(--accent-secondary); }
.particle:nth-child(8) { left: 80%; animation-duration: 17s; animation-delay: 4s; width: 4px; height: 4px; }
.particle:nth-child(9) { left: 90%; animation-duration: 23s; animation-delay: 1s; }
.particle:nth-child(10) { left: 15%; animation-duration: 14s; animation-delay: 3s; width: 3px; height: 3px; background: var(--accent-secondary); }
.particle:nth-child(11) { left: 25%; animation-duration: 25s; animation-delay: 6s; }
.particle:nth-child(12) { left: 65%; animation-duration: 13s; animation-delay: 2s; width: 2px; height: 2px; }
.particle:nth-child(13) { left: 75%; animation-duration: 19s; animation-delay: 7s; }
.particle:nth-child(14) { left: 85%; animation-duration: 16s; animation-delay: 4s; width: 3px; height: 3px; background: var(--accent-secondary); }
.particle:nth-child(15) { left: 5%; animation-duration: 21s; animation-delay: 1s; }

/* ---- Grid Background Pattern ---- */
.grid-bg {
  position: fixed; inset: 0; z-index: 0; pointer-events: none;
  background-image:
    linear-gradient(rgba(59,130,246,0.03) 1px, transparent 1px),
    linear-gradient(90deg, rgba(59,130,246,0.03) 1px, transparent 1px);
  background-size: 40px 40px;
}

/* ---- App Container ---- */
.app { position: relative; z-index: 1; min-height: 100vh; display: flex; flex-direction: column; }

/* ---- Header ---- */
.header {
  display: flex; align-items: center; justify-content: space-between;
  padding: 16px 24px;
  background: var(--glass);
  backdrop-filter: blur(20px);
  border-bottom: 1px solid var(--glass-border);
  position: sticky; top: 0; z-index: 100;
}
.header-left { display: flex; align-items: center; gap: 12px; }
.logo-icon {
  width: 36px; height: 36px; border-radius: 10px;
  background: linear-gradient(135deg, var(--accent), var(--accent-secondary));
  display: flex; align-items: center; justify-content: center;
  font-size: 18px; font-weight: 800; color: white;
  box-shadow: 0 0 20px var(--accent-glow);
}
.header-title { font-size: 20px; font-weight: 700; letter-spacing: -0.5px; }
.header-subtitle { font-size: 11px; color: var(--text-secondary); letter-spacing: 1px; text-transform: uppercase; }
.header-right { display: flex; gap: 8px; align-items: center; }

/* ---- Buttons ---- */
.btn {
  display: inline-flex; align-items: center; gap: 6px;
  padding: 8px 16px; border-radius: 8px; border: 1px solid var(--border);
  background: var(--bg-secondary); color: var(--text-primary);
  font-size: 13px; font-weight: 600; cursor: pointer;
  transition: all 0.2s ease; font-family: inherit;
}
.btn:hover { background: var(--accent); border-color: var(--accent); transform: translateY(-1px); box-shadow: 0 4px 12px var(--accent-glow); }
.btn:active { transform: translateY(0); }
.btn-primary { background: var(--accent); border-color: var(--accent); }
.btn-primary:hover { background: #2563eb; }
.btn-small { padding: 6px 12px; font-size: 12px; }
.btn-icon { padding: 8px; font-size: 16px; }

/* ---- Main Content ---- */
.main { flex: 1; display: flex; flex-direction: column; align-items: center; padding: 24px; gap: 20px; }

/* ---- Status Bar ---- */
.status-bar {
  width: 100%; max-width: 960px;
  display: flex; align-items: center; justify-content: space-between;
  padding: 10px 18px;
  background: var(--glass); backdrop-filter: blur(12px);
  border-radius: 10px; border: 1px solid var(--glass-border);
  font-size: 12px; color: var(--text-secondary);
}
.status-item { display: flex; align-items: center; gap: 6px; }
.status-dot { width: 8px; height: 8px; border-radius: 50%; background: var(--danger); transition: background 0.3s; }
.status-dot.ready { background: var(--success); box-shadow: 0 0 8px rgba(16,185,129,0.5); }
.status-dot.active { background: var(--accent); box-shadow: 0 0 8px var(--accent-glow); animation: pulse 2s infinite; }
@keyframes pulse { 0%,100% { opacity: 1; } 50% { opacity: 0.5; } }

/* ---- Emulator Viewport ---- */
.viewport {
  position: relative;
  border-radius: 16px; overflow: hidden;
  box-shadow: 0 20px 60px rgba(0,0,0,0.5), 0 0 40px rgba(59,130,246,0.1);
  border: 1px solid var(--glass-border);
  background: #000;
}
#gba-canvas {
  display: block;
  image-rendering: pixelated;
  image-rendering: crisp-edges;
  width: 480px; height: 320px;
}

/* ---- CRT Scanline Overlay ---- */
.crt-overlay {
  position: absolute; inset: 0; pointer-events: none; z-index: 10;
  background:
    repeating-linear-gradient(
      0deg,
      rgba(0,0,0,0.12) 0px,
      rgba(0,0,0,0.12) 1px,
      transparent 1px,
      transparent 3px
    );
  opacity: 0; transition: opacity 0.3s;
  border-radius: 16px;
}
.crt-overlay.active { opacity: 1; }
.crt-overlay::after {
  content: ''; position: absolute; inset: 0;
  background: radial-gradient(ellipse at center, transparent 50%, rgba(0,0,0,0.3) 100%);
  border-radius: 16px;
}

/* ---- Drop Zone ---- */
.drop-zone {
  width: 100%; max-width: 480px;
  padding: 40px 24px;
  border: 2px dashed var(--border);
  border-radius: 16px;
  text-align: center;
  transition: all 0.3s ease;
  background: var(--glass); backdrop-filter: blur(8px);
}
.drop-zone.drag-over {
  border-color: var(--accent);
  background: rgba(59,130,246,0.1);
  transform: scale(1.02);
  box-shadow: 0 0 30px var(--accent-glow);
}
.drop-zone-icon { font-size: 48px; margin-bottom: 12px; opacity: 0.5; }
.drop-zone-title { font-size: 16px; font-weight: 600; margin-bottom: 6px; }
.drop-zone-hint { font-size: 12px; color: var(--text-secondary); }
.drop-zone-input { display: none; }

/* ---- Control Bar ---- */
.control-bar {
  width: 100%; max-width: 960px;
  display: flex; flex-wrap: wrap; align-items: center; gap: 8px;
  padding: 12px 18px;
  background: var(--glass); backdrop-filter: blur(12px);
  border-radius: 12px; border: 1px solid var(--glass-border);
}
.control-group { display: flex; align-items: center; gap: 6px; padding: 0 8px; border-right: 1px solid var(--border); }
.control-group:last-child { border-right: none; }
.control-label { font-size: 11px; color: var(--text-secondary); text-transform: uppercase; letter-spacing: 0.5px; margin-right: 4px; }

/* ---- Settings Panel (Slide-out) ---- */
.settings-panel {
  position: fixed; top: 0; right: -400px; width: 380px; height: 100vh;
  background: var(--glass); backdrop-filter: blur(30px);
  border-left: 1px solid var(--glass-border);
  z-index: 200; transition: right 0.3s ease;
  overflow-y: auto; padding: 80px 24px 24px;
}
.settings-panel.open { right: 0; }
.settings-overlay {
  position: fixed; inset: 0; background: rgba(0,0,0,0.5); z-index: 199;
  opacity: 0; pointer-events: none; transition: opacity 0.3s;
}
.settings-overlay.open { opacity: 1; pointer-events: all; }
.settings-title { font-size: 20px; font-weight: 700; margin-bottom: 24px; }
.settings-section { margin-bottom: 24px; }
.settings-section-title { font-size: 12px; color: var(--text-secondary); text-transform: uppercase; letter-spacing: 1px; margin-bottom: 12px; }
.setting-item { display: flex; align-items: center; justify-content: space-between; padding: 10px 0; border-bottom: 1px solid var(--border); }
.setting-label { font-size: 13px; }
.toggle { width: 44px; height: 24px; border-radius: 12px; background: var(--border); position: relative; cursor: pointer; transition: background 0.3s; }
.toggle.active { background: var(--accent); }
.toggle-knob { width: 20px; height: 20px; border-radius: 50%; background: white; position: absolute; top: 2px; left: 2px; transition: left 0.3s; }
.toggle.active .toggle-knob { left: 22px; }
.select { padding: 6px 12px; border-radius: 6px; border: 1px solid var(--border); background: var(--bg-secondary); color: var(--text-primary); font-family: inherit; font-size: 13px; }
.key-map { display: flex; align-items: center; gap: 8px; font-size: 12px; color: var(--text-secondary); }
.key-badge { padding: 2px 8px; border-radius: 4px; background: var(--bg-secondary); border: 1px solid var(--border); font-family: monospace; font-size: 11px; }

/* ---- Key Mapping Grid ---- */
.key-grid { display: grid; grid-template-columns: 1fr 1fr; gap: 8px; font-size: 12px; }
.key-grid-item { display: flex; justify-content: space-between; align-items: center; padding: 6px 10px; background: var(--bg-secondary); border-radius: 6px; }
.key-grid-action { color: var(--text-secondary); }

/* ---- Log / Console ---- */
.log-panel {
  width: 100%; max-width: 960px; max-height: 150px; overflow-y: auto;
  padding: 12px 16px;
  background: var(--glass); backdrop-filter: blur(8px);
  border-radius: 10px; border: 1px solid var(--glass-border);
  font-family: 'Consolas', 'Monaco', monospace; font-size: 11px;
}
.log-entry { padding: 2px 0; border-bottom: 1px solid rgba(255,255,255,0.03); }
.log-entry.info { color: var(--text-secondary); }
.log-entry.success { color: var(--success); }
.log-entry.warn { color: var(--warning); }
.log-entry.error { color: var(--danger); }

/* ---- Responsive ---- */
@media (max-width: 768px) {
  #gba-canvas { width: 360px; height: 240px; }
  .control-bar { justify-content: center; }
  .settings-panel { width: 100%; right: -100%; }
  .header { padding: 12px 16px; }
  .header-title { font-size: 16px; }
}
@media (max-width: 480px) {
  #gba-canvas { width: 300px; height: 200px; }
}

/* ---- Utility Classes ---- */
.hidden { display: none !important; }
.fade-in { animation: fadeIn 0.5s ease; }
@keyframes fadeIn { from { opacity: 0; transform: translateY(10px); } to { opacity: 1; transform: translateY(0); } }

/* ---- Scrollbar ---- */
::-webkit-scrollbar { width: 6px; }
::-webkit-scrollbar-track { background: transparent; }
::-webkit-scrollbar-thumb { background: var(--border); border-radius: 3px; }
::-webkit-scrollbar-thumb:hover { background: var(--text-secondary); }""")
            ]
        ]
        body [] [
            rawText ("""<!--  Animated Background  -->""")
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
                rawText ("""<!--  Header  -->""")
                header [ _class "header" ] [
                    div [ _class "header-left" ] [
                        div [ _class "logo-icon" ] [
                            str "A"
                        ]
                        div [] [
                            div [ _class "header-title" ] [
                                str "Aether GBA"
                            ]
                            div [ _class "header-subtitle" ] [
                                str "Game Boy Advance Emulator"
                            ]
                        ]
                    ]
                    div [ _class "header-right" ] [
                        button [ _class "btn btn-small"; _id "btn-load-wasm"; attr "title" "Load WASM Core" ] [
                            span [] [
                                str "Load Core"
                            ]
                        ]
                        button [ _class "btn btn-small"; _id "btn-settings"; attr "title" "Settings" ] [
                            span [] [
                                str "Settings"
                            ]
                        ]
                        button [ _class "btn btn-small"; _id "btn-help"; attr "title" "Help" ] [
                            str "?"
                        ]
                    ]
                ]
                rawText ("""<!--  Main Content  -->""")
                main [ _class "main" ] [
                    rawText ("""<!--  Status Bar  -->""")
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
                    rawText ("""<!--  WASM Core Loader (shown when no core)  -->""")
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
                                str "mgba.wasm"
                            ]
                            str "+"
                            b [] [
                                str "mgba.js"
                            ]
                            str "here or click to browse"
                            br []
                            small [] [
                                str "Provide the Emscripten-compiled mGBA WebAssembly files"
                            ]
                        ]
                        input [ _type "file"; _class "drop-zone-input"; _id "wasm-input"; attr "accept" ".wasm,.js"; attr "multiple" "" ]
                    ]
                    rawText ("""<!--  ROM Loader (shown when core loaded, no ROM)  -->""")
                    div [ _class "drop-zone hidden"; _id "rom-drop-zone" ] [
                        div [ _class "drop-zone-icon" ] [
                            str "🎮"
                        ]
                        div [ _class "drop-zone-title" ] [
                            str "Load Game ROM"
                        ]
                        div [ _class "drop-zone-hint" ] [
                            str "Drop a"
                            b [] [
                                str ".gba"
                            ]
                            str "file here or click to browse"
                            br []
                            small [] [
                                str "Supports .gba ROM files"
                            ]
                        ]
                        input [ _type "file"; _class "drop-zone-input"; _id "rom-input"; attr "accept" ".gba" ]
                    ]
                    rawText ("""<!--  Emulator Viewport  -->""")
                    div [ _class "viewport hidden"; _id "emulator-viewport" ] [
                        canvas [ _id "gba-canvas"; attr "width" "240"; attr "height" "160" ] []
                        div [ _class "crt-overlay"; _id "crt-overlay" ] []
                    ]
                    rawText ("""<!--  Control Bar  -->""")
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
                            input [ _type "file"; _class "drop-zone-input"; _id "save-input"; attr "accept" ".sav" ]
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
                                str "Emulation"
                            ]
                            button [ _class "btn btn-small"; _id "btn-play-pause" ] [
                                str "▶ Play"
                            ]
                            button [ _class "btn btn-small"; _id "btn-reset" ] [
                                str "Reset"
                            ]
                            button [ _class "btn btn-small"; _id "btn-fast" ] [
                                str "Fast ×2"
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
                    rawText ("""<!--  Log Panel  -->""")
                    div [ _class "log-panel"; _id "log-panel" ] [
                        div [ _class "log-entry info" ] [
                            str "Welcome to Aether GBA. Load an emulator core to begin."
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  Settings Panel  -->""")
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
                                str "1x (240x160)"
                            ]
                            option [ attr "value" "2"; attr "selected" "" ] [
                                str "2x (480x320)"
                            ]
                            option [ attr "value" "3" ] [
                                str "3x (720x480)"
                            ]
                            option [ attr "value" "4" ] [
                                str "4x (960x640)"
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
                                str "L Shoulder"
                            ]
                            span [ _class "key-badge" ] [
                                str "A"
                            ]
                        ]
                        div [ _class "key-grid-item" ] [
                            span [ _class "key-grid-action" ] [
                                str "R Shoulder"
                            ]
                            span [ _class "key-badge" ] [
                                str "S"
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
                                str "Shift"
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
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-section-title" ] [
                        str "Emulation"
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "Fast Forward Multiplier"
                        ]
                        select [ _class "select"; _id "select-ff" ] [
                            option [ attr "value" "2" ] [
                                str "2x"
                            ]
                            option [ attr "value" "3" ] [
                                str "3x"
                            ]
                            option [ attr "value" "4" ] [
                                str "4x"
                            ]
                        ]
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "Auto-save SRAM to IndexedDB"
                        ]
                        div [ _class "toggle active"; _id "toggle-autosave" ] [
                            div [ _class "toggle-knob" ] []
                        ]
                    ]
                    div [ _class "setting-item" ] [
                        span [ _class "setting-label" ] [
                            str "Rewind Support"
                        ]
                        div [ _class "toggle"; _id "toggle-rewind" ] [
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
                            str "Aether GBA"
                        ]
                        str "v1.0 — A standalone Game Boy Advance emulator shell."
                        br []
                        str "Built for the mGBA WebAssembly core."
                        br []
                        br []
                        strong [] [
                            str "Architecture:"
                        ]
                        br []
                        str "• WASM core: Emscripten-compiled mGBA"
                        br []
                        str "• FS API: Emscripten MEMFS + IndexedDB persistence"
                        br []
                        str "• Rendering: HTML5 Canvas 2D"
                        br []
                        str "• Audio: Web Audio API"
                        br []
                        br []
                        str "Load"
                        code [] [
                            str "mgba.wasm"
                        ]
                        str "and"
                        code [] [
                            str "mgba.js"
                        ]
                        str "(the Emscripten output) to begin."
                    ]
                ]
            ]
            script [] [
                    rawText ("""/* ============================================================
   AETHER GBA — JavaScript Core
   ============================================================
   This module implements:
   - Emscripten Module pattern for WASM loading
   - Virtual FS (MEMFS + IndexedDB persistence)
   - ROM loading via FileReader -> FS.writeFile
   - SRAM save import/export via FS.readFile/FS.writeFile
   - Keyboard input mapping
   - Audio context management
   - Save state management (in-memory slots)
   - Render loop with requestAnimationFrame
   ============================================================ */

// ---- Global State ----
const State = {
  wasmLoaded: false,
  romLoaded: false,
  running: false,
  paused: false,
  fastForward: false,
  fastForwardMult: 2,
  audioEnabled: false,
  crtEnabled: false,
  smoothScaling: false,
  autosaveEnabled: true,
  frameCount: 0,
  lastFpsTime: 0,
  fps: 0,
  module: null,           // Emscripten Module instance
  wasmMemory: null,       // WASM memory buffer
  canvas: null,
  ctx: null,
  audioCtx: null,
  saveStates: {},         // In-memory save state slots
  keyMap: {              // Default GBA key mappings
    'z': 'A', 'x': 'B', 'Enter': 'Start', 'Shift': 'Select',
    'ArrowUp': 'up', 'ArrowDown': 'down', 'ArrowLeft': 'left', 'ArrowRight': 'right',
    'a': 'l', 's': 'r'
  },
  pressedKeys: new Set(),
  currentRomName: '',
  coreFiles: { js: null, wasm: null }
};

// ---- Logger ----
function log(msg, type = 'info') {
  const panel = document.getElementById('log-panel');
  const entry = document.createElement('div');
  entry.className = `log-entry ${type}`;
  entry.textContent = `[${new Date().toLocaleTimeString()}] ${msg}`;
  panel.appendChild(entry);
  panel.scrollTop = panel.scrollHeight;
  console.log(`[AetherGBA] ${msg}`);
}

// ---- UI Helpers ----
function setStatus(id, text, dotClass) {
  const el = document.getElementById(id);
  if (el) el.textContent = text;
  if (id === 'core-status-text' && dotClass) {
    const dot = document.getElementById('core-status-dot');
    dot.className = 'status-dot ' + dotClass;
  }
}
function show(id) { document.getElementById(id)?.classList.remove('hidden'); }
function hide(id) { document.getElementById(id)?.classList.add('hidden'); }

// ---- IndexedDB helpers for persistent saves ----
const DB_NAME = 'AetherGBA';
const DB_VERSION = 1;
let db = null;

function openDB() {
  return new Promise((resolve, reject) => {
    const req = indexedDB.open(DB_NAME, DB_VERSION);
    req.onerror = () => reject(req.error);
    req.onsuccess = () => { db = req.result; resolve(db); };
    req.onupgradeneeded = (e) => {
      const d = e.target.result;
      if (!d.objectStoreNames.contains('saves')) d.createObjectStore('saves');
      if (!d.objectStoreNames.contains('savestates')) d.createObjectStore('savestates');
    };
  });
}

async function dbPut(store, key, data) {
  if (!db) await openDB();
  return new Promise((resolve, reject) => {
    const tx = db.transaction(store, 'readwrite');
    const os = tx.objectStore(store);
    const req = os.put(data, key);
    req.onsuccess = () => resolve();
    req.onerror = () => reject(req.error);
  });
}

async function dbGet(store, key) {
  if (!db) await openDB();
  return new Promise((resolve, reject) => {
    const tx = db.transaction(store, 'readonly');
    const os = tx.objectStore(store);
    const req = os.get(key);
    req.onsuccess = () => resolve(req.result);
    req.onerror = () => reject(req.error);
  });
}

// ---- File Download Helper ----
function downloadFile(data, filename, mime) {
  const blob = new Blob([data], { type: mime || 'application/octet-stream' });
  const url = URL.createObjectURL(blob);
  const a = document.createElement('a');
  a.href = url; a.download = filename;
  document.body.appendChild(a); a.click();
  document.body.removeChild(a); URL.revokeObjectURL(url);
  log(`Downloaded: ${filename}`, 'success');
}

// ---- Drag & Drop Setup ----
function setupDropZone(zoneId, inputId, handler) {
  const zone = document.getElementById(zoneId);
  const input = document.getElementById(inputId);
  zone.addEventListener('click', () => input.click());
  input.addEventListener('change', (e) => { if (e.target.files.length) handler(e.target.files); });
  zone.addEventListener('dragover', (e) => { e.preventDefault(); zone.classList.add('drag-over'); });
  zone.addEventListener('dragleave', () => zone.classList.remove('drag-over'));
  zone.addEventListener('drop', (e) => {
    e.preventDefault(); zone.classList.remove('drag-over');
    if (e.dataTransfer.files.length) handler(e.dataTransfer.files);
  });
}

// ============================================================
// WASM CORE LOADING
// ============================================================
// The user provides mgba.js (glue) and mgba.wasm (binary).
// We store the files, load the JS glue which in turn fetches
// the WASM binary, then initialize the Module.
// ============================================================

setupDropZone('wasm-drop-zone', 'wasm-input', async (files) => {
  for (const file of files) {
    const buf = await file.arrayBuffer();
    if (file.name.endsWith('.js')) State.coreFiles.js = { name: file.name, data: buf };
    else if (file.name.endsWith('.wasm')) State.coreFiles.wasm = { name: file.name, data: buf };
  }
  if (State.coreFiles.js && State.coreFiles.wasm) {
    await initEmulatorCore();
  } else {
    log('Need both .js glue file and .wasm binary', 'warn');
  }
});

async function initEmulatorCore() {
  log('Initializing emulator core...');
  try {
    // Create a Blob URL for the JS glue file
    const jsBlob = new Blob([State.coreFiles.js.data], { type: 'application/javascript' };
    const jsUrl = URL.createObjectURL(jsBlob);

    // We need to provide the WASM file as a URL too.
    // The Emscripten glue fetches the .wasm relative to the script.
    // We'll monkey-patch to intercept it.
    const wasmBlob = new Blob([State.coreFiles.wasm.data], { type: 'application/wasm' });
    const wasmUrl = URL.createObjectURL(wasmBlob);

    // Set up global Module config before loading the glue script
    window.Module = window.Module || {};
    Object.assign(window.Module, {
      canvas: document.getElementById('gba-canvas'),
      locateFile: (filename) => {
        if (filename.endsWith('.wasm')) return wasmUrl;
        return filename;
      },
      print: (msg) => log(msg),
      printErr: (msg) => log(msg, 'warn'),
      onRuntimeInitialized: () => {
        onCoreInitialized();
      }
    });

    // Load the Emscripten glue script dynamically
    await import(/* @vite-ignore */ jsUrl);

    log('Emscripten glue loaded, waiting for runtime...');
  } catch (err) {
    log(`Core init error: ${err.message}`, 'error');
    console.error(err);
  }
}

function onCoreInitialized() {
  State.module = window.Module;
  State.wasmLoaded = true;
  State.wasmMemory = State.module.HEAPU8;

  log('WASM core initialized!', 'success');
  setStatus('core-status-text', 'Core ready', 'ready');

  // Initialize the FS (IndexedDB-backed persistence)
  initFileSystem();

  // Show ROM drop zone
  hide('wasm-drop-zone');
  show('rom-drop-zone');

  // Setup audio
  setupAudio();
}

// ============================================================
// FILE SYSTEM — Emscripten FS API
// ============================================================
// We use MEMFS mounted at /data for runtime, and sync
// to IndexedDB for persistence of save files.
// ============================================================

function initFileSystem() {
  if (!State.module || !State.module.FS) {
    log('FS API not available — creating virtual FS', 'warn');
    createVirtualFS();
    return;
  }
  try {
    // Create directories for saves and ROMs
    State.module.FS.mkdir('/data');
    State.module.FS.mkdir('/data/saves');
    State.module.FS.mkdir('/data/roms');
    State.module.FS.mkdir('/data/states');

    // Mount IDBFS for persistence if available
    if (State.module.IDBFS) {
      State.module.FS.mount(State.module.IDBFS, {}, '/data');
      State.module.FS.syncfs(true, (err) => {
        if (err) log(`FS sync error: ${err}`, 'warn');
        else log('Save data synced from IndexedDB');
      });
    }

    log('Filesystem initialized');
  } catch (e) {
    log(`FS init: ${e.message}`, 'warn');
    createVirtualFS();
  }
}

// Fallback virtual FS when Emscripten FS is not exposed
function createVirtualFS() {
  State.vfs = { '/data': {}, '/data/saves': {}, '/data/roms': {}, '/data/states': {} };
  log('Virtual FS created (no persistence)');
}

function vfsWrite(path, data) {
  if (State.module && State.module.FS) {
    State.module.FS.writeFile(path, data);
    if (State.module.IDBFS && State.autosaveEnabled) {
      State.module.FS.syncfs(false, (err) => { if (err) console.warn('sync error', err); });
    }
  } else {
    State.vfs[path] = new Uint8Array(data);
  }
}

function vfsRead(path) {
  if (State.module && State.module.FS) {
    return State.module.FS.readFile(path);
  }
  return State.vfs[path] || null;
}

function vfsExists(path) {
  if (State.module && State.module.FS) {
    try { return State.module.FS.analyzePath(path).exists; } catch { return false; }
  }
  return path in State.vfs;
}

// ============================================================
// ROM LOADING
// ============================================================
// Upload .gba file -> write to /data/roms/game.gba via FS
// -> call core loadGame function
// ============================================================

setupDropZone('rom-drop-zone', 'rom-input', async (files) => {
  const file = files[0];
  if (!file.name.endsWith('.gba')) { log('Only .gba files supported', 'warn'); return; }
  await loadRomFile(file);
});

document.getElementById('btn-load-rom')?.addEventListener('click', () => {
  document.getElementById('rom-input')?.click();
});

async function loadRomFile(file) {
  try {
    const buf = await file.arrayBuffer();
    const romData = new Uint8Array(buf);
    State.currentRomName = file.name;

    // Write ROM to virtual filesystem
    const romPath = `/data/roms/${file.name}`;
    vfsWrite(romPath, romData);

    log(`ROM loaded: ${file.name} (${(romData.length/1024/1024).toFixed(2)} MB)`);

    // Try to load via mGBA API if available
    if (State.module && State.module.uploadRom) {
      // Use mGBA's native upload
      await new Promise((resolve, reject) => {
        State.module.uploadRom(new File([romData], file.name), (err) => {
          if (err) reject(err); else resolve();
        });
      });
    }

    // Try loadGame API
    if (State.module && State.module.loadGame) {
      State.module.loadGame(romPath);
    }

    State.romLoaded = true;
    setStatus('rom-status-text', `ROM: ${file.name}`);

    // Check for existing save
    const saveName = file.name.replace('.gba', '.sav');
    const savePath = `/data/saves/${saveName}`;

    hide('rom-drop-zone');
    show('emulator-viewport');

    // Restore save if exists
    if (vfsExists(savePath)) {
      const saveData = vfsRead(savePath);
      if (saveData && State.module && State.module.uploadSaveOrSaveState) {
        State.module.uploadSaveOrSaveState(new File([saveData], saveName), () => {});
        log('Previous save restored');
      }
    }

    log('ROM ready — press Play to start', 'success');
  } catch (err) {
    log(`ROM load error: ${err.message}`, 'error');
  }
}

// ============================================================
// SAVE MANAGEMENT (SRAM Battery Saves)
// ============================================================
// GBA battery saves are typically 32KB-128KB EEPROM/Flash.
// Format: raw .sav file (no header)
// ============================================================

document.getElementById('btn-import-save')?.addEventListener('click', () => {
  document.getElementById('save-input')?.click();
});

document.getElementById('save-input')?.addEventListener('change', async (e) => {
  const file = e.target.files[0]; if (!file) return;
  try {
    const buf = await file.arrayBuffer();
    const saveName = State.currentRomName.replace('.gba', '.sav') || 'game.sav';
    const savePath = `/data/saves/${saveName}`;
    vfsWrite(savePath, new Uint8Array(buf));

    if (State.module && State.module.uploadSaveOrSaveState) {
      State.module.uploadSaveOrSaveState(file, () => {
        log('Save file imported and loaded');
      });
    } else {
      log('Save imported (will be used on next reset)', 'success');
    }
  } catch (err) {
    log(`Import error: ${err.message}`, 'error');
  }
});

document.getElementById('btn-export-save')?.addEventListener('click', async () => {
  try {
    let saveData = null;

    // Try mGBA's getSave API
    if (State.module && State.module.getSave) {
      saveData = State.module.getSave();
    }

    // Fallback: read from VFS
    if (!saveData) {
      const saveName = State.currentRomName.replace('.gba', '.sav') || 'game.sav';
      const savePath = `/data/saves/${saveName}`;
      if (vfsExists(savePath)) saveData = vfsRead(savePath);
    }

    if (saveData) {
      const saveName = State.currentRomName.replace('.gba', '.sav') || 'game.sav';
      downloadFile(saveData, saveName);
    } else {
      log('No save data found', 'warn');
    }
  } catch (err) {
    log(`Export error: ${err.message}`, 'error');
  }
});

// Auto-save interval (every 30 seconds)
setInterval(() => {
  if (!State.romLoaded || !State.autosaveEnabled) return;
  try {
    if (State.module && State.module.FS && State.module.IDBFS) {
      State.module.FS.syncfs(false, (err) => {
        if (!err) log('Auto-saved to IndexedDB');
      });
    }
  } catch (e) { /* silent */ }
}, 30000);

// ============================================================
// SAVE STATES (In-memory slots)
// ============================================================
// Uses mGBA's saveState/loadState API if available,
// otherwise falls back to Module.serializeState
// ============================================================

document.getElementById('btn-save-state')?.addEventListener('click', async () => {
  if (!State.romLoaded) { log('Load a ROM first', 'warn'); return; }
  try {
    const slot = document.getElementById('state-slot')?.value || '1';
    let stateData = null;

    if (State.module && State.module.saveStateSlot) {
      stateData = State.module.saveStateSlot(parseInt(slot), 0);
    } else if (State.module && State.module.saveState) {
      stateData = State.module.saveState(parseInt(slot));
    } else if (State.module && State.module.getSaveState) {
      // Serialize current emulation state from memory
      stateData = serializeEmulatorState();
    }

    if (stateData) {
      State.saveStates[slot] = stateData;
      await dbPut('savestates', `${State.currentRomName}_slot${slot}`, stateData);
      log(`Save state saved to slot ${slot}`, 'success');
    } else {
      // Fallback: serialize from memory manually
      const snapshot = serializeEmulatorState();
      State.saveStates[slot] = snapshot;
      await dbPut('savestates', `${State.currentRomName}_slot${slot}`, snapshot);
      log(`Save state ${slot} stored (memory snapshot)`);
    }
  } catch (err) {
    log(`Save state error: ${err.message}`, 'error');
  }
});

document.getElementById('btn-load-state')?.addEventListener('click', async () => {
  if (!State.romLoaded) { log('Load a ROM first', 'warn'); return; }
  try {
    const slot = document.getElementById('state-slot')?.value || '1';
    let stateData = State.saveStates[slot];

    // Try IndexedDB
    if (!stateData) {
      stateData = await dbGet('savestates', `${State.currentRomName}_slot${slot}`);
    }

    if (!stateData) { log(`No save state in slot ${slot}`, 'warn'); return; }

    if (State.module && State.module.loadStateSlot) {
      State.module.loadStateSlot(parseInt(slot), 0);
      log(`Save state loaded from slot ${slot}`, 'success');
    } else if (State.module && State.module.loadState) {
      State.module.loadState(parseInt(slot));
      log(`Save state loaded from slot ${slot}`, 'success');
    } else {
      log('State loading not supported by this core', 'warn');
    }
  } catch (err) {
    log(`Load state error: ${err.message}`, 'error');
  }
});

// Fallback: manually serialize emulator state from WASM memory
function serializeEmulatorState() {
  if (!State.module || !State.wasmMemory) return null;
  // Capture a slice of the relevant memory regions
  // This is a best-effort snapshot for cores without native state support
  const mem = State.wasmMemory;
  const snapshot = new Uint8Array(mem.length);
  snapshot.set(mem);
  return snapshot;
}

// ============================================================
// AUDIO MANAGEMENT
// ============================================================
// Web Audio API for audio output.
// The Emscripten core writes audio samples to a buffer
// which we copy to the Web Audio API output.
// ============================================================

function setupAudio() {
  try {
    State.audioCtx = new (window.AudioContext || window.webkitAudioContext)();
    log('Audio context created');
  } catch (e) {
    log('Audio not supported', 'warn');
  }
}

document.getElementById('btn-audio')?.addEventListener('click', () => {
  if (!State.audioCtx) { log('Audio not available', 'warn'); return; }
  State.audioEnabled = !State.audioEnabled;
  const btn = document.getElementById('btn-audio');
  if (State.audioEnabled) {
    if (State.audioCtx.state === 'suspended') State.audioCtx.resume();
    btn.textContent = 'Audio On';
    btn.classList.add('btn-primary');
    if (State.module && State.module.resumeAudio) State.module.resumeAudio();
    log('Audio enabled');
  } else {
    btn.textContent = 'Audio Off';
    btn.classList.remove('btn-primary');
    if (State.module && State.module.pauseAudio) State.module.pauseAudio();
    log('Audio disabled');
  }
});

// ============================================================
// EMULATION CONTROL
// ============================================================

document.getElementById('btn-play-pause')?.addEventListener('click', () => {
  if (!State.romLoaded) { log('Load a ROM first', 'warn'); return; }
  State.paused = !State.paused;
  const btn = document.getElementById('btn-play-pause');
  if (State.paused) {
    btn.textContent = '▶ Play';
    State.running = false;
    if (State.module && State.module.pauseGame) State.module.pauseGame();
    log('Emulation paused');
  } else {
    btn.textContent = '⏸ Pause';
    State.running = true;
    if (State.module && State.module.resumeGame) State.module.resumeGame();
    setStatus('core-status-dot', '', 'active');
    startEmulationLoop();
    log('Emulation started');
  }
});

document.getElementById('btn-reset')?.addEventListener('click', () => {
  if (!State.romLoaded) return;
  if (State.module && State.module.quickReload) {
    State.module.quickReload();
    log('Emulation reset');
  } else {
    log('Reset not supported by core', 'warn');
  }
});

document.getElementById('btn-fast')?.addEventListener('click', () => {
  State.fastForward = !State.fastForward;
  const btn = document.getElementById('btn-fast');
  const mult = State.fastForwardMult;
  if (State.fastForward) {
    btn.textContent = `Fast ×${mult}`;
    btn.classList.add('btn-primary');
    if (State.module && State.module.setFastForwardMultiplier) {
      State.module.setFastForwardMultiplier(mult);
    }
    log(`Fast forward: ${mult}x`);
  } else {
    btn.textContent = 'Fast ×2';
    btn.classList.remove('btn-primary');
    if (State.module && State.module.setFastForwardMultiplier) {
      State.module.setFastForwardMultiplier(1);
    }
    log('Normal speed');
  }
});

// ============================================================
// RENDER LOOP
// ============================================================
// Drives the emulation. Each frame:
// 1. Run emulator core for one frame
// 2. The core renders to its internal buffer
// 3. We copy to canvas (handled by Emscripten SDL typically)
// 4. Calculate FPS
// ============================================================

function startEmulationLoop() {
  if (!State.running) return;

  function frame() {
    if (!State.running) return;

    try {
      // Let the Emscripten core run (it handles its own rendering to canvas)
      // Most Emscripten cores use emscripten_set_main_loop or requestAnimationFrame
      // We just need to keep the JS event loop alive

      if (State.module && State.module.resumeGame) {
        // mGBA core handles its own frame loop internally
      }
    } catch (e) {
      console.error('Frame error:', e);
    }

    // FPS calculation
    State.frameCount++;
    const now = performance.now();
    if (now - State.lastFpsTime >= 1000) {
      State.fps = State.frameCount;
      State.frameCount = 0;
      State.lastFpsTime = now;
      document.getElementById('fps-counter').textContent = `${State.fps} fps`;
    }

    requestAnimationFrame(frame);
  }

  State.lastFpsTime = performance.now();
  requestAnimationFrame(frame);
}

// ============================================================
// KEYBOARD INPUT
// ============================================================
// Maps keyboard keys to GBA buttons using the mGBA JS API.
// The core registers button states and reads them each frame.
// ============================================================

document.addEventListener('keydown', (e) => {
  const key = e.key.length === 1 ? e.key.toLowerCase() : e.key;
  if (State.pressedKeys.has(key)) return;
  State.pressedKeys.add(key);

  const gbaBtn = State.keyMap[key];
  if (!gbaBtn) return;
  e.preventDefault();

  if (State.module && State.module.buttonPress) {
    State.module.buttonPress(gbaBtn);
  }
});

document.addEventListener('keyup', (e) => {
  const key = e.key.length === 1 ? e.key.toLowerCase() : e.key;
  State.pressedKeys.delete(key);

  const gbaBtn = State.keyMap[key];
  if (!gbaBtn) return;
  e.preventDefault();

  if (State.module && State.module.buttonUnpress) {
    State.module.buttonUnpress(gbaBtn);
  }
});

// Prevent arrow key scrolling
window.addEventListener('keydown', (e) => {
  if (['ArrowUp','ArrowDown','ArrowLeft','ArrowRight',' '].includes(e.key)) {
    if (State.running) e.preventDefault();
  }
});

// ============================================================
// DISPLAY CONTROLS
// ============================================================

document.getElementById('btn-fullscreen')?.addEventListener('click', () => {
  const vp = document.getElementById('emulator-viewport');
  if (document.fullscreenElement) {
    document.exitFullscreen();
  } else {
    vp?.requestFullscreen();
  }
});

document.getElementById('btn-crt')?.addEventListener('click', () => {
  State.crtEnabled = !State.crtEnabled;
  const overlay = document.getElementById('crt-overlay');
  const btn = document.getElementById('btn-crt');
  if (State.crtEnabled) {
    overlay?.classList.add('active');
    btn.textContent = 'CRT On';
    btn.classList.add('btn-primary');
  } else {
    overlay?.classList.remove('active');
    btn.textContent = 'CRT Off';
    btn.classList.remove('btn-primary');
  }
});

// Canvas scale
document.getElementById('select-scale')?.addEventListener('change', (e) => {
  const scale = parseInt(e.target.value);
  const canvas = document.getElementById('gba-canvas');
  canvas.style.width = `${240 * scale}px`;
  canvas.style.height = `${160 * scale}px`;
});

// ============================================================
// SETTINGS PANEL
// ============================================================

document.getElementById('btn-settings')?.addEventListener('click', () => {
  document.getElementById('settings-panel')?.classList.add('open');
  document.getElementById('settings-overlay')?.classList.add('open');
});

document.getElementById('settings-overlay')?.addEventListener('click', () => {
  document.getElementById('settings-panel')?.classList.remove('open');
  document.getElementById('settings-overlay')?.classList.remove('open');
});

// Toggle handlers
document.querySelectorAll('.toggle').forEach(t => {
  t.addEventListener('click', () => {
    t.classList.toggle('active');
    const id = t.id;
    if (id === 'toggle-crt') {
      State.crtEnabled = t.classList.contains('active');
      document.getElementById('crt-overlay')?.classList.toggle('active', State.crtEnabled);
    } else if (id === 'toggle-autosave') {
      State.autosaveEnabled = t.classList.contains('active');
    } else if (id === 'toggle-smooth') {
      State.smoothScaling = t.classList.contains('active');
      const canvas = document.getElementById('gba-canvas');
      canvas.style.imageRendering = State.smoothScaling ? 'auto' : 'pixelated';
    } else if (id === 'toggle-rewind') {
      // Rewind support placeholder
      log('Rewind: ' + (t.classList.contains('active') ? 'enabled' : 'disabled'));
    }
  });
});

document.getElementById('select-ff')?.addEventListener('change', (e) => {
  State.fastForwardMult = parseInt(e.target.value);
  if (State.fastForward) {
    if (State.module && State.module.setFastForwardMultiplier) {
      State.module.setFastForwardMultiplier(State.fastForwardMult);
    }
  }
});

// ============================================================
// HELP / INFO
// ============================================================

document.getElementById('btn-help')?.addEventListener('click', () => {
  alert(`Aether GBA — Quick Help

1. Click "Load Core" or drop mgba.wasm + mgba.js files
2. Drop a .gba ROM file
3. Use keyboard controls:
   Z=A, X=B, Enter=Start, Shift=Select
   Arrows=D-Pad, A=L, S=R
4. Use Save State / Load State for in-emulator saves
5. Import/Export .sav for battery saves

For the best experience, use a modern browser with WebAssembly support.`);
});

// ============================================================
// INITIALIZATION
// ============================================================

(async function init() {
  await openDB();
  log('Aether GBA initialized');
  log('Drop mgba.wasm + mgba.js (Emscripten files) to begin');
})();

// Expose state for debugging
window.AetherGBA = State;""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
