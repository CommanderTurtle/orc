module Muz.Source.Gitattributes

let file = """* text=auto eol=lf
src/vendor/** -text
"""

let render() = file
