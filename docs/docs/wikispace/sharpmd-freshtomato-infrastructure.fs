module ConvertedFiles.Docs.Wikispace.FreshtomatoInfrastructureMd

let file = """# FreshTomato Infrastructure

FreshTomato is a third-party firmware for Broadcom-based consumer routers, derived from the Tomato firmware by Jonathan Zarate. It provides a streamlined web interface, advanced QoS, VPN support, and comprehensive bandwidth monitoring while maintaining stability on supported hardware.

---

## Overview

???+ note "What this page covers"
    This page documents FreshTomato router firmware deployment:

    - **Supported Hardware** — Broadcom ARM and MIPS routers with specifications
    - **Firmware Variants** — Mini, VPN, AIO, and NG build types
    - **VPN Support** — OpenVPN, WireGuard, and legacy protocol status
    - **QoS Implementations** — HTB, fq_codel, and Cake algorithms
    - **Ad Blocking** — dnsmasq-based DNS filtering
    - **Custom Scripts** — Firewall, init, WAN up/down hooks
    - **DNS Configuration** — dnsmasq, stubby, and custom options

    For OpenWRT router firmware, see [Router Firmware: OpenWRT and FreshTomato](openwrt-freshtomato.md). For GL.iNet router specifics, see [GL.iNet / LuCI](glinet-luci.md). For DNS security configuration, see [DNS and Firewall](dns.md).

---

## Supported Hardware

FreshTomato targets Broadcom ARM and MIPS routers. Primary supported models:

```mermaid
flowchart LR
    subgraph ARM["ARM (Recommended)"]
        direction TB
        A1["RT-AC68U<br/>BCM4708 / AC1900"]
        A2["RT-AC3100<br/>BCM4709 / AC3100"]
        A3["R7000<br/>BCM4709 / AC1900"]
    end

    subgraph MIPS["MIPS (Legacy)"]
        direction TB
        M1["RT-N66U<br/>BCM4706 / N900"]
        M2["WNDR4500<br/>BCM4706 / N900"]
    end

    style ARM fill:#4a90d9
    style MIPS fill:#f5a623
```

| Model | Chipset | Wi-Fi | Max WAN |
|-------|---------|-------|---------|
| Asus RT-AC68U | BCM4708 | AC1900 | 1 Gbps |
| Asus RT-AC3100 | BCM4709 | AC3100 | 1 Gbps |
| Netgear R7000 | BCM4709 | AC1900 | 1 Gbps |
| Netgear R6400 | BCM4708 | AC1750 | 1 Gbps |
| Linksys EA6900 | BCM4708 | AC1900 | 1 Gbps |
| Linksys E2500 | BCM5357 | N600 | 100 Mbps |
| Asus RT-N66U | BCM4706 | N900 | 450 Mbps |
| Netgear WNDR4500 | BCM4706 | N900 | 450 Mbps |

Hardware selection considerations:

| Spec | Minimum | Recommended |
|------|---------|-------------|
| Flash | 8 MB | 32+ MB (for AIO builds) |
| RAM | 128 MB | 256+ MB |
| CPU | 480 MHz | 1 GHz+ (dual-core) |

---

## Firmware Variants

FreshTomato distributes multiple build types:

| Build | Size | Features |
|-------|------|----------|
| Mini | ~8 MB | Basic routing, no USB, no VPN |
| VPN | ~16 MB | Adds OpenVPN, WireGuard |
| AIO (All-in-One) | ~32 MB | Full feature set including USB, printer sharing, 3G/4G modem, TOR |
| NG (New Generation) | Varies | Experimental features, newer kernel |

---

## Feature Set

### VPN

| Protocol | Client | Server | Notes |
|----------|--------|--------|-------|
| OpenVPN | Yes | Yes | Full TLS with certificate authentication |
| WireGuard | Experimental | Experimental | Via custom scripts or community builds |
| PPTP | Yes | Yes | Legacy, not recommended for security |
| L2TP/IPsec | Yes | No | Client-only |

### Quality of Service (QoS)

FreshTomato provides multiple QoS implementations:

| Implementation | Algorithm | Use Case |
|---------------|-----------|----------|
| Traditional | HTB (Hierarchical Token Bucket) | Class-based bandwidth allocation |
| fq_codel | Fair Queueing + Controlled Delay | Bufferbloat reduction |
| Cake | Common Applications Kept Enhanced | Modern bufferbloat solution with bandwidth shaping |

### Ad Blocking

```
Administration > Ad Blocking
  Enable: Yes
  Blocklist source: StevenBlack hosts
  Custom blocklist: URL or local file
  Whitelist: exceptions
```

The ad blocker operates at the DNS level using `dnsmasq` with a hosts-format blocklist. All LAN DNS queries are checked against the blocklist before resolution.

### Bandwidth Monitoring

| Feature | Granularity |
|---------|-------------|
| Real-time | Per-second graph |
| Daily | 24-hour summary |
| Monthly | Calendar view with totals |
| Per-IP | Individual device tracking |
| Per-MAC | Device-level across IP changes |

---

## Web Interface Sections

```mermaid
flowchart TD
    subgraph Basic["Basic"]
        B1["Network<br/>(WAN/LAN/DHCP)"]
        B2["IPv6<br/>(Native/6rd/6to4)"]
        B3["Identification<br/>(Name/NTP)"]
    end

    subgraph Advanced["Advanced"]
        A1["Virtual Wireless<br/>(Guest SSIDs)"]
        A2["VLAN<br/>(802.1Q)"]
        A3["DHCP/DNS<br/>(dnsmasq)"]
        A4["Firewall<br/>(SPI/NAT)"]
    end

    subgraph Admin["Administration"]
        AD1["Access<br/>(SSH/Web)"]
        AD2["Scripts<br/>(Init/Firewall/WAN)"]
    end

    subgraph VPN["VPN"]
        V1["OpenVPN Client"]
        V2["OpenVPN Server"]
        V3["WireGuard"]
    end

    subgraph QoS["QoS"]
        Q1["Basic Settings"]
        Q2["Classification"]
    end

    style Basic fill:#4a90d9
    style Advanced fill:#7ed321
    style Admin fill:#f5a623
    style VPN fill:#9013fe
    style QoS fill:#bd10e0
```

| Section | Function |
|---------|----------|
| Basic > Network | WAN/LAN IP configuration, DHCP server |
| Basic > IPv6 | IPv6 connection type (native, 6rd, 6to4, DHCPv6) |
| Basic > Identification | Router name, domain, NTP |
| Advanced > Virtual Wireless | Multiple SSIDs, guest networks |
| Advanced > VLAN | 802.1Q VLAN tagging |
| Advanced > DHCP/DNS | DNS forwarder, static DHCP leases, custom DNS |
| Advanced > Firewall | SPI firewall, NAT loopback, multicast |
| Administration > Access | Web admin access, SSH, Telnet |
| Administration > Debugging | Syslog, console, packet capture |
| Administration > Scripts | Init, Firewall, WAN Up, WAN Down custom scripts |
| Administration > Buttons/LED | Custom GPIO button actions |
| VPN > OpenVPN Client | Profile-based OpenVPN client |
| VPN > OpenVPN Server | PKI setup for OpenVPN server |
| VPN > WireGuard | Peer configuration (NG builds) |
| QoS > Basic Settings | QoS enable, download/upload rates |
| QoS > Classification | Traffic class rules by port, IP, MAC |
| USB and NAS | File sharing, printer server, 3G/4G modem |

---

## Custom Scripts

FreshTomato provides hook scripts that run at specific lifecycle points:

```bash
# /jffs/scripts/init.sh - Runs at boot
# /jffs/scripts/firewall.sh - Runs when firewall restarts
# /jffs/scripts/wanup.sh - Runs when WAN comes up
# /jffs/scripts/wandown.sh - Runs when WAN goes down
```

### Firewall Custom Rules

```bash
# /jffs/scripts/firewall.sh
# Block IoT devices from accessing management interfaces
iptables -I FORWARD -s 192.168.30.0/24 -d 192.168.1.1 -p tcp --dport 22 -j DROP
iptables -I FORWARD -s 192.168.30.0/24 -d 192.168.1.1 -p tcp --dport 80 -j DROP
iptables -I FORWARD -s 192.168.30.0/24 -d 192.168.1.1 -p tcp --dport 443 -j DROP
iptables -I FORWARD -s 192.168.30.0/24 -d 192.168.1.1 -p tcp --dport 8080 -j DROP

# Allow IoT to internet only
iptables -I FORWARD -s 192.168.30.0/24 -d 192.168.0.0/16 -j DROP
iptables -I FORWARD -s 192.168.30.0/24 -d 10.0.0.0/8 -j DROP
iptables -I FORWARD -s 192.168.30.0/24 -d 172.16.0.0/12 -j DROP
```

---

## DNS Configuration

FreshTomato uses `dnsmasq` for DHCP and DNS forwarding. DNS-over-TLS can be configured via `stubby` (available in AIO builds):

```
Advanced > DHCP/DNS
  DNS Servers: Custom (enter upstream resolvers)
  Use dnscrypt-proxy: Enable (if available in build)
  Prevent DNS-rebind attacks: Enable
  Intercept DNS port: Enable (forces all LAN DNS through router)
```

Custom `dnsmasq` configuration can be added:

```
Advanced > DHCP/DNS > Dnsmasq Custom Configuration
  # Force all DNS through router
  dhcp-option=6,0.0.0.0
  
  # Custom domain for LAN
  local=/home.local/192.168.1.1
  
  # Static host entries
  address=/server.home.local/192.168.1.10
```

---

## IPv6 Configuration

```
Basic > IPv6
  IPv6 Service Type: Native DHCPv6
  Request PD (Prefix Delegation): Enable
  PD Size: /60 (requests /60 from ISP, provides /64 subnets to LAN)
  DUID: Default (or custom)
  LAN IPv6: Static or SLAAC
  Announce Subnets: Enable
```

---

## Related Pages

- [Router Firmware: OpenWRT and FreshTomato](openwrt-freshtomato.md) — Comparative firmware reference
- [GL.iNet / LuCI](glinet-luci.md) — GL.iNet router specifics and LuCI interface
- [OpenWRT LuCI](openwrt-luci.md) — OpenWRT web interface documentation
- [DNS and Firewall](dns.md) — DNS resolver configuration and iptables reference
- [WireGuard Server](wireguard-server.md) — WireGuard tunnel configuration

## Related Deep Hole

- [FreshTomato Wiki](https://wiki.freshtomato.org/) — Official documentation
- [FreshTomato Firmware Downloads](https://freshtomato.org/downloads) — Build repository
- [LinksysInfo Forums](https://www.linksysinfo.org/) — Community forums for Tomato-based firmware
- [FreshTomato GitHub](https://github.com/pedro0311/freshtomato-arm) — Source code repository
"""

let render() = file
