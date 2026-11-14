module TTS.READMEMd

let file = """# speakingwasm

Local speech and structured translation requests in a static page.

```sh
bun install
bun run build
bun start
```

Deploy `dist/` at any path on HTTPS. Models load only after an action, from pinned Hugging Face revisions, and remain in the browser's download cache. Close or cancel releases the inference worker. **Clear downloads** removes the persistent model cache.

For an entirely self-hosted deployment, run `bun run models` before building. Pass model names to fetch a subset: `bun run models whistle paradee`. Serve the complete dist with ordinary static hosting; microphone capture requires HTTPS or localhost.

## Modes

- **Speak:** Paradee 1.3 INT8 (8.5 MB, embedded voices) or full Kokoro 82M FP32 (326 MB plus the selected 522 KB voice). English, Spanish, French, Hindi, Italian and Portuguese text phonemization; all Kokoro voices are available with model-native phoneme input, including Japanese and Chinese. The pinned eSpeak/Misaki fallback runs locally. WAV playback, seeking and download.
- **Listen:** Whistle (17 MB, seven languages, incremental transcription), or Bark 3.0 Base / Plus / Clean (685 MB INT8 each, English, phrase updates). Microphone waveform, streaming text, Copy, Save and transfer to the translation pane. WAV, MP3, M4A and FLAC decode incrementally through browser codecs, with a lazy FFmpeg WASM fallback for unsupported codecs. No file-size cutoff. Quiet-boundary segmentation bounds inference memory independently of recording length.
- **Translate request:** Needle 3 extracts a `translate` tool call from an editable pre-prompt and a text/Markdown document. Source and target language controls, detection/all-language options, copy and JSON export. This pane prepares a request; Needle does not generate translated prose or execute a remote translator.

## Embed

Import `speech/speech.js` from the built tree. `SpeechEngine.load(name, options)` starts one worker; `call('speak', {text})` returns PCM, `call('transcribe', {pcm, stream})` accepts mono 16 kHz PCM, and `close()` releases it. `speech/microphone.js` supplies capture and waveform helpers. Copy the complete `speech/` directory, preserving its relative paths. One engine owner per operation keeps inactive models out of memory.

`models.json` pins source revisions; `assets.lock.json` pins every downloadable asset and its SHA-256. `bun run models` verifies checksums when materializing local assets. The browser validates sizes and uses immutable revision URLs as cache keys. Source attribution are listed in `credits/`.

AGPL-3.0 standalone page project. Visit the github page under [tts.shel.sh](https://tts.shel.sh/) - Source revision under fsharp multi-project orchestrator: [/tree/main/tts](https://github.com/CommanderTurtle/orc/tree/main/tts)
"""

let render() = file
