module ConvertedFiles.Source.Workbench.Cargo.ConfigToml

let file = """[target.wasm32-unknown-unknown]
rustflags = ["-C", "link-arg=-zstack-size=8388608"]
"""

let render() = file
