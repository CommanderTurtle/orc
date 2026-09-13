module Bl0g.Posts.N20260611MacrohardMd

let file = """---
layout: post
title: "macrohard & macrohelp: Not Your Average Macro Extension"
author: "CommanderTurtle"
date: 2026-06-11 04:00:00 +0000
tags: [project, automation, macros, tasket, cpp, react, typescript]
---

Desktop macro automation on Windows has a reputation problem. Task Scheduler is powerful but opaque, AutoHotkey is flexible but its scripting language shows its age, and the commercial tools are either enterprise-priced or consumer-limited. None of them give you a visual node editor where you wire IF/THEN/ELSE logic by dragging connections between blocks — because they all assume your automation is a *sequence*.

**macrohard** breaks that assumption. It is a Visual Workflow Automation Platform for [Tasket++](https://github.com/AmirHammouteneEI/ScheduledPasteAndKeys) (Amir Hammoutene's ScheduledPasteAndKeys, tested against v1.8), inspired by ComfyUI: a C++ HTTP trigger daemon, a React Flow workflow editor, and a TypeScript agent layer that lets an LLM drive the whole thing. The repo tagline, which I stopped explaining away a long time ago: *not your average macro extension.*

This is the full account as of the June 13 sync: 13 commits in roughly two and a half hours over one overnight session, plus **macrohelp**, the runtime harness split off into its own repo five days later.

## One Night, Three Components

The macrohard burst runs from `Initial commit` on June 11 at 23:58 to `Sync to Tasket 1.8` on June 13 at 03:36. Everything shipped inside that window:

| Component | Stack | Purpose |
|-----------|-------|---------|
| **Daemon** (`tasket-httpd`) | C++ | HTTP-triggered task execution engine |
| **Workflow Editor** | React + React Flow | Visual node-based workflow design |
| **PI Agent** | TypeScript | LLM-integrated automation agent |

Language mix on the repo: 64% C++, 29.8% TypeScript, 2.4% PowerShell. GPL-3.0, same as upstream; `cpp-httplib` is MIT.

## Two Repos, Two Names

The naming looks accidental, so here is the straight version. macrohard started out as the entire platform — daemon, editor, agent, installers, docs. Five days after the overnight burst, on June 16, the runtime side got its own repo: **macrohelp**, "a developer's best friend" — a ~300kb overlay harness around a running Tasket instance, focused on QoL, coordinate capture, buffers, and zone math. macrohard stayed the platform; macrohelp became the hands-on-the-glass layer. Both tracked the same upstream — Tasket++ v1.8 first, then 1.9 on July 2, then v2.0 on July 17 — so the split was a packaging decision, not a divergence.

The state of play today: the workflow editor is hosted live at [app.shel.sh/macro](https://app.shel.sh/macro) (source under the orc repo, plain rendering to text files, all local JS), and the documentation moved to [docs.shel.sh/projects/macrohard](https://docs.shel.sh/projects/macrohard). The project did not die in two repos; it consolidated into the sHEL orbit and kept shipping.

## The C++ Daemon

The daemon is a natively built sidecar for a running Tasket instance. The load-bearing design choice is that it **replaces Tasket++'s `TaskThread` with a `TaskExecutor` class** — the old path reached into the private `copyActionsList()` API, and a friend patch (`daemon/patches/Task.h.patch`, one line applied to the upstream source) made the executor the clean way in. Serving is `cpp-httplib` on port 7777, any client works — curl, Home Assistant, Tasker on Android, or the editor itself:

| Endpoint | What it does |
|----------|--------------|
| `GET /tasks` | List available tasks from the registry |
| `GET /run?task=HelloWorld` | Schedule a task with its default delay from the `.scht`; returns a numbered confirmation (`'HelloWorld' scheduled to run in 10s : success`) |
| `GET /check?id=1` | Poll status for a scheduled task number |
| `POST /entrypoint` | Set a workflow entrypoint value (`{"id": "ep1", "value": "hello world", "type": "string"}`) |
| `POST /grid` | Set a data-grid cell (`{"id": "grid-0", "value": "42"}`) |

The daemon loads `.scht` macro files from `saved_tasks/`, maintains a `TaskRegistry` of available entrypoints, and executes through the Tasket++ engine: paste operations, key sequences, system commands, cursor movements, and running other tasks as subroutines. Version 2.1.1 synced the last upstream fix wave — the infinite-loop guard (`loop != 0` check), negative loop value handling in native execution, and parameter validation on both GET and POST `/run`. The `daemon/test/` directory carries 63 Python API validation tests, which is how "it works" stays true instead of becoming a memory.

Install is one PowerShell pass as Administrator: clone macrohard, clone Tasket++ as `original/`, apply the patch, `.\install.ps1 -QtPath "C:\Qt\6.9.3\mingw_64"` — prerequisites Qt 6.9.3 (MinGW or MSVC), CMake 3.16+, bun. `.\run.ps1` starts daemon and editor together.

## The Workflow Editor

Built with React and React Flow, the editor treats workflows as graphs, not scripts. Five custom node types:

- **EntrypointNode** — inline value editing (string, bool, float); click the value area and type
- **DataGridNode** — a 3×3 cell grid with inline editing (Enter saves, Escape cancels)
- **CheckpointNode** — IF/THEN/ELSE branching with AND/OR/XOR logic, edited in the sidebar
- **MacroNode** — references a saved `.scht` macro file
- **OutputNode** — terminal actions and result capture

The checkpoint system is the reason the project exists. Traditional macro tools run linearly; a checkpoint branches — *IF* window title contains "Error", *THEN* click dismiss, *ELSE* proceed — and the traversal engine in `workflowEngine.ts` handles cycle detection and subgraph isolation. A graph that can express a decision is a fundamentally different tool than a list that cannot.

The UX is the ComfyUI inheritance, taken seriously: undo/redo history (Zustand-backed), a just-start-typing command palette, floating node action buttons (copy/duplicate/delete), and a keyboard-first surface — Ctrl+Z undo, Ctrl+Y or Ctrl+Shift+Z redo, Ctrl+D duplicate, Delete removes, Ctrl+S saves. Persistence uses two mechanisms, one format: auto-save every 3 seconds to `localStorage` (per-workflow keys plus an index for the welcome screen), and manual export that downloads a round-trip-safe JSON file — `{id, name, version, nodes, edges, viewport, createdAt, updatedAt}` — where every node, edge, condition, grid cell, and viewport position survives an export-import cycle identically. A defensive cleaner strips internal UI fields before export, loading works from the welcome screen, an Open File button, or dragging a `.json` straight onto the canvas. And when the daemon is down, the editor falls back to native execution rather than refusing to work.

Version history, honestly compressed: 1.0.0 proof-of-concept → 1.7.1 typed API with task numbering, configurable delays, and `/check` → 1.7.2 TaskExecutor replaces TaskThread with a signal-safe registry → 1.8.0 aligned with Tasket++ v1.8 (Qt 6.9.3, RunningOtherTask action support) → 2.0.0 editor v2 (copy/paste/delete, inline editing, native fallback, the POST endpoints) → 2.1.0 the full ComfyUI-style UX pass → 2.1.1 the upstream sync fixes. Each step corresponds to something in the commit log, not to a changelog wish.

## The PI Agent

The `@pi-extensions/pi-tasket-http` TypeScript package registers 6 tools that let an LLM agent operate the system: list available tasks, trigger execution, read grid data, modify entrypoints, query execution status — all typed HTTP calls against the daemon. Concretely: tell the agent "run my morning setup routine" and it queries the task list, finds `morning-setup.scht`, triggers it over HTTP, and reports back what happened. The daemon's numbered-task API exists partly for this — an agent needs stable handles (`/check?id=1`), not fire-and-forget guesses.

## macrohelp: The Harness That Stays On Screen

If macrohard is the platform, macrohelp is the part you feel while using your machine. It is a lightweight overlay runtime (~300kb) that sits next to a running Tasket instance and translates intent into native `.scht` work through the same `tasket-httpd` daemon — full GET support for schedules and session availability, no direct WinUI mouse or keyboard mutation.

The features worth naming:

- **Native Circle Placement tool** — place coordinates either as `i+j` offsets on a circular grid or as radian/degrees; dot-product translation and unit-circle visuals move the mouse off relative location instead of raw deltas
- **Paste library** — reusable code snippets for quickly writing repeated blocks
- **Keyboard history beside the cursor** — Dance-Dance-Revolution style input echo, rendered with PromptFont glyphs (SIL OFL, loaded via `AddFontMemResourceEx` from an embedded resource), tracked by a `WH_KEYBOARD_LL` hook into a thread-safe circular buffer; the crosshair is a `WS_EX_LAYERED` colorkey window on a 16ms `WM_TIMER`, fades linearly over 5 seconds, and pulses on active combos
- **Zone creation with the circle tool** — reusable zones and workflow stacks ("looks almost like N8N"), chainable with if-then sequencing; a one-liner script can build a dynamic workflow, e.g. Discord automation where an incoming message from a user makes a zone immediately grab that user's copypasta from the library
- **Registry Hub adapters** — `{rgdclip ...}` and `{rgdappend ...}` compose Regedited CLI calls as native Tasket actions, which is how the August 13 "Add Regedited workflow tokens" commit ties this ecosystem back to [regedited](/blog/2026-06-08-regedited/)

Hotkeys are `Shift+Alt+1` through `Shift+Alt+0`: paste and zone buffers, the assembly playground, circle and zone placement, left/right/middle-click helpers, stop-all-tasks-through-the-daemon, panel toggle, and save-JSONs for MouseMove and KeySequence. The June 26 commit wave was mostly making this pleasant on real hardware: DPI correctness on high-refresh (240 Hz and up) monitors, reachability fixes, zone patches, and a Qt 5.15 LTS build. AGPLv3, no data ever collected, solely passion project.

## The Actual History, From the Commit Log

- **June 11, 23:58 — initial commit.** Then the night runs: uploads, the pi extension, gitignore churn.
- **June 13, 03:36 — `Sync to Tasket 1.8`.** Example screenshot, README update. Thirteen commits, two and a half hours. The editor, the daemon, the agent, and the installer all exist by morning coffee.
- **June 16 — macrohelp initial commit.** The runtime side splits off as its own repo with the circle tool, paste library, and keyboard history already in hand.
- **June 23–26 — the QoL wave.** Main-release sync, then the dense day: Qt 5.15 LTS build, daemon builder update, DPI on high-refresh monitors, reachability, zones, and the README revision that finally explains what macrohard *is*.
- **July 2 — Tasket 1.9** (plus a secondary minor patch the same day). **July 17 — Tasket v2.0.** The tracking discipline is the boring story: every upstream release gets a named commit within days.
- **August 13 — Regedited workflow tokens.** The two projects wire together at the action level.
- **Today** — the editor lives at app.shel.sh/macro, the docs live at docs.shel.sh, and the repos keep receiving README and gitignore maintenance like any project someone actually uses.

## Why Visual, Why Checkpoints

A macro tool whose flow you cannot see is a flow you cannot trust. Linear lists fail the moment automation needs a decision, and the usual answer — bury the branch in a script — trades visibility for expressiveness. macrohard refuses that trade: the graph *is* the program, checkpoints make the branch explicit and inspectable, and the round-trip JSON keeps every workflow portable, diffable, and importable by anything that reads text. If ComfyUI made model pipelines tangible, the bet here is that desktop automation deserves the same treatment — a canvas you can look at and understand, a daemon you can curl from another room, and an agent that can ask what it can do before it does it.

[github.com/CommanderTurtle/macrohard](https://github.com/CommanderTurtle/macrohard) · [github.com/CommanderTurtle/macrohelp](https://github.com/CommanderTurtle/macrohelp)

---

#### xkcd of the day, 6/11 - Beam Pipe #3257

![xkcd of the day](https://imgs.xkcd.com/comics/beam_pipe_2x.png)

[[can you really run quake in css]](https://github.com/layoutit/cssQuake)

"""

let render() = file