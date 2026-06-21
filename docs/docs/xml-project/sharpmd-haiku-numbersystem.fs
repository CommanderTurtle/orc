module ConvertedFiles.Docs.XmlProject.HaikuNumbersystemMd

let file = """# Haiku Numbersystem Variable Rules

The Haiku Numbersystem is a variable naming convention for `cmd.exe` batch scripts designed to avoid conflicts with reserved words, environment variables, and the delayed expansion parser. The name derives from the constraint-based structure: variable names follow a fixed syllabic pattern similar to haiku poetry (5-7-5), enforcing short, non-conflicting identifiers that are easy to track across nested FOR loops and macro calls.

---

## Overview

???+ note "What this page covers"
    This page documents the Haiku Numbersystem variable naming convention:

    - **Naming Convention** — Project-specific prefix pattern with semantic descriptors
    - **Forbidden Names** — Reserved words, dynamic variables, environment variables
    - **Delayed Expansion Safety** — Characters to avoid in variable names
    - **Scope Management** — SETLOCAL/ENDLOCAL boundaries
    - **Indexed Variables** — Array simulation via naming convention

    For cmd.exe parser behavior and delayed expansion, see [cmd.exe Literacy](cmd-literacy.md). For clipboard automation patterns, see [Clipboard Automation](clipboard-automation.md).

---

## Naming Convention

### Prefix Pattern

All user-defined variables use a project-specific prefix followed by a semantic descriptor. This prevents collision with:

- Windows environment variables (`PATH`, `TEMP`, `USERPROFILE`, etc.)
- `cmd.exe` dynamic variables (`CD`, `DATE`, `TIME`, `ERRORLEVEL`, `RANDOM`, `CMDEXTVERSION`, `CMDCMDLINE`)
- Common utility variables (`_var`, `__tmp`, etc. that other scripts may export)

```batch
REM sHEL project prefix: sh_
set "sh_count=0"
set "sh_name=default"
set "sh_buffer="

REM Nested loop counters use ordinal suffixes
set "sh_i_1=0"
set "sh_i_2=0"
set "sh_i_3=0"
```

### Loop Variable Mapping

FOR loop variables (`%%A` through `%%Z`) are mapped to descriptive names immediately upon capture:

```batch
FOR /F "delims=" %%A IN ('command') DO (
    set "sh_line=%%A"
    REM All further processing uses !sh_line! (delayed expansion)
)
```

---

## Forbidden Names

The following categories of names must never be used for user variables:

### cmd.exe Reserved Words

`CALL`, `ECHO`, `ENDLOCAL`, `FOR`, `GOTO`, `IF`, `NOT`, `SET`, `SETLOCAL`, `SHIFT`

### Dynamic Variables (Read-Only)

| Variable | Content | Example |
|----------|---------|---------|
| `%CD%` | Current directory | `C:\Users\Name` |
| `%DATE%` | Current date | `Mon 01/15/2024` |
| `%TIME%` | Current time | `14:30:45.12` |
| `%RANDOM%` | Random 0-32767 | `18473` |
| `%ERRORLEVEL%` | Exit code of last command | `0`, `1`, `9009` |
| `%CMDEXTVERSION%` | Command extensions version | `2` |
| `%CMDCMDLINE%` | Original command line | `cmd /c script.bat` |
| `%HIGHESTNUMANODENUMBER%` | NUMA node count | `0` |

### Environment Variables (Common)

`ALLUSERSPROFILE`, `APPDATA`, `COMPUTERNAME`, `HOMEDRIVE`, `HOMEPATH`, `LOCALAPPDATA`, `LOGONSERVER`, `NUMBER_OF_PROCESSORS`, `OS`, `PATHEXT`, `PROCESSOR_ARCHITECTURE`, `PROGRAMDATA`, `PROGRAMFILES`, `PROGRAMFILES(X86)`, `PUBLIC`, `SYSTEMDRIVE`, `SYSTEMROOT`, `TEMP`, `TMP`, `USERDOMAIN`, `USERNAME`, `USERPROFILE`, `WINDIR`

---

## Delayed Expansion Safe Names

When delayed expansion is enabled, variable names must not contain exclamation marks (the expansion delimiter). Additionally, names should avoid characters that complicate the parser:

```mermaid
flowchart TD
    subgraph Safe["Safe Names"]
        direction TB
        S1["sh_var"]
        S2["sh_count_1"]
        S3["sh_buffer_tmp"]
    end

    subgraph Unsafe["Unsafe Names"]
        direction TB
        U1["var!name<br/>(! triggers expansion)"]
        U2["var(name)<br/>(parentheses break)"]
        U3["var&name<br/>(& is command sep)"]
        U4["var,name<br/>(, is parameter sep)"]
    end

    style Safe fill:#7ed321
    style Unsafe fill:#d0021b
```

| Safe | Unsafe | Reason |
|------|--------|--------|
| `sh_var` | `var!name` | `!` triggers delayed expansion |
| `sh_var` | `var(name)` | Parentheses break substitution |
| `sh_var` | `var&name` | `&` is command separator |
| `sh_var` | `var,name` | `,` is parameter separator |

---

## Scope Management

Variables should be localized with `SETLOCAL` to prevent leaking into the parent environment:

```batch
@echo off
set "sh_global=visible everywhere"

REM Subroutine with local scope
CALL :Subroutine
REM sh_local no longer exists here
echo %sh_global%        REM Works
echo %sh_local%         REM Empty (undefined)

:Subroutine
SETLOCAL
set "sh_local=only here"
echo %sh_global%        REM Works (parent visible to child)
ENDLOCAL
exit /b
```

---

## The Numbersystem

For numbered variable series (arrays simulated via naming):

```batch
REM Indexed naming: prefix_category_index
set "sh_file_1=readme.txt"
set "sh_file_2=config.ini"
set "sh_file_3=data.csv"

REM Access via delayed expansion and CALL double expansion
setlocal enabledelayedexpansion
set "sh_idx=2"
CALL echo File %%sh_file_%sh_idx%%%    REM Outputs: config.ini
```

The `CALL` statement forces a second expansion pass, resolving `%%sh_file_2%%` to the variable's value. This is the only reliable method for indirect variable access in `cmd.exe`.

---

## Related Pages

- [cmd.exe Literacy](cmd-literacy.md) — Parser phases, delayed expansion, FOR/F
- [Clipboard Automation](clipboard-automation.md) — Macros and file operations

## Related Deep Hole

- [SS64: Set variable reference](https://ss64.com/nt/set.html) — cmd.exe variable syntax and expansion rules
- [SS64: EnableDelayedExpansion](https://ss64.com/nt/delayedexpansion.html) — Delayed expansion behavior with variable names
- [Stack Overflow: List of cmd.exe environment variables](https://stackoverflow.com/questions/659647) — Comprehensive list of Windows environment variables
- [Microsoft Docs: Cmd.exe environment variables](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/set_1) — Official documentation
"""

let render() = file
