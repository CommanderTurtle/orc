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
  }
}
"""

let render() = file
