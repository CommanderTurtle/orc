module Muz.Source.Docs.AnalysisMd

let file = """# Musical analysis contract

`muz_analyze` / `bun run muz analyze` inspect **compiled engine notes**, not regular expressions over source. Every result has a source SHA-256 and selected engine revision. `.muz` remains unchanged.

## Coordinates and scope

All normalized times are quarter-note beats. Fractions are retained exactly for bar assignment, overlaps, note releases, and evidence positions. Output fractions such as `19/2` are beats, not seconds. Measure and within-measure beat labels start at one. A 6/8 measure is 3 quarter-note beats; a 7/8 measure is 7/2. The engine's `bars` literal is independently fixed at 4b.

Section meter changes define the measure grid. A change mid-measure starts a new measure and marks the preceding partial measure. Conflicting overlapping section meters are rejected instead of guessed. No pickup convention is inferred. A loop is analyzed for its compiled extent, not infinitely unrolled.

Default basis is `score`: the exact authored note duration before gate/humanization/kit expansion. `performance` uses realized MIDI schedules, each with its own PPQ, normalized to beats. Pitch bends, pedal resonance, effects and timbre are not folded back into those MIDI keys. Clock-placed score notes are explicitly omitted, making the analysis incomplete; use performance basis for realized placement. Microtonal notes remain in rhythm/register metrics but not 12-TET key weights. Interval matching is exact to a tiny floating-pitch tolerance, not psychoacoustic classification.

Default window: measures 1–32. Maximum 256 measures per request, 8192 in the form, 100,000 compiled notes, 512 simultaneous analyzed voices. The interval sweep permits one million candidate pairs; if exhausted, `complete=false` and the limitation is printed. A failed bound is never a successfully "clean" truncated prefix. `window.nextMeasure` supplies continuation. Span/expected-duration and phrase-group checks cover the form; note/range/leap/key/polyphony evidence covers the selected window.

## Key hypotheses

Each pitch class accumulates overlap duration × normalized attack velocity. A sustained note contributes to each measure it overlaps, not only its onset measure. For each of 24 major/natural-minor hypotheses:

```
coverage = in-scale weight / total weight
support = (tonic weight + 0.6 × third weight + 0.4 × fifth weight) / total weight
fit = 0.85 × coverage + 0.15 × support
```

Return the three highest fits. `keyAmbiguous` means the top two differ by less than 0.03. This threshold is a documented heuristic, **not calibrated statistical confidence**. Sparse material, relative keys, modal and polytonal writing are naturally ambiguous. The window-level candidates are a weighted aggregation, not a claim that every bar uses one key. All rests produce no key, not C major.

An optional declared key supplies the intended tonic and mode: major, minor, harmonic_minor, melodic_minor, dorian, phrygian, lydian, mixolydian, locrian, whole_tone. Borrowed/chromatic notes are informational by default. `strictKey:true` is an explicit constraint and makes these violations errors. No implicit drum-name or channel heuristic excludes notes; use `excludeTracks` deliberately.

## Harmony and interval evidence

For each constant-active-note slice, exact pitch-class sets are compared with triad, suspended, power, seventh and diminished-seventh templates. Bass position is retained for inversion labels. No exact match means no label; the program does not force every cluster into a chord. Multiple matches are hypotheses, especially symmetric diminished/augmented sets. Each measure prints at most 16 harmonic slices and discloses `total` / `omitted`.

The interval sweep uses half-open sounding-note spans: touching releases/onsets do not overlap. Minimum overlap defaults to 1/8 quarter-note beat, configurable with `minOverlap`. Default interval classes are 1 (semitone/major-seventh class) and 6 (tritone). Requested classes can be 1–6. Evidence identifies both notes, tracks, exact start, duration and measure. This is **not an acoustic roughness or "wrong note" detector**. Tritones are ordinary components of dominant harmony; semitones can be expressive, structural, or intentionally abrasive.

## Rhythm, register and explicit intent

Measure metrics include onset count, held-note count, peak polyphony, exact silence duration, duration-weighted pitch centroid, mean attack velocity, onset-gap mean/CV and off-notated-beat onset count. CV measures irregular spacing, not automatically bad rhythm. Off-beat is relative to the meter denominator; it is not a complete model of syncopation/accent. Onsets at the same exact time count once for gap/CV and separately for density.

Per-track maximum successive pitch leap is evaluated only in monophonic voice streams. An unseparated polyphonic stream is marked ambiguous, never linked into an invented melody. This does not perform contrapuntal voice separation or a full species-counterpoint audit.

An options file can express intent without modifying the language:

```json
{
  "basis": "score",
  "fromMeasure": 1,
  "measureCount": 32,
  "excludeTracks": ["drums"],
  "intent": {
    "key": { "tonic": "E", "mode": "harmonic_minor" },
    "expectedBeats": "128",
    "phraseMeasures": 4,
    "ranges": { "lead": [60, 88] },
    "maxLeap": { "lead": 12 },
    "maxPolyphony": { "lead": 1 }
  }
}
```

Use actual track IDs; unknown IDs and options are errors. Expected duration, declared register/leap/polyphony violations, and explicitly strict key violations fail `intent.status`, not `compiler.status`. Phrase-group remainders are advisory. Other musical findings are information, not automatic failures. `findings` is paginated with a total; severity counts include the full selected window even when only one findings page is returned.

CLI exit 0: compiled, analysis complete, declared hard intent satisfied. Exit 2: failed declared intent or incomplete analysis. Exit 1: invocation/engine failure. Warning/info counts alone do not cause failure.
"""

let render() = file
