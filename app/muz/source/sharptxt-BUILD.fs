module Muz.Source.BUILDTxt

let file = """Corresponding source for this build. From this directory: bun install, then bun run dev --engine-dir ./upstream-muz
Engine dependencies are selected by engine/Cargo.lock. Frontend dependencies are selected by bun.lock. Runtime files are ../assets/ and ../workbench/.
"""

let render() = file
