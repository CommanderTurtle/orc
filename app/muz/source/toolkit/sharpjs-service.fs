module Muz.Source.Toolkit.ServiceJs

let file = """import { readFile } from 'node:fs/promises';
import { fileURLToPath } from 'node:url';
import { resolve, join, dirname } from 'node:path';
import { createWorkspace } from './workspace.js';
import { runJob } from './runner.js';
import { object, string, number, integer, bool, array, validate } from './schema.js';

export const ROOT = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const projectShape = object({ title: string, entry: string, format: string, files: { type: 'object', additionalProperties: string }, assets: { type: 'object', additionalProperties: string } }, ['entry', 'files']);
const source = { path: { ...string, description: 'Relative to --root: one .muz file, project JSON, or a directory (includes relative modules/assets).' }, entry: { ...string, description: 'Entry inside a project directory; defaults to song.muz.' }, project: projectShape };
const mapOf = schema => ({ type: 'object', additionalProperties: schema });
export const analysisSchema = object({
  basis: { type: 'string', enum: ['score', 'performance'] }, fromMeasure: integer(1, 8192), measureCount: integer(1, 256),
  findingOffset: integer(0, 1_000_000), findingLimit: integer(1, 1000), excludeTracks: array(string), intervals: array(integer(1, 6)), minOverlap: string,
  intent: object({ key: object({ tonic: string, mode: string }, ['tonic', 'mode']), strictKey: bool, expectedBeats: string, phraseMeasures: integer(1, 8192), ranges: mapOf(array(number)), maxLeap: mapOf(number), maxPolyphony: mapOf(integer(0, 512)) }),
});
const definitions = [
  ['muz_read', 'Read source/plan text in --root with SHA-256 for revision-checked edits. Line numbers are one-based.', object({ path: string, startLine: integer(1, 1_000_000), limit: integer(1, 1000) }, ['path']), true],
  ['muz_write', 'Create native .muz/plan/policy text, or replace exactly a read revision. Existing files require expectedHash. No execution or automatic formatting.', object({ path: string, text: { ...string, maxLength: 4 * 1024 * 1024 }, expectedHash: string }, ['path', 'text']), false],
  ['muz_check', 'Compile, validate assets/graph/policies, and prepare the actual portable muz engine. Does not play audio. Returns source revision and structured compiler diagnostics.', object(source), true],
  ['muz_inspect', 'Paged native engine views. notes normalizes exact fractions to quarter-note beats. explain traces authored notes to source. Tick filters on native views use scorePpq/performedTracks.ppq from check; never assume 960.', object({ ...source, view: { type: 'string', enum: ['summary', 'sections', 'graph', 'score', 'performance', 'performance_overview', 'automation', 'automation_points', 'patches', 'patch_nodes', 'patch_detail', 'track_groups', 'locations', 'diagnostics', 'notes', 'explain'] }, basis: { type: 'string', enum: ['score', 'performance'] }, track: string, offset: integer(0, 1_000_000), limit: integer(1, 1000), start_tick: integer(0, Number.MAX_SAFE_INTEGER), end_tick: integer(1, Number.MAX_SAFE_INTEGER) }, ['view']), true],
  ['muz_analyze', 'Measure-by-measure key candidates, exact-overlap interval evidence, chord candidates, rhythm/register/polyphony and explicit intent constraints over compiled music. Musical evidence is advisory, not objective quality. Default: 32 measures of authored score; paginate nextMeasure/findings.next.', object({ ...source, options: analysisSchema }), true],
  ['muz_evaluate', 'Run an ordinary .muz script in the actual bounded evaluator: rational beat math, assertions, scales, voice-leading/reharmonization and pattern transforms. No song wrapper required. Use native language reference for syntax.', object(source), true],
  ['muz_format', 'Return engine-formatted .muz without writing. Supply source text or a single-file path. Strings and comments are preserved.', object({ source: string, path: string }), true],
  ['muz_render', 'Export actual engine WAV PCM24 stereo/48k or MIDI into --root; never plays speakers and never overwrites. seconds optionally requests a prefix preview. Full WAVs over 60s require an explicit larger maxSeconds budget (max 900). Native plugins/DAWProject need upstream desktop tools.', object({ ...source, format: { type: 'string', enum: ['wav', 'midi'] }, output: string, seconds: { ...number, minimum: .01, maximum: 900 }, maxSeconds: integer(1, 900) }, ['format', 'output']), false],
  ['muz_share', 'Build local lnkr v4 embedded/source/superlink URLs for muzstatic. Does not fetch or publish. Large links require an output .txt path so they do not flood model context. Raw .muz is single-file; use project JSON for imports/assets.', object({ ...source, mode: { type: 'string', enum: ['embedded', 'source', 'superlink'] }, url: string, baseUrl: string, output: string }), true],
  ['muz_reference', 'Read bundled composition/analysis guidance, real upstream docs, template or standard-library source. Use query to locate literal terms, then line paging. list returns available topics.', object({ topic: string, query: string, startLine: integer(1, 1_000_000), limit: integer(1, 300) }), true],
  ['muz_view_colorful', 'Export and view a deterministic PNG mathematical score portrait: circle-of-fifths gradient, complex unit-circle path, pitch/register, onset density, entropy, interval friction and phase motion. Uses actual compiled notes, not audio or a genre/quality classifier. Saves under --root, never overwrites. Defaults to up to 256 measures; nextMeasure discloses more.', object({ ...source, output: string, options: analysisSchema, width: integer(1200, 2400), pitchMin: integer(0, 126), pitchMax: integer(1, 127) }, ['output']), false],
];
export const tools = definitions.map(([name, description, inputSchema, readOnly]) => ({ name, description, inputSchema, annotations: { readOnlyHint: name === 'muz_share' ? false : readOnly, destructiveHint: name === 'muz_write', openWorldHint: false } }));

export async function createService({ root, wasm = join(ROOT, 'dist/assets/muz.wasm'), timeoutMs = 30_000 } = {}) {
  if (!root) throw Error('Supply --root /path/to/a/music-project (explicit workspace authority).');
  const workspace = await createWorkspace(root);
  const provenance = await readFile(join(dirname(wasm), 'engine.json'), 'utf8').then(JSON.parse).catch(() => null);
  async function reference(args) {
    const library = JSON.parse(await readFile(join(ROOT, 'dist/assets/library.json'), 'utf8'));
    const topics = ['compose', 'analysis', 'colorful', 'toolkit', 'language', 'workflow', 'performance', 'embedding', 'template', ...library.map(m => m.name)];
    if (!args.topic || args.topic === 'list') return { topics, engine: provenance };
    let text;
    if (args.topic === 'compose') text = await readFile(join(ROOT, 'skills/muz-compose/SKILL.md'), 'utf8');
    else if (['analysis', 'colorful', 'toolkit'].includes(args.topic)) text = await readFile(join(ROOT, `docs/${args.topic}.md`), 'utf8');
    else if (args.topic === 'template') text = await readFile(join(ROOT, 'dist/assets/template.muz'), 'utf8');
    else if (['language', 'workflow', 'performance', 'embedding'].includes(args.topic)) text = await readFile(join(ROOT, `dist/reference/${args.topic}.md`), 'utf8');
    else { text = library.find(m => m.name === args.topic)?.source; if (text === undefined) throw Error(`Unknown topic ${args.topic}; request list.`); }
    const lines = text.split('\n'); let start = args.startLine || 1;
    if (args.query) {
      const hits = lines.map((line, i) => line.toLowerCase().includes(args.query.toLowerCase()) ? i + 1 : 0).filter(Boolean);
      if (!hits.length) return { topic: args.topic, matches: [], totalLines: lines.length, engine: provenance };
      if (!args.startLine) start = Math.max(1, hits[0] - 4);
      return { topic: args.topic, matches: hits.slice(0, 100), totalMatches: hits.length, ...page(lines, start, args.limit || 100), engine: provenance };
    }
    return { topic: args.topic, ...page(lines, start, args.limit || 100), engine: provenance };
  }
  return {
    root: workspace.root, engine: provenance, reference,
    async call(name, args = {}, { signal, images = false } = {}) {
      const tool = tools.find(t => t.name === name);
      if (!tool) throw Error(`Unknown tool: ${name}`);
      validate(args, tool.inputSchema);
      if (name === 'muz_read') return workspace.read(args.path, args.startLine, args.limit);
      if (name === 'muz_write') return workspace.write(args.path, args.text, args.expectedHash);
      if (name === 'muz_reference') return reference(args);
      const action = name.slice(4);
      if (action === 'format') {
        if ((args.source === undefined) === (args.path === undefined)) throw Error('Supply source OR path.');
        let source = args.source;
        if (args.path !== undefined) { const loaded = await workspace.project({ path: args.path }); if (Object.keys(loaded.project.files).length !== 1 || Object.keys(loaded.project.assets).length) throw Error('format path must be one .muz file.'); source = loaded.project.files[loaded.project.entry]; }
        return runJob({ action, source }, { wasm, timeoutMs, signal });
      }
      if (action === 'share' && ['source', 'superlink'].includes(args.mode)) {
        if (!args.url || args.path || args.project || args.entry) throw Error('Source/superlink mode needs url only, not project input.');
        return share(null, args);
      }
      const loaded = await workspace.project(args);
      if (action === 'share') return share(loaded, args);
      const job = { action, project: loaded.project };
      if (action === 'view_colorful') {
        if (!args.output.toLowerCase().endsWith('.png')) throw Error('Colorful output must end in .png.');
        job.action = 'colorful'; job.options = args.options;
        job.drawing = { width: args.width, pitchMin: args.pitchMin, pitchMax: args.pitchMax };
        job.provenance = { sourceRevision: loaded.revision, engine: provenance };
      }
      if (action === 'inspect') {
        if (args.basis && args.view !== 'notes') throw Error('basis applies only to the normalized notes view. Native score/performance views already identify their basis.');
        job.view = args.view; job.basis = args.basis || 'score'; job.page = {};
        for (const field of ['track', 'offset', 'limit', 'start_tick', 'end_tick']) if (args[field] !== undefined) job.page[field] = args[field];
        if (['notes', 'explain'].includes(args.view) && (args.start_tick !== undefined || args.end_tick !== undefined)) throw Error('notes/explain use note offsets, not tick filters.');
        if (args.view === 'explain' && !args.track) throw Error('explain requires an authored score track ID.');
      }
      if (action === 'analyze') job.options = args.options;
      if (action === 'render') {
        if (!args.output.toLowerCase().endsWith(args.format === 'wav' ? '.wav' : '.mid') && !(args.format === 'midi' && args.output.toLowerCase().endsWith('.midi'))) throw Error('Output extension must match wav or mid/midi.');
        job.format = args.format; job.seconds = args.seconds; job.maxSeconds = args.maxSeconds || 60;
        if (args.format === 'midi' && (args.seconds !== undefined || args.maxSeconds !== undefined)) throw Error('MIDI is full-project export; seconds/maxSeconds apply only to WAV.');
      }
      const result = await runJob(job, { wasm, timeoutMs, signal });
      if (signal?.aborted) throw Error('Cancelled.');
      if (action === 'view_colorful') {
        if (result.bytes.length > 4 * 1024 * 1024) throw Error('PNG exceeds 4 MiB; request a smaller width/window.');
        return { ...result.metadata, ...await workspace.save(args.output, result.bytes), ...(images ? { _image: { type: 'image', mimeType: 'image/png', data: Buffer.from(result.bytes).toString('base64') } } : {}) };
      }
      if (action === 'render') {
        const { bytes, info, ...metadata } = result;
        return { ...metadata, ...await workspace.save(args.output, bytes), sourceRevision: loaded.revision, engine: provenance };
      }
      return { ...result, sourceRevision: loaded.revision, engine: provenance };
    },
  };
  async function share(loaded, args) {
    const { embeddedFragment, sourceFragment } = await import('../src/links.js');
    const mode = args.mode || 'embedded';
    if (mode === 'embedded' && args.url) throw Error('embedded mode uses project bytes; use source/superlink mode for url.');
    const fragment = mode === 'embedded' ? embeddedFragment(loaded.project) : sourceFragment(args.url, mode === 'superlink');
    const base = new URL(args.baseUrl || 'http://127.0.0.1:8196/');
    if (!['http:', 'https:'].includes(base.protocol) || base.username || base.password) throw Error('baseUrl must be a credential-free HTTP(S) frontend URL.');
    base.hash = ''; base.search = ''; const url = base.href + fragment;
    if (args.output && !args.output.endsWith('.txt')) throw Error('Share output must end in .txt.');
    const saved = args.output ? await workspace.save(args.output, Buffer.from(url + '\n')) : null;
    return { mode, characters: url.length, url: url.length <= 4096 ? url : undefined, output: saved, sourceRevision: loaded?.revision, note: url.length > 4096 && !saved ? 'Supply output to save the complete URL. Nothing was published.' : 'URL created locally. Nothing was published.' };
  }
}
function page(lines, start, limit) {
  return { startLine: start, totalLines: lines.length, nextLine: start + limit <= lines.length ? start + limit : null, text: lines.slice(start - 1, start - 1 + limit).join('\n') };
}
"""

let render() = file
