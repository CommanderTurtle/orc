module ConvertedFiles.Docs.Wikispace.Security.PermissionsMd

let file = """# Strength through Permissions

Access control is the enforcement of authorization decisions on system resources. The principle of least privilege dictates that every user, process, and system component should have only the permissions necessary to perform its function, and no more. Windows implements permissions through a discretionary access control (DAC) model using ACLs (Access Control Lists).

---

## Overview

???+ note "What this page covers"
    This page documents permission management across Windows and Linux systems:

    - **Windows ACL Model** — Permission levels, inheritance, and icacls operations
    - **NTFS vs Share Permissions** — Effective permission calculation
    - **UAC Configuration** — User Account Control behavior settings
    - **Linux File Permissions** — Numeric and symbolic chmod/chown

    For attack surface reduction, see [Minimalism](minimalism.md). For encryption of sensitive data, see [Encryption](encryption.md). For Windows registry essentials, see [Windows Wiki](../windows.md).

---

## Windows ACL Model

### Permission Levels

```mermaid
flowchart TD
    F["Full Control (F)<br/>Change ownership + all rights"] --> M["Modify (M)<br/>Read + write + execute + delete"]
    M --> RX["Read & Execute (RX)<br/>Read + list + traverse + execute"]
    RX --> R["Read (R)<br/>Read data + attributes + permissions"]
    R --> W["Write (W)<br/>Write data + append + attributes"]

    style F fill:#d0021b
    style M fill:#f5a623
    style RX fill:#7ed321
    style R fill:#4a90d9
    style W fill:#9013fe
```

| Permission | Abbreviation | Effective Rights |
|------------|-------------|--------------------|
| Full Control | F | All permissions including change ownership |
| Modify | M | Read, write, execute, delete |
| Read and Execute | RX | Read, list folder contents, traverse, execute |
| Read | R | Read data, read attributes, read permissions |
| Write | W | Write data, append data, write attributes |

### icacls Reference

```batch
REM View ACLs on a file or directory
icacls "C:\path\to\file"

REM Grant full control to a user
icacls "C:\path" /grant username:F

REM Grant modify (safer than full)
icacls "C:\path" /grant username:M

REM Grant read-only
icacls "C:\path" /grant "Users":R

REM Remove all permissions for a user
icacls "C:\path" /remove username

REM Save ACLs to file for backup
icacls "C:\path" /save acl_backup.txt /t /c

REM Restore ACLs from backup
icacls "C:\" /restore acl_backup.txt

REM Enable inheritance from parent
icacls "C:\path" /inheritance:e

REM Remove inheritance (copy existing to explicit)
icacls "C:\path" /inheritance:d

REM Remove inheritance (remove inherited)
icacls "C:\path" /inheritance:r
```

---

## NTFS Permissions vs Share Permissions

When accessing files over a network, both NTFS and share permissions apply. The effective permission is the **most restrictive** of the two.

| Scenario | NTFS | Share | Effective |
|----------|------|-------|-----------|
| Full via NTFS, Read via Share | Full Control | Read | Read |
| Read via NTFS, Full via Share | Read | Full Control | Read |
| Deny via NTFS, Full via Share | Deny | Full Control | Deny |

!!! note "Deny Overrides All"
    An explicit Deny entry in either NTFS or share permissions overrides all grant entries. Use Deny sparingly; it is generally better to simply not grant a permission than to explicitly deny it.

---

## User Account Control (UAC)

UAC is a mandatory access control mechanism that prevents unauthorized changes to the operating system. Key registry settings:

```batch
REM UAC configuration path:
REM HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System

REM Consent prompt behavior for administrators
REM 0 = Elevate without prompting
REM 1 = Prompt for credentials on secure desktop
REM 2 = Prompt for consent on secure desktop
REM 3 = Prompt for credentials
REM 4 = Prompt for consent
REM 5 = Prompt for consent for non-Windows binaries
reg add "HKLM\...\System" /v ConsentPromptBehaviorAdmin /t REG_DWORD /d 2 /f
```

---

## Linux File Permissions

```bash
# Numeric permission representation
# 4 = read (r), 2 = write (w), 1 = execute (x)
# Order: owner, group, others

chmod 644 file.txt    # rw-r--r-- (owner read/write, group/others read)
chmod 755 script.sh   # rwxr-xr-x (owner full, group/others read/execute)
chmod 700 private.key # rwx------ (owner only)
chmod 600 ~/.ssh/id_rsa  # SSH key recommended permissions

# Set ownership
chown user:group file
chown -R user:group directory
```

---

## Related Pages

- [Minimalism](minimalism.md) — Attack surface reduction
- [Encryption](encryption.md) — Data protection at rest and in transit
- [Windows Wiki](../windows.md) — System administration and registry reference

## Related Deep Hole

- [Microsoft Docs: icacls](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/icacls) — Official icacls documentation
- [SS64: icacls reference](https://ss64.com/nt/icacls.html) — Community-maintained icacls guide
- [CIS Windows Permission Guidelines](https://www.cisecurity.org/cis-benchmarks) — Baseline permission recommendations
"""

let render() = file
