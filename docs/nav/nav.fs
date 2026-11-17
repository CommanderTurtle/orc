module MyNav

module Nav =

    let navigation = """
[[project.nav]]
Home = "README.md"

[[project.nav]]
[[project.nav.Sections]]
Index = "sections/index.md"

[[project.nav.Sections]]
Research = [
    { ninfer-all = "wikispace/moltenmedium/2026-11-16--13--ninfer-all.md" },
    { "fp16 vs. bf16" = "wikispace/moltenmedium/2026-11-17--14--fp16-vs-bf16.md" },
]

[[project.nav.Sections]]

[[project.nav.Sections.Projects]]
Index = "projects/index.md"
[[project.nav.Sections.Projects]]
Captcha = "projects/captcha.md"
[[project.nav.Sections.Projects]]
Countku = "projects/countku.md"
[[project.nav.Sections.Projects]]
Automate = "projects/automate.md"
[[project.nav.Sections.Projects]]
Macrohard = "projects/macrohard.md"
[[project.nav.Sections.Projects]]
Gemma = "projects/nvfp4.md"
[[project.nav.Sections.Projects]]
Regedited = "projects/regedited.md"
[[project.nav.Sections.Projects]]
Blobs = "projects/surroundtest-freeblobs.md"


[[project.nav.Sections.Projects]]
"XML" = [
    { "Index" = "xml-project/index.md" },
    { "Base64" = "xml-project/base64.md" },
    { "Unicode" = "xml-project/captcha-unicode.md" },
    { "Clipboard Automation" = "xml-project/clipboard-automation.md" },
    { "CMD Literacy" = "xml-project/cmd-literacy.md" },
    { "JS vs Assembly" = "xml-project/countku.md" },
    { "Fsharp and Dotnet Solution" = "xml-project/fsharp-zensical.md" },
    { "Variable Math" = "xml-project/haiku-numbersystem.md" },
    { "CMD Data Structures" = "symbols/index.md" },
]
Home = "xml-project/xlsx.md"

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
    { Steganography = "wikispace/security/steganography.md"},
    { Stereograms = "symbols/stereograms.md"},
]

[[project.nav.Wikispace]]

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

[[project.nav.Wikispace.Environment]]
[[project.nav.Wikispace.Environment.Internet]]
"Deep Hole" = "deep-hole/index.md"

"""
