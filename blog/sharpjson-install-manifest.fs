module ConvertedFiles.InstallManifestJson

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
