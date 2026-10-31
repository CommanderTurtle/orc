module Muz.Source.Tests.LinksTestJs

let file = """import { test, expect } from 'bun:test';
import { embeddedFragment, resolveProjectLink, sourceFragment, resolveGist } from '../src/links.js';
import { normalizeProject } from '../src/project.js';
const source = 'use "std/arrange" as a;\nlet notes = phrase("C5:q E5:q");\nnotes\n';
const project = normalizeProject({ entry: 'song.muz', files: { 'song.muz': source, 'lib/test.muz': '// é\n42' } });

test('lnkr v4 embedded project loads from bare fragment and full URL', async () => {
  const fragment = embeddedFragment(project);
  for (const input of [fragment, 'https://app.shel.sh/muz/' + fragment, '#' + encodeURIComponent(fragment.slice(1))]) {
    expect((await resolveProjectLink(input, () => { throw Error('must not fetch'); })).project).toEqual(project);
  }
});
test('raw and source link imports use CORS with no credentials', async () => {
  const calls = [];
  const fetchImpl = async (url, init) => { calls.push({ url, init }); return new Response(source); };
  const result = await resolveProjectLink(sourceFragment('https://example.org/song.muz'), fetchImpl);
  expect(result.project.files['song.muz']).toBe(source);
  expect(calls[0].init.credentials).toBe('omit'); expect(calls[0].init.mode).toBe('cors'); expect(calls[0].init.referrerPolicy).toBe('no-referrer');
});
test('superlinks follow a pointer to embedded project without fetching Make', async () => {
  const embedded = 'https://app.shel.sh/make/' + embeddedFragment(project);
  const result = await resolveProjectLink(sourceFragment('https://example.org/pointer.txt', true), async () => new Response(embedded + '\n'));
  expect(result.project).toEqual(project);
});
test('cycles, malformed superlinks, and HTTP failures are clear errors', async () => {
  await expect(resolveProjectLink('https://example.org/a', async () => new Response('https://example.org/a'))).rejects.toThrow('Circular');
  await expect(resolveProjectLink(sourceFragment('https://example.org/a', true), async () => new Response(source))).rejects.toThrow('one-line');
  await expect(resolveProjectLink('https://example.org/a.muz', async () => new Response('', { status: 404 }))).rejects.toThrow('404');
});
test('gist manifest maps source paths and preserves entry', async () => {
  const p = await resolveGist('1234567890abcdef1234567890abcdef', async () => Response.json({ description: 'Synthetic', files: {
    'main.muz': { filename: 'main.muz', content: source },
    'helper.muz': { filename: 'helper.muz', content: '42' },
    'muzpad.json': { filename: 'muzpad.json', content: JSON.stringify({ entry: 'main.muz', paths: { 'helper.muz': 'lib/helper.muz' } }) }
  } }));
  expect(p.entry).toBe('main.muz'); expect(p.files['lib/helper.muz']).toBe('42');
});
"""

let render() = file
