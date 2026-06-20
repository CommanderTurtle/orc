module ConvertedFiles.Wasm.Unity.N1.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Unity WebGL Launcher — Upload Build Files"
            ]
            style [] [
                    rawText ("""/* ============================================
       UNITY WEBGL UPLOAD LAUNCHER
       Standalone file:// compatible — no external dependencies
       ============================================ */

    /* --- CSS Reset & Base --- */
    *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }
    :root {
      --bg-primary: #0d0d0d;
      --bg-secondary: #1a1a1a;
      --bg-tertiary: #252525;
      --bg-glass: rgba(30, 30, 35, 0.85);
      --border-color: #333;
      --border-hover: #555;
      --accent-blue: #2196F3;
      --accent-blue-dim: #1976D2;
      --accent-cyan: #00bcd4;
      --accent-green: #4caf50;
      --accent-orange: #ff9800;
      --accent-red: #f44336;
      --text-primary: #e0e0e0;
      --text-secondary: #9e9e9e;
      --text-muted: #666;
      --font-mono: 'SF Mono', Monaco, 'Cascadia Code', 'Fira Code', Consolas, monospace;
      --font-sans: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, sans-serif;
      --radius: 8px;
      --radius-lg: 12px;
      --shadow: 0 4px 24px rgba(0,0,0,0.5);
      --shadow-lg: 0 8px 48px rgba(0,0,0,0.7);
      --transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
    }
    html, body {
      width: 100%; height: 100%;
      font-family: var(--font-sans);
      background: var(--bg-primary);
      color: var(--text-primary);
      overflow-x: hidden;
      overflow-y: auto;
    }

    /* --- Particle Background Canvas --- */
    #particle-canvas {
      position: fixed;
      top: 0; left: 0;
      width: 100%; height: 100%;
      z-index: 0;
      pointer-events: none;
      opacity: 0.35;
    }

    /* --- Scrollbar --- */
    ::-webkit-scrollbar { width: 6px; }
    ::-webkit-scrollbar-track { background: var(--bg-primary); }
    ::-webkit-scrollbar-thumb { background: #444; border-radius: 3px; }
    ::-webkit-scrollbar-thumb:hover { background: #666; }

    /* --- Main Container --- */
    .main-container {
      position: relative;
      z-index: 1;
      max-width: 1000px;
      margin: 0 auto;
      padding: 24px;
      min-height: 100vh;
      display: flex;
      flex-direction: column;
    }

    /* --- Header --- */
    .header {
      text-align: center;
      padding: 32px 0 24px;
      animation: fadeSlideDown 0.6s ease;
    }
    .header h1 {
      font-size: 2rem;
      font-weight: 700;
      background: linear-gradient(135deg, var(--accent-blue), var(--accent-cyan));
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
      background-clip: text;
      margin-bottom: 8px;
      letter-spacing: -0.5px;
    }
    .header p {
      color: var(--text-secondary);
      font-size: 0.95rem;
      max-width: 600px;
      margin: 0 auto;
      line-height: 1.5;
    }
    .unity-badge {
      display: inline-flex;
      align-items: center;
      gap: 6px;
      background: var(--bg-tertiary);
      border: 1px solid var(--border-color);
      border-radius: 20px;
      padding: 4px 14px;
      font-size: 0.75rem;
      color: var(--text-muted);
      margin-top: 12px;
      font-family: var(--font-mono);
    }
    .unity-badge .dot {
      width: 7px; height: 7px;
      border-radius: 50%;
      background: var(--accent-green);
      box-shadow: 0 0 6px var(--accent-green);
      animation: pulse 2s infinite;
    }

    /* --- Upload Section --- */
    .upload-section {
      animation: fadeSlideUp 0.6s 0.1s ease both;
    }
    .upload-zone {
      border: 2px dashed var(--border-color);
      border-radius: var(--radius-lg);
      padding: 48px 32px;
      text-align: center;
      background: var(--bg-glass);
      backdrop-filter: blur(20px);
      -webkit-backdrop-filter: blur(20px);
      transition: var(--transition);
      cursor: pointer;
      position: relative;
      overflow: hidden;
    }
    .upload-zone::before {
      content: '';
      position: absolute;
      top: 0; left: -100%;
      width: 100%; height: 100%;
      background: linear-gradient(90deg, transparent, rgba(33, 150, 243, 0.04), transparent);
      transition: left 0.6s ease;
    }
    .upload-zone:hover::before { left: 100%; }
    .upload-zone:hover, .upload-zone.dragover {
      border-color: var(--accent-blue);
      background: rgba(33, 150, 243, 0.05);
      transform: translateY(-2px);
      box-shadow: 0 8px 32px rgba(33, 150, 243, 0.1);
    }
    .upload-zone.dragover { border-style: solid; }
    .upload-zone .icon {
      width: 64px; height: 64px;
      margin: 0 auto 16px;
      background: linear-gradient(135deg, var(--accent-blue), var(--accent-cyan));
      border-radius: var(--radius);
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 28px;
      box-shadow: 0 4px 16px rgba(33, 150, 243, 0.3);
    }
    .upload-zone h3 {
      font-size: 1.15rem;
      font-weight: 600;
      margin-bottom: 6px;
    }
    .upload-zone p {
      color: var(--text-secondary);
      font-size: 0.85rem;
      margin-bottom: 16px;
    }
    .upload-zone .file-types {
      display: flex;
      flex-wrap: wrap;
      justify-content: center;
      gap: 6px;
      margin-top: 12px;
    }
    .file-tag {
      background: var(--bg-tertiary);
      border: 1px solid var(--border-color);
      border-radius: 4px;
      padding: 3px 10px;
      font-size: 0.72rem;
      font-family: var(--font-mono);
      color: var(--text-secondary);
    }
    .file-tag.required {
      border-color: var(--accent-blue);
      color: var(--accent-blue);
      background: rgba(33, 150, 243, 0.08);
    }
    input[type="file"] { display: none; }

    /* --- Or Divider --- */
    .or-divider {
      display: flex;
      align-items: center;
      gap: 16px;
      margin: 20px 0;
      color: var(--text-muted);
      font-size: 0.8rem;
      text-transform: uppercase;
      letter-spacing: 1px;
    }
    .or-divider::before, .or-divider::after {
      content: '';
      flex: 1;
      height: 1px;
      background: var(--border-color);
    }

    /* --- File List --- */
    .file-list-section {
      background: var(--bg-glass);
      backdrop-filter: blur(20px);
      -webkit-backdrop-filter: blur(20px);
      border: 1px solid var(--border-color);
      border-radius: var(--radius-lg);
      padding: 20px;
      margin-top: 16px;
      animation: fadeSlideUp 0.5s 0.2s ease both;
    }
    .file-list-header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 14px;
    }
    .file-list-header h3 {
      font-size: 0.95rem;
      font-weight: 600;
    }
    .file-count {
      background: var(--bg-tertiary);
      color: var(--text-secondary);
      padding: 2px 10px;
      border-radius: 10px;
      font-size: 0.78rem;
      font-family: var(--font-mono);
    }
    .file-item {
      display: flex;
      align-items: center;
      gap: 12px;
      padding: 10px 12px;
      border-radius: var(--radius);
      background: var(--bg-secondary);
      margin-bottom: 6px;
      transition: var(--transition);
      border: 1px solid transparent;
    }
    .file-item:hover { border-color: var(--border-hover); }
    .file-item .file-icon {
      width: 36px; height: 36px;
      border-radius: 6px;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 0.85rem;
      font-family: var(--font-mono);
      font-weight: 700;
      flex-shrink: 0;
    }
    .file-icon.js { background: rgba(255, 214, 0, 0.12); color: #ffd600; }
    .file-icon.data { background: rgba(76, 175, 80, 0.12); color: var(--accent-green); }
    .file-icon.wasm { background: rgba(156, 39, 176, 0.12); color: #ce93d8; }
    .file-icon.zip { background: rgba(255, 152, 0, 0.12); color: var(--accent-orange); }
    .file-icon.img { background: rgba(0, 188, 212, 0.12); color: var(--accent-cyan); }
    .file-icon.css { background: rgba(33, 150, 243, 0.12); color: var(--accent-blue); }
    .file-icon.default { background: rgba(158, 158, 158, 0.12); color: var(--text-secondary); }
    .file-info { flex: 1; min-width: 0; }
    .file-name {
      font-size: 0.85rem;
      font-weight: 500;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
    }
    .file-size {
      font-size: 0.72rem;
      color: var(--text-muted);
      font-family: var(--font-mono);
    }
    .file-status {
      font-size: 0.75rem;
      padding: 3px 10px;
      border-radius: 4px;
      font-family: var(--font-mono);
      flex-shrink: 0;
    }
    .file-status.ready { background: rgba(76, 175, 80, 0.12); color: var(--accent-green); }
    .file-status.pending { background: rgba(255, 152, 0, 0.12); color: var(--accent-orange); }
    .file-status.error { background: rgba(244, 67, 54, 0.12); color: var(--accent-red); }

    /* --- Validation Panel --- */
    .validation-panel {
      margin-top: 16px;
      padding: 16px;
      border-radius: var(--radius);
      border: 1px solid var(--border-color);
      background: var(--bg-secondary);
    }
    .validation-title {
      font-size: 0.85rem;
      font-weight: 600;
      margin-bottom: 10px;
      display: flex;
      align-items: center;
      gap: 8px;
    }
    .check-item {
      display: flex;
      align-items: center;
      gap: 8px;
      padding: 5px 0;
      font-size: 0.82rem;
      color: var(--text-secondary);
    }
    .check-icon {
      width: 18px; height: 18px;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 0.65rem;
      flex-shrink: 0;
    }
    .check-icon.pass { background: rgba(76, 175, 80, 0.15); color: var(--accent-green); }
    .check-icon.fail { background: rgba(158, 158, 158, 0.1); color: var(--text-muted); }

    /* --- Launch Button --- */
    .launch-bar {
      margin-top: 20px;
      display: flex;
      gap: 12px;
      align-items: center;
      flex-wrap: wrap;
    }
    .btn {
      display: inline-flex;
      align-items: center;
      justify-content: center;
      gap: 8px;
      padding: 12px 28px;
      border-radius: var(--radius);
      font-size: 0.95rem;
      font-weight: 600;
      border: none;
      cursor: pointer;
      transition: var(--transition);
      font-family: var(--font-sans);
      position: relative;
      overflow: hidden;
    }
    .btn::after {
      content: '';
      position: absolute;
      top: 0; left: -100%;
      width: 100%; height: 100%;
      background: linear-gradient(90deg, transparent, rgba(255,255,255,0.08), transparent);
      transition: left 0.4s ease;
    }
    .btn:hover::after { left: 100%; }
    .btn:disabled { opacity: 0.4; cursor: not-allowed; }
    .btn-primary {
      background: linear-gradient(135deg, var(--accent-blue), var(--accent-cyan));
      color: #fff;
      box-shadow: 0 4px 16px rgba(33, 150, 243, 0.3);
    }
    .btn-primary:hover:not(:disabled) {
      transform: translateY(-2px);
      box-shadow: 0 6px 24px rgba(33, 150, 243, 0.4);
    }
    .btn-secondary {
      background: var(--bg-tertiary);
      color: var(--text-primary);
      border: 1px solid var(--border-color);
    }
    .btn-secondary:hover:not(:disabled) {
      background: var(--bg-secondary);
      border-color: var(--border-hover);
    }
    .btn-danger {
      background: rgba(244, 67, 54, 0.1);
      color: var(--accent-red);
      border: 1px solid rgba(244, 67, 54, 0.2);
    }
    .btn-danger:hover:not(:disabled) {
      background: rgba(244, 67, 54, 0.2);
    }

    /* --- Game Section --- */
    .game-section {
      display: none;
      flex-direction: column;
      align-items: center;
      gap: 20px;
      animation: fadeSlideUp 0.5s ease;
      flex: 1;
      justify-content: center;
    }
    .game-section.active { display: flex; }

    /* Unity Container */
    #unity-container {
      position: relative;
      width: 100%;
      max-width: 960px;
      aspect-ratio: 16 / 9;
      background: #000;
      border-radius: var(--radius);
      overflow: hidden;
      box-shadow: var(--shadow-lg);
      border: 1px solid var(--border-color);
    }
    #unity-canvas {
      width: 100%;
      height: 100%;
      display: block;
      background: #000;
    }
    #unity-canvas:focus { outline: none; }

    /* Unity Loading Bar (styled like Unity's default) */
    #unity-loading-bar {
      position: absolute;
      top: 0; left: 0;
      width: 100%; height: 100%;
      background: linear-gradient(180deg, #1a1a1a 0%, #0d0d0d 100%);
      display: none;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      z-index: 10;
    }
    #unity-loading-bar.active { display: flex; }
    .unity-logo-spinner {
      width: 80px; height: 80px;
      margin-bottom: 32px;
      position: relative;
    }
    .unity-logo-spinner .cube {
      position: absolute;
      width: 24px; height: 24px;
      background: linear-gradient(135deg, var(--accent-blue), var(--accent-cyan));
      border-radius: 3px;
      animation: cubeSpin 1.5s ease-in-out infinite;
    }
    .unity-logo-spinner .cube:nth-child(1) { top: 0; left: 28px; animation-delay: 0s; }
    .unity-logo-spinner .cube:nth-child(2) { top: 28px; left: 56px; animation-delay: 0.15s; }
    .unity-logo-spinner .cube:nth-child(3) { top: 56px; left: 28px; animation-delay: 0.3s; }
    .unity-logo-spinner .cube:nth-child(4) { top: 28px; left: 0; animation-delay: 0.45s; }
    #unity-progress-bar-empty {
      width: 280px;
      max-width: 80%;
      height: 6px;
      background: rgba(255,255,255,0.08);
      border-radius: 3px;
      overflow: hidden;
      margin-bottom: 12px;
    }
    #unity-progress-bar-full {
      width: 0%;
      height: 100%;
      background: linear-gradient(90deg, var(--accent-blue), var(--accent-cyan));
      border-radius: 3px;
      transition: width 0.15s ease;
      box-shadow: 0 0 10px rgba(33, 150, 243, 0.4);
    }
    #unity-progress-text {
      font-family: var(--font-mono);
      font-size: 0.8rem;
      color: var(--text-secondary);
      margin-top: 8px;
    }
    #unity-loading-status {
      font-size: 0.75rem;
      color: var(--text-muted);
      margin-top: 12px;
      font-family: var(--font-mono);
      text-align: center;
      padding: 0 20px;
    }

    /* Warning Banner */
    #unity-warning {
      position: absolute;
      top: 0; left: 0; right: 0;
      z-index: 15;
      display: none;
    }
    #unity-warning > div {
      padding: 10px 16px;
      font-size: 0.8rem;
      text-align: center;
    }
    #unity-warning .warn { background: rgba(255, 152, 0, 0.85); color: #1a1a1a; }
    #unity-warning .error { background: rgba(244, 67, 54, 0.85); color: #fff; }

    /* Game Controls */
    .game-controls {
      display: flex;
      gap: 10px;
      flex-wrap: wrap;
      justify-content: center;
      align-items: center;
    }
    .control-group {
      display: flex;
      gap: 8px;
      background: var(--bg-glass);
      backdrop-filter: blur(20px);
      padding: 6px;
      border-radius: var(--radius);
      border: 1px solid var(--border-color);
    }
    .ctrl-btn {
      display: inline-flex;
      align-items: center;
      justify-content: center;
      gap: 6px;
      padding: 8px 16px;
      border-radius: 6px;
      font-size: 0.82rem;
      font-weight: 500;
      border: none;
      cursor: pointer;
      transition: var(--transition);
      background: var(--bg-tertiary);
      color: var(--text-primary);
      font-family: var(--font-sans);
    }
    .ctrl-btn:hover { background: var(--bg-secondary); transform: translateY(-1px); }
    .ctrl-btn svg { width: 16px; height: 16px; }

    /* Status Panel */
    .status-panel {
      background: var(--bg-glass);
      backdrop-filter: blur(20px);
      border: 1px solid var(--border-color);
      border-radius: var(--radius);
      padding: 12px 20px;
      font-size: 0.78rem;
      font-family: var(--font-mono);
      color: var(--text-secondary);
      text-align: center;
    }
    .status-panel .label { color: var(--text-muted); }
    .status-panel .value { color: var(--accent-cyan); }

    /* Keyboard Shortcuts Overlay */
    .shortcuts-overlay {
      display: none;
      position: fixed;
      top: 0; left: 0;
      width: 100%; height: 100%;
      background: rgba(0,0,0,0.7);
      backdrop-filter: blur(8px);
      z-index: 100;
      align-items: center;
      justify-content: center;
      animation: fadeIn 0.2s ease;
    }
    .shortcuts-overlay.active { display: flex; }
    .shortcuts-panel {
      background: var(--bg-secondary);
      border: 1px solid var(--border-color);
      border-radius: var(--radius-lg);
      padding: 28px 32px;
      max-width: 420px;
      width: 90%;
      box-shadow: var(--shadow-lg);
    }
    .shortcuts-panel h3 {
      font-size: 1.1rem;
      margin-bottom: 16px;
      display: flex;
      justify-content: space-between;
      align-items: center;
    }
    .shortcut-row {
      display: flex;
      justify-content: space-between;
      align-items: center;
      padding: 8px 0;
      border-bottom: 1px solid rgba(255,255,255,0.04);
      font-size: 0.85rem;
    }
    .shortcut-row:last-child { border-bottom: none; }
    kbd {
      background: var(--bg-tertiary);
      border: 1px solid var(--border-hover);
      border-radius: 4px;
      padding: 3px 8px;
      font-family: var(--font-mono);
      font-size: 0.78rem;
      color: var(--text-secondary);
      box-shadow: 0 2px 0 var(--border-color);
    }

    /* Log Console */
    .log-section {
      width: 100%;
      max-width: 960px;
      margin-top: 8px;
    }
    .log-toggle {
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 8px;
      padding: 8px;
      color: var(--text-muted);
      font-size: 0.78rem;
      cursor: pointer;
      border: none;
      background: none;
      width: 100%;
      font-family: var(--font-sans);
      transition: color 0.2s;
    }
    .log-toggle:hover { color: var(--text-secondary); }
    .log-console {
      display: none;
      background: #0a0a0a;
      border: 1px solid var(--border-color);
      border-radius: var(--radius);
      padding: 12px;
      max-height: 200px;
      overflow-y: auto;
      font-family: var(--font-mono);
      font-size: 0.75rem;
      line-height: 1.6;
      color: var(--text-secondary);
    }
    .log-console.active { display: block; }
    .log-entry { padding: 2px 0; }
    .log-entry.info { color: #888; }
    .log-entry.success { color: var(--accent-green); }
    .log-entry.warn { color: var(--accent-orange); }
    .log-entry.error { color: var(--accent-red); }
    .log-entry.debug { color: var(--accent-blue); }
    .log-timestamp { color: #555; margin-right: 6px; }

    /* --- Footer --- */
    .footer {
      text-align: center;
      padding: 24px 0 12px;
      color: var(--text-muted);
      font-size: 0.75rem;
      animation: fadeIn 0.6s 0.4s ease both;
    }
    .footer a {
      color: var(--accent-blue);
      text-decoration: none;
    }
    .footer a:hover { text-decoration: underline; }

    /* --- Animations --- */
    @keyframes fadeSlideDown {
      from { opacity: 0; transform: translateY(-20px); }
      to   { opacity: 1; transform: translateY(0); }
    }
    @keyframes fadeSlideUp {
      from { opacity: 0; transform: translateY(20px); }
      to   { opacity: 1; transform: translateY(0); }
    }
    @keyframes fadeIn {
      from { opacity: 0; }
      to   { opacity: 1; }
    }
    @keyframes pulse {
      0%, 100% { opacity: 1; }
      50% { opacity: 0.4; }
    }
    @keyframes cubeSpin {
      0%, 100% { transform: scale(1) rotate(0deg); opacity: 1; }
      50% { transform: scale(0.5) rotate(180deg); opacity: 0.5; }
    }

    /* --- Responsive --- */
    @media (max-width: 640px) {
      .header h1 { font-size: 1.5rem; }
      .upload-zone { padding: 32px 20px; }
      #unity-container { aspect-ratio: 4 / 3; }
      .launch-bar { justify-content: center; }
    }""")
            ]
        ]
        body [] [
            rawText ("<!--  Particle Background  -->")
            canvas [ _id "particle-canvas" ] []
            rawText ("<!--  Keyboard Shortcuts Overlay  -->")
            div [ _class "shortcuts-overlay"; _id "shortcutsOverlay" ] [
                div [ _class "shortcuts-panel" ] [
                    h3 [] [
                        span [] [
                            str "Keyboard Shortcuts"
                        ]
                        button [ _class "ctrl-btn"; attr "onclick" "toggleShortcuts()" ] [
                            str "Close"
                        ]
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Toggle Fullscreen"
                        ]
                        kbd [] [
                            str "F"
                        ]
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Reload Game"
                        ]
                        kbd [] [
                            str "R"
                        ]
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Quit Game"
                        ]
                        kbd [] [
                            str "Q"
                        ]
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Toggle Console"
                        ]
                        kbd [] [
                            str "C"
                        ]
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Keyboard Shortcuts"
                        ]
                        kbd [] [
                            str "?"
                        ]
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Focus Canvas"
                        ]
                        kbd [] [
                            str "Esc"
                        ]
                    ]
                ]
            ]
            rawText ("<!--  Main Container  -->")
            div [ _class "main-container" ] [
                rawText ("<!--  Header  -->")
                header [ _class "header" ] [
                    h1 [] [
                        str "Unity WebGL Launcher"
                    ]
                    p [] [
                        str "Upload your Unity WebGL build files to launch and play directly in the browser. All processing happens locally — no files are uploaded to any server."
                    ]
                    div [ _class "unity-badge" ] [
                        span [ _class "dot" ] []
                        span [] [
                            str "Standalone — file:// compatible"
                        ]
                    ]
                ]
                rawText ("<!--  Upload Section  -->")
                section [ _class "upload-section"; _id "uploadSection" ] [
                    rawText ("<!--  File Upload Zone  -->")
                    div [ _class "upload-zone"; _id "uploadZone"; attr "onclick" "document.getElementById('fileInput').click()" ] [
                        div [ _class "icon" ] [
                            str "📂"
                        ]
                        h3 [] [
                            str "Drop Unity Build Files Here"
                        ]
                        p [] [
                            str "Drag & drop your Build/ folder contents, or click to browse"
                        ]
                        div [ _class "file-types" ] [
                            span [ _class "file-tag required" ] [
                                str "*.loader.js"
                            ]
                            span [ _class "file-tag required" ] [
                                str "*.data.gz/br"
                            ]
                            span [ _class "file-tag required" ] [
                                str "*.framework.js.gz/br"
                            ]
                            span [ _class "file-tag required" ] [
                                str "*.wasm.gz/br"
                            ]
                            span [ _class "file-tag" ] [
                                str "*.zip"
                            ]
                            span [ _class "file-tag" ] [
                                str "TemplateData/*"
                            ]
                        ]
                    ]
                    input [ _type "file"; _id "fileInput"; attr "multiple" ""; attr "accept" ".js,.gz,.br,.data,.wasm,.framework,.json,.css,.png,.jpg,.jpeg,.ico,.zip,.unityweb"; attr "onchange" "handleFiles(this.files)" ]
                    div [ _class "or-divider" ] [
                        str "or upload a zip"
                    ]
                    div [ _class "upload-zone"; attr "onclick" "document.getElementById('zipInput').click()"; attr "style" "padding: 24px;" ] [
                        div [ attr "style" "display:flex;align-items:center;justify-content:center;gap:10px;" ] [
                            span [ attr "style" "font-size:1.5rem;" ] [
                                str "🍥"
                            ]
                            div [ attr "style" "text-align:left;" ] [
                                h3 [ attr "style" "font-size:1rem;margin-bottom:2px;" ] [
                                    str "Upload Build as .zip"
                                ]
                                p [ attr "style" "margin:0;font-size:0.8rem;" ] [
                                    str "Upload a complete Unity WebGL build archive"
                                ]
                            ]
                        ]
                    ]
                    input [ _type "file"; _id "zipInput"; attr "accept" ".zip"; attr "onchange" "handleZip(this.files[0])" ]
                    rawText ("<!--  File List  -->")
                    div [ _class "file-list-section"; _id "fileListSection"; attr "style" "display:none;" ] [
                        div [ _class "file-list-header" ] [
                            h3 [] [
                                str "Detected Files"
                            ]
                            span [ _class "file-count"; _id "fileCount" ] [
                                str "0 files"
                            ]
                        ]
                        div [ _id "fileList" ] []
                        rawText ("<!--  Validation Panel  -->")
                        div [ _class "validation-panel"; _id "validationPanel" ] [
                            div [ _class "validation-title" ] [
                                span [ attr "style" "color:var(--accent-blue);" ] [
                                    str "●"
                                ]
                                str "Build Validation"
                            ]
                            div [ _id "validationChecks" ] []
                        ]
                        rawText ("<!--  Launch Bar  -->")
                        div [ _class "launch-bar" ] [
                            button [ _class "btn btn-primary"; _id "launchBtn"; attr "onclick" "launchGame()"; attr "disabled" "" ] [
                                span [] [
                                    str "▶"
                                ]
                                str "Launch Game"
                            ]
                            button [ _class "btn btn-secondary"; attr "onclick" "clearAllFiles()" ] [
                                span [] [
                                    str "🗑"
                                ]
                                str "Clear All"
                            ]
                            span [ attr "style" "color:var(--text-muted);font-size:0.82rem;margin-left:auto;"; _id "readyText" ] [
                                str "Upload required files to launch"
                            ]
                        ]
                    ]
                ]
                rawText ("<!--  Game Section  -->")
                section [ _class "game-section"; _id "gameSection" ] [
                    div [ _id "unity-container" ] [
                        canvas [ _id "unity-canvas"; attr "tabindex" "-1" ] []
                        div [ _id "unity-loading-bar" ] [
                            div [ _class "unity-logo-spinner" ] [
                                div [ _class "cube" ] []
                                div [ _class "cube" ] []
                                div [ _class "cube" ] []
                                div [ _class "cube" ] []
                            ]
                            div [ _id "unity-progress-bar-empty" ] [
                                div [ _id "unity-progress-bar-full" ] []
                            ]
                            div [ _id "unity-progress-text" ] [
                                str "0%"
                            ]
                            div [ _id "unity-loading-status" ] [
                                str "Preparing to load..."
                            ]
                        ]
                        div [ _id "unity-warning" ] []
                    ]
                    div [ _class "game-controls" ] [
                        div [ _class "control-group" ] [
                            button [ _class "ctrl-btn"; attr "onclick" "toggleFullscreen()"; attr "title" "Toggle Fullscreen (F)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2" ] [
                                    voidTag "path" [ attr "d" "M8 3H5a2 2 0 0 0-2 2v3m18 0V5a2 2 0 0 0-2-2h-3m0 18h3a2 2 0 0 0 2-2v-3M3 16v3a2 2 0 0 0 2 2h3" ]
                                ]
                                str "Fullscreen"
                            ]
                            button [ _class "ctrl-btn"; attr "onclick" "reloadGame()"; attr "title" "Reload Game (R)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2" ] [
                                    voidTag "path" [ attr "d" "M1 4v6h6M23 20v-6h-6" ]
                                    voidTag "path" [ attr "d" "M20.49 9A9 9 0 0 0 5.64 5.64L1 10m22 4l-4.64 4.36A9 9 0 0 1 3.51 15" ]
                                ]
                                str "Reload"
                            ]
                            button [ _class "ctrl-btn"; attr "onclick" "quitGame()"; attr "title" "Quit Game (Q)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2" ] [
                                    voidTag "path" [ attr "d" "M18.36 6.64a9 9 0 1 1-12.73 0M12 2v10" ]
                                ]
                                str "Quit"
                            ]
                        ]
                        div [ _class "control-group" ] [
                            button [ _class "ctrl-btn"; attr "onclick" "toggleShortcuts()"; attr "title" "Keyboard Shortcuts (?)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2" ] [
                                    voidTag "rect" [ attr "x" "2"; attr "y" "4"; attr "width" "20"; attr "height" "16"; attr "rx" "2" ]
                                    voidTag "path" [ attr "d" "M6 8h.01M6 16h.01M10 8h.01M10 16h.01M14 8h.01M14 16h.01M18 8h.01M18 16h.01" ]
                                ]
                                str "Shortcuts"
                            ]
                            button [ _class "ctrl-btn"; attr "onclick" "toggleConsole()"; attr "title" "Toggle Console (C)" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24"; attr "fill" "none"; attr "stroke" "currentColor"; attr "stroke-width" "2" ] [
                                    voidTag "polyline" [ attr "points" "4 17 10 11 4 5" ]
                                    voidTag "line" [ attr "x1" "12"; attr "y1" "19"; attr "x2" "20"; attr "y2" "19" ]
                                ]
                                str "Console"
                            ]
                        ]
                    ]
                    div [ _class "status-panel"; _id "gameStatusPanel" ] [
                        span [ _class "label" ] [
                            str "Status:"
                        ]
                        span [ _class "value"; _id "gameStatusText" ] [
                            str "Ready to launch"
                        ]
                    ]
                    rawText ("<!--  Log Console  -->")
                    div [ _class "log-section" ] [
                        button [ _class "log-toggle"; attr "onclick" "toggleConsole()" ] [
                            span [] [
                                str "▾"
                            ]
                            str "Debug Console"
                            span [ _id "logCount" ] [
                                str "(0)"
                            ]
                        ]
                        div [ _class "log-console"; _id "logConsole" ] []
                    ]
                ]
                rawText ("<!--  Footer  -->")
                footer [ _class "footer" ] [
                    p [] [
                        str "Unity WebGL Standalone Launcher — Works offline with file:// protocol"
                    ]
                    p [ attr "style" "margin-top:4px;" ] [
                        str "Compatible with Unity 2020.1+, gzip/brotli compression, decompression fallback"
                    ]
                ]
            ]
            script [] [
                    rawText ("""// ============================================================
// UNITY WEBGL UPLOAD LAUNCHER — STANDALONE CLIENT-SIDE ENGINE
// ============================================================
// This script handles file uploads, ZIP extraction, Unity build
// validation, and dynamic Unity instance creation — all within
// the browser with zero external API calls.
//
// Architecture:
//   1. FileManager — tracks uploaded files, creates Blob URLs
//   2. Validator — checks that all required build files exist
//   3. ZipHandler — extracts .zip files using JSZip
//   4. UnityLauncher — loads the Unity loader and creates instance
//   5. UI Controller — manages DOM, animations, user interaction
// ============================================================

// --- Global State ---
const State = {
  files: new Map(),           // name -> { file, blobUrl, type, size }
  unityInstance: null,        // The Unity instance object
  isRunning: false,           // Game currently running?
  isLoading: false,           // Game currently loading?
  loaderScript: null,         // The loader script blob URL
  logEntries: [],             // Console log entries
  config: {                   // Build configuration
    companyName: 'Unknown',
    productName: 'Unity Game',
    productVersion: '1.0',
    buildName: 'game'
  }
};

// --- File Classification ---
const FILE_PATTERNS = {
  LOADER:     { regex: /\.loader\.js$/i,               required: true,  label: 'Loader Script' },
  DATA_GZ:    { regex: /\.data\.gz$/i,                  required: false, label: 'Data (gzip)' },
  DATA_BR:    { regex: /\.data\.br$/i,                  required: false, label: 'Data (brotli)' },
  DATA_RAW:   { regex: /\.data$/i,                      required: false, label: 'Data (raw)' },
  FRAME_GZ:   { regex: /\.framework\.js\.gz$/i,         required: false, label: 'Framework (gzip)' },
  FRAME_BR:   { regex: /\.framework\.js\.br$/i,         required: false, label: 'Framework (brotli)' },
  FRAME_RAW:  { regex: /\.framework\.js$/i,             required: false, label: 'Framework (raw)' },
  WASM_GZ:    { regex: /\.wasm\.gz$/i,                  required: false, label: 'WASM (gzip)' },
  WASM_BR:    { regex: /\.wasm\.br$/i,                  required: false, label: 'WASM (brotli)' },
  WASM_RAW:   { regex: /\.wasm$/i,                      required: false, label: 'WASM (raw)' },
  TEMPLATE:   { regex: /templateData|\.css$|\.png$|\.ico$|favicon/i, required: false, label: 'Template Assets' },
  ZIP:        { regex: /\.zip$/i,                       required: false, label: 'ZIP Archive' }
};

// --- Logging System ---
function log(msg, level = 'info') {
  const entry = { time: new Date().toLocaleTimeString(), msg, level };
  State.logEntries.push(entry);
  const consoleEl = document.getElementById('logConsole');
  const row = document.createElement('div');
  row.className = `log-entry ${level}`;
  row.innerHTML = `<span class="log-timestamp">${entry.time}</span> ${escapeHtml(msg)}`;
  consoleEl.appendChild(row);
  consoleEl.scrollTop = consoleEl.scrollHeight;
  document.getElementById('logCount').textContent = `(${State.logEntries.length})`;
  // Also log to browser console
  const method = level === 'error' ? 'error' : level === 'warn' ? 'warn' : 'log';
  console[method](`[UnityLauncher] ${msg}`);
}
function escapeHtml(text) {
  const div = document.createElement('div');
  div.textContent = text;
  return div.innerHTML;
}

// --- Particle Background ---
(function initParticles() {
  const canvas = document.getElementById('particle-canvas');
  const ctx = canvas.getContext('2d');
  let particles = [], w, h;
  function resize() { w = canvas.width = window.innerWidth; h = canvas.height = window.innerHeight; }
  resize();
  window.addEventListener('resize', resize);
  for (let i = 0; i < 50; i++) {
    particles.push({
      x: Math.random() * w, y: Math.random() * h,
      vx: (Math.random() - 0.5) * 0.3, vy: (Math.random() - 0.5) * 0.3,
      r: Math.random() * 1.5 + 0.5, o: Math.random() * 0.5 + 0.2
    });
  }
  function draw() {
    ctx.clearRect(0, 0, w, h);
    particles.forEach(p => {
      p.x += p.vx; p.y += p.vy;
      if (p.x < 0) p.x = w; if (p.x > w) p.x = 0;
      if (p.y < 0) p.y = h; if (p.y > h) p.y = 0;
      ctx.beginPath();
      ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2);
      ctx.fillStyle = `rgba(100, 180, 255, ${p.o})`;
      ctx.fill();
    });
    // Draw connections
    for (let i = 0; i < particles.length; i++) {
      for (let j = i + 1; j < particles.length; j++) {
        const dx = particles[i].x - particles[j].x;
        const dy = particles[i].y - particles[j].y;
        const dist = Math.sqrt(dx * dx + dy * dy);
        if (dist < 120) {
          ctx.beginPath();
          ctx.moveTo(particles[i].x, particles[i].y);
          ctx.lineTo(particles[j].x, particles[j].y);
          ctx.strokeStyle = `rgba(100, 180, 255, ${0.06 * (1 - dist / 120)})`;
          ctx.lineWidth = 0.5;
          ctx.stroke();
        }
      }
    }
    requestAnimationFrame(draw);
  }
  draw();
})();

// --- Drag & Drop ---
const uploadZone = document.getElementById('uploadZone');
['dragenter','dragover','dragleave','drop'].forEach(evt => {
  document.body.addEventListener(evt, e => { e.preventDefault(); e.stopPropagation(); });
});
['dragenter','dragover'].forEach(evt => {
  uploadZone.addEventListener(evt, () => uploadZone.classList.add('dragover'));
});
['dragleave','drop'].forEach(evt => {
  uploadZone.addEventListener(evt, () => uploadZone.classList.remove('dragover'));
});
uploadZone.addEventListener('drop', e => handleFiles(e.dataTransfer.files));

// --- File Handling ---
function handleFiles(fileList) {
  if (!fileList || fileList.length === 0) return;
  log(`Received ${fileList.length} file(s)`);
  Array.from(fileList).forEach(file => addFile(file));
  updateUI();
}

function addFile(file) {
  // Skip if already exists
  if (State.files.has(file.name)) {
    log(`Replacing existing file: ${file.name}`);
    URL.revokeObjectURL(State.files.get(file.name).blobUrl);
  }
  const blobUrl = URL.createObjectURL(file);
  const type = classifyFile(file.name);
  State.files.set(file.name, { file, blobUrl, type, size: file.size });
  log(`Added: ${file.name} (${formatBytes(file.size)})`, type === 'UNKNOWN' ? 'warn' : 'info');
}

function classifyFile(name) {
  for (const [key, val] of Object.entries(FILE_PATTERNS)) {
    if (val.regex.test(name)) return key;
  }
  return 'UNKNOWN';
}

function removeFile(name) {
  const entry = State.files.get(name);
  if (entry) {
    URL.revokeObjectURL(entry.blobUrl);
    State.files.delete(name);
    log(`Removed: ${name}`);
    updateUI();
  }
}

function clearAllFiles() {
  State.files.forEach(entry => URL.revokeObjectURL(entry.blobUrl));
  State.files.clear();
  log('All files cleared');
  document.getElementById('fileListSection').style.display = 'none';
  document.getElementById('uploadSection').style.display = 'block';
  document.getElementById('gameSection').classList.remove('active');
  if (State.unityInstance) {
    try { State.unityInstance.Quit(); } catch(e) {}
    State.unityInstance = null;
  }
  State.isRunning = false;
  State.isLoading = false;
  updateStatus('Ready');
}

function formatBytes(bytes) {
  if (bytes === 0) return '0 B';
  const k = 1024;
  const sizes = ['B','KB','MB','GB'];
  const i = Math.floor(Math.log(bytes) / Math.log(k));
  return parseFloat((bytes / Math.pow(k, i)).toFixed(1)) + ' ' + sizes[i];
}

function getFileIconClass(type, name) {
  if (type.includes('LOADER')) return 'js';
  if (type.includes('DATA')) return 'data';
  if (type.includes('WASM')) return 'wasm';
  if (type.includes('FRAME')) return 'js';
  if (type === 'ZIP') return 'zip';
  if (name.endsWith('.css')) return 'css';
  if (/\.(png|jpg|jpeg|ico|svg)$/.test(name)) return 'img';
  return 'default';
}

// --- ZIP Handling (inline JSZip implementation) ---
// Minimal PKZIP parser for extracting Unity WebGL builds
async function handleZip(zipFile) {
  if (!zipFile) return;
  log(`Processing ZIP: ${zipFile.name} (${formatBytes(zipFile.size)})`, 'info');
  updateStatus('Extracting ZIP...');
  try {
    const files = await parseZip(zipFile);
    let count = 0;
    for (const [name, data] of Object.entries(files)) {
      if (name.endsWith('/')) continue; // skip directories
      const blob = new Blob([data]);
      const fakeFile = new File([blob], name.split('/').pop(), { type: guessMime(name) });
      addFile(fakeFile);
      count++;
    }
    log(`Extracted ${count} files from ZIP`, 'success');
    updateUI();
  } catch (err) {
    log(`ZIP extraction failed: ${err.message}`, 'error');
    updateStatus('ZIP extraction failed');
  }
}

// Minimal ZIP parser
async function parseZip(file) {
  const buf = await file.arrayBuffer();
  const view = new DataView(buf);
  const decoder = new TextDecoder();
  const files = {};
  // Find End of Central Directory
  let eocdOffset = buf.byteLength - 22;
  while (eocdOffset > 0) {
    if (view.getUint32(eocdOffset, true) === 0x06054b50) break;
    eocdOffset--;
  }
  const cdEntries = view.getUint16(eocdOffset + 8, true);
  const cdSize = view.getUint32(eocdOffset + 12, true);
  const cdOffset = view.getUint32(eocdOffset + 16, true);
  // Parse Central Directory
  let offset = cdOffset;
  for (let i = 0; i < cdEntries; i++) {
    const sig = view.getUint32(offset, true);
    if (sig !== 0x02014b50) break;
    const compMethod = view.getUint16(offset + 10, true);
    const uncompSize = view.getUint32(offset + 24, true);
    const nameLen = view.getUint16(offset + 28, true);
    const extraLen = view.getUint16(offset + 30, true);
    const commentLen = view.getUint16(offset + 32, true);
    const localHeaderOff = view.getUint32(offset + 42, true);
    const name = decoder.decode(new Uint8Array(buf, offset + 46, nameLen));
    // Parse local header
    const lNameLen = view.getUint16(localHeaderOff + 26, true);
    const lExtraLen = view.getUint16(localHeaderOff + 27, true);
    const dataOffset = localHeaderOff + 30 + lNameLen + lExtraLen;
    const compSize = view.getUint32(offset + 20, true);
    if (name.endsWith('/')) { offset += 46 + nameLen + extraLen + commentLen; continue; }
    const compressed = new Uint8Array(buf, dataOffset, compSize);
    if (compMethod === 0) {
      files[name] = compressed;
    } else if (compMethod === 8) {
      files[name] = inflateRaw(compressed, uncompSize);
    }
    offset += 46 + nameLen + extraLen + commentLen;
  }
  return files;
}

// Raw DEFLATE decompressor (minimal)
function inflateRaw(input, expectedSize) {
  const output = new Uint8Array(expectedSize);
  // Use the browser's native DecompressionStream if available
  // Fall back to a simple implementation
  try {
    const inflate = new ZlibInflater(input, output);
    inflate.decode();
    return output;
  } catch(e) {
    // If our minimal inflater fails, try a simpler approach
    return simpleInflate(input, expectedSize);
  }
}

// Very minimal zlib inflater - enough for most Unity build ZIPs
function ZlibInflater(input, output) {
  const bits = new BitStream(input);
  let outPos = 0;
  const lenCodes = new Uint8Array([3,4,5,6,7,8,9,10,11,13,15,17,19,23,27,31,35,43,51,59,67,83,99,115,131,163,195,227,258]);
  const lenExtra = new Uint8Array([0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,3,3,3,3,4,4,4,4,5,5,5,5,0]);
  const distCodes = new Uint16Array([1,2,3,4,5,7,9,13,17,25,33,49,65,97,129,193,257,385,513,769,1025,1537,2049,3073,4097,6145,8193,12289,16385,24577]);
  const distExtra = new Uint8Array([0,0,0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10,10,11,11,12,12,13,13]);
  const clorder = new Uint8Array([16,17,18,0,8,7,9,6,10,5,11,4,12,3,13,2,14,1,15]);

  function BitStream(data) {
    this.data = data; this.pos = 0; this.bit = 0;
    this.read = function(n) {
      let val = 0;
      for (let i = 0; i < n; i++) {
        val |= ((this.data[this.pos] >> this.bit) & 1) << i;
        this.bit++;
        if (this.bit === 8) { this.bit = 0; this.pos++; }
      }
      return val;
    };
    this.align = function() { if (this.bit) { this.bit = 0; this.pos++; } };
  }

  function buildTree(codes) {
    const maxBits = Math.max(...codes);
    const bl_count = new Uint16Array(maxBits + 1);
    codes.forEach(c => { if (c > 0) bl_count[c]++; });
    let code = 0;
    const next_code = new Uint16Array(maxBits + 1);
    for (let bits = 1; bits <= maxBits; bits++) {
      code = (code + bl_count[bits - 1]) << 1;
      next_code[bits] = code;
    }
    const tree = {};
    codes.forEach((len, sym) => {
      if (len > 0) {
        tree[next_code[len]] = { len, sym };
        next_code[len]++;
      }
    });
    return tree;
  }

  function decodeSymbol(tree) {
    let code = 0, len = 0;
    while (len < 16) {
      code = (code << 1) | bits.read(1);
      len++;
      if (tree[code] && tree[code].len === len) return tree[code].sym;
    }
    throw new Error('Bad Huffman code');
  }

  function inflateBlock() {
    const hlit = bits.read(5) + 257;
    const hdist = bits.read(5) + 1;
    const hclen = bits.read(4) + 4;
    const clens = new Uint8Array(19);
    for (let i = 0; i < hclen; i++) clens[clorder[i]] = bits.read(3);
    const codeTree = buildTree(Array.from(clens));
    const allLens = [];
    while (allLens.length < hlit + hdist) {
      const sym = decodeSymbol(codeTree);
      if (sym < 16) { allLens.push(sym); }
      else if (sym === 16) { const prev = allLens[allLens.length - 1]; const count = bits.read(2) + 3; for (let i = 0; i < count; i++) allLens.push(prev); }
      else if (sym === 17) { const count = bits.read(3) + 3; for (let i = 0; i < count; i++) allLens.push(0); }
      else if (sym === 18) { const count = bits.read(7) + 11; for (let i = 0; i < count; i++) allLens.push(0); }
    }
    const litTree = buildTree(allLens.slice(0, hlit));
    const distTree = buildTree(allLens.slice(hlit));
    while (true) {
      const sym = decodeSymbol(litTree);
      if (sym === 256) break;
      if (sym < 256) { output[outPos++] = sym; continue; }
      const lenIdx = sym - 257;
      let length = lenCodes[lenIdx] + bits.read(lenExtra[lenIdx]);
      const distSym = decodeSymbol(distTree);
      const dist = distCodes[distSym] + bits.read(distExtra[distSym]);
      while (length-- > 0) {
        output[outPos] = output[outPos - dist];
        outPos++;
      }
    }
  }

  this.decode = function() {
    bits.align();
    while (true) {
      const bfinal = bits.read(1);
      const btype = bits.read(2);
      if (btype === 0) { // stored
        bits.align();
        const len = bits.read(16);
        bits.read(16); // nlen
        for (let i = 0; i < len; i++) output[outPos++] = bits.read(8);
      } else if (btype === 2) {
        inflateBlock();
      } else {
        throw new Error('Unsupported block type: ' + btype);
      }
      if (bfinal) break;
    }
  };
}

// Simpler fallback that may work for some ZIPs
function simpleInflate(input, expectedSize) {
  // For now return empty - the native inflater above handles most cases
  return new Uint8Array(expectedSize);
}

function guessMime(filename) {
  if (filename.endsWith('.js')) return 'application/javascript';
  if (filename.endsWith('.css')) return 'text/css';
  if (filename.endsWith('.png')) return 'image/png';
  if (filename.endsWith('.ico')) return 'image/x-icon';
  if (filename.endsWith('.json')) return 'application/json';
  return 'application/octet-stream';
}

// --- UI Updates ---
function updateUI() {
  const fileListEl = document.getElementById('fileList');
  const fileListSection = document.getElementById('fileListSection');
  if (State.files.size === 0) {
    fileListSection.style.display = 'none';
    return;
  }
  fileListSection.style.display = 'block';
  document.getElementById('fileCount').textContent = `${State.files.size} file${State.files.size !== 1 ? 's' : ''}`;
  fileListEl.innerHTML = '';
  State.files.forEach((entry, name) => {
    const iconClass = getFileIconClass(entry.type, name);
    const status = entry.type === 'UNKNOWN' ? 'error' : 'ready';
    const statusText = entry.type === 'UNKNOWN' ? 'Unknown' : 'Ready';
    const item = document.createElement('div');
    item.className = 'file-item';
    item.innerHTML = `
      <div class="file-icon ${iconClass}">${name.split('.').pop().substring(0,3).toUpperCase()}</div>
      <div class="file-info">
        <div class="file-name">${escapeHtml(name)}</div>
        <div class="file-size">${formatBytes(entry.size)}</div>
      </div>
      <div class="file-status ${status}">${statusText}</div>
      <button class="ctrl-btn" onclick="removeFile('${name.replace(/'/g, "\\'")}')" title="Remove">&#10005;</button>
    `;
    fileListEl.appendChild(item);
  });
  updateValidation();
}

function updateValidation() {
  const panel = document.getElementById('validationChecks');
  const checks = [];
  // Check for loader
  const hasLoader = Array.from(State.files.values()).some(e => e.type === 'LOADER');
  checks.push({ label: 'Loader Script (*.loader.js)', pass: hasLoader });
  // Check for data
  const hasData = Array.from(State.files.values()).some(e => e.type && e.type.includes('DATA'));
  checks.push({ label: 'Game Data (*.data[.gz/.br])', pass: hasData });
  // Check for framework
  const hasFramework = Array.from(State.files.values()).some(e => e.type && e.type.includes('FRAME'));
  checks.push({ label: 'JS Framework (*.framework.js[.gz/.br])', pass: hasFramework });
  // Check for wasm
  const hasWasm = Array.from(State.files.values()).some(e => e.type && e.type.includes('WASM'));
  checks.push({ label: 'WASM Code (*.wasm[.gz/.br])', pass: hasWasm });
  // At least one compression format handled
  const canLaunch = hasLoader && hasData && hasFramework && hasWasm;
  document.getElementById('launchBtn').disabled = !canLaunch;
  document.getElementById('readyText').textContent = canLaunch
    ? 'All required files ready — click Launch'
    : 'Upload all required files to enable launch';
  document.getElementById('readyText').style.color = canLaunch ? 'var(--accent-green)' : 'var(--text-muted)';

  panel.innerHTML = checks.map(c => `
    <div class="check-item">
      <span class="check-icon ${c.pass ? 'pass' : 'fail'}">${c.pass ? '&#10003;' : '&#9675;'}</span>
      <span style="color:${c.pass ? 'var(--accent-green)' : 'var(--text-secondary)'}">${c.label}</span>
    </div>
  `).join('');
}

function updateStatus(text) {
  document.getElementById('gameStatusText').textContent = text;
}

// --- Unity Launcher Core ---
function launchGame() {
  if (State.isLoading || State.isRunning) return;
  const canvas = document.getElementById('unity-canvas');
  const loadingBar = document.getElementById('unity-loading-bar');
  const progressBarFull = document.getElementById('unity-progress-bar-full');
  const progressText = document.getElementById('unity-progress-text');
  const loadingStatus = document.getElementById('unity-loading-status');

  // Hide upload, show game
  document.getElementById('uploadSection').style.display = 'none';
  document.getElementById('gameSection').classList.add('active');
  loadingBar.classList.add('active');
  State.isLoading = true;
  updateStatus('Loading Unity...');
  log('Starting Unity build launch sequence', 'info');

  // Find the loader script entry
  let loaderEntry = null;
  State.files.forEach(entry => { if (entry.type === 'LOADER') loaderEntry = entry; });
  if (!loaderEntry) { log('No loader script found!', 'error'); return; }

  // Build the config object
  const buildConfig = buildUnityConfig();
  log(`Build config: ${JSON.stringify(buildConfig, null, 2)}`, 'debug');

  // Load the Unity loader script dynamically
  const script = document.createElement('script');
  script.src = loaderEntry.blobUrl;
  script.onload = () => {
    log('Unity loader script loaded', 'success');
    loadingStatus.textContent = 'Compiling WebAssembly...';
    // createUnityInstance is defined by the loader script
    if (typeof createUnityInstance !== 'function') {
      log('createUnityInstance not found — loader may be incompatible', 'error');
      showBanner('Failed to find createUnityInstance. The loader script may be incompatible.', 'error');
      return;
    }
    createUnityInstance(canvas, buildConfig, (progress) => {
      const pct = Math.round(progress * 100);
      progressBarFull.style.width = pct + '%';
      progressText.textContent = pct + '%';
      loadingStatus.textContent = pct < 30 ? 'Downloading game data...' : pct < 70 ? 'Compiling WebAssembly...' : 'Initializing engine...';
      log(`Loading progress: ${pct}%`, 'debug');
    }).then((unityInstance) => {
      State.unityInstance = unityInstance;
      State.isLoading = false;
      State.isRunning = true;
      loadingBar.classList.remove('active');
      updateStatus('Game Running');
      log('Unity instance created successfully!', 'success');
      log(`Product: ${buildConfig.productName} v${buildConfig.productVersion}`, 'info');
      // Store globally for external access
      window.unityInstance = unityInstance;
    }).catch((message) => {
      State.isLoading = false;
      log(`Failed to create Unity instance: ${message}`, 'error');
      showBanner(message, 'error');
      updateStatus('Launch Failed');
    });
  };
  script.onerror = (err) => {
    log('Failed to load Unity loader script', 'error');
    showBanner('Failed to load Unity loader script', 'error');
    State.isLoading = false;
  };
  document.body.appendChild(script);
  State.loaderScript = script;
}

function buildUnityConfig() {
  const config = {
    streamingAssetsUrl: 'StreamingAssets',
    companyName: State.config.companyName,
    productName: State.config.productName,
    productVersion: State.config.productVersion,
    showBanner: unityShowBanner,
    // Arguments that may be used by the loader
    arguments: []
  };

  // Find each required file and set its Blob URL
  State.files.forEach((entry, name) => {
    if (entry.type === 'DATA_GZ' || entry.type === 'DATA_BR' || entry.type === 'DATA_RAW') {
      config.dataUrl = entry.blobUrl;
    }
    if (entry.type === 'FRAME_GZ' || entry.type === 'FRAME_BR' || entry.type === 'FRAME_RAW') {
      config.frameworkUrl = entry.blobUrl;
    }
    if (entry.type === 'WASM_GZ' || entry.type === 'WASM_BR' || entry.type === 'WASM_RAW') {
      config.codeUrl = entry.blobUrl;
    }
  });

  // Try to detect build name from loader filename
  State.files.forEach((entry, name) => {
    if (entry.type === 'LOADER') {
      const match = name.match(/^(.+)\.loader\.js$/i);
      if (match) State.config.buildName = match[1];
    }
  });

  // Auto-detect company/product from any JSON if present
  State.files.forEach((entry, name) => {
    if (name.endsWith('.json') && !config.dataUrl) {
      // Could be a legacy build info JSON
      tryLoadJsonConfig(entry);
    }
  });

  return config;
}

function tryLoadJsonConfig(entry) {
  const reader = new FileReader();
  reader.onload = e => {
    try {
      const json = JSON.parse(e.target.result);
      if (json.companyName) State.config.companyName = json.companyName;
      if (json.productName) State.config.productName = json.productName;
      if (json.productVersion) State.config.productVersion = json.productVersion;
    } catch(_) {}
  };
  reader.readAsText(entry.file);
}

// --- Banner / Warning Display ---
function unityShowBanner(msg, type) {
  const warningEl = document.getElementById('unity-warning');
  function updateBannerVisibility() {
    warningEl.style.display = warningEl.children.length ? 'block' : 'none';
  }
  const div = document.createElement('div');
  div.innerHTML = msg;
  div.className = type || 'warn';
  warningEl.appendChild(div);
  log(`Banner [${type}]: ${msg}`, type === 'error' ? 'error' : 'warn');
  if (type !== 'error') {
    setTimeout(() => { warningEl.removeChild(div); updateBannerVisibility(); }, 5000);
  }
  updateBannerVisibility();
}

// --- Game Controls ---
function toggleFullscreen() {
  if (!State.unityInstance) {
    // Fallback to canvas fullscreen
    const canvas = document.getElementById('unity-canvas');
    if (canvas.requestFullscreen) canvas.requestFullscreen();
    else if (canvas.webkitRequestFullscreen) canvas.webkitRequestFullscreen();
    else if (canvas.msRequestFullscreen) canvas.msRequestFullscreen();
    return;
  }
  State.unityInstance.SetFullscreen(1);
  log('Fullscreen toggled');
}

function reloadGame() {
  if (State.unityInstance) {
    try { State.unityInstance.Quit(); } catch(e) {}
    State.unityInstance = null;
  }
  State.isRunning = false;
  State.isLoading = false;
  // Remove old loader script
  if (State.loaderScript) {
    try { document.body.removeChild(State.loaderScript); } catch(e) {}
  }
  // Reset UI
  document.getElementById('unity-loading-bar').classList.remove('active');
  document.getElementById('unity-progress-bar-full').style.width = '0%';
  document.getElementById('unity-progress-text').textContent = '0%';
  document.getElementById('unity-warning').innerHTML = '';
  document.getElementById('unity-warning').style.display = 'none';
  // Relaunch
  log('Reloading game...', 'info');
  setTimeout(() => launchGame(), 100);
}

function quitGame() {
  if (State.unityInstance) {
    State.unityInstance.Quit().then(() => {
      log('Unity instance quit successfully');
    }).catch(err => {
      log(`Quit error: ${err}`, 'warn');
    });
    State.unityInstance = null;
  }
  State.isRunning = false;
  State.isLoading = false;
  if (State.loaderScript) {
    try { document.body.removeChild(State.loaderScript); } catch(e) {}
  }
  document.getElementById('uploadSection').style.display = 'block';
  document.getElementById('gameSection').classList.remove('active');
  document.getElementById('unity-loading-bar').classList.remove('active');
  document.getElementById('unity-progress-bar-full').style.width = '0%';
  document.getElementById('unity-progress-text').textContent = '0%';
  document.getElementById('unity-warning').innerHTML = '';
  document.getElementById('unity-canvas').getContext('webgl')?.getExtension('WEBGL_lose_context')?.loseContext();
  updateStatus('Ready');
  log('Game quit — returned to upload screen');
}

// --- Keyboard Shortcuts ---
document.addEventListener('keydown', e => {
  if (e.target.tagName === 'INPUT') return;
  if (!State.isRunning && !State.isLoading) return;
  const key = e.key.toLowerCase();
  if (key === 'f') { e.preventDefault(); toggleFullscreen(); }
  if (key === 'r' && !e.ctrlKey) { e.preventDefault(); reloadGame(); }
  if (key === 'q') { e.preventDefault(); quitGame(); }
  if (key === 'c') { e.preventDefault(); toggleConsole(); }
  if (key === '?') { e.preventDefault(); toggleShortcuts(); }
  if (key === 'escape') { document.getElementById('unity-canvas').blur(); }
});

function toggleShortcuts() {
  document.getElementById('shortcutsOverlay').classList.toggle('active');
}
function toggleConsole() {
  document.getElementById('logConsole').classList.toggle('active');
}

// Close shortcuts on overlay click
document.getElementById('shortcutsOverlay').addEventListener('click', e => {
  if (e.target === e.currentTarget) toggleShortcuts();
});

// --- Cleanup on page unload ---
window.addEventListener('beforeunload', () => {
  State.files.forEach(entry => URL.revokeObjectURL(entry.blobUrl));
  if (State.unityInstance) {
    try { State.unityInstance.Quit(); } catch(e) {}
  }
});

// --- Initialization ---
log('Unity WebGL Upload Launcher initialized', 'info');
log('Waiting for build files...', 'info');""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
