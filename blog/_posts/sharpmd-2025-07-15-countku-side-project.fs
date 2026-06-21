module ConvertedFiles.Posts.N20250715CountkuSideProjectMd

let file = """---
layout: post
title: "countku: Expert Level Counting"
author: "CommanderTurtle"
date: 2025-07-15 10:00:00 +0000
tags: [side-project, math, haiku, game, js]
---

It started with a Discord thread. I was playing with two bots — a counting bot and Haikubot — and wondered: what if counting could be poetry? What if every number you expressed had to fit the rigid 5-7-5 structure of a haiku?

That question became **countku**.

## The Origin

I posted the original concept to Reddit ([r/haikusbot](https://www.reddit.com/r/haikusbot/comments/1p1aq85/countku_expert_level_counting/)) with a simple challenge: get both the counting bot and Haikubot to validate the same message simultaneously. The screenshot tells the whole story — me typing `21+1.1-1.1+1-1`, the counting bot accepting it as valid (it evaluates to 22), and Haikubot transcribing it into perfect 5-7-5 form:

> Twenty two, plus one  
> point one, minus one point one,  
> plus one, minus one

Then I pushed further. `1-3.000+1+1+1` — evaluating to 1, the next number in the count — became:

> One minus three point  
> zero zero zero, plus  
> one, plus one, plus one

The bots agreed. The game was born.

## What Countku Actually Is

Countku is a base-ten number system more convoluted than all prime numbers. The core premise: **express any mathematical result as a haiku** (5-7-5 syllables) where the math actually evaluates to the intended number.

It isn't just wordplay — it's a genuine constraint system with documented rules:

- **5-7-5 syllable structure** is strictly enforced
- **No cutting words across line breaks** — "ze-" on line 1 and "ro" on line 2 is illegal
- **Decimal is always "point"** — proper mathematical English
- **Zero variants**: "zero" (2 syl), "zed" (1 syl), or "oh" (1 syl) — pick one per thread and stick to it
- **"Type shit" and two-syllable memes** are legal BS words — they pad syllables without affecting the math
- **Words must finish at the end of a Ku** — no "one point zero Oh" cheating that circumvents the memory challenge

The O'Leary license applies: I don't intend to monetize it, but if you sell countku or a variation, I ask for 1 satoshi per API call. You can wrap the shaves of pennies in envelopes and mail them to me.

## The Documentation

What started as a joke grew into a fully documented system. I built out comprehensive docs across three files:

**[1.md — The Rulebook](https://shel.sh/projects/1.md)** documents every substring in the countku lexicon with full grammatical metadata — syllable count, whether it's a base number, scale word, math operator, preposition, or passive/active participle. There are 127 indexed substrings from "one" to "influence," each with their bit flags for the parsing engine. Five complete data tables cover: the substring database, base glossary (Zero through Highers), full operators matrix (46+ distinct operations), prepositional/auxiliary combinations, and modifier/ordinal definitions including Latin and Greek systematic forms.

**[2.md — The Changelog](https://shel.sh/projects/2.md)** tracks the engine evolution from v1.0 through v7.4, including the deferred emission engine, `$P_Action` vs `$P_Passiv` prepositional semantics (does "using the power of" wrap the entire expression or just the last term?), logarithm system overhaul, trig parenthesis fixes, and noun operator preposition gating.

**[3.md — The Engine Reference](https://shel.sh/projects/3.md)** is the complete technical manual for the JavaScript conversion engine, covering the tokenization pipeline, `convertTokens()` state machine, the fallover syllable system for automatic 5-7-5 line detection, and the `CountkuConverter` and `HaikuValidator` class architectures.

## The Math Engine

The JavaScript engine converts English word phrases into executable math expressions. Some examples from the docs:

| Input | Expression | Result |
|-------|-----------|--------|
| one plus two | 1+2 | 3 |
| the square root of sixteen | Math.sqrt(16) | 4 |
| five to the sixtieth | (5)**60 | huge |
| the sine of zero plus the log of one and two | Math.sin(0)+Math.log(1)+2 | 2 |
| five plus three using the power of two | (5+3)**2 | 64 |
| five plus three under the power of two | 5+(3)**2 | 14 |

The `$P_Action` vs `$P_Passiv` distinction is the clever part. "Using" wraps the entire preceding expression in parentheses before applying the power. "Under" wraps only the immediately preceding term. Same words, different math.

## Sakura Count Ninja — The Game

All of this became **[Sakura Count Ninja](https://shel.sh/projects/)**, a browser-based counting game with four modes:

- **Normal** — Base 10 JS math expression evaluation
- **Hard** — Base 2, results shown in binary
- **WTF** — Base 16, results shown in hex
- **Countku** — English word haikus validated for 5-7-5 structure then converted to math

The game features ninja animations (idle, run, jump), streak tracking, sound effects, and an end-game dashboard. The countku mode runs the full `HaikuValidator` + `CountkuConverter` dual-check system — both the syllable structure AND the math must be valid.

## The Future: A JS Math Library

The long-term vision is extracting the countku engine into a proper JavaScript math library that **invalidates non-haiku math and forces haiku-safe operations**. Imagine a math library where `eval("one plus two")` works but `eval("1 + 2")` doesn't — where every computation must pass through the linguistic layer. Where the constraint isn't a bug, it's the feature.

The documentation is already structured like a language specification. The engine handles ordinals, fractions, trigonometry, logarithms, roots, powers, passive/active voice distinctions, and noise-token stripping. Turning that into a `countku-math` npm package is the natural next step.

Play the game at [shel.sh/projects](https://shel.sh/projects/). Read the full docs at [shel.sh/projects/1.md](https://shel.sh/projects/1.md), [2.md](https://shel.sh/projects/2.md), and [3.md](https://shel.sh/projects/3.md). And remember: numbers are nature.
"""

let render() = file
