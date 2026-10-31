module Muz.Source.Src.ProjectJs

let file = """export const MAX_TEXT = 4 * 1024 * 1024;
export const MAX_PROJECT = 64 * 1024 * 1024;
const encoder = new TextEncoder();
export function projectPath(path) {
  if (typeof path !== 'string' || !path || /[\\:\x00-\x1f]/.test(path)) throw Error('Invalid project path');
  const parts = path.split('/');
  if (parts.some(p => !p || ['.', '..', '__proto__', 'constructor', 'prototype'].includes(p))) throw Error(`Invalid project path: ${path}`);
  return parts.join('/');
}
export function normalizeProject(input) {
  if (!input || typeof input !== 'object' || !input.files || typeof input.files !== 'object' || Array.isArray(input.files)) throw Error('Expected a muz project with an entry and a files map.');
  const files = Object.create(null), assets = Object.create(null);
  let textBytes = 0, assetBytes = 0;
  const entries = Object.entries(input.files);
  if (entries.length > 500) throw Error('Project exceeds 500 source files.');
  for (const [path, text] of entries) {
    projectPath(path);
    if (typeof text !== 'string' || !/\.(muz|md)$/i.test(path)) throw Error(`Source files must be .muz or .md text: ${path}`);
    textBytes += encoder.encode(text).length;
    if (textBytes > MAX_TEXT) throw Error('Project source exceeds 4 MiB.');
    files[path] = text;
  }
  for (const [path, b64] of Object.entries(input.assets || {})) {
    projectPath(path);
    if (path in files || typeof b64 !== 'string' || !/^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$/.test(b64)) throw Error(`Invalid asset: ${path}`);
    assetBytes += Math.floor(b64.length / 4) * 3;
    if (assetBytes > MAX_PROJECT) throw Error('Project assets exceed 64 MiB.');
    assets[path] = b64;
  }
  if (Object.keys(assets).length > 500) throw Error('Project exceeds 500 assets.');
  const entry = projectPath(input.entry || ('song.muz' in files ? 'song.muz' : Object.keys(files).find(p => p.endsWith('.muz'))));
  if (!entry.endsWith('.muz') || !(entry in files)) throw Error('Choose an existing .muz entry file.');
  return { format: 'muzstatic/1', title: String(input.title || entry.replace(/\.muz$/, '')).slice(0, 200), entry, files, assets };
}
export function parseProject(text, name = 'song.muz') {
  if (encoder.encode(text).length > MAX_PROJECT * 1.4 + MAX_TEXT) throw Error('Project is too large.');
  const source = text.replace(/^\uFEFF/, '');
  let object;
  try { object = JSON.parse(source); } catch { /* Ordinary muz code is not JSON. */ }
  if (object?.files) return normalizeProject(object);
  if (/\.json$/i.test(name)) throw Error('This JSON is not a muz project (entry + files).');
  if (/^\s*(?:<!doctype|<html|<script)/i.test(source)) throw Error('The source returned an HTML page. Use its raw file URL.');
  let path = name.split('/').pop();
  if (!path?.endsWith('.muz')) path = 'song.muz';
  return normalizeProject({ title: path.replace(/\.muz$/, ''), entry: path, files: { [path]: source } });
}
export function bytesToBase64(bytes) {
  let binary = '';
  for (let i = 0; i < bytes.length; i += 8192) binary += String.fromCharCode(...bytes.subarray(i, i + 8192));
  return btoa(binary);
}
export async function importFiles(list) {
  const files = [...list];
  if (!files.length) throw Error('Choose a source file or project folder.');
  if (files.length === 1 && /\.json$/i.test(files[0].name)) return parseProject(await files[0].text(), files[0].name);
  if (files.length > 1000 || files.reduce((n, f) => n + f.size, 0) > MAX_PROJECT) throw Error('Project exceeds 1000 files or 64 MiB.');
  const result = { files: Object.create(null), assets: Object.create(null) };
  for (const file of files) {
    const path = projectPath(file.webkitRelativePath ? file.webkitRelativePath.split('/').slice(1).join('/') : file.name);
    if (/\.(muz|md)$/i.test(path)) result.files[path] = await file.text();
    else result.assets[path] = bytesToBase64(new Uint8Array(await file.arrayBuffer()));
  }
  return normalizeProject(result);
}
"""

let render() = file
