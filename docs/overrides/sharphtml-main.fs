module ConvertedFiles.Overrides.MainRaw

let file = """{#-
  sHEL Documentation Overrides
  - Announcement banner
  - RunLLM AI assistant widget
  - Social meta tags
-#}
{% extends "base.html" %}

{% block extrahead %}
  {{ super() }}
  <meta property="og:type" content="website">
  <meta property="og:url" content="https://docs.shel.sh/">
  <meta property="og:title" content="sHEL Documentation">
  <meta property="og:description" content="sHEL - All the protection of a turtle without the soft underbelly">
  <meta property="og:locale" content="en_US">
  <meta property="twitter:card" content="summary_large_image">
  <meta property="twitter:title" content="sHEL Documentation">
  <meta property="twitter:description" content="sHEL - All the protection of a turtle without the soft underbelly">
{% endblock %}

{% block announce %}
  <strong>sHEL is in active development</strong> --
  <a href="https://github.com/CommanderTurtle/docs-pages">Star us on GitHub</a>
{% endblock %}

{% block scripts %}
  {{ super() }}
  <script type="module" src="https://widget.runllm.com"
    id="runllm-widget-script"
    version="stable"
    runllm-keyboard-shortcut="Mod+j"
    runllm-name="sHEL"
    runllm-position="BOTTOM_RIGHT"
    runllm-position-y="120px"
    runllm-position-x="20px"
    runllm-assistant-id="207"
    async
  ></script>
{% endblock %}
"""

let render() = file
