module Muz.Source.Toolkit.ServerJs

let file = """import { createService, tools } from './service.js';

const argv = process.argv.slice(2);
const option = (name, fallback) => { const at = argv.indexOf(name); return at < 0 ? fallback : argv[at + 1]; };
const known = new Set(['--root', '--wasm', '--timeout']);
for (let i = 0; i < argv.length; i += 2) if (!known.has(argv[i]) || !argv[i + 1]) { process.stderr.write('Usage: bun toolkit/server.js --root PROJECT_DIR [--wasm FILE] [--timeout SECONDS]\n'); process.exit(1); }
const timeout = Number(option('--timeout', 30));
if (!Number.isFinite(timeout) || timeout < 1 || timeout > 600) throw Error('--timeout must be 1..600 seconds.');
const service = await createService({ root: option('--root'), wasm: option('--wasm'), timeoutMs: timeout * 1000 });
const versions = ['2025-11-25', '2025-06-18', '2025-03-26', '2024-11-05'];
let state = 'new', protocol, buffer = '', closing = false;
const active = new Map(), tasks = new Set(), MAX_LINE = 8 * 1024 * 1024;
function send(message) { if (!closing) process.stdout.write(JSON.stringify(message) + '\n'); }
const error = (id, code, message, data) => send({ jsonrpc: '2.0', id, error: { code, message, ...(data === undefined ? {} : { data }) } });
async function dispatch(message) {
  const id = message?.id;
  if (!message || typeof message !== 'object' || Array.isArray(message) || message.jsonrpc !== '2.0' || typeof message.method !== 'string' || (id !== undefined && typeof id !== 'string' && !Number.isSafeInteger(id))) return error(null, -32600, 'Invalid JSON-RPC request.');
  const { method, params = {} } = message;
  if (id === undefined) {
    if (method === 'notifications/initialized' && state === 'awaiting') state = 'ready';
    if (method === 'notifications/cancelled' && params.requestId !== undefined) active.get(params.requestId)?.abort();
    return;
  }
  if (active.has(id)) return error(id, -32600, 'Request ID is already in flight.');
  const controller = new AbortController(); active.set(id, controller);
  try {
    let result;
    if (method === 'initialize') {
      if (state !== 'new') return error(id, -32600, 'Already initialized.');
      if (typeof params.protocolVersion !== 'string' || !params.clientInfo || !params.capabilities) return error(id, -32602, 'initialize requires protocolVersion, clientInfo and capabilities.');
      protocol = versions.includes(params.protocolVersion) ? params.protocolVersion : versions[0]; state = 'awaiting';
      result = { protocolVersion: protocol, capabilities: { tools: {}, resources: {}, prompts: {} }, serverInfo: { name: 'muz-studio', version: '0.2.0', title: 'muz composition studio' }, instructions: `Native .muz is the source of truth. Workspace: ${service.root}. Start with muz_reference compose and template; use compiler evidence before musical inference. Tools never play speakers or publish. Analysis is not an objective quality score.` };
    } else if (method === 'ping') result = {};
    else if (state !== 'ready') return error(id, -32002, 'Initialize and send notifications/initialized first.');
    else if (method === 'tools/list') result = { tools };
    else if (method === 'tools/call') {
      if (typeof params.name !== 'string' || !tools.some(t => t.name === params.name)) return error(id, -32602, 'Unknown tool.');
      if (active.size > 4) return error(id, -32000, 'At most four tool jobs may run concurrently.');
      try {
        const { _image, ...value } = await service.call(params.name, params.arguments ?? {}, { signal: controller.signal, images: true });
        const text = JSON.stringify(value);
        if (Buffer.byteLength(text) > 1024 * 1024) throw Error('Tool response exceeds 1 MiB. Request fewer rows/lines/measures or save an export.');
        result = { content: [{ type: 'text', text }, ...(_image ? [_image] : [])], ...(protocol === '2024-11-05' ? {} : { structuredContent: value }), isError: false };
      } catch (e) {
        const value = { error: e.message, ...(e.diagnostic ? { diagnostic: e.diagnostic } : {}) };
        result = { content: [{ type: 'text', text: JSON.stringify(value) }], ...(protocol === '2024-11-05' ? {} : { structuredContent: value }), isError: true };
      }
    } else if (method === 'resources/list') result = { resources: ['compose', 'analysis'].map(topic => ({ uri: `muz://guidance/${topic}`, name: topic, mimeType: 'text/markdown', description: 'Bundled composition guidance; upstream manuals are paged via muz_reference.' })) };
    else if (method === 'resources/read') {
      const topic = { 'muz://guidance/compose': 'compose', 'muz://guidance/analysis': 'analysis' }[params.uri];
      if (!topic) return error(id, -32002, 'Unknown resource.');
      result = { contents: [{ uri: params.uri, mimeType: 'text/markdown', text: (await service.reference({ topic, limit: 300 })).text }] };
    } else if (method === 'prompts/list') result = { prompts: [
      { name: 'compose', description: 'Plan, code, compile, inspect and refine native .muz.', arguments: [{ name: 'brief', description: 'Musical intent and delivery requirements.', required: true }] },
      { name: 'review', description: 'Review a .muz project using compiler and musical evidence.', arguments: [{ name: 'path', description: 'Workspace-relative project path.', required: true }] },
    ] };
    else if (method === 'prompts/get') {
      if (!['compose', 'review'].includes(params.name)) return error(id, -32602, 'Unknown prompt.');
      const key = params.name === 'compose' ? 'brief' : 'path', value = params.arguments?.[key];
      if (typeof value !== 'string' || !value || value.length > 16_384) return error(id, -32602, `Supply ${key} as text (max 16384 characters).`);
      result = { description: 'Native .muz composition workflow', messages: [{ role: 'user', content: { type: 'text', text: `${(await service.reference({ topic: 'compose', limit: 300 })).text}\n\n${params.name === 'compose' ? 'Composition brief' : 'Project to review'}:\n${value}` } }] };
    } else return error(id, -32601, 'Method not found.');
    if (!controller.signal.aborted) send({ jsonrpc: '2.0', id, result });
  } catch (e) { if (!controller.signal.aborted) error(id, -32603, e.message); }
  finally { active.delete(id); }
}
process.stdin.setEncoding('utf8');
process.stdin.on('data', chunk => {
  buffer += chunk;
  for (;;) {
    const end = buffer.indexOf('\n'); if (end < 0) break;
    const line = buffer.slice(0, end); buffer = buffer.slice(end + 1);
    if (Buffer.byteLength(line) > MAX_LINE) { error(null, -32700, 'MCP message exceeds 8 MiB. Use a project path.'); continue; }
    let message; try { message = JSON.parse(line); } catch { error(null, -32700, 'Invalid JSON.'); continue; }
    const task = dispatch(message); tasks.add(task); task.finally(() => tasks.delete(task));
  }
  if (Buffer.byteLength(buffer) > MAX_LINE) { process.stderr.write('Unterminated MCP message exceeds 8 MiB.\n'); close(); }
});
function close() { closing = true; for (const c of active.values()) c.abort(); process.stdin.destroy(); }
process.stdin.on('end', close); process.on('SIGINT', close); process.on('SIGTERM', close);
process.stdout.on('error', close);
"""

let render() = file
