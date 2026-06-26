module ConvertedFiles.Docs.Projects.AutomateMd

let file = """# Automation

This is a brief technical document on tools used to make automation easier.

In the modern era, there is a number of sources:

- [HTML to Markdown machine](https://app.shel.sh/webclip "JS can become a full routing engine. Used in this standalone webpage. <br> (All conversion happens within single html file)"){:rel="noopener noreferrer" target="blank"}
    - [see: the monkey Sidecar](#a-grep-script "jump to script import")
- [Tasket++](https://github.com/AmirHammouteneEI/ScheduledPasteAndKeys "AmirHammouteneEI/ScheduledPasteAndKeys <br> This is a dev tool written in C++, <br>ported to MSIX (Microsoft store)"){:rel="noopener noreferrer" target="blank"}
    - [see: the macro sidecar](./macrohard.md){ data-preview } - a native http daemon to "harness" tasket
    - and of course, [the UI](https://app.shel.sh/macro "a preview for importing machine code to the sidecar daemon"){:rel="noopener noreferrer" target="blank"}
- [Surfingkeys](https://github.com/brookhong/Surfingkeys "brookhong/Surfingkeys <br> This is a full suite for keyboard surfing in web browsers."){:rel="noopener noreferrer"}
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



### Related pages:
- [Regedited GitHub Repository](./regedited.md){ data-preview } — Source code and documentation
- [CMD](../xml-project/index.md){ data-preview } — Reproducable format for boolean if-then in C
- [Gemma](./nvfp4.md){ data-preview } — Document on powershell oneliner harnessing a local agent
- [Obsidian](https://obsidian.md/ "a really,<br>really useful tool for Markdown & Charting"){:rel="noopener noreferrer" target="blank"}
- [Notepad++](https://notepad-plus-plus.org/ "The best text editor that ever lived<br>...it even has a diff extension"){:rel="noopener noreferrer" target="blank"}"""

let render() = file
