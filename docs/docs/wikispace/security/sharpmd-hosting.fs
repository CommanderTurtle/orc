module ConvertedFiles.Docs.Wikispace.Security.HostingMd

let file = """# Hosting a Website

Hosting a website involves making content available over HTTP/HTTPS to clients on the internet or a private network. This page covers web server hardening, TLS configuration, and deployment security. For containerized deployments, refer to the [Containerization](containerization.md) page.

---

## Overview

???+ note "What this page covers"
    This page documents secure web server deployment:

    - **Server Selection** — Nginx, Apache, Caddy, and Lighttpd comparison
    - **Nginx Hardening** — Security headers, TLS, OCSP stapling, rate limiting
    - **Certificate Management** — Let's Encrypt with HTTP and DNS validation
    - **DDoS Mitigation** — Layered defense from network to application

    For TLS cipher suite details, see [Encryption](encryption.md). For container orchestration, see [Containerization](containerization.md). For general network security, see [DNS and Firewall](../dns.md).

---

## Web Server Selection

```mermaid
flowchart TD
    subgraph Servers["Web Server Comparison"]
        direction TB
        N["Nginx<br/>Low memory, high perf<br/>Declarative config"]
        A["Apache<br/>Moderate memory/perf<br/>.htaccess, rewrite rules"]
        C["Caddy<br/>Low memory, high perf<br/>Automatic HTTPS"]
        L["Lighttpd<br/>Very low memory<br/>Simple config"]
    end

    subgraph UseCase["Use Case Mapping"]
        U1["Reverse proxy<br/>Static sites<br/>High concurrency"] --> N
        U2["Complex rewrites<br/>Shared hosting"] --> A
        U3["Simple deploy<br/>Auto TLS"] --> C
        U4["Embedded<br/>Low resource"] --> L
    end

    style Servers fill:#4a90d9
```

| Server | Memory | Performance | Configuration | Use Case |
|--------|--------|-------------|---------------|----------|
| Nginx | Low | High | Declarative | Reverse proxy, static sites, high concurrency |
| Apache | Moderate | Moderate | Directive-based | Complex rewrite rules, .htaccess, shared hosting |
| Caddy | Low | High | Automatic HTTPS | Simple deployments, automatic TLS |
| Lighttpd | Very low | Moderate | Simple | Embedded systems, low-resource environments |

---

## Nginx Hardening

### Security Headers

```nginx
server {
    listen 443 ssl http2;
    server_name example.com;

    # TLS
    ssl_certificate /etc/letsencrypt/live/example.com/fullchain.pem;
    ssl_certificate_key /etc/letsencrypt/live/example.com/privkey.pem;
    ssl_protocols TLSv1.2 TLSv1.3;
    ssl_ciphers 'ECDHE-ECDSA-AES128-GCM-SHA256:ECDHE-RSA-AES128-GCM-SHA256';
    ssl_prefer_server_ciphers off;
    ssl_session_cache shared:SSL:10m;
    ssl_session_timeout 1d;

    # Security headers
    add_header Strict-Transport-Security "max-age=63072000; includeSubDomains; preload" always;
    add_header X-Frame-Options "DENY" always;
    add_header X-Content-Type-Options "nosniff" always;
    add_header X-XSS-Protection "1; mode=block" always;
    add_header Referrer-Policy "strict-origin-when-cross-origin" always;
    add_header Content-Security-Policy "default-src 'self'; script-src 'self'; style-src 'self' 'unsafe-inline'" always;
    add_header Permissions-Policy "camera=(), microphone=(), geolocation=()" always;

    # OCSP stapling
    ssl_stapling on;
    ssl_stapling_verify on;
    ssl_trusted_certificate /etc/letsencrypt/live/example.com/chain.pem;
    resolver 1.1.1.1 1.0.0.1 valid=300s;
    resolver_timeout 5s;
}
```

### Rate Limiting

```nginx
limit_req_zone $binary_remote_addr zone=general:10m rate=10r/s;
limit_conn_zone $binary_remote_addr zone=addr:10m;

server {
    location / {
        limit_req zone=general burst=20 nodelay;
        limit_conn addr 10;
    }
}
```

---

## TLS Certificate Management

### Let's Encrypt (Certbot)

```bash
# Obtain certificate
certbot certonly --standalone -d example.com -d www.example.com

# Auto-renewal (cron)
0 3 * * * certbot renew --quiet --deploy-hook "nginx -s reload"
```

### DNS Validation (for internal networks)

```bash
# Using Cloudflare DNS plugin
certbot certonly --dns-cloudflare --dns-cloudflare-credentials /etc/letsencrypt/cloudflare.ini -d internal.example.com
```

---

## DDoS Mitigation

```mermaid
flowchart LR
    subgraph Layers["Defense Layers"]
        direction LR
        NET["Network<br/>Rate limiting<br/>iptables/ip6tables"]
        TRA["Transport<br/>SYN cookies"]
        APP["Application<br/>CAPTCHA / PoW"]
        CDN["CDN<br/>Cloudflare<br/>AWS CloudFront"]
    end

    ATT["DDoS Attack"] --> NET
    NET --> TRA
    TRA --> APP
    APP --> CDN
    CDN --> ORIGIN["Origin Server<br/>(Protected)"]

    style CDN fill:#4a90d9
    style ORIGIN fill:#7ed321
```

| Layer | Technique | Implementation |
|-------|-----------|----------------|
| Network | Rate limiting | iptables/ip6tables, Nginx limit_req |
| Transport | SYN cookies | `/proc/sys/net/ipv4/tcp_syncookies` |
| Application | Challenge | CAPTCHA, proof-of-work |
| CDN | Absorption | Cloudflare, AWS CloudFront |

---

## Related Pages

- [Encryption](encryption.md) — AES, RSA, TLS cipher suites
- [Containerization](containerization.md) — Containerized deployment
- [DNS and Firewall](../dns.md) — Network-level protection
- [DNS and Firewall](../dns.md) — iptables rate limiting rules

## Related Deep Hole

- [Mozilla SSL Configuration Generator](https://ssl-config.mozilla.org/) — Server-specific TLS configurations
- [OWASP Secure Headers Project](https://owasp.org/www-project-secure-headers/) — HTTP security headers reference
- [Let's Encrypt Documentation](https://letsencrypt.org/docs/) — Free certificate authority
- [Caddy Documentation](https://caddyserver.com/docs/) — Automatic HTTPS web server
"""

let render() = file
