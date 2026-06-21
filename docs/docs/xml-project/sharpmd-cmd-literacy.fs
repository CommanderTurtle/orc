module ConvertedFiles.Docs.XmlProject.CmdLiteracyMd

let file = """# cmd.exe Literacy

Command prompt scripting literacy encompasses understanding the `cmd.exe` parser phases, the `FOR` command family, `findstr` for pattern matching, `TYPE` for file output, and the delayed expansion system. These primitives form the foundation of the sHEL literal-safe processing pipeline.

---

## Parser Phases

The `cmd.exe` command interpreter processes batch script lines in well-defined phases. Understanding these phases is necessary for predicting how any given command will behave.

```mermaid
flowchart LR
    A["1. Read Line"] --> B["2. %var% Expansion"]
    B --> C["3. Redirection Detection<br/>&lt; &gt; &gt;&gt; |"]
    C --> D["4. Caret Escaping<br/>^"]
    D --> E{"5. Delayed<br/>Expansion<br/>Enabled?"}
    E -->|Yes| F["5a. !var! Expansion"]
    E -->|No| G["6. Control Operators<br/>& &verbar; &lt; &gt;"]
    F --> G
    G --> H["7. Execute"]

    style A fill:#2d5a3a,color:#fff
    style H fill:#4a7c59,color:#fff
    style E fill:#5a3a2d,color:#fff
```

1. **Read Phase**: The line is read from the script (entire parenthesized blocks count as a single line)
2. **Percent Expansion**: `%variable%` references are replaced with their values
3. **Redirection Detection**: `< > >> |` operators are identified and removed from the command text
4. **Caret Escaping**: `^` escape sequences are processed
5. **Delayed Expansion**: If enabled, `!variable!` references are expanded (this is Phase 5 per the official parse documentation)
6. **Special Character Handling**: Remaining `& | < >` are interpreted as control operators
7. **Execution**: The command is invoked

### Phase 5 Subphases (Delayed Expansion)

Delayed expansion occurs only if all of the following are true:

- Delayed expansion is enabled (via `SETLOCAL EnableDelayedExpansion` or `cmd /v:on`)
- The command is not within a parenthesized block on either side of a pipe
- The command is not a "naked" batch script (name without `CALL`, parentheses, or pipe)

For each token parsed during delayed expansion:

- If the token contains no `!` characters, it is passed through unchanged
- If the token contains `!`, each character is scanned left to right:
  - A `^` caret causes the next character to be taken literally (caret is removed)
  - An opening `!` begins a variable name search for the next `!`
  - Consecutive opening `!` marks collapse to a single `!`
  - Unpaired `!` marks are removed

!!! warning "Exclamation Marks in Filenames"
    When delayed expansion is enabled and a `FOR` loop iterates over files, any filename containing `!` will have that character consumed during delayed expansion. This occurs because parameter expansion (`%%A`) happens immediately before the delayed expansion phase.

---

## Overview

???+ note "What this page covers"
    This page documents the complete `cmd.exe` command-line parsing system including parser phases, the `FOR` command family with all variants, `findstr` pattern matching, `TYPE` file output, and the delayed expansion toggle pattern. These primitives form the [sHEL literal-safe processing pipeline](index.md). For the variable naming conventions used in these scripts, see [Haiku Numbersystem](haiku-numbersystem.md).

---

## FOR Command Family

### FOR /F — Text Parsing

`FOR /F` parses the output of a command, the content of a file, or a literal string, splitting each line into tokens based on delimiter characters.

```batch
REM Parse command output
FOR /F "delims=" %%A IN ('dir /b /a-d') DO echo %%A

REM Parse a file line by line
FOR /F "delims=" %%A IN (file.txt) DO echo %%A

REM Parse a file with specific delimiters
FOR /F "tokens=1,2 delims=: " %%A IN (hosts.txt) DO echo IP=%%A Host=%%B

REM Parse with skip (skip header lines)
FOR /F "skip=1 tokens=*" %%A IN (data.csv) DO echo %%A
```

### FOR /F Options

| Option | Syntax | Description |
|--------|--------|-------------|
| `delims` | `"delims=chars"` | Characters used to split lines into tokens |
| `tokens` | `"tokens=x,y-z,*"` | Which tokens to assign to variables (up to 31) |
| `skip` | `"skip=n"` | Number of lines to skip at start |
| `eol` | `"eol=char"` | Character marking end-of-line (comment) |
| `usebackq` | `"usebackq"` | Changes quote semantics (see below) |

### FOR /L — Numeric Iteration

```batch
REM Count from 1 to 10
FOR /L %%A IN (1,1,10) DO echo %%A

REM Count from 10 to 1 (decrement)
FOR /L %%A IN (10,-1,1) DO echo %%A

REM Step by 2
FOR /L %%A IN (0,2,100) DO echo %%A
```

### FOR /R — Recursive Directory

```batch
REM List all .txt files recursively
FOR /R "C:\path" %%A IN (*.txt) DO echo %%A
```

### FOR /D — Directory Names

```batch
REM List all subdirectories
FOR /D %%A IN (*) DO echo %%A
```

---

## findstr — Pattern Matching

`findstr` provides regular expression pattern matching for text files and command output. It is the primary filtering tool in `cmd.exe`.

### Basic Usage

```batch
REM Simple string search (case-insensitive)
findstr /I "search text" file.txt

REM Search multiple files
findstr /I "error" *.log

REM Search recursively
findstr /S /I "pattern" *.txt

REM Regex search (limited regex support)
findstr /R "^Start.*End$" file.txt

REM Invert match (lines NOT containing pattern)
findstr /V "exclude" file.txt

REM Match whole word only
findstr /W "word" file.txt

REM Line number output
findstr /N "pattern" file.txt

REM Only print filenames that contain match
findstr /M "pattern" *.txt
```

### findstr Options Reference

| Switch | Description |
|--------|-------------|
| `/B` | Match pattern at beginning of line |
| `/E` | Match pattern at end of line |
| `/L` | Use literal search strings (disable regex) |
| `/R` | Use search strings as regular expressions |
| `/S` | Search current directory and all subdirectories |
| `/I` | Case-insensitive search |
| `/V` | Print only lines that do NOT contain a match |
| `/N` | Print line numbers before each matching line |
| `/M` | Print only the filename if a file contains a match |
| `/O` | Print character offset before each matching line |
| `/F:file` | Read file list from specified file |
| `/C:string` | Use specified string as a literal search string |
| `/G:file` | Read search strings from specified file |

### Boolean Logic with findstr

```batch
REM AND logic: pipe multiple findstr commands
type file.txt | findstr /I "first" | findstr /I "second"
REM Only lines containing both "first" AND "second"

REM OR logic: multiple /C switches
type file.txt | findstr /I /C:"first" /C:"second"
REM Lines containing "first" OR "second"

REM NOT logic: use /V
type file.txt | findstr /V /I "exclude"
REM Lines NOT containing "exclude"
```

---

## TYPE — File Output

`TYPE` writes the content of a text file to stdout. It is the simplest method for reading file content in a pipeline.

```batch
REM Display file content
type file.txt

REM Pipe to findstr for filtering
type file.txt | findstr /I "pattern"

REM Append to another file (concatenation)
type file1.txt >> combined.txt
type file2.txt >> combined.txt

REM Redirect to clipboard
type file.txt | clip
```

!!! note "TYPE and Binary Files"
    `TYPE` is designed for text files. Using it on binary files may produce unpredictable output, particularly with control characters or byte sequences that the console interprets as terminal control codes. For binary operations, use PowerShell's `[IO.File]::ReadAllBytes()` or equivalent.

---

## String Manipulation

### Substring Extraction

```batch
REM Extract substring: %var:~start,length%
set "date=2024-01-15"
echo %date:~0,4%     REM 2024 (year)
echo %date:~5,2%     REM 01 (month)
echo %date:~8,2%     REM 15 (day)
echo %date:~-2%      REM 15 (last 2 chars)

REM With delayed expansion for dynamic indices
setlocal enabledelayedexpansion
set "str=Hello World"
set "start=6"
set "len=5"
echo !str:~%start%,%len%!   REM World
```

### String Replacement

```batch
REM Replace substring: %var:old=new%
set "path=C:\Users\Name\file.txt"
echo %path:\=/%        REM C:/Users/Name/file.txt

REM Remove substring: %var:old=%
echo %path:.txt=%        REM C:\Users\Name\file

REM Replace all occurrences
set "text=a,b,c,d"
echo %text:,=;+%         REM a;+b;+c;+d
```

---

## Delayed Expansion Toggle Pattern

When processing data that may contain exclamation marks, delayed expansion can be toggled on and off within a loop to prevent `!` characters from being consumed:

```batch
@echo off
SETLOCAL DisableDelayedExpansion
FOR /F "usebackq delims=" %%G IN ("data.txt") DO (
    SET "_line=%%G"
    SETLOCAL EnableDelayedExpansion
    ECHO !_line!
    ENDLOCAL
)
```

This pattern ensures that:
1. The `FOR /F` loop variable `%%G` captures the raw line without delayed expansion interference
2. The line is stored in a variable
3. Delayed expansion is enabled in a nested scope to safely output the variable
4. `ENDLOCAL` returns to the previous state for the next iteration

---

## Related Deep Hole

- [SS64: EnableDelayedExpansion reference](https://ss64.com/nt/delayedexpansion.html) — Primary reference for delayed expansion behavior
- [SS64 Forum: Delayed expansion phase discussion](https://ss64.org/viewtopic.php?t=27) — Jeb and Aacini on caret double-escaping with delayed expansion
- [SuperUser: How does delayed expansion work in a batch script?](https://superuser.com/questions/1569594) — Comprehensive parse phase documentation
- [Stack Overflow: Example of delayed expansion in batch file](https://stackoverflow.com/questions/10558316) — Before/after comparison with FOR loops
- [Server Fault: Double expansion with CALL](https://serverfault.com/questions/949759) — CALL statement for second expansion of numbered variables
- [Microsoft Docs: setlocal command](https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/setlocal) — Official Microsoft documentation
- [Raymond Chen: Environment variable expansion](https://devblogs.microsoft.com/oldnewthing/20060823-00/?p=29993) — Parse-time vs execution-time expansion explanation
- [TenForums: Batch file issue with EnableDelayedExpansion](https://www.tenforums.com/general-support/169953-batch-file-issue-related-enabledelayedexpansion.html) — Common IF-block confusion resolved
"""

let render() = file
