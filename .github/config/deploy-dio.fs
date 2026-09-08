module Config.Workflows.DeployDio

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy Dio"
        SourceFolder = "dio"
        TargetRepo = "dio-pages"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
        UseSharedStrings = false
    }
