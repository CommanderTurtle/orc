module Muz.Source.Workbench.CargoToml

let file = """[workspace]
members = ["wasm"]
resolver = "2"

[profile.release]
lto = true
codegen-units = 1
panic = "abort"
"""

let render() = file
