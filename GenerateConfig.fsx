#!/usr/bin/env dotnet fsi
// =============================================================================
// Multi-Subdomain Config Generator, Renderer & YML Sync Tool
// =============================================================================
// Keeps the original fsharp-zensical model:
//   - F# files are the durable source of truth.
//   - Generated files are rendered into a temp/publish tree.
//   - /throw/ HTML conversion still belongs to src/generator.
//
// Usage:
//   dotnet fsi GenerateConfig.fsx all
//   dotnet fsi GenerateConfig.fsx render-site docs .rendered/docs --clean
//   dotnet fsi GenerateConfig.fsx render-all .rendered --clean
//   dotnet fsi GenerateConfig.fsx render-workflows .rendered/workflows --clean
//   dotnet fsi GenerateConfig.fsx local-cycle .rendered/local-cycle --clean
//   dotnet fsi GenerateConfig.fsx sync
// =============================================================================

open System
open System.Diagnostics
open System.IO
open System.Text
open System.Text.RegularExpressions

// =============================================================================
// Shared helpers
// =============================================================================

let repoRoot = Directory.GetCurrentDirectory()

let fullPath (path: string) =
    if Path.IsPathRooted(path) then Path.GetFullPath(path)
    else Path.GetFullPath(Path.Combine(repoRoot, path))

let quotePath (path: string) = path.Replace("\\", "\\\\").Replace("\"", "\\\"")

let runProcess (fileName: string) (args: string) (workingDir: string) =
    let psi = ProcessStartInfo(fileName, args)
    psi.WorkingDirectory <- workingDir
    psi.RedirectStandardOutput <- true
    psi.RedirectStandardError <- true
    psi.UseShellExecute <- false

    use proc = Process.Start(psi)
    let stdout = proc.StandardOutput.ReadToEnd()
    let stderr = proc.StandardError.ReadToEnd()
    proc.WaitForExit()
    proc.ExitCode, stdout, stderr

let runTool (fileName: string) (args: string) (workingDir: string) =
    let platform = Environment.OSVersion.Platform
    let isWindows =
        platform = PlatformID.Win32NT
        || platform = PlatformID.Win32S
        || platform = PlatformID.Win32Windows
        || platform = PlatformID.WinCE

    if isWindows then
        runProcess "cmd.exe" (sprintf "/c %s %s" fileName args) workingDir
    else
        runProcess fileName args workingDir

let runProcessWithTimeout (fileName: string) (args: string) (workingDir: string) (timeout: TimeSpan) =
    let psi = ProcessStartInfo(fileName, args)
    psi.WorkingDirectory <- workingDir
    psi.RedirectStandardOutput <- true
    psi.RedirectStandardError <- true
    psi.UseShellExecute <- false

    use proc = Process.Start(psi)
    let stdoutTask = proc.StandardOutput.ReadToEndAsync()
    let stderrTask = proc.StandardError.ReadToEndAsync()
    let finished = proc.WaitForExit(int timeout.TotalMilliseconds)

    if finished then
        stdoutTask.Wait()
        stderrTask.Wait()
        proc.ExitCode, stdoutTask.Result, stderrTask.Result, false
    else
        try
            proc.Kill(true)
        with _ -> ()

        stdoutTask.Wait(2000) |> ignore
        stderrTask.Wait(2000) |> ignore
        let stdout = if stdoutTask.IsCompletedSuccessfully then stdoutTask.Result else ""
        let stderr = if stderrTask.IsCompletedSuccessfully then stderrTask.Result else ""
        -1, stdout, stderr + sprintf "\nTimed out after %.0f second(s)." timeout.TotalSeconds, true

let runToolWithTimeout (fileName: string) (args: string) (workingDir: string) (timeout: TimeSpan) =
    let platform = Environment.OSVersion.Platform
    let isWindows =
        platform = PlatformID.Win32NT
        || platform = PlatformID.Win32S
        || platform = PlatformID.Win32Windows
        || platform = PlatformID.WinCE

    if isWindows then
        runProcessWithTimeout "cmd.exe" (sprintf "/c %s %s" fileName args) workingDir timeout
    else
        runProcessWithTimeout fileName args workingDir timeout

let safeDeleteDirectory (path: string) =
    let full = Path.GetFullPath(path)
    let root = Path.GetPathRoot(full)
    let normalized = full.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)

    if String.IsNullOrWhiteSpace normalized || normalized.Equals(root.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar), StringComparison.OrdinalIgnoreCase) then
        failwithf "Refusing to delete unsafe directory: %s" full

    if Directory.Exists(full) then
        Directory.Delete(full, true)

