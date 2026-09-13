module Bl0g.Posts.N20260716FirebendingMd

let file = """---
layout: post
title: "firebending: The Model Server That Waits For You"
author: "CommanderTurtle"
date: 2026-07-16 04:00:00 +0000
tags: [project, ai-agents, mcp, fsharp, openai, localhost]
---

Every local model server story ends the same way: download weights, burn VRAM, wait for inference. firebending is the F# localhost harness that reads the contract backwards. It looks like an OpenAI-compatible model server — same endpoints, same wire format, same streaming semantics — but there is no model inside. Post a chat completion and it **waits**. You (or a local tool, or a person with a keyboard) supply the response through `/v1/buffer`, and only then does the completion resolve. No GPU, no weights, no checkpoint download: the model is whatever responds to the buffer. The name is doing double duty — a firebender shapes something that isn't solid yet into what it needs to be, and this daemon shapes your answers into a shape every OpenAI client will accept.

## The Buffer Contract

The endpoint surface is deliberately small, and each route has exactly one job:

| Route | Behavior |
| --- | --- |
| `POST /v1/chat/completions` | Accepts the request, parks it in the pending queue, and waits for a buffer response. `stream: true` supported. |
| `POST /v1/buffer` | Inspect the pending queue and supply the response that resolves it. |
| `GET /v1/pending` | See what is currently waiting. |
| `GET /v1/models` | Reports one local compatibility model: `manual-buffer-model`. |
| `GET /health` | Liveness. |

Two properties make it safe to point real clients at: the daemon binds `127.0.0.1` by default and requires no API key, and unsupported `/v1/*` POST endpoints are logged and answered with a structured `501` JSON body. The daemon doesn't lie about capabilities it doesn't have — a client that probes `/v1/embeddings` gets a machine-readable refusal, not a hang or a made-up vector. And multimodal Chat Completions bodies are preserved exactly, including `image_url` content parts, so a vision-capable client can send what it sends upstream.

## Streaming Without Lying

This is where a naive implementation would fake progress. With `"stream": true`, the daemon returns an SSE stream, and while it is still waiting on the buffer it emits SSE *comments* — lines like `: thinking 2026-...` — which keep compatible clients' connections alive without delivering a single byte of fake assistant text. When `/v1/buffer` finally receives the response, the stream sends the final content chunk and `data: [DONE]`. The client experiences one uninterrupted generation that lasted however long the human took. That is the whole trick, and it's a good one: the latency of a slow model, with none of the tokens invented to hide it.

## Vision As Read-Only Observations

The second half of the daemon is a typed, read-only observation layer. Vision *producers* feed it — the [integrations/surfingkeys](https://github.com/CommanderTurtle/firebending/tree/main/integrations/surfingkeys) DOM producer ships in the repo, with optional Python UIA/OCR/CV paths — and the preference order is explicit: DOM first, then UIA, then OCR, then computer vision, because each step down the list is lossier and slower. The producers can observe; they cannot act. The observation shape is pinned in `contracts/vision-observation.schema.json`, and the producers stay separate processes from the daemon rather than being welded into it. A model server that can look at your screen and also click things is a different category of risk than one that can only describe what it sees.

## The Ember Routes: Zuko, Iroh, And Macro

The third half borrows its cast from *Avatar*. Zuko and Iroh are two routes that share one swappable Regedited output file — `%TEMP%\\tempreg.txt`. Every call creates a blank, one-indexed document and pipes the text through `rgd rs` as `i1z1`, which is to say: it treats the file as a [Regedited](/blog/2026-06-08-regedited/) registry and transports it the way that tool was built to move data. The file is the handoff surface; the routes are just different addresses for the same mailbox.

`/v1/macro` picks a persistent Tasket `.scht` pointer — or `off`. Tasket runs at `127.0.0.1:7777` under [macrohelp](/blog/2026-06-11-macrohard/)'s `tasket-httpd` sidecar, so the daemon isn't driving the scheduler directly; it's asking the local automation runtime to run a schedule it already knows. The macro-off, file-only mode is the important sibling: with `/v1/macro` set to `off`, the same Regedited file is produced and Tasket is simply skipped. One code path, one artifact, two deployment shapes.

## The Optional MCP

The larger-model escape hatch lives in `optional-mcp/`: a configurable, **independently installable** MCP template that submits larger-model requests through Zuko, can observe configured Regedited results, and recovers the last temporary payload — all without becoming part of the daemon process. The dependency direction stays honest: the daemon never imports the MCP; the MCP points at the daemon. The profile readme still calls it "an Anything-MCP built on macrohelp (TBD)", and the commit history agrees with that label — three commits in ninety minutes on August 7 iterate it from "add optional larger-model MCP" to "add optional MCP as a configurable subtree", which is the shape of someone deciding, quickly, that the feature must be opt-in or it isn't a feature.

## What It Is Not

One historical note deserves its own paragraph: the older `PiProxyVLLM` proxy is reference material only, intentionally not bundled into this daemon. The README says so out loud. When a project names the thing it deliberately left behind, the architecture has been thought about rather than accumulated.

## Thirteen Commits, Three Weeks

The timeline is sparse in the way a finished tool should be:

- **July 16, 04:26 UTC** — first commit: the OpenAI buffer daemon *and* vision observations land together. The core contract is complete before the project has a name worth arguing about.
- **July 18, 15:39 UTC** — a single hardening commit: "refactor: harden vision architecture and repository layout." Two days, one structural pass.
- **August 7, 15:32–17:29 UTC** — the macro bridge in one afternoon: Zuko, the Iroh Regedited slots, file-only mode, the optional MCP three times, then the merge integrating the hardened vision architecture. Seven commits in under two hours.
- **August 13, 20:20–21:10 UTC** — evening bug audit, then an `rgd rs` handling update.
- **August 14, 04:15 and 04:35 UTC** — the README settles in two commits twenty minutes apart.

Thirteen commits total. .NET 10. AGPL-3.0-only. The profile readme still lists it as a working prototype with opinions rather than a finished product, and honestly that framing undersells how complete the boring parts are: a daemon that waits, streams without inventing, refuses politely, and hands its artifacts off through registries other tools were built to read.

[github.com/CommanderTurtle/firebending](https://github.com/CommanderTurtle/firebending) · [macrohelp & macrohard](/blog/2026-06-11-macrohard/) · [regedited](/blog/2026-06-08-regedited/)

---

#### xkcd of the day, 7/16 - Time Change #3272

![xkcd of the day](https://imgs.xkcd.com/comics/time_change_2x.png)

[[can plain text actually print like a real document]](https://www.turbotype.app/)

"""

let render() = file
