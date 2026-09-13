module Bl0g.Posts.N20260726LibrarianMd

let file = """---
layout: post
title: "librarian: The Wikifier That Dreams"
author: "CommanderTurtle"
date: 2026-07-26 04:00:00 +0000
tags: [project, ai-agents, mcp, memory, bun, okf]
---

In my profile README, **librarian** gets the shortest description of anything in the stack: *wikifier — makes wikis, dreaming agents.* It is an RPC-native fork of [Understory](https://github.com/thecodacus/understory), Anirban Kar's "memory that grows" — an Open Knowledge Format agent with an MCP server, an agent core, and a web UI whose headline feature is an Obsidian-style memory graph you can pan, replay, and lint. The fork keeps Understory's deterministic core and removes the rest of its brain: there is no embedded model provider, no API client, and no second agent loop. Every agentic piece of work crosses a native RPC boundary into a harness that is already running — Hermes by default, OMP if you prefer it.

## What Understory Ships

Understory's initial release landed July 9, 2026: an OKF knowledge agent — MCP server, agent core, web UI. The upstream arc over the following weeks was fast and specific: seed memory so MCP clients get a session-start overview of the knowledge base, the `kb_*` tools renamed to `memory_*`, graph maintenance with lint and contradiction detection, query-path recording with a replay scrubber that animates a traversal from 0 to 100, the Obsidian-style graph view itself, a llama.cpp provider with model auto-discovery, and optional bearer-token auth for `/mcp` and `/api`. On July 28 came the two features this fork cares about most: a layered query cache (#8) and scheduled autonomous memory consolidation — "dreaming" (#9). The bundle format is Google's Open Knowledge Format spec: markdown concepts with required frontmatter, generated `index.md` files, and a newest-first `log.md`.

## The Contract the Fork Keeps

Everything deterministic stays inside the fork. Understory's `KnowledgeBase` remains the only write path, so the invariants it enforces still hold: bundle-relative path sandboxing, required OKF frontmatter, generated `index.md` files, newest-first `log.md` entries, serialized mutations, and optional Git autocommits. The public MCP keeps Understory's original five tools — `memory_query`, `memory_add`, `memory_update`, `memory_status`, `memory_maintain` — and `memory_status` is model-free. Every deep operation starts a fresh, isolated agent turn, streams native tool events internally, and closes the worker after the final answer.

Everything agentic is delegated. Hermes is the default backend and speaks its native TUI-gateway JSON-RPC protocol; OMP is selected with `LIBRARIAN_AGENT_BACKEND=omp` and speaks its distinct native JSONL RPC protocol. The recursion problem is solved structurally, not in the prompt: setup clones the current Hermes profile into an isolated `librarian` profile that registers only the private `librarian-okf` server, while the public `librarian` MCP lives in the default profile. OMP gets the same shape through profile-scoped configuration — the public server merges into `~/.omp/agent/mcp.json`, the dedicated `~/.omp/profiles/librarian/agent/mcp.json` converges on the private server alone, and workers launch as `omp --profile librarian --mode rpc --no-session`. A worker cannot discover its own public `memory_*` tools, so it cannot recurse back into Librarian.

## The Query Path

Three tiers, cheapest first. An exact query cache keyed by bundle fingerprint, backend, model, provider, and normalized question. A short-lived hot set that checks recently changed concepts and recent answers. And, on a miss, the full agent with its private OKF tools. Any bundle change invalidates exact answers, and a hot answer is accepted only when the harness returns a tool-free response — otherwise the request falls through to the deep agent. Query traces stay local under `<bundle>/.traces/`.

## Dreaming, Gated

Upstream's dreaming (#9) runs scheduled autonomous memory consolidation; the fork kept the schedule and rewired the authority. Checks run every six hours by default — first check delayed ten minutes after startup, configurable with `DREAM_INTERVAL` and `DREAM_START_DELAY` — scheduled only after the preceding run finishes, never overlapping, and never in ephemeral stdio MCP processes. A dream runs against an isolated copy of the bundle and saves a **pending proposal**; it never changes live memory by itself. Only one pending proposal is permitted at a time, so an unattended scheduler cannot accumulate competing plans against the same baseline.

Resolution is deliberately human. The web UI's Dreams view auto-refreshes proposal history and scheduler state, shows the next and previous checks, highlights changed lines in exact before/after diffs, and confirms each apply, reject, or rollback — but only the human-only HTTP approval route can resolve a proposal; no model-facing MCP tool has approval authority. Approval first verifies the stored proposal hashes and every live concept baseline. Applied proposals retain their preimages and can be rolled back from the same view; a later concept change blocks rollback rather than overwriting newer knowledge, and an interrupted multi-file apply compensates the edits it already made. In the README's own words, the design adapts Prime Agent's plan/apply/rollback refinement lifecycle and LongHorizon-Harness' persisted human gate without adding another agent loop. The commit arc says the same thing: upstream landed dreaming on July 28, the fork merged it in on August 3, and on August 14 made Librarian dreaming **proposal-only**.

## The Commit Arc

Forty-eight commits between July 9 and August 26, 2026:

| Author | Commits |
|---|---|
| Anirban Kar (upstream) | 29 |
| CommanderTurtle | 14 |
| Community (James Sesler, Timor, Josh Hendricks, holden093, André Martinsen) | 5 |

My fourteen split into four beats. The July 26 release-prep burst: preparing Librarian for a public Bun-native release, adding the native Hermes MCP integration skill, making Hermes MCP registration noninteractive and verifiable, delegating Understory knowledge operations to Hermes, and the LICENSE/NOTICE hygiene around it. Then August 3: merging in upstream's memory cache and dreaming. August 10: **Package Auditing** — the bridge to sandwich, the package-management side of this same stack. And August 14 plus August 26: making dreaming proposal-only, then the upstream merge and the dreaming improvements that close the window.

Bun is the only runtime requirement — normally supplied by sandwich — and Node.js, npm, pnpm, npx, and yarn are explicitly not runtime requirements. Librarian makes no telemetry calls of its own: knowledge, traces, delegated sessions, and configuration stay on the machine running the chosen harness. The license is AGPL-3.0-only, with the upstream attribution stated plainly — a modified derivative of Understory by Anirban Kar.

## Why It Matters Here

The memory layers in this stack stop duplicating each other: context-mode sandboxes tool output and indexes session events, Librarian owns the durable OKF bundle, and the harness — not a library — does the reasoning. [diogenes](/blog/2026-07-25-diogenes/) runs the services that host all of it, and sandwich supplies the Bun that runs Librarian itself. A wikifier that dreams and asks first is closer to a collaborator than a database — which is what a wiki is for.

[github.com/CommanderTurtle/librarian](https://github.com/CommanderTurtle/librarian) · [github.com/thecodacus/understory](https://github.com/thecodacus/understory)

---

#### xkcd of the day, 7/26 - Recursive Trucker's Hitch #3276

![xkcd of the day](https://imgs.xkcd.com/comics/recursive_truckers_hitch_2x.png)

[[what the heck is a shim - coreboot's solution]](https://coreboot.org/)

"""

let render() = file
