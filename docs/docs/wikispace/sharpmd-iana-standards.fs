module ConvertedFiles.Docs.Wikispace.IanaStandardsMd

let file = """# IANA Internet Standards

The Internet Assigned Numbers Authority (IANA) maintains the registries and protocol parameters that define the operational standards of the internet. This page documents the key standards at every layer of the network stack, from physical addressing to application protocols.

---

## Overview

???+ note "What this page covers"
    IANA internet standards at every OSI layer: Ethernet (IEEE 802.3), Wi-Fi (802.11), MAC addresses, VLAN (802.1Q), IPv4/IPv6 addressing, TCP/UDP/ICMP ports, HTTP status codes, MIME types, and DNS record types. For firewall configuration using these standards, see [iptables Deep](iptables-deep.md). For DNS specifics, see [DNS and Firewall](dns.md). For IPv6, see [IPv6](ipv6.md).

---

## Standards Organizations

| Organization | Role | Key Publications |
|-------------|------|-------------------|
| IANA | Protocol parameter registries | Port numbers, MIME types, IP allocations |
| IETF | Internet standards development | RFC series (Requests for Comments) |
| ICANN | Domain name and IP address policy | Top-level domain management |
| IEEE | Physical and data link standards | 802.3 (Ethernet), 802.11 (Wi-Fi) |
| ITU-T | Telecommunications standards | X.509 (certificates), H.264 (video) |
| W3C | Web standards | HTML, CSS, DOM, SVG |

```mermaid
flowchart TD
    subgraph "Application"
        A1["HTTP/HTTPS<br/>Port 80/443"]
        A2["DNS<br/>Port 53"]
        A3["SMTP<br/>Port 25/587"]
    end
    subgraph "Transport"
        T1["TCP<br/>RFC 793"]
        T2["UDP<br/>RFC 768"]
    end
    subgraph "Network"
        N1["IPv4<br/>RFC 791"]
        N2["IPv6<br/>RFC 8200"]
        N3["ICMP<br/>RFC 792"]
    end
    subgraph "Data Link"
        D1["Ethernet<br/>802.3"]
        D2["Wi-Fi<br/>802.11"]
        D3["VLAN<br/>802.1Q"]
    end
    subgraph "Physical"
        P1["Cat 6a UTP"]
        P2["Fiber<br/>Single/Multi-mode"]
        P3["Radio<br/>2.4/5/6 GHz"]
    end
    
    A1 --> T1
    A2 --> T2
    T1 --> N1
    T2 --> N1
    N1 --> D1
    D1 --> P1
    D2 --> P3
    
    style A1 fill:#4a7c59,color:#fff
    style N1 fill:#2d5a3a,color:#fff
    style P1 fill:#5a3a2d,color:#fff
```

---

## Layer 1 — Physical

### Ethernet (IEEE 802.3)

| Standard | Speed | Medium | Maximum Distance |
|----------|-------|--------|-----------------|
| 10BASE-T | 10 Mbps | Cat 3 UTP | 100m |
| 100BASE-TX | 100 Mbps | Cat 5 UTP | 100m |
| 1000BASE-T | 1 Gbps | Cat 5e UTP | 100m |
| 2.5GBASE-T | 2.5 Gbps | Cat 5e UTP | 100m |
| 5GBASE-T | 5 Gbps | Cat 6 UTP | 100m |
| 10GBASE-T | 10 Gbps | Cat 6a UTP | 100m |
| 10GBASE-SR | 10 Gbps | Multi-mode fiber | 300m |
| 10GBASE-LR | 10 Gbps | Single-mode fiber | 10km |
| 25GBASE-SR | 25 Gbps | Multi-mode fiber | 100m |
| 40GBASE-SR4 | 40 Gbps | Multi-mode fiber (parallel) | 100m |
| 100GBASE-LR4 | 100 Gbps | Single-mode fiber (WDM) | 10km |
| 400GBASE-SR16 | 400 Gbps | Multi-mode fiber | 100m |

### Wi-Fi (IEEE 802.11)

| Standard | Frequency | Max Rate | Channel Width | Modulation |
|----------|-----------|----------|---------------|------------|
| 802.11b | 2.4 GHz | 11 Mbps | 20 MHz | DSSS |
| 802.11a | 5 GHz | 54 Mbps | 20 MHz | OFDM |
| 802.11g | 2.4 GHz | 54 Mbps | 20 MHz | OFDM |
| 802.11n | 2.4/5 GHz | 600 Mbps | 40 MHz | MIMO-OFDM |
| 802.11ac | 5 GHz | 6.93 Gbps | 160 MHz | MU-MIMO |
| 802.11ax (Wi-Fi 6) | 2.4/5 GHz | 9.6 Gbps | 160 MHz | OFDMA |
| 802.11be (Wi-Fi 7) | 2.4/5/6 GHz | 46 Gbps | 320 MHz | MLO |

---

## Layer 2 — Data Link

### MAC Address Format

```
48-bit MAC address: XX-XX-XX-XX-XX-XX
  |-- OUI --| |-- NIC --|
  
OUI (Organizationally Unique Identifier): 24 bits, assigned by IEEE
NIC (Network Interface Controller): 24 bits, assigned by manufacturer

Example: 00-50-56-C0-00-08
  00-50-56 = VMware, Inc.
  C0-00-08 = Specific virtual NIC
```

### Ethernet Frame Structure

```
Preamble (7 bytes) + SFD (1 byte) + Destination MAC (6) + Source MAC (6) + 802.1Q Tag (4, optional) + EtherType (2) + Payload (46-1500) + FCS (4)

EtherType values (IANA assigned):
  0x0800 = IPv4
  0x0806 = ARP
  0x86DD = IPv6
  0x8100 = 802.1Q VLAN
  0x8847 = MPLS
  0x8863/0x8864 = PPPoE
  0x888E = 802.1X EAPOL
  0x88CC = LLDP
```

### VLAN (IEEE 802.1Q)

| Field | Size | Description |
|-------|------|-------------|
| TPID | 16 bits | Tag Protocol Identifier (0x8100) |
| PCP | 3 bits | Priority Code Point (0-7) |
| DEI | 1 bit | Drop Eligible Indicator |
| VID | 12 bits | VLAN Identifier (1-4094) |

Reserved VLAN IDs: 0 (null), 1 (default), 4095 (reserved)

---

## Layer 3 — Network

### IPv4 Address Classes (Historical)

| Class | First Bits | Range | Default Mask | Use |
|-------|-----------|-------|-------------|-----|
| A | 0 | 0.0.0.0 - 127.255.255.255 | /8 | Very large networks |
| B | 10 | 128.0.0.0 - 191.255.255.255 | /16 | Large networks |
| C | 110 | 192.0.0.0 - 223.255.255.255 | /24 | Small networks |
| D | 1110 | 224.0.0.0 - 239.255.255.255 | — | Multicast |
| E | 1111 | 240.0.0.0 - 255.255.255.255 | — | Experimental |

### RFC 1918 Private Address Space

| Range | CIDR | Usable Addresses |
|-------|------|-----------------|
| 10.0.0.0 - 10.255.255.255 | 10.0.0.0/8 | 16,777,214 |
| 172.16.0.0 - 172.31.255.255 | 172.16.0.0/12 | 1,048,574 |
| 192.168.0.0 - 192.168.255.255 | 192.168.0.0/16 | 65,534 |

### IPv6 Address Types

| Type | Prefix | Example |
|------|--------|---------|
| Global Unicast | 2000::/3 | 2001:db8::1 |
| Unique Local | fc00::/7 | fd00:1234::1 |
| Link-Local | fe80::/10 | fe80::1%eth0 |
| Multicast | ff00::/8 | ff02::1 |
| Loopback | ::1/128 | ::1 |
| Unspecified | ::/128 | :: |
| IPv4-mapped | ::ffff:0:0/96 | ::ffff:192.0.2.1 |

### IP Protocol Numbers

| Number | Protocol | RFC |
|--------|----------|-----|
| 1 | ICMP | RFC 792 |
| 2 | IGMP | RFC 1112 |
| 4 | IPv4 (encapsulated) | RFC 2003 |
| 6 | TCP | RFC 793 |
| 17 | UDP | RFC 768 |
| 41 | IPv6 | RFC 2460 |
| 43 | IPv6 Route | RFC 2460 |
| 44 | IPv6 Frag | RFC 2460 |
| 47 | GRE | RFC 2784 |
| 50 | ESP (IPsec) | RFC 4303 |
| 51 | AH (IPsec) | RFC 4302 |
| 58 | ICMPv6 | RFC 4443 |
| 89 | OSPF | RFC 2328 |
| 103 | PIM | RFC 4601 |
| 132 | SCTP | RFC 4960 |
| 136 | UDPLite | RFC 3828 |

---

## Layer 4 — Transport

### IANA Port Number Ranges

| Range | Name | Assignment Authority |
|-------|------|---------------------|
| 0-1023 | System / Well-Known | IANA, requires IETF Review |
| 1024-49151 | User / Registered | IANA, Expert Review |
| 49152-65535 | Dynamic / Private / Ephemeral | Not assigned; local use |

### Well-Known Port Assignments

| Port | Protocol | Transport | Service | RFC |
|------|----------|-----------|---------|-----|
| 20/21 | FTP | TCP | File Transfer | RFC 959 |
| 22 | SSH | TCP | Secure Shell | RFC 4251 |
| 23 | Telnet | TCP | Remote terminal | RFC 854 |
| 25 | SMTP | TCP | Mail submission | RFC 5321 |
| 53 | DNS | UDP/TCP | Domain Name System | RFC 1035 |
| 67/68 | DHCP | UDP | Dynamic Host Configuration | RFC 2131 |
| 69 | TFTP | UDP | Trivial File Transfer | RFC 1350 |
| 80 | HTTP | TCP | Hypertext Transfer | RFC 9112 |
| 88 | Kerberos | UDP/TCP | Authentication | RFC 4120 |
| 110 | POP3 | TCP | Post Office Protocol | RFC 1939 |
| 113 | Ident | TCP | Identification | RFC 1413 |
| 123 | NTP | UDP | Network Time Protocol | RFC 5905 |
| 137-139 | NetBIOS | UDP/TCP | Windows name service | RFC 1001 |
| 143 | IMAP | TCP | Internet Message Access | RFC 3501 |
| 161/162 | SNMP | UDP | Simple Network Management | RFC 3411 |
| 179 | BGP | TCP | Border Gateway Protocol | RFC 4271 |
| 194 | IRC | TCP | Internet Relay Chat | RFC 1459 |
| 389 | LDAP | TCP | Lightweight Directory Access | RFC 4511 |
| 443 | HTTPS | TCP | HTTP over TLS | RFC 9110 |
| 445 | SMB | TCP | Server Message Block | RFC 1002 |
| 465 | SMTPS | TCP | SMTP over TLS (deprecated) | RFC 8314 |
| 500 | ISAKMP | UDP | Internet Security Association | RFC 2408 |
| 514 | Syslog | UDP | System logging | RFC 3164 |
| 587 | SMTP | TCP | Message submission | RFC 6409 |
| 636 | LDAPS | TCP | LDAP over TLS | RFC 4513 |
| 853 | DNS-over-TLS | TCP | DNS over TLS | RFC 7858 |
| 989/990 | FTPS | TCP | FTP over TLS | RFC 4217 |
| 993 | IMAPS | TCP | IMAP over TLS | RFC 8314 |
| 995 | POP3S | TCP | POP3 over TLS | RFC 8314 |
| 1194 | OpenVPN | UDP | VPN tunnel | RFC 内联 |
| 1433 | MS-SQL | TCP | Microsoft SQL Server | — |
| 1701 | L2TP | UDP | Layer 2 Tunneling | RFC 2661 |
| 1723 | PPTP | TCP | Point-to-Point Tunneling | RFC 2637 |
| 2049 | NFS | UDP/TCP | Network File System | RFC 7530 |
| 2082/2083 | cPanel | TCP | Web hosting control panel | — |
| 3128 | Squid | TCP | HTTP proxy | — |
| 3306 | MySQL | TCP | MySQL database | — |
| 3389 | RDP | TCP | Remote Desktop Protocol | MS-RDPBCGR |
| 4443 | Phabricator | TCP | Code review platform | — |
| 4500 | IPsec NAT-T | UDP | IPsec NAT traversal | RFC 3947 |
| 4789 | VXLAN | UDP | Virtual Extensible LAN | RFC 7348 |
| 5060 | SIP | UDP/TCP | Session Initiation Protocol | RFC 3261 |
| 5201 | iPerf3 | TCP/UDP | Network bandwidth testing | — |
| 5222 | XMPP | TCP | Extensible Messaging | RFC 6120 |
| 5432 | PostgreSQL | TCP | PostgreSQL database | — |
| 5900 | VNC | TCP | Virtual Network Computing | RFC 6143 |
| 5985/5986 | WinRM | TCP | Windows Remote Management | MS-WSMV |
| 6443 | Kubernetes | TCP | Kubernetes API server | — |
| 8080 | HTTP-alt | TCP | Alternative HTTP | — |
| 8443 | HTTPS-alt | TCP | Alternative HTTPS | — |
| 9200/9300 | Elasticsearch | TCP | Search and analytics | — |
| 10000 | Webmin | TCP | Web-based system admin | — |
| 51820 | WireGuard | UDP | VPN tunnel | wireguard.com |

### TCP Header Flags

| Flag | Bit | Purpose |
|------|-----|---------|
| FIN | 0 | No more data from sender |
| SYN | 1 | Synchronize sequence numbers |
| RST | 2 | Reset the connection |
| PSH | 3 | Push function |
| ACK | 4 | Acknowledgment field is valid |
| URG | 5 | Urgent pointer field is valid |
| ECE | 6 | ECN-Echo (explicit congestion) |
| CWR | 7 | Congestion Window Reduced |

---

## Layer 5-7 — Session, Presentation, Application

### HTTP Status Codes (IANA Registered)

| Code | Meaning | RFC |
|------|---------|-----|
| 1xx | Informational | |
| 100 | Continue | RFC 9110 |
| 101 | Switching Protocols | RFC 9110 |
| 103 | Early Hints | RFC 8297 |
| 2xx | Success | |
| 200 | OK | RFC 9110 |
| 201 | Created | RFC 9110 |
| 204 | No Content | RFC 9110 |
| 3xx | Redirection | |
| 301 | Moved Permanently | RFC 9110 |
| 302 | Found | RFC 9110 |
| 304 | Not Modified | RFC 9110 |
| 307 | Temporary Redirect | RFC 9110 |
| 308 | Permanent Redirect | RFC 7538 |
| 4xx | Client Error | |
| 400 | Bad Request | RFC 9110 |
| 401 | Unauthorized | RFC 9110 |
| 403 | Forbidden | RFC 9110 |
| 404 | Not Found | RFC 9110 |
| 405 | Method Not Allowed | RFC 9110 |
| 418 | I'm a teapot | RFC 2324 |
| 429 | Too Many Requests | RFC 6585 |
| 451 | Unavailable For Legal Reasons | RFC 7725 |
| 5xx | Server Error | |
| 500 | Internal Server Error | RFC 9110 |
| 502 | Bad Gateway | RFC 9110 |
| 503 | Service Unavailable | RFC 9110 |
| 504 | Gateway Timeout | RFC 9110 |

### MIME Types (IANA Media Types)

| Type | Subtype | Usage |
|------|---------|-------|
| text | plain | Plain text |
| text | html | HTML documents |
| text | css | Stylesheets |
| text | javascript | JavaScript source |
| application | json | JSON data |
| application | xml | XML data |
| application | pdf | PDF documents |
| application | octet-stream | Arbitrary binary data |
| application | x-www-form-urlencoded | HTML form data |
| application | gzip | GZIP compressed |
| application | zip | ZIP archive |
| application | x-tar | TAR archive |
| image | png | PNG image |
| image | jpeg | JPEG image |
| image | gif | GIF image |
| image | svg+xml | SVG image |
| image | webp | WebP image |
| audio | mpeg | MP3 audio |
| audio | wav | WAV audio |
| audio | ogg | OGG audio |
| video | mp4 | MP4 video |
| video | webm | WebM video |
| video | ogg | OGG video |
| font | woff2 | WOFF2 font |

---

## DNS Resource Record Types

| Type | Value | Purpose | RFC |
|------|-------|---------|-----|
| A | 1 | IPv4 address | RFC 1035 |
| NS | 2 | Authoritative name server | RFC 1035 |
| CNAME | 5 | Canonical name (alias) | RFC 1035 |
| SOA | 6 | Start of authority | RFC 1035 |
| PTR | 12 | Pointer (reverse DNS) | RFC 1035 |
| MX | 15 | Mail exchange | RFC 1035 |
| TXT | 16 | Text record | RFC 1035 |
| AAAA | 28 | IPv6 address | RFC 3596 |
| SRV | 33 | Service locator | RFC 2782 |
| NAPTR | 35 | Naming authority pointer | RFC 3403 |
| DS | 43 | Delegation signer (DNSSEC) | RFC 4034 |
| RRSIG | 46 | Signature (DNSSEC) | RFC 4034 |
| NSEC | 47 | Next secure (DNSSEC) | RFC 4034 |
| DNSKEY | 48 | DNS key (DNSSEC) | RFC 4034 |
| NSEC3 | 50 | Hashed next secure | RFC 5155 |
| TLSA | 52 | TLS association (DANE) | RFC 6698 |
| CAA | 257 | Certification Authority Authorization | RFC 6844 |

---

## Related Deep Hole

- [IANA Protocol Registries](https://www.iana.org/protocols) — Master registry index
- [IANA Service Name and Port Number Registry](https://www.iana.org/assignments/service-names-port-numbers) — Port assignments
- [IANA MIME Media Types](https://www.iana.org/assignments/media-types/) — Media type registry
- [IANA DNS Parameters](https://www.iana.org/assignments/dns-parameters/) — DNS record types
- [IANA IPv6 Special-Purpose Address Registry](https://www.iana.org/assignments/iana-ipv6-special-registry/) — IPv6 special addresses
- [IEEE 802 Standards](https://standards.ieee.org/standard/index.html) — LAN/MAN standards
- [IETF RFC Index](https://www.rfc-editor.org/rfc-index.html) — Complete RFC listing
"""

let render() = file
