module Muz.Source.UpstreamMuz.Std.PreludeMuz

let file = """// Add source policy here without maintaining a Rust function-name registry.
use "std/performance" as performance;
use "std/catalogs" as catalogs;
use "std/patterns" as patterns;
merge(performance, catalogs, patterns)
"""

let render() = file
