module ConvertedFiles.Docs.DeepHole.IndexMd

let file = """# Deep Hole

The Deep Hole is a curated index of external resources, cultural references, and development tools encountered during the course of the sHEL project. Entries are organized by category and represent the peripheral technical and cultural material that informed humanity's direction without forming parts of its core documentation.

---

## Overview

???+ note "What this page covers"
    This page serves as a curated link archive organized by category:

    - **Community Platforms** — Lemmy, Fediverse, Cydia, and independent web publications
    - **History and Culture** — F#, Dreamsongs, Destroy All Software
    - **Network and Infrastructure** — Datacenter resources, monitoring tools
    - **VPN and Routing** — RFC 4193, WireGuard resources
    - **LLM and AI Development** — vLLM, Hermes, model weights
    - **pi.dev Packages** — Package registry entries

    For core technical documentation, see the [Wikispace](../wikispace/index.md). For project-specific documentation, see [Projects](../projects/index.md).

---

## Community Projects (cool things)

| Resource | Description |
|----------|-------------|
| Lemmy<sup>[1](https://en.wikipedia.org/wiki/Lemmy_(social_network)){:rel="noopener noreferrer" target="blank"}</sup> | Federated link aggregator and discussion platform |
| Fediverse<sup>[2](https://en.wikipedia.org/wiki/Fediverse){:rel="noopener noreferrer" target="blank"}</sup> | Decentralized social networking protocol ecosystem |
| Apollo (app)<sup>[3](https://en.wikipedia.org/wiki/Apollo_(app)){:rel="noopener noreferrer" target="blank"}</sup> | Third-party Reddit client (discontinued) |
| Cydia<sup>[4](https://en.wikipedia.org/wiki/Cydia){:rel="noopener noreferrer" target="blank"}</sup> | Alternative package manager for iOS |
| Fediverse Network Map<sup>[5](https://en.wikipedia.org/wiki/Fediverse#/media/File:A_view_into_the_Fediverse.png){:rel="noopener noreferrer" target="blank"}</sup> | Visualization of federated instance connections |
| d3.ru<sup>[6](https://d3.ru/){:rel="noopener noreferrer" target="blank"}</sup> | Russian-language content aggregator |
| youraislopbores.me<sup>[7](https://youraislopbores.me/){:rel="noopener noreferrer" target="blank"}</sup> | Independent web publication |
| MSN: Anti-AI Chatbots<sup>[8](https://www.msn.com/en-us/money/other/uno-reverse-humans-are-pretending-to-be-ai-chatbots-at-an-anti-ai-website/ar-AA20YzM6){:rel="noopener noreferrer" target="blank"}</sup> | Reporting on human imitation of AI behavior |

---

## Culture and History

| Resource | Description |
|----------|-------------|
| F# History (HOPL)<sup>[9](https://fsharp.org/history/hopl-final/hopl-fsharp.pdf){:rel="noopener noreferrer" target="blank"}</sup> | History of F# at the ACM SIGPLAN HOPL conference |
| Dreamsongs<sup>[10](https://dreamsongs.com/#){:rel="noopener noreferrer" target="blank"}</sup> | Essays on software engineering |
| Destroy All Software<sup>[11](https://www.destroyallsoftware.com/talks/the-birth-and-death-of-javascript){:rel="noopener noreferrer" target="blank"}</sup> | Gary Bernhardt's talk on JavaScript history |
| Code Golf GitHub<sup>[12](https://github.com/codegolf/todo/issues/2){:rel="noopener noreferrer" target="blank"}</sup> | Programming code golf community tracker |
| Project Gutenberg<sup>[13](https://www.gutenberg.org/){:rel="noopener noreferrer" target="blank"}</sup> | Free e-book archive |
| Poetry Foundation<sup>[14](https://www.poetryfoundation.org/){:rel="noopener noreferrer" target="blank"}</sup> | Free poetry archive |

---

## Network and Infrastructure Tools

| Resource | Description |
|----------|-------------|
| Cologix Service Brochures<sup>[15](https://cologix.com/resources/service-brochures/){:rel="noopener noreferrer" target="blank"}</sup> | Datacenter service documentation |
| Cologix Colocation Guide<sup>[16](https://cologix.com/resources/service-brochures/colocation-buyers-guide-checklist/){:rel="noopener noreferrer" target="blank"}</sup> | Colocation buyer's checklist |
| Colocation America (1U)<sup>[17](https://www.colocationamerica.com/colocation/1u-colocation){:rel="noopener noreferrer" target="blank"}</sup> | 1U colocation specifications |
| Datacenter Map<sup>[18](https://www.datacentermap.com/){:rel="noopener noreferrer" target="blank"}</sup> | Global datacenter location directory |
| Tampa Datacenters<sup>[19](https://www.datacentermap.com/usa/florida/tampa/){:rel="noopener noreferrer" target="blank"}</sup> | Tampa Bay area datacenter listings |
| Bohler Places LLC (Fort Meade)<sup>[20](https://www.datacentermap.com/usa/florida/tampa/bohler-places-llc-fort-meade/){:rel="noopener noreferrer" target="blank"}</sup> | Fort Meade datacenter campus |
| Cologix Lakeland<sup>[21](https://www.datacentermap.com/usa/florida/tampa/cologix-lakeland/){:rel="noopener noreferrer" target="blank"}</sup> | Lakeland facility information |
| XCD/USD Converter<sup>[22](https://themoneyconverter.com/xcd/usd){:rel="noopener noreferrer" target="blank"}</sup> | East Caribbean Dollar exchange rate |
| KeepTrack Space<sup>[23](https://app.keeptrack.space/){:rel="noopener noreferrer" target="blank"}</sup> | Satellite and space object tracking |
| World Monitor<sup>[24](https://world-monitor.com/){:rel="noopener noreferrer" target="blank"}</sup> | Global event monitoring |
| OSIRIS AI<sup>[25](https://osirisai.vercel.app/){:rel="noopener noreferrer" target="blank"}</sup> | AI-powered monitoring dashboard |

---

## VPN and Routing

| Resource | Description |
|----------|-------------|
| RFC 4193<sup>[26](https://www.rfc-editor.org/rfc/rfc4193){:rel="noopener noreferrer" target="blank"}</sup> | Unique Local IPv6 Unicast Addresses |
| Wikipedia: Unique Local Address<sup>[27](https://en.wikipedia.org/wiki/Unique_local_address){:rel="noopener noreferrer" target="blank"}</sup> | ULA overview and comparison |
| GL.iNet WireGuard Forum<sup>[28](https://forum.gl-inet.com/t/how-to-set-up-glinet-as-wireguard-client/50289/7){:rel="noopener noreferrer" target="blank"}</sup> | WireGuard client configuration on GL.iNet routers |
| WireGuard Firewall Rules<sup>[29](https://www.cyberciti.biz/faq/how-to-set-up-wireguard-firewall-rules-in-linux/){:rel="noopener noreferrer" target="blank"}</sup> | iptables integration for WireGuard |
| WgServerforWindows Issue 206<sup>[30](https://github.com/micahmo/WgServerforWindows/issues/206){:rel="noopener noreferrer" target="blank"}</sup> | Windows WireGuard server issue tracker |

---

## LLM and AI Development

| Resource | Description |
|----------|-------------|
| vLLM Windows (SystemPanic)<sup>[31](https://github.com/SystemPanic/vllm-windows/releases/tag/v0.22.1){:rel="noopener noreferrer" target="blank"}</sup> | Unofficial vLLM Windows builds |
| vLLM Tool Parser (Rust)<sup>[32](https://github.com/vllm-project/vllm/tree/main/rust/src/tool-parser/src){:rel="noopener noreferrer" target="blank"}</sup> | vLLM tool parser Rust source |
| vLLM Tool Template (Gemma4)<sup>[33](https://github.com/vllm-project/vllm/blob/main/examples/tool_chat_template_gemma4.jinja){:rel="noopener noreferrer" target="blank"}</sup> | Gemma 4 tool chat template |
| vLLM Gemma4 Parser<sup>[34](https://github.com/vllm-project/vllm/blob/main/rust/src/tool-parser/src/gemma4.rs){:rel="noopener noreferrer" target="blank"}</sup> | Gemma 4 tool parser implementation |
| OpenAI Developer Meetups<sup>[35](https://developers.openai.com/community/meetups){:rel="noopener noreferrer" target="blank"}</sup> | Regional developer community events |
| Hermes Agent (Nous Research)<sup>[36](https://hermes-agent.nousresearch.com/){:rel="noopener noreferrer" target="blank"}</sup> | Autonomous AI agent framework |

---

## vLLM and PyTorch Configuration

| Resource | Description |
|----------|-------------|
| vLLM v0.21.0 Release<sup>[37](https://github.com/vllm-project/vllm/releases/tag/v0.21.0){:rel="noopener noreferrer" target="blank"}</sup> | vLLM stable release notes |
| vLLM GPU Installation<sup>[38](https://docs.vllm.ai/en/v0.21.0/getting_started/installation/gpu/#pre-built-wheels){:rel="noopener noreferrer" target="blank"}</sup> | Official GPU installation guide |
| torch.compile Documentation<sup>[39](https://docs.pytorch.org/docs/2.12/generated/torch.compile.html){:rel="noopener noreferrer" target="blank"}</sup> | PyTorch torch.compile reference |
| vLLM Nightly Wheels<sup>[40](https://wheels.vllm.ai/nightly/cu130/vllm/){:rel="noopener noreferrer" target="blank"}</sup> | Pre-built nightly wheel index |
| Stack Overflow: torch.compile usage<sup>[41](https://stackoverflow.com/questions/75886125){:rel="noopener noreferrer" target="blank"}</sup> | Proper torch.compile configuration |
| Stack Overflow: Extra index URLs pip<sup>[42](https://stackoverflow.com/questions/38925928){:rel="noopener noreferrer" target="blank"}</sup> | Multiple PyPI index configuration |
| DeepWiki vLLM<sup>[43](https://deepwiki.com/vllm-project/vllm/3.1-enginecore-and-client-apis){:rel="noopener noreferrer" target="blank"}</sup> | Community vLLM documentation |

---

## Model Weights and Fine-Tuning

| Resource | Description |
|----------|-------------|
| sHEL1562 Gemma-4 A4B in NVFP4<sup>[44](https://huggingface.co/sHEL1562/gemma-4-A4B-it-MoE-HERETIC-nvfp4-blackwell/blob/main/README.md){:rel="noopener noreferrer" target="blank"}</sup> | Gemma-4 MoE HERETIC model for 5090/windows |
| AEON-7 Gemma-4-26B<sup>[45](https://huggingface.co/AEON-7/Gemma-4-26B-A4B-it-Uncensored-NVFP4){:rel="noopener noreferrer" target="blank"}</sup> | Uncensored Gemma-4 26B variant |
| AEON-7 SuperGemma4<sup>[46](https://huggingface.co/AEON-7/supergemma4-26b-abliterated-multimodal-nvfp4){:rel="noopener noreferrer" target="blank"}</sup> | Multimodal abliterated variant |
| DavidAU DECKARD<sup>[47](https://huggingface.co/DavidAU/gemma-4-19B-A4B-it-The-DECKARD-Heretic-Uncensored-Thinking){:rel="noopener noreferrer" target="blank"}</sup> | Gemma-4 DECKARD uncensored |
| LilaRest Gemma-4-31B<sup>[48](https://huggingface.co/LilaRest/gemma-4-31B-it-NVFP4-turbo/discussions/8){:rel="noopener noreferrer" target="blank"}</sup> | Gemma-4 31B NVFP4 turbo |
| nvidia Gemma-4-26B NVFP4<sup>[49](https://huggingface.co/nvidia/Gemma-4-26B-A4B-NVFP4){:rel="noopener noreferrer" target="blank"}</sup> | NVIDIA official NVFP4 weights |
| Google Gemma-4 Template<sup>[50](https://huggingface.co/google/gemma-4-26B-A4B-it/blob/main/chat_template.jinja){:rel="noopener noreferrer" target="blank"}</sup> | Official Gemma-4 chat template |

---

## pi.dev Package Registry

| Resource | Description |
|----------|-------------|
| pi.dev Packages<sup>[51](https://pi.dev/packages){:rel="noopener noreferrer" target="blank"}</sup> | pi.dev package registry |
| RPiv Advisor<sup>[52](https://pi.dev/packages/@juicesharp/rpiv-advisor){:rel="noopener noreferrer" target="blank"}</sup> | AI advisor package |
| RPiv Ask User<sup>[53](https://pi.dev/packages/@juicesharp/rpiv-ask-user-question){:rel="noopener noreferrer" target="blank"}</sup> | User interaction package |
| RPiv Todo<sup>[54](https://pi.dev/packages/@juicesharp/rpiv-todo){:rel="noopener noreferrer" target="blank"}</sup> | Task management package |
| A5C AI Babysitter<sup>[55](https://pi.dev/packages/@a5c-ai/babysitter-pi){:rel="noopener noreferrer" target="blank"}</sup> | AI babysitter agent |
| Plan Notator<sup>[56](https://pi.dev/packages/@plannotator/pi-extension){:rel="noopener noreferrer" target="blank"}</sup> | Planning extension |
| pi Lens<sup>[57](https://pi.dev/packages/pi-lens){:rel="noopener noreferrer" target="blank"}</sup> | Lens interface package |
| pi Simplify<sup>[58](https://pi.dev/packages/pi-simplify){:rel="noopener noreferrer" target="blank"}</sup> | Content simplification |
| Nitra Cursor<sup>[59](https://pi.dev/packages/@nitra/cursor){:rel="noopener noreferrer" target="blank"}</sup> | Cursor integration |

---

## News Aggregators

| Resource | Description |
|----------|-------------|
| Hacker News<sup>[60](https://news.ycombinator.com/){:rel="noopener noreferrer" target="blank"}</sup> | Technology and startup news |
| HN Item 48150431<sup>[61](https://news.ycombinator.com/item?id=48150431){:rel="noopener noreferrer" target="blank"}</sup> | Specific discussion thread |

---

## Related Pages

- [Wikispace](../wikispace/index.md) — Core technical documentation
- [Projects](../projects/index.md) — Project-specific documentation

## Related Deep Hole

- [Stack Overflow: Delayed expansion with exclamation marks in data](https://stackoverflow.com/questions/10558316/example-of-delayed-expansion-in-batch-file) — Toggle pattern for exclamation marks in filenames
- [SS64 Forum: Delayed expansion bugs and pipe behavior](https://ss64.org/viewtopic.php?t=27) — Pipe creates new cmd.exe instances without delayed expansion
- [Stack Overflow: Batch string manipulation techniques](https://stackoverflow.com/questions/5837418) — Substring extraction and replacement
- [Stack Overflow: findstr regex limitations](https://stackoverflow.com/questions/8921253) — Why findstr regex is not fully Perl-compatible
- [Server Fault: iptables best practices](https://serverfault.com/questions/46637) — Firewall rule ordering and efficiency
- [Stack Overflow: IPv6 iptables rules not working](https://stackoverflow.com/questions/27412632) — Common ip6tables pitfalls
- [OpenWrt Wiki: WireGuard setup](https://openwrt.org/docs/guide-user/services/vpn/wireguard/basics) — Router-grade WireGuard configuration
"""

let render() = file
