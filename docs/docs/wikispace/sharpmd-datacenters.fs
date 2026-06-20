module ConvertedFiles.Docs.Wikispace.DatacentersMd

let file = System.String.Join("\"\"\"", [|
    """# Datacenters and Network Infrastructure

Physical and virtual infrastructure for network service deployment, covering colocation services, GL.iNet router configuration with WireGuard, Unique Local Address (ULA) networking, and the Florida datacenter market.

---

## Overview

???+ note "What this page covers"
    This page documents physical and virtual network infrastructure:

    - **Colocation Services** — 1U hosting, power, bandwidth, and remote hands
    - **Florida Datacenters** — Cologix Lakeland, Equinix Miami, Fort Meade development
    - **WireGuard VPN** — Router-integrated tunneling with cryptographic specifications
    - **ULA Networking** — IPv6 private addressing for WireGuard tunnels
    - **Monitoring Tools** — Satellite tracking and global event monitoring

    For GL.iNet router-specific configuration, see [GL.iNet / LuCI](glinet-luci.md). For dedicated WireGuard server setup, see [WireGuard Server](wireguard-server.md). For IPv6 addressing details, see [IPv6](ipv6.md).

---

## Colocation Services

Colocation (colo) is the practice of housing privately-owned servers and networking equipment in a third-party datacenter. The colocation provider supplies the building, cooling, power, bandwidth, and physical security while the customer provides the hardware.

### Hosting Model Hierarchy

```mermaid
flowchart TD
    subgraph Control["Control Level Spectrum"]
        direction LR
        OP["On-Premises<br/>Full Control"]
        CO["Colocation<br/>Hardware + Software"]
        DS["Dedicated<br/>Software Only"]
        CL["Cloud/VPS<br/>Limited"]
    end

    subgraph Provider["Provider Responsibility"]
        direction LR
        P1["None<br/>(you manage all)"]
        P2["Facility<br/>(power, cooling, net)"]
        P3["Hardware + Facility"]
        P4["Everything"]
    end

    OP -->|"Increasing provider responsibility"| CO --> DS --> CL
    P1 --> P2 --> P3 --> P4

    style OP fill:#4a90d9
    style CL fill:#7ed321
```

### Colocation vs. Other Hosting Models

| Model | Hardware Owner | Infrastructure Provider | Control Level |
|-------|---------------|------------------------|---------------|
| On-premises | Organization | Organization | Full |
| Colocation | Organization | Datacenter operator | Hardware/software |
| Dedicated server | Provider | Provider | Software only |
| VPS/Cloud | Provider | Provider | Limited |

### 1U Colocation

1U (1 rack unit) colocation is the smallest standard server footprint, measuring 1.75 inches (44.45 mm) in height. A standard 42U rack can house up to 42 1U servers.

Typical 1U colocation package inclusions:

- 1U of rack space in a shared or private cabinet
- Power allocation (typically 1-2 amps at 120V or 208V)
- Network port (1 Gbps standard, 10 Gbps available)
- IP address allocation (typically /29 or /30 IPv4, /64 IPv6)
- Remote hands service (hourly rate or included hours)
- Uninterruptible power supply (UPS) and generator backup
- Environmental monitoring (temperature, humidity)

### Key Colocation Providers — Florida Region

| Provider | Location | Features |
|----------|----------|----------|
| Cologix | Lakeland, FL; Jacksonville, FL | Carrier-neutral, AWS Direct Connect |
| Equinix | Miami, FL (MI1) | Major peering hub for Latin America |
| DRT | Jacksonville, FL | Wholesale and retail colocation |
| Summit IG | Lakeland, FL | Dark fiber availability |

---

## Cologix Lakeland

Cologix operates a datacenter at 2850 Interstate Drive in Lakeland, Florida. The facility offers:

- Carrier-neutral network access
- Cross-connects to multiple Tier 1 and Tier 2 carriers
- Direct cloud on-ramps (AWS, Azure, Google Cloud)
- Compliance certifications: SOC 2 Type II, HIPAA
- 24/7 security and remote hands

### Cloudflare CNI (Cloudflare Network Interconnect)

Cologix Lakeland is listed as a Cloudflare CNI location, enabling private connectivity between customer infrastructure and Cloudflare's network without traversing the public internet.

---

## Bohler Places LLC / Fort Meade

Fort Meade, Florida has been identified as a developing datacenter location. The area benefits from:

- Florida's lack of state income tax
- Geographic separation from hurricane-prone coastal regions
- Proximity to Tampa metropolitan area
- Land availability for large-scale campus development

---

## WireGuard VPN

WireGuard is a layer 3 secure VPN tunneling protocol designed for simplicity and performance. It uses modern cryptographic primitives and operates with a minimal codebase compared to IPsec and OpenVPN.

### Protocol Characteristics

```mermaid
flowchart TD
    subgraph Crypto["Cryptographic Primitives"]
        direction TB
        C1["Curve25519<br/>ECDH Key Exchange"]
        C2["ChaCha20-Poly1305<br/>AEAD Encryption"]
        C3["BLAKE2s<br/>Hashing"]
        C4["SipHash24<br/>Hash Table Keying"]
    end

    subgraph Transport["Transport"]
        T1["UDP Only<br/>(No TCP fallback)"]
        T2["Port 51820<br/>(configurable)"]
        T3["1-RTT Handshake"]
        T4["Seamless Roaming"]
    end

    REQ["Connection Request"] --> Crypto
    Crypto --> Transport
    Transport --> EST["Established Tunnel"]

    style Crypto fill:#4a90d9
    style Transport fill:#7ed321
```

| Feature | Implementation |
|---------|---------------|
| Cryptography | Curve25519 (ECDH), ChaCha20-Poly1305 (AEAD), BLAKE2s, SipHash24 |
| Transport | UDP only (no TCP fallback) |
| Port | Configurable; default 51820/UDP |
| Key exchange | Static public/private key pairs; optional pre-shared key |
| Roaming | Seamlessly handles changing client IP addresses |
| Handshake | 1-RTT with crypto key routing |

### Configuration

WireGuard uses a simple INI-style configuration file:

```ini
[Interface]
PrivateKey = <server_private_key>
Address = 10.200.200.1/24
ListenPort = 51820
PostUp = iptables -A FORWARD -i %i -j ACCEPT; iptables -t nat -A POSTROUTING -o eth0 -j MASQUERADE
PostDown = iptables -D FORWARD -i %i -j ACCEPT; iptables -t nat -D POSTROUTING -o eth0 -j MASQUERADE

[Peer]
PublicKey = <client_public_key>
AllowedIPs = 10.200.200.2/32
```

### GL.iNet Router Integration

GL.iNet travel routers support WireGuard client mode through their OpenWrt-based firmware. Configuration steps:

1. Navigate to the router's web admin panel
2. Select VPN > WireGuard Client
3. Add a new tunnel (manual configuration or QR code import)
4. Paste the WireGuard client configuration
5. Activate the tunnel

The GL.iNet forum provides community-maintained configurations for various VPN providers. Custom WireGuard server configurations are supported via manual input.

---

## Unique Local Address (ULA) Networking

RFC 4193 defines Unique Local Addresses for IPv6 private networks. ULAs are globally unique (with high probability due to random global ID generation) but not routable on the public internet.

### ULA vs. IPv4 Private Addresses

| Aspect | IPv4 (RFC 1918) | IPv6 (RFC 4193, ULA) |
|--------|----------------|---------------------|
| Prefix | 10.0.0.0/8, 172.16.0.0/12, 192.168.0.0/16 | fc00::/7 (fd00::/8 in practice) |
| Uniqueness | Same prefixes reused everywhere | Random global ID provides uniqueness |
| NAT required | Yes, for internet access | No (IPv6 uses global addresses alongside ULAs) |
| Scope | Site-local | Site-local, but globally unique |

### ULA Prefix Generation

The recommended method generates a random 40-bit global ID:

```python
import secrets

def generate_ula():
    """
    """Generate a random ULA prefix per RFC 4193."""
    """
    global_id = secrets.token_hex(5)  # 40 bits
    return f"fd{global_id[:2]}:{global_id[2:6]}:{global_id[6:10]}::/48"

# Example: fd1a:2b3c:4d5e::/48
```

### WireGuard with ULA

Using ULAs for the WireGuard tunnel network avoids conflicts with the LAN addressing scheme:

```ini
[Interface]
PrivateKey = ...
Address = fd12:3456:789a:1::1/64
ListenPort = 51820

[Peer]
PublicKey = ...
AllowedIPs = fd12:3456:789a:1::2/128, 10.0.0.0/24
```

---

## Network Monitoring Tools

| Tool | URL | Purpose |
|------|-----|---------|
| KeepTrack | https://app.keeptrack.space | Satellite and space object tracking |
| World Monitor | https://world-monitor.com | Global event monitoring |
| OSIRIS AI | https://osirisai.vercel.app | AI-powered monitoring dashboard |

---

## Related Pages

- [WireGuard Server](wireguard-server.md) — Dedicated WireGuard server configuration
- [GL.iNet / LuCI](glinet-luci.md) — Router firmware and LuCI interface
- [IPv6](ipv6.md) — IPv6 addressing and ULA details
- [Hetzner Sovereign](hetzner-sovereign.md) — VPS deployment for VPN endpoints

## Related Deep Hole

- [Cologix Service Brochures](https://cologix.com/resources/service-brochures/) — Colocation buyer's guide and service documentation
- [Colocation America: 1U Colocation Guide](https://www.colocationamerica.com/colocation/1u-colocation) — 1U colocation specifications and pricing
- [Datacenter Map](https://www.datacentermap.com/) — Global datacenter location database
- [RFC 4193: Unique Local IPv6 Unicast Addresses](https://www.rfc-editor.org/rfc/rfc4193) — ULA specification
- [GL.iNet Forum: WireGuard Client Setup](https://forum.gl-inet.com/t/how-to-set-up-glinet-as-wireguard-client/50289/7) — Community guide for router WireGuard configuration
- [nixCraft: WireGuard Firewall Rules](https://www.cyberciti.biz/faq/how-to-set-up-wireguard-firewall-rules-in-linux/) — iptables/ip6tables integration with WireGuard
- [Bing Search: 1U Datacenter Rent](https://www.bing.com/search?q=1U+datacenter+rent) — Market pricing research
- [Datacenter Dynamics: Fort Meade Campus](https://www.datacenterdynamics.com/en/news/44-million-sq-ft-data-center-campus-gets-zoning-approval-in-fort-meade-florida/) — 4.4 million sq ft campus zoning approval
"""
|])

let render() = file
