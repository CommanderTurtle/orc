module ConvertedFiles.Adspace.Templates.N2.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "CinemaRoll Video -- Epic Adventure Awaits"
            ]
            link [ attr "rel" "preconnect"; _href "https://fonts.googleapis.com" ]
            link [ _href "https://fonts.googleapis.com/css2?family=Press+Start+2P&family=Inter:wght@300;400;500;600;700&display=swap"; attr "rel" "stylesheet" ]
            style [] [
                    rawText ("""/* ==========================================
       RESET & BASE
       ========================================== */
    *, *::before, *::after { margin: 0; padding: 0; box-sizing: border-box; }
    html, body {
      width: 100%; height: 100%;
      overflow: hidden;
      background: #87CEEB;
      font-family: 'Inter', system-ui, -apple-system, sans-serif;
    }

    /* ==========================================
       BACKGROUND CANVAS (Rolling Hills + Aircraft)
       ========================================== */
    #hillsCanvas {
      position: fixed;
      top: 0; left: 0;
      width: 100%; height: 100%;
      z-index: 1;
    }

    /* ==========================================
       CRT / VIGNETTE / SCANLINES OVERLAYS
       ========================================== */
    .vignette {
      position: fixed;
      inset: 0;
      pointer-events: none;
      z-index: 1000;
      box-shadow: inset 0 0 200px 80px rgba(0,0,0,0.65);
    }

    .global-scanlines {
      position: fixed;
      inset: 0;
      z-index: 999;
      pointer-events: none;
      background: repeating-linear-gradient(
        0deg,
        transparent,
        transparent 2px,
        rgba(0,0,0,0.18) 2px,
        rgba(0,0,0,0.18) 4px
      );
      animation: scanlineFlicker 3s ease-in-out infinite;
    }

    @keyframes scanlineFlicker {
      0%, 100% { opacity: 1; }
      50% { opacity: 0.85; }
    }

    /* Noise overlay */
    .noise-overlay {
      position: fixed;
      inset: 0;
      z-index: 998;
      pointer-events: none;
      opacity: 0.035;
      background-image: url("data:image/svg+xml,%3Csvg viewBox='0 0 256 256' xmlns='http://www.w3.org/2000/svg'%3E%3Cfilter id='n'%3E%3CfeTurbulence type='fractalNoise' baseFrequency='0.9' numOctaves='4' stitchTiles='stitch'/%3E%3C/filter%3E%3Crect width='100%25' height='100%25' filter='url(%23n)'/%3E%3C/svg%3E");
      background-size: 256px 256px;
    }

    /* ==========================================
       MAIN LAYOUT
       ========================================== */
    .main-container {
      position: fixed;
      inset: 0;
      z-index: 10;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      padding: 20px;
    }

    /* ==========================================
       VIDEO PLAYER
       ========================================== */
    .video-wrapper {
      position: relative;
      width: 100%;
      max-width: 800px;
      aspect-ratio: 16 / 9;
      flex-shrink: 0;
    }

    /* Stronger drop shadow */
    .video-shadow {
      position: absolute;
      inset: -8px;
      box-shadow:
        0 40px 100px rgba(0,0,0,0.75),
        0 20px 50px rgba(0,0,0,0.55),
        0 8px 20px rgba(0,0,0,0.4),
        0 0 120px rgba(0,0,0,0.25);
      z-index: 0;
      pointer-events: none;
    }

    /* Pixel frame around video */
    .pixel-frame {
      position: absolute;
      inset: -12px;
      border: 4px solid #000;
      background: #fff;
      z-index: 2;
      pointer-events: none;
    }
    .pixel-frame::before,
    .pixel-frame::after {
      content: '';
      position: absolute;
      width: 24px; height: 24px;
      border: 4px solid #000;
      background: #fff;
      z-index: 3;
    }
    .pixel-frame::before { top: -4px; left: -4px; }
    .pixel-frame::after { top: -4px; right: -4px; }

    .pixel-frame-bottom::before,
    .pixel-frame-bottom::after {
      content: '';
      position: absolute;
      width: 24px; height: 24px;
      border: 4px solid #000;
      background: #fff;
      z-index: 3;
      bottom: -4px;
    }
    .pixel-frame-bottom::before { left: -4px; }
    .pixel-frame-bottom::after { right: -4px; }

    /* Inner shadow for depth */
    .pixel-frame-inner {
      position: absolute;
      inset: 0;
      box-shadow: inset 0 0 30px rgba(0,0,0,0.4);
      pointer-events: none;
      z-index: 4;
    }

    video, #fallbackCanvas {
      width: 100%; height: 100%;
      display: block;
      object-fit: cover;
      position: relative;
      z-index: 3;
      background: #1a1a1a;
    }

    /* Scanlines overlay on video */
    .scanlines {
      position: absolute;
      inset: 0;
      z-index: 5;
      pointer-events: none;
      background: repeating-linear-gradient(
        0deg,
        transparent,
        transparent 2px,
        rgba(0,0,0,0.3) 2px,
        rgba(0,0,0,0.3) 4px
      );
      animation: scanlineFlicker 4s ease-in-out infinite;
    }

    /* Loading state overlay */
    .loading-overlay {
      position: absolute;
      inset: 0;
      background: #1a1a1a;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      z-index: 6;
      color: #fff;
      font-family: 'Press Start 2P', monospace;
      font-size: 14px;
      gap: 20px;
      transition: opacity 0.5s;
    }
    .loading-overlay.hidden {
      opacity: 0;
      pointer-events: none;
    }

    .loading-dots::after {
      content: '';
      animation: dots 1.5s steps(4, end) infinite;
    }
    @keyframes dots {
      0% { content: ''; }
      25% { content: '.'; }
      50% { content: '..'; }
      75% { content: '...'; }
      100% { content: ''; }
    }

    /* Pixel spinner */
    .pixel-spinner {
      width: 40px; height: 40px;
      border: 4px solid #333;
      border-top-color: #5865F2;
      animation: spin 0.8s steps(8) infinite;
    }
    @keyframes spin { to { transform: rotate(360deg); } }

    /* Error overlay */
    .error-overlay {
      position: absolute;
      inset: 0;
      background: #1a1a1a;
      display: none;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      z-index: 7;
      color: #ff4444;
      font-family: 'Press Start 2P', monospace;
      font-size: 12px;
      gap: 16px;
      text-align: center;
      padding: 20px;
    }
    .error-overlay.visible { display: flex; }

    /* ==========================================
       PROGRESS BAR
       ========================================== */
    .progress-container {
      width: 100%;
      max-width: 800px;
      margin-top: 28px;
      position: relative;
    }

    .progress-track {
      width: 100%;
      height: 22px;
      background: #111;
      border: 3px solid #000;
      position: relative;
      overflow: hidden;
    }

    .progress-fill {
      height: 100%;
      width: 0%;
      background: #4ade80;
      transition: width 0.1s linear, background-color 0.5s ease;
      position: relative;
      box-shadow: 0 0 25px rgba(74, 222, 128, 0.95), 0 0 55px rgba(74, 222, 128, 0.45), 0 0 80px rgba(74, 222, 128, 0.2);
    }

    /* Shimmer effect on progress bar */
    .progress-fill::after {
      content: '';
      position: absolute;
      top: 0; left: 0; right: 0; bottom: 0;
      background: repeating-linear-gradient(
        90deg,
        transparent,
        transparent 6px,
        rgba(255,255,255,0.15) 6px,
        rgba(255,255,255,0.15) 8px
      );
      animation: shimmer 0.5s linear infinite;
    }

    @keyframes shimmer {
      0% { transform: translateX(0); }
      100% { transform: translateX(14px); }
    }

    .progress-label {
      text-align: center;
      font-family: 'Press Start 2P', monospace;
      font-size: 10px;
      color: #fff;
      margin-top: 10px;
      text-shadow: 0 2px 6px rgba(0,0,0,0.7);
    }

    /* ==========================================
       INFO BAR
       ========================================== */
    .info-bar {
      width: 100%;
      max-width: 800px;
      margin-top: 18px;
      background: #1a1a1a;
      border: 3px solid #000;
      box-shadow: 0 6px 0 rgba(0,0,0,0.5);
      display: flex;
      align-items: center;
      justify-content: space-between;
      padding: 18px 22px;
      gap: 16px;
      flex-wrap: wrap;
      position: relative;
    }

    /* Top accent line */
    .info-bar::before {
      content: '';
      position: absolute;
      top: 0; left: 0; right: 0;
      height: 3px;
      background: #5865F2;
      box-shadow: 0 0 16px rgba(88, 101, 242, 0.7), 0 0 35px rgba(88, 101, 242, 0.35);
    }

    .info-left {
      display: flex;
      align-items: center;
      gap: 18px;
      flex: 1;
      min-width: 0;
    }

    /* Pixel art sword icon */
    .pixel-icon {
      width: 40px; height: 40px;
      flex-shrink: 0;
      position: relative;
      image-rendering: pixelated;
      image-rendering: crisp-edges;
    }

    .info-text {
      min-width: 0;
    }

    .info-title {
      font-family: 'Press Start 2P', monospace;
      font-size: 12px;
      color: #fff;
      line-height: 1.5;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
      text-shadow: 0 2px 4px rgba(0,0,0,0.5);
    }

    .info-subtitle {
      font-family: 'Inter', sans-serif;
      font-size: 13px;
      color: #888;
      margin-top: 5px;
      font-weight: 400;
    }

    .info-right {
      display: flex;
      gap: 12px;
      flex-shrink: 0;
    }

    /* ==========================================
       BUTTONS
       ========================================== */
    .pixel-btn {
      font-family: 'Press Start 2P', monospace;
      font-size: 10px;
      padding: 12px 20px;
      border: 3px solid #000;
      cursor: pointer;
      position: relative;
      transition: transform 0.1s, box-shadow 0.2s;
      outline: none;
      text-decoration: none;
      display: inline-flex;
      align-items: center;
      gap: 8px;
      white-space: nowrap;
    }

    .pixel-btn:hover:not(:disabled) {
      transform: translateY(-2px);
    }

    .pixel-btn:active:not(:disabled) {
      transform: translateY(0);
    }

    .pixel-btn:disabled {
      cursor: not-allowed;
      opacity: 0.7;
    }

    /* Play Now button */
    .btn-play {
      background: #4ade80;
      color: #000;
      box-shadow: 0 4px 0 #16a34a;
    }
    .btn-play:hover {
      box-shadow: 0 6px 0 #16a34a;
    }
    .btn-play:active {
      box-shadow: 0 2px 0 #16a34a;
    }

    /* Claim Reward button */
    .btn-claim {
      background: #333;
      color: #666;
      box-shadow: 0 4px 0 #111;
      transition: all 0.3s ease;
    }
    .btn-claim.unlocked {
      background: #5865F2;
      color: #fff;
      box-shadow: 0 4px 0 #3a45c4;
      animation: pulseGlow 1.5s ease-in-out infinite;
    }
    .btn-claim.unlocked:hover {
      box-shadow: 0 6px 0 #3a45c4, 0 0 30px rgba(88, 101, 242, 0.6);
    }
    .btn-claim.claimed {
      background: #22c55e;
      color: #fff;
      box-shadow: 0 4px 0 #16a34a;
      animation: none;
    }

    @keyframes pulseGlow {
      0%, 100% { box-shadow: 0 4px 0 #3a45c4, 0 0 10px rgba(88, 101, 242, 0.5); }
      50% { box-shadow: 0 4px 0 #3a45c4, 0 0 30px rgba(88, 101, 242, 1); }
    }

    /* Lock icon -- inline SVG, crisp at small sizes */
    .lock-icon {
      width: 14px; height: 14px;
      display: inline-flex;
      align-items: center;
      justify-content: center;
      flex-shrink: 0;
    }
    .lock-icon svg {
      width: 100%; height: 100%;
      display: block;
    }

    /* ==========================================
       COUNTDOWN TIMER (Top Right)
       ========================================== */
    .countdown {
      position: fixed;
      top: 20px; right: 20px;
      z-index: 100;
      background: #000;
      border: 3px solid #fff;
      padding: 12px 18px;
      font-family: 'Press Start 2P', monospace;
      font-size: 14px;
      color: #fff;
      min-width: 100px;
      text-align: center;
      transition: border-color 0.3s, color 0.3s;
      box-shadow: 0 6px 0 rgba(0,0,0,0.4);
    }

    .countdown.warning {
      border-color: #fbbf24;
      color: #fbbf24;
    }

    .countdown.danger {
      border-color: #ef4444;
      color: #ef4444;
      animation: countdownPulse 0.5s ease-in-out infinite;
    }

    .countdown.hidden {
      display: none;
    }

    @keyframes countdownPulse {
      0%, 100% { transform: scale(1); }
      50% { transform: scale(1.05); }
    }

    /* ==========================================
       END SCREEN
       ========================================== */
    .end-screen {
      position: fixed;
      inset: 0;
      z-index: 500;
      background: rgba(0,0,0,0.88);
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      gap: 30px;
      opacity: 0;
      pointer-events: none;
      transition: opacity 1s ease;
    }

    .end-screen.visible {
      opacity: 1;
      pointer-events: all;
    }

    .end-title {
      font-family: 'Press Start 2P', monospace;
      font-size: 24px;
      color: #4ade80;
      text-align: center;
      text-shadow: 0 0 20px rgba(74, 222, 128, 0.6), 0 0 40px rgba(74, 222, 128, 0.3);
      line-height: 1.5;
      animation: titleGlow 2s ease-in-out infinite;
    }

    @keyframes titleGlow {
      0%, 100% { text-shadow: 0 0 20px rgba(74, 222, 128, 0.6), 0 0 40px rgba(74, 222, 128, 0.3); }
      50% { text-shadow: 0 0 30px rgba(74, 222, 128, 0.9), 0 0 60px rgba(74, 222, 128, 0.5); }
    }

    .end-subtitle {
      font-family: 'Inter', sans-serif;
      font-size: 16px;
      color: #aaa;
      text-align: center;
    }

    .btn-continue {
      background: #fff;
      color: #000;
      box-shadow: 0 4px 0 #999;
      font-size: 12px;
      padding: 16px 32px;
    }
    .btn-continue:hover {
      box-shadow: 0 6px 0 #999, 0 0 20px rgba(255,255,255,0.3);
    }

    /* Sparkle particles container */
    .sparkle-container {
      position: absolute;
      pointer-events: none;
      z-index: 200;
    }

    .sparkle {
      position: absolute;
      width: 6px; height: 6px;
      background: #fff;
      animation: sparkleAnim 0.8s ease-out forwards;
    }
    @keyframes sparkleAnim {
      0% { transform: scale(1); opacity: 1; }
      100% { transform: scale(0) translate(var(--tx), var(--ty)); opacity: 0; }
    }

    /* ==========================================
       RESPONSIVE
       ========================================== */
    @media (max-width: 768px) {
      .video-wrapper { max-width: 100%; }
      .info-bar { flex-direction: column; align-items: stretch; }
      .info-right { justify-content: center; }
      .info-title { font-size: 10px; }
      .pixel-btn { font-size: 9px; padding: 10px 16px; }
      .countdown { font-size: 11px; padding: 8px 12px; min-width: 80px; }
      .end-title { font-size: 16px; }
    }

    @media (max-width: 480px) {
      .pixel-frame { inset: -8px; border-width: 3px; }
      .info-title { white-space: normal; font-size: 9px; }
      .pixel-btn { font-size: 8px; padding: 8px 12px; }
    }""")
            ]
        ]
        body [] [
            rawText ("""<!--  ==========================================
       ROLLING HILLS BACKGROUND CANVAS
       ==========================================  -->""")
            canvas [ _id "hillsCanvas" ] []
            rawText ("""<!--  Aircraft overlay canvas (above video)  -->""")
            canvas [ _id "aircraftCanvas"; attr "style" "position:fixed;top:0;left:0;width:100%;height:100%;z-index:11;pointer-events:none;" ] []
            rawText ("""<!--  ==========================================
       GLOBAL OVERLAYS (behind content, above hills)
       ==========================================  -->""")
            div [ _class "noise-overlay" ] []
            div [ _class "global-scanlines" ] []
            div [ _class "vignette" ] []
            rawText ("""<!--  ==========================================
       COUNTDOWN TIMER (Top Right)
       ==========================================  -->""")
            div [ _class "countdown"; _id "countdown" ] [
                str "00:00"
            ]
            rawText ("""<!--  ==========================================
       MAIN CONTENT
       ==========================================  -->""")
            div [ _class "main-container" ] [
                rawText ("""<!--  VIDEO PLAYER  -->""")
                div [ _class "video-wrapper"; _id "videoWrapper" ] [
                    rawText ("""<!--  Drop shadow  -->""")
                    div [ _class "video-shadow" ] []
                    rawText ("""<!--  Pixel frame  -->""")
                    div [ _class "pixel-frame" ] [
                        div [ _class "pixel-frame-bottom" ] []
                    ]
                    div [ _class "pixel-frame-inner" ] []
                    rawText ("""<!--  Video element (will be replaced by fallback canvas if video fails)  -->""")
                    video [ _id "mainVideo"; attr "preload" "auto"; attr "playsinline" ""; attr "muted" "" ] []
                    rawText ("""<!--  Scanlines overlay  -->""")
                    div [ _class "scanlines" ] []
                    rawText ("""<!--  Loading overlay  -->""")
                    div [ _class "loading-overlay"; _id "loadingOverlay" ] [
                        div [ _class "pixel-spinner" ] []
                        div [] [
                            str "Loading"
                            span [ _class "loading-dots" ] []
                        ]
                    ]
                    rawText ("""<!--  Error overlay  -->""")
                    div [ _class "error-overlay"; _id "errorOverlay" ] [
                        div [] [
                            str "Failed to load video"
                        ]
                        button [ _class "pixel-btn btn-play"; attr "onclick" "location.reload()" ] [
                            str "Retry"
                        ]
                    ]
                ]
                rawText ("""<!--  PROGRESS BAR  -->""")
                div [ _class "progress-container" ] [
                    div [ _class "progress-track" ] [
                        div [ _class "progress-fill"; _id "progressFill" ] []
                    ]
                    div [ _class "progress-label"; _id "progressLabel" ] [
                        str "0%"
                    ]
                ]
                rawText ("""<!--  INFO BAR  -->""")
                div [ _class "info-bar" ] [
                    div [ _class "info-left" ] [
                        rawText ("""<!--  Pixel Art Sword Icon Canvas  -->""")
                        canvas [ _class "pixel-icon"; _id "pixelIcon"; attr "width" "40"; attr "height" "40" ] []
                        div [ _class "info-text" ] [
                            div [ _class "info-title" ] [
                                str "Epic Adventure Awaits"
                            ]
                            div [ _class "info-subtitle" ] [
                                str "Studio Name • Available on All Platforms"
                            ]
                        ]
                    ]
                    div [ _class "info-right" ] [
                        button [ _class "pixel-btn btn-claim"; _id "btnClaim"; attr "disabled" "" ] [
                            span [ _class "lock-icon"; _id "lockIcon" ] [
                                tag "svg" [ attr "viewBox" "0 0 14 14"; attr "fill" "none"; attr "xmlns" "http://www.w3.org/2000/svg" ] [
                                    voidTag "rect" [ attr "x" "2"; attr "y" "6"; attr "width" "10"; attr "height" "7"; attr "rx" "1.5"; attr "fill" "currentColor" ]
                                    voidTag "path" [ attr "d" "M3.5 6V4a3.5 3.5 0 0 1 7 0v2"; attr "stroke" "currentColor"; attr "stroke-width" "2"; attr "stroke-linecap" "round"; attr "fill" "none" ]
                                    voidTag "circle" [ attr "cx" "7"; attr "cy" "9.5"; attr "r" "1"; attr "fill" "#333" ]
                                    voidTag "path" [ attr "d" "M7 10.5v1.5"; attr "stroke" "#333"; attr "stroke-width" "1"; attr "stroke-linecap" "round" ]
                                ]
                            ]
                            span [ _id "claimText" ] [
                                str "Claim Reward"
                            ]
                        ]
                        a [ _href "https://example.com"; attr "target" "_blank"; _class "pixel-btn btn-play" ] [
                            str "Play Now"
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  ==========================================
       END SCREEN
       ==========================================  -->""")
            div [ _class "end-screen"; _id "endScreen" ] [
                div [ _class "end-title" ] [
                    str "Thanks for watching!"
                ]
                div [ _class "end-subtitle"; _id "redirectText" ] [
                    str "Redirecting in 8 seconds..."
                ]
                a [ _href "https://example.com"; _class "pixel-btn btn-continue"; _id "btnContinue" ] [
                    str "Continue"
                ]
            ]
            rawText ("""<!--  ==========================================
       SPARKLE CONTAINER
       ==========================================  -->""")
            div [ _class "sparkle-container"; _id "sparkleContainer" ] []
            script [] [
                    rawText ("""/* ================================================================
       CINEMAROLL VIDEO -- COMPLETE JAVASCRIPT
       ================================================================ */

    // ===========================
    // DOM Elements
    // ===========================
    const video = document.getElementById('mainVideo');
    const videoWrapper = document.getElementById('videoWrapper');
    const loadingOverlay = document.getElementById('loadingOverlay');
    const errorOverlay = document.getElementById('errorOverlay');
    const progressFill = document.getElementById('progressFill');
    const progressLabel = document.getElementById('progressLabel');
    const countdown = document.getElementById('countdown');
    const btnClaim = document.getElementById('btnClaim');
    const claimText = document.getElementById('claimText');
    const lockIcon = document.getElementById('lockIcon');
    const endScreen = document.getElementById('endScreen');
    const redirectText = document.getElementById('redirectText');
    const btnContinue = document.getElementById('btnContinue');
    const sparkleContainer = document.getElementById('sparkleContainer');
    const hillsCanvas = document.getElementById('hillsCanvas');
    const pixelIcon = document.getElementById('pixelIcon');

    // ===========================
    // State
    // ===========================
    let videoDuration = 30; // Fallback duration for canvas
    let isVideoEnded = false;
    let isRewardClaimed = false;
    let redirectCountdown = 8;
    let redirectInterval = null;
    let lastTime = 0;
    let sparkles = [];
    let rewardUnlockedTime = 0;
    let useVideo = true;
    let fallbackActive = false;

    // ===========================
    // Pixel Art Sword -- proper blade / crossguard / handle / pommel
    // Canvas 40x40, each native pixel is 1px (sharp pixel art)
    // ===========================
    function drawPixelSword() {
      const sCtx = pixelIcon.getContext('2d');
      sCtx.clearRect(0, 0, 40, 40);
      sCtx.imageSmoothingEnabled = false;

      // Helper: draw a pixel block
      function px(x, y, w, h, color) {
        sCtx.fillStyle = color;
        sCtx.fillRect(x, y, w, h);
      }

      // Centre the sword in the 40x40 canvas (sword ~10px wide, 28px tall)
      const cx = 20; // centre X

      /* ---- BLADE ---- */
      // Main blade body: 3px wide, 14px tall, silver
      px(cx - 1, 2, 3, 14, '#C0C0C0');

      // White highlight strip on left edge of blade (alternating pixels)
      px(cx - 1, 3, 1, 1, '#FFFFFF');
      px(cx - 1, 5, 1, 1, '#FFFFFF');
      px(cx - 1, 7, 1, 1, '#FFFFFF');
      px(cx - 1, 9, 1, 1, '#FFFFFF');
      px(cx - 1, 11, 1, 1, '#FFFFFF');
      px(cx - 1, 13, 1, 1, '#FFFFFF');

      // Subtle darker edge on right side for depth
      px(cx + 1, 4, 1, 1, '#A0A0A0');
      px(cx + 1, 8, 1, 1, '#A0A0A0');
      px(cx + 1, 12, 1, 1, '#A0A0A0');

      // Blade tip (single pixel taper)
      px(cx, 1, 1, 1, '#E0E0E0');

      /* ---- CROSSGUARD ---- */
      // Gold horizontal bar: 12px wide, 3px tall
      px(cx - 5, 16, 12, 3, '#FFD700');
      // Crossguard highlight (brighter gold on top edge)
      px(cx - 5, 16, 12, 1, '#FFED4A');
      // Crossguard shadow (darker gold on bottom)
      px(cx - 5, 18, 12, 1, '#DAA520');
      // Small decorative nubs on ends
      px(cx - 6, 16, 1, 3, '#DAA520');
      px(cx + 6, 16, 1, 3, '#DAA520');

      /* ---- HANDLE ---- */
      // Brown handle: 3px wide, 7px tall
      px(cx - 1, 19, 3, 7, '#8B4513');
      // Handle highlight
      px(cx - 1, 19, 1, 7, '#A0522D');
      // Handle grip lines
      px(cx, 20, 1, 1, '#6B3410');
      px(cx, 22, 1, 1, '#6B3410');
      px(cx, 24, 1, 1, '#6B3410');

      /* ---- POMMEL ---- */
      // Gold pommel at bottom: 6px wide, 2px tall
      px(cx - 2, 26, 6, 2, '#FFD700');
      // Pommel highlight
      px(cx - 2, 26, 6, 1, '#FFED4A');
      // Small bottom tip
      px(cx - 1, 28, 3, 1, '#DAA520');
    }
    drawPixelSword();

    // ===========================
    // VIDEO SYSTEM -- Multi-URL + Canvas Fallback
    // ===========================
    const VIDEO_URLS = [
      'https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4',
      'https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4',
      'https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4'
    ];

    let currentVideoIndex = 0;
    let videoErrorCount = 0;

    function tryNextVideo() {
      if (currentVideoIndex < VIDEO_URLS.length) {
        video.src = VIDEO_URLS[currentVideoIndex];
        video.load();
        currentVideoIndex++;
      } else {
        // All videos failed -- activate canvas fallback
        activateFallbackCanvas();
      }
    }

    function activateFallbackCanvas() {
      useVideo = false;
      fallbackActive = true;
      loadingOverlay.classList.add('hidden');
      errorOverlay.classList.remove('visible');

      // Hide video, show canvas fallback
      video.style.display = 'none';

      const fallbackCanvas = document.createElement('canvas');
      fallbackCanvas.id = 'fallbackCanvas';
      fallbackCanvas.width = 1280;
      fallbackCanvas.height = 720;
      videoWrapper.insertBefore(fallbackCanvas, videoWrapper.querySelector('.scanlines'));

      // Start the fallback animation
      startFallbackCanvas(fallbackCanvas);

      // Start progress tracking (0-100% over 30 seconds)
      startFallbackProgress();
    }

    function startFallbackCanvas(canvas) {
      const fCtx = canvas.getContext('2d');
      const barCount = 32;
      let fallbackStartTime = performance.now();
      const FALLBACK_DURATION = 30000; // 30 seconds

      function drawFallback(timestamp) {
        if (!fallbackActive) return;
        const elapsed = timestamp - fallbackStartTime;
        const progress = Math.min(elapsed / FALLBACK_DURATION, 1);
        const w = canvas.width;
        const h = canvas.height;

        // Dark background
        fCtx.fillStyle = '#0a0a14';
        fCtx.fillRect(0, 0, w, h);

        // Animated scrolling colored bars
        const barW = w / barCount;
        const scrollOffset = elapsed * 0.02;

        for (let i = 0; i < barCount + 2; i++) {
          const x = ((i * barW + scrollOffset) % (w + barW)) - barW;
          const hue = ((i * 15 + elapsed * 0.05) % 360);
          const saturation = 60 + Math.sin(elapsed * 0.003 + i) * 20;
          const lightness = 20 + Math.sin(elapsed * 0.002 + i * 0.5) * 10;
          fCtx.fillStyle = `hsl(${hue}, ${saturation}%, ${lightness}%)`;
          fCtx.fillRect(Math.floor(x / 4) * 4, 0, Math.ceil(barW / 4) * 4, h);
        }

        // Vertical stripes overlay for retro feel
        for (let x = 0; x < w; x += 8) {
          const alpha = 0.03 + Math.sin(elapsed * 0.001 + x * 0.01) * 0.02;
          fCtx.fillStyle = `rgba(0,0,0,${alpha})`;
          fCtx.fillRect(x, 0, 4, h);
        }

        // "VIDEO PLACEHOLDER" text
        fCtx.textAlign = 'center';
        fCtx.textBaseline = 'middle';

        // Text shadow
        fCtx.fillStyle = 'rgba(0,0,0,0.7)';
        fCtx.font = 'bold 32px monospace';
        fCtx.fillText('VIDEO PLACEHOLDER', w / 2 + 2, h / 2 - 42);
        fCtx.fillStyle = 'rgba(0,0,0,0.5)';
        fCtx.font = '20px monospace';
        fCtx.fillText('CinemaRoll Demo', w / 2 + 2, h / 2 + 8);

        // Glow text
        fCtx.fillStyle = `rgba(74, 222, 128, ${0.7 + Math.sin(elapsed * 0.003) * 0.25})`;
        fCtx.font = 'bold 32px monospace';
        fCtx.fillText('VIDEO PLACEHOLDER', w / 2, h / 2 - 44);
        fCtx.fillStyle = '#e0e0e0';
        fCtx.font = '20px monospace';
        fCtx.fillText('CinemaRoll Demo', w / 2, h / 2 + 6);

        // Progress bar on canvas
        const pbW = 400;
        const pbH = 16;
        const pbX = (w - pbW) / 2;
        const pbY = h / 2 + 50;

        // Track
        fCtx.fillStyle = '#111';
        fCtx.fillRect(pbX - 4, pbY - 4, pbW + 8, pbH + 8);
        fCtx.fillStyle = '#222';
        fCtx.fillRect(pbX, pbY, pbW, pbH);

        // Fill
        const fillW = pbW * progress;
        const r = Math.floor(74 + (239 - 74) * progress);
        const g_col = Math.floor(222 + (68 - 222) * progress);
        const b = Math.floor(128 + (68 - 128) * progress);
        fCtx.fillStyle = `rgb(${r},${g_col},${b})`;
        fCtx.fillRect(pbX, pbY, fillW, pbH);

        // Shimmer on bar
        fCtx.fillStyle = 'rgba(255,255,255,0.2)';
        for (let sx = pbX; sx < pbX + fillW; sx += 12) {
          fCtx.fillRect(sx + (elapsed * 0.05) % 12, pbY, 3, pbH);
        }

        // Percentage text
        fCtx.font = 'bold 14px monospace';
        fCtx.fillStyle = '#fff';
        fCtx.fillText(Math.round(progress * 100) + '%', w / 2, pbY + pbH + 24);

        // Scanline effect on canvas
        fCtx.fillStyle = 'rgba(0,0,0,0.08)';
        for (let sy = 0; sy < h; sy += 4) {
          fCtx.fillRect(0, sy, w, 2);
        }

        // If finished, show completion
        if (progress >= 1) {
          fCtx.fillStyle = `rgba(74, 222, 128, ${0.3 + Math.sin(elapsed * 0.005) * 0.2})`;
          fCtx.font = 'bold 22px monospace';
          fCtx.fillText('COMPLETE!', w / 2, h / 2 + 110);
        }

        requestAnimationFrame(drawFallback);
      }

      requestAnimationFrame(drawFallback);
    }

    function startFallbackProgress() {
      // Simulate video progress over 30 seconds
      const FALLBACK_DURATION = 30000;
      let startTime = performance.now();

      function updateFallbackProgress() {
        if (isVideoEnded) return;
        const elapsed = performance.now() - startTime;
        const pct = Math.min((elapsed / FALLBACK_DURATION) * 100, 100);

        progressFill.style.width = pct + '%';
        progressLabel.textContent = Math.round(pct) + '%';

        // Color transition
        if (pct < 33) {
          progressFill.style.background = '#4ade80';
          progressFill.style.boxShadow = '0 0 25px rgba(74,222,128,0.95), 0 0 55px rgba(74,222,128,0.45), 0 0 80px rgba(74,222,128,0.2)';
        } else if (pct < 66) {
          progressFill.style.background = '#facc15';
          progressFill.style.boxShadow = '0 0 25px rgba(250,204,21,0.95), 0 0 55px rgba(250,204,21,0.45), 0 0 80px rgba(250,204,21,0.2)';
        } else if (pct < 90) {
          progressFill.style.background = '#fb923c';
          progressFill.style.boxShadow = '0 0 25px rgba(251,146,60,0.95), 0 0 55px rgba(251,146,60,0.45), 0 0 80px rgba(251,146,60,0.2)';
        } else {
          progressFill.style.background = '#ef4444';
          progressFill.style.boxShadow = '0 0 25px rgba(239,68,68,0.95), 0 0 55px rgba(239,68,68,0.45), 0 0 80px rgba(239,68,68,0.2)';
        }

        // Countdown timer
        const remaining = Math.max(0, (FALLBACK_DURATION - elapsed) / 1000);
        const mins = Math.floor(remaining / 60);
        const secs = Math.floor(remaining % 60);
        countdown.textContent = `${String(mins).padStart(2,'0')}:${String(secs).padStart(2,'0')}`;

        countdown.classList.remove('warning', 'danger');
        if (remaining <= 5) countdown.classList.add('danger');
        else if (remaining <= 10) countdown.classList.add('warning');

        if (pct >= 100) {
          onVideoEnded();
        } else {
          requestAnimationFrame(updateFallbackProgress);
        }
      }

      requestAnimationFrame(updateFallbackProgress);
    }

    // Video event handlers
    video.addEventListener('loadedmetadata', () => {
      videoDuration = video.duration;
      loadingOverlay.classList.add('hidden');
      video.play().catch(() => {
        loadingOverlay.innerHTML = '<button class="pixel-btn btn-play" onclick="video.play(); loadingOverlay.classList.add(\'hidden\')">Click to Play</button>';
        loadingOverlay.classList.remove('hidden');
      });
    });

    video.addEventListener('error', () => {
      videoErrorCount++;
      if (videoErrorCount >= VIDEO_URLS.length) {
        activateFallbackCanvas();
      } else {
        tryNextVideo();
      }
    });

    video.addEventListener('ended', onVideoEnded);

    // Start trying video URLs
    tryNextVideo();

    // ===========================
    // Video Progress & Countdown
    // ===========================
    video.addEventListener('timeupdate', () => {
      if (!videoDuration || isVideoEnded || !useVideo) return;

      const pct = (video.currentTime / videoDuration) * 100;
      progressFill.style.width = pct + '%';
      progressLabel.textContent = Math.round(pct) + '%';

      // Color transition: green -> yellow -> orange -> red
      if (pct < 33) {
        progressFill.style.background = '#4ade80';
        progressFill.style.boxShadow = '0 0 20px rgba(74,222,128,0.8), 0 0 40px rgba(74,222,128,0.3)';
      } else if (pct < 66) {
        progressFill.style.background = '#facc15';
        progressFill.style.boxShadow = '0 0 25px rgba(250,204,21,0.95), 0 0 55px rgba(250,204,21,0.45), 0 0 80px rgba(250,204,21,0.2)';
      } else if (pct < 90) {
        progressFill.style.background = '#fb923c';
        progressFill.style.boxShadow = '0 0 25px rgba(251,146,60,0.95), 0 0 55px rgba(251,146,60,0.45), 0 0 80px rgba(251,146,60,0.2)';
      } else {
        progressFill.style.background = '#ef4444';
        progressFill.style.boxShadow = '0 0 25px rgba(239,68,68,0.95), 0 0 55px rgba(239,68,68,0.45), 0 0 80px rgba(239,68,68,0.2)';
      }

      // Countdown timer
      const remaining = Math.max(0, videoDuration - video.currentTime);
      const mins = Math.floor(remaining / 60);
      const secs = Math.floor(remaining % 60);
      countdown.textContent = `${String(mins).padStart(2,'0')}:${String(secs).padStart(2,'0')}`;

      countdown.classList.remove('warning', 'danger');
      if (remaining <= 5) countdown.classList.add('danger');
      else if (remaining <= 10) countdown.classList.add('warning');
    });

    function onVideoEnded() {
      if (isVideoEnded) return;
      isVideoEnded = true;
      countdown.classList.add('hidden');
      progressFill.style.width = '100%';
      progressLabel.textContent = '100%';
      progressFill.style.background = '#ef4444';
      unlockReward();
      setTimeout(() => {
        endScreen.classList.add('visible');
        startRedirectCountdown();
      }, 3000);
    }

    // ===========================
    // Reward System
    // ===========================
    function unlockReward() {
      btnClaim.disabled = false;
      btnClaim.classList.add('unlocked');
      claimText.textContent = 'Claim Reward';
      lockIcon.innerHTML = '<svg viewBox="0 0 14 14" fill="none" xmlns="http://www.w3.org/2000/svg"><path d="M7 1l1.8 3.7 4.1.6-3 2.9.7 4.1L7 10.2 3.4 12.3l.7-4.1-3-2.9 4.1-.6L7 1z" fill="#FFD700" stroke="#DAA520" stroke-width="1"/></svg>';
      const rect = btnClaim.getBoundingClientRect();
      spawnSparkles(rect.left + rect.width/2, rect.top + rect.height/2, 20);
    }

    btnClaim.addEventListener('click', () => {
      if (!btnClaim.classList.contains('unlocked') || isRewardClaimed) return;
      isRewardClaimed = true;
      btnClaim.classList.remove('unlocked');
      btnClaim.classList.add('claimed');
      claimText.textContent = 'Claimed! \u2713';
      btnClaim.disabled = true;
      const rect = btnClaim.getBoundingClientRect();
      spawnSparkles(rect.left + rect.width/2, rect.top + rect.height/2, 15);
    });

    // ===========================
    // Sparkle Particles
    // ===========================
    function spawnSparkles(x, y, count) {
      for (let i = 0; i < count; i++) {
        const el = document.createElement('div');
        el.className = 'sparkle';
        const angle = (Math.PI * 2 * i) / count + (Math.random() - 0.5) * 0.5;
        const dist = 30 + Math.random() * 60;
        el.style.left = x + 'px';
        el.style.top = y + 'px';
        el.style.setProperty('--tx', Math.cos(angle) * dist + 'px');
        el.style.setProperty('--ty', Math.sin(angle) * dist + 'px');
        const colors = ['#fff', '#ffd700', '#5865F2', '#4ade80'];
        el.style.background = colors[Math.floor(Math.random() * colors.length)];
        sparkleContainer.appendChild(el);
        setTimeout(() => el.remove(), 800);
      }
    }

    // ===========================
    // End Screen Redirect
    // ===========================
    function startRedirectCountdown() {
      redirectCountdown = 8;
      redirectText.textContent = `Redirecting in ${redirectCountdown} seconds...`;
      redirectInterval = setInterval(() => {
        redirectCountdown--;
        redirectText.textContent = `Redirecting in ${redirectCountdown} seconds...`;
        if (redirectCountdown <= 0) {
          clearInterval(redirectInterval);
          window.open('https://example.com', '_blank');
          redirectText.textContent = 'Redirected!';
        }
      }, 1000);
    }

    btnContinue.addEventListener('click', () => {
      if (redirectInterval) clearInterval(redirectInterval);
    });

    /* ================================================================
       ROLLING HILLS BACKGROUND -- CANVAS 2D
       ================================================================ */

    const ctx = hillsCanvas.getContext('2d');
    const aircraftCanvas = document.getElementById('aircraftCanvas');
    const aCtx = aircraftCanvas.getContext('2d');
    let W, H;
    let dpr = window.devicePixelRatio || 1;

    function resize() {
      W = window.innerWidth;
      H = window.innerHeight;
      hillsCanvas.width = W * dpr;
      hillsCanvas.height = H * dpr;
      hillsCanvas.style.width = W + 'px';
      hillsCanvas.style.height = H + 'px';
      ctx.setTransform(dpr, 0, 0, dpr, 0, 0);
      aircraftCanvas.width = W * dpr;
      aircraftCanvas.height = H * dpr;
      aircraftCanvas.style.width = W + 'px';
      aircraftCanvas.style.height = H + 'px';
      aCtx.setTransform(dpr, 0, 0, dpr, 0, 0);
    }
    resize();
    window.addEventListener('resize', resize);

    // ===========================
    // Pixelated Hill System -- 4px strips with highlight + grass
    // ===========================
    const STRIP_W = 4;

    function getHillY(x, layerConfig, offset) {
      const { baseY, amplitude, frequency, noiseOffset } = layerConfig;
      let y = baseY;
      y += Math.sin((x + offset * frequency + noiseOffset) * 0.003) * amplitude;
      y += Math.sin((x + offset * frequency * 2 + noiseOffset * 2) * 0.007) * amplitude * 0.5;
      y += Math.sin((x + offset * frequency * 0.5 + noiseOffset * 3) * 0.0015) * amplitude * 0.3;
      return y;
    }

    function drawHillLayer(time, layerConfig, offset, isFront) {
      // Main body: draw as 4px-wide vertical strips
      for (let x = 0; x <= W; x += STRIP_W) {
        const hillY = getHillY(x, layerConfig, offset);
        const stripH = H - hillY;

        // Main hill color
        ctx.fillStyle = layerConfig.color;
        ctx.fillRect(x, hillY, STRIP_W, stripH);

        // Highlight strip at the top (ridge highlight)
        if (isFront) {
          // Alternating highlight strips on crest for pixel-art look
          const stripIdx = Math.floor(x / STRIP_W);
          if (stripIdx % 3 === 0) {
            ctx.fillStyle = '#00CC44';
            ctx.fillRect(x, hillY, STRIP_W, 8);
          } else if (stripIdx % 3 === 1) {
            ctx.fillStyle = layerConfig.highlight;
            ctx.fillRect(x, hillY, STRIP_W, 6);
          } else {
            ctx.fillStyle = layerConfig.topHighlight;
            ctx.fillRect(x, hillY, STRIP_W, 4);
          }

          // Bright top pixel line
          ctx.fillStyle = layerConfig.topHighlight;
          ctx.fillRect(x, hillY, STRIP_W, 2);
        } else {
          // Subtle highlight for back layers
          ctx.fillStyle = layerConfig.highlight;
          ctx.fillRect(x, hillY, STRIP_W, 3);
        }
      }

      // Animated grass blades on front hill
      if (isFront) {
        drawGrassBlades(time, layerConfig, offset);
      }
    }

    // ===========================
    // Grass Blade System (like Project 1)
    // ===========================
    const grassBlades = [];
    function initGrass() {
      grassBlades.length = 0;
      const count = Math.floor(W / 6) + 50;
      for (let i = 0; i < count; i++) {
        grassBlades.push({
          x: Math.random() * (W + 100),
          offsetPhase: Math.random() * Math.PI * 2,
          height: 6 + Math.random() * 10,
          freq: 1.5 + Math.random() * 2,
          lean: (Math.random() - 0.5) * 0.4,
          color: ['#00CC44', '#00DD44', '#32b85a', '#44CC66'][Math.floor(Math.random() * 4)],
        });
      }
    }
    initGrass();

    function drawGrassBlades(time, layerConfig, offset) {
      grassBlades.forEach(blade => {
        const hillY = getHillY(blade.x, layerConfig, offset);
        const wind = Math.sin(time * blade.freq + blade.offsetPhase) * 3 + Math.sin(time * 0.7 + blade.x * 0.01) * 2;
        const tipX = blade.x + wind + blade.lean * 6;
        const tipY = hillY - blade.height + Math.abs(wind) * 0.5;

        ctx.beginPath();
        ctx.moveTo(blade.x, hillY + 2);
        ctx.quadraticCurveTo(
          blade.x + (tipX - blade.x) * 0.4,
          hillY - blade.height * 0.5,
          tipX, tipY
        );
        ctx.strokeStyle = blade.color;
        ctx.lineWidth = 2;
        ctx.lineCap = 'round';
        ctx.stroke();
      });
    }

    // ===========================
    // Pixel-Art Cloud System -- 5-7 overlapping white rectangles
    // ===========================
    class PixelCloud {
      constructor() {
        this.reset(true);
      }
      reset(randomX) {
        this.x = randomX ? Math.random() * W : W + 100 + Math.random() * 300;
        this.y = 20 + Math.random() * (H * 0.28);
        this.speed = 5 + Math.random() * 12;
        this.scale = 0.5 + Math.random() * 0.8;
        // Build cloud from 5-7 overlapping rectangles for defined shape
        this.puffs = [];
        const numPuffs = 5 + Math.floor(Math.random() * 3);
        // Central "anchor" puff first
        this.puffs.push({
          dx: 0, dy: 0, w: 30 + Math.random() * 20, h: 14 + Math.random() * 8,
        });
        for (let i = 1; i < numPuffs; i++) {
          this.puffs.push({
            dx: (Math.random() - 0.5) * 55,
            dy: (Math.random() - 0.5) * 14,
            w: 18 + Math.random() * 28,
            h: 10 + Math.random() * 12,
          });
        }
      }
      update(dt) {
        this.x -= this.speed * dt;
        if (this.x < -200) this.reset(false);
      }
      draw() {
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.scale(this.scale, this.scale);

        // Shadow layer (slightly offset, darker)
        ctx.globalAlpha = 0.25;
        ctx.fillStyle = 'rgba(200,210,230,0.6)';
        this.puffs.forEach(p => {
          ctx.fillRect(p.dx + 3, p.dy + 4, p.w, p.h);
        });

        // Main body -- semi-transparent white rectangles
        ctx.globalAlpha = 0.8;
        ctx.fillStyle = 'rgba(255,255,255,0.8)';
        this.puffs.forEach(p => {
          ctx.fillRect(p.dx, p.dy, p.w, p.h);
        });

        // Brighter highlight on top edges
        ctx.globalAlpha = 0.5;
        ctx.fillStyle = 'rgba(255,255,255,0.95)';
        this.puffs.forEach(p => {
          ctx.fillRect(p.dx + 2, p.dy, p.w - 4, 3);
        });

        ctx.restore();
      }
    }

    // ===========================
    // Wind Particles
    // ===========================
    class WindParticle {
      constructor() {
        this.reset();
      }
      reset() {
        this.x = W + Math.random() * 100;
        this.y = Math.random() * H * 0.9;
        this.speed = 80 + Math.random() * 150;
        this.length = 30 + Math.random() * 80;
        this.opacity = 0.05 + Math.random() * 0.12;
        this.width = 1 + Math.random() * 1.5;
        this.sway = Math.random() * Math.PI * 2;
        this.swayFreq = 0.5 + Math.random() * 1.5;
      }
      update(dt) {
        this.x -= this.speed * dt;
        if (this.x < -this.length - 50) this.reset();
      }
      draw(time) {
        const curve = Math.sin(time * this.swayFreq + this.sway) * 8;
        ctx.beginPath();
        ctx.moveTo(this.x, this.y);
        ctx.quadraticCurveTo(
          this.x + this.length * 0.5,
          this.y + curve,
          this.x + this.length,
          this.y + curve * 0.5
        );
        ctx.strokeStyle = `rgba(220,240,255,${this.opacity})`;
        ctx.lineWidth = this.width;
        ctx.lineCap = 'round';
        ctx.stroke();
      }
    }

    // ===========================
    // BLIMP (Airship) -- Full pixel-art design
    // Flies left-to-right, behind video player
    // ===========================
    class Blimp {
      constructor() {
        this.reset();
      }
      reset() {
        // Start off-screen left
        this.x = -280;
        // Y position: middle-upper area, roughly aligned with video player
        this.baseY = H * 0.06;
        this.y = this.baseY;
        this.speed = 35; // pixels per second (medium-slow)
        this.width = 220;
        this.height = 70;
        this.propAngle = 0;
        this.visible = true;
        this.waitTimer = 0;
        this.cycleDuration = 40; // seconds for full crossing
        this.state = 'flying'; // 'flying' | 'waiting'
      }
      update(dt, time) {
        if (this.state === 'waiting') {
          this.waitTimer -= dt;
          if (this.waitTimer <= 0) {
            this.state = 'flying';
            this.x = -280;
          }
          return;
        }

        // Flying state
        this.x += this.speed * dt;

        // Gentle bobbing
        this.y = this.baseY + Math.sin(time * 0.8) * 4;

        // Spin propeller
        this.propAngle += dt * 25;

        // Check if exited right
        if (this.x > W + 100) {
          this.state = 'waiting';
          this.waitTimer = 5 + Math.random() * 5; // 5-10s delay before reappearing
        }
      }
      draw(time) {
        if (this.state === 'waiting') return;

        const ctx = aCtx; // draw on aircraft canvas (above video)
        ctx.save();
        ctx.translate(this.x, this.y);

        const bw = this.width;
        const bh = this.height;
        const halfBw = bw * 0.5;
        const halfBh = bh * 0.5;

        // --- TAIL FINS (drawn first, behind body) ---
        // Vertical stabilizer (top fin)
        ctx.fillStyle = '#CC4444';
        ctx.beginPath();
        ctx.moveTo(-halfBw + 10, -halfBh + 8);
        ctx.lineTo(-halfBw - 30, -halfBh - 22);
        ctx.lineTo(-halfBw - 30, -halfBh + 3);
        ctx.lineTo(-halfBw + 5, -halfBh + 15);
        ctx.closePath();
        ctx.fill();
        // Fin highlight
        ctx.fillStyle = '#DD5555';
        ctx.beginPath();
        ctx.moveTo(-halfBw + 8, -halfBh + 6);
        ctx.lineTo(-halfBw - 26, -halfBh - 18);
        ctx.lineTo(-halfBw - 28, -halfBh - 5);
        ctx.closePath();
        ctx.fill();

        // Horizontal stabilizers (bottom fins)
        ctx.fillStyle = '#CC4444';
        // Bottom fin
        ctx.beginPath();
        ctx.moveTo(-halfBw + 10, halfBh - 8);
        ctx.lineTo(-halfBw - 28, halfBh + 12);
        ctx.lineTo(-halfBw - 28, halfBh - 3);
        ctx.lineTo(-halfBw + 5, halfBh - 12);
        ctx.closePath();
        ctx.fill();
        // Bottom fin highlight
        ctx.fillStyle = '#DD5555';
        ctx.beginPath();
        ctx.moveTo(-halfBw + 8, halfBh - 6);
        ctx.lineTo(-halfBw - 24, halfBh + 8);
        ctx.lineTo(-halfBw - 24, halfBh - 1);
        ctx.closePath();
        ctx.fill();

        // --- MAIN BODY (elongated ellipsoid) ---
        // Bottom shading (darker half)
        ctx.fillStyle = '#A0A0A0';
        ctx.beginPath();
        ctx.ellipse(0, 4, halfBw, halfBh, 0, 0, Math.PI * 2);
        ctx.fill();

        // Top half (lighter)
        ctx.fillStyle = '#C0C0C0';
        ctx.beginPath();
        ctx.ellipse(0, 0, halfBw, halfBh, 0, Math.PI, Math.PI * 2);
        ctx.fill();

        // Highlight line on top
        ctx.fillStyle = '#E8E8E8';
        ctx.beginPath();
        ctx.ellipse(0, -4, halfBw * 0.65, halfBh * 0.35, 0, Math.PI * 1.15, Math.PI * 1.85);
        ctx.fill();

        // Nose cap highlight
        ctx.fillStyle = '#D8D8D8';
        ctx.beginPath();
        ctx.ellipse(halfBw * 0.7, -2, 12, 8, 0, Math.PI * 1.3, Math.PI * 1.7);
        ctx.fill();

        // --- BILLBOARD AREA on blimp side ---
        const bbX = -40;
        const bbY = -14;
        const bbW = 110;
        const bbH = 28;

        // Billboard shadow (slight offset)
        ctx.fillStyle = 'rgba(0,0,0,0.25)';
        ctx.fillRect(bbX + 2, bbY + 2, bbW, bbH);

        // Billboard background
        ctx.fillStyle = '#222';
        ctx.fillRect(bbX, bbY, bbW, bbH);

        // Pixel border
        ctx.fillStyle = '#444';
        ctx.fillRect(bbX - 2, bbY - 2, bbW + 4, 2);
        ctx.fillRect(bbX - 2, bbY + bbH, bbW + 4, 2);
        ctx.fillRect(bbX - 2, bbY - 2, 2, bbH + 4);
        ctx.fillRect(bbX + bbW, bbY - 2, 2, bbH + 4);

        // Corner accents
        ctx.fillStyle = '#666';
        ctx.fillRect(bbX - 2, bbY - 2, 6, 2);
        ctx.fillRect(bbX + bbW - 4, bbY - 2, 6, 2);
        ctx.fillRect(bbX - 2, bbY + bbH, 6, 2);
        ctx.fillRect(bbX + bbW - 4, bbY + bbH, 6, 2);

        // Billboard text
        ctx.fillStyle = '#fff';
        ctx.font = 'bold 9px "Press Start 2P", monospace';
        ctx.textAlign = 'center';
        ctx.textBaseline = 'middle';
        ctx.fillText('YOUR AD HERE', bbX + bbW / 2, bbY + bbH / 2);

        // --- GONDOLA (cabin underneath) ---
        const gondolaW = 44;
        const gondolaH = 18;
        const gondolaX = 15;
        const gondolaY = halfBh + 2;

        // Support lines
        ctx.strokeStyle = '#666';
        ctx.lineWidth = 1.5;
        ctx.beginPath();
        ctx.moveTo(gondolaX - 12, halfBh - 5);
        ctx.lineTo(gondolaX - 8, gondolaY);
        ctx.moveTo(gondolaX, halfBh - 2);
        ctx.lineTo(gondolaX, gondolaY);
        ctx.moveTo(gondolaX + 12, halfBh - 5);
        ctx.lineTo(gondolaX + 8, gondolaY);
        ctx.stroke();

        // Gondola body
        ctx.fillStyle = '#444';
        ctx.beginPath();
        ctx.roundRect(gondolaX - gondolaW / 2, gondolaY, gondolaW, gondolaH, 4);
        ctx.fill();

        // Gondola highlight (top edge)
        ctx.fillStyle = '#555';
        ctx.beginPath();
        ctx.roundRect(gondolaX - gondolaW / 2, gondolaY, gondolaW, 5, [4, 4, 0, 0]);
        ctx.fill();

        // Windows (3 small blue rectangles)
        ctx.fillStyle = '#87CEEB';
        for (let wi = 0; wi < 3; wi++) {
          const wx = gondolaX - 14 + wi * 14;
          ctx.fillRect(wx, gondolaY + 7, 8, 7);
        }
        // Window highlights
        ctx.fillStyle = '#B0E0FF';
        for (let wi = 0; wi < 3; wi++) {
          const wx = gondolaX - 14 + wi * 14;
          ctx.fillRect(wx, gondolaY + 7, 8, 2);
        }

        // --- REAR PROPELLER ---
        const propX = -halfBw + 5;
        const propY = 0;
        const propRadius = 10;

        // Propeller hub
        ctx.fillStyle = '#888';
        ctx.beginPath();
        ctx.arc(propX, propY, 3, 0, Math.PI * 2);
        ctx.fill();

        // Spinning blades
        ctx.save();
        ctx.translate(propX, propY);
        ctx.rotate(this.propAngle);
        ctx.fillStyle = 'rgba(180,180,180,0.7)';
        ctx.fillRect(-1, -propRadius, 2, propRadius * 2);
        ctx.fillRect(-propRadius, -1, propRadius * 2, 2);
        ctx.restore();

        // Engine glow behind propeller
        const glowAlpha = 0.3 + Math.sin(time * 8) * 0.15;
        ctx.fillStyle = `rgba(100,200,255,${glowAlpha})`;
        ctx.beginPath();
        ctx.arc(propX - 4, propY, 6, 0, Math.PI * 2);
        ctx.fill();

        ctx.restore();
      }
    }

    // ===========================
    // SMALL PLANE with Trailing Banner
    // Flies left-to-right, banner trails behind
    // ===========================
    class BannerPlane {
      constructor() {
        this.reset();
      }
      reset() {
        this.x = -50;
        // Plane flies high: 6% from top (responsive: min 30px, max 80px)
        this.baseY = Math.max(30, Math.min(80, H * 0.06));
        this.y = this.baseY;
        this.speed = 22; // pixels per second (slow)
        this.propAngle = 0;
        this.state = 'flying'; // 'flying' | 'waiting'
        this.waitTimer = 0;
        this.bannerText = 'Check out our latest content and subscribe for more amazing updates today!';
        this.bannerLength = 480;
        this.bannerWaveOffset = Math.random() * Math.PI * 2;
      }
      update(dt, time) {
        if (this.state === 'waiting') {
          this.waitTimer -= dt;
          if (this.waitTimer <= 0) {
            this.state = 'flying';
            this.x = -50;
            this.bannerWaveOffset = Math.random() * Math.PI * 2;
          }
          return;
        }

        // Fly rightward
        this.x += this.speed * dt;

        // Gentle altitude variation
        this.y = this.baseY + Math.sin(time * 0.6 + this.bannerWaveOffset) * 6;

        // Spin propeller fast
        this.propAngle += dt * 40;

        // Check if fully exited right (including banner)
        if (this.x > W + this.bannerLength + 80) {
          this.state = 'waiting';
          this.waitTimer = 8 + Math.random() * 7; // 8-15s delay
        }
      }
      draw(time) {
        if (this.state === 'waiting') return;

        const px = this.x;
        const py = this.y;

        // --- TRAILING BANNER (drawn first so plane appears on top) ---
        this.drawBanner(time, px, py);

        // --- PLANE BODY ---
        ctx.save();
        ctx.translate(px, py);

        // Shadow (slight offset)
        ctx.fillStyle = 'rgba(0,0,0,0.15)';
        ctx.fillRect(-8, 3, 28, 7);
        ctx.fillRect(-16, 5, 12, 4);

        // Main body (horizontal rectangle, red)
        ctx.fillStyle = '#E83838';
        ctx.fillRect(-10, 0, 26, 7);

        // Body highlight (top edge)
        ctx.fillStyle = '#FF5555';
        ctx.fillRect(-10, 0, 26, 2);

        // Body shadow (bottom edge)
        ctx.fillStyle = '#AA2222';
        ctx.fillRect(-10, 5, 26, 2);

        // Wings (crossing rectangle, white)
        ctx.fillStyle = '#F0F0F0';
        ctx.fillRect(-4, -6, 10, 18);
        // Wing highlight
        ctx.fillStyle = '#FFFFFF';
        ctx.fillRect(-4, -6, 10, 3);
        // Wing shadow
        ctx.fillStyle = '#D0D0D0';
        ctx.fillRect(-4, 8, 10, 4);

        // Tail (small vertical + horizontal stabilizer)
        ctx.fillStyle = '#E83838';
        // Vertical tail
        ctx.fillRect(-14, -5, 5, 8);
        ctx.fillStyle = '#FF5555';
        ctx.fillRect(-14, -5, 5, 2);
        // Horizontal tail
        ctx.fillStyle = '#F0F0F0';
        ctx.fillRect(-16, 1, 8, 4);

        // Cockpit window (small blue dot)
        ctx.fillStyle = '#87CEEB';
        ctx.fillRect(10, 1, 4, 3);
        ctx.fillStyle = '#B0E0FF';
        ctx.fillRect(10, 1, 4, 1);

        // --- PROPELLER (spinning at front) ---
        const propX = 17;
        ctx.save();
        ctx.translate(propX, 3);
        ctx.rotate(this.propAngle);
        // Propeller disc (motion blur effect)
        ctx.fillStyle = 'rgba(200,200,200,0.35)';
        ctx.beginPath();
        ctx.ellipse(0, 0, 2, 8, 0, 0, Math.PI * 2);
        ctx.fill();
        ctx.beginPath();
        ctx.ellipse(0, 0, 8, 2, 0, 0, Math.PI * 2);
        ctx.fill();
        // Propeller hub
        ctx.fillStyle = '#999';
        ctx.beginPath();
        ctx.arc(0, 0, 2, 0, Math.PI * 2);
        ctx.fill();
        ctx.restore();

        ctx.restore();
      }
      drawBanner(time, planeX, planeY) {
        const bannerStartX = planeX - 12; // Connects to back of plane
        const bannerBaseY = planeY + 18; // Below the plane
        const segWidth = 8;
        const numSegs = Math.floor(this.bannerLength / segWidth);

        ctx.save();

        // Banner background -- drawn as segments with sine wave furling
        for (let i = 0; i < numSegs; i++) {
          const segX = bannerStartX - i * segWidth;
          const waveY = Math.sin(i * 0.08 + time * 2.5 + this.bannerWaveOffset) * 5;
          const waveY2 = Math.sin(i * 0.04 + time * 1.5 + this.bannerWaveOffset) * 3;
          const totalWave = waveY + waveY2;

          // Shadow
          ctx.fillStyle = 'rgba(0,0,0,0.12)';
          ctx.fillRect(segX + 1, bannerBaseY + totalWave + 2, segWidth, 22);

          // Main white strip
          ctx.fillStyle = '#F8F8F8';
          ctx.fillRect(segX, bannerBaseY + totalWave, segWidth, 22);

          // Top edge highlight
          ctx.fillStyle = '#FFF';
          ctx.fillRect(segX, bannerBaseY + totalWave, segWidth, 2);

          // Bottom edge shadow
          ctx.fillStyle = '#E0E0E0';
          ctx.fillRect(segX, bannerBaseY + totalWave + 20, segWidth, 2);

          // Dashed border dots
          if (i % 4 === 0) {
            ctx.fillStyle = '#CC3333';
            ctx.fillRect(segX + 1, bannerBaseY + totalWave + 2, 3, 3);
            ctx.fillRect(segX + 1, bannerBaseY + totalWave + 17, 3, 3);
          }
        }

        // Banner text -- follows the wave curve
        ctx.fillStyle = '#333';
        ctx.font = 'bold 9px "Press Start 2P", monospace';
        ctx.textAlign = 'center';
        ctx.textBaseline = 'middle';

        // Draw text in chunks following the banner's wave
        const text = this.bannerText;
        const textX = bannerStartX - this.bannerLength / 2 - 10;
        const charSpacing = 6.5;
        const startCharIdx = 0;

        for (let ci = 0; ci < text.length; ci++) {
          const charGlobalIdx = startCharIdx + ci;
          const segIdx = Math.floor((this.bannerLength / 2 + ci * charSpacing) / segWidth);
          if (segIdx < 0 || segIdx >= numSegs) continue;

          const charX = textX + ci * charSpacing;
          const waveY = Math.sin(segIdx * 0.08 + time * 2.5 + this.bannerWaveOffset) * 5;
          const waveY2 = Math.sin(segIdx * 0.04 + time * 1.5 + this.bannerWaveOffset) * 3;
          const totalWave = waveY + waveY2;

          ctx.fillText(text[ci], charX, bannerBaseY + totalWave + 11);
        }

        // Banner tail (triangular cut at the end)
        const tailX = bannerStartX - numSegs * segWidth;
        const tailWaveY = Math.sin(numSegs * 0.08 + time * 2.5 + this.bannerWaveOffset) * 5
                       + Math.sin(numSegs * 0.04 + time * 1.5 + this.bannerWaveOffset) * 3;

        ctx.fillStyle = '#CC3333';
        ctx.beginPath();
        ctx.moveTo(tailX, bannerBaseY + tailWaveY + 2);
        ctx.lineTo(tailX - 12, bannerBaseY + tailWaveY + 11);
        ctx.lineTo(tailX, bannerBaseY + tailWaveY + 20);
        ctx.closePath();
        ctx.fill();

        ctx.restore();
      }
    }

    // ===========================
    // Hill Layer Configurations (3-layer parallax: 0.1, 0.2, 0.4)
    // ===========================
    const hillConfigs = [
      {
        color: '#1a6b2e',
        highlight: '#25803a',
        topHighlight: '#309048',
        speed: 0.1,
        baseY: H * 0.52,
        amplitude: 45,
        frequency: 1.0,
        noiseOffset: 0,
        offset: 0,
      },
      {
        color: '#2a9a45',
        highlight: '#34b050',
        topHighlight: '#40c55e',
        speed: 0.2,
        baseY: H * 0.65,
        amplitude: 35,
        frequency: 1.3,
        noiseOffset: 100,
        offset: 0,
      },
      {
        color: '#3dd068',
        highlight: '#00CC44',
        topHighlight: '#55e878',
        speed: 0.4,
        baseY: H * 0.78,
        amplitude: 28,
        frequency: 1.6,
        noiseOffset: 300,
        offset: 0,
      },
    ];

    function updateHillConfigs() {
      hillConfigs[0].baseY = H * 0.52;
      hillConfigs[1].baseY = H * 0.65;
      hillConfigs[2].baseY = H * 0.78;
      initGrass();
    }
    window.addEventListener('resize', updateHillConfigs);
    setTimeout(updateHillConfigs, 100);

    // ===========================
    // Scene objects
    // ===========================

    // Animated blimp
    const blimp = new Blimp();

    // Banner plane
    const bannerPlane = new BannerPlane();

    // Clouds
    const clouds = [];
    for (let i = 0; i < 8; i++) clouds.push(new PixelCloud());

    // Wind particles
    const windParticles = [];
    for (let i = 0; i < 25; i++) windParticles.push(new WindParticle());

    // Resize handler for aircraft Y-positions
    function updateAircraftPositions() {
      // Blimp: high up, just below top edge
      blimp.baseY = Math.max(30, Math.min(80, H * 0.06));
      // Plane: slightly below blimp, same responsive clamp
      bannerPlane.baseY = Math.max(60, Math.min(130, H * 0.10));
    }
    window.addEventListener('resize', updateAircraftPositions);
    setTimeout(updateAircraftPositions, 100);

    // ===========================
    // MAIN RENDER LOOP
    // ===========================
    function render(timestamp) {
      const dt = Math.min((timestamp - lastTime) / 1000, 0.05);
      lastTime = timestamp;
      const time = timestamp / 1000;

      // Clear & sky gradient
      const skyGrad = ctx.createLinearGradient(0, 0, 0, H);
      skyGrad.addColorStop(0, '#87CEEB');
      skyGrad.addColorStop(0.5, '#a8daf5');
      skyGrad.addColorStop(1, '#c8f0d8');
      ctx.fillStyle = skyGrad;
      ctx.fillRect(0, 0, W, H);

      // Pixel sun
      ctx.fillStyle = 'rgba(255,235,150,0.25)';
      ctx.fillRect(W * 0.78 - 45, 30, 90, 90);
      ctx.fillStyle = 'rgba(255,233,107,0.5)';
      ctx.fillRect(W * 0.78 - 28, 47, 56, 56);
      ctx.fillStyle = '#ffe96b';
      ctx.fillRect(W * 0.78 - 18, 57, 36, 36);
      ctx.fillStyle = '#fff5b8';
      ctx.fillRect(W * 0.78 - 10, 65, 20, 20);

      // Update & draw clouds (behind everything)
      clouds.forEach(c => { c.update(dt); c.draw(); });

      // --- BLIMP LAYER (above video, along top edge) ---
      aCtx.clearRect(0, 0, W, H);

      // Update & draw blimp (left to right, ON TOP of video)
      blimp.update(dt, time);
      blimp.draw(time);

      // --- PLANE LAYER (in background hills canvas) ---
      // Update & draw banner plane (left to right, in upper sky behind video)
      bannerPlane.update(dt, time);
      bannerPlane.draw(time);

      // Update hill offsets
      hillConfigs.forEach(cfg => {
        cfg.offset += cfg.speed * dt * 60;
      });

      // Back hill
      drawHillLayer(time, hillConfigs[0], hillConfigs[0].offset, false);
      // Mid hill
      drawHillLayer(time, hillConfigs[1], hillConfigs[1].offset, false);
      // Front hill (with grass)
      drawHillLayer(time, hillConfigs[2], hillConfigs[2].offset, true);

      // Wind particles (foreground)
      windParticles.forEach(w => {
        w.update(dt);
        w.draw(time);
      });

      requestAnimationFrame(render);
    }

    requestAnimationFrame(render);""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
