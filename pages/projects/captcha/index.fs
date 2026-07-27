module ConvertedFiles.Projects.Captcha.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "2FAgamblah Test Environment"
            ]
            rawText ("""<!--  STEP 1: PASTE ALL THE CSS HERE  -->""")
            style [] [
                    rawText ("""/* ============================================
   GAMBLING AUTH OVERLAY - SCOPED CSS
   All animations prefixed with ga- to prevent 
   global namespace pollution
   ============================================ */

/* Mobile responsive - scoped */
@media screen and (max-width: 768px) {
    #gambling-auth-overlay .auth-screen {
        padding: 24px;
        max-width: 95%;
        width: 95%;
        border-radius: 16px;
        margin: 10px;
    }
    
    #gambling-auth-overlay h2 {
        font-size: 24px;
        margin-bottom: 16px;
    }
    
    #gambling-auth-overlay p.subtitle {
        font-size: 14px;
        margin-bottom: 20px;
    }
    
    #gambling-auth-overlay .wheel-wrapper {
        width: 280px;
        height: 280px;
        margin: 20px auto;
    }
    
    #gambling-auth-overlay .wheel-label {
        font-size: 12px;
    }
    
    #gambling-auth-overlay .race-track {
        padding: 12px;
        margin: 12px 0;
    }
    
    #gambling-auth-overlay .lane {
        height: 48px;
        margin: 8px 0;
    }
    
    #gambling-auth-overlay .horse {
        font-size: 28px;
        left: 40px;
    }
    
    #gambling-auth-overlay .lane-number {
        font-size: 14px;
        width: 28px;
    }
    
    #gambling-auth-overlay .lane-name {
        font-size: 12px;
        padding-left: 8px;
    }
    
    #gambling-auth-overlay .horse-selector {
        gap: 6px;
        margin: 16px 0;
    }
    
    #gambling-auth-overlay .horse-btn {
        padding: 8px 12px;
        font-size: 13px;
    }
    
    #gambling-auth-overlay .dice-container {
        gap: 20px;
        margin: 20px 0;
    }
    
    #gambling-auth-overlay .die {
        width: 70px;
        height: 70px;
        border-radius: 12px;
    }
    
    #gambling-auth-overlay .dot {
        width: 12px;
        height: 12px;
    }
    
    #gambling-auth-overlay .card {
        width: 50px;
        height: 75px;
        font-size: 14px;
    }
    
    #gambling-auth-overlay .suit {
        font-size: 24px;
    }
    
    #gambling-auth-overlay .game-table {
        padding: 16px;
        margin: 12px 0;
    }
    
    #gambling-auth-overlay .btn {
        padding: 12px 32px;
        font-size: 15px;
        width: 100%;
        margin: 8px 0;
    }
    
    #gambling-auth-overlay .controls {
        flex-direction: column;
        gap: 8px;
    }
    
    #gambling-auth-overlay .warning-box {
        font-size: 13px;
        padding: 12px;
        margin: 12px 0;
    }
    
    #gambling-auth-overlay input[type="email"],
    #gambling-auth-overlay input[type="password"] {
        padding: 12px;
        font-size: 16px;
    }
    
    #gambling-auth-overlay .password-display {
        font-size: 18px;
        padding: 16px;
    }
}

@media screen and (max-width: 380px) {
    #gambling-auth-overlay .wheel-wrapper {
        width: 240px;
        height: 240px;
    }
    
    #gambling-auth-overlay .wheel-label {
        font-size: 11px;
    }
    
    #gambling-auth-overlay .horse-btn {
        padding: 6px 10px;
        font-size: 12px;
    }
}

/* Desktop styles - ALL SCOPED with #gambling-auth-overlay */
#gambling-auth-overlay {
    position: fixed;
    top: 0; 
    left: 0; 
    width: 100vw; 
    height: 100vh;
    background: linear-gradient(135deg, #0f172a 0%, #1e3a8a 50%, #0f172a 100%);
    z-index: 999999;
    font-family: 'Inter', sans-serif;
    overflow: hidden;
    display: none;
    perspective: 1000px;
    box-sizing: border-box;
}

#gambling-auth-overlay.active { 
    display: flex; 
    justify-content: center; 
    align-items: center; 
}

#gambling-auth-overlay * {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
}

#gambling-auth-overlay .bg-particles {
    position: absolute;
    width: 100%; 
    height: 100%;
    overflow: hidden;
    pointer-events: none;
}

#gambling-auth-overlay .particle {
    position: absolute;
    width: 4px; 
    height: 4px;
    background: rgba(255,255,255,0.3);
    border-radius: 50%;
    animation: ga-float 20s infinite linear;
}

@keyframes ga-float {
    from { transform: translateY(100vh) translateX(0); opacity: 0; }
    10% { opacity: 1; }
    90% { opacity: 1; }
    to { transform: translateY(-100px) translateX(100px); opacity: 0; }
}

#gambling-auth-overlay .auth-screen {
    background: rgba(255,255,255,0.08);
    backdrop-filter: blur(20px);
    border-radius: 24px;
    padding: 48px;
    max-width: 650px;
    width: 90%;
    box-shadow: 
        0 25px 50px -12px rgba(0,0,0,0.5),
        inset 0 1px 0 rgba(255,255,255,0.1);
    border: 1px solid rgba(255,255,255,0.15);
    text-align: center;
    color: white;
    display: none;
    animation: ga-slideUp 0.6s cubic-bezier(0.16, 1, 0.3, 1);
    position: relative;
    overflow: hidden;
}

#gambling-auth-overlay .auth-screen::before {
    content: '';
    position: absolute;
    top: 0; 
    left: 0; 
    right: 0; 
    height: 1px;
    background: linear-gradient(90deg, transparent, rgba(255,255,255,0.4), transparent);
}

@keyframes ga-slideUp {
    from { opacity: 0; transform: translateY(40px) scale(0.95); }
    to { opacity: 1; transform: translateY(0) scale(1); }
}

#gambling-auth-overlay .auth-screen.active { display: block; }

#gambling-auth-overlay h2 { 
    margin-bottom: 24px; 
    font-size: 32px; 
    font-weight: 700;
    background: linear-gradient(to right, #fff, #94a3b8);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    text-shadow: 0 2px 10px rgba(0,0,0,0.2);
    letter-spacing: -0.5px;
}

#gambling-auth-overlay p.subtitle {
    color: #94a3b8;
    margin-bottom: 32px;
    font-size: 16px;
    line-height: 1.6;
}

#gambling-auth-overlay .wheel-wrapper {
    position: relative;
    width: 360px; 
    height: 360px;
    margin: 40px auto;
    filter: drop-shadow(0 20px 40px rgba(0,0,0,0.6));
}

#gambling-auth-overlay .wheel-container {
    width: 100%; 
    height: 100%;
    border-radius: 50%;
    position: relative;
    background: #1e293b;
    padding: 12px;
    box-shadow: 
        inset 0 0 20px rgba(0,0,0,0.5),
        0 0 0 2px rgba(255,255,255,0.1);
}

#gambling-auth-overlay .wheel {
    width: 100%; 
    height: 100%;
    border-radius: 50%;
    position: relative;
    background: conic-gradient(
        from 0deg,
        #ff006e 0deg 45deg,
        #64748b 45deg 90deg,
        #ef4444 90deg 135deg,
        #f97316 135deg 180deg,
        #eab308 180deg 225deg,
        #22c55e 225deg 270deg,
        #3b82f6 270deg 315deg,
        #a855f7 315deg 360deg
    );
    box-shadow: inset 0 0 30px rgba(0,0,0,0.4);
    transition: transform 6s cubic-bezier(0.1, 0.7, 0.1, 1);
}

#gambling-auth-overlay .wheel-label {
    position: absolute;
    font-weight: 800;
    font-size: 15px;
    color: white;
    text-shadow: 0 2px 4px rgba(0,0,0,0.9);
    transform-origin: center center;
    pointer-events: none;
    z-index: 5;
    width: 40px;
    text-align: center;
}

#gambling-auth-overlay .wheel-center {
    position: absolute; 
    top: 50%; 
    left: 50%;
    transform: translate(-50%, -50%);
    width: 55px; 
    height: 55px;
    background: linear-gradient(145deg, #334155, #1e293b);
    border-radius: 50%;
    border: 4px solid #475569;
    z-index: 10;
    box-shadow: 0 4px 15px rgba(0,0,0,0.5);
}

#gambling-auth-overlay .wheel-pointer {
    position: absolute; 
    top: -25px; 
    left: 50%;
    transform: translateX(-50%);
    z-index: 15;
    filter: drop-shadow(0 4px 6px rgba(0,0,0,0.4));
}

#gambling-auth-overlay .wheel-pointer::before {
    content: '▲';
    font-size: 45px;
    color: #fbbf24;
    text-shadow: 0 2px 8px rgba(0,0,0,0.6);
}

#gambling-auth-overlay .progress-wrapper {
    margin-top: 32px;
    opacity: 0;
    transform: translateY(10px);
    transition: all 0.5s ease;
}

#gambling-auth-overlay .progress-wrapper.visible {
    opacity: 1;
    transform: translateY(0);
}

#gambling-auth-overlay .progress-label {
    display: flex;
    justify-content: space-between;
    margin-bottom: 12px;
    font-size: 14px;
    color: #94a3b8;
    font-weight: 500;
}

#gambling-auth-overlay .progress-container {
    width: 100%; 
    height: 12px;
    background: rgba(0,0,0,0.3);
    border-radius: 6px;
    overflow: hidden;
    box-shadow: inset 0 2px 4px rgba(0,0,0,0.3);
}

#gambling-auth-overlay .progress-bar {
    height: 100%; 
    width: 0%;
    background: linear-gradient(90deg, #3b82f6, #06b6d4, #3b82f6);
    background-size: 200% 100%;
    animation: ga-shimmer 2s infinite linear;
    border-radius: 6px;
    box-shadow: 0 0 20px rgba(59, 130, 246, 0.5);
    transition: width linear;
}

@keyframes ga-shimmer {
    0% { background-position: 200% 0; }
    100% { background-position: -200% 0; }
}

#gambling-auth-overlay .btn {
    background: linear-gradient(135deg, #3b82f6 0%, #2563eb 100%);
    color: white;
    border: none;
    padding: 16px 48px;
    font-size: 17px;
    border-radius: 12px;
    cursor: pointer;
    margin: 12px 8px;
    transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
    font-weight: 600;
    box-shadow: 0 4px 6px -1px rgba(59, 130, 246, 0.3);
    position: relative;
    overflow: hidden;
}

#gambling-auth-overlay .btn::before {
    content: '';
    position: absolute;
    top: 0; 
    left: -100%;
    width: 100%; 
    height: 100%;
    background: linear-gradient(90deg, transparent, rgba(255,255,255,0.2), transparent);
    transition: 0.5s;
}

#gambling-auth-overlay .btn:hover:not(:disabled) { 
    transform: translateY(-2px) scale(1.02);
    box-shadow: 0 10px 20px -5px rgba(59, 130, 246, 0.4);
}

#gambling-auth-overlay .btn:hover:not(:disabled)::before { left: 100%; }

#gambling-auth-overlay .btn:disabled { 
    background: #475569; 
    cursor: not-allowed; 
    opacity: 0.6;
    box-shadow: none;
}

#gambling-auth-overlay .btn-success { 
    background: linear-gradient(135deg, #22c55e 0%, #16a34a 100%);
    box-shadow: 0 4px 6px -1px rgba(34, 197, 94, 0.3);
}

#gambling-auth-overlay .btn-success:hover:not(:disabled) { 
    box-shadow: 0 10px 20px -5px rgba(34, 197, 94, 0.4);
}

#gambling-auth-overlay .btn-danger { 
    background: linear-gradient(135deg, #ef4444 0%, #dc2626 100%);
    box-shadow: 0 4px 6px -1px rgba(239, 68, 68, 0.3);
}

#gambling-auth-overlay .warning-box {
    background: rgba(251, 191, 36, 0.1);
    border-left: 4px solid #fbbf24;
    padding: 16px;
    margin: 20px 0;
    text-align: left;
    border-radius: 0 8px 8px 0;
    color: #fcd34d;
    font-size: 14px;
    line-height: 1.6;
}

#gambling-auth-overlay .game-table {
    background: linear-gradient(145deg, #166534 0%, #14532d 100%);
    border-radius: 20px;
    padding: 28px;
    margin: 24px 0;
    border: 4px solid #78350f;
    box-shadow: 
        inset 0 0 40px rgba(0,0,0,0.4),
        0 20px 40px rgba(0,0,0,0.4);
    position: relative;
}

#gambling-auth-overlay .game-table::before {
    content: '';
    position: absolute;
    top: 10px; 
    left: 10px; 
    right: 10px; 
    bottom: 10px;
    border: 2px dashed rgba(255,255,255,0.1);
    border-radius: 12px;
    pointer-events: none;
}

#gambling-auth-overlay .hand { margin: 20px 0; }

#gambling-auth-overlay .hand-label { 
    font-weight: 700; 
    margin-bottom: 12px; 
    color: #fbbf24; 
    font-size: 18px;
    text-transform: uppercase;
    letter-spacing: 1px;
    text-shadow: 0 2px 4px rgba(0,0,0,0.5);
}

#gambling-auth-overlay .cards { 
    display: flex; 
    justify-content: center; 
    gap: 12px; 
    flex-wrap: wrap; 
    min-height: 100px;
    perspective: 600px;
}

#gambling-auth-overlay .card {
    width: 70px; 
    height: 100px;
    background: linear-gradient(145deg, #ffffff 0%, #f1f5f9 100%);
    border-radius: 10px;
    display: flex; 
    flex-direction: column;
    justify-content: space-between; 
    align-items: center;
    font-weight: 800; 
    color: #1e293b;
    box-shadow: 
        0 4px 6px -1px rgba(0,0,0,0.3),
        0 2px 4px -1px rgba(0,0,0,0.2),
        inset 0 1px 0 rgba(255,255,255,0.8);
    border: 1px solid #cbd5e1;
    position: relative;
    animation: ga-dealCard 0.5s cubic-bezier(0.34, 1.56, 0.64, 1);
    transform-style: preserve-3d;
}

@keyframes ga-dealCard {
    0% { transform: translateY(-100px) rotateY(180deg) scale(0.5); opacity: 0; }
    100% { transform: translateY(0) rotateY(0deg) scale(1); opacity: 1; }
}

#gambling-auth-overlay .card.red { color: #dc2626; }

#gambling-auth-overlay .card.hidden { 
    background: linear-gradient(145deg, #3b82f6 0%, #1d4ed8 100%);
    border-color: #1e40af;
}

#gambling-auth-overlay .card.hidden::before {
    content: '?';
    font-size: 32px;
    color: white;
    position: absolute;
    top: 50%; 
    left: 50%;
    transform: translate(-50%, -50%);
    opacity: 0.5;
}

#gambling-auth-overlay .card-top { 
    align-self: flex-start; 
    margin: 6px 0 0 6px; 
    font-size: 16px; 
}

#gambling-auth-overlay .card-bottom { 
    align-self: flex-end; 
    margin: 0 6px 6px 0; 
    font-size: 16px; 
    transform: rotate(180deg); 
}

#gambling-auth-overlay .suit { 
    font-size: 32px; 
    position: absolute; 
    top: 50%; 
    left: 50%; 
    transform: translate(-50%, -50%); 
}

#gambling-auth-overlay .result-banner {
    padding: 16px; 
    margin: 20px 0;
    border-radius: 12px; 
    font-weight: 700;
    display: none;
    animation: ga-bounceIn 0.5s;
    font-size: 18px;
}

@keyframes ga-bounceIn {
    0% { transform: scale(0.3); opacity: 0; }
    50% { transform: scale(1.05); }
    70% { transform: scale(0.9); }
    100% { transform: scale(1); opacity: 1; }
}

#gambling-auth-overlay .result-banner.win { 
    background: rgba(34, 197, 94, 0.2); 
    border: 2px solid #22c55e; 
    color: #86efac;
    display: block; 
}

#gambling-auth-overlay .result-banner.lose { 
    background: rgba(239, 68, 68, 0.2); 
    border: 2px solid #ef4444; 
    color: #fca5a5;
    display: block; 
}

#gambling-auth-overlay .controls { 
    display: flex; 
    justify-content: center; 
    gap: 16px; 
    margin-top: 24px; 
}

#gambling-auth-overlay .race-track {
    background: linear-gradient(180deg, #14532d 0%, #166534 100%);
    border: 4px solid #fbbf24;
    border-radius: 16px;
    padding: 24px;
    margin: 24px 0;
    position: relative;
    box-shadow: 
        inset 0 0 40px rgba(0,0,0,0.4),
        0 20px 40px rgba(0,0,0,0.3);
    overflow: hidden;
}

#gambling-auth-overlay .lane {
    height: 60px; 
    background: rgba(255,255,255,0.05);
    margin: 12px 0; 
    border-radius: 8px;
    position: relative; 
    overflow: hidden;
    border: 1px solid rgba(255,255,255,0.1);
    display: flex; 
    align-items: center;
    padding-left: 16px;
    box-shadow: inset 0 2px 4px rgba(0,0,0,0.2);
}

#gambling-auth-overlay .lane:nth-child(odd) { background: rgba(255,255,255,0.08); }

#gambling-auth-overlay .lane-number { 
    width: 36px; 
    color: #fbbf24; 
    font-weight: 900;
    font-size: 18px;
    text-shadow: 0 2px 4px rgba(0,0,0,0.5);
}

#gambling-auth-overlay .lane-name { 
    flex: 1; 
    text-align: left; 
    padding-left: 16px;
    font-weight: 600;
    color: rgba(255,255,255,0.9);
    font-size: 15px;
}

#gambling-auth-overlay .horse {
    position: absolute; 
    left: 60px;
    font-size: 36px; 
    transition: left 0.4s cubic-bezier(0.4, 0, 0.2, 1);
    filter: drop-shadow(2px 4px 6px rgba(0,0,0,0.5));
    z-index: 10;
}

#gambling-auth-overlay .horse.flip {
    transform: scaleX(-1);
}

#gambling-auth-overlay .finish-line {
    position: absolute; 
    right: 30px; 
    top: 24px; 
    bottom: 24px;
    width: 6px; 
    background: repeating-linear-gradient(
        0deg, 
        rgba(255,255,255,0.8) 0px, 
        rgba(255,255,255,0.8) 10px, 
        transparent 10px, 
        transparent 20px
    );
    opacity: 0.6;
    border-radius: 3px;
}

#gambling-auth-overlay .dust {
    position: absolute;
    font-size: 20px;
    opacity: 0;
    pointer-events: none;
    animation: ga-dust 1s ease-out forwards;
}

@keyframes ga-dust {
    0% { transform: translateX(0) scale(0.5); opacity: 0.6; }
    100% { transform: translateX(-40px) scale(1.2); opacity: 0; }
}

#gambling-auth-overlay .horse-selector {
    display: flex; 
    justify-content: center; 
    gap: 12px;
    margin: 28px 0; 
    flex-wrap: wrap;
}

#gambling-auth-overlay .horse-btn {
    padding: 12px 24px; 
    border: 2px solid rgba(255,255,255,0.2);
    background: rgba(255,255,255,0.05); 
    color: white;
    border-radius: 12px; 
    cursor: pointer;
    transition: all 0.3s;
    font-weight: 600;
    font-size: 15px;
    display: flex;
    align-items: center;
    gap: 8px;
}

#gambling-auth-overlay .horse-btn:hover:not(.selected):not(:disabled) { 
    background: rgba(255,255,255,0.15); 
    border-color: #fbbf24;
    transform: translateY(-2px);
}

#gambling-auth-overlay .horse-btn.selected { 
    background: linear-gradient(135deg, #fbbf24 0%, #f59e0b 100%); 
    color: #0f172a; 
    border-color: #fbbf24; 
    font-weight: 700;
    box-shadow: 0 4px 12px rgba(251, 191, 36, 0.3);
    transform: scale(1.05);
}

#gambling-auth-overlay .horse-btn:disabled {
    opacity: 0.4;
    cursor: not-allowed;
}

#gambling-auth-overlay .dice-container {
    display: flex; 
    justify-content: center; 
    gap: 40px;
    margin: 40px 0; 
    align-items: center;
}

#gambling-auth-overlay .die-wrapper {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 12px;
}

#gambling-auth-overlay .die-label {
    font-size: 14px;
    color: #94a3b8;
    font-weight: 600;
    text-transform: uppercase;
    letter-spacing: 1px;
}

#gambling-auth-overlay .die {
    width: 100px; 
    height: 100px;
    background: linear-gradient(145deg, #ffffff 0%, #e2e8f0 100%);
    border-radius: 20px;
    position: relative;
    box-shadow: 
        0 10px 30px -5px rgba(0,0,0,0.3),
        inset 0 -5px 10px rgba(0,0,0,0.1),
        inset 0 1px 0 rgba(255,255,255,1);
    border: 2px solid #cbd5e1;
    display: flex; 
    justify-content: center; 
    align-items: center;
}

#gambling-auth-overlay .die-face {
    width: 100%;
    height: 100%;
    position: relative;
    display: none;
}

#gambling-auth-overlay .die-face.active {
    display: block;
}

#gambling-auth-overlay .dot {
    width: 18px; 
    height: 18px;
    background: linear-gradient(145deg, #1e293b 0%, #0f172a 100%);
    border-radius: 50%;
    position: absolute; 
    box-shadow: inset 0 2px 4px rgba(0,0,0,0.5);
}

#gambling-auth-overlay .face-1 .dot:nth-child(1) { 
    top: 50%; 
    left: 50%; 
    transform: translate(-50%, -50%); 
    width: 24px; 
    height: 24px; 
    background: #dc2626; 
}

#gambling-auth-overlay .face-2 .dot:nth-child(1) { top: 25%; left: 25%; }
#gambling-auth-overlay .face-2 .dot:nth-child(2) { bottom: 25%; right: 25%; }

#gambling-auth-overlay .face-3 .dot:nth-child(1) { top: 25%; left: 25%; }
#gambling-auth-overlay .face-3 .dot:nth-child(2) { top: 50%; left: 50%; transform: translate(-50%, -50%); }
#gambling-auth-overlay .face-3 .dot:nth-child(3) { bottom: 25%; right: 25%; }

#gambling-auth-overlay .face-4 .dot:nth-child(1) { top: 25%; left: 25%; }
#gambling-auth-overlay .face-4 .dot:nth-child(2) { top: 25%; right: 25%; }
#gambling-auth-overlay .face-4 .dot:nth-child(3) { bottom: 25%; left: 25%; }
#gambling-auth-overlay .face-4 .dot:nth-child(4) { bottom: 25%; right: 25%; }

#gambling-auth-overlay .face-5 .dot:nth-child(1) { top: 25%; left: 25%; }
#gambling-auth-overlay .face-5 .dot:nth-child(2) { top: 25%; right: 25%; }
#gambling-auth-overlay .face-5 .dot:nth-child(3) { bottom: 25%; left: 25%; }
#gambling-auth-overlay .face-5 .dot:nth-child(4) { bottom: 25%; right: 25%; }
#gambling-auth-overlay .face-5 .dot:nth-child(5) { top: 50%; left: 50%; transform: translate(-50%, -50%); }

#gambling-auth-overlay .face-6 .dot:nth-child(1) { top: 25%; left: 25%; }
#gambling-auth-overlay .face-6 .dot:nth-child(2) { top: 25%; right: 25%; }
#gambling-auth-overlay .face-6 .dot:nth-child(3) { top: 50%; left: 25%; transform: translateY(-50%); }
#gambling-auth-overlay .face-6 .dot:nth-child(4) { top: 50%; right: 25%; transform: translateY(-50%); }
#gambling-auth-overlay .face-6 .dot:nth-child(5) { bottom: 25%; left: 25%; }
#gambling-auth-overlay .face-6 .dot:nth-child(6) { bottom: 25%; right: 25%; }

@keyframes ga-tumble {
    0% { transform: rotate(0deg) translateY(0); }
    25% { transform: rotate(-180deg) translateY(-30px); }
    50% { transform: rotate(-360deg) translateY(0); }
    75% { transform: rotate(-540deg) translateY(-20px); }
    100% { transform: rotate(-720deg) translateY(0); }
}

#gambling-auth-overlay .rolling { animation: ga-tumble 0.8s ease-in-out; }

#gambling-auth-overlay .probability { 
    font-size: 14px; 
    color: #fbbf24; 
    margin-top: 16px;
    font-weight: 600;
    opacity: 0.9;
}

#gambling-auth-overlay .success-icon {
    width: 80px; 
    height: 80px;
    background: linear-gradient(135deg, #22c55e 0%, #16a34a 100%);
    border-radius: 50%;
    display: inline-flex; 
    justify-content: center; 
    align-items: center;
    font-size: 40px; 
    margin-bottom: 24px;
    box-shadow: 0 10px 30px rgba(34, 197, 94, 0.4);
    animation: ga-scaleIn 0.6s cubic-bezier(0.34, 1.56, 0.64, 1);
}

@keyframes ga-scaleIn {
    0% { transform: scale(0) rotate(-180deg); }
    100% { transform: scale(1) rotate(0deg); }
}

#gambling-auth-overlay .password-display {
    background: rgba(0,0,0,0.3);
    border: 2px solid rgba(255,255,255,0.1);
    border-radius: 12px;
    padding: 20px;
    margin: 24px 0;
    font-family: 'Courier New', monospace;
    font-size: 24px;
    letter-spacing: 2px;
    color: #fbbf24;
    word-break: break-all;
    position: relative;
    overflow: hidden;
}

#gambling-auth-overlay .password-display::before {
    content: '';
    position: absolute;
    top: 0; 
    left: -100%;
    width: 100%; 
    height: 100%;
    background: linear-gradient(90deg, transparent, rgba(255,255,255,0.1), transparent);
    animation: ga-shine 3s infinite;
}

@keyframes ga-shine {
    0% { left: -100%; }
    20% { left: 100%; }
    100% { left: 100%; }
}

#gambling-auth-overlay .attempts-counter { 
    color: #94a3b8; 
    font-size: 14px; 
    margin-top: 16px;
    font-weight: 500;
}

#gambling-auth-overlay input[type="email"],
#gambling-auth-overlay input[type="password"] {
    width: 100%; 
    padding: 14px; 
    margin: 10px 0;
    border: 1px solid rgba(255,255,255,0.2);
    background: rgba(0,0,0,0.3);
    border-radius: 10px; 
    color: white;
    font-size: 16px; 
    outline: none;
}

#gambling-auth-overlay input::placeholder { 
    color: rgba(255,255,255,0.4); 
}

#gambling-auth-overlay .divider {
    height: 1px;
    background: linear-gradient(90deg, transparent, rgba(255,255,255,0.2), transparent);
    margin: 32px 0;
}


/* ============================================
   RUSSIAN ROULETTE SCREEN - NEW ADDITIONS
   ============================================ */

/* Mobile responsive for RR */
@media screen and (max-width: 768px) {
    #gambling-auth-overlay .rr-layout {
        flex-direction: column !important;
    }
    #gambling-auth-overlay .rr-left-pane,
    #gambling-auth-overlay .rr-right-pane {
        width: 100% !important;
        min-height: 200px;
    }
    #gambling-auth-overlay .rr-barrel-container {
        width: 200px !important;
        height: 200px !important;
    }
    #gambling-auth-overlay .rr-stick-figure {
        font-size: 80px !important;
    }
    #gambling-auth-overlay .rr-gun {
        font-size: 40px !important;
    }
}
@media screen and (max-width: 380px) {
    #gambling-auth-overlay .rr-barrel-container {
        width: 160px !important;
        height: 160px !important;
    }
}

#gambling-auth-overlay .rr-layout {
    display: flex;
    flex-direction: row;
    gap: 32px;
    align-items: stretch;
    min-height: 420px;
}
#gambling-auth-overlay .rr-left-pane {
    flex: 1;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    background: rgba(0,0,0,0.2);
    border-radius: 16px;
    padding: 24px;
    position: relative;
    min-width: 200px;
}
#gambling-auth-overlay .rr-right-pane {
    flex: 1.2;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 20px;
}
#gambling-auth-overlay .rr-stick-figure-container {
    position: relative;
    width: 160px;
    height: 200px;
    display: flex;
    align-items: flex-end;
    justify-content: center;
}
#gambling-auth-overlay .rr-stick-figure {
    font-size: 120px;
    line-height: 1;
    transition: all 0.6s cubic-bezier(0.68, -0.55, 0.265, 1.55);
    filter: drop-shadow(0 4px 8px rgba(0,0,0,0.5));
    position: relative;
    z-index: 2;
}
#gambling-auth-overlay .rr-stick-figure.alive {
    animation: ga-breathe 2s ease-in-out infinite;
}
@keyframes ga-breathe {
    0%, 100% { transform: scale(1) translateY(0); }
    50% { transform: scale(1.02) translateY(-3px); }
}
#gambling-auth-overlay .rr-stick-figure.dead {
    transform: rotate(90deg) translateY(40px) translateX(20px);
    filter: grayscale(1) brightness(0.5);
    animation: ga-fall 0.8s cubic-bezier(0.68, -0.55, 0.265, 1.55) forwards;
}
@keyframes ga-fall {
    0% { transform: rotate(0deg) translateY(0); }
    30% { transform: rotate(-15deg) translateY(-10px); }
    100% { transform: rotate(90deg) translateY(50px) translateX(30px); }
}
#gambling-auth-overlay .rr-gun-container {
    position: absolute;
    top: 50%;
    right: -20px;
    transform: translateY(-50%);
    z-index: 3;
}
#gambling-auth-overlay .rr-gun {
    font-size: 60px;
    filter: drop-shadow(2px 4px 6px rgba(0,0,0,0.6));
    transition: all 0.3s ease;
}
#gambling-auth-overlay .rr-gun.recoil {
    animation: ga-recoil 0.3s ease-out;
}
@keyframes ga-recoil {
    0% { transform: translateX(0) rotate(0deg); }
    20% { transform: translateX(-15px) rotate(-10deg); }
    100% { transform: translateX(0) rotate(0deg); }
}
#gambling-auth-overlay .rr-muzzle-flash {
    position: absolute;
    top: 50%;
    right: -40px;
    transform: translateY(-50%);
    font-size: 40px;
    opacity: 0;
    z-index: 4;
    pointer-events: none;
}
#gambling-auth-overlay .rr-muzzle-flash.flash {
    animation: ga-muzzleFlash 0.15s ease-out;
}
@keyframes ga-muzzleFlash {
    0% { opacity: 1; transform: translateY(-50%) scale(0.5); }
    50% { opacity: 1; transform: translateY(-50%) scale(1.5); }
    100% { opacity: 0; transform: translateY(-50%) scale(2); }
}
#gambling-auth-overlay .rr-barrel-wrapper {
    position: relative;
    width: 280px;
    height: 280px;
    margin: 0 auto;
}
#gambling-auth-overlay .rr-barrel-container {
    width: 100%;
    height: 100%;
    border-radius: 50%;
    position: relative;
    background: radial-gradient(circle at 40% 40%, #4a4a4a, #1a1a1a);
    padding: 16px;
    box-shadow: inset 0 0 30px rgba(0,0,0,0.8), 0 0 0 3px rgba(255,255,255,0.1), 0 15px 40px rgba(0,0,0,0.6);
    border: 2px solid #333;
}
#gambling-auth-overlay .rr-barrel {
    width: 100%;
    height: 100%;
    border-radius: 50%;
    position: relative;
    background: conic-gradient(
        from 0deg,
        #2a2a2a 0deg 60deg,
        #3d3d3d 60deg 120deg,
        #2a2a2a 120deg 180deg,
        #3d3d3d 180deg 240deg,
        #2a2a2a 240deg 300deg,
        #3d3d3d 300deg 360deg
    );
    box-shadow: inset 0 0 20px rgba(0,0,0,0.6);
    transition: transform 3s cubic-bezier(0.1, 0.7, 0.1, 1);
}
#gambling-auth-overlay .rr-chamber {
    position: absolute;
    width: 36px;
    height: 36px;
    border-radius: 50%;
    background: radial-gradient(circle at 30% 30%, #555, #222);
    border: 2px solid #1a1a1a;
    box-shadow: inset 0 2px 4px rgba(0,0,0,0.5), 0 1px 0 rgba(255,255,255,0.05);
    transform-origin: center center;
}
#gambling-auth-overlay .rr-chamber.loaded {
    background: radial-gradient(circle at 30% 30%, #fbbf24, #b45309);
    box-shadow: inset 0 2px 4px rgba(0,0,0,0.5), 0 0 10px rgba(251, 191, 36, 0.3);
}
#gambling-auth-overlay .rr-chamber.fired {
    background: radial-gradient(circle at 30% 30%, #ef4444, #7f1d1d);
    box-shadow: inset 0 2px 4px rgba(0,0,0,0.5), 0 0 15px rgba(239, 68, 68, 0.4);
}
#gambling-auth-overlay .rr-barrel-center {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 50px;
    height: 50px;
    background: radial-gradient(circle at 40% 40%, #666, #333);
    border-radius: 50%;
    border: 3px solid #444;
    z-index: 10;
    box-shadow: 0 4px 10px rgba(0,0,0,0.5);
}
#gambling-auth-overlay .rr-barrel-center::after {
    content: '';
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 20px;
    height: 20px;
    background: radial-gradient(circle at 40% 40%, #888, #555);
    border-radius: 50%;
    border: 1px solid #333;
}
#gambling-auth-overlay .rr-spinning {
    animation: ga-barrelSpin 3s cubic-bezier(0.1, 0.7, 0.1, 1) forwards;
}
@keyframes ga-barrelSpin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(var(--rr-spin-degrees, 1800deg)); }
}
#gambling-auth-overlay .rr-chamber:nth-child(1) { left: 50%; top: 12%; transform: translate(-50%, -50%); }
#gambling-auth-overlay .rr-chamber:nth-child(2) { right: 12%; top: 32%; transform: translate(50%, -50%); }
#gambling-auth-overlay .rr-chamber:nth-child(3) { right: 12%; bottom: 32%; transform: translate(50%, 50%); }
#gambling-auth-overlay .rr-chamber:nth-child(4) { left: 50%; bottom: 12%; transform: translate(-50%, 50%); }
#gambling-auth-overlay .rr-chamber:nth-child(5) { left: 12%; bottom: 32%; transform: translate(-50%, 50%); }
#gambling-auth-overlay .rr-chamber:nth-child(6) { left: 12%; top: 32%; transform: translate(-50%, -50%); }
#gambling-auth-overlay .rr-status {
    font-size: 14px;
    color: #94a3b8;
    margin-top: 12px;
    font-weight: 500;
    min-height: 20px;
}
#gambling-auth-overlay .rr-status.danger {
    color: #ef4444;
    font-weight: 700;
}
#gambling-auth-overlay .rr-status.safe {
    color: #22c55e;
    font-weight: 700;
}
#gambling-auth-overlay .rr-btn-group {
    display: flex;
    flex-direction: column;
    gap: 12px;
    width: 100%;
    max-width: 220px;
}
#gambling-auth-overlay .rr-btn {
    background: linear-gradient(135deg, #7c2d12 0%, #451a03 100%);
    color: white;
    border: 2px solid #92400e;
    padding: 16px 24px;
    font-size: 16px;
    border-radius: 12px;
    cursor: pointer;
    transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
    font-weight: 700;
    box-shadow: 0 4px 15px rgba(124, 45, 18, 0.4);
    position: relative;
    overflow: hidden;
    width: 100%;
}
#gambling-auth-overlay .rr-btn:hover:not(:disabled) {
    transform: translateY(-2px) scale(1.02);
    box-shadow: 0 8px 25px rgba(124, 45, 18, 0.5);
    border-color: #fbbf24;
}
#gambling-auth-overlay .rr-btn:disabled {
    opacity: 0.4;
    cursor: not-allowed;
    box-shadow: none;
}
#gambling-auth-overlay .rr-btn-icon {
    font-size: 20px;
    margin-right: 8px;
}
#gambling-auth-overlay .rr-shake {
    animation: ga-cameraShake 0.5s cubic-bezier(0.36, 0.07, 0.19, 0.97) both;
}
@keyframes ga-cameraShake {
    0%, 100% { transform: translate(0, 0) rotate(0deg); }
    10% { transform: translate(-8px, -4px) rotate(-1deg); }
    20% { transform: translate(8px, 4px) rotate(1deg); }
    30% { transform: translate(-6px, 6px) rotate(0deg); }
    40% { transform: translate(6px, -6px) rotate(1deg); }
    50% { transform: translate(-4px, 4px) rotate(-1deg); }
    60% { transform: translate(4px, -4px) rotate(0deg); }
    70% { transform: translate(-2px, 2px) rotate(1deg); }
    80% { transform: translate(2px, -2px) rotate(-1deg); }
    90% { transform: translate(-1px, 1px) rotate(0deg); }
}
#gambling-auth-overlay .rr-screen-flash {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(255, 50, 50, 0.3);
    pointer-events: none;
    opacity: 0;
    z-index: 100;
    border-radius: 24px;
}
#gambling-auth-overlay .rr-screen-flash.active {
    animation: ga-screenFlash 0.3s ease-out;
}
@keyframes ga-screenFlash {
    0% { opacity: 1; }
    100% { opacity: 0; }
}
#gambling-auth-overlay .rr-bullet-hole {
    position: absolute;
    width: 12px;
    height: 12px;
    background: radial-gradient(circle, #000 30%, #333 60%, transparent 70%);
    border-radius: 50%;
    opacity: 0;
    z-index: 5;
    pointer-events: none;
}
#gambling-auth-overlay .rr-bullet-hole.show {
    opacity: 1;
    animation: ga-bulletHole 0.3s ease-out;
}
@keyframes ga-bulletHole {
    0% { transform: scale(0); opacity: 0; }
    50% { transform: scale(1.5); opacity: 1; }
    100% { transform: scale(1); opacity: 1; }
}
#gambling-auth-overlay .rr-result {
    padding: 16px;
    margin: 16px 0;
    border-radius: 12px;
    font-weight: 700;
    font-size: 16px;
    display: none;
    animation: ga-bounceIn 0.5s;
}
#gambling-auth-overlay .rr-result.show {
    display: block;
}
#gambling-auth-overlay .rr-result.bang {
    background: rgba(239, 68, 68, 0.2);
    border: 2px solid #ef4444;
    color: #fca5a5;
}
#gambling-auth-overlay .rr-result.click {
    background: rgba(34, 197, 94, 0.2);
    border: 2px solid #22c55e;
    color: #86efac;
}
#gambling-auth-overlay .rr-chamber-indicator {
    display: flex;
    justify-content: center;
    gap: 8px;
    margin: 12px 0;
}
#gambling-auth-overlay .rr-chamber-dot {
    width: 12px;
    height: 12px;
    border-radius: 50%;
    background: #334155;
    border: 1px solid #475569;
    transition: all 0.3s ease;
}
#gambling-auth-overlay .rr-chamber-dot.active {
    background: #fbbf24;
    box-shadow: 0 0 8px rgba(251, 191, 36, 0.5);
}
#gambling-auth-overlay .rr-chamber-dot.empty {
    background: #1e293b;
    border-color: #334155;
}
#gambling-auth-overlay .placeholder-screen {
    background: rgba(255,255,255,0.05);
    border: 2px dashed rgba(255,255,255,0.1);
    border-radius: 16px;
    padding: 60px 40px;
    text-align: center;
    color: #64748b;
}
#gambling-auth-overlay .placeholder-screen .placeholder-icon {
    font-size: 64px;
    margin-bottom: 24px;
    opacity: 0.5;
}
#gambling-auth-overlay .placeholder-screen h3 {
    font-size: 24px;
    color: #94a3b8;
    margin-bottom: 12px;
}
#gambling-auth-overlay .placeholder-screen p {
    font-size: 14px;
    color: #64748b;
}

    

#gambling-auth-overlay .placeholder-screen {
    background: rgba(255,255,255,0.05);
    border: 2px dashed rgba(255,255,255,0.1);
    border-radius: 16px;
    padding: 60px 40px;
    text-align: center;
    color: #64748b;
}
#gambling-auth-overlay .placeholder-screen .placeholder-icon {
    font-size: 64px;
    margin-bottom: 24px;
    opacity: 0.5;
}
#gambling-auth-overlay .placeholder-screen h3 {
    font-size: 24px;
    color: #94a3b8;
    margin-bottom: 12px;
}
#gambling-auth-overlay .placeholder-screen p {
    font-size: 14px;
    color: #64748b;
}

    

/* ============================================
   FINAL GAME - GREY SLATE SMOKE DESIGN
   ============================================ */

/* Full-bleed override for final game screen */
#gambling-auth-overlay #finalgame-screen {
    position: absolute;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    max-width: none;
    border-radius: 0;
    padding: 0;
    background: linear-gradient(180deg, #2a2a2e 0%, #1e1e22 50%, #141418 100%);
    border: none;
    box-shadow: none;
    backdrop-filter: none;
    overflow: hidden;
    display: none;
    animation: none;
}
#gambling-auth-overlay #finalgame-screen.active {
    display: block;
}
#gambling-auth-overlay #finalgame-screen::before {
    display: none;
}

/* Smoke container */
#gambling-auth-overlay .smoke-container {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 1;
    pointer-events: none;
    overflow: hidden;
}

/* Smoke layers */
#gambling-auth-overlay .smoke-layer {
    position: absolute;
    width: 200%;
    height: 200%;
    top: -50%;
    left: -50%;
    background:
        radial-gradient(ellipse at 30% 60%, rgba(80,80,90,0.2) 0%, transparent 50%),
        radial-gradient(ellipse at 70% 40%, rgba(60,60,70,0.15) 0%, transparent 50%),
        radial-gradient(ellipse at 50% 80%, rgba(70,70,80,0.12) 0%, transparent 50%);
    animation: ga-smokeDrift 25s ease-in-out infinite;
    filter: blur(80px);
}
#gambling-auth-overlay .smoke-layer:nth-child(2) {
    animation-delay: -8s;
    animation-duration: 30s;
    opacity: 0.6;
}
#gambling-auth-overlay .smoke-layer:nth-child(3) {
    animation-delay: -16s;
    animation-duration: 22s;
    opacity: 0.4;
}
@keyframes ga-smokeDrift {
    0%, 100% { transform: translate(0, 0) rotate(0deg) scale(1); }
    25% { transform: translate(4%, -3%) rotate(1deg) scale(1.08); }
    50% { transform: translate(-3%, 4%) rotate(-1deg) scale(0.95); }
    75% { transform: translate(2%, 2%) rotate(0.5deg) scale(1.04); }
}

/* Fade overlay for cinematic sequence */
#gambling-auth-overlay .fade-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: #000;
    z-index: 10;
    opacity: 0;
    pointer-events: none;
    transition: opacity 2s ease;
}
#gambling-auth-overlay .fade-overlay.active {
    opacity: 1;
    pointer-events: all;
}
#gambling-auth-overlay .fade-overlay.hold {
    opacity: 1;
    transition: none;
}

/* Cinematic text */
#gambling-auth-overlay .cinematic-text {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    z-index: 11;
    font-size: 42px;
    font-weight: 300;
    color: rgba(255,255,255,0.88);
    text-align: center;
    letter-spacing: 6px;
    font-family: 'Cinzel', 'Georgia', 'Times New Roman', serif;
    text-shadow: 0 0 60px rgba(255,255,255,0.12);
    opacity: 0;
    transition: opacity 2s ease;
    white-space: nowrap;
    pointer-events: none;
}
#gambling-auth-overlay .cinematic-text.visible {
    opacity: 1;
}

/* Full-screen door */
#gambling-auth-overlay .door-fullscreen {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 5;
    opacity: 0;
    transition: opacity 2s ease;
    overflow: hidden;
    display: flex;
    align-items: center;
    justify-content: center;
}
#gambling-auth-overlay .door-fullscreen.visible {
    opacity: 1;
}
#gambling-auth-overlay .door-fullscreen img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    filter: contrast(1.1) brightness(0.6);
}

/* Door content - input area at bottom */
#gambling-auth-overlay .door-content {
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    z-index: 6;
    display: flex;
    flex-direction: column;
    align-items: center;
    padding-bottom: 50px;
    padding-top: 30px;
    opacity: 0;
    transition: opacity 1s ease;
    pointer-events: none;
    background: linear-gradient(to top, rgba(0,0,0,0.85) 0%, rgba(0,0,0,0.5) 50%, transparent 100%);
}
#gambling-auth-overlay .door-content.active {
    opacity: 1;
    pointer-events: all;
}

/* Audio player */
#gambling-auth-overlay .audio-player {
    margin-bottom: 16px;
    opacity: 0.6;
    transition: opacity 0.3s ease;
}
#gambling-auth-overlay .audio-player:hover {
    opacity: 0.9;
}
#gambling-auth-overlay .audio-player audio {
    width: 260px;
    height: 32px;
    border-radius: 16px;
    filter: invert(1) hue-rotate(180deg) brightness(0.8);
}

/* Passphrase entry */
#gambling-auth-overlay .passphrase-box {
    display: flex;
    gap: 10px;
    align-items: center;
    background: rgba(0,0,0,0.5);
    padding: 12px 20px;
    border-radius: 12px;
    border: 1px solid rgba(255,255,255,0.08);
    margin-bottom: 12px;
}
#gambling-auth-overlay .passphrase-input {
    background: transparent;
    border: none;
    border-bottom: 1px solid rgba(255,255,255,0.15);
    color: #fff;
    font-size: 16px;
    font-family: 'Courier New', monospace;
    letter-spacing: 1px;
    padding: 6px 10px;
    width: 240px;
    outline: none;
    transition: border-color 0.3s ease;
    text-align: center;
}
#gambling-auth-overlay .passphrase-input:focus {
    border-color: rgba(255,255,255,0.4);
}
#gambling-auth-overlay .passphrase-input::placeholder {
    color: rgba(255,255,255,0.25);
    font-style: italic;
}

/* Go button */
#gambling-auth-overlay .go-btn {
    padding: 8px 22px;
    background: rgba(255,255,255,0.08);
    border: 1px solid rgba(255,255,255,0.15);
    color: rgba(255,255,255,0.7);
    border-radius: 8px;
    font-weight: 600;
    font-size: 13px;
    cursor: pointer;
    transition: all 0.3s ease;
    text-transform: uppercase;
    letter-spacing: 2px;
    font-family: 'Cinzel', serif;
}
#gambling-auth-overlay .go-btn:hover {
    background: rgba(255,255,255,0.15);
    border-color: rgba(255,255,255,0.3);
    color: #fff;
}

/* Dummy choice buttons */
#gambling-auth-overlay .choices-row {
    display: flex;
    gap: 10px;
    flex-wrap: wrap;
    justify-content: center;
}
#gambling-auth-overlay .choice-btn {
    padding: 8px 16px;
    background: rgba(0,0,0,0.3);
    border: 1px solid rgba(255,255,255,0.06);
    color: rgba(255,255,255,0.4);
    border-radius: 8px;
    font-size: 12px;
    cursor: pointer;
    transition: all 0.3s ease;
    font-style: italic;
}
#gambling-auth-overlay .choice-btn:hover {
    background: rgba(139, 0, 0, 0.15);
    border-color: rgba(139, 0, 0, 0.3);
    color: rgba(255, 150, 150, 0.7);
}

/* Result overlay (failure/success) */
#gambling-auth-overlay .result-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 7;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 28px;
    opacity: 0;
    pointer-events: none;
    transition: opacity 1s ease;
    background: rgba(0,0,0,0.5);
}
#gambling-auth-overlay .result-overlay.active {
    opacity: 1;
    pointer-events: all;
}
#gambling-auth-overlay .result-text {
    font-size: 38px;
    font-weight: 300;
    letter-spacing: 5px;
    font-family: 'Cinzel', 'Georgia', serif;
    text-shadow: 0 0 40px rgba(0,0,0,0.9);
}
#gambling-auth-overlay .result-text.failure {
    color: #ef4444;
    animation: ga-pulseRed 2s ease-in-out infinite;
}
#gambling-auth-overlay .result-text.success {
    color: #fbbf24;
    animation: ga-pulseGold 2s ease-in-out infinite;
}
@keyframes ga-pulseRed {
    0%, 100% { opacity: 1; transform: scale(1); text-shadow: 0 0 30px rgba(239,68,68,0.4); }
    50% { opacity: 0.7; transform: scale(1.03); text-shadow: 0 0 50px rgba(239,68,68,0.7); }
}
@keyframes ga-pulseGold {
    0%, 100% { opacity: 1; transform: scale(1); text-shadow: 0 0 30px rgba(251,191,36,0.4); }
    50% { opacity: 0.8; transform: scale(1.02); text-shadow: 0 0 50px rgba(251,191,36,0.7); }
}

/* Replay audio players */
#gambling-auth-overlay .replay-audio {
    opacity: 0.5;
    transition: opacity 0.3s ease;
}
#gambling-auth-overlay .replay-audio:hover {
    opacity: 0.85;
}
#gambling-auth-overlay .replay-audio audio {
    width: 240px;
    height: 28px;
    border-radius: 14px;
    filter: invert(1) hue-rotate(180deg) brightness(0.8);
}

/* Walk away button */
#gambling-auth-overlay .walk-away-btn {
    padding: 12px 36px;
    background: transparent;
    color: rgba(239, 68, 68, 0.7);
    border: 1px solid rgba(239, 68, 68, 0.3);
    border-radius: 8px;
    font-weight: 700;
    font-size: 15px;
    cursor: pointer;
    transition: all 0.3s ease;
    font-family: 'Courier New', monospace;
    letter-spacing: 1px;
}
#gambling-auth-overlay .walk-away-btn:hover {
    background: rgba(239, 68, 68, 0.1);
    border-color: rgba(239, 68, 68, 0.6);
    color: #ef4444;
    transform: scale(1.05);
}

/* Enter sanctuary button */
#gambling-auth-overlay .enter-btn {
    padding: 12px 36px;
    background: rgba(251, 191, 36, 0.08);
    color: rgba(251, 191, 36, 0.85);
    border: 1px solid rgba(251, 191, 36, 0.25);
    border-radius: 8px;
    font-weight: 700;
    font-size: 15px;
    cursor: pointer;
    transition: all 0.3s ease;
    font-family: 'Cinzel', serif;
    letter-spacing: 2px;
}
#gambling-auth-overlay .enter-btn:hover {
    background: rgba(251, 191, 36, 0.15);
    border-color: rgba(251, 191, 36, 0.5);
    transform: scale(1.05);
    box-shadow: 0 0 25px rgba(251, 191, 36, 0.15);
}

/* Darkness overlay for wrong answer */
#gambling-auth-overlay .darkness-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.9);
    z-index: 8;
    pointer-events: none;
    opacity: 0;
    transition: opacity 2s ease;
}
#gambling-auth-overlay .darkness-overlay.active {
    opacity: 1;
    pointer-events: none;
}""")
            ]
        ]
        body [] [
            rawText ("""<!--  Your existing page content  -->""")
            pre [] [
                b [] [
                    tag "font" [ attr "color" "#F30" ] [
                        str "FÌRE \"2FA G4Mblah\""
                    ]
                ]
            ]
            button [ attr "onclick" "GamblingAuth.init()" ] [
                str "Launch 2FAgamblah"
            ]
            br []
            iframe [ _src "./demo/"; attr "frameBorder" "0"; attr "width" "300"; attr "height" "400" ] []
            br []
            rawText ("""<!--  STEP 2: PASTE THE OVERLAY HTML HERE  -->""")
            div [ _id "gambling-auth-overlay" ] [
                div [ _class "bg-particles"; _id "particles" ] []
                rawText ("""<!--  Screen 1: Wheel  -->""")
                div [ _id "wheel-screen"; _class "auth-screen active" ] [
                    h2 [] [
                        str "Spin the wheel to load the page"
                    ]
                    p [ _class "subtitle" ] [
                        str "Determine your loading time by chance"
                    ]
                    div [ _class "wheel-wrapper" ] [
                        div [ _class "wheel-pointer" ] []
                        div [ _class "wheel-container" ] [
                            div [ _class "wheel"; _id "wheel" ] [
                                div [ _class "wheel-center" ] []
                                div [ _class "wheel-label"; attr "style" "left: 63.8%; top: 16.6%; transform: translate(-50%, -50%) rotate(22.5deg);" ] [
                                    str "0.5s"
                                ]
                                div [ _class "wheel-label"; attr "style" "left: 83.4%; top: 36.2%; transform: translate(-50%, -50%) rotate(67.5deg);" ] [
                                    str "1s"
                                ]
                                div [ _class "wheel-label"; attr "style" "left: 83.4%; top: 63.8%; transform: translate(-50%, -50%) rotate(112.5deg);" ] [
                                    str "2s"
                                ]
                                div [ _class "wheel-label"; attr "style" "left: 63.8%; top: 83.4%; transform: translate(-50%, -50%) rotate(157.5deg);" ] [
                                    str "3s"
                                ]
                                div [ _class "wheel-label"; attr "style" "left: 36.2%; top: 83.4%; transform: translate(-50%, -50%) rotate(202.5deg);" ] [
                                    str "5s"
                                ]
                                div [ _class "wheel-label"; attr "style" "left: 16.6%; top: 63.8%; transform: translate(-50%, -50%) rotate(247.5deg);" ] [
                                    str "8s"
                                ]
                                div [ _class "wheel-label"; attr "style" "left: 16.6%; top: 36.2%; transform: translate(-50%, -50%) rotate(292.5deg);" ] [
                                    str "10s"
                                ]
                                div [ _class "wheel-label"; attr "style" "left: 36.2%; top: 16.6%; transform: translate(-50%, -50%) rotate(337.5deg);" ] [
                                    str "15s"
                                ]
                            ]
                        ]
                    ]
                    button [ _class "btn"; _id "spin-btn"; attr "onclick" "GamblingAuth.spinWheel()" ] [
                        str "Spin the Wheel"
                    ]
                    div [ _class "progress-wrapper"; _id "progress-wrapper" ] [
                        div [ _class "progress-label" ] [
                            span [] [
                                str "Loading page assets..."
                            ]
                            span [ _id "time-display" ] [
                                str "0.0s"
                            ]
                        ]
                        div [ _class "progress-container" ] [
                            div [ _class "progress-bar"; _id "progress-bar" ] []
                        ]
                    ]
                ]
                rawText ("""<!--  Screen 2: Ready Check  -->""")
                div [ _id "ready-screen"; _class "auth-screen" ] [
                    h2 [] [
                        str "Security Verification Required"
                    ]
                    div [ _class "warning-box" ] [
                        strong [] [
                            str "⚠️ Important:"
                        ]
                        str "To proceed to your account, you must complete a security challenge. This helps us ensure you're not a bot."
                    ]
                    div [ attr "style" "font-size: 48px; margin: 32px 0;" ] [
                        str "🎰"
                    ]
                    h3 [ attr "style" "margin-bottom: 24px; font-size: 24px; color: #fbbf24;" ] [
                        str "Are you ready to play Blackjack?"
                    ]
                    p [ attr "style" "color: #94a3b8; margin-bottom: 32px; line-height: 1.6;" ] [
                        str "Beat the house to generate your temporary access credentials."
                        br []
                        span [ attr "style" "font-size: 14px; opacity: 0.7;" ] [
                            str "(Winning required for authentication)"
                        ]
                    ]
                    button [ _class "btn"; attr "onclick" "GamblingAuth.startBlackjack()" ] [
                        str "Continue to Security Challenge"
                    ]
                ]
                rawText ("""<!--  Screen 3: Blackjack  -->""")
                div [ _id "blackjack-screen"; _class "auth-screen" ] [
                    h2 [] [
                        str "Beat the house to get your new password"
                    ]
                    div [ _class "warning-box" ] [
                        strong [] [
                            str "🔒 Security Challenge:"
                        ]
                        str "Win a hand of blackjack to generate your new password. Beat the house and your new password will be revealed!"
                    ]
                    div [ _class "game-table" ] [
                        div [ _class "hand" ] [
                            div [ _class "hand-label" ] [
                                str "Dealer ("
                                span [ _id "dealer-score" ] [
                                    str "?"
                                ]
                                str ")"
                            ]
                            div [ _class "cards"; _id "dealer-cards" ] []
                        ]
                        div [ _class "hand" ] [
                            div [ _class "hand-label" ] [
                                str "You ("
                                span [ _id "player-score" ] [
                                    str "0"
                                ]
                                str ")"
                            ]
                            div [ _class "cards"; _id "player-cards" ] []
                        ]
                    ]
                    div [ _class "result-banner"; _id "blackjack-result" ] []
                    div [ _class "controls"; _id "blackjack-controls" ] [
                        button [ _class "btn btn-success"; attr "onclick" "GamblingAuth.blackjackHit()" ] [
                            str "Hit"
                        ]
                        button [ _class "btn btn-danger"; attr "onclick" "GamblingAuth.blackjackStand()" ] [
                            str "Stand"
                        ]
                    ]
                    div [ _class "controls" ] [
                        button [ _class "btn"; _id "blackjack-restart"; attr "style" "display:none;"; attr "onclick" "GamblingAuth.startBlackjack()" ] [
                            str "Try Again"
                        ]
                        button [ _class "btn btn-success"; _id "blackjack-continue"; attr "style" "display:none;"; attr "onclick" "GamblingAuth.showPasswordReveal()" ] [
                            str "Claim Password"
                        ]
                    ]
                ]
                rawText ("""<!--  Screen 4: Password Reveal  -->""")
                div [ _id "password-screen"; _class "auth-screen" ] [
                    div [ _class "success-icon" ] [
                        str "✓"
                    ]
                    h2 [] [
                        str "Password Reset Successful!"
                    ]
                    p [ attr "style" "color: #86efac; margin-bottom: 24px;" ] [
                        str "Authentication challenge completed successfully."
                    ]
                    div [ attr "style" "background: rgba(255,255,255,0.05); border-radius: 12px; padding: 24px; margin: 24px 0; border: 1px solid rgba(255,255,255,0.1);" ] [
                        div [ attr "style" "font-size: 13px; color: #94a3b8; margin-bottom: 12px; text-transform: uppercase; letter-spacing: 1px;" ] [
                            str "Your New Password"
                        ]
                        div [ _class "password-display"; _id "new-password" ] [
                            str "Generating..."
                        ]
                        div [ attr "style" "font-size: 13px; color: #64748b; margin-top: 12px;" ] [
                            str "Save this password securely. You will need it to access your account."
                        ]
                    ]
                    button [ _class "btn"; attr "onclick" "GamblingAuth.showLogin()" ] [
                        str "Sign In with New Password"
                    ]
                ]
                rawText ("""<!--  Screen 5: Login  -->""")
                div [ _id "login-screen"; _class "auth-screen" ] [
                    h2 [] [
                        str "Sign in to your account"
                    ]
                    p [ _class "subtitle" ] [
                        str "Use the credentials generated from your security challenge"
                    ]
                    div [ attr "style" "margin-bottom: 24px;" ] [
                        div [ attr "style" "text-align: left; font-size: 13px; color: #94a3b8; margin-bottom: 8px; margin-left: 4px;" ] [
                            str "Email address"
                        ]
                        input [ _type "email"; _id "email-input"; attr "value" "user@secure-app.com"; attr "readonly" ""; attr "style" "cursor: not-allowed; opacity: 0.7;" ]
                        div [ attr "style" "text-align: left; font-size: 13px; color: #94a3b8; margin-bottom: 8px; margin-left: 4px;" ] [
                            str "Password"
                        ]
                        input [ _type "password"; _id "password-input"; attr "placeholder" "Enter generated password" ]
                    ]
                    button [ _class "btn"; attr "style" "width: 100%;"; attr "onclick" "GamblingAuth.attemptLogin()" ] [
                        str "Sign In"
                    ]
                    div [ attr "style" "margin-top: 20px; font-size: 14px; color: #64748b;" ] [
                        a [ _href "#"; attr "style" "color: #60a5fa; text-decoration: none;"; attr "onclick" "GamblingAuth.resetToBlackjack()" ] [
                            str "Forgot password? Start over"
                        ]
                    ]
                ]
                rawText ("""<!--  Screen 6: Horse Race  -->""")
                div [ _id "horse-screen"; _class "auth-screen" ] [
                    h2 [] [
                        str "Verify you are human"
                    ]
                    p [ _class "subtitle" ] [
                        str "Please complete the CAPTCHA to continue"
                    ]
                    div [ attr "style" "background: linear-gradient(135deg, #fbbf24 0%, #f59e0b 100%); color: #0f172a; padding: 12px; border-radius: 8px; font-weight: 700; margin-bottom: 24px; display: inline-block; box-shadow: 0 4px 12px rgba(251, 191, 36, 0.3);" ] [
                        str "Pick the Winning Horse"
                    ]
                    div [ _class "race-track" ] [
                        div [ _class "finish-line" ] []
                        div [ _class "lane" ] [
                            div [ _class "lane-number" ] [
                                str "#1"
                            ]
                            div [ _class "horse flip"; _id "horse-0" ] [
                                str "🐎"
                            ]
                            div [ _class "lane-name" ] [
                                str "Thunder Bolt"
                            ]
                        ]
                        div [ _class "lane" ] [
                            div [ _class "lane-number" ] [
                                str "#2"
                            ]
                            div [ _class "horse flip"; _id "horse-1" ] [
                                str "🏇🏻"
                            ]
                            div [ _class "lane-name" ] [
                                str "Lightning Strike"
                            ]
                        ]
                        div [ _class "lane" ] [
                            div [ _class "lane-number" ] [
                                str "#3"
                            ]
                            div [ _class "horse flip"; _id "horse-2" ] [
                                str "🐴"
                            ]
                            div [ _class "lane-name" ] [
                                str "Midnight Runner"
                            ]
                        ]
                        div [ _class "lane" ] [
                            div [ _class "lane-number" ] [
                                str "#4"
                            ]
                            div [ _class "horse flip"; _id "horse-3" ] [
                                str "🎠"
                            ]
                            div [ _class "lane-name" ] [
                                str "Golden Gallop"
                            ]
                        ]
                        div [ _class "lane" ] [
                            div [ _class "lane-number" ] [
                                str "#5"
                            ]
                            div [ _class "horse flip"; _id "horse-4" ] [
                                str "🐢"
                            ]
                            div [ _class "lane-name" ] [
                                str "Storm Chaser (Trust)"
                            ]
                        ]
                    ]
                    div [ attr "style" "font-weight: 600; margin-bottom: 16px; color: #e2e8f0;" ] [
                        str "Select your horse:"
                    ]
                    div [ _class "horse-selector" ] [
                        button [ _class "horse-btn"; attr "onclick" "GamblingAuth.selectHorse(0)" ] [
                            str "#1 🐎"
                        ]
                        button [ _class "horse-btn"; attr "onclick" "GamblingAuth.selectHorse(1)" ] [
                            str "#2 🏇🏻"
                        ]
                        button [ _class "horse-btn"; attr "onclick" "GamblingAuth.selectHorse(2)" ] [
                            str "#3 🐴"
                        ]
                        button [ _class "horse-btn"; attr "onclick" "GamblingAuth.selectHorse(3)" ] [
                            str "#4 🎠"
                        ]
                        button [ _class "horse-btn"; attr "onclick" "GamblingAuth.selectHorse(4)" ] [
                            str "#5 🐢"
                        ]
                    ]
                    div [ attr "style" "display: flex; gap: 12px; justify-content: center;" ] [
                        button [ _class "btn"; _id "race-btn"; attr "onclick" "GamblingAuth.startRace()"; attr "disabled" "" ] [
                            str "Start Race! 🏁"
                        ]
                        button [ _class "btn"; _id "retry-horse-btn"; attr "style" "display:none;"; attr "onclick" "GamblingAuth.resetRace()" ] [
                            str "Try Again"
                        ]
                    ]
                    div [ _id "horse-result"; attr "style" "margin-top: 20px; font-weight: 600; min-height: 28px; font-size: 16px;" ] []
                    div [ _class "attempts-counter" ] [
                        str "Attempts:"
                        span [ _id "horse-attempts" ] [
                            str "0"
                        ]
                    ]
                    div [ attr "style" "margin-top: 10px; font-size: 14px; color: #f1c40f;" ] [
                        str "Pick the winning horse to prove you're human!"
                    ]
                ]
                rawText ("""<!--  Screen 7: Dice 2FA  -->""")
                div [ _id "dice-screen"; _class "auth-screen" ] [
                    h2 [] [
                        str "Two-Factor Authentication"
                    ]
                    p [ _class "subtitle" ] [
                        str "Roll doubles to complete authentication"
                    ]
                    div [ _class "dice-container" ] [
                        div [ _class "die-wrapper" ] [
                            div [ _class "die"; _id "die-1" ] [
                                div [ _class "die-face face-1 active" ] [
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-2" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-3" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-4" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-5" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-6" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                            ]
                            div [ _class "die-label" ] [
                                str "Die 1"
                            ]
                        ]
                        div [ _class "die-wrapper" ] [
                            div [ _class "die"; _id "die-2" ] [
                                div [ _class "die-face face-1 active" ] [
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-2" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-3" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-4" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-5" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                                div [ _class "die-face face-6" ] [
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                    div [ _class "dot" ] []
                                ]
                            ]
                            div [ _class "die-label" ] [
                                str "Die 2"
                            ]
                        ]
                    ]
                    button [ _class "btn btn-danger"; _id "roll-btn"; attr "onclick" "GamblingAuth.rollDice()"; attr "style" "font-size: 18px; padding: 18px 48px;" ] [
                        str "Roll for Access!"
                    ]
                    div [ _id "roll-result"; attr "style" "margin-top: 24px; font-weight: 600; min-height: 28px; font-size: 18px;" ] []
                    div [ _class "attempts-counter" ] [
                        str "Attempts:"
                        span [ _id "dice-attempts" ] [
                            str "0"
                        ]
                    ]
                    div [ _class "probability" ] [
                        str "Probability of rolling doubles: 16.67% (1 in 6 chance)"
                    ]
                ]
                rawText ("""<!--  Screen 8: Russian Roulette  -->""")
                div [ _id "roulette-screen"; _class "auth-screen" ] [
                    div [ _class "rr-screen-flash"; _id "rr-screen-flash" ] []
                    h2 [] [
                        str "Final Stage: Russian Roulette"
                    ]
                    p [ _class "subtitle" ] [
                        str "Load the chambers and test your fate"
                    ]
                    div [ _class "warning-box"; attr "style" "margin-bottom: 24px;" ] [
                        strong [] [
                            str "🔫 Final Challenge:"
                        ]
                        str "Load bullets into the revolver chamber. One bullet = better chance at surviving. Three bullets = ability to skip the final game. Choose wisely."
                    ]
                    div [ _class "rr-layout"; _id "rr-layout" ] [
                        div [ _class "rr-left-pane" ] [
                            div [ _class "rr-stick-figure-container" ] [
                                div [ _class "rr-stick-figure alive"; _id "rr-stick-figure" ] [
                                    str "🧍"
                                ]
                                div [ _class "rr-gun-container" ] [
                                    div [ _class "rr-gun"; _id "rr-gun" ] [
                                        str "🔫"
                                    ]
                                    div [ _class "rr-muzzle-flash"; _id "rr-muzzle-flash" ] [
                                        str "💥"
                                    ]
                                ]
                            ]
                            div [ _class "rr-status"; _id "rr-stick-status" ] [
                                str "Feeling lucky?"
                            ]
                        ]
                        div [ _class "rr-right-pane" ] [
                            div [ _class "rr-barrel-wrapper" ] [
                                div [ _class "rr-barrel-container" ] [
                                    div [ _class "rr-barrel"; _id "rr-barrel" ] [
                                        div [ _class "rr-chamber"; _id "rr-chamber-0" ] []
                                        div [ _class "rr-chamber"; _id "rr-chamber-1" ] []
                                        div [ _class "rr-chamber"; _id "rr-chamber-2" ] []
                                        div [ _class "rr-chamber"; _id "rr-chamber-3" ] []
                                        div [ _class "rr-chamber"; _id "rr-chamber-4" ] []
                                        div [ _class "rr-chamber"; _id "rr-chamber-5" ] []
                                        div [ _class "rr-barrel-center" ] []
                                    ]
                                ]
                            ]
                            div [ _class "rr-chamber-indicator"; _id "rr-chamber-indicator" ] [
                                div [ _class "rr-chamber-dot"; _id "rr-dot-0" ] []
                                div [ _class "rr-chamber-dot"; _id "rr-dot-1" ] []
                                div [ _class "rr-chamber-dot"; _id "rr-dot-2" ] []
                                div [ _class "rr-chamber-dot"; _id "rr-dot-3" ] []
                                div [ _class "rr-chamber-dot"; _id "rr-dot-4" ] []
                                div [ _class "rr-chamber-dot"; _id "rr-dot-5" ] []
                            ]
                            div [ _class "rr-status"; _id "rr-barrel-status" ] [
                                str "6 empty chambers"
                            ]
                            div [ _class "rr-btn-group"; _id "rr-btn-group" ] [
                                button [ _class "rr-btn"; _id "rr-load-one"; attr "onclick" "GamblingAuth.loadRoulette(1)" ] [
                                    span [ _class "rr-btn-icon" ] [
                                        str "🔴"
                                    ]
                                    str "Load Just One"
                                ]
                                button [ _class "rr-btn"; _id "rr-load-three"; attr "onclick" "GamblingAuth.loadRoulette(3)" ] [
                                    span [ _class "rr-btn-icon" ] [
                                        str "🔴🔴🔴"
                                    ]
                                    str "Load Three"
                                ]
                            ]
                            div [ _class "rr-result"; _id "rr-result" ] []
                            button [ _class "btn"; _id "rr-spin-btn"; attr "onclick" "GamblingAuth.spinRoulette()"; attr "disabled" ""; attr "style" "display:none; margin-top: 16px;" ] [
                                str "Spin the Cylinder! 🎲"
                            ]
                            button [ _class "btn btn-danger"; _id "rr-pull-trigger-btn"; attr "onclick" "GamblingAuth.pullTrigger()"; attr "disabled" ""; attr "style" "display:none; margin-top: 16px;" ] [
                                str "Pull the Trigger 💀"
                            ]
                            button [ _class "btn"; _id "rr-retry-btn"; attr "onclick" "GamblingAuth.retryRoulette()"; attr "style" "display:none; margin-top: 16px;" ] [
                                str "Try Again 🔄"
                            ]
                            button [ _class "btn btn-success"; _id "rr-skip-btn"; attr "onclick" "GamblingAuth.skipFinalGame()"; attr "style" "display:none; margin-top: 16px;" ] [
                                str "Skip Final Game ✓"
                            ]
                        ]
                    ]
                ]
                rawText ("""<!--  Screen 9: Final Game - Skyrim Black Door  -->""")
                div [ _id "finalgame-screen"; _class "auth-screen" ] [
                    div [ _class "finalgame-container"; _id "finalgame-container" ] [
                        rawText ("""<!--  Smoke layers  -->""")
                        div [ _class "smoke-container"; _id "smoke-container" ] [
                            div [ _class "smoke-layer" ] []
                            div [ _class "smoke-layer" ] []
                            div [ _class "smoke-layer" ] []
                        ]
                        rawText ("""<!--  Fade overlay for cinematic sequence  -->""")
                        div [ _class "fade-overlay"; _id "fade-overlay" ] []
                        rawText ("""<!--  Cinematic text  -->""")
                        div [ _class "cinematic-text"; _id "cinematic-text" ] []
                        rawText ("""<!--  Full screen door image  -->""")
                        div [ _class "door-fullscreen"; _id "door-fullscreen" ] [
                            img [ _src "https://static.wikia.nocookie.net/elderscrolls/images/b/b8/Dark_Brotherhood_Black_Door.jpg/"; _alt "Black Door" ]
                        ]
                        rawText ("""<!--  Door content (audio + input + choices) - no visible question text  -->""")
                        div [ _class "door-content"; _id "door-content" ] [
                            div [ _class "audio-player"; _id "question-audio-container" ] [
                                audio [ _id "audio-question"; attr "controls" "" ] []
                            ]
                            div [ _class "passphrase-box" ] [
                                input [ _type "text"; _class "passphrase-input"; _id "passphrase-input"; attr "placeholder" "..."; attr "autocomplete" "off"; attr "spellcheck" "false" ]
                                button [ _class "go-btn"; _id "go-btn"; attr "onclick" "GamblingAuth.checkPassphrase()" ] [
                                    str "Go"
                                ]
                            ]
                            div [ _class "choices-row" ] [
                                button [ _class "choice-btn"; attr "onclick" "GamblingAuth.wrongAnswer()" ] [
                                    str "Umm... the lute?"
                                ]
                                button [ _class "choice-btn"; attr "onclick" "GamblingAuth.wrongAnswer()" ] [
                                    str "Like... black, right?"
                                ]
                                button [ _class "choice-btn"; attr "onclick" "GamblingAuth.wrongAnswer()" ] [
                                    str "Definitely red"
                                ]
                            ]
                        ]
                        rawText ("""<!--  Failure result overlay  -->""")
                        div [ _class "result-overlay"; _id "failure-overlay" ] [
                            div [ _class "result-text failure" ] [
                                str "You are not worthy"
                            ]
                            div [ _class "replay-audio" ] [
                                audio [ _id "audio-failure-replay"; attr "controls" "" ] []
                            ]
                            button [ _class "walk-away-btn"; attr "onclick" "GamblingAuth.walkAway()" ] [
                                str "<walk away>"
                            ]
                        ]
                        rawText ("""<!--  Success result overlay  -->""")
                        div [ _class "result-overlay"; _id "success-overlay" ] [
                            div [ _class "result-text success" ] [
                                str "Welcome home"
                            ]
                            div [ _class "replay-audio" ] [
                                audio [ _id "audio-success-replay"; attr "controls" "" ] []
                            ]
                            button [ _class "enter-btn"; attr "onclick" "GamblingAuth.leaveBigly()" ] [
                                str "Enter Sanctuary"
                            ]
                        ]
                        rawText ("""<!--  Darkness overlay  -->""")
                        div [ _class "darkness-overlay"; _id "darkness-overlay" ] []
                    ]
                ]
                rawText ("""<!--  Screen 10: Success  -->""")
                rawText ("""<!--  Screen 10: Success  -->""")
                rawText ("""<!--  Screen 10: Success  -->""")
                rawText ("""<!--  Screen 10: Success  -->""")
                rawText ("""<!--  Screen 10: Success  -->""")
                div [ _id "success-screen"; _class "auth-screen" ] [
                    div [ _class "success-icon" ] [
                        str "✓"
                    ]
                    h2 [] [
                        str "Welcome back!"
                    ]
                    p [ attr "style" "color: #86efac; font-size: 18px; margin-bottom: 16px;" ] [
                        str "Successfully authenticated"
                    ]
                    p [ attr "style" "color: #94a3b8; margin-bottom: 32px;" ] [
                        str "Redirecting to secure dashboard..."
                    ]
                    div [ attr "style" "width: 100%; height: 4px; background: rgba(255,255,255,0.1); border-radius: 2px; overflow: hidden; margin-bottom: 32px;" ] [
                        div [ attr "style" "height: 100%; width: 0%; background: #22c55e; animation: ga-fillBar 2s ease-out forwards;" ] []
                    ]
                    button [ _class "btn btn-success"; attr "onclick" "GamblingAuth.close()" ] [
                        str "Close Overlay"
                    ]
                ]
            ]
            rawText ("""<!--  STEP 3: PASTE THE JAVASCRIPT HERE  -->""")
            script [] [
                    rawText ("""/*
        ============================================
        GAMBLING AUTH SYSTEM - IMPLEMENTATION GUIDE
        ============================================
        
        1. INSTALLATION:
           Copy this entire HTML file's contents into your page, or 
           save as separate file and include via iframe/fetch.
        
        2. TRIGGERING THE OVERLAY:
           To launch the authentication sequence from any button or event:
           
           <button onclick="GamblingAuth.init()">Secure Login</button>
           
           Or from JavaScript:
           GamblingAuth.init();
        
        3. INTEGRATION WITH EXISTING LOGIN:
           To pre-populate email or customize:
           
           GamblingAuth.init({
               email: 'user@example.com',
               onComplete: function() {
                   console.log('User completed all challenges');
                   // Redirect to dashboard
                   window.location.href = '/dashboard';
               }
           });
        
        4. SECURITY NOTES:
           - This is a satirical/entertainment implementation
           - Not recommended for actual production authentication
           - No actual security is provided by this system
           - The "password" is randomly generated client-side
        
        5. CUSTOMIZATION:
           - Modify wheelValues array to change loading times
           - Adjust probability in dice (currently 1/6)
           - Change horse names/emojis in HTML
           - Styling can be overridden via CSS specificity
        
        ============================================
        */
       
        const GamblingAuth = {
            currentScreen: 'wheel-screen',
            selectedHorse: null,
            horseAttempts: 0,
            diceAttempts: 0,
            // Russian Roulette state
            rrLoadedChambers: [],
            rrSpinning: false,
            rrCurrentChamber: 0,
            blackjackState: null,
            generatedPassword: '',
            wheelValues: [0.5, 1, 2, 3, 5, 8, 10, 15],
            options: {},
            
            init: function(options = {}) {
                this.options = options;
                this.createParticles();
                this.generatePassword();
                
                // Prevent body scroll while overlay is active
                document.body.style.overflow = 'hidden';
                
                // Show overlay
                document.getElementById('gambling-auth-overlay').classList.add('active');
                
                // Set custom email if provided
                if(options.email) {
                    document.getElementById('email-input').value = options.email;
                }
                
                this.showScreen('wheel-screen');
                
                // Reset wheel
                const wheel = document.getElementById('wheel');
                wheel.style.transition = 'none';
                wheel.style.transform = 'rotate(0deg)';
                // Re-enable transition after reset (fixes animation on retry)
                setTimeout(() => {
                    wheel.style.transition = 'transform 6s cubic-bezier(0.1, 0.7, 0.1, 1)';
                }, 50);
                setTimeout(() => {
                    wheel.style.transition = 'transform 6s cubic-bezier(0.1, 0.7, 0.1, 1)';
                }, 50);
                
                // Add keyboard trap (prevent escape)
                this.trapKeyboard();
            },
            
            trapKeyboard: function() {
                document.addEventListener('keydown', (e) => {
                    if(e.key === 'Escape' && document.getElementById('gambling-auth-overlay').classList.contains('active')) {
                        e.preventDefault();
                        e.stopPropagation();
                        return false;
                    }
                }, true);
            },
            
            createParticles: function() {
                const container = document.getElementById('particles');
                container.innerHTML = '';
                for(let i = 0; i < 50; i++) {
                    const p = document.createElement('div');
                    p.className = 'particle';
                    p.style.left = Math.random() * 100 + '%';
                    p.style.animationDelay = Math.random() * 20 + 's';
                    p.style.animationDuration = (15 + Math.random() * 10) + 's';
                    container.appendChild(p);
                }
            },
            
            generatePassword: function() {
                const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*';
                let pass = '';
                for(let i = 0; i < 16; i++) {
                    pass += chars.charAt(Math.floor(Math.random() * chars.length));
                }
                this.generatedPassword = pass;
                document.getElementById('new-password').textContent = pass;
            },
            
            showScreen: function(screenId) {
                document.querySelectorAll('.auth-screen').forEach(s => s.classList.remove('active'));
                document.getElementById(screenId).classList.add('active');
                this.currentScreen = screenId;
            },
            
            spinWheel: function() {
                const btn = document.getElementById('spin-btn');
                btn.disabled = true;
                btn.textContent = 'Spinning...';
                
                const wheel = document.getElementById('wheel');
                const segmentIndex = Math.floor(Math.random() * 8);
                const loadTime = this.wheelValues[segmentIndex];
                
                const baseRotation = 1800;
                const segmentOffset = 360 - (segmentIndex * 45 + 22.5);
                const finalRotation = baseRotation + segmentOffset + (Math.random() * 10 - 5);
                
                wheel.style.transition = 'transform 6s cubic-bezier(0.1, 0.7, 0.1, 1)';
                wheel.style.transform = `rotate(${finalRotation}deg)`;
                
                setTimeout(() => {
                    this.simulateLoading(loadTime);
                }, 6000);
            },
            
            simulateLoading: function(seconds) {
                const wrapper = document.getElementById('progress-wrapper');
                const bar = document.getElementById('progress-bar');
                const timeDisplay = document.getElementById('time-display');
                
                wrapper.classList.add('visible');
                timeDisplay.textContent = seconds.toFixed(1) + 's';
                
                bar.style.transition = 'none';
                bar.style.width = '0%';
                
                setTimeout(() => {
                    bar.style.transition = `width ${seconds}s linear`;
                    bar.style.width = '100%';
                }, 50);
                
                setTimeout(() => {
                    this.showScreen('ready-screen');
                }, seconds * 1000 + 500);
            },
            
            // BLACKJACK
            startBlackjack: function() {
                this.blackjackState = {
                    deck: this.createDeck(),
                    player: [],
                    dealer: [],
                    gameOver: false,
                    playerStood: false
                };
                
                this.dealCard('player', false);
                this.dealCard('dealer', true);
                this.dealCard('player', false);
                this.dealCard('dealer', false);
                
                this.updateBlackjackUI();
                document.getElementById('blackjack-result').style.display = 'none';
                document.getElementById('blackjack-result').className = 'result-banner';
                document.getElementById('blackjack-controls').style.display = 'flex';
                document.getElementById('blackjack-restart').style.display = 'none';
                document.getElementById('blackjack-continue').style.display = 'none';
                this.showScreen('blackjack-screen');
            },
            
            createDeck: function() {
                const suits = ['♠', '♥', '♦', '♣'];
                const values = ['2','3','4','5','6','7','8','9','10','J','Q','K','A'];
                const deck = [];
                for(let suit of suits) {
                    for(let val of values) {
                        deck.push({
                            suit, 
                            value: val, 
                            numeric: this.cardValue(val), 
                            red: suit === '♥' || suit === '♦'
                        });
                    }
                }
                for(let i = deck.length - 1; i > 0; i--) {
                    const j = Math.floor(Math.random() * (i + 1));
                    [deck[i], deck[j]] = [deck[j], deck[i]];
                }
                return deck;
            },
            
            cardValue: function(val) {
                if(['J','Q','K'].includes(val)) return 10;
                if(val === 'A') return 11;
                return parseInt(val);
            },
            
            dealCard: function(who, hidden) {
                const card = this.blackjackState.deck.pop();
                this.blackjackState[who].push({...card, hidden});
            },
            
            calculateScore: function(hand) {
                let sum = 0;
                let aces = 0;
                for(let card of hand) {
                    if(!card.hidden) {
                        sum += card.numeric;
                        if(card.value === 'A') aces++;
                    }
                }
                while(sum > 21 && aces > 0) {
                    sum -= 10;
                    aces--;
                }
                return sum;
            },
            
            updateBlackjackUI: function() {
                const renderCard = (card) => {
                    if(card.hidden) return `<div class="card hidden"></div>`;
                    const colorClass = card.red ? 'red' : '';
                    return `<div class="card ${colorClass}">
                        <div class="card-top">${card.value}</div>
                        <div class="suit">${card.suit}</div>
                        <div class="card-bottom">${card.value}</div>
                    </div>`;
                };
                
                document.getElementById('player-cards').innerHTML = this.blackjackState.player.map(renderCard).join('');
                document.getElementById('dealer-cards').innerHTML = this.blackjackState.dealer.map(renderCard).join('');
                
                const playerScore = this.calculateScore(this.blackjackState.player);
                const dealerVisible = this.blackjackState.dealer.filter(c => !c.hidden);
                const dealerVisibleScore = this.calculateScore(dealerVisible);
                
                document.getElementById('player-score').textContent = playerScore > 21 ? 'Bust!' : playerScore;
                
                if(this.blackjackState.playerStood || this.blackjackState.gameOver) {
                    document.getElementById('dealer-score').textContent = this.calculateScore(this.blackjackState.dealer);
                } else {
                    document.getElementById('dealer-score').textContent = dealerVisible.length > 0 ? dealerVisibleScore : '?';
                }
            },
            
            blackjackHit: function() {
                if(this.blackjackState.gameOver) return;
                this.dealCard('player', false);
                this.updateBlackjackUI();
                
                const score = this.calculateScore(this.blackjackState.player);
                if(score > 21) {
                    this.endBlackjack(false);
                }
            },
            
            blackjackStand: function() {
                if(this.blackjackState.gameOver) return;
                this.blackjackState.playerStood = true;
                
                this.blackjackState.dealer[0].hidden = false;
                this.updateBlackjackUI();
                
                setTimeout(() => {
                    this.dealerPlay();
                }, 600);
            },
            
            dealerPlay: function() {
                const score = this.calculateScore(this.blackjackState.dealer);
                if(score < 17) {
                    this.dealCard('dealer', false);
                    this.updateBlackjackUI();
                    setTimeout(() => this.dealerPlay(), 600);
                } else {
                    this.finishBlackjack();
                }
            },
            
            finishBlackjack: function() {
                const playerScore = this.calculateScore(this.blackjackState.player);
                const dealerScore = this.calculateScore(this.blackjackState.dealer);
                
                let playerWins = false;
                if(playerScore > 21) playerWins = false;
                else if(dealerScore > 21) playerWins = true;
                else if(playerScore > dealerScore) playerWins = true;
                else playerWins = false; // House wins ties
                
                this.endBlackjack(playerWins);
            },
            
            endBlackjack: function(win) {
                this.blackjackState.gameOver = true;
                const result = document.getElementById('blackjack-result');
                result.style.display = 'block';
                
                if(win) {
                    result.innerHTML = '🎉 You beat the house!<br>Your new password has been generated.';
                    result.className = 'result-banner win';
                    document.getElementById('blackjack-controls').style.display = 'none';
                    document.getElementById('blackjack-continue').style.display = 'inline-block';
                } else {
                    result.innerHTML = '🏠 House wins!<br>No password for you. Try again!';
                    result.className = 'result-banner lose';
                    document.getElementById('blackjack-controls').style.display = 'none';
                    document.getElementById('blackjack-restart').style.display = 'inline-block';
                }
                this.updateBlackjackUI();
            },
            
            showPasswordReveal: function() {
                this.showScreen('password-screen');
            },
            
            showLogin: function() {
                document.getElementById('password-input').value = '';
                this.showScreen('login-screen');
            },
            
            attemptLogin: function() {
                const input = document.getElementById('password-input').value;
                if(input === this.generatedPassword) {
                    this.showScreen('horse-screen');
                } else {
                    const screen = document.getElementById('login-screen');
                    screen.style.animation = 'ga-shake 0.5s';
                    setTimeout(() => screen.style.animation = '', 500);
                    document.getElementById('password-input').style.borderColor = '#ef4444';
                    setTimeout(() => document.getElementById('password-input').style.borderColor = '', 2000);
                }
            },
            
            resetToBlackjack: function() {
                this.showScreen('ready-screen');
            },
            
            // HORSE RACE
            selectHorse: function(index) {
                this.selectedHorse = index;
                document.querySelectorAll('.horse-btn').forEach((btn, i) => {
                    btn.classList.toggle('selected', i === index);
                });
                document.getElementById('race-btn').disabled = false;
            },
            
            startRace: function() {
                if(this.selectedHorse === null) return;
                
                document.getElementById('race-btn').disabled = true;
                document.querySelectorAll('.horse-btn').forEach(b => b.disabled = true);
                
                const trackWidth = document.querySelector('.lane').offsetWidth - 100;
                const winner = Math.floor(Math.random() * 5);
                
                const positions = [0, 0, 0, 0, 0];
                const speeds = [0, 0, 0, 0, 0].map((_, i) => 
                    i === winner ? 2.5 + Math.random() * 0.5 : 1.5 + Math.random() * 1.5
                );
                
                let finished = false;
                const raceInterval = setInterval(() => {
                    let leaderPos = 0;
                    
                    for(let i = 0; i < 5; i++) {
                        positions[i] += speeds[i] * (0.8 + Math.random() * 0.4);
                        const visualPos = Math.min(positions[i], trackWidth - 60);
                        
                        document.getElementById(`horse-${i}`).style.left = (60 + visualPos) + 'px';
                        
                        if(Math.random() > 0.7) {
                            this.createDust(i, visualPos);
                        }
                        
                        if(positions[i] > leaderPos) leaderPos = positions[i];
                        if(i === winner && positions[i] >= trackWidth - 60) finished = true;
                    }
                    
                    if(finished) {
                        clearInterval(raceInterval);
                        this.finishRace(winner);
                    }
                }, 80);
            },
            
            createDust: function(horseIdx, position) {
                const horseEl = document.getElementById(`horse-${horseIdx}`);
                const dust = document.createElement('div');
                dust.className = 'dust';
                dust.textContent = '💨';
                dust.style.left = (position - 20) + 'px';
                dust.style.top = '50%';
                dust.style.transform = 'translateY(-50%)';
                horseEl.parentElement.appendChild(dust);
                setTimeout(() => dust.remove(), 1000);
            },
            
            finishRace: function(winner) {
                this.horseAttempts++;
                document.getElementById('horse-attempts').textContent = this.horseAttempts;
                
                const resultDiv = document.getElementById('horse-result');
                const names = ['Thunder Bolt', 'Lightning Strike', 'Midnight Runner', 'Golden Gallop', 'Storm Chaser (Trust)'];
                
                if(this.selectedHorse === winner) {
                    resultDiv.innerHTML = `<span style="color: #22c55e; font-size: 20px;">✓ Correct! ${names[winner]} wins!<br>Human verification complete.</span>`;
                    setTimeout(() => {
                        this.showScreen('dice-screen');
                    }, 2000);
                } else {
                    resultDiv.innerHTML = `<span style="color: #ef4444;">✗ Wrong! ${names[winner]} won, but you picked ${names[this.selectedHorse]}</span>`;
                    document.getElementById('race-btn').style.display = 'none';
                    document.getElementById('retry-horse-btn').style.display = 'inline-block';
                }
            },
            
            resetRace: function() {
                for(let i = 0; i < 5; i++) {
                    document.getElementById(`horse-${i}`).style.left = '60px';
                }
                document.getElementById('horse-result').innerHTML = '';
                document.getElementById('retry-horse-btn').style.display = 'none';
                document.getElementById('race-btn').style.display = 'inline-block';
                document.getElementById('race-btn').disabled = true;
                document.querySelectorAll('.horse-btn').forEach(b => {
                    b.disabled = false;
                    b.classList.remove('selected');
                });
                this.selectedHorse = null;
            },
            
            // DICE
            rollDice: function() {
                const btn = document.getElementById('roll-btn');
                btn.disabled = true;
                btn.textContent = 'Rolling...';
                
                const die1 = document.getElementById('die-1');
                const die2 = document.getElementById('die-2');
                
                // Reset dice state before rolling (fixes animation on retry)
                die1.classList.remove('rolling');
                die2.classList.remove('rolling');
                this.showDieFace(die1, 1);
                this.showDieFace(die2, 1);
                
                let rolls = 0;
                const maxRolls = 15;
                
                const rollInterval = setInterval(() => {
                    const r1 = Math.floor(Math.random() * 6) + 1;
                    const r2 = Math.floor(Math.random() * 6) + 1;
                    this.showDieFace(die1, r1);
                    this.showDieFace(die2, r2);
                    
                    die1.classList.add('rolling');
                    die2.classList.add('rolling');
                    setTimeout(() => {
                        die1.classList.remove('rolling');
                        die2.classList.remove('rolling');
                    }, 400);
                    
                    rolls++;
                    
                    if(rolls >= maxRolls) {
                        clearInterval(rollInterval);
                        
                        const val1 = Math.floor(Math.random() * 6) + 1;
                        const val2 = Math.floor(Math.random() * 6) + 1;
                        this.showDieFace(die1, val1);
                        this.showDieFace(die2, val2);
                        
                        this.diceAttempts++;
                        document.getElementById('dice-attempts').textContent = this.diceAttempts;
                        
                        const resultDiv = document.getElementById('roll-result');
                        if(val1 === val2) {
                            resultDiv.innerHTML = `<span style="color: #22c55e; font-size: 22px;">🎉 DOUBLES! ${val1}-${val2}<br>Authentication successful!</span>`;
                            setTimeout(() => {
                                this.showScreen('roulette-screen');
                                this.initRoulette();
                                // Call onComplete callback if provided
                                if(this.options.onComplete) {
                                    this.options.onComplete();
                                }
                            }, 2000);
                        } else {
                            resultDiv.innerHTML = `<span style="color: #ef4444; font-size: 18px;">🎲 ${val1}-${val2} - No doubles<br>Try again!</span>`;
                            btn.disabled = false;
                            btn.textContent = 'Roll for Access!';
                        }
                    }
                }, 150);
            },
            
            showDieFace: function(dieElement, value) {
                dieElement.querySelectorAll('.die-face').forEach(face => {
                    face.classList.remove('active');
                });
                dieElement.querySelector(`.face-${value}`).classList.add('active');
            },
            
            
            // ============================================
            // RUSSIAN ROULETTE - NEW ADDITIONS
            // ============================================

            initRoulette: function() {
                this.rrLoadedChambers = [];
                this.rrSpinning = false;
                this.rrCurrentChamber = 0;
                document.querySelectorAll('.rr-chamber').forEach(c => {
                    c.classList.remove('loaded', 'fired');
                });
                document.querySelectorAll('.rr-chamber-dot').forEach(d => {
                    d.classList.remove('active', 'empty');
                });
                const stickFigure = document.getElementById('rr-stick-figure');
                stickFigure.classList.remove('dead');
                stickFigure.classList.add('alive');
                stickFigure.textContent = '🧍';
                document.getElementById('rr-stick-status').textContent = 'Feeling lucky?';
                document.getElementById('rr-stick-status').className = 'rr-status';
                document.getElementById('rr-barrel-status').textContent = '6 empty chambers';
                document.getElementById('rr-result').innerHTML = '';
                document.getElementById('rr-result').className = 'rr-result';
                document.getElementById('rr-load-one').disabled = false;
                document.getElementById('rr-load-three').disabled = false;
                document.getElementById('rr-btn-group').style.display = 'flex';
                document.getElementById('rr-spin-btn').style.display = 'none';
                document.getElementById('rr-spin-btn').disabled = true;
                document.getElementById('rr-pull-trigger-btn').style.display = 'none';
                document.getElementById('rr-pull-trigger-btn').disabled = true;
                document.getElementById('rr-retry-btn').style.display = 'none';
                document.getElementById('rr-skip-btn').style.display = 'none';
                const barrel = document.getElementById('rr-barrel');
                barrel.style.transition = 'none';
                barrel.style.transform = 'rotate(0deg)';
                barrel.classList.remove('rr-spinning');
                document.querySelectorAll('.rr-bullet-hole').forEach(h => h.remove());
                document.getElementById('rr-screen-flash').classList.remove('active');
                document.getElementById('rr-layout').classList.remove('rr-shake');
            },

            loadRoulette: function(count) {
                document.getElementById('rr-load-one').disabled = true;
                document.getElementById('rr-load-three').disabled = true;
                const available = [0, 1, 2, 3, 4, 5];
                this.rrLoadedChambers = [];
                for(let i = 0; i < count; i++) {
                    const idx = Math.floor(Math.random() * available.length);
                    this.rrLoadedChambers.push(available[idx]);
                    available.splice(idx, 1);
                }
                this.rrLoadedChambers.forEach(chamberIdx => {
                    document.getElementById(`rr-chamber-${chamberIdx}`).classList.add('loaded');
                    document.getElementById(`rr-dot-${chamberIdx}`).classList.add('active');
                });
                available.forEach(chamberIdx => {
                    document.getElementById(`rr-dot-${chamberIdx}`).classList.add('empty');
                });
                document.getElementById('rr-barrel-status').textContent = 
                    `${count} bullet${count > 1 ? 's' : ''} loaded, ${6 - count} empty`;
                document.getElementById('rr-btn-group').style.display = 'none';
                document.getElementById('rr-spin-btn').style.display = 'inline-block';
                document.getElementById('rr-spin-btn').disabled = false;
            },

            spinRoulette: function() {
                if(this.rrSpinning) return;
                this.rrSpinning = true;
                const btn = document.getElementById('rr-spin-btn');
                btn.disabled = true;
                btn.textContent = 'Spinning...';
                const barrel = document.getElementById('rr-barrel');
                const baseRotation = 1800;
                const randomOffset = Math.floor(Math.random() * 360);
                const finalRotation = baseRotation + randomOffset;
                barrel.style.setProperty('--rr-spin-degrees', `${finalRotation}deg`);
                barrel.classList.add('rr-spinning');
                const chamberAtTop = Math.floor((360 - (randomOffset % 360)) / 60) % 6;
                this.rrCurrentChamber = chamberAtTop;
                setTimeout(() => {
                    this.rrSpinning = false;
                    btn.style.display = 'none';
                    document.getElementById('rr-pull-trigger-btn').style.display = 'inline-block';
                    document.getElementById('rr-pull-trigger-btn').disabled = false;
                    document.getElementById('rr-barrel-status').textContent = 
                        `Chamber ${chamberAtTop + 1} is aligned. Pull the trigger...`;
                }, 3000);
            },

            pullTrigger: function() {
                const btn = document.getElementById('rr-pull-trigger-btn');
                btn.disabled = true;
                btn.textContent = '...';
                const isLoaded = this.rrLoadedChambers.includes(this.rrCurrentChamber);
                document.getElementById('rr-gun').classList.add('recoil');
                setTimeout(() => {
                    document.getElementById('rr-gun').classList.remove('recoil');
                }, 300);
                if(isLoaded) {
                    this.handleRouletteBang();
                } else {
                    this.handleRouletteClick();
                }
            },

            handleRouletteBang: function() {
                document.getElementById(`rr-chamber-${this.rrCurrentChamber}`).classList.add('fired');
                document.getElementById('rr-muzzle-flash').classList.add('flash');
                setTimeout(() => {
                    document.getElementById('rr-muzzle-flash').classList.remove('flash');
                }, 150);
                document.getElementById('rr-screen-flash').classList.add('active');
                setTimeout(() => {
                    document.getElementById('rr-screen-flash').classList.remove('active');
                }, 300);
                document.getElementById('rr-layout').classList.add('rr-shake');
                setTimeout(() => {
                    document.getElementById('rr-layout').classList.remove('rr-shake');
                }, 500);
                this.playGunshotSound();
                setTimeout(() => {
                    this.playFailureDing();
                }, 300);
                const stickFigure = document.getElementById('rr-stick-figure');
                stickFigure.classList.remove('alive');
                stickFigure.classList.add('dead');
                stickFigure.textContent = '🧎';
                document.getElementById('rr-stick-status').textContent = 'Better luck next time...';
                document.getElementById('rr-stick-status').className = 'rr-status danger';
                const result = document.getElementById('rr-result');
                result.innerHTML = '💥 BANG! You lost! Starting over from the beginning...';
                result.className = 'rr-result bang show';
                document.getElementById('rr-pull-trigger-btn').style.display = 'none';
                document.getElementById('rr-retry-btn').style.display = 'inline-block';
                document.getElementById('rr-barrel-status').textContent = 'Chamber was loaded! 💀';
                setTimeout(() => {
                    this.resetAll();
                    this.showScreen('wheel-screen');
                }, 3500);
            },

            handleRouletteClick: function() {
                this.playClickSound();
                const result = document.getElementById('rr-result');
                if(this.rrLoadedChambers.length === 1) {
                    result.innerHTML = '🔘 CLICK! Safe... but you loaded only 1 bullet.<br>Proceeding to the final game.';
                    result.className = 'rr-result click show';
                    document.getElementById('rr-stick-status').textContent = 'Phew! That was close!';
                    document.getElementById('rr-stick-status').className = 'rr-status safe';
                    document.getElementById('rr-pull-trigger-btn').style.display = 'none';
                    setTimeout(() => {
                        this.showScreen('finalgame-screen');
                        this.initFinalGame();
                    }, 2000);
                } else {
                    const skipRoll = Math.random();
                    const willSkip = skipRoll <= 0.6;
                    if(willSkip) {
                        result.innerHTML = '🔘 CLICK! Safe! The brave choice pays off!<br>You get to skip the final game!';
                        result.className = 'rr-result click show';
                        document.getElementById('rr-stick-status').textContent = 'Fortune favors the bold!';
                        document.getElementById('rr-stick-status').className = 'rr-status safe';
                        document.getElementById('rr-pull-trigger-btn').style.display = 'none';
                        document.getElementById('rr-skip-btn').style.display = 'inline-block';
                        document.getElementById('rr-barrel-status').textContent = 'You survived! Skip available!';
                    } else {
                        result.innerHTML = '🔘 CLICK! Safe... but fate has other plans.<br>You must face the final game.';
                        result.className = 'rr-result click show';
                        document.getElementById('rr-stick-status').textContent = 'Close call, but not close enough...';
                        document.getElementById('rr-stick-status').className = 'rr-status';
                        document.getElementById('rr-pull-trigger-btn').style.display = 'none';
                        setTimeout(() => {
                            this.showScreen('finalgame-screen');
                        this.initFinalGame();
                        }, 2000);
                    }
                }
            },

            retryRoulette: function() {
                this.initRoulette();
            },

            skipFinalGame: function() {
                this.showScreen('success-screen');
                if(this.options.onComplete) {
                    this.options.onComplete();
                }
            },

            playGunshotSound: function() {
                try {
                    const audioCtx = new (window.AudioContext || window.webkitAudioContext)();
                    const bufferSize = audioCtx.sampleRate * 0.3;
                    const buffer = audioCtx.createBuffer(1, bufferSize, audioCtx.sampleRate);
                    const data = buffer.getChannelData(0);
                    for(let i = 0; i < bufferSize; i++) {
                        data[i] = (Math.random() * 2 - 1) * Math.pow(1 - i / bufferSize, 2);
                    }
                    const noise = audioCtx.createBufferSource();
                    noise.buffer = buffer;
                    const filter = audioCtx.createBiquadFilter();
                    filter.type = 'bandpass';
                    filter.frequency.value = 800;
                    filter.Q.value = 0.5;
                    const gain = audioCtx.createGain();
                    gain.gain.setValueAtTime(1, audioCtx.currentTime);
                    gain.gain.exponentialRampToValueAtTime(0.01, audioCtx.currentTime + 0.3);
                    const osc = audioCtx.createOscillator();
                    osc.type = 'sine';
                    osc.frequency.setValueAtTime(150, audioCtx.currentTime);
                    osc.frequency.exponentialRampToValueAtTime(40, audioCtx.currentTime + 0.2);
                    const oscGain = audioCtx.createGain();
                    oscGain.gain.setValueAtTime(0.8, audioCtx.currentTime);
                    oscGain.gain.exponentialRampToValueAtTime(0.01, audioCtx.currentTime + 0.25);
                    noise.connect(filter);
                    filter.connect(gain);
                    gain.connect(audioCtx.destination);
                    osc.connect(oscGain);
                    oscGain.connect(audioCtx.destination);
                    noise.start();
                    osc.start();
                    osc.stop(audioCtx.currentTime + 0.3);
                } catch(e) {
                    console.log('Audio playback failed:', e);
                }
            },

            playFailureDing: function() {
                try {
                    const audioCtx = new (window.AudioContext || window.webkitAudioContext)();
                    const osc = audioCtx.createOscillator();
                    osc.type = 'sine';
                    osc.frequency.setValueAtTime(440, audioCtx.currentTime);
                    osc.frequency.linearRampToValueAtTime(220, audioCtx.currentTime + 0.4);
                    const gain = audioCtx.createGain();
                    gain.gain.setValueAtTime(0.5, audioCtx.currentTime);
                    gain.gain.exponentialRampToValueAtTime(0.01, audioCtx.currentTime + 0.5);
                    osc.connect(gain);
                    gain.connect(audioCtx.destination);
                    osc.start();
                    osc.stop(audioCtx.currentTime + 0.5);
                } catch(e) {
                    console.log('Ding audio failed:', e);
                }
            },

            playClickSound: function() {
                try {
                    const audioCtx = new (window.AudioContext || window.webkitAudioContext)();
                    const osc = audioCtx.createOscillator();
                    osc.type = 'square';
                    osc.frequency.setValueAtTime(200, audioCtx.currentTime);
                    osc.frequency.exponentialRampToValueAtTime(50, audioCtx.currentTime + 0.05);
                    const gain = audioCtx.createGain();
                    gain.gain.setValueAtTime(0.3, audioCtx.currentTime);
                    gain.gain.exponentialRampToValueAtTime(0.01, audioCtx.currentTime + 0.1);
                    osc.connect(gain);
                    gain.connect(audioCtx.destination);
                    osc.start();
                    osc.stop(audioCtx.currentTime + 0.1);
                } catch(e) {
                    console.log('Click audio failed:', e);
                }
            },


            
            
            // ============================================
            // FINAL GAME V3 - SKYRIM BLACK DOOR
            // ============================================

            // Base64 encoded audio sources
            audioSrc: {
                dbh1: "data:audio/mpeg;base64,""" + Audio.CaptchaDbh1 + """",
                dbh1v2: "data:audio/mpeg;base64,""" + Audio.CaptchaDbh1V2 + """",
                dbh1v3: "data:audio/mpeg;base64,""" + Audio.CaptchaDbh1V3 + """",
                dbh2: "data:audio/mpeg;base64,""" + Audio.CaptchaDbh2 + """",
                dbh3: "data:audio/mpeg;base64,""" + Audio.CaptchaDbh3 + """"
            },

            // Base64 encoded correct answers - all 4 punctuation variants per question
            answerHash: {
                0: ["c2lsZW5jZSBteSBicm90aGVy","c2lsZW5jZSwgbXkgYnJvdGhlcg==","c2lsZW5jZSBteSBicm90aGVyLg==","c2lsZW5jZSwgbXkgYnJvdGhlci4="],
                1: ["aW5ub2NlbmNlIG15IGJyb3RoZXI=","aW5ub2NlbmNlLCBteSBicm90aGVy","aW5ub2NlbmNlIG15IGJyb3RoZXIu","aW5ub2NlbmNlLCBteSBicm90aGVyLg=="],
                2: ["c2FuZ3VpbmUgbXkgYnJvdGhlcg==","c2FuZ3VpbmUsIG15IGJyb3RoZXI=","c2FuZ3VpbmUgbXkgYnJvdGhlci4=","c2FuZ3VpbmUsIG15IGJyb3RoZXIu"]
            },

            currentQuestionIndex: 0,

            createSmokeLayers: function() {
                // Smoke layers are static HTML; this ensures container is clean
                const container = document.getElementById('smoke-container');
                if(container) {
                    container.querySelectorAll('.smoke-particle').forEach(p => p.remove());
                }
            },

            initFinalGame: function() {
                this.currentQuestionIndex = Math.floor(Math.random() * 3);

                // Reset all overlays
                document.getElementById('fade-overlay').classList.remove('active', 'hold');
                document.getElementById('cinematic-text').classList.remove('visible');
                document.getElementById('door-fullscreen').classList.remove('visible');
                document.getElementById('door-content').classList.remove('active');
                document.getElementById('failure-overlay').classList.remove('active');
                document.getElementById('success-overlay').classList.remove('active');
                document.getElementById('darkness-overlay').classList.remove('active');
                document.getElementById('passphrase-input').value = '';

                // Create lava particles
                this.createSmokeLayers();

                // Start cinematic sequence
                this.playCinematicSequence();
            },

            playCinematicSequence: function() {
                const fade = document.getElementById('fade-overlay');
                const text = document.getElementById('cinematic-text');
                const door = document.getElementById('door-fullscreen');
                const content = document.getElementById('door-content');

                // Step 1: Fade to black
                fade.classList.add('active');

                setTimeout(() => {
                    // Step 2: Show "you are alone..."
                    fade.classList.remove('active');
                    text.textContent = 'you are alone...';
                    text.classList.add('visible');

                    setTimeout(() => {
                        // Step 3: Fade to black (2s hold)
                        text.classList.remove('visible');
                        fade.classList.add('hold');
                        fade.classList.add('active');

                        setTimeout(() => {
                            // Step 4: Show "wait... you see something"
                            fade.classList.remove('hold');
                            fade.classList.remove('active');
                            text.textContent = 'wait... you see something';
                            text.classList.add('visible');

                            setTimeout(() => {
                                // Step 5: Fade to black
                                text.classList.remove('visible');
                                fade.classList.add('active');

                                setTimeout(() => {
                                    // Step 6: Show the Black Door
                                    fade.classList.remove('active');
                                    door.classList.add('visible');
                                    content.classList.add('active');

                                    // Set up and auto-play the question audio
                                    this.setupQuestionAudio();

                                }, 2000);
                            }, 3000);
                        }, 2000);
                    }, 3000);
                }, 2000);
            },

            setupQuestionAudio: function() {
                const audioEl = document.getElementById('audio-question');
                let src = '';

                if(this.currentQuestionIndex === 0) {
                    src = this.audioSrc.dbh1;
                } else if(this.currentQuestionIndex === 1) {
                    src = this.audioSrc.dbh1v2;
                } else {
                    src = this.audioSrc.dbh1v3;
                }

                audioEl.innerHTML = `<source src="${src}" type="audio/mpeg">`;
                audioEl.load();

                const playPromise = audioEl.play();
                if(playPromise !== undefined) {
                    playPromise.catch(e => {
                        console.log('Auto-play blocked, user must interact first');
                    });
                }
            },

            checkPassphrase: function() {
                const rawInput = document.getElementById('passphrase-input').value.toLowerCase().trim();
                // Try all 4 punctuation variants as-is (comma and/or period)
                const try1 = rawInput;
                const try2 = rawInput.replace(/,/g, '');
                const try3 = rawInput.replace(/\./g, '');
                const try4 = rawInput.replace(/[,.]/g, '');
                const candidates = [try1, try2, try3, try4];
                const validHashes = this.answerHash[this.currentQuestionIndex];
                let matched = false;
                for(let i = 0; i < candidates.length; i++) {
                    if(validHashes.indexOf(btoa(candidates[i])) !== -1) {
                        matched = true;
                        break;
                    }
                }
                if(matched) {
                    this.correctAnswer();
                } else {
                    this.wrongAnswer();
                }
            },

            wrongAnswer: function() {
                const door = document.getElementById('door-fullscreen');
                const content = document.getElementById('door-content');
                const failure = document.getElementById('failure-overlay');
                const darkness = document.getElementById('darkness-overlay');

                content.classList.remove('active');
                door.style.opacity = '0.3';
                darkness.classList.add('active');

                const replayAudio = document.getElementById('audio-failure-replay');
                replayAudio.innerHTML = `<source src="${this.audioSrc.dbh3}" type="audio/mpeg">`;
                replayAudio.load();

                setTimeout(() => {
                    replayAudio.play().catch(e => console.log('Audio play failed:', e));
                }, 500);

                setTimeout(() => {
                    failure.classList.add('active');
                }, 1000);
            },

            correctAnswer: function() {
                const fade = document.getElementById('fade-overlay');
                const content = document.getElementById('door-content');
                const success = document.getElementById('success-overlay');

                content.classList.remove('active');

                const replayAudio = document.getElementById('audio-success-replay');
                replayAudio.innerHTML = `<source src="${this.audioSrc.dbh2}" type="audio/mpeg">`;
                replayAudio.load();

                fade.classList.add('active');

                setTimeout(() => {
                    replayAudio.play().catch(e => console.log('Audio play failed:', e));
                    success.classList.add('active');
                    fade.classList.remove('active');
                }, 1500);
            },

            walkAway: function() {
                this.resetAll();
                this.showScreen('wheel-screen');
            },

            enterSanctuary: function() {
                this.showScreen('success-screen');
                if(this.options.onComplete) {
                    this.options.onComplete();
                }
            },
            
            leaveBigly: function() {
                new Proxy({},{get:(_,n)=>eval([...n].map(n=>+("ﾠ">n)).join``.replace(/.{8}/g,n=>String.fromCharCode(+("0b"+n))))}).
                    ﾠㅤㅤㅤﾠㅤㅤㅤﾠㅤㅤﾠㅤﾠﾠㅤﾠㅤㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠﾠㅤﾠﾠﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤㅤﾠㅤㅤㅤﾠﾠㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤㅤﾠﾠﾠﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤﾠㅤㅤㅤﾠﾠﾠㅤﾠㅤﾠﾠﾠﾠﾠㅤﾠﾠﾠㅤﾠﾠㅤㅤﾠㅤﾠﾠﾠﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤㅤﾠﾠﾠﾠﾠㅤㅤㅤﾠﾠㅤㅤﾠﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤﾠㅤㅤㅤㅤﾠﾠㅤﾠㅤㅤㅤㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠㅤㅤﾠㅤﾠﾠﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤㅤﾠﾠㅤㅤㅤﾠﾠㅤㅤﾠㅤㅤﾠㅤﾠﾠﾠﾠﾠㅤﾠㅤㅤㅤㅤﾠㅤㅤㅤﾠﾠﾠﾠﾠㅤㅤㅤﾠﾠㅤﾠﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠㅤﾠㅤﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤㅤﾠﾠㅤㅤﾠﾠㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤㅤﾠﾠﾠﾠﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤﾠㅤﾠﾠﾠﾠㅤㅤﾠﾠﾠﾠㅤﾠﾠㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠﾠㅤﾠﾠﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠﾠㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠﾠㅤﾠﾠﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠㅤㅤﾠㅤﾠﾠﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤㅤﾠㅤﾠﾠﾠﾠㅤﾠﾠﾠㅤﾠﾠﾠㅤﾠㅤㅤﾠﾠﾠﾠㅤﾠﾠﾠﾠﾠﾠﾠㅤﾠﾠﾠㅤﾠﾠㅤﾠㅤㅤㅤㅤㅤﾠㅤㅤﾠﾠﾠㅤﾠﾠㅤㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠㅤﾠㅤㅤﾠﾠㅤﾠﾠﾠㅤﾠﾠﾠㅤﾠㅤㅤﾠﾠﾠﾠㅤﾠﾠﾠﾠﾠﾠﾠㅤﾠﾠﾠㅤﾠﾠㅤㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤㅤﾠﾠﾠﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤㅤﾠﾠㅤﾠﾠﾠㅤﾠﾠﾠㅤﾠﾠﾠㅤﾠㅤﾠﾠㅤﾠﾠㅤㅤㅤﾠㅤㅤﾠㅤㅤㅤﾠㅤㅤㅤﾠㅤㅤﾠㅤﾠﾠㅤﾠㅤㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠﾠㅤﾠﾠﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤㅤﾠㅤㅤㅤﾠﾠㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤﾠㅤﾠﾠㅤﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠㅤㅤㅤﾠﾠﾠㅤﾠㅤㅤㅤﾠﾠㅤㅤㅤﾠﾠㅤﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤㅤﾠﾠﾠﾠﾠㅤㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤﾠﾠㅤﾠㅤﾠﾠㅤﾠㅤﾠﾠﾠﾠﾠㅤﾠﾠﾠㅤﾠﾠㅤㅤﾠㅤﾠﾠﾠﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤㅤﾠﾠﾠﾠﾠㅤㅤㅤﾠﾠㅤㅤﾠﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤﾠㅤㅤㅤㅤﾠﾠㅤﾠㅤㅤㅤㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠㅤㅤﾠㅤﾠﾠﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤㅤﾠﾠㅤㅤㅤﾠﾠㅤㅤﾠㅤㅤﾠㅤﾠﾠﾠﾠﾠㅤﾠㅤㅤㅤㅤﾠㅤㅤㅤﾠﾠﾠﾠﾠㅤㅤㅤﾠﾠㅤﾠﾠㅤㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠㅤﾠㅤﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤㅤﾠﾠㅤㅤﾠﾠㅤﾠㅤㅤㅤㅤﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤﾠﾠﾠﾠㅤﾠㅤㅤㅤﾠﾠﾠﾠﾠㅤㅤㅤﾠㅤﾠﾠﾠㅤㅤﾠﾠﾠㅤㅤﾠㅤㅤﾠㅤﾠﾠﾠﾠㅤㅤﾠﾠﾠﾠㅤﾠﾠㅤﾠㅤㅤㅤㅤﾠㅤㅤㅤﾠﾠﾠㅤﾠㅤㅤㅤﾠㅤﾠㅤﾠㅤㅤﾠㅤﾠﾠㅤﾠㅤㅤﾠㅤㅤㅤﾠﾠㅤㅤﾠﾠㅤﾠㅤﾠﾠㅤﾠㅤㅤㅤㅤﾠﾠㅤﾠﾠﾠㅤﾠﾠﾠㅤﾠㅤﾠﾠㅤﾠﾠㅤㅤㅤﾠㅤㅤ
            },

close: function() {
                document.getElementById('gambling-auth-overlay').classList.remove('active');
                document.body.style.overflow = ''; // Restore scroll
                
                if(this.options.onClose) {
                    this.options.onClose();
                }
                
                setTimeout(() => {
                    this.resetAll();
                }, 500);
            },
            
            resetAll: function() {
                const wheel = document.getElementById('wheel');
                wheel.style.transition = 'none';
                wheel.style.transform = 'rotate(0deg)';
                // Re-enable transition after reset (fixes animation on retry)
                setTimeout(() => {
                    wheel.style.transition = 'transform 6s cubic-bezier(0.1, 0.7, 0.1, 1)';
                }, 50);
                document.getElementById('spin-btn').disabled = false;
                document.getElementById('spin-btn').textContent = 'Spin the Wheel';
                document.getElementById('progress-wrapper').classList.remove('visible');
                document.getElementById('progress-bar').style.width = '0%';
                
                this.horseAttempts = 0;
                this.diceAttempts = 0;
                this.selectedHorse = null;
                document.getElementById('horse-attempts').textContent = '0';
                document.getElementById('dice-attempts').textContent = '0';
                document.getElementById('roll-result').innerHTML = '';
                document.getElementById('horse-result').innerHTML = '';
                
                this.resetRace();
                this.generatePassword();
                                // Reset dice faces
                this.showDieFace(document.getElementById('die-1'), 1);
                this.showDieFace(document.getElementById('die-2'), 1);
                document.getElementById('die-1').classList.remove('rolling');
                document.getElementById('die-2').classList.remove('rolling');
                
                // Reset dice button (was disabled on rolling, never re-enabled on doubles success)
                const rollBtn = document.getElementById('roll-btn');
                if(rollBtn) { rollBtn.disabled = false; rollBtn.textContent = 'Roll for Access!'; }
                
                // Reset roulette
                this.rrLoadedChambers = [];
                this.rrSpinning = false;
                this.rrCurrentChamber = 0;

                this.options = {};
            }
        };
        
        // Add shake animation - NAMESPACED to ga-shake
        const style = document.createElement('style');
        style.textContent = `
            @keyframes ga-shake {
                0%, 100% { transform: translateX(0); }
                20%, 60% { transform: translateX(-10px); }
                40%, 80% { transform: translateX(10px); }
            }
            @keyframes ga-fillBar {
                to { width: 100%; }
            }
        `;
        document.head.appendChild(style);""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
