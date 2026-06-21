module ConvertedFiles.Docs.Wikispace.DnsMd

let file = """# DNS, iptables, ip6tables, IANA and IPv6

Network infrastructure configuration covering DNS resolution, firewall rules using iptables and ip6tables, IANA port assignments, and IPv6 addressing. This section consolidates the protocols and tools required for network service deployment.

---

## Overview

???+ note "What this page covers"
    This page provides consolidated reference material for core network infrastructure:

    - **DNS Resolution** — Recursive and authoritative nameserver operation, public resolver comparison, record type reference
    - **iptables/ip6tables** — IPv4/IPv6 packet filtering, table structure, chain flow, and production rulesets
    - **IANA Port Assignments** — Official port number ranges and common service registry
    - **IPv6 Addressing** — Address types, ULA generation, subnetting, and Windows configuration

    For advanced iptables match extensions and detailed chain traversal, see [iptables Deep Dive](iptables-deep.md). For dedicated IPv6 documentation including firewall integration, see [IPv6](ipv6.md). For IANA protocol numbers and OSI layer mapping, see [IANA Standards](iana-standards.md).

---

## DNS Resolution

The Domain Name System translates human-readable hostnames into IP addresses. DNS resolution operates hierarchically, with recursive resolvers caching responses from authoritative nameservers.

### DNS Resolution Hierarchy

```mermaid
flowchart TD
    Client["Stub Resolver<br/>(client)"] -->|"Query: example.com"| Recursor["Recursive Resolver<br/>(1.1.1.1, 8.8.8.8)"]
    Recursor -->|"Cache hit"| Client
    Recursor -->|"Query root"| Root["Root Nameserver<br/>(.)"]
    Root -->|"Referral: .com TLD"| Recursor
    Recursor -->|"Query TLD"| TLD["TLD Nameserver<br/>(.com)"]
    TLD -->|"Referral: ns1.example.com"| Recursor
    Recursor -->|"Query authoritative"| Auth["Authoritative Nameserver<br/>(example.com)"]
    Auth -->|"A: 93.184.216.34"| Recursor
    Recursor -->|"Response + cache TTL"| Client
```

### Public DNS Resolvers

| Provider | IPv4 Address | IPv6 Address | Protocols |
|----------|-------------|--------------|-----------|
| Cloudflare | 1.1.1.1, 1.0.0.1 | 2606:4700:4700::1111 | DNS53, DoH, DoT |
| Cloudflare (malware blocking) | 1.1.1.2, 1.0.0.2 | 2606:4700:4700::1112 | DNS53, DoH, DoT |
| Quad9 | 9.9.9.9, 149.112.112.112 | 2620:fe::fe | DNS53, DoH, DoT |
| Google | 8.8.8.8, 8.8.4.4 | 2001:4860:4860::8888 | DNS53, DoH, DoT |
| OpenDNS | 208.67.222.222, 208.67.220.220 | 2620:119:35::35 | DNS53 |

### DNS Record Types

| Type | Purpose | Example |
|------|---------|---------|
| A | IPv4 address record | `example.com. 300 IN A 93.184.216.34` |
| AAAA | IPv6 address record | `example.com. 300 IN AAAA 2606:2800:220:1::` |
| CNAME | Canonical name (alias) | `www.example.com. CNAME example.com.` |
| MX | Mail exchanger | `example.com. MX 10 mail.example.com.` |
| NS | Authoritative nameserver | `example.com. NS ns1.example.com.` |
| TXT | Text record (SPF, DKIM) | `example.com. TXT "v=spf1 include:_spf.example.com ~all"` |
| SRV | Service locator | `_sip._tcp.example.com. SRV 10 5 5060 sipserver.` |
| SOA | Start of authority | Zone transfer and refresh parameters |
| PTR | Pointer (reverse DNS) | `34.216.184.93.in-addr.arpa. PTR example.com.` |

---

## iptables

iptables is the netfilter administration tool for IPv4 packet filtering, network address translation (NAT), and packet mangling on Linux systems.

### Table Structure

iptables operates across five tables, each handling different packet processing stages:

| Table | Purpose | Chains |
|-------|---------|--------|
| `filter` | Packet filtering (default) | INPUT, FORWARD, OUTPUT |
| `nat` | Network address translation | PREROUTING, POSTROUTING, OUTPUT |
| `mangle` | Packet header modification | All chains |
| `raw` | Connection tracking exemption | PREROUTING, OUTPUT |
| `security` | Mandatory access control | INPUT, FORWARD, OUTPUT |

### Packet Flow Through netfilter Hooks

```mermaid
flowchart TD
    IN["Packet Arrives<br/>(NIC)"] --> PRE["PREROUTING<br/>(raw, mangle, nat)"]
    PRE --> RT{"Routing<br/>Decision"}
    RT -->|"Local<br/>destination"| L1["INPUT<br/>(mangle, filter, security)"]
    RT -->|"Forward"| FWD["FORWARD<br/>(mangle, filter, security)"]
    RT -->|"Local<br/>process"| OUT["OUTPUT<br/>(raw, mangle, nat, filter, security)"]
    L1 --> LP["Local Process<br/>(user space)"]
    LP --> OUT
    FWD --> POST1["POSTROUTING<br/>(mangle, nat)"]
    OUT --> POST2["POSTROUTING<br/>(mangle, nat)"]
    POST1 --> DEST["To Destination"]
    POST2 --> DEST

    style IN fill:#4a90d9
    style DEST fill:#4a90d9
    style LP fill:#7ed321
```

### Basic Ruleset

```bash
#!/bin/bash
# Flush existing rules
iptables -F
iptables -X
iptables -t nat -F
iptables -t nat -X

# Default policies
iptables -P INPUT DROP
iptables -P FORWARD DROP
iptables -P OUTPUT ACCEPT

# Allow established and related connections
iptables -A INPUT -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT

# Allow loopback
iptables -A INPUT -i lo -j ACCEPT

# Allow SSH with rate limiting
iptables -A INPUT -p tcp --dport 22 -m conntrack --ctstate NEW -m recent --set --name SSH
iptables -A INPUT -p tcp --dport 22 -m conntrack --ctstate NEW -m recent --update --seconds 60 --hitcount 4 --name SSH -j DROP
iptables -A INPUT -p tcp --dport 22 -j ACCEPT

# Allow HTTP/HTTPS
iptables -A INPUT -p tcp -m multiport --dports 80,443 -j ACCEPT

# Allow DNS
iptables -A INPUT -p udp --dport 53 -j ACCEPT
iptables -A INPUT -p tcp --dport 53 -j ACCEPT

# ICMP (ping)
iptables -A INPUT -p icmp --icmp-type echo-request -j ACCEPT

# Log dropped packets
iptables -A INPUT -j LOG --log-prefix "iptables-dropped: " --log-level 4
iptables -A INPUT -j DROP
```

### Rule Target Actions

| Target | Action |
|--------|--------|
| `ACCEPT` | Allow packet through |
| `DROP` | Silently discard packet |
| `REJECT` | Discard with ICMP error response |
| `LOG` | Log packet details to syslog |
| `DNAT` | Destination NAT (port forwarding) |
| `SNAT` | Source NAT (outbound masquerade) |
| `MASQUERADE` | Dynamic source NAT |

---

## ip6tables

ip6tables is the IPv6 equivalent of iptables. The command syntax is identical, but the protocol context differs.

### Critical Differences from iptables

- ICMPv6 is required for IPv6 neighbor discovery (address resolution) and must not be completely blocked
- IPv6 does not use NAT in standard configurations (NAT66 exists but is discouraged)
- Stateless Address Autoconfiguration (SLAAC) relies on Router Solicitation/Advertisement messages

### ICMPv6 Message Types

| Type | Purpose | Firewall Rule |
|------|---------|---------------|
| Type 128 | Echo Request (ping) | Allow selectively |
| Type 129 | Echo Reply | Allow with ESTABLISHED |
| Type 133 | Router Solicitation | Allow from LAN |
| Type 134 | Router Advertisement | Allow from routers |
| Type 135 | Neighbor Solicitation | Essential — allow |
| Type 136 | Neighbor Advertisement | Essential — allow |
| Type 137 | Redirect | Allow from routers |

### IPv6 Ruleset

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

# ICMPv6 (essential for IPv6 operation)
ip6tables -A INPUT -p ipv6-icmp -j ACCEPT

# SSH
ip6tables -A INPUT -p tcp --dport 22 -j ACCEPT

# HTTP/HTTPS
ip6tables -A INPUT -p tcp -m multiport --dports 80,443 -j ACCEPT

# Log and drop
ip6tables -A INPUT -j LOG --log-prefix "ip6tables-dropped: "
ip6tables -A INPUT -j DROP
```

---

## IANA Port Assignments

IANA maintains the authoritative registry of service names and port numbers (RFC 6335). Port numbers are divided into three ranges:

```mermaid
flowchart LR
    subgraph WellKnown["Well-Known Ports (0-1023)"]
        direction TB
        W1["HTTP: 80"]
        W2["HTTPS: 443"]
        W3["SSH: 22"]
        W4["DNS: 53"]
    end

    subgraph User["Registered Ports (1024-49151)"]
        direction TB
        U1["OpenVPN: 1194"]
        U2["WireGuard: 51820"]
        U3["DNS over TLS: 853"]
    end

    subgraph Dynamic["Dynamic Ports (49152-65535)"]
        direction TB
        D1["Ephemeral client<br/>source ports"]
    end

    WellKnown --> User --> Dynamic

    style WellKnown fill:#4a90d9
    style User fill:#f5a623
    style Dynamic fill:#7ed321
```

| Range | Name | Assignment Authority |
|-------|------|---------------------|
| 0-1023 | System (Well-Known) Ports | IANA, requires IETF Review |
| 1024-49151 | User (Registered) Ports | IANA, Expert Review process |
| 49152-65535 | Dynamic (Private/Ephemeral) Ports | Not assigned; local use |

### Common Service Port Reference

| Port | Protocol | Service |
|------|----------|---------|
| 20/21 | TCP | FTP (data/control) |
| 22 | TCP | SSH |
| 25 | TCP | SMTP |
| 53 | UDP/TCP | DNS |
| 67/68 | UDP | DHCP (server/client) |
| 80 | TCP | HTTP |
| 110 | TCP | POP3 |
| 143 | TCP | IMAP |
| 443 | TCP | HTTPS |
| 465 | TCP | SMTPS (legacy) |
| 587 | TCP | SMTP (submission) |
| 853 | TCP | DNS over TLS |
| 993 | TCP | IMAPS |
| 995 | TCP | POP3S |
| 1194 | UDP | OpenVPN |
| 3389 | TCP | RDP |
| 51820 | UDP | WireGuard |
| 8443 | TCP | HTTPS (alternate) |

---

## IPv6 Addressing

### Address Types

| Type | Prefix | Example | Purpose |
|------|--------|---------|---------|
| Global Unicast | 2000::/3 | 2001:db8::1 | Routable internet addresses |
| Unique Local | fc00::/7 | fd00:1234::1 | Private networks (RFC 4193) |
| Link-Local | fe80::/10 | fe80::1%eth0 | Single-link communication |
| Multicast | ff00::/8 | ff02::1 | One-to-many delivery |
| Loopback | ::1/128 | ::1 | Local host |
| Unspecified | ::/128 | :: | No address assigned |

### Unique Local Addresses (ULA)

RFC 4193 defines Unique Local Addresses for private IPv6 networks, analogous to RFC 1918 private IPv4 addresses. A ULA prefix has the format `fd00::/8` where the 40 bits following `fd` are the global ID.

```
ULA Prefix Structure:
  +--+----+----+----+----+----+----+----+
  |fd| Global ID (40 bits)  | Subnet  |
  +--+----+----+----+----+----+----+----+
   8       40                    16    = 64 bits

Example: fd12:3456:789a::/48
         |fd|123456789a|0000| :: | /48
```

ULA generation (using random global ID):

```bash
# Generate random ULA prefix
GLOBAL_ID=$(openssl rand -hex 5)
echo "fd${GLOBAL_ID:0:2}:${GLOBAL_ID:2:4}:${GLOBAL_ID:6:4}::/48"
# Example output: fd1a:2b3c:4d5e::/48
```

### IPv6 Subnetting

A standard IPv6 subnet uses a /64 prefix, yielding 64 bits for interface identifiers:

```
ISP allocation:     2001:db8:1234::/48
Site:               2001:db8:1234:0000::/56  (256 subnets)
VLAN/Subnet:        2001:db8:1234:0001::/64  (18 quintillion host addresses)
Host:               2001:db8:1234:0001::1/128
```

### IPv6 Configuration on Windows

```powershell
# View IPv6 addresses
Get-NetIPAddress -AddressFamily IPv6 | Select-Object IPAddress, PrefixLength, InterfaceAlias

# View IPv6 routes
Get-NetRoute -AddressFamily IPv6

# Ping IPv6
ping -6 ::1
Test-Connection -TargetName "2001:db8::1" -IPv6

# DNS lookup over IPv6
Resolve-DnsName -Name example.com -Type AAAA
```

---

## DNS-over-HTTPS (DoH)

DNS-over-HTTPS encrypts DNS queries within HTTPS connections, preventing on-path observers from reading query contents.

### Configuration

```powershell
# Windows 11: Configure DoH via Settings or registry
# Registry path for DoH configuration:
# HKLM:\System\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers

# Add DoH server
$regPath = "HKLM:\System\CurrentControlSet\Services\Dnscache\Parameters\DohWellKnownServers"
New-Item -Path "$regPath\1.1.1.1" -Force
Set-ItemProperty -Path "$regPath\1.1.1.1" -Name "Template" -Value "https://cloudflare-dns.com/dns-query"

# Flush DNS cache
Clear-DnsClientCache
```

---

## Related Pages

- [iptables Deep Dive](iptables-deep.md) — Advanced match extensions, custom chains, performance optimization
- [IPv6](ipv6.md) — Dedicated IPv6 addressing, subnetting, and firewall configuration
- [IANA Standards](iana-standards.md) — Protocol numbers, OSI layer mappings, assignment procedures
- [WireGuard Server](wireguard-server.md) — VPN tunnel configuration with iptables integration

## Related Deep Hole

- [RFC 6335: IANA Port Number Procedures](https://datatracker.ietf.org/doc/rfc6335/) — Official IANA port management procedures
- [IANA Service Name and Port Number Registry](https://www.iana.org/assignments/service-names-port-numbers) — Live port database
- [RFC 4193: Unique Local IPv6 Unicast Addresses](https://www.rfc-editor.org/rfc/rfc4193) — ULA specification
- [nixCraft: Linux IPTables Firewall Examples](https://www.cyberciti.biz/tips/linux-iptables-examples.html) — Practical iptables rulesets
- [RFC 8200: Internet Protocol, Version 6 (IPv6) Specification](https://datatracker.ietf.org/doc/html/rfc8200) — IPv6 protocol standard
- [WireGuard Firewall Rules on Linux](https://www.cyberciti.biz/faq/how-to-set-up-wireguard-firewall-rules-in-linux/) — iptables integration with WireGuard
"""

let render() = file
