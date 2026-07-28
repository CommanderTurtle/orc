module CountkuScore

open System.Text.Encodings.Web
open System.Text.Json

// The score stays native Web Audio and dependency-free. Design references:
// https://github.com/zoejane/awesome-music-programming
// https://www.w3.org/TR/webaudio-1.0/
// https://tonejs.github.io/
// https://strudel.cc/workshop/getting-started/

type ScoreMovement = {
    id: string
    title: string
    minimum: int
    description: string
    bpm: int
    subdivision: int
    wave: string
    counterWave: string
    bassWave: string
    notes: int list
    counter: int list
    roots: int list
    melodyGain: float
    counterGain: float
    bassGain: float
    attack: float
    release: float
    lowpass: int
    delayTime: float
    delayFeedback: float
    delayWet: float
    atmosphereFrequency: int
    atmosphereGain: float
    atmosphereQ: float
    pulseEvery: int
    pulseFrequency: int
    pulseGain: float
}

let private movement
    id title minimum description bpm subdivision
    wave counterWave bassWave notes counter roots
    melodyGain counterGain bassGain attack release lowpass
    delayTime delayFeedback delayWet
    atmosphereFrequency atmosphereGain atmosphereQ
    pulseEvery pulseFrequency pulseGain =
    {
        id = id
        title = title
        minimum = minimum
        description = description
        bpm = bpm
        subdivision = subdivision
        wave = wave
        counterWave = counterWave
        bassWave = bassWave
        notes = notes
        counter = counter
        roots = roots
        melodyGain = melodyGain
        counterGain = counterGain
        bassGain = bassGain
        attack = attack
        release = release
        lowpass = lowpass
        delayTime = delayTime
        delayFeedback = delayFeedback
        delayWet = delayWet
        atmosphereFrequency = atmosphereFrequency
        atmosphereGain = atmosphereGain
        atmosphereQ = atmosphereQ
        pulseEvery = pulseEvery
        pulseFrequency = pulseFrequency
        pulseGain = pulseGain
    }

