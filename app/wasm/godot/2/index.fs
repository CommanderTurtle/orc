module ConvertedFiles.Wasm.Godot.N2.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            meta [ attr "http-equiv" "X-UA-Compatible"; attr "content" "IE=edge" ]
            title [] [
                str "Godot Game Launcher - Directory Loader"
            ]
            style [] [
                    rawText ("""/* ============================================
           GODOT GAME LAUNCHER - PLACEHOLDER VARIANT
           Standalone HTML file - no external dependencies
           ============================================ */

        /* ---- CSS Reset & Base ---- */
        *, *::before, *::after {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        :root {
            /* Godot-inspired dark theme palette */
            --bg-primary: #0d0d0d;
            --bg-secondary: #1a1a1a;
            --bg-surface: #252526;
            --bg-elevated: #2d2d30;
            --bg-hover: #3e3e42;
            --border-subtle: #333337;
            --border-default: #454545;
            --border-focus: #478cbf;
            --text-primary: #e8e8e8;
            --text-secondary: #a0a0a0;
            --text-muted: #666666;
            --godot-blue: #478cbf;
            --godot-blue-light: #5a9fd4;
            --godot-blue-dark: #3a6d99;
            --accent-orange: #ff8f44;
            --success: #2ecc71;
            --error: #e74c3c;
            --warning: #f39c12;
            --info: #3498db;
            --glass-bg: rgba(37, 37, 38, 0.75);
            --glass-border: rgba(71, 140, 191, 0.2);
            --shadow-sm: 0 2px 8px rgba(0,0,0,0.3);
            --shadow-md: 0 4px 16px rgba(0,0,0,0.4);
            --shadow-lg: 0 8px 32px rgba(0,0,0,0.5);
            --radius-sm: 6px;
            --radius-md: 10px;
            --radius-lg: 16px;
            --transition-fast: 150ms ease;
            --transition-normal: 300ms ease;
            --transition-slow: 500ms ease;
        }

        html, body {
            width: 100%;
            height: 100%;
            overflow: hidden;
        }

        body {
            font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
            background: var(--bg-primary);
            color: var(--text-primary);
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }

        /* ---- Animated Background Grid ---- */
        .bg-grid {
            position: fixed;
            inset: 0;
            z-index: 0;
            pointer-events: none;
            background-image:
                linear-gradient(rgba(71, 140, 191, 0.03) 1px, transparent 1px),
                linear-gradient(90deg, rgba(71, 140, 191, 0.03) 1px, transparent 1px);
            background-size: 50px 50px;
            animation: gridMove 20s linear infinite;
        }

        @keyframes gridMove {
            0% { background-position: 0 0; }
            100% { background-position: 50px 50px; }
        }

        /* ---- Floating Orbs ---- */
        .orb {
            position: fixed;
            border-radius: 50%;
            filter: blur(80px);
            opacity: 0.15;
            pointer-events: none;
            z-index: 0;
        }
        .orb-1 {
            width: 400px; height: 400px;
            background: var(--godot-blue);
            top: -100px; left: -100px;
            animation: orbFloat1 12s ease-in-out infinite;
        }
        .orb-2 {
            width: 300px; height: 300px;
            background: var(--accent-orange);
            bottom: -80px; right: -80px;
            animation: orbFloat2 15s ease-in-out infinite;
        }
        .orb-3 {
            width: 250px; height: 250px;
            background: #7b68ee;
            top: 50%; left: 50%;
            animation: orbFloat3 18s ease-in-out infinite;
        }

        @keyframes orbFloat1 {
            0%, 100% { transform: translate(0, 0) scale(1); }
            33% { transform: translate(50px, 30px) scale(1.1); }
            66% { transform: translate(20px, 60px) scale(0.9); }
        }
        @keyframes orbFloat2 {
            0%, 100% { transform: translate(0, 0) scale(1); }
            33% { transform: translate(-40px, -30px) scale(1.15); }
            66% { transform: translate(-60px, 20px) scale(0.85); }
        }
        @keyframes orbFloat3 {
            0%, 100% { transform: translate(-50%, -50%) scale(1); }
            50% { transform: translate(-40%, -60%) scale(1.2); }
        }

        /* ---- Main Container ---- */
        #app {
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

        /* ---- App Header ---- */
        .app-header {
            position: absolute;
            top: 0; left: 0; right: 0;
            display: flex;
            align-items: center;
            justify-content: space-between;
            padding: 16px 24px;
            background: linear-gradient(to bottom, rgba(13,13,13,0.9), transparent);
            z-index: 10;
        }

        .logo {
            display: flex;
            align-items: center;
            gap: 12px;
        }

        .logo-icon {
            width: 36px;
            height: 36px;
            position: relative;
        }
        .logo-icon::before {
            content: "";
            position: absolute;
            inset: 0;
            background: var(--godot-blue);
            border-radius: 50%;
            box-shadow: 0 0 12px rgba(71,140,191,0.4);
        }
        .logo-icon::after {
            content: "G";
            position: absolute;
            inset: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 18px;
            font-weight: 800;
            color: white;
        }

        .logo-text {
            font-size: 18px;
            font-weight: 700;
            color: var(--text-primary);
            letter-spacing: -0.5px;
        }
        .logo-text span {
            color: var(--godot-blue);
            font-weight: 500;
        }

        .app-version {
            font-size: 11px;
            color: var(--text-muted);
            font-family: "SF Mono", Monaco, "Cascadia Code", monospace;
        }

        /* ---- Screen Management ---- */
        .screen {
            display: none;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            animation: fadeIn 0.5s ease;
            width: 100%;
            max-width: 640px;
        }
        .screen.active {
            display: flex;
        }

        @keyframes fadeIn {
            from { opacity: 0; transform: translateY(10px); }
            to { opacity: 1; transform: translateY(0); }
        }

        @keyframes slideUp {
            from { opacity: 0; transform: translateY(20px); }
            to { opacity: 1; transform: translateY(0); }
        }

        @keyframes pulse {
            0%, 100% { opacity: 1; }
            50% { opacity: 0.5; }
        }

        @keyframes spin {
            from { transform: rotate(0deg); }
            to { transform: rotate(360deg); }
        }

        /* ---- Glass Panel ---- */
        .glass-panel {
            background: var(--glass-bg);
            backdrop-filter: blur(16px);
            -webkit-backdrop-filter: blur(16px);
            border: 1px solid var(--glass-border);
            border-radius: var(--radius-lg);
            box-shadow: var(--shadow-lg), inset 0 1px 0 rgba(255,255,255,0.05);
            padding: 32px;
            width: 100%;
        }

        /* ---- Configuration Form ---- */
        .config-group {
            margin-bottom: 20px;
        }
        .config-label {
            display: block;
            font-size: 13px;
            font-weight: 500;
            color: var(--text-secondary);
            margin-bottom: 6px;
        }
        .config-input {
            width: 100%;
            padding: 12px 16px;
            background: var(--bg-elevated);
            border: 1px solid var(--border-subtle);
            border-radius: var(--radius-md);
            color: var(--text-primary);
            font-family: "SF Mono", Monaco, "Cascadia Code", monospace;
            font-size: 13px;
            outline: none;
            transition: all var(--transition-fast);
        }
        .config-input:focus {
            border-color: var(--godot-blue);
            box-shadow: 0 0 0 3px rgba(71,140,191,0.15);
        }
        .config-input::placeholder {
            color: var(--text-muted);
        }

        .config-hint {
            font-size: 11px;
            color: var(--text-muted);
            margin-top: 6px;
            line-height: 1.5;
        }

        .config-hint code {
            background: var(--bg-elevated);
            padding: 1px 5px;
            border-radius: 3px;
            font-size: 10px;
        }

        /* ---- Path Presets ---- */
        .preset-row {
            display: flex;
            gap: 8px;
            flex-wrap: wrap;
            margin-top: 8px;
        }
        .preset-btn {
            padding: 6px 12px;
            background: var(--bg-elevated);
            border: 1px solid var(--border-subtle);
            border-radius: var(--radius-sm);
            color: var(--text-secondary);
            font-size: 11px;
            font-family: "SF Mono", monospace;
            cursor: pointer;
            transition: all var(--transition-fast);
        }
        .preset-btn:hover {
            border-color: var(--godot-blue);
            color: var(--godot-blue-light);
        }

        /* ---- File Check List ---- */
        .check-list {
            display: flex;
            flex-direction: column;
            gap: 8px;
            margin: 16px 0;
        }
        .check-item {
            display: flex;
            align-items: center;
            gap: 12px;
            padding: 10px 14px;
            background: var(--bg-elevated);
            border: 1px solid var(--border-subtle);
            border-radius: var(--radius-md);
            font-size: 13px;
            transition: all var(--transition-fast);
            animation: slideUp 0.3s ease;
        }
        .check-item.found {
            border-left: 3px solid var(--success);
        }
        .check-item.missing {
            border-left: 3px solid var(--error);
        }
        .check-item.checking {
            border-left: 3px solid var(--warning);
        }

        .check-icon {
            font-size: 18px;
            width: 24px;
            text-align: center;
        }
        .check-name {
            flex: 1;
            font-family: "SF Mono", monospace;
            font-size: 12px;
        }
        .check-status {
            font-size: 11px;
            color: var(--text-muted);
        }

        /* ---- Progress Bar ---- */
        .progress-container {
            width: 100%;
            max-width: 480px;
            text-align: center;
        }
        .progress-title {
            font-size: 16px;
            font-weight: 600;
            margin-bottom: 8px;
            color: var(--text-primary);
        }
        .progress-subtitle {
            font-size: 13px;
            color: var(--text-secondary);
            margin-bottom: 24px;
        }
        .progress-detail {
            font-size: 11px;
            color: var(--text-muted);
            font-family: "SF Mono", monospace;
            margin-top: 8px;
        }
        .progress-bar-track {
            width: 100%;
            height: 8px;
            background: var(--bg-elevated);
            border-radius: 4px;
            overflow: hidden;
            position: relative;
        }
        .progress-bar-fill {
            height: 100%;
            background: linear-gradient(90deg, var(--godot-blue), var(--godot-blue-light));
            border-radius: 4px;
            transition: width 0.3s ease;
            position: relative;
        }
        .progress-bar-fill.indeterminate {
            width: 40%;
            animation: progressSlide 1.5s ease-in-out infinite;
        }
        @keyframes progressSlide {
            0% { transform: translateX(-100%); }
            50% { transform: translateX(150%); }
            100% { transform: translateX(-100%); }
        }

        /* ---- Spinner ---- */
        .spinner {
            width: 48px;
            height: 48px;
            border: 3px solid var(--bg-elevated);
            border-top-color: var(--godot-blue);
            border-radius: 50%;
            animation: spin 0.8s linear infinite;
            margin-bottom: 16px;
        }

        /* ---- Buttons ---- */
        .btn {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
            padding: 12px 24px;
            border: none;
            border-radius: var(--radius-md);
            font-size: 14px;
            font-weight: 600;
            cursor: pointer;
            transition: all var(--transition-fast);
            font-family: inherit;
            outline: none;
            position: relative;
            overflow: hidden;
        }
        .btn:disabled {
            opacity: 0.5;
            cursor: not-allowed;
        }
        .btn-primary {
            background: linear-gradient(135deg, var(--godot-blue), var(--godot-blue-dark));
            color: white;
            box-shadow: 0 4px 16px rgba(71,140,191,0.3);
        }
        .btn-primary:hover:not(:disabled) {
            transform: translateY(-2px);
            box-shadow: 0 6px 20px rgba(71,140,191,0.4);
        }
        .btn-secondary {
            background: var(--bg-elevated);
            color: var(--text-primary);
            border: 1px solid var(--border-default);
        }
        .btn-secondary:hover {
            background: var(--bg-hover);
            border-color: var(--border-focus);
        }
        .btn-sm {
            padding: 8px 16px;
            font-size: 12px;
        }
        .btn-row {
            display: flex;
            gap: 12px;
            margin-top: 20px;
            flex-wrap: wrap;
            justify-content: center;
        }

        /* ---- Status Badge ---- */
        .status-badge {
            display: inline-flex;
            align-items: center;
            gap: 6px;
            padding: 6px 12px;
            border-radius: var(--radius-sm);
            font-size: 12px;
            font-weight: 500;
        }
        .status-badge.success {
            background: rgba(46, 204, 113, 0.1);
            color: var(--success);
            border: 1px solid rgba(46, 204, 113, 0.2);
        }
        .status-badge.error {
            background: rgba(231, 76, 60, 0.1);
            color: var(--error);
            border: 1px solid rgba(231, 76, 60, 0.2);
        }
        .status-badge.warning {
            background: rgba(243, 156, 18, 0.1);
            color: var(--warning);
            border: 1px solid rgba(243, 156, 18, 0.2);
        }

        /* ---- Game Container ---- */
        #gameContainer {
            display: none;
            position: fixed;
            inset: 0;
            z-index: 100;
            background: black;
        }
        #gameContainer.active {
            display: flex;
        }
        #gameCanvas {
            width: 100%;
            height: 100%;
            display: block;
            outline: none;
        }

        /* ---- Game Controls Overlay ---- */
        .game-controls {
            position: absolute;
            top: 0; left: 0; right: 0;
            display: flex;
            align-items: center;
            justify-content: space-between;
            padding: 12px 16px;
            background: linear-gradient(to bottom, rgba(0,0,0,0.7), transparent);
            opacity: 0;
            transition: opacity var(--transition-normal);
            z-index: 101;
            pointer-events: none;
        }
        .game-controls.visible {
            opacity: 1;
            pointer-events: all;
        }
        .game-controls:hover {
            opacity: 1;
            pointer-events: all;
        }
        .game-title {
            font-size: 14px;
            font-weight: 600;
            color: white;
            text-shadow: 0 1px 4px rgba(0,0,0,0.5);
        }
        .game-buttons {
            display: flex;
            gap: 8px;
        }
        .game-btn {
            background: rgba(255,255,255,0.15);
            border: 1px solid rgba(255,255,255,0.2);
            color: white;
            padding: 6px 12px;
            border-radius: var(--radius-sm);
            font-size: 12px;
            cursor: pointer;
            transition: all var(--transition-fast);
            backdrop-filter: blur(8px);
            font-family: inherit;
        }
        .game-btn:hover {
            background: rgba(255,255,255,0.25);
        }

        /* ---- Error Display ---- */
        .error-box {
            background: rgba(231, 76, 60, 0.08);
            border: 1px solid rgba(231, 76, 60, 0.25);
            border-radius: var(--radius-md);
            padding: 16px;
            margin-top: 16px;
        }
        .error-title {
            font-size: 13px;
            font-weight: 600;
            color: var(--error);
            margin-bottom: 6px;
        }
        .error-text {
            font-size: 12px;
            color: var(--text-secondary);
            line-height: 1.6;
        }
        .error-text code {
            background: var(--bg-elevated);
            padding: 2px 5px;
            border-radius: 3px;
            font-family: monospace;
            font-size: 11px;
        }

        /* ---- Info Box ---- */
        .info-box {
            background: rgba(71, 140, 191, 0.06);
            border: 1px solid rgba(71, 140, 191, 0.15);
            border-radius: var(--radius-md);
            padding: 16px;
            margin-top: 16px;
        }
        .info-box-title {
            font-size: 12px;
            font-weight: 600;
            color: var(--godot-blue-light);
            margin-bottom: 8px;
            text-transform: uppercase;
            letter-spacing: 0.5px;
        }
        .info-list {
            list-style: none;
            font-size: 12px;
            color: var(--text-secondary);
            line-height: 1.8;
        }
        .info-list li::before {
            content: "\2022  ";
            color: var(--godot-blue);
        }
        .info-list code {
            background: var(--bg-elevated);
            padding: 2px 5px;
            border-radius: 3px;
            font-family: "SF Mono", monospace;
            font-size: 11px;
        }

        /* ---- Directory Tree Preview ---- */
        .tree-preview {
            background: var(--bg-elevated);
            border: 1px solid var(--border-subtle);
            border-radius: var(--radius-md);
            padding: 16px;
            margin: 12px 0;
            font-family: "SF Mono", monospace;
            font-size: 12px;
            line-height: 1.8;
        }
        .tree-line {
            color: var(--text-secondary);
        }
        .tree-line.dir {
            color: var(--godot-blue-light);
        }
        .tree-line.file {
            color: var(--text-secondary);
        }
        .tree-line.expected::before {
            content: "\2610  ";
            color: var(--text-muted);
        }
        .tree-line.expected.found::before {
            content: "\2611  ";
            color: var(--success);
        }
        .tree-indent {
            color: var(--border-default);
        }

        /* ---- Keyboard Shortcuts Overlay ---- */
        .shortcuts-overlay {
            display: none;
            position: fixed;
            inset: 0;
            z-index: 200;
            background: rgba(0,0,0,0.7);
            backdrop-filter: blur(8px);
            align-items: center;
            justify-content: center;
            animation: fadeIn 0.2s ease;
        }
        .shortcuts-overlay.active {
            display: flex;
        }
        .shortcuts-panel {
            background: var(--bg-surface);
            border: 1px solid var(--border-default);
            border-radius: var(--radius-lg);
            padding: 24px 32px;
            max-width: 420px;
            width: 90%;
            box-shadow: var(--shadow-lg);
        }
        .shortcuts-title {
            font-size: 16px;
            font-weight: 600;
            margin-bottom: 16px;
            text-align: center;
        }
        .shortcut-row {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 8px 0;
            border-bottom: 1px solid var(--border-subtle);
            font-size: 13px;
        }
        .shortcut-row:last-child {
            border-bottom: none;
        }
        kbd {
            background: var(--bg-elevated);
            border: 1px solid var(--border-default);
            border-radius: 4px;
            padding: 2px 8px;
            font-family: "SF Mono", monospace;
            font-size: 11px;
            color: var(--text-primary);
            box-shadow: 0 2px 0 var(--border-default);
        }
        .shortcuts-close {
            margin-top: 16px;
            width: 100%;
        }

        /* ---- Responsive ---- */
        @media (max-width: 640px) {
            .glass-panel { padding: 20px; }
            .app-header { padding: 12px 16px; }
        }

        /* ---- Scrollbar ---- */
        ::-webkit-scrollbar { width: 8px; }
        ::-webkit-scrollbar-track { background: var(--bg-secondary); }
        ::-webkit-scrollbar-thumb { background: var(--border-default); border-radius: 4px; }
        ::-webkit-scrollbar-thumb:hover { background: var(--text-muted); }""")
            ]
        ]
        body [] [
            rawText ("""<!--  Ambient Background  -->""")
            div [ _class "bg-grid" ] []
            div [ _class "orb orb-1" ] []
            div [ _class "orb orb-2" ] []
            div [ _class "orb orb-3" ] []
            rawText ("""<!--  App Header  -->""")
            header [ _class "app-header" ] [
                div [ _class "logo" ] [
                    div [ _class "logo-icon" ] []
                    div [ _class "logo-text" ] [
                        str "Godot"
                        span [] [
                            str "Launcher"
                        ]
                    ]
                ]
                div [ _class "app-version" ] [
                    str "Directory Loader"
                ]
            ]
            rawText ("""<!--  Main App  -->""")
            div [ _id "app" ] [
                rawText ("""<!--  ===== SCREEN: Configure =====  -->""")
                div [ _class "screen active"; _id "screenConfig" ] [
                    div [ _class "glass-panel" ] [
                        h2 [ attr "style" "text-align:center; margin-bottom:8px; font-size:22px;" ] [
                            str "Directory Loader"
                        ]
                        p [ attr "style" "text-align:center; color:var(--text-secondary); font-size:14px; margin-bottom:24px;" ] [
                            str "Load a Godot HTML5 game from a local directory path"
                        ]
                        rawText ("""<!--  Status  -->""")
                        div [ attr "style" "text-align:center; margin-bottom:20px;"; _id "configStatus" ] [
                            span [ _class "status-badge warning" ] [
                                str "⚠ Not configured"
                            ]
                        ]
                        rawText ("""<!--  Path Configuration  -->""")
                        div [ _class "config-group" ] [
                            label [ _class "config-label"; attr "for" "pathInput" ] [
                                str "Game Directory Path"
                            ]
                            input [ _type "text"; _class "config-input"; _id "pathInput"; attr "placeholder" "e.g., ./game/ or ../my-game/"; attr "value" "./game/" ]
                            div [ _class "config-hint" ] [
                                str "Relative path to the directory containing your Godot HTML5 export files.\n                        The directory should contain the"
                                code [] [
                                    str ".wasm"
                                ]
                                str ","
                                code [] [
                                    str ".pck"
                                ]
                                str ", and"
                                code [] [
                                    str ".js"
                                ]
                                str "files."
                            ]
                        ]
                        rawText ("""<!--  Quick Presets  -->""")
                        div [ _class "preset-row" ] [
                            button [ _class "preset-btn"; attr "data-path" "./game/" ] [
                                str "./game/"
                            ]
                            button [ _class "preset-btn"; attr "data-path" "../game/" ] [
                                str "../game/"
                            ]
                            button [ _class "preset-btn"; attr "data-path" "./" ] [
                                str "./ (same dir)"
                            ]
                            button [ _class "preset-btn"; attr "data-path" "../" ] [
                                str "../ (parent dir)"
                            ]
                            button [ _class "preset-btn"; attr "data-path" "/game/" ] [
                                str "/game/ (root)"
                            ]
                        ]
                        rawText ("""<!--  Check Button  -->""")
                        div [ _class "btn-row" ] [
                            button [ _class "btn btn-primary"; _id "btnCheck" ] [
                                str "🔎 Check Files"
                            ]
                            button [ _class "btn btn-secondary btn-sm"; _id "btnScan" ] [
                                str "Scan Directory"
                            ]
                        ]
                        rawText ("""<!--  File Check Results  -->""")
                        div [ _class "check-list"; _id "checkList" ] []
                        rawText ("""<!--  Directory Tree Preview  -->""")
                        div [ _class "tree-preview"; _id "treePreview"; attr "style" "display:none;" ] []
                        rawText ("""<!--  Launch Button  -->""")
                        div [ _class "btn-row"; _id "launchRow"; attr "style" "display:none;" ] [
                            button [ _class "btn btn-primary"; _id "btnLaunch"; attr "disabled" "" ] [
                                str "► Launch Game"
                            ]
                            button [ _class "btn btn-secondary btn-sm"; _id "btnEditPath" ] [
                                str "Change Path"
                            ]
                        ]
                        rawText ("""<!--  Info Box  -->""")
                        div [ _class "info-box" ] [
                            div [ _class "info-box-title" ] [
                                str "Expected Directory Structure"
                            ]
                            ul [ _class "info-list" ] [
                                li [] [
                                    str "Export your project from Godot via"
                                    code [] [
                                        str "Project → Export → Web"
                                    ]
                                ]
                                li [] [
                                    str "Copy all exported files to the target directory"
                                ]
                                li [] [
                                    str "Files are typically named:"
                                    code [] [
                                        str "index.html"
                                    ]
                                    str ","
                                    code [] [
                                        str "index.js"
                                    ]
                                    str ","
                                    code [] [
                                        str "index.wasm"
                                    ]
                                    str ","
                                    code [] [
                                        str "index.pck"
                                    ]
                                ]
                                li [] [
                                    str "This page must be served from a web server (not file://) for the placeholder variant"
                                ]
                                li [] [
                                    str "Recommended hosting: GitHub Pages, Netlify, Vercel, or any static host"
                                ]
                            ]
                        ]
                        rawText ("""<!--  Auto-try info  -->""")
                        div [ _class "info-box"; attr "style" "margin-top:12px;" ] [
                            div [ _class "info-box-title" ] [
                                str "Auto-Detection"
                            ]
                            ul [ _class "info-list" ] [
                                li [] [
                                    str "On page load, this launcher automatically checks the default path"
                                ]
                                li [] [
                                    str "If all files are found, the Launch button appears automatically"
                                ]
                                li [] [
                                    str "Use the"
                                    strong [] [
                                        str "Scan Directory"
                                    ]
                                    str "button to discover files in non-standard layouts"
                                ]
                            ]
                        ]
                    ]
                ]
                rawText ("""<!--  ===== SCREEN: Loading =====  -->""")
                div [ _class "screen"; _id "screenLoading" ] [
                    div [ _class "progress-container" ] [
                        div [ _class "spinner" ] []
                        div [ _class "progress-title"; _id "loadingTitle" ] [
                            str "Loading..."
                        ]
                        div [ _class "progress-subtitle"; _id "loadingSubtitle" ] [
                            str "Initializing game engine"
                        ]
                        div [ _class "progress-bar-track" ] [
                            div [ _class "progress-bar-fill indeterminate"; _id "loadingBar" ] []
                        ]
                        div [ _class "progress-detail"; _id "loadingDetail" ] []
                    ]
                ]
                rawText ("""<!--  ===== SCREEN: Error =====  -->""")
                div [ _class "screen"; _id "screenError" ] [
                    div [ _class "glass-panel"; attr "style" "text-align:center;" ] [
                        div [ attr "style" "font-size:48px; margin-bottom:16px;" ] [
                            str "💥"
                        ]
                        h2 [ attr "style" "margin-bottom:8px;" ] [
                            str "Failed to Load Game"
                        ]
                        p [ attr "style" "color:var(--text-secondary); font-size:14px; margin-bottom:20px;"; _id "errorMessage" ] [
                            str "Could not load the game from the specified directory."
                        ]
                        div [ _class "error-box"; _id "errorDetail"; attr "style" "display:none; text-align:left;" ] []
                        div [ _class "btn-row" ] [
                            button [ _class "btn btn-primary"; _id "btnRetry" ] [
                                str "Retry"
                            ]
                            button [ _class "btn btn-secondary"; _id "btnBack" ] [
                                str "Change Path"
                            ]
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  ===== GAME CONTAINER =====  -->""")
            div [ _id "gameContainer" ] [
                canvas [ _id "gameCanvas"; attr "tabindex" "-1" ] []
                div [ _class "game-controls"; _id "gameControls" ] [
                    div [ _class "game-title"; _id "gameTitle" ] [
                        str "Godot Game"
                    ]
                    div [ _class "game-buttons" ] [
                        button [ _class "game-btn"; _id "btnFullscreen"; attr "title" "Fullscreen (F11)" ] [
                            str "⛶ Fullscreen"
                        ]
                        button [ _class "game-btn"; _id "btnShortcuts"; attr "title" "Keyboard Shortcuts (H)" ] [
                            str "⌨ Keys"
                        ]
                        button [ _class "game-btn"; attr "style" "background:rgba(231,76,60,0.2);border-color:rgba(231,76,60,0.4);"; _id "btnQuit"; attr "title" "Quit (Esc)" ] [
                            str "✕ Quit"
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  ===== KEYBOARD SHORTCUTS OVERLAY =====  -->""")
            div [ _class "shortcuts-overlay"; _id "shortcutsOverlay" ] [
                div [ _class "shortcuts-panel" ] [
                    div [ _class "shortcuts-title" ] [
                        str "⌨ Keyboard Shortcuts"
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Toggle Fullscreen"
                        ]
                        kbd [] [
                            str "F11"
                        ]
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Quit Game"
                        ]
                        kbd [] [
                            str "Esc"
                        ]
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Show/Hide Controls"
                        ]
                        kbd [] [
                            str "H"
                        ]
                    ]
                    div [ _class "shortcut-row" ] [
                        span [] [
                            str "Focus Game"
                        ]
                        kbd [] [
                            str "Click"
                        ]
                    ]
                    button [ _class "btn btn-primary shortcuts-close"; _id "btnCloseShortcuts" ] [
                        str "Got it"
                    ]
                ]
            ]
            script [] [
                    rawText ("""/* ============================================
           GODOT GAME LAUNCHER - PLACEHOLDER VARIANT
           Core JavaScript - ES6+ with async/await
           ============================================ */

        // ===== Configuration =====
        const CONFIG = {
            // Default path to look for game files
            defaultPath: './game/',
            // LocalStorage key for saved path
            storageKey: 'godot-launcher-path',
            // Files we need to find
            requiredExtensions: ['.wasm', '.pck', '.js'],
            // Common base names for Godot exports
            commonNames: ['index', 'game', 'godot', 'export', 'web'],
        };

        // ===== State =====
        const State = {
            currentPath: '',
            foundFiles: {},    // ext -> filename mapping
            engine: null,
            isGameRunning: false,
            engineScriptLoaded: false,
            discoveredFiles: [],
        };

        // ===== DOM References =====
        const $ = (id) => document.getElementById(id);

        // ===== Utility Functions =====
        const formatSize = (bytes) => {
            if (!bytes || bytes === 0) return 'Unknown';
            const units = ['B', 'KB', 'MB', 'GB'];
            const i = Math.floor(Math.log2(bytes) / 10);
            return (bytes / (1 << (i * 10))).toFixed(i > 0 ? 1 : 0) + ' ' + units[i];
        };

        const normalizePath = (path) => {
            if (!path) return './';
            // Ensure path ends with /
            if (!path.endsWith('/')) path += '/';
            return path;
        };

        const showScreen = (name) => {
            ['screenConfig', 'screenLoading', 'screenError'].forEach(id => {
                $(id).classList.remove('active');
            });
            $(name).classList.add('active');
        };

        const setLoading = (title, subtitle, detail = '') => {
            $('loadingTitle').textContent = title;
            $('loadingSubtitle').textContent = subtitle;
            $('loadingDetail').textContent = detail;
            showScreen('screenLoading');
        };

        const showError = (message, detail = '') => {
            $('errorMessage').textContent = message;
            const detailEl = $('errorDetail');
            if (detail) {
                detailEl.style.display = 'block';
                detailEl.innerHTML = `<div class="error-title">Details</div><div class="error-text">${detail}</div>`;
            } else {
                detailEl.style.display = 'none';
            }
            showScreen('screenError');
        };

        // ===== File Discovery =====

        /**
         * Try to fetch a file and return info if it exists
         */
        const checkFile = async (url) => {
            try {
                const response = await fetch(url, { method: 'HEAD', cache: 'no-cache' });
                if (response.ok) {
                    const size = response.headers.get('content-length');
                    return { exists: true, size: size ? parseInt(size, 10) : null, url };
                }
            } catch (e) {
                // Network error or CORS issue
            }
            return { exists: false, size: null, url };
        };

        /**
         * Discover game files in the configured directory.
         * Tries common naming patterns to find the engine files.
         */
        const discoverFiles = async (basePath) => {
            const found = {};
            const path = normalizePath(basePath);

            // Strategy 1: Try common base names with required extensions
            for (const name of CONFIG.commonNames) {
                for (const ext of CONFIG.requiredExtensions) {
                    const filename = name + ext;
                    const url = path + filename;
                    const result = await checkFile(url);

                    if (result.exists && !found[ext]) {
                        found[ext] = {
                            filename,
                            url,
                            size: result.size,
                            basename: name,
                        };
                    }
                }
            }

            // Strategy 2: If we found at least a .js file, check if there's an .html
            // file that might give us the correct base name
            if (found['.js'] || found['.wasm'] || found['.pck']) {
                // We have at least some files - try to find the HTML file
                // to get the correct executable name
                for (const name of CONFIG.commonNames) {
                    const htmlUrl = path + name + '.html';
                    const result = await checkFile(htmlUrl);
                    if (result.exists) {
                        // The HTML file name is usually the executable name
                        const correctBase = name;
                        // Re-check if we have all files with this base name
                        for (const ext of CONFIG.requiredExtensions) {
                            if (!found[ext]) {
                                const url = path + correctBase + ext;
                                const r = await checkFile(url);
                                if (r.exists) {
                                    found[ext] = {
                                        filename: correctBase + ext,
                                        url,
                                        size: r.size,
                                        basename: correctBase,
                                    };
                                }
                            }
                        }
                        break;
                    }
                }
            }

            return found;
        };

        /**
         * Scan a directory for all .wasm, .pck, .js files
         */
        const scanDirectory = async (basePath) => {
            const path = normalizePath(basePath);
            const discovered = [];

            // Try to find any files with our target extensions
            // by checking a broader set of potential names
            const scanNames = [
                ...CONFIG.commonNames,
                'app', 'build', 'webexport', 'dist', 'www',
                'project', 'main', 'play', 'start', 'client',
            ];

            for (const name of scanNames) {
                for (const ext of ['.wasm', '.pck', '.js', '.html', '.png']) {
                    const filename = name + ext;
                    const result = await checkFile(path + filename);
                    if (result.exists) {
                        discovered.push({
                            name: filename,
                            ext,
                            size: result.size,
                            path: path + filename,
                        });
                    }
                }
            }

            return discovered;
        };

        /**
         * Update the check list UI with file discovery results
         */
        const updateCheckList = (found) => {
            const list = $('checkList');
            list.innerHTML = '';

            const fileTypes = [
                { key: '.wasm', label: 'Engine Binary', icon: '&#9889;' },
                { key: '.pck', label: 'Game Package', icon: '&#127918;' },
                { key: '.js', label: 'Engine Loader', icon: '&#128221;' },
            ];

            let allFound = true;

            fileTypes.forEach(({ key, label, icon }) => {
                const file = found[key];
                const item = document.createElement('div');
                item.className = 'check-item ' + (file ? 'found' : 'missing');

                const statusIcon = file ? '&#10003;' : '&#10007;';
                const statusText = file
                    ? `${formatSize(file.size)}`
                    : 'Not found';

                item.innerHTML = `
                    <div class="check-icon">${icon}</div>
                    <div class="check-name">${file ? file.filename : label + ' (*' + key + ')'}</div>
                    <div class="check-status">${statusText}</div>
                    <div style="font-size:16px;margin-left:8px;">${statusIcon}</div>
                `;

                list.appendChild(item);
                if (!file) allFound = false;
            });

            // Update status badge
            const statusEl = $('configStatus');
            if (allFound) {
                statusEl.innerHTML = '<span class="status-badge success">&#10003; All files found</span>';
            } else {
                const foundCount = Object.keys(found).length;
                const totalCount = fileTypes.length;
                statusEl.innerHTML = `<span class="status-badge warning">&#9888; ${foundCount}/${totalCount} files found</span>`;
            }

            // Show/hide launch button
            $('launchRow').style.display = 'flex';
            $('btnLaunch').disabled = !allFound;

            return allFound;
        };

        /**
         * Update the directory tree preview
         */
        const updateTreePreview = (found, path) => {
            const tree = $('treePreview');
            const normPath = normalizePath(path);

            let html = `<div class="tree-line dir">&#128193; ${normPath}</div>`;

            const entries = [
                { key: '.wasm', label: 'Engine Binary' },
                { key: '.pck', label: 'Game Package' },
                { key: '.js', label: 'Engine Loader' },
            ];

            entries.forEach(({ key, label }) => {
                const file = found[key];
                const found = !!file;
                html += `<div class="tree-line expected ${found ? 'found' : ''}" style="padding-left:20px;">`;
                html += found
                    ? `&#128196; ${file.filename} <span style="color:var(--text-muted);">(${formatSize(file.size)})</span>`
                    : `<span style="color:var(--text-muted);">&#10007; *${key} (${label})</span>`;
                html += '</div>';
            });

            tree.innerHTML = html;
            tree.style.display = 'block';
        };

        // ===== Path Management =====

        /**
         * Load saved path from localStorage
         */
        const loadSavedPath = () => {
            try {
                const saved = localStorage.getItem(CONFIG.storageKey);
                if (saved) {
                    $('pathInput').value = saved;
                    return saved;
                }
            } catch (e) {
                // localStorage may not be available (private mode, etc.)
            }
            return CONFIG.defaultPath;
        };

        /**
         * Save path to localStorage
         */
        const savePath = (path) => {
            try {
                localStorage.setItem(CONFIG.storageKey, path);
            } catch (e) {
                // Ignore storage errors
            }
        };

        // ===== Godot Engine Integration =====

        /**
         * Load the engine JavaScript file from the specified path.
         * This creates a script element that loads the engine's .js file,
         * which provides the global `Engine` class.
         */
        const loadEngineScript = (url) => {
            return new Promise((resolve, reject) => {
                const script = document.createElement('script');
                script.src = url;
                script.async = true;

                const timeout = setTimeout(() => {
                    reject(new Error('Engine script load timed out after 30 seconds'));
                }, 30000);

                script.onload = () => {
                    clearTimeout(timeout);
                    State.engineScriptLoaded = true;
                    resolve();
                };

                script.onerror = () => {
                    clearTimeout(timeout);
                    reject(new Error(`Failed to load engine script from: ${url}`));
                };

                document.head.appendChild(script);
            });
        };

        /**
         * Launch the Godot game from the discovered files.
         *
         * Technical approach:
         * 1. Load the engine .js file (provides the Engine class)
         * 2. Detect the correct executable name from the found files
         * 3. Initialize the Godot Engine with the directory path
         * 4. Start the game with progress tracking
         */
        const launchGame = async () => {
            try {
                const found = State.foundFiles;
                const path = normalizePath(State.currentPath);

                if (!found['.js'] || !found['.wasm'] || !found['.pck']) {
                    throw new Error('Required files not found. Please check the directory path.');
                }

                setLoading('Loading engine...', `From: ${path}`);

                // Determine the executable base name
                // Use the .wasm file's basename as the executable name
                const executableName = found['.wasm'].basename;

                // Step 1: Load the engine script
                setLoading('Loading engine script...', found['.js'].filename);
                await loadEngineScript(found['.js'].url);

                // Step 2: Verify the Engine class is available
                if (typeof Engine === 'undefined') {
                    throw new Error(
                        'The loaded script does not define the Engine class.\n' +
                        'Make sure the .js file is from a valid Godot HTML5 export.'
                    );
                }

                setLoading('Initializing engine...', 'Compiling WebAssembly module');

                // Step 3: Create and configure the engine instance
                const canvas = $('gameCanvas');
                const engineConfig = {
                    executable: executableName,
                    mainPack: executableName + '.pck',
                    canvas: canvas,
                    canvasResizePolicy: 2,  // Fill browser window
                    args: [],
                };

                State.engine = new Engine(engineConfig);

                // Set up progress callback for both Godot 3.x and 4.x
                let lastProgress = 0;
                if (State.engine.setProgressFunc) {
                    State.engine.setProgressFunc((current, total) => {
                        const pct = total > 0 ? Math.round((current / total) * 100) : lastProgress;
                        lastProgress = pct;
                        const detail = total > 0
                            ? `${formatSize(current)} / ${formatSize(total)} (${pct}%)`
                            : 'Loading...';
                        setLoading('Loading game assets...', 'Downloading game data', detail);

                        const bar = $('loadingBar');
                        bar.classList.remove('indeterminate');
                        bar.style.width = pct + '%';
                    });
                }

                // Show game container
                $('gameContainer').classList.add('active');
                $('gameTitle').textContent = executableName;

                setLoading('Starting game...', 'Launching Godot engine');

                // Step 4: Start the game
                // Godot 4.x: startGame(overrideConfig)
                // Godot 3.x: startGame(execName, mainPack)
                let startPromise;
                try {
                    startPromise = State.engine.startGame(engineConfig);
                } catch (e) {
                    startPromise = State.engine.startGame(executableName, executableName + '.pck');
                }

                await startPromise;

                State.isGameRunning = true;
                console.log('[Godot Launcher] Game started successfully from:', path);

            } catch (err) {
                console.error('[Godot Launcher] Launch error:', err);

                $('gameContainer').classList.remove('active');

                showError(
                    'Failed to launch the game',
                    err.message || 'Unknown error. Check the browser console for details.<br><br>' +
                    'Common causes:<br>' +
                    '&#8226; Files were not found at the specified path<br>' +
                    '&#8226; The server returned 404 for some files<br>' +
                    '&#8226; CORS policy blocked the request<br>' +
                    '&#8226; The .js file is not a valid Godot engine loader'
                );
            }
        };

        /**
         * Check files at the current path
         */
        const checkFiles = async () => {
            const path = $('pathInput').value.trim() || CONFIG.defaultPath;
            State.currentPath = path;
            savePath(path);

            $('checkList').innerHTML = '';
            $('treePreview').style.display = 'none';
            $('launchRow').style.display = 'none';
            $('configStatus').innerHTML = '<span class="status-badge warning">&#9203; Checking...</span>';

            // Add checking indicators
            CONFIG.requiredExtensions.forEach(ext => {
                const item = document.createElement('div');
                item.className = 'check-item checking';
                item.innerHTML = `
                    <div class="check-icon">&#128260;</div>
                    <div class="check-name">Scanning for *${ext}...</div>
                    <div class="check-status">checking</div>
                `;
                item.dataset.ext = ext;
                $('checkList').appendChild(item);
            });

            const found = await discoverFiles(path);
            State.foundFiles = found;

            updateCheckList(found);
            updateTreePreview(found, path);
        };

        /**
         * Scan directory for any Godot-related files
         */
        const scanDirectory = async () => {
            const path = $('pathInput').value.trim() || CONFIG.defaultPath;
            State.currentPath = path;

            $('configStatus').innerHTML = '<span class="status-badge warning">&#9203; Scanning directory...</span>';

            const discovered = await scanDirectory(path);
            State.discoveredFiles = discovered;

            // Show scan results
            const tree = $('treePreview');
            if (discovered.length === 0) {
                tree.innerHTML = '<div class="tree-line" style="color:var(--error);">&#9888; No .wasm, .pck, or .js files found in this directory</div>';
            } else {
                let html = `<div class="tree-line dir">&#128193; ${normalizePath(path)} <span style="color:var(--text-muted);">(${discovered.length} files found)</span></div>`;

                // Group by type
                const byType = {};
                discovered.forEach(f => {
                    if (!byType[f.ext]) byType[f.ext] = [];
                    byType[f.ext].push(f);
                });

                ['.wasm', '.pck', '.js', '.html', '.png'].forEach(ext => {
                    if (byType[ext]) {
                        byType[ext].forEach(f => {
                            html += `<div class="tree-line file" style="padding-left:20px;">`;
                            html += `&#128196; ${f.name} <span style="color:var(--text-muted);">(${formatSize(f.size)})</span>`;
                            html += '</div>';
                        });
                    }
                });

                tree.innerHTML = html;

                // If we found files, try to auto-match
                const wasmFile = discovered.find(f => f.ext === '.wasm');
                const pckFile = discovered.find(f => f.ext === '.pck');
                const jsFile = discovered.find(f => f.ext === '.js');

                if (wasmFile && pckFile && jsFile) {
                    // Check if they share the same basename
                    const wasmBase = wasmFile.name.replace('.wasm', '');
                    const pckBase = pckFile.name.replace('.pck', '');
                    const jsBase = jsFile.name.replace('.js', '');

                    if (wasmBase === pckBase && wasmBase === jsBase) {
                        // Perfect match - all files share the same basename
                        State.foundFiles = {
                            '.wasm': { filename: wasmFile.name, url: wasmFile.path, size: wasmFile.size, basename: wasmBase },
                            '.pck': { filename: pckFile.name, url: pckFile.path, size: pckFile.size, basename: pckBase },
                            '.js': { filename: jsFile.name, url: jsFile.path, size: jsFile.size, basename: jsBase },
                        };
                        updateCheckList(State.foundFiles);
                    }
                }
            }
            tree.style.display = 'block';

            $('configStatus').innerHTML = discovered.length > 0
                ? `<span class="status-badge success">&#128270; ${discovered.length} files discovered</span>`
                : `<span class="status-badge error">&#128165; No files found</span>`;
        };

        // ===== Game Controls =====

        const toggleFullscreen = async () => {
            const container = $('gameContainer');
            try {
                if (!document.fullscreenElement) {
                    await container.requestFullscreen();
                } else {
                    await document.exitFullscreen();
                }
            } catch (err) {
                container.style.position = 'fixed';
                container.style.inset = '0';
                container.style.zIndex = '9999';
            }
        };

        const quitGame = () => {
            if (State.engine && typeof State.engine.requestQuit === 'function') {
                try { State.engine.requestQuit(); } catch(e) {}
            }
            State.engine = null;
            State.isGameRunning = false;
            State.engineScriptLoaded = false;

            if (document.fullscreenElement) {
                document.exitFullscreen().catch(() => {});
            }

            $('gameContainer').classList.remove('active');
            showScreen('screenConfig');
        };

        // ===== Event Listeners =====

        // Preset buttons
        document.querySelectorAll('.preset-btn').forEach(btn => {
            btn.addEventListener('click', () => {
                $('pathInput').value = btn.dataset.path;
                // Auto-check when preset is clicked
                checkFiles();
            });
        });

        $('btnCheck').addEventListener('click', checkFiles);
        $('btnScan').addEventListener('click', scanDirectory);
        $('btnLaunch').addEventListener('click', launchGame);
        $('btnRetry').addEventListener('click', launchGame);

        $('btnBack').addEventListener('click', () => {
            showScreen('screenConfig');
        });

        $('btnEditPath').addEventListener('click', () => {
            showScreen('screenConfig');
        });

        $('btnFullscreen').addEventListener('click', toggleFullscreen);
        $('btnQuit').addEventListener('click', quitGame);

        // Keyboard shortcuts
        document.addEventListener('keydown', (e) => {
            if (e.key === 'F11') {
                e.preventDefault();
                if (State.isGameRunning) toggleFullscreen();
            }
            if (e.key === 'Escape' && State.isGameRunning) {
                const controls = $('gameControls');
                controls.classList.add('visible');
                setTimeout(() => controls.classList.remove('visible'), 2000);
            }
            if ((e.key === 'h' || e.key === 'H') && State.isGameRunning) {
                $('shortcutsOverlay').classList.toggle('active');
            }
        });

        $('btnShortcuts').addEventListener('click', () => {
            $('shortcutsOverlay').classList.add('active');
        });

        $('btnCloseShortcuts').addEventListener('click', () => {
            $('shortcutsOverlay').classList.remove('active');
        });

        $('shortcutsOverlay').addEventListener('click', (e) => {
            if (e.target === $('shortcutsOverlay')) {
                $('shortcutsOverlay').classList.remove('active');
            }
        });

        document.addEventListener('fullscreenchange', () => {
            const btn = $('btnFullscreen');
            btn.innerHTML = document.fullscreenElement ? '&#9974; Exit Fullscreen' : '&#9974; Fullscreen';
        });

        window.addEventListener('beforeunload', (e) => {
            if (State.isGameRunning) {
                e.preventDefault();
                e.returnValue = 'A game is currently running. Are you sure you want to leave?';
            }
        });

        // ===== Auto-initialize =====

        /**
         * On page load:
         * 1. Load saved path (or use default)
         * 2. Auto-check files at that path
         * 3. If all files found, show launch button
         */
        const init = async () => {
            const path = loadSavedPath();
            $('pathInput').value = path;
            State.currentPath = path;

            // Small delay to let the UI render
            await new Promise(r => setTimeout(r, 100));

            // Auto-check files
            await checkFiles();

            // If all files found, we're ready to launch
            const allFound = Object.keys(State.foundFiles).length === 3;
            if (allFound) {
                console.log('[Godot Launcher] All game files found at:', path);
                console.log('[Godot Launcher] Click "Launch Game" to start');
            } else {
                console.log('[Godot Launcher] Some files not found at:', path);
                console.log('[Godot Launcher] Use Scan Directory or adjust the path');
            }
        };

        // Detect if running from file:// protocol
        if (window.location.protocol === 'file:') {
            $('configStatus').innerHTML = '<span class="status-badge error">&#9888; file:// protocol detected</span>';
            $('checkList').innerHTML = `
                <div class="error-box">
                    <div class="error-title">Server Required</div>
                    <div class="error-text">
                        The placeholder variant cannot run from <code>file://</code> due to browser security restrictions.
                        Please serve this file from a web server such as:<br><br>
                        &#8226; <strong>Python:</strong> <code>python -m http.server 8000</code><br>
                        &#8226; <strong>Node.js:</strong> <code>npx serve</code><br>
                        &#8226; <strong>VS Code:</strong> Use the Live Server extension<br>
                        &#8226; <strong>GitHub Pages:</strong> Push to a GitHub repository
                    </div>
                </div>
            `;
        } else {
            // Running from a server - auto-init
            init();
        }

        // ===== Console Welcome =====
        console.log('%c Godot Game Launcher ', 'background:#478cbf;color:#fff;padding:4px 12px;border-radius:4px;font-weight:bold;');
        console.log('%c Directory Variant %c Standalone HTML5 Godot engine loader ', 'color:#478cbf;font-weight:bold;', 'color:#888;');
        console.log('Configure the directory path to load your Godot HTML5 export files.');""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
