module ConvertedFiles.Docs.Wikispace.WindowsAdvancedMd

let file = """# Windows Advanced Administration

Windows administrative tools and their roles in system configuration, DNS management, service control, and automated task scheduling. This page documents the exact procedures for configuring a sovereign DNS environment using Group Policy, Registry Editor, and native Windows management consoles.

---

## Overview

???+ note "What this page covers"
    Windows Group Policy DNS hardening via NRPT, registry modifications for domain join prevention, DCOM configuration, system properties, task scheduler, services management, Active Directory concepts, and DNS client operational logging. For the basic Windows setup walkthrough, see [Windows Wiki](windows.md). For Microsoft documentation references, see [Microsoft Documentation](microsoft-learn.md). For Portmaster configuration, see [Portmaster Deep](portmaster-deep.md).

---

## Group Policy Editor (gpedit.msc)

The Local Group Policy Editor (`gpedit.msc`) provides a structured interface for configuring Windows policies. On Windows 11 Pro, it can completely override domain controller and cloud-based policy settings when configured to enforce local preferences.

### DNS Resolution Policy

The Name Resolution Policy Table (NRPT) controls DNS behavior at the system level. A global NRPT rule (Key Name: `.`) applies to all DNS queries and overrides adapter-level settings.

```mermaid
flowchart TD
    Q["DNS Query"] --> N["NRPT<br/>(highest priority)"]
    N -->|"Match . rule"| R["192.168.30.1<br/>::"]
    N -->|"No match"| D["DoH Template"]
    D --> S["Static DNS"]
    S --> H["DHCP DNS"]
    H --> F["Fallback"]
    
    style N fill:#5a3a2d,color:#fff
    style R fill:#4a7c59,color:#fff
    style F fill:#333,color:#fff
```

```
Computer Configuration > Windows Settings > Name Resolution Policy
  Generic DNS Servers: 192.168.30.1, ::
  This creates a global policy forcing all queries through the specified resolver.
```

The NRPT is the highest-priority DNS mechanism in Windows. When active, it overrides DHCP DNS, static DNS, IPv6 DNS, DoH templates, WinHTTP DNS, NCSI DNS, Edge DNS, and Chrome DNS. The `GenericServerList` field specifies the resolver IP addresses. The presence of `::` (unspecified IPv6 address) as a second entry indicates that Windows should attempt IPv6 resolution but will fall back to the primary IPv4 address.

### DNS Client Policy Settings

The following Administrative Templates settings harden DNS client behavior:

| Policy Path | Setting | Value | Purpose |
|-------------|---------|-------|---------|
| ADMX > Network > DNS Client > Configure Discovery of Designated Resolvers (DDR) | Disabled | — | Prevents automatic DoH/DoT discovery |
| ADMX > Network > DNS Client > Configure encrypted name resolution | Enabled | Prohibit, Block DoH, Block DoT | Disables encrypted DNS |
| ADMX > Network > DNS Client > Configure multicast DNS (mDNS) | Disabled | — | Disables mDNS protocol |
| ADMX > Network > DNS Client > DNS servers | Enabled | 192.168.30.1 :: | Forces specific resolvers |
| ADMX > Network > DNS Client > Configure NetBIOS settings | Enabled | Disable NetBIOS | Blocks NetBIOS name resolution |
| ADMX > Network > DNS Client > Turn off smart multi-homed name resolution | Enabled | — | Prevents adapter fallback |
| ADMX > Network > DNS Client > Turn off smart protocol reordering | Enabled | — | Disables protocol preference changes |
| ADMX > Network > DNS Client > Turn off default IPv6 DNS Servers | Enabled | — | Disables built-in IPv6 DNS |
| ADMX > Network > DNS Client > Turn off multicast name resolution | Enabled | — | Disables LLMNR |
| ADMX > Network > DNS Client > Primary DNS suffix devolution | Disabled | — | Prevents domain suffix appending |

### Network Connectivity Status Indicator (NCSI)

NCSI probes Microsoft endpoints to determine internet connectivity. These probes can trigger unwanted DNS queries and resolver switching.

| Policy | Setting | Effect |
|--------|---------|--------|
| Specify Global DNS | Enabled, Use global DNS | Forces NCSI to use global rather than Microsoft-specific DNS |
| Specify passive polling | Enabled, Disable passive polling | Stops background connectivity probes |
| Turn off active probes | Enabled | Disables active NCSI probing |

### BITS and BranchCache

Background Intelligent Transfer Service (BITS) and BranchCache can create unintended network traffic:

| Policy | Setting | Effect |
|--------|---------|--------|
| Do not allow BITS to use Windows Branch Cache | Enabled | Isolates BITS from P2P caching |
| Do not allow computer to act as BITS Peercaching client | Enabled | Disables P2P client role |
| Do not allow computer to act as BITS Peercaching server | Enabled | Disables P2P server role |
| Allow BITS Peercaching | Disabled | Turns off P2P caching |
| Turn on BranchCache | Disabled | Disables BranchCache entirely |

### Additional Policies

```
ADMX > Network > TCPIP Settings > IPv6 Transition Technologies > Set Toredo State: Disabled

ADMX > System > Group Policy > Turn off Group Policy Client Service AOAC optimization: Enabled
ADMX > System > Group Policy > Turn off background refresh of Group Policy: Enabled
ADMX > System > Group Policy > Remove users ability to invoke machine policy refresh: Enabled

ADMX > Windows Components > MDM > Disable MDM Enrollment: Enabled
ADMX > Windows Components > Remote Desktop Services > Require secure RPC communication: Enabled
ADMX > Windows Components > Text Input > Improve inking and typing recognition: Disabled
ADMX > Windows Components > Windows PowerShell > Turn on Script Execution: RemoteSigned
ADMX > Windows Components > Windows Remote Shell > Allow Remote Shell Access: Disabled
```

---

## Registry Editor (regedit.msc)

Registry modifications enforce policies that Group Policy cannot reach, and create permanent configurations that survive system updates.

### Domain Join Prevention

```registry
HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\System
  NoDomainJoin = 1 (DWORD)
```

Blocks provisioning-based domain join, including MDM Autopilot enrollment and corporate provisioning packages. Prevents accidental or forced Azure AD / Entra ID joining.

### Netlogon SPN Blocking

```registry
HKLM\SYSTEM\CurrentControlSet\Services\Netlogon\Parameters
  AvoidSpnSet = 1 (DWORD)
```

Prevents Netlogon from registering Service Principal Names (SPNs). Without SPNs, domain join cannot complete, blocking domain trust negotiation and GPO controller locator traffic.

### Local GPO Override

```registry
HKLM\Software\Policies\Microsoft\Windows\System
  EnableLocalStoreOverride = 1 (DWORD)
```

Forces Local GPO to override domain GPO when both exist. Essential for sovereign workstations that may encounter conflicting domain policies.

---

## Component Services (dcomcnfg.exe)

DCOM Configuration (`dcomcnfg.exe`) manages Component Object Model distributed communication. For security hardening:

```
Component Services > Computers > My Computer > Properties > Default Properties
  Enable Distributed COM on this computer: No

Component Services > Computers > My Computer > Properties > Default Protocols
  Remove Connection-oriented TCP/IP (if DCOM not needed)
```

Disabling DCOM prevents remote COM object instantiation, blocking several lateral movement attack vectors including WMI-based persistence.

---

## System Properties (sysdm.cpl)

Advanced system settings control performance, user profiles, and remote access:

```
System Properties > Advanced > Performance Settings
  Adjust for best performance (removes visual effects)

System Properties > Advanced > User Profiles > Settings
  Manage local profiles and delete unused

System Properties > Remote
  Remote Assistance: Uncheck "Allow Remote Assistance connections"
  Remote Desktop: Select "Don't allow remote connections"
```

---

## Task Scheduler (taskschd.msc)

The Task Scheduler manages automated execution. Key security practices:

```powershell
# List all scheduled tasks
Get-ScheduledTask | Where-Object {$_.State -ne "Disabled"} |
    Select-Object TaskName, TaskPath, Author, State

# Disable telemetry-related tasks
$telemetryTasks = @(
    "Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser"
    "Microsoft\Windows\Application Experience\ProgramDataUpdater"
    "Microsoft\Windows\Autochk\Proxy"
    "Microsoft\Windows\Customer Experience Improvement Program\Consolidator"
    "Microsoft\Windows\Customer Experience Improvement Program\UsbCeip"
    "Microsoft\Windows\DiskDiagnostic\Microsoft-Windows-DiskDiagnosticDataCollector"
    "Microsoft\Windows\Maps\MapsUpdateTask"
)
foreach ($task in $telemetryTasks) {
    Disable-ScheduledTask -TaskName $task -ErrorAction SilentlyContinue
}
```

---

## Services (services.msc)

The Services console manages Windows background services. Key configurations for sovereign environments:

```batch
REM Critical services to evaluate
sc config Dnscache start= auto        REM DNS Client (required for NRPT)
sc config NlaSvc start= auto          REM Network Location Awareness
sc config netlogon start= disabled    REM Netlogon (not needed in workgroup)
sc config RemoteRegistry start= disabled
sc config TermService start= disabled REM Remote Desktop
sc config WinRM start= disabled       REM Windows Remote Management

REM Disable and stop Netlogon (prevents domain controller lookup)
sc config netlogon start= disabled
sc stop netlogon
```

---

## Active Directory and Forest Concepts

In a non-domain (workgroup) environment, Windows still contains AD-related components:

| Component | Workgroup Behavior | Domain Behavior |
|-----------|-------------------|-----------------|
| Netlogon | Can be disabled | Required for authentication |
| GPO | Local only | Centralized via SYSVOL |
| DNS SRV records | Not queried | Used for DC locator |
| Kerberos | Disabled | Primary auth protocol |
| NTLM | Local accounts only | Domain authentication |
| LDAP | Not used | Directory access protocol |

!!! note "NRPT in Workgroup Environments"
    NRPT does not require Active Directory, Azure AD, MDM, DirectAccess, or Enterprise enrollment. Local Group Policy is sufficient to configure and enforce NRPT rules, making it the primary tool for sovereign DNS control on standalone workstations.

---

## DNS Client Operational Logging

Windows DNS client activity can be traced through an analytic log that is disabled by default.

### Enable DNS Client Logging

```powershell
# Enable the operational log (requires elevated PowerShell)
wevtutil sl Microsoft-Windows-DNS-Client/Operational /enabled:true

# Verify
wevtutil gl Microsoft-Windows-DNS-Client/Operational
# Look for: enabled: true
```

### Event IDs

| Event ID | Meaning |
|----------|---------|
| 1014 | DNS name resolution failure |
| 3006 | DNS server unreachable / fallback triggered |
| 3008 | DNS server selected for query |
| 3010 | DNS settings changed |
| 3021 | NRPT rule applied |
| 5001 | DNS client service restarted |
| 5100 | DNS cache flushed |

### View Events

```powershell
# Recent DNS events
Get-WinEvent -LogName "Microsoft-Windows-DNS-Client/Operational" -MaxEvents 20 |
    Select-Object TimeCreated, Id, LevelDisplayName,
        @{N="Message";E={$_.Properties[0].Value}}

# Filter for NRPT rule applications (Event ID 3021)
Get-WinEvent -LogName "Microsoft-Windows-DNS-Client/Operational" |
    Where-Object {$_.Id -eq 3021} |
    Select-Object TimeCreated, @{N="Query";E={$_.Properties[1].Value}}
```

---

## PowerShell DNS Commands

```powershell
# View current DNS servers
Get-DnsClientServerAddress

# Remove DoH default resolvers
Get-DnsClientDohServerAddress | Remove-DnsClientDohServerAddress

# Set DNS server for an interface
Set-DnsClientServerAddress -InterfaceAlias "Ethernet" -ServerAddresses "192.168.30.1"

# Flush DNS cache
Clear-DnsClientCache

# Force Group Policy update
gpupdate /force

# Check Netlogon status
Get-Service Netlogon
sc config netlogon start= disabled
sc stop netlogon

# Verify WinHTTP proxy (should show "Direct access")
netsh winhttp show proxy
netsh winhttp reset proxy

# Disable active probing
Set-ItemProperty -Path "HKLM:\System\CurrentControlSet\Services\NlaSvc\Parameters\Internet" `
    -Name "EnableActiveProbing" -Value 0

# Troubleshooting sequence
ipconfig /flushdns
gpupdate /force
nslookup example.com 192.168.30.1
```

---

## Related Deep Hole

- [Microsoft Docs: Name Resolution Policy Table](https://docs.microsoft.com/en-us/windows-server/networking/dns/nrpt-mgmt) — Official NRPT documentation
- [SS64: gpresult](https://ss64.com/nt/gpresult.html) — Group Policy result tool
- [SS64: wevtutil](https://ss64.com/nt/wevtutil.html) — Windows Event Log utility
- [DNS in Windows with Group Policy](user-provided) — Sovereign DNS hardening profile with exact GPO paths
- [DNS Version 2](user-provided) — NRPT event analysis and DNS client operational logging
"""

let render() = file
