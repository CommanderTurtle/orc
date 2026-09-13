module Bl0g.EventsAiEngineerMiamiMd

let file = """---
layout: post
title: "AI Engineer Miami: Two Days in ER Glasses"
author: "CommanderTurtle"
date: 2026-04-20 04:00:00 +0000
tags: [life, ai, conference, miami, even-realities]
---

**April 20&ndash;21, 2026. Downtown Miami.** At the time I was turtleprotect.org &mdash; a measly personal domain, now captured in time at [vibe.shel.sh](https://vibe.shel.sh). [AI Engineer Miami](https://www.ai.engineer/miami/2026) &mdash; the first time the event touched down in South Florida &mdash; brought together 500+ AI engineers, CTOs, and VPs of AI as the opening act of Frontier Tech Week. I stayed for the first two days, wore the "Turtle Protect, CEO" lanyard the entire time, and spent a significant portion of both watching other people's faces do things with [Even Realities G2](https://vibe.shel.sh/db/even-realities-g2/) glasses.

## The Lanyard

The badge said **Turtle Protect, CEO**. This was accurate. The company behind [vibe.shel.sh](https://vibe.shel.sh) &mdash; the descendant of the [forked Hacker theme](/events/first-site-online/) that went live two months earlier &mdash; is still a Florida-based project in the sense that a one-person operation with a domain and a turtle mascot can be. Wearing the lanyard at a 500-person AI engineering conference was either a power move or a liability. Depending on who asked, it was both.

## The Room

The schedule was dense and genuinely good. Day 1 opened with [Dax Raad](https://x.com/dax) (OpenCode co-founder) arguing "You Don't Have Any Good Ideas," then Dexter Horthy (HumanLayer) taking apart Research/Plan/Implement at scale &mdash; control flow instead of prompting, and a frank list of what his team got wrong trying to roll context engineering out across hundreds of repos. The rest of the day ran through a developer-experience-taste panel with Max Stoiber (OpenAI, ChatGPT Apps), Ben Vinegar (Modem) on [running coding agents over SSH](https://www.ai.engineer/miami/2026) &mdash; remote machines that stay up 24/7, tmux sessions, agent-native review workflows &mdash; and Shashank Goyal (OpenRouter) showing what billions of real-world requests actually look like versus the benchmarks. [Kent C. Dodds](https://kentcdodds.com/) and Geoffrey Huntley (Latent Patterns) were in the room too, along with speakers from Cloudflare, Baseten, Agentuity, Cursor, Arize, and Google DeepMind.

What struck me, coming from the local-first side of the fence: the whole industry was converging on the same conclusions the small tools orbit reached on its own. Context is the load-bearing resource. Tool output needs sandboxing before it reaches the model ([context-mode](/blog/2026-09-12-context-mode/) does this locally, with receipts). Search infrastructure wants to stop phoning home ([localflame](/blog/2026-08-27-localflame/) does this for Firecrawl). Sessions want to survive compaction. The keynote-track version of these ideas had the production-scale numbers attached; the garage version had the working code. Both were right.

## The Glasses

The expo floor had a crowd in **ER glasses** &mdash; Even Realities G2 units, and the reason they stood out is that the ecosystem running on them is open source and scrappy in the best way. My own tracking page for it ([vibe.shel.sh/db/even-realities-g2](https://vibe.shel.sh/db/even-realities-g2/)) lists the half-decent apps that survived contact with reality: **Tetris, Snake, Pong-vs-AI, and Arachnoid** &mdash; each with a global scoreboard, installed by scanning a QR code off a GitHub repo; **Books G2**, a Gutenberg library in your field of view; **Tesla vehicle controls**; a weather forecast; chess; a Home Assistant/HomeKit bridge; an ePub reader; Soniox speech-to-text memos; a Twitch chat HUD; a gym plan app. One of them, **Glint**, is an OpenClaw AI HUD.

Watching someone clear lines of Tetris on their face while walking the expo floor is a specific kind of future that feels closer than most futures. The page footer says it flatly: *"Turtle Protect is a florida-based project. 🐢"* At the time of writing, that sentence is doing more brand work than any lanyard.

## The Theo Situation

I first heard about the event from [ThePrimeagen's "Yacht Problems"](https://www.youtube.com/watch?v=alK8hgHgxd4) &mdash; the official music video, of all things &mdash; and I never saw ThePrimeTime on the floor (I'm not even sure he went). Which makes the Theo business funnier. Mid-conversation someone dropped "Theo's here, btw," and I lit up &mdash; because at the time the only Theo I knew was ThioJoe, the small-but-great Microsoft Windows YouTuber. Nobody had told me that "Theo" in this room meant **Theo T3**. The speaker list did include him, buried next to **Ben Davis** of T3, whose listed title is literally **"Theo's Manager"** &mdash; but I read the room's Theo as a different person entirely, and I missed him completely. A two-day expo floor defeats any single human's pathing; the real failure was that I didn't know which Theo people meant.

The following month, while the AI-development weeks rolled, I genuinely learned who Theo T3 is. The first video I watched of him was him explaining what a harness actually is &mdash; it came out toward the end of that week &mdash; and by then the irony had fully set in: I'd been in a room where he was walking around, and I'd been thinking of a completely different Theo.

## The Best Part

What was best about the event were the friends I made along the way. All of us walked in with our own prospective "big" ideas. Everyone starts out as just small-time coders. That turned out to be the point.
"""

let render() = file
