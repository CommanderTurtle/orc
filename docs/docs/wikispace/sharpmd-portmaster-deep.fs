module ConvertedFiles.Docs.Wikispace.PortmasterDeepMd

let file = """# Portmaster Deep Configuration

Portmaster is an application-layer firewall for Windows and Linux that operates below the socket layer, providing per-process network control independent of the Windows Firewall. This page covers advanced rule configuration, IPv6 management, and behavioral analysis of Windows system components.

---

## Overview

???+ note "What this page covers"
    This page documents advanced Portmaster configuration for Windows environments:

    - **Architecture** — Kernel driver socket-layer interception and Windows Firewall co-existence
    - **IPv6 Management** — Blocking IPv6 traffic and disabling the IPv6 stack
    - **svchost.exe Analysis** — Service group identification and per-group rules
    - **Edge WebView2** — Embedded web control network behavior and rules
    - **Filter Lists** — Custom blocklist integration and built-in categories
    - **DoT Configuration** — DNS-over-TLS with NRPT fallback chaining

    For basic Portmaster setup, see [Apps](apps.md). For Windows DNS hardening via NRPT, see [Windows Advanced](windows-advanced.md). For DNS resolver configuration, see [DNS and Firewall](dns.md).

---

## Architecture

```mermaid
flowchart TD
    subgraph AppLayer["Application Layer"]
        A1["Browser"]
        A2["Email Client"]
        A3["svchost.exe"]
        A4["WebView2"]
    end

    subgraph PM["Portmaster Kernel Driver"]
        direction TB
        INT["Socket Intercept"]
        PID["Process ID<br/>Resolution"]
        RULE["Rule Engine"]
        DNS["DNS Filter"]
    end

    subgraph WinFW["Windows Firewall"]
        WF["Host-Level<br/>Port/Scope Rules"]
    end

    subgraph Network["Network Stack"]
        NIC["Network Adapter"]
    end

    A1 --> INT
    A2 --> INT
    A3 --> INT
    A4 --> INT
    INT --> PID
    PID --> RULE
    INT --> DNS
    RULE --> WF
    DNS --> WF
    WF --> NIC

    style PM fill:#4a90d9
    style WinFW fill:#7ed321
```

Portmaster uses a kernel driver to intercept network connections at the socket layer, before data reaches the network adapter. This allows it to:

- Identify the originating process for every connection
- Apply per-application rules without port-based configuration
- Filter DNS queries before they leave the system
- Monitor connection history in real time

Portmaster operates alongside the Windows Firewall — it does not replace it. Windows Firewall handles host-level port blocking; Portmaster adds process-level visibility and DNS filtering.

---

## Disabling IPv6 via Portmaster

While Portmaster does not directly disable the IPv6 stack, it can block all IPv6 traffic:

```
Settings > Network > Internet > IPv6
  Set to "Blocked"

Settings > Network > Localhost > IPv6
  Set to "Blocked"
```

For a complete IPv6 disable, use Windows native controls in addition:

```powershell
# Disable IPv6 on all adapters
Get-NetAdapterBinding -ComponentID ms_tcpip6 |
    Disable-NetAdapterBinding -ComponentID ms_tcpip6

# Or selectively per adapter
Disable-NetAdapterBinding -Name "Ethernet" -ComponentID ms_tcpip6
Disable-NetAdapterBinding -Name "Wi-Fi" -ComponentID ms_tcpip6
```

---

## svchost.exe Behavior

`svchost.exe` (Service Host) is a generic host process for Windows services. Multiple services run within a single `svchost.exe` instance, grouped by:

```mermaid
flowchart TD
    subgraph SVCHOST["svchost.exe Instances"]
        direction TB
        LS["LocalService"]
        LSNR["LocalServiceNetworkRestricted"]
        NS["NetworkService"]
        SYSNR["LocalSystemNetworkRestricted"]
    end

    subgraph Services["Contained Services"]
        S1["DHCP Client"]
        S2["DNS Client"]
        S3["Windows Firewall"]
        S4["Windows Update"]
        S5["Windows Search"]
        S6["Network Connections"]
    end

    LS --> S1
    LS --> S3
    NS --> S2
    NS --> S6
    LSNR --> S4
    SYSNR --> S5

    style SVCHOST fill:#4a90d9
```

| Group | Typical Services |
|-------|-----------------|
| LocalService | DHCP, DNS, Windows Firewall, Windows Time |
| LocalServiceNetworkRestricted | Diagnostic Policy, Windows Update |
| LocalServiceNoNetwork | Windows Font Cache, HomeGroup Provider |
| LocalSystemNetworkRestricted | Windows Search, Superfetch |
| NetworkService | DNS Client, Network Connections |

Portmaster can distinguish between `svchost.exe` instances by service group, allowing granular rules:

```
Portmaster > Apps > svchost.exe (LocalService)
  DNS queries: Allow to 192.168.30.1 only
  Outbound connections: Block by default

Portmaster > Apps > svchost.exe (NetworkService)
  DNS queries: Allow to 192.168.30.1 only
  NCSI probes: Block
```

!!! warning "svchost and DNS"
    The DNS Client service (`Dnscache`) runs inside `svchost.exe (NetworkService)`. Blocking this instance entirely will disable all DNS resolution. When using NRPT, the DNS Client service is still required for policy enforcement — only block unwanted outbound connections from this instance, not DNS itself.

---

## Microsoft Edge WebView2 Behavior

Edge WebView2 (`msedgewebview2.exe`) is a Chromium-based embedded web control used by:

- Microsoft 365 applications (Teams, Outlook, Office)
- Windows Widgets
- Third-party applications using WebView2 SDK
- Some Windows system UI components

WebView2 establishes independent network connections separate from the host application. Portmaster rules should account for this:

```
Portmaster > Apps > Microsoft Edge WebView2
  Connections: Prompt for new domains
  DNS: Route through system DNS (NRPT-aware)
  LAN access: Block (unless required by app)
```

WebView2 uses the same network stack as Microsoft Edge, including:

- Independent DNS resolution (respects system DNS settings)
- HTTP/2 and HTTP/3 support
- QUIC protocol over UDP 443
- Certificate validation through Windows certificate store

---

## Custom Filter Rules

Portmaster supports custom filter lists in addition to built-in blocklists:

```
Settings > Filter Lists > Custom Filter Lists
  URL: https://raw.githubusercontent.com/StevenBlack/hosts/master/hosts
  Format: Hosts file

Settings > Filter Lists > Custom Filter Lists
  URL: https://someonewhocares.org/hosts/zero/hosts
  Format: Hosts file
```

Built-in filter categories:

| Category | Description |
|----------|-------------|
| Block Malware | Known malicious domains |
| Block Ads | Advertising networks |
| Block Trackers | Analytics and tracking domains |
| Block NSFW | Adult content (optional) |
| Block Gambling | Gambling sites (optional) |
| Block Child Abuse | IWF blocklist |

---

## DNS-over-TLS Configuration

```
Settings > DNS > Configure Upstream Resolvers
  Add: cloudflare-dns.com (1.1.1.1, 1.0.0.1)
  Add: dns.quad9.net (9.9.9.9, 149.112.112.112)
  Protocol: DoT (DNS-over-TLS)
  Fallback: System DNS (for local resolution)
```

When combined with Windows NRPT, Portmaster's DoT settings operate at the application layer while NRPT operates at the system layer. The effective behavior:

```mermaid
flowchart TD
    APP["Application<br/>DNS Query"] --> PM["Portmaster<br/>DNS Filter"]
    PM -->|"Blocked by filter list"| DROP["Drop"]
    PM -->|"Allowed"| DOT["Portmaster DoT<br/>(cloudflare-dns.com)"]
    DOT -->|"Success"| RES["Resolved"]
    DOT -->|"Failure"| NRPT["NRPT Resolver<br/>(192.168.30.1)"]
    NRPT -->|"Success"| RES
    NRPT -->|"Failure"| ADAPTER["Adapter DNS<br/>(if not disabled)"]
    ADAPTER --> RES

    style PM fill:#4a90d9
    style DOT fill:#7ed321
    style DROP fill:#d0021b
```

1. Application makes DNS query
2. Portmaster intercepts and applies filter lists
3. If not blocked, Portmaster sends via DoT to configured resolver
4. If DoT fails, falls back to NRPT-configured resolver (192.168.30.1)
5. If NRPT resolver fails, falls back to adapter DNS (if not disabled)

---

## Related Pages

- [Apps](apps.md) — General application deployment and Portmaster basics
- [Windows Advanced](windows-advanced.md) — NRPT DNS hardening, GPO configuration
- [DNS and Firewall](dns.md) — DNS resolver reference and iptables

## Related Deep Hole

- [Portmaster Documentation](https://docs.safing.io/) — Official configuration guide
- [Portmaster GitHub](https://github.com/safing/portmaster) — Source code and issues
- [Microsoft: WebView2 Runtime](https://docs.microsoft.com/en-us/microsoft-edge/webview2/) — WebView2 documentation
- [Microsoft: Service Host (svchost.exe)](https://docs.microsoft.com/en-us/windows/application-management/svchost-service-refactoring) — Service grouping
"""

let render() = file
