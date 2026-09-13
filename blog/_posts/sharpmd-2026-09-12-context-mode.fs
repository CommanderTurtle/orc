module Bl0g.Posts.N20260912ContextModeMd

let file = """---
layout: post
title: "context-mode: The Other Half of the Context Problem"
author: "CommanderTurtle"
date: 2026-09-12 04:00:00 +0000
tags: [project, tooling, mcp, context-mode, ai-agents, python]
---

Context window exhaustion is the other half of the cost problem with coding agents: every tool call dumps raw output into the window, and the compaction that reclaims space quietly drops what the agent was doing. [mksglu/context-mode](https://github.com/mksglu/context-mode) is the open-source answer — an MCP server with 22.3k stars and a Hacker News front page behind it — and its tagline is the best summary of the approach: **the other half of the context problem.** It sits in my repo list as a fork. The fork exists for exactly one project: making context-mode work with *Hermes*, the agent harness this whole stack runs on — the only major client in it without a merged adapter.

## What It Does

Eleven MCP tools, six hook types, and a compatibility table spanning eighteen clients — Claude Code and Codex on one end, Cursor, Zed, PI, and OMP on the other. The savings are not marginal. The BENCHMARK suite covers 21 scenarios; the representative rows land here:

| Input | Before | After | Saving |
|---|---|---|---|
| GitHub issues, 20 items | 58.9 KB | 1.1 KB | 98% |
| Analytics CSV, 500 rows | 85.5 KB | 222 B | 100% |
| Git log, 153 commits | 11.6 KB | 107 B | 99% |
| Repo research, subagent | 986 KB | 62 KB | 94% |
| Full session, raw | 315 KB | 5.4 KB | 98% |

The last row is the operational one: a full recorded session that costs roughly three hours replayed as raw tool output takes about thirty minutes through the sandbox.

The README states the design in four pillars of its own:

| Pillar | Mechanism |
|---|---|
| Context saving | The `ctx_execute` family sandboxes tool output in an isolated subprocess; only stdout enters the conversation |
| Session continuity | Every file edit, git operation, task, error, and user decision is tracked in SQLite; when the conversation compacts, events are indexed into FTS5 and only what is relevant is retrieved via BM25 |
| Think in code | The agent programs the analysis instead of computing it — one script replaces ten tool calls and saves 100x context; enforced across all eighteen supported clients |
| No prose-style enforcement | Raw data stays out of context, but context-mode never dictates how the model writes; aggressive brevity prompts have been shown to degrade coding/reasoning benchmarks (Moonshot AI on `kimi-k2.5`), so the routing block stays focused on where data goes, not on how the model talks |

Cost accounting became real in late June. Every indexed unit records `bytes_stored`; every retrieval records `bytes_retrieved`, so a platform P&L can derive savings from actual traffic rather than from a model of what the agent "would have" read. That pass exposed a measurement bug in production: 124,454 events carried `bytes_retrieved=0` because the session loader never populated the field. The fix — a server-emitted marker, landed with four tests on June 26 — reconciled the consumed-event count from 100,279 + 3,009 to 103,288.

The license is Elastic License 2.0 instead of MIT, with the reasoning stated plainly in the README: MIT would let someone repackage the code as a competing closed SaaS; ELv2 keeps it source-available while forbidding offering it as a hosted service.

## The Fork: What It Actually Contains

The honest shape of CommanderTurtle/context-mode: a mirror with an overlay, not a parallel development line. Main carries 2,179 commits and 198 tags as of this writing (2,143 when the research sweep behind this post started) — the delta is the daily `ci: update install stats` bot commits, nothing else. The sweep behind this post covers 1,600 of them, March 20 through July 28, 2026:

| Month | Commits |
|---|---|
| March (partial) | 98 |
| April | 412 |
| May | 751 |
| June | 257 |
| July | 82 |

Authorship inside that window: Mert Koseoglu, the upstream maintainer, 1,004; `github-actions[bot]` 330, mostly the daily stats commit; roughly twenty community contributors; and me, 36. Release cadence over the window: 126 version bumps from 1.0.37 to 1.0.169, a bump every day or two during active stretches, with CI rebuilding and committing the shipped `server.bundle.js` and `cli.bundle.js` alongside. The headline arcs — the June 21 pivot of `ctx_insight` from local dashboard to hosted product, the late-June cost-accounting pass (real per-model pricing catalog, per-turn token and cost capture, `bytes_avoided` forwarded so a platform P&L can derive savings) — all landed upstream and came down through the sync merges. My 36 commits are one thing plus housekeeping: the Hermes plugin, and the merge hygiene around it.

## The Client Landscape

Seventeen clients in the upstream table, eighteen with my overlay: Claude Code, Gemini CLI, VS Code Copilot, JetBrains Copilot, GitHub Copilot CLI, Cursor, OpenCode, KiloCode, OpenClaw, Codex CLI, Kimi Code, Antigravity, Antigravity CLI, Kiro, Zed, Pi, OMP — with Hermes added in the overlay row. All seventeen sit in the JavaScript/TypeScript hook world, and the table is really a map of how far each system has gotten:

- **Cursor** has the fullest hook set — `preToolUse`, `postToolUse`, `sessionStart`, `stop`, `afterAgentResponse` — but the Marketplace plugin is still awaiting Cursor team review (tracked in #485 / #489). Until it is listed, installation goes through a local-folder path, which is why the README marks Cursor work-in-progress.
- **Kiro** exposes native `preToolUse` and `postToolUse` only: `agentSpawn` (its SessionStart equivalent) and `stop` are not wired yet, and setup means manually copying `KIRO.md` to the project root so routing instructions exist at session start.
- **OpenCode** uses a TypeScript plugin paradigm where hooks run as in-process functions — `experimental.chat.system.transform` acts as a SessionStart surrogate to inject the routing block and restore prior sessions, and `chat.message` captures user prompts and decisions.

Per-client honesty matters. It means "supported" means something checkable, and it means the Hermes row is the one where the surface is a native Python plugin API instead of JSON hook files — which no existing adapter could cover.

## Why Hermes Was the Gap

Hermes exposes a **native Python plugin API** — `pre_tool_call` with a block contract, `transform_tool_result`, `pre_llm_call`, and session lifecycle hooks. A different surface means a different adapter, and nobody had built one. I was surprised until I searched. PR #425 by tayuLuc, a draft titled "configs, plugin, README", opened May 4, took a proof request the next day and an ownership demand the day after, and closed May 8 at 6 of 22 checklist items. People had tried; nobody had finished. The head was force-pushed once on May 9, orphaning `7555fad`, and a June 19 reopen request (`df3f1334`) found GitHub no longer allowing it.

## The Plugin

`.hermes-plugin/` is deliberately small: `plugin.yaml`, `__init__.py`, and a README — the public Hermes plugin, hook, and MCP contracts, plus the Python standard library only. No dependencies.

| Hook | Behavior |
|---|---|
| `pre_tool_call` | Blocks known high-output terminal fetch/build commands using Hermes's `{"action":"block","message":...}` contract |
| `transform_tool_result` | Writes eligible outputs above 3 KiB to a collision-safe UTF-8 file and returns a compact pointer — a bounded fallback for oversized native tool results |
| `pre_llm_call` | Injects current `mcp__context_mode__ctx_*` routing guidance once per session |
| `on_session_start` | Initializes bounded per-session metrics |
| `on_session_end` | A per-turn boundary in current Hermes — metrics are retained, not flushed |
| `on_session_finalize` | Performs actual teardown: persists the session state and releases it |

The bounding is worth listing because it is where a "just save it to disk" idea usually rots: the transform fires only above 3 KiB, the round-trip is lossless UTF-8 with XML escaping on both escape characters, side-effectful tools are never sandboxed, and the in-memory index is an LRU `OrderedDict` that evicts past 1,000 entries under a lock, so a long session cannot grow it unbounded.

Install is four steps: `hermes mcp add context-mode --command npx --args -y context-mode`, copy `plugin.yaml` and `__init__.py` from `.hermes-plugin/` into `~/.hermes/plugins/hermes-context-mode/`, enable `hermes-context-mode` in `~/.hermes/config.yaml`, restart — for gateway deployments, restart the gateway process. Everything the plugin generates stays under its own directory. Verify with `hermes mcp test context-mode`, then ask for `ctx stats`.

## Privacy and Bounding

Local-only by default: a per-project SQLite store, no telemetry, no cloud sync, no account. The optional hosted Insight layer is the org-facing exception, and it is opt-in. Permission inheritance is the load-bearing rule — a Read denied on the host stays denied inside the MCP sandbox, chained shell commands are split and each segment checked, deny wins over allow, and project config overrides global. PR #852 was the incident that hardened it: an agent with host Read denied retried the same read through the sandbox; the fix bounds `ctx_execute_file` to the project root by default. URL fetching accepts http/https only, hard-blocks 169.254.0.0/16 as a DNS-rebinding defense while allowing loopback and RFC1918, and secrets — authorization headers, tokens, passwords, cookies, signatures, private keys — are masked before anything touches the session database.

## The Saga: PR #981

The commit log tells the whole story in one morning. July 21, 01:08-01:32 UTC: thirty-one commits in twenty-four minutes — the plugin landing in the fork through the web upload flow, the old `hermes-plugin/` layout deleted in favor of the dot-directory convention the rest of the tree already uses (`.claude-plugin`, `.codex-plugin`, `.openclaw-plugin`), a stray file and `__pycache__` cleaned up. Then, the same day: [PR #981](https://github.com/mksglu/context-mode/pull/981), "feat(hermes): add current plugin and MCP integration," opened against upstream — head `9741920`, checklist 11 of 17.

Then the wait. As of this post (September 12), #981 is **still open**. Around it, the Hermes gap grew its own little race: #1010 from ildunari, "native Hermes Agent support", opened July 29 and also still open; #1110, a docs-only PR adding Hermes to the platform pages, closed August 31 at 7 of 21. On a repository with 22.3k stars and a CI bot committing stats daily, the harness this whole stack runs on went months without a working adapter — because the first attempt died in draft and the surface it needed was Python.

## Why It Matters Here

This revamp runs on context-mode: the research cache behind every post in this series is indexed into its FTS5 knowledge base, which is how state survives compaction across sessions. The companion pieces of this series live next door — [diogenes](/blog/2026-07-25-diogenes/) for the search backend and [orc](/blog/2026-06-20-orc/) for the site generator that renders these F# wrappers into the Jekyll source you are reading. The harnesses in the sHEL orbit — Hermes, PI, OMP — all route large tool output through the sandbox now. And the hosted Insight product is where the `bytes_avoided` telemetry lands. An open PR is the distance between "context-mode works everywhere except my own harness" and "everywhere."

[github.com/CommanderTurtle/context-mode](https://github.com/CommanderTurtle/context-mode) · [PR #981](https://github.com/mksglu/context-mode/pull/981) · [github.com/mksglu/context-mode](https://github.com/mksglu/context-mode)

---

#### xkcd of the day, 9/12 - OH Scale #3297

![xkcd of the day](https://imgs.xkcd.com/comics/oh_scale_2x.png)

[[aem1k's original invisible encoder]](https://shel.sh/projects/captcha/invisible/encoder/)

"""

let render() = file