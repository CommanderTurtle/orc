module Bl0g.Posts.N20260804LeetcoderMd

let file = """---
layout: post
title: "leetcoder: Puppeteering, With Receipts"
author: "CommanderTurtle"
date: 2026-08-04 04:00:00 +0000
tags: [project, ai-agents, mcp, bun, delegation]
---

In the profile README, **leetcoder** is the one that "lets hermes puppeteer pi's for small coding tasks." The README tells the precise version of that joke: leetcoder lets a live Hermes agent hand a bounded job to a native [oh-my-pi](https://github.com/can1357/oh-my-pi) session without surrendering control of the conversation. Each delegation gets an isolated git worktree, its own persistent OMP root session, a visible title, live steering, durable follow-ups, native Advisor review, an electable OMP `task`/`hub` swarm, and a mandatory Librarian handoff.

Nothing starts on the first tool call. Hermes receives the proposed scope and every active Leetcoder title, checks for duplicate work itself, and confirms on the second call — a two-stage, one-use confirmation with an exact duplicate check at confirmation time. In the README's words: this is agent lifecycle control, not a human permission prompt.

## The Ownership Split

Hermes elects whether a bounded assignment deserves Leetcoder at all. The persistent OMP root then elects whether to work directly or use native subagents. OMP owns child concurrency, isolation, lifecycle, revival, and merging. Leetcoder owns the cross-harness root, the durable control contract, the outer draft, recovery, and the final knowledge handoff — and nothing else. It does not parse a TUI, call an OpenAI-compatible endpoint, create a second model configuration, or copy uncommitted source-checkout changes; OMP receives its ordinary tools and MCP integrations through an isolated profile cloned from the user's current configuration.

The ceiling is arithmetic, not aspiration: up to three concurrent root workers by default, each continuously reviewed by OMP's native read-only Advisor — three worker/Advisor pairs plus Hermes and Librarian fit the configured eight-sequence local model ceiling. Native task recursion stays one level, concurrency one child per root, inner async execution disabled, because Leetcoder itself already runs the root in the background. One git branch and worktree per delegation, preserved after completion; SQLite lifecycle, event history, transcript offsets, and nested subagent status trees under `~/.local/share/leetcoder`; automatic recovery of interrupted turns after a service restart.

## Verified Completion

The part that earns the "with receipts" half of the title. At the end of an implementation turn, the gateway opens a separate ephemeral OMP session with only `read`, `grep`, `glob`, `bash`, and `lsp` — no skills, no project rules, no extensions, an MCP-empty profile. It receives the original contract, the draft location, and the acting agent's claimed result, then independently inspects the worktree. The verdict uses LongHorizon-Harness' three-part completion boundary:

```text
Status: complete | incomplete | blocked
Integrity: clean | suspect | violation
Contract audit: aligned | unknown | needs_revision | invalid
```

Only `complete + clean + aligned` enters the SQLite accepted-fact ledger and the Librarian handoff. Any other result routes back to the persistent OMP root as concrete repair guidance, then a new auditor checks again — default two rounds, configurable from one to five. Malformed output and auditor-caused worktree changes fail closed, and the acting agent's claims remain provisional against the original contract and an unchanged worktree fingerprint until the auditor signs. Closing never deletes a branch or worktree: review, merge, archive, or remove them explicitly with ordinary git after the parent Hermes session has accepted the result.

## The Commit Arc

Nine commits between August 4 and August 26, 2026, all mine, and each one a visible stage of the design landing: the Hermes-to-OMP gateway on August 4; MCP runtime refresh with audit overrides, simplified autonomous OMP delegation, the swarm-native rewrite, and sequence-budget alignment on August 5; isolated-profile provider state sync on August 6; the verified milestone completion boundary on August 14; and setup aligned with the current OMP schema on August 26. Nine commits, one idea executed in stages: bounded work, honest verification, durable knowledge.

## Why It Matters Here

It closes the loop on this stack's memory pipeline: work leaves Hermes as a bounded delegation, gets audited against its contract by a session that shares nothing with the worker, and lands in [Librarian](/blog/2026-07-26-librarian/)'s OKF bundle through the mandatory handoff. [persephone](/blog/2026-08-04-persephone/) owns the durable gateway; leetcoder owns the hand-off between harnesses. Receipts included.

[github.com/CommanderTurtle/leetcoder](https://github.com/CommanderTurtle/leetcoder) · [github.com/can1357/oh-my-pi](https://github.com/can1357/oh-my-pi)

---

#### xkcd of the day, 8/4 - Maze #3280

![xkcd of the day](https://imgs.xkcd.com/comics/maze_2x.png)

[[is there a tracker for consumer rights bills]](https://consumerrights.wiki/w/Category:Legislation)

"""

let render() = file
