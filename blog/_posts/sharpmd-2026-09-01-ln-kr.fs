module Bl0g.Posts.N20260901LnKrMd

let file = """---
layout: post
title: "ln.kr: The Shortest URL That Is Also A Document"
author: "CommanderTurtle"
date: 2026-09-01 04:00:00 +0000
tags: [project, compression, url, markdown, agpl, local]
---

The repo description says it plainly: "Lossless structural URL & text compression, built on the lean QR URL foundation from [ha.mr](https://github.com/p2r3/ha.mr)." ha.mr — "Static URL compressor and QR code optimizer," MIT-licensed, 967 stars in its first two weeks — proved that a URL fragment can carry an entire document. ln.kr keeps that engine intact, preserves ha.mr's MIT license and Git history, and then asks the harder question: what if the URL didn't just *carry* the document, but *was* one?

That question produced a four-version lossless text grammar, a browser viewer that doubles as a document environment, optional repository rendering, and a two-way bridge into [mk.it](/blog/2026-09-02-mk-it/). Twenty-six commits: one upstream fix on August 20, then six working days between September 1 and September 8 — each one scoped, each one tested.

## What A URL Can Carry

The link-mode routes are the original ha.mr codec, extended rather than replaced:

- `#l:` shows the destination before navigating; `#lr:` replaces the page immediately.
- `#s:` fetches the target through its public URL, detects HTML/Markdown/JavaScript/plain text from response type, suffix, and contents, and turns the short route into an editable document URL — resolving GitHub `/blob/`/`/raw/` and Hugging Face presentation URLs to their raw files entirely in the browser.
- A bare `#s:` on its own line is a **runtime include**: CSS, scripts, and Markdown sections stay modular, includes may nest, repeated targets are fetched once, and `::~START[:SPAN]` slices lines with CMD substring semantics (`::~12:-3` = line 12 through three lines back from EOF, endings preserved byte-for-byte).
- `#i:`, `#media:`, and `#pdf:` expand into fully editable JavaScript viewers; `#ss:` (superlink) lets a tiny one-line pointer file carry an otherwise enormous source link.

Opening an ordinary payload link stays inert until you choose to run it. JavaScript can opt into parent-scope execution in a JSFuck-compatible style. The fragment never reaches the server — which is also how the QR form works: the `HTTPS://A.SHEL.SH/T/…` path 404s on GitHub Pages, the static `404.html` moves the payload into a fragment, and the client decodes.

## The Codec, Version By Version

`FORMAT.md` documents the format to the bit. Every version shares one header — a 16-bit magic, a 3-bit version, a 2-bit display kind (text/Markdown/JavaScript/HTML), an Elias-gamma byte length, a **CRC-32 over the exact UTF-8 bytes**, and a sentinel terminator — and decoding fails closed on a bad magic, invalid record, bad distance, length overflow, invalid UTF-8, trailing bits, or checksum mismatch. "Exact" is load-bearing: the CRC is over the original bytes, so any drift anywhere kills the decode.

- **v1** has four record types: one 7-bit ASCII byte, an Elias-gamma dictionary index, a prior-output copy with distance and length (copies may overlap their source — long runs and periodic text compress for free), and an exact literal run. The encoder indexes recent four-byte sequences and checks a bounded chain of candidates; it never guesses or applies a semantic rewrite. The ordered dictionary in `docs/text-compress.js` is normative — change its order or contents and you owe a new format version.
- **v2** is where it stops being "a better RLE." Each payload carries a *local* document grammar: a lexical table plus a structural-template table (static segments interleaved with variable holes, decoded by alternating `static0, hole0, static1, …`). Similarity is decided by a multiscale candidate map — exact four-byte hashes sampled at offsets from 0 to 2048, a sparse wave-shaped fingerprint that finds a repeated region even when early or interior bytes changed — and similarity is resolved by an exact overwrite operation: `T[j] = v[i][j − s[i]]` for the changed runs, `B[j]` everywhere else. No interpolation, no token normalization; every changed byte is present in the stream. Candidates must be at least 32 bytes, may use at most 128 residual runs, and may never read undecoded future output. Definitions that stop paying for themselves get pruned by a fixed-point pass priced at the *actual serialized bit cost* — a merely predicted local saving cannot force a larger stream. And because every reconstructed generation is eligible as a later reference, v2 supports lossy-looking, lossless chains: `B0 →Δ1→ B1 →Δ2→ B2 …` across generations of a document.
- **v3** adds a bounded document dictionary: entries of 2–512 bytes, at most 7,225 of them, byte-sorted for determinism, encoded with frequency-shaped canonical codes capped at 13 bits. The decoder rebuilds the whole code table from the code lengths and the stable entry order — no frequency table ships in the stream.
- **v4** is the honest escape hatch: for inputs whose local vocabulary is too expensive to describe, the body is plain zlib-wrapped DEFLATE at level 9 under the same header — declared compressed length, sentinel, then the same length/CRC/UTF-8 verification. No format guessing; the user picks v1, v2, v3, or v4 explicitly, and nothing ever plans multiple complete encodings.

On top of all four sits the transport alphabet machinery inherited from ha.mr: ASCII, QR-alphanumeric, and emoji. The emoji alphabet needed one real fix — composed sequences and their parts can visually concatenate into a different entry, so a `.` separator is inserted *only* at genuinely ambiguous boundaries and stripped before the BigInt reconstruction. Untouched ha.mr fixtures (ASCII, QR, and emoji) still decode identically; the test suite pins that.

## The Viewer Is The Second Product

The codec answers "can a URL hold this." The viewer answers "can a URL *be* this":

- Every preview gets a **unique sandbox origin**; Markdown parses as GFM *without sanitizing or rewriting authored HTML*, so README and Obsidian constructs (players, details/summary, attributes, embedded markup) survive. Exact source is always one click away.
- It implements the **complete 24-extension Zensical Markdown set** natively — admonitions, tabs, footnotes, definition lists, SmartSymbols, Keys, Highlight, SuperFences, Arithmatex, MagicLink, GLightbox, TOC permalinks and the rest. Mermaid is vendored locally; MathJax 3.2.2 loads only when math is actually present, and readable TeX remains if the optional network load isn't. Absolute Zensical snippet syntax routes through the same source-module engine — an ln.kr source link is the browser-native equivalent of `--8<--`, with nested expansion, line slicing, cycle checks, and fetch reuse.
- Optional repository rendering: a first line of `style=zensical`, `style=jekyll`, or `style=node` enables a render recipe. Jekyll mode uses sHEL's dark-green Minima palette and a collapsible "On this page" menu — the colors, typography, and menu treatment adapted **directly from this blog's own [Minima custom styles](https://github.com/CommanderTurtle/orc/blob/df42526fc210fc43d5461bc24c3e930d54c66eb2/blog/_sass/minima/sharpscss-custom-styles.fs)**, header, and heading navigation (AGPL-3.0). The `repo=`/`body=`/`css=`/`script=`/`artifact=`/`base=` bases are deliberately *not* page includes: naming a directory never imports its index.
- The execution boundaries are stated out loud: a preparation cache limited to 256 text files / 32 MiB / 16 nested frames with a 20-second per-request timeout; a lazy module lexer that recognizes real ESM imports, cycles, JSON imports, and `import.meta.url` but not fake ones in comments; no proxy, backend, worker service, or package installation. And the caveat that reads like a contract: "naming their repository is not a promise that every application can be rehosted."

## Two Ways Into mk.it

The Make integration closes the loop between the two shel projects. **Hoist to Make** writes mk.it's unchanged `MKIT/1` metadata-and-bytes envelope using the already-vendored pako, DEFLATEs it, and opens mk.it's existing share URL in a new tab — with per-kind filenames and MIME types (`document.md`, `document.html`, `script.js`, `document.txt`) and nothing precomputed or embedded. The reverse direction reads `#share:` and `#p:` links *in the browser*: a Make link on its own line expands as a module, media reuses the existing media modules, and in resource positions (`src`, `url(...)`) the substitution happens only in the private runtime copy, so authored source always shows the short link. Caps are explicit — 32 MiB per render, 128 pointer probes, 15-second probe timeout. Two tools that never make a request to each other, sharing a 130-line format.

## Six Days Of Discipline

The fork started with the video linked from ha.mr's own page — ["I Made the World's First 'Link Compressor'"](https://www.youtube.com/watch?v=TOr1Vvji6jA) — and a pinned upstream import that landed August 20 as a single fix: preserve equals signs in query parameter values. Then nothing until the first week of September, when the whole thing happened in six days:

- **September 1** — the lossless v1 text grammar over the ha.mr codec, the static viewer completed and compacted, parent-scope runs wired in.
- **September 2** — the heaviest day, eight commits: rich document viewers, lossless structural compression, link mode restored with a stateless resolver, the explicit v2 document grammar with its deterministic pipeline, modular source routes, and line-sliced source modules.
- **September 3** — fragment-only routing, the bounded v3 document dictionary, v4 DEFLATE under the same header, and the complete link-source and media routes. All four format versions exist by end of day.
- **September 4** — Zensical rendering and superlinks, hover-capsule source, bookmark-safe previews, opt-in repository render bases and theme styling.
- **September 5** — the mk.it bridge both ways: Make handoff, reading navigation, Make resource resolution.
- **September 8** — the last commit: keep bare issue numbers as markdown text.

## The Test Suite Reads Like A Contract

`bun test` pins: the exact untouched ha.mr ASCII, QR, and emoji fixtures; every alphabet for the text codec; empty, whitespace-sensitive, CRLF/LF, NUL, combining, multilingual, and emoji cases; exact and sparsely modified repetition; multigeneration structural deltas; deterministic mixed-Unicode fuzz; ambiguity-safe emoji boundaries; bounded frequency-shaped v3 dictionaries through every transport alphabet; v4 DEFLATE round trips through every content kind and alphabet; payload corruption rejection; the URL-mode contracts for every guarded, direct, source, live-source, framed, sliced-module, nested-superlink, image, audio/video, and PDF route; the exact Zensical extension inventory; the vendored renderer assets and their license copies; and the vendored JSFuck alphabet and execution. Browser-level checks run against a static fixture host with in-browser mocked raw files — including the runner's offline policy.

A fragment router with a documented-to-the-bit codec, a viewer that renders a document instead of serving it, and a test suite written like a specification. The shortest URL that is also a document — and it knows it.

[github.com/CommanderTurtle/ln.kr](https://github.com/CommanderTurtle/ln.kr) · [FORMAT.md](https://github.com/CommanderTurtle/ln.kr/blob/main/FORMAT.md) · [STRUCTURAL-COMPRESSION.md](https://github.com/CommanderTurtle/ln.kr/blob/main/STRUCTURAL-COMPRESSION.md) · [p2r3/ha.mr](https://github.com/p2r3/ha.mr)

---

#### xkcd of the day, 9/1 - Geology Class #3292

![xkcd of the day](https://imgs.xkcd.com/comics/geology_class_2x.png)

[[the craziest wow 1v1]](https://www.youtube.com/watch?v=-rdzXvWqX_M)

"""

let render() = file
