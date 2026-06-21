module ConvertedFiles.Wasm.Godot.N1.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            meta [ attr "http-equiv" "X-UA-Compatible"; attr "content" "IE=edge" ]
            title [] [
                str "Godot Game Launcher - Upload Variant"
            ]
            style [] [
                    rawText ("""/* ============================================
           GODOT GAME LAUNCHER - UPLOAD VARIANT
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

        /* ---- Floating Orbs (ambient effect) ---- */
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

        /* Godot-inspired logo icon (CSS-only) */
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

        /* ---- State Screens ---- */
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
            from { opacity: 0; transform: translateY(30px); }
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

        @keyframes shimmer {
            0% { background-position: -200% center; }
            100% { background-position: 200% center; }
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

        /* ---- Upload Zone ---- */
        .upload-zone {
            width: 100%;
            min-height: 280px;
            border: 2px dashed var(--border-default);
            border-radius: var(--radius-lg);
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            gap: 16px;
            padding: 40px 32px;
            cursor: pointer;
            transition: all var(--transition-normal);
            position: relative;
            overflow: hidden;
        }

        .upload-zone::before {
            content: "";
            position: absolute;
            inset: 0;
            background: linear-gradient(135deg, rgba(71,140,191,0.05), transparent);
            opacity: 0;
            transition: opacity var(--transition-normal);
        }

        .upload-zone:hover,
        .upload-zone.dragover {
            border-color: var(--godot-blue);
            background: rgba(71,140,191,0.05);
            transform: scale(1.01);
        }
        .upload-zone:hover::before,
        .upload-zone.dragover::before {
            opacity: 1;
        }

        .upload-zone.dragover {
            border-style: solid;
            box-shadow: 0 0 20px rgba(71,140,191,0.2);
        }

        .upload-icon {
            font-size: 48px;
            opacity: 0.6;
            transition: transform var(--transition-normal);
        }
        .upload-zone:hover .upload-icon {
            transform: translateY(-4px);
        }

        .upload-title {
            font-size: 18px;
            font-weight: 600;
            color: var(--text-primary);
        }

        .upload-subtitle {
            font-size: 13px;
            color: var(--text-secondary);
            text-align: center;
            line-height: 1.6;
        }

        .upload-hint {
            font-size: 11px;
            color: var(--text-muted);
            margin-top: 4px;
        }

        /* ---- File Input (hidden) ---- */
        #fileInput {
            display: none;
        }

        /* ---- File List ---- */
        .file-list {
            width: 100%;
            display: flex;
            flex-direction: column;
            gap: 8px;
            margin-top: 16px;
        }

        .file-item {
            display: flex;
            align-items: center;
            gap: 12px;
            padding: 12px 16px;
            background: var(--bg-elevated);
            border: 1px solid var(--border-subtle);
            border-radius: var(--radius-md);
            transition: all var(--transition-fast);
            animation: slideUp 0.3s ease;
        }
        .file-item:hover {
            border-color: var(--border-default);
            background: var(--bg-hover);
        }
        .file-item.valid {
            border-left: 3px solid var(--success);
        }
        .file-item.invalid {
            border-left: 3px solid var(--error);
        }
        .file-item.missing {
            border-left: 3px solid var(--warning);
            opacity: 0.7;
        }

        .file-icon {
            font-size: 24px;
            flex-shrink: 0;
        }

        .file-info {
            flex: 1;
            min-width: 0;
        }

        .file-name {
            font-size: 14px;
            font-weight: 500;
            color: var(--text-primary);
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .file-meta {
            font-size: 11px;
            color: var(--text-muted);
            font-family: "SF Mono", Monaco, monospace;
        }

        .file-status {
            font-size: 18px;
            flex-shrink: 0;
        }

        .file-remove {
            background: none;
            border: none;
            color: var(--text-muted);
            cursor: pointer;
            font-size: 16px;
            padding: 4px;
            border-radius: 4px;
            transition: all var(--transition-fast);
        }
        .file-remove:hover {
            color: var(--error);
            background: rgba(231,76,60,0.1);
        }

        /* ---- Action Buttons ---- */
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

        .btn::after {
            content: "";
            position: absolute;
            inset: 0;
            background: linear-gradient(90deg, transparent, rgba(255,255,255,0.1), transparent);
            background-size: 200% 100%;
            opacity: 0;
            transition: opacity var(--transition-fast);
        }
        .btn:hover::after {
            opacity: 1;
            animation: shimmer 1.5s infinite;
        }

        .btn-primary {
            background: linear-gradient(135deg, var(--godot-blue), var(--godot-blue-dark));
            color: white;
            box-shadow: 0 4px 16px rgba(71,140,191,0.3);
        }
        .btn-primary:hover {
            transform: translateY(-2px);
            box-shadow: 0 6px 20px rgba(71,140,191,0.4);
        }
        .btn-primary:active {
            transform: translateY(0);
        }
        .btn-primary:disabled {
            opacity: 0.5;
            cursor: not-allowed;
            transform: none;
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

        .btn-danger {
            background: rgba(231,76,60,0.15);
            color: var(--error);
            border: 1px solid rgba(231,76,60,0.3);
        }
        .btn-danger:hover {
            background: rgba(231,76,60,0.25);
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
            font-family: "SF Mono", Monaco, monospace;
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
        .progress-bar-fill::after {
            content: "";
            position: absolute;
            right: 0;
            top: 0;
            bottom: 0;
            width: 20px;
            background: linear-gradient(90deg, transparent, rgba(255,255,255,0.3));
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

        /* ---- Game Canvas Container ---- */
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
            top: 0;
            left: 0;
            right: 0;
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

        /* ---- Error Message ---- */
        .error-box {
            background: rgba(231,76,60,0.1);
            border: 1px solid rgba(231,76,60,0.3);
            border-radius: var(--radius-md);
            padding: 16px;
            margin-top: 16px;
            width: 100%;
        }
        .error-title {
            font-size: 14px;
            font-weight: 600;
            color: var(--error);
            margin-bottom: 4px;
        }
        .error-text {
            font-size: 12px;
            color: var(--text-secondary);
            line-height: 1.5;
        }

        /* ---- Info Box ---- */
        .info-box {
            background: rgba(71,140,191,0.08);
            border: 1px solid rgba(71,140,191,0.2);
            border-radius: var(--radius-md);
            padding: 16px;
            margin-top: 20px;
            width: 100%;
        }
        .info-title {
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
            padding: 2px 6px;
            border-radius: 3px;
            font-family: "SF Mono", Monaco, monospace;
            font-size: 11px;
            color: var(--text-primary);
        }

        /* ---- Keyboard Shortcut Overlay ---- */
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
            font-family: "SF Mono", Monaco, monospace;
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
            .glass-panel {
                padding: 20px;
            }
            .upload-zone {
                min-height: 200px;
                padding: 24px 16px;
            }
            .app-header {
                padding: 12px 16px;
            }
        }

        /* ---- Scrollbar styling ---- */
        ::-webkit-scrollbar {
            width: 8px;
        }
        ::-webkit-scrollbar-track {
            background: var(--bg-secondary);
        }
        ::-webkit-scrollbar-thumb {
            background: var(--border-default);
            border-radius: 4px;
        }
        ::-webkit-scrollbar-thumb:hover {
            background: var(--text-muted);
        }""")
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
                    str "Upload Variant"
                ]
            ]
            rawText ("""<!--  Main App Container  -->""")
            div [ _id "app" ] [
                rawText ("""<!--  ===== SCREEN: Upload =====  -->""")
                div [ _class "screen active"; _id "screenUpload" ] [
                    div [ _class "glass-panel" ] [
                        h2 [ attr "style" "text-align:center; margin-bottom:8px; font-size:22px;" ] [
                            str "Load Your Godot Game"
                        ]
                        p [ attr "style" "text-align:center; color:var(--text-secondary); font-size:14px; margin-bottom:24px;" ] [
                            str "Upload the files from your HTML5 export to launch"
                        ]
                        rawText ("""<!--  Upload Zone  -->""")
                        div [ _class "upload-zone"; _id "uploadZone" ] [
                            div [ _class "upload-icon" ] [
                                str "📂"
                            ]
                            div [ _class "upload-title" ] [
                                str "Drop files here or click to browse"
                            ]
                            div [ _class "upload-subtitle" ] [
                                str "Select your exported"
                                code [] [
                                    str ".wasm"
                                ]
                                str "(engine),"
                                code [] [
                                    str ".pck"
                                ]
                                str "(game data),"
                                br []
                                str "and"
                                code [] [
                                    str ".js"
                                ]
                                str "(loader) files from your Godot HTML5 export"
                            ]
                            div [ _class "upload-hint" ] [
                                str "You can also select multiple files at once"
                            ]
                        ]
                        input [ _type "file"; _id "fileInput"; attr "multiple" ""; attr "accept" ".wasm,.pck,.js,.zip" ]
                        rawText ("""<!--  File List  -->""")
                        div [ _class "file-list"; _id "fileList" ] []
                        rawText ("""<!--  Error Display  -->""")
                        div [ _id "errorDisplay" ] []
                        rawText ("""<!--  Action Buttons  -->""")
                        div [ _class "btn-row"; _id "actionButtons"; attr "style" "display:none;" ] [
                            button [ _class "btn btn-primary"; _id "btnLaunch"; attr "disabled" "" ] [
                                str "► Launch Game"
                            ]
                            button [ _class "btn btn-secondary btn-sm"; _id "btnClear" ] [
                                str "Clear All"
                            ]
                        ]
                        rawText ("""<!--  Info Box  -->""")
                        div [ _class "info-box" ] [
                            div [ _class "info-title" ] [
                                str "Where to find these files"
                            ]
                            ul [ _class "info-list" ] [
                                li [] [
                                    str "Export your project from Godot via"
                                    code [] [
                                        str "Project → Export → Web"
                                    ]
                                ]
                                li [] [
                                    str "The export creates an"
                                    code [] [
                                        str "index.html"
                                    ]
                                    str "file and supporting files"
                                ]
                                li [] [
                                    str "Look for files with"
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
                                    str "extensions"
                                ]
                                li [] [
                                    str "Files may be named like"
                                    code [] [
                                        str "game.wasm"
                                    ]
                                    str "or"
                                    code [] [
                                        str "index.wasm"
                                    ]
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
                            str "Initializing Engine..."
                        ]
                        div [ _class "progress-subtitle"; _id "loadingSubtitle" ] [
                            str "Loading game files into memory"
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
                            str "⚠"
                        ]
                        h2 [ attr "style" "margin-bottom:8px;" ] [
                            str "Something Went Wrong"
                        ]
                        p [ attr "style" "color:var(--text-secondary); font-size:14px; margin-bottom:20px;"; _id "errorMessage" ] [
                            str "An error occurred while loading the game."
                        ]
                        div [ _class "error-box"; _id "errorDetail"; attr "style" "display:none; text-align:left;" ] []
                        div [ _class "btn-row" ] [
                            button [ _class "btn btn-primary"; _id "btnRetry" ] [
                                str "Try Again"
                            ]
                            button [ _class "btn btn-secondary"; _id "btnBack" ] [
                                str "Back to Upload"
                            ]
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  ===== GAME CONTAINER =====  -->""")
            div [ _id "gameContainer" ] [
                canvas [ _id "gameCanvas"; attr "tabindex" "-1" ] []
                rawText ("""<!--  Game Controls Overlay  -->""")
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
                        button [ _class "game-btn btn-danger"; _id "btnQuit"; attr "title" "Quit Game (Escape)" ] [
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
           GODOT GAME LAUNCHER - UPLOAD VARIANT
           Core JavaScript - ES6+ with async/await
           ============================================ */

        // ===== State Management =====
        const State = {
            files: { wasm: null, pck: null, js: null },
            engine: null,
            engineScriptLoaded: false,
            isGameRunning: false,
            originalFetch: window.fetch.bind(window),
        };

        // ===== DOM References =====
        const $ = (id) => document.getElementById(id);
        const screens = {
            upload: $('screenUpload'),
            loading: $('screenLoading'),
            error: $('screenError'),
        };

        // ===== Utility Functions =====
        /**
         * Format file size in human-readable form
         */
        const formatSize = (bytes) => {
            if (bytes === 0) return '0 B';
            const units = ['B', 'KB', 'MB', 'GB'];
            const i = Math.floor(Math.log2(bytes) / 10);
            return (bytes / (1 << (i * 10))).toFixed(i > 0 ? 1 : 0) + ' ' + units[i];
        };

        /**
         * Switch between app screens with animation
         */
        const showScreen = (name) => {
            Object.values(screens).forEach(s => s.classList.remove('active'));
            screens[name].classList.add('active');
        };

        /**
         * Show an error message
         */
        const showError = (message, detail = '') => {
            $('errorMessage').textContent = message;
            const detailEl = $('errorDetail');
            if (detail) {
                detailEl.style.display = 'block';
                detailEl.innerHTML = `<div class="error-title">Details</div><div class="error-text">${detail}</div>`;
            } else {
                detailEl.style.display = 'none';
            }
            showScreen('error');
        };

        /**
         * Update loading screen progress
         */
        const setLoading = (title, subtitle, detail = '') => {
            $('loadingTitle').textContent = title;
            $('loadingSubtitle').textContent = subtitle;
            $('loadingDetail').textContent = detail;
            showScreen('loading');
        };

        // ===== File Upload Handling =====

        const uploadZone = $('uploadZone');
        const fileInput = $('fileInput');
        const fileList = $('fileList');
        const actionButtons = $('actionButtons');
        const btnLaunch = $('btnLaunch');
        const btnClear = $('btnClear');

        /**
         * Open file picker when upload zone is clicked
         */
        uploadZone.addEventListener('click', () => fileInput.click());

        /**
         * Handle drag-and-drop events
         */
        ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
            uploadZone.addEventListener(eventName, (e) => {
                e.preventDefault();
                e.stopPropagation();
            });
        });

        ['dragenter', 'dragover'].forEach(eventName => {
            uploadZone.addEventListener(eventName, () => {
                uploadZone.classList.add('dragover');
            });
        });

        ['dragleave', 'drop'].forEach(eventName => {
            uploadZone.addEventListener(eventName, () => {
                uploadZone.classList.remove('dragover');
            });
        });

        uploadZone.addEventListener('drop', (e) => {
            const files = Array.from(e.dataTransfer.files);
            handleFiles(files);
        });

        fileInput.addEventListener('change', (e) => {
            const files = Array.from(e.target.files);
            handleFiles(files);
        });

        /**
         * Process uploaded files - extract from zip or use directly
         */
        const handleFiles = async (files) => {
            // Check if any ZIP files were uploaded
            const zipFiles = files.filter(f => f.name.toLowerCase().endsWith('.zip'));
            const regularFiles = files.filter(f => !f.name.toLowerCase().endsWith('.zip'));

            // Process ZIP files
            for (const zipFile of zipFiles) {
                try {
                    await extractZip(zipFile);
                } catch (err) {
                    console.error('ZIP extraction failed:', err);
                    showError('Failed to extract ZIP file', err.message);
                    return;
                }
            }

            // Process regular files
            regularFiles.forEach(processFile);

            updateFileList();
            validateFiles();
        };

        /**
         * Extract files from a ZIP archive
         * Uses the DecompressionStream API for deflate decompression
         */
        const extractZip = async (zipFile) => {
            const arrayBuffer = await zipFile.arrayBuffer();
            const dataView = new DataView(arrayBuffer);
            const bytes = new Uint8Array(arrayBuffer);

            // ZIP file structure parser
            // Find Central Directory offset by reading EOCD record
            const eocdOffset = findEOCD(bytes, dataView);
            if (eocdOffset === -1) {
                throw new Error('Invalid ZIP file: End of Central Directory not found');
            }

            const cdOffset = dataView.getUint32(eocdOffset + 16, true);
            const cdSize = dataView.getUint32(eocdOffset + 12, true);
            const numEntries = dataView.getUint16(eocdOffset + 10, true);

            // Parse Central Directory entries
            let offset = cdOffset;
            for (let i = 0; i < numEntries && offset < cdOffset + cdSize; i++) {
                const signature = dataView.getUint32(offset, true);
                if (signature !== 0x02014b50) break; // Central directory file header signature

                const compression = dataView.getUint16(offset + 10, true);
                const uncompSize = dataView.getUint32(offset + 24, true);
                const nameLen = dataView.getUint16(offset + 28, true);
                const extraLen = dataView.getUint16(offset + 30, true);
                const commentLen = dataView.getUint16(offset + 32, true);
                const localHeaderOffset = dataView.getUint32(offset + 42, true);

                const nameBytes = bytes.slice(offset + 46, offset + 46 + nameLen);
                const fileName = new TextDecoder().decode(nameBytes);

                // Parse local file header to get data offset
                const localNameLen = dataView.getUint16(localHeaderOffset + 26, true);
                const localExtraLen = dataView.getUint16(localHeaderOffset + 27, true);
                const dataOffset = localHeaderOffset + 30 + localNameLen + localExtraLen;
                const compSize = dataView.getUint32(offset + 20, true);

                // Read compressed data
                const compressedData = bytes.slice(dataOffset, dataOffset + compSize);

                let fileData;
                if (compression === 0) {
                    // Stored (no compression)
                    fileData = new Blob([compressedData]);
                } else if (compression === 8) {
                    // Deflate - use DecompressionStream
                    const ds = new DecompressionStream('deflate-raw');
                    const writer = ds.writable.getWriter();
                    writer.write(compressedData);
                    writer.close();
                    const decompressed = await new Response(ds.readable).arrayBuffer();
                    fileData = new Blob([decompressed]);
                } else {
                    console.warn(`Unsupported compression method ${compression} for ${fileName}`);
                    offset += 46 + nameLen + extraLen + commentLen;
                    continue;
                }

                // Create a File object
                const extractedFile = new File([fileData], fileName.split('/').pop(), {
                    type: getMimeType(fileName)
                });

                processFile(extractedFile);

                offset += 46 + nameLen + extraLen + commentLen;
            }
        };

        /**
         * Find End of Central Directory record in ZIP data
         */
        const findEOCD = (bytes, dataView) => {
            // EOCD is usually at the end, search backwards
            for (let i = bytes.length - 22; i >= Math.max(0, bytes.length - 65557); i--) {
                if (dataView.getUint32(i, true) === 0x06054b50) {
                    return i;
                }
            }
            return -1;
        };

        /**
         * Get MIME type based on file extension
         */
        const getMimeType = (filename) => {
            const ext = filename.split('.').pop().toLowerCase();
            const types = {
                wasm: 'application/wasm',
                pck: 'application/octet-stream',
                js: 'application/javascript',
                zip: 'application/zip',
            };
            return types[ext] || 'application/octet-stream';
        };

        /**
         * Process a single file and assign to the correct slot
         */
        const processFile = (file) => {
            const ext = file.name.split('.').pop().toLowerCase();
            if (ext === 'wasm') State.files.wasm = file;
            else if (ext === 'pck') State.files.pck = file;
            else if (ext === 'js') State.files.js = file;
        };

        /**
         * Get icon for file type
         */
        const getFileIcon = (ext) => {
            const icons = { wasm: '&#9889;', pck: '&#127918;', js: '&#128221;' };
            return icons[ext] || '&#128196;';
        };

        /**
         * Update the file list UI
         */
        const updateFileList = () => {
            fileList.innerHTML = '';
            const fileTypes = [
                { key: 'wasm', label: 'Engine (WASM)' },
                { key: 'pck', label: 'Game Data (PCK)' },
                { key: 'js', label: 'Engine Loader (JS)' },
            ];

            let hasAll = true;

            fileTypes.forEach(({ key, label }) => {
                const file = State.files[key];
                const item = document.createElement('div');
                item.className = 'file-item ' + (file ? 'valid' : 'missing');

                const icon = getFileIcon(key);
                const name = file ? file.name : `${label} file`;
                const meta = file ? formatSize(file.size) : 'Not uploaded';
                const status = file ? '&#10003;' : '&#9675;';

                item.innerHTML = `
                    <div class="file-icon">${icon}</div>
                    <div class="file-info">
                        <div class="file-name">${name}</div>
                        <div class="file-meta">${meta} &middot; ${label}</div>
                    </div>
                    <div class="file-status">${status}</div>
                    ${file ? `<button class="file-remove" data-type="${key}" title="Remove">&times;</button>` : ''}
                `;

                fileList.appendChild(item);

                if (!file) hasAll = false;

                // Add remove handler
                const removeBtn = item.querySelector('.file-remove');
                if (removeBtn) {
                    removeBtn.addEventListener('click', (e) => {
                        e.stopPropagation();
                        State.files[key] = null;
                        updateFileList();
                        validateFiles();
                    });
                }
            });
        };

        /**
         * Validate files and enable/disable launch button
         */
        const validateFiles = () => {
            const hasAll = State.files.wasm && State.files.pck && State.files.js;
            btnLaunch.disabled = !hasAll;
            actionButtons.style.display = 'flex';

            // Auto-focus launch button when all files present
            if (hasAll) {
                btnLaunch.focus();
            }
        };

        // Clear all files
        btnClear.addEventListener('click', () => {
            State.files = { wasm: null, pck: null, js: null };
            fileInput.value = '';
            updateFileList();
            validateFiles();
            actionButtons.style.display = 'none';
        });

        // ===== Godot Engine Integration =====

        /**
         * Launch the Godot game using the uploaded files.
         * This is the core engine integration function.
         *
         * Technical approach:
         * 1. Read the engine .js file and inject it as a script tag
         * 2. Create Blob URLs for .wasm and .pck files
         * 3. Override window.fetch to intercept requests and serve blob URLs
         * 4. Initialize the Godot Engine with the proper configuration
         * 5. Start the game with progress tracking
         */
        const launchGame = async () => {
            try {
                setLoading('Reading game files...', 'Preparing engine initialization');

                // Step 1: Read all files as ArrayBuffer
                const [jsContent, wasmBuffer, pckBuffer] = await Promise.all([
                    State.files.js.text(),
                    State.files.wasm.arrayBuffer(),
                    State.files.pck.arrayBuffer(),
                ]);

                setLoading('Loading engine script...', 'Injecting Godot engine JavaScript');

                // Step 2: Create blob URLs for the binary files
                const wasmBlob = new Blob([wasmBuffer], { type: 'application/wasm' });
                const pckBlob = new Blob([pckBuffer], { type: 'application/octet-stream' });
                const wasmBlobUrl = URL.createObjectURL(wasmBlob);
                const pckBlobUrl = URL.createObjectURL(pckBlob);

                // Store for cleanup
                State.blobUrls = [wasmBlobUrl, pckBlobUrl];

                // Step 3: Override fetch to serve our blob URLs for the engine files
                // The Godot engine will try to fetch {executable}.wasm and {mainPack}
                // We intercept these requests and redirect to our blob URLs
                const executableName = State.files.wasm.name.replace(/\.wasm$/i, '');

                window.fetch = async (url, options) => {
                    const urlStr = url.toString();

                    // Intercept .wasm requests - match by executable name
                    if (urlStr.endsWith('.wasm') || urlStr.includes('.wasm?')) {
                        console.log('[Godot Launcher] Intercepted WASM fetch:', urlStr);
                        return State.originalFetch(wasmBlobUrl, options);
                    }

                    // Intercept .pck requests
                    if (urlStr.endsWith('.pck') || urlStr.includes('.pck?')) {
                        console.log('[Godot Launcher] Intercepted PCK fetch:', urlStr);
                        return State.originalFetch(pckBlobUrl, options);
                    }

                    // Pass through all other requests
                    return State.originalFetch(url, options);
                };

                // Step 4: Load the engine .js file
                // We create a script element and set its content directly
                await loadEngineScript(jsContent);

                setLoading('Initializing engine...', 'Compiling WebAssembly and starting engine');

                // Step 5: Initialize the Godot Engine
                // The Engine class is now available globally (provided by the .js file)
                if (typeof Engine === 'undefined') {
                    throw new Error(
                        'The uploaded .js file does not define the Engine class.\n' +
                        'Make sure you uploaded the correct engine loader file from a Godot HTML5 export.'
                    );
                }

                // Create engine instance with configuration
                // canvasResizePolicy: 0 = Godot won't resize the canvas (we control it)
                // canvasResizePolicy: 1 = resize on start and window resize
                // canvasResizePolicy: 2 = fill the entire browser window
                const canvas = $('gameCanvas');
                const engineConfig = {
                    executable: executableName,
                    mainPack: executableName + '.pck',
                    canvas: canvas,
                    canvasResizePolicy: 2,  // Fill the browser window
                    args: [],
                };

                State.engine = new Engine(engineConfig);

                // Set up progress callback
                let lastProgress = 0;
                // In Godot 4.x, use the config/onProgress approach
                // In Godot 3.x, use setProgressFunc
                if (State.engine.setProgressFunc) {
                    State.engine.setProgressFunc((current, total) => {
                        const pct = total > 0 ? Math.round((current / total) * 100) : lastProgress;
                        lastProgress = pct;
                        const detail = total > 0
                            ? `${formatSize(current)} / ${formatSize(total)} (${pct}%)`
                            : 'Loading...';
                        setLoading('Loading game assets...', 'Downloading game data', detail);

                        // Update progress bar
                        const bar = $('loadingBar');
                        bar.classList.remove('indeterminate');
                        bar.style.width = pct + '%';
                    });
                }

                // Show game container
                $('gameContainer').classList.add('active');
                $('gameTitle').textContent = State.files.pck.name.replace(/\.pck$/i, '');

                setLoading('Starting game...', 'Launching Godot engine', '');

                // Start the game
                // startGame() in Godot 4.x takes an optional override config
                // In Godot 3.x, it takes execName and mainPack as separate args
                let startPromise;
                if (typeof State.engine.startGame === 'function') {
                    // Try Godot 4.x style: startGame(overrideConfig)
                    try {
                        startPromise = State.engine.startGame(engineConfig);
                    } catch (e) {
                        // Fall back to Godot 3.x style: startGame(execName, mainPack)
                        startPromise = State.engine.startGame(executableName, executableName + '.pck');
                    }
                } else {
                    throw new Error('Engine does not have a startGame method');
                }

                await startPromise;

                State.isGameRunning = true;
                console.log('[Godot Launcher] Game started successfully');

            } catch (err) {
                console.error('[Godot Launcher] Launch error:', err);

                // Restore fetch
                window.fetch = State.originalFetch;

                // Clean up blob URLs
                if (State.blobUrls) {
                    State.blobUrls.forEach(url => URL.revokeObjectURL(url));
                }

                // Hide game container
                $('gameContainer').classList.remove('active');

                showError(
                    'Failed to launch the game',
                    err.message || 'Unknown error. Check the browser console for details.'
                );
            }
        };

        /**
         * Load the engine JavaScript by injecting it as a script tag.
         * Since we have the file content as text, we create a Blob URL for the script.
         */
        const loadEngineScript = (jsContent) => {
            return new Promise((resolve, reject) => {
                // Create a blob URL for the script content
                const blob = new Blob([jsContent], { type: 'application/javascript' });
                const url = URL.createObjectURL(blob);

                const script = document.createElement('script');
                script.type = 'text/javascript';

                // Set a timeout in case the script fails to load
                const timeout = setTimeout(() => {
                    reject(new Error('Engine script load timed out after 30 seconds'));
                }, 30000);

                script.onload = () => {
                    clearTimeout(timeout);
                    State.engineScriptLoaded = true;
                    URL.revokeObjectURL(url); // Clean up the blob URL
                    resolve();
                };

                script.onerror = (e) => {
                    clearTimeout(timeout);
                    URL.revokeObjectURL(url);
                    reject(new Error('Failed to load engine script: ' + (e.message || 'Unknown error')));
                };

                script.src = url;
                document.head.appendChild(script);
            });
        };

        // ===== Game Controls =====

        /**
         * Toggle fullscreen mode for the game
         */
        const toggleFullscreen = async () => {
            const container = $('gameContainer');
            try {
                if (!document.fullscreenElement) {
                    await container.requestFullscreen();
                } else {
                    await document.exitFullscreen();
                }
            } catch (err) {
                console.warn('Fullscreen error:', err);
                // Fallback: maximize the canvas
                container.style.position = 'fixed';
                container.style.inset = '0';
                container.style.zIndex = '9999';
            }
        };

        /**
         * Quit the game and return to upload screen
         */
        const quitGame = () => {
            // Restore original fetch
            window.fetch = State.originalFetch;

            // Clean up blob URLs
            if (State.blobUrls) {
                State.blobUrls.forEach(url => URL.revokeObjectURL(url));
                State.blobUrls = null;
            }

            // Exit fullscreen if active
            if (document.fullscreenElement) {
                document.exitFullscreen().catch(() => {});
            }

            // Hide game container
            $('gameContainer').classList.remove('active');

            // Clear the engine
            if (State.engine) {
                // Request quit if the method exists (Godot 4.x)
                if (typeof State.engine.requestQuit === 'function') {
                    try { State.engine.requestQuit(); } catch(e) {}
                }
                State.engine = null;
            }

            State.isGameRunning = false;
            State.engineScriptLoaded = false;

            // Remove the engine script from DOM
            const scripts = document.querySelectorAll('script[data-engine]');
            scripts.forEach(s => s.remove());

            // Reset to upload screen
            showScreen('upload');

            // Reset loading bar
            const bar = $('loadingBar');
            bar.classList.add('indeterminate');
            bar.style.width = '';
        };

        // ===== Event Listeners =====

        btnLaunch.addEventListener('click', launchGame);

        $('btnRetry').addEventListener('click', launchGame);
        $('btnBack').addEventListener('click', () => {
            showScreen('upload');
        });

        $('btnFullscreen').addEventListener('click', toggleFullscreen);
        $('btnQuit').addEventListener('click', quitGame);

        // Keyboard shortcuts
        document.addEventListener('keydown', (e) => {
            // F11 - Fullscreen
            if (e.key === 'F11') {
                e.preventDefault();
                if (State.isGameRunning) toggleFullscreen();
            }

            // Escape - Quit game (only when game is running)
            if (e.key === 'Escape' && State.isGameRunning) {
                e.preventDefault();
                // Show controls briefly to confirm
                const controls = $('gameControls');
                controls.classList.add('visible');
                setTimeout(() => controls.classList.remove('visible'), 2000);
            }

            // H - Show shortcuts (only when game is running)
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

        // Fullscreen change events
        document.addEventListener('fullscreenchange', () => {
            const btn = $('btnFullscreen');
            if (document.fullscreenElement) {
                btn.innerHTML = '&#9974; Exit Fullscreen';
            } else {
                btn.innerHTML = '&#9974; Fullscreen';
            }
        });

        // Prevent accidental page unload when game is running
        window.addEventListener('beforeunload', (e) => {
            if (State.isGameRunning) {
                e.preventDefault();
                e.returnValue = 'A game is currently running. Are you sure you want to leave?';
            }
        });

        // ===== Console welcome message =====
        console.log('%c Godot Game Launcher ', 'background:#478cbf;color:#fff;padding:4px 12px;border-radius:4px;font-weight:bold;');
        console.log('%c Upload Variant %c Standalone HTML5 Godot engine loader ', 'color:#478cbf;font-weight:bold;', 'color:#888;');
        console.log('Drop .wasm, .pck, and .js files from your Godot HTML5 export to launch.');""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
