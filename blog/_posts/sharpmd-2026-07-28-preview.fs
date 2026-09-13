module Bl0g.Posts.N20260728PreviewMd

let file = """---
layout: post
title: "preview: The Deploy Topology, Rehearsed At Home"
author: "CommanderTurtle"
date: 2026-07-28 04:00:00 +0000
tags: [project, rust, egui, jekyll, fsharp, tooling]
---

A deploy pipeline that only works in CI has a blind spot: you find out about the broken build the moment your users do. preview closes it by treating the production topology as something you can *rehearse*. It's a multiplatform site previewer built around the orchestrator [orc](https://github.com/CommanderTurtle/orc): it reads the same `.github/config/deploy-*.fs` records that drive the real deployment, creates one rendered working mirror per source folder, launches each framework's own development server, and keeps the mirrors synchronized while source files are saved. The ORC checkout itself stays read-only — preview is separate from both ORC and the small one-tree `orc-reactor`, and cloning it gets you native previews of seven site frameworks with realtime edits to the F# source preserved.

The catchphrase fits the architecture: **it runs on reactor topology.** No monolithic build step pretending to be a server; each mirror is an independent unit with its own framework runtime, its own port, and its own lifecycle.

## The Watch Loop Is The Product

The core behavior is a notify-based watcher over the source tree. A changed F# source re-renders that mirror's staging tree and atomically swaps it into place; content-hash dedup means touching a file with identical bytes is a no-op, while a real edit triggers exactly one re-render. Jekyll mirrors get `jekyll serve --livereload` underneath, so the browser hot-reloads what the renderer produced. The ORC deploy records are watched too — when the deploy topology changes, the coordinator stops cleanly rather than serving a stale shape, which is exactly the failure mode that makes local previews lie to you.

That last behavior bit me personally during this blog revamp: the first live-mode runs exited after five seconds with "Deployment configuration changed. Stopping cleanly." Root cause was internal — the renderer's own `Access(Open)` probe of the shared config path was classifying itself as a topology change. The fix was to bind the event kind and count only `Create | Modify | Remove` under the config root. A watch loop that reacts to its own heartbeat is a subtle bug, and the honest fix lives in the pattern match, not in an ignore list.

## The Native Dashboard

On September 5 the project gained a dashboard compiled into the **same Cargo binary** — egui on a native OpenGL renderer, no browser runtime, no Electron, no GUI web server. Double-click `orc-preview.exe` or run `orc-preview --gui`; explicit CLI arguments still run the original console workflow. The design rules visible in the UI are worth stealing:

- **Nothing launches automatically.** Select sites and ports, then *Start selected*.
- **Refresh is surgical.** It re-renders one mirror, re-detects its framework, regenerates its launch configuration, and restarts just that server — the move to make after Zensical nav, Vite config, or Jekyll YAML changes.
- **Running means TCP-answering.** A port shown as running answered a TCP probe; the UI says plainly that this is not an HTTP health guarantee.
- **Shutdown is owned, not hoped.** Stopping the session or closing the window stops the owned process trees before deleting disposable output. A stalled shutdown gets 12 seconds, then the GUI terminates only its own worker tree — and on Windows, job objects contain the descendants even when a launcher exits early. Source repositories are *never* deleted.
- **No nuclear buttons.** Toggles let you reuse framework downloads in a shared cache or keep rendered mirrors, but switching either off never deletes an existing persistent folder, and there is deliberately no generic recursive "clear cache".

Logs stay in the window with per-site filtering, search, follow, copy, save, and clear, bounded to 4,000 lines in memory. Internally the GUI owns one hidden coordinator spoken to over a private stdin/stdout protocol carrying control actions and tagged logs — no network control port opens. The coordinator shares the CLI's renderer, theme cache, launch scripts, and watcher, so the two frontends cannot drift apart.

## Zero Configuration On Windows

For the people who just want it to work: put the `preview` and `orc` checkouts beside each other, run `.\orc-server.ps1`. It reads the Git-ignored `.env` when present, otherwise the complete `.env.example` baseline; the checked-in defaults resolve the adjacent `../orc/orc` checkout and start the canonical seven targets, building Preview when needed and creating a unique rendered environment beneath the Windows temporary directory. The CLI side stays positional and boring — `orc-preview --orc-dir C:\src\orc app,docs,lab 2000,2001,2002` — with `--single-dir` + `--runtime-dir` for pointing any standalone source folder at any canonical `GenerateConfig.fsx` runtime, and session state (mirrors, launch files, downloads, venvs, theme checkouts) living in one unique temporary directory removed on normal exit or Ctrl+C unless `--cache` or `--output` says otherwise.

Eight commits, July 28 to September 8: initial upload, the zero-config launcher, the canonical-runtime switch, the native dashboard, and the README settling around it. This post is, fittingly, being edited through the very watch loop it describes.

[github.com/CommanderTurtle/preview](https://github.com/CommanderTurtle/preview) · [CommanderTurtle/orc](https://github.com/CommanderTurtle/orc) · [the orc post](/blog/2026-06-20-orc/)

---

#### xkcd of the day, 7/28 - Forth #3277

![xkcd of the day](https://imgs.xkcd.com/comics/forth_2x.png)

[[Satan's Computer - A research paper]](https://www.cl.cam.ac.uk/archive/rja14/Papers/satan.pdf)

"""

let render() = file
