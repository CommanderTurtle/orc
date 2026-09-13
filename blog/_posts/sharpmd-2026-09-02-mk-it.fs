module Bl0g.Posts.N20260902MkItMd

let file = """---
layout: post
title: "mk.it: Private Browser-Based Conversion, OCR, Base64, and Archive Tools"
author: "CommanderTurtle"
date: 2026-09-02 04:00:00 +0000
tags: [project, web-tools, typescript, bun, ocr, privacy]
---

Most online file converters are boring and insecure: they convert between two formats of the same medium, and they make you upload the file to someone else's server first. The upstream project [p2r3/convert](https://github.com/p2r3/convert) — the engine behind convert.to.it — attacks both problems with a fully client-side conversion graph that treats the file as the *media* it represents, not the bytes it contains. **mk.it** is my fork of it, deployed at [app.shel.sh/make](https://app.shel.sh/make/), and the story of this post is a four-day burst in early September 2026 in which I layered four new workflows beside the original converter, then wired the result into the sHEL document pipeline.

## What the Fork Keeps

The upstream engine is the interesting part, so it stays intact. At the time of writing it sits at 644 commits on master with roughly 4,000 stars and 383 forks — a genuinely popular side project for something this niche. Every conversion tool is wrapped in a handler that normalizes its inputs and outputs; a breadth-first search builds a path between any supported input and output format through those handlers, with a MIME-type database resolving extensions. Cross-medium conversion is the whole point — the README's challenge: convert an AVI video to a PDF in your browser, "I dare you." The graph traversal means AVI → (intermediate media) → PDF instead of demanding a direct pair. Upstream even ships a semi-technical overview video ([youtu.be/btUbcsTbVA8](https://youtu.be/btUbcsTbVA8)). GPL-2.0, Bun + Vite, handlers vendored as git submodules, and a famously strict issue culture:

> **SIMPLY ASKING FOR A FILE FORMAT TO BE ADDED IS NOT A MEANINGFUL ISSUE!**

Suggesting a format requires checking existing issues, explaining what medium the conversion lands in (simply parsing the underlying data "is not sufficient"), linking an existing browser-based solution or at least an implementation reference, and confirming the license is compatible with GPL-2.0 — because "a developer will have to do 100x more work to actually implement the format." Even the bug-report rules carry a joke: "converting X to Y doesn't work" is *not* a bug report; "converting X to Y works but not how I expected" likely *is* one.

The contributing guide reads like a design philosophy, and it rhymes with this blog's obsession with wrappers. Each conversion tool "has to be normalized to a standard form - effectively a 'wrapper' that abstracts away the internal processes." Handlers must leave byte buffers unmutated, run MIME types through a normalizer before matching, and — most importantly — "treat the file as the media that it represents, not the data that it contains." An SVG handler converts an *image*, not an XML document; crude "binary waterfalls" are semantically meaningless and get rejected. There's even an explicit AI usage policy for contributors: disclose LLM usage in the PR, keep the scope to things you could do by hand, and never reach a scenario where you *need* the LLM. Governance documents this specific are rarer in four-thousand-star projects than they should be.

## Five Workflows on the Home Page

The fork expands the home page while keeping the original converter working exactly as before. Live, the panels read plainly — "Use the original universal conversion graph," "Recognize text locally with Tesseract WebAssembly," "Combine ZIP or TAR source trees; mark binaries omitted" — no marketing layer between you and what the bytes do:

| Workflow | What it does |
|----------|--------------|
| **Convert a file** | The original workflow, plus copy-any-file-as-MIME-correct-Base64-data-URL without touching its bytes |
| **Base64 file** | Decode raw base64 or a data URL, or encode a selected file; an Include-MIME switch picks between data URL and plain base64; a decoded ZIP/TAR continues straight into the archive pipeline |
| **Shared files** | A versioned `#share:` URL fragment carrying level-9 DEFLATE-compressed metadata plus the exact file bytes in URL-safe base64 — decoded locally in the recipient's browser, **never sent in the HTTP request**; text gets highlighted copyable source, SVG gets source and image views, media and PDF get native previews with a full-window expander and copyable self-contained HTML, images additionally expose ln.kr's pan-and-zoom viewer, HTML/Markdown get a direct `#p:` preview URL |
| **Image OCR** | Pinned Tesseract.js 7 worker with the WebAssembly core and English language assets copied into the static build — no CDN; formats the browser can't read are first normalized to PNG through the upstream conversion graph; results render in an isolated viewer with a selectable text layer plus a plain-text view |
| **Archive to Markdown** | Reads ZIP/TAR in memory, sorts paths, keeps text inside extension-aware code fences, marks binary or oversized entries `(omitted)`, and emits a copyable/downloadable `combined.md` — bounded at 20,000 entries, 512 MiB expanded, 8 MiB per text file, 64 MiB combined, so an archive bomb can't take the tab down with it |

The invariant across all five: nothing uploads, nothing extracts to a filesystem, nothing phones home. Sharing a 40 MB scan means a long URL, not a file host.

## The Shape of the Repo

Same pattern as the context-mode fork: a mirror with an overlay. Main carries 635 commits from December 2025 through September 2026. Upstream master currently holds 644, and the fork mirrors 623 of them — so at the time of writing the mirror trails upstream by roughly two weeks and twenty-one commits, and the twelve commits sitting on top are mine, all between September 2 and September 5:

- **Sept 2** — `feat: add base64, OCR, and archive tools`, then `feat: brand the fork as mk.it under /make`, followed by the Bun pass: auditing, and the error corrections that come with trusting `tesseract.js`, `@parcel/watcher`, `puppeteer`, and friends in a Bun workspace (`bun pm trust` for each)
- **Sept 3** — self-contained file sharing, local file checksums, the Bun-specific install instructions, base64 uploads with direct document previews, the interactive image viewer on shared files, and restoring native Edge PDF previews
- **Sept 5** — project navigation and the ln.kr text handoff

The February 2026 spike of 385 commits belongs to upstream; p2r3 accounts for 239 of the 635 total, alongside a small contributor community.

Tests follow the workflows. Upstream keeps two tiers: broad project-level suites in `test/` (graph traversal, end-to-end conversion smoke tests) and opt-in handler unit tests in `test/handlers/` following a `<handlerName>.test.ts` pattern. The fork adds repo-owned tooling and UI suites — `bun test test/tooling.test.ts` and `bun test test/ui.test.ts`, named explicitly so Bun doesn't discover framework-specific tests inside the vendored handler submodules — plus an opt-in OCR end-to-end run (`RUN_OCR_E2E=1`) that generates a local fixture and verifies the real worker, core, and trained-data path without contacting a Tesseract CDN.

## Running It Yourself

Local development is deliberately fiddly in the best way: clone **with submodules** (omitting them leaves dependencies missing), `bun install`, `bunx vite`. The first page load spends a long time generating the list of supported formats per tool; once the console prints `Built initial format list`, call `printSupportedFormatCache()` and save the JSON to `cache.json` to skip that screen on every future start. The prebuilt Docker image serves the finished app at `http://localhost:8080/make/`; the compose override that builds locally is slow on the first run because the build stage installs Chromium for `buildCache.js` (puppeteer), and fast afterwards thanks to layer caching.

## Wired Into the Orbit

The last commit is the one that makes it part of the sHEL family instead of a standalone fork. Shared Markdown, HTML, JavaScript, and TXT files expose an **Edit** action that opens the decoded text in [ln.kr](https://a.shel.sh/) in a new tab (its "Edit a copy" flow does the rest — the v4 document link is generated on click, JavaScript never auto-runs), and the header links out to ln.kr and [Webclip](https://app.shel.sh/webclip). Deployment is static: the Docker compose serves the build under `/make/`, which is how it lands on app.shel.sh. A fork of a converter becomes a node in the document pipeline: Webclip scrapes, mk.it converts and shares, ln.kr edits and links.

[github.com/CommanderTurtle/mk.it](https://github.com/CommanderTurtle/mk.it) · [app.shel.sh/make](https://app.shel.sh/make/) · [github.com/p2r3/convert](https://github.com/p2r3/convert)

---

#### xkcd of the day, 9/2 - Handedness #3293

![xkcd of the day](https://imgs.xkcd.com/comics/handedness_2x.png)

[[intro to the fediverse]](https://en.wikipedia.org/wiki/Lemmy_(social_network))

"""

let render() = file
