module Config.Workflows.Deploymllm

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy mllm"
        SourceFolder = "mllm"
        TargetRepo = "mllm-pages"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
        UseSharedStrings = false
    }
