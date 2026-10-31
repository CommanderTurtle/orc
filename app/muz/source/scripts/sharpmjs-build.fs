module Muz.Source.Scripts.BuildMjs

let file = """import { cp, mkdir, readFile, writeFile, stat, rm, realpath } from 'node:fs/promises';
import { resolve, dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';
import { spawnSync } from 'node:child_process';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const args = process.argv.slice(2);
const configPath = join(root, '.local.json');
const config = await readFile(configPath, 'utf8').then(JSON.parse).catch(() => ({}));
const upstream = JSON.parse(await readFile(join(root, 'upstream.json'), 'utf8'));
const value = key => args.includes(key) ? args[args.indexOf(key) + 1] : undefined;
function run(command, argv, cwd = root) {
  const result = spawnSync(command, argv, { cwd, stdio: 'inherit', shell: false, env: { ...process.env, GIT_TERMINAL_PROMPT: '0' } });
  if (result.error) throw result.error;
  if (result.status !== 0) throw Error(`${command} exited ${result.status}`);
}
if (value('--engine-dir')) {
  config.engineDir = resolve(value('--engine-dir'));
  await stat(join(config.engineDir, 'src/lib.rs'));
  await writeFile(configPath, JSON.stringify(config, null, 2) + '\n');
}
if (args.includes('--upstream')) {
  delete config.engineDir;
  await writeFile(configPath, JSON.stringify(config, null, 2) + '\n');
}
const engine = join(root, '.cache/muz');
await mkdir(join(root, '.cache'), { recursive: true });
async function removeGenerated(path) {
  const actual = await realpath(path).catch(() => undefined);
  if (!actual) return;
  const actualRoot = await realpath(root);
  const { relative, isAbsolute } = await import('node:path');
  const rel = relative(actualRoot, actual);
  if (!rel || rel.startsWith('..') || isAbsolute(rel)) throw Error('Refusing to remove a cache outside this project.');
  await rm(path, { recursive: true, force: true });
}
let provenance;
if (config.engineDir) {
  // Refresh the selected local installation on every build, including uncommitted edits.
  // Only copy engine build inputs. Never modify the selected checkout.
  await mkdir(engine, { recursive: true });
  for (const name of ['Cargo.toml', 'src', 'std', 'templates', 'crates']) {
    if (resolve(config.engineDir) === resolve(engine)) throw Error('--engine-dir must point to your source checkout, not the generated cache.');
    await removeGenerated(join(engine, name));
    await cp(join(config.engineDir, name), join(engine, name), { recursive: true, force: true, filter: path => !/(?:^|[\\/])(?:target|\.git)(?:[\\/]|$)/.test(path) });
  }
  const result = spawnSync('git', ['-C', config.engineDir, 'rev-parse', 'HEAD'], { encoding: 'utf8' });
  const dirty = spawnSync('git', ['-C', config.engineDir, 'status', '--porcelain'], { encoding: 'utf8' });
  provenance = { repository: upstream.repository, revision: result.stdout?.trim() || 'local', local: true, dirty: Boolean(dirty.stdout?.trim()) };
} else {
  const exists = await stat(join(engine, '.git')).then(() => true).catch(() => false);
  if (!exists) {
    await removeGenerated(engine);
    run('git', ['-c', 'credential.helper=', '-c', 'core.askPass=', 'clone', '--no-checkout', '--filter=blob:none', upstream.repository, engine]);
  }
  const current = spawnSync('git', ['rev-parse', 'HEAD'], { cwd: engine, encoding: 'utf8' });
  if (current.stdout?.trim() !== upstream.revision) {
    run('git', ['-c', 'credential.helper=', '-c', 'core.askPass=', 'fetch', '--depth', '1', 'origin', upstream.revision], engine);
    run('git', ['checkout', '--detach', upstream.revision], engine);
  }
  provenance = { repository: upstream.repository, revision: upstream.revision, local: false, dirty: false };
}
// The bridge has its own lockfile and no desktop features. No patching of upstream.
const lock = await stat(join(root, 'engine/Cargo.lock')).then(() => true).catch(() => false);
run('cargo', ['build', '--release', '--target', 'wasm32-unknown-unknown', '--manifest-path', 'engine/Cargo.toml', ...(lock ? ['--locked'] : [])]);
await mkdir(join(root, 'dist/assets'), { recursive: true });
await cp(join(root, 'engine/target/wasm32-unknown-unknown/release/muzstatic_engine.wasm'), join(root, 'dist/assets/muz.wasm'));
await cp(join(root, 'src/index.html'), join(root, 'dist/index.html'));
await cp(join(root, 'src/style.css'), join(root, 'dist/assets/style.css'));
const build = await Bun.build({ entrypoints: ['src/app.js', 'src/engine-worker.js', 'src/data-worker.js'], root: join(root, 'src'), outdir: join(root, 'dist/assets'), target: 'browser', minify: true, sourcemap: 'none' });
if (!build.success) throw new AggregateError(build.logs, 'Browser build failed');
await cp(join(root, 'src/player-worklet.js'), join(root, 'dist/assets/player-worklet.js'));
await writeFile(join(root, 'dist/assets/engine.json'), JSON.stringify(provenance, null, 2));
await writeFile(join(root, 'dist/assets/template.muz'), await readFile(join(engine, 'templates/song.muz')));
// Language reference and source libraries ship locally too; no runtime CDN.
const modules = [];
async function collect(dir, prefix) {
  const { readdir } = await import('node:fs/promises');
  for (const item of await readdir(dir, { withFileTypes: true })) {
    if (item.isDirectory()) await collect(join(dir, item.name), `${prefix}/${item.name}`);
    else if (item.name.endsWith('.muz')) modules.push({ name: `${prefix}/${item.name}`, source: await readFile(join(dir, item.name), 'utf8') });
  }
}
await collect(join(engine, 'std'), 'std');
await writeFile(join(root, 'dist/assets/library.json'), JSON.stringify(modules));
await mkdir(join(root, 'dist/reference'), { recursive: true });
for (const topic of ['language', 'workflow', 'performance', 'embedding']) {
  const selected = config.engineDir ? join(config.engineDir, `docs/${topic}.md`) : join(engine, `docs/${topic}.md`);
  await cp(selected, join(root, `dist/reference/${topic}.md`));
}
const source = join(root, 'dist/source');
await removeGenerated(source);
await mkdir(join(source, 'engine'), { recursive: true });
for (const name of ['src', 'scripts', 'tests', 'toolkit', 'skills', 'docs', 'examples', '.gitignore', '.gitattributes', 'package.json', 'upstream.json', 'README.md', 'LICENSE']) await cp(join(root, name), join(source, name), { recursive: true });
for (const name of ['src', 'Cargo.toml', 'Cargo.lock']) await cp(join(root, 'engine', name), join(source, 'engine', name), { recursive: true });
await cp(engine, join(source, 'upstream-muz'), { recursive: true, filter: path => !/(?:^|[\\/])(?:target|\.git)(?:[\\/]|$)/.test(path) });
await mkdir(join(source, 'upstream-muz/docs'), { recursive: true });
for (const topic of ['language', 'workflow', 'performance', 'embedding']) await cp(join(root, `dist/reference/${topic}.md`), join(source, `upstream-muz/docs/${topic}.md`));
await writeFile(join(source, 'BUILD.txt'), 'Corresponding source for this build. From this directory: bun run dev --engine-dir ./upstream-muz\nEngine dependencies are selected by engine/Cargo.lock. Runtime files are ../assets/.\n');
const sourceFiles = [];
async function indexSource(dir, prefix = '') {
  const { readdir } = await import('node:fs/promises');
  for (const item of await readdir(dir, { withFileTypes: true })) {
    const name = prefix + item.name;
    if (item.isDirectory()) await indexSource(join(dir, item.name), name + '/');
    else sourceFiles.push(name);
  }
}
await indexSource(source);
const escapeHTML = s => s.replaceAll('&', '&amp;').replaceAll('<', '&lt;').replaceAll('"', '&quot;');
await writeFile(join(source, 'index.html'), '<!doctype html><meta charset="utf-8"><title>muzstatic source</title><style>body{font:14px monospace;max-width:1000px;margin:40px auto;background:#101419;color:#d4dce5}a{color:#89d6b4}li{margin:6px}</style><h1>muzstatic source</h1><p>Exact frontend and selected muz source for this build. <a href="BUILD.txt">Build instructions</a></p><ul>' + sourceFiles.map(p => '<li><a href="' + escapeHTML(p.split('/').map(encodeURIComponent).join('/')) + '">' + escapeHTML(p) + '</a></li>').join('') + '</ul>');
console.log(`Built dist/ with muz ${provenance.revision}${provenance.dirty ? ' (local edits)' : ''}`);
if (args.includes('--serve')) await import('./serve.mjs');
"""

let render() = file
