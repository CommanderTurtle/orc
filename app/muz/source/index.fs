module Muz.Source.IndexHtml

open Giraffe.ViewEngine

let page =
    html [] [
        head [] []
        body [] [
            meta [ attr "charset" "utf-8" ]
            title [] [
                str "muzstatic source"
            ]
            style [] [ rawText ("""body{font:14px monospace;max-width:1000px;margin:40px auto;background:#101419;color:#d4dce5}a{color:#89d6b4}li{margin:6px}""") ]
            h1 [] [
                str "muzstatic source"
            ]
            p [] [
                str "Exact frontend and selected muz source for this build."
                a [ _href "BUILD.txt" ] [
                    str "Build instructions"
                ]
            ]
            ul [] [
                li [] [
                    a [ _href "engine/src/lib.rs" ] [
                        str "engine/src/lib.rs"
                    ]
                ]
                li [] [
                    a [ _href "engine/Cargo.toml" ] [
                        str "engine/Cargo.toml"
                    ]
                ]
                li [] [
                    a [ _href "engine/Cargo.lock" ] [
                        str "engine/Cargo.lock"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/vendor/licenses/pako-NOTICE.txt" ] [
                        str "src/vendor/lnkr/vendor/licenses/pako-NOTICE.txt"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/vendor/pako.esm.min.js" ] [
                        str "src/vendor/lnkr/vendor/pako.esm.min.js"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/LICENSE" ] [
                        str "src/vendor/lnkr/LICENSE"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/alphabets.js" ] [
                        str "src/vendor/lnkr/alphabets.js"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/compress.js" ] [
                        str "src/vendor/lnkr/compress.js"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/link-runtime.js" ] [
                        str "src/vendor/lnkr/link-runtime.js"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/make-resource.js" ] [
                        str "src/vendor/lnkr/make-resource.js"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/payload.js" ] [
                        str "src/vendor/lnkr/payload.js"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/text-compress.js" ] [
                        str "src/vendor/lnkr/text-compress.js"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/upstream.json" ] [
                        str "src/vendor/lnkr/upstream.json"
                    ]
                ]
                li [] [
                    a [ _href "src/vendor/lnkr/viewer-runtime.js" ] [
                        str "src/vendor/lnkr/viewer-runtime.js"
                    ]
                ]
                li [] [
                    a [ _href "src/app.js" ] [
                        str "src/app.js"
                    ]
                ]
                li [] [
                    a [ _href "src/data-worker.js" ] [
                        str "src/data-worker.js"
                    ]
                ]
                li [] [
                    a [ _href "src/engine-worker.js" ] [
                        str "src/engine-worker.js"
                    ]
                ]
                li [] [
                    a [ _href "src/index.html" ] [
                        str "src/index.html"
                    ]
                ]
                li [] [
                    a [ _href "src/links.js" ] [
                        str "src/links.js"
                    ]
                ]
                li [] [
                    a [ _href "src/player-worklet.js" ] [
                        str "src/player-worklet.js"
                    ]
                ]
                li [] [
                    a [ _href "src/project.js" ] [
                        str "src/project.js"
                    ]
                ]
                li [] [
                    a [ _href "src/style.css" ] [
                        str "src/style.css"
                    ]
                ]
                li [] [
                    a [ _href "scripts/build.mjs" ] [
                        str "scripts/build.mjs"
                    ]
                ]
                li [] [
                    a [ _href "scripts/serve.mjs" ] [
                        str "scripts/serve.mjs"
                    ]
                ]
                li [] [
                    a [ _href "tests/analysis.test.js" ] [
                        str "tests/analysis.test.js"
                    ]
                ]
                li [] [
                    a [ _href "tests/colorful.test.js" ] [
                        str "tests/colorful.test.js"
                    ]
                ]
                li [] [
                    a [ _href "tests/engine.test.js" ] [
                        str "tests/engine.test.js"
                    ]
                ]
                li [] [
                    a [ _href "tests/links.test.js" ] [
                        str "tests/links.test.js"
                    ]
                ]
                li [] [
                    a [ _href "tests/project.test.js" ] [
                        str "tests/project.test.js"
                    ]
                ]
                li [] [
                    a [ _href "tests/toolkit-engine.test.js" ] [
                        str "tests/toolkit-engine.test.js"
                    ]
                ]
                li [] [
                    a [ _href "tests/toolkit.test.js" ] [
                        str "tests/toolkit.test.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/analysis.js" ] [
                        str "toolkit/analysis.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/cli.js" ] [
                        str "toolkit/cli.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/colorful.js" ] [
                        str "toolkit/colorful.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/png.js" ] [
                        str "toolkit/png.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/runner.js" ] [
                        str "toolkit/runner.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/schema.js" ] [
                        str "toolkit/schema.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/server.js" ] [
                        str "toolkit/server.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/service.js" ] [
                        str "toolkit/service.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/time.js" ] [
                        str "toolkit/time.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/wasm.js" ] [
                        str "toolkit/wasm.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/worker.js" ] [
                        str "toolkit/worker.js"
                    ]
                ]
                li [] [
                    a [ _href "toolkit/workspace.js" ] [
                        str "toolkit/workspace.js"
                    ]
                ]
                li [] [
                    a [ _href "skills/muz-compose/agents/openai.yaml" ] [
                        str "skills/muz-compose/agents/openai.yaml"
                    ]
                ]
                li [] [
                    a [ _href "skills/muz-compose/SKILL.md" ] [
                        str "skills/muz-compose/SKILL.md"
                    ]
                ]
                li [] [
                    a [ _href "docs/analysis.md" ] [
                        str "docs/analysis.md"
                    ]
                ]
                li [] [
                    a [ _href "docs/colorful.md" ] [
                        str "docs/colorful.md"
                    ]
                ]
                li [] [
                    a [ _href "docs/toolkit.md" ] [
                        str "docs/toolkit.md"
                    ]
                ]
                li [] [
                    a [ _href "examples/starter/intent.json" ] [
                        str "examples/starter/intent.json"
                    ]
                ]
                li [] [
                    a [ _href "examples/starter/math.muz" ] [
                        str "examples/starter/math.muz"
                    ]
                ]
                li [] [
                    a [ _href "examples/starter/plan.md" ] [
                        str "examples/starter/plan.md"
                    ]
                ]
                li [] [
                    a [ _href "examples/starter/song.muz" ] [
                        str "examples/starter/song.muz"
                    ]
                ]
                li [] [
                    a [ _href ".gitignore" ] [
                        str ".gitignore"
                    ]
                ]
                li [] [
                    a [ _href ".gitattributes" ] [
                        str ".gitattributes"
                    ]
                ]
                li [] [
                    a [ _href "package.json" ] [
                        str "package.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream.json" ] [
                        str "upstream.json"
                    ]
                ]
                li [] [
                    a [ _href "README.md" ] [
                        str "README.md"
                    ]
                ]
                li [] [
                    a [ _href "LICENSE" ] [
                        str "LICENSE"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/Cargo.toml" ] [
                        str "upstream-muz/Cargo.toml"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/analysis.rs" ] [
                        str "upstream-muz/src/analysis.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/assets.rs" ] [
                        str "upstream-muz/src/assets.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/automation.rs" ] [
                        str "upstream-muz/src/audio/automation.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/clap.rs" ] [
                        str "upstream-muz/src/audio/clap.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/advanced.rs" ] [
                        str "upstream-muz/src/audio/device/advanced.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/bitcrusher.rs" ] [
                        str "upstream-muz/src/audio/device/bitcrusher.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/patch.rs" ] [
                        str "upstream-muz/src/audio/device/patch.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/patch_envelope.rs" ] [
                        str "upstream-muz/src/audio/device/patch_envelope.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/patch_sample.rs" ] [
                        str "upstream-muz/src/audio/device/patch_sample.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/patch_shape.rs" ] [
                        str "upstream-muz/src/audio/device/patch_shape.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/rack.rs" ] [
                        str "upstream-muz/src/audio/device/rack.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/sampler.rs" ] [
                        str "upstream-muz/src/audio/device/sampler.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/sfz.rs" ] [
                        str "upstream-muz/src/audio/device/sfz.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/sfz_dsp.rs" ] [
                        str "upstream-muz/src/audio/device/sfz_dsp.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device/studio.rs" ] [
                        str "upstream-muz/src/audio/device/studio.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/device.rs" ] [
                        str "upstream-muz/src/audio/device.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/engine.rs" ] [
                        str "upstream-muz/src/audio/engine.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/mod.rs" ] [
                        str "upstream-muz/src/audio/mod.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/observation.rs" ] [
                        str "upstream-muz/src/audio/observation.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/pipewire.rs" ] [
                        str "upstream-muz/src/audio/pipewire.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/transaction.rs" ] [
                        str "upstream-muz/src/audio/transaction.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/transport.rs" ] [
                        str "upstream-muz/src/audio/transport.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/vst3.rs" ] [
                        str "upstream-muz/src/audio/vst3.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio/vst3_state.rs" ] [
                        str "upstream-muz/src/audio/vst3_state.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/audio_file.rs" ] [
                        str "upstream-muz/src/audio_file.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/bin/sfz-audit.rs" ] [
                        str "upstream-muz/src/bin/sfz-audit.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/compile.rs" ] [
                        str "upstream-muz/src/compile.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/control.rs" ] [
                        str "upstream-muz/src/control.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/dawproject/mod.rs" ] [
                        str "upstream-muz/src/dawproject/mod.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/description.rs" ] [
                        str "upstream-muz/src/description.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/device_state.rs" ] [
                        str "upstream-muz/src/device_state.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/diagnostic.rs" ] [
                        str "upstream-muz/src/diagnostic.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/expression.rs" ] [
                        str "upstream-muz/src/expression.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/host.rs" ] [
                        str "upstream-muz/src/host.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/inspect.rs" ] [
                        str "upstream-muz/src/inspect.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/lang/builtins.rs" ] [
                        str "upstream-muz/src/lang/builtins.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/lang/controls.rs" ] [
                        str "upstream-muz/src/lang/controls.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/lang/diagnostic.rs" ] [
                        str "upstream-muz/src/lang/diagnostic.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/lang/eval.rs" ] [
                        str "upstream-muz/src/lang/eval.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/lang/format.rs" ] [
                        str "upstream-muz/src/lang/format.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/lang/loader.rs" ] [
                        str "upstream-muz/src/lang/loader.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/lang/mod.rs" ] [
                        str "upstream-muz/src/lang/mod.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/lang/parser.rs" ] [
                        str "upstream-muz/src/lang/parser.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/lib.rs" ] [
                        str "upstream-muz/src/lib.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/limits.rs" ] [
                        str "upstream-muz/src/limits.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/live.rs" ] [
                        str "upstream-muz/src/live.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/main.rs" ] [
                        str "upstream-muz/src/main.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/midi.rs" ] [
                        str "upstream-muz/src/midi.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/model.rs" ] [
                        str "upstream-muz/src/model.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/music.rs" ] [
                        str "upstream-muz/src/music.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/native.rs" ] [
                        str "upstream-muz/src/native.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/native_tests.rs" ] [
                        str "upstream-muz/src/native_tests.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/native_test_plugin.rs" ] [
                        str "upstream-muz/src/native_test_plugin.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/patch_description.rs" ] [
                        str "upstream-muz/src/patch_description.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/patch_source.rs" ] [
                        str "upstream-muz/src/patch_source.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/performance.rs" ] [
                        str "upstream-muz/src/performance.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/plugins.rs" ] [
                        str "upstream-muz/src/plugins.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/provenance.rs" ] [
                        str "upstream-muz/src/provenance.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/recipes.rs" ] [
                        str "upstream-muz/src/recipes.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/reconcile.rs" ] [
                        str "upstream-muz/src/reconcile.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/render.rs" ] [
                        str "upstream-muz/src/render.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/sfz/mod.rs" ] [
                        str "upstream-muz/src/sfz/mod.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/sfz/opcodes.rs" ] [
                        str "upstream-muz/src/sfz/opcodes.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/smf.rs" ] [
                        str "upstream-muz/src/smf.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/snapshot.rs" ] [
                        str "upstream-muz/src/snapshot.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/source/locations.rs" ] [
                        str "upstream-muz/src/source/locations.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/source.rs" ] [
                        str "upstream-muz/src/source.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/tonal.rs" ] [
                        str "upstream-muz/src/tonal.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/watch.rs" ] [
                        str "upstream-muz/src/watch.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/src/worker.rs" ] [
                        str "upstream-muz/src/worker.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/arrange.muz" ] [
                        str "upstream-muz/std/arrange.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/catalogs.muz" ] [
                        str "upstream-muz/std/catalogs.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/grooves.muz" ] [
                        str "upstream-muz/std/grooves.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/instrument.muz" ] [
                        str "upstream-muz/std/instrument.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/mix.muz" ] [
                        str "upstream-muz/std/mix.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/music.muz" ] [
                        str "upstream-muz/std/music.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/patterns.muz" ] [
                        str "upstream-muz/std/patterns.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/performance.muz" ] [
                        str "upstream-muz/std/performance.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/piano.muz" ] [
                        str "upstream-muz/std/piano.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/prelude.muz" ] [
                        str "upstream-muz/std/prelude.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/sampler.muz" ] [
                        str "upstream-muz/std/sampler.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/signal.muz" ] [
                        str "upstream-muz/std/signal.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/synthesis.muz" ] [
                        str "upstream-muz/std/synthesis.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/std/tonal.muz" ] [
                        str "upstream-muz/std/tonal.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/templates/song.muz" ] [
                        str "upstream-muz/templates/song.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/crates/muz-clap/Cargo.toml" ] [
                        str "upstream-muz/crates/muz-clap/Cargo.toml"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/crates/muz-clap/src/lib.rs" ] [
                        str "upstream-muz/crates/muz-clap/src/lib.rs"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/language.md" ] [
                        str "upstream-muz/docs/language.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/workflow.md" ] [
                        str "upstream-muz/docs/workflow.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/performance.md" ] [
                        str "upstream-muz/docs/performance.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/embedding.md" ] [
                        str "upstream-muz/docs/embedding.md"
                    ]
                ]
                li [] [
                    a [ _href "BUILD.txt" ] [
                        str "BUILD.txt"
                    ]
                ]
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
