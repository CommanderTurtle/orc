module Muz.Source.Toolkit.RunnerJs

let file = """import { Worker } from 'node:worker_threads';
import { fileURLToPath } from 'node:url';

export function runJob(job, { wasm, signal, timeoutMs = 30_000 } = {}) {
  return new Promise((resolve, reject) => {
    if (signal?.aborted) return reject(Error('Cancelled.'));
    const worker = new Worker(new URL('./worker.js', import.meta.url), { workerData: { job, wasm: wasm instanceof URL ? fileURLToPath(wasm) : wasm } });
    let settled = false;
    const finish = (error, result) => {
      if (settled) return;
      settled = true; clearTimeout(timer); signal?.removeEventListener('abort', abort);
      worker.terminate(); error ? reject(error) : resolve(result);
    };
    const abort = () => finish(Error('Cancelled.'));
    const timer = setTimeout(() => finish(Error(`Engine job exceeded ${timeoutMs / 1000}s; narrow the request or raise --timeout.`)), timeoutMs);
    signal?.addEventListener('abort', abort, { once: true });
    if (signal?.aborted) abort();
    worker.on('message', message => {
      if (message.ok) finish(null, message.value);
      else { const error = Error(message.error); error.diagnostic = message.diagnostic; finish(error); }
    });
    worker.on('error', error => finish(error));
    worker.on('exit', code => { if (!settled) finish(Error(`Engine worker exited before replying (${code}).`)); });
  });
}
"""

let render() = file
