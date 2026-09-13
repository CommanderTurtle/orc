module Bl0g.InstallManifestJson

let file = """{
  "schema": 1,
  "suite": "sHEL",
  "defaultProjectsDirectory": "Projects",
  "repositories": {
    "diogenes": {
      "url": "https://github.com/CommanderTurtle/diogenes.git",
      "branch": "dev"
    },
    "orc": {
      "url": "https://github.com/CommanderTurtle/orc.git",
      "branch": "clonable",
      "overlayBranch": "main"
    },
    "reactor": {
      "url": "https://github.com/CommanderTurtle/reactor.git",
      "branch": "main"
    },
    "preview": {
      "url": "https://github.com/CommanderTurtle/preview.git",
      "branch": "main"
    },
    "tools": {
      "url": "https://github.com/CommanderTurtle/tools.git",
      "branch": "main"
    },
    "regedited": {
      "url": "https://github.com/CommanderTurtle/regedited.git",
      "branch": "main"
    },
    "macrohard": {
      "url": "https://github.com/CommanderTurtle/macrohard.git",
      "branch": "main"
    },
    "sandwich": {
      "url": "https://github.com/CommanderTurtle/sandwich.git",
      "branch": "main"
    },
    "mmTools": {
      "url": "https://github.com/CommanderTurtle/mm-tools.git",
      "branch": "main"
    },
    "localflame": {
      "url": "https://github.com/CommanderTurtle/localflame.git",
      "branch": "master"
    },
    "ninfer": {
      "url": "https://github.com/Neroued/ninfer.git",
      "branch": "master"
    },
    "camofoxMcp": {
      "url": "https://github.com/CommanderTurtle/archive--camofox-mcp.git",
      "branch": "main"
    },
    "camofoxBrowser": {
      "url": "https://github.com/CommanderTurtle/archive--camofox-browser.git",
      "branch": "master"
    },
    "firecrawl": {
      "url": "https://github.com/firecrawl/firecrawl.git",
      "branch": "main"
    },
    "contextMode": {
      "url": "https://github.com/CommanderTurtle/context-mode.git",
      "branch": "main"
    },
    "hermesWorkspace": {
      "url": "https://github.com/CommanderTurtle/archive--hermes-workspace.git",
      "branch": "main"
    },
    "leetcoder": {
      "url": "https://github.com/CommanderTurtle/leetcoder.git",
      "branch": "main"
    },
    "librarian": {
      "url": "https://github.com/CommanderTurtle/librarian.git",
      "branch": "main"
    },
    "persephone": {
      "url": "https://github.com/CommanderTurtle/persephone.git",
      "branch": "main"
    },
    "retrieval": {
      "url": "https://github.com/CommanderTurtle/retrieval.git",
      "branch": "main"
    },
    "codebaseMemory": {
      "url": "https://github.com/DeusData/codebase-memory-mcp.git",
      "branch": "main"
    },
    "minima": {
      "url": "https://github.com/jekyll/minima.git",
      "branch": "master"
    },
    "zensicalDocs": {
      "url": "https://github.com/zensical/docs.git",
      "branch": "master"
    },
    "openclawSite": {
      "url": "https://github.com/openclaw/openclaw.ai.git",
      "branch": "main"
    },
    "vllmMinima": {
      "url": "https://github.com/vllm-project/vllm-project.github.io-static.git",
      "branch": "main"
    }
  },
  "siteFrameworks": [
    {
      "id": "static",
      "label": "Static HTML",
      "description": "Minimal index.html rendered from F# source."
    },
    {
      "id": "zensical",
      "label": "Zensical",
      "description": "Documentation site managed with uv."
    },
    {
      "id": "jekyll",
      "label": "Jekyll",
      "description": "GitHub Pages-compatible Ruby site."
    },
    {
      "id": "vite",
      "label": "Vite",
      "description": "Bun-powered Vite application."
    },
    {
      "id": "netdocs",
      "label": "Netdocs",
      "description": "Native .NET documentation site."
    }
  ]
}"""

let render() = file
