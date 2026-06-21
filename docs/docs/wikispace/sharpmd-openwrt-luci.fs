module ConvertedFiles.Docs.Wikispace.OpenwrtLuciMd

let file = """# OpenWRT LuCI Documentation

LuCI (Lua Configuration Interface) is the web-based administration interface for OpenWRT. It provides a comprehensive GUI for router configuration while maintaining the ability to drop down to UCI (Unified Configuration Interface) commands or raw configuration files when needed. This page documents LuCI's architecture, key modules, and advanced configuration workflows.

---

## Overview

???+ note "What this page covers"
    Complete OpenWRT LuCI documentation: MVC architecture, all modules (Status/System/Network), CBI framework for form generation, custom page creation, themes, and JSON-RPC API. For router firmware comparison, see [Router Firmware](openwrt-freshtomato.md). For GL.iNet specific configuration, see [GL.iNet / LuCI](glinet-luci.md).

---

## Architecture

LuCI uses a Model-View-Controller architecture built on Lua and the Nginx/uHTTPd web server:

```mermaid
flowchart TD
    B["Browser"] -->|"HTTP/HTTPS"| W["uHTTPd / Nginx"]
    W -->|"Lua dispatch"| D["LuCI Dispatcher"]
    D --> A["Authentication<br/>luci.sysauth"]
    D --> C["CSRF Protection"]
    D --> M["Menu Tree"]
    D --> CTL["Controller<br/>lua/luci/controller/"]
    CTL --> CBI["CBI Model<br/>lua/luci/model/cbi/"]
    CBI --> U["UCI Config<br/>/etc/config/"]
    CBI --> V["View<br/>lua/luci/view/"]
    V --> H["HTML Templates"]
    V --> J["JavaScript<br/>/luci-static/resources/"]
    V --> S["CSS<br/>/luci-static/bootstrap/"]
    
    style B fill:#333,color:#fff
    style U fill:#4a7c59,color:#fff
    style D fill:#5a3a2d,color:#fff
```

---

## LuCI Modules

### Status

| Page | Path | Information Displayed |
|------|------|----------------------|
| Overview | `/cgi-bin/luci/admin/status/overview` | System uptime, memory, active connections |
| Realtime Graphs | `/cgi-bin/luci/admin/status/realtime` | Traffic graphs (CPU, memory, network) |
| Processes | `/cgi-bin/luci/admin/status/processes` | Running processes with CPU/memory usage |
| Syslog | `/cgi-bin/luci/admin/status/syslog` | Kernel and system log messages |
| Kernel Log | `/cgi-bin/luci/admin/status/dmesg` | Boot messages |

### System

| Page | Path | Configuration |
|------|------|---------------|
| System Properties | `/cgi-bin/luci/admin/system/system` | Hostname, timezone, logging |
| Administration | `/cgi-bin/luci/admin/system/admin` | Root password, SSH access |
| Software | `/cgi-bin/luci/admin/system/opkg` | Package management (opkg) |
| Startup | `/cgi-bin/luci/admin/system/startup` | Init scripts, local startup |
| Scheduled Tasks | `/cgi-bin/luci/admin/system/crontab` | cron job management |
| Mount Points | `/cgi-bin/luci/admin/system/fstab` | Filesystem mount configuration |
| LED Configuration | `/cgi-bin/luci/admin/system/leds` | GPIO LED triggers |
| Backup / Flash | `/cgi-bin/luci/admin/system/flash` | Firmware upgrade, config backup |

### Network

| Page | Path | Configuration |
|------|------|---------------|
| Interfaces | `/cgi-bin/luci/admin/network/network` | WAN, LAN, VLAN interfaces |
| Wireless | `/cgi-bin/luci/admin/network/wireless` | Wi-Fi SSIDs, encryption, channels |
| DHCP and DNS | `/cgi-bin/luci/admin/network/dhcp` | dnsmasq configuration |
| Hostnames | `/cgi-bin/luci/admin/network/hosts` | Static host entries |
| Firewall | `/cgi-bin/luci/admin/network/firewall` | fw4 zones, rules, forwards |
| Diagnostics | `/cgi-bin/luci/admin/network/diagnostics` | Ping, traceroute, nslookup |
| Routing | `/cgi-bin/luci/admin/network/routes` | Static routes |

---

## CBI (Configuration Binding Interface)

CBI is LuCI's framework for automatically generating configuration forms from UCI schemas:

```lua
-- Example CBI model for a simple configuration page
local m = Map("system", "System Configuration")
local s = m:section(TypedSection, "system", "General Settings")
s.anonymous = true

-- Hostname field
local hostname = s:option(Value, "hostname", "Hostname")
hostname.datatype = "hostname"
hostname.default = "OpenWrt"

-- Timezone field
local timezone = s:option(ListValue, "timezone", "Timezone")
timezone:value("UTC", "UTC")
timezone:value("EST5EDT", "Eastern Time")
timezone:value("CST6CDT", "Central Time")
timezone:value("MST7MDT", "Mountain Time")
timezone:value("PST8PDT", "Pacific Time")

-- Boolean field
local logging = s:option(Flag, "logging", "Enable Logging")
logging.default = logging.enabled

return m
```

### CBI Field Types

| Type | HTML Output | Use Case |
|------|-------------|----------|
| `Value` | Text input | Strings, numbers |
| `ListValue` | Dropdown | Selection from options |
| `Flag` | Checkbox | Boolean values |
| `DynamicList` | Multiple text inputs | Lists of values |
| `MultiValue` | Multiple checkboxes | Multiple selections |
| `DummyValue` | Read-only text | Display-only fields |
| `FileUpload` | File input | File uploads |
| `TextValue` | Textarea | Multi-line text |

---

## Advanced Configuration Workflows

### VLAN Configuration via LuCI

```
Network > Interfaces > Devices tab
  |
  +-- Add device configuration
  |     Type: 802.1q VLAN
  |     Base device: eth0
  |     VLAN ID: 10
  |
  +-- Add device configuration
  |     Type: Bridge device
  |     Bridge ports: eth0.10
  |
  +-- Add new interface
        Protocol: Static address
        Device: br-vlan10
        IP: 192.168.10.1/24
```

### Wi-Fi Configuration via LuCI

```
Network > Wireless
  |
  +-- Edit radio0 (2.4 GHz)
  |     Channel: auto / specific
  |     Width: 20 MHz / 40 MHz
  |     Power: transmission power dBm
  |
  +-- Add new network
        ESSID: network-name
        Mode: Access Point
        Network: lan / guest / iot
        Encryption: WPA2-PSK / WPA3-SAE
        Key: passphrase
```

### Firewall Configuration via LuCI

```
Network > Firewall
  |
  +-- General Settings
  |     Input: Accept / Reject / Drop
  |     Output: Accept / Reject / Drop
  |     Forward: Accept / Reject / Drop
  |
  +-- Zones
  |     lan -> wan: Allow
  |     guest -> wan: Allow
  |     iot -> wan: Allow
  |     iot -> lan: Reject
  |
  +-- Traffic Rules
  |     Name: Allow-SSH-WAN
  |     Source: wan
  |     Destination port: 22
  |     Action: Accept
  |
  +-- Port Forwards
        Name: HTTP-Server
        External port: 80
        Internal IP: 192.168.1.100
        Internal port: 80
```

---

## Custom LuCI Pages

Creating a custom LuCI page involves three files:

### 1. Controller (`/usr/lib/lua/luci/controller/myapp.lua`)

```lua
module("luci.controller.myapp", package.seeall)

function index()
    entry({"admin", "services", "myapp"}, 
          cbi("myapp/config"), 
          "My Application", 
          60).dependent = false
end
```

### 2. Model (`/usr/lib/lua/luci/model/cbi/myapp/config.lua`)

```lua
local m = Map("myapp", "My Application Configuration")
local s = m:section(TypedSection, "settings", "Settings")
s.anonymous = true

local enabled = s:option(Flag, "enabled", "Enable")
local port = s:option(Value, "port", "Port")
port.datatype = "port"
port.default = "8080"

return m
```

### 3. UCI Configuration (`/etc/config/myapp`)

```
config settings 'main'
    option enabled '1'
    option port '8080'
```

---

## LuCI Themes

| Theme | Package | Description |
|-------|---------|-------------|
| Bootstrap | `luci-theme-bootstrap` | Default theme, responsive |
| Material | `luci-theme-material` | Google Material Design |
| OpenWrt | `luci-theme-openwrt` | Classic OpenWrt look |
| OpenWrt-2020 | `luci-theme-openwrt-2020` | Modern OpenWrt theme |

```bash
# Install theme
opkg update
opkg install luci-theme-material

# Set theme
uci set luci.main.mediaurlbase='/luci-static/material'
uci commit luci
```

---

## LuCI API (RPC)

LuCI provides a JSON-RPC API for programmatic access:

```bash
# Authenticate
curl -d '{"id":1,"method":"call","params":["","session","login",["root","password"]]}' \
     http://192.168.1.1/cgi-bin/luci/rpc/auth

# Response: {"id":1,"result":"auth_token","error":null}

# Call UCI methods
curl -d '{"id":1,"method":"call","params":["auth_token","uci","get",["network","lan","ipaddr"]]}' \
     http://192.168.1.1/cgi-bin/luci/rpc/uci

# Response: {"id":1,"result":"192.168.1.1","error":null}
```

### RPC Modules

| Module | Methods | Purpose |
|--------|---------|---------|
| `uci` | `get`, `set`, `commit`, `revert` | Configuration management |
| `sys` | `exec`, `netdev`, `netconntrack` | System information |
| `fs` | `read`, `write`, `list`, `stat` | Filesystem operations |
| `iwinfo` | `info`, `scan`, `assoclist` | Wireless information |

---

## Related Deep Hole

- [OpenWRT LuCI Documentation](https://openwrt.org/docs/guide-user/luci/start) — Official LuCI guide
- [LuCI API Documentation](https://openwrt.org/docs/techref/luci) — Technical reference
- [OpenWRT Forum](https://forum.openwrt.org/) — Community support
- [OpenWrt Wiki: Writing LuCI Modules](https://openwrt.org/docs/guide-developer/luci-howto) — Developer guide
- [UCI Documentation](https://openwrt.org/docs/guide-user/base-system/uci) — Configuration system
"""

let render() = file
