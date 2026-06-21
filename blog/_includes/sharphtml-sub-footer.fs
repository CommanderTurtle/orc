module ConvertedFiles.Includes.SubFooterRaw

let file = """{% comment %}
  Use this to insert markup before the closing body tag.
  For example, scripts that need to be executed after the document has finished loading.
{% endcomment %}
"""

let render() = file
