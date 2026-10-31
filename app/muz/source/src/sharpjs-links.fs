module Muz.Source.Src.LinksJs

let file = """import { encodeLinkTarget, decodeLinkTarget, decodeQRLinkTarget, extractSingleLinkDocument, sourceResourceURL, splitLinkFragment, validateLinkTarget } from './vendor/lnkr/link-runtime.js';
import { outputAlphabetASCII, outputAlphabetEmoji } from './vendor/lnkr/alphabets.js';
import { stringToNumber } from './vendor/lnkr/compress.js';
import { compressTextV4, decompressText } from './vendor/lnkr/text-compress.js';
import { splitExecutableFragment } from './vendor/lnkr/viewer-runtime.js';
import { decodeMakeFile, isMakeLink } from './vendor/lnkr/make-resource.js';
import { Inflate } from './vendor/lnkr/vendor/pako.esm.min.js';
import { MAX_PROJECT, MAX_TEXT, normalizeProject, parseProject, projectPath } from './project.js';

const MAX_LINK = 512 * 1024;
const base = 'https://muzstatic.invalid/';
const prefixes = /^(?:ss|s|sm|sj|sh|hs|lr|l|lf|i|media|pdf|share|p|r|m|h):/;
function decodeDocument(fragment) {
  // Bound the declared decoded size before the unmodified upstream decoder allocates.
  const candidates = [fragment];
  try { const v = decodeURIComponent(fragment); if (v !== fragment) candidates.push(v); } catch {}
  let last;
  for (const payload of candidates) for (const alphabet of [outputAlphabetASCII, outputAlphabetEmoji]) {
    try {
      let n = stringToNumber(payload, alphabet);
      const bit = () => { if (n <= 1n) throw Error('Truncated payload'); const b = Number(n & 1n); n >>= 1n; return b; };
      const fixed = size => { let v = 0; for (let i = 0; i < size; i++) v += bit() * 2 ** i; return v; };
      if (fixed(16) !== 0x4c4e) throw Error('Not an ln.kr document');
      const version = fixed(3); fixed(2);
      if (version < 1 || version > 4) throw Error('Unsupported ln.kr version');
      let zeros = 0;
      while (!bit()) { if (++zeros > 27) throw Error('Embedded document exceeds the project limit'); }
      let size = 1; while (zeros--) size = size * 2 + bit();
      if (size - 1 > MAX_PROJECT * 1.4 + MAX_TEXT) throw Error('Embedded document exceeds the project limit');
      if (version === 4) {
        // Keep the upstream wire decoder unchanged, but reject a forged-length
        // deflate bomb before its one-shot inflate can allocate the full output.
        fixed(32);
        let z = 0; while (!bit()) { if (++z > 20) throw Error('Invalid compressed length'); }
        let length = 1; while (z--) length = length * 2 + bit(); length--;
        if (length > MAX_LINK) throw Error('Compressed document exceeds the link limit');
        const compressed = new Uint8Array(length);
        for (let i = 0; i < length; i++) compressed[i] = fixed(8);
        let decoded = 0; const stream = new Inflate();
        stream.onData = chunk => { decoded += chunk.length; if (decoded > size - 1) throw Error('ln.kr document exceeds its declared size'); };
        stream.push(compressed, true);
        if (stream.err || !stream.ended || decoded !== size - 1) throw Error('Invalid ln.kr deflate length');
      }
      return decompressText(payload, alphabet).text;
    } catch (e) { last = e; }
  }
  throw last || Error('Invalid ln.kr document');
}
export function embeddedFragment(project) {
  const text = JSON.stringify(normalizeProject(project));
  const payload = compressTextV4(text, outputAlphabetASCII, 'text').payload;
  if (payload.length > MAX_LINK) throw Error('This project is too large for a practical URL. Save its project JSON and share a raw URL to that file instead.');
  return '#' + payload;
}
export function sourceFragment(url, superlink = false) {
  return '#' + (superlink ? 'ss:' : 's:') + encodeLinkTarget(validateLinkTarget(url)).payload;
}
function locator(input) {
  const value = input.trim();
  if (!value || value.length > MAX_LINK) throw Error('Link is empty or exceeds 512 KiB.');
  const bare = value.startsWith('#') || prefixes.test(value);
  const url = bare ? new URL(value.startsWith('#') ? value : '#' + value, base) : new URL(validateLinkTarget(value));
  const fragment = url.hash.slice(1);
  if (/^(share|p):/.test(fragment)) return { target: 'https://app.shel.sh/make/#' + fragment, fragment: '#' + fragment };
  const route = splitLinkFragment(fragment);
  if (route.mode) return { target: decodeLinkTarget(route.payload).target, superlink: route.mode === 'super-source', fragment: '#' + fragment };
  if (fragment) {
    const executable = splitExecutableFragment(fragment);
    try { return { text: decodeDocument(executable.payload), fragment: '#' + fragment }; }
    catch (e) {
      if (bare && !executable.executableKind) for (const decode of [decodeLinkTarget, decodeQRLinkTarget]) {
        try { const target = decode(fragment).target; return { target, fragment: sourceFragment(target) }; } catch {}
      }
      if (bare || executable.executableKind) throw e;
    }
  }
  if (bare) throw Error('Invalid ln.kr fragment.');
  return { target: url.href };
}
async function read(response, budget) {
  if (!response.ok) throw Error(`Source returned HTTP ${response.status}`);
  if (Number(response.headers.get('content-length')) > budget) throw Error('Source exceeds the 64 MiB link budget.');
  const reader = response.body?.getReader();
  if (!reader) return '';
  let size = 0; const chunks = [];
  try { for (;;) { const { done, value } = await reader.read(); if (done) break; size += value.length; if (size > budget) throw Error('Source exceeds the link budget.'); chunks.push(value); } }
  finally { await reader.cancel().catch(() => {}); reader.releaseLock(); }
  const bytes = new Uint8Array(size); let offset = 0;
  for (const c of chunks) { bytes.set(c, offset); offset += c.length; }
  return new TextDecoder('utf-8', { fatal: true }).decode(bytes);
}
async function request(url, fetchImpl, signal, budget) {
  const u = new URL(url);
  if (!['http:', 'https:'].includes(u.protocol) || u.username || u.password) throw Error('Source must be a public HTTP(S) URL without embedded credentials.');
  try {
    const response = await fetchImpl(u.href, { method: 'GET', mode: 'cors', credentials: 'omit', referrerPolicy: 'no-referrer', signal });
    return { text: await read(response, budget), url: response.url || url };
  } catch (e) { signal.throwIfAborted(); throw Error(`Cannot read source. It must allow browser CORS access. ${e.message}`, { cause: e }); }
}
export async function resolveProjectLink(input, fetchImpl = fetch, signal = AbortSignal.timeout(30_000)) {
  const first = locator(input);
  let pending = input, used = 0;
  let fragment = first.fragment || sourceFragment(first.target);
  const seen = new Set(), sources = [];
  for (let hop = 0; hop < 12; hop++) {
    signal.throwIfAborted();
    if (seen.has(pending)) throw Error('Circular link pointer.');
    seen.add(pending);
    const item = locator(pending);
    let text = item.text, name = 'song.muz', pointerBase = base;
    if (text === undefined) {
      if (isMakeLink(item.target)) {
        const file = decodeMakeFile(item.target, MAX_PROJECT - used);
        text = new TextDecoder('utf-8', { fatal: true }).decode(file.bytes); name = file.name;
      } else {
        const u = new URL(sourceResourceURL(item.target)); u.hash = '';
        if (seen.has('fetch:' + u.href)) throw Error('Circular link pointer.');
        seen.add('fetch:' + u.href); sources.push(u.href);
        const result = await request(u.href, fetchImpl, signal, MAX_PROJECT - used);
        text = result.text; pointerBase = result.url;
        try { name = decodeURIComponent(new URL(result.url).pathname.split('/').pop()) || name; } catch {}
      }
      if (item.superlink && !extractSingleLinkDocument(text, pointerBase)) throw Error('A superlink must point to a one-line link document.');
    }
    used += new TextEncoder().encode(text).length;
    if (used > MAX_PROJECT) throw Error('Source exceeds the link budget.');
    const pointer = extractSingleLinkDocument(text, pointerBase);
    if (pointer) {
      if (hop === 0 && !first.fragment) fragment = sourceFragment(first.target, true);
      pending = pointer; continue;
    }
    return { project: parseProject(text, name), fragment, sources };
  }
  throw Error('Too many link pointer hops (maximum 12).');
}
export async function resolveGist(input, fetchImpl = fetch) {
  const match = input.trim().match(/^(?:https:\/\/gist\.github\.com\/[^/]+\/)?([a-f\d]{32,40})(?:\/([a-f\d]{40}))?\/?$/i);
  if (!match) throw Error('Enter a gist ID or gist.github.com URL.');
  const id = match[1] + (match[2] ? '/' + match[2] : '');
  const signal = AbortSignal.timeout(30_000);
  const { text } = await request('https://api.github.com/gists/' + id, fetchImpl, signal, MAX_TEXT * 2);
  const gist = JSON.parse(text), files = Object.create(null);
  if (!gist.files || Object.keys(gist.files).length > 500) throw Error('Gist exceeds 500 files.');
  let manifest = {}, size = 0;
  for (const file of Object.values(gist.files)) {
    if (!/\.(muz|md)$/i.test(file.filename) && file.filename !== 'muzpad.json') continue;
    let content = file.content;
    if (file.truncated) {
      const raw = new URL(file.raw_url);
      if (raw.protocol !== 'https:' || raw.hostname !== 'gist.githubusercontent.com') throw Error('Invalid gist raw origin.');
      content = (await request(raw.href, fetchImpl, signal, MAX_TEXT - size)).text;
    }
    if (typeof content !== 'string') throw Error(`Missing gist file ${file.filename}`);
    size += new TextEncoder().encode(content).length;
    if (size > MAX_TEXT) throw Error('Gist source exceeds 4 MiB.');
    if (file.filename === 'muzpad.json') manifest = JSON.parse(content);
    else files[file.filename] = content;
  }
  const mapped = Object.create(null);
  for (const [name, text] of Object.entries(files)) {
    const path = projectPath(manifest.paths?.[name] || name);
    if (path in mapped) throw Error(`Duplicate gist path ${path}`);
    mapped[path] = text;
  }
  return normalizeProject({ title: manifest.title || gist.description, entry: manifest.entry, files: mapped });
}
"""

let render() = file
