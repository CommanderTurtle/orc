module Bl0g.Posts.N20260728CountkuSideProjectMd

let file = """---
layout: post
title: "countku: A Number System More Convoluted Than All Prime Numbers"
author: "CommanderTurtle"
date: 2026-07-28 10:00:00 +0000
tags: [side-project, math, haiku, game, js, fsharp]
---

It started with a Discord thread where two bots were arguing with me.

I was in a counting game — the kind where a `counting` bot keeps a running total and everyone has to post the next number. There was also a `HaikuBot` in the server. I wondered what would happen if a single message satisfied both: evaluated to the next number *and* transcribed itself into a valid 5-7-5 haiku. I posted `21+1.1-1.1+1-1` (which is 22, the correct next number) and the two bots lit up at once — the counting bot accepted it, and HaikuBot rendered it as:

> Twenty two, plus one
> point one, minus one point one,
> plus one, minus one

Two bots, one message, both correct. I posted it to Reddit as ["Countku, expert level counting"](https://www.reddit.com/r/haikusbot/comments/1p1aq85/countku_expert_level_counting/) and called the thing **countku**. A base-ten number system more convoluted than all prime numbers, where every number you say has to be a haiku that actually evaluates to that number.

## The Rulebook

It isn't just wordplay. It's a constraint system with documented, parseable rules:

- **5-7-5 syllable structure** is strictly enforced.
- **No cutting words across line breaks** — "ze-" on line 1 and "ro" on line 2 is illegal.
- **Decimal is always "point"** — proper mathematical English.
- **Zero has three variants** — "zero" (2 syllables), "zed" (1), or "oh" (1) — pick one per thread and stick with it.
- **"Type shit" and two-syllable memes are legal BS words** — they pad syllables without touching the math.
- **A word must finish at the end of a Ku** — no "one point zero Oh" cheating that sneaks a syllable across the boundary.

The documentation grew into three reference files, all living under [app.shel.sh/countku](https://app.shel.sh/countku/):

**[1 — The Rulebook](https://app.shel.sh/countku/1)** documents every substring in the countku lexicon with full grammatical metadata — syllable count, and bit flags for whether it's a base number, a scale word, a math operator, a preposition, or a passive/active participle. The core is a five-table database. Table 1 (Substrings-All) alone indexes over 127 substrings from "one" to "influence," each with its flags and base value. The remaining tables cover the base glossary, the full operator matrix (46+ distinct operations), prepositional/auxiliary combinations, and modifier/ordinal definitions including Latin and Greek systematic forms.

**[2 — The Changelog](https://app.shel.sh/countku/2)** tracks the engine from v1.0 (2025-05-16) through v8.1 (2026-07-27).

**[3 — The Engine Reference](https://app.shel.sh/countku/3)** is the technical manual for the JavaScript conversion engine.

## The Engine: From State Machine to Interpreter

The engine converts English word phrases into executable JavaScript math. The early version was a hand-rolled token state machine, and the interesting bug that shaped it was the **active-vs-passive preposition distinction**. Consider:

| Input | Expression | Result |
|-------|-----------|--------|
| five plus three **using** the power of two | `(5+3)**2` | 64 |
| five plus three **under** the power of two | `5+(3)**2` | 14 |

"Using" wraps the *entire* preceding expression before applying the power; "under" wraps only the immediately preceding term. Same words, different math — and the engine had to know which one you meant. That distinction (`$P_Action` vs `$P_Passiv`) is what pushed the parser toward tables instead of branches.

The v8.0 release — **"Tables Become the Interpreter"** (2026-07-27) — completed that direction. The duplicate word validator and the expression state machine were replaced by a single whole-word syllable lexicon, a longest-match phrase matrix, and an ordinal matrix. Noun grammar (the `using`/`with`/`undergoing` + optional `the` + operator-noun combinations) is now *generated* as a Cartesian matrix rather than hand-branched. A compact Pratt parser supplies only precedence and associativity; the markdown tables themselves define the language. Every valid sentence produces one AST, and from that single AST the engine renders three things that can no longer drift apart: the numeric value, the executable JavaScript, and unambiguous LaTeX. So `the cube root of eight / under the influence of / eighth power of six` becomes `\sqrt[3]{8}\,6^8`, and the math, the code, and the TeX all agree by construction.

The earlier versions read like a design diary: v5.0 (2026-05-17) unified all power/root operations onto `**` and made `of` a root trigger; v6.0 (2025-05-17) introduced the deferred-emission engine. By v8.1 the changelog entry is a "Matrix Fidelity Pass" — I played every Table 5 alias through roots and powers against the live game and made `half` and `square` obey the same degree rules as the documented `hendecagonal`/`undecagonal`/`duodecagonal` forms.

## Sakura Count Ninja

All of this became a game: **Sakura Count Ninja**, at [app.shel.sh/countku](https://app.shel.sh/countku). The base game has four numeric modes — **Normal** (base-10 JS evaluation), **Hard** (base 2, results in binary), **WTF** (base 16, results in hex), and **Countku** — where the full `HaikuValidator` + `CountkuConverter` dual check runs and both the syllable structure *and* the math have to be valid.

The countku mode is where the project stopped being a parser and became a world. The current build is a local-first, installable game (PWA manifest + service worker, network-first so a cached engine never beats a live one) whose language layer is still the shared countku engine but whose *game layer* is authored and rendered through F#. A 624-line F# dialogue registry compiles to a jump table that exposes four progression ranges; a 370-line F# worlds file owns the complete world route — 21 hand-authored five-landing palettes from Sakura Trail through Dark Crossing, then deterministic compound-name and color generation from landing 105 onward. The music is a dependency-free look-ahead Web Audio transport playing a 10-movement F#-scored soundtrack that follows your progress and exposes every unlocked movement in a jukebox; the interaction sounds are generated procedurally per rank, so there are no recorded samples to duplicate. The original three numeric modes keep using the base page; the enhanced world only turns on while countku is selected.

## The License and the Future

The O'Leary license applies: I don't intend to monetize it, but if you sell countku or a variation, I ask for 1 satoshi per API call. You can wrap the shaves of pennies in envelopes and mail them to me.

The long-term vision is extracting the engine into a `countku-math` JavaScript library that **invalidates non-haiku math and forces haiku-safe operations** — a library where `eval("one plus two")` works but `eval("1 + 2")` doesn't, where every computation must pass through the linguistic layer. The constraint isn't a bug. It's the feature. The documentation is already structured like a language specification, and turning it into a package is the natural next step.

Numbers are nature.

[Play the game](https://app.shel.sh/countku) | [Rulebook](https://app.shel.sh/countku/1) | [Changelog](https://app.shel.sh/countku/2) | [Engine Reference](https://app.shel.sh/countku/3)

---

#### xkcd of the day, 7/28 - Forth #3277

![xkcd of the day](https://imgs.xkcd.com/comics/forth_2x.png)

[[Microsoft Retiring 3d viewer? Use babylon.js instead]](https://sandbox.babylonjs.com/)

"""

let render() = file
