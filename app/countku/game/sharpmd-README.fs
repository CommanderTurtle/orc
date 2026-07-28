module ConvertedFiles.READMEMd

let file = """# Countku game layer

This directory upgrades the Orc browser page without duplicating its language
engine.

- `sharpjs-countku-dialogue.fs` is the compiled F# dialogue registry. Its
  inert Regedited jump table exposes the four progression ranges at indexes
  `4100`, `4200`, `4300`, and `4400`; Orc renders the catalog to
  `countku-dialogue.js`.
- `sharpjs-countku-worlds.fs` owns the complete world route: 21 hand-authored
  five-landing palettes from Sakura Trail through Dark Crossing, followed by
  deterministic compound-name and color generation beginning at landing 105.
- `sharpjs-countku-score.fs` owns the opening movement and ten twenty-landing
  score movements. Orc renders the note, pulse, atmosphere, and timing data
  to `countku-score.js`.
- `sharpjs-countku-wisdom.fs` is the large authored string bank for field
  dialogue, 20 attributed scene lines, and 65 five-seven-five advisor
  meetings. The page imports the rendered catalog instead of carrying it in
  `index.fs`.
- `countku-content.js` is the compact progression/rules catalog and imports
  the rendered dialogue bank.
- `countku-state.js` owns the versioned, local-only player save.
- `countku-sound.js` generates original, rank-sensitive interaction sounds
  with Web Audio. There are no recorded samples to duplicate or recolor.
- `countku-music.js` is a dependency-free, look-ahead Web Audio transport.
  It plays the F# score catalog, follows progress automatically, and exposes
  every unlocked movement as a jukebox choice. A filtered procedural
  atmosphere, restrained feedback delay, and output compression give it
  space without shipping a recorded track. Audio starts only after a player
  gesture.
- `countku-app.js` adapts the existing game and renderer.
- `countku-app.css` contains the responsive Countku-only presentation.
- `ASSETS.md` records original assets and institutional learning sources.
- `assets/cc0-ninja-adventure/` contains four tiny CC0 progression sprites
  with the upstream CC0 deed bundled beside them.
- `../manifest.webmanifest` and `../countku-sw.js` provide the local-first
  installable shell. Navigation remains network-first so an old cached engine
  never silently wins over a reachable current build.

The original three numeric modes continue to use the base page. The enhanced
world is enabled only while `countku` is selected.

Do not add parser tables here. Language changes belong in the shared Countku
engine and must follow the synchronization sequence in
`CommanderTurtle/countku/docs/INTEGRATION.md`.

The registries are deliberately plain F# source. For example,
`rgd ist game/sharpjs-countku-dialogue.fs 4100` describes the early range and
`rgd rg game/sharpjs-countku-dialogue.fs i4100z1` jumps directly to its
authored entries. New entries should remain concise, identify whether they
are original or institutional, and never turn a historical paraphrase into a
floating quotation.
"""

let render() = file
