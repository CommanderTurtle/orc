module ConvertedFiles.Docs.XmlProject.IndexMd

let file = """# XML Project

The core technical documentation for sHEL's literal-safe data handling system. This project addresses the fundamental problem of storing and transmitting data that contains `cmd.exe` special characters without triggering unwanted interpretation by the command-line parser.

---

# The original project

```powershell
set "var=["'I am a hater of XML'"]" && echo %var%| clip
<# ["'I am a hater of XML </s>'"] <--- added to clipboard.
```
### What is the use case?
XML can store a large sum of data. This project was initially justified due to being able to consecutively use basic dos shell, clip, and markdown, to store an insane amount of data as an alternative to SQL databasing.
- Why not store a dumb amount of stuff into variables and keep things only in temporary memory, where it's assumed clipboard history is disabled?
clip is powerful. So is echo.

### Here is an example of databasing:
```powershell
set "x=[""]"
set "y=['']"
set "z=["''"]"
set "0aaa=<111somehtml line 1>"
set "0aab=<222somehtml this is line 2>"
set "0aac=<333somehtml with </a> extras>"
```

```powershell
set '0aad=%x:~0,2%%0aaa%%x:~2%'&set '0aae=%x:~0,2%%0aab%%x:~2%'&set '0aaf=%x:~0,2%%0aac%%x:~2%'&set "0aba=%y:~0,2%%0aaa%%y:~2%"&set "0abb=%y:~0,2%%0aab%%y:~2%"&set "0abc=%y:~0,2%%0aac%%y:~2%"&set 0abd=%z:~0,3%%0aaa%%z:~3%&set 0abe=%z:~0,3%%0aab%%z:~3%&set 0abf=%z:~0,3%%0aac%%z:~3%
```
```powershell
<# This is the same as:
set '0aad=%x:~0,2%%0aaa%%x:~2%' <-- Sets ["<html>"] for string searching
set '0aae=%x:~0,2%%0aab%%x:~2%'
set '0aaf=%x:~0,2%%0aac%%x:~2%'
set "0aba=%y:~0,2%%0aaa%%y:~2%" <-- Sets ['<html>'] for delimiting
set "0abb=%y:~0,2%%0aab%%y:~2%"
set "0abc=%y:~0,2%%0aac%%y:~2%"
set 0abd=%z:~0,3%%0aaa%%z:~3% <-- Sets ["'<html>'"] for storage --> (see %0abd:~3,-3% for extracting previous data, and compatibility with all but delimitation)
set 0abe=%z:~0,3%%0aab%%z:~3%
set 0abf=%z:~0,3%%0aac%%z:~3%
#> 
```

### Tokenize, Search, and Run Logic:
```powershell
set "search=for /f "tokens= delims=[" %A in ("") do @for /f "tokens=1 delims=]" %B in ("%A") do @echo %B"
set tok=%search:~0,15%
set aa=%search:~15,19%
set bb=%search:~34%
```
```powershell
%search:~0,15%  [Enter Tokens to Dig]  %search:~15,19%  [Paste Large Block to Delimit nth value]  %search:~34%
# OR:
%tok%  [Enter Tokens to Dig]  %aa%  [Paste Large Block to Delimit nth value]  %bb%
```
??? question "Example" 
    Searching for second list item (tok=3 == item 2):
    ```powershell
    %tok%3%aa%(echo ['<jibberish 1>']&echo ['<wtf ! /2>']&echo ['69 86 <64????/> <third value>']&echo ['249 86 64 ^*!?<this is the fourth line, etc.></a>'])| clip%bb%
    ```
    this prints: `['<wtf ! /2>']`
    !!! note
        - +1 needs to be added to the search. 0 returns nothing. 1 returns everything prior to the list. tok=2 returns first. tok=3 returns second, etc.
        - Secondly, x and z format work for simple lists but have limitations. y formatting [''] works all the time, but lacks searchable strings.

??? example "Searchable strings"
    === ":octicons-mark-github-16: Searching for '3'"
        ```powershell
        (echo ["'<somehtml>'"]&echo ["'"%date%,%time:~0,8%"... is actually the time <testhtml>'"]&echo ["'<somehtml> #3'"]) | findstr "3"
        ```
        prints `["'<somehtml> #3'"]`
    === ":fontawesome-brands-font-awesome: Searching for 'time'"
        ```powershell
        (echo ["'<somehtml>'"]&echo ["'"%date%,%time:~0,8%"... is actually the time <testhtml>'"]&echo ["'<somehtml> #3'"]) | findstr "time"
        ```
        prints `["'"%date%,%time:~0,8%"... is actually the time <testhtml>'"]`
        !!! success "Note"
            This only works for long echo strings, and usually fails if searching a piped or mega-one-liner clip command.

??? example "Boolean cmd — Click to Expand"
    Now that we have the basics, why not add if/then functionality to dos shell by being clever?
    ```powershell
    echo "text to search" | find /I "needle" >nul && echo true || echo false
    ```
    Removing `/I` allows for a case-sensitive variant.
    Now, run all the macros you like!
    We can paste a large multi-line list with clip, 
    search a string out of it, 
    if it exists, pipe to clip something else. 

    Possibility when running macros? Run a dummy "about:blank" paste instead of a URL if something is not found, 
    then, add to clipboard large, multiline table that is markdown friendly (containing html elements) — your database.

    ```powershell
    echo "text to search" | find /I "needle" >nul && (echo Great Success! & (echo ["| <a href="https://example.com" title="this is sparta, no, this is a generic T icon"><img src="data:image/png;  base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACpUlEQVR4nGxTz0tVQRg937z79Hnx0SLNcvEMXBRFq4x+UEKE9EsXbWoR/XLxKqhFEfUHtMpthSiBYUG0kqiNKBFqmBBBWtSiLF9l+CsR7Jm+e+frzL2KL2gud+bemXPOfN+Z   +TywKSASDewuYh+Hc/yp52RGA/ 4tIMfvPqxBh9xGfzFHsNy0Cb7NoMWIZJE0SVgDFBRakYFsPQhMjADvBwrw0I4crstT5B1PnNLEKfjr0uiSMjRw2uoiLEIkUODi5fuwu8643QK5e8jgY7dRJHom58JjVQ+Q91wYYTluiU/yHJaQTnvY0ehJ9TZVy/    j5mqFO1Z2nPWw5bDHUvSTrpaEyJAe4JHoeu5GUPoYrqN4k9uqAkfKKyBCJc41GCRZVWxtFhnstUi5wVUZY71lB1njMrIAAGhjz9ZXq4EORzfuBPc2QzrOA58P+GhXz7rmilHpWLZLwGFyWntH1gGoejP78LHqnSbT3MZCfgVJZh7uA35OQk/    egR66J5imQSBh6pI7rBDK0TKKXeClJQvwEd03FodfyVC88cU4BP0YgxMDaGE+ut5Kj6+KcNQYzyuikZ74AH3qhn17AvOwGKikehMskwBCfi/pVympjZkhXMSwDGXsDLTdMn2Y7vIn2yhli  +nnijmeNm1LVmL0stXYjpCwNzH6DGKvGrTMJx3FcQ1I7DQmijFB8ehon9JYmTjONuhPKK+0M1AhLjuMaacOgDdGGFDXVCYmFg2jI3sAcvanYfhyYnyKZOyurg1jHcVzjrvLUPG7oH/    TARwkoLSkKvX5E0rTqgSuis98VI88cESgNSxw24hR7Np6FvyGJFn6ymPgsMIGqWqCmDjLKApwdd5YXLMOeYDFVrxTT/8qZoGaTkL283jWuoCg3xgrt5/l3SOu/5fwXAAD//5rxYZkAAAAGSURBVAMAkjI5uqP0pJcAAAAASUVORK5CYII=" alt="An     image on the screen displays a generic 'T', This part is read by accessibilty screen readers" style="width:24px;height:24px;"></a><br><span style="font-size:13px; color:#666;">Figure 1 —  Example icon footer</span> | Test | Three |"]&echo ["|---|---|---|"]&echo ["| aaa | bbb | ccc |"]&echo ["| ddd | eee | fff |"]&echo ["#### Example title"])| clip) || (set "var=This element     does not exist" & echo %var% & echo %var%| clip)
    ```
    Adds the following to clipboard... (renderable as markdown plaintext, delimited with `["` and `"]` due to html elements—find and replace these easily).

    ---
    | <a href="https://example.com" title="this is sparta, no, this is a generic T icon set to 32px"><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/ 9hAAACpUlEQVR4nGxTz0tVQRg937z79Hnx0SLNcvEMXBRFq4x+UEKE9EsXbWoR/XLxKqhFEfUHtMpthSiBYUG0kqiNKBFqmBBBWtSiLF9l+CsR7Jm+e+frzL2KL2gud+bemXPOfN+Z+TywKSASDewuYh+Hc/yp52RGA/     4tIMfvPqxBh9xGfzFHsNy0Cb7NoMWIZJE0SVgDFBRakYFsPQhMjADvBwrw0I4crstT5B1PnNLEKfjr0uiSMjRw2uoiLEIkUODi5fuwu8643QK5e8jgY7dRJHom58JjVQ+Q91wYYTluiU/yHJaQTnvY0ehJ9TZVy/    j5mqFO1Z2nPWw5bDHUvSTrpaEyJAe4JHoeu5GUPoYrqN4k9uqAkfKKyBCJc41GCRZVWxtFhnstUi5wVUZY71lB1njMrIAAGhjz9ZXq4EORzfuBPc2QzrOA58P+GhXz7rmilHpWLZLwGFyWntH1gGoejP78LHqnSbT3MZCfgVJZh7uA35OQk/    egR66J5imQSBh6pI7rBDK0TKKXeClJQvwEd03FodfyVC88cU4BP0YgxMDaGE+ut5Kj6+KcNQYzyuikZ74AH3qhn17AvOwGKikehMskwBCfi/pVympjZkhXMSwDGXsDLTdMn2Y7vIn2yhli  +nnijmeNm1LVmL0stXYjpCwNzH6DGKvGrTMJx3FcQ1I7DQmijFB8ehon9JYmTjONuhPKK+0M1AhLjuMaacOgDdGGFDXVCYmFg2jI3sAcvanYfhyYnyKZOyurg1jHcVzjrvLUPG7oH/    TARwkoLSkKvX5E0rTqgSuis98VI88cESgNSxw24hR7Np6FvyGJFn6ymPgsMIGqWqCmDjLKApwdd5YXLMOeYDFVrxTT/8qZoGaTkL283jWuoCg3xgrt5/l3SOu/5fwXAAD//5rxYZkAAAAGSURBVAMAkjI5uqP0pJcAAAAASUVORK5CYII=" alt="An     image on the screen displays a generic 'T', This part is read by accessibilty screen readers" style="width:32px;height:32px;"></a><br><span style="font-size:13px; color:#666;">Figure 1 -  Example icon footer</span> | Test | Three |
    |---|---|---|
    | aaa | bbb | ccc |
    | ddd | eee | fff |
    
    #### Example title
    `blank line`
    
    ---
    
    
    If there is no needle. The command prints and clips custom text. Note, `echo off | clip` will clear the clipboard.
    
    Here is a plaintext rendering of the output after removing delimiters:
    
    ```plain
    | <html blob> | Test | Three |
    |---|---|---|
    | aaa | bbb | ccc |
    | ddd | eee | fff |
    #### Example title
    [Blank Line] <--- 
    ```

---

## A reproducable structure (step-by-step):

Set your database:
```powershell
set "x=[""]"
set "y=['']"
set "z=["''"]"
set "0aaa=Title: Task 1 DB: My Datasheet"
set "0aab=| Index | TodoCount | ThinkCount | TermCount | PyCount | BufferVar |"
set "0aac=|-|-|-|-|-|-|"
set "0aad=| 1aaa # | 0aaa # | 0aab # | 0aac # | 0aad # | 0aae # |"
```
One line variant:
```powershell
set "x=[""]"&set "y=['']"&set "z=["''"]"&set "0aaa=Title: Task 1 DB: My Datasheet"&set "0aab=| Index | TodoCount | ThinkCount | TermCount | PyCount | BufferVar |"&set "0aac=|-|-|-|-|-|-|"&set "0aad=| 1aaa # | 0aaa # | 0aab # | 0aac # | 0aad # | 0aae # |"
```
Append to structure (X,Y,Z):
```powershell
set 0aba=%x:~0,2%%0aaa%%x:~2%&set 0abb=%x:~0,2%%0aab%%x:~2%&set 0abc=%x:~0,2%%0aac%%x:~2%&set 0abd=%x:~0,2%%0aad%%x:~2%&set "0aca=%y:~0,2%%0aaa%%y:~2%"&set "0acb=%y:~0,2%%0aab%%y:~2%"&set "0acc=%y:~0,2%%0aac%%y:~2%"&set "0acd=%y:~0,2%%0aad%%y:~2%"&set 0ada=%z:~0,3%%0aaa%%z:~3%&set 0adb=%z:~0,3%%0aab%%z:~3%&set 0adc=%z:~0,3%%0aac%%z:~3%&set 0add=%z:~0,3%%0aad%%z:~3%
```
Optionally, build a second database:
```powershell
set "0baa=Title: Task 1 DB: My Second Datasheet"
set "0bab=| Index | TodoCount | ThinkCount | TermCount | PyCount | BufferVar |"
set "0bac=|-|-|-|-|-|-|"
set "0bad=| 1aaa # | 0aaa # | 0aab # | 0aac # | 0aad # | 0aae # |"
```
One line variant:
```powershell
set "0baa=Title: Task 1 DB: My Second Datasheet"&set "0bab=| Index | TodoCount | ThinkCount | TermCount | PyCount | BufferVar |"&set "0bac=|-|-|-|-|-|-|"&set "0bad=| 1aaa # | 0aaa # | 0aab # | 0aac # | 0aad # | 0aae # |"
```
Append to structure:
```powershell
set '0bba=%x:~0,2%%0baa%%x:~2%'&set '0bbb=%x:~0,2%%0bab%%x:~2%'&set '0bbc=%x:~0,2%%0bac%%x:~2%'&set '0bbd=%x:~0,2%%0bad%%x:~2%'&set "0bca=%y:~0,2%%0baa%%y:~2%"&set "0bcb=%y:~0,2%%0bab%%y:~2%"&set "0bcc=%y:~0,2%%0bac%%y:~2%"&set "0bcd=%y:~0,2%%0bad%%y:~2%"&set 0bda=%z:~0,3%%0baa%%z:~3%&set 0bdb=%z:~0,3%%0bab%%z:~3%&set 0bdc=%z:~0,3%%0bac%%z:~3%&set 0bdd=%z:~0,3%%0bad%%z:~3%
```

??? tip "Expand to show — “What you just did”"

    === ":octicons-mark-github-16: (High level overview)"

        ``` powershell
        set 0bba=%x:~0,2%%0baa%%x:~2% # <-- Sets ["<html>"] for string searching
        set 0bbb=%x:~0,2%%0bab%%x:~2%
        set 0bbc=%x:~0,2%%0bac%%x:~2%
        set 0bbd=%x:~0,2%%0bad%%x:~2%
        set "0bca=%y:~0,2%%0baa%%y:~2%" # <-- Sets ['<html>'] for delimiting
        set "0bcb=%y:~0,2%%0bab%%y:~2%" # <-- c can always be piped to clip
        set "0bcc=%y:~0,2%%0bac%%y:~2%"
        set "0bcd=%y:~0,2%%0bad%%y:~2%" # <-- c can be nested echo " " --> See: # echo "(echo %0aca%&echo %0acb%&echo%0acc%&echo%0acd%)"
        set 0bda=%z:~0,3%%0baa%%z:~3% # <-- Sets ["'<html>'"] for storage --> %0abd:~3,-3% for extracting previous data, and compatibility with   all but delimitation)
        set 0bdb=%z:~0,3%%0bab%%z:~3%
        set 0bdc=%z:~0,3%%0bac%%z:~3%  # <-- d can be nested echo "" "" (See: echo ""(echo %0bba%&echo %0bbb%&echo%0bbc%&echo%0bbd%)""
        set 0bdd=%z:~0,3%%0bad%%z:~3%  # <-- d by itself can be piped to findstr (See: (echo %0bda%&echo %0bdb%&echo%0bdc%&echo%0bdd%) | findstr  "index"
        ...
        (echo %0bba%&echo %0bbb%&echo%0bbc%&echo%0bbd%)| clip
        (echo %0bca%&echo %0bcb%&echo%0bcc%&echo%0bcd%)| clip
        (echo %0bda%&echo %0bdb%&echo%0bdc%&echo%0bdd%)| clip
        ```


    === ":fontawesome-brands-font-awesome: a better understanding with A..."

        ``` powershell
        set 0aba=%x:~0,2%%0aaa%%x:~2% # <-- Sets ["<html>"] for string searching
        set 0abb=%x:~0,2%%0aab%%x:~2%
        set 0abc=%x:~0,2%%0aac%%x:~2% # <-- b can be nested echo "" "" (See: echo ""(echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)"" # <-- will  expand (4 lines will be echoed), encapsulated in double quote ""<start ---- end>""
        set 0abd=%x:~0,2%%0aad%%x:~2%
        set "0aca=%y:~0,2%%0aaa%%y:~2%" # <-- Sets ['<html>'] for delimiting
        set "0acb=%y:~0,2%%0aab%%y:~2%" # <-- c can be delimited (walked), but sometimes has string issues.
        set "0acc=%y:~0,2%%0aac%%y:~2%" # <-- c can be nested echo " " --> See: # echo "(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)" # <--    will be echoed as a single oneliner block. Compresses html to single line string.
        set "0acd=%y:~0,2%%0aad%%y:~2%"
        set 0ada=%z:~0,3%%0aaa%%z:~3% # <-- Sets ["'<html>'"] for storage --> %0abd:~3,-3% for extracting previous data, and compatibility with   all but delimitation)
        set 0adb=%z:~0,3%%0aab%%z:~3%  # <-- d by itself is almost always safe, but b is better.. (See: (echo %0ada%&echo %0adb%&echo %0adc%&echo     %0add%) | findstr "index"
        set 0adc=%z:~0,3%%0aac%%z:~3%  # <-- d can be nested echo "" "" (See: echo ""(echo %0ada%&echo %0adb%&echo %0adc%&echo %0add%)"" # <-- will     expand (4 lines will be echoed), encapsulated in double quote ""<start ---- end>""
        set 0add=%z:~0,3%%0aad%%z:~3%  
        ...
        (echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%) # <--almost always perfect, cant delimit
        (echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%) # <--almost always perfect, can't echo
        (echo %0ada%&echo %0adb%&echo %0adc%&echo %0add%) # <--almost always perfect, can't delimit
        ```

---
Create delimit function:
```powershell
set "search=for /f "tokens= delims=[" %A in ("") do @for /f "tokens=1 delims=]" %B in ("%A") do @echo [%B] && @set "code=%B" && @set "cbuf=[%B]" && @set dbuf=["%B"] && @echo ["%B"]| clip"
```
Set p:
```powershell
set "p=%"
```
Make grabbing b possible:
```powershell
set "grabb=echo ["%p%code:~1,-1%p%"]| clip && @echo ["%p%code:~1,-1%p%"]| for /f "delims=" %A in ('more') do @set "bbuf=%A""
```
Tokenize parts of the command:
```powershell
set tok=%search:~0,15%
```
```powershell
set aa=%search:~15,19%
```
```powershell
set bb=%search:~34%
```
??? question "Example" 

    ```powershell
    %tok%5%aa%(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)| clip%bb%
    ```
    ```powershell
    %grabb%
    ```
    !!! success "This works with c"
        `b and d cannot delimit due to strings`

??? tip "Expand to show — “Why do this?”"

    === ":octicons-mark-github-16: (High level overview)"

        ``` powershell
        # Default: Just echo 'result':
        set "search=for /f "tokens= delims=[" %A in ("") do @for /f "tokens=1 delims=]" %B in ("%A") do @echo %B"

        # v2.0: Just perform echo of compat(d), store diggable(c), as well as store/clip compat(d) :
        set "search=for /f "tokens= delims=[" %A in ("") do @for /f "tokens=1 delims=]" %B in ("%A") do @echo [%B] && @set "code=%B" && @set "cbuf=[%B]" && @set dbuf=["%B"] && @echo ["%B"]| clip"
        # Bonus :
        set "p=%"
        set "grabb=echo ["%p%code:~1,-1%p%"]| clip && @echo ["%p%code:~1,-1%p%"]| for /f "delims=" %A in ('more') do @set "bbuf=%A""
        <#
        Now running %grabb% adds searchable(b) to library.
        Now we have:
        bbuf = ["result"]
        cbuf = ['result']
        dbuf = ["'result'"]
        clipboard = ["result"] --> or ["'result'"] if %bbuf% is never run to grab (b).
        #>
        ```

    === ":fontawesome-brands-font-awesome: The Commands"

        ``` powershell

        # "Search" :

        for /f "tokens= delims=[" %A in ("") do @for /f "tokens=1 delims=]" %B in ("%A") do @echo [%B] && @set "code=%B" && @set "cbuf=[%B]" && @set dbuf=["%B"] && @echo ["%B"]| clip

        # "B Extraction" :
        
        echo ["%p%code:~1,-1%p%"]| clip && @echo ["%p%code:~1,-1%p%"]| for /f "delims=" %A in ('more') do @set "bbuf=%A"
        ```

    === ":fontawesome-solid-flask: How to Dig"

        ```powershell
        %tok%  [Enter Tokens to Dig]  %aa%  [Paste Large Block to Delimit nth value]  %bb%

        #Generic Example: <-- Prints and clips delimitation (in this case, second value) <-- bbuf grabs and saves extra buffer zone
        #For cmdlet oneliner : (echo ['<jibberish 1>']&echo ['<wtf ! /2>']&echo ['69 86 <64????/> <third value>']&echo ['249 86 64 ^*!?<this is the fourth line, etc.></a>'])| clip
        #Run :
        %tok%3%aa%_______%bb%
        %bbuf%
        #Like:
        %tok%3%aa%(echo ['<jibberish 1>']&echo ['<wtf ! /2>']&echo ['69 86 <64????/> <third value>']&echo ['249 86 64 ^*!?<this is the fourth line, etc.></a>'])| clip%bb%
        %grabb%
        <#
        Prints (tok=3 : 2nd delimitation):
        ['<wtf ! /2>']
        Stores:
        ["<wtf ! /2>"]   <-- %bbuf%
        ['<wtf ! /2>']   <-- %cbuf%
        ["'<wtf ! /2>'"] <-- %dbuf%

        ["<wtf ! /2>"]   <-- clipboard (b) after %grabb% , else clipboard is temporarily %dbuf%


        Working Example: <-- Delimits 4th line of html (**normally un-echoable!**)#>

        #A:
        %tok%5%aa%(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)| clip%bb%
        #B:
        %tok%5%aa%(echo %0bca%&echo %0bcb%&echo %0bcc%&echo %0bcd%)| clip%bb%
        ```

Create search function:
```powershell
() | findstr /I ""
```
It's not worthwhile to save, since it's not a hard command
```powershell
( [ Echo to Search ] ) | findstr /I "text"
```
??? question "Example" 

    ```powershell
    # From the first database:
    (echo %0ada%&echo %0adb%&echo %0adc%&echo %0add%) | findstr /I "aaa"
    (echo %0ada%&echo %0adb%&echo %0adc%&echo %0add%) | findstr "aaa"
    ```
    ```powershell
    # From the second database
    (echo %0bda%&echo %0bdb%&echo %0bdc%&echo %0bdd%) | findstr /I "aaa"
    (echo %0bda%&echo %0bdb%&echo %0bdc%&echo %0bdd%) | findstr "aaa"
    ```
    !!! success "This works with (b/d)"
        `c has serious issues`

??? tip "Expand to show — “Why do this?”"

    === ":octicons-mark-github-16: (High level overview)"

        ``` powershell
        # How to Search (b/d):
        ( [ Echo to Search ] ) | findstr /I "text" <-- /I is case insensitive :

        () | findstr /I ""
        () | findstr ""

        # Generic Example:
        (echo ["'<somehtml>'"]&echo ["'"%date%,%time:~0,8%"... is actually the time <testhtml>'"]&echo ["'<somehtml> #3'"]) | findstr "3"

        # Generic Example 2 -> pipes to clip:
        ((echo ["'<somehtml>'"]&echo ["'"%date%,%time:~0,8%"... is actually the time <testhtml>'"]&echo ["'<somehtml> #3'"]) | findstr "3")| clip
        ```

    === ":fontawesome-brands-font-awesome: The Commands"

        ``` powershell

        # Case in-sensitive :

        () | findstr /I ""

        # Case sensitive :

        () | findstr ""

        # Clip it (case in-sensitive) :

        (() | findstr /I "")| clip
        ```

Create booling function:
```powershell
set "bool=echo "" | find /I "needle" >nul && (echo Great Success! & ()| clip) || (set "buffer=about:blank" & echo This element does not exist! & echo %buffer%| clip)"
```
Create if/then/else :
``` powershell
set aif=%bool:~0,6%
```
``` powershell
set ahas=%bool:~6,13%
```
``` powershell
set "ahas0=%bool:~7,12%"
```
``` powershell
set athen=%bool:~25,33%
```
``` powershell
set "cc=%bool:~60,17%"
```
``` powershell
set "cc0=%bool:~66,11%"
```
``` powershell
set "cc1=%bool:~60,16%"
```
``` powershell
set "cc2=%bool:~66,10%"
```
``` powershell
set dd=%bool:~95,40%
```
``` powershell
set dd0=%bool:~96,39%
```
``` powershell
set "ee=%bool:~-7%"
```

??? tip "Expand to show — “What you just did”"

    === ":octicons-mark-github-16: (High level overview)"

        ``` powershell

        # "if (it has this) then print ..., else print ..."

        %aif% [ Text to Search ] %ahas% [ needle ] %athen% [ echo to clip ] %cc% [ foo=anything ] %dd% [ (custom error clip) ] %ee%

        %aif%_______%ahas%_______%athen%(echo trueclip)%cc%buffer=error%dd%(echo falseclip)%ee%
        ```
        


    === ":fontawesome-brands-font-awesome: a full understanding?"

        ``` powershell
        # Debug is shown on the right. (Echo partial commands safely)
        # i.e. echo "%aif%" for echoing the command { <-- " "} vs { <-- "" ""}
        set aif=%bool:~0,6%	<-- " "
        (6-19th)
        set ahas=%bool:~6,13% <-- "" "" <-- i.e: echo ""%ahas%""
        set "ahas0=%bool:~7,12%" <-- " "
        (25-58th)
        set athen=%bool:~25,33% <-- "" ""
        (60-77th)
        # Else: choose buffer..
        set "cc=%bool:~60,17%"	<-- " " (inside) # always clipped
        set "cc0=%bool:~66,11%" <-- " " (inside)| clip # use for custom pipe (success)
        set "cc1=%bool:~60,16%" <-- " " # (used for non-string buffers)
        set "cc2=%bool:~66,10%" <-- " " # (used for non-string buffers)
        (95-135th) (ee is literally just "| clip") <-- # leave out for custom pipe (fail)
        # Else
        set dd=%bool:~95,40% 	<-- "" ""
        # "Else" modified for non-string buffers
        set dd0=%bool:~96,39%	<-- " "
        # and copy with ee.. (within is paste as failure pipe)
        set "ee=%bool:~-7%" 	<-- " "
        ```
    
    === ":fontawesome-solid-flask: a visual of the function"

        ``` powershell
        <#   %bool%   --> #>echo "" | find /I "needle" >nul && (echo Great Success! & ()| clip) || (set "buffer=about:blank" & echo This element does not exist! & echo %buffer%| clip)
        #    echo "...
        set aif=%bool:~0,6%
        # ..." | find /I "...
        set ahas=%bool:~6,13%
        # ... | find /I "...
        set "ahas0=%bool:~7,12%"
        # ..." >nul && (echo Great Success! & ...
        set athen=%bool:~25,33%
        # ...| clip) || (set "...
        set "cc=%bool:~60,17%"
        # ...) || (set "...
        set "cc0=%bool:~66,11%"
        # ...| clip) || (set ...
        set "cc1=%bool:~60,16%"
        # ...) || (set ...
        set "cc2=%bool:~66,10%"
        # ..." & echo This element does not exist! & ...
        set dd=%bool:~95,40%
        # ... & echo This element does not exist! & ...
        set "dd0=%bool:~96,39%"
        # ...| clip)
        set "ee=%bool:~-7%"
        ```
    
    === ":fontawesome-solid-circle-info: more detail?"

        ```powershell
        <#   %bool%   --> #>echo "" | find /I "needle" >nul && (echo Great Success! & ()| clip) || (set "buffer=about:blank" & echo This element does not exist! & echo %buffer%| clip)
        #    echo "...
        %aif%this thing...%ahas%this specific text...
        # ..." | find /I "...
        echo "this specific element%ahas0%        "<------ahas0 completes a quote, too
        # ... | find /I "...
        echo "this specific element"%ahas%
        # ..." >nul && (echo Great Success! & ...
        ...%ahas/ahas0%the text im searching!!!%athen%
        # ...| clip) || (set "...
        ...%athen%(echo "I've found it!")%cc% #(clips it)
        # ...) || (set "...
        ...%athen%(echo "I've found it!")| clip%cc0% # or, clip it manually / allows to run some loop
        #
        #
        #
        #
        # ..." & echo This element does not exist! & ...
        ...%cc/cc0%myerrorvar=true%dd%(echo "my clipboard failure line (#1)"&echo "line2"...))
        # ... & echo This element does not exist! & ...
        ...%c1/cc2%/a count+=1%dd0%(echo my special counter can be found typing "%p%count%p%"))
        # ...| clip) <---literal clip pipe, optional:
        ...%cc/cc0%myerrorvar=true%dd%(echo "my clipboard failure line (#1)"&echo "line2"...)%ee%
        ```


    === ":fontawesome-solid-skull: advanced purpose"

        We must truly understand those nested echo rules..

        b can be nested echo `"" ""` See: 
        ```powershell
        echo ""(echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)""
        ```
        This will expand (4 lines will be echoed), encapsulated in double quote `""<start ---- end>""`

        But what about c?

        c can be nested echo " " See: 
        ```powershell
        echo "(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)" 
        ```
        It behaves THE OPPOSITE. This will be echoed as a single oneliner block. 
        
        This compresses html to single line string.

        now it makes sense... understanding "d is almost always perfect, cant delimit" ...

        There is nothing to delimit...

        So now... ahas and ahas0 have clear purpose!

        c must use `%aif%-INNER-%ahas%` :
        ```powershell
        %aif%(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)%ahas%sometext%athen%echo trueclip%cc%buffer=bufferran%dd%(echo falseclip)%ee%
        ```
        b/d must use `INNER-%ahas0%` :
        ```powershell
        # B:

        (echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)%ahas0%sometext%athen%echo trueclip%cc%buffer=bufferran%dd%(echo falseclip)%ee%
        
        # D:

        (echo %0ada%&echo %0adb%&echo %0adc%&echo %0add%)%ahas0%sometext%athen%echo trueclip%cc%buffer=bufferran%dd%(echo falseclip)%ee%
        ```
        ??? ":fontawesome-solid-flask: at a glance"
            With nested echos for b/d, there is one key "weirdness" we solve :
            ```powershell
            (echo (echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%))%ahas0%aaa%athen%echo trueclip%cc%buffer=bufferran%dd%(echo falseclip)%ee%
            ```
            ...works, however, not just are all lines are physically echoed. Only the final one is searched (%0abd%)
            
            therefore, it is cannon for b/d to cut out that first echo
            
            `INNER-%ahas0%`
        
        So what are the final commands?

        Just one.
        
        Search database for any specific (all lines)
        ```powershell
        %aif%(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)%ahas%
        ```
        You must use c for input. b for output.
        ??? success "Original Example"
            ``` powershell
            echo "text to search" | find /I "needle" >nul && (echo Great Success! & (echo ["| <a href="https://example.com" title="this is sparta, no, this is a generic T icon"><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACpUlEQVR4nGxTz0tVQRg937z79Hnx0SLNcvEMXBRFq4x+UEKE9EsXbWoR/XLxKqhFEfUHtMpthSiBYUG0kqiNKBFqmBBBWtSiLF9l+CsR7Jm+e+frzL2KL2gud+bemXPOfN+Z+TywKSASDewuYh+Hc/yp52RGA/ 4tIMfvPqxBh9xGfzFHsNy0Cb7NoMWIZJE0SVgDFBRakYFsPQhMjADvBwrw0I4crstT5B1PnNLEKfjr0uiSMjRw2uoiLEIkUODi5fuwu8643QK5e8jgY7dRJHom58JjVQ+Q91wYYTluiU/yHJaQTnvY0ehJ9TZVy/j5mqFO1Z2nPWw5bDHUvSTrpaEyJAe4JHoeu5GUPoYrqN4k9uqAkfKKyBCJc41GCRZVWxtFhnstUi5wVUZY71lB1njMrIAAGhjz9ZXq4EORzfuBPc2QzrOA58P+GhXz7rmilHpWLZLwGFyWntH1gGoejP78LHqnSbT3MZCfgVJZh7uA35OQk/egR66J5imQSBh6pI7rBDK0TKKXeClJQvwEd03FodfyVC88cU4BP0YgxMDaGE+ut5Kj6+KcNQYzyuikZ74AH3qhn17AvOwGKikehMskwBCfi/pVympjZkhXMSwDGXsDLTdMn2Y7vIn2yhli+nnijmeNm1LVmL0stXYjpCwNzH6DGKvGrTMJx3FcQ1I7DQmijFB8ehon9JYmTjONuhPKK+0M1AhLjuMaacOgDdGGFDXVCYmFg2jI3sAcvanYfhyYnyKZOyurg1jHcVzjrvLUPG7oH/TARwkoLSkKvX5E0rTqgSuis98VI88cESgNSxw24hR7Np6FvyGJFn6ymPgsMIGqWqCmDjLKApwdd5YXLMOeYDFVrxTT/8qZoGaTkL283jWuoCg3xgrt5/l3SOu/5fwXAAD//5rxYZkAAAAGSURBVAMAkjI5uqP0pJcAAAAASUVORK5CYII=" alt="An image on the screen displays a generic 'T', This part is read by accessibilty screen readers" style="width:24px;height:24px;"></a><br><span style="font-size:13px; color:#666;">Figure 1 — Example icon footer</span> | Test | Three |"]&echo ["|---|---|---|"]&echo ["| aaa | bbb | ccc |"]&echo ["| ddd | eee | fff |"]&echo ["#### Holy guacamole"])| clip) || (set "buffer=about:blank" & echo This element does not exist! & echo %buffer%| clip)
            ```
            Try it in the database:
            ```powershell
            set "0aaa=| <a href="https://example.com" title="this is sparta, no, this is a generic T icon"><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACpUlEQVR4nGxTz0tVQRg937z79Hnx0SLNcvEMXBRFq4x+UEKE9EsXbWoR/XLxKqhFEfUHtMpthSiBYUG0kqiNKBFqmBBBWtSiLF9l+CsR7Jm+e+frzL2KL2gud+bemXPOfN+Z+TywKSASDewuYh+Hc/yp52RGA/ 4tIMfvPqxBh9xGfzFHsNy0Cb7NoMWIZJE0SVgDFBRakYFsPQhMjADvBwrw0I4crstT5B1PnNLEKfjr0uiSMjRw2uoiLEIkUODi5fuwu8643QK5e8jgY7dRJHom58JjVQ+Q91wYYTluiU/yHJaQTnvY0ehJ9TZVy/j5mqFO1Z2nPWw5bDHUvSTrpaEyJAe4JHoeu5GUPoYrqN4k9uqAkfKKyBCJc41GCRZVWxtFhnstUi5wVUZY71lB1njMrIAAGhjz9ZXq4EORzfuBPc2QzrOA58P+GhXz7rmilHpWLZLwGFyWntH1gGoejP78LHqnSbT3MZCfgVJZh7uA35OQk/egR66J5imQSBh6pI7rBDK0TKKXeClJQvwEd03FodfyVC88cU4BP0YgxMDaGE+ut5Kj6+KcNQYzyuikZ74AH3qhn17AvOwGKikehMskwBCfi/pVympjZkhXMSwDGXsDLTdMn2Y7vIn2yhli+nnijmeNm1LVmL0stXYjpCwNzH6DGKvGrTMJx3FcQ1I7DQmijFB8ehon9JYmTjONuhPKK+0M1AhLjuMaacOgDdGGFDXVCYmFg2jI3sAcvanYfhyYnyKZOyurg1jHcVzjrvLUPG7oH/TARwkoLSkKvX5E0rTqgSuis98VI88cESgNSxw24hR7Np6FvyGJFn6ymPgsMIGqWqCmDjLKApwdd5YXLMOeYDFVrxTT/8qZoGaTkL283jWuoCg3xgrt5/l3SOu/5fwXAAD//5rxYZkAAAAGSURBVAMAkjI5uqP0pJcAAAAASUVORK5CYII=" alt="An image on the screen displays a generic 'T', This part is read by accessibilty screen readers" style="width:24px;height:24px;"></a><br><span style="font-size:13px; color:#666;">Figure 1 — Example icon footer</span> | Test | Three |"
            set "0aab=|---|---|---|"
            set "0aac=|-|-|-|-|-|-|"
            set "0aad=| aaa | bbb | ccc |"
            ```
            One line copy:
            ```powershell
            set "0aaa=| <a href="https://example.com" title="this is sparta, no, this is a generic T icon"><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACpUlEQVR4nGxTz0tVQRg937z79Hnx0SLNcvEMXBRFq4x+UEKE9EsXbWoR/XLxKqhFEfUHtMpthSiBYUG0kqiNKBFqmBBBWtSiLF9l+CsR7Jm+e+frzL2KL2gud+bemXPOfN+Z+TywKSASDewuYh+Hc/yp52RGA/ 4tIMfvPqxBh9xGfzFHsNy0Cb7NoMWIZJE0SVgDFBRakYFsPQhMjADvBwrw0I4crstT5B1PnNLEKfjr0uiSMjRw2uoiLEIkUODi5fuwu8643QK5e8jgY7dRJHom58JjVQ+Q91wYYTluiU/yHJaQTnvY0ehJ9TZVy/j5mqFO1Z2nPWw5bDHUvSTrpaEyJAe4JHoeu5GUPoYrqN4k9uqAkfKKyBCJc41GCRZVWxtFhnstUi5wVUZY71lB1njMrIAAGhjz9ZXq4EORzfuBPc2QzrOA58P+GhXz7rmilHpWLZLwGFyWntH1gGoejP78LHqnSbT3MZCfgVJZh7uA35OQk/egR66J5imQSBh6pI7rBDK0TKKXeClJQvwEd03FodfyVC88cU4BP0YgxMDaGE+ut5Kj6+KcNQYzyuikZ74AH3qhn17AvOwGKikehMskwBCfi/pVympjZkhXMSwDGXsDLTdMn2Y7vIn2yhli+nnijmeNm1LVmL0stXYjpCwNzH6DGKvGrTMJx3FcQ1I7DQmijFB8ehon9JYmTjONuhPKK+0M1AhLjuMaacOgDdGGFDXVCYmFg2jI3sAcvanYfhyYnyKZOyurg1jHcVzjrvLUPG7oH/TARwkoLSkKvX5E0rTqgSuis98VI88cESgNSxw24hR7Np6FvyGJFn6ymPgsMIGqWqCmDjLKApwdd5YXLMOeYDFVrxTT/8qZoGaTkL283jWuoCg3xgrt5/l3SOu/5fwXAAD//5rxYZkAAAAGSURBVAMAkjI5uqP0pJcAAAAASUVORK5CYII=" alt="An image on the screen displays a generic 'T', This part is read by accessibilty screen readers" style="width:24px;height:24px;"></a><br><span style="font-size:13px; color:#666;">Figure 1 — Example icon footer</span> | Test | Three |"&set "0aab=|---|---|---|"&set "0aac=|-|-|-|-|-|-|"&set "0aad=| aaa | bbb | ccc |"
            ```
            Append to structure (b/c/d):
            ```powershell
            set 0aba=%x:~0,2%%0aaa%%x:~2%&set 0abb=%x:~0,2%%0aab%%x:~2%&set 0abc=%x:~0,2%%0aac%%x:~2%&set 0abd=%x:~0,2%%0aad%%x:~2%&set "0aca=%y:~0,2%%0aaa%%y:~2%"&set "0acb=%y:~0,2%%0aab%%y:~2%"&set "0acc=%y:~0,2%%0aac%%y:~2%"&set "0acd=%y:~0,2%%0aad%%y:~2%"&set 0ada=%z:~0,3%%0aaa%%z:~3%&set 0adb=%z:~0,3%%0aab%%z:~3%&set 0adc=%z:~0,3%%0aac%%z:~3%&set 0add=%z:~0,3%%0aad%%z:~3%
            ```
            Then run bool (check c, print as b) --> (C=INPUT, B=OUTPUT) :
            ```powershell
            %aif%(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)%ahas%needle%athen%(echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)%cc%buffer=about:blank%dd%echo %buffer%%ee%
            ```
            This one is true (check for the word `generic` instead of `needle`):
            ```powershell
            %aif%(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)%ahas%generic%athen%(echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)%cc%buffer=about:blank%dd%echo %buffer%%ee%
            ```




??? question "Example: Basic"

    ``` powershell
    %aif%text%ahas%needle%athen%echo string%cc%buffer=foo%dd%(echo string2)%ee%
    ```
    ``` powershell
    # cc0 allows performing custom pipe at "true" clip area) : echo "text"| mypipe
    %aif%text%ahas%needle%athen%(echo string2)| clip%cc0%buffer=bar%dd%(echo string3)%ee%
    ```

!!! tip "what?.."
    (ee is literally just "| clip")

    Perform no clips:
    ```powershell
    %aif%text%ahas%needle%athen%echo string3%cc0%buffer=foo%dd%(echo string2))
    ```
            


??? question "Example: HTML in input"

    Set your failure counter:
    ```powershell
    set count=0
    ```
    Searches for "needle" in database (spam this command, paste over and over)
    ``` powershell
    %aif%(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)%ahas%needle%athen%echo true%cc1%/a count+=1 & echo ..%dd0%(echo ⇡ my precious failure counter))
    ```
    Eventually, after pasting a bit, use the following: (appends `%ee%` for clip)
    ``` powershell
    %aif%(echo %0aca%&echo %0acb%&echo %0acc%&echo %0acd%)%ahas%needle%athen%echo true%cc1%/a count+=1 & echo  ⇠ my precious failure counter%dd0%(echo [check clipboard]) & (echo "Num-fails-so-far (-1): %count%")%ee%
    ```


??? question "Example: HTML in output"

    Always false:
    ``` powershell
    %aif%the quick brown fox%ahas%a dog%athen%(echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)%cc%buffer=about:blank%dd%echo %buffer%%ee%
    ```
    Always true:
    ``` powershell
    %aif%the quick brown fox%ahas%wolf|fox%athen%(echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)%cc%buffer=about:blank%dd%echo %buffer%%ee%
    ```
    You can clear the clipboard with `echo off | clip` btw :
    ``` powershell
    %aif%the quick brown fox%ahas%a dog%athen%(echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)%cc%buffer=about:blank%dd%echo off%ee%
    ```
    Search both wolves and foxes :
    ```powershell
    %aif%the quick brown fox" | (findstr /I "wolf fox" >nul) && (echo Great Success! & (echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)%cc%buffer=about:blank%dd%echo %buffer%%ee%
    ```
    ??? success "Need False Variant?"
        ```powershell
        %aif%the quick brown fox%ahas%some kind of koala%athen%(echo succeeded unsuccessfully)%cc%buffer=about:blank%dd%(echo %0aba%&echo %0abb%&echo %0abc%&echo %0abd%)%ee%
        ```
        !!! info
            Flip `%athen%____%cc%`  output with `%dd%____%ee%` spot

That's it.
```powershell
%aif%               #echo
(c block)
%ahas%              #find
____
%athen%
(echo trueclip)     #if html, must be 'b block'
%cc%                #set (if else)
buffer=error
%dd%                #'else'
(echo falseclip)    #if html, must be 'b block'
%ee%                #clip
```

??? example "Neat tricks (click to expand)"

    Have a whole html file you'd like to set?

    GRAB B         `# Replace "set with set  |  Replace `    "  ` with nothing`
    ```powershell
    set count=0 && ((for /f "tokens=2" %A in ('findstr /R "^.*" myfile.html') do @set /a count+=1 && @echo -0=["%A"]) | for /f "delims=" %B in ('more') do (@echo "set aa%B"&@echo "set bb%B")) | findstr /R "^.*" | clip
    ```
    Grab D         `# Replace "set with set  |  Replace `    "  ` with nothing`
    ```powershell
    set count=0 && ((for /f "tokens=2" %A in ('findstr /R "^.*" myfile.html') do @set /a count+=1 && @echo -0=["'%A'"]) | for /f "delims=" %B in ('more') do (@echo "set aa%B"&@echo "set bb%B")) | findstr /R "^.*" | clip
    ```
    GRAB C         `# Replace "-0 with -0 instead of set  |  Replace `"    "  ` with nothing`
    ```powershell
    set count=0 && ((for /f "tokens=2" %A in ('findstr /R "^.*" myfile.html') do @set /a count+=1 && @echo "-0=['%A']") | for /f "delims=" %B in ('more') do (@echo set "aa%B"&@echo set "bb%B")) | findstr /R "^.*" | clip
    ```
    ??? question "Where I left off in this project"
        Error handling...
        ```powershell
        b=[""]
        c=['']
        d=["''"]

        str(1)          set "a=blank"
        realstr(2)      set a="blank"
        literal(4)      set a='test'
        actual(5)       set a=blank
		realrealstr(3)  set "a="blank""

        # Any failures mean you just need another variant appended. Grab the line you need:
        # c and b succeed together on (1) and (3) concurrently. 
        # To tell c and b apart, c will succeed & b will fail on (2)

        # Modify the replacements (these are defaults):

        # B: "Replace "set with set  |  Replace `    "  ` with nothing"
        # C: "Replace "-0 with -0 instead of set  |  Replace `"    "  ` with nothing"
        # D: "Replace "set with set  |  Replace `    "  ` with nothing"
        ```

!!! tip "Why is this even cool?"

    "The Snipping Tool will now scan for text and extract it, which can now copy. You can copy all text using the option visible or you can specifically copy part of text from the image, by selecting it."

    — Microsoft Learn<sup>[link](https://learn.microsoft.com/en-us/answers/questions/2285914/how-to-extract-text-from-images-on-windows-11-arti){:rel="noopener noreferrer" target="blank"}</sup>

![](https://learn-attachment.microsoft.com/api/attachments/f4ea0190-cf1c-41b2-80ad-421225d9644a?platform=QnA){:rel="noopener noreferrer" target="blank"}

Win+Shift+T , alternatively, with [Microsoft Powertoys](https://learn.microsoft.com/en-us/windows/powertoys/){:rel="noopener noreferrer" target="blank"}

- [Razer Macros](https://mysupport.razer.com/app/answers/detail/a_id/2003/~/how-to-create-macros-on-a-razer-mouse){:rel="noopener noreferrer" target="blank"}
- [Tasket++](https://github.com/AmirHammouteneEI/ScheduledPasteAndKeys#tasket){:rel="noopener noreferrer" target="blank"}

??? abstract "Click to load preview"
    ![](https://camo.githubusercontent.com/ab15c2a569502dea9cf77fc6832a9c2902bfee25d8eebf03efac448b52be41b4/68747470733a2f2f66696c65732e616d697268616d6d6f7574656e652e6465762f5461736b65742b2b2f73637265656e73686f74732f312d6d61696e2e706e67){:rel="noopener noreferrer" target="blank"}

#### Related projects (on this site):

- [Regedited](../projects/regedited.md)
- [Comfy for Tasket](../projects/macrohard.md)

## Overview

???+ note "What this page covers"
    This page serves as the index for the XML Project, documenting literal-safe data handling in `cmd.exe`:

    - **The Problem** — cmd.exe special characters and parser behavior
    - **The Solution** — Layered encoding system: Base64, delayed expansion, FOR/F, findstr, clipboard
    - **Media Embedding** — Base64 data URIs for HTML elements
    - **Safety Comparison** — Unsafe vs delayed expansion vs Base64 approaches

    For detailed component documentation, see the sections below.

---

## The Problem

`cmd.exe` interprets certain characters as control operators at parse time:

```mermaid
flowchart TD
    subgraph Special["cmd.exe Special Characters"]
        direction LR
        AMP["&<br/>Command separator"]
        PIPE["|<br/>Pipe"]
        LT["<<<br/>Input redirect"]
        GT["><br/>Output redirect"]
        CARET["^<br/>Escape"]
        PCT["%<br/>Variable expansion"]
        QUOT["“<br/>Quote toggle"]
    end

    subgraph Effect["Effect"]
        direction TB
        E1["Parser interprets<br/>at parse time"]
        E2["NOT string delimiters"]
        E3["Quote toggles state flag"]
    end

    Special --> Effect
```

| Character | Behavior |
|-----------|----------|
| `&` | Command separator |
| `\|` | Pipe |
| `<` | Input redirect |
| `>` | Output redirect |
| `^` | Escape character |
| `%` | Variable expansion |
| `"` | Quote-state toggle |

The double-quote character in `cmd.exe` is not a string delimiter. It toggles the parser's quote-state flag. A `"` at the end of a line may leave the parser in quoted mode for subsequent lines within a parenthesized block. This is why `"delims=^""` requires careful construction.

---

## The Solution: Literal-Safe Encoding

```mermaid
flowchart TD
    DATA["Raw Data<br/>(contains & | < > ^ %)"] --> B64["1. Base64 Encode<br/>(binary-safe text)"]
    B64 --> TRANSPORT["2. Transport Through<br/>cmd.exe pipeline"]
    TRANSPORT --> DELAY["3. Delayed Expansion<br/>(!var! syntax)"]
    DELAY --> FORF["4. FOR /F Parsing<br/>(structured extraction)"]
    FORF --> FINDSTR["5. findstr Filtering<br/>(pattern selection)"]
    FINDSTR --> CLIP["6. Clipboard Integration<br/>(clip / Get-Clipboard)"]
    CLIP --> DECODE["7. Base64 Decode<br/>(recover original data)"]

    style B64 fill:#4a90d9
    style DELAY fill:#7ed321
    style DECODE fill:#4a90d9
```

The sHEL approach uses a layered system:

1. **Base64 encoding** — Binary-safe transport of any data through text pipelines
2. **Delayed expansion** — `cmd /v /c` with `!var!` syntax for safe variable handling
3. **FOR /F parsing** — Structured data extraction from command output
4. **findstr filtering** — Pattern matching for data selection
5. **Clipboard integration** — Bidirectional data transfer via `clip` and `Get-Clipboard`

---

## Sections

- [Base64 Encoding for Media Embedding](base64.md) — Base64 encoding/decoding, HTML data URIs, media embedding
- [cmd.exe Literacy](cmd-literacy.md) — FOR/F, findstr, delayed expansion, parser phases
- [Clipboard Automation](clipboard-automation.md) — clip, macros, tee pattern, file operations
- [Haiku Numbersystem Variable Rules](haiku-numbersystem.md) — Variable naming conventions for literal-safe scripts
- [Countku](countku.md) — Constraint-based language game using English syllable counting
- [CAPTCHA Unicode](captcha-unicode.md) — Invisible Unicode steganography for anti-bot systems
- [F# Zensical](fsharp-zensical.md) — Architecture documentation for the F# Zensical documentation system

---

## Tabular Echo: Base64 in Media Elements

The following table shows the exact `echo` command patterns for embedding Base64-encoded media in HTML, accounting for `cmd.exe` special character handling:

| Media Type | MIME Type | HTML Element | `src` Format |
|-----------|-----------|-------------|--------------|
| PNG image | `image/png` | `<img>` | `data:image/png;base64,...` |
| JPEG image | `image/jpeg` | `<img>` | `data:image/jpeg;base64,...` |
| SVG image | `image/svg+xml` | `<img>` | `data:image/svg+xml;base64,...` |
| MP3 audio | `audio/mpeg` | `<audio>` | `data:audio/mpeg;base64,...` |
| WAV audio | `audio/wav` | `<audio>` | `data:audio/wav;base64,...` |
| OGG audio | `audio/ogg` | `<audio>` | `data:audio/ogg;base64,...` |
| MP4 video | `video/mp4` | `<video>` | `data:video/mp4;base64,...` |
| WebM video | `video/webm` | `<video>` | `data:video/webm;base64,...` |
| ICO icon | `image/x-icon` | `<link rel="icon">` | `data:image/x-icon;base64,...` |

### SVG to Base64 Efficiency

SVG (Scalable Vector Graphics) encoded as Base64 is more space-efficient than raster equivalents for geometric imagery. SVG source is XML text, which compresses well and has no binary overhead. The recommended workflow:

1. Optimize SVG with `svgo` (remove metadata, simplify paths)
2. Minify to single-line XML
3. Encode as Base64
4. Embed as `data:image/svg+xml;base64,...`

```bash
# Optimize SVG
svgo input.svg -o output.svg --pretty=false --multipass

# Encode as Base64 (Linux/macOS)
base64 -i output.svg -o output.svg.b64

# Encode as Base64 (PowerShell)
[Convert]::ToBase64String([IO.File]::ReadAllBytes("output.svg"))
```

Compared to PNG for the same icon:

| Format | Original | Base64 | Overhead |
|--------|----------|--------|----------|
| SVG (simple icon) | 500 bytes | ~670 bytes | 34% |
| PNG (same icon) | 2,000 bytes | ~2,670 bytes | 34% |

SVG maintains crisp scaling at any resolution; raster images require higher resolution (and larger file size) for equivalent visual quality.

---

## Quick Example: Safe vs Unsafe

=== "Unsafe (breaks on special chars)"

    ```batch
    REM This FAILS if data contains & | < > ^ %
    set "data=Some & value | pipe"
    echo %data%
    ```

=== "Safe (delayed expansion)"

    ```batch
    REM Handles any character safely
    cmd /v /c "set ""data=Some & value | pipe<>^%%"" & echo !data!"
    ```

=== "Safest (Base64 encoded)"

    ```batch
    REM Data is Base64-encoded, decoded at use time
    set "b64=U29tZSAmIHZhbHVlIHwgcGlwZTw+XiU="
    for /f "delims=" %%A in (
        'powershell -NoP -C "[Text.Encoding]::UTF8.GetString([Convert]::FromBase64String('%b64%'))"'
    ) do set "data=%%A"
    echo %data%
    ```

---

## Related Deep Hole

- [RFC 4648: Base64 Data Encodings](https://datatracker.ietf.org/doc/html/rfc4648) — Base64 specification
- [SS64: EnableDelayedExpansion](https://ss64.com/nt/delayedexpansion.html) — Delayed expansion behavior
- [SuperUser: How does delayed expansion work](https://superuser.com/questions/1569594) — Parse phase documentation
- [Microsoft Docs: setlocal](https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/setlocal) — Official setlocal documentation
"""

let render() = file
