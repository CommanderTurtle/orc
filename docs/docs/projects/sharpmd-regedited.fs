module ConvertedFiles.Docs.Projects.RegeditedMd

let file = """# Regedited

Regedited is a fast plaintext parse-ment database written in Rust. It reimagines structured data storage by combining the memory-mapping techniques of the safetensors format with a typed hex-word addressing system, enabling O(1) section jumps on multi-gigabyte files without loading them into RAM. The project is licensed under AGPL-3.0.

- [CommanderTurtle/regedited](https://github.com/CommanderTurtle/regedited){:rel="noopener noreferrer" target="blank"} - Source Code
- [Deepwiki](https://deepwiki.com/CommanderTurtle/regedited){:rel="noopener noreferrer" target="blank"} - polled against the latest push (until these docs are further updated)

---

## Overview

???+ note "What this page covers"
    Regedited is a fast plaintext parse-ment database in Rust with O(1) section jumps on multi-gigabyte files via typed hex-word addressing. 21 modules, 11,221 lines, 43 CLI commands. For the related F# documentation system, see [F# Zensical](../xml-project/fsharp-zensical.md). For the sHEL literal-safe processing pipeline, see [XML Project](../xml-project/index.md).

---

## Architecture

Regedited addresses the fundamental limitation of plaintext databases: linear scanning. Where traditional tools such as `cat` and `grep` require O(n) traversal, regedited builds an index of section headers at parse time, enabling direct byte-offset jumps to any section.

```plain
## SECTION: Data
index: 2
0x0000000 : 0x0000000 : 0x0000000 : 0x0000000 : 0x0000000 : 0x0000000
0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0
Data description and notes
Second string line
Third string line
---
# Data Section
```

```mermaid
flowchart LR
    subgraph "Traditional"
        T1["cat file.md<br/>&vert; grep section"] --> T2["O(n) full scan<br/>10 GB in RAM"]
    end
    
    subgraph "Regedited"
        R1["regedited scan file.md"] --> R2["Index built<br/>~200 KB"]
        R2 --> R3["regedited grep file.md section zone<br/>O(1) byte offset jump"]
    end
    
    T2 -.->|"vs"| R3
    
    style T2 fill:#8B0000,color:#fff
    style R3 fill:#4a7c59,color:#fff
```

| Approach | RAM Usage (10 GB file) | Section Jump | Index Size |
|----------|------------------------|--------------|------------|
| `cat + grep` | 10 GB (full file) | O(n) scan | None |
| Python `readlines()` | 10 GB (full file) | O(1) at a cost | Proportional to file |
| Regedited | ~200 KB | O(1) byte offset | ~200 KB for 1,000 sections |

The trick is the hex-word store: each section header contains typed line-number pointers (`0xTLLLLLLL`) that encode both where content lives and what type it is. When content changes, all pointers recalculate automatically.

---

## Hex-Word Format

Each value follows the format `TxLLLLLLL` where:

| Nibble | Field | Description |
|--------|-------|-------------|
| `T` | Type | Content type identifier |
| `LLLLLLL` | Line | 28-bit line number |

### Type Nibbles

| Hex-Word | Type | Line | Meaning |
|----------|------|------|---------|
| `0x000000A` | Markdown | 10 | Text at line 10 |
| `1x0000050` | Code | 80 | Code at line 80 |
| `2x0000A00` | Media | 2560 | Media at line 2560 |
| `3x0000001` | Database | 1 | Data at line 1 |

### Line Range Conversion

```bash
# Convert line ranges to hex-words
regedited convert 50 80 --zone-type code
# Start: 1x0000032
# End:   1x0000050

# Paste into .md:
# 1x0000032 : 1x0000050 : 0x0000000 : 0x0000000 : 0x0000000 : 0x0000000
```

---

## Project Structure

```
regedited/
├── src/                          # 21 modules, 11,221 lines
│   ├── main.rs                   # 1,984 lines — CLI (43 commands)
│   ├── lib.rs                    # 392 lines — core types & re-exports
│   ├── wal.rs                    # 723 lines, 6 tests — crash-safe writes
│   ├── transaction.rs            # 436 lines, 4 tests — batch atomicity
│   ├── schema.rs                 # 590 lines, 4 tests — type enforcement
│   ├── typed_value.rs            # 433 lines, 8 tests — registry types
│   ├── serve.rs                  # 460 lines — HTTP container
│   ├── fast_ops.rs               # 808 lines, 9 tests — scan/diff/replace
│   ├── zone_editor.rs            # 467 lines, 6 tests — content manipulation
│   ├── store.rs                  # 657 lines, 11 tests — high-level API
│   ├── header.rs                 # 555 lines, 9 tests — section scanner
│   ├── db_line.rs                # 549 lines, 13 tests — 9-value parser
│   ├── zone_type.rs              # 377 lines, 11 tests — hex-word codec
│   ├── echo.rs                   # 530 lines, 15 tests — safe echo
│   ├── encapsulate.rs            # 306 lines, 8 tests — b/c/d modes
│   ├── html_extract.rs           # 399 lines, 13 tests — GRAB B/C/D
│   ├── bool_ops.rs               # 356 lines, 10 tests — AND/NAND/OR/XOR
│   ├── zone.rs                   # 462 lines, 6 tests — zone extraction
│   ├── ascii_store.rs            # 240 lines, 5 tests — hex-word store
│   ├── utf16.rs                  # 273 lines, 13 tests — DWORD encoding
│   └── clip.rs                   # 224 lines, 6 tests — clipboard
├── docs/                         # 5 docs, ~2,800 lines
│   ├── ARCHITECTURE.md           # comprehensive reference (500+ lines)
│   ├── FLOWCHART.md              # 7 conceptual diagrams
│   ├── USAGE.md                  # command redirect
│   ├── FORMAT.md                 # format redirect
│   └── PYTHON.md                 # Python integration
├── pi/                           # Pi/OMP skill package
│   ├── SKILL.md                  # 361 lines, 12 workflow categories
│   ├── install.sh                # global/local/OMP install
│   ├── scripts/                  # 9 helper scripts
│   └── references/               # 6 reference docs
└── examples/
    ├── example.md                # v3 format demo
    └── python_workflow.py        # Python integration demo
```

---

## Core Capabilities

### 43 CLI Commands

| Category | Commands | Description |
|----------|----------|-------------|
| **Query** | `list`, `scan`, `grep`, `find` | Section discovery and content retrieval |
| **Edit** | `zone-replace`, `zone-edit`, `zone-delete` | Content manipulation with automatic pointer recalculation |
| **Compare** | `diff`, `patch` | File differencing and patching |
| **Boolean** | `bool-and`, `bool-nand`, `bool-or`, `bool-xor` | Set operations on section content |
| **Extract** | `grab-html`, `html-extract` | HTML attribute extraction (GRAB B/C/D equivalent) |
| **Utility** | `convert`, `echo`, `encapsulate` | Format conversion and safe output |
| **Admin** | `serve`, `wal-check`, `validate` | HTTP container, integrity checks |

### Memory Safety

| Feature | Implementation |
|---------|---------------|
| Crash-safe writes | Write-ahead logging (WAL) — 723 lines, 6 tests |
| Batch atomicity | Transaction system — 436 lines, 4 tests |
| Type enforcement | Schema validation — 590 lines, 4 tests |
| Safe echo | Context-aware output — 530 lines, 15 tests |

---

## Quick Start

```bash
# winget Rustup (if not already)
winget install --source winget --id Rustland.Rustup

# Git Clone
git clone https://github.com/CommanderTurtle/regedited regedited
cd regedited

# Build
cargo build --release

# Add release to path:
sysdm.cpl # Windows (environment variables, add PATH)
# or for linux...
export PATH="$PATH:/home/alienl/repos/regedited/target/release"
source ~/.bashrc

# List sections in a document
./target/release/regedited list myfile.md

# Header-only scan (reads ~100 bytes per section)
./target/release/regedited scan myfile.md

# Extract zone 1 from a section (O(1) jump)
./target/release/regedited grep myfile.md MySection 1

# Replace zone content (automatic line recalculation)
cat new_code.rs | ./target/release/regedited zone-replace myfile.md MySection 1

# Diff two files (metadata only)
./target/release/regedited diff base.md patched.md

# Boolean: contains ALL patterns?
./target/release/regedited bool-and myfile.md MySection "rust" "fn" "main"

# Extract HTML attributes (GRAB B/C/D equivalent)
./target/release/regedited grab-html page.html HREF --tag a --mode d --set 0
```

---

## Inspiration

Regedited is inspired by the safetensors format's ability to scan, diff, and replace keys in multi-gigabyte files without loading them into RAM — applied to structured markdown documents with full key-value semantics.

> "Why need a DB? You should dangerously grep a million-line markdown file." 

It's entirely possible — if you have regedited.

---

This project is very useful in assembly-mapping entire imports to clipboard for the [macrohelp](macrohard.md){ data-preview } project. <br>
(Entire workflows can be indexed) [app.shel.sh/macro](https://app.shel.sh/macro){:rel="noopener noreferrer" target="blank"}

## Related Deep Hole

- [Regedited GitHub Repository](https://github.com/CommanderTurtle/regedited){:rel="noopener noreferrer" target="blank"} — Source code and documentation
- [safetensors](https://github.com/huggingface/safetensors){:rel="noopener noreferrer" target="blank"} — Hugging Face format that inspired regedited
- [Rust Memory Mapping](https://doc.rust-lang.org/std/fs/struct.File.html){:rel="noopener noreferrer" target="blank"} — std::fs::File and memory mapping
- [Alan Kay Quotes](https://www.goodreads.com/author/quotes/117227.Alan_Kay){:rel="noopener noreferrer" target="blank"} — Computing pioneer quotes
"""

let render() = file
