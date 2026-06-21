module ConvertedFiles.Docs.PageMd

let file = """# sHEL Documentation

The sHEL project (sHEL Environment Literacy) is a comprehensive system for literal-safe data handling in Windows command-line environments. It addresses the fundamental problem of storing and transmitting data containing `cmd.exe` special characters without triggering unwanted parser interpretation. This documentation covers the core encoding systems, command-line literacy, network infrastructure references, operating system hardening, AI tooling, individual projects, 2026 technology surveys, and the external resources that informed the project.

---

## Documentation Sections

### Symbols Archive

A complete reference of special characters and their behavior across `cmd.exe` parsing contexts, HTML attribute encoding, and Base64 alphabets. Includes stereograms as a demonstration of encoding structured information within seemingly random data.

[Symbols Archive](symbols/index.md) | [Stereograms](symbols/stereograms.md)

### XML Project

The core technical documentation for literal-safe data handling. Covers Base64 encoding for media embedding, `cmd.exe` command literacy (FOR/F, findstr, delayed expansion), clipboard automation patterns, the Haiku Numbersystem variable naming convention, Countku JS encoding, CAPTCHA systems using invisible Unicode, and the F# Zensical architecture.

[Base64 Encoding](xml-project/base64.md) | [cmd.exe Literacy](xml-project/cmd-literacy.md) | [Clipboard Automation](xml-project/clipboard-automation.md) | [Haiku Numbersystem](xml-project/haiku-numbersystem.md) | [Countku](xml-project/countku.md) | [CAPTCHA Unicode](xml-project/captcha-unicode.md) | [F# Zensical](xml-project/fsharp-zensical.md)

### Projects

Individual projects developed as part of the sHEL ecosystem: Countku (syllable-counting language game), CAPTCHA (multi-modal anti-bot system), SurroundTest + FreeBlobs (surround sound testing and Unicode character library), Regedited (Rust plaintext database), and Macrohard (visual workflow automation).

[Projects Overview](projects/index.md) | [Countku](projects/countku.md) | [CAPTCHA](projects/captcha.md) | [SurroundTest + FreeBlobs](projects/surroundtest-freeblobs.md) | [Regedited](projects/regedited.md) | [Macrohard](projects/macrohard.md)

### Wikispace

Curated reference material for systems administration, networking, security, AI tooling, and development. Covers Windows administration and Group Policy DNS hardening, Microsoft documentation, applications, Portmaster deep configuration, iOS, DNS and firewall configuration, IPv6, IANA internet standards, router firmware (OpenWRT, FreshTomato, GL.iNet), WireGuard and ZeroTier VPNs, datacenter colocation, Hetzner sovereign infrastructure, local LLM inference, AI agent stacks, modeling with Ollama vs vLLM, modern objects and 2026 technologies, WSL, DNN architecture analysis, and a full security layer model.

[Windows Wiki](wikispace/windows.md) | [Windows Advanced](wikispace/windows-advanced.md) | [Microsoft Documentation](wikispace/microsoft-learn.md) | [Applications](wikispace/apps.md) | [Portmaster Deep](wikispace/portmaster-deep.md) | [iOS](wikispace/ios.md) | [DNS and Firewall](wikispace/dns.md) | [iptables Deep](wikispace/iptables-deep.md) | [IPv6](wikispace/ipv6.md) | [IANA Standards](wikispace/iana-standards.md) | [Router Firmware](wikispace/openwrt-freshtomato.md) | [FreshTomato](wikispace/freshtomato-infrastructure.md) | [GL.iNet / LuCI](wikispace/glinet-luci.md) | [OpenWRT LuCI](wikispace/openwrt-luci.md) | [WireGuard Server](wikispace/wireguard-server.md) | [ZeroTier](wikispace/zerotier.md) | [Datacenters](wikispace/datacenters.md) | [Hetzner Sovereign](wikispace/hetzner-sovereign.md) | [Local LLM](wikispace/local-llm.md) | [Modeling](wikispace/modeling.md) | [AI Agent Stack](wikispace/ai-agent-stack.md) | [Modern Objects 2026](wikispace/modern-objects-2026.md) | [WSL Guide](wikispace/wsl.md) | [DNN Analysis](wikispace/dnn-analysis.md) | [Security](wikispace/security/index.md)

### Deep Hole

A curated index of external resources, community platforms, software history, and development tools encountered during the course of the project.

[Deep Hole Index](deep-hole/index.md)

---

## What is Literal-Safe Handling?

`cmd.exe` interprets certain characters as control operators at parse time: `&` separates commands, `|` creates pipes, `<` and `>` handle redirection, `^` escapes the following character, and `%` triggers variable expansion. The double-quote character does not delimit strings but toggles a quote-state flag in the parser. These behaviors make it difficult to store and process text data containing arbitrary characters.

The sHEL project uses a layered approach to solve this problem:

1. **Base64 encoding** provides a character-set-safe transport mechanism for any binary data through any text-processing pipeline
2. **Delayed expansion** with `!variable!` syntax defers variable expansion until execution time, bypassing parse-time interpretation
3. **FOR /F** with carefully selected delimiter and token options extracts structured data from command output
4. **findstr** filters and matches text patterns with regular expression support
5. **The `clip` command** and PowerShell `Get-Clipboard` provide bidirectional clipboard integration

These primitives are combined into processing pipelines that can handle any character data without corruption, forming the foundation of the sHEL literal-safe system.
"""

let render() = file
