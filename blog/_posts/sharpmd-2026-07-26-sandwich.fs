module Bl0g.Posts.N20260726SandwichMd

let file = """---
layout: post
title: "sandwich: An Oven Factory"
author: "CommanderTurtle"
date: 2026-07-26 04:00:00 +0000
tags: [project, tooling, bun, node, package-management, auditing]
---

*an oven factory. node replacement that runs on delicious bread only.* That is the entire first paragraph of the README for **sandwich**, and it is also the whole design: `node`, `npm`, `npx`, `pnpm`, `yarn`, and `corepack` resolve to tested Bun translations. Workspaces, global installs, lifecycle trust, frozen lockfiles, and foreign package-lock projects are supported without installing a second JavaScript runtime — and without pretending to be one. When Bun does not expose Node's experimental `node:module.stripTypeScriptTypes`, sandwich supplies its position-preserving strip mode through the pinned Amaro implementation Node itself uses, so Node-oriented loaders can import and strip erasable TypeScript without touching their installed source. What Bun does not implement, like worker isolation controls, stays explicitly unsupported rather than silently approximated.

## The Compatibility Surface

The install path is one script: clone, `./install.sh`, `source ~/.bashrc`, then `sandwich doctor` verifies Bun and every compatibility shim. Windows gets the same shape through a PowerShell installer that creates small `.cmd` launchers under `.windows-bin`, puts that directory first on the user PATH, and runs the canonical Bash entrypoints through Git for Windows — no Node runtime installed, current PowerShell session updated immediately. Preview with `--check`, upgrade Bun with `--upgrade-bun`, and existing shims and shell configuration are backed up under `~/.local/state/sandwich`.

The most consequential consumer is Hermes, and the relationship is external by design: sandwich never patches, commits, rebases, or installs files into the official Hermes source tree. The wrapper runs the official updater with sandwich first on `PATH`, so Hermes' native `node` and `npm` commands execute on Bun, then rebuilds the generated UI/TUI output against a frozen compatibility lock staged only for the Bun process and removed immediately — no Bun lockfile or local compatibility commit lands in Hermes. Build compatibility stays fail-closed: when Bun exposes stricter optional-peer types than npm's installed layout, sandwich accepts only a known, version-scoped declaration mismatch, still type-checks the application, and runs the real upstream build. Any additional diagnostic fails normally, and no tracked Hermes source is changed.

## The Maintenance Walkers

The second half of the project is an audit suite for every runtime on the machine, each one read-only until you say otherwise:

| Command | Scope | Honesty contract |
|---|---|---|
| `sandwich checkExpr` | Every Bun root under `~/.bun/install/global` | Runs `bun audit`, adds or refreshes overrides, picks the newest non-vulnerable release satisfying every consumer's declared range; reports an unresolved advisory instead of forcing an API-incompatible major |
| `sandwich checkFence` | User-owned Cargo roots and tracked global installs | RustSec plus `cargo update --dry-run`; recreates a crates.io installation with its original features, binaries, profile, target, and lockfile; Git, path, and custom-registry installs are reported but never guessed |
| `sandwich checkZoo` | uv-locked projects, standalone venvs, uv tools | Native `uv audit` for locked projects; `uv pip list --outdated` for standalone environments, kept visibly distinct from a lockfile security audit; never invokes `pip`, never selects `--system`, never mutates distro Python |

Every mutation requires an explicit `--apply=projects`, `--apply=global`, `--apply=tools`, or `--apply=all`; a bare walker is rejected. Protected names travel through `--protect`, `--protect-file`, or environment variables, a protected version change aborts the operation and restores the original lockfile, and stale overrides get repaired only when one compatible release satisfies all consumers and an isolated audit confirms it is clean. The lock and audit behavior follows the upstream uv, Cargo, and RustSec contracts rather than inventing its own. Fail loudly when another package manager's semantics cannot be represented honestly — that last line of the README is the operating principle for the whole project.

## The Commit Arc

Sixteen commits between July 26 and September 10, 2026, all mine. The July 26 burst bakes the core: the Bun-only compatibility layer, pnpm package-script shorthand, the Hermes runtime skill, explicit foreign-runtime audit, public repository documentation, and keeping Hermes' Bun locks current across updates. August adds the edges: refreshing the native Hermes update integration while keeping Hermes pristine during Bun updates, the expiration checker, a Windows shim (requiring Git), a fix for over-generalized walking on Windows, DeepSeek Harness Node compatibility — including the private-loader bridge for its zero-root user-profile watcher, where module-job inspection and hot reload stay explicitly unsupported — and Hermes web-build compatibility under Bun. The window closes with the uv and Cargo maintenance walkers on September 1 and a September 10 tightening that keeps audit overrides within dependency contracts.

## Why It Matters Here

Everything Bun-native in this stack — Persephone, Librarian, Leetcoder, the Hermes builds themselves — resolves through sandwich, and its walkers are what keep that surface honest as dependencies drift. A node replacement that refuses to approximate is the difference between a shim you have to remember exists and infrastructure you can forget about. Delicious bread only.

[github.com/CommanderTurtle/sandwich](https://github.com/CommanderTurtle/sandwich)

---

#### xkcd of the day, 7/26 - Recursive Trucker's Hitch #3276

![xkcd of the day](https://imgs.xkcd.com/comics/recursive_truckers_hitch_2x.png)

[[fun javascript obfuscation]](https://webcrack.netlify.app/)

"""

let render() = file
