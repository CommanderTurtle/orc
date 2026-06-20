module ConvertedFiles.Docs.Wikispace.ModernObjectsMd

let file = """# Powershell Objects

Modern programming patterns for structured data manipulation, with emphasis on PowerShell's object pipeline, Python's data model, and cross-platform JSON interchange. The Amazon Web Services SDK patterns for list operations, pagination, and batch processing are used as reference implementations due to their maturity in handling large-scale object collections.

---

## PowerShell Objects

Everything in PowerShell is an object. The pipeline passes objects with full fidelity, preserving type information, properties, and methods at each stage.

### Creating Objects

```powershell
# Hashtable to PSCustomObject
$server = [PSCustomObject]@{
    Hostname    = 'web01.local'
    IPAddress   = '10.0.0.5'
    Port        = 443
    SSLEnabled  = $true
    Services    = @('http', 'https', 'ssh')
}

# Adding methods
$server | Add-Member -MemberType ScriptMethod -Name "GetEndpoint" -Value {
    $protocol = if ($this.SSLEnabled) { "https" } else { "http" }
    return "$($protocol)://$($this.Hostname):$($this.Port)"
}

$server.GetEndpoint()  # https://web01.local:443
```

### Object Pipeline

```powershell
# Multi-stage pipeline with full object fidelity
Get-Process |
    Where-Object {$_.WorkingSet -gt 100MB} |
    Select-Object Name, Id,
        @{N='MemoryMB'; E={[math]::Round($_.WorkingSet / 1MB, 2)}},
        @{N='CPUPercent'; E={$_.CPU}} |
    Sort-Object MemoryMB -Descending |
    Select-Object -First 10

# Grouping and aggregation
Get-ChildItem -File |
    Group-Object Extension |
    Select-Object Name, Count,
        @{N='TotalSize'; E={($_.Group | Measure-Object Length -Sum).Sum}}
```

---

## AWS SDK List Pattern Reference

The AWS SDK pagination pattern is a robust model for handling large collections. It generalizes to any API that returns paginated results.

### Pagination Pattern

```powershell
function Get-AllPages {
    param([scriptblock]$FetchPage)
    $all = [System.Collections.ArrayList]::new()
    $nextToken = $null
    do {
        $page = & $FetchPage -NextToken $nextToken
        [void]$all.AddRange($page.Items)
        $nextToken = $page.NextToken
    } while ($nextToken)
    return $all
}

# Usage example (conceptual)
$objects = Get-AllPages -FetchPage {
    param($NextToken)
    # API call returning { Items, NextToken }
}
```

### Batch Processing Pattern

```powershell
function Invoke-Batch {
    param(
        [array]$Items,
        [int]$BatchSize = 25,
        [scriptblock]$ProcessBatch
    )
    for ($i = 0; $i -lt $Items.Count; $i += $BatchSize) {
        $batch = $Items[$i..([Math]::Min($i + $BatchSize - 1, $Items.Count - 1))]
        & $ProcessBatch -Batch $batch
        Write-Host "Processed $($i + $batch.Count) / $($Items.Count)"
    }
}
```

---

## JSON as Interchange Format

### PowerShell JSON

```powershell
# Convert object to JSON
$config = @{
    Name     = 'Server'
    Status   = 'Running'
    Ports    = @(80, 443)
    Metadata = @{ Region = 'us-east-1'; Tier = 'production' }
}
$json = $config | ConvertTo-Json -Depth 5

# Convert from JSON
$parsed = $json | ConvertFrom-Json
$parsed.Metadata.Region

# File operations
Get-Content "config.json" | ConvertFrom-Json
$config | ConvertTo-Json -Depth 5 | Set-Content "config.json"
```

### Python JSON

```python
import json

# Serialize
config = {"name": "Server", "status": "Running", "ports": [80, 443]}
json_str = json.dumps(config, indent=2)

# Deserialize
parsed = json.loads(json_str)
print(parsed["ports"])  # [80, 443]

# File operations
with open("config.json", "w") as f:
    json.dump(config, f, indent=2)

with open("config.json", "r") as f:
    loaded = json.load(f)
```

---

## Builder Pattern

```powershell
class RequestBuilder {
    [string]$Method
    [string]$Uri
    [hashtable]$Headers
    [hashtable]$Query
    [object]$Body

    RequestBuilder() {
        $this.Headers = @{}
        $this.Query = @{}
    }

    [RequestBuilder] WithMethod([string]$method) {
        $this.Method = $method
        return $this
    }

    [RequestBuilder] WithUri([string]$uri) {
        $this.Uri = $uri
        return $this
    }

    [RequestBuilder] WithHeader([string]$key, [string]$value) {
        $this.Headers[$key] = $value
        return $this
    }

    [RequestBuilder] WithQuery([string]$key, [string]$value) {
        $this.Query[$key] = $value
        return $this
    }

    [hashtable] Build() {
        $uriBuilder = [System.UriBuilder]::new($this.Uri)
        if ($this.Query.Count -gt 0) {
            $uriBuilder.Query = ($this.Query.GetEnumerator() |
                ForEach-Object { "$($_.Key)=$([System.Web.HttpUtility]::UrlEncode($_.Value))" }) -join "&"
        }
        return @{
            Method  = $this.Method
            Uri     = $uriBuilder.Uri.ToString()
            Headers = $this.Headers
        }
    }
}

# Fluent usage
$request = [RequestBuilder]::new()
    .WithMethod("GET")
    .WithUri("https://api.example.com/v1/items")
    .WithHeader("Authorization", "Bearer $token")
    .WithHeader("Accept", "application/json")
    .WithQuery("limit", "100")
    .WithQuery("offset", "0")
    .Build()
```

---

## Related Deep Hole

- [PowerShell Object Pipeline Documentation](https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/04-pipelines) — Official pipeline documentation
- [AWS SDK for .NET Pagination](https://docs.aws.amazon.com/sdk-for-net/v3/developer-guide/paginators.html) — AWS pagination pattern reference
- [PowerShell Classes Documentation](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_classes) — Class-based development
"""

let render() = file
