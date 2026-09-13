module Bl0g.Posts.N20260605Gemma4BlackwellNvfp4Md

let file = """---
layout: post
title: "Gemma 4 on Blackwell: A Three-Act Saga of Pain and Glory"
author: "CommanderTurtle"
date: 2026-06-05 21:10:00 +0000
categories: jekyll update
---

## Act I — The Dream

June 4, 2026. I had just spent an evening staring at a benchmark spreadsheet that kept telling me the same thing: my LLM inference stack was leaving performance on the table, and the reason was almost certainly the kind of reason that makes engineers want to walk into the ocean.

The model was Gemma 4 — specifically the A4B-it MoE variant, a 19B expert-pruned model (cut down from 26B) running in a native NVFP4 quantization. The stack was vLLM 0.27.1, the standard choice for high-throughput serving. The hardware was my local rig — a single RTX 5090 (GB202, SM120), the consumer 50-series Blackwell, the same silicon class the patch targets. One card, no tensor parallelism to hide behind. And the symptom was classic: *the kernel was doing things it shouldn't have been doing, on silicon it didn't fully understand.*

This post is the full record of what happened between June 4 and the evening of June 5, 2026. It is not a victory lap. It is a post-mortem that happens to end in a victory — because the interesting part was the two nights of pain, not the final 1.78× speedup.

The end state, for those who just want the number: **the NVFP4-quantized 19B MoE runs with a 1.78× larger KV-cache pool than the FP8 baseline at +0% scale-factor overhead, holds a 0.49 MTP acceptance rate, and sustains an Interactive-Turnaround-Latency (ITL) of 85 ms at 512/1024 tokens — 25% faster than FP8, 74% faster than BF16.** Zero crashes across the run. That is the headline. The rest of the story is how I got there, including the three ways I almost didn't.

## Act II — The Three Nights of Pain

The work landed in a lineage of five commits on a fork of the vLLM 0.27.1 tree, named (with appropriate humility) after the problem it existed to solve: `vllm-nvfp4-kv-sm120`. The commit log is the real timeline of this saga, so let me walk it as it actually happened.

### Night one — "fix mtp: use NVFP4 GEMM (fp8-quantize path was wrong)"

The first commit is the one I'm least proud of, because it's the one that tells you the shape of the bug before you understand it: *the FP8-quantize path was wrong for NVFP4.*

The way to read that is this: NVFP4 and FP8 are not the same thing with different bit counts. They are different *kinds* of quantization with different scale-factor layouts, different GEMM entry points, and different assumptions about where the scale factors live in memory. vLLM's codebase has a FP8 path that predates NVFP4 by a year, and the NVFP4 path was — as of 0.27.1 — a *partial* port. The MTP (Multi-Token Prediction, the speculative-decoding side of the model) was silently routing through the FP8-quantize path because the NVFP4 path wasn't wired up for the MTP kernel yet. The model was *working*. The numbers were just *wrong*, in the way that makes a wrong number far more dangerous than a crash: it looked plausible, it was internally consistent, and it disagreed with the ground truth by a margin you couldn't see until you had the ground truth in front of you.

The fix was to route the MTP kernel through the NVFP4 GEMM. One line of dispatch, one kernel launch changed. The acceptance rate jumped from "suspiciously low" to 0.49, and I could go to sleep.

The lesson, the one that generalizes beyond this specific bug: *a quantized model that "works" is not a working model until you have verified the quantization path end-to-end against a reference.* The MTP acceptance rate is the canary here — it's the single number that tells you whether the speculative path is actually *accepting* the tokens the model thinks it's proposing, and a wrong GEMM path will depress that rate in a way that's easy to misread as "the model is just bad at MTP."

### Night two — "add SF buffer guard (GEMM read 132B past end)"

The second commit is the one I keep coming back to, because it's the most *Blackwell-specific* bug in the whole saga, and the one that would have been invisible on any other architecture.

A "SF" — scale factor — buffer is a small region of memory that holds the per-tensor or per-block scaling multipliers for a quantized weight. The NVFP4 GEMM kernel reads from this buffer during the matmul. On Blackwell, the SF buffer layout is *different* from the Hopper layout that the original GEMM was written for. The kernel was reading 132 bytes *past the end* of the allocated SF buffer.

132 bytes. That's the number I want you to hold onto, because it's the whole story of why this bug was so hard to catch:

- 132 bytes past the end of a buffer is *inside the memory allocator's bookkeeping* on most systems. It's not a page fault. It's not a segfault. It's a read of a region that *happens to be mapped* (because the allocator rounds up to page boundaries), *happens to contain something that looks like a number*, and *happens to produce a scale factor that is close enough to the real one that the output is "approximately right."*
- On a single run, you might never see it. On a benchmark, it manifests as a *slightly* off ITL, a *slightly* off acceptance rate — noise you'd write off as measurement jitter.
- The fix was to add a guard: a bounds check on the SF buffer read that *crashes loudly* if the kernel tries to read past the end. With the guard in place, the bug became a clean assertion failure instead of a silent 132-byte over-read, and the fix to the buffer size became trivial.

The deeper lesson: *Blackwell (SM120) is new enough that the kernel ecosystem is still catching up.* The Hopper (SM90) path is battle-tested; the Blackwell path is six months into a migration. The vLLM 0.27.1 tree had the NVFP4 GEMM working, but the SF buffer layout was a Hopper artifact that hadn't been re-validated for SM120. If you're running NVFP4 on Blackwell as of mid-2026, *this exact class of bug is still out there* in code you haven't looked at yet. The guard is the cheapest insurance you can buy.

### Night three — "fix sm120 gemm (NVFP4 was misdispatching)"

The third commit is the one that made the whole thing actually *fast*, and it's the one I'd call out to a reader who only has time for one paragraph.

The first two commits made the model *correct*. The third commit made it *fast*. And the reason it was slow up to that point was the most frustrating kind of slowness: *the right kernel, on the wrong dispatch path.*

vLLM's GEMM dispatcher, as of 0.27.1, had a fallback chain: if it couldn't find a specialized kernel for the current (quantization, architecture) pair, it would fall back to a *generic* path. For NVFP4 on SM120, the specialized kernel existed in the tree — it was *there*, compiled, linked, ready to go — but the dispatcher wasn't routing to it. It was misdispatching to a *generic* GEMM that was numerically correct (hence the "works but slow" from night one) but ran at roughly half the throughput of the specialized path.

The fix was a dispatch-table entry: *on SM120 with NVFP4, use the NVFP4 GEMM, not the generic one.* One line. The ITL dropped from the 106 ms FP8-baseline class to 85 ms. The model got 25% faster *for free*, because the fast kernel had been sitting in the tree the whole time, waiting for someone to point the dispatcher at it.

This is the bug that makes me most grateful that I was *benchmarking* instead of just *running*. If I had only been looking at "does it work," the misdispatch would have been a permanent 25% tax on the whole stack, invisible in any correctness check. The benchmark is what told me "this is 25% slower than it should be," and the dispatch table is what told me *why*.

## Act III — The Payoff

The final commit on June 5, 2026, at 13:42 UTC, is the one that closes the loop: *"sm120 nvfp4 kv final: 19b mtp bench, itl 85.21ms vs fp8 106.84, zero crashes."*

That commit message is the entire engineering story in 12 words, so let me unpack it.

### The benchmark, in full

The benchmark was run on the single RTX 5090 (SM120), with the 19B MoE Gemma 4 A4B-it NVFP4 model, at 512-token prompts and 1024-token completions. The three configurations:

| Configuration | ITL (ms) | Relative to BF16 | Relative to FP8 |
|---------------|----------|------------------|-----------------|
| BF16 (baseline) | 148.06 | 1.00× | 1.39× |
| FP8 KV cache | 106.84 | 0.72× | 1.00× |
| **NVFP4 KV cache (final)** | **85.21** | **0.57×** | **0.80×** |

Three numbers to sit with:

1. **85.21 ms ITL, 25% faster than the FP8 baseline.** That's the direct win from the NVFP4 KV cache: smaller per-token storage, fewer bytes moved per attention step, and a GEMM path that's actually *on* the specialized kernel (thanks to night three).
2. **+0% scale-factor overhead.** This is the number I'm most proud of, and the one that's hardest to get. The NVFP4 SF buffer, with the guard from night two in place, added *zero* measurable overhead to the KV-cache pool. That means the scale factors are not eating into the pool that holds the actual KV data — they're stored in a way that's effectively free. For a 19B MoE where every megabyte of pool is a token of context, "+0% SF overhead" is the difference between "the pool holds 200K tokens" and "the pool holds 200K tokens *and* the SFs live somewhere else."
3. **1.78× larger KV-cache pool than the FP8 baseline, at the same memory footprint.** This is the *actual* headline. The NVFP4 KV cache stores the same data in 1.78× fewer bytes, so at a fixed memory budget you can hold 1.78× more context. For a MoE with MTP, that's the difference between "fits in memory" and "fits in memory *and* has headroom for the speculative tokens."

And the MTP acceptance rate held at **0.49** — the same 0.49 from night one, after the GEMM fix. That's the number that tells you the speculative path is *actually working*, not just "not crashing." A 0.49 acceptance rate on a 19B MoE is a healthy number; it means the MTP head is proposing tokens that the main model agrees with 49% of the time, and the serving stack is harvesting that 49% as free throughput.

### Zero crashes

"Zero crashes" is in the commit message for a reason. The run was a sustained benchmark — not a single forward pass, but a long interactive session at 512/1024, enough to exercise the MTP path, the SF buffer, and the dispatch table thousands of times. Any of the three bugs from the three nights would have *crashed* under sustained load: the wrong GEMM path would have produced a NaN that propagated to a kernel assertion, the 132-byte over-read would have hit an unmapped page under allocator pressure, and the misdispatch would have shown up as a throughput cliff at the MTP boundary. Zero crashes across the run is the "the fix is real" stamp, not the "the fix is plausible" stamp.

## The Takeaway

Three bugs, three nights, three lessons that generalize well beyond vLLM or Blackwell:

1. **A quantized model that "works" is not working until you've verified the quantization path end-to-end.** The MTP acceptance rate is the canary. If it's lower than you expect, suspect the GEMM path before you suspect the model.
2. **New silicon (SM120) means the kernel ecosystem is still catching up.** Hopper-era assumptions about buffer layouts, SF placement, and dispatch tables are *still* the failure mode. Add bounds checks. Crash loudly. The 132-byte over-read is the shape of every silent bug on new hardware.
3. **Benchmark, don't just run.** The misdispatch was a 25% tax that no correctness check would have caught. The benchmark told me "this is slower than it should be," and the dispatch table told me why. If you're on a new architecture, the benchmark *is* the test suite.

The model is live on HuggingFace: `sHEL1562/gemma-4-A4B-it-MoE-HERETIC-nvfp4-blackwell` — a ~16 GB NVFP4 export, pulled straight off the hub with `huggingface_hub` + `hf_transfer`, the same local-only pattern as the rest of the stack: network for the artifact fetch, inference never leaves the machine. It is a ModelOpt calibration of DavidAU's DECKARD Heretic Uncensored Thinking base — experts pruned 128 → 90 and fully finetuned, vision tower and embeddings preserved in BF16 — so the provenance chain is public end to end. The fork is in the repo lineage under the `vllm-0.27.1-sm120` branch. And the 85 ms ITL is the number I get to keep.

*— CommanderTurtle, June 5, 2026*

---

#### xkcd of the day, 6/5 - Planetary Science #3255

![xkcd of the day](https://imgs.xkcd.com/comics/planetary_science_2x.png)

[[why is florida building so many datacenters]](https://www.datacenterdynamics.com/en/news/44-million-sq-ft-data-center-campus-gets-zoning-approval-in-fort-meade-florida/)

"""

let render() = file