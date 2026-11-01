module Muz.Source.READMEMd

let file = """# muzstatic

> Transfer music by the link!

This is a personal fork of [muz](https://github.com/apage43/muz) in a static page, with [linkoder](https://github.com/CommanderTurtle/linkoder) technology.

Muzstatic is a static browser workspace consuming the real Rust engine. The engine checkout remains unmodified; browser audio, inspection, and source revisions use its portable APIs.

It also includes a [native `.muz` composition toolkit](docs/toolkit.md): CLI/MCP compiler checks, exact score/performance inspection, math evaluation, musical analysis, file renders, and a composition skill. The browser site remains standalone; enabling the MCP is optional and independent.

The optional [`view colorful`](docs/colorful.md) PNG exporter adds a circle-of-fifths gradient, complex tonal path, register map, rhythm and interval/entropy traces directly from compiled notes. This allows for viewing a colorized, shaped gradient of "how well" music *is* programmatically. Similar to the bouba/kiki effect, metal/boss-battle music will look much different than C418.

## Build and run

Install [Bun](https://bun.sh), [Rust](https://rustup.rs), Git, and the WebAssembly target once:

```sh
rustup target add wasm32-unknown-unknown
```

From this directory:

```sh
bun install
bun run dev
```

After the one-time dependency install, `bun run dev` fetches the pinned public engine and workbench, builds their portable WebAssembly hosts, writes `dist/`, and serves it at **http://127.0.0.1:8196/**. First build needs network access for Git/Cargo. Frontend dependencies are build-time only.

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
- **Compile** validates and prepares the engine. Subsequent compiles use upstream's prepared transactions: a rejected edit leaves the accepted engine playing. **Live**, initially off, applies valid edits after a short idle period. **Play** compiles edited source before playback; Pause resumes and Stop returns to the beginning.
- Drag the **playback slider** or any arrangement lane to seek. Arrow keys on the slider move one second; Shift moves ten seconds; Home/End jump to the bounds. Seeking restores DSP history in a worker, including voices, pedals and effect tails. Longer jumps show progress. **Sections** jumps to authored sections. **Loop / In / Out** define a half-open loop range.
- Source has **syntax colors**, native-parser **error underlines**, and an error-location button. Syntax checking leaves source unchanged and runs separately from playback; Compile checks evaluation and graph readiness. **Format** uses muz's own formatter. **Undo/Redo** retain 40 edit snapshots; **Accepted revisions** retains the last 20 accepted source snapshots for the current session. Restore source followed by Compile reapplies an earlier version. Project exports and links contain the current project, rather than session history.
- **Arrangement** shows performed notes after kit expansion on the engine's own tempo timeline. **Mute/Solo** change audition only, through native track masks. Their effect follows the short audio buffer.
- **Piano roll** supports note selection, double-click creation, drag movement, right-edge resizing, pitch/time nudging, velocity/length fields, snapping, quantization and deletion. **Apply notes**, track gain, native preset/sample selection, **+ Track**, **Remove track**, and constant **Tempo** edits generate an ordinary `.muz` wrapper. Original files remain intact. **Studio source** reveals that wrapper; **Detach** makes it directly editable. Note replacements freeze the displayed performance with explicit gates; expressive controllers remain editable in the original source. Expanded kit internals stay source-edited. Variable tempo maps stay source-edited too.
- **Inspect** pages through the upstream graph, automation, sections, groups, patches, patch nodes and diagnostics. Native instruments, effects, buses, sends, performance rules and programmable voice graphs remain available through `.muz` and the bundled **Reference**. Standard-library modules can be downloaded as source.
- **WAV** exports the full master at 48 kHz, stereo, PCM24 with its authored release tail. **MIDI** calls muz's own SMF exporter. **Stems** packages the master, post-insert track taps, MIDI, native project and routing notes in a ZIP. Shared bus/master processing remains in the master; track taps need not sum to it. Volume/Mute/Solo leave exports unchanged. Offline exports use an independent worker and can be cancelled while the player continues.
- **DAWProject** exports a portable `.dawproject` ZIP containing the rendered stereo master, muted editable performed-note lanes, tempo changes, meter, section markers, native MIDI, exact project source/assets, and a fidelity report. Assign DAW instruments and unmute the note lanes when replacing the reference mix. Native sound design, routing and automation are baked into the master; the archive claims no native plugin-state equivalence.
- **Project** saves all source/docs/assets as a portable JSON bundle. A local draft is also saved in IndexedDB. Browser storage is not a backup.
- **Reference** displays the actual bundled upstream standard-library source and links to the language docs.

## Sample library

**Library** browses pinned VSCO-2-CE and Karoryfer manifests from the selected upstream checkout, including their `.muz` mappings and license information. Filter resources, select mappings and the recordings they reference, then **Import selected**. Only selected resources download; pinned size/SHA-256 values are verified before the candidate project is committed. Imported bytes travel with Project exports and embedded links. Folder import also accepts local WAV/FLAC, MIDI and SFZ assets.

A custom CORS-readable catalog uses this shape; resource URLs resolve relative to the catalog:

```json
{
  "title": "My samples",
  "license": "Your license",
  "mount": "audio",
  "files": [
    { "path": "hit.wav", "url": "./hit.wav", "bytes": 1234, "sha256": "64_HEX_CHARACTERS" }
  ]
}
```

`mount`, `bytes`, and `sha256` are optional. A `.muz` or `.md` resource may use `text` instead of `url`. Existing files are protected from overwrites; cancelled or failed downloads leave the project unchanged. The bundled catalog descriptions ship with the site; recordings download only on an explicit import.

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

## Portable workflow

**Workbench ↗** opens the current project in the bundled [upstream muzpad workbench](https://github.com/apage43/muzpad), pinned by `workbench.json`. Its shared source editor, folding/search, Markdown library, revision details, routing/voice/automation views, analysis, themes, connected-folder saves/conflicts/recovery, and custom audio/MIDI exports are the original implementations. **Open link**, **Copy link**, and **Studio ↗** provide raw/gist/ln.kr/superlink import and bidirectional handoff. This remains a static browser application. The upstream browser host accepts MIDI/WAV/FLAC assets within its own limits; projects with other binary types stay in Studio. Oversized embedded projects should use a raw project JSON link.

Workspace handoffs use one-use same-origin IndexedDB records, so local samples do not have to fit in a URL. They expire after 15 minutes and are removed on use; at most eight pending transfers remain. Public **Copy link** still uses portable ln.kr encoding. `workbench-build.json` records the upstream/core pins and actual frontend dependency versions, including patched DOMPurify/Vite versions. The original checkout stays untouched.

Muzpad's native Linux application is a separate Tauri host of the same workbench, with native muz in an owned child process and installed CLAP/VST3 resources. Its `desktop:dev`, `desktop:build`, and packaging commands remain upstream's native workflow. The hosted static page neither launches local executables nor opens an unauthenticated native-engine listener.

The static workspace includes streaming playback and scrubbing, loops, live revisions, a source-backed piano roll and track mixer, parser diagnostics, revision restore, project files, existing gist/raw/ln.kr/superlinks, sample catalogs, native-library downloads, engine inspection, and WAV/MIDI/stems/DAWProject export.

Native VST3/CLAP binaries and their installers belong to desktop muz. The browser uses upstream's native synths, samplers, SFZ and effects; DAW handoff includes rendered audio plus editable notes and native source. No application backend, plugin process, or model inference participates in playback or editing.
"""

let render() = file
