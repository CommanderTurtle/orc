module Muz.Source.Tests.ToolkitTestJs

let file = """import { test, expect } from 'bun:test';
import { mkdtemp, readFile, rm, mkdir, writeFile, symlink } from 'node:fs/promises';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { spawn } from 'node:child_process';
import { fileURLToPath } from 'node:url';
import { createService } from '../toolkit/service.js';
import { createWorkspace } from '../toolkit/workspace.js';

const song = 'song({tracks: [track("lead", phrase("C4:q E4:q G4:h"), synth("bell"))], tail: 0.05})';
const inline = { entry: 'song.muz', files: { 'song.muz': song } };
async function temporary(fn) {
  const root = await mkdtemp(join(tmpdir(), 'muz-tools-'));
  try { await fn(root); } finally { await rm(root, { recursive: true, force: true }); }
}
test('workspace revision edits, snapshots, directory imports and escape boundaries', async () => temporary(async root => {
  const ws = await createWorkspace(root);
  await ws.write('song.muz', song);
  const first = await ws.read('song.muz');
  await expect(ws.write('song.muz', '42')).rejects.toThrow('expectedHash');
  await expect(ws.write('song.muz', '42', 'stale')).rejects.toThrow('Revision changed');
  const next = await ws.write('song.muz', song + '\n', first.sha256);
  expect(next.sha256).not.toBe(first.sha256);
  await expect(ws.read('../outside.muz')).rejects.toThrow('escapes');
  await expect(ws.write('../outside.muz', song)).rejects.toThrow('escapes');
  await ws.write('lib/theme.muz', 'phrase("C4:w")');
  expect(Object.keys((await ws.project({ path: '.' })).project.files)).toEqual(['lib/theme.muz', 'song.muz']);
  expect(Object.keys((await ws.project({ path: 'song.muz' })).project.files)).toEqual(['song.muz']);
}));
test('symlink/junction reads and output parents cannot escape the chosen root', async () => temporary(async root => {
  await mkdir(join(root, 'inside')); await mkdir(join(root, 'outside'));
  await writeFile(join(root, 'outside/secret.muz'), '42');
  await symlink(join(root, 'outside'), join(root, 'inside/jump'), process.platform === 'win32' ? 'junction' : 'dir');
  const ws = await createWorkspace(join(root, 'inside'));
  await expect(ws.read('jump/secret.muz')).rejects.toThrow('escapes');
  await expect(ws.write('jump/new.muz', '42')).rejects.toThrow('escapes');
  await expect(ws.project({ path: '.' })).rejects.toThrow('symlink');
}));
test('all service layers share engine provenance, render without playback, and never overwrite', async () => temporary(async root => {
  const s = await createService({ root });
  const check = await s.call('muz_check', { project: inline });
  expect(check.sourceRevision).toHaveLength(64); expect(check.engine.revision).toHaveLength(40);
  const study = await s.call('muz_analyze', { project: inline });
  expect(study.sourceRevision).toBe(check.sourceRevision); expect(study.counts.sourceNotes).toBe(3);
  await expect(s.call('muz_check', { project: inline, typo: true })).rejects.toThrow('Unknown argument');
  const wav = await s.call('muz_render', { project: inline, format: 'wav', output: 'out/preview.wav', seconds: .1 });
  expect(wav.frames).toBe(4800); expect(wav.preview).toBe(true); expect(wav.nonfiniteSamples).toBe(0);
  const bytes = await readFile(wav.path); expect(bytes.toString('ascii', 0, 4)).toBe('RIFF'); expect(bytes.readUInt32LE(24)).toBe(48000);
  await expect(s.call('muz_render', { project: inline, format: 'wav', output: 'out/preview.wav', seconds: .1 })).rejects.toThrow();
  const midi = await s.call('muz_render', { project: inline, format: 'midi', output: 'out/song.mid' });
  expect((await readFile(midi.path)).toString('ascii', 0, 4)).toBe('MThd');
  const link = await s.call('muz_share', { project: inline, output: 'out/link.txt' });
  expect(link.url).toStartWith('http://127.0.0.1:8196/#'); expect(link.output.bytes).toBeGreaterThan(0);
  expect((await s.call('muz_reference', { topic: 'template' })).text).toContain('song');
  expect((await s.call('muz_reference', { topic: 'language', query: 'scale' })).totalMatches).toBeGreaterThan(0);
  expect((await s.call('muz_reference', { topic: 'compose' })).text).toContain('exact');
}));

async function client(root) {
  const child = spawn(process.execPath, [fileURLToPath(new URL('../toolkit/server.js', import.meta.url)), '--root', root], { stdio: ['pipe', 'pipe', 'pipe'] });
  const pending = new Map(); let text = '', stderr = '', next = 0;
  child.stderr.on('data', chunk => { stderr += chunk; });
  child.stdout.on('data', chunk => {
    text += chunk;
    while (text.includes('\n')) {
      const at = text.indexOf('\n'), line = text.slice(0, at); text = text.slice(at + 1);
      const message = JSON.parse(line), task = pending.get(message.id);
      if (task) { clearTimeout(task.timer); pending.delete(message.id); task.resolve(message); }
    }
  });
  const send = message => child.stdin.write(JSON.stringify(message) + '\n');
  return {
    start(method, params = {}) {
      const id = ++next;
      const promise = new Promise((resolve, reject) => {
        const timer = setTimeout(() => reject(Error('MCP response timed out: ' + stderr)), 5000);
        pending.set(id, { resolve, reject, timer });
      });
      send({ jsonrpc: '2.0', id, method, params }); return { id, promise };
    },
    request(method, params = {}) { return this.start(method, params).promise; },
    notify(method, params = {}) { send({ jsonrpc: '2.0', method, params }); },
    async close() {
      for (const p of pending.values()) clearTimeout(p.timer);
      child.stdin.end();
      await Promise.race([new Promise(resolve => child.once('exit', resolve)), new Promise(resolve => setTimeout(() => { child.kill(); resolve(); }, 2000))]);
      expect(stderr).toBe('');
    },
  };
}
test('stdio MCP handshake, discovery, native tool calls, prompts/resources and errors', async () => temporary(async root => {
  const c = await client(root);
  try {
    expect((await c.request('tools/list')).error.code).toBe(-32002);
    const init = await c.request('initialize', { protocolVersion: '2025-11-25', capabilities: {}, clientInfo: { name: 'focused-test', version: '1' } });
    expect(init.result.protocolVersion).toBe('2025-11-25');
    c.notify('notifications/initialized');
    expect((await c.request('tools/list')).result.tools.length).toBeGreaterThan(8);
    const check = await c.request('tools/call', { name: 'muz_check', arguments: { project: inline } });
    expect(check.result.isError).toBe(false); expect(check.result.structuredContent.tracks[0].id).toBe('lead');
    const invalid = await c.request('tools/call', { name: 'muz_check', arguments: { project: { ...inline, files: { 'song.muz': 'song({ tracks: [no_such_name] })' } } } });
    expect(invalid.result.isError).toBe(true); expect(invalid.result.structuredContent.diagnostic).toBeTruthy();
    expect((await c.request('resources/read', { uri: 'muz://guidance/compose' })).result.contents[0].text).toContain('.muz');
    expect((await c.request('prompts/get', { name: 'compose', arguments: { brief: 'A tiny 3/4 waltz.' } })).result.messages[0].content.text).toContain('3/4 waltz');
    expect((await c.request('not/a/method')).error.code).toBe(-32601);
    expect((await c.request('ping')).result).toEqual({});
    const image = await c.request('tools/call', { name: 'muz_view_colorful', arguments: { project: inline, output: 'colorful.png', width: 1200 } });
    expect(image.result.isError).toBe(false);
    expect(image.result.content[1].type).toBe('image'); expect(image.result.content[1].mimeType).toBe('image/png');
    expect(Buffer.from(image.result.content[1].data, 'base64').subarray(0, 4)).toEqual(Buffer.from([137, 80, 78, 71]));
    expect(image.result.structuredContent._image).toBeUndefined();
    const cancelled = c.start('tools/call', { name: 'muz_analyze', arguments: { project: inline } });
    c.notify('notifications/cancelled', { requestId: cancelled.id });
    expect((await c.request('ping')).result).toEqual({});
    expect(await Promise.race([cancelled.promise, new Promise(resolve => setTimeout(() => resolve('cancelled-without-response'), 100))])).toBe('cancelled-without-response');
  } finally { await c.close(); }
}));
test('older MCP clients negotiate a supported protocol without unsupported structured results', async () => temporary(async root => {
  const c = await client(root);
  try {
    expect((await c.request('initialize', { protocolVersion: '2024-11-05', capabilities: {}, clientInfo: { name: 'legacy-test', version: '1' } })).result.protocolVersion).toBe('2024-11-05');
    c.notify('notifications/initialized');
    const result = await c.request('tools/call', { name: 'muz_evaluate', arguments: { project: { entry: 'math.muz', files: { 'math.muz': 'assert(1b / 3 * 3 == 1b); 2 + 3' } } } });
    expect(result.result.isError).toBe(false); expect(result.result.structuredContent).toBeUndefined(); expect(JSON.parse(result.result.content[0].text).result).toBe(5);
  } finally { await c.close(); }
}));
"""

let render() = file
