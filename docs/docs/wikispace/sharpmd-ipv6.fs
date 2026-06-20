module ConvertedFiles.Docs.Wikispace.Ipv6Md

let file = """# IPv6

Internet Protocol version 6 is the successor to IPv4, designed to address address exhaustion and improve network efficiency. This page covers IPv6 addressing, subnetting, Unique Local Addresses, and firewall configuration. For broader network security topics, see the [DNS and Firewall](dns.md) page.

---

## Overview

???+ note "What this page covers"
    This page provides comprehensive IPv6 reference material:

    - **Address Format** — 128-bit representation, compression rules per RFC 5952
    - **Address Types** — Global unicast, ULA, link-local, multicast, and special addresses
    - **Unique Local Addresses** — Private IPv6 networking per RFC 4193 with random generation
    - **Subnetting** — Hierarchical allocation from /48 to /64
    - **Windows Configuration** — PowerShell cmdlets for IPv6 management
    - **IPv6 Firewall** — ip6tables ruleset with ICMPv6 considerations
    - **VPN Integration** — WireGuard with ULA addressing

    For IPv4 firewall configuration and DNS integration, see [DNS and Firewall](dns.md). For WireGuard VPN setup with IPv6, see [WireGuard Server](wireguard-server.md).

---

## Address Format

IPv6 addresses are 128-bit identifiers written as eight 16-bit hexadecimal groups separated by colons:

```
Full form:      2001:0db8:85a3:0000:0000:8a2e:0370:7334
Compressed:     2001:db8:85a3::8a2e:370:7334
Loopback:       ::1
Unspecified:    ::
```

Compression rules (RFC 5952):

- Leading zeros within each group may be omitted (`0db8` becomes `db8`)
- One group of consecutive all-zero sections may be replaced with `::`
- The `::` shortcut can only be used once per address

---

## Address Types

```mermaid
flowchart TD
    IPv6["IPv6 Address Space<br/>128 bits"]
    IPv6 --> GU["Global Unicast<br/>2000::/3"]
    IPv6 --> ULA["Unique Local<br/>fc00::/7"]
    IPv6 --> LL["Link-Local<br/>fe80::/10"]
    IPv6 --> MC["Multicast<br/>ff00::/8"]
    IPv6 --> SPEC["Special"]
    SPEC --> LO["Loopback<br/>::1/128"]
    SPEC --> UNS["Unspecified<br/>::/128"]

    GU -->|"Internet-routable"| GUEX["2001:db8::1"]
    ULA -->|"Private networks"| ULAEX["fd00:1234::1"]
    LL -->|"Single segment"| LLEX["fe80::1%eth0"]
    MC -->|"All-nodes local"| MCEX["ff02::1"]

    style GU fill:#4a90d9
    style ULA fill:#7ed321
    style LL fill:#f5a623
    style MC fill:#bd10e0
    style LO fill:#9013fe
    style UNS fill:#9013fe
```

| Type | Prefix | Example | Scope |
|------|--------|---------|-------|
| Global Unicast | 2000::/3 | 2001:db8::1 | Internet-routable |
| Unique Local | fc00::/7 | fd00:1234::1 | Private networks (RFC 4193) |
| Link-Local | fe80::/10 | fe80::1%eth0 | Single network segment |
| Multicast | ff00::/8 | ff02::1 | All-nodes on local segment |
| Loopback | ::1/128 | ::1 | Local host only |
| Unspecified | ::/128 | :: | No address assigned |

---

## Unique Local Addresses (ULA)

RFC 4193 defines Unique Local Addresses for private IPv6 networks. The `fc00::/7` prefix is reserved, but in practice only `fd00::/8` is used (`fd` prefix with random global ID).

### ULA Prefix Structure

```
    8 bits      40 bits        16 bits       64 bits
  +--------+-------------+-------------+-------------+
  | 11111101| Global ID   |  Subnet ID  | Interface ID |
  +--------+-------------+-------------+-------------+

Example: fd12:3456:789a:0001::/64
         |fd|123456789a|0001|     ::     |
```

### Generating a Random ULA Prefix

```bash
# Method 1: OpenSSL
GLOBAL_ID=$(openssl rand -hex 5)
echo "fd${GLOBAL_ID:0:2}:${GLOBAL_ID:2:4}:${GLOBAL_ID:6:4}::/48"

# Method 2: /dev/urandom
printf "fd%02x:%02x%02x:%02x%02x::/48\n" $(od -An -tx1 -N5 /dev/urandom)

# Example output: fd1a:2b3c:4d5e::/48
```

---

## Subnetting

IPv6 standard practice allocates a /64 prefix per subnet, leaving 64 bits for interface identifiers (typically derived from MAC addresses via EUI-64 or randomly generated via privacy extensions).

```mermaid
flowchart TD
    ISP["ISP Allocation<br/>2001:db8:1234::/48"]
    ISP --> S56["Site /56<br/>2001:db8:1234:ab00::/56<br/>(256 subnets)"]
    ISP --> S56B["Site /56<br/>2001:db8:1234:cd00::/56<br/>(256 subnets)"]
    S56 --> S64A["Subnet /64<br/>2001:db8:1234:ab01::/64"]
    S56 --> S64B["Subnet /64<br/>2001:db8:1234:ab02::/64"]
    S56 --> S64N["Subnet /64<br/>2001:db8:1234:abff::/64"]
    S64A --> H1["Host<br/>2001:db8:1234:ab01::1/128"]
    S64A --> H2["Host<br/>2001:db8:1234:ab01::2/128"]

    style ISP fill:#4a90d9
    style S56 fill:#7ed321
    style S64A fill:#f5a623
```

| Allocation | Prefix | Subnets | Hosts per Subnet |
|------------|--------|---------|-----------------|
| /48 (site) | fd00:1234:5678::/48 | 65,536 (/64 each) | 18 quintillion |
| /56 (small site) | fd00:1234:5678:ab00::/56 | 256 | 18 quintillion |
| /64 (subnet) | fd00:1234:5678:ab01::/64 | 1 | 18 quintillion |

```
Site allocation:    fd00:1234:5678::/48
  Subnet 1:         fd00:1234:5678:0001::/64
  Subnet 2:         fd00:1234:5678:0002::/64
  Subnet 255:       fd00:1234:5678:00ff::/64
  Subnet 256:       fd00:1234:5678:0100::/64
```

---

## Windows IPv6 Configuration

```powershell
# View all IPv6 addresses
Get-NetIPAddress -AddressFamily IPv6 | Select-Object IPAddress, PrefixLength, InterfaceAlias

# View IPv6 routes
Get-NetRoute -AddressFamily IPv6

# Disable IPv6 on a specific adapter
Disable-NetAdapterBinding -Name "Ethernet" -ComponentID ms_tcpip6

# Ping IPv6
ping -6 ::1
Test-Connection -TargetName "2001:db8::1" -IPv6

# DNS AAAA record lookup
Resolve-DnsName -Name google.com -Type AAAA
```

---

## IPv6 Firewall (ip6tables)

IPv6 requires special firewall considerations. ICMPv6 must be permitted for neighbor discovery (address resolution), and DHCPv6 or Router Advertisements may be needed depending on the configuration method.

```mermaid
flowchart TD
    P6["IPv6 Packet"] --> PRE6["PREROUTING"]
    PRE6 --> RT6{"Routing"}
    RT6 -->|"Local"| IN6["INPUT"]
    RT6 -->|"Forward"| FWD6["FORWARD"]
    IN6 -->|"Established"| ACC6["ACCEPT"]
    IN6 -->|"Loopback"| ACC6
    IN6 -->|"ICMPv6<br/>Neighbor Discovery"| ACC6
    IN6 -->|"SSH/HTTP/HTTPS"| ACC6
    IN6 -->|"Log + Drop"| DROP6["LOG + DROP"]

    style ACC6 fill:#7ed321
    style DROP6 fill:#d0021b
```

```bash
#!/bin/bash
ip6tables -F
ip6tables -X

ip6tables -P INPUT DROP
ip6tables -P FORWARD DROP
ip6tables -P OUTPUT ACCEPT

# Established connections
ip6tables -A INPUT -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT

# Loopback
ip6tables -A INPUT -i lo -j ACCEPT

# ICMPv6 (required for IPv6 operation)
ip6tables -A INPUT -p ipv6-icmp -j ACCEPT

# SSH
ip6tables -A INPUT -p tcp --dport 22 -j ACCEPT

# HTTP/HTTPS
ip6tables -A INPUT -p tcp -m multiport --dports 80,443 -j ACCEPT

# DNS
ip6tables -A INPUT -p udp --dport 53 -j ACCEPT
ip6tables -A INPUT -p tcp --dport 53 -j ACCEPT

# WireGuard
ip6tables -A INPUT -p udp --dport 51820 -j ACCEPT

# Log and drop
ip6tables -A INPUT -j LOG --log-prefix "ip6tables-dropped: " --log-level 4
ip6tables -A INPUT -j DROP
```

---

## IPv6 and VPN Integration

Using IPv6 inside a VPN tunnel avoids NAT issues and provides end-to-end connectivity:

```mermaid
flowchart LR
    subgraph SiteA["Site A"]
        WA["WireGuard Peer<br/>fd12:3456:789a:1::1/64"]
        D1["Device<br/>fd12:3456:789a:1::10"]
    end

    subgraph Tunnel["WireGuard Tunnel"]
        T1["UDP/51820<br/>Encrypted"]
    end

    subgraph SiteB["Site B"]
        WB["WireGuard Peer<br/>fd12:3456:789a:1::2/64"]
        D2["Device<br/>fd12:3456:789a:1::20"]
    end

    WA --> T1
    T1 --> WB
    WA --> D1
    WB --> D2
    D1 <-->|"End-to-end IPv6<br/>No NAT"| D2

    style Tunnel fill:#4a90d9
```

```ini
# WireGuard with ULA addressing
[Interface]
PrivateKey = ...
Address = fd12:3456:789a:1::1/64, 10.200.200.1/24
ListenPort = 51820

[Peer]
PublicKey = ...
AllowedIPs = fd12:3456:789a:1::2/128, 10.200.200.2/32
```

---

## Related Pages

- [DNS and Firewall](dns.md) — IPv4/IPv6 firewall rules, DNS resolution, IANA ports
- [WireGuard Server](wireguard-server.md) — VPN tunnel configuration with IPv6 ULA addressing
- [iptables Deep Dive](iptables-deep.md) — Advanced firewall match extensions and optimization

## Related Deep Hole

- [RFC 4193: Unique Local IPv6 Unicast Addresses](https://www.rfc-editor.org/rfc/rfc4193) — ULA specification
- [RFC 8200: Internet Protocol, Version 6 (IPv6)](https://datatracker.ietf.org/doc/html/rfc8200) — IPv6 protocol standard
- [RFC 5952: A Recommendation for IPv6 Address Text Representation](https://datatracker.ietf.org/doc/html/rfc5952) — Address formatting rules
- [Wikipedia: IPv6](https://en.wikipedia.org/wiki/IPv6) — Comprehensive IPv6 overview
- [Wikipedia: Unique Local Address](https://en.wikipedia.org/wiki/Unique_local_address) — ULA comparison with RFC 1918
"""

let render() = file
