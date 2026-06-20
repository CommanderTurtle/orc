module Config.Workflows.DeployPages

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy Pages"
        SourceFolder = "pages"
        TargetRepo = "blog-pages"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
    }
