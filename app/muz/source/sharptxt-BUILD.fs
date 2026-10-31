module Muz.Source.BUILDTxt

let file = """Corresponding source for this build. From this directory: bun run dev --engine-dir ./upstream-muz
Engine dependencies are selected by engine/Cargo.lock. Runtime files are ../assets/.
"""

let render() = file
