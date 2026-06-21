module ConvertedFiles.Docs.Symbols.IndexMd

let file = """# Symbols Archive

A reference of special characters and their behavior across parsing contexts. This archive documents the exact interpretation of every symbol encountered in `cmd.exe` command processing, HTML attribute parsing, and Base64 encoding alphabets. The behavior documented here is derived from direct experimentation and verified against official specifications.

---

## Overview

???+ note "What this page covers"
    This page serves as the master symbol reference for the sHEL project:

    - **cmd.exe Control Characters** — Special interpretation during command-line parsing
    - **Quoting and Escaping** — Caret escaping, quote handling in FOR/F
    - **Variable Expansion** — Immediate vs delayed expansion comparison
    - **FOR/F Parsing** — Options reference and usebackq modes
    - **HTML Encoding** — Characters requiring encoding in HTML contexts
    - **Base64 Alphabet** — RFC 4648 character-to-value mapping

    For stereogram encoding techniques, see [Stereograms](stereograms.md). For cmd.exe parser phases, see [cmd.exe Literacy](../xml-project/cmd-literacy.md).

---

## cmd.exe Control Characters

The following characters trigger special interpretation during `cmd.exe` command-line parsing. The parser operates in phases: first, the entire line (including parenthesized blocks) is read; second, variables are expanded; third, redirection operators are processed; finally, the command is executed.

```mermaid
flowchart LR
    subgraph Parse["Parse Phase"]
        P1["Variable<br/>Expansion<br/>%VAR%"]
        P2["Caret<br/>Escaping<br/>^char"]
        P3["Quote<br/>Toggle<br/>”"]
    end

    subgraph Execute["Execution Phase"]
        E1["&<br/>Command sep"]
        E2["|<br/>Pipe"]
        E3["< ><br/>Redirect"]
    end

    subgraph Effect["Effect"]
        direction TB
        SAFE["Literal-safe:<br/>Base64 encoding<br/>Delayed expansion<br/>FOR/F parsing"]
    end

    Parse --> Execute --> Effect

```

| Character | Phase Affected | Behavior | Literal-Safe Method |
|-----------|---------------|----------|---------------------|
| `&` | Execution | Command separator: starts a new command on the same line | `^&` caret escape; quoting |
| `\|` | Execution | Pipe: redirects stdout of left command to stdin of right | `^\|` caret escape; quoting |
| `<` | Execution | Input redirection: read stdin from file | `^<` caret escape |
| `>` | Execution | Output redirection: write stdout to file | `^>` caret escape |
| `^` | Parse | Escape character: the following character loses special meaning | `^^` double-caret |
| `%` | Parse/Expand | Variable delimiter: `%VAR%` triggers immediate expansion | `%%` doubling; delayed expansion |
| `"` | Parse | Quote toggle: switches "quoted mode" on/off (not a true delimiter) | `\"` backslash-escape |

!!! warning "The Quote Toggle Behavior"
    The double-quote character in `cmd.exe` does not delimit strings. It toggles a quote-state flag in the parser. A `"` at the end of a line may leave the parser in quoted mode for subsequent lines within a parenthesized block. This is why `"delims=^""` requires careful construction — the parser state changes mid-parse.

---

## Quoting and Escaping Mechanics

### Caret Escaping

The caret (`^`) is the general-purpose escape character in `cmd.exe`. It prevents the next character from being interpreted as a control operator.

```batch
REM Escaping redirection operators
echo This ^> that        REM Outputs: This > that
echo This ^& that        REM Outputs: This & that
echo This ^|^| that      REM Outputs: This || that

REM Escaping the escape character itself
echo Caret: ^^           REM Outputs: Caret: ^

REM Escaping in a variable assignment
set "expr=5 ^> 3"
echo %expr%              REM Outputs: 5 > 3
```

!!! note "Caret Escaping Limitations"
    The caret escape is processed at parse time, before variable expansion. A caret before a `%variable%` will escape the percent sign, not the expanded value. For escaping expanded content, use delayed expansion with `!variable!` syntax instead.

### Quote Handling in FOR /F Delimiters

When specifying `"` as a delimiter in `FOR /F`, the parser's quote-toggle behavior creates a special case:

```batch
REM This uses escaped quotes within the options string
FOR /F "delims=^\"" %%A IN ('command') DO echo %%A
```

The `"delims=^""` syntax works because the caret escapes the quote, preventing it from toggling parser state while still passing the quote character as the delimiter value.

---

## Environment Variable Expansion

### Immediate Expansion (%VAR%)

By default, variables are expanded when the line is parsed, not when it is executed. This means the value is fixed before any commands on that line run.

```batch
@echo off
set VAR=before
set VAR=after & echo %VAR%
REM Outputs: before (the old value, expanded before set executed)
```

### Delayed Expansion (!VAR!)

Delayed expansion, enabled via `SETLOCAL EnableDelayedExpansion` or `cmd /v:on`, defers variable expansion until execution time. Variables enclosed in exclamation marks are re-evaluated each time they are encountered.

```batch
@echo off
SETLOCAL EnableDelayedExpansion
set VAR=before
set VAR=after & echo %VAR% !VAR!
REM Outputs: before after
REM %VAR% shows parse-time value; !VAR! shows execution-time value
```

| Aspect | `%VAR%` (Immediate) | `!VAR!` (Delayed) |
|--------|--------------------|--------------------|
| Expansion timing | Parse time (line read) | Execution time (command run) |
| FOR loop behavior | Shows initial value throughout | Updates each iteration |
| IF block behavior | Fixed at block entry | Dynamic within block |
| Pipe behavior | Standard | May be disabled in new cmd instance |
| Exclamation marks in data | Safe | Consumed as variable syntax |

---

## FOR /F Parsing Modes

The `FOR /F` command processes command output or file content with configurable parsing behavior controlled by its options string.

### Options Reference

| Option | Purpose | Example |
|--------|---------|---------|
| `delims=chars` | Characters that separate tokens | `"delims=,"` splits on commas |
| `tokens=n` | Which tokens to capture (1-31, *) | `"tokens=2,*"` captures token 2 and rest |
| `skip=n` | Skip first N lines | `"skip=1"` skips header line |
| `eol=char` | End-of-line comment character | `"eol=#"` ignores lines starting with # |
| `usebackq` | Enable backquote semantics | Required for quoted filenames |

### usebackq Modes

`FOR /F` has three quote-handling modes determined by `usebackq`:

```mermaid
flowchart TD
    subgraph Default["Default Mode"]
        D1["'text'<br/>== LITERAL TEXT"]
        D2["ˋcommandˋ<br/>== COMMAND"]
    end

    subgraph Usebackq["usebackq Mode"]
        U1["'file.txt'<br/>== FILENAME"]
        U2["ˋcommandˋ<br/>== COMMAND"]
    end

    Default -->|"usebackq option"| Usebackq

```

```batch
REM Default mode: single-quoted strings are LITERAL TEXT
FOR /F "delims=" %%A IN ('literal text here') DO echo %%A
REM Processes the words "literal", "text", "here" as lines

REM usebackq mode: backquoted strings are COMMANDS
FOR /F "usebackq delims=" %%A IN (`dir /b`) DO echo %%A
REM Runs 'dir /b' and processes its output

REM usebackq mode: single-quoted strings are FILENAMES
FOR /F "usebackq delims=" %%A IN ('C:\path\to\file.txt') DO echo %%A
REM Reads lines from the specified file
```

!!! info "The usebackq Distinction"
    Without `usebackq`, a single-quoted string in the IN clause is treated as literal text to parse. With `usebackq`, single quotes indicate a filename and backquotes indicate a command to execute. This option is essential when filenames contain spaces and must be quoted.

---

## HTML Encoding Characters

Characters that require encoding when appearing in HTML attribute values or text content.

| Character | Entity Reference | Numeric Reference | Context |
|-----------|-----------------|--------------------|---------|
| `&` | `&amp;` | `&#38;` | All HTML contexts |
| `<` | `&lt;` | `&#60;` | All HTML contexts |
| `>` | `&gt;` | `&#62;` | All HTML contexts |
| `"` | `&quot;` | `&#34;` | Inside double-quoted attributes |
| `'` | `&#39;` | `&#39;` | Inside single-quoted attributes |
| `/` | `&#47;` | `&#47;` | Inside `</` sequence in script contexts |

!!! note "Base64 and HTML Context"
    Base64-encoded data using the standard alphabet (RFC 4648) contains only `[A-Za-z0-9+/=]`. None of these characters require HTML encoding, which is one reason Base64 is safe for embedding in HTML attributes via `data:` URIs.

---

## Base64 Alphabet

RFC 4648 specifies the following character-to-value mapping for Base64 encoding:

| Char | Value | Char | Value | Char | Value | Char | Value |
|------|-------|------|-------|------|-------|------|-------|
| A | 0 | Q | 16 | g | 32 | w | 48 |
| B | 1 | R | 17 | h | 33 | x | 49 |
| C | 2 | S | 18 | i | 34 | y | 50 |
| D | 3 | T | 19 | j | 35 | z | 51 |
| E | 4 | U | 20 | k | 36 | 0 | 52 |
| F | 5 | V | 21 | l | 37 | 1 | 53 |
| G | 6 | W | 22 | m | 38 | 2 | 54 |
| H | 7 | X | 23 | n | 39 | 3 | 55 |
| I | 8 | Y | 24 | o | 40 | 4 | 56 |
| J | 9 | Z | 25 | p | 41 | 5 | 57 |
| K | 10 | a | 26 | q | 42 | 6 | 58 |
| L | 11 | b | 27 | r | 43 | 7 | 59 |
| M | 12 | c | 28 | s | 44 | 8 | 60 |
| N | 13 | d | 29 | t | 45 | 9 | 61 |
| O | 14 | e | 30 | u | 46 | + | 62 |
| P | 15 | f | 31 | v | 47 | / | 63 |
|   |   |   |   |   |   | = | Pad |

The URL-safe variant (RFC 4648 section 5) substitutes `-` for `+` and `_` for `/`, with padding omitted.

---

## Path and Separator Characters

| Character | Name | Platform Notes |
|-----------|------|----------------|
| `\` | Backslash | Directory separator on Windows; escape character in many contexts |
| `/` | Forward slash | Directory separator on Unix; alternate separator on Windows |
| `:` | Colon | Drive letter separator (`C:`); also namespace operator in PowerShell |
| `;` | Semicolon | Path separator in `PATH` environment variable |

---

## Related Pages

- [Stereograms](stereograms.md) — 3D depth encoding in 2D images
- [cmd.exe Literacy](../xml-project/cmd-literacy.md) — Detailed parser phase documentation
- [Base64 Encoding](../xml-project/base64.md) — Base64 encoding/decoding reference

## Related Deep Hole

- [Stack Overflow: How does delayed expansion work in a batch script?](https://superuser.com/questions/1569594) — Deep dive into the parse phases of cmd.exe
- [Stack Overflow: Example of delayed expansion in batch file](https://stackoverflow.com/questions/10558316) — Iteration counter example with and without delayed expansion
- [SS64 Forum: SETLOCAL ENABLEDELAYEDEXPANSION discussion](https://ss64.org/viewtopic.php?t=27) — Caret double-escaping behavior with delayed expansion enabled
- [Server Fault: Double expansion syntax with delayed expansion](https://serverfault.com/questions/949759) — CALL statement as second expansion mechanism
- [TenForums: Batch file issue with EnableDelayedExpansion](https://www.tenforums.com/general-support/169953-batch-file-issue-related-enabledelayedexpansion.html) — Common IF-block variable update confusion
- [The Old New Thing: Environment variable expansion](https://devblogs.microsoft.com/oldnewthing/20060823-00/?p=29993) — Raymond Chen's explanation of parse-time vs execution-time expansion
"""

let render() = file
