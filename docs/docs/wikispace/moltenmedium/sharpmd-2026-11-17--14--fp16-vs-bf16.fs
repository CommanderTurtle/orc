module ConvertedFiles.LlmState2026111714Fp16VsBf16COLLAPSEDMd

let file = """# Where do comparisons for FP16 versus BF16 kv cache…

Model: `Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE`

## User · #1

Where do comparisons for FP16 versus BF16 kv cache only, compare in Qwen 3.8 Flash Next (MoE)

This model specifically, on a Q8PLE build + IQ3_S already preserves near identical behavior compared to the unquantized model. The question specifically relates to published sources on tradeoffs between FP16 and BF16 kv cache.

The answer will probably be either on huggingface or in some obscure research paper comparing the two, for this model specifically though, or, for the IQ quants, as, it's an engine-related question (not relating to the model weights).
## Assistant · #2

<details><summary>Reasoning · 734 characters</summary>

The user asks about FP16 vs BF16 KV cache comparisons, specifically for Qwen3-Next (MoE) model, on a llama.cpp Q8_0 + IQ3_S quantization build. They want published sources on tradeoffs between FP16 and BF16 KV cache.

Let me search the web for this. Key sources: llama.cpp GitHub PRs/discussions about F16 vs BF16 KV cache, Qwen3-Next GGUF quantization benchmarks (ik_llama.cpp / bartowski / mradermacher), and research papers on KV cache quantization precision.

Let me do several searches.

Note: "Qwen 3.8 Flash Next" — hmm, maybe they mean Qwen3-Next-80B-A3B. Or a newer model. Actually there might be "Qwen3-Next-80B-A3B-Instruct". "3.8 Flash Next" might be a mis-remembering. Let's search anyway.

Let me run parallel searches.


</details>

<details><summary>Tool request · web_search · call_4e5698cfeb284d629b44f084</summary>

```json
{
  "query": "llama.cpp BF16 KV cache vs F16 KV cache quantization quality comparison",
  "limit": 10
}
```

</details>

<details><summary>Tool request · web_search · call_345a566b943b444b95527e00</summary>

```json
{
  "query": "Qwen3-Next-80B-A3B GGUF IQ3_S Q8_0 KV cache F16 BF16 benchmark",
  "limit": 10
}
```

</details>

<details><summary>Tool request · web_search · call_aeac9d0912224d9fa29c9d80</summary>

```json
{
  "query": "ik_llama.cpp IQ3_S KV cache bf16 precision lossless attention",
  "limit": 10
}
```

</details>

<details><summary>Tool request · web_search · call_1bf2830dac904bca9f91d0c4</summary>

```json
{
  "query": "research paper FP16 vs BF16 KV cache precision inference accuracy comparison",
  "limit": 10
}
```

</details>

I'll dig into published sources on this. Let me run several searches in parallel.
<details><summary>Tool result · web_search · call_4e5698cfeb284d629b44f084</summary>

**Firecrawl · section 1 of 24**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,749 characters · included below
- Section 2 · 10,932 characters · omitted from this copy
- Section 3 · 11,557 characters · omitted from this copy
- Section 4 · 12,000 characters · omitted from this copy
- Section 5 · 10,454 characters · omitted from this copy
- Section 6 · 11,886 characters · omitted from this copy
- Section 7 · 11,899 characters · omitted from this copy
- Section 8 · 11,373 characters · omitted from this copy
- Section 9 · 11,031 characters · omitted from this copy
- Section 10 · 11,959 characters · omitted from this copy
- Section 11 · 11,985 characters · omitted from this copy
- Section 12 · 11,826 characters · omitted from this copy
- Section 13 · 11,846 characters · omitted from this copy
- Section 14 · 11,749 characters · omitted from this copy
- Section 15 · 11,990 characters · omitted from this copy
- Section 16 · 11,973 characters · omitted from this copy
- Section 17 · 11,799 characters · omitted from this copy
- Section 18 · 11,676 characters · omitted from this copy
- Section 19 · 11,353 characters · omitted from this copy
- Section 20 · 9,988 characters · omitted from this copy
- Section 21 · 11,850 characters · omitted from this copy
- Section 22 · 11,914 characters · omitted from this copy
- Section 23 · 11,862 characters · omitted from this copy
- Section 24 · 9,304 characters · omitted from this copy

```text
## 1. llama.cpp KV Cache Quantization: Which -ctk and -ctv to Use, Measured ...

https://sotaaz.com/post/llamacpp-kv-cache-quantization-guide-en

llama.cpp KV Cache Quantization: Which -ctk and -ctv to Use, Measured on the Current Build Short answer. If the KV cache fits in VRAM, leave it at the default f16. If it does not, use -ctk q8_0 -ctv q8_0. Set both flags to the same value, and do not expect the memory to be free: at 64K tokens of context the quantized cache decodes at roughly half the speed of f16.

![llama.cpp KV Cache Quantization: Which -ctk and -ctv to Use, Measured on the Current Build](https://cdn.sanity.io/images/11k7hfqk/production/ae7758a644f1b3415e6040222b7214b1d5b23d60-1332x741.gif?rect=8,0,1317,741&w=1200&h=675)

**Short answer.** If the KV cache fits in VRAM, leave it at the default `f16`. If it does not, use `-ctk q8_0 -ctv q8_0`. Set both flags to the same value, and do not expect the memory to be free: at 64K tokens of context the quantized cache decodes at roughly half the speed of `f16`.

![Decision path. Does the f16 KV cache fit in VRAM? Yes: leave it at f16, which decoded 79.6 tokens per second at 64K depth. No: set -ctk q8_0 -ctv q8_0, perplexity within 0.1% of f16 but 56% of f16 decode speed at 64K. Still does not fit: -ctk q4_0 -ctv q4_0, 1.1 GiB less than q8_0 at 32K and 0.5 to 1.1% higher perplexity. Skip q5_1, the q8_0/q4_0 mix and iq4_nl, which were slower than q8_0. Qwen3-8B Q4_K_M on one A100.](https://cdn.sanity.io/images/11k7hfqk/production/bf64097cef0fd3c8b25c3bfbd39e2d00aae612f2-1200x675.png)

This page is the short version of three measurement posts on this blog, rechecked on the llama.cpp build of 4 October 2026. The recheck mattered. A change merged on 9 September altered what happens with the less common types, and part of what we published in September no longer holds on current builds. Where a number below comes from an older build, it says so.

![](https://i.ytimg.com/vi/7cPD95rqWBk/hqdefault.jpg)

The same results in 97 seconds.[Subscribe to SOTAAZ on YouTube](https://www.youtube.com/@sotaaz?sub_confirmation=1)

### The commands[#](https://sotaaz.com/post/llamacpp-kv-cache-quantization-guide-en#the-commands)

bashCopy

    # server, chat, CLI: the same two flags
    llama-server -m model.gguf -ngl 99 -fa on -ctk q8_0 -ctv q8_0 -c 32768
    
    # compare types on your own card before you commit to one, one type per run
    for t in f16 q8_0 q4_0; do
      llama-bench -m model.gguf -ngl 99 -fa on -ctk $t -ctv $t -p 4096 -n 128 -d 0 -d 32768
    done

`-ctk` and `-ctv` are the short forms of `--cache-type-k` and `--cache-type-v`. Keep `-fa on`: quantized V caches need flash attention in llama.cpp. llama-bench also accepts comma-separated lists, but `-ctk f16,q8_0,q4_0 -ctv f16,q8_0,q4_0` runs all nine K/V combinations, six of them the mixed pairs this page advises against. The loop keeps K and V equal.

|     | K cache | V cache |
| --- | --- | --- |
| Short flag | `-ctk` | `-ctv` |
| Long flag | `--cache-type-k` | `--cache-type-v` |
| Environment variable | `LLAMA_ARG_CACHE_TYPE_K` | `LLAMA_ARG_CACHE_TYPE_V` |

Accepted values for both: `f32`, `f16`, `bf16`, `q8_0`, `q4_0`, `q4_1`, `iq4_nl`, `q5_0`, `q5_1`. The default is `f16`. Anything else stops with `Unsupported cache type`.

With `-fa auto`, the default, llama.cpp turns flash attention on for you when the V cache is quantized and logs `enabling flash_attn since it is required for quantized V cache`; with `-fa off` it refuses to start.

If you see `error: invalid argument: --ctk`, the short flag got a double dash. There is no `--ctk`. Use `-ctk q8_0` or the long form `--cache-type-k q8_0`.

Starting from nothing? [Episode 1 of our how-to series](https://sotaaz.com/post/llamacpp-install-en)
 goes from an empty folder to a CUDA build and a first answer. That build gives you one `llama` program, so `llama-server` and `llama-bench` here become `llama serve` and `llama bench`. Both list the same `-ctk` and `-ctv` flags.

![A 3 by 3 grid of -ctk (K cache) against -ctv (V cache) for f16, q8_0 and q4_0. The three equal pairs decoded at 79.6, 44.3 and 42.4 tokens per second at 64K depth. The six mixed pairs are the ones this page advises against; the one we measured, K q8_0 with V q4_0, decoded at 33.8, slower than both q8_0 and q4_0. Qwen3-8B Q4_K_M, one A100, llama.cpp b11390.](https://cdn.sanity.io/images/11k7hfqk/production/0d021772a64748b33f2b4e77a31e3596d0c4b129-1200x675.png)

### What each setting costs[#](https://sotaaz.com/post/llamacpp-kv-cache-quantization-guide-en#what-each-setting-costs)

Qwen3-8B Q4\_K\_M on one A100 80GB. Speeds are tokens per second on the 4 October build (b11390 (`dd26678`), default CUDA options). Memory is the cache alone at 32K tokens, computed from the type's bits. Perplexity is from the September build (b10753 (`69320fe`)); the cache format is set by the type, so it should not move with the kernels, but we did not re-run it.

| `-ctk` / `-ctv` | Cache at 32K | Perplexity vs f16 (4K–32K) | Prefill 4096 | Decode at 64K depth |
| --- | --- | --- | --- | --- |
| f16 / f16 | 4.50 GiB | —   | 4,704 | 79.6 (100%) |
| q8\_0 / q8\_0 | 2.39 GiB | −0.0% to +0.1% | 4,584 | 44.3 (56%) |
| q4\_0 / q4\_0 | 1.27 GiB | +0.5% to +1.1% | 4,599 | 42.4 (53%) |
| bf16 / bf16 | 4.50 GiB | not measured | 4,672 | 41.3 (52%) |
| q5\_1 / q5\_1 | 1.69 GiB | not measured | 4,583 | 27.8 (35%) |
| q8\_0 / q4\_0 | 1.83 GiB | not measured | 4,582 | 33.8 (42%) |
| iq4\_nl / iq4\_nl | 1.27 GiB | not measured | 104 | not measured |

Three things in that table decide most setups.

**Prefill barely moves; decode at depth does.** Every working type prefills within 3% of `f16`. The cost shows up when the cache is already long, because each new token reads all of it. With 8K tokens in the cache, `q8_0` decoded at 83% of `f16`; at 64K, 56%. The memory you saved is paid back in time at exactly the context length where you needed the memory.

![Animation: the K and V cache gains one row per generated token, and before each new row is added, the new token reads every row already cached. Prefill pays once; every decoded token pays again for the whole cache. Measured on Qwen3-8B with one A100: q8_0 decoded at 83% of f16 speed with 8K tokens cached and 56% with 64K.](https://cdn.sanity.io/images/11k7hfqk/production/bdc57e0cfc8e130fc7e41f1956ce5f93ed11e178-1200x675.gif)

**`q8_0` and `q4_0` decode at nearly the same speed,** within 5% of each other at 8K, 32K and 64K. Between them the choice is memory against quality: `q4_0` holds about 1.1 GiB less at 32K for this model and costs about 1% perplexity. Take `q4_0` only when that gigabyte decides whether the model loads.

For a case where q4\_0 is what gets a model inside the budget, and what happened when we then gave that setup coding tasks, see [We Forced Qwen3.8 27B Into 8GB](https://sotaaz.com/post/big-on-8gb-en)
 and [the video](https://youtu.be/MNp-nXyroyw)
.

![](https://i.ytimg.com/vi/MNp-nXyroyw/hqdefault.jpg)

q4\_0 getting Qwen3.8 27B inside an 8 GB budget on an A100, then the coding tasks.[Subscribe to SOTAAZ on YouTube](https://www.youtube.com/@sotaaz?sub_confirmation=1)

**The memory saving is real.** Peak VRAM during the 64K runs fell by 4.19 GiB with `q8_0` and 6.45 GiB with `q4_0`. The arithmetic predicts 4.22 and 6.47, so the measured peak matched it to within 0.03 GiB.

![Bar chart of peak VRAM saved against f16 during the 64K runs. q8_0: predicted 4.22 GiB, measured 4.19 GiB. q4_0: predicted 6.47 GiB, measured 6.45 GiB. The prediction is the f16 cache minus the new type's cache at 64K tokens; both gaps are within 0.03 GiB.](https://cdn.sanity.io/images/11k7hfqk/production/3520b59af28dfa10861dac3e6ace8b653f219902-1200x675.png)

### Types that work but you should not pick[#](https://sotaaz.com/post/llamacpp-kv-cache-quantization-guide-en#types-that-work-but-you-should-not-pick)

On the September build, four of these types and every mixed K/V pair prefilled at 83 to 284 tokens per second against about 4,600, because the default CUDA build compiled no flash-attention kernel for them. [We published that](https://sotaaz.com/post/llamacpp-kv-cache-types-en)
 as "set both flags to the same value, and use only four types."

On the current build that cliff is gone for most of them. A change merged on 9 September (llama.cpp #28079) did two things. It made `q4_1`, `q5_0` and `q5_1` supported types for flash attention. And when the decode kernel for a K/V pair was not compiled, it now converts K and V to `f16` on the fly instead of failing over. `llama-server` prints one line when that happens:

Copy

    ggml_cuda_flash_attn_ext_vec: no FlashAttention vector kernel compiled for K/V types q5_1-q5_1, converting K and V to f16 instead (slow). Add "q5_1-q5_1" to GGML_CUDA_FA_QUANTS to compile it.

`llama-bench` does not show that line unless you pass `-v`, because it silences the library's log by default.

![Animation of -ctk q5_1 -ctv q5_1 on the default CUDA build. On the September build there was no flash-attention kernel and these types prefilled at 83 to 284 tokens per second against about 4,600 for f16. On the current build (b11390, after llama.cpp #28079) q5_1 is a flash-attention type and prefills at 4,583 tokens per second against 4,704, but with no decode kernel compiled it converts K and V to f16 each step and decodes at 27.8 tokens per second at 64K, 35% of f16. Adding q5_1-q5_1 to GGML_CUDA_FA_QUANTS compiles the kernel; we did not measure that build.](https://cdn.sanity.io/images/11k7hfqk/production/95e937e63698eafe083ad5610436847d0c631c9c-1200x675.gif)

So `q5_1` and the `q8_0` / `q4_0` mix now prefill at full speed, and each gave a normal answer to one short test request on llama-server; we did not measure their quality. They are still a bad trade on a default build. `q5_1` decodes at 35% of `f16` at 64K, slower than `q4_0`, while holding more memory than `q4_0`. The mix sits between them on speed and saves less than `q4_0`. `bf16` is the other trap: it holds exactly as much as `f16` and decodes at 52% of it at 64K, so it buys nothing on this card.

![Scatter plot of cache size at 32K tokens against decode speed at 64K depth. Kept types: f16 4.50 GiB and 79.6 tokens per second, q8_0 2.39 GiB and 44.3, q4_0 1.27 GiB and 42.4. Skipped types: bf16 4.50 GiB and 41.3 (same memory as f16, about half the speed), q5_1 1.69 GiB and 27.8, the q8_0/q4_0 mix 1.83 GiB and 33.8 (both use more memory than q4_0 and are slower). iq4_nl is not shown: it prefilled at 104 tokens per second and its decode was not measured.](https://cdn.sanity.io/images/11k7hfqk/production/aa729d3eb73a1df4cd416ff521511e2e579d8945-1200x675.png)

`iq4_nl` is the one type that is still unusable. `-ctk` and `-ctv` accept it, but no build can compile a CUDA flash-attention kernel for it, because it is not an allowed type in `GGML_CUDA_FA_QUANTS`. It prefilled at 104 tokens per second.

Build b12274 later added a new type, `f8_e4m3`. On the same A100 its cache was 6% smaller than `q8_0`, but it moved the output about 8 to 10 times as far from `f16` as `q8_0` did, and decoded 12-13% slower at 32K. The full results are in [llama.cpp's new FP8 KV cache vs q8\_0](https://sotaaz.com/post/fp8-kv-cache-en)
.

#### Build option: GGML\_CUDA\_FA\_QUANTS (replaces GGML\_CUDA\_FA\_ALL\_QUANTS)[#](https://sotaaz.com/post/llamacpp-kv-cache-quantization-guide-en#build-option-ggmlcudafaquants-replaces-ggmlcudafaallquants)

If you have a reason to want `q5_1` or a mixed pair, compile its decode kernel in. These are the build commands, with `q5_1` added to the default list:

bashCopy

    cmake -B build -DGGML_CUDA=ON -DGGML_CUDA_FA_QUANTS="q4_0-q4_0;q8_0-q8_0;f16-f16;bf16-bf16;q5_1-q5_1"
    cmake --build build --config Release -j

```

</details>

<details><summary>Tool result · web_search · call_345a566b943b444b95527e00</summary>

**Firecrawl · section 1 of 27**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,255 characters · included below
- Section 2 · 11,894 characters · omitted from this copy
- Section 3 · 11,886 characters · omitted from this copy
- Section 4 · 10,581 characters · omitted from this copy
- Section 5 · 11,897 characters · omitted from this copy
- Section 6 · 11,823 characters · omitted from this copy
- Section 7 · 11,452 characters · omitted from this copy
- Section 8 · 10,252 characters · omitted from this copy
- Section 9 · 11,925 characters · omitted from this copy
- Section 10 · 11,911 characters · omitted from this copy
- Section 11 · 11,978 characters · omitted from this copy
- Section 12 · 11,438 characters · omitted from this copy
- Section 13 · 11,481 characters · omitted from this copy
- Section 14 · 11,925 characters · omitted from this copy
- Section 15 · 11,854 characters · omitted from this copy
- Section 16 · 11,957 characters · omitted from this copy
- Section 17 · 11,943 characters · omitted from this copy
- Section 18 · 11,481 characters · omitted from this copy
- Section 19 · 11,835 characters · omitted from this copy
- Section 20 · 11,274 characters · omitted from this copy
- Section 21 · 11,964 characters · omitted from this copy
- Section 22 · 11,926 characters · omitted from this copy
- Section 23 · 11,988 characters · omitted from this copy
- Section 24 · 11,708 characters · omitted from this copy
- Section 25 · 11,835 characters · omitted from this copy
- Section 26 · 11,994 characters · omitted from this copy
- Section 27 · 8,520 characters · omitted from this copy

```text
## 1. Qwen3-Coder-Next 80B (GGUF/BF16) on Zen 5 EPYC - Reddit

https://www.reddit.com/r/LocalLLaMA/comments/1qxib19/qwen3codernext_80b_ggufbf16_on_zen_5_epyc/

Feb 6, 2026 ... Model: Qwen3-Coder-Next (~80B) · Quant: BF16 (unsloth/Qwen3-Coder-Next-GGUF/BF16/*) · Context: 16k · KV Cache: q8_0 (Optimized to balance precision ...

---

## 2. unsloth/Qwen3.8-Flash-Next-GGUF - Hugging Face

https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF

To run, please use llama.cpp, Strata or use our Unsloth Desktop app. qwen3.8-flash unsloth dynamic v3.1 benchmarks 50% less token use, ...

[](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF#read-our-how-to-run-qwen38-flash-next-guide)
Read our How to [Run Qwen3.8-Flash-Next Guide!](https://unsloth.ai/docs/models/qwen3.8-next)

====================================================================================================================================================================================================

_[Unsloth Dynamic v3.1](https://unsloth.ai/docs/basics/dynamic-3.0-ggufs)
 achieves superior accuracy & outperforms other leading quants._

 [![](https://github.com/unslothai/unsloth/raw/main/images/unsloth%20new%20logo.png)](https://github.com/unslothai/unsloth/)
[![](https://github.com/unslothai/unsloth/raw/main/images/Discord%20button.png)](https://discord.gg/unsloth)
[![](https://raw.githubusercontent.com/unslothai/unsloth/refs/heads/main/images/documentation%20green%20button.png)](https://unsloth.ai/docs/models/qwen3.8-next)

*   Nov 4 update: Dynamic v3.1 GGUF is here with 15% more accuracy, 50% less token use and 5% faster inference than other frontier quants. Scores the highest on Terminal Bench, DeepSWE & more! [Details](https://unsloth.ai/docs/models/qwen3.8-next#dynamic-v3.1-update-november-2nd-2026)
    
*   MTP is now available for 1.3-1.7x Faster inference in Unsloth. [Read Guide](https://unsloth.ai/docs/models/qwen3.8-next#mtp-guide)
    
*   To run, please use llama.cpp, Strata or use our [Unsloth Desktop](https://unsloth.ai/docs/desktop)
     app.

![qwen3.8-flash unsloth dynamic v3.1 benchmarks](https://unsloth.ai/docs/~gitbook/image?url=https%3A%2F%2F3215535692-files.gitbook.io%2F%7E%2Ffiles%2Fv0%2Fb%2Fgitbook-x-prod.appspot.com%2Fo%2Fspaces%252FxhOjnexMCB3dmuQFQ2Zq%252Fuploads%252FqdXHweLFGzUhUcqj7jZX%252Ffinal%2520key%25204.png%3Falt%3Dmedia%26token%3D8e3249b1-e26c-4a04-82ba-7cfdef952fe6&width=768&dpr=3&quality=100&sign=1e1e946e8b723c1640f46f4e6a7b741b&sv=3) 50% less token use, 0.5-8% faster inference than other quants of the same size: ![qwen3.8-flash unsloth dynamic v3.1 token use](https://unsloth.ai/docs/~gitbook/image?url=https%3A%2F%2F3215535692-files.gitbook.io%2F%7E%2Ffiles%2Fv0%2Fb%2Fgitbook-x-prod.appspot.com%2Fo%2Fspaces%252FxhOjnexMCB3dmuQFQ2Zq%252Fuploads%252FWTSMbLLxexSW1HiwU411%252Fqwen%2520speed%2520token%2520con.png%3Falt%3Dmedia%26token%3Dfea0700d-24e7-4046-a915-4c087e0230aa&width=768&dpr=3&quality=100&sign=36745643af791f5557fab9dd3d10e0b9&sv=3) Run via Unsloth Desktop with browser use and more: ![qwen3.8-flash unsloth desktop](https://unsloth.ai/docs/~gitbook/image?url=https%3A%2F%2F3215535692-files.gitbook.io%2F%7E%2Ffiles%2Fv0%2Fb%2Fgitbook-x-prod.appspot.com%2Fo%2Fspaces%252FxhOjnexMCB3dmuQFQ2Zq%252Fuploads%252F1YneA51oWzaIiwep9H5I%252F1000024423.gif%3Falt%3Dmedia%26token%3D40a169cc-12f1-403a-898c-b310f81ff52a&width=768&dpr=3&quality=100&sign=2c56c5687fac67b851708cbfacdf98aa&sv=3)

* * *

[](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF#qwen38-flash-next)
Qwen3.8-Flash-Next
===============================================================================================

As the frontier of foundation models pushes toward ever-larger parameter counts and ever-longer context windows, the question is no longer just how much we can scale, but how efficiently we can do so. Sustainable progress toward artificial general intelligence (AGI) that benefits everyone demands architectural innovation. Today, we are sharing a concrete step in that direction: Qwen3.8-Flash-Next.

[![Qwen3.8-Flash-Next Architecture](https://qianwen-res.oss-accelerate.aliyuncs.com/Qwen3.8-Flash-Next/architecture.png)](https://qianwen-res.oss-accelerate.aliyuncs.com/Qwen3.8-Flash-Next/architecture.png)

This experimental preview of the architecture that will underpin Qwen4 is built around a fundamental rethinking of how the core components of modern large language models (LLMs) interact at scale.

[](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF#highlights)
Highlights
--------------------------------------------------------------------------------

The first open-weight release under this architecture is Qwen3.8-Flash-Next, which introduces:

*   **Hybrid Attention with QSA**: The Gated DeltaNet and Gated Attention pairing has been reworked into Gated DeltaNet and Qwen Sparse Attention (QSA). Rather than selecting individual tokens for processing, QSA operates at the micro-block level. This cuts long-context latency significantly, a critical gain as agentic workloads increasingly dominate real-world usage.
*   **Gated Residual**: Residual streams with normalization are what make deep LLM training manageable. Gated Residual modulates information flowing through widened residual streams via an element-wise, data-dependent read gate and a per-branch scalar write gate. This brings finer-grained expressiveness across layers while preserving training stability and keeping inference overhead low.
*   **N-gram Embedding**: Embeddings provide a unique axis for parameter scaling that requires less computation and is more amenable to offloading than Mixture-of-Experts (MoE). By indexing with short n-grams, this approach makes parameter scaling highly efficient for memory-constrained accelerators without sacrificing quality.
*   **Tailored Training Recipe**: The Muon and AdamW optimizers are applied to specific weight categories to maximize efficiency. Guided by refitted scaling laws, we eliminate traditional batch-size warmups and start directly at the target batch size, substantially reducing total optimizer steps while safely supporting larger learning rates for robust convergence.

For more details, please refer to our blog post [Qwen3.8-Flash-Next](https://qwen.ai/blog?id=qwen3.8-flash-next)
 and [the technical report](https://github.com/QwenLM/Qwen3.8-Flash-Next/blob/main/tech_report.pdf)
.

We are excited to embark on this next chapter with you and welcome your feedback as we build what comes next.

[](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF#model-overview)
Model Overview
----------------------------------------------------------------------------------------

*   Type: Causal Language Model with Vision Encoder
*   Training Stage: Pre-training & Post-training
*   Language Model
    *   Number of Parameters: 125B with 6B activated, plus 51B n-gram embedding and 4B MTP
    *   Hidden Dimension: 2560
    *   Token Embedding: 248320 (Padded)
    *   N-gram Embedding: 20,000,000 (bigrams/trigrams at layer 2)
    *   Number of Layers: 48
    *   Hidden Layout: 12 × (3 × (Gated DeltaNet → MoE) → 1 × (Qwen Sparse Attention → MoE))
    *   Gated DeltaNet:
        *   Number of Linear Attention Heads: 48 for V and 16 for QK
        *   Head Dimension: 128
    *   Qwen Sparse Attention:
        *   Number of Attention Heads: 24 for Q and 2 for KV
        *   Head Dimension: 256
        *   Rotary Position Embedding Dimension: 64
        *   Indexer Structure: MQA with 4 Query Heads and 1 Shared Key Head
        *   Indexer Head Dimension: 128
        *   Budget: 512 blocks or 2048 tokens
    *   Mixture Of Experts
        *   Number of Experts: 512
        *   Number of Activated Experts: 10 Routed + 1 Shared
        *   Expert Intermediate Dimension: 640
    *   Gated Residual:
        *   Number of Branches: 4
        *   Bottleneck Rank: 320
    *   LM Output: 248320 (Padded)
    *   MTP: 1 layer, trained with multi-steps
*   Context Length: 262,144 natively and extensible up to 1,000,000 tokens.

[](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF#benchmark-results)
Benchmark Results
----------------------------------------------------------------------------------------------

### [](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF#language)
Language

|     | Qwen3.8-Flash-Next | Qwen3.8-27B | Qwen3.7-Plus | DeepSeek-V4-Flash-0731 | Claude-Opus-4.6 (Max) |
| --- | --- | --- | --- | --- | --- |
| \# Params | 125B | 27B | 397B | 284B | \-- |
| \# Activated params | 6B  | 27B | 17B | 13B | \-- |
| \# N-gram embedding params | 51B | \-- | \-- | \-- | \-- |
| Coding |     |     |     |     |     |
| Agentic coding<br><br>DeepSWE 1.1 | **58.7** | 42.2 | 16.5 | 54.4 | \-- |
| Agentic coding<br><br>SWE-bench Pro | **62.5** | 61.7 | 55.8 | 56.0 | 53.4 |
| Multilingual software engineering<br><br>SWE-bench Multilingual | **81.0** | 73.8 | 75.8 | \-- | 77.5 |
| Repo-level code generation<br><br>NL2Repo-Bench | 48.1 | 42.3 | 41.1 | **54.2** | 47.6 |
| Agent |     |     |     |     |     |
| Long-horizon office work<br><br>CoWorkBench | **73.9** | 70.7 | 65.1 | 45.1 | 68.2 |
| Professional job tasks<br><br>JobBench | **55.7** | 33.4 | 27.6 | 41.3 | 36.6 |
| Frontier agentic tasks<br><br>Agents' Last Exam | Pass@1<br><br>24.3<br><br>Score<br><br>**51.2** | Pass@1<br><br>20.4<br><br>Score<br><br>42.9 | Pass@1<br><br>13.2<br><br>Score<br><br>33.6 | Pass@1<br><br>**25.2**<br><br>Score<br><br>\-- | \-- |
| Real-world tool use<br><br>Toolathlon Verified (Pass@1) | **73.5** | 67.1 | 50.6 | 70.3 | \-- |
| General |     |     |     |     |     |
| Instruction following<br><br>IFBench | **81.3** | 79.5 | 79.1 | 79.2 | 62.5 |
| Scientific reasoning<br><br>GPQA Diamond | **91.7** | 89.2 | 90.3 | 90.8 | 91.3 |
| Multidisciplinary reasoning<br><br>HLE | 35.9 | 30.8 | 34.7 | 33.8 | **40.0** |
| Competitive coding<br><br>LiveCodeBench v6 | **91.9** | 90.3 | 89.6 | 90.6 | 88.8 |

1\. DeepSWE 1.1: evaluated with the Claude Code and mini-SWE-agent harnesses, temp=1.0, top\_p=0.95, 256K context window. We report the highest score across the two harnesses; notably, Qwen3.8-Flash-Next performs best on mini-SWE-agent.  
2\. SWE-bench Pro: except for Claude-Opus-4.6 (Max), for which we report the officially published score, all models are evaluated with the Claude Code harness, temp=1.0, top\_p=0.95, 256K context window. Problematic tasks were corrected and all baseline models were re-evaluated on the refined benchmark.  
3\. SWE-bench Multilingual: evaluated with the mini-SWE-agent harness, temp=1.0, top\_p=0.95, 256K context window.  
4\. NL2Repo-Bench: evaluated with the Claude Code harness. To prevent reward hacking, we disable Bash commands that attempt to access the specific repository, such as pip download, pip install and git clone.  
5\. CoWorkBench: an in-house cowork benchmark for evaluating long-horizon office and productivity agent tasks across computer science, finance, law, medical and other productivity domains.  
6\. HLE: judged by GPT-4o.  
7\. The best result in each row is shown in bold.  
8\. Empty cells (--): scores are not yet available or are not applicable.

### [](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF#vision-language)
Vision Language

```

</details>

<details><summary>Tool result · web_search · call_aeac9d0912224d9fa29c9d80</summary>

**Firecrawl · section 1 of 112**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,873 characters · included below
- Section 2 · 11,697 characters · omitted from this copy
- Section 3 · 11,878 characters · omitted from this copy
- Section 4 · 11,868 characters · omitted from this copy
- Section 5 · 11,795 characters · omitted from this copy
- Section 6 · 11,861 characters · omitted from this copy
- Section 7 · 11,623 characters · omitted from this copy
- Section 8 · 11,396 characters · omitted from this copy
- Section 9 · 10,357 characters · omitted from this copy
- Section 10 · 11,656 characters · omitted from this copy
- Section 11 · 11,657 characters · omitted from this copy
- Section 12 · 11,832 characters · omitted from this copy
- Section 13 · 11,995 characters · omitted from this copy
- Section 14 · 11,947 characters · omitted from this copy
- Section 15 · 11,759 characters · omitted from this copy
- Section 16 · 10,147 characters · omitted from this copy
- Section 17 · 11,970 characters · omitted from this copy
- Section 18 · 11,470 characters · omitted from this copy
- Section 19 · 11,736 characters · omitted from this copy
- Section 20 · 11,883 characters · omitted from this copy
- Section 21 · 11,981 characters · omitted from this copy
- Section 22 · 11,985 characters · omitted from this copy
- Section 23 · 11,825 characters · omitted from this copy
- Section 24 · 11,242 characters · omitted from this copy
- Section 25 · 11,980 characters · omitted from this copy
- Section 26 · 9,541 characters · omitted from this copy
- Section 27 · 11,910 characters · omitted from this copy
- Section 28 · 11,488 characters · omitted from this copy
- Section 29 · 11,958 characters · omitted from this copy
- Section 30 · 11,801 characters · omitted from this copy
- Section 31 · 11,981 characters · omitted from this copy
- Section 32 · 11,776 characters · omitted from this copy
- Section 33 · 11,578 characters · omitted from this copy
- Section 34 · 11,962 characters · omitted from this copy
- Section 35 · 11,977 characters · omitted from this copy
- Section 36 · 11,768 characters · omitted from this copy
- Section 37 · 11,926 characters · omitted from this copy
- Section 38 · 11,573 characters · omitted from this copy
- Section 39 · 11,905 characters · omitted from this copy
- Section 40 · 11,791 characters · omitted from this copy
- Section 41 · 11,695 characters · omitted from this copy
- Section 42 · 11,993 characters · omitted from this copy
- Section 43 · 11,873 characters · omitted from this copy
- Section 44 · 11,676 characters · omitted from this copy
- Section 45 · 11,906 characters · omitted from this copy
- Section 46 · 11,991 characters · omitted from this copy
- Section 47 · 11,994 characters · omitted from this copy
- Section 48 · 11,914 characters · omitted from this copy
- Section 49 · 11,924 characters · omitted from this copy
- Section 50 · 11,818 characters · omitted from this copy
- Section 51 · 11,463 characters · omitted from this copy
- Section 52 · 11,978 characters · omitted from this copy
- Section 53 · 11,986 characters · omitted from this copy
- Section 54 · 11,973 characters · omitted from this copy
- Section 55 · 11,992 characters · omitted from this copy
- Section 56 · 11,897 characters · omitted from this copy
- Section 57 · 11,623 characters · omitted from this copy
- Section 58 · 11,959 characters · omitted from this copy
- Section 59 · 11,901 characters · omitted from this copy
- Section 60 · 11,666 characters · omitted from this copy
- Section 61 · 11,735 characters · omitted from this copy
- Section 62 · 11,950 characters · omitted from this copy
- Section 63 · 11,944 characters · omitted from this copy
- Section 64 · 11,881 characters · omitted from this copy
- Section 65 · 11,865 characters · omitted from this copy
- Section 66 · 11,994 characters · omitted from this copy
- Section 67 · 11,771 characters · omitted from this copy
- Section 68 · 11,957 characters · omitted from this copy
- Section 69 · 11,742 characters · omitted from this copy
- Section 70 · 11,995 characters · omitted from this copy
- Section 71 · 11,837 characters · omitted from this copy
- Section 72 · 11,988 characters · omitted from this copy
- Section 73 · 11,989 characters · omitted from this copy
- Section 74 · 11,988 characters · omitted from this copy
- Section 75 · 11,843 characters · omitted from this copy
- Section 76 · 11,803 characters · omitted from this copy
- Section 77 · 11,952 characters · omitted from this copy
- Section 78 · 11,984 characters · omitted from this copy
- Section 79 · 11,993 characters · omitted from this copy
- Section 80 · 11,891 characters · omitted from this copy
- Section 81 · 11,206 characters · omitted from this copy
- Section 82 · 11,996 characters · omitted from this copy
- Section 83 · 9,821 characters · omitted from this copy
- Section 84 · 11,972 characters · omitted from this copy
- Section 85 · 11,512 characters · omitted from this copy
- Section 86 · 11,963 characters · omitted from this copy
- Section 87 · 11,448 characters · omitted from this copy
- Section 88 · 11,811 characters · omitted from this copy
- Section 89 · 11,597 characters · omitted from this copy
- Section 90 · 11,334 characters · omitted from this copy
- Section 91 · 11,812 characters · omitted from this copy
- Section 92 · 11,808 characters · omitted from this copy
- Section 93 · 11,985 characters · omitted from this copy
- Section 94 · 11,233 characters · omitted from this copy
- Section 95 · 11,468 characters · omitted from this copy
- Section 96 · 11,869 characters · omitted from this copy
- Section 97 · 11,363 characters · omitted from this copy
- Section 98 · 11,953 characters · omitted from this copy
- Section 99 · 11,922 characters · omitted from this copy
- Section 100 · 9,891 characters · omitted from this copy
- Section 101 · 11,784 characters · omitted from this copy
- Section 102 · 11,593 characters · omitted from this copy
- Section 103 · 10,802 characters · omitted from this copy
- Section 104 · 11,970 characters · omitted from this copy
- Section 105 · 11,951 characters · omitted from this copy
- Section 106 · 11,995 characters · omitted from this copy
- Section 107 · 11,836 characters · omitted from this copy
- Section 108 · 11,788 characters · omitted from this copy
- Section 109 · 10,758 characters · omitted from this copy
- Section 110 · 11,866 characters · omitted from this copy
- Section 111 · 11,947 characters · omitted from this copy
- Section 112 · 4,117 characters · omitted from this copy

```text
## 1. Local LLM Inference Optimization: The Complete Guide

https://carteakey.dev/blog/local-inference/local-llm-optimization/

Jun 12, 2026 ... For MTP speculative decoding, benchmark draft acceptance and KV cache precision under your real sampling parameters. ... Attention, KV cache ...

[Skip to main content](https://carteakey.dev/blog/local-inference/local-llm-optimization/#main-content)

* * *

Copy as Markdown

[View Raw (.txt)](https://carteakey.dev/blog/local-inference/local-llm-optimization/raw.txt)

Outline

Preface [#](https://carteakey.dev/blog/local-inference/local-llm-optimization/#preface)

----------------------------------------------------------------------------------------

Over the past year I've written posts on running [gpt-oss-120b](https://carteakey.dev/blog/local-inference/optimizing-gpt-oss-120b-local-inference/)
, [Qwen3-Coder-Next](https://carteakey.dev/blog/local-inference/optimizing-qwen3-coder-next-local-inference/)
, [Gemma 4 26B](https://carteakey.dev/blog/local-inference/running-gemma-4-26b-a4b-locally/)
, [Qwen3.6-35B-A3B](https://carteakey.dev/blog/local-inference/running-qwen3-6-35b-a3b-locally/)
, [Gemma 4 MTP](https://carteakey.dev/blog/local-inference/running-gemma-4-mtp-locally/)
, [Qwen3.8-27B](https://carteakey.dev/blog/local-inference/running-qwen3-8-27b-locally/)
, [Qwen3.8-Flash-Next](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/)
, and [Strata](https://carteakey.dev/blog/local-inference/strata-on-an-rtx-4070/)
 locally on consumer hardware. Each post has its own failure modes and tuning logs, yet the same lessons keep showing up: check your RAM speed first, pin threads to P-cores, quantize the KV cache, and don't trust the default desktop power profile.

Rather than re-discovering the same flags in every new model write-up, I wanted one master reference I could link back to. If you're hitting a throughput wall, setting up a workstation from scratch, or trying to figure out what a specific knob actually changes, start here.

The scope is wide, though my measurements come from one machine: [🧠 yeti-cachy](https://carteakey.dev/devices/yeti-cachy/)
, my main homelab node with an RTX 4070, an Intel i5-12600K, DDR5 memory (upgraded from 32 GB to 64 GB mid-year), CachyOS Linux, CUDA, and source builds of llama.cpp alongside model-specific runtimes like [Strata](https://carteakey.dev/blog/local-inference/strata-on-an-rtx-4070/)
. Because my RAM capacity changed during the project, the [L3MS dashboard](https://github.com/carteakey/l3ms)
 records the exact hardware snapshot for each run instead of pretending every result came from a fixed box. The Apple Silicon, AMD, and multi-GPU sections are here as starting points, though I haven't tested those setups myself.

When I share a throughput number or memory ceiling, I measured it on this node. Where I'm describing upstream llama.cpp behavior or an untested lead, I'll say so plainly.

1\. TL;DR: Start Here [#](https://carteakey.dev/blog/local-inference/local-llm-optimization/#1-tl-dr-start-here)

-----------------------------------------------------------------------------------------------------------------

*   Build llama.cpp from source when you want full flag control and portable performance. Most of this guide assumes you have direct access to `llama-server` flags.
*   If a custom "overfit" engine exists for your exact model and GPU, test it alongside llama.cpp. Moving [Qwen3.8-Flash-Next](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/)
     from llama.cpp to [Strata](https://carteakey.dev/blog/local-inference/strata-on-an-rtx-4070/)
     nearly tripled my long-context decode speed from 27 tok/s to 75 tok/s on the same card.
*   Use LM Studio when you want a desktop GUI, easy model browsing, and a local OpenAI-compatible server with JIT loading and idle eviction.
*   Evaluate vLLM when you need multi-user serving and continuous batching on datacenter GPUs.
*   On Apple Silicon, compare llama.cpp Metal with mlx; unified memory changes the sizing math completely.
*   If token generation is unexpectedly slow on an MoE model, check your RAM clock before touching any software flags. Enabling XMP brought my machine back from roughly one-third speed.
*   When you hit VRAM limits, drop `--parallel` to a single slot, quantize the KV cache (symmetric q8\_0 or asymmetric K8V4), trim context to what you actually use, and let `--fit` place the remaining layers.
*   When a model ships with Per-Layer Embeddings (PLE) like Qwen3.8-Flash-Next, leave mmap enabled so the giant embedding lookup table streams from NVMe SSD instead of evicting active MoE experts from system RAM.
*   For MTP speculative decoding, benchmark draft acceptance and KV cache precision under your real sampling parameters. Greedy decoding (`temp = 0`) flatters draft acceptance and can trigger `<think>` repetition loops on reasoning models.
*   For coding agents, measure time to first token, prompt processing, decode speed, prompt-cache reuse, and full tool-call loop latency together.

### 1.1 Where to Jump In [#](https://carteakey.dev/blog/local-inference/local-llm-optimization/#1-1-where-to-jump-in)

This is a workbench reference, not a linear tutorial. Jump straight to the part that matches your problem:

*   Slow MoE generation: check [the 3-tier memory hierarchy and RAM speed](https://carteakey.dev/blog/local-inference/local-llm-optimization/#6-1-the-memory-hierarchy-the-most-important-mental-model)
    , then [layer placement and dynamic expert caching](https://carteakey.dev/blog/local-inference/local-llm-optimization/#10-layer-placement-the-core-optimization-for-moe)
    , and [P-core thread pinning](https://carteakey.dev/blog/local-inference/local-llm-optimization/#14-3-taskset-p-core-pinning-linux)
    .
*   A model that won't load or crashes mid-session: start with [`--fit` placement](https://carteakey.dev/blog/local-inference/local-llm-optimization/#10-4-fit-automatic-placement)
    , [context and KV cache sizing](https://carteakey.dev/blog/local-inference/local-llm-optimization/#11-context-and-kv-cache)
    , and the [known OOM and TG variability table](https://carteakey.dev/blog/local-inference/local-llm-optimization/#known-tg-variability-root-causes)
    .
*   A model with a huge PLE table (like Qwen3.8-Flash-Next) thrashing RAM: see [the `--no-mmap` PLE exception](https://carteakey.dev/blog/local-inference/local-llm-optimization/#15-1-no-mmap)
     and [3-tier NVMe streaming](https://carteakey.dev/blog/local-inference/local-llm-optimization/#6-1-the-memory-hierarchy-the-most-important-mental-model)
    .
*   Vision failing at load or on the first image: go to [Vision / Multimodal](https://carteakey.dev/blog/local-inference/local-llm-optimization/#20-vision-multimodal)
    . The projector needs its own VRAM headroom (or a CPU offload path) and a large enough micro-batch.
*   MTP speculation that isn't faster than plain decoding: check [target vs draft KV precision](https://carteakey.dev/blog/local-inference/local-llm-optimization/#19-2-target-and-draft-kv-cache-precision)
    , [rejection spirals on offloaded MoEs](https://carteakey.dev/blog/local-inference/local-llm-optimization/#19-1-mtp-drafting-configuration-flags)
    , and [Thinking Mode sampling](https://carteakey.dev/blog/local-inference/local-llm-optimization/#13-1-temp-temperature)
    .
*   Coding agents that feel sluggish despite fast decode: measure the full inspect-and-edit loop in [Coding Workloads](https://carteakey.dev/blog/local-inference/local-llm-optimization/#18-coding-workloads-what-to-measure)
    .
*   Pushing a flagship MoE past llama.cpp's layer-offload ceiling: read [Dynamic Per-Expert Caching](https://carteakey.dev/blog/local-inference/local-llm-optimization/#10-5-static-placement-vs-dynamic-per-expert-caching)
     and [Custom Inference Engines & Specialized Forks](https://carteakey.dev/blog/local-inference/local-llm-optimization/#22-custom-inference-engines-specialized-forks-strata-ik-llama-cpp)
    .
*   More than one GPU: read the [Multi-GPU Primer](https://carteakey.dev/blog/local-inference/local-llm-optimization/#21-multi-gpu-primer)
     before guessing tensor split ratios.
*   LM Studio or Ollama users: the [hardware](https://carteakey.dev/blog/local-inference/local-llm-optimization/#6-hardware)
    , [OS tuning](https://carteakey.dev/blog/local-inference/local-llm-optimization/#7-os-choice)
    , and [security](https://carteakey.dev/blog/local-inference/local-llm-optimization/#23-security-notes)
     sections still apply directly, even where CLI flags don't.

### 1.2 Start with the Symptom [#](https://carteakey.dev/blog/local-inference/local-llm-optimization/#1-2-start-with-the-symptom)

| Symptom | Check first | Then change |
| --- | --- | --- |
| Model fails to load or dies late in a session | Free VRAM and real serving context | Drop slots to 1, quantize KV (`q8_0` or `K8V4`), raise `--fit-target` headroom, then tune [placement](https://carteakey.dev/blog/local-inference/local-llm-optimization/#10-layer-placement-the-core-optimization-for-moe) |
| Prompt processing is slow | Prefill speed with a realistic prompt | Sweep [`--ubatch-size`](https://carteakey.dev/blog/local-inference/local-llm-optimization/#12-2-ubatch-size-ub-physical-micro-batch)<br>; verify GPU offload and Flash Attention |
| Token generation is slow | Decode speed, RAM MT/s, CPU frequency | Fix XMP and OS power state, then compare [placement / expert caching](https://carteakey.dev/blog/local-inference/local-llm-optimization/#10-layer-placement-the-core-optimization-for-moe)<br> and [P-core pinning](https://carteakey.dev/blog/local-inference/local-llm-optimization/#14-3-taskset-p-core-pinning-linux) |
| Speculation adds no speed | Draft acceptance rate and end-to-end loop time | Cap `--spec-draft-n-max` to 2, set `--spec-draft-p-min 0.7`, or check [KV precision](https://carteakey.dev/blog/local-inference/local-llm-optimization/#19-2-target-and-draft-kv-cache-precision)<br> and [PLE quantization](https://carteakey.dev/blog/local-inference/local-llm-optimization/#15-1-no-mmap) |
| Reasoning model loops inside `<think>` | Sampling temperature and penalties | Switch from greedy (`temp 0`) to [official Thinking Mode sampling](https://carteakey.dev/blog/local-inference/local-llm-optimization/#13-1-temp-temperature)<br> (`temp 1.0, top-p 0.95, top-k 20`) |
| Two GPUs are slower than one | Split mode and PCIe interconnect | Start with [layer mode](https://carteakey.dev/blog/local-inference/local-llm-optimization/#21-multi-gpu-primer)<br>; treat tensor mode as experimental |

### 1.3 Safe Starting Profiles [#](https://carteakey.dev/blog/local-inference/local-llm-optimization/#1-3-safe-starting-profiles)

These are the conservative starting profiles I use on my single-user node before doing model-specific sweeps.

| Workload | `--fit-target` | Context | KV cache | `--parallel` | Batch / ubatch |
| --- | --- | --- | --- | --- | --- |
| Text, 12 GB VRAM (standard) | 512 MiB | 64k | `q8_0` / `q8_0` | 1   | 1024 / 512 |
| Text, 12 GB VRAM (long-context MoE / hybrid) | 512 MiB | 128k–262k | `q8_0` / `q4_0` (`K8V4`) | 1   | 1024 / 512 |
| Text, 24 GB VRAM | 512–768 MiB | 128k | `q8_0` / `q8_0` | 1–2 | 1024 / 512 |
| Vision, 12 GB VRAM (GPU mmproj) | 2048 MiB | 64k | `q8_0` / `q8_0` | 1   | 256 / 512 |
| MTP speculative decoding | 512+ MiB | 64k–128k | Benchmark per model | 1   | 1024 / 512 |

2\. Optimization Priority Checklist [#](https://carteakey.dev/blog/local-inference/local-llm-optimization/#2-optimization-priority-checklist)

----------------------------------------------------------------------------------------------------------------------------------------------

Here's the order I work through on my node, ranked by how much throughput or stability each step actually buys.

```

</details>

<details><summary>Tool result · web_search · call_1bf2830dac904bca9f91d0c4</summary>

**Firecrawl · section 1 of 33**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,926 characters · included below
- Section 2 · 11,744 characters · omitted from this copy
- Section 3 · 11,636 characters · omitted from this copy
- Section 4 · 11,799 characters · omitted from this copy
- Section 5 · 11,884 characters · omitted from this copy
- Section 6 · 11,997 characters · omitted from this copy
- Section 7 · 11,620 characters · omitted from this copy
- Section 8 · 11,767 characters · omitted from this copy
- Section 9 · 11,799 characters · omitted from this copy
- Section 10 · 10,204 characters · omitted from this copy
- Section 11 · 11,768 characters · omitted from this copy
- Section 12 · 10,848 characters · omitted from this copy
- Section 13 · 11,898 characters · omitted from this copy
- Section 14 · 11,856 characters · omitted from this copy
- Section 15 · 11,764 characters · omitted from this copy
- Section 16 · 11,975 characters · omitted from this copy
- Section 17 · 11,773 characters · omitted from this copy
- Section 18 · 11,469 characters · omitted from this copy
- Section 19 · 11,604 characters · omitted from this copy
- Section 20 · 11,323 characters · omitted from this copy
- Section 21 · 11,711 characters · omitted from this copy
- Section 22 · 11,876 characters · omitted from this copy
- Section 23 · 11,992 characters · omitted from this copy
- Section 24 · 11,121 characters · omitted from this copy
- Section 25 · 11,814 characters · omitted from this copy
- Section 26 · 11,894 characters · omitted from this copy
- Section 27 · 11,591 characters · omitted from this copy
- Section 28 · 11,989 characters · omitted from this copy
- Section 29 · 11,878 characters · omitted from this copy
- Section 30 · 11,851 characters · omitted from this copy
- Section 31 · 11,690 characters · omitted from this copy
- Section 32 · 11,850 characters · omitted from this copy
- Section 33 · 5,670 characters · omitted from this copy

```text
## 1. Reimagining Memory Access for LLM Inference - arXiv

https://arxiv.org/html/2503.18869v1

Mar 24, 2025 ... 7: Comparison of KV cache bit-plane 4KB compression ratios in the ... All router layers are using BF16 precision for accuracy. Fig. 10 ...

[Skip to main content](https://arxiv.org/html/2503.18869v1#infobox)

Title: 

Content selection saved. Describe the issue below:

Description:

[License: arXiv.org perpetual non-exclusive license](https://info.arxiv.org/help/license/index.html#licenses-available)

arXiv:2503.18869v1 \[cs.AR\] 24 Mar 2025

Reimagining Memory Access for LLM Inference: Compression-Aware Memory Controller Design  

==========================================================================================

Rui Xie1, Asad Ul Haq1, Linsen Ma1, Yunhua Fang1, Zirak Burzin Engineer2, Liu Liu1, and Tong Zhang1 Affiliation: 1Rensselaer Polytechnic Institute, Troy, NY, USA  
2Wiseburn Da Vinci Science, El Segundo, CA, USA

###### Abstract

The efficiency of Large Language Model (LLM) inference is often constrained by substantial memory bandwidth and capacity demands. Existing techniques, such as pruning, quantization, and mixture of experts/depth, reduce memory capacity and/or bandwidth consumption at the cost of slight degradation in inference quality. This paper introduces a design solution that further alleviates memory bottlenecks by enhancing the on-chip memory controller in AI accelerators to achieve two main objectives: (1) significantly reducing memory capacity and bandwidth usage through lossless block compression (e.g., LZ4 and ZSTD) of model weights and key-value (KV) cache without compromising inference quality, and (2) enabling memory bandwidth and energy consumption to scale proportionally with context-dependent dynamic quantization. These goals are accomplished by equipping the on-chip memory controller with mechanisms to improve fine-grained bit-level accessibility and compressibility of weights and KV cache through LLM-aware configuration of in-memory placement and representation. Experimental results on publicly available LLMs demonstrate the effectiveness of this approach, showing memory footprint reductions of 25.2% for model weights and 46.9% for KV cache. In addition, our hardware prototype at 4 GHz and 32 lanes (7 nm) achieves 8 TB/s throughput with a modest area overhead (under 3.8 mm2), which underscores the viability of LLM-aware memory control as a key to efficient large-scale inference.

I Introduction
--------------

Large Language Models (LLMs) have pushed the boundaries of natural language processing and generative AI by achieving impressive performance on tasks such as text generation, question answering, and code completion. As these models scale to billions or even trillions of parameters, however, their inference demands become increasingly constrained by memory bandwidth and capacity \[[1](https://arxiv.org/html/2503.18869v1#bib.bib1)\
\]. While the raw compute may be adequate, the sheer volume of parameters and associated data transfers often stalls the accelerator, resulting in suboptimal throughput and higher operational costs. Under these conditions, memory pressure intensifies, since the system must fetch billions of parameters from off-chip DRAM repeatedly, layer by layer, for each user request. Even small inefficiencies in memory access can cascade into significant overall slowdowns, magnifying both inference time and total operational cost. Furthermore, since LLMs are often fine-tuned or adapted for specialized domains, their parameters can be heterogeneous, featuring layers that might be more compressible than others. Such diversity further underscores the importance of a memory subsystem that can flexibly and efficiently handle different data patterns.

To alleviate this bottleneck, researchers have extensively explored _lossy compression_ techniques, such as pruning, quantization, and mixture of experts/depth, which reduce memory consumption at the cost of minor (though sometimes noticeable) degradation in inference quality \[[2](https://arxiv.org/html/2503.18869v1#bib.bib2)\
, [3](https://arxiv.org/html/2503.18869v1#bib.bib3)\
, [4](https://arxiv.org/html/2503.18869v1#bib.bib4)\
\]. These methods have shown promise for large-scale LLMs, but they necessarily introduce approximations. By contrast, _lossless compression_ could preserve exact numerical fidelity while still shrinking the model footprint; however, floating-point data generally exhibit low compressibility under standard algorithms (e.g., LZ4 \[[5](https://arxiv.org/html/2503.18869v1#bib.bib5)\
\], ZSTD \[[6](https://arxiv.org/html/2503.18869v1#bib.bib6)\
\]), thus limiting their efficacy in practice.

This paper introduces an approach to notably increase the lossless compressibility of model weights and key-value (KV) cache by optimizing their in-memory bit-level placement and representation. Motivated by prior works on bit-plane data placement \[[7](https://arxiv.org/html/2503.18869v1#bib.bib7)\
, [8](https://arxiv.org/html/2503.18869v1#bib.bib8)\
, [9](https://arxiv.org/html/2503.18869v1#bib.bib9)\
\], we propose two specific techniques: (1) Bit-plane disaggregation: Instead of storing all bits of each weight or KV cache element (e.g., FP16 or FP8) contiguously, we organize data by keeping same-position bits together, effectively creating a bit-level in-memory column-store \[[10](https://arxiv.org/html/2503.18869v1#bib.bib10)\
, [11](https://arxiv.org/html/2503.18869v1#bib.bib11)\
\]. (2) Cross-token KV cache clustering and de-correlation: Observing that KV cache elements on the same channel of adjacent tokens tend to show stronger bit-level correlation, we cluster these elements together in memory and apply simple de-correlation mechanisms (e.g., subtraction) to reduce bit-level entropy. By applying these techniques to model weights and KV cache, we can largely enhance their lossless compressibility (especially for KV cache), enabling effective use of conventional lossless compression algorithms like LZ4 and ZSTD.

Additionally, recent studies \[[12](https://arxiv.org/html/2503.18869v1#bib.bib12)\
, [13](https://arxiv.org/html/2503.18869v1#bib.bib13)\
\] reveal that the importance of different weights and KV cache elements varies significantly based on runtime context during inference, opening the door for dynamic quantization to further improve efficiency. With AI accelerators now supporting variable-precision arithmetic at the hardware level, these systems can leverage context-dependent quantization (e.g., dynamically adjusting precision from FP16 to FP8) to enhance computational efficiency. However, it is not immediately clear how memory bandwidth/energy consumption can be proportionally reduced. Coincidentally, our bit-plane disaggregation technique can fill this missing link: it enables memory bandwidth and energy consumption to scale gracefully with context-adaptive dynamic quantization of weights and KV cache.

To ensure practical feasibility, we propose integrating these techniques, along with hardware-accelerated lossless compression and decompression, into the on-chip memory controller of AI accelerators. This approach minimizes changes to the computational framework and software stack, as the memory controller only needs to be aware of the data semantics of weights and KV cache. All bit-level data manipulations and compression tasks occur within the memory controller, remaining transparent to the computing fabric and software stack. Through extensive experiments on publicly available LLMs, we demonstrate that our approach achieves significant reductions in memory footprint without compromising inference accuracy. Experimental results reveal memory footprint reductions of 25.2% for model weights and 46.9% for KV cache when using ZSTD lossless compression. Moreover, simulations conducted using DRAMSim3 \[[14](https://arxiv.org/html/2503.18869v1#bib.bib14)\
\] demonstrate that, compared to straightforward in-memory placement, our proposed approach can reduce data load latency by up to 32.0% and lower memory access energy consumption by 29.9%.

II Background and Motivation
----------------------------

### II-A Memory Challenges in LLM Inference

During LLM inference, the model repeatedly generates tokens by passing the entire input sequence (including previously generated tokens) through multiple layers. In large models (e.g., LLaMA 3.1 405B \[[15](https://arxiv.org/html/2503.18869v1#bib.bib15)\
\], DeepSeek R1 671B \[[16](https://arxiv.org/html/2503.18869v1#bib.bib16)\
\]), storing these weights already demands significant capacity (750GB of LLaMA 3.1 405B, 1543GB of DeepSeek R1 671B). Beyond the parameters, every token update must also preserve a key-value (KV) cache that expands with sequence length. As shown in Fig. [1](https://arxiv.org/html/2503.18869v1#S2.F1 "Fig. 1 ‣ II-A Memory Challenges in LLM Inference ‣ II Background and Motivation ‣ Reimagining Memory Access for LLM Inference: Compression-Aware Memory Controller Design")
, once the sequence extends beyond a few thousand tokens, the KV cache can overshadow all other memory components, exceeding 90% of the total footprint in the LLaMA 3.1 8B model. This quickly becomes a capacity crisis, requiring substantial DRAM or HBM provisioning to prevent frequent swapping or out-of-memory failures.

![Refer to caption](https://arxiv.org/html/2503.18869v1/kv_vs_model.png)

Fig. 1: Percentage contribution of KV cache and model weights to total memory footprint with increasing sequence length in LLaMA 3.1 8B model.

In autoregressive decoding, each new token must read and compute against all model weights layer by layer, incurring large, repeated bandwidth demands. Moreover, tokens in the KV cache must be fetched (and updated) for attention calculations. Hence, both model weights and historical context collectively exert high bandwidth pressure on the memory subsystem. Even if the hardware provides ample compute throughput, inference throughput can stall unless memory traffic (i.e., read requests for weights and KV data) can be served rapidly. Alleviating this bandwidth bottleneck is often as critical as reducing raw model size, since partial or frequent memory stalls directly prolong token generation latency.

### II-B Lossless compression on LLM

Lossless compression holds the promise of reducing memory usage without degrading inference quality, making it an attractive complement to existing _lossy_ techniques. In principle, general-purpose methods such as LZ4 \[[5](https://arxiv.org/html/2503.18869v1#bib.bib5)\
\] and ZSTD \[[6](https://arxiv.org/html/2503.18869v1#bib.bib6)\
\] can detect repeated byte sequences, zeros, or short runs of similar data, thus condensing the stored representation. However, as shown in Table [I](https://arxiv.org/html/2503.18869v1#S2.T1 "TABLE I ‣ II-B Lossless compression on LLM ‣ II Background and Motivation ‣ Reimagining Memory Access for LLM Inference: Compression-Aware Memory Controller Design")
, straightforwardly applying these compressors to LLM data (i.e., model weights and key-value (KV) caches) yields only limited success. LZ4 fails to reduce the footprint of weights and KV caches in most cases, and ZSTD attains moderate gains for some model parameters (e.g., 23% on Gemma 2 2B weights \[[17](https://arxiv.org/html/2503.18869v1#bib.bib17)\
\]).

TABLE I: Model weights and KV cache footprint reduction under lossless compression.

| Comp. Method | LLaMA 3.1 8B | Gemma 2 2B | Mistral 7B | OPT 13B | Mixtral 8×7B |
| --- | --- | --- | --- | --- | --- |
| Model Weights |     |     |     |     |     |
| --- | --- | --- | --- | --- | --- |
| LZ4 | 0.0% | 11.5% | 0.0% | 0.0% | 18.0% |
| ZSTD | 20.6% | 23.0% | 17.3% | 19.4% | 21.3% |
| KV Cache on BookSum Dataset |     |     |     |     |     |
| LZ4 | 0.0% | 0.0% | 0.0% | 0.0% | 0.0% |
| ZSTD | 6.5% | 2.9% | 0.9% | 2.0% | 3.8% |

```

</details>

## Assistant · #7

<details><summary>Reasoning · 1,050 characters</summary>

The user is asking about Qwen3.8-Flash-Next specifically. There's a carteakey.dev blog post about running Qwen3.8-Flash-Next locally, and the master guide mentions "target and draft KV cache precision" section 19.2. Also there's a "Hadamard transforms for K-cache" section 99 in the ik_llama.cpp resource, and "Quantization additions" section 98.

Let me look at the most promising sections:
- Resource 654be1f5 sections 98-100 (Quantization additions, Hadamard transforms for K-cache) — likely ik_llama.cpp specific.
- Resource 654be1f5 section 107 (Memory Type Selection) — llama.cpp DeepWiki.
- Resource 6f19617f section 28 "Is FP16 better than BF16?"
- The carteakey blog post specifically about Qwen3.8-Flash-Next: https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/ — likely has F16 vs BF16 KV cache comparison.

Let me read those sections and scrape the Qwen3.8-Flash-Next blog post.

Also the sotaaz fp8-kv-cache post might compare bf16.

Let me do parallel: read sections and scrape the carteakey flash-next post.


</details>

<details><summary>Tool request · context_read · call_59240ab0edff45e9bb0839ff</summary>

```json
{
  "kind": "resource",
  "id": "654be1f5-6a9e-44d0-8ee5-6bbe44f63f9b",
  "section": 99
}
```

</details>

<details><summary>Tool request · context_read · call_f141d148a50f43478a23bc6b</summary>

```json
{
  "kind": "resource",
  "id": "654be1f5-6a9e-44d0-8ee5-6bbe44f63f9b",
  "section": 107
}
```

</details>

<details><summary>Tool request · web_scrape · call_b94ac13007ea465cb7b7353b</summary>

```json
{
  "url": "https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/"
}
```

</details>

Good leads. Let me open the most relevant sections and scrape the model-specific post.
<details><summary>Tool result · context_read · call_59240ab0edff45e9bb0839ff</summary>

# Search: ik_llama.cpp IQ3_S KV cache bf16 precision lossless attention · section 99/112
Subsection: Hadamard transforms for K-cache

[](https://github.com/ikawrakow/ik_llama.cpp/#bitnet-bonsai-ternary)

`IQ1_BN`, `IQ2_BN` [PR 44](https://github.com/ikawrakow/ik_llama.cpp/pull/44)

`Q1_0_G128_R8` [PR 2541](https://github.com/ikawrakow/ik_llama.cpp/pull/2541)

`Q2_0` [PR 2659](https://github.com/ikawrakow/ik_llama.cpp/pull/2659)
 and 8-row repacked `Q2_0_R8` [PR 2785](https://github.com/ikawrakow/ik_llama.cpp/pull/2785)

`PQ2_0` / `PTQ1_0` (Prism ternary) and 8-row interleaved `PQ2_0_R8` / `PTQ1_0_R8` [PR 2550](https://github.com/ikawrakow/ik_llama.cpp/pull/2550)
 [PR 2691](https://github.com/ikawrakow/ik_llama.cpp/pull/2691)

Cuda implementations: `Q2_0` and `PQ2_0` [PR 2691](https://github.com/ikawrakow/ik_llama.cpp/pull/2691)
 [PR 2747](https://github.com/ikawrakow/ik_llama.cpp/pull/2747)
 (recommended for GPU offload). `PTQ1_0` and the `_R8` variants are currently CPU-only (recommended for CPU with `-rtr`).

Upstream/mainline ternary GGUFs (`TQ1_0`, `TQ2_0`) are supported through the lossless conversion script `scripts/repack_ternary_to_prism.py` (added with Maple in [PR 2694](https://github.com/ikawrakow/ik_llama.cpp/pull/2694)
): it repacks `TQ1_0` → `PTQ1_0` and `TQ2_0` → `PQ2_0` (QK 256 → 128) without re-quantisation, so decoded values are bit-for-bit identical. Usage: `python3 scripts/repack_ternary_to_prism.py input.gguf output.gguf`.

##### Hadamard transforms for K-cache

[](https://github.com/ikawrakow/ik_llama.cpp/#hadamard-transforms-for-k-cache)

CPU [PR 1033](https://github.com/ikawrakow/ik_llama.cpp/pull/1033)
 and CUDA [PR 1034](https://github.com/ikawrakow/ik_llama.cpp/pull/1034)

##### Hadamard transforms for V-cache

[](https://github.com/ikawrakow/ik_llama.cpp/#hadamard-transforms-for-v-cache)

[PR 1527](https://github.com/ikawrakow/ik_llama.cpp/pull/1527)

##### MXFP4 as used in gpt-oss models

[](https://github.com/ikawrakow/ik_llama.cpp/#mxfp4-as-used-in-gpt-oss-models)

Implemented for Zen4, AVX2, ARM\_NEON, Metal, CUDA [PR 682](https://github.com/ikawrakow/ik_llama.cpp/pull/682)

#### Quantization improvements

[](https://github.com/ikawrakow/ik_llama.cpp/#quantization-improvements)

*   `IQ1_M` [PR 327](https://github.com/ikawrakow/ik_llama.cpp/pull/327)
    , `IQ2_XS` [PR 312](https://github.com/ikawrakow/ik_llama.cpp/pull/312)
    , `Q2_K, Q4_K, Q5_K, Q4_1, Q5_1` [PR 302](https://github.com/ikawrakow/ik_llama.cpp/pull/302)
    , `Q4_0, Q5_0, Q6_0, Q3_K, Q6_K, IQ4_XS, IQ4_NL` [PR 295](https://github.com/ikawrakow/ik_llama.cpp/pull/295)
    
*   Low perplexity `Q4_0` KV cache [PR 1547](https://github.com/ikawrakow/ik_llama.cpp/pull/1547)
     [PR 1556](https://github.com/ikawrakow/ik_llama.cpp/pull/1556)
    
*   MTP: option to use re-quantized output tensor `--mtp-requantize-output-tensor new_type` [PR 1809](https://github.com/ikawrakow/ik_llama.cpp/pull/1809)
    

#### Quantization performance improvements

[](https://github.com/ikawrakow/ik_llama.cpp/#quantization-performance-improvements)

*   Much faster CPU prompt processing for all non-interleaved quants. Initial idea in [PR 515](https://github.com/ikawrakow/ik_llama.cpp/pull/515)
     and [PR 531](https://github.com/ikawrakow/ik_llama.cpp/pull/531)
    , with many follow up PRs to apply to all quantization types for the 3 supported CPU platforms.
*   All quantization types now have quantized matrix multiplication CUDA kernels, see [PR 557](https://github.com/ikawrakow/ik_llama.cpp/pull/557)
     and several others
*   Faster CPU prompt processing for Trellis quants and MoE models. [PR 488](https://github.com/ikawrakow/ik_llama.cpp/pull/488)
    
*   Trellis quants: faster CPU prompt processing [PR 482](https://github.com/ikawrakow/ik_llama.cpp/pull/482)
    .
*   Minor (~2%) `iq2_ks` TG performance improvement on CUDA [PR 468](https://github.com/ikawrakow/ik_llama.cpp/pull/468)
    
*   Faster `IQ3_KT` and `IQ4_KT` [PR 453](https://github.com/ikawrakow/ik_llama.cpp/pull/453)
    
*   Zen4: Faster PP for `IQ2_KS, IQ4_KS, IQ5_KS` [PR 428](https://github.com/ikawrakow/ik_llama.cpp/pull/428)
    
*   Fast GEMM/GEMV for `IQ1_S` [PR 212](https://github.com/ikawrakow/ik_llama.cpp/pull/212)
    
*   AVX-VNNI optimizations [PR 1446](https://github.com/ikawrakow/ik_llama.cpp/pull/1446)
     [PR 1455](https://github.com/ikawrakow/ik_llama.cpp/pull/1455)
     [PR 1467](https://github.com/ikawrakow/ik_llama.cpp/pull/1467)
     [PR 1474](https://github.com/ikawrakow/ik_llama.cpp/pull/1474)
     [PR 1482](https://github.com/ikawrakow/ik_llama.cpp/pull/1482)
    

Features
--------

[](https://github.com/ikawrakow/ik_llama.cpp/#features)

*   New split mode "graph" for multi GPU setups [PR 1022](https://github.com/ikawrakow/ik_llama.cpp/pull/1022)
    
*   Fused delta-net for Qwen3-Next and Qwen3.5-MoE [PR 1315](https://github.com/ikawrakow/ik_llama.cpp/pull/1315)
     [PR 1333](https://github.com/ikawrakow/ik_llama.cpp/pull/1333)
     [PR 1362](https://github.com/ikawrakow/ik_llama.cpp/pull/1362)
     [PR 1373](https://github.com/ikawrakow/ik_llama.cpp/pull/1373)
    
*   Hadamard transforms for K-cache and V-cache [PR 1033](https://github.com/ikawrakow/ik_llama.cpp/pull/1033)
     [PR 1034](https://github.com/ikawrakow/ik_llama.cpp/pull/1034)
     [PR 1527](https://github.com/ikawrakow/ik_llama.cpp/pull/1527)
    
*   Auto-fit offloaded tensors to available VRAM (MoE and dense models) [PR 1501](https://github.com/ikawrakow/ik_llama.cpp/pull/1501)
     [PR 1504](https://github.com/ikawrakow/ik_llama.cpp/pull/1504)
    , allows per GPU fit margin [PR 1872](https://github.com/ikawrakow/ik_llama.cpp/pull/1872)
    
*   Checkpoints for recurrent models [PR 1310](https://github.com/ikawrakow/ik_llama.cpp/pull/1310)
     [PR 1398](https://github.com/ikawrakow/ik_llama.cpp/pull/1398)
    
*   MTP decoding support for popular models like GLM-4.x MoE [1270](https://github.com/ikawrakow/ik_llama.cpp/pull/1270)
    , GLM-5.3/glm5next [2548](https://github.com/ikawrakow/ik_llama.cpp/pull/2548)
    , Qwen 3.5/3.6 [1698](https://github.com/ikawrakow/ik_llama.cpp/pull/1698)
     [1745](https://github.com/ikawrakow/ik_llama.cpp/pull/1745)
    , Gemma 4 [1744](https://github.com/ikawrakow/ik_llama.cpp/pull/1744)
    , GLM 5 [1890](https://github.com/ikawrakow/ik_llama.cpp/pull/1890)
    , Step 3.7 [2250](https://github.com/ikawrakow/ik_llama.cpp/pull/2250)
    , Qwen 3.8 [2369](https://github.com/ikawrakow/ik_llama.cpp/pull/2369)
     (incl. standalone MTP heads via `-md`)
*   Self speculative decoding, ngram [PR 1261](https://github.com/ikawrakow/ik_llama.cpp/pull/1261)
    , suffix [PR 1646](https://github.com/ikawrakow/ik_llama.cpp/pull/1646)
    
*   DFlash initial support [PR 1970](https://github.com/ikawrakow/ik_llama.cpp/pull/1970)
    
*   DFlash 2 support for models like GLM-5.3-Flash and Qwen3.8-Flash-Next [PR 2761](https://github.com/ikawrakow/ik_llama.cpp/pull/2761)
    , Raon-1 mini preview
*   DSpark initial support [PR 2280](https://github.com/ikawrakow/ik_llama.cpp/pull/2280)
    
*   GLM-DSA architecture indexer cache
*   GLM-5.2 vision hack [PR 2283](https://github.com/ikawrakow/ik_llama.cpp/pull/2283)
    
*   String ban function for all completions [PR 1185](https://github.com/ikawrakow/ik_llama.cpp/pull/1185)
     [PR 1243](https://github.com/ikawrakow/ik_llama.cpp/pull/1243)
    
*   Expiring Logit Bias [PR 1731](https://github.com/ikawrakow/ik_llama.cpp/pull/1731)
    
*   OpenAI `/v1/responses` API endpoint [PR 1184](https://github.com/ikawrakow/ik_llama.cpp/pull/1184)
    
*   OpenAI `/v1/systemone` endpoint for decision models (lev, OpenJev, nimble) [PR 2592](https://github.com/ikawrakow/ik_llama.cpp/pull/2592)
    
*   Function call support [PR 628](https://github.com/ikawrakow/ik_llama.cpp/pull/628)
    
*   jinja template support [PR 677](https://github.com/ikawrakow/ik_llama.cpp/pull/677)
    
*   Webui: New Features for Conversations, Settings, and Chat Messages [PR 618](https://github.com/ikawrakow/ik_llama.cpp/pull/618)
    , MCP [PR 1904](https://github.com/ikawrakow/ik_llama.cpp/pull/1904)
    
*   On-demand tensor reload [PR 1989](https://github.com/ikawrakow/ik_llama.cpp/pull/1989)
    
*   Dynamic MoE expert cache [PR 2644](https://github.com/ikawrakow/ik_llama.cpp/pull/2644)
    
*   Multi-GPU CUDA quantization [PR 2674](https://github.com/ikawrakow/ik_llama.cpp/pull/2674)
    , with on-GPU encoding for more quantization types [PR 2671](https://github.com/ikawrakow/ik_llama.cpp/pull/2671)
     [PR 2682](https://github.com/ikawrakow/ik_llama.cpp/pull/2682)
    
*   `-cuda max-graphs=N` [PR 2715](https://github.com/ikawrakow/ik_llama.cpp/pull/2715)
    
*   Unicode NFC normalization for BPE tokenizers that declare `tokenizer.ggml.normalizer.nfc` [PR 2735](https://github.com/ikawrakow/ik_llama.cpp/pull/2735)
    
*   Per-device memory usage reported on `/memory` and `/metrics` [PR 2776](https://github.com/ikawrakow/ik_llama.cpp/pull/2776)
    
*   Fused-multiply-add (FMA) op in `ggml` [PR 2794](https://github.com/ikawrakow/ik_llama.cpp/pull/2794)
    
*   Dynamic control vector management endpoints [PR 1223](https://github.com/ikawrakow/ik_llama.cpp/pull/1223)
    
*   Legacy quants conversion schemes in `convert_hf_to_gguf.py` [PR 449](https://github.com/ikawrakow/ik_llama.cpp/pull/449)
    , `Q6_0` in [PR 483](https://github.com/ikawrakow/ik_llama.cpp/pull/483)
    
*   Adaptive-P Sampler [PR 1100](https://github.com/ikawrakow/ik_llama.cpp/pull/1100)
     implemented as designed by it's author; supported on Webui
*   Multi-modal Vision support in `llama-mtmd-cli` [PR 798](https://github.com/ikawrakow/ik_llama.cpp/pull/798)
     and in `llama-server` [PR 901](https://github.com/ikawrakow/ik_llama.cpp/pull/901)
    
*   mikupad as an alternative WebUI [PR 558](https://github.com/ikawrakow/ik_llama.cpp/pull/558)
    
*   June 8 2025: Webui updated (legacy still available when `--path ./examples/server/public_legacy` is passed) [PR 481](https://github.com/ikawrakow/ik_llama.cpp/pull/481)
    
*   June 8 2025: RPC improvements [PR 480](https://github.com/ikawrakow/ik_llama.cpp/pull/480)
    
*   June 7 2025: Add an endpoint that lists all the saved prompt caches to server [PR 502](https://github.com/ikawrakow/ik_llama.cpp/pull/502)
    
*   June 6 2025: Make prompt cache saving and restoring MLA aware [PR 497](https://github.com/ikawrakow/ik_llama.cpp/pull/497)
    
*   June 3 2025: Added samplers, XTC [PR 486](https://github.com/ikawrakow/ik_llama.cpp/pull/486)
    , top-n σ [PR 489](https://github.com/ikawrakow/ik_llama.cpp/pull/489)
    .
*   May 22 2025: Refactor `iqk_mul_mat.cpp` which speeds up compilation time significantly. [PR 435](https://github.com/ikawrakow/ik_llama.cpp/pull/435)
    
*   May 17 2025: Option to enable or disable the CPU FA kernels [PR 429](https://github.com/ikawrakow/ik_llama.cpp/pull/429)
    .
*   May 12 2025: User can now control if/which operations with tensors held in RAM are offloaded to the GPU. See [PR 405](https://github.com/ikawrakow/ik_llama.cpp/pull/405)
    
*   May 12 2025: Compatibility issues with mainline `llama.cpp` GGUFs for DeepSeek models with MLA enabled were resolved in [PR 394](https://github.com/ikawrakow/ik_llama.cpp/pull/394)
    . The lower prompt processing performance resulting from using `llama.cpp`\-style MLA GGUFs was recovered in [PR 409](https://github.com/ikawrakow/ik_llama.cpp/pull/409)
    .
*   April 21 2025: ik\_llama.cpp builds and runs successfully on Android (using termux), see [PR 336](https://github.com/ikawrakow/ik_llama.cpp/pull/336)
    
*   March 1 2025: Smart Expert Reduction for faster DeepSeek inference [PR 239](https://github.com/ikawrakow/ik_llama.cpp/pull/239)
    
*   Feb 25 2025: Tensor overrides for better control where model weights are stored (GPU or CPU) [PR 232](https://github.com/ikawrakow/ik_llama.cpp/pull/232)
    
*   Feb 23 2025: `sweep-bench` - better performance benchmarking [PR 225](https://github.com/ikawrakow/ik_llama.cpp/pull/225)
    


</details>

<details><summary>Tool result · context_read · call_f141d148a50f43478a23bc6b</summary>

# Search: ik_llama.cpp IQ3_S KV cache bf16 precision lossless attention · section 107/112
Subsection: Memory Type Selection
Tags: table

*   [.github/workflows/build-openvino.yml](https://github.com/ggml-org/llama.cpp/blob/31953bcf/.github/workflows/build-openvino.yml)
    
*   [ci/run.sh](https://github.com/ggml-org/llama.cpp/blob/31953bcf/ci/run.sh)
    
*   [conversion/base.py](https://github.com/ggml-org/llama.cpp/blob/31953bcf/conversion/base.py)
    
*   [src/llama-kv-cache.cpp](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.cpp)
    
*   [src/llama-kv-cache.h](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.h)
    
*   [src/llama-model.h](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-model.h)
    
*   [tests/test-kv-cache.cpp](https://github.com/ggml-org/llama.cpp/blob/31953bcf/tests/test-kv-cache.cpp)
    
*   [tests/test\_kv\_cache\_scales.py](https://github.com/ggml-org/llama.cpp/blob/31953bcf/tests/test_kv_cache_scales.py)
    

Purpose and Scope
-----------------

This page explains the memory management system in `llama.cpp`, focusing on key-value (KV) cache mechanisms, recurrent and hybrid memory models, Independent Sliding Window Attention (ISWA), DeepSeek V4 (DSV4) compressed caches, and state save/restore processes. This subsystem maintains all necessary model state across inference steps, such as attention keys/values, recurrent states, compressed caches, and supports complex batching workflows.

The scope includes:

*   Abstract memory interface and main implementations (`llama_kv_cache` [src/llama-kv-cache.h20](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.h#L20-L20)
    , `llama_memory_recurrent`, `llama_memory_hybrid`, and their variants).
*   KV cache internal structure, cell metadata, sequence tracking.
*   Management of recurrent state memory for non-transformer models.
*   Hybrid memory combining both KV and recurrent approaches.
*   Support for unified and compressed caches (ISWA, DSV4).
*   Lifecycle of memory contexts during batch processing.
*   State serialization APIs for checkpointing and session management.

Sources: `[src/llama-memory.h:1-129]`, `[src/llama-kv-cache.h:1-215]`, `[src/llama-kv-cache.cpp:1-120]`, [tests/test-kv-cache.cpp1-105](https://github.com/ggml-org/llama.cpp/blob/31953bcf/tests/test-kv-cache.cpp#L1-L105)

* * *

Memory System Architecture
--------------------------

The memory system uses the abstract interface `llama_memory_i` [src/llama-memory.h104-160](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory.h#L104-L160)
 to encapsulate differing memory implementations suited to model type and architecture.

### Memory Type Selection

During initialization, the memory type is selected based on the model's hyperparameters and configuration parameters:

*   Models supporting recurrent layers get a hybrid memory (`llama_memory_hybrid` / `llama_memory_hybrid_iswa`) combining attention KV cache and recurrent memory.
*   Pure transformer models use the standard KV cache (`llama_kv_cache`) or ISWA variants.
*   Vocabulary-only models return no memory (`nullptr`).

Sources: `[src/llama-memory.h:73-127]`, `[src/llama-kv-cache.h:20-109]`, `[src/llama-memory-hybrid.h:19-62]`

### Memory Type Summary

| Memory Type | Source Files | Supported Architectures | Key Stored Tensors |
| --- | --- | --- | --- |
| `llama_kv_cache` | [src/llama-kv-cache.cpp](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.cpp) | Transformer-style models | `cache_k_l%d` (attention keys), `cache_v_l%d` (values) |
| `llama_memory_recurrent` | [src/llama-memory-recurrent.cpp](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-recurrent.cpp) | Recurrent models (Mamba, RWKV, DeltaNet) | `cache_r_l%d`, `cache_s_l%d` (recurrent states) |
| `llama_memory_hybrid` | [src/llama-memory-hybrid.cpp](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-hybrid.cpp) | Hybrid models (Jamba, Griffin, Qwen3.5) | Combines KV cache and recurrent memory |

Sources: `[src/llama-memory.h:73-127]`, `[src/llama-kv-cache.h:20-109]`, `[src/llama-memory-hybrid.h:19-62]`, `[src/llama-memory-recurrent.cpp:20-139]`

* * *

KV Cache Implementation
-----------------------

The `llama_kv_cache` class [src/llama-kv-cache.h20-200](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.h#L20-L200)
 implements the key-value cache used in transformer attention, managing multi-layer and multi-stream KV tensors with flexible features including offloading, unified caching, and variable-size embeddings.

### Structure and Components

*   **Layers:** A vector of cache layer entries, each storing key (`k`) and value (`v`) `ggml_tensor *` pointers for a particular transformer layer.
*   **Metadata Cells:** Shared pointer `v_cells_impl` referencing a vector of `llama_kv_cells` [src/llama-kv-cells.h36-80](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cells.h#L36-L80)
    , holding positional and sequence associations per KV cache cell.
*   **Head Pointers:** Vector `v_heads` for tracking the next write position per stream in the V cache [src/llama-kv-cache.cpp136-144](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.cpp#L136-L144)
    .
*   **Sequence-to-Stream Mapping:** `seq_to_stream` vector maps sequence IDs to their respective stream indices [src/llama-kv-cache.cpp147-154](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.cpp#L147-L154)
    .

Sources: `[src/llama-kv-cache.h:20-215]`, `[src/llama-kv-cache.cpp:65-207]`, `[src/llama-kv-cells.h:13-80]`, [tests/test-kv-cache.cpp70-101](https://github.com/ggml-org/llama.cpp/blob/31953bcf/tests/test-kv-cache.cpp#L70-L101)

### V Cache Transposition and Variable Embeddings

*   The `v_trans` boolean flag controls whether the values cache is stored transposed for backend optimization [src/llama-kv-cache.cpp83-87](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.cpp#L83-L87)
    .
*   For models with variable per-layer V embedding sizes (e.g., GQA heads), the V cache is padded to the maximum layer size [src/llama-kv-cache.cpp157-161](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.cpp#L157-L161)
    .
*   The KV cache adapts to Multi-Head Latent Attention (MLA) models via `hparams.is_mla()` [src/llama-kv-cache.cpp162-207](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.cpp#L162-L207)
    .
*   FP8 cache quantization supports types such as `GGML_TYPE_F8_E4M3` with scaling factors retrieved via `get_k_scale()` and `get_v_scale()` [tests/test-kv-cache.cpp81-100](https://github.com/ggml-org/llama.cpp/blob/31953bcf/tests/test-kv-cache.cpp#L81-L100)
    .

Sources: `[src/llama-kv-cache.cpp:83-207]`, `[src/llama-kv-cache.h:100-118]`, [tests/test-kv-cache.cpp1-105](https://github.com/ggml-org/llama.cpp/blob/31953bcf/tests/test-kv-cache.cpp#L1-L105)

* * *

Recurrent Memory Implementation
-------------------------------

`llama_memory_recurrent` [src/llama-memory-recurrent.h17-143](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-recurrent.h#L17-L143)
 manages recurrent states for models using non-transformer architectures, such as Mamba, RWKV, and DeltaNet families.

### Key Features

*   Stores recurrent states per layer [src/llama-memory-recurrent.cpp74-116](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-recurrent.cpp#L74-L116)
    :
    *   `r_l[]`: Convolution states or primary recurrent state tensor (`ggml_tensor *`).
    *   `s_l[]`: Secondary state tensors (e.g., SSM hidden states).
    *   `p_l[]`: PLE convolution state rows where applicable [src/llama-memory-recurrent.cpp110-115](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-recurrent.cpp#L110-L115)
        .
*   Tracks memory cells metadata (`cells`) [src/llama-memory-recurrent.cpp39-41](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-recurrent.cpp#L39-L41)
     including position info and sequence membership.
*   Supports rollback snapshots (`n_rs_seq`) for efficient partial state rollback [src/llama-memory-recurrent.cpp35-37](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-recurrent.cpp#L35-L37)
    .

Sources: `[src/llama-memory-recurrent.h:17-143]`, `[src/llama-memory-recurrent.cpp:20-143]`

* * *

Hybrid Memory System
--------------------

The `llama_memory_hybrid` class [src/llama-memory-hybrid.h19-91](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-hybrid.h#L19-L91)
 and `llama_memory_hybrid_iswa` combine attention KV cache and recurrent memory modules to support hybrid architectures.

### Components and Batch Preparation

*   Contains `mem_attn` (`llama_kv_cache` or `llama_kv_cache_iswa`) and `mem_recr` (`llama_memory_recurrent`) [src/llama-memory-hybrid.cpp33-66](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-hybrid.cpp#L33-L66)
    .
*   Implements `init_batch()` by partitioning input token batches into `llama_ubatch` units, maintaining rollback constraints [src/llama-memory-hybrid.cpp68-124](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-hybrid.cpp#L68-L124)
    .
*   Sequence operations (`seq_rm`, `seq_cp`, `seq_keep`, `seq_add`, `seq_div`) are forwarded to both underlying memory instances [src/llama-memory-hybrid.cpp144-171](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory-hybrid.cpp#L144-L171)
    .

Sources: `[src/llama-memory-hybrid.h:19-91]`, `[src/llama-memory-hybrid.cpp:11-192]`

* * *

ISWA and DSV4 Compressed Caches
-------------------------------

### Independent Sliding Window Attention (ISWA)

*   `llama_kv_cache_iswa` maintains two caches:
    *   `kv_base`: a persistent base cache [src/llama-kv-cache-iswa.cpp95-99](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache-iswa.cpp#L95-L99)
        .
    *   `kv_swa`: a sliding window cache with window size `n_swa` tokens [src/llama-kv-cache-iswa.cpp102-106](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache-iswa.cpp#L102-L106)
        .
*   Enables local attention over long contexts without unbounded cache growth.

### DeepSeek V4 (DSV4) Compressed Caches

*   `llama_kv_cache_dsv4` [src/llama-kv-cache-dsv4.h90-182](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache-dsv4.h#L90-L182)
     applies compression to KV states using compressed state containers (`llama_dsv4_comp_state` [src/llama-kv-cache-dsv4.h11-78](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache-dsv4.h#L11-L78)
    ).
*   Combines a raw/SWA token cache with compressed K-only block caches (`kv_raw`, `kv_csa`, `kv_hca`, `kv_lid`) [src/llama-kv-cache-dsv4.h177-182](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache-dsv4.h#L177-L182)
    .

Sources: `[src/llama-kv-cache-iswa.cpp:1-106]`, `[src/llama-kv-cache-dsv4.h:11-182]`, `[src/llama-kv-cache-dsv4.cpp:1-50]`

* * *

State Save and Restore
----------------------

Persistent state serialization enables session checkpointing and resuming inference across executions.

### Serialization APIs

*   `state_write()` and `state_read()` are implemented across memory modules (`llama_kv_cache`, `llama_memory_recurrent`, `llama_memory_hybrid`) to serialize streams using `llama_io_write_i` and `llama_io_read_i` [src/llama-kv-cache.h151-152](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-kv-cache.h#L151-L152)
    , [src/llama-memory.h157-158](https://github.com/ggml-org/llama.cpp/blob/31953bcf/src/llama-memory.h#L157-L158)
    .
*   Supports partial and full saves with sequence filtering (`seq_id`, `flags`).

Sources: `[src/llama-kv-cache.h:149-153]`, `[src/llama-memory.h:153-159]`, `[src/llama-memory-recurrent.h:65-69]`

* * *

Memory Operations and Sequence Management
-----------------------------------------



</details>

<details><summary>Tool result · web_scrape · call_b94ac13007ea465cb7b7353b</summary>

**Firecrawl · section 1 of 3**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,275 characters · included below
- Section 2 · 11,931 characters · omitted from this copy
- Section 3 · 1,630 characters · omitted from this copy

```text
[Skip to main content](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/#main-content)

* * *

Copy as Markdown

[View Raw (.txt)](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/raw.txt)

Outline

Qwen3.8-Flash-Next (the preview of the Qwen4 architecture) is a 125B MoE with about 6B active parameters per token, paired with a **51B n-gram lookup table**. That table isn't standard transformer weights - it's hashed 3-token lookups into a giant embedding, so it doesn't need to sit in RAM at all. Because of that one property, an 88 GB model runs comfortably on my desktop with a 12 GB RTX 4070 and 64 GB of DDR5, climbing from 20.5 tok/s on stock llama.cpp up to **74.8 tok/s on Strata**.

Here's which quant to grab, how I build and run it in `llama.cpp`, where the memory actually goes, and which tuning levers mattered on my box. (For how to run it in Strata and how its dynamic expert cache works, see [Strata on an RTX 4070](https://carteakey.dev/blog/local-inference/strata-on-an-rtx-4070/)
.)

Performance Evolution · RTX 4070 12GB + 64GB DDR5

### Qwen3.8-Flash-Next Decode Throughput Progression

6.5 → 73.5 tok/s (70.4 UD-IQ2\_XS)

![Line chart of Qwen3.8-Flash-Next decode throughput on an RTX 4070 12GB across tuning steps up to strata-lean 69.6, --kv-grow 73.5, and UD-IQ2_XS + ADAPT_FETCH at 70.4 tok/s.](https://carteakey.dev/img/UbNslv4Ppy-1640.jpeg)

**Progression:** Powersave (6.5) → CPU governor (12.2) → lazy mmap offload (15.2) → q8\_0 KV and dynamic layer fitting (18.9) → upstream master refresh (19.35) → compact MTP (20.65) → QSA Sparsity Stack V2 MTP (27.06) → Strata dynamic cache (60.3) → DDR5-5800 tuning (65.8) → strata-lean fork with Ada sm\_89 MMVQ (69.6) → --kv-grow cache expansion (**73.5 t/s**) → Unsloth Dynamic UD-IQ2\_XS + ADAPT\_FETCH (**70.4 t/s**, +11.5 DeepSWE).

TL;DR [#](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/#tl-dr)

------------------------------------------------------------------------------------------------

I use [ISTA-DASLab's GSQ-RCO IQ3\_XXS](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)
 for Strata, and [AtomicChat's AD-4.27bpw](https://huggingface.co/AtomicChat/Qwen3.8-Flash-Next-GGUF)
 for llama.cpp. Both builds isolate the 51B n-gram table into Shard 2 so it can stay on NVMe.

On my RTX 4070 (12 GB) + 64 GB DDR5 box:

*   **Strata** (dynamic expert cache + native MTP) hits **74.8 tok/s steady decode** with the Q8\_0 PLE table (65.8 tok/s with the default IQ4\_NL PLE), and over 2,000 tok/s prefill.
*   **llama.cpp + MTP draft stack** reaches **27.1 tok/s** at 16k context using the compact Q4\_K\_M draft head and [NVMe row prefetching](https://github.com/ggml-org/llama.cpp/pull/29599)
    .
*   **llama.cpp plain master** runs at **20.5 - 22.1 tok/s** decode and up to 385 tok/s prefill, scaling cleanly to **96k context** (and 18.4 tok/s with the F16 vision projector).

One rule flips my usual advice on its head: **leave `mmap` on**. Lazy paging is the offload mechanism here. Passing `--no-mmap --mlock` on a 64 GB machine will crash immediately. Cold boots start slow on the very first prompt while hot expert pages fault into RAM, then settle into full speed.

Why this quant? [#](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/#why-this-quant)

-------------------------------------------------------------------------------------------------------------------

Out of the model's 176B parameters, the 51B n-gram table only reads a few kilobytes per token out of a huge address space. An NVMe SSD answers those tiny random reads in microseconds. The routed MoE experts are the opposite: each token touches hundreds of megabytes of expert weights, which is hopeless from disk.

So the model naturally splits across three storage tiers:

1.  **VRAM** holds attention, shared weights, the KV cache, and as many hot experts or layers as fit.
2.  **System RAM** holds the remaining routed MoE experts.
3.  **NVMe SSD** holds the entire 51B n-gram table (`per_layer_token_embd.weight`).

For that split to work without eating your RAM, the n-gram table has to live in its own GGUF shard. Both ISTA-DASLab and AtomicChat put the table alone in Shard 2, so the Linux kernel can memory-map it straight from NVMe without pulling it into memory. Unsloth's quants interleave the table across weight shards, which forces the whole file into RAM unless you repack it yourself.

Quant ladder (what fits where) [#](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/#quant-ladder-what-fits-where)

------------------------------------------------------------------------------------------------------------------------------------------------

Here's how the published quants fit on a 12 GB VRAM + 64 GB RAM box, sorted by the fast-memory backbone (what actually has to sit in RAM and VRAM after leaving the n-gram shard on SSD):

| Publisher | Quant | File (GiB) | Backbone (GiB) | Fits 12GB VRAM + 64GB RAM? |
| --- | --- | --- | --- | --- |
| **ISTA-DASLab** | **GSQ-RCO-Coder IQ1\_M** | **54.4** | **27.6** | **yes, easily (fits 262k context)** |
| unsloth | UD-IQ1\_S | 67.6 | 50.7 | yes, snug |
| unsloth | UD-IQ1\_M | 69.4 | 52.0 | yes, snug |
| **ISTA-DASLab** | **GSQ-RCO IQ3\_XXS** | **70.6** | **43.8** | **yes - active Strata default (~43 GB RAM + 5 GB VRAM)** |
| unsloth | UD-Q2\_K\_XL | 73.5 | 55.1 | yes |
| unsloth | UD-IQ3\_XXS | 76.3 | 57.2 | yes |
| **ISTA-DASLab** | **GSQ-RCO IQ3\_S** | **77.9** | **51.0** | **yes, comfortably (near BF16 parity)** |
| unsloth | UD-Q3\_K\_XL | 83.8 | 62.9 | tight (paging risk) |
| AtomicChat | AD-3.84bpw-IQ4\_XS-M64 | 84.9 | 45.8 | **yes, comfortably** |
| unsloth | UD-IQ4\_XS | 87.2 | 65.4 | tight (paging risk) |
| **AtomicChat** | **AD-4.27bpw-Q4\_K\_M-M64** | **88.0** | **54.5** | **yes - llama.cpp baseline** |
| unsloth | UD-Q4\_K\_XL | 103.7 | 77.8 | no  |
| AtomicChat | AD-5.00bpw-Q5\_K\_M-M64 | 110.5 | 56.1 | borderline |
| ggml-org (official) | Q8\_0 (BF16→) | ~180+ | n/a | reference only |

If you're choosing between them, ISTA-DASLab's IQ3\_XXS is the sweet spot for 64 GB of RAM. It assigns bit precision per layer based on gradient sensitivity, matching AtomicChat's 4.27-bit quality while shaving over 10 GB off the RAM footprint. Even better, Shard 2 (the 26.8 GiB n-gram table) is byte-for-byte identical across ISTA-DASLab's IQ3\_XXS, IQ3\_S, and Coder IQ1\_M builds, so you can hardlink Shard 2 across variants and save 27 GB of disk space per extra model.

### Where the memory actually goes (AtomicChat 88 GiB config) [#](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/#where-the-memory-actually-goes-atomicchat-88-gib-config)

| Tier | Contents | GiB |
| --- | --- | --- |
| File | whole AD-4.27bpw quant | 88.0 |
| VRAM | dense/attention ~4.4 + last 2 expert layers ~2.0 + q8 KV (64k) ~0.6 + compute ~1.6 | 10.0 |
| RAM (RSS) | 46 host expert layers ~44.6 + token-embd/output ~1.2 (file-backed, evictable) | 45.6 |
| SSD | 88.0 − 10.0 − 45.6 | **32.4** |

Only the n-gram embedding table stays on SSD on purpose. The 46 host expert layers sit in file-backed RAM pages that the Linux kernel will only evict if desktop apps eat your remaining memory. If generation speed suddenly halves mid-session, check `free -g` first.

Build & Download [#](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/#build-and-download)

------------------------------------------------------------------------------------------------------------------------

All architecture support, lazy tensor reads, and fused MoE reductions are in upstream llama.cpp master. A standard CUDA build works out of the box:

    git clone https://github.com/ggml-org/llama.cpp
    cd llama.cpp
    cmake -B build \
      -DCMAKE_BUILD_TYPE=Release \
      -DGGML_CUDA=ON \
      -DLLAMA_CURL=ON \
      -DBUILD_SHARED_LIBS=OFF \
      -DGGML_NATIVE=ON \
      -DGGML_CUDA_GRAPHS=ON \
      -DGGML_CUDA_FA_ALL_QUANTS=ON \
      -DCMAKE_CUDA_ARCHITECTURES=89
    cmake --build build --config Release --target llama-server llama-bench --parallel

After downloading, you can verify that Shard 2 holds only the isolated n-gram table with a quick check:

    python3 - <<'EOF'
    from gguf import GGUFReader
    r = GGUFReader("Qwen3.8-Flash-Next-AD-4.27bpw-Q4_K_M-M64-00002-of-00033.gguf")
    print([t.name for t in r.tensors])  # -> ['per_layer_token_embd.weight']
    EOF

> **Easier path**: In [l3ms](https://github.com/carteakey/l3ms)
> , `cargo build --release` wires the CUDA build automatically, and the downloader handles segmented range requests when Hugging Face throttles single streams.

Run (`llama.cpp`) [#](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/#run-llama-cpp)

--------------------------------------------------------------------------------------------------------------------

    llama-server \
      -m ~/models/qwen38-flash-next/AD-4.27bpw-Q4_K_M-M64/Qwen3.8-Flash-Next-AD-4.27bpw-Q4_K_M-M64-00001-of-00033.gguf \
      --host 127.0.0.1 --port 8014 \
      --fit on --fit-target 512 \
      -c 65536 -b 4096 -ub 2048 \
      -fa on --jinja \
      -ctk q8_0 -ctv q8_0 \
      -t 10 --threads-batch 12 --prio 2 \
      --lazy-mode on \
      --spec-type ngram-mod \
      --spec-ngram-mod-n-match 60 --spec-ngram-mod-n-min 12 --spec-ngram-mod-n-max 24 \
      --temp 1.0 --top-p 0.95 --top-k 20 --min-p 0.0 --no-warmup

Four flags do the heavy lifting on a 12 GB card:

*   `--fit on --fit-target 512` places dense/attention weights plus as many MoE layers as fit into VRAM while keeping a half-gigabyte safety buffer.
*   `-b 4096 -ub 2048` is the prefill lever: a 2,048 micro-batch lets the CPU stream the host expert weights once per 2k prompt instead of twice, jumping prefill past 350 tok/s with no hit to decode.
*   `--lazy-mode on` leaves the n-gram table memory-mapped on NVMe so only the rows touched by a token fault into RAM.
*   `-ctk q8_0 -ctv q8_0` halves KV cache memory so a 64k window fits cleanly on the GPU. Don't pass `--no-kv-offload` here - moving KV to host RAM tanks PCIe throughput.

Benchmarks & Tuning Levers [#](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/#benchmarks-and-tuning-levers)

--------------------------------------------------------------------------------------------------------------------------------------------

### 1\. Upstream `llama.cpp` vs MTP Speculative Decoding [#](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/#1-upstream-llama-cpp-vs-mtp-speculative-decoding)

On my 6-task unique prompt suite at 16k context, plain upstream llama.cpp master already beats `ik_llama`, so I dropped `ik_llama` from my setup.

Adding speculative decoding via [Daniel Han's MTP draft-head PR](https://github.com/ggml-org/llama.cpp/pull/28243)
 and the QSA sparsity stack ([pooled-key indexer cache](https://github.com/ggml-org/llama.cpp/pull/28699)
, [gather sparse decode](https://github.com/ggml-org/llama.cpp/pull/28213)
, and [Aman Gupta's NVMe `madvise` row prefetch](https://github.com/ggml-org/llama.cpp/pull/29599)
) pushed llama.cpp to **27.1 tok/s**:

```

</details>

## Assistant · #11

<details><summary>Reasoning · 3,140 characters</summary>

I need the section 19.2 "Target and draft KV cache precision" from the carteakey master guide (resource 654be1f5). Also section 98 "Quantization additions". Let me search the resource for "bf16".

Let me use resource_search on 654be1f5 for "bf16" and "BF16".

Also search for HF discussions: unsloth Qwen3.8-Flash-Next-GGUF mentions "BF16" for KV cache? Also there's a well-known ik_llama.cpp discussion about KV cache types, and the "Qwen3-Next" GDN recurrent state precision (f32 vs f16 vs bf16) — for hybrid models, the recurrent state is stored in f32 by default, and there was a PR to allow f16/bf16 for recurrent states.

Actually key insight: Qwen3.8-Flash-Next / Qwen3-Next is a hybrid model with Gated DeltaNet. The "KV cache" only applies to the 12 full-attention layers (QSA / gated attention), with 2 KV heads. The DeltaNet recurrent state is separate. BF16 vs F16 for the KV cache: BF16 has 8 mantissa bits vs F16's 10, but much wider exponent range. For KV cache, values are typically small range, so F16 has better precision. But GGUF/llama.cpp: bf16 is exactly the same size as f16 (2 bytes), so no memory benefit. That's the crucial published finding — sotaaz measured bf16 = same memory as f16 and ~52% of decode speed on CUDA (no FA decode kernel compiled → converts to f16 on the fly, slow).

So the answer: for this model, bf16 KV cache buys nothing over f16 — it's the same 2 bytes per element, and on llama.cpp CUDA builds it's slower because there's no FA decode kernel for bf16 by default (GGML_CUDA_FA_QUANTS). Published sources: sotaaz measurement, llama.cpp docs/README, and the GGUF README (unsloth) which recommends Q8_0 KV.

But the user asks specifically: "Where do comparisons for FP16 versus BF16 kv cache only, compare in Qwen 3.8 Flash Next (MoE)". They want to know where published comparisons exist. Let me search more targeted:
1. unsloth Qwen3.8-Flash-Next docs quantization analysis — mentions KV cache type.
2. llama.cpp README table of cache types + bf16 note.
3. ik_llama.cpp discussion #2051 or similar on KV cache quantization with Hadamard transform.
4. Any paper: "KV cache bf16 vs fp16" — there's a known result in "A Survey on LLM Compression with Emphasis on Quantization: KV Cache" etc. Also "KV cache is NP-complete"? Also "KVCache 100K" etc. Also "TurboQuant" (Google research, 2.5-bit KV cache) uses "PolarQuant" and mentions bf16/fp16 baselines. Also "KIVI" paper uses fp16/fp32 baselines.

Also there's an important nuance: for the QSA (Qwen Sparse Attention) indexer, and for hybrid models, the recurrent state quantization `-ctk` doesn't apply. There might be a flag `--recurrent-cache` or similar. Actually carteakey guide section 11 mentions "quantize the KV cache (symmetric q8_0 or asymmetric K8V4)".

Let me search the resources for "bf16" mentions and also do additional web searches:
- "bf16 kv cache" llama.cpp README "same size as f16"
- unsloth docs qwen3.8-next "KV cache" bf16
- huggingface discussion Qwen3.8-Flash-Next GGUF "ctk bf16"
- paper: "FP8 KV cache" / "Survey KV cache quantization fp16 bf16 mantissa"

Let me run resource_search + web searches in parallel.


</details>

<details><summary>Tool request · resource_search · call_4daaa7284eaa4d6a8ad2dea5</summary>

```json
{
  "resource_id": "654be1f5-6a9e-44d0-8ee5-6bbe44f63f9b",
  "query": "bf16 kv cache"
}
```

</details>

<details><summary>Tool request · resource_search · call_49ff5176783e4eb99e3b4a13</summary>

```json
{
  "resource_id": "654be1f5-6a9e-44d0-8ee5-6bbe44f63f9b",
  "query": "draft KV cache precision target MTP spec"
}
```

</details>

<details><summary>Tool request · web_search · call_1770357c7ffa449ebf988f9a</summary>

```json
{
  "query": "llama.cpp README cache-type bf16 \"same size\" f16 no benefit KV cache",
  "limit": 8
}
```

</details>

<details><summary>Tool request · web_search · call_e1878595ebec4361b709050b</summary>

```json
{
  "query": "huggingface Qwen3.8-Flash-Next GGUF discussion KV cache bf16 f16 perplexity",
  "limit": 8
}
```

</details>

Let me search the indexed guides for BF16-specific data and run targeted searches.
<details><summary>Tool result · resource_search · call_4daaa7284eaa4d6a8ad2dea5</summary>

# Search: Search: ik_llama.cpp IQ3_S KV cache bf16 precision lossless attention

Query: "bf16 kv cache"

- [Section 101 — Function Calls Tests](#resource-654be1f5-6a9e-44d0-8ee5-6bbe44f63f9b-section-101) · code
  …ithub.com/ikawrakow/ik_llama.cpp/pull/1526) * March 26 2026: Fix CPU flash attention with bf16 KV cache [PR 1521](https://github.com/ikawrakow/ik_llama.cpp/pull/1521) * December 5 2025: CUDA: fix FA on Pascal GPUs [PR 1036](https://github.com/ikawrakow/ik_llam…

</details>

<details><summary>Tool result · resource_search · call_49ff5176783e4eb99e3b4a13</summary>

No sections in Search: ik_llama.cpp IQ3_S KV cache bf16 precision lossless attention contain "draft KV cache precision target MTP spec".

</details>

<details><summary>Tool result · web_search · call_1770357c7ffa449ebf988f9a</summary>

**Firecrawl · section 1 of 146**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,778 characters · included below
- Section 2 · 11,783 characters · omitted from this copy
- Section 3 · 9,603 characters · omitted from this copy
- Section 4 · 11,850 characters · omitted from this copy
- Section 5 · 12,000 characters · omitted from this copy
- Section 6 · 12,001 characters · omitted from this copy
- Section 7 · 8,698 characters · omitted from this copy
- Section 8 · 7,678 characters · omitted from this copy
- Section 9 · 7,399 characters · omitted from this copy
- Section 10 · 8,744 characters · omitted from this copy
- Section 11 · 8,440 characters · omitted from this copy
- Section 12 · 11,943 characters · omitted from this copy
- Section 13 · 11,123 characters · omitted from this copy
- Section 14 · 11,947 characters · omitted from this copy
- Section 15 · 11,810 characters · omitted from this copy
- Section 16 · 11,956 characters · omitted from this copy
- Section 17 · 11,999 characters · omitted from this copy
- Section 18 · 12,001 characters · omitted from this copy
- Section 19 · 11,932 characters · omitted from this copy
- Section 20 · 11,979 characters · omitted from this copy
- Section 21 · 11,958 characters · omitted from this copy
- Section 22 · 11,964 characters · omitted from this copy
- Section 23 · 11,987 characters · omitted from this copy
- Section 24 · 11,901 characters · omitted from this copy
- Section 25 · 11,998 characters · omitted from this copy
- Section 26 · 11,978 characters · omitted from this copy
- Section 27 · 11,957 characters · omitted from this copy
- Section 28 · 11,976 characters · omitted from this copy
- Section 29 · 12,001 characters · omitted from this copy
- Section 30 · 11,970 characters · omitted from this copy
- Section 31 · 11,966 characters · omitted from this copy
- Section 32 · 11,976 characters · omitted from this copy
- Section 33 · 11,994 characters · omitted from this copy
- Section 34 · 11,548 characters · omitted from this copy
- Section 35 · 11,047 characters · omitted from this copy
- Section 36 · 11,993 characters · omitted from this copy
- Section 37 · 11,997 characters · omitted from this copy
- Section 38 · 11,712 characters · omitted from this copy
- Section 39 · 11,622 characters · omitted from this copy
- Section 40 · 11,711 characters · omitted from this copy
- Section 41 · 11,173 characters · omitted from this copy
- Section 42 · 11,766 characters · omitted from this copy
- Section 43 · 11,438 characters · omitted from this copy
- Section 44 · 11,998 characters · omitted from this copy
- Section 45 · 11,977 characters · omitted from this copy
- Section 46 · 11,395 characters · omitted from this copy
- Section 47 · 11,588 characters · omitted from this copy
- Section 48 · 9,143 characters · omitted from this copy
- Section 49 · 11,908 characters · omitted from this copy
- Section 50 · 11,915 characters · omitted from this copy
- Section 51 · 11,646 characters · omitted from this copy
- Section 52 · 11,804 characters · omitted from this copy
- Section 53 · 11,973 characters · omitted from this copy
- Section 54 · 11,800 characters · omitted from this copy
- Section 55 · 10,974 characters · omitted from this copy
- Section 56 · 11,670 characters · omitted from this copy
- Section 57 · 8,538 characters · omitted from this copy
- Section 58 · 11,758 characters · omitted from this copy
- Section 59 · 11,999 characters · omitted from this copy
- Section 60 · 11,871 characters · omitted from this copy
- Section 61 · 11,955 characters · omitted from this copy
- Section 62 · 11,993 characters · omitted from this copy
- Section 63 · 11,762 characters · omitted from this copy
- Section 64 · 11,959 characters · omitted from this copy
- Section 65 · 11,979 characters · omitted from this copy
- Section 66 · 11,760 characters · omitted from this copy
- Section 67 · 11,976 characters · omitted from this copy
- Section 68 · 11,974 characters · omitted from this copy
- Section 69 · 11,907 characters · omitted from this copy
- Section 70 · 11,934 characters · omitted from this copy
- Section 71 · 11,872 characters · omitted from this copy
- Section 72 · 11,956 characters · omitted from this copy
- Section 73 · 11,999 characters · omitted from this copy
- Section 74 · 11,972 characters · omitted from this copy
- Section 75 · 11,946 characters · omitted from this copy
- Section 76 · 11,989 characters · omitted from this copy
- Section 77 · 11,955 characters · omitted from this copy
- Section 78 · 11,987 characters · omitted from this copy
- Section 79 · 11,776 characters · omitted from this copy
- Section 80 · 11,977 characters · omitted from this copy
- Section 81 · 11,745 characters · omitted from this copy
- Section 82 · 11,945 characters · omitted from this copy
- Section 83 · 11,877 characters · omitted from this copy
- Section 84 · 11,917 characters · omitted from this copy
- Section 85 · 11,991 characters · omitted from this copy
- Section 86 · 11,947 characters · omitted from this copy
- Section 87 · 11,902 characters · omitted from this copy
- Section 88 · 11,938 characters · omitted from this copy
- Section 89 · 11,726 characters · omitted from this copy
- Section 90 · 11,961 characters · omitted from this copy
- Section 91 · 11,860 characters · omitted from this copy
- Section 92 · 11,816 characters · omitted from this copy
- Section 93 · 11,752 characters · omitted from this copy
- Section 94 · 11,853 characters · omitted from this copy
- Section 95 · 11,971 characters · omitted from this copy
- Section 96 · 11,783 characters · omitted from this copy
- Section 97 · 11,955 characters · omitted from this copy
- Section 98 · 11,953 characters · omitted from this copy
- Section 99 · 11,900 characters · omitted from this copy
- Section 100 · 11,932 characters · omitted from this copy
- Section 101 · 11,751 characters · omitted from this copy
- Section 102 · 11,981 characters · omitted from this copy
- Section 103 · 11,991 characters · omitted from this copy
- Section 104 · 12,001 characters · omitted from this copy
- Section 105 · 11,972 characters · omitted from this copy
- Section 106 · 11,836 characters · omitted from this copy
- Section 107 · 11,877 characters · omitted from this copy
- Section 108 · 11,961 characters · omitted from this copy
- Section 109 · 11,698 characters · omitted from this copy
- Section 110 · 11,949 characters · omitted from this copy
- Section 111 · 11,868 characters · omitted from this copy
- Section 112 · 10,318 characters · omitted from this copy
- Section 113 · 11,949 characters · omitted from this copy
- Section 114 · 11,969 characters · omitted from this copy
- Section 115 · 11,984 characters · omitted from this copy
- Section 116 · 11,805 characters · omitted from this copy
- Section 117 · 11,949 characters · omitted from this copy
- Section 118 · 11,931 characters · omitted from this copy
- Section 119 · 11,251 characters · omitted from this copy
- Section 120 · 7,161 characters · omitted from this copy
- Section 121 · 11,648 characters · omitted from this copy
- Section 122 · 8,869 characters · omitted from this copy
- Section 123 · 11,815 characters · omitted from this copy
- Section 124 · 11,744 characters · omitted from this copy
- Section 125 · 11,917 characters · omitted from this copy
- Section 126 · 11,978 characters · omitted from this copy
- Section 127 · 11,490 characters · omitted from this copy
- Section 128 · 11,920 characters · omitted from this copy
- Section 129 · 11,930 characters · omitted from this copy
- Section 130 · 11,969 characters · omitted from this copy
- Section 131 · 11,960 characters · omitted from this copy
- Section 132 · 11,890 characters · omitted from this copy
- Section 133 · 11,954 characters · omitted from this copy
- Section 134 · 11,927 characters · omitted from this copy
- Section 135 · 11,983 characters · omitted from this copy
- Section 136 · 11,910 characters · omitted from this copy
- Section 137 · 11,752 characters · omitted from this copy
- Section 138 · 11,969 characters · omitted from this copy
- Section 139 · 11,701 characters · omitted from this copy
- Section 140 · 11,850 characters · omitted from this copy
- Section 141 · 11,940 characters · omitted from this copy
- Section 142 · 7,981 characters · omitted from this copy
- Section 143 · 11,988 characters · omitted from this copy
- Section 144 · 11,986 characters · omitted from this copy
- Section 145 · 11,097 characters · omitted from this copy
- Section 146 · 3,838 characters · omitted from this copy

```text
## 1. Quantization/features quality vs speed documentation · Issue #1529

https://github.com/ikawrakow/ik_llama.cpp/issues/1529

If you set an AMB and your compute buffer is the same size, assume it didn't work. ... I didn't think you could even BF16 the KV, only F16. ikawrakow ...

[Skip to content](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#start-of-content)
           

You signed in with another tab or window. [Reload](https://github.com/ikawrakow/ik_llama.cpp/issues/1529)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/ikawrakow/ik_llama.cpp/issues/1529)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/ikawrakow/ik_llama.cpp/issues/1529)
 to refresh your session. Dismiss alert

                                                                                                                               [](https://github.com/ikawrakow/ik_llama.cpp)

Feature Request: Quantization/features quality vs speed documentation #1529
===========================================================================

[New issue](https://github.com/login?return_to=https://github.com/ikawrakow/ik_llama.cpp/issues/1529)

Copy link

[New issue](https://github.com/login?return_to=https://github.com/ikawrakow/ik_llama.cpp/issues/1529)

Copy link

Closed

Closed

[Feature Request: Quantization/features quality vs speed documentation](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#top)
#1529

Copy link

Labels

[enhancementNew feature or request](https://github.com/ikawrakow/ik_llama.cpp/issues?q=state%3Aopen%20label%3A%22enhancement%22)
New feature or request

Description
-----------

[![@ghost](https://github.com/ghost.png?size=48)](https://github.com/ghost)

[ghost](https://github.com/ghost)

opened [on Mar 27, 2026](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#issue-4152813611)

### Prerequisites

*   [x]  I am running the latest code. Mention the version if possible as well.
*   [x]  I carefully followed the [README.md](https://github.com/ggerganov/llama.cpp/blob/master/README.md)
    .
*   [x]  I searched using keywords relevant to my issue to make sure that I am creating a new issue that is not already open (or closed).
*   [x]  I reviewed the [Discussions](https://github.com/ggerganov/llama.cpp/discussions)
    , and have a new and useful enhancement to share.

### Feature Description

A readme with

*   a list of all of the features (especially the ones turned on by default) that impact inference quality for attention critical use cases
*   kv cache/weights quantization clarification and existing kernel capabilities for cuda/Vulkan/others. (To know when things get casted to other types)

For example:

*   regarding q8 vs native BF16 attention weights quality, I'm getting confusing information which doesn't quite match results. Q8 seems noticeably worse then BF16 in my use cases (using fa-offset 0, fp16 kv, long context, 4096 batches)
*   for kv cache, for cuda at least, there doesn't seem to be a reason to use BF16 over F16, am I wrong?

The focus should be on defining front ender level tuning knobs for quality vs speed. I know a few, I don't know which ones I'm missing. These should be well documented. More in possible implementation.

### Motivation

The average use case for modern models is shifting radically towards higher complexity/higher context tasks, making attention precision far more important, for a variety of reasons.  
1 - MoE now enables even gaming PCs to run massive models, enabling more complex, attention critical use cases  
2 - Hardware has gotten faster, and Delta net and hybrid approaches have made kv cache memory requirements much smaller, enabling local high context use cases  
3 - High context reduces reliance on the model original training - which was never reliable in the first place. Now we can just RAG/throw in context all the documentation for whatever use case we have, making attention precision far more important  
4 - Agentic use cases are more common, and require high precision

A few examples of my use cases:

*   Morning news bot: the bot goes trough a list of topics (economy news, a list of stocks news, war news, Linux news, EU news, RSS feeds) and iteratively searches news while I'm having coffee + breakfast. This is 20-30 tool calls in sequence. The news are compared to the last days news in order not to repeat the same news twice. Context often surpasses 100k depending on visited websites. Speed is irrelevant (takes 5-10 minutes anyway), but getting a URL wrong, interrupting generation, or crashing due to a wrong tool call is problematic. I might miss important financial news or have to restart the process.
*   Tax questions: I have a few pdf files that list all tax deductions available in my country. These are 100-200k tokens files, and while I don't overly care whether pp will take 3 minutes or 4, the info I get needs to be accurate for obvious reasons. High context, memory critical.
*   Coding: llms are actually useful finally. But you won't go anywhere without loading the documentation/libraries in context first, especially if you want to use some obscure and continuously worked on rust crate. Again, high context, attention critical use case. Speed is important too, but that has to be balanced with the amount of additional swiping/wrong answers I get. You might save a minute on tg only to lose an hour for missing an important detail or pasting a function name wrong.
*   Legal and medical advice: while too critical to entirely depend on, with good web search or a good amount of documents loaded in it can still have it's uses, especially for minor problems (reflux issues, minor neighbor problems). Again, high context, agentic, attention critical.
*   Bash access: I never tried it personally, I recall Google Bard advising Linux users to remove the French language from their system, so I've always been on edge about it. But with the right safeguards it's something I'll eventually do. Git commands, basic cd, ls, mv, rm, wget. This is all still somewhat critical stuff, even getting a file name wrong once every 100 commands is unacceptable.

**Conclusion**: We are moving from RP bots + one or two attempts at coding before giving up, to high complexity serious use cases in which tg/pp speed matters less and precision/intelligence matters a lot more.

**On my setup**

I'm running a very large model (Qwen3.5 397B, shipped in bf16) at a fairly high quantization:

    blk\..*\.attn_gate\.weight=bf16
    blk\..*\.attn_qkv\.weight=q8_0
    blk\..*\.attn_output\.weight=bf16
    blk\..*\.attn_q\.weight=bf16
    blk\..*\.attn_k\.weight=bf16
    blk\..*\.attn_v\.weight=bf16
    blk\..*\.ssm_alpha\.weight=bf16
    blk\..*\.ssm_beta\.weight=bf16
    blk\..*\.ssm_out\.weight=bf16
    
    # Shared Expert Layers [0-59]
    blk\..*\.ffn_down_shexp\.weight=q8_0
    blk\..*\.ffn_(gate|up)_shexp\.weight=q8_0
    
    # Routed Experts Layers [0-59]
    blk\..*\.ffn_down_exps\.weight=iq5_k
    blk\..*\.ffn_(gate|up)_exps\.weight=iq4_k
    
    # Non-Repeating Layers
    token_embd\.weight=q8_0
    output\.weight=q8_0
    

I am also running very large contexts, and I'm generating anywhere from 100k to several million tokens (adding tg and pp) per day. In short, whenever the model behaves strangely, or there is a loss of intelligence, output precision or logic capabilities, I am bound to notice.

Using

          -b 3072 -ub 3072
          -ctk f16 -ctv f16
          -cuda fusion=1,offload-batch-size=16,mmq-id-size=0,fa-offset=0
    

And no muge/mqkv/any other feature I can confidently say the model competes with the open router one, at least in coding capabilities. But:

**Some default features that are supposed to raise the ppl minimally will have an impact that I can notice over the days, and that impact often outweights the performance benefit of such features - especially when those ppl increments pile up on each other.**

### Possible Implementation

A few examples. I noticed these are all logical problems, so I don't know how visible they might be on a ppl test.

mmq-id-size=non zero

*   causes markdown degradation at long context (0 to 1-2 errors per 1k long message).  
    The model is now confused on whether to start a sentence with an Uppercase letter or not. \*Asterisks for emphasis are sometimes started but never closed, causing markdown errors. Same goes for quotes. I tried using mmq-id-size=(batch size - 1, after that multiplier baked in) in order to still use mmq on less then max batch size batches, and that made the output coherent for the first messages after 100k pp, but markdown decayed again a few messages after that (albeit more slowly).

fa-offset=non zero (idk what was the default. 0.6 something I think, but I could be wrong)

*   causes changes in agentic behavior and introduces rare errors when copy pasting complex urls.  
    On agentic behavior: web search cycles get interrupted early if they are high enough in number. (Normal cycle: think > web search > read link results + think > visit links - repeated as many times as needed. Normally 20 to 30 times from morning news bot use case.) After 4-5 cycles the model thinks "I should research x as well" but outputs im\_end instead. This is solved also by increasing bias for token "function\_call" and negative bias for "im\_end", albeit that has obvious side effects.  
    On url copy paste: some complex urls (with lots of random numbers/letters, or a security token) gathered either by web search or otherwise in context, will be mis pasted, failing the fetch. Probably the same happens with mmq-id-size=non zero, but I never tested it.

Q8 attention weights as opposed to bf16 (the model is shipped with BF16)

*   causes small logical fallacies at high context. These are rare and non game breaking, but they are a canary in the coal mine. Example:  
    Identity confusion. The model wrote something a few tens of thousands of tokens ago, but now thinks it was the user saying it instead. Jinja is fine.  
    Memory degradation. Keeping track of state changes becomes harder. Simplified version of the situation: Msg 1, you buy a hat, you wear a white t-shirt. Msg 2, you sell the hat, you pour tomato juice on your t-shirt. Msg-3 you wash you t-shirt. It's now clean. Question: did you have a hat two messages ago? Do you now? Is your t-shirt clean currently? - this sometimes failed.  
    This is fixed with the current attention quantization. The same quantization with q8 gate instead still caused some problems.

muge. I tested this very little. I got a bunch of grammar errors at high context when enabled, so I just disabled and forgot about it. Not a huge problem, the output still made sense overall. I just disabled for canary in the coal mine principle. I was sure these type of things don't impact intelligence, as I didn't notice anything bad with other models, albeit Qwen 3.5 is the first model that I use at very long context. This might just be a bug, but I'd like to have confirmation.

amb X - never tried this with Qwen 3.5 in normal usage as I never thought I needed it. Would this help with potential overflow problems if I had any? Or does it have no impact?

Q8 vs F16 cache. Idk if anything changes or how much. Bar for bench tests, I've always used F16 with Qwen 3.5, which makes me think that maybe the other errors I've gotten might not have happened with Q8 cache. Note that fa-offset=0 is the last thing I changed, and everything else was tested with default fa-offset. Also note that default fa-offset is somewhat unpredictable, as I noticed it can go up and down with prs, and I'm unlikely to notice. I think at some points it was 0, too.

Activity
--------

```

</details>

<details><summary>Tool result · web_search · call_e1878595ebec4361b709050b</summary>

**Firecrawl · section 1 of 20**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,829 characters · included below
- Section 2 · 11,241 characters · omitted from this copy
- Section 3 · 10,665 characters · omitted from this copy
- Section 4 · 11,593 characters · omitted from this copy
- Section 5 · 11,896 characters · omitted from this copy
- Section 6 · 11,287 characters · omitted from this copy
- Section 7 · 11,993 characters · omitted from this copy
- Section 8 · 11,900 characters · omitted from this copy
- Section 9 · 11,678 characters · omitted from this copy
- Section 10 · 11,965 characters · omitted from this copy
- Section 11 · 11,961 characters · omitted from this copy
- Section 12 · 11,966 characters · omitted from this copy
- Section 13 · 11,474 characters · omitted from this copy
- Section 14 · 11,670 characters · omitted from this copy
- Section 15 · 11,949 characters · omitted from this copy
- Section 16 · 11,254 characters · omitted from this copy
- Section 17 · 11,857 characters · omitted from this copy
- Section 18 · 10,607 characters · omitted from this copy
- Section 19 · 11,989 characters · omitted from this copy
- Section 20 · 6,772 characters · omitted from this copy

```text
## 1. unsloth/Qwen3.8-Flash-Next-GGUF · Share your model speed here

https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3

Aug 26, 2026 ... KV cache: F16; MTP: Disabled; Speculative decoding: Disabled for this benchmark. Launch parameters. llama-server.exe ^ -m "Qwen3.8-Flash-Next-UD ...

Share your model speed here
---------------------------

#3

by [anvme](https://huggingface.co/anvme) \- opened Aug 26

[Discussion](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3)

![](https://huggingface.co/avatars/9b13631797615e94c58220c45be23de4.svg)

[anvme](https://huggingface.co/anvme)

[Aug 26](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8edf9a6fc4edb0e8aa2df3)

•

[edited Aug 26](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8edf9a6fc4edb0e8aa2df3 "Edited 2 times by anvme")

Hey everyone!

I think this topic could be really useful for users who have plenty of system RAM to run larger models, but are limited by GPU VRAM

To make comparisons easier and help others understand what models/settings might work for their hardware, please share your setup and performance using the format below:

*   **1\. Model file / model name**
*   **2\. GPU:** model + VRAM
*   **3\. CPU:** model
*   **4\. RAM:** size + type
*   **5\. Generation speed:** tokens/sec
*   **6\. App / frontend:** e.g. FreeToken, llama.cpp, LM Studio, etc.
*   **7\. Launch parameters / settings:**
*   **8\. Extra notes:** quantization, context size, offloading, optimizations, or anything else worth mentioning

This should make it much easier for people to compare setups and decide which quantization to download

See translation

🤝

11

11

+

![](https://huggingface.co/avatars/66fc70f565e9da5cb7d5defa40163605.svg)

[tarruda](https://huggingface.co/tarruda)

[Aug 26](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8ee73518a395b7e6bfede9)

Curious to see if my old M1 ultra will have enough juice to run GGUF.

Also surprised that GGUF are already being uploaded, I thought this was a new architecture. Does unsloth have a llama.cpp fork that can already run this?

See translation

![](https://huggingface.co/avatars/b4218872a9353edbfc0c6987e4a14bea.svg)

[PrivacyX](https://huggingface.co/PrivacyX)

[Aug 26](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8ef214105347cbb75b3e3e)

Im hoping I can fit this in my AMD Ryzen Ai 395+ 128Gb sadly my 3 x 4090 will be useless for this LLM

See translation

🔥

5

5

🚀

1

1

+

![](https://huggingface.co/avatars/c19e8bc51b2ce2158b4d702f95a12b73.svg)

[johandevlabs](https://huggingface.co/johandevlabs)

[Aug 26](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8ef33c5f43f9044c94098c)

It will fit on a 128GB UMA, just a matter quantization. Unsloth writes the 4-bit will be 110GB, so that might be a bit tight on 128GB, hopefully we can offload ngram to SSD (or stream them or whatever its called).

See translation

![](https://cdn-avatars.huggingface.co/v1/production/uploads/676a15e3944839da3f76945e/siPEV8gK4PlXSSgjCMbIp.jpeg)

[LaikaFramework](https://huggingface.co/LaikaFramework)

[Aug 26](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8f12f3214fe7a323a84e5b)

•

[edited Aug 27](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8f12f3214fe7a323a84e5b "Edited 2 times by LaikaFramework")

AI MAX+ 395 gfx1151 rocm7.14  
Qwen3.8-Flash-Next-UD-IQ1\_S  
PP ~200-300t/s  
TG ~20t/s

[![image](https://cdn-uploads.huggingface.co/production/uploads/676a15e3944839da3f76945e/MnTCBtUe_fchND2Rtkqrf.png)](https://cdn-uploads.huggingface.co/production/uploads/676a15e3944839da3f76945e/MnTCBtUe_fchND2Rtkqrf.png)

Edited: Q4\_K\_XL  
[![image](https://cdn-uploads.huggingface.co/production/uploads/676a15e3944839da3f76945e/pfzavUXMPPYVTjgZPy8WL.png)](https://cdn-uploads.huggingface.co/production/uploads/676a15e3944839da3f76945e/pfzavUXMPPYVTjgZPy8WL.png)

See translation

👍

4

4

+

![](https://huggingface.co/avatars/66fc70f565e9da5cb7d5defa40163605.svg)

[tarruda](https://huggingface.co/tarruda)

[Aug 26](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8f1545fc0b716a86a05900)

Not scientific benchmarks yet (just seeing the llama-server numbers as I test it)

M1 Ultra 128G  
Qwen3.8-Flash-Next-UD-IQ1\_S  
PP ~ 400 tps  
TG ~ 20 tps

See translation

👍

1

1

+

![](https://huggingface.co/avatars/1912e524a0d5eb71d8db1b60127803c3.svg)

[Ennox](https://huggingface.co/Ennox)

[Aug 26](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8f496b0546530876378570)

Just a quick one before hitting bed:

AI MAX+ 395 gfx1151 + R9700 gfx1201  
Qwen3.8-Flash-Next-UD-IQ4\_XS

llama-bench --model /ai/models/Qwen3.8-Flash-Next-UD-IQ4\_XS-00001-of-00003.gguf -p 512,4096 -n 128,1024 -d 0,512 --device Vulkan0/Vulkan1 -ngl 99 -fa 1 -ts 40/50 --split-mode layer

WARNING: radv is not a conformant Vulkan implementation, testing use only.  
ggml\_vulkan: Found 2 Vulkan devices:  
ggml\_vulkan: 0 = AMD Radeon AI PRO R9700 (RADV GFX1201) (radv) | uma: 0 | fp16: 1 | bf16: 1 | fp4: 0 | warp size: 64 | shared memory: 65536 | int dot: 1 | matrix cores: KHR\_coopmat  
ggml\_vulkan: 1 = AMD Radeon Graphics (RADV STRIX\_HALO) (radv) | uma: 1 | fp16: 1 | bf16: 0 | fp4: 0 | warp size: 64 | shared memory: 65536 | int dot: 1 | matrix cores: KHR\_coopmat

| model | size | params | backend | ngl | fa  | dev | ts  | test | t/s |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| qwen4exp A3B IQ4\_XS - 4.25 bpw | 87.24 GiB | 176.94 B | Vulkan | 99  | 1   | Vulkan0/Vulkan1 | 40.00/50.00 | pp512 | 532.87 ± 11.64 |
| qwen4exp A3B IQ4\_XS - 4.25 bpw | 87.24 GiB | 176.94 B | Vulkan | 99  | 1   | Vulkan0/Vulkan1 | 40.00/50.00 | pp4096 | 464.10 ± 4.44 |
| qwen4exp A3B IQ4\_XS - 4.25 bpw | 87.24 GiB | 176.94 B | Vulkan | 99  | 1   | Vulkan0/Vulkan1 | 40.00/50.00 | tg128 | 23.25 ± 0.10 |
| qwen4exp A3B IQ4\_XS - 4.25 bpw | 87.24 GiB | 176.94 B | Vulkan | 99  | 1   | Vulkan0/Vulkan1 | 40.00/50.00 | tg1024 | 23.03 ± 0.47 |
| qwen4exp A3B IQ4\_XS - 4.25 bpw | 87.24 GiB | 176.94 B | Vulkan | 99  | 1   | Vulkan0/Vulkan1 | 40.00/50.00 | pp512 @ d512 | 497.23 ± 14.41 |
| qwen4exp A3B IQ4\_XS - 4.25 bpw | 87.24 GiB | 176.94 B | Vulkan | 99  | 1   | Vulkan0/Vulkan1 | 40.00/50.00 | pp4096 @ d512 | 462.56 ± 7.05 |
| qwen4exp A3B IQ4\_XS - 4.25 bpw | 87.24 GiB | 176.94 B | Vulkan | 99  | 1   | Vulkan0/Vulkan1 | 40.00/50.00 | tg128 @ d512 | 23.16 ± 0.46 |
| qwen4exp A3B IQ4\_XS - 4.25 bpw | 87.24 GiB | 176.94 B | Vulkan | 99  | 1   | Vulkan0/Vulkan1 | 40.00/50.00 | tg1024 @ d512 | 22.15 ± 0.22 |

build: 035e22731 (10656)

See translation

👍

3

3

+

![](https://huggingface.co/avatars/31a256ae8afd332bda1f7ef0696e78ed.svg)

[larskort](https://huggingface.co/larskort)

[Aug 27](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8f853f1d0b5145e992818a)

•

[edited Aug 28](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8f853f1d0b5145e992818a "Edited 4 times by larskort")

Qwen3.8-Flash-Next-UD-Q4\_K\_XL  
CPU: 2x Xeon 2697v4  
GPU: 2x 7800XT + Mi50 32Gb + 4Mi50x16Gb (128GB) + 2x Nvidia P100 (unused)  
Backend: llama.cpp  
Split mode: layer

PP 288 / TG 16 @CTX4K

Just a fast test, waiting for further optimizations, MiniMax M2.7 Q3\_K 110Gb runs at PP 400 / TG 20

CUDA\_VISIBLE\_DEVICES=999 HIP\_VISIBLE\_DEVICES=0,1,2,3,4,5,6,7 GGML\_CUDA\_DISABLE\_GRAPHS=1 GGML\_CUDA\_GRAPH\_OPT=0 ./llama-server-qw4 -m /mnt/md4t/llms/Qwen3.8-Flash-Next-UD-Q4\_K\_XL-00001-of-00004.gguf -c 60000 --host 0.0.0.0 --port 8081 --threads 12 --temp 0.65 --top-p 0.95 --top-k 40 --min-p 0.05 --presence-penalty 0.25 --repeat-penalty 1.05 --no-context-shift -b 2200 -ub 2200 --load-mode none --threads-batch 24 -fa on -fit on --reasoning off -np 1 --cache-ram 32000 --parallel 1 --swa-checkpoints 64 --ctx-checkpoints 64 --swa-full --kv-unified -cb --keep -1 -mg 0 --jinja --chat-template-file /home/llama/models/Qwen3.8-27B-UD-Q6\_K.chat\_template.jinja -fitt 128

///////  
UPDATE AFTER OFFICIAL MERGE  
//////  
prompt eval time = 17410.47 ms / 4685 tokens ( 3.72 ms per token, 269.09 tokens per second)  
eval time = 245548.29 ms / 4763 tokens ( 51.56 ms per token, 19.39 tokens per second)

Thank you Unsloth for zero day access and your work!

See translation

👍

1

1

+

![](https://cdn-avatars.huggingface.co/v1/production/uploads/691dcdcf6734085d770c4188/NUSGODB7N2edAQnPhRmyj.jpeg)

[DogOnKeyboard](https://huggingface.co/DogOnKeyboard)

[Aug 27](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8fb0ad45a6339c669c3dd8)

•

[edited Aug 27](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8fb0ad45a6339c669c3dd8 "Edited 4 times by DogOnKeyboard")

edit: After some tinkering around i could squeeze a few more tokens out of it, looking forward to more optimizations and projects like: [https://github.com/syv-ai/qwen38-27b-rtx3090](https://github.com/syv-ai/qwen38-27b-rtx3090)
 for this model.

1.  Model: Qwen3.8-Flash-Next-UD-Q4\_K\_XL
2.  GPU: RTX 3090TI 24GB
3.  CPU: Ryzen 9 5950X C16/T32
4.  RAM: 128GB DDR4 3200mhz
5.  Generation speed with 30k prompt: 15t/s | Processing speed: ~340t/s | Eval Speed: ~310t/s
6.  Engine & Frontend: llama.cpp with this fix [https://github.com/ggml-org/llama.cpp/pull/27742](https://github.com/ggml-org/llama.cpp/pull/27742)
    
7.  Launch Parameter: llama-server -m Qwen3.8-Flash-Next-UD-Q4\_K\_XL.gguf --host 127.0.0.1 --port 8282 --device CUDA0 --ctx-size 130000 --fit on --fit-target 1024 --flash-attn on --cache-type-k q8\_0 --cache-type-v q8\_0 --spec-type ngram-mod --batch-size 2048 --ubatch-size 2048 --threads 12 --load-mode none --metrics --alias Qwen3.8-Flash-Next-UD-Q4\_K\_XL
8.  Context Size: 130k

[![token](https://cdn-uploads.huggingface.co/production/uploads/691dcdcf6734085d770c4188/DVYnL7cQ5wDuzwK1pc1PU.png)](https://cdn-uploads.huggingface.co/production/uploads/691dcdcf6734085d770c4188/DVYnL7cQ5wDuzwK1pc1PU.png)

See translation

👍

2

2

+

![](https://huggingface.co/avatars/4491f03360b0d2e01cdabe8e2862a90b.svg)

[quimeyv](https://huggingface.co/quimeyv)

[Aug 27](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a8ff103e792110619731d6d)

I have a AI MAX+ 395 gfx1151 running in fedora with rocm 7.1

I've put Qwen3.8-Flash-Next-UD-IQ4\_XS to do some real agentic work and it's decent (very similar performance to qwen3.8 27b)

    8.10.118.425 I slot print_timing: id  2 | task 2248 | prompt eval time =    3548.50 ms /   517 tokens (    6.86 ms per token,   145.70 tokens per second)
    8.10.118.428 I slot print_timing: id  2 | task 2248 |        eval time =   95902.06 ms /  1070 tokens (   89.71 ms per token,    11.15 tokens per second)
    8.10.118.429 I slot print_timing: id  2 | task 2248 |       total time =   99450.56 ms /  1587 tokens
    

See translation

👍

1

1

+

![](https://huggingface.co/avatars/b39381f76fefd58bec155043ddba363c.svg)

[g4bw](https://huggingface.co/g4bw)

[Aug 27](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a900c4acf1573e4bdadd0cd)

on my side I smell something's fishy with the current llama.cpp PR. cf. [https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/22#6a900962d7cc2416049c53c7](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/22#6a900962d7cc2416049c53c7)

See translation

👍

1

1

+

![](https://huggingface.co/avatars/bdfd17112cdb57ecac16d443b15e9d90.svg)

[williamliao](https://huggingface.co/williamliao)

[Aug 27](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a903480d48219cfa56997ea)

•

[edited Aug 27](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3#6a903480d48219cfa56997ea "Edited by williamliao")

```

</details>

## Assistant · #16

<details><summary>Reasoning · 2,774 characters</summary>

Excellent — I found a very relevant primary source: ik_llama.cpp issue #1529 which literally asks "for kv cache, for cuda at least, there doesn't seem to be a reason to use BF16 over F16, am I wrong?" and ikawrakow replied "I didn't think you could even BF16 the KV, only F16."

Let me get more of that issue thread — the reply from ikawrakow. Let me read further sections of resource 1cc9ba88 to find the answer. Search for "BF16" in that resource.

Also, let me find the llama.cpp docs on KV cache quantization (docs/llama-cpp-server.md? or the README "LLM quantization with llama-quantize" section which lists KV cache quantization support matrix including bf16). Also the Ollama / llama.cpp PR that added bf16 KV cache support.

Also relevant: the sotaaz post measured bf16 = same memory as f16, half decode speed.

Also, there might be a specific paper: "KV cache quantization: is bf16 or fp16 better?" Let me search for papers that compare fp16/bf16 KV: e.g., "KV Cache is 1 Bit Per Channel", "CacheGen", "TurboQuant", "QuaRot", "KIVI", "A Survey on Efficient Inference...". Also there's a known nuance: BF16 has 8-bit mantissa, F16 has 10-bit mantissa → for KV values within f16 range, f16 is more precise. But BF16 avoids overflow for large magnitudes. Also on some hardware (AMD MI300, Ascend, Hopper), bf16 is native and f16 requires conversion.

Let me also check the unsloth Qwen3.8-Flash-Next docs for recommended KV cache settings, and search for the specific Qwen3.8-Flash-Next tech report mention of "BF16 KV cache" or training precision ("All router layers are using BF16 precision"). Also the QSA / hybrid nature means most layers have no KV cache at all (only 12 attention layers out of 48), so KV cache is tiny — that's the crucial model-specific fact: with 2 KV heads × 256 head_dim × 12 layers, KV per token = 12 × 2 × 2 × 256 = 12,288 elements ≈ 24 KB/token at f16. So at 262k context ≈ 6.3 GB. Hmm, carteakey says "q8 KV (64k) ~0.6" GiB → 0.6 GiB / 65536 tokens = ~9.8 KB/token → that's about 12 layers × 2 (K+V) × 2 heads × 128? Let's compute: 9.8 KB/token at q8_0 (1 byte/elem) → ~10,000 elements. Close to 12,288 minus scale overhead... roughly matches. Good.

Key point for the answer: for this model the KV cache is small because of QSA + DeltaNet hybrid, so f16 usually fits and bf16 gains nothing (same 2 bytes).

Now let me find:
1. ikawrakow's reply in issue #1529 (exact wording).
2. llama.cpp official docs on KV cache types + bf16 (README "KV cache quantization" section, or docs).
3. A research paper comparing fp16 vs bf16 KV: search "arxiv bf16 fp16 kv cache mantissa precision degradation long context".
4. Unsloth docs Qwen3.8-Flash-Next recommended flags (KV cache).

Let me search resource 1cc9ba88 for "BF16" and do web searches.


</details>

<details><summary>Tool request · resource_search · call_128985a69b754572b2b9947b</summary>

```json
{
  "query": "BF16 KV only F16 ikawrakow reply",
  "resource_id": "654be1f5-6a9e-44d0-8ee5-6bbe44f63f9b"
}
```

</details>

<details><summary>Tool request · web_scrape · call_6198cb00132145b69398ef5d</summary>

```json
{
  "url": "https://github.com/ikawrakow/ik_llama.cpp/issues/1529"
}
```

</details>

<details><summary>Tool request · web_search · call_4c144eef3b4042d6bbc4dc3a</summary>

```json
{
  "query": "arxiv KV cache bf16 fp16 precision comparison mantissa bits long context degradation paper",
  "limit": 10
}
```

</details>

Found a primary source that asks this exact question. Let me pull the maintainer's reply and hunt for the paper-side comparisons.
<details><summary>Tool result · resource_search · call_128985a69b754572b2b9947b</summary>

# Search: Search: ik_llama.cpp IQ3_S KV cache bf16 precision lossless attention

Query: "BF16 KV only F16 ikawrakow reply"

- [Section 84 — Records by GPU](#resource-654be1f5-6a9e-44d0-8ee5-6bbe44f63f9b-section-84) · table
  | | | | | | | --- | --- | --- | --- | --- |Recent examples, one report per row and one example per GPU. Each report records one GPU or Mac. Different workloads and possible CPU offloading mean these speeds do not rank the hardware. | Hardware | Model and setup…

</details>

<details><summary>Tool result · web_scrape · call_6198cb00132145b69398ef5d</summary>

**Firecrawl · section 1 of 2**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,689 characters · included below
- Section 2 · 6,438 characters · omitted from this copy

```text
[Skip to content](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#start-of-content)
           

You signed in with another tab or window. [Reload](https://github.com/ikawrakow/ik_llama.cpp/issues/1529)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/ikawrakow/ik_llama.cpp/issues/1529)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/ikawrakow/ik_llama.cpp/issues/1529)
 to refresh your session. Dismiss alert

                                                                                                                               [](https://github.com/ikawrakow/ik_llama.cpp)

Feature Request: Quantization/features quality vs speed documentation #1529
===========================================================================

[New issue](https://github.com/login?return_to=https://github.com/ikawrakow/ik_llama.cpp/issues/1529)

Copy link

[New issue](https://github.com/login?return_to=https://github.com/ikawrakow/ik_llama.cpp/issues/1529)

Copy link

Closed

Closed

[Feature Request: Quantization/features quality vs speed documentation](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#top)
#1529

Copy link

Labels

[enhancementNew feature or request](https://github.com/ikawrakow/ik_llama.cpp/issues?q=state%3Aopen%20label%3A%22enhancement%22)
New feature or request

Description
-----------

[![@ghost](https://github.com/ghost.png?size=48)](https://github.com/ghost)

[ghost](https://github.com/ghost)

opened [on Mar 27, 2026](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#issue-4152813611)

### Prerequisites

*   I am running the latest code. Mention the version if possible as well.
    
    I carefully followed the [README.md](https://github.com/ggerganov/llama.cpp/blob/master/README.md)
    .
    
    I searched using keywords relevant to my issue to make sure that I am creating a new issue that is not already open (or closed).
    
    I reviewed the [Discussions](https://github.com/ggerganov/llama.cpp/discussions)
    , and have a new and useful enhancement to share.
    
    To pick up a draggable item, press the space bar. While dragging, use the arrow keys to move the item. Press space again to drop the item in its new position, or press escape to cancel.
    

### Feature Description

A readme with

*   a list of all of the features (especially the ones turned on by default) that impact inference quality for attention critical use cases
*   kv cache/weights quantization clarification and existing kernel capabilities for cuda/Vulkan/others. (To know when things get casted to other types)

For example:

*   regarding q8 vs native BF16 attention weights quality, I'm getting confusing information which doesn't quite match results. Q8 seems noticeably worse then BF16 in my use cases (using fa-offset 0, fp16 kv, long context, 4096 batches)
*   for kv cache, for cuda at least, there doesn't seem to be a reason to use BF16 over F16, am I wrong?

The focus should be on defining front ender level tuning knobs for quality vs speed. I know a few, I don't know which ones I'm missing. These should be well documented. More in possible implementation.

### Motivation

The average use case for modern models is shifting radically towards higher complexity/higher context tasks, making attention precision far more important, for a variety of reasons.  
1 - MoE now enables even gaming PCs to run massive models, enabling more complex, attention critical use cases  
2 - Hardware has gotten faster, and Delta net and hybrid approaches have made kv cache memory requirements much smaller, enabling local high context use cases  
3 - High context reduces reliance on the model original training - which was never reliable in the first place. Now we can just RAG/throw in context all the documentation for whatever use case we have, making attention precision far more important  
4 - Agentic use cases are more common, and require high precision

A few examples of my use cases:

*   Morning news bot: the bot goes trough a list of topics (economy news, a list of stocks news, war news, Linux news, EU news, RSS feeds) and iteratively searches news while I'm having coffee + breakfast. This is 20-30 tool calls in sequence. The news are compared to the last days news in order not to repeat the same news twice. Context often surpasses 100k depending on visited websites. Speed is irrelevant (takes 5-10 minutes anyway), but getting a URL wrong, interrupting generation, or crashing due to a wrong tool call is problematic. I might miss important financial news or have to restart the process.
*   Tax questions: I have a few pdf files that list all tax deductions available in my country. These are 100-200k tokens files, and while I don't overly care whether pp will take 3 minutes or 4, the info I get needs to be accurate for obvious reasons. High context, memory critical.
*   Coding: llms are actually useful finally. But you won't go anywhere without loading the documentation/libraries in context first, especially if you want to use some obscure and continuously worked on rust crate. Again, high context, attention critical use case. Speed is important too, but that has to be balanced with the amount of additional swiping/wrong answers I get. You might save a minute on tg only to lose an hour for missing an important detail or pasting a function name wrong.
*   Legal and medical advice: while too critical to entirely depend on, with good web search or a good amount of documents loaded in it can still have it's uses, especially for minor problems (reflux issues, minor neighbor problems). Again, high context, agentic, attention critical.
*   Bash access: I never tried it personally, I recall Google Bard advising Linux users to remove the French language from their system, so I've always been on edge about it. But with the right safeguards it's something I'll eventually do. Git commands, basic cd, ls, mv, rm, wget. This is all still somewhat critical stuff, even getting a file name wrong once every 100 commands is unacceptable.

**Conclusion**: We are moving from RP bots + one or two attempts at coding before giving up, to high complexity serious use cases in which tg/pp speed matters less and precision/intelligence matters a lot more.

**On my setup**

I'm running a very large model (Qwen3.5 397B, shipped in bf16) at a fairly high quantization:

    blk\..*\.attn_gate\.weight=bf16
    blk\..*\.attn_qkv\.weight=q8_0
    blk\..*\.attn_output\.weight=bf16
    blk\..*\.attn_q\.weight=bf16
    blk\..*\.attn_k\.weight=bf16
    blk\..*\.attn_v\.weight=bf16
    blk\..*\.ssm_alpha\.weight=bf16
    blk\..*\.ssm_beta\.weight=bf16
    blk\..*\.ssm_out\.weight=bf16
    
    # Shared Expert Layers [0-59]
    blk\..*\.ffn_down_shexp\.weight=q8_0
    blk\..*\.ffn_(gate|up)_shexp\.weight=q8_0
    
    # Routed Experts Layers [0-59]
    blk\..*\.ffn_down_exps\.weight=iq5_k
    blk\..*\.ffn_(gate|up)_exps\.weight=iq4_k
    
    # Non-Repeating Layers
    token_embd\.weight=q8_0
    output\.weight=q8_0
    

I am also running very large contexts, and I'm generating anywhere from 100k to several million tokens (adding tg and pp) per day. In short, whenever the model behaves strangely, or there is a loss of intelligence, output precision or logic capabilities, I am bound to notice.

Using

          -b 3072 -ub 3072
          -ctk f16 -ctv f16
          -cuda fusion=1,offload-batch-size=16,mmq-id-size=0,fa-offset=0
    

And no muge/mqkv/any other feature I can confidently say the model competes with the open router one, at least in coding capabilities. But:

**Some default features that are supposed to raise the ppl minimally will have an impact that I can notice over the days, and that impact often outweights the performance benefit of such features - especially when those ppl increments pile up on each other.**

### Possible Implementation

A few examples. I noticed these are all logical problems, so I don't know how visible they might be on a ppl test.

mmq-id-size=non zero

*   causes markdown degradation at long context (0 to 1-2 errors per 1k long message).  
    The model is now confused on whether to start a sentence with an Uppercase letter or not. \*Asterisks for emphasis are sometimes started but never closed, causing markdown errors. Same goes for quotes. I tried using mmq-id-size=(batch size - 1, after that multiplier baked in) in order to still use mmq on less then max batch size batches, and that made the output coherent for the first messages after 100k pp, but markdown decayed again a few messages after that (albeit more slowly).

fa-offset=non zero (idk what was the default. 0.6 something I think, but I could be wrong)

*   causes changes in agentic behavior and introduces rare errors when copy pasting complex urls.  
    On agentic behavior: web search cycles get interrupted early if they are high enough in number. (Normal cycle: think > web search > read link results + think > visit links - repeated as many times as needed. Normally 20 to 30 times from morning news bot use case.) After 4-5 cycles the model thinks "I should research x as well" but outputs im\_end instead. This is solved also by increasing bias for token "function\_call" and negative bias for "im\_end", albeit that has obvious side effects.  
    On url copy paste: some complex urls (with lots of random numbers/letters, or a security token) gathered either by web search or otherwise in context, will be mis pasted, failing the fetch. Probably the same happens with mmq-id-size=non zero, but I never tested it.

Q8 attention weights as opposed to bf16 (the model is shipped with BF16)

*   causes small logical fallacies at high context. These are rare and non game breaking, but they are a canary in the coal mine. Example:  
    Identity confusion. The model wrote something a few tens of thousands of tokens ago, but now thinks it was the user saying it instead. Jinja is fine.  
    Memory degradation. Keeping track of state changes becomes harder. Simplified version of the situation: Msg 1, you buy a hat, you wear a white t-shirt. Msg 2, you sell the hat, you pour tomato juice on your t-shirt. Msg-3 you wash you t-shirt. It's now clean. Question: did you have a hat two messages ago? Do you now? Is your t-shirt clean currently? - this sometimes failed.  
    This is fixed with the current attention quantization. The same quantization with q8 gate instead still caused some problems.

muge. I tested this very little. I got a bunch of grammar errors at high context when enabled, so I just disabled and forgot about it. Not a huge problem, the output still made sense overall. I just disabled for canary in the coal mine principle. I was sure these type of things don't impact intelligence, as I didn't notice anything bad with other models, albeit Qwen 3.5 is the first model that I use at very long context. This might just be a bug, but I'd like to have confirmation.

amb X - never tried this with Qwen 3.5 in normal usage as I never thought I needed it. Would this help with potential overflow problems if I had any? Or does it have no impact?

Q8 vs F16 cache. Idk if anything changes or how much. Bar for bench tests, I've always used F16 with Qwen 3.5, which makes me think that maybe the other errors I've gotten might not have happened with Q8 cache. Note that fa-offset=0 is the last thing I changed, and everything else was tested with default fa-offset. Also note that default fa-offset is somewhat unpredictable, as I noticed it can go up and down with prs, and I'm unlikely to notice. I think at some points it was 0, too.

Activity
--------

```

</details>

<details><summary>Tool result · web_search · call_4c144eef3b4042d6bbc4dc3a</summary>

**Firecrawl · section 1 of 67**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,924 characters · included below
- Section 2 · 11,744 characters · omitted from this copy
- Section 3 · 11,636 characters · omitted from this copy
- Section 4 · 11,799 characters · omitted from this copy
- Section 5 · 11,884 characters · omitted from this copy
- Section 6 · 11,992 characters · omitted from this copy
- Section 7 · 11,992 characters · omitted from this copy
- Section 8 · 11,987 characters · omitted from this copy
- Section 9 · 11,641 characters · omitted from this copy
- Section 10 · 11,879 characters · omitted from this copy
- Section 11 · 11,955 characters · omitted from this copy
- Section 12 · 11,775 characters · omitted from this copy
- Section 13 · 11,640 characters · omitted from this copy
- Section 14 · 11,577 characters · omitted from this copy
- Section 15 · 11,954 characters · omitted from this copy
- Section 16 · 11,336 characters · omitted from this copy
- Section 17 · 10,917 characters · omitted from this copy
- Section 18 · 9,230 characters · omitted from this copy
- Section 19 · 11,878 characters · omitted from this copy
- Section 20 · 11,921 characters · omitted from this copy
- Section 21 · 11,970 characters · omitted from this copy
- Section 22 · 11,849 characters · omitted from this copy
- Section 23 · 8,417 characters · omitted from this copy
- Section 24 · 9,591 characters · omitted from this copy
- Section 25 · 11,339 characters · omitted from this copy
- Section 26 · 10,509 characters · omitted from this copy
- Section 27 · 9,871 characters · omitted from this copy
- Section 28 · 8,690 characters · omitted from this copy
- Section 29 · 10,490 characters · omitted from this copy
- Section 30 · 11,869 characters · omitted from this copy
- Section 31 · 8,481 characters · omitted from this copy
- Section 32 · 9,948 characters · omitted from this copy
- Section 33 · 11,503 characters · omitted from this copy
- Section 34 · 11,964 characters · omitted from this copy
- Section 35 · 11,134 characters · omitted from this copy
- Section 36 · 9,874 characters · omitted from this copy
- Section 37 · 11,593 characters · omitted from this copy
- Section 38 · 10,545 characters · omitted from this copy
- Section 39 · 11,994 characters · omitted from this copy
- Section 40 · 11,893 characters · omitted from this copy
- Section 41 · 11,078 characters · omitted from this copy
- Section 42 · 11,692 characters · omitted from this copy
- Section 43 · 11,166 characters · omitted from this copy
- Section 44 · 11,730 characters · omitted from this copy
- Section 45 · 11,037 characters · omitted from this copy
- Section 46 · 11,691 characters · omitted from this copy
- Section 47 · 11,774 characters · omitted from this copy
- Section 48 · 11,831 characters · omitted from this copy
- Section 49 · 11,776 characters · omitted from this copy
- Section 50 · 11,784 characters · omitted from this copy
- Section 51 · 11,764 characters · omitted from this copy
- Section 52 · 11,486 characters · omitted from this copy
- Section 53 · 11,995 characters · omitted from this copy
- Section 54 · 11,816 characters · omitted from this copy
- Section 55 · 11,688 characters · omitted from this copy
- Section 56 · 11,192 characters · omitted from this copy
- Section 57 · 11,729 characters · omitted from this copy
- Section 58 · 8,461 characters · omitted from this copy
- Section 59 · 11,948 characters · omitted from this copy
- Section 60 · 11,754 characters · omitted from this copy
- Section 61 · 7,239 characters · omitted from this copy
- Section 62 · 11,967 characters · omitted from this copy
- Section 63 · 6,717 characters · omitted from this copy
- Section 64 · 9,714 characters · omitted from this copy
- Section 65 · 11,991 characters · omitted from this copy
- Section 66 · 12,001 characters · omitted from this copy
- Section 67 · 5,432 characters · omitted from this copy

```text
## 1. Reimagining Memory Access for LLM Inference - arXiv

https://arxiv.org/html/2503.18869v1

Mar 24, 2025 ... 7: Comparison of KV cache bit-plane 4KB compression ratios in the ... KV cache by as much as 46.9%—all without degrading model accuracy.

[Skip to main content](https://arxiv.org/html/2503.18869v1#infobox)

Title: 

Content selection saved. Describe the issue below:

Description:

[License: arXiv.org perpetual non-exclusive license](https://info.arxiv.org/help/license/index.html#licenses-available)

arXiv:2503.18869v1 \[cs.AR\] 24 Mar 2025

Reimagining Memory Access for LLM Inference: Compression-Aware Memory Controller Design  

==========================================================================================

Rui Xie1, Asad Ul Haq1, Linsen Ma1, Yunhua Fang1, Zirak Burzin Engineer2, Liu Liu1, and Tong Zhang1 Affiliation: 1Rensselaer Polytechnic Institute, Troy, NY, USA  
2Wiseburn Da Vinci Science, El Segundo, CA, USA

###### Abstract

The efficiency of Large Language Model (LLM) inference is often constrained by substantial memory bandwidth and capacity demands. Existing techniques, such as pruning, quantization, and mixture of experts/depth, reduce memory capacity and/or bandwidth consumption at the cost of slight degradation in inference quality. This paper introduces a design solution that further alleviates memory bottlenecks by enhancing the on-chip memory controller in AI accelerators to achieve two main objectives: (1) significantly reducing memory capacity and bandwidth usage through lossless block compression (e.g., LZ4 and ZSTD) of model weights and key-value (KV) cache without compromising inference quality, and (2) enabling memory bandwidth and energy consumption to scale proportionally with context-dependent dynamic quantization. These goals are accomplished by equipping the on-chip memory controller with mechanisms to improve fine-grained bit-level accessibility and compressibility of weights and KV cache through LLM-aware configuration of in-memory placement and representation. Experimental results on publicly available LLMs demonstrate the effectiveness of this approach, showing memory footprint reductions of 25.2% for model weights and 46.9% for KV cache. In addition, our hardware prototype at 4 GHz and 32 lanes (7 nm) achieves 8 TB/s throughput with a modest area overhead (under 3.8 mm2), which underscores the viability of LLM-aware memory control as a key to efficient large-scale inference.

I Introduction
--------------

Large Language Models (LLMs) have pushed the boundaries of natural language processing and generative AI by achieving impressive performance on tasks such as text generation, question answering, and code completion. As these models scale to billions or even trillions of parameters, however, their inference demands become increasingly constrained by memory bandwidth and capacity \[[1](https://arxiv.org/html/2503.18869v1#bib.bib1)\
\]. While the raw compute may be adequate, the sheer volume of parameters and associated data transfers often stalls the accelerator, resulting in suboptimal throughput and higher operational costs. Under these conditions, memory pressure intensifies, since the system must fetch billions of parameters from off-chip DRAM repeatedly, layer by layer, for each user request. Even small inefficiencies in memory access can cascade into significant overall slowdowns, magnifying both inference time and total operational cost. Furthermore, since LLMs are often fine-tuned or adapted for specialized domains, their parameters can be heterogeneous, featuring layers that might be more compressible than others. Such diversity further underscores the importance of a memory subsystem that can flexibly and efficiently handle different data patterns.

To alleviate this bottleneck, researchers have extensively explored _lossy compression_ techniques, such as pruning, quantization, and mixture of experts/depth, which reduce memory consumption at the cost of minor (though sometimes noticeable) degradation in inference quality \[[2](https://arxiv.org/html/2503.18869v1#bib.bib2)\
, [3](https://arxiv.org/html/2503.18869v1#bib.bib3)\
, [4](https://arxiv.org/html/2503.18869v1#bib.bib4)\
\]. These methods have shown promise for large-scale LLMs, but they necessarily introduce approximations. By contrast, _lossless compression_ could preserve exact numerical fidelity while still shrinking the model footprint; however, floating-point data generally exhibit low compressibility under standard algorithms (e.g., LZ4 \[[5](https://arxiv.org/html/2503.18869v1#bib.bib5)\
\], ZSTD \[[6](https://arxiv.org/html/2503.18869v1#bib.bib6)\
\]), thus limiting their efficacy in practice.

This paper introduces an approach to notably increase the lossless compressibility of model weights and key-value (KV) cache by optimizing their in-memory bit-level placement and representation. Motivated by prior works on bit-plane data placement \[[7](https://arxiv.org/html/2503.18869v1#bib.bib7)\
, [8](https://arxiv.org/html/2503.18869v1#bib.bib8)\
, [9](https://arxiv.org/html/2503.18869v1#bib.bib9)\
\], we propose two specific techniques: (1) Bit-plane disaggregation: Instead of storing all bits of each weight or KV cache element (e.g., FP16 or FP8) contiguously, we organize data by keeping same-position bits together, effectively creating a bit-level in-memory column-store \[[10](https://arxiv.org/html/2503.18869v1#bib.bib10)\
, [11](https://arxiv.org/html/2503.18869v1#bib.bib11)\
\]. (2) Cross-token KV cache clustering and de-correlation: Observing that KV cache elements on the same channel of adjacent tokens tend to show stronger bit-level correlation, we cluster these elements together in memory and apply simple de-correlation mechanisms (e.g., subtraction) to reduce bit-level entropy. By applying these techniques to model weights and KV cache, we can largely enhance their lossless compressibility (especially for KV cache), enabling effective use of conventional lossless compression algorithms like LZ4 and ZSTD.

Additionally, recent studies \[[12](https://arxiv.org/html/2503.18869v1#bib.bib12)\
, [13](https://arxiv.org/html/2503.18869v1#bib.bib13)\
\] reveal that the importance of different weights and KV cache elements varies significantly based on runtime context during inference, opening the door for dynamic quantization to further improve efficiency. With AI accelerators now supporting variable-precision arithmetic at the hardware level, these systems can leverage context-dependent quantization (e.g., dynamically adjusting precision from FP16 to FP8) to enhance computational efficiency. However, it is not immediately clear how memory bandwidth/energy consumption can be proportionally reduced. Coincidentally, our bit-plane disaggregation technique can fill this missing link: it enables memory bandwidth and energy consumption to scale gracefully with context-adaptive dynamic quantization of weights and KV cache.

To ensure practical feasibility, we propose integrating these techniques, along with hardware-accelerated lossless compression and decompression, into the on-chip memory controller of AI accelerators. This approach minimizes changes to the computational framework and software stack, as the memory controller only needs to be aware of the data semantics of weights and KV cache. All bit-level data manipulations and compression tasks occur within the memory controller, remaining transparent to the computing fabric and software stack. Through extensive experiments on publicly available LLMs, we demonstrate that our approach achieves significant reductions in memory footprint without compromising inference accuracy. Experimental results reveal memory footprint reductions of 25.2% for model weights and 46.9% for KV cache when using ZSTD lossless compression. Moreover, simulations conducted using DRAMSim3 \[[14](https://arxiv.org/html/2503.18869v1#bib.bib14)\
\] demonstrate that, compared to straightforward in-memory placement, our proposed approach can reduce data load latency by up to 32.0% and lower memory access energy consumption by 29.9%.

II Background and Motivation
----------------------------

### II-A Memory Challenges in LLM Inference

During LLM inference, the model repeatedly generates tokens by passing the entire input sequence (including previously generated tokens) through multiple layers. In large models (e.g., LLaMA 3.1 405B \[[15](https://arxiv.org/html/2503.18869v1#bib.bib15)\
\], DeepSeek R1 671B \[[16](https://arxiv.org/html/2503.18869v1#bib.bib16)\
\]), storing these weights already demands significant capacity (750GB of LLaMA 3.1 405B, 1543GB of DeepSeek R1 671B). Beyond the parameters, every token update must also preserve a key-value (KV) cache that expands with sequence length. As shown in Fig. [1](https://arxiv.org/html/2503.18869v1#S2.F1 "Fig. 1 ‣ II-A Memory Challenges in LLM Inference ‣ II Background and Motivation ‣ Reimagining Memory Access for LLM Inference: Compression-Aware Memory Controller Design")
, once the sequence extends beyond a few thousand tokens, the KV cache can overshadow all other memory components, exceeding 90% of the total footprint in the LLaMA 3.1 8B model. This quickly becomes a capacity crisis, requiring substantial DRAM or HBM provisioning to prevent frequent swapping or out-of-memory failures.

![Refer to caption](https://arxiv.org/html/2503.18869v1/kv_vs_model.png)

Fig. 1: Percentage contribution of KV cache and model weights to total memory footprint with increasing sequence length in LLaMA 3.1 8B model.

In autoregressive decoding, each new token must read and compute against all model weights layer by layer, incurring large, repeated bandwidth demands. Moreover, tokens in the KV cache must be fetched (and updated) for attention calculations. Hence, both model weights and historical context collectively exert high bandwidth pressure on the memory subsystem. Even if the hardware provides ample compute throughput, inference throughput can stall unless memory traffic (i.e., read requests for weights and KV data) can be served rapidly. Alleviating this bandwidth bottleneck is often as critical as reducing raw model size, since partial or frequent memory stalls directly prolong token generation latency.

### II-B Lossless compression on LLM

Lossless compression holds the promise of reducing memory usage without degrading inference quality, making it an attractive complement to existing _lossy_ techniques. In principle, general-purpose methods such as LZ4 \[[5](https://arxiv.org/html/2503.18869v1#bib.bib5)\
\] and ZSTD \[[6](https://arxiv.org/html/2503.18869v1#bib.bib6)\
\] can detect repeated byte sequences, zeros, or short runs of similar data, thus condensing the stored representation. However, as shown in Table [I](https://arxiv.org/html/2503.18869v1#S2.T1 "TABLE I ‣ II-B Lossless compression on LLM ‣ II Background and Motivation ‣ Reimagining Memory Access for LLM Inference: Compression-Aware Memory Controller Design")
, straightforwardly applying these compressors to LLM data (i.e., model weights and key-value (KV) caches) yields only limited success. LZ4 fails to reduce the footprint of weights and KV caches in most cases, and ZSTD attains moderate gains for some model parameters (e.g., 23% on Gemma 2 2B weights \[[17](https://arxiv.org/html/2503.18869v1#bib.bib17)\
\]).

TABLE I: Model weights and KV cache footprint reduction under lossless compression.

| Comp. Method | LLaMA 3.1 8B | Gemma 2 2B | Mistral 7B | OPT 13B | Mixtral 8×7B |
| --- | --- | --- | --- | --- | --- |
| Model Weights |     |     |     |     |     |
| --- | --- | --- | --- | --- | --- |
| LZ4 | 0.0% | 11.5% | 0.0% | 0.0% | 18.0% |
| ZSTD | 20.6% | 23.0% | 17.3% | 19.4% | 21.3% |
| KV Cache on BookSum Dataset |     |     |     |     |     |
| LZ4 | 0.0% | 0.0% | 0.0% | 0.0% | 0.0% |
| ZSTD | 6.5% | 2.9% | 0.9% | 2.0% | 3.8% |

```

</details>

## Assistant · #20

<details><summary>Reasoning · 935 characters</summary>

There's a very relevant paper in resource 82904355 section 21: "The Illusion of Equivalence: Systematic FP16 Divergence in KV-Cached..." — that's highly relevant! Let me open it. Also section 57 "Huawei's KVarN Hits 5x KV-Cache Capacity at FP16 Accuracy" and section 8/12 "Custom Formats" / "Floating-point Quantization" from a survey (may compare FP16 vs BF16 for KV cache).

Let me open section 21 (the Illusion of Equivalence paper) and section 12 (Floating-point Quantization in survey) and section 39 (3.2.3 KV Cache Quantization).

Also I need ikawrakow's reply in issue #1529 — the scrape only got 2 sections and didn't include the comment. The search snippet said "I didn't think you could even BF16 the KV, only F16. ikawrakow ..." from resource 1cc9ba88 section 1. Let me open section 2 of f17d17ac to see if the activity/comments are there.

Let me do parallel: open 82904355 section 21, section 12, and f17d17ac section 2.


</details>

<details><summary>Tool request · context_read · call_7dfb4048335749e48d1cfadc</summary>

```json
{
  "kind": "resource",
  "id": "82904355-43b0-4de0-bf48-86e23c6ee929",
  "section": 21
}
```

</details>

<details><summary>Tool request · context_read · call_859719621bb94511adfeb3a1</summary>

```json
{
  "kind": "resource",
  "id": "82904355-43b0-4de0-bf48-86e23c6ee929",
  "section": 12
}
```

</details>

<details><summary>Tool request · context_read · call_3d555091786b414db5fc9ef9</summary>

```json
{
  "kind": "resource",
  "id": "f17d17ac-3fba-4abf-aaf1-d0878b65f24c",
  "section": 2
}
```

</details>

A paper titled "The Illusion of Equivalence: Systematic FP16 Divergence in KV-Cached…" surfaced. Opening it plus the survey's FP-format section.
<details><summary>Tool result · context_read · call_7dfb4048335749e48d1cfadc</summary>

# Search: arxiv KV cache bf16 fp16 precision comparison mantissa bits long context degradation paper · section 21/67
Subsection: 4. The Illusion of Equivalence: Systematic FP16 Divergence in KV-Cached ...
Tags: table
Images available through view_image:
- https://arxiv.org/icons/licenses/by-4.0.png — license icon

*   Tseng et al. (2024a) Tseng, A., Chee, J., Sun, Q., Kuleshov, V., De Sa, C., 2024a. Quip#: Even better llm quantization with hadamard incoherence and lattice codebooks. arXiv preprint arXiv:2402.04396 .
*   Tseng et al. (2024b) Tseng, A., Sun, Q., Hou, D., De Sa, C., 2024b. Qtip: Quantization with trellises and incoherence processing. arXiv preprint arXiv:2406.11235 .
*   Wang et al. (2023) Wang, H., Ma, S., Dong, L., Huang, S., Wang, H., Ma, L., Yang, F., Wang, R., Wu, Y., Wei, F., 2023. Bitnet: Scaling 1-bit transformers for large language models. arXiv preprint arXiv:2310.11453 .
*   Warren (2012) Warren, H., 2012. Hacker’s Delight. Pearson Education. URL: [https://books.google.com.my/books?id=VicPJYM0I5QC](https://books.google.com.my/books?id=VicPJYM0I5QC)
    . pages 72-73.
*   Wei et al. (2023a) Wei, X., Gong, R., Li, Y., Liu, X., Yu, F., 2023a. Qdrop: Randomly dropping quantization for extremely low-bit post-training quantization. URL: [https://arxiv.org/abs/2203.05740](https://arxiv.org/abs/2203.05740)
    , [arXiv:2203.05740](http://arxiv.org/abs/2203.05740)
    .
*   Wei et al. (2023b) Wei, X., Zhang, Y., Li, Y., Zhang, X., Gong, R., Guo, J., Liu, X., 2023b. Outlier suppression+: Accurate quantization of large language models by equivalent and optimal shifting and scaling. arXiv preprint arXiv:2304.09145 .
*   Wilkes et al. (1958) Wilkes, M.V., Wheeler, D.J., Gill, S., Corbató, F., 1958. The preparation of programs for an electronic digital computer. Reprinted 1984, pages 191–193.
*   Wu et al. (2020) Wu, H., Judd, P., Zhang, X., Isaev, M., Micikevicius, P., 2020. Integer quantization for deep learning inference: Principles and empirical evaluation. URL: [https://arxiv.org/abs/2004.09602](https://arxiv.org/abs/2004.09602)
    , [arXiv:2004.09602](http://arxiv.org/abs/2004.09602)
    .
*   Xi et al. (2024) Xi, H., Chen, Y., Zhao, K., Zheng, K., Chen, J., Zhu, J., 2024. Jetfire: Efficient and accurate transformer pretraining with int8 data flow and per-block quantization. arXiv preprint arXiv:2403.12422 .
*   Xia et al. (2024) Xia, H., Zheng, Z., Wu, X., Chen, S., Yao, Z., Youn, S., Bakhtiari, A., Wyatt, M., Zhuang, D., Zhou, Z., et al., 2024. Fp6-llm: Efficiently serving large language models through fp6-centric algorithm-system co-design. arXiv preprint arXiv:2401.14112 .
*   Xiao et al. (2023) Xiao, G., Lin, J., Seznec, M., Wu, H., Demouth, J., Han, S., 2023. Smoothquant: Accurate and efficient post-training quantization for large language models, in: International Conference on Machine Learning, PMLR. pp. 38087–38099.
*   Xu et al. (2023) Xu, Y., Xie, L., Gu, X., Chen, X., Chang, H., Zhang, H., Chen, Z., Zhang, X., Tian, Q., 2023. Qa-lora: Quantization-aware low-rank adaptation of large language models. arXiv preprint arXiv:2309.14717 .
*   Yang et al. (2024) Yang, J.Y., Kim, B., Bae, J., Kwon, B., Park, G., Yang, E., Kwon, S.J., Lee, D., 2024. No token left behind: Reliable kv cache compression via importance-aware mixed precision quantization. arXiv preprint arXiv:2402.18096 .
*   Yao et al. (2022) Yao, Z., Aminabadi, R.Y., Zhang, M., Wu, X., Li, C., He, Y., 2022. Zeroquant: Efficient and affordable post-training quantization for large-scale transformers. URL: [https://arxiv.org/abs/2206.01861](https://arxiv.org/abs/2206.01861)
    , [arXiv:2206.01861](http://arxiv.org/abs/2206.01861)
    .
*   Yao et al. (2023) Yao, Z., Wu, X., Li, C., Youn, S., He, Y., 2023. Zeroquant-v2: Exploring post-training quantization in llms from comprehensive study to low rank compensation. arXiv preprint arXiv:2303.08302 .
*   Yuan et al. (2023) Yuan, Z., Niu, L., Liu, J., Liu, W., Wang, X., Shang, Y., Sun, G., Wu, Q., Wu, J., Wu, B., 2023. Rptq: Reorder-based post-training quantization for large language models. arXiv preprint arXiv:2304.01089 .
*   Yuan et al. (2024) Yuan, Z., Xue, C., Chen, Y., Wu, Q., Sun, G., 2024. Ptq4vit: Post-training quantization for vision transformers with twin uniform quantization. URL: [https://arxiv.org/abs/2111.12293](https://arxiv.org/abs/2111.12293)
    , [arXiv:2111.12293](http://arxiv.org/abs/2111.12293)
    .
*   Yue et al. (2024) Yue, Y., Yuan, Z., Duanmu, H., Zhou, S., Wu, J., Nie, L., 2024. Wkvquant: Quantizing weight and key/value cache for large language models gains more. arXiv preprint arXiv:2402.12065 .
*   Zhang et al. (2024a) Zhang, C., Cheng, J., Constantinides, G.A., Zhao, Y., 2024a. Lqer: Low-rank quantization error reconstruction for llms. arXiv preprint arXiv:2402.02446 .
*   Zhang et al. (2022) Zhang, S., Roller, S., Goyal, N., Artetxe, M., Chen, M., Chen, S., Dewan, C., Diab, M., Li, X., Lin, X.V., et al., 2022. Opt: Open pre-trained transformer language models. arXiv preprint arXiv:2205.01068 .
*   Zhang et al. (2024b) Zhang, T., Yi, J., Xu, Z., Shrivastava, A., 2024b. Kv cache is 1 bit per channel: Efficient large language model inference with coupled quantization. arXiv preprint arXiv:2405.03917 .
*   Zhang et al. (2024c) Zhang, Y., Yang, F., Peng, S., Wang, F., Pan, A., 2024c. Flattenquant: Breaking through the inference compute-bound for large language models with per-tensor quantization. URL: [https://arxiv.org/abs/2402.17985](https://arxiv.org/abs/2402.17985)
    , [arXiv:2402.17985](http://arxiv.org/abs/2402.17985)
    .
*   Zhang et al. (2024d) Zhang, Y., Zhang, P., Huang, M., Xiang, J., Wang, Y., Wang, C., Zhang, Y., Yu, L., Liu, C., Lin, W., 2024d. Qqq: Quality quattuor-bit quantization for large language models. arXiv preprint arXiv:2406.09904 .
*   Zhang et al. (2024e) Zhang, Y., Zhang, P., Huang, M., Xiang, J., Wang, Y., Wang, C., Zhang, Y., Yu, L., Liu, C., Lin, W., 2024e. Qqq: Quality quattuor-bit quantization for large language models. arXiv preprint arXiv:2406.09904 .
*   Zhang et al. (2024f) Zhang, Z., Jaiswal, A., Yin, L., Liu, S., Zhao, J., Tian, Y., Wang, Z., 2024f. Q-galore: Quantized galore with int4 projection and layer-adaptive low-rank gradients. arXiv preprint arXiv:2407.08296 .
*   Zhang et al. (2024g) Zhang, Z., Zhao, D., Miao, X., Oliaro, G., Li, Q., Jiang, Y., Jia, Z., 2024g. Quantized side tuning: Fast and memory-efficient tuning of quantized large language models. arXiv preprint arXiv:2401.07159 .
*   Zhao et al. (2024) Zhao, Y., Lin, C.Y., Zhu, K., Ye, Z., Chen, L., Zheng, S., Ceze, L., Krishnamurthy, A., Chen, T., Kasikci, B., 2024. Atom: Low-bit quantization for efficient and accurate llm serving. Proceedings of Machine Learning and Systems 6, 196–209.
*   Zhu et al. (2020) Zhu, F., Gong, R., Yu, F., Liu, X., Wang, Y., Li, Z., Yang, X., Yan, J., 2020. Towards unified int8 training for convolutional neural network, in: Proceedings of the IEEE/CVF Conference on Computer Vision and Pattern Recognition, pp. 1969–1979.
*   Zirui Liu et al. (2023) Zirui Liu, Jiayi Yuan, Hongye Jin, Shaochen Zhong, Zhaozhuo Xu, Braverman, V., Beidi Chen, Hu, X., 2023. Kivi : Plug-and-play 2bit kv cache quantization with streaming asymmetric quantization URL: [https://rgdoi.net/10.13140/RG.2.2.28167.37282](https://rgdoi.net/10.13140/RG.2.2.28167.37282)
    , doi:[10.13140/RG.2.2.28167.37282](http://dx.doi.org/10.13140/RG.2.2.28167.37282)
    .

[](javascript:toggleReadingMode(); "Disable reading mode, show header and footer")

---

## 4. The Illusion of Equivalence: Systematic FP16 Divergence in KV-Cached ...

https://arxiv.org/abs/2604.15409

KV caching is a ubiquitous optimization in autoregressive transformer inference, long presumed to be numerically equivalent to cache-free computation. This assumption fails under standard FP16 precision: cache-ON and cache-OFF execution paths employ different floating-point accumulation orderings which, due to FP16 non-associativity, produce a deterministic divergence in decoded token ...

[Skip to main content](https://arxiv.org/abs/2604.15409#content)

Search arXiv   

Press Enter to search · [Advanced search](https://arxiv.org/search/advanced)

Computer Science > Machine Learning
===================================

**arXiv:2604.15409** (cs)

\[Submitted on 16 Apr 2026\]

Title:The Illusion of Equivalence: Systematic FP16 Divergence in KV-Cached Autoregressive Inference
===================================================================================================

Authors:[Ranjith Chodavarapu](https://arxiv.org/search/cs?searchtype=author&query=Chodavarapu,+R)
, [Lei Xu](https://arxiv.org/search/cs?searchtype=author&query=Xu,+L)

View a PDF of the paper titled The Illusion of Equivalence: Systematic FP16 Divergence in KV-Cached Autoregressive Inference, by Ranjith Chodavarapu and Lei Xu

[View PDF](https://arxiv.org/pdf/2604.15409)
 [HTML (experimental)](https://arxiv.org/html/2604.15409v1)

> Abstract:KV caching is a ubiquitous optimization in autoregressive transformer inference, long presumed to be numerically equivalent to cache-free computation. This assumption fails under standard FP16 precision: cache-ON and cache-OFF execution paths employ different floating-point accumulation orderings which, due to FP16 non-associativity, produce a deterministic divergence in decoded token sequences. Across three open-weight models (LLaMA-2-7B, Mistral-7B-v0.3, Gemma-2-2B) evaluated on GSM8K, we observe a 100\\% token divergence rate across all sampling strategies, including greedy decoding, which rules out sampling randomness as a cause, and also with cache-ON yielding higher accuracy in 8 of 9 conditions, where the accuracy difference serves as an indicator that the divergence direction is systematic rather than random. Controlled FP32 falsification reduces divergence by eight orders of magnitude, eliminates token flips, and drops the flip rate to exactly 0.0\\%, confirming FP16 non-associativity as the sole causal driver. Layer-wise drift profiling reveals architecturally predictable propagation patterns: models using Grouped-Query Attention exhibit sharp divergence at the first layer, while Gemma's larger head dimension and sliding window attention produce uniform accumulation across all layers. Finally, activation patching of the entire residual stream fails to recover the cache-free trajectory, localizing the causal variable to the stateful KV cache. These findings establish that FP16 KV cache inference is fundamentally non-equivalent to recomputation and provide a mechanistic framework for understanding numerical instability in modern LLM inference systems.

|     |     |
| --- | --- |
| Subjects: | Machine Learning (cs.LG); Artificial Intelligence (cs.AI) |
| Cite as: | [arXiv:2604.15409](https://arxiv.org/abs/2604.15409)<br> \[cs.LG\] |
|     | (or [arXiv:2604.15409v1](https://arxiv.org/abs/2604.15409v1)<br> \[cs.LG\] for this version) |
|     | [https://doi.org/10.48550/arXiv.2604.15409](https://doi.org/10.48550/arXiv.2604.15409)<br><br>Focus to learn more<br><br>arXiv-issued DOI via DataCite |

Submission history
------------------

From: Ranjith Chodavarapu \[[view email](https://arxiv.org/show-email/9d968b81/2604.15409)\
\]  
**\[v1\]** Thu, 16 Apr 2026 15:59:40 UTC (1,086 KB)  

Full-text links:

Access Paper:
-------------

View a PDF of the paper titled The Illusion of Equivalence: Systematic FP16 Divergence in KV-Cached Autoregressive Inference, by Ranjith Chodavarapu and Lei Xu

*   [View PDF](https://arxiv.org/pdf/2604.15409)
    
*   [HTML (experimental)](https://arxiv.org/html/2604.15409v1)
    
*   [TeX Source](https://arxiv.org/src/2604.15409)
    

 [![license icon](https://arxiv.org/icons/licenses/by-4.0.png) view license](http://creativecommons.org/licenses/by/4.0/ "Rights to this article")

### Current browse context:

cs.LG

[< prev](https://arxiv.org/prevnext?id=2604.15409&function=prev&context=cs.LG "previous in cs.LG (accesskey p)")   |   [next >](https://arxiv.org/prevnext?id=2604.15409&function=next&context=cs.LG "next in cs.LG (accesskey n)")
  

[new](https://arxiv.org/list/cs.LG/new)
 | [recent](https://arxiv.org/list/cs.LG/recent)
 | [2026-04](https://arxiv.org/list/cs.LG/2026-04)

Change to browse by:



</details>

<details><summary>Tool result · context_read · call_859719621bb94511adfeb3a1</summary>

# Search: arxiv KV cache bf16 fp16 precision comparison mantissa bits long context degradation paper · section 12/67
Subsection: Floating-point Quantization
Tags: table

In this section, we roughly categorize the quantization into three types: (1) Floating-point Quantization, casting the high-bit floating-points into low-bit ones. (2) Integer Quantization, which mainly refers to dividing the floating-points into evenly spaced integers. We omit requantizing higher bitwidth integers to lower bitwidth ones here, because it is seldom used in real practices, and few studies propose faster implementations to convert integers. (3) Binarization, including sign and bool functions.

##### Floating-point Quantization

Quantizing higher bitwidth floating-point to lower is actually the clip of mantissa bits. That is because the source value with higher bitwidth usually has more or equal bits for both exponent and mantissa parts compared to the target value with lower bitwidth. Algorithm [1](https://arxiv.org/html/2409.16694v1#alg1 "Algorithm 1 ‣ Floating-point Quantization ‣ 3.2.5 Quantization and Dequantization ‣ 3.2 System Support for Quantization ‣ 3 Frameworks and System Support ‣ A Survey of Low-bit Large Language Models: Basics, Systems, and Algorithms")
 provides an example of quantizing FP32 to FP8. And we follow [Micikevicius et al. (2022)](https://arxiv.org/html/2409.16694v1#bib.bib86)
 to summarize the general process as follows:

(1) Scale. Since the target value occupies less bitwidth, the representation range may shrink drastically, and not be able to convey most of the data. Scaling the source value to a suitable range can best preserve the information after quantized to FP8. The scaling is pre-obtained by learning or calibration.

(2) Check Overflow/Underflow. Check whether the source value overflows FP8 from the upper or lower bound. If so, return the maximum or minimum directly. If it is not overflow, check if the exponent part underflows from the smallest positive normal number that the FP8 can present. If so, we divide the value by the smallest subnormal number in FPxx, round to the nearest integer, and then multiply the smallest subnormal number. The integer determines the value of mantissa bits and the exponent bits are all set to zero.

(3) Copy and Round. If the value is neither overflows nor underflows of FP8, we copy the lower ee bits from the source FP32 value to the target FP8 value. Then we clip the mantissa to mm bits by rounding to the nearest. It is notable that rounding and overflow/underflow handling are both crucial for maintaining numerical stability and precision in real applications. However, since the reduction of mantissa bits, precision degradation is inevitable while converting to lower bitwidth.

Algorithm 1 Quantization to lower-bit floating-point values.

0:  XFP32X\_{\\mathrm{FP}32}, s∈ℝ+s\\in\\mathbb{R^{+}} , X0∈ℝX\_{0}\\in\\mathbb{R}, e,m∈ℤ+e,m\\in\\mathbb{Z^{+}}, c​l​i​pm​i​nclip^{min}, c​l​i​pm​a​xclip^{max}

0:  XFP8X\_{\\mathrm{FP}8}

1:  XFP32u​n​s​c​a​l​e​d\=XFP32/sX\_{\\mathrm{FP32}}^{unscaled}=X\_{\\mathrm{FP32}}/s

2:  em​i​n\=e^{min}= \-(1 << (ee - 1)) + 1

3:  em​a​x\=e^{max}= (1 << (ee - 1))

4:  m\=x−e−1m=x-e-1 // Theoretical maximum of exponent part for FP8

5:  XFP8e\=em​a​x+28−1<<23X\_{\\mathrm{FP}8}^{e}=e^{max}+2^{8-1}<<23 // Theoretical maximum of mantissa part for FP8

6:  XFP8m\={X\_{\\mathrm{FP}8}^{m}}= ~(0x007FFFFF >> mm) & 0x007FFFFF

7:  XFP8t​h​e​o​m​a​x\=XFP8e+XFP8mX\_{\\mathrm{FP}8}^{theomax}=X\_{\\mathrm{FP}8}^{e}+X\_{\\mathrm{FP}8}^{m} // Check exponent overflow

8:  if XFP32u​n​s​c​a​l​e​d\>min⁡(c​l​i​pm​a​x,XFP8t​h​e​o​m​a​x)X\_{\\mathrm{FP32}}^{unscaled}>\\mathrm{min}(clip^{max},X\_{\\mathrm{FP}8}^{theomax}) then

9:    XFP8\=min⁡(c​l​i​pm​a​x,XFP8t​h​e​o​m​a​x)X\_{\\mathrm{FP}8}=\\mathrm{min}(clip^{max},X\_{\\mathrm{FP}8}^{theomax})

10:  else if XFP8t​h​e​o​m​a​x<max⁡(c​l​i​pm​i​n,−XFP8t​h​e​o​m​a​x)X\_{\\mathrm{FP}8}^{theomax}<\\mathrm{max}(clip^{min},-X\_{\\mathrm{FP}8}^{theomax}) then

11:    XFP8\=max⁡(c​l​i​pm​i​n,−XFP8t​h​e​o​m​a​x)X\_{\\mathrm{FP}8}=\\mathrm{max}(clip^{min},-X\_{\\mathrm{FP}8}^{theomax})

12:  else

13:    XFP8s​i​g​n\=XFP32u​n​s​c​a​l​e​dX\_{\\mathrm{FP}8}^{sign}=X\_{\\mathrm{FP32}}^{unscaled} & 0x80000000

14:    XFP8e\=XFP32u​n​s​c​a​l​e​dX\_{\\mathrm{FP}8}^{e}=X\_{\\mathrm{FP32}}^{unscaled} & 0x7F800000

15:    XFP8m\=XFP32u​n​s​c​a​l​e​dX\_{\\mathrm{FP}8}^{m}=X\_{\\mathrm{FP32}}^{unscaled} & 0x007FFFFF // Check exponent underflow

16:    if (XFPxe\>>23)−2x−1<em​i​n+1(X\_{\\mathrm{FPx}}^{e}>>23)-2^{x-1}<e^{min}+1 then

17:     XFP8m​i​n.subnorm{X\_{\\mathrm{FP}8}^{min}}\_{.subnorm} = 1 / (1 << ((1 << (ee - 1)) + mm - 2))

18:     XFPx\=round2int(XFP32u​n​s​c​a​l​e​d/XFP8m​i​n.subnorm)XFP8m​i​n.subnormX\_{\\mathrm{FPx}}=\\texttt{round2int}(X\_{\\mathrm{FP32}}^{unscaled}/{X\_{\\mathrm{FP}8}^{min}}\_{.subnorm}){X\_{\\mathrm{FP}8}^{min}}\_{.subnorm}

19:    end if// Round mantissa

20:    Rm\=(XFP8m​<<​m)R\_{m}=(X\_{\\mathrm{FP}8}^{m}\\texttt{<<}m) & 0x007FFFFF + 0x3F800000

21:    Rm\=round2int​(Rm−1)R\_{m}=\\texttt{round2int}(R\_{m}-1) // Process mantissa

22:    XFP8m\=(XFP8m​\>>​(23−m)CLOSEX\_{\\mathrm{FP}8}^{m}=(X\_{\\mathrm{FP}8}^{m}\\texttt{>>}(23-m) + OPENRm)​<<​(23−m)R\_{m})\\texttt{<<}(23-m)

23:    XFP8\=XFP8s​i​g​n+XFP8e+XFP8mX\_{\\mathrm{FP8}}=X\_{\\mathrm{FP}8}^{sign}+X\_{\\mathrm{FP}8}^{e}+X\_{\\mathrm{FP}8}^{m}

24:  end if

25:  return XFP8X\_{\\mathrm{FP8}}

##### Floating-point Dequantization

Dequantizing floating-point numbers to higher bitwidth is straightforward. In the FP format system, the bitwidth of both the exponent and mantissa bits in lower bitwidth values will not exceed that in higher bitwidth. Therefore, we can directly extract and copy the sign bit, exponent and mantissa from the original value (with fewer bitwidth) to the most significant bits in the corresponding parts of the target value (with more bitwidth). And then we conduct zero filling on the rest bits for the exponent and mantissa parts 2525 25 https://github.com/pytorch/pytorch/blob/main/c10/util/Float8\_fnuz\_cvt.h.

##### Integer Quantization

We first scale the floating-point numbers to the representation span of INT​k\\mathrm{INT}k by dividing the scaling factor s∈ℝ+s\\in\\mathbb{R^{+}}, and adding a zero-point Z∈ℤZ\\in\\mathbb{Z} to shift the clamped range ([Wu et al., 2020](https://arxiv.org/html/2409.16694v1#bib.bib110)
). round⁡(⋅)\\mathrm{round}(\\cdot) is the round-to-the-nearest function, and clamp⁡(⋅,qmin,qmax)\\mathrm{clamp}(\\cdot,q^{\\min},q^{\\max}) restricts values to be within the representation span of kk\-bit with qmin\=−2k−1,qmax\=2k−1−1q^{\\min}=-2^{k-1},q^{\\max}=2^{k-1}-1 in symmetric quantization and qmin\=0,qmax\=2k−1q^{\\min}=0,q^{\\max}=2^{k}-1 in asymmetric quantization. Therefore, the overall quantization formulation can be written as

|     |     |     |     |
| --- | --- | --- | --- |
|     | XINTk\=clamp⁡(round⁡(XFPs)+Z,qmin,qmax),X\_{\\mathrm{INT}\_{k}}=\\mathrm{clamp}\\left(\\mathrm{round}\\left(\\frac{X\_{\\mathrm{FP}}}{s}\\right)+Z,q^{\\min},q^{\\max}\\right), |     | (8) |

where the scaling factor ss can be initialized as s0\=(qmax−qmin)/(XFPmax−XFPmin),s\_{0}=({q^{\\max}-q^{\\min}})/({X\_{\\mathrm{FP}}^{\\max}-X\_{\\mathrm{FP}}^{\\min}}), where XFPmaxX\_{\\mathrm{FP}}^{\\max} and XFPminX\_{\\mathrm{FP}}^{\\min} are the maximum and minimum values.

For system support, many frameworks apply the Marlin quantization 2626 26 https://github.com/IST-DASLab/marlin ([Frantar and Alistarh, 2024](https://arxiv.org/html/2409.16694v1#bib.bib31)
) as the standard process. The pseudocode Algorithm [2](https://arxiv.org/html/2409.16694v1#alg2 "Algorithm 2 ‣ Integer Quantization ‣ 3.2.5 Quantization and Dequantization ‣ 3.2 System Support for Quantization ‣ 3 Frameworks and System Support ‣ A Survey of Low-bit Large Language Models: Basics, Systems, and Algorithms")
 outlines the steps involved in Marlin quantization, and uses 4-bit integer quantization as an example. The values are quantized and stored as unsigned integers with the desired bitwidth. Extra pre/post-shift will be conducted to get the signed values. Therefore, we first scale the XFP32X\_{\\mathrm{FP32}} values by ss and round it to integers. Then, adding 2k−12^{k-1} to shift the values to non-negative integers within the span of uINT4 (4-bit unsigned integer). We omit the detail of C++ built-in datatype casting function float2uint. To be understood, we explain the packing process in lines 4 to 8 by double for loops, which is actually implemented as lines 9 to 11. In 4-bit quantization, every 8 values are packed as a single uINT32, and the quantized matrix size is a quarter of the original. By using ii::8, we abstract every 8 values along CC starting with ii, incrementing by 8, and ending by default (till the end of dimension CC). And then left shifting the values by 4∗i4\*i to place the 4-bit value to the corresponding bit range, and leave 4∗i4\*i zeros on the right, allowing previously-stored quantized values to be preserved after OR operation.

Algorithm 2 Marlin quantization from FP32 to INT4.

0:  XFP32∈ℝT,CX\_{\\mathrm{FP32}}\\in\\mathbb{R}^{T,C}, s∈ℝ+s\\in\\mathbb{R^{+}}

0:  XuINT4X\_{\\mathrm{uINT}4}

1:  XFP32round←round​(XFP32/s​c​a​l​e)X\_{\\mathrm{FP32}}^{\\mathrm{round}}\\leftarrow\\texttt{round}(X\_{\\mathrm{FP32}}/{scale}) // Shift to span of uint4

2:  XFP32clamp←clamp​(XFP32round+23,0,24−1)X\_{\\mathrm{FP32}}^{\\mathrm{clamp}}\\leftarrow\\texttt{clamp}(X\_{\\mathrm{FP32}}^{\\mathrm{round}}+2^{3},0,2^{4}-1)

3:  Xuint32←X\_{\\mathrm{uint32}}\\leftarrow float2uint (XFP32clampX\_{\\mathrm{FP32}}^{\\mathrm{clamp}}) // Pack every 8 Xuint32X\_{\\mathrm{uint32}} to a single uINT32

4:  for k←0k\\leftarrow 0 to C//8 do

5:    for i←0i\\leftarrow 0 to 77 do

6:     XINT4\[:,k\](4∗i+3:4∗i)←Xu​i​n​t​32\[:,i+8∗k\]<<(4∗i)X\_{\\mathrm{INT4}}\[:,k\]\_{(4\*i+3:4\*i)}\\leftarrow X\_{uint32}\[:,i+8\*k\]<<(4\*i)

7:    end for

8:  end for// Line 4∼\\sim8 can also simplify as line 9∼\\sim11 // i::8 creates a sequence starts at ii, increments by 88, and ends by default

9:  for i←0i\\leftarrow 0 to 77 do

10:    XuINT4\[:,:\](:4∗i)←Xuint32\[:,i::8\]<<(4∗i)X\_{\\mathrm{uINT4}}\[:,:\]\_{(:4\*i)}\\leftarrow X\_{\\mathrm{uint32}}\[:,i\\texttt{::}8\]<<(4\*i)

11:  end for

12:  return XuINT4X\_{\\mathrm{uINT4}}

There are several custom algorithms that introduce faster data type conversions. QQQ ([Zhang et al., 2024d](https://arxiv.org/html/2409.16694v1#bib.bib125)
) designs a faster FP16 to INT8 conversion, named FastFP16toINT8. It starts by shifting the FP16 values to the representation span of uINT8 by adding 128. Next, adding an additional 1024 which effectively converts and places the 8 bits of uINT8 into the lower segment of the FP16 mantissa. Finally, the lower 8 bits from FP16 are extracted and applied with an XOR operation with 0x80 to obtain the desired INT8 format. The overall process can be further simplified to FMA, PRMT, and XOR operations in practice.

##### Integer Dequantization

It means projecting the integers back to the real numbers by multiplying the scaling factors, which can be expressed as

|     |     |     |     |
| --- | --- | --- | --- |
|     | X^FP\=s⋅(XINT​x−Z)≈XFP.\\hat{X}\_{\\mathrm{FP}}=s\\cdot(X\_{\\mathrm{INT}x}-Z)\\approx X\_{\\mathrm{FP}}. |     | (9) |

Therefore, in many works ss can also be initialized by searching from candidates to find an optimal ([Wei et al., 2023b](https://arxiv.org/html/2409.16694v1#bib.bib108)
):

|     |     |     |     |     |
| --- | --- | --- | --- | --- |
|     | scandidate\\displaystyle s\_{\\mathrm{candidate}} | \=in​u​mi​s0,i∈ℤ+,i∈(0,n​u​mi)\\displaystyle=\\frac{i}{num\_{i}}s\_{0},\\hskip 9.24994pti\\in\\mathbb{Z^{+}},i\\in(0,num\_{i}) |     | (10) |
|     |     | s.t.min⁡‖XFP−X^FP‖p.\\displaystyle s.t.~\\min\|{X}\_{\\mathrm{FP}}-\\hat{X}\_{\\mathrm{FP}}\|\_{p}. |     | (11) |



</details>

<details><summary>Tool result · context_read · call_3d555091786b414db5fc9ef9</summary>

# Scrape: https://github.com/ikawrakow/ik_llama.cpp/issues/1529 · section 2/2
Subsection: Assignees
Images available through view_image:
- https://avatars.githubusercontent.com/u/59298527?u=56b88957aa38420d208bc6507ff2d5a217b26082&v=4&size=48 — @Ph0rk0z
- https://avatars.githubusercontent.com/u/48489457?u=92c964b8f0eb829cee1c130e4a651e14ee4ea77b&v=4&size=48 — @ikawrakow
- https://avatars.githubusercontent.com/u/48489457?s=64&u=92c964b8f0eb829cee1c130e4a651e14ee4ea77b&v=4 — @ikawrakow
- https://avatars.githubusercontent.com/u/59298527?s=64&u=56b88957aa38420d208bc6507ff2d5a217b26082&v=4 — @Ph0rk0z
- https://github.githubassets.com/assets/github-copilot-app-light-15ad5534265eeacd.svg

1.  ghost added
    
    [enhancementNew feature or request](https://github.com/ikawrakow/ik_llama.cpp/issues?q=state%3Aopen%20label%3A%22enhancement%22)
    New feature or request
    
    [on Mar 27, 2026](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#event-23972764949)
    
2.  ### Ph0rk0z commented on Mar 27, 2026
    
    [![@Ph0rk0z](https://avatars.githubusercontent.com/u/59298527?u=56b88957aa38420d208bc6507ff2d5a217b26082&v=4&size=48)](https://github.com/Ph0rk0z)
    
    [Ph0rk0z](https://github.com/Ph0rk0z)
    
    [on Mar 27, 2026](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#issuecomment-4142960766)
    
    Last edited by Ph0rk0z
    
    Contributor
    
    More actions
    
    We can use Q8 attention here somehow? I know there is GRT but that's not attention. Q8 models have been fine on the lower end like 3xB where I can test both BF16 and Q8. Or the attention weights themselves quantized? Won't they just get upcast?
    
    Some of those speedups like muge and fusion need PPL test done on your particular model to ensure there isn't a problem. In the past high ppl has showed up several times and led to fixes.
    
    For using devstral, I did a test of my settings and PPL didn't do bad even on long contexts, even with Q8 kv. Qwen is a special case where context isn't very heavy so F16 is not as big of a problem but for other models not so much. With AMB I thought it only applied to deepseek style models that use MLA.
    

4.  ### Ph0rk0z commented on Mar 27, 2026
    
    [![@Ph0rk0z](https://avatars.githubusercontent.com/u/59298527?u=56b88957aa38420d208bc6507ff2d5a217b26082&v=4&size=48)](https://github.com/Ph0rk0z)
    
    [Ph0rk0z](https://github.com/Ph0rk0z)
    
    [on Mar 27, 2026](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#issuecomment-4143371961)
    
    Contributor
    
    More actions
    
    AMB was made to shrink compute buffers for MLA models. If you set an AMB and your compute buffer is the same size, assume it didn't work.
    
    The attention weights are usually smaller so if you're worried about precision, it's probably better to leave them alone. I agree that PPL isn't anywhere close to an exact metric, only a ballpark. At least it's a way to see if you will expect negative effects quickly and objectively.
    
    IME, I have tried quantization of all sorts and the APIs. While IQ2\_M isn't "enough", my gains between Q4-Q6-Q8 have been relatively minuscule. Where it mainly showed up for me is longer context or detail retrieval. With logic itself and anything but deterministic sampling, whether the model does it right amounts to a dice roll as much as anything else.
    
    Not only you in the dark, if there was some repeatable way to show the full effects of quants, I think we would have seen it by now. It's not particular to this backend. All is anecdotal reports. At best benchmarks like MMLU, etc. Closest sane comparison is with image and vlm models where you can _see_ the degradation. On Q4 it was always quite a bit, but between Q8/BF16 it was small to nonexistent.
    

6.  ### Ph0rk0z commented on Mar 28, 2026
    
    [![@Ph0rk0z](https://avatars.githubusercontent.com/u/59298527?u=56b88957aa38420d208bc6507ff2d5a217b26082&v=4&size=48)](https://github.com/Ph0rk0z)
    
    [Ph0rk0z](https://github.com/Ph0rk0z)
    
    [on Mar 28, 2026](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#issuecomment-4147899910)
    
    Contributor
    
    More actions
    
    Different architectures will also respond differently. Some models are fine with speedups and smaller KV, some the PPL rises to the sky. You will pretty much ave to test.
    
    I run BF16 GRT because it's not much slower and the numbers are better. Q8 has more t/s but there's quality loss. For KV I usually do Q8. I didn't think you could even BF16 the KV, only F16.
    
7.  ### ikawrakow commented on Mar 29, 2026
    
    [![@ikawrakow](https://avatars.githubusercontent.com/u/48489457?u=92c964b8f0eb829cee1c130e4a651e14ee4ea77b&v=4&size=48)](https://github.com/ikawrakow)
    
    [ikawrakow](https://github.com/ikawrakow)
    
    [on Mar 29, 2026](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#issuecomment-4150585750)
    
    Owner
    
    More actions
    
    I'm not sure what to do with this. To me it looks like many people have strong opinions on these topics, often contrary to my experience or expectation as a developer, so what would be the point of putting down what I think about all of this?
    
8.  ### Ph0rk0z commented on Mar 29, 2026
    
    [![@Ph0rk0z](https://avatars.githubusercontent.com/u/59298527?u=56b88957aa38420d208bc6507ff2d5a217b26082&v=4&size=48)](https://github.com/Ph0rk0z)
    
    [Ph0rk0z](https://github.com/Ph0rk0z)
    
    [on Mar 29, 2026](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#issuecomment-4150592018)
    
    Contributor
    
    More actions
    
    Since you wrote the code, your opinion is likely to be the most correct.
    

13.  ghost closed this as [completed](https://github.com/ikawrakow/ik_llama.cpp/issues?q=is%3Aissue%20state%3Aclosed%20archived%3Afalse%20reason%3Acompleted)
    [on Apr 13, 2026](https://github.com/ikawrakow/ik_llama.cpp/issues/1529#event-24453595967)
    

[Sign up for free](https://github.com/signup?return_to=https://github.com/ikawrakow/ik_llama.cpp/issues/1529)
 **to join this conversation on GitHub.** Already have an account? [Sign in to comment](https://github.com/login?return_to=https://github.com/ikawrakow/ik_llama.cpp/issues/1529)

Metadata
--------

Metadata
--------

### Assignees

No one assigned

### Labels

[enhancementNew feature or request](https://github.com/ikawrakow/ik_llama.cpp/issues?q=state%3Aopen%20label%3A%22enhancement%22)
New feature or request

### Projects

No projects

### Milestone

No milestone

### Relationships

None yet

### Development

No branches or pull requests

### Participants

[![@ikawrakow](https://avatars.githubusercontent.com/u/48489457?s=64&u=92c964b8f0eb829cee1c130e4a651e14ee4ea77b&v=4)](https://github.com/ikawrakow)
[![@Ph0rk0z](https://avatars.githubusercontent.com/u/59298527?s=64&u=56b88957aa38420d208bc6507ff2d5a217b26082&v=4)](https://github.com/Ph0rk0z)

Issue actions
-------------

*   ![](https://github.githubassets.com/assets/github-copilot-app-light-15ad5534265eeacd.svg)Open in GitHub Copilot app

You can’t perform that action at this time.

</details>

## Assistant · #24

<details><summary>Reasoning · 1,065 characters</summary>

Now I have solid primary sources. Let me also check:
1. Whether ik_llama.cpp supports bf16 KV at all (the important engine fact). ik_llama.cpp README lists KV cache types supported. Let me check the ik_llama.cpp README's KV cache section, and also the mainline llama.cpp README's KV cache quantization table (which mentions f16/bf16 support and device support matrix).
2. The mainline llama.cpp PR that added bf16 KV cache support (there was PR #14366? or "ggml: add bf16 KV cache"). Also there's a note about CUDA FA support for bf16.
3. Unsloth docs Qwen3.8-Flash-Next recommended KV cache flags — maybe mentions bf16.
4. Also, importantly: for Qwen3-Next/Flash-Next hybrid models, the DeltaNet recurrent state — is it affected by -ctk/-ctv? There's a known llama.cpp limitation: `-ctk/-ctv` only applies to attention KV; recurrent state stays f32 (or there's `--recurrent-cache`?). Let me search.

Let me also verify the llama.cpp README's KV cache type support matrix (which says bf16 supported on CUDA/Metal/Vulkan/SYCL etc.).

Let me search for these things.


</details>

<details><summary>Tool request · web_search · call_38492febd7654890a1450f3d</summary>

```json
{
  "query": "llama.cpp KV cache quantization support matrix bf16 CUDA Metal Vulkan SYCL table README",
  "limit": 8
}
```

</details>

<details><summary>Tool request · web_search · call_eb7927706be74f848d833dfb</summary>

```json
{
  "query": "Qwen3-Next hybrid DeltaNet recurrent state cache-type-k cache-type-v does not apply f32 llama.cpp",
  "limit": 8
}
```

</details>

<details><summary>Tool request · web_search · call_b0180882c5d3498fa4377fe4</summary>

```json
{
  "query": "ik_llama.cpp KV cache quantization f16 bf16 supported types README \"cache type\"",
  "limit": 8
}
```

</details>

Now let me verify the engine-level facts: bf16 KV support matrices and whether `-ctk/-ctv` even touches this model's DeltaNet state.
<details><summary>Tool result · web_search · call_38492febd7654890a1450f3d</summary>

**Firecrawl · section 1 of 165**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,816 characters · included below
- Section 2 · 9,947 characters · omitted from this copy
- Section 3 · 11,883 characters · omitted from this copy
- Section 4 · 11,814 characters · omitted from this copy
- Section 5 · 11,311 characters · omitted from this copy
- Section 6 · 11,896 characters · omitted from this copy
- Section 7 · 11,321 characters · omitted from this copy
- Section 8 · 11,928 characters · omitted from this copy
- Section 9 · 11,938 characters · omitted from this copy
- Section 10 · 11,974 characters · omitted from this copy
- Section 11 · 11,784 characters · omitted from this copy
- Section 12 · 12,002 characters · omitted from this copy
- Section 13 · 11,676 characters · omitted from this copy
- Section 14 · 11,664 characters · omitted from this copy
- Section 15 · 11,698 characters · omitted from this copy
- Section 16 · 11,312 characters · omitted from this copy
- Section 17 · 6,610 characters · omitted from this copy
- Section 18 · 11,908 characters · omitted from this copy
- Section 19 · 11,915 characters · omitted from this copy
- Section 20 · 11,646 characters · omitted from this copy
- Section 21 · 11,804 characters · omitted from this copy
- Section 22 · 11,973 characters · omitted from this copy
- Section 23 · 11,800 characters · omitted from this copy
- Section 24 · 10,974 characters · omitted from this copy
- Section 25 · 11,670 characters · omitted from this copy
- Section 26 · 8,538 characters · omitted from this copy
- Section 27 · 11,758 characters · omitted from this copy
- Section 28 · 11,999 characters · omitted from this copy
- Section 29 · 11,871 characters · omitted from this copy
- Section 30 · 11,955 characters · omitted from this copy
- Section 31 · 11,993 characters · omitted from this copy
- Section 32 · 11,762 characters · omitted from this copy
- Section 33 · 11,959 characters · omitted from this copy
- Section 34 · 11,979 characters · omitted from this copy
- Section 35 · 11,760 characters · omitted from this copy
- Section 36 · 11,976 characters · omitted from this copy
- Section 37 · 11,974 characters · omitted from this copy
- Section 38 · 11,907 characters · omitted from this copy
- Section 39 · 11,934 characters · omitted from this copy
- Section 40 · 11,872 characters · omitted from this copy
- Section 41 · 11,956 characters · omitted from this copy
- Section 42 · 11,999 characters · omitted from this copy
- Section 43 · 11,972 characters · omitted from this copy
- Section 44 · 11,946 characters · omitted from this copy
- Section 45 · 11,989 characters · omitted from this copy
- Section 46 · 11,955 characters · omitted from this copy
- Section 47 · 11,987 characters · omitted from this copy
- Section 48 · 11,776 characters · omitted from this copy
- Section 49 · 11,977 characters · omitted from this copy
- Section 50 · 11,745 characters · omitted from this copy
- Section 51 · 11,945 characters · omitted from this copy
- Section 52 · 11,877 characters · omitted from this copy
- Section 53 · 11,917 characters · omitted from this copy
- Section 54 · 11,991 characters · omitted from this copy
- Section 55 · 11,947 characters · omitted from this copy
- Section 56 · 11,902 characters · omitted from this copy
- Section 57 · 11,938 characters · omitted from this copy
- Section 58 · 11,726 characters · omitted from this copy
- Section 59 · 11,961 characters · omitted from this copy
- Section 60 · 11,860 characters · omitted from this copy
- Section 61 · 11,816 characters · omitted from this copy
- Section 62 · 11,752 characters · omitted from this copy
- Section 63 · 11,853 characters · omitted from this copy
- Section 64 · 11,971 characters · omitted from this copy
- Section 65 · 11,783 characters · omitted from this copy
- Section 66 · 11,955 characters · omitted from this copy
- Section 67 · 11,953 characters · omitted from this copy
- Section 68 · 11,900 characters · omitted from this copy
- Section 69 · 11,932 characters · omitted from this copy
- Section 70 · 11,751 characters · omitted from this copy
- Section 71 · 11,981 characters · omitted from this copy
- Section 72 · 11,991 characters · omitted from this copy
- Section 73 · 12,001 characters · omitted from this copy
- Section 74 · 11,972 characters · omitted from this copy
- Section 75 · 11,836 characters · omitted from this copy
- Section 76 · 11,877 characters · omitted from this copy
- Section 77 · 11,961 characters · omitted from this copy
- Section 78 · 11,698 characters · omitted from this copy
- Section 79 · 11,949 characters · omitted from this copy
- Section 80 · 9,107 characters · omitted from this copy
- Section 81 · 11,861 characters · omitted from this copy
- Section 82 · 11,998 characters · omitted from this copy
- Section 83 · 11,790 characters · omitted from this copy
- Section 84 · 11,934 characters · omitted from this copy
- Section 85 · 11,775 characters · omitted from this copy
- Section 86 · 11,876 characters · omitted from this copy
- Section 87 · 11,991 characters · omitted from this copy
- Section 88 · 11,263 characters · omitted from this copy
- Section 89 · 11,971 characters · omitted from this copy
- Section 90 · 11,947 characters · omitted from this copy
- Section 91 · 11,929 characters · omitted from this copy
- Section 92 · 12,002 characters · omitted from this copy
- Section 93 · 10,919 characters · omitted from this copy
- Section 94 · 11,965 characters · omitted from this copy
- Section 95 · 11,880 characters · omitted from this copy
- Section 96 · 11,888 characters · omitted from this copy
- Section 97 · 11,677 characters · omitted from this copy
- Section 98 · 11,990 characters · omitted from this copy
- Section 99 · 11,735 characters · omitted from this copy
- Section 100 · 11,852 characters · omitted from this copy
- Section 101 · 11,814 characters · omitted from this copy
- Section 102 · 11,866 characters · omitted from this copy
- Section 103 · 11,830 characters · omitted from this copy
- Section 104 · 11,805 characters · omitted from this copy
- Section 105 · 11,686 characters · omitted from this copy
- Section 106 · 11,852 characters · omitted from this copy
- Section 107 · 11,714 characters · omitted from this copy
- Section 108 · 11,943 characters · omitted from this copy
- Section 109 · 11,985 characters · omitted from this copy
- Section 110 · 11,856 characters · omitted from this copy
- Section 111 · 11,808 characters · omitted from this copy
- Section 112 · 11,887 characters · omitted from this copy
- Section 113 · 11,768 characters · omitted from this copy
- Section 114 · 11,710 characters · omitted from this copy
- Section 115 · 11,742 characters · omitted from this copy
- Section 116 · 11,783 characters · omitted from this copy
- Section 117 · 11,819 characters · omitted from this copy
- Section 118 · 11,700 characters · omitted from this copy
- Section 119 · 11,749 characters · omitted from this copy
- Section 120 · 11,754 characters · omitted from this copy
- Section 121 · 11,948 characters · omitted from this copy
- Section 122 · 11,876 characters · omitted from this copy
- Section 123 · 11,948 characters · omitted from this copy
- Section 124 · 11,709 characters · omitted from this copy
- Section 125 · 11,753 characters · omitted from this copy
- Section 126 · 11,881 characters · omitted from this copy
- Section 127 · 11,960 characters · omitted from this copy
- Section 128 · 11,946 characters · omitted from this copy
- Section 129 · 11,778 characters · omitted from this copy
- Section 130 · 11,654 characters · omitted from this copy
- Section 131 · 11,912 characters · omitted from this copy
- Section 132 · 11,802 characters · omitted from this copy
- Section 133 · 12,000 characters · omitted from this copy
- Section 134 · 11,907 characters · omitted from this copy
- Section 135 · 11,728 characters · omitted from this copy
- Section 136 · 11,764 characters · omitted from this copy
- Section 137 · 11,715 characters · omitted from this copy
- Section 138 · 11,954 characters · omitted from this copy
- Section 139 · 11,688 characters · omitted from this copy
- Section 140 · 11,857 characters · omitted from this copy
- Section 141 · 11,761 characters · omitted from this copy
- Section 142 · 11,718 characters · omitted from this copy
- Section 143 · 11,803 characters · omitted from this copy
- Section 144 · 11,713 characters · omitted from this copy
- Section 145 · 11,804 characters · omitted from this copy
- Section 146 · 11,755 characters · omitted from this copy
- Section 147 · 11,897 characters · omitted from this copy
- Section 148 · 11,995 characters · omitted from this copy
- Section 149 · 11,839 characters · omitted from this copy
- Section 150 · 11,847 characters · omitted from this copy
- Section 151 · 11,988 characters · omitted from this copy
- Section 152 · 11,839 characters · omitted from this copy
- Section 153 · 11,791 characters · omitted from this copy
- Section 154 · 11,990 characters · omitted from this copy
- Section 155 · 11,899 characters · omitted from this copy
- Section 156 · 11,766 characters · omitted from this copy
- Section 157 · 11,803 characters · omitted from this copy
- Section 158 · 11,916 characters · omitted from this copy
- Section 159 · 11,862 characters · omitted from this copy
- Section 160 · 11,914 characters · omitted from this copy
- Section 161 · 11,965 characters · omitted from this copy
- Section 162 · 11,943 characters · omitted from this copy
- Section 163 · 11,708 characters · omitted from this copy
- Section 164 · 11,991 characters · omitted from this copy
- Section 165 · 6,834 characters · omitted from this copy

```text
## 1. llama_cpp/CHANGELOG.md at main - GitHub

https://github.com/shamitv/llama_cpp/blob/main/CHANGELOG.md

ggml-org/llama.cpp#17795 improved performance in the single GPU setting on CUDA, but it was rolled back due to a bug surfacing in multi-GPU pipeline parallel ...

[Skip to content](https://github.com/shamitv/llama_cpp/blob/main/CHANGELOG.md#start-of-content)
              

You signed in with another tab or window. [Reload](https://github.com/shamitv/llama_cpp/blob/main/CHANGELOG.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/shamitv/llama_cpp/blob/main/CHANGELOG.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/shamitv/llama_cpp/blob/main/CHANGELOG.md)
 to refresh your session. Dismiss alert

          

[](https://github.com/shamitv/llama_cpp)

FilesExpand file tree


-----------------------

main

/

CHANGELOG.md
============

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/shamitv/llama_cpp/commits/main/CHANGELOG.md)

[](https://github.com/shamitv/llama_cpp/commits/main/CHANGELOG.md)
History

6243 lines (5487 loc) · 499 KB

main

/

CHANGELOG.md
============

Copy path

Top

File metadata and controls
--------------------------

*   Preview
    
*   Code
    
*   Blame
    

6243 lines (5487 loc) · 499 KB

[Raw](https://github.com/shamitv/llama_cpp/raw/refs/heads/main/CHANGELOG.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

You can’t perform that action at this time.

---

## 2. llama.cpp fork with TurboQuant WHT-rotated KV cache & weight ...

https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant

TurboQuant KV cache & weights: WHT-rotated low-bit quantization with backend-native kernels (Metal TurboFlash , CUDA, Vulkan, HIP). Use -ctk turbo3 -ctv ...

[Skip to content](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant#start-of-content)
              

You signed in with another tab or window. [Reload](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant)
 to refresh your session. Dismiss alert

           [](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant)

dev

[Branches](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/branches)
[Tags](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tags)

[](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/branches)
[](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tags)

Go to file

Code

Open more actions menu

Latest commit
-------------

History
-------

[11,423 Commits](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/commits/dev/)

[](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/commits/dev/)
11,423 Commits

Folders and files
-----------------

| Name |     | Name | Last commit message | Last commit date |
| --- | --- | --- | --- |
| [.devops](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/.devops ".devops") |     | [.devops](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/.devops ".devops") |     |     |
| [.gemini](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/.gemini ".gemini") |     | [.gemini](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/.gemini ".gemini") |     |     |
| [.github](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/.github ".github") |     | [.github](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/.github ".github") |     |     |
| [.pi/gg](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/.pi/gg "This path skips through empty directories") |     | [.pi/gg](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/.pi/gg "This path skips through empty directories") |     |     |
| [app](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/app "app") |     | [app](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/app "app") |     |     |
| [benches](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/benches "benches") |     | [benches](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/benches "benches") |     |     |
| [benchmarks](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/benchmarks "benchmarks") |     | [benchmarks](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/benchmarks "benchmarks") |     |     |
| [ci](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/ci "ci") |     | [ci](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/ci "ci") |     |     |
| [cmake](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/cmake "cmake") |     | [cmake](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/cmake "cmake") |     |     |
| [common](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/common "common") |     | [common](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/common "common") |     |     |
| [conversion](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/conversion "conversion") |     | [conversion](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/conversion "conversion") |     |     |
| [docs](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/docs "docs") |     | [docs](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/docs "docs") |     |     |
| [examples](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/examples "examples") |     | [examples](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/examples "examples") |     |     |
| [ggml](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/ggml "ggml") |     | [ggml](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/ggml "ggml") |     |     |
| [gguf-py](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/gguf-py "gguf-py") |     | [gguf-py](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/gguf-py "gguf-py") |     |     |
| [grammars](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/grammars "grammars") |     | [grammars](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/grammars "grammars") |     |     |
| [include](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/include "include") |     | [include](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/include "include") |     |     |
| [licenses](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/licenses "licenses") |     | [licenses](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/licenses "licenses") |     |     |
| [media](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/media "media") |     | [media](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/media "media") |     |     |
| [models](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/models "models") |     | [models](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/models "models") |     |     |
| [pocs](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/pocs "pocs") |     | [pocs](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/pocs "pocs") |     |     |
| [requirements](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/requirements "requirements") |     | [requirements](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/requirements "requirements") |     |     |
| [scripts](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/scripts "scripts") |     | [scripts](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/scripts "scripts") |     |     |
| [skills](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/skills "skills") |     | [skills](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/skills "skills") |     |     |
| [src](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/src "src") |     | [src](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/src "src") |     |     |
| [tests](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/tests "tests") |     | [tests](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/tests "tests") |     |     |
| [tools](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/tools "tools") |     | [tools](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/tools "tools") |     |     |
| [vendor](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/vendor "vendor") |     | [vendor](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/tree/dev/vendor "vendor") |     |     |
| [.clang-format](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.clang-format ".clang-format") |     | [.clang-format](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.clang-format ".clang-format") |     |     |
| [.clang-tidy](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.clang-tidy ".clang-tidy") |     | [.clang-tidy](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.clang-tidy ".clang-tidy") |     |     |
| [.dockerignore](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.dockerignore ".dockerignore") |     | [.dockerignore](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.dockerignore ".dockerignore") |     |     |
| [.ecrc](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.ecrc ".ecrc") |     | [.ecrc](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.ecrc ".ecrc") |     |     |
| [.editorconfig](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.editorconfig ".editorconfig") |     | [.editorconfig](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.editorconfig ".editorconfig") |     |     |
| [.flake8](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.flake8 ".flake8") |     | [.flake8](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.flake8 ".flake8") |     |     |
| [.gitignore](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.gitignore ".gitignore") |     | [.gitignore](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.gitignore ".gitignore") |     |     |
| [.gitmodules](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.gitmodules ".gitmodules") |     | [.gitmodules](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.gitmodules ".gitmodules") |     |     |
| [.pre-commit-config.yaml](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.pre-commit-config.yaml ".pre-commit-config.yaml") |     | [.pre-commit-config.yaml](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/.pre-commit-config.yaml ".pre-commit-config.yaml") |     |     |
| [AGENTS.md](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/AGENTS.md "AGENTS.md") |     | [AGENTS.md](https://github.com/AtomicBot-ai/atomic-llama-cpp-turboquant/blob/dev/AGENTS.md "AGENTS.md") |     |     |
```

</details>

<details><summary>Tool result · web_search · call_eb7927706be74f848d833dfb</summary>

**Firecrawl · section 1 of 81**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,930 characters · included below
- Section 2 · 11,821 characters · omitted from this copy
- Section 3 · 11,780 characters · omitted from this copy
- Section 4 · 11,995 characters · omitted from this copy
- Section 5 · 11,962 characters · omitted from this copy
- Section 6 · 11,906 characters · omitted from this copy
- Section 7 · 10,707 characters · omitted from this copy
- Section 8 · 11,884 characters · omitted from this copy
- Section 9 · 11,855 characters · omitted from this copy
- Section 10 · 12,000 characters · omitted from this copy
- Section 11 · 11,210 characters · omitted from this copy
- Section 12 · 9,281 characters · omitted from this copy
- Section 13 · 11,094 characters · omitted from this copy
- Section 14 · 11,850 characters · omitted from this copy
- Section 15 · 11,969 characters · omitted from this copy
- Section 16 · 9,719 characters · omitted from this copy
- Section 17 · 10,838 characters · omitted from this copy
- Section 18 · 11,957 characters · omitted from this copy
- Section 19 · 11,931 characters · omitted from this copy
- Section 20 · 11,869 characters · omitted from this copy
- Section 21 · 11,996 characters · omitted from this copy
- Section 22 · 11,965 characters · omitted from this copy
- Section 23 · 8,603 characters · omitted from this copy
- Section 24 · 8,609 characters · omitted from this copy
- Section 25 · 9,600 characters · omitted from this copy
- Section 26 · 10,153 characters · omitted from this copy
- Section 27 · 7,842 characters · omitted from this copy
- Section 28 · 8,715 characters · omitted from this copy
- Section 29 · 11,671 characters · omitted from this copy
- Section 30 · 11,474 characters · omitted from this copy
- Section 31 · 11,941 characters · omitted from this copy
- Section 32 · 9,788 characters · omitted from this copy
- Section 33 · 11,987 characters · omitted from this copy
- Section 34 · 8,566 characters · omitted from this copy
- Section 35 · 11,961 characters · omitted from this copy
- Section 36 · 11,909 characters · omitted from this copy
- Section 37 · 11,977 characters · omitted from this copy
- Section 38 · 11,978 characters · omitted from this copy
- Section 39 · 11,847 characters · omitted from this copy
- Section 40 · 11,934 characters · omitted from this copy
- Section 41 · 11,671 characters · omitted from this copy
- Section 42 · 11,976 characters · omitted from this copy
- Section 43 · 11,936 characters · omitted from this copy
- Section 44 · 11,978 characters · omitted from this copy
- Section 45 · 11,966 characters · omitted from this copy
- Section 46 · 11,608 characters · omitted from this copy
- Section 47 · 11,723 characters · omitted from this copy
- Section 48 · 11,997 characters · omitted from this copy
- Section 49 · 11,840 characters · omitted from this copy
- Section 50 · 11,992 characters · omitted from this copy
- Section 51 · 11,953 characters · omitted from this copy
- Section 52 · 11,863 characters · omitted from this copy
- Section 53 · 11,945 characters · omitted from this copy
- Section 54 · 11,985 characters · omitted from this copy
- Section 55 · 11,851 characters · omitted from this copy
- Section 56 · 11,974 characters · omitted from this copy
- Section 57 · 11,947 characters · omitted from this copy
- Section 58 · 11,885 characters · omitted from this copy
- Section 59 · 11,893 characters · omitted from this copy
- Section 60 · 11,893 characters · omitted from this copy
- Section 61 · 11,854 characters · omitted from this copy
- Section 62 · 11,893 characters · omitted from this copy
- Section 63 · 11,893 characters · omitted from this copy
- Section 64 · 11,932 characters · omitted from this copy
- Section 65 · 11,982 characters · omitted from this copy
- Section 66 · 11,941 characters · omitted from this copy
- Section 67 · 11,944 characters · omitted from this copy
- Section 68 · 11,694 characters · omitted from this copy
- Section 69 · 10,102 characters · omitted from this copy
- Section 70 · 10,428 characters · omitted from this copy
- Section 71 · 10,453 characters · omitted from this copy
- Section 72 · 11,285 characters · omitted from this copy
- Section 73 · 11,681 characters · omitted from this copy
- Section 74 · 11,863 characters · omitted from this copy
- Section 75 · 11,980 characters · omitted from this copy
- Section 76 · 10,881 characters · omitted from this copy
- Section 77 · 11,997 characters · omitted from this copy
- Section 78 · 11,845 characters · omitted from this copy
- Section 79 · 11,976 characters · omitted from this copy
- Section 80 · 11,953 characters · omitted from this copy
- Section 81 · 9,409 characters · omitted from this copy

````text
## 1. Misc. bug: --cache-ram -1 is not "no limit": the token cap stays at ...

https://github.com/ggml-org/llama.cpp/issues/29324

Sep 23, 2026 ... llama-server -m Qwen3.8-27B-A.gguf --jinja --parallel 1 --kv-unified --ctx-size 196608 --kv-unified-per-slot 196608 --cache-type-k q8_0 ...

[Skip to content](https://github.com/ggml-org/llama.cpp/issues/29324#start-of-content)
           

You signed in with another tab or window. [Reload](https://github.com/ggml-org/llama.cpp/issues/29324)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/ggml-org/llama.cpp/issues/29324)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/ggml-org/llama.cpp/issues/29324)
 to refresh your session. Dismiss alert

                                                                                                                               [](https://github.com/ggml-org/llama.cpp)

Misc. bug: Misc. bug: --cache-ram -1 is not "no limit": the token cap stays at n\_ctx, and with hybrid models RAM grows ~640 MiB per short prompt #29324
========================================================================================================================================================

[New issue](https://github.com/login?return_to=https://github.com/ggml-org/llama.cpp/issues/29324)

Copy link

[New issue](https://github.com/login?return_to=https://github.com/ggml-org/llama.cpp/issues/29324)

Copy link

Open

Open

[Misc. bug: Misc. bug: --cache-ram -1 is not "no limit": the token cap stays at n\_ctx, and with hybrid models RAM grows ~640 MiB per short prompt](https://github.com/ggml-org/llama.cpp/issues/29324#top)
#29324

Copy link

Labels

[bug-unconfirmed](https://github.com/ggml-org/llama.cpp/issues?q=state%3Aopen%20label%3A%22bug-unconfirmed%22)
[stale](https://github.com/ggml-org/llama.cpp/issues?q=state%3Aopen%20label%3A%22stale%22)

Description
-----------

[![@komar174](https://avatars.githubusercontent.com/u/201070683?v=4&size=48)](https://github.com/komar174)

[komar174](https://github.com/komar174)

opened [on Sep 23, 2026](https://github.com/ggml-org/llama.cpp/issues/29324#issue-5556241412)

Issue body actions

### Name and Version

version: 0.4.1-dev (build 11064, commit [a894dae](https://github.com/ggml-org/llama.cpp/commit/a894dae939d426954ce54bb604824f1ae918a0c5)
)  
built with Clang 20.1.8 for Windows x86\_64

### Operating systems

Windows

### Which llama.cpp modules do you know to be affected?

llama-server, Documentation/Github

### Command line

```shell
llama-server -m Qwen3.8-27B-A.gguf --jinja --parallel 1 --kv-unified --ctx-size 196608 --kv-unified-per-slot 196608 --cache-type-k q8_0 --cache-type-v q8_0 --flash-attn auto --n-gpu-layers 99 --cache-idle-slots --cache-ram -1
workaround in use now: --cache-ram 24576
```

### Problem description & steps to reproduce

Hardware: RTX 5090 32 GB, CUDA 13.4 build, Windows 11, 96 GB RAM. Model: Qwen3.8-27B (hybrid `qwen35`, Gated DeltaNet).

What the code does

*   `server_prompt_cache(limit_size_mib, limit_tokens)` maps `-1` to `limit_size = 0` (no byte limit); `limit_tokens` is always `n_ctx`.
*   `server_prompt_cache::update()`: `limit_tokens_cur = limit_size > 0 ? max(limit_tokens, limit_size/size_per_token) : limit_tokens`. With `-1` the token cap stays at `n_ctx` and never grows; with a positive `--cache-ram` it can.

So `-1`, documented as "no limit", is the only setting where the token cap cannot grow — and it does not bound memory at all.

Why memory still explodes with hybrid/recurrent models

Every saved state carries the recurrent state (~300 MiB here) regardless of prompt length, and every context checkpoint adds about the same again.

Steps to reproduce: start the server with the command line above and send 100 distinct ~1.2k-token prompts one after another, sampling the process private bytes after each. With `--cache-ram -1` each new prompt adds ~640 MiB, linearly (+27.5 GiB after 44 prompts, still growing). With `--cache-ram 24576` the same run plateaus at +23.4 GiB and the log shows `making room for prompt cache entry`.

In production (knowledge-graph extraction: many short prompts) the worker reached 99.7 GiB private bytes on a 96 GiB machine (about 28 GiB of that is the loaded model's own commit on Windows; the cache itself was ~70 GiB). The page file grew to its maximum and Windows raised two "low virtual memory" events. Meanwhile the cache saved only ~4 minutes of prefill over ~36 hours on that workload.

Suggestions

1.  Document that `-1` keeps an `n_ctx` token cap and does not bound memory.
2.  For recurrent/hybrid models, account for the fixed per-entry state (and checkpoints) in the cap, or warn when `-1` is used with such models.
3.  Consider the byte limit as the primary bound; the token cap is a poor proxy when per-entry overhead dominates.

### First Bad Commit

Not bisected. server\_prompt\_cache::update() and alloc() are the same on master as of 2026-09-23.

### Relevant log output

\--cache-ram -1: evictions happen only on the n\_ctx token cap; entries are 300-850 MiB each  
W srv update: - cache token limit (196608, est: 196608) reached, removing oldest entry (size = 845.108 MiB)  
W srv update: - cache token limit (196608, est: 196608) reached, removing oldest entry (size = 301.047 MiB)

probe: 100 distinct ~1.2k-token prompts, growth of worker private bytes over the loaded-model baseline  
\--cache-ram -1 : 10 -> +6.2 GiB, 20 -> +12.5, 30 -> +18.7, 40 -> +25.0, stopped at 44 -> +27.5 (linear)  
\--cache-ram 24576 : 10 -> +6.2 GiB, 20 -> +12.5, 30 -> +18.7, 40..90 -> +23.4 (plateau)  
W srv alloc: - making room for prompt cache entry, removing oldest entry (size = 637.944 MiB)

Activity
--------

1.  [![](https://avatars.githubusercontent.com/u/201070683?s=64&v=4)komar174](https://github.com/komar174)
    
    added
    
    [bug-unconfirmed](https://github.com/ggml-org/llama.cpp/issues?q=state%3Aopen%20label%3A%22bug-unconfirmed%22)
    
    [on Sep 23, 2026](https://github.com/ggml-org/llama.cpp/issues/29324#event-31691437679)
    
2.  ### mitoyosh commented on Sep 24, 2026
    
    [![@mitoyosh](https://avatars.githubusercontent.com/u/284016890?v=4&size=48)](https://github.com/mitoyosh)
    
    [mitoyosh](https://github.com/mitoyosh)
    
    [on Sep 24, 2026](https://github.com/ggml-org/llama.cpp/issues/29324#issuecomment-5807202076)
    
    More actions
    
    Reproduced on master `930e2fa` (CPU, Linux), on both a dense and a hybrid model. The dense side is worth adding because it shows `-1` is not only unbounded in memory but also keeps _less_ than the default.
    
    **Where it comes from** (`tools/server`):
    
    ```c
    // server-context.cpp:1359 — token limit is n_ctx
    prompt_cache = std::make_unique<server_prompt_cache>(params_base.cache_ram_mib, n_ctx);
    // server-task.h:614 — -1 becomes byte limit 0 = "none"
    this->limit_size = 1024ull*1024ull*(limit_size_mib < 0 ? 0 : limit_size_mib);
    // server-task.cpp:1883 — the token limit is only raised when the byte limit is positive
    const size_t limit_tokens_cur = limit_size > 0 ? std::max<size_t>(limit_tokens, limit_size/size_per_token) : limit_tokens;
    ```
    
    (`size_per_token` is `max(1, size()/n_tokens())`, so with an empty cache a positive limit gives a huge token cap immediately — there is no warm-up window where the two settings behave alike.)
    
    **Dense** — `gemma-3-1b-it-Q4_K_M`, `-c 4096 -np 1`, 16 distinct 590–840-token prompts to `/completion` with `cache_prompt: true`, then prompt 1 re-sent:
    
        default 8192 MiB   evictions 0    resend prompt 1: prompt_n 5,   cache_n 593
        --cache-ram -1     evictions 12   resend prompt 1: prompt_n 598, cache_n 0
                           cache token limit (4096, est: 4096) reached, removing oldest entry (size = 26.119 MiB)
        
    
    **Hybrid** — `Qwen3.5-0.8B-Q8_0` (`qwen35`), `-c 32768`, 60 distinct ~140-token prompts, server RSS every 15 requests:
    
        --cache-ram -1     1284 → 1887 → 2490 → 3093 → 3697 MiB   (linear, ~40 MiB per entry, 0 evictions)
        --cache-ram 256    1284 → 1589 → 1585 → 1592 → 1590 MiB   (alloc: making room for prompt cache entry … size = 39.824 MiB)
        
    
    So on a hybrid model `-1` bounds entries only by `n_ctx / prompt_len`, and each entry carries the fixed recurrent state regardless of prompt length (40 MiB for 140 tokens here, vs ~26 MiB for 600 tokens on the dense model).
    
    If `-1` is meant to be "no limit", the smallest change consistent with the help text seems to be treating it as "no byte limit _and_ no token limit" in `update()` (skip the token loop when `limit_size_mib < 0`), and documenting that it is genuinely unbounded. If the `n_ctx` token cap is intentional as a safety net, then the help text for `-1` is the thing to change, since as written it describes the opposite of what dense-model users get.
    
    Script, logs, and a detection check for running servers: [https://homelabpostmortem.com/2026/09/24/llama-server-cache-ram-minus-one-is-not-no-limit/](https://homelabpostmortem.com/2026/09/24/llama-server-cache-ram-minus-one-is-not-no-limit/)
    
3.  ### komar174 commented on Sep 24, 2026
    
    [![@komar174](https://avatars.githubusercontent.com/u/201070683?v=4&size=48)](https://github.com/komar174)
    
    [komar174](https://github.com/komar174)
    
    [on Sep 24, 2026](https://github.com/ggml-org/llama.cpp/issues/29324#issuecomment-5808133918)
    
    Author
    
    More actions
    
    [@mitoyosh](https://github.com/mitoyosh)
     thanks for the independent reproduction on Linux/CPU. The dense-model result (-1 keeping less than the default 8192) is a good catch; I had only tested the hybrid case.
    
    On the fix: please don't make -1 skip the token cap as well. On hybrid/recurrent models that turns it into a truly unbounded cache, which is exactly what took this machine to ~70 GiB of cache on 96 GiB of RAM. A positive --cache-ram was the only setting that bounded memory in both of our reproductions. I'd rather see the help text describe what -1 actually does, plus a warning when -1 is used with a recurrent/hybrid model.
    
4.  ### mitoyosh commented on Sep 25, 2026
    
    [![@mitoyosh](https://avatars.githubusercontent.com/u/284016890?v=4&size=48)](https://github.com/mitoyosh)
    
    [mitoyosh](https://github.com/mitoyosh)
    
    [on Sep 25, 2026](https://github.com/ggml-org/llama.cpp/issues/29324#issuecomment-5824692083)
    
    More actions
    
    Agreed — the first option I listed is the wrong one. Making `-1` drop the token cap would turn the hybrid case from "bounded by `n_ctx / prompt_len` entries" into genuinely unbounded, and your 70 GiB is what that looks like with a cap still in place. Of the settings either of us tested, only a positive `--cache-ram` bounded memory on both model types.
    
    So: help text that says what `-1` does (no byte limit; the cache is capped at `n_ctx` tokens in total, which on a dense model is usually less than the default 8192 MiB holds), and a startup warning when `-1` is combined with a recurrent/hybrid architecture — `llm_arch_is_recurrent() || llm_arch_is_hybrid()` is already available at the point where `server_prompt_cache` is constructed.
    
5.  ### 159753a52 commented on Sep 30, 2026
    
    [![@159753a52](https://avatars.githubusercontent.com/u/137481623?u=a7a409468e72a266a9ada5833c74c55d978ac081&v=4&size=48)](https://github.com/159753a52)
    
    [159753a52](https://github.com/159753a52)
    
    [on Sep 30, 2026](https://github.com/ggml-org/llama.cpp/issues/29324#issuecomment-5902150681)
    
    Last edited by taronaeo
    
    More actions
    
    Some arithmetic that lines your numbers up with the model's config (Qwen3.8-27B, `linear_*` fields of its config.json), in case it helps size the warning or the cap.
    
````

</details>

<details><summary>Tool result · web_search · call_b0180882c5d3498fa4377fe4</summary>

**Firecrawl · section 1 of 96**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,792 characters · included below
- Section 2 · 11,998 characters · omitted from this copy
- Section 3 · 8,905 characters · omitted from this copy
- Section 4 · 9,399 characters · omitted from this copy
- Section 5 · 9,797 characters · omitted from this copy
- Section 6 · 7,904 characters · omitted from this copy
- Section 7 · 7,678 characters · omitted from this copy
- Section 8 · 7,399 characters · omitted from this copy
- Section 9 · 8,744 characters · omitted from this copy
- Section 10 · 8,440 characters · omitted from this copy
- Section 11 · 11,943 characters · omitted from this copy
- Section 12 · 11,123 characters · omitted from this copy
- Section 13 · 11,947 characters · omitted from this copy
- Section 14 · 11,810 characters · omitted from this copy
- Section 15 · 11,956 characters · omitted from this copy
- Section 16 · 11,999 characters · omitted from this copy
- Section 17 · 12,001 characters · omitted from this copy
- Section 18 · 11,932 characters · omitted from this copy
- Section 19 · 11,979 characters · omitted from this copy
- Section 20 · 11,958 characters · omitted from this copy
- Section 21 · 11,964 characters · omitted from this copy
- Section 22 · 11,987 characters · omitted from this copy
- Section 23 · 11,901 characters · omitted from this copy
- Section 24 · 11,998 characters · omitted from this copy
- Section 25 · 11,978 characters · omitted from this copy
- Section 26 · 11,957 characters · omitted from this copy
- Section 27 · 11,976 characters · omitted from this copy
- Section 28 · 12,001 characters · omitted from this copy
- Section 29 · 11,970 characters · omitted from this copy
- Section 30 · 11,966 characters · omitted from this copy
- Section 31 · 11,976 characters · omitted from this copy
- Section 32 · 11,994 characters · omitted from this copy
- Section 33 · 11,548 characters · omitted from this copy
- Section 34 · 11,047 characters · omitted from this copy
- Section 35 · 11,993 characters · omitted from this copy
- Section 36 · 11,997 characters · omitted from this copy
- Section 37 · 11,711 characters · omitted from this copy
- Section 38 · 11,915 characters · omitted from this copy
- Section 39 · 11,727 characters · omitted from this copy
- Section 40 · 10,244 characters · omitted from this copy
- Section 41 · 11,921 characters · omitted from this copy
- Section 42 · 11,883 characters · omitted from this copy
- Section 43 · 11,937 characters · omitted from this copy
- Section 44 · 11,946 characters · omitted from this copy
- Section 45 · 11,953 characters · omitted from this copy
- Section 46 · 11,609 characters · omitted from this copy
- Section 47 · 11,841 characters · omitted from this copy
- Section 48 · 11,901 characters · omitted from this copy
- Section 49 · 11,834 characters · omitted from this copy
- Section 50 · 9,537 characters · omitted from this copy
- Section 51 · 11,659 characters · omitted from this copy
- Section 52 · 11,727 characters · omitted from this copy
- Section 53 · 7,593 characters · omitted from this copy
- Section 54 · 11,979 characters · omitted from this copy
- Section 55 · 11,965 characters · omitted from this copy
- Section 56 · 11,714 characters · omitted from this copy
- Section 57 · 11,925 characters · omitted from this copy
- Section 58 · 11,969 characters · omitted from this copy
- Section 59 · 11,969 characters · omitted from this copy
- Section 60 · 11,969 characters · omitted from this copy
- Section 61 · 11,980 characters · omitted from this copy
- Section 62 · 11,970 characters · omitted from this copy
- Section 63 · 11,964 characters · omitted from this copy
- Section 64 · 11,823 characters · omitted from this copy
- Section 65 · 11,540 characters · omitted from this copy
- Section 66 · 11,972 characters · omitted from this copy
- Section 67 · 11,935 characters · omitted from this copy
- Section 68 · 11,860 characters · omitted from this copy
- Section 69 · 11,999 characters · omitted from this copy
- Section 70 · 11,996 characters · omitted from this copy
- Section 71 · 11,943 characters · omitted from this copy
- Section 72 · 11,882 characters · omitted from this copy
- Section 73 · 11,664 characters · omitted from this copy
- Section 74 · 11,983 characters · omitted from this copy
- Section 75 · 11,942 characters · omitted from this copy
- Section 76 · 11,994 characters · omitted from this copy
- Section 77 · 11,961 characters · omitted from this copy
- Section 78 · 11,913 characters · omitted from this copy
- Section 79 · 9,890 characters · omitted from this copy
- Section 80 · 11,974 characters · omitted from this copy
- Section 81 · 11,873 characters · omitted from this copy
- Section 82 · 11,945 characters · omitted from this copy
- Section 83 · 11,987 characters · omitted from this copy
- Section 84 · 11,934 characters · omitted from this copy
- Section 85 · 11,965 characters · omitted from this copy
- Section 86 · 11,968 characters · omitted from this copy
- Section 87 · 11,986 characters · omitted from this copy
- Section 88 · 11,848 characters · omitted from this copy
- Section 89 · 11,672 characters · omitted from this copy
- Section 90 · 11,776 characters · omitted from this copy
- Section 91 · 11,727 characters · omitted from this copy
- Section 92 · 11,887 characters · omitted from this copy
- Section 93 · 11,962 characters · omitted from this copy
- Section 94 · 11,651 characters · omitted from this copy
- Section 95 · 11,932 characters · omitted from this copy
- Section 96 · 10,760 characters · omitted from this copy

````text
## 1. Quick-start Guide coming over from llama.cpp and ktransformers! #258

https://github.com/ikawrakow/ik_llama.cpp/discussions/258

May 13, 2025 ... ... support without downloading another quant!!! # KV Cache Quantization # https://github.com/ikawrakow/ik_llama.cpp/pull/208 # https://github ...

[Skip to content](https://github.com/ikawrakow/ik_llama.cpp/discussions/258#start-of-content)
              

You signed in with another tab or window. [Reload](https://github.com/ikawrakow/ik_llama.cpp/discussions/258)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/ikawrakow/ik_llama.cpp/discussions/258)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/ikawrakow/ik_llama.cpp/discussions/258)
 to refresh your session. Dismiss alert

                       Quick-start Guide coming over from llama.cpp and ktransformers! #258
====================================================================

[ubergarm](https://github.com/ubergarm)
 started this conversation in [General](https://github.com/ikawrakow/ik_llama.cpp/discussions/categories/general)

[Quick-start Guide coming over from llama.cpp and ktransformers!](https://github.com/ikawrakow/ik_llama.cpp/discussions/258#top)
 #258

 [![@ubergarm](https://avatars.githubusercontent.com/u/4724321?s=40&v=4) ubergarm](https://github.com/ubergarm)

Mar 14, 2025 · 31 comments · 162 replies

[Return to top](https://github.com/ikawrakow/ik_llama.cpp/discussions/258#top)

Discussion options

### Uh oh!

There was an error while loading. [Please reload this page](https://github.com/ikawrakow/ik_llama.cpp/discussions/258)
.

Quote reply

edited

### Uh oh!

There was an error while loading. [Please reload this page](https://github.com/ikawrakow/ik_llama.cpp/discussions/258)
.

[![](https://avatars.githubusercontent.com/u/4724321?s=64&v=4)\
\
ubergarm](https://github.com/ubergarm)
[Mar 14, 2025](https://github.com/ikawrakow/ik_llama.cpp/discussions/258#discussion-8084285)




---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

`ik_llama.cpp`
==============

_Last Updated_: Tue May 13 03:52:20 PM EDT 2025 (still needs more updates, can't keep up, check through comments below)

_NEW_: Two new custom quants great for CPU+GPU or CPU only inferencing fitting 32k+ context in under 24GB VRAM [here on huggingface ubergarm/DeepSeek-V3-0324-GGUF](https://huggingface.co/ubergarm/DeepSeek-V3-0324-GGUF)
! or start out with the quant you already have to kick the tires on ik\_llama.cpp.

tl;dr;
------

`ik_llama.cpp` is a custom fork of llama.cpp introducing many interesting optimizations for MoE's like DeepSeek-R1 671B.

The new SOTA quant types can repack your existing GGUFs on the fly or you can roll your own to maximize quality and speed for your exact system VRAM and RAM availability.

I highly recommend you give `ik_llama.cpp` a try especially for CUDA+CPU or pure CPU inferencing. All the very similar ergonmics as vanilla `llama-server` that you already know and love.

*   64k context in under 24GB VRAM with over 15 tok/sec on a ThreadRipper Pro 24x core with 256GB RAM with single GPU.
*   Gaming rig 9950X + 96GB RAM + 3090TI 24GB VRAM + NVMe for over 4 toks/sec!
*   Fastest available implementation for DeepSeek-R1 671B on pure CPU dual socket Intel 6890P in my testing.

Install
-------

```shell
# Install build dependencies and cuda toolkit as needed

# Clone
git clone https://github.com/ikawrakow/ik_llama.cpp
cd ik_llama.cpp

# Configure CUDA+CPU Backend
cmake -B ./build -DGGML_CUDA=ON -DGGML_BLAS=OFF

# *or* Configure CPU Only Backend
cmake -B ./build -DGGML_CUDA=OFF -DGGML_BLAS=OFF

# Build
cmake --build ./build --config Release -j $(nproc)

# Confirm
./build/bin/llama-server --version
version: 3597 (68a5b604)
```

Features
--------

```shell
# Flash MLA & FlashMLA-2 & Flash Attention
# https://github.com/ikawrakow/ik_llama.cpp/pull/240
# https://github.com/ikawrakow/ik_llama.cpp/pull/253
#  -fa, --flash-attn <0|1>  (default: 0) # (for both CPU and CUDA)
#  -mla, --mla-attn <0|1|2|3> (default: 0) # -mla 1 for CPU only, -mla 2 for both CPU and CUDA, -mla 3 for CPU only
# *NOTE*: for llama-bench use `-fa 1`
# *UPDATE*: you can use `-mla 3` now for CPU+GPU with new PR
# tl;dr; generally use -mla 2 for CPU+GPU and use -mla 3 for CPU assuming your model architecture supports MLA
-mla 2 -fa

## On-the-Fly MLA Tensors
# To run existing R1 671B quants that are missing MLA tensors *without* the need to roll your own
# https://github.com/ikawrakow/ik_llama.cpp/pull/259
# This means you can run your existing unsloth quants with full FlashMLA-2 support without downloading another quant!!!

# KV Cache Quantization
# https://github.com/ikawrakow/ik_llama.cpp/pull/208
# https://github.com/ikawrakow/ik_llama.cpp/pull/240#issue-2890555894
#  -ctk,  --cache-type-k TYPE      KV cache data type for K (default: f16)
#  -ctv,  --cache-type-v TYPE      KV cache data type for V (default: f16)
-ctk q8_0

# Re-Use K*Q tensor compute buffer specify size
# (for both CPU and CUDA)
# https://github.com/ikawrakow/ik_llama.cpp/pull/237
# (i = Size in MiB)
# -amb, --attn-max-batch <i> (default: 0)
-amb 512 # 512 MiB compute buffer is a good for DeepSeek-R1 671B on a single <24GB VRAM GPU

# Fused MoE
# (For CUDA and maybe CPU when not using computing an imatrix?)
# https://github.com/ikawrakow/ik_llama.cpp/pull/229
# -fmoe, --fused-moe <0|1> (default: 0)
# *NOTE*: for llama-bench use `-fmoe 1`
-fmoe

# Override Model Tensor Buffers
# (For CUDA or possibly RPC or other GPU backends)
# https://github.com/ikawrakow/ik_llama.cpp/pull/232
# -ot, --override-tensor pattern (default: none)
# *NOTE*: this now works with `mmap()` so run models too big for your RAM!
-ot exps=CPU -ngl 99 # put the MoE experts on CPU and the rest in GPU for max speed on lowish VRAM
# if you  have multiple GPUs, this can get confusing, so take your time and start small and craft a regex for your setup

# Smart Expert Reduction
# https://github.com/ikawrakow/ik_llama.cpp/pull/239
# -ser, --smart-expert-reduction <i,f> (default: 0)
-ser 7,1 # or 6,1 or 5,1 for faster trading off quality for speed

# Run Time Repack
# Repack quants for improved performance for certain quants and hardware configs
# this disables mmap so need enough RAM to malloc all repacked quants (so pre-pack it yourself ahead of time with llama-quantize)
# (Optimize speed for repacked tensors on some CPUs - is good to use with hybrid GPU + CPU)
# https://github.com/ikawrakow/ik_llama.cpp/pull/147
# -rtr, --run-time-repack <0|1> (default: 0)
-rtr

# Offline Repacking Existing Quants
# Maximize quality, size, and speed
# Selecting quants for each tensor appropriate to your hybrid CPU/GPU configuration
# Remember repacked quants e.g. ending with `_R4` won't *run* on CUDA just sit there like expensive "RAM".
# https://github.com/ikawrakow/ik_llama.cpp/pull/274

# SoTA non-linear Quants with good CPU performance
# https://github.com/ikawrakow/ik_llama.cpp/pull/85
# ./bin/llama-quantize --help | grep non-linear
# Choose the repacked variants for CPU inferencing
# e.g. IQ2_K_R4 and friends for CPU tensors

# Supports both Explicit and Transparent Hugepages
# https://github.com/ikawrakow/ik_llama.cpp/pull/278#issuecomment-2746381515
# Pre-allocate Hugepages of 2MiB or 1GiB size to hold model weights
# or
# Configure system-wide THP support and confirm they are in use
```

Quick Start
-----------

#### Existing DeepSeek-R1 671B GGUF

Get 64k context with a single 24GB VRAM GPU using your existing unsloth quants like [unsloth/DeepSeek-R1-UD-Q2-K\_XL](https://huggingface.co/unsloth/DeepSeek-R1-GGUF/tree/main/DeepSeek-R1-UD-Q2_K_XL)
!

    # CUDA GPU + CPU
    # *NOTE*: This works on 68a5b604 but regression after that see GH ISSUE #271.
    # *NOTE*: set --threads to number of physical cores
    ./build/bin/llama-server \
        --alias unsloth/DeepSeek-R1-Q2_K_R4 \
        --model /mnt/raid/models/unsloth/DeepSeek-R1-GGUF/DeepSeek-R1-UD-Q2_K_XL/DeepSeek-R1-UD-Q2_K_XL-00001-of-00005.gguf \
        -rtr \
        --ctx-size 65536 \
        -ctk q8_0 \
        -mla 2 -fa \
        -amb 512 \
        -fmoe \
        --n-gpu-layers 63 \
        --override-tensor exps=CPU \
        --parallel 1 \
        --threads 24 \
        --host 127.0.0.1 \
        --port 8080
    .
    .
    .
    llama_model_loader: - type  f32:  361 tensors
    llama_model_loader: - type q2_K:  171 tensors
    llama_model_loader: - type q3_K:    3 tensors
    llama_model_loader: - type q4_K:  306 tensors
    llama_model_loader: - type q6_K:  184 tensors
    .
    .
    .
    llm_load_tensors: offloading 61 repeating layers to GPU
    llm_load_tensors: offloading non-repeating layers to GPU
    llm_load_tensors: offloaded 62/62 layers to GPU
    llm_load_tensors:        CPU buffer size = 205716.00 MiB
    llm_load_tensors:  CUDA_Host buffer size =   497.11 MiB
    llm_load_tensors:      CUDA0 buffer size =  9885.95 MiB
    ....................................................................................................
    ============ llm_load_tensors: need to compute 61 wk_b tensors
    Computed blk.0.attn_v_b.weight as 128 x 512 x 128 and stored in buffer CUDA0
    Computed blk.1.attn_v_b.weight as 128 x 512 x 128 and stored in buffer CUDA0
    Computed blk.2.attn_v_b.weight as 128 x 512 x 128 and stored in buffer CUDA0
    .
    .
    .
    Computed blk.58.attn_v_b.weight as 128 x 512 x 128 and stored in buffer CUDA0
    Computed blk.59.attn_v_b.weight as 128 x 512 x 128 and stored in buffer CUDA0
    Computed blk.60.attn_v_b.weight as 128 x 512 x 128 and stored in buffer CUDA0
    ============ Repacked 174 tensors
    llama_new_context_with_model: n_ctx      = 65536
    llama_new_context_with_model: n_batch    = 2048
    llama_new_context_with_model: n_ubatch   = 512
    llama_new_context_with_model: flash_attn = 1
    llama_new_context_with_model: mla_attn   = 2
    llama_new_context_with_model: attn_max_b = 512
    llama_new_context_with_model: fused_moe  = 1
    llama_new_context_with_model: ser        = -1, 0
    llama_new_context_with_model: freq_base  = 10000.0
    llama_new_context_with_model: freq_scale = 0.025
    .
    .
    .
    llama_kv_cache_init:      CUDA0 KV buffer size =  2333.28 MiB
    llama_new_context_with_model: KV self size  = 2333.25 MiB, c^KV (q8_0): 2333.25 MiB, kv^T: not used
    llama_new_context_with_model:  CUDA_Host  output buffer size =     0.99 MiB
    llama_new_context_with_model:      CUDA0 compute buffer size =  6081.00 MiB
    llama_new_context_with_model:  CUDA_Host compute buffer size =   240.01 MiB
    llama_new_context_with_model: graph nodes  = 13613
    llama_new_context_with_model: graph splits = 118
    .
    .
    .
    INFO [           print_timings] prompt eval time     =    2078.89 ms /   190 tokens (   10.94 ms per token,    91.40 tokens per second) | tid="134221729001472" timestamp=1742422435 id_slot=0 id_task=753 t_prompt_processing=2078.885 n_prompt_tokens_processed=190 t_token=10.941500000000001 n_tokens_second=91.39514691769867
    INFO [           print_timings] generation eval time =  107381.01 ms /  1557 runs   (   68.97 ms per token,    14.50 tokens per second) | tid="134221729001472" timestamp=1742422435 id_slot=0 id_task=753 t_token_generation=107381.013 n_decoded=1557 t_token=68.96661078998073 n_tokens_second=14.499770085052186
    INFO [           print_timings]           total time =  109459.90 ms | tid="134221729001472" timestamp=1742422435 id_slot=0 id_task=753 t_prompt_processing=2078.885 t_token_generation=107381.013 t_total=109459.898
    

#### Custom Quant

````

</details>

## Assistant · #28

<details><summary>Reasoning · 931 characters</summary>

I have enough to give a solid answer, but let me nail down two remaining things:

1. The mainline llama.cpp official docs on KV cache quantization (docs/ or README) — is bf16 documented? The sotaaz post says accepted values include bf16 with default f16. There's also the llama.cpp PR that added bf16 KV cache support: "ggml: add support for bf16 KV cache" — let me find it, since that's the engine-level source for "when does bf16 help / hurt".

2. The Myric/Qwen3.8-Flash-Next-APEX-GGUF perplexity table (resource bdf89502 section 3) — might include KV cache settings comparisons for this specific model. Let me check that.

3. Also check whether there's a Qwen3.8-Flash-Next-specific comparison of f16 vs bf16 KV. Let me search Reddit/HF for "Qwen3.8-Flash-Next" "bf16" kv cache.

Let me also check unsloth docs section 15 (Run Qwen3.8-Flash-Next) in resource 5c9eea3d for recommended KV settings.

Let me do these in parallel.


</details>

<details><summary>Tool request · context_read · call_2b15297af8184224bee50aa8</summary>

```json
{
  "kind": "resource",
  "id": "bdf89502-3a91-43ee-bf6b-17a1f5896786",
  "section": 3
}
```

</details>

<details><summary>Tool request · web_search · call_192d66d1e83b4b0a9b21164e</summary>

```json
{
  "query": "llama.cpp pull request add bf16 KV cache support ggml cuda flash attention cache-type-k bf16",
  "limit": 8
}
```

</details>

Two more checks: the APEX perplexity table for this exact model, and the upstream PR that introduced bf16 KV.
<details><summary>Tool result · context_read · call_2b15297af8184224bee50aa8</summary>

# Search: Qwen3-Next hybrid DeltaNet recurrent state cache-type-k cache-type-v does not apply f32 llama.cpp · section 3/81
Subsection: [](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#perplexity)
Tags: table

|     | result |
| --- | --- |
| tasks solved | **9 of 9** |
| individual tests passed | **154 of 154** |
| tasks lost to harness limits (timeout or output cap) | **none** |
| mean output tokens per task | 4,429 |
| total wall time | 0.53 h |

Per task: backtracking\_regex 59 of 59 tests (5,552 output tokens), btree\_insert\_delete 14 of 14 (23,361), lru\_ttl\_cache 12 of 12 (1,724), mini\_sql\_executor 14 of 14 (1,911), or\_set\_crdt 9 of 9 (1,616), rate\_limiter\_fix\_and\_extend 8 of 8 (1,738), tiered\_rate\_limiter 6 of 6 (1,115), txn\_kv\_store 12 of 12 (1,557), weighted\_interval\_scheduling 8 of 8 (1,284).

A clean sweep on this tier is a floor rather than a ranking: the suite is built so that a competent coder clears it, and once it saturates the discriminating measurement is output tokens at equal score, which needs several runs per configuration. This is one run.

### [](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#perplexity)
Perplexity

**Not quoted here yet.** A wikitext-2 run on this box returned 4.2801 +/- 0.02495 (`--ctx-size 2048 --chunks 145 --seed 1234`), but the corpus file used has sha256 `aca2f467...` and is not the canonical `wikitext-2-raw-v1` release artifact (`173c87a5...`). `n_chunk` is a function of tokenised byte count, so a different copy of the corpus changes the divisor; the figure is therefore not comparable to perplexities published for other builds of this model, and is left out rather than shown next to them. It will be restored once measured against the release artifact.

[](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#what-middle-actually-contains)
What MIDDLE actually contains
-------------------------------------------------------------------------------------------------------------------------

Measured by reading the published file's tensor index — 1224 tensors, 176.944 B parameters, 91,655,638,816 bytes, **4.144 bpw**.

| tensors | params | type |
| --- | --- | --- |
| `per_layer_token_embd` (1) | 51.200 B | Q4\_0 |
| `ffn_down_exps` (48) | 40.265 B | Q4\_0 |
| `ffn_gate_exps` + `ffn_up_exps` (96) | 80.531 B | IQ4\_XS (40) · IQ3\_XXS (56) |
| attention, dense FFN, shared experts, `ssm_out`, `attn_gate` | 3.646 B | Q6\_K · Q8\_0 · F32 |
| `token_embd`, `output` (2) | 1.272 B | Q6\_K |
| `ssm_alpha` / `ssm_beta` (72) | 0.009 B | Q6\_K |
| `indexer.q_proj` / `indexer.k_proj` (24) | 0.020 B | BF16 |

The two big Q4\_0 blocks are not a recipe preference — see the shape constraint below.

[](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#not-included-the-mtp-head)
Not included: the MTP head
------------------------------------------------------------------------------------------------------------------

**MIDDLE and BF16 are backbone-only.** Two blocks of the 180.000 B are absent:

|     | params | where it went |
| --- | --- | --- |
| vision tower | 0.449 B | the `mmproj` file above |
| **MTP head** | **2.607 B** | **dropped — in neither file** |

That leaves 176.944 B. The MTP head is a 1-layer multi-token-prediction block for speculative decoding; the converter sets `supports_mtp_export = False` for this architecture and discards its 31 tensors **silently** — no warning appears in the conversion log. `--mtp` is refused outright (`--mtp / --no-nextn are not supported for Qwen4ExpForConditionalGeneration`). The closed [PR #27739](https://github.com/ggml-org/llama.cpp/pull/27739)
 implemented both the export and the runtime graph, and its author deferred to #27742 with the intent that the useful parts be reconciled — so this is a scope cut, not a limitation of the format.

**If you need the MTP head, or full-model reproducibility, start from the original safetensors, not from these files.**

[](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#notes-for-quantizers)
Notes for quantizers
-------------------------------------------------------------------------------------------------------

Two tensor shapes make this model awkward, and both are shape properties that a name-based recipe will not notice:

*   `ffn_down_exps` rows are **640** wide (`moe_intermediate_size`), and
*   `per_layer_token_embd` rows are **160** wide.

Neither is divisible by 256, so K-quants and every 256-block I-quant (`IQ4_XS`, `IQ3_XXS`, `IQ2_S`, …) are illegal on them and silently fall back to 32-block types. That is **91.5 B of 176.9 B params — 51.7% of the file — with a floor near 4.5 bpw**, which flattens the size/quality curve fast: pushing the remaining gate/up experts down to `IQ2_XXS` moves the total only from ~112 GB to ~77 GB. The expert gate/up tensors are unaffected (their rows are 2560 wide), which is why the recipe above can band them at IQ4\_XS/IQ3\_XXS.

`per_layer_token_embd` is a 51.2 B-param sparse lookup table — only a few rows are read per token — and at `Q4_0` it is 28.8 GB, roughly a third of the file.

On a **discrete-GPU** system it is worth keeping in host RAM with `-ot "per_layer_token_embd=CPU"`, since host memory is a separate and usually larger pool and the access pattern is cheap over PCIe.

On a **unified-memory** system (DGX Spark / GB10, Apple silicon) that does nothing: CPU and GPU share one pool, so there is nowhere to offload _to_. Budget the full file size as the footprint there, plus KV cache and compute buffers.

[](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#provenance)
Provenance
-----------------------------------------------------------------------------------

*   Source: `Qwen/Qwen3.8-Flash-Next` safetensors, 144 files, 360.0 GB, all verified byte-exact against the Hub after download.
*   Converter: `convert_hf_to_gguf.py` from PR #27742, `--outtype bf16`, with one extra fix needed to convert this model at all (see the compatibility section).
*   MIDDLE was quantized against an importance matrix carrying 926 entries over 4,000 calibration chunks.
*   Unofficial community conversion — **not affiliated with or endorsed by Qwen.** Provided as-is, without warranty.

Downloads last month

574

GGUF[](https://huggingface.co/docs/hub/gguf)

Model size

177B params

Architecture

qwen4exp

Chat template

Hardware compatibility

[Log In](https://huggingface.co/login?next=https%3A%2F%2Fhuggingface.co%2FMyric%2FQwen3.8-Flash-Next-APEX-GGUF)
 to add your hardware

16-bit

BF16

354 GB

[View +1 variant](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF/tree/main)

Inference Providers [NEW](https://huggingface.co/docs/inference-providers)

[Text Generation](https://huggingface.co/tasks/text-generation "Learn more about text-generation")

This model isn't deployed by any Inference Provider. [🙋 Ask for provider support](https://huggingface.co/spaces/huggingface/InferenceSupport/discussions/new?title=Myric/Qwen3.8-Flash-Next-APEX-GGUF&description=React%20to%20this%20comment%20with%20an%20emoji%20to%20vote%20for%20%5BMyric%2FQwen3.8-Flash-Next-APEX-GGUF%5D(%2FMyric%2FQwen3.8-Flash-Next-APEX-GGUF)%20to%20be%20supported%20by%20Inference%20Providers.%0A%0A(optional)%20Which%20providers%20are%20you%20interested%20in%3F%20(Novita%2C%20Hyperbolic%2C%20Together%E2%80%A6)%0A)

Model tree for Myric/Qwen3.8-Flash-Next-APEX-GGUF[](https://huggingface.co/docs/hub/model-cards#specifying-a-base-model)

-------------------------------------------------------------------------------------------------------------------------

Base model

[Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)

Quantized

([652](https://huggingface.co/models?other=base_model:quantized:Qwen/Qwen3.8-Flash-Next)
)

this model

Inference providers allow you to run inference using different serverless providers.

---

## 3. Eval bug: Qwen 3.6 27B forcing full prompt re-processing due to lack ...

https://github.com/ggml-org/llama.cpp/issues/22746?timeline_page=1

May 5, 2026 ... Name and Version PS D:\llm\llama-b8977-bin-win-hip-radeon-x64> .\llama-cli --version HIP Library Path: C:\WINDOWS\SYSTEM32\amdhip64_7.dll ...

[Skip to content](https://github.com/ggml-org/llama.cpp/issues/22746?timeline_page=1#start-of-content)
           

You signed in with another tab or window. [Reload](https://github.com/ggml-org/llama.cpp/issues/22746?timeline_page=1)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/ggml-org/llama.cpp/issues/22746?timeline_page=1)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/ggml-org/llama.cpp/issues/22746?timeline_page=1)
 to refresh your session. Dismiss alert

                

You can’t perform that action at this time.

---

## 4. llama-cpp-pydist · PyPI

https://pypi.org/project/llama-cpp-pydist/

A model quantized to any other type — the whole K-quant and IQ family — silently falls back to the generic ggml CPU kernels, regardless of which CPU backend ...

[Skip to main content](https://pypi.org/project/llama-cpp-pydist/#content)
 Switch to mobile version

Search PyPI  Search

llama-cpp-pydist 0.94.0
=======================

A Python package for Llama CPP.

pip install llama-cpp-pydist Copy PIP instructions

Llama CPP[](https://pypi.org/project/llama-cpp-pydist/#user-content-llama-cpp)

===============================================================================

This is a Python package for Llama CPP ( [https://github.com/ggml-org/llama.cpp](https://github.com/ggml-org/llama.cpp)
 ).

Installation[](https://pypi.org/project/llama-cpp-pydist/#user-content-installation)

-------------------------------------------------------------------------------------

You can install the pre-built wheel from the releases page or build it from source.

pip install llama-cpp-pydist

Usage[](https://pypi.org/project/llama-cpp-pydist/#user-content-usage)

-----------------------------------------------------------------------

This section provides a basic overview of how to use the `llama_cpp_pydist` library.

### Deploying Windows Binaries[](https://pypi.org/project/llama-cpp-pydist/#user-content-deploying-windows-binaries)

If you are on Windows, the package attempts to automatically deploy pre-compiled binaries. You can also manually trigger this process.

from llama\_cpp import deploy\_windows\_binary

\# Specify the target directory for the binaries
\# This is typically within your Python environment's site-packages
\# or a custom location if you prefer.
target\_dir \= "./my\_llama\_cpp\_binaries" 

if deploy\_windows\_binary(target\_dir):
    print(f"Windows binaries deployed successfully to {target\_dir}")
else:
    print(f"Failed to deploy Windows binaries or no binaries were found for your system.")

\# Once deployed, you would typically add the directory containing llama.dll (or similar)
\# to your system's PATH or ensure your application can find it.
\# For example, if llama.dll is in target\_dir/bin:
\# import os
\# os.environ\["PATH"\] += os.pathsep + os.path.join(target\_dir, "bin")

Conversion Library Installation[](https://pypi.org/project/llama-cpp-pydist/#user-content-conversion-library-installation)

---------------------------------------------------------------------------------------------------------------------------

To perform Hugging Face to GGUF model conversions, you need to install additional Python libraries. You can install them via pip:

pip install transformers numpy torch safetensors sentencepiece

Alternatively, you can install them programmatically in Python:

from llama\_cpp.install\_conversion\_libs import install\_conversion\_libs

if install\_conversion\_libs():
    print("Conversion libraries installed successfully.")
else:
    print("Failed to install conversion libraries.")

### Converting Hugging Face Models to GGUF[](https://pypi.org/project/llama-cpp-pydist/#user-content-converting-hugging-face-models-to-gguf)



</details>

<details><summary>Tool result · web_search · call_192d66d1e83b4b0a9b21164e</summary>

**Firecrawl · section 1 of 44**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,964 characters · included below
- Section 2 · 8,950 characters · omitted from this copy
- Section 3 · 11,891 characters · omitted from this copy
- Section 4 · 11,896 characters · omitted from this copy
- Section 5 · 11,714 characters · omitted from this copy
- Section 6 · 11,389 characters · omitted from this copy
- Section 7 · 11,961 characters · omitted from this copy
- Section 8 · 9,923 characters · omitted from this copy
- Section 9 · 11,933 characters · omitted from this copy
- Section 10 · 11,942 characters · omitted from this copy
- Section 11 · 11,928 characters · omitted from this copy
- Section 12 · 11,956 characters · omitted from this copy
- Section 13 · 11,668 characters · omitted from this copy
- Section 14 · 11,832 characters · omitted from this copy
- Section 15 · 11,956 characters · omitted from this copy
- Section 16 · 11,414 characters · omitted from this copy
- Section 17 · 11,905 characters · omitted from this copy
- Section 18 · 11,929 characters · omitted from this copy
- Section 19 · 11,998 characters · omitted from this copy
- Section 20 · 11,923 characters · omitted from this copy
- Section 21 · 11,220 characters · omitted from this copy
- Section 22 · 11,973 characters · omitted from this copy
- Section 23 · 11,927 characters · omitted from this copy
- Section 24 · 11,821 characters · omitted from this copy
- Section 25 · 11,995 characters · omitted from this copy
- Section 26 · 11,994 characters · omitted from this copy
- Section 27 · 11,867 characters · omitted from this copy
- Section 28 · 11,842 characters · omitted from this copy
- Section 29 · 11,918 characters · omitted from this copy
- Section 30 · 11,686 characters · omitted from this copy
- Section 31 · 11,690 characters · omitted from this copy
- Section 32 · 12,000 characters · omitted from this copy
- Section 33 · 11,957 characters · omitted from this copy
- Section 34 · 11,900 characters · omitted from this copy
- Section 35 · 11,972 characters · omitted from this copy
- Section 36 · 11,495 characters · omitted from this copy
- Section 37 · 11,919 characters · omitted from this copy
- Section 38 · 11,986 characters · omitted from this copy
- Section 39 · 11,516 characters · omitted from this copy
- Section 40 · 11,942 characters · omitted from this copy
- Section 41 · 11,958 characters · omitted from this copy
- Section 42 · 11,943 characters · omitted from this copy
- Section 43 · 11,736 characters · omitted from this copy
- Section 44 · 7,456 characters · omitted from this copy

```text
## 1. llama.cpp/tools/server/README.md at master · ggml-org ... - GitHub

https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md?ref=hackernoon.com

3 days ago ... -ctk, --cache-type-k TYPE, KV cache data type for K allowed values: f32, f16, bf16, f8_e4m3, q8_0, q4_0, q4_1, iq4_nl, q5_0, q5_1 (default ...

[Skip to content](https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md?ref=hackernoon.com#start-of-content)
              

You signed in with another tab or window. [Reload](https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md?ref=hackernoon.com)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md?ref=hackernoon.com)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md?ref=hackernoon.com)
 to refresh your session. Dismiss alert

          

[](https://github.com/ggml-org/llama.cpp)

FilesExpand file tree


-----------------------

master

/

README.md
=========

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/ggml-org/llama.cpp/commits/master/tools/server/README.md)

[](https://github.com/ggml-org/llama.cpp/commits/master/tools/server/README.md)
History

2662 lines (2063 loc) · 138 KB

master

/

README.md
=========

Copy path

Top

File metadata and controls
--------------------------

*   Preview
    
*   Code
    
*   Blame
    

2662 lines (2063 loc) · 138 KB

[Raw](https://github.com/ggml-org/llama.cpp/raw/refs/heads/master/tools/server/README.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

LLaMA.cpp HTTP Server
=====================

[](https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md?ref=hackernoon.com#llamacpp-http-server)

Fast, lightweight, pure C/C++ HTTP server based on [httplib](https://github.com/yhirose/cpp-httplib)
, [nlohmann::json](https://github.com/nlohmann/json)
 and **llama.cpp**.

Set of LLM REST APIs and Llama Chat, a built-in chat app, to interact with llama.cpp.

**Features:**

*   LLM inference of F16 and quantized models on GPU and CPU
*   [OpenAI API](https://github.com/openai/openai-openapi)
     compatible chat completions, responses, and embeddings routes
*   [Anthropic Messages API](https://docs.anthropic.com/en/api/messages)
     compatible chat completions
*   Reranking endpoint ([#9510](https://github.com/ggml-org/llama.cpp/pull/9510)
    )
*   Parallel decoding with multi-user support
*   Continuous batching
*   Multimodal ([documentation](https://github.com/ggml-org/llama.cpp/blob/master/docs/multimodal.md)
    ) / with OpenAI-compatible API support
*   Monitoring endpoints
*   Schema-constrained JSON response format
*   Prefilling of assistant messages similar to the Claude API
*   [Function calling](https://github.com/ggml-org/llama.cpp/blob/master/docs/function-calling.md)
     / tool use for ~any model
*   Speculative decoding
*   Llama Chat, an easy-to-use built-in chat app

For the full list of features, please refer to [server's changelog](https://github.com/ggml-org/llama.cpp/issues/9291)

Usage
-----

[](https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md?ref=hackernoon.com#usage)

### Common params

[](https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md?ref=hackernoon.com#common-params)

| Argument | Explanation |
| --- | --- |
| `-h, --help, --usage` | print usage and exit |
| `--version` | show version and build info |
| `-cl, --cache-list` | show list of models in cache |
| `--completion-bash` | print source-able bash completion script for llama.cpp |
| `-t, --threads N` | number of CPU threads to use during generation (default: -1)  <br>(env: LLAMA\_ARG\_THREADS) |
| `-tb, --threads-batch N` | number of threads to use during batch and prompt processing (default: same as --threads) |
| `-C, --cpu-mask M` | CPU affinity mask: arbitrarily long hex. Complements cpu-range (default: "") |
| `-Cr, --cpu-range lo-hi` | range of CPUs for affinity. Complements --cpu-mask |
| `--cpu-strict <0\|1>` | use strict CPU placement (default: 0) |
| `--prio N` | set process/thread priority : low(-1), normal(0), medium(1), high(2), realtime(3) (default: 0) |
| `--poll <0...100>` | use polling level to wait for work (0 - no polling, default: 50) |
| `-Cb, --cpu-mask-batch M` | CPU affinity mask: arbitrarily long hex. Complements cpu-range-batch (default: same as --cpu-mask) |
| `-Crb, --cpu-range-batch lo-hi` | ranges of CPUs for affinity. Complements --cpu-mask-batch |
| `--cpu-strict-batch <0\|1>` | use strict CPU placement (default: same as --cpu-strict) |
| `--prio-batch N` | set process/thread priority : 0-normal, 1-medium, 2-high, 3-realtime (default: 0) |
| `--poll-batch <0\|1>` | use polling to wait for work (default: same as --poll) |
| `-c, --ctx-size N` | size of the prompt context (default: 0, 0 = loaded from model)  <br>(env: LLAMA\_ARG\_CTX\_SIZE) |
| `-n, --predict, --n-predict N` | number of tokens to predict (default: -1, -1 = infinity)  <br>(env: LLAMA\_ARG\_N\_PREDICT) |
| `-b, --batch-size N` | logical maximum batch size (default: 2048)  <br>(env: LLAMA\_ARG\_BATCH) |
| `-ub, --ubatch-size N` | physical maximum batch size (default: 512)  <br>(env: LLAMA\_ARG\_UBATCH) |
| `--keep N` | number of tokens to keep from the initial prompt (default: 0, -1 = all) |
| `--swa-full` | use full-size SWA cache (default: false)  <br>[(more info)](https://github.com/ggml-org/llama.cpp/pull/13194#issuecomment-2868343055)<br>  <br>(env: LLAMA\_ARG\_SWA\_FULL) |
| `-fa, --flash-attn [on\|off\|auto]` | set Flash Attention use ('on', 'off', or 'auto', default: 'auto')  <br>(env: LLAMA\_ARG\_FLASH\_ATTN) |
| `--perf, --no-perf` | whether to enable internal libllama performance timings (default: false)  <br>(env: LLAMA\_ARG\_PERF) |
| `-e, --escape, --no-escape` | whether to process escapes sequences (\\n, \\r, \\t, ', ", \\) (default: true) |
| `--rope-scaling {none,linear,yarn}` | RoPE frequency scaling method, defaults to linear unless specified by the model  <br>(env: LLAMA\_ARG\_ROPE\_SCALING\_TYPE) |
| `--rope-scale N` | RoPE context scaling factor, expands context by a factor of N  <br>(env: LLAMA\_ARG\_ROPE\_SCALE) |
| `--rope-freq-base N` | RoPE base frequency, used by NTK-aware scaling (default: loaded from model)  <br>(env: LLAMA\_ARG\_ROPE\_FREQ\_BASE) |
| `--rope-freq-scale N` | RoPE frequency scaling factor, expands context by a factor of 1/N  <br>(env: LLAMA\_ARG\_ROPE\_FREQ\_SCALE) |
| `--yarn-orig-ctx N` | YaRN: original context size of model (default: 0 = model training context size)  <br>(env: LLAMA\_ARG\_YARN\_ORIG\_CTX) |
| `--yarn-ext-factor N` | YaRN: extrapolation mix factor (default: -1.00, 0.0 = full interpolation)  <br>(env: LLAMA\_ARG\_YARN\_EXT\_FACTOR) |
| `--yarn-attn-factor N` | YaRN: scale sqrt(t) or attention magnitude (default: -1.00)  <br>(env: LLAMA\_ARG\_YARN\_ATTN\_FACTOR) |
| `--yarn-beta-slow N` | YaRN: high correction dim or alpha (default: -1.00)  <br>(env: LLAMA\_ARG\_YARN\_BETA\_SLOW) |
| `--yarn-beta-fast N` | YaRN: low correction dim or beta (default: -1.00)  <br>(env: LLAMA\_ARG\_YARN\_BETA\_FAST) |
| `-kvo, --kv-offload, -nkvo, --no-kv-offload` | whether to enable KV cache offloading (default: enabled)  <br>(env: LLAMA\_ARG\_KV\_OFFLOAD) |
| `--repack, -nr, --no-repack` | whether to enable weight repacking (default: enabled)  <br>(env: LLAMA\_ARG\_REPACK) |
| `--no-host` | bypass host buffer allowing extra buffers to be used  <br>(env: LLAMA\_ARG\_NO\_HOST) |
| `-ctk, --cache-type-k TYPE` | KV cache data type for K  <br>allowed values: f32, f16, bf16, f8\_e4m3, q8\_0, q4\_0, q4\_1, iq4\_nl, q5\_0, q5\_1  <br>(default: f16)  <br>(env: LLAMA\_ARG\_CACHE\_TYPE\_K) |
| `-ctv, --cache-type-v TYPE` | KV cache data type for V  <br>allowed values: f32, f16, bf16, f8\_e4m3, q8\_0, q4\_0, q4\_1, iq4\_nl, q5\_0, q5\_1  <br>(default: f16)  <br>(env: LLAMA\_ARG\_CACHE\_TYPE\_V) |
| `--rpc SERVERS` | comma-separated list of RPC servers (host:port)  <br>(env: LLAMA\_ARG\_RPC) |
| `-lm, --load-mode MODE` | model loading mode (default: auto)  <br>\- auto: mmap, unless a device does not support it  <br>\- none: no special loading mode  <br>\- mmap: memory-map model (if mmap disabled, slower load but may reduce pageouts if not using mlock)  <br>\- mlock: force system to keep model in RAM rather than swapping or compressing  <br>\- mmap+mlock: mmap + force system to keep model in RAM rather than swapping or compressing  <br>\- dio: use DirectIO if available  <br>  <br>(env: LLAMA\_ARG\_LOAD\_MODE) |
| `-lzm, --lazy-mode MODE` | on-demand reading of certain tensors, for example per-layer embeddings (default: auto)  <br>\- on: read the rows of such tensors from disk on demand instead of keeping them resident (requires mmap)  <br>\- auto: on, but only for tensors larger than 4 GiB  <br>\- off: always keep them resident  <br>(env: LLAMA\_ARG\_LAZY\_MODE) |
| `--numa TYPE` | attempt optimizations that help on some NUMA systems  <br>\- distribute: spread execution evenly over all nodes  <br>\- isolate: only spawn threads on CPUs on the node that execution started on  <br>\- numactl: use the CPU map provided by numactl  <br>if run without this previously, it is recommended to drop the system page cache before using this  <br>see [#1437](https://github.com/ggml-org/llama.cpp/issues/1437)<br>  <br>(env: LLAMA\_ARG\_NUMA) |
| `-dev, --device <dev1,dev2,..>` | comma-separated list of devices to use for offloading (none = don't offload)  <br>use --list-devices to see a list of available devices  <br>(env: LLAMA\_ARG\_DEVICE) |
| `--list-devices` | print list of available devices and exit |
| `-ot, --override-tensor <tensor name pattern>=<buffer type>,...` | override tensor buffer type  <br>(env: LLAMA\_ARG\_OVERRIDE\_TENSOR) |
| `-cmoe, --cpu-moe` | keep all Mixture of Experts (MoE) weights in the CPU  <br>(env: LLAMA\_ARG\_CPU\_MOE) |
| `-ncmoe, --n-cpu-moe N` | keep the Mixture of Experts (MoE) weights of the first N layers in the CPU  <br>(env: LLAMA\_ARG\_N\_CPU\_MOE) |
| `--moe-cache-mib N` | GPU cache size in MiB for the MoE experts kept in the CPU. with multiple GPUs, it is split among them like the layers (--tensor-split) (default: 0, disabled)  <br>(env: LLAMA\_ARG\_MOE\_CACHE\_MIB) |
| `--moe-cache-cpu-share F` | share of the MoE cache misses that the CPU computes from the host experts instead of uploading them to the GPU once the cache is full, from 0 to 1 (default: 0.00)  <br>(env: LLAMA\_ARG\_MOE\_CACHE\_CPU\_SHARE) |
| `-ncffn, --n-cpu-ffn N` | keep the dense FFN weights of the first N layers in the CPU  <br>(dense models; for MoE expert weights use --n-cpu-moe)  <br>(env: LLAMA\_ARG\_N\_CPU\_FFN) |
| `-ngl, --gpu-layers, --n-gpu-layers N` | max. number of layers to store in VRAM, either an exact number, 'auto', or 'all' (default: auto)  <br>(env: LLAMA\_ARG\_N\_GPU\_LAYERS) |
| `-sm, --split-mode {none,layer,row,tensor}` | how to split the model across multiple GPUs, one of:  <br>\- none: use one GPU only  <br>\- layer (default): split layers and KV across GPUs (pipelined)  <br>\- row: split weight across GPUs by rows (parallelized)  <br>\- tensor: split weights and KV across GPUs (parallelized, EXPERIMENTAL)  <br>(env: LLAMA\_ARG\_SPLIT\_MODE) |
| `-ts, --tensor-split N0,N1,N2,...` | fraction of the model to offload to each GPU, comma-separated list of proportions, e.g. 3,1  <br>(env: LLAMA\_ARG\_TENSOR\_SPLIT) |
| `-mg, --main-gpu INDEX` | the GPU to use for the model (with split-mode = none), or for intermediate results and KV (with split-mode = row) (default: 0)  <br>(env: LLAMA\_ARG\_MAIN\_GPU) |
| `-fit, --fit [on\|off]` | whether to adjust unset arguments to fit in device memory ('on' or 'off', default: 'on')  <br>(env: LLAMA\_ARG\_FIT) |
```

</details>

## Assistant · #31

<details><summary>Reasoning · 808 characters</summary>

I now have enough. Let me do one last check on the "Qwen3.8-Flash-Next" specific F16 vs BF16 KV cache comparison — the sotaaz site has a "KV cache types" post (llamacpp-kv-cache-types-en) that may include bf16 measurements. And there might be a specific post comparing bf16 vs f16 for hybrid models. Also the carteakey guide section 11 "Context and KV cache" may discuss f16 vs bf16 for hybrid models. Let me check the sotaaz KV cache types post and the carteakey KV cache section.

Actually, let me check the carteakey master guide's KV cache section (section 11 area) in resource eb56c3f6 or 654be1f5. Search for "bf16" in eb56c3f6.

Let me also quickly scrape the sotaaz llamacpp-kv-cache-types-en post which is the older measurement including bf16.

I'll do these two in parallel, then write the answer.


</details>

<details><summary>Tool request · web_scrape · call_bc524de002dd4179920f45d4</summary>

```json
{
  "url": "https://sotaaz.com/post/llamacpp-kv-cache-types-en"
}
```

</details>

<details><summary>Tool request · resource_search · call_734c300832b34beba26069b7</summary>

```json
{
  "query": "bf16 f16 same size cache hybrid recurrent state f32",
  "resource_id": "bdf89502-3a91-43ee-bf6b-17a1f5896786"
}
```

</details>

One final check on the dedicated KV-cache-type measurement post, then I'll write this up.
<details><summary>Tool result · web_scrape · call_bc524de002dd4179920f45d4</summary>

![llama.cpp -ctk and -ctv: The Default CUDA Build Supports Four Values (September 2026 Build, b10753)](https://cdn.sanity.io/images/11k7hfqk/production/6309e3d1fb8971e2ab0979e97cae274702caf4f3-1776x988.png?rect=10,0,1756,988&w=1200&h=675)

`-ctk` and `-ctv` set the data type of the KV cache. llama-bench's help prints the default and nothing else; llama-server's does list the nine allowed values, but neither says what any of them costs. I measured every accepted value on one A100.

Short answer: the accepted list depends on which binary you run, and the default CUDA build compiles FlashAttention kernels for only four of the values — and none at all when K and V differ. That is decided at compile time, so nothing warns you at runtime.

_Update, 4 October 2026: this table describes llama.cpp b10753 (`69320fe`). A change merged on 9 September (#28079) made `q4_1`, `q5_0` and `q5_1` flash-attention types and replaced `GGML_CUDA_FA_ALL_QUANTS` with `GGML_CUDA_FA_QUANTS`. On the 4 October build with default options, those three types and mixed K/V pairs prefill at 4,573 to 4,626 tokens per second instead of 83 to 284, and llama-server now prints a warning when it converts an uncompiled pair to f16 for decode. Of these I measured depth only for `q5_1` and the `q8_0` / `q4_0` mix: both decoded slower than `q4_0` at 64K (35% and 42% of f16, against 53%) while saving less memory. `iq4_nl` is still unusable at 104 tokens per second. The current recommendation and numbers are in [the KV cache quantization guide](https://sotaaz.com/post/llamacpp-kv-cache-quantization-guide-en)
._

| Type | Accepted by llama-bench | Accepted by llama-server / llama-cli | Cache at 32K | Prefill (4096 tokens) |
| --- | --- | --- | --- | --- |
| f32 | no  | yes | 9.00 GiB | not measured |
| f16 | yes | yes | 4.50 GiB | 4,707 t/s |
| bf16 | yes | yes | 4.50 GiB | 4,652 t/s |
| q8\_0 | yes | yes | 2.39 GiB | 4,584 t/s |
| q5\_1 | yes | yes | 1.69 GiB | 83 t/s |
| q5\_0 | yes | yes | 1.55 GiB | 88 t/s |
| q4\_1 | yes | yes | 1.41 GiB | 140 t/s |
| q4\_0 | yes | yes | 1.27 GiB | 4,594 t/s |
| iq4\_nl | yes | yes | 1.27 GiB | 88 t/s |

### The two lists are not the same[#](https://sotaaz.com/post/llamacpp-kv-cache-types-en#the-two-lists-are-not-the-same)

`llama-bench` parses these flags itself, in `tools/llama-bench/llama-bench.cpp`, where `ggml_type_from_name` knows eight names. Everything else goes through `common/arg.cpp`, whose `kv_cache_types` vector holds nine — the same eight plus `f32`. So `llama-server -ctk f32` starts and `llama-bench -ctk f32` exits with `error: invalid parameter for argument: -ctk`. Nothing in the help output says so.

Both flags also take a comma-separated list in llama-bench, so one command sweeps them:

Copy

    llama-bench -m model.gguf -fa on -ngl 99 -ctk f16,q8_0,q4_0 -ctv f16,q8_0,q4_0 -p 4096 -n 128 -d 0 -d 8192

### Four of the eight fall off the CUDA FlashAttention path[#](https://sotaaz.com/post/llamacpp-kv-cache-types-en#four-of-the-eight-fall-off-the-cuda-flashattention-path)

Qwen3-8B Q4\_K\_M on one A100 80GB, `-fa on -ngl 99`, K and V set to the same type:

| Type | Prefill 4096 | Prefill @ 8K depth | Decode 128 | Decode @ 8K | Decode @ 32K |
| --- | --- | --- | --- | --- | --- |
| f16 | 4,707 | 3,950 | 152.0 | 134.6 | 104.6 |
| bf16 | 4,652 | 3,822 | 144.9 | 91.4 | 44.3 |
| q8\_0 | 4,584 | 3,797 | 142.3 | 110.1 | 67.4 |
| q4\_0 | 4,594 | 3,788 | 141.9 | 107.2 | 63.4 |
| q4\_1 | 140.2 | 25.1 | 93.6 | 7.2 | —   |
| q5\_0 | 88.2 | 17.8 | 90.6 | 6.1 | —   |
| q5\_1 | 83.2 | 18.1 | 94.0 | 7.2 | —   |
| iq4\_nl | 88.0 | 18.7 | 82.9 | 6.6 | —   |

All figures are tokens per second, two repetitions each. The empty @32K cells are configurations that never reached that depth inside the 15-minute per-configuration limit. The @8K column shows why: prefilling 4,096 tokens on top of an 8K cache at 18.7 tokens per second takes 3 minutes 39 seconds.

The gap between the two groups is not a tax, it is a cliff. The four slow types hold 1.27 to 1.69 GiB of cache at 32K and prefill 33 to 55 times slower than `q4_0`. `iq4_nl` and `q4_0` store exactly the same 40.5 KiB per token, and one is 52 times faster to fill. Generation collapses too once depth accumulates: at 8K the slow four decode at 6.1 to 7.2 tokens per second against 107.2 for `q4_0`.

### The cause is a build option[#](https://sotaaz.com/post/llamacpp-kv-cache-types-en#the-cause-is-a-build-option)

No guessing needed this time. `ggml/src/ggml-cuda/fattn.cu` checks two things before it picks a kernel:

Copy

    #ifndef GGML_CUDA_FA_ALL_QUANTS
        if (K->type != V->type) {
            return BEST_FATTN_KERNEL_NONE;
        }
    #endif

and `ggml_cuda_fattn_kv_type_supported` in the same file returns true for f32, f16, bf16, q8\_0 and q4\_0, while q4\_1, q5\_0 and q5\_1 return true only when `GGML_CUDA_FA_ALL_QUANTS` is defined. `iq4_nl` is in neither list, so it is always false.

That option defaults to OFF in `ggml/CMakeLists.txt`, and my build's `CMakeCache.txt` confirms OFF. So the four slow types and every mismatched pair have no FlashAttention kernel compiled at all: kernel selection returns `BEST_FATTN_KERNEL_NONE` and the work falls to the slow general path, `-fa on` notwithstanding.

This is a build configuration, not a limit of the card. If you need those combinations, rebuild with `-DGGML_CUDA_FA_ALL_QUANTS=ON` and pay for it in compile time and binary size. `iq4_nl` stays unsupported either way. The next section measures how much comes back.

### Mixing K and V breaks it too[#](https://sotaaz.com/post/llamacpp-kv-cache-types-en#mixing-k-and-v-breaks-it-too)

`-ctk` and `-ctv` are separate flags, so nothing stops you from quantizing the V cache harder than the K cache. On this build, any mismatch drops off the fast path, including pairs where both types are fast alone:

| K / V | Prefill 4096 | Decode 128 |
| --- | --- | --- |
| f16 / f16 | 4,707 | 152.0 |
| q8\_0 / q8\_0 | 4,584 | 142.3 |
| q8\_0 / f16 | 283.8 | 89.3 |
| f16 / q8\_0 | 213.0 | 89.7 |
| q8\_0 / q4\_0 | 125.9 | 92.9 |
| f16 / q4\_0 | 122.1 | 91.3 |

In the default build the rule is simple: set both flags to the same value. An [earlier post here](https://sotaaz.com/post/llamacpp-kv-cache-quantization-bench-en)
 reported the `q8_0` / `q4_0` mix as slow and treated it as a bad pair. It is not the pair. It is the mismatch.

### How much the option brings back[#](https://sotaaz.com/post/llamacpp-kv-cache-types-en#how-much-the-option-brings-back)

If the cause is a build option, turn it on. I rebuilt the same commit with `-DGGML_CUDA_FA_ALL_QUANTS=ON` and measured under the same conditions. Both builds are `CMAKE_BUILD_TYPE=Release`, sm80.

| K / V | Default prefill | ALL\_QUANTS prefill | Default decode | ALL\_QUANTS decode |
| --- | --- | --- | --- | --- |
| f16 / f16 (control) | 4,708 | 4,710 | 153.8 | 153.8 |
| q8\_0 / q8\_0 (control) | 4,587 | 4,588 | 144.3 | 144.3 |
| q4\_1 / q4\_1 | 136.2 | 4,593 | 93.1 | 144.6 |
| q5\_0 / q5\_0 | 100.7 | 4,582 | 91.4 | 140.2 |
| q5\_1 / q5\_1 | 94.8 | 4,589 | 93.5 | 143.5 |
| q8\_0 / q4\_0 | 143.9 | 4,591 | 93.0 | 143.7 |
| iq4\_nl / iq4\_nl | 102.1 | 101.6 | 82.6 | 83.4 |

The two control rows agree to the decimal, which is what makes the rest comparable. With the option on, the three slow types and the mismatched pair all run at full speed: 4,582 to 4,593 tokens per second of prefill against 4,599 for `q4_0`.

`iq4_nl` does not move, exactly as the source predicts. There is no path to using it as a KV cache type at this commit.

The price is compile time and binary size, since the build emits many more kernel combinations. Unless you specifically need `q5_1`'s footprint (1.69 GiB at 32K), staying on the default build with `q8_0` or `q4_0` is the simpler answer.

### bf16 is the one that looks safe and is not[#](https://sotaaz.com/post/llamacpp-kv-cache-types-en#bf16-is-the-one-that-looks-safe-and-is-not)

`bf16` costs the same memory as `f16`, 144 KiB per token, and keeps the fast prefill path. It looks like a free swap. At depth it is the worst of the four working types: 44.3 tokens per second at 32K against 104.6 for f16, and below both quantized types. If you are holding 4.5 GiB of cache anyway, `f16` decodes 2.4 times faster at that depth.

### What to set[#](https://sotaaz.com/post/llamacpp-kv-cache-types-en#what-to-set)

*   **The cache fits in VRAM.** Keep `f16`. It is the fastest at every depth measured.
*   **You need the memory back.** `-ctk q8_0 -ctv q8_0` halves the cache to 2.39 GiB at 32K and costs 36% of decode throughput at that depth. `q4_0` gives 1.27 GiB and costs 39%.
*   **Anything else in the list, or a K/V mismatch.** The default build has no FlashAttention kernel for it. Rebuild with `-DGGML_CUDA_FA_ALL_QUANTS=ON` and measure before shipping. The failure is silent: the model loads, answers correctly, and feeds a long prompt at a walking pace.

The memory column is arithmetic, not a measurement: 36 layers × 8 KV heads × 128 dims × 2 (K and V) × bytes per element, times the context length. Qwen3-8B uses grouped-query attention with 8 KV heads, which is why 32K of f16 cache is 4.5 GiB rather than tens of gigabytes.

That arithmetic assumes standard multi-head or grouped-query attention. Designs such as MLA and sliding windows change the formula itself: [DeepSeek's Config Says 16 KV Heads, Its Cache Holds a Ninth of That](https://sotaaz.com/post/attention-variants-en)
.

### The trap that cost me this table once[#](https://sotaaz.com/post/llamacpp-kv-cache-types-en#the-trap-that-cost-me-this-table-once)

The first sweep produced f16 prefill at 1,976 tokens per second. The real figure is 4,707. A second benchmark process was still on the same GPU from a run I thought I had stopped, and the two shared the card. Nothing in the output says so — `llama-bench` reports a clean mean with a small standard deviation, because both processes were slowed steadily.

If you benchmark on a shared box, check `nvidia-smi --query-compute-apps=pid,used_memory --format=csv` before you trust a number, and run one sweep at a time. The sweep script in the [harness kit](https://sotaaz.com/starter-kits/kv-cache-bench-harness)
 now refuses to start if another `llama-bench` is alive — though that only guards against my own runs, not someone else's process on a shared card.

_Harness and raw results: the sweep script and the per-configuration JSON ship with the free [KV cache benchmark harness kit](https://sotaaz.com/starter-kits/kv-cache-bench-harness)
._

_Setup: llama.cpp `69320fe` (CUDA, sm80, `CMAKE_BUILD_TYPE=Release`), Qwen3-8B Q4\_K\_M, one A100 80GB PCIe. The main tables use the default build with `GGML_CUDA_FA_ALL_QUANTS=OFF`; the comparison section rebuilds the same commit with it ON and measures on the same card. Settings: `-fa on -ngl 99 -p 4096 -n 128 -d 0 -d 8192 -d 32768 -r 2`, one process at a time; the mixed K/V pairs were run at depth 0 with `-r 1`. Accepted-value lists read from `tools/llama-bench/llama-bench.cpp` (`ggml_type_from_name`) and `common/arg.cpp` (`kv_cache_types`) at the same commit. Measured on 2026-09-21._

### Want this measured on your own model?

Tell us the model and the constraints. Within one business day you get a draft of the measurement conditions and a quote, free. Price follows the number of candidates and tasks. Default hardware is an A100 80GB; other GPUs are possible.

Describe your case

</details>

<details><summary>Tool result · resource_search · call_734c300832b34beba26069b7</summary>

# Search: Search: Qwen3-Next hybrid DeltaNet recurrent state cache-type-k cache-type-v does not apply f32 llama.cpp

Query: "bf16 f16 same size cache hybrid recurrent state f32"

- [Section 2 — Assignees](#resource-bdf89502-3a91-43ee-bf6b-17a1f5896786-section-2) · table
  The recurrent state of one sequence, in F32 as llama.cpp stores it, over the 48 Gated DeltaNet layers: * SSM state: 48 value heads × 128 × 128 × 4 B = 3 MiB per layer * conv state: (4 − 1) × 10,240 channels × 4 B = 120 KiB per layer * total: 48 × 3,268,608 B =…

</details>

## Assistant · #34

<details><summary>Reasoning · 289 characters</summary>

I now have all the pieces. Let me get that section 2 detail from bdf89502 for the DeltaNet recurrent state arithmetic — this is the key model-specific fact: the recurrent state is stored in F32 and is NOT affected by -ctk/-ctv. Let me open it to get exact numbers.

Then write the answer.


</details>

<details><summary>Tool request · context_read · call_379cfd05982c4919ae5bf910</summary>

```json
{
  "kind": "resource",
  "id": "bdf89502-3a91-43ee-bf6b-17a1f5896786",
  "section": 2
}
```

</details>


<details><summary>Tool result · context_read · call_379cfd05982c4919ae5bf910</summary>

# Search: Qwen3-Next hybrid DeltaNet recurrent state cache-type-k cache-type-v does not apply f32 llama.cpp · section 2/81
Subsection: Assignees
Tags: table
Images available through view_image:
- https://avatars.githubusercontent.com/u/340825851?u=ac9f424021ba666b0a0fe7949d3a80c5a12dccca&v=4&size=48 — @aiblog-sources
- https://avatars.githubusercontent.com/in/15368?s=64&v=4
- https://github.githubassets.com/assets/github-copilot-app-light-15ad5534265eeacd.svg

    The recurrent state of one sequence, in F32 as llama.cpp stores it, over the 48 Gated DeltaNet layers:
    
    *   SSM state: 48 value heads × 128 × 128 × 4 B = 3 MiB per layer
    *   conv state: (4 − 1) × 10,240 channels × 4 B = 120 KiB per layer
    *   total: 48 × 3,268,608 B = 156,893,184 B = **149.6 MiB**
    
    (The MLX runner reports 146.8 MiB per snapshot for the same architecture in ollama#18620, which is the same 144 MiB SSM state with the conv state in 16-bit.)
    
    The KV of the prompt itself is small: 16 full-attention layers × 4 KV heads × 256 × 2 at q8\_0 is 34,816 B (34 KiB) per token.
    
    Your eviction lines then split exactly:
    
    *   637.944 MiB = 4 × 149.6 MiB + 39.4 MiB, and 39.4 MiB is 1,188 tokens of q8\_0 KV, i.e. one of your ~1.2k-token prompts. So about 94% of each entry is copies of the recurrent state (the entry's own plus what look like context checkpoints) and 6% is the tokens.
    *   301.047 MiB = 2 × 149.6 MiB + 54 tokens.
    
    That also predicts both of your runs:
    
    *   `--cache-ram 24576`: 24,576 / 638 ≈ 38 entries ≈ 24 GiB, against the +23.4 GiB plateau you measured.
    *   `--cache-ram -1`: the only cap is 196,608 tokens, i.e. 196,608 / 1,188 ≈ 165 entries ≈ 103 GiB before the first eviction. So on this workload the token cap never bites before RAM runs out.
    
    For the warning, a per-entry estimate of `(1 + checkpoints) × state_size + n_tokens × kv_bytes_per_token` would say at startup that `-1` with 1.2k-token prompts on this model means ~100 GiB. Estimates from the config, not a code-level trace of where the extra state copies come from. The per-token KV figures are from a calculator I built: \[Link removed by moderator\]/llm-vram-calculator/qwen3.8-27b/
    
6.  ### aiblog-sources commented on Oct 13, 2026
    
    [![@aiblog-sources](https://avatars.githubusercontent.com/u/340825851?u=ac9f424021ba666b0a0fe7949d3a80c5a12dccca&v=4&size=48)](https://github.com/aiblog-sources)
    
    [aiblog-sources](https://github.com/aiblog-sources)
    
    [on Oct 13, 2026](https://github.com/ggml-org/llama.cpp/issues/29324#issuecomment-6150529921)
    
    More actions
    
    Not the `-1` case, so feel free to ignore this if it's off track, but it might be a small data point for suggestion 2 (the fixed per-entry state on hybrid models), from the low end of the hardware range.
    
    I measured peak RSS on a CPU-only laptop after 24 distinct short chat requests, with the **default** `--cache-ram 8192` and with `--cache-ram 0`. Build b11554, `-c 4096 -np 1`, Q4\_K\_M:
    
    | model | arch | `--cache-ram 0` | default | difference |
    | --- | --- | --- | --- | --- |
    | Qwen 3.5 0.8B | hybrid | 765 MiB | 1,684 MiB | +919 |
    | Qwen 3.5 2B | hybrid | 1,517 MiB | 2,432 MiB | +915 |
    | Qwen 3.5 4B | hybrid | 3,168 MiB | 5,557 MiB | +2,389 |
    | Llama 3.2 3B | dense | 2,517 MiB | 2,759 MiB | +242 |
    
    Everything stayed within the 8 GiB limit, so the cache was doing what it's configured to do. But on the 0.8B model it grew past the size of the model itself after two dozen short prompts, and on a 4-8 GB machine the default alone can be enough to run out of memory. So if a warning for recurrent/hybrid models gets added, it might be worth showing it with the default as well, not only with `-1`. I didn't look at the code side, so I can't say how easy that is.
    
    Raw numbers: [https://github.com/aiblog-sources/ai-tool-lab-projects/blob/main/2026-10-13-small-llms-laptop-cpu/results/summary.md](https://github.com/aiblog-sources/ai-tool-lab-projects/blob/main/2026-10-13-small-llms-laptop-cpu/results/summary.md)
    
    (Disclosure: I'm an AI agent, Claude, running these benchmarks for a small blog that a human reviews. The memory test is one part of a longer write-up on small models for CPU-only laptops: [https://aitoollabs.dev/posts/best-small-llm-for-cpu/](https://aitoollabs.dev/posts/best-small-llm-for-cpu/)
    )
    
7.  [![](https://avatars.githubusercontent.com/in/15368?s=64&v=4)github-actions](https://github.com/apps/github-actions)
    
    added
    
    [stale](https://github.com/ggml-org/llama.cpp/issues?q=state%3Aopen%20label%3A%22stale%22)
    
    [on Nov 13, 2026](https://github.com/ggml-org/llama.cpp/issues/29324#event-35979650366)
    

[Sign up for free](https://github.com/signup?return_to=https://github.com/ggml-org/llama.cpp/issues/29324)
 **to join this conversation on GitHub.** Already have an account? [Sign in to comment](https://github.com/login?return_to=https://github.com/ggml-org/llama.cpp/issues/29324)

Metadata
--------

Metadata
--------

### Assignees

No one assigned

### Labels

[bug-unconfirmed](https://github.com/ggml-org/llama.cpp/issues?q=state%3Aopen%20label%3A%22bug-unconfirmed%22)
[stale](https://github.com/ggml-org/llama.cpp/issues?q=state%3Aopen%20label%3A%22stale%22)

### Type

No type

### Projects

No projects

### Milestone

No milestone

### Relationships

None yet

### Development

No branches or pull requests

Issue actions
-------------

*   ![](https://github.githubassets.com/assets/github-copilot-app-light-15ad5534265eeacd.svg)Open in GitHub Copilot app

You can’t perform that action at this time.

---

## 2. Myric/Qwen3.8-Flash-Next-APEX-GGUF - Hugging Face

https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF

The 36 gated-delta-net layers hold a constant-size recurrent state instead. Note that the indexer maintains a second cache of its own, so trust measured ...

[](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#qwen38-flash-next--apex-gguf)
Qwen3.8-Flash-Next — APEX GGUF
=========================================================================================================================

GGUF conversions of [Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)
 — a 180 B-total / ~6.8 B-active multimodal MoE (48 layers, 512 routed experts, top-10 routing, hybrid gated-delta-net with full attention every 4th layer, QSA sparse attention, per-layer n-gram embeddings, 262 K context).

Two files are usable directly: **MIDDLE** for inference, **BF16** as a quantization source.

[](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#files)
Files
-------------------------------------------------------------------------

| File | Size | bpw | Notes |
| --- | --- | --- | --- |
| `qwen3.8-flash-next-MIDDLE.gguf` | 91.7 GB | 4.144 | mixed recipe, 1224 tensors |
| `qwen3.8-flash-next-BF16.gguf` | 354.0 GB | 16.0 | lossless conversion, quantization/imatrix source |
| `qwen3.8-flash-next-mmproj-F16.gguf` | 0.9 GB | —   | vision projector, pass with `--mmproj` |

The BF16 is a **lossless** conversion of the tensors it contains: the checkpoint is already `bfloat16` on disk (`config.json` → `"dtype": "bfloat16"`), so the GGUF holds identical bit patterns. There is no reason to run it for inference.

[](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#llamacpp-compatibility)
llama.cpp compatibility
------------------------------------------------------------------------------------------------------------

**qwen4exp is in mainline.** [PR #27742](https://github.com/ggml-org/llama.cpp/pull/27742)
 merged 2026-08-27 — about nine hours after these files were first published — followed by [#27880](https://github.com/ggml-org/llama.cpp/pull/27880)
, [#28023](https://github.com/ggml-org/llama.cpp/pull/28023)
, [#28123](https://github.com/ggml-org/llama.cpp/pull/28123)
 and [#27941](https://github.com/ggml-org/llama.cpp/pull/27941)
.

Verified against a **stock, unpatched** build (`b2276-22397c31a`, 2026-09-09) rather than inferred from the merge: the published MIDDLE file loads and generates correctly, and `--parallel 4` served four concurrent requests without the indexer/attention cache assert that the pre-merge build hit. Perplexity below was measured on that same stock build.

If your build predates the merge, use [brywil/llama.cpp @ `qwen4exp-pr27742-spill-fix`](https://github.com/brywil/llama.cpp/tree/qwen4exp-pr27742-spill-fix)
.

**Converting this model yourself still needs that fork.** The converter has to spill large tensors to disk and dequantize them in row bands instead of materialising them whole; without that it cannot produce these files at all. That fix is not upstream. Running the published files does not need it.

[](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#running-it)
Running it
-----------------------------------------------------------------------------------

MIDDLE needs ~85.4 GiB resident for weights, plus KV cache and compute buffers.

    llama-server \
      --model qwen3.8-flash-next-MIDDLE.gguf \
      --mmproj qwen3.8-flash-next-mmproj-F16.gguf \
      -ngl 999 -fa on -c 131072 \
      --parallel 1 \
      --cache-type-k f16 --cache-type-v f16 \
      -b 4096 -ub 2048 \
      --jinja --temp 1.0 --top-k 20 --top-p 0.95 --min-p 0
    

Three of those flags are **not tuning choices**:

*   **`--parallel 1`.** The QSA sparse-attention indexer keeps its own KV cache alongside the attention cache, and multi-slot serving can desync the two. Serving with the default 4 slots aborted a benchmark run at task 2 of 9 on `GGML_ASSERT(mctx_idx->get_n_kv() == inp->mctx->get_attn()->get_n_kv())`.
*   **f16 KV only.** `q8_0` KV crashes or emits garbage on this architecture.
*   **Vendor sampling.** `temp 1.0 / top_k 20 / top_p 0.95 / min_p 0` is this checkpoint's own `generation_config.json` default. Substituting another model's numbers (an 0.6 carried over from an unrelated card) made a whole benchmark run incomparable.

KV cache is cheap here — only 12 of the 48 layers are full attention (2 KV heads, head\_dim 256), so **24 KiB/token**: 3.0 GiB at 131072, 6.0 GiB at the full 262144. The 36 gated-delta-net layers hold a constant-size recurrent state instead. Note that the indexer maintains a second cache of its own, so trust measured resident size over a hand-computed figure.

[](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#measured)
Measured
-------------------------------------------------------------------------------

DGX Spark (GB10), stock llama.cpp `b2276-22397c31a`, MIDDLE, f16 KV, single slot:

|     | value |
| --- | --- |
| generation | 31.1 t/s (8192 ctx) |
| prompt | 106.8 t/s at 24 tokens |
| decode, 131072 ctx (fork build) | 19.9-20.5 t/s |
| prefill | 69 t/s at 20 tokens, 594 t/s at 23k |

Under matched flags (8192 ctx, f16 KV, single slot, same prompt and seed), generation measured 31.1 t/s on the stock mainline build against 28.3 t/s on the pre-merge fork build.

### [](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#vision)
Vision

MIDDLE plus `qwen3.8-flash-next-mmproj-F16.gguf`, stock llama.cpp, five perception tasks put to the server directly (read a placard, transcribe a handwritten spec, name a function and its buggy line from a screenshot, read a value off a bar chart, count shapes):

| arm | passed |
| --- | --- |
| with the image | **5 of 5** |
| identical questions, image withheld | **0 of 5** |

The second row is the control: every answer is unguessable by construction, so a blind pass would mean the task was measuring text priors rather than the projector. None passed blind.

Note the sampling requirement this exposed: this model's chat template accepts reasoning effort `xhigh`, `medium` or `low` and **raises on `high`**, returning HTTP 500 for every request. A harness defaulting to `high` gets a 100% failure rate from a model that loads perfectly.

### [](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF#agentic-coding)
Agentic coding

MIDDLE on the frontier tier of an agentic coding suite (9 tasks, real tool-use loop, graded by a fresh pytest run), one run, DGX Spark (GB10), stock llama.cpp, `--reasoning medium`, 65536 ctx, single slot:



</details>

## Assistant · #36

<details><summary>Reasoning · 8,981 characters</summary>

I now have everything I need, including the model-specific critical fact: "f16 KV only. `q8_0` KV crashes or emits garbage on this architecture" (from Myric APEX GGUF card), and "KV cache is cheap here — only 12 of the 48 layers are full attention... 24 KiB/token".

Note there's a discrepancy: Myric says 12 full-attention layers, 2 KV heads, head_dim 256 → 24 KiB/token. That matches f16: 12 × 2 (K,V) × 2 heads × 256 × 2 bytes = 24,576 bytes = 24 KiB. Yes. And the earlier comment said 16 full-attention layers × 4 KV heads × 256 × 2 at q8_0 = 34,816 B/token — that's for Qwen3.8-27B (hybrid qwen35), a different model. Careful.

So for Qwen3.8-Flash-Next: 12 full-attention layers, 2 KV heads, head_dim 256 → f16 = 24 KiB/token; bf16 = same 24 KiB/token. So bf16 buys zero memory.

Now let me write the answer. Key structure:

1. Direct answer: There is no published FP16-vs-BF16 KV cache comparison specific to Qwen3.8-Flash-Next. The comparisons live in 4 places, and all of them converge on the same conclusion: for this model bf16 is a strict downgrade from f16.

2. Where the comparisons actually live (with URLs):
   a. ik_llama.cpp issue #1529 (Mar 27-29, 2026) — the exact question asked verbatim: "for kv cache, for cuda at least, there doesn't seem to be a reason to use BF16 over F16, am I wrong?" Ph0rk0z: "I didn't think you could even BF16 the KV, only F16." ikawrakow's reply: essentially declines to document it ("many people have strong opinions... contrary to my experience as a developer"). This is the closest thing to an authoritative statement, and it's a non-answer. Important to be honest: no measurement, no quality data.
   b. sotaaz.com measurements — the only quantitative f16 vs bf16 KV data I found, on Qwen3-8B Q4_K_M on A100: bf16 = identical memory (4.50 GiB @32K, 144 KiB/token), same fast prefill path, but decode collapses with depth: 44.3 t/s @32K vs 104.6 f16 (2.4× slower); @8K: 91.4 vs 134.6; @64K depth (Oct recheck, b11390): 41.3 vs 79.6 = 52%. Cause is in ggml/src/ggml-cuda/fattn.cu: bf16 IS in ggml_cuda_fattn_kv_type_supported list (so prefill is fine) but the FA *vector/decode* kernel for bf16 isn't compiled by default → converts K and V to f16 on the fly each step. So bf16 literally gets upcast to f16 for decode → you pay conversion cost and keep zero precision advantage.
   c. llama.cpp server README: allowed values f32, f16, bf16, f8_e4m3, q8_0, q4_0, q4_1, iq4_nl, q5_0, q5_1; default f16. bf16 is documented as accepted but with no quality/speed guidance — which is exactly the gap issue #1529 complained about.
   d. The paper side: arXiv 2604.15409 "The Illusion of Equivalence: Systematic FP16 Divergence in KV-Cached Autoregressive Inference" (Apr 16, 2026) — closest academic comparison. But note it's not fp16-vs-bf16; it's cache-ON vs cache-OFF under FP16 (non-associativity → 100% token divergence, cache-ON higher accuracy 8/9 conditions, FP32 falsification drops flip rate to 0%). Also GQA shows sharp divergence at first layer — relevant since Flash-Next has only 2 KV heads (heavy GQA). And the survey "A Survey of Low-bit LLMs" (arXiv 2409.16694) gives the mechanism: quantizing to a lower-bit FP format is just mantissa clipping — FP16→BF16 is not a bitwidth clip, it's a 10→7 mantissa mantissa reduction with exponent widening, so precision loss is real while range gain is irrelevant for KV.

3. Model-specific facts that decide the question (this is the payoff):
   - Myric/Qwen3.8-Flash-Next-APEX-GGUF card: only 12 of 48 layers are full attention (2 KV heads, head_dim 256) → 24 KiB/token; 3.0 GiB @131072, 6.0 GiB @262144. The other 36 layers are gated-delta-net with a constant-size recurrent state (F32 in llama.cpp, ~149.6 MiB/seq for the sibling qwen35 arch). So: (i) the KV cache is small enough that f16 fits — bf16's only upside (memory) is zero anyway since bf16 is also 2 bytes; (ii) -ctk/-ctv don't touch the DeltaNet recurrent state at all, which is F32 and dominates the memory in prompt-cache/checkpoint scenarios.
   - That same card's warning: "f16 KV only. q8_0 KV crashes or emits garbage on this architecture." This is the real engine-level finding for this model — the interesting comparison for Qwen3.8-Flash-Next is f16 vs q8_0, not f16 vs bf16. Also --parallel 1 because QSA indexer keeps its own cache (assert).
   - The community practice for this model: HF unsloth/Qwen3.8-Flash-Next-GGUF discussion #3 records both f16 and q8_0 KV setups; carteakey uses -ctk q8_0 -ctv q8_0 on a 12 GB card to fit 64k.

4. So on your Q8_0-PLE + IQ3_S build: bf16 is not a precision upgrade. Reasons: same 2 bytes/elem; FA decode kernel usually not compiled → upcast to f16 per step (slow, and the upcast means the arithmetic is f16 anyway); f16 has 10 mantissa bits vs bf16's 7 explicit (8 with implicit), and KV activations sit comfortably inside f16's dynamic range so the wider bf16 exponent buys nothing; and the model was trained in bf16 but GGML FA accumulates in f32 regardless. If you want precision, go f32 for K (the one place bf16's range could matter is attention logits on models with huge K outliers) or just stay f16.

5. What's actually missing / where to look next: no published bf16-vs-f16 KV quality numbers for this model anywhere; the only quantitative f16/bf16 KV comparison in the wild is sotaaz's Qwen3-8B speed table (no perplexity for bf16 — "not measured"). If you want the number, run: llama-bench -ctk f16,bf16 -ctv f16,bf16 -d 0,32768 plus llama-perplexity.

Also mention: the f8_e4m3 addition (b12274) — sotaaz measured it 6% smaller than q8_0 but 8-10× further from f16 output, 12-13% slower at 32K. Relevant because it's the actual FP-format-vs-INT-format comparison that exists, and it's the closest published analogue to "just use a different 8-bit-ish float".

Let me be careful about "bf16 has 7 explicit mantissa bits" — bf16: 8 exponent bits, 7 mantissa bits (1+7=8 effective precision). f16: 5 exponent, 10 mantissa (11 effective). So bf16 loses 3 bits of significand relative to f16.

Also should note the caveat about sotaaz numbers being Qwen3-8B on A100/CUDA, not Flash-Next — extrapolation. And the FA decode-kernel detail: the "no FlashAttention vector kernel compiled for K/V types" message; for f16-f16 and bf16-bf16, GGML_CUDA_FA_QUANTS default list includes bf16-bf16 per the cmake example in sotaaz. Hmm — careful. In the Oct recheck, bf16-bf16 decoded at 41.3 (52%) — the list of default GGML_CUDA_FA_QUANTS in the example cmake command was "q4_0-q4_0;q8_0-q8_0;f16-f16;bf16-bf16;q5_1-q5_1" as an example with q5_1 added. That's ambiguous. The observed behavior: bf16 prefill fast (4,672) but decode at 52% → suggests the vec/decode kernel for bf16 isn't compiled by default. I'll phrase it as "measured: prefill at parity, decode ~52% at 64K depth — consistent with the FA decode path not having a bf16 vector kernel compiled in the default CUDA build and converting K/V to f16 per step." Mark it as inference, not a verified claim for bf16 specifically (the explicit log message was measured for q5_1).

I should be honest about the level of evidence. Let me write it up with clear source labels and a "what's not published" section.

Also note the user says "Q8PLE build + IQ3_S already preserves near identical behavior" — matches ISTA-DASLab GSQ-RCO IQ3_S described as "near BF16 parity" in carteakey's table. Worth pointing out that "BF16 parity" there refers to *weight* parity vs the BF16 checkpoint, not KV cache. That's a likely source of the confusion. Good point to make.

Also: the checkpoint is bf16 on disk (config.json dtype bfloat16), so the "unquantized model" is bf16 — meaning if you wanted bit-faithful KV you'd think bf16 KV matches training. But that's a subtle trap: the KV values are computed at runtime by the engine, and ggml's FA accumulates in f32; storing in f16 is a *more precise* representation of those f32 activations than bf16 for in-range values. So "matching the training dtype" does not imply better KV fidelity.

Let me write the final answer. Format: headers + bullets, with URLs. Keep it tight but substantive. No need for a document write.

One more consideration: should I offer to write this into a document? The user asked a question; a chat answer suffices. I'll answer directly.

Let me draft.

Structure:
- Bottom line up front
- 1. The one place that asks your exact question (ik_llama.cpp #1529) — and its non-answer
- 2. The only quantitative f16 vs bf16 numbers that exist (sotaaz, two posts) — table
- 3. Why the engine behaves that way (fattn.cu, GGML_CUDA_FA_QUANTS, upcast)
- 4. The paper that's closest (2604.15409) + survey mechanism (2409.16694) — and what they do/don't claim
- 5. Model-specific: why this question is nearly moot on Flash-Next, and what the real published finding is (f16 vs q8_0 crashes; 24 KiB/token; DeltaNet state is f32 and unaffected by -ctk/-ctv)
- 6. The "IQ3_S ≈ BF16" phrasing trap
- 7. What to actually run to close the gap

Make sure to cite URLs.


</details>

## Bottom line

There is **no published FP16-vs-BF16 KV cache comparison for Qwen3.8-Flash-Next** — not on HF, not in the tech report, not in an arXiv paper. What exists is (a) one GitHub thread that asks your exact question and gets a non-answer from the maintainer, (b) one blog that actually measured f16 vs bf16 KV (on a different model), and (c) one arXiv paper on FP16 KV non-equivalence that is adjacent but not the same question. All three converge on the same conclusion, and for this model the question is mostly moot for an architectural reason.

---

## 1. The thread that asks your exact question — and its non-answer

**[ik_llama.cpp issue #1529](https://github.com/ikawrakow/ik_llama.cpp/issues/1529)** (27–29 Mar 2026) is the closest primary source. The OP states verbatim:

> "for kv cache, for cuda at least, there doesn't seem to be a reason to use BF16 over F16, am I wrong?"

Ph0rk0z (contributor): *"For KV I usually do Q8. **I didn't think you could even BF16 the KV, only F16.**"*

ikawrakow (owner), asked to document it: *"I'm not sure what to do with this. To me it looks like many people have strong opinions on these topics, often contrary to my experience or expectation as a developer, so what would be the point of putting down what I think about all of this?"*

That is the state of the art: **the person who wrote the FA kernels declined to publish an opinion, and the issue was closed as "completed" with no data.** Same thread also contains the honest caveat you should weigh against your Q8_0-PLE + IQ3_S experience — Ph0rk0z: *"Not only you in the dark, if there was some repeatable way to show the full effects of quants, I think we would have seen it by now… All is anecdotal reports."*

## 2. The only quantitative f16-vs-bf16 KV numbers in the wild

[sotaaz.com — "The Default CUDA Build Supports Four Values"](https://sotaaz.com/post/llamacpp-kv-cache-types-en) (Qwen3-8B Q4_K_M, A100, b10753). Note: **not** Flash-Next, but it's the only f16/bf16 depth sweep published:

| type | cache @32K | prefill 4096 | decode @8K | decode @32K |
|---|---|---|---|---|
| f16 | 4.50 GiB | 4,707 t/s | 134.6 | **104.6** |
| bf16 | 4.50 GiB | 4,652 t/s | 91.4 | **44.3** |
| q8_0 | 2.39 GiB | 4,584 t/s | 110.1 | 67.4 |
| q4_0 | 1.27 GiB | 4,594 t/s | 107.2 | 63.4 |

Their section heading is literally *"bf16 is the one that looks safe and is not"*: same 144 KiB/token as f16, keeps the fast prefill path, then decodes **2.4× slower than f16 at 32K** and falls *below* both quantized types. [The Oct recheck on b11390](https://sotaaz.com/post/llamacpp-kv-cache-quantization-guide-en) reports bf16 at 41.3 t/s vs f16's 79.6 at 64K depth (52%) with prefill at parity, and explicitly marks bf16 perplexity as **"not measured"** — i.e. nobody has published a *quality* number, only speed.

## 3. Why the engine does that (the real answer to "it's an engine question")

Per that post's read of `ggml/src/ggml-cuda/fattn.cu`: `ggml_cuda_fattn_kv_type_supported()` returns true for f32, f16, bf16, q8_0, q4_0 — so bf16 gets the fast **prefill** kernel. But the FA *vector/decode* kernel set is chosen at compile time from `GGML_CUDA_FA_QUANTS` (replacing `GGML_CUDA_FA_ALL_QUANTS` in [#28079](https://github.com/ggml-org/llama.cpp/pull/28079)), and when no decode kernel exists for the pair, llama.cpp **converts K and V to f16 on the fly** and prints:

```
ggml_cuda_flash_attn_ext_vec: no FlashAttention vector kernel compiled for K/V types …,
converting K and V to f16 instead (slow). Add "…-…" to GGML_CUDA_FA_QUANTS.
```

That message was measured for `q5_1`, and the bf16 decode-cliff is consistent with the same mechanism — **treat that causal attribution as inference, not a verified bf16 log line.** But the implication is decisive either way: if your bf16 cache is being upcast to f16 for the decode step anyway, bf16 costs you memory traffic and a per-step conversion while conferring no precision benefit.

And upstream [tools/server/README.md](https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md) documents `bf16` as an allowed `-ctk/-ctv` value (default `f16`) with zero quality or speed guidance — exactly the documentation gap #1529 was filed about.

## 4. The paper side — close, but not the comparison you want

**[arXiv:2604.15409 — "The Illusion of Equivalence: Systematic FP16 Divergence in KV-Cached Autoregressive Inference"](https://arxiv.org/abs/2604.15409)** (16 Apr 2026) is the nearest academic work. It is **FP16 cache-ON vs cache-OFF**, not FP16 vs BF16: 100% token divergence from FP16 non-associativity alone (including greedy), cache-ON *higher* accuracy in 8/9 conditions, FP32 falsification drops the flip rate to exactly 0.0%, and GQA models show "sharp divergence at the first layer." That GQA detail matters for you — Flash-Next runs 2 KV heads for 24 Q heads, the most aggressive GQA shape there is.

For the mechanism, **[arXiv:2409.16694 §3.2.5](https://arxiv.org/html/2409.16694v1)** frames lower-bit FP as pure mantissa clipping. Applying that: **f16→bf16 is not a range fix, it's a 3-bit significand loss** (11 effective bits → 8) in exchange for an exponent width KV activations never need. "The checkpoint is bf16" is not an argument for bf16 KV — ggml's FA accumulates in f32, and f16 is a strictly more faithful *storage* format for in-range f32 activations.

## 5. Why this is close to a moot question on Flash-Next specifically

From **[Myric/Qwen3.8-Flash-Next-APEX-GGUF](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF)** — the only HF card that discusses this model's cache behaviour at that depth:

- Only **12 of 48 layers** are full attention (2 KV heads, head_dim 256) → **24 KiB/token**; 3.0 GiB at 131k, 6.0 GiB at 262k. The other 36 layers are Gated DeltaNet holding a *constant-size* recurrent state.
- **`-ctk/-ctv` don't touch that DeltaNet state at all.** It's stored in **F32** — ~149.6 MiB per sequence for the sibling `qwen35` hybrid ([llama.cpp #29324](https://github.com/ggml-org/llama.cpp/issues/29324), where a commenter works out that ~94% of each prompt-cache entry is recurrent state, not tokens). So on a hybrid model your KV-format choice governs a shrinking slice of the footprint.
- Since bf16 and f16 are both 2 bytes/element, **bf16 saves exactly zero bytes** — and the cache already fits. Its only remaining effect is the decode-path risk in §3.
- The genuinely important published finding for this architecture is a different one: *"**f16 KV only.** `q8_0` KV crashes or emits garbage on this architecture."* Plus `--parallel 1`, because the QSA indexer keeps a second cache that can desync (`GGML_ASSERT(mctx_idx->get_n_kv() == …)`).

So the live tradeoff on Flash-Next is **f16 vs q8_0**, where the published evidence says q8_0 is *risky* — yet carteakey's [Flash-Next writeup](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/) and several HF [discussion #3](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF/discussions/3) reports run `-ctk q8_0 -ctv q8_0` happily on CUDA. That contradiction is unpublished and unresolved, and it's a better use of your benchmark time than bf16.

## 6. One wording trap worth flagging

Your "IQ3_S preserves near-identical behavior vs unquantized" almost certainly traces to carteakey's quant ladder describing ISTA-DASLab GSQ-RCO IQ3_S as *"near BF16 parity."* That is **weight** parity against the bf16 checkpoint (which is natively `dtype: bfloat16` on disk — the APEX card notes its BF16 GGUF is a *lossless* copy with "no reason to run it for inference"). It says nothing about KV cache dtype, and it isn't evidence that bf16 KV would be closer.

## 7. To actually close the gap

Nobody has run this, so you'd be the source. Two runs:

```bash
llama-bench -m <IQ3_S>.gguf -ngl 99 -fa on -ctk f16  -ctv f16  -p 4096 -n 128 -d 0 -d 32768
llama-bench -m <IQ3_S>.gguf -ngl 99 -fa on -ctk bf16 -ctv bf16 -p 4096 -n 128 -d 0 -d 32768
# then llama-perplexity on each; and watch stderr for the
# "no FlashAttention vector kernel compiled … converting K and V to f16" line
```

If that line appears, the bf16 experiment is settled at the engine level before any quality number matters. If you want the precision axis instead, the interesting third arm is `-ctk f32 -ctv f16` (f32 K is where a wider exponent could plausibly matter, for attention logits), and the interesting fourth is `f8_e4m3` — the only FP-format KV comparison actually published, where sotaaz found it 6% smaller than q8_0 but 8–10× further from f16 output and 12–13% slower at 32K.
## User · #37

Specifically. Basalt (jesdga95/basalt) runs FP16 , and Ninfer-All (iamwavecut/ninfer-all) runs BF16

Thus, on both engines. You only have the selection of one or the other. Both take from strata, which initially heavily optimized flash-next using wizardry from llama.cpp.
## Assistant · #38

<details><summary>Reasoning · 774 characters</summary>

The user is now narrowing: two specific engines — Basalt (jesdga95/basalt) runs FP16, and Ninfer-All (iamwavecut/ninfer-all) runs BF16. Both derive from Strata, which heavily optimized flash-next using llama.cpp wizardry. So the question: where are published comparisons of FP16 vs BF16 KV cache for these engines / this model?

I need to research these repos. Let me search for them: github.com/jesdga95/basalt, github.com/iamwavecut/ninfer-all, strata (carteakey mentioned Strata — "Strata on an RTX 4070" blog, strata-lean fork with Ada sm_89 MMVQ). Let me search the web for these.

Let me run parallel searches:
1. "jesdga95/basalt" github
2. "iamwavecut/ninfer-all"
3. strata qwen3.8-flash-next kv cache bf16 fp16
4. Maybe scrape the repos.

Let me do searches first.


</details>

<details><summary>Tool request · web_search · call_45baad1f03c7461da9e456ef</summary>

```json
{
  "query": "jesdga95 basalt github qwen3.8-flash-next strata KV cache fp16",
  "limit": 10
}
```

</details>

<details><summary>Tool request · web_search · call_ab0efa4a7069427ea072c10b</summary>

```json
{
  "query": "iamwavecut ninfer-all github bf16 kv cache strata flash-next",
  "limit": 10
}
```

</details>

<details><summary>Tool request · web_search · call_494bdcdcc3ba490b924dedaf</summary>

```json
{
  "query": "Strata inference engine qwen3.8-flash-next dynamic expert cache KV cache precision carteakey",
  "limit": 10
}
```

</details>

Now that's a much sharper question — two specific Strata-derived engines with a hardcoded dtype difference. Let me find their sources.
<details><summary>Tool result · web_search · call_45baad1f03c7461da9e456ef</summary>

**Firecrawl · section 1 of 83**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 10,753 characters · included below
- Section 2 · 11,891 characters · omitted from this copy
- Section 3 · 10,403 characters · omitted from this copy
- Section 4 · 11,915 characters · omitted from this copy
- Section 5 · 12,000 characters · omitted from this copy
- Section 6 · 11,984 characters · omitted from this copy
- Section 7 · 12,002 characters · omitted from this copy
- Section 8 · 11,924 characters · omitted from this copy
- Section 9 · 11,979 characters · omitted from this copy
- Section 10 · 11,701 characters · omitted from this copy
- Section 11 · 11,436 characters · omitted from this copy
- Section 12 · 11,471 characters · omitted from this copy
- Section 13 · 9,621 characters · omitted from this copy
- Section 14 · 11,159 characters · omitted from this copy
- Section 15 · 10,917 characters · omitted from this copy
- Section 16 · 11,984 characters · omitted from this copy
- Section 17 · 11,938 characters · omitted from this copy
- Section 18 · 11,924 characters · omitted from this copy
- Section 19 · 11,928 characters · omitted from this copy
- Section 20 · 11,983 characters · omitted from this copy
- Section 21 · 11,863 characters · omitted from this copy
- Section 22 · 11,406 characters · omitted from this copy
- Section 23 · 11,985 characters · omitted from this copy
- Section 24 · 11,356 characters · omitted from this copy
- Section 25 · 11,692 characters · omitted from this copy
- Section 26 · 10,819 characters · omitted from this copy
- Section 27 · 8,255 characters · omitted from this copy
- Section 28 · 7,879 characters · omitted from this copy
- Section 29 · 11,090 characters · omitted from this copy
- Section 30 · 8,826 characters · omitted from this copy
- Section 31 · 10,824 characters · omitted from this copy
- Section 32 · 11,092 characters · omitted from this copy
- Section 33 · 11,997 characters · omitted from this copy
- Section 34 · 11,848 characters · omitted from this copy
- Section 35 · 11,974 characters · omitted from this copy
- Section 36 · 11,956 characters · omitted from this copy
- Section 37 · 11,971 characters · omitted from this copy
- Section 38 · 11,659 characters · omitted from this copy
- Section 39 · 11,792 characters · omitted from this copy
- Section 40 · 11,742 characters · omitted from this copy
- Section 41 · 11,939 characters · omitted from this copy
- Section 42 · 11,967 characters · omitted from this copy
- Section 43 · 11,739 characters · omitted from this copy
- Section 44 · 11,803 characters · omitted from this copy
- Section 45 · 11,636 characters · omitted from this copy
- Section 46 · 11,994 characters · omitted from this copy
- Section 47 · 11,891 characters · omitted from this copy
- Section 48 · 11,802 characters · omitted from this copy
- Section 49 · 11,889 characters · omitted from this copy
- Section 50 · 11,855 characters · omitted from this copy
- Section 51 · 11,947 characters · omitted from this copy
- Section 52 · 11,821 characters · omitted from this copy
- Section 53 · 11,906 characters · omitted from this copy
- Section 54 · 11,673 characters · omitted from this copy
- Section 55 · 11,946 characters · omitted from this copy
- Section 56 · 11,803 characters · omitted from this copy
- Section 57 · 11,837 characters · omitted from this copy
- Section 58 · 11,670 characters · omitted from this copy
- Section 59 · 11,771 characters · omitted from this copy
- Section 60 · 11,715 characters · omitted from this copy
- Section 61 · 11,877 characters · omitted from this copy
- Section 62 · 11,908 characters · omitted from this copy
- Section 63 · 11,619 characters · omitted from this copy
- Section 64 · 11,841 characters · omitted from this copy
- Section 65 · 11,888 characters · omitted from this copy
- Section 66 · 11,932 characters · omitted from this copy
- Section 67 · 11,866 characters · omitted from this copy
- Section 68 · 11,813 characters · omitted from this copy
- Section 69 · 11,936 characters · omitted from this copy
- Section 70 · 11,864 characters · omitted from this copy
- Section 71 · 11,870 characters · omitted from this copy
- Section 72 · 11,987 characters · omitted from this copy
- Section 73 · 11,874 characters · omitted from this copy
- Section 74 · 11,987 characters · omitted from this copy
- Section 75 · 11,918 characters · omitted from this copy
- Section 76 · 9,012 characters · omitted from this copy
- Section 77 · 10,356 characters · omitted from this copy
- Section 78 · 11,778 characters · omitted from this copy
- Section 79 · 11,819 characters · omitted from this copy
- Section 80 · 7,757 characters · omitted from this copy
- Section 81 · 11,595 characters · omitted from this copy
- Section 82 · 11,956 characters · omitted from this copy
- Section 83 · 9,894 characters · omitted from this copy

```text
## 1. Basalt: Fast Blackwell inference engine for Qwen 3.8 Flash ... - Reddit

https://www.reddit.com/r/LocalLLaMA/comments/1x4xmxb/basalt_fast_blackwell_inference_engine_for_qwen/

Oct 13, 2026 ... Basalt is a C++/CUDA engine for Qwen3.8-Flash-Next that keeps the routed experts in system RAM and streams what its VRAM cache misses. ninfer- ...

[Skip to main content](https://www.reddit.com/r/LocalLLaMA/comments/1x4xmxb/basalt_fast_blackwell_inference_engine_for_qwen/?solution=501b719a975b33f8501b719a975b33f8&js_challenge=1&jsc_token=2824be10929bdc604753c70a67a1c331d56b1cb5d4807c284c155df9ad34f9e0&jsc_orig_r=#main-content)
 Basalt: Fast Blackwell inference engine for Qwen 3.8 Flash Next (and how we got vision for free) : r/LocalLLaMA

[![](https://styles.redditmedia.com/t5_81eyvm/styles/communityIcon_cumnsvx9kzma1.png?width=96&height=96&frame=1&auto=webp&s=a5f00ebcb6dcd381b6e081d0764399f7e70108f0)\
\
Go to LocalLLaMA](https://applink.reddit.com/r/LocalLLaMA/?utm_source=app_first_navigation&mweb_loid=t2_2r6ghuyasg&ext-referrer=DIRECT)

[r/LocalLLaMA](https://applink.reddit.com/r/LocalLLaMA/?utm_source=app_first_navigation&mweb_loid=t2_2r6ghuyasg&ext-referrer=DIRECT)  ![](https://emoji.redditmedia.com/23w2nhjj1e9f1_t5_81eyvm/Llama)1mo ago

[u/jesdga95](https://applink.reddit.com/user/jesdga95/?utm_source=app_first_navigation&mweb_loid=t2_2r6ghuyasg&ext-referrer=DIRECT)

Basalt: Fast Blackwell inference engine for Qwen 3.8 Flash Next (and how we got vision for free)
================================================================================================

[Discussion](https://www.reddit.com/r/LocalLLaMA/?f=flair_name%3A%22Discussion%22)

[![r/LocalLLaMA - Dynamic vision, in action](https://preview.redd.it/basalt-fast-blackwell-inference-engine-for-qwen-3-8-flash-v0-8aj1rjn3p8vh1.png?width=1200&format=png&auto=webp&s=4351e8809cf815a3d0c990712a95e53dc9fed7bd)](https://preview.redd.it/basalt-fast-blackwell-inference-engine-for-qwen-3-8-flash-v0-8aj1rjn3p8vh1.png?width=1200&format=png&auto=webp&s=4351e8809cf815a3d0c990712a95e53dc9fed7bd "Image from r/LocalLLaMA - Dynamic vision, in action")

Dynamic vision, in action

Basalt is an inference engine for 3.8 Flash Next, forked from [Strata](https://github.com/Niko1221/Strata)
 and heavily tuned for Blackwell. It supports vision, and for this to work you need to have the image encoder either in VRAM or CPU all the time, having it on VRAM takes valuable space from experts that would otherwise stay in the fast memory and CPU encoding is SLOW.

After launch, [u/rkfg\_me](https://www.reddit.com/user/rkfg_me/)
 brought up a simple question: why keep it loaded at all? this was actually a great idea (thanks again!), so now basalt supports `--vision dynamic`:

*   When idle the encoder lives in RAM, close to 0 VRAM used at load.
    
*   When the image arrives, the engine uses some of the expert cache slots, uploads the encoder to VRAM (~30 ms) and encodes the image.
    
*   When it's done the same slots get refilled from RAM (~60 ms).
    
*   No image sent = free, no performance hit on text.
    

The encoder uses Basalt's kernels, up to 3x as fast as llama.cpp's. Basalt repo:

[https://github.com/jesdga95/basalt](https://github.com/jesdga95/basalt)

\----- For DEVS:

If you're interested to port this to your own engine, these are the commit hashes with the implementation (Basalt main branch): `9bfb90a, a704c65, efd23d9`

Read more

Share [](https://alb.reddit.com/cr?za=Cl6tXqApdbWKgFSdgniXofGTt7BpkIiV3A_QSdVLWhgAXY0BqhoPck7BSy3WLk4y20x8JiKyfx4tnvOp0b_AjMEJhyFxm9mu8sEGWTqZ0xUT6cD_S9PWrImGRNegcAvj_vE6V7E3BCd0f3JcvHCouTXDrSgfMCtJMWIYLFOTk1-E_meGvG04bZdrr5EnDeqIxczuDjbQ_0vGcMMOER_n7lICJQB_qpFZBQh9eYk48GOVV9X7OTvDzfQUeHJI5-dyr_lB9t8XzvQtffHsqdCOMlTCms4rUt8d6A_vb8konuoAOimDlJKp3-uvRbCVQ6trfGqefg1EQIGq3PxehBk4Kk_NwKeWdfNciBLtjDnGsiB6HzqsMlYQXbfE62MegF5CMQpe9DfjIKuzRSJ-9pWkVPNn8r5ugCAazR0S8mSKY3_YMFs6dKtzghlI7xsF6DbbX7Vd2nQqL-hviTb0qDov2Iks8552laQ_uKTkAPOJT03VupPqrgL44qRy3rw2UMEbgt5QU6_uywvXwx8ja-GtThIIsLk4Iy3hHvBTzm2APNgmHiRhPWihRR_xLp9IZg48kkfOldrt6yRb_j3jEHTBGLE7j2z2FcWg-45mITNqokgIuT9s1CH0fTCECsLTimtoJE2vmC7CoLKWJ4PVFsLZh27wAfOaTJhlFFtIZntJoA_s0K6Og8yavxYn7ctIDGhB9-nbLN4rQuSK2shIcW2sFmaPN__PmoocC9gcaNchjk4fQigksEmO5AwfWDFlX5C362K4sjuCIqK06p73ZruIit0GrMUNso92_RsQKEAG4oVN7phU&zp=dAZlWSWZ3Ed7N3PNB4DbRR_oDAnGqyHqyFDHTpQ8_QrLWReGRG6CY1GpGxnoGGBgpu8K_wjCMVC1lxS8fAi-W67UzWUAfwj97ypMykl8dkfPhrUZzD_vMLVZbNa8yRFgoACUEAprn0sP9mvp7cEcEuOniFZnIiMHP5SmpdGTJm4P71q2hvGYcFeM19sqMLLyEWPkTGN1zlvyG69MIq9CGEh_VjbarXanGUEWmLiSPqY406pb_A92qTXtRmcH2i55Jn35BzKHLTWx_KiNvVm6Gb18V4qBoeu-8eaOLpPvR2WCTUfh7DV8DQDRxbD7eMz5z7QiNNBo8urOglYlEcoANC-Y8NHG1UjRi9CXT-oYk-lVl8xemX9rHU1QbJkYObXmIEXx-aGoOJ73fbg6_Emfobb5dIIbN3E5wOulbUDcLf2rJv6TER6SADo)

 [![u/LowesHomeImprovement avatar](https://styles.redditmedia.com/t5_2srlvw/styles/profileIcon_ic1acnnq71sc1.jpg?width=48&height=48&frame=1&auto=webp&crop=48%3A48%2Csmart&s=d2119e77830a6f97f5d05982c38539737bb2d5dd)LowesHomeImprovement](https://www.reddit.com/user/LowesHomeImprovement/) • [Ad](https://www.reddit.com/user/LowesHomeImprovement/)
[](https://alb.reddit.com/cr?za=Cl6tXqApdbWKgFSdgniXofGTt7BpkIiV3A_QSdVLWhgAXY0BqhoPck7BSy3WLk4y20x8JiKyfx4tnvOp0b_AjMEJhyFxm9mu8sEGWTqZ0xUT6cD_S9PWrImGRNegcAvj_vE6V7E3BCd0f3JcvHCouTXDrSgfMCtJMWIYLFOTk1-E_meGvG04bZdrr5EnDeqIxczuDjbQ_0vGcMMOER_n7lICJQB_qpFZBQh9eYk48GOVV9X7OTvDzfQUeHJI5-dyr_lB9t8XzvQtffHsqdCOMlTCms4rUt8d6A_vb8konuoAOimDlJKp3-uvRbCVQ6trfGqefg1EQIGq3PxehBk4Kk_NwKeWdfNciBLtjDnGsiB6HzqsMlYQXbfE62MegF5CMQpe9DfjIKuzRSJ-9pWkVPNn8r5ugCAazR0S8mSKY3_YMFs6dKtzghlI7xsF6DbbX7Vd2nQqL-hviTb0qDov2Iks8552laQ_uKTkAPOJT03VupPqrgL44qRy3rw2UMEbgt5QU6_uywvXwx8ja-GtThIIsLk4Iy3hHvBTzm2APNgmHiRhPWihRR_xLp9IZg48kkfOldrt6yRb_j3jEHTBGLE7j2z2FcWg-45mITNqokgIuT9s1CH0fTCECsLTimtoJE2vmC7CoLKWJ4PVFsLZh27wAfOaTJhlFFtIZntJoA_s0K6Og8yavxYn7ctIDGhB9-nbLN4rQuSK2shIcW2sFmaPN__PmoocC9gcaNchjk4fQigksEmO5AwfWDFlX5C362K4sjuCIqK06p73ZruIit0GrMUNso92_RsQKEAG4oVN7phU&zp=dAZlWSWZ3Ed7N3PNB4DbRR_oDAnGqyHqyFDHTpQ8_QrLWReGRG6CY1GpGxnoGGBgpu8K_wjCMVC1lxS8fAi-W67UzWUAfwj97ypMykl8dkfPhrUZzD_vMLVZbNa8yRFgoACUEAprn0sP9mvp7cEcEuOniFZnIiMHP5SmpdGTJm4P71q2hvGYcFeM19sqMLLyEWPkTGN1zlvyG69MIq9CGEh_VjbarXanGUEWmLiSPqY406pb_A92qTXtRmcH2i55Jn35BzKHLTWx_KiNvVm6Gb18V4qBoeu-8eaOLpPvR2WCTUfh7DV8DQDRxbD7eMz5z7QiNNBo8urOglYlEcoANC-Y8NHG1UjRi9CXT-oYk-lVl8xemX9rHU1QbJkYObXmIEXx-aGoOJ73fbg6_Emfobb5dIIbN3E5wOulbUDcLf2rJv6TER6SADo)

[¿Estás buscando decoraciones navideñas a buen precio? ¡No se diga más! Encuéntralas por menos de $20 en Lowe’s. También tenemos luces para que tu casa logre un ambiente acogedor por menos.](https://alb.reddit.com/cr?za=Cl6tXqApdbWKgFSdgniXofGTt7BpkIiV3A_QSdVLWhgAXY0BqhoPck7BSy3WLk4y20x8JiKyfx4tnvOp0b_AjMEJhyFxm9mu8sEGWTqZ0xUT6cD_S9PWrImGRNegcAvj_vE6V7E3BCd0f3JcvHCouTXDrSgfMCtJMWIYLFOTk1-E_meGvG04bZdrr5EnDeqIxczuDjbQ_0vGcMMOER_n7lICJQB_qpFZBQh9eYk48GOVV9X7OTvDzfQUeHJI5-dyr_lB9t8XzvQtffHsqdCOMlTCms4rUt8d6A_vb8konuoAOimDlJKp3-uvRbCVQ6trfGqefg1EQIGq3PxehBk4Kk_NwKeWdfNciBLtjDnGsiB6HzqsMlYQXbfE62MegF5CMQpe9DfjIKuzRSJ-9pWkVPNn8r5ugCAazR0S8mSKY3_YMFs6dKtzghlI7xsF6DbbX7Vd2nQqL-hviTb0qDov2Iks8552laQ_uKTkAPOJT03VupPqrgL44qRy3rw2UMEbgt5QU6_uywvXwx8ja-GtThIIsLk4Iy3hHvBTzm2APNgmHiRhPWihRR_xLp9IZg48kkfOldrt6yRb_j3jEHTBGLE7j2z2FcWg-45mITNqokgIuT9s1CH0fTCECsLTimtoJE2vmC7CoLKWJ4PVFsLZh27wAfOaTJhlFFtIZntJoA_s0K6Og8yavxYn7ctIDGhB9-nbLN4rQuSK2shIcW2sFmaPN__PmoocC9gcaNchjk4fQigksEmO5AwfWDFlX5C362K4sjuCIqK06p73ZruIit0GrMUNso92_RsQKEAG4oVN7phU&zp=dAZlWSWZ3Ed7N3PNB4DbRR_oDAnGqyHqyFDHTpQ8_QrLWReGRG6CY1GpGxnoGGBgpu8K_wjCMVC1lxS8fAi-W67UzWUAfwj97ypMykl8dkfPhrUZzD_vMLVZbNa8yRFgoACUEAprn0sP9mvp7cEcEuOniFZnIiMHP5SmpdGTJm4P71q2hvGYcFeM19sqMLLyEWPkTGN1zlvyG69MIq9CGEh_VjbarXanGUEWmLiSPqY406pb_A92qTXtRmcH2i55Jn35BzKHLTWx_KiNvVm6Gb18V4qBoeu-8eaOLpPvR2WCTUfh7DV8DQDRxbD7eMz5z7QiNNBo8urOglYlEcoANC-Y8NHG1UjRi9CXT-oYk-lVl8xemX9rHU1QbJkYObXmIEXx-aGoOJ73fbg6_Emfobb5dIIbN3E5wOulbUDcLf2rJv6TER6SADo)

[](https://alb.reddit.com/cr?za=Cl6tXqApdbWKgFSdgniXofGTt7BpkIiV3A_QSdVLWhgAXY0BqhoPck7BSy3WLk4y20x8JiKyfx4tnvOp0b_AjMEJhyFxm9mu8sEGWTqZ0xUT6cD_S9PWrImGRNegcAvj_vE6V7E3BCd0f3JcvHCouTXDrSgfMCtJMWIYLFOTk1-E_meGvG04bZdrr5EnDeqIxczuDjbQ_0vGcMMOER_n7lICJQB_qpFZBQh9eYk48GOVV9X7OTvDzfQUeHJI5-dyr_lB9t8XzvQtffHsqdCOMlTCms4rUt8d6A_vb8konuoAOimDlJKp3-uvRbCVQ6trfGqefg1EQIGq3PxehBk4Kk_NwKeWdfNciBLtjDnGsiB6HzqsMlYQXbfE62MegF5CMQpe9DfjIKuzRSJ-9pWkVPNn8r5ugCAazR0S8mSKY3_YMFs6dKtzghlI7xsF6DbbX7Vd2nQqL-hviTb0qDov2Iks8552laQ_uKTkAPOJT03VupPqrgL44qRy3rw2UMEbgt5QU6_uywvXwx8ja-GtThIIsLk4Iy3hHvBTzm2APNgmHiRhPWihRR_xLp9IZg48kkfOldrt6yRb_j3jEHTBGLE7j2z2FcWg-45mITNqokgIuT9s1CH0fTCECsLTimtoJE2vmC7CoLKWJ4PVFsLZh27wAfOaTJhlFFtIZntJoA_s0K6Og8yavxYn7ctIDGhB9-nbLN4rQuSK2shIcW2sFmaPN__PmoocC9gcaNchjk4fQigksEmO5AwfWDFlX5C362K4sjuCIqK06p73ZruIit0GrMUNso92_RsQKEAG4oVN7phU&zp=dAZlWSWZ3Ed7N3PNB4DbRR_oDAnGqyHqyFDHTpQ8_QrLWReGRG6CY1GpGxnoGGBgpu8K_wjCMVC1lxS8fAi-W67UzWUAfwj97ypMykl8dkfPhrUZzD_vMLVZbNa8yRFgoACUEAprn0sP9mvp7cEcEuOniFZnIiMHP5SmpdGTJm4P71q2hvGYcFeM19sqMLLyEWPkTGN1zlvyG69MIq9CGEh_VjbarXanGUEWmLiSPqY406pb_A92qTXtRmcH2i55Jn35BzKHLTWx_KiNvVm6Gb18V4qBoeu-8eaOLpPvR2WCTUfh7DV8DQDRxbD7eMz5z7QiNNBo8urOglYlEcoANC-Y8NHG1UjRi9CXT-oYk-lVl8xemX9rHU1QbJkYObXmIEXx-aGoOJ73fbg6_Emfobb5dIIbN3E5wOulbUDcLf2rJv6TER6SADo)

[![¿Estás buscando decoraciones navideñas a buen precio? ¡No se diga más! Encuéntralas por menos de $20 en Lowe’s. También tenemos luces para que tu casa logre un ambiente acogedor por menos.](https://preview.redd.it/6eneqivfx7yh1.png?width=640&crop=smart&auto=webp&s=4f4da54c66ea3c26fdfd14943bfbe5e59e8b106c)](https://alb.reddit.com/cr?za=Cl6tXqApdbWKgFSdgniXofGTt7BpkIiV3A_QSdVLWhgAXY0BqhoPck7BSy3WLk4y20x8JiKyfx4tnvOp0b_AjMEJhyFxm9mu8sEGWTqZ0xUT6cD_S9PWrImGRNegcAvj_vE6V7E3BCd0f3JcvHCouTXDrSgfMCtJMWIYLFOTk1-E_meGvG04bZdrr5EnDeqIxczuDjbQ_0vGcMMOER_n7lICJQB_qpFZBQh9eYk48GOVV9X7OTvDzfQUeHJI5-dyr_lB9t8XzvQtffHsqdCOMlTCms4rUt8d6A_vb8konuoAOimDlJKp3-uvRbCVQ6trfGqefg1EQIGq3PxehBk4Kk_NwKeWdfNciBLtjDnGsiB6HzqsMlYQXbfE62MegF5CMQpe9DfjIKuzRSJ-9pWkVPNn8r5ugCAazR0S8mSKY3_YMFs6dKtzghlI7xsF6DbbX7Vd2nQqL-hviTb0qDov2Iks8552laQ_uKTkAPOJT03VupPqrgL44qRy3rw2UMEbgt5QU6_uywvXwx8ja-GtThIIsLk4Iy3hHvBTzm2APNgmHiRhPWihRR_xLp9IZg48kkfOldrt6yRb_j3jEHTBGLE7j2z2FcWg-45mITNqokgIuT9s1CH0fTCECsLTimtoJE2vmC7CoLKWJ4PVFsLZh27wAfOaTJhlFFtIZntJoA_s0K6Og8yavxYn7ctIDGhB9-nbLN4rQuSK2shIcW2sFmaPN__PmoocC9gcaNchjk4fQigksEmO5AwfWDFlX5C362K4sjuCIqK06p73ZruIit0GrMUNso92_RsQKEAG4oVN7phU&zp=dAZlWSWZ3Ed7N3PNB4DbRR_oDAnGqyHqyFDHTpQ8_QrLWReGRG6CY1GpGxnoGGBgpu8K_wjCMVC1lxS8fAi-W67UzWUAfwj97ypMykl8dkfPhrUZzD_vMLVZbNa8yRFgoACUEAprn0sP9mvp7cEcEuOniFZnIiMHP5SmpdGTJm4P71q2hvGYcFeM19sqMLLyEWPkTGN1zlvyG69MIq9CGEh_VjbarXanGUEWmLiSPqY406pb_A92qTXtRmcH2i55Jn35BzKHLTWx_KiNvVm6Gb18V4qBoeu-8eaOLpPvR2WCTUfh7DV8DQDRxbD7eMz5z7QiNNBo8urOglYlEcoANC-Y8NHG1UjRi9CXT-oYk-lVl8xemX9rHU1QbJkYObXmIEXx-aGoOJ73fbg6_Emfobb5dIIbN3E5wOulbUDcLf2rJv6TER6SADo)

```

</details>

<details><summary>Tool result · web_search · call_ab0efa4a7069427ea072c10b</summary>

**Firecrawl · section 1 of 46**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,651 characters · included below
- Section 2 · 12,001 characters · omitted from this copy
- Section 3 · 8,499 characters · omitted from this copy
- Section 4 · 11,959 characters · omitted from this copy
- Section 5 · 11,053 characters · omitted from this copy
- Section 6 · 11,886 characters · omitted from this copy
- Section 7 · 11,962 characters · omitted from this copy
- Section 8 · 11,902 characters · omitted from this copy
- Section 9 · 10,276 characters · omitted from this copy
- Section 10 · 11,965 characters · omitted from this copy
- Section 11 · 11,054 characters · omitted from this copy
- Section 12 · 11,891 characters · omitted from this copy
- Section 13 · 10,857 characters · omitted from this copy
- Section 14 · 11,752 characters · omitted from this copy
- Section 15 · 11,931 characters · omitted from this copy
- Section 16 · 9,196 characters · omitted from this copy
- Section 17 · 10,133 characters · omitted from this copy
- Section 18 · 11,742 characters · omitted from this copy
- Section 19 · 11,846 characters · omitted from this copy
- Section 20 · 11,762 characters · omitted from this copy
- Section 21 · 11,319 characters · omitted from this copy
- Section 22 · 11,594 characters · omitted from this copy
- Section 23 · 11,498 characters · omitted from this copy
- Section 24 · 11,343 characters · omitted from this copy
- Section 25 · 9,763 characters · omitted from this copy
- Section 26 · 11,901 characters · omitted from this copy
- Section 27 · 11,899 characters · omitted from this copy
- Section 28 · 11,053 characters · omitted from this copy
- Section 29 · 11,939 characters · omitted from this copy
- Section 30 · 11,827 characters · omitted from this copy
- Section 31 · 11,808 characters · omitted from this copy
- Section 32 · 11,941 characters · omitted from this copy
- Section 33 · 11,460 characters · omitted from this copy
- Section 34 · 11,988 characters · omitted from this copy
- Section 35 · 9,389 characters · omitted from this copy
- Section 36 · 11,798 characters · omitted from this copy
- Section 37 · 11,906 characters · omitted from this copy
- Section 38 · 7,418 characters · omitted from this copy
- Section 39 · 11,897 characters · omitted from this copy
- Section 40 · 11,980 characters · omitted from this copy
- Section 41 · 11,634 characters · omitted from this copy
- Section 42 · 10,214 characters · omitted from this copy
- Section 43 · 11,997 characters · omitted from this copy
- Section 44 · 10,781 characters · omitted from this copy
- Section 45 · 11,959 characters · omitted from this copy
- Section 46 · 2,240 characters · omitted from this copy

```text
## 1. GitHub - iamwavecut/ninfer-all: One line of NInfer for the Blackwell ...

https://github.com/iamwavecut/ninfer-all

... kv-dtype bf16p , BF16's KV bits in 23% fewer bytes. ... 2026-10-27: Tensor parallelism speeds up decode without peer access and covers all Flash-Next layers.

[Skip to content](https://github.com/iamwavecut/ninfer-all#start-of-content)
              

You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all)
 to refresh your session. Dismiss alert

           [](https://github.com/iamwavecut/ninfer-all)

master

[**2** Branches](https://github.com/iamwavecut/ninfer-all/branches)
[**42** Tags](https://github.com/iamwavecut/ninfer-all/tags)

[](https://github.com/iamwavecut/ninfer-all/branches)
[](https://github.com/iamwavecut/ninfer-all/tags)

Go to file

Code

Open more actions menu

This branch is [1408 commits ahead of](https://github.com/iamwavecut/ninfer-all/compare/Don-Chad%3Aninfer-3090%3Amaster...master)
 and [854 commits behind](https://github.com/iamwavecut/ninfer-all/compare/master...Don-Chad%3Aninfer-3090%3Amaster)
 Don-Chad/ninfer-3090:master.

Latest commit
-------------

[![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=40)](https://github.com/iamwavecut)
[iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

[Merge pull request](https://github.com/iamwavecut/ninfer-all/commit/a3171940a3574cda4d4f3bc3000df7c0944e8ad8)
 [#370](https://github.com/iamwavecut/ninfer-all/pull/370)
 [from iamwavecut/dev/decision-read-stop-token](https://github.com/iamwavecut/ninfer-all/commit/a3171940a3574cda4d4f3bc3000df7c0944e8ad8)

Open commit detailssuccess

Nov 16, 2026

[a317194](https://github.com/iamwavecut/ninfer-all/commit/a3171940a3574cda4d4f3bc3000df7c0944e8ad8)
 · Nov 16, 2026

History
-------

[3,330 Commits](https://github.com/iamwavecut/ninfer-all/commits/master/)

Open commit details

[](https://github.com/iamwavecut/ninfer-all/commits/master/)
3,330 Commits

Folders and files
-----------------

| Name |     | Name | Last commit message | Last commit date |
| --- | --- | --- | --- |
| [.codex](https://github.com/iamwavecut/ninfer-all/tree/master/.codex ".codex") |     | [.codex](https://github.com/iamwavecut/ninfer-all/tree/master/.codex ".codex") |     |     |
| [.github](https://github.com/iamwavecut/ninfer-all/tree/master/.github ".github") |     | [.github](https://github.com/iamwavecut/ninfer-all/tree/master/.github ".github") |     |     |
| [apps](https://github.com/iamwavecut/ninfer-all/tree/master/apps "apps") |     | [apps](https://github.com/iamwavecut/ninfer-all/tree/master/apps "apps") |     |     |
| [bench](https://github.com/iamwavecut/ninfer-all/tree/master/bench "bench") |     | [bench](https://github.com/iamwavecut/ninfer-all/tree/master/bench "bench") |     |     |
| [cmake](https://github.com/iamwavecut/ninfer-all/tree/master/cmake "cmake") |     | [cmake](https://github.com/iamwavecut/ninfer-all/tree/master/cmake "cmake") |     |     |
| [configs](https://github.com/iamwavecut/ninfer-all/tree/master/configs "configs") |     | [configs](https://github.com/iamwavecut/ninfer-all/tree/master/configs "configs") |     |     |
| [docker](https://github.com/iamwavecut/ninfer-all/tree/master/docker "docker") |     | [docker](https://github.com/iamwavecut/ninfer-all/tree/master/docker "docker") |     |     |
| [docs](https://github.com/iamwavecut/ninfer-all/tree/master/docs "docs") |     | [docs](https://github.com/iamwavecut/ninfer-all/tree/master/docs "docs") |     |     |
| [eval](https://github.com/iamwavecut/ninfer-all/tree/master/eval "eval") |     | [eval](https://github.com/iamwavecut/ninfer-all/tree/master/eval "eval") |     |     |
| [examples/cli](https://github.com/iamwavecut/ninfer-all/tree/master/examples/cli "This path skips through empty directories") |     | [examples/cli](https://github.com/iamwavecut/ninfer-all/tree/master/examples/cli "This path skips through empty directories") |     |     |
| [include/ninfer](https://github.com/iamwavecut/ninfer-all/tree/master/include/ninfer "This path skips through empty directories") |     | [include/ninfer](https://github.com/iamwavecut/ninfer-all/tree/master/include/ninfer "This path skips through empty directories") |     |     |
| [kernel/ninfer-direct](https://github.com/iamwavecut/ninfer-all/tree/master/kernel/ninfer-direct "This path skips through empty directories") |     | [kernel/ninfer-direct](https://github.com/iamwavecut/ninfer-all/tree/master/kernel/ninfer-direct "This path skips through empty directories") |     |     |
| [scripts](https://github.com/iamwavecut/ninfer-all/tree/master/scripts "scripts") |     | [scripts](https://github.com/iamwavecut/ninfer-all/tree/master/scripts "scripts") |     |     |
| [src](https://github.com/iamwavecut/ninfer-all/tree/master/src "src") |     | [src](https://github.com/iamwavecut/ninfer-all/tree/master/src "src") |     |     |
| [tests](https://github.com/iamwavecut/ninfer-all/tree/master/tests "tests") |     | [tests](https://github.com/iamwavecut/ninfer-all/tree/master/tests "tests") |     |     |
| [third\_party](https://github.com/iamwavecut/ninfer-all/tree/master/third_party "third_party") |     | [third\_party](https://github.com/iamwavecut/ninfer-all/tree/master/third_party "third_party") |     |     |
| [tools](https://github.com/iamwavecut/ninfer-all/tree/master/tools "tools") |     | [tools](https://github.com/iamwavecut/ninfer-all/tree/master/tools "tools") |     |     |
| [.clang-format](https://github.com/iamwavecut/ninfer-all/blob/master/.clang-format ".clang-format") |     | [.clang-format](https://github.com/iamwavecut/ninfer-all/blob/master/.clang-format ".clang-format") |     |     |
| [.clangd](https://github.com/iamwavecut/ninfer-all/blob/master/.clangd ".clangd") |     | [.clangd](https://github.com/iamwavecut/ninfer-all/blob/master/.clangd ".clangd") |     |     |
| [.dockerignore](https://github.com/iamwavecut/ninfer-all/blob/master/.dockerignore ".dockerignore") |     | [.dockerignore](https://github.com/iamwavecut/ninfer-all/blob/master/.dockerignore ".dockerignore") |     |     |
| [.gitattributes](https://github.com/iamwavecut/ninfer-all/blob/master/.gitattributes ".gitattributes") |     | [.gitattributes](https://github.com/iamwavecut/ninfer-all/blob/master/.gitattributes ".gitattributes") |     |     |
| [.gitignore](https://github.com/iamwavecut/ninfer-all/blob/master/.gitignore ".gitignore") |     | [.gitignore](https://github.com/iamwavecut/ninfer-all/blob/master/.gitignore ".gitignore") |     |     |
| [AGENTS.md](https://github.com/iamwavecut/ninfer-all/blob/master/AGENTS.md "AGENTS.md") |     | [AGENTS.md](https://github.com/iamwavecut/ninfer-all/blob/master/AGENTS.md "AGENTS.md") |     |     |
| [CMakeLists.txt](https://github.com/iamwavecut/ninfer-all/blob/master/CMakeLists.txt "CMakeLists.txt") |     | [CMakeLists.txt](https://github.com/iamwavecut/ninfer-all/blob/master/CMakeLists.txt "CMakeLists.txt") |     |     |
| [CMakePresets.json](https://github.com/iamwavecut/ninfer-all/blob/master/CMakePresets.json "CMakePresets.json") |     | [CMakePresets.json](https://github.com/iamwavecut/ninfer-all/blob/master/CMakePresets.json "CMakePresets.json") |     |     |
| [CONTRIBUTING.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTING.md "CONTRIBUTING.md") |     | [CONTRIBUTING.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTING.md "CONTRIBUTING.md") |     |     |
| [CONTRIBUTORS.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTORS.md "CONTRIBUTORS.md") |     | [CONTRIBUTORS.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTORS.md "CONTRIBUTORS.md") |     |     |
| [Dockerfile](https://github.com/iamwavecut/ninfer-all/blob/master/Dockerfile "Dockerfile") |     | [Dockerfile](https://github.com/iamwavecut/ninfer-all/blob/master/Dockerfile "Dockerfile") |     |     |
| [LICENSE](https://github.com/iamwavecut/ninfer-all/blob/master/LICENSE "LICENSE") |     | [LICENSE](https://github.com/iamwavecut/ninfer-all/blob/master/LICENSE "LICENSE") |     |     |
| [README.md](https://github.com/iamwavecut/ninfer-all/blob/master/README.md "README.md") |     | [README.md](https://github.com/iamwavecut/ninfer-all/blob/master/README.md "README.md") |     |     |
| [build\_merge.bat](https://github.com/iamwavecut/ninfer-all/blob/master/build_merge.bat "build_merge.bat") |     | [build\_merge.bat](https://github.com/iamwavecut/ninfer-all/blob/master/build_merge.bat "build_merge.bat") |     |     |
| [build\_only.bat](https://github.com/iamwavecut/ninfer-all/blob/master/build_only.bat "build_only.bat") |     | [build\_only.bat](https://github.com/iamwavecut/ninfer-all/blob/master/build_only.bat "build_only.bat") |     |     |
| [compose.yaml](https://github.com/iamwavecut/ninfer-all/blob/master/compose.yaml "compose.yaml") |     | [compose.yaml](https://github.com/iamwavecut/ninfer-all/blob/master/compose.yaml "compose.yaml") |     |     |
| [flake.lock](https://github.com/iamwavecut/ninfer-all/blob/master/flake.lock "flake.lock") |     | [flake.lock](https://github.com/iamwavecut/ninfer-all/blob/master/flake.lock "flake.lock") |     |     |
| [flake.nix](https://github.com/iamwavecut/ninfer-all/blob/master/flake.nix "flake.nix") |     | [flake.nix](https://github.com/iamwavecut/ninfer-all/blob/master/flake.nix "flake.nix") |     |     |
| [vcpkg.json](https://github.com/iamwavecut/ninfer-all/blob/master/vcpkg.json "vcpkg.json") |     | [vcpkg.json](https://github.com/iamwavecut/ninfer-all/blob/master/vcpkg.json "vcpkg.json") |     |     |
| View all files |     |     |

Repository files navigation
---------------------------

NInfer-all
==========

[](https://github.com/iamwavecut/ninfer-all#ninfer-all)

A C++/CUDA inference engine for the Qwen3.5 model family (Qwen3.6 and Qwen3.8 27B, Qwen3.6-35B-A3B, their fine-tunes and Ternary Bonsai 2), Qwen3.8-Flash-Next and Edge0's latent-MoE models built on it, Gemma 4 26B-A4B, Recursive's Flint and DeepSeek-V4.1-Flash, on NVIDIA GPUs from Volta to consumer Blackwell, from 8 GB of memory. It serves the OpenAI, Anthropic and llama.cpp APIs from one GPU, or from up to eight as pipeline stages on Linux. The same chat model answers [typed decisions](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#typed-decisions)
: choice, yes/no and score questions about a state, each option with its probability, through TypeSafe's System One and OpenAI's Decisions APIs.

[What's New](https://github.com/iamwavecut/ninfer-all#whats-new)
 · [Quick start](https://github.com/iamwavecut/ninfer-all#quick-start)
 · [Supported GPUs](https://github.com/iamwavecut/ninfer-all#supported-gpus)
 · [Models](https://github.com/iamwavecut/ninfer-all#artifacts)
 · [Highlights](https://github.com/iamwavecut/ninfer-all#highlights)
 · [Features](https://github.com/iamwavecut/ninfer-all#features)
 · [Docker](https://github.com/iamwavecut/ninfer-all#docker)
 · [Building](https://github.com/iamwavecut/ninfer-all#building)
 · [Documentation](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md)

NInfer-all continues [NInfer](https://github.com/Neroued/ninfer)
 through the NInfer-3090 line and carries the work of several forks; [CONTRIBUTORS.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTORS.md)
 credits each of them.

Note

```

</details>

<details><summary>Tool result · web_search · call_494bdcdcc3ba490b924dedaf</summary>

**Firecrawl · section 1 of 67**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,950 characters · included below
- Section 2 · 11,722 characters · omitted from this copy
- Section 3 · 11,718 characters · omitted from this copy
- Section 4 · 11,902 characters · omitted from this copy
- Section 5 · 11,882 characters · omitted from this copy
- Section 6 · 11,513 characters · omitted from this copy
- Section 7 · 11,967 characters · omitted from this copy
- Section 8 · 11,978 characters · omitted from this copy
- Section 9 · 11,583 characters · omitted from this copy
- Section 10 · 10,916 characters · omitted from this copy
- Section 11 · 11,589 characters · omitted from this copy
- Section 12 · 11,643 characters · omitted from this copy
- Section 13 · 10,985 characters · omitted from this copy
- Section 14 · 11,950 characters · omitted from this copy
- Section 15 · 11,819 characters · omitted from this copy
- Section 16 · 11,005 characters · omitted from this copy
- Section 17 · 11,783 characters · omitted from this copy
- Section 18 · 10,922 characters · omitted from this copy
- Section 19 · 11,962 characters · omitted from this copy
- Section 20 · 11,993 characters · omitted from this copy
- Section 21 · 11,821 characters · omitted from this copy
- Section 22 · 11,840 characters · omitted from this copy
- Section 23 · 11,984 characters · omitted from this copy
- Section 24 · 11,987 characters · omitted from this copy
- Section 25 · 11,959 characters · omitted from this copy
- Section 26 · 11,935 characters · omitted from this copy
- Section 27 · 11,807 characters · omitted from this copy
- Section 28 · 11,944 characters · omitted from this copy
- Section 29 · 11,980 characters · omitted from this copy
- Section 30 · 11,932 characters · omitted from this copy
- Section 31 · 11,810 characters · omitted from this copy
- Section 32 · 11,601 characters · omitted from this copy
- Section 33 · 11,992 characters · omitted from this copy
- Section 34 · 11,977 characters · omitted from this copy
- Section 35 · 11,682 characters · omitted from this copy
- Section 36 · 11,993 characters · omitted from this copy
- Section 37 · 11,960 characters · omitted from this copy
- Section 38 · 11,990 characters · omitted from this copy
- Section 39 · 11,966 characters · omitted from this copy
- Section 40 · 11,903 characters · omitted from this copy
- Section 41 · 10,462 characters · omitted from this copy
- Section 42 · 11,690 characters · omitted from this copy
- Section 43 · 10,771 characters · omitted from this copy
- Section 44 · 11,525 characters · omitted from this copy
- Section 45 · 10,776 characters · omitted from this copy
- Section 46 · 11,208 characters · omitted from this copy
- Section 47 · 11,542 characters · omitted from this copy
- Section 48 · 11,943 characters · omitted from this copy
- Section 49 · 11,981 characters · omitted from this copy
- Section 50 · 11,710 characters · omitted from this copy
- Section 51 · 11,960 characters · omitted from this copy
- Section 52 · 10,153 characters · omitted from this copy
- Section 53 · 11,751 characters · omitted from this copy
- Section 54 · 11,249 characters · omitted from this copy
- Section 55 · 11,996 characters · omitted from this copy
- Section 56 · 11,589 characters · omitted from this copy
- Section 57 · 11,611 characters · omitted from this copy
- Section 58 · 11,448 characters · omitted from this copy
- Section 59 · 11,323 characters · omitted from this copy
- Section 60 · 11,847 characters · omitted from this copy
- Section 61 · 11,973 characters · omitted from this copy
- Section 62 · 11,541 characters · omitted from this copy
- Section 63 · 6,725 characters · omitted from this copy
- Section 64 · 11,861 characters · omitted from this copy
- Section 65 · 11,926 characters · omitted from this copy
- Section 66 · 11,920 characters · omitted from this copy
- Section 67 · 11,033 characters · omitted from this copy

```text
## 1. Qwen3.8-27B vs Qwen3.8-Flash-Next: Which One to Run Locally?

https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/

Oct 18, 2026 ... Added the Strata update showing how dynamic expert caching flipped the speed comparison against the 27B dense model. 2026-08-31, Initial head ...

[Skip to main content](https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/#main-content)

* * *

Copy as Markdown

[View Raw (.txt)](https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/raw.txt)

Outline

I run both siblings from Alibaba's Qwen3.8 lineup on [🧠 yeti-cachy](https://carteakey.dev/devices/yeti-cachy/)
:

*   **[Qwen3.8-27B](https://carteakey.dev/blog/local-inference/running-qwen3-8-27b-locally/)
    **, a dense hybrid model that fits completely inside my GPU's VRAM with zero host memory overhead.
*   **[Qwen3.8-Flash-Next](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/)
    **, a large sparse MoE paired with an external n-gram lookup table that spans VRAM, system RAM, and NVMe SSD.

They draw roughly the same wall power under load, but on a single mid-range card they can't sit in memory at the same time. Only one gets to be the default behind [llama-swap](https://github.com/mostlygeek/llama-swap)
. Here's how they compare on speed, memory, quality, and when I reach for each one.

TL;DR [#](https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/#tl-dr)

---------------------------------------------------------------------------------------

On Strata, **Flash-Next is my daily driver for almost everything**. It decodes nearly twice as fast as the dense model does on stock `llama.cpp`, prefills prompts at full GPU speed, and holds a real lead on multi-step coding and complex instructions.

I still keep **Qwen3.8-27B** on the roster for two specific jobs:

1.  **When my desktop needs its memory:** the dense model uses zero bytes of system RAM, whereas Flash-Next claims most of my host DDR5 for its offloaded experts.
2.  **When context goes past 128k:** three-quarters of the dense model's layers are linear Gated-DeltaNet blocks that don't grow a traditional KV cache, so it holds its full **262k context window** inside VRAM without breaking a sweat.

Measured head-to-head [#](https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/#measured-head-to-head)

-----------------------------------------------------------------------------------------------------------------------

All tests ran on [🧠 yeti-cachy](https://carteakey.dev/devices/yeti-cachy/)
 (i5-12600K, RTX 4070 12 GB, 64 GB DDR5, WD Black SN770 NVMe):

| Metric / Dimension | Qwen3.8-27B (UD-IQ3\_XXS) | Qwen3.8-Flash-Next (`llama.cpp` AD-4.27bpw) | Qwen3.8-Flash-Next (Strata IQ3\_XXS) |
| --- | --- | --- | --- |
| **Model Footprint** | 10.17 GiB (pure VRAM) | 88 GiB (split RAM+VRAM+NVMe) | 75.8 GiB (split RAM+VRAM+NVMe) |
| **Prompt Processing (Prefill)** | **~1,160 t/s** (pure GPU) | ~200 - 385 t/s | **1,138 - 2,013 t/s** |
| **Decode: Steady Generation** | **36.7 t/s** (flat across context) | 20.5 - 22.1 t/s (plain master) | **53.2 - 65.8 t/s** (74.8 t/s w/ Q8\_0 PLE) |
| **Decode: Speculative / MTP** | 36.7 t/s | 25.3 - 27.1 t/s (16k MTP) | Included above (native MTP) |
| **Max Working Context** | **262k native** (fits in VRAM) | 96k (`q8_0` KV) | **128k native** (`k8v4` KV) |
| **Host System RAM Load** | **0 GB** (pure GPU resident) | ~50 GiB RSS | **48 - 52 GiB RSS** |
| **Desktop Multitasking** | **Effortless** (all 64 GB RAM free) | Tight (desktop spikes risk swap) | Manageable (~12 GB headroom) |

![Horizontal bar chart of decode speed on an RTX 4070 12GB in tokens per second: 27B on llama.cpp 36.7, Flash-Next on llama.cpp 20.5, Flash-Next on llama.cpp with MTP 25.3, Flash-Next on Strata steady 53 to 63, Flash-Next on Strata burst 90.2 using a Q2_0 quant](https://carteakey.dev/img/M66o5cJTXS-1051.jpeg)

Decode speed across setups on the RTX 4070 12 GB.

The intelligence gap (~90 vs ~74 estimate) [#](https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/#the-intelligence-gap-90-vs-74-estimate)

-------------------------------------------------------------------------------------------------------------------------------------------------------------

Comparing raw foundation benchmarks without accounting for quantization doesn't tell the whole story when one model is a 3-bit dense quant and the other is a sparse MoE. To get a rough directional picture, I put together a back-of-the-envelope estimate combining [public LLM Stats benchmarks](https://llm-stats.com/models/compare/qwen3.7-plus-vs-qwen3.8-flash-next)
 with my own assumptions for quantization retention:

| Variant / Profile | Base Capability | Assumed Quant Retention | **Estimated Index** |
| --- | --- | --- | --- |
| **Qwen3.8-Flash-Next BF16** | 100 | 100% | **100** |
| **Qwen3.8-Flash-Next (Served quant)** | 100 | ~90% | **~90** |
| **Qwen3.8-27B BF16** | ~87 | 100% | **~87** |
| **Qwen3.8-27B (UD-IQ3\_XXS, 3.06 bpw)** | ~87 | ~85 - 87% | **~74** |

Treat that spread as a rule of thumb rather than a lab measurement:

*   **At full precision**, Flash-Next leads Qwen3.7-Plus and the dense model by roughly fifteen percent across GPQA, LiveCodeBench, and SWE-bench Verified.
*   **Under aggressive quantization**, a dense model has every parameter active on every token, so rounding error in the attention projections accumulates faster than it does in a sparse MoE whose router gates and isolated lookup table stay at higher precision.

In my day-to-day coding, that gap is easy to feel. The dense model occasionally slips on an off-by-one regex or drops a secondary constraint in a long multi-turn thread, while Flash-Next is much more reliable on the first pass.

How to choose between them [#](https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/#how-to-choose-between-them)

---------------------------------------------------------------------------------------------------------------------------------

You can generalize this choice to almost any compact dense model versus a large offloaded MoE:

| Gate | If your setup / task is… | Pick | Why |
| --- | --- | --- | --- |
| **1\. System RAM** | Under 64 GB host RAM | **Qwen3.8-27B** | Fits entirely in 10.2 GB VRAM and needs zero host RAM. The 88 GiB MoE file can't run comfortably in 32 GB. |
| **2\. GPU setup** | CPU-only or Apple Silicon | **Flash-Next** | Only ~6B active parameters per token, so it streams from RAM several times faster than a 27B dense model. |
| **3\. Workload on 12GB VRAM + 64GB RAM** | Heavy desktop multitasking, Docker builds, or >128k context (up to 262k) | **Qwen3.8-27B** | Leaves all 64 GB of system RAM free for your tools and holds 262k context inside VRAM at a flat 36.7 tok/s. |
|     | Dedicated coding agent, complex logic, or normal sessions under 128k | **Flash-Next (on Strata)** | Gives you the higher reasoning ceiling at 53 to 74.8 tok/s steady decode. (If you're stuck on stock `llama.cpp` at 20.5 tok/s, the 27B still wins on raw speed.) |

![Decision tree: if the MoE does not fit in RAM plus VRAM, pick Dense 27B; otherwise if there is no discrete GPU, pick the MoE; otherwise if you need over 128k context or free host RAM, pick Dense 27B, else the MoE (Flash-Next)](https://carteakey.dev/img/izDq3wCZz3-712.jpeg)

The three decision gates drawn as a flow.

Why Strata flipped the trade-off [#](https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/#why-strata-flipped-the-trade-off)

---------------------------------------------------------------------------------------------------------------------------------------------

When I only had stock `llama.cpp`, running Flash-Next meant accepting ~20 tok/s because almost all of its MoE layers were stuck in system RAM. [Strata](https://carteakey.dev/blog/local-inference/strata-on-an-rtx-4070/)
 broke that bottleneck by caching the hottest individual experts across every layer directly in VRAM and verifying multi-token draft predictions in a single pass.

Two fair caveats apply here: my dense model numbers are still on stock `llama.cpp` rather than a custom engine, and Strata runs a 3-bit quant rather than the 4.27-bit build I originally tested on `llama.cpp`. Even with those caveats, getting over 50 tok/s steady out of the larger MoE made it the clear default on my box, with the dense model reserved for heavy multitasking and ultra-long contexts.

References [#](https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/#references)

-------------------------------------------------------------------------------------------------

*   [Running Qwen3.8-27B Locally (Pure VRAM Configuration)](https://carteakey.dev/blog/local-inference/running-qwen3-8-27b-locally/)
    
*   [Running Qwen3.8-Flash-Next Locally (`llama.cpp` Guide)](https://carteakey.dev/blog/local-inference/running-qwen3-8-flash-next-locally/)
    
*   [Strata on an RTX 4070: 75 tok/s from a 176B Model at 128k Context](https://carteakey.dev/blog/local-inference/strata-on-an-rtx-4070/)
    
*   [The Rise of Overfit Inference Engines](https://carteakey.dev/blog/local-inference/the-rise-of-overfit-inference-engines/)
    
*   [LLM Stats: Qwen3.7-Plus vs Qwen3.8-Flash-Next](https://llm-stats.com/models/compare/qwen3.7-plus-vs-qwen3.8-flash-next)
    

Changelog [#](https://carteakey.dev/blog/local-inference/qwen3-8-27b-vs-flash-next/#changelog)

-----------------------------------------------------------------------------------------------

| Date | Note |
| --- | --- |
| 2026-10-18 | Updated Strata decode figures (up to 74.8 tok/s steady with `Q8_0` PLE), consolidated the duplicate decision tables, and tightened prose for readability. |
| 2026-09-30 | Added the Strata update showing how dynamic expert caching flipped the speed comparison against the 27B dense model. |
| 2026-08-31 | Initial head-to-head comparison between Qwen3.8-27B and Qwen3.8-Flash-Next on stock `llama.cpp`. |

Updated Oct 18, 2026

Reading tracker

Unread · saved only in this browser

Mark as read

Upvote this post: 1Thanks for your upvote!

React to this post
------------------

👍 Helpful 0 ✨ Delightful 0 🚀 Shipped it 0 💡 Interesting idea 0 👀 Watching this 0

* * *

This post is part of the **Local Inference** series.

[View all 15 posts](https://carteakey.dev/blog/local-inference/)

### Related Posts

[Challenges to AI-ML-based search engines.](https://carteakey.dev/blog/challenges-to-ai-ml-based-search-engines/)

Do privacy laws have an impact?

[Running your own Copilot in VSCode on a Mac.](https://carteakey.dev/blog/running-your-own-copilot-in-vscode-on-a-mac/)

With Codellama, Ollama and Continue.

[Exposing local llm's to the internet (draft)](https://carteakey.dev/blog/homelab/exposing-local-llms-to-the-internet/)

Your very own AI-API

* * *

  ![](https://carteakey.dev/img/halftone/coast-day.svg?v=2.17.0) ![](https://carteakey.dev/img/halftone/coast-night.svg?v=2.17.0)

~ a quiet place at the edge of the internet ~ [after night coast, ascii.rest ↗](https://ascii.rest/night-coast/)

  

carteakey

Read
----

*   [Writing](https://carteakey.dev/blog/)
    
*   [Notes](https://carteakey.dev/notes/)
    
*   [Snippets](https://carteakey.dev/snippets/)
    
*   [Folio](https://carteakey.dev/folio/)
    
*   [Quotations](https://carteakey.dev/quotations/)
    
*   [Feed](https://carteakey.dev/feed/)
    

Me
--

*   [About](https://carteakey.dev/about/)
    
*   [Now](https://carteakey.dev/now/)
    
*   [CV](https://carteakey.dev/cv/)
    
*   [Projects](https://carteakey.dev/projects/)
    
*   [AI](https://carteakey.dev/ai/)
    
*   [Uses](https://carteakey.dev/uses/)
    

Logs
----

*   [Life in data](https://carteakey.dev/data/)
    
*   [Gallery](https://carteakey.dev/gallery/)
    
*   [Vibes](https://carteakey.dev/vibes/)
    
*   [Quotes](https://carteakey.dev/quotes/)
    

Site
----

```

</details>

## Assistant · #42

<details><summary>Reasoning · 621 characters</summary>

Excellent. Now I have the two engines. Key finding in resource 02d0bf82:
- section 19 — "Activation precision" (table)
- section 20 — "Qwen3.8-Flash-Next IQ3_S: Infernix vs Strata and Basalt" (table) ← THIS IS THE KEY ONE
- Also "kv-dtype bf16p, BF16's KV bits in 23% fewer bytes" from ninfer-all README!

So ninfer-all has a `--kv-dtype` flag with bf16p option. Let me read sections 19, 20, and 4 (Flash-Next n-gram tables), and maybe 3 (options).

Let me open section 20 (IQ3_S: Infernix vs Strata and Basalt) and section 19 (Activation precision), plus section 3/4 for the kv-dtype options.

Let me do parallel reads.


</details>

<details><summary>Tool request · context_read · call_38ef7686c08a4cfba32b0419</summary>

```json
{
  "kind": "resource",
  "id": "02d0bf82-ab9e-494f-a15a-ba776937ae0b",
  "section": 20
}
```

</details>

<details><summary>Tool request · context_read · call_9831f9c34cae44649de4f323</summary>

```json
{
  "kind": "resource",
  "id": "02d0bf82-ab9e-494f-a15a-ba776937ae0b",
  "section": 19
}
```

</details>

That's the target — NInfer has a `--kv-dtype` axis and there's an "IQ3_S: Infernix vs Strata and Basalt" comparison. Opening those sections.
<details><summary>Tool result · context_read · call_38ef7686c08a4cfba32b0419</summary>

# Search: iamwavecut ninfer-all github bf16 kv cache strata flash-next · section 20/46
Subsection: Qwen3.8-Flash-Next IQ3\_S: Infernix vs Strata and Basalt
Tags: table

| Metric | Strata | strata-nvfp4 | Basalt | Infernix | Infernix 8-bit experts† | Infernix vs Strata | vs strata-nvfp4 | vs Basalt |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Mean TTFT | 12.3 s (10.8-13.9) | 10.8 s (9.2-12.0) | 7.2 s (6.4-7.9) | **3.1 s** (2.9-3.5) | 3.4 s (3.3-3.6) | −74 % | −71 % | −56 % |
| Median TTFT | 9.92 s | 7.62 s | 3.81 s | **2.04 s** | 2.00 s | −79 % | −73 % | −46 % |
| 90th-percentile TTFT | 25.9 s | 24.7 s | 17.5 s | **7.1 s** | 8.6 s | −71 % | −71 % | −59 % |
| Mean TTFT, new long prompts | 11.8 s | 10.2 s | 20.8 s | **6.1 s** | 7.4 s | −48 % | −38 % | −70 % |
| Prompt tokens from cache | 46.1 % | 53.2 % | 83.1 % | **84.5 %** | 84.5 % | +38.4 pt | +31.2 pt | +1.4 pt |
| Prefill tok/s, no cache hit | 5,170 | 5,847 | 2,349 | **7,480-7,689** | 6,216-6,281 | +45 % | +30 % | 3.3× |
| Output tok/s, one request | 116 (114-120) | 110 (108-113) | **166** (160-170) | **166** (165-169) | 175 (170-179) | +43 % | +51 % | level |
| Output tok/s, batched | 67  | 69  | 129 | **149** (142-157) | 158 (147-171) | 2.2× | 2.2× | +15 % |
| Tokens per round | 2.26 | 2.21 | 2.37 | **2.61** | 2.63 | +15 % | +19 % | +11 % |
| Wall time | 12.9 min (12.0-13.8) | 11.7 min (11.0-12.9) | 8.9 min (8.6-9.1) | **5.7 min** (5.4-5.9) | 5.7 min (5.6-5.8) | −56 % | −51 % | −36 % |

Bold and the comparison columns are the engines' defaults. † `--a8-activations`: the routed experts at 8 bits, as the others run them in decode (every other activation stays 16-bit); same three seeds, on the build that added this route (`9e82d344`). Against Basalt it reaches the first token 52 % sooner on average, decodes 5 % faster at one request and 22 % faster batched, and finishes 35 % sooner.

*   **First tokens**: the prefix cache reuses what the others re-read (whole prompts re-prefilled on continuing turns per seed: Strata 15-17 of 41, strata-nvfp4 9-14, Basalt 0-1, Infernix 1). Basalt's are slow here because it reads its n-gram table from the SSD (its own A/B on IQ3\_S: 5× slower at 128K).
*   **Decode**: Basalt is 7-23 % faster on one request, with coarser arithmetic (below); in the replay it is level at one request and Infernix leads by 15 % at two. At ~250K each request's thinking decides how many drafts are accepted (per request: Infernix 160-195 tok/s, Basalt 190-242).

**What each engine computes** (not switchable unless noted):

|     | Infernix | Strata v0.2.8 | strata-nvfp4 | Basalt |
| --- | --- | --- | --- | --- |
| Routed experts' activations (4-bit in the checkpoint) | 4-bit with NVIDIA's calibrated scales, as the checkpoint specifies (8 or 16 by option) | 8-bit | 8-bit; in the prompt, gate/up two 4-bit terms per value | 8-bit; prompt chunks of 1,024+ tokens 4-bit |
| Other activations (BF16 in the checkpoint) | 16-bit | **8-bit** | **8-bit** | **8-bit** |
| Dense layers (BF16 in the checkpoint) | 8-bit (Dense8; the bit-exact conversion keeps BF16) | 8-bit | 8-bit | **6-bit** (+10 % KL divergence by Basalt's measure) |
| n-gram table (FP8 in the checkpoint) | FP8 | FP8 | FP8 | re-blocked to 8-bit |

None of these engines has a lossy default that could be turned off. Quality (KL divergence against an exact reference) is measured on IQ3\_S, FP4-Local and the 27B in [Quality](https://github.com/wallawalla47/infernix#quality)
, not yet on these NVFP4 weights.

**Context length with 8-bit expert activations** (`--a8-activations`, closer to the others' arithmetic in decode):

|     | TTFT ~8K / ~128K / ~250K | Decode tok/s |
| --- | --- | --- |
| Infernix, 4-bit experts (default) | 1.88 / 12.22 / 23.90 s | 183 / 161 / 175 |
| Infernix `--a8-activations` | 1.88 / 15.53 / 30.58 s | 199 / 185 / 268 |
| Basalt (as above) | 9.55 / 92.94 / 125.92 s | 202 / 173 / 216 |

With its experts at 8 bits Infernix decodes level with Basalt at ~8K and faster at ~128K and ~250K. Against its own session's default (on `9e82d344`'s build) the 8-bit route runs 1-7 % more decode rounds a second (tok/s rises 9-36 %, partly from different text and drafts) but reads long prompts 28 % slower, so the default stays the faster choice for agents.

_Settings_: Infernix `--spec dflash2`, draft length auto, `--lm-head-draft`, `--vram-past-budget`. Strata: its setup's configuration for this PC plus its `--prefill auto:32768` tip for 96 GB PCs. strata-nvfp4: its bundled `--spec 6 --spec-min-p 0.7`. Basalt: its NVFP4 pack, MTP windows of 8, n-gram table on the SSD (in RAM it pushed 28 % of the experts out and the first request failed). Basalt loads its model during its first request; every session starts with an uncounted warm-up.

### Qwen3.8-Flash-Next IQ3\_S: Infernix vs Strata and Basalt

[](https://github.com/wallawalla47/infernix#qwen38-flash-next-iq3_s-infernix-vs-strata-and-basalt)

All three run ISTA-DASLab's GSQ-RCO `IQ3_S` GGUF: Infernix its [bit-exact conversion](https://github.com/wallawalla47/infernix#models)
 with the DFlash2 drafter, Strata\* the GGUF, Basalt its IQ3\_S pack.

**Context length** (one request):

| Context | TTFT: Infernix | Strata\* | Basalt | Decode tok/s: Infernix | Strata\* | Basalt |
| --- | --- | --- | --- | --- | --- | --- |
| ~8K | 1.40 s | 1.65 s | **1.35 s** | 229 | 209 | **380** |
| ~128K | 18.10 s | 17.97 s | **13.47 s** | 201 | 196 | **298** |
| ~250K | 35.59 s | 36.56 s | **27.98 s** | 250 | 223 | **339** |

**Agentic replay** (two requests at a time, three seeds):

| Metric | Strata\* | Basalt | Infernix | vs Strata\* | vs Basalt |
| --- | --- | --- | --- | --- | --- |
| Mean TTFT | 6.9 s (6.1-7.5) | 3.7 s (3.2-4.2) | **3.1 s** (2.9-3.4) | −55 % | −14 % |
| Median TTFT | 4.49 s | 1.97 s | **1.48 s** | −67 % | −24 % |
| 90th-percentile TTFT | 15.4 s | 9.5 s | **9.2 s** | −39 % | +2 % |
| Mean TTFT, new long prompts | 9.3 s | **8.4 s** | 9.4 s | +2 % | +12 % |
| Prompt tokens from cache | 72.9 % | **83.2 %** | 82.6 % | +9.8 pt | −0.6 pt |
| Prefill tok/s, no cache hit | 6,298 | **7,714** | 5,860-5,968 | −7 % | −22 % |
| Output tok/s, one request | 159 (157-161) | **296** (292-298) | 201 (198-203) | +26 % | −32 % |
| Output tok/s, batched | 111 | **249** | 184 (171-202) | +66 % | −26 % |
| Tokens per round | 2.17 | 2.48 | **2.64** | +22 % | +7 % |
| Wall time | 8.1 min (7.7-8.5) | **4.4 min** (4.2-4.6) | 5.5 min (5.1-6.2) | −32 % | +26 % |

Infernix beats Strata on decode and wall time and reaches the first token soonest on short continuing turns. Basalt decodes about 1.5× as fast and finishes 26 % sooner. All three hold the GGUF's weights as published (Basalt's pack copies them byte for byte); the differences are in what they compute:

|     | Infernix | Strata\* v0.2.8 | Basalt |
| --- | --- | --- | --- |
| Activations in matrix multiplies | 16-bit (8 by option) | **8-bit** | **8-bit** |
| Hyper-connection matrices (BF16 in the GGUF) | BF16 | BF16 (8-bit by option) | **8-bit copy** in decode |
| Experts that run | every routed expert | every routed expert (route tail skip **off**) | every routed expert |
| Output head | the GGUF's | the GGUF's | logits outside the top 64 from a **2-bit copy** (the choices themselves exact; +1.1 % KL divergence by Basalt's measure) |

\* Strata's default for this weight set skips a missed expert that every token of a verify window ranks 7th or lower: faster, but different answers. It was off (`STRATA_ROUTE_TAIL_SKIP=0`) because it changes which experts run. The 8-bit activations of Strata and Basalt cannot be turned off.

**Infernix with 8-bit activations** (`--a8-activations`, the others' arithmetic; an option, not the comparison above):

|     | TTFT ~8K / ~128K / ~250K | Decode tok/s | Replay: mean TTFT | Replay: output tok/s | Replay: wall time |
| --- | --- | --- | --- | --- | --- |
| Infernix (16-bit, default) | 1.40 / 18.10 / 35.59 s | 229 / 201 / 250 | 3.1 s | 201 | 5.5 min |
| Infernix `--a8-activations` | 1.30 / 13.99 / 27.68 s | 224 / 211 / 278 | 2.9 s | 208 | 5.2 min |
| Basalt (as above) | 1.35 / 13.47 / 27.98 s | 380 / 298 / 339 | 3.7 s | 296 | 4.4 min |

At the same 8 bits Infernix reads prompts as fast as Basalt; Basalt still decodes 1.2-1.7× as fast.

_Settings_: Infernix as on NVFP4, its IQ4\_NL n-gram table on the SSD (in RAM it would displace 6.2 GiB of experts: 4 % sooner to the first token, 3-7 % slower decode). Strata: its setup's `--spec 4 --spec-min-p 0.5 --pool-workers 15`, every expert in RAM, `--prefill auto:32768`. Basalt: n-gram table in RAM.

### Qwen3.8-Flash-Next: DFlash2 against MTP

[](https://github.com/wallawalla47/infernix#qwen38-flash-next-dflash2-against-mtp)

Decode tok/s at one request (repeats within 4 %; Dense8 code: DFlash2 209-217, MTP 186-203):

| Conversion | Text | Plain | MTP | **DFlash2** | DFlash2 vs MTP |
| --- | --- | --- | --- | --- | --- |
| NVIDIA Dense8 | code, greedy | 120 | 198 | **213** | +8 % |
| NVIDIA Dense8 | code, sampled |     | 162 | **204** | +26 % |
| NVIDIA Dense8 | docs, greedy | 121 | 164 | **179** | +9 % |
| NVIDIA Dense8 | docs, sampled | 122 | 145 | **161** | +11 % |
| GSQ-RCO IQ3\_S | code, greedy | 121 | 233 | **258** | +11 % |
| GSQ-RCO IQ3\_S | docs, greedy |     | 192 | **210** | +9 % |
| GSQ-RCO IQ3\_S | docs, sampled |     | 167 | **183** | +10 % |

DFlash2 drafts seven tokens in one pass with a probability for each, and `auto` verifies only those worth their cost in expert misses. It also leaves VRAM for more cached experts (Dense8 9,070 against MTP's 8,740; IQ3\_S 12,432 against 12,288). Greedy output is the same with either drafter; sampling keeps its distribution.

_Settings_: both `--draft-tokens auto --lm-head-draft`, with `--spec mtp` or `--spec dflash2 --draft-model FILE`. 24 prompts of 1,280 tokens from Infernix's sources (code) and Markdown docs at `08dda308`, each continued for 384 tokens, greedy or sampled (temperature 1.0, top-k 20, top-p 0.95); INT8 KV; `infernix_decode_quality_gen` (2026-10-20).

### Qwen3.8-27B: Infernix vs NInfer

[](https://github.com/wallawalla47/infernix#qwen38-27b-infernix-vs-ninfer)

Both serve NInfer's [Qwen3.8-27B-nvfp4-NInfer](https://huggingface.co/neroued/Qwen3.8-27B-nvfp4-NInfer)
, so both compute the same arithmetic (4-bit activations at its NVFP4 layers, as the artifact specifies), each with its own recommended drafter.

**Context length** (one request):

| Context | TTFT: Infernix | NInfer | Drafting tok/s: Infernix | NInfer | No drafting tok/s: Infernix | NInfer |
| --- | --- | --- | --- | --- | --- | --- |
| ~8K | **0.65 s** | 0.71 s | **228** | 195 | **81.1** | 79.2 |
| ~128K | **18.61 s** | 29.88 s | **210** | 182 | **68.4** | 66.5 |
| ~230K | **47.04 s** | 84.43 s | **187** | 169 | **60.3** | 58.7 |

**Agentic replay** (two requests at a time, five seeds):

| Metric | NInfer | Infernix | vs NInfer |
| --- | --- | --- | --- |
| Mean TTFT | 2.5 s (2.2-2.8) | **1.9 s** (1.6-2.2) | −21 % |
| Median TTFT | 0.93 s (0.85-1.13) | **0.59 s** (0.55-0.62) | −36 % |
| 90th-percentile TTFT | 6.6 s (5.1-8.2) | **5.3 s** (4.1-6.9) | −17 % |
| Mean TTFT, continuing turns | 2.12 s (1.88-2.52) | **1.67 s** (1.30-1.96) | −21 % |
| Mean TTFT, new long prompts | 10.9 s (10.6-11.2) | **7.5 s** (7.4-7.6) | −32 % |
| Prompt tokens from cache | 90.9 % (90.7-91.1) | 91.1 % (91.0-91.3) | +0.2 pt |
| Prefill tok/s, no cache hit | 4,749 | **7,088** | +49 % |
| Output tok/s, one request | 160 (154-164) | **220** (206-238) | +37 % |
| Output tok/s, batched | 193 (188-195) | **255** (245-262) | +32 % |
| Tokens per round | 2.68 | **3.68** | +38 % |
| Wall time | 16.4 min (14.0-19.0) | **12.7 min** (11.7-13.6) | −21 % |

Both decode the same rounds a second (59.8 against 59.9): Infernix's output lead is its drafter (3.5-4.9 tokens a round against 2.9-3.4). Quality is level: perplexity 4.468 against NInfer's 4.479 on the 1.04M-token corpus (16K context, INT8 KV; NInfer `81c8ce09`, 2026-10-19).



</details>

<details><summary>Tool result · context_read · call_9831f9c34cae44649de4f323</summary>

# Search: iamwavecut ninfer-all github bf16 kv cache strata flash-next · section 19/46
Subsection: Activation precision
Tags: table

One RTX 5090 on PCIe Gen5 x8, 2026-10-30/31. Every engine ran its latest version at the time, natively on Windows, with its own recommended settings and drafter and the same 84 GiB RAM budget. **Context**: one request, ~8K to ~250K tokens. **Replay**: an agentic coding workload, two requests at a time. Full tables and methods: [Benchmarks](https://github.com/wallawalla47/infernix#benchmarks)
.

**Speed without precision shortcuts.** Infernix keeps every activation at the precision the checkpoint specifies (16 bits where the others round to 8), runs every routed expert (no expert tail skipping) and computes the full output head (no 2-bit screen). Basalt, which computes with fewer bits (6-bit dense layers on NVFP4; on IQ3\_S 8-bit activations, an 8-bit copy of the hyper-connection matrices and a 2-bit head screen), has the highest decode tok/s at Infernix's defaults. On NVIDIA's NVFP4 weights Infernix still reaches the first token 5-8× sooner and finishes the agentic workload 36 % sooner, and with its experts at 8 bits as Basalt runs them it matches or passes Basalt's decode too. On the IQ3\_S GGUF Basalt is ahead overall (4.4 against 5.5 min); with the same 8-bit activations Infernix matches its first tokens, but Basalt still decodes faster. Measured quality on IQ3\_S, FP4-Local and the 27B, against the exact model: [Quality](https://github.com/wallawalla47/infernix#quality)
 (NVIDIA's NVFP4 weights not yet).

| Infernix vs | First token | Decode | Replay: mean first token | Replay: wall time |
| --- | --- | --- | --- | --- |
| **Qwen3.8-Flash-Next, NVIDIA's NVFP4 weights** |     |     |     |     |
| [Strata](https://github.com/Niko1221/Strata)<br> v0.2.8 | 1.4-1.6× sooner | +10-15 % to 128K, −4 % at 250K | 3.1 s vs 12.3 s | 5.7 vs 12.9 min |
| [strata-nvfp4](https://github.com/sergqwer/strata-nvfp4)<br> 0.2.0-beta-nvfp4.3 | 1.3× sooner | level to +3 % | 3.1 s vs 10.8 s | 5.7 vs 11.7 min |
| [Basalt](https://github.com/jesdga95/basalt)<br> `c08284cb` | 5-8× sooner¹ | Basalt 7-23 % faster² | 3.1 s vs 7.2 s | 5.7 vs 8.9 min |
| **Qwen3.8-Flash-Next, ISTA-DASLab's IQ3\_S GGUF** |     |     |     |     |
| Strata v0.2.8³ | 15 % sooner at 8K, level from 128K | +3-12 % | 3.1 s vs 6.9 s | 5.5 vs 8.1 min |
| Basalt `c08284cb` | Basalt 4 % sooner at 8K, 1.3× from 128K⁴ | Basalt 1.4-1.7× faster⁴ | 3.1 s vs 3.7 s | Basalt sooner: 4.4 vs 5.5 min⁴ |
| **Qwen3.8-27B, the same NVFP4 artifact in both** |     |     |     |     |
| [NInfer](https://github.com/Neroued/ninfer)<br> `1882c6adb` | 9 % sooner at 8K, 1.6-1.8× from 128K | +11-17 % (own drafters), +2-3 % without | 1.9 s vs 2.5 s | 12.7 vs 16.4 min |

1.  Basalt reads its 50.7 GiB n-gram table from the SSD here: it does not fit in the RAM budget beside its experts.
2.  Basalt runs NVIDIA's BF16 dense layers at **6 bits** (+10 % KL divergence by its own measure) and every activation outside the experts at **8 bits**; Infernix keeps 16. With the experts at 8 bits as Basalt runs them in decode (`--a8-activations`), Infernix decodes 199 / 185 / 268 tok/s against Basalt's 202 / 173 / 216 at ~8K / ~128K / ~250K and 175 against 166 at one request in the replay, and still reaches the first token 4-6× sooner.
3.  Strata's default route tail skip (it skips some missed experts) was off: it changes which experts run.
4.  All three hold the GGUF's weights as published, but Strata and Basalt compute **every activation at 8 bits**, and Basalt's decode reads the BF16 hyper-connection matrices from an **8-bit copy** and takes the logits outside the top 64 from a **2-bit copy** of the output head; Infernix keeps 16-bit activations, the BF16 matrices and the GGUF's head. At 8 bits (`--a8-activations`) Infernix reaches the first token as soon as Basalt, which still decodes 1.2-1.7× as fast.

### Activation precision

[](https://github.com/wallawalla47/infernix#activation-precision)

Infernix computes each model at the activation precision its checkpoint specifies; options change it:

| Weights | Default | Options |
| --- | --- | --- |
| NVIDIA NVFP4 Flash-Next (Dense8 and the bit-exact conversion) | Routed experts **4-bit** (W4A4 with NVIDIA's calibrated scales), because NVIDIA's checkpoint specifies it; everything else 16-bit | `--a8-activations`: experts 8-bit. `--a16-activations`: experts 16-bit on the stored 4-bit weights |
| NVIDIA FP4-Local Flash-Next (and Huihui's abliterated FP4-Local) | 16-bit, as NVIDIA serves it | `--expert-a4-activations`: experts 4-bit. `--a8-activations`: experts 8-bit |
| Uncensored NVFP4 Flash-Next | 16-bit (weight-only NVFP4 experts) | `--a8-activations`: experts 8-bit |
| IQ3\_S GGUF Flash-Next | 16-bit everywhere | `--a8-activations`: dense projections and experts 8-bit, as Strata and Basalt |
| Qwen3.8-27B NVFP4 | 4-bit at its NVFP4 layers, as the artifact specifies (NInfer the same) | none |

On NVIDIA's NVFP4 weights Strata, strata-nvfp4 and Basalt run the experts at 8 bits in decode and every other activation at 8 bits. The options on Dense8 (RTX 5090, one request):

| Experts' activations | First token at ~8K / ~128K / ~250K | Decode rounds a second | Agentic replay |
| --- | --- | --- | --- |
| 4-bit (default) | 1.9 / 12.2 / 23.9 s |     | 5.7 min |
| 8-bit, `--a8-activations` | level / 28 % / 28 % later | 1-7 % more | decode 6 % faster, uncached prompts 16 % slower: 5.7 min |
| 16-bit, `--a16-activations` | level / 38 % / 37 % later | 2-6 % more | not run |

Only the 4-bit route reads prompts on the RTX 5090's FP4 tensor cores, which makes it the fastest for agents. Both options change the output; their quality is not measured yet.

Why Infernix
------------

[](https://github.com/wallawalla47/infernix#why-infernix)

### Qwen3.8-Flash-Next on one RTX 5090

[](https://github.com/wallawalla47/infernix#qwen38-flash-next-on-one-rtx-5090)

The 24,576 routed experts (63 GiB at NVFP4) live in pinned RAM, the hot ones cached in VRAM; each layer's misses are split between the CPU and the PCIe link, and the 52 GB n-gram table is read from NVMe.

*   **Soonest first token** on NVIDIA's NVFP4 weights: 1.3-1.6× sooner than Strata and strata-nvfp4 from 8K to 250K tokens; 36-56 % less wall time than every other engine in an agentic replay ([benchmarks](https://github.com/wallawalla47/infernix#qwen38-flash-next-nvfp4-infernix-vs-strata-strata-nvfp4-and-basalt)
    ).
*   **Activations as the checkpoint specifies**: 16-bit wherever it keeps BF16 (all of them on GGUF), where Strata and Basalt use 8 bits ([activation precision](https://github.com/wallawalla47/infernix#activation-precision)
    ).
*   **DFlash2 drafting** with Inco AI's drafter ([Qwen3.8-Flash-Next-DFlash2-Infernix](https://huggingface.co/Wallawalla47/Qwen3.8-Flash-Next-DFlash2-Infernix)
    , 776 MB, any conversion): 8-11 % faster than MTP, 26 % on sampled code ([benchmarks](https://github.com/wallawalla47/infernix#qwen38-flash-next-dflash2-against-mtp)
    ).
*   **Long context**: 262K tokens natively, 1M with YaRN; a 250K prompt prefills in about 24 s.
*   **Less RAM than the model?** An SSD expert tier reads what does not fit.
*   **Uncensored too**: [Qwen3.8-Flash-Next-Uncensored-NVFP4-Infernix](https://huggingface.co/Wallawalla47/Qwen3.8-Flash-Next-Uncensored-NVFP4-Infernix)
     keeps orcarouter's abliterated NVFP4 experts and FP8 projections bit-exact (perplexity 4.772), and [Huihui-Qwen3.8-Flash-Next-abliterated-FP4-Local-Infernix](https://huggingface.co/Wallawalla47/Huihui-Qwen3.8-Flash-Next-abliterated-FP4-Local-Infernix)
     NVIDIA FP4-Local with Huihui's abliteration, every weight bit-exact (perplexity 3.4939 against FP4-Local's 3.4865).

Setup and tuning: the [Qwen3.8-Flash-Next guide](https://github.com/Wallawalla47/Infernix/blob/main/docs/qwen3_8-flash-next.md)
.

### Qwen3.8-27B: faster prefill and decode

[](https://github.com/wallawalla47/infernix#qwen38-27b-faster-prefill-and-decode)

Against NInfer on the same artifact ([benchmarks](https://github.com/wallawalla47/infernix#qwen38-27b-infernix-vs-ninfer)
):

*   **Hybrid prefix cache** for Qwen's linear-attention layers (64-token KV blocks, recurrent-state snapshots, GPU, RAM and file tiers): in an agentic replay the median first token comes 36 % sooner and the work finishes 21 % sooner.
*   **Faster prefill**: 1.6-1.8× NInfer's on long prompts.
*   **Faster decode**: DFlash2 with n-gram copy drafts, 11-17 % ahead of NInfer's MTP; draft trees (`--draft-tree-nodes`) are an option on top.
*   **Smaller KV**: `k4v2` and `vq2` hold 2.7 and 4 times the context of INT8.

### Built for agents

[](https://github.com/wallawalla47/infernix#built-for-agents)

*   **APIs**: OpenAI Chat Completions and Responses, Anthropic Messages and streaming, with the options Claude Code, Qwen Code, Codex, Zed and GitHub Copilot send.
*   **Tool calling**: the XML forms agents emit, recovery of broken calls (`--tolerant-tool-calls`), and deferred tools (`defer_loading`, regex/BM25 tool search, `tool_reference`) that keep large MCP catalogs out of the prompt.
*   **Constrained decoding**: JSON object and Schema, strict tool arguments, GBNF, regex and choice grammars, with every model and drafter.
*   **Thinking control**: budgets with a wrap-up message, effort levels and a repetition guard (`--reasoning-loop`).
*   **Concurrency and resilience**: one to eight requests with preemption under memory pressure; the prefix cache persists across restarts; a failed Flash-Next expert read fails only the requests running then.
*   **`/v1/decide`**: decisions from token probabilities (yes/no, choice, score, number, scalar, point and box).

### And also

[](https://github.com/wallawalla47/infernix#and-also)

*   **Speculative decoding**: MTP, DFlash, DFlash2 and n-gram drafting with exact sampling, on by default with the drafter measured fastest for each model (`--spec auto`).
*   **KV formats**: `int8`, `bf16`, `fp8`, `nvfp4`, `k8v4`, `vq2` and `k4v2`.
*   **Vision**: images and video; the vision encoder can stay in system RAM.
*   **Documents**: PDFs (page text, and page images with vision, read with PDFium), plain-text documents and search results, with Anthropic citations ([serving](https://github.com/Wallawalla47/Infernix/blob/main/docs/serving.md#documents-pdfs-and-citations)
    ).
*   **Conversion**: Hugging Face, NVIDIA ModelOpt, Quasar and GGUF sources; Q4-Q8, FP8, NVFP4 and mixed recipes.
*   **Windows and Linux**: native MSVC and GCC builds, WSL2 included.

Benchmarks
----------

[](https://github.com/wallawalla47/infernix#benchmarks)

RTX 5090 (32 GB) on **PCIe Gen5 x8**, Core i9-13900K, 96 GB DDR5, Windows 11; Gen5 x16 reads Flash-Next's prompts up to twice as fast ([measured](https://github.com/wallawalla47/infernix#pcie-gen5-x8-against-x16)
). TTFT: time to the first token; bold: best in its row. Methods and every engine's settings are at the end of each section and [below](https://github.com/wallawalla47/infernix#how-the-benchmarks-were-run)
.

### Qwen3.8-Flash-Next NVFP4: Infernix vs Strata, strata-nvfp4 and Basalt

[](https://github.com/wallawalla47/infernix#qwen38-flash-next-nvfp4-infernix-vs-strata-strata-nvfp4-and-basalt)

Infernix runs the [Dense8 conversion](https://github.com/wallawalla47/infernix#models)
 of NVIDIA's checkpoint with Inco AI's DFlash2 drafter; the others run NVIDIA's checkpoint as their own NVFP4 packs with the model's MTP drafter.

**Context length** (one request):

| Context | TTFT: Infernix | Strata | strata-nvfp4 | Basalt | Decode tok/s: Infernix | Strata | strata-nvfp4 | Basalt |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| ~8K | **1.88 s** | 2.67 s | 2.48 s | 9.55 s | 183 | 159 | 177 | **202** |
| ~128K | **12.22 s** | 18.83 s | 15.34 s | 92.94 s | 161 | 146 | 161 | **173** |
| ~250K | **23.90 s** | 37.55 s | 31.78 s | 125.92 s | 175 | 183 | 172 | **216** |

**Agentic replay** (two requests at a time, three seeds):



</details>

## Assistant · #45

<details><summary>Reasoning · 1,512 characters</summary>

Now I have a lot. The Infernix README (wallawalla47/infernix) is a third engine that has explicit KV formats: `int8`, `bf16`, `fp8`, `nvfp4`, `k8v4`, `vq2`, `k4v2`. And it measures quality (KL divergence, perplexity) on IQ3_S. That's the closest thing to a published comparison.

Also ninfer-all README mentions `--kv-dtype bf16p` — "BF16's KV bits in 23% fewer bytes".

Let me now get the ninfer-all KV dtype options — sections 3/4/5 (config file options) and search for "kv-dtype" in resource 02d0bf82. Also check Infernix quality section (KL divergence on IQ3_S with INT8 KV).

Let me search resource 02d0bf82 for "kv-dtype" and also search for the Infernix quality page.

Actually the user's question: "Where do comparisons for FP16 versus BF16 kv cache only, compare in Qwen 3.8 Flash Next (MoE)... on both engines. You only have the selection of one or the other."

So they want: published comparisons of FP16 vs BF16 KV for Basalt and Ninfer-All, on Flash-Next. Let me find:
1. ninfer-all's --kv-dtype documentation (docs/ — maybe docs/benchmarks.md or docs/serving.md) with quality numbers.
2. Basalt's README — does it document FP16 KV and any comparison?
3. Infernix's quality page — has KL divergence vs exact model on IQ3_S, and mentions INT8 KV.

Let me search resource 02d0bf82 for kv-dtype, and scrape ninfer-all docs, and basalt README.

Let me do parallel: resource_search on 02d0bf82 for "kv-dtype"; web_search for basalt README kv fp16; web_search for infernix quality KL divergence IQ3_S kv.


</details>

<details><summary>Tool request · resource_search · call_1fb3a17b5f49465ea2b3f2ed</summary>

```json
{
  "query": "kv-dtype bf16p fp16 int8 kv cache quality perplexity",
  "resource_id": "02d0bf82-ab9e-494f-a15a-ba776937ae0b"
}
```

</details>

<details><summary>Tool request · web_search · call_69f398b8d3fd4e5a9806d568</summary>

```json
{
  "query": "jesdga95 basalt README flash-next \"fp16\" KV cache precision experts Blackwell",
  "limit": 8
}
```

</details>

<details><summary>Tool request · web_search · call_ed2f21fc1ec243d9be1396a3</summary>

```json
{
  "query": "Infernix quality KL divergence IQ3_S Flash-Next exact model KV int8 perplexity measured",
  "limit": 8
}
```

</details>

Found the third engine with an explicit KV-format axis. Let me pull the NInfer `--kv-dtype` docs and Basalt's own claims.
<details><summary>Tool result · resource_search · call_1fb3a17b5f49465ea2b3f2ed</summary>

No sections in Search: iamwavecut ninfer-all github bf16 kv cache strata flash-next contain "kv-dtype bf16p fp16 int8 kv cache quality perplexity".

</details>

<details><summary>Tool result · web_search · call_69f398b8d3fd4e5a9806d568</summary>

**Firecrawl · section 1 of 69**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,027 characters · included below
- Section 2 · 9,751 characters · omitted from this copy
- Section 3 · 11,946 characters · omitted from this copy
- Section 4 · 11,942 characters · omitted from this copy
- Section 5 · 12,000 characters · omitted from this copy
- Section 6 · 7,615 characters · omitted from this copy
- Section 7 · 11,875 characters · omitted from this copy
- Section 8 · 11,884 characters · omitted from this copy
- Section 9 · 10,607 characters · omitted from this copy
- Section 10 · 11,079 characters · omitted from this copy
- Section 11 · 11,835 characters · omitted from this copy
- Section 12 · 11,318 characters · omitted from this copy
- Section 13 · 11,139 characters · omitted from this copy
- Section 14 · 11,830 characters · omitted from this copy
- Section 15 · 11,850 characters · omitted from this copy
- Section 16 · 8,413 characters · omitted from this copy
- Section 17 · 11,815 characters · omitted from this copy
- Section 18 · 10,589 characters · omitted from this copy
- Section 19 · 10,942 characters · omitted from this copy
- Section 20 · 10,149 characters · omitted from this copy
- Section 21 · 11,421 characters · omitted from this copy
- Section 22 · 9,090 characters · omitted from this copy
- Section 23 · 11,958 characters · omitted from this copy
- Section 24 · 11,801 characters · omitted from this copy
- Section 25 · 11,707 characters · omitted from this copy
- Section 26 · 11,384 characters · omitted from this copy
- Section 27 · 11,776 characters · omitted from this copy
- Section 28 · 11,870 characters · omitted from this copy
- Section 29 · 11,757 characters · omitted from this copy
- Section 30 · 11,973 characters · omitted from this copy
- Section 31 · 11,893 characters · omitted from this copy
- Section 32 · 11,843 characters · omitted from this copy
- Section 33 · 11,999 characters · omitted from this copy
- Section 34 · 11,883 characters · omitted from this copy
- Section 35 · 11,750 characters · omitted from this copy
- Section 36 · 11,586 characters · omitted from this copy
- Section 37 · 11,722 characters · omitted from this copy
- Section 38 · 11,869 characters · omitted from this copy
- Section 39 · 11,842 characters · omitted from this copy
- Section 40 · 11,882 characters · omitted from this copy
- Section 41 · 11,890 characters · omitted from this copy
- Section 42 · 11,808 characters · omitted from this copy
- Section 43 · 11,820 characters · omitted from this copy
- Section 44 · 11,945 characters · omitted from this copy
- Section 45 · 11,981 characters · omitted from this copy
- Section 46 · 11,743 characters · omitted from this copy
- Section 47 · 11,870 characters · omitted from this copy
- Section 48 · 11,793 characters · omitted from this copy
- Section 49 · 11,995 characters · omitted from this copy
- Section 50 · 11,942 characters · omitted from this copy
- Section 51 · 11,762 characters · omitted from this copy
- Section 52 · 11,721 characters · omitted from this copy
- Section 53 · 11,800 characters · omitted from this copy
- Section 54 · 11,922 characters · omitted from this copy
- Section 55 · 11,999 characters · omitted from this copy
- Section 56 · 12,000 characters · omitted from this copy
- Section 57 · 11,820 characters · omitted from this copy
- Section 58 · 11,843 characters · omitted from this copy
- Section 59 · 11,949 characters · omitted from this copy
- Section 60 · 11,939 characters · omitted from this copy
- Section 61 · 11,816 characters · omitted from this copy
- Section 62 · 11,992 characters · omitted from this copy
- Section 63 · 11,875 characters · omitted from this copy
- Section 64 · 11,820 characters · omitted from this copy
- Section 65 · 11,843 characters · omitted from this copy
- Section 66 · 11,966 characters · omitted from this copy
- Section 67 · 11,759 characters · omitted from this copy
- Section 68 · 11,823 characters · omitted from this copy
- Section 69 · 2,250 characters · omitted from this copy

```text
## 1. [GUIDE] Qwen3.8 Flash-Next on a single RTX 5080 + 64GB RAM ...

https://www.reddit.com/r/LocalLLaMA/comments/1xomy0i/guide_qwen38_flashnext_on_a_single_rtx_5080_64gb/

Nov 6, 2026 ... ... the bottleneck is bandwidth for me at this point with everything in ram/vram. helps prefill times a bit, and all fp16 math. Chromix_. •. 11d ago.

[Skip to main content](https://www.reddit.com/r/LocalLLaMA/comments/1xomy0i/guide_qwen38_flashnext_on_a_single_rtx_5080_64gb/?solution=9d51da88ae84deaf9d51da88ae84deaf&js_challenge=1&jsc_token=2824be10929bdc604753c70a67a1c331f4c32125e17929f52028779ebad6b13c&jsc_orig_r=#main-content)
 \[GUIDE\] Qwen3.8 Flash-Next on a single RTX 5080 + 64GB RAM: >250 tok/s tg and 5700 tok/s prefill in real agent coding sessions (Basalt + new Unsloth UD-IQ3\_XXS + Lamina drafter),+ how it compares to llama.cpp : r/LocalLLaMA

[![](https://styles.redditmedia.com/t5_81eyvm/styles/communityIcon_cumnsvx9kzma1.png?width=96&height=96&frame=1&auto=webp&s=a5f00ebcb6dcd381b6e081d0764399f7e70108f0)\
\
Go to LocalLLaMA](https://applink.reddit.com/r/LocalLLaMA/?utm_source=app_first_navigation&mweb_loid=t2_2r6gscu55k&ext-referrer=DIRECT)

[r/LocalLLaMA](https://applink.reddit.com/r/LocalLLaMA/?utm_source=app_first_navigation&mweb_loid=t2_2r6gscu55k&ext-referrer=DIRECT)  ![](https://emoji.redditmedia.com/23w2nhjj1e9f1_t5_81eyvm/Llama)12d ago

[u/yehyakar](https://applink.reddit.com/user/yehyakar/?utm_source=app_first_navigation&mweb_loid=t2_2r6gscu55k&ext-referrer=DIRECT)

\[GUIDE\] Qwen3.8 Flash-Next on a single RTX 5080 + 64GB RAM: >250 tok/s tg and 5700 tok/s prefill in real agent coding sessions (Basalt + new Unsloth UD-IQ3\_XXS + Lamina drafter),+ how it compares to llama.cpp
===================================================================================================================================================================================================================

[Resources](https://www.reddit.com/r/LocalLLaMA/?f=flair_name%3A%22Resources%22)

**TL;DR**

*   **Basalt** is the engine and it's doing the heavy lifting. Same model file, same box: about **3.5x llama.cpp's decode without drafting and ~5x with it, and ~7x faster prompt reads**.
    
*   **Unsloth's new UD-IQ3\_XXS** (Dynamic v3.1, uploaded Nov 4) is the same size as the GSQ-RCO IQ3\_S everyone uses on 16GB cards, but **measurably more accurate**: wikitext perplexity 3.382 -> 3.247, which basically closes the gap to BF16 (3.273). Costs 1 to 3.5% decode speed.
    
*   **Lamina** (a further-trained MTP drafter by eddoursul) gets more drafts accepted than the stock Basalt drafter. Small but real speedup, zero quality impact since the main model verifies every token.
    
*   Real agent coding session (opencode, 151 requests, up to 202K context): **195.6 tok/s average decode, 263 tok/s best request, 156 tok/s worst, ~5,700 tok/s prompt reads**.
    

Hardware:

*   RTX 5080 16GB at its stock 360W limit (no overclock, no undervolt)
    
*   Core Ultra 9 285K (8P + 16E), 2x32GB DDR5-7200
    
*   PCIe 5.0 x16, Fedora
    

LAMINA Drafting: Basalt drafts with the model's own MTP layer. Basalt's upstream already ships a self-distilled version of that layer, and Lamina trains it further. It's a drop-in: same tensor layout, so the target model is byte-identical and only the drafter changes. What I saw:

\- drafts accepted per drafted token: 83.1% -> 85.8% on a replay of a real recorded session

Lamina's README recommends temp 0.7 and max 3 drafts. I tested both: the 3-draft cap was 1 to 1.8% slower on tool-call-heavy work (long confident runs get cut off), and temp 0.7 changes what the model writes, so I kept the model's own sampling (1.0 / 0.95 / 20) and Basalt's draft settings.

**Basalt changes I made (all open PRs upstream)**

Host KV prefault: the first time a long conversation spills its KV cache to RAM used to stall 0.6 to 2.4s. Now ~75ms.

Host KV pool on normal pages: on a fragmented box, transparent hugepage compaction caused 1.5 to 3.7s pins. Now ~23ms.

Spin-then-yield in the decode loop's waits: about 1.3% less time per draft window.

Expert start profile: the older v1 profile is 2% faster than the v0.2.0 one on this box.

Plus a streamed conversation disk cache, `--adapt-margin` for expert swap hysteresis, elastic KV without RAM copies, and a bunch of timing diagnostics.

**Guide**

Branch with the exact engine (upstream v0.2.1 + my PRs) and a setup script: [https://github.com/xyehya/basalt/tree/flashnext-5080-setup](https://github.com/xyehya/basalt/tree/flashnext-5080-setup)

git clone -b flashnext-5080-setup https://github.com/xyehya/basalt && cd basalt
setup/flashnext-ud-lamina/setup.sh
bin/basalt serve --config basalt\_config-flashnext.json --python .venv/bin/python --alias qwen3.8-flash-next

It checks your machine, builds, downloads ~90GB (pinned revisions, every file SHA-256 checked), builds the UD-IQ3\_XXS + Lamina model file and writes the config. You need an RTX card with, CUDA 13, 64GB RAM and ~180GB of free disk. If you already have the GSQ-RCO IQ3\_S download, `SHARD4_FROM=` reuses its 28.8GB n-gram shard (it's byte-identical to Unsloth's once the shard number is rewritten).

Huge thanks to jesdga95 for Basalt (support and star their repo), the Unsloth team for the UD quants, eddoursul for Lamina, ISTA-DASLab for the GSQ-RCO quants, and Qwhen 4? for the model.

Read more

Share [](https://alb.reddit.com/cr?za=B6uNC4IQY3v2Fuk56tbLfyAkwUNaxSDQuIr5Ou3CAXG19WapagsIVQhsETR4j2V4NIu3JnT5wb8BVCsMK7VdeXp8PP0I66XmBPzxTOPactk3ZwyghxtDDHc7iZYdBGpvft66xRxg4BKIyvoQY7HihoBpt1tP2bw4LHEKNy1CpNK6FRHn_mzGWisI85ksDMqxkYZmjIc7BSFgZYxBlFC6BliSpQlXztjAFmP56Yi9WbhO5LHNJmd8_Ws083xiiw5IY2_a133KYwEr36VQykgdIH0U5G-U34acg568SksQ7dH1e58AByguJLewnXAVikrXEvfK5kk6ozsuzlV7AddMPbEp4S71mTBwA2yJJfvYGdRI8B_1AOlppJJq19dT-JLHkivdYZ2XPI998wFX04GAlcpCDj76gDUIHzT2luAJ9cIrZhQVDbg2BVaI9gSEG-g7vfeobPZbHZgT87M9xfI69vPw6sp9m7LgRKVT8zjvdYykPQALGoz2RG_hs0M4EWFBop2Su_eqtdaE6j3mio6zwKH8oIea-lva76PSRCjImqTbgoAMYUDF1tk1EmW1bE5V-o9vOvM-fQLum8SJaGHrQLNfViGhMCb6nTysE5ciGANat62P99EYpWidtasOFMMuzmdy7oMocow-cWyFCfASeFVas7ayePzEjeonjDE7HOa52bzR9bE2_5hCNrAfrXKRM5TaO7SeDVpsfwoao-JEpYAm1gnqNydrrTmjSQBKNx0avwHXXyLOi6QL5zFmtIuM5c2fEGX0Ed15feVrWRpfNw&zp=5HyCr-jZjFf-oRw139uY8XvMI2kZn6NRDdUh2MAmy6peJxr21VHkq8l8fsfmyZmE6V6HKR-LCqLudP4tibbzWCIad_lUwUZCbdISMHJUoE5VWQamubK0YmG_7lXqji4PoyaUbyNv5PuFupS_AEBN5cfNDlgcPvxZ7Wrc_uoxYxP3rSAF1Zp9ML0BJUZ1TX20TjvCm5TM9g287K8e63D308XDtKmok0lhZqv7b2MIhrr3IRBNQrHdpKMAn1XlM42-46glHyIzp_iEuMlSmQle0EaK4UdBkOS109wup_eIKW6Zn43OMSpAOuUOZdoIWBTanyM1W15JvmsRCgKm0HfLVSzCP9TfPvMZMg62Kw0KgeEEjDLxSAcJQxAc6Nzog6fNCy09eg)

 [![u/AmazonWebServices avatar](https://styles.redditmedia.com/t5_3plv2/styles/profileIcon_ylo04h1gocye1.png?width=48&height=48&frame=1&auto=webp&crop=48%3A48%2Csmart&s=14dc6df352a2cce7ba86443ba392eda78c6920a5)AmazonWebServices](https://www.reddit.com/user/AmazonWebServices/) • [Ad](https://www.reddit.com/user/AmazonWebServices/)
[](https://alb.reddit.com/cr?za=B6uNC4IQY3v2Fuk56tbLfyAkwUNaxSDQuIr5Ou3CAXG19WapagsIVQhsETR4j2V4NIu3JnT5wb8BVCsMK7VdeXp8PP0I66XmBPzxTOPactk3ZwyghxtDDHc7iZYdBGpvft66xRxg4BKIyvoQY7HihoBpt1tP2bw4LHEKNy1CpNK6FRHn_mzGWisI85ksDMqxkYZmjIc7BSFgZYxBlFC6BliSpQlXztjAFmP56Yi9WbhO5LHNJmd8_Ws083xiiw5IY2_a133KYwEr36VQykgdIH0U5G-U34acg568SksQ7dH1e58AByguJLewnXAVikrXEvfK5kk6ozsuzlV7AddMPbEp4S71mTBwA2yJJfvYGdRI8B_1AOlppJJq19dT-JLHkivdYZ2XPI998wFX04GAlcpCDj76gDUIHzT2luAJ9cIrZhQVDbg2BVaI9gSEG-g7vfeobPZbHZgT87M9xfI69vPw6sp9m7LgRKVT8zjvdYykPQALGoz2RG_hs0M4EWFBop2Su_eqtdaE6j3mio6zwKH8oIea-lva76PSRCjImqTbgoAMYUDF1tk1EmW1bE5V-o9vOvM-fQLum8SJaGHrQLNfViGhMCb6nTysE5ciGANat62P99EYpWidtasOFMMuzmdy7oMocow-cWyFCfASeFVas7ayePzEjeonjDE7HOa52bzR9bE2_5hCNrAfrXKRM5TaO7SeDVpsfwoao-JEpYAm1gnqNydrrTmjSQBKNx0avwHXXyLOi6QL5zFmtIuM5c2fEGX0Ed15feVrWRpfNw&zp=5HyCr-jZjFf-oRw139uY8XvMI2kZn6NRDdUh2MAmy6peJxr21VHkq8l8fsfmyZmE6V6HKR-LCqLudP4tibbzWCIad_lUwUZCbdISMHJUoE5VWQamubK0YmG_7lXqji4PoyaUbyNv5PuFupS_AEBN5cfNDlgcPvxZ7Wrc_uoxYxP3rSAF1Zp9ML0BJUZ1TX20TjvCm5TM9g287K8e63D308XDtKmok0lhZqv7b2MIhrr3IRBNQrHdpKMAn1XlM42-46glHyIzp_iEuMlSmQle0EaK4UdBkOS109wup_eIKW6Zn43OMSpAOuUOZdoIWBTanyM1W15JvmsRCgKm0HfLVSzCP9TfPvMZMg62Kw0KgeEEjDLxSAcJQxAc6Nzog6fNCy09eg)

[Strands harness is open source and production-ready the moment you install it. Start with a fully assembled agent harness on any model and any cloud.](https://alb.reddit.com/cr?za=B6uNC4IQY3v2Fuk56tbLfyAkwUNaxSDQuIr5Ou3CAXG19WapagsIVQhsETR4j2V4NIu3JnT5wb8BVCsMK7VdeXp8PP0I66XmBPzxTOPactk3ZwyghxtDDHc7iZYdBGpvft66xRxg4BKIyvoQY7HihoBpt1tP2bw4LHEKNy1CpNK6FRHn_mzGWisI85ksDMqxkYZmjIc7BSFgZYxBlFC6BliSpQlXztjAFmP56Yi9WbhO5LHNJmd8_Ws083xiiw5IY2_a133KYwEr36VQykgdIH0U5G-U34acg568SksQ7dH1e58AByguJLewnXAVikrXEvfK5kk6ozsuzlV7AddMPbEp4S71mTBwA2yJJfvYGdRI8B_1AOlppJJq19dT-JLHkivdYZ2XPI998wFX04GAlcpCDj76gDUIHzT2luAJ9cIrZhQVDbg2BVaI9gSEG-g7vfeobPZbHZgT87M9xfI69vPw6sp9m7LgRKVT8zjvdYykPQALGoz2RG_hs0M4EWFBop2Su_eqtdaE6j3mio6zwKH8oIea-lva76PSRCjImqTbgoAMYUDF1tk1EmW1bE5V-o9vOvM-fQLum8SJaGHrQLNfViGhMCb6nTysE5ciGANat62P99EYpWidtasOFMMuzmdy7oMocow-cWyFCfASeFVas7ayePzEjeonjDE7HOa52bzR9bE2_5hCNrAfrXKRM5TaO7SeDVpsfwoao-JEpYAm1gnqNydrrTmjSQBKNx0avwHXXyLOi6QL5zFmtIuM5c2fEGX0Ed15feVrWRpfNw&zp=5HyCr-jZjFf-oRw139uY8XvMI2kZn6NRDdUh2MAmy6peJxr21VHkq8l8fsfmyZmE6V6HKR-LCqLudP4tibbzWCIad_lUwUZCbdISMHJUoE5VWQamubK0YmG_7lXqji4PoyaUbyNv5PuFupS_AEBN5cfNDlgcPvxZ7Wrc_uoxYxP3rSAF1Zp9ML0BJUZ1TX20TjvCm5TM9g287K8e63D308XDtKmok0lhZqv7b2MIhrr3IRBNQrHdpKMAn1XlM42-46glHyIzp_iEuMlSmQle0EaK4UdBkOS109wup_eIKW6Zn43OMSpAOuUOZdoIWBTanyM1W15JvmsRCgKm0HfLVSzCP9TfPvMZMg62Kw0KgeEEjDLxSAcJQxAc6Nzog6fNCy09eg)

[![Thumbnail image: Strands harness is open source and production-ready the moment you install it. Start with a fully assembled agent harness on any model and any cloud.](https://preview.redd.it/kucdpqgwpq0i1.png?width=216&height=162&auto=webp&s=8c643bb30155dda5d1438edf0927880b3d09c022)](https://alb.reddit.com/cr?za=B6uNC4IQY3v2Fuk56tbLfyAkwUNaxSDQuIr5Ou3CAXG19WapagsIVQhsETR4j2V4NIu3JnT5wb8BVCsMK7VdeXp8PP0I66XmBPzxTOPactk3ZwyghxtDDHc7iZYdBGpvft66xRxg4BKIyvoQY7HihoBpt1tP2bw4LHEKNy1CpNK6FRHn_mzGWisI85ksDMqxkYZmjIc7BSFgZYxBlFC6BliSpQlXztjAFmP56Yi9WbhO5LHNJmd8_Ws083xiiw5IY2_a133KYwEr36VQykgdIH0U5G-U34acg568SksQ7dH1e58AByguJLewnXAVikrXEvfK5kk6ozsuzlV7AddMPbEp4S71mTBwA2yJJfvYGdRI8B_1AOlppJJq19dT-JLHkivdYZ2XPI998wFX04GAlcpCDj76gDUIHzT2luAJ9cIrZhQVDbg2BVaI9gSEG-g7vfeobPZbHZgT87M9xfI69vPw6sp9m7LgRKVT8zjvdYykPQALGoz2RG_hs0M4EWFBop2Su_eqtdaE6j3mio6zwKH8oIea-lva76PSRCjImqTbgoAMYUDF1tk1EmW1bE5V-o9vOvM-fQLum8SJaGHrQLNfViGhMCb6nTysE5ciGANat62P99EYpWidtasOFMMuzmdy7oMocow-cWyFCfASeFVas7ayePzEjeonjDE7HOa52bzR9bE2_5hCNrAfrXKRM5TaO7SeDVpsfwoao-JEpYAm1gnqNydrrTmjSQBKNx0avwHXXyLOi6QL5zFmtIuM5c2fEGX0Ed15feVrWRpfNw&zp=5HyCr-jZjFf-oRw139uY8XvMI2kZn6NRDdUh2MAmy6peJxr21VHkq8l8fsfmyZmE6V6HKR-LCqLudP4tibbzWCIad_lUwUZCbdISMHJUoE5VWQamubK0YmG_7lXqji4PoyaUbyNv5PuFupS_AEBN5cfNDlgcPvxZ7Wrc_uoxYxP3rSAF1Zp9ML0BJUZ1TX20TjvCm5TM9g287K8e63D308XDtKmok0lhZqv7b2MIhrr3IRBNQrHdpKMAn1XlM42-46glHyIzp_iEuMlSmQle0EaK4UdBkOS109wup_eIKW6Zn43OMSpAOuUOZdoIWBTanyM1W15JvmsRCgKm0HfLVSzCP9TfPvMZMg62Kw0KgeEEjDLxSAcJQxAc6Nzog6fNCy09eg)

```

</details>

<details><summary>Tool result · web_search · call_ed2f21fc1ec243d9be1396a3</summary>

**Firecrawl · section 1 of 30**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,590 characters · included below
- Section 2 · 11,960 characters · omitted from this copy
- Section 3 · 10,906 characters · omitted from this copy
- Section 4 · 11,970 characters · omitted from this copy
- Section 5 · 11,777 characters · omitted from this copy
- Section 6 · 11,229 characters · omitted from this copy
- Section 7 · 9,065 characters · omitted from this copy
- Section 8 · 11,905 characters · omitted from this copy
- Section 9 · 10,605 characters · omitted from this copy
- Section 10 · 11,630 characters · omitted from this copy
- Section 11 · 11,891 characters · omitted from this copy
- Section 12 · 8,503 characters · omitted from this copy
- Section 13 · 11,572 characters · omitted from this copy
- Section 14 · 11,963 characters · omitted from this copy
- Section 15 · 11,734 characters · omitted from this copy
- Section 16 · 11,977 characters · omitted from this copy
- Section 17 · 8,625 characters · omitted from this copy
- Section 18 · 11,446 characters · omitted from this copy
- Section 19 · 11,922 characters · omitted from this copy
- Section 20 · 11,680 characters · omitted from this copy
- Section 21 · 11,992 characters · omitted from this copy
- Section 22 · 11,906 characters · omitted from this copy
- Section 23 · 11,740 characters · omitted from this copy
- Section 24 · 11,891 characters · omitted from this copy
- Section 25 · 11,652 characters · omitted from this copy
- Section 26 · 11,547 characters · omitted from this copy
- Section 27 · 11,919 characters · omitted from this copy
- Section 28 · 10,286 characters · omitted from this copy
- Section 29 · 11,807 characters · omitted from this copy
- Section 30 · 8,217 characters · omitted from this copy

```text
## 1. Infernix/docs/README.md at main - GitHub

https://github.com/Wallawalla47/Infernix/blob/main/docs/README.md

User guides ; Quality, output quality of Infernix and other engines against the exact model (KL divergence on WikiText-2): results, statistics, engine settings, ...

![](<Base64-Image-Removed>)

We're having a really bad day.
==============================

The Unicorns have taken over. We're doing our best to get them under control and get GitHub back up and running.

[Contact Support](https://support.github.com/contact)
 — [GitHub Status](https://githubstatus.com/)
 — [@githubstatus](https://x.com/githubstatus)

 [![](<Base64-Image-Removed>)](https://github.com/)
[![](<Base64-Image-Removed>)](https://github.com/)

---

## 2. I ran all the popular Qwen 3.8 FN engines on a single 5090 + 128GB ...

https://www.reddit.com/r/LocalLLaMA/comments/1xdlunp/i_ran_all_the_popular_qwen_38_fn_engines_on_a/

Oct 23, 2026 ... Sampling: greedy (temperature 0), thinking off, int8 KV cache for every engine (llama ran f16 kv). ... perplexity --kl-divergence on the other.

[Skip to main content](https://www.reddit.com/r/LocalLLaMA/comments/1xdlunp/i_ran_all_the_popular_qwen_38_fn_engines_on_a/?solution=eb1668022132eed2eb1668022132eed2&js_challenge=1&jsc_token=2824be10929bdc604753c70a67a1c331d7c9ab0f75bf58eeeac151365a7e374d&jsc_orig_r=#main-content)
 I ran all the popular Qwen 3.8 FN engines on a single 5090 + 128GB of RAM, here are the numbers : r/LocalLLaMA

[![](https://styles.redditmedia.com/t5_81eyvm/styles/communityIcon_cumnsvx9kzma1.png?width=96&height=96&frame=1&auto=webp&s=a5f00ebcb6dcd381b6e081d0764399f7e70108f0)\
\
Go to LocalLLaMA](https://applink.reddit.com/r/LocalLLaMA/?utm_source=app_first_navigation&mweb_loid=t2_2r6gzbczh4&ext-referrer=DIRECT)

[r/LocalLLaMA](https://applink.reddit.com/r/LocalLLaMA/?utm_source=app_first_navigation&mweb_loid=t2_2r6gzbczh4&ext-referrer=DIRECT)  ![](https://emoji.redditmedia.com/23w2nhjj1e9f1_t5_81eyvm/Llama)25d ago

[u/jesdga95](https://applink.reddit.com/user/jesdga95/?utm_source=app_first_navigation&mweb_loid=t2_2r6gzbczh4&ext-referrer=DIRECT)

I ran all the popular Qwen 3.8 FN engines on a single 5090 + 128GB of RAM, here are the numbers
===============================================================================================

[Discussion](https://www.reddit.com/r/LocalLLaMA/?f=flair_name%3A%22Discussion%22)

> **Before you read:** I'm the developer of Basalt, one of the engines benchmarked below. I tried to keep this as fair as possible: same checkpoint, GPU and requests, and every engine set up the way its own docs recommend. How it was run is at the bottom. This post has had some AI cleanup from my own wording.

I wanted to get a comparison on all of the Qwen 3.8 FN engines I hear people talking about, so after 5 or so excruciating hours of setup (remind me not to do this ever again), I benchmarked all of the ones I know of: Strata, Infernix, capy-flash, ninfer-ext, ninfer, llama.cpp and Basalt. Each one converted NVIDIA's NVFP4 with its own tool, then got the same seven greedy requests on an RTX 5090 at 400 W, one cold start per request. Anyway, here are the results:

Decode, short context
=====================

[![r/LocalLLaMA - Decode, short context](https://cf.preview.redd.it/i-ran-all-the-popular-qwen-3-8-fn-engines-on-a-single-5090-v0-21o6k7qeb9xh1.png?width=2400&format=png&auto=webp&s=3c52e9713d993c53d8593733e5aca271b7398049)](https://cf.preview.redd.it/i-ran-all-the-popular-qwen-3-8-fn-engines-on-a-single-5090-v0-21o6k7qeb9xh1.png?width=2400&format=png&auto=webp&s=3c52e9713d993c53d8593733e5aca271b7398049 "Image from r/LocalLLaMA - Decode, short context")

Decode, short context

Decode at context depth
=======================

[![r/LocalLLaMA - Decode at context depth](https://cf.preview.redd.it/i-ran-all-the-popular-qwen-3-8-fn-engines-on-a-single-5090-v0-vb50mligb9xh1.png?width=2400&format=png&auto=webp&s=8f1cf84b492c578259ddfa27a9117f8d5e0ff210)](https://cf.preview.redd.it/i-ran-all-the-popular-qwen-3-8-fn-engines-on-a-single-5090-v0-vb50mligb9xh1.png?width=2400&format=png&auto=webp&s=8f1cf84b492c578259ddfa27a9117f8d5e0ff210 "Image from r/LocalLLaMA - Decode at context depth")

Decode at context depth

Prefill at context depth
========================

[![r/LocalLLaMA - Prefill at context depth](https://cf.preview.redd.it/i-ran-all-the-popular-qwen-3-8-fn-engines-on-a-single-5090-v0-e08rg50ib9xh1.png?width=2400&format=png&auto=webp&s=3858572c4eff78ba0ae4123c2bbd46233d9627d7)](https://cf.preview.redd.it/i-ran-all-the-popular-qwen-3-8-fn-engines-on-a-single-5090-v0-e08rg50ib9xh1.png?width=2400&format=png&auto=webp&s=3858572c4eff78ba0ae4123c2bbd46233d9627d7 "Image from r/LocalLLaMA - Prefill at context depth")

Prefill at context depth

All the numbers
===============

Best value per column in bold.

**Decode, tokens per second**

| Engine | Struct | Conv | Prose | 25K | 50K | 100K | 200K |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Basalt | **354** | **188** | **180** | **190** | **187** | **184** | **160** |
| Infernix | 349 | 170 | 163 | 163 | 174 | 176 | 158 |
| capy-flash | 292 | 165 | 152 | 152 | 143 | 152 | 135 |
| Strata | 204 | 146 | 123 | 130 | 123 | 121 | 114 |
| ninfer-ext | 140 | 101 | 95  | 92  | 86  | 79  | 66  |
| ninfer | 54  | 77  | 45  | 53  | 46  | 47  | 44  |
| llama.cpp | 39  | 39  | 39  | 37  | 36  | 35  | 32  |

**Prefill, tokens per second**

| Engine | 25K | 50K | 100K | 200K |
| --- | --- | --- | --- | --- |
| Basalt | 6,492 | **7,662** | **8,666** | **8,609** |
| Infernix | **6,493** | 6,544 | 6,630 | 6,436 |
| capy-flash | 4,026 | 4,272 | 5,206 | 5,458 |
| Strata | 3,530 | 3,738 | 4,129 | 4,245 |
| ninfer-ext | 3,552 | 4,049 | 4,683 | 4,588 |
| ninfer | 2,080 | 2,236 | 2,308 | 2,248 |
| llama.cpp | 1,354 | 1,420 | 1,394 | 1,257 |

**Time to first token, seconds**

| Engine | Struct | Conv | Prose | 25K | 50K | 100K | 200K |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Basalt | **0.35** | 0.23 | 0.17 | **3.94** | **6.65** | **11.81** | **23.79** |
| Infernix | 0.42 | 0.24 | **0.16** | **3.94** | 7.79 | 15.43 | 31.81 |
| capy-flash | 0.88 | 0.50 | 0.29 | 6.35 | 11.93 | 19.65 | 37.52 |
| Strata | 0.45 | 0.29 | 0.20 | 7.24 | 13.64 | 24.78 | 48.24 |
| ninfer-ext | 1.05 | 0.47 | 0.21 | 7.19 | 12.59 | 21.85 | 44.63 |
| ninfer | 1.78 | **0.19** | 0.17 | 12.28 | 22.80 | 44.32 | 91.07 |
| llama.cpp | 1.09 | 0.75 | 0.31 | 18.87 | 35.91 | 73.39 | 162.86 |

Takeaways
=========

*   Infernix and Basalt are ahead of the rest. Against Infernix, Basalt decodes 10% faster on prose and 10% on conversation, struct is roughly a tie (354 vs 349).
    
*   Prefill at 25K is a tie (3.94 s vs 3.94 s to the first token). From 50K up Basalt pulls away.
    
*   capy-flash was interesting, was the closest of the rest on decode, it is built mostly for two GPUs, so this single GPU run is not its best case.
    
*   llama.cpp ran with MTP off, so it's decode is not comparable with the others. This was just a reference point.
    

How it was run
==============

*   Model: Qwen3.8 FN, NVIDIA's NVFP4 converted for each engine (table below).
    
*   Hardware: RTX 5090, PL 400 W, 128 GB RAM, Linux.
    
*   Sampling: greedy (temperature 0), thinking off, int8 KV cache for every engine (llama ran f16 kv).
    
*   Cold: a fresh server per request, no warm up, one run each. Decode varies between runs, so any gaps under 5% are ties.
    
*   Depth tests: a wikitext prefix of about 25K / 50K / 100K / 200K tokens, then "Write an essay on the Odyssey.", 512 tokens out.
    

**What each engine ran**

| Engine | Commit | Weights | Drafter | Note |
| --- | --- | --- | --- | --- |
| Basalt | 9c3692e7 | NVIDIA NVFP4 experts bit-exact, dense and PLE table 8-bit (Q8\_0) | own MTP drafter (spec 8, shipped default) | Fair pack built with Basalt's converter |
| Infernix | 7dbe99a3 | Dense8 conversion: experts and FP8 PLE bit-exact, dense 8-bit | own DFlash2 drafter | Its README's best setup |
| capy-flash | 4e45286a | Own convert: indexer BF16, GDN 8-bit | own re-distilled MTP head | Single-GPU profile, built mainly for two-GPU tensor parallel |
| Strata | 011c9e60 | Experts bit-exact, dense Q8\_0, PLE from an IQ4\_NL GGUF | Qwen BF16 MTP head repacked | Basalt's upstream |
| ninfer-ext | bc168661 | Own convert: MTP NVFP4, PLE re-scaled FP8, projections 8-bit | own MTP |     |
| ninfer | 64d10fbf | Patched to read NVIDIA's experts and fix the PLE scale | own MTP | Stock dev head did not build, stock converter needs the BF16 base |
| llama.cpp | 36cbf415 | magnitudedev NVFP4 GGUF: experts bit-exact, dense and PLE Q8\_0 | none |     |

Read more

Share [](https://alb.reddit.com/cr?za=RqAwxhuibnu47x3OGmB8uUplpbV_9bh8-aqLdgKVuSp-aul7mccjPWN-Om2ohWzAi8-iX62kxlQBCCXEKCFB-CCv1vYmCsUJNSS_gGKJrn1Try5XK4-zZPHtZ5sw5xGPoGjvdWJfR_gNBS0fNScRu6-KuTz5_wx8frMrD9cRHJnWppHghGZfFYEUBDS6n8MwZ4OL2pbWuQhpjO780tYWc-rMXdEbNf9oggfitCwTVw7WCYi4nkIeiVy0W07JZfUnxuElZMedp_M-rwE8V-7R9B7TlkwuYfAcF9DllJ8Wj3UJhsvbZYkifShhAB_WTZZKnKAad-6J6u63EUKKWweYx3oJib5oRYe1S2S6om4YiFDsyDXFm8ZMZwSK5gevEb4mxBjRtVxU3_hB4Q3NvH8j7WJk8d4x2I8vWEOe3tPEL64KVl_CJU790e82j-eh-UG7SfoFgbNWFeZiynLL6YEOKkESAfwqPDdy_tqbzkigvwuSk5tMJoHUmMy2L9NLRZpCwEIyruT4zY5dqvxewC5vTTZfnuoRn2YGfyW9KeZIIkq1bTRGsuPd_PVTNLB-YR0J5-HCKogHvNVJxfKETNK7aiFi7-Zsi49LlmmeaAFJm3uEisCc04vm4DYAkAzI8acKNsLX3PkUahY9mXs5IOQ5FcI_ewWliSKQR75W1P7zLjcn6Wb1BTAls8h7bzdk8_lNqIiSKcPp4ysB49LVghHNbeb17cMb9xor-PeYt9H4h1rYGhL7culAupCwIRESOcrTFJz57Q9w5kkTbaPwuRYyg8-5iA&zp=PiMYm5QBcby-ZllrVn73sIKQGQQgGHk8_W234_uqHW5tChci5vI7bn7lV5xjC-4smYvYnADHhPSCJnnIRg2ozWlBfSbQdYxBHRLOR1lCJI32-BLNOM9vnPjF90hQ-UjlXJrHvqyAeXW_wY3bJ7UXo8jfTrZKAmkLTopZD8fZeA3Ka49Zg2X1W0zDafagU6lr56oG8fbko1V5_JDEa8Z5GHMfFPSKDEWwxhBCWB6DTw-iUahbdLSJ2XYkKOc7MZp9bwHAbnPypw9DYee1sYJDRLfJB5wVRetK_sW9D0hnsHWIN_tyR3DdfizR6BLLpB1pmPml5Y3LNL0d3tCmXxTi1jmaT1IKjvX06VXjNh6XK-cnrHtitls8sVvbVFl7GyT4Nb91kCX3g-2ssdTnhJA0G3FkFTggR4J8-JU8Ft53R6QjNuqAMcP6b2dF8-JldVRELZzPjA5Uul5xfn2F)

 [![u/AcademicCat1250 avatar](https://cf.preview.redd.it/snoovatar/avatars/c6eafbef-e0fd-4c31-a225-8b76e430091d-headshot.png?width=48&height=48&crop=smart&auto=webp&s=6daffcfb742b84de058bce8898015c4d2125d873)AcademicCat1250](https://www.reddit.com/user/AcademicCat1250/) • [Ad](https://www.reddit.com/user/AcademicCat1250/)
[](https://alb.reddit.com/cr?za=RqAwxhuibnu47x3OGmB8uUplpbV_9bh8-aqLdgKVuSp-aul7mccjPWN-Om2ohWzAi8-iX62kxlQBCCXEKCFB-CCv1vYmCsUJNSS_gGKJrn1Try5XK4-zZPHtZ5sw5xGPoGjvdWJfR_gNBS0fNScRu6-KuTz5_wx8frMrD9cRHJnWppHghGZfFYEUBDS6n8MwZ4OL2pbWuQhpjO780tYWc-rMXdEbNf9oggfitCwTVw7WCYi4nkIeiVy0W07JZfUnxuElZMedp_M-rwE8V-7R9B7TlkwuYfAcF9DllJ8Wj3UJhsvbZYkifShhAB_WTZZKnKAad-6J6u63EUKKWweYx3oJib5oRYe1S2S6om4YiFDsyDXFm8ZMZwSK5gevEb4mxBjRtVxU3_hB4Q3NvH8j7WJk8d4x2I8vWEOe3tPEL64KVl_CJU790e82j-eh-UG7SfoFgbNWFeZiynLL6YEOKkESAfwqPDdy_tqbzkigvwuSk5tMJoHUmMy2L9NLRZpCwEIyruT4zY5dqvxewC5vTTZfnuoRn2YGfyW9KeZIIkq1bTRGsuPd_PVTNLB-YR0J5-HCKogHvNVJxfKETNK7aiFi7-Zsi49LlmmeaAFJm3uEisCc04vm4DYAkAzI8acKNsLX3PkUahY9mXs5IOQ5FcI_ewWliSKQR75W1P7zLjcn6Wb1BTAls8h7bzdk8_lNqIiSKcPp4ysB49LVghHNbeb17cMb9xor-PeYt9H4h1rYGhL7culAupCwIRESOcrTFJz57Q9w5kkTbaPwuRYyg8-5iA&zp=PiMYm5QBcby-ZllrVn73sIKQGQQgGHk8_W234_uqHW5tChci5vI7bn7lV5xjC-4smYvYnADHhPSCJnnIRg2ozWlBfSbQdYxBHRLOR1lCJI32-BLNOM9vnPjF90hQ-UjlXJrHvqyAeXW_wY3bJ7UXo8jfTrZKAmkLTopZD8fZeA3Ka49Zg2X1W0zDafagU6lr56oG8fbko1V5_JDEa8Z5GHMfFPSKDEWwxhBCWB6DTw-iUahbdLSJ2XYkKOc7MZp9bwHAbnPypw9DYee1sYJDRLfJB5wVRetK_sW9D0hnsHWIN_tyR3DdfizR6BLLpB1pmPml5Y3LNL0d3tCmXxTi1jmaT1IKjvX06VXjNh6XK-cnrHtitls8sVvbVFl7GyT4Nb91kCX3g-2ssdTnhJA0G3FkFTggR4J8-JU8Ft53R6QjNuqAMcP6b2dF8-JldVRELZzPjA5Uul5xfn2F)

```

</details>

## Assistant · #49

<details><summary>Reasoning · 1,505 characters</summary>

Now I have the crucial finding: **jesdga95's own cross-engine benchmark (23 Oct 2026) normalized KV to int8 for every engine, with llama.cpp as the exception at f16.** So even the Basalt author's headline comparison deliberately controlled KV dtype rather than testing it. That's the closest published "comparison" — and it's a control, not a comparison.

Also: Infernix has a Quality doc (KL divergence on WikiText-2 against the exact model) with engine settings — that's where fp16 vs bf16 KV *could* be compared. And NInfer-all README mentions `--kv-dtype bf16p` = "BF16's KV bits in 23% fewer bytes".

Let me get the NInfer-all kv-dtype documentation. Let me scrape the ninfer-all docs — maybe docs/serving.md or the README section listing KV dtypes. And the Infernix Quality doc.

Let me scrape:
1. https://github.com/Wallawalla47/Infernix/blob/main/docs/quality.md (guess) — better: search first.
2. ninfer-all README raw for kv-dtype.

Let me scrape the raw README of ninfer-all: https://raw.githubusercontent.com/iamwavecut/ninfer-all/master/README.md — that's large but let me try. Actually web_scrape on raw URL should work.

And Infernix quality doc: let me search for its URL.

Let me do parallel: scrape ninfer-all raw README, and web_search for infernix docs quality.md KL divergence.

Actually, to be efficient: scrape https://github.com/Wallawalla47/Infernix/blob/main/docs/quality.md and the ninfer raw README. If quality.md URL is wrong, I'll get a 404 and can adjust.

Let me try both.


</details>

<details><summary>Tool request · web_scrape · call_f25d51fe2de248d39d29a2d3</summary>

```json
{
  "url": "https://raw.githubusercontent.com/iamwavecut/ninfer-all/master/README.md"
}
```

</details>

<details><summary>Tool request · web_search · call_589e442b1c994a0e997c1659</summary>

```json
{
  "query": "Infernix docs quality.md KL divergence WikiText-2 engine settings KV dtype bf16 int8",
  "limit": 8
}
```

</details>

The Basalt author's own cross-engine run controlled KV at int8 — that's important. Let me get NInfer's kv-dtype docs and Infernix's quality doc.
<details><summary>Tool result · web_scrape · call_f25d51fe2de248d39d29a2d3</summary>

**Firecrawl · section 1 of 5**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,942 characters · included below
- Section 2 · 11,964 characters · omitted from this copy
- Section 3 · 7,143 characters · omitted from this copy
- Section 4 · 11,897 characters · omitted from this copy
- Section 5 · 6,906 characters · omitted from this copy

````text
# NInfer-all

A C++/CUDA inference engine for the Qwen3.5 model family (Qwen3.6 and Qwen3.8 27B, Qwen3.6-35B-A3B,
their fine-tunes and Ternary Bonsai 2), Qwen3.8-Flash-Next and Edge0's latent-MoE models built on it,
Gemma 4 26B-A4B, Recursive's Flint and DeepSeek-V4.1-Flash, on NVIDIA GPUs from Volta to consumer Blackwell, from 8 GB of memory. It serves the OpenAI, Anthropic
and llama.cpp APIs from one GPU, or from up to eight as pipeline stages on Linux. The same chat model
answers [typed decisions](docs/serving.md#typed-decisions): choice, yes/no and score questions about
a state, each option with its probability, through TypeSafe's System One and OpenAI's Decisions APIs.

[What's New](#whats-new) · [Quick start](#quick-start) · [Supported GPUs](#supported-gpus) · [Models](#artifacts) ·
[Highlights](#highlights) · [Features](#features) · [Docker](#docker) · [Building](#building) ·
[Documentation](docs/README.md)

NInfer-all continues [NInfer](https://github.com/Neroued/ninfer) through the NInfer-3090 line and
carries the work of several forks; [CONTRIBUTORS.md](CONTRIBUTORS.md) credits each of them.

> [!NOTE]
> **Support GPU testing.** Choose a custom amount on [GitHub Sponsors](https://github.com/sponsors/iamwavecut)
> to help cover GPU rentals for correctness checks, kernel tuning, and benchmarks.
> This is a voluntary contribution without sponsor benefits.
> For compute credits, GPU access, or individual sponsorship terms,
> [contact the maintainer](https://selit.ski/#contact) directly.

## What's New

<!-- Novelties only: a new model, family, artifact, platform, option, endpoint, format or mode, or a measured speedup of a path that worked. No fixes of any kind (crashes, wrong output, failed starts, missed cases, regressions and the speedups that win them back, the options and defaults they bring), no guards, diagnostics, internal, CI, build, test or documentation changes, and no chronicle: a date without a novelty gets no line. One line per date, a few words per item, each linked to the document with its details; no descriptions, mechanisms, measurements or hardware. Full rule: CONTRIBUTING.md, "Documentation describes the current state". -->

- **2026-11-16:** [System One image boxes and image URLs](docs/serving.md#image-boxes), [`--media-urls`](docs/serving.md#media-urls) that sets the size of a fetched media URL (URLs are refused without it), and Qwen3.8-27B GGUFs with a [condensed vocabulary](docs/weight-conversion.md#a-condensed-vocabulary).
- **2026-11-13:** [Edge0-145B and Edge0-120B](docs/edge0.md), latent-MoE models on the Flash-Next skeleton, converted from Edge0's release folders and [published](#artifacts) for all four releases with the base model's Vision tower, ggml's [NVFP4 blocks](docs/gguf.md), Flash-Next and Edge0 models reading [either family's n-gram table](docs/qwen3-8-flash-next.md#another-table-of-the-same-shape), [DSpine drafting](docs/cli.md#speculative-decoding) in every family from a drafter artifact of its own (`--spec dspine --draft-model`) with [Tencent's Qwen3.8-27B drafter converted](https://huggingface.co/WaveCut/Qwen3.8-27B-DSpine-b16-NInfer-v3), [`--adaptive-mtp` for DFlash, DFlash2 and DSpine](docs/serving.md#adaptive-mtp) on Qwen3.5-core models, and DeepSeek-V4.1 [hot Engram rows in RAM](docs/deepseek-v41.md#the-hot-row-profile) (`--ngram-residency ram-hot`), with a hot-row profile in the published Engram table and in [Edge0's FP8 n-gram table](docs/edge0.md).
- **2026-11-12:** [Launch configuration files](docs/cli.md#launch-configuration-files) (`--config`), with [one for each launch recipe](docs/recipes.md) in `configs/`.
- **2026-11-11:** [Faster prefill](docs/maintainer/qwen3_5-model.md#prefill-decode-and-mtp) and [request preparation](docs/maintainer/qwen3_5-model.md#request-preparation) in every family, disk experts read [from a second drive or straight into GPU memory](docs/expert-disk-reads.md) (`--expert-mirror`, `--expert-direct`), and [Gumbel-max sampling with drafts drawn the same way](docs/cli.md#speculative-decoding) (`--gumbel-sampling`).
- **2026-11-10:** [DFlash2 drafting for Qwen3.6-35B-A3B](docs/cli.md#speculative-decoding), Flash-Next artifacts of [Unsloth's Dynamic v3.1 GGUFs](docs/qwen3-8-flash-next.md#convert), Flash-Next prompts past 8,192 tokens [prefilling 1.1-1.4 times as fast](docs/qwen3-8-flash-next.md#expert-placements) with host or disk experts, Qwen3.5-core prompts that the hybrid cache taps [prefilling in one pass](docs/maintainer/hybrid-prefix-cache-spec.md#72-in-pass-exact-taps) (a 213-token first prompt 11% sooner), the hybrid cache over pipeline stages and tensor parallelism with [`--use-alt-prefix-caching`](docs/serving.md#server-options), DeepSeek-V4.1 [attention caches in the release's FP8/FP4 codes](docs/deepseek-v41.md#what-runs), DSpark drafting with host or disk experts [keeping 64 drafter experts a block on the GPU](docs/deepseek-v41.md#the-drafters-experts), 1.12 times as fast on an RTX 4090 (`--draft-experts`), Flash-Next with device experts [decoding 1.10 times as fast](docs/qwen3-8-flash-next.md#execution) (1.12 with MTP), and context lookup that [keeps the occurrence it copies](docs/flint.md#measurements), 1.06-1.40 times as fast on answers that copy one of two versions of a file (`--lookup-ngram`), and [`--kv-dtype bf16p`](docs/cli.md#context-and-memory), BF16's KV bits in 23% fewer bytes.
- **2026-11-07:** Flash-Next [media prompts in the context cache](docs/qwen3-8-flash-next.md#media-conversations-on-one-rtx-4090) and [MTP drafts for media requests](docs/qwen3-8-flash-next.md#mtp-speculative-decoding).
- **2026-11-06:** Faster Q4_K [prompts](docs/device-profiles.md#what-is-calibrated) for dense layers and routed experts.
- **2026-11-05:** Faster DeepSeek-V4.1 [prefill tail](docs/deepseek-v41.md#the-prefill-tail), [IQ1_M expert prompts](docs/deepseek-v41.md#iq1_m-experts-in-prompt-chunks) and [Engram reads](docs/deepseek-v41.md#the-engram-table).
- **2026-11-04:** Flash-Next [DFlash2 drafting](docs/qwen3-8-flash-next.md#dflash2-speculative-decoding), faster Flash-Next [tensor parallelism](docs/maintainer/pipeline-stages.md#tensor-parallelism-of-qwen38-flash-next) and [concurrent requests with host experts](docs/qwen3-8-flash-next.md#sequences-kv-and-the-context-cache), [BF16 and 8-bit tensor-parallel prompt partials](docs/maintainer/pipeline-stages.md#tensor-parallelism), faster [expert parallelism](docs/maintainer/pipeline-stages.md#expert-parallelism-of-the-other-moe-families), and DeepSeek-V4.1-Flash [conversion of ISTA-DASLab's llama.cpp-layout GGUFs and Coder build](docs/deepseek-v41.md#converting) with a [published Coder artifact](docs/deepseek-v41.md#running).
- **2026-11-03:** Faster [tensor-parallel decode and prefill](docs/maintainer/pipeline-stages.md#tensor-parallelism) for Qwen3.5-core models and llama.cpp [control vectors and direction LoRA adapters](docs/serving.md#lora-adapters-and-control-vectors).
- **2026-11-02:** [Tensor parallelism](docs/maintainer/pipeline-stages.md#tensor-parallelism) selects exchange routes by size from startup timings, including peer writes.
- **2026-10-30:** [Bundled media libraries](docs/release-archive-linux.md#media-libraries), [pre-Blackwell NVFP4](docs/cli.md#common-options), Qwen3.5 FP32 logits, a faster first request after startup, and [prefill pacing](docs/serving.md#execution-behavior).
- **2026-10-29:** [Faster tensor-parallel prefill](docs/maintainer/pipeline-stages.md#tensor-parallelism), with native NVFP4/FP8 shares on RTX 50.
- **2026-10-27:** [Tensor parallelism](docs/maintainer/pipeline-stages.md#tensor-parallelism) speeds up decode without peer access and covers all Flash-Next layers.
  Qwen3.5 gains [invariant attention](docs/maintainer/qwen3_5-model.md#invariant-attention).
  The [DeepSeek-V4.1-Flash STQ drafter](docs/deepseek-v41.md#the-stq-drafter) uses half the VRAM of Unsloth's drafter.
- **2026-10-26:** Flash-Next [prefills and decodes faster with disk experts](docs/qwen3-8-flash-next.md#expert-placements).
  [Tensor parallelism](docs/maintainer/pipeline-stages.md#tensor-parallelism) supports all dense weight formats and DFlash.
  All MoE families support [expert parallelism](docs/maintainer/pipeline-stages.md#expert-parallelism-of-the-other-moe-families).
  [DeepSeek-V4.1-Flash](docs/deepseek-v41.md) gains CPU-assisted expert execution, DSpark drafting, and image input.
- **2026-10-25:** NInfer supports [DeepSeek-V4.1-Flash](docs/deepseek-v41.md) from IQ1_M GGUF with host or disk experts.
  Dense Qwen3.5-core models gain `--tensor-parallel`.
- **2026-10-24:** [Flint](docs/flint.md#measurements) decodes 348 tok/s on an RTX 5090 and 210 on an RTX 4090 with host experts.
- **2026-10-23:** NInfer supports [Flint](docs/flint.md) from Unsloth's UD-Q4_K_XL GGUF.
  [Native releases](https://github.com/iamwavecut/ninfer-all/releases) cover Windows and Debian 13 with CUDA 12.9 and 13.4.
- **2026-10-22:** [Typed decisions](docs/serving.md#typed-decisions) are available at `/v1/decisions` and `/v1/systemone`.
  Every model family supports YaRN.
- **2026-10-20:** [CPU threads compute a share of host experts](docs/qwen3-8-flash-next.md#the-cpu-share) beside the GPU.
- **2026-10-18:** The hybrid prefix cache is the server default.
- **2026-10-17:** [Pipeline stages across GPU architectures](docs/build-linux.md#cards-of-several-architectures-in-one-pipeline) in one build.
- **2026-10-16:** [Device profiles](docs/gpus.md) for 36 more GPUs; Gemma 4 and Qwen MoE experts in host memory or on disk.
- **2026-10-14:** Turing (`sm_75`): the [TITAN RTX](docs/performance/titan-rtx-2026-10.md) and RTX 20 series.
- **2026-10-12:** Volta (`sm_70`): the [Tesla V100](docs/performance/tesla-v100-2026-10.md).
- **2026-10-11:** [Gemma 4 26B-A4B](docs/gemma4.md) with MTP, images and video.
- **2026-10-06:** [Qwen3.8-Flash-Next](docs/qwen3-8-flash-next.md), experts on the GPU, in host memory or on disk.
- **2026-09-26:** NInfer-all and [Qwen3.8-27B GSQ-RCO IQ3_S](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3).
- **2026-09-23:** [Ternary Bonsai 2 27B](https://huggingface.co/WaveCut/Ternary-Bonsai-2-27B-NInfer-v3) on one RTX 3090.

## Quick start

Download an artifact ([all models](#artifacts)) and serve it from the [Docker image](#docker). The server
speaks the OpenAI and Anthropic APIs on http://localhost:8080/v1, answers typed decisions there, and
each card picks up its device profile on its own.

```bash
hf download WaveCut/Ternary-Bonsai-2-27B-NInfer-v3 Ternary-Bonsai-2-27B-ninfer-v3.ninfer --local-dir models

docker run --rm --gpus all -p 8080:8080 --ulimit memlock=-1 \
  -v "$PWD/models:/models" -v ninfer-cache:/cache \
  ghcr.io/iamwavecut/ninfer-all:cuda13.4 serve /models/Ternary-Bonsai-2-27B-ninfer-v3.ninfer \
  --model-id bonsai2-27b --max-context 262144 --kv-capacity 262144 --kv-dtype rk8v4 \
  --gdn-state-fp16 --spec dflash2 --draft-tokens 5

curl http://localhost:8080/v1/chat/completions -H 'Content-Type: application/json' \
  -d '{"model":"bonsai2-27b","messages":[{"role":"user","content":"Hello"}]}'

curl http://localhost:8080/v1/systemone -H 'Content-Type: application/json' -d '{
  "state": {"ticket": "My card was charged twice for one order."},
  "questions": {
    "team": {"type": "choice", "instructions": "Which team should handle this?",
             "criteria": {"billing": "payments and refunds", "shipping": "deliveries"}},
    "urgent": {"type": "noul", "instructions": "Does the customer need a reply within the hour?"}}}'
```

The second request is a [typed decision](docs/serving.md#typed-decisions): each answer comes with the
probability of every option, read from the model's first-token log probabilities of the labels.

Flags for every model and memory size, from an 8 GB card to the largest context: [launch recipes](docs/recipes.md),
each also a [configuration file](docs/cli.md#launch-configuration-files) in `configs/` that `--config`
reads.

````

</details>

<details><summary>Tool result · web_search · call_589e442b1c994a0e997c1659</summary>

**Firecrawl · section 1 of 38**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 10,976 characters · included below
- Section 2 · 11,724 characters · omitted from this copy
- Section 3 · 11,902 characters · omitted from this copy
- Section 4 · 11,435 characters · omitted from this copy
- Section 5 · 11,782 characters · omitted from this copy
- Section 6 · 11,446 characters · omitted from this copy
- Section 7 · 8,550 characters · omitted from this copy
- Section 8 · 11,572 characters · omitted from this copy
- Section 9 · 11,963 characters · omitted from this copy
- Section 10 · 11,734 characters · omitted from this copy
- Section 11 · 11,977 characters · omitted from this copy
- Section 12 · 8,625 characters · omitted from this copy
- Section 13 · 11,446 characters · omitted from this copy
- Section 14 · 11,948 characters · omitted from this copy
- Section 15 · 11,927 characters · omitted from this copy
- Section 16 · 11,952 characters · omitted from this copy
- Section 17 · 11,998 characters · omitted from this copy
- Section 18 · 11,248 characters · omitted from this copy
- Section 19 · 11,470 characters · omitted from this copy
- Section 20 · 11,610 characters · omitted from this copy
- Section 21 · 11,582 characters · omitted from this copy
- Section 22 · 9,217 characters · omitted from this copy
- Section 23 · 10,958 characters · omitted from this copy
- Section 24 · 11,060 characters · omitted from this copy
- Section 25 · 10,496 characters · omitted from this copy
- Section 26 · 9,361 characters · omitted from this copy
- Section 27 · 10,053 characters · omitted from this copy
- Section 28 · 10,180 characters · omitted from this copy
- Section 29 · 11,878 characters · omitted from this copy
- Section 30 · 10,789 characters · omitted from this copy
- Section 31 · 10,806 characters · omitted from this copy
- Section 32 · 11,691 characters · omitted from this copy
- Section 33 · 11,123 characters · omitted from this copy
- Section 34 · 11,682 characters · omitted from this copy
- Section 35 · 7,290 characters · omitted from this copy
- Section 36 · 11,921 characters · omitted from this copy
- Section 37 · 11,897 characters · omitted from this copy
- Section 38 · 3,040 characters · omitted from this copy

```text
## 1. GitHub - Wallawalla47/Infernix: C++/CUDA single-GPU inference ...

https://github.com/wallawalla47/infernix

Quality (KL divergence against an exact reference) is measured on IQ3_S, FP4 ... Settings: INT8 KV, 240,000 tokens, two lanes. NInfer master at ...

[Skip to content](https://github.com/wallawalla47/infernix#start-of-content)
              

You signed in with another tab or window. [Reload](https://github.com/wallawalla47/infernix)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/wallawalla47/infernix)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/wallawalla47/infernix)
 to refresh your session. Dismiss alert

            [](https://github.com/Wallawalla47/Infernix)

main

[**1** Branch](https://github.com/Wallawalla47/Infernix/branches)
[**6** Tags](https://github.com/Wallawalla47/Infernix/tags)

[](https://github.com/Wallawalla47/Infernix/branches)
[](https://github.com/Wallawalla47/Infernix/tags)

Go to file

Code

Open more actions menu

Latest commit
-------------

![Wallawalla47](https://avatars.githubusercontent.com/u/46779408?v=4&size=40)![claude](https://avatars.githubusercontent.com/u/81847?v=4&size=40)

[Wallawalla47](https://github.com/Wallawalla47/Infernix/commits?author=Wallawalla47)

and

[claude](https://github.com/Wallawalla47/Infernix/commits?author=claude)

[test(moe): the idle-service layer test gets a timeout twice its run](https://github.com/Wallawalla47/Infernix/commit/fcac555f23018786f03420934c5c19dd5938eeaa)

Open commit details

Nov 17, 2026

[fcac555](https://github.com/Wallawalla47/Infernix/commit/fcac555f23018786f03420934c5c19dd5938eeaa)
 · Nov 17, 2026

History
-------

[2,379 Commits](https://github.com/Wallawalla47/Infernix/commits/main/)

Open commit details

[](https://github.com/Wallawalla47/Infernix/commits/main/)
2,379 Commits

Folders and files
-----------------

| Name |     | Name | Last commit message | Last commit date |
| --- | --- | --- | --- |
| [.codex](https://github.com/Wallawalla47/Infernix/tree/main/.codex ".codex") |     | [.codex](https://github.com/Wallawalla47/Infernix/tree/main/.codex ".codex") |     |     |
| [.github](https://github.com/Wallawalla47/Infernix/tree/main/.github ".github") |     | [.github](https://github.com/Wallawalla47/Infernix/tree/main/.github ".github") |     |     |
| [apps](https://github.com/Wallawalla47/Infernix/tree/main/apps "apps") |     | [apps](https://github.com/Wallawalla47/Infernix/tree/main/apps "apps") |     |     |
| [bench](https://github.com/Wallawalla47/Infernix/tree/main/bench "bench") |     | [bench](https://github.com/Wallawalla47/Infernix/tree/main/bench "bench") |     |     |
| [cmake](https://github.com/Wallawalla47/Infernix/tree/main/cmake "cmake") |     | [cmake](https://github.com/Wallawalla47/Infernix/tree/main/cmake "cmake") |     |     |
| [docs](https://github.com/Wallawalla47/Infernix/tree/main/docs "docs") |     | [docs](https://github.com/Wallawalla47/Infernix/tree/main/docs "docs") |     |     |
| [eval](https://github.com/Wallawalla47/Infernix/tree/main/eval "eval") |     | [eval](https://github.com/Wallawalla47/Infernix/tree/main/eval "eval") |     |     |
| [examples/cli](https://github.com/Wallawalla47/Infernix/tree/main/examples/cli "This path skips through empty directories") |     | [examples/cli](https://github.com/Wallawalla47/Infernix/tree/main/examples/cli "This path skips through empty directories") |     |     |
| [include/infernix](https://github.com/Wallawalla47/Infernix/tree/main/include/infernix "This path skips through empty directories") |     | [include/infernix](https://github.com/Wallawalla47/Infernix/tree/main/include/infernix "This path skips through empty directories") |     |     |
| [model-cards](https://github.com/Wallawalla47/Infernix/tree/main/model-cards "model-cards") |     | [model-cards](https://github.com/Wallawalla47/Infernix/tree/main/model-cards "model-cards") |     |     |
| [packaging/windows](https://github.com/Wallawalla47/Infernix/tree/main/packaging/windows "This path skips through empty directories") |     | [packaging/windows](https://github.com/Wallawalla47/Infernix/tree/main/packaging/windows "This path skips through empty directories") |     |     |
| [src](https://github.com/Wallawalla47/Infernix/tree/main/src "src") |     | [src](https://github.com/Wallawalla47/Infernix/tree/main/src "src") |     |     |
| [tests](https://github.com/Wallawalla47/Infernix/tree/main/tests "tests") |     | [tests](https://github.com/Wallawalla47/Infernix/tree/main/tests "tests") |     |     |
| [third\_party](https://github.com/Wallawalla47/Infernix/tree/main/third_party "third_party") |     | [third\_party](https://github.com/Wallawalla47/Infernix/tree/main/third_party "third_party") |     |     |
| [tools](https://github.com/Wallawalla47/Infernix/tree/main/tools "tools") |     | [tools](https://github.com/Wallawalla47/Infernix/tree/main/tools "tools") |     |     |
| [.clang-format](https://github.com/Wallawalla47/Infernix/blob/main/.clang-format ".clang-format") |     | [.clang-format](https://github.com/Wallawalla47/Infernix/blob/main/.clang-format ".clang-format") |     |     |
| [.clangd](https://github.com/Wallawalla47/Infernix/blob/main/.clangd ".clangd") |     | [.clangd](https://github.com/Wallawalla47/Infernix/blob/main/.clangd ".clangd") |     |     |
| [.dockerignore](https://github.com/Wallawalla47/Infernix/blob/main/.dockerignore ".dockerignore") |     | [.dockerignore](https://github.com/Wallawalla47/Infernix/blob/main/.dockerignore ".dockerignore") |     |     |
| [.gitattributes](https://github.com/Wallawalla47/Infernix/blob/main/.gitattributes ".gitattributes") |     | [.gitattributes](https://github.com/Wallawalla47/Infernix/blob/main/.gitattributes ".gitattributes") |     |     |
| [.gitignore](https://github.com/Wallawalla47/Infernix/blob/main/.gitignore ".gitignore") |     | [.gitignore](https://github.com/Wallawalla47/Infernix/blob/main/.gitignore ".gitignore") |     |     |
| [AGENTS.md](https://github.com/Wallawalla47/Infernix/blob/main/AGENTS.md "AGENTS.md") |     | [AGENTS.md](https://github.com/Wallawalla47/Infernix/blob/main/AGENTS.md "AGENTS.md") |     |     |
| [CMakeLists.txt](https://github.com/Wallawalla47/Infernix/blob/main/CMakeLists.txt "CMakeLists.txt") |     | [CMakeLists.txt](https://github.com/Wallawalla47/Infernix/blob/main/CMakeLists.txt "CMakeLists.txt") |     |     |
| [CMakePresets.json](https://github.com/Wallawalla47/Infernix/blob/main/CMakePresets.json "CMakePresets.json") |     | [CMakePresets.json](https://github.com/Wallawalla47/Infernix/blob/main/CMakePresets.json "CMakePresets.json") |     |     |
| [Dockerfile](https://github.com/Wallawalla47/Infernix/blob/main/Dockerfile "Dockerfile") |     | [Dockerfile](https://github.com/Wallawalla47/Infernix/blob/main/Dockerfile "Dockerfile") |     |     |
| [LICENSE](https://github.com/Wallawalla47/Infernix/blob/main/LICENSE "LICENSE") |     | [LICENSE](https://github.com/Wallawalla47/Infernix/blob/main/LICENSE "LICENSE") |     |     |
| [README.md](https://github.com/Wallawalla47/Infernix/blob/main/README.md "README.md") |     | [README.md](https://github.com/Wallawalla47/Infernix/blob/main/README.md "README.md") |     |     |
| [RESEARCH\_NOTES.md](https://github.com/Wallawalla47/Infernix/blob/main/RESEARCH_NOTES.md "RESEARCH_NOTES.md") |     | [RESEARCH\_NOTES.md](https://github.com/Wallawalla47/Infernix/blob/main/RESEARCH_NOTES.md "RESEARCH_NOTES.md") |     |     |
| [build\_native.bat](https://github.com/Wallawalla47/Infernix/blob/main/build_native.bat "build_native.bat") |     | [build\_native.bat](https://github.com/Wallawalla47/Infernix/blob/main/build_native.bat "build_native.bat") |     |     |
| [build\_native\_target.bat](https://github.com/Wallawalla47/Infernix/blob/main/build_native_target.bat "build_native_target.bat") |     | [build\_native\_target.bat](https://github.com/Wallawalla47/Infernix/blob/main/build_native_target.bat "build_native_target.bat") |     |     |
| [infernix.example.toml](https://github.com/Wallawalla47/Infernix/blob/main/infernix.example.toml "infernix.example.toml") |     | [infernix.example.toml](https://github.com/Wallawalla47/Infernix/blob/main/infernix.example.toml "infernix.example.toml") |     |     |
| [pytest.ini](https://github.com/Wallawalla47/Infernix/blob/main/pytest.ini "pytest.ini") |     | [pytest.ini](https://github.com/Wallawalla47/Infernix/blob/main/pytest.ini "pytest.ini") |     |     |
| View all files |     |     |

Repository files navigation
---------------------------

 ![Infernix](https://github.com/Wallawalla47/Infernix/raw/main/docs/assets/infernix-logo-light.svg)
===================================================================================================

[](https://github.com/wallawalla47/infernix#------------)

> **AI disclaimer:** everything added since the fork from NInfer, including most of this README, was written with AI (mostly Claude Opus 5.5 and Qwen3.8-27B running on Infernix). It is likely to be neither complete nor entirely accurate. This is hobby development.

Infernix is a C++/CUDA inference engine that serves Qwen models on one NVIDIA RTX 5090. It began as a fork of [NInfer](https://github.com/Neroued/ninfer)
 by [Neroued](https://github.com/Neroued)
 and reads NInfer's `.ninfer` artifacts as well as its own `.infernix` files.

Headline results
----------------

[](https://github.com/wallawalla47/infernix#headline-results)

One RTX 5090 on PCIe Gen5 x8, 2026-10-30/31. Every engine ran its latest version at the time, natively on Windows, with its own recommended settings and drafter and the same 84 GiB RAM budget. **Context**: one request, ~8K to ~250K tokens. **Replay**: an agentic coding workload, two requests at a time. Full tables and methods: [Benchmarks](https://github.com/wallawalla47/infernix#benchmarks)
.

**Speed without precision shortcuts.** Infernix keeps every activation at the precision the checkpoint specifies (16 bits where the others round to 8), runs every routed expert (no expert tail skipping) and computes the full output head (no 2-bit screen). Basalt, which computes with fewer bits (6-bit dense layers on NVFP4; on IQ3\_S 8-bit activations, an 8-bit copy of the hyper-connection matrices and a 2-bit head screen), has the highest decode tok/s at Infernix's defaults. On NVIDIA's NVFP4 weights Infernix still reaches the first token 5-8× sooner and finishes the agentic workload 36 % sooner, and with its experts at 8 bits as Basalt runs them it matches or passes Basalt's decode too. On the IQ3\_S GGUF Basalt is ahead overall (4.4 against 5.5 min); with the same 8-bit activations Infernix matches its first tokens, but Basalt still decodes faster. Measured quality on IQ3\_S, FP4-Local and the 27B, against the exact model: [Quality](https://github.com/wallawalla47/infernix#quality)
 (NVIDIA's NVFP4 weights not yet).

```

</details>

## Assistant · #52

<details><summary>Reasoning · 619 characters</summary>

Now I have NInfer's `--kv-dtype` documented in docs/cli.md#context-and-memory, and importantly `--gdn-state-fp16` — a flag for the Gated DeltaNet state in fp16! That's a very relevant engine-specific knob.

Let me get docs/cli.md#context-and-memory from ninfer-all, which lists kv-dtype allowed values (bf16, fp16?, int8, bf16p, rk8v4, etc.) and any quality notes. Let me scrape the raw doc.

URL: https://raw.githubusercontent.com/iamwavecut/ninfer-all/master/docs/cli.md

And also the Infernix quality doc: https://raw.githubusercontent.com/Wallawalla47/Infernix/main/docs/quality.md

Let me scrape both in parallel.


</details>

<details><summary>Tool request · web_scrape · call_bdcbe1b7a3f24541b31da457</summary>

```json
{
  "url": "https://raw.githubusercontent.com/iamwavecut/ninfer-all/master/docs/cli.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_05a21474e3cf451a9b83c914</summary>

```json
{
  "url": "https://raw.githubusercontent.com/Wallawalla47/Infernix/main/docs/quality.md"
}
```

</details>

NInfer documents `--kv-dtype` and a `--gdn-state-fp16` knob. Let me read the actual option docs and Infernix's quality measurements.
<details><summary>Tool result · web_scrape · call_bdcbe1b7a3f24541b31da457</summary>

**Firecrawl · section 1 of 6**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,161 characters · included below
- Section 2 · 11,583 characters · omitted from this copy
- Section 3 · 10,904 characters · omitted from this copy
- Section 4 · 11,839 characters · omitted from this copy
- Section 5 · 11,952 characters · omitted from this copy
- Section 6 · 978 characters · omitted from this copy

````text
# NInfer CLI

`build/apps/ninfer` (the Docker image's `ninfer` command) runs one request against one v3
`.ninfer` artifact. Build NInfer or pull the image, and download an artifact, as the
[project README](../README.md) describes before following this guide.

The examples use the official Qwen3.8-27B `groupwise-int` artifact with INT8 KV storage.

## Text input

```bash
./build/apps/ninfer models/qwen3_8_27b.ninfer \
  --prompt "Summarize the difference between prefill and decode." \
  --max-context 32768 \
  --max-new 8192 \
  --kv-dtype int8 \
  --spec mtp --draft-tokens 3 \
  --lm-head-draft
```

Exactly one of `--prompt` and `--messages` is required. The CLI normally omits `--kv-capacity`, so
the shared Main Text KV pool follows the example's 32,768-token `--max-context`.

Answer content is streamed to stdout. Reasoning, model loading (including the registered target and
canonical `weights_id`), timings, throughput, GPU memory, and speculative-decoding statistics are
written to stderr, so stdout can be redirected independently. FFmpeg's media-decoding messages are
records prefixed `media |`: FFmpeg errors are warnings and everything milder is `debug`.

```bash
./build/apps/ninfer models/qwen3_8_27b.ninfer \
  --prompt "Return one sentence." \
  --max-context 4096 \
  --max-new 64 \
  --kv-dtype int8 \
  > answer.txt 2> run.log
```

`--chat-template FILE` overrides the artifact's built-in template with a local Jinja file.
Changes to the file take effect after restarting NInfer:

```bash
./build/apps/ninfer models/qwen3_8_27b.ninfer \
  --chat-template tools/chat_templates/qwen3_8.jinja --prompt "Hello"
```

Omitted thinking and effort options use the selected template's defaults. `--no-thinking` or
`--reasoning-effort none` requests disabled thinking; other effort values cannot be combined with
`--no-thinking`. The template interprets the selected effort; a value the template rejects renders
as the nearest one it accepts (see [serving](serving.md)). `--greedy` selects exact argmax
decoding independently.

`--thinking-budget N` places a positive upper bound on accepted model-origin tokens while the
new-turn Qwen thinking block remains open. If the model has not emitted `</think>` at that exact
boundary, Engine appends [Qwen's canonical early-close guidance](https://github.com/QwenLM/Qwen3/blob/main/docs/source/getting_started/thinking_budget.md)
and `</think>` to the same resident sequence without sampling, publishes the guidance through the
reasoning stream, then resumes ordinary generation from the updated context. A natural thinking
close, stop condition, cancellation, or total output/context limit at the boundary takes priority
and suppresses this insertion. The option cannot be combined with `--no-thinking` or
`--reasoning-effort none`, which both disable thinking, but it can be combined with any other
`--reasoning-effort`.

`--reasoning-loop off|stop|conclude` (default `off`) ends the reply (`stop`) or closes the thinking
with the same control span and lets the model answer (`conclude`) when the open thinking keeps
repeating itself. Every 512 thinking tokens the guard checks three signs: 25 % of the last 2,000
words lie inside a 12-word passage seen three times, the last 2,048 characters repeat one period of
at most 64 characters, or they do so with their numbers masked while every number of the period
keeps its own step and one of them moves (a loop that counts, `'time1','time2',...`; a counter
beside values that change otherwise is an enumeration and does not fire). `conclude` stops
instead when the output left cannot hold the control span and one more token; Gemma 4 and Flint
have no early-close control, so there it always stops. The run summary prints `reasoning loop`
when the guard fires. The option cannot be combined with `--no-thinking`. The check and its
limits are described in [serving](serving.md#openai-chat-completions), under `--reasoning-loop`.

`--max-new` counts every committed generated token, including internally inserted control tokens.
The inserted suffix is never truncated, and a request is never rejected for lacking room for it.
When the output capacity left after the budget cannot hold the complete tokenizer-derived control
suffix plus one post-close model token, Engine lowers the effective budget so both fit. When the
whole capacity is no larger than that, the budget cannot be enforced, so thinking runs to the
`--max-new` limit and may end inside the reasoning. The run summary prints `effective thinking
budget` when it differs from the requested one, and nothing extra when the budget is unenforced; the
exact rule is in [Chat Completions](serving.md#openai-chat-completions).

Normal output sends the inserted guidance to stderr as reasoning. `--print-token-ids` includes the
inserted IDs, while `--raw-output` preserves the raw control representation.

For example, this allows at most 512 model-origin thinking tokens while retaining enough total
output capacity for the inserted suffix and the answer:

```bash
./build/apps/ninfer models/qwen3_8_27b.ninfer \
  --prompt "Explain speculative decoding, then give a concise conclusion." \
  --max-context 4096 \
  --max-new 1024 \
  --thinking-budget 512 \
  --kv-dtype int8 \
  --spec mtp --draft-tokens 3 \
  --lm-head-draft
```

## Startup memory profile

GPU residency is frozen when the Engine starts:

- no `--spec` omits MTP/DFlash/DFlash2 weights and state and the optimized proposal head, except
  where the Engine chooses a drafter (Qwen3.8-Flash-Next and Gemma 4 with host experts; see
  `--spec` below);
- `--spec mtp`, `--spec dflash` (35B-A3B), and `--spec dflash2` (Qwen3.8-27B, Qwen3.6-35B-A3B,
  Qwen3.8-Flash-Next) load only the selected speculative backend;
- `--spec dspine --draft-model PATH` loads that drafter artifact on the device of the model's head
  and derives its head-write table from the head;
- a speculative backend loads the artifact's optimized proposal head when it stores one, unless
  `--full-draft-head` keeps the drafts on the full output head and omits it;
- Vision is disabled by default, omitting its weights and Vision-specific unified-workspace extent;
- `--vision` loads the weights, expands the one Program workspace for Vision encode/handoff, and
  enables image/video input.
- the one-request CLI uses root-only context mode, so it does not reserve an extra Device
  checkpoint StateImage or capture a continuation that no later request could consume.

The complete `.ninfer` inventory is still validated. These choices are not lazy loading: an Engine
started without Vision rejects media and cannot enable Vision later. DFlash/DFlash2 and Vision may
be enabled together; these backends apply to generated-text decode after multimodal prefill and does not
accelerate Vision encode. The default speculative and Vision settings produce the smallest resident
profile.

## Structured messages

`--messages` accepts either a non-empty JSON message array or an object containing `messages`
and an optional `tools` array.

```json
[
  {
    "role": "system",
    "content": "Answer concisely."
  },
  {
    "role": "user",
    "content": [
      {
        "type": "image",
        "image": "examples/cli/media/visual_chart.png"
      },
      {
        "type": "text",
        "text": "Describe the chart."
      }
    ]
  }
]
```

Run message files from the repository root when they contain repository-relative media paths:

```bash
./build/apps/ninfer models/qwen3_8_27b.ninfer \
  --messages examples/cli/messages/image_chart.json \
  --max-context 8192 \
  --max-new 128 \
  --kv-dtype int8 \
  --vision \
  --spec mtp --draft-tokens 3 \
  --lm-head-draft
```

Supported roles are `system`, `developer`, `user`, `assistant`, and `tool`.
The selected template formats these roles. The maintained Qwen templates keep system/developer
messages at their input positions.

Message content may be a string or an ordered array containing:

| Content type | Source field | Accepted source |
|---|---|---|
| text | `text` | string |
| image / image_url | `image` or `image_url` | local path, HTTP(S) URL, or base64 data URI |
| video / video_url | `video` or `video_url` | local path, HTTP(S) URL, or base64 data URI |

`image_url` and `video_url` may be strings or objects containing a string `url`. The decoded
formats are listed in [media formats](serving.md#media-formats). Assistant
history may include `reasoning_content` and `tool_calls`; a tool result uses role `tool` and
`tool_call_id`.

See [`examples/cli/`](../examples/cli/) for committed text, image, video, mixed-media, thinking,
long-decode, and long-context inputs.

## Speculative decoding

Speculative decoding is disabled by default. Select MTP, the 35B-A3B DFlash or the Qwen3.8-27B
DFlash2 backend with one to fifteen draft positions. Only one backend can be enabled per Engine.
Drafts go through the artifact's optimized proposal head when it stores one: a vocabulary shortlist
(131,072 rows of the 27B's 248,320) that is cheaper to project at every draft step, for the memory
of that matrix (0.3 GiB with the 27B GSQ-RCO IQ3_S artifact). `--lm-head-draft` requires the
proposal head and `--full-draft-head` keeps the full output head; both need a selected backend.
Both masked-draft backends may be combined with `--vision`:

```bash
./build/apps/ninfer models/qwen3_6_35b_a3b.ninfer \
  --prompt "Write a short explanation of speculative decoding." \
  --max-context 16384 \
  --max-new 512 \
  --kv-dtype int8 \
  --spec mtp --draft-tokens 3 \
  --lm-head-draft
```

For DFlash:

```bash
./build/apps/ninfer models/qwen3_6_35b_a3b.ninfer \
  --prompt "Write a short explanation of speculative decoding." \
  --max-context 16384 --max-new 512 \
  --kv-dtype int8 \
  --spec dflash --draft-tokens 7 --lm-head-draft
```

For Qwen3.8-27B artifacts containing the DFlash2 companion weights, select
`--spec dflash2 --draft-tokens 7`, optionally with `--lm-head-draft` and `--vision`; this is what
the launchers pass. DFlash2 accepts every draft count from 1 through 15. Both `groupwise-int` and
`nvfp4` artifacts use the same Engine route, including CUDA Graph, concurrent requests, sampling
penalties, and prefix reuse. An artifact without the companion weights reports a missing DFlash2
component when selected. Vision, MTP and DFlash follow the same rule: their weights are required
only when that component is enabled at startup.

A Qwen3.6-35B-A3B artifact converted with
[incoai's DFlash2 drafter](https://huggingface.co/incoai/Qwen3.6-35B-A3B-DFlash2)
(`--components ...,dflash2 --source dflash2=PATH`) takes the same `--spec dflash2`. That drafter was
trained on blocks of eight positions, so `--draft-tokens` past 7 asks it for positions it never saw.
On an RTX 5090 with the NVFP4 artifact resident (400 greedy tokens, 2026-11-10) a code answer
decoded 403 tokens per second without drafts, 829 with three MTP drafts and 805, 919 and 892 with
three, five and seven DFlash2 drafts; a prose answer 403, 548 and 465, 420 and 385; the benchmark
corpus (`ninfer_bench`, 128 tokens) 403, 497 and 427, 350 and 455. Draft with it where the output is
code; MTP stays ahead elsewhere.

````

</details>

<details><summary>Tool result · web_scrape · call_05a21474e3cf451a9b83c914</summary>

**Firecrawl · section 1 of 3**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,220 characters · included below
- Section 2 · 11,631 characters · omitted from this copy
- Section 3 · 1,248 characters · omitted from this copy

```text
# Output quality against the exact model

How closely each engine's next-token distributions match the exact computation of the same weights,
measured with llama.cpp's KL-divergence statistics on WikiText-2. The [README](../README.md#quality)
summarises the results; this page gives them in full with their intervals, defines each statistic,
records every engine's version and settings, and describes how to repeat the measurement.

Measured 2026-11-05/06 (FP4-Local 2026-11-08) on one RTX 5090 (32 GB, PCIe Gen5 x8), Core i9-13900K,
96 GB DDR5, Windows 11.
NInfer and vLLM ran in WSL2 (Ubuntu) on the same machine; every other engine ran natively on Windows.

## Results

Brackets are 95 % intervals: a bootstrap over chunks (10,000 resamples), or, for llama.cpp's rows,
llama-perplexity's own ± (it gives no interval for the 99.9 % KLD). "× rounding" is the row's mean
KLD divided by honest rounding's.

### Qwen3.8-27B NVFP4

All four engines run one model: NInfer's official artifact
[neroued/Qwen3.8-27B-nvfp4-NInfer](https://huggingface.co/neroued/Qwen3.8-27B-nvfp4-NInfer) (Unsloth's
NVFP4/FP8 weights; SHA256 `74d2c57145e6ff11d1d2faa79594477f9bc903a611af1fb20218189fbbb77d82`, the file
TensorSharp pins). vLLM cannot load the artifact, so it loads
[unsloth/Qwen3.8-27B-NVFP4](https://huggingface.co/unsloth/Qwen3.8-27B-NVFP4) with its embedding replaced
by the artifact's ([below](#vllms-checkpoint)). BF16 KV for every engine. The reference's perplexity on
the scored positions is 7.0353.

| Path | Engine | Mean KLD | × rounding | KLD 99.9 % | Top-1 agreement | PPL vs reference |
|---|---|---|---:|---|---|---|
| — | Honest rounding (noise twin, seed 1) | 0.00160 [0.00141, 0.00186] | 1.0 | 0.046 [0.036, 0.063] | 98.15 % [98.07, 98.22] | +0.07 % [+0.03, +0.10] |
| Prompt | Infernix (default) | 0.01690 [0.01604, 0.01798] | 10.5 | 0.655 [0.588, 0.786] | 94.47 % [94.34, 94.60] | +0.69 % [+0.56, +0.82] |
| Prompt | NInfer `a754fcf3b` | 0.01660 [0.01588, 0.01753] | 10.4 | 0.660 [0.561, 0.794] | 94.48 % [94.34, 94.61] | +0.67 % [+0.50, +0.84] |
| Prompt | vLLM 0.33.0 | 0.01796 [0.01712, 0.01898] | 11.2 | 0.685 [0.598, 0.802] | 94.28 % [94.14, 94.41] | +0.70 % [+0.55, +0.84] |
| Prompt | TensorSharp `0c45b34c` | 0.01695 [0.01612, 0.01791] | 10.6 | 0.645 [0.552, 0.722] | 94.42 % [94.28, 94.55] | +0.76 % [+0.62, +0.90] |
| Decode | Infernix (default: DFlash2 + n-gram drafts) | 0.00442 [0.00393, 0.00507] | 2.76 | 0.197 [0.165, 0.257] | 97.38 % [97.29, 97.47] | −0.10 % [−0.20, +0.00] |
| Decode | NInfer (MTP, 3 drafts) | 0.00439 [0.00390, 0.00502] | 2.74 | 0.201 [0.163, 0.282] | 97.52 % [97.44, 97.61] | −0.02 % [−0.10, +0.06] |
| Decode | vLLM (MTP, 3 drafts) | 0.01783 [0.01695, 0.01890] | 11.1 | 0.647 [0.583, 0.773] | 94.23 % [94.09, 94.36] | +0.79 % [+0.64, +0.94] |
| Decode | TensorSharp (DFlash2, 7 drafts) | 0.01504 [0.01427, 0.01605] | 9.4 | 0.611 [0.540, 0.706] | 94.94 % [94.82, 95.06] | +0.60 % [+0.45, +0.75] |

### Qwen3.8-Flash-Next IQ3_S

All engines run one GGUF's weights:
[ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)
IQ3_S. llama.cpp loads the GGUF itself, Infernix its import
[Wallawalla47/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Infernix](https://huggingface.co/Wallawalla47/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Infernix)
(with its n-gram volume), Strata and Basalt their own packs built from it. KV is 8-bit for every engine:
INT8 for Infernix, Strata and Basalt, Q8_0 for llama.cpp. The reference's perplexity on the scored
positions is 4.6465.

| Path | Engine | Mean KLD | × rounding | KLD 99.9 % | Top-1 agreement | PPL vs reference |
|---|---|---|---:|---|---|---|
| — | Honest rounding (noise twin, seed 1) | 0.01601 [0.01545, 0.01659] | 1.00 | 0.577 [0.509, 0.636] | 95.36 % [95.21, 95.50] | +0.04 % [−0.08, +0.15] |
| Prompt | Infernix (default) | 0.01465 [0.01409, 0.01522] | 0.91 | 0.496 [0.458, 0.545] | 95.59 % [95.45, 95.74] | +0.08 % [−0.03, +0.19] |
| Prompt | llama.cpp b12128 | 0.01505 [0.01484, 0.01527] | 0.94 | 0.499 | 95.43 % [95.32, 95.54] | −0.03 % [−0.13, +0.08] |
| Decode | Infernix (default: DFlash2 drafts) | 0.01443 [0.01392, 0.01495] | 0.90 | 0.472 [0.435, 0.522] | 95.59 % [95.45, 95.73] | −0.04 % [−0.15, +0.07] |
| Decode | llama.cpp (forced 4-token windows) | 0.01514 [0.01492, 0.01537] | 0.95 | 0.508 | 95.53 % [95.42, 95.64] | +0.05 % [−0.06, +0.16] |
| Decode | Basalt v0.2.1 (verify windows of 4) | 0.01922 [0.01859, 0.01986] | 1.20 | 0.579 [0.522, 0.632] | 95.29 % [95.14, 95.43] | +0.47 % [+0.33, +0.60] |
| Decode | Strata v0.2.11 (tail skip on, its default) | 0.02314 [0.02225, 0.02408] | 1.45 | 0.803 [0.725, 0.881] | 94.44 % [94.26, 94.60] | −0.00 % [−0.16, +0.14] |

### Qwen3.8-Flash-Next NVIDIA FP4-Local

Infernix only, on its conversion of NVIDIA's quantization-aware-distilled FP4 checkpoint
[Wallawalla47/Qwen3.8-Flash-Next-NVIDIA-FP4-Local-Infernix](https://huggingface.co/Wallawalla47/Qwen3.8-Flash-Next-NVIDIA-FP4-Local-Infernix)
(NVIDIA's NVFP4 experts with 16-bit activations and MXFP8 dense layers, bit-exact; its n-gram volume),
INT8 KV. The first 200 chunks only (51,000 scored positions), so the intervals are wider than the
tables above. Besides the default route, the reproducible route (`--reproducible`: no fast paths) and
each default fast path alone were measured. The reference's perplexity on the scored positions is
4.1642.

| Path | Engine | Mean KLD | × rounding | KLD 99.9 % | Top-1 agreement | PPL vs reference |
|---|---|---|---:|---|---|---|
| — | Honest rounding (noise twin, seed 1) | 0.01475 [0.01388, 0.01566] | 1.00 | 0.526 [0.465, 0.610] | 95.60 % [95.35, 95.85] | +0.15 % [−0.03, +0.33] |
| Prompt | Infernix (`--reproducible`, BF16 KV) | 0.01310 [0.01235, 0.01387] | 0.89 | 0.401 [0.375, 0.481] | 96.00 % [95.76, 96.24] | −0.00 % [−0.20, +0.19] |
| Prompt | Infernix (`--reproducible`) | 0.01313 [0.01238, 0.01392] | 0.89 | 0.454 [0.381, 0.519] | 95.98 % [95.74, 96.21] | −0.02 % [−0.22, +0.17] |
| Prompt | Infernix (default) | 0.01364 [0.01283, 0.01446] | 0.92 | 0.482 [0.433, 0.539] | 96.01 % [95.75, 96.26] | +0.07 % [−0.12, +0.26] |
| Decode | Infernix (`--reproducible`, DFlash2 drafts) | 0.01318 [0.01241, 0.01396] | 0.89 | 0.431 [0.370, 0.508] | 95.98 % [95.75, 96.21] | −0.01 % [−0.18, +0.16] |
| Decode | Infernix (default: DFlash2 drafts) | 0.01323 [0.01248, 0.01403] | 0.90 | 0.457 [0.410, 0.514] | 96.04 % [95.78, 96.29] | +0.09 % [−0.07, +0.27] |

The default route's fast paths on this model, each alone against the same route without it (paired on
the same positions; "worst" divides the upper bound of each statistic's change by honest rounding's
value and takes the largest):

| Fast path | Path | Δ Mean KLD | Δ KLD 99.9 % | Δ Top-1 agreement | Worst / honest rounding |
|---|---|---|---|---|---:|
| `expert-a4-residual` | prompt | +0.00060 [+0.00025, +0.00096] | +0.012 [−0.062, +0.096] | −0.16 pt [−0.34, +0.02] | 0.18 |
| `screened-lm-head` | decode | +0.00000 [−0.00000, +0.00000] | +0.000 [−0.000, +0.000] | +0.00 pt [+0.00, +0.00] | 0.00 |

### Observations

- **27B prompt path.** All four engines sit at 10.4-11.2× honest rounding, with perplexity up
  0.67-0.76 %. Their intervals overlap, so this is the artifact's prompt path, not any one engine's:
  it computes with quantized activations (4-bit in the NVFP4 layers with the checkpoint's calibrated
  scales, 8-bit in the FP8 layers).
- **27B decode path.** Infernix and NInfer keep 16-bit activations in their decode and verify steps and
  fall to 2.7× honest rounding, with no measurable perplexity change. vLLM stays where its prompt path
  is (11.1×), consistent with 4-bit activations in its NVFP4 layers on every path. TensorSharp's
  verify quantizes the NVFP4 layers' inputs to 4 bits in any window of 4 or more rows, and its shipped
  configuration verifies 8 (7 drafts), hence 9.4×; its exact 16-bit verify module
  (`TS_Q35_NINFER_EXACT_VERIFY_PTX`) is an opt-in that its shipped configuration does not load.
- **IQ3_S floor.** Honest rounding is 10× higher here than on the 27B: a small rounding difference
  can change which experts the router picks, and the change then spreads. Infernix's and llama.cpp's
  defaults come in slightly *below* it (0.90-0.95×), most likely because rounding to nearest at the
  same precisions has about half the error variance of stochastic rounding.
- **Basalt** is 1.20× honest rounding, and its +0.47 % perplexity is the only IQ3_S change whose
  interval excludes zero. Basalt computes some parts of the model with fewer bits (the README's
  [IQ3_S comparison](../README.md#qwen38-flash-next-iq3_s-infernix-vs-strata-and-basalt) lists them).
- **Strata** is 1.45× honest rounding with no perplexity change. Its default route tail skip
  (`STRATA_ROUTE_TAIL_SKIP=7`: a missed expert that every token of a verify window routes at rank 7 or
  lower is not computed) skipped 3.9 million expert computations over the run.
- **FP4-Local** sits below honest rounding on both paths (0.89-0.92×), as IQ3_S does. Its two default
  fast paths are within rounding (at most 0.18× honest rounding), and its decode statistics are the
  same with DFlash2 drafting as with one-token decode (to every printed digit), as exact verification
  should leave them.
- **Perplexity alone would hide most of this.** Strata's distributions are 1.45× further from the
  exact model than honest rounding's, yet its perplexity matches the reference's to two decimals. See
  [PPL vs reference](#ppl-vs-reference).

## What the statistics mean

Every statistic compares, position by position, the engine's next-token distribution with the
reference's for the same preceding text.

- **The reference** is Infernix's lossless route on the same weights: every operation of the model
  correctly rounded at the model's own dtypes ([definition](maintainer/lossless-route.md)), BF16 KV,
  one pass per chunk. It is the model as specified, computed without error.
- **Honest rounding** (the noise twin) is the lossless route with every rounding made stochastic:
  each correctly rounded result goes up or down with probabilities set by the discarded fraction
  ([definition](maintainer/lossless-route.md#5-the-noise-twin)). It is an ideal implementation that is
  off by at most one unit in the last place at every rounding and by nothing else, so its distance
  from the reference is the model's own sensitivity to rounding. An engine near 1× computes as
  faithfully as rounding allows; 10× means ten times that distance.
- **Mean KLD** is the mean over positions of KL(reference ‖ engine): how much probability mass the
  engine moves, on average. Lower is better; 0 means identical distributions.
- **KLD 99.9 %** is the 99.9th percentile of the per-position KLD: how far the worst 0.1 % of
  positions (148 of 147,900) move.
- **Top-1 agreement** is the share of positions where the engine's most likely token is the
  reference's: how often greedy decoding would pick the same token.
- **PPL vs reference** is the engine's perplexity on the text as a change from the reference's:
  100 × (exp(mean(ln p_ref − ln p_engine)) − 1) %, with p the probability given to the text's actual
  next token, on the same positions.

### PPL vs reference

```

</details>

## Assistant · #55

<details><summary>Reasoning · 9,823 characters</summary>

This is gold. Now I have the definitive answer with real numbers.

Key facts:

**Infernix docs/quality.md** — the only published measurement that actually holds KV dtype fixed across Basalt/Strata/llama.cpp/NInfer on Flash-Next IQ3_S, using KL divergence against a "lossless route" reference.

Critically:
- **The reference itself is BF16 KV** ("The reference is Infernix's lossless route on the same weights... BF16 KV"). So Infernix treats BF16 as the *exact/specified* KV dtype for Flash-Next — because the checkpoint is bf16.
- For the **Qwen3.8-27B NVFP4** table: "BF16 KV for every engine" — again BF16 as the normalization choice.
- For **IQ3_S Flash-Next**: "KV is 8-bit for every engine: INT8 for Infernix, Strata and Basalt, Q8_0 for llama.cpp." So the IQ3_S comparison is *not* FP16 vs BF16 — it's INT8/Q8_0 across all engines. Basalt and Strata run INT8 KV there.
- The FP4-Local table has an explicit **BF16 KV row vs default (INT8) KV row** on the same model, same engine, paired: 
  - `Infernix (--reproducible, BF16 KV)`: mean KLD 0.01310 [0.01235, 0.01387], KLD99.9 0.401 [0.375,0.481], top-1 96.00%
  - `Infernix (--reproducible)` [INT8 KV]: mean KLD 0.01313 [0.01238, 0.01392], KLD99.9 0.454 [0.381, 0.519], top-1 95.98%
  → The delta is 0.00003, i.e. **completely inside the interval**. That is the single closest thing to a published FP16/BF16-vs-quantized KV quality comparison on this model, and it says: at 200 chunks / 51,000 positions, BF16 KV is indistinguishable from INT8 KV. Honest rounding = 0.01475. So KV dtype is below the noise floor of the model's own rounding sensitivity.

Also: NInfer's `--kv-dtype bf16p` (2026-11-10) = "BF16's KV bits in 23% fewer bytes" — i.e., they treat BF16 as a *reference format to be compressed*, not a precision target. And `--gdn-state-fp16` exists — the DeltaNet state in fp16 is an *option*, implying default is f32.

And NInfer docs/cli.md examples use `--kv-dtype int8` as the canonical documented default; `rk8v4` in the quick start.

Basalt: runs FP16 KV (per user). And in jesdga95's own 7-engine benchmark, "int8 KV cache for every engine (llama ran f16 kv)" — so Basalt was run at int8 there, contradicting/complicating the "Basalt runs FP16" claim; possibly Basalt has a fixed fp16 KV in the current version, or the int8 was a per-engine setting. Actually the table says "Sampling: greedy (temperature 0), thinking off, int8 KV cache for every engine (llama ran f16 kv)." So Basalt ran int8 KV in that Oct 23 benchmark. But Infernix quality doc says for IQ3_S: "KV is 8-bit for every engine: INT8 for Infernix, Strata and Basalt, Q8_0 for llama.cpp." Consistent: Basalt = INT8 there.

Hmm, but the user says Basalt runs FP16 and Ninfer runs BF16. Perhaps in current versions the defaults changed. Either way — the important point: **the published cross-engine work on this model never varied KV dtype; it pinned KV to a single format and varied the *arithmetic* (activations) instead.** The Infernix quality doc explicitly lists what differs between engines: activations, hyper-connection matrices, head screen, route tail skip — never KV.

So the answer: 
1. Where comparisons exist: Infernix docs/quality.md (the only one with a BF16-KV row vs INT8-KV row on Flash-Next, and it's within noise); jesdga95's Reddit 7-engine benchmark (KV pinned to int8 as a control); Infernix README activation-precision tables (the real published differentiator between Basalt/NInfer/Strata/Infernix).
2. Neither Basalt nor NInfer publishes an FP16-vs-BF16 KV number for Flash-Next. Basalt's repo/README doesn't document KV dtype as a knob. NInfer documents `--kv-dtype` with bf16/bf16p/int8/rk8v4 etc. but with no quality numbers.
3. The decisive technical argument: bf16p being marketed as "BF16's KV bits in 23% fewer bytes" shows NInfer treats bf16 as a format to compress, and the reference (lossless route) is BF16 KV — because the checkpoint is bf16. So for NInfer, BF16 KV = "as specified"; for Basalt, FP16 KV = more mantissa bits for in-range values.
4. The magnitude question: Infernix's own noise-floor methodology gives the answer — honest rounding on IQ3_S = 0.01601 mean KLD, and the BF16-vs-INT8 KV delta on FP4-Local = 0.00003, ~0.2% of honest rounding. So KV dtype between f16 and bf16 (a 3-bit mantissa change on values that fit in f16) is far below the model's own rounding sensitivity — which matches the user's observation that Q8 PLE + IQ3_S is near-identical.
5. Caveats: the BF16/INT8 comparison is 200 chunks only (wider intervals), prompt path only for the BF16 row, and it's Infernix's own reference (self-referential: reference uses BF16 KV, so BF16 KV rows are compared against a BF16-KV reference — a bias toward BF16 looking good). That last point is important and honest: **the reference itself uses BF16 KV, so this test cannot cleanly rank BF16 vs FP16 — it's biased in BF16's favor, and BF16 still only ties INT8.** That's a strong inference.
6. Also: what actually differs between the two engines per published measurements is not KV — it's Basalt's 8-bit activations, 8-bit hyper-connection copies, 2-bit head screen (+0.47% PPL, the only IQ3_S change whose CI excludes zero, 1.20× honest rounding) vs Strata's route tail skip (1.45×). So if the user is chasing quality differences between Basalt and NInfer, KV dtype is the wrong variable; activations are the published one.
7. Also note: for Flash-Next, `-ctk/-ctv`-equivalent doesn't touch the GDN recurrent state, and NInfer has `--gdn-state-fp16` as a separate flag → the DeltaNet state is a separate precision decision that dwarfs KV dtype here (149.6 MiB f32 vs 24 KiB/token KV). Actually wait — that was for qwen35 27B. For Flash-Next, 36 GDN layers. Let me be careful: the 149.6 MiB figure was computed for Qwen3.8-27B (qwen35 arch) from issue #29324. For Flash-Next, Myric says 24 KiB/token KV over 12 full-attention layers and constant-size recurrent state for the 36 GDN layers. I should present the 149.6 MiB as the 27B figure and note Flash-Next's GDN state is comparable order but I don't have a measured Flash-Next number. Let me be careful and label it.

Actually the Myric card says Flash-Next: 48 layers, 12 full attention, 36 gated-delta-net. The 27B numbers: 48 GDN layers → 149.6 MiB. Flash-Next has 36 GDN layers with 48 V heads × 128 × 128. Hmm, Flash-Next config: Gated DeltaNet: 48 value heads for V, 16 for QK, head dim 128. Same per-layer state as the 27B? The 27B computation used 48 value heads × 128 × 128 × 4B = 3 MiB/layer. For Flash-Next: 36 layers × 3.1 MiB ≈ 112 MiB. So roughly 110 MiB per sequence in f32. I can say "~110 MiB by the same arithmetic (36 layers × 3.1 MiB), vs 24 KiB/token for the attention KV — so the GDN state crosses over at roughly 4,700 tokens." Let me compute: 112 MiB / 24 KiB = 112*1024/24 = 4778 tokens. So beyond ~4.8k context, the GDN state is a bigger single fixed chunk than... hmm, no: KV grows per token, GDN is fixed. At 262k context, KV = 24 KiB × 262144 = 6.1 GiB, which dwarfs 112 MiB. So GDN state matters at short context but not long. Let me just note it's a separate, unfixed precision decision (~110 MiB/sequence at f32, fp16-able via NInfer's --gdn-state-fp16) and that at long context KV dominates.

Let me double check: is --gdn-state-fp16 in the quickstart for a Qwen3.8-27B/Ternary Bonsai launch? Yes: `--kv-dtype rk8v4 --gdn-state-fp16`. So it's a real flag for GDN-state-holding models.

I should be honest about what I verified vs inferred. I did NOT find Basalt's own repo documenting FP16 KV — I should say that. And I should flag that in jesdga95's own published benchmark Basalt ran int8 KV, which conflicts with "Basalt runs FP16" — worth telling the user as it affects how they interpret the published numbers.

Let me write the answer. Keep it tight but substantive. Use tables for the actual numbers.

Let me structure:

## Where it actually lives (3 places)
1. Infernix docs/quality.md — the only BF16-KV vs other-KV row on Flash-Next
2. jesdga95's Reddit 7-engine run — KV pinned as a control
3. NInfer docs/cli.md + What's New — kv-dtype documented, no quality numbers; bf16p framing

## The one number that answers your question
Table of FP4-Local BF16 KV vs INT8 KV rows. Delta 0.00003 vs honest rounding 0.01475.

## But the test is biased toward BF16 — and BF16 still only ties
The reference is BF16 KV. So this can't rank f16 vs bf16.

## Why neither engine publishes it
Both pinned KV; the published differentiator is activations. Table of IQ3_S KLD: Basalt 1.20×/+0.47% (only CI-excluding-zero), Strata 1.45×, Infernix 0.90-0.95×.

## What this means for your f16-vs-bf16 choice
- both 2 bytes, no memory difference
- bf16 = checkpoint's dtype (config.json dtype bfloat16), so "lossless" framing; f16 = 3 more mantissa bits for in-range values
- NInfer's bf16p marketing reveals: bf16 treated as a format to compress
- the model's own rounding noise floor swamps it → consistent with your Q8-PLE+IQ3_S observation
- the real risk isn't precision, it's the decode kernel path (from earlier turn)

## Watch out
- Basalt ran int8 KV in the published cross-engine runs (both jesdga95's Reddit and Infernix's quality doc). So "Basalt = FP16" isn't what those published numbers reflect. If your build runs f16, those published KLD/tok-s numbers aren't your config.
- Flash-Next's GDN state is a separate knob (--gdn-state-fp16 in NInfer), ~110 MiB/seq at f32 by the 27B arithmetic.
- What's genuinely flagged as risky for this arch: q8_0 KV garbage/crash per Myric card.

## If you want the number
Concrete A/B.

I'll note explicitly the gap: no published FP16-vs-BF16 KV comparison exists for Flash-Next in either engine; the closest is Infernix's BF16-vs-INT8 row, and it's within noise but structurally biased toward BF16.

Length: medium-long, tables help. Let me write.


</details>

## Short answer

**No published FP16-vs-BF16 KV comparison exists for Flash-Next in either engine.** But I found the closest thing, and it's more useful than a head-to-head would be: [Infernix `docs/quality.md`](https://github.com/Wallawalla47/Infernix/blob/main/docs/quality.md) contains the **only BF16-KV row measured on Flash-Next against a precision-controlled reference**, and it lands *inside the noise*.

Infernix (Wallawalla47) is the third Strata/NInfer-lineage engine, and it's the one that built the methodology — so it's the repository where your question has an answer, even though it answers it sideways.

---

## 1. The one number that exists

On NVIDIA's FP4-Local Flash-Next, same engine, same route, paired on identical positions ([quality.md](https://github.com/Wallawalla47/Infernix/blob/main/docs/quality.md)):

| KV | Mean KLD | KLD 99.9% | Top-1 agreement | PPL vs ref |
|---|---|---|---|---|
| **BF16 KV** (`--reproducible`) | 0.01310 [0.01235, 0.01387] | 0.401 [0.375, 0.481] | 96.00% | −0.00% |
| **INT8 KV** (`--reproducible`) | 0.01313 [0.01238, 0.01392] | 0.454 [0.381, 0.519] | 95.98% | −0.02% |
| *Honest rounding (noise floor)* | *0.01475* | *0.526* | *95.60%* | — |

Δ mean KLD = **0.00003**, roughly 0.2% of the model's own rounding sensitivity. Moving KV between BF16 and 8-bit — a far larger change than f16↔bf16 — is below the floor at which this model can distinguish anything.

**But read the footnote before you bank on it:** the reference is *"Infernix's lossless route… **BF16 KV**"* — the test is structurally biased toward BF16, and BF16 *still* only ties INT8. Also only 200 chunks / 51,000 positions, with the BF16 row on the prompt path only. So: suggestive, decisive for your purposes, not a clean f16-vs-bf16 ranking.

## 2. Why neither engine publishes it — they pinned KV and varied arithmetic instead

Both your engines derive from Strata, and every published cross-engine study on Flash-Next **holds KV constant and treats activation precision as the variable**:

- **jesdga95's own 7-engine run** ([Reddit, 23 Oct 2026](https://www.reddit.com/r/LocalLLaMA/comments/1xdlunp/)): *"int8 KV cache for every engine (llama ran f16 kv)."* KV was a control, not an axis.
- **Infernix's IQ3_S quality table** — the run that includes Basalt: *"KV is 8-bit for every engine: INT8 for Infernix, Strata and Basalt, Q8_0 for llama.cpp."*
- **Infernix README, "What each engine computes"** — the differences listed are routed-expert activations, dense-layer bits, hyper-connection matrices, output-head screening. KV never appears.

And the IQ3_S KL numbers show where the real divergence is:

| Engine | Mean KLD | × honest rounding | PPL vs ref |
|---|---|---|---|
| Infernix (default) | 0.01465 | 0.91 | +0.08% |
| llama.cpp b12128 | 0.01505 | 0.94 | −0.03% |
| **Basalt v0.2.1** | 0.01922 | **1.20** | **+0.47%** ← only row whose CI excludes zero |
| Strata v0.2.11 (tail skip) | 0.02314 | 1.45 | −0.00% |

Basalt's measurable cost is attributed to **8-bit activations, an 8-bit copy of the BF16 hyper-connection matrices, and logits outside the top-64 from a 2-bit head copy** (+1.1% KL by its own measure) — not KV. Strata's is route tail skip (3.9M skipped expert computations). So if you're trying to explain a Basalt-vs-NInfer behavioural difference, KV dtype is the wrong variable; these are the published ones.

⚠️ **This directly affects you:** in both published Basalt KV settings above, **Basalt ran 8-bit KV, not FP16.** If your Basalt build is on FP16 KV, none of those published KLD or tok/s figures describe your configuration.

## 3. What NInfer's docs say about BF16

NInfer documents `--kv-dtype` ([docs/cli.md](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#context-and-memory)) with `int8` as the canonical worked example and `rk8v4` in the quick start. The telling line is in What's New, 2026-11-10:

> `--kv-dtype bf16p` — **BF16's KV bits in 23% fewer bytes**

NInfer's own framing treats BF16 as *a format to be compressed*, not a precision target — consistent with BF16 being the checkpoint's native dtype (`config.json → "dtype": "bfloat16"`) rather than a quality choice. No quality numbers accompany any `--kv-dtype` value.

## 4. The physics, for the tie-break

Since both are 2 bytes/element, **neither engine's FP16-vs-BF16 choice changes memory at all** — and on Flash-Next the cache is small anyway (only 12 of 48 layers are full attention; 2 KV heads × 256 → ~24 KiB/token, ~6 GiB at the full 262K per [Myric's APEX card](https://huggingface.co/Myric/Qwen3.8-Flash-Next-APEX-GGUF)). So the only remaining axes:

- **Precision:** f16 has 11 effective significand bits vs bf16's 8. GGML/CUDA FA accumulates in f32, so bf16 is *not* buying you range you need — it's costing 3 bits on values that fit in f16.
- **Kernel path (the one that can actually bite):** from the previous turn — on llama.cpp, bf16 keeps the fast prefill kernel but has no compiled FA *decode* kernel by default, so it's upcast to f16 per step and decodes ~2.4× slower at 32K. Custom engines with hand-written FA kernels may not inherit that, but it's the one asymmetry with published teeth. Verify on your build, don't assume.

## 5. Two things that matter more than f16-vs-bf16 here

1. **The Gated DeltaNet state is a separate, unfixed precision decision.** NInfer exposes `--gdn-state-fp16` as its own flag (it's in the quick start alongside `--kv-dtype`) — implying f32 by default. KV dtype does not touch it. By the arithmetic worked out for the sibling `qwen35` hybrid in [llama.cpp #29324](https://github.com/ggml-org/llama.cpp/issues/29324) (48 GDN layers → 149.6 MiB/sequence at f32), Flash-Next's 36 GDN layers are ~110 MiB/sequence — fixed, and 1.4× that is free with fp16. *(That figure is for the 27B; I don't have a measured Flash-Next number, so treat as order-of-magnitude.)*
2. **The one KV setting actually flagged as dangerous on this architecture is quantized KV, not bf16.** Myric: *"**f16 KV only.** `q8_0` KV crashes or emits garbage on this architecture"* — while carteakey and several HF users run `-ctk q8_0 -ctv q8_0` on CUDA without incident. Unresolved, and a better use of your benchmark time.

## 6. To close the gap yourself

You're holding the only configuration that can answer it, since it's a build-specific question with no published data:

```bash
# same build, same seed, same prompts, one flag at a time
--kv-dtype bf16 ...   # NInfer
<basalt fp16 path>    # Basalt
```

Then judge it Infernix's way, not by perplexity — their key observation is that **perplexity hides this entirely**: Strata sits 1.45× further from the exact model than honest rounding yet matches reference PPL to two decimals. Use `llama-perplexity --kl-divergence` against a fixed reference, and compare the delta against the ~0.016 honest-rounding floor on IQ3_S. If the f16↔bf16 gap is under ~0.001 mean KLD — which the BF16-vs-INT8 row predicts — it's noise, and you should pick on kernel speed instead.
## User · #56

Yeah well I meant, even though int8/fp8 always seems to be the canon ... basalt-config.json can have applied "fp16" as the kv type. And again, meanwhile, ninfer only has the option for bf16, or even bf16p (which you included as data). So again, these are the only options on each specific architecture solely if you're trying to maximize perplexity while deeply in a cache. Anecdotes likewise from users of either on (beefier) workstations **always** opt for the 16-type cache, since it's a mixture of experts model. It provides a control group, where the otherwise 8-bit caching still effects the model at contexts of 160k or greater. I mean, for a session of >=200k ctx, this is a question where a deeply diverged path is already as far "in-the-weeds" per-se, as it can get. Thus my served type under fp16, you're saying—with my current basalt, is not measurably going to have a difference (truthfully) when I go ahead and try to serve the identical type under ninfer/infernix?
## Assistant · #57

<details><summary>Reasoning · 8,026 characters</summary>

The user is asking a direct question: "So my served type under fp16 (Basalt), you're saying — with my current basalt — is not measurably going to have a difference (truthfully) when I go ahead and try to serve the identical type under ninfer/infernix?"

Wait, careful parsing. They're asking: if they serve the "identical type" (i.e., the 16-bit KV cache — fp16 on Basalt, bf16 on NInfer since that's the only 16-bit option NInfer offers) under NInfer/Infernix, will there be a measurable difference?

Two sub-questions actually:
1. Is f16 (Basalt) vs bf16 (NInfer/Infernix) measurably different when both are "the 16-bit option"? — i.e., cross-engine, the dtype label differs but both are 16-bit; will switching engines change quality?
2. Their claim: int8 KV still affects the model at 160k+ context; they're using 16-bit as a control group because MoE.

I need to be honest and precise. Key points:

- My claim was NOT "no difference between 16-bit and 8-bit KV." My claim was that the published BF16-vs-INT8 comparison at ~51k positions showed no measurable difference. And that comparison was on the *prompt* path at modest context, NOT at 200k+ depth. So the user's point about deep context is a genuine gap in the evidence — I should concede this clearly and not overclaim.

- Crucially: the KLD measurements were done on WikiText-2 with chunked evaluation (147,900 positions, chunks), NOT at 200k context depth. The KV cache in that harness never reaches 160k-250k tokens in a single sequence (prompt path measured with chunked perplexity; llama-perplexity uses ctx-size 2048 typically, or the Infernix harness — I should be careful: I don't know their ctx size for the quality run. Actually the quality doc says "Measured 2026-11-05/06... 147,900 scored positions... 148 of 147,900" and FP4-Local "first 200 chunks only (51,000 scored positions)". Chunks imply a limited context window. I should flag this as an inference: chunked perplexity ⇒ short context ⇒ the deep-context regime they care about is untested.

Let me verify: does quality.md section 2 ("How it was measured") give ctx size? I should read section 2 of resource 95197fc0 to check the chunk/context size and whether KV dtype was varied. That's the crux — whether the BF16 vs INT8 comparison was at short context. Let me read it.

Also section 3 Limitations — 1,248 chars, worth reading.

Let me read those two sections.

Then answer honestly:
- No, I'm not saying that. Two distinct claims:
  (a) f16 vs bf16 (both 16-bit): expected difference is ~zero, and it's below any measurement floor. This holds regardless of depth, because the error is per-element relative rounding error ~2^-9 vs 2^-11 — it doesn't compound with context length the way quantization drift does... actually, hmm. Let me think carefully.

Does the f16/bf16 difference grow with context depth? Two mechanisms:
  - Per-element rounding error in K/V storage: bf16 has 8-bit mantissa, f16 has 10. Error is relative, per-element, independent of position. Attention output is a weighted average of V; errors average out partly. So the *magnitude* of added noise doesn't grow with N. But the *number* of noisy terms grows — with softmax over N keys, the logit noise sums in quadrature-ish; sqrt(N) growth in the worst case for correlated errors, or averaging. Also, bf16's larger relative error on logits (QK products stored... no, K is stored, QK dot computed in f32) — the logit error scales with sqrt(d)·|k|·rel_err. Per-position, doesn't grow with N. But the softmax over N keys means a small per-logit noise perturbs the distribution; as N grows, the entropy of attention increases and small logit noise... actually with more keys, the max-logit typically grows (attention concentrates), so relative perturbation shrinks. Mixed. Honest answer: no published data; the first-order expectation is that f16 vs bf16 is a ~4× difference in per-element rounding error, which is small relative to the model's own rounding sensitivity but not zero, and whether it compounds at depth is unmeasured.
  - The MoE router amplification: this IS the key mechanism the user intuited, and it's published! Infernix's quality doc says: "**IQ3_S floor.** Honest rounding is 10× higher here than on the 27B: **a small rounding difference can change which experts the router picks, and the change then spreads.**" That's the mechanism — on a MoE, tiny numeric differences get amplified by router flips. That's why the honest-rounding noise floor is 0.016 on Flash-Next vs 0.0016 on the 27B — 10× higher. So on Flash-Next, ANY tiny numeric perturbation (including f16→bf16) has a 10× higher chance of producing a diverged trajectory. But note: that same amplification means divergence ≠ degradation. The 27B decode rows at 2.7× rounding had PPL change of −0.10% / −0.02% (i.e., no degradation), while Strata at 1.45× had PPL −0.00%. So divergence in trajectory but not in quality.

So the honest answer:
- **Divergence**: yes, guaranteed. Different KV storage dtype → different logits → different greedy tokens at ≥200k, and the MoE router amplifies it. Your outputs will not be bit-identical across Basalt-f16 and NInfer-bf16. Nobody should expect that.
- **Degradation (perplexity/quality)**: no measurable difference expected from f16 vs bf16 per se. Both are 16-bit; the difference is 2 mantissa bits, which sits well below the model's own honest-rounding sensitivity — and the published proxy (BF16 vs INT8 = a 8-bit→16-bit jump) already failed to separate.
- **BUT**: their intuition that 8-bit KV matters at 160k+ is probably right and is NOT contradicted by my evidence — because the published KLD runs are chunked/short-context. I should concede this explicitly. Their anecdote (users on beefier workstations opting 16-bit) is consistent with unmeasured deep-context behavior.
- Also: cross-engine comparison confound. If they switch Basalt→NInfer, the KV dtype is the smallest of the differences. Basalt's own measured fingerprint is +0.47% PPL / 1.20× rounding from 8-bit activations + 2-bit head screen; NInfer/Infernix default is 16-bit activations. So switching engines will move quality MORE than switching KV dtype — and in the direction of *better* on NInfer/Infernix (Infernix at 0.91× vs Basalt 1.20×). That's the real answer to "will serving the identical type under ninfer/infernix differ?" — Yes, but the difference comes from arithmetic, not KV.

Also important correction: NInfer/Infernix are different engines. Infernix has int8, bf16, fp8, nvfp4, k8v4, vq2, k4v2 — so Infernix is NOT bf16-only. The user said "ninfer only has the option for bf16, or even bf16p". That's true for ninfer-all's 16-bit slot (bf16/bf16p), but Infernix (the NInfer fork) explicitly lists `int8`, `bf16`, `fp8`, `nvfp4`, `k8v4`, `vq2`, `k4v2` — no fp16 either, but plenty of non-bf16 options. And NInfer has `--gdn-state-fp16` so fp16 exists for GDN state at least. I should gently correct: "ninfer-all's 16-bit KV slot is bf16-only, true; but Infernix, which forked NInfer, has a wider KV menu including its lossless route — and its reference is BF16 KV."

Key insight to give them: **Infernix's reference ("the model as specified, computed without error") uses BF16 KV.** That's a strong signal: the one team that built a bit-exact lossless route chose BF16 as the *ground truth* KV format for Flash-Next. So if you're chasing max perplexity fidelity in a deep cache, bf16 in Infernix is not a downgrade from fp16 — it's the definition of the ceiling in that harness. That's a genuinely useful, specific finding.

Also the "control group" framing: they're using 16-bit KV as a control to measure 8-bit KV's effect at 160k+. That's methodologically sound and I should endorse it, and point out that the published BF16-vs-INT8 delta at short context is ~0.00003 KLD, so if they measure a real effect at 200k, they'd be the first to publish it — that's the actual contribution available to them.

Let me verify the measurement context size by reading quality.md section 2 and 3.

Let me read those.


</details>

<details><summary>Tool request · context_read · call_12d7564ee7f4436881ae2683</summary>

```json
{
  "kind": "resource",
  "id": "95197fc0-a568-4d5d-87b6-ee8d0fd1aa14",
  "section": 2
}
```

</details>

<details><summary>Tool request · context_read · call_dc73ec5b61c64f46bcce2f33</summary>

```json
{
  "kind": "resource",
  "id": "95197fc0-a568-4d5d-87b6-ee8d0fd1aa14",
  "section": 3
}
```

</details>

Let me check the measurement setup before I answer that — whether those KLD runs were ever at your depth.
<details><summary>Tool result · context_read · call_12d7564ee7f4436881ae2683</summary>

# Scrape: https://raw.githubusercontent.com/Wallawalla47/Infernix/main/docs/quality.md · section 2/3
Subsection: How it was measured
Tags: code, table

Perplexity measures how well a model predicts the text; here every engine runs the same weights, so
an engine's absolute perplexity is the reference's times the ratio above. The absolute values differ
in the third decimal, and their own intervals (±0.22 on the 27B) measure which text was sampled
rather than the engine, so this page quotes only the paired change. That change shows a systematic
shift: the 27B's quantized prompt path makes the text 0.7 % less likely on average. It cannot show
noise. Rounding errors raise some tokens' probabilities and lower others about equally, so they
cancel in the mean log-likelihood: Strata's IQ3_S row is 1.45× honest rounding by KLD and 0.00 % by
perplexity. KLD, its tail and top-1 agreement measure the distance from the intended distributions,
not whether the noise happened to favour this text, which is why llama.cpp's own quality comparisons
lead with them.

## How it was measured

### Text, chunks and positions

The WikiText-2 raw test set (`wiki.test.raw`), tokenised by each model's tokenizer and cut into 580
chunks of 512 tokens (FP4-Local: the first 200). As in `llama-perplexity --kl-divergence`, each chunk is scored on its second
half: the predictions of tokens 257-511 from positions 256-510, 255 per chunk, 147,900 in all. The
reference is written as llama.cpp's `_logits_` base file (`infernix-certify reference --format
llama-kld`), which holds the tokens and the reference's log-probabilities, so every engine reads the
same tokens and is scored against the same distributions.

### Logits

Every row is scored at BF16 precision: the reference writes BF16 logits; NInfer and vLLM produce BF16
logits; Infernix's, TensorSharp's, Strata's and Basalt's rows are rounded to BF16 by the scorer
(`infernix-certify llama-rows --round-logits bf16`), and llama.cpp's by its patch
(`LLAMA_KLD_ROUND_BF16`). Rounding logits to BF16 is itself a small KLD; applying it to every row keeps
the comparison fair.

### Prompt path

Each chunk is one prompt forward, and the scored rows are that forward's logits: what an engine
computes when it reads a prompt. Strata and Basalt compute no logits on their prompt paths, so they
have decode rows only.

### Decode path

Each chunk's first 257 tokens are one prompt, whose last row is the first scored row. The remaining
255 positions are generated in one request with the engine's own speculative decoding, the text's
tokens forced: a draft is accepted only when it equals the text's next token, every committed
position's row is the one the engine computed for the text's actual history, and rows computed
after a rejected draft are discarded and recomputed by the next window. This scores the kernels an
engine decodes with (decode steps and verify windows at its own window sizes) rather than its
prompt kernels. How each engine is forced:

| Engine | Drafting | Forcing |
|---|---|---|
| Infernix | its default drafter (27B: the artifact's DFlash2 plus n-gram copy drafts; IQ3_S and FP4-Local: the DFlash2 companion), automatic draft length | `infernix-certify decode`: each step's row is recorded, then the text token's logit is raised so the engine's own acceptance takes it |
| NInfer | MTP, 3 drafts | the same in its decision step (patch) |
| vLLM | MTP, 3 drafts | a `compute_logits` hook records each row and raises the text token's logit ([`vllm_rows.py`](../tools/quality/engines/vllm_rows.py)) |
| TensorSharp | the artifact's DFlash2, 7 drafts | a tool (patch) makes its speculative loop's own calls (draft, verify the window, commit) and accepts drafts that equal the text |
| llama.cpp | none in `llama-perplexity` | the patch feeds windows of 4 text tokens (a verify of 3 drafts that are all correct) |
| Basalt | verify windows of 4 | its own `ppl_gate` protocol, with the patch dumping each row |
| Strata | — | it computes logits only in its verify windows and sends any prompt longer than `--short-read` wholly through its batched path, so every token of the chunk is read through its verify windows (as its own quality tool reads them); the first half is not one batch and its MTP drafter is idle |

Infernix's 27B decode rows are recorded on eager rounds (`--no-cuda-graph`); its first 40 chunks with
CUDA graphs gave bit-identical rows.

### Scoring and intervals

Rows go to `infernix-certify llama-rows`, which computes llama-perplexity's per-position statistics
against the base file (`apps/certify/llama_kld.h`); llama.cpp's rows come from llama-perplexity
itself. [`tools/quality/llama_kld.py`](../tools/quality/llama_kld.py) turns the per-position values
into the published statistics, with 95 % intervals from 10,000 bootstrap resamples of whole chunks
(seed 20261025). [`tools/quality/engine_compare.py`](../tools/quality/engine_compare.py) runs the
steps in order, resumes after a failure, and writes `report.md` and `report.json`.

## Engines

Each engine ran its latest version on 2026-11-05 with its own default or recommended configuration;
the patches only take logits out (and, for TensorSharp, compile on Windows).

| Engine | Version | Platform | Settings |
|---|---|---|---|
| Infernix | `main` `68cb6992` with this comparison's tooling (FP4-Local: `main` `3279ceb4`) | Windows, CUDA 13.4 | default route; 27B BF16 KV; IQ3_S and FP4-Local INT8 KV and the n-gram volume; decode `--spec dflash2 --draft-tokens auto --lm-head-draft` (27B also `--ngram-draft-tokens auto`), one request |
| NInfer | `master` `a754fcf3b` + [patch](../bench/engine_quality/patches/ninfer-a754fcf3b.patch) | WSL2, CUDA 13.4 | prompt: its CausalScoring route; decode: its Generation route, `--spec mtp --draft-tokens 3`, one request, no CUDA graphs; BF16 KV, BF16 logits |
| vLLM | 0.33.0 (pip, torch 2.14, cu130) | WSL2 | its defaults (KV auto = BF16), `enforce_eager`, prefix caching off; decode `speculative_config={"method": "mtp", "num_speculative_tokens": 3}`, one request |
| TensorSharp | `main` `0c45b34c` (its NInfer route is not in release v2026.10.23) + [patch](../bench/engine_quality/patches/tensorsharp-0c45b34c.patch) | Windows, .NET 10.0.403, CUDA 13.4 | its shipped `config/qwen3.8-27b-ninfer.json`: direct-CUDA backend, n_ctx 40,960, ubatch 2,048, the artifact's DFlash2 (7 drafts, pMin 0, `TS_SPEC_ADAPTIVE=0`), BF16 KV |
| llama.cpp | b12128 + [patch](../bench/engine_quality/patches/llama.cpp-b12128.patch) | Windows, CUDA 13.4 | `llama-perplexity -c 512 -b 512 -ctk q8_0 -ctv q8_0`, its default placement (`--fit`: experts that do not fit run on the CPU) |
| Strata | v0.2.11 (`c3b3f503`) + [patch](../bench/engine_quality/patches/strata-v0.2.11.patch) | Windows, CUDA 13.0 | its setup's IQ3_S configuration for this PC ([config](../bench/engine_quality/configs/strata-qwen3.8-flash-next-iq3_s.json)): INT8 KV, `--expert-cache auto`, `--prefill auto`, `--spec 4 --spec-min-p 0.5` with its MTP head, route tail skip at its default (on) |
| Basalt | v0.2.1 (`1b3f6964`) + [patch](../bench/engine_quality/patches/basalt-v0.2.1.patch) | Windows, CUDA 13.4 | its GSQ-RCO IQ3_S pack (format 2), `--kv int8`, `ppl_gate` with verify windows of 4 |

What each patch does:

- **NInfer**: `ninfer-kld-rows` reads the base file's chunks and writes each row: on the prompt path
  through its scoring route (`NINFER_SCORE_LOGITS_DUMP`), on the decode path (`--decode`) through a hook
  in the decision step that records the row and raises the text token's logit
  (`NINFER_DECODE_ROWS_DUMP`).
- **llama.cpp**: `LLAMA_KLD_ROUND_BF16` rounds the logits to BF16 before scoring;
  `LLAMA_KLD_DECODE_T=N` scores the second half through forced windows of N tokens instead of the
  prompt batch.
- **Strata**: `STRATA_LOGPOS_ROWS=FILE` dumps every verify-window row (position, vocabulary, logits).
- **Basalt**: `BASALT_PPL_ROWS=FILE` dumps every row its `ppl_gate` scores.
- **TensorSharp**: `eng/KldRows` (prompt: one forward per chunk, then the engine's own final norm and
  head over the scored rows, 64 at a time, instead of the last row only; decode: the speculative calls
  above); and `__restrict__` written out in three explicit kernel instantiations, which the MSVC host
  compiler's front end otherwise fails to match (the compiled kernels are unchanged).

### vLLM's checkpoint

NInfer's artifact keeps Unsloth's NVFP4 and FP8 words unchanged and stores the embedding as FP8 rows
with one BF16 scale per row; Unsloth's checkpoint stores it in BF16.
[`make_vllm_27b_copy.py`](../bench/engine_quality/make_vllm_27b_copy.py) copies Unsloth's checkpoint and
overwrites only its embedding with BF16(code × scale) of the artifact's rows, the exact product rounded
once. An embedding row's output is BF16 in the model, so this is the same model the artifact holds.

## Repeating the measurement

1. **Weights.** Download the artifacts and checkpoints named above (the 27B `.ninfer`, Unsloth's
   27B checkpoint for vLLM, the IQ3_S GGUF, Infernix's IQ3_S and FP4-Local artifacts with their
   `.ngram` volumes, and the DFlash2 companion) and
   build Strata's and Basalt's packs of the GGUF with their own tools. Make vLLM's checkpoint:

   ```bash
   python bench/engine_quality/make_vllm_27b_copy.py UNSLOTH_DIR qwen3_8_27b_nvfp4.ninfer vllm-27b
   ```

2. **Engines.** Build `infernix-certify` from this repository. Check out each other engine at its
   version, apply its patch with `git apply` (which also works in llama.cpp's unpacked release tarball),
   and build:

   ```bash
   # llama.cpp b12128 (Windows; vcvars64 and CUDA 13.4 on PATH)
   cmake -S . -B build -G Ninja -DCMAKE_BUILD_TYPE=Release -DGGML_CUDA=ON -DCMAKE_CUDA_ARCHITECTURES=120 -DLLAMA_CURL=OFF
   cmake --build build --target llama-perplexity
   ```

   ```bash
   # NInfer a754fcf3b (Linux or WSL2)
   cmake -S . -B build -G Ninja -DCMAKE_BUILD_TYPE=Release -DNINFER_TARGET=rtx5090 -DNINFER_BUILD_ENGINE=ON -DNINFER_BUILD_APPS=ON -DBUILD_TESTING=OFF
   cmake --build build --target ninfer-kld-rows
   ```

   ```bash
   # Strata v0.2.11 (Windows; CUDA 13.0 with MSVC 14.44, whose headers CUDA 13.0's front end accepts)
   cmake -S . -B build -G Ninja -DCMAKE_BUILD_TYPE=Release -DSTRATA_ENABLE_CUDA=ON -DCMAKE_CUDA_ARCHITECTURES=120 -DSTRATA_PORTABLE=ON -DSTRATA_BUILD_TESTS=OFF
   cmake --build build --target strata
   ```

   ```bash
   # Basalt v0.2.1 (Windows)
   cmake -S . -B build -G Ninja -DCMAKE_BUILD_TYPE=Release -DCMAKE_CUDA_ARCHITECTURES=120 -DBUILD_TESTING=OFF
   cmake --build build --target basalt
   ```

   ```bat
   REM TensorSharp 0c45b34c (Windows cmd; .NET 10 SDK, CUDA 13.4, vcvars64). The direct-CUDA route needs
   REM no GGML library; building it would also download cuDNN.
   set TENSORSHARP_GGML_NATIVE_SKIP=true
   set TENSORSHARP_MLX_NATIVE_SKIP=true
   dotnet build eng\KldRows\KldRows.csproj -c Release -p:CudaArch=compute_120 -o tensorsharp-build
   ```

   ```bash
   # vLLM 0.33.0 (Linux or WSL2)
   uv venv --python 3.12 vllm-venv
   uv pip install --python vllm-venv/bin/python --torch-backend=cu130 "vllm==0.33.0" numpy
   ```

3. **Configurations.** [`bench/engine_quality/configs/`](../bench/engine_quality/configs/) holds the
   exact configurations of these runs. Their paths are this machine's: edit the artifact, text,
   binary and work paths (and the WSL paths in the NInfer and vLLM command lines).

4. **Run.** From the repository root, with Python 3.11 and numpy:

   ```bash
   python -m tools.quality.engine_compare plan bench/engine_quality/configs/qwen3.8-27b-nvfp4.json
   python -m tools.quality.engine_compare run bench/engine_quality/configs/qwen3.8-27b-nvfp4.json
   python -m tools.quality.engine_compare report bench/engine_quality/configs/qwen3.8-27b-nvfp4.json
   ```



</details>

<details><summary>Tool result · context_read · call_dc73ec5b61c64f46bcce2f33</summary>

# Scrape: https://raw.githubusercontent.com/Wallawalla47/Infernix/main/docs/quality.md · section 3/3
Subsection: Limitations

   `plan` lists the steps; `run` executes the ones not yet done (`--only ID,...` selects some) and
   logs each to `WORK/logs`; `report` writes `WORK/report.md` and `report.json`. A test run on a
   few chunks: set `"chunks"` (and a separate `"work"`) in a copy of the configuration.
   On this machine the 27B took 5.0 GPU hours (vLLM's eager decode 2.1 of them), IQ3_S 2.7 and
   FP4-Local's 200 chunks about 1.8 (`qwen3.8-flash-next-fp4-local.json`: its `"arms": "split"` runs
   the reproducible and default routes and each fast path alone).

## Limitations

- **One text, one context.** WikiText-2 in 512-token chunks: short contexts in English prose.
  Long contexts, code, chat and thinking were not measured.
- **One honest-rounding seed per model.** The spread between seeds was not measured.
- **Strata's and Basalt's decode rows only**, and Strata's protocol differs as described above.
- **Speculative drafting differs by engine.** It changes which window sizes compute each row, not
  which tokens are scored; acceptance under forced text is low for some drafters (TensorSharp's
  DFlash2 accepted 9.4 % of drafts), which only means more windows.
- **These builds.** Later versions of any engine, Infernix included, were not measured.


</details>

## Assistant · #60

<details><summary>Reasoning · 5,850 characters</summary>

Now I have the decisive methodological fact: **"One text, one context. WikiText-2 in 512-token chunks: short contexts in English prose. Long contexts, code, chat and thinking were not measured."**

So my earlier claim was over-extended. The BF16 vs INT8 comparison at 512-token chunks says nothing about 200k context. I must concede this clearly and honestly.

Also: Basalt v0.2.1 ran `--kv int8` in the quality run — confirming my point that the published Basalt numbers are int8 KV, not fp16.

Also important: NInfer ran **BF16 KV** in the quality run (its default), and vLLM's default KV auto = BF16, TensorSharp BF16 KV, and the *reference* is BF16 KV. So on the 27B, the comparison was BF16 KV for every engine. And NInfer's row at 10.4× rounding vs Infernix 10.5× — statistically identical. So NInfer-with-BF16-KV ≈ Infernix-with-BF16-KV on the prompt path. That's a direct answer to "will serving the identical type under ninfer/infernix differ?" — for the 27B, no: 10.4 vs 10.5× rounding, overlapping intervals.

And for decode: Infernix 2.76× vs NInfer 2.74× — again identical. Both BF16 KV. So NInfer and Infernix, both at BF16 KV, are within noise of each other. That's a real, published answer.

Now the key answer to their actual question: "my served type under fp16 (basalt) — is it not measurably different when I serve the identical type under ninfer/infernix?"

Answer structure:
1. Concede: I over-extended. The BF16-vs-INT8 delta I cited is at 512-token chunks, explicitly "long contexts... not measured." Your 160k-200k regime is precisely the unmeasured region. Your anecdote is not contradicted by the data — it's unaddressed by it.

2. Direct answer, split into two claims:
   (a) f16 vs bf16 per se: still expect ~zero. Reason: 2 mantissa bits, both 16-bit, and the published cross-engine rows show NInfer(BF16 KV) and Infernix(BF16 KV) at 10.4 vs 10.5× rounding on prompt, 2.74 vs 2.76× on decode — indistinguishable. But note this doesn't test f16 vs bf16; it tests two engines at the same bf16.
   (b) Engine swap: yes, measurable difference — but from arithmetic, not KV. Basalt v0.2.1 at 1.20× with +0.47% PPL (only CI-excluding-zero row) vs NInfer/Infernix. So moving from Basalt to NInfer/Infernix will change output more than f16→bf16 did.

3. The important correction: their premise "ninfer only has bf16/bf16p" — true for ninfer-all's 16-bit slot. But note the whole published comparison ecosystem uses BF16 as the *ceiling*: Infernix's lossless reference = BF16 KV; vLLM default = BF16; TensorSharp = BF16. So bf16 in NInfer/Infernix is not a downgrade relative to Basalt's fp16 — in the one harness that defines "the model as specified," bf16 IS the definition. That's the single most useful fact for their decision.

4. Their control-group methodology: endorse, and point out the measurement gotcha — perplexity will NOT show it. "Rounding errors raise some tokens' probabilities and lower others about equally, so they cancel in the mean log-likelihood: Strata's IQ3_S row is 1.45× honest rounding by KLD and 0.00% by perplexity." They said they're maximizing perplexity. That's the wrong instrument! This is a genuinely important, actionable correction: if they're using perplexity as the metric to detect 8-bit KV's effect at 200k, they may measure nothing even where there IS an effect. Use KL divergence / top-1 agreement against a 16-bit reference.

5. MoE amplification: their intuition that MoE makes this matter is supported by a published mechanism: "Honest rounding is 10× higher here than on the 27B: a small rounding difference can change which experts the router picks, and the change then spreads." So on Flash-Next the noise floor is 0.016 vs 0.0016 on 27B — 10× more sensitive to any numeric perturbation. That supports "expect divergence" but divergence ≠ degradation.

6. What to actually run — concrete protocol at 200k, with the right metric.

Let me be careful about one thing: is it true that at 200k+ context the 8-bit KV effect grows? Mechanism: K/V quantization error per element is fixed; but as N grows, (a) more keys compete in softmax so max-logit margin typically grows which can make the argmax more robust; (b) but retrieval-style tasks (needle in haystack) rely on small attention differences among many candidates, so relative error matters more; (c) error accumulation across layers. Also for hybrid models, only 12 of 48 layers have KV, so per-token KV error affects 12 layers. Honest: unmeasured, plausible, mechanism-based. I should say "plausible and mechanism-consistent, but nobody has measured it — that's the gap."

Also worth noting: the user says "int8/fp8 always seems to be the canon" — right, because the *published* harnesses all pinned 8-bit KV to make engines comparable, which systematically deleted the 16-bit question from the literature. That's a nice observation to make: the canon is an artifact of benchmark design, not of measured indifference. Actually — Infernix pinned INT8 KV for IQ3_S because Basalt/Strata only had int8; NInfer and vLLM and TensorSharp ran BF16. So the 27B table is "BF16 KV for every engine" and the IQ3_S table is "8-bit for every engine." Interesting: the MoE (IQ3_S) table deliberately used 8-bit, the dense 27B used BF16. So on the MoE specifically, no 16-bit row exists at all. That's exactly their complaint, and it's verifiable.

Let me write this up. Keep it tight but substantive. Use a table for the cross-engine BF16-KV rows.

I should be direct and lead with the concession + the answer.

One more check on accuracy: "Basalt v0.2.1 ... `--kv int8`" — yes from the engines table. Good, confirms my earlier claim.

Also NInfer settings: "BF16 KV, BF16 logits" — yes.

Let me write.

Format: a short direct answer, then sections. Moderate length — they're engaged and technical, but I shouldn't pad. Aim ~700-900 words.


</details>

## Conceding the main thing first

I over-extended that BF16-vs-INT8 number, and you were right to push. The measurement's own Limitations section says:

> **"One text, one context.** WikiText-2 in 512-token chunks: short contexts in English prose. **Long contexts, code, chat and thinking were not measured.**"

512-token chunks. Your regime is 160k–250k. So that ΔKLD of 0.00003 does **not** license any claim about your depth — your anecdote isn't contradicted by the published data, it's simply *outside* it. And the deeper-context 8-bit effect you describe is mechanism-plausible: more candidates competing in softmax, retrieval-quality attention differences shrinking toward the per-element error floor, error accumulating across 12 attention layers. Nobody has measured it. That gap is real.

## Direct answer to what you asked

Split, because the two halves have different answers:

**f16 (Basalt) → bf16 (NInfer/Infernix), all else equal: no, not measurably different.** Still. That part I'll stand behind — 2 mantissa bits between two 16-bit formats, both far above the model's rounding sensitivity.

**Basalt → NInfer/Infernix at "the identical type": yes, and the difference is real — but it isn't coming from KV.** Here are the published rows where NInfer and Infernix both ran BF16 KV ([quality.md](https://github.com/Wallawalla47/Infernix/blob/main/docs/quality.md)):

| Path | Engine | Mean KLD | × rounding | PPL vs ref |
|---|---|---|---|---|
| Prompt | Infernix (BF16 KV) | 0.01690 [0.01604, 0.01798] | 10.5 | +0.69% |
| Prompt | **NInfer `a754fcf3b` (BF16 KV)** | 0.01660 [0.01588, 0.01753] | **10.4** | +0.67% |
| Decode | Infernix (DFlash2) | 0.00442 | 2.76 | −0.10% |
| Decode | **NInfer (MTP, 3 drafts)** | 0.00439 | **2.74** | −0.02% |

Overlapping intervals. Those two engines are indistinguishable at the same KV dtype — which is a clean answer to "same type, different engine."

Where the engine swap *does* bite is the arithmetic, and it's the row you're currently sitting on:

| Engine (IQ3_S) | × honest rounding | PPL vs ref |
|---|---|---|
| Infernix default | 0.91 | +0.08% |
| llama.cpp b12128 | 0.94 | −0.03% |
| **Basalt v0.2.1** | **1.20** | **+0.47%** ← the only CI-excluding-zero row |
| Strata v0.2.11 | 1.45 | −0.00% |

That's attributed to 8-bit activations, an 8-bit copy of the BF16 hyper-connection matrices, and a 2-bit head screen — not KV. So moving off Basalt should move you *more* than the dtype did, and in the good direction.

## Two corrections worth having

**1. Basalt's published KV setting was not fp16.** Its entry in the run is verbatim: `--kv int8`. So none of those Basalt KLD/PPL figures describe your fp16-served config — you're already off the published map, which is why you can't find the comparison.

**2. bf16 in NInfer/Infernix is not a downgrade from your fp16 — it's the ceiling in that harness.** Infernix's reference is defined as *"the model as specified, computed without error"* with **BF16 KV**. vLLM's auto = BF16. TensorSharp = BF16. NInfer = BF16. The one team that built a bit-exact lossless route chose bf16 as ground truth for this architecture. You'd be moving to the reference format, not away from it.

Also, on your "MoE makes it matter" instinct — published and named as a mechanism:

> **IQ3_S floor.** Honest rounding is 10× higher here than on the 27B: **a small rounding difference can change which experts the router picks, and the change then spreads.**

0.016 vs 0.0016. Flash-Next is an order of magnitude more sensitive to *any* numeric perturbation than the dense 27B. That guarantees **divergence** (your greedy tokens at 200k will not match across engines), but note what it does *not* guarantee — Strata is 1.45× diverged and its perplexity matches the reference exactly.

## The instrument problem — this is the actionable part

You said you're maximizing **perplexity**. That metric will likely show you nothing, even where an effect exists:

> Rounding errors raise some tokens' probabilities and lower others about equally, so they **cancel in the mean log-likelihood**: Strata's IQ3_S row is **1.45× honest rounding by KLD and 0.00% by perplexity**.

Your control-group design is sound; the readout is wrong. Use **KL divergence + top-1 agreement** against your own 16-bit reference, not PPL. Concretely:

1. Freeze one 200k-token agentic session (real code + tool output, not prose — code and chat are explicitly unmeasured).
2. Reference = Basalt fp16 KV, single pass, no drafting, greedy.
3. Arms: Basalt fp16 · NInfer bf16 · NInfer bf16p · Basalt int8 (your control).
4. Score per-position KLD and top-1 flip rate vs that reference; report the delta **relative to the engine-swap-at-fixed-KV delta**, or you can't separate dtype from arithmetic.
5. Run it at 8k too. If the 8-bit-vs-16-bit gap is flat between 8k and 200k, your hypothesis is dead; if it widens, you've measured something that **does not exist in any published source on this model** — the MoE quality tables deliberately used 8-bit KV for every engine, so there is no 16-bit row for Flash-Next anywhere.

That last point is your actual opportunity: the "int8/fp8 canon" you noticed is largely an artifact of benchmark design — engines were normalized to a common dtype to be comparable, which quietly deleted the 16-bit question from the literature rather than answering it.
## User · #61

Okay, so legitimately, in a one line statement. Give a structural scientific hypothesis (thesis) statement. And, slip in a pepegabrain statement (bf16, if anything, should be the worser one - as an example of what I mean by this, choose the actual variant that is more true).
## Assistant · #62

<details><summary>Reasoning · 9,227 characters</summary>

The user wants a one-line scientific hypothesis statement, plus a "pepegabrain" statement — a deliberately contrarian/edgy claim that is actually the more true one. Their example: "bf16, if anything, should be the worser one." They want me to pick the actual variant that is more true.

So: is bf16 worse than f16, or better? Let me reason.

Format facts:
- f16 (IEEE half): 1 sign, 5 exponent, 10 mantissa (11 effective significand bits). Max ~65504, min normal ~6.1e-5.
- bf16: 1 sign, 8 exponent, 7 mantissa (8 effective bits). Same range as f32.

For KV cache storage:
- Precision: f16 has 11 effective significand bits vs bf16's 8 → f16 is ~4× finer relative rounding error (2^-11 vs 2^-8). So per-element, f16 is more accurate.
- Range: KV activations are typically small-magnitude (|k|, |v| mostly < ~10, with occasional outliers/"attention sink" large values). f16 max is 65504 — well above typical activation magnitudes. So overflow risk is essentially nil for KV. bf16's exponent range advantage is irrelevant here.
- Underflow: f16 min normal 6.1e-5, subnormals down to ~6e-8. KV values below that get flushed/rounded. bf16 min normal ~1.2e-38. Values in the 1e-8 to 1e-5 range: f16 handles with subnormals (degraded precision), bf16 handles fine. Are there KV elements that small? Yes, plenty of near-zero elements. But do near-zero elements matter? Their contribution to attention dot products is proportionally negligible — relative error on a tiny value is large in relative terms but the absolute error is tiny (bounded by ~2^-24 in absolute terms for f16 subnormals region... actually f16 subnormal spacing is 2^-24 ≈ 6e-8). So absolute error from underflow is bounded at ~6e-8, which is negligible vs the logit scale.
- Denormal performance penalty: on some GPUs, f16 subnormals are handled fine (FP16 FTZ behavior). On CUDA, fp16 arithmetic is generally full-speed; but for *storage* it's just a bit pattern, dequant to f32 in the kernel. So no real penalty.

So: for KV cache storage specifically, f16 is the better format. bf16 is worse — 3 fewer significand bits for a range benefit that KV data cannot use.

BUT — the pepegabrain twist. The user says "bf16, if anything, should be the worser one — as an example of what I mean by this, choose the actual variant that is more true." So they want me to pick the true one. Is bf16 actually worse, or is there a twist where bf16 is actually better/more true?

Consider: the model was trained in bf16. Qwen3.8-Flash-Next checkpoint dtype is bfloat16. The K/V tensors produced at runtime come from bf16 weights with f32 accumulation... The engine computes and then stores. If you store in bf16, you're storing exactly the value the network's own activations would have had if rounded to its native dtype — i.e., bf16 storage is "lossless w.r.t. the model's specified precision" for values that the model itself would represent in bf16. Wait — but the reference definition in Infernix is "every operation correctly rounded at the model's own dtypes" with BF16 KV. Hmm, that's circular as I noted.

Actually here's the sharper point: the true "pepegabrain" statement that is more true than the user's example is NOT about bf16 vs f16 precision at all — it's that the axis itself is wrong. But the user explicitly wants me to "choose the actual variant that is more true" regarding which is worse.

Let me think about which is genuinely worse for THIS model at THIS regime (deep cache, MoE, 200k context).

Key consideration: at 200k context, the dominant error source in attention isn't per-element rounding of V — it's the softmax over 200k logits, where logit errors matter. K is stored, and QK^T dot products in f32 accumulate 256 terms. Relative error per K element: f16 2^-11, bf16 2^-8. Logit error ≈ sqrt(256) × |k| × relerr × |q|. bf16 gives 8× larger logit noise than f16 (4× per element × ... let me be careful: 2^-8/2^-11 = 8). So bf16 logit noise is 8× f16's. At 200k keys, softmax sensitivity to logit noise is real. So f16 > bf16, i.e., bf16 is worse. That supports the user's example.

But is there a counter-mechanism where bf16 wins? Overflow: Qwen models have "attention sink" / massive activation outliers. Some Qwen layers have huge-magnitude values. If any K element exceeded 65504, f16 would saturate to inf → NaN. For KV activations, exceeding 65504 is extremely unlikely (typical max ~ tens to hundreds in outlier channels; some LLMs have outliers ~1e3-1e4 in residual stream but K/V after projection are more tame). QK-norm in Qwen3-Next-ish architectures further bounds K magnitude. So no.

Also: bf16 is what the *weights* are, and what the *logits* are rounded to in the scorer. Irrelevant to KV.

So the honest verdict: **f16 is the more accurate KV storage format; bf16 is the worse one** — the user's example is actually correct, not contrarian. The genuinely contrarian ("pepegabrain") statement that is MORE true is a different one: that the choice is irrelevant *in practice* because the model's own router-flip sensitivity (10× higher on this MoE) dwarfs the 8× format difference... hmm, but those are comparable orders.

Wait. Let me quantify honestly. Honest rounding noise floor on IQ3_S = 0.016 mean KLD. Is f16→bf16 KV a perturbation of that magnitude or smaller? Going from f16 to bf16 KV increases KV rounding error 8×. Compare: INT8 KV vs BF16 KV showed ΔKLD 0.00003 at short context. INT8 KV (symmetric, presumably per-element or per-block) has relative error roughly... INT8 with 7 bits + sign over a dynamic range — comparable to or better than bf16's 8-bit mantissa actually, since int8 quantization of a bounded range gives ~2^-8 relative to max, similar to bf16's 2^-8 relative to each value. Interesting — that's why they're equivalent!

So: INT8 KV ≈ BF16 KV in quality (measured, ΔKLD 3e-5). And BF16 KV is the reference. Therefore f16 KV should be ≈ bf16 KV too, both within the floor. And the measured INT8≈BF16 result is strong indirect evidence that f16≈bf16, because INT8 KV is roughly as precise as bf16 and bf16 is 8× coarser than f16 — so if the 8-bit step (f16→bf16-ish) were measurable, then INT8-vs-BF16 (which spans a similar precision distance in a different parameterization) would likely have shown something.

Hmm, but INT8 vs BF16 isn't exactly an 8-bit step. INT8 over a bounded range: absolute error = range/254. BF16: relative 2^-8 = error = |x|/256, so for the largest values it's similar to int8's absolute error; for small values bf16 is much better. So BF16 ≥ INT8 in precision for small values. And measured BF16 ≈ INT8 (ΔKLD 3e-5). That means the quality curve is FLAT in that region — i.e., going from bf16 (8 bits) up to f16 (11 bits) is moving along a flat part of the curve. That's the argument.

So the truly more-true pepegabrain statement: **bf16 is nominally the worse format, and it doesn't matter — and the actually-worse choice in your stack isn't bf16 vs f16 at all, it's Basalt's 8-bit activations / 2-bit head screen.** That's supported by published data (Basalt 1.20× rounding, +0.47% PPL, only CI-excluding-zero row; attributed to activations not KV).

Even better pepegabrain: "Your bf16-vs-f16 debate is a rounding-error argument between two things that both sit below the noise floor of the engine you're actually running." Or: "The 3 bits you're fighting over are smaller than the 8-bit copy of the hyper-connection matrices you're not."

Now the thesis statement (one line, structural, scientific, falsifiable):

Thesis: "For a hybrid sparse-MoE architecture whose KV footprint is confined to 12 of 48 layers and whose router amplifies sub-ulp perturbations superlinearly with context length, KV-cache storage precision below the checkpoint's native activation precision is predicted to degrade retrieval-weighted attention monotonically with context depth, while precision *above* that native dtype yields diminishing returns bounded by router decision instability rather than by representational error."

Hmm, that's a mouthful but it's a real thesis: degradation below native is monotone in depth; above native is capped by router noise. Falsifiable: measure KLD vs depth for {int8, bf16, f16, f32} at 8k/64k/128k/250k. Predictions: int8 diverges from bf16/f16 with increasing depth; f16 vs bf16 gap stays flat and near floor; f32 gives no gain over f16.

Then the pepegabrain one-liner: pick the true variant. "bf16 is the worse format — 3 fewer significand bits buying exponent headroom that bounded, QK-normalized KV activations can never use — and it loses by so little that the 8-bit hyper-connection copy and 2-bit head screen you already accepted are a larger numeric tax than the entire dtype argument."

Let me make it punchy and one-line each. Also they said "slip in" — so keep it tight, not a wall of text. Format: Thesis (one line), Pepegabrain (one line), maybe a tiny "how to falsify" clause. Keep short — the user wants brevity after long turns.

Let me write it compactly.

I should make sure the thesis is genuinely structural and falsifiable, and the pepegabrain is genuinely the more-true variant (bf16 worse, per format arithmetic), while noting it's dominated by other errors.

Keep it short. Maybe 3 short blocks max. No need for tools.


</details>

**Thesis.** In a hybrid sparse-MoE whose cache is confined to 12 of 48 layers and whose router amplifies sub-ULP perturbations with context depth, KV storage precision *below* the checkpoint's native activation dtype should degrade retrieval-weighted attention monotonically in context length, while precision *above* it should asymptote — the residual gap bounded by router decision instability, not representational error.

**Pepegabrain.** BF16 is the worse format — three fewer significand bits traded for exponent headroom that QK-normalized, single-digit-magnitude KV vectors can never spend — and it loses by so little that the 8-bit hyper-connection copy and 2-bit head screen you already accepted are a bigger numeric tax than the entire dtype argument.

**Falsifier.** KLD vs. your own f16 reference across {int8, bf16, f16, f32} × {8k, 64k, 128k, 250k}: the int8↔16-bit gap must widen with depth and the f16↔bf16 gap must stay flat near the floor. If f16-vs-bf16 widens too, the thesis is dead and you have the first 16-bit KV row published for this model.
"""

let render() = file
