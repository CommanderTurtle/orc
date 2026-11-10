module Config.Workflows.DeployNet

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy Net"
        SourceFolder = "net"
        TargetRepo = "net-docs"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
        UseSharedStrings = false
    }
