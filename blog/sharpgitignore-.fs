module Bl0g.Gitignore

let file = """_site
.sass-cache
.jekyll-cache
.jekyll-metadata
vendor
Gemfile.lock
.bundle
"""

let render() = file
