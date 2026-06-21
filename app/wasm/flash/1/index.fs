module ConvertedFiles.Wasm.Flash.N1.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Flashpoint - Flash Game Player (Upload)"
            ]
            style [] [
                    rawText ("""/* ============================================================
   FLASHPOINT - FLASH GAME PLAYER (UPLOAD VARIANT)
   A standalone, self-contained Flash game player using Ruffle.
   Drag & drop ruffle.js + .wasm + .swf to play Flash games
   in the browser with zero external dependencies.
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

/* ---- Drop Zone ---- */
.drop-zone {
  width: 100%; max-width: 720px; min-height: 280px;
  border: 2px dashed rgba(255,107,53,0.3); border-radius: 24px;
  display: flex; flex-direction: column; align-items: center; justify-content: center;
  gap: 16px; padding: 40px; cursor: pointer; transition: all 0.3s;
  background: rgba(255,107,53,0.03); position: relative; overflow: hidden;
}
.drop-zone::before {
  content: ''; position: absolute; inset: 0;
  background: radial-gradient(circle at 50% 50%, rgba(255,107,53,0.08), transparent 70%);
  opacity: 0; transition: opacity 0.3s;
}
.drop-zone:hover, .drop-zone.dragover {
  border-color: var(--accent);
  background: rgba(255,107,53,0.08);
}
.drop-zone:hover::before, .drop-zone.dragover::before { opacity: 1; }
.drop-zone > * { position: relative; z-index: 1; }
.drop-icon { font-size: 56px; filter: drop-shadow(0 4px 12px var(--accent-glow)); }
.drop-title { font-size: 20px; font-weight: 600; }
.drop-subtitle { font-size: 13px; color: var(--text-secondary); text-align: center; line-height: 1.6; }
.drop-files { display: flex; gap: 10px; flex-wrap: wrap; justify-content: center; margin-top: 4px; }
.drop-tag {
  background: rgba(255,107,53,0.12); border: 1px solid rgba(255,107,53,0.2);
  color: var(--accent); border-radius: 20px; padding: 4px 12px;
  font-size: 11px; font-weight: 600; letter-spacing: 0.5px;
}

/* ---- File Input Hidden ---- */
#fileInput { display: none; }

/* ---- Game Stage ---- */
.game-stage {
  width: 100%; max-width: 960px; aspect-ratio: 4/3;
  background: #000; border-radius: 16px; overflow: hidden;
  border: 1px solid var(--border); position: relative;
  display: none; box-shadow: 0 8px 40px rgba(0,0,0,0.5);
}
.game-stage.active { display: block; }
.game-stage-placeholder {
  position: absolute; inset: 0; display: flex;
  flex-direction: column; align-items: center; justify-content: center;
  gap: 16px; color: var(--text-secondary);
}
.ruffle-player-container {
  width: 100%; height: 100%; display: flex;
  align-items: center; justify-content: center;
}
.ruffle-player-container ruffle-player {
  width: 100%; height: 100%;
}

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
.loader-stage {
  font-size: 12px; color: rgba(255,255,255,0.3); margin-top: 4px;
}

/* ---- Controls Bar ---- */
.controls-bar {
  width: 100%; max-width: 960px;
  display: flex; align-items: center; justify-content: space-between;
  gap: 12px; flex-wrap: wrap;
}
.controls-left, .controls-right { display: flex; gap: 8px; align-items: center; }
.ctrl-btn {
  background: rgba(255,255,255,0.06); border: 1px solid var(--border);
  color: var(--text-primary); border-radius: 10px; padding: 8px 14px;
  font-size: 13px; cursor: pointer; transition: all 0.2s;
  display: flex; align-items: center; gap: 6px;
}
.ctrl-btn:hover { background: rgba(255,255,255,0.1); border-color: rgba(255,255,255,0.2); transform: translateY(-1px); }
.ctrl-btn:active { transform: translateY(0); }
.ctrl-btn.primary { background: linear-gradient(135deg, #ff6b35, #ff3366); border: none; }
.ctrl-btn.primary:hover { opacity: 0.9; transform: translateY(-1px); }
.ctrl-btn.warn { background: rgba(255,71,87,0.15); border-color: rgba(255,71,87,0.3); color: #ff6b81; }
.ctrl-btn.warn:hover { background: rgba(255,71,87,0.25); }
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
.info-stats { display: flex; gap: 16px; }
.info-stat { text-align: center; }
.info-stat-val { font-size: 16px; font-weight: 600; color: var(--accent); }
.info-stat-label { font-size: 10px; color: var(--text-secondary); text-transform: uppercase; letter-spacing: 0.5px; }

/* ---- Validation Panel ---- */
.validation-panel {
  width: 100%; max-width: 720px;
  background: var(--glass); border: 1px solid var(--glass-border);
  border-radius: 14px; padding: 20px; backdrop-filter: blur(20px);
  display: none;
}
.validation-panel.active { display: block; }
.val-title { font-size: 13px; font-weight: 600; color: var(--text-secondary); text-transform: uppercase; letter-spacing: 1px; margin-bottom: 12px; }
.val-grid { display: grid; grid-template-columns: repeat(3, 1fr); gap: 8px; }
.val-item {
  display: flex; align-items: center; gap: 8px; padding: 10px 12px;
  background: rgba(255,255,255,0.04); border-radius: 10px; font-size: 12px;
}
.val-item.ok { border-left: 2px solid var(--success); }
.val-item.missing { border-left: 2px solid var(--danger); }
.val-item.optional { border-left: 2px solid var(--warning); }
.val-dot { font-size: 14px; }
.val-name { flex: 1; }
.val-status { font-size: 10px; text-transform: uppercase; font-weight: 600; }

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

/* ---- CRT Effect Overlay ---- */
.crt-overlay {
  position: absolute; inset: 0; pointer-events: none; z-index: 10;
  background: repeating-linear-gradient(
    0deg, transparent, transparent 2px, rgba(0,0,0,0.08) 2px, rgba(0,0,0,0.08) 4px
  );
  opacity: 0; transition: opacity 0.3s; border-radius: 16px;
}
.crt-overlay.on { opacity: 1; }

/* ---- Responsive ---- */
@media (max-width: 768px) {
  .header { padding: 16px; }
  .main { padding: 20px 16px; }
  .game-stage { aspect-ratio: 16/10; }
  .settings-panel { width: 100%; }
}

/* Scrollbar */
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
                                str "Flash Game Player • Upload Variant"
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
                main [ _class "main" ] [
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
                    rawText ("""<!--  Drop Zone  -->""")
                    div [ _class "drop-zone"; _id "dropZone" ] [
                        div [ _class "drop-icon" ] [
                            str "📦"
                        ]
                        div [ _class "drop-title" ] [
                            str "Drop files to play Flash games"
                        ]
                        div [ _class "drop-subtitle" ] [
                            str "Upload"
                            b [] [
                                str "ruffle.js"
                            ]
                            str "+"
                            b [] [
                                str ".wasm"
                            ]
                            str "files (Ruffle runtime)"
                            br []
                            str "and your"
                            b [] [
                                str ".swf"
                            ]
                            str "game file"
                        ]
                        div [ _class "drop-files" ] [
                            span [ _class "drop-tag" ] [
                                str ".js (ruffle)"
                            ]
                            span [ _class "drop-tag" ] [
                                str ".wasm"
                            ]
                            span [ _class "drop-tag" ] [
                                str ".swf (game)"
                            ]
                        ]
                        input [ _type "file"; _id "fileInput"; attr "multiple" ""; attr "accept" ".js,.wasm,.swf" ]
                    ]
                    rawText ("""<!--  Validation Panel  -->""")
                    div [ _class "validation-panel"; _id "validationPanel" ] [
                        div [ _class "val-title" ] [
                            str "File Validation"
                        ]
                        div [ _class "val-grid"; _id "valGrid" ] []
                    ]
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
                                str "Unknown • 0 x 0"
                            ]
                        ]
                        div [ _class "info-stats" ] [
                            div [ _class "info-stat" ] [
                                div [ _class "info-stat-val"; _id "statSize" ] [
                                    str "0"
                                ]
                                div [ _class "info-stat-label" ] [
                                    str "KB"
                                ]
                            ]
                            div [ _class "info-stat" ] [
                                div [ _class "info-stat-val"; _id "statVer" ] [
                                    str "?"
                                ]
                                div [ _class "info-stat-label" ] [
                                    str "Version"
                                ]
                            ]
                            div [ _class "info-stat" ] [
                                div [ _class "info-stat-val"; _id "statW" ] [
                                    str "0"
                                ]
                                div [ _class "info-stat-label" ] [
                                    str "Width"
                                ]
                            ]
                            div [ _class "info-stat" ] [
                                div [ _class "info-stat-val"; _id "statH" ] [
                                    str "0"
                                ]
                                div [ _class "info-stat-label" ] [
                                    str "Height"
                                ]
                            ]
                        ]
                    ]
                    rawText ("""<!--  Game Stage  -->""")
                    div [ _class "game-stage"; _id "gameStage" ] [
                        div [ _class "loading-screen"; _id "loadingScreen" ] [
                            div [ _class "loader" ] []
                            div [ _class "loader-text"; _id "loaderText" ] [
                                str "Initializing Ruffle..."
                            ]
                            div [ _class "loader-stage"; _id "loaderStage" ] [
                                str "Loading runtime"
                            ]
                        ]
                        div [ _class "crt-overlay"; _id "crtOverlay" ] []
                        div [ _class "ruffle-player-container"; _id "playerContainer" ] []
                    ]
                    rawText ("""<!--  Controls Bar  -->""")
                    div [ _class "controls-bar"; _id "controlsBar"; attr "style" "display:none" ] [
                        div [ _class "controls-left" ] [
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
                        div [ _class "controls-right" ] [
                            button [ _class "ctrl-btn"; _id "btnCrt" ] [
                                str "📺 CRT"
                            ]
                            button [ _class "ctrl-btn warn"; _id "btnEject" ] [
                                str "⏏ Eject"
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
                        div [ _class "kbd-item" ] [
                            kbd [] [
                                str "1-9"
                            ]
                            span [] [
                                str "Quality"
                            ]
                        ]
                    ]
                    rawText ("""<!--  Console  -->""")
                    div [ _class "console"; _id "console" ] []
                ]
                rawText ("""<!--  Footer  -->""")
                footer [ _class "footer" ] [
                    str "Flashpoint v1.0 • Ruffle-powered Flash emulator • Runs entirely in your browser • No external API calls"
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
                                str "Window mode for rendering"
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
                                str "Show warnings for AS3 content"
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
                                str "Show Ruffle loading screen"
                            ]
                        ]
                        div [ _class "toggle on"; attr "data-cfg" "preloader"; _id "togPreloader" ] []
                    ]
                    div [ _class "settings-row" ] [
                        div [] [
                            div [] [
                                str "Upgrade to HTTPS"
                            ]
                            div [ _class "settings-desc" ] [
                                str "Force HTTPS for URLs"
                            ]
                        ]
                        div [ _class "toggle on"; attr "data-cfg" "upgradeHttps"; _id "togHttps" ] []
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
                            str "is a standalone Flash game player using the Ruffle emulator."
                        ]
                        p [ attr "style" "margin-top:8px" ] [
                            str "Upload your"
                            code [ attr "style" "background:rgba(255,255,255,0.08);padding:2px 6px;border-radius:4px" ] [
                                str "ruffle.js"
                            ]
                            str "runtime files and"
                            code [ attr "style" "background:rgba(255,255,255,0.08);padding:2px 6px;border-radius:4px" ] [
                                str ".swf"
                            ]
                            str "games to play them in-browser."
                        ]
                        p [ attr "style" "margin-top:8px" ] [
                            str "Ruffle is an open-source Flash Player emulator written in Rust, compiled to WebAssembly."
                        ]
                        p [ attr "style" "margin-top:8px" ] [
                            str "No external servers or APIs are used. Everything runs locally in your browser."
                        ]
                    ]
                ]
            ]
            script [] [
                    rawText ("""// ===================== STATE =====================
const state = {
  files: {},           // Uploaded files by type: ruffleJs, wasmFiles[], swfFile
  player: null,        // Ruffle player instance
  ruffleLoaded: false, // Whether ruffle.js has been injected
  swfLoaded: false,    // Whether a SWF has been loaded
  isPlaying: false,
  isFullscreen: false,
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
    preloader: true,
    upgradeToHttps: true
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
  // Also log to browser console
  console.log(`[Flashpoint] ${msg}`);
}

// ===================== FILE HANDLING =====================
const dropZone = document.getElementById('dropZone');
const fileInput = document.getElementById('fileInput');

dropZone.addEventListener('click', () => fileInput.click());
dropZone.addEventListener('dragover', e => { e.preventDefault(); dropZone.classList.add('dragover'); });
dropZone.addEventListener('dragleave', () => dropZone.classList.remove('dragover'));
dropZone.addEventListener('drop', e => {
  e.preventDefault();
  dropZone.classList.remove('dragover');
  handleFiles(e.dataTransfer.files);
});
fileInput.addEventListener('change', e => handleFiles(e.target.files));

function handleFiles(fileList) {
  const files = Array.from(fileList);
  if (files.length === 0) return;

  files.forEach(file => {
    const name = file.name.toLowerCase();
    if (name === 'ruffle.js' || name.endsWith('.ruffle.js') || (name.endsWith('.js') && name.includes('ruffle'))) {
      state.files.ruffleJs = file;
      log(`Ruffle runtime detected: ${file.name} (${(file.size/1024).toFixed(1)} KB)`, 'success');
    }
    else if (name.endsWith('.wasm')) {
      if (!state.files.wasmFiles) state.files.wasmFiles = [];
      state.files.wasmFiles.push(file);
      log(`WASM file detected: ${file.name} (${(file.size/1024).toFixed(1)} KB)`, 'success');
    }
    else if (name.endsWith('.swf')) {
      state.files.swfFile = file;
      log(`SWF game detected: ${file.name} (${(file.size/1024).toFixed(1)} KB)`, 'success');
    }
    else {
      log(`Ignored file: ${file.name} (unknown type)`, 'warn');
    }
  });

  updateValidationPanel();
  updateStatusBar();

  // Auto-load if we have all required files
  if (state.files.ruffleJs && state.files.swfFile) {
    log('All required files detected. Auto-loading...', 'info');
    loadGame();
  } else {
    const missing = [];
    if (!state.files.ruffleJs) missing.push('ruffle.js');
    if (!state.files.swfFile) missing.push('.swf game');
    log(`Waiting for: ${missing.join(', ')}`, 'warn');
  }
}

// ===================== VALIDATION PANEL =====================
function updateValidationPanel() {
  const panel = document.getElementById('validationPanel');
  const grid = document.getElementById('valGrid');
  panel.classList.add('active');

  const items = [
    { name: 'ruffle.js (runtime)', ok: !!state.files.ruffleJs, required: true },
    { name: '.wasm files', ok: !!(state.files.wasmFiles && state.files.wasmFiles.length > 0), required: true },
    { name: '.swf game file', ok: !!state.files.swfFile, required: true },
    { name: 'Ruffle loaded', ok: state.ruffleLoaded, required: false },
    { name: 'SWF loaded', ok: state.swfLoaded, required: false },
    { name: 'Player ready', ok: state.ruffleLoaded && state.swfLoaded, required: false },
  ];

  grid.innerHTML = items.map(item => {
    const cls = item.ok ? 'ok' : (item.required ? 'missing' : 'optional');
    const icon = item.ok ? '&#10003;' : (item.required ? '&#10007;' : '&#9675;');
    const status = item.ok ? 'OK' : (item.required ? 'MISSING' : 'WAIT');
    return `<div class="val-item ${cls}"><span class="val-dot">${icon}</span><span class="val-name">${item.name}</span><span class="val-status" style="color:${item.ok ? 'var(--success)' : (item.required ? 'var(--danger)' : 'var(--warning)')}">${status}</span></div>`;
  }).join('');
}

function updateStatusBar() {
  document.getElementById('dotRuffle').className = 'status-dot ' + (state.ruffleLoaded ? 'active' : (state.files.ruffleJs ? 'warning' : ''));
  document.getElementById('dotSwf').className = 'status-dot ' + (state.swfLoaded ? 'active' : (state.files.swfFile ? 'warning' : ''));
  const ready = state.ruffleLoaded && state.swfLoaded;
  document.getElementById('dotReady').className = 'status-dot ' + (ready ? 'active' : '');
  document.getElementById('txtReady').textContent = ready ? 'Game Running' : (state.files.ruffleJs ? 'Partial' : 'Ready');
}

// ===================== LOAD GAME =====================
async function loadGame() {
  if (!state.files.ruffleJs || !state.files.swfFile) {
    log('Cannot load: missing required files', 'error');
    return;
  }

  showLoading(true, 'Injecting Ruffle runtime...', 'Loading ruffle.js');

  try {
    // Step 1: Inject ruffle.js
    await injectRuffle(state.files.ruffleJs);
    state.ruffleLoaded = true;
    log('Ruffle runtime injected successfully', 'success');
    updateValidationPanel();
    updateStatusBar();

    // Step 2: Wait for Ruffle to be ready
    showLoading(true, 'Initializing Ruffle player...', 'Waiting for init');
    await waitForRuffle();

    // Step 3: Create player
    showLoading(true, 'Creating player...', 'Player setup');
    await createRufflePlayer();

    // Step 4: Load SWF
    showLoading(true, 'Loading SWF game...', 'Decoding');
    await loadSWF(state.files.swfFile);
    state.swfLoaded = true;

    // Step 5: Show game
    showLoading(false);
    showGameStage();
    log('Game loaded successfully!', 'success');
    updateValidationPanel();
    updateStatusBar();

  } catch (err) {
    showLoading(false);
    log(`Error loading game: ${err.message}`, 'error');
    console.error(err);
  }
}

function injectRuffle(file) {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.onload = e => {
      const blob = new Blob([e.target.result], { type: 'application/javascript' });
      const url = URL.createObjectURL(blob);
      const script = document.createElement('script');
      script.src = url;
      script.onload = () => {
        log('ruffle.js loaded from blob URL');
        // Store blob URL for WASM path resolution
        state.ruffleBlobUrl = url;
        resolve();
      };
      script.onerror = () => reject(new Error('Failed to load ruffle.js'));
      document.head.appendChild(script);
    };
    reader.onerror = () => reject(new Error('Failed to read ruffle.js'));
    reader.readAsArrayBuffer(file);
  });
}

