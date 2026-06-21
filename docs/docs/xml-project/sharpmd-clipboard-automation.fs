module ConvertedFiles.Docs.XmlProject.ClipboardAutomationMd

let file = """# Clipboard Automation

The Windows clipboard serves as an intermediate data store for transferring text between applications and command-line sessions. The `clip` command redirects stdin to the clipboard; PowerShell's `Get-Clipboard` and `Set-Clipboard` provide bidirectional access. This section documents the exact patterns for clipboard integration within `cmd.exe` batch processing pipelines.

---

## Overview

???+ note "What this page covers"
    This page documents clipboard integration patterns for `cmd.exe` and PowerShell:

    - **clip Command** — Writing stdin to the clipboard from batch scripts
    - **Reading Clipboard** — Get-Clipboard and cmd.exe integration
    - **Boolean Logic** — findstr filtering with clip redirection
    - **CMD Macros** — Subroutine-like constructs with argument handling
    - **Tee Pattern** — Simultaneous output to console, file, and clipboard
    - **File Operations** — Line filtering, counting, and concatenation
    - **GitHub API** — Repository enumeration via PowerShell

    For cmd.exe parser behavior and delayed expansion, see [cmd.exe Literacy](cmd-literacy.md). For variable naming conventions, see [Haiku Numbersystem](haiku-numbersystem.md).

---

## clip Command

`clip.exe` is a built-in Windows utility that copies stdin to the clipboard. It accepts piped input and overwrites the clipboard contents.

```mermaid
flowchart LR
    subgraph Sources["Input Sources"]
        direction TB
        S1["echo text | clip"]
        S2["type file.txt | clip"]
        S3["dir /b | clip"]
        S4["!var! | clip<br/>(delayed expansion)"]
    end

    subgraph CLIP["clip.exe"]
        C["Windows Clipboard"]
    end

    subgraph Destinations["Read Destinations"]
        direction TB
        D1["Ctrl+V<br/>(GUI apps)"]
        D2["Get-Clipboard<br/>(PowerShell)"]
        D3["FOR /F<br/>(cmd.exe)"]
    end

    Sources --> CLIP --> Destinations

    style CLIP fill:#4a90d9
```

```batch
REM Copy text to clipboard
echo Hello World | clip

REM Copy file content to clipboard
type file.txt | clip

REM Copy command output to clipboard
dir /b | clip

REM Copy with delayed expansion output
setlocal enabledelayedexpansion
set "result=computed value"
echo !result! | clip
```

!!! note "Clipboard Overwrite Behavior"
    `clip` always replaces the entire clipboard contents. It does not append. There is no native `cmd.exe` mechanism for reading clipboard content; use PowerShell's `Get-Clipboard` for that operation.

---

## Reading Clipboard Content

PowerShell provides the `Get-Clipboard` cmdlet for reading clipboard data:

```powershell
# Read text from clipboard
Get-Clipboard

# Read and assign to variable
$text = Get-Clipboard

# Read as file paths (when Explorer copies files)
$files = Get-Clipboard -Format FileDropList

# Read as image
$image = Get-Clipboard -Format Image
$image.Save("clipboard_image.png")
```

From `cmd.exe`, clipboard reading requires PowerShell invocation:

```batch
REM Read clipboard into environment variable
FOR /F "usebackq delims=" %%A IN (`powershell -NoP -C "Get-Clipboard"`) DO SET "clipboard=%%A"

REM Read clipboard and process with findstr
powershell -NoP -C "Get-Clipboard" | findstr /I "pattern"
```

---

## Boolean Logic with Clipboard

The combination of `findstr` filtering and `clip` redirection enables conditional clipboard operations:

```batch
REM Only copy lines matching a pattern
type log.txt | findstr /I "ERROR" | clip

REM Copy lines matching any of several patterns
type log.txt | findstr /I /C:"ERROR" /C:"WARN" /C:"FAIL" | clip

REM Exclude lines matching a pattern, then copy to clipboard
type log.txt | findstr /V /I "DEBUG" | clip

REM Complex filter: include ERROR but exclude known-false positives
type log.txt | findstr /I "ERROR" | findstr /V /I "benign_error_123" | clip
```

---

## CMD Macros

CMD macros are subroutine-like constructs defined using `:label` syntax and invoked with `CALL :label`. They enable reusable code blocks within a single batch file.

### Defining a Macro

```batch
@echo off
setlocal enabledelayedexpansion

REM Main script
CALL :ProcessFile "input.txt" "output.txt"
if %errorlevel% neq 0 echo Processing failed
exit /b

REM Macro definition
:ProcessFile
set "infile=%~1"
set "outfile=%~2"
if not exist "%infile%" exit /b 1

for /f "usebackq delims=" %%A in ("%infile%") do (
    set "line=%%A"
    set "line=!line:old=new!"
    echo !line! >> "%outfile%"
)
exit /b 0
```

### Macro Arguments

| Modifier | Meaning |
|----------|---------|
| `%~1` | Argument 1, quotes removed |
| `%~f1` | Full path of file in argument 1 |
| `%~d1` | Drive letter only |
| `%~p1` | Path only (no drive, no filename) |
| `%~n1` | Filename only (no extension) |
| `%~x1` | Extension only |
| `%~s1` | Short (8.3) path |
| `%~a1` | File attributes |
| `%~t1` | Modification date/time |
| `%~z1` | File size |

---

## Tee Pattern — Print, Log, and Clipboard

The "tee" pattern (named after the Unix `tee` command) simultaneously outputs data to the console, a file, and the clipboard. In `cmd.exe`, this requires a multi-step approach since native tee functionality is limited.

### Basic Tee Using Temporary File

```batch
@echo off
setlocal
set "tempfile=%TEMP%\tee_%RANDOM%.tmp"

REM Step 1: Capture output to temp file
(
    echo === System Information ===
    echo Date: %date% %time%
    echo.
    echo Environment:
    set
) > "%tempfile%"

REM Step 2: Display to console
type "%tempfile%"

REM Step 3: Append to log file
type "%tempfile%" >> "session.log"

REM Step 4: Copy to clipboard
type "%tempfile%" | clip

REM Cleanup
del "%tempfile%"
```

### Tee Using PowerShell (Single Pipeline)

```powershell
# PowerShell provides Tee-Object for native tee behavior
Get-Process | Tee-Object -FilePath "processes.txt" | Set-Clipboard

# Equivalent: output to console, file, and clipboard simultaneously
"Output text" | Tee-Object -FilePath "log.txt" | Set-Clipboard
```

---

## File Tree Concatenation

A common operation is concatenating multiple files into a single combined document, often with code fencing for markdown compatibility:

```batch
@echo off
setlocal enabledelayedexpansion

REM Create combined file with code fences
> combined.txt (
    for /r %%F in (*.cmd *.bat *.ps1) do (
        echo # %%~nF
        echo ```batch
        type "%%F"
        echo ```
        echo.
    )
)
```

### PowerShell Variant

```powershell
# Concatenate with markdown code fences
Get-ChildItem -Recurse -Filter "*.ps1" | ForEach-Object {
    "# $($_.Name)"
    "```powershell"
    Get-Content $_.FullName
    "```"
    ""
} | Set-Content "combined.md"
```

---

## Text File Operations

### Line Filtering and Deletion

```batch
REM Delete lines matching a pattern (output to new file, delete original)
type input.txt | findstr /V /I "DELETE_ME" > temp.txt
move /y temp.txt input.txt

REM Keep only lines matching a pattern
type input.txt | findstr /I "KEEP" > filtered.txt

REM Filter blank lines
type input.txt | findstr /R "." > no_blanks.txt

REM Filter comment lines
type input.txt | findstr /V /B "#" > no_comments.txt
```

### Line Counting

```batch
REM Count lines in a file
FOR /F %%A IN ('type file.txt ^| find /c /v ""') DO SET "lines=%%A"
REM Note: find /c /v "" counts all lines including blanks

REM Count lines matching a pattern
FOR /F %%A IN ('type file.txt ^| find /c /I "pattern"') DO SET "matches=%%A"
```

---

## GitHub API Scraping

PowerShell can interact with the GitHub API for repository enumeration and file download:

```powershell
# List branches for a repository
$api = "https://api.github.com/repos/username/repo/branches"
$branches = Invoke-RestMethod -Uri $api -Headers @{
    "Accept" = "application/vnd.github.v3+json"
    "User-Agent" = "sHEL"
}
$branches | ForEach-Object { $_.name }

# Download repository archive
$url = "https://github.com/username/repo/archive/refs/heads/main.zip"
Invoke-WebRequest -Uri $url -OutFile "repo.zip"
Expand-Archive -Path "repo.zip" -DestinationPath "./repo"

# Get repository contents
$contents = Invoke-RestMethod -Uri "https://api.github.com/repos/username/repo/contents/"
$contents | Select-Object name, type, download_url
```

---

## Related Pages

- [cmd.exe Literacy](cmd-literacy.md) — Parser phases, FOR/F, delayed expansion
- [Haiku Numbersystem](haiku-numbersystem.md) — Variable naming conventions
- [Base64 Encoding](base64.md) — Encoding for clipboard-safe data transport

## Related Deep Hole

- [Stack Overflow: How to use the Windows clipboard from cmd.exe](https://stackoverflow.com/questions/9785508) — clip.exe usage patterns and limitations
- [Stack Overflow: Get clipboard content in batch file](https://stackoverflow.com/questions/61653035) — PowerShell Get-Clipboard from cmd
- [Stack Overflow: Tee command in Windows](https://stackoverflow.com/questions/796476) — Implementing tee in cmd vs PowerShell
- [SS64: clip command reference](https://ss64.com/nt/clip.html) — Official SS64 documentation
- [SS64: CALL command reference](https://ss64.com/nt/call.html) — Macro argument modifier syntax
- [Stack Overflow: Batch file function with return value](https://stackoverflow.com/questions/673718) — Errorlevel-based return patterns
"""

let render() = file
