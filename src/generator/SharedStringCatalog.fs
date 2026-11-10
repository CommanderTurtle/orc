namespace Generator

open System
open System.Collections.Generic
open System.IO
open System.Security.Cryptography
open System.Text
open System.Text.RegularExpressions

module SharedStringCatalog =
    type ReconcileResult = {
        WrappersChanged: int
        ReferencesRewritten: int
        AssetsAdded: int
        AssetsTotal: int
        SkippedPayloads: int
        CatalogPath: string
    }

    type AssetInfo = {
        Id: int
        Reference: string
        Bytes: int
        Sha256: string
    }

    type AssetRegistration = {
        Info: AssetInfo
        MimeType: string
        WasAdded: bool
        AttributeExpression: string
        RawTextExpression: string
        CatalogPath: string
    }

    type private AssetEntry = {
        Id: int
        Category: string
        Name: string
        Hash: string
        Payload: string
        Bytes: int
    }

    type private TextDocument = {
        Text: string
        Encoding: Encoding
        HasPreamble: bool
    }

    type private Replacement = {
        Index: int
        Length: int
        Text: string
    }

    type private FilePlan = {
        Path: string
        Document: TextDocument
        Updated: string
    }

    let private ignoredDirectories =
        set [
            ".git"; ".venv"; ".cache"; ".sass-cache"; ".jekyll-cache"
            "bin"; "obj"; "target"; "node_modules"; "site"; "_site"
            "dist"; "public"; "output"; "strings"
        ]

    let private dataUriPattern =
        Regex(
            "(?<prefix>data:(?<mime>[A-Za-z0-9.+-]+/[A-Za-z0-9.+-]+)(?:;[A-Za-z0-9.+_-]+=[^;,\\s\"']+)*;base64,)(?<payload>[A-Za-z0-9+/]{32,}={0,2})",
            RegexOptions.CultureInvariant
        )

    let private catalogEntryPattern =
        Regex(
            "(?ms)^\\s*//\\s*asset-id:\\s*(?<id>\\d+)\\s+sha256:\\s*(?<hash>[A-Fa-f0-9]{64})\\s*\\r?\\n\\s*let\\s+(?<name>[A-Za-z_][A-Za-z0-9_']*)\\s*=\\s*\"\"\"(?<payload>[A-Za-z0-9+/]+={0,2})\"\"\"",
            RegexOptions.CultureInvariant
        )

    let private identifierPattern =
        Regex("^[A-Za-z_][A-Za-z0-9_']*$", RegexOptions.CultureInvariant)

    let private readTextFile path =
        let bytes = File.ReadAllBytes(path)
        let encoding, preambleLength =
            if bytes.Length >= 3 && bytes.[0] = 0xEFuy && bytes.[1] = 0xBBuy && bytes.[2] = 0xBFuy then
                UTF8Encoding(true, true) :> Encoding, 3
            elif bytes.Length >= 2 && bytes.[0] = 0xFEuy && bytes.[1] = 0xFFuy then
                UnicodeEncoding(true, true, true) :> Encoding, 2
            elif bytes.Length >= 2 && bytes.[0] = 0xFFuy && bytes.[1] = 0xFEuy then
                UnicodeEncoding(false, true, true) :> Encoding, 2
            else
                UTF8Encoding(false, true) :> Encoding, 0

        {
            Text = encoding.GetString(bytes, preambleLength, bytes.Length - preambleLength)
            Encoding = encoding
            HasPreamble = preambleLength > 0
        }

    let private writeTextAtomically (path: string) (document: TextDocument) (text: string) =
        let directory =
            Path.GetDirectoryName(path)
            |> Option.ofObj
            |> Option.defaultValue (Directory.GetCurrentDirectory())
        Directory.CreateDirectory(directory) |> ignore
        let temporary =
            Path.Combine(
                directory,
                "." + Path.GetFileName(path) + ".shared-strings-" + Guid.NewGuid().ToString("N") + ".tmp"
            )
        let body = document.Encoding.GetBytes(text)
        let bytes =
            if document.HasPreamble then
                let preamble = document.Encoding.GetPreamble()
                Array.append preamble body
            else
                body
        try
            File.WriteAllBytes(temporary, bytes)
            File.Move(temporary, path, true)
        finally
            if File.Exists(temporary) then File.Delete(temporary)

    let private defaultCatalogDocument (text: string) : TextDocument =
        {
            Text = text
            Encoding = UTF8Encoding(false) :> Encoding
            HasPreamble = false
        }

    let private normalizeBase64 (payload: string) =
        match payload.Length % 4 with
        | 0 -> payload
        | 1 -> raise (FormatException("Base64 payload length cannot be normalized."))
        | remainder -> payload + String('=', 4 - remainder)

    let private decodeBase64 payload =
        Convert.FromBase64String(normalizeBase64 payload)

    let private sha256 (bytes: byte[]) =
        Convert.ToHexString(SHA256.HashData(bytes))

    let private categoryForMime (mime: string) =
        match mime.Split('/', 2).[0].ToLowerInvariant() with
        | "image" -> "Image"
        | "audio" -> "Audio"
        | "video" -> "Video"
        | "font" -> "Font"
        | "application" -> "Application"
        | _ -> "Other"

    let private inferMimeType (path: string) (explicitMime: string option) =
        match explicitMime with
        | Some mime when not (String.IsNullOrWhiteSpace(mime)) ->
            if not (Regex.IsMatch(mime, "^[A-Za-z0-9.+-]+/[A-Za-z0-9.+-]+$")) then
                failwithf "Invalid MIME type: %s" mime
            mime.ToLowerInvariant()
        | _ ->
            let extension =
                Path.GetExtension(path)
                |> Option.ofObj
                |> Option.defaultValue ""
                |> _.ToLowerInvariant()
            match extension with
            | ".png" -> "image/png"
            | ".jpg" | ".jpeg" -> "image/jpeg"
            | ".gif" -> "image/gif"
            | ".webp" -> "image/webp"
            | ".avif" -> "image/avif"
            | ".svg" -> "image/svg+xml"
            | ".ico" -> "image/x-icon"
            | ".mp3" -> "audio/mpeg"
            | ".wav" -> "audio/wav"
            | ".m4a" -> "audio/mp4"
            | ".aac" -> "audio/aac"
            | ".ogg" -> "audio/ogg"
            | ".flac" -> "audio/flac"
            | ".mp4" -> "video/mp4"
            | ".webm" -> "video/webm"
            | ".woff" -> "font/woff"
            | ".woff2" -> "font/woff2"
            | ".ttf" -> "font/ttf"
            | ".otf" -> "font/otf"
            | ".json" -> "application/json"
            | ".pdf" -> "application/pdf"
            | extension ->
                failwithf "Cannot infer a MIME type from '%s'. Supply --mime=type/subtype." extension

    let private resolveCatalogPath (siteRoot: string) (catalog: string option) =
        let root = Path.GetFullPath(siteRoot)
        if not (Directory.Exists(root)) then
            failwithf "Site folder not found: %s" root
        let path =
            match catalog with
            | Some value when not (String.IsNullOrWhiteSpace(value)) && Path.IsPathRooted(value) ->
                Path.GetFullPath(value)
            | Some value when not (String.IsNullOrWhiteSpace(value)) ->
                let direct = Path.GetFullPath(value)
                let directParent = Path.GetDirectoryName(direct)
                if File.Exists(direct) || Directory.Exists(directParent) then direct
                else Path.GetFullPath(Path.Combine(root, value))
            | _ ->
                Path.GetFullPath(Path.Combine(root, "strings", "sharedstrings.fs"))
        path

    let private referenceFor (entry: AssetEntry) =
        entry.Category + "." + entry.Name

    let private loadCatalog catalogPath =
        let entries = ResizeArray<AssetEntry>()
        let byHash = Dictionary<string, AssetEntry>(StringComparer.OrdinalIgnoreCase)
        let mutable highestId = 0
        let document =
            if File.Exists(catalogPath) then Some(readTextFile catalogPath)
            else None

        match document with
        | None -> ()
        | Some catalog ->
            for matched in catalogEntryPattern.Matches(catalog.Text) |> Seq.cast<Match> do
                let id = Int32.Parse(matched.Groups.["id"].Value)
                let payload = matched.Groups.["payload"].Value
                let bytes = decodeBase64 payload
                let hash = sha256 bytes
                if not (hash.Equals(matched.Groups.["hash"].Value, StringComparison.OrdinalIgnoreCase)) then
                    failwithf "Catalog hash mismatch for asset-id %d in %s" id catalogPath
                if byHash.ContainsKey(hash) then
                    failwithf "Duplicate payload entries already exist in %s" catalogPath

                let categoryStart = catalog.Text.LastIndexOf("module ", matched.Index, StringComparison.Ordinal)
                if categoryStart < 0 then
                    failwithf "Could not resolve the module for asset-id %d in %s" id catalogPath
                let foundLineEnd = catalog.Text.IndexOfAny([| '\r'; '\n' |], categoryStart)
                let categoryLineEnd = if foundLineEnd < 0 then catalog.Text.Length else foundLineEnd
                let category =
                    catalog.Text.Substring(categoryStart + 7, categoryLineEnd - categoryStart - 7)
                        .Trim()
                        .TrimEnd('=')
                        .Trim()
                let entry = {
                    Id = id
                    Category = category
                    Name = matched.Groups.["name"].Value
                    Hash = hash
                    Payload = payload
                    Bytes = bytes.Length
                }
                entries.Add(entry)
                byHash.Add(hash, entry)
                highestId <- max highestId id

        entries, byHash, highestId, document

    let private catalogText (newline: string) (entries: seq<AssetEntry>) =
        let lines = ResizeArray<string>()
        lines.Add("module SharedStrings")
        lines.Add("")
        lines.Add("// Generated by enumerate-base64.ps1. Rename a let binding and its reported")
        lines.Add("// Category.Name references together; asset-id and hash remain stable.")

        entries
        |> Seq.groupBy (fun entry -> entry.Category)
        |> Seq.iter (fun (category, group) ->
            lines.Add("")
            lines.Add("module " + category + " =")
            group
            |> Seq.iter (fun entry ->
                lines.Add("")
                lines.Add(sprintf "    // asset-id: %03d sha256: %s" entry.Id entry.Hash)
                lines.Add(sprintf "    let %s = \"\"\"%s\"\"\"" entry.Name entry.Payload)))

        String.concat newline lines + newline

    let private eligibleWrapper (path: string) =
        let name =
            Path.GetFileName(path)
            |> Option.ofObj
            |> Option.defaultValue ""
            |> _.ToLowerInvariant()
        name = "index.fs"
        || name = "indexmd.fs"
        || ((name.StartsWith("sharphtml-")
             || name.StartsWith("sharphtm-")
             || name.StartsWith("sharpmd-")
             || name.StartsWith("sharpmarkdown-"))
            && name.EndsWith(".fs"))

    let private ignoredFile (root: string) (path: string) =
        Path.GetRelativePath(root, path)
            .Split(
                [| Path.DirectorySeparatorChar; Path.AltDirectorySeparatorChar |],
                StringSplitOptions.RemoveEmptyEntries
            )
        |> Array.exists ignoredDirectories.Contains

    let private insideTripleQuotedString (text: string) (index: int) =
        Regex.Matches(text.Substring(0, index), "\"\"\"").Count % 2 = 1

    let private replacementFor (text: string) (matched: Match) (reference: string) : Replacement =
        let prefix = matched.Groups.["prefix"].Value
        if insideTripleQuotedString text matched.Index then
            {
                Index = matched.Index
                Length = matched.Length
                Text = prefix + "\"\"\" + " + reference + " + \"\"\""
            }
        else
            let before = matched.Index - 1
            let after = matched.Index + matched.Length
            if before >= 0 && after < text.Length && text.[before] = '"' && text.[after] = '"' then
                {
                    Index = before
                    Length = matched.Length + 2
                    Text = "(\"" + prefix + "\" + " + reference + ")"
                }
            else
                failwithf
                    "Unsupported Base64 context at character %d. Outside triple-quoted raw text, the data URI must occupy one complete F# string literal."
                    matched.Index

    let private newlineFor (document: TextDocument option) (fallback: string) =
        match document with
        | Some value when value.Text.Contains("\r\n", StringComparison.Ordinal) -> "\r\n"
        | Some _ -> "\n"
        | None -> fallback

    let reconcile siteRoot catalog =
        let root = Path.GetFullPath(siteRoot)
        let catalogPath = resolveCatalogPath root catalog
        let entries, byHash, initialHighestId, existingCatalog = loadCatalog catalogPath
        let mutable highestId = initialHighestId
        let mutable added = 0
        let mutable references = 0
        let mutable skipped = 0
        let plans = ResizeArray<FilePlan>()

        let files =
            Directory.GetFiles(root, "*", SearchOption.AllDirectories)
            |> Array.filter (fun path -> eligibleWrapper path && not (ignoredFile root path))
            |> Array.sort

        for path in files do
            let document = readTextFile path
            let replacements = ResizeArray<Replacement>()
            for matched in dataUriPattern.Matches(document.Text) |> Seq.cast<Match> do
                try
                    let payload = matched.Groups.["payload"].Value
                    let bytes = decodeBase64 payload
                    let hash = sha256 bytes
                    let entry =
                        match byHash.TryGetValue(hash) with
                        | true, existing -> existing
                        | false, _ ->
                            highestId <- highestId + 1
                            added <- added + 1
                            let created = {
                                Id = highestId
                                Category = categoryForMime matched.Groups.["mime"].Value
                                Name = sprintf "Asset%03d" highestId
                                Hash = hash
                                Payload = payload
                                Bytes = bytes.Length
                            }
                            entries.Add(created)
                            byHash.Add(hash, created)
                            created
                    replacements.Add(replacementFor document.Text matched (referenceFor entry))
                    references <- references + 1
                with :? FormatException ->
                    skipped <- skipped + 1

            if replacements.Count > 0 then
                let mutable updated = document.Text
                replacements
                |> Seq.sortByDescending (fun replacement -> replacement.Index)
                |> Seq.iter (fun replacement ->
                    updated <-
                        updated.Substring(0, replacement.Index)
                        + replacement.Text
                        + updated.Substring(replacement.Index + replacement.Length))
                plans.Add({ Path = path; Document = document; Updated = updated })

        if references > 0 then
            let fallbackNewline =
                if plans.Count > 0 && not (plans.[0].Document.Text.Contains("\r\n", StringComparison.Ordinal)) then "\n"
                else "\r\n"
            if added > 0 then
                let newline = newlineFor existingCatalog fallbackNewline
                let output = catalogText newline entries
                let catalogDocument =
                    existingCatalog
                    |> Option.defaultValue (defaultCatalogDocument output)
                writeTextAtomically catalogPath catalogDocument output
            for plan in plans do
                writeTextAtomically plan.Path plan.Document plan.Updated

        {
            WrappersChanged = plans.Count
            ReferencesRewritten = references
            AssetsAdded = added
            AssetsTotal = entries.Count
            SkippedPayloads = skipped
            CatalogPath = catalogPath
        }

    let registerAsset siteRoot catalog assetPath requestedName explicitMime =
        let root = Path.GetFullPath(siteRoot)
        let catalogPath = resolveCatalogPath root catalog
        let fullAssetPath = Path.GetFullPath(assetPath)
        if not (File.Exists(fullAssetPath)) then
            failwithf "Asset file not found: %s" fullAssetPath
        let bytes = File.ReadAllBytes(fullAssetPath)
        if bytes.Length = 0 then
            failwith "Shared-string assets cannot be empty."
        let mime = inferMimeType fullAssetPath explicitMime
        let hash = sha256 bytes
        let entries, byHash, highestId, existingCatalog = loadCatalog catalogPath
        let entry, wasAdded =
            match byHash.TryGetValue(hash) with
            | true, existing -> existing, false
            | false, _ ->
                let id = highestId + 1
                let category = categoryForMime mime
                let name =
                    requestedName
                    |> Option.filter (String.IsNullOrWhiteSpace >> not)
                    |> Option.defaultValue (sprintf "Asset%03d" id)
                if not (identifierPattern.IsMatch(name)) then
                    failwithf "Invalid F# binding name: %s" name
                if entries |> Seq.exists (fun item -> item.Category = category && item.Name = name) then
                    failwithf "Catalog reference %s.%s already belongs to another asset." category name
                let created = {
                    Id = id
                    Category = category
                    Name = name
                    Hash = hash
                    Payload = Convert.ToBase64String(bytes)
                    Bytes = bytes.Length
                }
                entries.Add(created)
                created, true

        if wasAdded then
            let newline = newlineFor existingCatalog "\n"
            let output = catalogText newline entries
            let catalogDocument =
                existingCatalog
                |> Option.defaultValue (defaultCatalogDocument output)
            writeTextAtomically catalogPath catalogDocument output

        let reference = referenceFor entry
        {
            Info = {
                Id = entry.Id
                Reference = reference
                Bytes = entry.Bytes
                Sha256 = entry.Hash
            }
            MimeType = mime
            WasAdded = wasAdded
            AttributeExpression = sprintf "(\"data:%s;base64,\" + %s)" mime reference
            RawTextExpression = sprintf "data:%s;base64,\"\"\" + %s + \"\"\"" mime reference
            CatalogPath = catalogPath
        }

    let listAssets siteRoot catalog =
        let catalogPath = resolveCatalogPath (Path.GetFullPath(siteRoot)) catalog
        let entries, _, _, _ = loadCatalog catalogPath
        entries
        |> Seq.sortBy (fun entry -> entry.Id)
        |> Seq.map (fun entry -> {
            Id = entry.Id
            Reference = referenceFor entry
            Bytes = entry.Bytes
            Sha256 = entry.Hash
        })
        |> Seq.toList
