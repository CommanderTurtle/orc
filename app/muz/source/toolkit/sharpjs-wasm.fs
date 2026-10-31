module Muz.Source.Toolkit.WasmJs

let file = """import { readFile } from 'node:fs/promises';

// The browser and agent hosts consume the same compiled engine ABI. No parser,
// synthesis, formatter, or MIDI-export implementation is duplicated here.
export async function loadEngine(path) {
  const { instance } = await WebAssembly.instantiate(await readFile(path), {});
  const w = instance.exports, encoder = new TextEncoder(), decoder = new TextDecoder();
  return {
    call(request) {
      const bytes = encoder.encode(JSON.stringify(request));
      const ptr = w.muz_alloc(bytes.length);
      if (!ptr) throw Error('Engine request exceeds its memory boundary.');
      let length;
      try {
        new Uint8Array(w.memory.buffer, ptr, bytes.length).set(bytes);
        length = w.muz_call(ptr, bytes.length);
      } finally { w.muz_free(ptr, bytes.length); }
      const result = JSON.parse(decoder.decode(new Uint8Array(w.memory.buffer, w.muz_response(), length)));
      if (!result.ok) {
        const error = Error(result.error); error.diagnostic = result.diagnostic; throw error;
      }
      return result.value;
    },
    blob(length) { return new Uint8Array(w.memory.buffer, w.muz_blob(), length).slice(); },
    pcm(frames) { return new Float32Array(w.memory.buffer, w.muz_pcm(), frames * 2).slice(); },
  };
}
"""

let render() = file