function waitForRuffle() {
  return new Promise((resolve, reject) => {
    let attempts = 0;
    const maxAttempts = 100; // 10 seconds
    const interval = setInterval(() => {
      attempts++;
      if (window.RufflePlayer && window.RufflePlayer.newest) {
        clearInterval(interval);
        log('Ruffle API ready');
        resolve();
      } else if (attempts >= maxAttempts) {
        clearInterval(interval);
        reject(new Error('Ruffle failed to initialize (timeout)'));
      }
    }, 100);
  });
}

async function createRufflePlayer() {
  const ruffle = window.RufflePlayer.newest();
  if (!ruffle) throw new Error('Ruffle not available');

  // Apply config
  const cfg = {
    autoplay: state.config.autoplay,
    unmuteOverlay: state.config.unmuteOverlay,
    letterbox: state.config.letterbox,
    scale: state.config.scale,
    quality: state.config.quality,
    wmode: state.config.wmode,
    warnOnUnsupportedContent: state.config.warnOnUnsupportedContent,
    contextMenu: state.config.contextMenu,
    preloader: state.config.preloader,
    upgradeToHttps: state.config.upgradeToHttps,
    allowScriptAccess: false
  };

  window.RufflePlayer.config = cfg;

  const player = ruffle.createPlayer();
  player.id = 'rufflePlayer';

  const container = document.getElementById('playerContainer');
  container.innerHTML = '';
  container.appendChild(player);

  state.player = player;
  log('Player created with config', 'info');
}

