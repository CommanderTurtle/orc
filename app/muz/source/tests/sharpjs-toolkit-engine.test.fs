module Muz.Source.Tests.ToolkitEngineTestJs

let file = """import { test, expect } from 'bun:test';
import { loadEngine } from '../toolkit/wasm.js';

const wasm = new URL('../dist/assets/muz.wasm', import.meta.url);
const project = source => ({ entry: 'song.muz', files: { 'song.muz': source } });
const song = 'song({meter: [3, 4], tracks: [track("lead", phrase("C4:q E4:q G4:q"), synth("bell"))]})';

test('agent host uses engine inspection and exact score/performance time', async () => {
  const e = await loadEngine(wasm);
  const info = e.call({ command: 'check', project: project(song), provenance: true });
  expect(info.meter).toEqual([3, 4]); expect(info.tracks[0].notes).toBeUndefined();
  const a = e.call({ command: 'notes', basis: 'score', limit: 2 });
  expect(a.total).toBe(3); expect(a.next).toBe(2); expect(a.rows[1].at).toEqual([1, 1]);
  const b = e.call({ command: 'notes', basis: 'performance', limit: 10 });
  expect(b.rows[1].at[0] / b.rows[1].at[1]).toBe(1);
  expect(b.rows[0].dur[0] / b.rows[0].dur[1]).toBeCloseTo(.9);
  const page = e.call({ command: 'inspect', view: 'score', page: { limit: 1 } });
  expect(page.total).toBe(3); expect(page.next).toBe(1);
  const origin = e.call({ command: 'explain', track: 'lead', limit: 1 });
  expect(origin.rows[0].definition.path).toContain('song.muz');
});

test('evaluate runs real muz math and formatter preserves comments/string tokens', async () => {
  const e = await loadEngine(wasm);
  expect(e.call({ command: 'evaluate', project: project('let triplet = 1b / 3; assert(triplet * 3 == 1b); [triplet * 3, 2 + 3]') }).result).toEqual([1, 5]);
  const result = e.call({ command: 'format', source: '// preserve\nlet x= "é\\n";x' });
  expect(result.changed).toBe(true); expect(result.source).toContain('// preserve'); expect(result.source).toContain('"é\\n"');
  expect(e.call({ command: 'format', source: result.source }).changed).toBe(false);
});

test('bad candidate retains structured diagnostics, never stale notes', async () => {
  const e = await loadEngine(wasm);
  e.call({ command: 'check', project: project(song) });
  let failure;
  try { e.call({ command: 'check', project: project('song({ tracks: [broken_name] })') }); } catch (error) { failure = error; }
  expect(failure.diagnostic).toBeTruthy();
  expect(() => e.call({ command: 'notes' })).toThrow('compile first');
  expect(() => e.call({ command: 'evaluate', project: { entry: 'song.muz', files: { 'song.muz': 'use "../private.muz" as p; p' } } })).toThrow('escapes');
});
"""

let render() = file
