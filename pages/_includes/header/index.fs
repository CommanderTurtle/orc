module ConvertedFiles.Includes.HeaderHtml

open Giraffe.ViewEngine

let page =
    html [] []

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
