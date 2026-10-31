module Muz.Source.Tests.EngineTestJs

let file = """import { test, expect } from 'bun:test';
import { readFile } from 'node:fs/promises';
test('built WASM compiles actual muz, renders native PCM, and exports MIDI', async () => {
  const bytes = await readFile(new URL('../dist/assets/muz.wasm', import.meta.url));
  const { instance } = await WebAssembly.instantiate(bytes, {}), w = instance.exports;
  const encoder = new TextEncoder(), decoder = new TextDecoder();
  function call(v) {
    const bytes = encoder.encode(JSON.stringify(v)), ptr = w.muz_alloc(bytes.length);
    new Uint8Array(w.memory.buffer, ptr, bytes.length).set(bytes);
    const n = w.muz_call(ptr, bytes.length); w.muz_free(ptr, bytes.length);
    const result = JSON.parse(decoder.decode(new Uint8Array(w.memory.buffer, w.muz_response(), n)));
    if (!result.ok) throw Error(result.error);
    return result.value;
  }
  const source = (await readFile(new URL('../dist/assets/template.muz', import.meta.url), 'utf8')).replace('tempo: 120', 'tempo: 150');
  const info = call({ command: 'compile', project: { entry: 'song.muz', files: { 'song.muz': source } }, rate: 48000 });
  expect(info.tracks.length).toBeGreaterThan(0); expect(info.frames).toBeGreaterThan(0);
  expect(info.bpm).toBe(150);
  expect(info.tracks[0].notes.some(n => n.at > 1000 && n.at < info.frames)).toBe(true);
  call({ command: 'start' });
  const status = call({ command: 'render', frames: 1024 });
  expect(status.frame).toBeGreaterThan(0);
  const pcm = new Float32Array(w.memory.buffer, w.muz_pcm(), 2048);
  expect(pcm.some(v => Math.abs(v) > .00001)).toBe(true);
  const midi = call({ command: 'midi' });
  expect(midi.length).toBeGreaterThan(14);
  expect(decoder.decode(new Uint8Array(w.memory.buffer, w.muz_blob(), 4))).toBe('MThd');
  expect(() => call({ command: 'compile', project: { entry: 'song.muz', files: { 'song.muz': 'use "../outside.muz" as x; x' } } })).toThrow('escapes');
});
"""

let render() = file
