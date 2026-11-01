module Muz.Source.Scripts.WorkbenchMjs

let file = """import { cp, mkdir, readFile, writeFile, stat } from 'node:fs/promises';
import { join, resolve } from 'node:path';
import { pathToFileURL } from 'node:url';
import { spawnSync } from 'node:child_process';
import { createHash } from 'node:crypto';

// Keep the upstream workbench whole. The integration changes only project/link
// ingress/egress and build paths; transport, editor, inspection and native host
// contracts are the published implementations, not parallel reconstructions.
export async function buildWorkbench({ root, engine, catalogRoot, provenance, removeGenerated }) {
  const pin = JSON.parse(await readFile(join(root, 'workbench.json'), 'utf8'));
  if (!/^[a-f0-9]{40}$/.test(pin.revision) || pin.repository !== 'https://github.com/apage43/muzpad.git') throw Error('Invalid workbench source pin.');
  const source = join(root, '.cache/muzpad-upstream'), stage = join(root, '.cache/workbench');
  const run = (command, args, cwd = root) => {
    const result = spawnSync(command, args, { cwd, stdio: 'inherit', env: { ...process.env, GIT_TERMINAL_PROMPT: '0' } });
    if (result.error) throw result.error; if (result.status) throw Error(`${command} exited ${result.status}`);
  };
  if (!await stat(join(source, '.git')).catch(() => false)) run('git', ['-c', 'credential.helper=', '-c', 'core.askPass=', 'clone', '--filter=blob:none', '--no-checkout', pin.repository, source]);
  const head = spawnSync('git', ['rev-parse', 'HEAD'], { cwd: source, encoding: 'utf8' }).stdout?.trim();
  if (head !== pin.revision) run('git', ['-c', 'credential.helper=', '-c', 'core.askPass=', 'fetch', '--depth', '1', 'origin', pin.revision], source);
  // --no-checkout clones can already name the desired HEAD while having no
  // working files yet; materialize the pinned tree even on that first build.
  run('git', ['checkout', '--detach', pin.revision], source);
  await removeGenerated(stage); await mkdir(stage, { recursive: true });
  for (const name of ['src', 'public', 'wasm', 'scripts', '.cargo', 'Cargo.toml', 'Cargo.lock', 'package.json', 'package-lock.json', 'index.html', 'tsconfig.json', 'README.md', 'AGENTS.md']) await cp(join(source, name), join(stage, name), { recursive: true });
  const replace = (text, needle, value) => {
    if (!text.includes(needle) || text.indexOf(needle) !== text.lastIndexOf(needle)) throw Error(`Workbench integration anchor changed: ${needle.slice(0, 90)}`);
    return text.replace(needle, value);
  };
  const cargo = await readFile(join(stage, 'wasm/Cargo.toml'), 'utf8');
  await writeFile(join(stage, 'wasm/Cargo.toml'), replace(cargo, '../../muz-core', '../../muz'));
  await writeFile(join(stage, 'build.config.json'), JSON.stringify({ core: '../muz', gists: [] }));
  await cp(join(root, 'src/workbench-bridge.js'), join(stage, 'src/muzstatic-bridge.js'));
  let main = (await readFile(join(stage, 'src/main.ts'), 'utf8')).replaceAll('\r\n', '\n');
  main = 'import { incomingMuzstatic, installMuzstatic } from "./muzstatic-bridge.js";\n' + main;
  main = replace(main, '  if (requested !== null) {\n    setGistURL(requested);', '  const linked = await incomingMuzstatic();\n  if (linked) {\n    await importMuzstatic(linked);\n  } else if (requested !== null) {\n    setGistURL(requested);');
  main += `
async function importMuzstatic(p: any) {
  return replaceProject(() => host.projects.importProject({ kind: "content", project: {
    settings: { title: p.title, entry: p.entry },
    files: Object.entries(p.files as Record<string,string>).map(([path, text]) => ({path, text})),
    assets: Object.entries(p.workbenchAssets as Record<string,{format:"midi"|"wav"|"flac";base64:string}>).map(([path,value]) => ({path,...value})),
  } }, operation()));
}
if (runtime.capabilities.environment === "web") installMuzstatic({
  importProject: importMuzstatic,
  snapshot: async () => { const input = capture(); await host.projects.persistRecovery(input, operation()); return (host.projects as any).muzstaticSnapshot(input, operation()); },
  projectId: () => project?.project,
});
`;
  await writeFile(join(stage, 'src/main.ts'), main);
  let store = (await readFile(join(stage, 'src/host/web-projects.ts'), 'utf8')).replaceAll('\r\n', '\n');
  store = replace(store, '  exportArchive(input: WorkingCapture, op: Operation): Promise<ArchiveResult> {', `  muzstaticSnapshot(input: WorkingCapture, op: Operation) {
    abort(op);
    const { state } = this.capture(input);
    return { format: "muzstatic/1", title: state.settings.title, entry: state.settings.entry,
      files: workingFiles(state), assets: Object.fromEntries(Object.entries(state.assets).map(([path, asset]) => [path, asset.base64])) };
  }
  exportArchive(input: WorkingCapture, op: Operation): Promise<ArchiveResult> {`);
  await writeFile(join(stage, 'src/host/web-projects.ts'), store);
  run('cargo', ['build', '--release', '--target', 'wasm32-unknown-unknown', '--locked', '--target-dir', join(root, 'engine/target')], stage);
  await cp(join(root, 'engine/target/wasm32-unknown-unknown/release/muzpad_wasm.wasm'), join(stage, 'public/muz.wasm'));
  const { buildCatalog } = await import(pathToFileURL(join(source, 'scripts/catalog.mjs')).href);
  const catalog = await buildCatalog(join(stage, 'build.config.json'), catalogRoot);
  catalog.engine = { commit: provenance.revision, clean: !provenance.dirty };
  await writeFile(join(stage, 'public/catalog.json'), JSON.stringify(catalog));
  const dependencies = JSON.parse(await readFile(join(root, 'package.json'), 'utf8')).devDependencies;
  const metadata = { ...pin, engine: provenance, dependencies, integrationSha256: createHash('sha256').update(main).update(store).update(await readFile(join(root, 'src/workbench-bridge.js'))).digest('hex') };
  await writeFile(join(stage, 'public/engine-build.json'), JSON.stringify({ commit: provenance.revision, clean: !provenance.dirty, wasmSha256: createHash('sha256').update(await readFile(join(stage, 'public/muz.wasm'))).digest('hex') }));
  await writeFile(join(stage, 'public/workbench-build.json'), JSON.stringify(metadata, null, 2));
  const { build } = await import('vite');
  await build({ root: stage, configFile: false, base: './', resolve: { alias: { 'muzstatic/project': resolve(root, 'src/project.js'), 'muzstatic/links': resolve(root, 'src/links.js'), 'muzstatic/workbench-project': resolve(root, 'src/workbench-project.js'), 'muzstatic/project-transfer': resolve(root, 'src/project-transfer.js') } }, build: { outDir: join(root, 'dist/workbench'), emptyOutDir: true } });
  // Exact modified build inputs travel with the distribution too.
  const output = join(root, 'dist/source/workbench'); await removeGenerated(output); await mkdir(output, { recursive: true });
  for (const name of ['src', 'public/player-worklet.js', 'wasm', '.cargo', 'Cargo.toml', 'Cargo.lock', 'package.json', 'package-lock.json', 'index.html', 'tsconfig.json', 'README.md']) await cp(join(stage, name), join(output, name), { recursive: true });
  await writeFile(join(output, 'UPSTREAM.json'), JSON.stringify(metadata, null, 2));
  console.log(`Bundled upstream muzpad ${pin.revision} at dist/workbench/`);
}
"""

let render() = file
