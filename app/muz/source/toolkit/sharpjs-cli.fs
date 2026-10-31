module Muz.Source.Toolkit.CliJs

let file = """import { createService } from './service.js';
import { createWorkspace } from './workspace.js';

const argv = process.argv.slice(2); let action = argv.shift();
if (action === 'view' && argv[0] === 'colorful') { argv.shift(); action = 'view_colorful'; }
const names = new Set(['check', 'inspect', 'analyze', 'evaluate', 'format', 'render', 'share', 'reference', 'read', 'write', 'view_colorful']);
const help = 'Usage: bun run muz ACTION [PROJECT] --root DIR [--view score] [--format wav --output out.wav] [--options intent.json] [--args JSON]\nActions: check, inspect, analyze, evaluate, format, render, share, reference, read, write, view colorful\nAll output is JSON. format never writes. MCP: bun run mcp --root DIR\n';
if (!names.has(action)) { process.stderr.write(help); process.exit(action === '--help' ? 0 : 1); }
try {
  const args = {}, control = {}; let positional;
  const keys = { '--root': 'root', '--wasm': 'wasm', '--timeout': 'timeout', '--args': 'args', '--options': 'optionsFile', '--view': 'view', '--track': 'track', '--limit': 'limit', '--offset': 'offset', '--entry': 'entry', '--format': 'format', '--output': 'output', '--seconds': 'seconds', '--max-seconds': 'maxSeconds', '--mode': 'mode', '--url': 'url', '--base-url': 'baseUrl', '--topic': 'topic', '--query': 'query', '--start-line': 'startLine', '--text': 'text', '--expected-hash': 'expectedHash', '--basis': 'basis', '--start-tick': 'start_tick', '--end-tick': 'end_tick', '--width': 'width', '--pitch-min': 'pitchMin', '--pitch-max': 'pitchMax', '--from-measure': 'fromMeasure', '--measure-count': 'measureCount', '--finding-offset': 'findingOffset', '--finding-limit': 'findingLimit' };
  const numeric = new Set(['limit', 'offset', 'seconds', 'maxSeconds', 'startLine', 'start_tick', 'end_tick', 'width', 'pitchMin', 'pitchMax', 'fromMeasure', 'measureCount', 'findingOffset', 'findingLimit']);
  let checkFormat = false;
  for (let i = 0; i < argv.length; i++) {
    if (argv[i] === '--check' && action === 'format') { checkFormat = true; continue; }
    if (!argv[i].startsWith('--')) { if (positional) throw Error('Only one project path is accepted.'); positional = argv[i]; continue; }
    const key = keys[argv[i]]; if (!key || argv[i + 1] === undefined) throw Error(`Unknown/incomplete option ${argv[i]}`);
    const value = argv[++i];
    if (['root', 'wasm', 'timeout', 'args', 'optionsFile'].includes(key)) control[key] = value;
    else args[key] = numeric.has(key) ? Number(value) : value;
  }
  if (control.args && (positional || Object.keys(args).length || control.optionsFile)) throw Error('--args replaces all tool arguments.');
  if (positional) args.path = positional;
  if (control.optionsFile) {
    if (!['analyze', 'view_colorful'].includes(action)) throw Error('--options applies to analyze/view colorful.');
    const ws = await createWorkspace(control.root), file = await ws.read(control.optionsFile, 1, 1000);
    if (file.nextLine !== null) throw Error('Options file exceeds 1000 lines.');
    args.options = JSON.parse(file.text);
  }
  if (['analyze', 'view_colorful'].includes(action)) for (const key of ['basis', 'fromMeasure', 'measureCount', 'findingOffset', 'findingLimit']) if (args[key] !== undefined) {
    args.options = { ...args.options, [key]: args[key] }; delete args[key];
  }
  const timeoutMs = control.timeout === undefined ? 30_000 : Number(control.timeout) * 1000;
  if (!Number.isFinite(timeoutMs) || timeoutMs < 1000 || timeoutMs > 600_000) throw Error('--timeout must be 1..600 seconds.');
  const service = await createService({ root: control.root, wasm: control.wasm, timeoutMs });
  const result = await service.call(`muz_${action}`, control.args ? JSON.parse(control.args) : args);
  process.stdout.write(JSON.stringify(result, null, 2) + '\n');
  if (result.intent?.status === 'failed' || result.complete === false || (checkFormat && result.changed)) process.exitCode = 2;
} catch (e) { process.stdout.write(JSON.stringify({ error: e.message, ...(e.diagnostic ? { diagnostic: e.diagnostic } : {}) }, null, 2) + '\n'); process.exitCode = 1; }
"""

let render() = file
