module Muz.Source.Toolkit.WorkerJs

let file = """import { parentPort, workerData } from 'node:worker_threads';
import { loadEngine } from './wasm.js';
import { analyze } from './analysis.js';
import { colorfulPNG } from './colorful.js';

async function execute(job, wasm) {
  const engine = await loadEngine(wasm), call = value => engine.call(value);
  if (job.action === 'evaluate') return call({ command: 'evaluate', project: job.project });
  if (job.action === 'format') return call({ command: 'format', source: job.source });
  const info = call({ command: 'check', project: job.project, provenance: job.view === 'explain', offline: true });
  if (job.action === 'check') return info;
  if (job.action === 'inspect') {
    if (job.view === 'notes') return call({ command: 'notes', ...job.page, basis: job.basis });
    if (job.view === 'explain') return call({ command: 'explain', ...job.page });
    return call({ command: 'inspect', view: job.view, page: job.page });
  }
  if (job.action === 'analyze' || job.action === 'colorful') {
    const notes = [], basis = job.options?.basis || 'score';
    let offset = 0;
    for (;;) {
      const page = call({ command: 'notes', basis, offset, limit: 1000 });
      // Never call a prefix a clean analysis. Request a smaller project instead.
      if (page.total > 100_000) throw Error('Analysis exceeds 100,000 notes; use a smaller project or inspect pages.');
      notes.push(...page.rows);
      if (page.next === null) break;
      if (page.next <= offset) throw Error('Engine note pagination did not advance.');
      offset = page.next;
    }
    const options = job.action === 'colorful' ? { measureCount: 256, ...job.options } : job.options;
    const study = analyze(info, notes, options);
    return job.action === 'colorful' ? colorfulPNG(info, notes, study, job.drawing, job.provenance) : study;
  }
  if (job.action === 'render') {
    if (job.format === 'midi') { const result = call({ command: 'midi' }); return { bytes: engine.blob(result.length), info, format: 'midi' }; }
    const rate = info.rate, total = info.frames + Math.ceil((info.tail || 0) * rate);
    const frames = job.seconds === undefined ? total : Math.min(total, Math.ceil(job.seconds * rate));
    if (frames > job.maxSeconds * rate) throw Error(`Render needs ${(frames / rate).toFixed(1)}s. Increase maxSeconds explicitly or request a shorter seconds preview.`);
    if (frames * 6 + 44 > 256 * 1024 * 1024) throw Error('WAV exceeds 256 MiB.');
    const bytes = new Uint8Array(44 + frames * 6), view = new DataView(bytes.buffer);
    const text = (at, s) => { for (let i = 0; i < s.length; i++) bytes[at + i] = s.charCodeAt(i); };
    text(0, 'RIFF'); view.setUint32(4, bytes.length - 8, true); text(8, 'WAVEfmt ');
    view.setUint32(16, 16, true); view.setUint16(20, 1, true); view.setUint16(22, 2, true);
    view.setUint32(24, rate, true); view.setUint32(28, rate * 6, true); view.setUint16(32, 6, true); view.setUint16(34, 24, true);
    text(36, 'data'); view.setUint32(40, frames * 6, true);
    call({ command: 'start' });
    let released = false, clippedSamples = 0, nonfiniteSamples = 0, peak = 0;
    for (let at = 0; at < frames;) {
      if (!released && at >= info.frames) { call({ command: 'release' }); released = true; }
      const count = Math.min(1024, frames - at, released ? Infinity : Math.max(1, info.frames - at));
      call({ command: 'render', frames: count });
      const pcm = engine.pcm(count);
      for (let i = 0; i < pcm.length; i++) {
        let sample = pcm[i];
        if (!Number.isFinite(sample)) { sample = 0; nonfiniteSamples++; }
        peak = Math.max(peak, Math.abs(sample)); if (Math.abs(sample) > 1) clippedSamples++;
        const value = Math.round(Math.max(-1, Math.min(1, sample)) * (sample < 0 ? 8388608 : 8388607)), p = 44 + at * 6 + i * 3;
        bytes[p] = value & 255; bytes[p + 1] = (value >> 8) & 255; bytes[p + 2] = (value >> 16) & 255;
      }
      at += count;
    }
    return { bytes, format: 'wav', frames, seconds: frames / rate, preview: frames < total, peak, clippedSamples, nonfiniteSamples };
  }
  throw Error('Unknown engine job.');
}
try { parentPort.postMessage({ ok: true, value: await execute(workerData.job, workerData.wasm) }); }
catch (e) { parentPort.postMessage({ ok: false, error: e.message, diagnostic: e.diagnostic }); }
"""

let render() = file
