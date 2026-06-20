# F# Zensical for MkDocs — Cross-Repo Pages Orchestrator

A complete **F# → GitHub Pages** workflow using Zensical (Material for MkDocs) with **F# and DSL support.** 

Designed with subdomains in mind, this orchestrator allows each site folder to build locally. GitHub Actions will build artifacts and push output to entirely separate GitHub repositories using token-authenticated git. 

This is a continuation repository - see the mkdocs implementation: [fsharp-material](https://github.com/CommanderTurtle/fsharp-material).

```fsharp
"""
       ∧＿∧ 
　    (｡･ω･｡)つ━☆・*。
   ⊂ /　  /　       ・゜
     しーＪ　　　    °。+*°。
		             .・゜F#                                   
                    ゜｡ﾟﾟ･｡･ﾟﾟ 
                       ╱|、     
                     (˚ˎ 。7 
                      |、˜〵    
                      じしˍ,)ノzensical
"""
```

Write type-safe F# configurations, build beautiful static sites, and deploy them with Zensical using dynamic content in F#.

# Table of Contents
(Quick Jumps)
1. [Overview](https://github.com/CommanderTurtle/fsharp-zensical/#table-of-contents)
2. [Features](https://github.com/CommanderTurtle/fsharp-zensical/#features)
3. [Local Setup Guide](https://github.com/CommanderTurtle/fsharp-zensical/#quick-start)
4. [FAQ](https://github.com/CommanderTurtle/fsharp-zensical/#4-what-to-configure)
   - 4.1 [GitHub Token + Secret](https://github.com/CommanderTurtle/fsharp-zensical/#faq)
   - 4.2 ['I'm a complete beginner'](https://github.com/CommanderTurtle/fsharp-zensical/#indexhtml-vs-indexmd-priority)
   - 4.3 [Nameschema / Individualization](https://github.com/CommanderTurtle/fsharp-zensical/#2-configure-repository-mapping)
1. [Guides for Devs](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/documentation/architecture/#overview-of-all-scripts)
   - 5.1 [Giraffe Attribute Shortcuts](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/documentation/architecture/#example-5-void-elements)
   - 5.2 [Triple-Quote Safety](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/documentation/fsharp-in-zensical/#migration-guide)
   - 5.3 [How to /throw/](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/documentation/how-to-throw)
   - 5.4 [Module Naming for index.fs Files](https://github.com/CommanderTurtle/fsharp-zensical/#creating-sites-things-to-know)
   - 5.5 [Sharpendabot bool (High-Level Overview)](https://github.com/CommanderTurtle/fsharp-zensical/#2-sharpendabot-bool-high-level-overview)
   - 5.6 [Configuring a new index.md](https://github.com/CommanderTurtle/fsharp-zensical/#indexmd-fs-markdown-content)
1. [Full Documentation (Wiki Hub)](https://github.com/CommanderTurtle/fsharp-zensical/#recommended-extra-documentation)
2. [Architecture Diagrams](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/documentation/architecture/#d-2-workflow-state-machine)
3. [Mathematical Foundations](https://github.com/CommanderTurtle/fsharp-zensical/tree/main/documentation/architecture/#mathematical-evolution)
4. [License](https://raw.githubusercontent.com/CommanderTurtle/fsharp-zensical/refs/heads/main/LICENSE)

---

Currently deploying a rust/python zensical documentation site, a custom ruby jekyll blog, two react apps, and two static git pages (default jekyll).

More can be read in the overhead repo, this deployment maintains `docs/`, `blog/`, `vite/`, `app/`, `pages/`, and `lab/`

---

###### [Try our js math library, requiring all math to be written in type-safe Haiku!](https://app.shel.sh/countku)

[Docs](https://docs.shel.sh) actively being updated, as well as main blog. Any pushes to this repo automatically configure all six site deployments.

<details>
  <summary>Show extra debug</summary>
  
#### Quick config (local development):

/throw/ automatically bundles legacy files via sharpendabot.
  
```powershell
# Perform a bundle:
dotnet run --project .\src\generator\Generator.fsproj -- wrap-batch "input" "output"

# Test a render:
dotnet fsi GenerateConfig.fsx render-site "input" "output" --clean

<# ###### #>
# Optionally run before bundling a dir (prevent DSL/giraffe on edge cases like jinja html / codegolf files):

Get-ChildItem "C:\path\to\target" -Recurse -Filter *.html -File | `
    Rename-Item -NewName { $_.BaseName + ".raw" }

dotnet run --project .\src\generator\Generator.fsproj -- wrap-batch "input" "output"

Get-ChildItem "C:\path\to\target" -Recurse -File | `
    Rename-Item -NewName { $_.Name.Replace("sharpraw", "sharphtml") }

Get-ChildItem "C:\path\to\target" -Recurse -File | `
    Rename-Item -NewName { $_.Name.Replace("sharphtml-index", "index") }

<# ###### #>
# Optionally remove excess throw directory folders created for index files:

Get-ChildItem -Recurse -File -Filter "index.fs" | `
    Where-Object { $_.Directory.Name -eq "index" } | `
    ForEach-Object { `
        Move-Item $_.FullName ($_.Directory.Parent.FullName + "\index.fs"); `
        Remove-Item $_.Directory.FullName -Force `
    }

<# ###### #>
# Debug if an error appears (example, search whole filetree for instances of !-- where <!-- should have been rendered):

Get-ChildItem "C:\folder" -Recurse -File | `
    Select-String "!--" | `
    Format-Table Path, LineNumber, Line
```

</details>