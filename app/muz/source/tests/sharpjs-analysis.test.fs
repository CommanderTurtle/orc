module Muz.Source.Tests.AnalysisTestJs

let file = """import { test, expect } from 'bun:test';
import { analyze, chordCandidates, measureGrid } from '../toolkit/analysis.js';
import { rat, exact, add } from '../toolkit/time.js';
import { runJob } from '../toolkit/runner.js';

const info = (beats = 8, meter = [4, 4]) => ({ beats, meter, title: 'Synthetic', diagnostics: [], sections: [], scoreTracks: [{ id: 'lead', span: [beats, 1] }], performedTracks: [{ id: 'lead', endBeat: beats }] });
const note = (at, dur, pitch, index = 0, track = 'lead') => ({ at: typeof at === 'number' ? [at, 1] : at, dur: typeof dur === 'number' ? [dur, 1] : dur, pitch, index, track, key: `n${index}`, velocity: 1, tags: [] });

test('barlines, tuplets, and held-note weights use exact half-open intervals', () => {
  expect(exact(add(rat('1/3'), rat('2/3')))).toBe('1');
  const fraction = analyze({ ...info(4 / 3), scoreTracks: [{ id: 'lead', span: [4, 3] }] }, [], { intent: { expectedBeats: '4/3' } });
  expect(fraction.spanBeats).toBe('4/3'); expect(fraction.intent.status).toBe('passed');
  const result = analyze(info(), [note([11, 3], [1, 3], 60), note(4, 4, 66, 1)]);
  expect(result.measures[0].onsets).toBe(1); expect(result.measures[1].onsets).toBe(1);
  expect(result.measures[0].soundingNotes).toBe(1); expect(result.counts.intervalPairs).toBe(0);
  const held = analyze(info(), [note(3, 2, 60), note(3, 2, 66, 1)]);
  expect(held.measures.map(m => m.weightedPitchClasses[0])).toEqual([1, 1]);
  expect(held.findings.rows[0].durationBeats).toBe('2'); expect(held.findings.rows[0].severity).toBe('info');
});
test('meter is not hardcoded to four and section meter changes are honored', () => {
  expect(analyze(info(6, [6, 8]), []).totalMeasures).toBe(2);
  const grid = measureGrid({ ...info(13, [3, 4]), sections: [{ start: 0, end: 6, meter: [3, 4] }, { start: 6, end: 13, meter: [7, 8] }] }, rat(13));
  expect(grid.map(b => exact(b.start))).toEqual(['0', '3', '6', '19/2']); expect(grid.every(b => !b.partial)).toBe(true);
  expect(analyze(info(7, [3, 4]), []).measures.at(-1).partial).toBe(true);
});
test('chords include inversions, but never label arbitrary clusters as definite chords', () => {
  expect(chordCandidates([64, 67, 72])[0].symbol).toBe('C/E');
  expect(chordCandidates([60, 61, 66])).toEqual([]);
  const result = analyze(info(4), [note(0, 4, 60), note(0, 4, 64, 1), note(0, 4, 67, 2)]);
  expect(result.measures[0].harmonies.rows[0].candidates[0].symbol).toBe('C');
  expect(result.keyCandidates[0].tonic).toBe('C');
});
test('declared constraints fail separately from engine validity and stylistic evidence', () => {
  const result = analyze(info(4), [note(0, 1, 60), note(1, 1, 78, 1)], { intent: { expectedBeats: 8, ranges: { lead: [60, 72] }, maxLeap: { lead: 12 }, key: { tonic: 'C', mode: 'major' } } });
  expect(result.compiler.status).toBe('passed'); expect(result.intent.status).toBe('failed');
  expect(result.counts.findings.error).toBe(3);
  expect(result.findings.rows.find(f => f.code === 'harmony.outside_key').severity).toBe('info');
});
test('voice analysis does not invent melodic leaps between chord notes', () => {
  const result = analyze(info(4), [note(0, 4, 48), note(0, 4, 84, 1)], { intent: { maxLeap: { lead: 5 } } });
  expect(result.tracks[0].ambiguousVoiceGroups).toBe(1); expect(result.intent.status).toBe('passed');
});
test('finding pages disclose omitted evidence and exclude unpitched tracks only explicitly', () => {
  const result = analyze(info(4), [note(0, 4, 60), note(0, 4, 61, 1), note(0, 4, 66, 2)], { findingLimit: 1 });
  expect(result.findings.total).toBe(2); expect(result.findings.next).toBe(1);
  const quiet = analyze(info(4), [note(0, 4, 60)], { excludeTracks: ['lead'] });
  expect(quiet.counts.selectedNotes).toBe(0);
  expect(() => analyze(info(), [], { excludeTracks: ['typo'] })).toThrow('Unknown');
});
test('clock/microtonal limitations and input bounds are explicit', () => {
  const result = analyze(info(4), [{ ...note(0, 2, 60.5), clock: {} }]);
  expect(result.complete).toBe(false); expect(result.limitations.some(s => s.includes('clock-placed'))).toBe(true);
  expect(() => analyze(info(), [], { measureCount: 9999 })).toThrow();
  expect(() => analyze(info(), [], { intent: { ranges: { typo: [0, 1] } } })).toThrow();
});
test('worker compiles actual muz before analysis and can be cancelled', async () => {
  const project = { entry: 'song.muz', files: { 'song.muz': 'song({tracks: [track("lead", phrase("C4:q E4:q G4:h"), synth("bell"))]})' } };
  const result = await runJob({ action: 'analyze', project }, { wasm: new URL('../dist/assets/muz.wasm', import.meta.url) });
  expect(result.counts.sourceNotes).toBe(3); expect(result.compiler.status).toBe('passed');
  const controller = new AbortController(); controller.abort();
  await expect(runJob({ action: 'check', project }, { signal: controller.signal })).rejects.toThrow('Cancelled');
});
"""

let render() = file
