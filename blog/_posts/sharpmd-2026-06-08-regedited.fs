module Bl0g.Posts.N20260608RegeditedMd

let file = """---
layout: post
title: "So I Rewrote the Windows Registry in Rust"
author: "CommanderTurtle"
date: 2026-06-08 04:00:00 +0000
tags: [project, registry, rust, plaintext, database, windows]
---

The repo's README opens with a question it then answers in code: *what makes `regedit` so great?* And the honest answer is: it doesn't make sense. You have a multi-terabyte, cross-machine, cross-decade configuration store, and your primary interface to it is a 30-year-old Windows GUI that can't export a tree to text without a registry hack from Stack Overflow. Meanwhile, the thing that actually works every day on every serious system is a text file plus `grep`.

The project started as a joke in a chat: "Why need a DB? You should dangerously grep a million-line markdown file." Jokes like that have a way of becoming design constraints if you don't catch them in time, so I caught this one on purpose. The result is **regedited** — a plaintext parse-ment database with numeric indexes, typed hex-word ranges, native references, guarded zone relocation, clipboard transport, and optional HTTP and browser runtimes. The tagline, which I stopped apologizing for a long time ago: *the registry, edited.*

This is the full account as of the August 13 documentation audit: 66 commits, v0.1.0 shipped June 8, 2026, and a feature surface that grew from a weekend parser into a little content-operations toolkit.

## The Format: A Six-Line Record That Hides in Plain Text

The entire format is one rule: the literal lowercase phrase `regedited open`, anywhere in any line, marks the start of a record. The six lines immediately below it are the index; everything else in the file is just shared content.

```text
<!-- arbitrary comment text regedited open :anything after it is ignored
index: 64
1x0000055 : 1x000005F : 0x0000000 : 0x0000000 : 0x0000000 : 0x0000000
15 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0
Primary summary
Secondary summary
One important line
...ordinary file content continues...
```

That's the whole record, and the design constraints that shape it are worth naming one at a time:

- **The trigger is a zero-allocation exact byte search** for `regedited open`. No `to_lowercase()`, no string allocations, no regex. It can live inside an HTML comment, a JS block comment, a bash comment, a markdown bold, or mid-sentence in prose, and the scanner doesn't care — text before and after the phrase on the same line is ignored, forever. There is deliberately no name on the trigger line.
- **Identity is the number on the line after.** `index: 64` is *the* identity of that record. `64`, `i64`, and `index:64` all resolve to it. Duplicate numbers are rejected. Any characters wrapped around the trigger never become a name. This is the "canonical index" idea, and it's what makes the tool composable — you can reference a region of any file by a number, from any shell, without quoting the contents.
- **The six hex-words are three typed zone pairs.** Each word is `TxLLLLLLL`: a type nibble, the literal `x`, and a seven-digit hex line number. Seven hex digits is 28 bits — 268,435,456 addressable lines, maximum line `0x0FFFFFFF`. That's a deliberate headroom choice: the index format should outlive the documents it addresses by at least an order of magnitude.
- **The type nibble is immediately visible, no bit-shifting.** `0` is markdown/text, `1` is code, `2` is media, `3` is database, `4–F` reserved. The inline tokens are `p`, `b`, `m`, `d` respectively. A line pointer carries both *address* and *intent*, and a human can read the type off the first character. That's the safetensors inheritance in its purest form: keep the addresses small, make the identity explicit, don't pretend the payload needs a heavyweight schema.
- **Nine exact decimal values** (pipe-separated, legacy tabs accepted) are the record's database column. **Three strings** are the labels. And the zones are absolute line ranges anywhere in the shared document — not offsets into the record, the whole file.

The consequence of this whole shape is that the file *stays* the file. Your markdown is still markdown, your HTML is still HTML, your script is still a script. The index is a small structured bolt that any editor shows and any `grep` finds. If regedited disappears tomorrow, nothing about the file changes.

## Why It's Fast (and Why That's the Whole Point)

The fast paths — `scan`, single-pattern `fgrep`, metadata diff — **memory-map the file, walk borrowed UTF-8 slices, and build compact metadata per index.** They never deserialize a database and never construct an object per content line. A million-line document with a dozen indexes is scanned in the shape of a `grep`, because it *is* a `grep`, just one that knows where the structure is.

The operation-to-read map is the honest summary:

| Operation | What it reads |
|---|---|
| `scan`, `fgrep`, metadata diff | The memory-mapped file and the index metadata lines |
| Indexed string or DB lookup | The owned document, then the selected index metadata |
| Zone extraction | The owned document, then the line range in one zone pair |
| Mutating commands | The owned document, then a direct rewrite with backup/undo behavior |
| `check` / `commit` | Compact fingerprints and surrounding line anchors |

And the stress test is in the repo, marked `--ignored` so it doesn't run on CI by default: **relocate a zone inside a one-million-line document and verify the checkpoint stays compact.** `cargo test million_line_relocation_keeps_checkpoint_compact --lib -- --ignored`. I keep it visible because it's the test that separates "a clever format" from "a format you can use on files that are actually big."

## Native References: One Grammar for Everything

The command surface is where the joke became a tool. Instead of one command family per data type, there's one reference grammar that resolves to strings, DB values, full metadata lines, zones, and literal hex ranges, and *everything* — read, write, copy, diff, boolean compare — operates on references.

| Canonical reference | `rgd` form | Resolves to |
|---|---|---|
| `index:64` | `i64` | Whole-index aggregate |
| `index:64:string:2` | `i64s2` | String 2 |
| `index:64:db:7` | `i64db7` | DB value 7 |
| `index:64:dbline` | `i64dbl` | All nine DB values |
| `index:64:zone:1` | `i64z1` | Zone 1 content |
| `hex:1x0000055..1x000005F` | — | Literal line range |
| `text:hello` | — | Literal string |

So the everyday operations look like this:

```bash
rgd rg i64s2                          # read string 2 of index 64
rgd rg i64z1 c                        # read zone 1, copy to clipboard
rgd rs i64s2 --text "follow up Friday"
rgd rc i64z1 i70z2                    # copy zone content across indexes
rgd rd i64db1 i70db2                  # diff two DB values
rgd rb i64db7 gte 8 --then-val READY --else-val WAIT
```

The boolean commands (`ref-bool`, `bool-and/nand/or/xor`, `if-contains`, `count`) take exact scopes: a single ref, a whole-index aggregate, or `__all__` for the whole document. And the numeric comparisons use **the same exact fixed-point decimal representation as the DB values — a malformed number is an error, not a false result.** That last sentence is not a footnote; it's the difference between a toy and a tool. A boolean that silently swallows `1.2.5` as `false` is a lie with a good exit code.

There are also two binaries. `regedited` is the explicit, stateless command surface; `rgd` is the same executable with aliases, compact references, and an optional remembered file path (`rgd load notes.md`, then `rgd l` just works; an explicit path always wins). On Windows the helper creates a hard link, on Linux a symlink — one build, two names, PATH added by `scripts/pathadd.ps1` or `scripts/pathadd.sh`.

And the help system is generated from the actual Clap definitions and alias registry, with per-shell example lanes: `rgd rb --help --ex 1` through `--ex 8` produce PowerShell, Bash, Python, and CMD example sets, standard then advanced. The documentation in `docs/shell/` — POWERSHELL.txt, BASH.txt, PYTHON.txt, BAT.txt, REPL.txt — is written as the command examples each shell actually runs. That's the part that cost the most August 13 (more on that below), and it's the part I'm most glad of, because a CLI whose examples only run in the README is a CLI that's half documented.

## Guarded Zone Relocation: The Tool That Refuses to Guess

The hardest problem in the whole design was this: the format stores *absolute* line ranges in the zone pairs. If content above a zone moves, the hex-word pair goes stale. A naive tool rewrites them by best effort and prays. Regedited does the opposite — it **refuses to guess**, and the refusal conditions are explicit:

- the index disappeared or became ambiguous;
- the literal hex-word pair changed after the checkpoint;
- the old content has multiple plausible new locations;
- content changed in place rather than moving cleanly.

The workflow is a checkpoint, not a history:

```bash
rgd cm          # create the first compact checkpoint
# edit the document normally
rgd ck          # calculate a guarded temporary relocation diff
rgd pl          # apply safe relocations
# or: rgd cm --pull
```

The checkpoint is `<document>.rgd-state.json` — compact content fingerprints and nearby line anchors, **not** a document history. There is no commit log, by design; a new checkpoint replaces the old one after the work is accepted. One-step undo lives in `<document>.undo`, and the explicit WAL operations (`wal`, `wal-replay`) plus `tx begin/commit/rollback/status` are there for the people who want journaling on. The point of the whole mechanism: when the document has moved, the tool either proves it knows where, or it tells you it doesn't, and never the third option, which is a plausible-looking guess.

## The Runtimes: CLI, HTTP, and a Read-Only Browser

The same reference grammar drives three runtimes:

1. **The CLI** — the primary surface, as above.
2. **`regedited serve --file notes.md --port 5000`** — a native HTTP container, read-only by default, binding `0.0.0.0`. The routes are numeric-index-first: `GET /sections`, `/section/{index}`, `/section/{index}/db`, `/section/{index}/hexline` (with `/ascii` retained as a legacy alias), `/grep?pattern=…&index=…`, `/ref?spec=…`, `/ref-bool?left=…&op=…&right=…`, `/state`, `/wal`, `/health`, and `POST /query` for boolean query JSON. The old `/section` route names are retained for compatibility; the identity inside them is numeric-index-first. A plaintext database that can be `curl`ed from another machine is a plaintext database that can be *used* by a pipeline, and that's the point of the runtime.
3. **The Wasm browser package** — built by `scripts/webbuild.ps1` / `webbuild.sh` (which verify `wasm32-unknown-unknown` and `wasm-pack` before installing), read-only by construction — the runner intentionally rejects mutating commands — and exposes scan, grep, index reads, compact refs, and conversion from a plain string. The detail that matters: `dbExact(64)` returns **exact decimal strings, without JS `Number` rounding.** A database view in the browser that silently turns `0.1 + 0.2` into `0.30000000000000004` is a different product than the one on the CLI. The August 13 commit "Preserve exact decimals in browser bindings" exists because I let that happen once, and I never let it again.

## The Actual History, From the Commit Log

The 66-commit graph is more interesting than the feature list, so here it is honestly:

- **June 8, 2026 — v0.1.0.** Initial commit at 16:43, the full tree pushed at 16:49, and the 0.1.0 changelog written at 21:33 the same evening. The parser, the format, the CLI, the first tests: one day.
- **June 8–29 — the rebuild cycle.** This is the part I'd usually cut from a post and am keeping on purpose: the graph shows the whole tree deleted and re-pushed on June 15, June 22, and June 29, each time "delete src, delete docs, delete examples, delete pi, delete Cargo.toml, delete the docs directory… then a fresh push." The README's own opening joke — *dangerously grep a million-line markdown file* — applies to the repo's history too. The format was being re-derived from first principles each cycle, and each re-derivation tightened it: the record layout, the hex-word encoding, the canonical index rule. Some of that was thrash. Some of it was the format finding its shape. The commit log doesn't distinguish, and neither should I.
- **July 18–21 — the QoL wave.** `.gitignore` done right, README restructured with a table of contents, `QUICK_START.md` split out as its own onboarding path, and the "QoL Feature Update 3" pass. This is the stretch where the project stopped being "my parser" and started being "a thing another person could install."
- **August 13 — the audit.** A single dense day, eleven commits, and the one I'd call the release that made it a project: *Canonicalize Regedited index records and command behavior*, *Scope boolean operations and add advanced help lanes*, *Document every Regedited command across interactive shells*, *Validate command examples across interactive shells*, *Preserve exact decimals in browser bindings*, *Fix canonical record build and range assertions*, and the closing documentation pair — *Document exact boolean scopes and advanced examples* / *Document August audit and exact reference flows*. After that day, every command was documented in the shells people actually use, the boolean scopes were explicit instead of implied, and the browser could no longer lie about decimals.

## Why Not Just Use a Database

Because the database was the problem. A registry — any registry, Windows or otherwise — is configuration that other systems read and write, and the failure mode of a binary store is *opacity*: you cannot read it in a text editor, you cannot `git diff` it, you cannot pipe it through a review, and the moment the tool that owns it is gone, the data is hostage to the tool's archaeology. regedited inverts that: the data is the file, the file is the source of truth, and the tool is a fast, opinionated reader/writer that leaves no proprietary residue. If you disagree with the format, the document is still a document.

That's the whole philosophy in one sentence, and everything else — the memory-mapped scan, the exact decimals, the refusal to guess — is implementation details in service of it.

[github.com/CommanderTurtle/regedited](https://github.com/CommanderTurtle/regedited)

---

#### xkcd of the day, 6/8 - Nostalgia Content #3256

![xkcd of the day](https://imgs.xkcd.com/comics/nostalgia_content_2x.png)

[[how is qubes different from just running vms]](https://blog.invisiblethings.org/2012/09/12/how-is-qubes-os-different-from.html)

"""

let render() = file