module Muz.Source.READMEMd

let file = """# muzstatic

> Transfer music by the link!

This is a personal fork of [muz](https://github.com/apage43/muz) in a static page, with [linkoder](https://github.com/CommanderTurtle/linkoder) technology.

Muzstatic is a static browser workspace. This is a new frontend consuming the real Rust engine, not a copy of muzpad's minified deployment. The engine checkout is never patched.

It also includes a [native `.muz` composition toolkit](docs/toolkit.md): CLI/MCP compiler checks, exact score/performance inspection, math evaluation, musical analysis, file renders, and a composition skill. The browser site remains standalone; enabling the MCP is optional and independent.

The optional [`view colorful`](docs/colorful.md) PNG exporter adds a circle-of-fifths gradient, complex tonal path, register map, rhythm and interval/entropy traces directly from compiled notes. This allows for viewing a colorized, shaped gradient of "how well" music *is* programmatically. Similar to the bouba/kiki effect, metal/boss-battle music will look much different than C418.

## Build and run

Install [Bun](https://bun.sh), [Rust](https://rustup.rs), Git, and the WebAssembly target once:

```sh
rustup target add wasm32-unknown-unknown
```

From this directory:

```sh
bun run dev
```

That one command fetches the pinned public engine, builds its portable WebAssembly host, writes `dist/`, and serves it at **http://127.0.0.1:8196/**. First build needs network access for Git/Cargo. There is no npm install step.

To use your own existing muz checkout instead:

```sh
bun run dev --engine-dir /path/to/muz
```

The path is remembered in ignored `.local.json`; subsequent `bun run dev` or `bun run build` refreshes from that checkout, including local source changes. It does not modify or pull the selected checkout. Update that checkout yourself to choose a newer engine. To return to the pinned public source, use `bun run dev --upstream`.

```sh
bun run build   # build dist only; no server
bun start       # serve an already-built dist; no rebuild
bun run test    # focused source/link/WASM host tests, after building
```

Change the pinned engine commit in `upstream.json` deliberately to update the default build. The selected commit and local-dirty status are visible in the page and `dist/assets/engine.json`. Cargo dependencies are locked in `engine/Cargo.lock`.

## Host or wrap

Upload **the contents of `dist/`**, preserving its files. No Node, Bun, Rust, Python, API server, proxy, Cloudflare worker, or CDN is needed at runtime. Paths are relative, so hosting under `/muz/` or wrapping that directory works without a base-path rebuild. Serve over HTTPS or localhost: browser AudioWorklet does not work on insecure remote HTTP origins. Use an HTTP server, not `file://`.

For a Vitality wrapper, finish `bun run build` first, then point the wrapper's input directory at this project's `dist/`. 

The generated `source/` folder includes the frontend and selected engine source for this build; keep it available when distributing the bundle. 

## Use

- **Files** imports `.muz` or a saved `.muzproject.json`. **Folder** imports relative source, documentation, sample, MIDI, and SFZ paths together. Files can also be dropped on the page.
- Choose the `.muz` **entry** for a multi-file project. Relative imports stay inside that project's virtual mount; standard modules are already embedded in muz.
- **Compile** validates and prepares the engine. **Play** compiles edited source before playback. Pause resumes the current render; Stop returns to the beginning. Source editing is not applied silently during playback.
- The score shows performed notes after kit expansion, on the engine's own tempo timeline. **Solo** changes audition only. Its effect follows the short audio buffer, not an instant flush.
- **WAV** exports the full master at 48 kHz, stereo, PCM24, with the authored release tail. **MIDI** calls muz's own SMF exporter. Playback volume and audition Solo do not change exported files. Long WAV jobs can be cancelled without killing the player.
- **Project** saves all source/docs/assets as a portable JSON bundle. A local draft is also saved in IndexedDB. Browser storage is not a backup.
- **Reference** displays the actual bundled upstream standard-library source and links to the language docs.

Shortcuts: **Ctrl+Enter** play/pause; **Ctrl+S** compile; **Tab** inserts two spaces in the source editor.

## Links

**Open link** accepts raw `.muz` or project JSON URLs, full ln.kr URLs, bare fragments, and legacy gist IDs/URLs. Existing `muzpad.json` entry/path mappings are respected for gist imports. `?source=URL`, `?url=URL`, and `?gist=ID` work too.

**Share** provides:

- **Embedded**: exact project JSON encoded with ln.kr's existing **v4 DEFLATE** text codec. No hosting service, gist, or upload is needed. Importing a local project or editing source updates the actual URL fragment after a brief debounce.
- **Source link**: `#s:` pointing to a CORS-readable raw source/project JSON. Existing `#lr:` and other traditional ln.kr routes also resolve.
- **Superlink**: `#ss:` pointing to a one-line document containing another raw link, ln.kr link, or embedded project link. Pointer chains are bounded and cycles rejected.

An embedded fragment works unchanged at this frontend or at Make; this frontend treats the decoded content as project data, never executable HTML/JavaScript. Make's existing `#share:` file envelopes are also accepted. Raw GitHub/Hugging Face page URLs are normalized through the vendored ln.kr resolver.

Copy Embedded snapshots the current files. Source/superlinks intentionally retain a remote pointer until you edit or explicitly choose Embedded. Links are not encrypted: anyone with an embedded URL can read its contents. External sources must permit browser CORS; an HTTPS page cannot fetch ordinary insecure HTTP. There is no CORS bypass or authenticated fetch.

Raw `.muz` imports are single files. For relative modules/assets, import the project folder or share a project JSON; the app does not recursively crawl remote directories.

Minimal project shape:

```json
{
  "format": "muzstatic/1",
  "title": "Example",
  "entry": "song.muz",
  "files": { "song.muz": "…", "lib/part.muz": "…", "notes.md": "…" },
  "assets": { "audio/sample.wav": "BASE64_BYTES" }
}
```

Limits: 500 source files, 4 MiB source text, 500 assets / 64 MiB asset bytes, 512 KiB URL fragments, 12 pointer hops, 30-second source fetches, and 512 MiB WAV output. Big sample projects are better shared as raw project JSON URLs than enormous fragments. Compilation uses upstream's evaluation/graph budgets in a terminable worker.

## Feature Parity

This is not full muzpad feature parity.

Added:

- Source editing
- Project files
- Links
- Streaming audio
- Score inspection
- Standard-library browsing
- Native-engine WAV/MIDI exports.

TODO:

- VST3/CLAP hosting
- DAWProject export
- External sample catalogs
- Plugin downloads
- In-Browser DAW
- Transactional live recompilation. 

WAV/FLAC/MIDI/SFZ assets work only when supplied in the project
"""

let render() = file
