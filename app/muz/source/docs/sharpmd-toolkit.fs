module Muz.Source.Docs.ToolkitMd

let file = """# Agent composition toolkit

The toolkit is a consumer of the **same portable Rust/WASM engine** as the static site. No extra DAW runtime, Python music parser, language fork, MCP SDK dependency, account, or background HTTP server is needed. It runs with Bun after `bun run build`. Source files remain native `.muz`.

## CLI

From the muzstatic repository (replace `PROJECT` with your chosen music directory):

```sh
bun run muz reference --root PROJECT --topic template
bun run muz check song.muz --root PROJECT
bun run muz inspect song.muz --root PROJECT --view notes --track lead --limit 12
bun run muz inspect song.muz --root PROJECT --view explain --track lead --limit 4
bun run muz evaluate math.muz --root PROJECT
bun run muz analyze song.muz --root PROJECT --options intent.json
bun run muz format song.muz --root PROJECT --check
bun run muz render song.muz --root PROJECT --format wav --output out/preview.wav --seconds 8
bun run muz render song.muz --root PROJECT --format midi --output out/song.mid
bun run muz share song.muz --root PROJECT --output out/link.txt
```

`--root` is required. A `.muz` path loads exactly that one file. For relative imports and samples, pass a **project directory** and optionally `--entry relative/song.muz`; or use a `.muzproject.json` bundle. Directory loading includes `.muz`, `.md`, `.wav`, `.flac`, `.mid`, `.midi`, `.sfz`, `.json`, omits hidden/build/dependency folders and rejects symlink entries. Standard-library modules are embedded. Filesystem paths/imports stay inside the selected root/project snapshot. 

`--args '{...}'` supplies the exact tool arguments instead of the convenience flags. Useful for inline project snapshots and analysis pagination:

```sh
bun run muz analyze --root PROJECT --args '{"path":"song.muz","options":{"fromMeasure":33,"measureCount":16,"findingLimit":20}}'
```

Shell quoting differs by platform; MCP calls avoid that entirely. All CLI output is JSON. The CLI never auto-formats/writes source. `format --check` exits 2 if formatting differs. Analysis exit meanings and musical limits are in [analysis.md](analysis.md). A render never plays speakers. WAV defaults to a 60-second maximum; a longer full master needs e.g. `--max-seconds 360 --timeout 180`. WAV output is bounded to 256 MiB. MIDI exports the whole piece. Export filenames must not already exist.

An editable, self-contained four-measure starter is in `examples/starter/`: native tonal/voice-leading helpers, a plain plan, exact `.muz` math/assertions and an optional JSON intent. Try `bun run muz analyze song.muz --root examples/starter --options intent.json`. It can also be imported directly into muzstatic as `.muz`.

`analyze` and `view colorful` also accept `--basis performance`, `--from-measure 33`, `--measure-count 16`, `--finding-offset 100`, and `--finding-limit 20`; these override the corresponding options-file fields.

## MCP

Launch over stdio, using absolute executable/script/root paths in your MCP client's configuration:

```json
{
  "mcpServers": {
    "muz-studio": {
      "command": "bun",
      "args": ["/absolute/path/muzstatic/toolkit/server.js", "--root", "/absolute/path/my-music"]
    }
  }
}
```

This is the common JSON shape; use your client's equivalent configuration. `bun run mcp --root PROJECT` also launches it from this repository. `--wasm FILE` selects an explicit built bridge, and `--timeout SECONDS` sets a 1–600s worker deadline (default 30s).

Tools:

| Tool | Purpose |
| --- | --- |
| `muz_read`, `muz_write` | Read/create/edit native source, plans or JSON intent; existing writes require the read SHA-256 |
| `muz_check` | Actual engine compiler, asset/graph/policy validation and portable preparation |
| `muz_inspect` | Native paged summary, sections, score, performance, graph/patches, automation, diagnostics, locations, plus normalized notes and source explanations |
| `muz_evaluate` | Native `.muz` rational math, assertions, musical helper calls and script results |
| `muz_analyze` | Key/chord hypotheses, interval evidence, timing/form/voice metrics, explicit intent checks |
| `muz_format` | Real upstream formatter; returns text without overwriting |
| `muz_render` | Actual-engine WAV or MIDI file export, no playback |
| `muz_share` | Existing lnkr v4 embedded/source/superlink URL generation; no upload |
| `muz_reference` | Bundled skill, analysis definitions, upstream manuals, native template and standard modules |
| `muz_view_colorful` | [PNG mathematical score portrait](colorful.md), returned directly as an MCP image and saved locally |

`compose` and `review` MCP prompts are available. The composition skill and analysis guide are also readable MCP resources. Protocol versions 2024-11-05, 2025-03-26, 2025-06-18 and 2025-11-25 are supported. Messages are newline-delimited JSON-RPC; stdout is protocol-only. The adapter follows the [MCP stdio transport](https://modelcontextprotocol.io/specification/2025-11-25/basic/transports), [lifecycle](https://modelcontextprotocol.io/specification/2025-11-25/basic/lifecycle), and [cancellation](https://modelcontextprotocol.io/specification/2025-11-25/basic/utilities/cancellation) contracts. No HTTP listener or transport credentials are involved.

Engine work is isolated in terminable workers. Cancellation kills that job; closing stdin cancels outstanding work. Four concurrent tool requests, 8 MiB input messages, 1 MiB result payloads. Use project paths for large assets; use inspection/analysis pagination for large outputs. The 96 MiB bridge request and existing project/engine expansion budgets remain enforced. Worker isolation is a timeout/lifecycle boundary.

Writes are confined to `--root`. New files are exclusive-create; existing source writes require a content hash and return a new hash.

## Skill

The portable skill lives at `skills/muz-compose/SKILL.md`, with optional UI metadata beside it. Install that folder into your agent's skills directory and connect the MCP, or use the same CLI. Keep this repository path available for CLI fallback. The workflow supports planning → native code → compile → inspect → musical evidence → targeted refinement → optional render/share, without requiring every project to follow an identical compositional recipe.

## Reproducibility and provenance

Every check/study/export reports the snapshot SHA-256 and selected upstream engine revision. Inspection reparses the current snapshot rather than serving a stale prior compile. Upstream source remains untouched. The source bundle includes this toolkit, its skill/tests/docs and selected engine manuals.
"""

let render() = file
