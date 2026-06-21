module ConvertedFiles.Src.Components.HeroSceneTsx

let file = """import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

/* ═══════════════════════════════════════════════════════════
   TURTLE HERO v2 — Using actual SVG assets from the user
   
   Shell pieces fall from above using data-start-transform
   values from the animation manifest, landing behind the
   turtle's head/neck thanks to proper depth layering.
   ═══════════════════════════════════════════════════════════ */

/* Shell piece animation data — extracted from animation manifest */
const SHELL_PIECES = [
  { id: 'piece_01_upper_left_edge_panel', delay: 0.60, startTx: -69, startTy: -478, startRot: 10 },
  { id: 'piece_02_upper_right_small_panel', delay: 0.75, startTx: 71, startTy: -474, startRot: -7 },
  { id: 'piece_03_upper_center_panel', delay: 0.45, startTx: 27, startTy: -464, startRot: 5 },
  { id: 'piece_04_upper_center_panel', delay: 0.90, startTx: -34, startTy: -462, startRot: -18 },
  { id: 'piece_05_right_upper_edge_panel', delay: 0.55, startTx: 97, startTy: -439, startRot: -4 },
  { id: 'piece_06_middle_right_hex_panel', delay: 0.30, startTx: 63, startTy: -432, startRot: -22 },
  { id: 'piece_07_center_hex_panel', delay: 0.65, startTx: 7, startTy: -423, startRot: 14 },
  { id: 'piece_08_middle_left_hidden_panel', delay: 0.50, startTx: -31, startTy: -422, startRot: -13 },
  { id: 'piece_09_lower_right_edge_panel', delay: 0.80, startTx: 92, startTy: -399, startRot: -15 },
  { id: 'piece_10_lower_center_panel', delay: 0.40, startTx: 42, startTy: -384, startRot: -14 },
  { id: 'piece_11_lower_left_panel', delay: 0.70, startTx: -9, startTy: -380, startRot: -19 },
  { id: 'piece_12_bottom_rim_long_piece', delay: 1.00, startTx: 48, startTy: -365, startRot: -2 },
];

/* Pre-generated CSS keyframes for all shell piece falling animations */
const SHELL_CSS = `
  @keyframes turtleBodyIn {
    from { opacity: 0; transform: translateY(30px) scale(0.96); }
    to   { opacity: 1; transform: translateY(0) scale(1); }
  }
  @keyframes hatTipIn {
    0%   { opacity: 0; transform: translateY(-60px) rotate(-8deg) scale(0.9); }
    60%  { opacity: 1; transform: translateY(3px) rotate(1deg) scale(1.02); }
    100% { opacity: 1; transform: translateY(0) rotate(0deg) scale(1); }
  }
  @keyframes turtleBounce {
    0%, 100% { transform: translateY(0); }
    50%      { transform: translateY(6px); }
  }
  @keyframes turtleParticleFloat {
    0%, 100% { transform: translateY(0) translateX(0); opacity: 0.15; }
    25%      { transform: translateY(-25px) translateX(8px); opacity: 0.4; }
    50%      { transform: translateY(-12px) translateX(-4px); opacity: 0.25; }
    75%      { transform: translateY(-32px) translateX(6px); opacity: 0.35; }
  }
  @keyframes starTwinkle {
    0%, 100% { opacity: 0.2; transform: scale(1); }
    50%      { opacity: 1; transform: scale(1.3); }
  }
  .shell-piece_01_upper_left_edge_panel { animation: sf_01 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.60s both; }
  .shell-piece_02_upper_right_small_panel { animation: sf_02 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.75s both; }
  .shell-piece_03_upper_center_panel { animation: sf_03 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.45s both; }
  .shell-piece_04_upper_center_panel { animation: sf_04 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.90s both; }
  .shell-piece_05_right_upper_edge_panel { animation: sf_05 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.55s both; }
  .shell-piece_06_middle_right_hex_panel { animation: sf_06 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.30s both; }
  .shell-piece_07_center_hex_panel { animation: sf_07 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.65s both; }
  .shell-piece_08_middle_left_hidden_panel { animation: sf_08 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.50s both; }
  .shell-piece_09_lower_right_edge_panel { animation: sf_09 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.80s both; }
  .shell-piece_10_lower_center_panel { animation: sf_10 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.40s both; }
  .shell-piece_11_lower_left_panel { animation: sf_11 0.75s cubic-bezier(0.32,1.3,0.62,1) 0.70s both; }
  .shell-piece_12_bottom_rim_long_piece { animation: sf_12 0.75s cubic-bezier(0.32,1.3,0.62,1) 1.00s both; }
  @keyframes sf_01 { 0% { opacity:0; transform:translate(-69px,-478px) rotate(10deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(-3deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_02 { 0% { opacity:0; transform:translate(71px,-474px) rotate(-7deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(2deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(-0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_03 { 0% { opacity:0; transform:translate(27px,-464px) rotate(5deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(-1.5deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_04 { 0% { opacity:0; transform:translate(-34px,-462px) rotate(-18deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(5deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(-0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_05 { 0% { opacity:0; transform:translate(97px,-439px) rotate(-4deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(1deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(0deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_06 { 0% { opacity:0; transform:translate(63px,-432px) rotate(-22deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(6deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(-0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_07 { 0% { opacity:0; transform:translate(7px,-423px) rotate(14deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(-4deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_08 { 0% { opacity:0; transform:translate(-31px,-422px) rotate(-13deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(4deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(-0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_09 { 0% { opacity:0; transform:translate(92px,-399px) rotate(-15deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(4deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(-0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_10 { 0% { opacity:0; transform:translate(42px,-384px) rotate(-14deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(4deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(-0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_11 { 0% { opacity:0; transform:translate(-9px,-380px) rotate(-19deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(5deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(-0.5deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
  @keyframes sf_12 { 0% { opacity:0; transform:translate(48px,-365px) rotate(-2deg) scale(0.7); } 50% { opacity:1; } 70% { transform:translate(2px,4px) rotate(0.5deg) scale(1.03); } 85% { transform:translate(-1px,-2px) rotate(0deg) scale(0.99); } 100% { opacity:1; transform:translate(0,0) rotate(0deg) scale(1); } }
`;

export default function HeroScene() {
  const [started, setStarted] = useState(false);
  const [textVisible, setTextVisible] = useState(false);
  const [glowActive, setGlowActive] = useState(false);

  useEffect(() => {
    const t1 = setTimeout(() => setStarted(true), 300);
    const t2 = setTimeout(() => setTextVisible(true), 1600);
    const t3 = setTimeout(() => setGlowActive(true), 2200);
    return () => { clearTimeout(t1); clearTimeout(t2); clearTimeout(t3); };
  }, []);

  return (
    <div style={{ position: 'relative', width: '100%', minHeight: '100dvh', overflow: 'hidden' }}>
      {/* Starry night background */}
      <div style={{ position: 'absolute', inset: 0, background: 'radial-gradient(ellipse at 30% 80%, #1B4332 0%, #0F2E1E 45%, #060F0A 100%)' }} />

      {/* Star field — layered for depth */}
      <div style={{ position: 'absolute', inset: 0, pointerEvents: 'none', overflow: 'hidden' }}>
        {/* Far stars — small, slow twinkle */}
        {[...Array(40)].map((_, i) => (
          <div key={`f${i}`} style={{
            position: 'absolute',
            width: `${1 + (i % 2)}px`,
            height: `${1 + (i % 2)}px`,
            borderRadius: '50%',
            background: i % 7 === 0 ? 'rgba(212,165,116,0.5)' : 'rgba(255,255,255,0.35)',
            left: `${(i * 47 + 13) % 100}%`,
            top: `${(i * 31 + 7) % 100}%`,
            animation: `starTwinkle ${3 + (i % 4)}s ease-in-out ${i * 0.2}s infinite`,
          }} />
        ))}
        {/* Near stars — larger, brighter, different twinkle */}
        {[...Array(15)].map((_, i) => (
          <div key={`n${i}`} style={{
            position: 'absolute',
            width: `${2 + (i % 2)}px`,
            height: `${2 + (i % 2)}px`,
            borderRadius: '50%',
            background: i % 3 === 0 ? 'rgba(233,196,106,0.6)' : 'rgba(255,255,255,0.5)',
            boxShadow: i % 3 === 0 ? '0 0 4px rgba(233,196,106,0.3)' : '0 0 3px rgba(255,255,255,0.2)',
            left: `${(i * 67 + 23) % 100}%`,
            top: `${(i * 53 + 17) % 100}%`,
            animation: `starTwinkle ${2 + (i % 3)}s ease-in-out ${i * 0.35}s infinite`,
          }} />
        ))}
      </div>

      {/* Floating ambient particles (gold dust) */}
      <div style={{ position: 'absolute', inset: 0, pointerEvents: 'none' }}>
        {[...Array(12)].map((_, i) => (
          <div key={i} style={{ position: 'absolute', width: `${2 + (i % 3)}px`, height: `${2 + (i % 3)}px`, borderRadius: '50%', background: 'rgba(212,165,116,0.2)', left: `${(i * 19 + 3) % 100}%`, top: `${(i * 29 + 8) % 100}%`, animation: `turtleParticleFloat ${7 + (i % 4)}s ease-in-out ${i * 0.4}s infinite` }} />
        ))}
      </div>

      {/* Main SVG Scene — inline master turtle with animated shell pieces */}
      <div style={{ position: 'absolute', inset: 0, display: 'flex', alignItems: 'center', justifyContent: 'center', paddingTop: '40px' }}>
        <svg
          viewBox="0 0 1254 1254"
          style={{ width: 'min(92vw, 680px)', height: 'auto', maxHeight: '62vh', filter: 'drop-shadow(0 30px 80px rgba(0,0,0,0.5))' }}
          xmlns="http://www.w3.org/2000/svg"
          role="img"
          aria-label="Turtle Protect mascot getting shelled"
        >
          <defs>
            <linearGradient id="bodyGradient" x1="90" y1="445" x2="830" y2="1100" gradientUnits="userSpaceOnUse">
              <stop offset="0" stopColor="#D5ED3F"/>
              <stop offset="0.55" stopColor="#C1D24E"/>
              <stop offset="1" stopColor="#AEBD39"/>
            </linearGradient>
            <linearGradient id="shellGradient" x1="300" y1="370" x2="1110" y2="920" gradientUnits="userSpaceOnUse">
              <stop offset="0" stopColor="#969F5E"/>
              <stop offset="0.50" stopColor="#7C854A"/>
              <stop offset="1" stopColor="#69723D"/>
            </linearGradient>
            <linearGradient id="hatGradient" x1="280" y1="120" x2="1060" y2="445" gradientUnits="userSpaceOnUse">
              <stop offset="0" stopColor="#956907"/>
              <stop offset="0.58" stopColor="#805A00"/>
              <stop offset="1" stopColor="#6D4A00"/>
            </linearGradient>
            {/* Golden glow for completed shell */}
            <radialGradient id="shellGlowGrad" cx="680" cy="620" r="350" gradientUnits="userSpaceOnUse">
              <stop offset="0" stopColor="rgba(212,165,116,0.35)"/>
              <stop offset="0.6" stopColor="rgba(212,165,116,0.08)"/>
              <stop offset="1" stopColor="rgba(212,165,116,0)"/>
            </radialGradient>
          </defs>

          {/* ═══════ LAYER 1: Body under shell (depth 10) ═══════ */}
          <g style={{ animation: started ? 'turtleBodyIn 0.7s ease-out forwards' : 'none', opacity: 0 }}>
            <path d="M 575 906 L 575 1071 L 623 1078 L 680 1077 L 726 1069 L 750 1057 L 755 1044 L 754 1020 L 741 921 L 748 919 L 650 919 L 608 914 Z" fill="url(#bodyGradient)"/>
            <path d="M 1082 805 L 1017 846 L 975 866 L 930 882 L 933 948 L 945 965 L 979 976 L 1021 976 L 1079 966 L 1095 960 L 1106 951 L 1110 940 L 1109 920 Z" fill="url(#bodyGradient)"/>
            <path d="M 1163 583 L 1153 582 L 1140 586 L 1080 619 L 1098 674 L 1109 722 L 1131 695 L 1168 625 L 1173 600 L 1171 590 Z" fill="url(#bodyGradient)"/>
          </g>

          {/* ═══════ LAYER 2: Shell pieces (depth 30) — animated! ═══════ */}
          {SHELL_PIECES.map((p) => (
            <g
              key={p.id}
              id={p.id}
              className={started ? `shell-${p.id}` : ''}
              style={{ opacity: started ? undefined : 0 }}
            >
              <ShellPiece id={p.id} />
            </g>
          ))}

          {/* Glow ring behind shell (appears after pieces land) */}
          <ellipse cx="680" cy="620" rx="360" ry="310" fill="url(#shellGlowGrad)"
            style={{ opacity: glowActive ? 1 : 0, transition: 'opacity 2s ease-out' }}
          />

          {/* ═══════ LAYER 3: Front head/neck depth mask (depth 40) ═══════ */}
          <g style={{ animation: started ? 'turtleBodyIn 0.7s ease-out 0.1s forwards' : 'none', opacity: 0 }}>
            <path d="M 141 503 L 104 544 L 83 588 L 70 647 L 69 706 L 77 754 L 91 792 L 106 819 L 142 860 L 193 893 L 172 966 L 168 999 L 172 1027 L 178 1033 L 195 1040 L 248 1049 L 299 1049 L 325 1045 L 339 1039 L 348 1023 L 343 931 L 452 939 L 560 940 L 558 1044 L 563 1062 L 574 1070 L 574 906 L 550 896 L 547 811 L 529 721 L 497 629 L 474 584 L 455 557 L 414 513 L 379 487 L 345 472 L 301 461 L 254 460 L 214 467 L 183 478 Z" fill="url(#bodyGradient)"/>
          </g>

          {/* ═══════ LAYER 4: Face (depth 41) ═══════ */}
          <g style={{ animation: started ? 'turtleBodyIn 0.7s ease-out 0.15s forwards' : 'none', opacity: 0 }}>
            {/* Mouth */}
            <path d="M 185 705 L 189 718 L 204 734 L 224 748 L 248 758 L 261 758 L 274 752 L 317 720 L 326 708 L 324 698 L 310 697 L 258 723 L 247 725 L 224 716 L 199 698 L 190 698 Z" fill="#2F3330"/>
            {/* Right eye */}
            <path d="M 328 578 L 314 584 L 303 596 L 298 610 L 298 630 L 303 644 L 315 658 L 330 665 L 344 665 L 355 661 L 367 649 L 373 636 L 374 615 L 368 598 L 359 587 L 345 579 Z" fill="#2F3330"/>
            {/* Left eye */}
            <path d="M 167 576 L 152 582 L 139 596 L 132 613 L 132 631 L 139 648 L 148 657 L 162 663 L 175 663 L 192 655 L 201 645 L 209 625 L 209 610 L 202 591 L 195 583 L 183 577 Z" fill="#2F3330"/>
            {/* Eye shine detail */}
            <path d="M 295 457 L 298 460 L 320 463 L 377 483 L 389 493 L 389 439 L 378 451 L 334 439 L 314 436 Z" fill="#2F3330"/>
          </g>

          {/* ═══════ LAYER 5: Cowboy hat (depth 50) ═══════ */}
          <g style={{ animation: started ? 'hatTipIn 0.8s cubic-bezier(0.32, 1.3, 0.62, 1) 0.3s forwards' : 'none', opacity: 0, transformOrigin: '660px 300px' }}>
            <path d="M 268 241 L 270 262 L 276 278 L 298 314 L 332 349 L 381 383 L 423 403 L 492 424 L 564 436 L 645 442 L 717 441 L 786 434 L 841 423 L 904 402 L 954 375 L 993 346 L 1030 306 L 1047 277 L 1054 255 L 1054 236 L 1047 220 L 1030 208 L 1008 206 L 987 215 L 955 245 L 928 261 L 889 273 L 858 276 L 847 227 L 823 169 L 793 131 L 768 119 L 733 123 L 671 147 L 651 146 L 601 125 L 578 119 L 559 118 L 538 125 L 513 149 L 492 185 L 476 227 L 465 276 L 431 272 L 396 261 L 371 247 L 336 214 L 318 206 L 302 205 L 284 212 L 273 224 Z" fill="url(#hatGradient)"/>
            <path d="M 508 304 L 510 310 L 527 325 L 555 339 L 588 348 L 636 354 L 689 354 L 747 345 L 789 329 L 814 308 L 809 276 L 777 292 L 734 305 L 696 311 L 644 312 L 612 309 L 569 300 L 541 290 L 514 275 Z" fill="#A97814" opacity="0.72"/>
            <path d="M 526 238 L 576 258 L 643 268 L 695 267 L 730 262 L 762 254 L 797 238 L 789 214 L 771 182 L 759 170 L 739 163 L 713 166 L 666 184 L 652 183 L 604 164 L 573 165 L 562 171 L 550 184 L 534 213 Z" fill="#A97814" opacity="0.72"/>
          </g>
        </svg>
      </div>

      {/* Text Overlay */}
      <div style={{ position: 'absolute', inset: 0, display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'flex-end', paddingBottom: 'clamp(2rem, 8vh, 5rem)', zIndex: 10, pointerEvents: 'none', opacity: textVisible ? 1 : 0, transform: textVisible ? 'translateY(0)' : 'translateY(20px)', transition: 'opacity 1s ease-out, transform 1s ease-out' }}>
        <p className="font-body font-medium text-[0.7rem] sm:text-[0.75rem] uppercase tracking-[0.2em] mb-3" style={{ color: '#D4A574' }}>Florida&apos;s Trusted Protection Platform</p>
        <h1 className="font-display font-bold text-white text-center" style={{ fontSize: 'clamp(2rem, 6vw, 4.5rem)', lineHeight: 1.05, letterSpacing: '-0.02em', textShadow: '0 4px 30px rgba(0,0,0,0.5), 0 2px 10px rgba(0,0,0,0.3)', maxWidth: '700px', padding: '0 1.5rem' }}>
          Turtle Protect.
          <br /><span style={{ fontSize: '0.55em', opacity: 0.85, fontWeight: 400 }}>Protect what matters most.</span>
        </h1>
        <p className="font-body text-center mt-4" style={{ color: 'rgba(255,255,255,0.75)', fontSize: 'clamp(0.875rem, 1.5vw, 1.125rem)', maxWidth: '520px', padding: '0 1.5rem', lineHeight: 1.6 }}>Turtle Protect helps Florida families safeguard their homes, health, finances, and futures.</p>
        <div className="flex flex-wrap items-center justify-center" style={{ gap: '0.75rem', marginTop: '1.5rem', pointerEvents: 'auto' }}>
          <Link to="/insurance" className="font-body font-semibold text-white px-6 py-3 rounded-lg transition-all duration-200 hover:scale-105" style={{ background: 'linear-gradient(135deg, #2D6A4F, #3D8A6F)', fontSize: '0.9375rem', boxShadow: '0 4px 16px rgba(45,106,79,0.4)' }}>Explore Protection</Link>
          <Link to="/contact" className="font-body font-semibold text-white px-6 py-3 rounded-lg transition-all duration-200 hover:bg-[rgba(255,255,255,0.2)]" style={{ border: '1px solid rgba(255,255,255,0.3)', fontSize: '0.9375rem', background: 'rgba(255,255,255,0.08)' }}>Free Consultation</Link>
        </div>
      </div>

      {/* Scroll indicator */}
      <div style={{ position: 'absolute', bottom: '1.5rem', left: '50%', transform: 'translateX(-50%)', zIndex: 10, display: 'flex', flexDirection: 'column', alignItems: 'center', color: 'rgba(255,255,255,0.4)', opacity: textVisible ? 1 : 0, transition: 'opacity 1s ease-out 0.5s' }}>
        <span className="font-body text-[0.65rem] mb-1" style={{ animation: 'turtleBounce 2s infinite' }}>Scroll</span>
        <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" style={{ animation: 'turtleBounce 2s infinite' }}><polyline points="6 9 12 15 18 9"/></svg>
      </div>

      {/* CSS Keyframes — injected per-piece for shell falling animation */}
      <style>{SHELL_CSS}</style>
    </div>
  );
}

/* ═══════════════════════════════════════════════════════════
   Shell Piece Component — renders the correct SVG paths
   for each of the 12 shell pieces
   ═══════════════════════════════════════════════════════════ */

function ShellPiece({ id }: { id: string }) {
  const paths = SHELL_PATHS[id];
  if (!paths) return null;
  return (
    <>
      {paths.outlines.map((d: string, i: number) => (
        <path key={`o-${i}`} d={d} fill="#303330" />
      ))}
      {paths.fills.map((d: string, i: number) => (
        <path key={`f-${i}`} d={d} fill="url(#shellGradient)" />
      ))}
    </>
  );
}

/* SVG path data for each shell piece — traced from the master SVG */
const SHELL_PATHS: Record<string, { outlines: string[]; fills: string[] }> = {
  piece_01_upper_left_edge_panel: {
    outlines: ['M 435 397 L 430 391 L 382 368 L 370 368 L 340 390 L 304 425 L 301 438 L 310 448 L 370 463 L 383 463 L 433 413 L 436 407 Z'],
    fills: ['M 422 403 L 375 381 L 340 409 L 315 435 L 378 450 Z'],
  },
  piece_02_upper_right_small_panel: {
    outlines: ['M 873 401 L 870 407 L 873 423 L 884 452 L 894 460 L 973 485 L 982 482 L 1001 457 L 1002 447 L 994 434 L 937 377 L 925 377 Z'],
    fills: ['M 884 410 L 899 447 L 970 471 L 975 469 L 988 451 L 964 421 L 932 390 Z'],
  },
  piece_03_upper_center_panel: {
    outlines: ['M 881 452 L 866 415 L 853 407 L 764 424 L 691 429 L 643 428 L 632 432 L 627 440 L 632 480 L 637 488 L 784 549 L 794 546 L 878 465 Z'],
    fills: ['M 867 455 L 853 421 L 764 438 L 717 442 L 641 443 L 646 477 L 784 535 Z'],
  },
  piece_04_upper_center_panel: {
    outlines: ['M 392 464 L 395 478 L 438 518 L 468 554 L 536 566 L 553 563 L 628 486 L 622 438 L 613 428 L 517 416 L 457 401 L 447 404 L 397 455 Z'],
    fills: ['M 406 467 L 449 509 L 477 543 L 544 552 L 614 483 L 608 441 L 517 430 L 457 415 Z'],
  },
  piece_05_right_upper_edge_panel: {
    outlines: ['M 1002 466 L 984 486 L 983 499 L 1027 640 L 1037 648 L 1083 664 L 1094 664 L 1102 657 L 1103 645 L 1075 569 L 1054 526 L 1021 471 L 1014 466 Z'],
    fills: ['M 1007 479 L 997 492 L 1040 634 L 1089 651 L 1078 615 L 1055 560 L 1031 514 Z'],
  },
  piece_06_middle_right_hex_panel: {
    outlines: ['M 889 465 L 880 468 L 792 554 L 791 564 L 810 684 L 814 692 L 822 697 L 934 735 L 943 732 L 1022 649 L 1023 638 L 976 495 L 943 481 Z'],
    fills: ['M 889 479 L 805 560 L 824 681 L 934 721 L 1009 641 L 965 504 Z'],
  },
  piece_07_center_hex_panel: {
    outlines: ['M 630 495 L 552 573 L 577 710 L 584 721 L 693 779 L 704 779 L 806 694 L 805 670 L 787 563 L 777 552 L 641 495 Z'],
    fills: ['M 635 508 L 566 576 L 591 707 L 699 766 L 793 688 L 772 565 Z'],
  },
  piece_08_middle_left_hidden_panel: {
    outlines: ['M 464 562 L 456 569 L 455 579 L 491 649 L 517 730 L 526 739 L 538 739 L 567 723 L 573 714 L 547 578 L 534 570 Z'],
    fills: ['M 469 575 L 504 643 L 530 724 L 533 726 L 559 711 L 534 584 Z'],
  },
  piece_09_lower_right_edge_panel: {
    outlines: ['M 1084 670 L 1038 653 L 1026 653 L 946 734 L 941 750 L 948 807 L 954 817 L 970 819 L 1019 794 L 1062 764 L 1093 734 L 1099 724 L 1099 713 Z'],
    fills: ['M 1075 681 L 1031 666 L 955 747 L 963 806 L 994 792 L 1032 769 L 1059 748 L 1082 725 L 1085 716 Z'],
  },
  piece_10_lower_center_panel: {
    outlines: ['M 936 747 L 925 738 L 820 701 L 803 703 L 705 786 L 703 801 L 707 866 L 713 873 L 722 876 L 794 869 L 878 851 L 939 831 L 945 822 Z'],
    fills: ['M 923 753 L 812 714 L 718 792 L 720 860 L 754 860 L 806 853 L 873 838 L 930 820 Z'],
  },
  piece_11_lower_left_panel: {
    outlines: ['M 528 751 L 525 765 L 533 806 L 536 844 L 543 855 L 582 866 L 632 874 L 687 876 L 698 871 L 701 865 L 699 797 L 693 784 L 584 726 L 571 726 Z'],
    fills: ['M 539 760 L 552 844 L 623 859 L 687 862 L 684 795 L 579 739 Z'],
  },
  piece_12_bottom_rim_long_piece: {
    outlines: ['M 1125 739 L 1116 729 L 1104 729 L 1053 776 L 1007 806 L 944 835 L 869 859 L 796 874 L 725 881 L 628 878 L 591 872 L 552 861 L 539 869 L 537 899 L 543 908 L 583 922 L 667 933 L 774 930 L 891 908 L 932 896 L 998 870 L 1075 826 L 1096 809 L 1118 783 L 1125 761 Z'],
    fills: ['M 1111 742 L 1062 787 L 1016 817 L 949 848 L 874 872 L 796 888 L 725 895 L 628 892 L 586 885 L 552 875 L 551 896 L 588 909 L 621 915 L 667 919 L 733 919 L 811 911 L 886 895 L 975 865 L 1017 845 L 1066 815 L 1087 798 L 1105 777 L 1111 758 Z'],
  },
};
"""

let render() = file
