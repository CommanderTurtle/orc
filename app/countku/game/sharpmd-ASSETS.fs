module ConvertedFiles.ASSETSMd

let file = """# Countku application asset ledger

## Original application assets

| Asset | Origin | Shipping terms |
|---|---|---|
| `assets/skeptical-scholar.svg` | Original pixel character created for Countku | Covered by the repository license |
| `assets/countku-mark.svg` | Original `句` application mark created for Countku | Covered by the repository license |
| Success and failure sounds | Synthesized at runtime by `countku-sound.js`; pitch, chord, envelope, and oscillator timbre change with trail rank | No recorded audio file or third-party sample |
| Ambient trail score | Eleven original movements authored in `sharpjs-countku-score.fs`, synthesized and scheduled at runtime by `countku-music.js` | No recorded audio file or third-party sample |

## CC0 progression sprites

Countku includes four deliberately small sprites from the
[Superpowers Ninja Adventure asset pack](https://github.com/sparklinlabs/superpowers-asset-packs/tree/master/ninja-adventure):

- animated coin;
- flower;
- empty scroll;
- two-state treasure chest.

The upstream pack was created by Pixel-boy and Sparklin Labs and released
under CC0 1.0. The complete upstream `LICENSE.txt` is preserved as
`assets/cc0-ninja-adventure/LICENSE-CC0.txt`. These sprites are used only as
quiet progression affordances; Countku's original world art remains the
dominant visual identity.

The game layer contains no copied Avatar character art, screenshot, music,
logo, or other franchise asset. `sharpjs-countku-wisdom.fs` includes 20 brief
attributed scene lines as text, each with its transcript source attached.

## Learning sources

Learning cards distinguish attributed excerpts, sourced paraphrases, and
original Countku writing. Every sourced item stores its URL in the F# catalog;
original character lines are labeled as original.
Current institutional sources are:

- National Diet Library, *Japanese Mathematics in the Edo Period*;
- National Diet Library authority data for Matsuo Bashō;
- Kokugakuin University, *Encyclopedia of Shinto*.
- Project Gutenberg editions used by the advisor field book;
- Avatar Wiki episode transcripts for the 20 brief Avatar and Korra scene
  lines.

The dialogue bank uses original Countku personas and one original pixel
portrait. The compact rolling-text presentation is implemented from scratch
in the Countku game layer.

The source metadata documents factual provenance. It does not imply that
those institutions endorse Countku or license Countku's own artwork.
"""

let render() = file
