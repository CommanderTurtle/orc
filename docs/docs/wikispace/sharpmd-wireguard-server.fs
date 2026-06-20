module ConvertedFiles.Docs.Wikispace.WireguardServerMd

let file = """# WireGuard Server on Windows

Running a WireGuard server on Windows without the GUI, using only the official CLI tools and native Windows networking components. This approach avoids third-party helper tools and provides full control over the tunnel configuration, key management, and NAT routing.

---

## Overview

???+ note "What this page covers"
    This page documents running a WireGuard server on Windows using only CLI tools — no GUI. Covers key generation, server configuration, DPAPI service installation, and NAT routing with `New-NetNat`. For the broader VPN and networking context, see [Datacenters and Network Infrastructure](datacenters.md) and [ZeroTier](zerotier.md).

---

## Architecture

WireGuard on Windows uses a kernel-space virtual network adapter and a user-space management daemon. The CLI tools consist of:

```mermaid
graph LR
    C["Client<br/>10.21.209.2"] -->|"Encrypted UDP<br/>port 51563"| W["wg.exe +<br/>wireguard.exe"]
    W --> K["Kernel-space<br/>Virtual Adapter<br/>10.21.209.1"]
    K --> N["New-NetNat<br/>NAT"]
    N --> I["Physical Interface<br/>Wi-Fi / Ethernet"]
    I --> INT["Internet"]
    
    style C fill:#2d5a3a,color:#fff
    style W fill:#5a3a2d,color:#fff
    style K fill:#4a7c59,color:#fff
    style INT fill:#333,color:#fff
```

Configuration files must be stored as DPAPI-encrypted (`.conf.dpapi`) in `C:\Program Files\WireGuard\Data\Configurations\`. The DPAPI encryption is performed automatically when installing a tunnel service.

---

## Installation

Download the official MSI from wireguard.com. The MSI installs the virtual network adapter driver, `wg.exe`, and `wireguard.exe`. No GUI is required for server operation.

---

## Key Generation

```powershell
cd "C:\Program Files\WireGuard"

# Generate server private key
.\wg.exe genkey | Tee-Object -Variable ServerPrivKey > Data\server_private.key

# Derive server public key
$ServerPubKey = Get-Content Data\server_private.key | .\wg.exe pubkey
$ServerPubKey | Out-File Data\server_public.key

# Generate client keys
.\wg.exe genkey | Tee-Object -Variable Client1Priv > Data\client1_private.key
$Client1Pub = Get-Content Data\client1_private.key | .\wg.exe pubkey
$Client1Pub | Out-File Data\client1_public.key

# Display keys
Get-Content Data\server_public.key
Get-Content Data\server_private.key
Get-Content Data\client1_private.key
Get-Content Data\client1_public.key
```

WireGuard uses Curve25519 for key exchange. Each keypair is independent; there is no certificate authority or PKI hierarchy. The private key must be kept secret; the public key is shared with peers.

---

## Server Configuration

Create the plaintext configuration file:

```ini
; C:\Program Files\WireGuard\Data\Configurations\wg0.conf
[Interface]
PrivateKey = <SERVER_PRIVATE_KEY>
Address = 10.21.209.1/24
ListenPort = 51563

[Peer]
PublicKey = <CLIENT1_PUBLIC_KEY>
AllowedIPs = 10.21.209.2/32

[Peer]
PublicKey = <CLIENT2_PUBLIC_KEY>
AllowedIPs = 10.21.209.3/32
```

### Configuration Parameters

| Parameter | Description |
|-----------|-------------|
| `PrivateKey` | Server's Curve25519 private key |
| `Address` | Tunnel network CIDR for the server endpoint |
| `ListenPort` | UDP port for incoming connections |
| `PublicKey` (Peer) | Client's Curve25519 public key |
| `AllowedIPs` | IPs this peer may use inside the tunnel |

!!! warning "AllowedIPs on Server vs Client"
    On the **server**, `AllowedIPs` must be a per-client `/32`, specifying which tunnel IPs that client may claim. On the **client**, `AllowedIPs = 0.0.0.0/0` forces all traffic through the tunnel. These serve opposite purposes and must not be confused.

---

## Service Installation

Convert the plaintext config to DPAPI format and register as a Windows service:

```powershell
& "C:\Program Files\WireGuard\wireguard.exe" /installtunnelservice `
    "C:\Program Files\WireGuard\Data\Configurations\wg0.conf"
```

This creates `wg0.conf.dpapi` and registers the tunnel service. To control:

```powershell
# View tunnel status
& "C:\Program Files\WireGuard\wg.exe" show

# Uninstall tunnel service
& "C:\Program Files\WireGuard\wireguard.exe" /uninstalltunnelservice "wg0"

# Add peer to running interface without restart
& "C:\Program Files\WireGuard\wg.exe" set wg0 `
    peer <CLIENT_PUBLIC_KEY> `
    allowed-ips 10.21.209.4/32
```

---

## Client Configuration Template

```ini
; client1.conf
[Interface]
PrivateKey = <CLIENT_PRIVATE_KEY>
Address = 10.21.209.2/32
DNS = 192.168.10.1
MTU = 1420

[Peer]
PublicKey = <SERVER_PUBLIC_KEY>
AllowedIPs = 0.0.0.0/0
Endpoint = <PUBLIC_IP_OR_DDNS>:51563
PersistentKeepalive = 25
```

| Parameter | Description |
|-----------|-------------|
| `Address` | Client's tunnel IP (must match server's Peer AllowedIPs) |
| `DNS` | DNS server reachable from the tunnel endpoint |
| `MTU` | Maximum transmission unit (1420 accounts for WireGuard overhead) |
| `AllowedIPs = 0.0.0.0/0` | Routes all traffic through the tunnel (full tunnel) |
| `Endpoint` | Public IP or DDNS hostname of the server |
| `PersistentKeepalive` | Seconds between keepalive packets (required for NAT traversal) |

---

## NAT Configuration

Windows does not have built-in `iptables`-style NAT. Use `New-NetNat` (Hyper-V networking component):

### Enable IP Forwarding

```powershell
# Enable IPv4 forwarding (requires reboot)
New-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" `
    -Name "IPEnableRouter" -Value 1 -PropertyType DWORD -Force
```

### Enable Hyper-V Networking (if `New-NetNat` is unavailable)

```powershell
Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All
# Reboot required

# Verify NetNat classes are available
Get-CimClass -Namespace root/StandardCimv2 -ClassName *NetNat*
# Should return: MSFT_NetNat, MSFT_NetNatGlobal, MSFT_NetNatSession, MSFT_NetNatStaticMapping
```

### Create NAT Rule

```powershell
# Enable forwarding on interfaces
Set-NetIPInterface -InterfaceAlias "wg0" -Forwarding Enabled
Set-NetIPInterface -InterfaceAlias "Wi-Fi" -Forwarding Enabled

# Create NAT for WireGuard subnet
New-NetNat -Name "WG-NAT" -InternalIPInterfaceAddressPrefix "10.21.209.0/24"

# Verify
Get-NetNat
# Should show: InternalIPInterfaceAddressPrefix : 10.21.209.0/24

# Ensure default route exists on Wi-Fi
Get-NetRoute -InterfaceAlias "Wi-Fi" -AddressFamily IPv4
# Should show: 0.0.0.0/0 via <router-ip>

# Add route from WireGuard interface
New-NetRoute -InterfaceAlias "wg0" -DestinationPrefix 0.0.0.0/0 -NextHop 0.0.0.0

# Verify WG interface IP
Get-NetIPAddress -InterfaceAlias "wg0"
```

---

## Traffic Flow

```
Client (10.21.209.2)
  |
  | Encrypted WireGuard UDP
  v
Server wg0 (10.21.209.1)
  |
  | NAT (New-NetNat)
  v
Wi-Fi interface
  |
  | Standard routing
  v
Internet
```

---

## Full Directory Layout

```
C:\Program Files\WireGuard\
  wg.exe
  wireguard.exe
  Data\
    server_private.key
    server_public.key
    client1_private.key
    client1_public.key
    Configurations\
      wg0.conf
      wg0.conf.dpapi
      client1.conf
      wg0.log
```

---

## Security Properties

WireGuard enforces client authentication cryptographically, not via firewall rules. A peer can only connect if:

1. The server configuration contains a `[Peer]` entry with the client's public key
2. The client knows the server's public key
3. The client's private key matches the public key in the server config

If any condition fails, the handshake is rejected and the packet is silently dropped. There is no partial access, logging, or fallback.

---

## Related Deep Hole

- [WireGuard Official Documentation](https://www.wireguard.com/) — Protocol specification and whitepaper
- [WireGuard Windows Installation](https://download.wireguard.com/windows-client/) — Official MSI builds
- [PS History - WireGuard](user-provided) — Complete PowerShell setup procedures
- [WgServerforWindows Issue 206](https://github.com/micahmo/WgServerforWindows/issues/206) — Third-party helper discussion
"""

let render() = file
