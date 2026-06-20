module Config.Workflows.DeployDocs

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy Docs"
        SourceFolder = "docs"
        TargetRepo = "docs-pages"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
    }