let writeFileEnsuringDirectory (path: string) (content: string) =
    let dir = Path.GetDirectoryName(path)
    if not (String.IsNullOrWhiteSpace dir) then
        Directory.CreateDirectory(dir) |> ignore
    File.WriteAllText(path, content, Encoding.UTF8)

let copyFileEnsuringDirectory (source: string) (dest: string) =
    let dir = Path.GetDirectoryName(dest)
    if not (String.IsNullOrWhiteSpace dir) then
        Directory.CreateDirectory(dir) |> ignore
    File.Copy(source, dest, true)

let copyDirectoryRecursive (source: string) (dest: string) =
    if Directory.Exists(dest) then
        Directory.Delete(dest, true)

    Directory.CreateDirectory(dest) |> ignore

    for dir in Directory.GetDirectories(source, "*", SearchOption.AllDirectories) do
        let rel = Path.GetRelativePath(source, dir)
        Directory.CreateDirectory(Path.Combine(dest, rel)) |> ignore

    for file in Directory.GetFiles(source, "*", SearchOption.AllDirectories) do
        let rel = Path.GetRelativePath(source, file)
        copyFileEnsuringDirectory file (Path.Combine(dest, rel))

let countFiles (root: string) =
    if Directory.Exists(root) then
        Directory.GetFiles(root, "*", SearchOption.AllDirectories).Length
    else
        0

let relativeTo (root: string) (path: string) =
    Path.GetRelativePath(root, path)

let splitLines (text: string) =
    text.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n') |> Array.toList

// =============================================================================
// Config Generation Functions
// =============================================================================

let generate (folder: string) (moduleName: string) (outputName: string) =
    let fsPath = Path.Combine(folder, "zensical.fs")
    if not (File.Exists(fsPath)) then
        printfn "Missing %s" fsPath
        false
    else
        let code =
            sprintf
                """
#load "%s"
open %s
System.IO.File.WriteAllText("%s", render())
"""
                fsPath
                moduleName
                (Path.Combine(folder, outputName))

        let tempFile = Path.GetTempFileName() + ".fsx"
        File.WriteAllText(tempFile, code)

        let exitCode, _, stderr = runProcess "dotnet" (sprintf "fsi \"%s\"" tempFile) repoRoot
        File.Delete(tempFile)

        if exitCode = 0 then
            printfn "  OK %s/%s" folder outputName
            true
        else
            printfn "  Failed to generate %s/%s" folder outputName
            printfn "     %s" stderr
            false

let generateAll() =
    printfn ""
    printfn "Generating Zensical configurations"
    printfn ""

    let candidates = [
        "main", "Main.Zensical"
        "docs", "Docs.Zensical"
        "app", "App.Zensical"
        "blog", "Blog.Zensical"
    ]

    let configured =
        candidates
        |> List.filter (fun (folder, _) -> File.Exists(Path.Combine(folder, "zensical.fs")))

    let results =
        configured
        |> List.map (fun (folder, moduleName) -> generate folder moduleName "zensical.toml")

    printfn ""
    if List.isEmpty configured then
        printfn "No zensical.fs files found. Nothing to generate."
    elif List.forall id results then
        printfn "All configurations generated successfully."
    else
        printfn "Some configurations failed to generate."
    printfn ""

// =============================================================================
// F# site rendering
// =============================================================================

let ignoredDirectories =
    set [
        ".git"; ".github"; ".venv"; ".sass-cache"; ".jekyll-cache"; ".cache"
        ".deploy"; "bin"; "obj"; "node_modules"; "site"; "_site"; "dist"; "public"; "output"
    ]

let ignoredLiteralFiles =
    set [
        ".gitignore"
        ".gitattributes"
        ".nojekyll"
        "CNAME"
    ]

