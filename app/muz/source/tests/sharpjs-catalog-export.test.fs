module Muz.Source.Tests.CatalogExportTestJs

let file = """import { test, expect } from 'bun:test';
import { normalizeCatalog, importCatalog, readResource } from '../src/catalog.js';
import { normalizeProject, MAX_TEXT } from '../src/project.js';
import { crc32, zipArchive } from '../src/zip.js';
import { dawprojectDocuments, exportDawproject } from '../src/dawproject.js';

const project = normalizeProject({ title: 'A < B & "C"', entry: 'song.muz', files: { 'song.muz': 'song({})' } });
test('catalog import is selected, bounded, SHA-256 verified, and transactional', async () => {
  const bytes = new Uint8Array([1, 2, 3]), sha256 = [...new Uint8Array(await crypto.subtle.digest('SHA-256', bytes))].map(n => n.toString(16).padStart(2, '0')).join('');
  const catalog = normalizeCatalog({ title: 'Tiny', mount: 'audio', files: [{ path: 'sample.wav', url: './sample.wav', bytes: 3, sha256 }] }, 'https://example.org/catalog.json');
  const seen = [], fetcher = async (url, options) => { seen.push([url, options.credentials]); return new Response(bytes); };
  const result = await importCatalog(project, catalog.files, { fetcher });
  expect(result.assets['audio/sample.wav']).toBe('AQID'); expect(seen).toEqual([['https://example.org/sample.wav', 'omit']]);
  expect(Object.keys(project.assets)).toHaveLength(0);
  await expect(importCatalog(project, [...catalog.files, { path: 'bad.wav', url: 'https://example.org/x', sha256: '0'.repeat(64) }], { fetcher })).rejects.toThrow('SHA-256');
  expect(Object.keys(project.assets)).toHaveLength(0);
  await expect(importCatalog(result, catalog.files, { fetcher })).rejects.toThrow('already exists');
  const aborted = new AbortController(); aborted.abort();
  await expect(importCatalog(project, catalog.files, { signal: aborted.signal, fetcher })).rejects.toThrow();
  await expect(readResource('https://example.org/large', 2, undefined, fetcher)).rejects.toThrow('size limit');
  await expect(importCatalog(project, [{ path: 'large.muz', text: 'x'.repeat(MAX_TEXT) }])).rejects.toThrow('size limit');
});
test('catalogs reject missing URLs, traversal, credentials and invalid manifests', () => {
  for (const file of [{ path: '../bad.wav', url: './x' }, { path: 'x.wav' }, { path: 'x.wav', url: 'file:///secret' }, { path: 'x.wav', url: 'https://user:pass@example.org/x' }, { path: 'x.wav', text: 'x' }, { path: 'x.wav', url: './x', sha256: 42 }]) expect(() => normalizeCatalog({ files: [file] }, 'https://example.org/catalog.json')).toThrow();
});
async function unzip(blob) {
  const bytes = new Uint8Array(await blob.arrayBuffer()), view = new DataView(bytes.buffer), decoder = new TextDecoder(), files = new Map(); let at = 0;
  while (view.getUint32(at, true) === 0x04034b50) {
    const size = view.getUint32(at + 18, true), nameLength = view.getUint16(at + 26, true), extra = view.getUint16(at + 28, true);
    expect(view.getUint16(at + 6, true)).toBe(0x800); expect(view.getUint16(at + 8, true)).toBe(0);
    const start = at + 30 + nameLength + extra, data = bytes.slice(start, start + size);
    expect(crc32(data)).toBe(view.getUint32(at + 14, true)); files.set(decoder.decode(bytes.slice(at + 30, at + 30 + nameLength)), data); at = start + size;
  }
  expect(view.getUint32(at, true)).toBe(0x02014b50); expect(view.getUint32(bytes.length - 22, true)).toBe(0x06054b50);
  expect(view.getUint16(bytes.length - 12, true)).toBe(files.size); return files;
}
test('portable DAWProject ZIP includes exact source, audio, MIDI and explicit fidelity details', async () => {
  const score = { frames: 96000, tail: .1, rate: 48000, beats: 4, bpm: 120, meter: [4, 4], revision: 2, tempos: [{ beat: 0, frame: 0, bpm: 120 }, { beat: 2, frame: 48000, bpm: 90 }], sections: [{ name: 'A & B', start: 0 }], tracks: [{ id: 'lead', notes: [{ beat: 0, length: 1, pitch: 60, velocity: .8 }] }] };
  const audio = new Uint8Array([82, 73, 70, 70]), midi = new Uint8Array([77, 84, 104, 100]);
  const files = await unzip(exportDawproject(score, project, audio, midi)), decoder = new TextDecoder();
  expect(files.get('audio/master.wav')).toEqual(audio); expect(files.get('muzstatic/song.mid')).toEqual(midi);
  expect(JSON.parse(decoder.decode(files.get('muzstatic/project.muzproject.json')))).toEqual(project);
  const xml = decoder.decode(files.get('project.xml'));
  expect(xml).toContain('<Mute id="mute-0" value="true"/>'); expect(xml).toContain('timeUnit="seconds"'); expect(xml).toContain('<TempoAutomation');
  expect(xml).toContain('name="A &amp; B"'); expect(xml).not.toContain('<Vst3Plugin');
  expect(JSON.parse(decoder.decode(files.get('muzstatic/report.json'))).requiredPlugins).toEqual([]);
  expect(dawprojectDocuments(score, project)[1][1]).toContain('A &lt; B &amp; &quot;C&quot;');
});
test('archives reject duplicate and escaping filenames', async () => {
  expect(crc32(new TextEncoder().encode('123456789'))).toBe(0xcbf43926);
  await unzip(zipArchive([['é.muz', '42']]));
  for (const names of [['../escape'], ['/escape'], ['a\\b'], ['a', 'a']]) expect(() => zipArchive(names.map(n => [n, 'x']))).toThrow();
});
"""

let render() = file
