module Muz.Source.BunLock

let file = """{
  "lockfileVersion": 2,
  "configVersion": 1,
  "workspaces": {
    "": {
      "name": "muzstatic",
      "devDependencies": {
        "@codemirror/commands": "6.11.0",
        "@codemirror/language": "6.12.4",
        "@codemirror/search": "6.7.2",
        "@codemirror/state": "6.7.4",
        "@codemirror/view": "6.43.11",
        "@lezer/highlight": "1.2.3",
        "codemirror": "6.0.2",
        "dompurify": "3.4.17",
        "fflate": "0.8.3",
        "marked": "18.0.13",
        "vite": "8.3.5",
      },
    },
  },
  "packages": {
    "@codemirror/autocomplete": ["@codemirror/autocomplete@6.20.4", "", { "dependencies": { "@codemirror/language": "^6.0.0", "@codemirror/state": "^6.0.0", "@codemirror/view": "^6.17.0", "@lezer/common": "^1.0.0" } }, "sha512-yF8RhOf2SXlg00+qtupzLhrglcas61boqaONiNcbPIebHCpJocpqTBA6dyrtUrQO47hqyTdeob/3XnYilT7TaQ=="],

    "@codemirror/commands": ["@codemirror/commands@6.11.0", "", { "dependencies": { "@codemirror/language": "^6.0.0", "@codemirror/state": "^6.7.0", "@codemirror/view": "^6.27.0", "@lezer/common": "^1.1.0" } }, "sha512-/K4Rl5BN0OtTiPWmJCdqODu38XnDMsDxKY5rgrPnCkutPTJf2wVbkoixLfealF5Kwse/s8P8M5jAiURiwSwnFA=="],

    "@codemirror/language": ["@codemirror/language@6.12.4", "", { "dependencies": { "@codemirror/state": "^6.0.0", "@codemirror/view": "^6.23.0", "@lezer/common": "^1.5.0", "@lezer/highlight": "^1.0.0", "@lezer/lr": "^1.0.0", "style-mod": "^4.0.0" } }, "sha512-1q4PaT+o6PbgpkJt4Q8Fv5XJxTy4FUZ4MWETtyiDw3J0Pyr9E2vqcKL+k9wcvjNTIsauxvE7OfmWj3FRPHQ76A=="],

    "@codemirror/lint": ["@codemirror/lint@6.9.7", "", { "dependencies": { "@codemirror/state": "^6.0.0", "@codemirror/view": "^6.42.0", "crelt": "^1.0.5" } }, "sha512-28/+iWLYxKxsvGYhSYL7zaCZqLz5+FFFDq9tVsvGv9kv8RY4fFAchJ5WX9M3YrrRlTIsECjsXPqeNgnSmNP2dg=="],

    "@codemirror/search": ["@codemirror/search@6.7.2", "", { "dependencies": { "@codemirror/state": "^6.0.0", "@codemirror/view": "^6.37.0", "crelt": "^1.0.5" } }, "sha512-gUYkYhT2+n/+VGZ+8EzE5WFkYZUZYm1VOKDudIsNqh42uRVQJ0a6Yss9sdKT3MeOYfuL1N6AZA57oza0Oyr0LA=="],

    "@codemirror/state": ["@codemirror/state@6.7.4", "", { "dependencies": { "@marijn/find-cluster-break": "^1.0.0" } }, "sha512-QhQIVRY+xHZDxwOSFrJ1eUMapJBUID3IdeAjf7dHO7zBUzSkyooHiodnalz5MG3iHzwixKMlAAyn7244y537EA=="],

    "@codemirror/view": ["@codemirror/view@6.43.11", "", { "dependencies": { "@codemirror/state": "^6.7.0", "crelt": "^1.0.6", "style-mod": "^4.1.0", "w3c-keyname": "^2.2.4" } }, "sha512-2+esucbQX6wB2JYi1eDvdCPFTA31BN8oSy6xCmk3G6CloV11yOvEjYk+gH7kLrP0MuHG94E8WDhjs5oMiu3+Wg=="],

    "@lezer/common": ["@lezer/common@1.5.5", "", {}, "sha512-Pw7PVCndruF1pb3ebCxpSVpkMHSDjwRCLcTRw+RizUKco5QbWylwq2g4lnG/RYN7yTTQDXE9F77MwtkAyphrjg=="],

    "@lezer/highlight": ["@lezer/highlight@1.2.3", "", { "dependencies": { "@lezer/common": "^1.3.0" } }, "sha512-qXdH7UqTvGfdVBINrgKhDsVTJTxactNNxLk7+UMwZhU13lMHaOBlJe9Vqp907ya56Y3+ed2tlqzys7jDkTmW0g=="],

    "@lezer/lr": ["@lezer/lr@1.4.12", "", { "dependencies": { "@lezer/common": "^1.0.0" } }, "sha512-On9HU4oMMiHPMkQDgoTnGahjgG5n/MkN38CgG77sMraKLL+3JBbeQNi1FcCXV9QRqwF9/BUXP3caHyJC1fBOTQ=="],

    "@marijn/find-cluster-break": ["@marijn/find-cluster-break@1.0.4", "", {}, "sha512-Wy0V7+SGUjnF9/TkiM1hKVDPj7jKXduPNboMVtHTA8dySMURWqfg/JZ9E2Sq8JgSJmkl7k7Qe9FLeMSrSraWmQ=="],

    "@oxc-project/types": ["@oxc-project/types@0.156.0", "", {}, "sha512-1Duyg48TdJNdyhEB8Xn1L36bT9Pv6GUtlKjHxOys8xkaF/rQq3XJE+bAurSK/AgIz5mGFsb77cn9Pb20+WCScw=="],

    "@rolldown/binding-android-arm-eabi": ["@rolldown/binding-android-arm-eabi@1.2.16", "", { "os": "android", "cpu": "arm" }, "sha512-ia3DwAs0OsMGS7+IConptSiyk9pEXkOx/AbJ2n/lAGxH3QkWQus1t8d7gnAT38FCU2sQu8lUbeR6AiZFv4JxaA=="],

    "@rolldown/binding-android-arm64": ["@rolldown/binding-android-arm64@1.2.16", "", { "os": "android", "cpu": "arm64" }, "sha512-kx5wBiMB6E7TEvpl2B9gjLU004BkvEm2Dr941BFjx/SontPwSzNuQUIoVKxHHoSjpFIfHMmcguyLOtyn0hObRg=="],

    "@rolldown/binding-darwin-arm64": ["@rolldown/binding-darwin-arm64@1.2.16", "", { "os": "darwin", "cpu": "arm64" }, "sha512-qslZrXnKJU4cUpjoAmtAo/KQM9e2IRMlmpig6Zpwj+8KWxW8v+nkAf9216Bsek9lOC1jvg2yCjygCFo2f83msQ=="],

    "@rolldown/binding-darwin-x64": ["@rolldown/binding-darwin-x64@1.2.16", "", { "os": "darwin", "cpu": "x64" }, "sha512-FdF+y48ND13eAyM2mQn+85kvAqNlvRWROy2rhgA463X/0Gv4vGtazZtfaF1mRBLscYvtOlh4QnLjOWiFzX69OQ=="],

    "@rolldown/binding-freebsd-x64": ["@rolldown/binding-freebsd-x64@1.2.16", "", { "os": "freebsd", "cpu": "x64" }, "sha512-ddjqFM5e95AgLbUPtKIS7V1KTVlA0RUgCVr5mn+/IEhsdy3pr+Vuj/HZ7nlMN2FyxIwUktOH1LEPIQXO1v9y1Q=="],

    "@rolldown/binding-linux-arm-gnueabihf": ["@rolldown/binding-linux-arm-gnueabihf@1.2.16", "", { "os": "linux", "cpu": "arm" }, "sha512-tHdKWbFkFBI687iim3LIyIvyL7j66VvQYkDPss5Stn/qyE2tWkR1YD0dXmXPFKKqT/o5ZEJVsaRsWS2meQwGOA=="],

    "@rolldown/binding-linux-arm64-gnu": ["@rolldown/binding-linux-arm64-gnu@1.2.16", "", { "os": "linux", "cpu": "arm64", "libc": "glibc" }, "sha512-FJiLGAblPBMlBEdbOqw6kW6QcXDWAf/oJu7gYs9ZJZwmg+K+/zjFLxPTIY9izJUzxzc24FHvmseyA0IvJSl17w=="],

    "@rolldown/binding-linux-arm64-musl": ["@rolldown/binding-linux-arm64-musl@1.2.16", "", { "os": "linux", "cpu": "arm64", "libc": "musl" }, "sha512-hrJpblMsrQ58U9veWpbXzkhV5zStunds6HWLprqq1qauvgBr1E6P+24kLj6lSLI9vjRn/RYpjprhkHQPKGWpNg=="],

    "@rolldown/binding-linux-ppc64-gnu": ["@rolldown/binding-linux-ppc64-gnu@1.2.16", "", { "os": "linux", "cpu": "ppc64", "libc": "glibc" }, "sha512-qJd/dC6j6CwLG9/s/RP2nb1RZ0GIgj7Ioj7x/SYa3RzjVrlzrmH0fhIOpfvqQDeIsdP0loi+kHaMhJzY1PBIaA=="],

    "@rolldown/binding-linux-s390x-gnu": ["@rolldown/binding-linux-s390x-gnu@1.2.16", "", { "os": "linux", "cpu": "s390x", "libc": "glibc" }, "sha512-Vx7Xg5uUJuNcujJjI70OICaH0EYj80BtOLZTSN7uOYg8QOLlyKnaG0IW7Fn/J0IpJsaKzmDKMhOQv1JBM9m9vg=="],

    "@rolldown/binding-linux-x64-gnu": ["@rolldown/binding-linux-x64-gnu@1.2.16", "", { "os": "linux", "cpu": "x64", "libc": "glibc" }, "sha512-TNKhgE3uJTsTzatUSSYt0Kgo+Oa2uSlSjz4r1aEIea7HX6ULBym4fAlYUhG1i6pjNf2njfCUAfKwr6C3E9Xg1w=="],

    "@rolldown/binding-linux-x64-musl": ["@rolldown/binding-linux-x64-musl@1.2.16", "", { "os": "linux", "cpu": "x64", "libc": "musl" }, "sha512-7chXdpjXZ8qG0+mIxECN3cT9kvhZ3/oZhMX6Pp876P7CDrIy8nJswva6Mq357JR7eYXfuskwZxMeV1SzoZdHrA=="],

    "@rolldown/binding-openharmony-arm64": ["@rolldown/binding-openharmony-arm64@1.2.16", "", { "os": "none", "cpu": "arm64" }, "sha512-Kwjt+7uNTJK5/MDkGWGVO2KQPnj8yAV75dMpfwyHZrJSXWHrniOB0aUEWlVYf3H1hOqFLIStLdM5QXq6bnKmOQ=="],

    "@rolldown/binding-win32-arm64-msvc": ["@rolldown/binding-win32-arm64-msvc@1.2.16", "", { "os": "win32", "cpu": "arm64" }, "sha512-/LH6WfjDRXXJz/p5xl4TmU+jpcnwcxbKEQBW/GZE0JHfN0lGIyTtsUEGaQ/q/GikkGJ2yLKe6pwm7AnEWO8pdw=="],

    "@rolldown/binding-win32-x64-msvc": ["@rolldown/binding-win32-x64-msvc@1.2.16", "", { "os": "win32", "cpu": "x64" }, "sha512-1lv1KvX0Z871zfk7vw+dnXMMnHNyDwMzWG8Kv3HxDXMOhzCX4SHc7HK319fInP0i+0p9D8brkfzL7pJOaGl+tw=="],

    "@rolldown/pluginutils": ["@rolldown/pluginutils@1.0.1", "", {}, "sha512-2j9bGt5Jh8hj+vPtgzPtl72j0yRxHAyumoo6TNfAjsLB04UtpSvPbPcDcBMxz7n+9CYB0c1GxQFxYRg2jimqGw=="],

    "@types/trusted-types": ["@types/trusted-types@2.0.7", "", {}, "sha512-ScaPdn1dQczgbl0QFTeTOmVHFULt394XJgOQNoyVhZ6r2vLnMLJfBPd53SB52T/3G36VI1/g2MZaX0cwDuXsfw=="],

    "codemirror": ["codemirror@6.0.2", "", { "dependencies": { "@codemirror/autocomplete": "^6.0.0", "@codemirror/commands": "^6.0.0", "@codemirror/language": "^6.0.0", "@codemirror/lint": "^6.0.0", "@codemirror/search": "^6.0.0", "@codemirror/state": "^6.0.0", "@codemirror/view": "^6.0.0" } }, "sha512-VhydHotNW5w1UGK0Qj96BwSk/Zqbp9WbnyK2W/eVMv4QyF41INRGpjUhFJY7/uDNuudSc33a/PKr4iDqRduvHw=="],

    "crelt": ["crelt@1.0.7", "", {}, "sha512-aK6BbWfhf4U/wCcLHKPJl/xa6VkVstRaPywWtMKGwuOLc/wZTyQYuoxgvZnNsBvv7Kg3YTBQYYBCggcviQczuA=="],

    "detect-libc": ["detect-libc@2.1.2", "", {}, "sha512-Btj2BOOO83o3WyH59e8MgXsxEQVcarkUOpEYrubB0urwnN10yQ364rsiByU11nZlqWYZm05i/of7io4mzihBtQ=="],

    "dompurify": ["dompurify@3.4.17", "", { "optionalDependencies": { "@types/trusted-types": "^2.0.7" } }, "sha512-B/pSlYVHQ58kqISD/yDjuJ1yfzI34m1gF4lAod2bwSRhiN4K5Cl3H8Af7hqB2PmTL911tdEudnnXn5FnhRoz0w=="],

    "fdir": ["fdir@6.5.0", "", { "peerDependencies": { "picomatch": "^3 || ^4" }, "optionalPeers": ["picomatch"] }, "sha512-tIbYtZbucOs0BRGqPJkshJUYdL+SDH7dVM8gjy+ERp3WAUjLEFJE+02kanyHtwjWOnwrKYBiwAmM0p4kLJAnXg=="],

    "fflate": ["fflate@0.8.3", "", {}, "sha512-tbZNuJrLwGUp3zshBtdy4W+ORxZuIh8a5ilyIEQDC5rY1f3U20JMry0Ll3WBzU58EZKsEuJFXhb5gwv8CsPvgA=="],

    "fsevents": ["fsevents@2.3.3", "", { "os": "darwin", "hasInstallScript": true }, "sha512-5xoDfX+fL7faATnagmWPpbFtwh/R77WmMMqqHGS65C3vvB0YHrgF+B1YmZ3441tMj5n63k0212XNoJwzlhffQw=="],

    "lightningcss": ["lightningcss@1.33.0", "", { "dependencies": { "detect-libc": "^2.0.3" }, "optionalDependencies": { "lightningcss-android-arm64": "1.33.0", "lightningcss-darwin-arm64": "1.33.0", "lightningcss-darwin-x64": "1.33.0", "lightningcss-freebsd-x64": "1.33.0", "lightningcss-linux-arm-gnueabihf": "1.33.0", "lightningcss-linux-arm64-gnu": "1.33.0", "lightningcss-linux-arm64-musl": "1.33.0", "lightningcss-linux-x64-gnu": "1.33.0", "lightningcss-linux-x64-musl": "1.33.0", "lightningcss-win32-arm64-msvc": "1.33.0", "lightningcss-win32-x64-msvc": "1.33.0" } }, "sha512-WkUDrojuJs0xkgGf2udWxa3yGBRxPtxUkB79i6aCZLRgc7PM8fZe9TosfPDcvEpQZbuFASnHYmRLBLUbmLOIIA=="],

    "lightningcss-android-arm64": ["lightningcss-android-arm64@1.33.0", "", { "os": "android", "cpu": "arm64" }, "sha512-gEpRTalKdosp4Bb8qWtc2iOgE5SeIHlpS1up9bFq2wAyYhl1UdTObYiHe98zEM9SQvSoqQZ1IQD0JNpg3Ml5pg=="],

    "lightningcss-darwin-arm64": ["lightningcss-darwin-arm64@1.33.0", "", { "os": "darwin", "cpu": "arm64" }, "sha512-Sciaz8eenNTKn9b3t7+xr0ipTp9YxKQY4npwQ3mrRuL0BAVHBLyZxofhaKBAVtzmtRZ/zTyo0/to4B1uWG/Djg=="],

    "lightningcss-darwin-x64": ["lightningcss-darwin-x64@1.33.0", "", { "os": "darwin", "cpu": "x64" }, "sha512-Z5UPAxzrjlWNNyGy6i65cJzzvgJ5D3T6wMvs+gWpY9d7qRhANrxqAp6LhxIgZhWEw18RfJTGcRxjuLIBr+m8XQ=="],

    "lightningcss-freebsd-x64": ["lightningcss-freebsd-x64@1.33.0", "", { "os": "freebsd", "cpu": "x64" }, "sha512-QQM/Ti/hQajJwCY+RiWuCZ9sdtI/XQk7nDK5vC8kkdwixezOlDgvDx7+RT+QjK6FcFT4MpsuoBnHIo/O3StRRg=="],

    "lightningcss-linux-arm-gnueabihf": ["lightningcss-linux-arm-gnueabihf@1.33.0", "", { "os": "linux", "cpu": "arm" }, "sha512-N7FVBe6iS24MlM6R/4RBTxGhQheZGs7tiQ9U32UtF75NzP5Q7xWPRqLBCKxlRQRk3rY1jCIPLzx7WzOhuUIRLQ=="],

    "lightningcss-linux-arm64-gnu": ["lightningcss-linux-arm64-gnu@1.33.0", "", { "os": "linux", "cpu": "arm64", "libc": "glibc" }, "sha512-j2v/itmy4HlNxlc6voKXYgBqNi0Ng2LShg4z7GufpEgs05P+2suBVyi9I6YHq5uoVFx9ETin3eCEhLVyXGQnKg=="],

    "lightningcss-linux-arm64-musl": ["lightningcss-linux-arm64-musl@1.33.0", "", { "os": "linux", "cpu": "arm64", "libc": "musl" }, "sha512-yiO5ROMuYQgXbC60yjZU5CYSFZGKXL0HFATXt9mHJn1+zW55oCtMI9NfcVhYLMFDL7gV7oBPon/EmMMGg2OvtQ=="],

    "lightningcss-linux-x64-gnu": ["lightningcss-linux-x64-gnu@1.33.0", "", { "os": "linux", "cpu": "x64", "libc": "glibc" }, "sha512-ar+Ju7LmcN0Jo4FpL4hpFybwNG9/3A/Br5KW2n2jyODg3MEZXaDYADdemoNS+BDNfMgKvylJLj4S5tyRActuAg=="],

    "lightningcss-linux-x64-musl": ["lightningcss-linux-x64-musl@1.33.0", "", { "os": "linux", "cpu": "x64", "libc": "musl" }, "sha512-RYiYbkokw0trfKqqzfF55lginwEPrD3OJDfTuJzFs1MK6iFnDenaz1fqLLtX4ITG3OktJQXOeTaw1awrBAlZPw=="],

    "lightningcss-win32-arm64-msvc": ["lightningcss-win32-arm64-msvc@1.33.0", "", { "os": "win32", "cpu": "arm64" }, "sha512-1K+MPfLSFVpphzpdbfkhlWk6wBrTObBzS2T6db10PNOZgR9GoVsAWzwNyuhUYYbTp23j+4RrncfujZ4uAzXvwA=="],

    "lightningcss-win32-x64-msvc": ["lightningcss-win32-x64-msvc@1.33.0", "", { "os": "win32", "cpu": "x64" }, "sha512-OlEICDx/Xl0FqSp4bry8zFnCvGpig3Gl4gCquvYwHuqJKEC1+n9NgDniFvqHGmMv1ZkqDJrDqKKSykTDX+ehuA=="],

    "marked": ["marked@18.0.13", "", { "bin": { "marked": "bin/marked.js" } }, "sha512-xTxVzZsBFwunP6HDmtBkabUQEYArnP7/rMDGmPj9SlrKlQ4i8MdYVow+nJL0eOqwpUqhzBoTBRADGN6uYwPyOw=="],

    "nanoid": ["nanoid@3.3.20", "", { "bin": { "nanoid": "bin/nanoid.cjs" } }, "sha512-uKdg2G3GNCKQn9byYOpxbGqrT2fGO5KRt5J/8b3pok8rT6qxGWF6hxMyJiEYtAf+FVyYuD9hRaDqX5uPFYJ4ZQ=="],

    "picocolors": ["picocolors@1.1.1", "", {}, "sha512-xceH2snhtb5M9liqDsmEw56le376mTZkEX/jEb/RxNFyegNul7eNslCXP9FDj/Lcu0X8KEyMceP2ntpaHrDEVA=="],

    "picomatch": ["picomatch@4.0.7", "", {}, "sha512-qcJu88Q2IWqJsDD529JKMdwGm/dvInW4HvQnRwiH9JtihJvzGOscDtHE3x1pBKeUOTysQ8kVmLnJ2kJu7yhcGA=="],

    "postcss": ["postcss@8.5.32", "", { "dependencies": { "nanoid": "^3.3.20", "picocolors": "^1.1.1", "source-map-js": "^1.2.2" } }, "sha512-LJlKCCAUFKOuZxipUdYw1NzIITEsPcgyOG9LkvRJvuKj/bRzbuRY0ARXvL0pWGpsZvn8jku+LMep2eU0seHp8g=="],

    "rolldown": ["rolldown@1.2.16", "", { "dependencies": { "@oxc-project/types": "=0.156.0", "@rolldown/pluginutils": "^1.0.0" }, "optionalDependencies": { "@rolldown/binding-android-arm-eabi": "1.2.16", "@rolldown/binding-android-arm64": "1.2.16", "@rolldown/binding-darwin-arm64": "1.2.16", "@rolldown/binding-darwin-x64": "1.2.16", "@rolldown/binding-freebsd-x64": "1.2.16", "@rolldown/binding-linux-arm-gnueabihf": "1.2.16", "@rolldown/binding-linux-arm64-gnu": "1.2.16", "@rolldown/binding-linux-arm64-musl": "1.2.16", "@rolldown/binding-linux-ppc64-gnu": "1.2.16", "@rolldown/binding-linux-s390x-gnu": "1.2.16", "@rolldown/binding-linux-x64-gnu": "1.2.16", "@rolldown/binding-linux-x64-musl": "1.2.16", "@rolldown/binding-openharmony-arm64": "1.2.16", "@rolldown/binding-win32-arm64-msvc": "1.2.16", "@rolldown/binding-win32-x64-msvc": "1.2.16" }, "bin": { "rolldown": "./bin/cli.mjs" } }, "sha512-bWvlMpFKiTfDKfnK7FC2MPgPeWCf/Kpwsq49ApdW+FQaBZb6O6dZ4MAPbPUjp7hYQrw/RobqCzn64BRrQecGHw=="],

    "source-map-js": ["source-map-js@1.2.2", "", {}, "sha512-KGj/8Y43x35aZVDtt+J4mK1hoLGHULMYfSkODJNQjNDC3oW1PqPoxMwo0pLUsWM/UEGzON/NxeHywEfNXNP3Vw=="],

    "style-mod": ["style-mod@4.1.4", "", {}, "sha512-XXWIQt633/EpAFx8aZDOTjBzrCaGmhvEQlQo6MVPfa2OzO2cWo+4hV9h+6UkHYlXGfy+ODXKUdP7Pthmcu5ATw=="],

    "tinyglobby": ["tinyglobby@0.2.17", "", { "dependencies": { "fdir": "^6.5.0", "picomatch": "^4.0.4" } }, "sha512-wXR/dYpcqKmfWpEdZjiKJOwCNFndD0DMnrW/cYjVGttEkBfVgcLFHoNrlj47mjOVic9yyNu65alsgF4NQyTa2g=="],

    "vite": ["vite@8.3.5", "", { "dependencies": { "lightningcss": "^1.33.0", "picomatch": "^4.0.7", "postcss": "^8.5.30", "rolldown": "~1.2.14", "tinyglobby": "^0.2.17" }, "optionalDependencies": { "fsevents": "~2.3.3" }, "peerDependencies": { "@types/node": "^20.19.0 || >=22.12.0", "@vitejs/devtools": "^0.7.1 || ^0.8.0", "esbuild": "^0.27.0 || ^0.28.0", "jiti": ">=1.21.0", "less": "^4.0.0", "sass": "^1.70.0", "sass-embedded": "^1.70.0", "stylus": ">=0.54.8", "sugarss": "^5.0.0", "terser": "^5.16.0", "tsx": "^4.8.1", "yaml": "^2.4.2" }, "optionalPeers": ["@types/node", "@vitejs/devtools", "esbuild", "jiti", "less", "sass", "sass-embedded", "stylus", "sugarss", "terser", "tsx", "yaml"], "bin": { "vite": "bin/vite.js" } }, "sha512-z1YpjieJ9g0ebTmQpLBv/oq9E3F9EIlOe+7LahW8SrE3LTiG3udBRUXQOlYXP9b+IC2q2phHeVxj9xGlw34OEQ=="],

    "w3c-keyname": ["w3c-keyname@2.2.8", "", {}, "sha512-dpojBhNsCNN7T82Tm7k26A6G9ML3NkhDsnw9n/eoxSRlVBB4CEtIQ/KTCLI2Fwf3ataSXRhYFkQi3SlnFwPvPQ=="],
  }
}
"""

let render() = file
