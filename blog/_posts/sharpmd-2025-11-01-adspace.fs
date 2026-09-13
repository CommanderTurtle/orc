module Bl0g.Posts.N20251101AdspaceMd

let file = """---
layout: post
title: "adspace: The Redirect Engine That Could (Still)"
author: "CommanderTurtle"
date: 2025-11-01 09:00:00 +0000
tags: [side-project, adspace, redirect, templates, interstitial]
---

Every project starts with a template. A blank canvas. A `index.html` and a dream. **adspace** started exactly that way — announced on November 1, 2025 as a single interstitial template called *Hillscape Journey*, with a bigger promise attached: a pluggable redirect engine with a template marketplace. This is the full account of what that experiment became, including the parts the announcement can no longer see.

## What Was Announced

The [original post](https://shel.sh/blog/2025-11-01-adspace/) described a redirect-engine template at `shel.sh/projects/adspace/templates/1`: a scenic hillscape background with a subtle counter. Simple. Peaceful. Deliberately minimal. The idea: **interstitial redirects** — those 5-to-15-second moments between clicking a link and arriving at the destination — deserve better than "please wait."

The long-term plan was three layers:

| Layer | Role |
| --- | --- |
| **Template Layer** | HTML/CSS/JS interstitial designs with configurable parameters — background, timer duration, transition animation, optional interactive elements. Themes for the space between pages. |
| **Redirect Layer** | Fast, tracked URL shortening with analytics: click counts, dwell time on the interstitial, completion rate to the final destination. |
| **Ad Insertion Layer** | Optional sponsored content, constrained to be as pleasant as the default templates. No flashing banners. No auto-playing audio. |

The philosophy underneath: most ad tech is hostile — it interrupts, distracts, and degrades the experience. adspace was an experiment in the opposite: **advertising as ambient art**. If someone is going to wait five seconds for a redirect anyway, that time can be either empty and frustrating, or filled with something worth looking at.

## Where the Code Actually Lives

Seven months after the announcement, I audited the record, and the first finding is that the announcement's own links are stale. Its GitHub directory (`projects/adspace` on `CommanderTurtle.github.io`) never appears in that repository's commit history — no tree, no commits, on either branch — and the template URL it pointed at now returns GitHub Pages' "File not found."

The code is real, though. It lives in `orc`, under [`app/adspace/templates`](https://github.com/CommanderTurtle/orc/tree/main/app/adspace/templates) — a sibling of the other app-surface projects (`countku`, `dash`, `loosescrew`, `love`, `support`, `wasm`) under `app/`. There are two templates, and each is a single Zensical F# `index.fs` rendered through Giraffe's view engine — the same strongly-typed pipeline as the rest of sHEL, not a hand-written `index.html`.

## The Timeline, From the Commit Log

| Date | Commit | What happened |
| --- | --- | --- |
| Nov 1, 2025 | — | Announcement published; template #1 described as hillscape background plus counter |
| Jun 20, 2026 | `d315ca7` — Add files via upload | adspace lands in `orc/app/` alongside the other app projects |
| Jun 20, 2026 | `f7b4e7e` — Delete app directory | the whole `app/` tree is wiped the same day, mid-restructure |
| Jun 21, 2026 | `1c7ad2d` — Upload update | full `app/` tree re-uploaded — both adspace templates restored, template #1 revised |
| Sep 12, 2026 | — | both templates verified live on the app surface |

The delete-and-reupload day is the boring middle of this story: the app surface was being reorganized, and adspace came back the next morning with everything else.

## What Shipped Versus What Was Announced

The announcement said "a scenic hillscape background with a subtle counter." What the June code ships is considerably more.

**Template 1 — Hillscape Journey.** An animated pixel-art scene: parallax rolling hills, drifting clouds, birds, and a yellow bus that pulls up to the stop while a countdown reads "NEXT BUS IN" — fifteen seconds, ticking down (not counting up from 11.20, which was the v0 number in the November post). Two billboards stand on the hills: one says **"Your Content"** — the Ad Insertion Layer made literal, a reserved slot — and the other says "Coming Soon." When the countdown ends, the scene cuts to a destination screen: "You have reached your destination," a Continue to Destination button, and an automatic redirect — which still points at the placeholder `example.com`. A small state machine drives the whole thing: WAITING, ARRIVING, STOPPED, DONE.

**Template 2 — Cinema Roll.** A different register entirely: a 16:9 video interstitial ("Epic Adventure Awaits") with loading and error overlays, a progress bar, a Play Now button, and a Claim Reward button with explicit locked and unlocked states. Countdown fixed top-right, end screen with a continue button when it finishes. Same single-file Zensical F# format, same pixel-font chrome.

The template numbering is the marketplace in embryo: `templates/1`, `templates/2` — add a directory, add a theme. What is missing is the Redirect Layer: no tracking backend, no slot bidding, no analytics yet. The interstitials work as static pages today.

## Why the Old URL 404s

The 2026 rebuild split the shel.sh site into separate surfaces — docs, app, blog — each deployed from `orc` by its own workflow. The announcement URL lived under the old monolithic site layout (`shel.sh/projects/...`), and nothing in the new pages source tree carries that path. The project did not die; it moved house, and the announcement never got the forwarding address. It still points at the old door.

## What Survives

The design constraints did. "Advertising as ambient art" turned out to be implementable: a billboard reading "Your Content" is a cleaner statement of the Ad Insertion Layer than any spec. Interstitials deserve better than a spinner, and two working themes prove the Template Layer. What remains is the Redirect Layer — tracking, dwell time, completion — because a template marketplace without measurement is just a gallery.

Until then, the bus keeps pulling up on schedule, the counter keeps its place, and template #1 waits at its new address.

[github.com/CommanderTurtle/orc/app/adspace](https://github.com/CommanderTurtle/orc/tree/main/app/adspace) · [app.shel.sh/adspace/templates/1](https://app.shel.sh/adspace/templates/1/) · [the original announcement](https://shel.sh/blog/2025-11-01-adspace/)

---

#### xkcd of the day, 11/1 - Heart Mountain #3162

![xkcd of the day](https://imgs.xkcd.com/comics/heart_mountain_2x.png)

[[what actually happened to geocities]](https://en.wikipedia.org/wiki/GeoCities)

"""

let render() = file
