module Config.Workflows.Deploylink

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy link"
        SourceFolder = "link"
        TargetRepo = "a-pages"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
        UseSharedStrings = false
    }