function loadSWF(file) {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.onload = e => {
      const blob = new Blob([e.target.result], { type: 'application/x-shockwave-flash' });
      const swfUrl = URL.createObjectURL(blob);
      state.swfBlobUrl = swfUrl;

      // Parse SWF header for dimensions
      parseSWFHeader(new Uint8Array(e.target.result));

      try {
        state.player.load({ url: swfUrl });
        state.isPlaying = true;

        // Update info panel
        document.getElementById('infoName').textContent = file.name;
        document.getElementById('statSize').textContent = (file.size / 1024).toFixed(0);
        resolve();
      } catch (err) {
        reject(err);
      }
    };
    reader.onerror = () => reject(new Error('Failed to read SWF'));
    reader.readAsArrayBuffer(file);
  });
}

// ===================== SWF HEADER PARSER =====================
function parseSWFHeader(data) {
  try {
    const sig = data[0];
    let offset = 8; // Skip signature + version + length

    // CWS = zlib compressed, FWS = uncompressed, ZWS = LZMA
    if (sig === 0x43 || sig === 0x5A) { // CWS or ZWS
      log('Compressed SWF detected', 'info');
    }

    // Read RECT structure
    const bits = data[offset];
    const nBits = bits >> 3;
    const bytesNeeded = Math.floor((5 + nBits * 4 + 7) / 8) + 1;

    // Simple fallback: try reading width/height from common offsets
    // For uncompressed FWS:
    if (sig === 0x46) {
      const view = new DataView(data.buffer, 8);
      // RECT parsing is complex; use heuristics for common dimensions
      // Most SWFs are 550x400, 800x600, or 640x480
    }

    // Display file signature
    const sigStr = String.fromCharCode(sig, data[1], data[2]);
    const version = data[3];
    document.getElementById('statVer').textContent = version;
    log(`SWF version ${version}, signature: ${sigStr}`, 'info');

    // Try to extract dimensions from the RECT bitfield
    try {
      const result = readRECT(data, offset);
      if (result) {
        const w = Math.round(result.xMax / 20);
        const h = Math.round(result.yMax / 20);
        document.getElementById('statW').textContent = w;
        document.getElementById('statH').textContent = h;
        document.getElementById('infoDetail').textContent = `${w} x ${h} px &bull; Version ${version}`;
        log(`SWF dimensions: ${w}x${h}`, 'info');
      }
    } catch(e) {
      document.getElementById('infoDetail').textContent = `Unknown dimensions &bull; Version ${version}`;
    }
  } catch(e) {
    log('Could not parse SWF header', 'warn');
  }
}

