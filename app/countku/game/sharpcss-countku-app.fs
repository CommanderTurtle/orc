module ConvertedFiles.CountkuAppCss

let file = """:root {
  --ck-safe-top: env(safe-area-inset-top, 0px);
  --ck-safe-right: env(safe-area-inset-right, 0px);
  --ck-safe-bottom: env(safe-area-inset-bottom, 0px);
  --ck-safe-left: env(safe-area-inset-left, 0px);
  --ck-ink: #090817;
  --ck-night: #12132c;
  --ck-indigo: #252553;
  --ck-sakura: #ff83b8;
  --ck-sakura-soft: #ffd0e3;
  --ck-moon: #d9e3ff;
  --ck-mint: #8ff0cd;
  --ck-gold: #ffd57a;
  --ck-danger: #ff768a;
  --ck-panel: rgba(17, 17, 41, 0.94);
  --ck-line: rgba(211, 220, 255, 0.17);
  --ck-world-glow-a: rgba(113, 127, 230, 0.18);
  --ck-world-glow-b: rgba(255, 107, 161, 0.12);
  --ck-world-top: #0b0b1c;
  --ck-world-middle: #171830;
  --ck-world-bottom: #221832;
  --ck-tree-filter: saturate(0.75) hue-rotate(12deg) contrast(1.12);
}

html {
  min-height: 100%;
  background: var(--ck-ink);
}

body {
  min-height: 100svh;
}

@supports (min-height: 100dvh) {
  body {
    min-height: 100dvh;
  }
}

button,
input {
  -webkit-tap-highlight-color: transparent;
}

button:focus-visible,
input:focus-visible,
a:focus-visible {
  outline: 3px solid var(--ck-moon);
  outline-offset: 3px;
}

body.mode-countku {
  overflow-x: hidden;
  overflow-y: auto;
  min-height: 100svh;
  background:
    radial-gradient(circle at 70% 8%, var(--ck-world-glow-a), transparent 28%),
    radial-gradient(circle at 20% 70%, var(--ck-world-glow-b), transparent 36%),
    linear-gradient(
      180deg,
      var(--ck-world-top) 0%,
      var(--ck-world-middle) 48%,
      var(--ck-world-bottom) 100%
    );
  color: #f8f4ff;
  transition: background 820ms ease, color 420ms ease;
}

@supports (min-height: 100dvh) {
  body.mode-countku {
    min-height: 100dvh;
  }
}

body.mode-countku::before,
body.mode-countku::after {
  content: "";
  position: fixed;
  inset: 0;
  pointer-events: none;
}

body.mode-countku::before {
  z-index: 0;
  opacity: 0.42;
  background:
    linear-gradient(125deg, transparent 0 48%, rgba(255, 255, 255, 0.028) 48.2% 48.5%, transparent 48.7%),
    linear-gradient(55deg, transparent 0 62%, rgba(255, 255, 255, 0.018) 62.2% 62.5%, transparent 62.7%);
  background-size: 160px 160px;
  mask-image: linear-gradient(to bottom, #000, transparent 82%);
}

body.mode-countku::after {
  z-index: 2;
  background:
    linear-gradient(to bottom, rgba(6, 7, 18, 0.04), rgba(6, 7, 18, 0.45)),
    repeating-linear-gradient(
      to bottom,
      transparent 0,
      transparent 3px,
      rgba(255, 255, 255, 0.012) 4px
    );
  mix-blend-mode: screen;
}

body.mode-countku .bg-tree {
  right: max(-140px, calc(50vw - 760px));
  bottom: -90px;
  width: min(760px, 72vw);
  opacity: 0.25;
  filter: var(--ck-tree-filter);
  transition: opacity 700ms ease, filter 700ms ease;
}

body.mode-countku.stage-novice {
  --ck-tree-filter: saturate(0.75) hue-rotate(12deg) contrast(1.12);
}

body.mode-countku.stage-apprentice {
  --ck-sakura: #8be4bd;
  --ck-sakura-soft: #d6f8e8;
  --ck-gold: #f1df8b;
  --ck-world-glow-a: rgba(84, 194, 156, 0.19);
  --ck-world-glow-b: rgba(255, 194, 139, 0.1);
  --ck-world-top: #081614;
  --ck-world-middle: #122921;
  --ck-world-bottom: #172d29;
  --ck-tree-filter: sepia(0.24) hue-rotate(78deg) saturate(0.88);
}

body.mode-countku.stage-verse {
  --ck-sakura: #ff8fc0;
  --ck-sakura-soft: #ffe0ed;
  --ck-gold: #ffe095;
  --ck-world-glow-a: rgba(199, 137, 255, 0.19);
  --ck-world-glow-b: rgba(255, 121, 174, 0.17);
  --ck-world-top: #150b21;
  --ck-world-middle: #2a1637;
  --ck-world-bottom: #381b34;
  --ck-tree-filter: saturate(1.05) hue-rotate(344deg) contrast(1.08);
}

body.mode-countku.stage-adept {
  --ck-sakura: #ff9e72;
  --ck-sakura-soft: #ffe3ca;
  --ck-gold: #ffd17a;
  --ck-world-glow-a: rgba(255, 168, 91, 0.2);
  --ck-world-glow-b: rgba(205, 82, 121, 0.14);
  --ck-world-top: #1b0d16;
  --ck-world-middle: #351c26;
  --ck-world-bottom: #42251d;
  --ck-tree-filter: sepia(0.5) hue-rotate(328deg) saturate(1.28);
}

body.mode-countku.stage-moon {
  --ck-sakura: #a8baff;
  --ck-sakura-soft: #e0e7ff;
  --ck-gold: #c5ddff;
  --ck-world-glow-a: rgba(96, 132, 255, 0.21);
  --ck-world-glow-b: rgba(139, 211, 255, 0.1);
  --ck-world-top: #060b1e;
  --ck-world-middle: #101c3e;
  --ck-world-bottom: #18294a;
  --ck-tree-filter: grayscale(0.22) hue-rotate(48deg) saturate(0.78);
}

body.mode-countku.stage-sage {
  --ck-sakura: #b7f1d8;
  --ck-sakura-soft: #e8fff6;
  --ck-gold: #ffe6a1;
  --ck-world-glow-a: rgba(160, 235, 210, 0.18);
  --ck-world-glow-b: rgba(255, 216, 132, 0.14);
  --ck-world-top: #091615;
  --ck-world-middle: #122b2b;
  --ck-world-bottom: #253429;
  --ck-tree-filter: sepia(0.16) hue-rotate(91deg) saturate(0.72) brightness(1.08);
}

body.mode-countku.trail-moon-ink {
  --ck-sakura: #9db4ff !important;
  --ck-sakura-soft: #dce5ff !important;
  --ck-gold: #bcd7ff !important;
}

body.mode-countku.trail-bamboo-dawn {
  --ck-sakura: #7bd7ad !important;
  --ck-sakura-soft: #d6f8e8 !important;
  --ck-gold: #f1df8b !important;
}

body.mode-countku.trail-bamboo-dawn .bg-tree {
  filter: sepia(0.22) hue-rotate(78deg) saturate(0.8);
}

body.mode-countku.trail-moon-ink .bg-tree {
  filter: grayscale(0.25) hue-rotate(45deg) saturate(0.7);
}

body.mode-countku.trail-maple-ember {
  --ck-sakura: #ff9c69 !important;
  --ck-sakura-soft: #ffe0c2 !important;
  --ck-gold: #ffd084 !important;
}

body.mode-countku.trail-maple-ember .bg-tree {
  filter: sepia(0.55) hue-rotate(330deg) saturate(1.35);
}

body.mode-countku.trail-lantern-moss {
  --ck-sakura: #9ccc84 !important;
  --ck-sakura-soft: #e5f3cf !important;
  --ck-gold: #ffc86c !important;
  --ck-world-glow-a: rgba(89, 156, 106, 0.2) !important;
  --ck-world-glow-b: rgba(255, 174, 76, 0.12) !important;
  --ck-world-top: #07120d !important;
  --ck-world-middle: #13251a !important;
  --ck-world-bottom: #2d2a18 !important;
}

body.mode-countku.trail-lantern-moss .bg-tree {
  filter: sepia(0.34) hue-rotate(67deg) saturate(0.92);
}

body.mode-countku.trail-sumi-gold {
  --ck-sakura: #dbc381 !important;
  --ck-sakura-soft: #fff0bf !important;
  --ck-gold: #f4c95d !important;
  --ck-world-glow-a: rgba(223, 190, 94, 0.16) !important;
  --ck-world-glow-b: rgba(128, 114, 173, 0.09) !important;
  --ck-world-top: #080909 !important;
  --ck-world-middle: #151714 !important;
  --ck-world-bottom: #24231d !important;
}

body.mode-countku.trail-sumi-gold .bg-tree {
  filter: grayscale(0.75) sepia(0.36) saturate(0.66) contrast(1.12);
}

body.mode-countku.avatar-scholar-band #ninjaImg {
  filter: drop-shadow(0 -7px 0 rgba(207, 215, 255, 0.72));
}

body.mode-countku.avatar-moon-halo #ninjaImg {
  filter:
    drop-shadow(0 0 7px rgba(188, 215, 255, 0.8))
    drop-shadow(0 0 18px rgba(114, 152, 255, 0.42));
}

body.mode-countku .ninja-area {
  position: relative;
  isolation: isolate;
}

body.mode-countku .ninja-area #ninja {
  position: absolute;
  z-index: 3;
}

body.mode-countku .ninja-area #ninjaImg {
  position: relative;
}

body.mode-countku .ninja-area::before,
body.mode-countku .ninja-area::after {
  content: "";
  position: absolute;
  z-index: 2;
  pointer-events: none;
  opacity: 0;
}

body.mode-countku.effect-petal-glow .ninja-area::before {
  inset: 2% 23% 8%;
  opacity: 0.92;
  border-radius: 50%;
  background:
    radial-gradient(circle, transparent 28%, var(--ck-sakura) 62%, transparent 73%);
  filter: blur(8px);
  animation: ck-aura-breathe 2.8s ease-in-out infinite;
}

body.mode-countku.effect-smoke .ninja-area::before {
  right: 19%;
  bottom: 6%;
  left: 19%;
  height: 82%;
  opacity: 0.72;
  background:
    radial-gradient(circle at 22% 82%, rgba(214, 220, 230, 0.5) 0 8%, transparent 21%),
    radial-gradient(circle at 62% 64%, rgba(172, 181, 194, 0.43) 0 10%, transparent 24%),
    radial-gradient(circle at 42% 36%, rgba(225, 228, 234, 0.32) 0 8%, transparent 22%);
  filter: blur(5px);
  animation: ck-smoke-rise 3.8s ease-in-out infinite;
}

body.mode-countku.effect-sword .ninja-area::after {
  top: 2%;
  left: 53.5%;
  width: 6px;
  height: 60%;
  opacity: 1;
  z-index: 4;
  border: 1px solid rgba(255, 255, 255, 0.72);
  border-radius: 70% 70% 2px 2px;
  background:
    linear-gradient(
      to bottom,
      #f9fbff 0 4%,
      #667085 5%,
      #f9fbff 44%,
      #8e99aa 73%,
      #f0c765 74% 82%,
      #5a302d 83% 100%
    );
  box-shadow:
    0 0 0 1px rgba(26, 31, 43, 0.45),
    0 0 10px rgba(220, 233, 255, 0.52);
  clip-path: polygon(50% 0, 100% 6%, 100% 74%, 86% 74%, 86% 83%, 70% 83%, 70% 100%, 30% 100%, 30% 83%, 14% 83%, 14% 74%, 0 74%, 0 6%);
  transform: rotate(34deg);
  transform-origin: 50% 100%;
}

body.mode-countku.effect-fire .ninja-area::before {
  inset: -8% 20% 3%;
  opacity: 0.92;
  background:
    conic-gradient(
      from 212deg at 50% 78%,
      transparent,
      #ff552d 7%,
      #ffd66f 13%,
      transparent 21%,
      #ff3b27 34%,
      #ffcf67 42%,
      transparent 51%
    );
  filter: blur(4px);
  animation: ck-fire-aura 720ms steps(4, end) infinite;
}

body.mode-countku.effect-ascendant .ninja-area::before {
  inset: -12% 17% -4%;
  opacity: 0.94;
  background:
    repeating-conic-gradient(
      from 0deg,
      transparent 0 8deg,
      rgba(255, 243, 154, 0.88) 9deg 10deg,
      transparent 11deg 25deg
    );
  filter: drop-shadow(0 0 9px #fff3a1);
  animation: ck-charge-spin 2.1s linear infinite;
}

body.mode-countku.effect-ascendant .ninja-area::after {
  inset: 4% 26% 8%;
  opacity: 0.74;
  border-radius: 48%;
  background: radial-gradient(circle, #fffbe7 0 9%, #ffe769 35%, transparent 68%);
  filter: blur(8px);
  animation: ck-aura-breathe 520ms ease-in-out infinite alternate;
}

body.mode-countku.effect-disco .ninja-area #ninjaImg {
  animation: ck-disco-ninja 2.4s linear infinite;
}

body.mode-countku.effect-disco .ninja-area::before {
  inset: 4% 21% 7%;
  opacity: 0.76;
  border-radius: 50%;
  background:
    conic-gradient(#ff4f8b, #ffd45b, #56e3b3, #60a7ff, #d66bff, #ff4f8b);
  filter: blur(12px);
  animation: ck-charge-spin 2.7s linear infinite;
}

body.mode-countku.effect-glitch .ninja-area #ninjaImg {
  animation: ck-glitch-ninja 1.4s steps(2, end) infinite;
}

body.mode-countku.effect-glitch .ninja-area::before {
  inset: 12% 24% 9%;
  opacity: 0.68;
  background:
    repeating-linear-gradient(
      to bottom,
      transparent 0 7px,
      rgba(74, 255, 239, 0.65) 8px 9px,
      transparent 10px 16px,
      rgba(255, 73, 167, 0.58) 17px 18px
    );
  mix-blend-mode: screen;
  animation: ck-glitch-scan 820ms steps(5, end) infinite;
}

body.mode-countku.effect-matrix .ninja-area::after {
  content: "01\A 10\A 句\A 001\A 10";
  top: -18%;
  left: 26%;
  width: 52%;
  height: 126%;
  overflow: hidden;
  opacity: 0.74;
  color: #68ff92;
  font: 1.15rem/1.25 "VT323", monospace;
  text-align: center;
  white-space: pre;
  text-shadow: 0 0 7px #15d85a;
  mask-image: linear-gradient(transparent, #000 18%, #000 76%, transparent);
  animation: ck-matrix-fall 2s linear infinite;
}

body.mode-countku.effect-cowboy .ninja-area::after {
  content: "🐎";
  right: auto;
  bottom: 15%;
  left: 61%;
  opacity: 1;
  font-size: clamp(1.8rem, 5vh, 2.8rem);
  filter: drop-shadow(0 8px 8px rgba(3, 4, 12, 0.38));
  transform: scaleX(-1);
  animation: ck-horse-bob 1.1s steps(2, end) infinite;
}

body.mode-countku.effect-supernova .ninja-area::before {
  inset: -28% 5% -18%;
  opacity: 0.96;
  border-radius: 50%;
  background:
    radial-gradient(circle, #fff 0 3%, #dff6ff 4% 8%, #8fbfff 14%, #845cff 28%, #ff6a9f 42%, transparent 68%);
  filter: blur(4px) saturate(1.35);
  animation: ck-supernova 2.8s ease-in-out infinite;
}

body.mode-countku.effect-supernova .ninja-area::after {
  inset: -35% -6% -25%;
  opacity: 0.82;
  background:
    repeating-conic-gradient(
      transparent 0 13deg,
      rgba(223, 246, 255, 0.85) 14deg 15deg,
      transparent 16deg 31deg
    );
  animation: ck-charge-spin 8s linear infinite;
}

body.mode-countku .game-container {
  justify-content: flex-start;
  min-height: 100svh;
  padding:
    calc(72px + var(--ck-safe-top))
    calc(22px + var(--ck-safe-right))
    calc(104px + var(--ck-safe-bottom))
    calc(22px + var(--ck-safe-left));
  isolation: isolate;
  animation: ck-world-enter 700ms cubic-bezier(0.2, 0.8, 0.2, 1) both;
}

@supports (min-height: 100dvh) {
  body.mode-countku .game-container {
    min-height: 100dvh;
  }
}

body.mode-countku .game-container > * {
  position: relative;
  z-index: 5;
}

body.mode-countku .mode-selector {
  margin: 0 0 14px;
  padding: 4px;
  border: 1px solid var(--ck-line);
  border-radius: 16px;
  background: rgba(8, 9, 24, 0.58);
  box-shadow: 0 16px 40px rgba(2, 3, 12, 0.22);
  backdrop-filter: blur(16px);
}

body.mode-countku .mode-btn {
  min-height: 48px;
  border: 1px solid transparent;
  color: rgba(225, 229, 255, 0.66);
  background: transparent;
}

body.mode-countku .mode-btn.active {
  border-color: rgba(255, 255, 255, 0.14);
  color: #fff;
  background:
    linear-gradient(135deg, rgba(255, 131, 184, 0.96), rgba(126, 111, 219, 0.96));
  box-shadow:
    0 10px 26px rgba(62, 50, 135, 0.35),
    inset 0 1px rgba(255, 255, 255, 0.35);
}

body.mode-countku .game-title {
  margin: 2px 0 14px;
  color: var(--ck-sakura-soft);
  font-size: clamp(1.25rem, 2.8vw, 2rem);
  letter-spacing: 0.06em;
  text-shadow:
    3px 3px 0 rgba(3, 4, 15, 0.65),
    0 0 26px color-mix(in srgb, var(--ck-sakura) 38%, transparent);
}

.ck-objective {
  display: inline-flex;
  align-items: center;
  gap: 8px;
  min-height: 34px;
  margin: -4px 0 10px;
  padding: 6px 10px;
  border: 1px solid rgba(143, 240, 205, 0.23);
  border-radius: 999px;
  color: rgba(232, 235, 255, 0.7);
  background: rgba(12, 17, 36, 0.7);
  font: 0.9rem "VT323", monospace;
  cursor: pointer;
}

.ck-objective[hidden] {
  display: none;
}

.ck-objective span {
  color: var(--ck-mint);
  text-transform: uppercase;
}

.ck-objective strong {
  color: #f7f5ff;
  font-weight: 400;
}

.ck-objective em {
  color: var(--ck-gold);
  font-style: normal;
}

body.mode-countku .number-display {
  margin-bottom: 14px;
}

body.mode-countku .number-display .label {
  color: rgba(222, 227, 255, 0.58);
  font-size: 0.96rem;
  letter-spacing: 0.05em;
  text-transform: uppercase;
}

body.mode-countku .number-display .current-number {
  color: var(--ck-sakura-soft);
  font-size: clamp(4.2rem, 11vh, 7rem);
}

body.mode-countku .number-display .next-number {
  color: var(--ck-mint);
  font-size: 1rem;
}

body.mode-countku .ninja-area {
  height: clamp(120px, 19vh, 170px);
  margin-bottom: 12px;
}

body.mode-countku .target-platform {
  background: linear-gradient(90deg, var(--ck-indigo), var(--ck-sakura));
  box-shadow: 0 0 22px color-mix(in srgb, var(--ck-sakura) 45%, transparent);
}

body.mode-countku .target-number {
  color: var(--ck-sakura-soft);
}

body.mode-countku .chat-bubble {
  max-width: min(320px, 76vw);
  color: #171327;
  background: linear-gradient(145deg, #fff5fa, var(--ck-sakura-soft));
  box-shadow:
    0 18px 45px rgba(3, 4, 15, 0.32),
    inset 0 1px 0 #fff;
}

body.mode-countku .chat-bubble::after {
  border-top-color: var(--ck-sakura-soft);
}

body.mode-countku #gameForm {
  width: min(100%, 620px);
}

body.mode-countku .input-wrapper {
  max-width: 620px;
}

body.mode-countku .game-input {
  min-height: 58px;
  max-width: 620px;
  padding: 15px 88px 15px 20px;
  border: 1px solid rgba(179, 188, 255, 0.3);
  border-radius: 18px;
  background: rgba(8, 9, 23, 0.88);
  color: #fff8fd;
  font-size: max(1.12rem, 16px);
  line-height: 1.35;
  box-shadow:
    0 22px 60px rgba(3, 4, 14, 0.33),
    inset 0 0 0 1px rgba(255, 255, 255, 0.035);
  scroll-margin-bottom: 42vh;
}

body.mode-countku .game-input::placeholder {
  color: rgba(218, 222, 250, 0.42);
}

body.mode-countku .game-input:focus {
  border-color: var(--ck-sakura);
  box-shadow:
    0 0 0 3px color-mix(in srgb, var(--ck-sakura) 26%, transparent),
    0 22px 60px rgba(3, 4, 14, 0.4);
}

body.mode-countku .go-btn {
  min-width: 66px;
  min-height: 42px;
  border-radius: 12px;
  color: #111126;
  background: linear-gradient(135deg, var(--ck-gold), var(--ck-sakura-soft));
  box-shadow: 0 10px 26px color-mix(in srgb, var(--ck-sakura) 24%, transparent);
}

body.mode-countku .input-hint {
  color: rgba(218, 222, 250, 0.5);
}

body.mode-countku #haikuDisplay {
  border-color: rgba(143, 240, 205, 0.22) !important;
  background: rgba(10, 12, 30, 0.82) !important;
  box-shadow: 0 18px 50px rgba(2, 3, 12, 0.25);
  backdrop-filter: blur(16px);
}

body.mode-countku #debugConsole:not(.ck-open) {
  display: none !important;
}

.ck-lens-button {
  display: none;
  min-height: 34px;
  margin: 8px auto 0;
  padding: 6px 12px;
  border: 1px solid rgba(196, 181, 253, 0.28);
  border-radius: 999px;
  color: #d9d1ff;
  background: rgba(75, 57, 117, 0.24);
  font: 0.92rem "VT323", monospace;
  cursor: pointer;
}

body.mode-countku #haikuDisplay[style*="display: block"] .ck-lens-button,
body.mode-countku #haikuDisplay[style*="display:block"] .ck-lens-button {
  display: inline-flex;
}

body.mode-countku #streakIndicator {
  display: none !important;
}

body.mode-countku .dashboard-overlay {
  z-index: 150;
}

.ck-app[hidden] {
  display: none;
}

.ck-app {
  position: relative;
  z-index: 70;
  font-family: "VT323", monospace;
}

.ck-hud {
  position: fixed;
  top: calc(14px + var(--ck-safe-top));
  right: calc(14px + var(--ck-safe-right));
  left: calc(68px + var(--ck-safe-left));
  z-index: 82;
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 10px;
  pointer-events: none;
}

.ck-hud__identity,
.ck-hud__wallet {
  display: flex;
  align-items: center;
  min-height: 44px;
  border: 1px solid var(--ck-line);
  border-radius: 14px;
  background: rgba(8, 9, 24, 0.74);
  box-shadow: 0 12px 36px rgba(1, 2, 10, 0.22);
  backdrop-filter: blur(16px);
  pointer-events: auto;
}

.ck-hud__identity {
  gap: 10px;
  padding: 7px 12px;
}

.ck-hud__mark {
  display: grid;
  width: 30px;
  height: 30px;
  place-items: center;
  border-radius: 9px;
  color: #101124;
  background: linear-gradient(135deg, var(--ck-mint), var(--ck-moon));
  font-weight: 700;
}

.ck-hud__copy {
  display: grid;
  line-height: 1.05;
}

.ck-hud__copy strong {
  color: #f6f4ff;
  font-size: 1rem;
}

.ck-hud__copy span {
  color: rgba(222, 227, 255, 0.55);
  font-size: 0.76rem;
}

.ck-hud__wallet {
  gap: 8px;
  padding: 8px 12px;
  color: var(--ck-gold);
  font-size: 1.1rem;
}

.ck-coin-sprite {
  width: 16px;
  height: 16px;
  background: url("assets/cc0-ninja-adventure/coin.gif") center / contain no-repeat;
  image-rendering: pixelated;
}

.ck-music-button {
  min-width: 34px;
  min-height: 34px;
  border-radius: 10px;
  font-size: 1rem;
}

.ck-music-button.is-playing {
  border-color: color-mix(in srgb, var(--ck-mint) 52%, transparent);
  color: var(--ck-mint);
  background: color-mix(in srgb, var(--ck-mint) 12%, transparent);
  box-shadow: 0 0 20px color-mix(in srgb, var(--ck-mint) 16%, transparent);
}

.ck-hud__streak {
  color: var(--ck-sakura-soft);
}

.ck-nav {
  position: fixed;
  right: 50%;
  bottom: calc(14px + var(--ck-safe-bottom));
  z-index: 84;
  display: flex;
  gap: 4px;
  padding: 5px;
  border: 1px solid var(--ck-line);
  border-radius: 18px;
  background: rgba(8, 9, 24, 0.88);
  box-shadow: 0 20px 50px rgba(1, 2, 10, 0.4);
  backdrop-filter: blur(20px);
  transform: translateX(50%);
}

.ck-nav button {
  min-width: 76px;
  min-height: 48px;
  padding: 7px 10px;
  border: 0;
  border-radius: 13px;
  color: rgba(226, 230, 255, 0.64);
  background: transparent;
  font: 0.98rem "VT323", monospace;
  cursor: pointer;
}

.ck-nav button span {
  display: block;
  font-size: 0.72rem;
  letter-spacing: 0.05em;
  text-transform: uppercase;
}

.ck-nav button:hover,
.ck-nav button[aria-pressed="true"] {
  color: #fff;
  background: linear-gradient(
    135deg,
    color-mix(in srgb, var(--ck-sakura) 26%, transparent),
    rgba(97, 91, 174, 0.26)
  );
}

.ck-panel {
  position: fixed;
  top: calc(72px + var(--ck-safe-top));
  right: calc(16px + var(--ck-safe-right));
  bottom: calc(80px + var(--ck-safe-bottom));
  z-index: 120;
  display: flex;
  width: min(390px, calc(100vw - 32px));
  flex-direction: column;
  overflow: hidden;
  border: 1px solid rgba(214, 220, 255, 0.2);
  border-radius: 22px;
  background: var(--ck-panel);
  box-shadow: 0 30px 90px rgba(1, 2, 10, 0.6);
  backdrop-filter: blur(22px);
  animation: ck-panel-in 240ms ease-out both;
}

.ck-panel[hidden] {
  display: none;
}

.ck-panel__header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 18px 18px 14px;
  border-bottom: 1px solid var(--ck-line);
}

.ck-panel__header h2 {
  color: var(--ck-sakura-soft);
  font: 1.2rem "Press Start 2P", cursive;
}

.ck-icon-button {
  display: inline-grid;
  min-width: 44px;
  min-height: 44px;
  place-items: center;
  border: 1px solid var(--ck-line);
  border-radius: 12px;
  color: #fff;
  background: rgba(255, 255, 255, 0.045);
  font: 1.25rem "VT323", monospace;
  cursor: pointer;
}

.ck-panel__body {
  flex: 1;
  overflow-y: auto;
  padding: 16px;
  overscroll-behavior: contain;
}

.ck-section-intro {
  margin-bottom: 14px;
  color: rgba(226, 230, 255, 0.65);
  font-size: 1rem;
  line-height: 1.35;
}

.ck-filter-row {
  display: flex;
  gap: 7px;
  margin: -2px 0 14px;
  padding-bottom: 4px;
  overflow-x: auto;
  scrollbar-width: none;
}

.ck-filter-row::-webkit-scrollbar {
  display: none;
}

.ck-filter {
  flex: 0 0 auto;
  min-height: 36px;
  padding: 7px 10px;
  border: 1px solid var(--ck-line);
  border-radius: 999px;
  color: rgba(231, 234, 255, 0.66);
  background: rgba(255, 255, 255, 0.035);
  font: 0.82rem "VT323", monospace;
  cursor: pointer;
}

.ck-filter[aria-pressed="true"] {
  border-color: color-mix(in srgb, var(--ck-sakura) 60%, transparent);
  color: #fff;
  background: color-mix(in srgb, var(--ck-sakura) 19%, transparent);
}

.ck-card-grid {
  display: grid;
  gap: 12px;
}

.ck-card {
  position: relative;
  overflow: hidden;
  padding: 15px;
  border: 1px solid var(--ck-line);
  border-radius: 16px;
  background: rgba(255, 255, 255, 0.035);
}

.ck-card[data-complete="true"] {
  border-color: rgba(143, 240, 205, 0.35);
  background: rgba(82, 180, 145, 0.07);
}

.ck-card[data-locked="true"] {
  opacity: 0.64;
}

.ck-card--daily {
  background:
    linear-gradient(135deg, rgba(143, 240, 205, 0.09), rgba(255, 131, 184, 0.055));
}

.ck-card--weekly {
  min-height: 172px;
  background:
    linear-gradient(135deg, rgba(255, 213, 122, 0.085), rgba(115, 112, 205, 0.07));
}

.ck-card--weekly > *:not(.ck-scroll-sprite) {
  position: relative;
  z-index: 1;
}

.ck-scroll-sprite {
  position: absolute;
  top: 12px;
  right: 12px;
  width: 24px;
  height: 24px;
  opacity: 0.72;
  background: url("assets/cc0-ninja-adventure/scroll.png") center / contain no-repeat;
  image-rendering: pixelated;
}

.ck-card__eyebrow {
  color: var(--ck-mint);
  font-size: 0.76rem;
  letter-spacing: 0.08em;
  text-transform: uppercase;
}

.ck-card h3 {
  margin: 4px 0 5px;
  color: #f8f5ff;
  font-size: 1.22rem;
}

.ck-card p {
  color: rgba(226, 230, 255, 0.64);
  line-height: 1.32;
}

.ck-card__footer {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 10px;
  margin-top: 12px;
}

.ck-reward {
  color: var(--ck-gold);
}

.ck-chip-row {
  display: flex;
  flex-wrap: wrap;
  gap: 6px;
  margin-top: 10px;
}

.ck-chip {
  display: inline-flex;
  padding: 5px 8px;
  border: 1px solid rgba(143, 240, 205, 0.25);
  border-radius: 999px;
  color: var(--ck-mint);
  background: rgba(143, 240, 205, 0.06);
  font-size: 0.82rem;
  text-transform: capitalize;
}

.ck-muted {
  color: rgba(226, 230, 255, 0.48);
}

.ck-progress {
  height: 7px;
  margin-top: 13px;
  overflow: hidden;
  border-radius: 999px;
  background: rgba(255, 255, 255, 0.08);
}

.ck-progress span {
  display: block;
  height: 100%;
  border-radius: inherit;
  background: linear-gradient(90deg, var(--ck-mint), var(--ck-sakura));
}

.ck-journey {
  margin-bottom: 14px;
  padding: 15px;
  border: 1px solid color-mix(in srgb, var(--ck-sakura) 24%, transparent);
  border-radius: 17px;
  background:
    radial-gradient(circle at 100% 0, color-mix(in srgb, var(--ck-sakura) 12%, transparent), transparent 45%),
    rgba(255, 255, 255, 0.03);
}

.ck-journey__header {
  display: flex;
  align-items: end;
  justify-content: space-between;
  gap: 14px;
}

.ck-journey__header span:first-child {
  display: grid;
  gap: 2px;
}

.ck-journey__header em,
.ck-journey__next {
  color: rgba(226, 230, 255, 0.5);
  font-size: 0.76rem;
  font-style: normal;
}

.ck-journey__header strong {
  color: var(--ck-sakura-soft);
  font-size: 1.1rem;
}

.ck-journey__next {
  max-width: 145px;
  text-align: right;
}

.ck-progress--journey {
  margin: 12px 0 15px;
}

.ck-stage-map {
  display: grid;
  gap: 7px;
  margin: 0;
  padding: 0;
  list-style: none;
}

.ck-stage-map li {
  display: grid;
  grid-template-columns: 24px minmax(0, 1fr);
  align-items: center;
  gap: 9px;
  min-height: 36px;
  padding: 6px 8px;
  border-radius: 10px;
  color: rgba(226, 230, 255, 0.4);
}

.ck-stage-map li[data-reached="true"] {
  color: rgba(239, 242, 255, 0.74);
}

.ck-stage-map li[data-current="true"] {
  color: #fff;
  background: color-mix(in srgb, var(--ck-sakura) 12%, transparent);
}

.ck-stage-map li > span:last-child {
  display: flex;
  align-items: baseline;
  justify-content: space-between;
  gap: 8px;
}

.ck-stage-map strong {
  font-size: 0.94rem;
}

.ck-stage-map em {
  color: currentColor;
  font-size: 0.7rem;
  font-style: normal;
  opacity: 0.68;
}

.ck-chest-sprite {
  display: inline-block;
  width: 16px;
  height: 16px;
  background:
    url("assets/cc0-ninja-adventure/treasure-chest.png")
    0 0 / 32px 16px no-repeat;
  image-rendering: pixelated;
}

.ck-chest-sprite.is-open {
  background-position: -16px 0;
}

.ck-action {
  min-height: 40px;
  padding: 8px 13px;
  border: 1px solid rgba(255, 255, 255, 0.1);
  border-radius: 11px;
  color: #121329;
  background: linear-gradient(135deg, var(--ck-gold), var(--ck-sakura-soft));
  font: 0.94rem "VT323", monospace;
  cursor: pointer;
}

.ck-action--secondary {
  color: #f4f2ff;
  background: rgba(255, 255, 255, 0.06);
}

.ck-action:disabled {
  cursor: default;
  opacity: 0.5;
}

.ck-store-actions {
  display: flex;
  flex-wrap: wrap;
  gap: 8px;
  margin-top: 12px;
}

.ck-panel-actions {
  display: flex;
  margin-top: 14px;
}

.ck-panel-actions .ck-action {
  flex: 1;
}

.ck-source {
  display: inline-flex;
  margin-top: 12px;
  color: var(--ck-mint);
  text-underline-offset: 3px;
}

.ck-source--original {
  color: rgba(226, 230, 255, 0.52);
  font-style: italic;
}

.ck-settings {
  display: grid;
  gap: 12px;
}

.ck-setting {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 18px;
  min-height: 58px;
  padding: 12px 14px;
  border: 1px solid var(--ck-line);
  border-radius: 14px;
  background: rgba(255, 255, 255, 0.035);
}

.ck-setting span {
  color: rgba(230, 233, 255, 0.72);
}

.ck-setting > span:first-child {
  display: grid;
  gap: 3px;
}

.ck-setting strong {
  color: rgba(243, 244, 255, 0.86);
  font-weight: 400;
}

.ck-setting small {
  color: rgba(226, 230, 255, 0.46);
  font-size: 0.72rem;
  line-height: 1.2;
}

.ck-setting--range {
  align-items: end;
  flex-direction: column;
}

.ck-setting--range > span:first-child {
  align-self: stretch;
}

.ck-setting--score {
  align-items: stretch;
  flex-direction: column;
}

.ck-score-library {
  display: grid;
  width: 100%;
  grid-template-columns: repeat(2, minmax(0, 1fr));
  gap: 7px;
}

.ck-score-choice {
  display: grid;
  gap: 3px;
  min-height: 56px;
  padding: 9px 10px;
  border: 1px solid var(--ck-line);
  border-radius: 10px;
  color: rgba(238, 241, 255, 0.72);
  background: rgba(255, 255, 255, 0.035);
  text-align: left;
  cursor: pointer;
}

.ck-score-choice[aria-pressed="true"] {
  border-color: color-mix(in srgb, var(--ck-mint) 52%, transparent);
  color: #fff;
  background: color-mix(in srgb, var(--ck-mint) 11%, transparent);
}

.ck-score-choice strong,
.ck-score-choice small {
  color: inherit;
}

.ck-advisor-library {
  margin-bottom: 16px;
}

.ck-subsection-header {
  display: flex;
  align-items: end;
  justify-content: space-between;
  gap: 12px;
  margin-bottom: 10px;
  color: rgba(228, 232, 255, 0.5);
  font-size: 0.76rem;
}

.ck-subsection-header > span:first-child {
  display: grid;
  gap: 2px;
}

.ck-subsection-header em {
  color: var(--ck-mint);
  font-style: normal;
  letter-spacing: 0.08em;
  text-transform: uppercase;
}

.ck-subsection-header strong {
  color: var(--ck-sakura-soft);
  font-size: 1rem;
  font-weight: 500;
}

.ck-haiku-lines {
  line-height: 1.55;
}

.ck-range-control {
  display: grid;
  width: 100%;
  grid-template-columns: minmax(0, 1fr) 40px;
  align-items: center;
  gap: 10px;
}

.ck-range-control input {
  width: 100%;
  accent-color: var(--ck-sakura);
  cursor: pointer;
}

.ck-range-control output {
  color: var(--ck-mint);
  font-size: 0.8rem;
  text-align: right;
}

.ck-toggle {
  position: relative;
  width: 48px;
  height: 28px;
  flex: 0 0 auto;
  border: 0;
  border-radius: 999px;
  background: rgba(255, 255, 255, 0.12);
  cursor: pointer;
}

.ck-toggle::after {
  content: "";
  position: absolute;
  top: 4px;
  left: 4px;
  width: 20px;
  height: 20px;
  border-radius: 50%;
  background: #e9e8f5;
  transition: transform 180ms ease, background 180ms ease;
}

.ck-toggle[aria-checked="true"] {
  background: color-mix(in srgb, var(--ck-mint) 54%, transparent);
}

.ck-toggle[aria-checked="true"]::after {
  background: #fff;
  transform: translateX(20px);
}

.ck-data-actions {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 8px;
  margin-top: 14px;
}

.ck-data-actions .ck-action:last-child {
  grid-column: 1 / -1;
}

.ck-toast {
  position: fixed;
  top: calc(72px + var(--ck-safe-top));
  left: 50%;
  z-index: 165;
  width: min(440px, calc(100vw - 28px));
  padding: 12px 16px;
  border: 1px solid rgba(143, 240, 205, 0.35);
  border-radius: 14px;
  color: #eafff7;
  background: rgba(19, 55, 50, 0.94);
  box-shadow: 0 18px 50px rgba(1, 2, 10, 0.45);
  text-align: center;
  transform: translate(-50%, -16px);
  animation: ck-toast-in 220ms ease-out both;
}

.ck-toast[hidden] {
  display: none;
}

.ck-stage-reveal {
  position: fixed;
  z-index: 190;
  display: grid;
  inset: 0;
  padding:
    calc(24px + var(--ck-safe-top))
    calc(20px + var(--ck-safe-right))
    calc(24px + var(--ck-safe-bottom))
    calc(20px + var(--ck-safe-left));
  place-items: center;
  background:
    radial-gradient(circle, color-mix(in srgb, var(--ck-sakura) 13%, transparent), transparent 42%),
    rgba(4, 5, 14, 0.76);
  backdrop-filter: blur(12px);
  animation: ck-reveal-backdrop 420ms ease-out both;
}

.ck-stage-reveal[hidden] {
  display: none;
}

.ck-stage-reveal__card {
  position: relative;
  display: grid;
  width: min(410px, 100%);
  justify-items: center;
  overflow: hidden;
  padding: 32px 26px 26px;
  border: 1px solid color-mix(in srgb, var(--ck-sakura) 42%, transparent);
  border-radius: 24px;
  background:
    linear-gradient(145deg, rgba(31, 32, 68, 0.98), rgba(10, 11, 29, 0.98));
  box-shadow:
    0 40px 110px rgba(1, 2, 10, 0.72),
    0 0 60px color-mix(in srgb, var(--ck-sakura) 9%, transparent);
  text-align: center;
  animation: ck-stage-card-in 620ms cubic-bezier(0.2, 0.85, 0.2, 1.12) both;
}

.ck-stage-reveal__eyebrow {
  color: var(--ck-mint);
  font-size: 0.74rem;
  letter-spacing: 0.14em;
  text-transform: uppercase;
}

.ck-stage-reveal__sigil {
  display: grid;
  width: 76px;
  height: 76px;
  margin: 16px 0 13px;
  place-items: center;
  border: 1px solid color-mix(in srgb, var(--ck-sakura) 45%, transparent);
  border-radius: 24px;
  color: #101124;
  background: linear-gradient(135deg, var(--ck-mint), var(--ck-sakura-soft));
  box-shadow: 0 18px 45px color-mix(in srgb, var(--ck-sakura) 18%, transparent);
  font: 2.4rem "VT323", monospace;
}

.ck-stage-reveal h2 {
  color: #fff;
  font: 1.15rem "Press Start 2P", cursive;
  line-height: 1.4;
}

.ck-stage-reveal p {
  max-width: 310px;
  margin: 12px 0 16px;
  color: rgba(232, 235, 255, 0.7);
  line-height: 1.42;
}

.ck-stage-reveal__reward {
  display: flex;
  align-items: center;
  gap: 9px;
  margin-bottom: 18px;
  padding: 9px 12px;
  border: 1px solid rgba(255, 213, 122, 0.22);
  border-radius: 12px;
  color: var(--ck-gold);
  background: rgba(255, 213, 122, 0.055);
  font-size: 0.78rem;
}

.ck-flower {
  position: absolute;
  width: 16px;
  height: 16px;
  opacity: 0.72;
  background: url("assets/cc0-ninja-adventure/flower.gif") center / contain no-repeat;
  image-rendering: pixelated;
}

.ck-flower--one {
  top: 17px;
  left: 19px;
  transform: scale(1.5) rotate(-8deg);
}

.ck-flower--two {
  right: 21px;
  bottom: 22px;
  transform: scale(1.15) rotate(14deg);
}

.ck-encounter {
  position: fixed;
  right: calc(20px + var(--ck-safe-right));
  bottom: calc(86px + var(--ck-safe-bottom));
  z-index: 160;
  display: grid;
  width: min(560px, calc(100vw - 32px));
  grid-template-columns: 96px minmax(0, 1fr);
  overflow: hidden;
  border: 4px solid #101116;
  border-radius: 9px;
  background: #f5f4ea;
  box-shadow:
    inset 0 0 0 3px #f5f4ea,
    inset 0 0 0 7px #101116,
    0 30px 90px rgba(1, 2, 10, 0.65);
  animation: ck-scholar-enter 500ms cubic-bezier(0.2, 0.9, 0.2, 1.15) both;
}

.ck-encounter[hidden] {
  display: none;
}

.ck-encounter__portrait {
  position: relative;
  display: grid;
  min-height: 166px;
  place-items: end center;
  border-right: 4px solid #101116;
  background:
    radial-gradient(circle at 50% 70%, color-mix(in srgb, var(--ck-mint) 35%, transparent), transparent 55%),
    color-mix(in srgb, var(--ck-sakura-soft) 32%, #e6e7df);
}

.ck-encounter__sigil {
  position: absolute;
  top: 10px;
  left: 10px;
  z-index: 2;
  display: grid;
  width: 34px;
  height: 34px;
  place-items: center;
  border: 1px solid color-mix(in srgb, var(--ck-sakura) 45%, transparent);
  border-radius: 9px;
  color: var(--ck-sakura-soft);
  background: rgba(7, 9, 24, 0.7);
  font: 1.2rem "VT323", monospace;
  box-shadow: 0 8px 20px rgba(2, 3, 12, 0.28);
}

.ck-encounter__portrait img {
  width: 104px;
  max-height: 166px;
  object-fit: contain;
  image-rendering: pixelated;
  transition: filter 300ms ease;
}

.ck-encounter[data-persona="road-poet"] .ck-encounter__portrait img {
  filter: sepia(0.32) hue-rotate(315deg) saturate(0.9);
}

.ck-encounter[data-persona="lantern-geometer"] .ck-encounter__portrait img {
  filter: sepia(0.22) hue-rotate(62deg) saturate(0.86);
}

.ck-encounter[data-persona="shrine-archivist"] .ck-encounter__portrait img {
  filter: grayscale(0.2) hue-rotate(18deg) brightness(1.08);
}

.ck-encounter[data-persona="wandering-elementalist"] .ck-encounter__portrait img {
  filter: hue-rotate(145deg) saturate(0.82) brightness(1.05);
}

.ck-encounter__copy {
  position: relative;
  min-height: 166px;
  padding: 20px 48px 24px 20px;
  color: #171820;
  background:
    linear-gradient(rgba(255, 255, 255, 0.38), transparent 40%),
    #f5f4ea;
}

.ck-encounter__copy .ck-icon-button {
  position: absolute;
  top: 10px;
  right: 10px;
  min-width: 36px;
  min-height: 36px;
}

.ck-encounter__copy h2 {
  margin: 3px 0 7px;
  color: #16171c;
  font: 1.02rem/1.35 "Press Start 2P", cursive;
}

.ck-encounter__copy p {
  min-height: 3.4em;
  margin-bottom: 8px;
  color: #242630;
  font: 1.15rem/1.38 "VT323", monospace;
  white-space: pre-line;
}

.ck-encounter__era {
  color: #4f5a73;
  font-size: 0.76rem;
  letter-spacing: 0.08em;
  text-transform: uppercase;
}

.ck-encounter .ck-source {
  color: #344e8c;
}

.ck-encounter .ck-source--original {
  color: #666b76;
}

.ck-encounter__copy .ck-icon-button {
  color: #16171c;
  background: rgba(17, 18, 23, 0.08);
}

.ck-encounter[data-kind="field"] {
  grid-template-columns: minmax(0, 1fr);
}

.ck-encounter[data-kind="field"] .ck-encounter__portrait {
  display: none;
}

.ck-encounter[data-kind="field"] .ck-encounter__copy {
  min-height: 132px;
  padding-left: 24px;
}

.ck-dialogue-advance {
  position: absolute;
  right: 17px;
  bottom: 10px;
  color: #16171c;
  font: 1rem "Press Start 2P", cursive;
  animation: ck-dialogue-prompt 760ms steps(2, end) infinite;
}

.ck-sr-only {
  position: absolute !important;
  width: 1px !important;
  height: 1px !important;
  padding: 0 !important;
  overflow: hidden !important;
  clip: rect(0, 0, 0, 0) !important;
  white-space: nowrap !important;
  border: 0 !important;
}

.ck-onboarding-actions {
  display: flex;
  flex-wrap: wrap;
  gap: 8px;
  margin-top: 12px;
}

.ck-help-close {
  position: sticky;
  bottom: 0;
  width: 100%;
  min-height: 46px;
  margin-top: 16px;
  border: 0;
  border-radius: 12px;
  color: #161429;
  background: linear-gradient(135deg, var(--ck-gold), var(--ck-sakura-soft));
  font: 0.86rem "Press Start 2P", cursive;
  cursor: pointer;
}

body.mode-countku .help-content {
  width: min(720px, 94vw);
  max-width: 720px;
  max-height: min(82dvh, 780px);
  border-color: rgba(213, 220, 255, 0.24);
  background: rgba(16, 16, 39, 0.97);
}

body.mode-countku.effects-reduced .petal,
body.mode-countku.effects-reduced .wind-swirl {
  display: none !important;
}

body.mode-countku.effects-reduced *,
body.mode-countku.effects-reduced *::before,
body.mode-countku.effects-reduced *::after {
  scroll-behavior: auto !important;
  animation-duration: 0.001ms !important;
  animation-iteration-count: 1 !important;
  transition-duration: 0.001ms !important;
}

@keyframes ck-world-enter {
  from {
    opacity: 0;
    transform: translateY(12px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

@keyframes ck-panel-in {
  from {
    opacity: 0;
    transform: translateX(18px);
  }
}

@keyframes ck-toast-in {
  from {
    opacity: 0;
    transform: translate(-50%, -26px);
  }
  to {
    opacity: 1;
    transform: translate(-50%, 0);
  }
}

@keyframes ck-scholar-enter {
  from {
    opacity: 0;
    transform: translate(22px, 12px) scale(0.94);
  }
  to {
    opacity: 1;
    transform: translate(0, 0) scale(1);
  }
}

@keyframes ck-reveal-backdrop {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}

@keyframes ck-stage-card-in {
  from {
    opacity: 0;
    transform: translateY(24px) scale(0.9);
  }
  to {
    opacity: 1;
    transform: translateY(0) scale(1);
  }
}

@keyframes ck-aura-breathe {
  50% {
    opacity: 0.58;
    transform: scale(1.08);
  }
}

@keyframes ck-smoke-rise {
  from {
    transform: translateY(18px) scale(0.82);
  }
  55% {
    opacity: 0.82;
  }
  to {
    opacity: 0.08;
    transform: translateY(-24px) scale(1.16);
  }
}

@keyframes ck-fire-aura {
  50% {
    transform: translate(-2px, -3px) scaleX(1.04);
  }
}

@keyframes ck-charge-spin {
  to {
    transform: rotate(360deg);
  }
}

@keyframes ck-disco-ninja {
  0% {
    filter: hue-rotate(0deg) saturate(1.25) drop-shadow(0 0 8px #ff4f8b);
  }
  50% {
    filter: hue-rotate(180deg) saturate(1.5) drop-shadow(0 0 12px #56e3b3);
  }
  100% {
    filter: hue-rotate(360deg) saturate(1.25) drop-shadow(0 0 8px #ff4f8b);
  }
}

@keyframes ck-glitch-ninja {
  0%,
  88%,
  100% {
    transform: translate(0);
    filter: none;
  }
  90% {
    transform: translate(-4px, 1px);
    filter: drop-shadow(5px 0 #4affef) drop-shadow(-4px 0 #ff49a7);
  }
  94% {
    transform: translate(3px, -1px);
    filter: drop-shadow(-5px 0 #4affef) drop-shadow(4px 0 #ff49a7);
  }
}

@keyframes ck-glitch-scan {
  50% {
    transform: translate(5px, -4px);
    clip-path: inset(22% 0 38%);
  }
}

@keyframes ck-matrix-fall {
  from {
    transform: translateY(-22%);
  }
  to {
    transform: translateY(26%);
  }
}

@keyframes ck-horse-bob {
  50% {
    transform: scaleX(-1) translateY(-4px);
  }
}

@keyframes ck-supernova {
  0%,
  100% {
    transform: scale(0.88);
    filter: blur(5px) saturate(1.25);
  }
  50% {
    transform: scale(1.1);
    filter: blur(3px) saturate(1.6);
  }
}

@keyframes ck-dialogue-prompt {
  50% {
    transform: translateY(4px);
  }
}

@media (max-width: 720px) {
  body {
    overflow-x: hidden;
    overflow-y: auto;
  }

  body .game-container {
    min-height: 100svh;
    height: auto;
  }

  body.mode-countku .game-container {
    min-height: 100svh;
    padding:
      calc(64px + var(--ck-safe-top))
      calc(12px + var(--ck-safe-right))
      calc(132px + var(--ck-safe-bottom))
      calc(12px + var(--ck-safe-left));
  }

  @supports (min-height: 100dvh) {
    body.mode-countku .game-container {
      min-height: 100dvh;
    }
  }

  body.mode-countku .bg-tree {
    right: -180px;
    bottom: 28vh;
    width: 520px;
    opacity: 0.17;
  }

  body.mode-countku .mode-selector {
    width: 100%;
    justify-content: flex-start;
    flex-wrap: nowrap;
    overflow-x: auto;
    scrollbar-width: none;
    scroll-snap-type: x proximity;
  }

  body.mode-countku .mode-selector::-webkit-scrollbar {
    display: none;
  }

  body.mode-countku .mode-btn {
    min-width: 88px;
    flex: 0 0 auto;
    scroll-snap-align: center;
  }

  body.mode-countku .game-title {
    margin: 0 0 8px;
    font-size: 1.05rem;
  }

  .ck-objective {
    max-width: 100%;
    margin-bottom: 6px;
  }

  .ck-objective strong {
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
  }

  body.mode-countku .number-display {
    margin-bottom: 6px;
  }

  body.mode-countku .number-display .label {
    display: none;
  }

  body.mode-countku .number-display .current-number {
    font-size: clamp(3.2rem, 10vh, 4.8rem);
  }

  body.mode-countku .ninja-area {
    height: 116px;
    margin-bottom: 4px;
  }

  body.mode-countku #gameForm {
    position: sticky;
    bottom: calc(70px + var(--ck-safe-bottom));
    z-index: 42;
    padding: 10px 0 4px;
    background:
      linear-gradient(to bottom, transparent, rgba(10, 10, 27, 0.96) 24%);
  }

  body.mode-countku .game-input {
    min-height: 54px;
    padding: 13px 78px 13px 16px;
    font-size: 16px;
  }

  body.mode-countku .input-hint {
    overflow: hidden;
    max-width: 100%;
    white-space: nowrap;
    text-overflow: ellipsis;
  }

  body.mode-countku #haikuDisplay {
    max-height: 164px;
    overflow-y: auto;
  }

  .ck-hud {
    top: calc(8px + var(--ck-safe-top));
    right: calc(8px + var(--ck-safe-right));
    left: calc(52px + var(--ck-safe-left));
  }

  .ck-hud__identity {
    min-height: 42px;
    padding: 5px 8px;
  }

  .ck-hud__copy span,
  .ck-hud__streak {
    display: none;
  }

  .ck-hud__wallet {
    min-height: 42px;
    padding: 7px 9px;
  }

  .ck-music-button {
    min-width: 32px;
    min-height: 32px;
  }

  .ck-stage-map li > span:last-child {
    display: grid;
  }

  .ck-stage-reveal__card {
    padding: 28px 18px 22px;
  }

  body.mode-countku .help-btn {
    top: calc(8px + var(--ck-safe-top));
    left: calc(8px + var(--ck-safe-left));
    width: 40px;
    height: 40px;
  }

  .ck-nav {
    right: calc(8px + var(--ck-safe-right));
    bottom: calc(8px + var(--ck-safe-bottom));
    left: calc(8px + var(--ck-safe-left));
    justify-content: space-around;
    transform: none;
  }

  .ck-nav button {
    min-width: 0;
    min-height: 50px;
    flex: 1;
    padding-inline: 4px;
  }

  .ck-panel {
    top: auto;
    right: calc(8px + var(--ck-safe-right));
    bottom: calc(70px + var(--ck-safe-bottom));
    left: calc(8px + var(--ck-safe-left));
    width: auto;
    max-height: min(70dvh, 620px);
    border-radius: 22px;
  }

  .ck-panel__header {
    padding: 14px;
  }

  .ck-panel__header h2 {
    font-size: 0.94rem;
  }

  .ck-score-library {
    grid-template-columns: 1fr;
  }

  .ck-subsection-header {
    align-items: start;
    flex-direction: column;
  }

  .ck-encounter {
    right: calc(8px + var(--ck-safe-right));
    bottom: calc(70px + var(--ck-safe-bottom));
    left: calc(8px + var(--ck-safe-left));
    width: auto;
    grid-template-columns: 84px minmax(0, 1fr);
  }

  .ck-encounter__portrait {
    min-height: 164px;
  }

  .ck-encounter__portrait img {
    width: 82px;
  }

  .ck-encounter__copy {
    padding: 15px 42px 14px 14px;
  }

  .ck-encounter__copy h2 {
    font-size: 0.82rem;
  }

  .ck-encounter__copy p {
    font-size: 0.94rem;
  }

  .help-modal {
    padding:
      calc(10px + var(--ck-safe-top))
      calc(10px + var(--ck-safe-right))
      calc(10px + var(--ck-safe-bottom))
      calc(10px + var(--ck-safe-left));
  }

  body.mode-countku .help-content {
    max-height: 90dvh;
    padding: 18px;
  }
}

@media (max-height: 680px) and (min-width: 721px) {
  body.mode-countku .game-container {
    padding-top: calc(60px + var(--ck-safe-top));
  }

  body.mode-countku .mode-selector {
    margin-bottom: 7px;
  }

  body.mode-countku .game-title {
    margin-bottom: 6px;
  }

  body.mode-countku .number-display {
    margin-bottom: 3px;
  }

  body.mode-countku .number-display .current-number {
    font-size: 4rem;
  }

  body.mode-countku .ninja-area {
    height: 108px;
    margin-bottom: 4px;
  }
}

@media (prefers-reduced-motion: reduce) {
  body.mode-countku *,
  body.mode-countku *::before,
  body.mode-countku *::after {
    scroll-behavior: auto !important;
    animation-duration: 0.001ms !important;
    animation-iteration-count: 1 !important;
    transition-duration: 0.001ms !important;
  }

  body.mode-countku .petal,
  body.mode-countku .wind-swirl {
    display: none !important;
  }
}
"""

let render() = file
