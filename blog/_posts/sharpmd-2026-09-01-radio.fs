module Bl0g.Posts.N20260901RadioMd

let file = """---
layout: post
title: "radio: A Desktop QML World, Shipped As Static Files"
author: "CommanderTurtle"
date: 2026-09-01 04:00:00 +0000
tags: [project, qml, qt, web, radio, agpl]
---

The repository description states the whole thesis in one question: **"usage of plugin store requires omarchy? Why not just webapp?"** Omarchy is a desktop QML environment — Wayland-native, plugin-shaped, themable down to the last token — and its most visible plugins live in the Omarchy bar. The first packaged application inside this repo is a faithful web port of the bar's best-known radio plugin, [AksharP5/omarchy-radio-atlas](https://github.com/AksharP5/omarchy-radio-atlas) — "explore live radio on a rotatable globe," MIT-licensed, 64 stars, still actively developed upstream. And the answer to the question: a static, browser-native host for Omarchy plugins, with **no Qt runtime, no C++, no server application, no package install, and no build step in the deployed site**. Clone it, serve it, and a desktop-bar application runs from a folder of static files.

## The Port, Source By Source

The adapter preserves the experience that made the original worth porting: a rotatable, deeply zoomable canvas globe with clipped country geometry; live Radio Browser station discovery with country browsing, search, and random tuning; a progressive world catalog that expands to 5,000 records; coordinate estimation for stations that publish only a country; a virtualized station list with favorites, recent history, and cached results; and full `<audio>` transport — play/pause, previous/next, stop, mute, volume, failed-stream skipping, Media Session integration. The complete upstream keyboard and pointer control set came along, close/reopen behavior keeps the in-page session intact, and persistence uses indexed browser storage with no telemetry. The visual reference for the work is the original overlay screenshot, kept in the repo next to the ported source.

Two honesty notes stand out, because they're the kind of claims a casual port waves away:

- **Network discipline.** The page contacts exactly two things: Radio Browser, and the station stream the user asked to play. Some community stations expose HTTP-only audio, and an HTTPS-hosted page would choke on them with a mixed-content error *after* the fact. The adapter detects those entries before assigning them to the media element and moves on to the next playable station — no failed request ever leaves the page.
- **Now-playing, honestly.** A static page can't read arbitrary ICY response headers, so instead of claiming MPV's proxy-level metadata extraction, it exposes station identity to Media Session and stops there. The README says so plainly, and links a source-by-source [parity audit](https://github.com/CommanderTurtle/omarchy-webapp-shell/blob/main/docs/PARITY.md) documenting what maps where.

## Themes With Provenance

The theme selector ships the first twelve themes from the canonical Omarchy manual (quattro branch) — Tokyo Night, Catppuccin, Lumon, Ethereal, Everforest, Gruvbox, Miasma, Hackerman, Osaka Jade, Kanagawa, Nord, Matte Black. Their tokens and canonical previews come straight from the corresponding current Omarchy theme directories, and the palette identities were cross-checked against the public [Omarchy Themes preview catalog](https://omarchythemes.com/) wherever that catalog exposes a first-party entry. Catppuccin is the default because it most closely matches Radio Atlas's upstream screenshot, and the choice persists locally. In a project whose whole premise is "the desktop contract, narrowed honestly," the themes aren't decoration — they're the contract, verbatim, with the test suite pinning their exact order and tokens.

## An Importer That Refuses To Guess

Adding a second application is a single command:

```
node tools/import-plugin.mjs --repo /path/to/plugin
node tools/import-plugin.mjs --repo https://github.com/owner/plugin.git
```

`--repo` always points at the plugin root — the directory containing its schema-1 `manifest.json`. The importer validates the manifest, entry-point containment, symlinks, file sizes, and record counts; copies only auditable static source; records the Git commit, date, and dirty state plus a deterministic SHA-256 source digest; generates the shell wrapper; and registers the descriptor in `plugins/catalog.json`. The running shell reads the catalog and adds the application tab programmatically — `shell.js` never needs a plugin-specific edit. And critically, **the importer never executes the imported plugin**: it audits bytes, it doesn't run them.

A plugin written against the portable QtQuick subset gets the vendored QmlWeb runtime. A plugin that reaches for Quickshell processes, files, Wayland/Hyprland, Omarchy UI globals, shell IPC, or an external player is **refused** until someone names an explicit adapter:

```
node tools/import-plugin.mjs --repo ... --adapter my-browser-adapter --app-entry app/index.html
```

The adapter directory survives later imports so the upstream source can be refreshed and audited independently, and the adapter is explicitly *not* a blank compatibility waiver — `plugin.json` retains every detected native boundary. Refusal is the feature: the deployed site can never quietly claim more of the desktop than it actually implemented.

## What "Static" Means Here

The deployed application carries **zero npm dependencies** — `package.json` exists only for development convenience. Any ordinary static server works: `npm run serve` for local development, or GitHub Pages, Caddy, nginx, Apache, a CDN, even `python -m http.server 4173`. (`file://` is deliberately unsupported and documented as such: browsers block local `fetch()` and QML loads, and pretending otherwise just breaks on the first click.)

The verification suite closes the loop with the same refusal energy: `npm test` covers importer refusal and reproducibility, source digest and commit recording, manifest/catalog resolution, exact theme order and tokens, local-only assets, QmlWeb packaging, Radio Browser normalization, and map mathematics — then a final browser audit exercises the portable QML runtime end-to-end: Radio Atlas search, playback, history, favorites, themes, close/reopen behavior, and responsive layout. Provenance stays itemized through it all: the host and original adapter code are AGPL-3.0-only, the imported Radio Atlas source remains MIT, QmlWeb remains MIT/BSD-2-Clause, Natural Earth geometry stays public domain, and every bit of it is listed in the third-party notices file.

## Seven Commits, A Weekend Of Edges

The history reads like a QA log: born **Tuesday, September 1, 12:11 UTC** — the static shell, the Radio Atlas port, and the parity tests landing within ninety seconds of each other — an HTTPS fix the next morning at 09:48, nine canonical themes at 21:31, and two small behavioral corrections the following morning: keep the player on the selected station, keep station rows stable through activation. Seven commits across roughly thirty hours, with the upstream pinned at import time to commit `1738fa1` and an archived mirror kept under the author's own organization. A desktop-bar application, a documented plugin contract, and a static site — the question in the repo description answered with a working port and an importer that tells you when it can't.

[github.com/CommanderTurtle/omarchy-webapp-shell](https://github.com/CommanderTurtle/omarchy-webapp-shell) · [AksharP5/omarchy-radio-atlas](https://github.com/AksharP5/omarchy-radio-atlas)

---

#### xkcd of the day, 9/1 - Geology Class #3292

![xkcd of the day](https://imgs.xkcd.com/comics/geology_class_2x.png)

[[floppotron]](https://www.youtube.com/watch?v=ph5OW9p-GHM)

"""

let render() = file
