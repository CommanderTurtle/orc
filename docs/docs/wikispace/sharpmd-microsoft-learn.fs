module ConvertedFiles.Docs.Wikispace.MicrosoftLearnMd

let file = """# Microsoft Documentation

Microsoft provides comprehensive documentation for Windows administration, PowerShell scripting, .NET development, Azure cloud services, and enterprise infrastructure. This page consolidates the key Microsoft Learn resources referenced in the bookmarks file and expands on the PowerShell and Windows administration content previously distributed across other pages.

---

## Windows Administration

### Core Documentation

| Resource | URL | Description |
|----------|-----|-------------|
| Windows Commands Reference | https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/windows-commands | Complete command-line reference |
| PowerShell Documentation | https://learn.microsoft.com/en-us/powershell/ | Official PowerShell documentation |
| Windows Client Documentation | https://learn.microsoft.com/en-us/windows/ | Windows 10/11 admin guides |
| Windows Server Documentation | https://learn.microsoft.com/en-us/windows-server/ | Server administration |
| Windows Terminal Documentation | https://learn.microsoft.com/en-us/windows/terminal/ | Terminal emulator configuration |
| WinGet Package Manager | https://learn.microsoft.com/en-us/windows/package-manager/winget/ | Windows Package Manager reference |

### Registry and System Configuration

| Resource | URL | Description |
|----------|-----|-------------|
| Registry Reference | https://learn.microsoft.com/en-us/windows/win32/sysinfo/registry | Windows Registry API documentation |
| setlocal command | https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/setlocal | Localizes environment changes in batch scripts |
| reg command | https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/reg | Registry command-line operations |
| System Properties | https://learn.microsoft.com/en-us/windows/client-management/system-properties | sysdm.cpl configuration |
| Services | https://learn.microsoft.com/en-us/windows/win32/services/services | services.msc documentation |
| Task Scheduler | https://learn.microsoft.com/en-us/windows/win32/taskschd/task-scheduler-start-page | taskschd.msc documentation |

### Group Policy

| Resource | URL | Description |
|----------|-----|-------------|
| Group Policy Overview | https://learn.microsoft.com/en-us/windows/security/threat-protection/windows-firewall/group-policy-overview | GPO fundamentals |
| Local Group Policy Editor | https://learn.microsoft.com/en-us/windows/security/threat-protection/windows-firewall/open-the-group-policy-management-console | gpedit.msc usage |
| Security Baselines | https://learn.microsoft.com/en-us/windows/security/threat-protection/windows-security-configuration-framework/windows-security-baselines | Security baseline configurations |
| NRPT Management | https://learn.microsoft.com/en-us/windows-server/networking/dns/nrpt-mgmt | Name Resolution Policy Table |

### Networking

| Resource | URL | Description |
|----------|-----|-------------|
| TCP/IP Fundamentals | https://learn.microsoft.com/en-us/troubleshoot/windows-server/networking/overview-of-tcpip-tools | TCP/IP troubleshooting tools |
| DNS Client | https://learn.microsoft.com/en-us/windows-server/networking/dns/dns-client | Windows DNS client behavior |
| Windows Firewall | https://learn.microsoft.com/en-us/windows/security/operating-system-security/network-security/windows-firewall/ | Firewall configuration |
| IPConfig | https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/ipconfig | Network configuration command |
| Netsh | https://learn.microsoft.com/en-us/windows-server/networking/technologies/netsh/netsh | Network shell command |

---

## PowerShell

### Documentation Hierarchy

| Level | Resource | URL |
|-------|----------|-----|
| Getting Started | PowerShell 101 | https://learn.microsoft.com/en-us/powershell/scripting/learn/ps101/00-introduction |
| Language Reference | About Topics | https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about |
| Cmdlet Reference | Module Browser | https://learn.microsoft.com/en-us/powershell/module/ |
| Remoting | PowerShell Remoting | https://learn.microsoft.com/en-us/powershell/scripting/learn/remoting/ |
| DSC | Desired State Configuration | https://learn.microsoft.com/en-us/powershell/dsc/overview |

### Essential Cmdlet Categories

| Category | Key Cmdlets | Description |
|----------|-------------|-------------|
| File System | `Get-ChildItem`, `Set-Location`, `Copy-Item`, `Remove-Item` | Navigate and manipulate files |
| Registry | `Get-ItemProperty`, `Set-ItemProperty`, `New-Item` | Registry access via PSDrive |
| Services | `Get-Service`, `Start-Service`, `Stop-Service` | Service management |
| Processes | `Get-Process`, `Stop-Process`, `Start-Process` | Process control |
| Networking | `Test-Connection`, `Invoke-WebRequest`, `Test-NetConnection` | Network diagnostics |
| Security | `Get-Acl`, `Set-Acl`, `Get-ExecutionPolicy` | Permission and policy management |
| Events | `Get-WinEvent`, `New-EventLog`, `Write-EventLog` | Windows Event Log access |
| CIM/WMI | `Get-CimInstance`, `Invoke-CimMethod` | Hardware and software inventory |

### PowerShell Execution Policies

| Policy | Description | Security Level |
|--------|-------------|----------------|
| `Restricted` | No scripts allowed | Maximum |
| `AllSigned` | Only signed scripts | High |
| `RemoteSigned` | Local scripts OK; remote must be signed | Moderate |
| `Unrestricted` | All scripts run with warning | Low |
| `Bypass` | No restrictions | None |

```powershell
# Check current policy
Get-ExecutionPolicy

# Set policy (requires admin)
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope LocalMachine
```

---

## .NET and Development

| Resource | URL | Description |
|----------|-----|-------------|
| .NET Documentation | https://learn.microsoft.com/en-us/dotnet/ | .NET platform documentation |
| F# Documentation | https://learn.microsoft.com/en-us/dotnet/fsharp/ | F# language and tools |
| C# Reference | https://learn.microsoft.com/en-us/dotnet/csharp/ | C# language reference |
| ASP.NET Core | https://learn.microsoft.com/en-us/aspnet/core/ | Web development framework |
| Entity Framework | https://learn.microsoft.com/en-us/ef/ | ORM documentation |
| ML.NET | https://learn.microsoft.com/en-us/dotnet/machine-learning/ | Machine learning for .NET |

### F# Specific Resources

| Resource | URL | Description |
|----------|-----|-------------|
| F# Guide | https://learn.microsoft.com/en-us/dotnet/fsharp/ | F# documentation hub |
| F# History (HOPL) | https://fsharp.org/history/hopl-final/hopl-fsharp.pdf | ACM SIGPLAN HOPL conference paper |
| F# for Fun and Profit | https://fsharpforfunandprofit.com/ | Community tutorials |
| Giraffe Framework | https://github.com/giraffe-fsharp/Giraffe | F# web framework |
| Saturn Framework | https://saturnframework.org/ | F# MVC web framework |

---

## Azure and Cloud

| Resource | URL | Description |
|----------|-----|-------------|
| Azure Documentation | https://learn.microsoft.com/en-us/azure/ | Azure services documentation |
| Azure CLI | https://learn.microsoft.com/en-us/cli/azure/ | Command-line interface |
| Azure PowerShell | https://learn.microsoft.com/en-us/powershell/azure/ | Azure PowerShell modules |
| Microsoft Entra ID | https://learn.microsoft.com/en-us/entra/identity/ | Identity and access management |
| Azure Virtual Network | https://learn.microsoft.com/en-us/azure/virtual-network/ | Cloud networking |

---

## Microsoft 365 and Office

| Resource | URL | Description |
|----------|-----|-------------|
| Microsoft 365 Documentation | https://learn.microsoft.com/en-us/microsoft-365/ | Admin and user documentation |
| Office Deployment Tool | https://learn.microsoft.com/en-us/deployoffice/ | Enterprise deployment |
| Exchange Online | https://learn.microsoft.com/en-us/exchange/exchange-online | Email service |
| SharePoint | https://learn.microsoft.com/en-us/sharepoint/ | Document management |
| Teams | https://learn.microsoft.com/en-us/microsoftteams/ | Collaboration platform |

---

## Security and Compliance

| Resource | URL | Description |
|----------|-----|-------------|
| Microsoft Security | https://learn.microsoft.com/en-us/security/ | Security documentation hub |
| Defender for Endpoint | https://learn.microsoft.com/en-us/microsoft-365/security/defender-endpoint/ | Endpoint protection |
| Security Compliance Toolkit | https://www.microsoft.com/download/details.aspx?id=55319 | Security baseline tools |
| Credential Guard | https://learn.microsoft.com/en-us/windows/security/identity-protection/credential-guard/ | Hardware-based credential isolation |
| BitLocker | https://learn.microsoft.com/en-us/windows/security/operating-system-security/data-protection/bitlocker/ | Drive encryption |

---

## PowerShell Code Reference

### System Information

```powershell
# Windows version and build
Get-ComputerInfo | Select-Object WindowsProductName, WindowsVersion, OsBuildNumber

# Environment variables
Get-ChildItem Env: | Sort-Object Name

# Running services
Get-Service | Where-Object {$_.Status -eq 'Running'} | Select-Object Name, DisplayName

# Installed hotfixes
Get-HotFix | Select-Object HotFixID, InstalledOn | Sort-Object InstalledOn -Descending

# Boot configuration
bcdedit /enum

# Power configuration
powercfg /batteryreport
powercfg /energy
```

### File System Operations

```powershell
# List files with full details
Get-ChildItem -Path C:\Path -Recurse | Select-Object Name, Length, LastWriteTime

# Find files by name
Get-ChildItem -Path C:\ -Filter '*.log' -Recurse -ErrorAction SilentlyContinue

# Find files containing text
Select-String -Path '*.txt' -Pattern 'search term'

# Create directory
New-Item -Path 'C:\NewFolder' -ItemType Directory

# Remove directory recursively
Remove-Item -Path 'C:\OldFolder' -Recurse -Force

# Copy with attributes
Copy-Item -Path 'C:\Source' -Destination 'C:\Dest' -Recurse

# Robust file copy
robocopy C:\Source C:\Dest /MIR /Z /R:3 /W:5 /MT:8
```

### User and Permission Management

```powershell
# List local users
Get-LocalUser | Select-Object Name, Enabled, LastLogon

# List local groups
Get-LocalGroup | Select-Object Name, Description

# Create user
New-LocalUser -Name 'username' -Password (ConvertTo-SecureString -AsPlainText 'password' -Force)

# Add to administrators
Add-LocalGroupMember -Group 'Administrators' -Member 'username'

# View effective permissions
Get-Acl -Path 'C:\Path\To\File' | Format-List

# Grant permissions
$path = 'C:\Path'
$rule = New-Object System.Security.AccessControl.FileSystemAccessRule('username', 'Modify', 'ContainerInherit,ObjectInherit', 'None', 'Allow')
$acl = Get-Acl $path
$acl.SetAccessRule($rule)
Set-Acl $path $acl
```

### Service Management

```powershell
# List all services with status
Get-Service | Select-Object Name, Status, StartType | Sort-Object Status

# Start a service
Start-Service -Name 'ServiceName'

# Stop a service
Stop-Service -Name 'ServiceName'

# Configure startup type
Set-Service -Name 'ServiceName' -StartupType Automatic   # Automatic, Manual, Disabled

# Query service configuration
Get-CimInstance Win32_Service -Filter "Name = 'ServiceName'" | Select-Object *
```

### Networking

```powershell
# IP configuration
Get-NetIPConfiguration

# Network statistics
Get-NetTCPConnection | Select-Object LocalAddress, LocalPort, RemoteAddress, State

# Routing table
Get-NetRoute | Select-Object DestinationPrefix, NextHop, InterfaceAlias, RouteMetric

# Connectivity testing
Test-Connection -ComputerName 8.8.8.8 -Count 4
Test-NetConnection -ComputerName example.com -Port 443

# DNS resolution
Resolve-DnsName -Name example.com

# Firewall status
Get-NetFirewallProfile | Select-Object Name, Enabled, DefaultInboundAction
```

---

## Related Deep Hole

- [Microsoft Learn](https://learn.microsoft.com/) — Master documentation portal
- [Microsoft Q&A](https://learn.microsoft.com/en-us/answers/) — Community Q&A platform
- [PowerShell Gallery](https://www.powershellgallery.com/) — PowerShell module repository
- [SS64: Windows CMD Commands](https://ss64.com/nt/) — Community-maintained command reference
- [SS64: PowerShell Commands](https://ss64.com/ps/) — Community PowerShell reference
"""

let render() = file
