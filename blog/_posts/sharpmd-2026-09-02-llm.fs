module Bl0g.Posts.N20260902LlmMd

let file = """---
layout: post
title: "llm: A Chat Interface With No Backend To Own"
author: "CommanderTurtle"
date: 2026-09-02 04:00:00 +0000
tags: [project, llm, static, browser, mcp, firecrawl]
---

Run an unauthenticated OpenAI-compatible service — vLLM is the canonical example — and serve a folder of static files. That's the whole deployment story for llm: a static browser agent harness for OpenAI-compatible models running on localhost or a private LAN. There is no application server, no account, no API-key field, no telemetry, and no cloud database. Persistent state lives only in that browser profile's IndexedDB, and network traffic goes only to endpoints the user explicitly configures and invokes. `bun run dev`, open `http://127.0.0.1:4173/`, point the default `http://localhost:8000/v1` somewhere (or type a model id by hand), click Connect, and **Send** becomes `POST /v1/chat/completions` with streaming enabled. When the harness connects it shows you the exact `GET /v1/models` target, and if discovery takes longer than twelve seconds it stops trying rather than hanging indefinitely.

## The Baseline Is Deliberately Small

What you get before touching a single opt-in:

- multiple named, resumable chats — new, switch, rename, delete — with automatic IndexedDB persistence for chats, drafts, settings, attachments, tool turns, and integrations;
- complete workspace JSON import/export, plus legacy single-conversation import;
- active-chat Markdown export and browser print/save-to-PDF;
- streaming and non-streaming completions with reasoning, final text, usage, finish reason, and tool calls kept as separate fields;
- generation controls for temperature, top-p, max tokens, seed, `reasoning_effort`, and `chat_template_kwargs.enable_thinking`;
- per-turn copy, edit, and delete — and the visible edited transcript *is* the transcript sent on later requests;
- bounded model/tool continuation with approval before every call by default.

And the refresh contract is the quiet guarantee: refreshing the page resumes the last workspace but does **not** reconnect to a model, Firecrawl, or MCP server, and issues no unsolicited network request. A static page that phone-homes on load isn't static.

## An Opt-In Matrix With A Contract

Every enhancement starts disabled and persists in browser state, and the README defines the contract explicitly: **Clear all** restores the last baseline release's request and interaction behavior — the 8192-token output allowance, one foreground generation, the original Markdown renderer and scrolling, the original deletion behavior, and only the previously enabled OCR/Firecrawl/MCP tools. Nothing silently enables a dependent tool; the single documented dependency is that write tools also enable their required read tools. Checkboxes support drag-painting across rows and Shift-click functional groups, because toggling nine features individually was getting silly.

A few entries show the taste:

- **Interrupted-response recovery** distinguishes a real terminal signal from a clean premature EOF, empty output, or `finish_reason: length`, preserves the partial output, and offers *Continue* — without adding a timeout to the healthy path.
- **Server-decided output allowance** omits `max_tokens` entirely so the endpoint chooses its own allowance; turning it off restores the fixed 8192. The client never computes a number it doesn't understand — it either sends a value it owns or sends nothing and lets the server decide.
- **Parallel chats** let independent sessions keep generating while you switch between them. Each session owns its own request and Stop action, its status marker is static, and streaming mutates only stable text nodes inside the active assistant card — no per-token session-list repaint, no Markdown re-parse, no card replacement.
- **Vision resize recovery** reacts to an image-dimension `ValueError` by retrying with browser-only projections reduced by exactly 128 pixels on the longest side until accepted; the stored originals never change.
- **Complete Markdown export** makes download, Copy, and the lazy local `a.shel.sh` link produce one complete document: every native turn, reasoning block, tool request/result, attachment reference, and compaction record retained regardless of what the API projected.
- **Composable context controls** pair per-chat *Soft* actions — Firecrawl indexing, completed context-read collapse — with user-selected *Normal* summarization. Each soft action has an *Auto* checkbox: on the first context-limit error, enabled actions run and the existing Continue path retries once. New groups compose with earlier active groups instead of reopening them, and exact originals stay stored so they can be restored independently or together.
- **Scraped image reads** expose a source-bound `view_image` only for image URLs discovered in earlier stored Firecrawl results, with the approval view showing the source and subsection.

The September 8 additions round it out: indexed scrape-media tools with efficient streaming, a feature-matrix auditing pass, and auto context recovery.

## Nine Commits In A Week

Born **Tuesday, September 2, 10:55 UTC** ("Build static local LLM harness"), the persistent agent shape followed that night at 23:08, browser-access fixes landed early Wednesday, canonical local-network permissions by 15:47, opt-in workspace features on September 7, and the media/streaming/audit/optimize cluster closed it out on September 8. Nine commits, one week, static end to end — a harness whose entire backend is the browser profile it runs in.

[github.com/CommanderTurtle/llm](https://github.com/CommanderTurtle/llm)

---

#### xkcd of the day, 9/2 - Handedness #3293

![xkcd of the day](https://imgs.xkcd.com/comics/handedness_2x.png)

[[pegasus bringing doom to iphones]](https://en.wikipedia.org/wiki/Pegasus_(spyware))

"""

let render() = file
