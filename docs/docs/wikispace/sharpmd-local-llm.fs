module ConvertedFiles.Docs.Wikispace.LocalLlmMd

let file = """# Local Language Model Deployment

Running large language models locally provides data privacy, eliminates API dependency, and enables customization of model behavior for specific tasks. This page covers local LLM inference tools, hardware requirements, quantization methods, and the vLLM serving framework for high-throughput generation.

---

## Overview

???+ note "What this page covers"
    This page documents local large language model deployment and optimization:

    - **Inference Frameworks** — vLLM, llama.cpp, Ollama, Transformers, TensorRT-LLM
    - **vLLM Setup** — Installation, model serving, torch.compile optimization levels
    - **Quantization** — FP32 through NVFP4 quality/VRAM tradeoffs
    - **Hardware Requirements** — GPU VRAM requirements by model size and precision
    - **CPU Inference** — llama.cpp GGUF for non-GPU deployments

    For the broader AI agent stack including model curation and API integration, see [AI Agent Stack](ai-agent-stack.md). For deep neural network analysis, see [DNN Analysis](dnn-analysis.md).

---

## Inference Frameworks

```mermaid
flowchart TD
    subgraph GPU["GPU-Accelerated"]
        direction TB
        VLLM["vLLM<br/>(PyTorch, PagedAttention)"]
        TRT["TensorRT-LLM<br/>(NVIDIA optimized)"]
        OLL["Ollama<br/>(llama.cpp wrapper)"]
    end

    subgraph CPU["CPU / Edge"]
        direction TB
        LLCPP["llama.cpp<br/>(GGUF quantization)"]
    end

    subgraph Research["Research / Training"]
        direction TB
        HF["Transformers<br/>(Hugging Face)"]
    end

    REQ["Inference Request"] --> GPU
    REQ --> CPU
    REQ --> Research

    VLLM -->|"Highest throughput<br/>Multi-GPU"| OUT["Generated Tokens"]
    TRT -->|"Max NVIDIA perf<br/>FP8/INT8/INT4"| OUT
    LLCPP -->|"CPU/mobile<br/>Q4_K_M"| OUT
    HF -->|"Fine-tuning<br/>Research"| OUT

    style GPU fill:#4a90d9
    style CPU fill:#7ed321
    style Research fill:#f5a623
```

| Framework | Backend | Quantization | Use Case |
|-----------|---------|-------------|----------|
| **vLLM** | PyTorch | GPTQ, AWQ, FP8, NVFP4 | High-throughput serving, multi-GPU |
| **llama.cpp** | C/C++ | GGUF (Q4, Q5, Q8, F16) | CPU inference, edge devices |
| **Ollama** | Go/llama.cpp | GGUF | Easy local deployment |
| **Transformers** | PyTorch | AutoGPTQ, BnB | Research, fine-tuning |
| **TensorRT-LLM** | TensorRT | FP8, INT8, INT4 | Maximum NVIDIA GPU performance |

---

## vLLM

vLLM is a high-throughput inference engine featuring PagedAttention for efficient KV-cache memory management. It supports continuous batching, tensor parallelism, and speculative decoding.

### Architecture

```mermaid
flowchart TD
    subgraph vLLM_Engine["vLLM Engine"]
        direction TB
        SCH["Scheduler<br/>(Continuous Batching)"]
        PA["PagedAttention<br/>(Block Manager)"]
        subgraph KV["KV Cache"]
            B1["Block 1"]
            B2["Block 2"]
            B3["Block 3"]
        end
        WORK["Worker<br/>(GPU Compute)"]
    end

    REQ1["Request A<br/>'Explain quantum...'"] --> SCH
    REQ2["Request B<br/>'Write a poem...'"] --> SCH
    REQ3["Request C<br/>'Summarize...'"] --> SCH
    SCH --> PA
    PA --> KV
    PA --> WORK
    WORK --> OUT1["Tokens A"]
    WORK --> OUT2["Tokens B"]
    WORK --> OUT3["Tokens C"]

    style vLLM_Engine fill:#4a90d9
```

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
vllm serve "meta-llama/Llama-2-7b-chat-hf" \
    --tensor-parallel-size 1 \
    --gpu-memory-utilization 0.9 \
    --max-model-len 4096

# Multi-GPU
vllm serve "meta-llama/Llama-2-70b-chat-hf" \
    --tensor-parallel-size 4 \
    --pipeline-parallel-size 1

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
    model="meta-llama/Llama-2-7b-chat-hf",
    compilation_config={
        "level": 3,  # Max optimization
        "backend": "inductor",
        "mode": "reduce-overhead",
        "fullgraph": True,
    }
)

sampling_params = SamplingParams(temperature=0.8, top_p=0.95)
outputs = llm.generate(["The capital of France is"], sampling_params)
```

| Compilation Level | Description | Use Case |
|-------------------|-------------|----------|
| 0 | No compilation | Debugging |
| 1 | Compile CUDA graphs | Single requests |
| 2 | Compile with inductor | Batch processing |
| 3 | Max optimization (fullgraph) | Production serving |

---

## Quantization

Quantization reduces model precision to decrease memory usage and increase inference speed.

```mermaid
flowchart LR
    subgraph Precision["Precision / Quality Tradeoff"]
        direction LR
        FP32["FP32<br/>100%<br/>28GB"] --> FP16["FP16/BF16<br/>~99%<br/>14GB"]
        FP16 --> INT8["INT8<br/>~97%<br/>7GB"]
        INT8 --> GPTQ["GPTQ INT4<br/>~95%<br/>4GB"]
        GPTQ --> AWQ["AWQ INT4<br/>~96%<br/>4GB"]
        AWQ --> NVFP4["NVFP4<br/>(Blackwell)<br/>~98%<br/>4GB"]
    end

    style FP32 fill:#d0021b
    style FP16 fill:#f5a623
    style INT8 fill:#7ed321
    style NVFP4 fill:#4a90d9
```

| Format | Bits | Relative Quality | VRAM (7B model) |
|--------|------|-------------------|----------------|
| FP32 | 32 | 100% | 28 GB |
| FP16/BF16 | 16 | ~99% | 14 GB |
| INT8 | 8 | ~97% | 7 GB |
| GPTQ INT4 | 4 | ~95% | 4 GB |
| AWQ INT4 | 4 | ~96% | 4 GB |
| GGUF Q4_K_M | 4 | ~94% | 4 GB |
| NVFP4 (Blackwell) | 4 | ~98% | 4 GB |

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

## Related Pages

- [AI Agent Stack](ai-agent-stack.md) — Model curation, API integration, agent frameworks
- [DNN Analysis](dnn-analysis.md) — Neural network architecture analysis

## Related Deep Hole

- [vLLM Documentation](https://docs.vllm.ai/) — Official inference engine documentation
- [vLLM GitHub Repository](https://github.com/vllm-project/vllm) — Source code and releases
- [torch.compile Documentation](https://docs.pytorch.org/docs/2.2/generated/torch.compile.html) — PyTorch compilation reference
- [NVIDIA TensorRT-LLM](https://github.com/NVIDIA/TensorRT-LLM) — Optimized NVIDIA inference
- [llama.cpp GitHub](https://github.com/ggerganov/llama.cpp) — CPU inference engine
- [Ollama](https://ollama.ai/) — Easy local model management
"""

let render() = file
