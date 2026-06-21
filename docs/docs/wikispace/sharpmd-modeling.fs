module ConvertedFiles.Docs.Wikispace.ModelingMd

let file = """# Want to Get Into Modeling?

Local large language model deployment requires navigating a landscape of inference engines, hardware constraints, and quantization formats. This page provides a decision framework for selecting the appropriate tooling stack based on hardware, use case, and performance requirements. It includes a comprehensive comparison of vLLM and Ollama, the two dominant local inference frameworks, based on benchmark data from NVIDIA Blackwell hardware.

---

## Overview

???+ note "What this page covers"
    Local LLM deployment decision framework with head-to-head benchmarks of vLLM vs Ollama on NVIDIA Blackwell hardware. Includes quantization formats, hardware requirements, and the complete AI agent stack. For the broader AI tooling context, see [AI Agent Stack](ai-agent-stack.md) and [Local LLM Deployment](local-llm.md).

---

## Decision Framework

```mermaid
flowchart TD
    A["Need local LLM?"] --> B{"Multiple clients?"}
    B -->|Yes| C["vLLM<br/>PagedAttention"]
    B -->|No| D{"NVIDIA 16GB+ VRAM?"}
    D -->|Yes| E["vLLM + TensorRT-LLM"]
    D -->|No| F{"CPU / Apple Silicon?"}
    F -->|Yes| G["Ollama / llama.cpp"]
    F -->|No| H{"Quick setup?"}
    H -->|Yes| G
    H -->|No| I["Compare benchmarks<br/>on this page"]
    
    style C fill:#2d5a3a,color:#fff
    style G fill:#4a7c59,color:#fff
    style E fill:#2d5a3a,color:#fff
```

---

## vLLM vs Ollama: Benchmark Analysis

The following data is derived from independent benchmarks conducted on NVIDIA Blackwell (RTX 5090) hardware with 96 GB VRAM, testing both vLLM 0.11.0 and Ollama 0.10.5 with the Gemma 4 27B NVFP4 model.

### Throughput Benchmarks (requests/second)

| Batch Size | vLLM (requests/sec) | Ollama (requests/sec) | vLLM Advantage |
|------------|---------------------|-----------------------|----------------|
| 1 (single user) | 12.4 | 8.7 | 1.42x |
| 4 | 38.2 | 18.3 | 2.09x |
| 8 | 67.5 | 24.1 | 2.80x |
| 16 | 89.3 | 26.8 | 3.33x |
| 32 | 94.7 | 27.2 | 3.48x |

### Latency Benchmarks (time to first token, milliseconds)

| Batch Size | vLLM (TTFT) | Ollama (TTFT) | Winner |
|------------|-------------|---------------|--------|
| 1 | 45ms | 38ms | Ollama |
| 4 | 52ms | 89ms | vLLM |
| 8 | 61ms | 156ms | vLLM |
| 16 | 78ms | 312ms | vLLM |
| 32 | 112ms | 589ms | vLLM |

### Memory Efficiency (VRAM usage, GB)

| Metric | vLLM | Ollama |
|--------|------|--------|
| Model load (27B NVFP4) | 14.2 GB | 14.8 GB |
| KV cache (batch=16, 4K ctx) | 3.8 GB | 8.2 GB |
| Total (batch=16) | 18.0 GB | 23.0 GB |
| KV cache efficiency | 2.16x better | — |

### Key Findings

1. **Single-user scenarios**: Ollama has lower time-to-first-token (38ms vs 45ms) and simpler setup. For personal desktop use with one client, Ollama is the pragmatic choice.

2. **Multi-user scenarios**: vLLM's PagedAttention and continuous batching provide 3.5x throughput at batch=32. The gap widens as concurrency increases.

3. **KV cache**: vLLM's non-contiguous KV cache management uses 2.16x less memory for the same batch size, enabling larger batches or longer contexts.

4. **Throughput saturation**: vLLM saturates the GPU at batch=32 (94.7 req/s). Ollama saturates at batch=8 (24.1 req/s) and does not scale beyond.

---

## vLLM: Architecture and Configuration

vLLM is a high-throughput inference engine featuring PagedAttention for efficient KV-cache memory management. It supports continuous batching, tensor parallelism, and speculative decoding.

### Installation

```bash
# Pre-built wheels (CUDA 12.1+)
pip install vllm

# From source for specific CUDA version
pip install https://wheels.vllm.ai/nightly/cu123/vllm/

# Verify installation
python -c "import vllm; print(vllm.__version__)"
```

### Serving a Model

```bash
# Single GPU
vllm serve "meta-llama/Llama-3.1-8B-Instruct" \
    --tensor-parallel-size 1 \
    --gpu-memory-utilization 0.9 \
    --max-model-len 4096

# Multi-GPU
vllm serve "meta-llama/Llama-3.1-70B-Instruct" \
    --tensor-parallel-size 4

# With quantization (AWQ)
vllm serve "TheBloke/Llama-2-7B-AWQ" \
    --quantization awq \
    --dtype half
```

### torch.compile Optimization

```python
import vllm
from vllm import LLM, SamplingParams

llm = LLM(
    model="meta-llama/Llama-3.1-8B-Instruct",
    compilation_config={
        "level": 3,  # Max optimization
        "backend": "inductor",
        "mode": "reduce-overhead",
        "fullgraph": True,
    }
)
```

| Compilation Level | Description | Use Case |
|-------------------|-------------|----------|
| 0 | No compilation | Debugging |
| 1 | Compile CUDA graphs | Single requests |
| 2 | Compile with inductor | Batch processing |
| 3 | Max optimization (fullgraph) | Production serving |

---

## Ollama: Architecture and Configuration

Ollama provides a single-binary deployment model with built-in model management and a REST API. It uses llama.cpp as the inference backend.

### Installation

```bash
# macOS / Linux
curl -fsSL https://ollama.com/install.sh | sh

# Windows
# Download installer from ollama.com
```

### Running a Model

```bash
# Pull and run
ollama pull llama3.1:8b
ollama run llama3.1:8b

# Start API server
ollama serve

# API endpoint: http://localhost:11434
# OpenAI-compatible endpoint available
```

### Configuration

```bash
# Modelfile for customization
cat > Modelfile << 'EOF'
FROM llama3.1:8b
PARAMETER temperature 0.7
PARAMETER top_p 0.9
SYSTEM You are a helpful coding assistant.
EOF

ollama create mymodel -f Modelfile
ollama run mymodel
```

---

## Quantization Formats

| Format | Bits | Relative Quality | VRAM (7B model) | Supported By |
|--------|------|-------------------|-----------------|--------------|
| FP32 | 32 | 100% | 28 GB | Both |
| FP16/BF16 | 16 | ~99% | 14 GB | Both |
| INT8 | 8 | ~97% | 7 GB | Both |
| GPTQ INT4 | 4 | ~95% | 4 GB | vLLM, AutoGPTQ |
| AWQ INT4 | 4 | ~96% | 4 GB | vLLM, AutoAWQ |
| GGUF Q4_K_M | 4 | ~94% | 4 GB | Ollama, llama.cpp |
| NVFP4 (Blackwell) | 4 | ~98% | 4 GB | vLLM, TensorRT-LLM |

### NVFP4 (NVIDIA Blackwell)

NVFP4 is a 4-bit floating-point format introduced with NVIDIA Blackwell (RTX 50-series, H200). It uses 2-bit exponent and 1-bit mantissa with a shared scale factor per 16-element block, providing higher quality than INT4 quantization at the same memory footprint.

```python
# vLLM with NVFP4 (requires Blackwell GPU)
llm = LLM(
    model="nvidia/Llama-3.1-8B-NVFP4",
    quantization="nvfp4",
    dtype="float16"
)
```

---

## Hardware Requirements

| Model Size | VRAM (FP16) | VRAM (INT4) | Min GPU (FP16) | Min GPU (INT4) |
|------------|-------------|-------------|----------------|----------------|
| 7B | 14 GB | 4 GB | RTX 3080 (10GB) | RTX 3060 (12GB) |
| 13B | 26 GB | 8 GB | RTX 3090 (24GB) | RTX 3080 (10GB) |
| 30B | 60 GB | 16 GB | 2x RTX 3090 | RTX 4090 (24GB) |
| 70B | 140 GB | 40 GB | 4x A100 (40GB) | 2x RTX 4090 |

### CPU Inference with llama.cpp

```bash
# Download quantized model
wget https://huggingface.co/TheBloke/Llama-2-7B-GGUF/resolve/main/llama-2-7b.Q4_K_M.gguf

# Run inference
./main -m llama-2-7b.Q4_K_M.gguf -n 256 --temp 0.8 -p "The capital of France is"

# With OpenAI-compatible server
./server -m llama-2-7b.Q4_K_M.gguf --host 0.0.0.0 --port 8080
```

---

## AI Agent Stack

The full stack for local AI development:

| Layer | Purpose | Tools |
|-------|---------|-------|
| 1 — Harness | Terminal integration for AI | OpenClaw, PicoClaw, NemoClaw, Pi Agent, Hermes Agent, Oh My Opencode |
| 2 — Terminal Agent | CLI-first coding agents | Claude Code, Opencode |
| 3 — IDE Agent | Editor-integrated agents | Cursor, Antigravity, Codex |
| 4 — Redirect | Model routing and proxying | LiteLLM, OpenRouter |
| 5 — Model Serving | Local inference engines | vLLM, AIStudio, Ollama, llama.cpp, LM Studio |

### Terminal Harness Tools

| Tool | Description |
|------|-------------|
| Opencode | Terminal-integrated AI client with plugin system |
| Oh My Opencode | Framework for extending Opencode with custom agents |
| Hermes Agent | Autonomous agent with tool use by Nous Research |
| Pi Agent | Personal intelligence agents via pi.dev registry |

### IDE Agents

| Tool | Description |
|------|-------------|
| Cursor | VS Code fork with built-in AI agent capabilities |
| Codex | OpenAI chat-based coding assistance |
| Antigravity | AI-powered development environment |

### Redirect Proxies

| Tool | Description |
|------|-------------|
| LiteLLM | Unified API for 100+ model providers |
| OpenRouter | Single API key for multiple providers |

---

## Local Setup Guides

### NVIDIA Free AI Coding Agent

Community guides for setting up local AI coding agents on NVIDIA hardware:

| Guide | URL | Description |
|-------|-----|-------------|
| OpenCode + OpenRouter + NVIDIA | github.com/network-tocoder/OpenCode-OpenRouter-NVIDIA-Free-AI-Coding-Agent-Setup-Guide | OpenCode setup with NVIDIA optimization |
| Claude Code + NVIDIA | github.com/network-tocoder/Claude-Code-NVIDIA-Free-AI-Coding-Agent | Claude Code on NVIDIA GPUs |
| Local AI Agent Gemma4 | github.com/network-tocoder/Local-AI-Coding-Agent-Gemma4-VS-Code-Ollama-Contine | VS Code + Ollama + Continue |
| Google Agents CLI | github.com/network-tocoder/Google-Agents-CLI-Full-Setup-Guide | Google Agents setup |

---

## DeepWiki References

| Resource | URL | Description |
|----------|-----|-------------|
| vLLM EngineCore and Client APIs | https://deepwiki.com/vllm-project/vllm/3.1-enginecore-and-client-apis | Community vLLM documentation |
| GenAImil | https://grokipedia.com/page/GenAImil | AI model information |

---

## Related Deep Hole

- [Allen Kuo: vLLM or Ollama on Blackwell? Benchmarks, Landmines, and What Agents Actually Need](https://allenkuo.medium.com/vllm-or-ollama-on-blackwell-benchmarks-landmines-and-what-agents-actually-need-5dc539bb28ef) — Benchmark data source
- [Allen Kuo: Gemma 4 on vLLM vs Ollama Benchmarks on a 96 GB Blackwell GPU](https://allenkuo.medium.com/gemma-4-on-vllm-vs-ollama-benchmarks-on-a-96-gb-blackwell-gpu-804ca4845a21) — Head-to-head comparison
- [Allen Kuo: vLLM on Blackwell with TurboQuant KV Cache](https://aivrar.medium.com/how-i-got-vllm-running-natively-on-windows-no-wsl-no-docker-with-bonus-turboquant-kv-cache-af0ec0b3ce62) — Windows vLLM setup
- [Julsimon: What to Buy for Local LLMs April 2026](https://julsimon.medium.com/what-to-buy-for-local-llms-april-2026-a4946a381a6a) — Hardware recommendations
- [vLLM Documentation](https://docs.vllm.ai/) — Official inference engine documentation
- [Ollama GitHub](https://github.com/ollama/ollama) — Source code and releases
- [Local AI Wiki](https://github.com/useaitechdad/llm-wiki-and-gemma4-tests) — Community LLM testing
- [Hermes Agent Documentation](https://hermes-agent.nousresearch.com/docs/skills/) — Nous Research agent framework
"""

let render() = file
