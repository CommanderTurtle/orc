module ConvertedFiles.Docs.Wikispace.AppsMd

let file = """# Applications

Productivity software, development tools, security applications, and driver management for Windows environments.

---

## Overview

???+ note "What this page covers"
    This page documents essential Windows application deployment and management:

    - **Microsoft 365** — Office Deployment Tool scripted installation and update channel selection
    - **Portmaster** — Application firewall with per-process rules and DNS-over-TLS
    - **Visual Studio Code** — Editor configuration, essential extensions, settings.json
    - **Driver Management** — DISM, pnputil, and PowerShell device management
    - **Package Management** — winget and Chocolatey for automated software deployment

    For advanced Portmaster rules and svchost analysis, see [Portmaster Deep](portmaster-deep.md). For Windows system administration, see [Windows Wiki](windows.md). For WSL and Kali Linux, see [WSL Guide](wsl.md).

---

## Microsoft 365

### Office Deployment Tool

The Office Deployment Tool (ODT) enables scripted installation of Microsoft 365 Apps with custom configuration.

```xml
<!-- configuration.xml -->
<Configuration>
  <Add OfficeClientEdition="64" Channel="MonthlyEnterprise">
    <Product ID="O365ProPlusRetail">
      <Language ID="en-us" />
      <ExcludeApp ID="Teams" />
      <ExcludeApp ID="OneDrive" />
      <ExcludeApp ID="Groove" />
      <ExcludeApp ID="Lync" />
    </Product>
  </Add>
  <Display Level="None" AcceptEULA="TRUE" />
  <Property Name="AUTOACTIVATE" Value="0" />
  <Updates Enabled="TRUE" Channel="MonthlyEnterprise" />
</Configuration>
```

```batch
REM Download ODT
setup.exe /download configuration.xml

REM Install
setup.exe /configure configuration.xml
```

### Channel Selection

| Channel | Update Frequency | Stability | Use Case |
|---------|-----------------|-----------|----------|
| Current | Monthly | Feature-first | Development workstations |
| Monthly Enterprise | Monthly (1 week deferral) | Balanced | General business |
| Semi-Annual Enterprise | Every 6 months | Maximum stability | Regulated environments |

### Microsoft Store Apps

```powershell
# Install Store apps via winget
winget install Microsoft.PowerToys
winget install Microsoft.WindowsTerminal
winget install Microsoft.Powershell
winget install Microsoft.VisualStudioCode

# List installed Store apps
Get-AppxPackage | Select-Object Name, PackageFullName | Sort-Object Name
```

---

## Portmaster

Portmaster is an application firewall for Windows and Linux that provides per-process network control, DNS-over-TLS, and filter list integration.

```mermaid
flowchart TD
    subgraph Apps["Applications"]
        A1["Browser"]
        A2["Email"]
        A3["System"]
    end

    subgraph PM["Portmaster"]
        direction TB
        INT["Socket<br/>Intercept"]
        PID["Process<br/>ID"]
        RULE["Per-App<br/>Rules"]
        DNS["DNS-over-TLS"]
        FL["Filter Lists"]
    end

    Apps --> INT
    INT --> PID
    PID --> RULE
    RULE --> DNS
    DNS --> FL
    FL -->|"Allowed"| OUT["Internet"]
    FL -->|"Blocked"| DROP["Drop<br/>(ads/trackers/malware)"]

    style PM fill:#4a90d9
    style DROP fill:#d0021b
```

### Key Features

| Feature | Description |
|---------|-------------|
| **Per-App Rules** | Allow or block network access per process |
| **DNS-over-TLS** | Encrypted DNS queries to configurable resolvers |
| **Filter Lists** | Block ads, trackers, malware at the DNS level |
| **Connection History** | Real-time and historical connection monitoring |
| **SPN** | Optional Safing Privacy Network (VPN-like routing) |

### Configuration

```
Settings > DNS > Configure upstream resolvers
Settings > Filter Lists > Enable: EasyList, EasyPrivacy, Malware Domain List
Settings > Network > Default Action: Prompt for unknown apps
Settings > Network > Default Action: Allow for trusted apps
```

!!! tip "Portmaster with Windows Firewall"
    Portmaster complements rather than replaces the Windows Firewall. Use Windows Firewall for host-level rules (port blocking, scope restriction) and Portmaster for application-level visibility and DNS filtering.

---

## Visual Studio Code Workflows

### Essential Extensions

| Extension | Publisher | Purpose |
|-----------|-----------|---------|
| `ms-vscode.powershell` | Microsoft | PowerShell language support |
| `vscodevim.vim` | vscodevim | Vim keybindings |
| `eamodio.gitlens` | GitKraken | Git blame, history, annotations |
| `oderwat.indent-rainbow` | oderwat | Visual indentation guides |
| `shardulm94.trailing-spaces` | Shardul | Trailing space highlighting |
| `ms-vscode-remote.remote-wsl` | Microsoft | WSL remote development |

### settings.json Configuration

```json
{
  "editor.renderWhitespace": "boundary",
  "editor.rulers": [80, 120],
  "files.trimTrailingWhitespace": true,
  "files.insertFinalNewline": true,
  "files.eol": "\n",
  "powershell.codeFormatting.preset": "OTBS",
  "powershell.scriptAnalysis.enable": true,
  "terminal.integrated.defaultProfile.windows": "PowerShell",
  "terminal.integrated.profiles.windows": {
    "PowerShell": {
      "source": "PowerShell",
      "args": ["-NoExit", "-Command", "Set-Location C:\\projects"]
    }
  }
}
```

---

## Driver Management

### Windows Driver Store

Windows maintains a driver store at `C:\Windows\System32\DriverStore\FileRepository`. Each driver package is stored in a subdirectory with a hashed name.

```batch
REM List third-party drivers
dism /online /get-drivers /format:table

REM Export all third-party drivers
dism /online /export-driver /destination:C:\DriverBackup

REM Add driver to offline image
dism /image:C:\offline /add-driver /driver:C:\Drivers\driver.inf

REM Remove driver from offline image
dism /image:C:\offline /remove-driver /driver:oem###.inf
```

### Driver Installation Tools

| Tool | Purpose |
|------|---------|
| `pnputil` | Add, remove, enumerate driver packages |
| `devcon` | Device management (requires Windows SDK) |
| PowerShell `Get-PnpDevice` | List and manage plug-and-play devices |

```powershell
# List all devices with driver issues
Get-PnpDevice -Status ERROR,DEVNODE_NOT_STARTED

# Update driver for a device
Update-PnpDevice -InstanceId "PCI\..." -Confirm:$false

# Disable a device
Disable-PnpDevice -InstanceId "PCI\..." -Confirm:$false
```

---

## Package Management

### winget (Windows Package Manager)

```batch
REM Search for packages
winget search notepad++

REM Install
winget install Notepad++.Notepad++

REM Update all
winget upgrade --all

REM Export installed packages
winget export -o packages.json

REM Import packages
winget import -i packages.json
```

### Chocolatey (Alternative)

```powershell
# Install Chocolatey
Set-ExecutionPolicy Bypass -Scope Process -Force
[System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072
Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

# Install packages
choco install 7zip firefox notepadplusplus -y
```

---

## Related Pages

- [Portmaster Deep](portmaster-deep.md) — Advanced rules, svchost analysis, DoT configuration
- [Windows Wiki](windows.md) — System administration commands and registry
- [WSL Guide](wsl.md) — Windows Subsystem for Linux with Kali

## Related Deep Hole

- [Microsoft 365 Deployment Guide](https://docs.microsoft.com/en-us/deployoffice/) — Official deployment documentation
- [Portmaster Documentation](https://docs.safing.io/) — Application firewall documentation
- [VS Code Documentation](https://code.visualstudio.com/docs) — Official editor documentation
- [winget Documentation](https://docs.microsoft.com/en-us/windows/package-manager/winget/) — Windows Package Manager reference
- [Microsoft Docs: DISM Driver Servicing](https://docs.microsoft.com/en-us/windows-hardware/manufacture/desktop/dism-driver-servicing-command-line-options-s14) — Driver management commands
"""

let render() = file
