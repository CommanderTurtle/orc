module ConvertedFiles.Docs.Projects.MacrohardMd

let file = """# Macrohard

Macrohelp is a workflow automation platform that extends Tasket++ with IF/THEN/ELSE checkpoint branching, and a typed HTTP trigger daemon. It is a complete extension of [AmirHammouteneEI/ScheduledPasteAndKeys](https://github.com/AmirHammouteneEI/ScheduledPasteAndKeys "original source code for Tasket++"){:rel="noopener noreferrer" target="blank"} — built in qt

My links on GitHub:

- [CommanderTurtle/macrohelp](https://github.com/CommanderTurtle/macrohelp "CommanderTurtle/macrohelp"){:rel="noopener noreferrer" target="blank"}
- [[Macrohard editor]](https://app.shel.sh/macro "open-source node editor"){:rel="noopener noreferrer" target="blank"}
    - [Source Code](https://github.com/CommanderTurtle/orc/tree/main/app/macro){:rel="noopener noreferrer" target="blank"}

---

## Overview

???+ note "What this page covers"
    Macrohelp is a lightweight, technical utility suite designed to enhance the **Tasket++** automation environment. It consists of a high-performance Win32 overlay runtime (~300kb) and a Qt-based HTTP sidecar daemon. Together, they bridge the gap between human intent (hotkeys, coordinate selection, and visual feedback) and programmatic execution within Tasket++.

    The system specializes in coordinate capture, paste buffer management, and complex "Zone Flow" math, translating these actions into native Tasket `.scht` schedules that are executed by the Tasket engine

---

## Architecture

Macrohelp consists of three integrated components that form a complete automation ecosystem:

*[three]: mermaid extrated from deepwiki via Copilot <br> side note..<br>maybe good use of M365 copilot?

### Buffered pastes as runtime variables
```mermaid
flowchart TD
    %% Input Layer
    subgraph InputLayer["Input Layer"]
        A1["Shift+Alt+9 (Hotkey)"]
        A2["LowLevelKeyboardProc"]
        A2 -->|Capture Z/X/C/V| B1["IDD_PASTE_BUFFERS"]
        A1 -->|Triggers| B1
    end

    %% Buffer Management
    subgraph BufferManagement["Buffer Management (PasteB)"]
        B2["Buffer Z: Snip + Copy"]
        B3["Buffer X: Multi-line"]
        B4["Buffer C: Single-line"]
        B5["Buffer V: Zone + Copy"]
        B1 --> B2
        B1 --> B3
        B1 --> B4
        B1 --> B5
    end

    %% BuildPasteActionJson for each buffer
    B2 --> C1["BuildPasteActionJson"]
    B3 --> C2["BuildPasteActionJson"]
    B4 --> C3["BuildPasteActionJson"]
    B5 --> C4["BuildPasteActionJson"]

    %% Emission Subsystem
    subgraph EmissionSubsystem["Emission Subsystem"]
        D1["Tasket JSON Action"]
        D2["AppendActionAndWait"]
        D3["clicksession.txt"]
        D1 --> D2 --> D3
    end

    %% Connect BuildPasteActionJson to EmissionSubsystem
    C1 --> D1
    C2 --> D1
    C3 --> D1
    C4 --> D1
```

---

### The assembly layer
```mermaid
flowchart TD
    %% Natural Language Layer
    subgraph NaturalLanguageSpace["Natural Language Space"]
        NL1["User Input String: '{powershell}'"]
    end

    %% Code Entity Extraction
    subgraph CodeEntitySpace["Code Entity Space"]
        CE1["ExtractRegistryHubTokens()"]
    end

    NL1 --> CE1

    %% Token Loop Decision
    D1{"Token Loop"}

    CE1 --> D1

    %% Branch 1: PowerShell Tokens
    subgraph PowerShellBranch["Branch: Is PowerShell"]
        PS1["CompileRegistryHubToken(t)"]
        PS2["ShellExecuteExW / PowerShe"]
    end

    D1 -->|Is PowerShell| PS1 --> PS2

    %% Branch 2: Paste Tokens
    subgraph PasteBranch["Branch: Is Paste"]
        P1["CompileRegistryHubToken(t)"]
        P2["g_pasteBuffers[idx]"]
    end

    D1 -->|Is Paste| P1 --> P2

    %% Branch 3: If/Conditional Tokens
    subgraph IfBranch["Branch: Is If"]
        IF1["EvaluateTasketDaemonCond"]
        IF2["WinHttp (GET /grid or /entry)"]
    end

    D1 -->|Is If| IF1 --> IF2

    %% Convergence: String Assembly
    SC["String Concatenation"]

    PS2 --> SC
    P2 --> SC
    IF2 --> SC

    %% Task Scheduling + HTTP Emission
    S1["ScheduleTasketTempTask()"]
    H1["tasket-httpd: POST /temp-ta"]

    SC --> S1 --> H1
```

---

### The qt http layer
```mermaid
flowchart TD
    %% Natural Language Layer
    subgraph NaturalLanguageSpace["Natural Language Space"]
        NL1["User triggers Macro"]
        NL2["Waiting for Delay"]
        NL3["Macro Executing"]
        NL4["Macro Complete"]
    end

    %% Code Entity Layer
    subgraph CodeEntitySpace["Code Entity Space"]
        CE1["POST /run"]
        CE2["struct TaskInstance"]
        CE3["TaskState::Idle"]
        CE4["TaskRegistry::addTask()"]
        CE5["TaskState::Scheduled"]
        CE6["Timer Expired"]
        CE7["TaskState::Running"]
        CE8["TaskState::Finished"]
        CE9["TaskState::Stopped"]
        CE10["TaskState::Failed"]
        CE11["class TaskRegistry"]
        CE12["class TaskExecutor"]
    end

    %% Flow connections
    NL1 --> CE1
    CE1 --> CE3
    CE2 --> CE3
    CE3 --> CE4
    CE4 --> CE5
    CE5 --> CE6
    CE6 --> CE7
    CE12 --> CE7

    %% Outcomes
    CE7 -->|Success| CE8
    CE7 -->|User Stop| CE9
    CE7 -->|Error| CE10

    %% Supporting entities
    CE11 --> CE4
```

---

## Components and more can be read on the [deepwiki](https://deepwiki.com/CommanderTurtle/macrohelp){:rel="noopener noreferrer" target="blank"}

### Installation instructions:

The installation utilizes an automated build helper `ps1` file. For those of you who like hacking, the flow automates an install checklist before attempting to pull qt, then builds & deletes the local qt folder (same dir portable install).

```mermaid
flowchart TD
    %% External Sources
    subgraph ExternalSources["External_Sources"]
        ES1["aqtinstall (Qt6)"]
        ES2["Tasket++ Git Repo"]
    end

    %% Local Build Environment
    subgraph LocalBuildEnv["Local_Build_Environment"]
        L1["build.ps1"]
        L2["_qt6-build-cache"]
        L3["original/ (Tasket++ Source)"]
        L4["Task.h.patch"]
        L5["install-qt"]
        L6["git clone"]
        L7["git apply"]
    end

    %% Build Artifacts
    subgraph BuildArtifacts["Build_Artifacts"]
        B1["CMake / MSVC"]
        B2["tasket-httpd.exe"]
        B3["windeployqt.exe"]
        B4["verify-runtime-layout.ps1"]
    end

    %% External to Local
    ES1 -->|install-qt| L2
    ES2 -->|git clone| L3
    L4 -->|git apply| L3

    %% Local to Build Artifacts
    L2 -->|CMAKE_PREFIX_PATH| B1
    L3 -->|TASKETPP_ROOT| B1
    B1 -->|compile| B2
    B2 -->|bundle DLLs| B3
    B3 -->|input| B2
    B2 -->|check| B4

    %% Feedback loop
    B1 -->|Build_Artifacts| L1
```

#### Guided install:

Clone repo
```powershell
cd ~/Documents
git clone https://github.com/CommanderTurtle/macrohelp build
cd build
```

??? info "Build the daemon with automated qt compatibility"
    ```powershell
    cd tasket-http-daemon
    ```
    ```powershell
    .\build.ps1 --dry-run
    ```
    After..
    ```powershell
    .\build.ps1
    ```

??? info "Build the overlay"
    ```powershell
    cd macrohelp-runtime/source
    ```
    ```powershell
    cmake -S . -B build-vs2026 -G "Visual Studio 18 2026" -A x64
    ```
    ```powershell
    cmake --build build-vs2026 --config Release
    ```

Running:

!!! info "Overlay"
    Go to dir
    ```powershell
    cd macrohelp-runtime/source
    ```
    Run from source folder
    ```powershell
    .\build-vs2026\bin\Release\CursorOverlay.exe
    ```
    End when done
    ```powershell
    Get-Process CursorOverlay -ErrorAction SilentlyContinue | Stop-Process -Force
    ```

!!! info "httpd"
    Go to dir
    ```powershell
    cd tasket-http-daemon
    ```
    Run
    ```powershell
    .\build-msvc\Release\tasket-httpd.exe --port 7777 --bind 127.0.0.1 --dir "$env:APPDATA\Tasket++\saved_tasks" --default-delay 1
    ```
    `ctrl+c` or killing that window will end server

??? question "Configuring the scaling"
    ## Adjust DPI manually (if needed, 4k defaults to 2+)
    ```powershell
    $env:MACROHELP_UI_SCALE = "2.25"
    Start-Process "C:\..path\to\CursorOverlay.exe\
    ```
    For persistance:
    ```powershell
    [Environment]::SetEnvironmentVariable("MACROHELP_UI_SCALE", "2.25", "User")
    # Then restart. To fully remove it later:
    [Environment]::SetEnvironmentVariable("MACROHELP_UI_SCALE", $null, "User")
    ```
    Ending:
    ```powershell
    Get-Process CursorOverlay -ErrorAction SilentlyContinue | Stop-Process -Force
    ```

---

### Related pages:
- [Regedited GitHub Repository](./regedited.md){ data-preview } — Source code and documentation
- [CMD](../xml-project/index.md){ data-preview } — Reproducable format for boolean if-then in C
- [Gemma](./nvfp4.md){ data-preview } — Document on powershell oneliner harnessing a local agent
- [Automation](./automate.md){ data-preview } — Document on automation tooling
- [pi.dev Packages](https://pi.dev/packages){:rel="noopener noreferrer" target="blank"} — PI agent registry"""

let render() = file
