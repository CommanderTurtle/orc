module ConvertedFiles.Posts.N20251015MacrohardMd

let file = """---
layout: post
title: "macrohard: Not Your Average Macro Extension"
author: "CommanderTurtle"
date: 2025-10-15 10:00:00 +0000
tags: [project, automation, macros, tasket, cpp, react, typescript]
---

Task scheduling and macro automation on Windows has a reputation. The built-in Task Scheduler is powerful but opaque. AutoHotkey is flexible but its scripting language shows its age. Commercial tools are either enterprise-expensive or consumer-limited. And none of them give you a visual node editor where you can wire together IF/THEN/ELSE logic by dragging connections between blocks.

**macrohard** does. It's a complete rewrite and extension of Tasket++ with a ComfyUI-style node editor, checkpoint-based flow control, and a typed HTTP trigger daemon — turning repetitive desktop tasks into visual, composable workflows.

## What It Is

macrohard is a Visual Workflow Automation Platform for Tasket++. It extends [Amir Hammoutene's ScheduledPasteAndKeys](https://github.com/AmirHammouteneEI/ScheduledPasteAndKeys) (tested against v1.8) with three integrated components:

| Component | Stack | Purpose |
|-----------|-------|---------|
| **Daemon** | C++ | HTTP-triggered task execution engine |
| **Workflow Editor** | React + React Flow | Visual node-based workflow design |
| **PI Agent** | TypeScript | LLM-integrated automation agent |

## The Architecture

```
+---------------+     HTTP      +-----------------------+
| Android/Tasker| <-----------> |  tasket-httpd.exe     |
| Home Assistant|   port 7777   |  (C++ daemon)         |
| curl/any      |               |  - TaskExecutor*      |
|               |               |  - TaskRegistry       |
|               |               |  - cpp-httplib        |
+---------------+               +----------+------------+
                                           |
                                           | loads .scht
                                           v
                                +-----------------------+
                                |  Tasket++ Engine      |
                                |  (PasteAction,        |
                                |   KeysSequenceAction, |
                                |   SystemCommands,     |
                                |   CursorMovements,    |
                                |   RunningOtherTask)   |
                                +-----------------------+

+---------------+     HTTP      +-----------------------+
| Browser       | <-----------> |  Workflow Editor      |
| localhost:3000|               |  (React + React Flow) |
|               |               |  - Node editor        |
|               |               |  - Checkpoint editor  |
|               |               |  - Macro library      |
|               |               |  - Inline grid edit   |
|               |               |  - Copy/paste/delete  |
+---------------+               +----------+------------+
                                           |
                                           | JSON workflow
                                           v
                                +-----------------------+
                                |  PI Agent Extension   |
                                |  (@pi-extensions/     |
                                |   pi-tasket-http)     |
                                +-----------------------+
```

## The C++ Daemon

The daemon replaces Tasket++'s `TaskThread` with a `TaskExecutor` class (avoids the private `copyActionsList()` API). It uses `cpp-httplib` for HTTP serving and listens on port 7777 by default. Any HTTP client can trigger tasks — curl, Home Assistant, Tasker on Android, or the Workflow Editor itself.

The daemon loads `.scht` macro files from `saved_tasks/`, maintains a `TaskRegistry` of available entrypoints, and executes tasks through the Tasket++ engine. Actions include: paste operations, key sequences, system commands, cursor movements, and running other tasks as subroutines.

## The Workflow Editor

Built with React and React Flow, the editor provides a ComfyUI-inspired canvas where workflows are graphs, not scripts. Five custom node types:

- **EntrypointNode** — Inline value editing (string, bool, float)
- **DataGridNode** — Inline 3×3 cell editing for tabular data
- **CheckpointNode** — IF/THEN/ELSE branching logic
- **MacroNode** — References saved `.scht` macro files
- **OutputNode** — Terminal actions and result capture

The checkpoint system is the killer feature. Traditional macro tools run linearly. macrohard's checkpoints let you branch: *IF* window title contains "Error", *THEN* click dismiss, *ELSE* proceed. The graph traversal engine in `workflowEngine.ts` handles the full execution flow with cycle detection and subgraph isolation.

Keyboard shortcuts, copy/paste/delete, and a macro library with drag-and-drop placement make the editor feel like a native application. Zustand manages state with a full undo/redo stack.

## The PI Agent

The `@pi-extensions/pi-tasket-http` TypeScript package provides 6 PI (Programmable Intelligence) tool registrations that let an LLM agent interact with the macrohard system. The agent can: list available tasks, trigger execution, read grid data, modify entrypoints, and query execution status — all through typed HTTP calls to the daemon.

This means you can tell an LLM "run my morning setup routine" and it will: query the available tasks, find `morning-setup.scht`, trigger it via HTTP, and report back what happened.

## Installation

One PowerShell command as Administrator:

```powershell
git clone https://github.com/CommanderTurtle/macrohard
cd macrohard

# Also clone the original Tasket++ source (required for daemon build)
git clone https://github.com/AmirHammouteneEI/ScheduledPasteAndKeys.git original

# Apply the one-line patch
copy daemon\patches\Task.h.patch original\
cd original && git apply Task.h.patch && cd ..

# Install everything
.\install.ps1 -QtPath "C:\Qt\6.9.3\mingw_64"
```

Prerequisites: Qt 6.9.3 (MinGW or MSVC), CMake 3.16+, bun.

Run everything with `.\run.ps1` — starts both the daemon and workflow editor. Or `.\run.ps1 daemon` for daemon-only.

## Repository Layout

```
macrohard/
├── README.md
├── install.ps1              # One-click Windows installer
├── run.ps1                  # Runtime launcher
├── .tasketconfig.json       # Generated config
│
├── original/                # Tasket++ source (patched)
│
├── daemon/                  # C++ HTTP daemon
│   ├── CMakeLists.txt
│   ├── patches/Task.h.patch
│   ├── include/             # Headers
│   ├── src/                 # C++ sources
│   ├── saved_tasks/         # .scht macro files
│   └── test/                # Python API validation (63 tests)
│
├── workflows/               # React workflow editor
│   └── src/
│       ├── types/workflow.ts
│       ├── engine/checkpoint.ts
│       ├── engine/workflowEngine.ts
│       ├── stores/workflowStore.ts
│       └── components/nodes/
│
├── pi-extension/            # PI Agent
│   └── src/
│       ├── client/tasket-client.ts
│       ├── tools/tasket-http.ts
│       └── skills/
│
└── docs/
    ├── INSTALL.md
    ├── API.md
    ├── PI_AGENT.md
    └── ARCHITECTURE.md
```

64% C++, 29.8% TypeScript, 2.4% PowerShell. GPL-3.0 licensed.

macrohard turns the tedious into the visual. If ComfyUI made ML model pipelines tangible, macrohard does the same for desktop automation.

[github.com/CommanderTurtle/macrohard](https://github.com/CommanderTurtle/macrohard)
"""

let render() = file
