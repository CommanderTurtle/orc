module ConvertedFiles.WtgPpt.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Presentation"
            ]
            link [ attr "rel" "preconnect"; _href "https://fonts.googleapis.com" ]
            link [ attr "rel" "preconnect"; _href "https://fonts.gstatic.com"; attr "crossorigin" "" ]
            link [ _href "https://fonts.googleapis.com/css2?family=Instrument+Serif&family=DM+Sans:wght@400;500;600;700&display=swap"; attr "rel" "stylesheet" ]
            style [] [
                    rawText ("""/* ===== Reset & Base ===== */
    *, *::before, *::after {
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }

    :root {
      --brand-green: #3C8220;
      --dark-text: #2E2E2E;
      --light-bg: #F8F8F5;
      --medium-bg: #ECECE8;
      --accent-line: rgba(60, 130, 32, 0.35);
      --white: #FFFFFF;
      --radius: 0.5rem;
    }

    html {
      scroll-behavior: smooth;
    }

    body {
      font-family: 'DM Sans', sans-serif;
      color: var(--dark-text);
      background-color: var(--light-bg);
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      line-height: 1.6;
    }

    /* ===== Typography ===== */
    .font-display {
      font-family: 'Instrument Serif', serif;
    }

    /* ===== Layout ===== */
    .container {
      max-width: 1200px;
      margin: 0 auto;
      padding: 0 24px;
    }

    /* ===== Navbar ===== */
    .navbar {
      position: sticky;
      top: 0;
      background: var(--white);
      border-bottom: 1px solid var(--medium-bg);
      padding: 0;
      z-index: 100;
      backdrop-filter: blur(12px);
      background-color: rgba(255, 255, 255, 0.95);
    }

    .navbar-inner {
      display: flex;
      align-items: center;
      justify-content: space-between;
      height: 64px;
    }

    .navbar-brand {
      display: flex;
      align-items: center;
      gap: 12px;
      text-decoration: none;
      color: var(--dark-text);
    }

    .navbar-brand-icon {
      width: 36px;
      height: 36px;
      background: var(--brand-green);
      border-radius: 8px;
      display: flex;
      align-items: center;
      justify-content: center;
    }

    .navbar-brand-icon svg {
      width: 20px;
      height: 20px;
      fill: none;
      stroke: white;
      stroke-width: 2;
      stroke-linecap: round;
      stroke-linejoin: round;
    }

    .navbar-brand-text {
      font-family: 'Instrument Serif', serif;
      font-size: 22px;
      font-weight: 400;
      letter-spacing: -0.02em;
    }

    .navbar-brand-text span {
      color: var(--brand-green);
    }

    .navbar-nav {
      display: flex;
      align-items: center;
      gap: 6px;
      list-style: none;
    }

    .navbar-nav a {
      display: block;
      padding: 8px 16px;
      font-size: 14px;
      font-weight: 500;
      color: var(--dark-text);
      text-decoration: none;
      border-radius: 6px;
      transition: all 200ms ease;
    }

    .navbar-nav a:hover {
      background: var(--light-bg);
      color: var(--brand-green);
    }

    .navbar-nav a.active {
      color: var(--brand-green);
      background: rgba(60, 130, 32, 0.08);
    }

    /* Mobile menu toggle */
    .navbar-toggle {
      display: none;
      width: 40px;
      height: 40px;
      border: none;
      background: transparent;
      cursor: pointer;
      border-radius: 6px;
      align-items: center;
      justify-content: center;
      flex-direction: column;
      gap: 5px;
    }

    .navbar-toggle span {
      display: block;
      width: 22px;
      height: 2px;
      background: var(--dark-text);
      border-radius: 2px;
      transition: all 250ms ease;
    }

    .navbar-toggle[aria-expanded="true"] span:nth-child(1) {
      transform: rotate(45deg) translate(5px, 5px);
    }

    .navbar-toggle[aria-expanded="true"] span:nth-child(2) {
      opacity: 0;
    }

    .navbar-toggle[aria-expanded="true"] span:nth-child(3) {
      transform: rotate(-45deg) translate(5px, -5px);
    }

    /* ===== Hero Section ===== */
    .hero {
      padding: 80px 0 60px;
      text-align: center;
      background: var(--white);
      border-bottom: 1px solid var(--medium-bg);
    }

    .hero-label {
      display: inline-flex;
      align-items: center;
      gap: 8px;
      padding: 6px 16px;
      background: rgba(60, 130, 32, 0.08);
      border: 1px solid rgba(60, 130, 32, 0.15);
      border-radius: 100px;
      font-size: 12px;
      font-weight: 600;
      letter-spacing: 0.08em;
      text-transform: uppercase;
      color: var(--brand-green);
      margin-bottom: 28px;
    }

    .hero-label-dot {
      width: 6px;
      height: 6px;
      background: var(--brand-green);
      border-radius: 50%;
    }

    .hero-title {
      font-family: 'Instrument Serif', serif;
      font-size: clamp(36px, 6vw, 64px);
      font-weight: 400;
      line-height: 1.1;
      color: var(--dark-text);
      margin-bottom: 20px;
      letter-spacing: -0.02em;
    }

    .hero-title em {
      color: var(--brand-green);
      font-style: italic;
    }

    .hero-subtitle {
      font-size: clamp(16px, 2vw, 20px);
      font-weight: 400;
      color: rgba(46, 46, 46, 0.65);
      max-width: 560px;
      margin: 0 auto 40px;
      line-height: 1.6;
    }

    .hero-actions {
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 16px;
      flex-wrap: wrap;
    }

    /* ===== Buttons ===== */
    .btn {
      display: inline-flex;
      align-items: center;
      gap: 8px;
      border: 1.5px solid var(--brand-green);
      border-radius: 8px;
      padding: 14px 32px;
      font-family: 'DM Sans', sans-serif;
      font-size: 14px;
      font-weight: 600;
      letter-spacing: 0.04em;
      color: var(--brand-green);
      text-decoration: none;
      transition: all 250ms ease-out;
      background: transparent;
      cursor: pointer;
      white-space: nowrap;
    }

    .btn:hover {
      background-color: var(--brand-green);
      color: white;
      transform: translateY(-1px);
      box-shadow: 0 4px 16px rgba(60, 130, 32, 0.25);
    }

    .btn-primary {
      background-color: var(--brand-green);
      color: white;
    }

    .btn-primary:hover {
      background-color: #327a1a;
      border-color: #327a1a;
    }

    .btn-ghost {
      border-color: var(--medium-bg);
      color: var(--dark-text);
    }

    .btn-ghost:hover {
      background-color: var(--dark-text);
      border-color: var(--dark-text);
      color: white;
    }

    .btn svg {
      width: 16px;
      height: 16px;
      fill: none;
      stroke: currentColor;
      stroke-width: 2;
      stroke-linecap: round;
      stroke-linejoin: round;
      flex-shrink: 0;
    }

    /* ===== PDF Viewer Section ===== */
    .viewer-section {
      padding: 48px 0 80px;
    }

    .viewer-header {
      display: flex;
      align-items: center;
      justify-content: space-between;
      margin-bottom: 20px;
      flex-wrap: wrap;
      gap: 16px;
    }

    .viewer-title {
      font-family: 'Instrument Serif', serif;
      font-size: 28px;
      font-weight: 400;
      color: var(--dark-text);
    }

    .viewer-meta {
      display: flex;
      align-items: center;
      gap: 16px;
      font-size: 14px;
      color: rgba(46, 46, 46, 0.55);
    }

    .viewer-meta-item {
      display: flex;
      align-items: center;
      gap: 6px;
    }

    .viewer-meta-item svg {
      width: 16px;
      height: 16px;
      fill: none;
      stroke: currentColor;
      stroke-width: 2;
      stroke-linecap: round;
      stroke-linejoin: round;
    }

    .pdf-container {
      position: relative;
      width: 100%;
      height: 80vh;
      min-height: 500px;
      background: var(--white);
      border-radius: 12px;
      border: 1px solid var(--medium-bg);
      overflow: hidden;
      box-shadow: 0 4px 24px rgba(0, 0, 0, 0.04);
      transition: box-shadow 300ms ease;
    }

    .pdf-container:hover {
      box-shadow: 0 8px 40px rgba(0, 0, 0, 0.08);
    }

    .pdf-frame {
      width: 100%;
      height: 100%;
      border: none;
      display: block;
    }

    /* Expand toggle */
    .viewer-toolbar {
      display: flex;
      align-items: center;
      justify-content: space-between;
      margin-top: 16px;
      flex-wrap: wrap;
      gap: 12px;
    }

    .viewer-hint {
      font-size: 13px;
      color: rgba(46, 46, 46, 0.45);
      display: flex;
      align-items: center;
      gap: 6px;
    }

    .viewer-hint svg {
      width: 14px;
      height: 14px;
      fill: none;
      stroke: currentColor;
      stroke-width: 2;
      stroke-linecap: round;
      stroke-linejoin: round;
    }

    /* ===== Expand State ===== */
    .pdf-container.is-expanded {
      position: fixed;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0;
      height: 100vh;
      z-index: 200;
      border-radius: 0;
      border: none;
    }

    .pdf-exit-fullscreen {
      display: none;
      position: fixed;
      top: 16px;
      right: 16px;
      z-index: 201;
      background: var(--dark-text);
      color: white;
      border: none;
      border-radius: 8px;
      padding: 10px 18px;
      font-family: 'DM Sans', sans-serif;
      font-size: 13px;
      font-weight: 600;
      cursor: pointer;
      align-items: center;
      gap: 6px;
      box-shadow: 0 4px 16px rgba(0, 0, 0, 0.2);
    }

    .pdf-exit-fullscreen svg {
      width: 14px;
      height: 14px;
      fill: none;
      stroke: currentColor;
      stroke-width: 2;
      stroke-linecap: round;
      stroke-linejoin: round;
    }

    .pdf-container.is-expanded + .viewer-toolbar .pdf-exit-fullscreen-btn {
      display: none;
    }

    /* ===== Features Section ===== */
    .features {
      padding: 80px 0;
      background: var(--white);
      border-top: 1px solid var(--medium-bg);
    }

    .section-header {
      text-align: center;
      margin-bottom: 56px;
    }

    .section-header-label {
      display: inline-flex;
      align-items: center;
      gap: 8px;
      font-size: 12px;
      font-weight: 600;
      letter-spacing: 0.1em;
      text-transform: uppercase;
      color: var(--brand-green);
      margin-bottom: 16px;
    }

    .section-header-label::before {
      content: '';
      display: block;
      width: 24px;
      height: 1px;
      background: var(--accent-line);
    }

    .section-header-label::after {
      content: '';
      display: block;
      width: 24px;
      height: 1px;
      background: var(--accent-line);
    }

    .section-header-title {
      font-family: 'Instrument Serif', serif;
      font-size: clamp(28px, 4vw, 42px);
      font-weight: 400;
      color: var(--dark-text);
      margin-bottom: 12px;
    }

    .section-header-subtitle {
      font-size: 17px;
      color: rgba(46, 46, 46, 0.55);
      max-width: 480px;
      margin: 0 auto;
    }

    .features-grid {
      display: grid;
      grid-template-columns: repeat(auto-fit, minmax(260px, 1fr));
      gap: 20px;
    }

    .feature-card {
      background: var(--light-bg);
      border-radius: 12px;
      padding: 36px 32px;
      transition: transform 300ms ease-out, box-shadow 300ms ease-out;
      border: 1px solid var(--medium-bg);
    }

    .feature-card:hover {
      transform: translateY(-3px);
      box-shadow: 0 12px 40px rgba(0, 0, 0, 0.06);
      border-color: rgba(60, 130, 32, 0.15);
    }

    .feature-icon {
      width: 44px;
      height: 44px;
      background: rgba(60, 130, 32, 0.08);
      border-radius: 10px;
      display: flex;
      align-items: center;
      justify-content: center;
      margin-bottom: 20px;
    }

    .feature-icon svg {
      width: 22px;
      height: 22px;
      fill: none;
      stroke: var(--brand-green);
      stroke-width: 1.8;
      stroke-linecap: round;
      stroke-linejoin: round;
    }

    .feature-title {
      font-size: 16px;
      font-weight: 600;
      color: var(--dark-text);
      margin-bottom: 8px;
    }

    .feature-text {
      font-size: 14px;
      color: rgba(46, 46, 46, 0.6);
      line-height: 1.6;
    }

    /* ===== How It Works ===== */
    .how-it-works {
      padding: 80px 0;
      background: var(--light-bg);
    }

    .steps {
      display: grid;
      grid-template-columns: repeat(auto-fit, minmax(220px, 1fr));
      gap: 24px;
      margin-top: 48px;
    }

    .step {
      position: relative;
      text-align: center;
      padding: 0 16px;
    }

    .step-number {
      width: 48px;
      height: 48px;
      background: var(--brand-green);
      color: white;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      font-family: 'Instrument Serif', serif;
      font-size: 22px;
      margin: 0 auto 20px;
    }

    .step-title {
      font-size: 15px;
      font-weight: 600;
      color: var(--dark-text);
      margin-bottom: 8px;
    }

    .step-text {
      font-size: 14px;
      color: rgba(46, 46, 46, 0.55);
      line-height: 1.5;
    }

    .step-connector {
      display: none;
    }

    /* ===== CTA Section ===== */
    .cta-section {
      padding: 100px 0;
      background: var(--white);
      border-top: 1px solid var(--medium-bg);
      text-align: center;
    }

    .cta-box {
      max-width: 640px;
      margin: 0 auto;
      padding: 64px 48px;
      background: var(--light-bg);
      border-radius: 16px;
      border: 1px solid var(--medium-bg);
    }

    .cta-box-icon {
      width: 56px;
      height: 56px;
      background: rgba(60, 130, 32, 0.08);
      border-radius: 14px;
      display: flex;
      align-items: center;
      justify-content: center;
      margin: 0 auto 24px;
    }

    .cta-box-icon svg {
      width: 28px;
      height: 28px;
      fill: none;
      stroke: var(--brand-green);
      stroke-width: 1.5;
      stroke-linecap: round;
      stroke-linejoin: round;
    }

    .cta-box-title {
      font-family: 'Instrument Serif', serif;
      font-size: 32px;
      font-weight: 400;
      color: var(--dark-text);
      margin-bottom: 12px;
    }

    .cta-box-text {
      font-size: 16px;
      color: rgba(46, 46, 46, 0.55);
      margin-bottom: 32px;
      line-height: 1.6;
    }

    /* ===== Footer ===== */
    .footer {
      padding: 48px 0;
      background: var(--white);
      border-top: 1px solid var(--medium-bg);
    }

    .footer-inner {
      display: flex;
      align-items: center;
      justify-content: space-between;
      flex-wrap: wrap;
      gap: 16px;
    }

    .footer-brand {
      display: flex;
      align-items: center;
      gap: 10px;
      font-family: 'Instrument Serif', serif;
      font-size: 18px;
      color: var(--dark-text);
    }

    .footer-brand svg {
      width: 18px;
      height: 18px;
      fill: none;
      stroke: var(--brand-green);
      stroke-width: 2;
      stroke-linecap: round;
      stroke-linejoin: round;
    }

    .footer-copy {
      font-size: 13px;
      color: rgba(46, 46, 46, 0.4);
    }

    /* ===== Section Reveal Animations ===== */
    .reveal {
      opacity: 0;
      transform: translateY(30px);
      transition: opacity 700ms cubic-bezier(0.215, 0.61, 0.355, 1),
                  transform 700ms cubic-bezier(0.215, 0.61, 0.355, 1);
    }

    .reveal.visible {
      opacity: 1;
      transform: translateY(0);
    }

    .reveal-left {
      opacity: 0;
      transform: translateX(-20px);
      transition: opacity 700ms cubic-bezier(0.215, 0.61, 0.355, 1),
                  transform 700ms cubic-bezier(0.215, 0.61, 0.355, 1);
    }

    .reveal-left.visible {
      opacity: 1;
      transform: translateX(0);
    }

    .stagger-1 { transition-delay: 80ms; }
    .stagger-2 { transition-delay: 160ms; }
    .stagger-3 { transition-delay: 240ms; }
    .stagger-4 { transition-delay: 320ms; }
    .stagger-5 { transition-delay: 400ms; }
    .stagger-6 { transition-delay: 480ms; }

    /* ===== Responsive ===== */
    @media (max-width: 768px) {
      .navbar-toggle {
        display: flex;
      }

      .navbar-nav {
        position: absolute;
        top: 64px;
        left: 0;
        right: 0;
        background: var(--white);
        border-bottom: 1px solid var(--medium-bg);
        flex-direction: column;
        align-items: stretch;
        padding: 12px 24px;
        gap: 4px;
        opacity: 0;
        visibility: hidden;
        transform: translateY(-8px);
        transition: all 250ms ease;
      }

      .navbar-nav.is-open {
        opacity: 1;
        visibility: visible;
        transform: translateY(0);
      }

      .navbar-nav a {
        padding: 12px 16px;
      }

      .hero {
        padding: 56px 0 40px;
      }

      .hero-actions {
        flex-direction: column;
        align-items: stretch;
      }

      .hero-actions .btn {
        justify-content: center;
      }

      .viewer-section {
        padding: 32px 0 56px;
      }

      .viewer-header {
        flex-direction: column;
        align-items: flex-start;
      }

      .pdf-container {
        height: 70vh;
        min-height: 400px;
      }

      .features {
        padding: 56px 0;
      }

      .features-grid {
        grid-template-columns: 1fr;
      }

      .how-it-works {
        padding: 56px 0;
      }

      .steps {
        grid-template-columns: 1fr;
        gap: 36px;
      }

      .cta-section {
        padding: 64px 0;
      }

      .cta-box {
        padding: 40px 28px;
      }

      .cta-box-title {
        font-size: 26px;
      }

      .footer-inner {
        flex-direction: column;
        text-align: center;
      }
    }

    @media (prefers-reduced-motion: reduce) {
      .reveal, .reveal-left {
        opacity: 1;
        transform: none;
        transition: none;
      }

      html {
        scroll-behavior: auto;
      }
    }""")
            ]
        ]
        body [] [
            rawText ("""<!--  Navbar  -->""")
            nav [ _class "navbar" ] [
                div [ _class "container navbar-inner" ] [
                    a [ _href "#"; _class "navbar-brand" ] [
                        div [ _class "navbar-brand-icon" ] [
                            tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                voidTag "path" [ attr "d" "M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z" ]
                                voidTag "polyline" [ attr "points" "14 2 14 8 20 8" ]
                                voidTag "line" [ attr "x1" "16"; attr "y1" "13"; attr "x2" "8"; attr "y2" "13" ]
                                voidTag "line" [ attr "x1" "16"; attr "y1" "17"; attr "x2" "8"; attr "y2" "17" ]
                                voidTag "polyline" [ attr "points" "10 9 9 9 8 9" ]
                            ]
                        ]
                        span [ _class "navbar-brand-text" ] [
                            str "WTG"
                            span [] [
                                str "Safety"
                            ]
                        ]
                    ]
                    button [ _class "navbar-toggle"; _id "navToggle"; attr "aria-expanded" "false"; attr "aria-label" "Toggle navigation" ] [
                        span [] []
                        span [] []
                        span [] []
                    ]
                    ul [ _class "navbar-nav"; _id "navMenu" ] [
                        li [] [
                            a [ _href "https://providers.shel.sh/wtg/#/dasform"; _class "active" ] [
                                str "Submit Inquiry"
                            ]
                        ]
                        li [] [
                            a [ _href "https://providers.shel.sh/wtg/" ] [
                                str "Home"
                            ]
                        ]
                        li [] [
                            a [ _href "https://nextivityinc.com/" ] [
                                str "Nextivity"
                            ]
                        ]
                        li [] [
                            a [ _href "https://providers.shel.sh/wtg-ppt/" ] [
                                str "About"
                            ]
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  Hero  -->""")
            header [ _class "hero" ] [
                div [ _class "container" ] [
                    div [ _class "reveal" ] [
                        div [ _class "hero-label" ] [
                            span [ _class "hero-label-dot" ] []
                            str "Standalone Presentation Viewer"
                        ]
                    ]
                    h1 [ _class "hero-title reveal stagger-1" ] [
                        str "Gain confidence in"
                        em [] [
                            str "safety"
                        ]
                        str "and insurability."
                    ]
                    p [ _class "hero-subtitle reveal stagger-2" ] [
                        str "View the powerpoint below to learn more about how a Distributed Antenna System (DAS) solution could be the right fit for your company."
                    ]
                    div [ _class "hero-actions reveal stagger-3" ] [
                        a [ _href "#viewer"; _class "btn btn-primary" ] [
                            tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                voidTag "path" [ attr "d" "M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z" ]
                                voidTag "circle" [ attr "cx" "12"; attr "cy" "12"; attr "r" "3" ]
                            ]
                            str "View Full PPTX"
                        ]
                        a [ _href "#features"; _class "btn btn-ghost" ] [
                            str "Learn More"
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  PDF Viewer  -->""")
            section [ _class "viewer-section"; _id "viewer" ] [
                div [ _class "container" ] [
                    div [ _class "viewer-header reveal" ] [
                        h2 [ _class "viewer-title" ] [
                            str "Document Preview"
                        ]
                        div [ _class "viewer-meta" ] [
                            span [ _class "viewer-meta-item" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                    voidTag "path" [ attr "d" "M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z" ]
                                    voidTag "polyline" [ attr "points" "14 2 14 8 20 8" ]
                                ]
                                str "PPTX Document"
                            ]
                            span [ _class "viewer-meta-item" ] [
                                tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                    voidTag "circle" [ attr "cx" "12"; attr "cy" "12"; attr "r" "10" ]
                                    voidTag "polyline" [ attr "points" "12 6 12 12 16 14" ]
                                ]
                                str "Updated just now"
                            ]
                        ]
                    ]
                    div [ _class "pdf-container reveal stagger-1"; _id "pdfContainer" ] [
                        iframe [ _src ("data:application/pdf;base64," + Application.WorkTogetherPresentation); _class "pdf-frame"; attr "title" "Powerpoint Viewer"; attr "loading" "lazy" ] []
                    ]
                    div [ _class "viewer-toolbar reveal stagger-2" ] [
                        span [ _class "viewer-hint" ] [
                            tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                voidTag "circle" [ attr "cx" "12"; attr "cy" "12"; attr "r" "10" ]
                                voidTag "line" [ attr "x1" "12"; attr "y1" "16"; attr "x2" "12"; attr "y2" "12" ]
                                voidTag "line" [ attr "x1" "12"; attr "y1" "8"; attr "x2" "12.01"; attr "y2" "8" ]
                            ]
                            str "PowerPoint by Wilson Technology Group. Based on data from the State of Florida."
                        ]
                        button [ _class "btn pdf-exit-fullscreen-btn"; _id "expandBtn" ] [
                            tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                                voidTag "path" [ attr "d" "M8 3H5a2 2 0 0 0-2 2v3m18 0V5a2 2 0 0 0-2-2h-3m0 18h3a2 2 0 0 0 2-2v-3M3 16v3a2 2 0 0 0 2 2h3" ]
                            ]
                            str "Fullscreen"
                        ]
                    ]
                ]
            ]
            button [ _class "pdf-exit-fullscreen"; _id "exitFullscreenBtn"; attr "style" "display:none;" ] [
                tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                    voidTag "path" [ attr "d" "M8 3v3a2 2 0 0 1-2 2H3m18 0h-3a2 2 0 0 1-2-2V3m0 18v-3a2 2 0 0 1 2-2h3M3 16h3a2 2 0 0 1 2 2v3" ]
                ]
                str "Exit Fullscreen"
            ]
            rawText ("""<!--  Footer  -->""")
            footer [ _class "footer" ] [
                div [ _class "container footer-inner" ] [
                    div [ _class "footer-brand" ] [
                        tag "svg" [ attr "viewBox" "0 0 24 24" ] [
                            voidTag "path" [ attr "d" "M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z" ]
                            voidTag "polyline" [ attr "points" "14 2 14 8 20 8" ]
                            voidTag "polyline" [ attr "points" "10 9 9 9 8 9" ]
                            voidTag "line" [ attr "x1" "16"; attr "y1" "13"; attr "x2" "8"; attr "y2" "13" ]
                            voidTag "line" [ attr "x1" "16"; attr "y1" "17"; attr "x2" "8"; attr "y2" "17" ]
                        ]
                        str "PPTXView"
                    ]
                    p [ _class "footer-copy" ] []
                ]
            ]
            script [] [
                    rawText ("""// ===== Section Reveal on Scroll =====
    const revealElements = document.querySelectorAll('.reveal, .reveal-left');
    const revealObserver = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          entry.target.classList.add('visible');
          revealObserver.unobserve(entry.target);
        }
      });
    }, {
      threshold: 0.1,
      rootMargin: '0px 0px -40px 0px'
    });
    revealElements.forEach(el => revealObserver.observe(el));

    // ===== Mobile Nav Toggle =====
    const navToggle = document.getElementById('navToggle');
    const navMenu = document.getElementById('navMenu');
    navToggle.addEventListener('click', () => {
      const isOpen = navToggle.getAttribute('aria-expanded') === 'true';
      navToggle.setAttribute('aria-expanded', !isOpen);
      navMenu.classList.toggle('is-open');
    });

    // Close mobile menu when clicking a link
    navMenu.querySelectorAll('a').forEach(link => {
      link.addEventListener('click', () => {
        navToggle.setAttribute('aria-expanded', 'false');
        navMenu.classList.remove('is-open');
      });
    });

    // ===== Active Nav Link on Scroll =====
    const sections = document.querySelectorAll('section[id], header[id]');
    const navLinks = document.querySelectorAll('.navbar-nav a');
    const scrollSpyObserver = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          navLinks.forEach(link => {
            link.classList.toggle('active', link.getAttribute('href') === '#' + entry.target.id);
          });
        }
      });
    }, { threshold: 0.3, rootMargin: '-64px 0px 0px 0px' });
    sections.forEach(section => scrollSpyObserver.observe(section));

    // ===== Fullscreen Expand =====
    const pdfContainer = document.getElementById('pdfContainer');
    const expandBtn = document.getElementById('expandBtn');
    const exitBtn = document.getElementById('exitFullscreenBtn');

    expandBtn.addEventListener('click', () => {
      pdfContainer.classList.add('is-expanded');
      exitBtn.style.display = 'inline-flex';
    });

    exitBtn.addEventListener('click', () => {
      pdfContainer.classList.remove('is-expanded');
      exitBtn.style.display = 'none';
    });

    // Exit fullscreen on Escape key
    document.addEventListener('keydown', (e) => {
      if (e.key === 'Escape' && pdfContainer.classList.contains('is-expanded')) {
        pdfContainer.classList.remove('is-expanded');
        exitBtn.style.display = 'none';
      }
    });""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
