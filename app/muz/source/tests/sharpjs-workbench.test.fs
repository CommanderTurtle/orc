module Muz.Source.Tests.WorkbenchTestJs

let file = """import { test, expect } from 'bun:test';
import { toWorkbench } from '../src/workbench-project.js';
import { embeddedFragment, resolveProjectLink } from '../src/links.js';

test('upstream handoff preserves source, entries, binary bytes and native Studio wrappers', async () => {
  const original = { title: 'Handoff', entry: 'studio.muz', files: { 'song.muz': 'song({})', 'studio.muz': '42' }, assets: { 'audio/a.WAV': 'AQID' }, studio: { version: 1, baseEntry: 'song.muz', generated: 'studio.muz', tracks: {} } };
  const converted = toWorkbench(original);
  expect(converted.entry).toBe('studio.muz'); expect(converted.workbenchAssets['audio/a.WAV']).toEqual({format:'wav',base64:'AQID'});
  const resolved = await resolveProjectLink(embeddedFragment(converted));
  expect(resolved.project.assets).toEqual(original.assets); expect(resolved.project.files).toEqual(original.files);
  expect(resolved.project.studio).toMatchObject(original.studio);
});
test('unsupported upstream asset kinds fail explicitly instead of losing project data', () => {
  const project = { entry: 'song.muz', files: { 'song.muz': '42' }, assets: { 'instrument.sfz': 'AQID' } };
  expect(() => toWorkbench(project)).toThrow('Keep this project in Studio');
  expect(project.assets['instrument.sfz']).toBe('AQID');
  for (const path of ['sample.__proto__', 'sample.constructor']) expect(() => toWorkbench({...project,assets:{[path]:'AQID'}})).toThrow('Keep this project in Studio');
});
"""

let render() = file
