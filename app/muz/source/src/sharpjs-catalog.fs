module Muz.Source.Src.CatalogJs

let file = """import { MAX_TEXT, MAX_PROJECT, bytesToBase64, normalizeProject, projectPath } from './project.js';
function sourceURL(input, base) {
  if (typeof input !== 'string' || !input.trim()) throw Error('A resource URL is required.');
  const url = new URL(input, base);
  if (!['https:', 'http:'].includes(url.protocol) || url.username || url.password) throw Error('Catalog resources need public HTTP(S) URLs.');
  return url.href;
}
export async function readResource(url, limit, signal, fetcher = fetch) {
  if (!Number.isSafeInteger(limit) || limit < 0) throw Error('Project size limit exceeded.');
  const response = await fetcher(url, { signal: AbortSignal.any([signal || new AbortController().signal, AbortSignal.timeout(30000)]), credentials: 'omit', referrerPolicy: 'no-referrer' });
  if (!response.ok) throw Error(`Resource request failed (${response.status}): ${url}`);
  if (Number(response.headers.get('content-length')) > limit) throw Error('Resource exceeds the project size limit.');
  const reader = response.body?.getReader();
  if (!reader) throw Error('Resource has no readable body.');
  const chunks = []; let size = 0;
  try {
    for (;;) { const { value, done } = await reader.read(); if (done) break; size += value.length; if (size > limit) throw Error('Resource exceeds the project size limit.'); chunks.push(value); }
  } finally { await reader.cancel().catch(() => {}); }
  const bytes = new Uint8Array(size); let offset = 0; for (const chunk of chunks) { bytes.set(chunk, offset); offset += chunk.length; }
  return bytes;
}
export function normalizeCatalog(input, baseURL) {
  if (!input || !Array.isArray(input.files) || input.files.length > 20000) throw Error('Expected a catalog with a files array (up to 20,000 entries).');
  const prefix = input.mount ? projectPath(input.mount) + '/' : '';
  const paths = new Set();
  const files = input.files.map(file => {
    const path = projectPath(prefix + projectPath(file.path));
    if (paths.has(path)) throw Error(`Duplicate catalog resource: ${path}`); paths.add(path);
    if (file.sha256 !== undefined && (typeof file.sha256 !== 'string' || !/^[a-f\d]{64}$/i.test(file.sha256))) throw Error('Invalid catalog SHA-256.');
    if (file.bytes !== undefined && (!Number.isSafeInteger(file.bytes) || file.bytes < 0)) throw Error('Invalid catalog byte size.');
    if (file.text !== undefined && (typeof file.text !== 'string' || !/\.(muz|md)$/i.test(path))) throw Error('Inline catalog text must be .muz or .md source.');
    return { path, ...(file.text !== undefined ? { text: file.text } : { url: sourceURL(file.url, baseURL) }), bytes: file.bytes, sha256: file.sha256?.toLowerCase() };
  });
  return { title: String(input.title || input.library || 'Sample catalog').slice(0, 200), license: String(input.license || 'See publisher terms').slice(0, 300), homepage: input.homepage ? sourceURL(input.homepage, baseURL) : undefined, files };
}
export async function loadCatalog(url, signal, fetcher = fetch) {
  const absolute = sourceURL(url);
  return normalizeCatalog(JSON.parse(new TextDecoder('utf-8', { fatal: true }).decode(await readResource(absolute, MAX_TEXT, signal, fetcher))), absolute);
}
export async function importCatalog(project, resources, { signal, progress = () => {}, fetcher = fetch } = {}) {
  if (!Array.isArray(resources) || !resources.length || resources.length > 500) throw Error('Choose 1…500 catalog resources.');
  const files = { ...project.files }, assets = { ...project.assets };
  const originalSize = Object.values(assets).reduce((n, value) => n + Math.floor(value.length / 4) * 3, 0);
  const encoder = new TextEncoder();
  let downloaded = 0, textBytes = Object.values(files).reduce((n, text) => n + encoder.encode(text).length, 0);
  // The caller only commits this candidate when every requested file verifies.
  for (let i = 0; i < resources.length; i++) {
    signal?.throwIfAborted(); const resource = resources[i], path = projectPath(resource.path);
    if (path in files || path in assets) throw Error(`Resource already exists: ${path}`);
    const textFile = /\.(muz|md)$/i.test(path);
    if (Object.keys(textFile ? files : assets).length >= 500) throw Error('Project exceeds 500 files of this type.');
    const remaining = textFile ? MAX_TEXT - textBytes : MAX_PROJECT - originalSize - downloaded;
    if (resource.bytes !== undefined && resource.bytes > remaining) throw Error('Resource exceeds the project size limit.');
    const bytes = resource.text === undefined ? await readResource(sourceURL(resource.url), remaining, signal, fetcher) : encoder.encode(resource.text);
    if (bytes.length > remaining) throw Error('Resource exceeds the project size limit.');
    if (resource.bytes !== undefined && bytes.length !== resource.bytes) throw Error(`Size mismatch: ${path}`);
    if (resource.sha256) {
      const digest = [...new Uint8Array(await crypto.subtle.digest('SHA-256', bytes))].map(n => n.toString(16).padStart(2, '0')).join('');
      if (digest !== resource.sha256) throw Error(`SHA-256 mismatch: ${path}`);
    }
    if (textFile) { files[path] = new TextDecoder('utf-8', { fatal: true }).decode(bytes); textBytes += bytes.length; }
    else { assets[path] = bytesToBase64(bytes); downloaded += bytes.length; }
    progress((i + 1) / resources.length);
  }
  return normalizeProject({ ...project, files, assets });
}
"""

let render() = file
