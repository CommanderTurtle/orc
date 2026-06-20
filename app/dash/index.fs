module ConvertedFiles.Dash.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Turtle Protect - Take Control of Your Debt"
            ]
            style [] [
                    rawText ("""* {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        :root {
            --primary-blue: #0A6CFF;
            --primary-blue-dark: #0052CC;
            --accent-cyan: #00D4FF;
            --bg-light: #F8FAFC;
            --text-dark: #1A1A2E;
            --text-gray: #64748B;
            --success-green: #10B981;
            --white: #FFFFFF;
            --camo-olive: #556B2F; /* dark olive green */
            --camo-moss: #6B8E23; /* olive drab */
            --camo-fern: #4F6F3E; /* deep natural green */
            --camo-khaki: #BDB76B; /* muted khaki */
            --camo-sand: #C2B280; /* sand beige */
            --camo-bark: #4A3B2A; /* dark brown */
            --camo-earth: #7A6A4F; /* earthy brown */
            --camo-blackgreen: #2B3A1A; /* near-black green */
            --hacker-green: #B9ED54;
            --shadow: 0 10px 40px -10px rgba(0,0,0,0.1);
            --shadow-hover: 0 20px 60px -15px rgba(10, 108, 255, 0.2);
        }

        html {
            scroll-behavior: smooth;
        }

        body {
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
            color: var(--text-dark);
            line-height: 1.6;
            overflow-x: hidden;
            background: var(--white);
        }

        /* Animations */
        @keyframes fadeInUp {
            from {
                opacity: 0;
                transform: translateY(30px);
            }
            to {
                opacity: 1;
                transform: translateY(0);
            }
        }

        @keyframes fadeIn {
            from { opacity: 0; }
            to { opacity: 1; }
        }

        @keyframes slideInRight {
            from {
                opacity: 0;
                transform: translateX(50px);
            }
            to {
                opacity: 1;
                transform: translateX(0);
            }
        }

        @keyframes pulse {
            0%, 100% { transform: scale(1); }
            50% { transform: scale(1.05); }
        }

        @keyframes float {
            0%, 100% { transform: translateY(0px); }
            50% { transform: translateY(-10px); }
        }

        @keyframes shimmer {
            0% { background-position: -1000px 0; }
            100% { background-position: 1000px 0; }
        }

        @keyframes fadeOut {
            from { opacity: 1; }
            to { opacity: 0; }
        }

        .animate-on-scroll {
            opacity: 0;
            transform: translateY(30px);
            transition: all 0.8s cubic-bezier(0.4, 0, 0.2, 1);
        }

        .animate-on-scroll.visible {
            opacity: 1;
            transform: translateY(0);
        }

        /* Header */
        header {
            position: fixed;
            top: 0;
            width: 100%;
            background: rgba(255, 255, 255, 0.95);
            backdrop-filter: blur(10px);
            border-bottom: 1px solid rgba(0,0,0,0.05);
            z-index: 1000;
            padding: 1rem 0;
            transition: all 0.3s ease;
        }

        nav {
            max-width: 1200px;
            margin: 0 auto;
            padding: 0 2rem;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .logo {
            font-size: 1.5rem;
            font-weight: 800;
            color: var(--text-dark);
            text-decoration: none;
            display: flex;
            align-items: center;
            gap: 0.5rem;
            transition: transform 0.3s ease;
        }

        .logo:hover {
            transform: scale(1.05);
        }

        .logo span {
            font-size: 2rem;
            animation: float 3s ease-in-out infinite;
        }

        .phone-btn {
            background: var(--primary-blue); /*camo-moss*/
            color: white;
            padding: 0.75rem 1.5rem;
            border-radius: 50px;
            text-decoration: none;
            font-weight: 600;
            font-size: 0.9rem;
            transition: all 0.3s ease;
            box-shadow: 0 4px 15px rgba(10, 108, 255, 0.3);
            display: flex;
            align-items: center;
            gap: 0.5rem;
        }

        .phone-btn:hover {
            transform: translateY(-2px);
            box-shadow: 0 6px 20px rgba(10, 108, 255, 0.4);
            background: var(--primary-blue-dark); /*camo-blackgreen*/
        }


        /* Hero Section */
        .hero {
            margin-top: 80px;
            padding: 4rem 2rem;
            text-align: center;
            background: linear-gradient(180deg, var(--bg-light) 0%, var(--white) 100%);
            position: relative;
            overflow: hidden;
        }

        .hero::before {
            content: '';
            position: absolute;
            top: -50%;
            left: -50%;
            width: 200%;
            height: 200%;
            background: radial-gradient(circle, rgba(10, 108, 255, 0.03) 0%, transparent 70%);
            animation: pulse 10s ease-in-out infinite;
        }

        .hero-content {
            position: relative;
            z-index: 1;
            max-width: 800px;
            margin: 0 auto;
            animation: fadeInUp 1s ease-out;
        }

        h1 {
            font-size: clamp(2rem, 5vw, 3.5rem);
            font-weight: 800;
            line-height: 1.2;
            margin-bottom: 1.5rem;
            color: var(--text-dark);
        }

        .highlight {
            color: var(--primary-blue);
            position: relative;
            display: inline-block;
        }

        .highlight::after {
            content: '';
            position: absolute;
            bottom: 0;
            left: 0;
            width: 100%;
            height: 30%;
            background: rgba(10, 108, 255, 0.1);
            z-index: -1;
            transform: skewX(-10deg);
        }

        .hero p {
            font-size: 1.25rem;
            color: var(--text-gray);
            margin-bottom: 2rem;
            max-width: 600px;
            margin-left: auto;
            margin-right: auto;
        }

        .cta-button {
            display: inline-block;
            background: var(--primary-blue);
            color: white;
            padding: 1.25rem 2.5rem;
            border-radius: 50px;
            font-weight: 700;
            font-size: 1.1rem;
            text-decoration: none;
            border: none;
            cursor: pointer;
            transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
            box-shadow: 0 10px 30px rgba(10, 108, 255, 0.3);
            position: relative;
            overflow: hidden;
        }

        .cta-button::before {
            content: '';
            position: absolute;
            top: 0;
            left: -100%;
            width: 100%;
            height: 100%;
            background: linear-gradient(90deg, transparent, rgba(255,255,255,0.2), transparent);
            transition: left 0.5s;
        }

        .cta-button:hover {
            transform: translateY(-3px) scale(1.02);
            box-shadow: 0 15px 40px rgba(10, 108, 255, 0.4);
        }

        .cta-button:hover::before {
            left: 100%;
        }

        .trust-badges {
            display: flex;
            justify-content: center;
            gap: 2rem;
            margin-top: 2rem;
            flex-wrap: wrap;
            font-size: 0.85rem;
            color: var(--text-gray);
        }

        .trust-badge {
            display: flex;
            align-items: center;
            gap: 0.5rem;
            animation: fadeIn 1s ease-out 0.5s both;
        }

        .trust-badge svg {
            width: 20px;
            height: 20px;
            color: var(--success-green);
        }

        .security-badges {
            display: flex;
            justify-content: center;
            gap: 2rem;
            margin-top: 1.5rem;
            font-size: 0.75rem;
            color: var(--text-gray);
            opacity: 0.8;
        }

        /* How It Works */
        .how-it-works {
            padding: 5rem 2rem;
            background: var(--white);
        }

        .container {
            max-width: 1200px;
            margin: 0 auto;
        }

        .section-header {
            text-align: center;
            margin-bottom: 4rem;
        }

        h2 {
            font-size: 2.5rem;
            font-weight: 800;
            margin-bottom: 1rem;
            color: var(--text-dark);
        }

        .section-subtitle {
            color: var(--text-gray);
            font-size: 1.1rem;
            max-width: 600px;
            margin: 0 auto;
        }

        .steps {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
            gap: 3rem;
            position: relative;
        }

        .step {
            text-align: center;
            padding: 2rem;
            position: relative;
            animation: fadeInUp 0.8s ease-out backwards;
        }

        .step:nth-child(1) { animation-delay: 0.1s; }
        .step:nth-child(2) { animation-delay: 0.2s; }
        .step:nth-child(3) { animation-delay: 0.3s; }

        .step-icon {
            width: 80px;
            height: 80px;
            background: linear-gradient(135deg, var(--primary-blue), var(--accent-cyan));
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            margin: 0 auto 1.5rem;
            color: white;
            font-size: 2rem;
            box-shadow: 0 10px 30px rgba(10, 108, 255, 0.3);
            transition: transform 0.3s ease;
        }

        .step:hover .step-icon {
            transform: scale(1.1) rotate(5deg);
        }

        .step h3 {
            font-size: 1.25rem;
            font-weight: 700;
            margin-bottom: 0.75rem;
            color: var(--text-dark);
        }

        .step-number {
            color: var(--primary-blue);
            font-weight: 600;
            font-size: 0.9rem;
            display: block;
            margin-bottom: 0.5rem;
        }

        .step p {
            color: var(--text-gray);
            font-size: 0.95rem;
            line-height: 1.6;
        }

        .center-cta {
            text-align: center;
            margin-top: 3rem;
        }

        /* Why Choose Section */
        .why-choose {
            padding: 5rem 2rem;
            background: linear-gradient(135deg, #f0f7ff 0%, #ffffff 100%);
            position: relative;
            overflow: hidden;
        }

        .why-choose::before {
            content: '🐢';
            position: absolute;
            font-size: 400px;
            opacity: 0.03;
            right: -100px;
            top: -100px;
            pointer-events: none;
        }

        .features-grid {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 4rem;
            align-items: center;
            max-width: 1000px;
            margin: 0 auto;
        }

        .features-list {
            space-y: 1.5rem;
        }

        .feature-item {
            display: flex;
            gap: 1rem;
            margin-bottom: 1.5rem;
            padding: 1rem;
            background: rgba(255,255,255,0.8);
            border-radius: 12px;
            transition: all 0.3s ease;
            border: 1px solid rgba(0,0,0,0.05);
        }

        .feature-item:hover {
            transform: translateX(10px);
            box-shadow: var(--shadow);
            background: white;
        }

        .feature-icon {
            width: 40px;
            height: 40px;
            background: rgba(10, 108, 255, 0.1);
            border-radius: 10px;
            display: flex;
            align-items: center;
            justify-content: center;
            color: var(--primary-blue);
            font-size: 1.25rem;
            flex-shrink: 0;
        }

        .feature-text h4 {
            font-weight: 700;
            margin-bottom: 0.25rem;
            color: var(--text-dark);
        }

        .feature-text p {
            font-size: 0.9rem;
            color: var(--text-gray);
            line-height: 1.5;
        }

        .stats-card {
            background: white;
            padding: 3rem;
            border-radius: 24px;
            box-shadow: var(--shadow);
            text-align: center;
            position: relative;
            overflow: hidden;
        }

        .stats-card::after {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            height: 4px;
            background: linear-gradient(90deg, var(--primary-blue), var(--accent-cyan));
        }

        .big-stat {
            font-size: 3rem;
            font-weight: 800;
            color: var(--primary-blue);
            margin-bottom: 0.5rem;
            background: linear-gradient(135deg, var(--primary-blue), var(--accent-cyan));
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            background-clip: text;
        }

        .stat-label {
            color: var(--text-gray);
            font-size: 0.9rem;
            margin-bottom: 2rem;
        }

        .mini-stats {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 1.5rem;
            margin-bottom: 2rem;
        }

        .mini-stat {
            text-align: center;
        }

        .mini-stat-value {
            font-size: 1.5rem;
            font-weight: 700;
            color: var(--text-dark);
        }

        .mini-stat-label {
            font-size: 0.8rem;
            color: var(--text-gray);
        }

        /* Partners */
        .partners {
            padding: 4rem 2rem;
            background: white;
            text-align: center;
        }

        .partners-grid {
            display: flex;
            justify-content: center;
            gap: 4rem;
            margin-top: 3rem;
            flex-wrap: wrap;
        }

        .partner {
            text-align: center;
            padding: 2rem;
            border-radius: 16px;
            transition: all 0.3s ease;
            min-width: 200px;
        }

        .partner:hover {
            background: var(--bg-light);
            transform: translateY(-5px);
        }

        .partner-name {
            font-weight: 700;
            font-size: 1.25rem;
            margin-bottom: 0.5rem;
            color: var(--text-dark);
        }

        .stars {
            color: #FBBF24;
            margin-bottom: 0.5rem;
            font-size: 1.25rem;
            letter-spacing: 2px;
        }

        .partner-rating {
            font-size: 0.9rem;
            color: var(--text-gray);
        }

        .partner-badge {
            display: inline-flex;
            align-items: center;
            gap: 0.5rem;
            margin-top: 2rem;
            padding: 0.75rem 1.5rem;
            background: rgba(16, 185, 129, 0.1);
            color: var(--success-green);
            border-radius: 50px;
            font-size: 0.9rem;
            font-weight: 600;
        }

        /* FAQ Section */
        .faq {
            padding: 5rem 2rem;
            background: var(--bg-light);
        }

        .faq-list {
            max-width: 700px;
            margin: 3rem auto 0;
        }

        .faq-item {
            background: white;
            margin-bottom: 1rem;
            border-radius: 12px;
            overflow: hidden;
            box-shadow: 0 2px 10px rgba(0,0,0,0.05);
            transition: all 0.3s ease;
        }

        .faq-item:hover {
            box-shadow: 0 5px 20px rgba(0,0,0,0.1);
        }

        .faq-question {
            padding: 1.5rem;
            cursor: pointer;
            display: flex;
            justify-content: space-between;
            align-items: center;
            font-weight: 600;
            color: var(--text-dark);
            transition: all 0.3s ease;
        }

        .faq-question:hover {
            color: var(--primary-blue);
        }

        .faq-icon {
            transition: transform 0.3s ease;
            color: var(--text-gray);
        }

        .faq-item.active .faq-icon {
            transform: rotate(180deg);
            color: var(--primary-blue);
        }

        .faq-answer {
            max-height: 0;
            overflow: hidden;
            transition: max-height 0.3s ease, padding 0.3s ease;
            color: var(--text-gray);
            line-height: 1.6;
        }

        .faq-item.active .faq-answer {
            max-height: 300px;
            padding: 0 1.5rem 1.5rem;
        }

        /* Footer CTA */
        .footer-cta {
            background: linear-gradient(135deg, var(--primary-blue), #0052CC);
            padding: 5rem 2rem;
            text-align: center;
            color: white;
            position: relative;
            overflow: hidden;
        }

        .footer-cta::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: url("data:image/svg+xml,%3Csvg width='60' height='60' viewBox='0 0 60 60' xmlns='http://www.w3.org/2000/svg'%3E%3Cg fill='none' fill-rule='evenodd'%3E%3Cg fill='%23ffffff' fill-opacity='0.05'%3E%3Cpath d='M36 34v-4h-2v4h-4v2h4v4h2v-4h4v-2h-4zm0-30V0h-2v4h-4v2h4v4h2V6h4V4h-4zM6 34v-4H4v4H0v2h4v4h2v-4h4v-2H6zM6 4V0H4v4H0v2h4v4h2V6h4V4H6z'/%3E%3C/g%3E%3C/g%3E%3C/svg%3E");
        }

        .footer-cta h2 {
            color: white;
            font-size: 2.5rem;
            margin-bottom: 1rem;
            position: relative;
        }

        .footer-cta p {
            opacity: 0.9;
            margin-bottom: 2rem;
            font-size: 1.1rem;
            max-width: 600px;
            margin-left: auto;
            margin-right: auto;
            position: relative;
        }

        .btn-white {
            background: white;
            color: var(--primary-blue);
            padding: 1.25rem 2.5rem;
            border-radius: 50px;
            font-weight: 700;
            font-size: 1.1rem;
            border: none;
            cursor: pointer;
            transition: all 0.3s ease;
            position: relative;
            display: inline-flex;
            align-items: center;
            gap: 0.5rem;
        }

        .btn-white:hover {
            transform: translateY(-2px);
            box-shadow: 0 10px 30px rgba(0,0,0,0.2);
        }

        .footer-cta-badges {
            display: flex;
            justify-content: center;
            gap: 2rem;
            margin-top: 2rem;
            font-size: 0.85rem;
            opacity: 0.8;
            position: relative;
        }

        /* Footer */
        footer {
            background: #1e293b;
            color: white;
            padding: 3rem 2rem 2rem;
            font-size: 0.9rem;
        }

        .footer-content {
            max-width: 1200px;
            margin: 0 auto;
            display: grid;
            grid-template-columns: 2fr 1fr 1fr 2fr;
            gap: 3rem;
            margin-bottom: 2rem;
        }

        .footer-brand {
            font-size: 1.5rem;
            font-weight: 700;
            margin-bottom: 1rem;
            display: flex;
            align-items: center;
            gap: 0.5rem;
        }

        .footer-brand span {
            font-size: 2rem;
        }

        .footer-desc {
            color: #94a3b8;
            line-height: 1.6;
            max-width: 300px;
        }

        .footer-links h4 {
            margin-bottom: 1rem;
            color: #e2e8f0;
        }

        .footer-links a {
            display: block;
            color: #94a3b8;
            text-decoration: none;
            margin-bottom: 0.5rem;
            transition: color 0.3s ease;
        }

        .footer-links a:hover {
            color: white;
        }

        .footer-contact {
            color: #94a3b8;
        }

        .footer-contact p {
            margin-bottom: 0.5rem;
        }

        .footer-bottom {
            border-top: 1px solid #334155;
            padding-top: 2rem;
            text-align: center;
            color: #64748b;
            font-size: 0.8rem;
            max-width: 1200px;
            margin: 0 auto;
        }

        /* Form Wizard */
        .form-container {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: rgba(255,255,255,0.98);
            z-index: 2000;
            overflow-y: auto;
        }

        .form-container.active {
            display: block;
            animation: fadeIn 0.5s ease;
        }

        .form-header {
            background: white;
            border-bottom: 1px solid #e2e8f0;
            padding: 1rem 2rem;
            position: sticky;
            top: 0;
            z-index: 10;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .form-logo {
            font-size: 1.5rem;
            font-weight: 800;
            display: flex;
            align-items: center;
            gap: 0.5rem;
        }

        .form-logo span {
            font-size: 2rem;
        }

        .close-form {
            background: none;
            border: none;
            font-size: 1.5rem;
            cursor: pointer;
            color: var(--text-gray);
            width: 40px;
            height: 40px;
            display: flex;
            align-items: center;
            justify-content: center;
            border-radius: 50%;
            transition: all 0.3s ease;
        }

        .close-form:hover {
            background: var(--bg-light);
            color: var(--text-dark);
        }

        .form-progress {
            height: 4px;
            background: #e2e8f0;
            width: 100%;
            position: sticky;
            top: 73px;
            z-index: 10;
        }

        .form-progress-bar {
            height: 100%;
            background: linear-gradient(90deg, var(--primary-blue), var(--accent-cyan));
            transition: width 0.5s ease;
            width: 0%;
        }

        .form-content {
            max-width: 600px;
            margin: 3rem auto;
            padding: 0 2rem;
        }

        .form-step {
            display: none;
            animation: fadeInUp 0.5s ease;
        }

        .form-step.active {
            display: block;
        }

        .form-question {
            font-size: 1.75rem;
            font-weight: 700;
            text-align: center;
            margin-bottom: 2rem;
            color: var(--text-dark);
        }

        .form-slider-container {
            margin: 3rem 0;
        }

        .slider-value {
            text-align: center;
            font-size: 2rem;
            font-weight: 700;
            color: var(--primary-blue);
            margin-bottom: 1.5rem;
        }

        .slider {
            width: 100%;
            height: 8px;
            border-radius: 4px;
            background: #e2e8f0;
            outline: none;
            -webkit-appearance: none;
        }

        .slider::-webkit-slider-thumb {
            -webkit-appearance: none;
            appearance: none;
            width: 24px;
            height: 24px;
            border-radius: 50%;
            background: var(--primary-blue);
            cursor: pointer;
            box-shadow: 0 2px 10px rgba(10, 108, 255, 0.3);
            transition: transform 0.2s;
        }

        .slider::-webkit-slider-thumb:hover {
            transform: scale(1.2);
        }

        .slider-labels {
            display: flex;
            justify-content: space-between;
            margin-top: 0.5rem;
            font-size: 0.85rem;
            color: var(--text-gray);
        }

        .form-options {
            display: flex;
            flex-direction: column;
            gap: 1rem;
            margin: 2rem 0;
        }

        .form-option {
            padding: 1.25rem;
            border: 2px solid #e2e8f0;
            border-radius: 12px;
            cursor: pointer;
            transition: all 0.3s ease;
            display: flex;
            align-items: center;
            justify-content: space-between;
            background: white;
        }

        .form-option:hover {
            border-color: var(--primary-blue);
            background: rgba(10, 108, 255, 0.02);
        }

        .form-option.selected {
            border-color: var(--primary-blue);
            background: rgba(10, 108, 255, 0.05);
        }

        .form-option-check {
            width: 24px;
            height: 24px;
            border: 2px solid #cbd5e1;
            border-radius: 6px;
            display: flex;
            align-items: center;
            justify-content: center;
            transition: all 0.3s ease;
            color: white;
            font-weight: bold;
        }

        .form-option.selected .form-option-check {
            background: var(--primary-blue);
            border-color: var(--primary-blue);
        }

        .form-input {
            width: 100%;
            padding: 1rem;
            border: 2px solid #e2e8f0;
            border-radius: 12px;
            font-size: 1rem;
            font-family: inherit;
            transition: all 0.3s ease;
            margin-bottom: 1rem;
        }

        .form-input:focus {
            outline: none;
            border-color: var(--primary-blue);
            box-shadow: 0 0 0 3px rgba(10, 108, 255, 0.1);
        }

        .form-input.error {
            border-color: #ef4444;
        }

        .error-message {
            color: #ef4444;
            font-size: 0.85rem;
            margin-bottom: 1rem;
            display: none;
        }

        .error-message.show {
            display: block;
        }

        .btn-primary {
            width: 100%;
            background: var(--primary-blue);
            color: white;
            padding: 1.25rem;
            border: none;
            border-radius: 12px;
            font-size: 1.1rem;
            font-weight: 700;
            cursor: pointer;
            transition: all 0.3s ease;
            margin-top: 1rem;
        }

        .btn-primary:hover:not(:disabled) {
            background: var(--primary-blue-dark);
            transform: translateY(-2px);
            box-shadow: 0 10px 30px rgba(10, 108, 255, 0.3);
        }

        .btn-primary:disabled {
            opacity: 0.5;
            cursor: not-allowed;
        }

        .form-security {
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 0.5rem;
            margin-top: 1rem;
            font-size: 0.8rem;
            color: var(--text-gray);
        }

        .form-sidebar {
            max-width: 600px;
            margin: 3rem auto 0;
            padding: 2rem;
            background: linear-gradient(135deg, #f0f9ff 0%, #e0f2fe 100%);
            border-radius: 16px;
            border-left: 4px solid var(--primary-blue);
        }

        .testimonial {
            font-style: italic;
            color: var(--text-dark);
            margin-bottom: 1rem;
            line-height: 1.6;
        }

        .testimonial-author {
            font-weight: 700;
            color: var(--primary-blue);
            font-size: 0.9rem;
        }

        .how-to-start {
            margin-top: 2rem;
        }

        .how-to-start h4 {
            margin-bottom: 1rem;
            color: var(--text-dark);
        }

        .how-to-start ol {
            padding-left: 1.5rem;
            color: var(--text-gray);
            font-size: 0.9rem;
            line-height: 1.8;
        }

        .how-to-start li {
            margin-bottom: 0.5rem;
        }

        .how-to-start strong {
            color: var(--text-dark);
        }

        /* Bubble Overlay Popup */
        .bubble-overlay {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: rgba(15, 23, 42, 0.95);
            backdrop-filter: blur(10px);
            z-index: 3000;
            overflow-y: auto;
            animation: fadeIn 0.5s ease;
        }

        .bubble-overlay.active {
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 2rem;
        }

        .bubble-overlay.fade-out {
            animation: fadeOut 0.5s ease forwards;
        }

        .bubble-content {
            background: white;
            border-radius: 30px;
            padding: 3rem;
            max-width: 700px;
            width: 100%;
            box-shadow: 0 25px 80px rgba(0,0,0,0.3);
            animation: fadeInUp 0.5s ease;
            position: relative;
        }

        .bubble-content::before {
            content: '';
            position: absolute;
            top: -20px;
            left: 50%;
            transform: translateX(-50%);
            width: 60px;
            height: 60px;
            background: linear-gradient(135deg, var(--primary-blue), var(--accent-cyan));
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .bubble-content::after {
            content: '🐢';
            position: absolute;
            top: -12px;
            left: 50%;
            transform: translateX(-50%);
            font-size: 1.5rem;
        }

        .bubble-title {
            text-align: center;
            font-size: 1.75rem;
            font-weight: 700;
            color: var(--text-dark);
            margin-bottom: 1.5rem;
            margin-top: 1rem;
        }

        .summary-list {
            background: var(--bg-light);
            border-radius: 16px;
            padding: 1.5rem;
            margin-bottom: 2rem;
        }

        .summary-item {
            display: flex;
            justify-content: space-between;
            padding: 0.75rem 0;
            border-bottom: 1px solid #e2e8f0;
        }

        .summary-item:last-child {
            border-bottom: none;
        }

        .summary-label {
            font-weight: 600;
            color: var(--text-gray);
        }

        .summary-value {
            font-weight: 700;
            color: var(--primary-blue);
            text-align: right;
        }

        .custom-message-section {
            margin-bottom: 1.5rem;
        }

        .custom-message-label {
            display: block;
            font-weight: 600;
            color: var(--text-dark);
            margin-bottom: 0.75rem;
        }

        .custom-message-box {
            width: 100%;
            min-height: 150px;
            padding: 1rem;
            border: 2px solid #e2e8f0;
            border-radius: 12px;
            font-family: inherit;
            font-size: 1rem;
            resize: vertical;
            transition: all 0.3s ease;
        }

        .custom-message-box:focus {
            outline: none;
            border-color: var(--primary-blue);
            box-shadow: 0 0 0 3px rgba(10, 108, 255, 0.1);
        }

        .btn-ready {
            width: 100%;
            background: linear-gradient(135deg, var(--primary-blue), var(--primary-blue-dark));
            color: white;
            padding: 1.25rem;
            border: none;
            border-radius: 12px;
            font-size: 1.1rem;
            font-weight: 700;
            cursor: pointer;
            transition: all 0.3s ease;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 0.5rem;
        }

        .btn-ready:hover {
            transform: translateY(-2px);
            box-shadow: 0 10px 30px rgba(10, 108, 255, 0.4);
        }

        /* Base64 Result Overlay */
        .base64-overlay {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: rgba(15, 23, 42, 0.98);
            backdrop-filter: blur(10px);
            z-index: 4000;
            overflow-y: auto;
            animation: fadeIn 0.5s ease;
        }

        .base64-overlay.active {
            display: block;
        }

        .base64-content {
            max-width: 900px;
            margin: 3rem auto;
            padding: 2rem;
            position: relative;
        }

        .close-base64 {
            position: absolute;
            top: 0;
            right: 2rem;
            background: rgba(255,255,255,0.1);
            border: none;
            color: white;
            width: 48px;
            height: 48px;
            border-radius: 50%;
            font-size: 1.5rem;
            cursor: pointer;
            transition: all 0.3s ease;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .close-base64:hover {
            background: rgba(255,255,255,0.2);
            transform: rotate(90deg);
        }

        .base64-title {
            color: white;
            text-align: center;
            margin-bottom: 2rem;
            font-size: 2rem;
        }

        .base64-block {
            background: rgba(255,255,255,0.05);
            border: 1px solid rgba(255,255,255,0.1);
            border-radius: 16px;
            padding: 2rem;
            margin-bottom: 2rem;
            font-family: 'Courier New', monospace;
            color: #00ff9d;
            word-break: break-all;
            line-height: 1.6;
            max-height: 400px;
            overflow-y: auto;
            position: relative;
        }

        .copy-btn {
            display: block;
            width: 200px;
            margin: 0 auto 3rem;
            padding: 1rem 2rem;
            background: var(--primary-blue);
            color: white;
            border: none;
            border-radius: 50px;
            font-weight: 700;
            cursor: pointer;
            transition: all 0.3s ease;
        }

        .copy-btn:hover {
            background: var(--accent-cyan);
            color: var(--text-dark);
            transform: translateY(-2px);
        }

        .copy-btn.copied {
            background: var(--success-green);
        }

        @media (max-width: 768px) {
            .features-grid {
                grid-template-columns: 1fr;
            }
            
            .footer-content {
                grid-template-columns: 1fr;
                gap: 2rem;
            }
            
            .partners-grid {
                gap: 2rem;
            }
            
            .trust-badges {
                flex-direction: column;
                gap: 1rem;
            }

            .bubble-content {
                padding: 2rem 1.5rem;
            }

            .bubble-title {
                font-size: 1.4rem;
            }
        }""")
            ]
            voidTag "base" [ attr "target" "_blank" ]
        ]
        body [] [
            rawText ("<!--  Header  -->")
            header [ _id "main-header" ] [
                nav [] [
                    a [ _href "#"; _class "logo" ] [
                        span [] [
                            str "🐢"
                        ]
                        str "Turtle Protect"
                    ]
                    a [ _href "tel:3524284009"; _class "phone-btn" ] [
                        tag "svg" [ attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                            tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z" ] []
                        ]
                        str "(352) 428-4009"
                    ]
                ]
            ]
            rawText ("<!--  Hero Section  -->")
            section [ _class "hero" ] [
                div [ _class "hero-content" ] [
                    h1 [] [
                        str "Take Control of Your"
                        span [ _class "highlight" ] [
                            str "Debt Right Now"
                        ]
                    ]
                    p [] [
                        str "You may qualify for a plan that reduces what you owe and simplifies your payments"
                    ]
                    button [ _class "cta-button"; attr "onclick" "openForm()" ] [
                        str "Check My Eligibility"
                    ]
                    div [ _class "trust-badges" ] [
                        div [ _class "trust-badge" ] [
                            tag "svg" [ attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" ] []
                            ]
                            str "Secure"
                        ]
                        div [ _class "trust-badge" ] [
                            tag "svg" [ attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M5 13l4 4L19 7" ] []
                            ]
                            str "Free to Check"
                        ]
                        div [ _class "trust-badge" ] [
                            tag "svg" [ attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M9 12l2 2 4-4m5.618-4.016A11.955 11.955 0 0112 2.944a11.955 11.955 0 01-8.618 3.04A12.02 12.02 0 003 9c0 5.591 3.824 10.29 9 11.622 5.176-1.332 9-6.03 9-11.622 0-1.042-.133-2.052-.382-3.016z" ] []
                            ]
                            str "Doesn't Impact Your Credit"
                        ]
                    ]
                    div [ _class "security-badges" ] [
                        span [] [
                            str "SSL Secured"
                        ]
                        span [] [
                            str "Norton Verified"
                        ]
                    ]
                ]
            ]
            rawText ("<!--  How It Works  -->")
            section [ _class "how-it-works" ] [
                div [ _class "container" ] [
                    div [ _class "section-header animate-on-scroll" ] [
                        h2 [] [
                            str "How It Works"
                        ]
                        p [ _class "section-subtitle" ] [
                            str "Getting debt relief is easier than you think. Here's how we help thousands of Americans every month."
                        ]
                    ]
                    div [ _class "steps" ] [
                        div [ _class "step animate-on-scroll" ] [
                            div [ _class "step-icon" ] [
                                str "📋"
                            ]
                            span [ _class "step-number" ] [
                                str "Step 1"
                            ]
                            h3 [] [
                                str "Answer a few simple questions"
                            ]
                            p [] [
                                str "Tell us about your debt situation in just 2-3 minutes."
                            ]
                        ]
                        div [ _class "step animate-on-scroll" ] [
                            div [ _class "step-icon" ] [
                                str "🤝"
                            ]
                            span [ _class "step-number" ] [
                                str "Step 2"
                            ]
                            h3 [] [
                                str "Get matched with a debt relief plan"
                            ]
                            p [] [
                                str "We connect you with top-rated, licensed debt relief providers."
                            ]
                        ]
                        div [ _class "step animate-on-scroll" ] [
                            div [ _class "step-icon" ] [
                                str "📉"
                            ]
                            span [ _class "step-number" ] [
                                str "Step 3"
                            ]
                            h3 [] [
                                str "Start lowering your monthly payments"
                            ]
                            p [] [
                                str "Begin your journey to financial freedom with expert guidance."
                            ]
                        ]
                    ]
                    div [ _class "center-cta animate-on-scroll" ] [
                        button [ _class "cta-button"; attr "onclick" "openForm()" ] [
                            str "Start Your Free Assessment"
                        ]
                    ]
                ]
            ]
            rawText ("<!--  Why Choose Turtle Protect  -->")
            section [ _class "why-choose" ] [
                div [ _class "container" ] [
                    div [ _class "section-header animate-on-scroll" ] [
                        h2 [] [
                            str "Why Choose"
                            span [ _class "highlight" ] [
                                str "Turtle"
                            ]
                            str "Protect?"
                        ]
                    ]
                    div [ _class "features-grid" ] [
                        div [ _class "features-list animate-on-scroll" ] [
                            div [ _class "feature-item" ] [
                                div [ _class "feature-icon" ] [
                                    str "💰"
                                ]
                                div [ _class "feature-text" ] [
                                    h4 [] [
                                        str "Plan for life"
                                    ]
                                    p [] [
                                        str "Only pay when we successfully help. No hidden costs or surprise charges."
                                    ]
                                ]
                            ]
                            div [ _class "feature-item" ] [
                                div [ _class "feature-icon" ] [
                                    str "🛡️"
                                ]
                                div [ _class "feature-text" ] [
                                    h4 [] [
                                        str "Safe & Confidential"
                                    ]
                                    p [] [
                                        str "Your personal information is protected with security and encryption."
                                    ]
                                ]
                            ]
                            div [ _class "feature-item" ] [
                                div [ _class "feature-icon" ] [
                                    str "🏆"
                                ]
                                div [ _class "feature-text" ] [
                                    h4 [] [
                                        str "Works with Top-Rated Providers"
                                    ]
                                    p [] [
                                        str "We partner only with licensed, accredited companies with proven track records."
                                    ]
                                ]
                            ]
                            div [ _class "feature-item" ] [
                                div [ _class "feature-icon" ] [
                                    str "⭐"
                                ]
                                div [ _class "feature-text" ] [
                                    h4 [] [
                                        str "Rated Excellent by Thousands of Americans"
                                    ]
                                    p [] [
                                        str "Join over 50,000 satisfied customers who've found a plan through our connections."
                                    ]
                                ]
                            ]
                            div [ _class "feature-item" ] [
                                div [ _class "feature-icon" ] [
                                    str "✓"
                                ]
                                div [ _class "feature-text" ] [
                                    h4 [] [
                                        str "Lower Your Monthly Payments"
                                    ]
                                    p [] [
                                        str "Most customers see significant reductions in their monthly stress within 90 days."
                                    ]
                                ]
                            ]
                        ]
                        div [ _class "stats-card animate-on-scroll" ] [
                            div [ _class "big-stat" ] [
                                str "$100,000+"
                            ]
                            div [ _class "stat-label" ] [
                                str "Average debt on a home with our customers"
                            ]
                            div [ _class "mini-stats" ] [
                                div [ _class "mini-stat" ] [
                                    div [ _class "mini-stat-value" ] [
                                        str "∞"
                                    ]
                                    div [ _class "mini-stat-label" ] [
                                        str "Time earned with debt freedom"
                                    ]
                                ]
                                div [ _class "mini-stat" ] [
                                    div [ _class "mini-stat-value" ] [
                                        str "∞"
                                    ]
                                    div [ _class "mini-stat-label" ] [
                                        str "Average debt reduction"
                                    ]
                                ]
                            ]
                            button [ _class "cta-button"; attr "onclick" "openForm()"; attr "style" "width: 100%;" ] [
                                str "Get Started Today"
                            ]
                        ]
                    ]
                ]
            ]
            rawText ("<!--  Partners  -->")
            section [ _class "partners" ] [
                div [ _class "container" ] [
                    div [ _class "section-header animate-on-scroll" ] [
                        h3 [ attr "style" "font-size: 1.5rem; color: var(--text-gray);" ] [
                            str "Trusted Partners with Proven Results"
                        ]
                        p [ _class "section-subtitle" ] [
                            str "We work exclusively with licensed, top-rated providers"
                        ]
                    ]
                    div [ _class "partners-grid animate-on-scroll" ] [
                        div [ _class "partner" ] [
                            div [ _class "partner-name" ] [
                                str "Trustpilot"
                            ]
                            div [ _class "stars" ] [
                                str "★★★★★"
                            ]
                            div [ _class "partner-rating" ] [
                                str "4.8 (3,500+ reviews)"
                            ]
                        ]
                        div [ _class "partner" ] [
                            div [ _class "partner-name" ] [
                                str "Google"
                            ]
                            div [ _class "stars" ] [
                                str "★★★★☆"
                            ]
                            div [ _class "partner-rating" ] [
                                str "4.6 (1,070+ reviews)"
                            ]
                        ]
                        div [ _class "partner" ] [
                            div [ _class "partner-name" ] [
                                str "Experience.com"
                            ]
                            div [ _class "stars" ] [
                                str "★★★★★"
                            ]
                            div [ _class "partner-rating" ] [
                                str "4.86 (96.6K+ Reviews)"
                            ]
                        ]
                    ]
                    div [ _class "partner-badge animate-on-scroll" ] [
                        tag "svg" [ attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                            tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" ] []
                        ]
                        str "All partners are licensed and trained"
                    ]
                ]
            ]
            rawText ("<!--  FAQ  -->")
            section [ _class "faq" ] [
                div [ _class "container" ] [
                    div [ _class "section-header animate-on-scroll" ] [
                        h2 [] [
                            str "Frequently Asked Questions"
                        ]
                        p [ _class "section-subtitle" ] [
                            str "Get answers to common questions about debt relief"
                        ]
                    ]
                    div [ _class "faq-list animate-on-scroll" ] [
                        div [ _class "faq-item" ] [
                            div [ _class "faq-question"; attr "onclick" "toggleFaq(this)" ] [
                                str "What is debt relief?"
                                tag "svg" [ _class "faq-icon"; attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                    tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M19 9l-7 7-7-7" ] []
                                ]
                            ]
                            div [ _class "faq-answer" ] [
                                str "Debt relief helps reduce the total amount you owe through negotiation with creditors. Our partners work in effect to lower your mortgage, fund expenses, and create manageable protections of estate that fit your budget."
                            ]
                        ]
                        div [ _class "faq-item" ] [
                            div [ _class "faq-question"; attr "onclick" "toggleFaq(this)" ] [
                                str "Will this hurt my credit?"
                                tag "svg" [ _class "faq-icon"; attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                    tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M19 9l-7 7-7-7" ] []
                                ]
                            ]
                            div [ _class "faq-answer" ] [
                                str "Debt relief in a traditional sense is not what we offer. We manage estate protection servicing through partners. Many clients see a real benefit in will and love of life, knowing they can pay off and continue to own and hold value of estate. The long-term benefits often outweigh short-term cost."
                            ]
                        ]
                        div [ _class "faq-item" ] [
                            div [ _class "faq-question"; attr "onclick" "toggleFaq(this)" ] [
                                str "How fast can I get help?"
                                tag "svg" [ _class "faq-icon"; attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                    tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M19 9l-7 7-7-7" ] []
                                ]
                            ]
                            div [ _class "faq-answer" ] [
                                str "You can get matched with a specialist within 48 hours of completing our assessment. Most clients are happy to see their future planned for."
                            ]
                        ]
                        div [ _class "faq-item" ] [
                            div [ _class "faq-question"; attr "onclick" "toggleFaq(this)" ] [
                                str "What debts qualify?"
                                tag "svg" [ _class "faq-icon"; attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                    tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M19 9l-7 7-7-7" ] []
                                ]
                            ]
                            div [ _class "faq-answer" ] [
                                str "Any property debt, including Mortgages. We can link people with retirement planning, cash-value indexing, annuty purchasing, and more. Secure your debts like mortgages and car loans by turning these liabilities into assets."
                            ]
                        ]
                    ]
                    div [ _class "center-cta animate-on-scroll"; attr "style" "margin-top: 3rem;" ] [
                        button [ _class "cta-button"; attr "onclick" "openForm()" ] [
                            str "See If You're Eligible"
                        ]
                    ]
                ]
            ]
            rawText ("<!--  Footer CTA  -->")
            section [ _class "footer-cta" ] [
                h2 [] [
                    str "Struggling with debt? See if you can turn your estate into your greatest asset."
                ]
                p [] [
                    str "Join thousands of Americans who've found a future through our trusted network of real specialists."
                ]
                button [ _class "btn-white"; attr "onclick" "openForm()" ] [
                    str "Check Eligibility Now"
                    tag "svg" [ attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                        tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M9 5l7 7-7 7" ] []
                    ]
                ]
                div [ _class "footer-cta-badges" ] [
                    span [] [
                        str "✓ Free Assessment"
                    ]
                    span [] [
                        str "✓ No Obligation"
                    ]
                    span [] [
                        str "✓ Secure & Confidential"
                    ]
                ]
            ]
            rawText ("<!--  Footer  -->")
            footer [] [
                div [ _class "footer-content" ] [
                    div [] [
                        div [ _class "footer-brand" ] [
                            span [] [
                                str "🐢"
                            ]
                            str "Turtle Protect"
                        ]
                        p [ _class "footer-desc" ] [
                            str "Connecting Americans with trusted insurance plans since 2024. Licensed and regulated protection services."
                        ]
                    ]
                    div [ _class "footer-links" ] [
                        h4 [] [
                            str "Legal"
                        ]
                        a [ _href "https://turtleprotect.org/docs/1.md" ] [
                            str "Terms of Service"
                        ]
                        a [ _href "https://turtleprotect.org/docs/2.md" ] [
                            str "Privacy Policy"
                        ]
                        a [ _href "https://turtleprotect.org/home/" ] [
                            str "Visit my main page"
                        ]
                    ]
                    div [ _class "footer-links" ] [
                        h4 [] [
                            str "Company"
                        ]
                        a [ _href "https://turtleprotect.org/blog/" ] [
                            str "Blog"
                        ]
                        a [ _href "https://turtleprotect.org/home/" ] [
                            str "About Us"
                        ]
                        a [ _href "tel:3524284009" ] [
                            str "Contact"
                        ]
                    ]
                    div [ _class "footer-contact" ] [
                        h4 [] [
                            str "Contact"
                        ]
                        p [] [
                            str "Phone: (352) 428-4009"
                        ]
                        p [] [
                            str "Available: Mon-Fri 8AM-8PM EST"
                        ]
                    ]
                ]
                div [ _class "footer-bottom" ] [
                    p [] [
                        str "Important Disclaimer: TurtleProtect.org does not directly provide debt relief or financial advice. We connect users with trusted, licensed providers. Turtle Protect is a Florida-based project. 🐢"
                    ]
                    p [ attr "style" "margin-top: 1rem;" ] [
                        str "™ 2026 Turtle Protect. Most rights reserved. Licensed Protection Services Provider"
                    ]
                ]
            ]
            rawText ("<!--  Form Wizard  -->")
            div [ _class "form-container"; _id "formContainer" ] [
                div [ _class "form-header" ] [
                    div [ _class "form-logo" ] [
                        span [] [
                            str "🐢"
                        ]
                        str "Turtle Protect"
                    ]
                    button [ _class "close-form"; attr "onclick" "closeForm()" ] [
                        str "✕"
                    ]
                ]
                div [ _class "form-progress" ] [
                    div [ _class "form-progress-bar"; _id "progressBar" ] []
                ]
                div [ _class "form-content" ] [
                    rawText ("<!--  Step 1: Debt Amount  -->")
                    div [ _class "form-step active"; attr "data-step" "1" ] [
                        h3 [ _class "form-question" ] [
                            str "How Much Do You Owe?"
                        ]
                        div [ _class "form-slider-container" ] [
                            div [ _class "slider-value"; _id "debtValue" ] [
                                str "$41,250"
                            ]
                            input [ _type "range"; attr "min" "5000"; attr "max" "100000"; attr "value" "41250"; _class "slider"; _id "debtSlider"; attr "oninput" "updateDebtValue(this.value)" ]
                            div [ _class "slider-labels" ] [
                                span [] [
                                    str "$5,000"
                                ]
                                span [] [
                                    str "$100,000+"
                                ]
                            ]
                        ]
                        button [ _class "btn-primary"; attr "onclick" "nextStep()" ] [
                            str "Next"
                        ]
                        div [ _class "form-security" ] [
                            tag "svg" [ attr "width" "16"; attr "height" "16"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" ] []
                            ]
                            str "Secure & Confidential - Your information is protected"
                        ]
                    ]
                    rawText ("<!--  Step 2: Debt Type  -->")
                    div [ _class "form-step"; attr "data-step" "2" ] [
                        h3 [ _class "form-question" ] [
                            str "What type of debt do you need help with?"
                        ]
                        div [ _class "form-options" ] [
                            div [ _class "form-option"; attr "onclick" "toggleDebtType(this, 'Mortgage')" ] [
                                span [] [
                                    str "Mortgage"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "toggleDebtType(this, 'Personal Loan')" ] [
                                span [] [
                                    str "Personal Loan"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "toggleDebtType(this, 'Collection')" ] [
                                span [] [
                                    str "Collection"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "toggleDebtType(this, 'Custom')" ] [
                                span [] [
                                    str "Tax Debt"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                        ]
                        div [ _class "form-security"; attr "style" "margin-bottom: 1rem;" ] [
                            tag "svg" [ attr "width" "16"; attr "height" "16"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" ] []
                            ]
                            str "This helps us gauge your financial aims and goals."
                        ]
                        button [ _class "btn-primary"; attr "onclick" "nextStep()" ] [
                            str "Next"
                        ]
                    ]
                    rawText ("<!--  Step 3: Income  -->")
                    div [ _class "form-step"; attr "data-step" "3" ] [
                        h3 [ _class "form-question" ] [
                            str "What is your approximate monthly income?"
                        ]
                        div [ _class "form-options" ] [
                            div [ _class "form-option"; attr "onclick" "selectIncome(this, '$1,000 - $2,000')" ] [
                                span [] [
                                    str "$1,000 - $2,000"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectIncome(this, '$2,000 - $3,000')" ] [
                                span [] [
                                    str "$2,000 - $3,000"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectIncome(this, '$3,000 - $4,000')" ] [
                                span [] [
                                    str "$3,000 - $4,000"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectIncome(this, '$4,000 - $5,000')" ] [
                                span [] [
                                    str "$4,000 - $5,000"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectIncome(this, '$5,000+')" ] [
                                span [] [
                                    str "$5,000+"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                        ]
                        div [ _class "form-security"; attr "style" "margin-bottom: 1rem;" ] [
                            tag "svg" [ attr "width" "16"; attr "height" "16"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" ] []
                            ]
                            str "This helps us gauge your financial situation and ensure you're presented with suitable choices."
                        ]
                        button [ _class "btn-primary"; attr "onclick" "nextStep()" ] [
                            str "Next"
                        ]
                    ]
                    rawText ("<!--  Step 4: Employment  -->")
                    div [ _class "form-step"; attr "data-step" "4" ] [
                        h3 [ _class "form-question" ] [
                            str "What best describes your current employment?"
                        ]
                        div [ _class "form-options" ] [
                            div [ _class "form-option"; attr "onclick" "selectEmployment(this, 'Full-Time Employed')" ] [
                                div [] [
                                    div [ attr "style" "font-weight: 600;" ] [
                                        str "Full-Time Employed"
                                    ]
                                    div [ attr "style" "font-size: 0.85rem; color: var(--text-gray);" ] [
                                        str "40+ hours per week"
                                    ]
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectEmployment(this, 'Part-Time Employed')" ] [
                                div [] [
                                    div [ attr "style" "font-weight: 600;" ] [
                                        str "Part-Time Employed"
                                    ]
                                    div [ attr "style" "font-size: 0.85rem; color: var(--text-gray);" ] [
                                        str "Less than 40 hours per week"
                                    ]
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectEmployment(this, 'Self-Employed')" ] [
                                div [] [
                                    div [ attr "style" "font-weight: 600;" ] [
                                        str "Self-Employed"
                                    ]
                                    div [ attr "style" "font-size: 0.85rem; color: var(--text-gray);" ] [
                                        str "Business owner or contractor"
                                    ]
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectEmployment(this, 'Retired')" ] [
                                div [] [
                                    div [ attr "style" "font-weight: 600;" ] [
                                        str "Retired"
                                    ]
                                    div [ attr "style" "font-size: 0.85rem; color: var(--text-gray);" ] [
                                        str "Receiving retirement benefits"
                                    ]
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectEmployment(this, 'Other')" ] [
                                div [] [
                                    div [ attr "style" "font-weight: 600;" ] [
                                        str "Other"
                                    ]
                                    div [ attr "style" "font-size: 0.85rem; color: var(--text-gray);" ] [
                                        str "Not currently employed"
                                    ]
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                        ]
                        div [ _class "form-security"; attr "style" "margin-bottom: 1rem;" ] [
                            tag "svg" [ attr "width" "16"; attr "height" "16"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" ] []
                            ]
                            str "This information helps us tailor recommendations based on your employment status."
                        ]
                        button [ _class "btn-primary"; attr "onclick" "nextStep()" ] [
                            str "Next"
                        ]
                    ]
                    rawText ("<!--  Step 5: Pay Frequency  -->")
                    div [ _class "form-step"; attr "data-step" "5" ] [
                        h3 [ _class "form-question" ] [
                            str "What is your pay frequency?"
                        ]
                        div [ _class "form-options" ] [
                            div [ _class "form-option"; attr "onclick" "selectFrequency(this, 'Weekly')" ] [
                                span [] [
                                    str "Weekly"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectFrequency(this, 'Biweekly')" ] [
                                span [] [
                                    str "Biweekly"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectFrequency(this, 'Twice Monthly')" ] [
                                span [] [
                                    str "Twice Monthly"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                            div [ _class "form-option"; attr "onclick" "selectFrequency(this, 'Monthly')" ] [
                                span [] [
                                    str "Monthly"
                                ]
                                div [ _class "form-option-check" ] [
                                    str "✓"
                                ]
                            ]
                        ]
                        div [ _class "form-security"; attr "style" "margin-bottom: 1rem;" ] [
                            tag "svg" [ attr "width" "16"; attr "height" "16"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" ] []
                            ]
                            str "Knowing how often you're paid helps us align to your financial rhythm."
                        ]
                        button [ _class "btn-primary"; attr "onclick" "nextStep()" ] [
                            str "Next"
                        ]
                    ]
                    rawText ("<!--  Step 6: Email  -->")
                    div [ _class "form-step"; attr "data-step" "6" ] [
                        h3 [ _class "form-question" ] [
                            str "What's your email address?"
                        ]
                        input [ _type "email"; _class "form-input"; _id "emailInput"; attr "placeholder" "Email Address"; attr "onblur" "validateEmail()" ]
                        div [ _class "error-message"; _id "emailError" ] [
                            str "Email is required"
                        ]
                        div [ _class "form-security"; attr "style" "margin-bottom: 2rem;" ] [
                            tag "svg" [ attr "width" "16"; attr "height" "16"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                                tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" ] []
                            ]
                            str "We need this to complete your profile and move forward with your request."
                        ]
                        button [ _class "btn-primary"; attr "onclick" "finishForm()" ] [
                            str "Next"
                        ]
                    ]
                ]
                div [ _class "form-sidebar" ] [
                    div [ attr "style" "font-weight: 700; margin-bottom: 1rem; color: var(--text-dark);" ] [
                        str "You're Likely Eligible For Lower Payments"
                    ]
                    p [ attr "style" "font-size: 0.9rem; color: var(--text-gray); margin-bottom: 1rem; line-height: 1.6;" ] [
                        str "Thanks to recent program changes, many individuals struggling with debt may not realize they qualify for plans that change how they can afford the future."
                    ]
                    div [ _class "testimonial" ] [
                        str "\"I was completely overwhelmed. Now I know how to plan, I no longer resent, and I'm finally sleeping again.\""
                    ]
                    div [ _class "testimonial-author" ] [
                        str "— JMAR, 25, Tampa FL"
                    ]
                    div [ _class "how-to-start" ] [
                        h4 [] [
                            str "Here's How To Get Started:"
                        ]
                        ol [] [
                            li [] [
                                strong [] [
                                    str "Step 1:"
                                ]
                                str "Click SEE MY OPTIONS above and answer the questions"
                            ]
                            li [] [
                                strong [] [
                                    str "Step 2:"
                                ]
                                str "Fill out the short form to check what you qualify for"
                            ]
                            li [] [
                                strong [] [
                                    str "Step 3:"
                                ]
                                str "Review your custom response and decide if it's the right fit"
                            ]
                        ]
                        button [ _class "cta-button"; attr "style" "width: 100%; margin-top: 1rem; padding: 0.75rem;"; attr "onclick" "document.getElementById('debtSlider').focus()" ] [
                            str "SEE MY OPTIONS"
                        ]
                    ]
                ]
            ]
            rawText ("<!--  Bubble Overlay Popup  -->")
            div [ _class "bubble-overlay"; _id "bubbleOverlay" ] [
                div [ _class "bubble-content" ] [
                    h2 [ _class "bubble-title" ] [
                        str "The information you have given is:"
                    ]
                    div [ _class "summary-list" ] [
                        div [ _class "summary-item" ] [
                            span [ _class "summary-label" ] [
                                str "Debt Amount:"
                            ]
                            span [ _class "summary-value"; _id "summaryDebtAmount" ] [
                                str "-"
                            ]
                        ]
                        div [ _class "summary-item" ] [
                            span [ _class "summary-label" ] [
                                str "Debt Type:"
                            ]
                            span [ _class "summary-value"; _id "summaryDebtType" ] [
                                str "-"
                            ]
                        ]
                        div [ _class "summary-item" ] [
                            span [ _class "summary-label" ] [
                                str "Monthly Income:"
                            ]
                            span [ _class "summary-value"; _id "summaryIncome" ] [
                                str "-"
                            ]
                        ]
                        div [ _class "summary-item" ] [
                            span [ _class "summary-label" ] [
                                str "Employment:"
                            ]
                            span [ _class "summary-value"; _id "summaryEmployment" ] [
                                str "-"
                            ]
                        ]
                        div [ _class "summary-item" ] [
                            span [ _class "summary-label" ] [
                                str "Pay Frequency:"
                            ]
                            span [ _class "summary-value"; _id "summaryFrequency" ] [
                                str "-"
                            ]
                        ]
                        div [ _class "summary-item" ] [
                            span [ _class "summary-label" ] [
                                str "Email:"
                            ]
                            span [ _class "summary-value"; _id "summaryEmail" ] [
                                str "-"
                            ]
                        ]
                    ]
                    div [ _class "custom-message-section" ] [
                        label [ _class "custom-message-label"; attr "for" "customMessageBox" ] [
                            str "Write your full message:"
                        ]
                        tag "textarea" [ _class "custom-message-box"; _id "customMessageBox"; attr "placeholder" "Enter your custom message here..." ] []
                    ]
                    button [ _class "btn-ready"; attr "onclick" "imReady()" ] [
                        str "I'm Ready"
                        tag "svg" [ attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                            tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M13 10V3L4 14h7v7l9-11h-7z" ] []
                        ]
                    ]
                ]
            ]
            rawText ("<!--  Base64 Result Overlay  -->")
            div [ _class "base64-overlay"; _id "base64Overlay" ] [
                button [ _class "close-base64"; attr "onclick" "closeBase64Overlay()" ] [
                    str "✕"
                ]
                div [ _class "base64-content" ] [
                    h2 [ _class "base64-title" ] [
                        str "Your custom message is:"
                    ]
                    div [ _class "base64-block"; _id "base64Block" ] []
                    button [ _class "copy-btn"; _id "copyBtn"; attr "onclick" "copyToClipboard()" ] [
                        str "Copy to Clipboard"
                    ]
                    br []
                    br []
                    h2 [ _class "base64-title" ] [
                        p [] [
                            str "Wait, you're not done! Send this email to:"
                        ]
                        p [] [
                            str "clement.keynote-1e@icloud.com 🐢"
                        ]
                    ]
                    br []
                    br []
                    a [ _href "mailto:clement.keynote-1e@icloud.com"; attr "title" "This button should redirect you to gmail/outlook/.."; attr "target" "_blank"; attr "rel" "noopener noreferrer"; _class "phone-btn" ] [
                        tag "svg" [ attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                            tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z" ] []
                        ]
                        str "🐢 Redirects to send this email."
                    ]
                    br []
                    br []
                    br []
                    br []
                    br []
                    br []
                    br []
                    a [ _href "https://is.gd/turtleanalytics/"; attr "title" "This button sends an Analytics beacon that you visited this page, You can close the [about:blank] page that opens"; attr "target" "_blank"; attr "rel" "noopener noreferrer"; _class "phone-btn" ] [
                        tag "svg" [ attr "width" "20"; attr "height" "20"; attr "fill" "none"; attr "stroke" "currentColor"; attr "viewBox" "0 0 24 24" ] [
                            tag "path" [ attr "stroke-linecap" "round"; attr "stroke-linejoin" "round"; attr "stroke-width" "2"; attr "d" "M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z" ] []
                        ]
                        str "Send Optional Analytics Info"
                    ]
                    br []
                    br []
                    span [ attr "style" "font-size:18px; color:#666;" ] [
                        str "🐢 Thank you! Call or contact any time. Turtle Protect is a Florida-based project."
                        br []
                    ]
                ]
            ]
            script [] [
                    rawText ("""// Form Variables - storing answers as strings
        let answer1 = '';
        let answer2 = '';
        let answer3 = '';
        let answer4 = '';
        let answer5 = '';
        let answer6 = '';
        
        let currentStep = 1;
        let formData = {
            debtAmount: 41250,
            debtTypes: [],
            income: '',
            employment: '',
            frequency: '',
            email: ''
        };

        // Scroll Animation Observer
        const observerOptions = {
            threshold: 0.1,
            rootMargin: '0px 0px -50px 0px'
        };

        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('visible');
                }
            });
        }, observerOptions);

        document.querySelectorAll('.animate-on-scroll').forEach((el) => observer.observe(el));

        // FAQ Toggle
        function toggleFaq(element) {
            const item = element.parentElement;
            const isActive = item.classList.contains('active');
            
            // Close all
            document.querySelectorAll('.faq-item').forEach(faq => {
                faq.classList.remove('active');
            });
            
            // Open clicked if wasn't active
            if (!isActive) {
                item.classList.add('active');
            }
        }

        // Form Functions
        function openForm() {
            document.getElementById('formContainer').classList.add('active');
            document.body.style.overflow = 'hidden';
            updateProgress();
        }

        function closeForm() {
            document.getElementById('formContainer').classList.remove('active');
            document.body.style.overflow = '';
            // Reset form after delay
            setTimeout(() => {
                currentStep = 1;
                showStep(1);
                formData = { debtAmount: 41250, debtTypes: [], income: '', employment: '', frequency: '', email: '' };
                document.querySelectorAll('.form-option').forEach(opt => opt.classList.remove('selected'));
                document.getElementById('debtSlider').value = 41250;
                updateDebtValue(41250);
                document.getElementById('emailInput').value = '';
            }, 300);
        }

        function updateDebtValue(val) {
            formData.debtAmount = val;
            document.getElementById('debtValue').textContent = '$' + parseInt(val).toLocaleString();
        }

        function toggleDebtType(element, type) {
            element.classList.toggle('selected');
            if (element.classList.contains('selected')) {
                if (!formData.debtTypes.includes(type)) formData.debtTypes.push(type);
            } else {
                formData.debtTypes = formData.debtTypes.filter(t => t !== type);
            }
        }

        function selectIncome(element, range) {
            document.querySelectorAll('[data-step="3"] .form-option').forEach(opt => opt.classList.remove('selected'));
            element.classList.add('selected');
            formData.income = range;
        }

        function selectEmployment(element, status) {
            document.querySelectorAll('[data-step="4"] .form-option').forEach(opt => opt.classList.remove('selected'));
            element.classList.add('selected');
            formData.employment = status;
        }

        function selectFrequency(element, freq) {
            document.querySelectorAll('[data-step="5"] .form-option').forEach(opt => opt.classList.remove('selected'));
            element.classList.add('selected');
            formData.frequency = freq;
        }

        function validateEmail() {
            const email = document.getElementById('emailInput').value;
            const error = document.getElementById('emailError');
            if (!email || !email.includes('@')) {
                document.getElementById('emailInput').classList.add('error');
                error.classList.add('show');
                return false;
            }
            document.getElementById('emailInput').classList.remove('error');
            error.classList.remove('show');
            formData.email = email;
            return true;
        }

        function showStep(step) {
            document.querySelectorAll('.form-step').forEach(s => s.classList.remove('active'));
            document.querySelector(`[data-step="${step}"]`).classList.add('active');
            currentStep = step;
            updateProgress();
        }

        function updateProgress() {
            const progress = ((currentStep - 1) / 6) * 100;
            document.getElementById('progressBar').style.width = progress + '%';
        }

        function nextStep() {
            // Store current step's answer before moving
            storeCurrentAnswer();
            
            // Validation per step
            if (currentStep === 2 && formData.debtTypes.length === 0) {
                alert('Please select at least one debt type');
                return;
            }
            if (currentStep === 3 && !formData.income) {
                alert('Please select your income range');
                return;
            }
            if (currentStep === 4 && !formData.employment) {
                alert('Please select your employment status');
                return;
            }
            if (currentStep === 5 && !formData.frequency) {
                alert('Please select your pay frequency');
                return;
            }
            
            if (currentStep < 6) {
                showStep(currentStep + 1);
            }
        }

        function storeCurrentAnswer() {
            // Store answers as literal strings
            switch(currentStep) {
                case 1:
                    answer1 = '$' + parseInt(formData.debtAmount).toLocaleString();
                    break;
                case 2:
                    answer2 = formData.debtTypes.join(', ');
                    break;
                case 3:
                    answer3 = formData.income;
                    break;
                case 4:
                    answer4 = formData.employment;
                    break;
                case 5:
                    answer5 = formData.frequency;
                    break;
                case 6:
                    answer6 = document.getElementById('emailInput').value;
                    break;
            }
        }

        function finishForm() {
            // Validate email first
            if (!validateEmail()) {
                return;
            }
            
            // Store the email answer
            answer6 = document.getElementById('emailInput').value;
            
            // Hide form and show bubble overlay with summary
            document.getElementById('formContainer').classList.remove('active');
            
            // Populate the summary
            document.getElementById('summaryDebtAmount').textContent = answer1 || '-';
            document.getElementById('summaryDebtType').textContent = answer2 || '-';
            document.getElementById('summaryIncome').textContent = answer3 || '-';
            document.getElementById('summaryEmployment').textContent = answer4 || '-';
            document.getElementById('summaryFrequency').textContent = answer5 || '-';
            document.getElementById('summaryEmail').textContent = answer6 || '-';
            
            // Show bubble overlay
            document.getElementById('bubbleOverlay').classList.add('active');
            document.body.style.overflow = 'hidden';
        }

        function imReady() {
            const customMessage = document.getElementById('customMessageBox').value;
            
            // Fade out bubble overlay
            const bubbleOverlay = document.getElementById('bubbleOverlay');
            bubbleOverlay.classList.add('fade-out');
            
            // After fade out, show base64 overlay
            setTimeout(() => {
                bubbleOverlay.classList.remove('active', 'fade-out');
                
                // Encode the custom message to base64
                const encoded = btoa(unescape(encodeURIComponent("Debt Amount: " + answer1 + "—" + answer2 + ". Income: " + answer3 + ". Employment Type: " + answer4 + ". Wage Freq: " + answer5 + ". Contact: " + answer6 + ". " + customMessage)));
                
                // Display in base64 overlay
                document.getElementById('base64Block').textContent = encoded;
                document.getElementById('base64Overlay').classList.add('active');
            }, 500);
        }

        function closeBase64Overlay() {
            document.getElementById('base64Overlay').classList.remove('active');
            document.body.style.overflow = '';
            
            // Reset everything
            setTimeout(() => {
                currentStep = 1;
                showStep(1);
                formData = { debtAmount: 41250, debtTypes: [], income: '', employment: '', frequency: '', email: '' };
                document.querySelectorAll('.form-option').forEach(opt => opt.classList.remove('selected'));
                document.getElementById('debtSlider').value = 41250;
                updateDebtValue(41250);
                document.getElementById('emailInput').value = '';
                document.getElementById('customMessageBox').value = '';
                answer1 = '';
                answer2 = '';
                answer3 = '';
                answer4 = '';
                answer5 = '';
                answer6 = '';
            }, 300);
        }

        function copyToClipboard() {
            const text = document.getElementById('base64Block').textContent;
            navigator.clipboard.writeText(text).then(() => {
                const btn = document.getElementById('copyBtn');
                btn.textContent = 'Copied!';
                btn.classList.add('copied');
                setTimeout(() => {
                    btn.textContent = 'Copy to Clipboard';
                    btn.classList.remove('copied');
                }, 2000);
            });
        }

        // Close overlays on click outside
        document.getElementById('bubbleOverlay').addEventListener('click', function(e) {
            if (e.target === this) {
                // Don't close on outside click for bubble overlay
            }
        });

        document.getElementById('base64Overlay').addEventListener('click', function(e) {
            if (e.target === this) {
                closeBase64Overlay();
            }
        });

        // Header scroll effect
        window.addEventListener('scroll', () => {
            const header = document.getElementById('main-header');
            if (window.scrollY > 100) {
                header.style.boxShadow = '0 2px 20px rgba(0,0,0,0.1)';
            } else {
                header.style.boxShadow = 'none';
            }
        });""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
