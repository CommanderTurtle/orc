module ConvertedFiles.Docs.Projects.AutomateMd

let file = """# Automation

This is a brief technical document on tools used to make automation easier.

In the modern era, there is a number of sources:

- [HTML to Markdown machine](https://app.shel.sh/webclip "JS can become a full routing engine. Used in this standalone webpage. <br> (All conversion happens within single html file)"){:rel="noopener noreferrer" target="blank"}
    - [see: the monkey Sidecar](#a-grep-script "jump to script import")
- [Tasket++](https://github.com/AmirHammouteneEI/ScheduledPasteAndKeys "AmirHammouteneEI/ScheduledPasteAndKeys <br> This is a dev tool written in C++, <br>ported to MSIX (Microsoft store)"){:rel="noopener noreferrer" target="blank"}
    - [see: the macro sidecar](./macrohard.md){ data-preview } - a native http daemon to "harness" tasket
    - and of course, [the UI](https://app.shel.sh/macro "a preview for importing machine code to the sidecar daemon"){:rel="noopener noreferrer" target="blank"}
- [Surfingkeys](https://github.com/brookhong/Surfingkeys "brookhong/Surfingkeys <br> This is a full suite for keyboard surfing in web browsers."){:rel="noopener noreferrer" target="blank"}
- [Powertoys](https://github.com/microsoft/PowerToys/tree/main/doc/devdocs "microsoft's take on QoL<br>a helpful program one cannot live without"){:rel="noopener noreferrer" target="blank"}

*[native]: ~300kb harnness<br> ...with more scriptability than Autohotkey<br>written solely with Qt

---

# A Grep Script! 🥳

Prerequisites ?

- install Tampermonkey [here (edge)](https://microsoftedge.microsoft.com/addons/detail/tampermonkey/iikmkjmpaadaobahmlepeloendndfphd?hl=en-US){:rel="noopener noreferrer" target="blank"}
- [or here (chrome)](https://chromewebstore.google.com/detail/tampermonkey/dhdgffkkebhmkfjojejmpbldmpobfkfo?hl=en-US){:rel="noopener noreferrer" target="blank"}


```js
// ==UserScript==
// @name         Clip HTML Button
// @description  Copy HTML Directly (runs copy(new XMLSerializer().serializeToString(document)) in dev console)
// @version      2026-06-23
// @match        *://*/*
// @grant        GM_setClipboard
// ==/UserScript==

(function() {
    const btn = document.createElement("button");
    btn.textContent = ".";
    btn.style.cssText = `
        position: fixed;
        bottom: 20px;
        right: 20px;
        z-index: 999999;
        padding: 8px 12px;
        background: #222;
        color: #fff;
        border-radius: 6px;
        cursor: pointer;
        font-size: 14px;
    `;

    btn.onclick = () => {
        const html = new XMLSerializer().serializeToString(document);
        GM_setClipboard(html);
        btn.textContent = "✔ Copied! ( ͡° ͜ʖ ͡°)";
        setTimeout(() => btn.textContent = ".", 1000);
    };

    document.body.appendChild(btn);
})();
```

??? question "What does it do?"
    This physically does the equivalent of running
    ```
    copy(new XMLSerializer().serializeToString(document))
    ```
    in developer console on pages. Nothing more!

    Now, you have a button that instantly copies an open webpage.

    *[button]: (After adding to dashboard) <br> small period `.` — check corner of screen

??? example "winget all extensions for Command Palette"
    Originally just a bloatable "save-time" script instead of hunting through msstore
    ```powershell
    # Winget Only
    winget upgrade --source winget --id Fastfetch-cli.Fastfetch
    winget upgrade --source winget --id Git.Git
    winget upgrade --source winget --id aria2.aria2
    winget upgrade --source winget --id Oven-sh.Bun
    scoop update

    # Powertoys
    --source msstore --id XP89DCGQ3K6VLD

    # Copilot
    --source msstore --id XP9CXNGPPJ97XX

    # Ruby Devkit
    winget install --source winget --id RubyInstallerTeam.RubyWithDevKit.4.0
    # Python
    winget install --source winget --id Python.Python.3.12
    # Cmake
    winget install --source winget --id Kitware.Cmake

    ## Installs:

    ----------winget Managed
    `
    winget install --source winget --id Fastfetch-cli.Fastfetch Git.Git aria2.aria2 Obsidian.Obsidian ZeroTier.ZeroTierOne Symless.Synergy
    `
	    # winget upgrade --source winget ..

    ----------MSStore Managed

    	# Useful packages:
    `
    winget install --source msstore "Sysinternals Suite" "Microsoft Powertoys" "Power Automate" "Powershell Preview" "Terminal Preview" "Tasket++" "TurboType" "Microsoft Sticky Notes"
    `
		    ## MSStore will manage all of these, and the following, in the future with 'Check for Updates'

    	# All Command Palette, (Win+Alt+Space):
    `
    winget install --source msstore "Aria2 Extension for Command Palette" "Scoop Extension for Command Palette" "Snippet Shelf" "Scripter for Command Palette" "Simple Snippet for Command Palette" "Change Case for Command Palette" "Colors for Command Palette" "Dev Numbers for Command Palette" "Errors & Codes for Command Palette" "QR Codes for Command Palette" "Symbols and Emojis for Command Palette" "Unit Converter for Command Palette" "Command Palette - Random Data Generator" "Definition for Command Palette" "Godot Engine for Command Palette"
    `

    	# Optional, for 365 Subscribers (fresh windows installs, non-included 365 programs)
    `
    winget install --source msstore "Microsoft Whiteboard" "Microsoft Designer" "Microsoft To Do: Lists, Tasks & Reminders" "Microsoft Clipchamp"
    `

    ----------

    # Optional, added for completion..
		# Dev - Portable
        `winget search ...`
    	Godot, BCUninstaller, Rufus, 7zip, uv

        # Essential:
        Obsidian, Zerotier, Synergy

        # Portable:
        Godot, BCUninstaller, Rufus, 7zip

        # CLi to get scoop:
        irm get.scoop.sh | iex
    ```

---

# A 'simple snippet' json - for html developer pastes ✍️

- install Powertoys [here (github)](https://github.com/microsoft/PowerToys/tree/main/doc/devdocs){:rel="noopener noreferrer" target="blank"}
- [or here (msstore)](https://apps.microsoft.com/detail/xp89dcgq3k6vld){:rel="noopener noreferrer" target="blank"}
- get SimpleSnippet (`winget install --source msstore Simple Snippet for "Command Palette"`)

Alternatively, just use 'Scripter for Command Palette'. These pastes are useful to have on hand for web-development, though.

`~\AppData\Local\Packages\INGPlay.SimpleSnippetforCommandPalette_fta6ge0ntyrtj\LocalState` :

??? tip "Click to expand `list.json`"
    ```json
    [
      {
        "Id": "cec10ab7-a784-4ba5-8f30-07e094998ae5",
        "Title": "Base64 Clip File PDF",
        "Content": "\u0022data:application/pdf;base64,\u0022 \u002B ([Convert]::ToBase64String([IO.File]::ReadAllBytes(\u0022here\u0022))) | Set-Clipboard",
        "SummaryContent": "\u0022data:application/pdf;base64,\u0022 \u002B ([Convert]::ToBase64String([IO.File]::ReadAllBytes(\u0022here\u0022))) | Set-Clipboard",
        "Type": "Text",
        "Created": "2026-06-23T12:26:13.3280139-04:00",
        "LastUpdated": "2026-06-23T12:26:13.3280153-04:00",
        "LastCopied": "2026-06-23T12:41:09.0724171-04:00"
      },
      {
        "Id": "759de201-1573-41dc-a49c-ec5fbb633835",
        "Title": "Base64 Clip Image JPEG",
        "Content": "\u0022data:image/jpeg;base64,\u0022 \u002B ([Convert]::ToBase64String([IO.File]::ReadAllBytes(\u0022here\u0022))) | Set-Clipboard",
        "SummaryContent": "\u0022data:image/jpeg;base64,\u0022 \u002B ([Convert]::ToBase64String([IO.File]::ReadAllBytes(\u0022here\u0022))) | Set-Clipboard",
        "Type": "Text",
        "Created": "2026-06-23T12:23:53.2158488-04:00",
        "LastUpdated": "2026-06-23T12:23:53.2158504-04:00",
        "LastCopied": "2026-06-23T12:42:02.689572-04:00"
      },
      {
        "Id": "5aa80ee7-070b-4a1d-a4a2-7a4b0c9af599",
        "Title": "Base64 Clip File TXT",
        "Content": "\u0022data:text/plain;base64,\u0022 \u002B ([Convert]::ToBase64String([IO.File]::ReadAllBytes(\u0022here\u0022))) | Set-Clipboard",
        "SummaryContent": "\u0022data:text/plain;base64,\u0022 \u002B ([Convert]::ToBase64String([IO.File]::ReadAllBytes(\u0022here\u0022))) | Set-Clipboard",
        "Type": "Text",
        "Created": "2026-06-23T12:25:21.4238716-04:00",
        "LastUpdated": "2026-06-23T12:25:33.0877896-04:00",
        "LastCopied": "2026-06-23T12:42:26.4575759-04:00"
      },
      {
        "Id": "ad308e38-136e-431a-9f64-ae6486c951aa",
        "Title": "MD5 / SHA Hash (file-path)",
        "Content": "$fp=\u0022file-path\u0022; \u0022SHA256: $((Get-FileHash $fp -Algorithm SHA256).Hash)\u0060nSHA1:   $((Get-FileHash $fp -Algorithm SHA1).Hash)\u0060nMD5:    $((Get-FileHash $fp -Algorithm MD5).Hash)\u0022",
        "SummaryContent": "$fp=\u0022file-path\u0022; \u0022SHA256: $((Get-FileHash $fp -Algorithm SHA256).Hash)\u0060nSHA1:   $((Get-FileHash $fp -Algorithm SHA1).Hash)\u0060nMD5:    $((Get-FileHash $f...",
        "Type": "Text",
        "Created": "2026-06-22T17:24:18.9644226-04:00",
        "LastUpdated": "2026-06-25T22:56:01.9955387-04:00",
        "LastCopied": "2026-06-25T22:55:06.082657-04:00"
      },
      {
        "Id": "5efb9e63-8b0d-4275-949f-535a033759a9",
        "Title": "Base64 Clip Image PNG",
        "Content": "\u0022data:image/png;base64,\u0022 \u002B ([Convert]::ToBase64String([IO.File]::ReadAllBytes(\u0022here\u0022))) | Set-Clipboard",
        "SummaryContent": "\u0022data:image/png;base64,\u0022 \u002B ([Convert]::ToBase64String([IO.File]::ReadAllBytes(\u0022here\u0022))) | Set-Clipboard",
        "Type": "Text",
        "Created": "2026-06-23T12:23:21.8883119-04:00",
        "LastUpdated": "2026-06-23T12:24:09.0320148-04:00",
        "LastCopied": "2026-06-27T22:32:31.1444425-04:00"
      },
      {
        "Id": "f950bc14-1373-457a-9345-44794583c9f3",
        "Title": "HREF (Remove PX Optional For Fill)",
        "Content": "\u003Ca href=\u0022https://example.com\u0022 title=\u0022this is sparta, no, this is thumbnail\u0022\u003E\u003Cimg src=\u0022data:image/png;base64,INSERT\u0022\u00A0alt=\u0022This part is accessibility read by screen readers.\u0022\u00A0style=\u0022max-width:100;width:64px;height:auto;\u0022\u003E\u003C/a\u003E\u003Cbr\u003E\u003Cspan style=\u0022font-size:13px; color:#666;\u0022\u003EFigure 1 \u2014 Example icon description\u003C/span\u003E",
        "SummaryContent": "\u003Ca href=\u0022https://example.com\u0022 title=\u0022this is sparta, no, this is thumbnail\u0022\u003E\u003Cimg src=\u0022data:image/png;base64,INSERT\u0022\u00A0alt=\u0022This part is accessibility re...",
        "Type": "Text",
        "Created": "2026-03-16T11:31:39.1685874-04:00",
        "LastUpdated": "2026-03-16T12:00:47.4763197-04:00",
        "LastCopied": "2026-06-27T22:37:52.5765168-04:00"
      },
      {
        "Id": "00b0c978-e9e8-4884-a7a5-abc07f3fe725",
        "Title": "Image (Remove PX Optional for Fill)",
        "Content": "\u003Cimg src=\u0022data:image/png;base64,\u0022 alt=\u0022ACCESSIBILITY\u0022 style=\u0022max-width:100;width:300px;height:auto;\u0022\u003E\u003Cbr\u003E\u003Cspan style=\u0022font-size:13px; color:#666;\u0022\u003EFigure 1 \u2014 Example icon description\u003C/span\u003E",
        "SummaryContent": "\u003Cimg src=\u0022data:image/png;base64,\u0022 alt=\u0022ACCESSIBILITY\u0022 style=\u0022max-width:100;width:300px;height:auto;\u0022\u003E\u003Cbr\u003E\u003Cspan style=\u0022font-size:13px; color:#666;\u0022\u003EFig...",
        "Type": "Text",
        "Created": "2026-03-16T11:33:33.8719173-04:00",
        "LastUpdated": "2026-03-16T12:00:05.1607765-04:00",
        "LastCopied": "2026-06-27T22:53:33.5916152-04:00"
      }
    ]
    ```

### Related pages:
- [Regedited GitHub Repository](./regedited.md){ data-preview } — Source code and documentation
- [CMD](../xml-project/index.md){ data-preview } — Reproducable format for boolean if-then in C
- [Gemma](./nvfp4.md){ data-preview } — Document on powershell oneliner harnessing a local agent
- [Obsidian](https://obsidian.md/ "a really,<br>really useful tool for Markdown & Charting"){:rel="noopener noreferrer" target="blank"}
- [Notepad++](https://notepad-plus-plus.org/ "The best text editor that ever lived<br>...it even has a diff extension"){:rel="noopener noreferrer" target="blank"}"""

let render() = file
