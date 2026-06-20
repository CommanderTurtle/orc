module ConvertedFiles.Docs.Wikispace.AiAgentStackMd

let file = """# AI Agent Stack

The landscape of local AI development involves layered tools spanning terminal shells, coding agents, model serving infrastructure, and redirect proxies. This page documents the ecosystem of tools for running large language models locally and integrating them into development workflows.

---

## Overview

???+ note "What this page covers"
    The 5-layer AI agent stack: terminal harnesses, CLI agents, IDE agents, redirect proxies, and model serving engines. For the Ollama vs vLLM comparison with benchmarks, see [Modeling](modeling.md). For local LLM hardware requirements, see [Local LLM Deployment](local-llm.md).

---

## Stack Layers

```mermaid
flowchart TD
    subgraph "Layer 5: Model Serving"
        M1["vLLM"] 
        M2["Ollama"]
        M3["llama.cpp"]
        M4["AIStudio"]
    end
    
    subgraph "Layer 4: Redirect"
        R1["LiteLLM"]
        R2["OpenRouter"]
    end
    
    subgraph "Layer 3: IDE Agent"
        I1["Cursor"]
        I2["Codex"]
    end
    
    subgraph "Layer 2: Terminal Agent"
        T1["Claude Code"]
        T2["Opencode"]
    end
    
    subgraph "Layer 1: Harness"
        H1["Hermes Agent"]
        H2["Pi Agent"]
        H3["Oh My Opencode"]
    end
    
    M1 --> R1 --> I1 --> T1 --> H1
    
    style M1 fill:#2d5a3a,color:#fff
    style H1 fill:#4a7c59,color:#fff
```

| Layer | Purpose | Tools |
|-------|---------|-------|
| 1 — Harness | Terminal integration for AI | OpenClaw, PicoClaw, NemoClaw, Pi Agent, Hermes Agent, Oh My Opencode |
| 2 — Terminal Agent | CLI-first coding agents | Claude Code, Opencode |
| 3 — IDE Agent | Editor-integrated agents | Cursor, Antigravity, Codex |
| 4 — Redirect | Model routing and proxying | LiteLLM, OpenRouter |
| 5 — Model Serving | Local inference engines | vLLM, AIStudio, Ollama, llama.cpp, LM Studio |

---

## Terminal Shell Layer

The foundation layer provides the command-line environment for tool integration:

| Shell | Use Case |
|-------|----------|
| PowerShell | Windows automation, .NET integration |
| Windows Terminal | Modern terminal emulator with tab support |
| CMD | Legacy batch scripting, `cmd.exe` literal-safe operations |
| VS Code Terminal | Integrated development terminal |

---

## Harness Layer

Terminal-integrated AI clients that provide conversational access to language models within the shell environment.

### Opencode

```bash
# Installation
curl -fsSL https://opencode.ai/install | bash

# Configuration
# ~/.config/opencode/config.yaml
model: ollama/llama3.1
default_agent: coder
```

### Oh My Opencode

A framework for extending Opencode with custom agents and workflows. Configuration uses a plugin system for adding capabilities like code review, documentation generation, and test writing.

### Hermes Agent

Hermes by Nous Research provides autonomous agent capabilities with tool use:

- **Skills system**: Modular capabilities that can be composed
- **Memory**: Persistent context across sessions
- **Tool use**: File operations, web search, code execution
- **Documentation**: https://hermes-agent.nousresearch.com/docs/skills/

### Pi Agent

Pi (personal intelligence) agents operate through the pi.dev package registry:

| Package | Purpose |
|---------|---------|
| `@juicesharp/rpiv-advisor` | AI advisor |
| `@juicesharp/rpiv-ask-user-question` | Interactive user queries |
| `@juicesharp/rpiv-todo` | Task management |
| `@a5c-ai/babysitter-pi` | Monitoring agent |
| `@plannotator/pi-extension` | Planning tools |
| `@nitra/cursor` | Cursor integration |

---

## Terminal Agent Layer

### Claude Code

Anthropic's terminal agent provides autonomous coding capabilities:

```bash
# Installation
npm install -g @anthropics/claude-code

# Usage
claude code "refactor this function to use async/await"
```

### Opencode Agent

The agent-mode of Opencode provides file-aware context and edit capabilities through natural language commands.

---

## IDE Agent Layer

### Cursor

Cursor is a VS Code fork with built-in AI agent capabilities, featuring:

- Tab-completion with full file context
- Agent mode for multi-file edits
- Codebase-wide search and understanding
- Model selection (GPT-4, Claude, local models)

### Codex

OpenAI's Codex provides chat-based coding assistance within supported IDEs.

---

## Redirect Layer

### LiteLLM

LiteLLM provides a unified API for multiple model providers:

```python
from litellm import completion

# Works with OpenAI, Anthropic, Ollama, vLLM, and 100+ providers
response = completion(
    model="ollama/llama3.1",
    messages=[{"role": "user", "content": "Hello"}]
)
```

### OpenRouter

OpenRouter provides a unified API endpoint for accessing models from multiple providers with a single API key.

---

## Model Serving Layer

| Engine | Backend | Quantization | Best For |
|--------|---------|-------------|----------|
| vLLM | PyTorch | GPTQ, AWQ, FP8, NVFP4 | High-throughput serving |
| AIStudio | Proprietary | Various | NVIDIA GPU optimization |
| Ollama | Go/llama.cpp | GGUF | Easy local deployment |
| llama.cpp | C/C++ | GGUF | CPU inference, edge devices |
| LM Studio | Desktop app | GGUF | GUI-based local inference |

### vLLM Configuration

```bash
# GPU installation (CUDA 12.1+)
pip install vllm

# With torch.compile optimization
vllm serve "meta-llama/Llama-3.1-8B-Instruct" \
    --compilation-config 3 \
    --tensor-parallel-size 1

# Multi-GPU
vllm serve "meta-llama/Llama-3.1-70B-Instruct" \
    --tensor-parallel-size 4
```

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

### NVIDIA Build

The NVIDIA AI platform provides model access and optimization tools:

- **NVIDIA NIM**: Optimized model containers for GPU inference
- **TensorRT-LLM**: High-performance inference engine
- **nvidia.ai**: Model catalog and API access

---

## Related Deep Hole

- [Hermes Agent Documentation](https://hermes-agent.nousresearch.com/docs/skills/) — Nous Research agent framework
- [Opencode Installation](https://github.com/code-yeongyu/oh-my-openagent/blob/dev/docs/guide/installation.md) — Oh My Opencode guide
- [pi.dev Packages](https://pi.dev/packages) — Pi agent registry
- [NVIDIA Build](https://build.nvidia.com/) — NVIDIA model platform
- [Local AI Wiki](https://github.com/useaitechdad/llm-wiki-and-gemma4-tests) — Community LLM testing
"""

let render() = file
