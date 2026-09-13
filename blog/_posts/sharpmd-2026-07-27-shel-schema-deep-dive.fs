module Bl0g.Posts.N20260727ShelSchemaDeepDiveMd

let file = System.String.Join("\"\"\"", [|
    """---
layout: post
title: "Deep Dive: The sHEL Schema System — A Database Engine in Your Clipboard"
author: "sHEL Team"
date: 2026-07-27 14:00:00 +0000
tags: [technical, schema, deep-dive, sHEL, cmd]
---

The docs describe what sHEL can be in a list that reads like a job board for seven different tools: a full schema system, a query language, a serializer/deserializer, a macro-friendly API, a clipboard-based KV store, a Markdown dashboard generator, and a "CMD database engine" with indexing. It "feels like" Redis, Jinja2, SQLite, a templating engine, and a macro system — "all fused into one."

That's a lot of claims. This post is the deep dive into the one everything else hangs off: the schema system, as documented in the [XML Project](https://docs.shel.sh/xml-project/) section of the docs. It's the part of sHEL that started as a boolean-structure trick for multi-line assembly and grew into a literal-safe way to store, search, and transform data using nothing but `cmd.exe`, `clip`, and `echo`.

## The Parser Problem, Precisely

Every schema is a response to a specific failure mode. sHEL's is `cmd.exe`. At parse time, the command interpreter treats a defined set of characters as control operators:

| Character | Behavior |
|---|---|
| `&` | Command separator |
| `\|` | Pipe |
| `<` | Input redirect |
| `>` | Output redirect |
| `^` | Escape character |
| `%` | Variable expansion |
| `"` | Quote-state toggle |

The last one is the one that surprises people, and it's the one the whole design revolves around: in `cmd.exe`, the double quote **is not a string delimiter**. It toggles the parser's quote-state flag. A stray quote at the end of a line can leave the parser sitting in quoted mode for every subsequent line inside a parenthesized block. Data that contains quotes doesn't just need escaping — it needs to stop being interpreted, entirely. That's what "literal-safe" means: the character never becomes syntax.

## The Solution: Layered Encoding

The documented approach is a five-layer system, and every layer is a `cmd.exe` builtin or a Windows system primitive — no external tools, no SDK:

1. **Base64 encoding** — binary-safe transport of any data through text pipelines (RFC 4648).
2. **Delayed expansion** — `cmd /v /c` with `!var!` syntax for safe variable handling.
3. **FOR /F parsing** — structured data extraction from command output.
4. **findstr filtering** — pattern matching for data selection.
5. **Clipboard integration** — bidirectional data transfer via `clip` and `Get-Clipboard`.

Each layer buys a different safety property, and the schema system is the structure you build on top of all five at once.

## The Record Format: b, c, and d

Here's the core of the schema. In sHEL, you never store a value as one string. You store it as up to **three encoding variants** of itself, and the variant you reach for depends on what operation you're about to run:

```batch
set "b=["'I am a hater of XML'"]"   &  echo %b% | clip
```

- **b-format** — `["<html>"]`. Wrapped in `["` and `"]`. This is the *searchable* form: it's what you `findstr` against, because the wrapper gives the pattern a clean, unambiguous boundary.
- **c-format** — `['<html>']`. Wrapped in `['` and `']`. This is the *delimiting* form: what `FOR /F` walks token-by-token.
- **d-format** — `["'<html>'"]`. Double-wrapped. This is the *storage* form — the canonical record in the database. You extract the previous data out of it with substring math: `%d:~3,-3%` peels the wrapper off and hands you the raw value back.

The wrappers themselves live in three tiny helper variables, and the "encoding" of a record is a substring splice:

```batch
set "x=["
set "y=['"
set "z=["'"
set "0aaa=<111somehtml line 1>"

set '0aad=%x:~0,2%%0aaa%%x:~2%'   REM -> b-format
set "0aba=%y:~0,2%%0aaa%%y:~2%"   REM -> c-format
set 0abd=%z:~0,3%%0aaa%%z:~3%     REM -> d-format (storage)
```

Read that last line slowly. `%z:~0,3%` is the three-character wrapper `["'`, `%0aaa%` is the data, `%z:~3%` is the closing `']`. No escaping. No quoting acrobatics. The special characters are *inside* a value that the parser already decided was a literal, because the wrapper was assembled out of substring expansions rather than typed through the quote state.

And the reason you keep all three forms around is documented explicitly, with the failure modes:

- **b** is almost always perfect for echo, but *can't delimit* — it walks wrong under `FOR /F` tokens.
- **c** is what you feed to the tokenizer — but nested-echo behaves *opposite* for c: it collapses a multi-line block into a single oneliner string, compressing HTML to one line.
- **d** is almost always safe, *can't delimit*, but is what `findstr` likes, and it's the only form from which you can recover the raw value.

The docs are candid about the trade: "c must use `%aif%`-INNER-`%ahas%`" while "b/d must use `INNER`-`%ahas0%`." The quote-completion asymmetry between the variants is why the boolean macros come in two flavors — `ahas` and `ahas0`, where `ahas0` "completes a quote, too."

## The Database: Indexing Without a Database

The naming is where the "CMD database engine with indexing" claim starts making sense. Records are stored as *numbered variable series*:

```batch
set "0aaa=Title: Task 1 DB: My Datasheet"
set "0aab=| Index | TodoCount | ThinkCount | TermCount | PyCount | BufferVar |"
set "0aac=|-|-|-|-|-|-|"
set "0aad=| 1aaa # | 0aaa # | 0aab # | 0aac # | 0aad # | 0aae # |"
```

The first character pair is the **database index** — `0a` is database one. A second database is just a second series:

```batch
set "0baa=Title: Task 1 DB: My Second Datasheet"
```

Each database is a full Markdown table (the title line, the header row, the separator row, the data rows) that can be encoded into b/c/d form line-by-line and — here's the part that makes it a KV store — **piped to the clipboard**. The use case, from the docs, is unapologetic: "XML can store a large sum of data. This project was initially justified due to being able to consecutively use basic dos shell, clip, and markdown, to store an insane amount of data as an alternative to SQL databasing." The assumption is clipboard history disabled, everything in temporary memory, `clip` and `echo` doing the heavy lifting. Volatile by design — which is the "volatile" in the sHEL description, and it's a feature, not a gap.

## The Query Language: Boolean Commands

The schema isn't just storage. The documented "query" primitive is a **boolean command** — an `if/then/else` constructed from `find /I` plus the macro fragments the docs define (`aif`, `ahas`, `athen`, `cc`, `dd`, `ee`):

```batch
%aif%the quick brown fox%ahas%wolf|fox%athen%(echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)%cc%buffer=about:blank%dd%echo %buffer%%ee%
```

The shape is always the same, and it's worth reading as a grammar:

```
%aif%  <subject>  %ahas%  <needle>  %athen%  <true-action>  %cc%  <else-var>  %dd%  <false-action>  %ee%
```

`%ee%` is literally just `| clip` — the output channel of the whole system is the clipboard, and the "else" branch's job is usually to set a buffer and clip that instead. The docs' rule for the two variants is the C=INPUT / B=OUTPUT contract: **you must use c for input and b for output.** You search the c-encoded block; you clip the b-encoded result.

A v2.0 `search` macro automates the bookkeeping — when you tokenize, it maintains all four buffers at once:

```
bbuf = ["result"]
cbuf = ['result']
dbuf = ["'result'"]
clipboard = ["result"]
```

So a "SELECT" in this database engine is: build the database series, append it to b/c/d, run the boolean command with your needle, and read the clipboard. No engine process. No files on disk. No connection string.

## The Variable Schema: Haiku Numbersystem

A schema that doesn't constrain identifiers isn't a schema, so the third pillar is the **Haiku Numbersystem** — a variable naming convention that exists specifically to keep user variables from colliding with the three populations of names the parser already owns:

1. **cmd.exe reserved words** — `CALL`, `ECHO`, `ENDLOCAL`, `FOR`, `GOTO`, `IF`, `NOT`, `SET`, `SETLOCAL`, `SHIFT`.
2. **Dynamic variables (read-only)** — `%CD%`, `%DATE%`, `%TIME%`, `%RANDOM%`, `%ERRORLEVEL%`, `%CMDEXTVERSION%`, `%CMDCMDLINE%`, `%HIGHESTNUMANODENUMBER%`.
3. **Environment variables** — `PATH`, `TEMP`, `USERPROFILE`, `COMPUTERNAME`, `SYSTEMROOT`, and friends.

The rules:

- **Prefix pattern** — every user variable is `sh_<semantic descriptor>`. `sh_count`, `sh_name`, `sh_buffer`. Nested loop counters get ordinal suffixes: `sh_i_1`, `sh_i_2`, `sh_i_3`.
- **Loop variable mapping** — a `FOR` token (`%%A`–`%%Z`) is captured into a named variable immediately, and all further processing uses delayed expansion: `set "sh_line=%%A"` then `!sh_line!`.
- **Delayed-expansion-safe names** — no `!` in a name (it's the expansion delimiter), no `(` or `)` (they break substitution), no `&` (command separator), no `,` (parameter separator).
- **Scope** — `SETLOCAL`/`ENDLOCAL` boundaries so subroutine variables don't leak into the parent environment.

And the arrays. `cmd.exe` has no arrays, so the Numbersystem simulates them with indexed naming and a second expansion pass:

```batch
set "sh_file_1=readme.txt"
set "sh_file_2=config.ini"
set "sh_file_3=data.csv"

setlocal enabledelayedexpansion
set "sh_idx=2"
CALL echo File %%sh_file_%sh_idx%%%    REM Outputs: config.ini
```

The `CALL` statement forces a second expansion pass, resolving `%%sh_file_2%%` to the value. The docs call it "the only reliable method for indirect variable access in `cmd.exe`" — which is exactly the kind of load-bearing fact a schema needs to state.

## The Literal Ladder

The docs close the XML Project with an honest "where I left off" section: error handling, framed as a *literal ladder* — five levels of quoting, each one more real than the last:

```batch
b=[""]    c=['']    d=["'']

str(1)         set "a=blank"
realstr(2)     set a="blank"
literal(4)     set a='test'
actual(5)      set a=blank
realrealstr(3) set "a=""blank"""
    """
```

The working rule: c and b succeed together on levels 1 and 3; level 2 is where c succeeds and b fails, which is how you tell the two variants apart. Any failure means you need another variant appended — you grab the line you need and move on. It's a debugging taxonomy for a parser with no exceptions: when a form breaks, the ladder tells you which rung you're actually standing on.

## What This Buys

Pulling it back together, the schema system is a serialization format (b/c/d variants of every record), a query language (boolean commands with a fixed grammar), an indexing scheme (numbered variable series per database), a KV store (the clipboard, volatile by design), and a serializer/deserializer (the `%d:~3,-3%` unwrap). It feels like the tool list in the docs because *it is* the tool list — each tool is one documented pattern over the same five primitives.

The constraint that makes all of it coherent is the one from the very first paragraph of the docs: **data containing `cmd.exe` special characters, stored and transmitted without triggering unwanted parser interpretation.** Every layer, every variant, every naming rule exists to keep the character from ever becoming syntax.

The full documentation is at [docs.shel.sh/xml-project](https://docs.shel.sh/xml-project/) — the [Symbols Archive](https://docs.shel.sh/symbols/) covers the character reference and Base64 alphabet, [cmd.exe Literacy](https://docs.shel.sh/xml-project/cmd-literacy/) covers the parser phases, and [Haiku Numbersystem](https://docs.shel.sh/xml-project/haiku-numbersystem/) covers the variable schema in full.

[github.com/CommanderTurtle/docs-pages](https://github.com/CommanderTurtle/docs-pages)

---

#### xkcd of the day, 7/27 - Forth #3277

![xkcd of the day](https://imgs.xkcd.com/comics/forth_2x.png)

[[what's better, proxmox vs qubes?]](https://forum.qubes-os.org/t/proxmox-vs-qubes/33185/19)

"""
|])

let render() = file
