module ConvertedFiles.Docs.Wikispace.GlinetLuciMd

let file = """# GL.iNet and OpenWRT Advanced Configuration

GL.iNet travel routers ship with a customized OpenWRT firmware featuring a simplified web interface and pre-configured VPN client support. The underlying OpenWRT system exposes full configuration through SSH, UCI (Unified Configuration Interface), and the LuCI web interface. This page documents VLAN configuration, Multi-Link Operation (MLO) Wi-Fi, Qualcomm NSS acceleration, and IPv6 subnetting on GL.iNet hardware.

---

## Overview

???+ note "What this page covers"
    GL.iNet Flint 3 advanced configuration: VLAN setup with UCI, Qualcomm NSS acceleration, MLO Wi-Fi 7, nftables customization, and IPv6 subnetting. For the OpenWRT LuCI web interface documentation, see [OpenWRT LuCI](openwrt-luci.md). For router firmware comparison, see [Router Firmware](openwrt-freshtomato.md).

---

## Hardware: Flint 3 (GL-BE9300)

| Specification | Value |
|-------------|-------|
| SoC | Qualcomm IPQ5332 |
| Wi-Fi | Wi-Fi 7 (802.11be) |
| Ethernet | 1x 2.5G WAN, 4x 2.5G LAN |
| RAM | 1 GB DDR4 |
| Storage | 128 MB NAND Flash |
| Acceleration | Qualcomm NSS (Network Subsystem) |

```mermaid
flowchart TD
    I["Internet"] --> W["2.5G WAN<br/>eth0"]
    W --> Q["Qualcomm NSS<br/>Hardware Offload"]
    Q --> B["Bridge<br/>br-lan"]
    B --> L1["LAN1<br/>eth1.1"]
    B --> L2["LAN2<br/>eth1.2"]
    B --> L3["LAN3<br/>eth1.3"]
    B --> L4["LAN4<br/>eth1.4"]
    Q --> V["VLAN 25<br/>IoT Network"]
    V --> Wi["Wi-Fi<br/>IoT SSID"]
    
    style Q fill:#5a3a2d,color:#fff
    style V fill:#2d5a3a,color:#fff
```

---

## Qualcomm NSS Acceleration

The IPQ5332 features Qualcomm's Network Subsystem (NSS), a hardware offloading engine that processes packets at line rate without CPU involvement. To maintain NSS acceleration:

| Practice | Reason |
|----------|--------|
| Use `eth1.X` sub-interfaces | Hardware recognizes 802.1Q tagged paths |
| Avoid software bridges (`br-lan.X`) | Bridges disable NSS offloading |
| Avoid `vlan_filtering` | Software VLAN processing bypasses hardware |

```
eth1 = internal CPU-facing interface to the hardware switch
eth1.X = 802.1Q sub-interface (NSS accelerates this path)
LAN ports = switch members, not independent interfaces
```

---

## VLAN Configuration (IoT Network)

### Create VLAN Sub-Interface

```bash
uci set network.eth1_25=device
uci set network.eth1_25.type='8021q'
uci set network.eth1_25.ifname='eth1'
uci set network.eth1_25.vid='25'
uci set network.eth1_25.name='eth1.25'
```

### Create Bridge and Interface

```bash
uci add network device
uci set network.@device[-1].type='bridge'
uci set network.@device[-1].name='br-iot'
uci add_list network.@device[-1].ports='eth1.25'

uci set network.iot=interface
uci set network.iot.proto='static'
uci set network.iot.device='br-iot'
uci set network.iot.ipaddr='192.168.25.1'
uci set network.iot.netmask='255.255.255.0'
```

### Configure DHCP

```bash
uci set dhcp.iot=dhcp
uci set dhcp.iot.interface='iot'
uci set dhcp.iot.start='100'
uci set dhcp.iot.limit='150'
uci set dhcp.iot.leasetime='12h'
```

### Firewall Zone

```bash
uci add firewall zone
uci set firewall.@zone[-1].name='iot'
uci set firewall.@zone[-1].input='ACCEPT'
uci set firewall.@zone[-1].output='ACCEPT'
uci set firewall.@zone[-1].forward='REJECT'
uci add_list firewall.@zone[-1].network='iot'

uci add firewall forwarding
uci set firewall.@forwarding[-1].src='iot'
uci set firewall.@forwarding[-1].dest='wan'

uci add firewall rule
uci set firewall.@rule[-1].name='Allow-DHCP-IoT'
uci add_list firewall.@rule[-1].proto='udp'
uci set firewall.@rule[-1].src='iot'
uci set firewall.@rule[-1].dest_port='67-68'
uci set firewall.@rule[-1].target='ACCEPT'

uci add firewall rule
uci set firewall.@rule[-1].name='Allow-DNS-IoT'
uci set firewall.@rule[-1].src='iot'
uci set firewall.@rule[-1].dest_port='53'
uci set firewall.@rule[-1].target='ACCEPT'

uci add firewall rule
uci set firewall.@rule[-1].name='Block-IoT-Intra'
uci set firewall.@rule[-1].src='iot'
uci set firewall.@rule[-1].dest='iot'
uci set firewall.@rule[-1].target='REJECT'
```

### Wi-Fi SSID Binding

```bash
uci set wireless.iot2g=wifi-iface
uci set wireless.iot2g.device='wifi0'
uci set wireless.iot2g.network='iot'
uci set wireless.iot2g.mode='ap'
uci set wireless.iot2g.ifname='wlan25'
uci set wireless.iot2g.ssid='IoT'
uci set wireless.iot2g.encryption='psk2+ccmp'
uci set wireless.iot2g.key='<password>'
uci set wireless.iot2g.hidden='0'
uci set wireless.iot2g.isolate='1'
uci set wireless.iot2g.ieee80211k='1'
uci set wireless.iot2g.bss_transition='1'
```

### Apply Changes

```bash
uci commit
(
sleep 2
/etc/init.d/network restart
sleep 5
/etc/init.d/firewall restart
/etc/init.d/dnsmasq restart
wifi reload
) &
```

---

## Switch Port Mapping

The Flint 3 uses `switch1` for LAN ports. Port numbering differs between physical layout, LuCI display, and UCI configuration:

| Physical Port | UCI switch1 Port | LuCI Display |
|---------------|------------------|--------------|
| LAN1 | 7 | LAN4 |
| LAN2 | 6 | LAN3 |
| LAN3 | 5 | LAN2 |
| LAN4 | 4 | LAN1 |
| CPU | 3 (tagged) | — |

```bash
# Example: VLAN 30 on LAN3 (physical) = port 5 in UCI
uci set network.vlan_iot='switch_vlan'
uci set network.vlan_iot.device='switch1'
uci set network.vlan_iot.vlan='30'
uci set network.vlan_iot.ports='3t 5ut'
```

---

## Multi-Link Operation (MLO) Wi-Fi

MLO is a Wi-Fi 7 feature that allows a client to simultaneously connect across multiple bands (2.4 GHz, 5 GHz, 6 GHz) as a single logical link.

### MLD Configuration

```bash
uci set mlo.mld1=wifi-mld
uci set mlo.mld1.disabled='0'
uci set mlo.mld1.bands='2g'
uci add_list mlo.mld1.bands='5g'
uci add_list mlo.mld1.bands='6g'

# 2.4 GHz interface
uci set wireless.mlo2g=wifi-iface
uci set wireless.mlo2g.device='wifi0'
uci set wireless.mlo2g.mode='ap'
uci set wireless.mlo2g.ssid='MLO-Network'
uci set wireless.mlo2g.encryption='ccmp'
uci set wireless.mlo2g.sae='1'
uci set wireless.mlo2g.key='<password>'
uci set wireless.mlo2g.mld='mld1'

# 5 GHz interface
uci set wireless.mlo5g=wifi-iface
uci set wireless.mlo5g.device='wifi1'
uci set wireless.mlo5g.mode='ap'
uci set wireless.mlo5g.ssid='MLO-Network'
uci set wireless.mlo5g.encryption='ccmp'
uci set wireless.mlo5g.sae='1'
uci set wireless.mlo5g.key='<password>'
uci set wireless.mlo5g.mld='mld1'

# 6 GHz interface
uci set wireless.mlo6g=wifi-iface
uci set wireless.mlo6g.device='wifi2'
uci set wireless.mlo6g.mode='ap'
uci set wireless.mlo6g.ssid='MLO-Network'
uci set wireless.mlo6g.encryption='ccmp'
uci set wireless.mlo6g.sae='1'
uci set wireless.mlo6g.key='<password>'
uci set wireless.mlo6g.mld='mld1'
```

!!! note "MLO and VLANs"
    As of firmware 4.7.x, MLO SSIDs do not appear in the stock GL.iNet web UI when added via UCI. They function correctly but require LuCI or SSH for management. GL.iNet has indicated MLO VLAN support is planned for a future firmware release.

---

## nftables Customization

OpenWRT 22.03+ uses `fw4` (nftables-based). Custom rules can be added to `/etc/nftables.d/`:

```bash
# /etc/nftables.d/10-custom.nft
chain custom_input {
    type filter hook input priority 0; policy accept;
    
    # Rate limit ICMP
    ip protocol icmp limit rate 10/second burst 20 packets accept
    ip6 nexthdr icmpv6 limit rate 10/second burst 20 packets accept
    
    # Log and drop invalid state
    ct state invalid log prefix "nft-invalid: " limit rate 5/minute drop
}
```

---

## IPv6 Subnetting on GL.iNet

Assign ULA (Unique Local Address) subnets to VLANs:

```bash
# Generate random ULA prefix: fdXX:XXXX:XXXX::/48
# Subnet for LAN: fdXX:XXXX:XXXX:1::/64
# Subnet for IoT: fdXX:XXXX:XXXX:25::/64

uci set network.lan.ip6assign='64'
uci set network.lan.ip6hint='1'
uci set network.iot.ip6assign='64'
uci set network.iot.ip6hint='25'

# Enable IPv6 forwarding
uci set network.globals.ula_prefix='fd12:3456:789a::/48'
```

---

## Related Deep Hole

- [GL.iNet Forum: VLAN on Flint 3](https://forum.gl-inet.com/t/how-to-set-up-the-vlan-for-iot-wi-fi-on-flint-3-gl-be9300/63364) — Official VLAN discussion thread
- [OpenWRT VLAN Documentation](https://openwrt.org/docs/guide-user/network/vlan/switch_configuration) — Generic VLAN configuration
- [Qualcomm NSS Documentation](https://forum.openwrt.org/t/qualcomm-nss-hardware-offloading/) — NSS acceleration details
- [The Flint 3 Stack](user-provided) — Complete VLAN and MLO configuration guide
"""

let render() = file
