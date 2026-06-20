module ConvertedFiles.Adspace.Templates.N1.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "UTF-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1.0" ]
            title [] [
                str "Hillscape Journey"
            ]
            link [ _href "https://fonts.googleapis.com/css2?family=Press+Start+2P&display=swap"; attr "rel" "stylesheet" ]
            style [] [
                    rawText ("""/* ===== RESET & BASE ===== */
  * { margin: 0; padding: 0; box-sizing: border-box; }
  html, body {
    width: 100%;
    height: 100%;
    overflow: hidden;
    background: #5C94FC;
    font-family: 'Press Start 2P', monospace;
  }

  /* ===== CANVAS LAYERS ===== */
  .layer {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    will-change: transform;
  }
  #bgCanvas     { z-index: 1; }
  #windCanvas   { z-index: 2; }
  #fxCanvas     { z-index: 3; }
  #actorsCanvas { z-index: 4; }

  /* ===== SKY GRADIENT (animated, breathing) ===== */
  #sky {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    z-index: 0;
    background: linear-gradient(to bottom, #5C94FC, #8BB9FE);
    animation: skyBreathe 30s ease-in-out infinite alternate;
  }
  @keyframes skyBreathe {
    0%   { filter: hue-rotate(0deg) brightness(1); }
    50%  { filter: hue-rotate(6deg) brightness(1.03); }
    100% { filter: hue-rotate(-4deg) brightness(0.97); }
  }

  /* ===== COUNTDOWN TIMER ===== */
  #countdown-box {
    position: fixed;
    top: 20px;
    right: 20px;
    z-index: 50;
    background: #1a1a2e;
    border: 4px solid #444;
    padding: 12px 16px;
    font-family: 'Press Start 2P', monospace;
    font-size: 14px;
    color: #0f0;
    box-shadow: 0 4px 0 rgba(0,0,0,0.4);
    min-width: 140px;
    text-align: center;
  }

  #countdown-box::before {
    content: 'NEXT BUS IN';
    display: block;
    font-size: 7px;
    color: #888;
    margin-bottom: 8px;
  }

  #countdown-box.warning {
    border-color: #FFD700;
    color: #FFD700;
  }

  #countdown-box.danger {
    border-color: #FF3333;
    color: #FF3333;
    animation: pulse 0.5s ease-in-out infinite alternate;
  }

  @keyframes pulse {
    from { transform: scale(1); box-shadow: 0 0 5px rgba(255,51,51,0.3); }
    to   { transform: scale(1.05); box-shadow: 0 0 20px rgba(255,51,51,0.6); }
  }

  /* ===== DESTINATION SCREEN ===== */
  #destination-screen {
    position: fixed;
    top: 0; left: 0;
    width: 100vw; height: 100vh;
    background: #0a0a1a;
    z-index: 100;
    display: none;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    opacity: 0;
    transition: opacity 1s ease;
  }

  #destination-screen.active {
    display: flex;
    opacity: 1;
  }

  #destination-screen .dest-title {
    font-family: 'Press Start 2P', monospace;
    font-size: 18px;
    color: #0f0;
    text-align: center;
    line-height: 2;
    animation: glow 1.5s ease-in-out infinite alternate;
    margin-bottom: 40px;
  }

  @keyframes glow {
    from { text-shadow: 0 0 10px #0f0, 0 0 20px #0f0; }
    to   { text-shadow: 0 0 20px #0f0, 0 0 40px #0f0, 0 0 60px #0f0; }
  }

  #destination-screen .dest-btn {
    font-family: 'Press Start 2P', monospace;
    font-size: 12px;
    background: #0f0;
    color: #000;
    border: none;
    padding: 16px 32px;
    cursor: pointer;
    text-decoration: none;
    display: inline-block;
    box-shadow: 0 6px 0 #080;
    transition: all 0.1s;
    margin-bottom: 30px;
  }

  #destination-screen .dest-btn:hover {
    background: #5f5;
    transform: translateY(-2px);
    box-shadow: 0 8px 0 #080;
  }

  #destination-screen .dest-btn:active {
    transform: translateY(4px);
    box-shadow: 0 2px 0 #080;
  }

  #destination-screen .dest-auto {
    font-size: 9px;
    color: #666;
    font-family: 'Press Start 2P', monospace;
  }

  #destination-screen .dest-auto span {
    color: #aaa;
  }

  /* ===== CRT SCANLINES ===== */
  #scanlines {
    position: absolute;
    top: 0; left: 0;
    width: 100%; height: 100%;
    z-index: 10;
    pointer-events: none;
    background: repeating-linear-gradient(
      to bottom,
      rgba(0,0,0,0) 0px,
      rgba(0,0,0,0) 2px,
      rgba(0,0,0,0.06) 2px,
      rgba(0,0,0,0.06) 4px
    );
  }

  /* ===== VIGNETTE ===== */
  #vignette {
    position: absolute;
    top: 0; left: 0;
    width: 100%; height: 100%;
    z-index: 11;
    pointer-events: none;
    background: radial-gradient(ellipse at center, transparent 50%, rgba(0,0,0,0.35) 100%);
  }

  /* ===== EXHAUST PUFFS ===== */
  #puff-layer {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    z-index: 5;
    pointer-events: none;
    overflow: hidden;
  }

  .exhaust-puff {
    position: absolute;
    border-radius: 50%;
    background: rgba(180,180,180,0.6);
    pointer-events: none;
  }""")
            ]
        ]
        body [] [
            rawText ("<!--  Sky gradient background  -->")
            div [ _id "sky" ] []
            rawText ("<!--  Canvas layers  -->")
            canvas [ _id "bgCanvas"; _class "layer" ] []
            canvas [ _id "windCanvas"; _class "layer" ] []
            canvas [ _id "fxCanvas"; _class "layer" ] []
            canvas [ _id "actorsCanvas"; _class "layer" ] []
            rawText ("<!--  Countdown  -->")
            div [ _id "countdown-box" ] [
                span [ _id "countdown-display" ] [
                    str "15.00"
                ]
                str "s"
            ]
            rawText ("<!--  Exhaust puff container  -->")
            div [ _id "puff-layer" ] []
            rawText ("<!--  Overlays  -->")
            div [ _id "scanlines" ] []
            div [ _id "vignette" ] []
            rawText ("<!--  Destination screen  -->")
            div [ _id "destination-screen" ] [
                div [ _class "dest-title" ] [
                    str "You have reached"
                    br []
                    str "your destination"
                ]
                a [ _href "https://example.com"; _class "dest-btn"; _id "dest-btn" ] [
                    str "Continue to Destination"
                ]
                div [ _class "dest-auto" ] [
                    str "Redirecting in"
                    span [ _id "auto-countdown" ] [
                        str "5"
                    ]
                    str "s"
                ]
            ]
            script [] [
                    rawText ("""(function() {
  'use strict';

  // ========================================================================
  //  GLOBAL SETUP
  // ========================================================================
  const bgCanvas     = document.getElementById('bgCanvas');
  const windCanvas   = document.getElementById('windCanvas');
  const fxCanvas     = document.getElementById('fxCanvas');
  const actorsCanvas = document.getElementById('actorsCanvas');
  const bgCtx     = bgCanvas.getContext('2d');
  const windCtx   = windCanvas.getContext('2d');
  const fxCtx     = fxCanvas.getContext('2d');
  const actorsCtx = actorsCanvas.getContext('2d');

  let W, H;
  let dpr = Math.min(window.devicePixelRatio || 1, 2);

  function resize() {
    W = window.innerWidth;
    H = window.innerHeight;
    dpr = Math.min(window.devicePixelRatio || 1, 2);
    [bgCanvas, windCanvas, fxCanvas, actorsCanvas].forEach(c => {
      c.width = W * dpr;
      c.height = H * dpr;
      c.style.width = W + 'px';
      c.style.height = H + 'px';
    });
    bgCtx.setTransform(dpr, 0, 0, dpr, 0, 0);
    windCtx.setTransform(dpr, 0, 0, dpr, 0, 0);
    fxCtx.setTransform(dpr, 0, 0, dpr, 0, 0);
    actorsCtx.setTransform(dpr, 0, 0, dpr, 0, 0);
    initHills();
    initGrass();
    initClouds();
    initBillboards();
    updateResponsivePositions();
  }

  // ========================================================================
  //  JOURNEY STATE MACHINE
  // ========================================================================
  const BUS_PHASES = { WAITING: 0, ARRIVING: 1, STOPPED: 2, DONE: 3 };
  const COUNTDOWN_DURATION = 15;

  let journeyState = {
    countdown: COUNTDOWN_DURATION,
    busPhase: BUS_PHASES.WAITING,
    busX: -999,           // set properly in resize/init
    busTargetX: 0,        // set properly in resize/init
    busSpeed: 0,
    busStopTime: 0,
    characters: [],
    destinationShown: false,
    autoCountdown: 5,
    globalSpeed: 1,
  };

  // DOM refs
  const countdownBox     = document.getElementById('countdown-box');
  const countdownDisplay = document.getElementById('countdown-display');
  const puffLayer        = document.getElementById('puff-layer');
  const destScreen       = document.getElementById('destination-screen');
  const autoCountdownEl  = document.getElementById('auto-countdown');

  function initJourney() {
    journeyState.busX = W + 300;
    updateResponsivePositions();
  }

  // Responsive positioning for all scene elements
  let BACK_BB_POSITIONS = [400, 2400]; // world X for each back-hill billboard
  let MID_BB_POSITIONS  = [300, 2000];  // world X for each middle-hill billboard
  let billboardScale = 1.0;             // responsive scale factor for billboards

  function updateResponsivePositions() {
    // Bus stops with its visual center at screen center
    journeyState.busTargetX = W * 0.5;

    // Responsive billboard scale: smaller on narrow screens
    billboardScale = W < 600 ? W / 800 : 1.0;
    billboardScale = Math.max(0.4, Math.min(1.0, billboardScale));

    // Back-hill billboards: left and right thirds, offset from middle ones
    const backLoopWidth = W + HILL_LAYERS[0].scrollSpeed * 40;
    BACK_BB_POSITIONS = [
      backLoopWidth * 0.10,           // far left
      backLoopWidth * 0.10 + W * 1.2, // well right of center
    ];

    // Middle-hill billboards: staggered so they don't overlap with back-hill ones
    const midLoopWidth = W + HILL_LAYERS[1].scrollSpeed * 20;
    MID_BB_POSITIONS = [
      midLoopWidth * 0.35,   // center-left (between the two back-hill ones)
      midLoopWidth * 0.80,   // far right
    ];

    // Update middle-hill billboard instances
    billboards.forEach((bb, i) => {
      bb.x = MID_BB_POSITIONS[i];
      bb.width = 280 * billboardScale;
      bb.height = 160 * billboardScale;
      bb.poleHeight = 70 * billboardScale;
    });
  }

  // ========================================================================
  //  HILL SYSTEM — Triple-layer parallax with pixelated fill
  // ========================================================================
  const HILL_LAYERS = [
    { color: '#1B5E20', scrollSpeed: 18,  yBase: 0.55, amp: 60, freq: 0.003, freq2: 0.007, amp2: 25 },
    { color: '#2E7D32', scrollSpeed: 38,  yBase: 0.68, amp: 45, freq: 0.005, freq2: 0.011, amp2: 18 },
    { color: '#43A047', scrollSpeed: 68,  yBase: 0.80, amp: 30, freq: 0.007, freq2: 0.015, amp2: 12 },
  ];

  let hillOffsets = [0, 0, 0];
  let hillPoints = [[], [], []]; // cached Y values for grass/billboard anchoring

  function initHills() {
    hillOffsets = [0, 0, 0];
    sampleHills();
  }

  function sampleHills() {
    for (let l = 0; l < 3; l++) {
      hillPoints[l] = new Float32Array(W + 4);
      for (let x = 0; x <= W + 2; x++) {
        hillPoints[l][x] = getHillY(l, x);
      }
    }
  }

  function getHillY(layerIdx, x) {
    const hl = HILL_LAYERS[layerIdx];
    const ox = x + hillOffsets[layerIdx];
    const base = H * hl.yBase;
    const w1 = Math.sin(ox * hl.freq) * hl.amp;
    const w2 = Math.sin(ox * hl.freq2 + 1.7) * hl.amp2;
    const w3 = Math.sin(ox * hl.freq * 0.5 + 3.1) * (hl.amp * 0.3);
    return base + w1 + w2 + w3;
  }

  // ---- draw pixelated hills as 4px-wide vertical strips ----
  function drawPixelHillColumn(ctx, x, yTop, w, h, color) {
    if (yTop >= H) return;
    const clampedY = Math.max(0, yTop);
    const clampedH = H - clampedY;
    if (clampedH > 0) {
      ctx.fillStyle = color;
      ctx.fillRect(x, clampedY, w, clampedH);
    }
  }

  // ---- Draw a single hill layer with its highlight/shadow strips ----
  function drawSingleHillLayer(ctx, l) {
    const hl = HILL_LAYERS[l];
    const step = 4; // pixelation block width

    // Main hill body: draw as vertical pixelated columns
    for (let x = 0; x <= W; x += step) {
      const hillY = hillPoints[l][x];
      drawPixelHillColumn(ctx, x, hillY, step, H - hillY, hl.color);
    }

    // Highlight strip at the crest for pixel-art "Windows XP bliss" look
    const highlightColor = (l === 2) ? '#00CC44' : (l === 1) ? '#4CAF50' : '#388E3C';
    const shadowColor    = (l === 2) ? '#2E7D32' : (l === 1) ? '#1B5E20' : '#0D3B10';

    for (let x = 0; x <= W; x += step) {
      const hillY = hillPoints[l][x];
      if (hillY >= H) continue;

      // Alternating highlight / shadow strips based on position
      const cyclePos = Math.floor((x + hillOffsets[l]) / step);
      if (cyclePos % 2 === 0) {
        // Bright highlight strip at the very crest (more prominent)
        ctx.fillStyle = highlightColor;
        ctx.fillRect(x, hillY - 3, step, 5);
      } else {
        // Slightly darker band just below crest
        ctx.fillStyle = shadowColor;
        ctx.fillRect(x, hillY + 1, step, 3);
      }

      // Brighter top edge line for the front layer
      if (l === 2) {
        ctx.fillStyle = '#66FF88';
        ctx.fillRect(x, hillY - 1, step, 2);
      }

      // Random bright speckles on front layer for extra pixel charm
      if (l === 2 && (cyclePos % 5 === 0)) {
        ctx.fillStyle = '#88FF88';
        ctx.fillRect(x + 1, hillY - 2, 2, 2);
      }
    }
  }

  // ---- Draw all hills at once (for init/resample) ----
  function drawHills(ctx) {
    // Re-sample hill points at current offsets for accurate anchoring
    sampleHills();

    // Draw back to front
    for (let l = 0; l < 3; l++) {
      drawSingleHillLayer(ctx, l);
    }
  }

  // ========================================================================
  //  GRASS SYSTEM — Tufts of blade shapes anchored to hill surface
  // ========================================================================
  const GRASS_COLORS = ['#44FF44', '#00FF00', '#00DD00', '#66EE66', '#88FF88', '#77DD55'];
  let grassTufts = []; // {x, layer, blades: [{height, colorIdx, phase, lean}]}

  function initGrass() {
    grassTufts = [];
    const tuftCount = Math.floor(W * 0.6); // density per screen width

    for (let i = 0; i < tuftCount; i++) {
      const layer = 2; // ONLY front hill - grass grows on the ground
      const x = Math.random() * W * 3; // wide area for wrapping
      const bladeCount = 2 + Math.floor(Math.random() * 3); // 2-4 blades per tuft
      const blades = [];

      for (let b = 0; b < bladeCount; b++) {
        blades.push({
          height: 12 + Math.random() * 8,    // 12-20px tall
          colorIdx: Math.floor(Math.random() * GRASS_COLORS.length),
          phase: Math.random() * Math.PI * 2,
          lean: (Math.random() - 0.5) * 4,   // natural slight lean offset
        });
      }

      grassTufts.push({ x, layer, blades });
    }
  }

  function drawGrass(ctx, time, windStrength) {
    const layer = 2;
    const scroll = hillOffsets[layer];
    const layerSpeed = HILL_LAYERS[layer].scrollSpeed;
    const totalWidth = W + layerSpeed * 12;

    for (const tuft of grassTufts) {
      // Wrap tuft position
      let drawX = tuft.x - scroll;
      while (drawX < -30) drawX += totalWidth;
      while (drawX > W + 30) drawX -= totalWidth;

      if (drawX < -10 || drawX > W + 10) continue;

      // Get hill Y at this X — grass grows FROM the hill surface
      const hillY = getHillY(layer, drawX);
      if (hillY >= H - 5 || hillY < 0) continue;

      // Draw each blade in the tuft
      for (const blade of tuft.blades) {
        // Wind sway: combines gentle oscillation + gust influence
        const sway = Math.sin(time * 2.5 + blade.phase) * (4 + windStrength * 10);
        const gustSway = Math.sin(time * 1.3 + blade.phase * 1.7) * windStrength * 8;
        const totalSway = sway + gustSway + blade.lean;

        const rootX = drawX;
        const rootY = hillY - 1; // start just below hill crest
        const tipX = rootX + totalSway;
        const tipY = rootY - blade.height;

        // Draw blade as a thin filled shape (2px wide line)
        ctx.fillStyle = GRASS_COLORS[blade.colorIdx];
        ctx.beginPath();
        ctx.moveTo(rootX - 1, rootY);
        ctx.lineTo(rootX + 1, rootY);
        ctx.lineTo(tipX + 1, tipY);
        ctx.lineTo(tipX - 1, tipY);
        ctx.closePath();
        ctx.fill();
      }
    }
  }

  // ========================================================================
  //  WIND SYSTEM — Prominent curved Bezier streaks, 3 depth layers
  // ========================================================================
  const WIND_LAYERS = [
    { count: 20, speedBase: 90,  lengthMin: 80,  lengthMax: 140, width: 2,  alpha: 0.35, curve: 10 },
    { count: 14, speedBase: 160, lengthMin: 100, lengthMax: 180, width: 2,  alpha: 0.48, curve: 18 },
    { count: 10, speedBase: 240, lengthMin: 120, lengthMax: 220, width: 3,  alpha: 0.60, curve: 25 },
  ];

  let windStreaks = [];

  class WindStreak {
    constructor(layerIdx) {
      this.layer = layerIdx;
      this.reset(true);
    }

    reset(randomX) {
      const cfg = WIND_LAYERS[this.layer];
      this.y = 20 + Math.random() * (H * 0.82);
      this.speed = cfg.speedBase * (0.7 + Math.random() * 0.6);
      this.length = cfg.lengthMin + Math.random() * (cfg.lengthMax - cfg.lengthMin);
      this.width = cfg.width;
      this.alpha = cfg.alpha * (0.5 + Math.random() * 0.5);
      this.curveMax = cfg.curve;
      this.curveDir = Math.random() > 0.5 ? 1 : -1;
      this.phase = Math.random() * Math.PI * 2;
      this.x = randomX ? Math.random() * (W + 300) : W + 50 + Math.random() * 300;
    }

    update(dt, gustMult) {
      this.x -= this.speed * dt * (1 + gustMult * 1.2) * journeyState.globalSpeed;
      if (this.x + this.length < -80) {
        this.reset(false);
      }
    }

    draw(ctx, gustMult) {
      const gAlpha = Math.min(0.85, this.alpha * (1 + gustMult * 0.8));
      const curve = this.curveMax * this.curveDir * (1 + gustMult * 0.5);
      const midX = this.x + this.length * 0.5;
      const endX = this.x + this.length;

      // Main streak — thick, prominent Bezier curve
      ctx.strokeStyle = `rgba(255, 253, 240, ${gAlpha})`;
      ctx.lineWidth = this.width;
      ctx.lineCap = 'round';
      ctx.beginPath();
      ctx.moveTo(this.x, this.y);
      ctx.quadraticCurveTo(midX, this.y + curve, endX, this.y + curve * 0.4);
      ctx.stroke();

      // 1px inner core for depth
      ctx.strokeStyle = `rgba(255, 255, 255, ${gAlpha * 0.6})`;
      ctx.lineWidth = Math.max(1, this.width * 0.5);
      ctx.beginPath();
      ctx.moveTo(this.x + 2, this.y + 1);
      ctx.quadraticCurveTo(midX, this.y + curve + 1, endX - 4, this.y + curve * 0.4 + 1);
      ctx.stroke();
    }
  }

  function initWind() {
    windStreaks = [];
    for (let l = 0; l < 3; l++) {
      for (let i = 0; i < WIND_LAYERS[l].count; i++) {
        windStreaks.push(new WindStreak(l));
      }
    }
  }

  // ========================================================================
  //  CLOUD SYSTEM — Pixel-art clouds from multiple overlapping rectangles
  // ========================================================================
  let clouds = [];

  class Cloud {
    constructor() {
      this.reset(true);
    }

    reset(randomX) {
      this.y = 15 + Math.random() * (H * 0.30);
      this.speed = 6 + Math.random() * 14;
      this.scale = 0.5 + Math.random() * 0.8;
      this.alpha = 0.75 + Math.random() * 0.20;
      this.x = randomX ? Math.random() * (W + 400) : W + 100 + Math.random() * 400;

      // Build cloud from 5-7 overlapping rectangles for fluffy pixel look
      this.blocks = [];

      // Central mass (main body)
      this.blocks.push({ dx: 0,      dy: 0,   w: 50,  h: 18, color: 'rgba(255,255,255,0.85)' });
      // Left bumps
      this.blocks.push({ dx: -22,    dy: 4,   w: 28,  h: 14, color: 'rgba(255,255,255,0.70)' });
      this.blocks.push({ dx: -12,    dy: -8,  w: 32,  h: 12, color: 'rgba(255,255,255,0.80)' });
      // Right bumps
      this.blocks.push({ dx: 38,     dy: 3,   w: 26,  h: 14, color: 'rgba(255,255,255,0.70)' });
      this.blocks.push({ dx: 30,     dy: -7,  w: 30,  h: 12, color: 'rgba(255,255,255,0.80)' });
      // Top bump
      this.blocks.push({ dx: 10,     dy: -14, w: 24,  h: 10, color: 'rgba(255,255,255,0.75)' });
      // Extra bottom fluff
      this.blocks.push({ dx: 8,      dy: 10,  w: 30,  h: 10, color: 'rgba(245,248,255,0.65)' });
      // Additional depth piece (small darker)
      if (Math.random() > 0.3) {
        this.blocks.push({ dx: -6,    dy: 12,  w: 20,  h: 8,  color: 'rgba(230,235,245,0.55)' });
      }
    }

    update(dt) {
      this.x -= this.speed * dt * journeyState.globalSpeed;
      if (this.x < -250) this.reset(false);
    }

    draw(ctx) {
      ctx.save();
      ctx.globalAlpha = this.alpha;

      for (const b of this.blocks) {
        const bx = this.x + b.dx * this.scale;
        const by = this.y + b.dy * this.scale;
        const bw = Math.round(b.w * this.scale);
        const bh = Math.round(b.h * this.scale);

        // Each block uses its own color for depth variation
        ctx.fillStyle = b.color || 'rgba(255,255,255,0.85)';
        ctx.fillRect(Math.round(bx), Math.round(by), bw, bh);

        // Subtle shadow on bottom edge for depth
        ctx.fillStyle = 'rgba(200, 210, 230, 0.4)';
        ctx.fillRect(Math.round(bx), Math.round(by + bh - 2), bw, 2);
      }

      ctx.restore();
    }
  }

  function initClouds() {
    clouds = [];
    const count = 7 + Math.floor(Math.random() * 3); // 7-10 clouds
    for (let i = 0; i < count; i++) {
      clouds.push(new Cloud());
    }
  }

  // ========================================================================
  //  AMBIENT LIFE PARTICLES — Floating pollen / fireflies
  // ========================================================================
  let lifeParticles = [];
  const PARTICLE_COUNT = 36;

  class LifeParticle {
    constructor() {
      this.reset(true);
    }

    reset(randomY) {
      this.x = Math.random() * W;
      this.y = randomY ? Math.random() * H : H + 5;
      this.vx = (Math.random() - 0.5) * 12;
      this.vy = -6 - Math.random() * 10; // float upward
      this.size = 2 + Math.random() * 1.5; // 2-3.5px
      this.alphaBase = 0.4 + Math.random() * 0.5;
      this.twinklePhase = Math.random() * Math.PI * 2;
      this.twinkleSpeed = 1.5 + Math.random() * 2.5;
    }

    update(dt, time) {
      this.x += this.vx * dt;
      this.y += this.vy * dt;
      this.x += Math.sin(time * 0.8 + this.twinklePhase) * 3 * dt;

      if (this.y < -10 || this.x < -20 || this.x > W + 20) {
        this.reset(false);
      }
    }

    draw(ctx, time) {
      const twinkle = 0.4 + 0.6 * Math.sin(time * this.twinkleSpeed + this.twinklePhase);
      const alpha = this.alphaBase * twinkle;
      // Golden/yellow glow
      ctx.fillStyle = `rgba(255, 220, 80, ${alpha})`;
      ctx.fillRect(this.x - this.size / 2, this.y - this.size / 2, this.size, this.size);
      // Bright center dot
      ctx.fillStyle = `rgba(255, 255, 200, ${alpha * 0.8})`;
      ctx.fillRect(this.x - 0.5, this.y - 0.5, 1.5, 1.5);
    }
  }

  function initLifeParticles() {
    lifeParticles = [];
    for (let i = 0; i < PARTICLE_COUNT; i++) {
      lifeParticles.push(new LifeParticle());
    }
  }

  // ========================================================================
  //  PIXEL BIRDS — Occasional flocks of V-shaped birds
  // ========================================================================
  let birds = [];
  let birdTimer = 0;
  let nextBirdTime = 12 + Math.random() * 10; // 12-22 seconds

  class Bird {
    constructor(startX, startY, flockIdx) {
      this.x = startX;
      this.y = startY;
      this.speed = 55 + Math.random() * 25;
      this.wingPhase = Math.random() * Math.PI * 2;
      this.wingSpeed = 6 + Math.random() * 3;
      this.flockIdx = flockIdx;
      this.size = 3 + Math.random() * 2;
    }

    update(dt) {
      this.x -= this.speed * dt;
      this.y += Math.sin(this.x * 0.008 + this.flockIdx) * 0.3;
      this.wingPhase += this.wingSpeed * dt;
    }

    draw(ctx) {
      const wingY = Math.sin(this.wingPhase) * 3;
      ctx.strokeStyle = '#1A1A1A';
      ctx.lineWidth = 2;
      ctx.lineCap = 'square';
      ctx.beginPath();
      // V shape pointing down
      ctx.moveTo(this.x - this.size, this.y - wingY);
      ctx.lineTo(this.x, this.y + this.size * 0.5);
      ctx.lineTo(this.x + this.size, this.y - wingY);
      ctx.stroke();
    }
  }

  function spawnBirds() {
    const flockSize = 2 + Math.floor(Math.random() * 3); // 2-4 birds
    const startX = W + 30;
    const startY = 30 + Math.random() * (H * 0.28);
    for (let i = 0; i < flockSize; i++) {
      birds.push(new Bird(startX + i * 14, startY + i * 7, i));
    }
  }

  function updateBirds(dt, time) {
    birdTimer += dt;
    if (birdTimer >= nextBirdTime) {
      spawnBirds();
      birdTimer = 0;
      nextBirdTime = 12 + Math.random() * 10;
    }
    for (let i = birds.length - 1; i >= 0; i--) {
      birds[i].update(dt);
      if (birds[i].x < -30) birds.splice(i, 1);
    }
  }

  function drawBirds(ctx) {
    for (const b of birds) b.draw(ctx);
  }

  // ========================================================================
  //  BILLBOARDS — Large pixel-styled signs anchored to MIDDLE hill
  // ========================================================================
  let billboards = [];
  const BILLBOARD_TEXTS = [
    { text: 'Your Content', color: '#FFD700' },
    { text: 'Coming Soon',  color: '#4ECDC4' },
  ];

  class Billboard {
    constructor(data, idx) {
      this.textData = data;
      this.idx = idx;
      // Position set dynamically via updateResponsivePositions()
      this.x = MID_BB_POSITIONS[idx] || (400 + idx * 1500);
      this.layer = 1; // MIDDLE hill layer
      // Wide format (16:9-ish): 280 x 160
      this.width = 280;
      this.height = 160;
      this.poleHeight = 70;
    }

    draw(ctx) {
      const scroll = hillOffsets[this.layer];
      let drawX = this.x - scroll;
      const layerSpeed = HILL_LAYERS[this.layer].scrollSpeed;
      const totalWidth = W + layerSpeed * 20;
      while (drawX < -450) drawX += totalWidth;
      while (drawX > W + 450) drawX -= totalWidth;

      if (drawX < -400 || drawX > W + 400) return;

      const hillY = getHillY(this.layer, drawX);
      if (hillY >= H - 5) return;

      const groundY = hillY + 6;
      const bx = drawX - this.width / 2;
      const by = groundY - this.poleHeight - this.height;

      // Pole (planted in the hill) — thick and sturdy
      const poleW = Math.max(4, Math.round(10 * billboardScale));
      ctx.fillStyle = '#8D6E63';
      ctx.fillRect(drawX - poleW / 2, by + this.height, poleW, this.poleHeight);
      // Pole highlight for depth
      ctx.fillStyle = '#A1887F';
      ctx.fillRect(drawX - poleW / 2, by + this.height, Math.max(2, Math.round(3 * billboardScale)), this.poleHeight);

      // Board shadow (offset for depth)
      ctx.fillStyle = 'rgba(0,0,0,0.25)';
      const shOff = Math.max(3, Math.round(6 * billboardScale));
      ctx.fillRect(bx + shOff, by + shOff, this.width, this.height);

      // Board background
      ctx.fillStyle = '#F5F5DC';
      ctx.fillRect(bx, by, this.width, this.height);

      // Thick pixel border (top/bottom/left/right)
      const borderThick = Math.max(3, Math.round(6 * billboardScale));
      const cOff = Math.max(2, Math.round(4 * billboardScale));
      const cSize = Math.max(6, Math.round(18 * billboardScale));
      ctx.fillStyle = '#444444';
      ctx.fillRect(bx, by, this.width, borderThick);
      ctx.fillRect(bx, by + this.height - borderThick, this.width, borderThick);
      ctx.fillRect(bx, by, borderThick, this.height);
      ctx.fillRect(bx + this.width - borderThick, by, borderThick, this.height);

      // Corner decorations (colored squares)
      ctx.fillStyle = this.textData.color;
      ctx.fillRect(bx + cOff, by + cOff, cSize, cSize);
      ctx.fillRect(bx + this.width - cSize - cOff, by + cOff, cSize, cSize);
      ctx.fillRect(bx + cOff, by + this.height - cSize - cOff, cSize, cSize);
      ctx.fillRect(bx + this.width - cSize - cOff, by + this.height - cSize - cOff, cSize, cSize);

      // Inner dark area for text
      ctx.fillStyle = '#1A1A1A';
      const innerPadX = Math.max(6, Math.round(12 * billboardScale));
      const innerPadTop = Math.max(10, Math.round(24 * billboardScale));
      const innerPadBot = Math.max(16, Math.round(42 * billboardScale));
      ctx.fillRect(bx + innerPadX, by + innerPadTop, this.width - innerPadX * 2, this.height - innerPadBot);

      // Text — large and readable with colored glow shadow
      ctx.fillStyle = '#FFFFFF';
      const baseFontSize = Math.max(10, Math.round(22 * billboardScale));
      ctx.font = `${baseFontSize}px "Press Start 2P", monospace`;
      ctx.textAlign = 'center';
      ctx.textBaseline = 'middle';
      ctx.shadowColor = this.textData.color;
      ctx.shadowBlur = Math.max(2, Math.round(6 * billboardScale));
      ctx.shadowOffsetX = 0;
      ctx.shadowOffsetY = 0;

      // Handle long text: if text is too wide, scale down font
      const textWidth = ctx.measureText(this.textData.text).width;
      const maxTextWidth = this.width - Math.round(32 * billboardScale);
      if (textWidth > maxTextWidth) {
        const scaleFactor = maxTextWidth / textWidth;
        const minFont = Math.max(8, Math.round(12 * billboardScale));
        ctx.font = `${Math.max(minFont, Math.floor(baseFontSize * scaleFactor))}px "Press Start 2P", monospace`;
      }

      ctx.fillText(this.textData.text, bx + this.width / 2, by + this.height / 2 + 2);
      // Reset shadow
      ctx.shadowColor = 'transparent';
      ctx.shadowBlur = 0;
      ctx.textAlign = 'start';
      ctx.textBaseline = 'alphabetic';
    }
  }

  function initBillboards() {
    billboards = [];
    BILLBOARD_TEXTS.forEach((d, i) => {
      billboards.push(new Billboard(d, i));
    });
  }

  // ========================================================================
  //  BACK-HILL BILLBOARDS — Behind layer 0, peeping over the back hill
  // ========================================================================
  // Back-hill billboard configs (positions set dynamically in updateResponsivePositions)
  const BACK_BILLBOARDS = [
    { text: 'VIDEO A',   color: '#FF3333' },
    { text: 'CONTENT B', color: '#3388FF' },
  ];

  function drawBackBillboards(ctx) {
    const scroll = hillOffsets[0];
    const layerSpeed = HILL_LAYERS[0].scrollSpeed;
    const totalWidth = W + layerSpeed * 40;

    BACK_BILLBOARDS.forEach((bb, i) => {
      const bbWorldX = BACK_BB_POSITIONS[i];
      if (bbWorldX === undefined) return;
      let drawX = bbWorldX - scroll;
      while (drawX < -500) drawX += totalWidth;
      while (drawX > W + 500) drawX -= totalWidth;

      if (drawX < -400 || drawX > W + 400) return;

      const hillY = getHillY(0, bbWorldX);
      if (hillY >= H - 5) return;

      const s = billboardScale;
      const boardW = Math.round(320 * s);
      const boardH = Math.round(180 * s);
      const poleH = Math.round(60 * s);
      const border = Math.max(3, Math.round(6 * s));
      const cornerSize = Math.max(6, Math.round(14 * s));

      // Ground position: embed bottom slightly into hill
      const groundY = hillY + 20;
      const bx = drawX - boardW / 2;
      const by = groundY - poleH - boardH;

      // Pole
      const poleW = Math.max(2, Math.round(6 * s));
      ctx.fillStyle = '#8D6E63';
      ctx.fillRect(drawX - poleW / 2, by + boardH, poleW, poleH + Math.round(20 * s));

      // Pole base plate
      ctx.fillStyle = '#6D4C41';
      ctx.fillRect(drawX - Math.round(8 * s), groundY - 4, Math.round(16 * s), 4);

      // Board shadow
      ctx.fillStyle = 'rgba(0,0,0,0.25)';
      ctx.fillRect(bx + Math.round(4 * s), by + Math.round(4 * s), boardW, boardH);

      // Board background
      ctx.fillStyle = '#F5F5DC';
      ctx.fillRect(bx, by, boardW, boardH);

      // Thick pixel border
      ctx.fillStyle = '#333333';
      ctx.fillRect(bx, by, boardW, border);
      ctx.fillRect(bx, by + boardH - border, boardW, border);
      ctx.fillRect(bx, by, border, boardH);
      ctx.fillRect(bx + boardW - border, by, border, boardH);

      // Inner colored frame
      ctx.fillStyle = bb.color;
      ctx.fillRect(bx + border, by + border, boardW - border * 2, border);
      ctx.fillRect(bx + border, by + boardH - border * 2, boardW - border * 2, border);
      ctx.fillRect(bx + border, by + border, border, boardH - border * 2);
      ctx.fillRect(bx + boardW - border * 2, by + border, border, boardH - border * 2);

      // Corner decorations (colored squares)
      ctx.fillStyle = bb.color;
      const cd = border + Math.max(2, Math.round(4 * s));
      ctx.fillRect(bx + cd, by + cd, cornerSize, cornerSize);
      ctx.fillRect(bx + boardW - cd - cornerSize, by + cd, cornerSize, cornerSize);
      ctx.fillRect(bx + cd, by + boardH - cd - cornerSize, cornerSize, cornerSize);
      ctx.fillRect(bx + boardW - cd - cornerSize, by + boardH - cd - cornerSize, cornerSize, cornerSize);

      // Inner dark screen area
      ctx.fillStyle = '#111111';
      ctx.fillRect(bx + border + Math.max(2, Math.round(4 * s)), by + border + Math.round(24 * s), boardW - border * 2 - Math.max(4, Math.round(8 * s)), boardH - border * 2 - Math.round(32 * s));

      // Text — responsive font size
      ctx.fillStyle = '#FFFFFF';
      const fontSize = Math.max(8, Math.round(18 * s));
      ctx.font = `${fontSize}px "Press Start 2P", monospace`;
      ctx.textAlign = 'center';
      ctx.textBaseline = 'middle';
      ctx.shadowColor = bb.color;
      ctx.shadowBlur = Math.max(2, Math.round(6 * s));
      ctx.fillText(bb.text, bx + boardW / 2, by + boardH / 2 + 6);
      // Reset shadow
      ctx.shadowColor = 'transparent';
      ctx.shadowBlur = 0;
      ctx.textAlign = 'start';
      ctx.textBaseline = 'alphabetic';
    });
  }

  // ========================================================================
  //  GUST SYSTEM — Periodic wind gusts that intensify everything
  // ========================================================================
  let gustTimer = 0;
  let gustDuration = 0;
  let gustIntensity = 0; // 0-1
  let isGusting = false;
  let nextGustTime = 4 + Math.random() * 5; // 4-9 seconds until next gust

  function updateGusts(dt) {
    gustTimer += dt;
    if (!isGusting) {
      if (gustTimer >= nextGustTime) {
        isGusting = true;
        gustDuration = 2.0 + Math.random() * 2.5; // gust lasts 2.0-4.5s
        gustTimer = 0;
      }
      // Ease intensity down
      gustIntensity = Math.max(0, gustIntensity - dt * 1.5);
    } else {
      // During gust: ramp up then down (bell curve)
      const halfDur = gustDuration / 2;
      if (gustTimer < halfDur) {
        gustIntensity = Math.min(1, gustIntensity + dt * 2.5);
      } else {
        gustIntensity = Math.max(0, gustIntensity - dt * 1.8);
      }
      if (gustTimer >= gustDuration) {
        isGusting = false;
        gustTimer = 0;
        nextGustTime = 4 + Math.random() * 5;
        gustIntensity = 0;
      }
    }
  }

  function getGustMult() {
    return gustIntensity;
  }

  // ========================================================================
  //  BUS DRAWING
  // ========================================================================
  function roundRect(ctx, x, y, w, h, r) {
    ctx.beginPath();
    ctx.moveTo(x + r, y);
    ctx.lineTo(x + w - r, y);
    ctx.quadraticCurveTo(x + w, y, x + w, y + r);
    ctx.lineTo(x + w, y + h - r);
    ctx.quadraticCurveTo(x + w, y + h, x + w - r, y + h);
    ctx.lineTo(x + r, y + h);
    ctx.quadraticCurveTo(x, y + h, x, y + h - r);
    ctx.lineTo(x, y + r);
    ctx.quadraticCurveTo(x, y, x + r, y);
    ctx.closePath();
  }

  function drawWheel(ctx, x, y, r) {
    ctx.fillStyle = '#1a1a1a';
    ctx.beginPath();
    ctx.arc(x, y, r, 0, Math.PI * 2);
    ctx.fill();
    ctx.fillStyle = '#555';
    ctx.beginPath();
    ctx.arc(x, y, r * 0.55, 0, Math.PI * 2);
    ctx.fill();
    ctx.fillStyle = '#888';
    ctx.beginPath();
    ctx.arc(x, y, r * 0.25, 0, Math.PI * 2);
    ctx.fill();
  }

  // Original goofy bus — drawn exactly as the prototype, scale 3
  // Bus dimensions at original scale: 80 x 60, scaled 3x = 240 x 180 on screen
  const BUS_SCALE = 3;
  const BUS_W = 80;
  const BUS_H = 60;
  const BUS_DRAW_W = BUS_W * BUS_SCALE; // 240
  const BUS_DRAW_H = BUS_H * BUS_SCALE; // 180

  function drawBus(ctx, busLX, busTY, isArriving) {
    // busLX = left edge of bus in screen coords
    // busTY = top edge of bus in screen coords
    const x = busLX;
    const y = busTY;

    // Body
    ctx.fillStyle = '#F8D030';
    ctx.fillRect(x, y, BUS_DRAW_W, BUS_DRAW_H);

    // Stripe
    ctx.fillStyle = '#B8A020';
    ctx.fillRect(x, y + 35 * BUS_SCALE, BUS_DRAW_W, 10 * BUS_SCALE);

    // Windows
    ctx.fillStyle = '#87CEEB';
    ctx.fillRect(x + 8 * BUS_SCALE, y + 10 * BUS_SCALE, 64 * BUS_SCALE, 20 * BUS_SCALE);

    // Wheels — gloriously simple rectangles
    ctx.fillStyle = '#333';
    ctx.fillRect(x + 12 * BUS_SCALE, y + (BUS_H - 8) * BUS_SCALE, 16 * BUS_SCALE, 8 * BUS_SCALE);
    ctx.fillRect(x + 52 * BUS_SCALE, y + (BUS_H - 8) * BUS_SCALE, 16 * BUS_SCALE, 8 * BUS_SCALE);

    // Door line
    ctx.fillStyle = '#D0B020';
    ctx.fillRect(x + (BUS_W - 15) * BUS_SCALE, y + 35 * BUS_SCALE, 10 * BUS_SCALE, 20 * BUS_SCALE);

    // Headlight glow if arriving
    if (isArriving) {
      ctx.fillStyle = 'rgba(255, 255, 200, 0.3)';
      ctx.fillRect(x - 40 * BUS_SCALE, y + 40 * BUS_SCALE, 40 * BUS_SCALE, 20 * BUS_SCALE);
    }
  }

  // ========================================================================
  //  CHARACTER SYSTEM
  // ========================================================================
  class Character {
    constructor(color, delay) {
      this.color = color;
      this.delay = delay;
      this.phase = 'waiting';
      this.x = 0;
      this.y = 0;
      this.hopY = 0;
      this.hopPhase = 0;
      this.walkX = 0;
      this.walkStartX = 0;
      this.legPhase = 0;
      this.targetY = 0;
      this.skinColor = '#F5CBA7';
      this.pantsColor = '#34495E';
    }

    update(dt, doorX, doorY, groundY) {
      if (this.phase === 'waiting') {
        // Hidden inside the bus — position at door but don't draw yet
        this.x = doorX;
        this.targetY = groundY;
        return;
      }

      if (this.phase === 'hopping') {
        this.hopPhase += dt * 5;
        // Hop arc: jump up then land on ground
        this.hopY = Math.sin(this.hopPhase) * 35;
        // Move slightly outward from door during hop
        this.x = doorX + Math.sin(this.hopPhase) * 15;
        if (this.hopPhase >= Math.PI) {
          this.hopY = 0;
          this.phase = 'walking';
          // Start walking from current position
          this.walkStartX = this.x;
        }
      }

      if (this.phase === 'walking') {
        this.walkX += 30 * dt;
        // Walk left from where the hop ended
        this.x = this.walkStartX - this.walkX;
        this.legPhase += dt * 10;
      }

      this.targetY = groundY;
      // While hopping, offset Y by hop arc (negative = up)
      this.y = this.targetY - (this.phase === 'hopping' ? this.hopY : 0);
    }

    draw(ctx) {
      if (this.phase === 'waiting') return;

      const px = Math.floor(this.x);
      const py = Math.floor(this.y);

      ctx.save();
      ctx.imageSmoothingEnabled = false;

      // Shadow
      ctx.fillStyle = 'rgba(0,0,0,0.2)';
      ctx.beginPath();
      ctx.ellipse(px, this.targetY + 2, 8, 3, 0, 0, Math.PI * 2);
      ctx.fill();

      // Legs
      const legSwing = this.phase === 'walking' ? Math.sin(this.legPhase) * 4 : 0;
      ctx.fillStyle = this.pantsColor;
      ctx.fillRect(px - 5 + legSwing, py - 10, 4, 10);
      ctx.fillRect(px + 1 - legSwing, py - 10, 4, 10);

      // Body / Shirt
      ctx.fillStyle = this.color;
      ctx.fillRect(px - 6, py - 24, 12, 14);

      // Head
      ctx.fillStyle = this.skinColor;
      ctx.fillRect(px - 5, py - 34, 10, 10);

      // Hair
      ctx.fillStyle = '#4A3018';
      ctx.fillRect(px - 5, py - 36, 10, 4);

      ctx.restore();
    }

    startHop() {
      if (this.phase === 'waiting') {
        this.phase = 'hopping';
        this.hopPhase = 0;
      }
    }
  }

  function initCharacters() {
    journeyState.characters = [
      new Character('#E74C3C', 0),
      new Character('#3498DB', 0.5),
      new Character('#2ECC71', 1.0),
    ];
  }

  // ========================================================================
  //  EXHAUST PUFF SYSTEM — DOM-based smoke particles
  // ========================================================================
  const exhaustPuffs = [];

  function spawnPuff(x, y) {
    const puff = document.createElement('div');
    puff.className = 'exhaust-puff';
    const size = 4 + Math.random() * 8;
    puff.style.width = size + 'px';
    puff.style.height = size + 'px';
    puff.style.left = x + 'px';
    puff.style.top = y + 'px';
    puffLayer.appendChild(puff);
    exhaustPuffs.push({
      el: puff,
      x: x,
      y: y,
      vx: -20 - Math.random() * 30,
      vy: -10 - Math.random() * 15,
      life: 1.0,
      decay: 0.4 + Math.random() * 0.3,
    });
  }

  function updatePuffs(dt) {
    for (let i = exhaustPuffs.length - 1; i >= 0; i--) {
      const p = exhaustPuffs[i];
      p.life -= p.decay * dt;
      p.x += p.vx * dt;
      p.vy += 20 * dt;
      p.y += p.vy * dt;
      p.el.style.left = p.x + 'px';
      p.el.style.top = p.y + 'px';
      p.el.style.opacity = Math.max(0, p.life * 0.6);
      p.el.style.transform = `scale(${1 + (1 - p.life)})`;
      if (p.life <= 0) {
        p.el.remove();
        exhaustPuffs.splice(i, 1);
      }
    }
  }

  // ========================================================================
  //  DESTINATION SCREEN
  // ========================================================================
  function showDestination() {
    destScreen.style.display = 'flex';
    requestAnimationFrame(() => {
      destScreen.classList.add('active');
    });

    journeyState.autoCountdown = 5;
    const autoInterval = setInterval(() => {
      journeyState.autoCountdown--;
      autoCountdownEl.textContent = journeyState.autoCountdown;
      if (journeyState.autoCountdown <= 0) {
        clearInterval(autoInterval);
        window.location.href = 'https://example.com';
      }
    }, 1000);
  }

  // ========================================================================
  //  COUNTDOWN UI UPDATE
  // ========================================================================
  function updateCountdownUI() {
    const t = journeyState.countdown;
    countdownDisplay.textContent = t.toFixed(2);

    countdownBox.classList.remove('warning', 'danger');
    if (t <= 3) countdownBox.classList.add('danger');
    else if (t <= 5) countdownBox.classList.add('warning');

    if (t <= 0) {
      countdownBox.style.display = 'none';
    }
  }

  // ========================================================================
  //  MAIN RENDER LOOP
  // ========================================================================
  let lastTime = performance.now();
  let elapsed = 0;

  function frame(now) {
    const rawDt = (now - lastTime) / 1000;
    lastTime = now;
    const dt = Math.min(rawDt, 0.05); // cap dt for stability
    elapsed += dt;

    // ======================================================================
    //  STATE MACHINE UPDATE
    // ======================================================================
    const js = journeyState;

    // Countdown
    if (js.busPhase === BUS_PHASES.WAITING) {
      js.countdown -= dt;
      if (js.countdown <= 0) {
        js.countdown = 0;
        js.busPhase = BUS_PHASES.ARRIVING;
      }
      updateCountdownUI();
    }

    // Global speed: scroll hills when waiting, slow when bus arriving, stop when stopped
    if (js.busPhase === BUS_PHASES.WAITING) {
      js.globalSpeed = 1;
    } else if (js.busPhase === BUS_PHASES.ARRIVING) {
      const dist = js.busX - js.busTargetX;
      js.globalSpeed = Math.max(0, Math.min(1, dist / 400));
    } else {
      js.globalSpeed = 0;
    }

    // Bus arrival — smooth deceleration to target
    if (js.busPhase === BUS_PHASES.ARRIVING) {
      const dist = js.busX - js.busTargetX;
      // Ease-out: slower as we approach
      const easeSpeed = Math.max(15, dist * 2.5);
      js.busX -= easeSpeed * dt;
      if (dist < 2) {
        js.busX = js.busTargetX;
        js.busPhase = BUS_PHASES.STOPPED;
        js.busStopTime = elapsed;
      }
    }

    // Character disembark
    if (js.busPhase === BUS_PHASES.STOPPED) {
      const timeSinceStop = elapsed - js.busStopTime;
      js.characters.forEach((c, i) => {
        if (timeSinceStop > i * 0.6) c.startHop();
      });

      if (timeSinceStop > 3.0 && !js.destinationShown) {
        js.destinationShown = true;
        js.busPhase = BUS_PHASES.DONE;
        showDestination();
      }
    }

    // Hill Y at bus position (for bus grounding and puffs)
    const hillYAtBus = getHillY(2, js.busX);

    // Characters are updated inside the bus drawing block above

    // Exhaust puffs (updated in bus animation block above)
    updatePuffs(dt);

    // ======================================================================
    //  UPDATE PROJECT 2 SYSTEMS
    // ======================================================================
    updateGusts(dt);
    const gustMult = getGustMult();

    // Scroll hills (parallax, modulated by globalSpeed)
    for (let l = 0; l < 3; l++) {
      hillOffsets[l] += HILL_LAYERS[l].scrollSpeed * dt * js.globalSpeed;
    }

    // Update wind streaks
    for (const s of windStreaks) s.update(dt, gustMult);

    // Update clouds
    for (const c of clouds) c.update(dt);

    // Update life particles
    for (const p of lifeParticles) p.update(dt, elapsed);

    // Update birds
    updateBirds(dt, elapsed);

    // ======================================================================
    //  CLEAR CANVASES
    // ======================================================================
    bgCtx.clearRect(0, 0, W, H);
    windCtx.clearRect(0, 0, W, H);
    fxCtx.clearRect(0, 0, W, H);
    actorsCtx.clearRect(0, 0, W, H);

    // ======================================================================
    //  DRAW ORDER (new Project 1 order)
    //  drawSky() -> clouds -> BACK_BILLBOARDS -> drawHills() -> drawGrass()
    //  -> wind -> particles + birds -> bus -> characters
    // ======================================================================

    // Re-sample hill points at current offsets
    sampleHills();

    // ---- BG Canvas: clouds, back billboards, hills, middle billboards, grass ----

    // Clouds behind everything
    for (const c of clouds) c.draw(bgCtx);

    // BACK-HILL BILLBOARDS — drawn BEFORE the back hill so they peek over it
    drawBackBillboards(bgCtx);

    // Layer 0: Back hill (darkest, slowest)
    drawSingleHillLayer(bgCtx, 0);

    // Layer 1: Middle hill + BILLBOARDS
    drawSingleHillLayer(bgCtx, 1);
    for (const bb of billboards) bb.draw(bgCtx);

    // Layer 2: Front hill (brightest, fastest)
    drawSingleHillLayer(bgCtx, 2);

    // Grass tufts on front hill
    drawGrass(bgCtx, elapsed, gustMult);

    // ---- Wind Layer: prominent streaks ----
    for (const s of windStreaks) s.draw(windCtx, gustMult);

    // ---- FX Layer: particles + birds ----
    for (const p of lifeParticles) p.draw(fxCtx, elapsed);
    drawBirds(fxCtx);

    // ---- Actors Layer: original goofy bus + characters ----
    if (js.busPhase !== BUS_PHASES.WAITING || js.countdown <= 2) {
      // Original bus: 240x180, centered at js.busX, bottom on hill
      const busLX = js.busX - BUS_DRAW_W / 2;  // left edge
      const busTY = hillYAtBus - BUS_DRAW_H;    // top edge
      const isArriving = js.busPhase === BUS_PHASES.ARRIVING;

      // Draw the original goofy bus
      if (js.busX > -BUS_DRAW_W && js.busX < W + BUS_DRAW_W) {
        drawBus(actorsCtx, busLX, busTY, isArriving);
      }

      // Door position for characters (original door at x + 65, y + 35..55)
      const doorX = busLX + 65 * BUS_SCALE;     // ~busLX + 195
      const doorBottomY = busTY + 55 * BUS_SCALE; // ~busTY + 165 = hillYAtBus - 15

      // Update characters — pass door position so they hop out of the door
      js.characters.forEach(c => c.update(dt, doorX, doorBottomY, hillYAtBus + 28));
    } else {
      // During countdown, keep characters hidden inside the bus area
      js.characters.forEach(c => c.update(dt, 0, 0, 0));
    }

    // Characters
    if (js.busPhase === BUS_PHASES.STOPPED || js.busPhase === BUS_PHASES.DONE) {
      js.characters.forEach(c => c.draw(actorsCtx));
    }

    requestAnimationFrame(frame);
  }

  // ========================================================================
  //  INIT
  // ========================================================================
  window.addEventListener('resize', resize);
  resize();
  initJourney();
  initCharacters();
  initWind();
  initLifeParticles();
  requestAnimationFrame(frame);

})();""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
