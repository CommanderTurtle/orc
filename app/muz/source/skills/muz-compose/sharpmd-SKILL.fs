module Muz.Source.Skills.MuzCompose.SKILLMd

let file = """---
name: muz-compose
description: Compose, revise, or review native .muz music using the muz studio compiler, score inspection, musical analysis, and render tools. Use for code-based composition and arrangement, not generic audio-file editing.
---

# Native .muz composition

The deliverable is ordinary editable `.muz`, not a replacement score format or a description of imagined music. The `muz_*` tools use the same pinned Rust engine as muzstatic. Read `muz_reference(topic="template")` and relevant upstream `language` / `workflow` sections before using unfamiliar syntax. Standard-library modules are available as `std/tonal`, `std/arrange`, `std/piano`, etc.; `muz_reference` returns their actual source, not guessed APIs.

## Compose with intent

Establish enough musical intent to guide choices: form/length, meter and tempo, tonal palette (or intentionally atonal), instrumentation/roles, rhythmic vocabulary, development, contrast, and delivery. Keep a short editable plan if the piece warrants one; it is not a mandatory schema. Reuse motifs and transforms to create development rather than expanding repeated note lists. Preserve existing music outside the requested revision.

Use native facilities where useful: exact musical durations, `phrase`, patterns and transforms, scales/diatonic chords, `std/tonal` voice-leading and reharmonization, `std/arrange` passages/occurrences/span contracts, and source `assert(...)`. Query the real reference for signatures. Named voices/tags can make edits and explanations much more precise. An optional piano performance policy is a declared playing constraint, not a universal requirement.

`muz_evaluate` runs real `.muz` math/scripts without a song wrapper. Use it to verify durations, transformations and assertions; avoid maintaining a second imagined evaluator. `.muz` `b` means quarter-note beats. Its `bars` literal is always four quarter-note beats, **not** the current meter's measure. For example, a 7/8 measure is `3.5b`; three triplet thirds add exactly to `1b`.

## Check, inspect, refine

Use `muz_check` after a meaningful revision. A successful compile/preparation is different from a good musical result. Compiler/asset/graph failures are hard failures; fix their actual cause and preserve structured source locations. All results identify the source revision: don't compare an old analysis against edited files as if it described the current source.

Inspect `sections`, `summary`, and the affected `score` / `notes` pages. Authored score includes rational beat positions and pre-performance intent. `basis="performance"` follows gating, humanization and kit expansion. Imported MIDI may have no authored score; use performance basis then. Performance analysis uses MIDI key numbers, not continuous pitch bends. Do not mix score PPQ, imported MIDI PPQ, and legacy loop PPQ. Prefer normalized `notes` fractions; native tick views disclose their resolutions in `muz_check`.

Use `muz_inspect(view="explain", track=...)` for source provenance, rather than rewriting whole passages to fix an identified note. Note indices/positional key paths are revision-local; source locations use Unicode columns, not JavaScript UTF-16 columns.

`muz_analyze` defaults to a 32-measure authored-score window. Follow `window.nextMeasure` and `findings.next` when the review needs more. Set explicit intent constraints only when they express the user's actual intent (length, pitch range, maximum polyphony/leap, optional strict key). Exclude unpitched/percussion tracks by ID when studying harmony; no track is excluded by an unreliable name heuristic.

Interpret key/chord candidates as hypotheses. Tritones, chromatic pitches, irregular phrases, off-beat entries, dense chords and silence can be deliberate. Informational interval findings are exact-overlap evidence, not errors or a genre-independent quality score. Don't "repair" intentional color to minimize warnings. `complete=false`, omitted chord segments, and paged findings cannot establish a clean whole-piece review. Maximum melodic leap is undefined for an unseparated polyphonic stream; name voices or inspect the actual voicing.

Refine the smallest relevant passage; check and re-inspect it. Explain concrete musical changes and unresolved tradeoffs, not just a lint count. `muz_format` returns formatting without silently editing. Existing-file `muz_write` calls require the hash from `muz_read`; a stale-hash failure means read current source before replacing it.

## Audition and delivery

Render a short WAV when it helps evaluate a passage. `muz_render` writes a file and never plays speakers. A visual/theory report cannot prove a mix sounds good. Full WAV exports over 60 seconds need an explicit larger render budget; native plugins and DAWProject export belong to the upstream desktop host. Don't invent portable support for them.

Deliver native `.muz`, plus project-relative modules/assets when needed. One self-contained `.muz` can live at a CORS-readable raw URL. Multi-file projects need a project JSON bundle; remote raw imports do not crawl adjacent directories. `muz_share` creates existing lnkr v4 embedded/source/superlink encoding locally. It does not upload, publish, or grant CORS. Large URLs should go to a requested text output instead of flooding model context.

For visual inspection, use `muz_view_colorful` if present. Read its legend: it maps measurable pitch-class, rhythm, register and dynamics features, not a composer's subjective hearing. Render and source remain the musical ground truth.

If MCP isn't connected, the repository's `bun run muz` CLI exposes the same checks and analysis. `docs/toolkit.md` documents launch/configuration; `muz_reference(topic="analysis")` explains the mathematical definitions and limits. Keep the skill and toolkit versions together.
"""

let render() = file
