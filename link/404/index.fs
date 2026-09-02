module ConvertedFiles.Link.N404Html

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1" ]
            meta [ attr "name" "color-scheme"; attr "content" "dark light" ]
            title [] [
                str "ln.kr · opening document"
            ]
            style [] [ rawText ("""body { margin: 0; display: grid; min-height: 100vh; place-items: center; background: #111512; color: #dce7de; font: 16px system-ui, sans-serif; }""") ]
        ]
        body [] [
            p [] [
                str "Opening ln.kr document…"
            ]
            script [] [
                    rawText ("""const marker = "/T/";
    const markerIndex = location.pathname.toUpperCase().indexOf(marker);
    if (markerIndex >= 0) {
      const base = location.pathname.slice(0, markerIndex + 1);
      const payload = location.pathname.slice(markerIndex + marker.length);
      location.replace(`${base}#q:${encodeURIComponent(payload)}`);
    } else {
      const base = location.pathname.replace(/[^/]*$/, "");
      location.replace(base || "/");
    }""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
