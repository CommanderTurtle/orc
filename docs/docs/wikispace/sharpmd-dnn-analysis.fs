module ConvertedFiles.Docs.Wikispace.DnnAnalysisMd

let file = """# Hybrid Web Architecture Analysis

Modern enterprise web applications frequently combine multiple technology generations within a single deployment. This page analyzes the DotNetNuke (DNN) content management system as an example of transitional architecture, where legacy ASP.NET WebForms infrastructure hosts modern client-side JavaScript frameworks.

---

## DotNetNuke (DNN) Architecture

DNN is an enterprise CMS built on ASP.NET WebForms. It provides role-based content permissions, intranet/extranet portals, authenticated user dashboards, and a modular plugin architecture.

### Server-Side Layer

| Component | Technology | Purpose |
|-----------|-----------|---------|
| Page lifecycle | ASP.NET WebForms | Request handling, viewstate management |
| Resource injection | CDF (Client Dependency Framework) | Dynamic script/style loading |
| Partial updates | ScriptManager / PageRequestManager | AJAX postbacks |
| Module system | DNN Modules | Pluggable content components |
| Templating | DNN Skins/Containers | Theme system |

The server-side layer generates initial HTML and manages state between requests. CDF injects scripts dynamically, versioned by `?cdv=2020` cache-busting parameters.

### Client-Side Layer

| Technology | Role |
|------------|------|
| Vue.js | Reactive components for modern widgets |
| jQuery | Legacy DOM manipulation |
| Bootstrap | Styling framework |
| DOMPurify | Client-side HTML sanitization |

Vue components bind to DOM elements rendered by DNN, fetching data via REST APIs without page reloads.

### Hybrid Integration Pattern

```
1. Browser requests DNN page
2. ASP.NET WebForms renders HTML server-side
3. CDF injects required scripts (Vue, jQuery, Bootstrap)
4. ScriptManager initializes page lifecycle
5. Vue mounts on designated DOM elements
6. Vue fetches JSON data from .NET Web API endpoints
7. Vue handles reactivity and DOM updates client-side
```

---

## DNN vs Giraffe ViewEngine

| Aspect | DNN | Giraffe ViewEngine |
|--------|-----|---------------------|
| Platform type | Full CMS | HTML rendering library |
| Language | C#/VB.NET | F# |
| Paradigm | Object-oriented, event-driven | Functional, composable |
| Role | Application platform + CMS | View layer only |
| Rendering | Server-side WebForms | Server-side functional DSL |
| Extensibility | Modules, skins, containers | Functions, components |
| Use case | Enterprise portals | Custom web apps, microservices |

### Giraffe ViewEngine Example

```fsharp
// Giraffe ViewEngine: HTML as F# expressions
open Giraffe.ViewEngine

let page =
    html [] [
        head [] [ title [] [ str "Page Title" ] ]
        body [] [
            div [ _class "container" ] [
                h1 [] [ str "Hello World" ]
            ]
        ]
    ]
```

### DNN Equivalent (ASP.NET WebForms)

```aspx
<%-- DNN Skin/Container --%>
<div class="container">
    <h1><%= Page.Title %></h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Server-rendered content -->
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
```

DNN uses controls and templates (imperative, stateful). Giraffe ViewEngine uses functions and expressions (declarative, stateless). DNN is a framework; Giraffe ViewEngine is a library.

---

## Who Uses DNN

| Organization Type | Use Case |
|-------------------|----------|
| Banks, insurance, utilities | Legacy .NET infrastructure |
| Healthcare networks | Patient portals, intranets |
| Universities | Student portals, event systems |
| Religious/nonprofit organizations | Live-streaming, event management |
| Government/municipal | Public service dashboards |
| Corporate HR/training | Video content portals |

---

## Signal Flow Diagram

```
[Browser Request]
    |
    v
[DNN Page Lifecycle]
    |
    +-- [CDF Bundling] --> [Script Injection]
    |                         |
    +-- [Module Injection]    v
    |                      [ScriptManager Init]
    |                         |
    +-- [Skin Rendering]      v
    |                      [DOM Ready]
    |                         |
    v                         v
[HTML Response] <------ [Vue Mount]
                             |
                             v
                      [.NET API Calls]
                      (/DesktopModules/.../API/)
                             |
                             v
                      [JSON Response]
                             |
                             v
                      [Vue Reactivity]
                             |
                             v
                      [DOM Updates]
```

---

## Related Deep Hole

- [DNN Platform Documentation](https://docs.dnncommunity.org/) — Community documentation
- [ASP.NET WebForms Lifecycle](https://docs.microsoft.com/en-us/troubleshoot/aspnet/understand-asp-net-page-life-cycle) — Microsoft documentation
- [Giraffe ViewEngine](https://github.com/giraffe-fsharp/Giraffe) — F# view engine
- [DNN hybridization analysis](user-provided) — Transitional architecture documentation
"""

let render() = file
