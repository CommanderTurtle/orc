module Bl0g.Posts.N20260827LocalflameMd

let file = """---
layout: post
title: "localflame: The Web Search That Never Calls Home"
author: "CommanderTurtle"
date: 2026-08-27 04:00:00 +0000
tags: [project, search, firecrawl, self-hosted, mcp, deepseek]
---

The DeepSeek Harness ships with exactly one web-search provider, and it's the cloud one. `dsh-web-search-deepseek`, id `deepseek-official`, pointed at DeepSeek's API and gated on `DEEPSEEK_API_KEY`. There is no fetch backend in the box at all — `tool-web` ships with `fetch: false`, and the `web-fetch-http` package isn't even installed. Which means the honest description of the stock harness's web capability is: a search button that works if you pay, and a fetch button that doesn't exist. localflame is the answer to that: a tiny, self-hosted [Firecrawl](https://firecrawl.dev) web **search + fetch** provider for the DeepSeek Harness (`dsh`, the `dsh-web` GUI served by `@deepseek-ai/dsh-web-app`) that routes the harness's native `web_search` / `web_fetch` tools at your own unauthenticated Firecrawl instance. Zero auth. And it started, very specifically, with a 401.

## The 401 That Started This

The before-state was a hand-added, cloud-only Firecrawl provider pointing at `api.firecrawl.dev` with a bad key. `web_search` came back with:

```
Error: Firecrawl search failed (HTTP 401): Unauthorized: Invalid token
```

Meanwhile, a healthy **zero-auth** local Firecrawl instance was already sitting on port 3002, answering real queries with no header at all:

```bash
curl -s http://127.0.0.1:3002/                          # {"message":"Firecrawl API",...}
curl -s -X POST http://127.0.0.1:3002/v2/search  -d '{"query":"github","limit":1}'   # real results, no auth
curl -s -X POST http://127.0.0.1:3002/v2/scrape -d '{"url":"https://example.com"}'   # real markdown
```

The fix was never going to be a better key. The fix was a provider that stopped sending one.

## What Stock DSH Actually Ships

Before writing anything, the project read the installed code — the `@deepseek-ai/*` packages under the global bun install — and the picture it produced is worth keeping:

- The only search provider in the box is `dsh-web-search-deepseek` (cloud-only). No Firecrawl provider. No fetch provider.
- `dsh-base/cordis.patch.yml` sets the defaults: `web` → `searchProvider: deepseek-official`, `web-search-deepseek` → `apiKeyEnv: DEEPSEEK_API_KEY`, and `tool-web` → `fetch: false`. Fetch is off *by default*.
- `web-fetch-http` isn't installed, so even a fetch flip would have had nothing behind it.

So the actual work decomposed into: add a Firecrawl search **and** fetch provider, select it in the seam, and turn `tool-web.fetch` on. Each of those three turns out to have a trap.

## The `ctx.web` Seam

DSH exposes web access as a **service seam** (`ctx.web`), not a hardcoded function. Backends register as search and fetch providers; a provider is an object with an `id`, an `available()` method that must be a cheap local check and *must not hit the network*, and the `search`/`fetch` methods themselves. The model-facing tools `web_search` and `web_fetch` live in `dsh-tool-web`, which merely formats the seam's result — it never owns provider selection or network access. Provider selection comes from config (`web.searchProvider` / `web.fetchProvider`) or the `DSH_WEB_SEARCH_PROVIDER` / `DSH_WEB_FETCH_PROVIDER` environment variables, and with nothing set the seam auto-selects the single registered usable provider. Failures map to typed `WebError` codes — `WEB_PROVIDER_CONFIGURED_MISSING`, `WEB_PROVIDER_AMBIGUOUS`, and friends — rather than generic exceptions.

The README documents this model because it was reverse-engineered, and it cross-checked the approach against how two other agents on the same machine already wire Firecrawl: **Hermes** runs a `FirecrawlWebSearchProvider` with a `_KeylessFirecrawlClient` that POSTs to `/v2/search` and `/v2/scrape` with no `Authorization` header at all, and **OMP's pi-coding-agent** resolves its endpoint from `FIRECRAWL_BASE_URL` / `FIRECRAWL_API_URL` and omits the header entirely in keyless mode. localflame is the same pattern, done natively as a DSH provider instead of bolted onto someone else's harness.

## The Two Traps

**Trap one: the patch shape.** The first attempt registered the plugin as a plain top-level row in the profile's `cordis.patch.yml`:

```yaml
- id: web-firecrawl-local        # WRONG for a brand-new entry
  name: '@local/dsh-web-firecrawl'
```

After a restart: `Error: configured web provider "firecrawl-local" is not registered`. That error is the smoking gun — the `web` override *had* applied (the seam now wanted `firecrawl-local`), but the plugin row never mounted. Reading `applyEntryPatches` in `@deepseek-ai/dsh-app-boot` explains why:

```js
const target = entryMap.get(id);
if (!target) { warn("patch: entry % not found", id); continue; }  // silently skipped
```

Top-level patch rows **only override existing entries**; a brand-new id is dropped with a warning nobody reads. New entries must use `- insert:`. The working shape is a top-level `web` row (an override of an existing id) plus an `insert` for the provider entry itself.

**Trap two: resolving is not mounting.** The second failure mode was subtler — the plugin resolved as a bare module from the profile directory, imported cleanly, exported exactly `{ apply, inject, name }`, and still didn't mount. The code was right; the wiring was the problem. The lesson generalizes: in a layered loader, "my module imports" and "my module is loaded" are different claims, and only the second one produces behavior.

And there's a third, quieter trap hiding in the fetch flip. You'd naturally try `tool-web → fetch: true` in the profile patch. That merges into the host `tool-web` row — but the web-app ships that row `disabled: true`, and the tools a session actually sees are mounted **per-session by the agent preset**, where every shipped preset (`standard`, `code`, `cordis`) forces `fetch: false`. A profile-patch flip is a silent no-op. The real lever is the preset: localflame flips `fetch: true` inside the three presets you actually use (Standard, PTC, Creator), each backed up to `*.localflame.bak`, and keeps the profile patch minimal — select the provider, disable the cloud search provider, done.

## The Provider Itself

Ported from [`firecrawl/dsh-firecrawl`](https://github.com/firecrawl/dsh-firecrawl) (MIT, with full attribution in `ATTRIBUTION.md`, relicensed AGPLv3 at the repo root), the provider exposes the Firecrawl v2 surface:

- **Search** (`POST /v2/search`): source selection, result limits, `scrapeContent`, domain include/exclude lists, Google-style freshness qualifiers (`qdr:h/d/w/m/y`), geo-targeting, and a 60-second timeout.
- **Fetch** (`POST /v2/scrape`): markdown or HTML output, main-content stripping, ad and cookie-banner blocking, wait-before-capture for slow client-rendered pages, mobile emulation, proxy pass-through, a 100k-character decoded-body cap that sets a *real* `truncated: true` flag, and a 2048-character URL limit.

On top sits a safety and typing layer that's always on, independent of configuration: `assertFetchableUrl` rejects `file://`, non-HTTP(S) schemes, embedded credentials, and over-long URLs **locally, before any request leaves the process**; fetch returns the page's real `metadata.statusCode`, so a 404 is a *result* (`statusCode: 404`) rather than a thrown error; failures carry typed `WebError` codes (`WEB_ABORTED`, `WEB_INVALID_URL`, `WEB_PROVIDER_ERROR`) with the seam's structured metadata preserved; and the transport is `redirect: 'error'` with no `Authorization` header — `available()` is always true, because there is no API key to gate on.

## Eleven Commits, One Night

The history is compressed in the way the problem demanded — no time for architecture debates when a 401 is sitting in the terminal:

- **August 27, 07:51 UTC** — first commit announces the whole project in its subject line: "localflame: zero-auth self-hosted Firecrawl web search+fetch provider for DeepSeek Harness (AGPLv3)". Seven minutes later, the initial commit.
- **Evening of August 27, 17:22–17:35 UTC** — fourteen minutes of focused hardening: the Firecrawl feature flags ported into one robust plugin, MIT attribution and modification notes, install-time config flags for both tools, the feature matrix and upstream citation, and a restored executable bit on `install.sh` (the classic Windows-born-script bug).
- **19:11 UTC** — `web_fetch` exposed through a `standard-fetch` agent preset.
- **22:22 UTC** — the clone-and-preset-creating installer removed; simplified to zero-config.
- **August 28, 00:50 UTC** — push update. **01:46 UTC** — PR #1 merged.

Born in the morning, hardened by night, merged just after midnight. Eleven commits across eighteen hours, AGPLv3, Node `^22.19.0 || >=24.0.0` to match what the harness itself demands. If your `web_search` ever says "Invalid token" again, the reason is now a choice, not a limitation: the flame stays local, and it doesn't call home.

[github.com/CommanderTurtle/localflame](https://github.com/CommanderTurtle/localflame) · [persephone](/blog/2026-08-04-persephone/)

---

#### xkcd of the day, 8/27 - Trade #3290

![xkcd of the day](https://imgs.xkcd.com/comics/trade_2x.png)

[[how to pack proper]](https://erich-friedman.github.io/packing/)

"""

let render() = file
