module Muz.Source.Toolkit.ColorfulJs

let file = """import { encodePNG } from './png.js';
import { rat, real } from './time.js';
import { PITCH_NAMES } from './analysis.js';

const TAU = Math.PI * 2, clamp = (v, lo = 0, hi = 1) => Math.max(lo, Math.min(hi, v));
const mod = (n, d) => ((n % d) + d) % d;
export const fifthAngle = pitch => TAU * mod(7 * pitch, 12) / 12;
export function circularMoment(weights) {
  const total = weights.reduce((a, b) => a + b, 0);
  if (!total) return { re: 0, im: 0, magnitude: 0, phase: 0 };
  const re = weights.reduce((a, w, p) => a + w * Math.cos(fifthAngle(p)), 0) / total;
  const im = weights.reduce((a, w, p) => a + w * Math.sin(fifthAngle(p)), 0) / total;
  return { re, im, magnitude: Math.hypot(re, im), phase: Math.atan2(im, re) };
}

export function colorFeatures(rawNotes, study, bins) {
  const start = real(rat(study.window.start)), end = real(rat(study.window.end));
  if (!(end > start)) throw Error('There is no positive musical span to draw.');
  const width = (end - start) / bins, weights = Array.from({ length: 12 }, () => new Float64Array(bins));
  const energy = new Float64Array(bins), pitches = new Float64Array(bins), attacks = new Float64Array(bins);
  const excluded = new Set(study.counts.excludedTracks), notes = [];
  for (const n of rawNotes) {
    if (n.clock || excluded.has(n.track) || n.velocity <= 0) continue;
    const at = real(rat(n.at)), stop = at + real(rat(n.dur));
    if (stop <= start || at >= end || stop <= at) continue;
    const note = { ...n, at, end: stop }; notes.push(note);
    if (at >= start) attacks[Math.min(bins - 1, Math.floor((at - start) / width))]++;
    const first = clamp(Math.floor((at - start) / width), 0, bins - 1), last = clamp(Math.ceil((stop - start) / width) - 1, 0, bins - 1);
    for (let i = first; i <= last; i++) {
      const weight = Math.max(0, Math.min(stop, start + (i + 1) * width) - Math.max(at, start + i * width)) / width * n.velocity;
      energy[i] += weight; pitches[i] += n.pitch * weight;
      if (Math.abs(n.pitch - Math.round(n.pitch)) < 1e-6) weights[mod(Math.round(n.pitch), 12)][i] += weight;
    }
  }
  const moments = [], entropy = [], friction = [], motion = [];
  const severity = [0, .95, .6, .15, .15, .1, .85];
  for (let i = 0; i < bins; i++) {
    const w = weights.map(p => p[i]), total = w.reduce((a, b) => a + b, 0), z = circularMoment(w);
    moments.push(z);
    entropy.push(total ? -w.reduce((a, value) => value ? a + value / total * Math.log(value / total) : a, 0) / Math.log(12) : 0);
    let tension = 0, pairs = 0;
    for (let p = 0; p < 12; p++) for (let q = p + 1; q < 12; q++) {
      const pair = w[p] * w[q], distance = q - p;
      tension += pair * severity[Math.min(distance, 12 - distance)]; pairs += pair;
    }
    friction.push(pairs ? tension / pairs : 0);
    const previous = moments[i - 1];
    const delta = previous ? Math.abs(Math.atan2(Math.sin(z.phase - previous.phase), Math.cos(z.phase - previous.phase))) : 0;
    motion.push(previous ? delta / Math.PI * Math.min(z.magnitude, previous.magnitude) : 0);
    if (energy[i]) pitches[i] /= energy[i];
  }
  return { start, end, binBeats: width, weights, energy, pitches, attacks, moments, entropy, friction, motion, notes };
}

function hsv(h, s, v) {
  h = mod(h, 1) * 6;
  const c = v * s, x = c * (1 - Math.abs(h % 2 - 1)), m = v - c;
  const values = h < 1 ? [c, x, 0] : h < 2 ? [x, c, 0] : h < 3 ? [0, c, x] : h < 4 ? [0, x, c] : h < 5 ? [x, 0, c] : [c, 0, x];
  return values.map(n => Math.round(255 * (n + m)));
}

// Tiny local raster font keeps exports deterministic and dependency-free.
// Unicode titles are retained losslessly in PNG metadata / the JSON result.
const FONT = {
  A: ['01110','10001','10001','11111','10001','10001','10001'], B: ['11110','10001','10001','11110','10001','10001','11110'], C: ['01111','10000','10000','10000','10000','10000','01111'], D: ['11110','10001','10001','10001','10001','10001','11110'],
  E: ['11111','10000','10000','11110','10000','10000','11111'], F: ['11111','10000','10000','11110','10000','10000','10000'], G: ['01111','10000','10000','10111','10001','10001','01111'], H: ['10001','10001','10001','11111','10001','10001','10001'],
  I: ['11111','00100','00100','00100','00100','00100','11111'], J: ['00111','00010','00010','00010','10010','10010','01100'], K: ['10001','10010','10100','11000','10100','10010','10001'], L: ['10000','10000','10000','10000','10000','10000','11111'],
  M: ['10001','11011','10101','10101','10001','10001','10001'], N: ['10001','11001','10101','10011','10001','10001','10001'], O: ['01110','10001','10001','10001','10001','10001','01110'], P: ['11110','10001','10001','11110','10000','10000','10000'],
  Q: ['01110','10001','10001','10001','10101','10010','01101'], R: ['11110','10001','10001','11110','10100','10010','10001'], S: ['01111','10000','10000','01110','00001','00001','11110'], T: ['11111','00100','00100','00100','00100','00100','00100'],
  U: ['10001','10001','10001','10001','10001','10001','01110'], V: ['10001','10001','10001','10001','10001','01010','00100'], W: ['10001','10001','10001','10101','10101','10101','01010'], X: ['10001','10001','01010','00100','01010','10001','10001'],
  Y: ['10001','10001','01010','00100','00100','00100','00100'], Z: ['11111','00001','00010','00100','01000','10000','11111'],
  0: ['01110','10001','10011','10101','11001','10001','01110'], 1: ['00100','01100','00100','00100','00100','00100','01110'], 2: ['01110','10001','00001','00010','00100','01000','11111'], 3: ['11110','00001','00001','01110','00001','00001','11110'],
  4: ['00010','00110','01010','10010','11111','00010','00010'], 5: ['11111','10000','10000','11110','00001','00001','11110'], 6: ['01110','10000','10000','11110','10001','10001','01110'], 7: ['11111','00001','00010','00100','01000','01000','01000'],
  8: ['01110','10001','10001','01110','10001','10001','01110'], 9: ['01110','10001','10001','01111','00001','00001','01110'],
  ':': ['00000','00100','00100','00000','00100','00100','00000'], '.': ['00000','00000','00000','00000','00000','00100','00100'], '-': ['00000','00000','00000','11111','00000','00000','00000'], '/': ['00001','00010','00010','00100','01000','01000','10000'],
  '#': ['01010','11111','01010','01010','11111','01010','00000'], '+': ['00000','00100','00100','11111','00100','00100','00000'], '=': ['00000','00000','11111','00000','11111','00000','00000'], '?': ['01110','10001','00001','00010','00100','00000','00100'],
  ',': ['00000','00000','00000','00000','00100','00100','01000'],
};
class Raster {
  constructor(w, h) { this.w = w; this.h = h; this.pixels = new Uint8Array(w * h * 4); this.rect(0, 0, w, h, [10, 16, 24]); }
  pixel(x, y, color, alpha = 1) {
    x = Math.round(x); y = Math.round(y); if (x < 0 || y < 0 || x >= this.w || y >= this.h) return;
    const at = (y * this.w + x) * 4;
    for (let c = 0; c < 3; c++) this.pixels[at + c] = Math.round(this.pixels[at + c] * (1 - alpha) + color[c] * alpha);
    this.pixels[at + 3] = 255;
  }
  rect(x, y, w, h, color, alpha = 1) { for (let j = Math.max(0, Math.floor(y)); j < Math.min(this.h, y + h); j++) for (let i = Math.max(0, Math.floor(x)); i < Math.min(this.w, x + w); i++) this.pixel(i, j, color, alpha); }
  line(x1, y1, x2, y2, color, alpha = 1, thick = 1) {
    const steps = Math.max(1, Math.ceil(Math.max(Math.abs(x2 - x1), Math.abs(y2 - y1))));
    for (let s = 0; s <= steps; s++) this.rect(x1 + (x2 - x1) * s / steps - thick / 2, y1 + (y2 - y1) * s / steps - thick / 2, thick, thick, color, alpha);
  }
  circle(cx, cy, radius, color, alpha = 1) { for (let i = 1; i <= 240; i++) this.line(cx + radius * Math.cos(TAU * (i - 1) / 240), cy + radius * Math.sin(TAU * (i - 1) / 240), cx + radius * Math.cos(TAU * i / 240), cy + radius * Math.sin(TAU * i / 240), color, alpha); }
  text(text, x, y, color = [181, 199, 214], scale = 2) {
    let offset = 0;
    for (const c of String(text).toUpperCase()) {
      const glyph = FONT[c] || (c === ' ' ? null : FONT['?']);
      if (glyph) for (let j = 0; j < 7; j++) for (let i = 0; i < 5; i++) if (glyph[j][i] === '1') this.rect(x + offset + i * scale, y + j * scale, scale, scale, color);
      offset += 6 * scale;
    }
  }
}

export function colorfulPNG(info, rawNotes, study, options = {}, provenance = {}) {
  const width = options.width || 1600, height = 1080;
  if (!Number.isInteger(width) || width < 1200 || width > 2400) throw Error('Colorful width must be 1200..2400 pixels.');
  const pitchMin = options.pitchMin ?? 24, pitchMax = options.pitchMax ?? 96;
  if (!Number.isInteger(pitchMin) || !Number.isInteger(pitchMax) || pitchMin < 0 || pitchMax > 127 || pitchMin >= pitchMax) throw Error('Invalid colorful MIDI pitch range.');
  const canvas = new Raster(width, height), x = 164, w = width - 504, right = x + w + 44;
  const f = colorFeatures(rawNotes, study, w), xp = beat => x + (beat - f.start) / (f.end - f.start) * w;
  const ink = [194, 212, 225], muted = [108, 134, 155], grid = [32, 49, 65];
  const panels = [{ y: 156, h: 240 }, { y: 448, h: 184 }, { y: 684, h: 88 }, { y: 830, h: 104 }];
  canvas.text('MUZ / COLORFUL', 32, 28, [201, 238, 232], 3);
  canvas.text((info.title || 'Untitled').slice(0, 65), 32, 68, muted, 2);
  canvas.text(`MEASURES ${study.window.fromMeasure}-${study.measures.at(-1)?.measure || 0}  /  ${study.basis}  /  QUARTER-NOTE BEATS`, 32, 108, muted, 1);
  for (const p of panels) canvas.rect(x, p.y, w, p.h, [14, 23, 34]);
  canvas.text('FIFTHS', 24, 164, ink, 2); canvas.text('FIELD', 24, 188, ink, 2);
  canvas.text('PITCH /', 24, 456, ink, 2); canvas.text('REGISTER', 24, 480, ink, 2);
  canvas.text('RHYTHM', 24, 690, ink, 2); canvas.text('ONSETS', 24, 714, muted, 1);
  canvas.text('TENSION', 24, 838, ink, 2); canvas.text('+ MOTION', 24, 862, muted, 1);
  // Circular von Mises kernels, expressible as complex unit-circle projection:
  // K(theta,p)=exp(6*(Re(exp(i*theta)*conj(exp(i*theta_p)))-1)).
  const kernels = Array.from({ length: 240 }, (_, y) => Array.from({ length: 12 }, (_, p) => Math.exp(6 * (Math.cos(TAU * y / 240 - fifthAngle(p)) - 1))));
  for (let i = 0; i < w; i++) {
    const total = f.weights.reduce((sum, row) => sum + row[i], 0);
    if (!total) continue;
    const density = 1 - Math.exp(-f.energy[i] / 3);
    for (let j = 0; j < 240; j++) {
      let field = 0; for (let p = 0; p < 12; p++) field += f.weights[p][i] / total * kernels[j][p];
      const strength = clamp(Math.pow(field, .65) * (.45 + .55 * density));
      canvas.pixel(x + i, 156 + j, hsv(j / 240, .72, .08 + .92 * strength));
    }
  }
  for (let i = 0; i < 12; i++) {
    const p = mod(i * 7, 12), y = 156 + i * 20;
    canvas.text(PITCH_NAMES[p], 130, y + 4, hsv(i / 12, .55, .9), 1);
    canvas.line(x, y, x + w, y, [150, 175, 190], .1);
  }
  const pitchY = p => 632 - (p - pitchMin) / (pitchMax - pitchMin) * 184;
  for (let p = Math.ceil(pitchMin / 12) * 12; p <= pitchMax; p += 12) {
    const y = pitchY(p); canvas.line(x, y, x + w, y, grid); canvas.text(`C${Math.floor(p / 12) - 1}`, 128, y - 3, muted, 1);
  }
  let outsideRegister = 0;
  for (const n of f.notes) {
    if (n.pitch < pitchMin || n.pitch > pitchMax) { outsideRegister++; continue; }
    const left = clamp(xp(n.at), x, x + w - 1), stop = clamp(xp(n.end), x, x + w);
    const color = hsv(fifthAngle(mod(n.pitch, 12)) / TAU, .6, .45 + .5 * n.velocity);
    canvas.rect(left, clamp(pitchY(n.pitch) - 1, 448, 630), Math.max(1, stop - left), Math.max(2, 184 / (pitchMax - pitchMin)), color, .82);
  }
  // Fixed-scale onset impulses and feature curves preserve comparison across files.
  const trace = (values, panel, color, transform = v => v) => {
    for (let i = 1; i < w; i++) canvas.line(x + i - 1, panel.y + panel.h - clamp(transform(values[i - 1])) * (panel.h - 8) - 4, x + i, panel.y + panel.h - clamp(transform(values[i])) * (panel.h - 8) - 4, color, .95, 2);
  };
  for (let i = 0; i < w; i++) if (f.attacks[i]) {
    const strength = 1 - Math.exp(-f.attacks[i] / 3), color = hsv(.48 + .3 * strength, .65, .6 + .4 * strength);
    canvas.rect(x + i, 768 - 80 * strength, 2, 80 * strength, color);
  }
  trace(f.entropy, panels[3], [89, 187, 237]); trace(f.friction, panels[3], [246, 119, 154]); trace(f.motion, panels[3], [238, 201, 101]);
  for (const bar of study.measures) {
    const at = xp(real(rat(bar.start)));
    for (const p of panels) canvas.line(at, p.y, at, p.y + p.h, [103, 137, 158], .3);
    const step = Math.max(1, Math.ceil(study.measures.length / Math.floor(w / 45)));
    if ((bar.measure - study.window.fromMeasure) % step === 0) canvas.text(String(bar.measure), at + 4, 412, muted, 1);
  }
  canvas.text('MEASURE', x, 136, muted, 1);
  const cx = right + 114, cy = 285, radius = 87;
  canvas.text('COMPLEX TONAL PATH', right, 158, ink, 1);
  canvas.circle(cx, cy, radius, grid); canvas.circle(cx, cy, radius * .5, grid);
  canvas.line(cx - radius, cy, cx + radius, cy, grid); canvas.line(cx, cy - radius, cx, cy + radius, grid);
  for (let i = 0; i < 12; i++) {
    const angle = fifthAngle(i) - Math.PI / 2;
    canvas.text(PITCH_NAMES[i], cx + (radius + 18) * Math.cos(angle) - 5, cy + (radius + 18) * Math.sin(angle) - 3, hsv(fifthAngle(i) / TAU, .55, .95), 1);
  }
  for (let i = 1; i < w; i++) {
    if (!f.energy[i] || !f.energy[i - 1]) continue;
    const a = f.moments[i - 1], b = f.moments[i];
    canvas.line(cx + radius * a.im, cy - radius * a.re, cx + radius * b.im, cy - radius * b.re, hsv(.48 + .4 * i / w, .55, .95), .6, 2);
  }
  const aggregate = circularMoment(f.weights.map(row => row.reduce((a, b) => a + b, 0)));
  canvas.line(cx, cy, cx + radius * aggregate.im, cy - radius * aggregate.re, [233, 245, 248], 1, 2);
  canvas.text('RADIUS = FIFTHS', right, 412, muted, 1); canvas.text('CONCENTRATION', right, 428, muted, 1);
  canvas.text('TRACE: EARLY TO LATE', right, 452, muted, 1);
  for (let i = 0; i < 220; i++) canvas.rect(right + i, 472, 1, 8, hsv(.48 + .4 * i / 219, .55, .95));
  const lines = [
    `NOTES: ${f.notes.length}`, `MEASURES: ${study.totalMeasures}`,
    `BASIS: ${study.basis}`, `FIELD: ${study.complete ? 'COMPLETE' : 'INCOMPLETE'}`,
    `NEXT: ${study.window.nextMeasure ?? 'END'}`, `PITCH: ${pitchMin}-${pitchMax}`,
    `OUTSIDE PITCH: ${outsideRegister}`, '12-TET PITCH CLASSES', 'NO TIMBRE CLASSIFIER',
  ];
  lines.forEach((line, i) => canvas.text(line, right, 526 + i * 24, i === 3 && !study.complete ? [245, 170, 110] : muted, 1));
  canvas.text('BLUE: CLASS ENTROPY', right, 830, [89, 187, 237], 1);
  canvas.text('PINK: INTERVAL FRICTION', right, 852, [246, 119, 154], 1);
  canvas.text('GOLD: PHASE MOTION', right, 874, [238, 201, 101], 1);
  canvas.text('NOT A QUALITY SCORE', right, 914, ink, 1);
  canvas.line(32, 974, width - 32, 974, grid);
  canvas.text('HUE = CIRCLE OF FIFTHS / BRIGHTNESS = DURATION X VELOCITY / SILENCE = DARK', 32, 998, muted, 1);
  canvas.text(`SOURCE ${(provenance.sourceRevision || 'IN-MEMORY').slice(0, 16)} / ENGINE ${(provenance.engine?.revision || 'UNKNOWN').slice(0, 16)} / EXACT NOTES, HEURISTIC INTERPRETATION`, 32, 1024, muted, 1);
  const metadata = {
    format: 'muz-colorful/1', title: info.title, width, height, sourceRevision: provenance.sourceRevision,
    engine: provenance.engine, basis: study.basis, window: study.window, complete: study.complete,
    unit: 'quarter-note beats', binBeats: f.binBeats, pitchMin, pitchMax, outsideRegister,
    math: { pitchAngle: 'theta_p = 2*pi*((7*p) mod 12)/12', moment: 'z(t)=sum(w_p(t)*exp(i*theta_p))/sum(w_p(t))', field: 'K(theta,p)=exp(6*(cos(theta-theta_p)-1)); H=sum(w_p*K)/sum(w_p)', entropy: '-sum(a_p*ln(a_p))/ln(12)', intervalWeights: [0, .95, .6, .15, .15, .1, .85], motion: 'abs(wrapped phase difference)/pi * min(adjacent |z|)' },
    limitations: [...study.limitations, 'Feature brightness uses note attack velocity, not audio loudness. Unit-circle concentration is not consonance or certainty.', 'The gradient is a documented mathematical projection, not a claim about how Beethoven or any listener perceived a piece.', 'Bitmap labels use uppercase ASCII; full Unicode title is retained in PNG metadata.'],
  };
  return { bytes: encodePNG(width, height, canvas.pixels, metadata), metadata };
}
"""

let render() = file
