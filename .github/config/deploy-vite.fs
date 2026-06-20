module Config.Workflows.DeployVite

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy Vite"
        SourceFolder = "vite"
        TargetRepo = "reactproj"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
    }
