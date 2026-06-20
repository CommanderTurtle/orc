module ConvertedFiles.Docs.Projects.MacrohardMd

let file = """# Macrohard

Macrohard is a visual workflow automation platform that extends Tasket++ with a ComfyUI-style node editor, IF/THEN/ELSE checkpoint branching, and a typed HTTP trigger daemon. It is a complete rewrite and extension of AmirHammouteneEI/ScheduledPasteAndKeys (tested against v1.8, June 2026), built in C++ and TypeScript with a React-based workflow editor.

My link on GitHub:

[CommanderTurtle/macrohard](https://github.com/CommanderTurtle/macrohard#macrohard--visual-workflow-automation-platform-for-tasket-inspired-by-comfyui){:rel="noopener noreferrer"}

---

## Overview

???+ note "What this page covers"
    Macrohard is a visual workflow automation platform extending Tasket++ with a ComfyUI-style node editor, IF/THEN/ELSE checkpoint branching, and a typed HTTP trigger daemon. Built in C++ and TypeScript with React. For the related AI agent stack, see [AI Agent Stack](../wikispace/ai-agent-stack.md). For the pi.dev package ecosystem, see [Modeling](../wikispace/modeling.md).

---

## Architecture

Macrohard consists of three integrated components that form a complete automation ecosystem:

```mermaid
flowchart TD
    subgraph "Macrohard"
        D["Daemon<br/>C++"]
        W["Workflows<br/>React"]
        P["PI Agent<br/>TypeScript"]
    end
    
    D -->|"HTTP triggers<br/>Type system<br/>Hot-reload"| W
    W -->|"Node editor<br/>IF/THEN/ELSE<br/>Visual graphs"| P
    P -->|"AI integration<br/>Skill system<br/>Task routing"| D
    
    D --> A["Windows API<br/>SendInput / Clipboard"]
    
    style D fill:#2d5a3a,color:#fff
    style W fill:#5a3a2d,color:#fff
    style P fill:#4a7c59,color:#fff
```

---

## Components

### Daemon (C++)

The daemon is the core runtime that executes workflows and manages system-level automation. Written in C++ for performance and native Windows API access.

| Feature | Implementation |
|---------|---------------|
| HTTP trigger server | Typed request handlers with schema validation |
| Task queue | Priority-based execution with dependency resolution |
| Hot-reload | Workflow updates without restart |
| Key injection | `SendInput` API for hardware-level automation |
| Clipboard | System clipboard monitoring and manipulation |
| Type system | Runtime type checking for workflow inputs/outputs |

```
daemon/
├── src/                # C++ source
├── include/            # Headers
├── CMakeLists.txt      # Build configuration
└── config/             # Runtime configuration
```

### Workflows (React)

The workflow editor provides a visual programming interface inspired by ComfyUI. Users construct automation flows by connecting nodes in a graph.

| Feature | Description |
|---------|-------------|
| Node editor | Drag-and-drop workflow construction |
| ComfyUI-style | Familiar interface for AI/ML users |
| IF/THEN/ELSE | Checkpoint branching for conditional logic |
| Visual graphs | Flow-based programming with real-time preview |
| Type safety | Ports are typed; only compatible types connect |

```
workflows/
├── src/                # React components
├── public/             # Static assets
├── package.json        # Dependencies
└── config/             # Build configuration
```

### PI Agent (TypeScript)

The PI Agent provides AI integration for intelligent automation. It connects to language models for context-aware task execution.

| Feature | Description |
|---------|-------------|
| AI integration | LLM context for decision-making |
| Skill system | Composable capabilities |
| Task routing | Intelligent delegation to appropriate handlers |
| Context memory | Persistent state across sessions |

```
pi-extension/
├── src/                # TypeScript source
├── skills/             # Skill definitions
├── config/             # Agent configuration
└── package.json        # Dependencies
```

---

## Workflow Concepts

### Nodes

Each node represents an atomic operation in the automation flow:

| Node Type | Purpose | Example |
|-----------|---------|---------|
| **Trigger** | Initiates workflow | HTTP request, hotkey, timer |
| **Action** | Performs operation | Send keystrokes, click, type text |
| **Condition** | Branching logic | IF clipboard contains "x" THEN ... |
| **Transform** | Data manipulation | String replace, regex, format |
| **Checkpoint** | Pause for user input | Confirmation dialog, form |
| **Output** | Result destination | Clipboard, file, HTTP response |

### IF/THEN/ELSE Checkpoints

Unlike traditional macro recorders that execute linearly, Macrohard supports conditional branching:

```
[Trigger: Hotkey Ctrl+Shift+V]
    |
    v
[Condition: Is clipboard image?]
    |--YES--> [Action: Save to screenshots folder]
    |              |
    |              v
    |          [Action: Copy file path to clipboard]
    |
    |--NO---> [Condition: Is clipboard URL?]
                   |--YES--> [Action: Open in browser]
                   |
                   |--NO---> [Action: Paste as plain text]
```

### Type System

Macrohard enforces type safety at connection points:

| Type | Description | Compatible With |
|------|-------------|-----------------|
| `String` | Text data | String, FilePath, URL |
| `Number` | Numeric value | Number, Coordinate |
| `Boolean` | True/false | Boolean |
| `Image` | Binary image data | Image, FilePath |
| `FilePath` | File system path | FilePath, String |
| `URL` | Web address | URL, String |
| `Coordinate` | Screen position | Coordinate, Number (pair) |

---

## Installation

```powershell
# Clone repository
git clone https://github.com/CommanderTurtle/macrohard.git
cd macrohard

# Install daemon (requires Visual Studio Build Tools)
./install.ps1

# Start daemon
./run.ps1

# Open workflow editor
# Navigate to http://localhost:3000
```

---

## PI Extension

The PI extension integrates with the pi.dev ecosystem:

| Package | Purpose |
|---------|---------|
| `@juicesharp/rpiv-advisor` | AI advisor for workflow construction |
| `@juicesharp/rpiv-ask-user-question` | Interactive user prompts |
| `@juicesharp/rpiv-todo` | Task management within workflows |
| `@a5c-ai/babysitter-pi` | Monitoring and alerting |
| `@plannotator/pi-extension` | Planning and scheduling |
| `@nitra/cursor` | Cursor control integration |

---

## Related Deep Hole

- [Macrohard GitHub Repository](https://github.com/CommanderTurtle/macrohard) — Source code and documentation
- [Tasket++](https://github.com/AmirHammouteneEI/ScheduledPasteAndKeys) — Base extension (v1.8)
- [ComfyUI](https://github.com/comfyanonymous/ComfyUI) — Visual node editor inspiration
- [pi.dev Packages](https://pi.dev/packages) — PI agent registry
"""

let render() = file
