module ConvertedFiles.Docs.Wikispace.WslMd

let file = """# WSL Guide

Windows Subsystem for Linux provides a full Linux kernel environment on Windows without traditional virtualization overhead. WSL2 uses a lightweight utility VM with the actual Linux kernel, providing full system call compatibility. This page covers WSL2 installation, configuration for security-focused distributions (Kali Linux), and integration with Qubes OS workflows.

---

## Overview

???+ note "What this page covers"
    This page documents Windows Subsystem for Linux deployment and configuration:

    - **Installation** — WSL2 setup on Windows 10 and Windows 11
    - **Kali Linux** — Security distribution installation and tool management
    - **Configuration** — Global `.wslconfig` and per-distribution `wsl.conf`
    - **Windows Integration** — File system access, cross-OS execution, GUI applications
    - **GPU Support** — CUDA passthrough for hashcat and GPU-accelerated tools
    - **Backup/Restore** — Distribution export/import and VHD compaction

    For general Windows administration, see [Windows Wiki](windows.md). For advanced DNS hardening on Windows, see [Windows Advanced](windows-advanced.md). For hypervisor-based compartmentalization alternatives, see [Hypervisors](security/hypervisors.md).

---

## Architecture

```mermaid
flowchart TD
    subgraph Win["Windows Host"]
        direction TB
        App["Windows Apps"]
        PS["PowerShell / CMD"]
    end

    subgraph WSL2["WSL2 Lightweight VM"]
        direction TB
        VMM["Virtual Machine<br/>Platform"]
        LX["Linux Kernel<br/>(actual kernel)"]
        NS["Namespaces<br/>(PID, NET, MNT)"]
        CG["cgroups"]

        subgraph Distros["Distributions"]
            Kali["Kali Linux"]
            Ubuntu["Ubuntu"]
        end
    end

    subgraph HW["Hardware"]
        GPU["NVIDIA GPU"]
        NIC["Network Adapter"]
        DISK["Storage (VHDX)"]
    end

    App -->|"wsl -d kali-linux"| Kali
    PS -->|"wsl command"| Kali
    Kali -->|"GUI apps (WSLg)"| Win
    Kali -->|"CUDA (DXGKrNL)"| GPU
    VMM --> NIC
    VMM --> DISK
    LX --> VMM
    NS --> LX
    CG --> LX
    Distros --> NS

    style WSL2 fill:#4a90d9
    style Kali fill:#7ed321
```

---

## Installation

### Windows 11 (Single Command)

```powershell
wsl --install
```

This installs WSL2, the default Ubuntu distribution, and required Windows features. Restart when prompted, then the Ubuntu installation will complete automatically.

### Windows 10 (Manual)

```powershell
# Enable required Windows features
dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart
dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all /norestart

# Download WSL2 kernel update
Invoke-WebRequest -Uri "https://wslstorestorage.blob.core.windows.net/wslblob/wsl_update_x64.msi" -OutFile "wsl_update.msi"
msiexec /i wsl_update.msi /quiet

# Set WSL2 as default
wsl --set-default-version 2
```

---

## Kali Linux Installation

Kali Linux is a Debian-derived distribution maintained by Offensive Security, preconfigured for penetration testing and security auditing.

```powershell
# Install Kali from Microsoft Store or command line
wsl --install -d kali-linux

# Or download from store
Invoke-WebRequest -Uri https://aka.ms/wsl-kali-linux-new -OutFile Kali.appx -UseBasicParsing
Add-AppxPackage .\Kali.appx

# Update Kali after installation
wsl -d kali-linux -e apt update
wsl -d kali-linux -e apt full-upgrade -y

# Install common tools
wsl -d kali-linux -e apt install -y nmap metasploit-framework wireshark john hashcat
```

### Kali-Specific Tools

| Tool | Purpose | Category |
|------|---------|----------|
| nmap | Network scanning and discovery | Information gathering |
| metasploit | Exploitation framework | Exploitation |
| wireshark | Network protocol analyzer | Sniffing/Spoofing |
| john | Password cracker | Password attacks |
| hashcat | GPU-accelerated password recovery | Password attacks |
| aircrack-ng | Wireless security auditing | Wireless attacks |
| sqlmap | SQL injection automation | Web application |
| burpsuite | Web proxy and scanner | Web application |
| gobuster | Directory/file/DNS busting | Information gathering |
| impacket | Python network protocols | Post-exploitation |

---

## Configuration

### Global Configuration (.wslconfig)

Place in `%USERPROFILE%\.wslconfig`:

```ini
[wsl2]
memory=8GB
processors=4
swap=2GB
swapFile=C:\temp\wsl-swap.vhdx
localhostForwarding=true
kernelCommandLine=cgroup_enable=memory
firewall=true
dnsTunneling=true
autoProxy=true
sparseVhd=true
```

### Distribution-Specific Configuration (wsl.conf)

Place in `/etc/wsl.conf` inside the distribution:

```ini
[boot]
systemd=true
command = /usr/local/bin/custom-startup.sh

[user]
default=kali

[network]
generateHosts=true
generateResolvConf=true
hostname=shel-kali

[interop]
enabled=true
appendWindowsPath=false

[automount]
enabled=true
mountFsTab=true
root=/mnt/
options="metadata,umask=22,fmask=11"
crossDistro=true

[experimental]
autoMemoryReclaim=gradual
sparseVhd=true
```

---

## Windows-Kali Integration

### File System Access

| Location | Access Method |
|----------|---------------|
| Windows C: drive | `/mnt/c/` |
| Windows home | `/mnt/c/Users/$WINUSER/` |
| Kali home | `\\wsl$\kali-linux\home\kali` |
| Kali root | `\\wsl$\kali-linux\` |

### Cross-OS Command Execution

```bash
# From Kali: run Windows executable
notepad.exe file.txt
/cmd.exe /c ipconfig

# From PowerShell: run Kali command
wsl -d kali-linux nmap -sV target.com
wsl -d kali-linux msfconsole -q -x "use auxiliary/scanner/http/dirbuster"
```

### Graphical Applications (WSLg)

WSL2 includes WSLg, which supports running Linux GUI applications without additional configuration:

```bash
# Kali GUI tools work directly
wsl -d kali-linux wireshark &
wsl -d kali-linux burpsuite &
```

---

## Qubes OS Comparison

Qubes OS and WSL2 serve fundamentally different purposes but are both relevant to security-focused workflows.

```mermaid
flowchart TD
    subgraph Q["Qubes OS"]
        direction TB
        QXEN["Type 1 Hypervisor<br/>(Xen)"]
        QDOM0["dom0<br/>(Admin)"]
        QSYS["sys-net<br/>sys-firewall<br/>sys-usb"]
        QAPP["AppVMs<br/>(Compartmentalized)"]
        QXEN --> QDOM0
        QDOM0 --> QSYS
        QDOM0 --> QAPP
    end

    subgraph W["WSL2 on Windows"]
        direction TB
        WW["Windows Host<br/>(Namespace isolation)"]
        WVM["Utility VM<br/>(Lightweight)"]
        WKA["Kali Linux"]
        WUB["Ubuntu"]
        WW --> WVM
        WVM --> WKA
        WVM --> WUB
    end

    Q -->|"Strong isolation<br/>Dedicated security OS"| QC{"Use Case"}
    W -->|"Dev/testing focus<br/>Broad compatibility"| QC

    style Q fill:#4a90d9
    style W fill:#7ed321
```

| Aspect | Qubes OS | WSL2 |
|--------|----------|------|
| Architecture | Type 1 hypervisor (Xen) | Type 2 utility VM |
| Isolation | Strong VM-level isolation | Namespace/cgroup isolation |
| Host OS | Dedicated security OS | Windows 10/11 |
| Use case | High-security workstation | Development, testing |
| Hardware | Requires specific compatibility | Broad hardware support |
| GUI | Native XFCE with X11 trust | WSLg (Wayland/RDP) |
| Networking | Sys-net VM isolation | Shared Windows network stack |

Qubes OS is the superior choice for high-threat environments requiring compartmentalization. WSL2 is appropriate for security tool access on standard Windows workstations where hardware compatibility or software requirements preclude Qubes.

---

## GPU Support (CUDA)

```bash
# In Kali: install NVIDIA CUDA
wget https://developer.download.nvidia.com/compute/cuda/repos/wsl-ubuntu/x86_64/cuda-keyring_1.0-1_all.deb
dpkg -i cuda-keyring_1.0-1_all.deb
apt update
apt install -y cuda-toolkit-12-3

# Verify
nvidia-smi
hashcat -I  # List GPU devices for hashcat
```

---

## Backup and Restore

```powershell
# Export Kali distribution to tar
wsl --export kali-linux C:\backups\kali-backup.tar

# Import from backup (with custom location)
wsl --import kali-custom C:\WSL\kali-custom C:\backups\kali-backup.tar --version 2

# Compact VHD (reclaim disk space)
wsl --shutdown
diskpart
# select vdisk file="C:\Users\...\ext4.vhdx"
# attach vdisk readonly
# compact vdisk
# detach vdisk
```

---

## Related Pages

- [Windows Wiki](windows.md) — General Windows administration commands and registry
- [Windows Advanced](windows-advanced.md) — NRPT, GPO hardening, DNS-over-HTTPS
- [Hypervisors](security/hypervisors.md) — Qubes OS, Proxmox, Xen vs KVM comparison

## Related Deep Hole

- [Microsoft WSL Documentation](https://docs.microsoft.com/en-us/windows/wsl/) — Official WSL documentation
- [Kali Linux WSL Documentation](https://www.kali.org/docs/wsl/) — Kali-specific WSL setup
- [Qubes OS Documentation](https://www.qubes-os.org/doc/) — Qubes OS security architecture
- [WSL2 GPU Support](https://docs.microsoft.com/en-us/windows/wsl/tutorials/gpu-compute) — CUDA on WSL2
- [NIST SP 800-125: Guide to Security for Full Virtualization Technologies](https://nvlpubs.nist.gov/nistpubs/Legacy/SP/nistspecialpublication800-125.pdf) — Virtualization security guidance
"""

let render() = file
