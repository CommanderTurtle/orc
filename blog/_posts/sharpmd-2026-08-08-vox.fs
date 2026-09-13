module Bl0g.Posts.N20260808VoxMd

let file = """---
layout: post
title: "vox: The Fork That Became an Audio Backbone"
author: "CommanderTurtle"
date: 2026-08-08 04:00:00 +0000
tags: [project, tooling, rust, audio, ai-agents, windows]
---

vox is a system tray application that gives CLI AI agents a voice. Press a hotkey and speak, and the transcript lands at your cursor position — terminal, editor, browser, anywhere; select some text and press a different chord, and a free Microsoft Edge voice reads it aloud. No plugin, no integration, no SDK in the target application: it works at the system level. [CommanderTurtle/vox](https://github.com/CommanderTurtle/vox) is a fork of [windward47/vox](https://github.com/windward47/vox), and like the other forks in this series, the fork tells the story the upstream repository no longer tells: 65 commits total, 51 mine and 14 inherited, and after upstream's last push on July 27 every line of development happened here. This post covers the whole arc — what upstream shipped in two months, the 37-commit burst after the August 8 fork, the 14-commit second wave that gave the audio app a browser extension, and the license drift the README still hasn't resolved.

## What Upstream Shipped

windward47/vox started June 10 with `Initial commit: vox v0.1.0` and a documentation sweep (SPEC/PLAN/TASKS/AGENTS, Task 10 scripts, CLI subcommands). Two waves did the rest:

- **June 30 (8 commits)** — the hardening wave: keyless Edge TTS plus local ASR, the tray menu and settings front/back ends decoupled, protocol and playback fixes folded in through a merge, push-to-talk recording mode, a multi-platform packaging workflow, the version bump to 0.1.1, macOS/Linux cross-compilation fixes, and Wayland support.
- **July 27 (4 commits)** — the engine wave: Volcano Engine Doubao ASR and TTS wired in (WebSocket `volc.seedasr.sauc.duration` for ASR, HTTP-streamed `seed-tts-2.0` for TTS, both keyed on the Agent Plan endpoint), the missing MIT `LICENSE` finally created, and a CI/tests/docs/robustness audit pass. Last push July 27, 19:44 UTC.

At the fork point the baseline was a real engine matrix: six ASR engines (whisper.cpp local server as the default, OpenAI-compatible REST, Mimo, Aliyun, Doubao, and a feature-gated whisper-rs FFI) and three TTS engines, all behind a fallback manager. What it did not have was anything about how I actually use it — translation as a workflow, real microphones on a real Windows machine, a signed driver, or any browser surface.

## The First 48 Hours

The fork opened at 16:58 UTC on August 8 and did not stop until 00:49 on August 10: 37 commits in two days, part of a 46-commit month. Day one established the direction — translation is not an add-on, it is the product:

- `feat: add private speech translation and voice pipeline` — the first commit; CrisperWhisper 2.0 plus a dedicated local EraX translation service, with inbound detect/source → English and outbound English → any chosen language
- `feat: make translation a native Vox workflow`, then LongCat voice pairs (`.wav`/`.mp3`/`.m4a` plus a verbatim `.txt`) with persisted seed controls, and portable clipboard controls (restore-after-paste and copy-only modes)
- then the Windows side: the native audio cable lifecycle, the `windows-vb-cable` setup helper that verifies CABLE Input and CABLE Output through the router's actual CPAL/WASAPI enumerator before launching a numbered device wizard, the mic forwarder as an opt-in `--features mic-forwarder` binary, and `http-router-only` — a backend-only workspace member that shares the CrisperWhisper/LongCat behavior without pulling in the tray, hotkeys, clipboard, GUI, capture, or device dependencies

Then came the part of the log that reads like a war story. The mic forwarder ships a real Windows driver, and shipping a Windows driver means signing it. Between 23:26 on August 8 and 05:15 on August 9, fourteen consecutive commits grind the signing problem down from the far side of a WSL boundary:

1. `feat: add Microsoft attestation release path` and `fix: verify developer test-signing state`, late on August 8
2. `fix: restore TrustedInstaller driver signing workflow` at 03:42
3. `docs: export MachineKeys-compatible signing bundle`, then the overnight grind: prepare signing from an Administrator-backed WSL, run the preparation "without UNC policy mutation", stage the signing imports on the Windows filesystem, detect the Code Signing EKU from PowerShell, resolve the MachineKeys container through CertUtil, accept SYSTEM tokens with TrustedInstaller enabled, reuse the prepared identity, keep the driver builds outside the signing token
4. `feat: generate the driver signing identity from WSL` at 05:15 — the end state: the complete signing identity generated from WSL, with the driver signing against the Windows certificate store from there

The same night, once the signing saga closed: the microphone rerouted through VB-CABLE, live audio routing rebuilt around multilingual caption lanes, the optional per-utterance detect pipeline (parallel Crisper + XLM-R + EraX-VL arbitration), and the programmable concurrent media routes — the items the README now lists as first-class features. August 10 ended with a single quiet commit, `Updated Documentation`.

## The Second Wave

Three quiet weeks later, August 27 opened a different kind of build: the audio app grew a browser extension. Fourteen commits through September 6, all MV3:

- **August 27 (7)** — a local Edge translation extension appears at 21:01, and by the end of the same night it carries standalone Webclip capture with deduplication before encoding, a relative-asset mode, and complete media format handling
- **August 29** — resources revised and PowerShell instructions added
- **September 2** — Firecrawl v2 clipping reconciled into the same MV3 extension
- **September 3** — local image understanding actions, a stateless HTTP proxy for EraX image requests, and hardened authenticated image capture
- **September 6** — `Fix native popout and live captions`, the last commit in the repository

This is where the profile's "local LLMs in a local Edge mv3 extension" stops being a bullet point and becomes load-bearing: translation, Webclip scraping, and vision all run against local backends from page context, not from the tray process.

## What It Looks Like Now

The README's feature list is the map. The shape of the system:

- voice input and TTS at the system level — fifteen configurable hotkey chords, push-to-talk or toggle, keyboard or clipboard injection with clipboard snapshot protection
- six ASR / three TTS engines with automatic fallback — whisper.cpp local as the default (no key, no FFI), Edge TTS free (Microsoft Edge Read Aloud, no key), Doubao auto-defaulting once a key is set
- translation lanes — CrisperWhisper 2.0 in intended/non-literal or literal mode; a known language takes the one-pass fast path, `detect` is the explicit per-utterance arbitration across Crisper + XLM-R + EraX-VL
- named LongCat voices — saved audio-plus-verbatim-transcript pairs, switchable from the tray or a hotkey, with seed ±1
- the native mic router — mixes multiple Windows input devices and generated speech into a selectable virtual-microphone endpoint over VB-CABLE, which is downloaded separately under its own license and never bundled
- independent live captions — the physical microphone mix and native system playback captioned simultaneously, with optional local translation and dubbing; caption presets launch independent processes with non-destructive router cursors, so several translated and untranslated windows can stay live from the same source device
- the programmable route matrix — saved input → STT → translate → TTS/text/caption workflows, live-reloadable hotkeys, seven first-run presets on Ctrl+Alt+1..7
- the ephemeral popout — a disposable dictate/translate/voice-render editor where only the workflow choices persist
- zero CPU when idle, and `config.toml` beside the running executable — portable, no platform config directory

The architectural line that matters sits in the README's local-pipeline section: on Windows the native Vox tray client can run while the model services stay inside WSL or on another private-LAN host. Same split as the signing saga — the operating system hosts the audio stack, WSL hosts the models.

## Wired Into The Orbit

The mm-tools README now points back at this exact fork: its Translation page is marked *compatible with vox* — "an in-house built translation pipeline with native web-ui. Compatibile with vox system-audio driver. (This exact fork)" — and its Speech-to-Text page carries the same marker. In mm-tools, generated audio is hoisted into the vox router instead of being wired per project, which is why the profile's one-line description reads the way it does: "vox (Rust native program wired to mm-tools; local LLMs in a local Edge mv3 extension; Speech-To-Text subtitling; native mic-router with VB-Cable)."

## The License Drift

The relicense happened at 01:50 on August 9, one day into the burst, between `Update Driver Instructions` and the TrustedInstaller workflow coming back: `Update LICENCE`, MIT → AGPL-3.0. The LICENSE file is authoritative, and the README only half caught up: the badge at the top still says `license-MIT-blue`, the English section says AGPLv3, and the Chinese section — an older snapshot whose install step is still `git clone https://github.com/your-username/vox.git` — still ends on MIT. Three answers to one question in one document. (And the commit spells it "LICENCE", British fashion, which is why a case-insensitive search for "license" walks right past it.)

[github.com/CommanderTurtle/vox](https://github.com/CommanderTurtle/vox) · [github.com/windward47/vox](https://github.com/windward47/vox) · [github.com/CommanderTurtle/mm-tools](https://github.com/CommanderTurtle/mm-tools)

---

#### xkcd of the day, 8/8 - Trick Play #3282

![xkcd of the day](https://imgs.xkcd.com/comics/trick_play_2x.png)

[[The RFC surrounding Unique-Local]](https://www.rfc-editor.org/rfc/rfc4193)

"""

let render() = file
