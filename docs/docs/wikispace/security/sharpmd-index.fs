module ConvertedFiles.Docs.Wikispace.Security.IndexMd

let file = """# Security

Security in the sHEL project is organized as a series of strength layers, each addressing a different attack surface. The principle is defense in depth: no single mechanism provides complete protection, but the combination of minimal attack surface, strict permissions, encryption, and controlled exposure creates a system that is resistant to both targeted attacks and opportunistic intrusion.

---

## Layer Model

```mermaid
flowchart TD
    subgraph "Application Layer"
        L1["/"]
    end
    subgraph "Data Protection"
        L3["3. Encryption"]
        L4["4. Steganography"]
        L5["5. Compression"]
        L6["6. Encoding"]
    end
    subgraph "Access Control"
        L2["2. Permissions"]
        L1["1. Minimalism"]
    end
    subgraph "Isolation"
        L7["7. Containerization"]
        L8["8. Hypervisors"]
    end
    subgraph "Exposure"
        L9["9. Hosting"]
    end
    
    L1 --> L2 --> L3 --> L7 --> L9
    L3 -.-> L4
    L3 -.-> L5
    L3 -.-> L6
    L7 --> L8
    
    style L1 fill:#2d5a3a,color:#fff
    style L9 fill:#5a3a2d,color:#fff
```

| Layer | Principle | Scope | Documentation |
|-------|-----------|-------|---------------|
| 1 | [Minimalism](minimalism.md) | Reduce attack surface by removing unnecessary components | Service disabling, legacy protocols |
| 2 | [Permissions](permissions.md) | Control access through least-privilege assignment | ACLs, UAC, icacls |
| 3 | [Encryption](encryption.md) | Protect data confidentiality at rest and in transit | AES, RSA, TLS/SSL |
| 4 | [Steganography](steganography.md) | Hide data existence within carrier media | LSB encoding |
| 5 | [Compression](compression.md) | Reduce data footprint before transmission | DEFLATE, LZMA, Brotli |
| 6 | [Encoding](encoding.md) | Transform data for safe transport through restricted channels | Base64, URL, HTML |
| 7 | [Containerization](containerization.md) | Isolate applications from host system resources | Docker, Podman |
| 8 | [Hypervisors](hypervisors.md) | Hardware-level isolation through virtual machine separation | Xen, KVM, Qubes |
| 9 | [Hosting](hosting.md) | Control physical and network exposure of services | Nginx, TLS, CDN |

---

## Sections

- [Strength through Minimalism](minimalism.md) — Reducing attack surface by eliminating unnecessary services, protocols, and software
- [Strength through Permissions](permissions.md) — Access control, ACL management, and least-privilege principles
- [Strength through Encryption](encryption.md) — Symmetric and asymmetric encryption, key management, TLS/SSL
- [Steganography](steganography.md) — Hiding data within images, audio, and other carrier media
- [Compression](compression.md) — Lossless and lossy compression algorithms for data reduction
- [Encoding](encoding.md) — Base64, URL encoding, HTML entities, and character set transformation
- [Containerization](containerization.md) — Docker, Podman, and application isolation
- [Hypervisors](hypervisors.md) — Qubes OS, Proxmox VE, Xen vs KVM, VFIO PCI passthrough
- [Hosting a Website](hosting.md) — Web server hardening, CDN configuration, and deployment security

---

## OSI Model Security Mapping

Network security controls map to specific layers of the OSI model. Understanding this mapping ensures that defensive measures are applied at the correct layer for maximum effectiveness.

| OSI Layer | Function | Security Controls |
|-----------|----------|-------------------|
| 7 — Application | HTTP, DNS, SMTP | WAF, input validation, secure coding |
| 6 — Presentation | TLS/SSL, encoding | Certificate pinning, cipher suite selection |
| 5 — Session | Session management | Token-based auth, session timeout |
| 4 — Transport | TCP/UDP, port numbers | iptables/ip6tables, port knocking, WireGuard |
| 3 — Network | IP, routing | IPsec, ACLs, reverse path filtering |
| 2 — Data Link | Ethernet, Wi-Fi | MAC filtering, VLAN segmentation, WPA3 |
| 1 — Physical | Cables, radio | Physical locks, Faraday cages, fiber taps |

!!! warning "Layer 4 and Below"
    Firewall rules in iptables/ip6tables operate at the network and transport layers (Layers 3-4). These rules cannot inspect application-layer content. For HTTP-specific filtering, an application-layer firewall or proxy (Layer 7) such as Nginx with ModSecurity is required alongside the Layer 3-4 rules.

---

## Related Deep Hole

- [NIST SP 800-53: Security and Privacy Controls](https://csrc.nist.gov/publications/detail/sp/800-53/rev-5/final) — Federal information security control catalog
- [OWASP Top Ten](https://owasp.org/www-project-top-ten/) — Most critical web application security risks
- [CIS Controls](https://www.cisecurity.org/controls) — Center for Internet Security prioritized controls
- [Microsoft Security Compliance Toolkit](https://www.microsoft.com/download/details.aspx?id=55319) — Windows security baseline configurations
"""

let render() = file