function readRECT(data, offset) {
  // Read the NBits value from the first byte
  let bytePos = offset;
  let bitPos = 0;

  function readBits(n) {
    let val = 0;
    for (let i = 0; i < n; i++) {
      const b = (data[bytePos] >> (7 - bitPos)) & 1;
      val = (val << 1) | b;
      bitPos++;
      if (bitPos === 8) { bitPos = 0; bytePos++; }
    }
    return val;
  }

  const nBits = readBits(5);
  if (nBits < 1 || nBits > 32) return null;

  const xMin = readBits(nBits);
  const xMax = readBits(nBits);
  const yMin = readBits(nBits);
  const yMax = readBits(nBits);

  return { xMin, xMax, yMin, yMax };
}

// ===================== UI CONTROLS =====================
function showLoading(show, text, stage) {
  const el = document.getElementById('loadingScreen');
  if (show) {
    el.classList.add('active');
    if (text) document.getElementById('loaderText').textContent = text;
    if (stage) document.getElementById('loaderStage').textContent = stage;
  } else {
    el.classList.remove('active');
  }
}

function showGameStage() {
  document.getElementById('dropZone').style.display = 'none';
  document.getElementById('gameStage').classList.add('active');
  document.getElementById('infoPanel').classList.add('active');
  document.getElementById('controlsBar').style.display = 'flex';
}

