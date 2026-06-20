module ConvertedFiles.Docs.Wikispace.Security.HypervisorsMd

let file = """# Hypervisors: The Ultimate Container

Hypervisors provide hardware-level isolation that exceeds the security boundaries of OS-level containerization. While Docker and Podman share a host kernel among containers, hypervisors partition CPU, memory, and I/O at the hardware abstraction layer, preventing kernel exploitation from crossing virtual machine boundaries. This page covers the two dominant open-source hypervisor architectures: Xen (type 1, bare-metal) and KVM (type 1.5, kernel-integrated), with specific focus on Qubes OS and Proxmox VE deployments.

---

## Overview

???+ note "What this page covers"
    This page documents hypervisor architecture (Xen vs KVM), Qubes OS security model, Proxmox VE, VFIO PCI passthrough, and the Qubes vs Proxmox debate. For container-level isolation, see [Containerization](containerization.md). For hosting security, see [Hosting](hosting.md).

---

## Hypervisor Types

| Type | Name | Architecture | Examples |
|------|------|-------------|----------|
| Type 1 | Bare-metal | Runs directly on hardware | Xen, VMware ESXi, Hyper-V |
| Type 2 | Hosted | Runs as application on host OS | VirtualBox, VMware Workstation, Parallels |
| Type 1.5 | Kernel-integrated | Kernel module with near-native performance | KVM (Linux), Hyper-V (Windows) |

---

## Xen vs KVM

| Aspect | Xen | KVM |
|--------|-----|-----|
| Architecture | Microkernel hypervisor | Linux kernel module |
| Paravirtualization | Native support | Not supported |
| Hardware virtualization | HVM (Hardware Virtual Machine) | Required |
| Memory management | Separate Xen heap | Standard Linux memory management |
| I/O model | XenStore, event channels | virtio devices |
| Live migration | Supported | Supported |
| Nested virtualization | Limited | Better support |
| Learning curve | Steeper | Gentler |
| Community | Academic, security-focused | Enterprise, general-purpose |

### Xen Architecture

Xen runs a minimal hypervisor (the "Xen VMM") directly on hardware. Domain 0 (Dom0) is a privileged VM that manages hardware and runs device drivers. All other VMs (DomU) are unprivileged and communicate with hardware through Dom0.

```mermaid
graph TD
    HW["Hardware"]
    VMM["Xen VMM<br/>Hypervisor"]
    D0["Dom0<br/>Privileged"]
    D0D["Device Drivers"]
    D0T["Toolstack"]
    SN["sys-net<br/>Untrusted"]
    SF["sys-firewall"]
    SW["work"]
    SP["personal"]
    SV["vault<br/>Air-gapped"]
    
    HW --> VMM
    VMM --> D0
    D0 --> D0D
    D0 --> D0T
    VMM --> SN
    VMM --> SF
    VMM --> SW
    VMM --> SP
    VMM --> SV
    
    SN -.->|"network traffic"| SF
    SF -.->|"filtered"| SW
    SF -.->|"filtered"| SP
    
    style HW fill:#333,color:#fff
    style VMM fill:#5a3a2d,color:#fff
    style D0 fill:#2d5a3a,color:#fff
    style SN fill:#8B0000,color:#fff
    style SV fill:#4a7c59,color:#fff
```

### KVM Architecture

KVM is a kernel module that converts Linux into a hypervisor. Each VM runs as a standard Linux process, scheduled by the kernel's process scheduler. QEMU provides I/O device emulation.

```plain
Hardware
  |
  +-- Linux Kernel
       |
       +-- KVM module
       |     +-- VM1 (qemu-kvm process)
       |     +-- VM2 (qemu-kvm process)
       |     +-- VM3 (qemu-kvm process)
       |
       +-- Standard Linux services
```

---

## Qubes OS

Qubes OS is a security-focused desktop operating system built on Xen. It uses security by compartmentalization: activities are isolated into separate VMs called "qubes." The default installation includes:

| VM | Role | Network Access |
|----|------|----------------|
| dom0 | Xen management, window manager | None (air-gapped) |
| sys-net | Network adapter driver | Direct (untrusted) |
| sys-firewall | Firewall between VMs and sys-net | Via sys-net |
| sys-usb | USB controller driver | None (isolated) |
| sys-whonix | Tor gateway | Via sys-firewall |
| work | Work activities | Via sys-firewall |
| personal | Personal browsing | Via sys-firewall |
| vault | Password storage | None (air-gapped) |

### Security Model

1. **sys-net is untrusted**: It runs the NIC driver and is the most likely VM to be compromised. It has no access to other VMs except through sys-firewall.
2. **Xen enforces isolation**: A compromised VM cannot escape to dom0 or other VMs without a Xen vulnerability.
3. **Disposable VMs**: One-time VMs for untrusted activities (opening attachments, visiting unknown sites).
4. **Copy-paste and file transfer**: Explicitly authorized between VMs, not automatic.

### Hardware Requirements

| Requirement | Minimum | Recommended |
|-------------|---------|-------------|
| CPU | x86_64 with VT-x/AMD-V | Intel vPro / AMD-Vi (IOMMU) |
| RAM | 8 GB | 16+ GB |
| Storage | 128 GB SSD | 256+ GB NVMe |
| GPU | Integrated | Dedicated GPU for passthrough |

---

## Proxmox VE

Proxmox VE is an open-source server virtualization platform combining KVM for VMs and LXC for containers. It provides a web-based management interface and supports clustering, live migration, ZFS storage, and Ceph distributed storage.

### Architecture

```
Hardware
  |
  +-- Debian Linux
       |
       +-- KVM (full VMs)
       |     +-- VM 100 (Windows)
       |     +-- VM 101 (Linux)
       |
       +-- LXC (containers)
       |     +-- CT 200 (Nginx)
       |     +-- CT 201 (MySQL)
       |
       +-- Proxmox web interface (port 8006)
```

### Key Features

| Feature | Implementation |
|---------|---------------|
| Storage | ZFS, Ceph, LVM, NFS, iSCSI |
| Networking | Linux bridge, VLAN, OVS |
| Backup | vzdump (snapshot-based) |
| High Availability | Corosync + Pacemaker |
| Firewall | iptables/nftables per VM |

---

## VFIO PCI Passthrough

VFIO (Virtual Function I/O) allows direct assignment of physical PCI devices to virtual machines. The device is isolated from the host kernel and given exclusively to the guest.

### Requirements

| Requirement | Check |
|-------------|-------|
| CPU: VT-d (Intel) or AMD-Vi (IOMMU) | `dmesg \| grep -e DMAR -e IOMMU` |
| BIOS: IOMMU enabled | BIOS settings |
| Kernel: IOMMU enabled | `intel_iommu=on` or `amd_iommu=on` in kernel cmdline |
| GPU in isolated IOMMU group | `find /sys/kernel/iommu_groups/ -type l` |

### GPU Passthrough Steps

```bash
# 1. Enable IOMMU (GRUB)
# Edit /etc/default/grub:
GRUB_CMDLINE_LINUX_DEFAULT="intel_iommu=on iommu=pt"

# 2. Update GRUB and reboot
update-grub
reboot

# 3. Identify GPU
lspci -nnk | grep -i nvidia
# Example: 01:00.0 VGA controller [0300]: NVIDIA ... [10de:1f08]
#          01:00.1 Audio device [0403]: NVIDIA ... [10de:10f9]

# 4. Bind GPU to vfio-pci
# /etc/modprobe.d/vfio.conf
options vfio-pci ids=10de:1f08,10de:10f9 disable_vga=1

# 5. Load vfio modules
# /etc/modules
vfio
vfio_iommu_type1
vfio_pci
vfio_virqfd
```

### Use Cases for Passthrough

| Device | Purpose | Notes |
|--------|---------|-------|
| GPU | Gaming VM, ML workloads | Requires UEFI BIOS, ROM BAR |
| NIC | Dedicated network VM | SR-IOV preferred for sharing |
| USB controller | Direct USB device access | Per-port controllers ideal |
| SATA controller | Direct disk access | Hot-swap support |

---

## Qubes vs Proxmox Comparison

| Aspect | Qubes OS | Proxmox VE |
|--------|----------|------------|
| Primary use | Secure desktop | Server virtualization |
| Hypervisor | Xen | KVM + LXC |
| Management | dom0 CLI + Qubes Manager | Web GUI (port 8006) |
| Default OS | Fedora/Xfce | Debian |
| Network model | Proxy VMs (sys-net, sys-firewall) | Linux bridges |
| Storage | LVM thin, BTRFS | ZFS, Ceph, LVM |
| Desktop integration | Seamless window integration | No desktop (server-only) |
| USB handling | sys-usb qube, qvm-usb | Direct passthrough |
| Learning curve | High | Moderate |
| Security focus | Maximum isolation | Flexible, configurable |

---

## Related Deep Hole

- [Qubes OS Documentation](https://www.qubes-os.org/doc/) — Official documentation
- [Proxmox VE Documentation](https://pve.proxmox.com/wiki/Main_Page) — Official wiki
- [Xen Project Documentation](https://xenbits.xenproject.org/docs/) — Xen hypervisor docs
- [KVM Documentation](https://www.linux-kvm.org/page/Documents) — Kernel Virtual Machine docs
- [VFIO Reddit Community](https://www.reddit.com/r/VFIO/) — GPU passthrough guides
- [VFIO Guide: Linux Gaming](https://www.reddit.com/r/linux_gaming/comments/eadhl7/people_who_still_arent_using_linux_in_2019_and/) — Comprehensive VFIO setup
"""

let render() = file
