module Muz.Source.Scripts.ServeMjs

let file = """import { resolve, dirname, sep } from 'node:path';
import { fileURLToPath } from 'node:url';
const root = resolve(dirname(fileURLToPath(import.meta.url)), '../dist');
const port = Number(process.env.PORT || 8196);
const server = Bun.serve({ hostname: '127.0.0.1', port, async fetch(request) {
  let path;
  try { path = resolve(root, '.' + decodeURIComponent(new URL(request.url).pathname)); } catch { return new Response('Bad path', { status: 400 }); }
  if (path !== root && !path.startsWith(root + sep)) return new Response('Not found', { status: 404 });
  let file = Bun.file(path === root ? resolve(root, 'index.html') : path);
  if (!await file.exists()) return new Response('Not found', { status: 404 });
  return new Response(file, { headers: { 'Cache-Control': 'no-cache', 'X-Content-Type-Options': 'nosniff' } });
} });
console.log(`Local: http://127.0.0.1:${server.port}/`);
"""

let render() = file
