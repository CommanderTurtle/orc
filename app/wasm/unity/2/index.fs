module ConvertedFiles.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Unity WebGL Launcher"
            ]
            style [] [
                    rawText ("""/*==============================================================
    UNITY WEBGL PLACEHOLDER LAUNCHER
    ================================================================
    A standalone HTML page that loads a Unity WebGL game from local
    ./Build/ and ./TemplateData/ directories.

    Expected directory structure:
      ./
      ├── Build/
      │   ├── {game}.data.gz or .br or .data
      │   ├── {game}.framework.js.gz or .br or .framework.js
      │   ├── {game}.wasm.gz or .br or .wasm
      │   └── {game}.loader.js
      ├── TemplateData/
      │   ├── style.css (optional)
      │   ├── favicon.ico (optional)
      │   └── fullscreen-button.png (optional)
      └── index.html (this file)

    Features:
      - Auto-detects build files in ./Build/ directory
      - Supports gzip (.gz) and brotli (.br) compression
      - Supports decompression fallback (.unityweb extension)
      - Dark theme UI with Unity-style loading bar
      - Fullscreen, reload, quit controls
      - Keyboard shortcuts
      - Responsive design with 16:9 aspect ratio preservation
      - Works on GitHub Pages and static hosting

    Unity Loader API:
      createUnityInstance(canvas, config, onProgress)
        .then(unityInstance => { ... })
        .catch(error => { ... })

    Unity Instance Methods:
      unityInstance.SetFullscreen(1)     — Enter fullscreen
      unityInstance.SetFullscreen(0)     — Exit fullscreen
      unityInstance.SendMessage(obj, method, value) — Call C# method
      unityInstance.Quit().then(...)     — Quit and cleanup

       ================================================================
       CSS CUSTOM PROPERTIES — Unity Dark Theme
       ================================================================ */
    :root {
      /* Core palette matching Unity Editor dark theme */
      --unity-bg: #1e1e1e;
      --unity-bg-dark: #151515;
      --unity-bg-panel: #252526;
      --unity-bg-hover: #2d2d30;
      --unity-border: #3e3e42;
      --unity-border-light: #555;
      --unity-text: #cccccc;
      --unity-text-dim: #858585;
      --unity-text-bright: #f0f0f0;

      /* Accent colors */
      --accent-blue: #4fc1ff;
      --accent-blue-dim: #007acc;
      --accent-cyan: #00b4d8;
      --accent-green: #4caf50;
      --accent-orange: #ff9800;
      --accent-red: #f44336;
      --accent-purple: #9c27b0;

      /* Loading bar gradient */
      --loading-gradient: linear-gradient(90deg, var(--accent-blue-dim), var(--accent-cyan), var(--accent-blue));

      /* Typography */
      --font-sans: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
      --font-mono: 'SFMono-Regular', Consolas, 'Liberation Mono', Menlo, Courier, monospace;

      /* Spacing & sizing */
      --radius: 8px;
      --radius-sm: 4px;
      --radius-lg: 12px;
      --shadow-sm: 0 2px 8px rgba(0,0,0,0.3);
      --shadow-md: 0 4px 20px rgba(0,0,0,0.4);
      --shadow-lg: 0 8px 40px rgba(0,0,0,0.5);

      /* Transitions */
      --ease-default: cubic-bezier(0.4, 0, 0.2, 1);
      --transition-fast: 0.15s;
      --transition-normal: 0.3s;
    }

    /* ================================================================
       RESET & BASE
       ================================================================ */
    *, *::before, *::after {
      box-sizing: border-box;
      margin: 0;
      padding: 0;
    }

    html, body {
      width: 100%;
      height: 100%;
      font-family: var(--font-sans);
      background: var(--unity-bg-dark);
      color: var(--unity-text);
      overflow: hidden; /* Full-screen app feel */
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
    }

    /* Selection styling */
    ::selection {
      background: rgba(79, 193, 255, 0.25);
      color: var(--unity-text-bright);
    }

    /* Custom scrollbar */
    ::-webkit-scrollbar { width: 8px; height: 8px; }
    ::-webkit-scrollbar-track { background: var(--unity-bg-dark); }
    ::-webkit-scrollbar-thumb { background: var(--unity-border); border-radius: 4px; }
    ::-webkit-scrollbar-thumb:hover { background: var(--unity-border-light); }

    /* ================================================================
       PARTICLE BACKGROUND CANVAS
       ================================================================ */
    #bg-canvas {
      position: fixed;
      inset: 0;
      z-index: 0;
      pointer-events: none;
      opacity: 0.25;
    }

    /* ================================================================
       MAIN LAYOUT
       ================================================================ */
    .app {
      position: relative;
      z-index: 1;
      width: 100%;
      height: 100%;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      padding: 20px;
    }

    /* ================================================================
       SCREEN SYSTEM — Upload / Loading / Game / Error
       ================================================================ */
    .screen {
      display: none;
      animation: screenEnter 0.4s var(--ease-default) forwards;
    }
    .screen.active { display: flex; }

    @keyframes screenEnter {
      from { opacity: 0; transform: translateY(12px); }
      to   { opacity: 1; transform: translateY(0); }
    }

    /* ================================================================
       SETUP SCREEN — Configuration Panel
       ================================================================ */
    .setup-screen {
      flex-direction: column;
      align-items: center;
      gap: 24px;
      max-width: 640px;
      width: 100%;
    }

    .setup-header {
      text-align: center;
    }
    .setup-header h1 {
      font-size: 1.75rem;
      font-weight: 700;
      letter-spacing: -0.5px;
      margin-bottom: 8px;
      background: linear-gradient(135deg, var(--accent-blue), var(--accent-cyan));
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
      background-clip: text;
    }
    .setup-header p {
      color: var(--unity-text-dim);
      font-size: 0.9rem;
      line-height: 1.5;
    }
    .unity-version-badge {
      display: inline-flex;
      align-items: center;
      gap: 8px;
      margin-top: 14px;
      padding: 6px 16px;
      background: var(--unity-bg-panel);
      border: 1px solid var(--unity-border);
      border-radius: 20px;
      font-family: var(--font-mono);
      font-size: 0.75rem;
      color: var(--unity-text-dim);
    }
    .pulse-dot {
      width: 8px;
      height: 8px;
      border-radius: 50%;
      background: var(--accent-green);
      box-shadow: 0 0 8px var(--accent-green);
      animation: pulse 2s ease infinite;
    }
    @keyframes pulse {
      0%, 100% { opacity: 1; transform: scale(1); }
      50% { opacity: 0.5; transform: scale(0.85); }
    }

    /* --- Glass Panel --- */
    .glass-panel {
      width: 100%;
      background: rgba(37, 37, 38, 0.9);
      backdrop-filter: blur(24px) saturate(1.2);
      -webkit-backdrop-filter: blur(24px) saturate(1.2);
      border: 1px solid var(--unity-border);
      border-radius: var(--radius-lg);
      padding: 24px;
      box-shadow: var(--shadow-lg);
    }

    /* --- Config Form --- */
    .config-section {
      margin-bottom: 20px;
    }
    .config-section:last-child { margin-bottom: 0; }
    .config-label {
      display: flex;
      align-items: center;
      gap: 6px;
      font-size: 0.8rem;
      font-weight: 600;
      text-transform: uppercase;
      letter-spacing: 0.8px;
      color: var(--unity-text-dim);
      margin-bottom: 12px;
    }
    .config-label .hint {
      font-weight: 400;
      text-transform: none;
      letter-spacing: normal;
      color: var(--unity-text-dim);
      opacity: 0.7;
    }

    /* Text Input */
    .config-input {
      width: 100%;
      padding: 10px 14px;
      background: var(--unity-bg-dark);
      border: 1px solid var(--unity-border);
      border-radius: var(--radius-sm);
      color: var(--unity-text);
      font-family: var(--font-mono);
      font-size: 0.85rem;
      transition: border-color var(--transition-fast) var(--ease-default),
                  box-shadow var(--transition-fast) var(--ease-default);
    }
    .config-input:focus {
      outline: none;
      border-color: var(--accent-blue-dim);
      box-shadow: 0 0 0 3px rgba(0, 122, 204, 0.15);
    }
    .config-input::placeholder { color: #666; }

    /* File Grid */
    .file-grid {
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(180px, 1fr));
      gap: 8px;
    }
    .file-detect-card {
      display: flex;
      flex-direction: column;
      gap: 6px;
      padding: 14px;
      background: var(--unity-bg-dark);
      border: 1px solid var(--unity-border);
      border-radius: var(--radius-sm);
      transition: all var(--transition-fast) var(--ease-default);
    }
    .file-detect-card:hover {
      border-color: var(--unity-border-light);
      background: var(--unity-bg-hover);
    }
    .file-detect-card.found {
      border-color: rgba(76, 175, 80, 0.4);
    }
    .file-detect-card.missing {
      border-color: rgba(244, 67, 54, 0.2);
      opacity: 0.7;
    }
    .file-detect-card .file-type-label {
      font-size: 0.7rem;
      text-transform: uppercase;
      letter-spacing: 0.5px;
      color: var(--unity-text-dim);
    }
    .file-detect-card .file-name-val {
      font-family: var(--font-mono);
      font-size: 0.8rem;
      color: var(--unity-text);
      word-break: break-all;
      line-height: 1.3;
    }
    .file-detect-card.found .file-name-val {
      color: var(--accent-green);
    }
    .file-detect-card.missing .file-name-val {
      color: var(--accent-red);
    }
    .file-detect-card .file-status-icon {
      align-self: flex-end;
      font-size: 1rem;
      margin-top: 2px;
    }

    /* --- Action Bar --- */
    .action-bar {
      display: flex;
      gap: 10px;
      margin-top: 20px;
      flex-wrap: wrap;
    }

    /* Button Base */
    .btn {
      display: inline-flex;
      align-items: center;
      justify-content: center;
      gap: 8px;
      padding: 11px 24px;
      border-radius: var(--radius-sm);
      font-size: 0.9rem;
      font-weight: 600;
      font-family: var(--font-sans);
      border: none;
      cursor: pointer;
      transition: all var(--transition-fast) var(--ease-default);
      position: relative;
      overflow: hidden;
    }
    .btn::before {
      content: '';
      position: absolute;
      inset: 0;
      background: linear-gradient(90deg, transparent, rgba(255,255,255,0.06), transparent);
      transform: translateX(-100%);
      transition: transform 0.5s ease;
    }
    .btn:hover::before { transform: translateX(100%); }
    .btn:active { transform: scale(0.97); }
    .btn:disabled {
      opacity: 0.35 !important;
      cursor: not-allowed;
      transform: none !important;
    }

    .btn-primary {
      background: linear-gradient(135deg, #007acc, #00a8e8);
      color: #fff;
      box-shadow: 0 4px 16px rgba(0, 122, 204, 0.3);
    }
    .btn-primary:hover:not(:disabled) {
      box-shadow: 0 6px 24px rgba(0, 122, 204, 0.45);
      transform: translateY(-1px);
    }
    .btn-secondary {
      background: var(--unity-bg-hover);
      color: var(--unity-text);
      border: 1px solid var(--unity-border);
    }
    .btn-secondary:hover:not(:disabled) {
      background: var(--unity-bg-panel);
      border-color: var(--unity-border-light);
    }
    .btn-danger {
      background: rgba(244, 67, 54, 0.1);
      color: #ff6b6b;
      border: 1px solid rgba(244, 67, 54, 0.2);
    }
    .btn-danger:hover:not(:disabled) {
      background: rgba(244, 67, 54, 0.2);
    }
    .btn-icon {
      font-size: 1.05em;
      line-height: 1;
    }

    /* --- Detection Status --- */
    .detect-status {
      display: flex;
      align-items: center;
      gap: 8px;
      padding: 10px 14px;
      border-radius: var(--radius-sm);
      font-size: 0.82rem;
      margin-bottom: 16px;
    }
    .detect-status.success {
      background: rgba(76, 175, 80, 0.08);
      border: 1px solid rgba(76, 175, 80, 0.2);
      color: var(--accent-green);
    }
    .detect-status.error {
      background: rgba(244, 67, 54, 0.08);
      border: 1px solid rgba(244, 67, 54, 0.2);
      color: var(--accent-red);
    }
    .detect-status.info {
      background: rgba(79, 193, 255, 0.06);
      border: 1px solid rgba(79, 193, 255, 0.15);
      color: var(--accent-blue);
    }

    /* ================================================================
       LOADING SCREEN — Unity-Style Loading Bar
       ================================================================ */
    .loading-screen {
      flex-direction: column;
      align-items: center;
      justify-content: center;
      gap: 32px;
      position: fixed;
      inset: 0;
      background: linear-gradient(180deg, #151515 0%, #0a0a0a 100%);
      z-index: 50;
    }

    /* Unity Logo Spinner (4 animated squares) */
    .spinner {
      position: relative;
      width: 72px;
      height: 72px;
    }
    .spinner-square {
      position: absolute;
      width: 22px;
      height: 22px;
      border-radius: 3px;
      background: linear-gradient(135deg, var(--accent-blue-dim), var(--accent-cyan));
      box-shadow: 0 0 12px rgba(0, 180, 216, 0.3);
      animation: spinnerOrbit 1.6s ease-in-out infinite;
    }
    .spinner-square:nth-child(1) { top: 0; left: 25px; animation-delay: 0s; }
    .spinner-square:nth-child(2) { top: 25px; right: 0; animation-delay: 0.15s; }
    .spinner-square:nth-child(3) { bottom: 0; left: 25px; animation-delay: 0.3s; }
    .spinner-square:nth-child(4) { top: 25px; left: 0; animation-delay: 0.45s; }

    @keyframes spinnerOrbit {
      0%, 100% { transform: scale(1) rotate(0deg); opacity: 1; }
      50%      { transform: scale(0.5) rotate(180deg); opacity: 0.4; }
    }

    /* Progress Bar Container */
    .progress-area {
      width: 320px;
      max-width: 80vw;
    }
    .progress-bar-track {
      width: 100%;
      height: 5px;
      background: rgba(255,255,255,0.06);
      border-radius: 3px;
      overflow: hidden;
      margin-bottom: 14px;
    }
    .progress-bar-fill {
      width: 0%;
      height: 100%;
      background: var(--loading-gradient);
      border-radius: 3px;
      transition: width 0.2s var(--ease-default);
      box-shadow: 0 0 12px rgba(0, 180, 216, 0.4);
    }
    .progress-info {
      display: flex;
      justify-content: space-between;
      align-items: center;
      font-family: var(--font-mono);
      font-size: 0.78rem;
    }
    .progress-percentage {
      color: var(--unity-text-bright);
      font-weight: 600;
    }
    .progress-stage {
      color: var(--unity-text-dim);
      font-size: 0.72rem;
    }

    /* Build info during loading */
    .loading-build-info {
      text-align: center;
      color: var(--unity-text-dim);
      font-size: 0.8rem;
      margin-top: 8px;
    }
    .loading-build-info .build-name {
      color: var(--unity-text);
      font-weight: 600;
    }

    /* ================================================================
       GAME SCREEN — Canvas + Controls
       ================================================================ */
    .game-screen {
      flex-direction: column;
      align-items: center;
      gap: 16px;
      width: 100%;
      max-width: 1100px;
    }

    /* Unity Canvas Container */
    .unity-wrapper {
      position: relative;
      width: 100%;
      max-width: 960px;
      aspect-ratio: 16 / 9;
      background: #000;
      border-radius: var(--radius);
      overflow: hidden;
      box-shadow: var(--shadow-lg);
      border: 1px solid var(--unity-border);
    }
    @supports not (aspect-ratio: 16 / 9) {
      .unity-wrapper { padding-top: 56.25%; height: 0; }
    }

    #unity-canvas {
      position: absolute;
      inset: 0;
      width: 100%;
      height: 100%;
      display: block;
      background: #000;
      outline: none;
      -webkit-tap-highlight-color: transparent;
    }

    /* Warning Banner (Unity-style) */
    .warning-banner {
      position: absolute;
      top: 0;
      left: 0;
      right: 0;
      z-index: 20;
      display: none;
    }
    .warning-banner.show { display: block; }
    .warning-banner > div {
      padding: 10px 16px;
      font-size: 0.82rem;
      text-align: center;
      animation: bannerSlide 0.3s var(--ease-default);
    }
    @keyframes bannerSlide {
      from { transform: translateY(-100%); }
      to   { transform: translateY(0); }
    }
    .warning-banner .warn-msg {
      background: rgba(255, 152, 0, 0.88);
      color: #1a1a1a;
    }
    .warning-banner .error-msg {
      background: rgba(244, 67, 54, 0.9);
      color: #fff;
    }

    /* Controls Bar */
    .controls-bar {
      display: flex;
      flex-wrap: wrap;
      align-items: center;
      justify-content: center;
      gap: 8px;
      width: 100%;
    }
    .control-cluster {
      display: flex;
      gap: 6px;
      padding: 5px;
      background: rgba(37, 37, 38, 0.85);
      backdrop-filter: blur(16px);
      border: 1px solid var(--unity-border);
      border-radius: var(--radius-sm);
    }
    .ctrl-btn {
      display: inline-flex;
      align-items: center;
      justify-content: center;
      gap: 6px;
      padding: 8px 14px;
      background: var(--unity-bg-hover);
      border: 1px solid transparent;
      border-radius: 6px;
      color: var(--unity-text);
      font-size: 0.8rem;
      font-weight: 500;
      font-family: var(--font-sans);
      cursor: pointer;
      transition: all var(--transition-fast) var(--ease-default);
    }
    .ctrl-btn:hover {
      background: var(--unity-bg-panel);
      border-color: var(--unity-border-light);
      transform: translateY(-1px);
    }
    .ctrl-btn svg {
      width: 15px;
      height: 15px;
      stroke: currentColor;
      stroke-width: 2;
      fill: none;
      stroke-linecap: round;
      stroke-linejoin: round;
    }

    /* Status Bar */
    .status-bar {
      display: flex;
      align-items: center;
      gap: 16px;
      padding: 8px 20px;
      background: rgba(37, 37, 38, 0.8);
      border: 1px solid var(--unity-border);
      border-radius: 20px;
      font-family: var(--font-mono);
      font-size: 0.75rem;
      color: var(--unity-text-dim);
    }
    .status-dot {
      width: 7px;
      height: 7px;
      border-radius: 50%;
      background: var(--accent-green);
      box-shadow: 0 0 6px var(--accent-green);
    }
    .status-dot.yellow { background: var(--accent-orange); box-shadow: 0 0 6px var(--accent-orange); }
    .status-dot.red { background: var(--accent-red); box-shadow: 0 0 6px var(--accent-red); }

    /* ================================================================
       SHORTCUTS OVERLAY
       ================================================================ */
    .overlay {
      display: none;
      position: fixed;
      inset: 0;
      background: rgba(0,0,0,0.65);
      backdrop-filter: blur(10px);
      -webkit-backdrop-filter: blur(10px);
      z-index: 100;
      align-items: center;
      justify-content: center;
      animation: fadeIn 0.2s ease;
    }
    .overlay.show { display: flex; }
    .overlay-panel {
      background: var(--unity-bg-panel);
      border: 1px solid var(--unity-border);
      border-radius: var(--radius-lg);
      padding: 28px 32px;
      max-width: 400px;
      width: 90%;
      box-shadow: var(--shadow-lg);
    }
    .overlay-header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 20px;
    }
    .overlay-header h3 {
      font-size: 1.1rem;
      font-weight: 600;
    }
    .kbd-row {
      display: flex;
      justify-content: space-between;
      align-items: center;
      padding: 9px 0;
      border-bottom: 1px solid rgba(255,255,255,0.04);
      font-size: 0.85rem;
    }
    .kbd-row:last-child { border-bottom: none; }
    kbd {
      display: inline-block;
      padding: 3px 10px;
      background: var(--unity-bg-dark);
      border: 1px solid var(--unity-border);
      border-radius: 5px;
      font-family: var(--font-mono);
      font-size: 0.78rem;
      color: var(--unity-text-dim);
      box-shadow: 0 3px 0 var(--unity-border);
      min-width: 28px;
      text-align: center;
    }

    /* ================================================================
       CONSOLE / LOG PANEL
       ================================================================ */
    .log-panel {
      width: 100%;
      max-width: 960px;
    }
    .log-toggle-btn {
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 6px;
      width: 100%;
      padding: 8px;
      color: var(--unity-text-dim);
      font-size: 0.76rem;
      font-family: var(--font-sans);
      background: none;
      border: none;
      cursor: pointer;
      transition: color 0.2s;
    }
    .log-toggle-btn:hover { color: var(--unity-text); }
    .log-content {
      display: none;
      background: #0d0d0d;
      border: 1px solid var(--unity-border);
      border-radius: var(--radius-sm);
      padding: 12px;
      max-height: 180px;
      overflow-y: auto;
      font-family: var(--font-mono);
      font-size: 0.74rem;
      line-height: 1.6;
      color: var(--unity-text-dim);
    }
    .log-content.show { display: block; }
    .log-line { padding: 1px 0; }
    .log-line.info  { color: #888; }
    .log-line.ok    { color: var(--accent-green); }
    .log-line.warn  { color: var(--accent-orange); }
    .log-line.err   { color: var(--accent-red); }
    .log-line.debug { color: var(--accent-blue); }
    .log-ts { color: #555; margin-right: 6px; }

    /* ================================================================
       ERROR SCREEN
       ================================================================ */
    .error-screen {
      flex-direction: column;
      align-items: center;
      gap: 20px;
      text-align: center;
      max-width: 500px;
    }
    .error-icon {
      width: 64px;
      height: 64px;
      border-radius: 50%;
      background: rgba(244, 67, 54, 0.1);
      border: 2px solid rgba(244, 67, 54, 0.3);
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 2rem;
      color: var(--accent-red);
    }
    .error-screen h2 {
      color: var(--unity-text-bright);
      font-size: 1.3rem;
    }
    .error-screen p {
      color: var(--unity-text-dim);
      font-size: 0.88rem;
      line-height: 1.6;
    }

    /* ================================================================
       ANIMATIONS
       ================================================================ */
    @keyframes fadeIn {
      from { opacity: 0; }
      to   { opacity: 1; }
    }
    @keyframes fadeSlideUp {
      from { opacity: 0; transform: translateY(16px); }
      to   { opacity: 1; transform: translateY(0); }
    }

    /* ================================================================
       RESPONSIVE
       ================================================================ */
    @media (max-width: 640px) {
      .setup-header h1 { font-size: 1.4rem; }
      .glass-panel { padding: 16px; }
      .file-grid { grid-template-columns: 1fr 1fr; }
      .unity-wrapper { aspect-ratio: 4 / 3; }
      .progress-area { width: 85vw; }
    }""")
            ]
            rawText ("""<!--  Try to load TemplateData style if it exists  -->""")
            link [ attr "rel" "stylesheet"; _href "./TemplateData/style.css"; attr "onerror" "this.remove()" ]
            link [ attr "rel" "shortcut icon"; _href "./TemplateData/favicon.ico"; attr "onerror" "this.remove()" ]
        ]
        body [] [
            rawText ("""<!--  Background Particles  -->""")
            canvas [ _id "bg-canvas" ] []
            rawText ("""<!--  ==================== SHORTCUTS OVERLAY ====================  -->""")
            div [ _class "overlay"; _id "shortcutsOverlay"; attr "onclick" "if(event.target===this)toggleShortcuts()" ] [
                div [ _class "overlay-panel" ] [
                    div [ _class "overlay-header" ] [
                        h3 [] [
                            str "Keyboard Shortcuts"
                        ]
                        button [ _class "ctrl-btn"; attr "onclick" "toggleShortcuts()" ] [
                            str "Close"
                        ]
                    ]
                    div [ _class "kbd-row" ] [
                        span [] [
                            str "Toggle Fullscreen"
                        ]
                        kbd [] [
                            str "F"
                        ]
                    ]
                    div [ _class "kbd-row" ] [
                        span [] [
                            str "Reload Game"
                        ]
                        kbd [] [
                            str "R"
                        ]
                    ]
                    div [ _class "kbd-row" ] [
                        span [] [
                            str "Quit to Setup"
                        ]
                        kbd [] [
                            str "Q"
                        ]
                    ]
                    div [ _class "kbd-row" ] [
                        span [] [
                            str "Toggle Console"
                        ]
                        kbd [] [
                            str "C"
                        ]
                    ]
                    div [ _class "kbd-row" ] [
                        span [] [
                            str "Show Shortcuts"
                        ]
                        kbd [] [
                            str "?"
                        ]
                    ]
                    div [ _class "kbd-row" ] [
                        span [] [
                            str "Blur Canvas / Pause"
                        ]
                        kbd [] [
                            str "Esc"
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  ==================== MAIN APP ====================  -->""")
            div [ _class "app" ] [
                rawText ("""<!--  - -- -- -- -- - SETUP SCREEN - -- -- -- -- -  -->""")
                div [ _class "screen setup-screen active"; _id "setupScreen" ] [
                    div [ _class "setup-header" ] [
                        h1 [] [
                            str "Unity WebGL Launcher"
                        ]
                        p [] [
                            str "Auto-detecting build files from local"
                            code [] [
                                str "./Build/"
                            ]
                            str "directory."
                            br []
                            str "Place your Unity WebGL build here and the game will load automatically."
                        ]
                        div [ _class "unity-version-badge" ] [
                            span [ _class "pulse-dot" ] []
                            span [ _id "detectBadgeText" ] [
                                str "Scanning ./Build/ directory..."
                            ]
                        ]
                    ]
                    div [ _class "glass-panel" ] [
                        rawText ("""<!--  Detection Status  -->""")
                        div [ _class "detect-status info"; _id "detectStatus" ] [
                            str "Scanning for Unity WebGL build files..."
                        ]
                        rawText ("""<!--  Build Name Configuration  -->""")
                        div [ _class "config-section" ] [
                            label [ _class "config-label" ] [
                                str "Build Prefix"
                                span [ _class "hint" ] [
                                    str "— auto-detected from ./Build/ folder"
                                ]
                            ]
                            input [ _type "text"; _class "config-input"; _id "buildPrefixInput"; attr "placeholder" "e.g. 'MyGame' (files: MyGame.data.gz, MyGame.loader.js, ...)"; attr "oninput" "onPrefixChange()" ]
                        ]
                        rawText ("""<!--  Detected Files Grid  -->""")
                        div [ _class "config-section" ] [
                            label [ _class "config-label" ] [
                                str "Detected Build Files"
                            ]
                            div [ _class "file-grid"; _id "fileGrid" ] [
                                rawText ("""<!--  Populated by JS  -->""")
                            ]
                        ]
                        rawText ("""<!--  Build Info  -->""")
                        div [ _class "config-section" ] [
                            label [ _class "config-label" ] [
                                str "Build Info"
                            ]
                            div [ attr "style" "display:grid;grid-template-columns:1fr 1fr;gap:10px;" ] [
                                input [ _type "text"; _class "config-input"; _id "companyNameInput"; attr "placeholder" "Company Name"; attr "value" "My Company" ]
                                input [ _type "text"; _class "config-input"; _id "productNameInput"; attr "placeholder" "Product Name"; attr "value" "Unity Game" ]
                            ]
                        ]
                        rawText ("""<!--  Actions  -->""")
                        div [ _class "action-bar" ] [
                            button [ _class "btn btn-primary"; _id "launchBtn"; attr "onclick" "launchGame()"; attr "disabled" "" ] [
                                span [ _class "btn-icon" ] [
                                    str "▶"
                                ]
                                str "Launch Game"
                            ]
                            button [ _class "btn btn-secondary"; attr "onclick" "rescanBuildDir()" ] [
                                span [ _class "btn-icon" ] [
                                    str "↻"
                                ]
                                str "Rescan"
                            ]
                            button [ _class "btn btn-secondary"; attr "onclick" "toggleShortcuts()" ] [
                                span [ _class "btn-icon" ] [
                                    str "?"
                                ]
                                str "Shortcuts"
                            ]
                            span [ attr "style" "margin-left:auto;color:var(--unity-text-dim);font-size:0.8rem;"; _id "hintText" ] [
                                str "Waiting for build files..."
                            ]
                        ]
                    ]
                ]
                rawText ("""<!--  - -- -- -- -- - LOADING SCREEN - -- -- -- -- -  -->""")
                div [ _class "screen loading-screen"; _id "loadingScreen" ] [
                    div [ _class "spinner" ] [
                        div [ _class "spinner-square" ] []
                        div [ _class "spinner-square" ] []
                        div [ _class "spinner-square" ] []
                        div [ _class "spinner-square" ] []
                    ]
                    div [ _class "progress-area" ] [
                        div [ _class "progress-bar-track" ] [
                            div [ _class "progress-bar-fill"; _id "progressFill" ] []
                        ]
                        div [ _class "progress-info" ] [
                            span [ _class "progress-percentage"; _id "progressPct" ] [
                                str "0%"
                            ]
                            span [ _class "progress-stage"; _id "progressStage" ] [
                                str "Initializing..."
                            ]
                        ]
                    ]
                    div [ _class "loading-build-info" ] [
                        str "Loading"
                        span [ _class "build-name"; _id "loadingBuildName" ] [
                            str "Unity Game"
                        ]
                    ]
                ]
                rawText ("""<!--  - -- -- -- -- - GAME SCREEN - -- -- -- -- -  -->""")
                div [ _class "screen game-screen"; _id "gameScreen" ] [
                    div [ _class "unity-wrapper"; _id "unityContainer" ] [
                        canvas [ _id "unity-canvas"; attr "tabindex" "-1" ] []
                        div [ _class "warning-banner"; _id "warningBanner" ] []
                    ]
                    div [ _class "controls-bar" ] [
                        div [ _class "control-cluster" ] [
                            button [ _class "ctrl-btn"; attr "onclick" "toggleFullscreen()"; attr "title" "Fullscreen (F)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                    voidTag "path" [ attr "d" "M8 3H5a2 2 0 0 0-2 2v3m18 0V5a2 2 0 0 0-2-2h-3m0 18h3a2 2 0 0 0 2-2v-3M3 16v3a2 2 0 0 0 2 2h3" ]
                                ]
                                str "Fullscreen"
                            ]
                            button [ _class "ctrl-btn"; attr "onclick" "reloadGame()"; attr "title" "Reload (R)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                    voidTag "path" [ attr "d" "M1 4v6h6M23 20v-6h-6" ]
                                    voidTag "path" [ attr "d" "M20.49 9A9 9 0 0 0 5.64 5.64L1 10m22 4l-4.64 4.36A9 9 0 0 1 3.51 15" ]
                                ]
                                str "Reload"
                            ]
                            button [ _class "ctrl-btn"; attr "onclick" "quitGame()"; attr "title" "Quit (Q)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                    voidTag "path" [ attr "d" "M18.36 6.64a9 9 0 1 1-12.73 0M12 2v10" ]
                                ]
                                str "Quit"
                            ]
                        ]
                        div [ _class "control-cluster" ] [
                            button [ _class "ctrl-btn"; attr "onclick" "toggleShortcuts()"; attr "title" "Shortcuts (?)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                    voidTag "rect" [ attr "x" "2"; attr "y" "4"; attr "width" "20"; attr "height" "16"; attr "rx" "2" ]
                                    voidTag "path" [ attr "d" "M6 8h.01M10 8h.01M14 8h.01M18 8h.01M6 16h.01M10 16h.01M14 16h.01M18 16h.01" ]
                                ]
                                str "Keys"
                            ]
                            button [ _class "ctrl-btn"; attr "onclick" "toggleConsole()"; attr "title" "Console (C)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                    voidTag "polyline" [ attr "points" "4 17 10 11 4 5" ]
                                    voidTag "line" [ attr "x1" "12"; attr "y1" "19"; attr "x2" "20"; attr "y2" "19" ]
                                ]
                                str "Console"
                            ]
                        ]
                    ]
                    div [ _class "status-bar" ] [
                        span [ _class "status-dot"; _id "statusDot" ] []
                        span [ _id "statusText" ] [
                            str "Ready"
                        ]
                    ]
                    div [ _class "log-panel" ] [
                        button [ _class "log-toggle-btn"; attr "onclick" "toggleConsole()" ] [
                            span [] [
                                str "▾"
                            ]
                            str "Debug Console"
                            span [ _id "consoleCount" ] [
                                str "(0)"
                            ]
                        ]
                        div [ _class "log-content"; _id "logContent" ] []
                    ]
                ]
                rawText ("""<!--  - -- -- -- -- - ERROR SCREEN - -- -- -- -- -  -->""")
                div [ _class "screen error-screen"; _id "errorScreen" ] [
                    div [ _class "error-icon" ] [
                        str "!"
                    ]
                    h2 [ _id "errorTitle" ] [
                        str "Build Files Not Found"
                    ]
                    p [ _id "errorMessage" ] [
                        str "Could not find Unity WebGL build files in"
                        code [] [
                            str "./Build/"
                        ]
                        str "."
                        br []
                        str "Please ensure your build output is in the correct location."
                    ]
                    div [ _class "action-bar"; attr "style" "justify-content:center;margin-top:8px;" ] [
                        button [ _class "btn btn-secondary"; attr "onclick" "showScreen('setupScreen'); rescanBuildDir();" ] [
                            span [ _class "btn-icon" ] [
                                str "↻"
                            ]
                            str "Back to Setup"
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  /app  -->""")
            rawText ("""<!--  ==================== JAVASCRIPT ====================  -->""")
            script [] [
                    rawText ("""// ================================================================
// UNITY WEBGL PLACEHOLDER LAUNCHER
// ================================================================
// Loads a Unity WebGL game from local ./Build/ and ./TemplateData/
// directories. Auto-detects build files and configures the Unity
// loader dynamically.
//
// Key components:
//   1. BuildDetector    — scans ./Build/ for Unity build files
//   2. ConfigBuilder    — constructs the createUnityInstance config
//   3. UnityLauncher    — loads loader.js and creates the instance
//   4. UIController     — manages screen transitions and DOM
//   5. LogManager       — debug logging to on-page console
// ================================================================

/** @type {Object} Global application state */
const App = {
  unityInstance: null,       // Active Unity instance
  loaderScript: null,        // Script element for loader.js
  isRunning: false,
  isLoading: false,
  buildPrefix: '',           // Detected build filename prefix
  detectedFiles: {},         // Map of file type -> relative path
  config: {                  // Unity build config
    companyName: 'My Company',
    productName: 'Unity Game',
    productVersion: '1.0',
    streamingAssetsUrl: 'StreamingAssets'
  },
  logs: [],
  /** @type {string} Build directory path (customizable) */
  buildPath: './Build',
  /** @type {string} Template data directory path */
  templatePath: './TemplateData'
};

// ---- File detection patterns (order matters — more specific first) ----
const DETECT_PATTERNS = [
  { key: 'loader',     test: n => /\.loader\.js$/.test(n),               required: true,  label: 'Loader',    ext: '.loader.js' },
  { key: 'dataGz',     test: n => /\.data\.gz$/.test(n),                  required: false, label: 'Data',      ext: '.data.gz' },
  { key: 'dataBr',     test: n => /\.data\.br$/.test(n),                  required: false, label: 'Data',      ext: '.data.br' },
  { key: 'dataRaw',    test: n => /\.data$/.test(n) && !n.includes('.framework'), required: false, label: 'Data', ext: '.data' },
  { key: 'frameworkGz',test: n => /\.framework\.js\.gz$/.test(n),         required: false, label: 'Framework', ext: '.framework.js.gz' },
  { key: 'frameworkBr',test: n => /\.framework\.js\.br$/.test(n),         required: false, label: 'Framework', ext: '.framework.js.br' },
  { key: 'frameworkRaw',test: n => /\.framework\.js$/.test(n),            required: false, label: 'Framework', ext: '.framework.js' },
  { key: 'wasmGz',     test: n => /\.wasm\.gz$/.test(n),                  required: false, label: 'WASM',      ext: '.wasm.gz' },
  { key: 'wasmBr',     test: n => /\.wasm\.br$/.test(n),                  required: false, label: 'WASM',      ext: '.wasm.br' },
  { key: 'wasmRaw',    test: n => /\.wasm$/.test(n) && !n.includes('.framework'), required: false, label: 'WASM', ext: '.wasm' },
  { key: 'dataUnityweb', test: n => /\.data\.unityweb$/.test(n),          required: false, label: 'Data',      ext: '.data.unityweb' },
  { key: 'frameworkUnityweb', test: n => /\.framework\.js\.unityweb$/.test(n), required: false, label: 'Framework', ext: '.framework.js.unityweb' },
  { key: 'wasmUnityweb', test: n => /\.wasm\.unityweb$/.test(n),          required: false, label: 'WASM',      ext: '.wasm.unityweb' },
];

// ================================================================
// LOG MANAGER
// ================================================================
function logger(msg, level = 'info') {
  const ts = new Date().toLocaleTimeString();
  const entry = { ts, msg: String(msg), level };
  App.logs.push(entry);
  // Browser console
  const fn = level === 'err' ? 'error' : level === 'warn' ? 'warn' : level === 'debug' ? 'log' : 'log';
  console[fn](`[UnityLauncher] ${msg}`);
  // On-page console
  const container = document.getElementById('logContent');
  if (container) {
    const row = document.createElement('div');
    row.className = `log-line ${level}`;
    row.innerHTML = `<span class="log-ts">${ts}</span>${esc(String(msg))}`;
    container.appendChild(row);
    container.scrollTop = container.scrollHeight;
    document.getElementById('consoleCount').textContent = `(${App.logs.length})`;
  }
}
function esc(s) {
  const d = document.createElement('div');
  d.textContent = s;
  return d.innerHTML;
}

// ================================================================
// PARTICLE BACKGROUND
// ================================================================
(function initBg() {
  const c = document.getElementById('bg-canvas');
  const ctx = c.getContext('2d');
  let P = [], W, H;
  function resize() { W = c.width = window.innerWidth; H = c.height = window.innerHeight; }
  resize();
  window.addEventListener('resize', resize);
  for (let i = 0; i < 45; i++) {
    P.push({
      x: Math.random() * W, y: Math.random() * H,
      vx: (Math.random() - 0.5) * 0.25, vy: (Math.random() - 0.5) * 0.25,
      r: Math.random() * 1.8 + 0.4, a: Math.random() * 0.4 + 0.15
    });
  }
  (function draw() {
    ctx.clearRect(0, 0, W, H);
    P.forEach(p => {
      p.x += p.vx; p.y += p.vy;
      if (p.x < 0) p.x = W; if (p.x > W) p.x = 0;
      if (p.y < 0) p.y = H; if (p.y > H) p.y = 0;
      ctx.beginPath();
      ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2);
      ctx.fillStyle = `rgba(100,170,255,${p.a})`;
      ctx.fill();
    });
    // Lines between nearby particles
    for (let i = 0; i < P.length; i++) {
      for (let j = i + 1; j < P.length; j++) {
        const dx = P[i].x - P[j].x, dy = P[i].y - P[j].y;
        const d = Math.sqrt(dx * dx + dy * dy);
        if (d < 130) {
          ctx.beginPath();
          ctx.moveTo(P[i].x, P[i].y);
          ctx.lineTo(P[j].x, P[j].y);
          ctx.strokeStyle = `rgba(100,170,255,${0.04 * (1 - d / 130)})`;
          ctx.lineWidth = 0.5;
          ctx.stroke();
        }
      }
    }
    requestAnimationFrame(draw);
  })();
})();

// ================================================================
// SCREEN MANAGEMENT
// ================================================================
function showScreen(id) {
  document.querySelectorAll('.screen').forEach(s => s.classList.remove('active'));
  const target = document.getElementById(id);
  if (target) target.classList.add('active');
}

function setStatus(text, type = 'ok') {
  const dot = document.getElementById('statusDot');
  const txt = document.getElementById('statusText');
  txt.textContent = text;
  dot.className = 'status-dot';
  if (type === 'warn') dot.classList.add('yellow');
  if (type === 'err') dot.classList.add('red');
}

// ================================================================
// BUILD DETECTOR
// ================================================================
/**
 * Attempts to detect Unity build files in the ./Build/ directory.
 * Since we can't list directories from the client, we try fetching
 * known filename patterns derived from the build prefix.
 */
async function detectBuildFiles(prefix = '') {
  logger(`Scanning ${App.buildPath}/ for build files...`, 'debug');
  App.detectedFiles = {};
  let searchPrefix = prefix;

  // If no prefix given, try common names
  if (!searchPrefix) {
    const candidates = ['Build', 'build', 'WebGL', 'webgl', 'Game', 'game', 'index'];
    for (const cand of candidates) {
      const ok = await testFile(`${App.buildPath}/${cand}.loader.js`);
      if (ok) { searchPrefix = cand; break; }
    }
  } else {
    // Verify the provided prefix exists
    const ok = await testFile(`${App.buildPath}/${searchPrefix}.loader.js`);
    if (!ok) searchPrefix = '';
  }

  if (!searchPrefix) {
    // Try to find ANY .loader.js in Build dir by probing
    searchPrefix = await findLoaderPrefix();
  }

  App.buildPrefix = searchPrefix;
  document.getElementById('buildPrefixInput').value = searchPrefix;

  if (!searchPrefix) {
    logger('No Unity loader found in ./Build/', 'warn');
    return false;
  }

  logger(`Found build prefix: "${searchPrefix}"`, 'ok');

  // Now detect all companion files
  for (const pat of DETECT_PATTERNS) {
    const url = `${App.buildPath}/${searchPrefix}${pat.ext}`;
    const exists = await testFile(url);
    if (exists) {
      App.detectedFiles[pat.key] = url;
      logger(`Found: ${searchPrefix}${pat.ext}`, 'ok');
    }
  }

  return true;
}

/**
 * Attempt to discover the build prefix by probing for .loader.js
 * with common prefixes.
 */
async function findLoaderPrefix() {
  const prefixes = [];
  // Try directory name as prefix
  const pathParts = window.location.pathname.split('/');
  const dirName = pathParts[pathParts.length - 2] || '';
  if (dirName) prefixes.push(dirName);
  // Common defaults
  prefixes.push('Build', 'build', 'WebGL', 'webgl', 'Game', 'game', 'index', 'main', 'app');
  // Deduplicate
  const unique = [...new Set(prefixes)];
  for (const p of unique) {
    if (await testFile(`${App.buildPath}/${p}.loader.js`)) return p;
  }
  return '';
}

/**
 * Test if a file exists by sending a HEAD request.
 */
async function testFile(url) {
  try {
    const r = await fetch(url, { method: 'HEAD', cache: 'no-store' });
    return r.ok;
  } catch(e) {
    return false;
  }
}

// ================================================================
// UI UPDATES
// ================================================================
function updateFileGrid() {
  const grid = document.getElementById('fileGrid');
  const statusEl = document.getElementById('detectStatus');
  const badgeText = document.getElementById('detectBadgeText');
  const hintText = document.getElementById('hintText');
  const launchBtn = document.getElementById('launchBtn');

  grid.innerHTML = '';

  if (!App.buildPrefix) {
    statusEl.className = 'detect-status error';
    statusEl.textContent = 'No Unity WebGL build found in ./Build/';
    badgeText.textContent = 'No build detected';
    hintText.textContent = 'Place your Unity WebGL build files in ./Build/';
    launchBtn.disabled = true;
    // Show all patterns as missing
    DETECT_PATTERNS.filter(p => p.required || ['dataGz','dataBr','frameworkGz','frameworkBr','wasmGz','wasmBr'].includes(p.key))
      .forEach(pat => renderFileCard(grid, pat, null));
    return;
  }

  // Check if we have minimum required files
  const hasLoader = !!App.detectedFiles.loader;
  const hasData = !!(App.detectedFiles.dataGz || App.detectedFiles.dataBr || App.detectedFiles.dataRaw || App.detectedFiles.dataUnityweb);
  const hasFramework = !!(App.detectedFiles.frameworkGz || App.detectedFiles.frameworkBr || App.detectedFiles.frameworkRaw || App.detectedFiles.frameworkUnityweb);
  const hasWasm = !!(App.detectedFiles.wasmGz || App.detectedFiles.wasmBr || App.detectedFiles.wasmRaw || App.detectedFiles.wasmUnityweb);
  const canLaunch = hasLoader && hasData && hasFramework && hasWasm;

  statusEl.className = canLaunch ? 'detect-status success' : 'detect-status info';
  statusEl.textContent = canLaunch
    ? `Found "${App.buildPrefix}" build — ready to launch`
    : `Found "${App.buildPrefix}" — some files may be missing`;
  badgeText.textContent = canLaunch ? 'Build ready' : `Prefix: ${App.buildPrefix}`;
  hintText.textContent = canLaunch ? 'All required files detected' : 'Missing some build files — check your build output';
  hintText.style.color = canLaunch ? 'var(--accent-green)' : 'var(--unity-text-dim)';
  launchBtn.disabled = !canLaunch;

  // Render cards
  const keysToShow = ['loader','dataGz','dataBr','frameworkGz','frameworkBr','wasmGz','wasmBr','dataRaw','frameworkRaw','wasmRaw','dataUnityweb','frameworkUnityweb','wasmUnityweb'];
  const shown = new Set();
  keysToShow.forEach(key => {
    const pat = DETECT_PATTERNS.find(p => p.key === key);
    if (!pat || shown.has(pat.label + pat.ext)) return;
    shown.add(pat.label + pat.ext);
    const url = App.detectedFiles[key];
    renderFileCard(grid, pat, url);
  });
}

function renderFileCard(grid, pat, url) {
  const card = document.createElement('div');
  card.className = `file-detect-card ${url ? 'found' : 'missing'}`;
  card.innerHTML = `
    <span class="file-type-label">${pat.label}</span>
    <span class="file-name-val">${url ? App.buildPrefix + pat.ext : 'Not found'}</span>
    <span class="file-status-icon">${url ? '&#10003;' : '&#9675;'}</span>
  `;
  grid.appendChild(card);
}

function onPrefixChange() {
  const val = document.getElementById('buildPrefixInput').value.trim();
  App.buildPrefix = val;
  if (val) {
    // Re-detect with this prefix
    detectBuildFiles(val).then(() => updateFileGrid());
  }
}

async function rescanBuildDir() {
  logger('Rescanning build directory...', 'info');
  document.getElementById('detectStatus').className = 'detect-status info';
  document.getElementById('detectStatus').textContent = 'Scanning...';
  const found = await detectBuildFiles();
  updateFileGrid();
  if (!found) {
    logger('No build files found during rescan', 'warn');
  }
}

// ================================================================
// UNITY LAUNCHER
// ================================================================
function launchGame() {
  if (App.isLoading || App.isRunning) return;

  const canvas = document.getElementById('unity-canvas');
  const progressFill = document.getElementById('progressFill');
  const progressPct = document.getElementById('progressPct');
  const progressStage = document.getElementById('progressStage');

  // Update loading screen info
  document.getElementById('loadingBuildName').textContent =
    document.getElementById('productNameInput').value || 'Unity Game';

  showScreen('loadingScreen');
  App.isLoading = true;
  setStatus('Loading...', 'warn');
  logger('Starting Unity WebGL launch sequence', 'info');

  // Build config
  const cfg = buildConfig();
  if (!cfg) {
    showScreen('errorScreen');
    logger('Failed to build config — missing files', 'err');
    return;
  }

  logger(`Config: dataUrl=${cfg.dataUrl}, frameworkUrl=${cfg.frameworkUrl}, codeUrl=${cfg.codeUrl}`, 'debug');

  // Load Unity loader
  const script = document.createElement('script');
  script.src = App.detectedFiles.loader;
  App.loaderScript = script;

  script.onload = () => {
    logger('Unity loader loaded', 'ok');
    progressStage.textContent = 'Compiling...';

    if (typeof createUnityInstance !== 'function') {
      logger('createUnityInstance not found — incompatible loader', 'err');
      showBanner('Loader incompatible. Try a different Unity build.', 'error');
      showScreen('errorScreen');
      return;
    }

    createUnityInstance(canvas, cfg, (progress) => {
      const pct = Math.round(progress * 100);
      progressFill.style.width = pct + '%';
      progressPct.textContent = pct + '%';
      if (pct < 25) progressStage.textContent = 'Downloading...';
      else if (pct < 60) progressStage.textContent = 'Compiling WASM...';
      else if (pct < 90) progressStage.textContent = 'Initializing...';
      else progressStage.textContent = 'Starting...';
      if (pct % 10 === 0) logger(`Progress: ${pct}%`, 'debug');
    }).then((instance) => {
      App.unityInstance = instance;
      App.isLoading = false;
      App.isRunning = true;
      window.unityInstance = instance;
      showScreen('gameScreen');
      setStatus('Running', 'ok');
      logger('Unity instance created — game running!', 'ok');
    }).catch((err) => {
      App.isLoading = false;
      logger(`Launch failed: ${err}`, 'err');
      document.getElementById('errorTitle').textContent = 'Launch Failed';
      document.getElementById('errorMessage').innerHTML =
        `Failed to start Unity:<br><code style="color:var(--accent-red)">${esc(String(err))}</code><br><br>` +
        `Check that all build files are present and compatible with your browser.`;
      showScreen('errorScreen');
    });
  };

  script.onerror = () => {
    App.isLoading = false;
    logger('Failed to load Unity loader script', 'err');
    document.getElementById('errorTitle').textContent = 'Loader Error';
    document.getElementById('errorMessage').textContent = 'Could not load the Unity loader JavaScript file.';
    showScreen('errorScreen');
  };

  document.body.appendChild(script);
}

function buildConfig() {
  const d = App.detectedFiles;
  const c = { ...App.config };

  c.dataUrl = d.dataGz || d.dataBr || d.dataRaw || d.dataUnityweb;
  c.frameworkUrl = d.frameworkGz || d.frameworkBr || d.frameworkRaw || d.frameworkUnityweb;
  c.codeUrl = d.wasmGz || d.wasmBr || d.wasmRaw || d.wasmUnityweb;
  c.showBanner = unityShowBanner;

  // Apply user overrides
  c.companyName = document.getElementById('companyNameInput').value || c.companyName;
  c.productName = document.getElementById('productNameInput').value || c.productName;

  if (!c.dataUrl || !c.frameworkUrl || !c.codeUrl) {
    logger('Missing required build files in config', 'err');
    return null;
  }
  return c;
}

// ================================================================
// GAME CONTROLS
// ================================================================
function toggleFullscreen() {
  if (App.unityInstance) {
    App.unityInstance.SetFullscreen(1);
    logger('Fullscreen requested via Unity API');
  } else {
    // Fallback: request canvas fullscreen
    const canvas = document.getElementById('unity-canvas');
    if (canvas.requestFullscreen) canvas.requestFullscreen();
    else if (canvas.webkitRequestFullscreen) canvas.webkitRequestFullscreen();
    else if (canvas.msRequestFullscreen) canvas.msRequestFullscreen();
    logger('Fullscreen requested via browser API');
  }
}

function reloadGame() {
  if (App.unityInstance) {
    try { App.unityInstance.Quit(); } catch(e) {}
    App.unityInstance = null;
  }
  App.isRunning = false;
  App.isLoading = false;
  if (App.loaderScript) {
    try { document.body.removeChild(App.loaderScript); } catch(e) {}
  }
  // Reset progress bar
  document.getElementById('progressFill').style.width = '0%';
  document.getElementById('progressPct').textContent = '0%';
  document.getElementById('progressStage').textContent = 'Initializing...';
  document.getElementById('warningBanner').innerHTML = '';
  document.getElementById('warningBanner').classList.remove('show');
  logger('Game reloaded', 'info');
  setTimeout(() => launchGame(), 100);
}

function quitGame() {
  if (App.unityInstance) {
    App.unityInstance.Quit().catch(() => {});
    App.unityInstance = null;
  }
  App.isRunning = false;
  App.isLoading = false;
  if (App.loaderScript) {
    try { document.body.removeChild(App.loaderScript); } catch(e) {}
  }
  // Cleanup WebGL context
  const canvas = document.getElementById('unity-canvas');
  const gl = canvas.getContext('webgl') || canvas.getContext('webgl2');
  if (gl) {
    const ext = gl.getExtension('WEBGL_lose_context');
    if (ext) ext.loseContext();
  }
  showScreen('setupScreen');
  setStatus('Ready');
  rescanBuildDir();
  logger('Game quit — returned to setup', 'info');
}

function toggleShortcuts() {
  document.getElementById('shortcutsOverlay').classList.toggle('show');
}
function toggleConsole() {
  document.getElementById('logContent').classList.toggle('show');
}

// ================================================================
// BANNER
// ================================================================
function unityShowBanner(msg, type) {
  const el = document.getElementById('warningBanner');
  const fn = () => { el.style.display = el.children.length ? 'block' : 'none'; };
  const div = document.createElement('div');
  div.className = type === 'error' ? 'error-msg' : 'warn-msg';
  div.textContent = msg;
  el.appendChild(div);
  el.classList.add('show');
  logger(`[${type}] ${msg}`, type === 'error' ? 'err' : 'warn');
  if (type !== 'error') {
    setTimeout(() => { if(div.parentNode) el.removeChild(div); fn(); }, 6000);
  }
}

// ================================================================
// KEYBOARD SHORTCUTS
// ================================================================
document.addEventListener('keydown', e => {
  if (!App.isRunning && !App.isLoading) return;
  if (e.target.tagName === 'INPUT') return;
  const k = e.key.toLowerCase();
  if (k === 'f') { e.preventDefault(); toggleFullscreen(); }
  if (k === 'r' && !e.ctrlKey) { e.preventDefault(); reloadGame(); }
  if (k === 'q') { e.preventDefault(); quitGame(); }
  if (k === 'c') { e.preventDefault(); toggleConsole(); }
  if (k === '?') { e.preventDefault(); toggleShortcuts(); }
});

// ================================================================
// MOBILE DETECTION
// ================================================================
if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
  const meta = document.createElement('meta');
  meta.name = 'viewport';
  meta.content = 'width=device-width, height=device-height, initial-scale=1.0, user-scalable=no, shrink-to-fit=yes';
  document.head.appendChild(meta);
  logger('Mobile device detected — adjusted viewport');
}

// ================================================================
// INITIALIZATION
// ================================================================
(async function init() {
  logger('Unity WebGL Placeholder Launcher initialized', 'info');
  logger(`Build path: ${App.buildPath}`, 'debug');

  // Try to auto-detect
  await rescanBuildDir();

  // If build detected and all files present, offer quick launch
  const hasLoader = !!App.detectedFiles.loader;
  const hasData = !!(App.detectedFiles.dataGz || App.detectedFiles.dataBr || App.detectedFiles.dataRaw);
  const hasFw = !!(App.detectedFiles.frameworkGz || App.detectedFiles.frameworkBr || App.detectedFiles.frameworkRaw);
  const hasWasm = !!(App.detectedFiles.wasmGz || App.detectedFiles.wasmBr || App.detectedFiles.wasmRaw);
  if (hasLoader && hasData && hasFw && hasWasm) {
    logger('All build files detected — ready for launch', 'ok');
  }
})();""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
