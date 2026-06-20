module Config.Workflows.DeployLab

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy Lab"
        SourceFolder = "lab"
        TargetRepo = "prov"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
    }