// -1 is a rest. The browser module converts it to null so the F# source stays
// compact and every authored step remains visible in one registry.
let private movements =
    [
        movement
            "sakura-prelude" "Sakura Prelude" 0
            "A suspended pentatonic opening with long air between each answer."
            62 2 "sine" "triangle" "sine"
            [ 60; -1; 67; -1; 64; -1; 69; -1; 62; -1; 67; -1; 64; -1; 71; -1 ]
            [ -1; -1; 72; -1; -1; -1; 76; -1; -1; -1; 74; -1; -1; -1; 79; -1 ]
            [ 48; 45; 50; 47 ]
            0.050 0.018 0.034 0.055 1.45 1750
            0.31 0.21 0.16
            420 0.026 0.48
            0 1200 0.0

        movement
            "amber-footfall" "Amber Footfall" 20
            "A warmer pulse arrives in pairs, like footsteps crossing dry grass."
            72 2 "triangle" "sine" "sine"
            [ 57; -1; 64; 67; -1; 69; 64; -1; 60; -1; 67; 69; -1; 72; 67; -1 ]
            [ -1; 76; -1; -1; 74; -1; -1; 76; -1; 79; -1; -1; 81; -1; -1; 79 ]
            [ 45; 48; 43; 50 ]
            0.052 0.020 0.036 0.042 1.20 1900
            0.27 0.18 0.14
            510 0.024 0.58
            8 1180 0.018

        movement
            "vermilion-bell" "Vermilion Bell" 40
            "Bell-like fifths answer a deliberate red-gate rhythm."
            68 3 "sine" "triangle" "triangle"
            [ 62; -1; 69; 74; -1; 71; -1; 69; 64; -1; 71; 76; -1; 74; -1; 71; 67; -1; 74; 79; -1; 76; -1; 74 ]
            [ -1; 81; -1; -1; -1; 79; -1; -1; 83; -1; -1; -1; 81; -1; -1; 79; -1; -1; 86; -1; -1; 83; -1; -1 ]
            [ 50; 47; 52; 45 ]
            0.048 0.022 0.034 0.025 1.68 2300
            0.375 0.27 0.19
            760 0.020 0.72
            12 1640 0.015

        movement
            "cobalt-current" "Cobalt Current" 60
            "A quicker blue ostinato moves beneath a wide, floating counterline."
            82 4 "triangle" "sine" "sine"
            [ 59; 66; -1; 71; 64; -1; 69; 73; 61; 68; -1; 73; 66; -1; 71; 76 ]
            [ -1; -1; 78; -1; -1; 83; -1; -1; -1; -1; 80; -1; -1; 85; -1; -1 ]
            [ 47; 52; 49; 54 ]
            0.043 0.019 0.032 0.020 0.88 2100
            0.24 0.22 0.14
            640 0.023 0.64
            4 980 0.014

        movement
            "frost-pavilion" "Frost Pavilion" 80
            "High glass tones and quiet sub-bass leave a cold, crystalline room."
            56 2 "sine" "sine" "sine"
            [ 72; -1; -1; 79; -1; 76; -1; -1; 74; -1; -1; 81; -1; 79; -1; -1 ]
            [ -1; 84; -1; -1; -1; -1; 88; -1; -1; 86; -1; -1; -1; -1; 91; -1 ]
            [ 43; 50; 45; 52 ]
            0.036 0.015 0.030 0.090 2.35 2850
            0.46 0.33 0.23
            1180 0.017 0.84
            16 2280 0.009

        movement
            "dark-crossing" "Dark Crossing" 100
            "Low minor seconds, a restrained pulse, and a horizon nearly without color."
            48 2 "triangle" "sine" "sine"
            [ 50; -1; 51; -1; 57; -1; 54; -1; 49; -1; 50; -1; 56; -1; 52; -1 ]
            [ -1; -1; 62; -1; -1; 63; -1; -1; -1; -1; 61; -1; -1; 68; -1; -1 ]
            [ 38; 39; 33; 40 ]
            0.042 0.016 0.042 0.075 2.20 980
            0.51 0.37 0.22
            190 0.038 1.12
            4 310 0.024

        movement
            "iron-moon" "Iron Moon" 120
            "Metallic intervals orbit a steady low center after the crossing."
            64 3 "square" "sine" "triangle"
            [ 54; -1; 61; -1; 58; 65; -1; 63; 56; -1; 63; -1; 60; 67; -1; 65; 58; -1; 65; -1; 61; 68; -1; 66 ]
            [ -1; 73; -1; -1; 70; -1; -1; 75; -1; -1; 72; -1; -1; 77; -1; -1; 75; -1; -1; 80; -1; -1; 77; -1 ]
            [ 42; 44; 39; 46 ]
            0.031 0.016 0.039 0.018 1.08 1420
            0.22 0.29 0.15
            330 0.030 0.92
            6 730 0.020

        movement
            "hidden-constellation" "Hidden Constellation" 140
            "Sparse points of sound imply a larger shape that never fully resolves."
            58 4 "sine" "triangle" "sine"
            [ 65; -1; -1; 72; -1; 69; -1; 76; 67; -1; -1; 74; -1; 71; -1; 79 ]
            [ -1; -1; 84; -1; -1; -1; 81; -1; -1; -1; 86; -1; -1; -1; 83; -1 ]
            [ 41; 48; 43; 50 ]
            0.040 0.018 0.029 0.068 1.92 2500
            0.42 0.31 0.24
            930 0.018 0.76
            0 1300 0.0

        movement
            "glass-tempest" "Glass Tempest" 160
            "Fast bright fragments circle without becoming noise."
            92 4 "triangle" "square" "sine"
            [ 62; 69; 74; -1; 66; 73; 78; -1; 64; 71; 76; -1; 67; 74; 79; -1 ]
            [ -1; 81; -1; 86; -1; 85; -1; 90; -1; 83; -1; 88; -1; 86; -1; 91 ]
            [ 38; 45; 40; 47 ]
            0.036 0.014 0.032 0.012 0.58 2350
            0.16 0.24 0.12
            1520 0.016 1.24
            4 2450 0.013

        movement
            "solar-archive" "Solar Archive" 180
            "Warm polyphonic fragments recall every earlier movement in a brighter key."
            76 3 "sawtooth" "sine" "triangle"
            [ 60; 67; -1; 72; 64; 71; -1; 76; 62; 69; -1; 74; 67; 74; -1; 79; 64; 71; -1; 76; 69; 76; -1; 81 ]
            [ -1; 84; -1; -1; 83; -1; -1; 88; -1; 86; -1; -1; 88; -1; -1; 91; -1; 88; -1; -1; 93; -1; -1; 95 ]
            [ 48; 52; 50; 55 ]
            0.028 0.016 0.035 0.016 0.92 1850
            0.29 0.26 0.17
            690 0.023 0.64
            6 1380 0.016

        movement
            "endless-return" "Endless Return" 200
            "The final authored movement recombines the opening motif and leaves the jukebox open."
            66 3 "triangle" "sine" "sine"
            [ 60; -1; 67; 72; -1; 69; 64; -1; 71; 76; -1; 74; 62; -1; 69; 74; -1; 71; 67; -1; 74; 79; -1; 76 ]
            [ -1; 84; -1; -1; 83; -1; -1; 88; -1; -1; 86; -1; -1; 81; -1; -1; 83; -1; -1; 88; -1; -1; 91; -1 ]
            [ 48; 45; 50; 43; 52; 47 ]
            0.045 0.018 0.034 0.038 1.52 2200
            0.333 0.24 0.18
            520 0.024 0.58
            12 1180 0.012
    ]

let render () =
    let options = JsonSerializerOptions()
    options.WriteIndented <- true
    options.PropertyNamingPolicy <- JsonNamingPolicy.CamelCase
    options.Encoder <- JavaScriptEncoder.UnsafeRelaxedJsonEscaping

    let json =
        JsonSerializer.Serialize(movements |> List.toArray, options)

    """// Generated by Orc from sharpjs-countku-score.fs.
// Edit the F# source; do not hand-edit this rendered module.
const movements = __SCORE_JSON__;

export const SCORE_MOVEMENTS = Object.freeze(
  movements.map((entry) => Object.freeze({{
    ...entry,
    notes: Object.freeze(entry.notes.map((note) => note < 0 ? null : note)),
    counter: Object.freeze(entry.counter.map((note) => note < 0 ? null : note)),
    roots: Object.freeze(entry.roots)
  }}))
);

export function movementForCount(correct) {{
  const count = Math.max(0, Math.floor(Number(correct) || 0));
  for (let index = SCORE_MOVEMENTS.length - 1; index >= 0; index -= 1) {{
    if (count >= SCORE_MOVEMENTS[index].minimum) return SCORE_MOVEMENTS[index];
  }}
  return SCORE_MOVEMENTS[0];
}}

export function movementById(id) {{
  return SCORE_MOVEMENTS.find((movement) => movement.id === id) ?? null;
}}
"""
    |> fun template ->
        template
            .Replace("{{", "{")
            .Replace("}}", "}")
            .Replace("__SCORE_JSON__", json)
