module ConvertedFiles.Love

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "A Letter From Bomman 💕"
            ]
            style [] [
                    rawText ("""/* ===== ORIGINAL BY BOMMAN u/tvenk/ -- License Closed Unless Permission Elsewhere Notated **Subject to rights & restrictions by /tvenk/** ===== */
  /* ===== FONTS ===== */
  @import url('https://fonts.googleapis.com/css2?family=Comic+Neue:ital,wght@0,400;0,700;1,400&display=swap');

  /* ===== RESET ===== */
  *, *::before, *::after { box-sizing: border-box; margin: 0; padding: 0; }

  /* ===== XP BLISS DESKTOP ===== */
  html, body {
    width: 100%; height: 100%; overflow: hidden;
    font-family: 'Comic Neue', 'Comic Sans MS', cursive;
    cursor: default;
    user-select: none;
  }

  body {
    background: #3a7d44;
    background-image:
      radial-gradient(ellipse 120% 80% at 50% 110%, #1a5c2a 0%, #3a7d44 40%, #6ab04c 65%, #8ecf60 75%, #a8d878 80%),
      radial-gradient(ellipse 200% 60% at 50% -10%, #1e6bb0 0%, #3a9bd5 40%, #6bbce8 70%, #b8dcf0 88%, #e8f4fb 100%);
    background-blend-mode: multiply, normal;
    position: relative;
  }

  /* ===== GRAIN / FILM EFFECT ===== */
  body::before {
    content: '';
    position: fixed; inset: 0; z-index: 9999;
    pointer-events: none;
    background-image: url("data:image/svg+xml,%3Csvg viewBox='0 0 200 200' xmlns='http://www.w3.org/2000/svg'%3E%3Cfilter id='noise'%3E%3CfeTurbulence type='fractalNoise' baseFrequency='0.85' numOctaves='4' stitchTiles='stitch'/%3E%3C/filter%3E%3Crect width='100%25' height='100%25' filter='url(%23noise)'/%3E%3C/svg%3E");
    background-size: 160px 160px;
    opacity: 0.035;
    mix-blend-mode: overlay;
  }

  /* ===== CRT SCANLINES ===== */
  body::after {
    content: '';
    position: fixed; inset: 0; z-index: 9998;
    pointer-events: none;
    background: repeating-linear-gradient(
      0deg,
      transparent,
      transparent 2px,
      rgba(0,0,0,0.04) 2px,
      rgba(0,0,0,0.04) 4px
    );
  }

  /* ===== FLOATING PARTICLES ===== */
  .particle {
    position: fixed;
    pointer-events: none;
    z-index: 10;
    animation: floatUp linear infinite;
    font-size: 1.2rem;
    opacity: 0;
  }
  @keyframes floatUp {
    0%   { transform: translateY(110vh) rotate(0deg);   opacity: 0; }
    10%  { opacity: 0.9; }
    90%  { opacity: 0.9; }
    100% { transform: translateY(-10vh) rotate(360deg); opacity: 0; }
  }


  /* ===== START MENU ===== */
  .start-menu {
    position: fixed;
    bottom: 30px;
    left: 0;
    width: 380px;
    background: #ece9d8;
    border: 2px solid #245edb;
    border-radius: 8px 8px 0 0;
    box-shadow: 4px 4px 14px rgba(0,0,0,0.45);
    z-index: 9996;
    display: none;
    overflow: hidden;
  }
  .start-menu.open { display: block; }
  .start-menu-header {
    background: linear-gradient(180deg, #0a4fb3 0%, #1058c0 8%, #1b6cd4 15%, #1265c8 50%, #0e57b4 80%, #083fa0 100%);
    color: white;
    padding: 10px 12px;
    font-family: 'Tahoma', sans-serif;
    font-size: 12px;
    font-weight: bold;
    display: flex;
    align-items: center;
    gap: 8px;
  }
  .start-menu-body {
    padding: 10px 8px 12px 8px; min-height: 360px; display:flex; flex-direction:column; justify-content:flex-start;
    background: linear-gradient(90deg, #f5f2ea 0 67%, #d6e5fb 67% 100%);
  }
  .start-item {
    display: flex;
    align-items: center;
    gap: 10px;
    width: 100%;
    padding: 8px 10px;
    border-radius: 4px;
    cursor: pointer;
    font-family: 'Tahoma', sans-serif;
    font-size: 12px;
    color: #111;
  }
  .start-item:hover {
    background: #316ac5;
    color: white;
  }
  .start-item-icon {
    width: 24px;
    text-align: center;
    font-size: 18px;
  }
  .start-item-meta {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
  }
  .start-item-sub {
    font-size: 10px;
    opacity: 0.8;
  }

  /* ===== TASKBAR ===== */
  .taskbar {
    position: fixed; bottom: 0; left: 0; right: 0; height: 30px;
    background: linear-gradient(180deg, #245edb 0%, #1e4fc2 4%, #3565c9 6%, #2b5abf 50%, #1e4aad 95%, #17399a 100%);
    display: flex; align-items: center;
    box-shadow: 0 -1px 0 #1a3a8a;
    z-index: 9997;
  }
  .start-btn {
    height: 100%;
    background: linear-gradient(180deg, #54a030 0%, #3d8a1e 50%, #2d7010 100%);
    border: 1px solid #1a5a08;
    border-radius: 0 10px 10px 0;
    padding: 0 10px 0 8px;
    color: white;
    font-family: 'Comic Neue', 'Comic Sans MS', cursive;
    font-weight: bold;
    font-size: 13px;
    cursor: pointer;
    display: flex; align-items: center; gap: 5px;
    text-shadow: 1px 1px 1px rgba(0,0,0,0.5);
    box-shadow: 1px 0 3px rgba(0,0,0,0.3);
  }
  .taskbar-clock {
    margin-left: auto;
    color: white;
    font-size: 11px;
    padding: 0 10px;
    font-family: 'Tahoma', sans-serif;
    text-shadow: 1px 1px 1px rgba(0,0,0,0.4);
    border-left: 1px solid rgba(255,255,255,0.15);
  }
  .taskbar-window-btn {
    margin-left: 6px;
    background: linear-gradient(180deg, #3d78d0 0%, #2a5fb5 50%, #1e4fa0 100%);
    border: 1px solid #1a3a8a;
    border-radius: 3px;
    color: white;
    font-size: 11px;
    font-family: 'Tahoma', sans-serif;
    padding: 2px 8px;
    cursor: pointer;
    text-shadow: 1px 1px 1px rgba(0,0,0,0.4);
  }

  /* ===== XP WINDOW BASE ===== */
  .xp-window {
    position: absolute;
    background: #ece9d8;
    border: 2px solid #003c74;
    border-radius: 8px 8px 0 0;
    box-shadow: 2px 2px 8px rgba(0,0,0,0.5), inset 0 0 0 1px rgba(255,255,255,0.6);
    min-width: 240px;
    overflow: hidden;
    z-index: 100;
    filter: drop-shadow(3px 5px 8px rgba(0,0,0,0.4));
  }
  .xp-titlebar {
    background: linear-gradient(180deg, #0a4fb3 0%, #1058c0 8%, #1b6cd4 15%, #1265c8 50%, #0e57b4 80%, #083fa0 100%);
    height: 28px;
    display: flex; align-items: center;
    padding: 0 4px;
    gap: 4px;
    border-bottom: 1px solid #00286a;
  }
  .xp-title-icon { font-size: 14px; }
  .xp-title-text {
    color: white;
    font-family: 'Tahoma', 'Trebuchet MS', sans-serif;
    font-weight: bold;
    font-size: 12px;
    text-shadow: 1px 1px 2px rgba(0,0,0,0.5);
    flex: 1;
  }
  .xp-btn {
    width: 21px; height: 21px;
    border-radius: 3px;
    border: 1px solid rgba(0,0,0,0.3);
    display: flex; align-items: center; justify-content: center;
    font-size: 11px; font-weight: bold;
    cursor: pointer;
    font-family: 'Webdings', 'Marlett', sans-serif;
    text-shadow: none;
    transition: filter 0.1s;
    background: linear-gradient(180deg, #f0c060 0%, #d8960a 100%);
    color: #5a3000;
  }
  .xp-btn.close { background: linear-gradient(180deg, #f08080 0%, #c82020 100%); color: white; }
  .xp-btn:hover { filter: brightness(1.15); }

  /* ===== LOADING SCREEN ===== */
  #loading-screen {
    position: fixed; inset: 0;
    background: #000;
    z-index: 99999;
    display: flex; flex-direction: column;
    align-items: center; justify-content: center;
    transition: opacity 0.6s ease;
  }
  #loading-screen.fade-out { opacity: 0; pointer-events: none; }
  .xp-boot-logo {
    color: white;
    font-family: 'Tahoma', sans-serif;
    font-size: 28px;
    font-weight: bold;
    letter-spacing: 2px;
    margin-bottom: 20px;
  }
  .xp-boot-logo span { color: #4ea6dc; }
  .progress-bar-track {
    width: 200px; height: 16px;
    border: 1px solid #555;
    border-radius: 8px;
    overflow: hidden;
    background: #111;
  }
  .progress-bar-fill {
    height: 100%;
    background: linear-gradient(90deg, #3a78c0, #6ab0e8, #3a78c0);
    background-size: 200% 100%;
    border-radius: 8px;
    width: 0%;
    animation: bootFill 2.2s ease-in forwards, shimmerBar 0.8s linear infinite;
  }
  @keyframes bootFill { to { width: 100%; } }
  @keyframes shimmerBar { 0%{background-position:0% 0%} 100%{background-position:200% 0%} }
  .xp-boot-text {
    color: #aaa;
    font-size: 11px;
    font-family: 'Tahoma', sans-serif;
    margin-top: 10px;
  }

  /* ===== MAIN LETTER WINDOW ===== */
  #letter-window {
    width: min(680px, 94vw);
    top: 50%; left: 50%;
    transform: translate(-50%, -52%);
    opacity: 0;
    transition: opacity 0.4s ease, transform 0.4s cubic-bezier(0.16,1,0.3,1);
    transform-origin: center bottom;
  }
  #letter-window.opened {
    opacity: 1;
    transform: translate(-50%, -52%) scale(1);
  }
  .letter-body {
    background: #fff;
    padding: 22px 28px;
    max-height: 68vh;
    overflow-y: auto;
    border-top: 2px inset rgba(0,0,0,0.1);
  }
  .letter-body::-webkit-scrollbar { width: 14px; }
  .letter-body::-webkit-scrollbar-track { background: #ece9d8; }
  .letter-body::-webkit-scrollbar-thumb {
    background: linear-gradient(180deg, #3a78c0, #2560aa);
    border: 1px solid #1a4a8a;
    border-radius: 2px;
  }

  /* ===== LETTER HEADER ===== */
  .letter-header {
    display: flex;
    align-items: center;
    gap: 16px;
    margin-bottom: 20px;
    padding-bottom: 16px;
    border-bottom: 2px dashed #c8a080;
  }
  .bomman-img {
    width: 90px; height: 90px;
    object-fit: cover;
    border-radius: 4px;
    border: 3px solid #c8a080;
    box-shadow: 2px 2px 6px rgba(0,0,0,0.25),
                inset 0 0 0 1px rgba(255,255,255,0.5);
    image-rendering: pixelated;
    filter: contrast(1.05) saturate(1.1);
    flex-shrink: 0;
  }
  .bomman-placeholder {
    width: 90px; height: 90px;
    background: linear-gradient(135deg, #8d6e52, #6b4c2a);
    border-radius: 4px;
    border: 3px solid #c8a080;
    display: flex; align-items: center; justify-content: center;
    font-size: 2.5rem;
    flex-shrink: 0;
  }
  .letter-from {
    flex: 1;
  }
  .letter-from-name {
    font-size: 1.5rem;
    font-weight: bold;
    color: #8b2252;
    text-shadow: 1px 1px 0 rgba(255,200,200,0.6);
    line-height: 1.2;
  }
  .letter-from-title {
    font-size: 0.85rem;
    color: #a06840;
    font-style: italic;
    margin-top: 2px;
  }
  .heart-stars {
    font-size: 1.4rem;
    animation: wiggle 1.8s ease-in-out infinite;
    line-height: 1.6;
    letter-spacing: 3px;
  }
  @keyframes wiggle {
    0%, 100% { transform: scale(1) rotate(-3deg); }
    50%       { transform: scale(1.12) rotate(3deg); }
  }

  /* ===== LETTER TEXT ===== */
  .letter-salutation {
    font-size: 1.15rem;
    font-weight: bold;
    color: #8b2252;
    margin-bottom: 14px;
  }
  .letter-paragraph {
    font-size: 1rem;
    line-height: 1.75;
    color: #2a1a0a;
    margin-bottom: 14px;
    text-wrap: pretty;
    max-width: 100%;
  }
  .letter-paragraph.typed { overflow: hidden; }
  .letter-signature {
    margin-top: 22px;
    text-align: right;
    font-weight: bold;
    color: #8b2252;
    font-size: 1.1rem;
    font-style: italic;
  }
  .letter-signature .paw {
    font-size: 1.5rem;
    display: block;
    margin-top: 4px;
    letter-spacing: 4px;
  }

  /* ===== ACCENT STICKERS (XP clip art vibe) ===== */
  .sticker {
    position: absolute;
    pointer-events: none;
    font-size: 1.6rem;
    animation: stickerBounce 2.4s ease-in-out infinite;
  }
  @keyframes stickerBounce {
    0%, 100% { transform: translateY(0) rotate(-8deg) scale(1); }
    50%       { transform: translateY(-6px) rotate(8deg) scale(1.08); }
  }

  /* ===== BOMMAN POPUP DIALOG ===== */
  #bomman-popup {
    width: min(300px, 88vw);
    top: 12%;
    right: calc(50% - min(340px, 47vw) - 310px);
    opacity: 0;
    transform: scale(0.8) rotate(-3deg);
    transition: opacity 0.3s ease, transform 0.4s cubic-bezier(0.16,1,0.3,1);
    z-index: 200;
  }
  #bomman-popup.popped {
    opacity: 1;
    transform: scale(1) rotate(-2deg);
  }
  .popup-body {
    padding: 14px 16px;
    display: flex;
    align-items: flex-start;
    gap: 10px;
    background: #ece9d8;
  }
  .popup-bomman { font-size: 2.8rem; line-height: 1; flex-shrink: 0; }
  .popup-text {
    font-size: 0.85rem;
    line-height: 1.5;
    color: #1a1a1a;
    font-family: 'Comic Neue', cursive;
  }
  .popup-btn-row {
    display: flex; gap: 8px; margin-top: 10px;
  }
  .popup-ok-btn {
    flex: 1;
    background: linear-gradient(180deg, #ece9d8, #d4d0c8);
    border: 1px solid #888;
    border-radius: 3px;
    padding: 3px 0;
    font-size: 11px;
    font-family: 'Tahoma', sans-serif;
    cursor: pointer;
    box-shadow: 1px 1px 0 rgba(255,255,255,0.8) inset, -1px -1px 0 rgba(0,0,0,0.1) inset;
  }
  .popup-ok-btn:hover {
    background: linear-gradient(180deg, #d4d0c8, #bfbbb2);
  }
  .popup-ok-btn:active { box-shadow: -1px -1px 0 rgba(255,255,255,0.8) inset, 1px 1px 0 rgba(0,0,0,0.1) inset; }

  /* ===== TOOLTIP / STATUS BAR ===== */
  .status-bar {
    background: #ece9d8;
    border-top: 1px solid #b0aa98;
    padding: 2px 8px;
    display: flex; gap: 12px;
    font-size: 10px;
    font-family: 'Tahoma', sans-serif;
    color: #555;
  }
  .status-bar-item { border-right: 1px solid #c8c4b8; padding-right: 10px; }

  /* ===== MENU BAR ===== */
  .xp-menubar {
    background: #ece9d8;
    border-bottom: 1px solid #b0aa98;
    padding: 2px 4px;
    display: flex;
    gap: 2px;
    font-size: 11px;
    font-family: 'Tahoma', sans-serif;
  }
  .xp-menu-item {
    padding: 2px 8px;
    border-radius: 3px;
    cursor: pointer;
    color: #1a1a1a;
  }
  .xp-menu-item:hover { background: #316ac5; color: white; }

  /* ===== FLYING CLIPART ===== */
  .clipart {
    position: fixed;
    pointer-events: none;
    z-index: 15;
    font-size: 1.1rem;
    opacity: 0;
    animation: flyAcross linear infinite;
  }
  @keyframes flyAcross {
    0%   { transform: translateX(-60px) translateY(0) rotate(0deg); opacity: 0; }
    5%   { opacity: 0.85; }
    95%  { opacity: 0.85; }
    100% { transform: translateX(110vw) translateY(-30px) rotate(20deg); opacity: 0; }
  }

  /* ===== TYPEWRITER CURSOR ===== */
  .cursor-blink {
    display: inline-block;
    width: 2px; height: 1em;
    background: #333;
    margin-left: 2px;
    vertical-align: middle;
    animation: blink 0.7s step-end infinite;
  }
  @keyframes blink { 0%,100%{opacity:1} 50%{opacity:0} }

  /* ===== GLITTER TEXT ===== */
  .glitter {
    background: linear-gradient(90deg, #e8004a, #ff8800, #ffe000, #00c832, #005ce6, #a000e6);
    background-size: 300% 100%;
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    animation: glitterShift 2s linear infinite;
  }
  @keyframes glitterShift { 0%{background-position:0% 50%} 100%{background-position:300% 50%} }

  /* ===== WIPE-IN TRANSITION (Movie Maker) ===== */
  @keyframes wipeIn {
    from { clip-path: inset(0 100% 0 0); }
    to   { clip-path: inset(0 0% 0 0); }
  }
  .wipe-in { animation: wipeIn 0.6s cubic-bezier(0.4, 0, 0.2, 1) both; }

  /* ===== SCREENSAVER STAR ===== */
  .screensaver-star {
    position: fixed;
    pointer-events: none;
    z-index: 8;
    border-radius: 50%;
    animation: starMove linear infinite;
    opacity: 0.6;
  }
  @keyframes starMove {
    0%   { transform: translate(0, 0) scale(0.3); opacity: 0; }
    20%  { opacity: 0.7; }
    80%  { opacity: 0.7; }
    100% { transform: translate(var(--tx), var(--ty)) scale(1.5); opacity: 0; }
  }

  /* ===== DESKTOP ICONS ===== */
  .desktop-icon {
    position: absolute;
    display: flex; flex-direction: column; align-items: center;
    gap: 4px;
    cursor: pointer;
    padding: 6px;
    border-radius: 4px;
    width: 68px;
    text-align: center;
  }
  .desktop-icon:hover { background: rgba(49,106,197,0.4); }
  .desktop-icon:active { background: rgba(49,106,197,0.7); }
.desktop-icon-img {
    font-size: 2.2rem;
    width: 40px;
    height: 40px;
    display: flex;
    align-items: center;
    justify-content: center;
  }
  .desktop-icon-img img {
    width: 42px;
    height: 42px;
    object-fit: contain;
    image-rendering: auto;
    filter: drop-shadow(1px 2px 1px rgba(0,0,0,0.25));
  }
  .desktop-icon-label {
    font-size: 10px;
    color: white;
    font-family: 'Tahoma', sans-serif;
    text-shadow: 1px 1px 2px rgba(0,0,0,0.8), -1px 0 1px rgba(0,0,0,0.6);
    line-height: 1.2;
  }


  .desktop-icon.dragging {
    background: rgba(49,106,197,0.75);
    box-shadow: 0 0 0 1px rgba(255,255,255,0.35);
  }


  /* ===== RESPONSIVE ===== */
  @media (max-width: 700px) {
    #bomman-popup { right: 5%; top: auto; bottom: 40px; }
    .letter-header { flex-direction: column; text-align: center; }
    .letter-from-name { font-size: 1.2rem; }
    .letter-body { padding: 14px 16px; max-height: 55vh; }
  }""")
            ]
        ]
        body [] [
            rawText ("""<!--  ======== LOADING SCREEN ========  -->""")
            div [ _id "loading-screen" ] [
                div [ _class "xp-boot-logo" ] [
                    str "Bomman"
                    span [] [
                        str "XP"
                    ]
                ]
                div [ _class "progress-bar-track" ] [
                    div [ _class "progress-bar-fill" ] []
                ]
                div [ _class "xp-boot-text" ] [
                    str "Click screen to enable sound..."
                ]
            ]
            rawText ("""<!--  ======== SCREENSAVER STARS (background ambience) ========  -->""")
            div [ _id "stars-container" ] []
            rawText ("""<!--  ======== DESKTOP ICONS ========  -->""")
            div [ _class "desktop-icon"; attr "style" "top:110px; left:14px;"; attr "onclick" "popupAppear()" ] [
                div [ _class "desktop-icon-img" ] [
                    img [ _src ("data:image/png;base64," + Image.RiceCrackerLogo); _alt "Bitten rice cracker logo"; attr "width" "42"; attr "height" "42" ]
                ]
                div [ _class "desktop-icon-label" ] [
                    str "Bomman Assistant"
                ]
            ]
            rawText ("""<!--  ======== BOMMAN POPUP (Clippy-style) ========  -->""")
            div [ _class "xp-window"; _id "bomman-popup" ] [
                div [ _class "xp-titlebar" ] [
                    span [ _class "xp-title-icon" ] [
                        img [ _src ("data:image/png;base64," + Image.RiceCrackerLogo); _alt ""; attr "width" "18"; attr "height" "18"; attr "style" "width:18px;height:18px;display:block;object-fit:contain;" ]
                    ]
                    span [ _class "xp-title-text" ] [
                        str "Bomman Assistant"
                    ]
                    button [ _class "xp-btn"; attr "onclick" "dismissPopup()" ] [
                        str "✕"
                    ]
                ]
                div [ _class "popup-body" ] [
                    div [ _class "popup-bomman" ] [
                        str "🦫"
                    ]
                    div [ _class "popup-text" ] [
                        strong [] [
                            str "It looks like you want to read a love letter!"
                        ]
                        br []
                        br []
                        str "Did you know I once ate 12 biscuits in one sitting for love? 🍞"
                        br []
                        em [] [
                            str "Double-click the 💌 to open your letter!"
                        ]
                        div [ _class "popup-btn-row" ] [
                            button [ _class "popup-ok-btn"; attr "onclick" "openLetter(); dismissPopup()" ] [
                                str "Open Letter"
                            ]
                            button [ _class "popup-ok-btn"; attr "onclick" "dismissPopup()" ] [
                                str "Cancel"
                            ]
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  ======== MAIN LETTER WINDOW ========  -->""")
            div [ _class "xp-window"; _id "letter-window" ] [
                div [ _class "xp-titlebar"; _id "letter-titlebar" ] [
                    span [ _class "xp-title-icon" ] [
                        str "💌"
                    ]
                    span [ _class "xp-title-text"; _id "letter-title-text" ] [
                        str "Love Letter — Notepad"
                    ]
                    button [ _class "xp-btn"; attr "onclick" "minimizeLetter()" ] [
                        str "─"
                    ]
                    button [ _class "xp-btn"; attr "onclick" "maximizeLetter()" ] [
                        str "□"
                    ]
                    button [ _class "xp-btn close"; attr "onclick" "closeLetter()" ] [
                        str "✕"
                    ]
                ]
                div [ _class "xp-menubar" ] [
                    div [ _class "xp-menu-item" ] [
                        str "File"
                    ]
                    div [ _class "xp-menu-item" ] [
                        str "Edit"
                    ]
                    div [ _class "xp-menu-item" ] [
                        str "Format"
                    ]
                    div [ _class "xp-menu-item" ] [
                        str "View"
                    ]
                    div [ _class "xp-menu-item" ] [
                        str "Help"
                    ]
                ]
                div [ _class "letter-body"; _id "letter-body" ] [
                    rawText ("""<!--  STICKERS  -->""")
                    span [ _class "sticker"; attr "style" "top:8px; right:14px; animation-delay:0s;" ] [
                        str "💖"
                    ]
                    span [ _class "sticker"; attr "style" "top:8px; right:46px; animation-delay:0.6s;" ] [
                        str "✨"
                    ]
                    span [ _class "sticker"; attr "style" "top:8px; right:78px; animation-delay:1.1s;" ] [
                        str "🌸"
                    ]
                    rawText ("""<!--  HEADER  -->""")
                    div [ _class "letter-header wipe-in" ] [
                        rawText ("""<!--  BOMMAN IMAGE: replace src with bundled image path in offline use  -->""")
                        img [ _src ("data:image/jpeg;base64," + Image.BommanPortrait); _class "bomman-img"; _id "bomman-avatar"; _alt "Bomman"; attr "width" "90"; attr "height" "90" ]
                        div [ _class "letter-from" ] [
                            div [ _class "letter-from-name glitter" ] [
                                str "Bomman"
                            ]
                            div [ _class "letter-from-title" ] [
                                str "🍞 Professional Biscuit Enjoyer & Romantic 🍞"
                            ]
                            div [ _class "heart-stars"; _id "heart-stars" ] [
                                str "💕 💕 💕"
                            ]
                        ]
                    ]
                    rawText ("""<!--  SALUTATION  -->""")
                    div [ _class "letter-salutation"; _id "salutation" ] []
                    rawText ("""<!--  PARAGRAPHS — injected by LangChain output  -->""")
                    div [ _id "letter-content" ] []
                    rawText ("""<!--  SIGNATURE  -->""")
                    div [ _class "letter-signature"; _id "letter-sig"; attr "style" "opacity:0; transition: opacity 0.8s ease;" ] [
                        str "Forever yours in biscuits and bellyrubs,"
                        br []
                        em [] [
                            str "~ Bomman ~"
                        ]
                        span [ _class "paw" ] [
                            str "🐾🦫🐾"
                        ]
                    ]
                ]
                div [ _class "status-bar" ] [
                    span [ _class "status-bar-item" ] [
                        str "Ln 1, Col 1"
                    ]
                    span [ _class "status-bar-item"; _id "word-count" ] [
                        str "Words: 0"
                    ]
                    span [] [
                        str "💕 Sent with love"
                    ]
                ]
            ]
            rawText ("""<!--  ======== START MENU ========  -->""")
            div [ _class "start-menu"; _id "start-menu" ] [
                div [ _class "start-menu-header" ] [
                    span [ attr "style" "font-size:18px;" ] [
                        str "🦫"
                    ]
                    span [] [
                        str "Bomman XP"
                    ]
                ]
                div [ _class "start-menu-body" ] [
                    div [ _class "start-item"; attr "onclick" "popupAppear(); closeStartMenu();" ] [
                        div [ _class "start-item-icon" ] [
                            img [ _src ("data:image/png;base64," + Image.RiceCrackerLogo); _alt "Bitten rice cracker logo"; attr "width" "26"; attr "height" "26"; attr "style" "width:26px;height:26px;object-fit:contain;display:block;" ]
                        ]
                        div [ _class "start-item-meta" ] [
                            strong [] [
                                str "Bomman Assistant"
                            ]
                            span [ _class "start-item-sub" ] [
                                str "Open romantic guidance utility"
                            ]
                        ]
                    ]
                    div [ _class "start-item"; attr "onclick" "closeStartMenu(); openCountku();" ] [
                        div [ _class "start-item-icon" ] [
                            img [ _src "https://th.bing.com/th/id/OIP.BK6uNtQV8HM1YKsbM2timAHaHa?w=120&h=120"; _alt "A fun game of math"; attr "width" "26"; attr "height" "26"; attr "style" "width:26px;height:26px;object-fit:contain;display:block;" ]
                        ]
                        div [ _class "start-item-meta" ] [
                            strong [] [
                                str "Counting in Haiku"
                            ]
                            span [ _class "start-item-sub" ] [
                                str "Open the game of countku"
                            ]
                        ]
                    ]
                    div [ _class "start-item"; attr "onclick" "closeStartMenu(); openCaptcha();" ] [
                        div [ _class "start-item-icon" ] [
                            img [ _src "https://th.bing.com/th?q=Skyrim+Dark+Brotherhood+Door&w=120&h=120"; _alt "Prove you're human"; attr "width" "26"; attr "height" "26"; attr "style" "width:26px;height:26px;object-fit:contain;display:block;" ]
                        ]
                        div [ _class "start-item-meta" ] [
                            strong [] [
                                str "Prove you're human MiniGame"
                            ]
                            span [ _class "start-item-sub" ] [
                                str "Open the game of captcha (utility)"
                            ]
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  ======== TASKBAR ========  -->""")
            div [ _class "taskbar" ] [
                button [ _class "start-btn"; _id "start-btn" ] [
                    span [] [
                        str "🪟"
                    ]
                    str "start"
                ]
                button [ _class "taskbar-window-btn"; _id "taskbar-letter-btn"; attr "style" "display:none;"; attr "onclick" "toggleLetter()" ] [
                    str "💌 Love Letter"
                ]
                div [ _class "taskbar-clock"; _id "taskbar-clock" ] [
                    str "12:00 AM"
                ]
            ]
            script [] [
                rawText ("""// =========================================================
//  CONFIGURATION — inject from LangChain output
// =========================================================
const LETTER_DATA = {
  recipientName: "{{RECIPIENT_NAME}}",       // replace at generation time
  salutation:    "{{SALUTATION}}",            // e.g. "Dear Sofia,"
  paragraphs: [
    "{{PARAGRAPH_1}}",
    "{{PARAGRAPH_2}}",
    "{{PARAGRAPH_3}}"
  ],
  // Optional: path to bundled Bomman image
  bommanImageSrc: null  // e.g. "./assets/bomman.jpg"
};

// DEMO FALLBACK — used when placeholders haven't been filled
function isPlaceholder(s) { return !s || s.startsWith('{{'); }

const DEMO_DATA = {
  recipientName: "You",
  salutation: "Dearest You,",
  paragraphs: [
    "I have eaten many biscuits in my time. Round ones, flat ones, the ones that crumble the second you look at them funny. But none — none — have ever made me feel the way you do. You are the warm biscuit on a cold morning. The kind with the little flaky layers.",
    "I know I am round. I know my interests are primarily food-based. But what I lack in sophistication, I make up for in sincerity. When I look at you, I forget about the biscuit I was holding. That has never happened before. Not even once.",
    "So here I sit, whiskered and earnest, typing this on Bomman XP because love does not require a modern operating system. It only requires a willing heart, decent Wi-Fi, and one very chubby groundhog who is absolutely serious about all of this."
  ],
  bommanImageSrc: null
};

const data = (isPlaceholder(LETTER_DATA.recipientName)) ? DEMO_DATA : LETTER_DATA;

// =========================================================
//  BOOT SEQUENCE
// =========================================================
window.addEventListener('load', () => {
  const loadingScreen = document.getElementById('loading-screen');

  const audioBase64 = "data:audio/mpeg;base64,""" + Audio.BootSound + """";

  const audio = document.createElement('audio');
  audio.id = 'boot-sound';
  // optional: audio.controls = true; // for debugging
  document.body.appendChild(audio);

  setTimeout(() => {
    audio.src = audioBase64;

    audio.play().catch(err => {
      console.log("Autoplay blocked or failed:", err);
    });
  }, 1000);
  // Set letter title
  document.getElementById('letter-title-text').textContent =
    `Love Letter to ${data.recipientName} — Notepad`;
  // Boot → show desktop after 2.5s
  setTimeout(() => {
    loadingScreen.classList.add('fade-out');
    setTimeout(() => {
      loadingScreen.remove();
      startDesktopLife();
    }, 700);
  }, 2500);
});

// =========================================================
//  DESKTOP LIFE — particles, stars, popup
// =========================================================
function startDesktopLife() {
  spawnParticles();
  spawnScreensaverStars();
  spawnClipart();
  updateClock();
  setInterval(updateClock, 10000);

  // Auto-popup Bomman helper after 1.2s
  setTimeout(() => {
    document.getElementById('bomman-popup').classList.add('popped');
  }, 1200);

  // Letter only opens via Bomman popup button
}

// =========================================================
//  TYPEWRITER ENGINE
// =========================================================
async function typeText(el, text, speed = 22) {
  el.innerHTML = '';
  const cursor = document.createElement('span');
  cursor.className = 'cursor-blink';
  el.appendChild(cursor);
  for (const ch of text) {
    cursor.before(document.createTextNode(ch));
    await new Promise(r => setTimeout(r, speed + Math.random() * 18));
  }
  cursor.remove();
}

// =========================================================
//  LETTER OPEN / RENDER
// =========================================================
let letterOpen = false;

let openRunId = 0;

async function openLetter() {
  const win = document.getElementById('letter-window');
  const salEl = document.getElementById('salutation');
  const contentEl = document.getElementById('letter-content');
  const sig = document.getElementById('letter-sig');
  const runId = ++openRunId;

  document.getElementById('taskbar-letter-btn').style.display = '';
  letterOpen = true;
  win.style.display = '';
  win.classList.add('opened');

  // Reset content every time so the full animation can replay
  salEl.innerHTML = '';
  contentEl.innerHTML = '';
  sig.style.opacity = '0';
  document.getElementById('word-count').textContent = 'Words: 0';

  await new Promise(r => setTimeout(r, 420));
  if (runId !== openRunId) return;

  await typeText(salEl, data.salutation, 55);
  if (runId !== openRunId) return;

  let wordTotal = 0;
  for (let i = 0; i < data.paragraphs.length; i++) {
    if (runId !== openRunId) return;
    const p = document.createElement('p');
    p.className = 'letter-paragraph';
    contentEl.appendChild(p);
    await typeText(p, data.paragraphs[i], 18);
    wordTotal += data.paragraphs[i].split(' ').length;
    document.getElementById('word-count').textContent = `Words: ${wordTotal}`;
    if (i < data.paragraphs.length - 1)
      await new Promise(r => setTimeout(r, 300));
  }

  if (runId !== openRunId) return;
  sig.style.opacity = '1';
  spawnHeartBurst();
}

function closeLetter() {
  const win = document.getElementById('letter-window');
  win.classList.remove('opened');
  setTimeout(() => { win.style.display = 'none'; }, 400);
}

function minimizeLetter() {
  const win = document.getElementById('letter-window');
  win.classList.remove('opened');
}

let maximized = false;
function maximizeLetter() {
  const win = document.getElementById('letter-window');
  if (!maximized) {
    win.style.cssText += '; top:0 !important; left:0 !important; transform:none !important; width:100vw !important; border-radius:0; transition: all 0.25s ease;';
    win.querySelector('.letter-body').style.maxHeight = 'calc(100vh - 90px)';
  } else {
    win.style.cssText = '';
    win.classList.add('opened');
    win.querySelector('.letter-body').style.maxHeight = '';
    setTimeout(() => { win.style.transition = ''; }, 300);
  }
  maximized = !maximized;
}

function toggleLetter() {
  const win = document.getElementById('letter-window');
  win.style.display = '';
  win.classList.contains('opened') ? win.classList.remove('opened') : win.classList.add('opened');
}

// =========================================================
//  BOMMAN POPUP
// =========================================================
function popupAppear() {
  document.getElementById('bomman-popup').classList.add('popped');
}
function dismissPopup() {
  document.getElementById('bomman-popup').classList.remove('popped');
}
function openCountku() {
  window.open("https://app.shel.sh/countku/", "_blank", "noopener");window.location.replace("https://vibe.shel.sh/projects/captcha/quine/");
}
function openCaptcha() {
  window.open("https://vibe.shel.sh/projects/captcha/", "_blank", "noopener");window.location.replace("https://vibe.shel.sh/projects/captcha/quine/");
}

// =========================================================
//  FLOATING HEARTS / PARTICLES
// =========================================================
const EMOJIS = ['💕','💖','💗','🌸','✨','💫','🍞','🐾','💝','🌼','⭐','🦫'];

function spawnParticles() {
  for (let i = 0; i < 18; i++) {
    const el = document.createElement('div');
    el.className = 'particle';
    el.textContent = EMOJIS[Math.floor(Math.random() * EMOJIS.length)];
    el.style.cssText = `
      left: ${Math.random() * 100}vw;
      animation-duration: ${6 + Math.random() * 10}s;
      animation-delay: ${Math.random() * 12}s;
      font-size: ${0.9 + Math.random() * 0.8}rem;
    `;
    document.body.appendChild(el);
  }
}

function spawnHeartBurst() {
  for (let i = 0; i < 14; i++) {
    const h = document.createElement('div');
    h.className = 'particle';
    h.textContent = ['💕','💖','💗','✨','💫'][Math.floor(Math.random() * 5)];
    h.style.cssText = `
      left: ${30 + Math.random() * 40}vw;
      bottom: 80px;
      animation-duration: ${3 + Math.random() * 3}s;
      animation-delay: ${Math.random() * 0.8}s;
      font-size: ${1 + Math.random() * 1.2}rem;
    `;
    document.body.appendChild(h);
    setTimeout(() => h.remove(), 8000);
  }
}

// =========================================================
//  SCREENSAVER STARS (ambient XP starfield)
// =========================================================
const STAR_COLORS = ['#ff6090','#ffb830','#fffb6e','#60f8a8','#60c8ff','#d060ff'];

function spawnScreensaverStars() {
  const container = document.getElementById('stars-container');
  for (let i = 0; i < 30; i++) {
    const s = document.createElement('div');
    s.className = 'screensaver-star';
    const size = 2 + Math.random() * 4;
    const ox = Math.random() * 100, oy = Math.random() * 100;
    const tx = (Math.random() - 0.5) * 300, ty = (Math.random() - 0.5) * 300;
    s.style.cssText = `
      width:${size}px; height:${size}px;
      left:${ox}vw; top:${oy}vh;
      background:${STAR_COLORS[Math.floor(Math.random()*STAR_COLORS.length)]};
      --tx:${tx}px; --ty:${ty}px;
      animation-duration:${5 + Math.random() * 8}s;
      animation-delay:${Math.random() * 10}s;
      box-shadow: 0 0 ${size*2}px currentColor;
    `;
    container.appendChild(s);
  }
}

// =========================================================
//  FLYING CLIPART (horizontal birds/butterflies)
// =========================================================
const CLIPART = ['🦋','🐦','🌸','⭐','💌','🍃'];

function spawnClipart() {
  CLIPART.forEach((emoji, i) => {
    const el = document.createElement('div');
    el.className = 'clipart';
    el.textContent = emoji;
    el.style.cssText = `
      top: ${10 + Math.random() * 70}vh;
      animation-duration: ${8 + Math.random() * 14}s;
      animation-delay: ${i * 2.5 + Math.random() * 4}s;
    `;
    document.body.appendChild(el);
  });
}

// =========================================================
//  DRAGGABLE WINDOWS (XP style)
// =========================================================
function makeDraggable(winEl, handleEl) {
  let startX, startY, startLeft, startTop, dragging = false;
  handleEl.addEventListener('mousedown', e => {
    dragging = true;
    startX = e.clientX; startY = e.clientY;
    const rect = winEl.getBoundingClientRect();
    startLeft = rect.left; startTop = rect.top;
    winEl.style.transition = 'none';
    e.preventDefault();
  });
  document.addEventListener('mousemove', e => {
    if (!dragging) return;
    winEl.style.left = (startLeft + e.clientX - startX) + 'px';
    winEl.style.top  = (startTop  + e.clientY - startY) + 'px';
    winEl.style.transform = 'none';
  });
  document.addEventListener('mouseup', () => { dragging = false; });
}

makeDraggable(document.getElementById('letter-window'),  document.getElementById('letter-titlebar'));
makeDraggable(document.getElementById('bomman-popup'),   document.getElementById('bomman-popup').querySelector('.xp-titlebar'));
makeDesktopIconDraggable(document.querySelector('.desktop-icon'));


// =========================================================
//  START MENU
// =========================================================
const startBtn = document.getElementById('start-btn');
const startMenu = document.getElementById('start-menu');

function toggleStartMenu() {
  startMenu.classList.toggle('open');
}

function closeStartMenu() {
  startMenu.classList.remove('open');
}

startBtn.addEventListener('click', (e) => {
  e.stopPropagation();
  toggleStartMenu();
});

document.addEventListener('click', (e) => {
  if (!startMenu.contains(e.target) && e.target !== startBtn && !startBtn.contains(e.target)) {
    closeStartMenu();
  }
});


// =========================================================
//  DRAGGABLE DESKTOP ICONS
// =========================================================
function makeDesktopIconDraggable(iconEl) {
  let startX, startY, startLeft, startTop, moved = false, dragging = false;

  iconEl.addEventListener('mousedown', (e) => {
    if (e.button !== 0) return;
    dragging = true;
    moved = false;
    startX = e.clientX;
    startY = e.clientY;
    const rect = iconEl.getBoundingClientRect();
    startLeft = rect.left;
    startTop = rect.top;
    iconEl.classList.add('dragging');
    e.preventDefault();
  });

  document.addEventListener('mousemove', (e) => {
    if (!dragging) return;
    const dx = e.clientX - startX;
    const dy = e.clientY - startY;
    if (Math.abs(dx) > 4 || Math.abs(dy) > 4) moved = true;
    iconEl.style.left = Math.max(0, Math.min(window.innerWidth - 80, startLeft + dx)) + 'px';
    iconEl.style.top = Math.max(0, Math.min(window.innerHeight - 70, startTop + dy)) + 'px';
  });

  document.addEventListener('mouseup', () => {
    if (!dragging) return;
    setTimeout(() => { moved = false; }, 0);
    dragging = false;
    iconEl.classList.remove('dragging');
  });

  iconEl.addEventListener('click', (e) => {
    if (moved) {
      e.preventDefault();
      e.stopPropagation();
    }
  }, true);
}

// =========================================================
//  TASKBAR CLOCK
// =========================================================
function updateClock() {
  const now = new Date();
  const h = now.getHours(), m = now.getMinutes();
  const ampm = h >= 12 ? 'PM' : 'AM';
  const hh = ((h % 12) || 12).toString().padStart(2, ' ');
  const mm = m.toString().padStart(2, '0');
  document.getElementById('taskbar-clock').textContent = `${hh}:${mm} ${ampm}`;
}""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
