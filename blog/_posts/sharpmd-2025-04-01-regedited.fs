module ConvertedFiles.Posts.N20250401RegeditedMd

let file = """---
layout: post
title: "regedited: So I Rewrote the Windows Registry in Rust"
author: "CommanderTurtle"
date: 2025-04-01 11:00:00 +0000
tags: [project, registry, rust, windows, database, plaintext]
---

It started as a joke. "Why need a DB? You should dangerously grep a million-line markdown file." That became the repo description, then the design philosophy, then — somehow — an actual Rust project that reimagines the Windows Registry as a memory-mapped, plaintext-parsable database with O(1) section jumps.

## What regedited Is

**regedited** is a fast plaintext parsing database with structured headers, typed hex-word offsets, and O(1) section jumps on multi-GB files. The tagline says it all: *dangerously grep a million-line markdown file*.

The name itself is a pun — "the registry, edited." It's not a registry editor in the traditional sense. It's a complete rethinking of how structured system configuration data should be stored, parsed, and accessed.

## The Core Insight

The inspiration came from the [safetensors](https://github.com/huggingface/safetensors) format — specifically its ability to scan, diff, and replace keys in multi-gigabyte files without loading them into RAM. If that works for ML model weights, why not for structured configuration data?

The approach: memory-map your file and build an index of section headers. A 10GB file with 1,000 sections uses ~200KB of Rust heap — the file lives in OS-managed virtual memory, not your process RAM. The trick is the **hex-word store**: each section header contains typed line-number pointers that encode both the data type and the byte offset.

| Approach | 10GB File RAM | Section Jump |
|----------|--------------|--------------|
| `cat + grep` | 10GB | O(n) scan |
| Python `readlines()` | 10GB | O(1) — at a cost |
| **regedited** | **~200KB** | **O(1) byte offset** |

## Architecture

The database format uses structured markdown documents with full key-value semantics. Section headers carry typed hex-word offsets — essentially embedded metadata that lets the parser jump directly to any section without scanning. The format is human-readable (it's markdown), diff-friendly, and version-control compatible — three things the actual Windows Registry hive format is not.

The Rust codebase is 90.2% Rust, 7.5% Python (for the [test compendium](https://github.com/CommanderTurtle/regedited/blob/main/test_compendium.py)), and 2.3% Shell. The project includes:

- **`src/`** — Core Rust library with the parser, index builder, and section jumper
- **`docs/`** — Format specification and API documentation
- **`examples/`** — Sample databases and usage patterns
- **`pi/`** — Platform interface layer
- **`test_compendium.py`** — Comprehensive Python test suite

## Why Plaintext?

The Windows Registry binary format (hive files) is opaque, fragile, and impossible to version control meaningfully. regedited asks: what if system configuration was just well-structured markdown? Readable in any editor. Diffable in git. Greppable in any Unix tool. And yet — with the hex-word index — as fast as a binary format for random access.

The structured headers mean you don't actually need the "dangerous grep" anymore. The index gives you direct jumps. But the grep still works if you want it — that's the beauty of plaintext.

## Project Status

18 commits on main. AGPL-3.0 licensed. The core engine is functional and the test compendium validates parsing correctness across a range of file sizes and section counts. The project continues to evolve — the next frontier is write operations (safe section edits without full file rewrites) and a query language for filtered lookups.

[github.com/CommanderTurtle/regedited](https://github.com/CommanderTurtle/regedited)
"""

let render() = file
