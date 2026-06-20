module ConvertedFiles.Wasm.Android.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0, user-scalable=no" ]
            title [] [
                str "Android Phone Simulator + APK Sideload"
            ]
            style [] [
                    rawText ("""/* ============================================================
   ANDROID PHONE SIMULATOR WITH APK SIDELOADING
   A standalone, self-contained Android simulator that can
   parse and render APK files entirely in the browser.
   ============================================================ */

:root {
  --phone-width: 380px;
  --phone-height: 780px;
  --screen-width: 360px;
  --screen-height: 760px;
  --status-h: 28px;
  --nav-h: 48px;
  --bg: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  --wallpaper: linear-gradient(135deg, #1a1a2e 0%, #16213e 50%, #0f3460 100%);
  --accent: #1a73e8;
  --accent2: #8ab4f8;
  --surface: #1c1c1e;
  --surface-light: #2c2c2e;
  --text: #ffffff;
  --text-secondary: #8e8e93;
  --success: #34c759;
  --warning: #ff9500;
  --danger: #ff3b30;
  --notch-h: 28px;
  --pill-w: 120px;
  --pill-h: 4px;
  --sideload: #5856d6;
}

* { margin: 0; padding: 0; box-sizing: border-box; -webkit-tap-highlight-color: transparent; }

body {
  width: 100vw; height: 100vh;
  background: var(--bg);
  display: flex; align-items: center; justify-content: center;
  overflow: hidden;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif;
  user-select: none;
}

/* ===== PHONE FRAME ===== */
.phone-container {
  position: relative;
  width: var(--phone-width); height: var(--phone-height);
  background: #111;
  border-radius: 48px; padding: 10px;
  box-shadow: 0 0 0 2px #333, 0 0 0 4px #111, 0 20px 60px rgba(0,0,0,0.6), 0 40px 100px rgba(0,0,0,0.3);
  transition: transform 0.3s ease;
}

.phone-screen {
  position: relative; width: 100%; height: 100%;
  background: #000; border-radius: 40px; overflow: hidden;
  display: flex; flex-direction: column;
}

.screen-off { background: #000 !important; }
.screen-off * { opacity: 0 !important; pointer-events: none !important; }

/* Side buttons */
.btn-power {
  position: absolute; right: -6px; top: 140px;
  width: 6px; height: 80px; background: #222;
  border-radius: 0 3px 3px 0; cursor: pointer;
  transition: transform 0.1s; z-index: 10;
}
.btn-power:active { transform: translateX(-2px); }
.btn-vol-up {
  position: absolute; left: -6px; top: 120px;
  width: 6px; height: 50px; background: #222;
  border-radius: 3px 0 0 3px; cursor: pointer;
  transition: transform 0.1s; z-index: 10;
}
.btn-vol-up:active { transform: translateX(2px); }
.btn-vol-down {
  position: absolute; left: -6px; top: 180px;
  width: 6px; height: 50px; background: #222;
  border-radius: 3px 0 0 3px; cursor: pointer;
  transition: transform 0.1s; z-index: 10;
}
.btn-vol-down:active { transform: translateX(2px); }

/* ===== SIDELOAD BUTTON (NEW) ===== */
.btn-sideload {
  position: absolute; right: -7px; top: 280px;
  width: 7px; height: 60px;
  background: linear-gradient(180deg, #5856d6, #af52de);
  border-radius: 0 4px 4px 0;
  cursor: pointer;
  transition: transform 0.1s;
  z-index: 10;
  display: flex;
  align-items: center;
  justify-content: center;
  writing-mode: vertical-rl;
  text-orientation: mixed;
  font-size: 6px;
  font-weight: 700;
  color: rgba(255,255,255,0.6);
  letter-spacing: 1px;
  text-transform: uppercase;
}
.btn-sideload:hover {
  transform: translateX(-2px);
  box-shadow: 0 0 8px rgba(88, 86, 214, 0.5);
}
.btn-sideload:active { transform: translateX(-1px); }
.btn-sideload.pulse {
  animation: sidePulse 1.5s ease-in-out infinite;
}
@keyframes sidePulse {
  0%, 100% { box-shadow: 0 0 0 0 rgba(88,86,214,0.4); }
  50% { box-shadow: 0 0 0 6px rgba(88,86,214,0); }
}

/* ===== NOTCH ===== */
.notch {
  position: absolute; top: 12px; left: 50%; transform: translateX(-50%);
  width: var(--pill-w); height: var(--notch-h);
  background: #000; border-radius: 14px; z-index: 1000;
  display: flex; align-items: center; justify-content: center; gap: 8px;
}
.notch-cam { width: 10px; height: 10px; background: #0a0a0a; border-radius: 50%; border: 1px solid #1a1a1a; box-shadow: inset 0 0 2px #000; }
.notch-speaker { width: 40px; height: 4px; background: #222; border-radius: 2px; }

/* ===== STATUS BAR ===== */
.status-bar {
  position: absolute; top: 0; left: 0; right: 0; height: var(--status-h);
  display: flex; align-items: center; justify-content: space-between;
  padding: 0 18px; z-index: 999;
  font-size: 12px; font-weight: 600; color: #fff;
  text-shadow: 0 1px 3px rgba(0,0,0,0.5);
}
.status-left { display: flex; align-items: center; gap: 4px; }
.status-right { display: flex; align-items: center; gap: 5px; }
.battery-wrap { display: flex; align-items: center; gap: 2px; }
.battery-icon {
  width: 18px; height: 9px; border: 1px solid rgba(255,255,255,0.7);
  border-radius: 2px; position: relative;
  display: flex; align-items: center; padding: 1px;
}
.battery-icon::after {
  content: ""; position: absolute; right: -3px;
  width: 2px; height: 4px; background: rgba(255,255,255,0.7); border-radius: 0 1px 1px 0;
}
.battery-fill { height: 100%; background: #34c759; border-radius: 1px; transition: width 0.3s; }

/* ===== NAVIGATION BAR ===== */
.nav-bar {
  position: absolute; bottom: 0; left: 0; right: 0;
  height: var(--nav-h); z-index: 999;
  display: flex; align-items: center; justify-content: space-around;
  padding: 0 40px;
}
.nav-pill {
  width: var(--pill-w); height: var(--pill-h); background: rgba(255,255,255,0.3);
  border-radius: 4px; cursor: pointer; transition: all 0.2s;
}
.nav-pill:hover { background: rgba(255,255,255,0.5); width: 130px; }
.nav-btn { background: none; border: none; color: rgba(255,255,255,0.7); font-size: 20px; cursor: pointer; padding: 8px; transition: color 0.2s; display: none; }
.nav-btn:hover { color: #fff; }

/* ===== SCREEN CONTENT ===== */
.screen-content {
  flex: 1; position: relative; overflow: hidden;
  display: flex; flex-direction: column;
  border-radius: 40px;
}

/* ===== LOCK SCREEN ===== */
.lock-screen {
  position: absolute; inset: 0; z-index: 500;
  display: flex; flex-direction: column;
  align-items: center; padding-top: 100px; gap: 8px;
  transition: opacity 0.3s, transform 0.3s;
  cursor: pointer;
}
.lock-screen.hidden { opacity: 0; pointer-events: none; transform: translateY(-20px); }
.lock-clock { font-size: 56px; font-weight: 200; color: #fff; letter-spacing: -1px; text-shadow: 0 2px 10px rgba(0,0,0,0.3); }
.lock-date { font-size: 15px; color: rgba(255,255,255,0.8); font-weight: 400; }
.lock-notifs { position: absolute; top: 180px; left: 20px; right: 20px; display: flex; flex-direction: column; gap: 8px; }
.lock-notif-item {
  background: rgba(255,255,255,0.15); backdrop-filter: blur(20px);
  border-radius: 16px; padding: 12px; display: flex; gap: 10px;
  color: #fff; font-size: 12px; animation: slideIn 0.4s ease;
}
.lock-hint { position: absolute; bottom: 40px; font-size: 13px; color: rgba(255,255,255,0.5); animation: pulseHint 2s ease infinite; }
@keyframes pulseHint { 0%,100%{opacity:0.3} 50%{opacity:0.8} }
@keyframes slideIn { from{opacity:0;transform:translateY(-10px)} to{opacity:1;transform:translateY(0)} }

/* ===== HOME SCREEN ===== */
.home-screen {
  flex: 1; position: relative;
  background: var(--wallpaper);
  display: flex; flex-direction: column;
  padding: var(--status-h) 16px var(--nav-h);
}

/* ===== SEARCH BAR ===== */
.search-bar {
  display: flex; align-items: center; gap: 8px;
  background: rgba(255,255,255,0.15); backdrop-filter: blur(20px);
  border-radius: 24px; padding: 10px 16px;
  margin: 8px 0 12px; color: rgba(255,255,255,0.7);
  font-size: 14px; cursor: pointer; transition: all 0.2s;
}
.search-bar:hover { background: rgba(255,255,255,0.25); }

/* ===== WIDGET ===== */
.widget { margin-bottom: 16px; animation: fadeIn 0.6s ease; }
.widget-time { font-size: 42px; font-weight: 200; color: #fff; line-height: 1; }
.widget-date { font-size: 13px; color: rgba(255,255,255,0.7); margin-top: 4px; }
.widget-weather { display: flex; align-items: center; gap: 6px; font-size: 13px; color: rgba(255,255,255,0.8); margin-top: 4px; }

/* ===== APP GRID ===== */
.app-grid { display: grid; grid-template-columns: repeat(4, 1fr); gap: 12px 8px; flex: 1; align-content: start; padding: 0 4px; }
.app-icon { display: flex; flex-direction: column; align-items: center; gap: 6px; cursor: pointer; transition: transform 0.15s; }
.app-icon:active { transform: scale(0.88); }
.app-icon-img {
  width: 56px; height: 56px; border-radius: 14px;
  display: flex; align-items: center; justify-content: center;
  font-size: 28px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.2);
  transition: all 0.2s; position: relative; overflow: hidden;
}
.app-icon-img.sideloaded {
  border: 2px solid rgba(88, 86, 214, 0.5);
  box-shadow: 0 0 12px rgba(88, 86, 214, 0.3), 0 4px 12px rgba(0,0,0,0.2);
}
.app-icon-img.sideloaded::after {
  content: "";
  position: absolute;
  top: 2px; right: 2px;
  width: 8px; height: 8px;
  background: #5856d6;
  border-radius: 50%;
  border: 1px solid rgba(255,255,255,0.3);
}
.app-icon-label { font-size: 11px; color: #fff; text-shadow: 0 1px 3px rgba(0,0,0,0.5); max-width: 64px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap; text-align: center; }

/* ===== DOCK ===== */
.dock {
  position: absolute; bottom: calc(var(--nav-h) + 8px);
  left: 12px; right: 12px;
  display: flex; justify-content: space-around; align-items: center;
  background: rgba(255,255,255,0.15); backdrop-filter: blur(20px);
  border-radius: 28px; padding: 8px 4px;
}

/* ===== APP DRAWER ===== */
.app-drawer {
  position: absolute; inset: 0;
  background: rgba(0,0,0,0.95); backdrop-filter: blur(40px);
  z-index: 200; display: flex; flex-direction: column;
  padding: 42px 16px var(--nav-h);
  transform: translateY(100%);
  transition: transform 0.35s cubic-bezier(0.25,0.46,0.45,0.94);
  border-radius: 40px;
}
.app-drawer.open { transform: translateY(0); }
.drawer-search {
  display: flex; align-items: center; gap: 10px;
  background: rgba(255,255,255,0.1); border-radius: 24px;
  padding: 10px 16px; margin-bottom: 16px;
  color: rgba(255,255,255,0.6); font-size: 14px;
}
.drawer-grid {
  display: grid; grid-template-columns: repeat(4, 1fr); gap: 8px;
  overflow-y: auto; flex: 1; padding-bottom: 20px;
}
.drawer-grid .app-icon { gap: 4px; }
.drawer-grid .app-icon-img { width: 52px; height: 52px; border-radius: 13px; font-size: 24px; }
.drawer-grid .app-icon-label { font-size: 10px; color: rgba(255,255,255,0.85); }
.drawer-hint { text-align: center; font-size: 12px; color: rgba(255,255,255,0.3); padding: 8px; cursor: pointer; }

/* ===== NOTIFICATION PANEL ===== */
.notif-panel {
  position: absolute; inset: 0;
  background: rgba(20,20,30,0.95); backdrop-filter: blur(30px);
  z-index: 600; padding: 42px 14px 14px;
  transform: translateY(-100%);
  transition: transform 0.3s cubic-bezier(0.25,0.46,0.45,0.94);
  display: flex; flex-direction: column; gap: 10px;
  border-radius: 40px;
}
.notif-panel.open { transform: translateY(0); }
.notif-panel-clock { font-size: 32px; font-weight: 300; color: #fff; margin-bottom: 4px; }
.notif-panel-date { font-size: 13px; color: rgba(255,255,255,0.6); margin-bottom: 8px; }
.notif-toggles { display: grid; grid-template-columns: repeat(4, 1fr); gap: 8px; margin-bottom: 8px; }
.notif-toggle {
  aspect-ratio: 1; border-radius: 16px;
  display: flex; flex-direction: column; align-items: center; justify-content: center;
  gap: 4px; font-size: 18px; cursor: pointer; transition: all 0.2s;
  background: rgba(255,255,255,0.08); color: #fff; border: none; padding: 4px;
}
.notif-toggle.active { background: var(--accent); }
.notif-toggle-label { font-size: 9px; }
.notif-list { flex: 1; overflow-y: auto; display: flex; flex-direction: column; gap: 8px; }
.notif-item {
  background: rgba(255,255,255,0.08); border-radius: 16px; padding: 12px;
  display: flex; gap: 10px; color: #fff; font-size: 12px; animation: slideIn 0.3s ease;
}
.notif-item-icon { width: 36px; height: 36px; border-radius: 10px; display: flex; align-items: center; justify-content: center; font-size: 18px; flex-shrink: 0; }
.notif-item-title { font-weight: 600; margin-bottom: 2px; }

/* ===== RECENT APPS ===== */
.recent-apps {
  position: absolute; inset: 0;
  background: rgba(0,0,0,0.9); backdrop-filter: blur(40px);
  z-index: 400; padding: 50px 16px calc(var(--nav-h) + 20px);
  transform: translateY(100%);
  transition: transform 0.35s cubic-bezier(0.25,0.46,0.45,0.94);
  display: flex; flex-direction: column; gap: 12px;
  border-radius: 40px;
}
.recent-apps.open { transform: translateY(0); }
.recent-title { font-size: 18px; font-weight: 600; color: #fff; margin-bottom: 4px; }
.recent-card {
  background: rgba(255,255,255,0.1); border-radius: 20px;
  height: 140px; display: flex; align-items: center; justify-content: center;
  color: #fff; font-size: 14px; position: relative; overflow: hidden;
}
.recent-card-close { position: absolute; top: 8px; right: 8px; width: 24px; height: 24px; background: rgba(0,0,0,0.5); border-radius: 50%; border: none; color: #fff; cursor: pointer; font-size: 12px; }

/* ===== APP WINDOWS ===== */
.app-windows { position: absolute; inset: 0; z-index: 300; pointer-events: none; }
.app-window {
  position: absolute; inset: 0;
  background: var(--surface);
  border-radius: 40px;
  display: flex; flex-direction: column;
  transform: translateY(110%);
  transition: transform 0.35s cubic-bezier(0.25,0.46,0.45,0.94);
  pointer-events: none; overflow: hidden;
}
.app-window.active { transform: translateY(0); pointer-events: all; }
@keyframes fadeIn { from{opacity:0;transform:translateY(10px)} to{opacity:1;transform:translateY(0)} }

.app-header {
  height: 48px; display: flex; align-items: center; gap: 8px;
  padding: 0 12px; flex-shrink: 0;
  background: rgba(0,0,0,0.3); border-bottom: 1px solid rgba(255,255,255,0.05);
}
.app-header-btn { background: none; border: none; color: var(--accent2); font-size: 18px; cursor: pointer; padding: 8px; }
.app-header-title { color: #fff; font-size: 16px; font-weight: 600; flex: 1; text-align: center; margin-right: 34px; }
.app-body { flex: 1; overflow-y: auto; padding: 16px; color: #fff; font-size: 14px; }

/* ===== VOLUME OVERLAY ===== */
.vol-overlay {
  position: absolute; top: 50%; right: 20px; transform: translateY(-50%);
  width: 6px; height: 120px; background: rgba(255,255,255,0.2);
  border-radius: 3px; z-index: 1001; display: none;
}
.vol-fill { position: absolute; bottom: 0; left: 0; right: 0; background: #fff; border-radius: 3px; transition: height 0.1s; }

/* ===== APP SPECIFIC STYLES ===== */
.calc-display { background: rgba(0,0,0,0.3); border-radius: 16px; padding: 16px; text-align: right; font-size: 36px; font-weight: 300; color: #fff; margin-bottom: 12px; min-height: 60px; word-break: break-all; }
.calc-prev { font-size: 16px; color: rgba(255,255,255,0.5); min-height: 20px; }
.calc-grid { display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px; }
.calc-btn {
  aspect-ratio: 1; border-radius: 50%; border: none;
  font-size: 22px; font-weight: 500; cursor: pointer; transition: all 0.15s;
  display: flex; align-items: center; justify-content: center;
}
.calc-btn:active { transform: scale(0.9); opacity: 0.7; }
.calc-btn.gray { background: #a5a5a5; color: #000; }
.calc-btn.orange { background: #ff9f0a; color: #fff; }
.calc-btn.dark { background: #333; color: #fff; }

/* Browser */
.br-toolbar { display: flex; gap: 6px; margin-bottom: 8px; }
.br-btn { background: rgba(255,255,255,0.1); border: none; color: #fff; border-radius: 8px; padding: 6px 12px; font-size: 12px; cursor: pointer; }
.br-input { flex: 1; background: rgba(255,255,255,0.1); border: none; border-radius: 8px; padding: 6px 12px; color: #fff; font-size: 13px; outline: none; }
.br-frame { width: 100%; height: calc(100% - 44px); border: none; border-radius: 8px; background: #fff; }

/* Phone */
.dial-pad { display: grid; grid-template-columns: repeat(3, 1fr); gap: 12px; padding: 20px; }
.dial-btn { background: rgba(255,255,255,0.1); border: none; border-radius: 50%; aspect-ratio: 1; color: #fff; font-size: 24px; cursor: pointer; display: flex; flex-direction: column; align-items: center; justify-content: center; }
.dial-btn:active { background: rgba(255,255,255,0.2); transform: scale(0.95); }
.dial-btn small { font-size: 9px; color: rgba(255,255,255,0.5); letter-spacing: 2px; }
.call-btn { background: var(--success); width: 60px; height: 60px; border-radius: 50%; border: none; color: #fff; font-size: 24px; cursor: pointer; margin: 10px auto; display: flex; align-items: center; justify-content: center; }
.call-log-item { display: flex; align-items: center; gap: 12px; padding: 10px 0; border-bottom: 1px solid rgba(255,255,255,0.05); }

/* Messages */
.msg-item { display: flex; align-items: center; gap: 12px; padding: 12px 0; border-bottom: 1px solid rgba(255,255,255,0.05); cursor: pointer; }
.msg-avatar { width: 44px; height: 44px; border-radius: 50%; display: flex; align-items: center; justify-content: center; font-size: 18px; font-weight: 600; color: #fff; flex-shrink: 0; }
.msg-info { flex: 1; min-width: 0; }
.msg-name { font-weight: 600; margin-bottom: 2px; }
.msg-preview { font-size: 12px; color: var(--text-secondary); white-space: nowrap; overflow: hidden; text-overflow: ellipsis; }
.msg-time { font-size: 11px; color: var(--text-secondary); }
.chat-messages { display: flex; flex-direction: column; gap: 8px; padding: 8px 0; max-height: calc(var(--screen-height) - 200px); overflow-y: auto; }
.chat-bubble { max-width: 75%; padding: 10px 14px; border-radius: 18px; font-size: 14px; line-height: 1.4; word-wrap: break-word; }
.chat-bubble.sent { align-self: flex-end; background: var(--accent); color: #fff; border-bottom-right-radius: 4px; }
.chat-bubble.received { align-self: flex-start; background: rgba(255,255,255,0.1); color: #fff; border-bottom-left-radius: 4px; }
.chat-input-row { display: flex; gap: 8px; padding: 8px 0; }
.chat-input { flex: 1; background: rgba(255,255,255,0.1); border: none; border-radius: 20px; padding: 10px 16px; color: #fff; font-size: 14px; outline: none; }
.chat-send { background: var(--accent); border: none; border-radius: 50%; width: 40px; height: 40px; color: #fff; cursor: pointer; font-size: 16px; }

/* Camera */
.cam-viewfinder { flex: 1; background: linear-gradient(45deg, #1a1a2e, #16213e, #0f3460, #1a1a2e); background-size: 400% 400%; animation: camGrad 8s ease infinite; position: relative; border-radius: 16px; display: flex; align-items: center; justify-content: center; }
@keyframes camGrad { 0%{background-position:0%50%} 50%{background-position:100%50%} 100%{background-position:0%50%} }
.cam-focus { width: 60px; height: 60px; border: 2px solid rgba(255,255,255,0.5); border-radius: 8px; position: absolute; }
.cam-controls { display: flex; align-items: center; justify-content: space-around; padding: 16px 0; }
.cam-shutter { width: 60px; height: 60px; border: 4px solid #fff; border-radius: 50%; cursor: pointer; transition: all 0.1s; background: none; }
.cam-shutter:active { transform: scale(0.9); background: rgba(255,255,255,0.3); }
.cam-mode { display: flex; gap: 16px; justify-content: center; padding: 8px 0; }
.cam-mode-btn { background: none; border: none; color: rgba(255,255,255,0.5); font-size: 12px; cursor: pointer; transition: color 0.2s; }
.cam-mode-btn.active { color: #ffeb3b; }

/* Gallery */
.gallery-grid { display: grid; grid-template-columns: repeat(3, 1fr); gap: 3px; }
.gallery-item { aspect-ratio: 1; border-radius: 4px; display: flex; align-items: center; justify-content: center; font-size: 32px; cursor: pointer; transition: transform 0.15s; }
.gallery-item:active { transform: scale(0.95); }

/* Clock */
.clock-tabs { display: flex; gap: 4px; margin-bottom: 12px; }
.clock-tab { flex: 1; background: rgba(255,255,255,0.08); border: none; border-radius: 8px; padding: 8px; color: var(--text-secondary); font-size: 12px; cursor: pointer; }
.clock-tab.active { background: rgba(255,255,255,0.2); color: #fff; }
.clock-section { display: none; }
.clock-section.active { display: block; }
.alarm-item { display: flex; align-items: center; justify-content: space-between; padding: 12px 0; border-bottom: 1px solid rgba(255,255,255,0.05); }
.stopwatch-display { font-size: 48px; font-weight: 200; text-align: center; margin: 20px 0; font-variant-numeric: tabular-nums; }
.sw-controls { display: flex; gap: 20px; justify-content: center; }
.sw-btn { background: rgba(255,255,255,0.15); border: none; border-radius: 50%; width: 64px; height: 64px; color: #fff; font-size: 14px; cursor: pointer; }
.sw-btn.primary { background: var(--success); }
.timer-inputs { display: flex; gap: 8px; justify-content: center; margin: 20px 0; }
.timer-inputs input { width: 60px; background: rgba(255,255,255,0.1); border: none; border-radius: 12px; padding: 12px; color: #fff; font-size: 24px; text-align: center; }

/* Settings */
.settings-item { display: flex; align-items: center; gap: 12px; padding: 12px 0; border-bottom: 1px solid rgba(255,255,255,0.05); cursor: pointer; }
.settings-icon { width: 30px; height: 30px; border-radius: 8px; display: flex; align-items: center; justify-content: center; font-size: 14px; flex-shrink: 0; }
.settings-info { flex: 1; }
.settings-title { font-size: 14px; }
.settings-sub { font-size: 11px; color: var(--text-secondary); }
.settings-toggle { width: 48px; height: 28px; background: rgba(255,255,255,0.2); border-radius: 14px; position: relative; cursor: pointer; transition: background 0.2s; flex-shrink: 0; }
.settings-toggle::after { content: ""; position: absolute; width: 24px; height: 24px; background: #fff; border-radius: 50%; top: 2px; left: 2px; transition: transform 0.2s; }
.settings-toggle.on { background: var(--success); }
.settings-toggle.on::after { transform: translateX(20px); }

/* Files */
.file-grid { display: grid; grid-template-columns: repeat(2, 1fr); gap: 10px; }
.file-folder { background: rgba(255,255,255,0.08); border-radius: 16px; padding: 16px; text-align: center; cursor: pointer; transition: background 0.2s; }
.file-folder:active { background: rgba(255,255,255,0.15); }

/* Contacts */
.contact-item { display: flex; align-items: center; gap: 12px; padding: 10px 0; border-bottom: 1px solid rgba(255,255,255,0.05); cursor: pointer; }
.contact-avatar { width: 40px; height: 40px; border-radius: 50%; display: flex; align-items: center; justify-content: center; color: #fff; font-weight: 600; font-size: 16px; }
.contact-name { font-weight: 500; font-size: 15px; }
.add-contact-btn { position: absolute; bottom: 70px; right: 20px; width: 50px; height: 50px; background: var(--accent); border-radius: 50%; border: none; color: #fff; font-size: 24px; cursor: pointer; box-shadow: 0 4px 12px rgba(0,0,0,0.3); z-index: 10; }
.save-contact-btn { background: var(--accent); border: none; border-radius: 12px; padding: 12px 24px; color: #fff; font-size: 15px; cursor: pointer; margin-top: 16px; width: 100%; }
.contact-input { width: 100%; background: rgba(255,255,255,0.1); border: none; border-radius: 10px; padding: 12px; color: #fff; font-size: 15px; margin-bottom: 10px; outline: none; }

/* ===== APK SIDELOAD UI ===== */
.sideload-overlay {
  position: absolute; inset: 0; z-index: 2000;
  background: rgba(0,0,0,0.85); backdrop-filter: blur(30px);
  display: none; flex-direction: column;
  border-radius: 40px; overflow: hidden;
  animation: fadeIn 0.3s ease;
}
.sideload-overlay.active { display: flex; }
.sideload-header {
  display: flex; align-items: center; gap: 8px;
  padding: 12px 16px;
  border-bottom: 1px solid rgba(255,255,255,0.1);
}
.sideload-title { color: #fff; font-size: 16px; font-weight: 600; flex: 1; }
.sideload-close { background: none; border: none; color: rgba(255,255,255,0.6); font-size: 20px; cursor: pointer; padding: 4px; }
.sideload-body { flex: 1; overflow-y: auto; padding: 16px; }

.sideload-dropzone {
  border: 2px dashed rgba(88, 86, 214, 0.5);
  border-radius: 20px;
  padding: 40px 20px;
  text-align: center;
  color: rgba(255,255,255,0.6);
  transition: all 0.3s;
  cursor: pointer;
  margin-bottom: 16px;
}
.sideload-dropzone:hover, .sideload-dropzone.dragover {
  border-color: #5856d6;
  background: rgba(88, 86, 214, 0.1);
  color: #fff;
}
.sideload-dropzone .icon { font-size: 48px; margin-bottom: 12px; display: block; }
.sideload-dropzone .title { font-size: 16px; font-weight: 600; margin-bottom: 6px; color: #fff; }
.sideload-dropzone .subtitle { font-size: 12px; color: rgba(255,255,255,0.4); }

.sideload-progress {
  display: none;
  margin-bottom: 16px;
}
.sideload-progress.active { display: block; }
.sideload-progress-bar {
  height: 6px;
  background: rgba(255,255,255,0.1);
  border-radius: 3px;
  overflow: hidden;
  margin-bottom: 8px;
}
.sideload-progress-fill {
  height: 100%;
  width: 0%;
  background: linear-gradient(90deg, #5856d6, #af52de);
  border-radius: 3px;
  transition: width 0.3s ease;
}
.sideload-progress-text {
  font-size: 12px;
  color: rgba(255,255,255,0.5);
  text-align: center;
}

/* APK Info Panel */
.apk-info { display: none; }
.apk-info.active { display: block; animation: fadeIn 0.4s ease; }
.apk-info-header {
  display: flex; align-items: center; gap: 16px;
  margin-bottom: 20px;
}
.apk-info-icon {
  width: 72px; height: 72px; border-radius: 18px;
  background: linear-gradient(135deg, #5856d6, #af52de);
  display: flex; align-items: center; justify-content: center;
  font-size: 36px; flex-shrink: 0;
}
.apk-info-meta { flex: 1; min-width: 0; }
.apk-info-name { font-size: 20px; font-weight: 600; color: #fff; margin-bottom: 4px; word-break: break-word; }
.apk-info-pkg { font-size: 12px; color: rgba(255,255,255,0.4); font-family: monospace; }
.apk-info-version { font-size: 12px; color: var(--text-secondary); }

.apk-info-section { margin-bottom: 20px; }
.apk-info-section-title {
  font-size: 13px; font-weight: 600;
  color: rgba(255,255,255,0.5);
  text-transform: uppercase;
  letter-spacing: 1px;
  margin-bottom: 10px;
}
.apk-perm-list { display: flex; flex-direction: column; gap: 8px; }
.apk-perm-item {
  display: flex; align-items: center; gap: 10px;
  padding: 10px 12px;
  background: rgba(255,255,255,0.05);
  border-radius: 12px;
  font-size: 13px;
}
.apk-perm-icon { font-size: 16px; }
.apk-perm-name { flex: 1; }
.apk-perm-level {
  font-size: 10px; padding: 2px 8px;
  border-radius: 10px; font-weight: 600;
}
.apk-perm-level.dangerous { background: rgba(255, 59, 48, 0.2); color: #ff3b30; }
.apk-perm-level.normal { background: rgba(52, 199, 89, 0.2); color: #34c759; }
.apk-perm-level.signature { background: rgba(255, 149, 0, 0.2); color: #ff9500; }

.apk-activity-list { display: flex; flex-direction: column; gap: 6px; }
.apk-activity-item {
  padding: 10px 12px;
  background: rgba(255,255,255,0.05);
  border-radius: 12px;
  font-size: 13px;
  display: flex; align-items: center;
  gap: 10px;
}
.apk-activity-main { border: 1px solid rgba(88, 86, 214, 0.4); }
.apk-activity-badge {
  font-size: 9px; padding: 2px 8px;
  background: rgba(88, 86, 214, 0.3);
  color: #af52de; border-radius: 8px;
  font-weight: 600;
}

.apk-resource-grid {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 6px;
}
.apk-resource-item {
  aspect-ratio: 1;
  background: rgba(255,255,255,0.05);
  border-radius: 10px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 11px;
  color: rgba(255,255,255,0.5);
  overflow: hidden;
}
.apk-resource-item.has-image {
  background-size: cover;
  background-position: center;
}

.apk-action-btns {
  display: flex; gap: 10px;
  margin-top: 20px;
  position: sticky;
  bottom: 0;
  padding: 10px 0;
  background: var(--surface);
}
.apk-btn {
  flex: 1; padding: 14px;
  border-radius: 14px; border: none;
  font-size: 15px; font-weight: 600;
  cursor: pointer; transition: all 0.2s;
}
.apk-btn.install {
  background: linear-gradient(135deg, #5856d6, #af52de);
  color: #fff;
}
.apk-btn.install:hover { opacity: 0.9; transform: translateY(-1px); }
.apk-btn.install:active { transform: translateY(0); }
.apk-btn.preview {
  background: rgba(255,255,255,0.1);
  color: #fff;
}
.apk-btn.preview:hover { background: rgba(255,255,255,0.2); }

/* ===== APK APP PREVIEW (LAUNCHED APP) ===== */
.apk-preview-window {
  position: absolute; inset: 0; z-index: 300;
  background: #fff;
  border-radius: 40px;
  display: none; flex-direction: column;
  transform: translateY(110%);
  transition: transform 0.35s cubic-bezier(0.25,0.46,0.45,0.94);
  overflow: hidden;
}
.apk-preview-window.active {
  display: flex;
  transform: translateY(0);
}
.apk-preview-header {
  height: 48px;
  display: flex; align-items: center;
  padding: 0 12px;
  flex-shrink: 0;
  border-bottom: 1px solid rgba(0,0,0,0.08);
  background: #fff;
}
.apk-preview-back {
  background: none; border: none;
  font-size: 20px; cursor: pointer;
  padding: 8px; color: #333;
}
.apk-preview-title {
  flex: 1; text-align: center;
  font-size: 15px; font-weight: 600;
  color: #333; margin-right: 36px;
}
.apk-preview-body {
  flex: 1; overflow-y: auto;
  background: #fafafa;
}

/* Android Layout Rendered Styles */
.apk-rendered-view {
  font-family: -apple-system, BlinkMacSystemFont, "Roboto", sans-serif;
  color: #333;
}
.apk-rendered-view .view-text {
  font-size: 14px; line-height: 1.5;
}
.apk-rendered-view .view-button {
  background: var(--accent);
  color: #fff; border: none;
  border-radius: 8px; padding: 12px 20px;
  font-size: 14px; font-weight: 500;
  cursor: pointer;
}
.apk-rendered-view .view-edit {
  border: 1px solid #ddd;
  border-radius: 8px; padding: 10px 14px;
  font-size: 14px; outline: none;
  background: #fff;
}
.apk-rendered-view .view-image {
  background-size: cover;
  background-position: center;
  border-radius: 8px;
}
.apk-rendered-view .view-scroll {
  overflow-y: auto;
}

/* APK File Explorer */
.apk-file-tree { display: flex; flex-direction: column; gap: 4px; }
.apk-file-item {
  display: flex; align-items: center; gap: 8px;
  padding: 8px 10px;
  border-radius: 8px;
  font-size: 12px;
  font-family: monospace;
  cursor: pointer;
  transition: background 0.15s;
}
.apk-file-item:hover { background: rgba(255,255,255,0.05); }
.apk-file-item.folder { color: #8ab4f8; }
.apk-file-item.file { color: rgba(255,255,255,0.6); }

/* Toast */
.toast {
  position: absolute; bottom: 70px; left: 50%; transform: translateX(-50%) translateY(100px);
  background: rgba(40,40,50,0.95); backdrop-filter: blur(10px);
  color: #fff; padding: 12px 20px; border-radius: 24px;
  font-size: 13px; z-index: 5000; opacity: 0;
  transition: all 0.4s cubic-bezier(0.25,0.46,0.45,0.94);
  max-width: 80%; text-align: center;
  border: 1px solid rgba(255,255,255,0.1);
}
.toast.show { opacity: 1; transform: translateX(-50%) translateY(0); }

/* Scrollbar */
::-webkit-scrollbar { width: 4px; }
::-webkit-scrollbar-track { background: transparent; }
::-webkit-scrollbar-thumb { background: rgba(255,255,255,0.15); border-radius: 4px; }

/* ===== RESPONSIVE ===== */
@media (max-height: 850px) {
  .phone-container { transform: scale(0.88); }
}
@media (max-height: 720px) {
  .phone-container { transform: scale(0.78); }
}
@media (max-width: 420px) {
  .phone-container { transform: scale(0.75); }
}""")
            ]
        ]
        body [] [
            rawText ("<!--  ===== PHONE CONTAINER =====  -->")
            div [ _class "phone-container"; _id "phoneContainer" ] [
                rawText ("<!--  Side buttons  -->")
                div [ _class "btn-power"; _id "btnPower"; attr "title" "Power" ] []
                div [ _class "btn-vol-up"; _id "btnVolUp"; attr "title" "Volume Up" ] []
                div [ _class "btn-vol-down"; _id "btnVolDown"; attr "title" "Volume Down" ] []
                rawText ("<!--  SIDeload Button (NEW)  -->")
                div [ _class "btn-sideload pulse"; _id "btnSideload"; attr "title" "Sideload APK" ] [
                    str "APK"
                ]
                rawText ("<!--  Phone Screen  -->")
                div [ _class "phone-screen"; _id "phoneScreen" ] [
                    rawText ("<!--  Notch  -->")
                    div [ _class "notch" ] [
                        div [ _class "notch-cam" ] []
                        div [ _class "notch-speaker" ] []
                    ]
                    rawText ("<!--  Status Bar  -->")
                    div [ _class "status-bar" ] [
                        div [ _class "status-left" ] [
                            span [ _id "statusTime" ] [
                                str "12:00"
                            ]
                        ]
                        div [ _class "status-right" ] [
                            span [ _class "status-icon" ] [
                                str "📶"
                            ]
                            span [ _class "status-icon" ] [
                                str "🔋"
                            ]
                            div [ _class "battery-wrap" ] [
                                div [ _class "battery-icon" ] [
                                    div [ _class "battery-fill"; _id "batteryFill"; attr "style" "width:75%" ] []
                                ]
                                span [ attr "style" "font-size:10px"; _id "batteryText" ] [
                                    str "75%"
                                ]
                            ]
                        ]
                    ]
                    rawText ("<!--  Screen Content  -->")
                    div [ _class "screen-content"; _id "screenContent" ] [
                        rawText ("<!--  ===== LOCK SCREEN =====  -->")
                        div [ _class "lock-screen"; _id "lockScreen" ] [
                            div [ _class "lock-clock"; _id "lockClock" ] [
                                str "12:00"
                            ]
                            div [ _class "lock-date"; _id "lockDate" ] [
                                str "Monday, January 1"
                            ]
                            div [ _class "lock-notifs"; _id "lockNotifs" ] []
                            div [ _class "lock-hint" ] [
                                str "↑ Swipe up to unlock"
                            ]
                        ]
                        rawText ("<!--  ===== HOME SCREEN =====  -->")
                        div [ _class "home-screen"; _id "homeScreen" ] [
                            div [ _class "search-bar"; _id "searchBar" ] [
                                span [] [
                                    str "🔍"
                                ]
                                span [] [
                                    str "Search"
                                ]
                            ]
                            div [ _class "widget" ] [
                                div [ _class "widget-time"; _id "widgetTime" ] [
                                    str "12:00"
                                ]
                                div [ _class "widget-date"; _id "widgetDate" ] [
                                    str "Mon, Jan 1"
                                ]
                                div [ _class "widget-weather" ] [
                                    str "🌤 72deg;F Sunny"
                                ]
                            ]
                            div [ _class "app-grid"; _id "appGrid" ] [
                                rawText ("<!--  Built-in apps + sideloaded apps rendered here  -->")
                            ]
                            div [ _class "dock"; _id "dock" ] [
                                div [ _class "app-icon"; attr "data-app" "phone" ] [
                                    div [ _class "app-icon-img"; attr "style" "background:linear-gradient(135deg,#34c759,#30d158)" ] [
                                        str "📞"
                                    ]
                                    div [ _class "app-icon-label" ] [
                                        str "Phone"
                                    ]
                                ]
                                div [ _class "app-icon"; attr "data-app" "messages" ] [
                                    div [ _class "app-icon-img"; attr "style" "background:linear-gradient(135deg,#34c759,#30d158)" ] [
                                        str "💬"
                                    ]
                                    div [ _class "app-icon-label" ] [
                                        str "Messages"
                                    ]
                                ]
                                div [ _class "app-icon"; attr "data-app" "browser" ] [
                                    div [ _class "app-icon-img"; attr "style" "background:linear-gradient(135deg,#4285f4,#34a853,#fbbc05,#ea4335)" ] [
                                        str "🌐"
                                    ]
                                    div [ _class "app-icon-label" ] [
                                        str "Chrome"
                                    ]
                                ]
                                div [ _class "app-icon"; attr "data-app" "camera" ] [
                                    div [ _class "app-icon-img"; attr "style" "background:#333" ] [
                                        str "📸"
                                    ]
                                    div [ _class "app-icon-label" ] [
                                        str "Camera"
                                    ]
                                ]
                            ]
                        ]
                        rawText ("<!--  ===== APP DRAWER =====  -->")
                        div [ _class "app-drawer"; _id "appDrawer" ] [
                            div [ _class "drawer-search" ] [
                                span [] [
                                    str "🔍"
                                ]
                                span [] [
                                    str "Search apps..."
                                ]
                            ]
                            div [ _class "drawer-grid"; _id "drawerGrid" ] []
                            div [ _class "drawer-hint" ] [
                                str "↓ Swipe down to close"
                            ]
                        ]
                        rawText ("<!--  ===== NOTIFICATION PANEL =====  -->")
                        div [ _class "notif-panel"; _id "notifPanel" ] [
                            div [ _class "notif-panel-clock"; _id "notifClock" ] [
                                str "12:00"
                            ]
                            div [ _class "notif-panel-date"; _id "notifDate" ] [
                                str "Monday, January 1"
                            ]
                            div [ _class "notif-toggles" ] [
                                button [ _class "notif-toggle active"; attr "data-t" "wifi" ] [
                                    span [] [
                                        str "📶"
                                    ]
                                    span [ _class "notif-toggle-label" ] [
                                        str "Wi-Fi"
                                    ]
                                ]
                                button [ _class "notif-toggle"; attr "data-t" "bt" ] [
                                    span [] [
                                        str "🔋"
                                    ]
                                    span [ _class "notif-toggle-label" ] [
                                        str "BT"
                                    ]
                                ]
                                button [ _class "notif-toggle"; attr "data-t" "data" ] [
                                    span [] [
                                        str "📱"
                                    ]
                                    span [ _class "notif-toggle-label" ] [
                                        str "Data"
                                    ]
                                ]
                                button [ _class "notif-toggle"; attr "data-t" "flash" ] [
                                    span [] [
                                        str "🔦"
                                    ]
                                    span [ _class "notif-toggle-label" ] [
                                        str "Flash"
                                    ]
                                ]
                                button [ _class "notif-toggle"; attr "data-t" "plane" ] [
                                    span [] [
                                        str "✈"
                                    ]
                                    span [ _class "notif-toggle-label" ] [
                                        str "Airplane"
                                    ]
                                ]
                                button [ _class "notif-toggle"; attr "data-t" "rotate" ] [
                                    span [] [
                                        str "🔄"
                                    ]
                                    span [ _class "notif-toggle-label" ] [
                                        str "Rotate"
                                    ]
                                ]
                                button [ _class "notif-toggle active"; attr "data-t" "dnd" ] [
                                    span [] [
                                        str "🌙"
                                    ]
                                    span [ _class "notif-toggle-label" ] [
                                        str "DND"
                                    ]
                                ]
                                button [ _class "notif-toggle"; attr "data-t" "hotspot" ] [
                                    span [] [
                                        str "📡"
                                    ]
                                    span [ _class "notif-toggle-label" ] [
                                        str "Hotspot"
                                    ]
                                ]
                            ]
                            div [ _class "notif-list"; _id "notifList" ] []
                            button [ _class "notif-toggle"; _id "notifClear"; attr "style" "border-radius:12px;height:36px;flex-direction:row;gap:6px;background:rgba(255,255,255,0.1)" ] [
                                span [] [
                                    str "🗑"
                                ]
                                span [ _class "notif-toggle-label" ] [
                                    str "Clear All"
                                ]
                            ]
                        ]
                        rawText ("<!--  ===== RECENT APPS =====  -->")
                        div [ _class "recent-apps"; _id "recentApps" ] [
                            div [ _class "recent-title" ] [
                                str "Recent Apps"
                            ]
                            div [ _id "recentList" ] []
                        ]
                        rawText ("<!--  ===== APP WINDOWS =====  -->")
                        div [ _class "app-windows"; _id "appWindows" ] [
                            rawText ("<!--  Calculator  -->")
                            div [ _class "app-window"; _id "app-calculator" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "calcBack" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title" ] [
                                        str "Calculator"
                                    ]
                                ]
                                div [ _class "app-body" ] [
                                    div [ _class "calc-display" ] [
                                        div [ _class "calc-prev"; _id "calcPrev" ] []
                                        div [ _id "calcDisplay" ] [
                                            str "0"
                                        ]
                                    ]
                                    div [ _class "calc-grid" ] [
                                        button [ _class "calc-btn gray"; attr "data-c" "C" ] [
                                            str "C"
                                        ]
                                        button [ _class "calc-btn gray"; attr "data-c" "±" ] [
                                            str "±"
                                        ]
                                        button [ _class "calc-btn gray"; attr "data-c" "%" ] [
                                            str "%"
                                        ]
                                        button [ _class "calc-btn orange"; attr "data-c" "/" ] [
                                            str "÷"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "7" ] [
                                            str "7"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "8" ] [
                                            str "8"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "9" ] [
                                            str "9"
                                        ]
                                        button [ _class "calc-btn orange"; attr "data-c" "*" ] [
                                            str "×"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "4" ] [
                                            str "4"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "5" ] [
                                            str "5"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "6" ] [
                                            str "6"
                                        ]
                                        button [ _class "calc-btn orange"; attr "data-c" "-" ] [
                                            str "-"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "1" ] [
                                            str "1"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "2" ] [
                                            str "2"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "3" ] [
                                            str "3"
                                        ]
                                        button [ _class "calc-btn orange"; attr "data-c" "+" ] [
                                            str "+"
                                        ]
                                        button [ _class "calc-btn dark"; attr "style" "grid-column:span 2;border-radius:28px;text-align:left;padding-left:24px"; attr "data-c" "0" ] [
                                            str "0"
                                        ]
                                        button [ _class "calc-btn dark"; attr "data-c" "." ] [
                                            str "."
                                        ]
                                        button [ _class "calc-btn orange"; attr "data-c" "=" ] [
                                            str "="
                                        ]
                                    ]
                                ]
                            ]
                            rawText ("<!--  Browser  -->")
                            div [ _class "app-window"; _id "app-browser" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "brBack" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title" ] [
                                        str "Chrome"
                                    ]
                                ]
                                div [ _class "app-body"; attr "style" "padding:8px;display:flex;flex-direction:column" ] [
                                    div [ _class "br-toolbar" ] [
                                        button [ _class "br-btn"; _id "brBack2" ] [
                                            str "←"
                                        ]
                                        button [ _class "br-btn"; _id "brFwd" ] [
                                            str "→"
                                        ]
                                        button [ _class "br-btn"; _id "brRefresh" ] [
                                            str "↻"
                                        ]
                                        input [ _class "br-input"; _id "brUrl"; attr "placeholder" "Enter URL..."; attr "value" "https://example.com" ]
                                        button [ _class "br-btn"; _id "brGo" ] [
                                            str "Go"
                                        ]
                                    ]
                                    iframe [ _class "br-frame"; _id "brFrame"; attr "sandbox" "allow-scripts allow-same-origin allow-forms allow-popups allow-presentation"; _src "https://example.com" ] []
                                ]
                            ]
                            rawText ("<!--  Phone  -->")
                            div [ _class "app-window"; _id "app-phone" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "phoneBack" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title" ] [
                                        str "Phone"
                                    ]
                                ]
                                div [ _class "app-body"; attr "style" "padding:0" ] [
                                    div [ attr "style" "text-align:center;padding:20px;font-size:28px;font-weight:300;color:#fff;min-height:60px"; _id "phoneDisplay" ] []
                                    div [ _class "dial-pad" ] [
                                        button [ _class "dial-btn"; attr "data-d" "1" ] [
                                            str "1"
                                            small [] []
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "2" ] [
                                            str "2"
                                            small [] [
                                                str "ABC"
                                            ]
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "3" ] [
                                            str "3"
                                            small [] [
                                                str "DEF"
                                            ]
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "4" ] [
                                            str "4"
                                            small [] [
                                                str "GHI"
                                            ]
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "5" ] [
                                            str "5"
                                            small [] [
                                                str "JKL"
                                            ]
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "6" ] [
                                            str "6"
                                            small [] [
                                                str "MNO"
                                            ]
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "7" ] [
                                            str "7"
                                            small [] [
                                                str "PQRS"
                                            ]
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "8" ] [
                                            str "8"
                                            small [] [
                                                str "TUV"
                                            ]
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "9" ] [
                                            str "9"
                                            small [] [
                                                str "WXYZ"
                                            ]
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "*" ] [
                                            str "*"
                                            small [] []
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "0" ] [
                                            str "0"
                                            small [] [
                                                str "+"
                                            ]
                                        ]
                                        button [ _class "dial-btn"; attr "data-d" "#" ] [
                                            str "#"
                                            small [] []
                                        ]
                                    ]
                                    button [ _class "call-btn"; _id "callBtn" ] [
                                        str "📞"
                                    ]
                                    div [ attr "style" "padding:0 16px 16px" ] [
                                        div [ attr "style" "font-size:13px;color:var(--text-secondary);margin-bottom:8px" ] [
                                            str "Recent Calls"
                                        ]
                                        div [ _id "callLog" ] []
                                    ]
                                ]
                            ]
                            rawText ("<!--  Messages  -->")
                            div [ _class "app-window"; _id "app-messages" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "msgBack"; attr "style" "display:none" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title"; _id "msgTitle"; attr "style" "margin-right:0" ] [
                                        str "Messages"
                                    ]
                                ]
                                div [ _class "app-body"; attr "style" "padding:0 16px" ] [
                                    div [ _id "msgListView" ] [
                                        div [ attr "style" "padding:8px 0;font-size:13px;color:var(--text-secondary)" ] [
                                            str "Conversations"
                                        ]
                                        div [ _id "msgList" ] []
                                    ]
                                    div [ _id "chatView"; attr "style" "display:none;flex-direction:column;height:100%" ] [
                                        div [ _class "chat-messages"; _id "chatMessages" ] []
                                        div [ _class "chat-input-row" ] [
                                            input [ _class "chat-input"; _id "chatInput"; attr "placeholder" "Message..." ]
                                            button [ _class "chat-send"; _id "chatSend" ] [
                                                str "➤"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            rawText ("<!--  Camera  -->")
                            div [ _class "app-window"; _id "app-camera" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "camBack" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title" ] [
                                        str "Camera"
                                    ]
                                ]
                                div [ _class "app-body"; attr "style" "padding:8px;display:flex;flex-direction:column" ] [
                                    div [ _class "cam-viewfinder" ] [
                                        div [ _class "cam-focus" ] []
                                    ]
                                    div [ _class "cam-mode" ] [
                                        button [ _class "cam-mode-btn" ] [
                                            str "VIDEO"
                                        ]
                                        button [ _class "cam-mode-btn active" ] [
                                            str "PHOTO"
                                        ]
                                        button [ _class "cam-mode-btn" ] [
                                            str "PORTRAIT"
                                        ]
                                    ]
                                    div [ _class "cam-controls" ] [
                                        button [ _class "cam-shutter"; _id "camShutter" ] []
                                    ]
                                ]
                            ]
                            rawText ("<!--  Clock  -->")
                            div [ _class "app-window"; _id "app-clock" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "clockBack" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title" ] [
                                        str "Clock"
                                    ]
                                ]
                                div [ _class "app-body" ] [
                                    div [ _class "clock-tabs" ] [
                                        button [ _class "clock-tab active"; attr "data-tab" "alarm" ] [
                                            str "⏰ Alarm"
                                        ]
                                        button [ _class "clock-tab"; attr "data-tab" "world" ] [
                                            str "🌎 World"
                                        ]
                                        button [ _class "clock-tab"; attr "data-tab" "stopwatch" ] [
                                            str "⏱ Stopwatch"
                                        ]
                                        button [ _class "clock-tab"; attr "data-tab" "timer" ] [
                                            str "⏲ Timer"
                                        ]
                                    ]
                                    div [ _class "clock-section active"; _id "tab-alarm" ] [
                                        div [ _id "alarmList" ] []
                                        button [ _class "sw-btn primary"; attr "style" "width:auto;padding:0 20px;border-radius:20px;margin-top:12px"; _id "addAlarm" ] [
                                            str "+ Add Alarm"
                                        ]
                                    ]
                                    div [ _class "clock-section"; _id "tab-world" ] [
                                        div [ attr "style" "display:flex;flex-direction:column;gap:12px;margin-top:8px" ] [
                                            div [ attr "style" "display:flex;justify-content:space-between;align-items:center;padding:12px;background:rgba(255,255,255,0.05);border-radius:12px" ] [
                                                span [] [
                                                    str "New York"
                                                ]
                                                span [ attr "style" "font-size:24px;font-weight:200" ] [
                                                    str "--:--"
                                                ]
                                            ]
                                            div [ attr "style" "display:flex;justify-content:space-between;align-items:center;padding:12px;background:rgba(255,255,255,0.05);border-radius:12px" ] [
                                                span [] [
                                                    str "London"
                                                ]
                                                span [ attr "style" "font-size:24px;font-weight:200" ] [
                                                    str "--:--"
                                                ]
                                            ]
                                            div [ attr "style" "display:flex;justify-content:space-between;align-items:center;padding:12px;background:rgba(255,255,255,0.05);border-radius:12px" ] [
                                                span [] [
                                                    str "Tokyo"
                                                ]
                                                span [ attr "style" "font-size:24px;font-weight:200" ] [
                                                    str "--:--"
                                                ]
                                            ]
                                        ]
                                    ]
                                    div [ _class "clock-section"; _id "tab-stopwatch" ] [
                                        div [ _class "stopwatch-display"; _id "swDisplay" ] [
                                            str "00:00.00"
                                        ]
                                        div [ _class "sw-controls" ] [
                                            button [ _class "sw-btn"; _id "swLap" ] [
                                                str "Lap"
                                            ]
                                            button [ _class "sw-btn primary"; _id "swStart" ] [
                                                str "Start"
                                            ]
                                        ]
                                        div [ _id "swLaps"; attr "style" "margin-top:16px;max-height:200px;overflow-y:auto" ] []
                                    ]
                                    div [ _class "clock-section"; _id "tab-timer" ] [
                                        div [ _class "timer-inputs"; _id "timerInputs" ] [
                                            input [ _id "tmMin"; _type "number"; attr "placeholder" "00"; attr "min" "0"; attr "max" "99" ]
                                            span [ attr "style" "font-size:24px" ] [
                                                str ":"
                                            ]
                                            input [ _id "tmSec"; _type "number"; attr "placeholder" "00"; attr "min" "0"; attr "max" "59" ]
                                        ]
                                        div [ _class "stopwatch-display"; _id "timerDisplay"; attr "style" "display:none" ] [
                                            str "00:00"
                                        ]
                                        div [ _class "sw-controls" ] [
                                            button [ _class "sw-btn"; _id "tmCancel" ] [
                                                str "Cancel"
                                            ]
                                            button [ _class "sw-btn primary"; _id "tmStart" ] [
                                                str "Start"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            rawText ("<!--  Settings  -->")
                            div [ _class "app-window"; _id "app-settings" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "settingsBack" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title" ] [
                                        str "Settings"
                                    ]
                                ]
                                div [ _class "app-body" ] [
                                    div [ attr "style" "display:flex;align-items:center;gap:12px;margin-bottom:16px;padding-bottom:16px;border-bottom:1px solid rgba(255,255,255,0.1)" ] [
                                        div [ attr "style" "width:56px;height:56px;border-radius:50%;background:linear-gradient(135deg,#667eea,#764ba2);display:flex;align-items:center;justify-content:center;font-size:24px" ] [
                                            str "👤"
                                        ]
                                        div [] [
                                            div [ attr "style" "font-size:16px;font-weight:600" ] [
                                                str "Developer"
                                            ]
                                            div [ attr "style" "font-size:12px;color:var(--text-secondary)" ] [
                                                str "Android 14 • Pixel 8"
                                            ]
                                        ]
                                    ]
                                    div [ _class "settings-item" ] [
                                        div [ _class "settings-icon"; attr "style" "background:#34c759" ] [
                                            str "📶"
                                        ]
                                        div [ _class "settings-info" ] [
                                            div [ _class "settings-title" ] [
                                                str "Wi-Fi"
                                            ]
                                            div [ _class "settings-sub"; _id "stWifiSub" ] [
                                                str "Connected"
                                            ]
                                        ]
                                        div [ _class "settings-toggle on"; attr "data-s" "wifi" ] []
                                    ]
                                    div [ _class "settings-item" ] [
                                        div [ _class "settings-icon"; attr "style" "background:#007aff" ] [
                                            str "🔋"
                                        ]
                                        div [ _class "settings-info" ] [
                                            div [ _class "settings-title" ] [
                                                str "Bluetooth"
                                            ]
                                            div [ _class "settings-sub"; _id "stBtSub" ] [
                                                str "Off"
                                            ]
                                        ]
                                        div [ _class "settings-toggle"; attr "data-s" "bluetooth" ] []
                                    ]
                                    div [ _class "settings-item" ] [
                                        div [ _class "settings-icon"; attr "style" "background:#34c759" ] [
                                            str "📱"
                                        ]
                                        div [ _class "settings-info" ] [
                                            div [ _class "settings-title" ] [
                                                str "Mobile Data"
                                            ]
                                            div [ _class "settings-sub" ] [
                                                str "On"
                                            ]
                                        ]
                                        div [ _class "settings-toggle on"; attr "data-s" "mobileData" ] []
                                    ]
                                    div [ _class "settings-item" ] [
                                        div [ _class "settings-icon"; attr "style" "background:#ff9500" ] [
                                            str "✈"
                                        ]
                                        div [ _class "settings-info" ] [
                                            div [ _class "settings-title" ] [
                                                str "Airplane Mode"
                                            ]
                                        ]
                                        div [ _class "settings-toggle"; attr "data-s" "airplane" ] []
                                    ]
                                    div [ _class "settings-item" ] [
                                        div [ _class "settings-icon"; attr "style" "background:#5856d6" ] [
                                            str "🌙"
                                        ]
                                        div [ _class "settings-info" ] [
                                            div [ _class "settings-title" ] [
                                                str "Dark Mode"
                                            ]
                                        ]
                                        div [ _class "settings-toggle on"; attr "data-s" "darkMode" ] []
                                    ]
                                    div [ _class "settings-item" ] [
                                        div [ _class "settings-icon"; attr "style" "background:#ff3b30" ] [
                                            str "🔄"
                                        ]
                                        div [ _class "settings-info" ] [
                                            div [ _class "settings-title" ] [
                                                str "Auto-rotate"
                                            ]
                                        ]
                                        div [ _class "settings-toggle"; attr "data-s" "autoRotate" ] []
                                    ]
                                    div [ _class "settings-item" ] [
                                        div [ _class "settings-icon"; attr "style" "background:#ff9500" ] [
                                            str "🔊"
                                        ]
                                        div [ _class "settings-info" ] [
                                            div [ _class "settings-title" ] [
                                                str "Sound"
                                            ]
                                        ]
                                        div [ _class "settings-toggle on"; attr "data-s" "sound" ] []
                                    ]
                                    div [ _class "settings-item"; _id "aboutItem" ] [
                                        div [ _class "settings-icon"; attr "style" "background:#8e8e93" ] [
                                            str "ℹ"
                                        ]
                                        div [ _class "settings-info" ] [
                                            div [ _class "settings-title" ] [
                                                str "About Phone"
                                            ]
                                            div [ _class "settings-sub" ] [
                                                str "Android 14, Build UP1A"
                                            ]
                                        ]
                                        span [ attr "style" "color:var(--text-secondary)" ] [
                                            str "›"
                                        ]
                                    ]
                                ]
                            ]
                            rawText ("<!--  Gallery  -->")
                            div [ _class "app-window"; _id "app-gallery" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "galleryBack" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title" ] [
                                        str "Gallery"
                                    ]
                                ]
                                div [ _class "app-body"; attr "style" "padding:8px" ] [
                                    div [ _class "gallery-grid"; _id "galleryGrid" ] []
                                ]
                            ]
                            rawText ("<!--  Files  -->")
                            div [ _class "app-window"; _id "app-files" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "filesBack" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title" ] [
                                        str "Files"
                                    ]
                                ]
                                div [ _class "app-body" ] [
                                    div [ _class "file-grid" ] [
                                        div [ _class "file-folder" ] [
                                            div [ attr "style" "font-size:32px;margin-bottom:8px" ] [
                                                str "📁"
                                            ]
                                            div [ attr "style" "font-size:13px" ] [
                                                str "Documents"
                                            ]
                                            div [ attr "style" "font-size:11px;color:var(--text-secondary)" ] [
                                                str "12 items"
                                            ]
                                        ]
                                        div [ _class "file-folder" ] [
                                            div [ attr "style" "font-size:32px;margin-bottom:8px" ] [
                                                str "📂"
                                            ]
                                            div [ attr "style" "font-size:13px" ] [
                                                str "Downloads"
                                            ]
                                            div [ attr "style" "font-size:11px;color:var(--text-secondary)" ] [
                                                str "28 items"
                                            ]
                                        ]
                                        div [ _class "file-folder" ] [
                                            div [ attr "style" "font-size:32px;margin-bottom:8px" ] [
                                                str "🎴"
                                            ]
                                            div [ attr "style" "font-size:13px" ] [
                                                str "Photos"
                                            ]
                                            div [ attr "style" "font-size:11px;color:var(--text-secondary)" ] [
                                                str "156 items"
                                            ]
                                        ]
                                        div [ _class "file-folder" ] [
                                            div [ attr "style" "font-size:32px;margin-bottom:8px" ] [
                                                str "🎵"
                                            ]
                                            div [ attr "style" "font-size:13px" ] [
                                                str "Music"
                                            ]
                                            div [ attr "style" "font-size:11px;color:var(--text-secondary)" ] [
                                                str "48 items"
                                            ]
                                        ]
                                        div [ _class "file-folder" ] [
                                            div [ attr "style" "font-size:32px;margin-bottom:8px" ] [
                                                str "🎥"
                                            ]
                                            div [ attr "style" "font-size:13px" ] [
                                                str "Videos"
                                            ]
                                            div [ attr "style" "font-size:11px;color:var(--text-secondary)" ] [
                                                str "23 items"
                                            ]
                                        ]
                                        div [ _class "file-folder" ] [
                                            div [ attr "style" "font-size:32px;margin-bottom:8px" ] [
                                                str "💾"
                                            ]
                                            div [ attr "style" "font-size:13px" ] [
                                                str "Internal"
                                            ]
                                            div [ attr "style" "font-size:11px;color:var(--text-secondary)" ] [
                                                str "45 GB free"
                                            ]
                                        ]
                                    ]
                                ]
                            ]
                            rawText ("<!--  Contacts  -->")
                            div [ _class "app-window"; _id "app-contacts" ] [
                                div [ _class "app-header" ] [
                                    button [ _class "app-header-btn"; _id "contactsBack"; attr "style" "display:none" ] [
                                        str "←"
                                    ]
                                    div [ _class "app-header-title"; _id "contactsTitle" ] [
                                        str "Contacts"
                                    ]
                                    button [ _class "add-contact-btn"; _id "contactsAdd" ] [
                                        str "+"
                                    ]
                                ]
                                div [ _class "app-body"; attr "style" "padding:0 16px" ] [
                                    div [ _id "contactsListView" ] [
                                        div [ _id "contactsList" ] []
                                    ]
                                    div [ _id "contactsAddView"; attr "style" "display:none" ] [
                                        div [ attr "style" "text-align:center;margin:20px 0" ] [
                                            div [ attr "style" "width:80px;height:80px;border-radius:50%;background:linear-gradient(135deg,#667eea,#764ba2);display:inline-flex;align-items:center;justify-content:center;font-size:36px" ] [
                                                str "👤"
                                            ]
                                        ]
                                        input [ _class "contact-input"; _id "contactName"; attr "placeholder" "Name" ]
                                        input [ _class "contact-input"; _id "contactNumber"; attr "placeholder" "Phone Number"; _type "tel" ]
                                        input [ _class "contact-input"; _id "contactEmail"; attr "placeholder" "Email"; _type "email" ]
                                        button [ _class "save-contact-btn"; _id "saveContact" ] [
                                            str "Save Contact"
                                        ]
                                    ]
                                ]
                            ]
                        ]
                        rawText ("<!--  /app-windows  -->")
                        rawText ("<!--  ===== APK SIDELOAD OVERLAY (NEW) =====  -->")
                        div [ _class "sideload-overlay"; _id "sideloadOverlay" ] [
                            div [ _class "sideload-header" ] [
                                button [ _class "sideload-close"; _id "sideloadClose" ] [
                                    str "✕"
                                ]
                                div [ _class "sideload-title" ] [
                                    str "APK Sideloader"
                                ]
                                div [ attr "style" "width:28px" ] []
                            ]
                            div [ _class "sideload-body" ] [
                                rawText ("<!--  Drop Zone  -->")
                                div [ _class "sideload-dropzone"; _id "sideloadDropzone" ] [
                                    span [ _class "icon" ] [
                                        str "📦"
                                    ]
                                    div [ _class "title" ] [
                                        str "Drop APK file here"
                                    ]
                                    div [ _class "subtitle" ] [
                                        str "or click to browse"
                                        br []
                                        str "Supports Android .apk files"
                                    ]
                                    input [ _type "file"; _id "sideloadInput"; attr "accept" ".apk"; attr "style" "display:none" ]
                                ]
                                rawText ("<!--  Progress  -->")
                                div [ _class "sideload-progress"; _id "sideloadProgress" ] [
                                    div [ _class "sideload-progress-bar" ] [
                                        div [ _class "sideload-progress-fill"; _id "sideloadProgressFill" ] []
                                    ]
                                    div [ _class "sideload-progress-text"; _id "sideloadProgressText" ] [
                                        str "Parsing APK..."
                                    ]
                                ]
                                rawText ("<!--  APK Info Panel  -->")
                                div [ _class "apk-info"; _id "apkInfo" ] [
                                    div [ _class "apk-info-header" ] [
                                        div [ _class "apk-info-icon"; _id "apkInfoIcon" ] [
                                            str "📦"
                                        ]
                                        div [ _class "apk-info-meta" ] [
                                            div [ _class "apk-info-name"; _id "apkInfoName" ] [
                                                str "App Name"
                                            ]
                                            div [ _class "apk-info-pkg"; _id "apkInfoPkg" ] [
                                                str "com.example.app"
                                            ]
                                            div [ _class "apk-info-version"; _id "apkInfoVersion" ] [
                                                str "v1.0.0 (SDK 33)"
                                            ]
                                        ]
                                    ]
                                    div [ _class "apk-info-section" ] [
                                        div [ _class "apk-info-section-title" ] [
                                            str "Permissions"
                                        ]
                                        div [ _class "apk-perm-list"; _id "apkPermList" ] []
                                    ]
                                    div [ _class "apk-info-section" ] [
                                        div [ _class "apk-info-section-title" ] [
                                            str "Activities"
                                        ]
                                        div [ _class "apk-activity-list"; _id "apkActivityList" ] []
                                    ]
                                    div [ _class "apk-info-section" ] [
                                        div [ _class "apk-info-section-title" ] [
                                            str "APK Contents"
                                        ]
                                        div [ _class "apk-file-tree"; _id "apkFileTree" ] []
                                    ]
                                    div [ _class "apk-action-btns" ] [
                                        button [ _class "apk-btn preview"; _id "apkPreviewBtn" ] [
                                            str "📐 Preview UI"
                                        ]
                                        button [ _class "apk-btn install"; _id "apkInstallBtn" ] [
                                            str "📥 Install"
                                        ]
                                    ]
                                ]
                                rawText ("<!--  APK Preview Panel (UI Rendering)  -->")
                                div [ _class "apk-info"; _id "apkPreviewPanel"; attr "style" "display:none" ] [
                                    div [ _class "apk-info-section" ] [
                                        div [ _class "apk-info-section-title" ] [
                                            str "Rendered Layout"
                                        ]
                                        div [ attr "style" "background:#f5f5f5;border-radius:16px;padding:16px;border:1px solid #e0e0e0" ] [
                                            div [ _id "apkRenderedUI"; attr "style" "min-height:200px" ] []
                                        ]
                                    ]
                                    div [ _class "apk-info-section" ] [
                                        div [ _class "apk-info-section-title" ] [
                                            str "Resources"
                                        ]
                                        div [ _class "apk-resource-grid"; _id "apkResourceGrid" ] []
                                    ]
                                ]
                            ]
                        ]
                        rawText ("<!--  ===== APK APP PREVIEW WINDOW (LAUNCHED SIDELOADED APP) =====  -->")
                        div [ _class "apk-preview-window"; _id "apkPreviewWindow" ] [
                            div [ _class "apk-preview-header" ] [
                                button [ _class "apk-preview-back"; _id "apkPreviewBack" ] [
                                    str "←"
                                ]
                                div [ _class "apk-preview-title"; _id "apkPreviewTitle" ] [
                                    str "App"
                                ]
                            ]
                            div [ _class "apk-preview-body"; _id "apkPreviewBody" ] [
                                rawText ("<!--  Rendered APK UI goes here  -->")
                            ]
                        ]
                        rawText ("<!--  ===== NAVIGATION BAR =====  -->")
                        div [ _class "nav-bar" ] [
                            button [ _class "nav-btn"; _id "navBack" ] [
                                str "◀"
                            ]
                            div [ _class "nav-pill"; _id "navPill" ] []
                            button [ _class "nav-btn"; _id "navHome" ] [
                                str "●"
                            ]
                            button [ _class "nav-btn"; _id "navRecent" ] [
                                str "■"
                            ]
                        ]
                        rawText ("<!--  Volume Overlay  -->")
                        div [ _class "vol-overlay"; _id "volOverlay" ] [
                            div [ _class "vol-fill"; _id "volFill"; attr "style" "height:50%" ] []
                        ]
                        rawText ("<!--  Toast  -->")
                        div [ _class "toast"; _id "toast" ] []
                    ]
                    rawText ("<!--  /screen-content  -->")
                ]
                rawText ("<!--  /phone-screen  -->")
            ]
            rawText ("<!--  /phone-container  -->")
            script [] [
                    rawText ("""// ===================== STATE =====================
const state = {
  locked: true, screenOn: true, currentApp: null, appStack: [],
  volume: 50, notifications: [],
  settings: { wifi:true, bluetooth:false, mobileData:true, airplane:false, darkMode:true, autoRotate:false, sound:true },
  stopwatchRunning: false, stopwatchElapsed: 0, stopwatchInterval: null,
  timerRunning: false, timerRemaining: 0, timerInterval: null,
  alarms: [{time:"07:00",label:"Morning Alarm",on:true},{time:"08:30",label:"Work",on:false}],
  callLog: [{name:"Mom",number:"+1-555-0101",dir:"&#8595;",time:"2h ago"},{name:"John Smith",number:"+1-555-0102",dir:"&#8593;",time:"5h ago"},{name:"Unknown",number:"+1-555-0199",dir:"&#8595;",time:"Yesterday"}],
  conversations: [{id:1,name:"Alice",messages:[{from:"them",text:"Hey! Want to grab lunch?"},{from:"me",text:"Sure, how about 12:30?"},{from:"them",text:"Perfect, see you then!"}]},{id:2,name:"Bob",messages:[{from:"them",text:"Did you finish the report?"},{from:"me",text:"Almost done, sending it soon."}]},{id:3,name:"Team Group",messages:[{from:"them",text:"Meeting at 3pm"},{from:"them",text:"Don't forget to prepare the slides"}]}],
  contacts: [{id:1,name:"Alice Johnson",number:"+1-555-0101",color:"#ff6b6b"},{id:2,name:"Bob Smith",number:"+1-555-0102",color:"#4ecdc4"},{id:3,name:"Carol White",number:"+1-555-0103",color:"#45b7d1"},{id:4,name:"David Brown",number:"+1-555-0104",color:"#f7dc6f"},{id:5,name:"Emma Davis",number:"+1-555-0105",color:"#bb8fce"},{id:6,name:"Frank Miller",number:"+1-555-0106",color:"#85c1e9"},{id:7,name:"Grace Wilson",number:"+1-555-0107",color:"#f8c471"},{id:8,name:"Henry Taylor",number:"+1-555-0108",color:"#82e0aa"}],
  gallery: Array.from({length:20},(_,i)=>({emoji:["&#127751;","&#127749;","&#127754;","&#127748;","&#127752;","&#127756;","&#127757;","&#127758;","&#127759;","&#127760;","&#127762;","&#127763;","&#127764;","&#127765;","&#127766;","&#127767;","&#127768;","&#127769;","&#127770;","&#127771;"][i],color:`hsl(${i*18},60%,45%)`})),
  // APK sideload state
  sideloadedApps: [],
  currentAPK: null,
  _volTimer: null
};

const BUILTIN_APPS = [
  {id:'calculator',name:'Calculator',emoji:'&#128290;',bg:'#333',color:'#fff'},
  {id:'browser',name:'Chrome',emoji:'&#127760;',bg:'#4285f4',color:'#fff'},
  {id:'phone',name:'Phone',emoji:'&#128222;',bg:'#34c759',color:'#fff'},
  {id:'messages',name:'Messages',emoji:'&#128172;',bg:'#34c759',color:'#fff'},
  {id:'camera',name:'Camera',emoji:'&#128248;',bg:'#333',color:'#fff'},
  {id:'clock',name:'Clock',emoji:'&#9200;',bg:'#1c1c1e',color:'#ff9500'},
  {id:'settings',name:'Settings',emoji:'&#9881;',bg:'#8e8e93',color:'#fff'},
  {id:'gallery',name:'Gallery',emoji:'&#127924;',bg:'#ff2d55',color:'#fff'},
  {id:'files',name:'Files',emoji:'&#128193;',bg:'#5856d6',color:'#fff'},
  {id:'contacts',name:'Contacts',emoji:'&#128100;',bg:'#007aff',color:'#fff'},
];

// ===================== APK PARSER ENGINE =====================
// Pure JavaScript implementation - no external dependencies

/**
 * ZIP Reader - Pure JS implementation for reading APK (ZIP) files
 * Supports stored and DEFLATED compression methods
 */
class ZIPReader {
  constructor(arrayBuffer) {
    this.data = new Uint8Array(arrayBuffer);
    this.view = new DataView(arrayBuffer);
    this.entries = new Map();
  }

  readUInt32LE(offset) { return this.view.getUint32(offset, true); }
  readUInt16LE(offset) { return this.view.getUint16(offset, true); }
  readString(offset, length) {
    let s = '';
    for (let i = 0; i < length && offset + i < this.data.length; i++) {
      const c = this.data[offset + i];
      if (c === 0) break;
      s += String.fromCharCode(c);
    }
    return s;
  }

  async parse() {
    const eocdr = this.findEOCDR();
    if (!eocdr) throw new Error('Invalid ZIP: EOCDR not found');
    
    let offset = eocdr.cdOffset;
    for (let i = 0; i < eocdr.entryCount; i++) {
      const sig = this.readUInt32LE(offset);
      if (sig !== 0x02014b50) break;
      
      const compMethod = this.readUInt16LE(offset + 10);
      const compSize = this.readUInt32LE(offset + 20);
      const uncompSize = this.readUInt32LE(offset + 24);
      const nameLen = this.readUInt16LE(offset + 28);
      const extraLen = this.readUInt16LE(offset + 30);
      const commentLen = this.readUInt16LE(offset + 32);
      const localHeaderOffset = this.readUInt32LE(offset + 42);
      const name = this.readString(offset + 46, nameLen);
      
      this.entries.set(name, {
        name, compMethod, compSize, uncompSize,
        localHeaderOffset, nameLen, extraLen
      });
      
      offset += 46 + nameLen + extraLen + commentLen;
    }
    return this.entries;
  }

  findEOCDR() {
    const len = this.data.length;
    // Search backwards for EOCDR signature (0x06054b50)
    // Max comment size is 65535, so search at most that far
    const searchStart = Math.max(0, len - 22 - 65535);
    for (let i = len - 22; i >= searchStart; i--) {
      if (this.readUInt32LE(i) === 0x06054b50) {
        return {
          entryCount: this.readUInt16LE(i + 8),
          cdSize: this.readUInt32LE(i + 12),
          cdOffset: this.readUInt32LE(i + 16)
        };
      }
    }
    return null;
  }

  async extract(entryName) {
    const entry = this.entries.get(entryName);
    if (!entry) return null;

    // Read local file header
    let offset = entry.localHeaderOffset;
    const localNameLen = this.readUInt16LE(offset + 26);
    const localExtraLen = this.readUInt16LE(offset + 28);
    const dataOffset = offset + 30 + localNameLen + localExtraLen;

    if (entry.compMethod === 0) {
      // STORED - no compression
      return this.data.slice(dataOffset, dataOffset + entry.uncompSize);
    } else if (entry.compMethod === 8) {
      // DEFLATED - use DecompressionStream
      const compressed = this.data.slice(dataOffset, dataOffset + entry.compSize);
      // Add zlib wrapper for DecompressionStream
      const wrapped = this.addZlibWrapper(compressed);
      try {
        const ds = new DecompressionStream('deflate');
        const writer = ds.writable.getWriter();
        writer.write(wrapped);
        writer.close();
        const reader = ds.readable.getReader();
        const chunks = [];
        while (true) {
          const { done, value } = await reader.read();
          if (done) break;
          chunks.push(value);
        }
        let total = 0;
        chunks.forEach(c => total += c.length);
        const result = new Uint8Array(total);
        let pos = 0;
        chunks.forEach(c => { result.set(c, pos); pos += c.length; });
        return result;
      } catch (e) {
        // Fallback: try raw deflate (no wrapper)
        try {
          const ds = new DecompressionStream('deflate-raw');
          const writer = ds.writable.getWriter();
          writer.write(compressed);
          writer.close();
          const reader = ds.readable.getReader();
          const chunks = [];
          while (true) {
            const { done, value } = await reader.read();
            if (done) break;
            chunks.push(value);
          }
          let total = 0;
          chunks.forEach(c => total += c.length);
          const result = new Uint8Array(total);
          let pos = 0;
          chunks.forEach(c => { result.set(c, pos); pos += c.length; });
          return result;
        } catch (e2) {
          console.error('Decompression failed:', e2);
          return null;
        }
      }
    }
    return null;
  }

  // Add minimal zlib wrapper for DecompressionStream compatibility
  addZlibWrapper(data) {
    // Check if already has zlib header
    if (data[0] === 0x78) return data;
    // Add zlib header (CMF=0x78, FLG=0x9C)
    const wrapper = new Uint8Array(data.length + 2);
    wrapper[0] = 0x78;
    wrapper[1] = 0x9C;
    wrapper.set(data, 2);
    return wrapper;
  }

  getEntryNames() {
    return Array.from(this.entries.keys());
  }

  hasEntry(name) {
    return this.entries.has(name);
  }
}

/**
 * AXMLParser - Android Binary XML Parser
 * Parses AndroidManifest.xml and layout XML files from APK
 */
class AXMLParser {
  constructor(buffer) {
    this.data = new Uint8Array(buffer);
    this.view = new DataView(buffer);
    this.offset = 0;
    this.strings = [];
    this.resources = [];
    this.xml = '';
    this.attrs = {};
  }

  readUInt32() { const v = this.view.getUint32(this.offset, true); this.offset += 4; return v; }
  readUInt16() { const v = this.view.getUint16(this.offset, true); this.offset += 2; return v; }
  readInt32() { const v = this.view.getInt32(this.offset, true); this.offset += 4; return v; }

  parse() {
    this.offset = 0;
    const type = this.readUInt16();
    const headerSize = this.readUInt16();
    const size = this.readUInt32();

    if (type !== 0x0003) {
      throw new Error(`Not an AXML file (type=0x${type.toString(16)})`);
    }

    // Parse chunks
    this.offset = headerSize;
    let inXml = false;
    let depth = 0;
    const tagStack = [];

    while (this.offset < size && this.offset < this.data.length) {
      const chunkStart = this.offset;
      const chunkType = this.readUInt16();
      const chunkHeaderSize = this.readUInt16();
      const chunkSize = this.readUInt32();

      switch (chunkType) {
        case 0x0001: // RES_STRING_POOL_TYPE
          this.parseStringPool(chunkStart + chunkHeaderSize, chunkStart + chunkSize);
          this.offset = chunkStart + chunkSize;
          break;
        case 0x0180: // RES_XML_RESOURCE_MAP_TYPE
          this.parseResourceMap(chunkStart + chunkHeaderSize, chunkStart + chunkSize);
          this.offset = chunkStart + chunkSize;
          break;
        case 0x0100: // RES_XML_START_NAMESPACE_TYPE
          this.offset = chunkStart + chunkSize;
          break;
        case 0x0101: // RES_XML_END_NAMESPACE_TYPE
          this.offset = chunkStart + chunkSize;
          break;
        case 0x0102: { // RES_XML_START_ELEMENT_TYPE
          inXml = true;
          this.offset = chunkStart + 16; // Skip to name after chunk header
          const elemNs = this.readUInt32();
          const elemNameIdx = this.readUInt32();
          // Skip attribute fields
          this.offset += 8; // attrStart, attrSize
          const attrCount = this.readUInt16();
          this.readUInt16(); // idIndex
          this.readUInt16(); // classIndex
          this.readUInt16(); // styleIndex

          const tagName = this.getString(elemNameIdx);
          tagStack.push(tagName);
          
          let attrs = '';
          const attrObj = {};
          for (let a = 0; a < attrCount; a++) {
            const attrNs = this.readUInt32();
            const attrNameIdx = this.readUInt32();
            const attrRawValue = this.readUInt32();
            this.readUInt16(); // size
            this.readUInt8();  // reserved
            const attrDataType = this.readUInt8();
            const attrData = this.readUInt32();

            const attrName = this.getString(attrNameIdx);
            let attrValue = '';
            
            switch (attrDataType) {
              case 0x03: // TYPE_STRING
                attrValue = this.escapeXml(this.getString(attrData));
                break;
              case 0x01: // TYPE_REFERENCE
                attrValue = `@0x${attrData.toString(16)}`;
                break;
              case 0x10: // TYPE_INT_DEC
              case 0x11: // TYPE_INT_HEX
                attrValue = String(attrData);
                break;
              case 0x12: // TYPE_INT_BOOLEAN
                attrValue = attrData !== 0 ? 'true' : 'false';
                break;
              case 0x00: // TYPE_NULL
                attrValue = '';
                break;
              default:
                attrValue = String(attrData);
            }

            if (attrName && attrValue !== '') {
              attrs += ` ${attrName}="${attrValue}"`;
              attrObj[attrName] = attrValue;
            }
          }

          // Build XML string
          this.xml += '  '.repeat(depth) + `<${tagName}${attrs}>\n`;
          depth++;
          
          // Store attributes for the root element
          if (depth === 1) {
            this.attrs = attrObj;
          }
          
          this.offset = chunkStart + chunkSize;
          break;
        }
        case 0x0103: { // RES_XML_END_ELEMENT_TYPE
          this.offset = chunkStart + 16;
          const endNs = this.readUInt32();
          const endNameIdx = this.readUInt32();
          const tagName = this.getString(endNameIdx);
          depth = Math.max(0, depth - 1);
          if (tagStack.length > 0 && tagStack[tagStack.length - 1] === tagName) {
            tagStack.pop();
            this.xml += '  '.repeat(depth) + `</${tagName}>\n`;
          } else {
            this.xml += '  '.repeat(depth) + `</${tagName}>\n`;
          }
          this.offset = chunkStart + chunkSize;
          break;
        }
        case 0x0104: // RES_XML_CDATA_TYPE
          this.offset = chunkStart + chunkSize;
          break;
        default:
          this.offset = chunkStart + chunkSize;
      }
    }

    return {
      xml: this.xml,
      strings: this.strings,
      resources: this.resources,
      attrs: this.attrs
    };
  }

  parseStringPool(dataStart, dataEnd) {
    const saved = this.offset;
    this.offset = dataStart;
    
    const stringCount = this.readUInt32();
    const styleCount = this.readUInt32();
    const flags = this.readUInt32();
    const stringsStart = this.readUInt32();
    const stylesStart = this.readUInt32();
    
    const isUTF8 = (flags & 0x100) !== 0;
    
    const stringOffsets = [];
    for (let i = 0; i < stringCount; i++) {
      stringOffsets.push(this.readUInt32());
    }
    
    // Skip style offsets
    this.offset += styleCount * 4;
    
    const baseOffset = dataStart - 8 + stringsStart; // Adjust for chunk header
    
    for (let i = 0; i < stringCount; i++) {
      this.offset = baseOffset + stringOffsets[i];
      if (isUTF8) {
        this.strings.push(this.readUTF8String());
      } else {
        this.strings.push(this.readUTF16String());
      }
    }
    
    this.offset = dataEnd;
  }

  parseResourceMap(dataStart, dataEnd) {
    this.offset = dataStart;
    const count = (dataEnd - dataStart) / 4;
    for (let i = 0; i < count; i++) {
      this.resources.push(this.readUInt32());
    }
  }

  readUTF8String() {
    const u16len = this.readUInt16(); // UTF-16 length (ignored for UTF-8)
    const u8len = this.readUInt16();  // UTF-8 length
    if (u8len > 10000) return ''; // Safety
    let s = '';
    for (let i = 0; i < u8len; i++) {
      const b = this.data[this.offset++];
      if (b === 0) break;
      s += String.fromCharCode(b);
    }
    // Skip padding to 4-byte boundary
    while (this.offset % 4 !== 0) this.offset++;
    return s;
  }

  readUTF16String() {
    const len = this.readUInt16();
    if (len > 10000) { this.offset += len * 2 + 2; return ''; }
    let s = '';
    for (let i = 0; i < len; i++) {
      const c = this.readUInt16();
      if (c === 0) break;
      s += String.fromCharCode(c);
    }
    // Null terminator + padding
    this.readUInt16();
    while (this.offset % 4 !== 0) this.offset++;
    return s;
  }

  getString(index) {
    if (index === 0xFFFFFFFF || index < 0 || index >= this.strings.length) return '';
    return this.strings[index];
  }

  escapeXml(str) {
    if (!str) return '';
    return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
  }
}

/**
 * Android Layout Parser - Parses binary layout XML and produces structured data
 */
class LayoutParser {
  constructor(axmlResult) {
    this.xml = axmlResult.xml;
    this.strings = axmlResult.strings;
    this.tree = this.parseXmlLike(this.xml);
  }

  parseXmlLike(xml) {
    // Simple XML-like parser for the AXML output
    const lines = xml.split('\n').filter(l => l.trim());
    const root = { tag: '', attrs: {}, children: [] };
    const stack = [root];
    
    for (const line of lines) {
      const trimmed = line.trim();
      if (!trimmed) continue;
      
      if (trimmed.startsWith('<') && !trimmed.startsWith('</')) {
        // Opening tag
        const match = trimmed.match(/<(\w+)([^>]*)>\s*(.*)/);
        if (match) {
          const tag = match[1];
          const attrStr = match[2];
          const attrs = {};
          
          // Parse attributes
          const attrRegex = /(\w+)="([^"]*)"/g;
          let m;
          while ((m = attrRegex.exec(attrStr)) !== null) {
            attrs[m[1]] = m[2];
          }
          
          const node = { tag, attrs, children: [] };
          stack[stack.length - 1].children.push(node);
          if (!trimmed.endsWith('/>')) {
            stack.push(node);
          }
        }
      } else if (trimmed.startsWith('</')) {
        // Closing tag
        stack.pop();
      }
    }
    
    return root.children[0] || root;
  }

  toHTML(resourceMap = {}) {
    return this.renderNode(this.tree, resourceMap);
  }

  renderNode(node, resourceMap) {
    if (!node) return '';
    const tag = node.tag;
    const attrs = node.attrs || {};
    
    // Map Android views to HTML
    const viewMap = {
      'LinearLayout': () => this.renderLinearLayout(node, resourceMap),
      'RelativeLayout': () => this.renderRelativeLayout(node, resourceMap),
      'FrameLayout': () => this.renderFrameLayout(node, resourceMap),
      'ConstraintLayout': () => this.renderConstraintLayout(node, resourceMap),
      'TextView': () => this.renderTextView(node),
      'Button': () => this.renderButton(node),
      'ImageView': () => this.renderImageView(node, resourceMap),
      'EditText': () => this.renderEditText(node),
      'ScrollView': () => this.renderScrollView(node, resourceMap),
      'RecyclerView': () => this.renderRecyclerView(node),
      'ListView': () => this.renderRecyclerView(node),
      'View': () => this.renderGenericView(node),
      'CheckBox': () => this.renderCheckBox(node),
      'RadioButton': () => this.renderRadioButton(node),
      'Switch': () => this.renderSwitch(node),
      'ProgressBar': () => this.renderProgressBar(node),
      'SeekBar': () => this.renderSeekBar(node),
      'Toolbar': () => this.renderToolbar(node),
      'android.support.v7.widget.Toolbar': () => this.renderToolbar(node),
      'androidx.appcompat.widget.Toolbar': () => this.renderToolbar(node),
    };
    
    const renderer = viewMap[tag];
    if (renderer) {
      return renderer();
    }
    
    // Unknown tag - render children
    return node.children.map(c => this.renderNode(c, resourceMap)).join('');
  }

  // Layout renderers
  renderLinearLayout(node, resourceMap) {
    const attrs = node.attrs || {};
    const orientation = attrs.orientation === 'horizontal' ? 'row' : 'column';
    const style = `display:flex;flex-direction:${orientation};${this.layoutStyle(attrs)}`;
    const children = node.children.map(c => this.renderNode(c, resourceMap)).join('');
    return `<div style="${style}" class="apk-view LinearLayout">${children}</div>`;
  }

  renderRelativeLayout(node, resourceMap) {
    const attrs = node.attrs || {};
    const style = `position:relative;${this.layoutStyle(attrs)}`;
    const children = node.children.map(c => this.renderNode(c, resourceMap)).join('');
    return `<div style="${style}" class="apk-view RelativeLayout">${children}</div>`;
  }

  renderFrameLayout(node, resourceMap) {
    const attrs = node.attrs || {};
    const style = `position:relative;${this.layoutStyle(attrs)}`;
    const children = node.children.map(c => this.renderNode(c, resourceMap)).join('');
    return `<div style="${style}" class="apk-view FrameLayout">${children}</div>`;
  }

  renderConstraintLayout(node, resourceMap) {
    const attrs = node.attrs || {};
    const style = `position:relative;${this.layoutStyle(attrs)}`;
    const children = node.children.map(c => this.renderNode(c, resourceMap)).join('');
    return `<div style="${style}" class="apk-view ConstraintLayout">${children}</div>`;
  }

  // Widget renderers
  renderTextView(node) {
    const attrs = node.attrs || {};
    const text = attrs.text || attrs['android:text'] || '';
    const style = this.widgetStyle(attrs);
    const size = this.parseDimen(attrs['android:textSize']) || '14px';
    const color = this.parseColor(attrs['android:textColor']) || '#333';
    const weight = (attrs['android:textStyle'] === 'bold') ? '600' : '400';
    const gravity = this.parseGravity(attrs['android:gravity']);
    return `<div style="${style};font-size:${size};color:${color};font-weight:${weight};${gravity}" class="apk-view view-text">${this.escape(text)}</div>`;
  }

  renderButton(node) {
    const attrs = node.attrs || {};
    const text = attrs.text || attrs['android:text'] || 'Button';
    const style = this.widgetStyle(attrs);
    const bg = this.parseColor(attrs['android:background']) || '';
    const bgStyle = bg ? `background:${bg};` : 'background:#1a73e8;color:#fff;';
    return `<button style="${style};${bgStyle};border:none;border-radius:8px;padding:12px 20px;font-size:14px;font-weight:500;cursor:pointer;" class="apk-view view-button">${this.escape(text)}</button>`;
  }

  renderImageView(node, resourceMap) {
    const attrs = node.attrs || {};
    const src = attrs.src || attrs['android:src'] || '';
    const style = this.widgetStyle(attrs);
    const scaleType = attrs['android:scaleType'] || 'fitCenter';
    let bg = '';
    if (src.startsWith('@')) {
      const resName = src.replace('@drawable/', '').replace('@mipmap/', '');
      bg = resourceMap[resName] ? `background-image:url(${resourceMap[resName]});` : 'background:linear-gradient(135deg,#e0e0e0,#f0f0f0);';
    } else {
      bg = 'background:linear-gradient(135deg,#e0e0e0,#f0f0f0);';
    }
    const objFit = { centerCrop: 'cover', fitXY: '100% 100%', fitCenter: 'contain' }[scaleType] || 'cover';
    return `<div style="${style};${bg}background-size:${objFit};background-position:center;border-radius:8px;" class="apk-view view-image"></div>`;
  }

  renderEditText(node) {
    const attrs = node.attrs || {};
    const hint = attrs.hint || attrs['android:hint'] || '';
    const style = this.widgetStyle(attrs);
    return `<input type="text" placeholder="${this.escape(hint)}" style="${style};border:1px solid #ddd;border-radius:8px;padding:10px 14px;font-size:14px;outline:none;background:#fff;" class="apk-view view-edit">`;
  }

  renderScrollView(node, resourceMap) {
    const attrs = node.attrs || {};
    const style = `overflow-y:auto;${this.layoutStyle(attrs)}`;
    const children = node.children.map(c => this.renderNode(c, resourceMap)).join('');
    return `<div style="${style}" class="apk-view view-scroll">${children}</div>`;
  }

  renderRecyclerView(node) {
    const attrs = node.attrs || {};
    const style = this.layoutStyle(attrs);
    return `<div style="${style};background:#f5f5f5;border-radius:8px;padding:16px;" class="apk-view view-list"><div style="color:#999;font-size:13px;text-align:center">List content would appear here</div></div>`;
  }

  renderGenericView(node) {
    const attrs = node.attrs || {};
    const style = this.widgetStyle(attrs);
    const bg = this.parseColor(attrs['android:background']);
    const bgStyle = bg ? `background:${bg};` : '';
    return `<div style="${style};${bgStyle}" class="apk-view"></div>`;
  }

  renderCheckBox(node) {
    const attrs = node.attrs || {};
    const text = attrs.text || attrs['android:text'] || '';
    const checked = attrs['android:checked'] === 'true';
    return `<label style="${this.widgetStyle(attrs)};display:flex;align-items:center;gap:8px;cursor:pointer;"><input type="checkbox" ${checked ? 'checked' : ''} style="width:18px;height:18px;"><span>${this.escape(text)}</span></label>`;
  }

  renderRadioButton(node) {
    const attrs = node.attrs || {};
    const text = attrs.text || attrs['android:text'] || '';
    return `<label style="${this.widgetStyle(attrs)};display:flex;align-items:center;gap:8px;cursor:pointer;"><input type="radio" name="radio_group" style="width:18px;height:18px;"><span>${this.escape(text)}</span></label>`;
  }

  renderSwitch(node) {
    const attrs = node.attrs || {};
    const text = attrs.text || attrs['android:text'] || '';
    const checked = attrs['android:checked'] === 'true';
    return `<label style="${this.widgetStyle(attrs)};display:flex;align-items:center;justify-content:space-between;cursor:pointer;"><span>${this.escape(text)}</span><div style="width:44px;height:24px;background:${checked ? '#34c759' : '#ccc'};border-radius:12px;position:relative;transition:background 0.2s;"><div style="width:20px;height:20px;background:#fff;border-radius:50%;position:absolute;top:2px;${checked ? 'right:2px' : 'left:2px'};transition:all 0.2s;"></div></div></label>`;
  }

  renderProgressBar(node) {
    const attrs = node.attrs || {};
    const style = this.widgetStyle(attrs);
    const progress = parseInt(attrs['android:progress'] || '50');
    const max = parseInt(attrs['android:max'] || '100');
    const pct = (progress / max * 100).toFixed(0);
    return `<div style="${style};background:#e0e0e0;border-radius:4px;overflow:hidden;height:8px;"><div style="width:${pct}%;height:100%;background:#1a73e8;border-radius:4px;transition:width 0.3s;"></div></div>`;
  }

  renderSeekBar(node) {
    return this.renderProgressBar(node);
  }

  renderToolbar(node) {
    const attrs = node.attrs || {};
    const title = attrs.title || attrs['android:title'] || '';
    const style = this.layoutStyle(attrs);
    return `<div style="${style};background:#1a73e8;color:#fff;padding:16px;display:flex;align-items:center;font-size:16px;font-weight:600;">${this.escape(title)}</div>`;
  }

  // Style helpers
  layoutStyle(attrs) {
    const parts = [];
    const w = this.parseDimen(attrs['android:layout_width']);
    const h = this.parseDimen(attrs['android:layout_height']);
    if (w) parts.push(`width:${w}`);
    if (h) parts.push(`height:${h}`);
    const m = this.parseMargin(attrs);
    if (m) parts.push(m);
    const p = this.parsePadding(attrs);
    if (p) parts.push(p);
    const bg = this.parseColor(attrs['android:background']);
    if (bg) parts.push(`background:${bg}`);
    const gravity = this.parseGravityFlex(attrs['android:gravity']);
    if (gravity) parts.push(gravity);
    return parts.join(';');
  }

  widgetStyle(attrs) {
    const parts = [];
    const w = this.parseDimen(attrs['android:layout_width']);
    const h = this.parseDimen(attrs['android:layout_height']);
    const weight = attrs['android:layout_weight'];
    if (w) parts.push(`width:${w}`);
    if (h) parts.push(`height:${h}`);
    if (weight) parts.push(`flex:${weight}`);
    const m = this.parseMargin(attrs);
    if (m) parts.push(m);
    const p = this.parsePadding(attrs);
    if (p) parts.push(p);
    return parts.join(';');
  }

  parseDimen(val) {
    if (!val) return '';
    if (val === 'match_parent') return '100%';
    if (val === 'wrap_content') return 'auto';
    if (val === 'fill_parent') return '100%';
    if (val === '0dp') return '0'; // For weighted layouts
    // Parse dp/sp values
    const dp = val.match(/^(\d+)dp$/);
    if (dp) return `${dp[1]}px`;
    const sp = val.match(/^(\d+)sp$/);
    if (sp) return `${sp[1]}px`;
    return val;
  }

  parseMargin(attrs) {
    const parts = [];
    const margin = attrs['android:layout_margin'];
    if (margin) {
      const px = this.parseDimen(margin);
      if (px) parts.push(`margin:${px}`);
    }
    ['left','top','right','bottom'].forEach(side => {
      const v = attrs[`android:layout_margin${side.charAt(0).toUpperCase() + side.slice(1)}`];
      if (v) {
        const px = this.parseDimen(v);
        if (px) parts.push(`margin-${side}:${px}`);
      }
    });
    return parts.join(';');
  }

  parsePadding(attrs) {
    const parts = [];
    const padding = attrs['android:padding'];
    if (padding) {
      const px = this.parseDimen(padding);
      if (px) parts.push(`padding:${px}`);
    }
    ['left','top','right','bottom'].forEach(side => {
      const v = attrs[`android:padding${side.charAt(0).toUpperCase() + side.slice(1)}`];
      if (v) {
        const px = this.parseDimen(v);
        if (px) parts.push(`padding-${side}:${px}`);
      }
    });
    return parts.join(';');
  }

  parseColor(val) {
    if (!val) return '';
    if (val.startsWith('#')) return val;
    if (val.startsWith('@color/')) return '';
    if (val.startsWith('?attr/')) return '';
    // Handle @android:color/ references
    const androidColors = {
      'black': '#000', 'white': '#fff', 'red': '#f00', 'green': '#0f0', 'blue': '#00f',
      'transparent': 'transparent',
      'holo_red_light': '#ff4444', 'holo_red_dark': '#cc0000',
      'holo_blue_light': '#33b5e5', 'holo_blue_dark': '#0099cc',
      'holo_green_light': '#99cc00', 'holo_green_dark': '#669900',
    };
    const name = val.replace('@android:color/', '');
    return androidColors[name] || '';
  }

  parseGravity(val) {
    if (!val) return '';
    const parts = [];
    if (val.includes('center')) parts.push('text-align:center');
    if (val.includes('center_horizontal')) parts.push('text-align:center');
    if (val.includes('center_vertical')) parts.push('display:flex;align-items:center');
    if (val.includes('left')) parts.push('text-align:left');
    if (val.includes('right')) parts.push('text-align:right');
    if (val.includes('top')) parts.push('display:flex;align-items:flex-start');
    if (val.includes('bottom')) parts.push('display:flex;align-items:flex-end');
    return parts.join(';');
  }

  parseGravityFlex(val) {
    if (!val) return '';
    const parts = [];
    if (val.includes('center')) parts.push('justify-content:center;align-items:center');
    if (val.includes('center_horizontal')) parts.push('justify-content:center');
    if (val.includes('center_vertical')) parts.push('align-items:center');
    if (val.includes('left')) parts.push('justify-content:flex-start');
    if (val.includes('right')) parts.push('justify-content:flex-end');
    if (val.includes('top')) parts.push('align-items:flex-start');
    if (val.includes('bottom')) parts.push('align-items:flex-end');
    return parts.join(';');
  }

  escape(str) {
    if (!str) return '';
    return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
  }
}

/**
 * APK Analyzer - Orchestrates parsing and analysis
 */
class APKAnalyzer {
  constructor() {
    this.zipReader = null;
    this.manifest = null;
    this.layouts = new Map();
    this.resources = new Map();
    this.iconData = null;
  }

  async loadAPK(arrayBuffer) {
    this.zipReader = new ZIPReader(arrayBuffer);
    await this.zipReader.parse();
    
    // Parse AndroidManifest.xml
    const manifestData = await this.zipReader.extract('AndroidManifest.xml');
    if (!manifestData) throw new Error('AndroidManifest.xml not found');
    
    const axml = new AXMLParser(manifestData.buffer);
    this.manifest = axml.parse();
    
    // Extract layouts
    const layoutNames = this.zipReader.getEntryNames().filter(n => 
      n.startsWith('res/layout/') && n.endsWith('.xml')
    );
    
    for (const name of layoutNames) {
      try {
        const data = await this.zipReader.extract(name);
        if (data) {
          const parser = new AXMLParser(data.buffer);
          const result = parser.parse();
          this.layouts.set(name, result);
        }
      } catch (e) {
        console.warn(`Failed to parse layout ${name}:`, e);
      }
    }
    
    // Extract icon
    await this.extractIcon();
    
    return this.getInfo();
  }

  async extractIcon() {
    // Look for app icon in common locations
    const iconPaths = this.zipReader.getEntryNames().filter(n =>
      n.match(/res\/(drawable|mipmap)[^/]*\/(ic_launcher|icon|logo)/i)
    );
    
    // Prefer PNG
    const pngIcon = iconPaths.find(p => p.endsWith('.png'));
    if (pngIcon) {
      const data = await this.zipReader.extract(pngIcon);
      if (data) {
        const blob = new Blob([data], { type: 'image/png' });
        this.iconData = URL.createObjectURL(blob);
        return;
      }
    }
    
    // Try WEBP
    const webpIcon = iconPaths.find(p => p.endsWith('.webp'));
    if (webpIcon) {
      const data = await this.zipReader.extract(webpIcon);
      if (data) {
        const blob = new Blob([data], { type: 'image/webp' });
        this.iconData = URL.createObjectURL(blob);
        return;
      }
    }
    
    this.iconData = null;
  }

  getInfo() {
    const attrs = this.manifest.attrs || {};
    const xml = this.manifest.xml || '';
    
    // Extract info from parsed manifest
    const pkg = attrs.package || this.extractFromXml(xml, 'package="([^"]*)"') || 'unknown';
    const versionName = attrs['android:versionName'] || this.extractFromXml(xml, 'android:versionName="([^"]*)"') || '?';
    const versionCode = attrs['android:versionCode'] || this.extractFromXml(xml, 'android:versionCode="([^"]*)"') || '?';
    const appLabel = attrs['android:label'] || this.extractFromXml(xml, 'android:label="([^"]*)"') || 'Unknown App';
    const minSdk = this.extractFromXml(xml, 'android:minSdkVersion="([^"]*)"') || '?';
    const targetSdk = this.extractFromXml(xml, 'android:targetSdkVersion="([^"]*)"') || '?';
    
    // Extract permissions
    const permissions = this.extractPermissions(xml);
    
    // Extract activities
    const activities = this.extractActivities(xml);
    
    // Extract file list
    const files = this.zipReader.getEntryNames();
    
    return {
      packageName: pkg,
      appName: this.resolveResourceName(appLabel),
      versionName: this.resolveResourceName(versionName),
      versionCode,
      minSdk,
      targetSdk,
      permissions,
      activities,
      files,
      fileCount: files.length,
      layoutCount: this.layouts.size,
      icon: this.iconData,
      manifestXml: xml
    };
  }

  extractFromXml(xml, regex) {
    const m = xml.match(regex);
    return m ? m[1] : '';
  }

  extractPermissions(xml) {
    const perms = [];
    const regex = /<uses-permission[^>]*android:name="([^"]*)"[^>]*>/g;
    let m;
    while ((m = regex.exec(xml)) !== null) {
      const name = m[1];
      const level = this.getPermissionLevel(name);
      perms.push({ name: name.replace('android.permission.', ''), fullName: name, level });
    }
    return perms;
  }

  getPermissionLevel(perm) {
    const dangerous = ['CAMERA','READ_CONTACTS','WRITE_CONTACTS','READ_EXTERNAL_STORAGE',
      'WRITE_EXTERNAL_STORAGE','ACCESS_FINE_LOCATION','ACCESS_COARSE_LOCATION',
      'RECORD_AUDIO','READ_PHONE_STATE','CALL_PHONE','SEND_SMS','RECEIVE_SMS',
      'READ_SMS','BODY_SENSORS','ACTIVITY_RECOGNITION'];
    const signature = ['INSTALL_PACKAGES','DELETE_PACKAGES','CLEAR_APP_CACHE',
      'WRITE_SECURE_SETTINGS','DUMP','INJECT_EVENTS'];
    
    const base = perm.replace('android.permission.', '');
    if (dangerous.includes(base)) return 'dangerous';
    if (signature.includes(base)) return 'signature';
    return 'normal';
  }

  extractActivities(xml) {
    const activities = [];
    const regex = /<activity[^>]*android:name="([^"]*)"[^>]*>/g;
    let m;
    while ((m = regex.exec(xml)) !== null) {
      const name = m[1];
      const isMain = xml.substring(m.index, m.index + 500).includes('android.intent.action.MAIN');
      activities.push({ name, isMain });
    }
    return activities;
  }

  resolveResourceName(val) {
    if (!val) return '';
    if (val.startsWith('@string/')) {
      // Try to find in string resources
      const key = val.replace('@string/', '');
      return key; // Would need resources.arsc parsing for full resolution
    }
    return val;
  }

  async renderMainLayout() {
    // Find the main activity's layout
    const mainLayout = Array.from(this.layouts.entries()).find(([name]) => 
      name.includes('main') || name.includes('activity_main')
    );
    
    if (!mainLayout) {
      // Return first available layout
      const first = this.layouts.entries().next().value;
      if (!first) return '<div style="padding:20px;color:#999;text-align:center">No layouts found in APK</div>';
      mainLayout = first;
    }
    
    const [name, axmlResult] = mainLayout;
    const parser = new LayoutParser(axmlResult);
    return parser.toHTML(this.resources);
  }

  getFileTree() {
    return this.zipReader.getEntryNames().map(name => {
      const parts = name.split('/');
      const depth = parts.length - 1;
      const isDir = name.endsWith('/');
      const displayName = isDir ? parts[parts.length - 2] || name : parts[parts.length - 1];
      return { name, displayName, depth, isDir };
    });
  }
}

// ===================== APK SIDELOAD UI =====================
let apkAnalyzer = null;

function initSideloadUI() {
  const sideloadBtn = document.getElementById('btnSideload');
  const sideloadOverlay = document.getElementById('sideloadOverlay');
  const sideloadClose = document.getElementById('sideloadClose');
  const dropzone = document.getElementById('sideloadDropzone');
  const fileInput = document.getElementById('sideloadInput');
  
  // Open sideload overlay
  sideloadBtn.addEventListener('click', () => {
    sideloadOverlay.classList.add('active');
    resetSideloadUI();
  });
  
  sideloadClose.addEventListener('click', closeSideloadOverlay);
  
  // Drop zone
  dropzone.addEventListener('click', () => fileInput.click());
  
  dropzone.addEventListener('dragover', (e) => {
    e.preventDefault();
    dropzone.classList.add('dragover');
  });
  
  dropzone.addEventListener('dragleave', () => {
    dropzone.classList.remove('dragover');
  });
  
  dropzone.addEventListener('drop', (e) => {
    e.preventDefault();
    dropzone.classList.remove('dragover');
    const file = e.dataTransfer.files[0];
    if (file && file.name.endsWith('.apk')) {
      processAPK(file);
    } else {
      showToast('Please drop a valid .apk file');
    }
  });
  
  fileInput.addEventListener('change', (e) => {
    const file = e.target.files[0];
    if (file) processAPK(file);
  });
  
  // Install and preview buttons
  document.getElementById('apkInstallBtn').addEventListener('click', installAPK);
  document.getElementById('apkPreviewBtn').addEventListener('click', previewAPK);
  document.getElementById('apkPreviewBack').addEventListener('click', closeAPKPreview);
}

function closeSideloadOverlay() {
  document.getElementById('sideloadOverlay').classList.remove('active');
}

function resetSideloadUI() {
  document.getElementById('sideloadDropzone').style.display = 'block';
  document.getElementById('sideloadProgress').classList.remove('active');
  document.getElementById('apkInfo').classList.remove('active');
  document.getElementById('apkPreviewPanel').style.display = 'none';
  document.getElementById('sideloadInput').value = '';
  apkAnalyzer = null;
  state.currentAPK = null;
}

async function processAPK(file) {
  showProgress(10, 'Reading APK file...');
  document.getElementById('sideloadDropzone').style.display = 'none';
  document.getElementById('sideloadProgress').classList.add('active');
  
  try {
    const arrayBuffer = await file.arrayBuffer();
    
    showProgress(30, 'Parsing APK structure...');
    apkAnalyzer = new APKAnalyzer();
    
    showProgress(60, 'Analyzing manifest...');
    const info = await apkAnalyzer.loadAPK(arrayBuffer);
    state.currentAPK = info;
    
    showProgress(90, 'Extracting resources...');
    await new Promise(r => setTimeout(r, 300));
    
    showProgress(100, 'Done!');
    displayAPKInfo(info);
    
  } catch (error) {
    console.error('APK parsing error:', error);
    showToast('Error parsing APK: ' + error.message);
    resetSideloadUI();
  }
}

function showProgress(pct, text) {
  document.getElementById('sideloadProgressFill').style.width = pct + '%';
  document.getElementById('sideloadProgressText').textContent = text;
}

function displayAPKInfo(info) {
  document.getElementById('sideloadProgress').classList.remove('active');
  document.getElementById('apkInfo').classList.add('active');
  
  // Header
  document.getElementById('apkInfoName').textContent = info.appName || 'Unknown App';
  document.getElementById('apkInfoPkg').textContent = info.packageName;
  document.getElementById('apkInfoVersion').textContent = `v${info.versionName} (code: ${info.versionCode}, SDK: ${info.targetSdk})`;
  
  // Icon
  const iconEl = document.getElementById('apkInfoIcon');
  if (info.icon) {
    iconEl.innerHTML = `<img src="${info.icon}" style="width:100%;height:100%;object-fit:cover;border-radius:18px">`;
  } else {
    iconEl.textContent = '';
    iconEl.innerHTML = '<span style="font-size:36px">&#128230;</span>';
  }
  
  // Permissions
  const permList = document.getElementById('apkPermList');
  if (info.permissions.length === 0) {
    permList.innerHTML = '<div style="color:rgba(255,255,255,0.4);font-size:13px;padding:8px">No special permissions declared</div>';
  } else {
    permList.innerHTML = info.permissions.map(p => `
      <div class="apk-perm-item">
        <span class="apk-perm-icon">${p.level === 'dangerous' ? '&#128683;' : p.level === 'signature' ? '&#128272;' : '&#10003;'}</span>
        <span class="apk-perm-name">${p.name}</span>
        <span class="apk-perm-level ${p.level}">${p.level}</span>
      </div>
    `).join('');
  }
  
  // Activities
  const actList = document.getElementById('apkActivityList');
  if (info.activities.length === 0) {
    actList.innerHTML = '<div style="color:rgba(255,255,255,0.4);font-size:13px;padding:8px">No activities found</div>';
  } else {
    actList.innerHTML = info.activities.map(a => `
      <div class="apk-activity-item ${a.isMain ? 'apk-activity-main' : ''}">
        <span style="flex:1;word-break:break-all">${a.name}</span>
        ${a.isMain ? '<span class="apk-activity-badge">MAIN</span>' : ''}
      </div>
    `).join('');
  }
  
  // File tree (show first 30 entries)
  const fileTree = document.getElementById('apkFileTree');
  const files = info.files.slice(0, 50);
  fileTree.innerHTML = files.map(f => {
    const isDir = f.endsWith('/');
    const name = isDir ? f.slice(0, -1).split('/').pop() + '/' : f.split('/').pop();
    return `<div class="apk-file-item ${isDir ? 'folder' : 'file'}">${isDir ? '&#128193;' : '&#128196;'} ${name}</div>`;
  }).join('');
  if (info.files.length > 50) {
    fileTree.innerHTML += `<div style="color:rgba(255,255,255,0.3);font-size:11px;padding:8px;text-align:center">... and ${info.files.length - 50} more files</div>`;
  }
}

async function previewAPK() {
  if (!apkAnalyzer) return;
  
  showToast('Rendering UI preview...');
  
  try {
    const rendered = await apkAnalyzer.renderMainLayout();
    
    document.getElementById('apkInfo').style.display = 'none';
    const previewPanel = document.getElementById('apkPreviewPanel');
    previewPanel.style.display = 'block';
    previewPanel.classList.add('active');
    
    document.getElementById('apkRenderedUI').innerHTML = `<div class="apk-rendered-view">${rendered}</div>`;
    
    // Show resource grid
    const resourceGrid = document.getElementById('apkResourceGrid');
    const layouts = Array.from(apkAnalyzer.layouts.keys()).map(name => {
      const simpleName = name.replace('res/layout/', '');
      return `<div class="apk-resource-item" title="${simpleName}"><span style="font-size:10px;text-align:center;padding:4px">${simpleName}</span></div>`;
    });
    resourceGrid.innerHTML = layouts.join('');
    
    // Add back button
    const backBtn = document.createElement('button');
    backBtn.className = 'apk-btn preview';
    backBtn.style.cssText = 'margin-top:16px;width:100%';
    backBtn.innerHTML = '&#8592; Back to Info';
    backBtn.onclick = () => {
      previewPanel.style.display = 'none';
      document.getElementById('apkInfo').style.display = 'block';
    };
    
    // Only add if not already present
    if (!previewPanel.querySelector('.apk-btn.preview')) {
      previewPanel.appendChild(backBtn);
    }
    
  } catch (e) {
    console.error('Preview error:', e);
    showToast('Could not render layout preview');
  }
}

function installAPK() {
  if (!state.currentAPK) return;
  
  const info = state.currentAPK;
  const appId = 'sideloaded_' + info.packageName.replace(/\./g, '_');
  
  // Check if already installed
  if (state.sideloadedApps.find(a => a.id === appId)) {
    showToast('App already installed!');
    closeSideloadOverlay();
    return;
  }
  
  // Add to sideloaded apps
  const app = {
    id: appId,
    name: info.appName || info.packageName.split('.').pop(),
    packageName: info.packageName,
    emoji: info.icon ? null : getEmojiForApp(info.appName),
    icon: info.icon,
    bg: 'linear-gradient(135deg,#5856d6,#af52de)',
    color: '#fff',
    isSideloaded: true,
    analyzer: apkAnalyzer
  };
  
  state.sideloadedApps.push(app);
  
  // Update home screen
  renderHomeApps();
  renderDrawerApps();
  
  showToast(`Installed "${app.name}"!`);
  closeSideloadOverlay();
}

function getEmojiForApp(name) {
  const emojis = {
    'game': '&#127918;', 'music': '&#127925;', 'video': '&#127909;',
    'photo': '&#128248;', 'camera': '&#128248;', 'mail': '&#128231;',
    'message': '&#128172;', 'chat': '&#128172;', 'map': '&#128205;',
    'weather': '&#127780;', 'news': '&#128240;', 'shop': '&#128722;',
    'bank': '&#127974;', 'health': '&#10084;', 'fitness': '&#127947;',
    'food': '&#127828;', 'travel': '&#9992;', 'social': '&#128101;',
    'tool': '&#128295;', 'edit': '&#9999;', 'file': '&#128196;',
    'cloud': '&#9729;', 'wifi': '&#128246;', 'home': '&#127968;',
  };
  const lower = (name || '').toLowerCase();
  for (const [key, emoji] of Object.entries(emojis)) {
    if (lower.includes(key)) return emoji;
  }
  return '&#128230;'; // Package icon default
}

function launchSideloadedApp(app) {
  const previewWindow = document.getElementById('apkPreviewWindow');
  const previewBody = document.getElementById('apkPreviewBody');
  const previewTitle = document.getElementById('apkPreviewTitle');
  
  previewTitle.textContent = app.name;
  
  // Render the app's main layout
  if (app.analyzer) {
    app.analyzer.renderMainLayout().then(rendered => {
      previewBody.innerHTML = `<div class="apk-rendered-view" style="padding:16px">${rendered}</div>`;
    }).catch(() => {
      previewBody.innerHTML = `
        <div style="padding:40px;text-align:center;color:#666">
          <div style="font-size:48px;margin-bottom:16px">&#128230;</div>
          <div style="font-size:16px;font-weight:600;margin-bottom:8px">${app.name}</div>
          <div style="font-size:13px;color:#999;margin-bottom:20px">${app.packageName}</div>
          <div style="background:#f0f0f0;border-radius:12px;padding:16px;font-size:13px;color:#666">
            <p>This APK has been sideloaded.</p>
            <p style="margin-top:8px">The app's UI layouts are being analyzed and rendered as HTML.</p>
            <p style="margin-top:8px">For native execution, a full Android runtime would be needed.</p>
          </div>
        </div>
      `;
    });
  } else {
    previewBody.innerHTML = `
      <div style="padding:40px;text-align:center;color:#666">
        <div style="font-size:48px;margin-bottom:16px">&#128230;</div>
        <div style="font-size:16px;font-weight:600">${app.name}</div>
        <div style="font-size:13px;color:#999;margin-top:8px">${app.packageName}</div>
      </div>
    `;
  }
  
  previewWindow.classList.add('active');
  state.currentApp = app.id;
  state.appStack.push(app.id);
}

function closeAPKPreview() {
  document.getElementById('apkPreviewWindow').classList.remove('active');
  goHome();
}

// ===================== ORIGINAL FUNCTIONS =====================
function updateClock() {
  const now = new Date();
  const h = String(now.getHours()).padStart(2,'0');
  const m = String(now.getMinutes()).padStart(2,'0');
  const timeStr = `${h}:${m}`;
  
  document.getElementById('statusTime').textContent = timeStr;
  document.getElementById('lockClock').textContent = timeStr;
  document.getElementById('widgetTime').textContent = timeStr;
  document.getElementById('notifClock').textContent = timeStr;
  
  const days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'];
  const months = ['January','February','March','April','May','June','July','August','September','October','November','December'];
  const mons = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'];
  
  document.getElementById('lockDate').textContent = `${days[now.getDay()]}, ${months[now.getMonth()]} ${now.getDate()}`;
  document.getElementById('widgetDate').textContent = `${days[now.getDay()].slice(0,3)}, ${mons[now.getMonth()]} ${now.getDate()}`;
  document.getElementById('notifDate').textContent = `${days[now.getDay()]}, ${months[now.getMonth()]} ${now.getDate()}`;
}

function toggleScreen() {
  state.screenOn = !state.screenOn;
  const ps = document.getElementById('phoneScreen');
  if (!state.screenOn) {
    ps.classList.add('screen-off');
    state.locked = true;
    document.getElementById('lockScreen').classList.remove('hidden');
    closeAllApps();
  } else {
    ps.classList.remove('screen-off');
  }
}

function closeAllApps() {
  document.querySelectorAll('.app-window').forEach(w => w.classList.remove('active'));
  document.querySelectorAll('.app-drawer,.notif-panel,.recent-apps').forEach(p => p.classList.remove('open'));
  document.getElementById('apkPreviewWindow').classList.remove('active');
  state.currentApp = null;
  state.appStack = [];
}

function goHome() {
  document.querySelectorAll('.app-window').forEach(w => w.classList.remove('active'));
  document.getElementById('apkPreviewWindow').classList.remove('active');
  document.getElementById('appDrawer').classList.remove('open');
  document.getElementById('recentApps').classList.remove('open');
  document.getElementById('notifPanel').classList.remove('open');
  closeSideloadOverlay();
  state.currentApp = null;
}

function goBack() {
  document.getElementById('apkPreviewWindow').classList.remove('active');
  if (state.appStack.length > 0) {
    state.appStack.pop();
    const prev = state.appStack[state.appStack.length - 1];
    if (prev) {
      const win = document.getElementById('app-' + prev) || document.getElementById(prev);
      if (win) {
        document.querySelectorAll('.app-window').forEach(w => w.classList.remove('active'));
        win.classList.add('active');
        state.currentApp = prev;
        return;
      }
    }
  }
  closeAllApps();
  goHome();
}

function openNotifPanel() { document.getElementById('notifPanel').classList.add('open'); }
function closeNotifPanel() { document.getElementById('notifPanel').classList.remove('open'); }
function openAppDrawer() { document.getElementById('appDrawer').classList.add('open'); renderDrawerApps(); }
function closeAppDrawer() { document.getElementById('appDrawer').classList.remove('open'); }
function openRecentApps() { document.getElementById('recentApps').classList.add('open'); renderRecentApps(); }

function launchApp(appId) {
  // Check if it's a sideloaded app
  const sideloadedApp = state.sideloadedApps.find(a => a.id === appId);
  if (sideloadedApp) {
    closeAppDrawer();
    launchSideloadedApp(sideloadedApp);
    return;
  }
  
  const win = document.getElementById('app-' + appId);
  if (!win) return;
  document.querySelectorAll('.app-window').forEach(w => w.classList.remove('active'));
  win.classList.add('active');
  state.currentApp = appId;
  state.appStack.push(appId);
  closeAppDrawer();
  closeNotifPanel();
}

function renderHomeApps() {
  const grid = document.getElementById('appGrid');
  // First 8 built-in apps (excluding dock apps)
  const topApps = BUILTIN_APPS.filter(a => !['phone','messages','browser','camera'].includes(a.id)).slice(0, 8);
  
  let html = topApps.map(app => 
    `<div class="app-icon" data-app="${app.id}"><div class="app-icon-img" style="background:${app.bg};color:${app.color}">${app.emoji}</div><div class="app-icon-label">${app.name}</div></div>`
  ).join('');
  
  // Add sideloaded apps to home grid
  state.sideloadedApps.forEach(app => {
    const iconContent = app.icon ? 
      `<img src="${app.icon}" style="width:100%;height:100%;object-fit:cover;border-radius:14px">` :
      `<span>${app.emoji}</span>`;
    html += `<div class="app-icon" data-app="${app.id}"><div class="app-icon-img sideloaded" style="background:${app.bg};color:${app.color}">${iconContent}</div><div class="app-icon-label">${app.name}</div></div>`;
  });
  
  grid.innerHTML = html;
  
  grid.querySelectorAll('.app-icon').forEach(icon => {
    icon.addEventListener('click', () => launchApp(icon.dataset.app));
  });
}

function renderDrawerApps() {
  const grid = document.getElementById('drawerGrid');
  const allApps = [...BUILTIN_APPS, ...state.sideloadedApps];
  allApps.sort((a, b) => a.name.localeCompare(b.name));
  
  grid.innerHTML = allApps.map(app => {
    const iconContent = app.icon ?
      `<img src="${app.icon}" style="width:100%;height:100%;object-fit:cover;border-radius:13px">` :
      `<span>${app.emoji}</span>`;
    const sideloadedClass = app.isSideloaded ? 'sideloaded' : '';
    return `<div class="app-icon" data-app="${app.id}"><div class="app-icon-img ${sideloadedClass}" style="background:${app.bg};color:${app.color}">${iconContent}</div><div class="app-icon-label">${app.name}${app.isSideloaded ? ' <span style="color:#af52de">*</span>' : ''}</div></div>`;
  }).join('');
  
  grid.querySelectorAll('.app-icon').forEach(icon => {
    icon.addEventListener('click', () => launchApp(icon.dataset.app));
  });
}

function renderNotifications() {
  const list = document.getElementById('notifList');
  if (state.notifications.length === 0) {
    list.innerHTML = '<div style="text-align:center;color:rgba(255,255,255,0.3);padding:20px;font-size:13px">No notifications</div>';
    return;
  }
  list.innerHTML = state.notifications.map(n => 
    `<div class="notif-item"><div class="notif-item-icon" style="background:${n.color}">${n.icon}</div><div><div class="notif-item-title">${n.title}</div><div style="color:rgba(255,255,255,0.6)">${n.text}</div></div></div>`
  ).join('');
}

function renderLockNotifs() {
  const el = document.getElementById('lockNotifs');
  const notifs = state.notifications.slice(0, 3);
  if (notifs.length === 0) { el.innerHTML = ''; return; }
  el.innerHTML = notifs.map(n => 
    `<div class="lock-notif-item"><div style="font-size:18px">${n.icon}</div><div><div style="font-weight:600;margin-bottom:2px">${n.title}</div><div style="opacity:0.7">${n.text}</div></div></div>`
  ).join('');
}

function renderRecentApps() {
  const list = document.getElementById('recentList');
  const recent = state.appStack.slice(-3).reverse();
  if (recent.length === 0) {
    list.innerHTML = '<div style="text-align:center;color:rgba(255,255,255,0.3);padding:40px;font-size:13px">No recent apps</div>';
    return;
  }
  list.innerHTML = recent.map(appId => {
    const app = BUILTIN_APPS.find(a => a.id === appId) || state.sideloadedApps.find(a => a.id === appId);
    const name = app ? app.name : appId;
    const icon = app ? (app.icon ? `<img src="${app.icon}" style="width:40px;height:40px;border-radius:10px">` : app.emoji) : '&#128230;';
    return `<div class="recent-card"><span style="display:flex;align-items:center;gap:12px"><span style="font-size:28px">${icon}</span><span>${name}</span></span><button class="recent-card-close" data-app="${appId}">&#10005;</button></div>`;
  }).join('');
  
  list.querySelectorAll('.recent-card-close').forEach(btn => {
    btn.addEventListener('click', (e) => {
      e.stopPropagation();
      const appId = btn.dataset.app;
      state.appStack = state.appStack.filter(id => id !== appId);
      renderRecentApps();
    });
  });
}

function renderCallLog() {
  const el = document.getElementById('callLog');
  el.innerHTML = state.callLog.map(c => 
    `<div class="call-log-item"><span style="font-size:20px">${c.dir === '&#8593;' ? '&#8593;' : '&#8595;'}</span><div style="flex:1"><div style="font-weight:500">${c.name}</div><div style="font-size:12px;color:var(--text-secondary)">${c.number}</div></div><span style="font-size:12px;color:var(--text-secondary)">${c.time}</span></div>`
  ).join('');
}

function renderMessages() {
  const el = document.getElementById('msgList');
  el.innerHTML = state.conversations.map(c => {
    const lastMsg = c.messages[c.messages.length - 1];
    return `<div class="msg-item" data-cid="${c.id}"><div class="msg-avatar" style="background:linear-gradient(135deg,#667eea,#764ba2)">${c.name.charAt(0)}</div><div class="msg-info"><div class="msg-name">${c.name}</div><div class="msg-preview">${lastMsg.text}</div></div><div class="msg-time">Now</div></div>`;
  }).join('');
}

function renderAlarms() {
  const el = document.getElementById('alarmList');
  el.innerHTML = state.alarms.map((a, i) => 
    `<div class="alarm-item"><div><div style="font-size:32px;font-weight:200">${a.time}</div><div style="font-size:12px;color:var(--text-secondary)">${a.label}</div></div><div class="settings-toggle ${a.on ? 'on' : ''}" data-idx="${i}" onclick="this.classList.toggle('on');state.alarms[${i}].on=this.classList.contains('on')"></div></div>`
  ).join('');
}

function renderGallery() {
  const el = document.getElementById('galleryGrid');
  el.innerHTML = state.gallery.map((g, i) => 
    `<div class="gallery-item" style="background:${g.color}">${g.emoji}</div>`
  ).join('');
}

function renderContacts() {
  const el = document.getElementById('contactsList');
  const sorted = [...state.contacts].sort((a, b) => a.name.localeCompare(b.name));
  el.innerHTML = sorted.map(c => 
    `<div class="contact-item"><div class="contact-avatar" style="background:${c.color}">${c.name.charAt(0)}</div><div class="contact-name">${c.name}</div></div>`
  ).join('');
}

function unlockPhone() {
  if (!state.locked) return;
  state.locked = false;
  document.getElementById('lockScreen').classList.add('hidden');
}

function showToast(msg) {
  const toast = document.getElementById('toast');
  toast.textContent = msg;
  toast.classList.add('show');
  setTimeout(() => toast.classList.remove('show'), 2500);
}

function showVolume() {
  const ov = document.getElementById('volOverlay');
  document.getElementById('volFill').style.height = state.volume + '%';
  ov.style.display = 'block';
  clearTimeout(state._volTimer);
  state._volTimer = setTimeout(() => { ov.style.display = 'none'; }, 1500);
}

function createAboutHTML() {
  return `
    <div style="text-align:center;padding:20px 0">
      <div style="width:80px;height:80px;border-radius:20px;background:linear-gradient(135deg,#667eea,#764ba2);display:inline-flex;align-items:center;justify-content:center;font-size:40px;margin-bottom:16px">&#128241;</div>
      <div style="font-size:20px;font-weight:600;margin-bottom:4px">Android Phone Simulator</div>
      <div style="font-size:13px;color:var(--text-secondary);margin-bottom:20px">v2.0 + APK Sideload</div>
    </div>
    <div style="background:rgba(255,255,255,0.05);border-radius:16px;padding:16px;margin-bottom:12px">
      <div style="display:flex;justify-content:space-between;padding:8px 0;border-bottom:1px solid rgba(255,255,255,0.05)"><span style="color:var(--text-secondary)">Device</span><span>Pixel 8 Simulator</span></div>
      <div style="display:flex;justify-content:space-between;padding:8px 0;border-bottom:1px solid rgba(255,255,255,0.05)"><span style="color:var(--text-secondary)">Android Version</span><span>14 (API 34)</span></div>
      <div style="display:flex;justify-content:space-between;padding:8px 0;border-bottom:1px solid rgba(255,255,255,0.05)"><span style="color:var(--text-secondary)">Kernel</span><span>WebAssembly JS</span></div>
      <div style="display:flex;justify-content:space-between;padding:8px 0"><span style="color:var(--text-secondary)">APK Parser</span><span>Native AXML v1.0</span></div>
    </div>
    <div style="font-size:12px;color:var(--text-secondary);text-align:center;line-height:1.6">
      <p>This simulator runs entirely in your browser.</p>
      <p>APK sideloading parses Android apps and renders their UI as HTML.</p>
      <p>No external servers or APIs are used.</p>
    </div>
  `;
}

// ===================== EVENT SETUP =====================
function setupEvents() {
  // Power button
  document.getElementById('btnPower').addEventListener('click', toggleScreen);
  
  // Volume buttons
  document.getElementById('btnVolUp').addEventListener('click', () => {
    state.volume = Math.min(100, state.volume + 10);
    showVolume();
  });
  document.getElementById('btnVolDown').addEventListener('click', () => {
    state.volume = Math.max(0, state.volume - 10);
    showVolume();
  });
  
  // Navigation
  document.getElementById('navPill').addEventListener('click', goHome);
  document.getElementById('navHome').addEventListener('click', goHome);
  document.getElementById('navBack').addEventListener('click', goBack);
  document.getElementById('navRecent').addEventListener('click', openRecentApps);
  
  // Lock screen
  let lockStartY = 0;
  const lockScreen = document.getElementById('lockScreen');
  lockScreen.addEventListener('touchstart', e => { lockStartY = e.touches[0].clientY; }, {passive:true});
  lockScreen.addEventListener('touchend', e => {
    const dy = lockStartY - e.changedTouches[0].clientY;
    if (dy > 60) unlockPhone();
  }, {passive:true});
  lockScreen.addEventListener('mousedown', e => { lockStartY = e.clientY; });
  lockScreen.addEventListener('mouseup', e => {
    const dy = lockStartY - e.clientY;
    if (dy > 60) unlockPhone();
  });
  let lastTap = 0;
  lockScreen.addEventListener('click', () => {
    const now = Date.now();
    if (now - lastTap < 300) unlockPhone();
    lastTap = now;
  });
  
  // Swipe gestures
  let notifStartY = 0;
  const screenContent = document.getElementById('screenContent');
  screenContent.addEventListener('touchstart', e => { notifStartY = e.touches[0].clientY; }, {passive:true});
  screenContent.addEventListener('touchend', e => {
    const y = e.changedTouches[0].clientY;
    const dy = y - notifStartY;
    if (notifStartY < 60 && dy > 40) openNotifPanel();
    if (notifStartY > screenContent.clientHeight - 60 && dy < -40) goHome();
    if (state.currentApp === null && !state.locked && dy < -50 && notifStartY > 200) openAppDrawer();
  }, {passive:true});
  
  let mouseDown = false;
  screenContent.addEventListener('mousedown', e => { mouseDown = true; notifStartY = e.clientY; });
  screenContent.addEventListener('mouseup', e => {
    if (!mouseDown) return;
    mouseDown = false;
    const dy = e.clientY - notifStartY;
    if (notifStartY < 60 && dy > 40) openNotifPanel();
    if (notifStartY > screenContent.clientHeight - 60 && dy < -40) goHome();
    if (state.currentApp === null && !state.locked && dy < -50 && notifStartY > 200) openAppDrawer();
  });
  
  // Notif panel close
  const notifPanel = document.getElementById('notifPanel');
  let npStart = 0;
  notifPanel.addEventListener('touchstart', e => { npStart = e.touches[0].clientY; }, {passive:true});
  notifPanel.addEventListener('touchend', e => {
    if (e.changedTouches[0].clientY - npStart < -50) closeNotifPanel();
  }, {passive:true});
  
  // Notification toggles
  document.querySelectorAll('.notif-toggle').forEach(btn => {
    btn.addEventListener('click', () => {
      btn.classList.toggle('active');
      const key = btn.dataset.t;
      if (key === 'wifi') state.settings.wifi = btn.classList.contains('active');
      if (key === 'bt') state.settings.bluetooth = btn.classList.contains('active');
    });
  });
  
  // Clear notifications
  document.getElementById('notifClear').addEventListener('click', () => {
    state.notifications = [];
    renderNotifications();
    renderLockNotifs();
  });
  
  // Search bar opens browser
  document.getElementById('searchBar').addEventListener('click', () => launchApp('browser'));
  
  // App drawer close
  document.querySelector('.drawer-hint').addEventListener('click', closeAppDrawer);
  
  // App back buttons
  document.getElementById('calcBack').addEventListener('click', goBack);
  document.getElementById('brBack').addEventListener('click', goBack);
  document.getElementById('phoneBack').addEventListener('click', goBack);
  document.getElementById('msgBack').addEventListener('click', () => {
    document.getElementById('chatView').classList.remove('active');
    document.getElementById('msgListView').style.display = 'block';
    document.getElementById('msgBack').style.display = 'none';
    document.getElementById('msgTitle').textContent = 'Messages';
    renderMessages();
  });
  document.getElementById('camBack').addEventListener('click', goBack);
  document.getElementById('clockBack').addEventListener('click', goBack);
  document.getElementById('settingsBack').addEventListener('click', goBack);
  document.getElementById('galleryBack').addEventListener('click', goBack);
  document.getElementById('filesBack').addEventListener('click', goBack);
  document.getElementById('contactsBack').addEventListener('click', () => {
    document.getElementById('contactsListView').style.display = 'block';
    document.getElementById('contactsAddView').style.display = 'none';
    document.getElementById('contactsAdd').style.display = 'flex';
    document.getElementById('contactsBack').style.display = 'none';
    document.getElementById('contactsTitle').textContent = 'Contacts';
    renderContacts();
  });
}

function setupAppScripts() {
  // Calculator
  let calcVal = '0', calcPrev = '', calcOp = null;
  document.querySelectorAll('.calc-btn').forEach(btn => {
    btn.addEventListener('click', () => {
      const v = btn.dataset.c;
      if (v === 'C') { calcVal = '0'; calcPrev = ''; calcOp = null; }
      else if (v === '\u00b1') { calcVal = String(parseFloat(calcVal) * -1); }
      else if (v === '%') { calcVal = String(parseFloat(calcVal) / 100); }
      else if (['+','-','*','/'].includes(v)) { calcPrev = calcVal; calcOp = v; calcVal = '0'; }
      else if (v === '=') {
        if (calcOp && calcPrev) {
          try { calcVal = String(eval(`${calcPrev}${calcOp}${calcVal}`)); calcOp = null; calcPrev = ''; }
          catch { calcVal = 'Error'; }
        }
      } else {
        if (calcVal === '0' && v !== '.') calcVal = v;
        else if (v === '.' && calcVal.includes('.')) {}
        else calcVal += v;
      }
      document.getElementById('calcDisplay').textContent = calcVal;
      document.getElementById('calcPrev').textContent = calcOp ? `${calcPrev} ${calcOp}` : '';
    });
  });

  // Browser
  const brUrl = document.getElementById('brUrl');
  const brFrame = document.getElementById('brFrame');
  document.getElementById('brGo').addEventListener('click', () => {
    let url = brUrl.value.trim();
    if (!url) return;
    if (!url.startsWith('http')) url = 'https://' + url;
    brFrame.src = url;
  });
  document.getElementById('brBack2').addEventListener('click', () => brFrame.contentWindow?.history?.back?.());
  document.getElementById('brFwd').addEventListener('click', () => brFrame.contentWindow?.history?.forward?.());
  document.getElementById('brRefresh').addEventListener('click', () => brFrame.src = brFrame.src);
  brUrl.addEventListener('keydown', e => { if (e.key === 'Enter') document.getElementById('brGo').click(); });

  // Phone
  let dialed = '';
  document.querySelectorAll('.dial-btn').forEach(btn => {
    btn.addEventListener('click', () => {
      dialed += btn.dataset.d;
      document.getElementById('phoneDisplay').textContent = dialed;
    });
  });
  document.getElementById('callBtn').addEventListener('click', () => {
    if (dialed) {
      const name = state.contacts.find(c => c.number === dialed)?.name || dialed;
      state.callLog.unshift({ name, number: dialed, dir: '&#8593;', time: 'Just now' });
      dialed = '';
      document.getElementById('phoneDisplay').textContent = '';
      renderCallLog();
      showToast(`Calling ${name}...`);
    }
  });

  // Messages
  document.getElementById('msgList').addEventListener('click', e => {
    const item = e.target.closest('.msg-item');
    if (!item) return;
    const cid = parseInt(item.dataset.cid);
    const conv = state.conversations.find(c => c.id === cid);
    if (!conv) return;
    document.getElementById('msgListView').style.display = 'none';
    document.getElementById('msgBack').style.display = 'flex';
    document.getElementById('chatView').style.display = 'flex';
    document.getElementById('msgTitle').textContent = conv.name;
    renderChatMessages(conv);
    
    function renderChatMessages(conv) {
      const el = document.getElementById('chatMessages');
      el.innerHTML = conv.messages.map(m =>
        `<div class="chat-bubble ${m.from === 'me' ? 'sent' : 'received'}">${m.text}</div>`
      ).join('');
      el.scrollTop = el.scrollHeight;
    }
    
    const sendHandler = () => {
      const input = document.getElementById('chatInput');
      const text = input.value.trim();
      if (!text) return;
      conv.messages.push({ from: 'me', text });
      input.value = '';
      renderChatMessages(conv);
      setTimeout(() => {
        conv.messages.push({ from: 'them', text: 'Got it! Thanks for letting me know.' });
        renderChatMessages(conv);
      }, 2000);
    };
    
    document.getElementById('chatSend').onclick = sendHandler;
    document.getElementById('chatInput').onkeydown = e => { if (e.key === 'Enter') sendHandler(); };
  });

  // Camera
  document.getElementById('camShutter').addEventListener('click', () => {
    const flash = document.createElement('div');
    flash.style.cssText = 'position:absolute;inset:0;background:#fff;z-index:9999;opacity:0.9;pointer-events:none;border-radius:40px;transition:opacity 0.3s;';
    document.getElementById('app-camera').appendChild(flash);
    setTimeout(() => { flash.style.opacity = '0'; setTimeout(() => flash.remove(), 300); }, 80);
  });
  document.querySelectorAll('.cam-mode-btn').forEach(btn => {
    btn.addEventListener('click', () => {
      document.querySelectorAll('.cam-mode-btn').forEach(b => b.classList.remove('active'));
      btn.classList.add('active');
    });
  });

  // Clock Tabs
  document.querySelectorAll('.clock-tab').forEach(tab => {
    tab.addEventListener('click', () => {
      document.querySelectorAll('.clock-tab').forEach(t => t.classList.remove('active'));
      tab.classList.add('active');
      document.querySelectorAll('.clock-section').forEach(s => s.classList.remove('active'));
      document.getElementById('tab-' + tab.dataset.tab).classList.add('active');
    });
  });

  // Stopwatch
  document.getElementById('swStart').addEventListener('click', () => {
    if (state.stopwatchRunning) {
      clearInterval(state.stopwatchInterval);
      state.stopwatchRunning = false;
      document.getElementById('swStart').textContent = 'Start';
      document.getElementById('swStart').classList.add('primary');
    } else {
      state.stopwatchRunning = true;
      document.getElementById('swStart').textContent = 'Stop';
      document.getElementById('swStart').classList.remove('primary');
      const start = Date.now() - state.stopwatchElapsed;
      state.stopwatchInterval = setInterval(() => {
        state.stopwatchElapsed = Date.now() - start;
        updateStopwatchDisplay();
      }, 10);
    }
  });
  document.getElementById('swLap').addEventListener('click', () => {
    if (!state.stopwatchRunning) { state.stopwatchElapsed = 0; updateStopwatchDisplay(); document.getElementById('swLaps').innerHTML = ''; return; }
    const lap = formatTime(state.stopwatchElapsed);
    const div = document.createElement('div');
    div.style.cssText = 'display:flex;justify-content:space-between;padding:8px 0;border-bottom:1px solid rgba(255,255,255,0.05);font-size:14px;';
    div.innerHTML = `<span style="color:var(--text-secondary)">Lap ${document.getElementById('swLaps').children.length + 1}</span><span style="color:#fff">${lap}</span>`;
    document.getElementById('swLaps').insertBefore(div, document.getElementById('swLaps').firstChild);
  });
  function updateStopwatchDisplay() {
    document.getElementById('swDisplay').textContent = formatTime(state.stopwatchElapsed);
  }
  function formatTime(ms) {
    const m = Math.floor(ms / 60000);
    const s = Math.floor((ms % 60000) / 1000);
    const cs = Math.floor((ms % 1000) / 10);
    return `${String(m).padStart(2,'0')}:${String(s).padStart(2,'0')}.${String(cs).padStart(2,'0')}`;
  }

  // Timer
  document.getElementById('tmStart').addEventListener('click', () => {
    if (state.timerRunning) {
      clearInterval(state.timerInterval);
      state.timerRunning = false;
      document.getElementById('tmStart').textContent = 'Start';
      document.getElementById('tmStart').classList.add('primary');
    } else {
      const mins = parseInt(document.getElementById('tmMin').value) || 0;
      const secs = parseInt(document.getElementById('tmSec').value) || 0;
      state.timerRemaining = mins * 60 + secs;
      if (state.timerRemaining <= 0) return;
      document.getElementById('timerInputs').style.display = 'none';
      document.getElementById('timerDisplay').style.display = 'block';
      state.timerRunning = true;
      document.getElementById('tmStart').textContent = 'Pause';
      document.getElementById('tmStart').classList.remove('primary');
      updateTimerDisplay();
      state.timerInterval = setInterval(() => {
        state.timerRemaining--;
        updateTimerDisplay();
        if (state.timerRemaining <= 0) {
          clearInterval(state.timerInterval);
          state.timerRunning = false;
          document.getElementById('tmStart').textContent = 'Start';
          document.getElementById('tmStart').classList.add('primary');
          document.getElementById('timerDisplay').textContent = 'Done!';
        }
      }, 1000);
    }
  });
  document.getElementById('tmCancel').addEventListener('click', () => {
    clearInterval(state.timerInterval);
    state.timerRunning = false;
    document.getElementById('timerInputs').style.display = 'flex';
    document.getElementById('timerDisplay').style.display = 'none';
    document.getElementById('tmStart').textContent = 'Start';
    document.getElementById('tmStart').classList.add('primary');
  });
  function updateTimerDisplay() {
    const m = Math.floor(state.timerRemaining / 60);
    const s = state.timerRemaining % 60;
    document.getElementById('timerDisplay').textContent = `${String(m).padStart(2,'0')}:${String(s).padStart(2,'0')}`;
  }

  // Settings
  document.querySelectorAll('.settings-toggle').forEach(tog => {
    tog.addEventListener('click', () => {
      tog.classList.toggle('on');
      const key = tog.dataset.s;
      if (key) state.settings[key] = tog.classList.contains('on');
      if (key === 'wifi') document.getElementById('stWifiSub').textContent = state.settings.wifi ? 'Connected' : 'Off';
      if (key === 'bluetooth') document.getElementById('stBtSub').textContent = state.settings.bluetooth ? 'On' : 'Off';
    });
  });
  document.getElementById('aboutItem').addEventListener('click', () => {
    const aboutDiv = document.createElement('div');
    aboutDiv.className = 'app-window active';
    aboutDiv.id = 'app-about';
    aboutDiv.innerHTML = `<div class="app-header"><button class="app-header-btn" id="aboutBack">&#8592;</button><div class="app-header-title">About Phone</div></div><div class="app-body">${createAboutHTML()}</div>`;
    document.getElementById('appWindows').appendChild(aboutDiv);
    document.getElementById('aboutBack').addEventListener('click', () => { aboutDiv.remove(); });
  });

  // Contacts
  document.getElementById('contactsAdd').addEventListener('click', () => {
    document.getElementById('contactsListView').style.display = 'none';
    document.getElementById('contactsAddView').style.display = 'block';
    document.getElementById('contactsAdd').style.display = 'none';
    document.getElementById('contactsBack').style.display = 'flex';
    document.getElementById('contactsTitle').textContent = 'New Contact';
  });
  document.getElementById('contactsBack').addEventListener('click', () => {
    document.getElementById('contactsListView').style.display = 'block';
    document.getElementById('contactsAddView').style.display = 'none';
    document.getElementById('contactsAdd').style.display = 'flex';
    document.getElementById('contactsBack').style.display = 'none';
    document.getElementById('contactsTitle').textContent = 'Contacts';
    renderContacts();
  });
  document.getElementById('saveContact').addEventListener('click', () => {
    const name = document.getElementById('contactName').value.trim();
    const number = document.getElementById('contactNumber').value.trim();
    if (!name || !number) return showToast('Please fill in name and number');
    const colors = ['#ff6b6b','#4ecdc4','#45b7d1','#f7dc6f','#bb8fce','#85c1e9','#f8c471','#82e0aa'];
    state.contacts.push({ id: Date.now(), name, number, color: colors[Math.floor(Math.random()*colors.length)] });
    document.getElementById('contactName').value = '';
    document.getElementById('contactNumber').value = '';
    document.getElementById('contactEmail').value = '';
    document.getElementById('contactsBack').click();
    showToast('Contact saved!');
  });

  // Alarms
  document.getElementById('addAlarm').addEventListener('click', () => {
    state.alarms.push({ time: '09:00', label: 'New Alarm', on: true });
    renderAlarms();
  });
  renderAlarms();
}

// ===================== INIT =====================
function init() {
  // Clock
  updateClock();
  setInterval(updateClock, 1000);
  
  // Battery
  if (navigator.getBattery) {
    navigator.getBattery().then(bat => {
      const pct = Math.round(bat.level * 100);
      document.getElementById('batteryFill').style.width = pct + '%';
      document.getElementById('batteryText').textContent = pct + '%';
      bat.addEventListener('levelchange', () => {
        const p = Math.round(bat.level * 100);
        document.getElementById('batteryFill').style.width = p + '%';
        document.getElementById('batteryText').textContent = p + '%';
      });
    });
  }
  
  // Notifications
  state.notifications = [
    { title: 'Gmail', text: 'New email from Team', icon: '&#128231;', color: '#ea4335' },
    { title: 'Calendar', text: 'Meeting in 30 min', icon: '&#128197;', color: '#4285f4' },
    { title: 'APK Sideloader', text: 'Tap the purple APK button to sideload apps!', icon: '&#128230;', color: '#5856d6' },
  ];
  renderNotifications();
  renderLockNotifs();
  
  // Home
  renderHomeApps();
  renderDrawerApps();
  renderCallLog();
  renderMessages();
  renderGallery();
  renderContacts();
  
  // Events
  setupEvents();
  setupAppScripts();
  
  // APK Sideload
  initSideloadUI();
}

init();""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
