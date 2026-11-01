module Muz.Source.Tests.StudioTestJs

let file = """import { test, expect } from 'bun:test';
import { readFile } from 'node:fs/promises';
import { runInNewContext } from 'node:vm';
import { normalizeProject, bytesToBase64 } from '../src/project.js';
import { applyStudioEdit } from '../src/studio-source.js';
import { audibleTracks, beatToFrame, frameToBeat, snapBeat } from '../src/timeline.js';

async function host() {
  const { instance: { exports: w } } = await WebAssembly.instantiate(await readFile(new URL('../dist/assets/muz.wasm', import.meta.url)), {});
  const encoder = new TextEncoder(), decoder = new TextDecoder();
  const call = v => {
    const bytes = encoder.encode(JSON.stringify(v)), ptr = w.muz_alloc(bytes.length);
    new Uint8Array(w.memory.buffer, ptr, bytes.length).set(bytes);
    const n = w.muz_call(ptr, bytes.length); w.muz_free(ptr, bytes.length);
    const result = JSON.parse(decoder.decode(new Uint8Array(w.memory.buffer, w.muz_response(), n)));
    if (!result.ok) throw Error(result.error); return result.value;
  };
  return { call, pcm: frames => new Float32Array(w.memory.buffer, w.muz_pcm(), frames * 2).slice() };
}
const source = 'song({tempo:120, tracks:[track("lead", phrase("C4:q E4:q G4:h"), synth("bell"))], tail:0.05})';
const original = () => normalizeProject({ entry: 'parts/song.muz', files: { 'parts/song.muz': source }, title: 'Studio fixture' });

test('visual edits compile as native muz while preserving the original source', async () => {
  const { call } = await host();
  let project = applyStudioEdit(original(), 'lead', { gain: -9, notes: [{ beat: 1.5, length: .75, pitch: 67, velocity: .5 }] });
  project = normalizeProject(applyStudioEdit(project, 'new-track', { added: true, preset: 'glass-lead', gain: -12, notes: [{ beat: 0, length: 1, pitch: 48, velocity: .8 }] }));
  project = normalizeProject(applyStudioEdit(project, null, { tempo: 90 }));
  expect(project.files['parts/song.muz']).toBe(source);
  expect(project.entry).toBe('studio.muz');
  const score = call({ command: 'compile', project });
  expect(score.bpm).toBeCloseTo(90, 3); expect(score.tracks.map(t => t.id)).toEqual(['lead', 'new-track']);
  expect(score.tracks[0].gain).toBe(-9); expect(score.tracks[0].editable).toBe(true);
  expect(score.tracks[0].notes).toHaveLength(1);
  expect(score.tracks[0].notes[0]).toMatchObject({ beat: 1.5, length: .75, pitch: 67 });
  project = normalizeProject(applyStudioEdit(project, 'lead', { removed: true }));
  expect(call({ command: 'compile', project }).tracks.map(t => t.id)).toEqual(['new-track']);
});

test('studio samples resolve from the generated module and malformed visual metadata is rejected', async () => {
  const wav = new Uint8Array(44 + 100 * 2), view = new DataView(wav.buffer), enc = new TextEncoder();
  wav.set(enc.encode('RIFF'), 0); view.setUint32(4, wav.length - 8, true); wav.set(enc.encode('WAVEfmt '), 8);
  view.setUint32(16, 16, true); view.setUint16(20, 1, true); view.setUint16(22, 1, true);
  view.setUint32(24, 48000, true); view.setUint32(28, 96000, true); view.setUint16(32, 2, true); view.setUint16(34, 16, true);
  wav.set(enc.encode('data'), 36); view.setUint32(40, 200, true);
  let p = original(); p.assets['audio/tiny.wav'] = bytesToBase64(wav);
  p = normalizeProject(applyStudioEdit(p, 'lead', { sample: 'audio/tiny.wav' }));
  const { call } = await host(); expect(call({ command: 'compile', project: p }).tracks[0].instrument).toContain('sample');
  expect(() => normalizeProject(applyStudioEdit(p, 'lead', { notes: [{ beat: -1, length: 1, pitch: 60, velocity: 1 }] }))).toThrow();
  expect(() => applyStudioEdit(p, '__proto__', { gain: 0 })).toThrow();
  expect(() => applyStudioEdit(p, 'lead', { sample: 'missing.wav' })).toThrow();
});

test('rejected live revisions preserve the accepted engine, playhead, and inspection', async () => {
  const { call, pcm } = await host();
  const project = original(); call({ command: 'compile', project }); call({ command: 'start' }); call({ command: 'render', frames: 1024 });
  const before = call({ command: 'inspect', view: 'summary' });
  expect(() => call({ command: 'revise', project: { ...project, files: { 'parts/song.muz': 'song({tracks: [missing_name]})' } } })).toThrow();
  expect(call({ command: 'inspect', view: 'summary' })).toEqual(before);
  const good = call({ command: 'revise', project: applyStudioEdit(project, 'lead', { gain: -10 }) });
  expect(good.positionFrame).toBe(1024); expect(good.tracks[0].gain).toBe(-10);
  call({ command: 'render', frames: 1024 }); expect(pcm(1024).some(v => Math.abs(v) > 1e-7)).toBe(true);
  call({ command: 'audition', tracks: [] }); // The live mask ramps and lets accepted effect tails finish.
  call({ command: 'reset' }); call({ command: 'render', frames: 1024 }); expect(pcm(1024).every(v => v === 0)).toBe(true);
  for (const view of ['graph', 'automation', 'automation_points', 'sections', 'track_groups', 'patches', 'patch_nodes', 'diagnostics']) expect(call({ command: 'inspect', view, page: { limit: 50 } }).rows).toBeArray();
});

test('the native syntax checker returns the original parser location without evaluating source', async () => {
  const { call } = await host();
  expect(call({ command: 'lint', path: 'song.muz', source: 'missing_name(42)' }).valid).toBe(true);
  expect(() => call({ command: 'lint', path: 'song.muz', source: 'song({tracks: [})' })).toThrow('song.muz:1:');
});

test('worker seeks reproduce accepted DSP history and exports stay independent', async () => {
  const pending = new Map(); let sequence = 0;
  const self = { postMessage: message => { if (message.progress !== undefined) return; const p = pending.get(message.id); pending.delete(message.id); message.error ? p.reject(Error(message.error)) : p.resolve(message.result); } };
  const bytes = await readFile(new URL('../dist/assets/muz.wasm', import.meta.url));
  const script = (await readFile(new URL('../src/engine-worker.js', import.meta.url), 'utf8')).replaceAll('import.meta.url', JSON.stringify(new URL('../src/engine-worker.js', import.meta.url).href));
  runInNewContext(script, { self, URL, TextEncoder, TextDecoder, WebAssembly, Float32Array, Uint8Array, DataView, ArrayBuffer, Math, setTimeout, fetch: async () => new Response(bytes) });
  const request = (operation, input) => new Promise((resolve, reject) => { const id = ++sequence; pending.set(id, { resolve, reject }); self.onmessage({ data: { id, operation, input } }); });
  await request('compile', { project: original() });
  await request('pull', { frames: 20000 }); const reference = await request('pull', { frames: 2048 });
  const seek = await request('seek', { frame: 20000 }); expect(seek.frame).toBe(20000);
  expect([...(await request('pull', { frames: 2048 })).pcm]).toEqual([...reference.pcm]);
  await request('seek', { frame: 0 }); const first = await request('pull', { frames: 1024 }); expect(first.pcm.some(v => v !== 0)).toBe(true);
  const midi = await request('midi'); expect(new TextDecoder().decode(midi.slice(0, 4))).toBe('MThd');
  const wav = await request('wav', {}); expect(new TextDecoder().decode(new Uint8Array(wav, 0, 4))).toBe('RIFF');
  expect(new DataView(wav).getUint16(34, true)).toBe(24);
});

test('timeline conversions respect tempo changes, snapping, and combined solo/mute', () => {
  const score = { rate: 48000, bpm: 120, tempos: [{ beat: 0, frame: 0, bpm: 120 }, { beat: 4, frame: 96000, bpm: 60 }] };
  expect(beatToFrame(6, score)).toBe(192000); expect(frameToBeat(192000, score)).toBe(6);
  expect(snapBeat(.62, .25)).toBe(.5);
  expect(audibleTracks([{ id: 'a' }, { id: 'b' }, { id: 'c' }], new Set(['a', 'b']), new Set(['b']))).toEqual(['a']);
});

test('audio queue discards stale seeks and loops at a half-open frame boundary', async () => {
  let Player; const events = [];
  runInNewContext(await readFile(new URL('../src/player-worklet.js', import.meta.url), 'utf8'), {
    AudioWorkletProcessor: class { constructor() { this.port = { postMessage: d => events.push(d) }; } }, sampleRate: 48000,
    registerProcessor: (_name, value) => { Player = value; },
  });
  const p = new Player(), send = data => p.port.onmessage({ data });
  send({ type: 'clear', epoch: 2, frame: 100 });
  send({ type: 'chunk', epoch: 1, pcm: new Float32Array(16).fill(1), done: true }); expect(p.queue.length).toBe(0);
  send({ type: 'chunk', epoch: 2, pcm: new Float32Array(16).fill(1), done: false });
  send({ type: 'loop', range: [100, 104] }); send({ type: 'play', epoch: 2 });
  const left = new Float32Array(8), right = new Float32Array(8); p.process([], [[left, right]]);
  expect(p.frame).toBe(104); expect(events).toContainEqual({ type: 'loop', frame: 100, epoch: 2 });
  expect(left.slice(4).every(v => v === 0)).toBe(true);
  send({ type: 'clear', epoch: 3, frame: 3 }); send({ type: 'play', epoch: 2 }); expect(p.playing).toBe(false);
});
"""

let render() = file
