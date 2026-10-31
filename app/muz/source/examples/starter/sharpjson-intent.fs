module Muz.Source.Examples.Starter.IntentJson

let file = """{
  "basis": "score",
  "measureCount": 4,
  "intent": {
    "key": { "tonic": "E", "mode": "harmonic_minor" },
    "expectedBeats": "12",
    "phraseMeasures": 4,
    "ranges": { "lead": [48, 84] },
    "maxPolyphony": { "lead": 1 }
  }
}
"""

let render() = file
