module Config.Workflows.DeployBlog

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy Blog"
        SourceFolder = "blog"
        TargetRepo = "CommanderTurtle.github.io"
        TargetBranch = "master"
        TokenName = "GH_PAGES_TOKEN"
    }
