module Muz.Source.Examples.Starter.PlanMd

let file = """# Study in E

Four 3/4 measures at 90 BPM. E harmonic minor, i–VI–iv–V palette.
Bell melody over quiet, bounded-register pad voicings. The goal is a small,
editable example showing native tonal helpers, exact span assertions and
separate intent checks—not an automatic composition-quality score.

Try changing the melodic degrees or voicing bounds; check the source, inspect
the affected notes, then compare analysis evidence. A tritone inside dominant
harmony is expected color, not a request to remove it.
"""

let render() = file
