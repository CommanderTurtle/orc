module Config.Workflows.Deploytts

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy tts"
        SourceFolder = "tts"
        TargetRepo = "tts-pages"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
        UseSharedStrings = false
    }
