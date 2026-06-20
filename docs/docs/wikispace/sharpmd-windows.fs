module ConvertedFiles.Docs.Wikispace.WindowsMd

let file = """# Windows Wiki

Windows system administration from initial installation through hardened configuration. This guide covers setup procedures, essential command-line tools, registry locations, and automation patterns for Windows 10 and Windows 11.

---

## Overview

???+ note "What this page covers"
    This page provides a comprehensive Windows administration reference:

    - **Initial Setup** — Post-install configuration, feature enablement
    - **System Information** — Commands for version, services, hotfixes, boot config
    - **Registry Essentials** — Critical paths, read/write/search operations
    - **File System** — dir, findstr, xcopy, robocopy, symbolic links
    - **User Management** — net user, icacls, permission control
    - **Service Management** — sc.exe configuration and control
    - **Networking** — ipconfig, netstat, route, netsh firewall
    - **PowerShell** — Common one-liners for administration tasks

    For advanced DNS hardening via NRPT and GPO, see [Windows Advanced](windows-advanced.md). For WSL2 and Kali Linux integration, see [WSL Guide](wsl.md). For cmd.exe literal-safe handling, see [cmd.exe Literacy](../xml-project/cmd-literacy.md).

---

## Initial Setup Walkthrough

### Post-Install Configuration

```powershell
# Set computer name
Rename-Computer -NewName "shel-workstation" -Restart

# Configure time zone
Set-TimeZone -Id "Eastern Standard Time"

# Enable PowerShell remoting (for remote management)
Enable-PSRemoting -Force -SkipNetworkProfileCheck

# Set execution policy for scripts
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope LocalMachine

# Install Windows updates
Install-Module PSWindowsUpdate -Force
Get-WindowsUpdate -AcceptAll -Install -AutoReboot
```

### Essential Features

```powershell
# Enable Windows Subsystem for Linux
Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux -NoRestart
Enable-WindowsOptionalFeature -Online -FeatureName VirtualMachinePlatform -NoRestart

# Enable Hyper-V (for VMs)
Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All -NoRestart

# Enable Windows Sandbox
Enable-WindowsOptionalFeature -Online -FeatureName Containers-DisposableClientVM -NoRestart
```

---

## System Information Commands

```batch
REM Windows version and build information
winver
ver
systeminfo | findstr /B /C:"OS Name" /C:"OS Version" /C:"System Type"

REM Environment variables
set
set | findstr /I "user profile path temp"

REM Running services
sc query type= service state= running

REM Installed hotfixes
wmic qfe get HotFixID,InstalledOn /format:table

REM Boot configuration
bcdedit /enum

REM Power configuration
powercfg /batteryreport
powercfg /energy
```

---

## Registry Essentials

### Critical Registry Paths

```mermaid
flowchart TD
    subgraph HKLM["HKEY_LOCAL_MACHINE"]
        direction TB
        L1["\Software\Microsoft\Windows\CurrentVersion\Run"]
        L2["\Software\Classes"]
        L3["\System\CurrentControlSet\Control\Session Manager\Environment"]
        L4["\Software\Policies\Microsoft\Windows\WindowsUpdate"]
        L5["\Software\Microsoft\Windows\CurrentVersion\Policies\System"]
    end

    subgraph HKCU["HKEY_CURRENT_USER"]
        direction TB
        C1["\Software\Microsoft\Windows\CurrentVersion\Run"]
        C2["\Environment"]
        C3["\Software\Microsoft\Windows\CurrentVersion\Explorer"]
    end

    HKLM -->|"Machine-wide"| L1
    HKLM -->|"File associations"| L2
    HKLM -->|"System env vars"| L3
    HKLM -->|"Windows Update GPO"| L4
    HKLM -->|"UAC settings"| L5
    HKCU -->|"User run keys"| C1
    HKCU -->|"User env vars"| C2
    HKCU -->|"Explorer config"| C3

    style HKLM fill:#4a90d9
    style HKCU fill:#7ed321
```

| Purpose | Registry Path |
|---------|---------------|
| Run keys (current user) | `HKCU\Software\Microsoft\Windows\CurrentVersion\Run` |
| Run keys (all users) | `HKLM\Software\Microsoft\Windows\CurrentVersion\Run` |
| File associations | `HKLM\Software\Classes` |
| System environment | `HKLM\System\CurrentControlSet\Control\Session Manager\Environment` |
| User environment | `HKCU\Environment` |
| Explorer settings | `HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer` |
| UAC configuration | `HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\System` |
| Windows Update | `HKLM\Software\Policies\Microsoft\Windows\WindowsUpdate` |

### Registry Operations

```batch
REM Read a value
reg query "HKCU\Environment" /v TEMP

REM Add or modify a value
reg add "HKCU\Environment" /v MY_VAR /t REG_SZ /d "my_value" /f

REM Delete a value
reg delete "HKCU\Environment" /v MY_VAR /f

REM Export a key to .reg file
reg export "HKCU\Environment" "env_backup.reg"

REM Import a .reg file
reg import "env_backup.reg"

REM Search for a value across keys
reg query HKLM /s /v DisplayName | findstr /I "target"
```

---

## File System Operations

```batch
REM List files with full details
dir /a /q /o:d /t:w

REM Find files by name (recursive)
where /R C:\ file.txt
dir /s /b file.txt

REM Find files containing text
findstr /s /i /m "search text" *.txt

REM Create nested directory structure
mkdir "path\to\new\directory"

REM Remove directory recursively
rmdir /s /q "path\to\directory"

REM Copy with attributes preserved
xcopy /e /i /h /k "source\" "dest\"

REM Robust file copy with resume
robocopy "source" "dest" /mir /z /r:3 /w:5 /mt:8

REM Create symbolic link (requires admin)
mklink "link.txt" "target.txt"
mklink /d "link_dir" "target_dir"
mklink /h "hardlink.txt" "target.txt"
```

---

## User and Permission Management

```batch
REM List local users
net user

REM List local groups
net localgroup

REM Create user
net user username password /add

REM Add to administrators group
net localgroup administrators username /add

REM Show current user's group membership
whoami /groups

REM View effective permissions on a file
icacls "C:\path\to\file"

REM Grant full control
icacls "C:\path" /grant username:F /t

REM Grant modify only
icacls "C:\path" /grant username:M

REM Revoke all permissions for a user
icacls "C:\path" /remove username
```

---

## Service Management

```batch
REM List all services with status
sc query type= service state= all

REM Start a service
sc start ServiceName
net start ServiceName

REM Stop a service
sc stop ServiceName
net stop ServiceName

REM Configure startup type
sc config ServiceName start= auto      REM Automatic
sc config ServiceName start= demand    REM Manual
sc config ServiceName start= disabled  REM Disabled

REM Query service configuration
sc qc ServiceName
```

---

## Networking Commands

```mermaid
flowchart LR
    subgraph Info["Information"]
        I1["ipconfig /all"]
        I2["netstat -an"]
        I3["route print"]
    end

    subgraph Action["Action"]
        A1["ipconfig /flushdns"]
        A2["netsh advfirewall set allprofiles state on"]
        A3["ipconfig /release && ipconfig /renew"]
    end

    subgraph Test["Testing"]
        T1["ping -t 8.8.8.8"]
        T2["tracert 8.8.8.8"]
        T3["nslookup example.com"]
    end

    style Info fill:#4a90d9
    style Action fill:#7ed321
    style Test fill:#f5a623
```

```batch
REM IP configuration
ipconfig /all
ipconfig /release
ipconfig /renew
ipconfig /flushdns
ipconfig /displaydns

REM Network statistics
netstat -an
netstat -b                    REM Requires admin; shows process names

REM Routing table
route print

REM Connectivity testing
ping -t 8.8.8.8
tracert 8.8.8.8
pathping 8.8.8.8

REM DNS resolution
nslookup example.com

REM Firewall status
netsh advfirewall show allprofiles
netsh advfirewall set allprofiles state on
```

---

## PowerShell One-Liners

```powershell
# Search files recursively for pattern
Get-ChildItem -Recurse -Filter "*.log" | Select-String -Pattern "ERROR"

# Find processes using high memory
Get-Process | Where-Object {$_.WorkingSet -gt 100MB} | Sort-Object WorkingSet -Descending | Select-Object -First 10

# Export service list to CSV
Get-Service | Export-Csv services.csv -NoTypeInformation

# Monitor file system changes
Get-WinEvent -FilterHashtable @{LogName='Security'; Id=4663} -MaxEvents 50

# Create scheduled task
$action = New-ScheduledTaskAction -Execute "powershell.exe" -Argument "-File C:\scripts\backup.ps1"
$trigger = New-ScheduledTaskTrigger -Daily -At "02:00"
Register-ScheduledTask -TaskName "DailyBackup" -Action $action -Trigger $trigger
```

---

## Related Pages

- [Windows Advanced](windows-advanced.md) — NRPT DNS hardening, GPO configuration
- [WSL Guide](wsl.md) — Windows Subsystem for Linux with Kali
- [cmd.exe Literacy](../xml-project/cmd-literacy.md) — Literal-safe cmd.exe handling
- [DNS and Firewall](dns.md) — DNS resolution and iptables reference

## Related Deep Hole

- [Microsoft Docs: Windows Commands](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/windows-commands) — Official command reference
- [SS64: Windows CMD Commands](https://ss64.com/nt/) — Comprehensive command-line reference
- [Microsoft Docs: PowerShell](https://docs.microsoft.com/en-us/powershell/) — Official PowerShell documentation
"""

let render() = file
