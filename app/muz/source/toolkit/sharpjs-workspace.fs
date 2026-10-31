module Muz.Source.Toolkit.WorkspaceJs

let file = """import { realpath, readFile, readdir, stat, lstat, mkdir, open } from 'node:fs/promises';
import { resolve, relative, isAbsolute, join, dirname, basename, extname } from 'node:path';
import { createHash } from 'node:crypto';
import { normalizeProject, parseProject, MAX_TEXT, MAX_PROJECT } from '../src/project.js';

export const hash = bytes => createHash('sha256').update(bytes).digest('hex');
const omit = new Set(['.git', '.cache', '.work', 'node_modules', 'target', 'dist']);
const assets = new Set(['.wav', '.flac', '.mid', '.midi', '.sfz', '.json']);
const within = (root, path) => { const rel = relative(root, path); return !isAbsolute(rel) && rel !== '..' && !rel.startsWith('..\\') && !rel.startsWith('../'); };

export async function createWorkspace(root) {
  const canonical = await realpath(resolve(root));
  if (!(await stat(canonical)).isDirectory()) throw Error('--root must be a directory.');
  function lexical(path) {
    if (typeof path !== 'string' || !path || path.includes('\0')) throw Error('A workspace-relative path is required.');
    const resolved = resolve(canonical, path);
    if (!within(canonical, resolved)) throw Error('Path escapes --root.');
    return resolved;
  }
  async function existing(path) {
    const resolved = await realpath(lexical(path));
    if (!within(canonical, resolved)) throw Error('Symlink escapes --root.');
    return resolved;
  }
  async function output(path) {
    const target = lexical(path);
    if (target === canonical) throw Error('Output must be a file inside --root.');
    const parts = relative(canonical, dirname(target)).split(/[\\/]/).filter(Boolean);
    let parent = canonical;
    for (const part of parts) {
      parent = join(parent, part); await mkdir(parent).catch(error => { if (error.code !== 'EEXIST') throw error; });
      const actual = await realpath(parent);
      if (!within(canonical, actual)) throw Error('Output parent symlink escapes --root.');
    }
    return target;
  }
  async function boundedRead(path, maximum) {
    const handle = await open(path, 'r');
    try {
      const size = (await handle.stat()).size;
      if (size > maximum) throw Error(`File exceeds ${maximum} byte limit.`);
      // Read at most the boundary even if another process grows the file.
      const bytes = Buffer.alloc(size + 1); let used = 0;
      while (used < bytes.length) { const { bytesRead } = await handle.read(bytes, used, bytes.length - used, used); if (!bytesRead) break; used += bytesRead; }
      if (used !== size) throw Error('File changed during read; retry.');
      return bytes.subarray(0, used);
    } finally { await handle.close(); }
  }
  async function project(input) {
    if (input.project !== undefined) {
      if (input.path !== undefined || input.entry !== undefined) throw Error('Use project OR path/entry, not both.');
      const value = normalizeProject(input.project); return { project: value, revision: hash(JSON.stringify(value)) };
    }
    const path = await existing(input.path || 'song.muz'), meta = await stat(path);
    let value;
    if (meta.isFile()) {
      if (input.entry !== undefined) throw Error('entry applies only to a project directory.');
      if (!/\.(muz|json)$/i.test(path)) throw Error('Expected .muz, project JSON, or a project directory.');
      value = parseProject((await boundedRead(path, MAX_PROJECT * 1.4 + MAX_TEXT)).toString('utf8'), basename(path));
    } else if (meta.isDirectory()) {
      const files = Object.create(null), binary = Object.create(null);
      let sourceBytes = 0, assetBytes = 0, count = 0;
      async function walk(dir, prefix = '') {
        for (const item of (await readdir(dir, { withFileTypes: true })).sort((a, b) => a.name.localeCompare(b.name))) {
          if (omit.has(item.name) || item.name.startsWith('.')) continue;
          if (item.isSymbolicLink()) throw Error(`Project directory contains a symlink: ${prefix + item.name}. Bundle explicit bytes in project JSON instead.`);
          const full = await existing(join(dir, item.name)), name = prefix + item.name;
          if (item.isDirectory()) { await walk(full, name + '/'); continue; }
          if (!item.isFile()) continue;
          const ext = extname(name).toLowerCase();
          if (!['.muz', '.md'].includes(ext) && !assets.has(ext)) continue;
          if (++count > 1000) throw Error('Project exceeds 1000 files.');
          const source = ['.muz', '.md'].includes(ext);
          const bytes = await boundedRead(full, source ? MAX_TEXT - sourceBytes : MAX_PROJECT - assetBytes);
          if (source) { sourceBytes += bytes.length; files[name] = bytes.toString('utf8'); }
          else { assetBytes += bytes.length; binary[name] = bytes.toString('base64'); }
        }
      }
      await walk(path);
      value = normalizeProject({ entry: input.entry, files, assets: binary, title: basename(path) });
    } else throw Error('Project path is not a regular file/directory.');
    return { project: value, revision: hash(JSON.stringify(value)) };
  }
  return {
    root: canonical, project,
    async read(path, startLine = 1, limit = 120) {
      if (!Number.isInteger(startLine) || startLine < 1 || !Number.isInteger(limit) || limit < 1 || limit > 1000) throw Error('startLine must be positive and limit 1..1000.');
      const actual = await existing(path);
      if (!/\.(muz|md|json|txt)$/i.test(actual)) throw Error('Read expects .muz/.md/.json/.txt.');
      const bytes = await boundedRead(actual, MAX_TEXT), lines = bytes.toString('utf8').split('\n');
      return { path: actual, sha256: hash(bytes), startLine, totalLines: lines.length, nextLine: startLine + limit <= lines.length ? startLine + limit : null, text: lines.slice(startLine - 1, startLine - 1 + limit).join('\n') };
    },
    async write(path, text, expectedHash) {
      if (!/\.(muz|md|json)$/i.test(path)) throw Error('Source writes require .muz/.md/.json.');
      if (typeof text !== 'string' || Buffer.byteLength(text) > MAX_TEXT) throw Error('Text exceeds 4 MiB.');
      const target = await output(path);
      const current = await lstat(target).catch(error => { if (error.code !== 'ENOENT') throw error; return null; });
      if (current?.isSymbolicLink()) throw Error('Refusing to overwrite a symlink.');
      if (current && !expectedHash) throw Error('File exists. Read it and supply expectedHash to replace that revision.');
      if (!current && expectedHash) throw Error('Expected an existing revision, but the file is absent.');
      const handle = await open(target, current ? 'r+' : 'wx');
      try {
        if (current && hash(await handle.readFile()) !== expectedHash) throw Error('Revision changed; read the current file before editing.');
        const bytes = Buffer.from(text); let used = 0;
        while (used < bytes.length) { const { bytesWritten } = await handle.write(bytes, used, bytes.length - used, used); if (!bytesWritten) throw Error('Source write made no progress.'); used += bytesWritten; }
        await handle.truncate(bytes.length); await handle.sync();
      } finally { await handle.close(); }
      return { path: target, bytes: Buffer.byteLength(text), sha256: hash(text) };
    },
    async save(path, bytes) {
      const target = await output(path), handle = await open(target, 'wx');
      try { await handle.writeFile(bytes); } finally { await handle.close(); }
      return { path: target, bytes: bytes.length, sha256: hash(bytes) };
    },
  };
}
"""

let render() = file
