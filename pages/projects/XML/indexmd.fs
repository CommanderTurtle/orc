module Imported.Projects.XML.IndexMd

let file = """## Going back to our original example...
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

### Now the fun begins.
```powershell
set "search=for /f "tokens= delims=[" %A in ("") do @for /f "tokens=1 delims=]" %B in ("%A") do @echo %B"
```
```powershell
<# If variables are more your thing,
instead of remembering 0, 15, 19, 34... just do:
set tok=%search:~0,15%
set aa=%search:~15,19%
set bb=%search:~34%
#>
```
```powershell
%search:~0,15%  [Enter Tokens to Dig]  %search:~15,19%  [Paste Large Block to Delimit nth value]  %search:~34%
# OR:
%tok%  [Enter Tokens to Dig]  %aa%  [Paste Large Block to Delimit nth value]  %bb%
```
##### Example searching for second list item (tok=3 == item 2):
```powershell
%tok%3%aa%(echo ['<jibberish 1>']&echo ['<wtf ! /2>']&echo ['69 86 <64????/> <third value>']&echo ['249 86 64 ^*!?<this is the fourth line, etc.></a>'])| clip%bb%
```
###### prints `['<wtf ! /2>']`

###### +1 needs to be added to the search. 0 returns nothing. 1 returns everything prior to the list. tok=2 returns first. tok=3 returns second, etc.
###### Secondly, x and z format work for simple lists but have limitations. y formatting [''] works all the time, but lacks searchable strings.

### Searchable strings
```powershell
(echo ["'<somehtml>'"]&echo ["'"%date%,%time:~0,8%"... is actually the time <testhtml>'"]&echo ["'<somehtml> #3'"]) | findstr "3"
```
###### prints `["'<somehtml> #3'"]`
##### Example searching for time
```powershell
(echo ["'<somehtml>'"]&echo ["'"%date%,%time:~0,8%"... is actually the time <testhtml>'"]&echo ["'<somehtml> #3'"]) | findstr "time"
```
###### prints `["'"%date%,%time:~0,8%"... is actually the time <testhtml>'"]`
###### This only works for long echo strings, and usually fails if searching a piped or mega-one-liner clip command.

### Boolean cmd
Now that we have the basics, why not add if/then functionality to dos shell by being clever?
```powershell
echo "text to search" | find /I "needle" >nul && echo true || echo false
```
###### Removing `/I` allows for a case-sensitive variant.

## Now, run all the macros you like!
#### We can paste a large multi-line list with clip, search a string out of it, if it exists, pipe to clip something else! Run a dummy "about:blank" paste instead of a URL if something is not found, then add to clipboard large, multiline pipes-and-dashes tables that are markdown friendly, containing html elements.

```powershell
echo "text to search" | find /I "needle" >nul && (echo Great Success! & (echo ["| <a href="https://example.com" title="this is sparta, no, this is a generic T icon"><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACpUlEQVR4nGxTz0tVQRg937z79Hnx0SLNcvEMXBRFq4x+UEKE9EsXbWoR/XLxKqhFEfUHtMpthSiBYUG0kqiNKBFqmBBBWtSiLF9l+CsR7Jm+e+frzL2KL2gud+bemXPOfN+Z+TywKSASDewuYh+Hc/yp52RGA/ 4tIMfvPqxBh9xGfzFHsNy0Cb7NoMWIZJE0SVgDFBRakYFsPQhMjADvBwrw0I4crstT5B1PnNLEKfjr0uiSMjRw2uoiLEIkUODi5fuwu8643QK5e8jgY7dRJHom58JjVQ+Q91wYYTluiU/yHJaQTnvY0ehJ9TZVy/j5mqFO1Z2nPWw5bDHUvSTrpaEyJAe4JHoeu5GUPoYrqN4k9uqAkfKKyBCJc41GCRZVWxtFhnstUi5wVUZY71lB1njMrIAAGhjz9ZXq4EORzfuBPc2QzrOA58P+GhXz7rmilHpWLZLwGFyWntH1gGoejP78LHqnSbT3MZCfgVJZh7uA35OQk/egR66J5imQSBh6pI7rBDK0TKKXeClJQvwEd03FodfyVC88cU4BP0YgxMDaGE+ut5Kj6+KcNQYzyuikZ74AH3qhn17AvOwGKikehMskwBCfi/pVympjZkhXMSwDGXsDLTdMn2Y7vIn2yhli+nnijmeNm1LVmL0stXYjpCwNzH6DGKvGrTMJx3FcQ1I7DQmijFB8ehon9JYmTjONuhPKK+0M1AhLjuMaacOgDdGGFDXVCYmFg2jI3sAcvanYfhyYnyKZOyurg1jHcVzjrvLUPG7oH/TARwkoLSkKvX5E0rTqgSuis98VI88cESgNSxw24hR7Np6FvyGJFn6ymPgsMIGqWqCmDjLKApwdd5YXLMOeYDFVrxTT/8qZoGaTkL283jWuoCg3xgrt5/l3SOu/5fwXAAD//5rxYZkAAAAGSURBVAMAkjI5uqP0pJcAAAAASUVORK5CYII=" alt="An image on the screen displays a generic 'T', This part is read by accessibilty screen readers" style="width:24px;height:24px;"></a><br><span style="font-size:13px; color:#666;">Figure 1 — Example icon footer</span> | Test | Three |"]&echo ["|---|---|---|"]&echo ["| aaa | bbb | ccc |"]&echo ["| ddd | eee | fff |"]&echo ["#### Holy guacamole"])| clip) || (set "var=This element does not exist" & echo %var% & echo %var%| clip)
```
Adds the following to clipboard... (renderable as markdown plaintext, delimited with `["` and `"]` due to html elements—find and replace these easily).

| <a href="https://example.com" title="this is sparta, no, this is a generic T icon set to 32px"><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACpUlEQVR4nGxTz0tVQRg937z79Hnx0SLNcvEMXBRFq4x+UEKE9EsXbWoR/XLxKqhFEfUHtMpthSiBYUG0kqiNKBFqmBBBWtSiLF9l+CsR7Jm+e+frzL2KL2gud+bemXPOfN+Z+TywKSASDewuYh+Hc/yp52RGA/ 4tIMfvPqxBh9xGfzFHsNy0Cb7NoMWIZJE0SVgDFBRakYFsPQhMjADvBwrw0I4crstT5B1PnNLEKfjr0uiSMjRw2uoiLEIkUODi5fuwu8643QK5e8jgY7dRJHom58JjVQ+Q91wYYTluiU/yHJaQTnvY0ehJ9TZVy/j5mqFO1Z2nPWw5bDHUvSTrpaEyJAe4JHoeu5GUPoYrqN4k9uqAkfKKyBCJc41GCRZVWxtFhnstUi5wVUZY71lB1njMrIAAGhjz9ZXq4EORzfuBPc2QzrOA58P+GhXz7rmilHpWLZLwGFyWntH1gGoejP78LHqnSbT3MZCfgVJZh7uA35OQk/egR66J5imQSBh6pI7rBDK0TKKXeClJQvwEd03FodfyVC88cU4BP0YgxMDaGE+ut5Kj6+KcNQYzyuikZ74AH3qhn17AvOwGKikehMskwBCfi/pVympjZkhXMSwDGXsDLTdMn2Y7vIn2yhli+nnijmeNm1LVmL0stXYjpCwNzH6DGKvGrTMJx3FcQ1I7DQmijFB8ehon9JYmTjONuhPKK+0M1AhLjuMaacOgDdGGFDXVCYmFg2jI3sAcvanYfhyYnyKZOyurg1jHcVzjrvLUPG7oH/TARwkoLSkKvX5E0rTqgSuis98VI88cESgNSxw24hR7Np6FvyGJFn6ymPgsMIGqWqCmDjLKApwdd5YXLMOeYDFVrxTT/8qZoGaTkL283jWuoCg3xgrt5/l3SOu/5fwXAAD//5rxYZkAAAAGSURBVAMAkjI5uqP0pJcAAAAASUVORK5CYII=" alt="An image on the screen displays a generic 'T', This part is read by accessibilty screen readers" style="width:32px;height:32px;"></a><br><span style="font-size:13px; color:#666;">Figure 1 - Example icon footer</span> | Test | Three |
|---|---|---|
| aaa | bbb | ccc |
| ddd | eee | fff |
#### Holy guacamole
\[blank line\]

<br><br>

##### If there is no needle. The command prints and clips custom text. Note, `echo off | clip` will clear the clipboard.
---
##### Here is a plaintext rendering of the output after removing delimiters:
###### | \<html blob\> | Test | Three |
###### |---|---|---|
###### | aaa | bbb | ccc |
###### | ddd | eee | fff |
###### #### Holy guacamole
###### [Blank Line] <--- 
"""

let render() = file
