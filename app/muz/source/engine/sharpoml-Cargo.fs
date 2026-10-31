module Muz.Source.Engine.CargoToml

let file = """[package]
name = "muzstatic-engine"
version = "0.1.0"
edition = "2024"

[lib]
crate-type = ["cdylib", "rlib"]

[dependencies]
muz = { path = "../.cache/muz", default-features = false }
anyhow = "1.0"
serde = { version = "1.0", features = ["derive"] }
serde_json = "1.0"
base64 = "0.22"

[profile.release]
opt-level = "s"
lto = true
strip = true
panic = "abort"
"""

let render() = file
