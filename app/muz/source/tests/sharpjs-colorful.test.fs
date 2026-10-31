module Muz.Source.Tests.ColorfulTestJs

let file = """import { test, expect } from 'bun:test';
import { inflateSync } from 'node:zlib';
import { circularMoment, colorFeatures, colorfulPNG } from '../toolkit/colorful.js';
import { analyze } from '../toolkit/analysis.js';

const info = { title: 'Synthetic portrait', beats: 8, meter: [4, 4], diagnostics: [], sections: [], scoreTracks: [{ id: 'lead', span: [8, 1] }], performedTracks: [{ id: 'lead', end: [8, 1] }] };
const note = (at, dur, pitch) => ({ at: [at, 1], dur: [dur, 1], pitch, velocity: .8, track: 'lead', index: at });

test('unit-circle transposition rotates the mathematical moment predictably', () => {
  const weights = [1, 0, 0, 0, .7, 0, 0, .8, 0, 0, 0, 0];
  const shifted = weights.map((_, p) => weights[(p + 5) % 12]); // up a perfect fifth
  const a = circularMoment(weights), b = circularMoment(shifted);
  const difference = Math.atan2(Math.sin(b.phase - a.phase), Math.cos(b.phase - a.phase));
  expect(difference).toBeCloseTo(Math.PI / 6, 10); expect(a.magnitude).toBeCloseTo(b.magnitude, 10);
  expect(circularMoment(Array(12).fill(0)).magnitude).toBe(0);
});
test('sustained texture and rapid attacks yield different structural traces', () => {
  const sustained = [note(0, 8, 60)], rapid = Array.from({ length: 8 }, (_, i) => note(i, 1, i % 2 ? 66 : 48));
  const a = colorFeatures(sustained, analyze(info, sustained), 128), b = colorFeatures(rapid, analyze(info, rapid), 128);
  expect(a.attacks.reduce((x, y) => x + y)).toBe(1); expect(b.attacks.reduce((x, y) => x + y)).toBe(8);
  expect(a.energy.every(x => x > 0)).toBe(true);
  expect(b.motion.some(x => x > 0)).toBe(true);
});
test('PNG is deterministic, decodable, bounded, and embeds mathematical provenance', () => {
  const notes = [note(0, 4, 60), note(4, 4, 67)], study = analyze(info, notes);
  const result = colorfulPNG(info, notes, study, { width: 1200 }, { sourceRevision: 'test-revision' });
  expect(result.bytes.equals(colorfulPNG(info, notes, study, { width: 1200 }, { sourceRevision: 'test-revision' }).bytes)).toBe(true);
  expect(result.bytes.readUInt32BE(16)).toBe(1200); expect(result.bytes.readUInt32BE(20)).toBe(1080);
  let offset = 8, idat = [], metadata;
  while (offset < result.bytes.length) {
    const length = result.bytes.readUInt32BE(offset), type = result.bytes.toString('ascii', offset + 4, offset + 8), data = result.bytes.subarray(offset + 8, offset + 8 + length);
    if (type === 'IDAT') idat.push(data); if (type === 'iTXt') metadata = data.toString('utf8');
    offset += length + 12;
  }
  expect(inflateSync(Buffer.concat(idat)).length).toBe(1080 * (1200 * 4 + 1));
  expect(metadata).toContain('test-revision'); expect(metadata).toContain('cos(theta-theta_p)');
  expect(result.bytes.length).toBeLessThan(4 * 1024 * 1024);
  expect(() => colorfulPNG(info, notes, study, { width: 10 })).toThrow();
});
"""

let render() = file
