module Comfy.Comfystatic.NativeInline0Js

let file = """;(function () {
        var bg, fg
        try {
          bg = localStorage.getItem('comfy-splash-bg')
          fg = localStorage.getItem('comfy-splash-fg')
        } catch (_) {}
        if (!bg || !fg) {
          var isDark =
            window.matchMedia &&
            window.matchMedia('(prefers-color-scheme: dark)').matches
          bg = isDark ? '#202020' : '#f5f5f5'
          fg = isDark ? '#ffffff' : '#000000'
        }
        document.documentElement.style.setProperty('--bg-color', bg)
        document.documentElement.style.setProperty('--fg-color', fg)
        var el = document.getElementById('splash-loader')
        if (el) {
          el.style.background = bg
          el.style.color = fg
        }
      })()"""

let render() = file
