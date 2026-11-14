module Config.Workflows.Deployocr

let render() =
    Config.Workflows.DeployCommon.render {
        WorkflowName = "Deploy ocr"
        SourceFolder = "ocr"
        TargetRepo = "ocr-pages"
        TargetBranch = "main"
        TokenName = "GH_PAGES_TOKEN"
        UseSharedStrings = false
    }
