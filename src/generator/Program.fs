
namespace Generator

open System
open System.IO
open System.Text
open SafeStringBuilder
open Spectre.Console
open GiraffeDslConverter
open Verification

module Program =
    let printHelp () =
        AnsiConsole.WriteLine()
        AnsiConsole.Write(Rule("[blue]HTML to Giraffe Converter[/]").RuleStyle("grey"))
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine("[yellow]Usage:[/]")
        AnsiConsole.MarkupLine("  html2giraffe [[command]] [[options]]")
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine("[yellow]Commands:[/]")
        AnsiConsole.MarkupLine("  [green]convert[/] <input> [[output]]     Convert HTML file to F# Giraffe DSL")
        AnsiConsole.MarkupLine("  [green]batch[/] <input-dir> <output>  Batch convert HTML files")
        AnsiConsole.MarkupLine("  [green]wrap-file[/] <input> <output>  Wrap one text/static file as sharp* F#")
        AnsiConsole.MarkupLine("  [green]wrap-batch[/] <input-dir> <output-dir>  Wrap a folder tree as sharp* F#")
        AnsiConsole.MarkupLine("  [green]wrap-site[/] <input-dir> <output-dir>  Re-import a rendered site tree as F# source")
        AnsiConsole.MarkupLine("  [green]verify[/]                      Verify conversion integrity")
        AnsiConsole.MarkupLine("  [green]help[/]                        Show this help message")
        AnsiConsole.MarkupLine("  [green]version[/]                     Show version information")
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine("[yellow]Options for convert:[/]")
        AnsiConsole.MarkupLine("  [green]--dsl[/]                       Use proper Giraffe DSL (default)")
        AnsiConsole.MarkupLine("  [green]--literal[/]                   Use triple-quoted literal mode")
        AnsiConsole.MarkupLine("  [green]--lines[/]                     Use line-by-line variable mode")
        AnsiConsole.WriteLine()

    let printVersion () =
        AnsiConsole.MarkupLine("[blue]html2giraffe[/] version [yellow]1.0.0[/]")
        AnsiConsole.MarkupLine("HTML to F# Giraffe.ViewEngine Converter")

    /// <summary>
    /// Converts HTML to F# using the new proper Giraffe DSL converter.
    /// </summary>
    let convertToGiraffeDsl (inputPath: string) (outputPath: string) =
        let html = File.ReadAllText(inputPath)
        let fsharpCode = GiraffeDslConverter.convert html
        File.WriteAllText(outputPath, fsharpCode)

    /// <summary>
    /// Converts HTML to F# using triple-quoted literal mode.
    /// </summary>
    let convertToLiteral (inputPath: string) (outputPath: string) =
        let html = File.ReadAllText(inputPath)
        let fsharpCode = EnhancedConverter.convertQuick html
        File.WriteAllText(outputPath, fsharpCode)

    /// <summary>
    /// Converts HTML to F# using line-by-line variable mode.
    /// </summary>
    let convertToLines (inputPath: string) (outputPath: string) =
        let html = File.ReadAllText(inputPath)
        let moduleName = Path.GetFileNameWithoutExtension(inputPath) |> fun s -> s.[0..0].ToUpper() + s.[1..]
        let fsharpCode = EnhancedConverter.convertWithLines html moduleName
        File.WriteAllText(outputPath, fsharpCode)

    let ensureParentDirectory (path: string) =
        let dir = Path.GetDirectoryName(path)
        if not (isNull dir) && not (String.IsNullOrWhiteSpace dir) then
            Directory.CreateDirectory(dir) |> ignore

    let splitIdentifierWords (value: string) =
        let cleaned =
            value
            |> Seq.map (fun c -> if Char.IsLetterOrDigit(c) then c else ' ')
            |> Seq.toArray
            |> fun chars -> new String(chars)

        cleaned.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries)

    let toPascalIdentifier (value: string) =
        let words = splitIdentifierWords value
        let name =
            words
            |> Array.map (fun word ->
                if String.IsNullOrWhiteSpace word then ""
                else Char.ToUpperInvariant(word.[0]).ToString() + word.[1..])
            |> String.concat ""

        let normalized =
            if String.IsNullOrWhiteSpace name then "File"
            elif Char.IsDigit(name.[0]) then "N" + name
            else name

        let keywords =
            set [
                "Abstract"; "And"; "As"; "Assert"; "Base"; "Begin"; "Class"; "Default"
                "Delegate"; "Do"; "Done"; "Downcast"; "Downto"; "Elif"; "Else"; "End"
                "Exception"; "Extern"; "False"; "Finally"; "Fixed"; "For"; "Fun"; "Function"
                "Global"; "If"; "In"; "Inherit"; "Inline"; "Interface"; "Internal"; "Lazy"
                "Let"; "Match"; "Member"; "Module"; "Mutable"; "Namespace"; "New"; "Not"
                "Null"; "Of"; "Open"; "Or"; "Override"; "Private"; "Public"; "Rec"; "Return"
                "Sig"; "Static"; "Struct"; "Then"; "To"; "True"; "Try"; "Type"; "Upcast"
                "Use"; "Val"; "Void"; "When"; "While"; "With"; "Yield"
            ]

        if keywords.Contains(normalized) then normalized + "Value" else normalized

    let extensionKeyForFile (inputPath: string) =
        let fileName = Path.GetFileName(inputPath)
        let ext = Path.GetExtension(inputPath).TrimStart('.').ToLowerInvariant()

        if fileName.Equals("Dockerfile", StringComparison.OrdinalIgnoreCase) then Some "docker"
        elif String.IsNullOrWhiteSpace ext then None
        elif ext = "htm" || ext = "html" then None
        elif ext = "toml" then Some "oml"
        else Some ext

    let wrapperFileNameFor (inputPath: string) =
        match extensionKeyForFile inputPath with
        | None -> None
        | Some "docker" -> Some "sharpdocker-Dockerfile.fs"
        | Some ext ->
            let baseName = Path.GetFileNameWithoutExtension(inputPath)
            Some (sprintf "sharp%s-%s.fs" ext baseName)

    let literalWrapperFileNameFor (inputPath: string) =
        let fileName = Path.GetFileName(inputPath)
        let ext = Path.GetExtension(inputPath).TrimStart('.').ToLowerInvariant()
        let baseName = Path.GetFileNameWithoutExtension(inputPath)

        if fileName.Equals("Dockerfile", StringComparison.OrdinalIgnoreCase) then
            Some "sharpdocker-Dockerfile.fs"
        elif String.IsNullOrWhiteSpace ext then
            None
        elif ext = "toml" then
            Some (sprintf "sharpoml-%s.fs" baseName)
        else
            Some (sprintf "sharp%s-%s.fs" ext baseName)

    let moduleNameForRelative (rootModule: string) (relativePath: string) =
        let separators = [| Path.DirectorySeparatorChar; Path.AltDirectorySeparatorChar |]
        let parts =
            relativePath.Split(separators, StringSplitOptions.RemoveEmptyEntries)
            |> Array.toList

        let lastIndex = parts.Length - 1
        let moduleParts =
            parts
            |> List.mapi (fun index part ->
                if index = lastIndex then
                    let ext = Path.GetExtension(part).TrimStart('.')
                    let stem = Path.GetFileNameWithoutExtension(part)
                    if String.IsNullOrWhiteSpace ext then toPascalIdentifier stem
                    else toPascalIdentifier (stem + "-" + ext)
                else
                    toPascalIdentifier part)

        rootModule :: moduleParts |> String.concat "."

    let tryReadUtf8Text (inputPath: string) =
        let bytes = File.ReadAllBytes(inputPath)
        if bytes |> Array.exists ((=) 0uy) then
            None
        else
            try
                let utf8 = UTF8Encoding(false, true)
                Some (utf8.GetString(bytes))
            with
            | :? DecoderFallbackException -> None

    let toFSharpStringExpression (content: string) =
        SafeStringBuilder.toTripleQuoted content

    let writeTextWrapper (inputPath: string) (outputPath: string) (moduleName: string) =
        match tryReadUtf8Text inputPath with
        | None -> false
        | Some content ->
            let expression = toFSharpStringExpression content
            let code =
                sprintf "module %s\n\nlet file = %s\n\nlet render() = file\n" moduleName expression

            ensureParentDirectory outputPath
            File.WriteAllText(outputPath, code, Encoding.UTF8)
            true

    let replaceModuleLine (moduleName: string) (fsharpCode: string) =
        let lines = fsharpCode.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n')
        if lines.Length > 0 && lines.[0].StartsWith("module ", StringComparison.Ordinal) then
            lines.[0] <- "module " + moduleName
        String.Join("\n", lines)

    let convertHtmlToDslModule (inputPath: string) (outputPath: string) (moduleName: string) =
        let html = File.ReadAllText(inputPath)
        let code = GiraffeDslConverter.convert html |> replaceModuleLine moduleName
        ensureParentDirectory outputPath
        File.WriteAllText(outputPath, code, Encoding.UTF8)

    let resolveWrapFileOutput (inputPath: string) (outputPath: string) =
        let ext = Path.GetExtension(inputPath).ToLowerInvariant()
        let outputIsFs =
            Path.GetExtension(outputPath).Equals(".fs", StringComparison.OrdinalIgnoreCase)

        if outputIsFs then outputPath
        elif ext = ".html" || ext = ".htm" then
            Path.Combine(outputPath, Path.GetFileNameWithoutExtension(inputPath), "index.fs")
        else
            match wrapperFileNameFor inputPath with
            | Some wrapperName -> Path.Combine(outputPath, wrapperName)
            | None -> Path.Combine(outputPath, Path.GetFileName(inputPath))

    let copyLiteralFile (inputPath: string) (outputPath: string) =
        ensureParentDirectory outputPath
        File.Copy(inputPath, outputPath, true)

    let handleWrapFile (args: string[]) =
        if args.Length < 3 then
            AnsiConsole.MarkupLine("[red]Error:[/] Input and output required")
            1
        else
            let inputPath = args.[1]
            let outputPath = resolveWrapFileOutput inputPath args.[2]

            if not (File.Exists(inputPath)) then
                AnsiConsole.MarkupLine(sprintf "[red]Error:[/] File not found: %s" inputPath)
                1
            else
                try
                    let ext = Path.GetExtension(inputPath).ToLowerInvariant()
                    let relativeForModule = Path.GetFileName(inputPath)
                    let moduleName = moduleNameForRelative "ConvertedFiles" relativeForModule

                    if ext = ".html" || ext = ".htm" then
                        convertHtmlToDslModule inputPath outputPath moduleName
                        AnsiConsole.MarkupLine(sprintf "[green]Success:[/] Converted HTML to [blue]%s[/]" outputPath)
                        0
                    else
                        match wrapperFileNameFor inputPath with
                        | Some _ when writeTextWrapper inputPath outputPath moduleName ->
                            AnsiConsole.MarkupLine(sprintf "[green]Success:[/] Wrapped file to [blue]%s[/]" outputPath)
                            0
                        | _ ->
                            copyLiteralFile inputPath outputPath
                            AnsiConsole.MarkupLine(sprintf "[yellow]Copied literal:[/] %s" outputPath)
                            0
                with ex ->
                    AnsiConsole.MarkupLine(sprintf "[red]Error:[/] %s" ex.Message)
                    1

    let handleWrapBatch (args: string[]) =
        if args.Length < 3 then
            AnsiConsole.MarkupLine("[red]Error:[/] Input and output directories required")
            1
        else
            let inputDir = args.[1]
            let outputDir = args.[2]

            if not (Directory.Exists(inputDir)) then
                AnsiConsole.MarkupLine(sprintf "[red]Error:[/] Directory not found: %s" inputDir)
                1
            else
                try
                    let mutable wrapped = 0
                    let mutable htmlConverted = 0
                    let mutable copied = 0

                    for inputPath in Directory.GetFiles(inputDir, "*", SearchOption.AllDirectories) do
                        let rel = Path.GetRelativePath(inputDir, inputPath)
                        let ext = Path.GetExtension(inputPath).ToLowerInvariant()

                        if ext = ".html" || ext = ".htm" then
                            let relDir = Path.GetDirectoryName(rel)
                            let pageDir =
                                if isNull relDir || String.IsNullOrWhiteSpace relDir then
                                    Path.GetFileNameWithoutExtension(inputPath)
                                else
                                    Path.Combine(relDir, Path.GetFileNameWithoutExtension(inputPath))

                            let outputPath = Path.Combine(outputDir, pageDir, "index.fs")
                            let moduleName = moduleNameForRelative "ConvertedFiles" rel
                            convertHtmlToDslModule inputPath outputPath moduleName
                            htmlConverted <- htmlConverted + 1
                        else
                            match wrapperFileNameFor inputPath with
                            | Some wrapperName when Option.isSome (tryReadUtf8Text inputPath) ->
                                let relDir = Path.GetDirectoryName(rel)
                                let outputPath =
                                    if isNull relDir || String.IsNullOrWhiteSpace relDir then
                                        Path.Combine(outputDir, wrapperName)
                                    else
                                        Path.Combine(outputDir, relDir, wrapperName)

                                let moduleName = moduleNameForRelative "ConvertedFiles" rel
                                if writeTextWrapper inputPath outputPath moduleName then
                                    wrapped <- wrapped + 1
                                else
                                    copyLiteralFile inputPath (Path.Combine(outputDir, rel))
                                    copied <- copied + 1
                            | _ ->
                                copyLiteralFile inputPath (Path.Combine(outputDir, rel))
                                copied <- copied + 1

                    AnsiConsole.MarkupLine(sprintf "[green]Success:[/] Wrapped [blue]%d[/], converted HTML [blue]%d[/], copied literal [blue]%d[/]" wrapped htmlConverted copied)
                    0
                with ex ->
                    AnsiConsole.MarkupLine(sprintf "[red]Error:[/] %s" ex.Message)
                    1

    let knownSiteOutputName (fileName: string) =
        match fileName.ToLowerInvariant() with
        | "index.md" -> Some "indexmd.fs"
        | "zensical.toml" -> Some "zensical.fs"
        | "pyproject.toml" -> Some "pyproject.fs"
        | "mkdocs.yml" | "mkdocs.yaml" -> Some "mkdocs.fs"
        | _ -> None

    let shouldSkipSiteImportFile (fileName: string) =
        match fileName with
        | ".gitignore" | ".gitattributes" | ".nojekyll" | "CNAME" -> true
        | _ -> false

    let handleWrapSite (args: string[]) =
        if args.Length < 3 then
            AnsiConsole.MarkupLine("[red]Error:[/] Input and output directories required")
            1
        else
            let inputDir = args.[1]
            let outputDir = args.[2]

            if not (Directory.Exists(inputDir)) then
                AnsiConsole.MarkupLine(sprintf "[red]Error:[/] Directory not found: %s" inputDir)
                1
            else
                try
                    let mutable wrapped = 0
                    let mutable htmlConverted = 0
                    let mutable copied = 0
                    let mutable skipped = 0

                    for inputPath in Directory.GetFiles(inputDir, "*", SearchOption.AllDirectories) do
                        let rel = Path.GetRelativePath(inputDir, inputPath)
                        let relDir = Path.GetDirectoryName(rel)
                        let fileName = Path.GetFileName(inputPath)
                        let ext = Path.GetExtension(inputPath).ToLowerInvariant()
                        let targetDir =
                            if isNull relDir || String.IsNullOrWhiteSpace relDir then outputDir
                            else Path.Combine(outputDir, relDir)

                        if shouldSkipSiteImportFile fileName then
                            skipped <- skipped + 1
                        elif fileName.Equals("index.html", StringComparison.OrdinalIgnoreCase) || fileName.Equals("index.htm", StringComparison.OrdinalIgnoreCase) then
                            let outputPath = Path.Combine(targetDir, "index.fs")
                            let moduleName = moduleNameForRelative "Imported" rel
                            convertHtmlToDslModule inputPath outputPath moduleName
                            htmlConverted <- htmlConverted + 1
                        else
                            match knownSiteOutputName fileName with
                            | Some fsName when Option.isSome (tryReadUtf8Text inputPath) ->
                                let outputPath = Path.Combine(targetDir, fsName)
                                let moduleName = moduleNameForRelative "Imported" rel
                                if writeTextWrapper inputPath outputPath moduleName then
                                    wrapped <- wrapped + 1
                                else
                                    copyLiteralFile inputPath (Path.Combine(outputDir, rel))
                                    copied <- copied + 1
                            | _ ->
                                match literalWrapperFileNameFor inputPath with
                                | Some wrapperName when Option.isSome (tryReadUtf8Text inputPath) ->
                                    let outputPath = Path.Combine(targetDir, wrapperName)
                                    let moduleName = moduleNameForRelative "Imported" rel
                                    if writeTextWrapper inputPath outputPath moduleName then
                                        wrapped <- wrapped + 1
                                    else
                                        copyLiteralFile inputPath (Path.Combine(outputDir, rel))
                                        copied <- copied + 1
                                | _ ->
                                    copyLiteralFile inputPath (Path.Combine(outputDir, rel))
                                    copied <- copied + 1

                    AnsiConsole.MarkupLine(sprintf "[green]Success:[/] Site wrapped [blue]%d[/], converted index HTML [blue]%d[/], copied literal [blue]%d[/], skipped [blue]%d[/]" wrapped htmlConverted copied skipped)
                    0
                with ex ->
                    AnsiConsole.MarkupLine(sprintf "[red]Error:[/] %s" ex.Message)
                    1

    let handleConvert (args: string[]) =
        if args.Length < 2 then
            AnsiConsole.MarkupLine("[red]Error:[/] Input file required")
            1
        else
            let inputPath = args.[1]
            
            // Check for mode flags
            let mode = 
                if args |> Array.contains "--literal" then "literal"
                elif args |> Array.contains "--lines" then "lines"
                else "dsl"
            
            // Find output path (skip mode flags)
            let outputPath = 
                let nonFlagArgs = args |> Array.filter (fun a -> not (a.StartsWith("--")))
                if nonFlagArgs.Length > 2 then nonFlagArgs.[2]
                else Path.ChangeExtension(inputPath, ".fs")
            
            if not (File.Exists(inputPath)) then
                AnsiConsole.MarkupLine(sprintf "[red]Error:[/] File not found: %s" inputPath)
                1
            else
                try
                    AnsiConsole.Status().Start(
                        sprintf "Converting [blue]%s[/] using [green]%s[/] mode..." (Path.GetFileName(inputPath)) mode,
                        fun ctx ->
                            match mode with
                            | "literal" -> convertToLiteral inputPath outputPath
                            | "lines" -> convertToLines inputPath outputPath
                            | _ -> convertToGiraffeDsl inputPath outputPath
                    )
                    AnsiConsole.MarkupLine(sprintf "[green]Success:[/] Converted to [blue]%s[/]" outputPath)
                    0
                with ex ->
                    AnsiConsole.MarkupLine(sprintf "[red]Error:[/] %s" ex.Message)
                    1

    let handleBatch (args: string[]) =
        if args.Length < 3 then
            AnsiConsole.MarkupLine("[red]Error:[/] Input and output directories required")
            1
        else
            let inputDir = args.[1]
            let outputDir = args.[2]
            
            // Check for mode flags
            let mode = 
                if args |> Array.contains "--literal" then "literal"
                elif args |> Array.contains "--lines" then "lines"
                else "dsl"
            
            if not (Directory.Exists(inputDir)) then
                AnsiConsole.MarkupLine(sprintf "[red]Error:[/] Directory not found: %s" inputDir)
                1
            else
                try
                    let htmlFiles = Directory.GetFiles(inputDir, "*.html", SearchOption.AllDirectories)
                    
                    AnsiConsole.Status().Start(
                        sprintf "Converting [blue]%d[/] files using [green]%s[/] mode..." htmlFiles.Length mode,
                        fun ctx ->
                            for htmlFile in htmlFiles do
                                let relativePath = htmlFile.Substring(inputDir.Length).TrimStart('/', '\\')
                                let outputFile = Path.Combine(outputDir, Path.ChangeExtension(relativePath, ".fs"))
                                Directory.CreateDirectory(Path.GetDirectoryName(outputFile)) |> ignore
                                
                                match mode with
                                | "literal" -> convertToLiteral htmlFile outputFile
                                | "lines" -> convertToLines htmlFile outputFile
                                | _ -> convertToGiraffeDsl htmlFile outputFile
                    )
                    
                    AnsiConsole.MarkupLine(sprintf "[green]Success:[/] Converted [blue]%d[/] files" htmlFiles.Length)
                    0
                with ex ->
                    AnsiConsole.MarkupLine(sprintf "[red]Error:[/] %s" ex.Message)
                    1

    let handleVerify (args: string[]) =
        try
            let report = runAllChecks()
            printReport report
            if List.isEmpty report.OrphanFiles then 0 else 2
        with ex ->
            AnsiConsole.MarkupLine(sprintf "[red]Error:[/] %s" ex.Message)
            1

    [<EntryPoint>]
    let main (args: string[]) : int =
        try
            if args.Length = 0 then
                printHelp()
                0
            else
                match args.[0].ToLowerInvariant() with
                | "convert" | "c" -> handleConvert args
                | "batch" | "b" -> handleBatch args
                | "wrap-file" | "wrap" -> handleWrapFile args
                | "wrap-batch" | "wrap-dir" -> handleWrapBatch args
                | "wrap-site" | "site-wrap" -> handleWrapSite args
                | "verify" | "v" -> handleVerify args
                | "help" | "h" | "--help" | "-h" -> printHelp(); 0
                | "version" | "--version" | "-v" -> printVersion(); 0
                | _ ->
                    AnsiConsole.MarkupLine(sprintf "[red]Unknown command:[/] %s" args.[0])
                    printHelp()
                    1
        with ex ->
            AnsiConsole.MarkupLine(sprintf "[red]Fatal error:[/] %s" ex.Message)
            1


