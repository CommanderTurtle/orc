module Muz.Source.Docs.ColorfulMd

let file = """# View colorful

## User scope — verbatim

> Perhaps even a "view colorful" command. That outputs a mathematical gradient, a .png, so the model can view how beethoven would view music. It would incorporate strategies like the unit circle and sine / complex trig functions to map out essentially *the music over time*. Thuswise a metal piece or boss battle music would look very different from c418, if u will. Definitely a really complicated albeit mathematically beautiful export to add at the end. Basically the music instructor you can see. If the model was deaf. Add only at the end, and use this text verbatim when scoping this without rewriting it. This is obviously after you spend a great deal of time on the other things.

## Implemented mathematical projection

This optional final export consumes the same compiled note snapshot and meter-aware analysis as the rest of the toolkit. It is a deterministic view of musical structure, not an assertion about Beethoven's subjective experience and not a genre detector. Register, attack density, sustained textures and harmonic trajectories are visible without listening; timbre and mixing still require audio evaluation.

```sh
bun run muz view colorful song.muz --root PROJECT --output out/colorful.png
```

MCP: `muz_view_colorful` accepts the same project input plus `output`, analysis `options`, optional `width` (1200–2400), `pitchMin` / `pitchMax` (default MIDI 24–96). Default image is 1600×1080, covering up to 256 measures. `window.nextMeasure` discloses a longer piece; request subsequent windows. `options.excludeTracks` deliberately removes unpitched material. Choose `basis="performance"` for realized gate/humanization and imported MIDI. Exports never overwrite an existing file and never play audio.

The MCP returns the PNG as an image content block **and** its saved path, with source revision, definitions and limitations in structured data. CLI returns metadata/path without dumping base64. A UTF-8 PNG metadata chunk preserves the mathematical contract and full project title. No graphics/font package, browser, CDN or audio rendering is required.

Panels:

- **Fifths field:** each pitch class lies at `theta_p = 2π × ((7p) mod 12) / 12`. Adjacent fifths are adjacent angles. Bin weights are the exact note-overlap durations converted to drawing weights, multiplied by velocity. `K(theta,p)=exp(6(cos(theta−theta_p)−1))` gives smooth circular lobes. The displayed field is `Σw_p K / Σw_p`, with fixed density-sensitive brightness and pitch-phase hue. Silence stays dark.
- **Complex tonal path:** `z(t)=Σw_p exp(i theta_p)/Σw_p`. Real/imaginary parts determine its location inside the unit circle. Radius is fifths concentration, not consonance, key confidence or musical quality. Trace color runs from early cyan to late violet; the white vector is the window's aggregate moment.
- **Pitch/register:** compiled note ribbons use fifths hue and velocity brightness, on a labeled MIDI pitch axis. Notes outside the requested register are counted, not silently described as absent. Chords/sustains differ visibly from sparse or rapid lines.
- **Rhythm:** unsmoothed note-on impulses preserve exact attack locations at image resolution. Height uses `1−exp(−count/3)` with fixed scaling, so separate exports remain comparable. Image bins can merge closely spaced events; use exact inspection for resolution below one pixel.
- **Tension/motion:** blue is normalized pitch-class entropy; pink is the weighted pairwise interval-class index using `[0,.95,.6,.15,.15,.1,.85]` for classes 0–6; gold is wrapped unit-circle phase change weighted by adjacent concentration. These are explicit heuristics, not acoustic roughness/quality judgments. A dominant seventh can legitimately look tense.

Image resolution and numeric color/statistic calculations use floating point; exact source timing remains available in score inspection/analysis. No waveform, spectral timbre, pedaled resonance, perceived loudness or emotion is inferred from note data. Musical styles can share identical notes and therefore identical images. The exporter does not pretend otherwise.
"""

let render() = file
