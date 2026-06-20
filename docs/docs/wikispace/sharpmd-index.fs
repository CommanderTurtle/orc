module ConvertedFiles.Docs.Wikispace.IndexMd

let file = """# Wikispace

The Wikispace is a curated knowledge base covering systems administration, networking, security, AI tooling, 2026 technologies, and development workflows. Each section documents practical configurations, exact commands, and tested procedures.

---

## Overview

???+ note "What this page covers"
    This page serves as the master index for the Wikispace knowledge base:

    - **Systems Administration** — Windows, iOS, WSL, applications, driver management
    - **Networking** — DNS, iptables, IPv6, router firmware, WireGuard, ZeroTier
    - **AI and Development** — Local LLM deployment, AI agent stack, modern technologies
    - **Security** — 9-layer defense-in-depth model with specialized subsections

    For the XML Project documentation, see [XML Project](../xml-project/index.md). For individual projects, see [Projects](../projects/index.md). For the curated external resource archive, see [Deep Hole](../deep-hole/index.md).

---

## Wikispace Structure

```mermaid
flowchart TD
    subgraph SysAdmin["Systems Administration"]
        direction TB
        S1["Windows Wiki"]
        S2["Windows Advanced"]
        S3["WSL Guide"]
        S4["iOS"]
        S5["Apps"]
        S6["Portmaster Deep"]
    end

    subgraph Networking["Networking"]
        direction TB
        N1["DNS / iptables"]
        N2["IPv6"]
        N3["WireGuard"]
        N4["ZeroTier"]
        N5["Router Firmware"]
        N6["Datacenters"]
    end

    subgraph AI["AI & Development"]
        direction TB
        A1["Local LLM"]
        A2["AI Agent Stack"]
        A3["Modern Objects 2026"]
    end

    subgraph Sec["Security"]
        direction TB
        SE1["9-Layer Model"]
        SE2["Minimalism"]
        SE3["Encryption"]
        SE4["Hypervisors"]
    end

    style SysAdmin fill:#4a90d9
    style Networking fill:#7ed321
    style AI fill:#f5a623
    style Sec fill:#9013fe
```

---

## Systems Administration

- [Windows Wiki](windows.md) — Windows setup walkthrough, system commands, registry, file operations
- [Windows Advanced](windows-advanced.md) — Group Policy DNS hardening, dcomcnfg, sysdm.cpl, taskschd.msc, services.msc, forests/AD
- [Microsoft Documentation](microsoft-learn.md) — PowerShell, Windows commands, .NET, Azure, M365, security baselines
- [Applications](apps.md) — Microsoft 365, VS Code workflows, driver management, package management
- [Portmaster Deep](portmaster-deep.md) — Advanced firewall rules, svchost analysis, Edge WebView2, IPv6 management
- [iOS](ios.md) — Configuration profiles, Shortcuts automation, hidden settings, native apps guide
- [WSL Guide](wsl.md) — WSL2 installation, Kali Linux, Windows integration, Qubes comparison

---

## Networking

- [DNS / iptables + ip6tables / IANA / IPv6](dns.md) — DNS resolution, firewall rules, port assignments
- [iptables Deep](iptables-deep.md) — Low-level iptables rule construction, match extensions, NAT, complete rulesets
- [IPv6](ipv6.md) — Dedicated IPv6 addressing, ULA subnetting, ip6tables, Windows configuration
- [IANA Internet Standards](iana-standards.md) — Protocol registries at every OSI layer, port assignments, MIME types
- [Router Firmware (OpenWRT / FreshTomato)](openwrt-freshtomato.md) — Third-party router firmware, DNS security, ad blocking
- [FreshTomato Infrastructure](freshtomato-infrastructure.md) — Full FreshTomato feature set, custom scripts, QoS
- [GL.iNet / LuCI](glinet-luci.md) — VLAN configuration, MLO Wi-Fi, Qualcomm NSS, nftables
- [OpenWRT LuCI](openwrt-luci.md) — Web interface documentation, CBI, custom pages, API
- [WireGuard Server](wireguard-server.md) — Windows WireGuard server setup, key management, NAT routing
- [ZeroTier](zerotier.md) — SDN mesh networking, self-hosted controller, sovereignty implications
- [Datacenters and Network Infrastructure](datacenters.md) — Colocation, WireGuard, GL.iNet, Cologix
- [Hetzner Sovereign](hetzner-sovereign.md) — ASN acquisition, NAT64/DNS64, ZeroTier controller hosting

---

## AI and Development

- [Local LLM Deployment](local-llm.md) — vLLM inference, quantization, torch.compile, hardware requirements
- [Modeling](modeling.md) — "Want to get into modeling?" — Ollama vs vLLM debate, AI agent stack, setup guides
- [AI Agent Stack](ai-agent-stack.md) — Terminal agents, IDE agents, model serving, redirect proxies
- [Modern Objects 2026](modern-objects-2026.md) — 18650 batteries, powerwalls, atmospheric water, solar, gadgets
- [DNN Analysis](dnn-analysis.md) — Hybrid web architecture, DotNetNuke, Giraffe ViewEngine comparison

---

## Security

- [Security Overview](security/index.md) — Defense in depth: 9-layer security model
- [Minimalism](security/minimalism.md) — Attack surface reduction, service disabling
- [Permissions](security/permissions.md) — ACL management, least-privilege principles
- [Encryption](security/encryption.md) — AES, RSA, TLS/SSL, key management
- [Steganography](security/steganography.md) — LSB data hiding in images and audio
- [Compression](security/compression.md) — Lossless and lossy compression algorithms
- [Encoding](security/encoding.md) — Base64, URL encoding, HTML entities
- [Containerization](security/containerization.md) — Docker, Podman, security constraints
- [Hypervisors](security/hypervisors.md) — Qubes OS, Proxmox, Xen vs KVM, VFIO passthrough
- [Hosting](security/hosting.md) — Web server hardening, TLS, DDoS mitigation

---

## OSI Layer Security Mapping

Network security controls map to specific OSI model layers. Controls at each layer are independent and complementary.

```mermaid
flowchart TD
    L7["Layer 7: Application<br/>HTTP, DNS, SMTP"] -->|"WAF, input validation"| L6
    L6["Layer 6: Presentation<br/>TLS/SSL, encoding"] -->|"Certificate pinning<br/>Cipher selection"| L5
    L5["Layer 5: Session<br/>Session management"] -->|"Token auth<br/>Session timeout"| L4
    L4["Layer 4: Transport<br/>TCP/UDP, ports"] -->|"iptables, WireGuard"| L3
    L3["Layer 3: Network<br/>IP, routing"] -->|"IPsec, ACLs, RPF"| L2
    L2["Layer 2: Data Link<br/>Ethernet, Wi-Fi"] -->|"MAC filter, VLAN, WPA3"| L1
    L1["Layer 1: Physical<br/>Cables, radio"] -->|"Physical locks<br/>Faraday cages"| END["Defense in Depth"]

    style L7 fill:#d0021b
    style L4 fill:#4a90d9
    style L1 fill:#7ed321
    style END fill:#f5a623
```

| Layer | Function | Security Controls |
|-------|----------|-------------------|
| 7 — Application | HTTP, DNS, SMTP | WAF, input validation, secure coding |
| 6 — Presentation | TLS/SSL, encoding | Certificate pinning, cipher suite selection |
| 5 — Session | Session management | Token-based auth, session timeout |
| 4 — Transport | TCP/UDP, port numbers | iptables/ip6tables, port knocking, WireGuard |
| 3 — Network | IP, routing | IPsec, ACLs, reverse path filtering |
| 2 — Data Link | Ethernet, Wi-Fi | MAC filtering, VLAN segmentation, WPA3 |
| 1 — Physical | Cables, radio | Physical locks, Faraday cages |

For detailed firewall configuration, see the [DNS and Firewall](dns.md) page or [iptables Deep](iptables-deep.md). For encryption and container security, see the [Security section](security/index.md).
"""

let render() = file
