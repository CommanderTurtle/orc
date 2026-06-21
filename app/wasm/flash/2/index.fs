module ConvertedFiles.Wasm.Flash.N2.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Flashpoint - Flash Game Player (Local)"
            ]
            style [] [
                    rawText ("""/* ============================================================
   FLASHPOINT - FLASH GAME PLAYER (PLACEHOLDER VARIANT)
   Loads Ruffle + SWF from local directory paths.
   Designed for GitHub Pages / static hosting deployment.
   Expected structure:
     ./ruffle/ruffle.js          (Ruffle runtime JS)
     ./ruffle/*.wasm             (Ruffle WASM files)
     ./game/game.swf             (Your Flash game)
   ============================================================ */

*, *::before, *::after { margin:0; padding:0; box-sizing:border-box; }

:root {
  --bg-primary: #0f0e1a;
  --bg-secondary: #1a182e;
  --bg-card: rgba(26,24,46,0.85);
  --accent: #ff6b35;
  --accent-glow: rgba(255,107,53,0.35);
  --accent-secondary: #ff3366;
  --text-primary: #f0e6ff;
  --text-secondary: #9b8fb8;
  --success: #00e5a0;
  --warning: #ffd166;
  --danger: #ff4757;
  --border: rgba(255,255,255,0.08);
  --glass: rgba(26,24,46,0.7);
  --glass-border: rgba(255,255,255,0.1);
}

html, body {
  width:100%; height:100%;
  font-family: 'Segoe UI', system-ui, -apple-system, sans-serif;
  background: var(--bg-primary);
  color: var(--text-primary);
  overflow-x: hidden;
}

/* ---- Animated Particle Background ---- */
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
  10% { opacity: 0.5; }
  90% { opacity: 0.5; }
  100% { transform: translateY(-10vh) scale(1); opacity: 0; }
}
.particle:nth-child(1) { left: 10%; animation-duration: 15s; animation-delay: 0s; }
.particle:nth-child(2) { left: 20%; animation-duration: 20s; animation-delay: 2s; width: 3px; height: 3px; }
.particle:nth-child(3) { left: 30%; animation-duration: 18s; animation-delay: 4s; }
.particle:nth-child(4) { left: 40%; animation-duration: 22s; animation-delay: 1s; width: 4px; height: 4px; background: var(--accent-secondary); }
.particle:nth-child(5) { left: 50%; animation-duration: 16s; animation-delay: 3s; }
.particle:nth-child(6) { left: 60%; animation-duration: 19s; animation-delay: 5s; width: 3px; height: 3px; }
.particle:nth-child(7) { left: 70%; animation-duration: 21s; animation-delay: 2s; background: var(--warning); }
.particle:nth-child(8) { left: 80%; animation-duration: 17s; animation-delay: 4s; }
.particle:nth-child(9) { left: 90%; animation-duration: 23s; animation-delay: 1s; width: 3px; height: 3px; background: var(--accent-secondary); }
.particle:nth-child(10) { left: 15%; animation-duration: 25s; animation-delay: 6s; }

/* ---- Grid Pattern Overlay ---- */
.grid-pattern {
  position: fixed; inset: 0; z-index: 1; pointer-events: none;
  background-image: 
    linear-gradient(rgba(255,107,53,0.03) 1px, transparent 1px),
    linear-gradient(90deg, rgba(255,107,53,0.03) 1px, transparent 1px);
  background-size: 60px 60px;
}

/* ---- App Container ---- */
.app-container { position: relative; z-index: 2; min-height: 100vh; display: flex; flex-direction: column; }

/* ---- Header ---- */
.header {
  display: flex; align-items: center; justify-content: space-between;
  padding: 20px 32px; border-bottom: 1px solid var(--border);
  background: rgba(15,14,26,0.8); backdrop-filter: blur(20px);
  position: sticky; top: 0; z-index: 100;
}
.header-left { display: flex; align-items: center; gap: 14px; }
.logo {
  width: 42px; height: 42px; border-radius: 12px;
  background: linear-gradient(135deg, #ff6b35, #ff3366);
  display: flex; align-items: center; justify-content: center;
  font-size: 20px; box-shadow: 0 4px 16px var(--accent-glow);
  animation: logoPulse 3s ease infinite;
}
@keyframes logoPulse { 0%, 100% { box-shadow: 0 4px 16px var(--accent-glow); } 50% { box-shadow: 0 4px 28px rgba(255,107,53,0.5); } }
.header-title { font-size: 22px; font-weight: 700; letter-spacing: -0.5px; }
.header-subtitle { font-size: 11px; color: var(--text-secondary); letter-spacing: 1px; text-transform: uppercase; }
.header-right { display: flex; align-items: center; gap: 12px; }
.header-btn {
  background: rgba(255,255,255,0.06); border: 1px solid var(--border);
  color: var(--text-primary); border-radius: 10px; padding: 8px 16px;
  font-size: 13px; cursor: pointer; transition: all 0.2s;
}
.header-btn:hover { background: rgba(255,255,255,0.1); border-color: rgba(255,255,255,0.2); }

/* ---- Main Content ---- */
.main { flex: 1; display: flex; flex-direction: column; align-items: center; padding: 32px; gap: 24px; max-width: 1200px; margin: 0 auto; width: 100%; }

/* ---- Status Bar ---- */
.status-bar {
  display: flex; gap: 20px; align-items: center; flex-wrap: wrap;
  background: var(--glass); border: 1px solid var(--glass-border);
  border-radius: 14px; padding: 12px 20px; width: 100%; font-size: 13px;
  backdrop-filter: blur(20px);
}
.status-item { display: flex; align-items: center; gap: 6px; color: var(--text-secondary); }
.status-item.active { color: var(--success); }
.status-dot { width: 7px; height: 7px; border-radius: 50%; background: var(--text-secondary); }
.status-dot.active { background: var(--success); box-shadow: 0 0 8px var(--success); }
.status-dot.warning { background: var(--warning); box-shadow: 0 0 8px var(--warning); }

/* ---- Setup Panel ---- */
.setup-panel {
  width: 100%; max-width: 720px;
  background: var(--glass); border: 1px solid var(--glass-border);
  border-radius: 20px; padding: 28px; backdrop-filter: blur(20px);
  display: flex; flex-direction: column; gap: 20px;
}
.setup-title { font-size: 18px; font-weight: 700; display: flex; align-items: center; gap: 10px; }
.setup-desc { font-size: 13px; color: var(--text-secondary); line-height: 1.6; }
.setup-grid { display: grid; grid-template-columns: repeat(auto-fit, minmax(200px, 1fr)); gap: 12px; }
.setup-field {
  display: flex; flex-direction: column; gap: 6px;
}
.setup-field label { font-size: 12px; color: var(--text-secondary); font-weight: 600; text-transform: uppercase; letter-spacing: 0.5px; }
.setup-field input[type="text"] {
  background: rgba(255,255,255,0.06); border: 1px solid var(--border);
  color: var(--text-primary); border-radius: 10px; padding: 10px 14px;
  font-size: 13px; outline: none; font-family: monospace;
}
.setup-field input[type="text"]:focus { border-color: var(--accent); }
.setup-preset { display: flex; gap: 6px; flex-wrap: wrap; margin-top: 2px; }
.preset-btn {
  background: rgba(255,107,53,0.1); border: 1px solid rgba(255,107,53,0.2);
  color: var(--accent); border-radius: 8px; padding: 4px 10px;
  font-size: 11px; cursor: pointer; transition: all 0.2s;
}
.preset-btn:hover { background: rgba(255,107,53,0.2); }

.setup-hint {
  background: rgba(255,107,53,0.05); border: 1px dashed rgba(255,107,53,0.2);
  border-radius: 12px; padding: 14px; font-size: 12px; color: var(--text-secondary); line-height: 1.6;
}
.setup-hint code {
  background: rgba(255,255,255,0.08); padding: 2px 6px; border-radius: 4px; font-size: 11px;
}

.setup-actions { display: flex; gap: 10px; margin-top: 4px; }
.setup-btn {
  flex: 1; padding: 12px; border-radius: 12px; border: none;
  font-size: 14px; font-weight: 600; cursor: pointer; transition: all 0.2s;
}
.setup-btn.primary { background: linear-gradient(135deg, #ff6b35, #ff3366); color: #fff; }
.setup-btn.primary:hover { opacity: 0.9; transform: translateY(-1px); }
.setup-btn.secondary { background: rgba(255,255,255,0.06); border: 1px solid var(--border); color: var(--text-primary); }
.setup-btn.secondary:hover { background: rgba(255,255,255,0.1); }
.setup-btn:disabled { opacity: 0.4; cursor: not-allowed; transform: none !important; }

/* ---- File Discovery Grid ---- */
.discovery-grid {
  width: 100%; max-width: 720px;
  display: grid; grid-template-columns: repeat(auto-fit, minmax(200px, 1fr)); gap: 10px;
}
.discover-card {
  background: var(--glass); border: 1px solid var(--glass-border);
  border-radius: 14px; padding: 16px; backdrop-filter: blur(20px);
  display: flex; flex-direction: column; gap: 10px;
}
.discover-title { font-size: 13px; font-weight: 600; color: var(--text-secondary); text-transform: uppercase; letter-spacing: 0.5px; }
.discover-files { display: flex; flex-direction: column; gap: 6px; }
.discover-file {
  display: flex; align-items: center; gap: 8px; padding: 8px 10px;
  background: rgba(255,255,255,0.04); border-radius: 8px; font-size: 12px;
  font-family: monospace; word-break: break-all;
}
.discover-file.found { border-left: 2px solid var(--success); color: var(--success); }
.discover-file.missing { border-left: 2px solid var(--danger); color: var(--danger); }
.discover-file.optional { border-left: 2px solid var(--warning); color: var(--warning); }
.discover-status { font-size: 10px; text-transform: uppercase; font-weight: 600; margin-left: auto; flex-shrink: 0; }

/* ---- Game Stage ---- */
.game-stage {
  width: 100%; max-width: 960px; aspect-ratio: 4/3;
  background: #000; border-radius: 16px; overflow: hidden;
  border: 1px solid var(--border); position: relative;
  display: none; box-shadow: 0 8px 40px rgba(0,0,0,0.5);
}
.game-stage.active { display: block; }
.crt-overlay {
  position: absolute; inset: 0; pointer-events: none; z-index: 10;
  background: repeating-linear-gradient(
    0deg, transparent, transparent 2px, rgba(0,0,0,0.08) 2px, rgba(0,0,0,0.08) 4px
  );
  opacity: 0; transition: opacity 0.3s; border-radius: 16px;
}
.crt-overlay.on { opacity: 1; }
.ruffle-player-container {
  width: 100%; height: 100%; display: flex;
  align-items: center; justify-content: center;
}
.ruffle-player-container ruffle-player { width: 100%; height: 100%; }

/* ---- Loading Screen ---- */
.loading-screen {
  position: absolute; inset: 0; z-index: 50;
  background: var(--bg-primary);
  display: none; flex-direction: column;
  align-items: center; justify-content: center; gap: 20px;
}
.loading-screen.active { display: flex; }
.loader {
  width: 48px; height: 48px;
  border: 3px solid rgba(255,107,53,0.15);
  border-top-color: var(--accent); border-radius: 50%;
  animation: spin 0.8s linear infinite;
}
@keyframes spin { to { transform: rotate(360deg); } }
.loader-text { font-size: 14px; color: var(--text-secondary); }

/* ---- Error Screen ---- */
.error-screen {
  position: absolute; inset: 0; z-index: 40;
  background: var(--bg-primary);
  display: none; flex-direction: column;
  align-items: center; justify-content: center; gap: 16px;
  padding: 40px; text-align: center;
}
.error-screen.active { display: flex; }
.error-icon { font-size: 48px; }
.error-title { font-size: 16px; font-weight: 600; color: var(--danger); }
.error-desc { font-size: 13px; color: var(--text-secondary); line-height: 1.5; max-width: 400px; }

/* ---- Controls Bar ---- */
.controls-bar {
  width: 100%; max-width: 960px;
  display: flex; align-items: center; justify-content: space-between;
  gap: 12px; flex-wrap: wrap;
}
.ctrl-btn {
  background: rgba(255,255,255,0.06); border: 1px solid var(--border);
  color: var(--text-primary); border-radius: 10px; padding: 8px 14px;
  font-size: 13px; cursor: pointer; transition: all 0.2s;
  display: flex; align-items: center; gap: 6px;
}
.ctrl-btn:hover { background: rgba(255,255,255,0.1); border-color: rgba(255,255,255,0.2); transform: translateY(-1px); }
.ctrl-btn:active { transform: translateY(0); }
.ctrl-btn.primary { background: linear-gradient(135deg, #ff6b35, #ff3366); border: none; }
.ctrl-btn.primary:hover { opacity: 0.9; }
.ctrl-btn.warn { background: rgba(255,71,87,0.15); border-color: rgba(255,71,87,0.3); color: #ff6b81; }
.ctrl-btn:disabled { opacity: 0.4; cursor: not-allowed; transform: none !important; }

/* ---- Game Info Panel ---- */
.info-panel {
  width: 100%; max-width: 960px;
  background: var(--glass); border: 1px solid var(--glass-border);
  border-radius: 14px; padding: 16px 20px; backdrop-filter: blur(20px);
  display: none; gap: 20px; align-items: center; flex-wrap: wrap;
}
.info-panel.active { display: flex; }
.info-icon { font-size: 28px; }
.info-meta { flex: 1; min-width: 0; }
.info-name { font-size: 15px; font-weight: 600; }
.info-detail { font-size: 12px; color: var(--text-secondary); margin-top: 2px; }

/* ---- Console ---- */
.console {
  width: 100%; max-width: 960px; max-height: 160px; overflow-y: auto;
  background: rgba(0,0,0,0.4); border: 1px solid var(--border);
  border-radius: 10px; padding: 12px 16px; font-family: 'Consolas', 'Monaco', monospace;
  font-size: 11px; display: none; flex-direction: column; gap: 4px;
}
.console.active { display: flex; }
.console-line { color: rgba(255,255,255,0.6); }
.console-line.info { color: #6c9fff; }
.console-line.success { color: var(--success); }
.console-line.warn { color: var(--warning); }
.console-line.error { color: var(--danger); }

/* ---- Settings Panel ---- */
.settings-panel {
  position: fixed; top: 0; right: 0; bottom: 0; width: 340px;
  background: rgba(15,14,26,0.95); backdrop-filter: blur(40px);
  border-left: 1px solid var(--border); z-index: 200;
  transform: translateX(100%);
  transition: transform 0.35s cubic-bezier(0.25,0.46,0.45,0.94);
  padding: 24px; overflow-y: auto; display: flex; flex-direction: column; gap: 20px;
}
.settings-panel.open { transform: translateX(0); }
.settings-overlay {
  position: fixed; inset: 0; background: rgba(0,0,0,0.3);
  z-index: 199; opacity: 0; pointer-events: none;
  transition: opacity 0.3s;
}
.settings-overlay.open { opacity: 1; pointer-events: all; }
.settings-header { display: flex; align-items: center; justify-content: space-between; }
.settings-title { font-size: 18px; font-weight: 700; }
.settings-close { background: none; border: none; color: var(--text-secondary); font-size: 24px; cursor: pointer; }
.settings-section { display: flex; flex-direction: column; gap: 10px; }
.settings-label { font-size: 11px; color: var(--text-secondary); text-transform: uppercase; letter-spacing: 1px; font-weight: 600; }
.settings-row { display: flex; align-items: center; justify-content: space-between; gap: 12px; }
.settings-desc { font-size: 11px; color: rgba(255,255,255,0.35); margin-top: 2px; }
.toggle {
  width: 44px; height: 26px; background: rgba(255,255,255,0.15);
  border-radius: 13px; position: relative; cursor: pointer; transition: background 0.2s; flex-shrink: 0;
}
.toggle::after { content: ''; position: absolute; width: 22px; height: 22px; background: #fff; border-radius: 50%; top: 2px; left: 2px; transition: transform 0.2s; }
.toggle.on { background: var(--accent); }
.toggle.on::after { transform: translateX(18px); }
select.styled {
  background: rgba(255,255,255,0.06); border: 1px solid var(--border);
  color: var(--text-primary); border-radius: 8px; padding: 8px 12px;
  font-size: 13px; outline: none; cursor: pointer;
}

/* ---- Keyboard Shortcuts ---- */
.kbd-shortcuts {
  width: 100%; max-width: 960px;
  background: var(--glass); border: 1px solid var(--glass-border);
  border-radius: 14px; padding: 16px 20px; backdrop-filter: blur(20px);
  display: none; gap: 12px; flex-wrap: wrap;
}
.kbd-shortcuts.active { display: flex; }
.kbd-item { display: flex; align-items: center; gap: 8px; font-size: 12px; color: var(--text-secondary); }
kbd {
  background: rgba(255,255,255,0.1); border: 1px solid rgba(255,255,255,0.15);
  border-radius: 5px; padding: 3px 8px; font-size: 11px; font-family: monospace;
  color: var(--text-primary); box-shadow: 0 2px 0 rgba(0,0,0,0.2);
}

/* ---- Footer ---- */
.footer {
  text-align: center; padding: 20px;
  font-size: 12px; color: rgba(255,255,255,0.25);
  border-top: 1px solid var(--border);
}

/* ---- Responsive ---- */
@media (max-width: 768px) {
  .header { padding: 16px; }
  .main { padding: 20px 16px; }
  .game-stage { aspect-ratio: 16/10; }
  .settings-panel { width: 100%; }
}

::-webkit-scrollbar { width: 5px; }
::-webkit-scrollbar-track { background: transparent; }
::-webkit-scrollbar-thumb { background: rgba(255,255,255,0.12); border-radius: 4px; }""")
            ]
        ]
        body [] [
            rawText ("""<!--  Background Effects  -->""")
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
            ]
            div [ _class "grid-pattern" ] []
            div [ _class "app-container" ] [
                rawText ("""<!--  Header  -->""")
                header [ _class "header" ] [
                    div [ _class "header-left" ] [
                        div [ _class "logo" ] [
                            str "⚡"
                        ]
                        div [] [
                            div [ _class "header-title" ] [
                                str "Flashpoint"
                            ]
                            div [ _class "header-subtitle" ] [
                                str "Flash Game Player • Local Files"
                            ]
                        ]
                    ]
                    div [ _class "header-right" ] [
                        button [ _class "header-btn"; _id "btnShortcuts"; attr "title" "Keyboard Shortcuts" ] [
                            str "⌨ Shortcuts"
                        ]
                        button [ _class "header-btn"; _id "btnConsole"; attr "title" "Toggle Console" ] [
                            str "💬 Console"
                        ]
                        button [ _class "header-btn"; _id "btnSettings"; attr "title" "Settings" ] [
                            str "⚙ Settings"
                        ]
                    ]
                ]
                rawText ("""<!--  Main Content  -->""")
                main [ _class "main"; _id "mainContent" ] [
                    rawText ("""<!--  Status Bar  -->""")
                    div [ _class "status-bar"; _id "statusBar" ] [
                        div [ _class "status-item"; _id "stRuffle" ] [
                            span [ _class "status-dot"; _id "dotRuffle" ] []
                            span [] [
                                str "Ruffle Runtime"
                            ]
                        ]
                        div [ _class "status-item"; _id "stSwf" ] [
                            span [ _class "status-dot"; _id "dotSwf" ] []
                            span [] [
                                str "SWF Game"
                            ]
                        ]
                        div [ _class "status-item" ] [
                            span [ _class "status-dot"; _id "dotReady" ] []
                            span [ _id "txtReady" ] [
                                str "Ready"
                            ]
                        ]
                        div [ _class "status-item"; attr "style" "margin-left:auto" ] [
                            span [ _id "fpsCounter" ] [
                                str "-- fps"
                            ]
                        ]
                    ]
                    rawText ("""<!--  Setup Panel  -->""")
                    div [ _class "setup-panel"; _id "setupPanel" ] [
                        div [ _class "setup-title" ] [
                            str "🔧 Setup Configuration"
                        ]
                        div [ _class "setup-desc" ] [
                            str "Configure the paths to your Ruffle runtime and Flash game files.\n        The player will auto-detect files from the specified directories."
                        ]
                        div [ _class "setup-grid" ] [
                            div [ _class "setup-field" ] [
                                label [] [
                                    str "Ruffle Path"
                                ]
                                input [ _type "text"; _id "rufflePath"; attr "value" "./ruffle/"; attr "placeholder" "./ruffle/" ]
                                div [ _class "setup-preset" ] [
                                    button [ _class "preset-btn"; attr "data-path" "./ruffle/" ] [
                                        str "./ruffle/"
                                    ]
                                    button [ _class "preset-btn"; attr "data-path" "./lib/ruffle/" ] [
                                        str "./lib/ruffle/"
                                    ]
                                    button [ _class "preset-btn"; attr "data-path" "/ruffle/" ] [
                                        str "/ruffle/"
                                    ]
                                ]
                            ]
                            div [ _class "setup-field" ] [
                                label [] [
                                    str "Game Path"
                                ]
                                input [ _type "text"; _id "gamePath"; attr "value" "./game/"; attr "placeholder" "./game/" ]
                                div [ _class "setup-preset" ] [
                                    button [ _class "preset-btn"; attr "data-game" "./game/" ] [
                                        str "./game/"
                                    ]
                                    button [ _class "preset-btn"; attr "data-game" "./games/" ] [
                                        str "./games/"
                                    ]
                                    button [ _class "preset-btn"; attr "data-game" "./swf/" ] [
                                        str "./swf/"
                                    ]
                                ]
                            ]
                            div [ _class "setup-field" ] [
                                label [] [
                                    str "SWF Filename"
                                ]
                                input [ _type "text"; _id "swfName"; attr "value" "game.swf"; attr "placeholder" "game.swf" ]
                                div [ _class "setup-preset" ] [
                                    button [ _class "preset-btn"; attr "data-swf" "game.swf" ] [
                                        str "game.swf"
                                    ]
                                    button [ _class "preset-btn"; attr "data-swf" "index.swf" ] [
                                        str "index.swf"
                                    ]
                                    button [ _class "preset-btn"; attr "data-swf" "movie.swf" ] [
                                        str "movie.swf"
                                    ]
                                ]
                            ]
                        ]
                        div [ _class "setup-hint" ] [
                            strong [] [
                                str "Expected directory structure:"
                            ]
                            br []
                            code [ _id "hintStructure" ] [
                                str "./ruffle/ruffle.js"
                            ]
                            str "(Ruffle runtime)"
                            br []
                            code [ _id "hintWasm" ] [
                                str "./ruffle/*.wasm"
                            ]
                            str "(WASM binary files)"
                            br []
                            code [ _id "hintSwf" ] [
                                str "./game/game.swf"
                            ]
                            str "(Your Flash game)"
                            br []
                            br []
                            span [ attr "style" "color:var(--warning)" ] [
                                str "⚠"
                            ]
                            str "This page must be served from a web server (not file://) for WASM to work correctly."
                        ]
                        div [ _class "setup-actions" ] [
                            button [ _class "setup-btn secondary"; _id "btnDetect" ] [
                                str "🔍 Detect Files"
                            ]
                            button [ _class "setup-btn primary"; _id "btnLaunch"; attr "disabled" "" ] [
                                str "▶ Launch Game"
                            ]
                        ]
                    ]
                    rawText ("""<!--  File Discovery Grid  -->""")
                    div [ _class "discovery-grid"; _id "discoveryGrid"; attr "style" "display:none" ] []
                    rawText ("""<!--  Game Info  -->""")
                    div [ _class "info-panel"; _id "infoPanel" ] [
                        div [ _class "info-icon" ] [
                            str "🎮"
                        ]
                        div [ _class "info-meta" ] [
                            div [ _class "info-name"; _id "infoName" ] [
                                str "Game Title"
                            ]
                            div [ _class "info-detail"; _id "infoDetail" ] [
                                str "Local file • Unknown dimensions"
                            ]
                        ]
                    ]
                    rawText ("""<!--  Game Stage  -->""")
                    div [ _class "game-stage"; _id "gameStage" ] [
                        div [ _class "loading-screen"; _id "loadingScreen" ] [
                            div [ _class "loader" ] []
                            div [ _class "loader-text"; _id "loaderText" ] [
                                str "Loading Ruffle..."
                            ]
                        ]
                        div [ _class "error-screen"; _id "errorScreen" ] [
                            div [ _class "error-icon" ] [
                                str "🚫"
                            ]
                            div [ _class "error-title"; _id "errorTitle" ] [
                                str "Failed to Load"
                            ]
                            div [ _class "error-desc"; _id "errorDesc" ] [
                                str "Check that the file paths are correct and the server is configured to serve .wasm files with MIME type application/wasm."
                            ]
                            button [ _class "ctrl-btn"; _id "btnRetry"; attr "style" "margin-top:8px" ] [
                                str "↻ Retry"
                            ]
                        ]
                        div [ _class "crt-overlay"; _id "crtOverlay" ] []
                        div [ _class "ruffle-player-container"; _id "playerContainer" ] []
                    ]
                    rawText ("""<!--  Controls Bar  -->""")
                    div [ _class "controls-bar"; _id "controlsBar"; attr "style" "display:none" ] [
                        div [ attr "style" "display:flex;gap:8px" ] [
                            button [ _class "ctrl-btn primary"; _id "btnPlay" ] [
                                str "▶ Play"
                            ]
                            button [ _class "ctrl-btn"; _id "btnPause" ] [
                                str "❚❚ Pause"
                            ]
                            button [ _class "ctrl-btn"; _id "btnReload" ] [
                                str "↻ Reload"
                            ]
                            button [ _class "ctrl-btn"; _id "btnFullscreen" ] [
                                str "⛶ Fullscreen"
                            ]
                        ]
                        div [ attr "style" "display:flex;gap:8px" ] [
                            button [ _class "ctrl-btn"; _id "btnCrt" ] [
                                str "📺 CRT"
                            ]
                            button [ _class "ctrl-btn"; _id "btnBack" ] [
                                str "⏏ Back to Setup"
                            ]
                        ]
                    ]
                    rawText ("""<!--  Keyboard Shortcuts  -->""")
                    div [ _class "kbd-shortcuts"; _id "kbdShortcuts" ] [
                        div [ _class "kbd-item" ] [
                            kbd [] [
                                str "F"
                            ]
                            span [] [
                                str "Fullscreen"
                            ]
                        ]
                        div [ _class "kbd-item" ] [
                            kbd [] [
                                str "R"
                            ]
                            span [] [
                                str "Reload"
                            ]
                        ]
                        div [ _class "kbd-item" ] [
                            kbd [] [
                                str "P"
                            ]
                            span [] [
                                str "Pause/Play"
                            ]
                        ]
                        div [ _class "kbd-item" ] [
                            kbd [] [
                                str "C"
                            ]
                            span [] [
                                str "CRT Toggle"
                            ]
                        ]
                        div [ _class "kbd-item" ] [
                            kbd [] [
                                str "Esc"
                            ]
                            span [] [
                                str "Exit Fullscreen"
                            ]
                        ]
                    ]
                    rawText ("""<!--  Console  -->""")
                    div [ _class "console"; _id "console" ] []
                ]
                footer [ _class "footer" ] [
                    str "Flashpoint v1.0 • Ruffle-powered Flash emulator • Designed for GitHub Pages • No external API calls"
                ]
            ]
            rawText ("""<!--  Settings Overlay  -->""")
            div [ _class "settings-overlay"; _id "settingsOverlay" ] []
            rawText ("""<!--  Settings Panel  -->""")
            aside [ _class "settings-panel"; _id "settingsPanel" ] [
                div [ _class "settings-header" ] [
                    div [ _class "settings-title" ] [
                        str "Settings"
                    ]
                    button [ _class "settings-close"; _id "settingsClose" ] [
                        str "×"
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-label" ] [
                        str "Playback"
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "Autoplay"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Start playing automatically"
                            ]
                        ]
                        div [ _class "toggle on"; attr "data-cfg" "autoplay"; _id "togAutoplay" ] []
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "Unmute Overlay"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Show click-to-play overlay"
                            ]
                        ]
                        div [ _class "toggle on"; attr "data-cfg" "unmuteOverlay"; _id "togUnmute" ] []
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "Letterboxing"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Preserve aspect ratio"
                            ]
                        ]
                        select [ _class "styled"; _id "selLetterbox" ] [
                            option [ attr "value" "fullscreen" ] [
                                str "Fullscreen"
                            ]
                            option [ attr "value" "on"; attr "selected" "" ] [
                                str "On"
                            ]
                            option [ attr "value" "off" ] [
                                str "Off"
                            ]
                        ]
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "Scale Mode"
                            ]
                            div [ _class "settings-desc" ] [
                                str "How SWF fills the stage"
                            ]
                        ]
                        select [ _class "styled"; _id "selScale" ] [
                            option [ attr "value" "showAll"; attr "selected" "" ] [
                                str "Show All"
                            ]
                            option [ attr "value" "exactFit" ] [
                                str "Exact Fit"
                            ]
                            option [ attr "value" "noBorder" ] [
                                str "No Border"
                            ]
                            option [ attr "value" "noScale" ] [
                                str "No Scale"
                            ]
                        ]
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-label" ] [
                        str "Display"
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "CRT Scanlines"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Retro CRT effect overlay"
                            ]
                        ]
                        div [ _class "toggle"; attr "data-cfg" "crt"; _id "togCrt" ] []
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "Quality"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Rendering quality"
                            ]
                        ]
                        select [ _class "styled"; _id "selQuality" ] [
                            option [ attr "value" "high"; attr "selected" "" ] [
                                str "High"
                            ]
                            option [ attr "value" "medium" ] [
                                str "Medium"
                            ]
                            option [ attr "value" "low" ] [
                                str "Low"
                            ]
                        ]
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "WMode"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Window mode"
                            ]
                        ]
                        select [ _class "styled"; _id "selWmode" ] [
                            option [ attr "value" "window" ] [
                                str "Window"
                            ]
                            option [ attr "value" "opaque" ] [
                                str "Opaque"
                            ]
                            option [ attr "value" "transparent"; attr "selected" "" ] [
                                str "Transparent"
                            ]
                        ]
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-label" ] [
                        str "Advanced"
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "Warn on Unsupported"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Show AS3 warnings"
                            ]
                        ]
                        div [ _class "toggle on"; attr "data-cfg" "warnUnsupported"; _id "togWarn" ] []
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "Context Menu"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Right-click menu"
                            ]
                        ]
                        div [ _class "toggle on"; attr "data-cfg" "contextMenu"; _id "togContext" ] []
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "Preloader"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Show loading screen"
                            ]
                        ]
                        div [ _class "toggle on"; attr "data-cfg" "preloader"; _id "togPreloader" ] []
                    ]
                ]
                div [ _class "settings-section" ] [
                    div [ _class "settings-label" ] [
                        str "About"
                    ]
                    div [ attr "style" "font-size:12px;color:var(--text-secondary);line-height:1.6" ] [
                        p [] [
                            strong [] [
                                str "Flashpoint"
                            ]
                            str "loads Flash games from local directories using the Ruffle emulator."
                        ]
                        p [ attr "style" "margin-top:8px" ] [
                            str "Place your"
                            code [ attr "style" "background:rgba(255,255,255,0.08);padding:2px 6px;border-radius:4px" ] [
                                str "ruffle.js"
                            ]
                            str "runtime and"
                            code [ attr "style" "background:rgba(255,255,255,0.08);padding:2px 6px;border-radius:4px" ] [
                                str ".swf"
                            ]
                            str "game files in the configured directories."
                        ]
                        p [ attr "style" "margin-top:8px" ] [
                            str "Designed for GitHub Pages, Vercel, Netlify, or any static host."
                        ]
                    ]
                ]
            ]
            script [] [
                    rawText ("""// ===================== STATE =====================
const state = {
  paths: { ruffle: './ruffle/', game: './game/', swf: 'game.swf' },
  detected: { ruffleJs: false, wasmFiles: [], swfFile: false },
  player: null,
  ruffleLoaded: false,
  swfLoaded: false,
  isPlaying: false,
  crtEnabled: false,
  config: {
    autoplay: 'on',
    unmuteOverlay: 'visible',
    letterbox: 'on',
    scale: 'showAll',
    quality: 'high',
    wmode: 'transparent',
    warnOnUnsupportedContent: true,
    contextMenu: true,
    preloader: true
  }
};

// ===================== LOGGING =====================
const consoleEl = document.getElementById('console');
function log(msg, type = 'info') {
  const time = new Date().toLocaleTimeString('en-US', { hour12: false });
  const line = document.createElement('div');
  line.className = `console-line ${type}`;
  line.textContent = `[${time}] ${msg}`;
  consoleEl.appendChild(line);
  consoleEl.scrollTop = consoleEl.scrollHeight;
  console.log(`[Flashpoint] ${msg}`);
}

// ===================== PATH MANAGEMENT =====================
const rufflePathInput = document.getElementById('rufflePath');
const gamePathInput = document.getElementById('gamePath');
const swfNameInput = document.getElementById('swfName');

function updatePaths() {
  let rp = rufflePathInput.value.trim();
  let gp = gamePathInput.value.trim();
  let sn = swfNameInput.value.trim();

  if (!rp.endsWith('/')) rp += '/';
  if (!gp.endsWith('/')) gp += '/';

  state.paths.ruffle = rp;
  state.paths.game = gp;
  state.paths.swf = sn;

  // Update hint
  document.getElementById('hintStructure').textContent = rp + 'ruffle.js';
  document.getElementById('hintWasm').textContent = rp + '*.wasm';
  document.getElementById('hintSwf').textContent = gp + sn;
}

[rufflePathInput, gamePathInput, swfNameInput].forEach(el => {
  el.addEventListener('input', updatePaths);
});

// Preset buttons
document.querySelectorAll('.preset-btn').forEach(btn => {
  btn.addEventListener('click', () => {
    if (btn.dataset.path) rufflePathInput.value = btn.dataset.path;
    if (btn.dataset.game) gamePathInput.value = btn.dataset.game;
    if (btn.dataset.swf) swfNameInput.value = btn.dataset.swf;
    updatePaths();
    log(`Preset applied: ${btn.textContent}`, 'info');
  });
});

// ===================== FILE DETECTION =====================
async function detectFiles() {
  updatePaths();
  log('Detecting files...', 'info');

  const grid = document.getElementById('discoveryGrid');
  grid.style.display = 'grid';
  grid.innerHTML = '<div class="discover-card" style="grid-column:1/-1;text-align:center;padding:24px"><div class="loader" style="margin:0 auto 12px"></div><div style="font-size:13px;color:var(--text-secondary)">Scanning directories...</div></div>';

  const checks = [];
  const ruffleJsUrl = state.paths.ruffle + 'ruffle.js';

  // Check ruffle.js
  checks.push(checkFile(ruffleJsUrl, 'ruffle.js', true));
  // Check common WASM files
  checks.push(checkFile(state.paths.ruffle + '8870d664631509b2a8c7.wasm', 'core WASM', true));
  checks.push(checkFile(state.paths.ruffle + 'ruffle_web_bg.wasm', 'alt WASM name', true));
  // Check SWF
  const swfUrl = state.paths.game + state.paths.swf;
  checks.push(checkFile(swfUrl, state.paths.swf, true));
  // Optional: check for other SWFs in game dir
  checks.push(checkFile(state.paths.game + 'index.swf', 'index.swf (alt)', false));

  const results = await Promise.allSettled(checks);

  state.detected.ruffleJs = results[0]?.value?.ok || false;
  state.detected.wasmFiles = results.filter((r, i) => i > 0 && i < 3 && r.value?.ok).map(r => r.value.name);
  state.detected.swfFile = results[3]?.value?.ok || false;

  renderDiscovery(results.map(r => r.value || r.reason));

  const canLaunch = state.detected.ruffleJs && state.detected.swfFile;
  document.getElementById('btnLaunch').disabled = !canLaunch;

  if (canLaunch) {
    log('All required files found! Ready to launch.', 'success');
  } else {
    log('Some files are missing. Check the discovery panel.', 'warn');
  }
}

async function checkFile(url, label, required) {
  try {
    const resp = await fetch(url, { method: 'HEAD', cache: 'no-cache' });
    if (resp.ok) {
      const size = resp.headers.get('content-length');
      return { url, name: label, ok: true, size: size ? parseInt(size) : null, required };
    }
    return { url, name: label, ok: false, status: resp.status, required };
  } catch (e) {
    return { url, name: label, ok: false, error: e.message, required };
  }
}

function renderDiscovery(results) {
  const grid = document.getElementById('discoveryGrid');

  const ruffleResults = results.filter(r => r.name === 'ruffle.js' || r.name.includes('WASM'));
  const swfResults = results.filter(r => r.name.includes('.swf'));

  function renderCard(title, items) {
    const found = items.filter(i => i.ok);
    const files = items.map(item => {
      const cls = item.ok ? 'found' : (item.required ? 'missing' : 'optional');
      const icon = item.ok ? '&#10003;' : (item.required ? '&#10007;' : '&#9675;');
      const size = item.size ? `(${(item.size/1024).toFixed(1)} KB)` : '';
      return `<div class="discover-file ${cls}"><span>${icon}</span><span>${item.name} ${size}</span><span class="discover-status">${item.ok ? 'FOUND' : (item.required ? 'MISSING' : 'NOT FOUND')}</span></div>`;
    }).join('');

    return `<div class="discover-card">
      <div class="discover-title">${title} (${found.length}/${items.length})</div>
      <div class="discover-files">${files}</div>
    </div>`;
  }

  grid.innerHTML = renderCard('Ruffle Runtime', ruffleResults) + renderCard('Game Files', swfResults);
}

// ===================== LAUNCH GAME =====================
async function launchGame() {
  updatePaths();
  showSetup(false);
  showLoading(true, 'Loading Ruffle runtime...');
  log('Launching game...', 'info');

  try {
    // Step 1: Load ruffle.js via script tag
    const ruffleJsUrl = state.paths.ruffle + 'ruffle.js';
    await loadScript(ruffleJsUrl);
    state.ruffleLoaded = true;
    log('Ruffle runtime loaded', 'success');
    updateStatusBar();

    // Step 2: Wait for Ruffle API
    showLoading(true, 'Initializing player...');
    await waitForRuffle();

    // Step 3: Create player
    showLoading(true, 'Creating player...');
    await createPlayer();

    // Step 4: Load SWF
    showLoading(true, 'Loading game...');
    const swfUrl = state.paths.game + state.paths.swf;
    await loadSWF(swfUrl);
    state.swfLoaded = true;

    // Step 5: Show game
    showLoading(false);
    showGameStage();
    log('Game launched successfully!', 'success');
    updateStatusBar();

  } catch (err) {
    showLoading(false);
    showError('Failed to Launch', err.message);
    log(`Launch error: ${err.message}`, 'error');
    console.error(err);
  }
}

function loadScript(src) {
  return new Promise((resolve, reject) => {
    // Check if already loaded
    const existing = document.querySelector(`script[src="${src}"]`);
    if (existing) { resolve(); return; }

    const script = document.createElement('script');
    script.src = src;
    script.onload = () => resolve();
    script.onerror = () => reject(new Error(`Failed to load: ${src}`));
    document.head.appendChild(script);
  });
}

function waitForRuffle() {
  return new Promise((resolve, reject) => {
    let attempts = 0;
    const max = 100;
    const iv = setInterval(() => {
      attempts++;
      if (window.RufflePlayer && window.RufflePlayer.newest) {
        clearInterval(iv);
        log('Ruffle API ready');
        resolve();
      } else if (attempts >= max) {
        clearInterval(iv);
        reject(new Error('Ruffle init timeout'));
      }
    }, 100);
  });
}

function createPlayer() {
  const ruffle = window.RufflePlayer.newest();
  if (!ruffle) throw new Error('Ruffle not available');

  window.RufflePlayer.config = {
    autoplay: state.config.autoplay,
    unmuteOverlay: state.config.unmuteOverlay,
    letterbox: state.config.letterbox,
    scale: state.config.scale,
    quality: state.config.quality,
    wmode: state.config.wmode,
    warnOnUnsupportedContent: state.config.warnOnUnsupportedContent,
    contextMenu: state.config.contextMenu,
    preloader: state.config.preloader,
    publicPath: state.paths.ruffle
  };

  const player = ruffle.createPlayer();
  player.id = 'rufflePlayer';

  const container = document.getElementById('playerContainer');
  container.innerHTML = '';
  container.appendChild(player);

  state.player = player;
  log('Player created');
}

function loadSWF(url) {
  return new Promise((resolve, reject) => {
    try {
      state.player.load({ url: url, allowScriptAccess: false });
      state.isPlaying = true;

      document.getElementById('infoName').textContent = state.paths.swf;
      document.getElementById('infoDetail').textContent = `Local file &bull; ${state.paths.game}${state.paths.swf}`;

      resolve();
    } catch (err) {
      reject(err);
    }
  });
}

// ===================== UI CONTROLS =====================
function showSetup(show) {
  document.getElementById('setupPanel').style.display = show ? 'flex' : 'none';
  document.getElementById('discoveryGrid').style.display = show ? 'grid' : 'none';
  document.getElementById('controlsBar').style.display = show ? 'none' : 'flex';
}

function showLoading(show, text) {
  const el = document.getElementById('loadingScreen');
  if (show) {
    el.classList.add('active');
    if (text) document.getElementById('loaderText').textContent = text;
  } else {
    el.classList.remove('active');
  }
}

function showError(title, desc) {
  document.getElementById('errorTitle').textContent = title;
  document.getElementById('errorDesc').textContent = desc;
  document.getElementById('errorScreen').classList.add('active');
}

function hideError() {
  document.getElementById('errorScreen').classList.remove('active');
}

function showGameStage() {
  document.getElementById('gameStage').classList.add('active');
  document.getElementById('infoPanel').classList.add('active');
  document.getElementById('controlsBar').style.display = 'flex';
  hideError();
}

function goBack() {
  if (state.player) {
    try { state.player.remove(); } catch(e) {}
    state.player = null;
  }
  state.ruffleLoaded = false;
  state.swfLoaded = false;
  state.isPlaying = false;

  document.getElementById('gameStage').classList.remove('active');
  document.getElementById('infoPanel').classList.remove('active');
  document.getElementById('playerContainer').innerHTML = '';
  hideError();
  showSetup(true);
  updateStatusBar();
}

function updateStatusBar() {
  document.getElementById('dotRuffle').className = 'status-dot ' + (state.ruffleLoaded ? 'active' : '');
  document.getElementById('dotSwf').className = 'status-dot ' + (state.swfLoaded ? 'active' : '');
  const ready = state.ruffleLoaded && state.swfLoaded;
  document.getElementById('dotReady').className = 'status-dot ' + (ready ? 'active' : '');
  document.getElementById('txtReady').textContent = ready ? 'Running' : 'Ready';
}

// Button handlers
document.getElementById('btnDetect').addEventListener('click', detectFiles);
document.getElementById('btnLaunch').addEventListener('click', launchGame);
document.getElementById('btnRetry').addEventListener('click', () => { hideError(); launchGame(); });
document.getElementById('btnBack').addEventListener('click', goBack);

document.getElementById('btnPlay').addEventListener('click', () => {
  if (state.player) { state.player.play(); state.isPlaying = true; log('Play'); }
});
document.getElementById('btnPause').addEventListener('click', () => {
  if (state.player) { state.player.pause(); state.isPlaying = false; log('Pause'); }
});
document.getElementById('btnReload').addEventListener('click', () => {
  if (state.player) launchGame();
});
document.getElementById('btnFullscreen').addEventListener('click', toggleFullscreen);
document.getElementById('btnCrt').addEventListener('click', toggleCRT);

function toggleFullscreen() {
  const stage = document.getElementById('gameStage');
  if (!document.fullscreenElement) {
    stage.requestFullscreen().catch(() => {});
  } else {
    document.exitFullscreen();
  }
}

function toggleCRT() {
  state.crtEnabled = !state.crtEnabled;
  document.getElementById('crtOverlay').classList.toggle('on', state.crtEnabled);
  document.getElementById('togCrt').classList.toggle('on', state.crtEnabled);
  log(`CRT ${state.crtEnabled ? 'ON' : 'OFF'}`);
}

// ===================== SETTINGS =====================
const settingsPanel = document.getElementById('settingsPanel');
const settingsOverlay = document.getElementById('settingsOverlay');

document.getElementById('btnSettings').addEventListener('click', () => {
  settingsPanel.classList.add('open');
  settingsOverlay.classList.add('open');
});
document.getElementById('settingsClose').addEventListener('click', closeSettings);
settingsOverlay.addEventListener('click', closeSettings);

function closeSettings() {
  settingsPanel.classList.remove('open');
  settingsOverlay.classList.remove('open');
}

document.querySelectorAll('.toggle').forEach(tog => {
  tog.addEventListener('click', () => {
    tog.classList.toggle('on');
    const key = tog.dataset.cfg;
    if (key === 'crt') toggleCRT();
    else if (key === 'autoplay') state.config.autoplay = tog.classList.contains('on') ? 'on' : 'off';
    else if (key === 'unmuteOverlay') state.config.unmuteOverlay = tog.classList.contains('on') ? 'visible' : 'hidden';
    else if (key === 'warnUnsupported') state.config.warnOnUnsupportedContent = tog.classList.contains('on');
    else if (key === 'contextMenu') state.config.contextMenu = tog.classList.contains('on');
    else if (key === 'preloader') state.config.preloader = tog.classList.contains('on');
  });
});

document.getElementById('selLetterbox').addEventListener('change', e => state.config.letterbox = e.target.value);
document.getElementById('selScale').addEventListener('change', e => state.config.scale = e.target.value);
document.getElementById('selQuality').addEventListener('change', e => state.config.quality = e.target.value);
document.getElementById('selWmode').addEventListener('change', e => state.config.wmode = e.target.value);

// ===================== SHORTCUTS & CONSOLE =====================
document.getElementById('btnShortcuts').addEventListener('click', () => {
  document.getElementById('kbdShortcuts').classList.toggle('active');
});
document.getElementById('btnConsole').addEventListener('click', () => {
  document.getElementById('console').classList.toggle('active');
});

document.addEventListener('keydown', e => {
  if (e.key === 'f' || e.key === 'F') toggleFullscreen();
  if (e.key === 'r' || e.key === 'R') { if (state.player) launchGame(); }
  if (e.key === 'p' || e.key === 'P') { document.getElementById(state.isPlaying ? 'btnPause' : 'btnPlay').click(); }
  if (e.key === 'c' || e.key === 'C') toggleCRT();
  if (e.key === 'Escape' && document.fullscreenElement) document.exitFullscreen();
});

// ===================== FPS COUNTER =====================
let lastTime = performance.now();
let frames = 0;
function tickFPS() {
  frames++;
  const now = performance.now();
  if (now - lastTime >= 1000) {
    document.getElementById('fpsCounter').textContent = `${frames} fps`;
    frames = 0;
    lastTime = now;
  }
  requestAnimationFrame(tickFPS);
}
requestAnimationFrame(tickFPS);

// ===================== INIT =====================
log('Flashpoint placeholder variant initialized', 'success');
log('Configure paths and click "Detect Files" to scan', 'info');
updatePaths();""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
