module Muz.Source.Toolkit.AnalysisJs

let file = """import { rat, add, sub, mul, cmp, min, max, real, exact, zero } from './time.js';

export const PITCH_NAMES = ['C', 'C#', 'D', 'Eb', 'E', 'F', 'F#', 'G', 'Ab', 'A', 'Bb', 'B'];
export const SCALES = {
  major: [0, 2, 4, 5, 7, 9, 11], minor: [0, 2, 3, 5, 7, 8, 10],
  harmonic_minor: [0, 2, 3, 5, 7, 8, 11], melodic_minor: [0, 2, 3, 5, 7, 9, 11],
  dorian: [0, 2, 3, 5, 7, 9, 10], phrygian: [0, 1, 3, 5, 7, 8, 10],
  lydian: [0, 2, 4, 6, 7, 9, 11], mixolydian: [0, 2, 4, 5, 7, 9, 10],
  locrian: [0, 1, 3, 5, 6, 8, 10], whole_tone: [0, 2, 4, 6, 8, 10],
};
const mod = (n, d = 12) => ((n % d) + d) % d;
const rounded = n => Math.round(n * 1e6) / 1e6;
const average = xs => xs.length ? xs.reduce((a, b) => a + b, 0) / xs.length : 0;
const deviation = xs => Math.sqrt(average(xs.map(x => (x - average(xs)) ** 2)));
const pitched = n => Math.abs(n.pitch - Math.round(n.pitch)) < 1e-6;
const pc = n => mod(Math.round(n.pitch));
const ref = n => ({ track: n.track, index: n.index, key: n.key, pitch: n.pitch });

export function keyDefinition(key) {
  if (!key) return null;
  if (typeof key !== 'object' || !SCALES[key.mode]) throw Error('key requires tonic and a supported mode (see muz_reference analysis).');
  const match = /^([A-Ga-g])([#b]?)$/.exec(key.tonic || '');
  if (!match) throw Error('Key tonic must be a pitch name such as C, F# or Bb.');
  const root = mod({ C: 0, D: 2, E: 4, F: 5, G: 7, A: 9, B: 11 }[match[1].toUpperCase()] + (match[2] === '#' ? 1 : match[2] === 'b' ? -1 : 0));
  return { tonic: key.tonic, mode: key.mode, root, pitchClasses: SCALES[key.mode].map(p => mod(root + p)) };
}

// Explicit heuristic, not a trained classifier or a claim about tonal intent.
// Scale coverage has priority; tonic/third/fifth support only breaks close fits.
export function keyCandidates(weights) {
  const sum = weights.reduce((a, b) => a + b, 0);
  if (!sum) return [];
  const candidates = [];
  for (let root = 0; root < 12; root++) for (const mode of ['major', 'minor']) {
    const scale = SCALES[mode].map(p => mod(root + p));
    const coverage = scale.reduce((a, p) => a + weights[p], 0) / sum;
    const support = (weights[root] + .6 * weights[mod(root + (mode === 'major' ? 4 : 3))] + .4 * weights[mod(root + 7)]) / sum;
    candidates.push({ tonic: PITCH_NAMES[root], mode, coverage: rounded(coverage), fit: rounded(.85 * coverage + .15 * support) });
  }
  return candidates.sort((a, b) => b.fit - a.fit || b.coverage - a.coverage || a.tonic.localeCompare(b.tonic)).slice(0, 3);
}

const CHORDS = [
  ['', [0, 4, 7]], ['m', [0, 3, 7]], ['dim', [0, 3, 6]], ['aug', [0, 4, 8]],
  ['sus2', [0, 2, 7]], ['sus4', [0, 5, 7]], ['5', [0, 7]],
  ['7', [0, 4, 7, 10]], ['maj7', [0, 4, 7, 11]], ['m7', [0, 3, 7, 10]],
  ['m(maj7)', [0, 3, 7, 11]], ['m7b5', [0, 3, 6, 10]], ['dim7', [0, 3, 6, 9]],
];
export function chordCandidates(pitches) {
  const pcs = [...new Set(pitches.map(p => mod(Math.round(p))))].sort((a, b) => a - b);
  const bass = mod(Math.round(Math.min(...pitches))), result = [];
  if (pcs.length < 2 || pitches.some(p => Math.abs(p - Math.round(p)) >= 1e-6)) return [];
  for (const root of pcs) for (const [suffix, intervals] of CHORDS) {
    if (pcs.length === intervals.length && intervals.every(p => pcs.includes(mod(root + p)))) {
      result.push({ symbol: `${PITCH_NAMES[root]}${suffix}${bass === root ? '' : '/' + PITCH_NAMES[bass]}`, root, bass, quality: suffix || 'major', rootInBass: bass === root });
    }
  }
  return result.sort((a, b) => Number(b.rootInBass) - Number(a.rootInBass)).slice(0, 3);
}

function meterLength(meter) {
  if (!Array.isArray(meter) || meter.length !== 2 || !meter.every(x => Number.isInteger(x) && x > 0 && x <= 128)) throw Error('Invalid meter.');
  return mul(rat(meter[0]), rat([4, meter[1]]));
}

export function measureGrid(info, end) {
  const sections = (info.sections || []).map(s => ({ ...s, a: rat(s.start), b: rat(s.end) }));
  const boundaries = new Map([['0', zero], [exact(end), end]]);
  for (const s of sections) for (const at of [s.a, s.b]) if (cmp(at, zero) > 0 && cmp(at, end) < 0) boundaries.set(exact(at), at);
  const points = [...boundaries.values()].sort(cmp), regions = [];
  for (let i = 0; i + 1 < points.length; i++) {
    const meters = sections.filter(s => cmp(s.a, points[i]) <= 0 && cmp(s.b, points[i]) > 0).map(s => s.meter);
    if (new Set(meters.map(m => m.join('/'))).size > 1) throw Error('Overlapping sections declare conflicting meters; inspect sections before analyzing.');
    const meter = meters[0] || info.meter;
    meterLength(meter);
    if (regions.at(-1)?.meter.join('/') === meter.join('/')) regions.at(-1).end = points[i + 1];
    else regions.push({ start: points[i], end: points[i + 1], meter });
  }
  const bars = [];
  for (const r of regions) {
    const width = meterLength(r.meter);
    for (let at = r.start; cmp(at, r.end) < 0;) {
      const stop = min(add(at, width), r.end);
      bars.push({ number: bars.length + 1, start: at, end: stop, meter: r.meter, partial: cmp(sub(stop, at), width) !== 0 });
      if (bars.length > 8192) throw Error('Measure map exceeds 8192 measures.');
      at = stop;
    }
  }
  return bars;
}

function sounding(notes, start, end) { return notes.filter(n => cmp(n.a, end) < 0 && cmp(n.b, start) > 0); }
function eventsFor(notes, start, end) {
  const events = [];
  for (const n of notes) { events.push({ at: max(start, n.a), on: true, n }, { at: min(end, n.b), on: false, n }); }
  return events.sort((a, b) => cmp(a.at, b.at) || Number(a.on) - Number(b.on));
}
function slices(notes, start, end) {
  const events = eventsFor(notes, start, end), active = new Set(), result = [];
  let at = start, maxPolyphony = 0;
  for (const event of events) {
    if (cmp(event.at, at) > 0) result.push({ at, end: event.at, notes: [...active] });
    event.on ? active.add(event.n) : active.delete(event.n);
    if (active.size > 512) throw Error('Analysis polyphony exceeds 512 voices; narrow the measure window or exclude tracks.');
    maxPolyphony = Math.max(maxPolyphony, active.size); at = event.at;
  }
  if (cmp(at, end) < 0) result.push({ at, end, notes: [...active] });
  return { result, maxPolyphony };
}

export function analyze(info, rawNotes, options = {}) {
  const { basis = 'score', fromMeasure = 1, measureCount = 32, findingOffset = 0, findingLimit = 100, intent = {} } = options;
  for (const [name, value, low, high] of [['fromMeasure', fromMeasure, 1, 8192], ['measureCount', measureCount, 1, 256], ['findingOffset', findingOffset, 0, 1_000_000], ['findingLimit', findingLimit, 1, 1000]]) if (!Number.isInteger(value) || value < low || value > high) throw Error(`${name} must be ${low}..${high}.`);
  if (!['score', 'performance'].includes(basis)) throw Error('basis must be score or performance.');
  const known = new Set((basis === 'score' ? info.scoreTracks : info.performedTracks).map(t => t.id));
  const excluded = new Set(options.excludeTracks || []);
  for (const id of excluded) if (!known.has(id)) throw Error(`Unknown excluded ${basis} track: ${id}`);
  for (const name of ['ranges', 'maxLeap', 'maxPolyphony']) for (const id of Object.keys(intent[name] || {})) if (!known.has(id)) throw Error(`Unknown intent track: ${id}`);
  if (intent.phraseMeasures !== undefined && (!Number.isInteger(intent.phraseMeasures) || intent.phraseMeasures < 1)) throw Error('phraseMeasures must be a positive integer.');
  for (const [id, range] of Object.entries(intent.ranges || {})) if (!Array.isArray(range) || range.length !== 2 || !range.every(Number.isFinite) || range[0] > range[1]) throw Error(`Invalid pitch range for ${id}.`);
  for (const name of ['maxLeap', 'maxPolyphony']) for (const value of Object.values(intent[name] || {})) if (!Number.isFinite(value) || value < 0 || (name === 'maxPolyphony' && !Number.isInteger(value))) throw Error(`Invalid ${name} constraint.`);
  const key = keyDefinition(intent.key), intervals = options.intervals || [1, 6];
  if (intent.strictKey && !key) throw Error('strictKey requires an explicit key.');
  if (!Array.isArray(intervals) || !intervals.every(x => Number.isInteger(x) && x >= 1 && x <= 6)) throw Error('intervals must contain interval classes 1..6.');
  const minOverlap = rat(options.minOverlap ?? '1/8');
  if (cmp(minOverlap, zero) < 0) throw Error('minOverlap cannot be negative.');
  const allNotes = rawNotes.map(n => ({ ...n, a: rat(n.at), b: add(rat(n.at), rat(n.dur)) }));
  let end = info.scoreTracks.some(t => t.span) ? info.scoreTracks.reduce((span, t) => t.span ? max(span, rat(t.span)) : span, zero) : rat(info.beats || 0);
  if (basis === 'performance') for (const t of info.performedTracks) end = max(end, rat(t.end ?? t.endBeat));
  for (const n of allNotes) end = max(end, n.b);
  const bars = measureGrid(info, end), selected = bars.slice(fromMeasure - 1, fromMeasure - 1 + measureCount);
  if (bars.length && !selected.length) throw Error(`fromMeasure exceeds ${bars.length} measures.`);
  const start = selected[0]?.start || zero, stop = selected.at(-1)?.end || zero;
  const clockNotes = allNotes.filter(n => n.clock), microtonalNotes = allNotes.filter(n => !pitched(n));
  // Clock-placed notes do not have an honest notated-beat location; omit them
  // explicitly instead of pretending their placement is the score coordinate.
  const notes = sounding(allNotes.filter(n => !excluded.has(n.track) && !n.clock && n.velocity > 0 && cmp(n.b, n.a) > 0), start, stop).sort((a, b) => cmp(a.a, b.a) || a.pitch - b.pitch);
  let total = 0, pairChecks = 0, complete = clockNotes.length === 0;
  const findings = [], counts = { error: 0, warning: 0, info: 0 };
  const addFinding = finding => { counts[finding.severity]++; if (total >= findingOffset && findings.length < findingLimit) findings.push(finding); total++; };
  const position = at => {
    const bar = bars.find(b => cmp(at, b.start) >= 0 && cmp(at, b.end) < 0);
    return { measure: bar?.number ?? null, beat: bar ? exact(add(sub(at, bar.start), rat(1))) : null, at: exact(at) };
  };
  if (intent.expectedBeats !== undefined && cmp(end, rat(intent.expectedBeats)) !== 0) addFinding({ severity: 'error', code: 'intent.duration', expected: exact(rat(intent.expectedBeats)), actual: exact(end), message: 'Compiled span differs from the explicitly requested quarter-note beat count.' });
  if (intent.phraseMeasures && (bars.length % intent.phraseMeasures || bars.some(b => b.partial))) addFinding({ severity: 'warning', code: 'form.partial_phrase', message: `Form does not contain only complete ${intent.phraseMeasures}-measure groups; this may be intentional.`, measures: bars.length });
  for (const n of notes) {
    const range = intent.ranges?.[n.track];
    if (range && (n.pitch < range[0] || n.pitch > range[1])) addFinding({ severity: 'error', code: 'intent.range', ...position(n.a), note: ref(n), range, message: 'Note exceeds the declared pitch range.' });
    if (key && pitched(n) && !key.pitchClasses.includes(pc(n))) addFinding({ severity: intent.strictKey ? 'error' : 'info', code: 'harmony.outside_key', ...position(max(start, n.a)), note: ref(n), message: `Pitch is outside declared ${key.tonic} ${key.mode}; borrowing/chromaticism may be intentional.` });
  }
  const trackMetrics = [];
  for (const id of known) {
    if (excluded.has(id)) continue;
    const tn = notes.filter(n => n.track === id), poly = slices(tn, start, stop).maxPolyphony;
    const maxVoices = intent.maxPolyphony?.[id];
    if (maxVoices !== undefined && poly > maxVoices) addFinding({ severity: 'error', code: 'intent.polyphony', track: id, actual: poly, maximum: maxVoices, message: 'Peak simultaneous note count exceeds the declared limit.' });
    const voices = new Map();
    for (const n of tn) { const v = n.voice || ''; if (!voices.has(v)) voices.set(v, []); voices.get(v).push(n); }
    let maxLeap = 0, ambiguousVoiceGroups = 0;
    for (const [voice, vn] of voices) {
      // No arbitrary "voice leading" between notes in a polyphonic chord stream.
      if (slices(vn, start, stop).maxPolyphony > 1) { ambiguousVoiceGroups++; continue; }
      for (let i = 1; i < vn.length; i++) {
        const leap = Math.abs(vn[i].pitch - vn[i - 1].pitch); maxLeap = Math.max(maxLeap, leap);
        if (intent.maxLeap?.[id] !== undefined && leap > intent.maxLeap[id]) addFinding({ severity: 'error', code: 'intent.leap', ...position(vn[i].a), track: id, voice, semitones: leap, notes: [ref(vn[i - 1]), ref(vn[i])], message: 'Successive monophonic pitches exceed the declared leap limit.' });
      }
    }
    trackMetrics.push({ track: id, notes: tn.length, pitchRange: tn.length ? tn.reduce(([lo, hi], n) => [Math.min(lo, n.pitch), Math.max(hi, n.pitch)], [Infinity, -Infinity]) : null, maxPolyphony: poly, maxMonophonicLeap: maxLeap, ambiguousVoiceGroups });
  }
  let intervalPairs = 0;
  const active = [];
  outer: for (const n of notes) {
    if (!intervals.length) break;
    for (let i = active.length - 1; i >= 0; i--) if (cmp(active[i].b, n.a) <= 0) active.splice(i, 1);
    for (const other of active) {
      if (++pairChecks > 1_000_000) { complete = false; break outer; }
      const overlapStart = max(start, max(n.a, other.a)), overlapEnd = min(stop, min(n.b, other.b));
      if (cmp(overlapEnd, overlapStart) <= 0 || cmp(sub(overlapEnd, overlapStart), minOverlap) < 0) continue;
      const distance = mod(Math.abs(n.pitch - other.pitch)), ic = Math.min(distance, 12 - distance);
      const matched = intervals.find(i => Math.abs(ic - i) < 1e-6);
      if (matched !== undefined) {
        intervalPairs++;
        addFinding({ severity: 'info', code: matched === 6 ? 'interval.tritone' : 'interval.class', ...position(overlapStart), durationBeats: exact(sub(overlapEnd, overlapStart)), intervalClass: matched, notes: [ref(other), ref(n)], message: 'Simultaneous interval evidence, not a compositional error.' });
      }
    }
    active.push(n);
  }
  const measures = selected.map(bar => {
    const bn = sounding(notes, bar.start, bar.end), weights = Array(12).fill(0);
    let pitchWeight = 0, pitchSum = 0;
    for (const n of bn) {
      const weight = real(sub(min(bar.end, n.b), max(bar.start, n.a))) * n.velocity;
      if (pitched(n)) weights[pc(n)] += weight;
      pitchWeight += weight; pitchSum += n.pitch * weight;
    }
    const onsets = bn.filter(n => cmp(n.a, bar.start) >= 0 && cmp(n.a, bar.end) < 0);
    const onsetTimes = [...new Map(onsets.map(n => [exact(n.a), n.a])).values()].sort(cmp);
    const gaps = onsetTimes.slice(1).map((at, i) => real(sub(at, onsetTimes[i])));
    const { result, maxPolyphony } = slices(bn, bar.start, bar.end);
    const harmonies = [];
    let silence = zero;
    for (const s of result) {
      if (!s.notes.length) { silence = add(silence, sub(s.end, s.at)); continue; }
      const pitches = [...new Set(s.notes.map(n => n.pitch))].sort((a, b) => a - b);
      const pitchClasses = [...new Set(pitches.map(p => mod(p)))].sort((a, b) => a - b);
      const last = harmonies.at(-1);
      const bassPitchClass = mod(pitches[0]);
      if (last && last.pitchClasses.join(',') === pitchClasses.join(',') && last.bassPitchClass === bassPitchClass && last.end === exact(s.at)) last.end = exact(s.end);
      else harmonies.push({ at: exact(s.at), end: exact(s.end), pitchClasses, bassPitchClass, candidates: chordCandidates(pitches) });
    }
    const candidates = keyCandidates(weights);
    return {
      measure: bar.number, start: exact(bar.start), end: exact(bar.end), meter: bar.meter, partial: bar.partial,
      onsets: onsets.length, soundingNotes: bn.length, maxPolyphony, silenceBeats: exact(silence),
      weightedPitchClasses: weights.map(rounded), meanPitch: pitchWeight ? rounded(pitchSum / pitchWeight) : null,
      meanVelocity: rounded(average(bn.map(n => n.velocity))),
      keyCandidates: candidates, keyAmbiguous: candidates.length > 1 && candidates[0].fit - candidates[1].fit < .03,
      rhythm: { distinctOnsets: onsetTimes.length, offBeatOnsets: onsetTimes.filter(at => mul(sub(at, bar.start), rat([bar.meter[1], 4])).d !== 1n).length, meanGapBeats: rounded(average(gaps)), gapCv: gaps.length > 1 && average(gaps) ? rounded(deviation(gaps) / average(gaps)) : 0 },
      harmonies: { rows: harmonies.slice(0, 16), total: harmonies.length, omitted: Math.max(0, harmonies.length - 16) },
    };
  });
  const weights = measures.reduce((sum, m) => sum.map((x, i) => x + m.weightedPitchClasses[i]), Array(12).fill(0));
  const limitations = [
    'Tonal candidates are duration × velocity weighted pitch-class heuristics, not proof of key, genre, quality or emotional intent.',
    'Interval findings describe notated overlap, not acoustic roughness; timbre, sustain pedals and effects are not modeled.',
    basis === 'score' ? 'Score times precede gate, humanization, kit expansion and performance realization.' : 'Performance times follow realization; pitch-class analysis uses MIDI keys, not pitch bends or timbre.',
    'No track is implicitly considered percussion. Exclude unpitched tracks explicitly.',
  ];
  if (microtonalNotes.length) limitations.push(`${microtonalNotes.length} microtonal notes excluded from 12-TET key weights; retained in timing/register analysis.`);
  if (clockNotes.length) limitations.push(`${clockNotes.length} clock-placed notes omitted from beat analysis. Use performance basis for realized timing.`);
  if (pairChecks > 1_000_000) limitations.push('Interval-pair budget reached; interval findings are incomplete. Narrow the measure window.');
  if (basis === 'score' && !allNotes.length && info.performedTracks.length) limitations.push('No authored score notes. Imported MIDI may require performance basis.');
  return {
    format: 'muz-study/1', basis, unit: 'quarter-note beats', complete,
    compiler: { status: 'passed', diagnostics: info.diagnostics },
    intent: { status: counts.error ? 'failed' : 'passed', key, expectedBeats: intent.expectedBeats ?? null },
    title: info.title, spanBeats: exact(end), totalMeasures: bars.length,
    window: { fromMeasure, measureCount: selected.length, start: exact(start), end: exact(stop), nextMeasure: selected.at(-1)?.number < bars.length ? selected.at(-1).number + 1 : null },
    counts: { sourceNotes: allNotes.length, selectedNotes: notes.length, excludedTracks: [...excluded], intervalPairs, findings: counts },
    keyCandidates: keyCandidates(weights), tracks: trackMetrics, measures,
    findings: { rows: findings, total, next: findingOffset + findings.length < total ? findingOffset + findings.length : null },
    limitations,
  };
}
"""

let render() = file
