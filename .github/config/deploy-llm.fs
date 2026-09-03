module Config.Workflows.Deployllm

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy llm"
        SourceFolder = "llm"
        TargetRepo = "llm-pages"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
        UseSharedStrings = false
    }
