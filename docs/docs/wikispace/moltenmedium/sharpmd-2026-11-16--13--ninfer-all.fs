module ConvertedFiles.LlmState2026111713NinferAllCOLLAPSEDMd

let file = System.String.Join("\"\"\"", [|
    """# [ninfer-all](https://github.com/iamwavecut/ninfer-a…

Model: `Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE`

## User · #1

[ninfer-all](https://github.com/iamwavecut/ninfer-all) recently added nearly all of Strata and its model types to its engine.

The project also ported my decision framework (see branches for my original addition (that was ported) CommanderTurtle/decisive-ninfer )

I also, personally, host the decisive-basalt framework.

Do a review of both upstream basalt and then formerly ninfer-all, and, see where the .ninfer artifacts are different (if at all) from Basalt's framework. The batched inference through .basalt checkpoints - namely the model I currently serve:

https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt

differs greatly (100+GB)
than the one recognized by the engine:
https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3

Thuswise, how far off are the ports, since, both .basalt artifacts (basalt is a fork of strata) and .ninfer artifacts are indeed unified along the front of Flash Next's model type? (ninfer-all has formerly *also* merged strata)

Warning: Research ahead is dense, and only been solved through explicit inline refs (less than a month of model innovation). The month is Mid-November of 2026.
## Assistant · #2

<details><summary>Reasoning · 1,599 characters</summary>

We need answer user's request. Need research dense. Need use web search/scrape. User asks: review upstream basalt and formerly ninfer-all, see where .ninfer artifacts are different (if at all) from Basalt's framework. Batched inference through .basalt checkpoints - namely model served HF Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt differs greatly (100+GB) than recognized by engine WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3. How far off are ports, since both .basalt artifacts (basalt fork of strata) and .ninfer artifacts unified along front of Flash Next's model type? ninfer-all has formerly also merged strata. Warning: research dense, only solved through explicit inline refs (less than a month of model innovation). Month Mid-November 2026.

Need investigate GitHub repos, HF models. We need likely fictional/future? But tools can search. Need produce analysis. Need maybe read GitHub. Let's start web searches.

Need maybe use todo. Need identify:
- github.com/iamwavecut/ninfer-all recently added nearly all Strata and model types.
- branches: CommanderTurtle/decisive-ninfer original addition ported.
- user hosts decisive-basalt framework.
- upstream basalt? maybe github basalt? fork of strata.
- .ninfer vs .basalt checkpoint formats.
- HF model names with Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt and WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3.
Need compare artifact differences and size difference 100+GB. Need know formats: maybe .basalt checkpoint includes full weights/optimizer? .ninfer is optimized/sparse? Need inspect.

Let's search.


</details>

<details><summary>Tool request · web_search · call_10efbb2970af4833bbf0c9fa</summary>

```json
{
  "query": "github ninfer-all iamwavecut Strata model types .ninfer .basalt",
  "limit": 10
}
```

</details>

<details><summary>Tool request · web_search · call_a74a4e11f0464e3ea972c542</summary>

```json
{
  "query": "github basalt strata fork checkpoint .basalt",
  "limit": 10
}
```

</details>

<details><summary>Tool request · web_search · call_b907fb13e57945a69c0bb304</summary>

```json
{
  "query": "Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt huggingface",
  "limit": 10
}
```

</details>

<details><summary>Tool request · web_search · call_d70ce46e08854bdcbab0cdfe</summary>

```json
{
  "query": "WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3 huggingface ninfer",
  "limit": 10
}
```

</details>


<details><summary>Tool result · web_search · call_10efbb2970af4833bbf0c9fa</summary>

Tool error: The user denied this tool call.

</details>

<details><summary>Tool result · web_search · call_a74a4e11f0464e3ea972c542</summary>

Tool error: The user denied this tool call.

</details>

<details><summary>Tool result · web_search · call_b907fb13e57945a69c0bb304</summary>

Tool error: The user denied this tool call.

</details>

<details><summary>Tool result · web_search · call_d70ce46e08854bdcbab0cdfe</summary>

Tool error: The user denied this tool call.

</details>

## Assistant · #7

<details><summary>Reasoning · 367 characters</summary>

User denied web search? Maybe need not use? Could ask clarification? But request asks research. Maybe tools are blocked? Need maybe use web_scrape directly? Let's try maybe one. Could be denied all search? Maybe need use context? No local attachments. We can try web_scrape on URLs. But maybe search denied due rate? Need be careful. Use web_scrape on GitHub and HF.


</details>

<details><summary>Tool request · web_scrape · call_18d72beb842b47c1a478ebcf</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all"
}
```

</details>

<details><summary>Tool request · web_scrape · call_a0b1db22079744eb88861e02</summary>

```json
{
  "url": "https://github.com/CommanderTurtle/decisive-ninfer"
}
```

</details>

<details><summary>Tool request · web_scrape · call_c59ac02a900f4b90afbe0a93</summary>

```json
{
  "url": "https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt"
}
```

</details>

<details><summary>Tool request · web_scrape · call_0dc310fa64d2402db20b246a</summary>

```json
{
  "url": "https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3"
}
```

</details>


<details><summary>Tool result · web_scrape · call_18d72beb842b47c1a478ebcf</summary>

**Firecrawl · section 1 of 7**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,550 characters · included below
- Section 2 · 11,891 characters · omitted from this copy
- Section 3 · 8,149 characters · omitted from this copy
- Section 4 · 11,959 characters · omitted from this copy
- Section 5 · 11,053 characters · omitted from this copy
- Section 6 · 11,886 characters · omitted from this copy
- Section 7 · 1,239 characters · omitted from this copy

```text
[Skip to content](https://github.com/iamwavecut/ninfer-all#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all)
 to refresh your session. Dismiss alert

            [](https://github.com/iamwavecut/ninfer-all)

master

[**2** Branches](https://github.com/iamwavecut/ninfer-all/branches)
[**42** Tags](https://github.com/iamwavecut/ninfer-all/tags)

[](https://github.com/iamwavecut/ninfer-all/branches)
[](https://github.com/iamwavecut/ninfer-all/tags)

Go to file

Code

Open more actions menu

Latest commit
-------------

[![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=40)](https://github.com/iamwavecut)
[iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

[Merge pull request](https://github.com/iamwavecut/ninfer-all/commit/a3171940a3574cda4d4f3bc3000df7c0944e8ad8)
 [#370](https://github.com/iamwavecut/ninfer-all/pull/370)
 [from iamwavecut/dev/decision-read-stop-token](https://github.com/iamwavecut/ninfer-all/commit/a3171940a3574cda4d4f3bc3000df7c0944e8ad8)

Open commit detailssuccess

Nov 16, 2026

[a317194](https://github.com/iamwavecut/ninfer-all/commit/a3171940a3574cda4d4f3bc3000df7c0944e8ad8)
 · Nov 16, 2026

History
-------

[3,330 Commits](https://github.com/iamwavecut/ninfer-all/commits/master/)

Open commit details

[](https://github.com/iamwavecut/ninfer-all/commits/master/)
3,330 Commits

Folders and files
-----------------

| Name |     | Name | Last commit message | Last commit date |
| --- | --- | --- | --- |
| [.codex](https://github.com/iamwavecut/ninfer-all/tree/master/.codex ".codex") |     | [.codex](https://github.com/iamwavecut/ninfer-all/tree/master/.codex ".codex") |     |     |
| [.github](https://github.com/iamwavecut/ninfer-all/tree/master/.github ".github") |     | [.github](https://github.com/iamwavecut/ninfer-all/tree/master/.github ".github") |     |     |
| [apps](https://github.com/iamwavecut/ninfer-all/tree/master/apps "apps") |     | [apps](https://github.com/iamwavecut/ninfer-all/tree/master/apps "apps") |     |     |
| [bench](https://github.com/iamwavecut/ninfer-all/tree/master/bench "bench") |     | [bench](https://github.com/iamwavecut/ninfer-all/tree/master/bench "bench") |     |     |
| [cmake](https://github.com/iamwavecut/ninfer-all/tree/master/cmake "cmake") |     | [cmake](https://github.com/iamwavecut/ninfer-all/tree/master/cmake "cmake") |     |     |
| [configs](https://github.com/iamwavecut/ninfer-all/tree/master/configs "configs") |     | [configs](https://github.com/iamwavecut/ninfer-all/tree/master/configs "configs") |     |     |
| [docker](https://github.com/iamwavecut/ninfer-all/tree/master/docker "docker") |     | [docker](https://github.com/iamwavecut/ninfer-all/tree/master/docker "docker") |     |     |
| [docs](https://github.com/iamwavecut/ninfer-all/tree/master/docs "docs") |     | [docs](https://github.com/iamwavecut/ninfer-all/tree/master/docs "docs") |     |     |
| [eval](https://github.com/iamwavecut/ninfer-all/tree/master/eval "eval") |     | [eval](https://github.com/iamwavecut/ninfer-all/tree/master/eval "eval") |     |     |
| [examples/cli](https://github.com/iamwavecut/ninfer-all/tree/master/examples/cli "This path skips through empty directories") |     | [examples/cli](https://github.com/iamwavecut/ninfer-all/tree/master/examples/cli "This path skips through empty directories") |     |     |
| [include/ninfer](https://github.com/iamwavecut/ninfer-all/tree/master/include/ninfer "This path skips through empty directories") |     | [include/ninfer](https://github.com/iamwavecut/ninfer-all/tree/master/include/ninfer "This path skips through empty directories") |     |     |
| [kernel/ninfer-direct](https://github.com/iamwavecut/ninfer-all/tree/master/kernel/ninfer-direct "This path skips through empty directories") |     | [kernel/ninfer-direct](https://github.com/iamwavecut/ninfer-all/tree/master/kernel/ninfer-direct "This path skips through empty directories") |     |     |
| [scripts](https://github.com/iamwavecut/ninfer-all/tree/master/scripts "scripts") |     | [scripts](https://github.com/iamwavecut/ninfer-all/tree/master/scripts "scripts") |     |     |
| [src](https://github.com/iamwavecut/ninfer-all/tree/master/src "src") |     | [src](https://github.com/iamwavecut/ninfer-all/tree/master/src "src") |     |     |
| [tests](https://github.com/iamwavecut/ninfer-all/tree/master/tests "tests") |     | [tests](https://github.com/iamwavecut/ninfer-all/tree/master/tests "tests") |     |     |
| [third\_party](https://github.com/iamwavecut/ninfer-all/tree/master/third_party "third_party") |     | [third\_party](https://github.com/iamwavecut/ninfer-all/tree/master/third_party "third_party") |     |     |
| [tools](https://github.com/iamwavecut/ninfer-all/tree/master/tools "tools") |     | [tools](https://github.com/iamwavecut/ninfer-all/tree/master/tools "tools") |     |     |
| [.clang-format](https://github.com/iamwavecut/ninfer-all/blob/master/.clang-format ".clang-format") |     | [.clang-format](https://github.com/iamwavecut/ninfer-all/blob/master/.clang-format ".clang-format") |     |     |
| [.clangd](https://github.com/iamwavecut/ninfer-all/blob/master/.clangd ".clangd") |     | [.clangd](https://github.com/iamwavecut/ninfer-all/blob/master/.clangd ".clangd") |     |     |
| [.dockerignore](https://github.com/iamwavecut/ninfer-all/blob/master/.dockerignore ".dockerignore") |     | [.dockerignore](https://github.com/iamwavecut/ninfer-all/blob/master/.dockerignore ".dockerignore") |     |     |
| [.gitattributes](https://github.com/iamwavecut/ninfer-all/blob/master/.gitattributes ".gitattributes") |     | [.gitattributes](https://github.com/iamwavecut/ninfer-all/blob/master/.gitattributes ".gitattributes") |     |     |
| [.gitignore](https://github.com/iamwavecut/ninfer-all/blob/master/.gitignore ".gitignore") |     | [.gitignore](https://github.com/iamwavecut/ninfer-all/blob/master/.gitignore ".gitignore") |     |     |
| [AGENTS.md](https://github.com/iamwavecut/ninfer-all/blob/master/AGENTS.md "AGENTS.md") |     | [AGENTS.md](https://github.com/iamwavecut/ninfer-all/blob/master/AGENTS.md "AGENTS.md") |     |     |
| [CMakeLists.txt](https://github.com/iamwavecut/ninfer-all/blob/master/CMakeLists.txt "CMakeLists.txt") |     | [CMakeLists.txt](https://github.com/iamwavecut/ninfer-all/blob/master/CMakeLists.txt "CMakeLists.txt") |     |     |
| [CMakePresets.json](https://github.com/iamwavecut/ninfer-all/blob/master/CMakePresets.json "CMakePresets.json") |     | [CMakePresets.json](https://github.com/iamwavecut/ninfer-all/blob/master/CMakePresets.json "CMakePresets.json") |     |     |
| [CONTRIBUTING.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTING.md "CONTRIBUTING.md") |     | [CONTRIBUTING.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTING.md "CONTRIBUTING.md") |     |     |
| [CONTRIBUTORS.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTORS.md "CONTRIBUTORS.md") |     | [CONTRIBUTORS.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTORS.md "CONTRIBUTORS.md") |     |     |
| [Dockerfile](https://github.com/iamwavecut/ninfer-all/blob/master/Dockerfile "Dockerfile") |     | [Dockerfile](https://github.com/iamwavecut/ninfer-all/blob/master/Dockerfile "Dockerfile") |     |     |
| [LICENSE](https://github.com/iamwavecut/ninfer-all/blob/master/LICENSE "LICENSE") |     | [LICENSE](https://github.com/iamwavecut/ninfer-all/blob/master/LICENSE "LICENSE") |     |     |
| [README.md](https://github.com/iamwavecut/ninfer-all/blob/master/README.md "README.md") |     | [README.md](https://github.com/iamwavecut/ninfer-all/blob/master/README.md "README.md") |     |     |
| [build\_merge.bat](https://github.com/iamwavecut/ninfer-all/blob/master/build_merge.bat "build_merge.bat") |     | [build\_merge.bat](https://github.com/iamwavecut/ninfer-all/blob/master/build_merge.bat "build_merge.bat") |     |     |
| [build\_only.bat](https://github.com/iamwavecut/ninfer-all/blob/master/build_only.bat "build_only.bat") |     | [build\_only.bat](https://github.com/iamwavecut/ninfer-all/blob/master/build_only.bat "build_only.bat") |     |     |
| [compose.yaml](https://github.com/iamwavecut/ninfer-all/blob/master/compose.yaml "compose.yaml") |     | [compose.yaml](https://github.com/iamwavecut/ninfer-all/blob/master/compose.yaml "compose.yaml") |     |     |
| [flake.lock](https://github.com/iamwavecut/ninfer-all/blob/master/flake.lock "flake.lock") |     | [flake.lock](https://github.com/iamwavecut/ninfer-all/blob/master/flake.lock "flake.lock") |     |     |
| [flake.nix](https://github.com/iamwavecut/ninfer-all/blob/master/flake.nix "flake.nix") |     | [flake.nix](https://github.com/iamwavecut/ninfer-all/blob/master/flake.nix "flake.nix") |     |     |
| [vcpkg.json](https://github.com/iamwavecut/ninfer-all/blob/master/vcpkg.json "vcpkg.json") |     | [vcpkg.json](https://github.com/iamwavecut/ninfer-all/blob/master/vcpkg.json "vcpkg.json") |     |     |
| View all files |     |     |

Repository files navigation
---------------------------

NInfer-all
==========

[](https://github.com/iamwavecut/ninfer-all#ninfer-all)

A C++/CUDA inference engine for the Qwen3.5 model family (Qwen3.6 and Qwen3.8 27B, Qwen3.6-35B-A3B, their fine-tunes and Ternary Bonsai 2), Qwen3.8-Flash-Next and Edge0's latent-MoE models built on it, Gemma 4 26B-A4B, Recursive's Flint and DeepSeek-V4.1-Flash, on NVIDIA GPUs from Volta to consumer Blackwell, from 8 GB of memory. It serves the OpenAI, Anthropic and llama.cpp APIs from one GPU, or from up to eight as pipeline stages on Linux. The same chat model answers [typed decisions](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#typed-decisions)
: choice, yes/no and score questions about a state, each option with its probability, through TypeSafe's System One and OpenAI's Decisions APIs.

[What's New](https://github.com/iamwavecut/ninfer-all#whats-new)
 · [Quick start](https://github.com/iamwavecut/ninfer-all#quick-start)
 · [Supported GPUs](https://github.com/iamwavecut/ninfer-all#supported-gpus)
 · [Models](https://github.com/iamwavecut/ninfer-all#artifacts)
 · [Highlights](https://github.com/iamwavecut/ninfer-all#highlights)
 · [Features](https://github.com/iamwavecut/ninfer-all#features)
 · [Docker](https://github.com/iamwavecut/ninfer-all#docker)
 · [Building](https://github.com/iamwavecut/ninfer-all#building)
 · [Documentation](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md)

NInfer-all continues [NInfer](https://github.com/Neroued/ninfer)
 through the NInfer-3090 line and carries the work of several forks; [CONTRIBUTORS.md](https://github.com/iamwavecut/ninfer-all/blob/master/CONTRIBUTORS.md)
 credits each of them.

Note

**Support GPU testing.** Choose a custom amount on [GitHub Sponsors](https://github.com/sponsors/iamwavecut)
 to help cover GPU rentals for correctness checks, kernel tuning, and benchmarks. This is a voluntary contribution without sponsor benefits. For compute credits, GPU access, or individual sponsorship terms, [contact the maintainer](https://selit.ski/#contact)
 directly.

What's New
----------

[](https://github.com/iamwavecut/ninfer-all#whats-new)

```

</details>

<details><summary>Tool result · web_scrape · call_a0b1db22079744eb88861e02</summary>

**Firecrawl · section 1 of 3**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,927 characters · included below
- Section 2 · 11,317 characters · omitted from this copy
- Section 3 · 7,947 characters · omitted from this copy

````text
[Skip to content](https://github.com/CommanderTurtle/decisive-ninfer#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/CommanderTurtle/decisive-ninfer)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/CommanderTurtle/decisive-ninfer)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/CommanderTurtle/decisive-ninfer)
 to refresh your session. Dismiss alert

            [](https://github.com/CommanderTurtle/decisive-ninfer)

feature/parallel-decision

[Branches](https://github.com/CommanderTurtle/decisive-ninfer/branches)
[Tags](https://github.com/CommanderTurtle/decisive-ninfer/tags)

[](https://github.com/CommanderTurtle/decisive-ninfer/branches)
[](https://github.com/CommanderTurtle/decisive-ninfer/tags)

Go to file

Code

Open more actions menu

Latest commit
-------------

History
-------

[1,647 Commits](https://github.com/CommanderTurtle/decisive-ninfer/commits/feature/parallel-decision/)

[](https://github.com/CommanderTurtle/decisive-ninfer/commits/feature/parallel-decision/)
1,647 Commits

Folders and files
-----------------

| Name |     | Name | Last commit message | Last commit date |
| --- | --- | --- | --- |
| [.codex](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/.codex ".codex") |     | [.codex](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/.codex ".codex") |     |     |
| [.github](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/.github ".github") |     | [.github](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/.github ".github") |     |     |
| [apps](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/apps "apps") |     | [apps](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/apps "apps") |     |     |
| [bench](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/bench "bench") |     | [bench](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/bench "bench") |     |     |
| [cmake](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/cmake "cmake") |     | [cmake](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/cmake "cmake") |     |     |
| [dashboard](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/dashboard "dashboard") |     | [dashboard](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/dashboard "dashboard") |     |     |
| [docs](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/docs "docs") |     | [docs](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/docs "docs") |     |     |
| [eval](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/eval "eval") |     | [eval](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/eval "eval") |     |     |
| [examples](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/examples "examples") |     | [examples](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/examples "examples") |     |     |
| [include/ninfer](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/include/ninfer "This path skips through empty directories") |     | [include/ninfer](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/include/ninfer "This path skips through empty directories") |     |     |
| [model-cards](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/model-cards "model-cards") |     | [model-cards](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/model-cards "model-cards") |     |     |
| [src](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/src "src") |     | [src](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/src "src") |     |     |
| [tests](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/tests "tests") |     | [tests](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/tests "tests") |     |     |
| [third\_party](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/third_party "third_party") |     | [third\_party](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/third_party "third_party") |     |     |
| [tools](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/tools "tools") |     | [tools](https://github.com/CommanderTurtle/decisive-ninfer/tree/feature/parallel-decision/tools "tools") |     |     |
| [.clang-format](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.clang-format ".clang-format") |     | [.clang-format](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.clang-format ".clang-format") |     |     |
| [.clangd](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.clangd ".clangd") |     | [.clangd](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.clangd ".clangd") |     |     |
| [.dockerignore](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.dockerignore ".dockerignore") |     | [.dockerignore](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.dockerignore ".dockerignore") |     |     |
| [.gitattributes](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.gitattributes ".gitattributes") |     | [.gitattributes](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.gitattributes ".gitattributes") |     |     |
| [.gitignore](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.gitignore ".gitignore") |     | [.gitignore](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/.gitignore ".gitignore") |     |     |
| [AGENTS.md](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/AGENTS.md "AGENTS.md") |     | [AGENTS.md](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/AGENTS.md "AGENTS.md") |     |     |
| [CMakeLists.txt](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/CMakeLists.txt "CMakeLists.txt") |     | [CMakeLists.txt](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/CMakeLists.txt "CMakeLists.txt") |     |     |
| [CMakePresets.json](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/CMakePresets.json "CMakePresets.json") |     | [CMakePresets.json](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/CMakePresets.json "CMakePresets.json") |     |     |
| [CONTRIBUTING.md](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/CONTRIBUTING.md "CONTRIBUTING.md") |     | [CONTRIBUTING.md](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/CONTRIBUTING.md "CONTRIBUTING.md") |     |     |
| [Dockerfile](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/Dockerfile "Dockerfile") |     | [Dockerfile](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/Dockerfile "Dockerfile") |     |     |
| [LICENSE](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/LICENSE "LICENSE") |     | [LICENSE](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/LICENSE "LICENSE") |     |     |
| [README.md](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/README.md "README.md") |     | [README.md](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/README.md "README.md") |     |     |
| [ninfer.example.toml](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/ninfer.example.toml "ninfer.example.toml") |     | [ninfer.example.toml](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/ninfer.example.toml "ninfer.example.toml") |     |     |
| View all files |     |     |

Repository files navigation
---------------------------

NInfer
======

[](https://github.com/CommanderTurtle/decisive-ninfer#ninfer)

> Native C++/CUDA inference for selected models on RTX 5090 and DGX Spark.

NInfer runs text and image/video generation through a local CLI or OpenAI- and Anthropic-compatible HTTP APIs. It supports single-device execution and model-parallel execution across two DGX Sparks, with CUDA Graph decode, speculative decoding, and shared-prefix caching. One Engine serves one model with a configurable resident-request capacity. Startup checks the resources required by that capacity; decode batches use the requests currently ready to run.

Supported models and deployments
--------------------------------

[](https://github.com/CommanderTurtle/decisive-ninfer#supported-models-and-deployments)

| Model | Architecture | Deployment | Speculative backends |
| --- | --- | --- | --- |
| Qwen3.6-27B / Qwen3.8-27B | Qwen3.5 Dense | RTX 5090 | MTP; DFlash2 for Qwen3.8-27B with companion weights |
| Qwen3.6-35B-A3B | Qwen3.5 MoE | RTX 5090, resident or CPU expert offload | MTP or DFlash with companion weights |
| Qwen3.8-Flash-Next | Qwen4Exp | RTX 5090 with CPU expert offload; one or two Sparks | MTP |
| GLM-5.3-Flash | GLM5Next | Two Sparks | MTP or DFlash2 with companion weights |

All rows support text, Vision, tools, constrained output, and offline perplexity scoring. Vision and speculative decoding require the corresponding components in the artifact and must be enabled at startup. Scoring loads Text only. CPU expert offload applies to the RTX 5090 target; Spark execution keeps selected weights on the GPU. Flash Next offload also needs substantial system RAM for expert weights; see the [CLI guide](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/cli.md#cpu-expert-offload)
.

Dual-Spark Flash Next uses TP2, optionally with EP2. GLM uses TP2 plus attention DP2, optionally with EP2. The [deployment guide](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/startup-configuration.md#distributed-deployment)
 explains these settings and worker startup. [Example configurations](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/examples/configs)
 cover the common deployments, including Vision, FP8 KV, MTP3 and the optimized draft head.

Build
-----

[](https://github.com/CommanderTurtle/decisive-ninfer#build)

Build natively on Linux: x86-64 / `sm_120a` for RTX 5090, AArch64 / `sm_121a` for DGX Spark. Dependencies are a CUDA toolkit supporting the target, CMake 3.28+, a C++20 host compiler, Ninja, `pkg-config`, libjpeg development headers, FFmpeg development libraries (`libavformat`, `libavcodec`, `libavutil`, `libswscale`), `hwloc >= 2.5`, `liburing >= 2.5`, and `libcurl >= 7.85`. CUDA 13.4 is the development toolkit; CMake checks the requested architecture.

```shell
git clone https://github.com/Neroued/ninfer.git
cd ninfer
cmake --preset rtx5090-release
cmake --build build/rtx5090-release -j
```

For a single Spark, use `dgx-spark-release` and `build/dgx-spark-release`. For two Sparks, install NCCL and libibverbs development headers and libraries (`libibverbs-dev` on Debian/Ubuntu), then build on **both nodes**:

````

</details>

<details><summary>Tool result · web_scrape · call_c59ac02a900f4b90afbe0a93</summary>

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt#qwen38-flash-next-abliterated-gsq-rco-iq3_s-q8-n-gram)
Qwen3.8-Flash-Next abliterated GSQ-RCO IQ3\_S, Q8 n-gram
===========================================================================================================================================================================================================

One `.basalt` file for [Basalt](https://github.com/jesdga95/basalt)
. Experts are the SC117 abliterated IQ3\_S GGUF, packed with the official Basalt MTP, vision, and profile sections. The n-gram table is Q8\_0.

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt#what-is-in-the-file)
What is in the file
------------------------------------------------------------------------------------------------------------------------------------

Experts come from [SC117/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-GGUF](https://huggingface.co/SC117/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-GGUF)
 `IQ3_S`. That repo transplants 144 residual-write tensors from an uncensored GGUF into the already-quantized [ISTA-DASLab GSQ-RCO](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)
 IQ3\_S, and keeps the GSQ scales. Shard 2 of that repo is the stock per-layer embedding, so the ablation does not touch the n-gram table.

Converted with Basalt `tools/convert/convert.py --compat-bf16 --sections-from` the official IQ3\_S pack that already carries the Q8 n-gram ([Shockem/Qwen3.8-FN-GSQ-RCO-IQ3\_S-Q8PLE-basalt](https://huggingface.co/Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt)
). Those copied sections were the self-distilled MTP drafter, the vision projector, the expert profile, and the tokenizer. The version-2 migration dropped the profile section. The vocabulary matched, which is what `--sections-from` requires.

After conversion the n-gram was still IQ4\_NL (26.8 GiB). It was then replaced with the Q8\_0 table from that same official pack, copied byte for byte.

*   tensor: `per_layer_token_embd.weight`, shape `[160, 320001536]`, type Q8\_0, 54,400,261,120 bytes
*   sha256: `e02bf3d78153f7c95390ffca1b4279776c90ef302a345aa56bf6b3b694d65e42`

Routed experts stay 46.84 GiB IQ3\_S.

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt#file-format)
File format
--------------------------------------------------------------------------------------------------------------------

Basalt 0.2.0 reads `.basalt` version 2 and refuses version 1. This file was migrated from the previous upload with `tools/migrations/basalt_v1_to_v2.py`. Every weight section was copied byte for byte (the script checks each section's SHA-256 against the source table). The `profile` section is gone; the engine ships that placement in `data/profiles`. The `hc8` section is the int8 hyper-connection table the engine used to build on every start, stored in the file. File size: 113,491,281,169 bytes (105.7 GiB). The previous version-1 file was 112,780,347,059 bytes.

This was not scored as a refusal eval. What was measured, on a 3× RTX 5060 Ti 16 GB box with Basalt `--spec 8` and a 37 GiB expert RAM budget:

|     | this pack | official IQ3\_S, same box, same morning |
| --- | --- | --- |
| experts only in the file | 1.5 GiB (3%) | 1.3 GiB (3%) |
| hard harness | 14/14 in 47 s | 14/14 |
| 4k prefill | 1851 tok/s |     |
| decode prose / code | 82.5 / 94.8 tok/s | 83.7 / 90.2 tok/s |
| MTP accept, prose / code | 0.62 / 0.65 | ~0.61 |

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt#run)
Run
----------------------------------------------------------------------------------------------------

    hf download Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt Qwen3.8-FN-GSQ-RCO-abliterated-IQ3_S-Q8PLE.basalt


Point Basalt's `server.model` at that file. The pack carries no engine flags. The Hub's side download box only lists GGUF, so this file is under Files and versions.

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt#sources)
Sources
------------------------------------------------------------------------------------------------------------

*   Experts: [SC117 abliterated IQ3\_S](https://huggingface.co/SC117/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-GGUF)
    , itself a transplant into [ISTA-DASLab GSQ-RCO](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)
    .
*   MTP, vision, profile, tokenizer, and the Q8 n-gram table: [Shockem/Qwen3.8-FN-GSQ-RCO-IQ3\_S-Q8PLE-basalt](https://huggingface.co/Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt)
    , which spliced that table out of the official NVFP4 Basalt pack.
*   Base model: [Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)
    .
*   Engine: [Basalt](https://github.com/jesdga95/basalt)
    , a fork of [Strata](https://github.com/Niko1221/Strata)
    .

If you use the GSQ-RCO experts, please cite GSQ (arXiv:2604.18556) and RCO (arXiv:2605.00649).

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt#license)
License
------------------------------------------------------------------------------------------------------------

[Qwen Community License 1.0](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt/tree/main/LICENSE)
. The Basalt engine itself is MIT. These weights are not. The SC117 model card says Apache-2.0; that does not fit Qwen-derived weights, so this repo uses the Qwen license.

Downloads last month

\-

Downloads are not tracked for this model. [How to track](https://huggingface.co/docs/hub/models-download-stats)

Inference Providers [NEW](https://huggingface.co/docs/inference-providers)

This model isn't deployed by any Inference Provider. [🙋 Ask for provider support](https://huggingface.co/spaces/huggingface/InferenceSupport/discussions/new?title=Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt&description=React%20to%20this%20comment%20with%20an%20emoji%20to%20vote%20for%20%5BShockem%2FQwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt%5D(%2FShockem%2FQwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt)%20to%20be%20supported%20by%20Inference%20Providers.%0A%0A(optional)%20Which%20providers%20are%20you%20interested%20in%3F%20(Novita%2C%20Hyperbolic%2C%20Together%E2%80%A6)%0A)

Model tree for Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3\_S-Q8PLE-Basalt[](https://huggingface.co/docs/hub/model-cards#specifying-a-base-model)

---------------------------------------------------------------------------------------------------------------------------------------------------------

Base model

[Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)

Finetuned

([129](https://huggingface.co/models?other=base_model:finetune:Qwen/Qwen3.8-Flash-Next)
)

this model

Collection including Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3\_S-Q8PLE-Basalt
---------------------------------------------------------------------------------------

[My quants for Basalt • 4 items • Updated about 7 hours ago](https://huggingface.co/collections/Shockem/basalt-packages)

Papers for Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3\_S-Q8PLE-Basalt
-----------------------------------------------------------------------------

[Paper • 2605.00649 • Published May 7 • 15](https://huggingface.co/papers/2605.00649)

[Paper • 2604.18556 • Published Apr 20 • 26](https://huggingface.co/papers/2604.18556)

Inference providers allow you to run inference using different serverless providers.

</details>

<details><summary>Tool result · web_scrape · call_0dc310fa64d2402db20b246a</summary>

[](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3#qwen38-27b-gsq-rco-iq3_s-ninfer-v3-artifact)
Qwen3.8-27B GSQ-RCO IQ3\_S, NInfer v3 artifact
=================================================================================================================================================================

A [NInfer](https://github.com/Neroued/ninfer)
 **v3** artifact of ISTA-DASLab's [Qwen3.8-27B GSQ-RCO IQ3\_S](https://huggingface.co/ISTA-DASLab/Qwen3.8-27B-GSQ-RCO-GGUF)
 (3.5 bits per weight) for **NInfer-all**, the `master` branch of [iamwavecut/ninfer-all](https://github.com/iamwavecut/ninfer-all)
, which serves the RTX 3090, RTX 4090, RTX 5090 and RTX PRO 6000 Blackwell. The GGUF assigns a ggml quantization type to every tensor; this artifact keeps each tensor's ggml blocks byte for byte, so nothing is requantized, and the engine multiplies the blocks in place. Stock NInfer builds refuse this file: the `gguf_*` formats exist only in that line, from commit [`8706bfc0`](https://github.com/iamwavecut/ninfer-all/commit/8706bfc078bc35bd571494f9904217e9fbe11c41)
 on.

[](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3#what-is-inside)
What is inside
----------------------------------------------------------------------------------------------------

| component | representation |
| --- | --- |
| text projections (64 layers) | the GGUF's own blocks, one type per tensor: IQ3\_S, IQ3\_XXS, IQ4\_XS, Q4\_K, IQ2\_S, Q2\_K, IQ2\_XS, IQ2\_XXS and one IQ1\_M, 3.5 bits per weight on average |
| output head, token table | Q4\_K, IQ2\_S, as in the GGUF |
| MTP head | the GGUF's Q6\_K next-token head |
| GDN A/B controls, norms, convolution, `A_log`, `dt_bias` | BF16/FP32, restored from llama.cpp's exporter conventions (grouped value heads, `w` instead of `1 + w`, `A_log` from `-exp(A_log)`); the GDN output projection keeps its stored column order and reads its input through a recorded permutation |
| DFlash2 adapter | [z-lab/Qwen3.8-27B-DFlash2](https://huggingface.co/z-lab/Qwen3.8-27B-DFlash2)<br>, Q8 |
| proposal head | the output head's own Q4\_K rows for the 131,072 most frequent tokens of NInfer's token ranking |
| Vision tower | the release's BF16 projector, groupwise Q4/Q5/Q6/Q8 as in the official artifact |
| chat template | NInfer's pinned `qwen3_8.jinja` |

One `.ninfer` file of 15,017,456,896 bytes (13.99 GiB; 10.95 GiB of text weights are resident without Vision and drafters), next to its conversion report, `SHA256SUMS` and `NOTICE`.

Conversion command, from the repository's tree:

    python3 -m tools.convert \
      --model Qwen3.8-27B \
      --recipe qwen3_8_27b_gguf \
      --source gguf=Qwen3.8-27B-GSQ-RCO-IQ3_S-mtp.gguf \
      --source vision=mmproj-Qwen3.8-27B-BF16.gguf \
      --source dflash2=Qwen3.8-27B-DFlash2 \
      --components text,vision,mtp,dflash2 \
      --resource chat_template.jinja=tools/chat_templates/qwen3_8.jinja \
      --proposal \
      --name qwen3.8-27b \
      --out Qwen3.8-27B-GSQ-RCO-IQ3_S-ninfer-v3.ninfer


`--model` needs only the base model's configuration and tokenizer files.

[](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3#running)
Running
--------------------------------------------------------------------------------------

A single stream with MTP from the [Docker image](https://github.com/iamwavecut/ninfer-all#docker)
 (an NVIDIA driver of the CUDA 13 branch, 580 or newer, and the NVIDIA Container Toolkit):

    hf download WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3 Qwen3.8-27B-GSQ-RCO-IQ3_S-ninfer-v3.ninfer --local-dir models
    docker run --rm --gpus all -p 8080:8080 --ulimit memlock=-1 \
      -v "$PWD/models:/models" -v ninfer-cache:/cache \
      ghcr.io/iamwavecut/ninfer-all serve /models/Qwen3.8-27B-GSQ-RCO-IQ3_S-ninfer-v3.ninfer \
      --model-id qwen3.8-27b --max-context 176128 --kv-capacity 176128 --kv-dtype rk8v4 \
      --gdn-state-fp16 --spec mtp --draft-tokens 3


The server answers OpenAI and Anthropic requests on `http://localhost:8080/v1`. A build of `master` ([its README](https://github.com/iamwavecut/ninfer-all#building)
; `CMAKE_CUDA_ARCHITECTURES` is `86`, `89` or `120a`, and `120a` needs CUDA 13.1 or newer) takes the same flags:

    ninfer-serve models/Qwen3.8-27B-GSQ-RCO-IQ3_S-ninfer-v3.ninfer --model-id qwen3.8-27b \
      --max-context 176128 --kv-capacity 176128 --kv-dtype rk8v4 --gdn-state-fp16 \
      --spec mtp --draft-tokens 3


176,128 tokens fit a 24 GB card; an RTX 5090 takes the full 262,144. `--spec dflash2 --draft-tokens 5` drafts with the DFlash2 adapter instead; `--vision` adds images. Products of up to eight tokens (decode, verification) decode each weight once for every token and dot it with ggml's q8\_1 activations; prompts run llama.cpp's integer tensor-core kernel, vendored into the engine. [GGUF block formats](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md)
 describes both.

[](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3#quality)
Quality
--------------------------------------------------------------------------------------

WikiText-2 test perplexity with the protocol of the GSQ-RCO model card (the test rows joined by blank lines, disjoint 2,048-token windows; `ninfer-perplexity --context 2048 --disjoint`, BF16 KV):

| model | perplexity |
| --- | --- |
| **this artifact** | **7.071** |
| GSQ-RCO IQ3\_S, as its model card states | 7.07 |
| BF16 Qwen3.8-27B, as the GSQ-RCO card states | 7.05 |
| official Qwen3.8-27B NInfer artifact (Q4/Q5 groups) | 7.286 |

Reasoning, with NInfer's [capability evaluation](https://github.com/iamwavecut/ninfer-all/blob/master/eval/README.md)
 (EvalScope 1.10.0, temperature 1.0, one sampled run each, RTX 5090), the protocol the official artifact was scored with:

| benchmark | this artifact | official Qwen3.8-27B NInfer artifact |
| --- | --- | --- |
| IFBench (prompt-level strict) | **80.33%** | 77.67% |
| AIME 2025 | **100.00%** | 96.67% |
| AIME 2026 | **100.00%** | 96.67% |
| GPQA-Diamond | **88.38%** | 87.37% |

The GSQ-RCO card reports 100 on AIME 2025 and 89.39 on GPQA-Diamond for this quantization with its own protocol (BF16: 100 and 89.90). One run of GPQA-Diamond's 198 questions varies by about two points.

[](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3#speed)
Speed
----------------------------------------------------------------------------------

September 2026, `rk8v4` KV, one request at a time, greedy, thinking off, measured with the repository's reference client (`tools/bench/refbench.py`). Every row pairs this artifact with the official Qwen3.8-27B NInfer artifact on the same card in the same sitting: an RTX 3090 at 420 W and an RTX 4090 at 450 W with a 176,128-token window (the official DFlash2 row on the RTX 4090 at 167,936), an RTX 5090 at 450 W with 262,144. Short chat is the mean decode rate over five 512-token answers.

|     | RTX 3090 | RTX 4090 | RTX 5090 |
| --- | --- | --- | --- |
| short chat, no speculation | **59.9** / 40.3 tok/s | **70.6** / 55.0 tok/s | **107.5** / 88.1 tok/s |
| short chat, MTP, 3 drafts | **108.7** / 82.7 tok/s | **146.4** / 109.3 tok/s | **221.4** / 178.1 tok/s |
| short chat, DFlash2, 5 drafts | **115.6** / 109.2 tok/s | **169.4** / 141.3 tok/s | **226.5** / 222.5 tok/s |
| decode after 32K tokens, no speculation | **50.4** / 38.4 tok/s | **66.0** / 52.2 tok/s | **100.3** / 83.2 tok/s |
| time to first token, 8K prompt | **4.95** / 5.43 s | **2.21** / 3.17 s | **2.01** / 2.23 s |
| time to first token, 32K prompt | **20.5** / 22.2 s | **9.3** / 12.8 s | **8.6** / 9.3 s |
| device memory, idle, no speculation | 17.3 / 21.3 GiB | 17.5 / 21.4 GiB | 19.3 / 23.6 GiB |

(this artifact / the official one). The official artifact's published reference numbers, measured on other boards (RTX 3090 at 390 W, RTX 5090 at 575 W), are 48.2 / 97.2 / 117.1 tok/s on the RTX 3090, 54.8 / 109.0 / 138.1 on the RTX 4090 and 92.0 / 184.7 / 221.0 on the RTX 5090 for the three short-chat rows.

[](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3#credits-and-license)
Credits and license
--------------------------------------------------------------------------------------------------------------

Quantized weights: ISTA-DASLab, Qwen3.8-27B GSQ-RCO GGUFs, produced with [GSQ](https://arxiv.org/abs/2604.18556)
 and [RCO](https://arxiv.org/abs/2605.00649)
 from Qwen/Qwen3.8-27B. DFlash2 adapter: z-lab. Tokenizer and frontend resources: Qwen/Qwen3.8-27B. All are Apache-2.0; their attribution notices are collected in [`NOTICE`](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3/tree/main/NOTICE)
. This repository only re-packs those weights into NInfer's container.

Downloads last month

65,582

Inference Providers [NEW](https://huggingface.co/docs/inference-providers)

[Image-Text-to-Text](https://huggingface.co/tasks/image-text-to-text "Learn more about image-text-to-text")

This model isn't deployed by any Inference Provider. [🙋 Ask for provider support](https://huggingface.co/spaces/huggingface/InferenceSupport/discussions/new?title=WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3&description=React%20to%20this%20comment%20with%20an%20emoji%20to%20vote%20for%20%5BWaveCut%2FQwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3%5D(%2FWaveCut%2FQwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3)%20to%20be%20supported%20by%20Inference%20Providers.%0A%0A(optional)%20Which%20providers%20are%20you%20interested%20in%3F%20(Novita%2C%20Hyperbolic%2C%20Together%E2%80%A6)%0A)

Model tree for WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3\_S-NInfer-v3[](https://huggingface.co/docs/hub/model-cards#specifying-a-base-model)

-----------------------------------------------------------------------------------------------------------------------------------

[ISTA-DASLab/Qwen3.8-27B-GSQ-RCO-GGUF](https://huggingface.co/ISTA-DASLab/Qwen3.8-27B-GSQ-RCO-GGUF)

[z-lab/Qwen3.8-27B-DFlash2](https://huggingface.co/z-lab/Qwen3.8-27B-DFlash2)

Merge model

this model

Papers for WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3\_S-NInfer-v3
-------------------------------------------------------

[Paper • 2605.00649 • Published May 7 • 15](https://huggingface.co/papers/2605.00649)

[Paper • 2604.18556 • Published Apr 20 • 26](https://huggingface.co/papers/2604.18556)

Inference providers allow you to run inference using different serverless providers.

</details>

## Assistant · #12

<details><summary>Reasoning · 1,614 characters</summary>

We have initial. Need review upstream basalt and ninfer-all. Need likely compare format docs. Need inspect ninfer-all docs for gguf.md, artifacts, maybe Flash Next model type. Also basalt repo docs, file format. Need compare .basalt vs .ninfer. The user's model Shockem is Qwen3.8-Flash-Next, 105.7 GiB because includes Q8 PLE n-gram 54.4 GiB + experts 46.84 GiB etc. WaveCut recognized is Qwen3.8-27B 14 GiB (dense? not Flash Next). Important: They are not same model type: Shockem is Qwen3.8-Flash-Next MoE, WaveCut is Qwen3.8-27B dense (Qwen3.5 Dense?) maybe Qwen3.8-27B. The size difference is not due to .ninfer vs .basalt port unification, but due to model architecture/quantization/components: Flash Next has routed experts and huge PLE table. NInfer v3 artifact is Qwen3.8-27B, not Flash Next. If engine recognizes WaveCut .ninfer, it isn't running your Flash Next .basalt. Need check ninfer-all support for Flash Next .ninfer artifacts maybe there are WaveCut Flash Next? Search. User says both .basalt and .ninfer unified along front of Flash Next model type? Need investigate if ninfer-all added Flash Next and whether can ingest .basalt? Need compare container formats: .basalt is fork of Strata, likely sectioned GGUF-like container? NInfer v3 .ninfer container with sections, GGUF block passthrough. They may share "front" model type but differ in container/metadata/tensor naming/sectioning. Need get docs.

Let's read ninfer-all README sections. Need use context_read resource a501cadf... sections. Section 2 likely What's New/Models; section 4 Flash-Next n-gram tables maybe relevant. Let's open.


</details>

<details><summary>Tool request · context_read · call_f81e8ad1c6f14e279b24ef7e</summary>

```json
{
  "kind": "resource",
  "id": "a501cadf-6b4b-441d-bb56-6d55b3b8cddd",
  "section": 2
}
```

</details>

<details><summary>Tool request · context_read · call_3d059698dbad476186c239e6</summary>

```json
{
  "kind": "resource",
  "id": "a501cadf-6b4b-441d-bb56-6d55b3b8cddd",
  "section": 4
}
```

</details>

<details><summary>Tool request · context_read · call_420ce31cc1b74eab8d1a92f1</summary>

```json
{
  "kind": "resource",
  "id": "a501cadf-6b4b-441d-bb56-6d55b3b8cddd",
  "section": 5
}
```

</details>


<details><summary>Tool result · context_read · call_f81e8ad1c6f14e279b24ef7e</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all · section 2/7

*   **2026-11-16:** [System One image boxes and image URLs](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#image-boxes)
    , [`--media-urls`](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#media-urls)
     that sets the size of a fetched media URL (URLs are refused without it), and Qwen3.8-27B GGUFs with a [condensed vocabulary](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#a-condensed-vocabulary)
    .
*   **2026-11-13:** [Edge0-145B and Edge0-120B](https://github.com/iamwavecut/ninfer-all/blob/master/docs/edge0.md)
    , latent-MoE models on the Flash-Next skeleton, converted from Edge0's release folders and [published](https://github.com/iamwavecut/ninfer-all#artifacts)
     for all four releases with the base model's Vision tower, ggml's [NVFP4 blocks](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md)
    , Flash-Next and Edge0 models reading [either family's n-gram table](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#another-table-of-the-same-shape)
    , [DSpine drafting](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#speculative-decoding)
     in every family from a drafter artifact of its own (`--spec dspine --draft-model`) with [Tencent's Qwen3.8-27B drafter converted](https://huggingface.co/WaveCut/Qwen3.8-27B-DSpine-b16-NInfer-v3)
    , [`--adaptive-mtp` for DFlash, DFlash2 and DSpine](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#adaptive-mtp)
     on Qwen3.5-core models, and DeepSeek-V4.1 [hot Engram rows in RAM](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#the-hot-row-profile)
     (`--ngram-residency ram-hot`), with a hot-row profile in the published Engram table and in [Edge0's FP8 n-gram table](https://github.com/iamwavecut/ninfer-all/blob/master/docs/edge0.md)
    .
*   **2026-11-12:** [Launch configuration files](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#launch-configuration-files)
     (`--config`), with [one for each launch recipe](https://github.com/iamwavecut/ninfer-all/blob/master/docs/recipes.md)
     in `configs/`.
*   **2026-11-11:** [Faster prefill](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen3_5-model.md#prefill-decode-and-mtp)
     and [request preparation](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen3_5-model.md#request-preparation)
     in every family, disk experts read [from a second drive or straight into GPU memory](https://github.com/iamwavecut/ninfer-all/blob/master/docs/expert-disk-reads.md)
     (`--expert-mirror`, `--expert-direct`), and [Gumbel-max sampling with drafts drawn the same way](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#speculative-decoding)
     (`--gumbel-sampling`).
*   **2026-11-10:** [DFlash2 drafting for Qwen3.6-35B-A3B](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#speculative-decoding)
    , Flash-Next artifacts of [Unsloth's Dynamic v3.1 GGUFs](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#convert)
    , Flash-Next prompts past 8,192 tokens [prefilling 1.1-1.4 times as fast](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#expert-placements)
     with host or disk experts, Qwen3.5-core prompts that the hybrid cache taps [prefilling in one pass](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/hybrid-prefix-cache-spec.md#72-in-pass-exact-taps)
     (a 213-token first prompt 11% sooner), the hybrid cache over pipeline stages and tensor parallelism with [`--use-alt-prefix-caching`](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#server-options)
    , DeepSeek-V4.1 [attention caches in the release's FP8/FP4 codes](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#what-runs)
    , DSpark drafting with host or disk experts [keeping 64 drafter experts a block on the GPU](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#the-drafters-experts)
    , 1.12 times as fast on an RTX 4090 (`--draft-experts`), Flash-Next with device experts [decoding 1.10 times as fast](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#execution)
     (1.12 with MTP), and context lookup that [keeps the occurrence it copies](https://github.com/iamwavecut/ninfer-all/blob/master/docs/flint.md#measurements)
    , 1.06-1.40 times as fast on answers that copy one of two versions of a file (`--lookup-ngram`), and [`--kv-dtype bf16p`](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#context-and-memory)
    , BF16's KV bits in 23% fewer bytes.
*   **2026-11-07:** Flash-Next [media prompts in the context cache](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#media-conversations-on-one-rtx-4090)
     and [MTP drafts for media requests](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#mtp-speculative-decoding)
    .
*   **2026-11-06:** Faster Q4\_K [prompts](https://github.com/iamwavecut/ninfer-all/blob/master/docs/device-profiles.md#what-is-calibrated)
     for dense layers and routed experts.
*   **2026-11-05:** Faster DeepSeek-V4.1 [prefill tail](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#the-prefill-tail)
    , [IQ1\_M expert prompts](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#iq1_m-experts-in-prompt-chunks)
     and [Engram reads](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#the-engram-table)
    .
*   **2026-11-04:** Flash-Next [DFlash2 drafting](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#dflash2-speculative-decoding)
    , faster Flash-Next [tensor parallelism](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/pipeline-stages.md#tensor-parallelism-of-qwen38-flash-next)
     and [concurrent requests with host experts](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#sequences-kv-and-the-context-cache)
    , [BF16 and 8-bit tensor-parallel prompt partials](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/pipeline-stages.md#tensor-parallelism)
    , faster [expert parallelism](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/pipeline-stages.md#expert-parallelism-of-the-other-moe-families)
    , and DeepSeek-V4.1-Flash [conversion of ISTA-DASLab's llama.cpp-layout GGUFs and Coder build](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#converting)
     with a [published Coder artifact](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#running)
    .
*   **2026-11-03:** Faster [tensor-parallel decode and prefill](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/pipeline-stages.md#tensor-parallelism)
     for Qwen3.5-core models and llama.cpp [control vectors and direction LoRA adapters](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#lora-adapters-and-control-vectors)
    .
*   **2026-11-02:** [Tensor parallelism](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/pipeline-stages.md#tensor-parallelism)
     selects exchange routes by size from startup timings, including peer writes.
*   **2026-10-30:** [Bundled media libraries](https://github.com/iamwavecut/ninfer-all/blob/master/docs/release-archive-linux.md#media-libraries)
    , [pre-Blackwell NVFP4](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#common-options)
    , Qwen3.5 FP32 logits, a faster first request after startup, and [prefill pacing](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#execution-behavior)
    .
*   **2026-10-29:** [Faster tensor-parallel prefill](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/pipeline-stages.md#tensor-parallelism)
    , with native NVFP4/FP8 shares on RTX 50.
*   **2026-10-27:** [Tensor parallelism](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/pipeline-stages.md#tensor-parallelism)
     speeds up decode without peer access and covers all Flash-Next layers. Qwen3.5 gains [invariant attention](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen3_5-model.md#invariant-attention)
    . The [DeepSeek-V4.1-Flash STQ drafter](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#the-stq-drafter)
     uses half the VRAM of Unsloth's drafter.
*   **2026-10-26:** Flash-Next [prefills and decodes faster with disk experts](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#expert-placements)
    . [Tensor parallelism](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/pipeline-stages.md#tensor-parallelism)
     supports all dense weight formats and DFlash. All MoE families support [expert parallelism](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/pipeline-stages.md#expert-parallelism-of-the-other-moe-families)
    . [DeepSeek-V4.1-Flash](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md)
     gains CPU-assisted expert execution, DSpark drafting, and image input.
*   **2026-10-25:** NInfer supports [DeepSeek-V4.1-Flash](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md)
     from IQ1\_M GGUF with host or disk experts. Dense Qwen3.5-core models gain `--tensor-parallel`.
*   **2026-10-24:** [Flint](https://github.com/iamwavecut/ninfer-all/blob/master/docs/flint.md#measurements)
     decodes 348 tok/s on an RTX 5090 and 210 on an RTX 4090 with host experts.
*   **2026-10-23:** NInfer supports [Flint](https://github.com/iamwavecut/ninfer-all/blob/master/docs/flint.md)
     from Unsloth's UD-Q4\_K\_XL GGUF. [Native releases](https://github.com/iamwavecut/ninfer-all/releases)
     cover Windows and Debian 13 with CUDA 12.9 and 13.4.
*   **2026-10-22:** [Typed decisions](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#typed-decisions)
     are available at `/v1/decisions` and `/v1/systemone`. Every model family supports YaRN.
*   **2026-10-20:** [CPU threads compute a share of host experts](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#the-cpu-share)
     beside the GPU.
*   **2026-10-18:** The hybrid prefix cache is the server default.
*   **2026-10-17:** [Pipeline stages across GPU architectures](https://github.com/iamwavecut/ninfer-all/blob/master/docs/build-linux.md#cards-of-several-architectures-in-one-pipeline)
     in one build.
*   **2026-10-16:** [Device profiles](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gpus.md)
     for 36 more GPUs; Gemma 4 and Qwen MoE experts in host memory or on disk.
*   **2026-10-14:** Turing (`sm_75`): the [TITAN RTX](https://github.com/iamwavecut/ninfer-all/blob/master/docs/performance/titan-rtx-2026-10.md)
     and RTX 20 series.
*   **2026-10-12:** Volta (`sm_70`): the [Tesla V100](https://github.com/iamwavecut/ninfer-all/blob/master/docs/performance/tesla-v100-2026-10.md)
    .
*   **2026-10-11:** [Gemma 4 26B-A4B](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gemma4.md)
     with MTP, images and video.
*   **2026-10-06:** [Qwen3.8-Flash-Next](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)
    , experts on the GPU, in host memory or on disk.
*   **2026-09-26:** NInfer-all and [Qwen3.8-27B GSQ-RCO IQ3\_S](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3)
    .
*   **2026-09-23:** [Ternary Bonsai 2 27B](https://huggingface.co/WaveCut/Ternary-Bonsai-2-27B-NInfer-v3)
     on one RTX 3090.

Quick start
-----------

[](https://github.com/iamwavecut/ninfer-all#quick-start)



</details>

<details><summary>Tool result · context_read · call_3d059698dbad476186c239e6</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all · section 4/7
Subsection: Flash-Next n-gram tables
Tags: table

| Model | Size, GiB | Weights | Vision | MTP | DFlash2 | Proposal head | Notes |
| --- | --- | --- | --- | --- | --- | --- | --- |
| [Ternary Bonsai 2 27B](https://huggingface.co/WaveCut/Ternary-Bonsai-2-27B-NInfer-v3) | 8.87 | ternary, 2.125 bits | ✓   | ✓   | ✓   | ✓   | Bonsai-trained MTP head and DFlash2 adapter |
| Qwen3.8-27B: [official](https://huggingface.co/neroued/Qwen3.8-27B-NInfer)<br> · [GSQ-RCO IQ3\_S](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3) | 19.03 · 13.99 | groupwise-int (Q4/Q5) · GGUF blocks, 3.5 bits | ✓   | ✓   | ✓   | ✓   | the official artifact, which the reference tables use; ISTA-DASLab's GGUF blocks byte for byte with a Q6\_K MTP head |
| [Qwen3.8-27B, abliterated](https://huggingface.co/WaveCut/Huihui-Qwen3.8-27B-abliterated-NInfer-v3) | 19.03 | groupwise-int (Q4/Q5) | ✓   | ✓   | ✓   | ✓   | the official recipe |
| [Qwen3.8-27B Uncensored, HauhauCS Aggressive](https://huggingface.co/WaveCut/Qwen3.8-27B-Uncensored-HauhauCS-Aggressive-DFlash2-NInfer-v3) | 19.03 | groupwise-int (Q4/Q5) | ✓   | ✓   | ✓   | ✓   | the tune's MTP head |
| [Qwen3.8-27B MXFP8-CRACK](https://huggingface.co/WaveCut/Qwen3.8-27B-MXFP8-CRACK-NInfer-v3) | 16.96 | groupwise-int | ✓   | ✓   | —   | ✓   |     |
| [Qwen3.6-35B-A3B NVFP4](https://huggingface.co/WaveCut/Qwen3.6-35B-A3B-NVFP4-NInfer-v3) | 21.04 | NVFP4 experts, Q8 projections | ✓   | ✓   | ✓   | ✓   | RedHatAI's NVFP4 experts code for code, incoai's DFlash2 drafter; `sm_120a` GPUs only |
| Qwen3.8-Flash-Next: [GSQ-RCO Q2\_0](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-NInfer-v3)<br> · [GSQ-RCO IQ3\_S](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3)<br> · [UD-IQ2\_XS](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-UD-IQ2_XS-NInfer-v3)<br> · [UD-IQ3\_XXS](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-UD-IQ3_XXS-NInfer-v3)<br> · [n-gram tables](https://github.com/iamwavecut/ninfer-all#flash-next-n-gram-tables) | 38.23 · 54.24 · 47.43 · 54.66 | GGUF blocks: ISTA-DASLab's GSQ-RCO 2.4 · 3.5 bits, Unsloth Dynamic v3.1 | ✓   | ✓   | ✓   | —   | shared-Q8\_0 MTP, incoai's Q4\_0 DFlash2 drafter |
| Qwen3.8-Flash-Next Coder GSQ-RCO: [IQ1\_M](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-Coder-IQ1_M-NInfer-v3)<br> · [n-gram tables](https://github.com/iamwavecut/ninfer-all#flash-next-n-gram-tables) | 30.76 | GGUF blocks | ✓   | ✓   | ✓   | —   | expert-pruned coding build, 256 experts per layer; shared-Q8\_0 MTP, incoai's Q4\_0 DFlash2 drafter |
| Edge0-145B: [NVFP4](https://huggingface.co/WaveCut/Edge0-145B-NVFP4-NInfer-v3)<br> · [q3k](https://huggingface.co/WaveCut/Edge0-145B-q3k-NInfer-v3)<br> · [n-gram tables](https://github.com/iamwavecut/ninfer-all#flash-next-n-gram-tables) | 54.41 · 47.43 | NVFP4 · Q3\_K/IQ4\_NL latent experts, Q8\_0 encoders and decoders | ✓   | ✓   | —   | —   | Edge0's release byte for byte, the base model's Vision tower; experts in host memory or on disk on one 48 GB card |
| Edge0-120B: [NVFP4](https://huggingface.co/WaveCut/Edge0-120B-NVFP4-NInfer-v3)<br> · [q3k](https://huggingface.co/WaveCut/Edge0-120B-q3k-NInfer-v3)<br> · [n-gram tables](https://github.com/iamwavecut/ninfer-all#flash-next-n-gram-tables) | 39.58 · 34.60 | NVFP4 · Q3\_K/IQ4\_NL latent experts, Q4\_0 encoders and decoders | ✓   | ✓   | —   | —   | Edge0's release byte for byte, the base model's Vision tower; every expert on one 48 GB card |
| [Gemma 4 26B-A4B it QAT](https://huggingface.co/WaveCut/gemma-4-26B-A4B-it-QAT-Q4_0-MTP-NInfer-v3) | 14.75 | GGUF Q4\_0 blocks | ✓   | ✓   | —   | —   | Google's QAT GGUF byte for byte; the MTP column is Google's QAT assistant |
| [Flint UD-Q4\_K\_XL](https://huggingface.co/WaveCut/Flint-UD-Q4_K_XL-NInfer-v3) | 23.38 | GGUF blocks, Q8\_0 to IQ3\_S | —   | —   | —   | —   | Unsloth's UD-Q4\_K\_XL GGUF byte for byte; drafts by context lookup |
| DeepSeek-V4.1-Flash-1017 GSQ-RCO: [IQ1\_M](https://huggingface.co/WaveCut/DeepSeek-V4.1-Flash-1017-GSQ-RCO-IQ1_M-NInfer-v3)<br> · [Engram table](https://huggingface.co/WaveCut/DeepSeek-V4.1-Flash-Engram-IQ4_NL-NInfer-v3) | 117.18 · 103.32 | GGUF blocks, IQ1\_S to IQ2\_S experts | ✓   | —   | —   | —   | ISTA-DASLab's GGUF byte for byte; experts in host memory or on disk; the release's vision tower (images); the release's DSpark drafter in beamster's STQ encoding (`--spec dspark`), or context lookup |
| DeepSeek-V4.1-Flash-1017 GSQ-RCO Coder: [IQ2\_XXS](https://huggingface.co/WaveCut/DeepSeek-V4.1-Flash-1017-GSQ-RCO-Coder-IQ2_XXS-NInfer-v3)<br> · [Engram table](https://huggingface.co/WaveCut/DeepSeek-V4.1-Flash-Engram-IQ4_NL-NInfer-v3) | 71.85 · 103.32 | GGUF blocks, IQ1\_M to IQ2\_XS experts | ✓   | —   | —   | —   | ISTA-DASLab's expert-pruned coding build byte for byte, 192 of 384 experts per block; otherwise as the IQ1\_M artifact |

DeepSeek-V4.1-Flash models read the Engram table in their row, which the model names by digest; pass it with `--ngram-table`. The Engram table holds the release's IQ4\_NL rows. Tencent's [DSpine drafter for Qwen3.8-27B](https://huggingface.co/WaveCut/Qwen3.8-27B-DSpine-b16-NInfer-v3)
 (2.27 GiB, Q8 layers and a BF16 code bridge) is an artifact of its own, which `--spec dspine --draft-model` loads beside any Qwen3.8-27B artifact.

### Flash-Next n-gram tables

[](https://github.com/iamwavecut/ninfer-all#flash-next-n-gram-tables)

Every Qwen3.8-Flash-Next and Edge0 model reads any table below with `--ngram-table`. A model names the table it was converted with, and the engine accepts any table of the model's shape, in any row format ([another table of the same shape](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#another-table-of-the-same-shape)
). Perplexity: the first 40 KB of WikiText, INT8 KV, one A40.

| Table | Size, GiB | Rows | Hot-row profile | Named by | Perplexity: Flash-Next Q2\_0 · Edge0-120B-q3k |
| --- | --- | --- | --- | --- | --- |
| [IQ4\_NL](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3) | 26.92 | IQ4\_NL blocks, 90 bytes a row: the GSQ-RCO and Unsloth releases' table byte for byte | ✓   | Flash-Next builds, Coder | 2.542153 · 5.017691 |
| [FP8](https://huggingface.co/WaveCut/Edge0-ngram-table-FP8-NInfer-v3) | 48.38 | FP8 E4M3 codes and an FP16 scale, 162 bytes a row: Edge0's `ple-fp8.gguf` codes byte for byte, its one scale in every row | ✓   | Edge0 builds | 2.531971 · 4.964565 |

The official NInfer artifacts (Qwen3.6-27B, Qwen3.6-35B-A3B and Qwen3.8-27B, `groupwise-int` and `nvfp4`) load too; the [documentation map](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md#model-artifacts)
 links them. Weight conversion shows how the [Bonsai](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#ternary-bonsai-2-27b)
 and [GSQ-RCO](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#a-mixed-precision-qwen38-27b-gguf)
 artifacts are built.

Highlights
----------

[](https://github.com/iamwavecut/ninfer-all#highlights)

Ternary Bonsai 2 27B decodes 397 tok/s on an RTX 5090 with DFlash2 and holds a 978,944-token context with every planted code found. Qwen3.8-Flash-Next decodes 138 tok/s with every expert on one RTX PRO 6000, and 96 tok/s with its experts in host memory on one RTX 5090. DeepSeek-V4.1-Flash decodes 52 tok/s on one RTX 5090, 48 on one RTX PRO 6000 and 39 on one RTX 4090 with its 106.7 GiB of experts in host memory. Every table of every card is on the [performance page](https://github.com/iamwavecut/ninfer-all/blob/master/docs/performance.md)
.

_Click a section to expand it._

**Ternary Bonsai 2 27B** — up to 397 tok/s, a million tokens of context

Measured in September 2026, one card each, greedy, one request unless the column says otherwise.

| Card | Short chat, DFlash2 7 drafts (tok/s) | After a 261K-token document (tok/s) | 261K-token prompt, to the first token | Largest context, all three codes found | Eight requests at once, MTP 3 (tok/s) |
| --- | --- | --- | --- | --- | --- |
| RTX 3090 | 202 | 90  | 215 s | 970,752 | 551 |
| RTX 4090 | 256 | 123 | 102 s | 958,464 | 824 |
| RTX 5090 | 397 | 218 | 82 s | 978,944 | 1,063 |
| RTX PRO 6000 | 381 | 218 | 78 s | 1,048,576, two of three codes | 1,155 |

The RTX PRO 6000 (96 GB) starts at the engine's ceiling of 1,048,576 tokens with every KV format and drafter. Filled to it, the model misses the code at 90% (about 943K); up to about 880K it found every code on every card.

**Qwen3.8-27B** — up to 237 tok/s, 872,448 tokens of context filled

The official `groupwise-int` artifact, measured in September 2026, one card each, greedy, one request unless the column says otherwise.

| Card | Short chat, DFlash2 7 drafts (tok/s) | Largest context, all three codes found | Eight requests at once, MTP 3 (tok/s) |
| --- | --- | --- | --- |
| RTX 3090 | 118 | 417,792 | 329 |
| RTX 4090 | 149 | 405,504 | 442 |
| RTX 5090 | 236 | 872,448 | 690 |
| RTX PRO 6000 | 237 | 1,048,576, two of three codes | 739 |

*   **RTX PRO 6000 against RTX 5090.** Re-measured in October beside an RTX 5090, both at 600 W, the PRO 6000 came back within 2% of September wherever the drafts accepted the same share. One request's decode is bound by memory bandwidth, and both cards have 1.79 TB/s of GDDR7 (Bonsai 2 without speculation: 167.7 against 170.4 tok/s). The PRO 6000's 188 SMs against 170 show where compute decides: the 261K prompt is 2% faster and eight requests at once 6 to 7% faster ([re-check](https://github.com/iamwavecut/ninfer-all/blob/master/docs/performance.md#rtx-pro-6000-against-rtx-5090-october-2026)
    ).
*   **Draft length.** DFlash2 with seven drafts is fastest on short answers; after long documents the best count is three to seven. MTP runs up to fifteen drafts and is fastest at three to five.

**Qwen3.8-Flash-Next** — 138 tok/s with the experts on a GPU, 98 tok/s from host memory

The Q2\_0 release (35.9 GiB model and 26.8 GiB n-gram table), one request, greedy, October 2026. Decode of a short answer, in tok/s:

| Card | Every expert on the GPUs | Experts in host memory | Experts on disk, in the page cache | Experts on disk, cold |
| --- | --- | --- | --- | --- |
| RTX PRO 6000 | 138 (one card) | 55  | 76  | 35  |
| RTX 5090 | 136 (two cards) | 98  | 72  | 38  |
| RTX 4090 | 97 (two cards) | 74  | 47  | 21  |
| RTX 3090 | 90 (two RTX 3090 Ti) | 39  | 28  | 20  |

Prefill of a 4,463-token prompt, in tok/s:

| Card | Every expert on the GPUs | Experts in host memory | Experts on disk, in the page cache | Experts on disk, cold |
| --- | --- | --- | --- | --- |
| RTX PRO 6000 | 2,939 | 1,297 | 2,024 | 1,000 |
| RTX 5090 | 3,809 | 3,290 | 1,827 | 1,108 |
| RTX 4090 | 3,608 | 1,801 | 1,144 | 558 |
| RTX 3090 | 1,504 | 663 | 503 | 474 |

*   **The host matters.** Host and disk rows depend on the host as much as on the card. The RTX 5090 host had PCIe 5.0 x16, the RTX PRO 6000 and RTX 4090 hosts PCIe 4.0 x16, and the RTX 3090 host PCIe 3.0 x16 and two sockets (the test ran pinned to the GPU's node). The host, disk and cold columns of the three GeForce cards were measured on October 26, the rest on October 5 and 6.
*   **Prompt spans.** With host or disk experts a prompt prefills in spans of up to eight chunks (sixteen for one request at a time), so each layer's missing experts cross the bus once per span. From the CLI with Q2\_0 disk experts in the page cache, a 7,680-token prompt prefilled at 1,830 tok/s on the RTX 5090 and the answer decoded at 115 tok/s, against 450 and 32 chunk by chunk ([three cards](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#expert-placements)
    ).
*   **Other releases and cards.** IQ3\_S, the Coder IQ1\_M build and the 8 and 12 GB cards are in the [expert placements](https://github.com/iamwavecut/ninfer-all/blob/master/docs/performance.md#expert-placements)
    . Six reasoning requests at once on two RTX 5090s produced 193 tok/s of output with Q2\_0.



</details>

<details><summary>Tool result · context_read · call_420ce31cc1b74eab8d1a92f1</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all · section 5/7
Tags: table

**DeepSeek-V4.1-Flash** — 52 tok/s on one RTX 5090, 48 on one RTX PRO 6000 (DSpark: 1.3 to 2.1 times as fast), 34 to 39 on one RTX 4090

ISTA-DASLab's GSQ-RCO IQ1\_M GGUF (112.7 GiB, and its 103.0 GiB Engram table), one request, greedy, thinking off, one GPU, October 2026. The routed experts stay in pinned host memory or in the file, the card caches as many as fit, and CPU threads compute a share of each decode call's missing host experts:

| Card | Experts cached on the card | Host experts: short answer (tok/s) | after 8,086 tokens (tok/s) | prefill of 8,086 tokens (tok/s) | Disk experts, page cache warm: short answer (tok/s) |
| --- | --- | --- | --- | --- | --- |
| RTX PRO 6000 | 74% | 48.0 | 45.3 | 1,310 | 37.4 |
| RTX 5090 | 15% | 51.5 | 42.2 | 912 | 16.7 |
| RTX 4090 | 7%  | 33.8 | 27.5 | 915 | 9.5 |
| RTX 3090 | 7%  | 19.8 | 15.2 | 416 | 6.0 |

The RTX PRO 6000 row is an earlier build that ran prompts chunk by chunk and copied every missing expert; the others ran on October 26 on hosts with PCIe 5.0 (RTX 5090), 4.0 (RTX 4090) and 3.0 (RTX 3090) links ([per card](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#per-card)
). On an RTX 4090 host with 64 CPU cores the build decodes at 38.9 and 31.4 tok/s, against 33.5 and 26.6 when it copies every miss ([the CPU share](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#the-cpu-share)
); there Strata 0.2.6 decodes the same GGUF at 34 to 40 tok/s, computing about half the experts on its CPU threads, and prefills at 635 to 690 tok/s ([measurements](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#measurements)
). With host experts the server peaks at 116 GiB of host memory. On October 27, with the release's DSpark drafter (`--spec dspark`, 3.58 GiB on the card in the STQ encoding the artifact carries), an RTX PRO 6000 decoded five requests 1.28 to 2.07 times as fast as without it, and an RTX 4090 decoded code and reasoning 1.19 and 1.21 times as fast, the other three requests 0.85 to 1.02 times, prefilling at plain speed ([the drafter](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#the-stq-drafter)
). With `--vision` it reads images through the release's vision tower ([images](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#images)
).

Features
--------

[](https://github.com/iamwavecut/ninfer-all#features)

_Click a section to expand it._

**Models and weight formats** — Qwen3.5 family, GGUF block formats, Ternary Bonsai 2, Flash-Next, Gemma 4, Flint, DeepSeek-V4.1-Flash

*   **Qwen3.5 family.** Dense and MoE (`Qwen3_5ForCausalLM`, `Qwen3_5MoeForCausalLM`) with MTP, DFlash (35B-A3B) and DFlash2 (Qwen3.8-27B, 35B-A3B) drafters, Vision for images and video, and `groupwise-int`, FP8, NVFP4 and ternary weights. Native MoE routed experts can stay in pinned host memory or the artifact's files, brought into whole-layer GPU banks with an optional device cache ([expert residency](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen3_5-model.md#routed-expert-residency)
    ). NVFP4 expert banks prefill through W4A4 and need a `120a` build.
*   **GGUF block formats.** Releases that pick a ggml type per tensor, such as ISTA-DASLab's GSQ-RCO, convert without requantization and multiply their blocks in place. The 3.5-bit Qwen3.8-27B IQ3\_S release holds 10.95 GiB of weights instead of 15.9, scores WikiText-2 perplexity 7.071 (the official artifact: 7.286) and decodes at 59.9 tok/s against the official artifact's 40.3 on an RTX 3090 ([GGUF block formats](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md)
    ).
*   **Ternary Bonsai 2 27B.** PrismML's [ternary Qwen3.8-27B](https://huggingface.co/prism-ml/Ternary-Bonsai-2-27B-gguf)
     runs from `t2_g128_fp16` weights: 2.125 bits per weight, imported without rounding, with the Hadamard rotations fused into the norms and gates and integer activations for its projections. The `bonsai2_27b_ternary` recipe adds ProCreations' MTP head and DFlash2 adapter and an exact proposal head.
*   **Qwen3.8-Flash-Next.** The 125B-parameter MoE (512 experts, about 6B active) from the GSQ-RCO GGUF releases, with its experts on the GPUs, in pinned host memory with a GPU cache (`--expert-residency host`) or in the artifact's files read into a GPU cache (`--expert-residency disk`, under 1 GB of RAM). It serves up to eight requests with prefix reuse, structured output, images and video, and MTP drafting. On two RTX 5090s the Q2\_0 release scores 93.3% on AIME 2025 and 86.4% on GPQA-Diamond ([Qwen3.8-Flash-Next](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)
    ).
*   **Gemma 4 26B-A4B.** Google's QAT Q4\_0 GGUF release, imported block for block (13.4 GiB), or a mixed-format GGUF of it: the sliding-window and full-attention blocks (the latter caching values only), the dense MLP beside 128 routed experts, every `--kv-dtype` format, up to eight concurrent requests with prefix reuse through host memory and shared system prompts, tool calls and structured output, images and video through the release's vision tower (on the GPU, streamed from pinned memory or on CPU threads), and Google's multi-token-prediction assistant for speculative decoding. On an RTX 3090 it prefills a 10,000-token prompt at 6,045 tok/s and decodes at 215 tok/s, 190 after 10,000 tokens, against llama.cpp's 4,697, 169 and 152 on the same GGUF; with two drafts a round chat answers decode at 291 tok/s instead of 209 ([Gemma 4](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gemma4.md)
    ).
*   **Flint.** Recursive's 39.8B coding MoE (2.5B active), from a llama.cpp GGUF such as Unsloth's UD-Q4\_K\_XL, imported block for block (23.4 GiB): sliding-window and position-free full-attention blocks with learned sinks, 256 routed experts beside a shared one, up to eight concurrent requests with prefix reuse through host memory, the model's own reasoning, GLM-4.7 tool calls, structured output, typed decisions, context-lookup drafting, and experts on the GPU, in pinned host memory or in the artifact's files. On an RTX 5090 it prefills a 10,000-token prompt at 14,656 tok/s and decodes at 348 tok/s, 315 after 10,000 tokens, against llama.cpp's 8,679, 223 and 209 on the same GGUF; on an RTX 3090, with its experts in host memory, at 5,755, 161 and 140 against llama.cpp's 2,553, 80 and 77 with four blocks' experts on the CPU ([Flint](https://github.com/iamwavecut/ninfer-all/blob/master/docs/flint.md)
    ).
*   **DeepSeek-V4.1-Flash.** DeepSeek's 40-block MoE (384 routed experts, 6 per token) from ISTA-DASLab's GSQ-RCO IQ1\_M GGUF, imported block for block, with its Engram table: four-stream hyper-connections, latent attention over a 128-position window and indexer-selected compressed latents with the release's FP8 and FP4 roundings, Engram rows read from the table's file or RAM, up to eight concurrent requests with prefix reuse through host memory, reasoning, DSML tool calls, structured output, typed decisions, images through the release's vision tower, the release's DSpark drafter and context-lookup drafting. Its 106.7 GiB of routed experts stay in pinned host memory or in the artifact's files, read into bounded buffers rather than mapped, and CPU threads compute a share of each decode call's missing host experts. Prompts run block by block in spans of up to 16,384 tokens, so each block's experts cross the bus once per span. On one RTX 4090 with its experts in host memory it decodes at 31.4 to 38.9 tok/s and prefills 8,086 tokens at 938 tok/s; on the same host Strata 0.2.6 decodes at 34 to 40 tok/s and prefills at 635 to 690 ([DeepSeek-V4.1-Flash](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md)
    ).
*   **CPU share of host and disk experts.** With Flash-Next, Gemma 4, Flint or native Qwen3.5/3.6 MoE experts off the GPU, or DeepSeek-V4.1-Flash's experts in host memory, CPU threads compute a share of each decode call's cache misses from host memory while the GPU copies the rest, bit for bit equal to the GPU's products (`--expert-dma-share auto`). The pool takes `min(physical cores, usable CPUs / 2)` threads by default, where usable CPUs are the affinity mask bounded by a container's CPU quota (15 threads on a 30-CPU quota); `--expert-cpu-threads N` sets another count ([common options](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#common-options)
    ).

**Speculative decoding** — MTP, DFlash, DFlash2, DSpark, DSpine, n-gram copying and context lookup

*   MTP, DFlash and DFlash2 with 1 to 15 drafts; the artifact's proposal head drafts by default when it stores one. Under MTP and DFlash a sampled request keeps a draft only while it equals the model's own keyed draw, so every emitted token is the model's sample; DFlash2 verifies its proposal distribution by rejection sampling.
*   Gemma 4 drafts with Google's multi-token-prediction assistant (`--spec mtp`, 1 to 7 drafts), four blocks that read the model's own KV cache; its verification rows are bit for bit plain decode rows, so the output is the one plain decoding gives.
*   DeepSeek-V4.1-Flash drafts with the release's DSpark drafter (`--spec dspark`, 1 to 5 drafts kept while its confidence holds): three blocks that read the backbone's last three blocks' streams. Its verification rows are bit for bit plain decode rows. In beamster's STQ encoding, which the published artifact carries (3.58 GiB on the card), it decodes 1.28 to 2.07 times as fast on an RTX PRO 6000; on an RTX 4090, whose expert cache it shrinks, it decodes code and reasoning 1.19 and 1.21 times as fast and other requests 0.85 to 1.02 times.
*   A DSpine drafter is an artifact of its own (`--spec dspine --draft-model PATH`): 1 to 15 drafts on Qwen3.5-core models and Qwen3.8-Flash-Next, 1 to 7 on Gemma 4, Flint and DeepSeek-V4.1. Tencent's drafter for Qwen3.8-27B, converted, decodes a code answer 3.08 times and a prose answer 1.86 times as fast as plain decoding on an RTX 5090, where DFlash2 reaches 3.29 and 2.05 ([measurements](https://github.com/iamwavecut/ninfer-all/blob/master/docs/performance.md#dspine-on-qwen38-27b)
    ).
*   Flint, which has no drafter, and DeepSeek-V4.1-Flash without `--spec` draft by context lookup (`--lookup-ngram N`, 1 to 7 drafts): what followed the last N tokens' earlier occurrence (the one the sequence was already copying while it still matches, else the newest), verified in one pass of decode rows.
*   `--adaptive-mtp` picks each round's width from measured draft survival and round cost: an MTP round's, and on Qwen3.5-core models a DFlash, DFlash2 or DSpine round's (`--draft-tokens` or half).
*   N-gram copy drafting beside the neural drafter (on with `--spec`) verifies up to 15 tokens copied from earlier prompt, tool-result or output text ([ngram copy proposals](https://github.com/iamwavecut/ninfer-all/blob/master/docs/ngram.md)
    ).

**Context and memory** — ten KV formats, up to 1,048,576 tokens, a context cache with a disk tier



</details>

## Assistant · #16

<details><summary>Reasoning · 1,871 characters</summary>

We have good. Need inspect ninfer docs for Flash-Next, gguf, weight conversion maybe artifact format. Also basalt upstream docs. Could scrape github docs raw files. Use raw.githubusercontent.com for specific. Need perhaps basalt docs and Strata docs. Need review "upstream basalt" maybe repo jesdga95/basalt. Let's scrape README/docs. Also Strata? .basalt format likely sectioned file. Need identify differences from .ninfer. Could use GitHub code search? web_scrape raw paths. We know from HF: Basalt tools/convert/convert.py --sections-from, tools/migrations/basalt_v1_to_v2.py; sections: experts, mtp, vision, profile, tokenizer, hc8, per_layer_token_embd. NInfer artifact is .ninfer v3 container with components, GGUF blocks; ngram table separate maybe not included? Wait Flash-Next NInfer artifacts sizes 38-54 GiB plus n-gram table 26.92 GiB separate? Model table says Qwen3.8-Flash-Next GSQ-RCO IQ3_S 54.24 GiB; n-gram table 26.92 GiB. Shockem .basalt 105.7 GiB includes Q8 PLE table 54.4 GiB and routed experts 46.84 GiB. The official NInfer Flash-Next IQ3_S 54.24 GiB probably excludes n-gram table? Wait total with IQ4_NL table 26.92 = 81.16. Shockem Q8 PLE table is 54.4 GiB, double IQ4_NL 26.92. If using NInfer with IQ4_NL table maybe comparable? 54.24 + 26.92 = 81.16 vs Basalt 105.7 = +24.5 due Q8 table vs IQ4_NL. But user says differs greatly (100+GB) than recognized by engine: WaveCut Qwen3.8-27B 13.99. That's different model, not Flash Next. Maybe engine also recognizes WaveCut Flash-Next IQ3_S 54.24, but user model is abliterated IQ3_S Q8PLE 105.7. Need address: if engine's recognized artifact is Qwen3.8-27B, not directly comparable. If you want same model, compare to WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3 54.24 plus ngram table. Need inspect exact HF Flash Next NInfer IQ3_S page for component sizes and conversion. Let's scrape.


</details>

<details><summary>Tool request · web_scrape · call_ac33adfeac9a4e03b7c7347c</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt"
}
```

</details>

<details><summary>Tool request · web_scrape · call_3df44bcd6c5a474f8c4e64a4</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_4f372abd408c4b37ab9c3756</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_dcbad4b85cd7470ca7a3a598</summary>

```json
{
  "url": "https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3"
}
```

</details>


<details><summary>Tool result · web_scrape · call_ac33adfeac9a4e03b7c7347c</summary>

**Firecrawl · section 1 of 2**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 10,361 characters · included below
- Section 2 · 4,210 characters · omitted from this copy

````text
[Skip to content](https://github.com/jesdga95/basalt#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt)
 to refresh your session. Dismiss alert

            [](https://github.com/jesdga95/basalt)

main

[Branches](https://github.com/jesdga95/basalt/branches)
[Tags](https://github.com/jesdga95/basalt/tags)

[](https://github.com/jesdga95/basalt/branches)
[](https://github.com/jesdga95/basalt/tags)

Go to file

Code

Open more actions menu

Latest commit
-------------

History
-------

[2,903 Commits](https://github.com/jesdga95/basalt/commits/main/)

[](https://github.com/jesdga95/basalt/commits/main/)
2,903 Commits

Folders and files
-----------------

| Name |     | Name | Last commit message | Last commit date |
| --- | --- | --- | --- |
| [.github](https://github.com/jesdga95/basalt/tree/main/.github ".github") |     | [.github](https://github.com/jesdga95/basalt/tree/main/.github ".github") |     |     |
| [assets](https://github.com/jesdga95/basalt/tree/main/assets "assets") |     | [assets](https://github.com/jesdga95/basalt/tree/main/assets "assets") |     |     |
| [cmake](https://github.com/jesdga95/basalt/tree/main/cmake "cmake") |     | [cmake](https://github.com/jesdga95/basalt/tree/main/cmake "cmake") |     |     |
| [data](https://github.com/jesdga95/basalt/tree/main/data "data") |     | [data](https://github.com/jesdga95/basalt/tree/main/data "data") |     |     |
| [docs](https://github.com/jesdga95/basalt/tree/main/docs "docs") |     | [docs](https://github.com/jesdga95/basalt/tree/main/docs "docs") |     |     |
| [include/basalt](https://github.com/jesdga95/basalt/tree/main/include/basalt "This path skips through empty directories") |     | [include/basalt](https://github.com/jesdga95/basalt/tree/main/include/basalt "This path skips through empty directories") |     |     |
| [serve](https://github.com/jesdga95/basalt/tree/main/serve "serve") |     | [serve](https://github.com/jesdga95/basalt/tree/main/serve "serve") |     |     |
| [src](https://github.com/jesdga95/basalt/tree/main/src "src") |     | [src](https://github.com/jesdga95/basalt/tree/main/src "src") |     |     |
| [tests](https://github.com/jesdga95/basalt/tree/main/tests "tests") |     | [tests](https://github.com/jesdga95/basalt/tree/main/tests "tests") |     |     |
| [tools](https://github.com/jesdga95/basalt/tree/main/tools "tools") |     | [tools](https://github.com/jesdga95/basalt/tree/main/tools "tools") |     |     |
| [.dockerignore](https://github.com/jesdga95/basalt/blob/main/.dockerignore ".dockerignore") |     | [.dockerignore](https://github.com/jesdga95/basalt/blob/main/.dockerignore ".dockerignore") |     |     |
| [.gitattributes](https://github.com/jesdga95/basalt/blob/main/.gitattributes ".gitattributes") |     | [.gitattributes](https://github.com/jesdga95/basalt/blob/main/.gitattributes ".gitattributes") |     |     |
| [.gitignore](https://github.com/jesdga95/basalt/blob/main/.gitignore ".gitignore") |     | [.gitignore](https://github.com/jesdga95/basalt/blob/main/.gitignore ".gitignore") |     |     |
| [AGENTS.md](https://github.com/jesdga95/basalt/blob/main/AGENTS.md "AGENTS.md") |     | [AGENTS.md](https://github.com/jesdga95/basalt/blob/main/AGENTS.md "AGENTS.md") |     |     |
| [CMakeLists.txt](https://github.com/jesdga95/basalt/blob/main/CMakeLists.txt "CMakeLists.txt") |     | [CMakeLists.txt](https://github.com/jesdga95/basalt/blob/main/CMakeLists.txt "CMakeLists.txt") |     |     |
| [CONTRIBUTING.md](https://github.com/jesdga95/basalt/blob/main/CONTRIBUTING.md "CONTRIBUTING.md") |     | [CONTRIBUTING.md](https://github.com/jesdga95/basalt/blob/main/CONTRIBUTING.md "CONTRIBUTING.md") |     |     |
| [Dockerfile](https://github.com/jesdga95/basalt/blob/main/Dockerfile "Dockerfile") |     | [Dockerfile](https://github.com/jesdga95/basalt/blob/main/Dockerfile "Dockerfile") |     |     |
| [LICENSE](https://github.com/jesdga95/basalt/blob/main/LICENSE "LICENSE") |     | [LICENSE](https://github.com/jesdga95/basalt/blob/main/LICENSE "LICENSE") |     |     |
| [README.md](https://github.com/jesdga95/basalt/blob/main/README.md "README.md") |     | [README.md](https://github.com/jesdga95/basalt/blob/main/README.md "README.md") |     |     |
| [THIRD\_PARTY\_LICENSES](https://github.com/jesdga95/basalt/blob/main/THIRD_PARTY_LICENSES "THIRD_PARTY_LICENSES") |     | [THIRD\_PARTY\_LICENSES](https://github.com/jesdga95/basalt/blob/main/THIRD_PARTY_LICENSES "THIRD_PARTY_LICENSES") |     |     |
| [requirements-test.txt](https://github.com/jesdga95/basalt/blob/main/requirements-test.txt "requirements-test.txt") |     | [requirements-test.txt](https://github.com/jesdga95/basalt/blob/main/requirements-test.txt "requirements-test.txt") |     |     |
| [requirements.txt](https://github.com/jesdga95/basalt/blob/main/requirements.txt "requirements.txt") |     | [requirements.txt](https://github.com/jesdga95/basalt/blob/main/requirements.txt "requirements.txt") |     |     |
| View all files |     |     |

Repository files navigation
---------------------------

![Basalt](https://github.com/jesdga95/basalt/raw/main/assets/basalt-lockup-light.png)

Basalt is a local inference engine for large language models: **Qwen3.8-Flash-Next**, **DeepSeek-V4.1-Flash** and **Qwen3.8-27B**. It runs on an NVIDIA Blackwell GPU (sm\_120) on Linux and Windows x64, with what does not fit in VRAM (the experts of a mixture-of-experts model) in system RAM, and optionally on more GPUs. The server speaks the OpenAI and Anthropic APIs. Website: [basalt.jgulfo.com](https://basalt.jgulfo.com/)
.

 [![The Basalt web UI while a reply streams](https://github.com/jesdga95/basalt/raw/main/docs/img/frontend.gif)](https://github.com/jesdga95/basalt/blob/main/docs/img/frontend.gif)
 [![The Basalt web UI while a reply streams](https://github.com/jesdga95/basalt/raw/main/docs/img/frontend.gif)](https://github.com/jesdga95/basalt/blob/main/docs/img/frontend.gif)
[](https://github.com/jesdga95/basalt/blob/main/docs/img/frontend.gif)

**Help wanted:** spare Blackwell compute for testing? See [Contributing](https://github.com/jesdga95/basalt/blob/main/CONTRIBUTING.md#other-ways-to-help)
.

Requirements
------------

[](https://github.com/jesdga95/basalt#requirements)

*   Linux x86-64 with AVX2, or Windows 10 1903+ x64 ([platforms](https://github.com/jesdga95/basalt/blob/main/docs/platforms.md)
    ).
*   An NVIDIA Blackwell GPU (compute capability 12.0) with CUDA 13.
*   CMake 3.24+, GCC 13+ (Linux), Python 3.10+, and enough system RAM for the experts that do not fit in VRAM.

Quick start
-----------

[](https://github.com/jesdga95/basalt#quick-start)

Prebuilt Linux and Windows archives are attached to each [release](https://github.com/jesdga95/basalt/releases)
 ([what they need](https://github.com/jesdga95/basalt/blob/main/docs/platforms.md#release-archives)
); otherwise build from source:

```shell
git clone https://github.com/jesdga95/basalt && cd basalt
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build -j                  # bin/basalt, bin/basalt-bench, bin/basalt-probe, bin/basalt-vision
                                        # Windows: add -G Ninja to the first line, from an x64 VS 2022 prompt ([platforms](docs/platforms.md#building-on-windows))
                                        # one model only: -DBASALT_MODELS=qwen4exp, deepseek41 or qwen35 ([building](docs/building.md#building-only-some-models))
pip install -r requirements.txt
hf download jesdga/Qwen3.8-Flash-Next-Basalt Qwen3.8-FN-NVFP4-DQ6_K.basalt --local-dir models
```

Put the settings in `basalt_config.json`:

```json
{
  "version": 2,
  "models": [{ "model": "models/Qwen3.8-FN-NVFP4-DQ6_K.basalt", "gpu": "0,1", "kv": "int8" }],
  "engine": { "resident-experts": true },
  "server": { "port": 8080 }
}
```

```shell
bin/basalt serve --config basalt_config.json
```

The server listens on 127.0.0.1. Every setting: [configuration](https://github.com/jesdga95/basalt/blob/main/docs/configuration/index.md)
. More examples: [example configurations](https://github.com/jesdga95/basalt/blob/main/docs/configuration/examples.md)
.

Models
------

[](https://github.com/jesdga95/basalt#models)

|     | Qwen3.8-Flash-Next | DeepSeek-V4.1-Flash | Qwen3.8-27B |
| --- | --- | --- | --- |
| Packs | default `Qwen3.8-FN-NVFP4-DQ6_K`, [Hugging Face](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt) | default `DeepSeek-V4.1-Flash-1017-UD-IQ1_M`, [Hugging Face](https://huggingface.co/jesdga/DeepSeek-V4.1-Flash-1017-Basalt) | `Qwen3.8-27B-QUASAR-NVFP4`, [Hugging Face](https://huggingface.co/jesdga/Qwen3.8-27B-Basalt) |
| Context | up to 262,144 (longer with YaRN) | up to 1,048,576 | up to 262,144 |
| Drafting | MTP, on by default | DSpark, on by default | DFlash 2, on by default |
| Images | yes | yes | yes |
| Documents (PDF, text) | yes | yes | yes |
| Guide | [guide](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md) | [guide](https://github.com/jesdga95/basalt/blob/main/docs/models/deepseek41.md) | [guide](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-27b.md) |
| Precision | [precision](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md) | [precision](https://github.com/jesdga95/basalt/blob/main/docs/precision/deepseek41.md) | [precision](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-27b.md) |

All models compared, with each one's context limit, flags and cards: [models](https://github.com/jesdga95/basalt/blob/main/docs/models/index.md)
.

Video
-----

[](https://github.com/jesdga95/basalt#video)

Qwen3.8-Flash-Next and Qwen3.8-27B read video; DeepSeek does not. A video is named like an image in a chat message, and needs `--vision` and FFmpeg on the machine. Flash-Next decodes frames on the GPU with NVDEC; the 27B decodes them on the CPU. How a request names a video, and the limits: [video](https://github.com/jesdga95/basalt/blob/main/docs/running.md#video)
.

Documentation
-------------

[](https://github.com/jesdga95/basalt#documentation)

````

</details>

<details><summary>Tool result · web_scrape · call_3df44bcd6c5a474f8c4e64a4</summary>

**Firecrawl · section 1 of 12**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,438 characters · included below
- Section 2 · 7,591 characters · omitted from this copy
- Section 3 · 11,378 characters · omitted from this copy
- Section 4 · 11,645 characters · omitted from this copy
- Section 5 · 10,110 characters · omitted from this copy
- Section 6 · 10,158 characters · omitted from this copy
- Section 7 · 11,971 characters · omitted from this copy
- Section 8 · 10,355 characters · omitted from this copy
- Section 9 · 11,964 characters · omitted from this copy
- Section 10 · 11,798 characters · omitted from this copy
- Section 11 · 11,699 characters · omitted from this copy
- Section 12 · 5,377 characters · omitted from this copy

````text
[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

FilesExpand file tree


-----------------------

master

/

qwen3-8-flash-next.md
=====================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/docs/qwen3-8-flash-next.md)

[](https://github.com/iamwavecut/ninfer-all/commits/master/docs/qwen3-8-flash-next.md)
History

1457 lines (1282 loc) · 114 KB

master

/

qwen3-8-flash-next.md
=====================

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


1457 lines (1282 loc) · 114 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/docs/qwen3-8-flash-next.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

Qwen3.8-Flash-Next
==================

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#qwen38-flash-next)

NInfer runs Qwen3.8-Flash-Next (`Qwen4ExpForConditionalGeneration`, 125B text parameters, about 6B active per token) from ISTA-DASLab's GSQ-RCO GGUF releases and Unsloth's Dynamic v3.1 ones, converted without requantization:

*   [Qwen3.8-Flash-Next-GSQ-RCO-GGUF](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)
    : Q2\_0 (37.6 GB), IQ2\_XS (39.2 GB), IQ3\_XXS (47.0 GB), IQ3\_S (54.8 GB);
*   [Qwen3.8-Flash-Next-GSQ-RCO-Coder-GGUF](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-Coder-GGUF)
    ;
*   [unsloth/Qwen3.8-Flash-Next-GGUF](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF)
    : UD-IQ2\_XS (47.0 GB) and UD-IQ3\_XXS (54.8 GB) were converted and run. Of its other sizes, UD-IQ1\_M stores IQ2\_XS expert blocks, which have no CPU product, and UD-Q4\_K\_XL and the larger ones store Q5\_1 tensors, which have no kernel; none of those was converted.

Each GSQ-RCO release is two GGUF shards: the model, and the 28.8 GB n-gram table of the model's per-layer embedding (PLE), byte for byte the same in every release, the Coder build's included. The table shard of Unsloth's UD-IQ2\_XS release holds the same rows (the same SHA-256 of the rows). A NInfer model artifact describes the table it reads in its `ngram` component (the hash constants, the row format and the SHA-256 of the rows) and either stores the rows too, as one self-contained file, or leaves them to a table artifact of their own that every Flash-Next model can share. Nothing reads the table at load; each token reads the 16 rows it addresses from the file, unless the table, or the part of it a profile ranks most used, is loaded into RAM ([the n-gram rows](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#the-n-gram-rows)
). A model stored without its rows takes them from `--ngram-table PATH`: the table the model names, or any other table of its shape ([another table of the same shape](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#another-table-of-the-same-shape)
); without a table the engine refuses to start ([running without it](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#without-the-n-gram-table)
 is an experiment, not a mode).

The published conversions store the models without the table, which is published once:

| Artifact | Size |     |
| --- | --- | --- |
| [n-gram table](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3) | 26.92 GiB | IQ4\_NL rows and an optional broad hot-row profile |
| [Q2\_0](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-NInfer-v3) | 38.23 GiB | Vision and shared-Q8\_0 MTP |
| [IQ3\_S](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3) | 54.24 GiB | Vision and shared-Q8\_0 MTP |
| [Coder IQ1\_M](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-Coder-IQ1_M-NInfer-v3) | 30.76 GiB | 256 text experts per layer, Vision and shared-Q8\_0 MTP |
| [Unsloth UD-IQ2\_XS](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-UD-IQ2_XS-NInfer-v3) | 47.43 GiB | Unsloth Dynamic v3.1, Vision, shared-Q8\_0 MTP and the DFlash2 drafter |
| [Unsloth UD-IQ3\_XXS](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-UD-IQ3_XXS-NInfer-v3) | 54.66 GiB | Unsloth Dynamic v3.1, Vision, shared-Q8\_0 MTP and the DFlash2 drafter |

The model runs with up to eight concurrent requests, a context cache of prompt prefixes, structured output, images and video through its Vision tower (`--vision`, from an artifact converted with the tower), and MTP speculative decoding (`--spec mtp`). The three published NInfer models above now include Unsloth's shared-Q8\_0 MTP block. The upstream GSQ-RCO GGUF sources omit it, so new conversions must supply it separately; see [MTP](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#mtp-speculative-decoding)
.

The Q4\_K async prompt tiles (`gguf_moe_matrix/q4_k`) apply to Q4\_K expert banks whose tables are 16-byte aligned (`MoeTable::aligned16`): device banks, a rank's share under tensor parallelism, and the slot pools that host and disk experts' prompt chunks fill. The published Q2\_0, IQ3\_S and IQ1\_M releases have no Q4\_K experts.

Convert
-------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#convert)

`--model` needs only the HF checkpoint's configuration and tokenizer files (`config.json`, `tokenizer.json`, `tokenizer_config.json`, `chat_template.jinja`, `generation_config.json`) from [Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)
.

```shell
# The model with its n-gram table, one self-contained file (--components text,ngram, the default).
python3 -m tools.convert --model /path/to/Qwen3.8-Flash-Next \
  --recipe qwen3_8_flash_next_gguf \
  --source gguf=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00001-of-00002.gguf \
  --source ngram=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00002-of-00002.gguf \
  --device cpu --rows-per-chunk 65536 \
  --name qwen3.8-flash-next --out models/flash-next-q2_0.ninfer

# Or the table once, as an artifact of its own, and each release without it.
python3 -m tools.convert --model /path/to/Qwen3.8-Flash-Next \
  --recipe qwen3_8_flash_next_gguf --components ngram \
  --source ngram=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00002-of-00002.gguf \
  --device cpu --rows-per-chunk 65536 --out models/flash-next-ngram-table.ninfer
python3 -m tools.convert --model /path/to/Qwen3.8-Flash-Next \
  --recipe qwen3_8_flash_next_gguf --components text \
  --source gguf=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00001-of-00002.gguf \
  --source ngram=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00002-of-00002.gguf \
  --device cpu --rows-per-chunk 65536 \
  --name qwen3.8-flash-next --out models/flash-next-q2_0.ninfer
```

Every conversion containing PLE reads the table shard once more to hash it (a minute or so for 28.8 GB), since the model records the digest of the table it reads whether or not it stores the rows.

A release split by llama.cpp (`llama-gguf-split`) converts the same way. Unsloth's Dynamic v3.1 files of [`unsloth/Qwen3.8-Flash-Next-GGUF`](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF)
 have this layout: the first shard holds the metadata and no tensor, the next one or two hold the model, and the last holds the table. `--source gguf=` names the first shard; the converter opens the shards beside it that the name counts (`-00001-of-0000N.gguf`) and reads each tensor from the shard that stores it. An absent shard is left out, so the table shard may lie elsewhere; a model tensor that no present shard stores, a cut shard, a tensor stored twice and a `split.count` that differs from the name are refused. The table shard is still the `ngram` source, and any release's table shard serves: the rows are the same.

```shell
# Unsloth UD-IQ2_XS without the table, with the Vision tower and the shared-Q8_0 MTP block.
python3 -m tools.convert --model /path/to/Qwen3.8-Flash-Next \
  --recipe qwen3_8_flash_next_gguf --components text,vision,mtp \
  --source gguf=/path/to/Qwen3.8-Flash-Next-UD-IQ2_XS-00001-of-00003.gguf \
  --source ngram=/path/to/Qwen3.8-Flash-Next-UD-IQ2_XS-00003-of-00003.gguf \
  --source vision=/path/to/mmproj-BF16.gguf \
  --source mtp=/path/to/mtp-Qwen3.8-Flash-Next-shared-Q8_0.gguf \
  --device cpu --rows-per-chunk 65536 \
  --name qwen3.8-flash-next --out models/flash-next-ud-iq2_xs.ninfer
```

`--layers A..B` makes a qualification artifact from source layers A through B-1, using zero-based, half-open bounds. It supports the HF, GGUF and native-Q2 recipes. The embedding, final mixer and head remain; selected blocks and their activation uses are renumbered from zero, while source lookups keep the original indices. `provenance.source_layers` records those indices. PLE moves with its block and keeps the same table constants. If the range contains no PLE, the artifact omits the `ngram` component and no table source or runtime override is needed. The Engine refuses unused table options for that slice.

```shell
# Source blocks 3 (QSA) and 4 (GDN), with no PLE or table scan.
python3.11 -m tools.convert --model /path/to/Qwen3.8-Flash-Next \
  --recipe qwen3_8_flash_next_gsq_q2 --layers 3..5 --components text \
  --source gguf=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00001-of-00002.gguf \
  --device cpu --rows-per-chunk 65536 --out models/flash-next-layers-3-5.ninfer
```

A sliced model runs its shortened stack through the public Engine. Its outputs are for binding, state and numerical qualification; they do not represent full-model quality or logits at the same layers of a complete forward, whose input residual also includes the preceding layers.

`qwen3_8_flash_next_gsq_q2` imports the trained Q2\_0 routed experts into `q2_g64_fp16` planes with exact code and signed-scale words. Q2\_0/Q8\_0 shared projections retain their codes/scales as native Q2/Q8; other shared block formats decode and round to BF16. Other projections and the MTP block keep their GGUF representations. Native banks support device residency and host residency at concurrency one; native disk residency is not implemented. A8 uses grouped integer MMA from 16 columns, decoding the stored native codes in registers without repacking the weights.

The native recipe is an explicit artifact choice; the GGUF artifacts stay the published representation. On the held-out quick corpus (391,000 targets, context 32,768, BF16 KV, one RTX A6000) the native-Q2 artifact scored 5.004501 against 4.991555 for the GGUF one (+0.26%, worst window +4.3%), and scoring took 15% longer. Its expert Op is within a few percent of the GGUF Op at decode widths with A8 activations, between 28% faster and 34% slower at prompt widths, and slower everywhere with A16 activations.

````

</details>

<details><summary>Tool result · web_scrape · call_4f372abd408c4b37ab9c3756</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

/

gguf.md
=======

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/docs/gguf.md)

[](https://github.com/iamwavecut/ninfer-all/commits/master/docs/gguf.md)
History

115 lines (94 loc) · 6.68 KB

/

gguf.md
=======

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


115 lines (94 loc) · 6.68 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/docs/gguf.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

GGUF block formats
==================

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md#gguf-block-formats)

NInfer serves GGUF releases that give every tensor its own ggml quantization type, such as ISTA-DASLab's [GSQ-RCO models](https://huggingface.co/ISTA-DASLab/Qwen3.8-27B-GSQ-RCO-GGUF)
, without converting their weights to another format. The converter recipe `qwen3_8_27b_gguf` copies each quantized tensor's blocks of a Qwen3.8-27B release into the artifact unchanged (see [weight conversion](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#a-mixed-precision-qwen38-27b-gguf)
), and the runtime multiplies them in place. The Qwen3.8-Flash-Next releases convert the same way with `qwen3_8_flash_next_gguf`, their routed experts kept as expert-major banks ([Qwen3.8-Flash-Next](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)
).

Formats
-------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md#formats)

Twenty block types: the fifteen llama.cpp writes for dense models, `Q8_0`, `Q2_K`, `Q3_K`, `Q4_K`, `Q5_K`, `Q6_K`, `IQ1_S`, `IQ1_M`, `IQ2_XXS`, `IQ2_XS`, `IQ2_S`, `IQ3_XXS`, `IQ3_S`, `IQ4_NL` and `IQ4_XS`; `Q2_0`, `Q4_0` and `Q5_0`, which the Flash-Next releases use; `MXFP4`, the routed experts of DeepSeek-V4.1's DSpark GGUF drafter; and `NVFP4` (64 values in four groups of 16 E2M1 codes with a UE4M3 scale each), the routed experts of the [Edge0](https://github.com/iamwavecut/ninfer-all/blob/master/docs/edge0.md)
 NVFP4 releases; stored as the `gguf_*` formats of the `gguf_blocks_v1` layout ([tensor formats](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/tensor-formats.md#35-gguf-block-formats)
, [storage layouts](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#6-gguf_blocks_v1)
). A projection may mix types: the parts of a fused projection that share a type are multiplied together, the others one by one against the same activation. A dense release's untied BF16 output head is stored and multiplied as BF16.

Products
--------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md#products)

Every product quantizes its BF16 activation to ggml's `q8_1` numbers, one scale and one sum per 32 values, as llama.cpp does, and accumulates in FP32; the weights' represented values are exactly those of `ggml-quants.c`. The vector kernel stores both in binary16, as does the matrix kernel for the types whose products read the sum (Q4\_K, Q5\_K and IQ1\_S among them): a 32-value block whose largest magnitude passes 127 × 65,504 (about 8.3 million) overflows such a scale, and one whose sum passes 65,504 overflows the sum. Flint's routed SwiGLU products reach the second limit, so its executor scales them ([F16 activation sums](https://github.com/iamwavecut/ninfer-all/blob/master/docs/flint.md#f16-activation-sums)
).

*   **Up to eight columns** (decode, speculative verification, small batches), the vector kernel (`src/ops/linear/gguf/ggml_bridge_vec.cuh`) decodes each 32-value slice of a row once into int8 words and dots it with every column. A warp owns two rows; a `[gate; up]` pair of one type is one launch that writes `silu(gate) * up`.
*   **More columns** (prompts) take llama.cpp's integer tensor-core kernel (`mul_mat_q`, vendored in `third_party/ggml-quants` under its MIT license with the changes its `README.ninfer.md` lists) with its Ampere tile table. `IQ1_M` has no such kernel for dense matrices, whose wide products dequantize to BF16 and run cuBLAS; routed experts in `IQ1_M` take that kernel with NInfer's tile loader for the format once a call routes more than 16 rows to each expert on average for gate and up products and 6 for down products, the vector kernel in groups of eight columns below that (`--iq1m-experts`, [DeepSeek-V4.1](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md#iq1_m-experts-in-prompt-chunks)
    ).
*   **Token table** rows are dequantized exactly.

The scales of `IQ2_XXS`, `IQ2_XS`, `IQ2_S` and `IQ3_XXS` are applied in FP32 where llama.cpp's vector kernels round an integer rescale, and the vector kernels round each step of the formats the CPU share also computes in a fixed order (`IQ1_M` with integer codes eight times its values), so a decode step's logits can differ from llama.cpp's in the last bits; prompts use llama.cpp's own arithmetic, and `IQ1_M` experts NInfer's tile loader.

Serving
-------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md#serving)

A converted artifact starts like any other; MTP, DFlash2 and Vision work as with the official artifact. A Qwen3.8-27B GGUF with a [condensed vocabulary](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#a-condensed-vocabulary)
 converts with zero rows up to whole 128-row tiles and drafts with MTP or context lookup only. The GSQ-RCO IQ3\_S conversion is published as [WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3\_S-NInfer-v3](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3)
:

```shell
./build/apps/ninfer-serve models/Qwen3.8-27B-GSQ-RCO-IQ3_S-ninfer-v3.ninfer \
  --model-id qwen3.8-27b --kv-dtype rk8v4 --gdn-state-fp16 --spec mtp --draft-tokens 3
```

Measurements
------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md#measurements)

GSQ-RCO IQ3\_S (3.5 bits per weight, 10.95 GiB of weights) against the official Qwen3.8-27B NInfer artifact (Q4/Q5 groups, 15.9 GiB of weights).

WikiText-2 test perplexity with the protocol of the GSQ-RCO model card (the test rows joined by blank lines, disjoint 2,048-token windows, `ninfer-perplexity --disjoint`, BF16 KV):

| Artifact | Perplexity |
| --- | --- |
| GSQ-RCO IQ3\_S in NInfer | 7.071 |
| GSQ-RCO IQ3\_S, model card | 7.07 |
| BF16 base model, model card | 7.05 |
| Official Qwen3.8-27B NInfer artifact | 7.286 |

The reasoning benchmarks of the [capability evaluation](https://github.com/iamwavecut/ninfer-all/blob/master/eval/README.md)
, with the protocol the official artifact was scored with (EvalScope, temperature 1.0, one sampled run each, an RTX 5090):

| Benchmark | GSQ-RCO IQ3\_S in NInfer | Official Qwen3.8-27B NInfer artifact |
| --- | --- | --- |
| IFBench (prompt-level strict) | 80.33% | 77.67% |
| AIME 2025 | 100.00% | 96.67% |
| AIME 2026 | 100.00% | 96.67% |
| GPQA-Diamond | 88.38% | 87.37% |

The GSQ-RCO card reports 100 on AIME 2025 and 89.39 on GPQA-Diamond with its own protocol (BF16: 100 and 89.90). One run of GPQA-Diamond's 198 questions varies by about two points.

Speed against the official artifact on the same card in the same sitting, `rk8v4` KV, one request, greedy, thinking off, with the reference client (`tools/bench/refbench.py`): an RTX 3090 at 420 W and an RTX 4090 at 450 W with a 176,128-token window (the official DFlash2 row on the RTX 4090 at 167,936), an RTX 5090 at 450 W with 262,144. Short chat is the mean decode rate over five 512-token answers; GSQ-RCO IQ3\_S / official:

|     | RTX 3090 | RTX 4090 | RTX 5090 |
| --- | --- | --- | --- |
| short chat, no speculation, tok/s | 59.9 / 40.3 | 70.6 / 55.0 | 107.5 / 88.1 |
| short chat, MTP, 3 drafts, tok/s | 108.7 / 82.7 | 146.4 / 109.3 | 221.4 / 178.1 |
| short chat, DFlash2, 5 drafts, tok/s | 115.6 / 109.2 | 169.4 / 141.3 | 226.5 / 222.5 |
| decode after 32K tokens, no speculation, tok/s | 50.4 / 38.4 | 66.0 / 52.2 | 100.3 / 83.2 |
| time to first token, 32K prompt, s | 20.5 / 22.2 | 9.3 / 12.8 | 8.6 / 9.3 |

The lead comes from reading 31% fewer weight bytes per token. Verification of several drafts gains less than plain decode because the i-quants cost more arithmetic per byte than the official Q4/Q5 groups, and every extra column adds its own dot products; DFlash2's six-token verification is where the two meet.

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_dcbad4b85cd7470ca7a3a598</summary>

**Firecrawl · section 1 of 3**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,574 characters · included below
- Section 2 · 11,912 characters · omitted from this copy
- Section 3 · 509 characters · omitted from this copy

```text
[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3#qwen38-flash-next-gsq-rco-iq3_s-ninfer-v3-artifact)
Qwen3.8-Flash-Next GSQ-RCO IQ3\_S, NInfer v3 artifact
======================================================================================================================================================================================

A [NInfer](https://github.com/Neroued/ninfer)
 **v3** artifact of ISTA-DASLab's [Qwen3.8-Flash-Next GSQ-RCO IQ3\_S](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)
 (3.50 bits per weight over the transformer weights) for **NInfer-all**, the `master` branch of [iamwavecut/ninfer-all](https://github.com/iamwavecut/ninfer-all)
. Qwen3.8-Flash-Next is a 125B-parameter mixture of experts: 48 layers of 512 routed experts, 10 of them active per token, about 6B active parameters. The GGUF assigns a ggml quantization type to every tensor; this artifact keeps each tensor's ggml blocks byte for byte (the hyper-connection projections excepted: they are re-quantized from BF16 to Q8\_0), and the engine multiplies the blocks in place. IQ3\_S is the release the GSQ-RCO card recommends: the strongest of the four.

Stock NInfer builds refuse these files: the model family and the `gguf_*` formats exist only in that line; build `master` from commit [`5395ec30b`](https://github.com/iamwavecut/ninfer-all/commit/5395ec30ba5653914ac59d265102414712a8721d)
 on. NInfer serves it with up to eight concurrent requests, prompt-prefix reuse, structured output and its Vision tower. This file includes the MTP block and incoai's DFlash2 drafter; with host experts NInfer drafts with DFlash2 unless `--spec` says otherwise ([November 4, 2026](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3#november-4-2026-dflash2-drafter)
).

[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3#what-is-inside)
What is inside
-----------------------------------------------------------------------------------------------------------

| component | representation |
| --- | --- |
| routed experts, 48 layers × 512 | the GGUF's own blocks, one type per layer and projection: gate and up IQ2\_S (20 layers), IQ3\_XXS (17), IQ3\_S (10), IQ4\_XS (1); down IQ4\_NL (39), Q2\_0 (9); expert-major, so one expert is one contiguous range of bytes |
| shared experts | the GGUF's own blocks per tensor: IQ4\_NL and Q8\_0 down, Q4\_K, Q5\_K, Q6\_K and IQ4\_XS gate and up |
| 36 Gated DeltaNet and 12 sparse-attention (QSA) layers | the GGUF's own blocks, Q4\_K to Q6\_K and IQ4\_XS per tensor |
| output head, token table | Q6\_K, IQ4\_XS |
| router | BF16, as in the GGUF |
| hyper-connection projections | ggml Q8\_0: the GGUF's BF16 matrices re-quantized (October 9, 2026), the MTP block's as stored in its GGUF |
| GDN controls, norms, convolution, `A_log`, `dt_bias` | BF16/FP32, restored from llama.cpp's exporter conventions (grouped value heads, `w` instead of `1 + w`, `A_log` from `-exp(A_log)`, the head-interleaved query and gate) |
| Vision tower | the release's `mmproj-Qwen3.8-Flash-Next-BF16.gguf` in BF16 (0.9 GB): the Qwen3.5/3.6 tower, 27 blocks of width 1152, merging 2×2 patches onto the text model's 2,560, with the checkpoint's image and video preprocessor configurations |
| n-gram table | not in this file: the model's `ngram` component names its table (the hash constants, IQ4\_NL rows, SHA-256 `dd55c289…6cc3` of the rows), the same table as every Flash-Next release, published once as [WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3)<br>; NInfer-all from [`57395b20b`](https://github.com/iamwavecut/ninfer-all/commit/57395b20b4ee9c4ac792146d82ffac6b28396a9b)<br> on reads any table of the same hash constants and geometry in its place, in any row format, such as [Edge0's FP8 table](https://huggingface.co/WaveCut/Edge0-ngram-table-FP8-NInfer-v3)<br>. |
| DFlash2 drafter | incoai's [DFlash 2 draft model](https://huggingface.co/incoai/Qwen3.8-Flash-Next-DFlash2)<br> in nazeshinjite's [Q4\_0 GGUF](https://huggingface.co/nazeshinjite/Qwen3.8-Flash-Next-DFlash2-GGUF)<br> (339 MB): five sliding-window layers of width 2,560 that draft from the model's own hidden states, their matrices and the selector's codebooks in the GGUF's Q4\_0 blocks, norms and convolution bases BF16 |
| chat template | Qwen/Qwen3.8-Flash-Next's `chat_template.jinja` |

One file, `Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-ninfer-v3.ninfer`, of 58,242,390,528 bytes (54.24 GiB), next to its conversion report, `SHA256SUMS`, `NOTICE` and `LICENSE`. Original text/Vision conversion command, before the MTP and DFlash2 attachments:

    python3 -m tools.convert --model Qwen3.8-Flash-Next \
      --recipe qwen3_8_flash_next_gguf --components text,vision \
      --source gguf=Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-00001-of-00002.gguf \
      --source ngram=Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-00002-of-00002.gguf \
      --source vision=mmproj-Qwen3.8-Flash-Next-BF16.gguf \
      --device cpu --rows-per-chunk 65536 \
      --name qwen3.8-flash-next --out Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-ninfer-v3.ninfer


The converter reads the table shard to record its digest; the rows themselves are in the table repository. The table shard of every release is the same file (SHA-256 `316b46f3…e113`); the digest above came from the Q2\_0 release's. `--model` needs the configuration, tokenizer and preprocessor files of [Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)
 (`config.json`, `tokenizer.json`, `tokenizer_config.json`, `chat_template.jinja`, `generation_config.json`, `preprocessor_config.json`, `video_preprocessor_config.json`).

[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3#running)
Running
---------------------------------------------------------------------------------------------

Download the artifact and the n-gram table, then serve them from a build of `master` ([its README](https://github.com/iamwavecut/ninfer-all#building)
; `CMAKE_CUDA_ARCHITECTURES` is `86`, `89` or `120a`, and `120a` needs CUDA 13.1 or newer):

    hf download WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3 \
      Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-ninfer-v3.ninfer --local-dir models
    hf download WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3 \
      Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer --local-dir models
    M=models/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-ninfer-v3.ninfer
    T=models/Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer

    # One RTX PRO 6000 (96 GB): every expert in device memory.
    ninfer-serve $M --ngram-table $T --model-id qwen3.8-flash-next --max-context 32768

    # Two 32 GB GPUs (Linux): every expert in device memory, one pipeline stage per GPU.
    ninfer-serve $M --ngram-table $T --model-id qwen3.8-flash-next --devices 0,1 --max-context 32768

    # One 24 GB GPU: the experts in page-locked host memory (50.3 GB), the most used of them cached on the GPU.
    ninfer-serve $M --ngram-table $T --model-id qwen3.8-flash-next --expert-residency host --max-context 32768

    # One 24 GB GPU and little RAM: the experts stay in the file and stream into a GPU cache.
    ninfer-serve $M --ngram-table $T --model-id qwen3.8-flash-next --expert-residency disk --max-context 32768


The [Docker image](https://github.com/iamwavecut/ninfer-all#docker)
 (an NVIDIA driver of the CUDA 13 branch, 580 or newer, and the NVIDIA Container Toolkit) runs the same commands as `serve` with the files under `/models`, and answers on `http://localhost:8080/v1`:

    docker run --rm --gpus all -p 8080:8080 --ulimit memlock=-1 \
      -v "$PWD/models:/models" -v ninfer-cache:/cache \
      ghcr.io/iamwavecut/ninfer-all serve /models/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-ninfer-v3.ninfer \
      --ngram-table /models/Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer \
      --model-id qwen3.8-flash-next --expert-residency host --max-context 32768


With host experts the GPU holds the 3.9 GB of dense weights, the request state and an expert cache that takes what is free after startup (`--expert-cache-mib` sets it). With disk experts the host keeps no copy of the banks: the cache reads the experts each layer routes to from the file, through the OS page cache. The n-gram rows are read from the table's file the same way (16 per token) unless `--ngram-ram` loads the 28.8 GB table into RAM. A model started without its table is refused; `--no-ngram-table` runs it without, a non-standard experimental mode with no practical use (see the table's card). `--vision` adds the Vision tower (0.9 GB on the GPU) for images and video. Every expert in device memory takes 53.7 GiB on one RTX PRO 6000 and 26.5 + 27.8 GiB on two RTX 5090s; three 24 GB cards (`--devices 0,1,2`) should hold it too, but were not measured. The KV cache of the 12 sparse-attention layers is BF16. [Qwen3.8-Flash-Next](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)
 describes the placements and the execution.

[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3#november-4-2026-dflash2-drafter)
November 4, 2026: DFlash2 drafter
-----------------------------------------------------------------------------------------------------------------------------------------------

This update appends the DFlash 2 draft model of [incoai/Qwen3.8-Flash-Next-DFlash2](https://huggingface.co/incoai/Qwen3.8-Flash-Next-DFlash2)
 (Apache-2.0) as the file's `dflash2` component, from nazeshinjite's [Q4\_0 GGUF](https://huggingface.co/nazeshinjite/Qwen3.8-Flash-Next-DFlash2-GGUF)
 of it (revision `cbe1b23f`, the smallest form of the drafter on Hugging Face): 339,417,600 bytes. Every other object is byte for byte the previous file's; `dflash2-attachment.json` records the sources' SHA-256 digests and the parent artifact. A round proposes up to seven drafts in one pass of the drafter, and the model verifies them, so every committed token is the model's own draw.

From commit [`b6e22a9c0`](https://github.com/iamwavecut/ninfer-all/commit/b6e22a9c0c240cb12f1a4d078758f7f1e2da4e1f)
 on, NInfer drafts with it whenever the experts are in host memory and `--spec` is not given: four drafts a round, verified through the first draft the drafter rates at or below 0.7 (`--draft-min-p`). `--spec dflash2 --draft-tokens N` (1 to 7) selects it explicitly, also with device experts, `--spec mtp` the MTP block and `--spec none` neither. Earlier builds load the file and ignore the drafter (checked with build `a147b0c27`).

On one RTX 3090 with host experts (EPYC 7K62; 256 greedy tokens after a code prompt and after a prose prompt, and the 43-token answer to a 144-token prompt; the mean of two runs) the default drafting decoded 92.3, 77.9 and 58.2 tokens per second, against 83.5, 73.4 and 49.8 with the MTP block's three drafts and the floor 0.5, and 59.0, 57.5 and 45.9 without drafts (a separate run); every answer was the answer without drafts. With four such requests at once it decoded 1.04 times the aggregate speed without drafts on the code prompt and 0.93 times on the prose prompt (MTP: 0.89 on both).

[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3#october-9-2026-q8_0-hyper-connection-projections)
October 9, 2026: Q8\_0 hyper-connection projections
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

```

</details>

## Assistant · #21

<details><summary>Reasoning · 200 characters</summary>

Good. Need basalt docs for .basalt format. Maybe docs/file-format.md, configuration, models/qwen38-flash-next. Let's inspect basalt docs directory maybe scrape raw README or docs. Use GitHub listing.


</details>

<details><summary>Tool request · web_scrape · call_c481199a040c41b0b2174ee9</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/tree/main/docs"
}
```

</details>

<details><summary>Tool request · web_scrape · call_1c6848ac7f8b461480657dda</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_4b7c549d13074f1098cc58b5</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_81d9018d086a4b0ba3969310</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/blob/main/tools/convert/convert.py"
}
```

</details>


<details><summary>Tool result · web_scrape · call_c481199a040c41b0b2174ee9</summary>

[Skip to content](https://github.com/jesdga95/basalt/tree/main/docs#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/tree/main/docs)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/tree/main/docs)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/tree/main/docs)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

FilesExpand file tree


-----------------------

main

/

docs
====

/

Copy path

Directory actions
-----------------

More options
------------

More options

Directory actions
-----------------

More options
------------

More options

Latest commit
-------------

History
-------

[History](https://github.com/jesdga95/basalt/commits/main/docs)

[](https://github.com/jesdga95/basalt/commits/main/docs)
History

main

/

docs
====

/

Copy path

Top

Folders and files
-----------------

| Name |     | Name | Last commit message | Last commit date |
| --- | --- | --- | --- |
| ### parent directory<br><br>[..](https://github.com/jesdga95/basalt/tree/main) |     |     |
| [assets](https://github.com/jesdga95/basalt/tree/main/docs/assets "assets") |     | [assets](https://github.com/jesdga95/basalt/tree/main/docs/assets "assets") |     |     |
| [changelog](https://github.com/jesdga95/basalt/tree/main/docs/changelog "changelog") |     | [changelog](https://github.com/jesdga95/basalt/tree/main/docs/changelog "changelog") |     |     |
| [community](https://github.com/jesdga95/basalt/tree/main/docs/community "community") |     | [community](https://github.com/jesdga95/basalt/tree/main/docs/community "community") |     |     |
| [configuration](https://github.com/jesdga95/basalt/tree/main/docs/configuration "configuration") |     | [configuration](https://github.com/jesdga95/basalt/tree/main/docs/configuration "configuration") |     |     |
| [img](https://github.com/jesdga95/basalt/tree/main/docs/img "img") |     | [img](https://github.com/jesdga95/basalt/tree/main/docs/img "img") |     |     |
| [models](https://github.com/jesdga95/basalt/tree/main/docs/models "models") |     | [models](https://github.com/jesdga95/basalt/tree/main/docs/models "models") |     |     |
| [precision](https://github.com/jesdga95/basalt/tree/main/docs/precision "precision") |     | [precision](https://github.com/jesdga95/basalt/tree/main/docs/precision "precision") |     |     |
| [adding-a-model.md](https://github.com/jesdga95/basalt/blob/main/docs/adding-a-model.md "adding-a-model.md") |     | [adding-a-model.md](https://github.com/jesdga95/basalt/blob/main/docs/adding-a-model.md "adding-a-model.md") |     |     |
| [basalt-file-changelog.md](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md "basalt-file-changelog.md") |     | [basalt-file-changelog.md](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md "basalt-file-changelog.md") |     |     |
| [building.md](https://github.com/jesdga95/basalt/blob/main/docs/building.md "building.md") |     | [building.md](https://github.com/jesdga95/basalt/blob/main/docs/building.md "building.md") |     |     |
| [community.md](https://github.com/jesdga95/basalt/blob/main/docs/community.md "community.md") |     | [community.md](https://github.com/jesdga95/basalt/blob/main/docs/community.md "community.md") |     |     |
| [model-file.md](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md "model-file.md") |     | [model-file.md](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md "model-file.md") |     |     |
| [platforms.md](https://github.com/jesdga95/basalt/blob/main/docs/platforms.md "platforms.md") |     | [platforms.md](https://github.com/jesdga95/basalt/blob/main/docs/platforms.md "platforms.md") |     |     |
| [probe.md](https://github.com/jesdga95/basalt/blob/main/docs/probe.md "probe.md") |     | [probe.md](https://github.com/jesdga95/basalt/blob/main/docs/probe.md "probe.md") |     |     |
| [running.md](https://github.com/jesdga95/basalt/blob/main/docs/running.md "running.md") |     | [running.md](https://github.com/jesdga95/basalt/blob/main/docs/running.md "running.md") |     |     |
| View all files |     |     |

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_1c6848ac7f8b461480657dda</summary>

[Skip to content](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

Collapse file tree


--------------------

Files
-----

main

Search this repository(forward slash) forward slash/

/

qwen38-flash-next.md
====================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/jesdga95/basalt/commits/main/docs/models/qwen38-flash-next.md)

[](https://github.com/jesdga95/basalt/commits/main/docs/models/qwen38-flash-next.md)
History

70 lines (51 loc) · 4.49 KB

/

qwen38-flash-next.md
====================

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


70 lines (51 loc) · 4.49 KB

[Raw](https://github.com/jesdga95/basalt/raw/refs/heads/main/docs/models/qwen38-flash-next.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

Qwen3.8-Flash-Next
==================

[](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#qwen38-flash-next)

Runs with the same command as any model: `basalt serve PACK`. What it supports next to the others: [models](https://github.com/jesdga95/basalt/blob/main/docs/models/index.md)
. Rounding and quality: [precision](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md)
.

Pack
----

[](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#pack)

Packs on [Hugging Face](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt)
, all named `Qwen3.8-FN-` plus:

*   `NVFP4-DQ6_K` (default) and `NVFP4-DQ8`: NVIDIA's NVFP4 experts. `D` is the dense projections' format: Q6\_K, or Q8\_0 for DQ8. DQ8 is slower than DQ6\_K and has a lower KLD ([precision](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#6-bit-dense-projections)
    ).
*   `UD-IQ1_S`, `UD-IQ1_M`, `UD-IQ2_XS`, `UD-IQ3_XXS`, `UD-IQ4_XS`, `UD-Q4_K_XL`, `UD-Q5_K_XL`, `UD-Q6_K_XL` and `Q8_0`: Unsloth's GGUF types.
*   Unsloth's `UD-IQ1_S` GGUF converts as shipped (70.4 GB). One of its layers has IQ2\_S gate and IQ2\_XXS up rows; every layer runs the same fast kernels as the other UD packs.

Sizes are on the card. The layout, and how to build a pack: [model file](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md)
.

Memory
------

[](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#memory)

*   **Context:** `--max-context`, default 8,192. The KV cache grows with it. `--kv fp16` (default), `int8` (half the VRAM), `q4_0` and `k8v4` trade precision for VRAM ([precision](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#measured-costs)
    ).
*   **Experts:** the main card's cache holds the most routed ones, system RAM the rest, and an adaptive tier moves them as the conversation changes ([adaptive tier](https://github.com/jesdga95/basalt/blob/main/docs/configuration/adaptive.md)
    ).
*   **RAM:** before the RAM copy, the checkpoint blocks of every slot are allocated (page-locked, so a checkpoint saves and restores at link speed and a save runs beside the first decode window) and the RAM of the page-locked prompt buffers is held: the PLE rows at the largest chunk, a layer split's hand-offs, and the prompt split's weights, hand-offs and staging. Each buffer takes its held RAM when it is made; what none takes goes back before the top-up. The copy then leaves `--ram-reserve-mib` free beside the driver's page tracking (`RAM floor X GiB of N GiB free` when experts stay on the SSD).
*   **Cards:** every card after the main one is an expert tier, up to three. Matched cards may split the layers instead ([GPUs](https://github.com/jesdga95/basalt/blob/main/docs/configuration/gpus.md)
    ).
*   **Elastic KV:** with `--max-context` above 32,768 (and not with `--kv-resident`, `--vram-elastic` or a layer split), each session backs its first 32,768 cells at start. More cells come from the expert cache when a request needs them, and go back when it does not. An idle conversation's KV moves to RAM after 15 s. The startup line `elastic KV: ...` shows the figures, and `elastic KV: about N cells fit in the S sessions ...` gives the ceiling: the cells all sessions can hold before the expert cache reaches the slots a prompt chunk needs, past which a request is refused. `/v1/status` gives its current value as `context.elastic_kv_ceiling` (null without elastic KV), so a client can compact a conversation first.

Long prompts
------------

[](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#long-prompts)

*   `--prefill auto` reads up to 16,384 tokens per chunk (32,768 for NVFP4). The CPU computes 0.6 of the prompt experts that stream (`--prefill-cpu-share`).
*   A fresh part of 64 tokens or fewer goes through decode windows (`--short-read`).
*   With several cards, a long prompt can be read as a pipeline over them ([GPUs](https://github.com/jesdga95/basalt/blob/main/docs/configuration/gpus.md#long-prompts-across-the-cards)
    ).
*   Prompts beside decoding slots: [running](https://github.com/jesdga95/basalt/blob/main/docs/running.md#prompts-beside-decoding-slots)
    .

Drafting
--------

[](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#drafting)

On when the pack has the MTP drafter. `--spec N` sets the window (default 8: the last accepted token plus up to 7 drafts). `--spec 0` turns it off. `--suffix-draft` (default 3) also fills a window from an earlier repeat in the context. Output is exactly plain decoding's ([precision](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#drafting-does-not-change-output)
). Structured output drafts best and prose least.

Parallel slots
--------------

[](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#parallel-slots)

`--parallel N` (1 to 8) serves N requests at once ([running](https://github.com/jesdga95/basalt/blob/main/docs/running.md#concurrent-requests---parallel-n)
).

Images and video
----------------

[](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#images-and-video)

`--vision dynamic`, a GPU number or `cpu` ([vision](https://github.com/jesdga95/basalt/blob/main/docs/running.md#vision---vision)
). Video works with images on and FFmpeg on the machine; frames decode on the GPU with NVDEC ([video](https://github.com/jesdga95/basalt/blob/main/docs/running.md#video)
).

Lossy flags
-----------

[](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#lossy-flags)

Off by default. `--relaxed-drafting`, `--route-prior` and `--route-tail-skip` each change output, and each is named in one start warning. What they do and what they cost: [precision](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#relaxed-drafting)
.

Limits
------

[](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md#limits)

*   **Two-card idle sleep** can drop the second card's experts until restart (seen at context 8,192 without elastic KV, not at 64K or 262,144).

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_4b7c549d13074f1098cc58b5</summary>

**Firecrawl · section 1 of 2**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,987 characters · included below
- Section 2 · 7,730 characters · omitted from this copy

```text
[Skip to content](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

FilesExpand file tree


-----------------------

main

/

qwen38-flash-next.md
====================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/jesdga95/basalt/commits/main/docs/precision/qwen38-flash-next.md)

[](https://github.com/jesdga95/basalt/commits/main/docs/precision/qwen38-flash-next.md)
History

224 lines (171 loc) · 15.7 KB

main

/

qwen38-flash-next.md
====================

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


224 lines (171 loc) · 15.7 KB

[Raw](https://github.com/jesdga95/basalt/raw/refs/heads/main/docs/precision/qwen38-flash-next.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

Qwen3.8-Flash-Next precision
============================

[](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#qwen38-flash-next-precision)

Where Flash-Next rounds and what each rounding costs. Method and reference: [quality](https://github.com/jesdga95/basalt/blob/main/docs/precision/quality.md)
. Guide: [Flash-Next](https://github.com/jesdga95/basalt/blob/main/docs/models/qwen38-flash-next.md)
.

Test setup: RTX 5090 at 400 W with an RTX 5060 Ti at 180 W as the peer expert tier, 128 GB of system RAM. Each number names its build. Geometry: 2560 hidden, 4 hyper-connection streams, 48 layers (36 GDN, 12 QSA), 512 experts, top-10.

Summary
-------

[](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#summary)

*   **Drafting does not change output** unless `--relaxed-drafting` is set. With the tiers pinned, 275 of 275 greedy prompts gave identical tokens on both packs tested (IQ3\_XXS and IQ3\_S), and every full-vocabulary logit row matched bit for bit.
*   **Lossy flags are opt-in:** `--relaxed-drafting`, `--route-prior`, `--route-tail-skip`. Each is named in one start warning, which `basalt-bench` shows too; it marks such a run LOSSY, and a community run refuses them.
*   **Closer to BF16 than llama.cpp.** Same Q8\_0 weights, against the BF16 reference: llama.cpp scores KLD 0.0325, top-1 93.98%; the Basalt Q8\_0 pack scores KLD 0.0200, top-1 95.34%.
*   **Quantized once.** GGUF packs keep their blocks. The NVIDIA NVFP4 pack keeps NVIDIA's expert codes and scales bit for bit and quantizes each dense tensor once from BF16.
*   **Only one rounding costs measurable quality by default:** the Q6\_K dense projections, about 0.006 KLD and 0.3 to 0.6 points of top-1 against NVIDIA's precision. Everything else costs about 0.001 or less.

Where each stage rounds
-----------------------

[](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#where-each-stage-rounds)

| Stage | Format | Arithmetic |
| --- | --- | --- |
| Routed experts (GGUF packs) | GGUF blocks, byte for byte; mixed types across layers, and within one (UD-IQ1\_S: IQ2\_S gate, IQ2\_XXS up) | q8\_1 activations, dp4a or int8 mma, fp32 scales |
| Routed experts (NVFP4) | NVIDIA's E2M1 codes and UE4M3 scales, 4.5 bits/weight; FP32 tail `{s_gate, s_up, s_down}` | q8\_1 activations, exact int32 per 16-value sub-block, fp32 scales; tails applied in fp32 |
| Dense projections (attention, GDN qkv/z/out, QSA) | Q8\_0 (or Q6\_K in the NVFP4 pack; Q4\_K/Q5\_K/Q6\_K in others) | q8\_1 activations, int8 tensor-core dot, exact int32 per 32 block |
| Router, GDN alpha/beta, indexer, PLE key/value | BF16 as stored | fp32 activations and sums |
| Hyper-connections | int8 copy, one fp16 scale per 32 inputs (`hc8`); the hc read takes fp32 activations | fp32 sums; the up product uses fp16 hi/lo mma |
| Token embedding | GGUF type; one row dequantized to fp32 per token | fp32 |
| Output head | Q8\_0 (NVFP4 pack) or Q6\_K (IQ3\_S pack) | two-stage in verify, see [head](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#two-stage-verify-head) |
| Drafter | Q8\_0 and BF16 dense; Q2\_0 experts in VRAM | proposes only; verify decides |
| KV cache | fp16 (default), int8 (fp16 scale per 64), q4\_0, k8v4 | K/V dequantized to fp32; scores and softmax fp32 |
| GDN state and conv history | fp32 | fp32 |

Decode activations are int8 (q8\_1) into every quantized matmul. The hc read stays fp32 (llama.cpp quantizes it to Q8\_0).

### Expert tiers

[](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#expert-tiers)

GPU experts run the same kernels on every tier, so an expert gives the same bits on either card. CPU experts quantize activations with ggml's `vec_dot_type` (Q8\_K per 256 for i-quant gate/up, Q8\_0 for down). They round about 1% of a layer's routed output differently, so which experts sit where changes the last bits. Pin `--adapt-swaps 0 --peer-adapt-swaps 0` for identity checks.

### Prefill

[](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#prefill)

Prefill is a different computation from decode: fp16 and BF16 GEMMs, int8 MMQ, and FP4 tensor cores for NVFP4 experts. The gate scores the decode path.

| Path | Format | Rounding |
| --- | --- | --- |
| Dense projections | fp16 weights and activations, cuBLAS, fp32 accumulate | fp16 activations |
| Routed experts, MMQ | q8\_1 activations, int8 mma | int8 activation rounding (every MMQ format) |
| Routed experts, FP4 tensor cores (NVFP4, chunks of 1,024 or more) | E2M1 activations with a UE4M3 scale per 16 values and one fp32 scale per token; `mma kind::mxf4nvf4` | W4A4; numerics change against MMQ |
| Routed experts, CPU pool (chunks under 6,144 tokens) | ggml dot products, the same as decode's RAM tier | the CPU rounding above |
| Attention | int8 KV: q and p in fp16, one fp16 mma, fp32 accumulate | output within 1.5e-3 of an FP64 reference |
| GDN | chunked delta rule, 16 tokens per chunk; state and gates fp32; BF16 and TF32 tensor cores | output depends on where the 16-token grid falls (about 1e-3 relative) |

Rounding moves with the chunking: `--prefill auto` reads at most 16,384 tokens per chunk (32,768 for NVFP4), and the K/V rounding follows the chunk boundaries. Prompts above the cap read a first chunk of 16,384 tokens. The CPU computes a fixed 0.6 of streamed prompt experts. Split reads across cards match a main-card read: KLD mean 0.0008 (65,535 tokens) and 0.0005 (122,879), top-1 64 of 64 in both.

Measured prefill numbers (NVIDIA-checkpoint NVFP4 pack, 400 W + 180 W, T 3, int8 KV, 100-chunk gate unless noted):

| Measurement | Result |
| --- | --- |
| FP4 tensor cores vs MMQ, 2,049-token prompts, 24 chunks | KLD 0.0455 against 0.0437 (+0.0018 \[+0.0002, +0.0035\]); top-1 -0.19 points |
| FP4 vs MMQ, 8,193-token prompts, 6 chunks | KLD +0.0008 \[-0.0015, +0.0030\]; not resolved at 6 chunks |
| FP4 vs MMQ speed, 400 W + 180 W, cold | MMQ 17 to 19% slower: 16K 6,456 against 7,807 tok/s; 64K 8,201 against 10,126 tok/s |
| CPU share 0 (all GPU) against 1 (all CPU), NVFP4 DQ6\_K, 20 chunks | PPL 2.3046 / 2.3068, KLD 0.07337 / 0.07085, top-1 93.04% / 93.12%; paired +0.0025 \[-0.0005, +0.0055\] |
| K-quant MMQ against the FP16 path | rel RMS 1.08e-2 against 5e-4 (MMQ carries int8 activation rounding); 100-chunk gate within run noise |

Measured costs
--------------

[](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#measured-costs)

Gate: 100 chunks, 400 W + 180 W, tiers pinned. Paired against the default (Q6\_K dense, int8 KV), the mean over chunks with a 95% interval. **Lossless** means the interval contains 0 or the output is bitwise equal. **Measurable** means it excludes 0.

| Switch | Paired dKLD \[95% CI\] | Top-1 points | Verdict |
| --- | --- | --- | --- |
| Q6\_K dense projections, against BF16 dense | \-0.0072 \[-0.0086, -0.0058\] | +0.82 | measurable |
| Q6\_K dense, against Q8\_0 dense | \-0.0059 \[-0.0074, -0.0043\] | +0.55 | measurable |
| Q8\_0 dense, against BF16 dense | \-0.0014 \[-0.0025, -0.0003\] | +0.27 | measurable |
| int8 hc copy (`hc8`) in decode | \-0.0002 \[-0.0014, +0.0011\] | +0.02 | lossless |
| int8 activations into GDN and QSA projections | \-0.0004 \[-0.0014, +0.0006\] | \-0.04 | lossless |
| int8 activations into the shared expert | +0.0005 \[-0.0004, +0.0014\] | \-0.02 | lossless |
| int8 activations into the head | \-0.00009 \[-0.00012, -0.00005\] | 0.00 | measurable, 0.1% of KLD |
| int8 activations into routed experts (W4A8) | +0.0002 \[-0.0008, +0.0012\] | \-0.15 | lossless |
| fast math and approximate intrinsics | \-0.0003 \[-0.0012, +0.0006\] | +0.11 | lossless |
| int8 KV against fp16 KV | +0.0000 \[-0.0010, +0.0010\] | +0.15 | lossless |
| k8v4 KV | +0.0056 \[+0.0038, +0.0073\] | \-0.20 | measurable |
| q4\_0 KV | +0.0093 \[+0.0074, +0.0112\] | \-0.38 | measurable |
| CPU tier against GPU tiers (98.8% of rows on the CPU) | \-0.0005 \[-0.0015, +0.0005\] | +0.28 | lossless |
| prompt path against decode | \-0.0000 \[-0.0010, +0.0009\] | +0.13 | lossless |
| verify window width, T 1 against T 3 | 0   | 0   | lossless, 5,100 of 5,100 rows bitwise equal |
| fp16 against fp32 indexer keys (below 2,048 tokens) | 0   | 0   | no effect, 25,500 of 25,500 rows equal |
| Q5\_0 down layers on MMQ prefill and the device-planned decode tail, against the dequant GEMM and the host-planned tail: UD-Q3\_K\_XL (20 such layers) | \-0.0005 \[-0.0014, +0.0005\] | +0.17 | lossless |
| the same on UD-Q2\_K\_XL (one such layer) | +0.0004 \[-0.0006, +0.0013\] | \-0.03 | lossless |

All roundings off at once (BF16 dense, fp32 activations everywhere, fp16 KV, exact math): PPL 3.2866 against 3.2975 default, KLD 0.05308 against 0.06213, top-1 92.55% against 91.59%. Removing every rounding lowers KLD by about 0.009 (15%). The Q8\_0-dense pack alone gives -0.0059 of that. The Q8\_0-dense pack is about 7% slower on prose and 3% on struct than the default.

UD-IQ1\_S, converted as shipped (layer 18: IQ2\_S gate, IQ2\_XXS up; each half on its own format's kernels, the same bits as a uniform layer's rows): PPL 3.4049, KLD 0.2676, top-1 82.76% (100 chunks, T 3, int8 KV, resident experts).

The Q5\_0 rows: KLD 0.0943 against 0.0948 on UD-Q3\_K\_XL, 0.1520 against 0.1517 on UD-Q2\_K\_XL, tiers auto-sized. The device-planned tail runs only when every layer's expert formats are in it, so on these packs the decode rounding moves as well as the prompt's.

6-bit dense projections
-----------------------

[](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#6-bit-dense-projections)

The NVFP4 pack's default `DQ6_K` stores attention q/k/v/o, GDN qkv/z/out and the shared experts' gate/up as Q6\_K. The `DQ8` variant stores them as Q8\_0. Each tensor is quantized once from NVIDIA's BF16, never from the Q8\_0 copy (which would round twice).

Speed, 400 W + 180 W, ABBA, 6 fresh processes per arm:

| Test | 8-bit dense tok/s | 6-bit dense tok/s | Change |
| --- | --- | --- | --- |
| prose | 213.4 | 229.9 | +7.8% |
| conversation | 251.0 | 265.1 | +5.6% |
| structured | 420.4 | 463.5 | +10.2% |
| prefill 8K and 32K | 3,806 and 7,791 | 3,845 and 7,856 | +1% |

Quality: the Q6\_K against Q8\_0 dense row of [measured costs](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md#measured-costs)
.

Drafting does not change output
-------------------------------

```

</details>

<details><summary>Tool result · web_scrape · call_81d9018d086a4b0ba3969310</summary>

**Firecrawl · section 1 of 8**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 12,001 characters · included below
- Section 2 · 11,991 characters · omitted from this copy
- Section 3 · 11,992 characters · omitted from this copy
- Section 4 · 11,942 characters · omitted from this copy
- Section 5 · 11,976 characters · omitted from this copy
- Section 6 · 11,974 characters · omitted from this copy
- Section 7 · 11,961 characters · omitted from this copy
- Section 8 · 1,487 characters · omitted from this copy

```text
[Skip to content](https://github.com/jesdga95/basalt/blob/main/tools/convert/convert.py#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/tools/convert/convert.py)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/tools/convert/convert.py)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/tools/convert/convert.py)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

Collapse file tree


--------------------

Files
-----

main

Search this repository(forward slash) forward slash/

/

convert.py
==========

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/jesdga95/basalt/commits/main/tools/convert/convert.py)

[](https://github.com/jesdga95/basalt/commits/main/tools/convert/convert.py)
History

852 lines (780 loc) · 43.7 KB

/

convert.py
==========

Copy path

Top

File metadata and controls
--------------------------

*   Code

*   Blame


852 lines (780 loc) · 43.7 KB

[Raw](https://github.com/jesdga95/basalt/raw/refs/heads/main/tools/convert/convert.py)

Copy raw file

Download raw file

Open symbols panel

Edit and raw actions

"""
    """Build the single .basalt model file from the source GGUF shards. python3 tools/convert/convert.py --gguf MODEL-00001-of-0000N.gguf --mmproj MMPROJ.gguf --out MODEL.basalt \\\\ \[--mtp-source DIR\] \[--mtp-dense FILE\] \[--draft-vocab FILE\] \[--name NAME\] \[--compat-bf16\] \[--no-vision\] \[--force\] python3 tools/convert/convert.py --gguf MODEL-00001-of-0000N.gguf --sections-from BASE.basalt --out MODEL.basalt \[--name NAME\] \[--force\] python3 tools/convert/convert.py --dspark FILE --into PACK.basalt --undo-dir DIR python3 tools/convert/convert.py --sections-from BASE.basalt --checkpoint DIR --out MODEL.basalt \[--dense-q8-0\] \[--mtp-dense FILE\] \\\\ \[--name NAME\] \[--workers N\] \[--force\] python3 tools/convert/convert.py --sections-from DEEPSEEK.basalt --checkpoint DIR --out MODEL.basalt \[--stream-shards\] \\\\ \[--name NAME\] \[--workers N\] \[--force\] python3 tools/convert/convert.py --checkpoint QWEN35\_DIR --out MODEL.basalt \[--drafter DFLASH2\_DIR\] \[--head nvfp4\] \[--name NAME\] \[--workers N\] \[--force\] Inputs --gguf FILE the model's GGUF: shard 1 of a split model (the others are found beside it) or --gguf per shard --sections-from BASE.basalt with --gguf: the drafter, DSpark and vision sections are copied from BASE byte for byte (BASE's vocabulary must be the GGUF's); replaces --mmproj, --mtp-\*, --draft-vocab and --dspark. A tensor with a section of its own (the Engram table) whose shard stops after its header is copied from BASE's section of the same tensor --mmproj FILE the vision projector GGUF (required unless --no-vision) --dspark FILE deepseek41 only: the DSpark drafter GGUF, stored whole as the dspark/gguf section --mtp-source DIR the draft layer's BF16 tensors from \`mtp\_fetch.py fetch --out DIR\`; without it there is no drafter --mtp-dense FILE a tuned \`mtp/dense\` section (raw bytes, same layout as the source; needs --mtp-source); the packs with a self-distilled MTP layer carry one. Its size is checked and its SHA-256 goes to meta.mtp. With --sections-from and --checkpoint it replaces the mtp/dense copied from BASE (same size required) --draft-vocab FILE the token subset the draft head may propose (int32 ids; needs --mtp-source) From an NVFP4 checkpoint (--sections-from with --checkpoint) --checkpoint DIR NVIDIA Model Optimizer's NVFP4 safetensors (config.json, the model-NNNNN-of-NNNNN shards, the FP8 n-gram table file, tokenizer files, generation\_config.json, README.md). The routed experts keep their E2M1 codes and UE4M3 scales, moved into Basalt's blocks with the FP32 tail {s\_gate, s\_up, s\_down, 0} from weight\_scale\_2; the projections are quantized once from BF16 to Q6\_K (Q8\_0 where rows are not whole 256-value blocks, and for the output head and token embedding); the other tensors keep BF16 or become F32/F16 as the engine reads them; the n-gram table is FP8 code x scale as Q8\_0. The GGUF metadata and the tokenizer come from the checkpoint's files. --dense-q8-0 Q8\_0 projections instead of Q6\_K (the 8-bit dense variant) The drafter and vision sections come from BASE byte for byte; BASE's vocabulary must be the checkpoint's. From NVIDIA's DeepSeek-V4.1 NVFP4 checkpoint (a deepseek41 BASE; tools/convert/checkpoint\_deepseek41.py) --checkpoint DIR config.json, model.safetensors.index.json and the shards. The routed experts are repacked as above (w1 gate, w3 up, w2 down); the FP8 projections become Q8\_0 of their exact values (BF16 where BASE reads BF16); the MXFP4 Engram rows are kept. Tokenizer, metadata, vision and drafter are BASE's --stream-shards the shards may arrive while the conversion runs, in file order (another process downloads them), and each is deleted once its tensors are written: the disk holds the pack and a shard or two From a dense qwen35 NVFP4 checkpoint (no --sections-from; tools/convert/checkpoint\_qwen35.py) --checkpoint DIR an NVFP4 checkpoint of a Qwen3.5-family dense model, NVIDIA Model Optimizer's (nvidia/Qwen3.8-27B-NVFP4) or compressed-tensors' (QUASAR-QAT/Qwen3.8-27B-QUASAR-NVFP4): NVFP4 projections keep their codes and scales, FP8 ones their E4M3 codes, NVFP4 GDN a / b become BF16 of their values, a BF16 head becomes FP8 E4M3 rows, the drafter's BF16 projections Q8\_0, the vision tower an mmproj GGUF; tokenizer and metadata from the checkpoint's files. Everything comes from DIR. --drafter DIR z-lab's DFlash 2 block drafter for the model (z-lab/Qwen3.8-27B-DFlash2), added as dflash.\* tensors --head fp8|nvfp4 a BF16 head as FP8 E4M3 rows with an FP32 scale per row (amax / 448, the default) or rounded once to NVFP4 (UE4M3 scale of least squared error per 16 values); a head already NVFP4 is kept Dense requantization python3 tools/convert/convert.py --requant-dense-q6k PACK.basalt \[--checkpoint DIR\] --out MODEL.basalt \[--workers N\] \[--force\] Every Q8\_0 dense projection whose rows are whole 256-value blocks (GDN qkv/z/out, attention q/k/v/o, the shared experts' gate and up) is written as Q6\_K; everything else is copied byte for byte. --checkpoint DIR quantizes from the BF16 shards (each tensor is checked against the Q8\_0 copy in PACK); without it the Q8\_0 values are requantized. Adding the drafter to a deepseek41 pack that exists --dspark FILE --into PACK.basalt --undo-dir DIR writes dspark/gguf and a new meta past the file's end and replaces the header in one write: no other section moves or changes. DIR (new) keeps the old header and meta; --roll-back --into PACK.basalt --undo-dir DIR puts them back and cuts the file to its old size. Options --name NAME the model's name, reported by the server --compat-bf16 convert small projections stored in another form to BF16 (round-to-nearest-even, recorded in meta.conversions) --no-vision leave out the vision projector --force overwrite --out Every mode writes a version 2 file; its \`hc8\` section is computed from the file's own hyper-connection matrices (tools/convert/hc8.py). Sections are listed in include/basalt/core/model\_format.hpp. Everything is streamed. """
    """ from \_\_future\_\_ import annotations import argparse import gc import hashlib import json import math import os import re import struct import sys import tempfile import time from pathlib import Path HERE = Path(\_\_file\_\_).resolve().parent sys.path.insert(0, str(HERE)) sys.path.insert(0, str(HERE.parent)) # for model\_file, gguf\_reader, tokenizer import arch as A # noqa: E402 import hc8 as H # noqa: E402 import model\_sections as S # noqa: E402 from model\_file import SECTION\_ALIGN, TENSOR\_ALIGN, ModelFile, ModelWriter, Stream, append\_section, undo\_append # noqa: E402 FINGERPRINT\_BYTES = 64 << 20 QWEN = A.for\_architecture("qwen4exp") def model\_license(kv: dict) -> dict: """
    """Flash-Next's license, with its full text (the license requires it in every copy)."""
    """ return QWEN.license(kv) def die(msg: str): raise SystemExit(f"convert: {msg}") # ------------------------------------------------------------------ helpers def fingerprint(path: Path) -> str: """
    """sha256 over the first and last 64 MiB and the size: fast, and enough to tell two files apart."""
    """ size = path.stat().st\_size h = hashlib.sha256() with path.open("rb") as f: h.update(f.read(FINGERPRINT\_BYTES)) f.seek(max(0, size - FINGERPRINT\_BYTES)) h.update(f.read(FINGERPRINT\_BYTES)) h.update(struct.pack("<Q", size)) return h.hexdigest() def source\_record(path: Path) -> dict: return {"path": path.name, "size": path.stat().st\_size, "fingerprint\_sha256\_first\_last\_64mib\_and\_size": fingerprint(path)} def check\_dspark(path: Path) -> None: """
    """Stops on what the engine's drafter cannot read: another architecture, or dense tensors no decode kernel reads."""
    """ from gguf\_reader import GGUFFile if not path.is\_file(): die(f"missing input: {path}") try: g = GGUFFile(path) except (ValueError, KeyError, struct.error) as e: die(f"{path}: {e}") if g.metadata.get("general.architecture") != "dflash": die(f"{path} is not a DSpark (dflash) drafter GGUF") for t in g.tensors: if t.name == "fc.weight" and t.type\_name in ("BF16", "F16", "F32"): die(f"{path}: {t.name} is {t.type\_name}, which no decode kernel reads; take the Q8\_0 drafter") def dspark\_record(path: Path) -> dict: return {"section": "dspark/gguf", "bytes": path.stat().st\_size, "architecture": "dflash"} def add\_dspark(a) -> None: """
    """--dspark with --into: the drafter joins a pack that exists, whose other sections stay where and as they are."""
    """ pack = Path(a.into) if not pack.is\_file(): die(f"missing input: {pack}") if a.roll\_back: undo\_append(str(pack), a.undo\_dir) print(f"done: {pack} is back to {pack.stat().st\_size} bytes") return dspark = Path(a.dspark) check\_dspark(dspark) m = ModelFile(str(pack)) meta = json.loads(m.read("meta")) if meta.get("arch") != "deepseek41": die(f"{pack} is no deepseek41 pack") meta\["dspark"\] = dspark\_record(dspark) meta\["sources"\].append(source\_record(dspark)) try: append\_section(str(pack), "dspark/gguf", str(dspark), json.dumps(meta, ensure\_ascii=False, separators=(",", ":")).encode("utf-8"), a.undo\_dir) except (ValueError, FileExistsError) as e: die(str(e)) m = ModelFile(str(pack)) if not m.verify("dspark/gguf") or not m.verify("meta"): die(f"{pack}: the new sections do not read back as written; --roll-back puts the file back") print(f"done: {pack} is {pack.stat().st\_size} bytes, {len(m.names())} sections") def json\_safe(v): """
    """GGUF metadata as JSON: non-finite floats become strings, which JSON cannot carry."""
    """ if isinstance(v, float) and not math.isfinite(v): return repr(v) if isinstance(v, list): return \[json\_safe(x) for x in v\] return v def load\_vision\_helper(): import pack\_vision return pack\_vision.vision\_sections def export\_tokenizer(first\_gguf: Path, out\_dir: Path) -> list\[Path\]: """
    """The tokenizer files (tools/tokenizer.py) of the model's first shard, written under \`out\_dir\`/tokenizer."""
    """ import tokenizer tokenizer.extract(first\_gguf, out\_dir) return sorted(p for p in (out\_dir / "tokenizer").iterdir() if p.is\_file()) def source\_architecture(first\_gguf: Path) -> str | None: """
    """\`general.architecture\` from the first shard's header."""
    """ from gguf\_reader import GGUFFile return GGUFFile(first\_gguf).metadata.get("general.architecture") def source\_tensors(model: S.SourceModel, own\_sections=()): """
    """(kv, \[(name, shard path, absolute offset, size, TensorInfo)\]) over every shard, expert tensors and the tensors that get a section of their own (\`own\_sections\`) excluded."""
    """ kv, tensors = {}, \[\] for p, g in zip(model.paths, model.files): for k, v in g.metadata.items(): kv.setdefault(k, json\_safe(v)) for name, (g,
```

</details>

## Assistant · #26

<details><summary>Reasoning · 345 characters</summary>

We have convert.py docstring. Need model-file.md and model_format.hpp perhaps. Need exact .basalt sections, version, metadata. Let's scrape docs/model-file.md and model_format.hpp. Also maybe basalt-file-changelog. Need .ninfer format docs: maintainer/artifact format, tensor formats/storage layouts. Need compare container. Use web_scrape raw.


</details>

<details><summary>Tool request · web_scrape · call_2eca21bd51384a37bd454ab6</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/blob/main/docs/model-file.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_d5d23bb3d71545c3b0f570bb</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/blob/main/include/basalt/core/model_format.hpp"
}
```

</details>

<details><summary>Tool request · web_scrape · call_82bb6acbb213408ba7bbb4a5</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_79db45c1e69943beb8acb50a</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md"
}
```

</details>


<details><summary>Tool result · web_scrape · call_2eca21bd51384a37bd454ab6</summary>

[Skip to content](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

Collapse file tree


--------------------

Files
-----

main

Search this repository(forward slash) forward slash/

/

model-file.md
=============

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/jesdga95/basalt/commits/main/docs/model-file.md)

[](https://github.com/jesdga95/basalt/commits/main/docs/model-file.md)
History

126 lines (97 loc) · 8.06 KB

/

model-file.md
=============

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


126 lines (97 loc) · 8.06 KB

[Raw](https://github.com/jesdga95/basalt/raw/refs/heads/main/docs/model-file.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

`.basalt` model file
====================

[](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md#basalt-model-file)

One file holds everything the engine, the server and the vision sidecar load: weights, tokenizer and chat template, MTP or DSpark drafter, 8-bit hyper-connection copies, vision projector, and the GGUF metadata with default sampling. Flags and the expert profile are not in it.

*   **Layout:** a 64 KiB header (magic `BASALTMF`, version 2, up to 511 named sections with offset, size and SHA-256), then sections aligned to 2 MiB. Authoritative: [model\_format.hpp](https://github.com/jesdga95/basalt/blob/main/include/basalt/core/model_format.hpp)
    .
*   **Versions:** the engine reads version 2 only. Version 1 files convert with [tools/migrations/basalt\_v1\_to\_v2.py](https://github.com/jesdga95/basalt/blob/main/tools/migrations/README.md)
    , without a download. What changed: [file format changes](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md)
    .

Build a pack from a GGUF
------------------------

[](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md#build-a-pack-from-a-gguf)

```shell
python3 tools/convert/convert.py --gguf MODEL-00001-of-0000N.gguf --mmproj MMPROJ.gguf --out MODEL.basalt \
    [--mtp-source DIR [--mtp-dense FILE]] [--draft-vocab FILE] [--compat-bf16] [--name NAME]
```

`--help` describes every input. `--compat-bf16` converts GGUF projections stored as BF16 in another type. A pack built this way without the official tuned drafter is slower than the official file.

DeepSeek pack
-------------

[](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md#deepseek-pack)

*   `dense`: F32 and BF16 tensors. `gguf`: quantized non-expert tensors. `experts`: routed experts per layer.
*   `engram`: the Engram table alone (IQ4\_NL rows of 144 bytes, or MXFP4 rows of 136 in the NVFP4 pack), 2 MiB aligned.
*   `vision/mmproj`: present only when built with `--mmproj`; the engine and `basalt-vision --model FILE.basalt` read it in place.
*   `dspark/gguf`: DeepSeek's DSpark drafter. Attach it to an existing pack without copying weights:

```shell
python3 tools/convert/convert.py --dspark DRAFTER.gguf --into PACK.basalt --undo-dir DIR
```

`--roll-back --into PACK.basalt --undo-dir DIR` reverts it.

DeepSeek NVFP4 pack
-------------------

[](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md#deepseek-nvfp4-pack)

From NVIDIA's checkpoint ([nvidia/DeepSeek-V4.1-Flash-1017-NVFP4](https://huggingface.co/nvidia/DeepSeek-V4.1-Flash-1017-NVFP4)
), with the tokenizer, metadata, vision projector and DSpark drafter of a DeepSeek pack (`--sections-from`). The routed experts move bit for bit; the FP8 projections (32 x 32 block scales) become Q8\_0 of their exact values, BF16 where the base pack reads BF16; the MXFP4 Engram rows are kept; each tensor is checked against the base pack's. `--stream-shards` lets the shards arrive while it runs (downloaded in file order by another process) and deletes each once used, so the disk holds the output and a shard or two (about 430 GB). The routed experts' shards and those holding the other tensors and the Engram tables are needed; the drafter and vision shards are not.

```shell
python3 tools/convert/convert.py --sections-from DeepSeek-V4.1-Flash-1017-UD-IQ1_M.basalt --checkpoint nvidia-ds \
    --stream-shards --out DeepSeek-V4.1-Flash-1017-NVFP4.basalt --name "DeepSeek-V4.1-Flash-1017 NVFP4"
```

Flash-Next NVFP4 pack
---------------------

[](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md#flash-next-nvfp4-pack)

The official file is NVIDIA's checkpoint ([nvidia/Qwen3.8-Flash-Next-NVFP4](https://huggingface.co/nvidia/Qwen3.8-Flash-Next-NVFP4)
, revision `fc694b54`) with dense projections as Q6\_K. The converter reads the safetensors directly: experts move bit for bit, dense tensors are quantized once from BF16.

```shell
hf download nvidia/Qwen3.8-Flash-Next-NVFP4 --revision fc694b54 --local-dir nvidia

# 6-bit dense (the official file)
python3 tools/convert/convert.py --sections-from Qwen3.8-FN-UD-Q4_K_XL.basalt --checkpoint nvidia \
    --out Qwen3.8-FN-NVIDIA-NVFP4.basalt --name "Qwen3.8-Flash-Next NVIDIA-NVFP4"

# 8-bit dense variant
python3 tools/convert/convert.py --sections-from Qwen3.8-FN-UD-Q4_K_XL.basalt --checkpoint nvidia --dense-q8-0 \
    --out Qwen3.8-FN-NVIDIA-NVFP4-Q8.basalt --name "Qwen3.8-Flash-Next NVIDIA-NVFP4"
```

`--mtp-dense FILE` (the `mtp/dense` bytes of an official NVFP4, UD-IQ1\_M, UD-IQ2\_XS or UD-IQ3\_XXS pack) swaps in a tuned drafter layer; the converter records it in `meta.mtp.dense`. Output is about 122 GiB (123 GiB for the 8-bit variant). The base's vocabulary must be NVIDIA's.

Qwen3.8-27B pack
----------------

[](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md#qwen38-27b-pack)

The published pack comes from QUASAR's quantization-aware NVFP4 checkpoint ([QUASAR-QAT/Qwen3.8-27B-QUASAR-NVFP4](https://huggingface.co/QUASAR-QAT/Qwen3.8-27B-QUASAR-NVFP4)
, revision `4a22293a`, Apache-2.0, every projection NVFP4 in compressed-tensors' form) alone, no base pack: tokenizer, metadata, MTP layer and vision tower come from the checkpoint's own files. `--drafter` adds the DFlash 2 block drafter ([z-lab/Qwen3.8-27B-DFlash2](https://huggingface.co/z-lab/Qwen3.8-27B-DFlash2)
, revision `50307d4c`).

```shell
hf download QUASAR-QAT/Qwen3.8-27B-QUASAR-NVFP4 --revision 4a22293a --local-dir quasar
hf download z-lab/Qwen3.8-27B-DFlash2 --revision 50307d4c --local-dir dflash2
python3 tools/convert/convert.py --checkpoint quasar --drafter dflash2 --out Qwen3.8-27B-QUASAR-NVFP4.basalt --name "Qwen3.8-27B QUASAR NVFP4"
```

*   `gguf`: every tensor in llama.cpp's `qwen35` names. GDN, attention and MLP projections move bit for bit as `NVFP4_PLANES` (type 45, below), `1 / weight_global_scale` in FP32 (rounded once) as `<name>.scale`. The GDN a and b projections (NVFP4 in the checkpoint, 48 rows) become BF16 of their values, rounded once to nearest. The MTP layer's and the drafter's BF16 projections Q8\_0; token embedding BF16 as stored; norms F32 with the offset folded in (exact); GDN value heads in the GGUF order (rows of qkv and z, columns of the out projection, moved whole).
*   The BF16 output head becomes `F8_E4M3` rows (type 44: one byte per value, Basalt's own type id), each row's FP32 scale (its amax / 448) in `output.scale` (F32 \[rows\]), each value the nearest E4M3 code. `--head nvfp4` rounds it to `NVFP4_PLANES` instead (tensor scale amax / (6 x 448), per 16 values the UE4M3 scale with the least squared error among half to four times amax / 6): 0.72 GB instead of 1.27 GB, nine times the squared error ([precision](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-27b.md#quality-against-bf16)
    ).
*   `vision/mmproj`: the BF16 tower written as llama.cpp's clip GGUF (`qwen3vl_merger`); `vision/text_vocab` beside it.
*   The drafter's feature projection is stored as one block per target layer (`dflash.fc.N`), so the engine projects each layer's rows as the layer ends. 19.7 GiB with the drafter (21,149,505,930 bytes, SHA-256 `5ec89e71b4bd461a5abf607825d3cd99e74d2476b8ba087fd690f09a067919ba` for the published file); about a minute on the default 16 converter processes. The engine refuses a 27B pack whose MLP and head are NVFP4 in ggml blocks (type 40, before NVFP4\_PLANES) and asks for a re-conversion.

NVIDIA's checkpoint ([nvidia/Qwen3.8-27B-NVFP4](https://huggingface.co/nvidia/Qwen3.8-27B-NVFP4)
, revision `482ca0f3`) converts with the same command:

```shell
hf download nvidia/Qwen3.8-27B-NVFP4 --revision 482ca0f3 --local-dir nvidia
python3 tools/convert/convert.py --checkpoint nvidia --drafter dflash2 --out Qwen3.8-27B-NVFP4.basalt --name "Qwen3.8-27B NVFP4"
```

*   Its MLP and output head are NVFP4 and move bit for bit as `NVFP4_PLANES` with each matrix's FP32 `weight_scale_2` as `<name>.scale`; its GDN and attention projections are FP8 and keep their E4M3 codes as `F8_E4M3` with each matrix's FP32 `weight_scale` as `<name>.scale`. Everything else as above. About 22 GiB with the drafter.

### `NVFP4_PLANES` (tensor type 45)

[](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md#nvfp4_planes-tensor-type-45)

An NVFP4 matrix of `rows` x `K` (rows a multiple of 128, K of 64) as two planes in one tensor, 36 bytes per 64 values like ggml's NVFP4 blocks, the layout the dense products read with TMA (NInfer's and Infernix's `block_scale_k16_m128x4`):

*   **Codes**, `rows * K / 2` bytes from the tensor's start: row-major, byte `b` of a row holds value `2b` in its low nibble and `2b + 1` in its high nibble (E2M1, as NVIDIA's checkpoints store them).
*   **Scales**, `rows * K / 16` UE4M3 bytes right after the codes, one per 16 values: 512-byte tiles of 128 rows x 4 groups, row-block major, so the scale of row `r` and group `g` (`= k / 16`) sits at `((r / 128) * (K / 64) + g / 4) * 512 + (r % 32) * 16 + ((r % 128) / 32) * 4 + g % 4`.
*   The matrix's FP32 scale is a separate F32 \[1\] tensor `<name>.scale`; a value is `e2m1 * ue4m3 * scale`.

[nvfp4\_planes.hpp](https://github.com/jesdga95/basalt/blob/main/include/basalt/kernels/nvfp4_planes.hpp)
 is the engine's copy of this layout.

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_d5d23bb3d71545c3b0f570bb</summary>

[Skip to content](https://github.com/jesdga95/basalt/blob/main/include/basalt/core/model_format.hpp#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/include/basalt/core/model_format.hpp)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/include/basalt/core/model_format.hpp)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/include/basalt/core/model_format.hpp)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

Collapse file tree


--------------------

Files
-----

main

Search this repository(forward slash) forward slash/

/

model\_format.hpp
=================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/jesdga95/basalt/commits/main/include/basalt/core/model_format.hpp)

[](https://github.com/jesdga95/basalt/commits/main/include/basalt/core/model_format.hpp)
History

63 lines (57 loc) · 3.47 KB

/

model\_format.hpp
=================

Copy path

Top

File metadata and controls
--------------------------

*   Code

*   Blame


63 lines (57 loc) · 3.47 KB

[Raw](https://github.com/jesdga95/basalt/raw/refs/heads/main/include/basalt/core/model_format.hpp)

Copy raw file

Download raw file

Open symbols panel

Edit and raw actions

#pragma once // The .basalt model file: one file holds everything the engine, the server and the vision sidecar load. // // Layout (little-endian): // \[0, 64 KiB) FileHeader, then n\_sections SectionEntry records (the table fits in the first 64 KiB) // every section starts at a multiple of kSectionAlign, so it can be mapped, read with O\_DIRECT and // backed by huge pages; the bytes between sections are zero // // A section's bytes are opaque to the container; what each one holds is listed below. Text sections are UTF-8. // tools/model\_file.py is the Python side of this layout and must stay byte-compatible with it. // // Sections (version 2; docs/basalt-file-changelog.md lists what each version holds): // meta JSON: format/version, model name, the source GGUF metadata the engine and the server read // (\`gguf\_kv\`, with the sampling defaults as general.sampling.\*), the type, shape, size and // offset in \`gguf\` of every source tensor (\`tensors\`), provenance (source files, sizes, // sha256) and the license / attribution text // tokenizer/<file> the tokenizer directory's files (tokenizer.json, vocab.json, merges.txt, // token\_type.json, chat\_template.jinja) // dense the dense weight pool // dense.index its tensor index (text, first line "# dense index v3") // experts the routed experts' blobs // experts.layout their per-layer layout (text, first line "# experts v3"; offsets relative to \`experts\`) // gguf every non-expert tensor of the source GGUFs (token\_embd.weight, // per\_layer\_token\_embd.weight, ...), raw bytes, each starting at a multiple of // kTensorAlign within the section; meta.tensors\[name\].offset is relative to the section // engram an Engram table alone, rows of 256 IQ4\_NL values; meta.engram has the geometry // mtp/dense, mtp/dense.index, mtp/experts, mtp/draft\_vocab // the drafter (the files of an mtp runtime directory) // hc8 the 8-bit copies of the hyper-connection matrices (model\_file.hpp), required // dspark/gguf a DSpark drafter GGUF, whole; optional, meta.dspark records it // vision/mmproj the vision projector GGUF, whole // vision/<name> anything else the vision sidecar reads #include <cstdint> namespace basalt::core { constexpr char kModelMagic\[8\] = {'B', 'A', 'S', 'A', 'L', 'T', 'M', 'F'}; constexpr uint32\_t kModelVersion = 2; constexpr uint64\_t kSectionAlign = 2ull << 20; constexpr uint64\_t kHeaderBytes = 64ull << 10; constexpr uint64\_t kTensorAlign = 4096; struct FileHeader { char magic\[8\]; ///< kModelMagic uint32\_t version; ///< kModelVersion uint32\_t n\_sections; uint64\_t file\_bytes; ///< the whole file, for a truncation check uint8\_t reserved\[40\]; }; static\_assert(sizeof(FileHeader) == 64); struct SectionEntry { char name\[64\]; ///< NUL-padded uint64\_t offset; ///< from the start of the file, a multiple of kSectionAlign uint64\_t bytes; uint8\_t sha256\[32\]; uint8\_t reserved\[16\]; }; static\_assert(sizeof(SectionEntry) == 128); constexpr uint32\_t kMaxSections = (uint32\_t) ((kHeaderBytes - sizeof(FileHeader)) / sizeof(SectionEntry)); } // namespace basalt::core\
\
1\
\
2\
\
3\
\
4\
\
5\
\
6\
\
7\
\
8\
\
9\
\
10\
\
11\
\
12\
\
13\
\
14\
\
15\
\
16\
\
17\
\
18\
\
19\
\
20\
\
21\
\
22\
\
23\
\
24\
\
25\
\
26\
\
27\
\
28\
\
29\
\
30\
\
31\
\
32\
\
33\
\
34\
\
35\
\
36\
\
37\
\
38\
\
39\
\
40\
\
41\
\
42\
\
43\
\
44\
\
45\
\
46\
\
47\
\
48\
\
49\
\
50\
\
51\
\
52\
\
53\
\
54\
\
55\
\
56\
\
57\
\
58\
\
59\
\
60\
\
61\
\
62\
\
63\
\
You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_82bb6acbb213408ba7bbb4a5</summary>

[Skip to content](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

Collapse file tree


--------------------

Files
-----

main

Search this repository(forward slash) forward slash/

/

basalt-file-changelog.md
========================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/jesdga95/basalt/commits/main/docs/basalt-file-changelog.md)

[](https://github.com/jesdga95/basalt/commits/main/docs/basalt-file-changelog.md)
History

40 lines (34 loc) · 2.94 KB

/

basalt-file-changelog.md
========================

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


40 lines (34 loc) · 2.94 KB

[Raw](https://github.com/jesdga95/basalt/raw/refs/heads/main/docs/basalt-file-changelog.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

`.basalt` file format changelog
===============================

[](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md#basalt-file-format-changelog)

The version is the `u32` after the magic in the file's header. The engine reads one version; the [model file](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md)
 page describes the current one.

Version 2
---------

[](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md#version-2)

The current version. The engine refuses version 1 files and names [tools/migrations/basalt\_v1\_to\_v2.py](https://github.com/jesdga95/basalt/blob/main/tools/migrations/README.md)
, which writes a version 2 file from a version 1 file without a download or any re-quantizing.

*   **Contains:** `meta`, `tokenizer/*`, `dense`, `dense.index`, `experts`, `experts.layout`, `gguf`, `mtp/*`, `hc8`, `dspark/gguf`, `vision/*`.
*   **Added `hc8`, now required:** the int8 copies of the hyper-connection matrices the decode reads, the bits the engine used to compute at every start. A start reads them as they are and skips reading the BF16 matrices to quantize them (about half a second).
*   **Removed `profile`:** the expert profile decides which experts start in VRAM. It is placement policy that improves independently of the weights, so it moved to the engine (`data/profiles`), where a better profile needs no new file.
*   **`experts.layout` v7, no version change:** a layer whose gate and up rows differ in type (Unsloth's UD-IQ1\_S: IQ2\_S gate and IQ2\_XXS up on one layer) gives the up type as a sixth column under an `# experts v7` header. The converter writes v7 only for such a model; every other pack keeps v5 (GGUF) or v6 (NVFP4). An engine from before v7 refuses a v7 pack and asks for an update.
*   **Tensor type 45, `NVFP4_PLANES`, no version change:** NVFP4 as a code plane and 128 x 4-tiled UE4M3 scales (the TMA layout; [model file](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md#nvfp4_planes-tensor-type-45)
    ), the FP32 scale a separate `<name>.scale`. The Qwen3.8-27B pack's MLP and head use it; the engine refuses that pack's older ggml-block form.
*   **Tensor type 44, `F8_E4M3`, no version change:** one E4M3 code per value with the matrix's FP32 scale as a separate `<name>.scale` tensor (F32 \[1\]), as NVIDIA's FP8 checkpoints store them. The Qwen3.8-27B pack's projections use it. An engine from before it refuses such a tensor by name ("the dense kernels read ...").
*   **Added `dspark/gguf`, optional, no version change:** a DeepSeek pack's DSpark drafter. The engine ignores sections it does not name, so an engine from before it runs such a pack plain, and a pack without it runs plain on any engine.
*   **Trimmed `meta`:** no `sampling` (the server reads the GGUF metadata's `general.sampling.*` keys), no `profile` or `hc8` records and no converter revision, provenance that changed whenever a section was replaced.

Version 1
---------

[](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md#version-1)

*   **Contains:** `meta` (with `sampling`, `profile` and `hc8` records and the converter's git revision), `tokenizer/*`, `dense`, `dense.index`, `experts`, `experts.layout`, `gguf`, `mtp/*`, `profile`, optionally `hc8`, `vision/*`.
*   The first single-file format: everything the engine, the server and the vision sidecar load. Without `hc8` the engine quantized the hyper-connection matrices at every start.

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_79db45c1e69943beb8acb50a</summary>

**Firecrawl · section 1 of 2**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,560 characters · included below
- Section 2 · 10,292 characters · omitted from this copy

```text
[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

/

storage-layouts.md
==================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/docs/maintainer/storage-layouts.md)

[](https://github.com/iamwavecut/ninfer-all/commits/master/docs/maintainer/storage-layouts.md)
History

424 lines (308 loc) · 16.5 KB

/

storage-layouts.md
==================

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


424 lines (308 loc) · 16.5 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/docs/maintainer/storage-layouts.md)

Copy raw file

Download raw file

You must be signed in to make or propose changes

More edit options

Outline

Edit and raw actions

NInfer Persistent Storage Layouts
=================================

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#ninfer-persistent-storage-layouts)

This reference records the persistent tensor layouts and resource encoding used by current `.ninfer` artifacts, including alignment, byte order, padding, encoded-size rules, and logical decode. Numeric semantics come from [`tensor-formats.md`](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/tensor-formats.md)
; framing and object ranges come from [`artifact-container.md`](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md)
.

1\. Registered identities
-------------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#1-registered-identities)

The storage registry contains exactly these identities:

| Identity | Kind | Compatible numeric formats | Logical shape | Object alignment |
| --- | --- | --- | --- | --- |
| `contiguous_le_v1` | tensor layout | `bf16`, `fp32`, `int32`, `fp16`, `uint16` | rank `0..16` | 256 bytes |
| `row_split_k128_v1` | tensor layout | `q2_g64_fp16`, `q4_g64_fp16`, `q5_g64_fp16`, `q6_g64_fp16`, `q8_g32_fp16`, `t2_g128_fp16` | rank 2 `[N,K]` | 256 bytes |
| `block_scale_k16_m128x4_v1` | tensor layout | `nvfp4` | rank 2 `[N,K]`, `N % 128 == 0`, `K % 64 == 0` | 256 bytes |
| `row_scale_v1` | tensor layout | `fp8_e4m3fn_row_bf16` | rank 2 `[N,K]` | 256 bytes |
| `row_interleaved_v1` | tensor layout | `fp8_e4m3fn_row_fp16` | rank 2 `[N,K]` | 256 bytes |
| `gguf_blocks_v1` | tensor layout | the eighteen `gguf_*` formats | rank 2 `[N,K]`, `K % block_values == 0` | 256 bytes |
| `raw_bytes_v1` | resource encoding | not applicable | nonempty byte string | 1 byte |

These format/layout pairs define the current codec support. Native consumer requirements are covered separately in Section 9.

Object alignment applies to the object's payload-relative `offset` in the `.ninfer` JSON. Internal plane offsets and padding belong to the selected layout. Inter-object padding belongs to the container and is not included in an object's `bytes`.

The helper used below is:

    align_up(x, a) = ceil_div(x, a) * a


All formula inputs and intermediate results are nonnegative integers. The container implementation must reject a shape or calculation that cannot be represented by its file-offset and size types.

2\. `contiguous_le_v1`
----------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#2-contiguous_le_v1)

### 2.1 Logical traversal

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#21-logical-traversal)

`contiguous_le_v1` stores direct logical words in C order: the last logical dimension varies fastest. For shape `[D0, D1, ..., D(r-1)]`, coordinate `[i0, i1, ..., i(r-1)]` has linear index:

    index = (((i0 * D1 + i1) * D2 + i2) ... ) * D(r-1) + i(r-1)


A rank-zero shape `[]` contains one scalar word. For every other legal shape:

    elements = product(shape)


The layout performs no reshape, transpose, type conversion, or numerical canonicalization. Those operations, when required, occur before layout encoding under the model-specific conversion recipe.

### 2.2 Word bytes

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#22-word-bytes)

Words are serialized least-significant byte first:

| Format | Bytes per element | Stored word |
| --- | --- | --- |
| `bf16` | 2   | the exact 16-bit bfloat16 logical word, little-endian |
| `fp32` | 4   | the exact 32-bit IEEE-754 binary32 logical word, little-endian |
| `int32` | 4   | the exact 32-bit two's-complement logical word, little-endian |
| `fp16` | 2   | the exact 16-bit IEEE-754 binary16 logical word, little-endian |
| `uint16` | 2   | the exact 16-bit unsigned logical word, little-endian |

Signed zero, subnormal, infinity, NaN payload, and integer-word behavior are determined by the numeric-format contract. The layout only preserves the word bits.

### 2.3 Encoded size

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#23-encoded-size)

There is no internal prefix, stride table, per-row padding, or trailing padding:

    payload_bytes = elements * bytes_per_element(format)


The tensor object's JSON `bytes` must equal `payload_bytes` exactly.

3\. `row_split_k128_v1`
-----------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#3-row_split_k128_v1)

### 3.1 Logical and physical geometry

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#31-logical-and-physical-geometry)

The logical tensor is a positive rank-two matrix `[N,K]`. The format supplies code width `b` and group size `G`:

| Format | `b` | `G` | Base bytes per group `B` | High bytes per group `H` |
| --- | --- | --- | --- | --- |
| `q2_g64_fp16` | 2   | 64  | 16  | 0   |
| `q4_g64_fp16` | 4   | 64  | 32  | 0   |
| `q5_g64_fp16` | 5   | 64  | 32  | 8   |
| `q6_g64_fp16` | 6   | 64  | 32  | 16  |
| `q8_g32_fp16` | 8   | 32  | 32  | 0   |
| `t2_g128_fp16` | 2   | 128 | 32  | 0   |

The layout extends the last axis to a multiple of 128:

    K_pad              = align_up(K, 128)
    groups_per_row     = K_pad / G
    logical_groups     = ceil_div(K, G)
    physical_group_cnt = N * groups_per_row


`K_pad` is physical geometry and is not added to the JSON `shape`. Because every registered group size divides 128, `groups_per_row` is integral.

For the final partially logical group, lanes whose column is at least `K` have signed code zero. Its scale remains the scale of the logical group defined by the numeric-format contract. Any complete physical group after `logical_groups` has scale word `0x0000` and all codes zero. Physical padding therefore cannot change a decoded logical value.

### 3.2 Payload planes

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#32-payload-planes)

The payload contains three conceptual planes in this order:

    base-code plane
    zero padding to a 256-byte boundary
    optional high-bit plane
    zero padding to a 256-byte boundary
    binary16 scale plane


Q2, Q4, Q8 and T2 have no high-bit bytes. They still place the scale plane at the first 256-byte boundary after the base-code plane. There is no padding after the scale plane inside the object.

Within every plane, traversal order is:

    row 0 group 0, row 0 group 1, ..., row 1 group 0, ...


Bytes belonging to one group are adjacent.

### 3.3 Base-code plane

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#33-base-code-plane)

For Q4, Q5, and Q6, let `q[i]` be lane `i`'s signed code and let:

    u[i] = q[i] modulo 2^b


be its unsigned `b`\-bit two's-complement word. Each consecutive lane pair occupies one base byte:

    base[j] = (u[2*j] & 0x0f) | ((u[2*j + 1] & 0x0f) << 4)


Thus the even lane is in the low nibble and the odd lane is in the high nibble. Every G64 group occupies 32 base bytes.

For Q8, each lane occupies one byte containing its exact 8-bit two's-complement word. Lane `i` occupies byte `i`, so every G32 group occupies 32 base bytes. The numeric-format restriction that excludes code `-128` remains in force.

For T2, four consecutive lanes share one byte, lowest lane in the lowest bits:

    base[j] = u[4*j] | (u[4*j + 1] << 2) | (u[4*j + 2] << 4) | (u[4*j + 3] << 6)


with `u[i] = q[i] modulo 4`, so every G128 group occupies 32 base bytes and T2 has no high-bit plane.

Q2 uses the same quartet bit order as T2, with `u[i] = q[i] + 1` instead of two's complement. Each G64 group occupies 16 bytes. Logical padding has integer code zero, hence stored word `0b01` and a full padding byte `0x55`; wholly physical groups also have positive-zero scales.

The complete base plane is the concatenation of these per-group byte sequences in plane traversal order.

### 3.4 High-bit plane

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#34-high-bit-plane)

Only Q5 and Q6 have a high-bit plane. For each lane:

    high[i] = (u[i] >> 4) & ((1 << (b - 4)) - 1)


The high-bit stream is lane-major. Within one lane, bit 4 is emitted first, followed by bit 5 for Q6. Stream bit `t` is stored in bit `(t mod 8)` of byte `floor(t / 8)`; bit zero is therefore the first bit of every byte.

Equivalently:

*   Q5 byte 0 contains the high bit of lanes 0 through 7 in byte bits 0 through 7;
*   Q6 byte 0 contains lane 0 bits 4 and 5 in byte bits 0 and 1, lane 1 bits 4 and 5 in byte bits 2 and 3, and so on.

One Q5 G64 group occupies 8 high bytes. One Q6 G64 group occupies 16 high bytes.

### 3.5 Scale plane

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#35-scale-plane)

Every physical group owns one 16-bit scale word. Scale words follow the same row/group traversal as the code planes and are stored little-endian:

    scale_index(row, group) = row * groups_per_row + group


For a logical group, the word is exactly the binary16 multiplier defined by its numeric format. The padding rule in Section 3.1 defines the scale words for wholly physical groups.

### 3.6 Plane offsets and encoded size

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md#36-plane-offsets-and-encoded-size)

Let:

    base_bytes  = N * groups_per_row * B
    high_bytes  = N * groups_per_row * H
    scale_bytes = N * groups_per_row * 2

    base_offset  = 0
    high_offset  = align_up(base_bytes, 256)
    scale_offset = high_offset + align_up(high_bytes, 256)

    payload_bytes = scale_offset + scale_bytes


The byte ranges are:

```

</details>

## Assistant · #31

<details><summary>Reasoning · 3,692 characters</summary>

Need artifact-container.md. Could scrape. Also maybe ninfer docs for decision framework? User mentions decision framework ported, but primary question format differences and size. Need mention decisions? Maybe review upstream basalt and ninfer-all, see where .ninfer artifacts differ from Basalt's framework. Need likely include decision framework? They host decisive-basalt. Could compare upstream basalt lacks typed decisions? ninfer-all has typed decisions / System One. CommanderTurtle decisive-ninfer branch added original decision framework later ported to ninfer-all. decisive-basalt is user's framework around Basalt. Need maybe inspect those repos to see decisions. User says "The project also ported my decision framework (see branches ...)" and "I also personally host decisive-basalt framework." Could be relevant: how far off ports? Need maybe mention ninfer-all supports typed decisions, but basalt upstream doesn't (unless decisive-basalt). Need check upstream basalt for decisions? Search code/docs. The README likely doesn't mention decisions. But user asks "Do a review of both upstream basalt and then formerly ninfer-all, and, see where the .ninfer artifacts are different (if at all) from Basalt's framework. The batched inference through .basalt checkpoints - namely the model I currently serve ... differs greatly (100+GB) than the one recognized by the engine ... Thuswise, how far off are the ports, since, both .basalt artifacts (basalt is a fork of strata) and .ninfer artifacts are indeed unified along the front of Flash Next's model type?"

Maybe user expects: compare artifact formats and model architecture support. Need maybe "upstream basalt" includes Strata? "basalt is a fork of strata". NInfer-all merged Strata? They want know whether .ninfer and .basalt unified on model type front, but sizes differ. We need answer: not off in model semantics; artifacts are different by design. .basalt is one-file sectioned opaque container (BASALTMF) with GGUF raw sections, dense/experts/hc8/mtp/vision/tokenizer/meta; .ninfer is object manifest JSON + aligned payload, components, GGUF block passthrough, separate ngram table artifact, Q8_0 hyper-connection, proposal/dflash/vision attachments. Size differences due components and representation, not model type mismatch. The Shockem pack is Flash Next MoE with Q8 PLE and abliterated experts; WaveCut recognized artifact is 27B dense GSQ IQ3_S; not same model. For same Flash Next IQ3_S, NInfer artifact is 54.24 GiB plus 26.92 GiB IQ4_NL table = 81.16 GiB total. Shockem Basalt is 105.7 GiB because ngram table included and stored Q8_0 54.4 GiB rather than IQ4_NL 26.92 GiB. Difference ≈ 24.55 GiB; plus MTP/vision/tokenizer/hc8 maybe included in 54.24 NInfer? Need compute. Shockem 105.7 = experts 46.84 + PLE Q8 54.4 = 101.24; plus other components maybe 4.5 GiB? The HF says experts 46.84 GiB; PLE 54.4; file 105.7, leaving ~4.45 for other weights/vision/MTP/hc8/tokenizer. NInfer 54.24 includes dense weights, routed experts, vision, MTP, DFlash2, excluding ngram. It likely also has hyperconnection Q8. The routed experts in NInfer IQ3_S artifact maybe 50.3? Wait doc says host experts 50.3 GB pinned; device experts 53.7 GiB total including dense? Routed experts 512*48. Shockem experts 46.84 GiB IQ3_S. Difference maybe due expert layout? But same GGUF blocks, so bytes similar. Need not overfocus.

Need inspect NInfer artifact-container for .ninfer. Also perhaps tensor-formats for gguf and ngram table. Also maybe docs/weight-conversion. Let's scrape artifact-container and maybe tensor-formats section? Could be large but enough. Use web_scrape raw? GitHub blob page maybe big. artifact-container.md.


</details>

<details><summary>Tool request · web_scrape · call_f0a525c72e7b4e1da0fa9117</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_4ffee52fdffe49df899bbdcf</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_28d59bb4b1794165803dc47d</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_fa1b17318bf342fcb5277d05</summary>

```json
{
  "url": "https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md"
}
```

</details>


<details><summary>Tool result · web_scrape · call_f0a525c72e7b4e1da0fa9117</summary>

**Firecrawl · section 1 of 3**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,911 characters · included below
- Section 2 · 11,894 characters · omitted from this copy
- Section 3 · 8,498 characters · omitted from this copy

````text
[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

/

artifact-container.md
=====================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/docs/maintainer/artifact-container.md)

[](https://github.com/iamwavecut/ninfer-all/commits/master/docs/maintainer/artifact-container.md)
History

745 lines (575 loc) · 36.3 KB

/

artifact-container.md
=====================

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


745 lines (575 loc) · 36.3 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/docs/maintainer/artifact-container.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

NInfer v3 容器规范
==============

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#ninfer-v3-%E5%AE%B9%E5%99%A8%E8%A7%84%E8%8C%83)

V3 保存精简的模型实例配置、实际对象、逻辑绑定与所需资源。数学公式、组件交接和状态程序 由模型代码定义。Reader 与 writer 根据本文即可独立实现文件组织和引用； 对应架构的 binder 再解释逻辑参数与配置。

一个 artifact 有固定入口和一份总目录。较小时是一个 `.ninfer` 文件，较大时由入口加续卷组成。 对象使用统一的逻辑 payload 偏移，文件分片保持每个对象的编码、布局和绑定关系。

1\. 合同与记法
---------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#1-%E5%90%88%E5%90%8C%E4%B8%8E%E8%AE%B0%E6%B3%95)

| 内容  | 权威  |
| --- | --- |
| 文件头、JSON、对象与引用、文件分片、v3 持久名称 | 本文  |
| 固定数学、精简 config、逻辑参数 shape、组件输入 | 对应架构的[配置](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen3_5/config.h)<br>与[绑定](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen3_5/load) |
| Format 的数值解码、有效 codes/scales | [数值格式](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/tensor-formats.md)<br>；持久名称见第 6 节 |
| Layout 的 planes、packing、内部 padding 与 encoded size | [存储布局](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md)<br>；持久名称见第 6 节 |
| 原生 Op 参数、支持范围、数值与 scratch | 对应 Op 合同 |
| 驻留、状态、容量、CUDA Graph 和结果发布 | [Engine 架构](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/engine-architecture.md)<br>及其资源合同 |

本文的整数均为精确整数，布尔值和浮点值分别按各自类型解释。

| 记法  | 定义  |
| --- | --- |
| U64 | `0..18446744073709551615` 的整数 |
| PositiveU64 | 严格大于零的 U64 |
| ID  | 非空 UTF-8 字符串，不含 U+0000，按原字符序列精确比较 |
| Shape | 长度 `0..16` 的正整数列表；空列表 `[]` 表示一个 scalar |
| `elements(shape)` | 空 shape 为 1，其余为维度乘积 |
| `[begin,end)` | 左闭右开的区间 |\
| `align_up(x,a)` | `ceil_div(x,a)*a` |\
\
乘积、前缀和、偏移加法与对齐结果须处于 U64 范围内。实际 I/O 和内存消费者检查自己的 地址范围。文件格式使用 64 位尺寸，Op 的实际 shape 支持由其调用入口决定。\
\
Header 整数采用 little-endian。JSON 使用 UTF-8，每个对象的成员名唯一。成员顺序、普通 字符串转义和 JSON 空白保持标准 JSON 含义。尺寸字段采用 JSON 整数，模型实数参数按其合同 要求的精度保存和解析。\
\
字段表列出通用记录的完整成员集合及可选性。未列出的通用字段是 schema 错误； `config` 交给架构解释，`metadata` 和 `provenance` 是第 10 节定义的开放资料对象。\
\
2\. 文件集合与地址空间\
-------------\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#2-%E6%96%87%E4%BB%B6%E9%9B%86%E5%90%88%E4%B8%8E%E5%9C%B0%E5%9D%80%E7%A9%BA%E9%97%B4)\
\
### 2.1 入口与续卷\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#21-%E5%85%A5%E5%8F%A3%E4%B8%8E%E7%BB%AD%E5%8D%B7)\
\
Writer 根据指定的入口输出路径生成文件集合。入口为 `example.ninfer` 时，文件名统一为：\
\
    example.ninfer\
    example.ninfer.part-0001\
    example.ninfer.part-0002\
    \
\
入口保存 header、JSON 总目录及第一段 payload。每个续卷保存自己的小 header 与后续 payload。 Writer 将续卷命名为 `<入口文件名>.part-<序号>`，入口文件名包含原扩展名；序号等于该续卷在 `files` 表中的下标，从 1 开始，以十进制表示，不足四位时左侧补零至四位，四位及以上完整输出。 续卷名由此规则自动派生，无独立命名参数；实际文件名写入 `files[i].path`。\
\
用户始终打开入口。Reader 按 `files` 表记录的文件名定位续卷；上述生成命名规则不作为读取 校验条件，目录中满足第 3.3 节路径规则的文件名均可读取。\
\
同一组文件具有相同的 16-byte `artifact_id`。它用于核对入口与续卷的归属，建议 writer 每次 生成新的文件集合时使用新的 UUID。它是容器集合标识，模型实现选择仍依据架构和实例参数。 Header 中保存原始 16 字节；打印时可用 32 个小写十六进制字符表示。\
\
### 2.2 逻辑 payload\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#22-%E9%80%BB%E8%BE%91-payload)\
\
令 `files[i].payload_bytes = B_i`，定义：\
\
    P_0 = 0\
    P_i = sum(B_j, j < i)\
    payload_bytes = sum(B_i)\
    \
\
文件 i 保存逻辑 payload 的 `[P_i,P_i+B_i)`。这是一组有序、连续的区间。 对象的 `offset` 始终相对于这个逻辑 payload；各文件的 header、JSON 和 payload 前的对齐区 均不计入逻辑 payload。\
\
Loading\
\
flowchart LR\
    O\["对象 offset + bytes"\] --> L\["逻辑 payload 区间"\]\
    L --> A\["入口中的相交区间"\]\
    L --> B\["续卷中的相交区间"\]\
    A --> D\["同一个驻留对象的对应位置"\]\
    B --> D\
    D --> V\["原来的 parent、planes 和逻辑 view"\]\
\
对象可以跨越文件边界。它仍是一个对象，其 format/layout 以完整对象的逻辑起点计算。 分片边界也可以位于某个 plane 内部；读取与复制保持原始字节顺序。\
\
### 2.3 默认单文件与显式分片上限\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#23-%E9%BB%98%E8%AE%A4%E5%8D%95%E6%96%87%E4%BB%B6%E4%B8%8E%E6%98%BE%E5%BC%8F%E5%88%86%E7%89%87%E4%B8%8A%E9%99%90)\
\
Writer 默认**不分片**：无论大小，artifact 只生成入口文件，模型所需的一切都在这一个带索引的 文件中，运行时只读取当前放置所需的对象。\
\
只有显式给出单文件大小上限（`--max-file-bytes`）时才分片，例如文件系统或传输限制单文件大小。 上限计入文件头、JSON、payload 前的对齐区和该文件的 payload。上限是生成策略，文件中只保存 实际分片结果，reader 按目录读取。若 `entry_payload_start + payload_bytes <= limit`，writer 只 生成入口文件。超过上限时，入口先容纳第一段，剩余数据依次进入续卷。\
\
对给定的 entry\_payload\_start，当前 writer 的分片容量为：\
\
    entry_capacity = floor((limit - entry_payload_start) / 4096) * 4096\
    part_capacity  = floor((limit - 4096) / 4096) * 4096\
    \
\
需要分片时，先检查上限足以容纳头部且两种容量均为正；非末段按容量写满，末段写剩余字节。 分片数量由数据量和容量决定。 这种放置使各段的逻辑起点保持 4096-byte 对齐，便于 direct I/O；reader 的范围映射也接受 其他满足本规范的正长度分段。\
\
3\. 二进制 framing\
---------------\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#3-%E4%BA%8C%E8%BF%9B%E5%88%B6-framing)\
\
### 3.1 入口 header\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#31-%E5%85%A5%E5%8F%A3-header)\
\
入口 header 长度固定为 32 字节。\
\
| Offset | Bytes | 字段  | 编码与含义 |\
| --- | --- | --- | --- |\
| 0   | 8   | magic | `4e 49 4e 46 45 52 00 03`，即 `NINFER`、零字节、版本 3 |\
| 8   | 8   | json\_bytes | Little-endian PositiveU64；完整 UTF-8 JSON 文本长度 |\
| 16  | 16  | artifact\_id | 文件集合标识的原始字节 |\
\
    json_offset         = 32\
    metadata_end        = 32 + json_bytes\
    entry_payload_start = align_up(metadata_end, 4096)\
    entry_file_bytes    = entry_payload_start + files[0].payload_bytes\
    \
\
Reader 核对完整 magic，读取 `[32,metadata_end)` 的 JSON，并检查实际文件长度等于 entry\_file\_bytes。`[metadata_end,entry_payload_start)` 是文件对齐区，writer 写零。\
\
JSON 的合法尾部空白计入 json\_bytes。Writer 可以用它预留确定的目录空间，再安排入口中的 payload 容量；这避免分片表长度变化反复移动 payload。Reader 按标准 JSON 解析这段文本。\
\
### 3.2 续卷 header\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#32-%E7%BB%AD%E5%8D%B7-header)\
\
续卷 header 同样为 32 字节，payload 固定从文件 offset 4096 开始。\
\
| Offset | Bytes | 字段  | 编码与含义 |\
| --- | --- | --- | --- |\
| 0   | 8   | magic | `4e 49 4e 50 52 54 00 03`，即 `NINPRT`、零字节、版本 3 |\
| 8   | 8   | part\_index | Little-endian PositiveU64；对应 `files` 数组下标 |\
| 16  | 16  | artifact\_id | 与入口逐字节相同 |\
\
    part_payload_start = 4096\
    part_file_bytes    = 4096 + files[part_index].payload_bytes\
    \
\
Writer 将 `[32,4096)` 写零。Reader 打开续卷时核对 magic、part\_index、artifact\_id 和实际长度。 入口与续卷有不同 magic；一个续卷通过入口目录参与读取。\
\
### 3.3 文件目录\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#33-%E6%96%87%E4%BB%B6%E7%9B%AE%E5%BD%95)\
\
根字段 `files` 是非空数组。数组第 0 项描述入口，其余项描述续卷。\
\
| 字段  | 类型  | 含义  |\
| --- | --- | --- |\
| path | 第 0 项为 null；其余为字符串 | 相对于入口目录的同级文件名 |\
| payload\_bytes | PositiveU64 | 该文件保存的逻辑 payload 字节数 |\
\
```json\
[\
  {"path": null, "payload_bytes": 31999934464},\
  {"path": "example.ninfer.part-0001", "payload_bytes": 4096}\
]\
```\
\
续卷 path 是一个非空文件名，采用原字符序列；其中不含 `/`、`\\` 或 U+0000，名称也不等于 `.` 或 `..`。续卷文件名互不重复，且与本次打开的入口文件名不同。目录可以整体移动。\
\
上面的数值示例取 entry\_payload\_start=65536，因此入口文件恰好为 32,000,000,000 字节。 第二个文件的实际大小为 8192 字节。\
\
4\. JSON 总目录\
------------\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#4-json-%E6%80%BB%E7%9B%AE%E5%BD%95)\
\
### 4.1 根记录\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#41-%E6%A0%B9%E8%AE%B0%E5%BD%95)\
\
| 字段  | 类型 / 必需性 | 含义  |\
| --- | --- | --- |\
| components | 非空 Object，必需 | 实际提供的模型组件及精简配置 |\
| objects | 非空 Array，必需 | 按逻辑 payload offset 排列的物理对象 |\
| bindings | Object，必需 | 完整逻辑参数名到 Binding 的映射 |\
| uses | Array，必需 | 按数学使用位置展开的计算许可与辅助输入 |\
| files | 非空 Array，必需 | 第 3.3 节文件目录 |\
| metadata | Object，可选 | 公开名称等第 10 节资料 |\
| provenance | Object，可选 | 来源、训练配对与转换说明 |\
\
Framing 版本已经确定 JSON 语法，根记录直接使用上述字段。完整的 JSON 示例见第 12 节。\
\
### 4.2 组件记录\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#42-%E7%BB%84%E4%BB%B6%E8%AE%B0%E5%BD%95)\
\
`components` 的键是组件 ID。`text` 是主模型；当前可选组件使用 `vision`、`mtp`、`dflash`、 `dflash2`，Qwen3.8-Flash-Next 另有 `ngram`（n-gram 表的描述，见 [Flash-Next 说明](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)\
）。只含 `ngram` 的产物是一张独立的 n-gram 表，没有 `text`。新的实际架构或后端可以使用同一记录结构，由对应编译代码解释其 ID 和 config。\
\
| 字段  | 类型 / 必需性 | 含义  |\
| --- | --- | --- |\
| config | Object，必需 | 架构标识与本组件的少量实例参数 |\
| target | 组件 ID，可选 | 本组件所关联的目标组件 |\
| resources | Object，可选 | 资源角色到 resource 对象 ID 的映射，省略表示空映射 |\
| proposal | Object，可选，仅 text | 主模型所附的可选 proposal 输出表示，见第 9.2 节 |\
\
Config 使用对应架构的标准 architectures/model\_type 与保留字段。 例如 Qwen Text 包含 architectures、model\_type、hidden\_size 等；Vision 使用自己的标准 model\_type；当前 Qwen MTP 的 config 只需 architectures，几何通过 target 取得。 源适配解释上游 `text_config`、`vision_config` 等组织，再把规范化结果写入对应组件的 config； 组件的 target、resources 和 proposal 按本节字段表单独放置。\
\
```json\
{\
  "config": {"architectures": ["Qwen3_5MTP"]},\
  "target": "text"\
}\
```\
\
Target 引用须能找到对应组件，其数学关联由架构 binder 检查。当前 Vision 与 spec 的 target 均为 text。固定特征采集位置、状态操作和功能准备流程由该组件代码定义。\
\
组件声明表示产物提供它。启动选项决定本次启用的组件；text、所选组件及其实际共享数据参与 加载。Writer 对所声明组件的数据完整性负责，binder 对启动所选功能检查数学与数据需求。\
\
5\. 物理对象\
--------\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#5-%E7%89%A9%E7%90%86%E5%AF%B9%E8%B1%A1)\
\
### 5.1 Tensor 对象\
\
[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md#51-tensor-%E5%AF%B9%E8%B1%A1)\
\
| 字段  | 类型  | 含义  |\
| --- | --- | --- |\
| id  | ID  | 本 artifact 内唯一的对象引用名 |\
| kind | `tensor` | 对象类别 |\
| shape | Shape | 存储对象的逻辑 shape，采用 C-order 元素坐标 |\
| format | ID  | 第 6 节的数值格式 |\
| layout | ID  | 第 6 节的布局 |\
| offset | U64 | 对象起点在逻辑 payload 中的字节偏移 |\
| bytes | PositiveU64 | 该对象完整编码的字节数 |\
| divisors | PositiveU64 | 可选，缺省为 1。堆叠进本平面且各自独立量化的源矩阵数量；每个源矩阵各持一个 NVFP4 权重除数，按平面行数均分。仅 `nvfp4` 与 `block_scale_k16_m128x4_v1` 允许大于 1 |\
\
```json\
{\
  "id": "w.attn.qk",\
  "kind": "tensor",\
  "shape": [7168, 5120],\
  "format": "q4_g64_fp16",\
  "layout": "row_split_k128_v1",\
  "offset": 0,\
  "bytes": 19496960\
}\
```\
\
Shape 描述对象的逻辑值域；layout 自己计算物理 padding、planes 和 encoded size。 例如 Q4 的 K 维 padding 由 row\_split\_k128\_v1 计算。对象可以容纳多个投影或多个专家， 其数学用途由第 7 节绑定给出。\
\
一个已编码对象包含其 codec/layout 要求的全部 planes 和对象级标量。现有 NVFP4 的 block scales 与 weight divisor 在对象内；现有逐行 FP8 的 row scales 也在对象内。 Op 所需的独立指针从这个对象的既定布局取得。使用位置的 activation divisor 则单独绑定，见第 8 节。\
\
### 5.2 Resource 对象\
\
````

</details>

<details><summary>Tool result · web_scrape · call_4ffee52fdffe49df899bbdcf</summary>

**Firecrawl · section 1 of 5**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,679 characters · included below
- Section 2 · 11,875 characters · omitted from this copy
- Section 3 · 11,881 characters · omitted from this copy
- Section 4 · 11,393 characters · omitted from this copy
- Section 5 · 9,245 characters · omitted from this copy

````text
[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

FilesExpand file tree


-----------------------

master

/

weight-conversion.md
====================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/docs/weight-conversion.md)

[](https://github.com/iamwavecut/ninfer-all/commits/master/docs/weight-conversion.md)
History

862 lines (718 loc) · 49.3 KB

master

/

weight-conversion.md
====================

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


862 lines (718 loc) · 49.3 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/docs/weight-conversion.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

Weight conversion
=================

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#weight-conversion)

NInfer's converter creates `.ninfer` artifacts from local weights and a Python recipe. A recipe can reuse an official conversion, change selected layers or projections, combine sources, or call your own conversion method. The artifact contains the resulting configuration, encoded weights, logical bindings and frontend resources.

Run the commands below from the repository root.

Upgrade an existing v2 artifact
-------------------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#upgrade-an-existing-v2-artifact)

The offline upgrade tool supports the official Qwen3.6/3.8-27B groupwise-int and NVFP4 artifacts, and Qwen3.6-35B-A3B groupwise-int. Update your checkout to the current `master` and [rebuild NInfer](https://github.com/iamwavecut/ninfer-all/blob/master/README.md#building)
, then run with Python 3.11:

```shell
python3 tools/upgrade_ninfer_v2_to_v3.py \
  models/qwen3_8_27b_nvfp4.ninfer \
  models/qwen3_8_27b_nvfp4.v3.ninfer
```

The output must use a new path. After upgrading, use it directly or rename it to replace the original file. Stored weight values and formats are preserved. The upgrade also installs the matching template from `tools/chat_templates/`. Published SHA-256 checksums apply only to downloaded files.

Start with an official recipe
-----------------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#start-with-an-official-recipe)

Source-weight conversion requires a Python 3.11 environment with PyTorch and NumPy. It uses CUDA by default; `--device cpu` selects CPU conversion. PyTorch runs one thread per CPU the process may use, capped by a container's CPU quota; `OMP_NUM_THREADS` overrides that. The input paths below are placeholders for your local checkpoint directories.

For Qwen3.6-27B floating-point source weights:

```shell
python3 -m tools.convert \
  --model /path/to/Qwen3.6-27B \
  --recipe qwen3_6_27b \
  --components text,vision,mtp \
  --resource chat_template.jinja=tools/chat_templates/qwen3_6.jinja \
  --proposal \
  --name qwen3.6-27b \
  --out models/qwen3_6_27b.ninfer
```

`--components` defaults to `text` (`text,ngram` for Qwen3.8-Flash-Next). Include only the optional components you want to distribute. Flash-Next also accepts `--layers A..B` for a zero-based, half-open source layer slice with its embedding and head. Source indices survive in provenance; runtime blocks are renumbered from zero. A slice without PLE needs no n-gram table. These are qualification models, not full-model quality candidates; see [Flash-Next conversion](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#convert)
. Flash-Next conversions storing the n-gram table also embed `ngram.hot` from the checkpoint directory when present. `--resource ngram.hot=PATH` selects a different profile made by `ninfer-ngram-profile`. The converter checks its hash constants and row IDs before writing it as `ngram.resources.hot_profile`; standalone table artifacts need no frontend resources. The profile changes residency selection, not table bytes or the table digest. `--proposal` adds the indexed proposal head used by speculative decoding; it uses the repository's token ranking and defaults to 131,072 rows. The ordinary full-vocabulary output head is retained.

The built-in recipes are ordinary Python functions in [`official_recipes.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/official_recipes.py)
:

| Recipe | Main representation choices | Additional source |
| --- | --- | --- |
| `qwen3_6_27b` | Q4/Q5 projections, Q6 vocabulary weights | None |
| `qwen3_8_27b` | Q4/Q5 projections, Q8 vocabulary weights | None |
| `qwen3_8_27b_q6` | Q4/Q5 projections, Q6 MLP gate/up, Q8 vocabulary weights | None |
| `qwen3_8_27b_imatrix` | `grouped_search` with signed scales; Q4/Q5 projections, Q4 mixer outputs and MLP down in layers 36-63, Q4 embedding, Q6 head | `imatrix` |
| `qwen3_6_35b_a3b` | Q4 experts, Q5/Q6 expert down, Q8 shared/projection weights | None |
| `qwen3_6_35b_a3b_nvfp4` | Imported NVFP4 routed and shared experts, Q8 projection weights, Q8/Q6 vocabulary weights | `quantized` |
| `qwen3_6_27b_nvfp4` | Imported NVFP4, selected BF16 projections, Q8 vocabulary weights | `quantized` |
| `qwen3_8_27b_nvfp4` | Imported NVFP4/FP8, FP8 embedding generated from BF16 | `quantized` |
| `qwen3_8_27b_nvfp4_nvidia` | nvidia/Qwen3.8-27B-NVFP4 (ModelOpt AutoQuant): imported NVFP4 MLP projections and per-row FP8 attention and GDN projections; FP8 embedding, and the NVFP4 output head re-quantized to FP8 | `quantized` |
| `qwen3_8_27b_nvfp4_orcarouter` | orcarouter/Qwen3.8-27B-Uncensored-NVFP4 (GPTQ compressed-tensors): imported NVFP4 MLP projections in layers 0-55, per-row FP8 everywhere else; FP8 embedding and output head from BF16 | `quantized` |
| `bonsai2_27b_ternary` | Imported ternary T2 text tower with Hadamard-rotated Uses, Q8 primal embedding | `ternary` (GGUF) |
| `qwen3_8_27b_gguf` | Every text, embedding, head and MTP tensor in its GGUF block format, byte for byte; an untied BF16 output head as BF16 words | `gguf` (GGUF), `vision` (mmproj GGUF) |
| `qwen3_8_flash_next_gguf` | Qwen3.8-Flash-Next: every text tensor in its GGUF block format, byte for byte, expert banks expert-major, and the n-gram table's IQ4\_NL rows in the same artifact or in a table artifact of their own; every hyper-connection matrix as ggml Q8\_0 rows (the release's BF16 ones re-quantised); the MTP block from an MTP GGUF, its matrices in their blocks | `gguf` (the release's first shard), `ngram` (its second shard), `vision` (mmproj GGUF), `mtp` (an MTP GGUF) |
| `edge0_pack`, `edge0_pack_q8`, `edge0_pack_q4` | Edge0-145B and Edge0-120B from an Edge0 release folder: the Flash-Next skeleton GGUF as `qwen3_8_flash_next_gguf` reads it, every latent expert row (NVFP4, Q3\_K, IQ4\_NL) and encoder and decoder row (Q8\_0 or Q4\_0: the release's choice, or the one the recipe names) byte for byte, the labels, the NVFP4 experts' FP32 multipliers or the reciprocals of the Q3\_K builds' column scales; the FP8 n-gram table's codes in the artifact or in a table artifact of their own; the release's MTP block | `pack` (the release folder); `gguf`, `ngram`, `mtp` override its files |
| `gemma4_gguf` | Gemma 4 26B-A4B from Google's QAT GGUF (or a mixed-format GGUF of it): every matrix in its block format (Q4\_0, the tied token table Q6\_K), byte for byte, a block's Q, K and V grouped into one parent when they share a format and the \[gate; up\] MLP projections always, the vectors and expert scales as FP32; with `--components text,mtp` the assistant from its own GGUF the same way | `gguf`, `mtp` |
| `flint_gguf` | Flint from a llama.cpp GGUF (Unsloth's UD-Q4\_K\_XL or another quantization): every matrix in its block format, byte for byte, the routed experts' gate and up banks interleaved per expert by whole rows, a block's Q, K and V grouped into one parent when they share a format and the \[gate; up\] rows of the dense MLP and the shared expert always, the router (BF16 in the GGUF), norms and sinks as FP32 | `gguf` |
| `deepseek_v41_gguf` | DeepSeek-V4.1-Flash from ISTA-DASLab's split GSQ-RCO GGUF, in llama.cpp's layout or the earlier one: every matrix in its block format, byte for byte, the routed experts' gate and up banks interleaved per expert by whole rows, the BF16 and F32 tensors (router, compressors, indexers, hyper-connection matrices, norms, sinks) as FP32, the Engram gate as the FP32 product of its BF16 factors; the Engram GGUF's IQ4\_NL rows in the same artifact or in a table artifact of their own | `gguf` (the first shard), `engram` (the Engram GGUF), `dspark`, `vision`, `bias_vl` (the earlier layout's image routing bias) |

The QUASAR Qwen3.8-27B NVFP4 checkpoint, which quantizes every Linear layer to NVFP4, has a driver of its own, `python3 -m tools.convert.quasar_nvfp4 --model DIR --dflash2 REFERENCE.ninfer --out PATH`: it imports the NVFP4 codes verbatim, keeps the BF16 parameters, and takes the DFlash2 draft from a reference v3 artifact.

These names select conversion choices. Runtime execution is selected from the architecture, configuration and actual bindings stored in the artifact. `--name` sets the public model name; it does not select kernels.

`qwen3_8_27b_q6` differs from `qwen3_8_27b` in one place: the MLP gate and up projections carry Q6 instead of Q4. Those two parameters are 43% of the text weights, and at 4.25 bits per weight Q4 leaves precision unused there (11.5% relative weight error against 2.6% for Q6 at 6.25 bits per weight). The vocabulary endpoints deliberately stay Q8, which at 8.5 bits per weight already outranks Q6.

```shell
python3 -m tools.convert \
  --model /path/to/Qwen3.8-27B \
  --recipe qwen3_8_27b_q6 \
  --components text,vision,mtp \
  --resource chat_template.jinja=tools/chat_templates/qwen3_8.jinja \
  --proposal \
  --name qwen3.8-27b-q6 \
  --out models/qwen3_8_27b_q6.ninfer
```

Measured with `ninfer-perplexity` over a 47,917-token corpus at `--context 4096 --stride 2048` with `--kv-dtype int8`, this artifact scores 1.520765 against 1.524538 for `qwen3_8_27b` and 1.530857 for `qwen3_8_27b_nvfp4`.

The FFN evaluates a Q6 gate/up pair through its existing materialized decomposition (the generic `linear` op followed by `silu_mul`) rather than the fused `linear_swiglu` op, which has no Q6 variant. That decomposition costs nothing measurable: forcing the fused Q4 route through the same decomposition moves the corpus perplexity from 1.524538 to 1.524618.

`qwen3_8_27b_imatrix` spends fewer bytes per decoded token than `qwen3_8_27b` and recovers the quality with the importance-weighted `grouped_search` (described under [Formats, methods and activation precision](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#formats-methods-and-activation-precision)
). It needs an importance matrix from llama.cpp's `llama-imatrix`; Unsloth publishes one for Qwen3.8-27B (`imatrix_unsloth.gguf`). Import it, then convert:

````

</details>

<details><summary>Tool result · web_scrape · call_28d59bb4b1794165803dc47d</summary>

**Firecrawl · section 1 of 25**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,405 characters · included below
- Section 2 · 11,104 characters · omitted from this copy
- Section 3 · 11,694 characters · omitted from this copy
- Section 4 · 8,248 characters · omitted from this copy
- Section 5 · 11,392 characters · omitted from this copy
- Section 6 · 11,805 characters · omitted from this copy
- Section 7 · 11,927 characters · omitted from this copy
- Section 8 · 11,679 characters · omitted from this copy
- Section 9 · 11,960 characters · omitted from this copy
- Section 10 · 11,853 characters · omitted from this copy
- Section 11 · 11,308 characters · omitted from this copy
- Section 12 · 10,540 characters · omitted from this copy
- Section 13 · 11,430 characters · omitted from this copy
- Section 14 · 11,924 characters · omitted from this copy
- Section 15 · 11,622 characters · omitted from this copy
- Section 16 · 11,809 characters · omitted from this copy
- Section 17 · 11,555 characters · omitted from this copy
- Section 18 · 11,499 characters · omitted from this copy
- Section 19 · 11,000 characters · omitted from this copy
- Section 20 · 11,841 characters · omitted from this copy
- Section 21 · 11,798 characters · omitted from this copy
- Section 22 · 11,307 characters · omitted from this copy
- Section 23 · 11,952 characters · omitted from this copy
- Section 24 · 11,835 characters · omitted from this copy
- Section 25 · 1,213 characters · omitted from this copy

````text
[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

FilesExpand file tree


-----------------------

master

/

serving.md
==========

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/docs/serving.md)

[](https://github.com/iamwavecut/ninfer-all/commits/master/docs/serving.md)
History

3085 lines (2719 loc) · 254 KB

master

/

serving.md
==========

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


3085 lines (2719 loc) · 254 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/docs/serving.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

HTTP serving
============

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#http-serving)

`build/apps/ninfer-serve` loads one v3 `.ninfer` artifact and exposes OpenAI-, Anthropic- and llama.cpp-compatible HTTP endpoints over one resident NInfer Engine, or serves a catalog of artifacts as a [router](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#several-models-router)
, one Engine per loaded model.

Start the server
----------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#start-the-server)

See [CUDA synchronization](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#cuda-synchronization)
 for the shared `NINFER_CUDA_SYNC` setting. The options can also come from a file: `--config FILE` reads them, the command line overrides the file, and `configs/` holds one for each [launch recipe](https://github.com/iamwavecut/ninfer-all/blob/master/docs/recipes.md)
 ([launch configuration files](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#launch-configuration-files)
).

```shell
./build/apps/ninfer-serve models/qwen3_8_27b.ninfer \
  --host 127.0.0.1 \
  --port 8080 \
  --max-context 240000 \
  --kv-capacity 240000 \
  --max-concurrency 2 \
  --kv-dtype rk4v4 \
  --device-state-slots 2 \
  --host-state-slots 8 \
  --host-kv-mib 8192 \
  --spec mtp --draft-tokens 3 \
  --lm-head-draft \
  --preserve-thinking
```

The command uses the official Qwen3.8-27B `groupwise-int` artifact. Each request has a 240,000-token logical ceiling. A shared 240,000-token Main Text KV pool serves admitted requests; either request may use the full capacity when running alone, and two requests run concurrently when their complete reservations fit.

With `C=2` and two extra Device checkpoint slots, the process owns two active StateImage guarantees plus a global pool of two Device-resident checkpoints. Eight pinned Host State slots and 8 GiB of pinned Host KV retain inactive continuations under Device pressure. Active request capacity is two.

`--host-state-slots` and `--host-kv-mib` are independent allocations, so their sum — not `--host-kv-mib` alone — is the Host RAM the process pins: a Host StateImage costs one `memory.host_state_image_bytes` regardless of the prefix depth it resumes. `--host-cache-mib N` replaces both with a single ceiling: the engine sizes the Host state pool from the checkpoint inventory the capture path creates, `(2 + max-long-anchors-per-continuation) * private continuations + shared prefixes` images, then, with `--auto-long-anchors` and a nonzero anchor count, spends the remaining state headroom under the half-budget cap on **more long anchors per continuation** — up to the count whose re-prefill gap still outweighs one StateImage — re-sizes the pool for the grown count, gives Host KV the remaining bytes, and refuses to start if that state footprint would exceed half the budget. A budget therefore never lowers the configured anchor count, and the count it resolves is the one the frontend grid, the ResourceManager and the Program all use; without automatic anchoring only client markers and the engine's endpoint and branch anchors create anchors, so the count stays as configured. Both unit costs and the derived split are reported in the `server_start` memory ledger.

Other artifacts use the same command shape with their own path. For 35B-A3B DFlash, replace the MTP selection with `--spec dflash --draft-tokens 7 --lm-head-draft`. Qwen3.8-27B artifacts with DFlash2 companion weights also support `--spec dflash2 --draft-tokens 7`. DFlash2 accepts draft counts 1..15 and supports the same sampling, concurrency, prefix reuse, and image/video request surfaces. It may remain combined with `--vision`.

When `--model-id` is omitted, the server advertises and accepts the artifact's `metadata.name`, falling back to its architecture name when no name is stored. An explicit `--model-id` is a public HTTP alias override and does not select or alter model execution.

Vision is disabled by default: its weights and Vision-specific unified-workspace extent are not allocated, and media requests and token-count requests fail with HTTP 400 `vision_disabled`. Add `--vision` when the server must accept image or video input. Speculative residency is likewise frozen by `--spec mtp|dflash|dflash2` and `--draft-tokens`; omitting `--spec` loads no speculative backend, except for a Flash-Next artifact with its MTP block and host experts, or a Gemma 4 artifact with its assistant and host or disk experts, which drafts three tokens a round (`--spec none` turns that off). A selected backend also loads the artifact's optimized proposal head when it stores one (`--full-draft-head` keeps the full output head instead). DFlash on 35B-A3B and DFlash2 on Qwen3.8-27B can be combined with `--vision`; each accelerates generated-text decode after multimodal prefill, while Vision encode and prefill remain outside speculative acceleration. A later request cannot enable a capability omitted at startup. The artifact need only contain the Text backbone and the optional components selected for this process.

### Adaptive MTP

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#adaptive-mtp)

With `--adaptive-mtp`, `--draft-tokens K` is the most drafts an MTP round verifies; every round still proposes `K` for the next one. Each request tracks how far its drafts survive, position by position, with a fast and a slow moving average; the Engine prices each verification width from the round times it has measured at that width and batch size (a width not yet run is priced from a relative cost shape scaled by the widths that have) and picks the width with the most expected committed tokens per second over this round and the next. A width changes only after it has won several rounds, and a width is probed upward when every row's drafts have kept surviving. While three drafts are ready the width stays at three or more, so the Engine captures CUDA Graphs for widths `min(3, K)..K`: the graph memory, and the startup capture time, grow with the number of widths. Committed tokens are still the target's greedy choices, but attention splits its reduction by the verify width, so a near-tie can resolve differently at another width, as it does between two fixed `--draft-tokens` settings (`--invariant-attention` removes attention's part of that difference; the other Ops keep theirs). The per-request log reports the rounds run at each width and the width changes.

With `--spec dflash`, `dflash2` or `dspine` on a Qwen3.5-core model, `--adaptive-mtp` lets each round without a copy draft and verify either `--draft-tokens K` drafts or K/2 (rounded down; with K = 1 it changes nothing). A masked drafter makes a round's drafts in one pass at the round's width, so the narrow round also drafts less. Each request keeps three moving averages over about ten rounds: the tokens a narrow round commits, how often all K/2 of its drafts survive, and how many more a wide round keeps after such a prefix. The wide round's expected tokens are the first plus the product of the other two, which narrow rounds keep current: a DSpine block is causal, so its narrow drafts are the wide round's first K/2 (a DFlash or DFlash2 block attends both ways, so there the sum is an approximation). Round times grow as contexts lengthen, so the width that is not running is priced from the running width's current time and the ratio of the two measured close together; each batch size measures that ratio over four rounds of the other width, and again over two every 96 rounds. A width changes after it has led by 2% for four rounds in a row, and a new request starts from the pooled averages of the requests before it. The Engine captures CUDA Graphs for both widths, and the KV sizing reserves graph memory for both: on an RTX 5090 with eight requests and an 8,192-token window, DSpine's graphs measured 264 MiB against 186 MiB with one width, but the reservation doubled to 4.5 GiB and the KV pool fell from 52,544 tokens to 15,680; `--cuda-graph-allowance-mib 2304` keeps the one-width pool. On that card with Qwen3.8-27B (`ninfer-serve`, `bf16` KV, no copy rounds), in decode tok/s:

| Workload | Drafter | 7 drafts | 15 drafts | `--adaptive-mtp`, 15 |
| --- | --- | --- | --- | --- |
| Python module, one request | DSpine | 341.7 | 486.8 | 354.8 |
| Python module, one request | DFlash2 | 311.6 | 411.0 | 414.6 |
| English prose, one request | DSpine | 182.2 | 160.3 | 182.3 |
| English prose, one request | DFlash2 | 192.9 | 167.8 | 195.4 |
| Model card set, one request at a time | DSpine | not run | 315.8 | 312.8 |
| Model card set, eight requests | DSpine | 604.9 | 480.1 | 561.0 |
| Model card set, eight requests | DFlash2 | 629.1 | 520.1 | 601.1 |

The two long requests decode 1,024 tokens with thinking off. The model card set is two prompts a dataset from GSM8K, MATH-500, HumanEval, MBPP and MT-Bench at reasoning effort `xhigh` and up to 2,048 tokens, one request at a time (mean per-request decode tok/s), or eight a dataset at eight requests (aggregate tok/s, every run with a 52,544-token KV pool: the adaptive runs pass `--cuda-graph-allowance-mib 2304`). Each cell is one run; a repeated fixed run measured 594.5 for DSpine's 7 drafts and 486.6 for its 15. With eight requests the adaptive width is 15-17% faster than 15 drafts and 4-7% slower than 7. With one request it is between 1.0% slower and 1.3% faster than the faster fixed width, except on DSpine's Python answer. DSpine's Python answer under `--adaptive-mtp` is another text: its rounds were 151 of 171 wide, but a wide round kept 5.1 drafts on average against 7.4 in the fixed answer. Greedy answers change with the width, so a single long request can land on text the drafter predicts better or worse. On the card set one request at a time, a wide round kept 4.9 drafts against 4.4 at a fixed 15, and wide rounds right after narrow ones kept 5.7, so the narrow rounds leave the drafter's context intact.

````

</details>

<details><summary>Tool result · web_scrape · call_fa1b17318bf342fcb5277d05</summary>

**Firecrawl · section 1 of 9**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,607 characters · included below
- Section 2 · 11,767 characters · omitted from this copy
- Section 3 · 11,432 characters · omitted from this copy
- Section 4 · 11,927 characters · omitted from this copy
- Section 5 · 11,973 characters · omitted from this copy
- Section 6 · 11,995 characters · omitted from this copy
- Section 7 · 11,806 characters · omitted from this copy
- Section 8 · 11,697 characters · omitted from this copy
- Section 9 · 3,043 characters · omitted from this copy

````text
[Skip to content](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md)
 to refresh your session. Dismiss alert



[](https://github.com/CommanderTurtle/decisive-ninfer)

FilesExpand file tree


-----------------------

feature/parallel-decision

/

serving.md
==========

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/CommanderTurtle/decisive-ninfer/commits/feature/parallel-decision/docs/serving.md)

[](https://github.com/CommanderTurtle/decisive-ninfer/commits/feature/parallel-decision/docs/serving.md)
History

1373 lines (1144 loc) · 87 KB

feature/parallel-decision

/

serving.md
==========

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


1373 lines (1144 loc) · 87 KB

[Raw](https://github.com/CommanderTurtle/decisive-ninfer/raw/refs/heads/feature/parallel-decision/docs/serving.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

HTTP serving
============

[](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md#http-serving)

`ninfer-serve` exposes OpenAI- and Anthropic-compatible HTTP endpoints over one NInfer Engine. The Engine can execute locally or across a configured pair of Sparks; clients use the same HTTP endpoint and request formats. Supported models and deployments are listed in the [README](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/README.md#supported-models-and-deployments)
.

Start the server
----------------

[](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md#start-the-server)

Choose a [deployment configuration](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/examples/configs)
, edit its paths and network settings, and launch it on the coordinator:

```shell
./build/rtx5090-release/apps/ninfer-serve --config ninfer.local.toml
```

Use `build/dgx-spark-release/apps/ninfer-serve` on Spark. Dual-node deployments automatically start local and remote workers; see [distributed launch](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/startup-configuration.md#distributed-deployment)
. A minimal command without a file is:

```shell
./build/rtx5090-release/apps/ninfer-serve models/qwen3_8_27b_nvfp4.ninfer \
  --host 127.0.0.1 --port 8080 --max-context 8192 --kv-dtype fp8
```

`max_context` limits each request. The separate Context byte pool is shared by KV and continuation state, with capacity reported at startup. See [resource controls](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/startup-configuration.md#context-and-memory)
.

The public model ID defaults to the artifact's `metadata.name`, falling back to its architecture name. `--model-id` overrides that HTTP alias without changing model execution. Use the advertised ID in requests; `GET /v1/models` returns it.

Enable `--vision` at startup for image/video requests. Without it, media generation and media counting requests return HTTP 400 `vision_disabled`. Select a speculative backend with `--spec mtp|dflash|dflash2` and `--draft-tokens`; `--proposal-head optimized` loads the additional head when available. Components omitted at startup cannot be enabled by a later HTTP request. The [CLI guide](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/cli.md#speculative-decoding)
 describes backend and head differences across models.

Qwen and GLM use the same protocol surfaces with their own templates and output decoders. In particular, GLM supports `low/high/max` reasoning effort and requires thinking to remain enabled. See [thinking options](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/cli.md#thinking-and-sampling)
 before copying model-specific request settings.

Endpoints
---------

[](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md#endpoints)

| Method and path | Behavior |
| --- | --- |
| `POST /v1/decision` (`/decision`) | finite-schema decisions; registered only with `--jev` |
| `POST /v1/systemone` | TypeSafe-shaped questions over the same decision engine; requires `--jev` |
| `GET /health` | Engine readiness |
| `GET /metrics` | Prometheus counters, gauges and latency histograms |
| `GET /monitor/info` | Instance identity, effective configuration, topology and startup resources |
| `GET /monitor/snapshot` | Published Engine/Service counters, resources and current request observations |
| `GET /monitor/events` | Live monitoring events over SSE |
| `GET /v1/models` | configured OpenAI model alias and effective `max_model_len` |
| `GET /v1/models/{id}` | lookup of the configured alias and effective `max_model_len` |
| `POST /v1/chat/completions` | OpenAI-style chat generation |
| `POST /v1/responses` | OpenAI Responses Core generation, state, typed Items, and SSE |
| `POST /v1/responses/input_tokens` | Responses prompt-token count without generation |
| `GET /v1/responses/{id}` | retrieve a locally stored terminal Response |
| `DELETE /v1/responses/{id}` | delete a locally stored Response |
| `GET /v1/responses/{id}/input_items` | list that Response's normalized input Items |
| `POST /v1/messages` | Anthropic-style message generation |
| `POST /v1/messages/count_tokens` | checkpoint-native expanded input-token count |

`GET /health` returns HTTP 200 with `{"status":"ok"}` while the Engine can accept work. After an Engine-wide failure it returns HTTP 503 with `{"status":"unavailable"}`. Temporary queue saturation does not make the Engine unavailable. The endpoint remains unauthenticated.

Every OpenAI-compatible response carries a unique `x-request-id` header, including streaming and error responses. Anthropic endpoints use their separate `request-id` contract.

All three generation SSE endpoints emit the standard `: keep-alive` comment after five seconds without a protocol event. The comment is transport-only: SSE clients ignore it, and it does not change generated text, event ordering, usage, stored Responses, or request logs. On Linux, accepted connections also use TCP keepalive and a 15-second `TCP_USER_TIMEOUT`; together with the heartbeat, a dead or unacknowledging peer is normally cancelled within about 20 seconds, including while the request is waiting or prefilling. A peer whose TCP stack remains connected and acknowledges data cannot be distinguished from a reading application; proxies must close their upstream NInfer connection when the downstream client disappears.

Parallel decisions: Jev
-----------------------

[](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md#parallel-decisions-jev)

The decision backend supports Qwen3.5 Dense/MoE architectures, including Qwen3.8-27B. Qwen4Exp inference currently runs without `--jev`.

Add `--jev` to the existing serving command to register `/v1/decision`, `/decision` and `/v1/systemone`. The normal build/Docker image contains these routes; no separate service or model is needed. Without the flag the routes are absent. Authentication, CORS, request IDs, payload bounds and disconnect handling follow the existing server. Responses use `Cache-Control: no-store`. These endpoints accept text, not images. Decision StateImages and KV pages use the shared `--context-capacity` allocator on demand. Branch scratch and private execution tables fit inside the existing workspace; `--jev` leaves the native Device reservation unchanged.

```shell
curl http://127.0.0.1:8080/v1/decision \
  -H 'Content-Type: application/json' --data-binary @examples/decision/support.json
```

### Request and response

[](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md#request-and-response)

| Member | Contract |
| --- | --- |
| `model` | Optional resident model alias |
| `instructions` | Optional text policy; at most 1 MiB |
| `contexts` | 1–256 strings, at most 1 MiB combined; results preserve order |
| `schema` | 1–32 independent fields, compact or JSON Schema `properties` |
| `mode` | `auto` (default), `tree`, or `greedy` |
| `tree_max` | Auto-mode exhaustive-domain threshold, 1–255; default 128 |
| `cache_prompt` | Reuse a retained exact root; false rebuilds it once, preserving within-request sharing; default true |

Compact fields require a description; JSON Schema descriptions are optional. All declared fields are returned regardless of `required`. Field names and choice labels are limited to 4096 bytes; the compiled catalogue is limited to 1 MiB.

| Field | Finite domain |
| --- | --- |
| `boolean` | true / false |
| `enum` (`choice`, `selection`) | `choices` or `enum`, 1–255 distinct strings; JSON Schema string enums also work |
| `integer` | Inclusive signed-64-bit minimum/maximum, at most 255 values |
| `number` | Inclusive minimum/maximum and positive step, both endpoints on the grid, at most 255 values and nine decimal places; integer inputs must convert to double without loss |

JSON Schema `multipleOf` additionally requires a zero-aligned grid. Numeric fields accept `aggregate` (or `x-aggregate`): mode, median or mean. Mean is projected to the nearest allowed value, ties to the earlier/lower value. Mean/median require exhaustive tree mode; explicit greedy aggregation is rejected. Unsupported keywords, conflicting aliases, nested domains, arbitrary strings and integer strides are rejected rather than approximated.

Responses contain `object: "decision"`, `results[]`, `usage` and `timings`. Each result contains the typed `decision`, per-field `value/probability/scored_nodes/tree`, and usage. Tree-scored numeric fields also include `interval_p10_p90`.

The artifact template/tokenizer encodes complete field/value continuations. Tree scoring normalizes logits over allowed next tokens and multiplies path probabilities; greedy mode follows the best edge and need not find the highest-probability leaf. Singleton fields need no scoring. Fields cannot see sibling answers. Probabilities are conditional on the supplied options, not calibrated truth estimates. Applications own thresholds and follow-up actions.

### Execution and accounting

[](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md#execution-and-accounting)

Decisions use the resident target head, not MTP/DFlash proposal heads. Startup reservation, chat lanes, automatic KV sizing and graph budgets are unchanged. Temporary execution buffers overlay existing general workspace; free native state slots and shared KV pages bound batch capacity. Occupied chat/checkpoint state is not evicted. Up to eight contexts and finite-trie divergences are compiled together; actual row batches may be smaller. This is bounded shared-prefix execution, not one kernel for an arbitrary request.

````

</details>

## Assistant · #36

<details><summary>Reasoning · 3,464 characters</summary>

Important: decisive-ninfer branch says Qwen4Exp inference currently runs without --jev. ninfer-all master docs says typed decisions every model family? Let's search ninfer-all serving decisions. Need resource_search maybe in f62... for "decisions". Use resource_search? It only can search a501... due list? It says available resource ids maybe only some. Could read specific sections? Serving docs section maybe decisions. Could web_scrape raw and search? Raw page likely Chinese? Maybe blob page sections. We can use resource_search for a501 only. But can scrape raw serving.md maybe huge; tool returns indexed? Could search by scraping raw? Hmm.

Need maybe compare decision framework: ninfer-all latest has `/v1/decisions` and `/v1/systemone`; branch decisive-ninfer uses `/v1/decision`, `/decision`, `/v1/systemone`, requires `--jev`; supports Qwen3.5 dense/MoE, not Qwen4Exp. ninfer-all says every model family supports typed decisions, including Flash-Next? README says "The same chat model answers typed decisions ... through TypeSafe's System One and OpenAI's Decisions APIs." It might have ported and generalized. Let's search ninfer-all docs/serving section decisions. Use context_read on f62... resource? Search tool only for long resource already opened? It says resource_search for long result already opened with context_read; available resource ids include f62da7ac? yes listed? Function schema allowed resource id enum only a501cadf? Wait tool definition says resource_search required resource_id enum only a501cadf. So only ninfer-all README can search. For serving docs, maybe read section containing decisions. The section list didn't show decisions explicitly. Could web_scrape raw and maybe the whole raw returned? It didn't index raw? Let's try web_scrape raw serving.md, maybe returns indexed sections. But no need maybe.

Need possibly inspect ninfer-all commit 8706bfc0 (gguf formats) and 5395ec30b Flash Next. User says "less than month of model innovation, mid-Nov 2026" maybe wants timeline. Could inspect commit messages? We can scrape GitHub commits. Need maybe "how far off are ports" maybe date-sensitive: ninfer-all latest Nov 16 2026; basalt 0.2.0? Shockem basalt migrated v1 to v2; model pack current. Need compare upstream basalt release version maybe 0.2.0 and ninfer-all master Nov 16. Need check basalt latest version/changelog. Scrape releases? Also Strata? Since basalt fork of strata; ninfer-all also merged strata? Need maybe compare Strata vs basalt/ninfer? Need inspect Strata repo? Could be upstream model types? Search Strata. User says "basalt is a fork of strata" and ninfer-all "formerly also merged strata". Need review upstream basalt and formerly ninfer-all. Could inspect basalt changelog, Strata docs. Maybe .basalt vs .strata checkpoint? Wait Basalt is a fork of Strata; .basalt artifacts are forked format. NInfer-all merged Strata, but artifacts are .ninfer. Are they unified along Flash Next model type? Need determine if "front" means architecture `qwen4exp`, not container. Could answer: architecture semantic front is largely unified (same Qwen4Exp/Flash Next model type, 125B, 48 layers, 36 GDN + 12 QSA, 512 experts top-10, PLE/ngram), but the serialization/runtime contracts diverged significantly. They share source GGUF block semantics and model graph, but not the file format or some tensor representations.

Need inspect Strata maybe to understand basalt fork? Let's scrape Strata README maybe.


</details>

<details><summary>Tool request · web_scrape · call_df243a96d2c74ebeb0bb2976</summary>

```json
{
  "url": "https://github.com/Niko1221/Strata"
}
```

</details>

<details><summary>Tool request · web_scrape · call_8fc4e563ae7d4738b844dbb2</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/releases"
}
```

</details>

<details><summary>Tool request · web_scrape · call_81b8ccca5ab147edb84b1ef5</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/commits/master/docs/qwen3-8-flash-next.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_aec2f87a8fa0434e98fb3809</summary>

```json
{
  "url": "https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3"
}
```

</details>


<details><summary>Tool result · web_scrape · call_df243a96d2c74ebeb0bb2976</summary>

**Firecrawl · section 1 of 3**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,932 characters · included below
- Section 2 · 11,992 characters · omitted from this copy
- Section 3 · 391 characters · omitted from this copy

```text
[Skip to content](https://github.com/Niko1221/Strata#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/Niko1221/Strata)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/Niko1221/Strata)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/Niko1221/Strata)
 to refresh your session. Dismiss alert

            [](https://github.com/Niko1221/Strata)

main

[Branches](https://github.com/Niko1221/Strata/branches)
[Tags](https://github.com/Niko1221/Strata/tags)

[](https://github.com/Niko1221/Strata/branches)
[](https://github.com/Niko1221/Strata/tags)

Go to file

Code

Open more actions menu

Latest commit
-------------

History
-------

[7,106 Commits](https://github.com/Niko1221/Strata/commits/main/)

[](https://github.com/Niko1221/Strata/commits/main/)
7,106 Commits

Folders and files
-----------------

| Name |     | Name | Last commit message | Last commit date |
| --- | --- | --- | --- |
| [.github](https://github.com/Niko1221/Strata/tree/main/.github ".github") |     | [.github](https://github.com/Niko1221/Strata/tree/main/.github ".github") |     |     |
| [apps](https://github.com/Niko1221/Strata/tree/main/apps "apps") |     | [apps](https://github.com/Niko1221/Strata/tree/main/apps "apps") |     |     |
| [bench](https://github.com/Niko1221/Strata/tree/main/bench "bench") |     | [bench](https://github.com/Niko1221/Strata/tree/main/bench "bench") |     |     |
| [bin](https://github.com/Niko1221/Strata/tree/main/bin "bin") |     | [bin](https://github.com/Niko1221/Strata/tree/main/bin "bin") |     |     |
| [cmake](https://github.com/Niko1221/Strata/tree/main/cmake "cmake") |     | [cmake](https://github.com/Niko1221/Strata/tree/main/cmake "cmake") |     |     |
| [data](https://github.com/Niko1221/Strata/tree/main/data "data") |     | [data](https://github.com/Niko1221/Strata/tree/main/data "data") |     |     |
| [docker](https://github.com/Niko1221/Strata/tree/main/docker "docker") |     | [docker](https://github.com/Niko1221/Strata/tree/main/docker "docker") |     |     |
| [docs](https://github.com/Niko1221/Strata/tree/main/docs "docs") |     | [docs](https://github.com/Niko1221/Strata/tree/main/docs "docs") |     |     |
| [history](https://github.com/Niko1221/Strata/tree/main/history "history") |     | [history](https://github.com/Niko1221/Strata/tree/main/history "history") |     |     |
| [include/strata](https://github.com/Niko1221/Strata/tree/main/include/strata "This path skips through empty directories") |     | [include/strata](https://github.com/Niko1221/Strata/tree/main/include/strata "This path skips through empty directories") |     |     |
| [integrations/harness](https://github.com/Niko1221/Strata/tree/main/integrations/harness "This path skips through empty directories") |     | [integrations/harness](https://github.com/Niko1221/Strata/tree/main/integrations/harness "This path skips through empty directories") |     |     |
| [metal](https://github.com/Niko1221/Strata/tree/main/metal "metal") |     | [metal](https://github.com/Niko1221/Strata/tree/main/metal "metal") |     |     |
| [packaging](https://github.com/Niko1221/Strata/tree/main/packaging "packaging") |     | [packaging](https://github.com/Niko1221/Strata/tree/main/packaging "packaging") |     |     |
| [ref](https://github.com/Niko1221/Strata/tree/main/ref "ref") |     | [ref](https://github.com/Niko1221/Strata/tree/main/ref "ref") |     |     |
| [research](https://github.com/Niko1221/Strata/tree/main/research "research") |     | [research](https://github.com/Niko1221/Strata/tree/main/research "research") |     |     |
| [serve](https://github.com/Niko1221/Strata/tree/main/serve "serve") |     | [serve](https://github.com/Niko1221/Strata/tree/main/serve "serve") |     |     |
| [spark](https://github.com/Niko1221/Strata/tree/main/spark "spark") |     | [spark](https://github.com/Niko1221/Strata/tree/main/spark "spark") |     |     |
| [src](https://github.com/Niko1221/Strata/tree/main/src "src") |     | [src](https://github.com/Niko1221/Strata/tree/main/src "src") |     |     |
| [strata\_cli](https://github.com/Niko1221/Strata/tree/main/strata_cli "strata_cli") |     | [strata\_cli](https://github.com/Niko1221/Strata/tree/main/strata_cli "strata_cli") |     |     |
| [strata\_control](https://github.com/Niko1221/Strata/tree/main/strata_control "strata_control") |     | [strata\_control](https://github.com/Niko1221/Strata/tree/main/strata_control "strata_control") |     |     |
| [sycl](https://github.com/Niko1221/Strata/tree/main/sycl "sycl") |     | [sycl](https://github.com/Niko1221/Strata/tree/main/sycl "sycl") |     |     |
| [tests](https://github.com/Niko1221/Strata/tree/main/tests "tests") |     | [tests](https://github.com/Niko1221/Strata/tree/main/tests "tests") |     |     |
| [third\_party](https://github.com/Niko1221/Strata/tree/main/third_party "third_party") |     | [third\_party](https://github.com/Niko1221/Strata/tree/main/third_party "third_party") |     |     |
| [tools](https://github.com/Niko1221/Strata/tree/main/tools "tools") |     | [tools](https://github.com/Niko1221/Strata/tree/main/tools "tools") |     |     |
| [.dockerignore](https://github.com/Niko1221/Strata/blob/main/.dockerignore ".dockerignore") |     | [.dockerignore](https://github.com/Niko1221/Strata/blob/main/.dockerignore ".dockerignore") |     |     |
| [.gitattributes](https://github.com/Niko1221/Strata/blob/main/.gitattributes ".gitattributes") |     | [.gitattributes](https://github.com/Niko1221/Strata/blob/main/.gitattributes ".gitattributes") |     |     |
| [.gitignore](https://github.com/Niko1221/Strata/blob/main/.gitignore ".gitignore") |     | [.gitignore](https://github.com/Niko1221/Strata/blob/main/.gitignore ".gitignore") |     |     |
| [AGENTS.md](https://github.com/Niko1221/Strata/blob/main/AGENTS.md "AGENTS.md") |     | [AGENTS.md](https://github.com/Niko1221/Strata/blob/main/AGENTS.md "AGENTS.md") |     |     |
| [BENCH.bat](https://github.com/Niko1221/Strata/blob/main/BENCH.bat "BENCH.bat") |     | [BENCH.bat](https://github.com/Niko1221/Strata/blob/main/BENCH.bat "BENCH.bat") |     |     |
| [CMakeLists.txt](https://github.com/Niko1221/Strata/blob/main/CMakeLists.txt "CMakeLists.txt") |     | [CMakeLists.txt](https://github.com/Niko1221/Strata/blob/main/CMakeLists.txt "CMakeLists.txt") |     |     |
| [CMakePresets.json](https://github.com/Niko1221/Strata/blob/main/CMakePresets.json "CMakePresets.json") |     | [CMakePresets.json](https://github.com/Niko1221/Strata/blob/main/CMakePresets.json "CMakePresets.json") |     |     |
| [CONTRIBUTING.md](https://github.com/Niko1221/Strata/blob/main/CONTRIBUTING.md "CONTRIBUTING.md") |     | [CONTRIBUTING.md](https://github.com/Niko1221/Strata/blob/main/CONTRIBUTING.md "CONTRIBUTING.md") |     |     |
| [Dockerfile](https://github.com/Niko1221/Strata/blob/main/Dockerfile "Dockerfile") |     | [Dockerfile](https://github.com/Niko1221/Strata/blob/main/Dockerfile "Dockerfile") |     |     |
| [LICENSE](https://github.com/Niko1221/Strata/blob/main/LICENSE "LICENSE") |     | [LICENSE](https://github.com/Niko1221/Strata/blob/main/LICENSE "LICENSE") |     |     |
| [README.de.md](https://github.com/Niko1221/Strata/blob/main/README.de.md "README.de.md") |     | [README.de.md](https://github.com/Niko1221/Strata/blob/main/README.de.md "README.de.md") |     |     |
| [README.es.md](https://github.com/Niko1221/Strata/blob/main/README.es.md "README.es.md") |     | [README.es.md](https://github.com/Niko1221/Strata/blob/main/README.es.md "README.es.md") |     |     |
| [README.fr.md](https://github.com/Niko1221/Strata/blob/main/README.fr.md "README.fr.md") |     | [README.fr.md](https://github.com/Niko1221/Strata/blob/main/README.fr.md "README.fr.md") |     |     |
| [README.ja.md](https://github.com/Niko1221/Strata/blob/main/README.ja.md "README.ja.md") |     | [README.ja.md](https://github.com/Niko1221/Strata/blob/main/README.ja.md "README.ja.md") |     |     |
| [README.md](https://github.com/Niko1221/Strata/blob/main/README.md "README.md") |     | [README.md](https://github.com/Niko1221/Strata/blob/main/README.md "README.md") |     |     |
| [README.pl.md](https://github.com/Niko1221/Strata/blob/main/README.pl.md "README.pl.md") |     | [README.pl.md](https://github.com/Niko1221/Strata/blob/main/README.pl.md "README.pl.md") |     |     |
| [README.pt-BR.md](https://github.com/Niko1221/Strata/blob/main/README.pt-BR.md "README.pt-BR.md") |     | [README.pt-BR.md](https://github.com/Niko1221/Strata/blob/main/README.pt-BR.md "README.pt-BR.md") |     |     |
| [README.zh-CN.md](https://github.com/Niko1221/Strata/blob/main/README.zh-CN.md "README.zh-CN.md") |     | [README.zh-CN.md](https://github.com/Niko1221/Strata/blob/main/README.zh-CN.md "README.zh-CN.md") |     |     |
| [SECURITY.md](https://github.com/Niko1221/Strata/blob/main/SECURITY.md "SECURITY.md") |     | [SECURITY.md](https://github.com/Niko1221/Strata/blob/main/SECURITY.md "SECURITY.md") |     |     |
| [SETUP.bat](https://github.com/Niko1221/Strata/blob/main/SETUP.bat "SETUP.bat") |     | [SETUP.bat](https://github.com/Niko1221/Strata/blob/main/SETUP.bat "SETUP.bat") |     |     |
| [START-HERE.bat](https://github.com/Niko1221/Strata/blob/main/START-HERE.bat "START-HERE.bat") |     | [START-HERE.bat](https://github.com/Niko1221/Strata/blob/main/START-HERE.bat "START-HERE.bat") |     |     |
| [UPDATE.bat](https://github.com/Niko1221/Strata/blob/main/UPDATE.bat "UPDATE.bat") |     | [UPDATE.bat](https://github.com/Niko1221/Strata/blob/main/UPDATE.bat "UPDATE.bat") |     |     |
| [bench.sh](https://github.com/Niko1221/Strata/blob/main/bench.sh "bench.sh") |     | [bench.sh](https://github.com/Niko1221/Strata/blob/main/bench.sh "bench.sh") |     |     |
| [conftest.py](https://github.com/Niko1221/Strata/blob/main/conftest.py "conftest.py") |     | [conftest.py](https://github.com/Niko1221/Strata/blob/main/conftest.py "conftest.py") |     |     |
| [flake.lock](https://github.com/Niko1221/Strata/blob/main/flake.lock "flake.lock") |     | [flake.lock](https://github.com/Niko1221/Strata/blob/main/flake.lock "flake.lock") |     |     |
| [flake.nix](https://github.com/Niko1221/Strata/blob/main/flake.nix "flake.nix") |     | [flake.nix](https://github.com/Niko1221/Strata/blob/main/flake.nix "flake.nix") |     |     |
| [requirements-build.txt](https://github.com/Niko1221/Strata/blob/main/requirements-build.txt "requirements-build.txt") |     | [requirements-build.txt](https://github.com/Niko1221/Strata/blob/main/requirements-build.txt "requirements-build.txt") |     |     |
| [requirements-dev.txt](https://github.com/Niko1221/Strata/blob/main/requirements-dev.txt "requirements-dev.txt") |     | [requirements-dev.txt](https://github.com/Niko1221/Strata/blob/main/requirements-dev.txt "requirements-dev.txt") |     |     |
| [requirements-monitor.txt](https://github.com/Niko1221/Strata/blob/main/requirements-monitor.txt "requirements-monitor.txt") |     | [requirements-monitor.txt](https://github.com/Niko1221/Strata/blob/main/requirements-monitor.txt "requirements-monitor.txt") |     |     |
| [requirements-nvfp4-local.txt](https://github.com/Niko1221/Strata/blob/main/requirements-nvfp4-local.txt "requirements-nvfp4-local.txt") |     | [requirements-nvfp4-local.txt](https://github.com/Niko1221/Strata/blob/main/requirements-nvfp4-local.txt "requirements-nvfp4-local.txt") |     |     |
| [requirements.txt](https://github.com/Niko1221/Strata/blob/main/requirements.txt "requirements.txt") |     | [requirements.txt](https://github.com/Niko1221/Strata/blob/main/requirements.txt "requirements.txt") |     |     |
| [setup.py](https://github.com/Niko1221/Strata/blob/main/setup.py "setup.py") |     | [setup.py](https://github.com/Niko1221/Strata/blob/main/setup.py "setup.py") |     |     |
```

</details>

<details><summary>Tool result · web_scrape · call_8fc4e563ae7d4738b844dbb2</summary>

**Firecrawl · section 1 of 9**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,897 characters · included below
- Section 2 · 11,704 characters · omitted from this copy
- Section 3 · 11,944 characters · omitted from this copy
- Section 4 · 11,998 characters · omitted from this copy
- Section 5 · 11,847 characters · omitted from this copy
- Section 6 · 11,977 characters · omitted from this copy
- Section 7 · 11,989 characters · omitted from this copy
- Section 8 · 11,971 characters · omitted from this copy
- Section 9 · 11,236 characters · omitted from this copy

```text
[Skip to content](https://github.com/jesdga95/basalt/releases#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/releases)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/releases)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/releases)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

Releases · jesdga95/basalt

Basalt 0.4.1
------------

[Basalt 0.4.1](https://github.com/jesdga95/basalt/releases/tag/v0.4.1)
 [Latest](https://github.com/jesdga95/basalt/releases/latest)

[Latest](https://github.com/jesdga95/basalt/releases/latest)

Compare

Choose a tag to compare
=======================

Sorry, something went wrong.
----------------------------

Filter

Loading

Sorry, something went wrong.
----------------------------

### Uh oh!

There was an error while loading. [Please reload this page](https://github.com/jesdga95/basalt/releases)
.

No results found
----------------

[View all tags](https://github.com/jesdga95/basalt/tags)

![@jesdga95](https://avatars.githubusercontent.com/u/778141?s=40&v=4) [jesdga95](https://github.com/jesdga95)
 released this 16 Nov 16:09

[v0.4.1](https://github.com/jesdga95/basalt/tree/v0.4.1)

[`d3b7574`](https://github.com/jesdga95/basalt/commit/d3b75742967c7f9fd892c6894a2b9ac6e36e0cf3)

2026-11-16. Taken from `main`. Build from source: [building](https://github.com/jesdga95/basalt/blob/v0.4.1/docs/building.md)
, or take a release archive ([platforms](https://github.com/jesdga95/basalt/blob/v0.4.1/docs/platforms.md#release-archives)
). The 27B gets a second card and a context past 262,144; Flash-Next's RAM plan leaves room for what the engine takes after it again. The `.basalt` format stays version 2 and the config stays version 2.

Highlights
----------

*   **Qwen3.8-27B on two cards.** A second Blackwell card reads the last layers of long prompts while the main card reads the next chunk (the `prompt line`): with an RTX 5060 Ti beside an RTX 5090, prompt reads +13% at 8k, +19% at 16k, +22% at 32k and +23% at 64k tokens. A 27B that does not fit its main card splits its layers across both (the `layer stage`), with output bitwise the main card's alone. [two cards](https://github.com/jesdga95/basalt/blob/v0.4.1/docs/models/qwen38-27b.md#two-cards-when-it-does-not-fit-one)

*   **The 27B past 262,144 tokens** with YaRN (`--rope-scaling yarn --rope-scale F`), and **`--kv-resident N`**, which keeps each attention layer's first N positions on the card and streams the rest from page-locked RAM, so a context or `--parallel` whose cache does not fit the card still starts. [memory](https://github.com/jesdga95/basalt/blob/v0.4.1/docs/models/qwen38-27b.md#memory)

*   **Flash-Next on 64 GB of RAM.** Since 0.3.1 the RAM plan left exactly `--ram-reserve-mib` free, and the memory the engine takes after the plan (graph capture, page-locked buffers, the first request) came out of it: a start on a 64 GB box could end at the RAM guard or be stopped by the load watchdog. The plan now leaves 2 GiB beside the reserve, as 0.2.1 did ([#339](https://github.com/jesdga95/basalt/issues/339)
    ).
*   **DeepSeek expert tiers on up to four second cards**, each holding the experts of its own block of layers ([#367](https://github.com/jesdga95/basalt/pull/367)
    , [@stevenm76](https://github.com/stevenm76)
    ).

Qwen3.8-27B
-----------

*   **Prompt line.** When the model, the context and the slots fit the main card, a second card reads the last layers of each long prompt chunk, its hand-off through page-locked RAM. Decoding stays on the main card. Off with `--kv-resident` below the context, and for contexts of 16,384 or less. The start line names it: `prompt line: layers 44-63 …`.
*   **Layer split.** When they do not fit, the start plans a cut from the pack's bytes per layer and both cards' free memory: the main card keeps layers 0 to N-1 with the head, the drafter and the image encoder, the second card the rest with its own KV cache and recurrent state per slot. Each card runs its layers of a window as its own CUDA graph. About 0.37 ms per window per layer on an RTX 5060 Ti. Two cards only; later cards stay idle.
*   **YaRN** reads the same flags as Flash-Next (`--rope-scaling`, `--rope-scale`, `--yarn-*`), now shared code. It changes short prompts' output too, so leave it off below 262,144. [precision](https://github.com/jesdga95/basalt/blob/v0.4.1/docs/precision/qwen38-27b.md#context-past-262144)

*   **`--kv-resident N`** (default 0): decode reads every position past N over the bus, so it slows with each position in RAM; prompt reads stay close; output is bitwise the same.
*   **Idle sleep** works for the 27B: a dense model has no expert cache to give back, so SLEEP now succeeds and the driver suspend runs (one card 1.7 s back, the layer split 3.6 s). Before, the server logged that the model stays awake.

Serve
-----

*   **`--parallel` hands the prompt to the engine as text**, as a single slot already did: the engine tokenizes it once and returns each slot's match, and one C++ matcher serves both modes. An over-context prompt is refused with a 400 before the stream starts, from the engine's count.
*   **A reply sent back in other pieces keeps the slot.** The model can write a text in pieces the tokenizer would cut differently; a client that sends the reply back unchanged got other ids for it, the prompt stopped matching inside the reply, and the turn was read again from a checkpoint (with `--parallel`, in another slot, leaving a dead copy in the old one: 6–8 GiB each at 550K tokens). Where the held ids spell the same bytes as the prompt, the engine now keeps them ([#378](https://github.com/jesdga95/basalt/issues/378)
    , [@hiraghi](https://github.com/hiraghi)
    ).
*   **`/slots` rows are the engine's slots:** row N is engine slot N, a running request shows on the slot it runs in, and an idle row shows what its slot holds ([#379](https://github.com/jesdga95/basalt/issues/379)
    , [@hiraghi](https://github.com/hiraghi)
    ).
*   **`POST /tokenize` and `/detokenize`**, as llama.cpp's server has them ([#363](https://github.com/jesdga95/basalt/pull/363)
    , [@mitalbert](https://github.com/mitalbert)
    ).
*   **`--reasoning-effort`** (or `"reasoning-effort"` in a model entry) sets the effort for requests that name none ([#364](https://github.com/jesdga95/basalt/pull/364)
    , [@mitalbert](https://github.com/mitalbert)
    ).
*   Responses API usage carries the engine's prompt count ([#381](https://github.com/jesdga95/basalt/pull/381)
    , [@JimJafar](https://github.com/JimJafar)
    ). `/v1/models` entries carry `created` and `owned_by`.

Fixes and platforms
-------------------

*   A `--resident-budget-gib` between the experts and the experts plus the adaptive swaps' free places keeps those places, as in 0.3.3; since 0.4.0 decode on a 16 GB card halved there ([#366](https://github.com/jesdga95/basalt/issues/366)
    , [#369](https://github.com/jesdga95/basalt/pull/369)
    , [@giveen](https://github.com/giveen)
    ).
*   In a container, the RAM readings follow the cgroup's limit, and the cgroup's shared memory (page-locked buffers among it) no longer counts as reclaimable cache: a 46 GiB container that was OOM-killed after the load now loads ([#339](https://github.com/jesdga95/basalt/issues/339)
     in containers).
*   A `-march=native` build on an AVX-512 CPU no longer emits AVX10.2 encodings in the AVX-VNNI-INT8 NVFP4 rows ([#323](https://github.com/jesdga95/basalt/issues/323)
    ).
*   The shipped executables land in `bin/` with every generator ([#373](https://github.com/jesdga95/basalt/issues/373)
    ); test targets build only with `BUILD_TESTING` ([#370](https://github.com/jesdga95/basalt/pull/370)
    , [@giveen](https://github.com/giveen)
    ); the DeepSeek TIER line says where file reads go through the file cache ([#372](https://github.com/jesdga95/basalt/issues/372)
    ); a Windows macro no longer breaks the dense build.
*   The 27B's per-card weights are one allocation, so the layer split's plan is what the load takes.
*   Community rows from [@edicristofaro](https://github.com/edicristofaro)
     ([#380](https://github.com/jesdga95/basalt/pull/380)
    ), [@Suppressor72](https://github.com/Suppressor72)
     ([#362](https://github.com/jesdga95/basalt/pull/362)
    ) and [@hronoas](https://github.com/hronoas)
     ([#371](https://github.com/jesdga95/basalt/pull/371)
    ).

Upgrading
---------

*   New flags only: the 27B takes `--rope-scaling`, `--rope-scale`, `--yarn-*` and `--kv-resident`. No flag or config key is removed or renamed.
*   **Flash-Next's RAM copy is about 2 GiB smaller** on a box where RAM bounds it (the plan leaves 2 GiB beside `--ram-reserve-mib`). `--ram-reserve-mib` still sets the guard.
*   **`--parallel` engine protocol:** the server sends prompts as text with `PROMPT`/`PMATCH`/`PFREE`. A server and engine must come from the same release, as always.
*   The `.basalt` format stays version 2 and the config version stays 2.

Checked
-------

At 400 W + 180 W, on the release commit against the `main` before the last seven changes (cgroup readings, the RAM plan, `--parallel` prompts in the engine, `/slots`, `-march=native`):

*   Greedy output: identical for Flash-Next alone and with `--parallel 2` (requests one at a time), the 27B on one card, and DeepSeek on two cards. Concurrent `--parallel` requests and one long DeepSeek prompt differ between two runs of the same build, on both builds alike.
*   Speed (`basalt-bench`, 16k prompt, conv/struct/prose, interleaved runs): Flash-Next with its peer card, the 27B and DeepSeek on two cards within run-to-run spread; prompt reads, conv and struct within 0.1–0.4%.
*   Flash-Next limited to about 56 GiB of free RAM on two cards: the RAM plan 2.2 GB smaller, the lowest free RAM 3.7–4.0 GiB against 2.0–2.6, every start loads and serves, and warm decode unchanged within its spread (198 against 196 tok/s).
*   `--parallel 2` with two conversations: each follow-up reuses its history, `/slots` shows each slot's held tokens.
*   The 27B layer split: output bitwise one card's at every window width, with `--parallel`, checkpoints and parked conversations.
*   CPU tests, serve tests, lint and the WERROR build: pass.

### Contributors

*   [![@JimJafar](https://avatars.githubusercontent.com/u/325261?s=64&v=4)](https://github.com/JimJafar)

*   [![@giveen](https://avatars.githubusercontent.com/u/1180939?s=64&v=4)](https://github.com/giveen)

*   [![@edicristofaro](https://avatars.githubusercontent.com/u/1906603?s=64&v=4)](https://github.com/edicristofaro)

*   [![@hronoas](https://avatars.githubusercontent.com/u/13671811?s=64&v=4)](https://github.com/hronoas)

*   [![@mitalbert](https://avatars.githubusercontent.com/u/15214337?s=64&v=4)](https://github.com/mitalbert)

*   [![@stevenm76](https://avatars.githubusercontent.com/u/35263413?s=64&v=4)](https://github.com/stevenm76)

*   [![@Suppressor72](https://avatars.githubusercontent.com/u/65858775?s=64&v=4)](https://github.com/Suppressor72)

*   [![@hiraghi](https://avatars.githubusercontent.com/u/160518656?s=64&v=4)](https://github.com/hiraghi)


JimJafar, giveen, and 6 other contributors

Assets 4

Loading

### Uh oh!

There was an error while loading. [Please reload this page](https://github.com/jesdga95/basalt/releases)
.



All reactions

Basalt 0.4.0
------------

[Basalt 0.4.0](https://github.com/jesdga95/basalt/releases/tag/v0.4.0)

Compare

Choose a tag to compare
=======================

Sorry, something went wrong.
----------------------------

Filter

Loading

Sorry, something went wrong.
----------------------------

### Uh oh!

```

</details>

<details><summary>Tool result · web_scrape · call_81b8ccca5ab147edb84b1ef5</summary>

**Firecrawl · section 1 of 3**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,962 characters · included below
- Section 2 · 12,000 characters · omitted from this copy
- Section 3 · 10,182 characters · omitted from this copy

```text
[Skip to content](https://github.com/iamwavecut/ninfer-all/commits/master/docs/qwen3-8-flash-next.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/commits/master/docs/qwen3-8-flash-next.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/commits/master/docs/qwen3-8-flash-next.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/commits/master/docs/qwen3-8-flash-next.md)
 to refresh your session. Dismiss alert

                  [](https://github.com/iamwavecut/ninfer-all)


Breadcrumbs
-----------

History for

on[master](https://github.com/iamwavecut/ninfer-all/tree/master)

User selector
-------------

All users

Datepicker
----------

All time

Commit history
--------------

1.  ### Commits on Nov 16, 2026

    *   #### [fix(qwen4\_exp): run staged GGUF host misses eagerly under WDDM](https://github.com/iamwavecut/ninfer-all/commit/43fd83d838751f831b594c4622b17fc20149a874)

        Show description for 43fd83d

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [43fd83d](https://github.com/iamwavecut/ninfer-all/commit/43fd83d838751f831b594c4622b17fc20149a874)
        View commit details

        Copy full SHA for 43fd83d

        [](https://github.com/iamwavecut/ninfer-all/blob/43fd83d838751f831b594c4622b17fc20149a874/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/43fd83d838751f831b594c4622b17fc20149a874)
        Browse repository at this point


2.  ### Commits on Nov 13, 2026

    *   #### [feat(engram): DeepSeek-V4.1 ram-hot Engram reads from a hot-row profile](https://github.com/iamwavecut/ninfer-all/commit/2a4bd90adc02b02388ebab3d19c66b9ada983e85)

        Show description for 2a4bd90

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [2a4bd90](https://github.com/iamwavecut/ninfer-all/commit/2a4bd90adc02b02388ebab3d19c66b9ada983e85)
        View commit details

        Copy full SHA for 2a4bd90

        [](https://github.com/iamwavecut/ninfer-all/blob/2a4bd90adc02b02388ebab3d19c66b9ada983e85/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/2a4bd90adc02b02388ebab3d19c66b9ada983e85)
        Browse repository at this point

    *   #### [feat(spec): DSpine drafters as standalone artifacts for every family](https://github.com/iamwavecut/ninfer-all/commit/2d97f5122769a1149a798a8430184b6bc008a5e2)

        Show description for 2d97f51

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [2d97f51](https://github.com/iamwavecut/ninfer-all/commit/2d97f5122769a1149a798a8430184b6bc008a5e2)
        View commit details

        Copy full SHA for 2d97f51

        [](https://github.com/iamwavecut/ninfer-all/blob/2d97f5122769a1149a798a8430184b6bc008a5e2/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/2d97f5122769a1149a798a8430184b6bc008a5e2)
        Browse repository at this point

    *   #### [feat(qwen4\_exp): read any n-gram table of the model's shape](https://github.com/iamwavecut/ninfer-all/commit/504fa8a25a8cf713d5d7cf3680311fdd02a0817c)

        Show description for 504fa8a

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [504fa8a](https://github.com/iamwavecut/ninfer-all/commit/504fa8a25a8cf713d5d7cf3680311fdd02a0817c)
        View commit details

        Copy full SHA for 504fa8a

        [](https://github.com/iamwavecut/ninfer-all/blob/504fa8a25a8cf713d5d7cf3680311fdd02a0817c/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/504fa8a25a8cf713d5d7cf3680311fdd02a0817c)
        Browse repository at this point

    *   #### [docs(readme): one row for the builds of Qwen3.8-27B and of Qwen3.8-Flash-Next](https://github.com/iamwavecut/ninfer-all/commit/d8a7bdc7d869ce838c48f6742aa788d6d43b1a0d)

        Show description for d8a7bdc

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [d8a7bdc](https://github.com/iamwavecut/ninfer-all/commit/d8a7bdc7d869ce838c48f6742aa788d6d43b1a0d)
        View commit details

        Copy full SHA for d8a7bdc

        [](https://github.com/iamwavecut/ninfer-all/blob/d8a7bdc7d869ce838c48f6742aa788d6d43b1a0d/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/d8a7bdc7d869ce838c48f6742aa788d6d43b1a0d)
        Browse repository at this point

    *   #### [feat(engine): Edge0 drafts with MTP on device experts when it serves one request](https://github.com/iamwavecut/ninfer-all/commit/f867b0081ec3e8fd336799355d16e881dad84b72)

        Show description for f867b00

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [f867b00](https://github.com/iamwavecut/ninfer-all/commit/f867b0081ec3e8fd336799355d16e881dad84b72)
        View commit details

        Copy full SHA for f867b00

        [](https://github.com/iamwavecut/ninfer-all/blob/f867b0081ec3e8fd336799355d16e881dad84b72/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/f867b0081ec3e8fd336799355d16e881dad84b72)
        Browse repository at this point


3.  ### Commits on Nov 11, 2026

    *   #### [docs: describe --gumbel-sampling and its draft acceptance](https://github.com/iamwavecut/ninfer-all/commit/b236ddb47c741d82ebad4ee0ff64c4057c348876)

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [b236ddb](https://github.com/iamwavecut/ninfer-all/commit/b236ddb47c741d82ebad4ee0ff64c4057c348876)
        View commit details

        Copy full SHA for b236ddb

        [](https://github.com/iamwavecut/ninfer-all/blob/b236ddb47c741d82ebad4ee0ff64c4057c348876/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/b236ddb47c741d82ebad4ee0ff64c4057c348876)
        Browse repository at this point

    *   #### [perf(qwen4\_exp): run a layer's projections of one input together](https://github.com/iamwavecut/ninfer-all/commit/f4ef85e633b6eb61e929d2d90bbd69ff5d218082)

        Show description for f4ef85e

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [f4ef85e](https://github.com/iamwavecut/ninfer-all/commit/f4ef85e633b6eb61e929d2d90bbd69ff5d218082)
        View commit details

        Copy full SHA for f4ef85e

        [](https://github.com/iamwavecut/ninfer-all/blob/f4ef85e633b6eb61e929d2d90bbd69ff5d218082/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/f4ef85e633b6eb61e929d2d90bbd69ff5d218082)
        Browse repository at this point

    *   #### [feat(experts): read disk experts from a drive mirror or straight into device memory](https://github.com/iamwavecut/ninfer-all/commit/11892986791f41ea2c9deb3ca036a43a4cdb1eab)

        Show description for 1189298

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [1189298](https://github.com/iamwavecut/ninfer-all/commit/11892986791f41ea2c9deb3ca036a43a4cdb1eab)
        View commit details

        Copy full SHA for 1189298

        [](https://github.com/iamwavecut/ninfer-all/blob/11892986791f41ea2c9deb3ca036a43a4cdb1eab/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/11892986791f41ea2c9deb3ca036a43a4cdb1eab)
        Browse repository at this point

    *   #### [perf: end a logit-free prompt chunk's last layer at its K/V appends](https://github.com/iamwavecut/ninfer-all/commit/f469a6cae3c1120aa6555ccb2be0cc94be9853ba)

        Show description for f469a6c

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [f469a6c](https://github.com/iamwavecut/ninfer-all/commit/f469a6cae3c1120aa6555ccb2be0cc94be9853ba)
        View commit details

        Copy full SHA for f469a6c

        [](https://github.com/iamwavecut/ninfer-all/blob/f469a6cae3c1120aa6555ccb2be0cc94be9853ba/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/f469a6cae3c1120aa6555ccb2be0cc94be9853ba)
        Browse repository at this point

    *   #### [test(qwen4\_exp): run only the mapped hybrid exchange under WDDM](https://github.com/iamwavecut/ninfer-all/commit/18136ba7a92ae505a43ea1ec84266f970b7af6be)

        Show description for 18136ba

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

        [18136ba](https://github.com/iamwavecut/ninfer-all/commit/18136ba7a92ae505a43ea1ec84266f970b7af6be)
        View commit details

        Copy full SHA for 18136ba

        [](https://github.com/iamwavecut/ninfer-all/blob/18136ba7a92ae505a43ea1ec84266f970b7af6be/docs/qwen3-8-flash-next.md)
        View code at this point[](https://github.com/iamwavecut/ninfer-all/tree/18136ba7a92ae505a43ea1ec84266f970b7af6be)
        Browse repository at this point

    *   #### [perf(flash-next): let the CPU share few-pair experts of 9-64-token calls](https://github.com/iamwavecut/ninfer-all/commit/57a3e06f50ae1fb08e91cbe0f2cb156f63b501e8)

        Show description for 57a3e06

        [![iamwavecut](https://avatars.githubusercontent.com/u/239034?v=4&size=32)](https://github.com/iamwavecut)
        [iamwavecut](https://github.com/iamwavecut/ninfer-all/commits?author=iamwavecut)

        committed

```

</details>

<details><summary>Tool result · web_scrape · call_aec2f87a8fa0434e98fb3809</summary>

[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3#qwen38-flash-next-n-gram-table-ninfer-v3-artifact)
Qwen3.8-Flash-Next n-gram table, NInfer v3 artifact
=================================================================================================================================================================================

The n-gram table of Qwen3.8-Flash-Next's per-layer embedding (PLE), as a [NInfer](https://github.com/Neroued/ninfer)
 **v3** artifact for **NInfer-all**, the `master` branch of [iamwavecut/ninfer-all](https://github.com/iamwavecut/ninfer-all)
. Every NInfer conversion of Qwen3.8-Flash-Next published without its table reads its rows from this file:

| model | artifact |
| --- | --- |
| Qwen3.8-Flash-Next GSQ-RCO Q2\_0 | [WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-Q2\_0-NInfer-v3](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-NInfer-v3) |
| Qwen3.8-Flash-Next GSQ-RCO IQ3\_S | [WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3\_S-NInfer-v3](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3) |
| Qwen3.8-Flash-Next Coder GSQ-RCO IQ1\_M | [WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-Coder-IQ1\_M-NInfer-v3](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-Coder-IQ1_M-NInfer-v3) |

Stock NInfer builds cannot read it: the model family and the `gguf_*` formats exist only in that line; build `master` from commit [`82f120de`](https://github.com/iamwavecut/ninfer-all/commit/82f120dece4de7e411fc8815fb0d3cc34706fa3e)
 on.

[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3#what-is-inside)
What is inside
---------------------------------------------------------------------------------------------------------

The table holds 320,001,536 rows of 160 values (51.2B parameters), 16 hash heads over the 2- and 3-token n-grams of the context, each head's rows at its own offset. Every token reads the 16 rows its n-grams address. The rows are ISTA-DASLab's IQ4\_NL blocks (`per_layer_token_embd` of their GGUF releases, 90 bytes a row), copied byte for byte: the second shard of every GSQ-RCO release, the Coder build's included, is the same file.

One file, `Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer`, of 28,905,035,512 bytes (26.92 GiB), next to its conversion report, `SHA256SUMS`, `NOTICE` and `LICENSE`. Its `ngram` component records the hash constants the rows were written for, their format and the SHA-256 of the rows, `dd55c28902f38cd88134b2a569c51282c5ffce30080487e1a645740115c56cc3`. A model names the table it needs by those. NInfer-all from [`57395b20b`](https://github.com/iamwavecut/ninfer-all/commit/57395b20b4ee9c4ac792146d82ffac6b28396a9b)
 on reads any table of a model's hash constants and geometry, in any row format, and warns when it is not the one the model names: Edge0's models read this table in place of [their FP8 table](https://huggingface.co/WaveCut/Edge0-ngram-table-FP8-NInfer-v3)
, at 0.6% to 1.2% higher perplexity. Original row conversion command, before profile attachment:

    python3 -m tools.convert --model Qwen3.8-Flash-Next \
      --recipe qwen3_8_flash_next_gguf --components ngram \
      --source ngram=Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00002-of-00002.gguf \
      --device cpu --rows-per-chunk 65536 \
      --name qwen3.8-flash-next-ngram-table --out Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer


`--model` needs only the configuration files of [Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)
.

[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3#running)
Running
-------------------------------------------------------------------------------------------

Download it next to a model and pass it with `--ngram-table`:

    hf download WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3 \
      Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer --local-dir models
    hf download WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-NInfer-v3 \
      Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-ninfer-v3.ninfer --local-dir models
    ninfer-serve models/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-ninfer-v3.ninfer \
      --ngram-table models/Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer \
      --model-id qwen3.8-flash-next --expert-residency host --max-context 32768


The [Docker image](https://github.com/iamwavecut/ninfer-all#docker)
 takes the same flags after `serve`, with both files under `/models`:

    docker run --rm --gpus all -p 8080:8080 --ulimit memlock=-1 \
      -v "$PWD/models:/models" -v ninfer-cache:/cache \
      ghcr.io/iamwavecut/ninfer-all serve /models/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-ninfer-v3.ninfer \
      --ngram-table /models/Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer \
      --model-id qwen3.8-flash-next --expert-residency host --max-context 32768


With the default disk residency, nothing reads all table rows at load: each token reads its 16 rows (1.4 KB) from the file through the OS page cache, so the table can sit on any disk. `--ngram-residency ram` loads all of it into RAM instead.

A model started without its table is refused. `--no-ngram-table` overrides that, and the model then runs without its per-layer embedding: a non-standard, experimental mode, warned about at startup, with no practical use. The model was trained with the table: without it the Q2\_0 release's WikiText-2 perplexity nearly doubles, from 2.66 to 5.01.

[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3#optional-broad-n-gram-profile)
Optional broad n-gram profile
---------------------------------------------------------------------------------------------------------------------------------------

This update adds a 104,893,176-byte row ranking as an embedded resource and as `broad-v1.hot`. The container grows by 104,893,176 bytes (0.364%). Every pre-existing object passed exact byte readback; the IQ4 row bytes, quantization and row digest are unchanged. This profile selects cached rows; it does not change model weights or establish answer-quality improvements.

The deterministic corpus uses four pinned [Common Corpus](https://huggingface.co/datasets/PleIAs/common_corpus)
 shards and one pinned [github-code-clean](https://huggingface.co/datasets/codeparrot/github-code-clean)
 shard. It covers prose, web, press, science and code without preferred languages. Equal per-group token ceilings limit dominance, and source documents or repositories separate training from held-out text. `profile-corpus.json` records revisions, sampling and limitations. Language labels are automatic; this finite sample is not a complete language inventory or an estimate of user traffic. Exact snippet deduplication does not eliminate all near-duplicates.

The profile contains 26,223,284 ranked rows from 3,711,509 training tokens. The held-out set contains 1,103,918 tokens and 445 domain/language groups. NumPy and the native C++ profiler produced byte-identical profiles.

| RAM budget, MiB | held-out row hits |
| --- | --- |
| 256 | 33.79% |
| 512 | 38.49% |
| 1024 | 42.92% |
| 2048 | 48.48% |
| 4096 | 49.64% |
| 8192 | 49.64% |
| 16384 | 49.64% |
| 32768 | 49.64% |

Across 239 groups with at least 2,048 held-out tokens, the minimum / median / maximum hit rates are 6.04% / 32.85% / 90.64% at 256 MiB and 20.54% / 49.38% / 95.47% at 4 GiB. Japanese books have the lowest measured coverage: 6.04% and 20.54%, respectively. All groups, including sparse ones, remain in `profile-heldout.json`.

On RTX 3090, disk residency, the embedded profile and the explicit profile produced identical tokens for two prompts, two repetitions and 32 output tokens, with MTP K=4 and int8 KV. Both profile modes served rows from the configured 256 MiB RAM cache. The Engine report retains startup time, every sample and memory counters. Cache state was uncontrolled and artifact transfers overlapped these checks, so this is functional evidence, not an isolated speedup. Caching remains opt-in; earlier cache tests showed 10–11% slower first requests.

Public commit `64492cb14` accepts an explicit profile:

    hf download WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3 broad-v1.hot --local-dir models
    # Add these options to the serving command above:
    --ngram-residency ram-hot --ngram-hot-profile models/broad-v1.hot --ngram-ram-mib 256


Automatic loading of the embedded profile is available in NInfer master at [ac94a1b610f6](https://github.com/iamwavecut/ninfer-all/commit/ac94a1b610f646c4d9f0e9b4e0e02b7a34261d0a)
 and was qualified on the development snapshot recorded in `profile-engine.json`. Use `--ngram-residency ram-hot --ngram-ram-mib 256` to select it. Older commit `64492cb14` requires the explicit `--ngram-hot-profile` option above. Default disk operation does not use the profile.

[](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3#credits-and-license)
Credits and license
-------------------------------------------------------------------------------------------------------------------

The table comes from ISTA-DASLab's [Qwen3.8-Flash-Next GSQ-RCO GGUFs](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)
, which quantize [Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)
. The model is released under the Qwen Community License 1.0, reproduced in [`LICENSE`](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3/tree/main/LICENSE)
, and its conditions apply to this file; ISTA-DASLab publish their GGUFs under Apache-2.0. Attribution notices are collected in [`NOTICE`](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3/tree/main/NOTICE)
. This repository only re-packs those rows into NInfer's container.

Downloads last month

7,954

Inference Providers [NEW](https://huggingface.co/docs/inference-providers)

This model isn't deployed by any Inference Provider. [🙋 Ask for provider support](https://huggingface.co/spaces/huggingface/InferenceSupport/discussions/new?title=WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3&description=React%20to%20this%20comment%20with%20an%20emoji%20to%20vote%20for%20%5BWaveCut%2FQwen3.8-Flash-Next-ngram-table-NInfer-v3%5D(%2FWaveCut%2FQwen3.8-Flash-Next-ngram-table-NInfer-v3)%20to%20be%20supported%20by%20Inference%20Providers.%0A%0A(optional)%20Which%20providers%20are%20you%20interested%20in%3F%20(Novita%2C%20Hyperbolic%2C%20Together%E2%80%A6)%0A)

Model tree for WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3[](https://huggingface.co/docs/hub/model-cards#specifying-a-base-model)

---------------------------------------------------------------------------------------------------------------------------------------

Base model

[Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)

Quantized

[ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)

Quantized

([54](https://huggingface.co/models?other=base_model:quantized:ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)
)

this model

Inference providers allow you to run inference using different serverless providers.

</details>

## Assistant · #41

<details><summary>Reasoning · 3,062 characters</summary>

Need maybe inspect Shockem collection previous pack and file sizes. The model card gave enough. Need maybe check HF files for Shockem to get file listing exact. It lists one .basalt size 113,491,281,169 bytes (105.7 GiB). Official IQ3_S NInfer 58,242,390,528 bytes (54.24 GiB), table 28,905,035,512 (26.92). Compare: total NInfer self-contained with IQ4 table = 87,147,426,040? Let's calculate: 58,242,390,528 + 28,905,035,512 = 87,147,426,040 bytes = 81.16 GiB. Shockem file 113,491,281,169 bytes = 105.7 GiB. Difference 26,343,855,129 bytes = 24.53 GiB. If compare just file (not table) 105.7 vs 54.24 = +51.5 GiB. But if self-contained conversion with same IQ4 table, Shockem should be 54.24 + 26.92 = 81.16; actual +24.5 due Q8 table. However Shockem also abliterated experts? Experts same IQ3_S with transplanted residual-write tensors? Does not change size. It uses official IQ3_S pack sections MTP/vision/hc8/tokenizer. It includes ngram Q8 table. Why official NInfer Flash-Next IQ3_S artifact 54.24 excludes table but includes MTP/vision/DFlash2. Shockem includes MTP/vision/hc8/tokenizer and Q8 ngram but no DFlash2? Basalt uses MTP only, maybe no DFlash2. It has 105.7. If remove Q8 PLE 54.4, leaves 51.3; NInfer excluding ngram 54.24 includes DFlash2 0.34 and maybe similar. So comparable.

Need maybe discuss "batched inference" and model currently served. Basalt supports --parallel 1-8, but "batched inference through .basalt checkpoints" maybe user refers batched. NInfer supports up to 8 requests. But if serving model Shockem, NInfer engine recognizes .ninfer only, cannot load .basalt. It recognized WaveCut .ninfer because Qwen3.8-27B. Need maybe answer: engine cannot serve your .basalt checkpoint; it needs conversion to .ninfer or use Basalt. It doesn't magically read .basalt. Could a .ninfer conversion of the Shockem GGUF be ~54.24 + table. The abliterated GGUF source from SC117 could be converted by NInfer-all recipe? Need verify whether ninfer-all supports SC117 GGUF? It supports GSQ-RCO and Unsloth Dynamic v3.1; SC117 is a transplant of residual-write tensors into GSQ-RCO IQ3_S. Since GGUF same architecture and tensor types, NInfer-all likely can convert it if vocabulary and metadata match and MTP/vision supplied separately. But there may be missing MTP block; official GSQ-RCO omits MTP; NInfer uses unsloth shared-Q8_0 MTP. Shockem's Basalt pack carries MTP from official IQ3_S pack? It says official IQ3_S pack carries self-distilled MTP drafter, vision, profile, tokenizer. NInfer recipe needs MTP GGUF source; can use Unsloth shared-Q8_0. Could build .ninfer from SC117 IQ3_S GGUF + mmproj + MTP + DFlash2 maybe. But if model type front unified, likely possible. Need caution: NInfer-all master as of Nov 16 supports Flash-Next GGUF blocks, but stock NInfer refuses. It does not read .basalt. Conversion is offline, not runtime direct.

Need maybe inspect ninfer-all commits for "decision framework ported". Could search latest commit PR #370 decision-read-stop-token; maybe typed decisions API. Let's scrape PR or docs.


</details>

<details><summary>Tool request · web_scrape · call_0194dbfa194b4989af2477a4</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/pull/370"
}
```

</details>

<details><summary>Tool request · web_scrape · call_8f64f9f023a14eb68063b062</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/commits/master/src/decisions"
}
```

</details>

<details><summary>Tool request · web_scrape · call_4acfeb1c520c45e9874466e1</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/decisions.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_3feda470361d460785fb5f8d</summary>

```json
{
  "url": "https://github.com/CommanderTurtle/decisive-ninfer/branches"
}
```

</details>


<details><summary>Tool result · web_scrape · call_0194dbfa194b4989af2477a4</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/pull/370#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/pull/370)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/pull/370)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/pull/370)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Conversation
------------

 [![@iamwavecut](https://avatars.githubusercontent.com/u/239034?s=80&v=4)](https://github.com/iamwavecut)

###

 ![@iamwavecut](https://avatars.githubusercontent.com/u/239034?s=48&v=4)**[iamwavecut](https://github.com/iamwavecut)** commented [Nov 16, 2026](https://github.com/iamwavecut/ninfer-all/pull/370#issue-6432958414)

Copy link

Copy Markdown

Owner

Two defects of the typed decision reads (`/v1/systemone`, `/v1/decisions`) that the checks of [#362](https://github.com/iamwavecut/ninfer-all/pull/362)
 and [#359](https://github.com/iamwavecut/ninfer-all/pull/359)
 found on master (both defects predate them).

*   **A read whose most likely token is a stop token failed with HTTP 500** ("the decision read produced no answer token"). A question longer than one prefill pass, and every read of media, runs as an ordinary one-token request and takes its answer from the content token's logprob record; a stop token is not content and has no record. The decision reads and rerank judgements now run with raw output (`ninfer::OutputOptions::raw`), so the first token is content whatever it is, with its record and readout.
*   **On a Qwen3.5-core model with `--spec`, every digit read of a wide label prefilled the whole question again.** A read without drafting publishes no endpoint there, and the reads of the next digit resume from the first read's endpoint. `Engine::read_endpoints_need_drafting` names that case; there the first read of a label of several digits drafts (one token drafts nothing). Continued reads, one-character labels, rerank and the other families keep the drafter off.

Measured on an RTX 3090 (Vast, CUDA 12.9.2 CI-mirror build, master + [#362](https://github.com/iamwavecut/ninfer-all/pull/362)
 + [#359](https://github.com/iamwavecut/ninfer-all/pull/359)
), Qwen3.8-27B GSQ-RCO IQ3\_S, two alternating rounds per side:

| Request | before | after |
| --- | --- | --- |
| ticket, 60- and 30-option choices + noul (3 tickets), no `--spec` | 2 of 3 HTTP 500 | 3 of 3 answered, 2.85–2.98 s |
| same, `--spec mtp --draft-tokens 3` | 15.56–15.83 s | 2.91–3.05 s |
| same, no `--spec`, after the first fix | 2.89–3.00 s | 2.88–3.00 s |
| short 40-option choice (branched reads) | 0.96 s | 0.96 s |
| image box + 30-option choice, `--spec mtp` | 36.16 s | 4.20 s |
| image URL box + 30-option choice, `--spec mtp` | 11.17 s | 2.82 s |

Answers: without `--spec` the answered requests are identical before and after; with `--spec mtp` the long reads now equal the answers without `--spec` exactly (before, up to 0.018 apart in a probability), and every choice is the same. Qwen3.8-Flash-Next with `--spec mtp` (its reads publish their entries without drafting) is unchanged: image box 6.355–6.400 s before, 6.381–6.392 s after; image URL box 4.408–4.431 s before, 4.430–4.434 s after. A first version that drafted every wide-label read there cost 9–12%; `Engine::read_endpoints_need_drafting` keeps it off.

Tests: `ninfer_qwen3_5_frontend_test` (a raw session keeps a stop token's record; a decoded one does not), `ninfer_systemone_test`, `ninfer_rerank_test`, `ninfer_openai_schema_test` on the pod.

Sorry, something went wrong.

### Uh oh!

There was an error while loading. [Please reload this page](https://github.com/iamwavecut/ninfer-all/pull/370)
.



All reactions[iamwavecut](https://github.com/iamwavecut)
 added 2 commits [November 17, 2026 00:17](https://github.com/iamwavecut/ninfer-all/pull/370#commits-pushed-0686128)

[![@iamwavecut](https://avatars.githubusercontent.com/u/239034?s=40&v=4)](https://github.com/iamwavecut)

`[fix(serve): keep a one-token read's record when the model picks a sto…](https://github.com/iamwavecut/ninfer-all/pull/370/commits/06861284c3f30fe547f4555d9f0f5666f23967da "fix(serve): keep a one-token read's record when the model picks a stop token  A decision read longer than one prefill pass runs as an ordinary one-token request and takes its answer from the content token's logprob record. When the model's most likely token there is a stop token, the token is not content and has no record, and the read failed with "the decision read produced no answer token" (HTTP 500). The typed decisions and rerank judgements now run with raw output, so every first token is content and keeps its record and readout.")` …





`[0686128](https://github.com/iamwavecut/ninfer-all/pull/370/commits/06861284c3f30fe547f4555d9f0f5666f23967da) `

…p token

A decision read longer than one prefill pass runs as an ordinary
one-token request and takes its answer from the content token's logprob
record. When the model's most likely token there is a stop token, the
token is not content and has no record, and the read failed with "the
decision read produced no answer token" (HTTP 500). The typed decisions
and rerank judgements now run with raw output, so every first token is
content and keeps its record and readout.

[![@iamwavecut](https://avatars.githubusercontent.com/u/239034?s=40&v=4)](https://github.com/iamwavecut)

`[perf(serve): a wide label's first decision read drafts on the Qwen3.5…](https://github.com/iamwavecut/ninfer-all/pull/370/commits/dec746c3ecb69a641d512cc3f92de115efcf2a71 "perf(serve): a wide label's first decision read drafts on the Qwen3.5 core  A label of several digits is read a digit at a time, and on the staged path the reads of the next digit resume from the first read's endpoint. Decision reads ran without the drafter, and a Qwen3.5-core Engine with --spec publishes no endpoint for a request that does not draft, so every digit read prefilled the whole question again (Qwen3.8-27B IQ3_S with --spec mtp on an RTX 3090: 15.6 s for a ticket with 60- and 30-option choices, 2.96 s without --spec).  Engine::read_endpoints_need_drafting tells where that holds. There the first read of a wide label drafts (one token still drafts nothing) and publishes its endpoint; the reads that continue its prompt, one-character labels, rerank judgements and the other families keep the drafter off.")` …





`[dec746c](https://github.com/iamwavecut/ninfer-all/pull/370/commits/dec746c3ecb69a641d512cc3f92de115efcf2a71) `

… core

A label of several digits is read a digit at a time, and on the staged
path the reads of the next digit resume from the first read's endpoint.
Decision reads ran without the drafter, and a Qwen3.5-core Engine with
--spec publishes no endpoint for a request that does not draft, so every
digit read prefilled the whole question again (Qwen3.8-27B IQ3\_S with
--spec mtp on an RTX 3090: 15.6 s for a ticket with 60- and 30-option
choices, 2.96 s without --spec).

Engine::read\_endpoints\_need\_drafting tells where that holds. There the
first read of a wide label drafts (one token still drafts nothing) and
publishes its endpoint; the reads that continue its prompt, one-character
labels, rerank judgements and the other families keep the drafter off.

Hide details View details

[![@iamwavecut](https://avatars.githubusercontent.com/u/239034?s=40&u=ce07158c09b9b9afb527622c6198f8245313ee23&v=4)](https://github.com/iamwavecut)

[iamwavecut](https://github.com/iamwavecut)
 merged commit [`a317194`](https://github.com/iamwavecut/ninfer-all/commit/a3171940a3574cda4d4f3bc3000df7c0944e8ad8)
 into master [Nov 16, 2026](https://github.com/iamwavecut/ninfer-all/pull/370#event-36339399339)

1 check failed

### Uh oh!

There was an error while loading. [Please reload this page](https://github.com/iamwavecut/ninfer-all/pull/370)
.

[![@iamwavecut](https://avatars.githubusercontent.com/u/239034?s=40&u=ce07158c09b9b9afb527622c6198f8245313ee23&v=4)](https://github.com/iamwavecut)

[iamwavecut](https://github.com/iamwavecut)
 deleted the dev/decision-read-stop-token branch [November 16, 2026 23:17](https://github.com/iamwavecut/ninfer-all/pull/370#event-36339402078)

[Sign up for free](https://github.com/join?source=comment-repo)
 **to join this conversation on GitHub**. Already have an account? [Sign in to comment](https://github.com/login?return_to=https%3A%2F%2Fgithub.com%2Fiamwavecut%2Fninfer-all%2Fpull%2F370)

 ### Reviewers

No reviews

### Uh oh!

There was an error while loading. [Please reload this page](https://github.com/iamwavecut/ninfer-all/pull/370)
.

### Assignees

No one assigned

### Labels

None yet

### Projects

None yet

### Milestone

No milestone

### Development

Successfully merging this pull request may close these issues.

### Uh oh!

There was an error while loading. [Please reload this page](https://github.com/iamwavecut/ninfer-all/pull/370)
.

### 1 participant

[![@iamwavecut](https://avatars.githubusercontent.com/u/239034?s=52&v=4)](https://github.com/iamwavecut)

Add this suggestion to a batch that can be applied as a single commit.This suggestion is invalid because no changes were made to the code.Suggestions cannot be applied while the pull request is closed.Suggestions cannot be applied while viewing a subset of changes.Only one suggestion per line can be applied in a batch.Add this suggestion to a batch that can be applied as a single commit.Applying suggestions on deleted lines is not supported.You must change the existing code in this line in order to create a valid suggestion.Outdated suggestions cannot be applied.This suggestion has been applied or marked resolved.Suggestions cannot be applied from pending reviews.Suggestions cannot be applied on multi-line comments.Suggestions cannot be applied while the pull request is queued to merge.Suggestion cannot be applied right now. Please check back later.

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_8f64f9f023a14eb68063b062</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/commits/master/src/decisions#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/commits/master/src/decisions)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/commits/master/src/decisions)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/commits/master/src/decisions)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Breadcrumbs
-----------

History for

on[master](https://github.com/iamwavecut/ninfer-all/tree/master)

User selector
-------------

All users

Datepicker
----------

All time

No commits history
------------------

There isn't any commit history to show here

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_4acfeb1c520c45e9874466e1</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/decisions.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/decisions.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/decisions.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/decisions.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

404 - page not found
--------------------

The master branch of **ninfer-all** does not contain the path **docs/decisions.md.**

[Return to the repository overview](https://github.com/iamwavecut/ninfer-all)

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_3feda470361d460785fb5f8d</summary>

[Skip to content](https://github.com/CommanderTurtle/decisive-ninfer/branches#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/CommanderTurtle/decisive-ninfer/branches)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/CommanderTurtle/decisive-ninfer/branches)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/CommanderTurtle/decisive-ninfer/branches)
 to refresh your session. Dismiss alert

                 Search

Default
-------

| Branch | Updated | Check status | BehindAhead | Pull request | Action menu |
| --- | --- | --- | --- | --- | --- |
| [feature/parallel-decision](https://github.com/CommanderTurtle/decisive-ninfer)<br><br>Copy branch name to clipboard | [![CommanderTurtle](https://avatars.githubusercontent.com/u/15604933?s=32&v=4)](https://github.com/CommanderTurtle)<br> Nov 16, 2026 |     |     |     | Delete branchBranch menu |

Active branches
---------------

| Branch | Updated | Check status | BehindAhead | Pull request | Action menu |
| --- | --- | --- | --- | --- | --- |
| [ninfer-all-40d913d-checkout](https://github.com/CommanderTurtle/decisive-ninfer/tree/ninfer-all-40d913d-checkout)<br><br>Copy branch name to clipboard | [![CommanderTurtle](https://avatars.githubusercontent.com/u/15604933?s=32&v=4)](https://github.com/CommanderTurtle)<br> Nov 16, 2026 |     |     |     | Delete branchBranch menu |
| [1a374127-checkout](https://github.com/CommanderTurtle/decisive-ninfer/tree/1a374127-checkout)<br><br>Copy branch name to clipboard | [![CommanderTurtle](https://avatars.githubusercontent.com/u/15604933?s=32&v=4)](https://github.com/CommanderTurtle)<br> Nov 16, 2026 |     |     |     | Delete branchBranch menu |
| [ninfer-all](https://github.com/CommanderTurtle/decisive-ninfer/tree/ninfer-all)<br><br>Copy branch name to clipboard | [![CommanderTurtle](https://avatars.githubusercontent.com/u/15604933?s=32&v=4)](https://github.com/CommanderTurtle)<br> Nov 16, 2026 |     |     |     | Delete branchBranch menu |
| [bac-stable-1a374127-feature/parallel-decision](https://github.com/CommanderTurtle/decisive-ninfer/tree/bac-stable-1a374127-feature/parallel-decision)<br><br>Copy branch name to clipboard | [![CommanderTurtle](https://avatars.githubusercontent.com/u/15604933?s=32&v=4)](https://github.com/CommanderTurtle)<br> Nov 16, 2026 |     |     |     | Delete branchBranch menu |
| [master](https://github.com/CommanderTurtle/decisive-ninfer/tree/master)<br><br>Copy branch name to clipboard | [![CommanderTurtle](https://avatars.githubusercontent.com/u/15604933?s=32&v=4)](https://github.com/CommanderTurtle)<br> Nov 16, 2026 |     |     |     | Delete branchBranch menu |

[View more branches](https://github.com/CommanderTurtle/decisive-ninfer/branches/active)

You can’t perform that action at this time.

</details>

## Assistant · #46

<details><summary>Reasoning · 404 characters</summary>

Need maybe inspect decisive-basalt framework. User says personally hosts decisive-basalt. Need scrape maybe GitHub? Could be repo user/decisive-basalt? Need know user handle? They mention Shockem? Maybe user is Shockem? They serve HF Shockem. They host decisive-basalt. Search web denied, but can scrape likely https://github.com/Shockem/decisive-basalt. Let's try. Also maybe HF dataset? Search GitHub.


</details>

<details><summary>Tool request · web_scrape · call_28c524d881df44b8a48c5361</summary>

```json
{
  "url": "https://github.com/Shockem/decisive-basalt"
}
```

</details>

<details><summary>Tool request · web_scrape · call_c2495989ba104431b0e2faa1</summary>

```json
{
  "url": "https://github.com/search?q=decisive-basalt&type=repositories"
}
```

</details>

<details><summary>Tool request · web_scrape · call_49a5b05f27bf45ac809847b1</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/blob/main/docs/running.md"
}
```

</details>


<details><summary>Tool result · web_scrape · call_28c524d881df44b8a48c5361</summary>

[Skip to content](https://github.com/Shockem/decisive-basalt#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/Shockem/decisive-basalt)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/Shockem/decisive-basalt)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/Shockem/decisive-basalt)
 to refresh your session. Dismiss alert

4 4

#### Didn’t find anything here!

Need to [sign in](https://github.com/login?return_to=https%3A%2F%2Fgithub.com%2FShockem%2Fdecisive-basalt)
?

Find code, projects, and people on GitHub:

 Search

[Contact Support](https://support.github.com/?tags=dotcom-404)
 — [GitHub Status](https://githubstatus.com/)
 — [@githubstatus](https://x.com/githubstatus)



You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_c2495989ba104431b0e2faa1</summary>

[Skip to content](https://github.com/search?q=decisive-basalt&type=repositories#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/search?q=decisive-basalt&type=repositories)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/search?q=decisive-basalt&type=repositories)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/search?q=decisive-basalt&type=repositories)
 to refresh your session. Dismiss alert

repositories Search Results · decisive-basalt
=============================================

Filter by
---------

*   *   [Code... (...)results](https://github.com/search?q=decisive-basalt&type=code)

    *   [Repositories0 (0)results](https://github.com/search?q=decisive-basalt&type=repositories)

    *   [Issues\
        \
        results](https://github.com/search?q=decisive-basalt&type=issues)

    *   [Pull requests\
        \
        results](https://github.com/search?q=decisive-basalt&type=pullrequests)

    *   [AI resources\
        \
        results](https://github.com/search?q=decisive-basalt&type=ai_resources)

    *   [Discussions\
        \
        results](https://github.com/search?q=decisive-basalt&type=discussions)

    *   More

*   [Advanced search](https://github.com/search/advanced)


Filter:Repositories0 (0)

0 results  (38 ms)

0 results
---------

Sort by: Best match

Filter

![Mona looking through a globe hologram for code](https://github.com/images/modules/search/light2x.png)

### Your search did not match any repositories

Try one of the tips below to find more repositories

Search across an organizationSaved searches

You could try an [advanced search](https://github.com/search/advanced?q=decisive-basalt)
.

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_49a5b05f27bf45ac809847b1</summary>

**Firecrawl · section 1 of 2**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,760 characters · included below
- Section 2 · 3,084 characters · omitted from this copy

```text
[Skip to content](https://github.com/jesdga95/basalt/blob/main/docs/running.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/running.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/running.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/docs/running.md)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

Collapse file tree


--------------------

Files
-----

main

Search this repository(forward slash) forward slash/

/

running.md
==========

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

[![giveen](https://avatars.githubusercontent.com/u/1180939?v=4&size=40)](https://github.com/giveen)
[giveen](https://github.com/jesdga95/basalt/commits?author=giveen)

[platform, serve: engine crashes, Windows memory figures and runtime e…](https://github.com/jesdga95/basalt/commit/99896e8d9c1a611d53b56405886b3a023541d2e0)

Open commit detailssuccess

Nov 17, 2026

[99896e8](https://github.com/jesdga95/basalt/commit/99896e8d9c1a611d53b56405886b3a023541d2e0)
 · Nov 17, 2026

History
-------

[History](https://github.com/jesdga95/basalt/commits/main/docs/running.md)

Open commit details

[](https://github.com/jesdga95/basalt/commits/main/docs/running.md)
History

152 lines (113 loc) · 11.1 KB

/

running.md
==========

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


152 lines (113 loc) · 11.1 KB

[Raw](https://github.com/jesdga95/basalt/raw/refs/heads/main/docs/running.md)

Copy raw file

Download raw file

You must be signed in to make or propose changes

More edit options

Outline

Edit and raw actions

Running the server
==================

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#running-the-server)

Settings: [configuration](https://github.com/jesdga95/basalt/blob/main/docs/configuration/index.md)
. Diagnostic flags: `bin/basalt --help`. Several models: [models and the router](https://github.com/jesdga95/basalt/blob/main/docs/configuration/models.md)
.

Start-up
--------

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#start-up)

The page is up at once and the model loads behind it. The header reads `Loading` with the percent over a progress bar while weights load; choosing a model in the picker loads it. `/health` and `/metrics` show the load. A failed start-up load ends the server. Requests wait during a load and get a 503 if it fails.

Concurrent requests: `--parallel N`
-----------------------------------

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#concurrent-requests---parallel-n)

`--parallel N` (1 to 8) serves N requests at once in batch slots. Further requests wait in arrival order. `--max-context` is shared: each slot holds `max-context / N` tokens (`--parallel 4 --max-context 262144` gives four slots of 65,536). A request longer than its slot is refused with a 400 that names the length. `--slot-full-context` gives every slot the whole `--max-context`, at N times the KV cache.

Each slot keeps two checkpoints (end of the system prompt, last turn), so requests that share a long system prompt read it once.

The engine tokenizes every prompt and matches it against what each slot holds. A reply the client sends back unchanged continues the slot's own tokens even when the model wrote it in other pieces than the tokenizer cuts the same bytes into (not with images).

### Session affinity

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#session-affinity)

With `--parallel`, a request that names its session goes to the slot that session last used, so the next turn continues the K/V already there. The session is the first of these headers that is set, then the request body's `session_id`: `x-llm-flow-id`, `x-claude-code-session-id`, `x-session-id`, `x-session-affinity`. A request with none picks a slot by the longest shared prefix, then the least recently used. When the session's slot is busy, the request takes that normal pick and the session's slot becomes the new one. Claude Code sends one `x-claude-code-session-id` for a session and its parallel subagents, so their overlapping requests spread over slots.

### Prompts beside decoding slots

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#prompts-beside-decoding-slots)

A prompt of up to 16,384 tokens is read at once, and the slots wait a few seconds. A longer one is read beside them, on its own thread, while the slots keep decoding. A short request that arrives meanwhile goes first at the end of the current chunk.

The console log
---------------

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#the-console-log)

Every line starts with `[server]`. Values are `key=value`. Start-up prints a legend, a line per model, `ready`, `loaded`, `kv`, `slots`. While a prompt is read, a slot prints `pp=<read>/<total>` with the rate. While requests generate, a `live` line appears every 2 s. Each request ends with one `done` line:

    [server] s1 done  pp=96/89c 0.1s  tg=1720 119.6t/s acc=65% dl=2.9  ttft=0.1s  end=stop  hit=89.7%  pcie=39.3%


*   `pp=<prompt tokens>/<cached>c`: the rate counts newly read tokens only.
*   `acc`: drafts accepted over drafts offered. `dl`: tokens per window, from the engine's own window count over the whole request (its solo and batch runs and every pass). With `--parallel` a window serves every busy slot in a fixed number of rows, so `dl` falls toward 1.0 as the slots fill. Both are absent when the request did not draft.
*   `end`: `stop`, `length`, `cancelled`, `disconnect` or `error`.
*   `hit`: expert cache hit rate. `pcie`: share of routed experts read over PCIe.

The engine's own `basalt ...` lines go to `~/.cache/basalt/<id>/engine.log`, one folder per model file (`<id>` is 16 hex digits taken from the file); `[server] engine log: PATH` names it at start. A log of 10 MiB or more moves to `engine.log.1` at the next start. An engine that dies of a fault or an unhandled exception writes a `basalt crash: error: ...` line (the fault, the stage it was in) and the server's warning quotes it with the exit status. The folder also holds the conversation cache. Nothing is unpacked from the model file: the server reads the tokenizer from its sections, and the engine and `basalt-vision` read the vision projector inside it.

The stats page
--------------

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#the-stats-page)

The server's address serves a page, updated every second from `/metrics`, `/slots` and `/api/logs`: GPU load, power, VRAM and temperature, RAM and disk, decode and prefill rates with 60 s charts, slots, the newest requests, and the console lines.

Three quiet figures sit in it, each from `/metrics`:

*   `N chats cached · X GiB` at the right of the Speed footer: the conversations parked in RAM (`conversation`: `parked`, `bytes`, `evictions`, and the last restore's `restored` tokens and `restored_ms`, in the tooltip). The server reads them from the engine's `conversation cache:` lines and clears them when the engine unloads, sleeps or restarts. A model that prints no line when it parks (DeepSeek) shows them after its first restore, without evictions.
*   `N requests served · M tokens written` under the Slots table (`totals`: requests, prompt, reused and written tokens, prompt and decode time since the server started; the rest in the tooltip).
*   The header word reads `Thinking`, `Answering` or `Tool call` (`live.phase`) while exactly one request runs.

The log panel shows the engine's long cache lines short (`cache: restored 187k tokens in 912 ms`); the log and `/api/logs` keep the raw line.

Conversations on disk: `--conversation-cache-disk-mib`
------------------------------------------------------

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#conversations-on-disk---conversation-cache-disk-mib)

Off at 0. With a budget, conversations of at least 8,192 tokens are written to `conversations` in the model's cache folder when they leave RAM, a session, or at exit. Only the system prompt's and the last three turns' states are stored. Files are bound to the model and settings they were made with, and checked by hash; a bad file is deleted. The folder is capped by the budget (least recently used first), and a write always leaves 4 GiB of the volume free. After a restart, a prompt that starts with a stored conversation reads it back.

Sleep: `--idle-sleep`
---------------------

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#sleep---idle-sleep)

After the given seconds without requests, the engine frees its VRAM (the driver moves the GPU state to host memory). The process and its RAM copy of the experts stay (a dense model has no cache to give back first: the driver moves all its GPU state, both cards' on two cards). The next request wakes it in seconds. Linux only. The server stays awake when the GPU state would not fit in free RAM with 8 GiB to spare. `--idle-unload` ends the process instead.

Memory floors
-------------

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#memory-floors)

Basalt refuses settings that would leave the machine without memory, and never shrinks what you asked for:

*   `--vram-reserve-mib` below 256 is refused on Windows and WSL2 (128 on Linux): less free VRAM makes the driver page GPU memory.
*   `--ram-reserve-mib` (default 2048) is the RAM left free for the rest of the system. The engine allocates its host buffers first, or holds their RAM when it page-locks them later; the expert tiers then take the free RAM less the reserve and less the driver's tracking of the pages they pin (`RAM floor ...` in the start log). Flash-Next's copy and top-up also leave 2 GiB beside the reserve for the host memory the engine takes after they read the free RAM (CUDA graphs, the first request), so the free RAM settles above the guard, not on it. When some experts stay in the file, the tiers also leave the OS file cache they are read through a floor: one prompt chunk's file reads and two layers' share of those experts, at least 4 GiB. Programs left idle beside a small reserve may be swapped out.
*   While serving, the RAM guard holds the reserve: below it, it parks conversations to disk or drops them. A request waits up to 30 s for RAM to return. A running request stops with an error only when RAM is critical (under 1 GiB free, or below the reserve under memory pressure). `--ram-reserve-mib 0` turns the guard off.
*   Experts on the SSD give one warning, the same for every model: `N experts on SSD (X GiB) · free X GiB RAM`. The console repeats it and the stats page turns its Experts block amber.
*   The disk tier keeps its floor a GiB above the reserve.
*   `--resident-budget-gib` that would leave less than the floor is refused with the largest safe value.

Vision: `--vision`
------------------

[](https://github.com/jesdga95/basalt/blob/main/docs/running.md#vision---vision)

`--vision off | dynamic | cpu | <GPU number>` (config: `"vision"` in `server`). The encoder is Basalt's own, and all modes give bitwise identical embeddings. All of them read the projector in place from the model file's `vision/mmproj` section. The text can still differ between modes: the sidecar's VRAM cost shrinks the expert cache, and which experts run on the GPU or the CPU shifts the last bits of the logits, so a greedy answer can fork after some tokens (`dynamic` does the same with a different cache size).

```

</details>

## Assistant · #50

<details><summary>Reasoning · 385 characters</summary>

No decisive-basalt public maybe private/local. We can mention cannot inspect if private. But user says personally hosts framework, maybe not needed.

Need perhaps check ninfer-all supported decisions docs. Could use web_search? denied earlier. Maybe search via GitHub code? Could scrape docs/README map. Use web_scrape docs README and maybe decisions anchor? Let's scrape docs README.


</details>

<details><summary>Tool request · web_scrape · call_fb04fef4adb448c288a7501f</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_af8e62d4a07a4986820edc06</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/openai-decisions.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_1f767d3f0e2c4526ba33a052</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/systemone.md"
}
```

</details>


<details><summary>Tool result · web_scrape · call_fb04fef4adb448c288a7501f</summary>

**Firecrawl · section 1 of 2**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 9,781 characters · included below
- Section 2 · 4,415 characters · omitted from this copy

```text
[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

FilesExpand file tree


-----------------------

master

/

README.md
=========

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/docs/README.md)

[](https://github.com/iamwavecut/ninfer-all/commits/master/docs/README.md)
History

94 lines (81 loc) · 9.03 KB

master

/

README.md
=========

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


94 lines (81 loc) · 9.03 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/docs/README.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

NInfer documentation
====================

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md#ninfer-documentation)

Start with the [project README](https://github.com/iamwavecut/ninfer-all/blob/master/README.md)
 to download an artifact and run the HTTP server from the Docker image or from a build. The executables' `--help` output is the exact source for option spelling and defaults.

User guides
-----------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md#user-guides)

| Document | Purpose |
| --- | --- |
| [Linux build](https://github.com/iamwavecut/ninfer-all/blob/master/docs/build-linux.md) | the container image, native Ubuntu builds for every target (`70`, `75`, `80`, `86`, `89`, `120a`), build options and the Bash launchers |
| [Windows build](https://github.com/iamwavecut/ninfer-all/blob/master/docs/build-windows.md) | native Windows builds, their toolchain constraints and the launcher scripts |
| [CLI](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md) | text, chat-history, image/video input, output streams, sampling, speculative decoding, the runtime options, and launch configuration files (`--config`) |
| [HTTP serving](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md) | OpenAI Responses/Chat Completions, Anthropic Messages, llama.cpp endpoints, rerank and typed decisions, the router, model suspend, state, streaming, token counting, authentication, tool calls, and the server options |
| [Ngram copy proposals](https://github.com/iamwavecut/ninfer-all/blob/master/docs/ngram.md) | copy acceleration alongside MTP, DFlash or DFlash2, on by default with a drafter |
| [Launch recipes](https://github.com/iamwavecut/ninfer-all/blob/master/docs/recipes.md) | the `ninfer-serve` configuration files in `configs/` for every model and memory size, from an 8 GB card to the largest context, and the flags they use |
| [Supported GPUs](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gpus.md) | architectures and their builds, every card of 8 GB and more with what has run on it, and what fits in a given amount of GPU memory |
| [Performance](https://github.com/iamwavecut/ninfer-all/blob/master/docs/performance.md) | every measured result card by card: largest context, decode and prompt rates by model, KV format, depth and drafter, several requests at once, Flash-Next's expert placements, quality; the measurement pages and users' field reports |
| [Weight conversion](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md) | official recipes, custom formats and sources, conversion methods, optional components and artifact output |
| [GGUF block formats](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md) | GGUF releases with a ggml type per tensor: the twenty block formats, their products, serving and measurements |
| [Qwen3.8-Flash-Next](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md) | converting the GSQ-RCO GGUF releases and their n-gram table; experts on one or several GPUs, in host memory or on disk; measurements |
| [Edge0](https://github.com/iamwavecut/ninfer-all/blob/master/docs/edge0.md) | Edge0-145B and Edge0-120B, latent-MoE models on the Flash-Next skeleton: converting the release folders, placements, tensor parallelism by groups, what differs from Flash-Next |
| [Gemma 4 26B-A4B](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gemma4.md) | converting Google's QAT GGUF release with its MTP assistant and vision tower, what runs, speculative decoding, images and video, the defaults, measurements against llama.cpp and the numerical checks |
| [Flint](https://github.com/iamwavecut/ninfer-all/blob/master/docs/flint.md) | converting a GGUF of Recursive's Flint, what runs, reasoning and GLM-4.7 tool calls, expert residency, measurements against llama.cpp and the numerical checks |
| [DeepSeek-V4.1-Flash](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md) | converting the GSQ-RCO IQ1\_M and Coder GGUFs and their Engram table, what runs, reasoning and DSML tool calls, host and disk experts, the Engram table's residency, measurements and the numerical checks |
| [Disk expert reads](https://github.com/iamwavecut/ninfer-all/blob/master/docs/expert-disk-reads.md) | disk experts striped over a second drive (`--expert-mirror`) and written by the drive straight into device memory (`--expert-direct`, NInfer's kernel modules) |
| [Perplexity](https://github.com/iamwavecut/ninfer-all/blob/master/docs/perplexity.md) | fixed-corpus and custom-text causal perplexity, comparison rules, progress, and reports |
| [Device profiles](https://github.com/iamwavecut/ninfer-all/blob/master/docs/device-profiles.md) | per-GPU route profiles: the built-in RTX 3090/4090/5090/PRO 6000/TITAN RTX/Tesla V100 table, calibration at first start, `ninfer-calibrate` |
| [Configuration calculator](https://github.com/iamwavecut/ninfer-all/blob/master/docs/config-calculator.html) | which context, KV format and speculation fit an RTX 3090 with Qwen3.8-27B or Qwen3.6-35B-A3B, from measurements |
| [CLI examples](https://github.com/iamwavecut/ninfer-all/blob/master/examples/cli) | committed text, multimodal, thinking, long-decode, and long-context inputs |
| [Release archives](https://github.com/iamwavecut/ninfer-all/blob/master/docs/release-archive-linux.md)<br> ([Windows](https://github.com/iamwavecut/ninfer-all/blob/master/docs/release-archive-windows.md)<br>) | the README that `scripts/package-release.sh` and `.ps1` put in a release archive |

Model artifacts
---------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md#model-artifacts)

The artifacts converted for this engine (Ternary Bonsai 2, the GSQ-RCO and Flash-Next conversions, the Qwen3.8-27B fine-tunes, Qwen3.6-35B-A3B NVFP4 and the Qwen3.8-27B DSpine drafter) are in the README's [artifact table](https://github.com/iamwavecut/ninfer-all/blob/master/README.md#artifacts)
; their cards live on Hugging Face. The official NInfer artifacts load as well; their cards on Hugging Face give upstream's requirements and its measurements on one RTX 5090. The `groupwise-int` artifacts run on every supported card. The `nvfp4` ones run on the FP4 tensor cores of a `120a` build and, on cards without them, through W4A16 routes or, with `--nvfp4-w4a8-int`, the int8 tensor cores.

| Model | Weights | Download |
| --- | --- | --- |
| Qwen3.6-27B | `groupwise-int` | [neroued/Qwen3.6-27B-NInfer](https://huggingface.co/neroued/Qwen3.6-27B-NInfer) |
| Qwen3.6-27B | `nvfp4` | [neroued/Qwen3.6-27B-nvfp4-NInfer](https://huggingface.co/neroued/Qwen3.6-27B-nvfp4-NInfer) |
| Qwen3.8-27B | `groupwise-int` | [neroued/Qwen3.8-27B-NInfer](https://huggingface.co/neroued/Qwen3.8-27B-NInfer) |
| Qwen3.8-27B | `nvfp4` | [neroued/Qwen3.8-27B-nvfp4-NInfer](https://huggingface.co/neroued/Qwen3.8-27B-nvfp4-NInfer) |
| Qwen3.6-35B-A3B | `groupwise-int` | [neroued/Qwen3.6-35B-A3B-NInfer](https://huggingface.co/neroued/Qwen3.6-35B-A3B-NInfer) |

Repository-local guides
-----------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md#repository-local-guides)

*   [Benchmarks](https://github.com/iamwavecut/ninfer-all/blob/master/bench/README.md)

*   [Tests](https://github.com/iamwavecut/ninfer-all/blob/master/tests/README.md)

*   [Tools](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md)

*   [Capability evaluation](https://github.com/iamwavecut/ninfer-all/blob/master/eval/README.md)

*   [Rented GPU hosts](https://github.com/iamwavecut/ninfer-all/blob/master/scripts/pods/README.md)


Maintainer references
---------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md#maintainer-references)

The references under [`maintainer/`](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer)
 record current architecture, model, artifact, and maintenance contracts. These files are not additional user workflows or installed API documentation. Several of them (engine architecture, artifact container, paged KV, ReplaySSM, resource scheduling) are written in Chinese, as upstream wrote them.

[Engine architecture](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/engine-architecture.md)
 is the single top-level reference. The other references own narrower contracts:

```

</details>

<details><summary>Tool result · web_scrape · call_af8e62d4a07a4986820edc06</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/openai-decisions.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/openai-decisions.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/openai-decisions.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/openai-decisions.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

404 - page not found
--------------------

The master branch of **ninfer-all** does not contain the path **docs/openai-decisions.md.**

[Return to the repository overview](https://github.com/iamwavecut/ninfer-all)

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_1f767d3f0e2c4526ba33a052</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/systemone.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/systemone.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/systemone.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/systemone.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

404 - page not found
--------------------

The master branch of **ninfer-all** does not contain the path **docs/systemone.md.**

[Return to the repository overview](https://github.com/iamwavecut/ninfer-all)

You can’t perform that action at this time.

</details>

## Assistant · #54

<details><summary>Reasoning · 199 characters</summary>

Decisions docs in serving. Could read section maybe. Need not.

Need maybe inspect qwen4-exp-model.md for implementation status and exact model type. Could be useful for "how far off ports". Scrape.


</details>

<details><summary>Tool request · web_scrape · call_e3dc0a7ed61c45bc9994b563</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md"
}
```

</details>


<details><summary>Tool result · web_scrape · call_e3dc0a7ed61c45bc9994b563</summary>

**Firecrawl · section 1 of 5**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 9,113 characters · included below
- Section 2 · 7,854 characters · omitted from this copy
- Section 3 · 11,692 characters · omitted from this copy
- Section 4 · 11,071 characters · omitted from this copy
- Section 5 · 2,046 characters · omitted from this copy

```text
[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

/

qwen4-exp-model.md
==================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/docs/maintainer/qwen4-exp-model.md)

[](https://github.com/iamwavecut/ninfer-all/commits/master/docs/maintainer/qwen4-exp-model.md)
History

528 lines (459 loc) · 35.2 KB

/

qwen4-exp-model.md
==================

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


528 lines (459 loc) · 35.2 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/docs/maintainer/qwen4-exp-model.md)

Copy raw file

Download raw file

You must be signed in to make or propose changes

More edit options

Outline

Edit and raw actions

Qwen3.8-Flash-Next: model mathematics
=====================================

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md#qwen38-flash-next-model-mathematics)

*   **Target:** HF `Qwen/Qwen3.8-Flash-Next`, `architectures = ["Qwen4ExpForConditionalGeneration"]`, `model_type = "qwen4_exp"` (text `qwen4_exp_text`), checkpoint revision `de4b8e4d43b917e7706784d8bb445c9af86a3540`.
*   **Implementation:** `src/models/qwen4_exp/` and the Engine core `src/runtime/engine/qwen4_exp_core.*`; the FP64 reference forward of the text path is `tools/reference/qwen4_exp.py`. Commands, options and measurements are in [the product guide](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)
    .
*   **Authority order for the mathematics** (highest first):
    1.  transformers `models/qwen4_exp` (PR #48337), the modular file and the generated modeling file - the only executable reference written by the model's owners' partners;
    2.  vLLM `qwen4_exp` (PR #53896, the NVIDIA path) for MTP (transformers has no MTP) and for fused-kernel semantics;
    3.  llama.cpp PR #27742 (arch `qwen4exp`) for the GGUF names and the GGUF-side hash;
    4.  [Strata](https://github.com/Niko1221/Strata)
         (MIT) for an independently validated CUDA transcription and its pitfalls list. Where they disagree this document says so and follows (1).
*   **Abbreviations:** `H` = 2560 hidden, `HC` = 4 streams, `R` = the residual stack `(HC, H)`, `LR` = 320, `E` = 512 experts, `K` = 10 routed per token, `I` = 640 expert width, `T` = tokens in a step (1 decode, ≤ 16 verify, chunk for prefill).

Implementation status
---------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md#implementation-status)

Everything the product guide describes runs through the public Engine: the text path with its PLE n-gram table (stored in the model or in a table artifact of its own), GGUF block banks imported without requantization, expert residency on the device, in pinned host memory or in the artifact's files, up to eight concurrent requests, the context cache with host and disk images, structured output, token log probabilities, Vision, and MTP from Unsloth's shared GGUF block.

The qualification contract: every Op against an independent FP64 oracle; exact repetition with the execution configuration fixed; exact restore of a context image for the same computation history and execution profile. Verification width, prefill partition and batch composition change reductions and can flip a near-tied argmax, so differences between plain and MTP decoding or between batch compositions are reported, not required to be zero. A split over two RTX 3090s matched one RTX A6000 through the first end-of-sequence token, and every token at 128K; past that token the outputs of the two hosts differ, with different drivers and route profiles, for a reason not established.

Built and kept experimental, not published:

*   the native Q2 recipe (`qwen3_8_flash_next_gsq_q2`): +0.26% held-out perplexity against the GGUF artifact and slower scoring;
*   the HF-source Q4/Q5 recipe (`qwen3_8_flash_next`), whose full-model quality is unmeasured, and the FP8 n-gram table, rejected for its 80% larger rows.

DFlash2 drafts from the optional `dflash2` component ([DFlash and DFlash2](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/dflash.md#qwen38-flash-next)
). Not supported: DFlash (PixelML's NVFP4 DFlash drafter is a research artifact for vLLM), n-gram copy proposals (`--ngram-draft-tokens`), `--lm-head-draft`, `--mtp-attention-window`, disk residency of native banks. The Windows paths have not been run.

* * *

1\. Forward mathematics
-----------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md#1-forward-mathematics)

### 1.0 Config fields that matter (text\_config) and their derived values

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md#10-config-fields-that-matter-text_config-and-their-derived-values)

| field | value | used by |
| --- | --- | --- |
| `hidden_size` | 2560 | everything |
| `num_hidden_layers` | 48  | `layer_types` = `[lin, lin, lin, full] x 12` (`full_attention_interval` 4): layers 3,7,...,47 are QSA, the other 36 GDN |
| `vocab_size` | 248320 | embed, head, n-gram hash (multiplier bound) |
| `tie_word_embeddings` | **false** | separate `lm_head.weight` |
| `rms_norm_eps` | 1e-6 | all norms |
| `hc_count`, `hc_lowrank` | 4, 320 | hyper-connections |
| `linear_num_key_heads`, `linear_num_value_heads` | 16, 48 | GDN (GQA ratio 3, `repeat_interleave`) |
| `linear_key_head_dim`, `linear_value_head_dim` | 128, 128 | GDN |
| `linear_conv_kernel_dim` | 4   | GDN causal conv |
| `output_gate_type` | `"sigmoid"` | **GDN gated norm activation** (Qwen3.5 uses SiLU here) |
| `mamba_ssm_dtype` | float32 | GDN recurrent state |
| `num_attention_heads`, `num_key_value_heads`, `head_dim` | 24, 2, 256 | QSA main attention |
| `partial_rotary_factor` | 0.25 | rotary dim 64 of 256 |
| `rope_parameters` | theta 1e7, `mrope_section [11,11,10]`, `mrope_interleaved true` | QSA + indexer |
| `indexer_n_heads`, `indexer_kv_heads`, `indexer_head_dim` | 4, 1, 128 | QSA indexer |
| `indexer_compress_ratio`, `indexer_budget` | 4, 2048 | block = 4 tokens; `block_topk` = 512 blocks |
| `num_experts`, `num_experts_per_tok`, `norm_topk_prob` | 512, 10, true (class default) | router |
| `moe_intermediate_size`, `shared_expert_intermediate_size` | 640, 640 | experts |
| `ple_layer_ids` | \[2\] (**one-indexed**) | PLE on `layer_idx = 1` (GGUF `blk.1`) |
| `ple_embed_dim` | 2560 | 16 heads x 160 |
| `ngram_size`, `heads_per_ngram` | 3, 8 | 16 hash heads (8 bigram + 8 trigram) |
| `ngram_vocab_size_base`, `make_ngram_vocab_size_divisible_by` | 20,000,000, 128 | table rows 320,001,536 |
| `split_ngram_parts` | 128 | checkpoint stores the table as 128 row shards of 2,500,012 rows |
| `ple_conv_kernel_size` | 4 (dilation = `ngram_size` = 3) | PLE conv, history 9 tokens |
| `seed` | 1234 (class default; not in config.json) | n-gram multipliers |
| `eos_token_id` | 248044 (endoftext) | **n-gram cut token**. Note: chat turns end with im\_end 248046, which does NOT cut |
| `mtp.num_hidden_layers`, `mtp.layer_types`, `mtp.rope_theta` | 1, `["full_attention"]` (= QSA), 1e7 | MTP |
| `mtp_use_dedicated_embeddings` | false | MTP shares `embed_tokens` and `lm_head` |
| `max_position_embeddings` | 262144 |     |

All RMSNorm weights of class `Qwen4ExpTextRMSNorm` / `Qwen3_5RMSNorm` / vLLM `GemmaRMSNorm` are **zero-centred**: `y = x * rsqrt(mean(x^2) + eps) * (1 + w)`, computed in FP32. The GDN gated norm (`linear_attn.norm.weight`) is the exception: plain `w` (initialised to ones), as in Qwen3.5. A loader that folds `1 + w` once must do it for exactly the zero-centred class and not for `linear_attn.norm`.

**There is no final `model.norm`.** The index has no `model.language_model.norm.weight`; the final `hyper_connection_mixer` (with its own `hc_norm`) is the last op before `lm_head`.

### 1.1 Tensor census (from the 131 safetensors headers; all BF16 unless noted)

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md#11-tensor-census-from-the-131-safetensors-headers-all-bf16-unless-noted)

Prefix `L.` = `model.language_model.`; `{l}` = layer; `{s}` = 0..127.

```

</details>

## Assistant · #56

<details><summary>Reasoning · 2,145 characters</summary>

This is useful: NInfer implementation status: DFlash2 etc; authority includes Strata. Also says FP8 n-gram table rejected for 80% larger rows. Shockem uses Q8 PLE (FP8? Q8_0 rows 160 bytes? Actually Q8_0 type per_layer_token_embd [160,320001536] 54.4GB; IQ4_NL row 90 bytes; Q8_0 row 160? The table shape [160,320001536] Q8_0 = 54.4GB; IQ4_NL row 90 bytes = 28.8GB. Q8_0 blocks: 32 values per block with fp16 scale -> 34 bytes? For 160 values = 5 blocks 170 bytes? But reported 54,400,261,120 / 320,001,536 = 170 bytes exactly? Yes. IQ4_NL 90 bytes. 170/90 = 1.889 (89% larger). NInfer docs says FP8 table rejected for 80% larger rows? Edge0 FP8 row 162 bytes vs IQ4 90 = 80% larger. Q8_0 170 is 89% larger. Shockem uses Q8_0 not FP8. NInfer supports Edge0 FP8 table, but Flash-Next n-gram artifacts published IQ4_NL. NInfer can read any table of shape and row format, including FP8, maybe Q8_0? It says any row format? Edge0 FP8 E4M3 row_interleaved; maybe can read any table of model shape in any row format. Could it read a Q8_0 PLE table converted to .ninfer? Possibly, if recipe supports Q8_0 GGUF block table. The model can read any table of model's shape in any row format? Docs say "in any row format" but component config specifies row format? "accepts any table of the model's shape, in any row format". So yes, could make .ninfer ngram table from Q8_0 source. But size.

Need understand Basalt PLE Q8 table: It stores `per_layer_token_embd.weight` shape [160,320001536], Q8_0. NInfer stores ngram rows separately, 320,001,536 rows of 160 values. Row format: IQ4_NL blocks 90 bytes. Q8_0 row 170 bytes. Why Shockem uses Q8_0? Better quality maybe. Basalt model card: after conversion ngram was IQ4_NL 26.8GiB, replaced with Q8_0 table 54.4GiB copied byte for byte. The previous version 1 file 112.78GB. Official Basalt? Shockem's model includes Q8 PLE. The recognized WaveCut is not Flash Next but 27B, so 14GB. Need clearly compare apples-to-apples.

Need maybe inspect Shockem previous pack? The card says official IQ3_S pack? It references Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt. Could compare file sizes? Let's scrape that.


</details>

<details><summary>Tool request · web_scrape · call_b6c9b17bf3a74ceeadc37b5c</summary>

```json
{
  "url": "https://huggingface.co/Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt"
}
```

</details>


<details><summary>Tool result · web_scrape · call_b6c9b17bf3a74ceeadc37b5c</summary>

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt#qwen38-flash-next-gsq-rco-iq3_s-q8-n-gram)
Qwen3.8-Flash-Next GSQ-RCO IQ3\_S, Q8 n-gram
=======================================================================================================================================================================

One `.basalt` file for [Basalt](https://github.com/jesdga95/basalt)
. It is the official GSQ-RCO IQ3\_S pack with a single tensor replaced.

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt#what-changed)
What changed
----------------------------------------------------------------------------------------------------------

`per_layer_token_embd.weight`, the per-layer n-gram table (320,001,536 rows × 160), is the Q8\_0 table from the official NVIDIA NVFP4 Basalt pack, copied byte for byte.

The official IQ3\_S pack stores that same table as IQ4\_NL: 26.8 GiB, 90 bytes per row. This file stores it as Q8\_0: 50.7 GiB, 170 bytes per row. A 48-row dequant comparison of the two encodings scored cosine 0.997 (about 8% rms), which is the 4-bit error. Ten Q8 rows in this file, including the first and the last, were checked byte-identical to the NVFP4 source.

Everything else is the official IQ3\_S pack, copied with matching section hashes:

*   routed experts, 46.84 GiB, GSQ-RCO IQ3\_S
*   dense pool, self-distilled MTP drafter, vision projector, tokenizer

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt#file-format)
File format
--------------------------------------------------------------------------------------------------------

Basalt 0.2.0 reads `.basalt` version 2 and refuses version 1. This file was migrated from the previous upload with `tools/migrations/basalt_v1_to_v2.py`. Every weight section was copied byte for byte (the script checks each section's SHA-256 against the source table). The `profile` section is gone; the engine ships that placement in `data/profiles`. The `hc8` section is the int8 hyper-connection table the engine used to build on every start, stored in the file. File size: 113,245,914,374 bytes (105.5 GiB). The previous version-1 file was 112,534,980,259 bytes.

Widening the n-gram table does not change expert spill. Basalt already reads Q8\_0 n-gram rows; that is the format the official NVFP4 pack ships. Each token reads 16 rows, so the extra traffic is 80 bytes per row.

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt#run)
Run
----------------------------------------------------------------------------------------

    hf download Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE.basalt


Point Basalt's `server.model` at that file. The pack carries no engine flags.

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt#context-for-the-expert-quant)
Context for the expert quant
------------------------------------------------------------------------------------------------------------------------------------------

On a 3× RTX 5060 Ti 16 GB box with a 37 GiB expert RAM budget, the unmodified IQ3\_S pack spills 1.3 GiB of experts (3%). The official NVFP4 pack spills 18.1 GiB (29%) and decodes much slower. Those measurements used the IQ4\_NL n-gram. This file was not re-benched; a short completion did load and answer after the splice.

|     | NVFP4 | IQ3\_S, IQ4 n-gram |
| --- | --- | --- |
| expert spill at 37 GiB | 18.1 GiB (29%) | 1.3 GiB (3%) |
| decode prose / code | 55.3 / 54.2 tok/s | 83.7 / 90.2 |
| prefill 32k / 128k | 2646 / 2491 | 2414 / 2301 |
| hard harness, 14 tests × 3 | 104 s | 35 s, both 14/14 |

Upstream quality of the official IQ3\_S pack against a Q8\_0 reference, 100 wikitext chunks: KLD 0.1547, top-1 agreement 87.25%. Official NVFP4: KLD 0.0680, top-1 91.46%. KLD is distance from that reference, not a task score. The experts here are still IQ3\_S, so most of that gap remains. The n-gram table is the part that now matches NVFP4.

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt#sources)
Sources
------------------------------------------------------------------------------------------------

*   Pack, aside from the n-gram table: [jesdga/Qwen3.8-Flash-Next-Basalt](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt)
     `Qwen3.8-FN-GSQ-RCO-IQ3_S.basalt`, from [ISTA-DASLab GSQ-RCO](https://huggingface.co/ISTA-DASLab/Qwen3.8-Flash-Next-GSQ-RCO-GGUF)
    .
*   N-gram table: `per_layer_token_embd.weight` from `Qwen3.8-FN-NVFP4.basalt` in that same repo. NVIDIA's FP8 table, reblocked to Q8\_0.
*   Base model: [Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)
    .
*   Engine: [Basalt](https://github.com/jesdga95/basalt)
    , a fork of [Strata](https://github.com/Niko1221/Strata)
    .

If you use the GSQ-RCO experts, please cite GSQ (arXiv:2604.18556) and RCO (arXiv:2605.00649).

[](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt#license)
License
------------------------------------------------------------------------------------------------

[Qwen Community License 1.0](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt/tree/main/LICENSE)
. The Basalt engine itself is MIT. These weights are not.

Downloads last month

\-

Downloads are not tracked for this model. [How to track](https://huggingface.co/docs/hub/models-download-stats)

Inference Providers [NEW](https://huggingface.co/docs/inference-providers)

This model isn't deployed by any Inference Provider. [🙋 Ask for provider support](https://huggingface.co/spaces/huggingface/InferenceSupport/discussions/new?title=Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt&description=React%20to%20this%20comment%20with%20an%20emoji%20to%20vote%20for%20%5BShockem%2FQwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt%5D(%2FShockem%2FQwen3.8-Flash-Next-GSQ-RCO-IQ3_S-Q8PLE-Basalt)%20to%20be%20supported%20by%20Inference%20Providers.%0A%0A(optional)%20Which%20providers%20are%20you%20interested%20in%3F%20(Novita%2C%20Hyperbolic%2C%20Together%E2%80%A6)%0A)

Model tree for Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3\_S-Q8PLE-Basalt[](https://huggingface.co/docs/hub/model-cards#specifying-a-base-model)

---------------------------------------------------------------------------------------------------------------------------------------------

Base model

[Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)

Finetuned

([129](https://huggingface.co/models?other=base_model:finetune:Qwen/Qwen3.8-Flash-Next)
)

this model

Collection including Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3\_S-Q8PLE-Basalt
---------------------------------------------------------------------------

[My quants for Basalt • 4 items • Updated about 7 hours ago](https://huggingface.co/collections/Shockem/basalt-packages)

Papers for Shockem/Qwen3.8-Flash-Next-GSQ-RCO-IQ3\_S-Q8PLE-Basalt
-----------------------------------------------------------------

[Paper • 2605.00649 • Published May 7 • 15](https://huggingface.co/papers/2605.00649)

[Paper • 2604.18556 • Published Apr 20 • 26](https://huggingface.co/papers/2604.18556)

Inference providers allow you to run inference using different serverless providers.

</details>

## Assistant · #58

<details><summary>Reasoning · 164 characters</summary>

Good.

Need maybe inspect official Basalt Qwen3.8-FN GSQ IQ3_S card for size and components. Could scrape jesdga/Qwen3.8-Flash-Next-Basalt? It may list pack sizes.


</details>

<details><summary>Tool request · web_scrape · call_cb2b09774bf848a4a53153e2</summary>

```json
{
  "url": "https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt"
}
```

</details>


<details><summary>Tool result · web_scrape · call_cb2b09774bf848a4a53153e2</summary>

[![Basalt](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt/resolve/main/assets/basalt-banner.png)](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt/blob/main/assets/basalt-banner.png)

[](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt#the-fastest-inference-engine-for-qwen38-flash-next-on-blackwell)
The fastest inference engine for Qwen3.8-Flash-Next on Blackwell
============================================================================================================================================================================================

Website: [basalt.jgulfo.com](https://basalt.jgulfo.com/)

Model files for [Basalt](https://github.com/jesdga95/basalt)
, a local inference engine for the Qwen3.8-Flash-Next mixture-of-experts model. Basalt runs on Linux with any NVIDIA Blackwell GPU (sm\_120). A second GPU can serve as a peer expert tier, and experts that do not fit in VRAM stay in system RAM. It has an OpenAI- and Anthropic-compatible API.

Each `.basalt` file is self-contained: weights, tokenizer, MTP drafter, vision projector and the int8 hyper-connection table the engine reads at start. The expert profile (which experts start in VRAM) ships with the engine. Expert formats: Unsloth UD quants (IQ1\_S, IQ1\_M, IQ2\_XS, IQ3\_XXS, IQ4\_XS, Q4\_K\_XL, Q5\_K\_XL, Q6\_K\_XL), Q8\_0 and NVIDIA NVFP4.

Files: `Qwen3.8-FN-NVFP4-DQ6_K`, `-NVFP4-DQ8`, `-UD-IQ1_S`, `-UD-IQ1_M`, `-UD-IQ2_XS`, `-UD-IQ3_XXS`, `-UD-IQ4_XS`, `-UD-Q4_K_XL`, `-UD-Q5_K_XL`, `-UD-Q6_K_XL` and `-Q8_0` (each `.basalt`), plus `convert/`.

These are `.basalt` format version 2 files, which Basalt 0.2.0 and later require. Version 2 drops engine policy data from the pack (the expert profile now ships with the engine, so a better one never needs a new download) and stores the int8 hyper-connection table, so the engine no longer rebuilds it at every start. Weights are unchanged and output is identical. Already have a version 1 file? Re-downloading is optional: `python3 tools/migrations/basalt_v1_to_v2.py OLD.basalt NEW.basalt` converts it locally without re-quantizing (needs numpy and room for a second copy). See the [file format changelog](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md)
.

[](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt#speed)
Speed
-----------------------------------------------------------------------

Best measured, single stream, RTX 5090 at 400 W + RTX 5060 Ti peer at 180 W, tokens/s. Numbers move with every release.

| pack | prose | structured | chat |
| --- | --- | --- | --- |
| NVFP4-DQ6\_K | 307 | 601 | 335 |
| UD-IQ3\_XXS | 342 | 658 | 399 |
| UD-IQ4\_XS | 300 | 608 | 363 |
| UD-IQ2\_XS | 345 | 641 | 396 |
| UD-IQ1\_S | 389 | 763 | 457 |
| UD-IQ1\_M | 364 | 732 | 434 |
| Q8\_0 | 112 | 166 | 101 |

[](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt#quality)
Quality
---------------------------------------------------------------------------

Measured with `basalt-bench --quality`: 100 chunks of wikitext-2 (512 tokens each), scored through the decode path against full precision: a llama.cpp BF16 reference of the original model (reference PPL 3.273 on the scored rows). int8 KV, RTX 5090 at 400 W + RTX 5060 Ti at 180 W. Lower KLD and higher top-1 agreement are closer to full precision. PPL is the pack's own perplexity on the same text; it is not a closeness measure. Only the official Basalt packs are listed.

| pack | source | file | experts | PPL | KLD mean | same top-1 |
| --- | --- | --- | --- | --- | --- | --- |
| UD-IQ1\_S | [Unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF) | 65.6 GiB | 31.1 GiB | 3.405 | 0.2676 | 82.76% |
| UD-IQ1\_M | [Unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF) | 67.1 GiB | 32.4 GiB | 3.379 | 0.2560 | 83.19% |
| UD-IQ2\_XS | [Unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF) | 74.4 GiB | 39.4 GiB | 3.289 | 0.1829 | 86.21% |
| UD-IQ3\_XXS | [Unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF) | 81.6 GiB | 46.8 GiB | 3.242 | 0.1188 | 88.67% |
| UD-IQ4\_XS | [Unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF) | 90.9 GiB | 56.2 GiB | 3.231 | 0.0818 | 90.52% |
| UD-Q4\_K\_XL | [Unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF) | 106.7 GiB | 71.7 GiB | 3.321 | 0.0496 | 92.63% |
| NVFP4-DQ6\_K | [NVIDIA](https://huggingface.co/nvidia/Qwen3.8-Flash-Next-NVFP4) | 122.0 GiB | 63.3 GiB | 3.304 | 0.0624 | 91.65% |
| NVFP4-DQ8 | [NVIDIA](https://huggingface.co/nvidia/Qwen3.8-Flash-Next-NVFP4) | 123.3 GiB | 63.3 GiB | 3.297 | 0.0561 | 92.25% |
| UD-Q5\_K\_XL | [Unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF) | 150.5 GiB | 91.6 GiB | 3.293 | 0.0255 | 94.82% |
| UD-Q6\_K\_XL | [Unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF) | 160.6 GiB | 101.7 GiB | 3.283 | 0.0209 | 95.22% |
| Q8\_0 | [Unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF) | 178.3 GiB | 119.5 GiB | 3.279 | 0.0200 | 95.34% |

Both NVFP4 packs keep NVIDIA's NVFP4 experts bit for bit; the head and embedding are Q8\_0. The `D` suffix names the dense projections' format: `Qwen3.8-FN-NVFP4-DQ6_K` stores them as Q6\_K, quantized once from BF16, and `Qwen3.8-FN-NVFP4-DQ8` stores them as Q8\_0, which removes most of the 6-bit pack's measurable rounding (KLD 0.0059 lower; every rounding removed, BF16 dense included, is 0.003 lower still) and decodes about 7% slower on prose and 3% on structured output. Every rounding the engine does is measured in the [precision docs](https://github.com/jesdga95/basalt/blob/main/docs/precision)
.

The UD-IQ1\_S, UD-IQ1\_M, UD-IQ2\_XS, UD-IQ3\_XXS, UD-IQ4\_XS and NVFP4 packs carry a self-distilled MTP layer (`convert/mtp/rt/dense.bin`) for higher draft acceptance; the others keep the original.

[](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt#run)
Run
-------------------------------------------------------------------

Build the engine as described in the [Basalt README](https://github.com/jesdga95/basalt#readme)
, then:

    hf download jesdga/Qwen3.8-Flash-Next-Basalt Qwen3.8-FN-NVFP4-DQ6_K.basalt --local-dir models


`basalt_config.json`:

    {
      "version": 2,
      "models": [{ "model": "models/Qwen3.8-FN-NVFP4-DQ6_K.basalt", "gpu": "0,1", "kv": "int8" }],
      "engine": { "resident-experts": true },
      "server": { "port": 8080 }
    }


    bin/basalt serve --config basalt_config.json


[](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt#conversion-kit)
Conversion kit
-----------------------------------------------------------------------------------------

`convert/` holds the inputs for `tools/convert/convert.py` (MTP layer, vision projector, draft vocabulary), so any GGUF quant of this model can become a `.basalt` file. See [docs/model-file.md](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md)
.

[](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt#sources)
Sources
---------------------------------------------------------------------------

*   **UD quants, Q8\_0**: [unsloth](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF)
    .
*   **NVFP4 experts**: [NVIDIA](https://huggingface.co/nvidia/Qwen3.8-Flash-Next-NVFP4)
    .
*   **MTP drafter**: [Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)
     BF16 MTP tensors.
*   Basalt is a fork of [Strata](https://github.com/Niko1221/Strata)
     (MIT).

[](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt#license)
License
---------------------------------------------------------------------------

All files here are derived from Qwen3.8-Flash-Next and are distributed under the [Qwen Community License 1.0](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt/tree/main/LICENSE)
, whose notice is included in this repository and inside every `.basalt` file. Businesses offering Model as a Service or an AI coding/office assistant need a separate license from Qwen for commercial use, and products above 100M monthly users or US$20M monthly revenue must display the model name. The [LICENSE](https://huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt/tree/main/LICENSE)
 has the binding terms. The Basalt engine itself is MIT.

Downloads last month

\-

Downloads are not tracked for this model. [How to track](https://huggingface.co/docs/hub/models-download-stats)

Inference Providers [NEW](https://huggingface.co/docs/inference-providers)

This model isn't deployed by any Inference Provider. [🙋 Ask for provider support](https://huggingface.co/spaces/huggingface/InferenceSupport/discussions/new?title=jesdga/Qwen3.8-Flash-Next-Basalt&description=React%20to%20this%20comment%20with%20an%20emoji%20to%20vote%20for%20%5Bjesdga%2FQwen3.8-Flash-Next-Basalt%5D(%2Fjesdga%2FQwen3.8-Flash-Next-Basalt)%20to%20be%20supported%20by%20Inference%20Providers.%0A%0A(optional)%20Which%20providers%20are%20you%20interested%20in%3F%20(Novita%2C%20Hyperbolic%2C%20Together%E2%80%A6)%0A)

Model tree for jesdga/Qwen3.8-Flash-Next-Basalt[](https://huggingface.co/docs/hub/model-cards#specifying-a-base-model)

-----------------------------------------------------------------------------------------------------------------------

Base model

[Qwen/Qwen3.8-Flash-Next](https://huggingface.co/Qwen/Qwen3.8-Flash-Next)

Finetuned

([129](https://huggingface.co/models?other=base_model:finetune:Qwen/Qwen3.8-Flash-Next)
)

this model

Finetunes

[1 model](https://huggingface.co/models?other=base_model:finetune:jesdga/Qwen3.8-Flash-Next-Basalt)

Inference providers allow you to run inference using different serverless providers.

</details>

## Assistant · #60

<details><summary>Reasoning · 42,446 characters</summary>

Interesting: official Basalt card lists IQ3_XXS not IQ3_S? It says expert formats Unsloth UD and NVIDIA, but source Shockem says official IQ3_S pack? Maybe official pack has GSQ-RCO IQ3_S not in list? It references `jesdga/Qwen3.8-Flash-Next-Basalt Qwen3.8-FN-GSQ-RCO-IQ3_S.basalt`. Card omitted? Maybe not official? Shockem says official IQ3_S pack, but README card lists file? It says files ... not GSQ. Maybe hidden. But enough.

Need maybe inspect ninfer-all artifact "Qwen3.8-Flash-Next GSQ-RCO IQ3_S" includes DFlash2, MTP, vision. Basalt pack includes self-distilled MTP, vision, tokenizer, hc8, ngram, no DFlash2. Basalt also has expert layout expert blobs and dense index, whereas ninfer objects/bindings. Basalt stores GGUF non-expert tensors raw in `gguf` section; experts in separate expert blobs with layout. NInfer stores GGUF blocks as objects, expert-major banks, ngram table component, resources. .basalt version 2 removes profile and requires hc8; NInfer stores hyperconnections Q8_0 too. Both keep GGUF block bytes for experts and non-experts, but metadata/layout differ.

Need maybe compare "batched inference" concurrency: Basalt `--parallel` 1–8, shared context per slot, checkpoints, session affinity. NInfer up to eight concurrent requests, prefix cache, host/disk experts, typed decisions. But size not concurrency.

Need maybe answer "how far off are the ports" with categories:
1. Model/architecture front: close / substantially aligned. Both implement Qwen4Exp / qwen4exp Flash-Next: 48 layers 36 GDN + 12 QSA, H=2560, HC=4, 512 experts top-10, PLE n-gram 320,001,536 rows x 160 values, 16 heads, 2/3-gram hash, MTP, vision. Both derive from llama.cpp GGUF names/Strata validation. NInfer's docs explicitly use Strata as reference and llama.cpp arch `qwen4exp`. Basalt is fork of Strata, same architecture front. So they are not different model types.
2. Artifact/container: completely different. `.basalt` = BASALTMF version 2 fixed 64KiB header + section table with SHA256, sections 2MiB aligned, opaque sections: meta, tokenizer/*, dense, dense.index, experts, experts.layout, gguf, engram (for DeepSeek), mtp/*, hc8, vision/*. Version 2 removed profile, added hc8. `.ninfer` v3 = magic NINFER + JSON manifest, objects with id/shape/format/layout/offset/bytes, bindings/uses, components, resources; can shard; objects 256B aligned, payload logical; supports formats gguf_blocks_v1, row_split, NVFP4, FP8 row etc. So no direct load cross-engine.
3. Weight representation: both preserve GGUF blocks byte-for-byte for GGUF sources, but:
   - NInfer hyper-connection matrices are stored as Q8_0 (for Flash-Next) and separate from GGUF source BF16 re-quantized; Basalt stores `hc8` int8 copies (fp16 scale per 32) in file required.
   - NInfer n-gram table may be separate table artifact and named by hash constants/digest; Basalt embeds PLE in `gguf` section as raw tensor `per_layer_token_embd.weight` and no separate table policy.
   - Basalt profile moved to engine; NInfer may embed ngram hot profile or table residency options.
   - Basalt pack stores GGUF metadata and tokenizer inside, no engine flags. NInfer stores config, bindings, resources and optional proposal/DFlash2.
   - Basalt self-distilled MTP; NInfer uses Unsloth shared-Q8_0 MTP or DFlash2; NInfer supports DFlash2 on Flash-Next, Basalt docs for Flash-Next uses MTP and suffix draft, no DFlash2? Basalt model docs says Flash-Next drafting MTP only; DeepSeek DSpark, 27B DFlash2. NInfer Flash-Next has DFlash2. So feature ports differ.
   - NInfer may keep some formats native/FP8/NVFP4 for other models, but for Flash-Next GGUF blocks.
4. Runtime/kernel semantic differences: Both use q8_1 activations for GGUF products? Basalt precision doc says decode int8 q8_1, prefill fp16/BF16 GEMM/MMQ/FP4; NInfer says product quantizes BF16 activation to q8_1, prefill uses llama.cpp mul_mat_q integer tensor-core for prompts; NInfer applies i-quant scales in FP32 where llama.cpp vector kernels round integer rescale, causing last-bit differences. Basalt has exact decode drafting, two-stage head approximate tail, expert tier CPU rounding, route flags. NInfer has MTP/DFlash2, exact target decisions. Numerically similar but not bit-identical across engines. Need not claim too much.
5. Feature port delta: NInfer-all master supports many model families and decision APIs; Basalt supports three model families and Blackwell sm_120 only, no decisions? Upstream Basalt README endpoints OpenAI/Anthropic, no typed decisions. decisive-ninfer branch had decision engine but Qwen4Exp inference runs without --jev. ninfer-all master now has `/v1/decisions` and `/v1/systemone` across families, including Flash-Next (PR #370 confirms Flash-Next decision reads with MTP). So decision port in ninfer-all is ahead of your branch; Basalt upstream lacks it. If your decisive-basalt framework adds decision handling around Basalt, it is outside the upstream engine's model format. Need maybe caveat private repo not public.

6. Size comparison:
- Shockem abliterated Q8PLE .basalt: 113,491,281,169 B = 105.7 GiB.
- WaveCut Qwen3.8-27B NInfer: 15,017,456,896 B = 13.99 GiB.
Different model: 27B dense vs 125B MoE Flash-Next. Not fair.
- Apples-to-apples: WaveCut Flash-Next IQ3_S NInfer: 58,242,390,528 B = 54.24 GiB + separate IQ4_NL table 28,905,035,512 B = 26.92 GiB => 87,147,426,040 B = 81.16 GiB.
- Shockem (non-abliterated base Q8PLE): 113,245,914,374 B = 105.5 GiB; abliterated: 113,491,281,169 B = 105.7 GiB (about 245 MB larger? difference 245,366,795? Let's calculate: 113,491,281,169 - 113,245,914,374 = 245,366,795 bytes = 234 MiB. The abliterated transplant of 144 residual-write tensors maybe increases dense pool by 234 MiB due requant? Good.)
- Difference between Shockem Q8PLE and self-contained NInfer with IQ4 table: 113,491,281,169 - 87,147,426,040 = 26,343,855,129 B = 24.53 GiB. This is almost exactly ngram table row format: Q8_0 54.4GB vs IQ4_NL 26.92GB = 25.48GB, plus Basalt has MTP/vision/hc8 etc and NInfer has DFlash2. Wait difference expected: table delta = 54.4 - 26.92 = 27.48GB? Actually NInfer table 26.92GiB = 28.905GB, Q8 table 54.400GB = 50.67GiB. Delta 21.75GiB? Need units carefully. HF card: IQ4_NL 26.8 GiB (28.9GB), Q8_0 50.7 GiB (54.4GB). Delta 23.9 GiB (25.5GB). Shockem total 105.5GiB. Official IQ3_S Basalt with IQ4 ngram? It says file previous version-1 112.5GB? Wait official IQ3_S pack file maybe? Shockem file with IQ4 table was 112.53GB v1; after Q8 table 113.25GB v2? Difference 710MB only? Wait confusion. Let's parse.

Shockem Q8PLE card: file size 113,245,914,374 bytes (105.5 GiB). Previous v1 file was 112,534,980,259 (104.8GiB). It says official IQ3_S pack stores table IQ4_NL 26.8GiB, this file stores Q8_0 50.7GiB. Everything else official IQ3_S pack. So if official IQ3_S pack size? Should be 105.5 - (50.7 - 26.8) = 81.6 GiB (87.6GB). That's same as NInfer total 81.16 GiB. Good. The v1/v2 difference not relevant. The current abliterated file 105.7 GiB. Self-contained NInfer IQ4 total 81.16 GiB. Difference 24.5 GiB, close to table delta 23.9 GiB plus ~0.6 GiB components/dense differences. Good.

But if NInfer could make a Q8_0 table artifact, total would be 54.24 + 50.7 = 104.94 GiB, close to Shockem 105.5/105.7. Need mention: NInfer can read different table shapes/row formats (from commit 57395b20b) and Edge0 FP8 table; it may support Q8_0 PLE rows if converted as GGUF blocks? It says any row format, but official artifacts don't publish Q8 table. However, NInfer's model names table format? "accepts any table of the model's shape, in any row format". If row format Q8_0, yes. So if you convert Q8 PLE table, NInfer size would be ~105GiB too. But if using official IQ4 table, size difference is 24.5GiB.

Need maybe discuss "both .basalt artifacts and .ninfer artifacts unified along front of Flash Next's model type". Maybe they expect: The ports are not "off" by 100GB; the 100GB is an artifact of comparing a full self-contained Q8 PLE Flash-Next pack to a 14GB dense Qwen3.8-27B artifact. For same quant, the ports differ only in PLE table representation plus engine-specific components. The model front is basically the same. Need be direct.

Need maybe check Shockem HF files to see exact file name and size. We have.

Need maybe inspect WaveCut Qwen3.8-Flash-Next Q2_0 size? Not needed.

Potential issue: User says "ninfer-all recently added nearly all of Strata and its model types" and "ninfer-all has formerly *also* merged strata". Maybe they think ninfer-all's engine recognized WaveCut .ninfer, not Shockem .basalt. Need maybe inspect "formerly ninfer-all"? Could be old repo? They say "formerly ninfer-all" maybe the project formerly Ninfer-all? The README says NInfer-all continues NInfer. We can mention current master as of Nov 16 2026. Basalt latest v0.4.1 Nov 16 2026. Both very fresh.

Need maybe use citations inline. We can cite URLs. Since final answer oververbosity 9, include detailed table.

Need maybe produce "review" structure:
- Bottom line
- What I reviewed (dates, versions)
- Apples-to-apples sizes
- Format delta table
- Model semantics delta
- Decision framework delta
- Why your two HF repos differ by ~92 GiB (or 100+GB)
- "How far off" verdict with scores: architecture front ~aligned, container ~completely separate, weight payload ~same source but different packaging, feature set ~diverged, practical portability ~need offline conversion, not direct checkpoint sharing.
- What to do: If want serve Shockem model under ninfer-all, don't compare to WaveCut 27B; use WaveCut Flash-Next IQ3_S + ngram table or convert SC117 abliterated IQ3_S GGUF to .ninfer. Use recipe qwen3_8_flash_next_gguf with --source gguf=SC117..., ngram=..., vision=mmproj, mtp=shared-Q8_0, components text,vision,mtp,dflash2 optional, --ngram-table. Need include exact command. For Q8PLE, convert ngram table separately from Q8_0 source. Need caution: NInfer's converter expects source GGUF first shard and ngram second shard; SC117 repo transplants residual tensors into IQ3_S, if metadata/arch matches, likely. The card says shard 2 stock PLE. It may use same GGUF names. Need mention official GSQ-RCO GGUF lacks MTP; supply Unsloth MTP. Basalt pack has MTP but NInfer cannot ingest .basalt. Need maybe state: Ninfer-all recognizes .ninfer only; it will not open .basalt; it recognizes WaveCut .ninfer because that's a converted artifact. If you want engine to serve current model, convert from GGUF source to .ninfer, not from .basalt. Could maybe Basalt conversion kit convert .basalt back? No. NInfer converter from GGUF/safetensors.

Need maybe provide exact expected .ninfer size:
- If using IQ4_NL table: 54.24 + 26.92 = 81.16 GiB (two files)
- If using Q8_0 PLE: 54.24 + 50.7 = 104.94 GiB (plus table maybe hot profile 0.1GiB). That matches Shockem.
- If self-contained one file maybe 105-ish. If without DFlash2 maybe -0.34GiB.
- If Qwen3.8-27B 13.99GiB dense is not relevant.

Need maybe compute exact byte table:
Shockem abliterated: 113,491,281,169 bytes / 1024^3 = 105.7 GiB.
WaveCut 27B: 15,017,456,896 = 13.99GiB.
Delta = 98,473,824,273 bytes = 91.7 GiB? User says 100+GB; in decimal 98.5GB, in GiB 91.7. They likely mean 100+GB file vs 14GB (difference ~99.5GB? 105.7-14=91.7 GiB = 98.5 GB decimal). Could say ~92GiB / ~98GB.
WaveCut Flash-Next IQ3_S + IQ4 table = 87,147,426,040 = 81.16 GiB. Delta to Shockem 26,343,855,129 = 24.53 GiB.
WaveCut Flash-Next alone = 58,242,390,528 = 54.24GiB. Delta vs Shockem 55,248,890,641 = 51.46GiB but missing table.
Shockem PLE Q8 54,400,261,120 = 50.67GiB; NInfer IQ4 table 28,905,035,512 = 26.92GiB; delta 25,495,225,608 = 23.74GiB.
Abliterated vs Shockem Q8PLE base: +245,366,795 bytes = 234MiB.
NInfer Flash-Next IQ3_S 54.24 includes DFlash2 339,417,600 bytes (0.32GiB) and MTP 2.79GB (2.6GiB) maybe. Basalt pack includes self-distilled MTP. Need not.

Need maybe check if WaveCut 27B artifact is Qwen3.8-27B not Flash Next. Its architecture Qwen3.5 Dense? It has GDN controls, output head, token table, MTP, DFlash2. Model ID `qwen3.8-27b`. Basalt also supports Qwen3.8-27B with different pack `Qwen3.8-27B-QUASAR-NVFP4` 19.7GiB. Could compare Basalt 27B vs NInfer 27B: Basalt QUASAR pack 19.7GiB vs NInfer GSQ 13.99GiB; both dense but different quantization (NVFP4 vs IQ3_S GGUF). But user's current model is Flash Next. Might mention for completeness: For the same 27B model type, Basalt's public pack is NVFP4/QUASAR 19.7 GiB; NInfer's GSQ IQ3_S artifact is 14 GiB, so size can still differ by quantization format. But not needed maybe.

Need maybe discuss "basalt is fork of strata" and "ninfer-all merged strata". NInfer's model doc authority includes Strata as validated CUDA transcription but not as direct fork. Basalt is fork of Strata, likely retains Strata's approach to model formats? NInfer-all "merged" Strata's model types, not its container. Need be careful: "merged Strata" could mean code merge? README says continues NInfer and carries work of several forks; CONTRIBUTORS credits. It may have merged Strata model types. But file format remains NInfer v3. So model type support and container support are distinct.

Need maybe inspect CONTRIBUTORS to confirm Strata? Could but not necessary. Could mention docs say Strata is reference, not runtime format.

Need maybe mention upstream Basalt release 0.4.1 says .basalt format stays version 2; Shockem pack migrated to v2. NInfer artifacts v3. These are independent versioning systems; version numbers do not align. Basalt 0.4.1 Nov 16 2026; NInfer-all master a317194 Nov 16 2026. Both latest.

Need maybe maybe include exact magic bytes: `.basalt` header magic `BASALTMF` version 2, 64KiB header, section table, SHA256, 2MiB align; `.ninfer` magic `NINFER\0\03`, 32-byte header + JSON manifest, 4KiB payload start, object offsets. This is valuable.

Need maybe mention Basalt sections vs NInfer components:
- .basalt `meta` JSON with GGUF metadata, tensor index, sources, license.
- .ninfer JSON root with components/objects/bindings/uses/files/metadata/provenance. Basalt does not expose bindings/uses; engine has hard-coded section names.
- .basalt `experts.layout` text v3/v5/v6/v7; NInfer uses object bindings and expert-major banks with formats.
- .basalt `gguf` raw non-expert tensors 4KiB aligned; NInfer objects may be GGUF blocks and resources.
- .basalt `hc8` required; NInfer stores HC matrices as Q8_0 tensor objects (not necessarily named hc8? likely yes maybe component). It has Q8_0 hyperconnection projections.
- .basalt `profile` removed from file in v2; NInfer ngram hot profile can be embedded/resource or engine option.
- .basalt `vision/mmproj` whole GGUF; NInfer vision component decoded into objects, may store tower.
- .basalt `mtp/dense` etc runtime directory; NInfer mtp component objects/bindings.
- .basalt `dspark/gguf` whole GGUF for DeepSeek; NInfer dspark drafter objects (or STQ encoding) and DFlash2 components.
- .ninfer supports part files/shards; .basalt single file.

Need maybe mention .basalt is closer to raw GGUF section archive; .ninfer is a typed object graph with bindings. Both preserve quant blocks but different runtime contracts.

Need maybe mention "front unified" but "backend ports diverged". How far off? Could say:
- Architecture graph: 0 model-type drift for Flash-Next (both qwen4exp); same geometry and table constants.
- Byte-compatible weights: no, not across extensions; GGUF blocks are the only common ground.
- Artifact compatibility: 0%, no shared loader; `.ninfer` cannot be opened by Basalt and `.basalt` cannot be opened by NInfer.
- Feature parity: NInfer-all ahead on Flash-Next DFlash2, DSpine, decisions, broader GPU support; Basalt ahead on Blackwell-specific expert tiering, adaptive routing, exact drafting, conversation cache, sleep, 27B two-card features.
- Practical artifact size: not a port issue; choose comparable quant and PLE format.

Need maybe mention "batched inference" and "batch slots": Basalt's 100+GB .basalt is one file; NInfer recognizes .ninfer; if engine sees WaveCut 27B it's serving different model. Batched inference through `.basalt` checkpoints means if using Basalt, the checkpoints are packs. NInfer artifact recognized is v3, not checkpoint of same model. Need maybe answer "where artifacts are different (if at all)": They differ in container and metadata; the underlying quantized blocks are same for GGUF-derived Flash-Next. The Shockem pack differs from official NInfer in PLE row format (Q8_0 vs IQ4_NL) and abliterated residual tensors. The 27B artifact differs model type and quantization.

Need maybe mention "SC117 abliterated transplant" changes only 144 residual-write tensors and does not touch PLE; size change small. The NInfer conversion from SC117 should not change expert size; it would be similar to WaveCut Flash-Next IQ3_S. But if NInfer has not published abliterated Flash-Next, no recognized artifact. Could create.

Need maybe inspect if ninfer-all recipe supports GGUF with mixed per-tensor types; yes. Could maybe mention `--recipe qwen3_8_flash_next_gguf` and `--components text,vision,mtp,dflash2`? Does Flash-Next recipe accept dflash2? Published artifact includes DFlash2; docs weight conversion recipe says MTP from MTP GGUF, but not dflash2 in recipe table? Model card says includes DFlash2 drafter; conversion command originally text,vision then MTP attachment, DFlash2 attachment. Could convert with `--components text,vision,mtp` and attach DFlash2 maybe. The docs show `--components text,vision,mtp` and later DFlash2 attachment. For user command maybe use text,vision,mtp; dflash2 if available. It supports `--source dflash2`? For 27B conversion used dflash2 source. For Flash-Next maybe maybe supports source dflash2? Not sure. The docs for Flash-Next conversion only show text,vision,mtp; later DFlash2 attachment separate. Could say `--components text,vision,mtp` (add DFlash2 only with the supported attachment path/source). Need not exact.

Need maybe include conversion command for SC117:
```
python3 -m tools.convert --model Qwen3.8-Flash-Next \
  --recipe qwen3_8_flash_next_gguf --components text,vision,mtp \
  --source gguf=Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-00001-of-00002.gguf \
  --source ngram=...00002-of-00002.gguf \
  --source vision=mmproj-Qwen3.8-Flash-Next-BF16.gguf \
  --source mtp=mtp-Qwen3.8-Flash-Next-shared-Q8_0.gguf \
  --device cpu --rows-per-chunk 65536 --name qwen3.8-flash-next-abliterated \
  --out ...ninfer
```
Then ngram table either text,ngram self-contained or table artifact. For Q8 PLE, source ngram from Q8_0 table shard? The SC117 repo second shard stock IQ4_NL, not Q8. Shockem Q8 table came from NVIDIA NVFP4 Basalt pack, not GGUF. To make Q8 .ninfer, need source table with Q8_0 rows; maybe NVIDIA FP8 table reblocked? NInfer Edge0 FP8 table supported. But Q8_0 rows in GGUF? NInfer supports Q8_0 blocks. Could convert a GGUF tensor with Q8_0 if source. Need caution.

Need maybe mention NInfer's table naming by digest: if you replace IQ4 rows with Q8 rows, the model's ngram component digest/hash constants? It names table by row SHA? For any table of shape, warns if not named. A new Q8 table would need model converted with that table source or use `--ngram-table`; NInfer can read different row format but if model's component records digest of IQ4 rows maybe mismatch but accepted with warning. Better convert model with same ngram source.

Need maybe mention `WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3` is the recognized Flash-Next artifact, not `WaveCut/Qwen3.8-27B...`. If user wants engine to recognize model "along front of Flash Next", use that plus ngram table. It is still not abliterated/Q8PLE but same base quant.

Need maybe maybe include "stock NInfer builds refuse" and minimum commits:
- Qwen3.8-27B GGUF artifact: requires ninfer-all master commit 8706bfc0.
- Flash-Next model artifact: commit 5395ec30b; DFlash2 Nov 4 commit b6e22a9c0; Q8_0 hyperconnections commit 944811b5c. Any ngram table shape commit 57395b20b / Nov 13 504fa8a? Current master after these supports. This reinforces ports are recent and explicit.
- Basalt reads .basalt version 2; Basalt 0.2.0+; latest 0.4.1. Version 1 migration.

Need maybe include dates: Basalt 0.4.1 Nov 16 2026; NInfer-all master Nov 16 2026; docs updated Nov 16/17. Mid-Nov 2026. Good.

Potential user expects maybe review "both upstream basalt and then formerly ninfer-all" and answer maybe "no, .ninfer artifacts are not different from Basalt framework except container; the size difference is due Q8PLE and model mismatch." Need be assertive.

Need maybe maybe mention "basalt's framework" as "upstream basalt" vs user's "decisive-basalt". Could say upstream Basalt has no public decision API in README/docs (as of 0.4.1), so decision framework is not part of upstream `.basalt` artifact. The decision framework lives in server/protocol layer, not in checkpoint container; therefore artifact differences are unrelated to decision port. Ninfer-all has ported/expanded it into native `/v1/decisions` and `/v1/systemone`.

Need maybe verify upstream basalt no decisions. README says OpenAI and Anthropic APIs; docs maybe no decision. Could search basalt docs "decision". Use web_scrape GitHub code search? Could not sign in maybe. Search public code? `https://github.com/search?q=repo%3Ajesdga95%2Fbasalt+decision&type=code` may require sign-in. But docs likely no. Could avoid absolute: "I did not find a typed-decision endpoint in upstream Basalt's current docs; its docs cover OpenAI/Anthropic, not `/v1/decisions`." Good.

Need maybe maybe compare decision framework branch details:
- decisive-ninfer `feature/parallel-decision` docs: `/v1/decision`, `/decision`, `/v1/systemone` require `--jev`, supports Qwen3.5 Dense/MoE incl Qwen3.8-27B; Qwen4Exp runs without `--jev`.
- ninfer-all PR #370: `/v1/systemone`, `/v1/decisions` on Qwen3.8-Flash-Next with MTP, fixes stop token and wide-label drafting. So port is beyond branch and now Flash-Next-capable.
- decisive-basalt: no public repo found under Shockem/GitHub search (but may be private/not indexed); if it wraps Basalt, decision layer does not change checkpoint size.

Need maybe maybe mention "my decision framework ported" - acknowledge credit. Need maybe phrase: "Your branch's shape is visible in NInfer-all master: finite schema decisions, System One, probabilities; but the master port changed route names from `/v1/decision` to `/v1/decisions`? It supports more families and fixes Flash-Next reads." Need not overclaim.

Need maybe maybe inspect ninfer-all serving docs to see exact decision endpoints. Could use web_scrape raw and maybe resource_search? Since f62... not in allowed resource_search? The tool enum only a501. But context_read allowed any resource? It can read f62 section. Need find decisions anchor. The section list didn't show decisions. Could open section maybe 18? Hard. Not necessary. PR #370 and README enough.

Need maybe inspect ninfer-all artifact container sections for resources and bindings, but enough. We have section 1/2? Could read section 2 for resources? But final can summarize. Need maybe use context_read to get more exact about .ninfer objects? Already enough.

Need maybe inspect basalt model sections for exact sections? model_format.hpp had all. Good.

Need maybe inspect NInfer storage layout for gguf rows. Enough.

Need maybe maybe inspect Edge0 doc for table shape? Not necessary.

Need maybe maybe inspect `ninfer-all` docs for "Flash-Next n-gram tables" already in README. Good.

Potential final answer style:
```
As of Nov 16/17 2026, after checking jesdga95/basalt@main (v0.4.1), iamwavecut/ninfer-all@master (a317194), Shockem and WaveCut HF cards:
Bottom line: ...
```
Then tables.

Need maybe mention "100+GB" vs "105.7 GiB" unit clarity.
```
Shockem .basalt = 113,491,281,169 bytes = 105.7 GiB.
WaveCut 27B .ninfer = 15,017,456,896 bytes = 13.99 GiB.
These are different model types: Shockem = Qwen3.8-Flash-Next (Qwen4Exp, 125B MoE); WaveCut 27B = Qwen3.8-27B (Qwen3.5-core dense). So 92GiB delta is not a port drift.
```
Then same-model table.

Need maybe compute "official GSQ IQ3_S Basalt with IQ4 table" estimated: Shockem card says everything else official IQ3_S pack; file with Q8 table 105.5; table delta 23.9 => official IQ3_S Basalt ~81.6 GiB. NInfer total 81.16. Difference 0.44GiB. But current abliterated 105.7. Need present "approximately".
Let's compute exact approximate:
Shockem base Q8PLE: 113,245,914,374 bytes = 105.5GiB. Q8 table 54,400,261,120 bytes = 50.67GiB. IQ4 table 28,905,035,512 = 26.92GiB. If swap back: 113,245,914,374 - 54,400,261,120 + 28,905,035,512 = 87,750,688,766 bytes = 81.72GiB. NInfer total 87,147,426,040 = 81.16GiB. Difference 603,262,726 bytes = 0.56GiB. This is likely Basalt vs NInfer component overhead/dense/MTP/hc8/DFlash2. Good. For abliterated: 113,491,281,169 - 54,400,261,120 + 28,905,035,512 = 87,996,055,561 bytes = 81.95GiB; difference vs NInfer 848,629,521 = 0.79GiB. But abliterated experts same size? It adds 234MB. So same IQ4 table equivalent .ninfer would be ~81-82 GiB. Nice.

But wait NInfer artifact 54.24 includes DFlash2 0.32GiB, while Shockem base has no DFlash2. So difference ~0.56GiB includes DFlash2 in NInfer, hc8/profile etc. Good.

Need maybe mention "NInfer can store ngram table either self-contained or separate. Shockem's .basalt stores PLE in file. If you keep NInfer model without table, it looks much smaller but cannot run without the table artifact." Good.

Need maybe mention "The engine recognizes WaveCut Qwen3.8-27B because it was converted with qwen3_8_27b_gguf; it is not a converted Shockem pack. To make engine recognize your model, you need a .ninfer conversion of the abliterated Flash-Next GGUF." Good.

Need maybe mention "If you convert Shockem's .basalt directly, no; the common source is GGUF. Basalt's pack is not a GGUF; it is a BASALTMF section archive. The NInfer converter accepts GGUF shards, HF config/tokenizer, mmproj, MTP GGUF, DFlash2. It does not accept .basalt." Good.

Need maybe mention "Basalt's pack carries tokenizer and chat template; NInfer can also carry resources but may use pinned chat template. Shockem uses Qwen template; NInfer's official artifact uses Qwen chat_template.jinja. For abliterated model, tokenizer/vocab likely same, but verify chat template and sampling defaults." Good.

Need maybe discuss "expert profile": Basalt moved profile to engine; NInfer has device profiles and ngram hot profile. These are runtime policy, not weights. They affect placement/performance but not artifact size much. Basalt profile removed from v2; NInfer hot profile optional 100MB table. Good.

Need maybe discuss "hyperconnections": Both store int8/Q8. Basalt `hc8` required; NInfer Q8_0 hyperconnections. They are not same layout but equivalent compression. Basalt v2 added hc8 to avoid rebuilding; NInfer Oct 9 update stored Q8_0. This is an example of converging weight representation but different container. Good.

Need maybe discuss "MTP drafter": Basalt official packs have self-distilled MTP from Qwen BF16 tensors, maybe tuned `mtp/dense`. NInfer Flash-Next MTP from Unsloth shared-Q8_0; quality/speed may differ. NInfer also DFlash2. So ports are not "identical" at component level. Basalt's `--sections-from` copies MTP/vision sections byte for byte; NInfer attachments also append/replace components. Both use donor packs. Shockem's MTP came from official IQ3_S Basalt pack; NInfer's MTP came from Unsloth shared-Q8_0. If you need exact same drafter, source must be same.

Need maybe discuss "Q8PLE vs IQ4_NL quality": Shockem's Q8 PLE matches NVIDIA NVFP4 table, reduces 4-bit error; NInfer's published IQ4_NL is GGUF rows and smaller. NInfer rejects FP8 table for 80% larger rows but can read other row formats. It does not currently publish a Q8 PLE table. Thus size delta intentional. Good.

Need maybe maybe mention "NInfer's official Qwen3.8-27B GSQ IQ3_S artifact has no routed experts and no PLE; its weights are 10.95GiB resident. Flash-Next has 48 layers * 512 experts and PLE. That's the main size reason." Good.

Need maybe final verdict:
```
Ports are off in packaging, not model type. The model front is unified; the checkpoint back ends are not. The 100GB discrepancy is explained ~24-25GiB by Q8 vs IQ4 PLE and ~92GiB by comparing 27B dense artifact to 125B MoE pack. A properly converted abliterated Flash-Next IQ3_S .ninfer would be ~81-82GiB with IQ4 table or ~105-106GiB with Q8 table, not 14GiB.
```
Maybe phrase "not off by a month of innovation; the artifacts are intentionally different."

Need maybe include sources. Use inline links in Markdown. Final answer with sections. Need ensure no unsupported claim like NInfer can read Q8_0 table? The docs say any row format; but if row format must be supported by engine? It says any row format, example FP8. Q8_0 block is supported GGUF format. likely. We can say "mechanically NInfer can carry GGUF Q8_0 rows and can accept alternate table shapes; the published Flash-Next table is IQ4_NL." Avoid guarantee.

Need maybe include exact command for conversion with `--ngram-table` if table separate. If source Q8PLE not available as GGUF, conversion from .basalt not possible. Could say use original GGUF source, not `.basalt`.

Need maybe mention "model ID alias" not execution: `--model-id` is HTTP alias, does not convert architecture. Good maybe.

Need maybe mention "stock NInfer refuses these files" and "stock NInfer" vs ninfer-all. If user serving ninfer-all engine, need master build from specified commits. Good.

Need maybe mention "Basalt requires sm_120 Blackwell; NInfer-all supports Volta to Blackwell." This is a port difference not artifact but relevant. Since user has 3x RTX 5060 Ti? Basalt docs says Blackwell sm_120; 5060 Ti is Blackwell? maybe sm_120. NInfer supports consumer Blackwell and older. Could mention.

Need maybe maybe discuss "100+GB on Hub side download box only lists GGUF" not relevant.

Need maybe maybe include "Basalt 0.2.0 requires .basalt version 2; Shockem migrated from v1; v1/v2 differences are not weights, just hc8/profile/meta". Good.

Need maybe think if there is any hidden expectation: "Do a review of both upstream basalt and then formerly ninfer-all, and, see where the .ninfer artifacts are different (if at all) from Basalt's framework. The batched inference through .basalt checkpoints - namely the model I currently serve ... differs greatly (100+GB) than the one recognized by the engine ... Thuswise, how far off are the ports, since, both .basalt artifacts (basalt is a fork of strata) and .ninfer artifacts are indeed unified along the front of Flash Next's model type?"

Could they want answer about "port of decision framework" more than model format? Maybe they ask "how far off are the ports" of frameworks? Need include decision ports. Let's elaborate:
- Your decisive-ninfer branch: feature/parallel-decision, 1647 commits; docs says Jev decision backend supports Qwen3.5 Dense/MoE including Qwen3.8-27B; Qwen4Exp inference without --jev. It exposes `/v1/decision`, `/decision`, `/v1/systemone`; finite schema, tree/greedy, probabilities. It is a fork of Neroued/ninfer, not ninfer-all? It has `ninfer-all` branch etc. It was ported into ninfer-all master.
- ninfer-all master: typed decisions available at `/v1/decisions` and `/v1/systemone`, every model family; PR #370 fixes decision reads for Qwen3.8-Flash-Next with MTP. So the port is not far off; it has advanced beyond the branch. But the artifact format still cannot carry decision schema; decisions are runtime requests.
- Basalt upstream: no typed decision endpoints in docs; it supports OpenAI/Anthropic and batched slots. Your decisive-basalt likely wraps that but not part of upstream `.basalt` pack. If you want decision API on Flash-Next in upstream ninfer-all, it's already there.
This addresses decision framework.

Need maybe maybe mention "ninfer-all master supports Qwen3.8-Flash-Next with decisions? PR #370 says Flash-Next with --spec mtp unchanged: image box reads. Yes.

Need maybe maybe inspect if ninfer-all decisions are `/v1/decisions` vs branch `/v1/decision` singular. Yes. Could mention.

Need maybe maybe mention "System One image boxes and media URLs added Nov 16" from README. Not central but can mention decision framework now includes image boxes? It may be relevant to user's decision framework? Could mention briefly.

Need maybe maybe discuss "batched inference" in decision branch: branch has parallel decisions? It says up to eight contexts and finite-trie divergences compiled together, bounded shared-prefix execution. ninfer-all master maybe every family supports decisions; PR #370 fixes batched reads? Not need.

Need maybe maybe include "The .ninfer artifact itself does not encode the decision framework; it encodes model/config/bindings/resources. Your decision framework is a serving-layer contract. Thus artifact size differences do not measure decision port drift." Good.

Need maybe ensure final answer doesn't overpromise "NInfer can read Shockem's .basalt". It cannot. Need explicit.

Need maybe maybe include "if you compare Basalt's official Flash-Next IQ3_S pack with NInfer's Flash-Next IQ3_S artifact, they are close: ~81.6 vs 81.16 GiB (with IQ4 table), not 100GB." Good.

Need maybe maybe include "Basalt's Shockem pack includes n-gram Q8PLE, but NInfer's official IQ3_S artifact does not include the ngram table in the model file. If you compare Shockem's one-file 105.7GiB to NInfer's model-only 54.24GiB, you are omitting 26.92GiB table artifact, making it look worse. If compare to WaveCut 27B 14GiB, you compare different model entirely." Great.

Need maybe maybe include "The model recognized by engine: WaveCut/Qwen3.8-27B-GSQ... It uses the same GGUF blocks but a different architecture/model type, Qwen3.5 Dense/Qwen3.8-27B, not Qwen4Exp. The engine recognized it because it's a Qwen3.8-27B GGUF artifact, not Flash-Next." Good.

Need maybe maybe include "If you want the engine to run the exact Shockem source, use SC117 GGUF source, not the .basalt pack. The abliterated tensors are inside GGUF and can be copied byte-for-byte by NInfer converter." Need caution: NInfer's GGUF recipe copies blocks byte for byte; but hyperconnection matrices are re-quantized from BF16 to Q8_0 for Flash-Next. If SC117 changed residual-write tensors that include hyperconnections? It transplants 144 residual-write tensors from uncensored GGUF; maybe those include dense projections? NInfer may re-quantize HC. But experts preserved. If the transplanted tensors are not GGUF quantized? "residual-write tensors" likely dense. Could be okay.

Need maybe maybe include "NInfer's published abliterated Qwen3.8-27B exists but not Flash-Next. There is no official WaveCut abliterated Flash-Next IQ3_S .ninfer in artifact table." Good.

Need maybe maybe include "The engine's model ID `qwen3.8-flash-next` must be used with `--ngram-table`." Good.

Let's draft final with high detail but not insane. Use headings and tables. Include citations as Markdown links. Need no citations style required but can link.

Need ensure final answer has "Bottom line" first.

Potential final answer:
```
Bottom line: The ports are not 100GB apart. They are different containers, not different model types. The 14GB file is not your Flash-Next checkpoint; it's a 27B dense artifact. A like-for-like Flash-Next IQ3_S .ninfer is ~54.24GiB model + 26.92GiB IQ4 table = 81.16GiB. Your Q8PLE .basalt is ~105.7GiB because it stores the PLE table as Q8_0 (54.4GB) and is abliterated/self-contained. Replace Q8 table with IQ4 and it is ~81.7-82.0GiB, close to NInfer.
```
Then detailed.

Need maybe include "how far off" with percentages? Maybe:
- model type: 0 drift
- container: 100% different
- GGUF weights: same source blocks but repacked
- same-model total bytes: within ~0.6-0.8GiB when using IQ4 table
- Q8PLE difference: ~24GiB
This answers.

Need maybe maybe mention "Basalt's 105.7 includes Q8PLE table from NVIDIA NVFP4 pack reblocked to Q8_0, while NInfer's official table is IQ4_NL and separate. Basalt's Shockem card says Q8_0 table 54.4GB, IQ4_NL 26.8GiB." Good.

Need maybe maybe include "NInfer v3 can be one file or parts; Basalt is one file. NInfer's objects are 256B aligned, Basalt sections 2MiB aligned. Basalt has section SHA-256; NInfer has artifact_id and JSON manifest; NInfer can read objects across parts." Good.

Need maybe maybe include "The `.ninfer` container is not a fork of `.basalt`; no common header." Good.

Need maybe maybe include "The `.basalt` file version 2 removed profile and added hc8. NInfer's Q8_0 HC is equivalent but not same layout. Profile differences are runtime policy." Good.

Need maybe maybe include "Decision port status" section:
```
Your branch exposes /v1/decision, /decision, /v1/systemone and requires --jev; Qwen4Exp not supported there. ninfer-all master now exposes /v1/decisions and /v1/systemone and PR #370 qualified Flash-Next reads; so the decision port in ninfer-all is ahead of your branch. Upstream Basalt docs do not expose typed decisions; decisive-basalt is an out-of-band wrapper. This does not affect .ninfer/.basalt size.
```

Need maybe maybe include "What to do" section with commands.

Conversion command: Need ensure `--source mtp` for Flash-Next recipe? Docs show `--source mtp=`. Include optional `--source dflash2=`? For Flash-Next model card DFlash2 attachment separate; maybe converter supports dflash2 component? README features says DFlash2 for Flash-Next. Weight conversion recipe table says MTP from MTP GGUF but not DFlash2 source. The published model says includes DFlash2 drafter and attachment JSON. Maybe converter has dflash2 source? For 27B yes; for Flash-Next maybe docs don't show. Could say "then attach DFlash2 if you want it; otherwise text/vision/mtp is enough." Good.

Need maybe include command with IQ4 table separate:
```
python3 -m tools.convert --model Qwen3.8-Flash-Next \
  --recipe qwen3_8_flash_next_gguf --components text \
  --source gguf=...-00001-of-00002.gguf \
  --source ngram=...-00002-of-00002.gguf \
  --source vision=mmproj... --source mtp=mtp-shared-Q8_0.gguf \
  --device cpu --rows-per-chunk 65536 --name qwen3.8-flash-next-abliterated --out ...ninfer
```
Then serve with separate table or self-contained. If want Q8 table, source ngram from Q8_0 table. Need note `--model` only config/tokenizer, not weights. Good.

Need maybe mention "the converter will refuse if vocab mismatch or missing shards; check SC117's shard count". Good.

Need maybe include "Do not compare with `--model-id qwen3.8-27b`; use `qwen3.8-flash-next`." Good.

Need maybe final answer with enough citations.

Double-check units and calculations:
- 113,491,281,169 / 1024^3. 1024^3=1,073,741,824. 113,491,281,169 / 1.073741824e9 = 105.696? yes 105.7.
- 15,017,456,896 / 1.073741824e9 = 13.986? yes 13.99.
- difference = 98,473,824,273 bytes / 1.073741824e9 = 91.70 GiB. In decimal 98.47GB. User says 100+GB maybe file sizes decimal? 113GB vs 15GB = 98GB. close.
- WaveCut Flash-Next 58,242,390,528 / 1.073741824e9 = 54.24.
- table 28,905,035,512 = 26.92.
- total 87,147,426,040 / 1.073741824e9 = 81.16.
- Shockem base Q8PLE 113,245,914,374 / 1.073741824e9 = 105.47? 113.245/1.073=105.47.
- abliterated vs base difference = 245,366,795 bytes = 228.5 MiB? 1 MiB=1,048,576; 245,366,795/1,048,576=234.0 MiB. yes.
- Q8 table 54,400,261,120 / 1.073e9 = 50.67 GiB. IQ4 table 26.92. delta = 23.75GiB.
- self-contained equivalent IQ4 base = 87,750,688,766 bytes = 81.72GiB. Abliterated equivalent = 87,996,055,561 = 81.95GiB. NInfer total 81.16. Difference 0.56/0.79GiB. Good.

Need be precise: Shockem abliterated current file size 113,491,281,169. It says experts 46.84GiB IQ3_S. PLE Q8 54,400,261,120. Sum = 101.24GiB. Remaining 4.45GiB dense/MTP/vision/hc8/tokenizer. Good.

Need maybe mention "Shockem's HF card says the previous v1 file 112.78GB; v2 migration didn't change weights, only sections/meta/hc8/profile." In current abliterated card: previous version-1 file was 112,780,347,059 bytes. The base Q8PLE card previous v1 112,534,980,259. Use current. Good.

Need maybe maybe mention "Basalt 0.2.0 required version 2; your file is version 2." Good.

Need maybe think about if `.basalt` includes "Q8PLE-Basalt" but model name says Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt. The recognized WaveCut is Qwen3.8-27B. Could answer "the engine is not recognizing Shockem because it's .basalt; it recognizes WaveCut because it's .ninfer." Obvious but important.

Need maybe maybe mention "Basalt's framework is not Strata's file format; it is `.basalt`, not `.strata`." Could say.

Need maybe maybe mention "ninfer-all supports Strata's model types, but not Strata/Basalt's checkpoint container." Good.

Need maybe maybe include "NInfer's GGUF block formats are stored in `gguf_blocks_v1`; Basalt's `gguf` section stores raw bytes with meta.tensors offsets. The quant blocks can be identical but addressing is different." Good.

Need maybe maybe include "NInfer's GGUF product uses q8_1 activations and llama.cpp block values; Basalt also uses q8_1 decode activations and dp4a/int8 MMA, but prefill differs: NInfer uses vendored llama.cpp integer tensor-core prompt kernel, Basalt uses fp16/BF16 GEMM/MMQ/FP4. This means outputs can be close but not guaranteed bit-for-bit across engines." Good.

Need maybe mention "Basalt's Flash-Next `hc8` is int8 copy of hyperconnections with fp16 scale per 32; NInfer's hyperconnections are ggml Q8_0 (fp16 scale per 32) too. So numerically similar but different stored object." Good.

Need maybe mention "Basalt's PLE is BF16 as stored in precision table? For Shockem Q8_0 token table; Basalt table says PLE key/value BF16 as stored? Wait precision table says PLE key/value BF16 as stored? For GGUF packs, `per_layer_token_embd.weight` Q8_0? It says PLE key/value BF16 as stored maybe for official NVFP4? Shockem Q8. NInfer table rows IQ4_NL. Anyway.

Need maybe maybe include "Basalt's Q8_0 ngram table came from NVIDIA FP8 table reblocked to Q8_0; NInfer's FP8 table exists as Edge0 table but Flash-Next official table IQ4. The two projects chose different quality/size tradeoffs." Good.

Need final.

Let's ensure no tool calls needed further. Maybe need check ninfer-all artifact container resources? Not necessary.

Let's compose final. Use Markdown.


</details>

## Bottom line

The ports are **not 100 GB apart in model semantics**. They are **not the same checkpoint container**, and the two Hugging Face repositories you linked are **not the same model type**.

- `Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt` is a **Qwen3.8-Flash-Next / `qwen4exp` / `Qwen4ExpForConditionalGeneration` MoE pack**, stored as a single `.basalt` file.
- `WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3` is a **Qwen3.8-27B / Qwen3.5-core dense GGUF-block artifact**, stored as `.ninfer` v3.

So the 14 GiB `.ninfer` file is not a “recognized Shockem Flash Next pack.” It is a different model family: dense 27B, not the 125B Flash-Next MoE with routed experts and the 320M-row PLE n-gram table.

For a like-for-like comparison, use:

- `WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3`: **54.24 GiB model-only**
- plus `WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3`: **26.92 GiB IQ4_NL table**

That gives approximately:

```text
54.24 GiB + 26.92 GiB = 81.16 GiB
```

Your current Shockem `.basalt` is:

```text
105.7 GiB
```

The remaining difference is mostly explained by the fact that your Shockem pack stores the PLE table as **Q8_0**, while NInfer’s published Flash-Next table is **IQ4_NL**:

```text
Q8_0 PLE table:  54.4 GB = 50.7 GiB
IQ4_NL table:    28.9 GB = 26.9 GiB
```

If you swap the Shockem Q8 table back to IQ4_NL, the equivalent Flash-Next IQ3_S package is roughly **81.7–82.0 GiB**, which is very close to the NInfer IQ3_S + IQ4-table total.

So: **the Flash-Next model-type front is basically unified; the artifact containers and PLE-table representation choices are different.**

---

## 1. The two HF artifacts you linked are not comparable as “same model, different format”

### Shockem pack

From the model card:

- file: one `.basalt`
- size: **113,491,281,169 bytes = 105.7 GiB**
- model: **Qwen3.8-Flash-Next**
- experts: **46.84 GiB IQ3_S**
- PLE table: `per_layer_token_embd.weight`, shape `[160, 320001536]`, **Q8_0**, **54,400,261,120 bytes**
- contains MTP, vision, tokenizer, `hc8`, and the Q8 n-gram table inside the same file
- version-2 `.basalt`, migrated from v1 with `tools/migrations/basalt_v1_to_v2.py`

Source:
[Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt](https://huggingface.co/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt)

### WaveCut pack

From the model card:

- file: one `.ninfer` v3
- size: **15,017,456,896 bytes = 13.99 GiB**
- model: **Qwen3.8-27B**
- source: ISTA-DASLab Qwen3.8-27B GSQ-RCO IQ3_S GGUF
- keeps GGUF blocks byte-for-byte
- includes MTP, DFlash2, vision, proposal head, etc.
- no routed-expert Flash-Next table, because it is not Flash-Next

Source:
[WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3](https://huggingface.co/WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3)

That artifact is the correct `.ninfer` equivalent of the **Qwen3.8-27B GGUF**, not of your Flash-Next `.basalt`.

---

## 2. Apples-to-apples Flash-Next size comparison

Use the actual Flash-Next NInfer artifact:

- [WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3)

Size:

```text
58,242,390,528 bytes = 54.24 GiB
```

But this artifact **does not contain the n-gram table**. NInfer publishes it separately:

- [WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3](https://huggingface.co/WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3)

Size:

```text
28,905,035,512 bytes = 26.92 GiB
```

So the real total for NInfer Flash-Next IQ3_S + IQ4_NL table is:

```text
58,242,390,528 + 28,905,035,512
= 87,147,426,040 bytes
= 81.16 GiB
```

Your Shockem Q8PLE `.basalt` is:

```text
113,491,281,169 bytes
= 105.7 GiB
```

Difference:

```text
113,491,281,169 - 87,147,426,040
= 26,343,855,129 bytes
≈ 24.53 GiB
```

That difference is almost exactly the PLE table format difference.

Your Q8 PLE tensor is:

```text
54,400,261,120 bytes = 50.67 GiB
```

NInfer’s IQ4_NL table is:

```text
28,905,035,512 bytes = 26.92 GiB
```

Table delta:

```text
54,400,261,120 - 28,905,035,512
= 25,495,225,608 bytes
≈ 23.75 GiB
```

Add the expected small differences from MTP/vision/tokenizer/hc8/profile/DFlash2 packaging, and the totals line up well.

If you convert a Shockem-like Flash-Next IQ3_S source but use IQ4_NL PLE rows, the NInfer total should land around:

```text
81–82 GiB
```

If you convert it with Q8_0 PLE rows, it should land around:

```text
105 GiB
```

So the 100 GB discrepancy is not evidence that the Flash-Next port is badly off. It is evidence that you are comparing:

```text
Flash-Next MoE + Q8 PLE + self-contained .basalt
```

to:

```text
Qwen3.8-27B dense + IQ3_S GGUF blocks + .ninfer v3
```

---

## 3. `.basalt` vs `.ninfer`: different containers, not different model front

As of mid-November 2026, the two ecosystems are parallel but not checkpoint-compatible.

### `.basalt` format

Authoritative source:

- [Basalt model_format.hpp](https://github.com/jesdga95/basalt/blob/main/include/basalt/core/model_format.hpp)
- [Basalt model-file docs](https://github.com/jesdga95/basalt/blob/main/docs/model-file.md)
- [Basalt file changelog](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md)

`.basalt` is a sectioned archive:

```text
64 KiB header
  magic: BASALTMF
  version: 2
  section count
  file_bytes
section table
  name
  offset
  bytes
  sha256
sections aligned to 2 MiB
```

Typical sections:

```text
meta
tokenizer/*
dense
dense.index
experts
experts.layout
gguf
mtp/dense
mtp/dense.index
mtp/experts
mtp/draft_vocab
hc8
dspark/gguf       # DeepSeek only
vision/mmproj
vision/*
```

Version 2:

- adds required `hc8`
- removes `profile`
- moves expert placement policy into the engine’s `data/profiles`
- does not requantize weights during v1 → v2 migration
- keeps weights byte-for-byte during migration

Your Shockem model card explicitly says this: v2 file, `profile` gone, `hc8` present, all weight sections copied with matching SHA-256.

### `.ninfer` v3 format

Authoritative source:

- [NInfer artifact-container.md](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/artifact-container.md)
- [NInfer storage-layouts.md](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md)
- [NInfer tensor-formats.md](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/tensor-formats.md)

`.ninfer` v3 is a JSON-manifest object container:

```text
32-byte entry header
  magic: NINFER\0\03
  json_bytes
  artifact_id
JSON manifest
payload aligned after JSON
```

The manifest contains:

```text
components
objects
bindings
uses
files
metadata
provenance
```

Tensor objects have:

```text
id
kind
shape
format
layout
offset
bytes
optional divisors
```

Supported layouts include:

```text
contiguous_le_v1
row_split_k128_v1
block_scale_k16_m128x4_v1
row_scale_v1
row_interleaved_v1
gguf_blocks_v1
raw_bytes_v1
```

For GGUF block passthrough, NInfer uses:

```text
gguf_blocks_v1
```

where each row stores the GGUF blocks unchanged.

### Practical consequence

There is no shared loader.

```text
Basalt reads .basalt.
NInfer-all reads .ninfer.
```

A `.basalt` file is not a `.ninfer` file with a different extension. It has a different header, different section/object model, different metadata contract, and different alignment strategy.

So NInfer-all will not “recognize” your Shockem `.basalt` just because it has merged the model type. It recognizes `.ninfer` artifacts.

---

## 4. Where the weight payloads are similar

For GGUF sources, both projects deliberately avoid requantizing the routed experts and other GGUF-quantized tensors.

### NInfer

From [NInfer GGUF docs](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md):

- GGUF releases with per-tensor ggml types are copied block-for-block.
- The runtime multiplies those blocks in place.
- Flash-Next uses `qwen3_8_flash_next_gguf`.
- Routed experts are kept as expert-major banks.
- Hyper-connection matrices are stored as ggml Q8_0.
- IQ3_S, IQ2_S, IQ3_XXS, IQ4_NL, Q2_0, etc. are preserved as `gguf_*` formats.

### Basalt

From [Basalt precision docs](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md):

- GGUF packs keep GGUF blocks byte-for-byte.
- Routed experts use q8_1 activations and int8/dp4a/MMA paths.
- Dense projections are stored in their selected GGUF types.
- Hyper-connections are stored as int8 `hc8`.

So the underlying quantized expert bytes can be very close, especially for the same GGUF source. The difference is how those bytes are addressed and interpreted.

In short:

```text
Same source GGUF blocks
Different container
Different tensor index / binding metadata
Different runtime placement policy
```

---

## 5. Where the `.ninfer` artifacts differ from `.basalt` artifacts

### A. Container metadata

`.basalt` uses:

```text
BASALTMF
fixed header
named sections
section SHA-256
2 MiB section alignment
```

`.ninfer` uses:

```text
NINFER v3
JSON manifest
component graph
logical bindings
object offsets
256-byte object alignment
optional part files
```

This means `.ninfer` has a richer runtime object graph. Basalt has a simpler opaque-section archive and hard-coded section semantics.

---

### B. Expert placement policy

Basalt version 2 intentionally moved the expert profile out of the checkpoint:

```text
profile section removed
placement policy moved to data/profiles in engine
```

This is a deliberate design choice: better placement profiles can ship with the engine without re-downloading weights.

NInfer also has placement profiles and device calibration, but the artifact itself can include components/resources differently, especially for n-gram hot-row profiles.

---

### C. Hyper-connection storage

Basalt `.basalt` version 2 stores an `hc8` section:

```text
int8 copy of hyper-connection matrices
one fp16 scale per 32 inputs
```

NInfer Flash-Next stores hyper-connection projections as ggml Q8_0 tensor objects:

```text
BF16 source matrices requantized to Q8_0
```

These are numerically similar ideas, but not the same container representation.

---

### D. N-gram / PLE table

This is the biggest practical difference for Flash-Next.

Basalt stores PLE as a raw GGUF tensor section:

```text
per_layer_token_embd.weight
```

Your Shockem pack stores it as Q8_0:

```text
54.4 GB raw
170 bytes per row
```

NInfer stores PLE as a table artifact or table component:

```text
320,001,536 rows
each row has 160 values
IQ4_NL rows
90 bytes per row
28.9 GB raw
```

NInfer models can reference a table by digest and, in current master, can read an alternate table of the same geometry in other supported row formats. But the published Flash-Next table artifact is IQ4_NL, not Q8_0.

This explains most of your size difference.

---

### E. MTP drafter

Basalt packs can carry a self-distilled MTP drafter inside the `.basalt` file.

NInfer Flash-Next artifacts usually attach the Unsloth shared-Q8_0 MTP block.

They are not byte-identical unless the donor MTP source is identical.

For your Shockem pack, the card says the MTP/vision/tokenizer sections were copied from the official IQ3_S Basalt pack using `--sections-from`. That is a Basalt-side donor workflow. NInfer’s published artifact came from a different MTP attachment source.

---

### F. DFlash2

NInfer-all’s Flash-Next IQ3_S artifact includes a DFlash2 drafter:

- incoai DFlash2
- nazeshinjite Q4_0 GGUF
- 339 MB
- enabled by newer NInfer-all commits

Basalt’s Flash-Next docs emphasize MTP and suffix drafting. DFlash2 is documented as the 27B drafter in Basalt, not as the Flash-Next path.

So NInfer-all is ahead on Flash-Next DFlash2.

---

### G. Vision tower

Basalt stores:

```text
vision/mmproj
```

as the vision projector GGUF inside the `.basalt` file.

NInfer stores vision as a component with decoded tensor objects and bindings.

Conceptually similar; container-wise unrelated.

---

### H. Tokenizer / chat template

Basalt stores tokenizer files directly:

```text
tokenizer/tokenizer.json
tokenizer/vocab.json
tokenizer/merges.txt
tokenizer/chat_template.jinja
```

NInfer stores frontend resources through the container’s resource/object system, and the conversion command can explicitly attach a chat template resource.

Again: same conceptual payload, different framing.

---

### I. File sharding

Basalt `.basalt` is one file.

NInfer `.ninfer` can be one file or an entry plus `.part-NNNN` continuation files.

Your large artifacts are currently one-file in both ecosystems, but NInfer’s format is sharding-aware by design.

---

## 6. Model-type front: the ports are much closer than the file sizes suggest

NInfer’s Flash-Next model reference explicitly identifies the same target as Basalt:

```text
HF Qwen/Qwen3.8-Flash-Next
architectures = ["Qwen4ExpForConditionalGeneration"]
model_type = "qwen4_exp"
text model_type = "qwen4_exp_text"
```

Source:
[NInfer qwen4-exp-model.md](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/qwen4-exp-model.md)

Important shared geometry:

```text
hidden_size = 2560
layers = 48
36 GDN layers
12 QSA layers
HC streams = 4
routed experts = 512
experts per token = 10
PLE n-gram table = 320,001,536 rows x 160 values
16 hash heads
2-token and 3-token n-grams
MTP shares embeddings/head
```

Basalt docs also describe the same architecture:

```text
2560 hidden
4 hyper-connection streams
48 layers
36 GDN
12 QSA
512 experts
top-10
```

Source:
[Basalt Flash-Next precision docs](https://github.com/jesdga95/basalt/blob/main/docs/precision/qwen38-flash-next.md)

So at the model-semantic front, they are talking about the same model.

The important nuance:

```text
NInfer-all merged Strata / Strata-like model support.
Basalt is a fork of Strata.
But both projects have diverged their own artifact containers.
```

NInfer’s model docs even list Strata as an authority/reference, not as the runtime checkpoint format:

> llama.cpp PR #27742 for GGUF names; Strata for independently validated CUDA transcription.

So “merged Strata” should not be interpreted as “reads Basalt packs.” It means the model math and pitfalls were cross-validated or ported.

---

## 7. How far off are the ports?

I would grade it this way.

| Axis | Basalt vs NInfer-all | How far off |
|---|---:|---:|
| Flash-Next model architecture | `qwen4exp` / `Qwen4ExpForConditionalGeneration` | **Very close** |
| GGUF source quantization preservation | both keep GGUF blocks byte-for-byte | **Close** |
| Container header | `BASALTMF` v2 vs `NINFER` v3 | **Completely different** |
| Tensor metadata | named sections vs JSON object graph/bindings | **Completely different** |
| Expert layout | `experts` + `experts.layout` vs expert-major object banks | **Different addressing** |
| PLE table | raw tensor section vs table artifact/component | **Different packaging; major size delta** |
| Hyper-connections | `hc8` vs Q8_0 tensor objects | **Similar compression, different format** |
| MTP | Basalt self-distilled vs NInfer Unsloth shared-Q8_0 | **Not identical unless same donor** |
| DFlash2 for Flash-Next | Basalt upstream: no; NInfer: yes | **NInfer ahead** |
| Typed decisions | Basalt upstream docs: no; NInfer-all: yes | **NInfer ahead** |
| GPU support | Basalt: Blackwell `sm_120` | NInfer: Volta to consumer Blackwell | **NInfer broader** |
| Practical checkpoint interchange | `.basalt` ↔ `.ninfer` | **No direct interchange** |

The important conclusion:

```text
Architecture front: aligned.
Checkpoint back end: diverged.
```

The ports are not “off” at the model type. They are off at the artifact contract.

---

## 8. The decision-framework port

This matters because your decision framework is not primarily a checkpoint-format issue.

### Your `decisive-ninfer` branch

From `CommanderTurtle/decisive-ninfer` on `feature/parallel-decision`:

- exposes `/v1/decision`, `/decision`, `/v1/systemone`
- requires `--jev`
- supports Qwen3.5 Dense/MoE, including Qwen3.8-27B
- docs explicitly say Qwen4Exp inference currently runs without `--jev`

Source:
[decisive-ninfer serving docs](https://github.com/CommanderTurtle/decisive-ninfer/blob/feature/parallel-decision/docs/serving.md#parallel-decisions-jev)

### NInfer-all master

NInfer-all master now has typed decision endpoints:

```text
/v1/decisions
/v1/systemone
```

and the latest PR #370 specifically fixed typed decision reads, including behavior relevant to Qwen3.8-Flash-Next with `--spec mtp`.

Source:
[ninfer-all PR #370](https://github.com/iamwavecut/ninfer-all/pull/370)

So the decision port in NInfer-all is now **ahead of your original branch**, at least in terms of Flash-Next decision-read behavior.

Your branch appears to have been the origin; master has generalized it and fixed defects.

### Upstream Basalt

As of Basalt `v0.4.1`, the upstream docs describe OpenAI/Anthropic-compatible serving, batched slots, vision, video, MTP drafting, expert tiering, and `/tokenize`/`/detokenize`, but I did not find a first-class typed decision API analogous to `/v1/decisions` or `/v1/systemone`.

Source:
[Basalt README](https://github.com/jesdga95/basalt)

So if your `decisive-basalt` framework provides decision semantics around Basalt, that is an external wrapper or sidecar layer, not part of the upstream `.basalt` checkpoint contract.

Important:

```text
Decision framework is a serving/runtime contract.
It does not explain the 100 GB checkpoint-size difference.
```

---

## 9. Why your specific model is recognized as WaveCut 27B, not Shockem Flash Next

The engine recognized:

```text
WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3
```

because that is a valid `.ninfer` v3 artifact for:

```text
Qwen3.8-27B
```

It is not a recognized conversion of:

```text
Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt
```

For NInfer-all, Flash-Next needs:

```text
--model-id qwen3.8-flash-next
--ngram-table PATH
```

and the model artifact should be a Flash-Next `.ninfer`, not a 27B `.ninfer`.

The NInfer Flash-Next IQ3_S artifact is:

```text
WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3
```

not:

```text
WaveCut/Qwen3.8-27B-GSQ-RCO-IQ3_S-NInfer-v3
```

Those are different model IDs and different architectures.

---

## 10. What you should actually compare

For your current Shockem pack, the closest NInfer-side comparison is not the 27B artifact.

Use:

```text
WaveCut/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-NInfer-v3
+
WaveCut/Qwen3.8-Flash-Next-ngram-table-NInfer-v3
```

Then compare:

| Artifact | Size | PLE table | Notes |
|---|---:|---|---|
| Shockem abliterated Q8PLE `.basalt` | 105.7 GiB | Q8_0 | self-contained |
| Shockem non-abliterated Q8PLE `.basalt` | 105.5 GiB | Q8_0 | same idea |
| WaveCut Flash-Next IQ3_S `.ninfer` | 54.24 GiB | not included | model only |
| WaveCut Flash-Next IQ4_NL table | 26.92 GiB | IQ4_NL | required for normal Flash-Next operation |
| WaveCut Flash-Next IQ3_S + IQ4 table | 81.16 GiB | IQ4_NL | realistic NInfer total |
| Shockem Q8PLE with IQ4 swap | approx. 81.7–82.0 GiB | IQ4_NL | close to NInfer total |

That is the correct comparison.

---

## 11. If you want to run your Shockem model through NInfer-all

You should not try to feed the `.basalt` file directly.

NInfer-all’s converter expects source weights in GGUF/HF/etc., not `.basalt`.

The relevant recipe is:

```text
qwen3_8_flash_next_gguf
```

Source:
[NInfer weight-conversion.md](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md)

A realistic conversion shape is:

```bash
python3 -m tools.convert \
  --model Qwen3.8-Flash-Next \
  --recipe qwen3_8_flash_next_gguf \
  --components text,vision,mtp \
  --source gguf=Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-00001-of-00002.gguf \
  --source ngram=Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-00002-of-00002.gguf \
  --source vision=mmproj-Qwen3.8-Flash-Next-BF16.gguf \
  --source mtp=mtp-Qwen3.8-Flash-Next-shared-Q8_0.gguf \
  --device cpu \
  --rows-per-chunk 65536 \
  --name qwen3.8-flash-next-abliterated \
  --out Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-ninfer-v3.ninfer
```

Then serve with:

```bash
ninfer-serve \
  models/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-ninfer-v3.ninfer \
  --ngram-table models/Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer \
  --model-id qwen3.8-flash-next \
  --expert-residency host \
  --max-context 32768
```

If you want the Q8 PLE table, you need a Q8_0 n-gram source and should convert/use that table. The published NInfer table is IQ4_NL, so the default published artifact will not match your Shockem Q8PLE byte size unless you intentionally make a Q8 table artifact.

---

## 12. The 14 GiB artifact is not “the same model but optimized”

This is the key point.

The WaveCut 27B artifact is small because:

- it is dense, not 512-expert MoE
- it has no 320M-row Flash-Next PLE table
- it has about 10.95 GiB of resident text weights without vision/drafters
- it is IQ3_S GGUF blocks
- it is not the same `model_type`

Your Shockem model is large because:

- it has 48 layers × 512 routed experts
- it has the PLE table
- it stores the PLE table as Q8_0
- it carries MTP, vision, tokenizer, `hc8`, metadata, etc.
- it is self-contained

So the 100 GB gap is not a porting error.

---

## 13. Final verdict

The Flash-Next support is **not 100 GB “off.”**

More precisely:

1. **Model type support:**
   Basalt and NInfer-all are aligned on `qwen4exp` / Flash-Next.

2. **Artifact compatibility:**
   They are not compatible. `.basalt` and `.ninfer` are different containers.

3. **Weight preservation:**
   Both preserve GGUF quantized blocks from the relevant sources, but they repack them into different object/section systems.

4. **Size difference between your HF repos:**
   Mostly invalid comparison. One is Flash-Next 125B MoE; the other is Qwen3.8-27B dense.

5. **Real Flash-Next IQ3_S comparison:**
   NInfer model + IQ4 table is about **81.16 GiB**.
   Shockem Q8PLE is about **105.7 GiB**.
   The difference is mostly **Q8 PLE vs IQ4 PLE**, plus packaging/component differences.

6. **Decision framework:**
   Your decision API is a serving-layer port, not a checkpoint-format difference. NInfer-all master appears to have advanced beyond your original branch and now supports typed decision reads including Flash-Next behavior. Upstream Basalt’s `.basalt` format does not encode that decision framework.

So the shortest technical answer is:

```text
The ports are unified at the model-type front, but not at the checkpoint-container front.
Your 14 GiB WaveCut artifact is not your Shockem Flash-Next checkpoint.
A real Shockem-like Flash-Next .ninfer would be ~81 GiB with IQ4 NInfer table,
or ~105 GiB if using Q8 PLE like your .basalt pack.
```
## User · #61

Yep. My bad on the erroneous link. You found the correct one.

It seems, the main question then stands:

1. How hard is it to make that exact ngram table for the shockem model, to have a nearly byte identical model under a .ninfer artifact.

2. Likewise, what's the compute when "making" a .ninfer or .basalt. Am I expecting day(s) of running? Or, is the python file rather fast for consolidating when you have high compute like my 32gb card (5090) + 64gb ddr5 (ram) build. Like I said, I run that 100gb+ checkpoint (back from when it was still a v1 artifact).

3. Does ninfer-all still benefit from an additive Q8PLE ngram, or, is it simply "not included" as in, meaning "it's there, just no one has necessarily done it yet, and it will still be easy to do from shockm's sources)

4. Would a dflash2 drafter need to be found separately for shockm's model? His current .basalt uses MTP, but, would an identical dflash2 adaptation be any more hard on system resources, or, would it be near-identical to the MTP setup that I currently run (in terms of stress on the machine. I already know dlfash2 is faster for smaller models like 27b, where it has been mainstreamed).
## Assistant · #62

<details><summary>Reasoning · 3,548 characters</summary>

We need answer four questions based on research. Need maybe do more research? We have enough? Need maybe check NInfer conversion speed, compute, components. Need know whether converter is fast, uses CPU by default, CUDA, PyTorch. Need inspect docs for conversion performance, maybe weight-conversion section says conversions take? Need search local resource maybe ninfer-all weight-conversion. Could use context_read sections of weight-conversion? We have resource 33493a18, need section 3/4 maybe conversion commands, sources. But compute time not explicit. Need infer and maybe look at converter docs, tools/convert. Could inspect Basalt convert.py doc: streamed, workers 16, about a minute for 27B QUASAR? It says 19.7 GiB pack about a minute on 16 processes. Flash-Next conversion from GGUF to .basalt likely minutes to tens of minutes, disk-bound. For .ninfer, conversion can be more expensive: reads GGUF shards, rewrites blocks, hashes table (minute or so for 28.8 GB). Need estimate.

Need answer Q3: Does ninfer-all still benefit from additive Q8PLE ngram? Need parse: "still benefit from an additive Q8PLE ngram, or simply 'not included' meaning it's there, just no one has done it yet, and it will still be easy from shockm sources". Need say: Not included as a published artifact by default; NInfer architecture supports ngram component/table and can use alternate row formats. Q8PLE is not model architecture requirement. It is a quality/speed tradeoff. Basalt supports reading Q8_0 PLE; NInfer published IQ4_NL because smaller; docs mention FP8 table rejected for 80% larger rows? Actually Edge0 FP8 table is supported, and any table of same shape/row format. But does NInfer support Q8_0 PLE row format for Flash-Next? It says any table of model's shape, in any row format. But "row format" might mean supported row format: IQ4_NL or FP8; Q8_0 maybe gguf_blocks_v1 Q8_0, supported as GGUF block format. The table has 160 values per row; Q8_0 block size 32, so 5 blocks + 5 fp16 scales = 170 bytes. Could convert from a .basalt? The Q8 table came from NVIDIA NVFP4 Basalt pack, not GGUF. To make NInfer Q8PLE, need source as GGUF tensor or raw Q8_0 rows. Shockem replaced IQ4 table with Q8_0 table from official NVFP4 Basalt pack. NInfer converter expects `--source ngram=` GGUF shard. If you only have Shockem .basalt, no direct .basalt reader. But you can extract the `gguf` section tensor `per_layer_token_embd.weight` from .basalt or source Q8 table, and wrap as a GGUF tensor or use raw? Maybe NInfer has Edge0 FP8 table from Edge0 pack; not arbitrary raw tensor. But likely can convert from the GGUF source that has Q8_0 PLE? Are there GGUF releases with Q8_0 PLE? NVIDIA NVFP4 checkpoint has FP8 table, Basalt reblocked to Q8_0. Shockem sources: NVIDIA FP8 table reblocked to Q8_0 in .basalt; no upstream GGUF with Q8 PLE? Basalt official packs maybe store Q8_0 n-gram in NVFP4 pack. For NInfer, to make exact Q8 table, you need extract the Q8 rows from Basalt pack or use a GGUF containing `per_layer_token_embd.weight` as Q8_0. If NInfer doesn't have raw .basalt source, may need a small extraction/repack script.

Need maybe check NInfer Flash-Next docs section 2 "Write just the FP8 table from an already downloaded HF checkpoint" (indexed section 2). That could answer if NInfer can write table from HF checkpoint. Need read qwen3-8-flash-next.md sections 2 and maybe 1/5 for ngram table and hot rows. Use context_read resource c3be2147 sections 2, 1 maybe. Also maybe resource_search? Let's read section 2 and section 5?


</details>

<details><summary>Tool request · context_read · call_e97e1b632c3249d09c1787d9</summary>

```json
{
  "kind": "resource",
  "id": "c3be2147-fd29-4399-b30f-5ff84b5c86e3",
  "section": 2
}
```

</details>

<details><summary>Tool request · context_read · call_5bfcb9c8f0e04ca8b9bf3184</summary>

```json
{
  "kind": "resource",
  "id": "33493a18-b99f-4411-8090-d576a080380e",
  "section": 3
}
```

</details>

<details><summary>Tool request · context_read · call_d61242fd7bb14cd295183b83</summary>

```json
{
  "kind": "resource",
  "id": "33493a18-b99f-4411-8090-d576a080380e",
  "section": 4
}
```

</details>


<details><summary>Tool result · context_read · call_e97e1b632c3249d09c1787d9</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md · section 2/12
Subsection: Write just the FP8 table from an already downloaded HF checkpoint.
Tags: code

`qwen3_8_flash_next` supports HF-source conversion: text routed experts Q4 gate/up and Q5 down, shared experts and GDN/QSA projections Q8, embedding Q8 and head Q6. HC, router, indexer, PLE, vision and small GDN gates stay in their direct formats. MTP routed experts use Q4 and its other projections BF16. No sensitive-layer Q6 mask is selected without quality measurements. Both text recipes accept the IQ4\_NL GGUF table or HF BF16 n-gram shards via `--source ngram=PATH`. HF rows become `fp8_e4m3fn_row_fp16`: 160 E4M3FN bytes and an FP16 scale per row. Full-model quality and memory requirements of this recipe are unmeasured; full HF-to-Q4/Q5 artifacts and their model campaign are outside the current delivery scope. The official FP8 checkpoint's individual expert matrices are supported alongside BF16 fused banks. E4M3FN codes are multiplied by their stored BF16 or FP32 `weight_scale_inv` values in 128×128 blocks, then rounded to FP32 before the selected artifact quantizer runs. Despite its name, `weight_scale_inv` is the dequantization multiplier. Source overrides resolve the selected checkpoint's layout, including MTP. Unscaled FP8 banks are refused. An FP8 text checkpoint still needs a separate supported table source: IQ4\_NL GGUF or HF BF16 shards. Import of the FP8 checkpoint's own n-gram encoding is not implemented.

```shell
python3.11 -m tools.convert --model /path/to/HF-BF16-checkpoint \
  --recipe qwen3_8_flash_next --components text,ngram,mtp \
  --source ngram=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00002-of-00002.gguf \
  --device cpu --out models/flash-next-q4-q5.ninfer

# Write just the FP8 table from an already downloaded HF checkpoint.
python3.11 -m tools.convert --model /path/to/HF-BF16-checkpoint \
  --recipe qwen3_8_flash_next --components ngram \
  --source ngram=/path/to/HF-BF16-checkpoint --device cpu \
  --out models/flash-next-ngram-fp8.ninfer

# Fetch only the HF MTP tensors into a new directory, with bounded 8 MiB weight reads.
python3.11 -m tools.reference.fetch_slice --repo Qwen/Qwen3.8-Flash-Next \
  --revision de4b8e4d43b917e7706784d8bb445c9af86a3540 --mtp --out /path/to/mtp-subset
```

The subset includes a config, safetensors index and SHA-256 manifest for files and individual tensors. Pass `--source mtp=/path/to/mtp-subset` to the native or GGUF recipe to use it; the HF MTP block then uses Q4 routed experts and BF16 elsewhere. A server that ignores byte ranges is refused before a full shard is read. Failed copies retain a `.partial` file, never a published safetensors file; use a fresh output directory after resolving a failed transfer.

An FP8 table (`fp8_e4m3fn_row_fp16`, 51.8 GB) from the HF BF16 shards is supported but not published: it improved held-out perplexity by 1.25% (worse on both code domains) for 80% more table storage than IQ4\_NL, which stays the release representation.

`--components text,vision` (with or without `ngram`) adds the Vision tower from the release's `mmproj-Qwen3.8-Flash-Next-BF16.gguf` (`--source vision=PATH`): the same tower as Qwen3.5/3.6 (27 blocks of width 1152, merging 2×2 patches onto the text model's 2,560), kept in BF16, 0.9 GB. `--model` then also needs `preprocessor_config.json` and `video_preprocessor_config.json`.

`--components text,mtp` (with or without `ngram` and `vision`) adds the MTP block from one of Unsloth's MTP GGUFs (`--source mtp=PATH`; [`unsloth/Qwen3.8-Flash-Next-GGUF`](https://huggingface.co/unsloth/Qwen3.8-Flash-Next-GGUF)
, folder `MTP/`, a `shared-` file, which borrows the model's token embedding and head):

```shell
python3 -m tools.convert --model /path/to/Qwen3.8-Flash-Next \
  --recipe qwen3_8_flash_next_gguf --components text,ngram,mtp \
  --source gguf=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00001-of-00002.gguf \
  --source ngram=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00002-of-00002.gguf \
  --source mtp=/path/to/mtp-Qwen3.8-Flash-Next-shared-Q8_0.gguf \
  --device cpu --rows-per-chunk 65536 \
  --name qwen3.8-flash-next --out models/flash-next-q2_0-mtp.ninfer
```

The block keeps its matrices in the GGUF's blocks and its 512 experts, also beside the Coder build's 256; its norms drop their stored `1 + w`, and its hyper-connection matrices keep the `shared-Q8_0` file's Q8\_0 blocks, which their kernels read. The `shared-Q8_0` block adds 2.8 GB to the model.

The DFlash2 drafter ([DFlash2 speculative decoding](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#dflash2-speculative-decoding)
) is appended to a converted artifact as its `dflash2` component, from [nazeshinjite's Q4\_0 GGUF](https://huggingface.co/nazeshinjite/Qwen3.8-Flash-Next-DFlash2-GGUF)
 of [incoai's drafter](https://huggingface.co/incoai/Qwen3.8-Flash-Next-DFlash2)
 and incoai's `config.json`. The artifact's other objects keep their bytes; the drafter keeps its Q4\_0 blocks and adds 339 MB:

```shell
python3.11 scripts/pods/attach_dflash2.py --base models/flash-next-q2_0.ninfer \
  --gguf /path/to/Qwen3.8-Flash-Next-DFlash2-Q4_0.gguf \
  --config /path/to/Qwen3.8-Flash-Next-DFlash2/config.json \
  --output models/flash-next-q2_0-dflash2.ninfer
```

Every matrix keeps the block type the release chose (see [GGUF block formats](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gguf.md)
); the expert banks keep the exporter's expert-major layout, so one expert is one contiguous range of bytes. The recipe undoes llama.cpp's exporter conventions as the Qwen3.8-27B GGUF recipe does (grouped GDN value heads, `1 + w` norms, `A_log`, the head-interleaved query and gate). The n-gram table keeps the release's IQ4\_NL rows, and its component carries the hash constants they were written for; the runtime derives them again from the model's configuration and refuses a table that disagrees ([another table of the same shape](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#another-table-of-the-same-shape)
).

Run
---

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#run)

```shell
# One GPU with room for every expert (48 GB for Q2_0, the 96 GB RTX PRO 6000 for IQ3_S).
./build/apps/ninfer-serve models/flash-next-q2_0.ninfer --ngram-table models/flash-next-ngram-table.ninfer \
  --max-context 32768

# Two 24 GB GPUs (two 32 GB for IQ3_S): every expert in device memory, one pipeline stage per GPU (Linux).
./build/apps/ninfer-serve models/flash-next-q2_0.ninfer --ngram-table models/flash-next-ngram-table.ninfer \
  --devices 0,1 --max-context 32768

# The same GPUs dividing every layer instead: GDN key heads, attention KV heads, routed experts (Linux).
./build/apps/ninfer-serve models/flash-next-q2_0.ninfer --ngram-table models/flash-next-ngram-table.ninfer \
  --devices 0,1 --tensor-parallel --max-context 32768

# One GPU: the experts in pinned host memory, the most used of them cached on the GPU.
./build/apps/ninfer-serve models/flash-next-q2_0.ninfer --ngram-table models/flash-next-ngram-table.ninfer \
  --expert-residency host --max-context 32768

# One GPU and little RAM: the experts stay in the artifact's files and stream into a GPU cache.
./build/apps/ninfer-serve models/flash-next-q2_0.ninfer --ngram-table models/flash-next-ngram-table.ninfer \
  --expert-residency disk --max-context 32768
```

A model converted with its table needs no `--ngram-table`. `ninfer` and `ninfer-perplexity` take the same options, and the Docker image's `serve` command takes them with the files under `/models` ([launch recipes](https://github.com/iamwavecut/ninfer-all/blob/master/docs/recipes.md#qwen38-flash-next)
).



</details>

<details><summary>Tool result · context_read · call_5bfcb9c8f0e04ca8b9bf3184</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md · section 3/5
Subsection: Qwen3.8-Flash-Next GGUF releases
Tags: code, table

The Qwen3.8-Flash-Next and Edge0 recipes (`qwen3_8_flash_next_gguf`, `edge0_pack`) require the official 248,320 rows: their per-layer embedding reads n-gram table rows at hashes of the official token ids, so a condensed vocabulary would also need a table hashed over the new ids.

### Qwen3.8-Flash-Next GGUF releases

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#qwen38-flash-next-gguf-releases)

`qwen3_8_flash_next_gguf` ([`qwen4_exp_gguf.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/qwen4_exp_gguf.py)
) imports the model shard of a Qwen3.8-Flash-Next GSQ-RCO release the same way: every matrix keeps its block type, the 512-expert banks stay expert-major (one expert is one contiguous byte range), and the exporter's conventions are undone by row gathers and exact small-tensor transforms. The release's second shard, the n-gram table, is the `ngram` component: the model always records the table's hash constants, row format and SHA-256, and `--components` decides where the rows go -- `text,ngram` (the default) into the model's artifact, `text` nowhere (the model reads a table artifact at run time), `ngram` into a table artifact without a model. The runtime reads only the rows each token addresses. `mtp` beside `text` adds the MTP block from one of Unsloth's MTP GGUFs (`--source mtp=...shared-Q8_0.gguf`, block 48 with `nextn.*` tensors): its fused input projection `eh_proj` splits between blocks into `fc_embedding` and `fc_hidden`, its norms drop their `1 + w`, and its hyper-connection matrices keep their Q8\_0 blocks. The text model's hyper-connection matrices, BF16 in the GSQ-RCO GGUFs, are the one thing the recipe re-quantises: to ggml Q8\_0 by its reference rounding, which halves the largest share of a decoded token's weight reads. Commands, runtime options and measurements: [Qwen3.8-Flash-Next](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md)
.

### Edge0 release folders

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#edge0-release-folders)

`edge0_pack` ([`edge0.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/edge0.py)
) imports an Edge0 release folder (`--source pack=FOLDER`) with `--model` holding the base Qwen3.8-Flash-Next's configuration and tokenizer files: the skeleton GGUF as the Flash-Next recipe imports it, and the latent MoE beside it, its expert, encoder and decoder rows byte for byte. The text configuration gains `latent_moe` (the latent width, the 8 groups and which scales the artifact stores). The FP8 n-gram table becomes `fp8_e4m3fn_row_fp16` rows with the release's one scale in each row, and `--components` places it as for Flash-Next. Commands, runtime options and the mathematics: [Edge0](https://github.com/iamwavecut/ninfer-all/blob/master/docs/edge0.md)
.

### Gemma 4 GGUF releases

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#gemma-4-gguf-releases)

`gemma4_gguf` ([`gemma4.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/gemma4.py)
) imports the text model of `google/gemma-4-26B-A4B-it-qat-q4_0-gguf` with `--model` holding the Hugging Face release's `config.json`, tokenizer, `chat_template.jinja` and `generation_config.json` and `--source gguf=...` the GGUF. The expert banks stay expert-major, the router's input scale and the per-expert output scales stay vectors the runtime applies, and the norm weights are stored as Gemma applies them (`w`, not `1 + w`). `--components text,mtp --source mtp=...` adds the multi-token-prediction assistant from a llama.cpp `gemma4-assistant` GGUF as the `mtp` component, checked against the target's head geometry and width. Commands, runtime defaults and measurements: [Gemma 4](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gemma4.md)
.

### Flint GGUF releases

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#flint-gguf-releases)

`flint_gguf` ([`flint.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/flint.py)
) imports Flint from a llama.cpp GGUF of `RecursiveSI/flint` with `--model` holding the Hugging Face release's `config.json`, tokenizer, `chat_template.jinja` and `generation_config.json` and `--source gguf=...` the GGUF. It checks the GGUF's metadata against the config (the block geometry, the sliding-window and rotation patterns, the RoPE base, sigmoid gating with normalized weights, the expert widths) and imports every row as stored: llama.cpp keeps the experts' gate and up projections as two banks, which the artifact interleaves per expert (\[gate rows; up rows\] of expert 0, then expert 1), moving whole rows only. Commands, runtime defaults and measurements: [Flint](https://github.com/iamwavecut/ninfer-all/blob/master/docs/flint.md)
.

### DeepSeek-V4.1-Flash GGUF releases

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#deepseek-v41-flash-gguf-releases)

`deepseek_v41_gguf` ([`deepseek_v41.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/deepseek_v41.py)
) imports DeepSeek-V4.1-Flash from ISTA-DASLab's split GGUF with `--model` holding the base release's `config.json` and tokenizer, `--source gguf=` the first shard (the others are found beside it) and `--source engram=` the Engram GGUF. It reads both layouts of these GGUFs and converts either to the same artifact: llama.cpp's own (b11870 and newer, ISTA-DASLab's files since 2026-10-27), whose split ends with the Engram GGUF as its last shard (a link beside the others, or absent), and the earlier layout of ISTA-DASLab's llama.cpp branch. It checks the GGUF's metadata against the config (the block geometry, the compression ratios, the hyper-connections, the expert widths and scale, the Engram blocks and the ranges of their hash constants) and imports every row as stored. A build with fewer routed experts per block than the release, such as the Coder, converts with its GGUF's expert count. The release ships no Jinja chat template: the recipe stores its own transcription of the release's encoder and generation defaults ([`templates/deepseek_v41`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/templates/deepseek_v41)
) unless `--model` or `--resource` provides them. `--components text` stores the model alone, naming its table by the SHA-256 of its rows, and `engram` that table artifact, the layout the published conversions use; `text,engram` (the default) stores both in one file. `--resource engram.hot=PATH` stores a hot-row profile made by `ninfer-ngram-profile` beside the stored Engram table as `engram.resources.hot_profile`, after checking its row IDs and the Engram hash and token map it was counted for against `--source gguf`, which a table alone then also needs; the table's bytes and digest stay the same. Commands, runtime defaults and measurements: [DeepSeek-V4.1-Flash](https://github.com/iamwavecut/ninfer-all/blob/master/docs/deepseek-v41.md)
.

Change part of a recipe
-----------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#change-part-of-a-recipe)

Save the following as `my_recipe.py`:

```python
from tools.convert.official_recipes import qwen3_6_27b


def configure(model, recipe, sources):
    qwen3_6_27b(model, recipe, sources)
    recipe.assign(
        "text/layers/0/mlp/down",
        format="q6_g64_fp16",
        method="grouped_absmax",
    )
```

Run it with the same source and component selection:

```shell
python3 -m tools.convert \
  --model /path/to/Qwen3.6-27B \
  --recipe my_recipe.py \
  --components text,vision,mtp \
  --proposal \
  --out models/my_qwen.ninfer
```

The default entry function is `configure`; `--recipe my_recipe.py:customize` selects another function. Alternatively, use an official `--recipe` and put only the changes in an `--override` file. Overrides run after the base recipe and optional proposal-head setup.

`model.parameters` maps logical names to their shape, source and mathematical inputs. To see the available names for your selected components, a recipe can print them:

```python
for name, parameter in model.parameters.items():
    print(name, parameter.shape, parameter.inputs)
```

`recipe.assign` accepts one name, a list of names, or shell-style patterns such as `text/layers/*/mlp/down`. A selector that matches nothing fails. Assignments run in Python order; later assignments replace only the explicitly supplied choices. Changing `format` does not automatically change `method`. Use `layout="auto"` to select the registered layout for the format when overriding an earlier explicit layout choice.

The principal choices are:

| Argument | Meaning |
| --- | --- |
| `format` | Persistent numeric format |
| `layout` | Physical encoding; inferred from format unless explicitly set |
| `method` | Built-in method name or Python callable |
| `source` | Logical values or encoded rows from the selected source |
| `parameters` | JSON-serializable numerical parameters passed to the method |
| `rows=(begin, end)` | Override complete leading-axis rows in a half-open range |
| `activation_policy` | Permission for activation precision at the parameter's mathematical inputs |

For example, `rows=(0, 128)` can give the first 128 rows a different format. This creates multiple physical parts when necessary. The container can represent that result; the intended Op must also support consuming those parts. Current native projections generally require a contiguous parent region, so arbitrary splits of one projection are not automatically executable.

Formats, methods and activation precision
-----------------------------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#formats-methods-and-activation-precision)

The converter currently writes these formats:

| Format | Built-in method for floating-point input | Import of already encoded input |
| --- | --- | --- |
| `bf16`, `fp32`, `int32`, `fp16`, `uint16` | `cast_direct` (`fp16` only from values it represents exactly, `uint16` only from unsigned 16-bit words) | Direct words through the source reader |
| `q4_g64_fp16`, `q5_g64_fp16`, `q6_g64_fp16`, `q8_g32_fp16` | `grouped_absmax`, `grouped_search` | Supply a custom method/source if needed |
| `fp8_e4m3fn_row_bf16` | `fp8_row_maxabs` | `import_encoded` |
| `nvfp4` | Supply a custom quantizer | `import_encoded` |

`grouped_absmax` stores one FP16 scale per group and signed integer codes. `grouped_search` stores the same words but picks each group's scale from about seventy candidates by the rounding error weighted with an activation importance matrix, and never does worse than `grouped_absmax` under that error. Its parameters are `imatrix` (a file written by `tools.convert.imatrix`) and `negative_scales` (default false), which admits signed scales that map a group's largest positive value onto the most negative code:

```shell
python3 -m tools.convert.imatrix --gguf imatrix.gguf \
  --config /path/to/Qwen3.8-27B/config.json --out qwen3_8_27b.imatrix.safetensors
```

```python
recipe.assign(name, format="q4_g64_fp16", method="grouped_search",
              parameters={"imatrix": "qwen3_8_27b.imatrix.safetensors", "negative_scales": True})
```

The importance file comes from a llama.cpp `llama-imatrix` run over calibration text. Parameters it does not cover (the embedding, the output head, MTP and draft components) are searched with equal channel weights. The search runs on `--device`; a CUDA device is much faster than the CPU.

`fp8_row_maxabs` first rounds input values to BF16, then produces E4M3FN codes and one BF16 multiplier per row. `import_encoded` preserves compatible code and scale words, including NVFP4's matrix weight divisor. It does not dequantize and requantize them.



</details>

<details><summary>Tool result · context_read · call_d61242fd7bb14cd295183b83</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md · section 4/5
Subsection: MTP, vision, and DFlash2 from GGUF
Tags: code, table

The exact numeric and packing rules are in [numeric formats](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/tensor-formats.md)
 and [storage layouts](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/storage-layouts.md)
. Source format names alone do not establish compatibility: scale direction, granularity, code meaning and axis order must also match.

Activation permissions are independent of the stored weight format:

| Policy | Permitted activation paths |
| --- | --- |
| `A16Only` | A16 |
| `AllowA8` | A16, A8 |
| `AllowA4` | A16, A8, A4 |

They permit choices; they do not force a kernel to use the lowest precision. A fused operation that shares one activation across several projections must respect the intersection of their permissions. `recipe.use(parameter, input_name, ...)` can set one mathematical input independently; the names are available in `parameter.inputs`.

An NVFP4 A4 input requires a positive finite activation divisor. `import_encoded` obtains it from the selected source, or a recipe supplies it through `recipe.use(..., auxiliaries={"activation_input_divisor": value})`. Shared weights retain separate Use records; sharing weights does not share calibration implicitly.

Fused parents and logical projections
-------------------------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#fused-parents-and-logical-projections)

The Qwen adapter exposes Q, K, gate and V separately, even when they came from fused source tensors. It also supplies finite packing groups for attention, GDN, MLP and MoE. Compatible selections are packed into a shared parent automatically by the built-in methods.

For the Dense groupwise recipe, attention Q/K form one Q4 parent and gate/V form one Q5 parent. The native fused Op receives two weights. To use the supported single-parent FP8 form, an override can assign all four projections together:

```python
def configure(model, recipe, sources):
    for layer, kind in enumerate(model.config["layer_types"]):
        if kind != "full_attention":
            continue
        prefix = f"text/layers/{layer}/attention/"
        recipe.assign(
            [prefix + role for role in ("query", "key", "gate", "value")],
            format="fp8_e4m3fn_row_bf16",
            layout="auto",
            method="fp8_row_maxabs",
            activation_policy="AllowA8",
        )
```

Use this file as `--override` after `qwen3_6_27b` or `qwen3_8_27b`. It leaves the other parameters under that recipe. The adapter handles source Q/gate row order; the override works with logical projections. Changing their representation can change numerical results and the physical kernels.

For explicit organization, `recipe.group([names...])` concatenates compatible selections in the given order, `recipe.separate(names)` disables automatic grouping for those parameters, and `recipe.share(parameter, target)` binds equal-shaped parameters to the same physical data. Explicit groups must be disjoint and use unsplit selections with matching format, layout, method and method parameters. NVFP4 parents also require a common weight divisor. Automatic grouping is limited to built-in methods; custom methods can request explicit groups.

Grouping chooses storage. Model execution code chooses the supported fused implementation. The loader uploads the stored representation, without repacking an inconvenient arrangement.

Read another source
-------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#read-another-source)

`--model` supplies the main config, default resources and the source named `base`. Add other Safetensors sources with repeated `--source NAME=PATH`; they are opened when used. Single-file Safetensors and indexed shards are supported. Additional tensor-only sources can omit model config; sources carrying config are checked against the relevant model geometry.

To replace a logical parameter from another compatible checkpoint in a recipe:

```python
name = "text/layers/0/mlp/down"
recipe.assign(
    name,
    source=model.source(name, sources["alternate"]),
    format="q6_g64_fp16",
    method="grouped_absmax",
)
```

Supply `--source alternate=/path/to/alternate-checkpoint`. `model.source` applies the architecture's source-name and axis mapping, including Q/gate extraction. The built-in compressed-tensors reader understands the implemented per-row FP8 and NVFP4 code/scale conventions. It can expose decoded values for another quantizer or encoded rows for exact import.

For another file format or quantization convention, provide a `LogicalSource`. Its value reader accepts flat C-order element bounds and returns exactly that range. For example, a recipe can read a logical matrix from a NumPy file stored beside the recipe:

```python
from pathlib import Path
import numpy as np
import torch
from tools.convert.sources.logical import LogicalSource


def configure(model, recipe, sources):
    name = "text/layers/0/mlp/down"
    path = Path(__file__).with_name("mlp-down.npy")
    data = np.load(path, mmap_mode="r")
    if tuple(data.shape) != model.parameters[name].shape or not data.flags.c_contiguous:
        raise ValueError("mlp-down.npy must have the logical shape and C-order storage")

    def read_values(begin, end):
        values = data.reshape(-1)[begin:end].astype(np.float32, copy=True)
        return torch.from_numpy(values)

    source = LogicalSource(tuple(data.shape), str(path), read_values)
    recipe.assign(name, source=source, format="q6_g64_fp16", method="grouped_absmax")
```

Use this as an override. The NumPy file must already follow the logical row/column order. For an unfamiliar quantized source, its reader performs the corresponding decoding before returning values. To preserve existing compatible encoded words, also provide `read_encoded` returning `EncodedRows`, and the format's required divisor accessors. Their definitions are in [`sources/logical.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/sources/logical.py)
.

Convert from a GGUF quant instead of the full checkpoint
--------------------------------------------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#convert-from-a-gguf-quant-instead-of-the-full-checkpoint)

The base `--model` checkpoint only needs to supply `config.json` and the frontend resources (tokenizer, chat template, generation config); it does not need every weight tensor present. If you already have a GGUF export of the model -- F16, or a ggml quant level such as `Q8_0` or `Q4_K_M` -- an override recipe can read the actual tensor values from that file instead of downloading the multi-gigabyte Safetensors checkpoint again. Keep only the checkpoint's small config/tokenizer files locally, and pass the GGUF file as a named `--source`:

```shell
python3 -m tools.convert \
  --model /path/to/checkpoint-config-only \
  --recipe qwen3_6_27b \
  --source quantized=/path/to/model-Q4_K_M.gguf \
  --override use_gguf_source.py \
  --out models/my_qwen.ninfer
```

`tools/convert/sources/gguf_source.py` reads the GGUF file (via the `gguf` package -- `pip install gguf`; it performs the actual block dequantization, since GGUF's quant byte layouts are intricate enough that reusing the maintained ggml-org reader beats reimplementing them) and exposes its tensors as FP32 values. Because GGUF tensor names never match the HF Safetensors names a recipe's `source_name`s are written against (`model.layers.0.self_attn.q_proj.weight` vs. `blk.0.attn_q.weight`), and some architectures reorder tensors on export, `HFAliasSource` wraps a `GGUFSource` with an explicit `{hf_name: gguf_name}` map (plus optional per-tensor transforms) so it satisfies the same interface a recipe already expects from `sources["..."]`.

`use_gguf_source.py`:

```python
from tools.convert.sources.gguf_source import HFAliasSource, standard_dense_name_map


def configure(model, recipe, sources):
    gguf_source = sources["quantized"]  # opened as a GGUFSource because the path ends in .gguf
    name_map, transforms, shapes = standard_dense_name_map(
        model.config["num_hidden_layers"],
        tie_word_embeddings=model.config["tie_word_embeddings"],
        text_prefix="model.language_model.",  # "model." for a text-only (non-vision) checkpoint
    )
    quantized = HFAliasSource(gguf_source, name_map, transforms=transforms, shapes=shapes)
    for name, parameter in model.parameters.items():
        if parameter.source_factory is None:
            continue
        recipe.assign(name, source=model.source(name, quantized))
```

Parameters whose HF source name isn't in `name_map` (mixture-of-experts routing, MTP, vision, ...) fail with a clear "no GGUF tensor mapped for ..." error rather than silently reading the wrong bytes; extend `name_map`/`transforms` for those before assigning them too, or leave them assigned to the base recipe's original source by only looping over the names you've actually mapped.

### MTP, vision, and DFlash2 from GGUF

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md#mtp-vision-and-dflash2-from-gguf)

`--components text,vision,mtp,dflash2` works with GGUF sources too, matching a normal multi-component conversion, though each component needs its own wiring:

*   **MTP** is usually exported as a _separate_ GGUF file (llama.cpp names these `mtp-*.gguf`), not fused into the main model's file. It appears as one more transformer layer appended after the base model's real layers (layer 64 for a 64-layer model), reusing the same attention/MLP/norm tensor roles `standard_dense_name_map` already covers, plus four MTP-specific tensors. `qwen35_mtp_name_map(gguf_layer_index, hf_prefix=...)` builds that map -- `hf_prefix="mtp."` when the MTP tensors are fused into the main checkpoint's state dict, or `hf_prefix=""` for a standalone MTP-only checkpoint whose tensors have no prefix. Pass it its own `--source mtp_quantized=mtp-*.gguf` and wrap that in its own `HFAliasSource`.

*   **Vision** is exported as a separate `mmproj-*.gguf` file (GGUF architecture `clip`, not the text model's `qwen35`/`qwen35moe`) covering the ViT tower and the projector MLP. `qwen35_vision_name_map(depth, hidden_size=..., patch_size=..., temporal_patch_size=..., ...)` builds its name map from the checkpoint's own `vision_config`. It also needs a `--source vision_quantized=mmproj-*.gguf`. One tensor needs more than a name/value transform: the patch-embed Conv3d kernel's temporal dimension is split across two separate GGUF tensors (`v.patch_embd.weight` / `.weight.1`), which `HFAliasSource`'s `composites` argument reassembles by reading both from the underlying `GGUFSource` and stacking them -- see its docstring if you need the same pattern elsewhere.

*   **DFlash2** needs no GGUF-specific code at all in the cases seen so far: it's a small enough draft head that a plain Safetensors checkpoint for it is the normal way to get one, and `tools.convert` already reads that natively via `--source dflash2=PATH` plus `--components ...,dflash2` -- the same mechanism `qwen3_8_27b_nvfp4`'s example in this doc already uses. An override recipe only needs to touch `dflash2/*` parameters if you actually have a GGUF export of the draft head to source them from instead.




</details>

## Assistant · #66

<details><summary>Reasoning · 8,847 characters</summary>

This gives key Q3: FP8 table supported but not published, improved perplexity 1.25% (worse code domains) for 80% more storage; IQ4_NL release representation. Shockem Q8PLE is similar tradeoff; NInfer can store FP8 table from HF BF16, but import of FP8 checkpoint's n-gram encoding not implemented for HF recipe? Need distinguish:

- For `qwen3_8_flash_next` HF-source recipe, PLE source can be IQ4_NL GGUF or HF BF16 shards. HF rows become FP8 E4M3FN row fp16. FP8 table supported but not published; improved perplexity 1.25% for 80% more storage. Import of FP8 checkpoint's own n-gram encoding not implemented.
- For `qwen3_8_flash_next_gguf`, ngram source is release second shard IQ4_NL. It keeps release's IQ4_NL rows. But runtime accepts any table of same hash constants/geometry in any row format. Published table is IQ4_NL. Could one make Q8 table? Need maybe "any row format" not necessarily all formats? It says "in any row format" likely any supported: IQ4_NL, FP8. Maybe Q8_0 gguf? Need read "another table of same shape" section. It might specify supported row formats. Let's search qwen3-8-flash-next.md section maybe 5? The section list: section 5 "Count rows corpus addresses: UTF-8 files, or .jsonl..." Actually not. Need find "another table of the same shape" anchor. Could be section 1? The doc section 1 includes top with conversion and maybe another table? It might be truncated. Need maybe read section 1 more (already top) no anchor. Could use resource_search? resource_search only for a501cadf, not this. Maybe web_scrape raw with URL? It returns indexed sections. Could use web_scrape raw qwen3-8-flash-next.md? We already have indexed 12 sections. Could read section 1 and maybe section 2. The anchor may be in section 1? Let's read section 1? Already from web_scrape top section 1? The tool output only top? It didn't show section 1 content in web_scrape, but we can context_read section 1? We did? For c3be2147 we did section 2. Need read section 1 maybe full first 11k; already saw top from web_scrape? It showed skip to content and beginning up to Convert. The anchor "another table of the same shape" probably in Run / ngram rows section. Could search by reading sections 5-8 maybe. But not essential.

Need Q1: "How hard is it to make that exact ngram table for the shockem model, to have a nearly byte identical model under .ninfer artifact." Need assess: If exact ngram table Q8PLE from Shockem: Need extract table. Hard? For NInfer, if you want same PLE representation as Shockem, you need Q8_0 rows. NInfer published path expects IQ4_NL GGUF table. There is no direct .basalt source. You could use Shockem's .basalt or official Basalt NVFP4 pack, extract `gguf` section's `per_layer_token_embd.weight` Q8_0 tensor, write a synthetic GGUF or NInfer table artifact. How hard? Maybe moderate: one custom converter script. If starting from Shockem's source GGUF (SC117 IQ3_S model shard and IQ4 table shard), then NInfer conversion is straightforward for IQ4 table, but not Q8PLE. To make exact Q8PLE, you need replace IQ4 rows with Q8 rows. You can do that offline:

1. Download Shockem .basalt (105.7 GB) or previous Q8PLE pack; identify section `gguf`, tensor `per_layer_token_embd.weight` with shape [160,320001536] Q8_0, size 54,400,261,120 bytes, SHA-256 e02bf...
2. Extract section bytes at tensor offset, or use Basalt `tools/model_file.py` / migration utilities to read sections.
3. Write a GGUF file with `general.architecture: qwen4exp` metadata and one tensor `per_layer_token_embd.weight` type Q8_0, shape [160,320001536]? Or convert directly to `.ninfer` with `--components ngram --source ngram=that_gguf`.
But the NInfer ngram recipe expects table shard to be a GGUF containing `per_layer_token_embd.weight`? The official table shard is a GGUF with that tensor. It records hash constants and geometry. It says every GSQ-RCO release is two GGUF shards: the model, and 28.8 GB n-gram table of the model's per-layer embedding. So yes, synthetic GGUF with the tensor and metadata may work, if metadata matches. But the Q8_0 table row bytes are from NVIDIA FP8 table reblocked to Q8_0. If NInfer can read Q8_0 GGUF tensor as gguf_blocks_v1? The `gguf_blocks_v1` supports Q8_0. The ngram component row format can be Q8_0? The doc says IQ4_NL release's table byte for byte; runtime derives hash constants and refuses table that disagrees; accepts any table of same hash constants and geometry, in any row format. If row format can be Q8_0, yes. If only row formats supported for table are IQ4_NL and FP8, maybe Q8_0 may need support? Basalt reads Q8_0 PLE. NInfer's GGUF runtime supports Q8_0 linear ops, but PLE table might require specialized row addressing; row format may be arbitrary block format? Storage layout has row_interleaved_v1 for FP8 table with K=160, and gguf_blocks_v1 for matrices. For ngram table, maybe row addressing requires block_values divides 160. Q8_0 block_values=32, 160/32=5. It can address row by whole blocks. So likely feasible.

But "nearly byte identical model under .ninfer artifact" - impossible byte identical because container differs, metadata, object offsets, hyperconnection requantization, MTP donor. But weights can be byte-for-byte for GGUF blocks except HC? For Shockem .basalt has `hc8` int8 hyperconnections, while NInfer stores Q8_0 hyperconnections? Basalt hc8 may be exactly Q8_0? Basalt precision: hyper-connections int8 copy one fp16 scale per 32 inputs. It is likely same Q8_0. But the Shockem pack's hc8 computed from file's own hyperconnection matrices (Basalt converter computes hc8). NInfer re-quantizes BF16 hyperconnections to Q8_0. If both use ggml reference rounding from same BF16, maybe identical? But Shockem's source was official IQ3_S Basalt pack, not direct GGUF? Its GGUF sections have original BF16? Basalt `convert.py --compat-bf16` and hc8 computed. NInfer from GGUF would also requantize HC to Q8_0. Could match if rounding same. But MTP differs: Shockem uses self-distilled MTP from official Basalt pack; NInfer uses Unsloth shared-Q8_0 MTP. To match Shockem's MTP, need source the same MTP donor and import as NInfer component. Basalt's mtp section is raw mtp runtime directory (dense/experts/draft_vocab) maybe not GGUF. NInfer expects an MTP GGUF. If Shockem's MTP donor is official Basalt self-distilled `mtp/dense`, not available as GGUF; hard to make identical. If you only care model quality, use NInfer's standard MTP/DFlash2.

Need Q2: compute for making .ninfer/.basalt. Need estimate from docs.

Basalt:
- convert.py streamed; for 27B QUASAR NVFP4 "about a minute on default 16 converter processes". But that's small 20GB. Flash-Next .basalt from GGUF likely 100GB, disk-bound. Basalt docs model-file: official NVFP4 output about 122 GiB; conversion reads safetensors directly, experts move bit for bit, dense quantized once. Not explicit time. Basalt migration v1->v2: without download, copies sections, checks SHA. For 100GB, I/O-bound. On fast NVMe maybe 10-30 min per read/write pass (200GB+). On HDD maybe hours. CPU not bottleneck; Python with multiprocessing maybe moderate. 5090 doesn't matter much; Basalt convert is CPU/disk. For Shockem's actual replacement: after conversion, ngram IQ4 replaced with Q8 byte for byte; likely minutes to tens of minutes depending disk.

NInfer:
- converter uses Python 3.11 + PyTorch; CUDA by default, `--device cpu`; PyTorch threads per CPU. For GGUF recipe, mostly byte copying and metadata transforms; HC requantization maybe on CPU/GPU? It re-quantizes BF16 hyperconnections to Q8_0. If `--device cpu`, uses CPU; CUDA may be faster for imatrix/grouped_search but not necessarily GGUF import. Docs: "Every conversion containing PLE reads the table shard once more to hash it (a minute or so for 28.8 GB), since model records digest." This suggests table hashing ~1 min on some system; reading 54GB Q8 maybe ~2 min. Main conversion likely dominated by I/O: read 55GB GGUF model + 29GB table + output 54GB + table 29GB; total ~170GB. On NVMe 3GB/s, ~1 min raw; with overhead maybe 10-30 min. On HDD, hours. For Q8 table, total read/write ~220GB, maybe 20-60 min on fast NVMe, 1-3h on slow. Python overhead can be significant; but converter is optimized with chunks and CPU/GPU. 5090 GPU helps only for quantization transforms (grouped_search/imatrix, FP8/NVFP4 checkpoint), not byte-for-byte GGUF pack. The 64GB DDR5 helps; conversion can be done with CPU. No days.

Need perhaps find conversion time evidence: For DFlash2 attachment: 339MB appended. For NInfer artifact conversion of 27B? Search? The docs may have no explicit. Could infer from "about a minute" for table hashing and "about a minute" for Basalt 27B. Need maybe search tool for "minutes" in ninfer-all? Could use web_search maybe denied. Maybe use context_read of tools/README? Could scrape tools convert README.


</details>

<details><summary>Tool request · web_scrape · call_bed718126b20424f987c022f</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_fa7b4186f104453cb7d45086</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/README.md"
}
```

</details>

<details><summary>Tool request · web_scrape · call_a61e3c5e61a440149659d8c5</summary>

```json
{
  "url": "https://github.com/jesdga95/basalt/blob/main/tools/migrations/README.md"
}
```

</details>


<details><summary>Tool result · web_scrape · call_bed718126b20424f987c022f</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

FilesExpand file tree


-----------------------

master

/

README.md
=========

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/tools/README.md)

[](https://github.com/iamwavecut/ninfer-all/commits/master/tools/README.md)
History

125 lines (97 loc) · 5.71 KB

master

/

README.md
=========

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


125 lines (97 loc) · 5.71 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/tools/README.md)

Copy raw file

Download raw file

Outline

Edit and raw actions

NInfer tools
============

[](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md#ninfer-tools)

`tools/` contains artifact conversion and inspection, benchmark orchestration, and serving smoke checks. To download and run an existing artifact, start with the [project README](https://github.com/iamwavecut/ninfer-all/blob/master/README.md)
. To build your own weights, use the [weight conversion guide](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md)
.

Run commands from the repository root with a Python environment containing the dependencies for the selected tool. The maintained environment uses Python 3.11.

Python tools are independent of CMake; there is no `NINFER_BUILD_TOOLS` option.

Task index
----------

[](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md#task-index)

| Task | Location |
| --- | --- |
| Convert weights with an official or custom recipe | [`convert/`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert)<br>; [user guide](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md) |
| Inspect artifact metadata and objects | [`artifact/inspect.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/artifact/inspect.py) |
| Count the bytes one decoded token reads (roofline denominator) | [`decode_byte_accounting.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/decode_byte_accounting.py) |
| Measure the card's sustained memory bandwidth | [`hbm_bandwidth_probe.cu`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/hbm_bandwidth_probe.cu) |
| One-time upgrade of official v2 artifacts | [`upgrade_ninfer_v2_to_v3.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/upgrade_ninfer_v2_to_v3.py)<br>, with positional `INPUT OUTPUT` paths |
| Run benchmark matrices | [`bench/`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/bench/README.md) |
| Reference measurements against a running server (the suites behind the [reference tables](https://github.com/iamwavecut/ninfer-all/blob/master/docs/performance/reference-2026-09.md)<br>) | [`bench/refbench.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/bench/README.md#reference-measurements-refbenchpy) |
| FP64 reference forward of Qwen3.8-Flash-Next for golden tensors | [`reference/qwen4_exp.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/reference/qwen4_exp.py) |
| FP64 reference forward of Gemma 4 26B-A4B over its GGUF: golden tensors, per-token NLL and the assistant's drafts | [`reference/gemma4.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/reference/gemma4.py) |
| Measure external Serve TTFT | [`bench/ttft/`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/bench/ttft/README.md) |
| Watch a resident server: dashboard, and restart on a wedge | [`monitor/`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/monitor/README.md) |
| Check long-context recall, cold prefill against a cached prefix | [`longctx_recall_probe.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/longctx_recall_probe.py) |
| Exercise a resident HTTP server | [`smoke/serve_contract.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/smoke/serve_contract.py) |
| Exercise thinking preservation through a managed server | [`smoke/serve_thinking_preservation.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/smoke/serve_thinking_preservation.py) |
| Measure the physical HBM read/copy ceiling | [`hbm_bandwidth_probe.cu`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/hbm_bandwidth_probe.cu)<br>; [build command](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md#standalone-hbm-probe) |

Standalone HBM probe
--------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md#standalone-hbm-probe)

This maintainer probe has an explicit standalone CUDA build, independent of the CMake benchmark targets. Build it with the project's CUDA toolkit for the card's architecture (`sm_86` for the RTX 30 and 40 series, `sm_120a` for Blackwell) and run it from the repository root:

```shell
mkdir -p build
nvcc -O3 -std=c++17 -arch=sm_86 tools/hbm_bandwidth_probe.cu \
  -o build/hbm_bandwidth_probe
./build/hbm_bandwidth_probe
```

The other `*_probe.cu` files in this directory are one-off measurements built the same way; most give their purpose and build command at the top of the file.

Artifact workflow
-----------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md#artifact-workflow)

The common converter reads selected local sources and writes a `.ninfer` artifact plus its `.conversion.json` report. These examples include the optional weights used by the official artifacts. The input paths are placeholders for local checkpoint checkouts:

```shell
python3 -m tools.convert \
  --model /path/to/Qwen3.6-27B \
  --recipe qwen3_6_27b --components text,vision,mtp --proposal \
  --resource chat_template.jinja=tools/chat_templates/qwen3_6.jinja \
  --name qwen3.6-27b \
  --out out/qwen3_6_27b.ninfer

python3 -m tools.convert \
  --model /path/to/Qwen3.8-27B \
  --recipe qwen3_8_27b --components text,vision,mtp,dflash2 --proposal \
  --source dflash2=/path/to/Qwen3.8-27B-DFlash2 \
  --resource chat_template.jinja=tools/chat_templates/qwen3_8.jinja \
  --name qwen3.8-27b \
  --out out/qwen3_8_27b.ninfer

python3 -m tools.convert \
  --model /path/to/Qwen3.6-35B-A3B-base \
  --recipe qwen3_6_35b_a3b --components text,vision,mtp,dflash --proposal \
  --source dflash=/path/to/Qwen3.6-35B-A3B-DFlash \
  --resource chat_template.jinja=tools/chat_templates/qwen3_6.jinja \
  --name qwen3.6-35b-a3b \
  --out out/qwen3_6_35b_a3b.ninfer
```

Inspect a result:

```shell
python3 -m tools.artifact.inspect out/qwen3_6_27b.ninfer --objects
```

Recipes, mixed sources, custom methods, resources and sharding are described in the [conversion guide](https://github.com/iamwavecut/ninfer-all/blob/master/docs/weight-conversion.md)
. Numeric formats, layouts and framing are defined by the references linked from the [documentation map](https://github.com/iamwavecut/ninfer-all/blob/master/docs/README.md)
.

Benchmark orchestration
-----------------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md#benchmark-orchestration)

`tools/bench/run_ninfer_bench_matrix.py` builds and runs the public-Engine benchmark matrix and writes ignored local reports below `profiles/bench/`:

```shell
python3 tools/bench/run_ninfer_bench_matrix.py --preset core --dry-run
python3 tools/bench/run_ninfer_bench_matrix.py --preset core
```

See [`tools/bench/README.md`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/bench/README.md)
 and [`bench/README.md`](https://github.com/iamwavecut/ninfer-all/blob/master/bench/README.md)
 for the orchestrator and executable contracts.

For request-arrival latency, use the managed Qwen3.8-27B NVFP4/FP8 TTFT campaign. Its measurement runner remains an external-only HTTP client; the separate controller owns Serve lifecycle and artifacts. See [`tools/bench/ttft/README.md`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/bench/ttft/README.md)
.

Serving smoke
-------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/tools/README.md#serving-smoke)

After starting `ninfer-serve` in another terminal:

```shell
python3 -m tools.smoke.serve_contract \
  --base-url http://127.0.0.1:18080 \
  --model qwen3.6-27b
```

The client exercises OpenAI, Anthropic, streaming, usage, multimodal, and tool-call response surfaces against the resident process.

For typed rewrite-checkpoint and thinking-history behavior, the managed smoke script launches a real server and consumes the repository fixture:

```shell
python3 tools/smoke/serve_thinking_preservation.py \
  --artifact out/qwen3_6_27b.ninfer --backend mtp
```

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_fa7b4186f104453cb7d45086</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/README.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/README.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/README.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/README.md)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

404 - page not found
--------------------

The master branch of **ninfer-all** does not contain the path **tools/convert/README.md.**

[Return to the repository overview](https://github.com/iamwavecut/ninfer-all)

You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_a61e3c5e61a440149659d8c5</summary>

[Skip to content](https://github.com/jesdga95/basalt/blob/main/tools/migrations/README.md#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/tools/migrations/README.md)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/tools/migrations/README.md)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/jesdga95/basalt/blob/main/tools/migrations/README.md)
 to refresh your session. Dismiss alert



[](https://github.com/jesdga95/basalt)

FilesExpand file tree


-----------------------

main

/

README.md
=========

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/jesdga95/basalt/commits/main/tools/migrations/README.md)

[](https://github.com/jesdga95/basalt/commits/main/tools/migrations/README.md)
History

21 lines (16 loc) · 1.19 KB

main

/

README.md
=========

Copy path

Top

File metadata and controls
--------------------------

*   Preview

*   Code

*   Blame


21 lines (16 loc) · 1.19 KB

[Raw](https://github.com/jesdga95/basalt/raw/refs/heads/main/tools/migrations/README.md)

Copy raw file

Download raw file

Edit and raw actions

Migration
=========

[](https://github.com/jesdga95/basalt/blob/main/tools/migrations/README.md#migration)

`basalt_v1_to_v2.py` turns a version 1 `.basalt` file into a version 2 file, which is what the engine reads. Nothing is downloaded or re-quantized: every model section is copied byte for byte, the expert profile is dropped (the engine ships its own, [data/profiles](https://github.com/jesdga95/basalt/blob/main/data/profiles)
), and the 8-bit hyper-connection table (`hc8`) is computed from the file's own matrices, bit for bit what the engine used to compute at every start.

```shell
python3 tools/migrations/basalt_v1_to_v2.py Qwen3.8-FN-NVFP4.basalt Qwen3.8-FN-NVFP4.v2.basalt
```

It needs Python 3.10+ with numpy, and free disk space for a second copy of the file. The old file is only read; delete it once the new one runs. What changed between the versions: [the file format changelog](https://github.com/jesdga95/basalt/blob/main/docs/basalt-file-changelog.md)
.

`config_v1_to_v2.py` turns a single-model server config (`"server"` naming the model, `"engine"` its flags) into the v2 shape with `"models"`, which is what the server reads ([configuration](https://github.com/jesdga95/basalt/blob/main/docs/configuration/models.md)
). The old file is only read: it prints the new one, or writes it to a new file with `-o`.

```shell
python3 tools/migrations/config_v1_to_v2.py basalt_config.json -o basalt_config.v2.json
```

You can’t perform that action at this time.

</details>

## Assistant · #70

<details><summary>Reasoning · 40,775 characters</summary>

Need maybe answer Q4 about DFlash2 resource stress. Need know Flash-Next DFlash2 memory/stress. NInfer docs: DFlash2 drafter is 339 MB Q4_0, five sliding-window layers width 2560; appends to artifact; with host experts default uses DFlash2; on RTX 3090 host experts, default drafting faster than MTP; with device experts may shrink expert cache? The HF artifact card says: "with host experts NInfer drafts with DFlash2 unless --spec says otherwise". Measurements: one RTX 3090 host experts: default DFlash2 92.3, 77.9, 58.2 vs MTP 83.5, 73.4, 49.8 vs no drafts 59,57.5,45.9. Every answer same as no drafts. With four requests aggregate 1.04x code, 0.93x prose vs no drafts; MTP 0.89. Need mention on 5090 likely DFlash2 faster but verification rows add compute; it loads 339MB extra and uses drafter state. It does not need separate drafter for Shockem? DFlash2 for Flash-Next is model-specific? It is trained/adapted for Qwen3.8-Flash-Next, not quant-specific. Since Shockem's model is a GGUF transplant of residual-write tensors into GSQ-RCO IQ3_S, same architecture/tokenizer; DFlash2 adapter should work. But exact acceptance may differ slightly because abliterated residual writes can change logits; but likely similar. It doesn't need retraining. You use incoai DFlash2 / nazeshinjite Q4_0 GGUF.

Need answer: would identical dflash2 adaptation be more hard on system resources or near-identical to MTP? Need compare memory/compute.

NInfer: DFlash2 adds 339MB on disk; loads as component, small. During decode, it runs five sliding-window layers of width 2560 to propose up to 7/4 drafts, then target verifies. MTP adds 2.8GB (Unsloth shared Q8_0 MTP block) and proposes. DFlash2 has less memory than MTP (339MB vs 2.8GB) but uses extra drafter activations/state and verification rows. For Flash-Next, target verification dominates; drafter is small. The model card says with host experts default DFlash2 faster than MTP. It may reduce expert cache slightly due to 339MB; on tight 24GB card, that can matter. With 5090 32GB and Shockem IQ3_S experts maybe 46.84GB total; device-resident IQ3_S on one 32GB cannot hold all experts; host experts uses 48.7/50.3GB host pinned. 339MB extra is negligible. DFlash2 stress is near-identical or slightly lower weight read than MTP; compute slightly higher per proposed token but fewer target passes if accepted. It will not require a separate huge drafter. The main cost remains routed experts and PLE.

But Basalt currently MTP; DFlash2 in upstream Basalt? For Flash-Next, upstream Basalt docs says drafting MTP; DFlash2 is for 27B. So if you run Shockem under Basalt, DFlash2 not available unless you add it via decisive-basalt or NInfer. Under NInfer-all, yes.

Need maybe answer Q1 in more detail:

- If "exact ngram table" means exactly Shockem's Q8PLE rows: Not hard if you can extract the tensor from Shockem .basalt or source Q8 table. But NInfer's stock GGUF conversion expects a GGUF ngram shard. Shockem's source GGUF has IQ4_NL; Q8 table came from NVIDIA NVFP4 pack and is inside .basalt. You need an intermediate:
  - Option A: extract `per_layer_token_embd.weight` Q8_0 from `.basalt` `gguf` section and write a GGUF table shard. Then run NInfer conversion with `--components ngram --source ngram=<gguf>`.
  - Option B: convert the text model from SC117 GGUF without table (`--components text`) and then make a Q8 table artifact from extracted GGUF. Use `--ngram-table`.
  - Option C: if you only need "nearly byte identical model" but not exact Q8 table, use published IQ4_NL table. This is easy and published; the text weights can be converted byte-for-byte from the same GGUF, except hyperconnection requantization.
- "nearly byte identical" under .ninfer: text GGUF blocks can be byte-for-byte; container impossible. Shockem's pack was built from official Basalt pack, which itself derived from ISTA GGUF but with `--compat-bf16` and MTP/vision/hc8. The NInfer conversion from SC117 GGUF should match tensor values of the GGUF, but not byte identical to Shockem's `gguf` section due:
  - different section vs object packing, padding (2MiB vs 256B)
  - metadata JSON vs meta JSON
  - HC maybe identical if same rounding but not guaranteed
  - MTP donor (Basalt self-distilled vs Unsloth shared-Q8_0), unless you use same MTP source converted
  - profile removed / placement policy
  - tokenizer/chat template may differ (NInfer uses pinned template? For Flash-Next uses Qwen template; Shockem uses official pack)
  - DFlash2 attachment optional.

Need maybe mention exact source: Shockem pack "Experts come from SC117 ... GGUF; converted with Basalt tools/convert/convert.py --compat-bf16 --sections-from the official IQ3_S pack that already carries Q8 n-gram." Thus to make .ninfer from Shockem sources:
- Use SC117 IQ3_S shard 1 as model source.
- Use official IQ3_S pack's Q8 ngram? But it's .basalt; extract.
- Use official IQ3_S pack's MTP/vision/tokenizer? For NInfer, vision from mmproj BF16 GGUF; MTP from Unsloth shared-Q8_0 GGUF (not same as Basalt self-distilled). To mimic Shockem's MTP, need get Basalt `mtp/dense`, maybe convert to GGUF? Hard. If you're okay with NInfer's MTP/DFlash2, easy.

Need Q2 compute estimate in more concrete terms.

Let's calculate disk traffic:

NInfer conversion IQ4 table:
- Read model shard 54.8GB (GGUF IQ3_S), vision 0.9GB, MTP 2.8GB, maybe table shard 28.8GB, HF config negligible.
- Write model artifact 54.24GB (if components text,vision,mtp,dflash2) and table artifact 28.9GB if separate.
- Reads table shard twice? Docs: every conversion containing PLE reads table shard once more to hash it. If `--components text` and `ngram` separate maybe each conversion reads. If `text,ngram` one artifact, reads table shard once for data + once for hash = 57.6GB.
Total ~115GB + output 83GB = ~198GB. For Q8 table: read Q8 table 54.4GB once + hash 54.4 = 108.8; model output 54 + table 54 = 108; plus model 55 = 272GB.
On NVMe sustained 2-3 GB/s: 90-135s theoretical; with Python overhead, hashing, checksum, maybe 15-40 min. On SATA SSD 0.5GB/s: 6-10 min raw? Actually 200GB/0.5=400s=6.7 min raw, but overhead; maybe 20-60 min. On HDD 150MB/s: 200GB/0.15=1333s=22 min raw; overhead maybe 1-3h. If multiple passes maybe more. Not days.

Basalt convert .basalt from GGUF:
- Read model shard 54.8 + table 28.8 + mmproj 0.9 + MTP dense etc.
- Write .basalt 81GB (IQ4) or 105GB (Q8). Section alignment 2MiB padding minimal.
- SHA-256 of sections maybe read again for verification; migration checks sections. Total maybe 200-250GB. Basalt 27B conversion about a minute on 16 processes for 20GB, so Flash-Next ~5-10x data maybe 5-15 min on good hardware, plus hashing. On HDD maybe 1-3h. Not days. If using `--workers 16` likely CPU parallel. 5090 not used.

Need mention RAM: 64GB enough but not required. 32GB can do if streaming, but Basalt migration needs free disk for second copy; NInfer writes output and reads input, no need to hold all in RAM. PyTorch may allocate chunks; 64GB comfortable. For CUDA conversion, if using GPU, VRAM 32GB enough for quantization chunks; but don't try to load full 100GB in RAM. If using HF BF16 full checkpoint (500GB?) conversion much heavier, may need disk space and time. But from GGUF quant, not days.

Need Q3: Does ninfer-all still benefit from additive Q8PLE? Need nuanced:
- There is no "additive Q8PLE" component in published NInfer artifacts. It's not that the model lacks PLE; PLE is mandatory and included as table. It is simply not published as Q8_0.
- The docs explicitly evaluate FP8 PLE (162-byte rows) vs IQ4_NL (90-byte rows): 80% more storage, held-out perplexity improved 1.25%, but worse on code domains; IQ4_NL remains release representation. Q8_0 is similar tradeoff (170-byte rows; Basalt says cosine 0.997 vs IQ4, about 8% RMS). Benefit is likely small and mixed; not a free quality boost. It increases per-token PLE traffic: each token reads 16 rows. IQ4 row 90B; Q8 row 170B; extra traffic 80B*16=1280B per token. At 100 tok/s, extra 128KB/s decode, negligible compared to expert reads? Actually 128 KB/s is tiny compared to GB/s expert reads. But table may be in file/page cache; extra 25GB disk footprint. On a 5090 host with experts in RAM, PLE reads from disk may be more important if not RAM-hot; but docs say each token reads 16 rows (1.4KB IQ4) from file unless ngram RAM; Q8 2.7KB. Still modest.
- NInfer can make FP8 table from HF BF16 shards; not published. For Shockem's Q8_0 specifically, need custom source as above. If you want exact Q8 from Shockem's .basalt, doable but custom. If you want quality equivalent to NVIDIA FP8, NInfer can make FP8 table from HF checkpoint (not import NVIDIA FP8 checkpoint encoding). But from Shockem sources, Q8 table can be carried as Q8_0 GGUF if supported.
- "it's there, just no one has done it yet" mostly yes for table artifact: the model type and ngram component exist; published table is IQ4_NL. But Q8PLE specifically is not a stock published artifact and requires custom table extraction/repack. NInfer's recipe from GGUF keeps IQ4_NL; to get Q8, source must be Q8 GGUF or custom logical source. It should not require engine changes, only converter/ingestion work.

Need Q4 details: DFlash2 drafter found separately? Use incoai's Flash-Next DFlash2, nazeshinjite Q4_0 GGUF. It is not quant-specific; same drafter for GSQ IQ3_S, Unsloth, abliterated GGUF as long as same base model/tokenizer. It is attached to NInfer artifact as component. Under Basalt, not natively; under NInfer yes. If your Shockem model is abliterated via residual-write transplant, acceptance may slightly change but likely no special adaptation needed. You can test with `--spec dflash2 --draft-tokens 5` or default host experts.

Need perhaps mention DFlash2 resource profile:
- 339MB Q4_0; five sliding-window layers width 2560; reads model hidden states; proposes 4-7 tokens.
- MTP block is 2.8GB; MTP shares embeddings/head but adds extra layer/experts. DFlash2 has fewer params? It is small. It does not replace routed experts; target still reads same experts. The extra stress is mostly extra draft rows verification; with high acceptance (around 62-70% on short prompts from docs? Basalt MTP acceptance 62-70; NInfer DFlash2 maybe accepted? docs not acceptance but speed). For batch/multi-request, DFlash2 can have mixed aggregate: one model card says four requests 1.04x code, 0.93x prose. So not universally faster under concurrency; target verification width adds work. Single-stream likely faster.
- With 5090 32GB and 64GB RAM, DFlash2 is safe. 339MB can slightly reduce expert cache; if host experts, pinned host 48.7-50.3GB, plus DFlash2 maybe fits. If experts on disk, 339MB negligible. If every expert on GPU requires 53.7GiB on PRO 6000 or two 5090s; on one 32GB 5090 you cannot have all IQ3_S experts device-resident anyway. DFlash2 will not be the bottleneck.

Need maybe mention DFlash2 not identical to MTP setup: MTP is a one-layer QSA MTP block from model, 2.8GB; DFlash2 is separate 5-layer sliding-window block, 339MB, trained external. It uses different proposal distribution; verification still target. It may produce different speed/acceptance. Not "identical" but resource stress near or lower.

Need maybe mention if DFlash2 can be attached after conversion without converting whole model: script `scripts/pods/attach_dflash2.py` appends 339MB, other bytes unchanged. Good. Could mention exact command.

Need maybe answer "make that exact ngram table for shockem model, to have nearly byte identical model under .ninfer artifact" perhaps propose steps/recipe.

Potential exact plan:

A. Fastest low-risk path:
```
# config-only HF dir
hf download Qwen/Qwen3.8-Flash-Next --include config.json tokenizer.json tokenizer_config.json chat_template.jinja generation_config.json preprocessor_config.json video_preprocessor_config.json
# SC117 model shard and table shard
# official NInfer MTP GGUF and mmproj
python3.11 -m tools.convert --model /models/Qwen3.8-FN-config \
  --recipe qwen3_8_flash_next_gguf --components text,vision,mtp \
  --source gguf=SC117...-00001-of-00002.gguf \
  --source ngram=SC117...-00002-of-00002.gguf \
  --source vision=mmproj-Qwen3.8-Flash-Next-BF16.gguf \
  --source mtp=mtp-Qwen3.8-Flash-Next-shared-Q8_0.gguf \
  --device cpu --rows-per-chunk 65536 --name qwen3.8-flash-next-abliterated --out shockem-iq3-s.ninfer
# attach DFlash2:
python3.11 scripts/pods/attach_dflash2.py --base shockem-iq3-s.ninfer --gguf Qwen3.8-Flash-Next-DFlash2-Q4_0.gguf --config Qwen3.8-Flash-Next-DFlash2/config.json --output shockem-iq3-s-dflash2.ninfer
# run with published IQ4 table
```
This yields same architecture and GGUF expert bytes, but IQ4 table not Q8.

B. Exact Q8 table path:
```
# extract Q8 tensor from Shockem .basalt `gguf` section into a GGUF table shard
python3 extract_basalt_ngram.py Shockem.basalt shockem-ngram-q8.gguf
# make table artifact
python3.11 -m tools.convert --model config-only --recipe qwen3_8_flash_next_gguf --components ngram --source ngram=shockem-ngram-q8.gguf --out shockem-ngram-q8.ninfer
# model can be text,vision,mtp without ngram, using --ngram-table
```
But the extractor is custom. Basalt `tools/model_file.py` can read sections; GGUF writer can write tensor. Need know exact tensor shape and type. Shockem card gives shape [160,320001536], Q8_0, sha256 e02bf... size. Use `gguf-py` to write. Need ensure metadata `general.architecture=qwen4exp`, maybe ngram constants? The table GGUF likely has metadata for ngram? The table shard has metadata? The official table shard is same file; it may contain full GGUF metadata of model? The NInfer converter reads table shard to hash rows and get row format; `--model` supplies config. It might require tensor name exactly `per_layer_token_embd.weight`. Could write minimal GGUF with tensor.

But maybe NInfer has tool to inspect/convert raw? `tools/convert` supports custom `LogicalSource`, not command line raw. Could use custom recipe. But extraction to GGUF likely easiest.

Need caution: Q8_0 table row format has row length 170B; if NInfer's ngram addressing expects row format with exact row byte count? It can read any table of same geometry in any row format, but row format might be recorded in component config. It likely can handle Q8_0 because ggml blocks. But "any row format" may mean any supported (IQ4_NL, FP8). Need state: likely feasible, but not stock/published; may need a small recipe adjustment/test because published path is IQ4_NL/FP8. If NInfer currently refuses Q8 table, the fix is small at converter/runtime level because Q8_0 linear blocks are already supported; but not guaranteed without testing.

Need maybe mention "nearly byte identical" from Shockem .basalt to .ninfer: The model card's Q8 table SHA can be preserved if you copy bytes; text expert bytes from SC117 GGUF can be preserved; dense projections? Basalt's `--compat-bf16` might convert small projections to BF16; NInfer may keep GGUF blocks. There can be differences. But "byte-for-byte tensor payloads" can be preserved for those sections if using same sources. The container will not be byte-identical.

Need maybe discuss 5090 compute and RAM:
- For conversion, use CPU and disk. 5090 may be idle. Use `--device cpu` for GGUF byte-preserving recipe to avoid needing CUDA; if using GPU for quantization, 32GB enough. 64GB RAM enough for streaming; no need to fit 100GB model. Ensure output disk free: 100-110GB plus source 85-110GB; Basalt v1->v2 needs second copy (200GB+ free). NInfer conversion from source to output similar. If creating table artifact and model artifact, need disk.
- Time: from GGUF: tens of minutes on NVMe; hours on spinning disk. From full HF BF16 checkpoint: possibly many hours and huge disk (full checkpoint hundreds GB) because dequant/quant transforms. From Shockem GGUF/quant: not days.
- Basalt migration v1->v2: 100GB copy + SHA; 15-60 min fast NVMe, possibly several hours HDD. It says no download/requantize, needs numpy and free disk for second copy.

Need maybe mention "making .ninfer exact Shockem" if you want to reuse Shockem's .basalt Q8 table, not full model conversion, maybe easiest is create only ngram table artifact, not full model. Since NInfer can run published WaveCut Flash-Next IQ3_S model with Shockem Q8 table? If Shockem's text weights are abliterated residual writes, using published IQ3_S model with Q8 table not same model; text differences remain. But for Q8 table benefit, you can pair published model with Q8 table (NInfer accepts any table same shape). But if you want abliterated model, need text conversion from SC117 GGUF. The table itself is same for all Flash-Next releases? Shockem says ngram table shard is stock per-layer embedding, ablation does not touch ngram. The Q8 table came from official NVIDIA pack. So yes, Q8 table can be shared across Flash-Next models (same rows). The NInfer ngram table artifact can be shared; you could make one Q8 table artifact and use it with any Flash-Next model. Important: table rows are same in every GSQ-RCO release; Shockem Q8 table is same across releases? It says table shard of every release is same file; Q8 table from official NVFP4 pack corresponds same rows reblocked. So one table artifact suffices.

Need perhaps mention table digest: NInfer model names table by hash constants and SHA-256 of rows. If using Q8 table, the model converted from IQ4 table names IQ4 rows digest; runtime warns when table not named but accepts any same shape. If you convert model with `--source ngram=Q8gguf`, it will record Q8 digest. If using published model artifact and Shockem Q8 table, it will warn but work. Good.

Need maybe answer "How hard is it to make exact ngram table" maybe:
- Extracting table only: low-to-moderate. Use Basalt model-file tooling to copy bytes; write GGUF or NInfer table. No GPU. Disk-bound, maybe 10-30 minutes.
- Full exact .ninfer matching Shockem: moderate because MTP/HC/tokenizer sections need sources. Text weights: easy. Q8 table: custom extraction. Byte-identical container: impossible.

Need maybe include table of tasks difficulty.

Let's formulate final with sections for each question, concise but thorough. Include commands. Need perhaps include caveats about future/fiction? No.

Need maybe use exact values:
- Shockem Q8 PLE: 54,400,261,120 bytes, 170 bytes/row.
- NInfer IQ4: 28,905,035,512 bytes, 90 bytes/row.
- FP8 table: 51.8GB (162B/row) from HF BF16; improved held-out perplexity 1.25%, worse code domains; IQ4 remains release.
- DFlash2: 339,417,600 bytes; five sliding-window layers width 2560.
- MTP: shared-Q8_0 adds 2.8GB to NInfer model.
- Basalt hc8: required v2; profile removed.

Need maybe address "his current .basalt uses MTP" Actually Shockem pack uses official Basalt self-distilled MTP; NInfer DFlash2 is separate. Could say DFlash2 drafter is not in Shockem's `.basalt`; if you move to NInfer, attach it from incoai/nazeshinjite. It doesn't need a new drafter trained for the ablation; it's a Flash-Next adapter. If you want to stay in Basalt, upstream Basalt does not currently provide Flash-Next DFlash2; you'd need your decisive-basalt to implement/attach it, or move to NInfer.

Need maybe mention exact NInfer DFlash2 command:
```
python3.11 scripts/pods/attach_dflash2.py --base ... --gguf ... --config ... --output ...
```
Need ensure config path from incoai. Good.

Need maybe mention serving default:
- `--spec dflash2 --draft-tokens 4/5`; host experts default DFlash2 four drafts if not specified.
- `--spec mtp --draft-tokens 3` for MTP.
- DFlash2 can combine with vision? For Flash-Next docs? It says DFlash2 drafts from component; MTP disables for media? Serving docs says DFlash2 on Qwen3.8-27B can combine with vision; not sure Flash-Next. Don't overstate.

Need maybe mention "stress" in terms of VRAM:
- Basalt MTP: drafter Q8_0/BF16 dense, Q2_0 experts in VRAM? Precision docs: Drafter Q8_0 and BF16 dense; Q2_0 experts in VRAM. That's self-distilled MTP maybe includes experts? Basalt's MTP drafter has experts? It says drafter Q8_0 and BF16 dense; Q2_0 experts in VRAM. So MTP may occupy more VRAM than DFlash2. NInfer MTP 2.8GB; DFlash2 339MB. Good.

Need maybe consider "batched inference" and DFlash2 under parallel:
- Basalt `--parallel` batches slots; MTP window T rows; DFlash2 may have different batch scaling. NInfer DFlash2 docs: with four requests on 3090, aggregate code 1.04x, prose 0.93x, MTP 0.89. So DFlash2 not always faster batched; single-stream likely. Under high concurrency, verification width may reduce throughput. But resource stress still near target decode; extra 339MB.

Need maybe mention compute for "making .ninfer or .basalt" with 5090+64GB:
- Use `--device cpu` for byte-preserving GGUF recipes; GPU won't help and could waste time? CUDA is default, but docs say `--device cpu`; maybe for GGUF import, CPU is okay. If `--device cuda`, PyTorch may use GPU for HC requantization? Not sure. Recommend CPU for byte-preserving conversions; use GPU for imatrix/grouped_search recipes.
- 32GB VRAM: if using CUDA quantization, chunking; no need to hold full artifact. But don't load HF BF16 full model into VRAM/RAM unless streaming.

Need maybe mention exact disk space:
- Basalt v1->v2: needs room for two copies of 105GB (~211GB) plus temp maybe.
- NInfer model+table conversion: source 85-110GB + output 81-108GB = ~170-220GB free. Q8 exact: source Shockem 105GB + output Q8 table 54GB + model 54GB = 213GB, if not reusing source. If extracting table only, output 54GB.
- If using published model + Shockem Q8 table, output 54GB only.

Need maybe include "nearly byte identical" matrix:

Component | Can be byte-preserved? | notes
Routed experts | yes | SC117 GGUF blocks preserved in both
Dense projections | mostly | depends on `--compat-bf16` and NInfer exporter transforms
PLE Q8 | yes if extracted | table digest can match
HC | likely same numeric, not same bytes | both 8-bit but container/rounding maybe
MTP | not unless same donor | Shockem uses Basalt self-distilled; NInfer uses Unsloth shared-Q8_0
Vision | yes if same mmproj | but packed differently
Tokenizer | yes bytes possible | resources differ
Container/header | no | different magic/alignment

Need maybe answer "does ninfer-all still benefit from additive Q8PLE" maybe say:
- If by "benefit" means "is Q8PLE required for model correctness" - no, PLE is there, IQ4_NL is enough and release default.
- If by "benefit" means "can it use Q8PLE for quality" - yes in principle; NInfer supports alternate table formats and evaluates FP8. But Q8/FP8 benefit is not universally positive; docs saw perplexity improvement 1.25% but worse code. Basalt's Q8PLE improved n-gram fidelity but most of model gap remains in IQ3_S experts.
- If by "not included" means "NInfer cannot handle it" - no, it can handle PLE and alternate tables; Q8 artifact just hasn't been published. It is mostly a data-prep/converter task, not an engine model rewrite.

Need maybe mention "exact ngram table for Shockem model" could be made from Shockem's sources: The Q8 table is not from SC117 GGUF; it's from NVIDIA NVFP4 pack. But NInfer's HF-source recipe can produce FP8 from HF BF16, not import NVIDIA FP8 encoding. For exact Q8, use Shockem's `.basalt` as source. If you want "Shockem's model" and "exact ngram table", you don't need to convert model and table together; table can be separate.

Potential final structure:

- Opening summary: Yes, now apples-to-apples. Answer bullets:
  1. Exact Q8PLE .ninfer: moderate custom data-prep; text GGUF easy; exact container impossible; if IQ4 table acceptable, published path easy.
  2. Compute: minutes-to-hours, not days; from GGUF is I/O-bound; 5090 mostly irrelevant; 64GB RAM enough; disk space caveat.
  3. NInfer and Q8PLE: PLE is mandatory, IQ4_NL published; alternate tables supported; FP8/Q8 benefit small/mixed; Q8 from Shockem not stock but feasible.
  4. DFlash2: separate drafter exists and model-agnostic to quant/ablation; attach to NInfer; lower memory than MTP; resource stress near-identical; single-stream faster, batched mixed.

Need maybe include practical recommended workflow:

```
# 1. config-only HF directory
# 2. convert SC117 IQ3_S to .ninfer with published IQ4 table
# 3. attach DFlash2
# 4. serve with --ngram-table published IQ4 or custom Q8
```

Then optional Q8 table creation pseudo:

```
# extract Q8PLE tensor from Shockem .basalt
python3 - <<'PY'
from tools/model_file import ModelFile?
PY
```
Need not actual code? Could mention use Basalt `tools/model_file.py` / `model_sections.py`. The `model_file.py` is Python side. It can read sections. Need write GGUF tensor.

Could propose:
```
# from basalt checkout
python3 - <<'PY'
from tools.model_file import ModelFile
m = ModelFile("Qwen3.8-FN-GSQ-RCO-abliterated-IQ3_S-Q8PLE.basalt")
# meta.tensors['per_layer_token_embd.weight'] gives offset/size/type/shape inside 'gguf' section
PY
```
But convert.py imports ModelFile from tools/model_file.py. Good. Need not give exact API.

Need maybe mention if writing GGUF, must include tensor name, type Q8_0, shape [160,320001536], row alignment? GGUF tensor offset alignment 64? NInfer can read. But if using `gguf-py`, type Q8_0 and shape maybe [320001536,160]? GGUF shape order? In Basalt card shape `[160,320001536]` maybe engine reads transposed? GGUF tensor `per_layer_token_embd.weight` official table shape? Need careful: Shockem says tensor shape `[160, 320001536]`. NInfer ngram table is 320,001,536 rows x 160 values. In GGUF, tensors are shape columns? Official GGUF likely shape `[160,320001536]` (GGML stores columns? It says rows of 160 values but tensor shape [160,320001536]). Need preserve exact shape as official table shard. Use metadata from official table shard or Basalt meta.tensors.

Need maybe mention "table rows digest" NInfer expects SHA-256 of rows. If you copy bytes from Shockem, digest can be recorded.

Need perhaps answer "exact ngram table for the shockem model" could mean make exact Shockem ngram table as .ninfer from Shockem sources. Since Shockem's table is byte-for-byte from official NVFP4 Basalt pack, and NInfer Edge0 FP8 table is also from Edge0 FP8, but no published Q8. Need say: You don't need to reconstruct from HF BF16; you can lift the Q8 rows from Shockem's `.basalt`. That's the shortest exact path.

Need maybe mention `--sections-from`? Basalt uses it to copy MTP/vision/tokenizer. NInfer has `scripts/pods/attach_dflash2.py` and components, but no `--sections-from`. It can combine sources. For MTP and DFlash2 separate. Good.

Need maybe mention "nearly byte identical model under .ninfer artifact" could mean "same model output bit-identical?" Output not guaranteed bit-identical due different kernels, activation rounding, expert placement, batch composition, drafter. Even same weights can produce different near-tied argmax across engines. NInfer docs explicitly: verification width/prefill partition/batch composition change reductions and can flip near-tied argmax. So byte-identical artifact impossible; bit-identical runtime output not guaranteed.

Need maybe include this nuance in Q1.

Potential final answer:

```
Short version:
- Exact Shockem Q8PLE .ninfer: feasible, moderate, mostly custom extraction; not a rewrite. Published IQ4 .ninfer path is easy.
- Conversion compute: not days; from GGUF it is I/O-bound: ~10-30 min on NVMe, 1-3h on slow disk; Basalt migration similar; from HF BF16 could be many hours.
- Q8PLE in NInfer: PLE table is present; IQ4_NL is published. Alternate tables are supported; FP8/Q8 tradeoff documented; not required, small/mixed quality benefit, custom prep.
- DFlash2: yes, use incoai/nazeshinjite Flash-Next DFlash2; no retraining; attach to NInfer artifact; 339MB vs 2.8GB MTP; low extra stress; single-stream faster, batched can be mixed; upstream Basalt lacks Flash-Next DFlash2.
```

Need maybe mention if 5090 32GB can convert: yes with 64GB RAM, but if experts host? Shockem IQ3_S host experts needs about 48.7GB pinned host RAM; your 64GB may be tight but possible? NInfer Flash-Next IQ3_S host expert memory: RTX 5090 host experts 30.1GiB device memory, 48.7GiB host; RTX PRO 6000 host 50.3GB pinned; device every expert 53.7GiB. Basalt Shockem uses 37GiB expert RAM budget on 16GB cards. On 5090 with 64GB RAM, host experts likely fits but RAM reserve matters; 64GB may be enough but close with OS + Q8 PLE page cache? Basalt RAM copy about 46-50GB; need reserve. DFlash2 339MB negligible. If using `--expert-residency disk`, RAM lower but disk bandwidth matters. Could mention DFlash2 won't change that.

Need maybe answer Q2 "when you have high compute like my 32gb card + 64gb ddr5" - The conversion from Shockem .basalt to .ninfer Q8 table might not be able to stream table from 100GB file into GPU; disk is bottleneck. 5090 helps for inference, not conversion. If using NInfer with CUDA default, make sure not to try to load whole table into GPU. Use `--device cpu` for GGUF recipe; PyTorch can use CPU. 64GB RAM is enough for chunked streaming, but not for caching whole 100GB. Use fast NVMe.

Need maybe mention "python file rather fast for consolidating" - yes, both Python converters are stream-oriented. Basalt convert.py says "Everything is streamed." NInfer converter writes report, uses chunks; table hashing minute for 28.8GB. So not a training/inference loop; no epochs.

Need maybe mention "back from when it was still v1 artifact" - v1 to v2 migration is local, no download; for Basalt. That migration itself is a byte copy + SHA, likely quick. It needs second copy. That's why v1 artifact 112.78GB and v2 113.49GB; hc8 computed, profile removed.

Need maybe maybe include exact commands for NInfer attach DFlash2 and serve:

```
python3.11 -m tools.convert --model qwen3.8-flash-next-config \
  --recipe qwen3_8_flash_next_gguf --components text,vision,mtp,dflash2 \
  --source gguf=SC117...-00001-of-00002.gguf \
  --source ngram=SC117...-00002-of-00002.gguf \
  --source vision=mmproj-Qwen3.8-Flash-Next-BF16.gguf \
  --source mtp=mtp-Qwen3.8-Flash-Next-shared-Q8_0.gguf \
  --source dflash2=... # But docs for Flash-Next DFlash2 says attach script, not --source? The model card includes DFlash2 attached. The command can maybe use `--components text,vision,mtp,dflash2` with `--source dflash2=`? Section 4 says DFlash2 needs Safetensors source. But for Flash-Next, docs use attach_dflash2.py with GGUF. Use attach script.
```
Actually for Qwen3.8-27B, `--components text,vision,mtp,dflash2 --source dflash2=Qwen3.8-27B-DFlash2` works. For Flash-Next, published artifact uses `scripts/pods/attach_dflash2.py` with GGUF because drafter from nazeshinjite Q4_0. Could do separate.

Could include:
```
# base without table artifact:
--components text,vision,mtp --source ngram=... --name ...
# attach drafter:
python3.11 scripts/pods/attach_dflash2.py --base base.ninfer --gguf Qwen3.8-Flash-Next-DFlash2-Q4_0.gguf --config Qwen3.8-Flash-Next-DFlash2/config.json --output out.ninfer
```
Good.

Need maybe mention if using Q8 custom table, convert model with `--components text,vision,mtp` and source ngram=Q8 table to record Q8 digest. Or keep model names IQ4 and pass Q8 table with warning.

Need maybe answer "would an identical dflash2 adaptation be any more hard on system resources" - If "identical" means same DFlash2 from incoai: yes available. "Hard" on system resources: not much; 339MB extra, small compute; near-identical to MTP but less weight memory. It may increase verification width and CPU? Target verification dominates. DFlash2 draft block runs five sliding-window layers, small; MTP is a full extra layer with experts? For Flash-Next MTP from shared-Q8_0 block adds 2.8GB. DFlash2 likely lower memory. But exact stress: DFlash2 uses additional state for draft (5 layers) and proposal head; not huge. Need not reconvert model, attach only.

Potential issue: DFlash2 drafter trained for base model; Shockem's abliterated residual writes might lower acceptance because logits shifted. But the ablation is residual-write transplant, not full finetune; DFlash2 likely still good. If acceptance drops, speed gain shrinks. If you want exact adaptation, you'd need to evaluate/possibly train, but no need for basic run.

Need maybe include "not mainstreamed for Flash-Next in Basalt" but NInfer added Nov 4 2026. Since user knows DFlash2 faster for 27B. Say: NInfer has Flash-Next DFlash2 now; Basalt upstream still MTP for Flash-Next. So for your Shockem pack on Basalt, DFlash2 would be a porting project; on NInfer, it's a 339MB attachment.

Need maybe mention exact DFlash2 model source:
- incoai/Qwen3.8-Flash-Next-DFlash2 (Apache-2.0)
- nazeshinjite/Qwen3.8-Flash-Next-DFlash2-GGUF (Q4_0)
- 339,417,600 bytes
- five sliding-window layers width 2560.

Need maybe mention MTP vs DFlash2 output exactness:
- NInfer DFlash2 verifies via rejection sampling? It says sampled request keeps draft only while equals model's draw under MTP; DFlash2 verifies proposal distribution by rejection sampling. DFlash2 can be lossless in accepted tokens? Model card says every answer was answer without drafts (greedy). For sampled, DFlash2 verified proposal distribution. Basalt exact drafting also exact unless relaxed. So no quality compromise normally.

Need maybe mention "Q8PLE benefit" in terms of table size and quality:
- Basalt model card: IQ4 vs Q8 cosine 0.997 (~8% RMS), 4-bit error. It is a fidelity improvement of PLE, but experts still IQ3_S; model quality gap remains. NInfer FP8 eval: +1.25% held-out perplexity, worse code domains. So not universally beneficial. It will still be easy from Shockem sources because table rows are shared.

Need maybe mention if Q8 table increases decode memory bandwidth:
- Each token reads 16 rows. IQ4 90B => 1440B; Q8 170B => 2720B; extra ~1280B/token. At 100 tok/s, 128KB/s; trivial compared to expert reads (multiple GB/s). But if table is cold disk and random reads, extra 25GB and random access might hurt unless page cache/RAM-hot; but still not enormous. NInfer supports `--ngram-residency ram-hot` profiles; Q8 table hot profile maybe can be generated? For IQ4 published table has broad profile; Q8 table profile maybe can be made with `ninfer-ngram-profile`? Maybe not necessary. Could mention hot-row profile can mitigate table traffic.

Need maybe mention "exact ngram table" from Shockem's sources: The ngram table is independent of SC117 ablation. It is the same PLE table for all Flash-Next GSQ-RCO releases. So you can build one Q8 table artifact and share it. The only model-specific part is digest if converting model with `--source ngram`; runtime can use alternate table with warning.

Need final answer in high detail. Let's craft with headings and tables.

Need ensure no unsupported claim "Q8_0 row format supported" too strong. Phrase: "The published table path is IQ4_NL. The runtime is table-shape agnostic and supports alternate row formats; FP8 table is already a supported table artifact. A Q8_0 table is therefore the right kind of thing to build, but it is not one of the stock published recipes, so you should expect a small converter/source-repack step and one validation run." That is safe.

Need maybe answer if "nearly byte identical model under .ninfer" - include "byte identical tensor payloads can be preserved; byte identical artifact file cannot." Also "runtime output bit-identical not guaranteed."

Need maybe include "from Shockem's sources" list:
- SC117 IQ3_S GGUF model shard (abliterated experts, IQ3_S)
- Shockem .basalt Q8 PLE section
- official IQ3_S Basalt pack sections (MTP, vision, tokenizer) if want exact MTP; NInfer uses Unsloth MTP otherwise
- mmproj BF16
- official Qwen config/tokenizer files
- DFlash2 GGUF/config

Need maybe mention `--compat-bf16` differences: Basalt uses `--compat-bf16`; NInfer restores llama.cpp exporter conventions and may store different numeric formats. So exact output not guaranteed.

Need maybe mention "exact ngram table" compute: table extraction/writing ~55GB read + 55GB write + SHA maybe ~110GB IO; fast NVMe ~10-30min; HDD maybe 1-3h. If using Basalt migration, 105GB copy + SHA ~210GB IO; similar.

Need maybe mention "making model .ninfer from GGUF" compute:
- The converter writes `.conversion.json` report; can inspect. Not long.
- DFlash2 attachment: only copies base artifact and appends 339MB; could take 10-30 min because copying 54GB base, not because drafter.

Need maybe mention if 5090 can serve Shockem: Not asked but maybe relevant. Shockem IQ3_S with DFlash2 on 5090: host experts uses 30.1GB device, 48.7GB host; 32GB card OK for host experts; 64GB RAM is tight but NInfer host needs 48.7GB pinned plus KV and OS. Basalt model card ran on 3x 5060 Ti 16GB with 37GB expert RAM. For 5090, likely okay but 64GB RAM may leave little for Q8 PLE page cache; use `--ram-reserve-mib` or disk residency. DFlash2 339MB won't matter. Could add note.

Need maybe mention "batched inference" DFlash2 in parallel: with NInfer up to 8 requests; DFlash2 may have mixed throughput; with Basalt `--parallel N` shared context. The DFlash2 extra compute is in target verification rows; if many slots busy, drafts might reduce throughput. Good.

Need final with "Recommended path" at end:

1. If you want low-risk: make standard .ninfer from SC117 GGUF + published IQ4 table + attach DFlash2.
2. If you want exact Q8PLE: first make Q8 table artifact by lifting tensor from Shockem .basalt; then either serve standard model with it (warning) or convert model with that table source.
3. Don't expect days; disk-bound.

Need maybe include "practical exact Q8 table artifact steps":
- Use Basalt `ModelFile` to read `meta` JSON, find `per_layer_token_embd.weight` offset/size/type/shape inside `gguf` section.
- Extract bytes to file; write GGUF with same tensor metadata.
- Run `tools.convert --components ngram --source ngram=...`.
But if NInfer rejects Q8_0 row format, fallback: use FP8 table from HF BF16 (supported but not published) or custom logical source with Q8 values. Need maybe mention.

Need maybe include "if you only want exact Q8 table, not model" easiest: extract table and use with existing WaveCut Flash-Next artifact; no 54GB model conversion. This is a good point: You can test Q8 table benefit by just creating table artifact and pointing existing WaveCut IQ3_S model to it. It will warn about table digest but run. Then if you want abliterated text, convert SC117 model.

Need maybe mention "nearly byte identical model" with published WaveCut model plus Shockem Q8 table isn't abliterated. So if exact Shockem model needed, convert SC117.

Let's draft final. Ensure answer addresses "Yep. My bad... main question stands" with confident tone. Use bullet tables. Include sources inline maybe. No need citations but links. Use current date Mid-Nov 2026. Ensure not overclaim.

Potential final:

```
Short answers
1. Exact Q8PLE: low-to-moderate. If acceptable to use IQ4_NL: trivial/published. Exact Q8: lift bytes from Shockem .basalt, repack as GGUF/ngram component. Byte-identical container impossible; MTP donor may differ.
2. Compute: no days from GGUF. I/O-bound. ...
3. NInfer Q8PLE: not missing architecture. IQ4_NL is release default. Alternate table support exists. FP8 eval. Q8 is feasible but custom and quality tradeoff.
4. DFlash2: yes use same Flash-Next DFlash2, not per-ablation. Attach 339MB. Resource stress lower/near MTP; single-stream faster; batched mixed; upstream Basalt lacks it.
```

Need maybe include "exact model under .ninfer" with components:

```
python3.11 -m tools.convert --model /models/qwen3.8-flash-next-config \
  --recipe qwen3_8_flash_next_gguf --components text,vision,mtp \
  --source gguf=/models/SC117...-00001-of-00002.gguf \
  --source ngram=/models/shockem-ngram-q8.gguf \
  --source vision=mmproj... \
  --source mtp=mtp-shared-Q8_0.gguf \
  --device cpu --rows-per-chunk 65536 \
  --name qwen3.8-flash-next-abliterated \
  --out shockem-abliterated.ninfer
```
If source ngram Q8 unsupported, fallback use IQ4 source and separate table.

Need maybe mention exact table source extraction pseudo-code:
```
# read Basalt meta.tensors["per_layer_token_embd.weight"]
# offset/size inside gguf section; sha256 e02...
```
No actual script.

Need maybe mention if Shockem's Q8 table SHA is known; can verify after extraction.

Need maybe mention "byte identical model" impossible due container, but tensor digest can match: routed experts and PLE table can be exact; output not bit-identical across engines.

Let's produce final. Also maybe mention "the exact Q8PLE table is model-independent among Flash-Next GGUFs". Good.

Need ensure no analysis in final. Good. Need final length ~2500-3500 words? Desired oververbosity 9. Let's do detailed but not too huge. Use tables.


</details>

Yes — the corrected comparison changes the question from “why is NInfer 100 GB behind?” to “how much custom packaging work is needed to reproduce Shockem’s exact Q8PLE Flash-Next pack as a `.ninfer` artifact?”

Short version:

1. **A Shockem-like `.ninfer` model artifact is easy if you accept the published IQ4_NL n-gram table.**
   A **near-byte-identical Shockem Q8PLE `.ninfer`** is feasible, but it requires extracting the Q8_0 PLE tensor from Shockem’s `.basalt`, repacking it as a table source, and then converting/validating it. It is not a model rewrite, but it is also not currently a one-command published recipe.

2. **Conversion is not “days” from GGUF/`.basalt` sources.**
   For your 5090 + 64 GB DDR5 machine, making a Flash-Next `.ninfer` or `.basalt` from existing quantized sources is mostly **disk-bound**, not GPU-bound. On fast NVMe: expect **minutes to tens of minutes**. On slower HDD/NAS: expect **hours**, but still not normally days unless you are converting the full HF BF16 checkpoint rather than the GGUF/quantized pack.

3. **NInfer-all does not “lack” Q8PLE.**
   The n-gram/PLE table is mandatory and fully supported. NInfer simply publishes the Flash-Next table as **IQ4_NL**, because it is much smaller and is the release representation. Alternate tables are supported in principle; an FP8 table is already supported but not published. Q8PLE is therefore “not done as a published artifact yet,” not “architecturally missing.”

4. **DFlash2 does not need a new drafter for Shockem’s specific ablation.**
   The Flash-Next DFlash2 drafter is model-family-specific, not quant-specific or ablation-specific. It can be attached to a Flash-Next `.ninfer` as a separate component. Resource stress is **near-identical to MTP, but with much less drafter weight footprint**: DFlash2 is about **339 MB**, while the NInfer Flash-Next MTP block is about **2.8 GB**.

---

# 1. How hard is it to make the exact Shockem Q8PLE n-gram table as `.ninfer`?

## There are two different goals

### Goal A: “I want a Shockem-like Flash-Next `.ninfer`, but IQ4_NL table is fine”

This is the easy path.

Your Shockem model experts come from:

```text
SC117/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-GGUF IQ3_S
```

which is:

- a GGUF transplant of residual-write tensors into the ISTA-DASLab GSQ-RCO IQ3_S GGUF
- same Flash-Next architecture
- same tokenizer/vocabulary
- same PLE/n-gram table geometry
- IQ3_S routed experts

NInfer-all can convert Flash-Next GGUF releases with:

```text
--recipe qwen3_8_flash_next_gguf
```

so a Shockem-like `.ninfer` text artifact can be made from the SC117 GGUF source.

The published NInfer path keeps the IQ4_NL n-gram table:

```text
IQ4_NL: 90 bytes/row
320,001,536 rows
28,905,035,512 bytes = 26.92 GiB
```

This is already the published WaveCut Flash-Next table artifact.

So if you do not require the Q8_0 PLE table, this is basically a normal conversion task.

---

### Goal B: “I want Shockem’s exact Q8PLE n-gram table”

This is where it becomes a small custom packaging job.

Shockem’s Q8PLE table is:

```text
per_layer_token_embd.weight
shape: [160, 320001536]
type: Q8_0
size: 54,400,261,120 bytes
sha256: e02bf3d78153f7c95390ffca1b4279776c90ef302a345aa56bf6b3b694d65e42
```

The important point: this table is not naturally a GGUF source file in Shockem’s model card.

Shockem says:

- the SC117 IQ3_S GGUF table shard is still IQ4_NL
- the Q8 table was taken from the official NVIDIA/Basalt NVFP4 pack
- it was copied byte-for-byte into the `.basalt` pack

So the Q8PLE bytes currently live inside Shockem’s `.basalt`, not inside a normal GGUF table shard.

NInfer’s converter expects n-gram sources like:

```text
--source ngram=/path/to/Qwen3.8-Flash-Next-GSQ-RCO-Q2_0-00002-of-00002.gguf
```

or, for HF-source recipes:

```text
--source ngram=/path/to/HF-BF16-checkpoint
```

It does not currently read `.basalt` directly.

Therefore, to make an exact Shockem Q8PLE `.ninfer` table, you would need an intermediate step:

```text
Shockem .basalt
  → extract `gguf` section tensor `per_layer_token_embd.weight`
  → write a GGUF table shard containing that Q8_0 tensor
  → use that GGUF as `--source ngram=` for NInfer
  → write `.ninfer` table artifact
```

Or:

```text
Shockem .basalt
  → extract Q8 rows
  → custom logical source / custom converter recipe
  → write `.ninfer` ngram component directly
```

The first path is probably easier because NInfer already has a GGUF table ingestion path for Flash-Next.

---

## Difficulty rating

| Task | Difficulty | Why |
|---|---:|---|
| Convert SC117 IQ3_S model shard to `.ninfer` with IQ4_NL table | **Low** | Normal NInfer Flash-Next GGUF recipe |
| Attach DFlash2 to that `.ninfer` | **Low** | Existing attachment script |
| Serve published WaveCut Flash-Next `.ninfer` model with Shockem Q8 table | **Low-to-moderate** | Need Q8 table artifact; runtime may warn about table digest but alternate tables are supported |
| Make exact Shockem Q8PLE `.ninfer` table artifact | **Moderate** | Need `.basalt` section extraction + GGUF/table repacking + validation |
| Make full Shockem-equivalent `.ninfer` with exact MTP/vision/tokenizer sections | **Moderate-to-hard if you demand exact Basalt MTP** | Shockem uses Basalt’s self-distilled MTP donor; NInfer uses Unsloth shared-Q8_0 MTP donor |
| Get byte-identical `.ninfer` file vs `.basalt` | **Impossible** | Different container format |
| Get byte-identical tensor payloads for experts/PLE | **Possible** | Both can preserve source bytes |
| Get bit-identical runtime output across Basalt and NInfer | **Not guaranteed** | Different kernels, activation rounding, batch shapes, expert placement |

---

## “Nearly byte identical” needs qualification

You can make the **weight bytes** mostly equivalent.

For example, these can be preserved:

- routed expert GGUF blocks from SC117 IQ3_S
- PLE rows if you lift Shockem’s Q8_0 bytes
- vision projector if you use the same mmproj source
- tokenizer/chat template bytes if you use the same files

But the file itself cannot be byte-identical because `.basalt` and `.ninfer` have different container designs.

`.basalt` is:

```text
BASALTMF header
named sections
2 MiB section alignment
section SHA-256
```

`.ninfer` is:

```text
NINFER v3 header
JSON manifest
components
objects
bindings
uses
files
256-byte object alignment
```

So even if every weight object is byte-preserved, the offsets, metadata, index, bindings, and alignment are different.

Also, Shockem’s `.basalt` was built with Basalt-side choices:

- `--compat-bf16`
- Basalt’s self-distilled MTP donor
- Basalt `hc8`
- removed `profile`
- Basalt-specific provenance

NInfer’s Flash-Next artifact uses different choices:

- NInfer object graph/bindings
- NInfer hyper-connection Q8_0 objects
- Unsloth shared-Q8_0 MTP donor
- optional DFlash2 attachment
- optional n-gram hot-row profile

Therefore, the realistic goal is:

```text
same model weights / same PLE bytes / same architecture
not byte-identical container
not guaranteed bit-identical runtime output
```

---

## Recommended practical path

If you want to move Shockem to NInfer, I would do it in layers.

### Layer 1: normal Shockem-like `.ninfer` with IQ4_NL

Use the SC117 GGUF and the normal NInfer Flash-Next recipe:

```bash
python3.11 -m tools.convert \
  --model /models/qwen3.8-flash-next-config \
  --recipe qwen3_8_flash_next_gguf \
  --components text,vision,mtp \
  --source gguf=/models/SC117-Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-00001-of-00002.gguf \
  --source ngram=/models/SC117-Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-00002-of-00002.gguf \
  --source vision=/models/mmproj-Qwen3.8-Flash-Next-BF16.gguf \
  --source mtp=/models/mtp-Qwen3.8-Flash-Next-shared-Q8_0.gguf \
  --device cpu \
  --rows-per-chunk 65536 \
  --name qwen3.8-flash-next-abliterated \
  --out /models/shockem-like-qwen3.8-flash-next-iq3_s.ninfer
```

Then attach DFlash2:

```bash
python3.11 scripts/pods/attach_dflash2.py \
  --base /models/shockem-like-qwen3.8-flash-next-iq3_s.ninfer \
  --gguf /models/Qwen3.8-Flash-Next-DFlash2-Q4_0.gguf \
  --config /models/Qwen3.8-Flash-Next-DFlash2/config.json \
  --output /models/shockem-like-qwen3.8-flash-next-iq3_s-dflash2.ninfer
```

Serve it with the published IQ4_NL table:

```bash
ninfer-serve \
  /models/shockem-like-qwen3.8-flash-next-iq3_s-dflash2.ninfer \
  --ngram-table /models/Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer \
  --model-id qwen3.8-flash-next \
  --expert-residency host \
  --max-context 32768 \
  --spec dflash2 \
  --draft-tokens 5
```

This gives you the abliterated text weights and DFlash2, without doing the custom Q8 table work.

---

### Layer 2: make Q8PLE table artifact only

If you want to test Shockem’s Q8PLE benefit without rebuilding everything, create only a Q8 n-gram table artifact.

Conceptual pipeline:

```bash
# 1. Read Shockem .basalt section table metadata.
# The tensor you want is:
#
#   per_layer_token_embd.weight
#   type: Q8_0
#   shape: [160, 320001536]
#   offset/size are recorded in meta.tensors
#   payload lives in the `gguf` section
#
# 2. Extract those 54,400,261,120 bytes.
#
# 3. Write a GGUF file containing that tensor with the same:
#   - tensor name
#   - shape
#   - ggml type Q8_0
#   - raw bytes
#
# 4. Convert that GGUF as an ngram component.
```

Then:

```bash
python3.11 -m tools.convert \
  --model /models/qwen3.8-flash-next-config \
  --recipe qwen3_8_flash_next_gguf \
  --components ngram \
  --source ngram=/models/shockem-per-layer-token-embd-q8.gguf \
  --device cpu \
  --out /models/qwen3.8-flash-next-ngram-table-Q8_ninfer-v3.ninfer
```

Then you could run:

```bash
ninfer-serve \
  /models/wavecut-qwen3.8-flash-next-iq3_s-dflash2.ninfer \
  --ngram-table /models/qwen3.8-flash-next-ngram-table-Q8_ninfer-v3.ninfer \
  --model-id qwen3.8-flash-next \
  --expert-residency host \
  --max-context 32768 \
  --spec dflash2 \
  --draft-tokens 5
```

NInfer may warn that the table is not the one the model names, because the model names the IQ4_NL digest. But the runtime supports alternate tables of the same hash constants and geometry.

This is probably the fastest way to test:

```text
published WaveCut Flash-Next IQ3_S model + Shockem Q8 table
```

That is not abliterated, but it lets you validate the Q8 table itself.

---

### Layer 3: convert the abliterated model directly against Q8 table

If the Q8 table artifact works, then you can make a model artifact that names it:

```bash
python3.11 -m tools.convert \
  --model /models/qwen3.8-flash-next-config \
  --recipe qwen3_8_flash_next_gguf \
  --components text,vision,mtp \
  --source gguf=/models/SC117-Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-00001-of-00002.gguf \
  --source ngram=/models/shockem-per-layer-token-embd-q8.gguf \
  --source vision=/models/mmproj-Qwen3.8-Flash-Next-BF16.gguf \
  --source mtp=/models/mtp-Qwen3.8-Flash-Next-shared-Q8_0.gguf \
  --device cpu \
  --rows-per-chunk 65536 \
  --name qwen3.8-flash-next-abliterated-q8ple \
  --out /models/shockem-like-qwen3.8-flash-next-iq3_s-q8ple.ninfer
```

Then attach DFlash2 as above.

This is the closest practical “Shockem model under `.ninfer`” artifact.

Caveat: the `--source ngram=` Q8_0 path is not one of the stock published examples. The architecture/table framework is there, and alternate table formats are supported, but Q8_0 PLE specifically is not a published stock recipe. Expect to test it. If NInfer’s GGUF table path rejects Q8_0 rows, the fix is more likely a small converter/source issue than a model-support issue, because Q8_0 blocks are already part of NInfer’s GGUF block-format support.

---

# 2. What is the compute cost of making `.ninfer` or `.basalt`?

## Key point: these are not training jobs

Both converters are packaging/quantization/import tools.

They do not:

- train weights
- sweep epochs
- require long GPU optimization
- need to hold the entire model in GPU memory

They mostly:

- stream source tensors
- copy byte-for-byte blocks for GGUF recipes
- re-quantize only selected tensors
- hash/checksum large sections
- write a new artifact

So for Shockem-like sources, the bottleneck is usually:

```text
disk bandwidth
+
checksum/hash time
+
Python conversion overhead
```

Not:

```text
GPU FLOPs
```

---

## From GGUF to `.ninfer`

For the normal Flash-Next GGUF recipe, the work is approximately:

```text
read model GGUF shard:          ~55 GB
read table GGUF shard:          ~29 GB for IQ4, ~54 GB for Q8
read vision/MTP:                ~3-4 GB
hash table shard again:         same table size again
write model `.ninfer`:          ~54 GB
write table `.ninfer`:          ~29 GB IQ4, ~54 GB Q8
```

For IQ4_NL:

```text
rough total I/O: 180-220 GB
```

For Q8PLE:

```text
rough total I/O: 260-300 GB
```

On a fast NVMe drive, 180-300 GB of read/write is not days. It is:

```text
fast NVMe:        maybe 10-40 minutes
SATA SSD:         maybe 30-90 minutes
HDD/NAS:          maybe 1-4 hours
```

These are rough estimates, but they reflect the fact that the conversion is streaming. NInfer’s docs explicitly say that PLE conversions read the table shard once more to hash it, and that hashing the 28.8 GB IQ4 table takes “a minute or so” on their test machine. That strongly suggests the operation is I/O-bound and not a multi-day compute problem.

Your 5090 helps mainly if you are running CUDA-accelerated quantization transforms, such as grouped search or FP8/NVFP4 processing. For byte-preserving GGUF conversion, the 5090 is mostly idle.

For byte-preserving GGUF conversion, I would use:

```bash
--device cpu
```

unless you have a specific quantization method that benefits from CUDA.

---

## Your 5090 + 64 GB DDR5

Your machine is plenty for converting from GGUF/quantized sources.

Important constraints:

### 1. Disk space matters more than GPU RAM

If converting from source GGUF to `.ninfer`, you need room for:

```text
source model GGUF:        ~55 GB
source table GGUF:        ~29-54 GB
output model `.ninfer`:   ~54 GB
output table `.ninfer`:   ~29-54 GB
```

For Q8 full Shockem-like conversion:

```text
source SC117 GGUF model:  ~55 GB
source Shockem .basalt:   ~106 GB if lifting Q8 table from it
output model `.ninfer`:   ~54 GB
output Q8 table:          ~54 GB
```

So you want a lot of free space.

### 2. 64 GB RAM is enough, but do not expect to cache everything

The converters stream.

64 GB DDR5 is fine for chunked conversion. It is not enough to comfortably keep the entire 100+ GB Shockem pack plus source files plus page cache all resident.

For conversion, that is okay.

For serving Shockem IQ3_S with host experts, 64 GB is more relevant. NInfer Flash-Next IQ3_S host-expert mode uses roughly:

```text
host pinned expert memory: ~48-50 GB
```

That can fit on a 64 GB system, but it is close depending on KV cache, OS, page cache, and your RAM reserve settings.

For Q8PLE specifically, the extra table traffic is not huge per token, but it adds another ~25 GB of cold file footprint.

---

## Basalt conversion/migration

Basalt’s own `.basalt` conversion is also streaming.

Basalt’s `convert.py` explicitly says:

```text
Everything is streamed.
```

The Basalt migration tool also says:

```text
Nothing is downloaded or re-quantized.
Every model section is copied byte for byte.
It needs free disk space for a second copy.
```

So for your old v1 `.basalt` → v2 `.basalt` migration, the work is roughly:

```text
read old 100+ GB file
write new 100+ GB file
compute SHA-256 sections
compute hc8 from matrices
```

That is another streaming job.

Rough estimate:

```text
fast NVMe:       15-60 minutes
SATA SSD:        45-120 minutes
HDD:             1-4 hours
```

Again, not normally days.

The main cost is:

```text
disk I/O
SHA-256
section copying
```

Not GPU.

---

## What would take longer?

You would start seeing longer runs if you convert from the **full HF BF16 checkpoint** rather than from GGUF/quantized sources.

The full HF BF16 Flash-Next checkpoint is enormous. Converting from BF16 requires:

- reading safetensors shards
- dequantizing/normalizing/reshaping
- quantizing many tensors
- processing the huge PLE table
- writing a new artifact

That can be much slower and may require substantial scratch disk.

But your Shockem path is from GGUF/`.basalt`/quantized sources, not full BF16 training weights.

So:

```text
from GGUF:     not days
from .basalt:  not days for table extraction/migration
from HF BF16:  could be many hours, but still usually not days on a good workstation
```

---

# 3. Does NInfer-all still benefit from an additive Q8PLE n-gram?

## NInfer has the PLE table; it just publishes IQ4_NL

The Flash-Next model requires the n-gram table. It is not optional for normal operation.

NInfer’s published Flash-Next table is:

```text
IQ4_NL
90 bytes/row
28.905 GB
```

This is the table shared by all published GSQ-RCO Flash-Next artifacts:

- Q2_0
- IQ3_S
- Coder IQ1_M
- etc.

The docs say the model names the table it was converted with, but newer NInfer-all can read another table of the same hash constants and geometry, in another supported row format.

So the situation is:

```text
PLE support: present
alternate table support: present
Q8_0 Shockem table published as `.ninfer`: not yet
```

---

## NInfer has evaluated FP8 PLE, and it is a mixed tradeoff

NInfer’s Flash-Next docs mention an FP8 PLE table:

```text
fp8_e4m3fn_row_fp16
51.8 GB
80% more table storage than IQ4_NL
```

It says:

- FP8 table improved held-out perplexity by about **1.25%**
- but it was worse on code domains
- IQ4_NL remains the release representation

That is the same class of tradeoff as Shockem’s Q8PLE.

Shockem’s Q8PLE table is:

```text
Q8_0
170 bytes/row
54.4 GB
```

The PLE fidelity is better than IQ4_NL. Basalt’s card says IQ4 vs Q8 cosine similarity is about **0.997**, with about **8% RMS** error in the IQ4 table.

But:

- the routed experts are still IQ3_S
- the model gap from full precision is mostly still in the experts
- the PLE table is only one component
- code-domain behavior can regress
- it adds ~25 GB of table storage over IQ4_NL

So Q8PLE is not a free upgrade. It is a quality/size/speed tradeoff.

---

## “It is there, just no one has done it yet” is mostly correct

I would phrase it this way:

```text
The model type, n-gram component, alternate table logic, and GGUF block support are there.
The published Q8PLE `.ninfer` table artifact is not there.
Making it is mostly a data-prep/converter task, not an engine rewrite.
```

The reason NInfer does not publish Q8PLE as the default:

1. IQ4_NL is smaller.
2. IQ4_NL matches the GSQ-RCO GGUF releases.
3. FP8/Q8 gains are mixed.
4. It increases table traffic and storage.
5. It is not necessary for the model to run.

But if you want Shockem’s exact table, you can probably extract and repack it.

---

## Practical benefit of testing Q8PLE in NInfer

The cleanest test:

```text
published WaveCut Flash-Next IQ3_S `.ninfer` model
+
your extracted Shockem Q8PLE `.ninfer` table
```

This isolates the table change.

Then compare:

```text
IQ4_NL table vs Q8PLE table
```

on prompts where n-gram behavior matters:

- prose fluency
- code continuation
- long-context recall
- structured output
- refusal/ablation behavior
- perplexity if you want a numeric signal

But do not expect the table alone to erase the IQ3_S expert quantization gap.

---

# 4. Would DFlash2 need to be found separately for Shockem’s model?

## Short answer: no special Shockem-specific DFlash2 is required

The Flash-Next DFlash2 drafter is:

```text
incoai/Qwen3.8-Flash-Next-DFlash2
nazeshinjite/Qwen3.8-Flash-Next-DFlash2-GGUF, Q4_0 form
```

It is trained for the **Flash-Next model family**, not for a particular quantization such as IQ3_S, UD-IQ3_XXS, NVFP4, or a residual-write ablation.

Shockem’s model is still Flash-Next:

```text
architectures: Qwen4ExpForConditionalGeneration
model_type: qwen4_exp
48 layers
36 GDN + 12 QSA
512 routed experts
top-10
PLE table
same tokenizer/vocabulary
```

So the existing Flash-Next DFlash2 drafter should be usable.

The ablation is a transplant of residual-write tensors into an existing IQ3_S GGUF. That can change token probabilities somewhat, so DFlash2 acceptance may not be identical to the non-abliterated model, but you do not need a new trained drafter just because the model is Shockem’s ablated IQ3_S.

---

## Resource profile: DFlash2 vs MTP

For NInfer Flash-Next:

### MTP

- comes from Unsloth shared-Q8_0 MTP GGUF
- adds about **2.8 GB** to the artifact
- shares embeddings/head
- uses MTP drafting through the model’s MTP block

### DFlash2

- from incoai’s Flash-Next DFlash2
- nazeshinjite Q4_0 GGUF
- about **339 MB**
- five sliding-window layers of width 2560
- drafts from the model’s hidden states
- target model verifies the drafts

So DFlash2 is much smaller than MTP in artifact and resident weight footprint.

That does not mean it is free. It still:

- runs the small draft block
- produces proposal tokens
- adds verification rows to the target model
- uses some extra state/memory
- may slightly reduce expert cache space

But the extra cost is small compared with the routed experts and PLE traffic.

---

## Stress on your machine

Your current Shockem Basalt pack uses MTP. Moving to NInfer DFlash2 would not be dramatically more stressful.

Rough comparison:

| Aspect | MTP | DFlash2 |
|---|---:|---:|
| Drafter weight size | ~2.8 GB for NInfer shared-Q8_0 | ~339 MB |
| Artifact growth | significant | small |
| VRAM/RAM pressure | more | less |
| Target verification cost | yes | yes |
| Draft block compute | MTP block | small 5-layer sliding-window block |
| Single-stream speed | good | usually better on Flash-Next host-expert setups |
| Multi-request behavior | can reduce aggregate throughput | can also reduce aggregate throughput, but often better than MTP |
| Output losslessness | exact unless relaxed flags | verified against target distribution |

NInfer’s Flash-Next IQ3_S card reports that, on an RTX 3090 with host experts, default DFlash2 drafting was faster than MTP:

```text
DFlash2 default: 92.3 / 77.9 / 58.2 tok/s
MTP:             83.5 / 73.4 / 49.8 tok/s
no draft:        59.0 / 57.5 / 45.9 tok/s
```

with the same answers as no-draft decoding in those tests.

For your 5090, DFlash2 should not be the machine’s stress point. The stress point remains:

```text
46-50 GB routed experts
PLE table reads
KV cache
host-to-device expert streaming
```

DFlash2 adds a small drafter and some verification overhead.

---

## Important: upstream Basalt may not give you Flash-Next DFlash2

As of Basalt 0.4.1, upstream Basalt’s Flash-Next drafting story is MTP. DFlash2 is the 27B path in upstream Basalt docs.

NInfer-all has Flash-Next DFlash2.

So:

```text
If staying on Basalt:
    Flash-Next DFlash2 is likely something you need to port/wrap yourself.

If moving to NInfer-all:
    DFlash2 is already a supported Flash-Next component.
```

That is one of the places where NInfer-all is ahead of upstream Basalt for your Flash-Next use case.

---

# Recommended plan for your situation

I would do it in this order.

---

## Step 1: Make the low-risk `.ninfer` first

Use:

```text
SC117 IQ3_S GGUF
+
published IQ4_NL table
+
NInfer shared-Q8_0 MTP
+
DFlash2 attachment
```

Command shape:

```bash
python3.11 -m tools.convert \
  --model /models/qwen3.8-flash-next-config \
  --recipe qwen3_8_flash_next_gguf \
  --components text,vision,mtp \
  --source gguf=/models/SC117-Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-00001-of-00002.gguf \
  --source ngram=/models/SC117-Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-00002-of-00002.gguf \
  --source vision=/models/mmproj-Qwen3.8-Flash-Next-BF16.gguf \
  --source mtp=/models/mtp-Qwen3.8-Flash-Next-shared-Q8_0.gguf \
  --device cpu \
  --rows-per-chunk 65536 \
  --name qwen3.8-flash-next-abliterated \
  --out /models/shockem-like-flash-next-iq3_s.ninfer
```

Attach DFlash2:

```bash
python3.11 scripts/pods/attach_dflash2.py \
  --base /models/shockem-like-flash-next-iq3_s.ninfer \
  --gguf /models/Qwen3.8-Flash-Next-DFlash2-Q4_0.gguf \
  --config /models/Qwen3.8-Flash-Next-DFlash2/config.json \
  --output /models/shockem-like-flash-next-iq3_s-dflash2.ninfer
```

Serve:

```bash
ninfer-serve \
  /models/shockem-like-flash-next-iq3_s-dflash2.ninfer \
  --ngram-table /models/Qwen3.8-Flash-Next-ngram-table-IQ4_NL-ninfer-v3.ninfer \
  --model-id qwen3.8-flash-next \
  --expert-residency host \
  --max-context 32768 \
  --spec dflash2 \
  --draft-tokens 5
```

This gives you:

- abliterated SC117 text weights
- NInfer Flash-Next runtime
- DFlash2 drafting
- standard IQ4_NL PLE table

This is the lowest-risk migration path.

---

## Step 2: Test Q8PLE separately

Create a Q8PLE table artifact from Shockem’s `.basalt`.

Conceptual pipeline:

```text
Shockem .basalt
→ extract Q8_0 `per_layer_token_embd.weight`
→ write GGUF table shard
→ convert to `.ninfer` ngram table
```

Then test:

```bash
ninfer-serve \
  /models/shockem-like-flash-next-iq3_s-dflash2.ninfer \
  --ngram-table /models/qwen3.8-flash-next-ngram-table-Q8_ninfer-v3.ninfer \
  --model-id qwen3.8-flash-next \
  --expert-residency host \
  --max-context 32768 \
  --spec dflash2 \
  --draft-tokens 5
```

Or even test with published WaveCut model first:

```bash
ninfer-serve \
  /models/Qwen3.8-Flash-Next-GSQ-RCO-IQ3_S-ninfer-v3.ninfer \
  --ngram-table /models/qwen3.8-flash-next-ngram-table-Q8_ninfer-v3.ninfer \
  --model-id qwen3.8-flash-next \
  --expert-residency host \
  --max-context 32768 \
  --spec dflash2 \
  --draft-tokens 5
```

This separates variables:

```text
published model + Shockem Q8 table
```

If that works, then you know the Q8 table is viable before rebuilding the abliterated model artifact.

---

# Final direct answers

## 1. How hard is the exact Shockem Q8PLE `.ninfer`?

**Moderate.**

- Normal Shockem-like `.ninfer` from GGUF: **easy**.
- Exact Shockem Q8PLE table: **moderate**, because you need to lift the Q8_0 tensor from Shockem’s `.basalt` and make it a NInfer-compatible n-gram source.
- Full byte-identical `.basalt` → `.ninfer`: **not possible**, because the containers are different.
- Byte-preserved tensor payloads: **possible**, especially routed experts and PLE bytes.
- Bit-identical output across Basalt and NInfer: **not guaranteed**.

---

## 2. Is conversion going to take days on a 5090 + 64 GB DDR5 machine?

**No, not from GGUF or `.basalt` sources.**

For your hardware:

```text
GGUF → .ninfer:     likely 10-90 minutes on SSD-class storage
HDD/NAS:           possibly 1-4 hours
Basalt v1 → v2:    likely 15-120 minutes depending on disk
DFlash2 attach:    mostly just copying the base artifact plus appending 339 MB
```

The 5090 is mostly not the bottleneck. The bottleneck is disk bandwidth and checksumming.

Use:

```bash
--device cpu
```

for byte-preserving GGUF conversion.

Use CUDA when you are running quantization methods that benefit from GPU, not for simple GGUF passthrough.

---

## 3. Is Q8PLE just “not included yet” in NInfer?

Mostly yes.

More precisely:

```text
NInfer has Flash-Next PLE support.
NInfer has alternate n-gram table support.
NInfer publishes IQ4_NL because it is smaller and is the release representation.
NInfer supports FP8 table experimentally, and it is a mixed quality/space tradeoff.
Shockem Q8PLE is feasible as a custom table artifact.
```

It is not a missing model feature. It is a missing published packaging artifact.

---

## 4. Does Shockem need a separate DFlash2 drafter?

**No.**

Use the standard Flash-Next DFlash2:

```text
incoai/Qwen3.8-Flash-Next-DFlash2
nazeshinjite/Qwen3.8-Flash-Next-DFlash2-GGUF
```

It is not quant-specific and should work with the SC117/abliterated IQ3_S model because that is still Flash-Next.

Resource-wise, DFlash2 is:

```text
~339 MB
small five-layer sliding-window draft block
much smaller than MTP
near-identical target-model stress
usually faster single-stream
batch behavior can be mixed
```

For upstream Basalt, Flash-Next DFlash2 is not currently the native path. For NInfer-all, it is already supported and attachable.
## User · #71

The Model card for shockM (that you already scraped) had sources tieing it to the Q8PLE tables, should anyone decide on using the same recipe in the future, and, as well posts their citation.

Retrieve that data because I believe the Q8 expert table, the exact one ShockM used, can be derived here for my conversion.

I am willing to take the tradeoff. Quality over quantity. I already run this ~105+GB checkpoint and had fantastic results even across basalt's batched parallelism (true parallel decode)

I guess the final question (after you completely find this without a doubt), is

5. Does the dflash2 route particularly have any info written on it when compared against flash next's "quality"? Or, it there not much of a quality tradeoff from MTP, and, there is only mostly gain.
and
6. Does ninfer-all port in actual batched decode (simultaneous windows both decoding separate things with true parallelism) — like basalt does. One if it's main benefits. You already pulled my basalt serving config since you already read my PR which had it as a small note of the config json.
## Assistant · #72

<details><summary>Reasoning · 3,173 characters</summary>

We need answer final two questions plus retrieve exact Q8PLE source data without a doubt. Need likely need research further. Need understand DFlash2 quality vs MTP for Flash-Next; batched decode true parallelism in ninfer-all vs basalt. User says model card for shockM already scraped had sources tying Q8PLE tables. Need retrieve data: exact source of Q8 expert/table? They say "Q8 expert table" maybe PLE table? "Q8 expert table, exact one ShockM used, can be derived here for my conversion." Need identify where Q8PLE table source can be derived: Shockem model card sources: N-gram table: `per_layer_token_embd.weight` from `Qwen3.8-FN-NVFP4.basalt` in jesdga/Qwen3.8-Flash-Next-Basalt; NVIDIA's FP8 table reblocked to Q8_0. Also Shockem current model sources: experts SC117, MTP/vision/profile/tokenizer/Q8 n-gram from Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt, which spliced table out of official NVFP4 Basalt pack. Need "retrieve that data" likely point to exact HF file and tensor path/size/sha. Need maybe inspect HF file tree for jesdga/Qwen3.8-Flash-Next-Basalt and Shockem packs. Need get exact filenames, maybe HF file metadata. Let's scrape file tree pages for those repos. Also maybe HuggingFace API for files sizes/sha. Could use web_scrape API? Try https://huggingface.co/api/models/jesdga/Qwen3.8-Flash-Next-Basalt/tree/main?blobs=true maybe returns JSON but web_scrape may show. Let's try. Also Shockem repo tree. Need exact Q8 table tensor: from `Qwen3.8-FN-NVFP4.basalt` or `Qwen3.8-FN-NVFP4-DQ6_K.basalt`? Shockem card says table from `Qwen3.8-FN-NVFP4.basalt` in jesdga repo. But official file named `Qwen3.8-FN-NVFP4-DQ6_K.basalt`? Earlier card says default `Qwen3.8-FN-NVFP4-DQ6_K`, output about 122 GiB. Shockem source says `Qwen3.8-FN-NVFP4.basalt` (maybe old name). Need retrieve exact. Could use HF tree to see files. Also maybe official NVIDIA checkpoint revision fc694b54 has FP8 n-gram file; Basalt reblocks to Q8_0. Need maybe exact NVIDIA file? Let's explore.

Need also DFlash2 quality vs MTP. We have docs: NInfer Flash-Next model card Nov 4 DFlash2: default drafting with host experts, every answer was answer without drafts; speed table. Quality: MTP and DFlash2 exact target token under verification; DFlash2 uses rejection sampling verifying proposal distribution? NInfer serving docs: under MTP/DFlash sampled request keeps draft only while equals model's own keyed draw, every emitted token model's sample; DFlash2 verifies proposal distribution by rejection sampling. So no quality tradeoff in terms of output distribution? It is lossless relative to target model; only speed/acceptance differences. But there are numerical differences due batch width/expert placement. Need maybe find Flash-Next DFlash2 quality benchmark vs MTP. There may be acceptance rates, speed. Search docs section 8/9? Need read qwen3-8-flash-next.md sections around MTP speculative decoding and DFlash2 (sections 6,7,8,9 maybe). We have resource c3be2147 12 sections. Need read section 6 MTP, section 7 MTP with several requests, section 8? Let's read sections 6,7,8, maybe 10-12. Also serving docs sections for speculative DFlash2. Use context_read.


</details>

<details><summary>Tool request · context_read · call_fa30202db9494e6babb1203c</summary>

```json
{
  "kind": "resource",
  "id": "c3be2147-fd29-4399-b30f-5ff84b5c86e3",
  "section": 6
}
```

</details>

<details><summary>Tool request · context_read · call_0bab4a3e46d14adbab4e654a</summary>

```json
{
  "kind": "resource",
  "id": "c3be2147-fd29-4399-b30f-5ff84b5c86e3",
  "section": 7
}
```

</details>

<details><summary>Tool request · context_read · call_60282d6c137b420ab0368da1</summary>

```json
{
  "kind": "resource",
  "id": "c3be2147-fd29-4399-b30f-5ff84b5c86e3",
  "section": 8
}
```

</details>

<details><summary>Tool request · context_read · call_c37a16b17c4544658e8bdc1b</summary>

```json
{
  "kind": "resource",
  "id": "c3be2147-fd29-4399-b30f-5ff84b5c86e3",
  "section": 9
}
```

</details>


<details><summary>Tool result · context_read · call_fa30202db9494e6babb1203c</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md · section 6/12
Subsection: MTP speculative decoding

`--max-concurrency N` (one to eight) runs that many requests at once, each on its own sequence with its own KV and recurrent state, so every sequence costs device memory (the KV of `--max-context` positions, 24 KiB a position in BF16 and less in a quantized `--kv-dtype`, plus 74 MiB of recurrent state and 74 MiB for the snapshot of it that the context cache and branched reads take, allocated at startup). Requests are admitted in arrival order. Prompts prefill a step at a time, each step from the prompt with the fewest tokens left, so a short or cached request is not held behind a long prompt for its whole prefill (a prompt passed over eight times goes next, and a prompt with media, once begun, finishes first). A step is one chunk, or with host or disk experts on one GPU a span of up to eight chunks of the prompt (sixteen under `--max-concurrency 1`, where no other prompt waits behind a step), media or not (see [Execution](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#execution)
); while other requests decode, a span is two chunks at most, since they wait for the whole step. Before a step, while requests are decoding, they run `--decode-rounds-per-prefill` rounds (by default the chunk size over 64, 16 at the default chunk) for each chunk's worth of prompt the step computes, at least one, so a short prompt gets in after one round and the streams keep their share during a long one; each round is one batched pass whose experts read their weights once for the whole batch, so the batch costs little more than one token while the experts dominate the step. The mixers' projections and the steps without state (the Gated DeltaNet and sparse-attention input projections, gates, norms and rotation, and their output gates and projections) also run over every request's columns at once, in calls of up to eight columns; only the convolution, recurrence, KV append, indexer and attention run request by request, on each request's own state. A vector product gives a column the same bits at any width up to eight, so a batched round computes what the requests' separate rounds would. On an RTX 3090 with host experts (IQ3\_S, 2026-11-04), eight requests released at once (about 1,100 prompt tokens and 128 answer tokens each) finished 2.0-4.2% faster with MTP over the nine `--kv-dtype` formats, and 11.5% faster without drafts (BF16 KV). A speculative round counts as the tokens its requests fed on average, so drafting streams get as many tokens per chunk as plain ones and hold a prompt back no longer.

With host or disk experts on one GPU, a step of a prompt without media or branched reads also takes the next chunks of the other such prompts that are prefilling, in the same order, while they fit the span: their chunks reach each layer together, so the layer's uncached experts cross the bus once for all of them. A step that does not end its prompt takes whole chunks, so each prompt runs the chunks it would run alone and computes the same bits. A prompt that would resume from a prefix another prompt of the step is about to keep waits for it, and a step that passes a shared prefix (below) runs alone. On the RTX 3090 above (host experts), eight requests got their last first token after 6.2-6.7 s instead of 19.3-20.9 s (9.5-9.7 instead of 22.8-23.7 s with BF16 KV) and finished 1.77-1.94 times as fast with MTP over the nine formats and 1.78 times as fast without drafts; two and four requests finished 1.37 and 1.50-1.56 times as fast (BF16 KV).

With the context cache on (the default), a sequence keeps its state when its request ends, and a snapshot of its recurrent state where the prompt's last user turn closes (or at the prompt's end when the template marks no turn), 74 MiB on the device: a later prompt that continues what the sequence holds resumes from its live state, and one that repeats the prompt up to that point (the next turn of a chat, which renders the previous answer without its reasoning) resumes from the snapshot. A turn that a stop string ends resumes where its visible text ends. The sequence keeps only the tokens before the one that begins the stop string's match: a round that holds such a token commits the tokens before it, and the next step reads the rest. A match that stays open keeps a second snapshot of the sequence there (another 74 MiB a sequence, with the context cache), which the turn goes back to when the stop string ends it in a later step, so the next prompt continues that state. Either way only the new tokens are prefilled; the response's prompt summary reports how many were reused. A request goes to the free sequence that holds the longest such prefix of its prompt. A prefix with images or video is the same only with the same media at the same places (each image's or video's content digest, grid and timestamps); a prompt that resumes past them encodes only its media after the prefix. `--no-prefix-reuse` (ninfer-serve) prefills every prompt from scratch, without the step ends below or at the turn closure.

What a sequence gives up for a new request (its turn-closure snapshot and the state it ended in, each of 128 tokens or more, the end of a disposable request such as a decision read excepted) is kept as an image in host memory, and so is the state where the frontend marks a prefix other requests share (the end of the leading system messages, of the tool declarations, a declared cache boundary, 128 tokens or more): a prompt step ends there, or with host or disk experts on one GPU, where the tokens on each side fill more than a narrow chunk (64 tokens, 8 with `--expert-tail-skip`), a span runs on past it in the chunks two steps split there would run and keeps the state there as it passes, so the experts cross the bus once for both sides ([measured](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#media-conversations-on-one-rtx-4090)
). Requests with the same prefix resume after it on any sequence, also when they arrive together, since a prompt that has not started prefilling looks for images again at its first step. An image is the paged KV and pooled keys of its positions, its recurrent state, and the MTP block's, about 114 MB plus 26 KiB a position in BF16 KV. The images live in 8 MiB pages of pinned memory that stay pinned for later images: the pages of two images of a whole context (within a quarter of the budget) are pinned at startup. Once the Engine has had nothing to run for 50 ms, it pins free pages back up to that many in 64 MiB chunks, within the budget; a request that arrives meanwhile waits for the chunk in progress (about 32 ms, [measured](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#media-conversations-on-one-rtx-4090)
), and the store pins pages itself only when the free ones fall short. Pinning while a request waits is slow where the experts and the page cache fill the host's memory: on an RTX 4090 host with IQ3\_S host experts, pinning the two images of a 32K-token prompt held a short prompt after it for 2.3 s, and faulting in pageable memory for them 1.8 s; into the pages pinned at startup they copy in 15 ms, and the short prompt's first token came 0.45 s after it arrived (2.9 s before). Pinning the startup pages (2 GiB with the default 8 GiB budget) adds about 2 s to startup. The other families pin their whole store at startup and never pin while a request waits. A prompt that continues a kept prefix further than any free sequence resumes from its image, copied back into a sequence. `--host-kv-mib` (or `--host-cache-mib`) is the budget, 8 GiB by default; past it the least recently used images go to the disk tier with `--disk-kv-path DIR` (`--disk-kv-gib`, 64 by default), one file each under a directory per artifact, KV format, MTP draft width and n-gram table (its SHA-256, or none), or are dropped without one. A different verify width or another n-gram table can change sequence state, so those runs cannot restore another profile's images. A request that does not draft (a decision read) runs its prompt without the MTP block, so its sequence's snapshots and images carry no MTP state and serve only requests that do not draft. With `--disk-kv-restore` a prompt also resumes from an image on disk, which a later run finds there too.

Structured output (`--structured-output` for the server, `--json`/`--json-schema` for the CLI) works as for Gemma 4 ([Structured output](https://github.com/iamwavecut/ninfer-all/blob/master/docs/gemma4.md#structured-output)
): the grammar's token mask applies to every sampled token, it is computed on a thread of its own while the step runs, a row whose mask is late samples once it is ready without holding the others, and a request drafts while its masks take at most 4 ms. So do [token log probabilities](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#token-log-probabilities)
: a request that asks gathers each sampled token's top 20 from the same logits before sampling.

`--vision` loads the Vision tower of an artifact converted with it (0.9 GB of BF16 weights on the first device, beside the token embedding) and takes images and video as the Qwen3.5 family does: the frontend renders the media tokens, the tower encodes the prompt's media before its first chunk, and their merged embeddings replace those tokens' embeddings. A media prompt rotates its positions on the three RoPE axes the frontend computes (text positions on all three, then each later token at its index plus the prompt's offset); it prefills in a pass of its own. The context cache keeps media prompts as it keeps text ones: the next turn of a conversation with images resumes past them, and the tower encodes only the media after the resumed prefix, whose merged tokens are what `--vision-max-merged` limits. The MTP block follows media prompts too, so their requests draft: the cell before a media token takes that token's merged embedding, and the cells rotate at the target's positions, on the three axes over media.

### MTP speculative decoding

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#mtp-speculative-decoding)



</details>

<details><summary>Tool result · context_read · call_0bab4a3e46d14adbab4e654a</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md · section 7/12
Subsection: MTP with several requests
Tags: table

`--spec mtp --draft-tokens N` (1 to 15) decodes with the MTP block of an artifact converted with it ([Convert](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#convert)
); without the block the engine refuses to start. Without `--spec`, an artifact with the block and host experts drafts up to three tokens a round with `--draft-min-p 0.5` (a verification window's routes share the layer's missing experts, which the CPU computes while the cached ones run; a round of several requests verifies at most 64 tokens, [below](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#mtp-with-several-requests)
), unless it also carries the DFlash2 drafter, which then drafts on one device ([DFlash2](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#dflash2-speculative-decoding)
); with disk experts it decodes without drafts ([below](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#mtp-with-several-requests)
), and `--spec none` decodes without drafts. An [Edge0](https://github.com/iamwavecut/ninfer-all/blob/master/docs/edge0.md#drafting)
 artifact also drafts with device experts when the engine serves one request at a time. Decoding requests then run rounds: the MTP block (one more sparse-attention layer with its own 512-expert MoE, its own final mixer and the model's head) drafts N tokens from the stack the model left at the request's last position (the head's argmax at each step; with `--gumbel-sampling` a sampled request's draw under the target's keyed noise, [coupled draws](https://github.com/iamwavecut/ninfer-all/blob/master/docs/cli.md#speculative-decoding)
), the model verifies the last sampled token and the N drafts in one pass, and the acceptance keeps the drafts while they equal the model's own draw at each position, then commits the model's draw at the first difference (or after the last draft). The acceptance samples as the request does (greedy, temperature and top-k/top-p/min-p, presence and frequency penalties counting the drafts kept before each position, the grammar's masks, logprobs from each position's own distribution), drawing each position with the request's seed and that position as the key, the key plain decoding uses there. Every committed token is thus the model's own draw whatever was drafted. Verification width and batch composition can still change floating-point reductions, so neither greedy nor sampled answers are promised to match plain decode byte for byte. The kernels are qualified against independent mathematical oracles; exact repetition holds the execution configuration fixed. Acceptance is bounded by the remaining output and thinking-token budgets, including the correction or bonus token.

`--draft-min-p P` optionally ends a round's drafting at the first draft whose absolute probability over the public vocabulary is at or below P. The round verifies the drafts up to and including that one, so every round verifies at least one; P=0 disables the calculation and P=1 drafts and verifies one. A batch drafts until each of its requests has reached such a draft (or the last step) and verifies each request's own selected prefix, the rows packed at their own widths (all at the largest one when a request gathers logprobs). This is distinct from the sampling `--min-p` filter. With a floor each draft step runs from its own CUDA Graph and the host reads the step's probabilities before it starts the next, so `drafted_tokens` counts the steps that ran; each verification width up to 8 has its own CUDA Graph. A round of several requests runs without graphs; the graphs of a single request's passes are captured at startup and shared by the sequences. The floor is part of the disk context-cache profile. `--spec mtp` keeps the full window unless `--draft-min-p` is set; the automatic drafting uses 0.5 unless `--draft-min-p` sets another floor (0 keeps the full window). On an RTX 4090 with the IQ3\_S release's host experts (EPYC 7V13, 32-CPU quota, 64K context; 256 greedy tokens after a code prompt, a prose prompt and a 31,865-token document, once per `--kv-dtype` format) three drafts with the floor 0.5 decoded 1.040 times as fast as without it (geomean of 27 pairs, 0.953-1.131, slower in 5): a round drafted 2.48 tokens instead of 3 and committed 2.27 instead of 2.31.

The verification leaves the sequence's state where it was: each Gated DeltaNet layer records its transitions and the commit replays the kept ones into the state (the Qwen3.5 family's ReplaySSM fold), the sparse-attention indexer's tail and the PLE convolution history advance over the kept positions from what the verification recorded, and the n-gram context is hashed again over them. The MTP block follows every token the model takes in (prompt chunks too), with a KV cache of its own the size of one sparse-attention layer's (2 KiB a position in BF16), so a request can draft as soon as its prompt is in, a prefix the context cache restores included. Following a token runs the block's attention, which leaves its KV and indexer state, and its router, whose routes the expert cache counts, but not its experts: only a draft reads the stack they leave. Up to eight requests run their rounds together, one MTP pass for all of them per draft and one verification pass. A request decodes without drafts when its prompt ends with a media token, near the end of its context, with one token left in its output or thinking budget, and while a `--post-thinking` request still reasons. N-gram copy proposals (`--ngram-draft-tokens`) are not available for this model; `--mtp-attention-window` and `--lm-head-draft` are refused.

With `--lookup-ngram N`, a request whose last `N` tokens (the token it feeds next last) appeared earlier in its sequence proposes what followed them then, up to the round's width (`--draft-tokens`, or with `--adaptive-mtp` the width the controller chose), in place of the MTP block's drafts; the MTP block drafts the other requests of the round, and none when every request has such a proposal. The proposal is verified like any draft, so a wrong one costs speed, not tokens. Its rounds are reported with the n-gram proposals (`ngram_rounds`).

With `--adaptive-mtp`, `--draft-tokens K` is the most drafts a round makes. The controller the Qwen3.5 models use (see [Adaptive MTP](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#adaptive-mtp)
) picks each round's width from the requests' measured draft survival and the round times it has measured at each width, but here it goes down to one draft: the MTP block runs one step per draft, so a narrower round also drafts less, where the Qwen3.5 models' drafts are ready before the round. Each step count has its own draft-chain graph and each width its own verification graph, captured at startup. A round of several requests drafts three steps at most ([below](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#mtp-with-several-requests)
).

#### MTP with several requests

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#mtp-with-several-requests)

A round of several requests verifies their anchors and drafts in one pass. With host experts and a CPU share, the CPU computes missing experts of a pass of up to eight tokens, and of a pass of up to 64 tokens those with at most eight pairs ([the CPU share](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#the-cpu-share)
); a wider pass copies every missing expert to the GPU. The automatic drafting therefore keeps a round of several requests within 64 tokens, which eight requests drafting four tokens each (40 tokens) stay within. On an RTX A6000 (two Xeon E5-2699 v4 sockets with a 10.56-CPU quota, the Q2\_0 release's host experts with a 12 GiB cache filled from the text layers' routing profile, `--max-concurrency 8`, the automatic drafting with the release's DFlash2 drafter; 256 greedy tokens a request after a short prompt, two runs a cell and six for eight requests without drafts, 2026-11-11), in aggregate tokens per second:

| Requests | Without drafts | Four drafts a request (the default) | Rounds of at most eight tokens |
| --- | --- | --- | --- |
| 1   | 50.5-66.3 | 83.1-105.1 | four drafts |
| 2   | 72.2-79.5 | 94.6-105.6 | 94.6-101.6 |
| 3   | 82.4-89.3 | 104.4-108.9 | 92.1-95.6 |
| 4   | 90.0-93.3 | 107.3-116.7 | 97.7-102.5 |
| 8   | 85.3-101.0 | 114.0-118.6 | 97.1-100.8 |

Rounds of at most eight tokens leave three drafts a request for two requests, one for three or four and none for five to eight. With every expert of 9- to 64-token calls on the matrix kernel and that bound, the default drafting had decoded 81.6-106.3, 91.0-103.2, 93.6-96.3, 92.3-104.0 and 93.8-100.4 tokens/s at one, two, three, four and eight requests on this host.

Greedy answers of concurrent requests depend on which requests share each round, which varies from run to run, so they are not reproducible bit for bit: on the RTX A6000 above, answers of two to eight requests, with or without drafts, differed between two runs of one build in some cells and matched in others. A lone request's answers matched in every run.

With `--adaptive-mtp` the controller picks the width of a lone request's round. A batch drafts until each of its requests has reached the floor or the round's width, so a round of more requests with the controller's widths (up to eight drafts, the floor 0.5) ran nearly every step for all of them and gave 0.89 and 0.91 times the speed without drafts at four and eight requests; the packed plan then left drafts unverified, and once kept 18 of 555 at two requests. A round of several requests therefore drafts three steps at most, each request verifying its drafts up to the floor: on an RTX 4090 with Q2\_0 host experts and the automatic cache (2026-11-03, when the CPU shared any missing expert of verifications of up to 64 tokens), 1.16, 1.14, 1.09, 1.02 and 1.08 times the speed without drafts at one, two, three, four and eight requests.

With disk experts a layer reads the experts its cache lacks before it runs, and a verification's drafts route to experts of their own: three drafts every round gave 0.91, 0.82 and 0.64 times the speed without drafts at one, two and eight requests, so the Engine drafts for disk experts only under `--spec mtp`.

### DFlash2 speculative decoding

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#dflash2-speculative-decoding)

`--spec dflash2 --draft-tokens N` (1 to 7) decodes with the DFlash2 drafter of an artifact that carries it ([Convert](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#convert)
); without it the engine refuses to start, and the MTP block, if the artifact has one, is not loaded. The drafter is five sliding-window layers of the model's width conditioned on the model's own states: after each of blocks 5, 15, 25, 35 and 45 the mean of the four hyper-connection streams is kept for every committed position and projected into each layer's ring of the last 2,048 positions (40 MiB a request). A round proposes all N drafts in one pass over the last token and N masks, through the model's head and a selector that walks the 16 likeliest tokens of each position. The model verifies them as it verifies MTP's drafts, with the same acceptance, so every committed token is the model's own draw. `--draft-min-p P` verifies up to the first draft whose selector confidence (its weight among the 16) is at or below P. A single request's proposal and its commits run from CUDA Graphs captured at startup. `--lookup-ngram N` proposes from the context in place of the drafter as it does under MTP; `--adaptive-mtp` needs `--spec mtp`, and pipeline stages are refused. The drafter's mathematics is in [DFlash and DFlash2](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/dflash.md#qwen38-flash-next)
.



</details>

<details><summary>Tool result · context_read · call_60282d6c137b420ab0368da1</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md · section 8/12

`--spec dspine --draft-model PATH --draft-tokens N` drafts instead with a [DSpine](https://github.com/iamwavecut/ninfer-all/blob/master/docs/maintainer/dspine.md)
 drafter trained for this model, up to its block less one: through the same features, ring lanes, rounds, acceptance and `--draft-min-p`, with DSpine's block and code bridge, on one device or under tensor parallelism. No DSpine drafter for Qwen3.8-Flash-Next is published yet.

Without `--spec`, an artifact with the drafter and host experts on one device drafts four tokens a round with `--draft-min-p 0.7`; over pipeline stages its MTP block drafts instead. On an RTX 3090 with host experts (EPYC 7K62, 96 CPUs; 256 greedy tokens after a code prompt and after a prose prompt, and the answer to a 144-token prompt; the mean of two runs) that decoded 92.3, 77.9 and 58.2 tokens per second with the IQ3\_S release, 1.10, 1.06 and 1.17 times the MTP block's automatic drafting, and 122.4, 93.7 and 113.8 with the Coder IQ1\_M release, 1.19, 1.09 and 1.15 times MTP and 1.72, 1.31 and 1.59 times without drafts. Every answer matched decoding without drafts. Seven drafts with the floor 0.8 decoded within 5% of four (1.13 times MTP in geometric mean, as four) while verifying 68-73% more drafts. A round of several requests verifies at most 64 tokens, within which eight requests draft four tokens each ([MTP with several requests](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#mtp-with-several-requests)
); concurrent answers to one prompt can differ from run to run with or without drafts. `--lookup-ngram 3` beside seven drafts decoded 85.9, 76.4 and 49.5 tokens per second on IQ3\_S, below the drafter alone. Under tensor parallelism over two RTX 3090s (Q2\_0, device experts, which draft only under `--spec`), four drafts with the floor 0.7 decoded 1.46, 1.21 and 1.24 times as fast as without drafts after the three prompts and 1.43 times after a 9,741-token document (MTP's three drafts 1.47, 1.18, 0.98 and 1.26), and every answer matched decoding without drafts, where MTP's did not.

Execution
---------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#execution)

*   The residual is a four-stream hyper-connection stack kept in FP32 between layers.
*   The 36 Gated DeltaNet layers run the Qwen3.5 GDN kernels with a sigmoid output gate; the 12 sparse attention layers run the block indexer and attend only to the blocks it selects (plain dense attention below 2,051 positions).
*   The PLE layer reads its 16 n-gram rows per token from the table's file (IQ4\_NL rows decoded on the GPU).
*   A layer's projections of one input run together: the GGUF ones quantize the input to q8\_1 once, and the BF16 ones that a call of up to eight tokens runs as vector products (a Gated DeltaNet layer's `a` and `b`) share one launch. The router's top-10 selection for up to eight tokens runs in its logits launch, in the CTA that finishes last. Each product and selection keeps the bits of its own launch.
*   The 512-expert MoE groups each layer's (token, expert) pairs by expert on the GPU and runs one pass over each selected expert's rows for all of its tokens, through device tables of expert base pointers: an expert is read wherever the table points, in device memory, a cache slot or the pinned host block. Up to eight tokens run vector products; wider calls run ggml's integer tensor-core matrix kernel (IQ1\_M experts once a call routes more than 16 rows to each expert, unless `--iq1m-experts vector`) over the routed pairs from device memory; up to 64 tokens an expert with at most eight pairs keeps the vector products, in every placement, so that the CPU can compute it as the GPU does. The choice depends only on the call's width and the expert's pairs, and a prompt chunk of up to 64 tokens runs alone in every placement (without the lossy `--expert-tail-skip`), so a call's result does not depend on where its experts reside. The matrix kernel runs one CTA per row tile and per column tile that holds pairs (the sort that groups the pairs lists those tiles for each tile width), rather than one per expert and possible column tile (on an RTX 3090 with IQ3\_S host experts, a 31,865-token prompt prefilled at 1.71k instead of 1.61k tokens/s). That kernel reads a 640-value down row in 256-value steps, so it decodes the bytes after a down matrix as the down's blocks: in a bank they are the next expert's down or zeros after the last one, and every cache or stream slot keeps zeros after its down, which a smaller down from another layer does not uncover (another format's bytes there can hold a non-finite scale, and NaN follows). With host experts, a wider prompt call first copies the routed experts the cache does not hold into a device pool on each GPU (0.7 GB for Q2\_0), a bank per projection laid out as the host's, so experts adjacent on the host cross the bus in one copy and each expert crosses it once per chunk; zeros follow each run of copied downs. While the cache has free slots, such an expert goes into one of them instead, and later calls find it cached. On one GPU a prompt longer than a chunk, or the steps of several prompts prefilling at once, run in spans of up to eight chunks layer by layer: each layer runs its attention over every chunk of the span, then its experts over every chunk, so the layer's uncached experts cross the bus once per span, during the attention phase that precedes them, and a span's short last chunk runs from the same pool (a 5,669-token prompt prefilled at 1,334 instead of 678 tokens/s on an RTX 3090 when spans came; the bank-shaped pool and the two phases then took a 9,297-token Q2\_0 prompt from 1.12-1.18k to 1.35k tokens/s from a cold expert cache). The expert phase runs up to 4,096 tokens of consecutive chunks in one call, each chunk routed on its own, so the matrix kernel takes 128-column tiles rather than the 32 of a 1,024-token chunk; a last chunk of up to 64 tokens (eight with `--expert-tail-skip`) runs alone, after the layer's wider calls, since it may copy experts into cache slots those calls read (with IQ3\_S, a 31,860-token prompt's expert matrix products took 4.47 instead of 6.52 s on an RTX 3090). With two prefill buffers (the default with the automatic expert cache, `--expert-prefill-buffers`) the pool has two buffers that consecutive layers alternate between: each layer's copies start as soon as the layer two back is done with its buffer, while the layer before it runs. A thread of its own issues each layer's copies, hundreds of operations that would otherwise hold the launching thread while the copy queue is full, so the layers in between keep being launched. An engine of one sequence (`--max-concurrency 1`, the CLI) keeps no other prompt waiting behind a step, so its spans take sixteen chunks where the further eight chunks' planes (46 KiB a token) fit 1/24 of the memory the device has free at startup: in a prompt past eight chunks each layer's uncached experts then cross the bus half as often ([Expert placements](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#expert-placements)
    ). Weighted expert outputs are summed in fixed point, so the result does not depend on the order experts finish in.
*   A prompt chunk whose rows produce no logits (each chunk before the prompt's last, and a scoring call's chunks before its first scored position) runs the last layer, a sparse attention layer, only up to its key/value and indexer-key appends. In a span, the last layer's expert calls run only where one of their chunks produces logits, so those experts cross the bus less often. With MTP every chunk runs whole, since the MTP block reads each position's final stack. The appended rows come from the same projections and kernels, so caches, states and logits keep their bits.
*   Decode steps, verifications of up to 64 tokens and prompt chunks of up to 64 tokens (eight with `--expert-tail-skip`; every verification and prompt chunk where half the free memory cannot hold a slot pool) of GGUF host experts run in two stages. A kernel splits the call's routes into the cached experts, which run at once, and the missing ones. A call of up to eight tokens posts them to a host service through mapped memory, without a host synchronization; the service copies each missing expert into the slot of the layer's least recently used expert of the lowest frequency tier (or into staging, or the CPU computes its share), the layer waits for it (on the device in a replayed graph, on the host in an eager pass such as a prompt chunk's), and the second stage runs it. A wider call runs eagerly and as over device banks: the host waits for the split, copies the missing experts into cache slots or into half of the 128 MiB staging, a round at a time, and each round's products run while the next round's copies cross the bus; in a call of up to 64 tokens CPU threads meanwhile compute a share of the missing experts with at most eight pairs, the ones the GPU would run on the vector products. The service spins for half a second after each pass start, call and served request; asleep, it still looks for requests every 10 ms, since a replayed layer posts its request from the device and no host call wakes the service for it. The decode form of the expert kernels needs no sort or memset: one small kernel lists each slot's pairs, quantizes the tokens' inputs once and zeroes the sum; a block of the fused gate/up kernel takes 32 rows of one expert and quantizes its piece of the middle for the down kernel itself; one token's down runs row by row over all its experts, summing a row in registers. The decoding of Q2\_0, the routed experts' format, is integer-throughput bound, so its activations come transposed and its codes need two operations a word. The shared expert runs on a second stream meanwhile. All of it is the separate kernels' arithmetic bit for bit. Device and disk experts take the same decode form in one stage, the shared expert on the second stream as well: on an RTX PRO 6000 Blackwell Server (600 W), the UD-IQ2\_XS release with device experts and no n-gram table decoded a 300-token greedy answer at 131.2 instead of 118.9 tok/s, with MTP and 4 drafts at 171.3 instead of 153.0, and with disk experts at 70.6 instead of 67.5, the same bytes (November 10, 2026).


</details>

<details><summary>Tool result · context_read · call_c37a16b17c4544658e8bdc1b</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md · section 9/12
Subsection: Expert placements
Tags: table

*   The expert cache counts the routes each forward pass took (decayed per token) and, between passes, copies the experts it needed most into its slots and points the tables at them: for every layer with mapped misses, and after a prompt chunk with staged ones. With disk experts the cache works per layer instead: once a layer has routed its tokens, the experts it lacks are read into the slots least recently used (never one the same call needs), and only then do the layer's experts run. A prompt longer than a chunk runs in the same spans as with host experts, each chunk's experts on their own: the chunks of a span reach a layer one after another, so the experts the first chunks read are still in their slots for the later ones, and an expert is read once per span rather than once per chunk. At a span's last chunk the layer's residents that chunk does not route to are released: once no slot is empty, later reads take released slots first, oldest release first, before the least recently used, unless a call routes to them again. The span's later layers thus read their experts into the earlier layers' stale ones, and every layer keeps the experts of the prompt's end. Empty slots are always taken first. The MTP block's experts (stored as Q8\_0, wider than the text layers') have slots of their own, for the experts of one draft step of eight tokens (80 slots), when the rest of the budget still holds a text layer's widest call; the text layers' slots are then sized for their own experts (11,815 Q2\_0 slots instead of 3,504 on an RTX 3090). Only drafts run the block's experts: with 80 slots instead of one for each of its 512 experts, three drafts every round gave 78.5 instead of 65.8 tokens/s at two requests and 103.6 instead of 79.4 at eight (aggregate, RTX 4090, Q2\_0, the mean of two runs at eight), and one request's two runs 60.2 and 55.6 against 52.6 and 54.4.
*   A decode step (one token) replays a CUDA graph per pipeline stage, captured at startup and shared by the sequences: a step of another sequence than the last captures it again and updates the graph in place; the token's position reaches the sparse-attention kernels in device memory. Disk experts need the host between a layer's routing and its experts, so their steps stay eager. Under WDDM (Windows, and WSL2) so do the passes of GGUF host experts with staged misses: there a graph's copies queued after a layer's wait for the misses could hold back the service's copies that end it, and the startup log says that graphs are off. `--no-cuda-graph` decodes eagerly everywhere.
*   With MTP, a verification of one request (at most eight tokens, so its experts take the vector products) replays graphs of its own the same way, and so does the draft chain of one request on one GPU, host experts included; several requests' rounds, the MTP catch-up and disk experts run eagerly. With staged host misses the MTP block serves its draft steps' missing experts (at most eight tokens a step) as a decode layer does, copied or computed by the CPU, so the drafts follow the block's own routing. On an RTX 4090 with the IQ3\_S release's host experts (EPYC 7742, 64K context, three drafts with `--draft-min-p 0.5`, 256 greedy tokens after a code prompt, a prose prompt and a 31,865-token document, once per `--kv-dtype` format) serving those misses instead of dropping them committed 5-21% more tokens a round and decoded 1.025 times as fast (geomean of 27 pairs, 0.959-1.092; slower in 4, the two largest losses after the document).
*   A pass whose layers may wait on the device for their missing experts ends synchronized: CUDA loads a kernel lazily at its first launch, a load may wait for the device to go idle, and a launch during such a wait would deadlock with the service it waits for.

Measurements
------------

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#measurements)

### Expert placements

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#expert-placements)

Greedy decoding, one request, the generate test (`ninfer_qwen4_exp_generate_real`) without drafts. Decode is measured over a short answer (78 tokens for Q2\_0, 81 or 82 for IQ3\_S) and over the first five tokens after a 4,463-token prompt; prefill is that prompt in 512-token chunks, which with host or disk experts ran as a span of eight chunks and a last chunk of 367 tokens (the span of that build; an engine of one sequence now takes the prompt as one span). Host memory is the process's peak resident set (with host experts, the pinned bank), device memory the most `nvidia-smi` showed in use. With host or disk experts the expert cache takes the memory the GPU has free and fills while the requests run.

One GPU, October 26, 2026, a build of `master` with CUDA 13.4 (`120a` on the RTX 5090, `sm_86` on the others), the n-gram table as the separate artifact, one run per row:

*   RTX 5090: 575 W, PCIe 5.0 x16, a 16-core Ryzen 9 7950X and 124 GB of RAM.
*   RTX 4090: 450 W, PCIe 4.0 x16, a 48-core EPYC 7K62 and 503 GB of RAM.
*   RTX 3090: 370 W, PCIe 3.0 x16, two 26-core Xeon Platinum 8272CL sockets (four NUMA nodes) and 1.5 TB of RAM. The test ran pinned to the CPUs of the GPU's NUMA node after the model files' pages were evicted, so the pinned bank and the page cache are on that node.

| Card | Release | Experts | Device memory | Host memory | Decode, short answer | Decode after 4,463 tokens | Prefill |
| --- | --- | --- | --- | --- | --- | --- | --- |
| RTX 5090 | Q2\_0 | pinned host memory | 30.1 GiB | 33.3 GiB | 97.8 tok/s | 83.2 tok/s | 3,290 tok/s |
| RTX 5090 | Q2\_0 | disk, the files in the page cache | 30.1 GiB | 1.7 GiB + page cache | 72.1 tok/s | 102.9 tok/s | 1,827 tok/s |
| RTX 5090 | Q2\_0 | disk, the files' pages evicted every second | 30.1 GiB | 1.7 GiB | 37.7 tok/s | 66.4 tok/s | 1,108 tok/s |
| RTX 5090 | IQ3\_S | pinned host memory | 30.1 GiB | 48.7 GiB | 82.5 tok/s | 70.7 tok/s | 2,451 tok/s |
| RTX 5090 | IQ3\_S | disk, the files in the page cache | 30.1 GiB | 2.0 GiB + page cache | 56.4 tok/s | 35.5 tok/s | 770 tok/s |
| RTX 5090 | IQ3\_S | disk, the files' pages evicted every second | 30.1 GiB | 2.0 GiB | 28.5 tok/s | 16.7 tok/s | 399 tok/s |
| RTX 4090 | Q2\_0 | pinned host memory | 22.1 GiB | 33.1 GiB | 73.9 tok/s | 66.9 tok/s | 1,801 tok/s |
| RTX 4090 | Q2\_0 | disk, the files in the page cache | 22.1 GiB | 1.5 GiB + page cache | 46.5 tok/s | 42.5 tok/s | 1,144 tok/s |
| RTX 4090 | Q2\_0 | disk, the files' pages evicted every second | 22.1 GiB | 1.5 GiB | 21.0 tok/s | 14.6 tok/s | 558 tok/s |
| RTX 3090 | Q2\_0 | pinned host memory | 22.2 GiB | 33.1 GiB | 39.1 tok/s | 45.7 tok/s | 663 tok/s |
| RTX 3090 | Q2\_0 | disk, the files in the page cache | 22.1 GiB | 1.5 GiB + page cache | 27.8 tok/s | 27.5 tok/s | 503 tok/s |
| RTX 3090 | Q2\_0 | disk, the files' pages evicted every second | 22.1 GiB | 1.5 GiB | 19.7 tok/s | 14.4 tok/s | 474 tok/s |
| RTX 3090 | IQ3\_S | pinned host memory | 22.2 GiB | 48.5 GiB | 27.1 tok/s | 33.1 tok/s | 438 tok/s |
| RTX 3090 | IQ3\_S | disk, the files in the page cache | 22.1 GiB | 1.7 GiB + page cache | 17.4 tok/s | 13.7 tok/s | 256 tok/s |
| RTX 3090 | IQ3\_S | disk, the files' pages evicted every second | 22.1 GiB | 1.7 GiB | 12.3 tok/s | 6.0 tok/s | 179 tok/s |

*   **Prompt spans.** With host or disk experts a prompt longer than a chunk prefills in spans of up to eight chunks (sixteen now for one request at a time, below), so a layer's missing experts cross the host link once per span rather than once per chunk; the chunk still sets each call's width. The CLI with 1,024-token chunks and MTP drafts on the 7,680-token needle prompt with Q2\_0 disk experts, 16 greedy tokens, this build against one that ran disk experts chunk by chunk with the MTP block's experts in the text layers' slots, interleaved on the same hosts, two runs each:

    | Card | Model files | Prefill, tok/s | Decode after it, tok/s |
    | --- | --- | --- | --- |
    | RTX 5090 | in the page cache | 1,830 against 449-450 | 114.7-114.8 against 31.4-31.9 |
    | RTX 5090 | pages evicted every second | 970-1,000 against 194-196 | 55.7-58.6 against 15.4 |
    | RTX 4090 | in the page cache | 1,640-1,670 against 494 | 44.8-44.9 against 23.7-24.0 |
    | RTX 4090 | pages evicted every second | 532-549 against 131-133 | 12.4-12.7 against 13.6-13.9 |
    | RTX 3090 | in the page cache | 927-988 against 305-307 | 30.2-31.0 against 17.4 |
    | RTX 3090 | pages evicted every second | 469-471 against 103-104 | 12.3-12.4 against 6.4-6.5 |

*   **Decode after the prompt.** Against the same test chunk by chunk (and without the releases), on the same hosts, the Q2\_0 rows prefill 3.9-4.3 times as fast with host experts, 1.0-1.4 times from the page cache and 1.0-2.0 times with the pages evicted. The five tokens after the prompt decode 10-12% slower from disk (2% faster on the RTX 3090 with the pages evicted): the span's last chunk keeps its experts, but this prompt ends in a separate 367-token chunk; without the releases the RTX 5090 decoded them at the rate chunk by chunk. With host experts they decode 1% slower on the RTX 5090, 8% slower on the RTX 4090 and 2% faster on the RTX 3090.

*   **Spans of sixteen chunks.** On November 10, 2026 a rented RTX 5090 (575 W, driver 595.91.07, CUDA 13.4; EPYC 7543, 12.75 CPUs of a host other tenants loaded to 24-56 of its 120 threads) ran the UD-IQ2\_XS release from the CLI with host experts, 1,024-token chunks and no drafts, this build against one held at spans of eight chunks, in interleaved pairs. Prefill, tok/s:

    | Prompt | Spans of eight chunks | Sixteen (one request at a time) |
    | --- | --- | --- |
    | 7,680 tokens, one span either way | 4.20k, 3.89k | 4.26k, 3.75k |
    | 20,181 tokens | 4.01k, 3.90k | 4.34k, 4.29k |
    | 32,256 tokens | 4.33k, 4.23k, 4.13k | 5.28k, 5.22k, 5.30k |
    | 64,512 tokens | 4.77k, 3.83k | 5.31k, 5.23k |
    | 32,256 tokens, disk experts in the page cache | 1.84k, 1.69k | 2.38k, 2.29k |
    | 32,235 tokens, the DFlash2 drafter loaded | 4.76k, 3.81k | 5.24k, 5.31k |
    | 32,235 tokens, `--expert-cache-mib 7000` | 3.13k, 2.90k | 4.30k, 4.33k |

    The answers were the same text. With the span's stack in the automatic cache between prompts the engine started with 23.4 GiB of expert cache (14,544 slots) instead of 23.1 GiB (14,400); with disk experts, which lend nothing, with 23.2 instead of 23.6 GiB. The 256 tokens after a 32,235-token prompt decoded at 73.0-80.7 tok/s (median 76.3 of five runs) against 75.1-80.8 (77.5). After a 52-token prompt they decoded at 78.1-85.6 (median 82.4 of eight runs) against 76.2-86.4 (81.8) on the build before the change; ten pairs against the eight-chunk build of an earlier commit gave 76.5-86.0 (81.4) against 81.2-86.6 (84.7), and that build ran 1.2% ahead of the build before the change as well, so the host's load, not the spans, sets these differences. Not measured: another card, a prompt step between the decode rounds of other requests, and the DeepSeek-V4.1 executor, whose spans are 16,384 tokens already.

*   **NUMA.** Unpinned on another two-socket RTX 3090 host (Xeon E5-2690 v4), Q2\_0 decoded the short answer 9% slower with host experts and 43% slower with disk experts in the page cache than pinned to the GPU's node.

*   **The host.** Host and disk experts cross the host link, and disk experts are read by the CPU threads, so these rows measure the host as much as the card.


Every expert on the GPUs, and the RTX PRO 6000, October 5 and 6, 2026, earlier builds: CUDA 12.8 and the table inside the artifact on the two RTX 3090 Ti; CUDA 12.8 and the separate table on two RTX 4090s at 450 W (PCIe 4.0 x16, no peer access) in a cloud VM with two EPYC 7543 sockets, both GPUs on NUMA node 0, and 694 GB of RAM; on Blackwell a `120a` build with CUDA 13.1 and the separate table, single-GPU rows pinned to the CPUs of the GPU's NUMA node:



</details>

## Assistant · #77

<details><summary>Reasoning · 6,590 characters</summary>

Great. Need batched decode details. Section 6/7 gives NInfer Flash-Next concurrency: `--max-concurrency` 1-8, each own sequence/KV/state, batched passes for projections and experts; MTP/DFlash2 round of several requests verifies anchors and drafts in one pass. Is that "true parallel decode" like Basalt's `--parallel`? Need compare.

Basalt running docs: `--parallel N` (1 to 8) serves N requests at once in batch slots. Each slot holds max-context/N unless --slot-full-context. Each slot keeps two checkpoints. Engine tokenizes prompts and matches slots. Session affinity. Prompts beside decoding slots. `dl` tokens per window, batch slots; with --parallel window serves every busy slot in fixed rows, dl falls toward 1.0 as slots fill. It says true parallel decode? User says one of main benefits. NInfer: `--max-concurrency N` and "up to eight requests run their rounds together, one MTP pass for all of them per draft and one verification pass." Also "A vector product gives a column same bits at any width up to eight, so a batched round computes what requests' separate rounds would." "The mixers' projections ... run over every request's columns at once, in calls of up to eight columns; only convolution, recurrence, KV append, indexer and attention run request by request." So yes true batched decode, but details differ: NInfer has one Engine, up to 8 sequences, batched decode rows, but some stateful parts run request-by-request. It is not separate engines? It is one engine with batched passes. It also has prefix cache, checkpoint images, host/disk. Need compare with Basalt's parallel slots: both 1-8. Basalt slots may be more "slots" with fixed per-slot context and session affinity; NInfer sequences with dynamic KV pool and prefix cache. NInfer has tensor/pipeline stages, host/disk expert streaming, batched expert pass. It supports concurrent requests with prefix reuse, structured output, token logprobs. Need answer if port has actual batched decode: yes. But maybe "true parallel" caveat: on Windows/WDDM graphs off? It still batched. NInfer's batched decode is a batched pass over requests' columns, not necessarily simultaneous CUDA kernel parallelism? Basalt also batch slots with fixed rows. Need be accurate.

Need DFlash2 vs MTP quality. From sections:
- DFlash2: model verifies as MTP, same acceptance, every committed token model's own draw.
- Measurements: default DFlash2 4 drafts floor 0.7 on RTX 3090 IQ3_S: 92.3,77.9,58.2 tok/s; 1.10,1.06,1.17 times MTP automatic; every answer matched decoding without drafts. Seven drafts floor 0.8 within 5% of four; verifying 68-73% more drafts. `--lookup-ngram 3` beside 7 drafts lower. Under tensor parallelism two RTX 3090 Q2_0: DFlash2 4 drafts floor 0.7 1.46,1.21,1.24 times no drafts and 1.43 after 9741 doc; MTP 3 drafts 1.47,1.18,0.98,1.26; every answer matched no drafts, where MTP's did not.
- MTP section: exactness not promised due floating reductions. But under normal execution every committed token model's own draw. DFlash2 proposal distribution rejection sampling? In serving docs: DFlash2 verifies proposal distribution by rejection sampling. So distributionally exact. But no direct quality benchmarks (AIME etc) for DFlash2 vs MTP because drafts are verified; quality is target model. Main difference: speed, acceptance, draft token counts, memory, context cache profiles. Quality tradeoff mostly none, except output may differ from another draft width/batch due numerical reductions and near-tie argmax. Also DFlash2 cannot be used with pipeline stages? Section: DFlash2 refuses pipeline stages. DSpine maybe supports TP? MTP supports pipeline. So if running two 3090s, DFlash2 under tensor parallelism yes? It says under tensor parallelism over two RTX 3090s DFlash2 measured; pipeline stages refused. Basalt multi-GPU uses peer expert tier and layer split, not necessarily pipeline? NInfer `--devices` pipeline stages vs `--tensor-parallel`. Need mention.

Need batched decode measurements: Section 7 includes MTP with several requests. For DFlash2 concurrency: "A round of several requests verifies at most 64 tokens, within which eight requests draft four tokens each; concurrent answers to one prompt can differ run to run with or without drafts." It doesn't give DFlash2 aggregate table? MTP with several requests table uses DFlash2 drafter? The table says "the automatic drafting with the release's DFlash2 drafter" on RTX A6000. Table:
Requests 1: no draft 50.5-66.3, four drafts default 83.1-105.1, rounds max eight 4 drafts.
2: 72.2-79.5, 94.6-105.6, 94.6-101.6
3: 82.4-89.3, 104.4-108.9, 92.1-95.6
4: 90-93.3, 107.3-116.7, 97.7-102.5
8: 85.3-101.0, 114.0-118.6, 97.1-100.8
This is automatic drafting with DFlash2? Actually header "MTP with several requests" but text says "the automatic drafting with the release's DFlash2 drafter". So yes DFlash2 default. Shows batched concurrency scaling aggregate. Also section 6: eight requests with MTP vs plain etc: 2-4% faster with MTP over KV formats, 11.5% faster without drafts (BF16). Wait that's "With host or disk experts... step prefill interleave" not decode? It says eight requests finished 2.0-4.2% faster with MTP... 11.5% faster without drafts (BF16 KV). Then "steps of prompts" gave 1.77-1.94 times as fast. Need carefully summarize: NInfer Flash-Next supports 1-8 concurrent; prompt prefill batching; decode rounds can batch across requests. MTP/DFlash2 rounds verify all requests in one pass, but wide batched speculative rounds limited to 64 tokens to avoid expert cache pressure. At 8 requests, aggregate speed can increase but per-request speed may not scale linearly. This is similar to Basalt parallel slots. Need mention `--max-concurrency` is runtime option, artifact independent. For Flash-Next host experts, up to 8 requests. `--max-context` per request? Need docs: each sequence device memory KV of max-context positions plus 74MiB recurrent state + 74MiB snapshot allocated startup? That suggests context capacity maybe per sequence? Need check CLI: max-context per request? For concurrency, shared pool? In serving docs generic: max-context logical ceiling, shared KV capacity. Flash-Next section says each sequence costs device memory (KV of max-context positions... allocated at startup). That might be per sequence? But with max-concurrency N, each sequence has own KV and recurrent state; context cache adds snapshot. Need not overstate. User asks batched decode not config details.

Need exact Q8PLE source. Let's retrieve HF files. Use web_scrape api tree. Also maybe get file metadata from HF API. Let's try.


</details>

<details><summary>Tool request · web_scrape · call_ff04fafd24774d1d941e0680</summary>

```json
{
  "url": "https://huggingface.co/api/models/jesdga/Qwen3.8-Flash-Next-Basalt/tree/main?recursive=true&blobs=true"
}
```

</details>

<details><summary>Tool request · web_scrape · call_2e3960f0674e41d596e06350</summary>

```json
{
  "url": "https://huggingface.co/api/models/Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt/tree/main?recursive=true&blobs=true"
}
```

</details>

<details><summary>Tool request · web_scrape · call_2aa7e462b3164c17a0d048c1</summary>

```json
{
  "url": "https://huggingface.co/api/models/Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt/tree/main?recursive=true&blobs=true"
}
```

</details>


<details><summary>Tool result · web_scrape · call_ff04fafd24774d1d941e0680</summary>

**Firecrawl · section 1 of 2**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 12,000 characters · included below
- Section 2 · 6,046 characters · omitted from this copy

````text
```json
[{"type":"directory","oid":"f0f4393fea958e2c1076fe807ffb13b0b225f329","size":0,"path":"assets"},{"type":"directory","oid":"5bcc47fbc1a7841814b7fb9ba20b5a9859f460dd","size":0,"path":"convert"},{"type":"directory","oid":"082b98ced2d9bef7aea5b22ec6e6d4483d208c74","size":0,"path":"convert/mtp"},{"type":"directory","oid":"bbb41d9227c197ee9e5dabc008749fc4fd7aa001","size":0,"path":"convert/mtp/rt"},{"type":"directory","oid":"57881a81978e7b3c93fd82684a1be393a44babe3","size":0,"path":"convert/mtp/tensors"},{"type":"file","oid":"38ab05f41d4cfde4df57a9f4aecec9d2267f24fe","size":3439,"path":".gitattributes"},{"type":"file","oid":"9557a8961782792814714b7488346732c043793d","size":3235,"path":"LICENSE"},{"type":"file","oid":"b6ff8c990835fb07d92c23834189b62267721bf9","size":131681979197,"lfs":{"oid":"177f9b70c63ecd7efd17fc705ad85a8c8253d59e4f04dd10a001b556d15fad33","size":131681979197,"pointerSize":137},"xetHash":"37daf5caf4480140f76dc9b78741ab3abfec93b108e977f5449145a2b0180e18","path":"Qwen3.8-FN-NVFP4-DQ6_K.basalt"},{"type":"file","oid":"82e563fd8cc8019f39a8860acec4484164c3512f","size":132367747589,"lfs":{"oid":"c96e8f301df7156d0ee7cf6158dd210bbeec4ef8a80418a427826955d0e3fe69","size":132367747589,"pointerSize":137},"xetHash":"198ffa9c7e8504e8e3f16f7b27965af207a53a9bb79bf30ce8291a2c8b51b8aa","path":"Qwen3.8-FN-NVFP4-DQ8.basalt"},{"type":"file","oid":"e625b11ab8dda19edcf98ef078f676392ae0e31e","size":192197543485,"lfs":{"oid":"6cf670388626b714934c977a65fd3b3dff53f124f3695f3eb361e032301e51df","size":192197543485,"pointerSize":137},"xetHash":"33d62e1aed9bf1e2b00eaed677a45036cdab95868f8dcef8e4e0a6358301c09d","path":"Qwen3.8-FN-Q8_0.basalt"},{"type":"file","oid":"6798854adb49f65971684dc59e7bd799742c2ec4","size":72032776054,"lfs":{"oid":"0294ab379c96aa64c89b2c304e4c2069d3804976a30344d17549fdf1520debf9","size":72032776054,"pointerSize":136},"xetHash":"03e761385cafa7385b264dc416142e51a63344ff19f4eba42a07299976f745b2","path":"Qwen3.8-FN-UD-IQ1_M.basalt"},{"type":"file","oid":"8304f732c217d6dc8866ea23aae0bc873e4e777a","size":70405386113,"lfs":{"oid":"7ff1ff8aad98cb3f5a8373081ccecf06d5dea7e920e0d461b009d65fce1cdc46","size":70405386113,"pointerSize":136},"xetHash":"7b8e0c628d69b9f3cd4a8091a977cd2ac1640b9ede8495f880575c487dd86f92","path":"Qwen3.8-FN-UD-IQ1_S.basalt"},{"type":"file","oid":"00ab94a9ce98f14821ff269c68d12151fe953609","size":79859347594,"lfs":{"oid":"ae1b92ab1380088be37f2c0b9a436b4249fe93dce4a7978529d59da549bd8a8e","size":79859347594,"pointerSize":136},"xetHash":"e7f90cdeb4573415191bee659a7566391bb2f1b553434d991b76294b3869c384","path":"Qwen3.8-FN-UD-IQ2_XS.basalt"},{"type":"file","oid":"c53d046eac7b0c1fb4481d4e9790e1f1abf67b02","size":87602085467,"lfs":{"oid":"b59b35000409e7a0f1ecaaae2d6c1cbbd4a933697183cffa4724f5dcf1dd9a11","size":87602085467,"pointerSize":136},"xetHash":"7447385e36edd6297d6019594a2dcbf88009bf17bf93630ab9fd41230020b17e","path":"Qwen3.8-FN-UD-IQ3_XXS.basalt"},{"type":"file","oid":"c1e462247c2df1cb7fdf84912b224e8c1f606e48","size":97645345884,"lfs":{"oid":"e277c4326319f578b4095aecef2eb3c18efa58e01d7249af63570835ba8a9850","size":97645345884,"pointerSize":136},"xetHash":"b9b25e6a7d3410e7a2ecf813c5e771f6a40e28a1746e39b2b0761eee06d5511f","path":"Qwen3.8-FN-UD-IQ4_XS.basalt"},{"type":"file","oid":"cb0d3d66138eeb99e6924159f4b181d930d50d6a","size":115307561176,"lfs":{"oid":"1e33bd4837ec26f5771509e3f8e2ab911af4562264e6fb8e0993d6711da00c01","size":115307561176,"pointerSize":137},"xetHash":"ecba6097c6fb863f241c6a089ad1b12a01a06cec632b6a24fad343a98876a030","path":"Qwen3.8-FN-UD-Q4_K_XL.basalt"},{"type":"file","oid":"6b0ccc82556e6d20cb7b9e36890fbd5158e875d2","size":162260697835,"lfs":{"oid":"16e353d1d1b96b8d8d9e3cef7bb6f05d890f3802d2c1b3226562cd360033f127","size":162260697835,"pointerSize":137},"xetHash":"69df44e36547f7452009fd299ce8778b46ad26a08b1dc44ebaeebd0c687a6963","path":"Qwen3.8-FN-UD-Q5_K_XL.basalt"},{"type":"file","oid":"73064e338d93f2a95ae816722249482e1dd15d92","size":173138625260,"lfs":{"oid":"a5da0dbc3ecc4924ec8452e9f3b00a99271fb06c458caddf1c9fadc97d16f550","size":173138625260,"pointerSize":137},"xetHash":"faa7dec592aad4871fe3c08c4b081a367a19e58c5bbe7cfcf5f2ae6f70a6bf5c","path":"Qwen3.8-FN-UD-Q6_K_XL.basalt"},{"type":"file","oid":"919d211e341353ae68ed4a125e845259b479dec1","size":6782,"path":"README.md"},{"type":"file","oid":"fdc371583d5fe057ee4b2d7f4b9a45f5c53765a5","size":199453,"lfs":{"oid":"7870f7c6262d6127dbce9b6322eb726f2f32f637ec60c6337c32ba5092a83c07","size":199453,"pointerSize":131},"xetHash":"a1fadc530dcba199df4a755c74657ed49461f476c46112dba9d1f2b8e3467a15","path":"assets/basalt-banner.png"},{"type":"file","oid":"31f761b32b7fa903266ddf878caea6afd36506d9","size":425196,"lfs":{"oid":"b1e1d3a7a9e4bf862dcd5923ce661fb59bbd07907e594df5cf86a62ac235cb91","size":425196,"pointerSize":131},"xetHash":"4000309fa28334f0fdee9319a6f69e766b2297f7ea944044f7a79d4d8cffc9a1","path":"convert/draft_vocab.bin"},{"type":"file","oid":"80bfba7cb950be7ae0496d2db9848c795b14e5d7","size":1796567040,"lfs":{"oid":"afa9185a852b460c6dcd136e780e8484337e2da069dcab7725575345ec068ead","size":1796567040,"pointerSize":135},"xetHash":"4a00a3a31a583ebfb813f38446ee73583bdd4c158c52a58f1ba34bcb8629ca9f","path":"convert/gguf-sources.tar"},{"type":"file","oid":"e46324becc3e715922191614c427d7aed801bb2c","size":7478,"path":"convert/mtp/mtp-inventory.json"},{"type":"file","oid":"67bae8679b6126d7ebe6b25321db3cffcfb50631","size":2437,"path":"convert/mtp/mtp-inventory.md"},{"type":"file","oid":"fca1a9dbe92813e6881aeecda205c1f84e384092","size":11643,"path":"convert/mtp/mtp-manifest.json"},{"type":"file","oid":"8aeb07ceb51c2b47edca4a77ea5859b92b53bd6c","size":3589,"path":"convert/mtp/mtp-q2_0.gguf.report.json"},{"type":"file","oid":"952dda56c20bfed823682d8dc1a6d3553b5a35b3","size":116099072,"lfs":{"oid":"c724dc0b0822ada5d2977bf5bde821605feabaa64ea2e0045b67ca656329070a","size":116099072,"pointerSize":134},"xetHash":"2efbb46f1e859195665154f7d850e342123c11d74cf08f85df20c2537a87ddad","path":"convert/mtp/rt/dense-original.bin"},{"type":"file","oid":"daad7d58c53158467049ccbcb290c7c393feb87a","size":346,"path":"convert/mtp/rt/dense-tuned.json"},{"type":"file","oid":"1661e9f85b584b00baac26867a0958ed138ba348","size":116099072,"lfs":{"oid":"dfe18647e0c95d05302907be88f021590119645a1567fcd770c8d309df852d75","size":116099072,"pointerSize":134},"xetHash":"d648597d8298ed9e251bd90ba75948b8f933bd6d35b785b2fe9f188c5737b51b","path":"convert/mtp/rt/dense.bin"},{"type":"file","oid":"e726e275f346dfc00e2504bba2696273e881fe99","size":1851,"path":"convert/mtp/rt/dense.txt"},{"type":"file","oid":"31f761b32b7fa903266ddf878caea6afd36506d9","size":425196,"lfs":{"oid":"b1e1d3a7a9e4bf862dcd5923ce661fb59bbd07907e594df5cf86a62ac235cb91","size":425196,"pointerSize":131},"xetHash":"4000309fa28334f0fdee9319a6f69e766b2297f7ea944044f7a79d4d8cffc9a1","path":"convert/mtp/rt/draft_vocab.bin"},{"type":"file","oid":"7804acaa65ac699ebd4199a136f865ffd4d7e9d6","size":707788800,"lfs":{"oid":"09398406be61f1f54c93861f449e48b8df0bfccbc9ec9b2b7636775a6ea9244f","size":707788800,"pointerSize":134},"xetHash":"7d8b496e7ad529777d6fa9714ef60f72bbeacda4d2dcedbc1d5e829af5631876","path":"convert/mtp/rt/experts.bin"},{"type":"file","oid":"10c88b901ea457f4193ccbc3abac5ead75ee892b","size":13107200,"lfs":{"oid":"241d6e87ded317a61b1aeb3ca4e28c53f1caba09ad5be66092e91fe5e3e14751","size":13107200,"pointerSize":133},"xetHash":"d57d1dd6f943e7089ec1e102421e0aedfd521f0b9cd5a4a22e15b1179c00694b","path":"convert/mtp/tensors/mtp.fc_embedding.weight.bin"},{"type":"file","oid":"8033a3659c866a8df4c5bba11d8a32038e38e69b","size":13107200,"lfs":{"oid":"97c8e427ad0177e2c713ed24a397d815b523eda15ef453f1ae6463f6c70a8f96","size":13107200,"pointerSize":133},"xetHash":"e9447e0ccb733a51865e7bd9e1c6a2aa690eddeec784426cdea9088521ff59b1","path":"convert/mtp/tensors/mtp.fc_hidden.weight.bin"},{"type":"file","oid":"51bc585740effabc1be8fb71f4d80fd123d831eb","size":20480,"lfs":{"oid":"ce948a398e15aeaa403c424cda34e6eed296ab2570d591bb5ff3da642b255d64","size":20480,"pointerSize":130},"xetHash":"4658eeb33c57fbcdfc25b722b16f9ab39988ed4e88ef7f57fec31238b357d704","path":"convert/mtp/tensors/mtp.hyper_connection_mixer.hc_norm.weight.bin"},{"type":"file","oid":"38e5f5c8bf6f195764701431528a2a9637d20572","size":6553600,"lfs":{"oid":"c633d2841fda463e82045e0b93fb8cb8d511ec0c9eda616020f01aca18d71947","size":6553600,"pointerSize":132},"xetHash":"140ab495d6dd487b93b91923065bdfbaa181df13da96f6ec7506c91bf0e77f8c","path":"convert/mtp/tensors/mtp.hyper_connection_mixer.input_mix_weight_down.weight.bin"},{"type":"file","oid":"d740dbfc0f6ccd9285a093a16d2c450039be0fda","size":6553600,"lfs":{"oid":"6565285f0ba2923703252763cfc11d8a9bda40ab42e7548e12464b04dbdbec13","size":6553600,"pointerSize":132},"xetHash":"ad224dcb01c88428c3df6a8507b6b9d260fd1292b4e71b90b95619f30991e536","path":"convert/mtp/tensors/mtp.hyper_connection_mixer.input_mix_weight_up.weight.bin"},{"type":"file","oid":"6d40570fc4c543e06cd371e0c3785053694ddccd","size":81920,"lfs":{"oid":"c8afff64e7f54412d02120097c4255033c55245e1c1eed84cc630d428ccb864c","size":81920,"pointerSize":130},"xetHash":"d82cdbb765b770df8ef3ddea596b970a01946eb627e3980b9b9b4d86317ffd60","path":"convert/mtp/tensors/mtp.layers.0.attn_hyper_connection.block_inject_weight.weight.bin"},{"type":"file","oid":"ba11a2b92a7238ad8456bd80c466ad428c0c6ca1","size":20480,"lfs":{"oid":"1fb619aeaaf637ccd70f46f1f8f8116e6a46448cb43026b246de8ee8286ed809","size":20480,"pointerSize":130},"xetHash":"dbc5d95865a6c6ac862a67eb70f71ec6b68f63fc9301b3dc319832885b2098f6","path":"convert/mtp/tensors/mtp.layers.0.attn_hyper_connection.hc_norm.weight.bin"},{"type":"file","oid":"8b3d882205f4d94029750d2b3d4b66857a1a0a92","size":6553600,"lfs":{"oid":"e80ac8bf3e270e9d5a949ec7c913329dc8de017d69851334820fae7b8c86a7f5","size":6553600,"pointerSize":132},"xetHash":"b1b68152e71d684ccb702d8863903702979d556035ff981db1aac9843259a925","path":"convert/mtp/tensors/mtp.layers.0.attn_hyper_connection.input_mix_weight_down.weight.bin"},{"type":"file","oid":"b49a0d8e657831178fc3103b9d32b24f787edafd","size":6553600,"lfs":{"oid":"f80f1fd44e1183e7764ea496b11ff89ead9dd758f861d4e79a770bf54956b1a5","size":6553600,"pointerSize":132},"xetHash":"176158f0dcbec94ff04818873fe71daed0b86038e0f5eacf93d703a702dca9c3","path":"convert/mtp/tensors/mtp.layers.0.attn_hyper_connection.input_mix_weight_up.weight.bin"},{"type":"file","oid":"8c42094faffa8b36895370b85e3ef73833375059","size":1677721600,"lfs":{"oid":"539c46234f73bac70450f731f40e715f77ac32faf77def0f3f800e58aaabbbc0","size":1677721600,"pointerSize":135},"xetHash":"57b936c2732e413fd50a6793bbc4f748f285eb6ab0569ff42a8da1ad5697a934","path":"convert/mtp/tensors/mtp.layers.0.mlp.experts.down_proj.bin"},{"type":"file","oid":"056ebefde47ad6d85e9a8b1b930d2da75ad734c7","size":3355443200,"lfs":{"oid":"839e98f9642ebc884b178abd2090b6dc8b0bcd81ed92d7f7a08314c6a68f96d5","size":3355443200,"pointerSize":135},"xetHash":"da29ab60ef401954aea388d011c586a7d95f2cc7003ed6e1a6b958681dec5da3","path":"convert/mtp/tensors/mtp.layers.0.mlp.experts.gate_up_proj.bin"},{"type":"file","oid":"4af5c4408e5ba95abbafdfe2f3aae2ac948dc086","size":2621440,"lfs":{"oid":"f0d35fa41b360a08bc0c5b1e5766aa42df960291716ee189208b5d2599462c20","size":2621440,"pointerSize":132},"xetHash":"f76f623cfd3295661d3fc6a7a246a75ff5e3d4587bae903596f7f67f5da55b42","path":"convert/mtp/tensors/mtp.layers.0.mlp.gate.weight.bin"},{"type":"file","oid":"5db07cc47ce22ba5e5b41a5bdec73bacd3636424","size":3276800,"lfs":{"oid":"d2ced8c81367cc494599d1a8cdc279c3dd6579b628ded05acd7495e99cee01d8","size":3276800,"pointerSize":132},"xetHash":"33e68042f6fdb7c3d11368a14c3890045047e69dff6568708850d446dbdb0cdc","path":"convert/mtp/tensors/mtp.layers.0.mlp.shared_expert.down_proj.weight.bin"},{"type":"file","oid":"5309b2f8ce7141167d09be12dbc3cccc027d0ac4","size":3276800,"lfs":{"oid":"f4a81109165853b3b64f36d809f98094b599763364070f5fa079200e1c386d4c","size":3276800,"pointerSize":132},"xetHash":"93627195d02d4d5787f781168ab66c1f7ea0c24c29f29881376904946530515f","path":"convert/mtp/tensors/mtp.laye
````

</details>

<details><summary>Tool result · web_scrape · call_2e3960f0674e41d596e06350</summary>

```json
[{"type":"file","oid":"f108b312cab66afc630ff4d76b8bf5e7f4c5bec6","size":1593,"path":".gitattributes"},{"type":"file","oid":"9557a8961782792814714b7488346732c043793d","size":3235,"path":"LICENSE"},{"type":"file","oid":"c35f740d3351e73a9e224f40dbb65d75778aafd7","size":113245914374,"lfs":{"oid":"cd7942f23a8c36d4c962ae47a589f6b85c104036dbecf6ccd483e7478f9e19e7","size":113245914374,"pointerSize":137},"xetHash":"48215b5287cfadf9b0d9f76450681138ba027515860ba51c5603fe97cb4a2f8e","path":"Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE.basalt"},{"type":"file","oid":"ccc584f321b9f318ad80d457a2203d3db53cf0fa","size":3876,"path":"README.md"}]
```

</details>

<details><summary>Tool result · web_scrape · call_2aa7e462b3164c17a0d048c1</summary>

```json
[{"type":"file","oid":"9df4ea9ef141bbe7acb3a0d67d0f70c5ae2b5b01","size":1605,"path":".gitattributes"},{"type":"file","oid":"9557a8961782792814714b7488346732c043793d","size":3235,"path":"LICENSE"},{"type":"file","oid":"028d8c672e9d45bfe092e5470015e9893fdef2ca","size":113491281169,"lfs":{"oid":"36fdc5077666f18c39552e3cba40c707f3d066119fa86b69d5d3fe632d5f89c6","size":113491281169,"pointerSize":137},"xetHash":"9c675da1084372bb7d72ed319e9426eadc9de1ee5c4ce1382dd82b9b18e76334","path":"Qwen3.8-FN-GSQ-RCO-abliterated-IQ3_S-Q8PLE.basalt"},{"type":"file","oid":"6c82fd15ba52d375ac695290b6ae0aacbb4ec2d0","size":4165,"path":"README.md"}]
```

</details>

## Assistant · #81

<details><summary>Reasoning · 2,674 characters</summary>

Good. Need exact source of Q8PLE: in jesdga pack NVFP4 files. The card says Q8 table from `Qwen3.8-FN-NVFP4.basalt`, but actual current files are `-DQ6_K` and `-DQ8`. Need maybe old file? Shockem previous model card says official IQ3_S pack? Wait current Shockem source says "MTP, vision, profile, tokenizer, and Q8 n-gram table: Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt, which spliced that table out of official NVFP4 Basalt pack." Previous Shockem card source says N-gram table: `per_layer_token_embd.weight` from `Qwen3.8-FN-NVFP4.basalt` in jesdga repo. The current jesdga repo has NVFP4-DQ6_K and DQ8, not plain NVFP4. Maybe file renamed? Need check if `Qwen3.8-FN-NVFP4.basalt` exists in repo maybe not. API shows only DQ6_K/DQ8/Q8_0/UD... no plain. It might have been renamed; Shockem source may reference historical revision. Need mention exact available current files: use `Qwen3.8-FN-NVFP4-DQ6_K.basalt` (size 131,681,979,197 bytes) or `Qwen3.8-FN-NVFP4-DQ8.basalt` (132,367,747,589 bytes). Which one contains exact Q8PLE table? Shockem says official NVFP4 pack stores PLE as Q8_0 from NVIDIA's FP8 table reblocked to Q8_0. The DQ6_K pack stores dense projections Q6_K but output head/token embedding Q8_0 and n-gram table Q8_0. The DQ8 pack same PLE Q8_0? The table likely identical across NVFP4 packs. Need not choose? The exact tensor SHA from Shockem card: e02bf... We need retrieve exact data. Could maybe compare if DQ6_K has same PLE table? Need inspect Basalt `model_file` metadata? Cannot parse .basalt here. But docs/model-file says Flash-Next NVFP4 pack: n-gram table is FP8 code x scale as Q8_0. Official file NVIDIA checkpoint revision fc694b54 with dense projections Q6_K; output about 122 GiB. The file is Qwen3.8-FN-NVFP4-DQ6_K.basalt. So exact available source is that. The plain `Qwen3.8-FN-NVFP4.basalt` likely old name for same NVFP4-DQ6_K. Need maybe check HF revisions? Could use API for old file? `?revision=main` only current. Maybe there are old files in refs? Could query `huggingface.co/jesdga/Qwen3.8-Flash-Next-Basalt/tree/Qwen3.8-FN-NVFP4.basalt?` no. Maybe commits. But we can confidently state current replacement.

Need maybe get NVIDIA checkpoint file containing FP8 n-gram table. The Basalt model-file docs: `hf download nvidia/Qwen3.8-Flash-Next-NVFP4 --revision fc694b54`. NVIDIA's FP8 table file? Need maybe find exact file in HF nvidia repo. Shockem card says "NVIDIA's FP8 table, reblocked to Q8_0." For conversion, the easiest is not NVIDIA FP8 but extract Q8 from Shockem/Basalt. Need perhaps retrieve NVIDIA table path to be complete. Let's inspect nvidia/Qwen3.8-Flash-Next-NVFP4 tree? It may be huge and filtered.


</details>

<details><summary>Tool request · web_scrape · call_07347d96621a44b8a9dd87d5</summary>

```json
{
  "url": "https://huggingface.co/api/models/nvidia/Qwen3.8-Flash-Next-NVFP4/tree/fc694b54?recursive=false"
}
```

</details>


<details><summary>Tool result · web_scrape · call_07347d96621a44b8a9dd87d5</summary>

```json
[{"type":"file","oid":"a09db2ea4d1bd1fc1c09f6fca45e8e4054953535","size":1635,"path":".gitattributes"},{"type":"file","oid":"f3edfc5b8f2cae8ae751162626d4c5aa3ed071a6","size":12109,"path":"README.md"},{"type":"file","oid":"c0c686f9c38d70d179fb7b5f5aa7530bc913dda3","size":8952,"path":"chat_template.jinja"},{"type":"file","oid":"d9df7636dc5b8bdab82655aba8ce0ebe25b22342","size":30820,"path":"config.json"},{"type":"file","oid":"023756cfadf88e5bf69eefeee3e172f38c448d64","size":202,"path":"generation_config.json"},{"type":"file","oid":"89bb1a48d2358f4b9ab7959bd4357a6d6d04020e","size":23001,"path":"hf_quant_config.json"},{"type":"file","oid":"a494e019ca1502219fd0128658b979e5f05ae8e8","size":3353259,"path":"merges.txt"},{"type":"file","oid":"cc1ea325b748152fc2e2c918a573763754acb04a","size":3115991696,"lfs":{"oid":"63fde954be6f08b49b876f4f70a0ad0bcfee71aff7b1faa33779b6b32feca2a2","size":3115991696,"pointerSize":135},"xetHash":"a37362239d94f0e06f143bbeaeb62c8a108343ba37b5fbf78ef54de261514e40","path":"model-00001-of-00010.safetensors"},{"type":"file","oid":"b27deb837913bec6df4848451aa0faac0e6ff851","size":10005510304,"lfs":{"oid":"4dafaef62a908e49e0d92c7c2a3fa99f4d9651fdeeb0ca09f09a9b40095af4e0","size":10005510304,"pointerSize":136},"xetHash":"c8a0d452ff7b77e30ef2b9ca4bb6d8d87df91ac6517eb91f2fafe13974b21f6f","path":"model-00002-of-00010.safetensors"},{"type":"file","oid":"8685aea0a89fd94bae7e45c093d9720cfc08f08c","size":10005364728,"lfs":{"oid":"3218ddc129258e91a721a8e81329ca8f00588332ec721bd8d2cf7d20e324bf47","size":10005364728,"pointerSize":136},"xetHash":"34d5e7b4d87704ff67b4595ba65a66f3130185a74d7a50da4aac603577456a08","path":"model-00003-of-00010.safetensors"},{"type":"file","oid":"26b3d2d2875fb47748a2bbaeb66c53e7d5f28957","size":10006060112,"lfs":{"oid":"55e2bdf6a3a1f6e65270787f65c63b2a2a56b308b54eb1fb318dfabc9b48b141","size":10006060112,"pointerSize":136},"xetHash":"ad760456f34520f4d3e3c45fb8e814418999d60395394fc4bfa61e8c74d02c70","path":"model-00004-of-00010.safetensors"},{"type":"file","oid":"09a5a9eca64e233417f69658786d4b990ba78dc9","size":10005362392,"lfs":{"oid":"d3c169d3694bfba846455d01e48f047d770f78d071c5a4d22f129389411d686e","size":10005362392,"pointerSize":136},"xetHash":"84128bc01dd5a31b3a33cfea7e83bb7a02e206d4cfacaab37c0e0fdd382d321a","path":"model-00005-of-00010.safetensors"},{"type":"file","oid":"1677993137ed61a8d20c86d8a3309819b52dbda9","size":10005375328,"lfs":{"oid":"38f65a9d11090428e139cc60d0587e8e5433ea2ce79820883c583d7cfcc53130","size":10005375328,"pointerSize":136},"xetHash":"6ecf99231ec5bdad9595d40e050104fbb280f142df2168a266ba38a6e57d9f96","path":"model-00006-of-00010.safetensors"},{"type":"file","oid":"b0225a45639224068ea9c09a1e626103c8d0fb7e","size":10005956544,"lfs":{"oid":"8cf3fa05c04cb2e060963b69bb01f7a7b9f43c58435fbe380836a0457a19cd3e","size":10005956544,"pointerSize":136},"xetHash":"a5ddff6fd3aa6546b8d44e30929c474775a477f856224efa5b0fa40d2064cac3","path":"model-00007-of-00010.safetensors"},{"type":"file","oid":"cb519eca012d73bc0581602cf11f19c404eddb3e","size":10005375200,"lfs":{"oid":"53d1f80746aa0cc0a7c2f4836587002a8a4dd72c827432cd2e43abae3c3899e4","size":10005375200,"pointerSize":136},"xetHash":"a97d87ebf66dc69ce0615172a8cb4381e6a2cb04c1d06487f3e3a2bf154f74b5","path":"model-00008-of-00010.safetensors"},{"type":"file","oid":"309a07d3d3571d75a92640fde8d04c4715ec442e","size":5679113808,"lfs":{"oid":"eaff6a87ece6fbfd6ad0fbaa0a5cf9ff542f8076acba38e62410b1ed55e12cc3","size":5679113808,"pointerSize":135},"xetHash":"e354bd9c499c0f3f623da8c67d1a6aa9d6d80702b2882b42cbd898f6bfddf66f","path":"model-00009-of-00010.safetensors"},{"type":"file","oid":"242cee9fd1ba2ab3ea64f2465608e6de14a16db8","size":128587536,"lfs":{"oid":"0d49b0cf7c15bf9b5bd1e17403b36727315860a8f2a2e0f5a53655547084f640","size":128587536,"pointerSize":134},"xetHash":"9f25a1e3ffc3c40fe264e9b9513a130369b02247710275d0947e8acc9b4788b4","path":"model-00010-of-00010.safetensors"},{"type":"file","oid":"e51653dec2b4181090936870439f2f0f71ce9eca","size":53717551730,"lfs":{"oid":"3525520c8602d850003eb1960aec0b64291dae33b83f8b65dd639a451df78823","size":53717551730,"pointerSize":136},"xetHash":"8098f0b81bcec6856e33fc64c280eb7f9a058e1f70d3314b687d6ab8184d9c2f","path":"model-fp8-mtp-ple.safetensors"},{"type":"file","oid":"e7b80ae9e50d978fce1a1c49f2ab139ad256530a","size":31275518,"lfs":{"oid":"660414e8300728ba80062e6a3c81cb76a65e2ab136ac9e9ceb450ba0c51c3c0d","size":31275518,"pointerSize":133},"xetHash":"3d5eb6852f30df885bcaf5c66576f1d6a6a5d53442b382e02cba06cac37161b4","path":"model.safetensors.index.json"},{"type":"file","oid":"2ea84a437d448ff71b08df68fdd949d5cc4ebb64","size":390,"path":"preprocessor_config.json"},{"type":"file","oid":"33818c7f9e991ad735fd240209f4fa73e6c28c50","size":1191,"path":"processor_config.json"},{"type":"file","oid":"9328ce9c41e80f6dd7bc2c66d8ae1fc93bf87440","size":12809320,"lfs":{"oid":"0997f410c57a1f4e53b09e4be8f4a172d90edd9564368fb0847030937229b9f3","size":12809320,"pointerSize":133},"xetHash":"ddca7e708ff0da8902fdcef5209d5eea8bf922715733eb02f93026a37478e426","path":"tokenizer.json"},{"type":"file","oid":"5de744b3fca2129d7186979ae47c06be33903243","size":17928,"path":"tokenizer_config.json"},{"type":"file","oid":"3ba673a5ad7d4d13f54155ecd38b2a94a6dac8fe","size":385,"path":"video_preprocessor_config.json"},{"type":"file","oid":"0aa0ce0658d60ac4a5d609f4eadb0e8e43514176","size":6722759,"path":"vocab.json"}]
```

</details>

## Assistant · #83

<details><summary>Reasoning · 19,330 characters</summary>

NVIDIA checkpoint has model-fp8-mtp-ple.safetensors 53,717,551,730 bytes. That likely contains FP8 MTP + PLE? Size 53.7GB (not 54.4). The Basalt Q8 PLE is 54.4GB. NVIDIA FP8 table has 160 E4M3 + FP16 scale? row 162 bytes, 51.84GB? model card says 51.8GB. 53.7GB safetensors includes MTP too maybe. The n-gram table FP8 may be in that file. Basalt reblocked to Q8_0: 54.4GB. Need maybe exact tensor name in NVIDIA checkpoint. Could inspect safetensors index? model.safetensors.index.json maybe huge but can search for `per_layer_token_embd`? Use HF API raw? It's JSON 31MB. Could web_scrape and maybe search? Not directly searchable. Could use HF file viewer? Maybe not needed.

Need "Q8 expert table" phrase? Maybe they mean Q8PLE table (n-gram), not "Q8 expert table". Shockem sources: Q8 n-gram from NVFP4 Basalt. Need provide exact source retrieval.

Need maybe retrieve `convert/gguf-sources.tar` in jesdga repo? It contains gguf sources for conversion, maybe includes table? Size 1.796 GB, likely not PLE. Not table.

Need maybe inspect jesdga README convert kit? The card says `convert/` holds inputs: MTP layer, vision projector, draft vocab. It doesn't mention PLE table source because packs include. Need Q8 table is inside NVFP4 `.basalt`.

Need maybe inspect Shockem previous model card exact text: "The n-gram table is Q8_0. ... n-gram table: `per_layer_token_embd.weight` from `Qwen3.8-FN-NVFP4.basalt` in that same repo. NVIDIA's FP8 table, reblocked to Q8_0." We have that.

Need answer Q5 with quality tradeoff. Need also note DFlash2 does not have direct quality eval because verified. There may be "quality" measured in model card? Flash-Next NInfer IQ3_S card has quality: NInfer computes what llama.cpp computes; perplexity; GSQ card evaluates but not run in NInfer. DFlash2 update says every answer matched decoding without drafts. So quality unchanged relative target model. But there is a caveat: DFlash2 is a learned drafter; its acceptance rate depends on target distribution. For abliterated model, acceptance may be slightly different, but not correctness. Under sampling, DFlash2 verifies proposal distribution by rejection sampling, so distribution exact. Under greedy, committed token is model's argmax. In batched concurrent runs, non-determinism due batch composition. MTP has exactness caveat too. DFlash2 cannot run pipeline stages; if using multi-GPU pipeline and not tensor parallel, MTP only. For your single 5090 with host experts, DFlash2 is supported and default.

Need Q6 actual batched decode. Need maybe compare with Basalt config JSON from user PR? User says "You already pulled my basalt serving config since you already read my PR which had it as small note of config json." In ninfer PR #370 we saw measured on Qwen3.8-27B and Flash-Next decisions, but not config JSON? Maybe in some PR? It might have had config snippet? We didn't search. But user says we already pulled. We can reference: Basalt config with models array, gpu 0,1, kv int8, resident-experts true maybe from Basalt README? Shockem uses 3x 5060 Ti and Basalt --spec 8. But user says PR had config JSON. Maybe in ninfer PR #370? It didn't show config. Maybe we need not.

Need maybe know ninfer-all batched decode config flags. We can read CLI docs for Flash-Next recipes and concurrency. Could search resource README for max-concurrency? We can read recipes? Use web_scrape configs for flash next? But enough. Maybe need exact `--max-concurrency`, `--max-context`, `--kv-dtype`, `--expert-residency`, `--spec dflash2`, `--draft-tokens`, `--draft-min-p`. Need answer: yes, via `--max-concurrency 1..8`. It is not "one process per model"? It is one resident Engine. It uses batched decode: one batched pass whose experts read weights once for whole batch. For decode rounds: up to eight requests run rounds together; one MTP pass per draft and one verification pass. DFlash2: round of several requests verifies at most 64 tokens; eight requests with 4 drafts = 40. So yes true batched decode. But caveat: some stateful layers run request by request; not every kernel is batched. Basalt also fixed rows. Need compare to Basalt's `--parallel`:
- Basalt: 1-8 slots; `--max-context` shared by default (each slot max-context/N), session affinity, checkpoints per slot, prompt beside decode.
- NInfer: `--max-concurrency` 1-8; each sequence own KV and recurrent state; context cache images/prefix reuse; prompt prefill interleaving; expert cache shared; no session affinity maybe prefix reuse; KV capacity maybe shared; supports up to eight concurrent requests and prefix reuse.
- NInfer's batched decode appears to be more integrated: one engine, dynamic prefix cache, checkpoint images, host/disk expert reads. But if user's main benefit is "true parallel decode", NInfer can do it for Flash-Next. Need mention Windows? NInfer supports Windows builds but Flash-Next Windows paths not run? Docs model status: Windows paths have not been run. So if user runs Linux, yes. Basalt supports Linux/Windows Blackwell. NInfer supports Linux and Windows? README says Linux or up to eight pipeline on Linux? For Windows maybe build? Flash-Next Windows not run. So likely use Linux.

Need maybe discuss "true parallel decode" semantics: In both, true parallelism at kernel level? Basalt `--parallel` has decode window serving every busy slot fixed rows; NInfer batched pass over up to 8 columns. It is "true parallel decode" in sense one forward evaluates multiple sequences simultaneously. It is not fully independent model instances; shared expert banks and cache. Basalt similarly expert tiers. Need not oversell.

Need maybe mention concurrency measurements from NInfer:
- RTX A6000 host experts, DFlash2 default four drafts: aggregate speed scales from 50-66 at 1 request to 114-119 at 8 requests (but ranges noisy). Without drafts 50-66 to 85-101. So batched decode improves aggregate throughput but not linear per-request.
- RTX 3090 eight requests released at once: with prompt spans, finished 1.77-1.94x faster with MTP over KV formats and 1.78x without drafts. That's about prefill batching and decode. But maybe not pure decode. Still evidence.
- MTP concurrency: with host experts CPU share, round <=64 tokens. DFlash2 default 4 drafts, 8 requests = 40 tokens, fits. Wider rounds reduce acceptance/speed. This is exactly analogous to Basalt's `dl` falling toward 1 as slots fill.
- Under tensor parallelism, DFlash2 works but pipeline stages refused. For multi-GPU, use `--tensor-parallel` not `--devices` pipeline for DFlash2. Basalt's multi-GPU layer split/peer expert tiers is different.

Need maybe answer Q1/Q3 again about Q8PLE source retrieval. User says "Retrieve that data because I believe the Q8 expert table, the exact one ShockM used, can be derived here for my conversion." Need maybe explicitly list exact source paths and sizes:
- Shockem current abliterated pack: `Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt`, file `Qwen3.8-FN-GSQ-RCO-abliterated-IQ3_S-Q8PLE.basalt`, size 113,491,281,169 bytes, LFS oid sha256 `36fdc5077666f18c39552e3cba40c707f3d066119fa86b69d5d3fe632d5f89c6`? Wait HF API lfs oid is sha256? For LFS, oid is sha256 of LFS object (file) likely yes. Need not cite as tensor. It is file hash. The tensor sha is e02bf...
- Shockem non-abliterated Q8PLE: `Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt`, file `Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE.basalt`, size 113,245,914,374, lfs oid cd7942...
- Source of table: jesdga `Qwen3.8-FN-NVFP4-DQ6_K.basalt`, size 131,681,979,197, lfs oid 177f...; current renamed from historical `Qwen3.8-FN-NVFP4.basalt`. Dense Q8 variant `-DQ8` size 132,367,747,589, lfs c96e...; table should be same Q8_0 PLE because NVFP4 packs both store ngram FP8 reblocked to Q8_0. But the "exact one ShockM used" according to card was official NVFP4 pack. Use `-DQ6_K` because that is official default. If the old plain file is unavailable, current official default is `-DQ6_K`.
- Tensor: `per_layer_token_embd.weight`, shape [160, 320001536], Q8_0, size 54,400,261,120 bytes, sha256 e02bf... (from Shockem card). This is the exact PLE table bytes. It lives in `.basalt` section `gguf`, offset recorded in `meta.tensors["per_layer_token_embd.weight"].offset` relative to section. Section `gguf` has SHA-256 in section table. The section aligns 2 MiB; tensor starts at kTensorAlign multiple within section. To extract: read `meta` JSON, find tensor offset/size, read section `gguf` at offset (section offset + tensor offset) for 54,400,261,120 bytes. Could use Basalt `tools/model_file.py` or `tools/migrations/basalt_v1_to_v2.py`? The migration reads sections; maybe no extract utility. But `tools/model_file.py` is Python side. Need maybe mention `include/basalt/core/model_format.hpp` section entry.

Need maybe exact NVIDIA FP8 source: `nvidia/Qwen3.8-Flash-Next-NVFP4` revision `fc694b54`, file `model-fp8-mtp-ple.safetensors`, size 53,717,551,730 bytes, LFS sha 352552... It contains MTP + PLE FP8? The Basalt converter reblocks NVIDIA FP8 table to Q8_0. If you want to derive from original NVIDIA, use that safetensors, but then need convert FP8 E4M3+scale to Q8_0 bytes. Easier to extract from Shockem/Basalt `.basalt`.

Need maybe "Q8 expert table" could refer to "Q8PLE" not experts. We should clarify: It is not an "expert" table in MoE-expert sense; it is the per-layer token embedding n-gram table (PLE). The routed experts are IQ3_S. The Q8 thing is `per_layer_token_embd.weight` (n-gram/PLE), not routed experts. Use terminology to avoid confusion.

Need maybe mention quality: Basalt model card measured IQ4 vs Q8 cosine 0.997, about 8% rms; official IQ3_S vs Q8_0 reference KLD 0.1547 top-1 87.25; NVFP4 KLD 0.0680 top-1 91.46. The Q8 ngram matches NVFP4 in table but experts still IQ3_S, so most gap remains. Shockem current says if using Q8PLE, experts still IQ3_S. The current abliterated pack measured? It has not scored refusal eval; decode speeds similar. It says Q8 table from official pack, routed experts 46.84, etc.

Need maybe answer "does dflash2 route have info written on quality compared against Flash Next quality?" There is no separate "quality" because verified. But there are draft acceptance and speed measurements. Could mention DFlash2 not lossy: `--relaxed-drafting` is Basalt lossy option; NInfer's exact acceptance. NInfer docs say every committed token model's own draw. DFlash2 verifies proposal distribution by rejection sampling. It doesn't change token sequence if execution profile fixed? Actually exactness not promised due floating reductions. For sampled, distribution exact. For greedy, output should equal plain decode if same arithmetic; measured every answer matched no-draft. But batch composition can change reductions and flip near ties. So quality tradeoff essentially none; only speed and acceptance.

Need maybe mention DFlash2 acceptance can be worse on ablated model? It may propose tokens with different acceptance because target distribution shifted, but correctness remains. If acceptance falls, speed benefit smaller. No evidence Shockem needs new drafter.

Need maybe mention DFlash2 draft token counts and memory:
- DFlash2 conditioned on model states after blocks 5,15,25,35,45; ring of last 2048 positions; 40 MiB per request. This is extra per-request memory. MTP block has own KV cache size of one sparse attention layer (2 KiB per position BF16) and 512-expert MoE; MTP block stored Q8_0, wider, expert cache slots. DFlash2 ring is 40 MiB/request, not huge but matters at 8 requests (320 MiB). MTP also has state. Which has more stress? DFlash2 smaller drafter weights, but per-request ring and 5-layer draft block compute. MTP has 512-expert MoE drafter and Q8_0 experts, much heavier. So DFlash2 likely lower resource stress, except it requires target states to be retained/projected. Need mention.

Need maybe compare with Basalt MTP: Basalt's self-distilled MTP layer maybe in VRAM? Basalt docs: drafter Q8_0/BF16 dense; Q2_0 experts in VRAM. It has MTP on by default. DFlash2 for Basalt 27B only. So moving to NInfer DFlash2 is a net resource reduction for drafter.

Need maybe final recommendation: If quality over quantity and single 5090 + 64GB, use:
- make Shockem-like `.ninfer` with IQ4 table first
- attach DFlash2
- serve `--max-concurrency 2-4`? For 64GB and 100GB pack, maybe 1-2 requests. Basalt batched parallel on 3x5060 Ti? User's current 3x5060 Ti 16GB = 48GB VRAM, expert RAM 37GB. On 5090 32GB + 64GB, host experts 48.7GB pinned; KV etc. With 64GB, max-concurrency maybe 1 or 2, not 8. Need mention concurrency is RAM-bound. For IQ3_S host experts, pinned experts ~48-50GB. Each concurrent sequence adds KV and recurrent state/snapshot. The docs: each sequence costs device memory KV of max-context positions (24 KiB/pos BF16, less quantized), plus 74 MiB recurrent state and 74 MiB snapshot allocated startup. That's 148 MiB per sequence just state/snapshot, plus KV. With 64GB and pinned experts, maybe 2 requests at 32K? Need not exact. But answer Q6: yes 1-8 by engine, but practical concurrency bounded by RAM/KV. Basalt also shared context. With your 64GB, likely do not expect 8-request true parallel decode at large context; 2-4 maybe depending context/KV quantization. On 124GB test host, 8 requests measured. Your 64GB is tight.

Need maybe mention NInfer `--max-concurrency` and `--kv-capacity`. In generic serving: max-context per request, shared KV capacity. For Flash-Next docs, each sequence cost. To enable batched decode, use `--max-concurrency 2` or 4. Example:
```
ninfer-serve model.ninfer --ngram-table table.ninfer --model-id qwen3.8-flash-next --expert-residency host --max-context 32768 --max-concurrency 4 --kv-dtype rk8v4 --spec dflash2 --draft-tokens 4 --draft-min-p 0.7
```
But need not overstate flags. Use `--max-concurrency`, not `--parallel`. Basalt uses `--parallel`; NInfer uses `--max-concurrency`.

Need maybe include exact DFlash2 serve command from model card:
```
--spec dflash2 --draft-tokens 5
```
or default four with floor 0.7. For concurrency, add `--max-concurrency 2` etc.

Need maybe answer "final question after you completely find this without a doubt". Need phrase "I found it without doubt". Need cite exact sources.

Let's also inspect the Shockem current model card text maybe already scraped. It says "Experts come from SC117 ... Converted with Basalt ... --sections-from official IQ3_S pack that already carries Q8 n-gram ([Shockem/Qwen3.8-FN...]) Those copied sections... After conversion ngram still IQ4_NL ... replaced with Q8_0 table from that same official pack, copied byte for byte." Wait current card says official IQ3_S pack carries Q8 n-gram? It says "Converted with Basalt --sections-from the official IQ3_S pack that already carries the Q8 n-gram (Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt). Those copied sections were the self-distilled MTP drafter, vision projector, expert profile, tokenizer. The version-2 migration dropped profile. ... After conversion the n-gram was still IQ4_NL (26.8 GiB). It was then replaced with Q8_0 table from that same official pack, copied byte for byte." Hmm slight inconsistency: "official IQ3_S pack that already carries Q8 n-gram" refers Shockem pack? Current card says "Converted with Basalt `--sections-from` the official IQ3_S pack that already carries the Q8 n-gram (Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt)." It uses Shockem's previous Q8PLE pack as donor for MTP/vision/tokenizer and Q8 table. It then says after conversion ngram still IQ4_NL, replaced with Q8_0 table from that same official pack. The previous card says table from jesdga NVFP4. So exact source: the Q8 table bytes are the same tensor in Shockem's previous `.basalt`, which got them from jesdga NVFP4. So for conversion, easiest source is Shockem's previous `.basalt` `Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE.basalt`, not jesdga. But if you want exact Shockem current abliterated, you can extract from current abliterated `.basalt` too; the Q8 table bytes same SHA. The tensor SHA e02bf... is authoritative. Need state.

Need maybe use HF API to get current file lfs sha. Already have. Could include table:

| Where | Exact object | Size | Hash/identity |
|---|---|---:|---|
| Shockem current abliterated pack | `Qwen3.8-FN-GSQ-RCO-abliterated-IQ3_S-Q8PLE.basalt` | 113,491,281,169 bytes | file LFS SHA `36fdc507...` |
| Shockem non-abliterated Q8PLE donor | `Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE.basalt` | 113,245,914,374 bytes | file LFS SHA `cd7942f2...` |
| Original Basalt NVFP4 source | `Qwen3.8-FN-NVFP4-DQ6_K.basalt` | 131,681,979,197 bytes | file LFS SHA `177f9b70...` |
| Tensor inside | `per_layer_token_embd.weight` | 54,400,261,120 bytes | SHA `e02bf3d7...` |
| NVIDIA original FP8 source | `model-fp8-mtp-ple.safetensors` | 53,717,551,730 bytes | LFS SHA `3525520c...` |

Need be careful HF API `oid` for file maybe not LFS sha? It includes lfs.oid. Use lfs.oid for LFS files. For small README oid is git blob not SHA256? For LFS files, `lfs.oid` is sha256. Good.

Need maybe mention exact Q8PLE table tensor is inside `.basalt` `gguf` section. Basalt model_format: `gguf` section contains non-expert tensors raw bytes; meta.tensors[name].offset relative to section. So extraction algorithm:
```
python tools/model_file.py? or read header:
- parse 64KiB header
- find SectionEntry name == 'gguf'
- parse meta section JSON
- tensor = meta['tensors']['per_layer_token_embd.weight']
- read file at section.offset + tensor['offset'], tensor['size']
```
No extraction utility specified; need maybe write 20-line Python. Could give pseudo-code. Basalt `tools/model_file.py` is Python side of layout and must be byte-compatible; likely can read sections. But user asks retrieve data, not necessarily code. Could provide exact data and pipeline.

Need maybe discuss converting exact Q8 table to `.ninfer`: The NInfer published recipe may expect GGUF table. To extract and make GGUF:
- Need write GGUF with tensor name/type/shape. Could use `gguf-py` (llama.cpp Python) to write GGUF. But `per_layer_token_embd.weight` Q8_0 tensor shape [160,320001536]. GGUF tensor alignment 4096; raw bytes already tensor data. Need set metadata `general.architecture: qwen4exp`? NInfer's converter may need metadata from `--model` config, not source table? The converter reads table shard for rows, and `--model` supplies config. The table source may just be tensor-only GGUF. But NInfer says "additional tensor-only sources can omit model config; sources carrying config are checked..." For `--source ngram=PATH`, likely path ends .gguf, opened as GGUF source. It may require the source GGUF has the tensor and possibly metadata. Could write minimal GGUF with `general.architecture: qwen4exp` and tensor. But row format expected? NInfer's `qwen3_8_flash_next_gguf` recipe may specifically look for `per_layer_token_embd.weight` and IQ4_NL? It might accept any ggml type? If recipe hardcoded IQ4_NL, custom recipe needed. Need say likely small recipe tweak: set ngram format/layout to `gguf_q8_0` / `gguf_blocks_v1`. The docs say GGUF block formats include Q8_0. The ngram component row format is recorded. Runtime accepts any table of same shape and row format. So converter can be adapted.

Need maybe check NInfer source qwen4_exp_gguf.py for table handling? Could scrape. Let's see if useful.


</details>

<details><summary>Tool request · web_scrape · call_8d720c077e1642f3b14f7a28</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/qwen4_exp_gguf.py"
}
```

</details>


<details><summary>Tool result · web_scrape · call_8d720c077e1642f3b14f7a28</summary>

**Firecrawl · section 1 of 4**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,999 characters · included below
- Section 2 · 11,994 characters · omitted from this copy
- Section 3 · 11,969 characters · omitted from this copy
- Section 4 · 6,463 characters · omitted from this copy

```text
[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/qwen4_exp_gguf.py#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/qwen4_exp_gguf.py)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/qwen4_exp_gguf.py)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/qwen4_exp_gguf.py)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

/

qwen4\_exp\_gguf.py
===================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/tools/convert/qwen4_exp_gguf.py)

[](https://github.com/iamwavecut/ninfer-all/commits/master/tools/convert/qwen4_exp_gguf.py)
History

895 lines (779 loc) · 42.8 KB

/

qwen4\_exp\_gguf.py
===================

Copy path

Top

File metadata and controls
--------------------------

*   Code

*   Blame


895 lines (779 loc) · 42.8 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/tools/convert/qwen4_exp_gguf.py)

Copy raw file

Download raw file

Open symbols panel

Edit and raw actions

"""
    """A Qwen3.8-Flash-Next GGUF (llama.cpp \`\`qwen4exp\`\`) kept in its own ggml block formats. The GSQ-RCO releases store every matrix in the type its allocation chose, one ggml type per tensor, so no weight is re-quantised: a row of the artifact is byte for byte a row of the GGUF, and the expert banks keep the exporter's expert-major layout. The hyper-connection matrices, BF16 in the release, become ggml Q8\_0 rows, the one re-quantised form, which their kernels read; the other BF16 matrices (router, indexer, the GDN gates) stay BF16; F32/F16 vectors become the artifact's direct formats. llama.cpp's exporter conventions are undone where they touch rows or small tensors: Gated DeltaNet value heads return to the grouped order (stored \`\`ssm\_out\`\` blocks keep their tiled input columns, which a row copy cannot move, and their import carries them as an \`\`input\_columns\`\` auxiliary; its values and BF16 rows return to the grouped order), zero-centred norms drop their stored \`\`1 + w\`\` (every norm but \`\`ssm\_norm\`\`), \`\`ssm\_a\`\` becomes \`\`A\_log\`\` again, the head- interleaved \`\`attn\_q\`\` splits into query and gate rows, and the indexer's split projections and the squeezed PLE convolution keep the layout the HF adapter (qwen4\_exp.py) declares. The first shard of a GSQ-RCO release holds the model; the second holds only \`\`per\_layer\_token\_embd\`\`, the n-gram table, which every release shares byte for byte. A llama.cpp split (Unsloth's releases: the metadata in the first shard, the tensors in the next ones, the table in the last) is read as one file from its first shard (\`\`GGUFSplit\`\`), and its last shard is the \`\`ngram\`\` source. The MTP block comes from an MTP GGUF of its own (Unsloth's \`\`MTP/\`\` folder), block 48 with \`\`nextn.\*\`\` tensors and no embedding or head. The recipe imports it row for row as the \`\`ngram\`\` component's table, into the model's artifact or into a table artifact of its own, and records the SHA-256 of its bytes, by which a model stored without the table names the one it reads. """
    """ from \_\_future\_\_ import annotations import hashlib from math import prod import numpy as np import torch from tools.artifact.formats import GGUF\_FORMATS\_BY\_TYPE from .gguf\_blocks import ( GGML\_Q8\_0, \_dequantize, \_vision\_source, block\_format, block\_source, dequantize\_q8\_0, q2\_native\_source, q8\_native\_source, quantize\_q8\_0, ) from .methods import cast\_direct, import\_encoded from .sources.gguf import TYPE\_BF16, TYPE\_F16, TYPE\_F32, GGUFFile from .sources.logical import EncodedRows, LogicalSource, array\_source from .ternary import ( GDN\_CHANNELS, GDN\_HEAD\_DIM, GDN\_KEY\_DIM, GDN\_VALUE\_DIM, GDN\_VALUE\_HEADS, RowMap, \_flat, attention\_rows, rows, tiled\_to\_grouped\_permutation, untile, untiled\_rows, ) from .gguf\_blocks import tiled\_input\_columns HIDDEN = 2560 LAYERS = 48 VOCABULARY = 248320 STREAMS = 4 WIDTH = STREAMS \* HIDDEN LOWRANK = 320 EXPERTS = 512 EXPERT\_WIDTH = 640 SHARED\_WIDTH = 640 QUERY\_ROWS = 24 \* 256 KV\_ROWS = 2 \* 256 HEAD\_DIM = 256 INDEXER\_HEADS = 4 INDEXER\_DIM = 128 NGRAM\_WIDTH = 160 NGRAM\_HEADS = 16 NGRAM\_TENSOR = "per\_layer\_token\_embd.weight" EXPECTED\_HEADER = { "general.architecture": "qwen4exp", "qwen4exp.block\_count": LAYERS, "qwen4exp.embedding\_length": HIDDEN, "qwen4exp.attention.head\_count": 24, "qwen4exp.attention.head\_count\_kv": 2, "qwen4exp.attention.key\_length": HEAD\_DIM, "qwen4exp.attention.value\_length": HEAD\_DIM, "qwen4exp.expert\_used\_count": 10, "qwen4exp.expert\_feed\_forward\_length": EXPERT\_WIDTH, "qwen4exp.expert\_shared\_feed\_forward\_length": SHARED\_WIDTH, "qwen4exp.ssm.conv\_kernel": 4, "qwen4exp.ssm.state\_size": GDN\_HEAD\_DIM, "qwen4exp.ssm.group\_count": 16, "qwen4exp.ssm.time\_step\_rank": GDN\_VALUE\_HEADS, "qwen4exp.ssm.inner\_size": GDN\_VALUE\_DIM, "qwen4exp.full\_attention\_interval": 4, "qwen4exp.hyper\_connection.count": STREAMS, "qwen4exp.hyper\_connection.low\_rank": LOWRANK, "qwen4exp.attention.indexer.head\_count": INDEXER\_HEADS, "qwen4exp.attention.indexer.key\_length": INDEXER\_DIM, "qwen4exp.attention.indexer.top\_k": 2048, "qwen4exp.ple.layers": \[1\], "qwen4exp.ple.ngram\_size": 3, "qwen4exp.ple.heads\_per\_ngram": 8, "qwen4exp.ple.conv\_kernel": 4, "qwen4exp.embedding\_length\_per\_layer\_input": NGRAM\_WIDTH, } # What a tensor may be stored as: a ggml block matrix or BF16 ("matrix"), or a direct vector. MATRIX = "matrix" DIRECT = (TYPE\_F32, TYPE\_F16, TYPE\_BF16) # The MTP block of an MTP GGUF (Unsloth's \`MTP/mtp-Qwen3.8-Flash-Next-shared-\*.gguf\`): the trailing # block 48, which shares the token embedding and the head with the model it drafts for. MTP\_BLOCK = LAYERS MTP\_HEADER = { "general.architecture": "qwen4exp", "qwen4exp.block\_count": LAYERS + 1, "qwen4exp.nextn\_predict\_layers": 1, "qwen4exp.nextn\_shared\_target\_tensors": True, "qwen4exp.embedding\_length": HIDDEN, "qwen4exp.attention.head\_count": 24, "qwen4exp.attention.head\_count\_kv": 2, "qwen4exp.attention.key\_length": HEAD\_DIM, "qwen4exp.attention.value\_length": HEAD\_DIM, "qwen4exp.expert\_used\_count": 10, "qwen4exp.expert\_feed\_forward\_length": EXPERT\_WIDTH, "qwen4exp.expert\_shared\_feed\_forward\_length": SHARED\_WIDTH, "qwen4exp.hyper\_connection.count": STREAMS, "qwen4exp.hyper\_connection.low\_rank": LOWRANK, "qwen4exp.attention.indexer.head\_count": INDEXER\_HEADS, "qwen4exp.attention.indexer.key\_length": INDEXER\_DIM, "qwen4exp.attention.indexer.top\_k": 2048, } def untiled\_heads() -> RowMap: """
    """Grouped value heads of a \[heads, k\] matrix (one row per head) stored tiled."""
    """ permutation = tiled\_to\_grouped\_permutation() def select(begin: int, end: int) -> np.ndarray: return permutation\[np.arange(begin, end, dtype=np.int64)\] return select def full\_attention(layer: int) -> bool: return layer % 4 == 3 def \_hc(prefix: str) -> dict\[str, tuple\[tuple\[int, ...\], str\]\]: return { prefix + "norm.weight": ((WIDTH,), "direct"), prefix + "down.weight": ((LOWRANK, WIDTH), MATRIX), prefix + "up.weight": ((WIDTH, LOWRANK), MATRIX), } def expected\_tensors( ple\_layers: tuple\[int, ...\] = (1,), experts: int = EXPERTS, routed: bool = True ) -> dict\[str, tuple\[tuple\[int, ...\], str\]\]: """
    """Row-major shape and kind of every tensor of the model shard; an expert-pruned release keeps \`experts\` of the 512 (and one router row for each). A skeleton GGUF, whose routed experts are stored elsewhere (an Edge0 release), has none of the three expert banks (\`routed\` false)."""
    """ out = { "token\_embd.weight": ((VOCABULARY, HIDDEN), MATRIX), "output.weight": ((VOCABULARY, HIDDEN), MATRIX), "output\_hc\_norm.weight": ((WIDTH,), "direct"), "output\_hc\_down.weight": ((LOWRANK, WIDTH), MATRIX), "output\_hc\_up.weight": ((WIDTH, LOWRANK), MATRIX), } for layer in range(LAYERS): p = f"blk.{layer}." for half in ("attn", "ffn"): out |= { p + f"hc\_{half}\_norm.weight": ((WIDTH,), "direct"), p + f"hc\_{half}\_down.weight": ((LOWRANK, WIDTH), MATRIX), p + f"hc\_{half}\_up.weight": ((WIDTH, LOWRANK), MATRIX), p + f"hc\_{half}\_inject.weight": ((STREAMS, WIDTH), MATRIX), } out |= { p + "ffn\_gate\_inp.weight": ((experts, HIDDEN), MATRIX), p + "ffn\_gate\_inp\_shexp.weight": ((HIDDEN,), "direct"), p + "ffn\_gate\_shexp.weight": ((SHARED\_WIDTH, HIDDEN), MATRIX), p + "ffn\_up\_shexp.weight": ((SHARED\_WIDTH, HIDDEN), MATRIX), p + "ffn\_down\_shexp.weight": ((HIDDEN, SHARED\_WIDTH), MATRIX), } if routed: out |= { p + "ffn\_gate\_exps.weight": ((experts, EXPERT\_WIDTH, HIDDEN), MATRIX), p + "ffn\_up\_exps.weight": ((experts, EXPERT\_WIDTH, HIDDEN), MATRIX), p + "ffn\_down\_exps.weight": ((experts, HIDDEN, EXPERT\_WIDTH), MATRIX), } if full\_attention(layer): out |= { p + "attn\_q.weight": ((2 \* QUERY\_ROWS, HIDDEN), MATRIX), p + "attn\_k.weight": ((KV\_ROWS, HIDDEN), MATRIX), p + "attn\_v.weight": ((KV\_ROWS, HIDDEN), MATRIX), p + "attn\_output.weight": ((HIDDEN, QUERY\_ROWS), MATRIX), p + "attn\_q\_norm.weight": ((HEAD\_DIM,), "direct"), p + "attn\_k\_norm.weight": ((HEAD\_DIM,), "direct"), p + "indexer.q\_proj.weight": ((INDEXER\_HEADS \* INDEXER\_DIM, HIDDEN), MATRIX), p + "indexer.k\_proj.weight": ((INDEXER\_DIM, HIDDEN), MATRIX), p + "indexer.q\_norm.weight": ((INDEXER\_DIM,), "direct"), p + "indexer.k\_norm.weight": ((INDEXER\_DIM,), "direct"), } else: out |= { p + "attn\_qkv.weight": ((GDN\_CHANNELS, HIDDEN), MATRIX), p + "attn\_gate.weight": ((GDN\_VALUE\_DIM, HIDDEN), MATRIX), p + "ssm\_out.weight": ((HIDDEN, GDN\_VALUE\_DIM), MATRIX), p + "ssm\_alpha.weight": ((GDN\_VALUE\_HEADS, HIDDEN), MATRIX), p + "ssm\_beta.weight": ((GDN\_VALUE\_HEADS, HIDDEN), MATRIX), p + "ssm\_a": ((GDN\_VALUE\_HEADS,), "direct"), p + "ssm\_dt.bias": ((GDN\_VALUE\_HEADS,), "direct"), p + "ssm\_conv1d.weight": ((GDN\_CHANNELS, 4), "direct"), p + "ssm\_norm.weight": ((GDN\_HEAD\_DIM,), "direct"), } if layer in ple\_layers: out |= { p + "ple\_key.weight": ((WIDTH, HIDDEN), MATRIX), p + "ple\_value.weight": ((HIDDEN, HIDDEN), MATRIX), p + "ple\_norm\_key.weight": ((WIDTH,), "direct"), p + "ple\_norm\_query.weight": ((WIDTH,), "direct"), p + "ple\_norm\_conv.weight": ((WIDTH,), "direct"), p + "ple\_conv1d.weight": ((WIDTH, 4), "direct"), } return out def \_qsa\_layer(p: str, experts: int) -> dict\[str, tuple\[tuple\[int, ...\], str\]\]: """
    """A sparse-attention block's tensors with their MoE (the MTP block's layer)."""
    """ out = {} for half in ("attn", "ffn"): out |= { p + f"hc\_{half}\_norm.weight": ((WIDTH,), "direct"), p + f"hc\_{half}\_down.weight": ((LOWRANK, WIDTH), MATRIX), p + f"hc\_{half}\_up.weight": ((WIDTH, LOWRANK), MATRIX), p + f"hc\_{half}\_inject.weight": ((STREAMS, WIDTH), MATRIX), } return out | { p + "attn\_q.weight": ((2 \* QUERY\_ROWS, HIDDEN), MATRIX), p + "attn\_k.weight": ((KV\_ROWS, HIDDEN), MATRIX), p + "attn\_v.weight": ((KV\_ROWS, HIDDEN), MATRIX), p + "attn\_output.weight": ((HIDDEN, QUERY\_ROWS), MATRIX), p + "attn\_q\_norm.weight": ((HEAD\_DIM,), "direct"), p + "attn\_k\_norm.weight": ((HEAD\_DIM,), "direct"), p + "indexer.q\_proj.weight": ((INDEXER\_HEADS \* INDEXER\_DIM, HIDDEN), MATRIX), p + "indexer.k\_proj.weight": ((INDEXER\_DIM, HIDDEN), MATRIX), p + "indexer.q\_norm.weight": ((INDEXER\_DIM,), "direct"), p + "indexer.k\_norm.weight": ((INDEXER\_DIM,), "direct"), p + "ffn\_gate\_inp.weight": ((experts, HIDDEN), MATRIX), p + "ffn\_gate\_inp\_shexp.weight": ((HIDDEN,), "direct"), p + "ffn\_gate\_exps.weight":
```

</details>

## Assistant · #85

<details><summary>Reasoning · 321 characters</summary>

Need inspect qwen4_exp_gguf.py ngram assignment to see if it uses block_format any type or hardcodes IQ4_NL. Search resource? Could read sections around ngram. Let's use resource_search? allowed resource dfbffb not in enum. Can't. Could web_scrape raw and maybe sections? Already indexed 4. Read section 3/4 maybe ngram.


</details>

<details><summary>Tool request · context_read · call_50bfd7485a574f7d9d55cff5</summary>

```json
{
  "kind": "resource",
  "id": "dfbffb17-8cbf-41de-8956-ed53c1cb6dd6",
  "section": 3
}
```

</details>

<details><summary>Tool request · context_read · call_54e34fcbe82849e7b69a69d8</summary>

```json
{
  "kind": "resource",
  "id": "dfbffb17-8cbf-41de-8956-ed53c1cb6dd6",
  "section": 4
}
```

</details>


<details><summary>Tool result · context_read · call_50bfd7485a574f7d9d55cff5</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/qwen4_exp_gguf.py · section 3/4

HIDDEN)) matrix(i + "key", g + "indexer.k\_proj.weight", (INDEXER\_DIM, HIDDEN)) direct(i + "query\_norm", \_norm(gguf, g + "indexer.q\_norm.weight", True)) direct(i + "key\_norm", \_norm(gguf, g + "indexer.k\_norm.weight", True)) \_moe\_sources(out, gguf, g, p + "moe/", experts) return out def \_moe\_sources(out: dict, gguf: GGUFFile, g: str, m: str, experts: int, routed: bool = True) -> None: out\[m + "router"\] = matrix\_source(gguf, g + "ffn\_gate\_inp.weight", (experts, HIDDEN), rows()) out\[m + "shared\_score"\] = ( \_direct(\_words(gguf, g + "ffn\_gate\_inp\_shexp.weight").reshape(1, HIDDEN), torch.bfloat16, g + "ffn\_gate\_inp\_shexp.weight"), False, ) for expert in range(experts if routed else 0): e = m + f"experts/{expert}/" out\[e + "gate"\] = matrix\_source(gguf, g + "ffn\_gate\_exps.weight", (EXPERT\_WIDTH, HIDDEN), rows(expert \* EXPERT\_WIDTH)) out\[e + "up"\] = matrix\_source(gguf, g + "ffn\_up\_exps.weight", (EXPERT\_WIDTH, HIDDEN), rows(expert \* EXPERT\_WIDTH)) out\[e + "down"\] = matrix\_source(gguf, g + "ffn\_down\_exps.weight", (HIDDEN, EXPERT\_WIDTH), rows(expert \* HIDDEN)) out\[m + "shared/gate"\] = matrix\_source(gguf, g + "ffn\_gate\_shexp.weight", (SHARED\_WIDTH, HIDDEN), rows()) out\[m + "shared/up"\] = matrix\_source(gguf, g + "ffn\_up\_shexp.weight", (SHARED\_WIDTH, HIDDEN), rows()) out\[m + "shared/down"\] = matrix\_source(gguf, g + "ffn\_down\_shexp.weight", (HIDDEN, SHARED\_WIDTH), rows()) def text\_sources(gguf: GGUFFile, config: dict, source\_layers: tuple\[int, ...\] | None = None, routed: bool = True) -> dict\[str, tuple\[LogicalSource, bool\]\]: """
    """Every text parameter's GGUF source; True marks encoded block rows. A skeleton GGUF supplies every parameter but the routed experts (\`routed\` false)."""
    """ out: dict\[str, tuple\[LogicalSource, bool\]\] = {} def matrix(name: str, tensor: str, shape: tuple\[int, int\], select: RowMap = rows(), columns: np.ndarray | None = None): out\[name\] = matrix\_source(gguf, tensor, shape, select, columns) def direct(name: str, source: LogicalSource): out\[name\] = (source, False) def hc(prefix: str, stored: str, inject: bool): direct(prefix + "norm", \_norm(gguf, stored + "norm.weight", True)) out\[prefix + "down"\] = hc\_matrix\_source(gguf, stored + "down.weight", (LOWRANK, WIDTH)), True out\[prefix + "up"\] = hc\_matrix\_source(gguf, stored + "up.weight", (WIDTH, LOWRANK)), True if inject: out\[prefix + "inject"\] = ( hc\_matrix\_source(gguf, stored + "inject.weight", (STREAMS, WIDTH)), True ) matrix("text/token\_embedding", "token\_embd.weight", (VOCABULARY, HIDDEN)) matrix("text/output\_head", "output.weight", (VOCABULARY, HIDDEN)) hc("text/final\_mixer/", "output\_hc\_", inject=False) indices = range(config\["num\_hidden\_layers"\]) if source\_layers is None else source\_layers for layer, source\_layer in enumerate(indices): g, p = f"blk.{source\_layer}.", f"text/layers/{layer}/" hc(p + "attn\_hc/", g + "hc\_attn\_", inject=True) hc(p + "mlp\_hc/", g + "hc\_ffn\_", inject=True) if config\["layer\_types"\]\[layer\] == "full\_attention": a = p + "attention/" matrix(a + "query", g + "attn\_q.weight", (QUERY\_ROWS, HIDDEN), attention\_rows(False)) matrix(a + "gate", g + "attn\_q.weight", (QUERY\_ROWS, HIDDEN), attention\_rows(True)) matrix(a + "key", g + "attn\_k.weight", (KV\_ROWS, HIDDEN)) matrix(a + "value", g + "attn\_v.weight", (KV\_ROWS, HIDDEN)) matrix(a + "output", g + "attn\_output.weight", (HIDDEN, QUERY\_ROWS)) direct(a + "query\_norm", \_norm(gguf, g + "attn\_q\_norm.weight", True)) direct(a + "key\_norm", \_norm(gguf, g + "attn\_k\_norm.weight", True)) i = p + "indexer/" matrix(i + "query", g + "indexer.q\_proj.weight", (INDEXER\_HEADS \* INDEXER\_DIM, HIDDEN)) matrix(i + "key", g + "indexer.k\_proj.weight", (INDEXER\_DIM, HIDDEN)) direct(i + "query\_norm", \_norm(gguf, g + "indexer.q\_norm.weight", True)) direct(i + "key\_norm", \_norm(gguf, g + "indexer.k\_norm.weight", True)) else: n = p + "gdn/" qkv = g + "attn\_qkv.weight" matrix(n + "query", qkv, (GDN\_KEY\_DIM, HIDDEN)) matrix(n + "key", qkv, (GDN\_KEY\_DIM, HIDDEN), rows(GDN\_KEY\_DIM)) matrix(n + "value", qkv, (GDN\_VALUE\_DIM, HIDDEN), untiled\_rows(2 \* GDN\_KEY\_DIM)) matrix(n + "z", g + "attn\_gate.weight", (GDN\_VALUE\_DIM, HIDDEN), untiled\_rows(0)) # Tiled input columns: an import keeps them and its Use gathers the grouped activation. matrix(n + "output", g + "ssm\_out.weight", (HIDDEN, GDN\_VALUE\_DIM), rows(), tiled\_input\_columns()) for role, tensor in (("a\_projection", "ssm\_alpha.weight"), ("b\_projection", "ssm\_beta.weight")): matrix(n + role, g + tensor, (GDN\_VALUE\_HEADS, HIDDEN), untiled\_heads()) ssm\_a = untile(\_words(gguf, g + "ssm\_a"), 1).astype(np.float64) if not np.all(ssm\_a < 0): raise ValueError(f"{g}ssm\_a must be strictly negative (-exp(A\_log))") direct(n + "a\_log", \_direct(np.log(-ssm\_a).astype(np.float32), torch.float32, g + "ssm\_a")) direct(n + "dt\_bias", \_direct(untile(\_words(gguf, g + "ssm\_dt.bias"), 1), torch.float32, g + "ssm\_dt.bias")) taps = \_words(gguf, g + "ssm\_conv1d.weight") channels = np.concatenate(\[taps\[: 2 \* GDN\_KEY\_DIM\], untile(taps\[2 \* GDN\_KEY\_DIM:\], GDN\_HEAD\_DIM)\]) direct(n + "convolution", \_direct(channels.T, torch.bfloat16, g + "ssm\_conv1d.weight")) direct(n + "norm", \_norm(gguf, g + "ssm\_norm.weight", False)) \_moe\_sources(out, gguf, g, p + "moe/", config\["num\_experts"\], routed) if layer in config\["ple\_layers"\]: q = p + "ple/" matrix(q + "key", g + "ple\_key.weight", (WIDTH, HIDDEN)) matrix(q + "value", g + "ple\_value.weight", (HIDDEN, HIDDEN)) for role in ("norm\_key", "norm\_query", "norm\_conv"): direct(q + role, \_norm(gguf, g + f"ple\_{role}.weight", True)) # Each channel's taps stay contiguous, oldest first (the HF conv squeezed). direct(q + "convolution", \_direct(\_words(gguf, g + "ple\_conv1d.weight"), torch.bfloat16, g + "ple\_conv1d.weight")) return out def \_assign(recipe, name: str, source: LogicalSource, encoded: bool, model) -> str: if encoded: format = source.read\_encoded(0, 1).format # The hyper-connection kernels keep their activations FP32: the default A16Only Use. mixer = name.rsplit("/", 2)\[-2\] in ("attn\_hc", "mlp\_hc", "final\_mixer") recipe.assign(name, format=format, method=import\_encoded, source=source, activation\_policy=None if mixer else "AllowA8") return format format = model.parameters\[name\].direct\_format recipe.assign(name, format=format, method=cast\_direct, source=source) return format def \_group\_same\_format(recipe, names: list\[str\], formats: dict\[str, str\]) -> None: if len({formats\[name\] for name in names}) == 1: recipe.group(names) def \_group\_attention(recipe, p: str, formats: dict\[str, str\]) -> None: a = p + "attention/" \_group\_same\_format(recipe, \[a + "query", a + "gate"\], formats) \_group\_same\_format(recipe, \[a + "key", a + "value"\], formats) \_group\_same\_format(recipe, \[p + "indexer/query", p + "indexer/key"\], formats) def \_group\_moe(recipe, m: str, experts: int, formats: dict\[str, str\]) -> None: gates = \[m + f"experts/{e}/gate" for e in range(experts)\] ups = \[m + f"experts/{e}/up" for e in range(experts)\] if formats\[gates\[0\]\] == formats\[ups\[0\]\]: # Each expert's gate rows then its up rows, expert-major: one \[gate; up\] parent per # expert, one bank per layer. recipe.group(\[name for pair in zip(gates, ups) for name in pair\]) else: recipe.group(gates) recipe.group(ups) recipe.group(\[m + f"experts/{e}/down" for e in range(experts)\]) recipe.group(\[m + "router", m + "shared\_score"\]) \_group\_same\_format(recipe, \[m + "shared/gate", m + "shared/up"\], formats) def configure\_ngram\_gguf(model, recipe, table): """
    """Bind IQ4\_NL table rows and record the digest of their stored bytes."""
    """ if not isinstance(table, GGUFFile): raise ValueError("--source ngram must name the release's n-gram table shard (.gguf)") descriptor = model.components\["ngram"\]\["config"\] source = ngram\_source(table, descriptor\["rows"\]) descriptor\["format"\] = source.read\_encoded(0, 1).format if descriptor\["format"\] != "gguf\_iq4\_nl": raise ValueError("the n-gram GGUF table must contain IQ4\_NL rows") size = table.info(NGRAM\_TENSOR).nbytes print(f"hashing the n-gram table ({size / 1e9:.1f} GB)", flush=True) descriptor\["table\_sha256"\] = table\_digest(table) if "ngram/table" in model.parameters: recipe.assign("ngram/table", format=descriptor\["format"\], method=import\_encoded, source=source) def qwen3\_8\_flash\_next\_gguf(model, recipe, sources): """
    """A Qwen3.8-Flash-Next GGUF release (GSQ-RCO's two shards or a llama.cpp split) in its own block formats: the first shard as \`--source gguf=SHARD1.gguf\` (for the text component) and the n-gram table shard, the release's last, as \`--source ngram=SHARD.gguf\`, which is always read, since the model records the digest of the table it reads even when the table's rows go into an artifact of their own. The Vision tower comes from the release's BF16 \`mmproj\` GGUF (\`--source vision=mmproj.gguf\`) and stays BF16; the MTP block from an MTP GGUF (\`--source mtp=mtp-\*.gguf\`), whose matrices keep their blocks. Every hyper-connection matrix is stored as ggml Q8\_0 rows (hc\_matrix\_source)."""
    """ from .qwen4\_exp\_ngram import configure\_ngram if "text" not in model.components: configure\_ngram(model, recipe, sources\["ngram"\]) return config = model.config if config.get("architectures") != \["Qwen4ExpForCausalLM"\]: raise ValueError("the qwen4exp GGUF recipe requires a Qwen3.8-Flash-Next model") gguf = sources\["gguf"\] if not isinstance(gguf, GGUFFile): raise ValueError("--source gguf must name the model's first .gguf shard") validate(gguf, config, model.source\_layers) formats: dict\[str, str\] = {} for name, (text\_source, encoded) in text\_sources(gguf, config, model.source\_layers).items(): formats\[name\] = \_assign(recipe, name, text\_source, encoded, model) if "mtp" in model.components: from .official\_recipes import flash\_next\_mtp\_formats from .sources.safetensors import SafetensorsSource mtp = sources\["mtp"\] experts = model.components\["mtp"\]\["config"\]\["num\_experts"\] if isinstance(mtp, SafetensorsSource): formats.update(flash\_next\_mtp\_formats(model, recipe)) elif isinstance(mtp, GGUFFile): validate\_mtp(mtp, experts) for name, (mtp\_source, encoded) in mtp\_sources(mtp, experts).items(): formats\[name\] = \_assign(recipe, name, mtp\_source, encoded, model) else: raise ValueError("--source mtp must name an MTP GGUF or HF safetensors subset") if "vision" in model.components: vision = \_vision\_source(model, sources) for name, parameter in model.parameters.items(): if name.startswith("vision/"): formats\[name\] = parameter.direct\_format recipe.assign(name, format=parameter.direct\_format, method=cast\_direct, source=model.source(name, vision)) if set(formats) != set(model.parameters) - {"ngram/table"}: missing = sorted(set(model.parameters) - set(formats) - {"ngram/table"})\[:5\] raise ValueError(f"the GGUF leaves logical parameters without a source: {missing}") # A malformed model, missing component or invalid source must fail before the large scan. if "ngram" in model.components: configure\_ngram(model, recipe, sources\["ngram"\]) for layer in range(config\["num\_hidden\_layers"\]): p = f"text/layers/{layer}/" if config\["layer\_types"\]\[layer\] == "full\_attention": \_group\_attention(recipe, p, formats) else: n = p + "gdn/" qkv = \[n + "query", n + "key", n + "value"\] recipe.group(qkv + \[n + "z"\] if formats\[n + "z"\] == formats\[n + "query"\] else qkv) recipe.group(\[n + "a\_projection", n + "b\_projection"\]) \_group\_moe(recipe, p + "moe/", config\["num\_experts"\], formats) if layer in config\["ple\_layers"\]: \_group\_same\_format(recipe, \[p + "ple/key", p + "ple/value"\], formats) if "mtp" in model.components: \_group\_attention(recipe, "mtp/layer/", formats) \_group\_moe(recipe, "mtp/layer/moe/", model.components\["mtp"\]\["config"\]\["num\_experts"\], formats) def

</details>

<details><summary>Tool result · context_read · call_54e34fcbe82849e7b69a69d8</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/qwen4_exp_gguf.py · section 4/4

qwen3\_8\_flash\_next\_gsq\_q2(model, recipe, sources): """
    """Preserve GSQ Q2\_0 routed grids in native planes. Preserve shared Q2\_0/Q8\_0/BF16 operands; other shared block formats decode to BF16. Other projections, MTP and the table retain their GGUF recipe contracts."""
    """ if "text" in model.components: gguf = sources\["gguf"\] if not isinstance(gguf, GGUFFile): raise ValueError("--source gguf must name the model's first .gguf shard") # Check the trained grids before hashing a 28.8 GB companion or reading other weights. for layer in model.source\_layers or range(LAYERS): for role in ("gate", "up", "down"): tensor = f"blk.{layer}.ffn\_{role}\_exps.weight" if gguf.info(tensor).type\_id != 42: raise ValueError(f"{tensor}: native GSQ Q2 requires stored Q2\_0 experts") qwen3\_8\_flash\_next\_gguf(model, recipe, sources) if "text" not in model.components: return gguf = sources\["gguf"\] for layer, source\_layer in enumerate(model.source\_layers or range(LAYERS)): g, m = f"blk.{source\_layer}.", f"text/layers/{layer}/moe/" for expert in range(model.config\["num\_experts"\]): for role, shape in (("gate", (EXPERT\_WIDTH, HIDDEN)), ("up", (EXPERT\_WIDTH, HIDDEN)), ("down", (HIDDEN, EXPERT\_WIDTH))): source = q2\_native\_source(gguf, g + f"ffn\_{role}\_exps.weight", shape, rows(expert \* shape\[0\])) recipe.assign(m + f"experts/{expert}/{role}", format="q2\_g64\_fp16", method=import\_encoded, source=source, activation\_policy="AllowA8") for role, shape in (("gate", (SHARED\_WIDTH, HIDDEN)), ("up", (SHARED\_WIDTH, HIDDEN)), ("down", (HIDDEN, SHARED\_WIDTH))): tensor = g + f"ffn\_{role}\_shexp.weight" if gguf.info(tensor).type\_id == TYPE\_BF16: # The base recipe already supplies the exact BF16 rows and A16 permission. continue if gguf.info(tensor).type\_id == 42: source = q2\_native\_source(gguf, tensor, shape, rows()) recipe.assign(m + f"shared/{role}", format="q2\_g64\_fp16", method=import\_encoded, source=source, activation\_policy="AllowA8") continue if gguf.info(tensor).type\_id == 8: source = q8\_native\_source(gguf, tensor, shape, rows()) recipe.assign(m + f"shared/{role}", format="q8\_g32\_fp16", method=import\_encoded, source=source, activation\_policy="AllowA8") else: source, \_ = bf16\_matrix\_source(gguf, tensor, shape) recipe.assign(m + f"shared/{role}", format="bf16", method=cast\_direct, source=source, activation\_policy="A16Only") print(f"{tensor}: {gguf.info(tensor).type\_name} shared rows decoded to BF16", flush=True) def with\_mtp\_expert\_count(config: dict, path) -> dict: """
    """The HF config with the MTP block's expert count read from the MTP GGUF at \`path\`: an expert-pruned model keeps fewer experts per layer than the MTP block it drafts with."""
    """ from copy import deepcopy with GGUFFile(path) as gguf: count = gguf.kv.get("qwen4exp.expert\_count") if type(count) is not int or count <= 0: raise ValueError(f"{path}: the MTP GGUF names no expert count") out = deepcopy(config) text = out.get("text\_config", out) if not isinstance(text.get("mtp"), dict): raise ValueError("text.mtp must describe the MTP block") text\["mtp"\]\["num\_experts"\] = count return out def with\_gguf\_expert\_count(config: dict, path) -> dict: """
    """The HF config with the expert count of the GGUF at \`path\`: an expert-pruned release (the Coder build keeps 256 of 512 per layer) is that model's config with fewer experts."""
    """ from copy import deepcopy with GGUFFile(path) as gguf: count = gguf.kv.get("qwen4exp.expert\_count") text = config.get("text\_config", config) if type(count) is not int or count == text.get("num\_experts"): return config if not 10 <= count <= text.get("num\_experts", 0): raise ValueError(f"{path}: {count} experts per layer cannot be a pruning of this model") out = deepcopy(config) out.get("text\_config", out)\["num\_experts"\] = count return out def ngram\_source(gguf: GGUFFile, rows\_count: int) -> LogicalSource: info = gguf.info(NGRAM\_TENSOR) if info.shape != (rows\_count, NGRAM\_WIDTH) or info.type\_id not in GGUF\_FORMATS\_BY\_TYPE: raise ValueError(f"{gguf.path}: {NGRAM\_TENSOR} is {info.type\_name} {info.shape}") return block\_source(gguf, NGRAM\_TENSOR, (rows\_count, NGRAM\_WIDTH), rows()) def table\_digest(gguf: GGUFFile) -> str: """
    """SHA-256 of the n-gram table's bytes, which the artifact stores unchanged, row for row."""
    """ size = gguf.info(NGRAM\_TENSOR).nbytes digest = hashlib.sha256() step = 1 << 28 for begin in range(0, size, step): digest.update(gguf.tensor\_bytes(NGRAM\_TENSOR, begin, min(begin + step, size))) return digest.hexdigest() RECIPES = { "qwen3\_8\_flash\_next\_gguf": qwen3\_8\_flash\_next\_gguf, "qwen3\_8\_flash\_next\_gsq\_q2": qwen3\_8\_flash\_next\_gsq\_q2, } \_\_all\_\_ = \[ "EXPECTED\_HEADER", "MTP\_HEADER", "NGRAM\_TENSOR", "RECIPES", "column\_source", "expected\_mtp\_tensors", "expected\_tensors", "mtp\_sources", "validate\_mtp", "with\_gguf\_expert\_count", "with\_mtp\_expert\_count", "ngram\_source", "qwen3\_8\_flash\_next\_gguf", "qwen3\_8\_flash\_next\_gsq\_q2", "table\_digest", "text\_sources", "validate", \]\
\
1\
\
2\
\
3\
\
4\
\
5\
\
6\
\
7\
\
8\
\
9\
\
10\
\
11\
\
12\
\
13\
\
14\
\
15\
\
16\
\
17\
\
18\
\
19\
\
20\
\
21\
\
22\
\
23\
\
24\
\
25\
\
26\
\
27\
\
28\
\
29\
\
30\
\
31\
\
32\
\
33\
\
34\
\
35\
\
36\
\
37\
\
38\
\
39\
\
40\
\
41\
\
42\
\
43\
\
44\
\
45\
\
46\
\
47\
\
48\
\
49\
\
50\
\
51\
\
52\
\
53\
\
54\
\
55\
\
56\
\
57\
\
58\
\
59\
\
60\
\
61\
\
62\
\
63\
\
64\
\
65\
\
66\
\
67\
\
68\
\
69\
\
70\
\
71\
\
72\
\
73\
\
74\
\
75\
\
76\
\
77\
\
78\
\
79\
\
80\
\
81\
\
82\
\
83\
\
84\
\
85\
\
86\
\
87\
\
88\
\
89\
\
90\
\
91\
\
92\
\
93\
\
94\
\
95\
\
96\
\
97\
\
98\
\
99\
\
100\
\
101\
\
102\
\
103\
\
104\
\
105\
\
106\
\
107\
\
108\
\
109\
\
110\
\
111\
\
112\
\
113\
\
114\
\
115\
\
116\
\
117\
\
118\
\
119\
\
120\
\
121\
\
122\
\
123\
\
124\
\
125\
\
126\
\
127\
\
128\
\
129\
\
130\
\
131\
\
132\
\
133\
\
134\
\
135\
\
136\
\
137\
\
138\
\
139\
\
140\
\
822\
\
823\
\
824\
\
825\
\
826\
\
827\
\
828\
\
829\
\
830\
\
831\
\
832\
\
833\
\
834\
\
835\
\
836\
\
837\
\
838\
\
839\
\
840\
\
841\
\
842\
\
843\
\
844\
\
845\
\
846\
\
847\
\
848\
\
849\
\
850\
\
851\
\
852\
\
853\
\
854\
\
855\
\
856\
\
857\
\
858\
\
859\
\
860\
\
861\
\
862\
\
863\
\
864\
\
865\
\
866\
\
867\
\
868\
\
869\
\
870\
\
871\
\
872\
\
873\
\
874\
\
875\
\
876\
\
877\
\
878\
\
879\
\
880\
\
881\
\
882\
\
883\
\
884\
\
885\
\
886\
\
887\
\
888\
\
889\
\
890\
\
891\
\
892\
\
893\
\
894\
\
895\
\
You can’t perform that action at this time.

</details>

## Assistant · #88

<details><summary>Reasoning · 1,786 characters</summary>

Aha important: `configure_ngram_gguf` hardcodes `gguf_iq4_nl`: if table GGUF source format != gguf_iq4_nl raises ValueError. Therefore stock `qwen3_8_flash_next_gguf` recipe currently refuses a Q8_0 GGUF ngram table. But runtime accepts alternate table? The converter stock rejects Q8_0. To make Q8PLE `.ninfer`, need custom recipe/source or patch converter to allow `gguf_q8_0` for ngram. The docs said runtime accepts any table in any row format, but converter recipe currently hardcodes IQ4_NL. Need update answer: not just "no one has done it"; stock GGUF recipe will reject Q8 table. However you can:
- use a tiny custom recipe overriding `configure_ngram_gguf` to accept `gguf_q8_0` and set descriptor format. Or
- make HF-source FP8 table (supported but not published) rather than Q8_0, but that is 51.8GB and not exact Shockem Q8_0.
- Or extract Q8 table and use a custom logical source / recipe; runtime likely can read it, but need verify.
Need check `qwen4_exp_ngram.configure_ngram` (not GGUF) maybe also hardcodes IQ4? It might support FP8. We have section 2 says HF BF16 rows become FP8. Need maybe not read source. But stock GGUF recipe explicit. Need update previous answer: Q8PLE conversion is still feasible but requires a tiny converter tweak/override, not simply pass Q8 GGUF through stock recipe. That's important.

Need maybe inspect runtime "another table same shape" details maybe row formats? Could read source code for ngram component? Search? Maybe runtime `qwen4_exp` ngram loader supports formats? We can scrape docs section "another table of same shape" maybe. Use qwen3-8-flash-next.md section maybe 10? Let's read section 5? We don't know. Maybe section 5 is "Count rows corpus addresses: UTF-8 files..." not. Search? Could read section 5, 10, 11 maybe.


</details>

<details><summary>Tool request · context_read · call_dbbe882693ff448880bf55ce</summary>

```json
{
  "kind": "resource",
  "id": "c3be2147-fd29-4399-b30f-5ff84b5c86e3",
  "section": 5
}
```

</details>

<details><summary>Tool request · context_read · call_df440dd93d804511b5adfc32</summary>

```json
{
  "kind": "resource",
  "id": "c3be2147-fd29-4399-b30f-5ff84b5c86e3",
  "section": 10
}
```

</details>

<details><summary>Tool request · context_read · call_f09ec3d7df6f4b45bd334449</summary>

```json
{
  "kind": "resource",
  "id": "c3be2147-fd29-4399-b30f-5ff84b5c86e3",
  "section": 11
}
```

</details>


<details><summary>Tool result · context_read · call_dbbe882693ff448880bf55ce</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md · section 5/12
Subsection: Count the rows a corpus addresses: UTF-8 files, or .jsonl with a "text" or chat "messages" per line.
Tags: code, table

Once a prompt step (a chunk, or a span) has read its own rows, it hints the rows of the Engine's next step, which are then read while the GPU runs this one. MTP hints its anchor and both highest-logit candidates at each draft step. An auxiliary CUDA stream copies each step's two tokens and hashes private contexts while later draft steps run. Verification also hints both candidates after each actual verified prefix; predictions do not change the next column's context. Linux buffered/mapped readers issue `POSIX_FADV_WILLNEED`; Windows mapped readers use `PrefetchVirtualMemory`. These are advisory reads, with duplicate rows and shared pages coalesced. A worker thread issues a batch of more than 256 page ranges and drops a batch that arrives while it still issues the previous one. Direct I/O and Windows buffered I/O start one bounded speculative batch in separate staging; busy workers skip extra hints. Only complete successful batches can supply demand reads, and hints alone admit no rows into the persistent cache.

Buffered/direct row misses use a bounded OS queue: io\_uring on Linux and overlapped reads with IOCP on Windows. One worker drives the queue while device execution continues; direct reads use at most `--ngram-io-depth` aligned bounce buffers. A failed batch drains its outstanding reads before returning and admits no rows to the cache. If Linux disables io\_uring, the reader uses positioned-read workers; a buffered batch of at most 1,024 rows then first reads, on the engine thread, the rows the page cache holds (`RWF_NOWAIT`, or `mincore` over a mapping of the file where the file system refuses that flag, as overlayfs does), and wakes only as many workers as rows remain. On an RTX 4090 host in a container without io\_uring, the 64 rows of a decode verification took 3.6 ms per round across 64 woken workers; read on the engine thread, the GPU's idle time before a verification fell from 2.4 ms to 0.8 ms a round. Bulk RAM/hot-set loading and mapped reads retain their existing paths. The Windows reader paths have not been run.

On a serving workload with one RTX 3090, the table's pages evicted before the first request, the PLE layer waited 0 to 4 microseconds per request for its rows with buffered or direct reads. The row cache stays off by default: with a 4 GiB cache the first requests took 10-11% longer, and repeated requests that hit every row generated no faster.

`--ngram-residency ram` reads the whole table into RAM at startup (2 MiB pages where Linux offers them), and `ram-hot` reads only the rows a hot-row profile ranks most used, as many as `--ngram-ram-mib` holds beside their index (a bit per table row, 40 MiB), and reads the rest from the file as `disk` does. A row depends on its token and the two before it and nothing else, so a profile is counted from text alone, without running the model:

The selected table artifact may carry a profile in `ngram.resources.hot_profile`. `ram-hot` uses it when `--ngram-hot-profile` is absent; an explicit file overrides it. An external table supplies its own profile, and a table with no embedded profile still needs the explicit file. Other residencies leave the resource unread. Conversion embeds a checkpoint's `ngram.hot` file when present, or the file selected by `--resource ngram.hot=PATH`; the hash, row bounds and uniqueness must match. This does not change the table digest or its row bytes.

Chat JSONL documents use the artifact's Frontend, including tool definitions, tool calls and the assistant generation prompt. Set `"enable_thinking": false` or `true` per document when the corpus uses a fixed thinking mode; without it the chat template chooses its default. Invalid messages are rejected rather than omitted from the profile.

```shell
# Count the rows a corpus addresses: UTF-8 files, or .jsonl with a "text" or chat "messages" per line.
./build/apps/ninfer-ngram-profile models/flash-next-q2_0.ninfer --out models/flash-next.hot \
  corpus/*.jsonl
# The share of a held-out corpus's row reads the profile's leading rows serve, per RAM budget.
./build/apps/ninfer-ngram-profile models/flash-next-q2_0.ninfer --evaluate models/flash-next.hot \
  heldout/*.jsonl
./build/apps/ninfer-serve models/flash-next-q2_0.ninfer --ngram-table models/flash-next-ngram-table.ninfer \
  --ngram-residency ram-hot --ngram-hot-profile models/flash-next.hot --ngram-ram-mib 4096
```

`--ngram-lock` keeps the resident rows in physical memory. `/stats` reports the rows the passes read, how many RAM served, the read latency and the time the PLE layer waited ([Stats](https://github.com/iamwavecut/ninfer-all/blob/master/docs/serving.md#structured-request-log)
), and `ninfer` prints them after its answer.

The published table carries a broad hot-row profile: 26,223,284 ranked rows counted from 3,711,509 tokens sampled with equal per-group ceilings from four Common Corpus shards (prose, web, press, science) and one github-code-clean shard. On 1,103,918 held-out tokens of the same sources the leading rows serve this share of row reads per RAM budget:

| RAM budget, MiB | 256 | 512 | 1,024 | 2,048 | 4,096 and more |
| --- | --- | --- | --- | --- | --- |
| Held-out row hits | 33.8% | 38.5% | 42.9% | 48.5% | 49.6% |

Across the 239 language and domain groups with at least 2,048 held-out tokens the hit rate at 4 GiB runs from 20.5% to 95.5% (median 49.4%); Japanese books have the lowest coverage. Hits measure row reuse, not speed or quality. Edge0's FP8 table carries the same profile, since one hash addresses both tables' rows.

### Another table of the same shape

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#another-table-of-the-same-shape)

A model reads any n-gram table artifact of its hash constants, row count and row width, in any row format the runtime decodes (IQ4\_NL, FP8 with an FP16 row scale, BF16): the table its `ngram` component names, or another one. The engine checks the table's shape against the model's configuration, not its values; for another table it warns at startup with both tables' formats and digests. A table of the same shape with other values starts too and degrades the output, as a wrong table would.

Flash-Next's IQ4\_NL table and [Edge0's](https://github.com/iamwavecut/ninfer-all/blob/master/docs/edge0.md)
 FP8 table are two quantizations of one BF16 table, so each model family reads either. Over three of the HF checkpoint's 128 BF16 table shards (7.5 million rows at the start, the middle and the end of the table, the 90 zero pad rows left out), every IQ4\_NL row has a cosine of at least 0.9939 with its FP8 row and of at least 0.9945 with its BF16 row; each BF16 row against the next, unrelated one has a median cosine of 0.02 to 0.04, none of the 7.5 million pairs reaching 0.9.

On one A40 (the CUDA 12.8 `sm_86` build, November 13, 2026), the first 40 KB of `wikitext/00.txt` with INT8 KV and device experts, the GSQ-RCO Q2\_0 release scores 2.542153 with its IQ4\_NL table and 2.531971 (0.40% lower) with Edge0's 48.38 GiB FP8 table; Edge0's figures are in [its guide](https://github.com/iamwavecut/ninfer-all/blob/master/docs/edge0.md#with-flash-nexts-table)
. Q2\_0's greedy answer to the sky prompt keeps its content and changes its wording with the FP8 table; it decodes at 87.6 and 87.5 tokens per second.

### Without the n-gram table

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#without-the-n-gram-table)

The model was trained with its n-gram embedding, so the engine refuses a model whose table it cannot find. `--no-ngram-table` starts it anyway, without the PLE injection (exactly what an all-zero table gives), and warns at startup: this is a non-standard, experimental mode with no practical use. On the Q2\_0 release it nearly doubles WikiText-2 perplexity, 2.66 to 5.01 over the fourteen windows of the comparison below; short factual answers survive, but nothing measured improves.

### Streamed sparse-attention KV

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#streamed-sparse-attention-kv)

Each query of a sparse-attention layer reads 512 blocks of four positions that the indexer selects and its own incomplete block, so most of a long context's KV sits unread at each step. With `--kv-resident N` below `--max-context` (by default 32,768 positions with host or disk experts) a sequence keeps each of the 12 layers' whole KV in pinned host memory, addressed by the GPU, and the device holds a pool of N / 4 blocks per layer (at least 513 for each token of a verification window). Before each decode or verification call's attention, a kernel looks up every block the queries read, claims the missing ones, gives each a pool slot by a CLOCK sweep (a slot the call uses is never taken), copies them across the bus from the host copy and re-points the table; the blocks the call wrote are copied again when it reads them, so no slot holds bytes older than the host copy. A prompt chunk reads its layer's whole history from a device staging copy, refreshed from the host copy once per span of chunks. The attention reads the same bytes either way: a streamed and a resident sequence give the same logits. The device memory saved goes to the expert cache. The residency scheme follows Strata's `kv_stream` (MIT).

### Sequences, KV and the context cache

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#sequences-kv-and-the-context-cache)

`--kv-dtype` stores the KV cache of the 12 sparse-attention layers in any of the ten formats the Qwen3.5 family uses. A position costs 24 KiB in `bf16` (the default), 18.4 KiB in the lossless `bf16p`, 12.4 KiB in `int8`, 12.1 KiB in `fp8`, 9.6 KiB in `rk8v4`, 9.4 KiB in `k8v4`, 6.8 KiB in `nvfp4`, 6.6 KiB in `rk4v4` and `rk4v4-e8`, and 5.1 KiB in `rk2v4-e8`; the indexer's pooled keys stay FP32 beside it, another 1.5 KiB a position in every format. The sparse attention decodes each row it reads, keys in the rotated basis the cache stores them in. What the quantized formats cost in quality has not been measured on this model yet.



</details>

<details><summary>Tool result · context_read · call_df440dd93d804511b5adfc32</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md · section 10/12
Subsection: Host and disk experts over two RTX 4090s
Tags: table

*   RTX PRO 6000 Blackwell Workstation Edition: 600 W, a PCIe 4.0 x16 host link, 64 vCPUs and 1.1 TB of RAM; short answer 87 tokens for IQ3\_S.
*   RTX 5090s: boards with a 600 W default limit, PCIe 5.0 x16, 512 threads and 1 TB of RAM; short answer 81 tokens for IQ3\_S.

The ranges are two runs.

| Hardware and placement | Release | Device memory | Host memory | Decode, short answer | Decode after 4,463 tokens | Prefill |
| --- | --- | --- | --- | --- | --- | --- |
| 2× RTX 3090 Ti (PCIe, no P2P), experts on the GPUs (`--devices 0,1`) | Q2\_0 | 18.4 + 19.4 GB | 0.7 GB | 90.2 tok/s | 107 tok/s | 1,504 tok/s |
| 2× RTX 4090, experts on the GPUs (`--devices 0,1`) | Q2\_0 | 18.5 + 19.4 GiB | 0.8 GiB | 92.6-100.7 tok/s | 116-120 tok/s | 3,482-3,734 tok/s |
| 2× RTX 5090, experts on the GPUs (`--devices 0,1`) | Q2\_0 | 18.8 + 19.6 GiB | 0.9 GiB | 136.1-136.3 tok/s | 157.0-157.2 tok/s | 3,807-3,811 tok/s |
| 2× RTX 5090, experts on the GPUs (`--devices 0,1`) | IQ3\_S | 26.5 + 27.8 GiB | 1.0 GiB | 121.6-121.9 tok/s | 141.8-142.0 tok/s | 3,310-3,341 tok/s |
| RTX PRO 6000, experts on the GPU | Q2\_0 | 37.7 GiB | 0.8 GiB | 136.0-139.7 tok/s | 160.7-162.6 tok/s | 2,925-2,952 tok/s |
| RTX PRO 6000, experts on the GPU | IQ3\_S | 53.7 GiB | 1.0 GiB | 123.8-125.9 tok/s | 146.8-146.9 tok/s | 2,540-2,541 tok/s |
| RTX PRO 6000, experts in pinned host memory | Q2\_0 | 38.5 GiB | 34.0 GB pinned | 54.8-55.0 tok/s | 67.7-70.0 tok/s | 1,296-1,297 tok/s |
| RTX PRO 6000, experts in pinned host memory | IQ3\_S | 55.0 GiB | 50.3 GB pinned | 29.3 tok/s | 31.2 tok/s | 803 tok/s |
| RTX PRO 6000, experts on disk, the files in the page cache | Q2\_0 | 93.6 GiB | 1.0 GiB + page cache | 75.9 tok/s | 115.8 tok/s | 2,024 tok/s |
| RTX PRO 6000, experts on disk, the files in the page cache | IQ3\_S | 93.5 GiB | 1.2 GiB + page cache | 65.6 tok/s | 106.0 tok/s | 1,661 tok/s |
| RTX PRO 6000, experts on disk, the files' pages evicted every second | Q2\_0 | 93.5 GiB | 1.0 GiB | 35.1 tok/s | 87.1 tok/s | 1,000 tok/s |
| RTX PRO 6000, experts on disk, the files' pages evicted every second | IQ3\_S | 93.5 GiB | 1.2 GiB | 28.7 tok/s | 78.6 tok/s | 773 tok/s |

*   **Device expert cache.** On the PRO 6000 the cache takes 94 GB, and nearly every expert ends up resident.
*   **CUDA graphs** add 27% to the short-answer decode on the two RTX 5090s (107.0 tok/s eager), 23 to 26% on the PRO 6000, 11% on the two RTX 3090 Ti, and 1% and 10% on the two RTX 4090s in their two runs (91.5-91.7 tok/s eager); disk experts decode eagerly.

Every GSQ-RCO release (Q2\_0, IQ2\_XS, IQ3\_XXS, IQ3\_S and the Coder IQ1\_M) answers the generate test's prompts with disk and host experts, with and without CUDA graphs; with disk experts the process peaks at 1.05 to 1.19 GB of RAM. The published layout (models without the table, the shared table artifact) passed device, host and disk placements, batched against single decoding, a restored snapshot, an image question per release and the server's concurrency, prefix reuse and JSON Schema checks on one NVIDIA L40S.

Where a decode step goes, from an Nsight Systems trace of the generate test's graph-replayed steps (Q2\_0, every expert on that L40S): about 1,780 kernels and copies in 10.6 ms, 0.5 ms of it idle between them. A token read about 4 GB of weights when the hyper-connection projections were BF16, the largest share (1.27 GB, more than the ten routed experts of every layer, 0.66 GB); they are Q8\_0 now, 0.67 GB.

### Host and disk experts over two RTX 4090s

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#host-and-disk-experts-over-two-rtx-4090s)

Two RTX 4090s (450 W, PCIe without peer access, so the stages' transfers go through host memory) in a Vast container with an EPYC 7713 and 503 GB of RAM ran the Q2\_0 release with its IQ4\_NL table on two pipeline stages, 2026-11-07. Host and disk experts scored the first 40 KB of the WikiText stream (`scripts/pods/residency_check.sh` with `ARGS='--devices 0,1'`) at perplexity 2.540839 each, the value one GPU gives with either. Through `ninfer-serve`, one request at a time, 64 greedy tokens after a 15-token and after a 5,879-token prompt, each configuration run once:

| Experts | Options | Drafts | Expert cache | Prefill, 5,879 tokens | Decode, short / long |
| --- | --- | --- | --- | --- | --- |
| host, one GPU | `--max-context 32768` | DFlash2, 4 |     | 2,581 tok/s | 116.8 / 127.4 tok/s |
| host, two stages | `--max-context 32768` | MTP, 3 | 17.8 + 16.3 GiB | 3,806 tok/s | 204.0 / 208.5 tok/s |
| disk, two stages | `--ngram-residency disk --max-context 131072 --kv-capacity 131072 --kv-dtype rk8v4` | none | 20.4 + 19.9 GiB | 1,128 tok/s | 44.4 / 104.6 tok/s |

All three gave the same tokens. The two caches together hold nearly every expert, so after its first reads the disk run decodes from the GPUs; its short prompt came first, with the caches cold. Before this build either placement over stages stopped at the first expert copy of the second GPU.

### Host experts on one RTX 3090

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#host-experts-on-one-rtx-3090)

One RTX 3090 (24 GB, PCIe 4.0 x16) with an i9-11900KF and 125 GB RAM, driver 580.82.09 and CUDA 13.1 ran the Q2 model (GSQ-RCO Q2\_0 with the IQ4\_NL table) through `ninfer-serve` with host experts, int8 KV, an 8,192-position context and one request at a time. Three prompts (a Python LRU cache, the blue sky, the history of the Great Wall in Chinese) ran in that order twice, 256 greedy output tokens each, so a prompt's second run follows the other two. Each binary ran every configuration once; the baseline is commit `a9155e0`.

| Mode | Baseline decode, tok/s (first / second run) | October 9 build |
| --- | --- | --- |
| plain, code / prose / Chinese | 69.2/78.4, 77.9/80.6, 74.1/79.4 | 87.3/92.3, 93.7/94.3, 93.4/94.3 |
| MTP 2 drafts | 68.6/70.0, 71.9/73.4, 57.2/62.4 | 118.8/118.6, 117.3/114.8, 95.8/101.2 |
| MTP 3 drafts | 66.7/66.9, 67.2/68.3, 53.0/57.5 | 121.2/122.6, 117.7/111.1, 90.0/94.6 |
| MTP 4 drafts | 63.1/62.2, 60.5/60.9, 44.9/48.2 | 111.1/105.9, 101.9/96.2, 74.6/78.5 |
| disk experts, code / prose (first run) | 64.5, 66.8 | 68.1, 71.4 |

The baseline predates the tiered admission of staged misses and Q2\_0's transposed decoding. Run back to back, a repeated prompt decodes at 98.5 (code) and 100.4 (prose) tokens/s plain and 137.6 and 123.7 with three drafts. A cache that admitted every miss into the least recently used slot let a passing decode evict the experts other prompts keep routing to; the tiers (below 1.5, below 6, and more routes) restored second-run starts of 212-305 ms instead of 284-397 ms on a second RTX 3090 for at most 4.4% of first-run decode.

### Host experts and long contexts on one RTX 4090

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#host-experts-and-long-contexts-on-one-rtx-4090)

One RTX 4090 (450 W, PCIe 4.0 x16, driver 590.48.01, CUDA 12.8) in a Vast container with two EPYC 7742 sockets, a 61.44-CPU quota and 503 GB of RAM ran the IQ3\_S release with its IQ4\_NL table through `ninfer-serve`: host experts, one request at a time, 256 greedy output tokens, every server pinned to the GPU's NUMA node (`taskset -c 0-63,128-191`), 2026-10-20. The baseline is commit `5ed86dff9`, the build before the expert tier, the CPU share by default, MTP by default and the streamed sparse-attention KV; its default copies every miss and drafts nothing, and its MTP row adds `--spec mtp --draft-tokens 3 --expert-dma-share auto`.

At a 65,536-position context, a Python LRU cache prompt and a blue-sky prompt twice and a 31,865-token document once per server, two rounds in rotated server order (eight short answers per row):

| Build | Expert cache | Decode, short prompts | Decode after 31,865 tokens | Prefill | Bus bytes |
| --- | --- | --- | --- | --- | --- |
| baseline | 14,288 MiB | 61.4-75.5 (68.3) tok/s | 68.7 tok/s | 2,833-2,846 tok/s | 660 GB |
| baseline, MTP and CPU share | 14,080 MiB | 66.5-77.1 (71.4) tok/s | 66.5-75.0 tok/s | 2,576-2,714 tok/s | 901 GB |
| defaults | 16,059 MiB | 72.6-82.5 (77.0) tok/s | 66.0-79.0 tok/s | 2,840 tok/s | 223 GB |
| defaults, 59 CPU threads | 16,059 MiB | 70.2-77.8 (73.1) tok/s | 64.4-75.6 tok/s | 2,818-2,831 tok/s | 218 GB |
| defaults, 59 CPU threads, `--kv-resident all` | 15,264 MiB | 68.7-76.9 (71.8) tok/s | 63.2-75.2 tok/s | 2,833-2,859 tok/s | 226 GB |

The bus bytes are every expert byte the server copied to the GPU over its ten requests. The rows with 59 CPU threads (the pool's size before it took half the CPUs) ran in one sitting with the baseline; the defaults ran about an hour later on the same host. The defaults copy a quarter of the baseline MTP row's bytes and decode the short prompts 7.8% faster on its mean, with overlapping ranges; streamed and resident KV decode alike at this context. Before the prefill buffers became cache slots the 59-thread defaults' cache held 14,776 MiB and decoded the short prompts at 64.9-72.0 (68.3) tok/s.

An Nsight Systems trace of one 256-token code answer shows where the step goes instead. With the defaults (then a 59-thread CPU pool) the GPU spent 39% of the answer computing, 38% in the kernels that wait for the host's expert service (the missing experts' copies and the CPU's products) and 23% idle, and the copies took 23.8 GB; the baseline's MTP row spent 41%, 38% and 21%, with 42.5 GB of copies.

At a 458,752-position context, the same two short prompts and a 136,077-token document once, one server each: the baseline keeps every layer's KV on the device and has 4,589 MiB left for experts; the defaults keep the 12 sparse-attention layers' KV in pinned host memory (11,648 MiB) with 832 MiB of their blocks on the device, and the cache takes 14,643 MiB.

| Build | Expert cache | Decode, code / prose | Decode after 136,077 tokens | Prefill |
| --- | --- | --- | --- | --- |
| baseline | 4,589 MiB | 39.2 / 43.0 tok/s | 37.7 tok/s | 2,612 tok/s |
| defaults, 59 CPU threads, `--kv-resident all` | 4,755 MiB | 39.0 / 31.3 tok/s | 34.7 tok/s | 2,548 tok/s |
| defaults, 59 CPU threads | 14,643 MiB | 70.0 / 67.2 tok/s | 62.3 tok/s | 2,700 tok/s |
| defaults | 14,643 MiB | 70.3 / 67.3 tok/s | 67.6 tok/s | 2,708 tok/s |

The baseline's and the defaults' answers part after a few tokens to a few hundred. Since the CPU's products of K-quant, Q4\_0 and Q5\_0 blocks were made equal to the GPU's, the GPU's vector kernels round each step of those slices' products, the one change to the GPU arithmetic of this release's decode, which keeps 177 tensors in Q4\_K, Q5\_K and Q6\_K; prompt chunks run the matrix kernels, which did not change. The defaults' configurations (with and without lent buffers, 30 or 59 CPU threads, streamed or resident KV) give each other's answers token for token with equal log probabilities, and the 40 KB perplexity slice scores 1.980071 on both builds.

### The CPU share on one RTX 4090

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#the-cpu-share-on-one-rtx-4090)

The RTX 4090 host of the previous section, servers pinned to the GPU's NUMA node, the IQ3\_S release at a 65,536-position context with its other defaults, 2026-10-20. Three prompts (a Python LRU cache, the blue sky, the history of the Great Wall in Chinese) ran twice per server with 256 greedy output tokens, in two rounds whose server order rotates: 12 answers per row.

| `--expert-dma-share`, `--expert-cpu-threads` | Decode, tok/s (range, mean) | Misses on the CPU | Bus bytes per token |
| --- | --- | --- | --- |
| 1, the GPU only | 62.7-75.2, 68.4 | —   | 172.5 MB |
| `auto`, 59 threads | 64.3-78.6, 71.1 | 37.3% | 85.8 MB |
| `auto`, 16 threads | 65.4-82.8, 74.2 | 29.9% | 102.4 MB |



</details>

<details><summary>Tool result · context_read · call_f09ec3d7df6f4b45bd334449</summary>

# Scrape: https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md · section 11/12
Subsection: The expert tier's paced rounds on one RTX 4090
Tags: table

Every answer with a CPU share has the GPU-only answer's tokens and log probabilities. The bus bytes are every expert byte the server copied, prompt chunks included, over the tokens it generated. An expert the CPU computes takes no slot and crosses no bus, so the share halves the bytes; decode gains less, 4% with 59 threads and 8% with 16: the bus no longer bounds a step on this host. With 59 threads the CPU took a larger share of the misses and still decoded slower than with 16 in 11 of the 12 pairs of answers. A second sweep (the same three prompts once per server, two rounds) decoded at a mean of 72.5 tok/s with 8 threads, 74.4 with 16, 74.3 with 24, 73.4 with 32 and 71.3 with 59, every answer equal; the default pool takes half the process's CPUs (30 here). Spinning on all 61 CPUs of the container's quota, the pool had the process throttled in 208 of 211 scheduling periods while it decoded.

A second RTX 4090 rental with a 30-CPU quota (the same release and context, 2026-10-20, a later build) answered the Python and blue-sky prompts twice and a 31,865-token prompt once per server:

| `--expert-cpu-threads` | Decode, tok/s: Python, blue sky, 32K prompt, Python, blue sky | Throttled periods |
| --- | --- | --- |
| 8   | 81.8, 76.4, 70.4, 82.0, 76.4 | 4 of 291 |
| 15 (the default here) | 84.8, 79.5, 75.2, 84.5, 84.0 | 3 of 278 |
| 22  | 91.3, 82.8, 77.4, 91.4, 87.0 | 4 of 270 |
| 29  | 92.3, 85.2, 76.5, 92.6, 86.7 | 13 of 271 |

Every answer was equal. Here more threads decoded 3-8% faster at 22 than at the default, where the first host gained nothing past 16; the default stays at half the CPUs, and `--expert-cpu-threads` tunes a host.

### The expert tier's paced rounds on one RTX 4090

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#the-expert-tiers-paced-rounds-on-one-rtx-4090)

One RTX 4090 with a Ryzen 9 9950X (32 CPUs, the default 15-thread pool), the IQ3\_S release at a 65,536-position context with its other defaults, 2026-10-20: one server per `--kv-dtype` format and build, the Python LRU cache and blue-sky prompts twice and the 31,865-token prompt once, 256 greedy output tokens. Starting a round's swaps a quarter per pass instead of all after the round's pass ([the expert cache](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#the-expert-cache)
) cut the GPU's wait for the first layer's misses from 2.6 to 0.9 ms a step and decoded faster with every format:

| `--kv-dtype` | bf16 | int8 | fp8 | k8v4 | nvfp4 | rk8v4 | rk4v4 | rk4v4-e8 | rk2v4-e8 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Decode, whole round / paced, tok/s | 86.7 / 91.8 | 88.9 / 93.0 | 85.3 / 92.4 | 90.8 / 95.3 | 86.8 / 92.8 | 92.7 / 94.6 | 89.0 / 97.2 | 88.1 / 93.6 | 75.6 / 82.9 |
| Paced / whole round, geometric mean | 1.058 | 1.045 | 1.083 | 1.049 | 1.068 | 1.018 | 1.093 | 1.063 | 1.096 |

Over the 45 pairs of answers the paced build decoded 0.970-1.144 times as fast, 1.064 on the geometric mean; three pairs (two rk8v4 and one int8 blue-sky answer) were slower. Every answer had the same tokens.

On the same host `auto` had read the CPU's gate and up time as nearly zero in about two of five calls: the CPU pool's calling thread could return before the last job's thread stamped its end, and read the previous phase's stamp. With the stamp in place before the pool returns, the same 45 pairs decoded 0.985-1.128 times as fast, 1.031 on the geometric mean; per format 0.990 (rk4v4, all five pairs slower by 0.2-1.5%) to 1.068 (k8v4). Every answer had the same tokens.

### MTP

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#mtp)

The Q2\_0 release with Unsloth's `shared-Q8_0` MTP block, converted into one file with its table, on two RTX 3090s (350 W, PCIe 4.0 x16, one GPU per socket of an EPYC 7663 host with 629 GB of RAM, no peer access), 2026-10-07: greedy decoding of a 117-token answer to a 37-token coding prompt, two runs each. Every speculative output is the plain decode's, token for token.

| Placement | Drafts | Decode | Drafts accepted | Tokens a round |
| --- | --- | --- | --- | --- |
| 2× RTX 3090, experts on the GPUs | none | 92.9-93.0 tok/s |     |     |
| 2× RTX 3090, experts on the GPUs | 1   | 130.1-130.9 tok/s | 96.6% | 1.97 |
| 2× RTX 3090, experts on the GPUs | 2   | 150.3-150.5 tok/s | 91.5% | 2.83 |
| 2× RTX 3090, experts on the GPUs | 3   | 167.8-171.0 tok/s | 95.6% | 3.87 |
| 2× RTX 3090, experts on the GPUs | 4   | 171.9-173.6 tok/s | 91.0% | 4.64 |
| RTX 3090, experts in pinned host memory | none | 39.3-44.1 tok/s |     |     |
| RTX 3090, experts in pinned host memory | 3   | 47.4-49.4 tok/s | 95.6% | 3.87 |

Coding answers are what MTP drafts best; a prose answer (80 tokens on the water cycle) keeps 38.6% of three drafts, 2.16 tokens a round, and decodes at 91.6 tok/s, no faster than without drafts. With host experts a verification's four columns route to up to four times as many experts, each missing one crossing the bus, so three drafts gained about 12% here; after the October 9 host-expert work three drafts decode 90-123 tok/s against 87-94 plain (table above).

### Media conversations on one RTX 4090

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#media-conversations-on-one-rtx-4090)

One RTX 4090 (480 W) in a Vast container with an EPYC 7713 ran the Q2\_0 release with its table and `--vision` through `ninfer-serve`, 2026-11-07: host experts, one request at a time, the release's DFlash2 drafts (the default), a four-turn chat whose system text is the first 24,000 characters of the WikiText stream, a 768x512 image in the first and third user turns, greedy answers of up to 128 tokens with thinking off, each turn sending the whole history again; then a conversation with the same system text and another question, and a text conversation with characters 30,000-54,000. Three starts of each build, interleaved: before media prompts were cached (`d6a658b8a`), the first build that cached them (`0c08dfefd`), and `e38464e9b`, whose first step passes the system text's end. The client sent each request as soon as the last answer came:

| Turn | Prompt tokens | `d6a658b8a` | `0c08dfefd`: reused, prefill | `e38464e9b` |
| --- | --- | --- | --- | --- |
| 1, image | 5,831 | 1.55-1.67 s | 0, 2.82-3.17 s | 1.60-1.76 s |
| 2   | 5,985 | 1.35-1.38 s | 5,958, 0.11-0.15 s | 0.12-0.14 s |
| 3, image | 6,422-6,434 | 1.45 s | 6,006, 1.03-1.31 s | 1.03-1.15 s |
| 4   | 6,572-6,586 | 1.48-1.52 s | 6,548, 0.10-0.12 s | 0.11-0.12 s |
| Same system text | 5,441 | 1.32-1.34 s | 5,417, 0.66-0.88 s | 0.75-0.78 s |

The four turns prefilled in 5.86-6.03 s, 4.07-4.64 s and 2.87-3.14 s. In `0c08dfefd` the first turn's step ended at the system text, whose state the store keeps for the next conversation, and the image and question after it were a second pass, which with host experts copied the experts again; here one span runs both sides and keeps the state at the system text's end as it passes. The third turn's 416 new tokens still take one pass that copies the experts. `e38464e9b`'s answers are `0c08dfefd`'s; `d6a658b8a`'s differ from the first turn on, since its media prompts did not end steps at the cache's frontiers (the end of the system text and of the last user message).

The text conversation's first turn (6,383 tokens, nothing reused, the same answer in all three builds) took 1.60-1.63 s in `d6a658b8a` and 2.57-2.77 s in the later two. The earlier conversations' images had taken the host pages pinned at startup (about 1.9 GB here), so storing the next images pinned more pages while the request waited; run before the media conversation, it took 1.72-1.89 s in all three (one start each). The store pins pages only until it holds its budget (8 GiB by default) and reuses them after; `d6a658b8a` stored no media images. No request left the Engine the 50 ms of idle time after which it pins free pages back.

Another RTX 4090 (450 W) host with an EPYC 9334 ran the same chat on 2026-11-08 against `e38464e9b` and this build, which pins free pages back while it is idle, with the client pausing before each request after the first; three starts of each build, interleaved, the server on the GPU's NUMA node (`taskset`). Prompt times as the server reports them, `e38464e9b` / this build:

| Client pause | 0   | 0.1 s | 3 s |
| --- | --- | --- | --- |
| Text conversation, turn 1 | 2.10-2.21 / 2.14-2.17 s | 2.07-2.10 / 2.06-2.07 s | 2.06-2.08 / 1.49-1.50 s |
| Text conversation, turn 2 | 0.25-0.30 / 0.29-0.30 s | 0.26 / 0.24-0.25 s | 0.26-0.27 / 0.09-0.10 s |
| Same system text | 0.43-0.45 / 0.43 s | 0.42-0.44 / 0.27-0.28 s | 0.42-0.45 / 0.13 s |
| Media turns 2 and 4, client's wall time | 0.23, 0.43-0.44 / 0.23, 0.43-0.44 s | 0.23-0.24, 0.43-0.45 / 0.25-0.26, 0.46 s | 0.24, 0.45 / 0.24-0.25, 0.44-0.45 s |

With 3 s pauses the free pages were pinned back before each request, so storing images no longer pinned pages while a request waited: the text conversation's first turn took less than it takes as the first request after startup (1.61-1.62 s in both builds, two starts with the text conversation first). With 0.1 s pauses about one chunk was pinned before the next request came, and a short turn that came during a chunk waited for it, up to 30 ms. Without pauses both builds took the same times. A 64 MiB chunk pinned in 32 ms on this host (median of 24, at most 35 ms; 128 MiB took 61 ms). Both builds gave the same answers in every turn. This build decoded at 0.999-1.008 of `e38464e9b`'s rate a turn without pauses, 0.986-0.998 with 0.1 s pauses and 0.980-1.023 with 3 s pauses (geomeans 1.003, 0.992 and 0.999); it pins nothing while a request runs.

With `--spec mtp --draft-tokens 3` the media requests draft. They decoded the four answers at 135.7, 178.5, 118.6 and 163.7 tok/s, against 70.9, 88.4, 87.6 and 99.2 with `--spec none`, the same tokens (the media cache's first build, one start each, on an earlier rental of the same kind). Without drafts the three builds decode at the same rate: over the chat above and the same chat without its system text, two starts each with `--spec none`, 78.7, 79.9 and 81.6 tok/s, and `d6a658b8a` with `--spec mtp` (which did not draft media requests there) 77.3; `e38464e9b` against `0c08dfefd`, with the same answers, 0.90-1.10 a turn. With DFlash2 drafts it decoded the table's answers at 0.78-1.21 of `0c08dfefd`'s rate a turn, 1.3% and 0.4% below it overall in two sets of three starts; the second window of DFlash2 features that a span keeps for one sequence takes 50 MiB of workspace and left the expert cache 89 MiB smaller.

### Hyper-connections in Q8\_0

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#hyper-connections-in-q8_0)

The hyper-connection projections (97 down/up pairs and 96 inject matrices) are stored as ggml Q8\_0, 0.67 GB instead of 1.27 GB in BF16. On the rented RTX 3090 of the tier measurements, plain decode went from 81.3-93.6 to 84.5-97.7 tok/s and decode with three MTP drafts from 84.5-114.4 to 83.0-120.4. Up to eight tokens the kernels decode the weights to exact FP32 values; wider calls round them to BF16 for the tensor-core products, which costs prompts and batches of nine or more tokens 5-57% more for these reads. Perplexity with host experts (4,096-token windows advancing by 2,048, int8 KV):

| Corpus | BF16 | Q8\_0 | Change |
| --- | --- | --- | --- |
| `perplexity-1m` | 3.93783 | 3.93842 | +0.015% |
| `perplexity-heldout-2026-09` | 4.69573 | 4.69673 | +0.021% |

### Against llama.cpp

[](https://github.com/iamwavecut/ninfer-all/blob/master/docs/qwen3-8-flash-next.md#against-llamacpp)



</details>

## Assistant · #92

<details><summary>Reasoning · 5,012 characters</summary>

Important: runtime supports IQ4_NL, FP8 row scale, BF16, but not explicitly Q8_0? Section says "in any row format the runtime decodes (IQ4_NL, FP8 with FP16 row scale, BF16)". It does not list Q8_0. That is crucial. The docs list supported runtime table row formats: IQ4_NL, FP8, BF16. Shockem Q8_0 PLE may not be runtime-supported as ngram row format in NInfer, despite generic GGUF block support. The GGUF recipe converter also hardcodes IQ4_NL. So exact Q8_0 Shockem table under NInfer may require runtime kernel support, not just converter tweak. Basalt reads Q8_0 ngram; NInfer may not. Need verify source code maybe runtime ngram decoder supports Q8_0? Docs says runtime decodes IQ4_NL, FP8, BF16. Therefore exact Q8_0 table is not supported currently, unless "any row format" elsewhere and list omits Q8? Need read docs: "any row format the runtime decodes (IQ4_NL, FP8 with an FP16 row scale, BF16)". That is explicit set. So Q8_0 row format is not currently listed. The HF runtime may refuse table with unknown format? The model names row format; engine checks table format? It says accepts any table of hash constants and geometry, in any row format; but another section says formats runtime decodes are IQ4_NL, FP8, BF16. So likely Q8_0 unsupported. Need adjust answer: exact Shockem Q8PLE table cannot simply be plugged in as current NInfer ngram artifact unless you add Q8_0 row decoder/residency addressing. It may be easy because GGUF Q8_0 block decode exists, but the ngram row addressing/PLE kernel likely needs a case. The docs mention "IQ4_NL rows decoded on GPU" in execution. So runtime ngram PLE layer reads IQ4_NL rows decoded on GPU. Alternate FP8/BF16. Q8_0 not supported. Thus user's belief "exact one ShockM used can be derived here" may be true for table source, but converting to `.ninfer` and running requires NInfer ngram row format support for Q8_0. Need maybe answer Q3: "does ninfer-all still benefit from additive Q8PLE?" Need say: It is not a one-line recipe today; the table source exists, but NInfer's ngram table currently supports IQ4_NL, FP8, BF16. Q8_0 PLE is a Basalt feature (Basalt reads Q8_0 ngram rows). NInfer-all could add it, but it's not a published/stock supported row format. The exact bytes can be derived from Shockem/Basalt, but exact Q8_0 `.ninfer` runtime support is a code change. Maybe you can instead use FP8 table (supported but not published) which is close to NVIDIA's FP8 source from which Shockem Q8 was reblocked; but it is not byte-identical to Shockem Q8. Or BF16 table? HF-source recipe can make BF16 n-gram? Wait section 2: HF rows become FP8 E4M3. Does BF16 table runtime decode? It says any table runtime decodes IQ4_NL, FP8, BF16. But HF recipe writes FP8. BF16 table may be supported runtime but not converter? Could convert BF16 ngram from HF checkpoint? Section says HF BF16 shards become FP8; maybe BF16 table artifact can be created by custom source. A BF16 table would be 320M*160*2 = 102.4GB raw, huge. FP8 = 51.8GB. Q8_0 = 54.4GB. Basalt Q8_0 is a reblocking of FP8 source, not necessarily better than FP8? Shockem chose Q8_0 because Basalt reads Q8_0. NInfer already supports FP8 table (162 bytes/row) which is closer to NVIDIA FP8 source and 51.8GB. The docs evaluated FP8: 1.25% better held-out PPL, worse code domains, 80% more storage than IQ4. It is supported but not published. So if user wants quality over quantity in NInfer, the practical path is FP8 table, not exact Q8_0. It is not identical to Shockem but likely equivalent/better and supported. Need mention.

But user says "I believe the Q8 expert table, exact one ShockM used, can be derived here for my conversion." We need be precise: The Q8PLE table bytes are derivable. But "exact one" in NInfer may need Q8_0 row format. If they accept FP8, source NVIDIA `model-fp8-mtp-ple.safetensors`; if exact Q8, source `.basalt`. Need likely answer: exact Q8 table source is derivable, but NInfer currently does not have a stock Q8_0 ngram table recipe/runtime. So to have exact Q8PLE under `.ninfer`, you need either:
1. Add `gguf_q8_0` to `configure_ngram_gguf` and runtime PLE row decoder/addressing; or
2. Use supported FP8 table from NVIDIA checkpoint (not exact Shockem bytes but same conceptual high-fidelity table).

Need maybe verify if runtime can read BF16 table (102GB). If BF16 supported, exact quality could be BF16 table from HF source (or dequantized Q8 to BF16), but not exact Q8. Yet docs list BF16 as runtime-supported. But converter HF BF16 ngram writes FP8, not BF16? Maybe there is `--format bf16` override. But a BF16 table is large.

Need update earlier Q3: I had said alternate formats supported. Now refine: alternate formats supported are IQ4_NL, FP8, BF16; not Q8_0. So exact Shockem Q8 is not stock.

Need maybe inspect NInfer source for ngram row formats? Could search `src/models/qwen4_exp` maybe. Use web_scrape `src/models/qwen4_exp/ngram`? Need confirm. Search likely file `src/models/qwen4_exp/ngram.cu`? Let's scrape maybe directory.


</details>

<details><summary>Tool request · web_scrape · call_5f384419dd4a4a63bd453367</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/tree/master/src/models/qwen4_exp"
}
```

</details>


<details><summary>Tool result · web_scrape · call_5f384419dd4a4a63bd453367</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/tree/master/src/models/qwen4_exp#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/tree/master/src/models/qwen4_exp)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/tree/master/src/models/qwen4_exp)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/tree/master/src/models/qwen4_exp)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

FilesExpand file tree


-----------------------

master

/

qwen4\_exp
==========

/

Copy path

Directory actions
-----------------

More options
------------

More options

Directory actions
-----------------

More options
------------

More options

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/src/models/qwen4_exp)

[](https://github.com/iamwavecut/ninfer-all/commits/master/src/models/qwen4_exp)
History

master

/

qwen4\_exp
==========

/

Copy path

Top

Folders and files
-----------------

| Name |     | Name | Last commit message | Last commit date |
| --- | --- | --- | --- |
| ### parent directory<br><br>[..](https://github.com/iamwavecut/ninfer-all/tree/master/src/models) |     |     |
| [config.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/config.cpp "config.cpp") |     | [config.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/config.cpp "config.cpp") |     |     |
| [config.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/config.h "config.h") |     | [config.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/config.h "config.h") |     |     |
| [dflash2.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/dflash2.cpp "dflash2.cpp") |     | [dflash2.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/dflash2.cpp "dflash2.cpp") |     |     |
| [dflash2.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/dflash2.h "dflash2.h") |     | [dflash2.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/dflash2.h "dflash2.h") |     |     |
| [executor.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/executor.cpp "executor.cpp") |     | [executor.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/executor.cpp "executor.cpp") |     |     |
| [executor.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/executor.h "executor.h") |     | [executor.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/executor.h "executor.h") |     |     |
| [expert\_cache.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_cache.cpp "expert_cache.cpp") |     | [expert\_cache.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_cache.cpp "expert_cache.cpp") |     |     |
| [expert\_cache.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_cache.h "expert_cache.h") |     | [expert\_cache.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_cache.h "expert_cache.h") |     |     |
| [expert\_location.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_location.h "expert_location.h") |     | [expert\_location.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_location.h "expert_location.h") |     |     |
| [expert\_misses.cu](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_misses.cu "expert_misses.cu") |     | [expert\_misses.cu](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_misses.cu "expert_misses.cu") |     |     |
| [expert\_misses.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_misses.h "expert_misses.h") |     | [expert\_misses.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_misses.h "expert_misses.h") |     |     |
| [expert\_stream.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_stream.cpp "expert_stream.cpp") |     | [expert\_stream.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_stream.cpp "expert_stream.cpp") |     |     |
| [expert\_stream.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_stream.h "expert_stream.h") |     | [expert\_stream.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/expert_stream.h "expert_stream.h") |     |     |
| [hybrid\_experts.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/hybrid_experts.cpp "hybrid_experts.cpp") |     | [hybrid\_experts.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/hybrid_experts.cpp "hybrid_experts.cpp") |     |     |
| [hybrid\_experts.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/hybrid_experts.h "hybrid_experts.h") |     | [hybrid\_experts.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/hybrid_experts.h "hybrid_experts.h") |     |     |
| [loading\_sources.cmake](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/loading_sources.cmake "loading_sources.cmake") |     | [loading\_sources.cmake](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/loading_sources.cmake "loading_sources.cmake") |     |     |
| [model.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/model.cpp "model.cpp") |     | [model.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/model.cpp "model.cpp") |     |     |
| [model.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/model.h "model.h") |     | [model.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/model.h "model.h") |     |     |
| [ngram\_component.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.cpp "ngram_component.cpp") |     | [ngram\_component.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.cpp "ngram_component.cpp") |     |     |
| [ngram\_component.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.h "ngram_component.h") |     | [ngram\_component.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.h "ngram_component.h") |     |     |
| [ngram\_draft\_prefetch.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_draft_prefetch.cpp "ngram_draft_prefetch.cpp") |     | [ngram\_draft\_prefetch.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_draft_prefetch.cpp "ngram_draft_prefetch.cpp") |     |     |
| [ngram\_draft\_prefetch.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_draft_prefetch.h "ngram_draft_prefetch.h") |     | [ngram\_draft\_prefetch.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_draft_prefetch.h "ngram_draft_prefetch.h") |     |     |
| [ngram\_hash.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_hash.cpp "ngram_hash.cpp") |     | [ngram\_hash.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_hash.cpp "ngram_hash.cpp") |     |     |
| [ngram\_hash.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_hash.h "ngram_hash.h") |     | [ngram\_hash.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_hash.h "ngram_hash.h") |     |     |
| [ngram\_profile.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_profile.cpp "ngram_profile.cpp") |     | [ngram\_profile.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_profile.cpp "ngram_profile.cpp") |     |     |
| [ngram\_profile.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_profile.h "ngram_profile.h") |     | [ngram\_profile.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_profile.h "ngram_profile.h") |     |     |
| [ngram\_table.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.cpp "ngram_table.cpp") |     | [ngram\_table.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.cpp "ngram_table.cpp") |     |     |
| [ngram\_table.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.h "ngram_table.h") |     | [ngram\_table.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.h "ngram_table.h") |     |     |
| [read\_pool.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/read_pool.cpp "read_pool.cpp") |     | [read\_pool.cpp](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/read_pool.cpp "read_pool.cpp") |     |     |
| [read\_pool.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/read_pool.h "read_pool.h") |     | [read\_pool.h](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/read_pool.h "read_pool.h") |     |     |
| View all files |     |     |

You can’t perform that action at this time.

</details>

## Assistant · #94

<details><summary>Reasoning · 56 characters</summary>

Need scrape ngram_table.h/cpp to see supported formats.


</details>

<details><summary>Tool request · web_scrape · call_49b925a4c3904ae598274ee4</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.h"
}
```

</details>

<details><summary>Tool request · web_scrape · call_89457bce799c453389bbdfb6</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.cpp"
}
```

</details>


<details><summary>Tool result · web_scrape · call_49b925a4c3904ae598274ee4</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.h#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.h)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.h)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.h)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

FilesExpand file tree


-----------------------

master

/

ngram\_table.h
==============

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/src/models/qwen4_exp/ngram_table.h)

[](https://github.com/iamwavecut/ninfer-all/commits/master/src/models/qwen4_exp/ngram_table.h)
History

149 lines (127 loc) · 6.79 KB

master

/

ngram\_table.h
==============

Copy path

Top

File metadata and controls
--------------------------

*   Code

*   Blame


149 lines (127 loc) · 6.79 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/src/models/qwen4_exp/ngram_table.h)

Copy raw file

Download raw file

Open symbols panel

Edit and raw actions

1

2

3

4

5

6

7

8

9

10

11

12

13

14

15

16

17

18

19

20

21

22

23

24

25

26

27

28

29

30

31

32

33

34

35

36

37

38

39

40

41

42

43

44

45

46

47

48

49

50

51

52

53

54

55

56

57

58

59

60

61

62

63

64

65

66

67

68

69

70

71

72

73

74

75

76

77

78

79

80

81

82

83

84

85

86

87

88

89

90

91

92

93

94

95

96

97

98

99

100

101

102

103

104

105

106

107

108

109

110

111

112

113

114

115

116

117

118

119

120

121

122

123

124

125

126

127

128

129

130

131

132

133

134

135

136

137

138

139

140

141

142

143

144

145

146

147

148

149

#pragma once

// Row reads from the Qwen3.8-Flash-Next n-gram table. By default the table stays in its files and

// the rows each pass addresses are read from there, \`depth\` at once: positioned reads through the

// OS page cache (NgramIo::Buffered), aligned reads past it (Direct), or copies out of a read-only

// mapping (Mapped). Disk caches recently read rows within its RAM budget. The Ram residency reads

// the whole table into RAM at startup; RamHot reads the

// rows a hot-row profile ranks most frequent, as many as a budget holds, and reads the rest from

// the files. Every mode returns the files' bytes.

#include "core/file\_read\_queue.h"

#include "models/qwen4\_exp/read\_pool.h"

#include "ninfer/model\_enums.h"

#include "ninfer/observability/resources.h"

#include <array\>

#include <atomic\>

#include <chrono\>

#include <cstdint\>

#include <filesystem\>

#include <memory\>

#include <span\>

#include <utility\>

#include <vector\>

namespace ninfer::models::qwen4\_exp {

// One file's share of the table's bytes; a table split across an artifact's part files has one

// per part, in order, and a row may straddle two of them.

struct NgramTableSegment {

std::filesystem::path path;

std::uint64\_t file\_offset = 0; // where the segment's first table byte is in the file

std::uint64\_t bytes = 0;

};

struct NgramTableLayout {

std::vector<NgramTableSegment> segments; // the table's bytes, in order

std::uint32\_t row\_bytes = 0;

std::uint64\_t rows = 0; // addressable rows

};

struct NgramReadOptions {

NgramResidency residency = NgramResidency::Disk;

NgramIo io = NgramIo::Buffered;

// Disk: cached rows and their index, zero disables caching. RamHot: resident rows and index.

std::uint64\_t budget\_bytes = 0;

// RamHot: most frequent first; the leading rows that fit become resident.

std::vector<std::uint32\_t\> hot\_rows;

bool lock = false; // keep the resident rows in physical memory

std::uint32\_t depth = 64; // reads in flight

// A batch's rows that the files serve are read once each however often the batch addresses

// them (repeated n-grams, image positions); the others get copies.

bool dedupe = true;

};

class NgramTableReader {

public:

// Opens the files and checks that they hold every row; Ram and RamHot read their rows now.

NgramTableReader(NgramTableLayout layout, const NgramReadOptions& options);

~NgramTableReader();

NgramTableReader(const NgramTableReader&) = delete;

NgramTableReader& operator\=(const NgramTableReader&) = delete;

\[\[nodiscard\]\] const NgramTableLayout& layout() const noexcept { return layout\_; }

\[\[nodiscard\]\] const NgramReadOptions& options() const noexcept { return options\_; }

// Rows held in RAM and allocated capacity including the index; Disk fills on demand.

\[\[nodiscard\]\] std::uint64\_t resident\_rows() const noexcept {

return resident\_rows\_.load(std::memory\_order\_relaxed);

}

\[\[nodiscard\]\] std::uint64\_t resident\_bytes() const noexcept;

// Physical reader selected on this OS; a restricted Linux host may disable io\_uring.

\[\[nodiscard\]\] const char\* io\_backend() const noexcept;

// Starts copying the rows \`row\_ids\` addresses, in order, into \`out\` (row\_ids.size() \*

// row\_bytes); the resident rows are copied before it returns. Both spans stay untouched by

// the caller until wait(), which also copies a row the batch repeats (options().dedupe). One

// batch at a time. A row id past the table throws std::out\_of\_range.

void submit(std::span<const std::uint64\_t\> row\_ids, std::span<std::uint8\_t\> out);

// Waits for the batch submit() started, reading with the pool, and rethrows a failed read as

// std::runtime\_error.

void wait();

// submit() and wait().

void read\_rows(std::span<const std::uint64\_t\> row\_ids, std::span<std::uint8\_t\> out);

// Advisory lookahead: OS hints for Linux buffered/mapped and Windows mapped reads;

// up to depth direct reads (also Windows buffered reads) into

// bounded staging. Hints do not change demand counters or admit rows to the resident cache.

// A batch of more than kInlineHints page ranges is hinted by a worker thread and dropped

// while the worker still hints the previous one. Like submit/wait, called by the reader's

// owner, never concurrently with them.

void prefetch(std::span<const std::uint64\_t\> row\_ids);

static constexpr std::size\_t kInlineHints = 256;

// The counters of every finished batch; any thread may read them.

\[\[nodiscard\]\] NgramTableStats counters() const;

private:

struct File;

class Memory;

class RowCache;

class Lookahead;

class Hints;

// Reads \`bytes\` of the table at table offset \`offset\`, across segments, from the files.

void read(std::uint64\_t offset, std::uint8\_t\* destination, std::size\_t bytes) const;

// Copies \[first, first + count) table rows into \`destination\` for a residency's load.\
\
void load(std::uint64\_t first, std::uint64\_t count, std::uint8\_t\* destination) const;\
\
void load\_resident();\
\
void load\_hot();\
\
\[\[nodiscard\]\] std::int64\_t hot\_slot(std::uint64\_t row) const noexcept;\
\
NgramTableLayout layout\_;\
\
NgramReadOptions options\_;\
\
std::vector<std::unique\_ptr<File>> files\_; // one per segment\
\
std::vector<std::uint64\_t\> starts\_; // table offset of each segment\
\
std::unique\_ptr<Memory> resident\_; // Ram: the table; RamHot: the hot rows by row id\
\
std::unique\_ptr<RowCache> cache\_; // Disk: bounded rows, populated after successful reads\
\
std::atomic<std::uint64\_t\> resident\_rows\_{0};\
\
// RamHot: bit per table row, and the hot rows before each 512-row block.\
\
std::vector<std::uint64\_t\> hot\_bits\_;\
\
std::vector<std::uint32\_t\> hot\_blocks\_;\
\
std::unique\_ptr<ReadPool> pool\_;\
\
std::unique\_ptr<FileReadQueue> queue\_;\
\
std::vector<QueuedFileRead> reads\_;\
\
std::unique\_ptr<Lookahead> lookahead\_;\
\
std::unique\_ptr<Hints> hints\_;\
\
// The batch in flight: the rows the files serve (index into the batch), with dedupe the\
\
// batch's repeats of them (index, the index whose row it copies), and its start.\
\
std::vector<std::uint32\_t\> misses\_;\
\
std::vector<std::pair<std::uint32\_t, std::uint32\_t\>> copies\_;\
\
// Dedupe's (row, index) pairs, and its radix sort's scratch.\
\
std::vector<std::pair<std::uint64\_t, std::uint32\_t\>> order\_, order\_scratch\_;\
\
std::vector<std::uint32\_t\> radix\_counts\_;\
\
std::vector<std::uint32\_t\> admissions\_;\
\
std::span<const std::uint64\_t\> batch\_ids\_;\
\
std::span<std::uint8\_t\> batch\_out\_;\
\
std::chrono::steady\_clock::time\_point batch\_start\_;\
\
bool pending\_ = false;\
\
std::atomic<std::uint64\_t\> rows\_{0}, resident\_hits\_{0}, batches\_{0}, latency\_ns\_{0};\
\
std::array<std::atomic<std::uint64\_t\>, NgramTableStats::kLatencyBuckets\> histogram\_{};\
\
};\
\
} // namespace ninfer::models::qwen4\_exp\
\
You can’t perform that action at this time.

</details>

<details><summary>Tool result · web_scrape · call_89457bce799c453389bbdfb6</summary>

**Firecrawl · section 1 of 8**

Later raw sections are omitted from this copy, not from the saved chat. Context-read results are still included in full.

- Section 1 · 11,994 characters · included below
- Section 2 · 11,998 characters · omitted from this copy
- Section 3 · 11,993 characters · omitted from this copy
- Section 4 · 11,920 characters · omitted from this copy
- Section 5 · 11,949 characters · omitted from this copy
- Section 6 · 11,990 characters · omitted from this copy
- Section 7 · 11,941 characters · omitted from this copy
- Section 8 · 2,540 characters · omitted from this copy

```text
[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.cpp#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.cpp)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.cpp)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_table.cpp)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

Collapse file tree


--------------------

Files
-----

master

Search this repository(forward slash) forward slash/

/

ngram\_table.cpp
================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/src/models/qwen4_exp/ngram_table.cpp)

[](https://github.com/iamwavecut/ninfer-all/commits/master/src/models/qwen4_exp/ngram_table.cpp)
History

1065 lines (1001 loc) · 44.5 KB

/

ngram\_table.cpp
================

Copy path

Top

File metadata and controls
--------------------------

*   Code

*   Blame


1065 lines (1001 loc) · 44.5 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/src/models/qwen4_exp/ngram_table.cpp)

Copy raw file

Download raw file

Open symbols panel

Edit and raw actions

#include "models/qwen4\_exp/ngram\_table.h" #include "core/file\_read\_error.h" #include <algorithm> #include <bit> #include <cstring> #include <exception> #include <iterator> #include <limits> #include <mutex> #include <new> #include <stdexcept> #include <string> #include <utility> #ifdef \_WIN32 # ifndef \_WIN32\_WINNT # define \_WIN32\_WINNT 0x0602 # endif # ifndef NOMINMAX # define NOMINMAX # endif # include <windows.h> #else # include <cerrno> # include <fcntl.h> # include <sys/mman.h> # include <sys/stat.h> # include <sys/uio.h> # include <unistd.h> #endif namespace ninfer::models::qwen4\_exp { namespace { // Direct reads cover whole 4 KiB blocks at 4 KiB-aligned file offsets into 4 KiB-aligned memory. constexpr std::uint64\_t kAlign = 4096; // A residency's load reads the table in pieces of about this size, several at once. constexpr std::uint64\_t kLoadChunk = 4ULL << 20; // A load piece holding fewer hot rows than one per this many bytes reads them one by one. constexpr std::uint64\_t kSparseLoad = 8192; // Direct row reads up to this size use a buffer each thread keeps. constexpr std::uint64\_t kThreadBounce = 64 \* 1024; // A batch of at most this many rows reads those the page cache holds on the submitting thread // (about a microsecond each); a prompt chunk's thousands go to the threads. constexpr std::size\_t kInlineRows = 1024; // Dedupe orders a batch of at least this many rows with radix\_sort, a smaller one with std::sort. constexpr std::size\_t kRadixRows = 2048; std::string mib(std::uint64\_t bytes) { return std::to\_string((bytes + (1ULL << 19)) >> 20) + " MiB"; } // Sorts the (row, index) pairs by row and keeps the order of a row's pairs: a least-significant- // digit radix sort over the row's low \`bits\`, up to 16 bits a pass. Its time is linear in the // pairs, which takes a prompt pass's tens of thousands of rows off the submitting thread's path. void radix\_sort(std::vector<std::pair<std::uint64\_t, std::uint32\_t>>& pairs, std::vector<std::pair<std::uint64\_t, std::uint32\_t>>& scratch, std::vector<std::uint32\_t>& counts, unsigned bits) { const unsigned passes = std::max(1U, (bits + 15) / 16); const unsigned digit = (bits + passes - 1) / passes; const std::uint64\_t mask = (std::uint64\_t{1} << digit) - 1; counts.resize(std::size\_t{1} << digit); scratch.resize(pairs.size()); for (unsigned shift = 0; shift < bits; shift += digit) { std::fill(counts.begin(), counts.end(), 0U); for (const auto& pair : pairs) { ++counts\[(pair.first >> shift) & mask\]; } std::uint32\_t sum = 0; for (auto& count : counts) { sum += std::exchange(count, sum); } for (const auto& pair : pairs) { scratch\[counts\[(pair.first >> shift) & mask\]++\] = pair; } pairs.swap(scratch); } } #ifndef \_WIN32 std::string error\_text(int error) { return std::strerror(error); } #endif struct AlignedFree { void operator()(std::uint8\_t\* p) const noexcept { ::operator delete(p, std::align\_val\_t{kAlign}); } }; using AlignedBytes = std::unique\_ptr<std::uint8\_t, AlignedFree>; AlignedBytes aligned\_bytes(std::uint64\_t bytes) { return AlignedBytes( static\_cast<std::uint8\_t\*>(::operator new(bytes, std::align\_val\_t{kAlign}))); } // The bounce buffer of a direct row read on this thread. std::uint8\_t\* thread\_bounce() { thread\_local AlignedBytes buffer = aligned\_bytes(kThreadBounce); return buffer.get(); } std::size\_t latency\_bucket(std::uint64\_t nanoseconds) { const std::uint64\_t micro = nanoseconds / 1000; return std::min<std::size\_t>(std::bit\_width(micro), NgramTableStats::kLatencyBuckets - 1); } } // namespace struct NgramTableReader::File { NgramIo io; std::filesystem::path path; std::uint64\_t bytes = 0; // the file's size const std::uint8\_t\* view = nullptr; // Mapped: the whole file // Linux Buffered: a mapping of the whole file, never read, for mincore() to tell which of its // pages the page cache holds where RWF\_NOWAIT is refused (overlayfs). const std::uint8\_t\* probe = nullptr; std::uint64\_t page = 4096; mutable std::atomic<bool> nowait\_unsupported{false}; #ifdef \_WIN32 HANDLE handle = INVALID\_HANDLE\_VALUE; HANDLE mapping = nullptr; #else int descriptor = -1; #endif File(std::filesystem::path file, NgramIo mode) : io(mode), path(std::move(file)) { #ifdef \_WIN32 // Random access: the cache manager does not read ahead past each row. DWORD flags = FILE\_ATTRIBUTE\_NORMAL | FILE\_FLAG\_RANDOM\_ACCESS; if (io == NgramIo::Direct) { flags |= FILE\_FLAG\_NO\_BUFFERING; } handle = CreateFileW(path.c\_str(), GENERIC\_READ, FILE\_SHARE\_READ, nullptr, OPEN\_EXISTING, flags, nullptr); if (handle == INVALID\_HANDLE\_VALUE) { fail("cannot open"); } LARGE\_INTEGER size{}; if (!GetFileSizeEx(handle, &size)) { fail("cannot size"); } bytes = static\_cast<std::uint64\_t>(size.QuadPart); if (io == NgramIo::Mapped) { mapping = CreateFileMappingW(handle, nullptr, PAGE\_READONLY, 0, 0, nullptr); if (mapping == nullptr) { fail("cannot map"); } view = static\_cast<const std::uint8\_t\*>(MapViewOfFile(mapping, FILE\_MAP\_READ, 0, 0, 0)); if (view == nullptr) { fail("cannot map"); } } #else int flags = O\_RDONLY | O\_CLOEXEC; if (io == NgramIo::Direct) { flags |= O\_DIRECT; } descriptor = ::open(path.c\_str(), flags); if (descriptor < 0) { const int error = errno; if (io == NgramIo::Direct && error == EINVAL) { throw std::runtime\_error("n-gram table: " + path.string() + " is on a file system without direct I/O; use " "--ngram-io buffered or mapped"); } throw std::runtime\_error("n-gram table: cannot open " + path.string() + ": " + error\_text(error)); } struct stat status{}; if (::fstat(descriptor, &status) != 0) { fail("cannot size"); } bytes = static\_cast<std::uint64\_t>(status.st\_size); # if defined(POSIX\_FADV\_RANDOM) if (io != NgramIo::Direct) { (void)::posix\_fadvise(descriptor, 0, 0, POSIX\_FADV\_RANDOM); } # endif if (io == NgramIo::Mapped && bytes > 0) { void\* p = ::mmap(nullptr, bytes, PROT\_READ, MAP\_SHARED, descriptor, 0); if (p == MAP\_FAILED) { fail("cannot map"); } (void)::madvise(p, bytes, MADV\_RANDOM); view = static\_cast<const std::uint8\_t\*>(p); } # ifdef \_\_linux\_\_ if (io == NgramIo::Buffered && bytes > 0) { void\* p = ::mmap(nullptr, bytes, PROT\_READ, MAP\_SHARED, descriptor, 0); if (p != MAP\_FAILED) { (void)::madvise(p, bytes, MADV\_RANDOM); probe = static\_cast<const std::uint8\_t\*>(p); } page = static\_cast<std::uint64\_t>(::sysconf(\_SC\_PAGESIZE)); } # endif #endif } ~File() { #ifdef \_WIN32 if (view != nullptr) UnmapViewOfFile(view); if (mapping != nullptr) CloseHandle(mapping); if (handle != INVALID\_HANDLE\_VALUE) CloseHandle(handle); #else if (view != nullptr) ::munmap(const\_cast<std::uint8\_t\*>(view), bytes); if (probe != nullptr) ::munmap(const\_cast<std::uint8\_t\*>(probe), bytes); if (descriptor >= 0) ::close(descriptor); #endif } File(const File&) = delete; File& operator=(const File&) = delete; \[\[noreturn\]\] void fail(const char\* what) const { #ifdef \_WIN32 throw std::runtime\_error("n-gram table: " + std::string(what) + " " + path.string() + " (error " + std::to\_string(GetLastError()) + ")"); #else throw std::runtime\_error("n-gram table: " + std::string(what) + " " + path.string() + ": " + error\_text(errno)); #endif } // A row read that failed while the Engine ran; the reader caches no row of a failed batch. \[\[noreturn\]\] void fail\_read() const { #ifdef \_WIN32 throw FileReadError("n-gram table: cannot read " + path.string() + " (error " + std::to\_string(GetLastError()) + ")"); #else throw FileReadError("n-gram table: cannot read " + path.string() + ": " + error\_text(errno)); #endif } // One positioned read of up to \`bytes\` at \`offset\`; 0 at the end of the file. std::size\_t read\_some(std::uint64\_t offset, std::uint8\_t\* destination, std::size\_t bytes) const { bytes = std::min<std::size\_t>(bytes, 1U << 30U); for (;;) { #ifdef \_WIN32 OVERLAPPED position{}; position.Offset = static\_cast<DWORD>(offset & 0xffffffffULL); position.OffsetHigh = static\_cast<DWORD>(offset >> 32U); DWORD done = 0; if (!ReadFile(handle, destination, static\_cast<DWORD>(bytes), &done, &position)) { if (GetLastError() == ERROR\_HANDLE\_EOF) { return 0; } fail\_read(); } return done; #else const ssize\_t done = ::pread(descriptor, destination, bytes, static\_cast<off\_t>(offset)); if (done < 0 && errno == EINTR) { continue; } if (done < 0) { fail\_read(); } return static\_cast<std::size\_t>(done); #endif } } // Reads exactly \`bytes\` at \`offset\`, through the page cache or out of the mapping. void read\_cached(std::uint64\_t offset, std::uint8\_t\* destination, std::size\_t bytes) const { if (view != nullptr) { std::memcpy(destination, view + offset, bytes); return; } while (bytes > 0) { const std::size\_t done = read\_some(offset, destination, bytes); if (done == 0) { throw FileReadError("n-gram table: " + path.string() + " ends early"); } destination += done; offset += done; bytes -= done; } } // Reads exactly \`bytes\` at \`offset\` past the page cache: the 4 KiB blocks around them into an // aligned buffer, then the bytes out of it. void read\_direct(std::uint64\_t offset, std::uint8\_t\* destination, std::size\_t bytes) const { const std::uint64\_t begin = offset & ~(kAlign - 1); const std::uint64\_t end = (offset + bytes + kAlign - 1) & ~(kAlign - 1); AlignedBytes owned; std::uint8\_t\* bounce = nullptr; if (end - begin <= kThreadBounce) { bounce = thread\_bounce(); } else { owned = aligned\_bytes(end - begin); bounce = owned.get(); } const std::uint64\_t need = offset + bytes - begin; std::uint64\_t have = 0; while (have < need) { const std::size\_t done = read\_some(begin + have, bounce + have, end - begin - have); if (done == 0) { throw FileReadError("n-gram table: " + path.string() + " ends early"); } have += done; } std::memcpy(destination, bounce + (offset - begin), bytes); } void read(std::uint64\_t offset, std::uint8\_t\* destination, std::size\_t bytes) const { if (io == NgramIo::Direct) { read\_direct(offset, destination, bytes); } else { read\_cached(offset, destination, bytes); } } // Reads exactly \`bytes\` at \`offset\` when the page cache holds them all, without waiting for // the device; false otherwise. RWF\_NOWAIT asks the kernel; where the file system refuses it, // mincore() over \`probe\` tells, which reports the page cache for a file this process owns or // may write and no page resident otherwise. bool read\_resident(std::uint64\_t
```

</details>

## Assistant · #97

<details><summary>Reasoning · 174 characters</summary>

The table reader just reads raw bytes by row_bytes; row format decoder elsewhere. Need ngram_component.cpp likely validates format. Let's scrape maybe section around format.


</details>

<details><summary>Tool request · web_scrape · call_e5cd6a38edd3483082f7d5b4</summary>

```json
{
  "url": "https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.cpp"
}
```

</details>


<details><summary>Tool result · web_scrape · call_e5cd6a38edd3483082f7d5b4</summary>

[Skip to content](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.cpp#start-of-content)


You signed in with another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.cpp)
 to refresh your session. You signed out in another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.cpp)
 to refresh your session. You switched accounts on another tab or window. [Reload](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.cpp)
 to refresh your session. Dismiss alert



[](https://github.com/iamwavecut/ninfer-all)

FilesExpand file tree


-----------------------

master

/

ngram\_component.cpp
====================

Copy path

Blame

More file actions

Blame

More file actions

Latest commit
-------------

History
-------

[History](https://github.com/iamwavecut/ninfer-all/commits/master/src/models/qwen4_exp/ngram_component.cpp)

[](https://github.com/iamwavecut/ninfer-all/commits/master/src/models/qwen4_exp/ngram_component.cpp)
History

188 lines (173 loc) · 9.27 KB

master

/

ngram\_component.cpp
====================

Copy path

Top

File metadata and controls
--------------------------

*   Code

*   Blame


188 lines (173 loc) · 9.27 KB

[Raw](https://github.com/iamwavecut/ninfer-all/raw/refs/heads/master/src/models/qwen4_exp/ngram_component.cpp)

Copy raw file

Download raw file

Open symbols panel

Edit and raw actions

1

2

3

4

5

6

7

8

9

10

11

12

13

14

15

16

17

18

19

20

21

22

23

24

25

26

27

28

29

30

31

32

33

34

35

36

37

38

39

40

41

42

43

44

45

46

47

48

49

50

51

52

53

54

55

56

57

58

59

60

61

62

63

64

65

66

67

68

69

70

71

72

73

74

75

76

77

78

79

80

81

82

83

84

85

86

87

88

89

90

91

92

93

94

95

96

97

98

99

100

101

102

103

104

105

106

107

108

109

110

111

112

113

114

115

116

117

118

119

120

121

122

123

124

125

126

127

128

129

130

131

132

133

134

135

136

137

138

139

140

141

142

143

144

145

146

147

148

149

150

151

152

153

154

155

156

157

158

159

160

161

162

163

164

165

166

167

168

169

170

171

172

173

174

175

176

177

178

179

180

181

182

183

184

185

186

187

188

#include "models/qwen4\_exp/ngram\_component.h"

#include "models/qwen4\_exp/ngram\_hash.h"

#include <stdexcept\>

#include <string\>

#include <vector\>

namespace ninfer::models::qwen4\_exp {

namespace {

using artifact::ArtifactError;

using artifact::Json;

constexpr const char\* kTableBinding = "ngram/table";

std::vector<std::uint64\_t\> u64\_array(const Json& config, const char\* name) {

const auto& value = config.at(name);

if (!value.is\_array()) { throw ArtifactError(std::string(name) + " must be an array"); }

std::vector<std::uint64\_t\> out;

for (const auto& item : value) { out.push\_back(artifact::require\_u64(item, name)); }

return out;

}

void require\_equal(const std::filesystem::path& artifact, std::uint64\_t actual,

std::uint64\_t expected, const char\* name) {

if (actual != expected) {

throw ArtifactError(artifact.string() + ": the n-gram table's " + name + " is " +

std::to\_string(actual) + "; the model needs " +

std::to\_string(expected));

}

}

ops::NgramRowFormat row\_format(const std::filesystem::path& artifact, const std::string& format) {

if (format == "gguf\_iq4\_nl") { return ops::NgramRowFormat::Iq4Nl; }

if (format == "bf16") { return ops::NgramRowFormat::Bf16; }

if (format == "fp8\_e4m3fn\_row\_fp16") { return ops::NgramRowFormat::Fp8E4M3RowScale; }

throw ArtifactError(artifact.string() + ": the n-gram table is stored as " + format +

"; the runtime decodes gguf\_iq4\_nl, bf16 and fp8\_e4m3fn\_row\_fp16 rows");

}

// What a \`ngram\` component says about its table, checked against the model's text config.

struct Descriptor {

std::string format;

std::string digest; // SHA-256 of the table's bytes, lowercase hex

std::uint64\_t rows = 0;

std::uint64\_t width = 0;

};

Descriptor descriptor(const artifact::Reader& reader, const std::filesystem::path& artifact,

const TextConfig& config) {

const auto& directory = reader.directory();

if (!directory.components.contains("ngram")) {

throw ArtifactError(artifact.string() +

" describes no n-gram table (its \`ngram\` component); convert it "

"with its table source, --source ngram=PATH");

}

const Json& c = directory.component("ngram").config;

artifact::require\_members(c,

{"architectures", "model\_type", "vocab\_size", "eos\_token\_id",

"ngram\_size", "heads\_per\_ngram", "row\_width", "rows", "multipliers",

"head\_vocab", "head\_offset", "format", "table\_sha256"},

{}, "n-gram table config");

if (!c.at("architectures").is\_array() || c.at("architectures").size() != 1 ||

c.at("architectures")\[0\] != "Qwen4ExpNgramTable") {

throw ArtifactError(artifact.string() +

": the \`ngram\` component is not a Qwen3.8-Flash-Next n-gram table");

}

const NgramHashConstants expected = derive\_ngram\_hash\_constants(config.ngram);

require\_equal(artifact, artifact::require\_u64(c.at("vocab\_size"), "vocab\_size"),

config.vocab\_size, "vocab\_size");

require\_equal(artifact, artifact::require\_u64(c.at("eos\_token\_id"), "eos\_token\_id"),

static\_cast<std::uint64\_t\>(config.eos\_token\_id), "eos\_token\_id");

require\_equal(artifact, artifact::require\_u64(c.at("ngram\_size"), "ngram\_size"),

config.ngram.ngram\_size, "ngram\_size");

require\_equal(artifact, artifact::require\_u64(c.at("heads\_per\_ngram"), "heads\_per\_ngram"),

config.ngram.heads\_per\_ngram, "heads\_per\_ngram");

Descriptor out;

out.width = config.ple\_embed\_dim / config.ngram\_heads();

out.rows = expected.rows;

require\_equal(artifact, artifact::require\_u64(c.at("row\_width"), "row\_width"), out.width,

"row\_width");

require\_equal(artifact, artifact::require\_u64(c.at("rows"), "rows"), out.rows, "rows");

if (u64\_array(c, "multipliers") != expected.multipliers ||

u64\_array(c, "head\_vocab") != expected.head\_vocab ||

u64\_array(c, "head\_offset") != expected.head\_offset) {

throw ArtifactError(artifact.string() +

": the n-gram table's hash constants differ from the model's");

}

out.format = artifact::require\_id(c.at("format"), "n-gram table format");

if (!c.at("table\_sha256").is\_string()) {

throw ArtifactError(artifact.string() + ": table\_sha256 must be a string");

}

out.digest = c.at("table\_sha256").get<std::string>();

if (out.digest.size() != 64 ||

out.digest.find\_first\_not\_of("0123456789abcdef") != std::string::npos) {

throw ArtifactError(artifact.string() +

": table\_sha256 must be 64 lowercase hexadecimal digits");

}

return out;

}

// The rows \`reader\` stores for the table \`d\` describes.

NgramTableSource stored\_rows(const artifact::Reader& reader, const std::filesystem::path& artifact,

const Descriptor& d, const TextConfig& config, bool read\_profile) {

const auto& directory = reader.directory();

const auto found = directory.bindings.find(kTableBinding);

if (found == directory.bindings.end() || found->second.parts.size() != 1) {

throw ArtifactError(artifact.string() + ": the n-gram table must be one stored object");

}

const auto& part = found->second.parts.front();

const auto& tensor = directory.tensor(part.object);

if (tensor.format != d.format) {

throw ArtifactError(artifact.string() + ": the n-gram table is stored as " +

tensor.format + " but described as " + d.format);

}

NgramTableSource out;

out.table\_format = d.format;

out.table\_digest = d.digest;

out.format = row\_format(artifact, tensor.format);

out.layout.row\_bytes = ops::ngram\_row\_bytes(out.format);

out.layout.rows = d.rows;

const std::uint64\_t table\_bytes = out.layout.rows \* out.layout.row\_bytes;

if (tensor.shape != artifact::Shape{d.rows, d.width} || part.begin != 0 ||

tensor.bytes != table\_bytes) {

throw ArtifactError(artifact.string() + ": the n-gram table has an unexpected geometry");

}

// Validate the format/layout pair as well as byte count before treating the object as rows.

(void)reader.geometry(part.object);

for (const auto& segment : reader.segments(tensor.offset, table\_bytes)) {

const auto& record = directory.files.at(segment.file\_index);

const std::filesystem::path file =

segment.file\_index == 0 ? artifact : artifact.parent\_path() / record.path.value();

out.layout.segments.push\_back({file, segment.file\_offset, segment.bytes});

}

if (read\_profile) {

const auto& resources = directory.component("ngram").resources;

const auto found\_profile = resources.find("hot\_profile");

if (found\_profile != resources.end()) {

const auto bytes = reader.read\_object(found\_profile->second);

out.hot\_profile = decode\_ngram\_profile(bytes, artifact.string() + ":ngram.hot\_profile");

check\_ngram\_profile(\*out.hot\_profile, derive\_ngram\_hash\_constants(config.ngram), artifact);

}

}

return out;

}

} // namespace

bool is\_ngram\_table\_artifact(const artifact::Reader& reader) {

const auto& directory = reader.directory();

return !directory.components.contains("text") && directory.components.contains("ngram") &&

directory.bindings.contains(kTableBinding);

}

NgramTableSource ngram\_table\_source(const artifact::Reader& reader,

const std::filesystem::path& artifact,

const TextConfig& config,

const std::filesystem::path& table, bool read\_hot\_profile) {

const Descriptor model = descriptor(reader, artifact, config);

if (table.empty()) {

if (!reader.directory().bindings.contains(kTableBinding)) {

throw ArtifactError(

artifact.string() + ": the model's n-gram table (sha256 " +

model.digest.substr(0, 16) +

"...) is stored separately; pass its table artifact with --ngram-table PATH. "

"\--no-ngram-table runs the model without it, a non-standard experimental mode "

"that badly degrades the output");

}

NgramTableSource out = stored\_rows(reader, artifact, model, config, read\_hot\_profile);

out.model\_format = model.format;

out.model\_digest = model.digest;

return out;

}

const artifact::Reader other(table);

if (!other.directory().bindings.contains(kTableBinding)) {

throw ArtifactError(table.string() + " stores no n-gram table");

}

// Any table of the model's hash constants and geometry: the one the model names, the same table

// in another row format, or another table of that shape. Its values are not compared.

const Descriptor theirs = descriptor(other, table, config);

NgramTableSource out = stored\_rows(other, table, theirs, config, read\_hot\_profile);

out.model\_format = model.format;

out.model\_digest = model.digest;

return out;

}

} // namespace ninfer::models::qwen4\_exp

You can’t perform that action at this time.

</details>

## Assistant · #99

<details><summary>Reasoning · 20,046 characters</summary>

Confirmed runtime only row_format: gguf_iq4_nl, bf16, fp8_e4m3fn_row_fp16. Q8_0 not supported. So exact Q8_0 table in `.ninfer` will throw ArtifactError unless code adds it. The table reader reads raw row bytes; row_bytes determined by ops::ngram_row_bytes(format). Need implement row decoding for Q8_0 in op. Q8_0 row has 5 blocks 34 bytes = 170. Need add format and kernel. Not huge but runtime change.

Need maybe answer "Does ninfer-all still benefit from additive Q8PLE ngram, or simply 'not included'..." Need now say: There are two senses:
- high-fidelity PLE: yes supported via FP8/BF16. NInfer has already tested FP8 and considers IQ4 release default.
- exact Shockem Q8_0: not stock. It is "not included" in the sense that NInfer does not currently decode Q8_0 n-gram rows. The exact bytes are derivable, but you need a runtime patch or use FP8/BF16 equivalent.
- Basalt specifically can read Q8_0 PLE rows; Shockem's pack was built for Basalt, not NInfer.

Need maybe mention "Q8 expert table" exact source:
- The Q8PLE tensor in Shockem's `.basalt` is not routed experts. It's `per_layer_token_embd.weight`.
- It is sourced from `Qwen3.8-FN-NVFP4-DQ6_K.basalt` (historically `Qwen3.8-FN-NVFP4.basalt`) in jesdga repo.
- The Q8_0 tensor SHA is e02bf... and size 54,400,261,120.
- NVIDIA original `model-fp8-mtp-ple.safetensors` has FP8+scale table (and MTP); Basalt reblocked to Q8_0. NInfer FP8 recipe can write `fp8_e4m3fn_row_fp16` from HF BF16 shards, but "Import of the FP8 checkpoint's own n-gram encoding is not implemented." Wait important: NInfer HF recipe can write FP8 table from HF BF16 shards, but cannot import NVIDIA FP8 checkpoint's own table encoding. It can write FP8 table from BF16 HF checkpoint. It does not support importing NVIDIA FP8 n-gram directly. So if you want supported FP8 table, you need HF BF16 checkpoint n-gram shards (maybe huge) or custom import. Shockem's Q8 table was reblocked from NVIDIA FP8; NInfer cannot import that FP8 encoding directly? It supports FP8 row format runtime, but recipe writes it from BF16 HF shards. The docs: "An FP8 text checkpoint still needs a separate supported table source: IQ4_NL GGUF or HF BF16 shards. Import of the FP8 checkpoint's own n-gram encoding is not implemented." Thus to make NInfer FP8 table, you need HF BF16 table shards, not NVIDIA FP8 safetensors. However the FP8 table from HF BF16 may not match Shockem Q8. But likely close.

Need answer "retrieve data because I believe Q8 expert table exact can be derived here for my conversion." Could say:
- Yes, exact Q8PLE table bytes can be derived from Shockem's `.basalt` or jesdga NVFP4 `.basalt` using Basalt section extraction.
- But for NInfer, exact Q8_0 row support is not currently in converter/runtime. The exact table can be extracted, but the current stock `qwen3_8_flash_next_gguf` recipe hard-fails on ngram rows not IQ4_NL, and runtime only decodes IQ4_NL/FP8/BF16. So if "exact Shockem Q8PLE" is mandatory, this is a code change (add `gguf_q8_0` row format) plus maybe GGUF source metadata.
- If "same quality intent" is enough, use FP8 table (supported, 51.8GB) or BF16 table (runtime supports, huge). FP8 is the closest supported NInfer representation; not exact Shockem but conceptually high-fidelity PLE.

Need perhaps give exact conversion path for FP8:
```
python3.11 -m tools.convert --model /HF-BF16-checkpoint --recipe qwen3_8_flash_next --components ngram --source ngram=/HF-BF16-checkpoint --device cpu --out fp8.ninfer
```
But note full HF BF16 checkpoint needed for table? It says just FP8 table from already downloaded HF checkpoint. Need HF BF16 checkpoint with n-gram shards. Could be huge but table shard? `--model` needs config and tokenizer; ngram source path to HF checkpoint. It may read BF16 shards? Need maybe only n-gram shards? But docs says source ngram=PATH to HF BF16 checkpoint. It may need index/config. The HF checkpoint likely 131 safetensors, but table is split 128 shards. Could fetch only table? Maybe.

Need maybe answer Q5 DFlash2 quality: Include exact measured "Every answer matched decoding without drafts" and distribution exact. There is no quality tradeoff vs MTP except speed/acceptance; both are target-verified. But DFlash2 has no `--adaptive-mtp` and no pipeline stages. If using single 5090, DFlash2 is beneficial. For ablated model acceptance may differ. Basalt's MTP self-distilled may have different acceptance; can't assume same speed.

Need Q6: true batched decode. Need perhaps mention exact command:
```
ninfer-serve model.ninfer --ngram-table table.ninfer --model-id qwen3.8-flash-next --expert-residency host --max-context 32768 --kv-capacity ... --kv-dtype rk8v4 --max-concurrency 4 --spec dflash2 --draft-tokens 4 --draft-min-p 0.7
```
Need not guess KV capacity. Generic serving flags: `--max-concurrency`, `--kv-capacity`, `--device-state-slots`, `--host-state-slots`, `--host-kv-mib`. But for Flash-Next, each sequence state cost. Use minimal. Mention NInfer uses `--max-concurrency`, not `--parallel`.

Need maybe mention NInfer supports true batched decode but not exactly same scheduling: Basalt has fixed slots and session affinity; NInfer uses sequences, KV pool, prefix cache, dynamic prefill interleaving. It supports up to 8. It does not have Basalt's session affinity maybe; but prefix reuse handles shared prefixes. It may not have "checkpoint per slot" same but context cache images. Need not overcompare.

Need maybe include table for batched decode evidence:
- `--max-concurrency` 1-8.
- One batched pass reads expert weights once for whole batch.
- Projections over all request columns; stateful layers request-by-request.
- Speculative rounds: up to 8 requests, one drafter pass per draft and one verification pass; 64-token verification cap; DFlash2 default 4 drafts for 8 requests = 40 tokens.
- Aggregate DFlash2 measurements on RTX A6000: 1 req 83-105 tok/s; 8 req 114-119 tok/s. Shows batching works but not linear.
- On 3090 host experts, 8 concurrent prompts finished 1.77-1.94x faster with prompt span batching.
- Your 64GB: expect lower concurrency; IQ3_S host experts pinned ~48.7GB; KV/state per sequence. Maybe max-concurrency 2 at modest context, not 8.

Need answer final in a clear structured way. Need include sources? User wants research; cite URLs and exact data. Need maybe say "I found it without doubt".

Need maybe mention "Q8PLE source data retrieved" first, then answer 5/6.

Potential issue: User says "Q8 expert table" maybe they mean "Q8PLE table" (n-gram). We should correct gently.

Need maybe answer "Does ninfer-all port in actual batched decode ... like basalt does. One of its main benefits. You already pulled my basalt serving config since you already read my PR which had it as small note of config json." We didn't actually pull config? We can acknowledge: Basalt config shape is `"models": [{ "model": ..., "gpu": "0,1", "kv": "int8" }], "engine": {"resident-experts": true}`. But not important. Need maybe compare config: NInfer equivalent:
```
ninfer-serve ... --max-concurrency 4 --expert-residency host ...
```
No config JSON in example, but NInfer has `--config` launch files. Could mention.

Need maybe mention "true parallel decode" with exact wording: NInfer's decode rounds are batched over up to 8 sequences: "a step is one batched pass whose experts read their weights once for the whole batch" and "up to eight requests run their rounds together, one MTP pass for all of them per draft and one verification pass." DFlash2 also: round of several requests verifies at most 64 tokens. So yes.

Need maybe mention caveats:
- Flash-Next DFlash2 refuses pipeline stages. If using `--devices 0,1` pipeline, use MTP. For tensor parallel two GPUs, DFlash2 tested. On single 5090, no issue.
- Windows not run for Flash-Next.
- Concurrent answers may differ from run to run due batch composition (Basalt also says concurrent requests differ between runs in some cases). So "true parallel decode" has scheduling nondeterminism; not quality issue.
- For 64GB RAM, pinned host experts nearly 50GB, so concurrency practical maybe 1-4. Use `--kv-dtype rk8v4` to reduce KV; Basalt int8 KV similar.

Need perhaps answer Q5 "quality tradeoff from MTP, mostly gain?" Need state:
- MTP and DFlash2 both verified by target; not lossy by design.
- DFlash2 is exact target sampling; every committed token model's own draw. Under greedy, should equal plain decode; under sampling, distribution exact. But output can differ from MTP answer due batch/width floating reductions and acceptance path, not due drafter quality.
- DFlash2 acceptance can be lower on some prompts/domains; if low, speed gain smaller. But no measurable model quality degradation reported.
- DFlash2 may cost extra workspace: 40MiB ring per request; one DFlash2 feature window takes 50 MiB workspace and reduced expert cache by 89 MiB in one test. Minor vs MTP's 2.8GB block and expert cache.
- For your 5090 + 64GB, DFlash2 should reduce stress vs MTP.

Need maybe include exact DFlash2 vs MTP speed table:
RTX 3090 host IQ3_S:
- default DFlash2 4 drafts: 92.3, 77.9, 58.2 tok/s
- MTP automatic: 83.5, 73.4, 49.8
- no draft: 59.0, 57.5, 45.9
- every answer matched no-draft
- 7 drafts floor 0.8 within 5% of 4, verifies 68-73% more drafts.
- Two RTX 3090 TP Q2_0: DFlash2 4 drafts better than MTP in three/four cases and answers matched no-draft where MTP did not.
Need maybe not include all but enough.

Need maybe mention "quality benchmarks" not done for DFlash2 vs MTP because verified; there are no AIME/GPQA differences. If someone measured DFlash2 vs MTP, differences are numerical acceptance path, not model quantization.

Need maybe answer "exact Q8PLE source retrieved" in detail:
Use table:
```
per_layer_token_embd.weight
[160, 320001536]
Q8_0
54,400,261,120 bytes
sha256 e02bf...
```
Source files:
- `Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE.basalt` (size 113,245,914,374, LFS SHA cd7942f2...)
- `Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt/Qwen3.8-FN-GSQ-RCO-abliterated-IQ3_S-Q8PLE.basalt` (size 113,491,281,169, LFS SHA 36fdc507...)
- `jesdga/Qwen3.8-Flash-Next-Basalt/Qwen3.8-FN-NVFP4-DQ6_K.basalt` (size 131,681,979,197, LFS SHA 177f9b70...)
- NVIDIA original: `nvidia/Qwen3.8-Flash-Next-NVFP4` revision `fc694b54`, file `model-fp8-mtp-ple.safetensors`, size 53,717,551,730, LFS SHA 3525520c...
Need maybe note file LFS SHA vs tensor SHA. The tensor SHA e02bf... from model card. The LFS SHA of file not tensor. Need not confuse. State "file LFS object SHA" separately.

Need perhaps explain extraction offset:
Basalt `.basalt` section table has `gguf` section; meta JSON has `tensors` dict; tensor offset relative to section. The tensor `per_layer_token_embd.weight` has type/shape/size/offset. Could use `tools/model_file.py`. Need perhaps include pseudo-code:
```python
# read header, sections, meta
section = sections["gguf"]
meta = json.loads(read(section))
t = meta["tensors"]["per_layer_token_embd.weight"]
open("ple_q8.gguf").write(file[section.offset + t["offset"]: ... + t["size"]])
```
But writing raw tensor into GGUF requires gguf writer. Could mention `gguf-py` or custom.

Need maybe answer "Q8 expert table can be derived here for my conversion" with caveat: If by "here" you mean NInfer conversion, the table source is available but NInfer runtime doesn't accept Q8_0 rows. So exact Shockem Q8 table cannot be loaded as-is unless you patch. The exact bytes can be extracted. The "same quality intent" can be represented by FP8.

Need maybe answer "additive Q8PLE" in terms of benefit:
- Shockem measured IQ4 vs Q8 cosine 0.997 (8% rms). Basalt model card official IQ3_S vs Q8_0 reference KLD etc.
- NInfer measured FP8 vs IQ4: Q2_0 wikitext 2.542153 vs 2.531971 (-0.40%) on first 40KB; FP8 full held-out +1.25% PPL but worse code domains.
- So benefit is real but mixed; not universal. If you value quality over quantity, use FP8 if supported; exact Q8 may require dev.

Need maybe answer conversion compute for Q8 table if patch: extraction 54.4GB copy, hash, write `.ninfer` table, total ~110-160GB I/O. Not days. But patching runtime may take days of dev/testing, not compute.

Need maybe include final recommendation:
- For immediate practical NInfer path: build Shockem-like IQ3_S `.ninfer` with IQ4 table + DFlash2, then optionally make/obtain FP8 table. Don't try exact Q8 until runtime supports `gguf_q8_0`.
- If exact Q8PLE is non-negotiable and you want no code changes: stay on Basalt. Basalt already reads Shockem Q8PLE and true batched decode.
- If you want NInfer features (DFlash2, broader GPU support, typed decisions) and can patch, add Q8_0 PLE row format or use FP8/BF16.

Need maybe answer "How far off ports" maybe final. But user now asks only 5/6 plus retrieve data. Need focus.

Need maybe mention "basalt serving config" in context: Basalt `--parallel` and config `"resident-experts": true`; NInfer equivalent uses `--expert-residency host` and `--max-concurrency`.

Need perhaps mention "true parallel decode" with Basalt's "batched parallelism" and NInfer's `--max-concurrency`: NInfer has actual batched decode, but not necessarily "parallel requests = independent engines". It is a single resident engine with batched kernels and separate KV/state. Basalt similar. Good.

Need maybe maybe there is issue: NInfer Flash-Next `--spec dflash2` no pipeline stages, but for one 5090 no issue. For tensor parallelism two GPUs, DFlash2 works. For Basalt two-card layer split/peer tiers maybe different. NInfer supports `--tensor-parallel` with DFlash2; DFlash2 refuses `--devices` pipeline stages. Need mention if planning multi-card.

Need maybe mention DFlash2 drafter memory: 339MB, ring 40MiB/request; at 8 concurrent 320MB. MTP has own Q8_0 experts and KV; more. DFlash2 also requires keeping model states after blocks 5,15,25,35,45 and projecting into rings; workspace can reduce expert cache by ~89MiB in one test. But overall less than MTP.

Need maybe answer quality of DFlash2 on ablated model: Since DFlash2 trained for Flash-Next, ablation changes distribution; acceptance rate could change. It is still lossless. If acceptance falls, speed may not be as high. But no need to find Shockem-specific drafter; standard Flash-Next DFlash2 is appropriate. Basalt MTP self-distilled may have been tuned to official pack? Shockem uses official IQ3_S pack MTP. NInfer DFlash2 trained on base Flash-Next; likely good. Need mention test on your prompts before switching production.

Need perhaps include exact commands for DFlash2 and concurrency:
```
ninfer-serve model.ninfer --ngram-table table.ninfer \
  --model-id qwen3.8-flash-next \
  --expert-residency host \
  --max-context 32768 \
  --kv-dtype rk8v4 \
  --gdn-state-fp16 \
  --max-concurrency 2 \
  --spec dflash2 --draft-tokens 4 --draft-min-p 0.7
```
Need `--gdn-state-fp16` from 27B example; for Flash-Next maybe not? The docs mention GDN state fp16? In 27B command yes; Flash-Next maybe uses `--gdn-state-fp16`? Not sure; maybe omit to avoid wrong. Use core flags only.

Need maybe mention `--expert-residency host` with 64GB: pinned experts ~48.7GB. `--expert-residency disk` uses less RAM but slower; page cache can help. Device experts not fit on 5090 (32GB) for IQ3_S (53.7GB); need two GPUs or host. Basalt's `resident-experts` maybe similar.

Need maybe cite docs with links:
- Shockem model card
- jesdga pack
- NVIDIA checkpoint
- NInfer qwen3-8-flash-next docs (alternate table, DFlash2, concurrency)
- NInfer qwen4_exp_gguf.py (hardcoded IQ4_NL)
- NInfer ngram_component.cpp (supported row formats)
- NInfer serving/Flash-Next docs batched decode.

Need now craft final answer. Desired oververbosity 9, thorough. No need mention tools. Need maybe include "I found it without doubt" and exact data. Need avoid saying "Q8 expert table" if not; clarify.

Need ensure no contradictions with earlier: previously said Q8 table feasible with custom converter; now add runtime support caveat. Need phrase: "The bytes are derivable; the exact Q8_0 row format is not currently stock in NInfer." This is the key correction.

Need maybe mention "Q8_0 PLE table in Basalt is read because Basalt's ngram path supports Q8_0 rows. NInfer's ngram component explicitly decodes only IQ4_NL, BF16, FP8 row-scale." This is solid.

Need maybe include source snippets:
`configure_ngram_gguf`:
```
if descriptor["format"] != "gguf_iq4_nl": raise ValueError(...)
```
`ngram_component.cpp`:
```
if format == "gguf_iq4_nl" ... "bf16" ... "fp8_e4m3fn_row_fp16"
throw ... runtime decodes gguf_iq4_nl, bf16 and fp8_e4m3fn_row_fp16 rows
```
This "without a doubt" supports exact answer.

Need maybe answer "Does ninfer-all port in actual batched decode ... like basalt does" with "yes, but command is `--max-concurrency`, not `--parallel`; it is not exactly same scheduler." Need maybe mention Basalt's `--parallel` and NInfer's `--max-concurrency` both 1-8.

Need maybe mention "true parallel decode" evidence:
- Each sequence own KV/recurrent state; requests admitted arrival; prompts prefill step by step; decode rounds batched; one batched pass whose experts read weights once for whole batch; vector products give columns same bits at any width up to eight. This is strong.
- DFlash2 concurrency: round several requests verifies at most 64 tokens; eight requests drafting four each fits.
- Measurements table aggregate.

Need maybe caution that concurrency answers can differ run-to-run in both engines due batching. Quality not degraded but exact reproducibility requires fixed execution config/lonely request. Basalt docs also say concurrent answers differ between runs in some cells.

Need maybe mention "batched inference through .basalt checkpoints" vs NInfer: NInfer can batch .ninfer artifacts; no .basalt. Good.

Need maybe final bottom line:
```
Exact Shockem Q8PLE table: source found, exact tensor and file. But exact Q8_0 NInfer support is not stock. Use FP8 table if supported, or patch NInfer to add gguf_q8_0. Basalt already supports it.
DFlash2: verified, no model quality tradeoff, mostly speed/resource gain on single GPU; acceptance may vary; no Shockem-specific drafter needed.
Batched decode: yes, NInfer has real batched decode up to 8, with practical concurrency bounded by your 64GB.
```

Need maybe include exact row formats and row bytes:
IQ4_NL: 90 bytes/row
FP8: 162 bytes/row
BF16: 320 bytes/row? 160*2=320
Q8_0: 170 bytes/row (not supported)
Sizes:
IQ4: 28.9GB
FP8: 51.8GB (docs)
BF16: ~102.4GB (calc)
Q8: 54.4GB
Need note Q8 is only 5% larger than FP8, but unsupported. FP8 is supported and smaller than Q8. Interesting: Q8_0 170 bytes vs FP8 162 bytes. Q8 only 4.9% larger than FP8, not 80% (FP8 is 80% larger than IQ4). Shockem Q8 is 170; FP8 162. If NInfer supports FP8, why not Q8? Runtime row decoders. If you patch Q8, size close to FP8. Could mention.

Need maybe compute Q8 table size: 320,001,536*170 = 54,400,261,120 bytes. Good. FP8 row 162: 51,840,248,832 bytes? Docs says 51.8GB. BF16 row 320: 102,400,491,520. IQ4 row 90: 28,800,138,240? But HF table file 28,905,035,512 due overhead. The row bytes vs file sizes. Could mention.

Need maybe be precise: Shockem says Q8 table 54.4GB = 50.7GiB; NInfer FP8 table "51.8 GB" (likely 48.25 GiB? 51.84GB decimal = 48.28 GiB). Edge0 FP8 table 48.38 GiB? Wait Edge0 FP8 table 48.38 GiB = 51.9GB decimal. FP8 Flash-Next table 51.8GB decimal = 48.25GiB. Q8 table 54.4GB decimal = 50.7GiB. Difference Q8 vs FP8: 2.56GB decimal (5%). Good.

Need maybe answer "Q8 expert table exact one ShockM used can be derived here" - maybe "yes, if by derived from Shockem's current pack. If by derived from NInfer sources, not quite." Need phrase.

Need maybe include "NInfer stock recipe hard-fail" exact quote. Good.

Let's draft final with sections:
- "I found the exact Q8PLE source"
- "But NInfer's current Q8PLE status"
- "5. DFlash2 quality"
- "6. Batched decode"
- "Recommended path"

Need include exact table with sources.

Need ensure not too long but detailed. Good.


</details>

## I found the exact Shockem Q8PLE source data — with one important correction

The exact Q8PLE table Shockem used **can be derived**, but for NInfer there is a practical distinction:

```text
The Q8PLE bytes exist and can be extracted.
NInfer’s current runtime does not decode Shockem’s exact Q8_0 n-gram row format.
```

So:

- **Source data:** yes, found without doubt.
- **Exact Shockem Q8_0 table as a stock `.ninfer` n-gram table:** not currently supported without a small engine/converter change.
- **Closest stock NInfer high-fidelity alternative:** FP8 row-scale table, which NInfer already supports but has not published as the default Flash-Next table.

Also, this is not a “Q8 expert” table in the routed-expert sense. The routed experts are still IQ3_S. The Q8 object is the PLE/n-gram table:

```text
per_layer_token_embd.weight
```

---

# 1. Exact Shockem Q8PLE table identity

The tensor Shockem replaced with the Q8 table is:

```text
tensor: per_layer_token_embd.weight
shape:  [160, 320001536]
type:   Q8_0
bytes:  54,400,261,120
sha256: e02bf3d78153f7c95390ffca1b4279776c90ef302a345aa56bf6b3b694d65e42
```

This is recorded in Shockem’s model cards. It is the Q8_0 reblock of NVIDIA’s FP8 PLE table, copied into the `.basalt` pack byte-for-byte.

Row math:

```text
Q8_0 row for 160 values:
5 × 32-value blocks
5 × 32 code bytes + 5 × 2-byte FP16 scales
= 170 bytes/row

320,001,536 rows × 170 bytes
= 54,400,261,120 bytes
= 54.4 GB decimal
≈ 50.7 GiB
```

---

# 2. Exact source locations

The Q8PLE table is present in these packs:

| Source | Exact file | File size | Notes |
|---|---|---:|---|
| Shockem current abliterated pack | `Shockem/Qwen3.8-Flash-Next-GSQ-RCO-abliterated-IQ3_S-Q8PLE-Basalt` → `Qwen3.8-FN-GSQ-RCO-abliterated-IQ3_S-Q8PLE.basalt` | 113,491,281,169 bytes | current served pack |
| Shockem non-abliterated Q8PLE donor | `Shockem/Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE-basalt` → `Qwen3.8-FN-GSQ-RCO-IQ3_S-Q8PLE.basalt` | 113,245,914,374 bytes | non-abliterated Q8PLE pack |
| Official Basalt NVFP4 source | `jesdga/Qwen3.8-Flash-Next-Basalt` → `Qwen3.8-FN-NVFP4-DQ6_K.basalt` | 131,681,979,197 bytes | current official default NVFP4 pack |
| Basalt NVFP4 8-bit dense variant | `jesdga/Qwen3.8-Flash-Next-Basalt` → `Qwen3.8-FN-NVFP4-DQ8.basalt` | 132,367,747,589 bytes | same class of NVFP4 pack |
| NVIDIA original FP8 checkpoint | `nvidia/Qwen3.8-Flash-Next-NVFP4`, revision `fc694b54` → `model-fp8-mtp-ple.safetensors` | 53,717,551,730 bytes | original FP8/MTP/PLE source |

Shockem’s current pack card says the Q8 n-gram table came from the official NVFP4 Basalt pack. The current Hugging Face tree no longer lists a plain `Qwen3.8-FN-NVFP4.basalt`; the official current default is:

```text
Qwen3.8-FN-NVFP4-DQ6_K.basalt
```

So if you are extracting the exact official source today, use:

```text
jesdga/Qwen3.8-Flash-Next-Basalt/Qwen3.8-FN-NVFP4-DQ6_K.basalt
```

or, more directly, extract from Shockem’s Q8PLE `.basalt`, because the exact tensor SHA is already known:

```text
per_layer_token_embd.weight
sha256: e02bf3d78153f7c95390ffca1b4279776c90ef302a345aa56bf6b3b694d65e42
```

---

# 3. But NInfer currently does not decode Shockem’s exact Q8_0 PLE rows

This is the critical part.

NInfer’s stock Flash-Next GGUF converter hard-checks the n-gram row format. In:

[`tools/convert/qwen4_exp_gguf.py`](https://github.com/iamwavecut/ninfer-all/blob/master/tools/convert/qwen4_exp_gguf.py)

the n-gram GGUF path effectively does:

```python
if descriptor["format"] != "gguf_iq4_nl":
    raise ValueError("the n-gram GGUF table must contain IQ4_NL rows")
```

So passing a Q8_0 `per_layer_token_embd.weight` through the normal `qwen3_8_flash_next_gguf` recipe will not just “work because it is GGUF.” The converter currently wants IQ4_NL.

NInfer’s runtime is also explicit. In:

[`src/models/qwen4_exp/ngram_component.cpp`](https://github.com/iamwavecut/ninfer-all/blob/master/src/models/qwen4_exp/ngram_component.cpp)

the supported n-gram row formats are:

```cpp
if (format == "gguf_iq4_nl") ...
if (format == "bf16") ...
if (format == "fp8_e4m3fn_row_fp16") ...
```

Otherwise it throws:

```text
the n-gram table is stored as ...; the runtime decodes
gguf_iq4_nl, bf16 and fp8_e4m3fn_row_fp16 rows
```

That means the current supported NInfer PLE row formats are:

```text
IQ4_NL
BF16
FP8 E4M3 row + FP16 row scale
```

Shockem’s Q8_0 row format is not one of them.

So the precise answer is:

```text
The exact Shockem Q8PLE bytes are derivable.
But exact Q8_0 PLE support is not currently stock in NInfer.
```

It is not a model-support gap. It is a table-row-format implementation gap.

---

# 4. Practical conversion options

## Option A: exact Shockem Q8PLE, but requires a small NInfer change

This is the closest to “same artifact as Shockem.”

Pipeline:

```text
Shockem .basalt
→ extract Q8_0 per_layer_token_embd.weight
→ make a GGUF/source containing that tensor
→ convert to .ninfer ngram artifact
→ add/enable gguf_q8_0 as an ngram row format in NInfer
```

What is easy:

- extracting the 54.4 GB tensor
- validating its SHA-256
- preserving the bytes
- writing a table artifact

What is not stock:

- `configure_ngram_gguf()` currently rejects non-IQ4_NL GGUF tables
- `ngram_component.cpp` currently only maps:
  - `gguf_iq4_nl`
  - `bf16`
  - `fp8_e4m3fn_row_fp16`

A Q8_0 PLE implementation would probably not be enormous, because Q8_0 is already a known GGUF block format and the row layout is simple:

```text
160 values = 5 × 32-value Q8_0 blocks
```

But it is not currently implemented as an n-gram PLE row decoder. So exact Shockem Q8PLE in NInfer is a code-support task, not just a data-prep task.

---

## Option B: use NInfer’s supported FP8 PLE table

This is probably the best practical NInfer path if you want “quality over quantity” without exact Shockem byte equality.

NInfer already supports:

```text
fp8_e4m3fn_row_fp16
```

That is:

```text
160 E4M3FN bytes
+ 2-byte FP16 row scale
= 162 bytes/row
```

Size:

```text
320,001,536 × 162
= 51,840,248,832 bytes
≈ 51.8 GB decimal
```

This is only about:

```text
54.4 GB - 51.8 GB
= 2.56 GB
```

smaller than Shockem’s Q8_0 table.

It is not byte-identical to Shockem’s Q8_0 table, but it is a supported high-fidelity PLE representation.

NInfer’s docs say the FP8 table was tested:

- improved held-out perplexity by about **1.25%**
- but worse on code domains
- IQ4_NL remains the published release representation because it is much smaller

So FP8 is a real quality/size tradeoff, not a free win.

---

## Option C: stay on Basalt if exact Shockem Q8PLE is mandatory

Basalt already reads Shockem’s Q8_0 PLE rows. Shockem’s pack is explicitly a Basalt pack.

So if your requirement is:

```text
exact Shockem Q8PLE table
plus batched parallel decode
plus no engine code changes
```

then Basalt is still the natural runtime.

NInfer would require either:

- exact Q8_0 PLE support patch, or
- accept FP8/BF16/IQ4 representation.

---

# 5. DFlash2 quality versus MTP on Flash-Next

## Short answer

For Flash-Next, DFlash2 is **not a lossy quality mode**. It is a verified speculative drafter.

The target model verifies the drafts, so the committed tokens are still the target model’s own decisions.

NInfer’s docs say:

```text
The model verifies them as it verifies MTP's drafts, with the same acceptance,
so every committed token is the model's own draw.
```

And in the DFlash2 measurements:

```text
Every answer matched decoding without drafts.
```

So there is no meaningful model-quality penalty from DFlash2 versus MTP in the normal exact-acceptance mode.

The differences are:

```text
speed
draft acceptance rate
resource footprint
multi-GPU mode support
numerical reproducibility under batching
```

not “the model became worse.”

---

## DFlash2 versus MTP measured speed

NInfer’s Flash-Next docs measured DFlash2 against MTP on an RTX 3090 with IQ3_S host experts.

Approximate decode rates:

| Prompt type | No draft | MTP automatic | DFlash2 default |
|---|---:|---:|---:|
| code | 59.0 tok/s | 83.5 tok/s | 92.3 tok/s |
| prose | 57.5 tok/s | 73.4 tok/s | 77.9 tok/s |
| short 144-token prompt | 45.9 tok/s | 49.8 tok/s | 58.2 tok/s |

DFlash2 was:

```text
1.10×
1.06×
1.17×
```

faster than MTP in those cases.

Also:

```text
Every answer matched decoding without drafts.
```

On tensor-parallel two-GPU Q2_0 device-expert testing, DFlash2 was also reported faster than MTP in most cases, and its answers matched no-draft decoding where MTP’s did not.

That last point is not a “DFlash2 is better quality” claim. It reflects numerical/path differences under speculative execution and batching. The intended quality is still: target model verifies, target model output wins.

---

## Why DFlash2 is resource-lighter than MTP

MTP for Flash-Next is a full extra sparse-attention/MoE-style block.

NInfer’s MTP block:

- comes from Unsloth’s shared-Q8_0 MTP GGUF
- adds about **2.8 GB**
- has its own 512-expert MoE
- has its own KV/state
- can use Q8_0 expert caches

DFlash2:

- from incoai’s Flash-Next DFlash2
- nazeshinjite Q4_0 GGUF form
- about **339 MB**
- five sliding-window draft layers
- conditioned on target model hidden states
- uses a 2,048-position ring per request, about **40 MiB per request**
- target model verifies all drafts

So compared with MTP, DFlash2 is much smaller and usually less stressful on VRAM/RAM/cache.

There is some extra cost:

- draft block compute
- proposal generation
- verification rows
- ring buffers
- DFlash2 feature workspace

But this is generally much lighter than the MTP block itself.

---

## Does Shockem need a special DFlash2 drafter?

No.

DFlash2 is trained for the Flash-Next model family:

```text
Qwen4ExpForConditionalGeneration
qwen4_exp
48 layers
36 GDN + 12 QSA
512 routed experts
top-10
PLE table
```

Shockem’s model is still Flash-Next. The ablation changes some residual-write tensors and therefore may change acceptance rates, but it does not make the model a different architecture.

Use:

```text
incoai/Qwen3.8-Flash-Next-DFlash2
nazeshinjite/Qwen3.8-Flash-Next-DFlash2-GGUF, Q4_0 form
```

You do not need a Shockem-specific DFlash2.

The practical caveat:

```text
Acceptance rate may differ slightly because the model’s token distribution changed.
```

But correctness remains target-verified.

---

## DFlash2 quality caveats

There are a few caveats, but they are not “quality degradation” in the usual sense.

### 1. Batched answers can differ run-to-run

NInfer says concurrent answers can differ between runs because different requests share batches, and floating-point reductions can change near-tie decisions.

This is also true in Basalt-like batched serving.

It is not a drafter quality bug. It is batched floating-point scheduling.

### 2. DFlash2 refuses pipeline stages

For Flash-Next:

```text
--spec dflash2
```

is supported, but pipeline stages are refused.

So if you use NInfer with:

```bash
--devices 0,1
```

as pipeline stages, use MTP.

For DFlash2 with two GPUs, use tensor parallelism rather than pipeline stages.

On your single 5090, this is not a problem.

### 3. DFlash2 is not the same as relaxed drafting

NInfer DFlash2 uses target verification.

Do not confuse it with lossy speculative modes. The output is target-model verified.

---

# 6. Does NInfer-all have actual batched decode like Basalt?

Yes.

NInfer-all has real batched decode for Flash-Next.

The flag is not:

```bash
--parallel
```

like Basalt.

It is:

```bash
--max-concurrency N
```

where `N` is 1 to 8.

---

## What NInfer actually batches

For Flash-Next, NInfer says:

```text
--max-concurrency N (one to eight) runs that many requests at once,
each on its own sequence with its own KV and recurrent state.
```

For expert-heavy decode/prefill:

```text
each round is one batched pass whose experts read their weights once
for the whole batch.
```

For non-stateful projections:

```text
the mixers' projections ... run over every request's columns at once,
in calls of up to eight columns.
```

For stateful parts:

```text
only the convolution, recurrence, KV append, indexer and attention
run request by request.
```

This is the expected split: shared/expert/dense work is batched; sequence-specific recurrent state is handled per sequence.

---

## Speculative batched decode

Under MTP:

```text
Up to eight requests run their rounds together,
one MTP pass for all of them per draft
and one verification pass.
```

Under DFlash2:

```text
A round of several requests verifies at most 64 tokens,
within which eight requests draft four tokens each.
```

That means eight concurrent requests with four drafts each:

```text
8 × 4 = 32 proposal rows
+ anchors/correction rows
```

fits inside the 64-token verification budget.

So yes: NInfer can serve multiple requests with shared batched expert work and batched verification.

---

## Measured Flash-Next batching behavior

NInfer measured Flash-Next concurrency with DFlash2-style automatic drafting on an RTX A6000 host-expert setup.

Approximate aggregate throughput:

| Requests | Without drafts | Four drafts/request default |
|---:|---:|---:|
| 1 | 50.5–66.3 tok/s | 83.1–105.1 tok/s |
| 2 | 72.2–79.5 tok/s | 94.6–105.6 tok/s |
| 3 | 82.4–89.3 tok/s | 104.4–108.9 tok/s |
| 4 | 90.0–93.3 tok/s | 107.3–116.7 tok/s |
| 8 | 85.3–101.0 tok/s | 114.0–118.6 tok/s |

This is not linear speedup, but it is real batched throughput gain.

NInfer also measured prompt-span batching:

- eight concurrent requests finished **1.77–1.94×** faster than chunk-by-chunk prefill in some host/disk-expert cases
- short prompts were admitted and finished much sooner because prefill/decode were interleaved dynamically

---

## How this compares to Basalt’s `--parallel`

Basalt’s model:

```text
--parallel N
```

uses batch slots, with N up to 8. It has:

- slot affinity/session headers
- fixed slots
- per-slot checkpoints
- `--max-context` shared by default
- `--slot-full-context` option
- batched decode windows

NInfer’s model:

```text
--max-concurrency N
```

uses sequences inside one resident Engine, with:

- own KV/recurrent state per sequence
- batched expert/dense work
- batched speculative verification
- prefix reuse/context cache
- dynamic prompt prefill interleaving
- host/disk expert streaming
- KV capacity/state-slot controls

They are conceptually similar, but NInfer’s scheduling is more integrated with its prefix cache and expert placement.

---

# 7. Practical concurrency on your 5090 + 64 GB DDR5

Your 5090 has 32 GB VRAM. Flash-Next IQ3_S wants roughly:

```text
pinned host experts: ~48–50 GB
```

The published IQ3_S host-expert measurements show about:

```text
48.7 GiB pinned host memory
```

on a 5090.

That already consumes most of your 64 GB RAM.

So NInfer can technically run:

```bash
--max-concurrency 8
```

but on your machine practical concurrency is probably lower, depending on:

```text
--max-context
--kv-capacity
--kv-dtype
--host-state-slots
--host-kv-mib
context cache budget
expert cache
KV dtype
```

For a 64 GB machine, I would test:

```bash
--max-concurrency 1
--max-concurrency 2
--max-concurrency 4
```

before assuming 8-request decode is reasonable.

A safer starting command shape:

```bash
ninfer-serve \
  models/shockem-like-qwen3.8-flash-next-iq3_s-dflash2.ninfer \
  --ngram-table models/qwen3.8-flash-next-ngram-table-IQ4_NL-ninfer-v3.ninfer \
  --model-id qwen3.8-flash-next \
  --expert-residency host \
  --max-context 32768 \
  --kv-dtype rk8v4 \
  --max-concurrency 2 \
  --spec dflash2 \
  --draft-tokens 4 \
  --draft-min-p 0.7
```

Do not expect true 8-request parallel decode at large context on 64 GB RAM with IQ3_S host experts. The engine supports it, but your machine may be the limiter.

---

# 8. Final direct answers to 5 and 6

## 5. Is there a DFlash2 quality tradeoff versus Flash-Next’s quality/MTP?

There is **no meaningful model-quality tradeoff** in normal NInfer DFlash2 mode.

DFlash2 drafts, target model verifies, committed tokens are target-model draws. NInfer’s measurements say the answers matched no-draft decoding.

DFlash2 versus MTP is mainly:

```text
faster
smaller drafter
lower resource pressure
different acceptance rate
different multi-GPU constraints
```

DFlash2 is about **339 MB**, versus MTP’s about **2.8 GB** block. It is much lighter.

The caveat is that DFlash2 acceptance can vary by prompt/domain, especially on an ablated fine-tune. But if acceptance is lower, you just get less speed benefit. You do not get a lossy model.

---

## 6. Does NInfer-all port actual batched decode like Basalt?

Yes.

NInfer-all has true batched decode for Flash-Next using:

```bash
--max-concurrency 1..8
```

It batches:

- expert reads where possible
- dense projection work
- speculative verification rows
- prompt/decode interleaving
- prefix cache reuse

It does not batch every stateful layer as one giant kernel, but neither does Basalt’s slot model.

The practical difference:

```text
Basalt: --parallel slots, session affinity, fixed slot behavior
NInfer: --max-concurrency sequences, prefix/context cache, dynamic KV/state slots
```

Both are real batched serving systems.

For your 5090 + 64 GB RAM, NInfer supports it, but practical parallelism will likely be bounded by RAM/KV/expert cache, not by the engine’s architectural limit.

"""
|])

let render() = file
