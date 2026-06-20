module Imported.Posts.N20250315ShelGemma4ReleaseMd

let file = """---
layout: post
title: "Gemma 4 on Blackwell: A Three-Act Saga of Pain and Glory"
author: "CommanderTurtle"
date: 2025-03-15 16:00:00 +0000
tags: [llm, local-ai, windows, gemma, blackwell, vllm, nvfp4]
---

Getting Gemma 4 running locally on a 5090 wasn't supposed to be this hard. NVIDIA's latest Blackwell architecture, a brand-new MoE model from Google, and a quantization format (NVFP4) designed specifically for the hardware — what could go wrong?

Everything, it turns out. But the destination was worth every hour.

## The Model

The release is **[sHEL Gemma 4 A4B Heretic NVFP4](https://huggingface.co/sHEL1562/gemma-4-A4B-it-MoE-HERETIC-nvfp4-blackwell)** — a pruned-expert, reasoning-optimized Gemma-4 MoE model with full NVFP4 quantization using NVIDIA ModelOpt. Built on the DavidAU heretic base, pruned from 128 to 90 experts, then fully finetuned. It supports thinking mode (with `<|think|>` blocks), instruct mode, tool calling, and full multimodal vision via AEON's proven methods.

The specs: 19B parameters (26B pruned), 10B params export size, ~16GB on disk, 256K native context length, served at 64K for throughput. On a 5090 with 32GB VRAM, four parallel 65K context windows at 170 tok/s.

## Act I: Following Allen Kuo Into the Minefield

I started where anyone should start — Allen Kuo's three-part Medium saga on getting vLLM running on Blackwell.

**[Part 1: vLLM or Ollama on Blackwell](https://allenkuo.medium.com/vllm-or-ollama-on-blackwell-benchmarks-landmines-and-what-agents-actually-need-5dc539bb28ef)** set the stage. Allen laid out the fundamental problem: Blackwell is new, the software stack is raw, and most "it just works" claims are lies. He benchmarked both vLLM and Ollama, found landmines in CUDA version compatibility, driver requirements, and the reality that "FP8 support" doesn't mean "your model will load."

**[Part 2: Gemma 4 on vLLM vs Ollama](https://allenkuo.medium.com/gemma-4-on-vllm-vs-ollama-benchmarks-on-a-96-gb-blackwell-gpu-804ca4845a21)** went deeper. Specific to Gemma 4, Allen documented the MoE routing issues, the context length limitations, the memory footprint surprises. His 96GB Blackwell GPU gave him room I didn't have — my 5090's 32GB meant every quantization decision mattered.

**[Part 3: Finishing What We Started](https://allenkuo.medium.com/finishing-what-we-started-gemma-4-nvfp4-on-vllm-desktop-blackwell-wsl2-b2088c34815a)** was where things got real. NVFP4 on vLLM, inside WSL2, with manual patching. Allen documented the full reproduction method: ModelOpt calibration, the 15-hour CPU quantization process, manual shard patching for vision tower keys, and the specific environment variables needed to make Blackwell's Cutlass/FlashInfer/Marlin paths all activate correctly.

## Act II: The WSL2 Rabbit Hole

Following Allen's guide, I went deep into WSL2. The quantization itself took ~15 hours on a high-end CPU — the model simply doesn't fit in BF16 on a 5090 alone, so you quantize on CPU using `uv run` inside a vLLM venv. The calibration uses 512 samples at sequence length 4096, batch size 3, with `NVFP4_DEFAULT_CFG` (plain NVFP4, no AWQ).

Then came the patching nightmare. ModelOpt doesn't perfectly preserve vision tower + down_proj/up_proj/gate_proj/q_proj/k_proj/v_proj/o_proj keys across shards. I ended up running a sequence of manual patch scripts:

```bash
# Patches 'vision_tower and down_proj' keys
uv run clean_shards3-2.py
# Patches 'vision_tower and up_proj' keys
uv run clean_shards3-2-1.py
# ...and so on for every combination
```

Each script takes keys from the original `.safetensors` file and transplants them into the post-ModelOpt shards. When vLLM errors with `AssertionError: Tried to load weights of size torch.Size([2816,576]) to a parameter of size torch.Size([2816,1152])`, you run `scanoffendingkey.py`, find the mismatch, and build a new patch script.

The final fix was the EOS configuration. Gemma 4 uses internal control tokens (`<|channel>`, `<channel|>`, `<|think|>`, `<|tool_call>`, `<tool_call|>`) that can leak into API responses as plaintext spam if not handled. Adding tokens 98, 100, and 101 to `eos_token_id` in `generation_config.json` stops the model from getting stuck in repetition loops.

## Act III: Windows Native and the Breath of Fresh Air

After weeks in WSL2, I stumbled on **[SystemPanic/vllm-windows](https://github.com/SystemPanic/vllm-windows)** — the official vLLM Windows port. This changed everything.

No more WSL2 overhead. No more cross-filesystem path translation. No more `export` instead of `$env:`. Just native Windows PowerShell with a `uv` venv and the vllm-windows wheel.

The environment variables for Windows:

```powershell
$env:VLLM_TEST_FORCE_FP8_MARLIN="1"
$env:VLLM_MARLIN_USE_ATOMIC_ADD="1"
$env:VLLM_ALLOW_LONG_MAX_MODEL_LEN="1"
$env:TORCH_MATMUL_PRECISION="high"
$env:PYTORCH_CUDA_ALLOC_CONF="expandable_segments:True"
$env:NVIDIA_FORWARD_COMPAT="1"
```

The serving command:

```powershell
vllm serve sHEL1562/gemma-4-A4B-it-MoE-HERETIC-nvfp4-blackwell `
  --quantization modelopt `
  --kv-cache-dtype fp8_e4m3 `
  --max-model-len 65536 `
  --max-num-seqs 4 `
  --max-num-batched-tokens 8192 `
  --gpu-memory-utilization 0.90 `
  --enable-chunked-prefill `
  --enable-prefix-caching `
  --trust-remote-code `
  --enable-auto-tool-choice `
  --tool-call-parser gemma4 `
  --reasoning-parser gemma4
```

One PowerShell window. Four concurrent 65K context streams. 170 tok/s.

## The AEON Connection

The quantization method follows **[AEON-7's SuperGemma guidelines](https://huggingface.co/AEON-7/supergemma4-26b-abliterated-multimodal-nvfp4)**. AEON's work on the "Gemma Problem" — the internal control token leakage, the MoE routing quirks, the calibration strategies for pruned experts — was foundational. The model card explicitly references AEON's JSON configurations and the `clean_shards` patching methodology.

For anyone reconstructing the ModelOptimizer pipeline: it requires `modelopt`, `torch`, and `accelerate`, performed in WSL with `uv run`. The reproduction script is included in the model files. Just... expect to wait. And patch. And patch again.

## Life After WSL

The experience fundamentally changed how I work. WSL2 is still there for quantizing and debugging — anything that needs the full Linux build chain. But for actual inference serving? Native Windows vLLM is the way. I followed [OneMarcFifty's WSL productivity guide](https://www.youtube.com/watch?v=U_K2w-Cee1c) for setting up the Kali taskbar, minimal tools, and the hobby-project mindset. The future is a hybrid: WSL for build environments, Windows for runtime.

## Quickstart for 5090 Owners

Prerequisites: NVIDIA drivers, CUDA, PowerShell Preview from the Windows Store. No external dependencies.

```powershell
# Test the model is serving
curl http://localhost:8000/v1/models

# Run inference
$tmp="$env:TEMP\vllm_req_$(Get-Random).json"
$json=@{model='gemma4';messages=@(@{role='user';content=@(@{type='text';text='Your prompt here'})})}|ConvertTo-Json -Depth 10 -Compress
Set-Content -Path $tmp -Value $json
curl.exe http://localhost:8000/v1/chat/completions -H "Content-Type: application/json" -d "@$tmp"
```

Pipe the output through Notepad++ (find+replace `    ` with empty, `\n` with literal newline, `\"` with `"`), then paste into Obsidian for clean markdown rendering.

The model is uncensored, reasoning-optimized, and genuinely excellent at long-form narrative writing. The thinking blocks are unlike anything else — leave them on for complex writing tasks, switch to instruct mode for tool calling.

Download: [sHEL1562/gemma-4-A4B-it-MoE-HERETIC-nvfp4-blackwell](https://huggingface.co/sHEL1562/gemma-4-A4B-it-MoE-HERETIC-nvfp4-blackwell)
"""

let render() = file
