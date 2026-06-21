module ConvertedFiles.Docs.Wikispace.Security.ContainerizationMd

let file = """# Containerization

Containerization isolates application processes from the host operating system kernel while sharing the same OS instance. Unlike virtual machines, which emulate complete hardware environments, containers share the host kernel and use namespace isolation and cgroup resource limiting to create bounded execution environments. Docker is the dominant container runtime; Podman provides a daemonless alternative compatible with Docker's CLI.

---

## Overview

???+ note "What this page covers"
    This page documents container deployment and security:

    - **Docker Architecture** — Client-server model, Dockerfile best practices, security options
    - **Podman** — Rootless, daemonless alternative to Docker
    - **Container Networking** — Bridge, host, none, container, macvlan modes
    - **Capability Security** — Linux capabilities and least-privilege configuration

    For hypervisor-based isolation (Qubes, Proxmox), see [Hypervisors](hypervisors.md). For web server hosting, see [Hosting](hosting.md). For minimalism and attack surface reduction, see [Minimalism](minimalism.md).

---

## Docker Architecture

```mermaid
flowchart TD
    subgraph Docker_Host["Docker Host"]
        direction TB
        CLI["docker CLI"]
        D["dockerd<br/>(Daemon)"]
        REG["Local Image<br/>Registry"]

        subgraph Container["Containers"]
            C1["Container A<br/>(App 1)"]
            C2["Container B<br/>(App 2)"]
        end

        subgraph Kernel["Host Kernel"]
            NS["Namespaces<br/>(PID, NET, MNT, UTS, IPC, USER)"]
            CG["cgroups<br/>(cpu, memory, pids)"]
            SEC["seccomp<br/>(syscall filter)"]
            CAP["Capabilities"]
        end
    end

    CLI --> D
    D --> REG
    D --> C1
    D --> C2
    C1 --> NS
    C1 --> CG
    C1 --> SEC
    C1 --> CAP
    C2 --> NS
    C2 --> CG
    C2 --> SEC
    C2 --> CAP

    style Docker_Host fill:#4a90d9
    style Kernel fill:#7ed321
```

Docker uses a client-server model. The `docker` CLI communicates with the Docker daemon (`dockerd`) via a Unix socket or TCP. Images are built from Dockerfiles and stored in registries. Containers are instantiated from images as isolated processes.

### Dockerfile Best Practices

```dockerfile
# Use specific version tags, not 'latest'
FROM python:3.12-slim-bookworm

# Run as non-root user
RUN groupadd -r appgroup && useradd -r -g appgroup appuser
USER appuser

# Set working directory
WORKDIR /app

# Copy requirements first for layer caching
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# Copy application code
COPY . .

# Use exec form for proper signal handling
CMD ["python", "app.py"]

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1
```

### Security Options

```bash
# Run with security constraints
docker run \
    --read-only \                          # Read-only root filesystem
    --tmpfs /tmp:rw,noexec,nosuid,size=100m \  # Writable tmpfs for /tmp
    --cap-drop=ALL \                       # Drop all capabilities
    --cap-add=NET_BIND_SERVICE \           # Add only needed capability
    --security-opt=no-new-privileges:true \ # Prevent privilege escalation
    --security-opt=seccomp=profile.json \  # Custom seccomp profile
    --memory=512m \                        # Memory limit
    --cpus=1.0 \                           # CPU limit
    --pids-limit=100 \                     # Process limit
    myapp
```

### Capability Reference

| Capability | Effect | Common Need |
|------------|--------|-------------|
| `NET_BIND_SERVICE` | Bind to ports < 1024 | Web servers on port 80/443 |
| `NET_ADMIN` | Network admin operations | VPN containers |
| `SYS_PTRACE` | Trace processes | Debug builds |
| `SYS_ADMIN` | Mount operations | Build containers |
| `DAC_READ_SEARCH` | Bypass read permissions | Backup containers |

!!! warning "Avoid SYS_ADMIN"
    `SYS_ADMIN` is equivalent to root in many contexts. It allows mount operations, loading kernel modules, and modifying namespaces. Grant it only in build containers and never in production.

---

## Podman (Rootless Alternative)

Podman is a daemonless container engine developed by Red Hat. It runs containers in user space without a persistent background process.

```bash
# Podman syntax is identical to Docker
podman build -t myapp .
podman run -d -p 8080:80 myapp

# Rootless: containers run as the current user
podman run --rm -it --userns=keep-id fedora bash

# Generate systemd unit file
podman generate systemd --new --name mycontainer > ~/.config/systemd/user/container-mycontainer.service
systemctl --user enable --now container-mycontainer
```

---

## Container Networking

```mermaid
flowchart TD
    subgraph Bridge["bridge (default)"]
        direction TB
        B1["Container A<br/>172.17.0.2"]
        B2["Container B<br/>172.17.0.3"]
        BR["docker0<br/>bridge"]
        B1 --> BR
        B2 --> BR
        BR --> NAT["NAT --> Host"]
    end

    subgraph Host["host"]
        H1["Container<br/>(shares host network)"]
    end

    subgraph None["none"]
        N1["Container<br/>(no network)"]
    end

    style Bridge fill:#4a90d9
    style Host fill:#7ed321
    style None fill:#d0021b
```

| Mode | Description | Use Case |
|------|-------------|----------|
| bridge | Default; isolated bridge network with NAT | Most applications |
| host | Shares host network namespace | High-performance networking |
| none | No network access | Offline processing |
| container | Shares another container's network | Sidecar pattern |
| macvlan | Assigns MAC address, appears as physical device | Legacy applications |

---

## Related Pages

- [Hypervisors](hypervisors.md) — VM-based isolation vs containers
- [Hosting](hosting.md) — Web server deployment
- [Minimalism](minimalism.md) — Attack surface reduction

## Related Deep Hole

- [Docker Security Documentation](https://docs.docker.com/engine/security/) — Official Docker security guide
- [CIS Docker Benchmark](https://www.cisecurity.org/benchmark/docker) — Hardening guidelines
- [NIST SP 800-190: Application Container Security Guide](https://nvlpubs.nist.gov/nistpubs/SpecialPublications/NIST.SP.800-190.pdf) — Federal container security guidance
- [OWASP Container Security Verification Standard](https://github.com/OWASP/Container-Security-Verification-Standard) — Container security requirements
- [Podman Documentation](https://docs.podman.io/) — Rootless container guide
"""

let render() = file
