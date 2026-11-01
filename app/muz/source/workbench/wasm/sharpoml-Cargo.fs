module Muz.Source.Workbench.Wasm.CargoToml

let file = """[package]
name = "muzpad-wasm"
version = "0.1.0"
edition = "2024"

[lib]
crate-type = ["cdylib", "rlib"]

[dependencies]
muz = { path = "../../muz", default-features = false }
anyhow = "1"
serde = { version = "1", features = ["derive"] }
serde_json = "1"
"""

let render() = file
