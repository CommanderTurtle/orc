module Bl0g.Posts.N20260810MmToolsMd

let file = """---
layout: post
title: "mm-tools: Cutting Out The Cloud"
author: "CommanderTurtle"
date: 2026-08-10 04:00:00 +0000
tags: [project, agpl, music, video, local, gpu, workstation]
---

The README has a line that states the entire project: "The ability to self-host a tool rivaling Adobe in 2026 was the purpose for this repo." mm-tools is the attempt at scale — a pruned, local-first multimedia workstation monorepo that bundles the runtime source, per-project setup entrypoints, and browser/CLI frontends for a dozen-plus local inference projects, and deliberately excludes everything else: no checkpoints, no virtual environments, no caches, no generated media, no training or evaluation material. Runtime inference is local. The network is involved only while installing or downloading model artifacts, and each downloaded model stays under its own native license. It is, in one sentence, "the all-in-one frontend for local multimedia inference. Cutting out the cloud."

The licensing stance is as deliberate as the architecture: pruning from tracked sources lives in **one AGPLv3 monorepo under a single root LICENSE, with no nested project licenses**. The stated reason — "created for protecting open-source runtimes under a documentable heirarchy with AGPL" — is doing real work: when the whole suite sits under one copyleft umbrella, the boundary between your adapters and the upstream runtimes is documented instead of inferred.

## The Inventory

The project pages tell what the workstation actually covers:

- **Voice cloning** — LongCat, running around 8–9 GB of VRAM, behind a private local workstation service.
- **Translation** — an in-house pipeline with a native web UI and a resident local EraX vision lane, compatible with the [vox](https://github.com/CommanderTurtle/vox) system-audio driver.
- **Speech-to-text** — CrisperWhisper, also vox-compatible, with every language flag exposed.
- **Video compression** and **video-to-GIF/AVIF** — because, as the README puts it, "who says ffmpeg is fine in cli?"
- **Background removal → AI-perfect SVG** — ObjectClear/Object Remover feeding [img2svg](https://github.com/CommanderTurtle/img2svg), with lasso selection, seeded edits, and local alpha masks that preserve crop geometry.
- **Asset separation** — qwen-layered layer decomposition for redesign work, run directly through Diffusers.
- **Music** — the deep end: generation, singing, orchestration, OMR, and transcription across ACE-Step, Stable Audio Foundation, SymphonyGen, VocalRender, MuSViT, and MuScriptor (the two score studios), plus MiniMax Music 3.
- **Underbelly** — the quiet one: multilingual routing integrated mid-August, YouTube transcript extraction arriving as the final commit of the project.

The honest hardware note: roughly 16–20 GB VRAM recommended for most tools, 24–32 GB for the largest quality-first music paths, and a monitor. With a 5090 the README's answer is "run all at once."

## How The Install Actually Works

There is no install *of* the workstation — there's a checkout, a one-time checkpoint pass, and per-project setup:

```bash
git clone https://github.com/CommanderTurtle/mm-tools multimedia && cd multimedia
cd models
uv run download_models.py   # choose workers, pick project bundles (or all)
```

The downloader is resumable, tracks a stateful model directory, and runs non-interactively (`all --yes --workers 24`) if you prefer. Then per project: `./setupwithuv` creates the ignored `.env` and an isolated `.venv`, and `./startwithuv.sh` starts it. Host prerequisites are `uv`, `ffmpeg`/`ffprobe`, `bun` (with [sandwich](https://github.com/CommanderTurtle/sandwich) optional), Rust/Cargo for `img2svg` and the CrisperWhisper launcher, and WSL on Windows. The README even warns you to sit on a speedy drive before the checkpoint pass, because model weights are the one dependency with a size.

The interesting architectural split landed in the first burst: browser sessions and HTTP model lifecycles are **separate things** — the commit appears twice in the morning, which tells you how central it was. The UI can come and go without tearing down the model process, and generated audio gets hoisted into the vox router rather than being wired per-project. That's the difference between a demo page and a workstation.

## The Burst, Minute By Minute

August 10, 02:35 UTC: the first commit integrates local Ideogram ComfyUI nodes, and the next ninety seconds are a cascade of "cloned pruned checkout `<pinned-sha>`" commits interleaved with "build local X workstation runtime" — Ideogram object editing, MuSViT, MuScriptor, the private LongCat voice service, the private CrisperWhisper service, ReDesign layered editing, video-compact, video-to-gif-avif, img2svg. At **02:50** the founding act lands: "prune portable multimedia runtime monorepo". The pruning *is* the project — a month of standalone runtimes compressed into one tree with the checkpoints, venvs, and caches cut out.

Then the burst starts paying attention to detail. A Kijai V2V compatibility workflow arrives at 02:39 and is **removed from the monorepo at 03:26** — forty-seven minutes of residence, gone when it didn't fit. At 03:26, in a single minute, nine commits document the runtime architecture of every project in the tree (CrisperWhisper, video animation, Video Compact, ReDesign, MuSViT, MuScriptor, LongCat, img2svg, Ideogram), followed by required model locations. Documentation treated as a build step, not an afterthought. By 03:55 the setup entrypoints are restored per project and the quickstarts simplified; by 05:01 the standalone workbenches exist (MuSViT local score server, Translate browser workbench, MuScriptor score studio) and img2svg ships native Rust launchers; by 08:49 WebM is a direct animation output. The day ends at 10:55 with five consecutive README commits twenty-five minutes apart — the surface area settling into words.

Seventy commits. Eight hours and twenty minutes. Twelve projects, each with a setup entrypoint, an architecture document, and a place in the tree.

## The Music Day, Then Three Weeks Of Manners

August 20 was the second burst — twenty-two commits from 09:33 to 18:33, all music: portable offline workbenches for ACE-Step and Foundation-1, offline browser studios for SymphonyGen and VocalRender, the pruned Comfy MiniMax runtime imported at a pinned SHA, the standalone MiniMax Music 3 studio, each music runtime's dependency graph resolved exactly once, and model downloads made selectable and portable.

Everything after that is polish, and it reveals what a workstation is *for*:

- **August 21** — a guided MiniMax music brief lab; README links reconciled against the reactor and tools.
- **August 25** — markdown output preview in the translator; live session takes preserved in MiniMax.
- **August 27** — multilingual Underbelly routing integrated, and a file called `what-is-this.txt` added (then updated eleven minutes later): the repo writing its own description while still being built.
- **September 3** — the resident EraX vision lane exposed in the translator, the downloader reconciled against the runtime inventory, image-request memory bounded.
- **September 4** — MiniMax prompt enhance simplified with portable session state; a runtime export audit that excludes unused vendor tokenizers; Ideogram gains private local masked editing with lasso selection, then seeded edits that preserve crop geometry through local alpha masks.
- **September 5** — ObjectClear refuses to downscale its source; the canonical `hf_transfer` update; a seed pane on the Object Remover.
- **September 6** — rerollable multi-voice concatenation in LongCat.
- **September 8** — YouTube transcript extraction in Underbelly.

Two days built the machine; three weeks taught it manners — and the manners are the feature, because a workstation you trust is one that stops downscaling your sources, keeps your takes, and documents itself as it goes.

[github.com/CommanderTurtle/mm-tools](https://github.com/CommanderTurtle/mm-tools) · [vox](https://github.com/CommanderTurtle/vox) · [sandwich](https://github.com/CommanderTurtle/sandwich)

---

#### xkcd of the day, 8/10 - Size and Lifespan #3283

![xkcd of the day](https://imgs.xkcd.com/comics/size_and_lifespan_2x.png)

[[snake in js, on Even-G2]](https://github.com/nickustinov/snake-even-g2)

"""

let render() = file
