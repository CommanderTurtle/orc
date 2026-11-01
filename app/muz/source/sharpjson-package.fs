module Muz.Source.PackageJson

let file = """{
  "name": "muzstatic",
  "private": true,
  "license": "AGPL-3.0-only",
  "type": "module",
  "scripts": {
    "build": "bun scripts/build.mjs",
    "dev": "bun scripts/build.mjs --serve",
    "start": "bun scripts/serve.mjs",
    "test": "bun test ./tests/",
    "muz": "bun toolkit/cli.js",
    "mcp": "bun toolkit/server.js"
  },
  "devDependencies": {
    "@codemirror/commands": "6.11.0",
    "@codemirror/language": "6.12.4",
    "@codemirror/search": "6.7.2",
    "@codemirror/state": "6.7.4",
    "@codemirror/view": "6.43.11",
    "@lezer/highlight": "1.2.3",
    "codemirror": "6.0.2",
    "dompurify": "3.4.17",
    "fflate": "0.8.3",
    "marked": "18.0.13",
    "vite": "8.3.5"
  }
}
"""

let render() = file
