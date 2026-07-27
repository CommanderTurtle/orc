module ConvertedFiles.Loosescrew.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Loose Screw LLC | Client Portal"
            ]
            rawText ("""<!--  Google Fonts  -->""")
            link [ _href "https://fonts.googleapis.com/css2?family=Inter:wght@300;400;600;800&family=Poppins:wght@500;700&display=swap"; attr "rel" "stylesheet" ]
            rawText ("""<!--  Font Awesome  -->""")
            link [ attr "rel" "stylesheet"; _href "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" ]
            rawText ("""<!--  Chart.js  -->""")
            script [ _src "https://cdn.jsdelivr.net/npm/chart.js" ] [ rawText ("""""") ]
            style [] [
                    rawText (""":root {
            --bg-dark: #0f172a;
            --bg-panel: #1e293b;
            --bg-card: #334155;
            --primary: #f59e0b; /* Amber */
            --primary-hover: #d97706;
            --text-main: #f8fafc;
            --text-muted: #94a3b8;
            --accent-blue: #38bdf8;
            --accent-green: #10b981;
            --accent-red: #ef4444;
            --font-main: 'Inter', sans-serif;
            --font-head: 'Poppins', sans-serif;
            --transition: all 0.3s ease;
        }

        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            background-color: var(--bg-dark);
            color: var(--text-main);
            font-family: var(--font-main);
            overflow-x: hidden;
            display: flex;
            min-height: 100vh;
        }

        /* Canvas Overlay */
        #hoseCanvas {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            pointer-events: none;
            z-index: 9999;
        }

        /* Login Overlay */
        .login-overlay {
            position: fixed;
            top: 0; left: 0; width: 100%; height: 100%;
            background: rgba(15, 23, 42, 0.95);
            backdrop-filter: blur(10px);
            display: flex;
            align-items: center;
            justify-content: center;
            z-index: 10005;
            transition: opacity 0.5s ease;
        }

        .login-bubble {
            background: var(--bg-panel);
            padding: 3rem;
            border-radius: 24px;
            box-shadow: 0 25px 50px -12px rgba(0, 0, 0, 0.5);
            text-align: center;
            border: 1px solid rgba(255, 255, 255, 0.1);
            max-width: 400px;
            width: 90%;
            transform: translateY(0);
            animation: float 6s ease-in-out infinite;
        }

        @keyframes float {
            0% { transform: translateY(0px); }
            50% { transform: translateY(-10px); }
            100% { transform: translateY(0px); }
        }

        .login-bubble h2 {
            font-family: var(--font-head);
            margin-bottom: 1.5rem;
            font-size: 1.25rem;
            color: var(--primary);
        }

        .login-bubble input {
            width: 100%;
            padding: 1rem;
            border-radius: 12px;
            border: 2px solid rgba(255, 255, 255, 0.1);
            background: var(--bg-dark);
            color: var(--text-main);
            font-family: var(--font-main);
            font-size: 1rem;
            margin-bottom: 1.5rem;
            outline: none;
            transition: var(--transition);
        }

        .login-bubble input:focus {
            border-color: var(--primary);
            box-shadow: 0 0 15px rgba(245, 158, 11, 0.2);
        }

        .login-bubble button {
            background: var(--primary);
            color: #0f172a;
            border: none;
            padding: 1rem 2rem;
            border-radius: 12px;
            font-weight: 700;
            font-size: 1rem;
            cursor: pointer;
            width: 100%;
            transition: var(--transition);
        }

        .login-bubble button:hover {
            background: var(--primary-hover);
            transform: scale(1.02);
        }

        /* App Container */
        #app-container {
            display: none;
            width: 100%;
            min-height: 100vh;
        }

        /* Layout */
        .sidebar {
            width: 280px;
            background-color: var(--bg-panel);
            padding: 2rem 1.5rem;
            display: flex;
            flex-direction: column;
            border-right: 1px solid rgba(255, 255, 255, 0.05);
            position: fixed;
            height: 100vh;
            z-index: 10;
        }

        .main-content {
            flex: 1;
            margin-left: 280px;
            padding: 2.5rem 4rem;
            position: relative;
            z-index: 5;
            max-width: 1400px;
        }

        /* Sidebar Styling */
        .brand {
            display: flex;
            align-items: center;
            gap: 15px;
            margin-bottom: 3rem;
        }

        .brand-icon {
            background: linear-gradient(135deg, var(--primary), #fbbf24);
            color: #000;
            width: 45px;
            height: 45px;
            border-radius: 12px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 1.5rem;
            box-shadow: 0 4px 15px rgba(245, 158, 11, 0.3);
            animation: pulse-glow 2s infinite alternate;
        }

        @keyframes pulse-glow {
            from { box-shadow: 0 4px 15px rgba(245, 158, 11, 0.2); }
            to { box-shadow: 0 4px 25px rgba(245, 158, 11, 0.6); }
        }

        .brand-text h1 {
            font-family: var(--font-head);
            font-size: 1.25rem;
            font-weight: 700;
            letter-spacing: 0.5px;
        }

        .brand-text p {
            font-size: 0.75rem;
            color: var(--text-muted);
            text-transform: uppercase;
            letter-spacing: 1px;
        }

        .nav-links {
            list-style: none;
            display: flex;
            flex-direction: column;
            gap: 0.5rem;
        }

        .nav-item {
            padding: 1rem 1.25rem;
            border-radius: 10px;
            cursor: pointer;
            transition: var(--transition);
            display: flex;
            align-items: center;
            gap: 15px;
            color: var(--text-muted);
            font-weight: 600;
            font-size: 0.95rem;
            text-decoration: none;
        }

        .nav-item:hover, .nav-item.active {
            background-color: rgba(245, 158, 11, 0.1);
            color: var(--primary);
        }

        .nav-item i {
            font-size: 1.1rem;
            width: 24px;
            text-align: center;
        }

        /* Top Dashboard Container (For scroll fading) */
        #topDashboard {
            transition: opacity 0.1s linear, transform 0.1s linear;
        }

        /* Header */
        .header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 3rem;
            position: relative;
        }

        .welcome-text h2 {
            font-family: var(--font-head);
            font-size: 2rem;
            margin-bottom: 0.25rem;
        }

        .welcome-text p {
            color: var(--text-muted);
            font-size: 1rem;
        }

        .action-btn {
            background: var(--primary);
            color: #0f172a;
            border: none;
            padding: 0.8rem 1.5rem;
            border-radius: 8px;
            font-weight: 700;
            font-size: 0.95rem;
            cursor: pointer;
            display: flex;
            align-items: center;
            gap: 10px;
            transition: var(--transition);
            box-shadow: 0 4px 15px rgba(245, 158, 11, 0.3);
            position: relative;
        }

        .action-btn:hover {
            background: var(--primary-hover);
            transform: translateY(-2px);
        }

        /* Request Service Popup Bubble */
        .request-popup {
            position: fixed;
            background: var(--bg-card);
            border: 1px solid var(--primary);
            color: var(--text-main);
            padding: 1rem 1.5rem;
            border-radius: 12px;
            font-weight: 600;
            box-shadow: 0 10px 25px rgba(0,0,0,0.5);
            z-index: 10003;
            animation: popIn 0.3s cubic-bezier(0.175, 0.885, 0.32, 1.275) forwards;
        }

        .request-popup::before {
            content: '';
            position: absolute;
            top: -8px;
            right: 30px;
            border-left: 8px solid transparent;
            border-right: 8px solid transparent;
            border-bottom: 8px solid var(--primary);
        }

        @keyframes popIn {
            from { opacity: 0; transform: translateY(10px) scale(0.9); }
            to { opacity: 1; transform: translateY(0) scale(1); }
        }

        /* Stats Grid */
        .stats-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
            gap: 1.5rem;
            margin-bottom: 3rem;
        }

        .stat-card {
            background: var(--bg-panel);
            padding: 1.5rem;
            border-radius: 16px;
            border: 1px solid rgba(255, 255, 255, 0.05);
            display: flex;
            align-items: center;
            gap: 1.25rem;
            transition: var(--transition);
            position: relative;
            overflow: hidden;
        }

        .stat-card::before {
            content: '';
            position: absolute;
            top: 0; left: 0; width: 4px; height: 100%;
            background: var(--primary);
            border-radius: 4px 0 0 4px;
        }

        .stat-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 10px 25px rgba(0,0,0,0.2);
            border-color: rgba(245, 158, 11, 0.2);
        }

        .stat-icon {
            width: 50px;
            height: 50px;
            border-radius: 12px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 1.25rem;
            background: rgba(56, 189, 248, 0.1);
            color: var(--accent-blue);
        }

        .stat-card:nth-child(2) .stat-icon {
            background: rgba(16, 185, 129, 0.1);
            color: var(--accent-green);
        }

        .stat-card:nth-child(3) .stat-icon {
            background: rgba(245, 158, 11, 0.1);
            color: var(--primary);
        }

        .stat-info h3 {
            font-size: 1.8rem;
            font-weight: 800;
            margin-bottom: 0.2rem;
            font-family: var(--font-head);
            display: flex;
            align-items: center;
        }

        .stat-info p {
            color: var(--text-muted);
            font-size: 0.85rem;
            font-weight: 600;
            text-transform: uppercase;
        }

        /* Dashboard Sections */
        .dashboard-grid {
            display: grid;
            grid-template-columns: 2fr 1fr;
            gap: 1.5rem;
        }

        .panel {
            background: var(--bg-panel);
            border-radius: 16px;
            padding: 2rem;
            border: 1px solid rgba(255, 255, 255, 0.05);
        }

        .panel-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 1.5rem;
        }

        .panel-title {
            font-family: var(--font-head);
            font-size: 1.25rem;
            font-weight: 700;
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .panel-title i {
            color: var(--primary);
        }

        /* Chart Container */
        .chart-container {
            position: relative;
            height: 300px;
            width: 100%;
        }

        /* Service List */
        .service-list {
            display: flex;
            flex-direction: column;
            gap: 1rem;
        }

        .service-item {
            background: var(--bg-card);
            padding: 1rem;
            border-radius: 12px;
            display: flex;
            align-items: center;
            justify-content: space-between;
            transition: var(--transition);
        }

        .service-item:hover {
            background: rgba(245, 158, 11, 0.1);
            transform: scale(1.02);
        }

        .service-details {
            display: flex;
            align-items: center;
            gap: 15px;
        }

        .service-icon {
            width: 40px;
            height: 40px;
            border-radius: 8px;
            background: rgba(255,255,255,0.05);
            display: flex;
            align-items: center;
            justify-content: center;
            color: var(--text-muted);
        }

        .service-item:hover .service-icon {
            color: var(--primary);
            background: rgba(245, 158, 11, 0.2);
        }

        .service-text h4 {
            font-size: 0.95rem;
            font-weight: 600;
        }

        .service-text p {
            font-size: 0.8rem;
            color: var(--text-muted);
            margin-top: 0.2rem;
        }

        .status-badge {
            font-size: 0.75rem;
            padding: 0.25rem 0.75rem;
            border-radius: 20px;
            font-weight: 600;
        }

        .status-active { background: rgba(16, 185, 129, 0.2); color: var(--accent-green); }
        .status-pending { background: rgba(245, 158, 11, 0.2); color: var(--primary); }

        /* Full Page Modal Styles */
        .modal-overlay {
            position: fixed;
            top: 0; left: 0; width: 100%; height: 100%;
            background: rgba(15, 23, 42, 0.8);
            backdrop-filter: blur(5px);
            display: none;
            align-items: center;
            justify-content: center;
            z-index: 10001; /* Above canvas */
        }

        .modal-content {
            background: var(--bg-panel);
            width: 90%;
            height: 90%;
            max-width: 1200px;
            border-radius: 24px;
            border: 1px solid rgba(255, 255, 255, 0.1);
            box-shadow: 0 25px 50px -12px rgba(0, 0, 0, 0.5);
            padding: 3rem;
            position: relative;
            overflow-y: auto;
            animation: slideUp 0.4s ease-out forwards;
        }

        @keyframes slideUp {
            from { opacity: 0; transform: translateY(50px); }
            to { opacity: 1; transform: translateY(0); }
        }

        .modal-close {
            position: absolute;
            top: 20px;
            right: 25px;
            background: none;
            border: none;
            color: var(--text-muted);
            font-size: 1.5rem;
            cursor: pointer;
            transition: var(--transition);
        }

        .modal-close:hover {
            color: var(--text-main);
            transform: rotate(90deg);
        }

        .modal-body {
            height: 100%;
            display: flex;
            flex-direction: column;
        }

        .modal-body.error-state {
            align-items: center;
            justify-content: center;
            text-align: center;
        }

        .modal-body.error-state h2 {
            font-size: 2.5rem;
            color: var(--accent-red);
            margin-bottom: 1rem;
            font-family: var(--font-head);
        }

        .modal-body.error-state p {
            font-size: 1.25rem;
            color: var(--text-muted);
        }

        .generic-content h2 {
            font-family: var(--font-head);
            font-size: 2rem;
            color: var(--primary);
            margin-bottom: 1.5rem;
            border-bottom: 1px solid rgba(255,255,255,0.1);
            padding-bottom: 1rem;
        }

        .generic-content p {
            color: var(--text-muted);
            line-height: 1.6;
            margin-bottom: 1rem;
        }

        /* About Me Section & Slider */
        #aboutMeSection {
            margin-top: 6rem;
            margin-bottom: 4rem;
        }

        .about-header {
            display: flex;
            align-items: center;
            gap: 15px;
            margin-bottom: 2rem;
            border-bottom: 1px solid rgba(255,255,255,0.05);
            padding-bottom: 1rem;
        }

        .about-header h2 {
            font-family: var(--font-head);
            font-size: 2rem;
            color: var(--text-main);
        }

        .about-header audio {
            height: 35px;
            outline: none;
        }

        .slider-container {
            position: relative;
            width: 100%;
            max-width: 900px;
            margin: 0 auto;
            background: var(--bg-card);
            border-radius: 16px;
            overflow: hidden;
            display: flex;
            align-items: center;
            justify-content: center;
            min-height: 400px;
            box-shadow: inset 0 0 20px rgba(0,0,0,0.2);
            border: 1px dashed rgba(255, 255, 255, 0.1);
        }

        .slide {
            display: none;
            width: 100%;
            text-align: center;
            padding: 2rem;
        }

        .slide.active {
            display: block;
            animation: fadeIn 0.6s ease-in-out;
        }

        .slide img {
            max-width: 100%;
            height: auto;
            border-radius: 8px;
            display: block;
            margin: 0 auto;
        }

        .slider-btn {
            position: absolute;
            top: 50%;
            transform: translateY(-50%);
            background: rgba(15, 23, 42, 0.8);
            color: var(--text-main);
            border: 1px solid rgba(255,255,255,0.1);
            width: 50px;
            height: 50px;
            display: flex;
            align-items: center;
            justify-content: center;
            cursor: pointer;
            font-size: 1.25rem;
            border-radius: 50%;
            z-index: 10;
            transition: var(--transition);
        }

        .slider-btn:hover {
            background: var(--primary);
            color: #000;
        }

        .slider-btn.prev { left: 20px; }
        .slider-btn.next { right: 20px; }

        @keyframes fadeIn {
            from { opacity: 0; }
            to { opacity: 1; }
        }

        /* Animations */
        .fade-in {
            opacity: 0;
            transform: translateY(20px);
            transition: opacity 0.8s ease, transform 0.8s ease;
        }

        .slide-right {
            opacity: 0;
            transform: translateX(-30px);
            transition: opacity 0.8s ease, transform 0.8s ease;
        }

        .visible {
            opacity: 1;
            transform: translate(0);
        }

        /* Custom Scrollbar */
        ::-webkit-scrollbar { width: 8px; }
        ::-webkit-scrollbar-track { background: var(--bg-dark); }
        ::-webkit-scrollbar-thumb { background: var(--bg-card); border-radius: 4px; }
        ::-webkit-scrollbar-thumb:hover { background: var(--primary); }

        @media (max-width: 1024px) {
            .dashboard-grid { grid-template-columns: 1fr; }
        }
        @media (max-width: 768px) {
            body { flex-direction: column; }
            .sidebar { width: 100%; height: auto; position: relative; border-right: none; border-bottom: 1px solid rgba(255,255,255,0.05); padding: 1rem; }
            .main-content { margin-left: 0; padding: 1.5rem; }
            .nav-links { flex-direction: row; flex-wrap: wrap; justify-content: center; }
            .nav-item { padding: 0.5rem 1rem; }
        }""")
            ]
        ]
        body [] [
            rawText ("""<!--  Interactive Canvas Background for Hose & Water  -->""")
            canvas [ _id "hoseCanvas" ] []
            rawText ("""<!--  Login Overlay  -->""")
            div [ _id "loginOverlay"; _class "login-overlay" ] [
                div [ _class "login-bubble" ] [
                    h2 [] [
                        str "Enter Your Name (Client ID):"
                    ]
                    input [ _type "text"; _id "clientIdInput"; attr "placeholder" "e.g., george"; attr "autocomplete" "off" ]
                    button [ _id "loginBtn" ] [
                        str "Access Portal"
                    ]
                ]
            ]
            rawText ("""<!--  App Container (Hidden until login)  -->""")
            div [ _id "app-container" ] [
                rawText ("""<!--  Sidebar Navigation  -->""")
                nav [ _class "sidebar slide-right" ] [
                    div [ _class "brand" ] [
                        div [ _class "brand-icon" ] [
                            i [ _class "fa-solid fa-wrench" ] []
                        ]
                        div [ _class "brand-text" ] [
                            h1 [] [
                                str "Loose Screw LLC"
                            ]
                            p [] [
                                str "Property Professionals"
                            ]
                        ]
                    ]
                    ul [ _class "nav-links" ] [
                        li [ _class "nav-item active"; attr "data-target-modal" "none" ] [
                            i [ _class "fa-solid fa-chart-pie" ] []
                            span [] [
                                str "Dashboard"
                            ]
                        ]
                        li [ _class "nav-item"; attr "data-target-modal" "current" ] [
                            i [ _class "fa-solid fa-clipboard-list" ] []
                            span [] [
                                str "Active Projects"
                            ]
                        ]
                        li [ _class "nav-item"; attr "data-target-modal" "log" ] [
                            i [ _class "fa-solid fa-house-chimney-crack" ] []
                            span [] [
                                str "Maintenance Log"
                            ]
                        ]
                        li [ _class "nav-item"; attr "data-target-modal" "invoice" ] [
                            i [ _class "fa-solid fa-file-invoice-dollar" ] []
                            span [] [
                                str "Invoices & Savings"
                            ]
                        ]
                        li [ _class "nav-item"; attr "data-target-modal" "settings" ] [
                            i [ _class "fa-solid fa-gear" ] []
                            span [] [
                                str "Account Settings"
                            ]
                        ]
                        a [ _href "https://turtleprotect.org/projects/loosescrew/"; _class "nav-item" ] [
                            i [ _class "fa-solid fa-arrows-rotate" ] []
                            span [] [
                                str "Refresh"
                            ]
                        ]
                    ]
                ]
                rawText ("""<!--  Main Dashboard Content  -->""")
                main [ _class "main-content" ] [
                    div [ _id "topDashboard" ] [
                        header [ _class "header fade-in" ] [
                            div [ _class "welcome-text" ] [
                                h2 [ _id "welcomeText" ] [
                                    str "Welcome back, Client!"
                                ]
                                p [] [
                                    str "Here is the overview of your property maintenance and repairs."
                                ]
                            ]
                            button [ _class "action-btn"; _id "requestBtn" ] [
                                i [ _class "fa-solid fa-plus" ] []
                                str "Request Service"
                            ]
                        ]
                        rawText ("""<!--  Statistics  -->""")
                        div [ _class "stats-grid" ] [
                            div [ _class "stat-card fade-in"; attr "style" "transition-delay: 0.1s;" ] [
                                div [ _class "stat-icon" ] [
                                    i [ _class "fa-solid fa-hammer" ] []
                                ]
                                div [ _class "stat-info" ] [
                                    h3 [ _class "counter"; _id "compCounter"; attr "data-target" "0" ] [
                                        str "0"
                                    ]
                                    p [] [
                                        str "Projects Completed"
                                    ]
                                ]
                            ]
                            div [ _class "stat-card fade-in"; attr "style" "transition-delay: 0.2s;" ] [
                                div [ _class "stat-icon" ] [
                                    i [ _class "fa-solid fa-shield-halved" ] []
                                ]
                                div [ _class "stat-info" ] [
                                    h3 [ _class "counter"; _id "healthCounter"; attr "data-target" "0" ] [
                                        str "0"
                                    ]
                                    p [] [
                                        str "Property Health Score"
                                    ]
                                ]
                            ]
                            div [ _class "stat-card fade-in"; attr "style" "transition-delay: 0.3s;" ] [
                                div [ _class "stat-icon" ] [
                                    i [ _class "fa-solid fa-piggy-bank" ] []
                                ]
                                div [ _class "stat-info" ] [
                                    h3 [] [
                                        str "$"
                                        span [ _class "counter"; _id "savingsCounter"; attr "data-target" "0" ] [
                                            str "0"
                                        ]
                                    ]
                                    p [] [
                                        str "Cumulative Savings"
                                    ]
                                ]
                            ]
                        ]
                        rawText ("""<!--  Charts and Services  -->""")
                        div [ _class "dashboard-grid" ] [
                            rawText ("""<!--  Savings Chart Panel  -->""")
                            div [ _class "panel fade-in"; attr "style" "transition-delay: 0.4s;" ] [
                                div [ _class "panel-header" ] [
                                    h3 [ _class "panel-title" ] [
                                        i [ _class "fa-solid fa-chart-line" ] []
                                        str "Money Saved Over Time"
                                    ]
                                    span [ attr "style" "color: var(--text-muted); font-size: 0.85rem;" ] [
                                        str "Compared to standard contractor rates"
                                    ]
                                ]
                                div [ _class "chart-container" ] [
                                    canvas [ _id "savingsChart" ] []
                                ]
                            ]
                            rawText ("""<!--  Recent/Active Services Panel  -->""")
                            div [ _class "panel fade-in"; attr "style" "transition-delay: 0.5s;" ] [
                                div [ _class "panel-header" ] [
                                    h3 [ _class "panel-title" ] [
                                        i [ _class "fa-solid fa-list-check" ] []
                                        str "Service Queue"
                                    ]
                                ]
                                div [ _class "service-list" ] [
                                    div [ _class "service-item" ] [
                                        div [ _class "service-details" ] [
                                            div [ _class "service-icon" ] [
                                                i [ _class "fa-solid fa-faucet-drip" ] []
                                            ]
                                            div [ _class "service-text" ] [
                                                h4 [] [
                                                    str "Pipe Realignment"
                                                ]
                                                p [] [
                                                    str "Plumbing Fixes"
                                                ]
                                            ]
                                        ]
                                        span [ _class "status-badge status-active" ] [
                                            str "In Progress"
                                        ]
                                    ]
                                    div [ _class "service-item" ] [
                                        div [ _class "service-details" ] [
                                            div [ _class "service-icon" ] [
                                                i [ _class "fa-solid fa-plug" ] []
                                            ]
                                            div [ _class "service-text" ] [
                                                h4 [] [
                                                    str "Fixture Installation"
                                                ]
                                                p [] [
                                                    str "Electrical Upgrades"
                                                ]
                                            ]
                                        ]
                                        span [ _class "status-badge status-pending" ] [
                                            str "Scheduled"
                                        ]
                                    ]
                                    div [ _class "service-item" ] [
                                        div [ _class "service-details" ] [
                                            div [ _class "service-icon" ] [
                                                i [ _class "fa-solid fa-couch" ] []
                                            ]
                                            div [ _class "service-text" ] [
                                                h4 [] [
                                                    str "Custom Shelving"
                                                ]
                                                p [] [
                                                    str "Carpentry & Assembly"
                                                ]
                                            ]
                                        ]
                                        span [ _class "status-badge status-pending" ] [
                                            str "Pending Quote"
                                        ]
                                    ]
                                    div [ _class "service-item"; attr "style" "justify-content: center; margin-top: 10px; background: transparent;" ] [
                                        a [ _href "#"; _id "historyBtn"; attr "style" "color: var(--primary); text-decoration: none; font-size: 0.9rem; font-weight: 600;" ] [
                                            str "View Full History"
                                            i [ _class "fa-solid fa-arrow-right" ] []
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    rawText ("""<!--  End Top Dashboard  -->""")
                    rawText ("""<!--  About Me Section  -->""")
                    div [ _id "aboutMeSection"; _class "panel fade-in" ] [
                        div [ _class "about-header" ] [
                            h2 [] [
                                str "About Me"
                            ]
                            audio [ attr "controls" "" ] [
                                source [ _src ("data:audio/mp3;base64," + Audio.LooseScrewTheme); _type "audio/mp3" ]
                            ]
                        ]
                        div [ _class "slider-container" ] [
                            button [ _class "slider-btn prev"; attr "onclick" "moveSlide(-1)" ] [
                                i [ _class "fa-solid fa-chevron-left" ] []
                            ]
                            div [ _class "slides-wrapper"; attr "style" "width: 100%;" ] [
                                div [ _class "slide active" ] [
                                    p [ attr "style" "color: var(--text-muted); margin-bottom: 10px;" ] [
                                        str "Hi, I'm Marty. Owner of Loose Screw."
                                        br []
                                        str "This is me with our first dog we got our son, Lucky."
                                    ]
                                    img [ _src ("data:image/jpg;base64," + Image.LuckyPhoto); attr "style" "max-width: 100%; height: auto;"; _alt "Empty Slide 1" ]
                                ]
                                div [ _class "slide" ] [
                                    p [ attr "style" "color: var(--text-muted); margin-bottom: 10px;" ] [
                                        str "Here's a photo of me on our recent ski trip."
                                        br []
                                        str "I like to live on the edge."
                                    ]
                                    img [ _src ("data:image/png;base64," + Image.LivingOnTheEdgePhoto); attr "style" "max-width: 100%; height: auto;"; _alt "Empty Slide 2" ]
                                ]
                                div [ _class "slide" ] [
                                    p [ attr "style" "color: var(--text-muted); margin-bottom: 10px;" ] [
                                        str "A family of entrepreneurs."
                                        br []
                                        str "This is my family."
                                    ]
                                    img [ _src ("data:image/jpg;base64," + Image.FamilyPhoto); attr "style" "max-width: 100%; height: auto;"; _alt "Empty Slide 3" ]
                                ]
                                div [ _class "slide" ] [
                                    p [ attr "style" "color: var(--text-muted); margin-bottom: 10px;" ] [
                                        str "Get your data in a modern dashboard."
                                        br []
                                        br []
                                        str "Click my business card to visit my Facebook!"
                                        br []
                                        br []
                                        str "For quick support, contact via this dashboard instead."
                                    ]
                                    a [ _href "https://www.facebook.com/marty.narverud/photos/d41d8cd9/10223595598543125/"; attr "title:\"Click" ""; attr "to" ""; attr "visit" ""; attr "my" ""; attr "Facebook.\"" "" ] [
                                        img [ _src ("data:image/png;base64," + Image.FacebookLink); attr "style" "max-width: 100%; height: auto;"; _alt "Facebook" ]
                                    ]
                                ]
                            ]
                            button [ _class "slider-btn next"; attr "onclick" "moveSlide(1)" ] [
                                i [ _class "fa-solid fa-chevron-right" ] []
                            ]
                        ]
                    ]
                ]
            ]
            rawText ("""<!--  Full Page Modal Overlay  -->""")
            div [ _id "fullPageModal"; _class "modal-overlay" ] [
                div [ _class "modal-content"; _id "modalContentBox" ] [
                    button [ _class "modal-close"; _id "modalCloseBtn" ] [
                        i [ _class "fa-solid fa-xmark" ] []
                    ]
                    div [ _id "modalBody"; _class "modal-body" ] [
                        rawText ("""<!--  Content gets injected here by JS  -->""")
                    ]
                ]
            ]
            rawText ("""<!--  Request Service Popup  -->""")
            div [ _id "requestPopup"; _class "request-popup"; attr "style" "display:none;" ] [
                str "Call (352) 428-4009 for a quote."
                br []
                str "Sales Operating Hours M-F 8am-7pm EST."
            ]
            script [] [
                    rawText ("""// --- Variables Setup ---
        let $name, $comp, $health, $savings, $current, $log, $invoice, $settings;

        // --- Logic & Login Implementation ---
        const loginBtn = document.getElementById('loginBtn');
        const clientIdInput = document.getElementById('clientIdInput');
        const loginOverlay = document.getElementById('loginOverlay');
        const appContainer = document.getElementById('app-container');

        // Allow Enter key to submit
        clientIdInput.addEventListener('keypress', function (e) {
            if (e.key === 'Enter') {
                loginBtn.click();
            }
        });

        loginBtn.addEventListener('click', () => {
            const clientId = clientIdInput.value.trim().toLowerCase();

            // If-Then-Else Statement required by prompt
            if (clientId === "martin") {
                $name = "Martin";
                $comp = 24;
                $health = 100;
                $savings = 4250;
                $current = "yes";
                $log = "yes";
                $invoice = "yes";
                $settings = "yes";
            } else {
                $name = "Client";
                $comp = "XXX";
                $health = "XXX";
                $savings = "XXX";
                $current = "no";
                $log = "no";
                $invoice = "no";
                $settings = "no";
            }

            // Apply Variables to DOM
            document.getElementById('welcomeText').innerText = `Welcome back, ${$name}!`;
            document.getElementById('compCounter').setAttribute('data-target', $comp);
            document.getElementById('healthCounter').setAttribute('data-target', $health);
            document.getElementById('savingsCounter').setAttribute('data-target', $savings);

            // Hide login, show app
            loginOverlay.style.opacity = '0';
            setTimeout(() => {
                loginOverlay.style.display = 'none';
                appContainer.style.display = 'block';
                initAppAnimations();
                initChart();
            }, 500);
        });

        // --- Init Dashboard Animations & Logic ---
        function initAppAnimations() {
            // Intersection Observer for Fades/Slides
            const observerOptions = { root: null, rootMargin: '0px', threshold: 0.1 };
            const observer = new IntersectionObserver((entries, observer) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        entry.target.classList.add('visible');
                        observer.unobserve(entry.target);
                    }
                });
            }, observerOptions);

            document.querySelectorAll('.fade-in, .slide-right').forEach(el => {
                observer.observe(el);
            });

            // Counter Animation
            const counters = document.querySelectorAll('.counter');
            const speed = 200; 

            counters.forEach(counter => {
                const updateCount = () => {
                    const targetAttr = counter.getAttribute('data-target');
                    
                    if (targetAttr === "XXX") {
                        counter.innerText = "XXX";
                        return;
                    }

                    const target = +targetAttr;
                    const count = +counter.innerText;
                    const inc = target / speed;

                    if (count < target) {
                        counter.innerText = Math.ceil(count + inc);
                        setTimeout(updateCount, 15);
                    } else {
                        counter.innerText = target;
                    }
                };
                
                // Trigger counter immediately since it's above fold
                setTimeout(updateCount, 400); 
            });
        }

        // --- Sidebar & History Modal Logic ---
        const navItems = document.querySelectorAll('.nav-item');
        const historyBtn = document.getElementById('historyBtn');
        const modalOverlay = document.getElementById('fullPageModal');
        const modalBody = document.getElementById('modalBody');
        const modalCloseBtn = document.getElementById('modalCloseBtn');

        // Mapping sections to logic variables dynamically
        const sectionMap = {
            'current': { name: 'Active Projects', varFunc: () => $current },
            'log': { name: 'Maintenance Log', varFunc: () => $log },
            'invoice': { name: 'Invoices & Savings', varFunc: () => $invoice },
            'settings': { name: 'Account Settings', varFunc: () => $settings }
        };

        navItems.forEach(item => {
            item.addEventListener('click', (e) => {
                const target = item.getAttribute('data-target-modal');
                if (!target || target === 'none') return; 

                const sectionInfo = sectionMap[target];
                const hasAccess = sectionInfo.varFunc() === "yes";

                if (hasAccess) {
                    modalBody.className = 'modal-body generic-content';
                    modalBody.innerHTML = `
                        <h2>${sectionInfo.name}</h2>
                        <p>This is a generic placeholder for the ${sectionInfo.name} module.</p>
                        <p>All your detailed records, graphs, and settings for this section will load securely here. You have full administrative access granted to your account.</p>
                        <br>
                        <div style="padding: 2rem; background: rgba(255,255,255,0.02); border-radius: 12px; border: 1px dashed rgba(255,255,255,0.1);">
                            <p style="text-align:center; margin: 0; font-size: 0.9rem;">[ Data Table / Interactive View Component Loading... ]</p>
                        </div>
                    `;
                } else {
                    showErrorModal();
                }
                modalOverlay.style.display = 'flex';
            });
        });

        historyBtn.addEventListener('click', (e) => {
            e.preventDefault();
            if ($name === 'Martin') {
                modalBody.className = 'modal-body generic-content';
                modalBody.innerHTML = `
                    <h2>Full Service History</h2>
                    <div style="display:flex; flex-direction:column; gap: 1rem; margin-top: 1rem;">
                        <div style="background: var(--bg-card); padding: 1.5rem; border-radius: 12px; border-left: 4px solid var(--accent-green);">
                            <h3 style="color: var(--text-main); margin-bottom: 0.5rem; font-family: var(--font-head);">Pipe Realignment</h3>
                            <p style="margin:0; font-size:0.9rem;"><strong>Category:</strong> Plumbing Fixes</p>
                            <p style="margin:0; font-size:0.9rem;"><strong>Status:</strong> <span style="color:var(--accent-green)">In Progress</span></p>
                            <p style="margin-top:0.5rem; color:var(--text-muted);">Realignment of the main water line to ensure proper pressure and prevent future leaks across the property structure.</p>
                        </div>
                        <div style="background: var(--bg-card); padding: 1.5rem; border-radius: 12px; border-left: 4px solid var(--primary);">
                            <h3 style="color: var(--text-main); margin-bottom: 0.5rem; font-family: var(--font-head);">Fixture Installation</h3>
                            <p style="margin:0; font-size:0.9rem;"><strong>Category:</strong> Electrical Upgrades</p>
                            <p style="margin:0; font-size:0.9rem;"><strong>Status:</strong> <span style="color:var(--primary)">Scheduled</span></p>
                            <p style="margin-top:0.5rem; color:var(--text-muted);">Installation of 4 new smart lighting fixtures in the living area and kitchen, updating existing wiring.</p>
                        </div>
                        <div style="background: var(--bg-card); padding: 1.5rem; border-radius: 12px; border-left: 4px solid var(--text-muted);">
                            <h3 style="color: var(--text-main); margin-bottom: 0.5rem; font-family: var(--font-head);">Custom Shelving</h3>
                            <p style="margin:0; font-size:0.9rem;"><strong>Category:</strong> Carpentry & Assembly</p>
                            <p style="margin:0; font-size:0.9rem;"><strong>Status:</strong> <span style="color:var(--text-muted)">Pending Quote</span></p>
                            <p style="margin-top:0.5rem; color:var(--text-muted);">Design and assembly of custom oak shelving units for the home office and garage storage areas.</p>
                        </div>
                    </div>
                `;
            } else {
                showErrorModal();
            }
            modalOverlay.style.display = 'flex';
        });

        function showErrorModal() {
            modalBody.className = 'modal-body error-state';
            modalBody.innerHTML = `
                <h2>Access Denied</h2>
                <p>You are not logged in. 😔</p>
            `;
        }

        modalCloseBtn.addEventListener('click', () => {
            modalOverlay.style.display = 'none';
        });

        modalOverlay.addEventListener('click', (e) => {
            if (e.target === modalOverlay) {
                modalOverlay.style.display = 'none';
            }
        });

        // --- Request Service Bubble Logic ---
        const requestBtn = document.getElementById('requestBtn');
        const requestPopup = document.getElementById('requestPopup');

        requestBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            const rect = requestBtn.getBoundingClientRect();
            requestPopup.style.top = (rect.bottom + 15) + 'px';
            requestPopup.style.right = (window.innerWidth - rect.right) + 'px';
            requestPopup.style.display = 'block';
        });

        document.addEventListener('click', (e) => {
            if (e.target !== requestBtn && e.target !== requestPopup) {
                requestPopup.style.display = 'none';
            }
        });

        // --- Chart.js Initialization ---
        let savingsChart;
        function initChart() {
            const ctxChart = document.getElementById('savingsChart').getContext('2d');
            
            let gradient = ctxChart.createLinearGradient(0, 0, 0, 300);
            gradient.addColorStop(0, 'rgba(56, 189, 248, 0.4)');
            gradient.addColorStop(1, 'rgba(56, 189, 248, 0.0)');

            let chartData = [];
            if ($name === "Martin") {
                chartData = [350, 700, 1150, 1800, 2100, 2800, 3400, 4250];
            } else {
                chartData = [0, 0, 0, 0, 0, 0, 0, 0];
            }

            savingsChart = new Chart(ctxChart, {
                type: 'line',
                data: {
                    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug'],
                    datasets: [{
                        label: 'Cumulative Savings ($)',
                        data: chartData,
                        borderColor: '#38bdf8',
                        backgroundColor: gradient,
                        borderWidth: 3,
                        pointBackgroundColor: '#0f172a',
                        pointBorderColor: '#38bdf8',
                        pointBorderWidth: 2,
                        pointRadius: 5,
                        pointHoverRadius: 7,
                        fill: true,
                        tension: 0.4
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        legend: { display: false },
                        tooltip: {
                            backgroundColor: '#1e293b',
                            titleColor: '#f8fafc',
                            bodyColor: '#38bdf8',
                            borderColor: '#334155',
                            borderWidth: 1,
                            padding: 10,
                            displayColors: false,
                            callbacks: {
                                label: function(context) {
                                    return $name === "Martin" ? '$' + context.parsed.y : 'XXX';
                                }
                            }
                        }
                    },
                    scales: {
                        x: {
                            grid: { color: 'rgba(255, 255, 255, 0.05)', drawBorder: false },
                            ticks: { color: '#94a3b8' }
                        },
                        y: {
                            grid: { color: 'rgba(255, 255, 255, 0.05)', drawBorder: false },
                            ticks: { 
                                color: '#94a3b8', 
                                callback: value => $name === "Martin" ? '$' + value : 'XXX' 
                            }
                        }
                    }
                }
            });
        }

        // --- Fade Top Dashboard on Scroll ---
        window.addEventListener('scroll', () => {
            const topDash = document.getElementById('topDashboard');
            // Calculate opacity based on scroll position (fades out as you scroll down)
            const scrollY = window.scrollY;
            const newOpacity = Math.max(0, 1 - (scrollY / 450));
            topDash.style.opacity = newOpacity;
            topDash.style.transform = `translateY(${scrollY * 0.15}px)`; // Slight parallax
        });

        // --- Slider Logic for About Me ---
        let slideIndex = 0;
        const slides = document.querySelectorAll('.slide');

        function moveSlide(n) {
            slides[slideIndex].classList.remove('active');
            slideIndex = (slideIndex + n + slides.length) % slides.length;
            slides[slideIndex].classList.add('active');
        }

        // --- Interactive Hose & Water Particle System ---
        const canvas = document.getElementById('hoseCanvas');
        const ctx = canvas.getContext('2d');

        let width, height;
        
        function resizeCanvas() {
            width = window.innerWidth;
            height = window.innerHeight;
            canvas.width = width;
            canvas.height = height;
        }
        window.addEventListener('resize', resizeCanvas);
        resizeCanvas();

        const mouse = {
            x: width / 2,
            y: height / 2,
            vx: 0,
            vy: 0,
            lastX: width / 2,
            lastY: height / 2
        };

        const smoothMouse = { x: width / 2, y: height / 2 };

        window.addEventListener('mousemove', (e) => {
            mouse.x = e.clientX;
            mouse.y = e.clientY;
        });

        class Particle {
            constructor(x, y, angle, speedMultiplier) {
                this.x = x;
                this.y = y;
                
                const spread = (Math.random() - 0.5) * 0.8;
                const finalAngle = angle + spread;
                
                const speed = (Math.random() * 8 + 4) * speedMultiplier;
                this.vx = Math.cos(finalAngle) * speed;
                this.vy = Math.sin(finalAngle) * speed;
                
                this.life = 1.0;
                this.decay = Math.random() * 0.015 + 0.005;
                this.size = Math.random() * 4 + 2;
                this.gravity = 0.4;
                
                const blues = ['#38bdf8', '#0ea5e9', '#bae6fd', '#e0f2fe'];
                this.color = blues[Math.floor(Math.random() * blues.length)];
                this.isSplash = false;
            }

            update() {
                this.vy += this.gravity;
                this.x += this.vx;
                this.y += this.vy;
                this.life -= this.decay;

                if (this.y + this.size >= height && !this.isSplash) {
                    this.y = height - this.size;
                    this.vy *= -0.4; 
                    this.vx *= 0.8;  
                    this.size *= 0.6;
                    this.isSplash = true;
                    this.decay *= 2; 
                }
            }

            draw(ctx) {
                ctx.globalAlpha = Math.max(0, this.life);
                ctx.fillStyle = this.color;
                ctx.beginPath();
                ctx.arc(this.x, this.y, this.size, 0, Math.PI * 2);
                ctx.fill();
                ctx.globalAlpha = 1.0;
            }
        }

        let particles = [];

        function animate() {
            ctx.clearRect(0, 0, width, height);

            mouse.vx = mouse.x - mouse.lastX;
            mouse.vy = mouse.y - mouse.lastY;
            mouse.lastX = mouse.x;
            mouse.lastY = mouse.y;

            smoothMouse.x += (mouse.x - smoothMouse.x) * 0.15;
            smoothMouse.y += (mouse.y - smoothMouse.y) * 0.15;

            const startX = width + 20;
            const startY = height + 20;

            const cpX = smoothMouse.x + (startX - smoothMouse.x) * 0.6;
            const cpY = height; 

            const angle = Math.atan2(smoothMouse.y - cpY, smoothMouse.x - cpX);

            // Hose
            ctx.beginPath();
            ctx.moveTo(startX, startY);
            ctx.quadraticCurveTo(cpX, cpY, smoothMouse.x, smoothMouse.y);
            ctx.lineWidth = 18;
            ctx.lineCap = 'round';
            ctx.strokeStyle = '#064e3b';
            ctx.stroke();
            
            // Highlight
            ctx.beginPath();
            ctx.moveTo(startX, startY);
            ctx.quadraticCurveTo(cpX, cpY, smoothMouse.x, smoothMouse.y);
            ctx.lineWidth = 6;
            ctx.strokeStyle = 'rgba(255, 255, 255, 0.15)';
            ctx.stroke();

            // Nozzle
            ctx.save();
            ctx.translate(smoothMouse.x, smoothMouse.y);
            ctx.rotate(angle);
            ctx.fillStyle = '#b45309';
            ctx.fillRect(-10, -12, 30, 24);
            ctx.fillStyle = '#f59e0b';
            ctx.fillRect(-10, -8, 30, 16);
            ctx.fillStyle = '#78350f';
            ctx.fillRect(20, -6, 8, 12);
            ctx.restore();

            // Particles
            const emitX = smoothMouse.x + Math.cos(angle) * 28;
            const emitY = smoothMouse.y + Math.sin(angle) * 28;

            const speedMultiplier = Math.min(1.5, Math.max(0.5, Math.abs(mouse.vx) + Math.abs(mouse.vy) * 0.05));
            for(let i = 0; i < 4; i++) {
                particles.push(new Particle(emitX, emitY, angle, speedMultiplier));
            }

            for (let i = particles.length - 1; i >= 0; i--) {
                const p = particles[i];
                p.update();
                p.draw(ctx);
                
                if (p.life <= 0) {
                    particles.splice(i, 1);
                }
            }

            requestAnimationFrame(animate);
        }

        animate();""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
