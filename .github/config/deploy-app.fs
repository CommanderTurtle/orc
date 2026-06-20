module Config.Workflows.DeployApp

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy App"
        SourceFolder = "app"
        TargetRepo = "app-pages"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
    }
