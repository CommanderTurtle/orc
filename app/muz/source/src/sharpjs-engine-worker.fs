module Muz.Source.Src.EngineWorkerJs

let file = """let wasm, loading, compiled, frame = 0, tail = 0, stoppedAtEnd = false;
const encoder = new TextEncoder(), decoder = new TextDecoder();
async function load() {
  if (!loading) loading = (async () => {
    const response = await fetch(new URL('./muz.wasm', import.meta.url));
    if (!response.ok) throw Error('Cannot load the bundled muz engine.');
    const { instance } = await WebAssembly.instantiate(await response.arrayBuffer(), {});
    wasm = instance.exports;
  })();
  await loading;
}
function call(value) {
  const bytes = encoder.encode(JSON.stringify(value)), ptr = wasm.muz_alloc(bytes.length);
  if (!ptr) throw Error('Host request is too large.');
  let length;
  try { new Uint8Array(wasm.memory.buffer, ptr, bytes.length).set(bytes); length = wasm.muz_call(ptr, bytes.length); }
  finally { wasm.muz_free(ptr, bytes.length); }
  const result = JSON.parse(decoder.decode(new Uint8Array(wasm.memory.buffer, wasm.muz_response(), length)));
  if (!result.ok) throw Object.assign(Error(result.error), { diagnostic: result.diagnostic });
  return result.value;
}
const totalFrames = () => compiled.frames + Math.round(tail * compiled.rate);
function reset(offline = false) { call({ command: 'reset', offline }); frame = 0; stoppedAtEnd = false; }
function render(count) {
  const output = new Float32Array(count * 2);
  let offset = 0, peak = 0;
  while (offset < count) {
    if (!stoppedAtEnd && frame >= compiled.frames) { call({ command: 'release' }); stoppedAtEnd = true; }
    const n = Math.min(1024, count - offset, stoppedAtEnd ? count : compiled.frames - frame);
    const status = call({ command: 'render', frames: n });
    output.set(new Float32Array(wasm.memory.buffer, wasm.muz_pcm(), n * 2), offset * 2);
    peak = Math.max(peak, status.peak); frame += n; offset += n;
  }
  return { pcm: output, peak, frame };
}
const yieldTask = () => new Promise(resolve => setTimeout(resolve, 0));
async function wav(input, progress) {
  if (input.project) compiled = call({ command: 'compile', ...input, offline: true });
  if (!compiled) throw Error('Compile first.');
  tail = Math.min(600, Math.max(0, compiled.tail || 0));
  call({ command: 'tap', track: input.track || null }); reset(true);
  const frames = totalFrames(), bytes = frames * 6;
  if (bytes > 512 * 1024 * 1024) throw Error('WAV export exceeds the 512 MiB browser-memory limit.');
  const buffer = new ArrayBuffer(44 + bytes), view = new DataView(buffer);
  const text = (s, at) => [...s].forEach((c, i) => view.setUint8(at + i, c.charCodeAt(0)));
  text('RIFF', 0); view.setUint32(4, 36 + bytes, true); text('WAVEfmt ', 8); view.setUint32(16, 16, true);
  view.setUint16(20, 1, true); view.setUint16(22, 2, true); view.setUint32(24, compiled.rate, true);
  view.setUint32(28, compiled.rate * 6, true); view.setUint16(32, 6, true); view.setUint16(34, 24, true);
  text('data', 36); view.setUint32(40, bytes, true);
  let done = 0;
  while (frame < frames) {
    const { pcm } = render(Math.min(8192, frames - frame));
    for (const sample of pcm) {
      const n = Number.isFinite(sample) ? Math.round(Math.max(-1, Math.min(1, sample)) * (sample < 0 ? 8388608 : 8388607)) : 0;
      const at = 44 + done++ * 3; view.setUint8(at, n & 255); view.setUint8(at + 1, (n >> 8) & 255); view.setUint8(at + 2, (n >> 16) & 255);
    }
    progress(frame / frames); await yieldTask();
  }
  return buffer;
}
async function operate({ id, operation, input = {} }) {
  try {
    await load(); let result, transfer = [];
    const progress = value => self.postMessage({ id, progress: value });
    if (operation === 'compile' || operation === 'prepare-export') {
      compiled = call({ command: 'compile', ...input, offline: operation === 'prepare-export' });
      tail = Math.min(600, Math.max(0, compiled.tail || 0)); frame = 0; stoppedAtEnd = false;
      call({ command: 'start' }); result = compiled;
    } else if (operation === 'revise') {
      // Rejection never assigns compiled or disturbs the accepted frame/DSP.
      const candidate = call({ command: 'revise', ...input });
      compiled = candidate; tail = Math.min(600, Math.max(0, compiled.tail || 0));
      frame = Math.round(compiled.positionFrame);
      if (stoppedAtEnd && frame < compiled.frames) { call({ command: 'start' }); stoppedAtEnd = false; }
      result = compiled;
    } else if (operation === 'pull') {
      const remaining = Math.max(0, totalFrames() - frame);
      result = render(Math.min(input.frames || 16384, remaining));
      result.done = frame >= totalFrames(); transfer = [result.pcm.buffer];
    } else if (operation === 'seek') {
      if (!compiled || !Number.isFinite(input.frame)) throw Error('A compiled timeline and valid position are required.');
      const target = Math.round(Math.max(0, Math.min(totalFrames(), input.frame)));
      reset();
      // Restore sampled voices, pedal history, filters and tails by exact replay.
      // Work is chunked here, never executed on the audio worklet thread.
      while (frame < target) { render(Math.min(16384, target - frame)); progress(frame / Math.max(1, target)); await yieldTask(); }
      result = { frame, done: frame >= totalFrames() };
    } else if (operation === 'reset') { reset(); result = {}; }
    else if (operation === 'solo') result = call({ command: 'solo', tracks: input });
    else if (operation === 'audition') result = call({ command: 'audition', tracks: input });
    else if (operation === 'inspect') result = call({ command: 'inspect', ...input });
    else if (operation === 'format') result = call({ command: 'format', source: input.source });
    else if (operation === 'lint') result = call({ command: 'lint', source: input.source, path: input.path });
    else if (operation === 'midi') {
      const value = call({ command: 'midi' });
      result = new Uint8Array(wasm.memory.buffer, wasm.muz_blob(), value.length).slice(); transfer = [result.buffer];
    } else if (operation === 'wav') { result = await wav(input, progress); transfer = [result]; }
    else throw Error('Unknown engine operation.');
    self.postMessage({ id, result }, transfer);
  } catch (e) { self.postMessage({ id, error: e.message, diagnostic: e.diagnostic }); }
}
// Awaiting asset loads/seeks/exports must not interleave stateful WASM calls.
let serial = Promise.resolve();
self.onmessage = ({ data }) => { serial = serial.then(() => operate(data)); };
"""

let render() = file