let isInsideIgnoredDirectory (root: string) (path: string) =
    let rel = relativeTo root path
    rel.Split([| Path.DirectorySeparatorChar; Path.AltDirectorySeparatorChar |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.exists (fun part -> ignoredDirectories.Contains(part))

let renderTargetForFsFile (sourcePath: string) =
    let fileName = Path.GetFileName(sourcePath)
    let lower = fileName.ToLowerInvariant()

    match lower with
    | "index.fs" -> Some "index.html"
    | "indexmd.fs" -> Some "index.md"
    | "zensical.fs" -> Some "zensical.toml"
    | "pyproject.fs" -> Some "pyproject.toml"
    | "mkdocs.fs" -> Some "mkdocs.yml"
    | _ ->
        let m = Regex.Match(fileName, @"^sharp([A-Za-z0-9]+)-(.+)\.fs$", RegexOptions.IgnoreCase)
        if not m.Success then
            None
        else
            let ext = m.Groups.[1].Value.ToLowerInvariant()
            let name = m.Groups.[2].Value
            match ext with
            | "bin" | "file" | "raw" | "none" ->
                failwithf "Unsupported wrapper '%s' in %s. Keep binary/extensionless files literal." ext sourcePath
            | "html" | "htm" -> Some (name + "." + ext)
            | "oml" | "toml" -> Some (name + ".toml")
            | "yaml" -> Some (name + ".yaml")
            | "yml" -> Some (name + ".yml")
            | "docker" | "dockerfile" -> Some "Dockerfile"
            | _ -> Some (name + "." + ext)

let modulePathIn (path: string) =
    let lines = File.ReadAllLines(path)

    let cleanModuleName (line: string) =
        line
            .Replace("module ", "")
            .Replace("namespace ", "")
            .Trim()
            .TrimEnd('=')
            .Trim()

    let firstDeclaration =
        lines
        |> Array.tryFind (fun line ->
            let t = line.Trim()
            t.StartsWith("module ") || t.StartsWith("namespace "))

    match firstDeclaration with
    | None -> failwithf "Could not find module or namespace declaration in %s" path
    | Some first ->
        let trimmed = first.Trim()
        if trimmed.StartsWith("namespace ") then
            let ns = cleanModuleName trimmed
            let inner =
                lines
                |> Array.tryFind (fun line ->
                    let t = line.Trim()
                    t.StartsWith("module ") && t.EndsWith("="))
                |> Option.map (fun line -> cleanModuleName (line.Trim()))
            match inner with
            | Some name -> ns + "." + name
            | None -> ns
        else
            cleanModuleName trimmed

let sharedPreludeLines() =
    let defaultLines = [ "open Giraffe.ViewEngine" ]
    let fromEnvironment =
        Environment.GetEnvironmentVariable("SHARED_FSHARP_OPENS")
        |> Option.ofObj
        |> Option.defaultValue ""
        |> splitLines
        |> List.map (fun line -> line.Trim())
        |> List.choose (fun line ->
            if String.IsNullOrWhiteSpace line || line.StartsWith("#") then None
            elif line.StartsWith("open ") then Some line
            else Some ("open " + line))

    defaultLines @ fromEnvironment |> List.distinct

let injectPrelude (sourceText: string) =
    let prelude =
        sharedPreludeLines()
        |> List.filter (fun line -> not (sourceText.Contains(line)))

    if List.isEmpty prelude then
        sourceText
    else
        let lines = splitLines sourceText

        let insertAt =
            lines
            |> List.tryFindIndex (fun line ->
                let t = line.Trim()
                t.StartsWith("module ") || t.StartsWith("namespace "))
            |> Option.map ((+) 1)
            |> Option.defaultValue 0

        let before, after = lines |> List.splitAt insertAt
        String.concat "\n" (before @ prelude @ after)

let stageFsFile (stageRoot: string) (sourceRoot: string) (sourcePath: string) =
    let rel = relativeTo sourceRoot sourcePath
    let stagedPath = Path.Combine(stageRoot, rel)
    let text = File.ReadAllText(sourcePath)
    writeFileEnsuringDirectory stagedPath (injectPrelude text)
    stagedPath

let helperIsReferencedBy (sourceText: string) (helperPath: string) =
    try
        let modulePath = modulePathIn helperPath
        let leaf = modulePath.Split('.') |> Array.last
        sourceText.Contains("open " + modulePath)
        || sourceText.Contains("open " + leaf)
        || sourceText.Contains(modulePath + ".")
        || sourceText.Contains(leaf + ".")
    with _ ->
        false

let renderFsFile (sourceRoot: string) (stageRoot: string) (helpers: string list) (sourcePath: string) (destPath: string) =
    let sourceText = File.ReadAllText(sourcePath)
    let selectedHelpers =
        helpers
        |> List.filter (helperIsReferencedBy sourceText)

    let stagedHelpers =
        selectedHelpers
        |> List.map (stageFsFile stageRoot sourceRoot)
        |> List.distinct

    let stagedSource = stageFsFile stageRoot sourceRoot sourcePath
    let modulePath = modulePathIn stagedSource

    let combinedSource =
        (sourcePath :: selectedHelpers)
        |> List.filter File.Exists
        |> List.map File.ReadAllText
        |> String.concat "\n"

    let sharedComponent =
        let path = fullPath "src/shared/Components.fs"
        let referencesShared =
            combinedSource.Contains("open Shared") || combinedSource.Contains("Shared.")
        if File.Exists(path) && referencesShared then [ path ] else []

    let loadLines =
        [
            yield "#r \"nuget: Giraffe.ViewEngine\""
            for file in sharedComponent do
                yield sprintf "#load @\"%s\"" (quotePath file)
            for file in stagedHelpers do
                if Path.GetFullPath(file) <> Path.GetFullPath(stagedSource) then
                    yield sprintf "#load @\"%s\"" (quotePath file)
            yield sprintf "#load @\"%s\"" (quotePath stagedSource)
            yield sprintf "open %s" modulePath
            yield sprintf "System.IO.File.WriteAllText(@\"%s\", render())" (quotePath destPath)
        ]

    let tempScript = Path.GetTempFileName() + ".fsx"
    File.WriteAllLines(tempScript, loadLines)

    let exitCode, stdout, stderr = runProcess "dotnet" (sprintf "fsi \"%s\"" tempScript) repoRoot
    File.Delete(tempScript)

    if exitCode <> 0 then
        failwithf "Failed to render %s -> %s\n%s\n%s" sourcePath destPath stdout stderr

let renderFsFilesBatch (sourceRoot: string) (helpers: string list) (targets: (string * string) list) =
    if List.isEmpty targets then
        0
    else
        let stageRoot = Path.Combine(Path.GetTempPath(), "fsharp-zensical-stage-" + Guid.NewGuid().ToString("N"))
        try
            let selectedHelpers =
                helpers
                |> List.filter (fun helper ->
                    targets
                    |> List.exists (fun (sourcePath, _) ->
                        let sourceText = File.ReadAllText(sourcePath)
                        helperIsReferencedBy sourceText helper))

            let combinedSource =
                (targets |> List.map fst) @ selectedHelpers
                |> List.filter File.Exists
                |> List.map File.ReadAllText
                |> String.concat "\n"

            let sharedComponent =
                let path = fullPath "src/shared/Components.fs"
                let referencesShared =
                    combinedSource.Contains("open Shared") || combinedSource.Contains("Shared.")
                if File.Exists(path) && referencesShared then [ path ] else []

            let stagedHelpers =
                selectedHelpers
                |> List.map (stageFsFile stageRoot sourceRoot)
                |> List.distinct

            let stagedTargets =
                targets
                |> List.map (fun (sourcePath, destPath) ->
                    let stagedSource = stageFsFile stageRoot sourceRoot sourcePath
                    sourcePath, stagedSource, modulePathIn stagedSource, destPath)

            let tempScript = Path.GetTempFileName() + ".fsx"
            let lines =
                [
                    yield "#r \"nuget: Giraffe.ViewEngine\""
                    yield "open System"
                    yield "open System.IO"
                    yield "let write (path: string) (content: string) ="
                    yield "    let dir = Path.GetDirectoryName(path)"
                    yield "    if not (String.IsNullOrWhiteSpace dir) then Directory.CreateDirectory(dir) |> ignore"
                    yield "    File.WriteAllText(path, content)"
                    for file in sharedComponent do
                        yield sprintf "#load @\"%s\"" (quotePath file)
                    for file in stagedHelpers do
                        yield sprintf "#load @\"%s\"" (quotePath file)
                    for (_, stagedSource, _, _) in stagedTargets do
                        yield sprintf "#load @\"%s\"" (quotePath stagedSource)
                    for (_, _, modulePath, destPath) in stagedTargets do
                        yield sprintf "write @\"%s\" (%s.render())" (quotePath destPath) modulePath
                ]

            File.WriteAllLines(tempScript, lines)
            let exitCode, stdout, stderr = runProcess "dotnet" (sprintf "fsi \"%s\"" tempScript) repoRoot
            File.Delete(tempScript)

            if exitCode <> 0 then
                failwithf "Failed to batch render %s\n%s\n%s" sourceRoot stdout stderr

            stagedTargets.Length
        finally
            if Directory.Exists(stageRoot) then Directory.Delete(stageRoot, true)

let renderSite (sourceFolder: string) (outputFolder: string) (clean: bool) =
    let sourceRoot = fullPath sourceFolder
    let outputRoot = fullPath outputFolder

    if not (Directory.Exists(sourceRoot)) then
        failwithf "Source folder not found: %s" sourceRoot

    if clean && Directory.Exists(outputRoot) then
        let normalizedRepo = repoRoot.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + string Path.DirectorySeparatorChar
        let normalizedOutput = outputRoot.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + string Path.DirectorySeparatorChar
        if not (normalizedOutput.StartsWith(normalizedRepo, StringComparison.OrdinalIgnoreCase)) then
            failwithf "Refusing to clean output outside this repository: %s" outputRoot
        Directory.Delete(outputRoot, true)

    Directory.CreateDirectory(outputRoot) |> ignore

    let files =
        Directory.GetFiles(sourceRoot, "*", SearchOption.AllDirectories)
        |> Array.filter (fun path -> not (isInsideIgnoredDirectory sourceRoot path))
        |> Array.toList

    let fsFiles = files |> List.filter (fun path -> Path.GetExtension(path).Equals(".fs", StringComparison.OrdinalIgnoreCase))

    let helperFiles =
        fsFiles
        |> List.filter (fun path -> renderTargetForFsFile path |> Option.isNone)

    let mutable copied = 0
    let renderTargets = ResizeArray<string * string>()

    for file in files do
        let rel = relativeTo sourceRoot file
        let dest = Path.Combine(outputRoot, rel)
        if Path.GetExtension(file).Equals(".fs", StringComparison.OrdinalIgnoreCase) then
            match renderTargetForFsFile file with
            | None -> ()
            | Some targetName ->
                let destFile = Path.Combine(Path.GetDirectoryName(dest), targetName)
                renderTargets.Add((file, destFile))
        else
            let name = Path.GetFileName(file)
            if not (ignoredLiteralFiles.Contains(name)) then
                copyFileEnsuringDirectory file dest
                copied <- copied + 1

    let rendered = renderFsFilesBatch sourceRoot helperFiles (renderTargets |> Seq.toList)

    for fs in Directory.GetFiles(outputRoot, "*.fs", SearchOption.AllDirectories) do
        File.Delete(fs)
    for fsx in Directory.GetFiles(outputRoot, "*.fsx", SearchOption.AllDirectories) do
        File.Delete(fsx)

    printfn "Rendered site: %s" sourceFolder
    printfn "  output:   %s" outputRoot
    printfn "  rendered: %d F# file(s)" rendered
    printfn "  copied:   %d literal file(s)" copied

let defaultSiteFolders =
    [ "docs"; "blog"; "vite"; "app"; "pages"; "lab" ]

let renderAll (outputRoot: string) (clean: bool) =
    for folder in defaultSiteFolders do
        if Directory.Exists(fullPath folder) then
            renderSite folder (Path.Combine(outputRoot, folder)) clean

// =============================================================================
// Local Sharpendabot / deploy-cycle simulation
// =============================================================================

let renderWorkflowConfigs (outputFolder: string) (clean: bool) =
    let configDir = fullPath ".github/config"
    let outputRoot = fullPath outputFolder
    let sharedDeploy = fullPath ".github/config/shared/deploy-common.fs"

    if not (Directory.Exists(configDir)) then
        failwithf "Workflow config directory not found: %s" configDir

    if clean then
        safeDeleteDirectory outputRoot

    Directory.CreateDirectory(outputRoot) |> ignore

    let fsFiles =
        Directory.GetFiles(configDir, "*.fs", SearchOption.TopDirectoryOnly)
        |> Array.sort

    let mutable generated = 0

    for fsFile in fsFiles do
        let name = Path.GetFileNameWithoutExtension(fsFile)
        let modulePath = modulePathIn fsFile
        let outputPath = Path.Combine(outputRoot, name + ".yml")
        let tempScript = Path.GetTempFileName() + ".fsx"
        let lines =
            [
                if File.Exists(sharedDeploy) then
                    yield sprintf "#load @\"%s\"" (quotePath sharedDeploy)
                yield sprintf "#load @\"%s\"" (quotePath fsFile)
                yield sprintf "open %s" modulePath
                yield sprintf "System.IO.File.WriteAllText(@\"%s\", render())" (quotePath outputPath)
            ]

        File.WriteAllLines(tempScript, lines)
        let exitCode, stdout, stderr = runProcess "dotnet" (sprintf "fsi \"%s\"" tempScript) repoRoot
        File.Delete(tempScript)

        if exitCode <> 0 then
            failwithf "Failed to render workflow %s\n%s\n%s" fsFile stdout stderr

        generated <- generated + 1

    printfn "Rendered workflows: %d" generated
    printfn "  output: %s" outputRoot
    generated

let localCycleStepTimeout() =
    Environment.GetEnvironmentVariable("LOCAL_CYCLE_STEP_TIMEOUT_SECONDS")
    |> Option.ofObj
    |> Option.bind (fun value ->
        match Int32.TryParse(value) with
        | true, seconds when seconds > 0 -> Some seconds
        | _ -> None)
    |> Option.defaultValue 300
    |> fun seconds -> TimeSpan.FromSeconds(float seconds)

let logToolRun (logsDir: string) (site: string) (step: string) (command: string) (args: string) (workingDir: string) =
    Directory.CreateDirectory(logsDir) |> ignore
    let sw = Stopwatch.StartNew()
    let timeout = localCycleStepTimeout()
    let exitCode, stdout, stderr, timedOut = runToolWithTimeout command args workingDir timeout
    sw.Stop()

    let logPath = Path.Combine(logsDir, sprintf "%s-%s.log" site step)
    let log =
        sprintf
            "command: %s %s\ncwd: %s\nexit: %d\ntimed_out: %b\nseconds: %.3f\ntimeout_seconds: %.0f\n\n--- stdout ---\n%s\n\n--- stderr ---\n%s\n"
            command
            args
            workingDir
            exitCode
            timedOut
            sw.Elapsed.TotalSeconds
            timeout.TotalSeconds
            stdout
            stderr
    writeFileEnsuringDirectory logPath log

    if exitCode <> 0 then
        failwithf "Build step failed for %s (%s). See %s" site step logPath

    sw.Elapsed.TotalSeconds

let detectAndBuildSite (site: string) (renderedRoot: string) (logsDir: string) =
    let buildSw = Stopwatch.StartNew()
    let mutable buildKind = "static"

    let publishRoot =
        if File.Exists(Path.Combine(renderedRoot, "zensical.toml")) then
            buildKind <- "zensical"
            logToolRun logsDir site "zensical-build" "uv" "run --with zensical zensical build" renderedRoot |> ignore
            Path.Combine(renderedRoot, "site")
        elif File.Exists(Path.Combine(renderedRoot, "Gemfile")) then
            buildKind <- "jekyll"
            logToolRun logsDir site "bundle-install" "bundle" "install" renderedRoot |> ignore
            logToolRun logsDir site "jekyll-build" "bundle" "exec jekyll build --disable-disk-cache" renderedRoot |> ignore
            Path.Combine(renderedRoot, "_site")
        elif File.Exists(Path.Combine(renderedRoot, "package.json")) then
            buildKind <- "javascript"
            logToolRun logsDir site "bun-install" "bun" "install" renderedRoot |> ignore
            logToolRun logsDir site "bun-build" "bun" "run build" renderedRoot |> ignore
            Path.Combine(renderedRoot, "dist")
        else
            renderedRoot

    buildSw.Stop()

    if not (Directory.Exists(publishRoot)) then
        failwithf "Publish directory did not exist for %s: %s" site publishRoot

    buildKind, publishRoot, buildSw.Elapsed.TotalSeconds

let scrubPublishRoot (publishRoot: string) =
    let mutable deleted = 0

    for file in Directory.GetFiles(publishRoot, "*", SearchOption.AllDirectories) do
        let name = Path.GetFileName(file)
        let ext = Path.GetExtension(file)
        if ext.Equals(".fs", StringComparison.OrdinalIgnoreCase)
           || ext.Equals(".fsx", StringComparison.OrdinalIgnoreCase)
           || ignoredLiteralFiles.Contains(name) then
            File.Delete(file)
            deleted <- deleted + 1

    deleted

type LocalCycleSiteReport = {
    Site: string
    BuildKind: string
    RenderSeconds: float
    BuildSeconds: float
    ScrubbedFiles: int
    PublishedFiles: int
    MockRoot: string
}

let jsonEscape (value: string) =
    value
        .Replace("\\", "\\\\")
        .Replace("\"", "\\\"")
        .Replace("\r", "\\r")
        .Replace("\n", "\\n")

let writeLocalCycleReport (reportPath: string) (workflowCount: int) (sites: LocalCycleSiteReport list) =
    let siteJson =
        sites
        |> List.map (fun site ->
            sprintf
                "    {\n      \"site\": \"%s\",\n      \"build_kind\": \"%s\",\n      \"render_seconds\": %.3f,\n      \"build_seconds\": %.3f,\n      \"scrubbed_files\": %d,\n      \"published_files\": %d,\n      \"mock_root\": \"%s\"\n    }"
                (jsonEscape site.Site)
                (jsonEscape site.BuildKind)
                site.RenderSeconds
                site.BuildSeconds
                site.ScrubbedFiles
                site.PublishedFiles
                (jsonEscape site.MockRoot))
        |> String.concat ",\n"

    let json =
        sprintf
            "{\n  \"generated_workflows\": %d,\n  \"sites\": [\n%s\n  ]\n}\n"
            workflowCount
            siteJson

    writeFileEnsuringDirectory reportPath json

let localCycle (outputFolder: string) (clean: bool) =
    let outputRoot = fullPath outputFolder
    if clean then
        safeDeleteDirectory outputRoot

    Directory.CreateDirectory(outputRoot) |> ignore

    let workflowsRoot = Path.Combine(outputRoot, "workflows")
    let stageRoot = Path.Combine(outputRoot, "stage")
    let mockRoot = Path.Combine(outputRoot, "mock-push-roots")
    let logsDir = Path.Combine(outputRoot, "logs")

    if Directory.Exists(stageRoot) then safeDeleteDirectory stageRoot
    if Directory.Exists(mockRoot) then safeDeleteDirectory mockRoot
    if Directory.Exists(workflowsRoot) then safeDeleteDirectory workflowsRoot

    Directory.CreateDirectory(stageRoot) |> ignore
    Directory.CreateDirectory(mockRoot) |> ignore

    let workflowCount = renderWorkflowConfigs workflowsRoot false
    let reports = ResizeArray<LocalCycleSiteReport>()

    try
        for site in defaultSiteFolders do
            if Directory.Exists(fullPath site) then
                let renderedRoot = Path.Combine(stageRoot, site, "output")
                let renderSw = Stopwatch.StartNew()
                renderSite site renderedRoot false
                renderSw.Stop()

                let buildKind, publishRoot, buildSeconds = detectAndBuildSite site renderedRoot logsDir
                let scrubbed = scrubPublishRoot publishRoot
                let siteMockRoot = Path.Combine(mockRoot, site)
                copyDirectoryRecursive publishRoot siteMockRoot

                reports.Add({
                    Site = site
                    BuildKind = buildKind
                    RenderSeconds = renderSw.Elapsed.TotalSeconds
                    BuildSeconds = buildSeconds
                    ScrubbedFiles = scrubbed
                    PublishedFiles = countFiles siteMockRoot
                    MockRoot = siteMockRoot
                })

        let reportPath = Path.Combine(outputRoot, "report.json")
        writeLocalCycleReport reportPath workflowCount (reports |> Seq.toList)

        printfn "Local cycle complete"
        printfn "  workflows: %s" workflowsRoot
        printfn "  mock roots: %s" mockRoot
        printfn "  report:    %s" reportPath
    finally
        if Directory.Exists(stageRoot) then
            Directory.Delete(stageRoot, true)

// =============================================================================
// YML -> .fs Sync Functions
// =============================================================================

let toPascalCase (name: string) =
    name.Split([| '-'; '_' |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun part ->
        if String.IsNullOrEmpty(part) then ""
        else Char.ToUpperInvariant(part.[0]).ToString() + part.[1..])
    |> String.concat ""

let getModulePath (fileName: string) =
    match fileName with
    | "dependabot" -> "Config.Dependabot"
    | name when name.StartsWith("deploy-") ->
        let suffix = name.Substring(7) |> toPascalCase
        sprintf "Config.Workflows.Deploy%s" suffix
    | name when name.StartsWith("pr-") ->
        let suffix = name.Substring(3) |> toPascalCase
        sprintf "Config.Workflows.Pr%s" suffix
    | name when name.Contains("dependency") ->
        "Config.Workflows.DependencyUpdate"
    | name when name.StartsWith("build-and-deploy") ->
        "Config.Workflows.BuildAndDeploy"
    | name when name.StartsWith("hello-world") ->
        "Workflows.HelloWorld"
    | _ ->
        sprintf "Config.Workflows.%s" (toPascalCase fileName)

let shouldSync (fileName: string) =
    let name = Path.GetFileNameWithoutExtension(fileName)
    name <> "sharpendabot"

let escapeForTripleQuoted (content: string) =
    if content.Contains("\"\"\"") then
        content.Replace("\"\"\"", "\"\"\" + \"\\\"\\\"\\\"\" + \"\"\"")
    else
        content

let generateFsContent (modulePath: string) (ymlContent: string) (sourceFile: string) =
    let escapedContent = escapeForTripleQuoted ymlContent
    sprintf
        "module %s\n\n/// <summary>\n/// Auto-generated from %s.\n/// This workflow was encoded back from its YML form.\n/// </summary>\nlet file = \"\"\"\n%s\n\"\"\"\n\nlet render() = file\n"
        modulePath
        sourceFile
        escapedContent

let syncYmlFile (ymlPath: string) (configDir: string) =
    let fileName = Path.GetFileNameWithoutExtension(ymlPath)
    let fsPath = Path.Combine(configDir, fileName + ".fs")

    printfn "  Syncing: %s -> %s" (Path.GetFileName(ymlPath)) (Path.GetFileName(fsPath))

    let ymlContent = File.ReadAllText(ymlPath)
    let modulePath = getModulePath fileName
    let fsContent = generateFsContent modulePath ymlContent (Path.GetFileName(ymlPath))

    File.WriteAllText(fsPath, fsContent)
    printfn "    Encoded: %s" fsPath

let syncAllYml() =
    printfn ""
    printfn "Syncing YML -> .fs"
    printfn ""

    let workflowsDir = ".github/workflows"
    let configDir = ".github/config"

    if not (Directory.Exists(workflowsDir)) then
        printfn "Workflows directory not found: %s" workflowsDir
    else
        Directory.CreateDirectory(configDir) |> ignore

        let ymlFiles = Directory.GetFiles(workflowsDir, "*.yml")
        let mutable syncedCount = 0

        for ymlFile in ymlFiles do
            if shouldSync ymlFile then
                try
                    syncYmlFile ymlFile configDir
                    syncedCount <- syncedCount + 1
                with ex ->
                    printfn "  Failed to sync %s: %s" (Path.GetFileName(ymlFile)) ex.Message
            else
                printfn "  Skipped authority: %s" (Path.GetFileName(ymlFile))

        printfn ""
        printfn "Synced %d workflow(s)" syncedCount
        printfn ""

// =============================================================================
// Entry Point
// =============================================================================

let args =
    fsi.CommandLineArgs
    |> Array.skip 1

let hasFlag flag =
    args |> Array.exists (fun arg -> arg.Equals(flag, StringComparison.OrdinalIgnoreCase))

let withoutFlags =
    args |> Array.filter (fun arg -> not (arg.StartsWith("--")))

match withoutFlags |> Array.tryHead with
| Some "all" | None -> generateAll()
| Some "main" -> generate "main" "Main.Zensical" "zensical.toml" |> ignore
| Some "docs" -> generate "docs" "Docs.Zensical" "zensical.toml" |> ignore
| Some "app" -> generate "app" "App.Zensical" "zensical.toml" |> ignore
| Some "blog" -> generate "blog" "Blog.Zensical" "zensical.toml" |> ignore
| Some "sync" -> syncAllYml()
| Some "render-site" ->
    if withoutFlags.Length < 3 then
        failwith "Usage: dotnet fsi GenerateConfig.fsx render-site <source-folder> <output-folder> [--clean]"
    renderSite withoutFlags.[1] withoutFlags.[2] (hasFlag "--clean")
| Some "render-all" ->
    let outRoot =
        if withoutFlags.Length >= 2 then withoutFlags.[1]
        else ".rendered"
    renderAll outRoot (hasFlag "--clean")
| Some "render-workflows" ->
    let outRoot =
        if withoutFlags.Length >= 2 then withoutFlags.[1]
        else ".rendered/workflows"
    renderWorkflowConfigs outRoot (hasFlag "--clean") |> ignore
| Some "local-cycle" ->
    let outRoot =
        if withoutFlags.Length >= 2 then withoutFlags.[1]
        else ".rendered/local-cycle"
    localCycle outRoot (hasFlag "--clean")
| Some arg ->
    printfn "Unknown argument: %s" arg
    printfn ""
    printfn "Usage:"
    printfn "  dotnet fsi GenerateConfig.fsx all"
    printfn "  dotnet fsi GenerateConfig.fsx main|docs|app|blog"
    printfn "  dotnet fsi GenerateConfig.fsx sync"
    printfn "  dotnet fsi GenerateConfig.fsx render-site <source-folder> <output-folder> [--clean]"
    printfn "  dotnet fsi GenerateConfig.fsx render-all [output-root] [--clean]"
    printfn "  dotnet fsi GenerateConfig.fsx render-workflows [output-root] [--clean]"
    printfn "  dotnet fsi GenerateConfig.fsx local-cycle [output-root] [--clean]"
