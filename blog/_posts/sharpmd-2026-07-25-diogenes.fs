module Bl0g.Posts.N20260725DiogenesMd

let file = """---
layout: post
title: "diogenes: Bloated with Materialism, Nihilistic in Theory"
author: "CommanderTurtle"
date: 2026-07-25 04:00:00 +0000
tags: [project, self-hosted, python, agents, services, models]
---

[odysseus-dev/odysseus](https://github.com/odysseus-dev/odysseus) is a self-hosted AI workspace: chat and agents, deep research, documents, email, notes and calendar, plus local model workflows, served from a web UI on port 7000. It is also one of the hotter open-source projects of mid-2026: 87.1k stars, 857 forks, and 2,086 commits on `dev` at the time of writing, with 1,831 commits landing in upstream's June alone. **diogenes** is my maintained fork of it, and its repository description is the best summary of the whole bet: *bloated with materialism, nihilistic in theory.* What it actually is: a native, admin-only workstation control plane layered over untouched Odysseus routes and data contracts — the piece that turns a single machine into the installer and manager for the rest of this site's projects.

## What Upstream Ships

Before the control plane, there's the workspace it sits on. The fork's README keeps the upstream feature list verbatim beneath the Diogenes sections, and it is long: Chat + Agents (local or API models, tools, MCP, files, shell, skills, memory); Cookbook (hardware-aware model recommendations, downloads, and serving); Deep Research (multi-step web research with source reading and report generation); Compare (blind side-by-side model testing and synthesis); Documents (a writing-first editor with AI edits, suggestions, Markdown, HTML, CSV, and syntax highlighting); Email (an IMAP/SMTP inbox with triage, tags, summaries, reminders, and reply drafts); Notes, Tasks + Calendar (reminders, todos, scheduled agent tasks, CalDAV sync); and Extras (gallery and image editor, themes, uploads, web search, presets, sessions, 2FA). The Docker quick start is four lines — clone, `cp .env.example .env`, `docker compose up -d --build` — then open <http://localhost:7000> when the containers are healthy; the first admin password is printed in `docker compose logs odysseus`. `dev` is the default branch, `main` the curated one, and the license is AGPL-3.0-or-later.

The project's maturity shows in the small print, too. A September 5 security pass closed three independent routes by which bearer API tokens could reach privileged agent tools: because a token resolved to the human who minted it, every owner-keyed privilege check answered "admin," so a narrow integration token could reach bash and python with the creator's full authority. The fix refuses token-driven approval resumes, signs chat-session grants server-side so they can't be reconstructed from caller-supplied metadata, and caps token-driven runs at the non-admin policy. That is the bar the control plane layers on top of.

## The Name Game

The commit log records a three-day naming saga. On July 25 the new runtime landed under the name **Ulysses** — "establish Ulysses runtime foundation," "brand Ulysses and expose background effects," "keep Ulysses on upstream dev lineage." Ulysses is the Roman name for Odysseus, so the working title was the same hero with a passport change. By July 26 the commits were saying **Diogenes**: "Complete Diogenes host runtime management," "Finalize native Diogenes runtime management." The README's own index of additions puts it plainly — the completed control plane was renamed to Diogenes, the Cynic philosopher who famously owned as little as possible, which is a fun thing to say about a self-hosted monolith. The rename was cosmetic in one telling way: the runtime modules still carry their first-day names (`src/ulysses_runtime.py`, `ulysses_topology.py`, the `ulysses_*.py` family), so the codebase remembers what it was called at birth while the surface answers to Diogenes.

## Eight Hours, Thirty-Two Commits

The foundation day ran from 14:58 to 22:35 UTC on July 25: thirty-two commits. The shape of that evening:

| Phase | What landed |
|-------|-------------|
| Runtime core | Typed workstation runtime, local topology discovery, read-only topology exposure |
| Data safety | Chroma persistence checks — a mounted path is validated, not assumed durable |
| Hermes | Adoption preview, then durable lifecycle jobs with output records, behind a fail-closed production-readiness gate |
| Models | Colibri GLM and Hy3 providers, a native runtime management console |
| Browser | Camofox registered as the shared configurable browser backend instead of silently installing another browser stack |
| Locks | vLLM installs pinned to a verified uv lock, confined to the checkout's `.venv` |

The design rule that repeats across all of it: **observation stays separate from mutation.** The Services surface discovers Docker Compose projects, tmux services, Git checkouts, and configuration files and shows them read-only; acting on any of them goes through explicit, confirmation-gated jobs whose state and output outlive the request that started them.

## The Control Plane

Native setup is two scripts — `uvsetup.sh` builds a Python 3.13.12 inner virtualenv with uv, `startwithuv.sh` starts the web app — and the JavaScript side runs through [Sandwich](https://github.com/CommanderTurtle/sandwich), the standalone Bun compatibility layer that provides `node`/`npm`/`npx`/`pnpm` surfaces without a system Node. Diogenes itself adds no telemetry. The Services window manages those runtimes plus a separate operator-only mm-tools venv and host-shell tabs on a named `diogenes-operator` tmux socket (`DIOGENES_OPERATOR_TMUX_SOCKET` and `DIOGENES_MM_TOOLS_ROOT` override both defaults); the internal-agent token cannot enter that plane, the default tmux server is neither listed nor mutated, and Diogenes strips its own `.venv` from each launch environment before sourcing a project's. Deployment is state-preserving: `scripts/diogenes-deploy` and `scripts/odysseus-backup` define capture, rollback, and in-place update, and the readiness gate refuses a production switchover when declared prerequisites are unmet.

Two details round out the plane. `ompsettings.sh` can apply the workstation's optimized OMP preference baseline once — it is deliberately never run by Integrate, preserves MCP/model/auth/session configuration, and asks for confirmation before writing anything. And the operator shell is not a dependency: the terminal assets (xterm) are vendored under `static/vendor/`, cached by the service worker, and attributed with their MIT license, so the admin surface works on a machine with nothing installed but Bun.

## Native Model Engines

The Launch view preserves everything Odysseus already gives you — editable commands, saved configurations, advanced runtime controls — and adds first-class engines beside it: Colibri GLM, Colibri Hy3, and PrismML, each separately built and operated. Hardware-aware profiles expose the supported flags directly, including tuned RTX 5090 starting points for serving [GLM 5.2](https://huggingface.co/mastouri/GLM-5.2-colibri-int4-g64-with-int8-mtp) and [Hy3](https://huggingface.co/UnderstandLing/Hy3-colibri-int4) locally, and the final launch command is never hidden behind the profile. Python dependencies — including the guarded CUDA 13 vLLM nightly lane — stay inside the Diogenes `.venv`; native engines and service projects keep their own source, build, update, and configuration boundaries. Model downloads run isolated and high-throughput, with Hugging Face lock files treated as resumable metadata rather than state.

## Hermes Knowledge Orchestration

The optional Hermes layer extends the retrieval pattern Odysseus already ships — lightweight FastEmbed embeddings over Chroma — across Hermes skills, sessions, Context Mode data, and project knowledge. A persistent watcher re-indexes those sources as they change, so large skill libraries stay searchable without bloating the always-active skill set. The [Librarian MCP](https://github.com/CommanderTurtle/librarian) can delegate a focused lookup to a *second* model process, search disk-backed context, and return only the relevant material to the calling model. [Retrieval](https://github.com/CommanderTurtle/retrieval), Codebase Memory, and Context Mode's native Hermes integration — the README pins it to [upstream PR #1010](https://github.com/mksglu/context-mode/pull/1010) — are wired alongside [Hermes Workspace](https://github.com/outsourc-e/hermes-workspace) orchestration, so agents work from task sheets and pursue defined background goals. None of it merges the two agents or their MCP registries.

## Wiring the Orbit

This is the part that makes diogenes the keystone of the sHEL stack instead of just another fork. The integration rule throughout: wire everything in **without merging** the Odysseus and Hermes agents or their MCP registries.

- **Hermes** — durable lifecycle jobs, natively managed knowledge projects, skill policy applied through Hermes' own API rather than rewriting its private state, and Hermes Workspace as a managed interactive runtime for task-sheet and background-goal workflows
- **Persephone + OMP** — a canonical [oh-my-pi](https://github.com/can1357/oh-my-pi) runtime with [Persephone](https://github.com/CommanderTurtle/persephone) providing the persistent local gateway, channels, schedules, and RPC supervision it omits; an optional OMP settings baseline that is deliberately never run by Integrate and asks before writing
- **Librarian, Retrieval, Leetcoder** — registered as integration contracts; the Librarian web process lives in Services
- **Context Mode** — the native Hermes integration pinned in place (August 3), the same integration this blog's own [context-mode post](/blog/2026-09-12-context-mode/) tracks as an open upstream PR
- **Search** — a self-hosted Firecrawl provider with managed SearXNG fallback, so research scrapes stay on the machine
- **Codebase Memory** — kept Hermes-native rather than folded into the Odysseus agent

## Documenting Itself

The README is as disciplined as the code. Below the Diogenes sections it keeps the upstream quick start and feature overview verbatim, then opens a numbered **index of additions**: seventeen entries, each a Roman-numeral summary of what landed, the exact commit SHAs oldest-first, and every file the change touched. Fork-authored history only — upstream merge commits are intentionally omitted, so the index reads as a changelog of the control plane itself.

Deployment gets the same treatment. `docs/DIOGENES_DEPLOYMENT.md` covers in-place updates and runtime state; `install-service.sh` installs a systemd user unit from `diogenes-ui.service` into `~/.config/systemd/user/` behind a versioned symlink at `~/local/service/diogenes/current`, then does the daemon-reload/enable/restart dance. The Compose file binds `${APP_BIND:-127.0.0.1}:${APP_PORT:-7000}` to the container's port 70000, health-checks the app on :8000 (five-second interval, twenty retries), and co-ships an ntfy notification container on :8091 plus SearXNG whose dropped capability set mirrors the recommendation in the SearXNG project's own issue #721. Even the security notes are specific: keep `AUTH_ENABLED=true` anywhere network-accessible, keep `LOCALHOST_BYPASS=false` outside local development, and don't expose raw model or service ports publicly.

The demo section is a cross-wire of its own: a Three-JS rendering of Zensical Mkdocs documentation on the [dio.shel.sh](https://dio.shel.sh/) landing page, with the source living in the [orc](/blog/2026-06-20-orc/) repo's `dio/` directory — the wrapping framework doing double duty as the docs host.

## Long-Form Research

September's research work turned Deep Research into a document engine, not just a link aggregator. Two new modes: arXiv-style paper runs and Fiction/Nonfiction story runs, each with its own reading surface — navigation, references, print output, Markdown export. Partial generations survive interruption through continuation, the default wall-clock cap on healthy runs was removed, and an opt-in route sends images straight to local OpenAI-compatible endpoints as base64 with progressive resize retries when they complain about size. The citation machinery got hardened twice: first a malformed-citation boundary repair (Markdown brackets kept out of the generated href), then a Firecrawl-backed evidence path that scrapes discovered URLs, retains usable evidence when structured extraction comes back empty, and explains extraction failures in the report instead of discarding results.

## The Numbers

Two thousand one hundred seventy-four commits on `dev`, counted from the v1.0 baseline of May 31. The June spike of 1,831 is upstream's heat; mine are the other 89, and they line up exactly with what GitHub reports today: **89 commits ahead, 1 commit behind** `odysseus-dev:dev` — the single behind commit is a September 11 MCP args-validation fix that landed after the fork's last upstream merge on September 5. The arc: July 25 the Ulysses foundation, July 26 the Diogenes rename and production integration, July 27 the README tour with its AVIF walkthrough, August the integration wave (Sandwich-routed Hermes updates, Persephone OMP, the search stack, Librarian and Leetcoder contracts), September the isolated venvs, resilient long-form research modes, and the README that documents all of it — the final commit, September 8, is literally "Update README with Diogenes and Odysseus details." Eight stars, one fork, zero tags — a workstation tool, not a marketplace product.

A self-hosted workspace named for the philosopher who rejected ownership, running on a machine you own, managing every other project on this site from one authenticated surface. The materialism is in the commit count; the nihilism is in the theory.

[github.com/CommanderTurtle/diogenes](https://github.com/CommanderTurtle/diogenes) · [github.com/odysseus-dev/odysseus](https://github.com/odysseus-dev/odysseus)

---

#### xkcd of the day, 7/25 - Recursive Trucker's Hitch #3276

![xkcd of the day](https://imgs.xkcd.com/comics/recursive_truckers_hitch_2x.png)

[[the channel that hosts podcasts with the codegolf guys]](https://www.youtube.com/c/Honeypotio)

"""

let render() = file
