module Muz.Source.Examples.Starter.MathMuz

let file = """// Evaluate independently: bun run muz evaluate math.muz --root examples/starter
let measure = 3b;
let triplet = measure / 3;
assert(triplet * 3 == measure);
assert(measure * 4 == 12b);
{measure: measure, triplet: triplet, form: measure * 4}
"""

let render() = file