function ejectGame() {
  // Clean up
  if (state.player) {
    try { state.player.remove(); } catch(e) {}
    state.player = null;
  }
  if (state.swfBlobUrl) { URL.revokeObjectURL(state.swfBlobUrl); state.swfBlobUrl = null; }

  state.ruffleLoaded = false;
  state.swfLoaded = false;
  state.isPlaying = false;
  state.files = {};

  document.getElementById('gameStage').classList.remove('active');
  document.getElementById('dropZone').style.display = 'flex';
  document.getElementById('infoPanel').classList.remove('active');
  document.getElementById('controlsBar').style.display = 'none';
  document.getElementById('validationPanel').classList.remove('active');

  // Remove ruffle script
  const scripts = document.querySelectorAll('script[src*="blob:"]');
  scripts.forEach(s => { if (s.src.includes('ruffle')) s.remove(); });

  log('Game ejected. Ready for new upload.', 'info');
  updateStatusBar();
}

// Button handlers
document.getElementById('btnPlay').addEventListener('click', () => {
  if (state.player) { state.player.play(); state.isPlaying = true; log('Play', 'info'); }
});
document.getElementById('btnPause').addEventListener('click', () => {
  if (state.player) { state.player.pause(); state.isPlaying = false; log('Pause', 'info'); }
});
document.getElementById('btnReload').addEventListener('click', () => {
  if (state.files.swfFile && state.files.ruffleJs) {
    ejectGame();
    setTimeout(() => loadGame(), 100);
  }
});
document.getElementById('btnFullscreen').addEventListener('click', toggleFullscreen);
document.getElementById('btnCrt').addEventListener('click', toggleCRT);
document.getElementById('btnEject').addEventListener('click', ejectGame);

