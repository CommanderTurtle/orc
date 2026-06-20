module ConvertedFiles.Docs.Wikispace.Security.MinimalismMd

let file = """# Strength through Minimalism

Every component running on a system represents a potential attack surface. Minimalism is the practice of reducing that surface by eliminating unnecessary software, services, protocols, and features. The principle is straightforward: a system cannot be compromised through a component that does not exist.

---

## Overview

???+ note "What this page covers"
    This page documents attack surface reduction through system minimalism:

    - **Software Removal** — Identifying and eliminating unused programs and features
    - **Service Hardening** — Disabling unnecessary Windows services
    - **Legacy Protocol Disabling** — SMBv1, LLMNR, NetBIOS elimination
    - **Network Minimalism** — Port closure and secure protocol selection
    - **Defender Configuration** — Windows Defender PUA and cloud protection

    For permission management and ACL configuration, see [Permissions](permissions.md). For encryption configuration, see [Encryption](encryption.md). For network firewall rules, see [DNS and Firewall](../dns.md).

---

## Attack Surface Reduction

### Remove Unused Software

```powershell
# List installed programs
Get-ItemProperty HKLM:\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\* |
    Select-Object DisplayName, DisplayVersion |
    Sort-Object DisplayName

# Remove via winget
winget uninstall "AppName"

# Remove Windows features
Disable-WindowsOptionalFeature -Online -FeatureName "TFTP" -Remove
```

### Disable Unnecessary Services

```batch
REM Common services to evaluate for disabling
sc config Fax start= disabled
sc config WMPNetworkSvc start= disabled
sc config TabletInputService start= disabled
sc config MapsBroker start= disabled
sc config lfsvc start= disabled
sc config SharedAccess start= disabled
sc config RetailDemo start= disabled
sc config WalletService start= disabled
sc config PhoneSvc start= disabled
sc config WbioSrvc start= disabled
```

!!! warning "Evaluate Before Disabling"
    Each service should be evaluated against its actual use case before disabling. The list above represents common candidates for personal workstations but may not apply to all configurations. Document every change and test system functionality after modification.

---

## Windows-Specific Hardening

### Disable Legacy Protocols

```batch
REM Disable SMBv1 (exploited by WannaCry, EternalBlue)
dism /online /Disable-Feature /FeatureName:SMB1Protocol

REM Disable LLMNR (Link-Local Multicast Name Resolution)
REM Mitigates responder-style attacks
reg add "HKLM\Software\Policies\Microsoft\Windows NT\DNSClient" /v EnableMulticast /t REG_DWORD /d 0 /f

REM Disable NetBIOS over TCP/IP
REM Reduces broadcast traffic and attack surface
```

### Windows Defender Configuration

```powershell
# Enable PUA (Potentially Unwanted Application) protection
Set-MpPreference -PUAProtection Enabled

# Enable cloud-delivered protection
Set-MpPreference -MAPSReporting Advanced

# Enable network protection
Set-MpPreference -EnableNetworkProtection Enabled

# Set real-time monitoring
Set-MpPreference -DisableRealtimeMonitoring $false
```

---

## Network Minimalism

### Close Unnecessary Ports

```bash
# Linux: Identify listening ports
ss -tlnp

# Close all ports except required services
iptables -P INPUT DROP
iptables -A INPUT -p tcp --dport 22 -j ACCEPT
iptables -A INPUT -p tcp --dport 80 -j ACCEPT
iptables -A INPUT -p tcp --dport 443 -j ACCEPT
iptables -A INPUT -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT
```

### Protocol Selection

```mermaid
flowchart TD
    subgraph Legacy["Legacy (Disable)"]
        L1["Telnet / Rlogin"]
        L2["SMBv1"]
        L3["Plain DNS"]
        L4["LLMNR / NetBIOS"]
    end

    subgraph Modern["Modern (Enable)"]
        M1["SSH"]
        M2["HTTPS / TLS 1.3"]
        M3["SMBv3 + Encryption"]
        M4["DoH / DoT"]
    end

    Legacy -->|"Replace with"| Modern

    style Legacy fill:#d0021b
    style Modern fill:#7ed321
```

| Protocol | Recommendation | Rationale |
|----------|---------------|-----------|
| SSH | Use exclusively; disable Telnet/Rlogin | Encrypted, authenticated |
| HTTPS | Use exclusively; redirect HTTP | TLS encryption |
| SMBv3 | Use with encryption; disable SMBv1/2 | AES-128-GCM encryption |
| DNS | Use DoH or DoT; disable plain DNS | Query privacy |
| IPv6 | Firewall equally with IPv4 | Same attack surface |

---

## Related Pages

- [Permissions](permissions.md) — ACL configuration and least privilege
- [Encryption](encryption.md) — Data at rest and in transit protection
- [Containerization](containerization.md) — Application isolation
- [DNS and Firewall](../dns.md) — Network-level access control

## Related Deep Hole

- [CIS Benchmarks](https://www.cisecurity.org/cis-benchmarks) — Hardening guidelines for Windows, Linux, macOS
- [Microsoft Security Baselines](https://docs.microsoft.com/en-us/windows/security/threat-protection/windows-security-configuration-framework/windows-security-baselines) — Official Windows security configurations
- [NSA Cybersecurity Guidance](https://www.nsa.gov/Press-Room/Fact-Sheets/Article/2699578/nsa-cybersecurity-information/) — Security hardening fact sheets
"""

let render() = file
