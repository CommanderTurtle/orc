module Bl0g.Posts.N20260804PersephoneMd

let file = """---
layout: post
title: "persephone: The Gateway That Is Not a Harness"
author: "CommanderTurtle"
date: 2026-08-04 04:00:00 +0000
tags: [project, tooling, ai-agents, gateway, bun, mcp]
---

The README opens with a joke and a job description: *obligatory greek goddess goth girl gateway compatibility layer for [oh-my-pi](https://github.com/can1357/oh-my-pi).* The job description is the interesting part. **persephone** turns a normal OMP installation into an optional always-on local agent without forking or patching OMP. OMP remains the agent engine. Persephone owns only the operational layer that does not belong inside a coding harness: durable delivery queues, channel-to-session routing, persistent RPC workers, cron, service lifecycle, and remote approval correlation. It uses Bun, SQLite, OMP's documented JSONL RPC protocol, native OMP plugins and MCP profiles, and a systemd user service. There is no Node runtime, no cloud relay, no analytics service, no web framework, and no second model abstraction.

## What It Adds, and Refuses to Add

The additions are all durability and reach. Persistent `omp --mode rpc` workers that resume the correct OMP session after a restart. A durable SQLite inbox and outbox with crash recovery and bounded retries. Separate Signal, Discord, and Slack transports behind one routing contract. Standard five-field cron prompts with optional delivery to any enabled transport. Conversation-bound `/approve` and `/deny` replies for headless UI requests. Mid-turn `/steer`, queued `/follow`, `/model`, `/thinking`, `/cwd`, and `/new` controls. A local authenticated health and control API. And native registration of the rest of this orbit: Context Mode, Librarian, Retrieval, Codebase Memory, and Camofox.

Two adapters deserve the detail. Web search goes to a self-hosted Firecrawl with no hosted fallback: OMP's built-in Firecrawl provider targets `api.firecrawl.dev` and cannot select a self-hosted base URL, so Persephone re-registers the same `web_search` tool through OMP's supported extension API and points the compatible `/v2/search` request at the local endpoint — fail-closed, so a down local instance reports failure instead of quietly submitting the query to a hosted provider. Exa stays disabled because it is a hosted service rather than software you can install locally. And the `browser` tool is a real OMP-compatible adapter backed by local [Camofox](http://localhost:9377) rather than Puppeteer: the named-tab open/run/close contract maps onto Camofox's HTTP API, raw Puppeteer APIs are deliberately absent, and Puppeteer never starts.

The refusal list is just as deliberate. OMP already provides editing, snapshots, LSP, plan mode, tasks, subagents, swarm DAGs, async jobs, artifacts, compaction, ACP, model routing, MCP, skills, rules, and extension hooks — Persephone wraps or reimplements none of them. It does not install `pi-gateway`, `remote-pi`, Orca, Hermes, or another memory product. OMP's native Mnemopi backend stays OMP-owned. Orca informed the durable run/dispatch/heartbeat model, but no Orca code or UI was copied. And GitHub issue automation remains OMP's native `roboomp` service rather than a second, less-isolated implementation inside Persephone.

## The Transports

| Channel | Native protocol | Conversation route |
|---|---|---|
| Signal | Local signal-cli JSON-RPC + SSE | Contact or group |
| Discord | Gateway v10 WebSocket + REST | DM, channel, or thread channel |
| Slack | Socket Mode WebSocket + Web API | DM, channel, or thread |

The command set is identical on every channel — `/status`, `/stop`, `/new`, `/steer`, `/follow`, `/cwd`, `/model`, `/thinking`, `/approve`, `/deny` — and DMs, channels, groups, and threads remain distinct conversations. Every transport is disabled by default and fails closed: each one requires its credentials plus an explicit allowlist unless its `allowAll` flag is deliberately set. Approval replies are accepted only from the exact originating transport and route, and they expire. One operational note from the README earns a quote of its own: if Hermes owns the same Signal account, leave Persephone's transport disabled, and during a cutover stop the Hermes gateway first, enable Persephone's allowlists, and start Persephone last — so only one SSE consumer can ever route a message.

## The Integration

`persephone integrate` is idempotent and uses each project through its native surface:

| Project | OMP integration |
|---|---|
| Context Mode | `omp plugin link` for lifecycle hooks plus its bundled stdio MCP launched directly with Bun |
| Librarian | Public stdio MCP plus a private OMP RPC profile whose MCP surface contains only deterministic OKF tools |
| Retrieval | Its watcher-backed `start.sh` stdio MCP |
| Codebase Memory | Its compiled, zero-dependency stdio server |
| Camofox | Its built stdio MCP launched by Bun |

Existing OMP MCP entries and config keys are preserved: their pre-Persephone values are recorded once and restored by `persephone uninstall`, and a malformed OMP config is never overwritten. Integration applies the workstation's eight-sequence policy through OMP's own `config set` command — the interactive profile gets one primary turn, one Advisor, and up to four native task workers; Persephone reserves one persistent worker; Librarian reserves one isolated delegated worker; brief Mnemopi extraction overlaps are queued by vLLM rather than creating another permanent worker. Passive startup and marketplace update checks are disabled in every managed profile; updates stay explicit operator actions. Worker profiles receive managed copies of the interactive model definitions but not its sessions, model cache, or credential database, and the isolated Librarian profile gets the orbit's tools without the public Librarian MCP that would recurse into itself.

## GitHub Automation, Pinned

OMP ships `python/robomp`, a purpose-built GitHub issue/PR orchestrator: webhook HMAC verification, allowlisted repositories, durable SQLite state, per-issue OMP RPC sessions, isolated worktrees, and a credential-holding `gh-proxy` sidecar. Persephone builds that native service from a pinned OMP commit and exposes lifecycle commands — `init`, `doctor`, `build`, `up`, `triage`, `review` — without replacing its queue, worker, prompt, or GitHub tools. The optional audit loop creates one proposal-only issue through the credential proxy and hands it to native manual triage; implementation still requires a trusted maintainer directive. Same philosophy as the rest of the stack: stage the change, gate the merge.

## The Commit Arc

Thirty-two commits between August 4 and August 26, 2026, all mine, in three beats. The August 4 burst — eighteen commits in one day — builds the control plane end to end: the OMP control plane itself, native setup documentation and configuration, a health probe, model discovery, local Firecrawl and Camofox backends, Discord and Slack transports, the OMP migration analysis, transport lifecycle hardening, the switch to a local-native OMP integration, canonical Orca Debian package handling for the apt sandbox, and the docs that pin the boundaries (local-only tooling, stock Orca lifecycle, messaging transport boundary). August 5 closes the loop with gateway routing and supervision hardening, bounded native swarm status, and the executable CLI entrypoint. Then the August 16–17 RoboOMP arc: governed GitHub loops, approval and identity boundaries, scoped GitHub bot identities, dream staging, a revert that removed duplicate orchestration before the native git agent landed, and launcher-mode preservation. The window closes August 26 with a fix that preserves the isolated Librarian OMP profile.

## Why It Matters Here

This blog revamp runs through it: the durable gateway that routes research prompts across sessions and channels is the thing under every post in this series. The orbit it registers natively — context-mode for tool output, Librarian for durable knowledge, Retrieval for dormant skills, Codebase Memory for repository structure, Camofox for the browser — is the same orbit [diogenes](/blog/2026-07-25-diogenes/) hosts as services. A gateway that stays out of the way is easier to trust than a harness that also wants to be your gateway: one SSE consumer, one approval authority, one model engine.

[github.com/CommanderTurtle/persephone](https://github.com/CommanderTurtle/persephone) · [github.com/can1357/oh-my-pi](https://github.com/can1357/oh-my-pi)

---

#### xkcd of the day, 8/4 - Maze #3280

![xkcd of the day](https://imgs.xkcd.com/comics/maze_2x.png)

[[Space Engine, possibly portable to standalone in-browser?]](https://spaceengine.org/)

"""

let render() = file
