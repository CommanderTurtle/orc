module ConvertedFiles.Docs.Wikispace.IptablesDeepMd

let file = """# iptables Deep Dive

iptables is the netfilter administration tool for IPv4 packet filtering, network address translation (NAT), and packet mangling on Linux systems. This page provides a comprehensive low-level reference for iptables rule construction, target actions, match extensions, and advanced filtering techniques.

---

## Overview

???+ note "What this page covers"
    Comprehensive low-level iptables reference: rule construction, all match extensions (TCP flags, state, limit, multiport, iprange, string, recent, time, owner), NAT targets, complete rulesets, and nftables migration. For DNS and IPv6 firewall configuration, see [DNS and Firewall](dns.md) and [IPv6](ipv6.md). For IANA port assignments, see [IANA Internet Standards](iana-standards.md).

---

## Table Structure

iptables operates across five tables, each handling different packet processing stages:

| Table | Purpose | Chains |
|-------|---------|--------|
| `filter` | Packet filtering (default) | INPUT, FORWARD, OUTPUT |
| `nat` | Network address translation | PREROUTING, POSTROUTING, OUTPUT |
| `mangle` | Packet header modification | PREROUTING, INPUT, FORWARD, OUTPUT, POSTROUTING |
| `raw` | Connection tracking exemption | PREROUTING, OUTPUT |
| `security` | Mandatory access control | INPUT, FORWARD, OUTPUT |

### Packet Flow Through Tables and Chains

```mermaid
flowchart TD
    P["Packet Arrives"] --> PRE["PREROUTING<br/>raw, mangle, nat"]
    PRE --> R{"Routing<br/>Decision"}
    R -->|"Local"| IN["INPUT<br/>mangle, filter, security"]
    R -->|"Forward"| FWD["FORWARD<br/>mangle, filter, security"]
    IN --> LP["Local Process"]
    LP --> OUT["OUTPUT<br/>raw, mangle, nat, filter, security"]
    FWD --> POST1["POSTROUTING<br/>mangle, nat"]
    OUT --> POST2["POSTROUTING<br/>mangle, nat"]
    POST1 --> D["To Destination"]
    POST2 --> D
    
    style P fill:#333,color:#fff
    style PRE fill:#5a3a2d,color:#fff
    style IN fill:#2d5a3a,color:#fff
    style FWD fill:#2d5a3a,color:#fff
    style LP fill:#4a7c59,color:#fff
    style D fill:#333,color:#fff
```

---

## Rule Structure

```
iptables [-t table] command [chain] [matches...] [target/jump]
```

### Commands

| Command | Short | Description |
|---------|-------|-------------|
| `--append` | `-A` | Append rule to chain |
| `--insert` | `-I` | Insert rule at position |
| `--delete` | `-D` | Delete rule by number or match |
| `--replace` | `-R` | Replace rule at position |
| `--list` | `-L` | List rules in chain |
| `--flush` | `-F` | Delete all rules in chain |
| `--zero` | `-Z` | Zero packet/byte counters |
| `--new-chain` | `-N` | Create a new user-defined chain |
| `--delete-chain` | `-X` | Delete user-defined chain |
| `--policy` | `-P` | Set default policy for built-in chain |
| `--rename-chain` | `-E` | Rename user-defined chain |

### Rule Specification Parameters

| Parameter | Description | Example |
|-----------|-------------|---------|
| `-p, --protocol` | Protocol (tcp, udp, icmp, all) | `-p tcp` |
| `-s, --source` | Source address/mask | `-s 192.168.1.0/24` |
| `-d, --destination` | Destination address/mask | `-d 10.0.0.1` |
| `-i, --in-interface` | Input interface | `-i eth0` |
| `-o, --out-interface` | Output interface | `-o eth1` |
| `-j, --jump` | Target to jump to | `-j ACCEPT` |
| `-g, --goto` | Go to user chain | `-g mychain` |
| `!` | Invert match | `! -s 192.168.1.1` |

---

## Target Actions

### Basic Targets

| Target | Description | Use Case |
|--------|-------------|----------|
| `ACCEPT` | Allow packet to proceed | Permit traffic |
| `DROP` | Silently discard packet | Block without notification |
| `REJECT` | Discard with ICMP error | Block with notification |
| `LOG` | Log packet details | Auditing, debugging |
| `RETURN` | Return from user chain | Chain exit |
| `QUEUE` | Pass to userspace | Custom processing |

### NAT Targets

| Target | Table | Description |
|--------|-------|-------------|
| `SNAT` | nat | Source NAT (fixed IP) |
| `MASQUERADE` | nat | Source NAT (dynamic IP) |
| `DNAT` | nat | Destination NAT |
| `REDIRECT` | nat | Redirect to local port |

### REJECT Options

```bash
# Reject with specific ICMP type
iptables -A INPUT -p tcp --dport 22 -j REJECT --reject-with tcp-reset
iptables -A INPUT -p icmp -j REJECT --reject-with icmp-host-unreachable
iptables -A INPUT -p udp --dport 53 -j REJECT --reject-with icmp-port-unreachable
```

### LOG Options

```bash
# Log with prefix and level
iptables -A INPUT -j LOG --log-prefix "iptables-input: " --log-level 4

# Limit logging rate
iptables -A INPUT -j LOG --log-prefix "flood: " -m limit --limit 2/min

# Log specific TCP flags
iptables -A INPUT -p tcp --tcp-flags ALL NONE -j LOG --log-prefix "null scan: "
```

---

## Match Extensions

### TCP Matches (`-p tcp`)

| Match | Description | Example |
|-------|-------------|---------|
| `--dport` | Destination port | `--dport 80` or `--dport 1000:2000` |
| `--sport` | Source port | `--sport 1024:65535` |
| `--tcp-flags` | TCP flags check | `--tcp-flags SYN,RST,ACK SYN` |
| `--syn` | SYN flag set (shorthand) | `--syn` |
| `--tcp-option` | TCP option number | `--tcp-option 8` (timestamp) |

### TCP Flag Checking

```bash
# Common flag combinations for security

# Block null scans (no flags set)
iptables -A INPUT -p tcp --tcp-flags ALL NONE -j DROP

# Block XMAS scans (FIN, PSH, URG)
iptables -A INPUT -p tcp --tcp-flags ALL FIN,PSH,URG -j DROP

# Block SYN/RST combination (invalid)
iptables -A INPUT -p tcp --tcp-flags SYN,RST SYN,RST -j DROP

# Allow established connections
iptables -A INPUT -p tcp --tcp-flags ALL ACK,RST,SYN,FIN -m state --state ESTABLISHED -j ACCEPT

# Allow SYN for new connections
iptables -A INPUT -p tcp --syn -m state --state NEW -j ACCEPT
```

### UDP Matches (`-p udp`)

| Match | Description | Example |
|-------|-------------|---------|
| `--dport` | Destination port | `--dport 53` |
| `--sport` | Source port | `--sport 53` |

### ICMP Matches (`-p icmp`)

| Match | Description | Example |
|-------|-------------|---------|
| `--icmp-type` | ICMP type | `--icmp-type echo-request` |

Common ICMP types:

| Type | Name | Code | Description |
|------|------|------|-------------|
| 0 | echo-reply | 0 | Ping reply |
| 3 | destination-unreachable | various | Host/port/network unreachable |
| 5 | redirect | 0-3 | Router redirect |
| 8 | echo-request | 0 | Ping request |
| 11 | time-exceeded | 0-1 | TTL expired |
| 12 | parameter-problem | 0 | Bad IP header |

### State Match (`-m state` / `-m conntrack`)

```bash
# Classic state match (iptables)
iptables -A INPUT -m state --state ESTABLISHED,RELATED -j ACCEPT

# Modern conntrack match (nftables-compatible)
iptables -A INPUT -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT

# States:
#   NEW        - First packet of new connection
#   ESTABLISHED - Part of existing connection
#   RELATED    - New connection related to existing (FTP data, ICMP error)
#   INVALID    - Packet that conntrack cannot process
#   UNTRACKED  - Packet marked to bypass conntrack (raw table)
```

### Limit Match (`-m limit`)

```bash
# Rate limit new SSH connections
iptables -A INPUT -p tcp --dport 22 -m state --state NEW \
    -m limit --limit 3/minute --limit-burst 5 -j ACCEPT

# Parameters:
#   --limit rate      - Maximum average rate (3/minute, 1/second, 5/hour)
#   --limit-burst num - Initial burst capacity (default 5)
```

### Multiport Match (`-m multiport`)

```bash
# Match multiple ports efficiently
iptables -A INPUT -p tcp -m multiport --dports 80,443,8080 -j ACCEPT
iptables -A INPUT -p tcp -m multiport --sports 22,80,443 -j ACCEPT

# Maximum 15 ports per rule
```

### IP Range Match (`-m iprange`)

```bash
# Match a range of IPs without CIDR
iptables -A INPUT -m iprange --src-range 192.168.1.10-192.168.1.50 -j ACCEPT
iptables -A INPUT -m iprange --dst-range 10.0.0.1-10.0.0.100 -j DROP
```

### String Match (`-m string`)

```bash
# Block packets containing specific strings
iptables -A INPUT -p tcp --dport 80 -m string --string "恶意请求" --algo bm -j DROP

# Algorithms: bm (Boyer-Moore), kmp (Knuth-Morris-Pratt)
# --from offset, --to offset - search range in packet
```

### Recent Match (`-m recent`)

```bash
# SSH brute force protection
iptables -A INPUT -p tcp --dport 22 -m state --state NEW \
    -m recent --set --name ssh_attempts

iptables -A INPUT -p tcp --dport 22 -m state --state NEW \
    -m recent --update --seconds 60 --hitcount 4 --name ssh_attempts -j DROP

iptables -A INPUT -p tcp --dport 22 -m state --state NEW -j ACCEPT

# Parameters:
#   --set               - Add source IP to list
#   --update            - Update existing entry
#   --seconds N         - Time window
#   --hitcount N        - Maximum hits in window
#   --name listname     - Named list
#   --rcheck            - Check without updating
#   --remove            - Remove matching entry
```

### Time Match (`-m time`)

```bash
# Allow SSH only during business hours
iptables -A INPUT -p tcp --dport 22 -m time \
    --timestart 09:00 --timestop 17:00 \
    --weekdays Mon,Tue,Wed,Thu,Fri \
    --datestart 2024-01-01 --datestop 2024-12-31 \
    -j ACCEPT

iptables -A INPUT -p tcp --dport 22 -j DROP
```

### Owner Match (`-m owner`)

```bash
# Allow specific user to access network
iptables -A OUTPUT -m owner --uid-owner 1000 -j ACCEPT

# Allow specific group
iptables -A OUTPUT -m owner --gid-owner 1000 -j ACCEPT

# Match by process ID
iptables -A OUTPUT -m owner --pid-owner 1234 -j ACCEPT
```

---

## Complete Firewall Rulesets

### Minimal Secure Server

```bash
#!/bin/bash
iptables -F
iptables -X
iptables -t nat -F
iptables -t mangle -F

# Default policies
iptables -P INPUT DROP
iptables -P FORWARD DROP
iptables -P OUTPUT ACCEPT

# Allow loopback
iptables -A INPUT -i lo -j ACCEPT

# Allow established
iptables -A INPUT -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT

# ICMP (limited)
iptables -A INPUT -p icmp --icmp-type echo-request -m limit --limit 1/second -j ACCEPT
iptables -A INPUT -p icmp --icmp-type destination-unreachable -j ACCEPT
iptables -A INPUT -p icmp --icmp-type time-exceeded -j ACCEPT

# SSH with rate limiting
iptables -A INPUT -p tcp --dport 22 -m conntrack --ctstate NEW \
    -m recent --set --name ssh
iptables -A INPUT -p tcp --dport 22 -m conntrack --ctstate NEW \
    -m recent --update --seconds 60 --hitcount 4 --name ssh -j DROP
iptables -A INPUT -p tcp --dport 22 -m conntrack --ctstate NEW -j ACCEPT

# HTTP/HTTPS
iptables -A INPUT -p tcp -m multiport --dports 80,443 -j ACCEPT

# DNS
iptables -A INPUT -p udp --dport 53 -j ACCEPT

# Log and drop everything else
iptables -A INPUT -j LOG --log-prefix "iptables-dropped: " --log-level 4 -m limit --limit 5/min
iptables -A INPUT -j DROP
```

### NAT Gateway

```bash
#!/bin/bash
# Enable IP forwarding
sysctl -w net.ipv4.ip_forward=1

# NAT for LAN to WAN
iptables -t nat -A POSTROUTING -o eth0 -j MASQUERADE

# Forward established
iptables -A FORWARD -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT

# Forward from LAN
iptables -A FORWARD -i eth1 -o eth0 -j ACCEPT

# Port forwarding example
iptables -t nat -A PREROUTING -p tcp --dport 8080 -j DNAT --to-destination 192.168.1.100:80
iptables -A FORWARD -p tcp -d 192.168.1.100 --dport 80 -j ACCEPT
```

---

## ip6tables

ip6tables uses identical syntax to iptables but operates on IPv6 packets:

```bash
#!/bin/bash
ip6tables -F
ip6tables -X

ip6tables -P INPUT DROP
ip6tables -P FORWARD DROP
ip6tables -P OUTPUT ACCEPT

# Established
ip6tables -A INPUT -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT

# Loopback
ip6tables -A INPUT -i lo -j ACCEPT

# ICMPv6 (ESSENTIAL for IPv6)
ip6tables -A INPUT -p ipv6-icmp -j ACCEPT

# SSH
ip6tables -A INPUT -p tcp --dport 22 -j ACCEPT

# HTTP/HTTPS
ip6tables -A INPUT -p tcp -m multiport --dports 80,443 -j ACCEPT

# Log and drop
ip6tables -A INPUT -j LOG --log-prefix "ip6tables-dropped: "
ip6tables -A INPUT -j DROP
```

### Critical ICMPv6 Types

| Type | Purpose | Firewall Rule |
|------|---------|---------------|
| Type 128 | Echo Request (ping) | Allow selectively |
| Type 129 | Echo Reply | Allow with ESTABLISHED |
| Type 133 | Router Solicitation | Allow from LAN |
| Type 134 | Router Advertisement | Allow from routers |
| Type 135 | Neighbor Solicitation | Essential - allow |
| Type 136 | Neighbor Advertisement | Essential - allow |
| Type 137 | Redirect | Allow from routers |

---

## nftables Migration

iptables is deprecated in favor of nftables (since Linux 3.13). Key differences:

| Feature | iptables | nftables |
|---------|----------|----------|
| Syntax | Multiple tools (iptables, ip6tables, ebtables) | Single tool (nft) |
| Performance | Less efficient | Better performance |
| Ruleset atomic update | No | Yes |
| User-defined chains | Limited | Full support |
| Set/Map support | ipset module | Native |
| Debugging | Limited | Built-in tracing |

### nftables Equivalent Example

```bash
#!/usr/sbin/nft -f

flush ruleset

table inet filter {
    chain input {
        type filter hook input priority 0; policy drop;
        
        # Loopback
        iif "lo" accept
        
        # Established
        ct state established,related accept
        
        # ICMP
        ip protocol icmp icmp type { echo-request, destination-unreachable, time-exceeded } accept
        ip6 nexthdr icmpv6 icmpv6 type { echo-request, 133-137 } accept
        
        # SSH with rate limiting
        tcp dport 22 ct state new limit rate 3/minute burst 5 packets accept
        
        # HTTP/HTTPS
        tcp dport { 80, 443 } accept
        
        # Log and drop
        log prefix "nftables-dropped: " limit rate 5/minute
        drop
    }
    
    chain forward {
        type filter hook forward priority 0; policy drop;
    }
    
    chain output {
        type filter hook output priority 0; policy accept;
    }
}
```

---

## Related Deep Hole

- [iptables Tutorial](https://www.netfilter.org/documentation/) — Official netfilter documentation
- [iptables man page](https://ipset.netfilter.org/iptables.man.html) — Complete command reference
- [Debian iptables Wiki](https://wiki.debian.org/iptables) — Practical examples
- [nixCraft: Linux IPTables Firewall Examples](https://www.cyberciti.biz/tips/linux-iptables-examples.html) — Practical rulesets
- [RFC 6146: Stateful NAT64](https://datatracker.ietf.org/doc/html/rfc6146) — NAT64 specification
- [nftables Documentation](https://wiki.nftables.org/) — Next-generation firewall
"""

let render() = file
