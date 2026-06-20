module ConvertedFiles.Docs.Wikispace.IosMd

let file = """# iOS

iOS configuration, hidden settings, Shortcuts automation, and advanced features for security and productivity. All procedures tested on iOS 17 and iOS 18.

---

## Overview

???+ note "What this page covers"
    This page documents iOS configuration and automation for advanced users:

    - **Configuration Profiles** — `.mobileconfig` files for DNS, VPN, and system settings
    - **Shortcuts Automation** — URL encoding, Base64, WiFi QR generation
    - **Field Test Mode** — Dialer codes for signal strength and carrier diagnostics
    - **Privacy Settings** — Comprehensive security and privacy checklist
    - **Native Apps** — Files, Markup, Books advanced features

    For general application deployment on Windows, see [Apps](apps.md). For DNS-over-HTTPS server configuration, see [DNS and Firewall](dns.md).

---

## Configuration Profiles

iOS supports `.mobileconfig` files for both enterprise MDM and personal configuration. Custom profiles can configure DNS, VPN, certificates, Wi-Fi, and restrictions without third-party apps.

### DNS-over-HTTPS Profile

```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN"
  "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
  <key>PayloadContent</key>
  <array>
    <dict>
      <key>DNSSettings</key>
      <dict>
        <key>DNSProtocol</key>
        <string>HTTPS</string>
        <key>ServerAddresses</key>
        <array>
          <string>1.1.1.1</string>
          <string>1.0.0.1</string>
        </array>
        <key>ServerURL</key>
        <string>https://cloudflare-dns.com/dns-query</string>
      </dict>
      <key>PayloadType</key>
      <string>com.apple.dnsSettings.managed</string>
      <key>PayloadUUID</key>
      <string>12345678-1234-1234-1234-123456789abc</string>
      <key>PayloadIdentifier</key>
      <string>com.example.dns</string>
      <key>PayloadDisplayName</key>
      <string>Cloudflare DoH</string>
      <key>PayloadVersion</key>
      <integer>1</integer>
    </dict>
  </array>
  <key>PayloadType</key>
  <string>Configuration</string>
  <key>PayloadUUID</key>
  <string>87654321-4321-4321-4321-cba987654321</string>
  <key>PayloadIdentifier</key>
  <string>com.example.config</string>
  <key>PayloadDisplayName</key>
  <string>DNS Configuration</string>
  <key>PayloadVersion</key>
  <integer>1</integer>
</dict>
</plist>
```

---

## Shortcuts Automation

```mermaid
flowchart TD
    subgraph Encode["Encoding Shortcuts"]
        direction TB
        E1["Receive Text"] --> E2["URL Encode"]
        E2 --> E3["Copy to Clipboard"]
        E4["Receive Text"] --> E5["Base64 Encode"]
        E5 --> E6["Copy to Clipboard"]
    end

    subgraph WiFi["WiFi QR Generator"]
        direction TB
        W1["Ask: Network Name"] --> W2["Ask: Password"]
        W2 --> W3["Ask: Security Type"]
        W3 --> W4["Generate QR<br/>WIFI:T:WPA;S:n;P:p;;"]
        W4 --> W5["Show / Save"]
    end

    style Encode fill:#4a90d9
    style WiFi fill:#7ed321
```

### URL Encoding

```
1. Receive Text Input
2. URL Encode Text
3. Copy to Clipboard
```

### Base64 Encode/Decode

```
1. Receive Text Input
2. Base64 Encode (or Decode)
3. Copy to Clipboard
```

### WiFi QR Code Generator

```
1. Ask for: Network Name (Text)
2. Ask for: Password (Text, masked)
3. Ask for: Security Type (WPA/WEP/None)
4. Generate QR Code with format: WIFI:T:WPA;S:{Network};P:{Password};;
5. Show QR Code / Save to Photos
```

---

## Hidden Settings and Field Test Mode

### Dialer Codes

| Code | Purpose |
|------|---------|
| `*3001#12345#*` | Field Test Mode (signal strength in dBm) |
| `*#06#` | IMEI display |
| `*#67#` | Call forwarding when busy |
| `*#21#` | Call forwarding status (all conditions) |
| `*#62#` | Call forwarding when unreachable |
| `*#31#` | Toggle caller ID presentation |
| `*3282#` | SMS usage information (carrier dependent) |
| `*646#` | Postpaid account balance (carrier dependent) |

!!! warning "Carrier Dependent"
    Some codes are carrier-specific and may not function on all networks. Field Test Mode displays signal strength in dBm (decibel-milliwatts) instead of signal bars, providing a precise measurement for comparing reception quality across locations.

---

## Safari Developer Tools

Enable web debugging for development:

```
Settings > Safari > Advanced > Web Inspector = ON
Settings > Safari > Advanced > JavaScript = ON
```

Connect iPhone to Mac via USB, then use Safari Develop menu to inspect web pages, debug JavaScript, and analyze network requests.

---

## Privacy Settings Checklist

```mermaid
flowchart TD
    subgraph Privacy["iOS Privacy Configuration"]
        direction TB
        T["Tracking<br/>Allow Apps to Request = OFF"]
        L["Location Services<br/>Disable non-essential"]
        A["Analytics<br/>Share iPhone Analytics = OFF"]
        AD["Personalized Ads = OFF"]
        S["Safari:<br/>Prevent Cross-Site Tracking = ON<br/>Hide IP Address = From Trackers"]
        LM["Lockdown Mode<br/>(high-risk targets)"]
    end

    style Privacy fill:#4a90d9
```

| Setting | Path | Recommended Value |
|---------|------|-------------------|
| Tracking | Privacy & Security > Tracking | Allow Apps to Request to Track = OFF |
| Location Services | Privacy & Security > Location Services | Disable for non-essential apps |
| Analytics | Privacy & Security > Analytics & Improvements > Share iPhone Analytics | OFF |
| Personalized Ads | Privacy & Security > Apple Advertising > Personalized Ads | OFF |
| Cross-Site Tracking | Safari > Prevent Cross-Site Tracking | ON |
| Hide IP Address | Safari > Hide IP Address | From Trackers and Websites |
| Lockdown Mode | Privacy & Security > Lockdown Mode | Enable if high-risk target |

---

## Native Apps Guide

### Files App

The Files app (com.apple.Files) provides access to local storage, iCloud Drive, and third-party cloud providers. It supports:

- ZIP extraction and compression
- Document scanning (continuity camera)
- SMB server connections (Settings > Files > Connect to Server)
- Tag-based organization
- External storage (USB-C/Thunderbolt drives on iPad Pro)

### Preview (Markup)

The Markup tool is available system-wide via the share sheet:

- Sign documents with saved signatures
- Annotate screenshots and PDFs
- Magnifier loupe for detailed areas
- Shape recognition (draw and hold to perfect)

### Books

Apple Books supports EPUB, PDF, and audiobooks. Features include:

- EPUB annotation and highlighting
- PDF form filling
- Reading goals tracking
- Collections for organization

---

## Related Pages

- [Apps](apps.md) — Windows application deployment and management
- [DNS and Firewall](dns.md) — DNS resolver configuration and network security

## Related Deep Hole

- [Apple Support: Configuration Profile Reference](https://developer.apple.com/business/documentation/Configuration-Profile-Reference.pdf) — Official profile specification
- [Apple Support: Use Shortcuts on iPhone](https://support.apple.com/guide/shortcuts/welcome/ios) — Shortcuts documentation
- [iOS Field Test Mode Guide](https://www.speedtest.net/ios-field-test-mode) — Signal measurement techniques
"""

let render() = file
