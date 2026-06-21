module ConvertedFiles.Docs.Wikispace.OpenwrtFreshtomatoMd

let file = """# Router Firmware: OpenWRT and FreshTomato

Third-party router firmware replaces the manufacturer's stock firmware with open-source alternatives that provide advanced features, security updates, and greater control over network infrastructure. This page covers OpenWRT and FreshTomato, the two leading firmware projects for consumer and prosumer router hardware.

---

## Overview

???+ note "What this page covers"
    This page provides a comparative reference for OpenWRT and FreshTomato router firmware:

    - **OpenWRT** — Linux-based firmware with opkg package management and nftables firewall
    - **FreshTomato** — Streamlined TomatoUI firmware for Broadcom routers
    - **DNS Security** — DoH, DoT, DNSSEC, and ad blocking on both platforms
    - **Feature Comparison** — Hardware support, VPN protocols, customization

    For detailed FreshTomato configuration, see [FreshTomato Infrastructure](freshtomato-infrastructure.md). For GL.iNet routers, see [GL.iNet / LuCI](glinet-luci.md). For OpenWRT LuCI specifics, see [OpenWRT LuCI](openwrt-luci.md).

---

## OpenWRT

OpenWRT is a Linux-based router firmware derived from the Linux kernel and BusyBox userland. It uses the opkg package manager and provides a fully writable filesystem with package management.

### Architecture

```mermaid
flowchart TD
    subgraph OpenWRT["OpenWRT System"]
        direction TB
        K["Linux Kernel"]
        BB["BusyBox<br/>(userland)"]
        OPKG["opkg<br/>(package manager)"]

        subgraph Net["Networking Stack"]
            NFT["nftables / fw4"]
            DNS["dnsmasq"]
            WG["WireGuard"]
        end

        subgraph FS["Filesystem"]
            SQUASHFS["SquashFS<br/>(read-only)"]
            OVERLAY["OverlayFS<br/>(writable)"]
        end
    end

    K --> BB
    BB --> OPKG
    K --> Net
    OPKG --> FS

    style OpenWRT fill:#4a90d9
    style Net fill:#7ed321
```

### Supported Hardware

| Manufacturer | Models | Notes |
|-------------|--------|-------|
| TP-Link | Archer C7, AX1800, AX3000 | Broad community support |
| GL.iNet | Flint (AX1800), Beryl (MT1300), Slate (AXT1800) | Pre-installed OpenWRT |
| Linksys | WRT3200ACM, WRT1900ACS | Marvell chipset, good mainline support |
| Netgear | R7800, RAX40 | Active community builds |
| Xiaomi | AX3600, AX6000 | Good hardware, requires flashing |

### Installation

```bash
# General procedure (verify device-specific steps first)
# 1. Download factory image from https://firmware-selector.openwrt.org/
# 2. Upload via stock firmware web interface (or TFTP recovery)
# 3. Wait for reboot
# 4. Access LuCI at http://192.168.1.1 (root, no password)
```

### DNS Configuration (dnsmasq)

OpenWRT uses dnsmasq as the default DNS forwarder and DHCP server. DNS-over-HTTPS can be enabled via https-dns-proxy:

```bash
# Install DNS-over-HTTPS proxy
opkg update
opkg install https-dns-proxy

# Configure for Cloudflare
uci set https-dns-proxy.main.url='https://cloudflare-dns.com/dns-query'
uci set https-dns-proxy.main.bootstrap_dns='1.1.1.1,1.0.0.1'
uci commit https-dns-proxy
/etc/init.d/https-dns-proxy enable
/etc/init.d/https-dns-proxy start

# Force all LAN clients to use router DNS
uci set dhcp.lan.dhcp_option='6,192.168.1.1'
uci commit dhcp
/etc/init.d/dnsmasq restart
```

### Firewall (fw4 / nftables)

OpenWRT 22.03+ uses fw4 based on nftables. Configuration is managed through UCI:

```bash
# View firewall configuration
uci show firewall

# Add custom rule
uci add firewall rule
uci set firewall.@rule[-1].name='Block-WAN-SSH'
uci set firewall.@rule[-1].src='wan'
uci set firewall.@rule[-1].dest_port='22'
uci set firewall.@rule[-1].proto='tcp'
uci set firewall.@rule[-1].target='REJECT'
uci commit firewall
/etc/init.d/firewall restart
```

### Ad Blocking (adblock)

```bash
opkg install adblock
uci set adblock.global.adb_enabled='1'
uci set adblock.global.adb_sources='blocklist_firefox_tracking blocklist_dating blocklist_gambling'
uci commit adblock
/etc/init.d/adblock enable
/etc/init.d/adblock start
```

---

## FreshTomato

FreshTomato is a fork of the Tomato firmware for Broadcom-based routers. It emphasizes ease of use with a streamlined web interface while providing advanced features.

### Supported Hardware

FreshTomato targets Broadcom ARM and MIPS routers, including:

| Model | Chipset | Max WAN |
|-------|---------|---------|
| Asus RT-AC68U | BCM4708 | 1 Gbps |
| Netgear R7000 | BCM4709 | 1 Gbps |
| Linksys EA6900 | BCM4708 | 1 Gbps |
| Asus RT-N66U | BCM4706 | 300 Mbps |

### Key Features

| Feature | Implementation |
|---------|---------------|
| VPN Client/Server | OpenVPN, WireGuard (experimental) |
| QoS | fq_codel, cake, traditional |
| Ad Blocking | dnsmasq with blocklist |
| Bandwidth Monitoring | Per-IP, per-MAC, per-device graphs |
| USB Support | NAS, printer sharing, 3G/4G modem |
| VLAN | 802.1Q tagging on supported hardware |

### DNS Configuration

FreshTomato uses dnsmasq for DNS forwarding. To configure DNS-over-HTTPS:

```
Advanced > DHCP/DNS > DNS Servers > 1.1.1.1, 1.0.0.1
Advanced > DHCP/DNS > Use dnscrypt-proxy > Enable (if available)
Advanced > DHCP/DNS > Prevent DNS-rebind attacks > Enable
```

### Firewall Configuration

FreshTomato provides a web-based firewall with the following sections:

| Section | Function |
|---------|----------|
| Basic > IPv4 Firewall | Enable/disable SPI firewall |
| Access Restriction | Time-based access control |
| Port Forwarding | NAT port redirects |
| DMZ | Expose single host to WAN |
| QoS | Traffic shaping and prioritization |

---

## OpenWRT vs FreshTomato

```mermaid
flowchart TD
    subgraph Comparison["Feature Comparison"]
        direction LR
        subgraph O["OpenWRT"]
            direction TB
            O1["Broad hardware<br/>(many archs)"]
            O2["opkg: 3000+<br/>packages"]
            O3["LuCI: extensive<br/>web interface"]
            O4["Steeper<br/>learning curve"]
            O5["nftables<br/>firewall"]
        end

        subgraph F["FreshTomato"]
            direction TB
            F1["Broadcom<br/>only"]
            F2["Built-in<br/>features"]
            F3["TomatoUI:<br/>streamlined"]
            F4["Gentler<br/>learning curve"]
            F5["iptables<br/>firewall"]
        end
    end

    style O fill:#4a90d9
    style F fill:#7ed321
```

| Feature | OpenWRT | FreshTomato |
|---------|---------|-------------|
| Hardware support | Broad (many architectures) | Limited (Broadcom only) |
| Package management | opkg (3000+ packages) | Limited built-in |
| Web interface | LuCI (extensive) | TomatoUI (streamlined) |
| VPN protocols | WireGuard, OpenVPN, IPsec, strongSwan | OpenVPN, basic WireGuard |
| Learning curve | Steeper | Gentler |
| Customization | Extensive | Moderate |
| Wireless performance | Good (depends on driver) | Excellent (proprietary Broadcom) |
| Community size | Large | Moderate |

---

## DNS Security on Router Firmware

Both OpenWRT and FreshTomato support DNS security measures:

| Feature | OpenWRT | FreshTomato | Purpose |
|---------|---------|-------------|---------|
| DNS-over-HTTPS | https-dns-proxy | dnscrypt-proxy | Encrypt DNS queries |
| DNS-over-TLS | stubby | stubby | Alternative to DoH |
| DNSSEC | dnsmasq-full | Built-in | Validate DNS responses |
| Ad blocking | adblock package | dnsmasq blocklist | Filter unwanted domains |
| DNS rebinding protection | firewall rule | Built-in option | Prevent LAN attacks |

---

## Related Pages

- [FreshTomato Infrastructure](freshtomato-infrastructure.md) — Detailed FreshTomato configuration
- [GL.iNet / LuCI](glinet-luci.md) — GL.iNet router specifics
- [OpenWRT LuCI](openwrt-luci.md) — OpenWRT web interface
- [DNS and Firewall](dns.md) — DNS resolver reference
- [WireGuard Server](wireguard-server.md) — VPN tunnel configuration

## Related Deep Hole

- [OpenWRT Documentation](https://openwrt.org/docs/start) — Official wiki and guides
- [OpenWRT Firmware Selector](https://firmware-selector.openwrt.org/) — Device-specific firmware downloads
- [FreshTomato Wiki](https://wiki.freshtomato.org/) — FreshTomato documentation
- [OpenWRT Package Index](https://openwrt.org/packages/start) — Available packages
- [WireGuard on OpenWRT](https://openwrt.org/docs/guide-user/services/vpn/wireguard/basics) — Router WireGuard setup
- [nixCraft: OpenWRT dnsmasq Setup](https://www.cyberciti.biz/faq/howto-setup-dnsmasq-dns-server/) — DNS configuration guide
"""

let render() = file
