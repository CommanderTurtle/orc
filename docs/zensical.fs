module ConvertedFiles.ZensicalToml

let file = """[project]
site_name = "sHEL"
site_url = "https://docs.shel.sh"
site_description = "sHEL - All the protection of a turtle without the soft underbelly"
repo_url = "https://github.com/CommanderTurtle/docs-pages"
edit_uri = "https://github.com/CommanderTurtle/docs-pages/edit/main/docs/"
docs_dir = "docs"
copyright = "Copyleft 🄯; 2025 sHEL Project"
extra_css = [
    "assets/stylesheets/extra.css",
]
extra_javascript = [
    "assets/javascripts/mathjax.js",
    "assets/javascripts/edit_and_feedback.js",
    "assets/javascripts/slack_and_forum.js",
    "assets/javascripts/run_llm_widget.js",
    "https://unpkg.com/mathjax@3.2.2/es5/tex-mml-chtml.js",
]

[project.markdown_extensions.abbr]

[project.markdown_extensions.admonition]

[project.markdown_extensions.attr_list]

[project.markdown_extensions.def_list]

[project.markdown_extensions.footnotes]

[project.markdown_extensions.md_in_html]

[project.markdown_extensions.pymdownx.caret]

[project.markdown_extensions.pymdownx.details]

[project.markdown_extensions.pymdownx.snippets]

[project.markdown_extensions.pymdownx.inlinehilite]

[project.markdown_extensions.pymdownx.smartsymbols]

[project.markdown_extensions.pymdownx.mark]

[project.markdown_extensions.pymdownx.tilde]

[project.markdown_extensions.pymdownx.keys]

[project.markdown_extensions.pymdownx.highlight]
line_spans = "__span"
anchor_linenums = true
linenums_style = "pymdownx-inline"
pygments_lang_class = true
auto_title = true

[project.markdown_extensions.pymdownx.superfences]
custom_fences = [
    { name = "mermaid", class = "mermaid", format = "pymdownx.superfences.fence_code_format" },
]

[project.markdown_extensions.pymdownx.tabbed]
alternate_style = true
combine_header_slug = true

[project.markdown_extensions.pymdownx.emoji]
emoji_index = "zensical.extensions.emoji.twemoji"
emoji_generator = "zensical.extensions.emoji.to_svg"

[project.markdown_extensions.pymdownx.arithmatex]
generic = true

[project.markdown_extensions.pymdownx.magiclink]
normalize_issue_symbols = true
repo_url_shorthand = true
user = "CommanderTurtle"
repo = "docs-pages"

[project.markdown_extensions.pymdownx.tasklist]
custom_checkbox = true

[project.markdown_extensions.pymdownx.betterem]
smart_enable = "all"

[project.markdown_extensions.zensical.extensions.glightbox]
auto_themed = true

[project.markdown_extensions.toc]
permalink = true

[project.extra]
social = [
    { icon = "fontawesome/brands/github", link = "https://github.com/CommanderTurtle?tab=repositories", name = "sHEL on GitHub" },
    { icon = "fontawesome/solid/paper-plane", link = "mailto:clement.keynote-1e@icloud.com", name = "Send feedback" },
]
generator = false

[project.theme]
variant = "classic"
logo = "assets/logos/shel-logo-icon.png"
favicon = "assets/logos/shel-favicon.png"
features = [
    "content.code.copy",
    "content.code.select",
    "content.code.annotate",
    "announce.dismiss",
    "content.action.edit",
    "content.action.view",
    "content.footnote.tooltips",
    "content.tabs.link",
    "content.tooltips",
    "navigation.footer",
    "navigation.indexes",
    "navigation.instant",
    "navigation.instant.progress",
    "navigation.path",
    "navigation.sections",
    "navigation.top",
    "navigation.tracking",
    "search.highlight",
    "toc.follow",
    "search.share",
]
custom_dir = "overrides"

[[project.theme.palette]]
media = "(prefers-color-scheme)"
primary = "custom"
accent = "custom"

[project.theme.palette.toggle]
icon = "lucide/sun-moon"
name = "Switch to light mode"

[[project.theme.palette]]
media = "(prefers-color-scheme: light)"
scheme = "default"
primary = "custom"
accent = "custom"

[project.theme.palette.toggle]
icon = "lucide/sun"
name = "Switch to dark mode"

[[project.theme.palette]]
media = "(prefers-color-scheme: dark)"
scheme = "slate"
primary = "custom"
accent = "custom"

[project.theme.palette.toggle]
icon = "lucide/moon-star"
name = "Switch to system preference"

[[project.nav]]
Home = "README.md"
Index = "page.md"

[[project.nav]]

[[project.nav."Deep Hole"]]
Index = "deep-hole/index.md"

[[project.nav]]

[[project.nav.Symbols]]
Index = "symbols/index.md"

[[project.nav.Symbols]]
Stereograms = "symbols/stereograms.md"

[[project.nav]]

[[project.nav.Projects]]
Index = "projects/index.md"

[[project.nav.Projects]]
Captcha = "projects/captcha.md"

[[project.nav.Projects]]
Countku = "projects/countku.md"

[[project.nav.Projects]]
Macrohard = "projects/macrohard.md"

[[project.nav.Projects]]
Regedited = "projects/regedited.md"

[[project.nav.Projects]]
Blobs = "projects/surroundtest-freeblobs.md"

[[project.nav.Projects]]

[[project.nav.Projects.XML]]
Index = "xml-project/index.md"

[[project.nav.Projects.XML]]
Base64 = "xml-project/base64.md"

[[project.nav.Projects.XML]]
Unicode = "xml-project/captcha-unicode.md"

[[project.nav.Projects.XML]]
"Clipboard Automation" = "xml-project/clipboard-automation.md"

[[project.nav.Projects.XML]]
"CMD Literacy" = "xml-project/cmd-literacy.md"

[[project.nav.Projects.XML]]
"JS vs Assembly" = "xml-project/countku.md"

[[project.nav.Projects.XML]]
"Fsharp and Dotnet Solution" = "xml-project/fsharp-zensical.md"

[[project.nav.Projects.XML]]
"Variable Math" = "xml-project/haiku-numbersystem.md"

[[project.nav]]

[[project.nav.Wikispace]]
Index = "wikispace/index.md"

[[project.nav.Wikispace]]
"AI Agents" = [
    { "Ai Agent Stack" = "wikispace/ai-agent-stack.md" },
    { "Local LLMs" = "wikispace/local-llm.md" },
    { "Ollama vs vLLM" = "wikispace/modeling.md" },
]

[[project.nav.Wikispace]]
Infrastructure = [
    { Datacenters = "wikispace/datacenters.md" },
    { "Modern Tech" = "wikispace/modern-objects-2026.md" },
    { Tunnels = "wikispace/wireguard-server.md" },
    { "Virtualized VLAN" = "wikispace/zerotier.md" },
]

[[project.nav.Wikispace]]
Networking = [
    { IPv6 = "wikispace/ipv6.md" },
    { DNNs = "wikispace/dnn-analysis.md" },
    { DNS = "wikispace/dns.md" },
    { Tomato = "wikispace/freshtomato-infrastructure.md" },
    { GLI = "wikispace/glinet-luci.md" },
    { Hetzner = "wikispace/hetzner-sovereign.md" },
    { IANA = "wikispace/iana-standards.md" },
    { iptables = "wikispace/iptables-deep.md" },
    { "Modding Proprietary Routers" = "wikispace/openwrt-freshtomato.md" },
    { Luci = "wikispace/openwrt-luci.md" },
    { Portmaster = "wikispace/portmaster-deep.md" },
]

[[project.nav.Wikispace]]
Security = [
    { Index = "wikispace/security/index.md" },
    { "Compression algorithms" = "wikispace/security/compression.md" },
    { Containerization = "wikispace/security/containerization.md" },
    { Encoding = "wikispace/security/encoding.md" },
    { Encryption = "wikispace/security/encryption.md" },
    { Hosting = "wikispace/security/hosting.md" },
    { Hypervisors = "wikispace/security/hypervisors.md" },
    { Minimalism = "wikispace/security/minimalism.md" },
    { Permissions = "wikispace/security/permissions.md" },
    { Steganography = "wikispace/security/steganography.md" },
]

[[project.nav.Wikispace.Environment]]
"Powershell Objects" = "wikispace/modern-objects.md"

[[project.nav.Wikispace.Environment]]
iOS = "wikispace/ios.md"

[[project.nav.Wikispace.Environment]]
Windows = [
    { "Trying to learn Microsoft" = "wikispace/microsoft-learn.md" },
    { "Windows Setup" = "wikispace/windows.md" },
    { "Windows Apps" = "wikispace/apps.md" },
    { "Windows Advanced" = "wikispace/windows-advanced.md" },
    { WSL = "wikispace/wsl.md" },
]
"""

let render() = file
