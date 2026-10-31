module Muz.Source.Examples.Starter.SongMuz

let file = """use "std/tonal" as tonal;

// Small editable demonstration, not a prescribed style.
let key = scale("E", "harmonic_minor", octave = 3);
let harmony = tonal.progression(key, [1, 6, 4, 5], each = 3b);
let melody = tonal.melody(key, [8, 10, 9, 8, 7, 6, 5, 7], step = 1.5b);
assert(harmony.span == 12b);
assert(melody.span == harmony.span);

song({
    title: "Study in E",
    tempo: 90,
    meter: [3, 4],
    tracks: [
        track("lead", melody, synth("bell"), {gain: -6}),
        track("harmony", voicelead(harmony, low = 40, high = 64), synth("pad"), {gain: -14})
    ],
    tail: 1
})
"""

let render() = file
