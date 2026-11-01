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
                    a [ _href "src/app.js" ] [
                        str "src/app.js"
                    ]
                ]
                li [] [
                    a [ _href "src/catalog.js" ] [
                        str "src/catalog.js"
                    ]
                ]
                li [] [
                    a [ _href "src/code-editor.js" ] [
                        str "src/code-editor.js"
                    ]
                ]
                li [] [
                    a [ _href "src/data-worker.js" ] [
                        str "src/data-worker.js"
                    ]
                ]
                li [] [
                    a [ _href "src/dawproject.js" ] [
                        str "src/dawproject.js"
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
                    a [ _href "src/project-transfer.js" ] [
                        str "src/project-transfer.js"
                    ]
                ]
                li [] [
                    a [ _href "src/project.js" ] [
                        str "src/project.js"
                    ]
                ]
                li [] [
                    a [ _href "src/studio-source.js" ] [
                        str "src/studio-source.js"
                    ]
                ]
                li [] [
                    a [ _href "src/studio-view.js" ] [
                        str "src/studio-view.js"
                    ]
                ]
                li [] [
                    a [ _href "src/studio.css" ] [
                        str "src/studio.css"
                    ]
                ]
                li [] [
                    a [ _href "src/style.css" ] [
                        str "src/style.css"
                    ]
                ]
                li [] [
                    a [ _href "src/timeline.js" ] [
                        str "src/timeline.js"
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
                    a [ _href "src/vendor/lnkr/LICENSE" ] [
                        str "src/vendor/lnkr/LICENSE"
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
                    a [ _href "src/vendor/lnkr/viewer-runtime.js" ] [
                        str "src/vendor/lnkr/viewer-runtime.js"
                    ]
                ]
                li [] [
                    a [ _href "src/workbench-bridge.js" ] [
                        str "src/workbench-bridge.js"
                    ]
                ]
                li [] [
                    a [ _href "src/workbench-project.js" ] [
                        str "src/workbench-project.js"
                    ]
                ]
                li [] [
                    a [ _href "src/zip.js" ] [
                        str "src/zip.js"
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
                    a [ _href "scripts/workbench.mjs" ] [
                        str "scripts/workbench.mjs"
                    ]
                ]
                li [] [
                    a [ _href "tests/analysis.test.js" ] [
                        str "tests/analysis.test.js"
                    ]
                ]
                li [] [
                    a [ _href "tests/catalog-export.test.js" ] [
                        str "tests/catalog-export.test.js"
                    ]
                ]
                li [] [
                    a [ _href "tests/colorful.test.js" ] [
                        str "tests/colorful.test.js"
                    ]
                ]
                li [] [
                    a [ _href "tests/editor.test.js" ] [
                        str "tests/editor.test.js"
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
                    a [ _href "tests/studio.test.js" ] [
                        str "tests/studio.test.js"
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
                    a [ _href "tests/workbench.test.js" ] [
                        str "tests/workbench.test.js"
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
                    a [ _href "bun.lock" ] [
                        str "bun.lock"
                    ]
                ]
                li [] [
                    a [ _href "upstream.json" ] [
                        str "upstream.json"
                    ]
                ]
                li [] [
                    a [ _href "workbench.json" ] [
                        str "workbench.json"
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
                    a [ _href "upstream-muz/README.md" ] [
                        str "upstream-muz/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/composer-friction.md" ] [
                        str "upstream-muz/docs/composer-friction.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/dawproject-validation.md" ] [
                        str "upstream-muz/docs/dawproject-validation.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/dawproject.md" ] [
                        str "upstream-muz/docs/dawproject.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/embedding.md" ] [
                        str "upstream-muz/docs/embedding.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/getting-started.md" ] [
                        str "upstream-muz/docs/getting-started.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/instruments.md" ] [
                        str "upstream-muz/docs/instruments.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/language.md" ] [
                        str "upstream-muz/docs/language.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/performance.md" ] [
                        str "upstream-muz/docs/performance.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/production.md" ] [
                        str "upstream-muz/docs/production.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/README.md" ] [
                        str "upstream-muz/docs/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/sfz-performance.md" ] [
                        str "upstream-muz/docs/sfz-performance.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/sfz-reference-evidence.json" ] [
                        str "upstream-muz/docs/sfz-reference-evidence.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/sfz-reference.md" ] [
                        str "upstream-muz/docs/sfz-reference.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/sfz-state-qualification.md" ] [
                        str "upstream-muz/docs/sfz-state-qualification.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/sfz.md" ] [
                        str "upstream-muz/docs/sfz.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/synthesis.md" ] [
                        str "upstream-muz/docs/synthesis.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/docs/workflow.md" ] [
                        str "upstream-muz/docs/workflow.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/envelope-timing.muz" ] [
                        str "upstream-muz/examples/envelope-timing.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/instrument-design.muz" ] [
                        str "upstream-muz/examples/instrument-design.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/midi-messages.muz" ] [
                        str "upstream-muz/examples/midi-messages.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/modulated-lead.muz" ] [
                        str "upstream-muz/examples/modulated-lead.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/nested-patch.muz" ] [
                        str "upstream-muz/examples/nested-patch.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/percussion-patches.muz" ] [
                        str "upstream-muz/examples/percussion-patches.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/preset-expression.muz" ] [
                        str "upstream-muz/examples/preset-expression.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/racks.muz" ] [
                        str "upstream-muz/examples/racks.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/revision-workflow.muz" ] [
                        str "upstream-muz/examples/revision-workflow.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/sidechain-levels.muz" ] [
                        str "upstream-muz/examples/sidechain-levels.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/stereo-body.muz" ] [
                        str "upstream-muz/examples/stereo-body.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/tagged-send.muz" ] [
                        str "upstream-muz/examples/tagged-send.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/tonal-assistance.muz" ] [
                        str "upstream-muz/examples/tonal-assistance.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/examples/voice-expression.muz" ] [
                        str "upstream-muz/examples/voice-expression.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/audit-sfz.py" ] [
                        str "upstream-muz/contrib/audit-sfz.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/install-sfz.py" ] [
                        str "upstream-muz/contrib/install-sfz.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/basses.muz" ] [
                        str "upstream-muz/contrib/karoryfer/basses.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/guitar.muz" ] [
                        str "upstream-muz/contrib/karoryfer/guitar.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/install.py" ] [
                        str "upstream-muz/contrib/karoryfer/install.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/manifest.json" ] [
                        str "upstream-muz/contrib/karoryfer/manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/performance.muz" ] [
                        str "upstream-muz/contrib/karoryfer/performance.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/README.md" ] [
                        str "upstream-muz/contrib/karoryfer/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/sfz-audit.json" ] [
                        str "upstream-muz/contrib/karoryfer/sfz-audit.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/sfz-catalog.json" ] [
                        str "upstream-muz/contrib/karoryfer/sfz-catalog.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/sfz-manifest.json" ] [
                        str "upstream-muz/contrib/karoryfer/sfz-manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/karoryfer/sfz.muz" ] [
                        str "upstream-muz/contrib/karoryfer/sfz.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/chowtape.muz" ] [
                        str "upstream-muz/contrib/plugins/chowtape.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/juce_state.py" ] [
                        str "upstream-muz/contrib/plugins/juce_state.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/orbitcab-install.py" ] [
                        str "upstream-muz/contrib/plugins/orbitcab-install.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/orbitcab-manifest.json" ] [
                        str "upstream-muz/contrib/plugins/orbitcab-manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/orbitcab.muz" ] [
                        str "upstream-muz/contrib/plugins/orbitcab.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/pianoteq-state.py" ] [
                        str "upstream-muz/contrib/plugins/pianoteq-state.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/pianoteq.muz" ] [
                        str "upstream-muz/contrib/plugins/pianoteq.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/README.md" ] [
                        str "upstream-muz/contrib/plugins/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/surge-xt.muz" ] [
                        str "upstream-muz/contrib/plugins/surge-xt.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/plugins/test-pianoteq-state.py" ] [
                        str "upstream-muz/contrib/plugins/test-pianoteq-state.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/README.md" ] [
                        str "upstream-muz/contrib/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sfz-performance-baseline.json" ] [
                        str "upstream-muz/contrib/sfz-performance-baseline.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sfz-state-qualification.json" ] [
                        str "upstream-muz/contrib/sfz-state-qualification.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/SFZ.md" ] [
                        str "upstream-muz/contrib/SFZ.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/catalog.json" ] [
                        str "upstream-muz/contrib/sonatina/catalog.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/CATALOG.md" ] [
                        str "upstream-muz/contrib/sonatina/CATALOG.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/export-catalog.py" ] [
                        str "upstream-muz/contrib/sonatina/export-catalog.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/install.py" ] [
                        str "upstream-muz/contrib/sonatina/install.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/make-state.py" ] [
                        str "upstream-muz/contrib/sonatina/make-state.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/manifest.json" ] [
                        str "upstream-muz/contrib/sonatina/manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/plugin.muz" ] [
                        str "upstream-muz/contrib/sonatina/plugin.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/README.md" ] [
                        str "upstream-muz/contrib/sonatina/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/sfz-audit.json" ] [
                        str "upstream-muz/contrib/sonatina/sfz-audit.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/sfz-catalog.json" ] [
                        str "upstream-muz/contrib/sonatina/sfz-catalog.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/sfz.muz" ] [
                        str "upstream-muz/contrib/sonatina/sfz.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/sonatina/test-pack.py" ] [
                        str "upstream-muz/contrib/sonatina/test-pack.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/test-install-sfz.py" ] [
                        str "upstream-muz/contrib/test-install-sfz.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/derive.py" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/derive.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/install.py" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/install.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/manifest.json" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/metal-gtx.muz" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/metal-gtx.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/performance.muz" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/performance.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/README.md" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/sfz-audit.json" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/sfz-audit.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/sfz-catalog.json" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/sfz-catalog.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/sfz-manifest.json" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/sfz-manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/metal-gtx/sfz.muz" ] [
                        str "upstream-muz/contrib/unreal/metal-gtx/sfz.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/standard-guitar/install.py" ] [
                        str "upstream-muz/contrib/unreal/standard-guitar/install.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/standard-guitar/manifest.json" ] [
                        str "upstream-muz/contrib/unreal/standard-guitar/manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/standard-guitar/README.md" ] [
                        str "upstream-muz/contrib/unreal/standard-guitar/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/standard-guitar/sfz-audit.json" ] [
                        str "upstream-muz/contrib/unreal/standard-guitar/sfz-audit.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/standard-guitar/sfz-catalog.json" ] [
                        str "upstream-muz/contrib/unreal/standard-guitar/sfz-catalog.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/standard-guitar/sfz-manifest.json" ] [
                        str "upstream-muz/contrib/unreal/standard-guitar/sfz-manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/standard-guitar/sfz.muz" ] [
                        str "upstream-muz/contrib/unreal/standard-guitar/sfz.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/unreal/standard-guitar/standard-guitar.muz" ] [
                        str "upstream-muz/contrib/unreal/standard-guitar/standard-guitar.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/virtuosity-drums/install.py" ] [
                        str "upstream-muz/contrib/virtuosity-drums/install.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/virtuosity-drums/kit.muz" ] [
                        str "upstream-muz/contrib/virtuosity-drums/kit.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/virtuosity-drums/manifest.json" ] [
                        str "upstream-muz/contrib/virtuosity-drums/manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/virtuosity-drums/README.md" ] [
                        str "upstream-muz/contrib/virtuosity-drums/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/virtuosity-drums/sfz-audit.json" ] [
                        str "upstream-muz/contrib/virtuosity-drums/sfz-audit.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/virtuosity-drums/sfz-catalog.json" ] [
                        str "upstream-muz/contrib/virtuosity-drums/sfz-catalog.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/virtuosity-drums/sfz-manifest.json" ] [
                        str "upstream-muz/contrib/virtuosity-drums/sfz-manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/virtuosity-drums/sfz.muz" ] [
                        str "upstream-muz/contrib/virtuosity-drums/sfz.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/alternates.muz" ] [
                        str "upstream-muz/contrib/vsco-2-ce/alternates.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/calibrate.py" ] [
                        str "upstream-muz/contrib/vsco-2-ce/calibrate.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/calibrated.muz" ] [
                        str "upstream-muz/contrib/vsco-2-ce/calibrated.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/calibration-gains.muz" ] [
                        str "upstream-muz/contrib/vsco-2-ce/calibration-gains.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/calibration.json" ] [
                        str "upstream-muz/contrib/vsco-2-ce/calibration.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/expanded.muz" ] [
                        str "upstream-muz/contrib/vsco-2-ce/expanded.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/export-calibration.py" ] [
                        str "upstream-muz/contrib/vsco-2-ce/export-calibration.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/expressive.muz" ] [
                        str "upstream-muz/contrib/vsco-2-ce/expressive.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/extra.muz" ] [
                        str "upstream-muz/contrib/vsco-2-ce/extra.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/install.py" ] [
                        str "upstream-muz/contrib/vsco-2-ce/install.py"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/manifest.json" ] [
                        str "upstream-muz/contrib/vsco-2-ce/manifest.json"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/README.md" ] [
                        str "upstream-muz/contrib/vsco-2-ce/README.md"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/shorts.muz" ] [
                        str "upstream-muz/contrib/vsco-2-ce/shorts.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/strings.muz" ] [
                        str "upstream-muz/contrib/vsco-2-ce/strings.muz"
                    ]
                ]
                li [] [
                    a [ _href "upstream-muz/contrib/vsco-2-ce/winds.muz" ] [
                        str "upstream-muz/contrib/vsco-2-ce/winds.muz"
                    ]
                ]
                li [] [
                    a [ _href "BUILD.txt" ] [
                        str "BUILD.txt"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/analysis-layout.ts" ] [
                        str "workbench/src/analysis-layout.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/arrangement-layout.ts" ] [
                        str "workbench/src/arrangement-layout.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/assets.js" ] [
                        str "workbench/src/assets.js"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/audio.ts" ] [
                        str "workbench/src/audio.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/audition.ts" ] [
                        str "workbench/src/audition.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/compiler.worker.ts" ] [
                        str "workbench/src/compiler.worker.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/document.ts" ] [
                        str "workbench/src/document.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/editor.ts" ] [
                        str "workbench/src/editor.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/engine.js" ] [
                        str "workbench/src/engine.js"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/export-audio.js" ] [
                        str "workbench/src/export-audio.js"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/export.ts" ] [
                        str "workbench/src/export.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/export.worker.ts" ] [
                        str "workbench/src/export.worker.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/folder.ts" ] [
                        str "workbench/src/folder.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/gist.js" ] [
                        str "workbench/src/gist.js"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/host/contracts.ts" ] [
                        str "workbench/src/host/contracts.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/host/desktop.ts" ] [
                        str "workbench/src/host/desktop.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/host/index.ts" ] [
                        str "workbench/src/host/index.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/host/web-preferences.ts" ] [
                        str "workbench/src/host/web-preferences.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/host/web-projects.ts" ] [
                        str "workbench/src/host/web-projects.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/host/web.ts" ] [
                        str "workbench/src/host/web.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/inspection.ts" ] [
                        str "workbench/src/inspection.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/main.ts" ] [
                        str "workbench/src/main.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/pan.ts" ] [
                        str "workbench/src/pan.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/preferences.ts" ] [
                        str "workbench/src/preferences.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/project-storage.js" ] [
                        str "workbench/src/project-storage.js"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/render.worker.ts" ] [
                        str "workbench/src/render.worker.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/style.css" ] [
                        str "workbench/src/style.css"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/theme.ts" ] [
                        str "workbench/src/theme.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/views.ts" ] [
                        str "workbench/src/views.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/workbench-status.ts" ] [
                        str "workbench/src/workbench-status.ts"
                    ]
                ]
                li [] [
                    a [ _href "workbench/src/muzstatic-bridge.js" ] [
                        str "workbench/src/muzstatic-bridge.js"
                    ]
                ]
                li [] [
                    a [ _href "workbench/public/player-worklet.js" ] [
                        str "workbench/public/player-worklet.js"
                    ]
                ]
                li [] [
                    a [ _href "workbench/wasm/Cargo.toml" ] [
                        str "workbench/wasm/Cargo.toml"
                    ]
                ]
                li [] [
                    a [ _href "workbench/wasm/src/lib.rs" ] [
                        str "workbench/wasm/src/lib.rs"
                    ]
                ]
                li [] [
                    a [ _href "workbench/.cargo/config.toml" ] [
                        str "workbench/.cargo/config.toml"
                    ]
                ]
                li [] [
                    a [ _href "workbench/Cargo.toml" ] [
                        str "workbench/Cargo.toml"
                    ]
                ]
                li [] [
                    a [ _href "workbench/Cargo.lock" ] [
                        str "workbench/Cargo.lock"
                    ]
                ]
                li [] [
                    a [ _href "workbench/package.json" ] [
                        str "workbench/package.json"
                    ]
                ]
                li [] [
                    a [ _href "workbench/package-lock.json" ] [
                        str "workbench/package-lock.json"
                    ]
                ]
                li [] [
                    a [ _href "workbench/index.html" ] [
                        str "workbench/index.html"
                    ]
                ]
                li [] [
                    a [ _href "workbench/tsconfig.json" ] [
                        str "workbench/tsconfig.json"
                    ]
                ]
                li [] [
                    a [ _href "workbench/README.md" ] [
                        str "workbench/README.md"
                    ]
                ]
                li [] [
                    a [ _href "workbench/UPSTREAM.json" ] [
                        str "workbench/UPSTREAM.json"
                    ]
                ]
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
