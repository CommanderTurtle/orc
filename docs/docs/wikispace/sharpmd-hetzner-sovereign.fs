module ConvertedFiles.Docs.Wikispace.HetznerSovereignMd

let file = """# Sovereign Network Infrastructure

Building a sovereign network infrastructure using Hetzner as the public edge, with private routing back to home networks via WireGuard tunnels. This architecture provides public IPv6 hosting without requiring an Autonomous System Number (ASN) or BGP peering.

---

## Overview

???+ note "What this page covers"
    Sovereign network infrastructure using Hetzner as the public edge: ASN acquisition (ARIN/RIPE/sponsoring LIR), NAT64/DNS64, ZeroTier controller hosting, and Qubes OS deployment. For WireGuard configuration, see [WireGuard Server](wireguard-server.md). For ZeroTier specifics, see [ZeroTier](zerotier.md). For datacenter selection, see [Datacenters and Network Infrastructure](datacenters.md).

---

## Private vs Global Routing

Two distinct networking models exist, with different requirements:

### Private Routing (No ASN Required)

| Capability | Available? |
|------------|-----------|
| Host public services on Hetzner | Yes |
| Use Hetzner's IPv6 /64 or /48 | Yes |
| Tunnel traffic home via WireGuard | Yes |
| NAT64/NAT66 for home LAN | Yes |
| Route ULA or SLAAC addresses home | Yes |
| Expose home services through Hetzner | Yes |
| Work behind CGNAT at home | Yes |

This is the recommended model for most deployments. Hetzner serves as the public internet presence; the home network is a private extension behind it.

### Global Routing (ASN Required)

| Capability | Available? |
|------------|-----------|
| Own globally routable /48 prefix | Yes |
| Announce prefix via BGP | Yes |
| Move prefix between providers | Yes |
| Multi-homing (Hetzner + OVH + home) | Yes |
| Global IPv6 reachability at home | Yes |

This requires an ASN and Provider-Independent (PI) address space.

---

## ASN Acquisition

### ARIN (US/Canada)

| Item | Cost |
|------|------|
| Initial fee | $550 one-time |
| Annual maintenance | $150/year |
| Processing time | 1-2 weeks |
| Requirements | Multi-homing intent or technical justification |

### RIPE (Europe)

| Item | Cost |
|------|------|
| Membership | EUR 1,400/year |
| ASN | Free with membership |
| IPv6 PI | Free |
| Processing time | 1-3 days |

### Sponsoring LIR (Cheapest Path)

| Item | Cost |
|------|------|
| Initial fee | $50-$100 one-time |
| Annual fee | $50-$100/year |
| Processing time | 1-3 days |
| Jurisdiction | EU/GDPR |

A sponsoring LIR provides a "hosted ASN" — still globally valid and fully controlled by the applicant, but without direct RIR membership fees. This is the standard path for hobbyist and small-scale operators.

---

## Hetzner IPv6 Configuration

### Requesting a /48

1. Log into Hetzner Robot
2. Navigate to the server
3. Click **IPs**
4. Click **Request IPv6 Subnet**
5. Select **/48**
6. Submit

Hetzner routes the /48 to the server's link-local address. This is Provider-Assigned (PA) space — routable within Hetzner's AS but not portable to other providers.

### /48 Subnet Allocation

A /48 provides 65,536 /64 subnets:

```
Hetzner allocation:   2a01:4f8:xxxx:yyyy::/48
  Subnet 1 (VMs):     2a01:4f8:xxxx:yyyy:0001::/64
  Subnet 2 (VPN):     2a01:4f8:xxxx:yyyy:0002::/64
  Subnet 3 (containers): 2a01:4f8:xxxx:yyyy:0003::/64
  Subnet 65535:       2a01:4f8:xxxx:yyyy:ffff::/64
```

---

## NAT64/DNS64

For providing IPv4-only services over an IPv6 network, NAT64 translates IPv6 packets to IPv4, and DNS64 synthesizes AAAA records from A records.

```bash
# Install tayga (NAT64) and unbound (DNS64) on Debian/Ubuntu
apt install tayga unbound

# tayga configuration (/etc/tayga.conf)
mipv4-addr 192.168.255.1
prefix 64:ff9b::/96
dynamic-pool 192.168.255.0/24
data-dir /var/db/tayga

# unbound DNS64 configuration (/etc/unbound/unbound.conf.d/dns64.conf)
server:
    module-config: "dns64 validator iterator"
    dns64-prefix: 64:ff9b::/96
    dns64-synthall: yes
```

The Well-Known Prefix `64:ff9b::/96` (RFC 6052) is used for DNS64-synthesized addresses. IPv6 clients query the DNS64-enabled resolver; when only an A record exists, the resolver prepends `64:ff9b::` to the IPv4 address. The client then connects to that IPv6 address, and tayga translates the packet to IPv4.

---

## Hetzner as ZeroTier Controller Host

A Hetzner VPS provides the ideal platform for a self-hosted ZeroTier controller:

| Advantage | Description |
|-----------|-------------|
| Stable public IP | No CGNAT, no dynamic IP |
| No port forwarding | Direct UDP access |
| No relay fallback | Direct peer-to-peer connections |
| GDPR jurisdiction | EU data protection |
| 1 Gbps unmetered | No bandwidth concerns |

```bash
# Deploy ZeroTier controller on Hetzner VPS
docker run -d --name zt-controller --restart unless-stopped \
    -p 9993:9993/tcp -p 9993:9993/udp \
    -v zt-data:/var/lib/zerotier-one \
    zerotier/zerotier-controller

# Create and configure network
docker exec zt-controller zerotier-cli mknet
```

---

## Server Recommendation

| Specification | Hetzner AX41-NVMe |
|---------------|-------------------|
| CPU | AMD Ryzen 5 3600 (6c/12t) |
| RAM | 64 GB |
| Storage | 2 x 512 GB NVMe |
| Bandwidth | 1 Gbps unmetered (20 TB full speed, then 1 Gbps) |
| IPv4 | 1 included |
| IPv6 | /64 included, /48 on request |
| Monthly cost | EUR 34-40 |

This configuration supports: NAT64/DNS64, ZeroTier controller, WireGuard hub, Qubes/Xen nested virtualization, and multiple VM workloads simultaneously.

---

## Qubes OS on Hetzner

Qubes OS requires bare-metal access or nested virtualization support:

| Environment | Qubes Support |
|-------------|--------------|
| Hetzner Dedicated Server | Yes — boot custom ISO, full Xen control |
| Hetzner Cloud VM | No — no Xen/Hyper-V nesting |

For Qubes deployment on dedicated servers:

1. Order dedicated server with KVM console access
2. Upload Qubes OS ISO via Hetzner Robot
3. Mount ISO and boot
4. Install Qubes with default Xen hypervisor
5. Configure sys-net, sys-firewall, and app VMs

---

## Related Deep Hole

- [Hetzner Robot Documentation](https://robot.hetzner.com/doc/) — Server management
- [RFC 6052: IPv6 Addressing of IPv4/IPv6 Translators](https://datatracker.ietf.org/doc/html/rfc6052) — NAT64 prefix standard
- [RFC 6147: DNS64](https://datatracker.ietf.org/doc/html/rfc6147) — DNS synthesis specification
- [ARIN ASN Request](https://www.arin.net/resources/manage/asn/) — US ASN application
- [RIPE NCC ASN Request](https://www.ripe.net/manage-ips-and-asns/as-numbers/) — European ASN application
- [Hetzner research](user-provided) — Sovereign networking architecture decisions
"""

let render() = file
