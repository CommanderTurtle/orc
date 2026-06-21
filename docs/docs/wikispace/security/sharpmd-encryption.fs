module ConvertedFiles.Docs.Wikispace.Security.EncryptionMd

let file = """# Strength through Encryption

Encryption transforms readable plaintext into unreadable ciphertext using mathematical algorithms and keys. It is the primary mechanism for ensuring data confidentiality both at rest (stored on disk) and in transit (moving across networks). This page covers symmetric encryption (AES), asymmetric encryption (RSA), and practical key management.

---

## Overview

???+ note "What this page covers"
    This page documents encryption implementation for data protection:

    - **Symmetric Encryption** — AES-256-GCM for confidentiality and authenticated integrity
    - **Asymmetric Encryption** — RSA key generation and hybrid encryption
    - **TLS/SSL** — Network encryption configuration for web servers
    - **BitLocker** — Windows full-disk encryption
    - **Key Management** — Separation, rotation, escrow, and destruction principles

    For permission-based access control, see [Permissions](permissions.md). For steganographic data hiding, see [Steganography](steganography.md). For Windows advanced security, see [Windows Advanced](../windows-advanced.md).

---

## Symmetric Encryption: AES

Advanced Encryption Standard (AES) is a symmetric block cipher using 128-bit blocks and key sizes of 128, 192, or 256 bits. AES-256-GCM (Galois/Counter Mode) is the recommended mode as it provides both confidentiality and authenticated integrity.

### AES Modes Comparison

```mermaid
flowchart TD
    subgraph Modes["AES Modes"]
        direction TB
        ECB["ECB<br/>Electronic Codebook"] -->|"Leaks patterns<br/>Do not use"| BAD["INSECURE"]
        CBC["CBC<br/>Cipher Block Chaining"] -->|"Legacy only<br/>No authentication"| LEG["Legacy"]
        CTR["CTR<br/>Counter"] -->|"Streaming<br/>No authentication"| STR["Streaming"]
        GCM["GCM<br/>Galois/Counter Mode"] -->|"Confidentiality<br/>+ Authentication<br/>+ Parallelizable"| REC["RECOMMENDED"]
        CCM["CCM<br/>Counter with CBC-MAC"] -->|"Constrained env<br/>Non-parallel"| CON["Constrained"]
    end

    style BAD fill:#d0021b
    style REC fill:#7ed321
    style LEG fill:#f5a623
    style STR fill:#4a90d9
    style CON fill:#9013fe
```

| Mode | Encryption | Authentication | Parallelizable | Use Case |
|------|-----------|----------------|----------------|----------|
| ECB | Yes | No | Yes | Do not use (leaks patterns) |
| CBC | Yes | No | No | Legacy compatibility |
| CTR | Yes | No | Yes | Streaming, random access |
| GCM | Yes | Yes | Yes | Recommended for all new designs |
| CCM | Yes | Yes | No | Constrained environments |

### PowerShell AES Encryption

```powershell
function Protect-AesGcm {
    param([string]$PlainText, [byte[]]$Key)
    $aes = [System.Security.Cryptography.AesGcm]::new($Key)
    $nonce = New-Object byte[] 12
    [Security.Cryptography.RandomNumberGenerator]::Fill($nonce)
    $plaintextBytes = [System.Text.Encoding]::UTF8.GetBytes($PlainText)
    $ciphertext = New-Object byte[] $plaintextBytes.Length
    $tag = New-Object byte[] 16
    $aes.Encrypt($nonce, $plaintextBytes, $ciphertext, $tag)
    return @{ Nonce = $nonce; Ciphertext = $ciphertext; Tag = $tag }
}

function Unprotect-AesGcm {
    param([byte[]]$Key, [byte[]]$Nonce, [byte[]]$Ciphertext, [byte[]]$Tag)
    $aes = [System.Security.Cryptography.AesGcm]::new($Key)
    $plaintext = New-Object byte[] $Ciphertext.Length
    $aes.Decrypt($Nonce, $Ciphertext, $Tag, $plaintext)
    return [System.Text.Encoding]::UTF8.GetString($plaintext)
}
```

---

## Asymmetric Encryption: RSA

RSA uses a public-private key pair. The public key encrypts; only the corresponding private key decrypts. RSA is computationally expensive and typically used to encrypt a symmetric key, which then encrypts the actual data (hybrid encryption).

### RSA Key Generation (PowerShell)

```powershell
$rsa = [System.Security.Cryptography.RSA]::Create(4096)
$privateKey = $rsa.ExportRSAPrivateKey()
$publicKey = $rsa.ExportRSAPublicKey()
[IO.File]::WriteAllBytes("private.key", $privateKey)
[IO.File]::WriteAllBytes("public.key", $publicKey)
```

---

## TLS/SSL for Network Encryption

Transport Layer Security (TLS) encrypts data in transit. TLS 1.3 is the current standard; TLS 1.2 is acceptable with proper cipher suites. TLS 1.0 and 1.1 are deprecated.

```mermaid
flowchart TD
    subgraph TLS_Handshake["TLS 1.3 Handshake"]
        direction LR
        C1["Client Hello<br/>+ Key Share"] --> S1["Server Hello<br/>+ Key Share<br/>+ {EncryptedExtensions}<br/>+ {Certificate}<br/>+ {Finished}"]
        S1 --> C2["Client<br/>{Finished}"]
        C2 --> APP["Application Data<br/>(1-RTT)"]
    end

    subgraph Cipher["Recommended Cipher Suites"]
        direction TB
        CS1["TLS_AES_256_GCM_SHA384"]
        CS2["TLS_CHACHA20_POLY1305_SHA256"]
        CS3["TLS_AES_128_GCM_SHA256"]
    end

    style TLS_Handshake fill:#4a90d9
    style Cipher fill:#7ed321
```

### Recommended TLS 1.2 Cipher Suites

```
TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384
TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384
TLS_ECDHE_ECDSA_WITH_CHACHA20_POLY1305_SHA256
TLS_ECDHE_RSA_WITH_CHACHA20_POLY1305_SHA256
TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256
TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256
```

### Nginx TLS Configuration

```nginx
server {
    listen 443 ssl http2;
    ssl_certificate /path/to/cert.pem;
    ssl_certificate_key /path/to/key.pem;
    ssl_protocols TLSv1.2 TLSv1.3;
    ssl_ciphers 'ECDHE-ECDSA-AES128-GCM-SHA256:ECDHE-RSA-AES128-GCM-SHA256';
    ssl_prefer_server_ciphers off;
    ssl_session_cache shared:SSL:10m;
    ssl_session_timeout 1d;
    add_header Strict-Transport-Security "max-age=63072000" always;
}
```

---

## BitLocker (Windows)

```powershell
# Check BitLocker status
Get-BitLockerVolume

# Enable BitLocker on C:
Enable-BitLocker -MountPoint C: -EncryptionMethod Aes256 -RecoveryPasswordProtector

# Backup recovery key
manage-bde -protectors -adbackup C:
```

---

## Key Management Principles

| Principle | Implementation |
|-----------|---------------|
| Separation | Store keys separate from encrypted data |
| Rotation | Regularly rotate encryption keys |
| Escrow | Maintain offline recovery capability |
| Minimization | Only decrypt in memory, never log keys |
| Destruction | Securely delete keys when no longer needed |

---

## Related Pages

- [Permissions](permissions.md) — Access control and least privilege
- [Steganography](steganography.md) — Concealed data transmission
- [Hosting](hosting.md) — Web server TLS configuration
- [Windows Advanced](../windows-advanced.md) — NRPT and DNS security

## Related Deep Hole

- [NIST SP 800-175B: Guiding the Development of Cryptographic Standards](https://csrc.nist.gov/publications/detail/sp/800-175b/final) — Federal cryptography guidance
- [OWASP Cryptographic Storage Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Cryptographic_Storage_Cheat_Sheet.html) — Practical implementation guidance
- [Mozilla SSL Configuration Generator](https://ssl-config.mozilla.org/) — Server-specific TLS configurations
"""

let render() = file
