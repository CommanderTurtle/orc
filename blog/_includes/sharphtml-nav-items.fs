module ConvertedFiles.Includes.NavItemsRaw

let file = """<div class="nav-items">
  {%- for path in include.paths -%}
  {%- assign hyperpage = site.pages | where: "path", path | first -%}
  {%- if hyperpage.title %}
  <a class="nav-item" href="{{ hyperpage.url | relative_url }}">{{ hyperpage.title | escape }}</a>
  {%- endif -%}
  {%- endfor %}
</div>
"""

let render() = file