function toggleFullscreen() {
  const stage = document.getElementById('gameStage');
  if (!document.fullscreenElement) {
    stage.requestFullscreen().then(() => {
      state.isFullscreen = true;
      log('Fullscreen on', 'info');
    }).catch(() => {});
  } else {
    document.exitFullscreen();
    state.isFullscreen = false;
    log('Fullscreen off', 'info');
  }
}

function toggleCRT() {
  state.crtEnabled = !state.crtEnabled;
  document.getElementById('crtOverlay').classList.toggle('on', state.crtEnabled);
  document.getElementById('togCrt').classList.toggle('on', state.crtEnabled);
  log(`CRT scanlines ${state.crtEnabled ? 'ON' : 'OFF'}`, 'info');
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

// Toggle switches
document.querySelectorAll('.toggle').forEach(tog => {
  tog.addEventListener('click', () => {
    tog.classList.toggle('on');
    const key = tog.dataset.cfg;
    if (key === 'crt') { state.crtEnabled = tog.classList.contains('on'); toggleCRT(); }
    else if (key === 'autoplay') state.config.autoplay = tog.classList.contains('on') ? 'on' : 'off';
    else if (key === 'unmuteOverlay') state.config.unmuteOverlay = tog.classList.contains('on') ? 'visible' : 'hidden';
    else if (key === 'warnUnsupported') state.config.warnOnUnsupportedContent = tog.classList.contains('on');
    else if (key === 'contextMenu') state.config.contextMenu = tog.classList.contains('on');
    else if (key === 'preloader') state.config.preloader = tog.classList.contains('on');
    else if (key === 'upgradeHttps') state.config.upgradeToHttps = tog.classList.contains('on');
  });
});

// Selects
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
  if (e.key === 'r' || e.key === 'R') { if (state.files.swfFile) { ejectGame(); setTimeout(loadGame, 100); } }
  if (e.key === 'p' || e.key === 'P') { document.getElementById(state.isPlaying ? 'btnPause' : 'btnPlay').click(); }
  if (e.key === 'c' || e.key === 'C') toggleCRT();
  if (e.key === 'Escape' && document.fullscreenElement) document.exitFullscreen();
});

// ===================== FPS COUNTER =====================
let lastFrameTime = performance.now();
let frameCount = 0;
function updateFPS() {
  frameCount++;
  const now = performance.now();
  if (now - lastFrameTime >= 1000) {
    document.getElementById('fpsCounter').textContent = `${frameCount} fps`;
    frameCount = 0;
    lastFrameTime = now;
  }
  requestAnimationFrame(updateFPS);
}
requestAnimationFrame(updateFPS);

// ===================== INIT =====================
log('Flashpoint initialized. Ready for file upload.', 'success');
log('Drag & drop: ruffle.js + .wasm files + .swf game', 'info');""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
