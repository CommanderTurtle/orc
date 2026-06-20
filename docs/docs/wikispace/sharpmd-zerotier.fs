module ConvertedFiles.Docs.Wikispace.ZerotierMd

let file = """# ZeroTier

ZeroTier is a software-defined networking (SDN) platform that creates encrypted virtual Ethernet networks across physical network boundaries. It combines the ease of VPN setup with the flexibility of SD-WAN, enabling multi-site mesh networking without configuration of individual tunnel endpoints.

---

## Overview

???+ note "What this page covers"
    This page documents ZeroTier SDN deployment for sovereign mesh networking:

    - **Architecture** — Three-layer model: roots, controller, and peers
    - **Sovereignty Analysis** — Jurisdiction comparison: Central vs self-hosted controller
    - **Self-Hosted Controller** — Docker deployment on Hetzner or other VPS infrastructure
    - **Route Advertisement** — LAN subnet sharing between remote peers
    - **Exit Node Configuration** — Full-tunnel internet routing through ZeroTier

    For point-to-point VPN tunnels, see [WireGuard Server](wireguard-server.md). For Hetzner-specific deployment hardening, see [Hetzner Sovereign](hetzner-sovereign.md). For underlying firewall configuration, see [DNS and Firewall](dns.md).

---

## Architecture

ZeroTier operates with three conceptual layers:

```mermaid
flowchart TD
    subgraph Roots["Root Servers (Planet)"]
        R1["Root 1"]
        R2["Root 2"]
    end

    subgraph Controller["Network Controller"]
        C1["Member Authorization"]
        C2["IP Assignment"]
        C3["Route Management"]
    end

    subgraph Peers["Peer Nodes"]
        P1["Peer A<br/>(Home LAN)"]
        P2["Peer B<br/>(Remote)"]
        P3["Peer C<br/>(Mobile)"]
    end

    P1 <-->|"STUN/UDP hole punch<br/>or TCP fallback"| Roots
    P2 <-->|"STUN/UDP hole punch<br/>or TCP fallback"| Roots
    P3 <-->|"STUN/UDP hole punch<br/>or TCP fallback"| Roots
    P1 -->|"Network ID"| Controller
    P2 -->|"Network ID"| Controller
    P3 -->|"Network ID"| Controller
    P1 <-->|"Encrypted<br/>Ethernet frames"| P2
    P1 <-->|"Encrypted<br/>Ethernet frames"| P3
    P2 <-->|"Encrypted<br/>Ethernet frames"| P3

    style Controller fill:#4a90d9
    style Roots fill:#7ed321
```

| Layer | Component | Purpose |
|-------|-----------|---------|
| Roots | Global planet servers | Help nodes discover each other (can be self-hosted) |
| Controller | Network membership authority | Manages network ID, member authorization, IP assignments, routes |
| Peers | End devices | Connect to networks, route traffic |

When using ZeroTier Central (the hosted controller), network management occurs through the zero-tier.com web interface. When self-hosting, the `zerotier-one` package provides a local controller accessible via JSON API on port 9993.

---

## Protocol Comparison

| Technology | US-based | CLOUD Act | Central Service | Self-hostable | Best For |
|------------|----------|-----------|-----------------|---------------|----------|
| WireGuard | No (protocol only) | No | None | N/A | Point-to-point tunnels |
| ZeroTier Central | Yes | Yes | Required | Controller is | Mesh networks, SD-WAN |
| ZeroTier self-hosted | N/A | No | None | Yes | Sovereign mesh networking |
| Tailscale | Yes | Yes | Required | Via Headscale | WireGuard-based mesh |
| Headscale | N/A | No | None | Yes | Self-hosted Tailscale control |

!!! note "Sovereignty Implications"
    ZeroTier the company is US-based, and ZeroTier Central (the hosted service) falls under US jurisdiction. However, the protocol is open and the controller can be self-hosted. A self-hosted controller running on non-US infrastructure (e.g., Hetzner in Germany) is not subject to CLOUD Act requirements.

---

## ZeroTier Central vs Self-Hosted

| Feature | ZeroTier Central | Self-Hosted Controller |
|---------|-----------------|----------------------|
| Privacy | US CLOUD Act applies | GDPR jurisdiction (if EU-hosted) |
| Sovereignty | Low | High |
| Routing control | Limited | Full (custom routes, NAT, exit nodes) |
| Membership approval | Manual web UI | Automatic or custom logic |
| Custom logic | No | Yes (via API) |
| Offline operation | No (depends on Central) | Yes |
| CGNAT compatibility | Poor (relies on relays) | Excellent (direct control) |
| Cost | Free tier + paid plans | Free (VPS cost only) |

---

## Self-Hosted Controller Setup

### Server Requirements

- Linux VPS with public IPv4 and IPv6 (Hetzner, OVH, etc.)
- Docker (recommended) or native `zerotier-one` package
- No ASN, BGP, or PI space required

### Docker Deployment

```bash
# Create controller container
docker run -d \
    --name zerotier-controller \
    --restart unless-stopped \
    -p 9993:9993/tcp \
    -p 9993:9993/udp \
    -v zerotier-controller:/var/lib/zerotier-one \
    zerotier/zerotier-controller

# Create a network
docker exec zerotier-controller \
    zerotier-cli mknet
# Returns: <NETWORK_ID>

# Configure network (example: 192.168.192.0/24)
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> enableBroadcast=true
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> multicastLimit=32
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> private=true
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> ipv4.assignMode.zt=true
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> ipv4.pool.0.start=192.168.192.1
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> ipv4.pool.0.end=192.168.192.254
```

### Client Join

```bash
# Install ZeroTier client
# Linux:
curl -s https://install.zerotier.com | sudo bash

# Windows:
# Download MSI from zerotier.com

# Join network
zerotier-cli join <NETWORK_ID>

# Authorize member (on controller)
docker exec zerotier-controller \
    zerotier-cli auth <NETWORK_ID> <MEMBER_ADDRESS>

# Check status
zerotier-cli status
zerotier-cli listnetworks
```

---

## Route Advertisement

Self-hosted controllers can advertise routes for LAN subnets:

```mermaid
flowchart LR
    subgraph PeerA["Peer A (Home)"]
        ZTA["ZT: 192.168.192.10"]
        ETH["eth0: 192.168.1.0/24"]
        D1["Device: 192.168.1.50"]
        D2["Device: 192.168.1.51"]
    end

    subgraph ZT["ZeroTier Network<br/>192.168.192.0/24"]
        direction LR
    end

    subgraph PeerB["Peer B (Remote)"]
        ZTB["ZT: 192.168.192.20"]
    end

    ZTA --> ZT
    ZTB --> ZT
    ETH --> D1
    ETH --> D2
    ZTB -->|"Access 192.168.1.0/24<br/>via 192.168.192.10"| ETH

    style ZT fill:#4a90d9
```

```bash
# On controller: add route for client's home LAN
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> route.0.target=192.168.1.0/24
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> route.0.via=<ZEROTIER_CLIENT_IP>

# On client: enable IP forwarding and NAT for LAN
# Linux:
sysctl -w net.ipv4.ip_forward=1
iptables -t nat -A POSTROUTING -o eth0 -j MASQUERADE
```

This allows remote ZeroTier peers to access devices on the client's home LAN without individual tunnel configuration.

---

## Exit Node Configuration

Route all internet traffic through a specific ZeroTier peer:

```bash
# On the exit node peer
zerotier-cli set <NETWORK_ID> allowDefault=1

# On controller: add default route
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> route.1.target=0.0.0.0/0
docker exec zerotier-controller \
    zerotier-cli set <NETWORK_ID> route.1.via=<EXIT_NODE_ZT_IP>
```

---

## Related Pages

- [WireGuard Server](wireguard-server.md) — Point-to-point VPN tunnel configuration
- [Hetzner Sovereign](hetzner-sovereign.md) — VPS hardening for ZeroTier controller hosting
- [DNS and Firewall](dns.md) — iptables rules for ZeroTier interface filtering

## Related Deep Hole

- [ZeroTier Documentation](https://docs.zerotier.com/) — Official documentation
- [ZeroTier GitHub](https://github.com/zerotier/ZeroTierOne) — Source code
- [ZeroTier Self-Hosted Controller](https://docs.zerotier.com/self-hosting/controllers) — Controller setup guide
- [Hetzner research](user-provided) — Sovereign networking with ZeroTier on Hetzner
"""

let render() = file
