module Muz.Source.Src.IndexHtml

open Giraffe.ViewEngine

let page =
    html [ _lang "en" ] [
        head [] [
            meta [ attr "charset" "utf-8" ]
            meta [ attr "name" "viewport"; attr "content" "width=device-width, initial-scale=1" ]
            meta [ attr "name" "theme-color"; attr "content" "#101419" ]
            meta [ attr "name" "description"; attr "content" "A static, local-first workspace for the muz music language." ]
            title [] [
                str "muzstatic"
            ]
            link [ attr "rel" "stylesheet"; _href "data:text/css;base64,OnJvb3R7Y29sb3Itc2NoZW1lOmRhcms7LS1iZzojMTAxNDE5Oy0tcGFuZWw6IzE1MWIyMjstLXJhaXNlZDojMWIyMzJkOy0tYm9yZGVyOiMyYjM1NDE7LS10ZXh0OiNkNGRjZTU7LS1kaW06IzhlOWNhYzstLWFjY2VudDojODlkNmI0Oy0tcmVkOiNmMjljOWM7Zm9udC1mYW1pbHk6dWktbW9ub3NwYWNlLFNGTW9uby1SZWd1bGFyLENvbnNvbGFzLCJMaWJlcmF0aW9uIE1vbm8iLG1vbm9zcGFjZTtmb250LXNpemU6MTNweH0qe2JveC1zaXppbmc6Ym9yZGVyLWJveH1ib2R5e21hcmdpbjowO2JhY2tncm91bmQ6dmFyKC0tYmcpO2NvbG9yOnZhcigtLXRleHQpO2hlaWdodDoxMDBkdmg7ZGlzcGxheTpmbGV4O2ZsZXgtZGlyZWN0aW9uOmNvbHVtbjttaW4td2lkdGg6MzUwcHh9YnV0dG9uLGlucHV0LHNlbGVjdCx0ZXh0YXJlYXtmb250OmluaGVyaXQ7Y29sb3I6aW5oZXJpdH1idXR0b257Ym9yZGVyOjFweCBzb2xpZCB2YXIoLS1ib3JkZXIpO2JhY2tncm91bmQ6dmFyKC0tcmFpc2VkKTtib3JkZXItcmFkaXVzOjVweDtwYWRkaW5nOjdweCAxMXB4O2N1cnNvcjpwb2ludGVyO3doaXRlLXNwYWNlOm5vd3JhcH1idXR0b246aG92ZXJ7Ym9yZGVyLWNvbG9yOiM2NDc3ODk7YmFja2dyb3VuZDojMjUzMTNkfWJ1dHRvbjpkaXNhYmxlZHtvcGFjaXR5Oi40O2N1cnNvcjpkZWZhdWx0fWJ1dHRvbjpmb2N1cy12aXNpYmxlLGE6Zm9jdXMtdmlzaWJsZXtvdXRsaW5lOjJweCBzb2xpZCB2YXIoLS1hY2NlbnQpO291dGxpbmUtb2Zmc2V0OjJweH0ucHJpbWFyeXtiYWNrZ3JvdW5kOnZhcigtLWFjY2VudCk7Y29sb3I6IzEwMjYxZTtib3JkZXItY29sb3I6dmFyKC0tYWNjZW50KTtmb250LXdlaWdodDo3MDB9LnByaW1hcnk6aG92ZXJ7YmFja2dyb3VuZDojYTZlOWNiO2NvbG9yOiMxMDI2MWV9LmFjY2VudHtjb2xvcjp2YXIoLS1hY2NlbnQpfS50b3BiYXJ7aGVpZ2h0OjY0cHg7cGFkZGluZzoxMnB4IDIycHg7ZGlzcGxheTpmbGV4O2FsaWduLWl0ZW1zOmNlbnRlcjtqdXN0aWZ5LWNvbnRlbnQ6c3BhY2UtYmV0d2Vlbjtib3JkZXItYm90dG9tOjFweCBzb2xpZCB2YXIoLS1ib3JkZXIpO2dhcDoyMHB4fS5icmFuZHtkaXNwbGF5OmZsZXg7YWxpZ24taXRlbXM6Y2VudGVyO2dhcDoxMnB4O2ZvbnQtc2l6ZToxOHB4O2xldHRlci1zcGFjaW5nOi0uNXB4fS5tYXJre2JvcmRlcjoxcHggc29saWQgIzUwNzk2ODtib3JkZXItcmFkaXVzOjdweDtjb2xvcjp2YXIoLS1hY2NlbnQpO2ZvbnQtc2l6ZToyNHB4O2xpbmUtaGVpZ2h0OjMwcHg7cGFkZGluZzowIDdweH0ubWFyayBzcGFue2ZvbnQtc2l6ZToxOHB4fS50YWd7Zm9udC1zaXplOjExcHg7Y29sb3I6dmFyKC0tZGltKTtmb250LXdlaWdodDo0MDA7bGV0dGVyLXNwYWNpbmc6MH0uYnJhbmQ+LnRhZ3tib3JkZXItbGVmdDoxcHggc29saWQgdmFyKC0tYm9yZGVyKTtwYWRkaW5nLWxlZnQ6MTJweH1uYXZ7ZGlzcGxheTpmbGV4O2dhcDo2cHh9LnRyYW5zcG9ydHtkaXNwbGF5OmZsZXg7Z2FwOjhweDthbGlnbi1pdGVtczpjZW50ZXI7cGFkZGluZzoxMnB4IDIycHg7Ym9yZGVyLWJvdHRvbToxcHggc29saWQgdmFyKC0tYm9yZGVyKTtmbGV4LXdyYXA6d3JhcH0udGltZXtkaXNwbGF5OmZsZXg7Z2FwOjlweDthbGlnbi1pdGVtczpjZW50ZXI7bWFyZ2luOjAgMTNweDtmb250LXNpemU6MTVweH0udGltZSBzcGFue2NvbG9yOiM0YjVhNjl9LnZvbHVtZXtjb2xvcjp2YXIoLS1kaW0pO2ZvbnQtc2l6ZToxMXB4O2Rpc3BsYXk6ZmxleDthbGlnbi1pdGVtczpjZW50ZXI7Z2FwOjhweDttYXJnaW4tbGVmdDoxMHB4fWlucHV0W3R5cGU9cmFuZ2Vde3dpZHRoOjgycHg7YWNjZW50LWNvbG9yOnZhcigtLWFjY2VudCl9LnNwYWNlcntmbGV4OjF9bWFpbntkaXNwbGF5OmdyaWQ7Z3JpZC10ZW1wbGF0ZS1jb2x1bW5zOm1pbm1heCgzNjBweCwxZnIpIG1pbm1heCgzNjBweCwxZnIpO2ZsZXg6MTttaW4taGVpZ2h0OjB9LmVkaXRvci1wYW5lbCwub3V0cHV0LXBhbmVse2Rpc3BsYXk6ZmxleDtmbGV4LWRpcmVjdGlvbjpjb2x1bW47bWluLWhlaWdodDowO21pbi13aWR0aDowfS5lZGl0b3ItcGFuZWx7Ym9yZGVyLXJpZ2h0OjFweCBzb2xpZCB2YXIoLS1ib3JkZXIpO2JhY2tncm91bmQ6IzEyMTgxZn0ucGFuZWwtaGVhZGluZ3toZWlnaHQ6NDNweDtmbGV4LXNocmluazowO2Rpc3BsYXk6ZmxleDtqdXN0aWZ5LWNvbnRlbnQ6c3BhY2UtYmV0d2VlbjthbGlnbi1pdGVtczpjZW50ZXI7cGFkZGluZzo4cHggMTZweDtib3JkZXItYm90dG9tOjFweCBzb2xpZCB2YXIoLS1ib3JkZXIpO2NvbG9yOnZhcigtLWRpbSk7Zm9udC1zaXplOjEwcHg7bGV0dGVyLXNwYWNpbmc6MXB4fS5wYW5lbC1oZWFkaW5nPmxhYmVse2Rpc3BsYXk6ZmxleDthbGlnbi1pdGVtczpjZW50ZXI7Z2FwOjEycHg7bWluLXdpZHRoOjB9LnBhbmVsLWhlYWRpbmcgaW5wdXR7YmFja2dyb3VuZDpub25lO2JvcmRlcjowO3BhZGRpbmc6NHB4O2NvbG9yOnZhcigtLXRleHQpO2xldHRlci1zcGFjaW5nOjA7d2lkdGg6MjAwcHg7Zm9udC1zaXplOjEycHh9LnBhbmVsLWhlYWRpbmcgYnV0dG9ue3BhZGRpbmc6MnB4IDhweH0uZmlsZWJhcntkaXNwbGF5OmZsZXg7Z2FwOjEwcHg7YWxpZ24taXRlbXM6Y2VudGVyO3BhZGRpbmc6OXB4IDE0cHg7Ym9yZGVyLWJvdHRvbToxcHggc29saWQgdmFyKC0tYm9yZGVyKX1zZWxlY3QsaW5wdXRbdHlwZT10ZXh0XSxpbnB1dFt0eXBlPXVybF17YmFja2dyb3VuZDp2YXIoLS1iZyk7Ym9yZGVyOjFweCBzb2xpZCB2YXIoLS1ib3JkZXIpO2JvcmRlci1yYWRpdXM6NHB4O3BhZGRpbmc6N3B4O21pbi13aWR0aDowfSNmaWxle2ZsZXg6MX0uZW50cnktbGFiZWx7Zm9udC1zaXplOjEwcHg7Y29sb3I6dmFyKC0tZGltKTtkaXNwbGF5OmZsZXg7YWxpZ24taXRlbXM6Y2VudGVyO2dhcDo3cHh9LmVudHJ5LWxhYmVsIHNlbGVjdHtmb250LXNpemU6MTFweDttYXgtd2lkdGg6MTgwcHh9LmVkaXRvci13cmFwe2ZsZXg6MTttaW4taGVpZ2h0OjA7ZGlzcGxheTpmbGV4O292ZXJmbG93OmhpZGRlbjtwYWRkaW5nLXRvcDoxN3B4fSNsaW5lLW51bWJlcnN7Y29sb3I6IzRlNjA3Mjt0ZXh0LWFsaWduOnJpZ2h0O3VzZXItc2VsZWN0Om5vbmU7bWFyZ2luOjA7bGluZS1oZWlnaHQ6MS43O3BhZGRpbmc6MCAxMnB4O3dpZHRoOjQ4cHg7b3ZlcmZsb3c6aGlkZGVuO2ZvbnQtc2l6ZToxM3B4fSNlZGl0b3J7ZmxleDoxO3Jlc2l6ZTpub25lO2JvcmRlcjowO2JhY2tncm91bmQ6dHJhbnNwYXJlbnQ7b3V0bGluZTpub25lO3BhZGRpbmc6MCAxOHB4IDI0cHggM3B4O2xpbmUtaGVpZ2h0OjEuNzt0YWItc2l6ZToyO2NvbG9yOiNjNmUwZGI7Zm9udC1zaXplOjEzcHg7d2hpdGUtc3BhY2U6cHJlO292ZXJmbG93OmF1dG99LmVkaXRvci1mb290ZXJ7ZGlzcGxheTpmbGV4O2p1c3RpZnktY29udGVudDpzcGFjZS1iZXR3ZWVuO2dhcDoxMHB4O2JvcmRlci10b3A6MXB4IHNvbGlkIHZhcigtLWJvcmRlcik7cGFkZGluZzo4cHggMTRweDtmb250LXNpemU6MTBweDtjb2xvcjp2YXIoLS1kaW0pfS5zY29yZS1zY3JvbGx7ZmxleDoxO292ZXJmbG93OmF1dG87bWluLWhlaWdodDoxNTBweDtwb3NpdGlvbjpyZWxhdGl2ZX0udHJhY2tze3BhZGRpbmc6MCAxNnB4fS50cmFja3twYWRkaW5nOjEzcHggMCAxMHB4O2JvcmRlci1ib3R0b206MXB4IHNvbGlkIHZhcigtLWJvcmRlcil9LnRyYWNrLWhlYWR7ZGlzcGxheTpmbGV4O2dhcDoxMHB4O2FsaWduLWl0ZW1zOmNlbnRlcjttYXJnaW4tYm90dG9tOjhweDtmb250LXNpemU6MTJweH0udHJhY2staGVhZCAudHJhY2staWR7b3ZlcmZsb3c6aGlkZGVuO3RleHQtb3ZlcmZsb3c6ZWxsaXBzaXM7d2hpdGUtc3BhY2U6bm93cmFwfS50cmFjay1oZWFkIGJ1dHRvbntmb250LXNpemU6MTBweDtwYWRkaW5nOjNweCA4cHg7bWFyZ2luLWxlZnQ6YXV0b30udHJhY2staGVhZCBidXR0b25bYXJpYS1wcmVzc2VkPXRydWVde2NvbG9yOnZhcigtLWFjY2VudCk7Ym9yZGVyLWNvbG9yOnZhcigtLWFjY2VudCl9LnRyYWNrLWhlYWQgLm5vdGUtY291bnR7Zm9udC1zaXplOjEwcHg7Y29sb3I6dmFyKC0tZGltKX1jYW52YXN7ZGlzcGxheTpibG9jazt3aWR0aDoxMDAlO2hlaWdodDo4MnB4O2JvcmRlcjoxcHggc29saWQgIzIyMmYzYTtib3JkZXItcmFkaXVzOjRweDtiYWNrZ3JvdW5kOiMxMDE3MWV9I2VtcHR5LXNjb3Jle2NvbG9yOnZhcigtLWRpbSk7cGFkZGluZzo2NXB4IDI0cHg7dGV4dC1hbGlnbjpjZW50ZXI7Zm9udC1zaXplOjEycHh9LmNvbnNvbGV7aGVpZ2h0OjE5MHB4O2ZsZXgtc2hyaW5rOjA7Ym9yZGVyLXRvcDoxcHggc29saWQgdmFyKC0tYm9yZGVyKX0uY29uc29sZSBwcmV7d2hpdGUtc3BhY2U6cHJlLXdyYXA7d29yZC1icmVhazpicmVhay13b3JkO21hcmdpbjowO3BhZGRpbmc6MTRweCAxNnB4O2xpbmUtaGVpZ2h0OjEuNjU7Zm9udC1zaXplOjExcHg7aGVpZ2h0OjE0MHB4O292ZXJmbG93OmF1dG87Y29sb3I6I2E4YmFjYn0uY29uc29sZSBwcmUuZXJyb3J7Y29sb3I6dmFyKC0tcmVkKX1mb290ZXJ7ZGlzcGxheTpmbGV4O2p1c3RpZnktY29udGVudDpzcGFjZS1iZXR3ZWVuO2FsaWduLWl0ZW1zOmNlbnRlcjtnYXA6MTBweDtib3JkZXItdG9wOjFweCBzb2xpZCB2YXIoLS1ib3JkZXIpO3BhZGRpbmc6OXB4IDIwcHg7Zm9udC1zaXplOjEwcHg7Y29sb3I6dmFyKC0tZGltKX1he2NvbG9yOnZhcigtLWFjY2VudCk7dGV4dC1kZWNvcmF0aW9uOm5vbmV9YTpob3Zlcnt0ZXh0LWRlY29yYXRpb246dW5kZXJsaW5lfS5kb3R7d2lkdGg6NnB4O2hlaWdodDo2cHg7YmFja2dyb3VuZDp2YXIoLS1hY2NlbnQpO2JvcmRlci1yYWRpdXM6NTAlO2Rpc3BsYXk6aW5saW5lLWJsb2NrO21hcmdpbi1yaWdodDo0cHh9ZGlhbG9ne3dpZHRoOm1pbig2MjBweCxjYWxjKDEwMCUgLSAzMHB4KSk7bWF4LWhlaWdodDo4NWR2aDtiYWNrZ3JvdW5kOnZhcigtLXBhbmVsKTtjb2xvcjp2YXIoLS10ZXh0KTtib3JkZXI6MXB4IHNvbGlkICM0NjU2NjM7Ym94LXNoYWRvdzowIDI1cHggODBweCAjMDAwOTtib3JkZXItcmFkaXVzOjlweDtwYWRkaW5nOjIycHh9ZGlhbG9nOjpiYWNrZHJvcHtiYWNrZ3JvdW5kOiMwMjA3MGJiYjtiYWNrZHJvcC1maWx0ZXI6Ymx1cigzcHgpfS5kaWFsb2ctaGVhZGluZ3tkaXNwbGF5OmZsZXg7anVzdGlmeS1jb250ZW50OnNwYWNlLWJldHdlZW47YWxpZ24taXRlbXM6Y2VudGVyO21hcmdpbi1ib3R0b206MjBweH1oMntmb250LXNpemU6MTdweDtmb250LXdlaWdodDo1MDA7bWFyZ2luOjB9LmNsb3Nle3BhZGRpbmc6M3B4IDlweDtmb250LXNpemU6MjBweDtiYWNrZ3JvdW5kOm5vbmV9ZGlhbG9nIGxhYmVse2Rpc3BsYXk6ZmxleDtmbGV4LWRpcmVjdGlvbjpjb2x1bW47Z2FwOjlweDtmb250LXNpemU6MTFweDtjb2xvcjp2YXIoLS1kaW0pO21hcmdpbjoxOHB4IDB9ZGlhbG9nIGlucHV0e3dpZHRoOjEwMCV9ZGlhbG9nIHB7Y29sb3I6dmFyKC0tZGltKTtmb250LXNpemU6MTFweDtsaW5lLWhlaWdodDoxLjd9ZGlhbG9nIHRleHRhcmVhe3dpZHRoOjEwMCU7cmVzaXplOnZlcnRpY2FsO2JhY2tncm91bmQ6dmFyKC0tYmcpO2JvcmRlcjoxcHggc29saWQgdmFyKC0tYm9yZGVyKTtib3JkZXItcmFkaXVzOjRweDtwYWRkaW5nOjEwcHg7Zm9udC1zaXplOjExcHg7d29yZC1icmVhazpicmVhay1hbGx9LmRpYWxvZy1hY3Rpb25ze2Rpc3BsYXk6ZmxleDtnYXA6OHB4O21hcmdpbjoxOHB4IDA7ZmxleC13cmFwOndyYXB9LnJlZmVyZW5jZS1kaWFsb2d7d2lkdGg6bWluKDkyMHB4LGNhbGMoMTAwJSAtIDMwcHgpKX0jbGlicmFyeXt3aWR0aDoxMDAlfSNsaWJyYXJ5LXNvdXJjZXtmb250LXNpemU6MTFweDtsaW5lLWhlaWdodDoxLjY1O3doaXRlLXNwYWNlOnByZTtvdmVyZmxvdzphdXRvO21heC1oZWlnaHQ6NDVkdmg7cGFkZGluZzoxNnB4O2JhY2tncm91bmQ6dmFyKC0tYmcpO2JvcmRlcjoxcHggc29saWQgdmFyKC0tYm9yZGVyKX1baGlkZGVuXXtkaXNwbGF5Om5vbmUhaW1wb3J0YW50fWJvZHkuZHJhZ2dpbmd7b3V0bGluZTozcHggZGFzaGVkIHZhcigtLWFjY2VudCk7b3V0bGluZS1vZmZzZXQ6LTVweH1AbWVkaWEobWF4LXdpZHRoOjEwMDBweCl7LnRhZ3tkaXNwbGF5Om5vbmV9LnRvcGJhcntwYWRkaW5nOjEycHggMTRweH0uYnJhbmQ+LnRhZ3tkaXNwbGF5Om5vbmV9bmF2e2ZsZXgtd3JhcDp3cmFwfS50cmFuc3BvcnR7cGFkZGluZzoxMHB4IDE0cHh9LnZvbHVtZXtkaXNwbGF5Om5vbmV9LnRpbWV7bWFyZ2luOjAgNHB4fWZvb3RlciAjbGluay1zdGF0ZXtkaXNwbGF5Om5vbmV9fUBtZWRpYShtYXgtd2lkdGg6NzYwcHgpe2JvZHl7aGVpZ2h0OmF1dG87bWluLWhlaWdodDoxMDBkdmh9LnRvcGJhcntoZWlnaHQ6YXV0bzthbGlnbi1pdGVtczpmbGV4LXN0YXJ0O2ZsZXgtZGlyZWN0aW9uOmNvbHVtbjtnYXA6MTJweH1uYXZ7d2lkdGg6MTAwJX1uYXYgYnV0dG9ue2ZsZXg6MTtwYWRkaW5nOjdweH0udHJhbnNwb3J0e2dhcDo2cHh9bWFpbntkaXNwbGF5OmZsZXg7ZmxleC1kaXJlY3Rpb246Y29sdW1uO21pbi1oZWlnaHQ6MH0uZWRpdG9yLXBhbmVse2hlaWdodDo1NmR2aDttaW4taGVpZ2h0OjMzMHB4O2JvcmRlci1yaWdodDowO2JvcmRlci1ib3R0b206MXB4IHNvbGlkIHZhcigtLWJvcmRlcil9Lm91dHB1dC1wYW5lbHttaW4taGVpZ2h0OjQwMHB4fS5zY29yZS1zY3JvbGx7bWluLWhlaWdodDoyMjBweDttYXgtaGVpZ2h0OjQwMHB4fWZvb3RlcntmbGV4LXdyYXA6d3JhcDtsaW5lLWhlaWdodDoxLjV9LmVudHJ5LWxhYmVsIHNlbGVjdHttYXgtd2lkdGg6MTMwcHh9fQo=#src%2Fapp%2Fassets%2Fstyle.css" ]
        ]
        body [] [
            header [ _class "topbar" ] [
                div [ _class "brand" ] [
                    span [ _class "mark"; attr "aria-hidden" "true" ] [
                        str "m"
                        span [] [
                            str "∿"
                        ]
                    ]
                    strong [] [
                        str "muzstatic"
                    ]
                    span [ _class "tag" ] [
                        str "web workspace"
                    ]
                ]
                nav [ attr "aria-label" "Project actions" ] [
                    button [ _id "new" ] [
                        str "New"
                    ]
                    button [ _id "open-link" ] [
                        str "Open link"
                    ]
                    button [ _id "open-files" ] [
                        str "Files"
                    ]
                    button [ _id "open-folder" ] [
                        str "Folder"
                    ]
                    button [ _id "share"; _class "accent" ] [
                        str "Share"
                    ]
                    button [ _id "reference" ] [
                        str "Reference"
                    ]
                ]
            ]
            section [ _class "transport"; attr "aria-label" "Playback" ] [
                button [ _id "play"; _class "primary"; attr "title" "Play / pause (Ctrl+Enter)" ] [
                    str "▶ Play"
                ]
                button [ _id "stop"; attr "title" "Stop and return to start" ] [
                    str "■"
                ]
                button [ _id "compile"; attr "title" "Compile (Ctrl+S)" ] [
                    str "Compile"
                ]
                div [ _class "time" ] [
                    output [ _id "position" ] [
                        str "0:00.0"
                    ]
                    span [] [
                        str "/"
                    ]
                    output [ _id "duration" ] [
                        str "—"
                    ]
                ]
                span [ _id "tempo"; _class "tag" ] [
                    str "— BPM"
                ]
                label [ _class "volume" ] [
                    str "Vol"
                    input [ _id "volume"; _type "range"; attr "min" "0"; attr "max" "100"; attr "value" "70"; attr "aria-label" "Volume" ]
                ]
                div [ _class "spacer" ] []
                button [ _id "export-midi" ] [
                    str "MIDI ↓"
                ]
                button [ _id "export-wav" ] [
                    str "WAV ↓"
                ]
                button [ _id "save-project" ] [
                    str "Project ↓"
                ]
            ]
            main [] [
                section [ _class "editor-panel"; attr "aria-label" "Source editor" ] [
                    div [ _class "panel-heading" ] [
                        label [] [
                            str "PROJECT"
                            input [ _id "project-title"; attr "aria-label" "Project title"; attr "value" "Untitled" ]
                        ]
                        div [] [
                            button [ _id "add-file"; attr "title" "Add a source file" ] [
                                str "+"
                            ]
                            button [ _id "remove-file"; attr "title" "Remove selected file" ] [
                                str "−"
                            ]
                        ]
                    ]
                    div [ _class "filebar" ] [
                        select [ _id "file"; attr "aria-label" "Selected source file" ] []
                        label [ _class "entry-label" ] [
                            str "entry"
                            select [ _id "entry"; attr "aria-label" "Entry file" ] []
                        ]
                    ]
                    div [ _class "editor-wrap" ] [
                        pre [ _id "line-numbers"; attr "aria-hidden" "true" ] [
                            str "1"
                        ]
                        tag "textarea" [ _id "editor"; attr "aria-label" "Muz source"; attr "spellcheck" "false"; attr "autocapitalize" "off"; attr "autocomplete" "off"; attr "autocorrect" "off"; attr "wrap" "off" ] []
                    ]
                    div [ _class "editor-footer" ] [
                        span [ _id "file-info" ] [
                            str "UTF-8"
                        ]
                        span [] [
                            str "Ctrl+S compile · Ctrl+Enter play"
                        ]
                    ]
                ]
                section [ _class "output-panel"; attr "aria-label" "Compiled music" ] [
                    div [ _class "panel-heading" ] [
                        span [] [
                            str "SCORE"
                        ]
                        span [ _id "score-info"; _class "tag" ] [
                            str "Not compiled"
                        ]
                    ]
                    div [ _class "score-scroll" ] [
                        div [ _id "tracks"; _class "tracks" ] []
                        div [ _id "empty-score" ] [
                            str "Compile a .muz file to view its score."
                        ]
                    ]
                    section [ _class "console"; attr "aria-label" "Compiler output" ] [
                        div [ _class "panel-heading" ] [
                            span [] [
                                str "OUTPUT"
                            ]
                            button [ _id "cancel"; attr "hidden" "" ] [
                                str "Cancel"
                            ]
                        ]
                        pre [ _id "messages"; attr "role" "status"; attr "aria-live" "polite" ] [
                            str "Ready."
                        ]
                    ]
                ]
            ]
            footer [] [
                span [] [
                    span [ _class "dot" ] []
                    span [ _id "status" ] [
                        str "Local workspace"
                    ]
                ]
                span [ _id "link-state" ] [
                    str "Embedded links use ln.kr v4"
                ]
                a [ _href "../index.html"; attr "target" "_blank"; attr "rel" "noreferrer" ] [
                    str "Source"
                ]
                a [ _href "https://github.com/apage43/muz"; attr "target" "_blank"; attr "rel" "noreferrer" ] [
                    str "muz engine ↗"
                    span [ _id "engine-version" ] []
                ]
            ]
            dialog [ _id "link-dialog" ] [
                form [ _id "link-form" ] [
                    div [ _class "dialog-heading" ] [
                        h2 [] [
                            str "Open a project"
                        ]
                        button [ _type "button"; _class "close"; attr "aria-label" "Close" ] [
                            str "×"
                        ]
                    ]
                    label [] [
                        str "Raw URL, ln.kr link, fragment, or gist"
                        input [ _id "link-input"; _type "text"; attr "placeholder" "https://… / #s:… / #ss:…"; attr "required" ""; attr "autocomplete" "off" ]
                    ]
                    p [] [
                        str "Public sources must allow browser CORS. Links import data only; playback starts when you press Play."
                    ]
                    div [ _class "dialog-actions" ] [
                        button [ _type "submit"; _class "primary" ] [
                            str "Open"
                        ]
                    ]
                ]
            ]
            dialog [ _id "share-dialog" ] [
                div [ _class "dialog-heading" ] [
                    h2 [] [
                        str "Share project"
                    ]
                    button [ _class "close"; attr "aria-label" "Close" ] [
                        str "×"
                    ]
                ]
                p [] [
                    str "Embedded includes the project files and assets. Source links point to a raw .muz or project JSON. Superlinks point to a one-line link document."
                ]
                label [] [
                    str "Source or pointer URL (optional)"
                    input [ _id "source-input"; _type "url"; attr "placeholder" "https://…" ]
                ]
                div [ _class "dialog-actions" ] [
                    button [ _id "share-embedded"; _class "primary" ] [
                        str "Copy embedded"
                    ]
                    button [ _id "share-source" ] [
                        str "Copy source link"
                    ]
                    button [ _id "share-super" ] [
                        str "Copy superlink"
                    ]
                ]
                label [] [
                    str "Share URL"
                    tag "textarea" [ _id "share-output"; attr "readonly" ""; attr "rows" "4"; attr "aria-label" "Share URL" ] []
                ]
                p [ _id "share-status"; attr "role" "status" ] []
            ]
            dialog [ _id "reference-dialog"; _class "reference-dialog" ] [
                div [ _class "dialog-heading" ] [
                    h2 [] [
                        str "Reference"
                    ]
                    button [ _class "close"; attr "aria-label" "Close" ] [
                        str "×"
                    ]
                ]
                p [] [
                    str "The bundled standard library is the engine’s own source. Copy code into your project, or import its module name without the .muz suffix."
                ]
                select [ _id "library"; attr "aria-label" "Standard library module" ] []
                pre [ _id "library-source" ] []
                p [] [
                    str "WAV/FLAC samples, MIDI, and SFZ can be imported with a project folder. Native VST3/CLAP hosts and DAWProject compilation remain in the desktop engine."
                ]
                a [ _href "https://github.com/apage43/muz/blob/main/docs/language.md"; attr "target" "_blank"; attr "rel" "noreferrer" ] [
                    str "Full muz language reference ↗"
                ]
                p [ _id "provenance" ] []
            ]
            input [ _id "file-input"; _type "file"; attr "multiple" ""; attr "hidden" "" ]
            input [ _id "folder-input"; _type "file"; attr "webkitdirectory" ""; attr "multiple" ""; attr "hidden" "" ]
            script [ _type "module" ] [
                    rawText ("""// \0vitality-assets
var e = { "src/app/assets/player-worklet.js": "dmFyIGU9Y2xhc3MgZXh0ZW5kcyBBdWRpb1dvcmtsZXRQcm9jZXNzb3J7Y29uc3RydWN0b3IoKXtzdXBlcigpLHRoaXMucXVldWU9W10sdGhpcy5vZmZzZXQ9MCx0aGlzLnBsYXlpbmc9ITEsdGhpcy5mcmFtZT0wLHRoaXMucmVwb3J0PTAsdGhpcy53YWl0aW5nPSExLHRoaXMuZG9uZT0hMSx0aGlzLnBvcnQub25tZXNzYWdlPSh7ZGF0YTplfSk9PntlLnR5cGU9PT1gY2h1bmtgJiYodGhpcy5xdWV1ZS5wdXNoKGUucGNtKSx0aGlzLndhaXRpbmc9ITEsdGhpcy5kb25lPWUuZG9uZSksZS50eXBlPT09YHBsYXlgJiYodGhpcy5wbGF5aW5nPSEwKSxlLnR5cGU9PT1gcGF1c2VgJiYodGhpcy5wbGF5aW5nPSExKSxlLnR5cGU9PT1gcmV0cnlgJiYodGhpcy53YWl0aW5nPSExKSxlLnR5cGU9PT1gY2xlYXJgJiYodGhpcy5xdWV1ZT1bXSx0aGlzLm9mZnNldD0wLHRoaXMuZnJhbWU9MCx0aGlzLndhaXRpbmc9ITEsdGhpcy5kb25lPSExLHRoaXMucGxheWluZz0hMSl9fXByb2Nlc3MoZSx0KXtsZXRbbixyXT10WzBdO2lmKCFuKXJldHVybiEwO2lmKHRoaXMucGxheWluZylmb3IobGV0IGU9MDtlPG4ubGVuZ3RoO2UrKyl7Zm9yKDt0aGlzLnF1ZXVlLmxlbmd0aCYmdGhpcy5vZmZzZXQ+PXRoaXMucXVldWVbMF0ubGVuZ3RoOyl0aGlzLnF1ZXVlLnNoaWZ0KCksdGhpcy5vZmZzZXQ9MDtpZighdGhpcy5xdWV1ZS5sZW5ndGgpYnJlYWs7bltlXT10aGlzLnF1ZXVlWzBdW3RoaXMub2Zmc2V0KytdLHJbZV09dGhpcy5xdWV1ZVswXVt0aGlzLm9mZnNldCsrXSx0aGlzLmZyYW1lKyt9bGV0IGk9dGhpcy5xdWV1ZS5yZWR1Y2UoKGUsdCk9PmUrdC5sZW5ndGgvMiwwKS10aGlzLm9mZnNldC8yO3JldHVybiB0aGlzLnBsYXlpbmcmJmk8c2FtcGxlUmF0ZSouNCYmIXRoaXMud2FpdGluZyYmIXRoaXMuZG9uZSYmKHRoaXMud2FpdGluZz0hMCx0aGlzLnBvcnQucG9zdE1lc3NhZ2Uoe3R5cGU6YG5lZWRgfSkpLHRoaXMucGxheWluZyYmdGhpcy5kb25lJiZpPD0wJiYodGhpcy5wbGF5aW5nPSExLHRoaXMucG9ydC5wb3N0TWVzc2FnZSh7dHlwZTpgZW5kZWRgfSkpLCsrdGhpcy5yZXBvcnQ+PTIwJiZ0aGlzLnBsYXlpbmcmJih0aGlzLnJlcG9ydD0wLHRoaXMucG9ydC5wb3N0TWVzc2FnZSh7dHlwZTpgcG9zaXRpb25gLGZyYW1lOnRoaXMuZnJhbWV9KSksITB9fTtyZWdpc3RlclByb2Nlc3NvcihgbXV6c3RhdGljLXBsYXllcmAsZSk7" }, t = {
	"src/app/assets/muz.wasm": "/muz/assets/muz-083b8f545e7df862.wasm",
	"src/app/assets/library.json": "data:application/json;base64,W3sibmFtZSI6InN0ZC9hcnJhbmdlLm11eiIsInNvdXJjZSI6Ii8vIEFycmFuZ2VtZW50IHZhbHVlcyBhcmUgb3JkaW5hcnkgcmVjb3Jkcy4gSW5zdHJ1bWVudHMgYW5kIHJvdXRpbmcgYmVsb25nIHRvXHJcbi8vIHRoZSBzb25nJ3MgcGVyc2lzdGVudCB0cmFja3M7IGEgcGFzc2FnZSBvbmx5IGNhcnJpZXMgbWF0ZXJpYWwgYW5kIGdlc3R1cmVzLlxyXG5mbiBtZWFzdXJlcyhjb3VudCwgbWV0ZXIgPSBbNCwgNF0pIHtcclxuICAgIGFzc2VydChsZW4obWV0ZXIpID09IDIsIFwibWV0ZXIgbmVlZHMgbnVtZXJhdG9yIGFuZCBkZW5vbWluYXRvclwiKTtcclxuICAgIGFzc2VydChcclxuICAgICAgICB1bml0KGNvdW50KSA9PSAxICYmIGNvdW50ID49IDBcclxuICAgICAgICAmJiB1bml0KG1ldGVyWzBdKSA9PSAxICYmIGZsb29yKG1ldGVyWzBdKSA9PSBtZXRlclswXVxyXG4gICAgICAgICYmIG1ldGVyWzBdID4gMCAmJiBtZXRlclswXSA8PSAyNTVcclxuICAgICAgICAmJiBjb250YWlucyhbMSwgMiwgNCwgOCwgMTYsIDMyLCA2NCwgMTI4XSwgbWV0ZXJbMV0pLFxyXG4gICAgICAgIFwibWVhc3VyZXMgbmVlZHMgYSBub25uZWdhdGl2ZSBzY2FsYXIgY291bnQgYW5kIGFuIGludGVncmFsIHZhbGlkIG1ldGVyXCJcclxuICAgICk7XHJcbiAgICBjb3VudCAqIG1ldGVyWzBdICogNGIgLyBtZXRlclsxXVxyXG59XHJcbmZuIGJhcnMoY291bnQsIG1ldGVyID0gWzQsIDRdKSA9IG1lYXN1cmVzKGNvdW50LCBtZXRlcik7XHJcblxyXG5mbiBwYXNzYWdlKHNwYW4sIHBhcnRzID0gW10sIGdlc3R1cmVzID0gW10sIHRlbXBvcyA9IFtdKSB7XHJcbiAgICBhc3NlcnQoc3BhbiA+IDBiLCBcInBhc3NhZ2Ugc3BhbiBtdXN0IGJlIHBvc2l0aXZlXCIpO1xyXG4gICAge3NwYW46IHNwYW4sIHBhcnRzOiBwYXJ0cywgZ2VzdHVyZXM6IGdlc3R1cmVzLCB0ZW1wb3M6IHRlbXBvcywgY29udHJhY3RzOiBbXX1cclxufVxyXG5mbiBwYXJ0KGlkLCBwYXR0ZXJuKSA9IHtpZDogaWQsIHBhdHRlcm46IHBhdHRlcm59O1xyXG5mbiBvY2N1cnJlbmNlKG5hbWUsIG1hdGVyaWFsKSA9IG1lcmdlKG1hdGVyaWFsLCB7bmFtZTogbmFtZX0pO1xyXG5cclxuZm4gc2VxdWVuY2UoaXRlbXMpID0gZm9sZChcclxuICAgIGl0ZW1zLFxyXG4gICAge3NwYW46IDBiLCBwbGFjZW1lbnRzOiBbXSwgbmFtZXM6IFtdfSxcclxuICAgIGZuKHN0YXRlLCBpdGVtKSA9PiB7XHJcbiAgICAgICAgYXNzZXJ0KFxyXG4gICAgICAgICAgICAhY29udGFpbnMoc3RhdGUubmFtZXMsIGl0ZW0ubmFtZSksXHJcbiAgICAgICAgICAgIFwiZHVwbGljYXRlIGFycmFuZ2VtZW50IG9jY3VycmVuY2U6IFwiICsgaXRlbS5uYW1lXHJcbiAgICAgICAgKTtcclxuICAgICAgICB7XHJcbiAgICAgICAgICAgIHNwYW46IHN0YXRlLnNwYW4gKyBpdGVtLnNwYW4sXHJcbiAgICAgICAgICAgIG5hbWVzOiBzdGF0ZS5uYW1lcyArIFtpdGVtLm5hbWVdLFxyXG4gICAgICAgICAgICBwbGFjZW1lbnRzOiBzdGF0ZS5wbGFjZW1lbnRzICsgW21lcmdlKGl0ZW0sIHtzdGFydDogc3RhdGUuc3Bhbn0pXVxyXG4gICAgICAgIH1cclxuICAgIH1cclxuKTtcclxuXHJcbi8vIENoYW5nZXMgb25seSB0aGUgcmVxdWVzdGVkIHBhcnQgb2YgdGhpcyBwYXNzYWdlIHZhbHVlLiBUaGUgc2hhcmVkIGlucHV0IHN0YXlzXHJcbi8vIGF2YWlsYWJsZSBmb3IgdGhlIG90aGVyIG9jY3VycmVuY2VzLiBNdWx0aXBsZSBsYXllcnMgd2l0aCB0aGUgc2FtZSBpZCBhcmUgdmFsaWQuXHJcbmZuIGVkaXQobWF0ZXJpYWwsIGlkLCB0cmFuc2Zvcm0pIHtcclxuICAgIGFzc2VydChsZW4oZmlsdGVyKG1hdGVyaWFsLnBhcnRzLCBmbihwKSA9PiBwLmlkID09IGlkKSkgPiAwLCBcInBhc3NhZ2UgaGFzIG5vIHBhcnQ6IFwiICsgaWQpO1xyXG4gICAgbWVyZ2UobWF0ZXJpYWwsIHtcclxuICAgICAgICBwYXJ0czogbWFwKG1hdGVyaWFsLnBhcnRzLCBmbihwKSA9PiBpZiBwLmlkID09IGlkIHtcclxuICAgICAgICAgICAgbWVyZ2UocCwge3BhdHRlcm46IHRyYW5zZm9ybShwLnBhdHRlcm4pfSlcclxuICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICBwXHJcbiAgICAgICAgfSlcclxuICAgIH0pXHJcbn1cclxuZm4gcmVxdWlyZShwYXR0ZXJuLCBzZWxlY3RvciwgY291bnQgPSAxKSB7XHJcbiAgICBhc3NlcnQoXHJcbiAgICAgICAgbGVuKHBhdHRlcm4uc2VsZWN0KHNlbGVjdG9yKSkgPT0gY291bnQsXHJcbiAgICAgICAgXCJwaW5uZWQgc2VsZWN0aW9uIGRpZCBub3QgbWF0Y2ggdGhlIGV4cGVjdGVkIG51bWJlciBvZiBub3Rlc1wiXHJcbiAgICApO1xyXG4gICAgcGF0dGVyblxyXG59XHJcblxyXG4vLyBMb2dpY2FsIGNvbnRyYWN0cyBpbmNsdWRlIHRyYWlsaW5nIHJlc3RzIGFuZCBkbyBub3QgaW5zcGVjdCBwZXJmb3JtZWQgdGltZS5cclxuZm4gcmVxdWlyZV9zcGFuKHBhdHRlcm4sIGV4cGVjdGVkKSB7XHJcbiAgICBhc3NlcnQoKHVuaXQoZXhwZWN0ZWQpID09IDFiIHx8IHVuaXQoZXhwZWN0ZWQpID09IDFiYXIpICYmIGV4cGVjdGVkID49IDBiLCBcImV4cGVjdGVkIHNwYW4gbXVzdCBiZSBhIG5vbm5lZ2F0aXZlIGJlYXQgZHVyYXRpb25cIik7XHJcbiAgICBhc3NlcnQocGF0dGVybi5zcGFuID09IGV4cGVjdGVkLCBcInBhdHRlcm4gZG9lcyBub3QgaGF2ZSB0aGUgcmVxdWlyZWQgc3BhblwiKTtcclxuICAgIHBhdHRlcm5cclxufVxyXG5mbiByZXF1aXJlX2ZpdChwYXR0ZXJuLCBsaW1pdCkge1xyXG4gICAgYXNzZXJ0KCh1bml0KGxpbWl0KSA9PSAxYiB8fCB1bml0KGxpbWl0KSA9PSAxYmFyKSAmJiBsaW1pdCA+PSAwYiwgXCJzcGFuIGxpbWl0IG11c3QgYmUgYSBub25uZWdhdGl2ZSBiZWF0IGR1cmF0aW9uXCIpO1xyXG4gICAgYXNzZXJ0KHBhdHRlcm4uc3BhbiA8PSBsaW1pdCwgXCJwYXR0ZXJuIGV4Y2VlZHMgdGhlIHNwYW4gbGltaXRcIik7XHJcbiAgICBwYXR0ZXJuXHJcbn1cclxuXHJcbmZuIGNvbnRhaW5lZF9zdGFydChzdGFydCwgYmVnaW4sIGVuZCwgcGlja3VwcywgbGFiZWwsIGtpbmQpIHtcclxuICAgIGFzc2VydChwaWNrdXBzIHx8IHN0YXJ0ID49IGJlZ2luLCBsYWJlbCArIGtpbmQgKyBcIiBwaWNrdXAgY3Jvc3NlcyBwYXNzYWdlIHN0YXJ0XCIpO1xyXG4gICAgYXNzZXJ0KHN0YXJ0IDwgZW5kLCBsYWJlbCArIGtpbmQgKyBcIiBzdGFydCByZWFjaGVzIG9yIGNyb3NzZXMgcGFzc2FnZSBlbmRcIilcclxufVxyXG5mbiByZXF1aXJlX2NvbnRhaW5lZChtYXRlcmlhbCwgcGlja3VwcyA9IGZhbHNlLCB0YWlscyA9IGZhbHNlKSA9IG1lcmdlKG1hdGVyaWFsLCB7XHJcbiAgICBjb250cmFjdHM6IG1hdGVyaWFsLmNvbnRyYWN0cyArIFtmbihjKSA9PiB7XHJcbiAgICAgICAgbGV0IGJlZ2luID0gc2Vjb25kc19hdChjLnN0YXJ0LCBjLnRpbWluZyk7XHJcbiAgICAgICAgbGV0IGVuZCA9IHNlY29uZHNfYXQoYy5zdGFydCArIGMuc3BhbiwgYy50aW1pbmcpO1xyXG4gICAgICAgIG1hcChjLnBhcnRzLCBmbihwKSA9PiB7XHJcbiAgICAgICAgICAgIGxldCBsYWJlbCA9IFwib2NjdXJyZW5jZSBcIiArIGMubmFtZSArIFwiLCBwYXJ0IFwiICsgcC5pZCArIFwiOiBcIjtcclxuICAgICAgICAgICAgYXNzZXJ0KCFwLnBhdHRlcm4uaGFzX2Nsb2NrX3RpbWluZywgbGFiZWwgKyBcInVuc3VwcG9ydGVkIGNsb2NrIHRpbWluZyBpbiBjb250YWlubWVudCBjb250cmFjdFwiKTtcclxuICAgICAgICAgICAgbWFwKHAucGF0dGVybi5ub3RlcywgZm4obikgPT4ge1xyXG4gICAgICAgICAgICAgICAgbGV0IHN0YXJ0ID0gc2Vjb25kc19hdChuLmF0LCBjLnRpbWluZykgKyBuLm9mZnNldDtcclxuICAgICAgICAgICAgICAgIGxldCByZWxlYXNlID0gc2Vjb25kc19hdChuLmF0ICsgbi5kdXJhdGlvbiAqIG4uZ2F0ZSwgYy50aW1pbmcpXHJcbiAgICAgICAgICAgICAgICAgICAgKyBuLm9mZnNldCArIG4ucmVsZWFzZV9vZmZzZXQ7XHJcbiAgICAgICAgICAgICAgICBjb250YWluZWRfc3RhcnQoc3RhcnQsIGJlZ2luLCBlbmQsIHBpY2t1cHMsIGxhYmVsLCBcIm5vdGVcIik7XHJcbiAgICAgICAgICAgICAgICBhc3NlcnQodGFpbHMgfHwgcmVsZWFzZSA8PSBlbmQsIGxhYmVsICsgXCJub3RlIHJlbGVhc2UgY3Jvc3NlcyBwYXNzYWdlIGVuZFwiKVxyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICAgICAgbWFwKHAucGF0dGVybi5jb250cm9scywgZm4oZXZlbnQpID0+IGNvbnRhaW5lZF9zdGFydChcclxuICAgICAgICAgICAgICAgIHNlY29uZHNfYXQoZXZlbnQuYXQsIGMudGltaW5nKSArIGV2ZW50Lm9mZnNldCwgYmVnaW4sIGVuZCwgcGlja3VwcywgbGFiZWwsIFwiY29udHJvbFwiXHJcbiAgICAgICAgICAgICkpO1xyXG4gICAgICAgICAgICBtYXAocC5wYXR0ZXJuLnJhdywgZm4oZXZlbnQpID0+IGNvbnRhaW5lZF9zdGFydChcclxuICAgICAgICAgICAgICAgIHNlY29uZHNfYXQoZXZlbnQuYXQsIGMudGltaW5nKSArIGV2ZW50Lm9mZnNldCwgYmVnaW4sIGVuZCwgcGlja3VwcywgbGFiZWwsIFwicmF3IGV2ZW50XCJcclxuICAgICAgICAgICAgKSlcclxuICAgICAgICB9KVxyXG4gICAgfV1cclxufSk7XHJcblxyXG5mbiBwbGFjZWRfcGFydHMoaXRlbSkgPSBtYXAoXHJcbiAgICBpdGVtLnBhcnRzLFxyXG4gICAgZm4ocCkgPT4gcGFydChwLmlkLCBwLnBhdHRlcm4uYXQoaXRlbS5zdGFydCwga2V5ID0gaXRlbS5uYW1lKSlcclxuKTtcclxuZm4gY29sbGVjdChwYXJ0cywgaWQpID0gb3ZlcmxheShtYXAoZmlsdGVyKHBhcnRzLCBmbihwKSA9PiBwLmlkID09IGlkKSwgZm4ocCkgPT4gcC5wYXR0ZXJuKSk7XHJcbmZuIG1hdGVyaWFsKGNvbnRleHQsIGlkKSA9IGNvbGxlY3QoY29udGV4dC5wYXJ0cywgaWQpO1xyXG5mbiBmbGF0dGVuKGxpc3RzKSA9IGZvbGQobGlzdHMsIFtdLCBmbihvdXQsIGxpc3QpID0+IG91dCArIGxpc3QpO1xyXG5cclxuZm4gY29udGV4dChpdGVtLCB0aW1pbmcpID0ge1xyXG4gICAgbmFtZTogaXRlbS5uYW1lLFxyXG4gICAgc3RhcnQ6IGl0ZW0uc3RhcnQsXHJcbiAgICBzcGFuOiBpdGVtLnNwYW4sXHJcbiAgICBwYXJ0czogcGxhY2VkX3BhcnRzKGl0ZW0pLFxyXG4gICAgdGltaW5nOiB0aW1pbmdcclxufTtcclxuXHJcbi8vIE5lc3QgYW4gYWxyZWFkeSBhcnJhbmdlZCBjb2xsZWN0aW9uLiBlZGl0KCkgcHJlc2VydmVzIHBhcnQgc2xvdHMsIHNvIGNsb3N1cmVzXHJcbi8vIGNhbiBzZWxlY3QgZWFjaCBjaGlsZCdzIGxheWVycyBmcm9tIHRoZSBmaW5hbCBwYXJlbnQgY29udGV4dCBpbnN0ZWFkIG9mXHJcbi8vIHJldGFpbmluZyBwcmUtZWRpdCBwYXR0ZXJucy4gVGhlIHNlbGVjdGVkIHBhcnRzIGFyZSBhbHJlYWR5IGZ1bGx5IHBsYWNlZC5cclxuZm4gZ3JvdXAoYXJyYW5nZW1lbnQpID0gZm9sZChhcnJhbmdlbWVudC5wbGFjZW1lbnRzLCBwYXNzYWdlKGFycmFuZ2VtZW50LnNwYW4pLCBmbihcclxuICAgIHN0YXRlLFxyXG4gICAgaXRlbVxyXG4pID0+IHtcclxuICAgIGxldCBpbmRpY2VzID0gcmFuZ2UobGVuKHN0YXRlLnBhcnRzKSArIGxlbihpdGVtLnBhcnRzKSwgc3RhcnQgPSBsZW4oc3RhdGUucGFydHMpKTtcclxuICAgIG1lcmdlKHN0YXRlLCB7XHJcbiAgICAgICAgcGFydHM6IHN0YXRlLnBhcnRzICsgcGxhY2VkX3BhcnRzKGl0ZW0pLFxyXG4gICAgICAgIGdlc3R1cmVzOlxyXG4gICAgICAgICAgICBzdGF0ZS5nZXN0dXJlc1xyXG4gICAgICAgICAgICArIG1hcChcclxuICAgICAgICAgICAgICAgIGl0ZW0uZ2VzdHVyZXMsXHJcbiAgICAgICAgICAgICAgICBmbihnZXN0dXJlKSA9PiBmbihwYXJlbnQpID0+IGdlc3R1cmUoXHJcbiAgICAgICAgICAgICAgICAgICAgbWVyZ2UocGFyZW50LCB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgIHN0YXJ0OiBwYXJlbnQuc3RhcnQgKyBpdGVtLnN0YXJ0LFxyXG4gICAgICAgICAgICAgICAgICAgICAgICBuYW1lOiBwYXJlbnQubmFtZSArIFwiL1wiICsgaXRlbS5uYW1lLFxyXG4gICAgICAgICAgICAgICAgICAgICAgICBzcGFuOiBpdGVtLnNwYW4sXHJcbiAgICAgICAgICAgICAgICAgICAgICAgIHBhcnRzOiBtYXAoaW5kaWNlcywgZm4oaSkgPT4gcGFyZW50LnBhcnRzW2ldKVxyXG4gICAgICAgICAgICAgICAgICAgIH0pXHJcbiAgICAgICAgICAgICAgICApXHJcbiAgICAgICAgICAgICksXHJcbiAgICAgICAgY29udHJhY3RzOlxyXG4gICAgICAgICAgICBzdGF0ZS5jb250cmFjdHNcclxuICAgICAgICAgICAgKyBtYXAoXHJcbiAgICAgICAgICAgICAgICBpdGVtLmNvbnRyYWN0cyxcclxuICAgICAgICAgICAgICAgIGZuKGNvbnRyYWN0KSA9PiBmbihwYXJlbnQpID0+IGNvbnRyYWN0KFxyXG4gICAgICAgICAgICAgICAgICAgIG1lcmdlKHBhcmVudCwge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICBzdGFydDogcGFyZW50LnN0YXJ0ICsgaXRlbS5zdGFydCxcclxuICAgICAgICAgICAgICAgICAgICAgICAgbmFtZTogcGFyZW50Lm5hbWUgKyBcIi9cIiArIGl0ZW0ubmFtZSxcclxuICAgICAgICAgICAgICAgICAgICAgICAgc3BhbjogaXRlbS5zcGFuLFxyXG4gICAgICAgICAgICAgICAgICAgICAgICBwYXJ0czogbWFwKGluZGljZXMsIGZuKGkpID0+IHBhcmVudC5wYXJ0c1tpXSlcclxuICAgICAgICAgICAgICAgICAgICB9KVxyXG4gICAgICAgICAgICAgICAgKVxyXG4gICAgICAgICAgICApLFxyXG4gICAgICAgIHRlbXBvczogc3RhdGUudGVtcG9zICsgbWFwKGl0ZW0udGVtcG9zLCBmbihwb2ludCkgPT4gW2l0ZW0uc3RhcnQgKyBwb2ludFswXSwgcG9pbnRbMV1dKVxyXG4gICAgfSlcclxufSk7XHJcblxyXG4vLyBUd28gZXhwbGljaXQgdGltZSBkb21haW5zOiBiZWF0LXJlbGF0aXZlIGN1cnZlcyBtb3ZlIHdpdGggc2NvcmUgdGltZTsgY2xvY2tcclxuLy8gY3VydmVzIGtlZXAgdGhlaXIgc2Vjb25kcyBvZmZzZXRzIGV2ZW4gd2hlbiB0aGUgc3Vycm91bmRpbmcgdGVtcG8gY2hhbmdlcy5cclxuZm4gbG9jYWwodGFyZ2V0LCBwb2ludHMsIHNoYXBlID0gXCJsaW5lYXJcIikgPSBmbihjKSA9PiBbXHJcbiAgICBhdXRvbWF0aW9uKHRhcmdldCwgY3VydmUobWFwKHBvaW50cywgZm4ocG9pbnQpID0+IFtjLnN0YXJ0ICsgcG9pbnRbMF0sIHBvaW50WzFdXSksIHNoYXBlKSlcclxuXTtcclxuZm4gY2xvY2sodGFyZ2V0LCBwb2ludHMsIHNoYXBlID0gXCJsaW5lYXJcIikgPSBmbihjKSA9PiBbXHJcbiAgICBhdXRvbWF0aW9uKFxyXG4gICAgICAgIHRhcmdldCxcclxuICAgICAgICBjdXJ2ZShcclxuICAgICAgICAgICAgbWFwKHBvaW50cywgZm4ocG9pbnQpID0+IFtzZWNvbmRzX2F0KGMuc3RhcnQsIGMudGltaW5nKSArIHBvaW50WzBdLCBwb2ludFsxXV0pLFxyXG4gICAgICAgICAgICBzaGFwZVxyXG4gICAgICAgIClcclxuICAgIClcclxuXTtcclxuXHJcbi8vIE5vcm1hbGl6ZSBnZXN0dXJlIHBvc2l0aW9ucyB0byBzZWNvbmRzIG9ubHkgYWZ0ZXIgcGxhY2VtZW50LiBDb25jYXRlbmF0aW9uXHJcbi8vIHJlcXVpcmVzIGNvbXBhdGlibGUgZW5kcG9pbnRzOyBvdmVybGFwcyBuZWVkIGFuIGV4cGxpY2l0IGNvbXBvc2VyIGNvbWJpbmF0aW9uLlxyXG5mbiBhcHBlbmRfY3VydmUoc3RhdGUsIG5leHQpIHtcclxuICAgIGxldCBwb2ludHMgPSBuZXh0LmN1cnZlLnBvaW50cztcclxuICAgIGFzc2VydChzdGF0ZS5zaGFwZSA9PSBuZXh0LmN1cnZlLnNoYXBlLCBcImpvaW5pbmcgZ2VzdHVyZXMgcmVxdWlyZXMgdGhlIHNhbWUgY3VydmUgc2hhcGVcIik7XHJcbiAgICBsZXQgcHJldmlvdXMgPSBzdGF0ZS5wb2ludHNbLTFdO1xyXG4gICAgbGV0IGZpcnN0ID0gcG9pbnRzWzBdO1xyXG4gICAgYXNzZXJ0KHByZXZpb3VzWzBdIDw9IGZpcnN0WzBdLCBcIm92ZXJsYXBwaW5nIGF1dG9tYXRpb24gZ2VzdHVyZXMgbmVlZCBhbiBleHBsaWNpdCBjb21iaW5hdGlvblwiKTtcclxuICAgIGFzc2VydChcclxuICAgICAgICBzdGF0ZS5zaGFwZSA9PSBcInN0ZXBcIiB8fCBwcmV2aW91c1sxXSA9PSBmaXJzdFsxXSxcclxuICAgICAgICBcImNvbnRpbnVvdXMgZ2VzdHVyZSBlbmRwb2ludHMgZGlmZmVyOyBzdXBwbHkgYW4gZXhwbGljaXQgdHJhbnNpdGlvblwiXHJcbiAgICApO1xyXG4gICAgYXNzZXJ0KFxyXG4gICAgICAgIHByZXZpb3VzWzBdICE9IGZpcnN0WzBdIHx8IHByZXZpb3VzWzFdID09IGZpcnN0WzFdLFxyXG4gICAgICAgIFwiYXV0b21hdGlvbiBnZXN0dXJlcyBkaXNhZ3JlZSBhdCBhIHNoYXJlZCBib3VuZGFyeVwiXHJcbiAgICApO1xyXG4gICAge3NoYXBlOiBzdGF0ZS5zaGFwZSwgcG9pbnRzOiBzdGF0ZS5wb2ludHMgKyBmaWx0ZXIocG9pbnRzLCBmbihwKSA9PiBwWzBdID4gcHJldmlvdXNbMF0pfVxyXG59XHJcbmZuIGpvaW4oYXV0b21hdGlvbnMsIHRpbWluZykge1xyXG4gICAgbGV0IGNsb2NrZWQgPSBtYXAoXHJcbiAgICAgICAgYXV0b21hdGlvbnMsXHJcbiAgICAgICAgZm4oYSkgPT4gbWVyZ2UoYSwge1xyXG4gICAgICAgICAgICBjdXJ2ZTogbWVyZ2UoYS5jdXJ2ZSwge1xyXG4gICAgICAgICAgICAgICAgcG9pbnRzOiBtYXAoYS5jdXJ2ZS5wb2ludHMsIGZuKHApID0+IFtzZWNvbmRzX2F0KHBbMF0sIHRpbWluZyksIHBbMV1dKVxyXG4gICAgICAgICAgICB9KVxyXG4gICAgICAgIH0pXHJcbiAgICApO1xyXG4gICAgbWFwKGdyb3VwX2J5KGNsb2NrZWQsIGZuKGEpID0+IGEudGFyZ2V0KSwgZm4oZ3JvdXApID0+IHtcclxuICAgICAgICBsZXQgb3JkZXJlZCA9IHNvcnRfYnkoZ3JvdXAsIGZuKGEpID0+IGEuY3VydmUucG9pbnRzWzBdWzBdKTtcclxuICAgICAgICBsZXQgY29tYmluZWQgPSBmb2xkKFxyXG4gICAgICAgICAgICBmaWx0ZXIocmFuZ2UobGVuKG9yZGVyZWQpKSwgZm4oaSkgPT4gaSA+IDApLFxyXG4gICAgICAgICAgICBvcmRlcmVkWzBdLmN1cnZlLFxyXG4gICAgICAgICAgICBmbihzdGF0ZSwgaSkgPT4gYXBwZW5kX2N1cnZlKHN0YXRlLCBvcmRlcmVkW2ldKVxyXG4gICAgICAgICk7XHJcbiAgICAgICAgYXV0b21hdGlvbihvcmRlcmVkWzBdLnRhcmdldCwgY29tYmluZWQpXHJcbiAgICB9KVxyXG59XHJcblxyXG5mbiBidWlsZChhcnJhbmdlbWVudCwgc2V0dGluZ3MsIGdlc3R1cmVzID0gW10pIHtcclxuICAgIGxldCBkZWZhdWx0cyA9IHt0ZW1wbzogMTIwLCB0ZW1wb3M6IFtdLCBhdXRvbWF0aW9uOiBbXSwgdHJhY2tzOiBbXX07XHJcbiAgICBsZXQgY29uZmlnID0gbWVyZ2UoZGVmYXVsdHMsIHNldHRpbmdzKTtcclxuICAgIGxldCBhbGxfcGFydHMgPSBmbGF0dGVuKG1hcChhcnJhbmdlbWVudC5wbGFjZW1lbnRzLCBmbihpdGVtKSA9PiBwbGFjZWRfcGFydHMoaXRlbSkpKTtcclxuICAgIGxldCB0cmFja19pZHMgPSBtYXAoY29uZmlnLnRyYWNrcywgZm4odCkgPT4gdC5pZCk7XHJcbiAgICBhc3NlcnQoXHJcbiAgICAgICAgbGVuKGZpbHRlcihhbGxfcGFydHMsIGZuKHApID0+ICFjb250YWlucyh0cmFja19pZHMsIHAuaWQpKSkgPT0gMCxcclxuICAgICAgICBcImFycmFuZ2VtZW50IHBhcnQgaGFzIG5vIG1hdGNoaW5nIHNvbmcgdHJhY2tcIlxyXG4gICAgKTtcclxuICAgIGxldCB0aW1pbmcgPSB7XHJcbiAgICAgICAgdGVtcG86IGNvbmZpZy50ZW1wbyxcclxuICAgICAgICB0ZW1wb3M6XHJcbiAgICAgICAgICAgIGNvbmZpZy50ZW1wb3NcclxuICAgICAgICAgICAgKyBmbGF0dGVuKFxyXG4gICAgICAgICAgICAgICAgbWFwKFxyXG4gICAgICAgICAgICAgICAgICAgIGFycmFuZ2VtZW50LnBsYWNlbWVudHMsXHJcbiAgICAgICAgICAgICAgICAgICAgZm4oaXRlbSkgPT4gbWFwKGl0ZW0udGVtcG9zLCBmbihwb2ludCkgPT4gW2l0ZW0uc3RhcnQgKyBwb2ludFswXSwgcG9pbnRbMV1dKVxyXG4gICAgICAgICAgICAgICAgKVxyXG4gICAgICAgICAgICApXHJcbiAgICB9O1xyXG4gICAgbWFwKGFycmFuZ2VtZW50LnBsYWNlbWVudHMsIGZuKGl0ZW0pID0+IG1hcChcclxuICAgICAgICBpdGVtLmNvbnRyYWN0cywgZm4oY29udHJhY3QpID0+IGNvbnRyYWN0KGNvbnRleHQoaXRlbSwgdGltaW5nKSlcclxuICAgICkpO1xyXG4gICAgbGV0IGxvY2FsX2dlc3R1cmVzID0gZmxhdHRlbihcclxuICAgICAgICBtYXAoXHJcbiAgICAgICAgICAgIGFycmFuZ2VtZW50LnBsYWNlbWVudHMsXHJcbiAgICAgICAgICAgIGZuKGl0ZW0pID0+IGZsYXR0ZW4oXHJcbiAgICAgICAgICAgICAgICBtYXAoaXRlbS5nZXN0dXJlcywgZm4oZ2VzdHVyZSkgPT4gZ2VzdHVyZShjb250ZXh0KGl0ZW0sIHRpbWluZykpKVxyXG4gICAgICAgICAgICApXHJcbiAgICAgICAgKVxyXG4gICAgKTtcclxuICAgIGxldCBnbG9iYWxfY29udGV4dCA9IHtcclxuICAgICAgICBuYW1lOiBcInNvbmdcIixcclxuICAgICAgICBzdGFydDogMGIsXHJcbiAgICAgICAgc3BhbjogYXJyYW5nZW1lbnQuc3BhbixcclxuICAgICAgICBwYXJ0czogYWxsX3BhcnRzLFxyXG4gICAgICAgIHRpbWluZzogdGltaW5nXHJcbiAgICB9O1xyXG4gICAgbGV0IGdsb2JhbF9nZXN0dXJlcyA9IGZsYXR0ZW4obWFwKGdlc3R1cmVzLCBmbihnZXN0dXJlKSA9PiBnZXN0dXJlKGdsb2JhbF9jb250ZXh0KSkpO1xyXG4gICAgc29uZyhcclxuICAgICAgICBtZXJnZShjb25maWcsIHtcclxuICAgICAgICAgICAgdGVtcG9zOiB0aW1pbmcudGVtcG9zLFxyXG4gICAgICAgICAgICBzZWN0aW9uczogbWFwKGFycmFuZ2VtZW50LnBsYWNlbWVudHMsIGZuKGl0ZW0pID0+IHNlY3Rpb24oaXRlbS5uYW1lLCBpdGVtLnNwYW4pKSxcclxuICAgICAgICAgICAgdHJhY2tzOiBtYXAoY29uZmlnLnRyYWNrcywgZm4odCkgPT4gbWVyZ2UodCwge3BhdHRlcm46IGNvbGxlY3QoYWxsX3BhcnRzLCB0LmlkKX0pKSxcclxuICAgICAgICAgICAgYXV0b21hdGlvbjogam9pbihjb25maWcuYXV0b21hdGlvbiArIGxvY2FsX2dlc3R1cmVzICsgZ2xvYmFsX2dlc3R1cmVzLCB0aW1pbmcpXHJcbiAgICAgICAgfSlcclxuICAgIClcclxufVxyXG4ifSx7Im5hbWUiOiJzdGQvY2F0YWxvZ3MubXV6Iiwic291cmNlIjoiLy8gRGVmYXVsdCB2b2NhYnVsYXJ5IGFuZCBtdXNpY2FsIHJlY2lwZXMgYXJlIGVkaXRhYmxlIHNvdXJjZS5cclxubGV0IHN5bnRoX3ByZXNldHMgPSB7XHJcbiAgICBcImluaXRcIjoge30sXHJcbiAgICBcInB1bHNlLWJhc3NcIjoge1xyXG4gICAgICAgIG1vZGU6IFwicHVsc2VcIixcclxuICAgICAgICBjdXRvZmZfaHo6IDgwMC4wLFxyXG4gICAgICAgIGZpbHRlcl9lbnY6IDIuNSxcclxuICAgICAgICBhdHRhY2tfbXM6IDIuMCxcclxuICAgICAgICBkZWNheV9tczogMTIwLjAsXHJcbiAgICAgICAgc3VzdGFpbjogMC40NSxcclxuICAgICAgICByZWxlYXNlX21zOiA3MC4wLFxyXG4gICAgICAgIHN1YjogMC40NSxcclxuICAgICAgICBkcml2ZV9kYjogMy4wLFxyXG4gICAgICAgIGdhaW5fZGI6IC0xMy4wXHJcbiAgICB9LFxyXG4gICAgXCJnbGFzcy1sZWFkXCI6IHtcclxuICAgICAgICBtb2RlOiBcInNhd1wiLFxyXG4gICAgICAgIHVuaXNvbjogMy4wLFxyXG4gICAgICAgIGRldHVuZV9jZW50czogOC4wLFxyXG4gICAgICAgIGF0dGFja19tczogOC4wLFxyXG4gICAgICAgIGRlY2F5X21zOiAxNzAuMCxcclxuICAgICAgICBzdXN0YWluOiAwLjYsXHJcbiAgICAgICAgcmVsZWFzZV9tczogMTgwLjAsXHJcbiAgICAgICAgY3V0b2ZmX2h6OiAzODAwLjAsXHJcbiAgICAgICAgZmlsdGVyX2VudjogMS4wLFxyXG4gICAgICAgIHZpYnJhdG9fY2VudHM6IDkuMCxcclxuICAgICAgICBnYWluX2RiOiAtMTguMFxyXG4gICAgfSxcclxuICAgIFwicGFkXCI6IHtcclxuICAgICAgICBtb2RlOiBcInNhd1wiLFxyXG4gICAgICAgIHVuaXNvbjogNS4wLFxyXG4gICAgICAgIGRldHVuZV9jZW50czogMTQuMCxcclxuICAgICAgICBhdHRhY2tfbXM6IDY1MC4wLFxyXG4gICAgICAgIHJlbGVhc2VfbXM6IDE4MDAuMCxcclxuICAgICAgICBzdXN0YWluOiAwLjcsXHJcbiAgICAgICAgY3V0b2ZmX2h6OiAxODAwLjAsXHJcbiAgICAgICAgZmlsdGVyX2VudjogMC40LFxyXG4gICAgICAgIGdhaW5fZGI6IC0yMy4wXHJcbiAgICB9LFxyXG4gICAgLy8gTGVnYWN5IGFsaWFzIG9mIHBhZDsgcmV0YWluZWQgdW5jaGFuZ2VkLiBVc2Ugc3RkL3N5bnRoZXNpcyBmb3IgZGlzdGluY3Qgc3RydWN0dXJlcy5cclxuICAgIFwiY2hvaXJcIjoge1xyXG4gICAgICAgIG1vZGU6IFwic2F3XCIsXHJcbiAgICAgICAgdW5pc29uOiA1LjAsXHJcbiAgICAgICAgZGV0dW5lX2NlbnRzOiAxNC4wLFxyXG4gICAgICAgIGF0dGFja19tczogNjUwLjAsXHJcbiAgICAgICAgcmVsZWFzZV9tczogMTgwMC4wLFxyXG4gICAgICAgIHN1c3RhaW46IDAuNyxcclxuICAgICAgICBjdXRvZmZfaHo6IDE4MDAuMCxcclxuICAgICAgICBmaWx0ZXJfZW52OiAwLjQsXHJcbiAgICAgICAgZ2Fpbl9kYjogLTIzLjBcclxuICAgIH0sXHJcbiAgICBcImJlbGxcIjoge1xyXG4gICAgICAgIG1vZGU6IFwiZm1cIixcclxuICAgICAgICBmbV9yYXRpbzogMi4wLFxyXG4gICAgICAgIGZtX2luZGV4OiAyLjUsXHJcbiAgICAgICAgYXR0YWNrX21zOiAyLjAsXHJcbiAgICAgICAgZGVjYXlfbXM6IDQ1MC4wLFxyXG4gICAgICAgIHN1c3RhaW46IDAuMSxcclxuICAgICAgICByZWxlYXNlX21zOiA4NTAuMCxcclxuICAgICAgICBnYWluX2RiOiAtMTguMCxcclxuICAgICAgICBjdXRvZmZfaHo6IDkwMDAuMFxyXG4gICAgfSxcclxuICAgIFwia2lja1wiOiB7bW9kZTogXCJraWNrXCIsIGRlY2F5X21zOiAxNTAuMCwgZ2Fpbl9kYjogLTcuMH0sXHJcbiAgICBcInNuYXJlXCI6IHttb2RlOiBcInNuYXJlXCIsIGRlY2F5X21zOiAxMjUuMCwgZHJpdmVfZGI6IDQuMCwgZ2Fpbl9kYjogLTEzLjB9LFxyXG4gICAgXCJoYXRcIjoge21vZGU6IFwiY3ltYmFsXCIsIGRlY2F5X21zOiAzMi4wLCBnYWluX2RiOiAtMjUuMH0sXHJcbiAgICBcImNyYXNoXCI6IHttb2RlOiBcImN5bWJhbFwiLCBkZWNheV9tczogODUwLjAsIGdhaW5fZGI6IC0yMy4wfSxcclxuICAgIFwidG9tXCI6IHttb2RlOiBcImZtX3BlcmN1c3Npb25cIiwgZGVjYXlfbXM6IDE5MC4wLCBmbV9yYXRpbzogMS41LCBmbV9pbmRleDogMS4wLCBnYWluX2RiOiAtMTMuMH0sXHJcbiAgICBcIm5vaXNlXCI6IHtcclxuICAgICAgICBtb2RlOiBcIm5vaXNlXCIsXHJcbiAgICAgICAgYXR0YWNrX21zOiA3MDAuMCxcclxuICAgICAgICByZWxlYXNlX21zOiAzMDAuMCxcclxuICAgICAgICBnYWluX2RiOiAtMjcuMCxcclxuICAgICAgICBjdXRvZmZfaHo6IDMwMDAuMFxyXG4gICAgfSxcclxuICAgIFwiZmlmdGhzXCI6IHtcclxuICAgICAgICBtb2RlOiBcInB1bHNlXCIsXHJcbiAgICAgICAgdW5pc29uOiAzLjAsXHJcbiAgICAgICAgZGV0dW5lX2NlbnRzOiA1LjAsXHJcbiAgICAgICAgYXR0YWNrX21zOiAzLjAsXHJcbiAgICAgICAgcmVsZWFzZV9tczogOTAuMCxcclxuICAgICAgICBjdXRvZmZfaHo6IDIzMDAuMCxcclxuICAgICAgICBmaWx0ZXJfZW52OiAwLjUsXHJcbiAgICAgICAgZHJpdmVfZGI6IDEwLjAsXHJcbiAgICAgICAgZ2Fpbl9kYjogLTIwLjBcclxuICAgIH1cclxufTtcclxuLy8gTnVtZXJpYyBjb2RlcyBiZWxvbmcgb25seSBhdCB0aGUgbmF0aXZlIGRldmljZSBib3VuZGFyeS4gUHJlc2V0cyBhbmQgY29tcG9zZXJcclxuLy8gb3ZlcnJpZGVzIHVzZSBjaGVja2VkIG5hbWVzOyB0aGVzZSBjb2RlcyBhcmUgaW50ZWdlcnMsIG5vdCBtdXNpY2FsIHF1YW50aXRpZXMuXHJcbmxldCBzeW50aF9tb2RlX2NvZGVzID0ge1xyXG4gICAgc2F3OiAwLFxyXG4gICAgcHVsc2U6IDEsXHJcbiAgICBmbTogMixcclxuICAgIGtpY2s6IDMsXHJcbiAgICBzbmFyZTogNCxcclxuICAgIGN5bWJhbDogNSxcclxuICAgIGZtX3BlcmN1c3Npb246IDYsXHJcbiAgICBub2lzZTogN1xyXG59O1xyXG4vLyBPbmUtc2hvdCBBRFNScyBhcmUgZ2VuZXJhbCB2b2ljZSBlbnZlbG9wZXM7IGFsbCBkcnVtIHRpbWJyZSBjaG9pY2VzIGxpdmUgaGVyZS5cclxuZm4gcGVyY3Vzc2lvbl9lbnZlbG9wZShpZCwgZGVjYXkpID0ge1xyXG4gICAgaWQ6IGlkLFxyXG4gICAgb3A6IFwiYWRzclwiLFxyXG4gICAgYXR0YWNrOiAwLFxyXG4gICAgZGVjYXk6IGRlY2F5LFxyXG4gICAgc3VzdGFpbjogMCxcclxuICAgIHJlbGVhc2U6IDAuMDA4LFxyXG4gICAgb25lX3Nob3Q6IHRydWVcclxufTtcclxuZm4gcGVyY3Vzc2lvbl9wYXRjaChuYW1lLCBzZXR0aW5ncykge1xyXG4gICAgbGV0IHAgPSBtZXJnZSh7ZGVjYXlfbXM6IDIwMCwgZ2Fpbl9kYjogLTE0LCBkcml2ZV9kYjogMH0sIHNldHRpbmdzKTtcclxuICAgIGxldCBjb21tb24gPSBbXHJcbiAgICAgICAge2lkOiBcImRlY2F5X21zXCIsIG9wOiBcInBhcmFtXCIsIHZhbHVlOiBwLmRlY2F5X21zLCBtaW46IDEsIG1heDogMTAwMDB9LFxyXG4gICAgICAgIHtpZDogXCJkZWNheV9zZWNvbmRzXCIsIG9wOiBcIm11bFwiLCBpbnB1dHM6IFtcImRlY2F5X21zXCIsIDAuMDA1XX0sXHJcbiAgICAgICAgbWVyZ2UocGVyY3Vzc2lvbl9lbnZlbG9wZShcImFtcFwiLCBcImRlY2F5X3NlY29uZHNcIiksIHthdHRhY2s6IDAuMDAwN30pLFxyXG4gICAgICAgIHtpZDogXCJub2lzZVwiLCBvcDogXCJub2lzZVwifSxcclxuICAgICAgICB7aWQ6IFwiYWlyXCIsIG9wOiBcImZpbHRlclwiLCBpbnB1dDogXCJub2lzZVwiLCBtb2RlOiBcImhpZ2hwYXNzXCIsIGN1dG9mZjogMTgwMCwgcTogMC43fVxyXG4gICAgXTtcclxuICAgIGxldCBib2R5ID0gaWYgcC5tb2RlID09IFwia2lja1wiIHtcclxuICAgICAgICBbXHJcbiAgICAgICAgICAgIHBlcmN1c3Npb25fZW52ZWxvcGUoXCJzd2VlcFwiLCAwLjA2NSksXHJcbiAgICAgICAgICAgIHtpZDogXCJiZW5kXCIsIG9wOiBcIm11bFwiLCBpbnB1dHM6IFtcInN3ZWVwXCIsIDUuNV19LFxyXG4gICAgICAgICAgICB7aWQ6IFwicmF0aW9cIiwgb3A6IFwic3VtXCIsIGlucHV0czogWzEsIFwiYmVuZFwiXX0sXHJcbiAgICAgICAgICAgIHtpZDogXCJvc2NcIiwgb3A6IFwib3NjXCIsIHdhdmU6IFwic2luZVwiLCByYXRpbzogXCJyYXRpb1wifSxcclxuICAgICAgICAgICAge2lkOiBcInNhdHVyYXRlZFwiLCBvcDogXCJkcml2ZVwiLCBpbnB1dDogXCJvc2NcIiwgYW1vdW50OiAxLjV9LFxyXG4gICAgICAgICAgICB7aWQ6IFwiYm9keVwiLCBvcDogXCJtdWxcIiwgaW5wdXRzOiBbXCJzYXR1cmF0ZWRcIiwgMC44NV19LFxyXG4gICAgICAgICAgICBwZXJjdXNzaW9uX2VudmVsb3BlKFwiY2xpY2tfZW52XCIsIDAuMDI1KSxcclxuICAgICAgICAgICAge2lkOiBcImNsaWNrXCIsIG9wOiBcIm11bFwiLCBpbnB1dHM6IFtcImFpclwiLCBcImNsaWNrX2VudlwiLCAwLjM1XX0sXHJcbiAgICAgICAgICAgIHtpZDogXCJtaXhcIiwgb3A6IFwic3VtXCIsIGlucHV0czogW1wiYm9keVwiLCBcImNsaWNrXCJdfVxyXG4gICAgICAgIF1cclxuICAgIH0gZWxzZSB7XHJcbiAgICAgICAgaWYgcC5tb2RlID09IFwic25hcmVcIiB7XHJcbiAgICAgICAgICAgIFtcclxuICAgICAgICAgICAgICAgIHBlcmN1c3Npb25fZW52ZWxvcGUoXCJzd2VlcFwiLCAwLjEpLFxyXG4gICAgICAgICAgICAgICAge2lkOiBcImJlbmRcIiwgb3A6IFwibXVsXCIsIGlucHV0czogW1wic3dlZXBcIiwgOTBdfSxcclxuICAgICAgICAgICAgICAgIHtpZDogXCJoelwiLCBvcDogXCJzdW1cIiwgaW5wdXRzOiBbMTcwLCBcImJlbmRcIl19LFxyXG4gICAgICAgICAgICAgICAge2lkOiBcIm9zY1wiLCBvcDogXCJvc2NcIiwgd2F2ZTogXCJzaW5lXCIsIGh6OiBcImh6XCJ9LFxyXG4gICAgICAgICAgICAgICAgcGVyY3Vzc2lvbl9lbnZlbG9wZShcImJvZHlfZW52XCIsIDAuMzI1KSxcclxuICAgICAgICAgICAgICAgIHtpZDogXCJib2R5XCIsIG9wOiBcIm11bFwiLCBpbnB1dHM6IFtcIm9zY1wiLCBcImJvZHlfZW52XCIsIDAuNTVdfSxcclxuICAgICAgICAgICAgICAgIHBlcmN1c3Npb25fZW52ZWxvcGUoXCJzbmFwX2VudlwiLCAwLjA1NSksXHJcbiAgICAgICAgICAgICAgICB7aWQ6IFwic25hcFwiLCBvcDogXCJtdWxcIiwgaW5wdXRzOiBbXCJzbmFwX2VudlwiLCAwLjMyXX0sXHJcbiAgICAgICAgICAgICAgICB7aWQ6IFwicmF0dGxlXCIsIG9wOiBcInN1bVwiLCBpbnB1dHM6IFswLjY4LCBcInNuYXBcIl19LFxyXG4gICAgICAgICAgICAgICAge2lkOiBcIndpcmVcIiwgb3A6IFwibXVsXCIsIGlucHV0czogW1wiYWlyXCIsIFwicmF0dGxlXCIsIDEuNl19LFxyXG4gICAgICAgICAgICAgICAge2lkOiBcIm1peFwiLCBvcDogXCJzdW1cIiwgaW5wdXRzOiBbXCJib2R5XCIsIFwid2lyZVwiXX1cclxuICAgICAgICAgICAgXVxyXG4gICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIFtcclxuICAgICAgICAgICAgICAgIHtpZDogXCJhXCIsIG9wOiBcIm9zY1wiLCB3YXZlOiBcInNpbmVcIiwgaHo6IDczMTN9LFxyXG4gICAgICAgICAgICAgICAge2lkOiBcImJcIiwgb3A6IFwib3NjXCIsIHdhdmU6IFwic2luZVwiLCBoejogNTI5N30sXHJcbiAgICAgICAgICAgICAgICB7aWQ6IFwibWV0YWxcIiwgb3A6IFwibXVsXCIsIGlucHV0czogW1wiYVwiLCBcImJcIiwgMC4yMl19LFxyXG4gICAgICAgICAgICAgICAge2lkOiBcIndhc2hcIiwgb3A6IFwibXVsXCIsIGlucHV0czogW1wiYWlyXCIsIDAuOF19LFxyXG4gICAgICAgICAgICAgICAge2lkOiBcIm1peFwiLCBvcDogXCJzdW1cIiwgaW5wdXRzOiBbXCJtZXRhbFwiLCBcIndhc2hcIl19XHJcbiAgICAgICAgICAgIF1cclxuICAgICAgICB9XHJcbiAgICB9O1xyXG4gICAgbGV0IGRyaXZlID0gaWYgcC5tb2RlID09IFwia2lja1wiIHx8IHAuZHJpdmVfZGIgPD0gMCB7IDEgfSBlbHNlIHsgcG93KDEwLCBwLmRyaXZlX2RiIC8gMjApIH07XHJcbiAgICBsZXQgZmluaXNoID0gaWYgZHJpdmUgPT0gMSB7XHJcbiAgICAgICAgW3tpZDogXCJvdXRcIiwgb3A6IFwibXVsXCIsIGlucHV0czogW1wibWl4XCIsIFwiYW1wXCJdfV1cclxuICAgIH0gZWxzZSB7XHJcbiAgICAgICAgW1xyXG4gICAgICAgICAgICB7aWQ6IFwiZHJpdmVuXCIsIG9wOiBcImRyaXZlXCIsIGlucHV0OiBcIm1peFwiLCBhbW91bnQ6IGRyaXZlfSxcclxuICAgICAgICAgICAge2lkOiBcIm91dFwiLCBvcDogXCJtdWxcIiwgaW5wdXRzOiBbXCJkcml2ZW5cIiwgXCJhbXBcIiwgMSAvIHBvdyhkcml2ZSwgMC41KV19XHJcbiAgICAgICAgXVxyXG4gICAgfTtcclxuICAgIHZvaWNlX3BhdGNoKG5hbWUsIHtnYWluX2RiOiBwLmdhaW5fZGIsIG5vZGVzOiBjb21tb24gKyBib2R5ICsgZmluaXNoLCBvdXRwdXQ6IFwib3V0XCJ9KVxyXG59XHJcbmZuIHN5bnRoKG5hbWUgPSBcImluaXRcIiwgcGFyYW1zID0ge30sIHByZXNldHMgPSBzeW50aF9wcmVzZXRzKSB7XHJcbiAgICBsZXQgc2V0dGluZ3MgPSBtZXJnZSh7dHlwZTogXCJzeW50aFwiLCBuYW1lOiBuYW1lLCBtb2RlOiBcInNhd1wifSwgcHJlc2V0c1tuYW1lXSwgcGFyYW1zKTtcclxuICAgIGFzc2VydChcclxuICAgICAgICBjb250YWlucyhrZXlzKHN5bnRoX21vZGVfY29kZXMpLCBzZXR0aW5ncy5tb2RlKSxcclxuICAgICAgICBcInN5bnRoIG1vZGUgbXVzdCBiZSBhIG5hbWU6IHNhdywgcHVsc2UsIGZtLCBraWNrLCBzbmFyZSwgY3ltYmFsLCBmbV9wZXJjdXNzaW9uLCBvciBub2lzZVwiXHJcbiAgICApO1xyXG4gICAgaWYgY29udGFpbnMoW1wia2lja1wiLCBcInNuYXJlXCIsIFwiY3ltYmFsXCJdLCBzZXR0aW5ncy5tb2RlKSB7XHJcbiAgICAgICAgcGVyY3Vzc2lvbl9wYXRjaChuYW1lLCBzZXR0aW5ncylcclxuICAgIH0gZWxzZSB7XHJcbiAgICAgICAgbWVyZ2Uoc2V0dGluZ3MsIHttb2RlOiBzeW50aF9tb2RlX2NvZGVzW3NldHRpbmdzLm1vZGVdfSlcclxuICAgIH1cclxufVxyXG5cclxubGV0IGRydW1fdm9pY2VzID0ge1xyXG4gICAga2ljazogMzYsXHJcbiAgICBzbmFyZTogMzgsXHJcbiAgICByaW1zaG90OiAzOCxcclxuICAgIHJpbTogMzcsXHJcbiAgICBoYXQ6IDQyLFxyXG4gICAgY2xvc2VkX2hhdDogNDIsXHJcbiAgICBvcGVuX2hhdDogNDYsXHJcbiAgICBwZWRhbF9oYXQ6IDQ0LFxyXG4gICAgY3Jhc2g6IDQ5LFxyXG4gICAgcmlkZTogNTEsXHJcbiAgICB0b21faGlnaDogNTAsXHJcbiAgICB0b206IDQ3LFxyXG4gICAgdG9tX2xvdzogNDNcclxufTtcclxubGV0IGRydW1fYXJ0aWN1bGF0aW9ucyA9IHtcclxuICAgIFwiWFwiOiAwLjk1LFxyXG4gICAgXCJ4XCI6IDAuNzIsXHJcbiAgICBcImdcIjogMC4zNCxcclxuICAgIFwib1wiOiAwLjU4LFxyXG4gICAgXCIxXCI6IDAuMSxcclxuICAgIFwiMlwiOiAwLjIsXHJcbiAgICBcIjNcIjogMC4zLFxyXG4gICAgXCI0XCI6IDAuNCxcclxuICAgIFwiNVwiOiAwLjUsXHJcbiAgICBcIjZcIjogMC42LFxyXG4gICAgXCI3XCI6IDAuNyxcclxuICAgIFwiOFwiOiAwLjgsXHJcbiAgICBcIjlcIjogMC45LFxyXG4gICAgXCIuXCI6IG51bGwsXHJcbiAgICBcIi1cIjogbnVsbCxcclxuICAgIFwiX1wiOiBudWxsXHJcbn07XHJcbmZuIGRydW1zKGxhbmVzLCBzcGFuID0gNGIsIHZvaWNlcyA9IGRydW1fdm9pY2VzLCBhcnRpY3VsYXRpb25zID0gZHJ1bV9hcnRpY3VsYXRpb25zLCBnYXRlID0gMC41KSA9XHJcbiAgICBkcnVtX2dyaWQobGFuZXMsIHZvaWNlcywgYXJ0aWN1bGF0aW9ucywgZ2F0ZSwgc3Bhbik7XHJcbmxldCBraXRfZGVmYXVsdHMgPSB7XHJcbiAgICB0eXBlOiBcImtpdFwiLFxyXG4gICAgbmFtZTogXCJkZWZhdWx0XCIsXHJcbiAgICBraWNrOiBzeW50aChcImtpY2tcIiksXHJcbiAgICBzbmFyZTogc3ludGgoXCJzbmFyZVwiKSxcclxuICAgIHJpbTogc3ludGgoXCJzbmFyZVwiKSxcclxuICAgIHJpbXNob3Q6IHN5bnRoKFwic25hcmVcIiksXHJcbiAgICBoYXQ6IHN5bnRoKFwiaGF0XCIpLFxyXG4gICAgY2xvc2VkX2hhdDogc3ludGgoXCJoYXRcIiksXHJcbiAgICBwZWRhbF9oYXQ6IHN5bnRoKFwiaGF0XCIpLFxyXG4gICAgb3Blbl9oYXQ6IHN5bnRoKFwiY3Jhc2hcIiksXHJcbiAgICBjcmFzaDogc3ludGgoXCJjcmFzaFwiKSxcclxuICAgIHJpZGU6IHN5bnRoKFwiY3Jhc2hcIiksXHJcbiAgICB0b206IHN5bnRoKFwidG9tXCIpLFxyXG4gICAgdG9tX2xvdzogc3ludGgoXCJ0b21cIiksXHJcbiAgICB0b21faGlnaDogc3ludGgoXCJ0b21cIiksXHJcbiAgICBjaG9rZXM6IFtbXCJoYXRcIiwgXCJvcGVuX2hhdFwiLCBcInBlZGFsX2hhdFwiXV1cclxufTtcclxuZm4ga2l0KG5hbWUgPSBcImRlZmF1bHRcIiwgcGFyYW1zID0ge30pID0gbWVyZ2Uoa2l0X2RlZmF1bHRzLCB7bmFtZTogbmFtZX0sIHBhcmFtcyk7XHJcblxyXG5sZXQgc2NhbGVfbW9kZXMgPSB7XHJcbiAgICBtYWpvcjogWzAsIDIsIDQsIDUsIDcsIDksIDExXSxcclxuICAgIGlvbmlhbjogWzAsIDIsIDQsIDUsIDcsIDksIDExXSxcclxuICAgIG1pbm9yOiBbMCwgMiwgMywgNSwgNywgOCwgMTBdLFxyXG4gICAgYWVvbGlhbjogWzAsIDIsIDMsIDUsIDcsIDgsIDEwXSxcclxuICAgIGhhcm1vbmljX21pbm9yOiBbMCwgMiwgMywgNSwgNywgOCwgMTFdLFxyXG4gICAgbWVsb2RpY19taW5vcjogWzAsIDIsIDMsIDUsIDcsIDksIDExXSxcclxuICAgIGRvcmlhbjogWzAsIDIsIDMsIDUsIDcsIDksIDEwXSxcclxuICAgIHBocnlnaWFuOiBbMCwgMSwgMywgNSwgNywgOCwgMTBdLFxyXG4gICAgbHlkaWFuOiBbMCwgMiwgNCwgNiwgNywgOSwgMTFdLFxyXG4gICAgbWl4b2x5ZGlhbjogWzAsIDIsIDQsIDUsIDcsIDksIDEwXSxcclxuICAgIGxvY3JpYW46IFswLCAxLCAzLCA1LCA2LCA4LCAxMF0sXHJcbiAgICBwZW50YXRvbmljOiBbMCwgMiwgNCwgNywgOV0sXHJcbiAgICBtaW5vcl9wZW50YXRvbmljOiBbMCwgMywgNSwgNywgMTBdLFxyXG4gICAgd2hvbGVfdG9uZTogWzAsIDIsIDQsIDYsIDgsIDEwXVxyXG59O1xyXG5mbiBzY2FsZShyb290LCBtb2RlID0gXCJtaW5vclwiLCBvY3RhdmUgPSA0LCBtb2RlcyA9IHNjYWxlX21vZGVzKSA9IG1vZGVzW21vZGVdLm1hcChcclxuICAgIGZuKGludGVydmFsKSA9PiBwaXRjaChyb290LCBvY3RhdmUpICsgaW50ZXJ2YWxcclxuKTtcclxuZm4gZGVncmVlKHNjYWxlLCBkZWdyZWUpIHtcclxuICAgIGFzc2VydChsZW4oc2NhbGUpID4gMCwgXCJzY2FsZSBpcyBlbXB0eVwiKTtcclxuICAgIGFzc2VydChkZWdyZWUgPT0gZmxvb3IoZGVncmVlKSwgXCJkZWdyZWUgbXVzdCBiZSBhbiBpbnRlZ2VyXCIpO1xyXG4gICAgbGV0IG9jdGF2ZSA9IGZsb29yKChkZWdyZWUgLSAxKSAvIGxlbihzY2FsZSkpO1xyXG4gICAgc2NhbGVbZGVncmVlIC0gMSAtIG9jdGF2ZSAqIGxlbihzY2FsZSldICsgMTIgKiBvY3RhdmVcclxufVxyXG5sZXQgZGVncmVlX3BpdGNoID0gZGVncmVlO1xyXG5mbiBkaWF0b25pY19jaG9yZChzY2FsZSwgZGVncmVlLCB2b2ljZXMgPSAzKSB7XHJcbiAgICBhc3NlcnQoXHJcbiAgICAgICAgdm9pY2VzID09IGZsb29yKHZvaWNlcykgJiYgdm9pY2VzID49IDEgJiYgdm9pY2VzIDw9IDgsXHJcbiAgICAgICAgXCJkaWF0b25pYyBjaG9yZCBuZWVkcyAxLi44IHZvaWNlc1wiXHJcbiAgICApO1xyXG4gICAgcmFuZ2Uodm9pY2VzKS5tYXAoZm4oaSkgPT4gZGVncmVlX3BpdGNoKHNjYWxlLCBkZWdyZWUgKyAyICogaSkpXHJcbn1cclxuZm4gZXVjbGlkZWFuKGhpdHMsIHN0ZXBzLCBwaXRjaCA9IDQyLCBzcGFuID0gNGIsIHJvdGF0aW9uID0gMCkge1xyXG4gICAgYXNzZXJ0KFxyXG4gICAgICAgIHN0ZXBzID09IGZsb29yKHN0ZXBzKVxyXG4gICAgICAgICYmIGhpdHMgPT0gZmxvb3IoaGl0cylcclxuICAgICAgICAmJiByb3RhdGlvbiA9PSBmbG9vcihyb3RhdGlvbilcclxuICAgICAgICAmJiBzdGVwcyA+IDBcclxuICAgICAgICAmJiBzdGVwcyA8PSA0MDk2XHJcbiAgICAgICAgJiYgaGl0cyA+PSAwXHJcbiAgICAgICAgJiYgaGl0cyA8PSBzdGVwc1xyXG4gICAgICAgICYmIHJvdGF0aW9uID49IDAsXHJcbiAgICAgICAgXCJldWNsaWRlYW4gcmVxdWlyZXMgaW50ZWdlciAwIDw9IGhpdHMgPD0gc3RlcHMgPD0gNDA5NiBhbmQgbm9ubmVnYXRpdmUgcm90YXRpb25cIlxyXG4gICAgKTtcclxuICAgIHN0YWNrKFtcclxuICAgICAgICByZXN0KHNwYW4pLFxyXG4gICAgICAgIHN0YWNrKFxyXG4gICAgICAgICAgICByYW5nZShzdGVwcylcclxuICAgICAgICAgICAgICAgIC5maWx0ZXIoZm4oaSkgPT4gKGkgKiBoaXRzKSAlIHN0ZXBzIDwgaGl0cylcclxuICAgICAgICAgICAgICAgIC5tYXAoXHJcbiAgICAgICAgICAgICAgICAgICAgZm4oaSkgPT4gbm90ZShcclxuICAgICAgICAgICAgICAgICAgICAgICAgcGl0Y2gsXHJcbiAgICAgICAgICAgICAgICAgICAgICAgIHNwYW4gLyAoc3RlcHMgKiAyKSxcclxuICAgICAgICAgICAgICAgICAgICAgICAgYXQgPSAoKGkgKyByb3RhdGlvbikgJSBzdGVwcykgKiBzcGFuIC8gc3RlcHNcclxuICAgICAgICAgICAgICAgICAgICApXHJcbiAgICAgICAgICAgICAgICApXHJcbiAgICAgICAgKVxyXG4gICAgXSlcclxufVxyXG5mbiB0aW1lX2Nvb3JkaW5hdGUodmFsdWUsIHRpY2spID0gaWYgdW5pdCh2YWx1ZSkgPT0gMSB7IHZhbHVlICogdGljayB9IGVsc2UgeyB2YWx1ZSB9O1xyXG5mbiBsZm8ocGVyaW9kLCBkdXJhdGlvbiwgbG93ID0gMCwgaGlnaCA9IDEsIHBoYXNlID0gMCkge1xyXG4gICAgbGV0IHRpY2sgPSBpZiB1bml0KHBlcmlvZCkgPT0gMXMgeyAxcyB9IGVsc2UgeyAxYiB9O1xyXG4gICAgbGV0IHBlcmlvZCA9IHRpbWVfY29vcmRpbmF0ZShwZXJpb2QsIHRpY2spO1xyXG4gICAgbGV0IGR1cmF0aW9uID0gdGltZV9jb29yZGluYXRlKGR1cmF0aW9uLCB0aWNrKTtcclxuICAgIGxldCBjeWNsZXMgPSBkdXJhdGlvbiAvIHBlcmlvZDtcclxuICAgIGFzc2VydChcclxuICAgICAgICBjeWNsZXMgPiAwICYmIGN5Y2xlcyA8PSAxNTAwICYmIHBlcmlvZCA+IHBlcmlvZCAqIDAsXHJcbiAgICAgICAgXCJMRk8gbmVlZHMgcG9zaXRpdmUgcGVyaW9kL2R1cmF0aW9uIGFuZCBhdCBtb3N0IDE1MDAgY3ljbGVzXCJcclxuICAgICk7XHJcbiAgICBsZXQgY291bnQgPSBtYXgoMSwgLWZsb29yKC1jeWNsZXMgKiA2NCkpO1xyXG4gICAgY3VydmUoXHJcbiAgICAgICAgcmFuZ2UoY291bnQgKyAxKS5tYXAoZm4oaSkgPT4gW1xyXG4gICAgICAgICAgICBkdXJhdGlvbiAqIGkgLyBjb3VudCxcclxuICAgICAgICAgICAgbG93XHJcbiAgICAgICAgICAgICsgKGhpZ2ggLSBsb3cpICogKDAuNSAtIDAuNSAqIGNvcyg2LjI4MzE4NTMwNzE3OTU4NiAqIChjeWNsZXMgKiBpIC8gY291bnQgKyBwaGFzZSkpKVxyXG4gICAgICAgIF0pXHJcbiAgICApXHJcbn1cclxuZm4gY3VydmVfYXQoY3VydmUsIG9mZnNldCkge1xyXG4gICAgbGV0IHRpY2sgPSBpZiB1bml0KG9mZnNldCkgPT0gMXMgeyAxcyB9IGVsc2UgeyAxYiB9O1xyXG4gICAgbWVyZ2UoY3VydmUsIHtcclxuICAgICAgICBwb2ludHM6IGN1cnZlLnBvaW50cy5tYXAoZm4ocCkgPT4gW1xyXG4gICAgICAgICAgICB0aW1lX2Nvb3JkaW5hdGUocFswXSwgdGljaykgKyB0aW1lX2Nvb3JkaW5hdGUob2Zmc2V0LCB0aWNrKSxcclxuICAgICAgICAgICAgcFsxXVxyXG4gICAgICAgIF0pXHJcbiAgICB9KVxyXG59XHJcblxyXG4vLyBNdXNpY2FsIHJhbmtpbmcgcHJlZmVyZW5jZXMgYXJlIGRhdGEsIGRpc3RpbmN0IGZyb20gYm91bmRlZCBzZWFyY2ggbWVjaGFuaWNzLlxyXG5sZXQgdG9uYWxfc2NvcmluZyA9IHtcclxuICAgIGNvbW1vbl90b25lOiAtMSxcclxuICAgIHBhcmFsbGVsOiAyLFxyXG4gICAgY2FuZGlkYXRlX2NlbnRlcjogMSxcclxuICAgIGNhbmRpZGF0ZV9zcHJlYWQ6IDAuMDMsXHJcbiAgICBjZW50ZXI6IDAuMixcclxuICAgIHN0cm9uZ19iZWF0OiAxLjUsXHJcbiAgICB3ZWFrX2JlYXQ6IDAuNzUsXHJcbiAgICByZXBlYXQ6IDAuOCxcclxuICAgIGZpZnRoOiAwLjE1LFxyXG4gICAgbW90aW9uOiAwLjEsXHJcbiAgICBhbHRlcm5hdGl2ZV9tb3ZlbWVudDogMC4wMyxcclxuICAgIG1ldHJpY2FsX3BlcmlvZDogMixcclxuICAgIG1ldHJpY2FsX3RvbGVyYW5jZTogMC4wMDAwMDFcclxufTtcclxuZm4gdm9pY2VsZWFkKGhhcm1vbnksIGxvdyA9IDQ4LCBoaWdoID0gODQsIGNlbnRlciA9IDY0LCBzY29yaW5nID0gdG9uYWxfc2NvcmluZykgPSB2b2ljZWxlYWRfc29sdmUoXHJcbiAgICBoYXJtb255LFxyXG4gICAgbG93LFxyXG4gICAgaGlnaCxcclxuICAgIGNlbnRlcixcclxuICAgIHNjb3JpbmdcclxuKTtcclxuZm4gcmVoYXJtb25pemUoaGFybW9ueSwgbWVsb2R5LCBjYW5kaWRhdGVzLCBvY3RhdmUgPSAzLCBzY29yaW5nID0gdG9uYWxfc2NvcmluZykgPVxyXG4gICAgcmVoYXJtb25pemVfc29sdmUoaGFybW9ueSwgbWVsb2R5LCBjYW5kaWRhdGVzLCBvY3RhdmUsIHNjb3JpbmcpO1xyXG5mbiByZWhhcm1vbml6YXRpb25zKGhhcm1vbnksIG1lbG9keSwgY2FuZGlkYXRlcywgb2N0YXZlID0gMywgY291bnQgPSAzLCBzY29yaW5nID0gdG9uYWxfc2NvcmluZykgPVxyXG4gICAgcmVoYXJtb25pemF0aW9uc19zb2x2ZShoYXJtb255LCBtZWxvZHksIGNhbmRpZGF0ZXMsIG9jdGF2ZSwgc2NvcmluZywgY291bnQpO1xyXG5cclxuLy8gU2FtcGxpbmcgcG9saWN5OiByZXRhaW4ga25vdHMsIGFkZCBhIHJlZ3VsYXIgZ3JpZCwgYW5kIHByZXNlcnZlIHN0ZXAgZWRnZXMuXHJcbmZuIGN1cnZlX2tub3RzKGMsIHRpY2spIHtcclxuICAgIGxldCBwb2ludHMgPSBjLnBvaW50cy5tYXAoZm4ocCkgPT4gdGltZV9jb29yZGluYXRlKHBbMF0sIHRpY2spKTtcclxuICAgIGxldCBzaGFwZSA9IG1lcmdlKHtzaGFwZTogXCJsaW5lYXJcIn0sIGMpLnNoYXBlO1xyXG4gICAgcG9pbnRzXHJcbiAgICArIGlmIHNoYXBlID09IFwic3RlcFwiIHtcclxuICAgICAgICBwb2ludHMuZmlsdGVyKGZuKHApID0+IHAgIT0gcG9pbnRzWzBdKS5tYXAoZm4ocCkgPT4gbWF4KHRpY2sgKiAwLCBwIC0gdGljayAqIDAuMDAwMDAxKSlcclxuICAgIH0gZWxzZSB7XHJcbiAgICAgICAgW11cclxuICAgIH1cclxufVxyXG5mbiBjdXJ2ZV9zYW1wbGVfdGltZXMoYSwgYiwgcmVzb2x1dGlvbikge1xyXG4gICAgbGV0IHRpY2sgPSBpZiB1bml0KGEucG9pbnRzWzBdWzBdKSA9PSAxcyB7IDFzIH0gZWxzZSB7IDFiIH07XHJcbiAgICBsZXQgZW5kID0gbWF4KHRpbWVfY29vcmRpbmF0ZShhLnBvaW50c1stMV1bMF0sIHRpY2spLCB0aW1lX2Nvb3JkaW5hdGUoYi5wb2ludHNbLTFdWzBdLCB0aWNrKSk7XHJcbiAgICBsZXQgc3RlcHMgPSBlbmQgLyB0aWNrIC8gcmVzb2x1dGlvbjtcclxuICAgIGFzc2VydChyZXNvbHV0aW9uID4gMCAmJiBzdGVwcyA8PSAxMDAwMDAsIFwiY29udHJvbCByZXNvbHV0aW9uIGV4Y2VlZHMgMTAwMDAwIHBvaW50c1wiKTtcclxuICAgIGxldCB0aW1lcyA9XHJcbiAgICAgICAgY3VydmVfa25vdHMoYSwgdGljaylcclxuICAgICAgICArIGN1cnZlX2tub3RzKGIsIHRpY2spXHJcbiAgICAgICAgKyByYW5nZSgtZmxvb3IoLXN0ZXBzKSArIDEpLm1hcChmbihpKSA9PiBtaW4oZW5kLCBpICogcmVzb2x1dGlvbiAqIHRpY2spKTtcclxuICAgIGxldCBvcmRlcmVkID0gc29ydF9ieSh0aW1lcywgZm4odCkgPT4gdCk7XHJcbiAgICByYW5nZShsZW4ob3JkZXJlZCkpXHJcbiAgICAgICAgLmZpbHRlcihmbihpKSA9PiBpID09IDAgfHwgb3JkZXJlZFtpXSAhPSBvcmRlcmVkW2kgLSAxXSlcclxuICAgICAgICAubWFwKGZuKGkpID0+IG9yZGVyZWRbaV0pXHJcbn1cclxuZm4gY3VydmVfbWFwKGN1cnZlLCBmdW5jdGlvbiwgcmVzb2x1dGlvbiA9IDEvNjQpIHtcclxuICAgIGxldCB0aW1lcyA9IGN1cnZlX3NhbXBsZV90aW1lcyhjdXJ2ZSwgY3VydmUsIHJlc29sdXRpb24pO1xyXG4gICAgbGV0IHZhbHVlcyA9IGN1cnZlX3ZhbHVlKGN1cnZlLCB0aW1lcykubWFwKGZ1bmN0aW9uKTtcclxuICAgIHtwb2ludHM6IHJhbmdlKGxlbih0aW1lcykpLm1hcChmbihpKSA9PiBbdGltZXNbaV0sIHZhbHVlc1tpXV0pLCBzaGFwZTogXCJsaW5lYXJcIn1cclxufVxyXG5mbiBjdXJ2ZV9hZGQoY3VydmUsIG90aGVyLCByZXNvbHV0aW9uID0gMS82NCkge1xyXG4gICAgbGV0IHRpbWVzID0gY3VydmVfc2FtcGxlX3RpbWVzKGN1cnZlLCBvdGhlciwgcmVzb2x1dGlvbik7XHJcbiAgICBsZXQgYSA9IGN1cnZlX3ZhbHVlKGN1cnZlLCB0aW1lcyk7XHJcbiAgICBsZXQgYiA9IGN1cnZlX3ZhbHVlKG90aGVyLCB0aW1lcyk7XHJcbiAgICB7cG9pbnRzOiByYW5nZShsZW4odGltZXMpKS5tYXAoZm4oaSkgPT4gW3RpbWVzW2ldLCBhW2ldICsgYltpXV0pLCBzaGFwZTogXCJsaW5lYXJcIn1cclxufVxyXG5mbiBjdXJ2ZV9tdWwoY3VydmUsIG90aGVyLCByZXNvbHV0aW9uID0gMS82NCkge1xyXG4gICAgbGV0IHRpbWVzID0gY3VydmVfc2FtcGxlX3RpbWVzKGN1cnZlLCBvdGhlciwgcmVzb2x1dGlvbik7XHJcbiAgICBsZXQgYSA9IGN1cnZlX3ZhbHVlKGN1cnZlLCB0aW1lcyk7XHJcbiAgICBsZXQgYiA9IGN1cnZlX3ZhbHVlKG90aGVyLCB0aW1lcyk7XHJcbiAgICB7cG9pbnRzOiByYW5nZShsZW4odGltZXMpKS5tYXAoZm4oaSkgPT4gW3RpbWVzW2ldLCBhW2ldICogYltpXV0pLCBzaGFwZTogXCJsaW5lYXJcIn1cclxufVxyXG4ifSx7Im5hbWUiOiJzdGQvZ3Jvb3Zlcy5tdXoiLCJzb3VyY2UiOiJmbiBmb3VyX2Zsb29yKCkgPSBkcnVtcyh7XHJcbiAgICBraWNrOiAgXCJYLi4uWC4uLlguLi5YLi4uXCIsXHJcbiAgICBzbmFyZTogXCIuLi4uWC4uLi4uLi5YLi4uXCIsXHJcbiAgICBoYXQ6ICAgXCJ4LnguWC54LngueC5YLnguXCJcclxufSk7XHJcbmZuIGJhY2tiZWF0KCkgPSBkcnVtcyh7XHJcbiAgICBraWNrOiAgXCJYLi4uLi54LlguLi4uLi4uXCIsXHJcbiAgICBzbmFyZTogXCIuLi4uWC4uLi4uLi5YLi4uXCIsXHJcbiAgICBoYXQ6ICAgXCJYLnguWC54LlgueC5YLnguXCJcclxufSk7XHJcbmZuIGhhbGZfdGltZSgpID0gZHJ1bXMoe1xyXG4gICAga2ljazogIFwiWC4uLi4ueC4uLnguLi4uLlwiLFxyXG4gICAgc25hcmU6IFwiLi4uLi4uLi5YLi4uLi4uLlwiLFxyXG4gICAgaGF0OiAgIFwiWC54LngueC5YLngueC54LlwiXHJcbn0pO1xyXG5mbiBwdWxzZShwYXR0ZXJuLCByZXBlYXRzID0gNCkgPSBwYXR0ZXJuLnJlcGVhdChyZXBlYXRzKTtcclxuZm4gZmlsbChwYXR0ZXJuLCB0YWlsKSA9IHNlcShbcGF0dGVybi5zbGljZSgwYiwgM2IpLCB0YWlsLmZpdCgxYildKTtcclxuZm4gYWNvdXN0aWMobWF0ZXJpYWwsIHNlZWQgPSAxKSA9IG1hdGVyaWFsXHJcbiAgICAuZ3Jvb3ZlKHtzbmFyZTogOW1zLCByaW1zaG90OiA5bXMsIGhhdDogLTJtc30sIFsxLCAwLjkyLCAwLjk4LCAwLjldLCBncmlkID0gMS8yYilcclxuICAgIC5kcnVtX2ZlZWwoM21zLCAwLjA0NSwgc2VlZCk7XHJcbmZuIGNyZXNjZW5kb19yb2xsKGR1cmF0aW9uID0gMWIsIHZvaWNlID0gXCJzbmFyZVwiKSA9IG5vdGUoMzgsIGR1cmF0aW9uLCB2ZWxvY2l0eSA9IDAuMylcclxuICAgIC52b2ljZSh2b2ljZSlcclxuICAgIC5yb2xsKFwiYWxsXCIsIHN0ZXAgPSAxLzhiLCB0byA9IDAuOTIpO1xyXG4ifSx7Im5hbWUiOiJzdGQvaW5zdHJ1bWVudC5tdXoiLCJzb3VyY2UiOiJ1c2UgXCJzdGQvc2lnbmFsXCIgYXMgcztcclxuLy8gU3RhYmxlIHNvdXJjZS1ub3RlIHZhcmlhdGlvbiB1c2VzIGl0cyBkZWNsYXJlZCBuYXRpdmUgbm90ZS1jb250cm9sIGxhbmUuXHJcbmZuIHZhcmlhdGlvbihwYXR0ZXJuLCBzZWVkID0gMCwgc3RyZWFtID0gXCJ2YXJpYXRpb25cIikgPSBwYXR0ZXJuLm1hcF9ub3RlcyhmbihuKSA9PiB7XHJcbiAgICBsZXQgZXhpc3RpbmcgPSBtZXJnZSh7ZXhwcmVzc2lvbjoge319LCBuLmRhdGEpLmV4cHJlc3Npb247XHJcbiAgICB7XHJcbiAgICAgICAgZGF0YTogbWVyZ2Uobi5kYXRhLCB7XHJcbiAgICAgICAgICAgIGV4cHJlc3Npb246IG1lcmdlKGV4aXN0aW5nLCB7XHJcbiAgICAgICAgICAgICAgICAvLyBQcmVzZXJ2ZSBwcmVzc3VyZSBhbmQgb3RoZXIgYXV0aG9yZWQgZXhwcmVzc2lvbiBnZXN0dXJlcy5cclxuICAgICAgICAgICAgICAgIHZhcmlhdGlvbjpcclxuICAgICAgICAgICAgICAgICAgICAoa2V5ZWRfbm9pc2Uobi5rZXksIHNlZWQsIHN0cmVhbSkgKyAxKVxyXG4gICAgICAgICAgICAgICAgICAgIC8gMlxyXG4gICAgICAgICAgICB9KVxyXG4gICAgICAgIH0pXHJcbiAgICB9XHJcbn0pO1xyXG5cclxuLy8gTGFzdCBhdHRhY2sgd2luczsgZWFybGllciBub3RlLW9mZnMgY2Fubm90IHJlbGVhc2UgdGhlIGNvbnRpbnVlZCB2b2ljZS5cclxuZm4gbW9ubyhwYXRjaCwgZ2xpZGUgPSAwbXMsIHJldHJpZ2dlciA9IGZhbHNlKSA9IG1lcmdlKHBhdGNoLCB7XHJcbiAgICB2b2ljZV9tb2RlOiBpZiByZXRyaWdnZXIgeyBcInJldHJpZ2dlclwiIH0gZWxzZSB7IFwibGVnYXRvXCIgfSxcclxuICAgIGdsaWRlX21zOiBnbGlkZVxyXG59KTtcclxuXHJcbi8vIFJlY29yZGluZyBzZWxlY3Rpb24gaXMgaW5oZXJpdGVkOyBlbnZlbG9wZSBhbmQgb3V0cHV0IGdhaW4gYXJlIGV4cGxpY2l0IHNvdXJjZSBwb2xpY3kuXHJcbmZuIG1zX3RpbWUodmFsdWUpID0gaWYgdW5pdCh2YWx1ZSkgPT0gMXMgeyB2YWx1ZSB9IGVsc2UgeyB2YWx1ZSAqIDFtcyB9O1xyXG5mbiBzYW1wbGVkKHNvdXJjZSwgdG9uZSA9IDEyMDAwSHosIG9wdGlvbnMgPSB7fSkge1xyXG4gICAgbGV0IHAgPSBtZXJnZSh7YXR0YWNrX21zOiAyLCByZWxlYXNlX21zOiAzNSwgZ2Fpbl9kYjogMCwgdmVsb2NpdHlfdHJhY2s6IDF9LCBzb3VyY2UpO1xyXG4gICAgbGV0IGUgPSBzLm1zZWcoXHJcbiAgICAgICAgW3t0aW1lOiBtc190aW1lKHAuYXR0YWNrX21zKSwgdG86IDF9XSxcclxuICAgICAgICBbe3RpbWU6IG1zX3RpbWUocC5yZWxlYXNlX21zKSwgdG86IDB9XSxcclxuICAgICAgICBzdXN0YWluID0gMFxyXG4gICAgKTtcclxuICAgIGxldCBwYWlyID0gcy5zdGVyZW8oXHJcbiAgICAgICAgcy5maWx0ZXIocy5yZWFkZXIoc291cmNlLCBcImxlZnRcIiksIHRvbmUpLFxyXG4gICAgICAgIHMuZmlsdGVyKHMucmVhZGVyKHNvdXJjZSwgXCJyaWdodFwiKSwgdG9uZSlcclxuICAgICk7XHJcbiAgICB2b2ljZV9wYXRjaChcclxuICAgICAgICBcInNhbXBsZWRcIixcclxuICAgICAgICBtZXJnZSh7XHJcbiAgICAgICAgICAgIGdhaW5fZGI6IHAuZ2Fpbl9kYixcclxuICAgICAgICAgICAgdmVsb2NpdHlfdHJhY2s6IHAudmVsb2NpdHlfdHJhY2ssXHJcbiAgICAgICAgICAgIG91dHB1dDogcy5zdGVyZW9fbXVsKHBhaXIsIGUpLFxyXG4gICAgICAgICAgICBsaWZldGltZToge2VudmVsb3BlOiBlLCB0YWlsOiAwc31cclxuICAgICAgICB9LCBvcHRpb25zKVxyXG4gICAgKVxyXG59O1xyXG5mbiBjcm9zc2ZhZGUoYSwgYiwgY29udHJvbCkgPSBzLmFkZChbXHJcbiAgICBzLm11bChbYSwgcy5hZGQoWzEsIHMubXVsKFtjb250cm9sLCAtMV0pXSldKSxcclxuICAgIHMubXVsKFtiLCBjb250cm9sXSlcclxuXSk7XHJcbi8vIEJ1aWxkIGFuIGluZGVwZW5kZW50IHJlbGVhc2UgbGFuZSB1c2luZyBwZXJmb3JtZWQgZW5kcywgaW5jbHVkaW5nIHJlbGVhc2Ugb2Zmc2V0cy5cclxuZm4gcmVsZWFzZXMocGF0dGVybiwgZHVyYXRpb24gPSAxMDBtcywgdGltaW5nID0ge30pID0gc3RhY2soXHJcbiAgICBtYXAocGF0dGVybi5ub3RlcywgZm4obikgPT4ge1xyXG4gICAgICAgIGxldCBhdCA9IHNlY29uZHNfYXQobi5hdCArIG4uZHVyYXRpb24gKiBuLmdhdGUsIHRpbWluZykgKyBuLm9mZnNldCArIG4ucmVsZWFzZV9vZmZzZXQ7XHJcbiAgICAgICAgbm90ZShuLnBpdGNoLCAxYiwgdmVsb2NpdHkgPSBuLnZlbG9jaXR5KVxyXG4gICAgICAgICAgICAuZ2F0ZSgxKVxyXG4gICAgICAgICAgICAubWFwX25vdGVzKGZuKHIpID0+IHtcclxuICAgICAgICAgICAgICAgIGR1cmF0aW9uOiAxYixcclxuICAgICAgICAgICAgICAgIG9mZnNldDogYXQsXHJcbiAgICAgICAgICAgICAgICByZWxlYXNlX29mZnNldDogZHVyYXRpb24gLSAoc2Vjb25kc19hdCgxYiwgdGltaW5nKSAtIHNlY29uZHNfYXQoMGIsIHRpbWluZykpXHJcbiAgICAgICAgICAgIH0pXHJcbiAgICB9KVxyXG4pO1xyXG5cclxuLy8gQSBzb3VyY2UgcGFja2FnZSBrZWVwcyBwcm9jZXNzaW5nIGFuZCBtYWNyb3Mgd2l0aCBhIHJldXNhYmxlIGluc3RydW1lbnQuXHJcbmZuIHNvdW5kKGluc3RydW1lbnQsIGNoYWluID0gW10sIHJhbmdlID0gWzM2LCA4NF0sIG1hY3JvcyA9IHt9KSA9IHtcclxuICAgIGluc3RydW1lbnQ6IGluc3RydW1lbnQsXHJcbiAgICBjaGFpbjogY2hhaW4sXHJcbiAgICByYW5nZTogcmFuZ2UsXHJcbiAgICBtYWNyb3M6IG1hY3Jvc1xyXG59O1xyXG5mbiBwbGF5KGlkLCBtYXRlcmlhbCwgc291bmQsIG9wdGlvbnMgPSB7fSkgPSB0cmFjayhcclxuICAgIGlkLFxyXG4gICAgbWF0ZXJpYWwsXHJcbiAgICBzb3VuZC5pbnN0cnVtZW50LFxyXG4gICAgbWVyZ2Uoe2NoYWluOiBzb3VuZC5jaGFpbn0sIG9wdGlvbnMpXHJcbik7XHJcbi8vIEVhY2ggbWFjcm8gbWFwcyBvbmUgbm9ybWFsaXplZCBjdXJ2ZSB0byBvbmUgb3IgbW9yZSBleGlzdGluZyB0YXJnZXQgbGFuZXMuXHJcbmZuIGF1dG9tYXRlKGlkLCBzb3VuZCwgbmFtZSwgdmFsdWVzKSA9IG1hcChcclxuICAgIHNvdW5kLm1hY3Jvc1tuYW1lXSxcclxuICAgIGZuKG1hcHBpbmcpID0+IGF1dG9tYXRpb24oXHJcbiAgICAgICAgZm9ybWF0KFwie30ue31cIiwgW2lkLCBtYXBwaW5nLnRhcmdldF0pLFxyXG4gICAgICAgIGN1cnZlX21hcCh2YWx1ZXMsIGZuKHgpID0+IG1hcHBpbmcub2Zmc2V0ICsgbWFwcGluZy5zY2FsZSAqIHgpXHJcbiAgICApXHJcbik7XHJcbiJ9LHsibmFtZSI6InN0ZC9taXgubXV6Iiwic291cmNlIjoiZm4gY2xlYW4obG93Y3V0ID0gMTAwKSA9IFtmeChcImhpZ2hwYXNzXCIsIHtjdXRvZmZfaHo6IGxvd2N1dCwgcmVzb25hbmNlOiAwLjcwN30pXTtcclxuZm4gc3BhY2UoZGVjYXkgPSAyLjUpID0gW2Z4KFwicmV2ZXJiXCIsIHtkZWNheV9zOiBkZWNheSwgbWl4OiAxfSldO1xyXG4vLyBUaGUgcmFjaydzIGFtb3VudCBjYW4gYmUgYXV0b21hdGVkIGFzIFRSQUNLLlJBQ0tfSUQubWl4LlxyXG5mbiBwYXJhbGxlbF9jb21wcmVzc2lvbihhbW91bnQgPSAwLjI1KSA9IHJhY2soXHJcbiAgICBbXHJcbiAgICAgICAgW1xyXG4gICAgICAgICAgICBmeChcImNvbXByZXNzb3JcIiwge3RocmVzaG9sZF9kYjogLTI1LCByYXRpbzogNiwgYXR0YWNrX21zOiAxNSwgcmVsZWFzZV9tczogMTIwfSksXHJcbiAgICAgICAgICAgIGZ4KFwiZ2FpblwiLCB7Z2Fpbl9kYjogOH0pXHJcbiAgICAgICAgXVxyXG4gICAgXSxcclxuICAgIHttaXg6IGFtb3VudH1cclxuKTtcclxuZm4gdHJlbW9sbyhyYXRlID0gMiwgZGVwdGggPSAzKSA9IHJhY2soXHJcbiAgICBbW2Z4KFwiZ2FpblwiKV1dLFxyXG4gICAge1xyXG4gICAgICAgIG1vZHVsYXRlOiBbXHJcbiAgICAgICAgICAgIHt0YXJnZXQ6IFwiMC4wLmdhaW5fZGJcIiwgYmFzZTogLWRlcHRoLCBkZXB0aDogZGVwdGgsIHJhdGVfaHo6IHJhdGUsIG1pbjogLTI0LCBtYXg6IDB9XHJcbiAgICAgICAgXVxyXG4gICAgfVxyXG4pO1xyXG5mbiBhdXRvX2ZpbHRlcihiYXNlID0gNDAwLCBzZW5zaXRpdml0eSA9IDUwMDApID0gcmFjayhcclxuICAgIFtbZngoXCJsb3dwYXNzXCIpXV0sXHJcbiAgICB7XHJcbiAgICAgICAgbW9kdWxhdGU6IFtcclxuICAgICAgICAgICAge1xyXG4gICAgICAgICAgICAgICAgdGFyZ2V0OiBcIjAuMC5jdXRvZmZfaHpcIixcclxuICAgICAgICAgICAgICAgIGJhc2U6IGJhc2UsXHJcbiAgICAgICAgICAgICAgICBmb2xsb3dlcjogc2Vuc2l0aXZpdHksXHJcbiAgICAgICAgICAgICAgICBhdHRhY2tfbXM6IDUsXHJcbiAgICAgICAgICAgICAgICByZWxlYXNlX21zOiAxNTAsXHJcbiAgICAgICAgICAgICAgICBtaW46IDMwLFxyXG4gICAgICAgICAgICAgICAgbWF4OiAxODAwMFxyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgXVxyXG4gICAgfVxyXG4pO1xyXG5mbiBtYXN0ZXIoKSA9IFtcclxuICAgIGZ4KFwiaGlnaHBhc3NcIiwge2N1dG9mZl9oejogMjUsIHJlc29uYW5jZTogMC43MDd9KSxcclxuICAgIGZ4KFwiY29tcHJlc3NvclwiLCB7dGhyZXNob2xkX2RiOiAtMTYsIHJhdGlvOiAxLjUsIGF0dGFja19tczogMzAsIHJlbGVhc2VfbXM6IDE4MH0pLFxyXG4gICAgZngoXCJsaW1pdGVyXCIsIHtjZWlsaW5nX2RiOiAtMS41LCBsb29rYWhlYWRfbXM6IDV9KVxyXG5dO1xyXG5cclxuLy8gVGltaW5nIGFuZCBlbnZlbG9wZSBwb2xpY2llcyBiZWxvdyBhcmUgb3JkaW5hcnkgc291cmNlOyBwcm9qZWN0cyBjYW4gcmVwbGFjZSB0aGVtLlxyXG5mbiBub3RlX3N0YXJ0KG4sIHRpbWluZyA9IHt9KSA9IHNlY29uZHNfYXQobi5hdCwgdGltaW5nKSArIG4ub2Zmc2V0O1xyXG5mbiBub3RlX2VuZChuLCB0aW1pbmcgPSB7fSkgPVxyXG4gICAgc2Vjb25kc19hdChuLmF0ICsgbi5kdXJhdGlvbiAqIG4uZ2F0ZSwgdGltaW5nKVxyXG4gICAgKyBuLm9mZnNldFxyXG4gICAgKyBuLnJlbGVhc2Vfb2Zmc2V0O1xyXG5cclxuLy8gQ29uc3RhbnQtbGV2ZWwgd2luZG93cyB3aXRoIHVuaW9uIG9uIG92ZXJsYXAuIE90aGVyIG92ZXJsYXAgcG9saWNpZXMgYmVsb25nIHRvXHJcbi8vIHRoZSBhdXRob3I6IGJ1aWxkIHBvaW50cyBkaXJlY3RseSwgb3IgY29tYmluZSBjdXJ2ZXMgdXNpbmcgY3VydmVfYWRkL2N1cnZlX211bC5cclxuZm4gd2luZG93X3N0ZXAocywgdywgbGV2ZWwsIGJhc2UpID0gaWYgcy5hY3RpdmUgJiYgd1swXSA8PSBzLmVuZCB7XHJcbiAgICBtZXJnZShzLCB7ZW5kOiBpZiB3WzFdID4gcy5lbmQgeyB3WzFdIH0gZWxzZSB7IHMuZW5kIH19KVxyXG59IGVsc2Uge1xyXG4gICAge1xyXG4gICAgICAgIHBvaW50czogcy5wb2ludHMgKyBpZiBzLmFjdGl2ZSB7IFtbcy5zdGFydCwgbGV2ZWxdLCBbcy5lbmQsIGJhc2VdXSB9IGVsc2UgeyBbXSB9LFxyXG4gICAgICAgIHN0YXJ0OiBpZiB3WzBdIDwgMHMgeyAwcyB9IGVsc2UgeyB3WzBdIH0sXHJcbiAgICAgICAgZW5kOiB3WzFdLFxyXG4gICAgICAgIGFjdGl2ZTogdHJ1ZVxyXG4gICAgfVxyXG59O1xyXG5mbiBnYXRlX3dpbmRvd3Mod2luZG93cywgbGV2ZWwgPSAtMTIsIGJhc2UgPSAtMTIwLCBzdGFydCA9IDBzKSB7XHJcbiAgICBsZXQgb3JkZXJlZCA9IHNvcnRfYnkoXHJcbiAgICAgICAgbWFwKGZpbHRlcih3aW5kb3dzLCBmbih3KSA9PiB3WzFdID4gc3RhcnQgJiYgd1sxXSA+IHdbMF0pLCBmbih3KSA9PiBbXHJcbiAgICAgICAgICAgIG1heChzdGFydCwgd1swXSksXHJcbiAgICAgICAgICAgIHdbMV1cclxuICAgICAgICBdKSxcclxuICAgICAgICBmbih3KSA9PiB3WzBdXHJcbiAgICApO1xyXG4gICAgbGV0IGluaXRpYWwgPSB7cG9pbnRzOiBbXSwgc3RhcnQ6IDBzLCBlbmQ6IDBzLCBhY3RpdmU6IGZhbHNlfTtcclxuICAgIGxldCByZXN1bHQgPSBmb2xkKG9yZGVyZWQsIGluaXRpYWwsIGZuKHMsIHcpID0+IHdpbmRvd19zdGVwKHMsIHcsIGxldmVsLCBiYXNlKSk7XHJcbiAgICBsZXQgcG9pbnRzID1cclxuICAgICAgICByZXN1bHQucG9pbnRzXHJcbiAgICAgICAgKyBpZiByZXN1bHQuYWN0aXZlIHsgW1tyZXN1bHQuc3RhcnQsIGxldmVsXSwgW3Jlc3VsdC5lbmQsIGJhc2VdXSB9IGVsc2UgeyBbXSB9O1xyXG4gICAgY3VydmUoXHJcbiAgICAgICAgaWYgbGVuKHBvaW50cykgPT0gMCB7XHJcbiAgICAgICAgICAgIFtbc3RhcnQsIGJhc2VdXVxyXG4gICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIGlmIHBvaW50c1swXVswXSA+IHN0YXJ0IHsgW1tzdGFydCwgYmFzZV1dICsgcG9pbnRzIH0gZWxzZSB7IHBvaW50cyB9XHJcbiAgICAgICAgfSxcclxuICAgICAgICBcInN0ZXBcIlxyXG4gICAgKVxyXG59XHJcblxyXG5mbiB0aHJvd3MobWF0ZXJpYWwsIHNlbGVjdG9yLCB0YXJnZXQsIGxldmVsID0gLTEyLCB0YWlsID0gMTIwbXMsIHRpbWluZyA9IHt9LCBzdGFydCA9IDBzKSA9XHJcbiAgICBhdXRvbWF0aW9uKFxyXG4gICAgICAgIHRhcmdldCxcclxuICAgICAgICBnYXRlX3dpbmRvd3MoXHJcbiAgICAgICAgICAgIG1hcChtYXRlcmlhbC5zZWxlY3Qoc2VsZWN0b3IpLm5vdGVzLCBmbihuKSA9PiBbXHJcbiAgICAgICAgICAgICAgICBub3RlX3N0YXJ0KG4sIHRpbWluZyksXHJcbiAgICAgICAgICAgICAgICBub3RlX2VuZChuLCB0aW1pbmcpICsgdGFpbFxyXG4gICAgICAgICAgICBdKSxcclxuICAgICAgICAgICAgbGV2ZWwsXHJcbiAgICAgICAgICAgIHN0YXJ0ID0gc3RhcnRcclxuICAgICAgICApXHJcbiAgICApO1xyXG4ifSx7Im5hbWUiOiJzdGQvbXVzaWMubXV6Iiwic291cmNlIjoiLy8gTXVzaWNhbCBwb2xpY3kgaXMgb3JkaW5hcnksIHJldXNhYmxlIHNvdXJjZS4gQWxsIGZ1bmN0aW9ucyBhcmUgYXZhaWxhYmxlIHRvIHByb2plY3RzLlxyXG5mbiBvc3RpbmF0byhjaGFuZ2VzLCBvcmRlciA9IFswLCAyLCAxLCAyXSwgc3RlcCA9IDEvMmIpID0gYXJwZWdnaWF0ZShjaGFuZ2VzLCBvcmRlciwgc3RlcCk7XHJcbmZuIGFuc3dlcih0aGVtZSwgaW50ZXJ2YWwgPSAwKSA9IHRoZW1lLnRyYW5zcG9zZShpbnRlcnZhbCkucmV2ZXJzZSgpO1xyXG5mbiByZXByaXNlKHRoZW1lLCByZXBlYXRzID0gMiwgbGlmdCA9IDApID0gdGhlbWUucmVwZWF0KHJlcGVhdHMpLnRyYW5zcG9zZShsaWZ0KTtcclxuZm4gc3dlbGwobWF0ZXJpYWwsIGZyb20gPSAwLjQ1LCB0byA9IDAuOCkgPSBtYXRlcmlhbC5keW5hbWljcyhmcm9tLCB0byk7XHJcbmZuIHNpbmdpbmcobWF0ZXJpYWwpID0gbWF0ZXJpYWwuZ2F0ZSgwLjk1KS5odW1hbml6ZSg0bXMsIDAuMDI1KTtcclxuZm4gcGlhbm9faGFuZHMocmlnaHQsIGxlZnQpID0gc3RhY2soW3JpZ2h0LmhhbmQoXCJyaWdodFwiKSwgbGVmdC5oYW5kKFwibGVmdFwiKV0pO1xyXG5mbiBoYXJtb255X3BlZGFsKGNoYW5nZXMsIGRlcHRoID0gMC42NSkgPSBwZWRhbChjaGFuZ2VzLCBkZXB0aCk7XHJcbmZuIGVjaG9fZW5kKG1hdGVyaWFsKSA9IG1hdGVyaWFsLnRhZyhcImxhc3RcIiwgXCJlY2hvXCIpO1xyXG4ifSx7Im5hbWUiOiJzdGQvcGF0dGVybnMubXV6Iiwic291cmNlIjoiLy8gUmh5dGhtaWMgYW5kIG5vdGUtc2VsZWN0aW9uIHBvbGljaWVzIG92ZXIgZ2VuZXJhbCBwYXR0ZXJuIHRyYW5zZm9ybWF0aW9ucy5cclxuZm4gc3dpbmcocGF0dGVybiwgcmF0aW8gPSAwLjU3LCBncmlkID0gMS8yYikge1xyXG4gICAgYXNzZXJ0KFxyXG4gICAgICAgIHJhdGlvID49IDAuNSAmJiByYXRpbyA8PSAwLjggJiYgZ3JpZCA+IDBiLFxyXG4gICAgICAgIFwic3dpbmcgbmVlZHMgcmF0aW8gMC41Li4wLjggYW5kIGEgcG9zaXRpdmUgZ3JpZFwiXHJcbiAgICApO1xyXG4gICAgcGF0dGVybi5tYXBfbm90ZXMoZm4obikgPT4ge1xyXG4gICAgICAgIGxldCBwb3NpdGlvbiA9IG4uYXQgLyBncmlkO1xyXG4gICAgICAgIGxldCB0aWNrID0gcm91bmQocG9zaXRpb24pO1xyXG4gICAgICAgIHtcclxuICAgICAgICAgICAgYXQ6XHJcbiAgICAgICAgICAgICAgICBuLmF0XHJcbiAgICAgICAgICAgICAgICArIGlmIGFicyhwb3NpdGlvbiAtIHRpY2spIDwgMC4wMDAwMDEgJiYgYWJzKHRpY2sgJSAyKSA9PSAxIHtcclxuICAgICAgICAgICAgICAgICAgICAocmF0aW8gKiAyIC0gMSkgKiBncmlkXHJcbiAgICAgICAgICAgICAgICB9IGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgICAgIDBiXHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG4gICAgfSlcclxufVxyXG5cclxuZm4gYXJwZWdnaWF0ZShoYXJtb255LCBvcmRlciA9IFswLCAyLCAxLCAyXSwgc3RlcCA9IDEvMmIpIHtcclxuICAgIGFzc2VydChzdGVwID4gMGIgJiYgbGVuKG9yZGVyKSA+IDAsIFwiYXJwZWdnaWF0b3IgbmVlZHMgcG9zaXRpdmUgc3RlcCBhbmQgbm9uZW1wdHkgb3JkZXJcIik7XHJcbiAgICBtYXAoXHJcbiAgICAgICAgb3JkZXIsXHJcbiAgICAgICAgZm4oaW5kZXgpID0+IGFzc2VydChpbmRleCA9PSBmbG9vcihpbmRleCksIFwiYXJwZWdnaWF0b3Igb3JkZXIgbmVlZHMgaW50ZWdlciBpbmRpY2VzXCIpXHJcbiAgICApO1xyXG4gICAgbGV0IGdyb3VwcyA9IHNvcnRfYnkoZ3JvdXBfYnkoaGFybW9ueS5ub3RlcywgZm4obikgPT4gbi5hdCksIGZuKGdyb3VwKSA9PiBncm91cFswXS5hdCk7XHJcbiAgICBsZXQgc3BhbnMgPSBtYXAocmFuZ2UobGVuKGdyb3VwcykpLCBmbihpKSA9PiB7XHJcbiAgICAgICAgbGV0IGNob3JkID0gc29ydF9ieShncm91cHNbaV0sIGZuKG4pID0+IG4ucGl0Y2gpO1xyXG4gICAgICAgIGxldCBzdGFydCA9IGNob3JkWzBdLmF0O1xyXG4gICAgICAgIGxldCBlbmQgPSBpZiBpICsgMSA8IGxlbihncm91cHMpIHsgZ3JvdXBzW2kgKyAxXVswXS5hdCB9IGVsc2UgeyBoYXJtb255LnNwYW4gfTtcclxuICAgICAgICB7Y2hvcmQ6IGNob3JkLCBzdGFydDogc3RhcnQsIGVuZDogZW5kLCBjb3VudDogbWF4KDAsIC1mbG9vcigtKGVuZCAtIHN0YXJ0KSAvIHN0ZXApKX1cclxuICAgIH0pO1xyXG4gICAgYXNzZXJ0KFxyXG4gICAgICAgIGZvbGQoc3BhbnMsIDAsIGZuKHRvdGFsLCBncm91cCkgPT4gdG90YWwgKyBncm91cC5jb3VudCkgPD0gMjAwMDAwLFxyXG4gICAgICAgIFwiYXJwZWdnaW8gZXhjZWVkcyBldmVudCBidWRnZXRcIlxyXG4gICAgKTtcclxuICAgIGxldCBwYXRjaGVzID0gZm9sZChcclxuICAgICAgICBtYXAocmFuZ2UobGVuKHNwYW5zKSksIGZuKGkpID0+IHtcclxuICAgICAgICAgICAgbGV0IGdyb3VwID0gc3BhbnNbaV07XHJcbiAgICAgICAgICAgIG1hcChyYW5nZShncm91cC5jb3VudCksIGZuKGopID0+IHtcclxuICAgICAgICAgICAgICAgIGxldCBrID0gb3JkZXJbaiAlIGxlbihvcmRlcildO1xyXG4gICAgICAgICAgICAgICAgbGV0IG9jdGF2ZSA9IGZsb29yKGsgLyBsZW4oZ3JvdXAuY2hvcmQpKTtcclxuICAgICAgICAgICAgICAgIGxldCBpbmRleCA9IGsgLSBvY3RhdmUgKiBsZW4oZ3JvdXAuY2hvcmQpO1xyXG4gICAgICAgICAgICAgICAgbGV0IG9yaWdpbmFsID0gZ3JvdXAuY2hvcmRbaW5kZXhdO1xyXG4gICAgICAgICAgICAgICAgbGV0IGF0ID0gZ3JvdXAuc3RhcnQgKyBqICogc3RlcDtcclxuICAgICAgICAgICAgICAgIG1lcmdlKG9yaWdpbmFsLCB7XHJcbiAgICAgICAgICAgICAgICAgICAgcGl0Y2g6IG9yaWdpbmFsLnBpdGNoICsgMTIgKiBvY3RhdmUsXHJcbiAgICAgICAgICAgICAgICAgICAgYXQ6IGF0LFxyXG4gICAgICAgICAgICAgICAgICAgIGR1cmF0aW9uOiBtaW4oc3RlcCwgZ3JvdXAuZW5kIC0gYXQpLFxyXG4gICAgICAgICAgICAgICAgICAgIGtleTogb3JpZ2luYWwua2V5ICsgXCIvYXJwXCIgKyBzdHIoaSkgKyBcIi5cIiArIHN0cihqKVxyXG4gICAgICAgICAgICAgICAgfSlcclxuICAgICAgICAgICAgfSlcclxuICAgICAgICB9KSxcclxuICAgICAgICBbXSxcclxuICAgICAgICBmbihvdXQsIGdyb3VwKSA9PiBvdXQgKyBncm91cFxyXG4gICAgKTtcclxuICAgIGlmIGxlbihoYXJtb255Lm5vdGVzKSA9PSAwIHtcclxuICAgICAgICBoYXJtb255XHJcbiAgICB9IGVsc2Uge1xyXG4gICAgICAgIGxldCBmaXJzdCA9IGhhcm1vbnkubm90ZXNbMF0ua2V5O1xyXG4gICAgICAgIGhhcm1vbnkuZmxhdF9tYXBfbm90ZXMoZm4obikgPT4gaWYgbi5rZXkgPT0gZmlyc3QgeyBwYXRjaGVzIH0gZWxzZSB7IFtdIH0pXHJcbiAgICB9XHJcbn1cclxuXHJcbi8vIENvbnRleHQgaXMgYWx3YXlzIGRyYXduIGZyb20gdGhlIG9yaWdpbmFsIG5vdGVzLiBWb2ljZSBsYWJlbHMgZGVzY3JpYmUgcnVucztcclxuLy8gc2ltdWx0YW5lb3VzIHVudm9pY2VkIG5vdGVzIHJlbWFpbiBvbmUgc3RhYmxlLCBleHBsaWNpdGx5IG9yZGVyZWQgcnVuLlxyXG5mbiBtYXBfbm90ZV9ydW5zKHBhdHRlcm4sIGZ1bmN0aW9uLCBydW4gPSBmbihuKSA9PiBuLnZvaWNlKSB7XHJcbiAgICBsZXQgb3JpZ2luYWwgPSBtYXAocGF0dGVybi5ub3RlcywgZm4obikgPT4ge25vdGU6IG4sIHJ1bjogcnVuKG4pfSk7XHJcbiAgICBsZXQgZ3JvdXBzID0gZ3JvdXBfYnkob3JpZ2luYWwsIGZuKGl0ZW0pID0+IGl0ZW0ucnVuKTtcclxuICAgIGxldCByZXN1bHRzID0gbWFwKGdyb3VwcywgZm4oZ3JvdXApID0+IHtcclxuICAgICAgICBsZXQgb3JkZXJlZCA9IHNvcnRfYnkoZ3JvdXAsIGZuKGl0ZW0pID0+IGl0ZW0ubm90ZS5hdCk7XHJcbiAgICAgICAgbGV0IGNvdW50ID0gbGVuKG9yZGVyZWQpO1xyXG4gICAgICAgIG1hcChyYW5nZShjb3VudCksIGZuKGkpID0+IHtcclxuICAgICAgICAgICAgbGV0IG4gPSBvcmRlcmVkW2ldLm5vdGU7XHJcbiAgICAgICAgICAgIHtcclxuICAgICAgICAgICAgICAgIGtleTogbi5rZXksXHJcbiAgICAgICAgICAgICAgICBwYXRjaDogZnVuY3Rpb24oe1xyXG4gICAgICAgICAgICAgICAgICAgIG5vdGU6IG4sXHJcbiAgICAgICAgICAgICAgICAgICAgcHJldmlvdXM6IGlmIGkgPiAwIHsgb3JkZXJlZFtpIC0gMV0ubm90ZSB9IGVsc2UgeyBudWxsIH0sXHJcbiAgICAgICAgICAgICAgICAgICAgbmV4dDogaWYgaSArIDEgPCBjb3VudCB7IG9yZGVyZWRbaSArIDFdLm5vdGUgfSBlbHNlIHsgbnVsbCB9LFxyXG4gICAgICAgICAgICAgICAgICAgIHJ1bjogb3JkZXJlZFtpXS5ydW4sXHJcbiAgICAgICAgICAgICAgICAgICAgaW5kZXg6IGksXHJcbiAgICAgICAgICAgICAgICAgICAgY291bnQ6IGNvdW50XHJcbiAgICAgICAgICAgICAgICB9KVxyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfSlcclxuICAgIH0pO1xyXG4gICAgLy8gUGFzcyB0aGUgaGVscGVyIHRvIGl0c2VsZjogbGV4aWNhbCBmdW5jdGlvbiBiaW5kaW5ncyBkbyBub3QgaW1wbGljaXRseVxyXG4gICAgLy8gY2FwdHVyZSB0aGVpciBvd24gbmFtZXMuIEJhbGFuY2VkIGpvaW5zIGF2b2lkIGNvcHlpbmcgYSBncm93aW5nIHByZWZpeFxyXG4gICAgLy8gZm9yIGV2ZXJ5IHNpbmdsZXRvbiBydW4sIGFuZCBrZWVwIHJlY3Vyc2lvbiBsb2dhcml0aG1pYy5cclxuICAgIGZuIGpvaW5fcmFuZ2VzKHNlbGYsIGJlZ2luLCBlbmQpIHtcclxuICAgICAgICBpZiBiZWdpbiA9PSBlbmQge1xyXG4gICAgICAgICAgICBbXVxyXG4gICAgICAgIH0gZWxzZSB7XHJcbiAgICAgICAgICAgIGlmIGVuZCAtIGJlZ2luID09IDEge1xyXG4gICAgICAgICAgICAgICAgcmVzdWx0c1tiZWdpbl1cclxuICAgICAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgICAgIGxldCBtaWRkbGUgPSBmbG9vcigoYmVnaW4gKyBlbmQpIC8gMik7XHJcbiAgICAgICAgICAgICAgICBzZWxmKHNlbGYsIGJlZ2luLCBtaWRkbGUpICsgc2VsZihzZWxmLCBtaWRkbGUsIGVuZClcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH1cclxuICAgIH1cclxuICAgIGxldCBieV9rZXkgPSBpbmRleF9ieShqb2luX3Jhbmdlcyhqb2luX3JhbmdlcywgMCwgbGVuKHJlc3VsdHMpKSwgZm4oaXRlbSkgPT4gaXRlbS5rZXkpO1xyXG4gICAgcGF0dGVybi5tYXBfbm90ZXMoZm4obikgPT4gYnlfa2V5W24ua2V5XS5wYXRjaClcclxufVxyXG4ifSx7Im5hbWUiOiJzdGQvcGVyZm9ybWFuY2UubXV6Iiwic291cmNlIjoiLy8gUGVyZm9ybWFuY2UgY2hvaWNlcyBhcmUgc291cmNlIHBvbGljaWVzIG92ZXIgbG9zc2xlc3MgZXZlbnQgdHJhbnNmb3JtYXRpb25zLlxyXG5mbiBzY2FsZV9nYXRlKHBhdHRlcm4sIGZhY3Rvcikge1xyXG4gICAgYXNzZXJ0KGZhY3RvciA+IDAsIFwic2NhbGVfZ2F0ZSByZXF1aXJlcyBhIHBvc2l0aXZlIGZpbml0ZSB2YWx1ZVwiKTtcclxuICAgIHBhdHRlcm4ubWFwX25vdGVzKGZuKG4pID0+IHtnYXRlOiBuLmdhdGUgKiBmYWN0b3J9KVxyXG59O1xyXG5mbiBkeW5hbWljcyhwYXR0ZXJuLCBmcm9tID0gMC40NSwgdG8gPSAwLjg1KSA9IHBhdHRlcm4ubWFwX25vdGVzKGZuKG4pID0+IHtcclxuICAgIHZlbG9jaXR5OiBtYXgoMC4wMDEsIG1pbigxLCBmcm9tICsgKHRvIC0gZnJvbSkgKiBuLmF0IC8gbWF4KHBhdHRlcm4uc3BhbiwgMS8xMDAwYikpKVxyXG59KTtcclxuZm4gaHVtYW5pemUocGF0dGVybiwgdGltaW5nID0gNG1zLCB2ZWxvY2l0eSA9IDAuMDI1LCBzZWVkID0gMCkgPSBwYXR0ZXJuLm1hcF9ub3RlcyhmbihuKSA9PiB7XHJcbiAgICBsZXQgZ3JvdXAgPSBbbi52b2ljZSwgbi5hdF07XHJcbiAgICBsZXQgZGVsdGEgPSAoMC44NSAqIGtleWVkX25vaXNlKGdyb3VwLCBzZWVkKSArIDAuMTUgKiBrZXllZF9ub2lzZShuLmtleSwgc2VlZCkpICogdGltaW5nO1xyXG4gICAge1xyXG4gICAgICAgIG9mZnNldDogbi5vZmZzZXQgKyBpZiBjb250YWlucyhuLnRhZ3MsIFwiZml4ZWRcIikgeyAwbXMgfSBlbHNlIHsgZGVsdGEgfSxcclxuICAgICAgICB2ZWxvY2l0eTogbWF4KFxyXG4gICAgICAgICAgICAwLjAxLFxyXG4gICAgICAgICAgICBtaW4oXHJcbiAgICAgICAgICAgICAgICAxLFxyXG4gICAgICAgICAgICAgICAgbi52ZWxvY2l0eVxyXG4gICAgICAgICAgICAgICAgKyB2ZWxvY2l0eVxyXG4gICAgICAgICAgICAgICAgKiAoXHJcbiAgICAgICAgICAgICAgICAgICAgMC42NSAqIGtleWVkX25vaXNlKGdyb3VwLCBzZWVkLCBcInZlbG9jaXR5XCIpXHJcbiAgICAgICAgICAgICAgICAgICAgKyAwLjM1ICoga2V5ZWRfbm9pc2Uobi5rZXksIHNlZWQsIFwidmVsb2NpdHlcIilcclxuICAgICAgICAgICAgICAgIClcclxuICAgICAgICAgICAgKVxyXG4gICAgICAgIClcclxuICAgIH1cclxufSk7XHJcbi8vIEEgZGlzcGxhY2VtZW50IGluIHNlY29uZHMgbW92ZXMgbm90ZS1vbiwgZ2F0ZWQgbm90ZS1vZmYsIENDIGFuZCByYXcgTUlESSB0b2dldGhlci5cclxuZm4gZGlzcGxhY2UocGF0dGVybiwgZnVuY3Rpb24pID0gcGF0dGVyblxyXG4gICAgLm1hcF9ub3RlcyhmbihuKSA9PiB7XHJcbiAgICAgICAgbGV0IG9uc2V0ID0gZnVuY3Rpb24obi5hdCk7XHJcbiAgICAgICAgbGV0IHJlbGVhc2UgPSBmdW5jdGlvbihuLmF0ICsgbi5kdXJhdGlvbiAqIG4uZ2F0ZSk7XHJcbiAgICAgICAge29mZnNldDogbi5vZmZzZXQgKyBvbnNldCwgcmVsZWFzZV9vZmZzZXQ6IG4ucmVsZWFzZV9vZmZzZXQgKyByZWxlYXNlIC0gb25zZXR9XHJcbiAgICB9KVxyXG4gICAgLm1hcF9jb250cm9scyhmbihjKSA9PiB7b2Zmc2V0OiBjLm9mZnNldCArIGZ1bmN0aW9uKGMuYXQpfSlcclxuICAgIC5tYXBfcmF3KGZuKHIpID0+IHtvZmZzZXQ6IHIub2Zmc2V0ICsgZnVuY3Rpb24oci5hdCl9KTtcclxuZm4gcnViYXRvKHBhdHRlcm4sIGFtb3VudCA9IDI1bXMpIHtcclxuICAgIGFzc2VydChcclxuICAgICAgICBwYXR0ZXJuLnNwYW4gPiAwYiAmJiAoYWJzKGFtb3VudCkgLyAxNTBtcykgKiA2LjI4MzE4NTMwNzE3OTU4NiAvIChwYXR0ZXJuLnNwYW4gLyAxYikgPCAxLFxyXG4gICAgICAgIFwicnViYXRvIG11c3QgcHJlc2VydmUgZm9yd2FyZCB0aW1lIGF0IGFsbCBzdXBwb3J0ZWQgdGVtcG9zOyByZWR1Y2UgdGhlIGFtb3VudCBvciBsZW5ndGhlbiB0aGUgcGhyYXNlXCJcclxuICAgICk7XHJcbiAgICBkaXNwbGFjZShcclxuICAgICAgICBwYXR0ZXJuLFxyXG4gICAgICAgIGZuKGF0KSA9PiAtc2luKG1heCgwLCBtaW4oMSwgYXQgLyBwYXR0ZXJuLnNwYW4pKSAqIDYuMjgzMTg1MzA3MTc5NTg2KSAqIGFtb3VudFxyXG4gICAgKVxyXG59O1xyXG5mbiBncm9vdmUocGF0dGVybiwgb2Zmc2V0cywgYWNjZW50cyA9IFsxXSwgZ3JpZCA9IDEvMmIpIHtcclxuICAgIGFzc2VydChcclxuICAgICAgICBncmlkID4gMGIgJiYgbGVuKGFjY2VudHMpID4gMCxcclxuICAgICAgICBcImludmFsaWQgZ3Jvb3ZlOiBwb3NpdGl2ZSBncmlkIGFuZCBub25lbXB0eSBhY2NlbnRzIHJlcXVpcmVkXCJcclxuICAgICk7XHJcbiAgICBtYXAoYWNjZW50cywgZm4odikgPT4gYXNzZXJ0KHYgPj0gMCAmJiB2IDw9IDIsIFwiZ3Jvb3ZlIGFjY2VudHMgbXVzdCBiZSAwLi4yXCIpKTtcclxuICAgIHBhdHRlcm4ubWFwX25vdGVzKGZuKG4pID0+IHtcclxuICAgICAgICBsZXQgbWF0Y2hlcyA9IGZpbHRlcihrZXlzKG9mZnNldHMpLCBmbihrKSA9PiBrID09IG4udm9pY2UpO1xyXG4gICAgICAgIGxldCBzaGlmdCA9IGlmIGxlbihtYXRjaGVzKSA9PSAwIHsgMG1zIH0gZWxzZSB7IG9mZnNldHNbbi52b2ljZV0gfTtcclxuICAgICAgICBhc3NlcnQoYWJzKHNoaWZ0KSA8PSAxMDBtcywgXCJncm9vdmUgb2Zmc2V0cyBtdXN0IGJlIHdpdGhpbiAxMDBtc1wiKTtcclxuICAgICAgICB7XHJcbiAgICAgICAgICAgIG9mZnNldDogbi5vZmZzZXQgKyBpZiBjb250YWlucyhuLnRhZ3MsIFwiZml4ZWRcIikgeyAwbXMgfSBlbHNlIHsgc2hpZnQgfSxcclxuICAgICAgICAgICAgdmVsb2NpdHk6IG1heCgwLjAwMSwgbWluKDEsIG4udmVsb2NpdHkgKiBhY2NlbnRzW3JvdW5kKG4uYXQgLyBncmlkKSAlIGxlbihhY2NlbnRzKV0pKVxyXG4gICAgICAgIH1cclxuICAgIH0pXHJcbn07XHJcbmZuIGRydW1fZmVlbChwYXR0ZXJuLCB0aW1pbmcgPSAzbXMsIHZhcmlhdGlvbiA9IDAuMDQ1LCBzZWVkID0gMCkge1xyXG4gICAgYXNzZXJ0KFxyXG4gICAgICAgIGFicyh0aW1pbmcpIDw9IDMwbXMgJiYgdmFyaWF0aW9uID49IDAgJiYgdmFyaWF0aW9uIDw9IDAuMyxcclxuICAgICAgICBcImRydW0gZmVlbCB0aW1pbmcgPD0zMG1zIGFuZCB2YXJpYXRpb24gMC4uMC4zXCJcclxuICAgICk7XHJcbiAgICBwYXR0ZXJuLm1hcF9ub3RlcyhmbihuKSA9PiB7XHJcbiAgICAgICAgbGV0IGdyb3VwID0ga2V5ZWRfbm9pc2UoW1wiYmFyXCIsIGZsb29yKG4uYXQgLyA0YildLCBzZWVkKTtcclxuICAgICAgICBsZXQgaGl0ID0ga2V5ZWRfbm9pc2Uobi5rZXksIHNlZWQpO1xyXG4gICAgICAgIGxldCByZWNvdmVyeSA9IGNvcygobi5hdCAvIDFiICUgMSkgKiA2LjI4MzE4NTMwNzE3OTU4Nik7XHJcbiAgICAgICAge1xyXG4gICAgICAgICAgICBvZmZzZXQ6XHJcbiAgICAgICAgICAgICAgICBuLm9mZnNldFxyXG4gICAgICAgICAgICAgICAgKyBpZiBjb250YWlucyhuLnRhZ3MsIFwiZml4ZWRcIikge1xyXG4gICAgICAgICAgICAgICAgICAgIDBtc1xyXG4gICAgICAgICAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgICAgICAgICB0aW1pbmcgKiAoMC42ICogZ3JvdXAgKyAwLjQgKiBoaXQpXHJcbiAgICAgICAgICAgICAgICB9LFxyXG4gICAgICAgICAgICB2ZWxvY2l0eTogbWF4KFxyXG4gICAgICAgICAgICAgICAgMC4wMDEsXHJcbiAgICAgICAgICAgICAgICBtaW4oMSwgbi52ZWxvY2l0eSAqICgxICsgdmFyaWF0aW9uICogKDAuNSAqIGdyb3VwICsgMC4zICogaGl0ICsgMC4yICogcmVjb3ZlcnkpKSlcclxuICAgICAgICAgICAgKVxyXG4gICAgICAgIH1cclxuICAgIH0pXHJcbn07XHJcbmZuIGZsYW0ocGF0dGVybiwgc2VsZWN0b3IgPSBcInNuYXJlXCIsIHNwcmVhZCA9IDI0bXMsIGdyYWNlID0gMC41KSB7XHJcbiAgICBhc3NlcnQoXHJcbiAgICAgICAgc3ByZWFkID49IDVtcyAmJiBzcHJlYWQgPD0gODBtcyAmJiBncmFjZSA+PSAwICYmIGdyYWNlIDw9IDEsXHJcbiAgICAgICAgXCJmbGFtIG5lZWRzIDUuLjgwbXMgc3ByZWFkIGFuZCBncmFjZSAwLi4xXCJcclxuICAgICk7XHJcbiAgICBwYXR0ZXJuLmZsYXRfbWFwX25vdGVzKGZuKG4pID0+IFtcclxuICAgICAgICB7a2V5OiBuLmtleSwgb2Zmc2V0OiBuLm9mZnNldCArIGlmIG4uYXQgPT0gMGIgeyBzcHJlYWQgfSBlbHNlIHsgMG1zIH19LFxyXG4gICAgICAgIHtcclxuICAgICAgICAgICAga2V5OiBuLmtleSArIFwiL2ZsYW1cIixcclxuICAgICAgICAgICAgdmVsb2NpdHk6IG4udmVsb2NpdHkgKiBncmFjZSxcclxuICAgICAgICAgICAgdGFnczogbi50YWdzICsgW1wiZ3JhY2VcIl0sXHJcbiAgICAgICAgICAgIG9mZnNldDogbi5vZmZzZXQgLSBpZiBuLmF0ID09IDBiIHsgMG1zIH0gZWxzZSB7IHNwcmVhZCB9XHJcbiAgICAgICAgfVxyXG4gICAgXSwgc2VsZWN0b3IpXHJcbn07XHJcbmZuIHJvbGwocGF0dGVybiwgc2VsZWN0b3IgPSBcInNuYXJlXCIsIHN0ZXAgPSAxLzRiLCB0byA9IDAuOSkge1xyXG4gICAgYXNzZXJ0KHN0ZXAgPiAwYiAmJiB0byA+PSAwICYmIHRvIDw9IDEsIFwicm9sbCBuZWVkcyBhIHBvc2l0aXZlIHN0ZXAgYW5kIHRvIDAuLjFcIik7XHJcbiAgICBwYXR0ZXJuLmZsYXRfbWFwX25vdGVzKGZuKG4pID0+IHtcclxuICAgICAgICBsZXQgY291bnQgPSAtZmxvb3IoLW4uZHVyYXRpb24gLyBzdGVwKTtcclxuICAgICAgICBhc3NlcnQoY291bnQgPD0gMTAyNCwgXCJyb2xsIGV4Y2VlZHMgMTAyNCBoaXRzXCIpO1xyXG4gICAgICAgIG1hcChyYW5nZShjb3VudCksIGZuKGopID0+IHtcclxuICAgICAgICAgICAgYXQ6IG4uYXQgKyBzdGVwICogaixcclxuICAgICAgICAgICAgZHVyYXRpb246IG1pbihzdGVwLCBuLmR1cmF0aW9uIC0gc3RlcCAqIGopLFxyXG4gICAgICAgICAgICB2ZWxvY2l0eTogbi52ZWxvY2l0eSArICh0byAtIG4udmVsb2NpdHkpICogaiAvIG1heCgxLCBjb3VudCAtIDEpLFxyXG4gICAgICAgICAgICBrZXk6IG4ua2V5ICsgXCIvcm9sbFwiICsgc3RyKGopLFxyXG4gICAgICAgICAgICBkYXRhOiBtZXJnZShuLmRhdGEsIHtzdGljazogaWYgaiAlIDIgPT0gMCB7IFwicmlnaHRcIiB9IGVsc2UgeyBcImxlZnRcIiB9fSlcclxuICAgICAgICB9KVxyXG4gICAgfSwgc2VsZWN0b3IpXHJcbn07XHJcbi8vIEdyb3VwIG9uY2UgYnkgb25zZXQ7IGJhc3Mgd2VpZ2h0IGFuZCBkZW5zaXR5IGFyZSBkZWxpYmVyYXRlbHkgZWRpdGFibGUgcG9saWN5LlxyXG5mbiBwZWRhbChoYXJtb255LCBkZXB0aCA9IDAuNjUsIGNvbnRyb2xsZXIgPSA2NCwgY2F0Y2ggPSAzMG1zLCBhd2FyZSA9IHRydWUpIHtcclxuICAgIGFzc2VydChcclxuICAgICAgICBjb250YWlucyhbNjQsIDY2LCA2N10sIGNvbnRyb2xsZXIpICYmIGNhdGNoID49IDBtcyAmJiBjYXRjaCA8PSA1MDBtcyxcclxuICAgICAgICBcInBlZGFsIGNvbnRyb2xsZXIgaXMgNjQvNjYvNjc7IGNhdGNoIG11c3QgYmUgMC4uNTAwbXNcIlxyXG4gICAgKTtcclxuICAgIGFzc2VydChkZXB0aCA+PSAwICYmIGRlcHRoIDw9IDEsIFwicGVkYWwgZGVwdGggbXVzdCBiZSAwLi4xXCIpO1xyXG4gICAgbGV0IGdyb3VwcyA9IGdyb3VwX2J5KGhhcm1vbnkubm90ZXMsIGZuKG4pID0+IG4uYXQpO1xyXG4gICAgc3RhY2soXHJcbiAgICAgICAgbWFwKGdyb3VwcywgZm4oZ3JvdXApID0+IHtcclxuICAgICAgICAgICAgbGV0IG1lYW4gPSBmb2xkKGdyb3VwLCAwLCBmbihzdW0sIG4pID0+IHN1bSArIG4ucGl0Y2gpIC8gbGVuKGdyb3VwKTtcclxuICAgICAgICAgICAgbGV0IHdlaWdodCA9IGlmIGF3YXJlIHtcclxuICAgICAgICAgICAgICAgIG1heCgwLjQsIG1pbigxLCAxIC0gbWF4KDAsIDYwIC0gbWVhbikgKiAwLjAwNyAtIG1heCgwLCBsZW4oZ3JvdXApIC0gMykgKiAwLjA0KSlcclxuICAgICAgICAgICAgfSBlbHNlIHtcclxuICAgICAgICAgICAgICAgIDFcclxuICAgICAgICAgICAgfTtcclxuICAgICAgICAgICAgc3RhY2soW1xyXG4gICAgICAgICAgICAgICAgY29udHJvbChjb250cm9sbGVyLCAwLCBhdCA9IGdyb3VwWzBdLmF0KSxcclxuICAgICAgICAgICAgICAgIGNvbnRyb2woXHJcbiAgICAgICAgICAgICAgICAgICAgY29udHJvbGxlcixcclxuICAgICAgICAgICAgICAgICAgICByb3VuZChkZXB0aCAqIHdlaWdodCAqIDEyNyksXHJcbiAgICAgICAgICAgICAgICAgICAgYXQgPSBncm91cFswXS5hdCxcclxuICAgICAgICAgICAgICAgICAgICBvZmZzZXQgPSBjYXRjaFxyXG4gICAgICAgICAgICAgICAgKVxyXG4gICAgICAgICAgICBdKVxyXG4gICAgICAgIH0pXHJcbiAgICAgICAgKyBbY29udHJvbChjb250cm9sbGVyLCAwLCBhdCA9IGhhcm1vbnkuc3BhbildXHJcbiAgICApXHJcbn07XHJcblxyXG4vLyBFZGl0YWJsZSBzZWFyY2ggc2NvcmluZy4gSGVsZCBub3RlcywgcmVhY2gsIGZpbmdlciBhbmNob3JzIGFuZCBzZWFyY2ggYnVkZ2V0c1xyXG4vLyByZW1haW4gc29sdmVyIGNvbnN0cmFpbnRzOyB0aGVzZSBudW1iZXJzIG9ubHkgcmFuayBmZWFzaWJsZSBhbGxvY2F0aW9ucy5cclxubGV0IHplcm9fcGl0Y2hfY29zdHMgPSBbMCwgMCwgMCwgMCwgMCwgMCwgMCwgMCwgMCwgMCwgMCwgMF07XHJcbmxldCBwaWFub19wcmVmZXJlbmNlcyA9IHtcclxuICAgIGhhbmRfY2VudGVyczogWzQ4LCA3Ml0sXHJcbiAgICBmaW5nZXJfcG9zaXRpb25zOiBbWzU1LCA1MywgNTEsIDQ5LCA0N10sIFs2NCwgNjYsIDY4LCA3MCwgNzJdXSxcclxuICAgIHJlYWNoX2Nvc3Q6IDEwMDAsXHJcbiAgICBjYXBhY2l0eV9jb3N0OiAxMDAwMCxcclxuICAgIGhhbmRfbW90aW9uX2Nvc3Q6IDEsXHJcbiAgICBoYW5kX3NwYW5fY29zdDogMC4xLFxyXG4gICAgZmluZ2VyX21vdGlvbl9jb3N0OiAwLjE1LFxyXG4gICAgZmluZ2VyX2NlbnRlcl9jb3N0OiAwLjA4LFxyXG4gICAgZmluZ2VyX3BpdGNoX2Nvc3RzOiBbXHJcbiAgICAgICAgWzAsIDAuMSwgMCwgMC4xLCAwLCAwLCAwLjEsIDAsIDAuMSwgMCwgMC4xLCAwXSxcclxuICAgICAgICB6ZXJvX3BpdGNoX2Nvc3RzLFxyXG4gICAgICAgIHplcm9fcGl0Y2hfY29zdHMsXHJcbiAgICAgICAgemVyb19waXRjaF9jb3N0cyxcclxuICAgICAgICB6ZXJvX3BpdGNoX2Nvc3RzXHJcbiAgICBdXHJcbn07XHJcbmZuIGhhbmRzKHBhdHRlcm4sIHJlYWNoID0gMTIsIHByZWZlcmVuY2VzID0gcGlhbm9fcHJlZmVyZW5jZXMpID0gYWxsb2NhdGVfaGFuZHMoXHJcbiAgICBwYXR0ZXJuLFxyXG4gICAgcmVhY2gsXHJcbiAgICBwcmVmZXJlbmNlc1xyXG4pO1xyXG5mbiB0cmFjayhuYW1lLCBwYXR0ZXJuLCBpbnN0cnVtZW50LCBvcHRpb25zID0ge30pID0gbWVyZ2UoXHJcbiAgICB7cGxheWluZzogcGlhbm9fcHJlZmVyZW5jZXN9LFxyXG4gICAgb3B0aW9ucyxcclxuICAgIHtpZDogbmFtZSwgcGF0dGVybjogcGF0dGVybiwgaW5zdHJ1bWVudDogaW5zdHJ1bWVudH1cclxuKTtcclxuIn0seyJuYW1lIjoic3RkL3BpYW5vLm11eiIsInNvdXJjZSI6ImZuIGFjY29tcGFuaW1lbnQoaGFybW9ueSwgb3JkZXIgPSBbMCwgMiwgMSwgMl0sIHN0ZXAgPSAxYiwgbGV2ZWwgPSAwLjQ4KSA9IGFycGVnZ2lhdGUoXHJcbiAgICBoYXJtb255LFxyXG4gICAgb3JkZXIsXHJcbiAgICBzdGVwXHJcbikudmVsb2NpdHkobGV2ZWwpLmhhbmQoXCJsZWZ0XCIpLnZvaWNlKFwiYWNjb21wYW5pbWVudFwiKTtcclxuZm4gcGVyZm9ybShtZWxvZHksIGxlZnQsIGhhcm1vbnksIGRlcHRoID0gMC41NSkgPSBzdGFjayhbXHJcbiAgICBtZWxvZHkuaGFuZChcInJpZ2h0XCIpLnZvaWNlKFwibWVsb2R5XCIpLFxyXG4gICAgbGVmdC5oYW5kKFwibGVmdFwiKSxcclxuICAgIHBlZGFsKGhhcm1vbnksIGRlcHRoKVxyXG5dKTtcclxuZm4gYXJyYW5nZShoYXJtb255LCBtZWxvZHksIGxvdyA9IDM2LCBoaWdoID0gNjApID0gcGVyZm9ybShcclxuICAgIG1lbG9keSxcclxuICAgIGFjY29tcGFuaW1lbnQodm9pY2VsZWFkKGhhcm1vbnksIGxvdywgaGlnaCwgY2VudGVyID0gKGxvdyArIGhpZ2gpIC8gMikpLFxyXG4gICAgaGFybW9ueVxyXG4pO1xyXG5mbiBzaW5naW5nKG1hdGVyaWFsKSA9IG1hdGVyaWFsLmdhdGUoMC45NikucnViYXRvKDI0bXMpLmh1bWFuaXplKDJtcywgMC4wMTgpO1xyXG5mbiBzb2Z0X3BlZGFsKGRvd24gPSAwYiwgdXAgPSA0YiwgZGVwdGggPSAwLjcpID0gc3RhY2soW1xyXG4gICAgY2MoNjcsIHJvdW5kKGRlcHRoICogMTI3KSwgYXQgPSBkb3duKSxcclxuICAgIGNjKDY3LCAwLCBhdCA9IHVwKVxyXG5dKTtcclxuIn0seyJuYW1lIjoic3RkL3ByZWx1ZGUubXV6Iiwic291cmNlIjoiLy8gQWRkIHNvdXJjZSBwb2xpY3kgaGVyZSB3aXRob3V0IG1haW50YWluaW5nIGEgUnVzdCBmdW5jdGlvbi1uYW1lIHJlZ2lzdHJ5LlxyXG51c2UgXCJzdGQvcGVyZm9ybWFuY2VcIiBhcyBwZXJmb3JtYW5jZTtcclxudXNlIFwic3RkL2NhdGFsb2dzXCIgYXMgY2F0YWxvZ3M7XHJcbnVzZSBcInN0ZC9wYXR0ZXJuc1wiIGFzIHBhdHRlcm5zO1xyXG5tZXJnZShwZXJmb3JtYW5jZSwgY2F0YWxvZ3MsIHBhdHRlcm5zKVxyXG4ifSx7Im5hbWUiOiJzdGQvc2FtcGxlci5tdXoiLCJzb3VyY2UiOiJ1c2UgXCJzdGQvbWl4XCIgYXMgdGltaW5nO1xyXG5cclxuLy8gQXNzaWduIGEgZnJlc2ggc291cmNlIHJvdW5kIHJvYmluIGJlZm9yZSBzZWxlY3Rpbmcvc3BsaXR0aW5nIGxhbmVzLlxyXG4vLyBVc2UgdGhlIG9yaWdpbmFsIGZ1bGwgcGF0dGVybiBhbmQgdGhlIHNvbmcncyB0ZW1wbyBtYXAuIEVxdWFsLXRpbWUgYXR0YWNrc1xyXG4vLyByZXRhaW4gcGF0dGVybiBvcmRlci4gWm9uZSBvcmRlciBtdXN0IHN0YXkgdW5jaGFuZ2VkIGFmdGVyIHBpbm5pbmcuXHJcbmZuIHBpbl9yZWNvcmRpbmdzKHBhdHRlcm4sIHpvbmVzLCBjbG9jayA9IHt9KSB7XHJcbiAgICBsZXQgb3JkZXJlZCA9IHNvcnRfYnkocGF0dGVybi5ub3RlcywgZm4obikgPT4gdGltaW5nLm5vdGVfc3RhcnQobiwgY2xvY2spKTtcclxuICAgIGxldCBjaG9pY2VzID0gbWFwKHJhbmdlKGxlbihvcmRlcmVkKSksIGZuKGkpID0+IHtcclxuICAgICAgICBsZXQgbiA9IG9yZGVyZWRbaV07XHJcbiAgICAgICAgbGV0IG1hdGNoaW5nID0gZmlsdGVyKHJhbmdlKGxlbih6b25lcykpLCBmbihqKSA9PiB7XHJcbiAgICAgICAgICAgIGxldCB6ID0gbWVyZ2Uoe2tleXM6IFswLCAxMjddLCB2ZWxvY2l0eTogWzAsIDFdfSwgem9uZXNbal0pO1xyXG4gICAgICAgICAgICByb3VuZChuLnBpdGNoKSA+PSB6LmtleXNbMF1cclxuICAgICAgICAgICAgJiYgcm91bmQobi5waXRjaCkgPD0gei5rZXlzWzFdXHJcbiAgICAgICAgICAgICYmIG4udmVsb2NpdHkgPj0gei52ZWxvY2l0eVswXVxyXG4gICAgICAgICAgICAmJiAobi52ZWxvY2l0eSA8IHoudmVsb2NpdHlbMV0gfHwgei52ZWxvY2l0eVsxXSA9PSAxKVxyXG4gICAgICAgIH0pO1xyXG4gICAgICAgIGFzc2VydChsZW4obWF0Y2hpbmcpID4gMCwgXCJDYW5ub3QgcGluIGEgbm90ZSB3aXRoIG5vIG1hdGNoaW5nIHNhbXBsZSB6b25lXCIpO1xyXG4gICAgICAgIHtrZXk6IG4ua2V5LCB6b25lOiBtYXRjaGluZ1tpICUgbGVuKG1hdGNoaW5nKV19XHJcbiAgICB9KTtcclxuICAgIHBhdHRlcm4ubWFwX25vdGVzKGZuKG4pID0+IHtcclxuICAgICAgICBsZXQgZm91bmQgPSBmaWx0ZXIoY2hvaWNlcywgZm4oYykgPT4gYy5rZXkgPT0gbi5rZXkpO1xyXG4gICAgICAgIGFzc2VydChsZW4oZm91bmQpID09IDEsIFwiUGluIHJlY29yZGluZ3MgcmVxdWlyZXMgdW5pcXVlIG5vdGUga2V5c1wiKTtcclxuICAgICAgICBsZXQgY2hvaWNlID0gZm91bmRbMF07XHJcbiAgICAgICAge2RhdGE6IG1lcmdlKG4uZGF0YSwge3NhbXBsZV96b25lOiBjaG9pY2Uuem9uZX0pfVxyXG4gICAgfSlcclxufVxyXG4ifSx7Im5hbWUiOiJzdGQvc2lnbmFsLm11eiIsInNvdXJjZSI6Ii8vIFNpZ25hbCBjb25zdHJ1Y3RvcnMgZXZhbHVhdGUgb2ZmLXRocmVhZC4gUmV1c2UgYSBib3VuZCByZWNvcmQgdG8gc2hhcmUgaXRzIHN0YXRlLlxyXG5mbiBwYXJhbShpZCwgdmFsdWUsIG1pbiA9IDAsIG1heCA9IDEpID0ge29wOiBcInBhcmFtXCIsIGlkOiBpZCwgdmFsdWU6IHZhbHVlLCBtaW46IG1pbiwgbWF4OiBtYXh9O1xyXG5mbiBmcmVxdWVuY3koKSA9IHtvcDogXCJmcmVxdWVuY3lcIn07XHJcbmZuIHZlbG9jaXR5KCkgPSB7b3A6IFwidmVsb2NpdHlcIn07XHJcbmZuIGV4cHJlc3Npb24oa2luZCkgPSB7b3A6IFwiZXhwcmVzc2lvblwiLCBraW5kOiBraW5kfTtcclxuZm4gb3NjKHdhdmUgPSBcInNpbmVcIiwgb3B0aW9ucyA9IHt9KSA9IG1lcmdlKHtvcDogXCJvc2NcIiwgd2F2ZTogd2F2ZX0sIG9wdGlvbnMpO1xyXG5mbiBzaW5lKG9wdGlvbnMgPSB7fSkgPSBvc2MoXCJzaW5lXCIsIG9wdGlvbnMpO1xyXG5mbiBzYXcob3B0aW9ucyA9IHt9KSA9IG9zYyhcInNhd1wiLCBvcHRpb25zKTtcclxuZm4gcHVsc2Uob3B0aW9ucyA9IHt9KSA9IG9zYyhcInB1bHNlXCIsIG9wdGlvbnMpO1xyXG5mbiBub2lzZSgpID0ge29wOiBcIm5vaXNlXCJ9O1xyXG5mbiBhZHNyKGF0dGFjayA9IDVtcywgZGVjYXkgPSAxNTBtcywgc3VzdGFpbiA9IDAuNywgcmVsZWFzZSA9IDIwMG1zLCBvbmVfc2hvdCA9IGZhbHNlKSA9IHtcclxuICAgIG9wOiBcImFkc3JcIixcclxuICAgIGF0dGFjazogYXR0YWNrLFxyXG4gICAgZGVjYXk6IGRlY2F5LFxyXG4gICAgc3VzdGFpbjogc3VzdGFpbixcclxuICAgIHJlbGVhc2U6IHJlbGVhc2UsXHJcbiAgICBvbmVfc2hvdDogb25lX3Nob3RcclxufTtcclxuZm4gYWRkKGlucHV0cykgPSB7b3A6IFwic3VtXCIsIGlucHV0czogaW5wdXRzfTtcclxuZm4gbXVsKGlucHV0cykgPSB7b3A6IFwibXVsXCIsIGlucHV0czogaW5wdXRzfTtcclxuZm4gZmlsdGVyKGlucHV0LCBjdXRvZmYgPSA0MDAwSHosIHEgPSAwLjcwNywgbW9kZSA9IFwibG93cGFzc1wiKSA9IHtcclxuICAgIG9wOiBcImZpbHRlclwiLFxyXG4gICAgaW5wdXQ6IGlucHV0LFxyXG4gICAgY3V0b2ZmOiBjdXRvZmYsXHJcbiAgICBxOiBxLFxyXG4gICAgbW9kZTogbW9kZVxyXG59O1xyXG5mbiBkcml2ZShpbnB1dCwgYW1vdW50ID0gMSkgPSB7b3A6IFwiZHJpdmVcIiwgaW5wdXQ6IGlucHV0LCBhbW91bnQ6IGFtb3VudH07XHJcbmZuIGRlbGF5KGlucHV0LCBzZWNvbmRzID0gMTAwbXMsIGZlZWRiYWNrID0gMCwgbWF4X3NlY29uZHMgPSAyNTBtcykgPSB7XHJcbiAgICBvcDogXCJkZWxheVwiLFxyXG4gICAgaW5wdXQ6IGlucHV0LFxyXG4gICAgc2Vjb25kczogc2Vjb25kcyxcclxuICAgIGZlZWRiYWNrOiBmZWVkYmFjayxcclxuICAgIG1heF9zZWNvbmRzOiBtYXhfc2Vjb25kc1xyXG59O1xyXG5mbiBzdGVyZW8obGVmdCwgcmlnaHQpID0ge2xlZnQ6IGxlZnQsIHJpZ2h0OiByaWdodH07XHJcbmZuIHN0ZXJlb19tdWwocGFpciwgZ2FpbikgPSBzdGVyZW8obXVsKFtwYWlyLmxlZnQsIGdhaW5dKSwgbXVsKFtwYWlyLnJpZ2h0LCBnYWluXSkpO1xyXG5mbiBzdGVyZW9fc3VtKHBhaXJzKSA9IHN0ZXJlbyhhZGQobWFwKHBhaXJzLCBmbihwKSA9PiBwLmxlZnQpKSwgYWRkKG1hcChwYWlycywgZm4ocCkgPT4gcC5yaWdodCkpKTtcclxuZm4gcGFuKGlucHV0LCBwb3NpdGlvbiA9IDAuNSkgPSBzdGVyZW8oXHJcbiAgICBtdWwoW2lucHV0LCBjb3MocG9zaXRpb24gKiAxLjU3MDc5NjMyNjc5NDg5NjYpXSksXHJcbiAgICBtdWwoW2lucHV0LCBzaW4ocG9zaXRpb24gKiAxLjU3MDc5NjMyNjc5NDg5NjYpXSlcclxuKTtcclxuZm4gbXNlZyhhdHRhY2ssIHJlbGVhc2UgPSBbe3RpbWU6IDEwMG1zLCB0bzogMH1dLCBzdXN0YWluID0gbnVsbCwgb25lX3Nob3QgPSBmYWxzZSkgPSB7XHJcbiAgICBvcDogXCJtc2VnXCIsXHJcbiAgICBhdHRhY2s6IGF0dGFjayxcclxuICAgIHJlbGVhc2U6IHJlbGVhc2UsXHJcbiAgICBzdXN0YWluOiBzdXN0YWluLFxyXG4gICAgb25lX3Nob3Q6IG9uZV9zaG90XHJcbn07XHJcbmZuIG1hcHBpbmcoaW5wdXQsIGtpbmQgPSBcImNsYW1wXCIsIG1pbiA9IDAsIG1heCA9IDEpID0ge1xyXG4gICAgb3A6IFwibWFwXCIsXHJcbiAgICBpbnB1dDogaW5wdXQsXHJcbiAgICBraW5kOiBraW5kLFxyXG4gICAgbWluOiBtaW4sXHJcbiAgICBtYXg6IG1heFxyXG59O1xyXG5mbiBob2xkKGlucHV0LCByYXRlX2h6ID0gNEh6KSA9IHtvcDogXCJob2xkXCIsIGlucHV0OiBpbnB1dCwgcmF0ZV9oejogcmF0ZV9oen07XHJcbmZuIHNsZXcoaW5wdXQsIHJpc2UgPSA0MG1zLCBmYWxsID0gNDBtcykgPSB7b3A6IFwic2xld1wiLCBpbnB1dDogaW5wdXQsIHJpc2U6IHJpc2UsIGZhbGw6IGZhbGx9O1xyXG5mbiBvY3RhdmVzKGJhc2UsIGFtb3VudCkgPSBtdWwoW2Jhc2UsIG1hcHBpbmcoYW1vdW50LCBcImV4cDJcIildKTtcclxuZm4gcGVyaW9kKGZyZXF1ZW5jeSkgPSBtYXBwaW5nKGZyZXF1ZW5jeSwgXCJyZWNpcHJvY2FsXCIpO1xyXG5mbiBkcmlmdChyYXRlID0gNEh6LCBzbW9vdGggPSAyMDBtcykgPSBzbGV3KGhvbGQobm9pc2UoKSwgcmF0ZSksIHNtb290aCwgc21vb3RoKTtcclxuLy8gUmVhZGVyIHJldHVybnMgem9uZS1jYWxpYnJhdGVkIGF1ZGlvOyBwYXRjaCBvdXRwdXQgYXBwbGllcyB2ZWxvY2l0eS9leHByZXNzaW9uLlxyXG5mbiByZWFkZXIoc291cmNlLCBjaGFubmVsID0gXCJtb25vXCIsIHNwZWVkID0gMSwgb3B0aW9ucyA9IHt9KSA9IG1lcmdlKHtcclxuICAgIG9wOiBcInJlYWRlclwiLFxyXG4gICAgc291cmNlOiBzb3VyY2UsXHJcbiAgICBjaGFubmVsOiBjaGFubmVsLFxyXG4gICAgc3BlZWQ6IHNwZWVkXHJcbn0sIG9wdGlvbnMpO1xyXG5mbiBzaGFwZShpbnB1dCwgcG9pbnRzLCBxdWFsaXR5ID0gXCJhZGFhXCIpID0ge1xyXG4gICAgb3A6IFwic2hhcGVcIixcclxuICAgIGlucHV0OiBpbnB1dCxcclxuICAgIHBvaW50czogcG9pbnRzLFxyXG4gICAgcXVhbGl0eTogcXVhbGl0eVxyXG59O1xyXG5mbiByZXNvbmF0b3IoaW5wdXQsIGZyZXF1ZW5jeSwgZGVjYXkgPSAxcykgPSB7XHJcbiAgICBvcDogXCJyZXNvbmF0b3JcIixcclxuICAgIGlucHV0OiBpbnB1dCxcclxuICAgIGZyZXF1ZW5jeTogZnJlcXVlbmN5LFxyXG4gICAgZGVjYXk6IGRlY2F5XHJcbn07XHJcbmZuIGRhbXBlZF9kZWxheShcclxuICAgIGlucHV0LFxyXG4gICAgc2Vjb25kcyxcclxuICAgIGZlZWRiYWNrID0gMC45OCxcclxuICAgIGRhbXBpbmcgPSA0MDAwSHosXHJcbiAgICBtYXhfc2Vjb25kcyA9IDI1MG1zLFxyXG4gICAgbWF4X2ZlZWRiYWNrID0gMC45OTk5OVxyXG4pID0ge1xyXG4gICAgb3A6IFwiZGVsYXlcIixcclxuICAgIGlucHV0OiBpbnB1dCxcclxuICAgIHNlY29uZHM6IHNlY29uZHMsXHJcbiAgICBmZWVkYmFjazogZmVlZGJhY2ssXHJcbiAgICBkYW1waW5nOiBkYW1waW5nLFxyXG4gICAgbWF4X3NlY29uZHM6IG1heF9zZWNvbmRzLFxyXG4gICAgbWF4X2ZlZWRiYWNrOiBtYXhfZmVlZGJhY2tcclxufTtcclxuIn0seyJuYW1lIjoic3RkL3N5bnRoZXNpcy5tdXoiLCJzb3VyY2UiOiIvLyBOYXRpdmUgaW5zdHJ1bWVudCByZWNpcGVzLiBDb250cm9scyBhbmQgbXVzaWNhbCBjaG9pY2VzIHJlbWFpbiBlZGl0YWJsZSBzb3VyY2UuXHJcbnVzZSBcInN0ZC9zaWduYWxcIiBhcyBzO1xyXG51c2UgXCJzdGQvaW5zdHJ1bWVudFwiIGFzIGluc3RydW1lbnQ7XHJcblxyXG4vLyBDMuKAk0M2OiBzdGVyZW8gc3VidHJhY3RpdmUgdm9pY2UuIFRvbmUgaXMgSHo7IG1vdGlvbiBpcyBub3RlLXRyaWdnZXJlZC5cclxuZm4gcGFkKHRvbmUgPSAxODAwSHopIHtcclxuICAgIGxldCBjdXRvZmYgPSBzLnBhcmFtKFwidG9uZVwiLCB0b25lLCA4MEh6LCAxMjAwMEh6KTtcclxuICAgIGxldCBlID0gcy5hZHNyKDUwMG1zLCAxcywgMC43LCAxMjAwbXMpO1xyXG4gICAgbGV0IHBhaXIgPSBzLnN0ZXJlbyhcclxuICAgICAgICBzLmZpbHRlcihzLnNhdyh7ZGV0dW5lOiAtOSwgcGhhc2U6IDAuMn0pLCBjdXRvZmYpLFxyXG4gICAgICAgIHMuZmlsdGVyKHMuc2F3KHtkZXR1bmU6IDksIHBoYXNlOiAwLjY1fSksIGN1dG9mZilcclxuICAgICk7XHJcbiAgICB2b2ljZV9wYXRjaChcInN0ZXJlby1wYWRcIiwge1xyXG4gICAgICAgIGdhaW5fZGI6IC0yMCxcclxuICAgICAgICBvdXRwdXQ6IHMuc3RlcmVvX211bChwYWlyLCBlKSxcclxuICAgICAgICBsaWZldGltZToge2VudmVsb3BlOiBlLCB0YWlsOiAwc31cclxuICAgIH0pXHJcbn07XHJcbi8vIEMy4oCTQzY6IGtleWVkIHZhcmlhdGlvbiBtb3ZlcyBjdXRvZmYgYnkgdXAgdG8gdHdvIG9jdGF2ZXMsIGxhc3QtYXR0YWNrIGxlZ2F0by5cclxuZm4gbGVhZCh0b25lID0gMTAwMEh6LCBnbGlkZSA9IDYwbXMpIHtcclxuICAgIGxldCBjdXRvZmYgPSBzLnBhcmFtKFwidG9uZVwiLCB0b25lLCA4MEh6LCA2MDAwSHopO1xyXG4gICAgbGV0IGUgPSBzLmFkc3IoOG1zLCAyNTBtcywgMC42LCAxODBtcyk7XHJcbiAgICBsZXQgb3NjID0gcy5hZGQoW3Muc2F3KCksIHMubXVsKFtzLnNpbmUoe3JhdGlvOiAwLjV9KSwgMC4zXSldKTtcclxuICAgIGxldCBib2R5ID0gcy5maWx0ZXIob3NjLCBzLm9jdGF2ZXMoY3V0b2ZmLCBzLm11bChbcy5leHByZXNzaW9uKFwidmFyaWF0aW9uXCIpLCAyXSkpLCAxLjIpO1xyXG4gICAgaW5zdHJ1bWVudC5tb25vKFxyXG4gICAgICAgIHZvaWNlX3BhdGNoKFwibGVnYXRvLWxlYWRcIiwge1xyXG4gICAgICAgICAgICBub3RlX2NvbnRyb2xzOiB7dmFyaWF0aW9uOiAwfSxcclxuICAgICAgICAgICAgZ2Fpbl9kYjogLTE4LFxyXG4gICAgICAgICAgICBvdXRwdXQ6IHMubXVsKFtib2R5LCBlXSksXHJcbiAgICAgICAgICAgIGxpZmV0aW1lOiB7ZW52ZWxvcGU6IGUsIHRhaWw6IDBzfVxyXG4gICAgICAgIH0pLFxyXG4gICAgICAgIGdsaWRlXHJcbiAgICApXHJcbn07XHJcbmZuIG1vZGFsX2JhbmsoaW5wdXQsIGZyZXF1ZW5jeSwgcmF0aW9zLCBkZWNheXMsIGdhaW5zKSA9IHMuYWRkKFxyXG4gICAgbWFwKFxyXG4gICAgICAgIHJhbmdlKGxlbihyYXRpb3MpKSxcclxuICAgICAgICBmbihpKSA9PiBzLm11bChbcy5yZXNvbmF0b3IoaW5wdXQsIHMubXVsKFtmcmVxdWVuY3ksIHJhdGlvc1tpXV0pLCBkZWNheXNbaV0pLCBnYWluc1tpXV0pXHJcbiAgICApXHJcbik7XHJcbi8vIEMy4oCTQzU6IGNhbGlicmF0ZWQgbW9kYWwgZGVjYXksIHdpdGggc291cmNlLWNob3NlbiBpbmhhcm1vbmljIHBhcnRpYWwgcmF0aW9zLlxyXG5mbiBzdHJ1Y2soZGVjYXkgPSAxcykge1xyXG4gICAgbGV0IGUgPSBzLmFkc3IoMHMsIDFtcywgMCwgMTBtcywgdHJ1ZSk7XHJcbiAgICBsZXQgZXhjaXRhdGlvbiA9IHMubXVsKFtzLm5vaXNlKCksIGVdKTtcclxuICAgIGxldCBib2R5ID0gbW9kYWxfYmFuayhcclxuICAgICAgICBleGNpdGF0aW9uLFxyXG4gICAgICAgIHMuZnJlcXVlbmN5KCksXHJcbiAgICAgICAgWzEsIDIuMDEsIDMuOSwgNS40XSxcclxuICAgICAgICBbZGVjYXksIGRlY2F5ICogMC43LCBkZWNheSAqIDAuNSwgZGVjYXkgKiAwLjNdLFxyXG4gICAgICAgIFswLjUsIDAuMywgMC4yLCAwLjEyXVxyXG4gICAgKTtcclxuICAgIHZvaWNlX3BhdGNoKFwic3RydWNrLWJvZHlcIiwge1xyXG4gICAgICAgIGdhaW5fZGI6IC0yMixcclxuICAgICAgICBvdXRwdXQ6IGJvZHksXHJcbiAgICAgICAgbGlmZXRpbWU6IHtlbnZlbG9wZTogZSwgdGFpbDogZGVjYXkgKiAxLjV9XHJcbiAgICB9KVxyXG59O1xyXG4vLyBDMuKAk0M1OiBub21pbmFsIGNvbWIgcGl0Y2g7IGRhbXBpbmcvaW50ZXJwb2xhdGlvbiBzaGlmdCB0dW5pbmcgYW5kIGRlY2F5LlxyXG5mbiBwbHVjayhkYW1waW5nID0gNjAwMEh6KSB7XHJcbiAgICBsZXQgZSA9IHMuYWRzcigwcywgMW1zLCAwLCAxMG1zLCB0cnVlKTtcclxuICAgIGxldCBjdXRvZmYgPSBzLnBhcmFtKFwiZGFtcGluZ1wiLCBkYW1waW5nLCAyMDBIeiwgMTYwMDBIeik7XHJcbiAgICBsZXQgYm9keSA9IHMuZGFtcGVkX2RlbGF5KFxyXG4gICAgICAgIHMubXVsKFtzLm5vaXNlKCksIGVdKSxcclxuICAgICAgICBzLnBlcmlvZChzLmZyZXF1ZW5jeSgpKSxcclxuICAgICAgICAwLjk5NSxcclxuICAgICAgICBjdXRvZmYsXHJcbiAgICAgICAgbWF4X3NlY29uZHMgPSAxMDBtc1xyXG4gICAgKTtcclxuICAgIHZvaWNlX3BhdGNoKFwiZGFtcGVkLXBsdWNrXCIsIHtnYWluX2RiOiAtMTgsIG91dHB1dDogYm9keSwgbGlmZXRpbWU6IHtlbnZlbG9wZTogZSwgdGFpbDogM3N9fSlcclxufTtcclxuLy8gQzPigJNDNjogaW5kZXBlbmRlbnQgbG93LXJhdGUgbW90aW9uIGFuZCBub25saW5lYXIgc3BlY3RyYWwgY2hhbmdlLlxyXG5mbiB0ZXh0dXJlKHRvbmUgPSAxMjAwSHopIHtcclxuICAgIGxldCBlID0gcy5hZHNyKDFzLCAycywgMC43LCAycyk7XHJcbiAgICBsZXQgY3V0b2ZmID0gcy5wYXJhbShcInRvbmVcIiwgdG9uZSwgMTAwSHosIDYwMDBIeik7XHJcbiAgICBsZXQgbW90aW9uID0gcy5hZGQoW3Muc2luZSh7aHo6IDAuMTdIen0pLCBzLm11bChbcy5kcmlmdCgySHosIDYwMG1zKSwgMC4yNV0pXSk7XHJcbiAgICBsZXQgb3NjID0gcy5zaW5lKHtwaGFzZTogcy5tdWwoW3Muc2luZSh7cmF0aW86IDIuMDF9KSwgbW90aW9uXSl9KTtcclxuICAgIGxldCBzaGFwZWQgPSBzLnNoYXBlKG9zYywgW1stMSwgLTAuNl0sIFstMC4zLCAtMC45XSwgWzAsIDBdLCBbMC40LCAwLjldLCBbMSwgMC40XV0pO1xyXG4gICAgbGV0IGZpbHRlcmVkID0gcy5maWx0ZXIoc2hhcGVkLCBzLm9jdGF2ZXMoY3V0b2ZmLCBtb3Rpb24pKTtcclxuICAgIHZvaWNlX3BhdGNoKFwibW92aW5nLXRleHR1cmVcIiwge1xyXG4gICAgICAgIGdhaW5fZGI6IC0yMCxcclxuICAgICAgICBvdXRwdXQ6IHMubXVsKFtmaWx0ZXJlZCwgZV0pLFxyXG4gICAgICAgIGxpZmV0aW1lOiB7ZW52ZWxvcGU6IGUsIHRhaWw6IDBzfVxyXG4gICAgfSlcclxufTtcclxuLy8gTWFwcyBtdXN0IGNvdmVyIHRoZSBzYW1lIHBlcmZvcm1lZCBub3Rlcy4gUHJlc3N1cmUgY3Jvc3NmYWRlcyBjYWxpYnJhdGVkIGxheWVycy5cclxuZm4gbGF5ZXJlZChzb2Z0LCBsb3VkKSB7XHJcbiAgICBsZXQgZSA9IHMuYWRzcigzMG1zLCAzMDBtcywgMC44LCAyMDBtcyk7XHJcbiAgICBsZXQgYmxlbmQgPSBzLmV4cHJlc3Npb24oXCJwcmVzc3VyZVwiKTtcclxuICAgIGZuIGNoYW5uZWwobmFtZSkgPSBpbnN0cnVtZW50LmNyb3NzZmFkZShzLnJlYWRlcihzb2Z0LCBuYW1lKSwgcy5yZWFkZXIobG91ZCwgbmFtZSksIGJsZW5kKTtcclxuICAgIHZvaWNlX3BhdGNoKFwiZHluYW1pYy1sYXllcnNcIiwge1xyXG4gICAgICAgIGdhaW5fZGI6IC0xMixcclxuICAgICAgICBvdXRwdXQ6IHMuc3RlcmVvX211bChzLnN0ZXJlbyhjaGFubmVsKFwibGVmdFwiKSwgY2hhbm5lbChcInJpZ2h0XCIpKSwgZSksXHJcbiAgICAgICAgbGlmZXRpbWU6IHtlbnZlbG9wZTogZSwgdGFpbDogMHN9XHJcbiAgICB9KVxyXG59XHJcbiJ9LHsibmFtZSI6InN0ZC90b25hbC5tdXoiLCJzb3VyY2UiOiJ1c2UgXCJzdGQvY2F0YWxvZ3NcIiBhcyBjYXRhbG9ncztcclxubGV0IHNjYWxlID0gY2F0YWxvZ3Muc2NhbGU7XHJcbmxldCBkZWdyZWUgPSBjYXRhbG9ncy5kZWdyZWU7XHJcbmxldCBkaWF0b25pY19jaG9yZCA9IGNhdGFsb2dzLmRpYXRvbmljX2Nob3JkO1xyXG5sZXQgc2NhbGVfbW9kZXMgPSBjYXRhbG9ncy5zY2FsZV9tb2RlcztcclxuLy8gRGVncmVlIG51bWJlcnMgc3RhcnQgYXQgMSBhbmQgY29udGludWUgbmF0dXJhbGx5IGFjcm9zcyBvY3RhdmVzLlxyXG5mbiB2b2ljaW5nKHBpdGNoZXMsIGR1cmF0aW9uID0gNGIpID0gc3RhY2socGl0Y2hlcy5tYXAoZm4ocCkgPT4gbm90ZShwLCBkdXJhdGlvbikpKTtcclxuZm4gcHJvZ3Jlc3Npb24oa2V5LCBkZWdyZWVzLCBlYWNoID0gNGIsIHZvaWNlcyA9IDMpID0gc2VxKFxyXG4gICAgZGVncmVlcy5tYXAoZm4oZCkgPT4gdm9pY2luZyhkaWF0b25pY19jaG9yZChrZXksIGQsIHZvaWNlcyksIGVhY2gpKVxyXG4pO1xyXG5mbiBtZWxvZHkoa2V5LCBkZWdyZWVzLCBzdGVwID0gMWIpID0gc2VxKGRlZ3JlZXMubWFwKGZuKGQpID0+IG5vdGUoZGVncmVlKGtleSwgZCksIHN0ZXApKSk7XHJcbmZuIGNhZGVuY2VzKGtleSkgPSBbXHJcbiAgICBwcm9ncmVzc2lvbihrZXksIFsyLCA1LCAxXSksXHJcbiAgICBwcm9ncmVzc2lvbihrZXksIFs0LCA1LCAxXSksXHJcbiAgICBwcm9ncmVzc2lvbihrZXksIFs2LCA0LCA1LCAxXSlcclxuXTtcclxubGV0IHRvbmFsX3Njb3JpbmcgPSBjYXRhbG9ncy50b25hbF9zY29yaW5nO1xyXG5sZXQgdm9pY2VsZWFkID0gY2F0YWxvZ3Mudm9pY2VsZWFkO1xyXG5sZXQgcmVoYXJtb25pemUgPSBjYXRhbG9ncy5yZWhhcm1vbml6ZTtcclxubGV0IHJlaGFybW9uaXphdGlvbnMgPSBjYXRhbG9ncy5yZWhhcm1vbml6YXRpb25zO1xyXG4ifV0=",
	"src/app/assets/template.muz": "data:application/octet-stream;base64,dXNlICJzdGQvYXJyYW5nZSIgYXMgYTsNCnVzZSAic3RkL21peCIgYXMgbWl4Ow0KDQpsZXQgdGhlbWUgPSBwaHJhc2UoIkM1OmUgRTU6ZSBHNTpxIEU1OnEgRDU6cSB8IEM1OmggcjpoIikudGFnKCJsYXN0IiwgImVjaG8iKTsNCmZuIGVjaG8oY29udGV4dCkgPSBbDQogICAgbWl4LnRocm93cygNCiAgICAgICAgYS5tYXRlcmlhbChjb250ZXh0LCAibGVhZCIpLA0KICAgICAgICAiZWNobyIsDQogICAgICAgICJsZWFkLnNlbmQuZWNobyIsDQogICAgICAgIC0xMiwNCiAgICAgICAgdGltaW5nID0gY29udGV4dC50aW1pbmcsDQogICAgICAgIHN0YXJ0ID0gc2Vjb25kc19hdChjb250ZXh0LnN0YXJ0LCBjb250ZXh0LnRpbWluZykNCiAgICApDQpdOw0KbGV0IHBocmFzZV9zZWN0aW9uID0gYS5wYXNzYWdlKDJiYXJzLCBbYS5wYXJ0KCJsZWFkIiwgdGhlbWUpXSwgW2VjaG9dKTsNCmxldCBmb3JtID0gYS5zZXF1ZW5jZShbDQogICAgYS5vY2N1cnJlbmNlKCJvcGVuaW5nIiwgcGhyYXNlX3NlY3Rpb24pLA0KICAgIGEub2NjdXJyZW5jZSgNCiAgICAgICAgInJldHVybiIsDQogICAgICAgIGEuZWRpdCgNCiAgICAgICAgICAgIHBocmFzZV9zZWN0aW9uLA0KICAgICAgICAgICAgImxlYWQiLA0KICAgICAgICAgICAgZm4ocCkgPT4gYS5yZXF1aXJlKHAsICJlY2hvIikucmVmaW5lKCJlY2hvIiwge2R1cmF0aW9uOiAzYn0pDQogICAgICAgICkNCiAgICApDQpdKTsNCmxldCBtYWluID0gYS5idWlsZChmb3JtLCB7DQogICAgdGl0bGU6ICJVbnRpdGxlZCIsDQogICAgdGVtcG86IDEyMCwNCiAgICB0cmFja3M6IFt0cmFjaygibGVhZCIsIHJlc3QoMGIpLCBzeW50aCgiZ2xhc3MtbGVhZCIpLCB7c2VuZHM6IHtlY2hvOiAtMTIwfX0pXSwNCiAgICBidXNlczogW2J1cygiZWNobyIsIFtmeCgiZGVsYXkiLCB7bWl4OiAxLCB0aW1lX2JlYXRzOiAwLjc1LCBmZWVkYmFjazogMC4zfSldKV0sDQogICAgbWFzdGVyOiBtaXgubWFzdGVyKCksDQogICAgdGFpbDogMw0KfSk7DQpsZXQgZGVsaXZlcnkgPSBbe25hbWU6ICJtYXN0ZXIiLCBzb25nOiBtYWluLCBvcHRpb25zOiB7Zm9ybWF0OiAicGNtMjQiLCB0YWlsOiAzfX1dOw0KbWFpbg0K",
	"src/app/assets/engine.json": "data:application/json;base64,ewogICJyZXBvc2l0b3J5IjogImh0dHBzOi8vZ2l0aHViLmNvbS9hcGFnZTQzL211ei5naXQiLAogICJyZXZpc2lvbiI6ICJmNjQ4Yzg2NzM3ZjBiOTk1ZTljODYxODFiYWIwOTA3NWQyNzAwZDkxIiwKICAibG9jYWwiOiB0cnVlLAogICJkaXJ0eSI6IHRydWUKfQ=="
}, n = new URL("/muz/", location.href), r = {};
function i(e, t, n, r = {}) {
	let a = new URL(n), o = (e, t) => Object.prototype.hasOwnProperty.call(e, t);
	function s(e, t = a.href) {
		let n;
		try {
			n = new URL(String(e), /^(?:blob|data):/.test(t) ? a.href : t);
		} catch {
			return;
		}
		if (n.origin === a.origin) try {
			return decodeURIComponent(n.pathname.startsWith(a.pathname) ? n.pathname.slice(a.pathname.length) : n.pathname.replace(/^\//, ""));
		} catch {
			return;
		}
	}
	let c = globalThis.fetch.bind(globalThis), l = /* @__PURE__ */ new Map();
	if (globalThis.__vitalityEmbedded = {
		root: a.href,
		asset(t) {
			if (!o(e, t)) throw Error("Unknown embedded asset: " + t);
			return new URL(e[t], a).href;
		},
		script(n) {
			if (!o(t, n)) throw Error("Unknown embedded script: " + n);
			if (t[n].startsWith("url:")) return new URL(t[n].slice(4), a).href;
			if (!l.has(n)) {
				let r = "if(!globalThis.__vitalityEmbedded)(" + i.toString() + ")(" + JSON.stringify(e) + "," + JSON.stringify(t) + "," + JSON.stringify(a.href) + ");\n";
				l.set(n, URL.createObjectURL(new Blob([r, Uint8Array.from(atob(t[n]), (e) => e.charCodeAt(0))], { type: "text/javascript" })));
			}
			return l.get(n);
		},
		import(e, t, n) {
			let i = s(e, t);
			return i && o(r, i) ? r[i]() : import(
				/* @vite-ignore */
				new URL(String(e), t).href,
				n
);
		}
	}, globalThis.fetch = async (t, n) => {
		let r = new Request(t instanceof Request ? t : new URL(String(t), a.href), n), i = s(r.url);
		if (i && o(e, i) && (r.method === "GET" || r.method === "HEAD")) {
			let t = await c(new URL(e[i], a), { signal: r.signal }), n = r.method === "HEAD" ? new Response(null, { headers: t.headers }) : t;
			return Object.defineProperty(n, "url", { value: r.url }), n;
		}
		return c(r);
	}, typeof globalThis.importScripts == "function") {
		let e = globalThis.importScripts.bind(globalThis);
		globalThis.importScripts = (...n) => e(...n.map((e) => {
			let n = s(e);
			return n && o(t, n) ? globalThis.__vitalityEmbedded.script(n) : e;
		}));
	}
	if (typeof XMLHttpRequest < "u") {
		let t = XMLHttpRequest.prototype.open;
		XMLHttpRequest.prototype.open = function(n, r, ...i) {
			let c = s(r);
			return t.call(this, n, c && o(e, c) ? new URL(e[c], a).href : r, ...i);
		};
	}
}
i(t, e, n.href, r);
// src/app/assets/app.ts
var a = new TextEncoder();
function o(e) {
	if (typeof e != "string" || !e || /[\\:\x00-\x1f]/.test(e)) throw Error("Invalid project path");
	let t = e.split("/");
	if (t.some((e) => !e || [
		".",
		"..",
		"__proto__",
		"constructor",
		"prototype"
	].includes(e))) throw Error(`Invalid project path: ${e}`);
	return t.join("/");
}
function s(e) {
	if (!e || typeof e != "object" || !e.files || typeof e.files != "object" || Array.isArray(e.files)) throw Error("Expected a muz project with an entry and a files map.");
	let t = Object.create(null), n = Object.create(null), r = 0, i = 0, s = Object.entries(e.files);
	if (s.length > 500) throw Error("Project exceeds 500 source files.");
	for (let [e, n] of s) {
		if (o(e), typeof n != "string" || !/\.(muz|md)$/i.test(e)) throw Error(`Source files must be .muz or .md text: ${e}`);
		if (r += a.encode(n).length, r > 4194304) throw Error("Project source exceeds 4 MiB.");
		t[e] = n;
	}
	for (let [r, a] of Object.entries(e.assets || {})) {
		if (o(r), r in t || typeof a != "string" || !/^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$/.test(a)) throw Error(`Invalid asset: ${r}`);
		if (i += Math.floor(a.length / 4) * 3, i > 67108864) throw Error("Project assets exceed 64 MiB.");
		n[r] = a;
	}
	if (Object.keys(n).length > 500) throw Error("Project exceeds 500 assets.");
	let c = o(e.entry || ("song.muz" in t ? "song.muz" : Object.keys(t).find((e) => e.endsWith(".muz"))));
	if (!c.endsWith(".muz") || !(c in t)) throw Error("Choose an existing .muz entry file.");
	return {
		format: "muzstatic/1",
		title: String(e.title || c.replace(/\.muz$/, "")).slice(0, 200),
		entry: c,
		files: t,
		assets: n
	};
}
function c(e, t = "song.muz") {
	if (a.encode(e).length > 98146713.6) throw Error("Project is too large.");
	let n = e.replace(/^\uFEFF/, ""), r;
	try {
		r = JSON.parse(n);
	} catch {}
	if (r?.files) return s(r);
	if (/\.json$/i.test(t)) throw Error("This JSON is not a muz project (entry + files).");
	if (/^\s*(?:<!doctype|<html|<script)/i.test(n)) throw Error("The source returned an HTML page. Use its raw file URL.");
	let i = t.split("/").pop();
	return i?.endsWith(".muz") || (i = "song.muz"), s({
		title: i.replace(/\.muz$/, ""),
		entry: i,
		files: { [i]: n }
	});
}
function l(e) {
	let t = "";
	for (let n = 0; n < e.length; n += 8192) t += String.fromCharCode(...e.subarray(n, n + 8192));
	return btoa(t);
}
async function u(e) {
	let t = [...e];
	if (!t.length) throw Error("Choose a source file or project folder.");
	if (t.length === 1 && /\.json$/i.test(t[0].name)) return c(await t[0].text(), t[0].name);
	if (t.length > 1e3 || t.reduce((e, t) => e + t.size, 0) > 67108864) throw Error("Project exceeds 1000 files or 64 MiB.");
	let n = {
		files: Object.create(null),
		assets: Object.create(null)
	};
	for (let e of t) {
		let t = o(e.webkitRelativePath ? e.webkitRelativePath.split("/").slice(1).join("/") : e.name);
		/\.(muz|md)$/i.test(t) ? n.files[t] = await e.text() : n.assets[t] = l(new Uint8Array(await e.arrayBuffer()));
	}
	return s(n);
}
var d = "!#$&'()*+,-./0123456789:;=?~@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]_abcdefghijklmnopqrstuvwxyz".split("");
"$*+-./:0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".split("");
var f = [
	"0123456789-_",
	"ABCDEFGHIJKLMNOPQRSTUVWXYZ-_",
	"abcdefghijklmnopqrstuvwxyz-_",
	"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_",
	"abcdefghijklmnopqrstuvwxyz0123456789-_",
	"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_",
	"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_",
	"!#$&'()*+,-.0123456789:;=?~@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]_abcdefghijklmnopqrstuvwxyz%"
], p = {
	us: "0000000",
	market: "0000001000",
	xyz: "0000001001",
	lt: "0000001010000",
	ae: "0000001010001",
	tt: "0000001010010",
	top: "0000001010011",
	hr: "000000101010",
	biz: "000000101011",
	es: "0000001011",
	wtf: "00000011",
	ceo: "000001000000000000",
	cbre: "000001000000000001",
	cfa: "000001000000000010",
	cern: "000001000000000011",
	catholic: "000001000000000100",
	catering: "000001000000000101",
	cbn: "000001000000000110",
	cba: "000001000000000111",
	chase: "000001000000001000",
	charity: "000001000000001001",
	chintai: "000001000000001010",
	cheap: "000001000000001011",
	cg: "000001000000001100",
	cfd: "000001000000001101",
	channel: "000001000000001110",
	chanel: "000001000000001111",
	canon: "000001000000010000",
	cam: "000001000000010001",
	capitalone: "000001000000010010",
	capetown: "000001000000010011",
	cal: "000001000000010100",
	cab: "000001000000010101",
	calvinklein: "000001000000010110",
	call: "000001000000010111",
	cars: "000001000000011000",
	careers: "000001000000011001",
	casino: "000001000000011010",
	case: "000001000000011011",
	caravan: "000001000000011100",
	car: "000001000000011101",
	career: "000001000000011110",
	care: "000001000000011111",
	comsec: "000001000000100000",
	compare: "000001000000100001",
	construction: "000001000000100010",
	condos: "000001000000100011",
	college: "000001000000100100",
	coffee: "000001000000100101",
	commbank: "000001000000100110",
	cologne: "000001000000100111",
	country: "000001000000101000",
	corsica: "000001000000101001",
	coupons: "000001000000101010",
	coupon: "000001000000101011",
	contact: "000001000000101100",
	consulting: "000001000000101101",
	cooking: "000001000000101110",
	contractors: "000001000000101111",
	citadel: "000001000000110000",
	cisco: "000001000000110001",
	citic: "000001000000110010",
	citi: "000001000000110011",
	chrome: "000001000000110100",
	christmas: "000001000000110101",
	circle: "000001000000110110",
	cipriani: "000001000000110111",
	clothing: "000001000000111000",
	clinique: "000001000000111001",
	coach: "000001000000111010",
	clubmed: "000001000000111011",
	claims: "000001000000111100",
	ck: "000001000000111101",
	clinic: "000001000000111110",
	cleaning: "000001000000111111",
	bcn: "000001000001000000",
	bcg: "000001000001000001",
	beauty: "000001000001000010",
	beats: "000001000001000011",
	bbc: "000001000001000100",
	bb: "000001000001000101",
	bbva: "000001000001000110",
	bbt: "000001000001000111",
	bible: "000001000001001000",
	bharti: "000001000001001001",
	bio: "000001000001001010",
	bing: "000001000001001011",
	bestbuy: "000001000001001100",
	best: "000001000001001101",
	bf: "000001000001001110",
	bet: "000001000001001111",
	azure: "000001000001010000",
	axa: "000001000001010001",
	banamex: "000001000001010010",
	baidu: "000001000001010011",
	aw: "000001000001010100",
	autos: "000001000001010101",
	ax: "000001000001010110",
	aws: "000001000001010111",
	baseball: "000001000001011000",
	bargains: "000001000001011001",
	bayern: "000001000001011010",
	bauhaus: "000001000001011011",
	barclaycard: "000001000001011100",
	barcelona: "000001000001011101",
	barefoot: "000001000001011110",
	barclays: "000001000001011111",
	box: "000001000001100000",
	boutique: "000001000001100001",
	bridgestone: "000001000001100010",
	bradesco: "000001000001100011",
	bosch: "000001000001100100",
	booking: "000001000001100101",
	boston: "000001000001100110",
	bostik: "000001000001100111",
	buy: "000001000001101000",
	bt: "000001000001101001",
	bzh: "000001000001101010",
	bv: "000001000001101011",
	broker: "000001000001101100",
	broadway: "000001000001101101",
	brussels: "000001000001101110",
	brother: "000001000001101111",
	bm: "000001000001110000",
	bloomberg: "000001000001110001",
	bmw: "000001000001110010",
	bms: "000001000001110011",
	black: "000001000001110100",
	bj: "000001000001110101",
	blockbuster: "000001000001110110",
	blackfriday: "000001000001110111",
	bond: "000001000001111000",
	bom: "000001000001111001",
	book: "000001000001111010",
	boo: "000001000001111011",
	boats: "000001000001111100",
	bnpparibas: "000001000001111101",
	bofa: "000001000001111110",
	boehringer: "000001000001111111",
	financial: "000001000010000000",
	final: "000001000010000001",
	firestone: "000001000010000010",
	fire: "000001000010000011",
	fidelity: "000001000010000100",
	ferrero: "000001000010000101",
	film: "000001000010000110",
	fido: "000001000010000111",
	flickr: "000001000010001000",
	fj: "000001000010001001",
	flir: "000001000010001010",
	flights: "000001000010001011",
	fish: "000001000010001100",
	firmdale: "000001000010001101",
	fit: "000001000010001110",
	fishing: "000001000010001111",
	fairwinds: "000001000010010000",
	fage: "000001000010010001",
	family: "000001000010010010",
	faith: "000001000010010011",
	eurovision: "000001000010010100",
	et: "000001000010010101",
	extraspace: "000001000010010110",
	express: "000001000010010111",
	fedex: "000001000010011000",
	fast: "000001000010011001",
	ferrari: "000001000010011010",
	feedback: "000001000010011011",
	fans: "000001000010011100",
	fan: "000001000010011101",
	fashion: "000001000010011110",
	farmers: "000001000010011111",
	gap: "000001000010100000",
	gallup: "000001000010100001",
	gb: "000001000010100010",
	gay: "000001000010100011",
	furniture: "000001000010100100",
	fujitsu: "000001000010100101",
	gallo: "000001000010100110",
	gal: "000001000010100111",
	gf: "000001000010101000",
	george: "000001000010101001",
	gift: "000001000010101010",
	ggee: "000001000010101011",
	gdn: "000001000010101100",
	gbiz: "000001000010101101",
	genting: "000001000010101110",
	gea: "000001000010101111",
	football: "000001000010110000",
	food: "000001000010110001",
	forex: "000001000010110010",
	ford: "000001000010110011",
	flowers: "000001000010110100",
	florist: "000001000010110101",
	foo: "000001000010110110",
	fly: "000001000010110111",
	frogans: "000001000010111000",
	fresenius: "000001000010111001",
	ftr: "000001000010111010",
	frontier: "000001000010111011",
	forum: "000001000010111100",
	forsale: "000001000010111101",
	free: "000001000010111110",
	fox: "000001000010111111",
	dealer: "000001000011000000",
	deal: "000001000011000001",
	delivery: "000001000011000010",
	degree: "000001000011000011",
	day: "000001000011000100",
	datsun: "000001000011000101",
	dds: "000001000011000110",
	dclk: "000001000011000111",
	dentist: "000001000011001000",
	dental: "000001000011001001",
	dhl: "000001000011001010",
	desi: "000001000011001011",
	deloitte: "000001000011001100",
	dell: "000001000011001101",
	democrat: "000001000011001110",
	delta: "000001000011001111",
	crown: "000001000011010000",
	creditunion: "000001000011010001",
	cruise: "000001000011010010",
	crs: "000001000011010011",
	cpa: "000001000011010100",
	courses: "000001000011010101",
	creditcard: "000001000011010110",
	credit: "000001000011010111",
	dad: "000001000011011000",
	cyou: "000001000011011001",
	date: "000001000011011010",
	data: "000001000011011011",
	cuisinella: "000001000011011100",
	cruises: "000001000011011101",
	cw: "000001000011011110",
	cv: "000001000011011111",
	edeka: "000001000011100000",
	eat: "000001000011100001",
	emerck: "000001000011100010",
	education: "000001000011100011",
	durban: "000001000011100100",
	dupont: "000001000011100101",
	dvr: "000001000011100110",
	dvag: "000001000011100111",
	ericsson: "000001000011101000",
	er: "000001000011101001",
	esq: "000001000011101010",
	erni: "000001000011101011",
	engineer: "000001000011101100",
	energy: "000001000011101101",
	epson: "000001000011101110",
	enterprises: "000001000011101111",
	discount: "000001000011110000",
	directory: "000001000011110001",
	dish: "000001000011110010",
	discover: "000001000011110011",
	diet: "000001000011110100",
	diamonds: "000001000011110101",
	direct: "000001000011110110",
	digital: "000001000011110111",
	dot: "000001000011111000",
	doctor: "000001000011111001",
	dubai: "000001000011111010",
	dtv: "000001000011111011",
	dm: "000001000011111100",
	diy: "000001000011111101",
	docs: "000001000011111110",
	dnp: "000001000011111111",
	fail: "0000010001000000",
	exposed: "0000010001000001",
	ge: "0000010001000010",
	finance: "0000010001000011",
	city: "0000010001000100",
	bo: "0000010001000101",
	domains: "0000010001000110",
	company: "0000010001000111",
	jo: "0000010001001000",
	ist: "0000010001001001",
	mo: "0000010001001010",
	kp: "0000010001001011",
	graphics: "0000010001001100",
	global: "0000010001001101",
	institute: "0000010001001110",
	ht: "0000010001001111",
	life: "00000100010100",
	by: "00000100010101",
	th: "00000100010110",
	news: "00000100010111",
	airbus: "000001000110000000",
	aig: "000001000110000001",
	airtel: "000001000110000010",
	airforce: "000001000110000011",
	aetna: "000001000110000100",
	aeg: "000001000110000101",
	agakhan: "000001000110000110",
	afl: "000001000110000111",
	ally: "000001000110001000",
	allstate: "000001000110001001",
	alstom: "000001000110001010",
	alsace: "000001000110001011",
	alibaba: "000001000110001100",
	akdn: "000001000110001101",
	allfinanz: "000001000110001110",
	alipay: "000001000110001111",
	abc: "000001000110010000",
	abbvie: "000001000110010001",
	abogado: "000001000110010010",
	able: "000001000110010011",
	aarp: "000001000110010100",
	aaa: "000001000110010101",
	abbott: "000001000110010110",
	abb: "000001000110010111",
	actor: "000001000110011000",
	aco: "000001000110011001",
	adult: "000001000110011010",
	ads: "000001000110011011",
	accenture: "000001000110011100",
	abudhabi: "000001000110011101",
	accountants: "000001000110011110",
	accountant: "000001000110011111",
	arte: "000001000110100000",
	arpa: "000001000110100001",
	associates: "000001000110100010",
	asda: "000001000110100011",
	aramco: "000001000110100100",
	arab: "000001000110100101",
	army: "000001000110100110",
	archi: "000001000110100111",
	auspost: "000001000110101000",
	audible: "000001000110101001",
	auto: "000001000110101010",
	author: "000001000110101011",
	attorney: "000001000110101100",
	athleta: "000001000110101101",
	audi: "000001000110101110",
	auction: "000001000110101111",
	amica: "000001000110110000",
	amfam: "000001000110110001",
	analytics: "000001000110110010",
	amsterdam: "000001000110110011",
	americanexpress: "000001000110110100",
	amazon: "000001000110110101",
	amex: "000001000110110110",
	americanfamily: "000001000110110111",
	apartments: "000001000110111000",
	aol: "000001000110111001",
	aquarelle: "000001000110111010",
	aq: "000001000110111011",
	anquan: "000001000110111100",
	android: "000001000110111101",
	ao: "000001000110111110",
	anz: "000001000110111111",
	pink: "0000010001110000",
	pictures: "0000010001110001",
	scot: "0000010001110010",
	science: "0000010001110011",
	museum: "0000010001110100",
	money: "0000010001110101",
	photos: "0000010001110110",
	np: "0000010001110111",
	travel: "0000010001111000",
	training: "0000010001111001",
	vu: "0000010001111010",
	tube: "0000010001111011",
	sm: "0000010001111100",
	show: "0000010001111101",
	theater: "0000010001111110",
	supply: "0000010001111111",
	sandvik: "000001001000000000",
	samsung: "000001001000000001",
	sanofi: "000001001000000010",
	sandvikcoromant: "000001001000000011",
	sale: "000001001000000100",
	sakura: "000001001000000101",
	samsclub: "000001001000000110",
	salon: "000001001000000111",
	sbi: "000001001000001000",
	saxo: "000001001000001001",
	scb: "000001001000001010",
	sbs: "000001001000001011",
	sarl: "000001001000001100",
	sap: "000001001000001101",
	save: "000001001000001110",
	sas: "000001001000001111",
	rodeo: "000001001000010000",
	rio: "000001001000010001",
	room: "000001001000010010",
	rogers: "000001001000010011",
	richardli: "000001001000010100",
	rich: "000001001000010101",
	ril: "000001001000010110",
	ricoh: "000001001000010111",
	saarland: "000001001000011000",
	ryukyu: "000001001000011001",
	safety: "000001001000011010",
	safe: "000001001000011011",
	ruhr: "000001001000011100",
	rsvp: "000001001000011101",
	rwe: "000001001000011110",
	rw: "000001001000011111",
	shiksha: "000001001000100000",
	shia: "000001001000100001",
	shopping: "000001001000100010",
	shoes: "000001001000100011",
	shangrila: "000001001000100100",
	sfr: "000001001000100101",
	shell: "000001001000100110",
	sharp: "000001001000100111",
	skin: "000001001000101000",
	ski: "000001001000101001",
	skype: "000001001000101010",
	sky: "000001001000101011",
	sina: "000001001000101100",
	shouji: "000001001000101101",
	sj: "000001001000101110",
	singles: "000001001000101111",
	sd: "000001001000110000",
	schwarz: "000001001000110001",
	seat: "000001001000110010",
	search: "000001001000110011",
	schmidt: "000001001000110100",
	schaeffler: "000001001000110101",
	schule: "000001001000110110",
	scholarships: "000001001000110111",
	seven: "000001001000111000",
	sener: "000001001000111001",
	sex: "000001001000111010",
	sew: "000001001000111011",
	security: "000001001000111100",
	secure: "000001001000111101",
	select: "000001001000111110",
	seek: "000001001000111111",
	play: "000001001001000000",
	pioneer: "000001001001000001",
	plumbing: "000001001001000010",
	playstation: "000001001001000011",
	pid: "000001001001000100",
	pictet: "000001001001000101",
	ping: "000001001001000110",
	pin: "000001001001000111",
	praxi: "000001001001001000",
	post: "000001001001001001",
	prod: "000001001001001010",
	prime: "000001001001001011",
	pohl: "000001001001001100",
	pnc: "000001001001001101",
	porn: "000001001001001110",
	politie: "000001001001001111",
	pars: "000001001001010000",
	paris: "000001001001010001",
	parts: "000001001001010010",
	partners: "000001001001010011",
	ott: "000001001001010100",
	otsuka: "000001001001010101",
	panasonic: "000001001001010110",
	page: "000001001001010111",
	philips: "000001001001011000",
	phd: "000001001001011001",
	physio: "000001001001011010",
	phone: "000001001001011011",
	pccw: "000001001001011100",
	pay: "000001001001011101",
	pg: "000001001001011110",
	pfizer: "000001001001011111",
	reisen: "000001001001100000",
	reise: "000001001001100001",
	reliance: "000001001001100010",
	reit: "000001001001100011",
	recipes: "000001001001100100",
	realty: "000001001001100101",
	rehab: "000001001001100110",
	redumbrella: "000001001001100111",
	rest: "000001001001101000",
	republican: "000001001001101001",
	rexroth: "000001001001101010",
	restaurant: "000001001001101011",
	rent: "000001001001101100",
	ren: "000001001001101101",
	repair: "000001001001101110",
	rentals: "000001001001101111",
	pru: "000001001001110000",
	protection: "000001001001110001",
	pwc: "000001001001110010",
	prudential: "000001001001110011",
	progressive: "000001001001110100",
	prof: "000001001001110101",
	property: "000001001001110110",
	promo: "000001001001110111",
	read: "000001001001111000",
	radio: "000001001001111001",
	realtor: "000001001001111010",
	realestate: "000001001001111011",
	quebec: "000001001001111100",
	qpon: "000001001001111101",
	racing: "000001001001111110",
	quest: "000001001001111111",
	verisign: "000001001010000000",
	ventures: "000001001010000001",
	vet: "000001001010000010",
	versicherung: "000001001010000011",
	ups: "000001001010000100",
	uol: "000001001010000101",
	vana: "000001001010000110",
	vacations: "000001001010000111",
	vin: "000001001010001000",
	villas: "000001001010001001",
	visa: "000001001010001010",
	virgin: "000001001010001011",
	viajes: "000001001010001100",
	vi: "000001001010001101",
	viking: "000001001010001110",
	vig: "000001001010001111",
	travelers: "000001001010010000",
	trading: "000001001010010001",
	trv: "000001001010010010",
	travelersinsurance: "000001001010010011",
	town: "000001001010010100",
	tours: "000001001010010101",
	toys: "000001001010010110",
	toyota: "000001001010010111",
	ubs: "000001001010011000",
	ubank: "000001001010011001",
	university: "000001001010011010",
	unicom: "000001001010011011",
	tunes: "000001001010011100",
	tui: "000001001010011101",
	tvs: "000001001010011110",
	tushu: "000001001010011111",
	whoswho: "000001001010100000",
	wf: "000001001010100001",
	windows: "000001001010100010",
	williamhill: "000001001010100011",
	wedding: "000001001010100100",
	wed: "000001001010100101",
	weir: "000001001010100110",
	weibo: "000001001010100111",
	wtc: "000001001010101000",
	wow: "000001001010101001",
	xerox: "000001001010101010",
	xbox: "000001001010101011",
	winners: "000001001010101100",
	wine: "000001001010101101",
	woodside: "000001001010101110",
	wme: "000001001010101111",
	voting: "000001001010110000",
	volvo: "000001001010110001",
	voyage: "000001001010110010",
	voto: "000001001010110011",
	vivo: "000001001010110100",
	viva: "000001001010110101",
	vodka: "000001001010110110",
	vlaanderen: "000001001010110111",
	weather: "000001001010111000",
	watches: "000001001010111001",
	weber: "000001001010111010",
	weatherchannel: "000001001010111011",
	walter: "000001001010111100",
	walmart: "000001001010111101",
	wanggou: "000001001010111110",
	wang: "000001001010111111",
	stockholm: "000001001011000000",
	stcgroup: "000001001011000001",
	study: "000001001011000010",
	storage: "000001001011000011",
	statebank: "000001001011000100",
	star: "000001001011000101",
	stc: "000001001011000110",
	statefarm: "000001001011000111",
	swatch: "000001001011001000",
	sv: "000001001011001001",
	sydney: "000001001011001010",
	swiss: "000001001011001011",
	surf: "000001001011001100",
	sucks: "000001001011001101",
	suzuki: "000001001011001110",
	surgery: "000001001011001111",
	softbank: "000001001011010000",
	soccer: "000001001011010001",
	song: "000001001011010010",
	sohu: "000001001011010011",
	sling: "000001001011010100",
	sl: "000001001011010101",
	smile: "000001001011010110",
	smart: "000001001011010111",
	ss: "000001001011011000",
	srl: "000001001011011001",
	staples: "000001001011011010",
	stada: "000001001011011011",
	spa: "000001001011011100",
	soy: "000001001011011101",
	spot: "000001001011011110",
	sport: "000001001011011111",
	tienda: "000001001011100000",
	tiaa: "000001001011100001",
	tirol: "000001001011100010",
	tires: "000001001011100011",
	tg: "000001001011100100",
	teva: "000001001011100101",
	theatre: "000001001011100110",
	thd: "000001001011100111",
	toray: "000001001011101000",
	tmall: "000001001011101001",
	total: "000001001011101010",
	toshiba: "000001001011101011",
	tjmaxx: "000001001011101100",
	tj: "000001001011101101",
	tkmaxx: "000001001011101110",
	tjx: "000001001011101111",
	target: "000001001011110000",
	taobao: "000001001011110001",
	tatar: "000001001011110010",
	tatamotors: "000001001011110011",
	tab: "000001001011110100",
	sz: "000001001011110101",
	talk: "000001001011110110",
	taipei: "000001001011110111",
	tel: "000001001011111000",
	tdk: "000001001011111001",
	tennis: "000001001011111010",
	temasek: "000001001011111011",
	taxi: "000001001011111100",
	tattoo: "000001001011111101",
	td: "000001001011111110",
	tci: "000001001011111111",
	jll: "000001001100000000",
	jio: "000001001100000001",
	jmp: "000001001100000010",
	jm: "000001001100000011",
	jeep: "000001001100000100",
	jcb: "000001001100000101",
	jewelry: "000001001100000110",
	jetzt: "000001001100000111",
	jprs: "000001001100001000",
	jpmorgan: "000001001100001001",
	juniper: "000001001100001010",
	juegos: "000001001100001011",
	joburg: "000001001100001100",
	jnj: "000001001100001101",
	joy: "000001001100001110",
	jot: "000001001100001111",
	insure: "000001001100010000",
	insurance: "000001001100010001",
	investments: "000001001100010010",
	intuit: "000001001100010011",
	inc: "000001001100010100",
	immobilien: "000001001100010101",
	infiniti: "000001001100010110",
	industries: "000001001100010111",
	itv: "000001001100011000",
	itau: "000001001100011001",
	java: "000001001100011010",
	jaguar: "000001001100011011",
	irish: "000001001100011100",
	ipiranga: "000001001100011101",
	istanbul: "000001001100011110",
	ismaili: "000001001100011111",
	kuokgroup: "000001001100100000",
	kred: "000001001100100001",
	kyoto: "000001001100100010",
	ky: "000001001100100011",
	kpmg: "000001001100100100",
	kosher: "000001001100100101",
	krd: "000001001100100110",
	kpn: "000001001100100111",
	lasalle: "000001001100101000",
	lanxess: "000001001100101001",
	latino: "000001001100101010",
	lat: "000001001100101011",
	lamborghini: "000001001100101100",
	lacaixa: "000001001100101101",
	landrover: "000001001100101110",
	lamer: "000001001100101111",
	kg: "000001001100110000",
	kfh: "000001001100110001",
	kids: "000001001100110010",
	kia: "000001001100110011",
	kddi: "000001001100110100",
	kaufen: "000001001100110101",
	kerryproperties: "000001001100110110",
	kerryhotels: "000001001100110111",
	kn: "000001001100111000",
	km: "000001001100111001",
	komatsu: "000001001100111010",
	koeln: "000001001100111011",
	kindle: "000001001100111100",
	kim: "000001001100111101",
	kiwi: "000001001100111110",
	kitchen: "000001001100111111",
	gu: "000001001101000000",
	grocery: "000001001101000001",
	guge: "000001001101000010",
	gucci: "000001001101000011",
	gratis: "000001001101000100",
	grainger: "000001001101000101",
	gripe: "000001001101000110",
	green: "000001001101000111",
	hdfc: "000001001101001000",
	hbo: "000001001101001001",
	healthcare: "000001001101001010",
	hdfcbank: "000001001101001011",
	gw: "000001001101001100",
	guitars: "000001001101001101",
	hangout: "000001001101001110",
	hair: "000001001101001111",
	gmbh: "000001001101010000",
	gmail: "000001001101010001",
	gmx: "000001001101010010",
	gmo: "000001001101010011",
	giving: "000001001101010100",
	gifts: "000001001101010101",
	globo: "000001001101010110",
	glass: "000001001101010111",
	goog: "000001001101011000",
	goodyear: "000001001101011001",
	got: "000001001101011010",
	gop: "000001001101011011",
	godaddy: "000001001101011100",
	gn: "000001001101011101",
	golf: "000001001101011110",
	goldpoint: "000001001101011111",
	hyatt: "000001001101100000",
	hughes: "000001001101100001",
	ibm: "000001001101100010",
	hyundai: "000001001101100011",
	hotmail: "000001001101100100",
	hotels: "000001001101100101",
	hsbc: "000001001101100110",
	house: "000001001101100111",
	imamat: "000001001101101000",
	ikano: "000001001101101001",
	immo: "000001001101101010",
	imdb: "000001001101101011",
	ice: "000001001101101100",
	icbc: "000001001101101101",
	ifm: "000001001101101110",
	ieee: "000001001101101111",
	hiv: "000001001101110000",
	hitachi: "000001001101110001",
	holiday: "000001001101110010",
	hkt: "000001001101110011",
	here: "000001001101110100",
	helsinki: "000001001101110101",
	hisamitsu: "000001001101110110",
	hermes: "000001001101110111",
	hospital: "000001001101111000",
	honda: "000001001101111001",
	hot: "000001001101111010",
	hosting: "000001001101111011",
	homegoods: "000001001101111100",
	homedepot: "000001001101111101",
	homesense: "000001001101111110",
	homes: "000001001101111111",
	nab: "000001001110000000",
	mz: "000001001110000001",
	navy: "000001001110000010",
	nagoya: "000001001110000011",
	mtn: "000001001110000100",
	msd: "000001001110000101",
	music: "000001001110000110",
	mtr: "000001001110000111",
	next: "000001001110001000",
	neustar: "000001001110001001",
	nexus: "000001001110001010",
	nextdirect: "000001001110001011",
	nec: "000001001110001100",
	nba: "000001001110001101",
	netflix: "000001001110001110",
	netbank: "000001001110001111",
	moi: "000001001110010000",
	moda: "000001001110010001",
	monster: "000001001110010010",
	mom: "000001001110010011",
	mm: "000001001110010100",
	mls: "000001001110010101",
	mobile: "000001001110010110",
	mma: "000001001110010111",
	mov: "000001001110011000",
	motorcycles: "000001001110011001",
	mr: "000001001110011010",
	mq: "000001001110011011",
	mortgage: "000001001110011100",
	mormon: "000001001110011101",
	moto: "000001001110011110",
	moscow: "000001001110011111",
	ollo: "000001001110100000",
	olayangroup: "000001001110100001",
	omega: "000001001110100010",
	om: "000001001110100011",
	office: "000001001110100100",
	observer: "000001001110100101",
	olayan: "000001001110100110",
	okinawa: "000001001110100111",
	organic: "000001001110101000",
	orange: "000001001110101001",
	osaka: "000001001110101010",
	origins: "000001001110101011",
	ooo: "000001001110101100",
	ong: "000001001110101101",
	oracle: "000001001110101110",
	open: "000001001110101111",
	nikon: "000001001110110000",
	nike: "000001001110110001",
	nissay: "000001001110110010",
	nissan: "000001001110110011",
	ngo: "000001001110110100",
	nfl: "000001001110110101",
	nico: "000001001110110110",
	nhk: "000001001110110111",
	nra: "000001001110111000",
	nowtv: "000001001110111001",
	obi: "000001001110111010",
	ntt: "000001001110111011",
	norton: "000001001110111100",
	nokia: "000001001110111101",
	nowruz: "000001001110111110",
	now: "000001001110111111",
	loans: "000001001111000000",
	loan: "000001001111000001",
	locus: "000001001111000010",
	locker: "000001001111000011",
	living: "000001001111000100",
	lincoln: "000001001111000101",
	llp: "000001001111000110",
	llc: "000001001111000111",
	ltd: "000001001111001000",
	ls: "000001001111001001",
	lundbeck: "000001001111001010",
	ltda: "000001001111001011",
	lotto: "000001001111001100",
	lotte: "000001001111001101",
	lplfinancial: "000001001111001110",
	lpl: "000001001111001111",
	lefrak: "000001001111010000",
	leclerc: "000001001111010001",
	lexus: "000001001111010010",
	lego: "000001001111010011",
	lawyer: "000001001111010100",
	latrobe: "000001001111010101",
	lease: "000001001111010110",
	lds: "000001001111010111",
	lilly: "000001001111011000",
	lighting: "000001001111011001",
	limo: "000001001111011010",
	limited: "000001001111011011",
	lidl: "000001001111011100",
	lgbt: "000001001111011101",
	lifestyle: "000001001111011110",
	lifeinsurance: "000001001111011111",
	menu: "000001001111100000",
	memorial: "000001001111100001",
	merckmsd: "000001001111100010",
	merck: "000001001111100011",
	med: "000001001111100100",
	mckinsey: "000001001111100101",
	meme: "000001001111100110",
	meet: "000001001111100111",
	mit: "000001001111101000",
	mint: "000001001111101001",
	mlb: "000001001111101010",
	mitsubishi: "000001001111101011",
	miami: "000001001111101100",
	mh: "000001001111101101",
	mini: "000001001111101110",
	microsoft: "000001001111101111",
	makeup: "000001001111110000",
	maison: "000001001111110001",
	management: "000001001111110010",
	man: "000001001111110011",
	luxury: "000001001111110100",
	luxe: "000001001111110101",
	maif: "000001001111110110",
	madrid: "000001001111110111",
	mattel: "000001001111111000",
	marshalls: "000001001111111001",
	mc: "000001001111111010",
	mba: "000001001111111011",
	map: "000001001111111100",
	mango: "000001001111111101",
	marriott: "000001001111111110",
	markets: "000001001111111111",
	bw: "00000101000000000",
	buzz: "00000101000000001",
	casa: "00000101000000010",
	camera: "00000101000000011",
	bot: "00000101000000100",
	bh: "00000101000000101",
	builders: "00000101000000110",
	bs: "00000101000000111",
	cool: "00000101000001000",
	computer: "00000101000001001",
	dog: "00000101000001010",
	dating: "00000101000001011",
	church: "00000101000001100",
	cd: "00000101000001101",
	click: "00000101000001110",
	ci: "00000101000001111",
	win: "000001010000100",
	sa: "000001010000101",
	bank: "00000101000011000",
	baby: "00000101000011001",
	berlin: "00000101000011010",
	basketball: "00000101000011011",
	works: "000001010000111",
	iq: "00000101000100000",
	ing: "00000101000100001",
	kh: "00000101000100010",
	je: "00000101000100011",
	hm: "00000101000100100",
	hiphop: "00000101000100101",
	horse: "00000101000100110",
	holdings: "00000101000100111",
	melbourne: "00000101000101000",
	marketing: "00000101000101001",
	monash: "00000101000101010",
	men: "00000101000101011",
	kz: "00000101000101100",
	kw: "00000101000101101",
	lr: "00000101000101110",
	like: "00000101000101111",
	eus: "00000101000110000",
	estate: "00000101000110001",
	gallery: "00000101000110010",
	fk: "00000101000110011",
	dz: "00000101000110100",
	drive: "00000101000110101",
	equipment: "00000101000110110",
	eco: "00000101000110111",
	group: "00000101000111000",
	gp: "00000101000111001",
	health: "00000101000111010",
	hamburg: "00000101000111011",
	gh: "00000101000111100",
	garden: "00000101000111101",
	gold: "00000101000111110",
	gi: "00000101000111111",
	trade: "0000010100100",
	cloud: "0000010100101",
	lk: "000001010011000",
	host: "000001010011001",
	press: "000001010011010",
	pr: "000001010011011",
	cafe: "000001010011100",
	ba: "000001010011101",
	eg: "000001010011110",
	earth: "000001010011111",
	"xn--lgbbat1ad8j": "000001010100000000",
	"xn--l1acc": "000001010100000001",
	"xn--mgba3a3ejt": "000001010100000010",
	"xn--mgb9awbf": "000001010100000011",
	"xn--kprw13d": "000001010100000100",
	"xn--kcrx77d1x4a": "000001010100000101",
	"xn--kput3i": "000001010100000110",
	"xn--kpry57d": "000001010100000111",
	"xn--mgbai9azgqp6j": "000001010100001000",
	"xn--mgbah1a3hjkrd": "000001010100001001",
	"xn--mgbbh1a": "000001010100001010",
	"xn--mgbayh7gpa": "000001010100001011",
	"xn--mgba7c0bbn0a": "000001010100001100",
	"xn--mgba3a4f16a": "000001010100001101",
	"xn--mgbab2bd": "000001010100001110",
	"xn--mgbaam7a8h": "000001010100001111",
	"xn--h2brj9c": "000001010100010000",
	"xn--h2breg3eve": "000001010100010001",
	"xn--hxt814e": "000001010100010010",
	"xn--h2brj9c8c": "000001010100010011",
	"xn--gckr3f0f": "000001010100010100",
	"xn--g2xx48c": "000001010100010101",
	"xn--gk3at1e": "000001010100010110",
	"xn--gecrj9c": "000001010100010111",
	"xn--j6w193g": "000001010100011000",
	"xn--j1amh": "000001010100011001",
	"xn--jvr189m": "000001010100011010",
	"xn--jlq480n2rg": "000001010100011011",
	"xn--imr513n": "000001010100011100",
	"xn--i1b6b1a6a2e": "000001010100011101",
	"xn--j1aef": "000001010100011110",
	"xn--io0a7i": "000001010100011111",
	"xn--o3cw4h": "000001010100100000",
	"xn--nyqy26a": "000001010100100001",
	"xn--otu796d": "000001010100100010",
	"xn--ogbpf8fl": "000001010100100011",
	"xn--node": "000001010100100100",
	"xn--ngbrx": "000001010100100101",
	"xn--nqv7fs00ema": "000001010100100110",
	"xn--nqv7f": "000001010100100111",
	"xn--qcka1pmc": "000001010100101000",
	"xn--q9jyb4c": "000001010100101001",
	"xn--qxam": "000001010100101010",
	"xn--qxa6a": "000001010100101011",
	"xn--pgbs0dh": "000001010100101100",
	"xn--p1acf": "000001010100101101",
	"xn--q7ce6a": "000001010100101110",
	"xn--pssy2u": "000001010100101111",
	"xn--mgbgu82a": "000001010100110000",
	"xn--mgberp4a5d4ar": "000001010100110001",
	"xn--mgbpl2fh": "000001010100110010",
	"xn--mgbi4ecexp": "000001010100110011",
	"xn--mgbc0a9azcg": "000001010100110100",
	"xn--mgbbh1a71e": "000001010100110101",
	"xn--mgbcpq6gpa1a": "000001010100110110",
	"xn--mgbca7dzdo": "000001010100110111",
	"xn--mxtq1m": "000001010100111000",
	"xn--mk1bu44c": "000001010100111001",
	"xn--ngbe9e0a": "000001010100111010",
	"xn--ngbc5azd": "000001010100111011",
	"xn--mgbtx2b": "000001010100111100",
	"xn--mgbt3dhd": "000001010100111101",
	"xn--mix891f": "000001010100111110",
	"xn--mgbx4cd0ab": "000001010100111111",
	"xn--5su34j936bgsg": "000001010101000000",
	"xn--55qx5d": "000001010101000001",
	"xn--6frz82g": "000001010101000010",
	"xn--5tzm5g": "000001010101000011",
	"xn--4gbrim": "000001010101000100",
	"xn--4dbrk0ce": "000001010101000101",
	"xn--55qw42g": "000001010101000110",
	"xn--54b7fta0cc": "000001010101000111",
	"xn--80aswg": "000001010101001000",
	"xn--80asehdb": "000001010101001001",
	"xn--90a3ac": "000001010101001010",
	"xn--8y0a063a": "000001010101001011",
	"xn--80adxhks": "000001010101001100",
	"xn--6qq986b3xl": "000001010101001101",
	"xn--80aqecdr1a": "000001010101001110",
	"xn--80ao21a": "000001010101001111",
	"xn--2scrj9c": "000001010101010000",
	"xn--1qqw23a": "000001010101010001",
	"xn--3bst00m": "000001010101010010",
	"xn--30rr7y": "000001010101010011",
	xin: "000001010101010100",
	xihuan: "000001010101010101",
	"xn--1ck2e1b": "000001010101010110",
	"xn--11b4c3d": "000001010101010111",
	"xn--45br5cyl": "000001010101011000",
	"xn--42c2d9a": "000001010101011001",
	"xn--45q11c": "000001010101011010",
	"xn--45brj9c": "000001010101011011",
	"xn--3e0b707e": "000001010101011100",
	"xn--3ds443g": "000001010101011101",
	"xn--3pxu8k": "000001010101011110",
	"xn--3hcrj9c": "000001010101011111",
	"xn--fct429k": "000001010101100000",
	"xn--efvy88h": "000001010101100001",
	"xn--fiq228c5hs": "000001010101100010",
	"xn--fhbei": "000001010101100011",
	"xn--d1alf": "000001010101100100",
	"xn--d1acj3b": "000001010101100101",
	"xn--eckvdtc9d": "000001010101100110",
	"xn--e1a4c": "000001010101100111",
	"xn--fpcrj9c3d": "000001010101101000",
	"xn--flw351e": "000001010101101001",
	"xn--fzys8d69uvgm": "000001010101101010",
	"xn--fzc2c9e2c": "000001010101101011",
	"xn--fiqs8s": "000001010101101100",
	"xn--fiq64b": "000001010101101101",
	"xn--fjq720a": "000001010101101110",
	"xn--fiqz9s": "000001010101101111",
	"xn--b4w605ferd": "000001010101110000",
	"xn--9krt00a": "000001010101110001",
	"xn--c1avg": "000001010101110010",
	"xn--bck1b9a5dre4c": "000001010101110011",
	"xn--90ais": "000001010101110100",
	"xn--90ae": "000001010101110101",
	"xn--9et52u": "000001010101110110",
	"xn--9dbq2a": "000001010101110111",
	"xn--czr694b": "000001010101111000",
	"xn--clchc0ea0b2g2a9gcd": "000001010101111001",
	"xn--czru2d": "000001010101111010",
	"xn--czrs0t": "000001010101111011",
	"xn--cck2b3b": "000001010101111100",
	"xn--c2br7g": "000001010101111101",
	"xn--cg4bki": "000001010101111110",
	"xn--cckwcxetd": "000001010101111111",
	silk: "00000101011000000",
	school: "00000101011000001",
	software: "00000101011000010",
	sncf: "00000101011000011",
	qa: "00000101011000100",
	productions: "00000101011000101",
	sb: "00000101011000110",
	reviews: "00000101011000111",
	tickets: "00000101011001000",
	supplies: "00000101011001001",
	tn: "00000101011001010",
	tm: "00000101011001011",
	sony: "00000101011001100",
	solar: "00000101011001101",
	style: "00000101011001110",
	sr: "00000101011001111",
	new: "00000101011010000",
	nc: "00000101011010001",
	ni: "00000101011010010",
	nf: "00000101011010011",
	mv: "00000101011010100",
	movie: "00000101011010101",
	na: "00000101011010110",
	mw: "00000101011010111",
	photo: "00000101011011000",
	pharmacy: "00000101011011001",
	poker: "00000101011011010",
	photography: "00000101011011011",
	pa: "00000101011011100",
	nrw: "00000101011011101",
	pf: "00000101011011110",
	pet: "00000101011011111",
	"xn--yfro4i67o": "000001010111000000",
	"xn--y9a3aq": "000001010111000001",
	"xn--zfr164b": "000001010111000010",
	"xn--ygbi2ammx": "000001010111000011",
	"xn--xhq521b": "000001010111000100",
	"xn--wgbl6a": "000001010111000101",
	"xn--xkc2dl3a5ee0h": "000001010111000110",
	"xn--xkc2al3hye2a": "000001010111000111",
	yodobashi: "000001010111001000",
	ye: "000001010111001001",
	yokohama: "000001010111001010",
	yoga: "000001010111001011",
	yahoo: "000001010111001100",
	yachts: "000001010111001101",
	yandex: "000001010111001110",
	yamaxun: "000001010111001111",
	"xn--t60b56a": "000001010111010000",
	"xn--ses554g": "000001010111010001",
	"xn--tiq49xqyj": "000001010111010010",
	"xn--tckwe": "000001010111010011",
	"xn--rovu88b": "000001010111010100",
	"xn--rhqv96g": "000001010111010101",
	"xn--s9brj9c": "000001010111010110",
	"xn--rvc1e0am3e": "000001010111010111",
	"xn--w4r85el8fhu5dnra": "000001010111011000",
	"xn--vuq861b": "000001010111011001",
	"xn--wgbh1c": "000001010111011010",
	"xn--w4rs40l": "000001010111011011",
	"xn--vermgensberater-ctb": "000001010111011100",
	"xn--unup4y": "000001010111011101",
	"xn--vhquv": "000001010111011110",
	"xn--vermgensberatung-pwb": "000001010111011111",
	uz: "00000101011110000",
	uno: "00000101011110001",
	vision: "00000101011110010",
	vanguard: "00000101011110011",
	trust: "00000101011110100",
	tokyo: "00000101011110101",
	ug: "00000101011110110",
	tz: "00000101011110111",
	zero: "000001010111110000",
	zara: "000001010111110001",
	zuerich: "000001010111110010",
	zm: "000001010111110011",
	youtube: "000001010111110100",
	you: "000001010111110101",
	zappos: "000001010111110110",
	yun: "000001010111110111",
	wien: "00000101011111100",
	webcam: "00000101011111101",
	"": "000001010111111100",
	zw: "000001010111111101",
	yt: "00000101011111111",
	dk: "000001011",
	gl: "00000110",
	cc: "0000011100",
	la: "000001110100",
	space: "000001110101",
	ag: "00000111011000",
	uy: "00000111011001",
	stream: "0000011101101",
	im: "000001110111",
	ie: "0000011110",
	sk: "0000011111000",
	dance: "00000111110010",
	cr: "00000111110011",
	ee: "000001111101",
	pub: "00000111111000",
	pe: "00000111111001",
	work: "0000011111101",
	ninja: "0000011111110",
	id: "0000011111111",
	au: "0000100",
	to: "0000101000",
	ua: "0000101001",
	fr: "000010101",
	nl: "000010110",
	mg: "0000101110",
	int: "00001011110",
	app: "0000101111100",
	cx: "00001011111010",
	bid: "00001011111011",
	af: "0000101111110000",
	ad: "00001011111100010",
	zip: "00001011111100011",
	ve: "000010111111001",
	xxx: "00001011111101",
	jobs: "000010111111100",
	asia: "000010111111101",
	run: "000010111111110",
	nyc: "000010111111111",
	tv: "0000110",
	sh: "00001110",
	media: "00001111000000",
	ec: "00001111000001",
	vg: "00001111000010",
	tk: "00001111000011",
	ai: "0000111100010",
	tr: "0000111100011",
	at: "00001111001",
	club: "00001111010",
	ph: "000011110110",
	al: "000011110111000",
	cy: "0000111101110010",
	cm: "0000111101110011",
	icu: "00001111011101",
	ac: "00001111011110",
	mk: "000011110111110",
	exchange: "000011110111111",
	nz: "000011111",
	it: "00010",
	me: "0001100",
	ch: "0001101000",
	ws: "000110100100",
	rocks: "000110100101",
	va: "0001101001100",
	lu: "0001101001101",
	pn: "000110100111000",
	pm: "000110100111001",
	store: "000110100111010",
	red: "000110100111011",
	gd: "0001101001111",
	se: "000110101",
	moe: "0001101100",
	wiki: "0001101101",
	lc: "0001101110000000",
	ke: "0001101110000001",
	md: "0001101110000010",
	ma: "0001101110000011",
	fitness: "0001101110000100",
	email: "0001101110000101",
	how: "0001101110000110",
	games: "0001101110000111",
	social: "0001101110001000",
	rip: "0001101110001001",
	vc: "0001101110001010",
	solutions: "0001101110001011",
	ne: "0001101110001100",
	mt: "0001101110001101",
	py: "0001101110001110",
	ovh: "0001101110001111",
	review: "00011011100100",
	gy: "00011011100101",
	ir: "0001101110011",
	mil: "00011011101",
	fun: "0001101111000",
	rs: "0001101111001",
	sc: "000110111101",
	cf: "000110111110",
	sg: "000110111111",
	is: "0001110",
	ru: "0001111",
	be: "0010",
	net: "0011",
	info: "010000",
	jp: "0100010",
	hu: "010001100000",
	fyi: "01000110000100",
	gq: "010001100001010",
	download: "010001100001011",
	audio: "0100011000011000",
	band: "01000110000110010",
	as: "01000110000110011",
	watch: "010001100001101",
	pizza: "01000110000111",
	place: "010001100010000",
	land: "010001100010001",
	sn: "010001100010010",
	shop: "010001100010011",
	nu: "0100011000101",
	gr: "010001100011",
	kr: "01000110010",
	ro: "01000110011",
	"xn--p1ai": "010001101",
	party: "01000111000000",
	gle: "01000111000001",
	online: "0100011100001",
	li: "0100011100010",
	si: "0100011100011",
	pt: "01000111001",
	cn: "01000111010",
	my: "0100011101100",
	tech: "01000111011010",
	name: "01000111011011",
	tw: "010001110111",
	su: "010001111",
	co: "0100100",
	ms: "010010100",
	fo: "01001010100",
	law: "01001010101000000",
	ki: "01001010101000001",
	love: "01001010101000010",
	legal: "01001010101000011",
	hn: "01001010101000100",
	gt: "01001010101000101",
	international: "01001010101000110",
	hockey: "01001010101000111",
	support: "01001010101001000",
	services: "01001010101001001",
	systems: "01001010101001010",
	sy: "01001010101001011",
	onl: "01001010101001100",
	nr: "01001010101001101",
	rugby: "01001010101001110",
	properties: "01001010101001111",
	engineering: "01001010101010000",
	dev: "01001010101010001",
	foundation: "01001010101010010",
	expert: "01001010101010011",
	center: "01001010101010100",
	capital: "01001010101010101",
	cymru: "01001010101010110",
	cu: "01001010101010111",
	gives: "01001010101011000",
	gent: "01001010101011001",
	google: "01001010101011010",
	gm: "01001010101011011",
	fund: "01001010101011100",
	frl: "01001010101011101",
	game: "01001010101011110",
	futbol: "01001010101011111",
	bn: "0100101010110000",
	az: "0100101010110001",
	deals: "0100101010110010",
	community: "0100101010110011",
	zone: "01001010101101",
	vip: "0100101010111000",
	team: "0100101010111001",
	vegas: "01001010101110100",
	tax: "01001010101110101",
	wales: "01001010101110110",
	vote: "01001010101110111",
	london: "0100101010111100",
	events: "0100101010111101",
	ps: "0100101010111110",
	mu: "0100101010111111",
	pk: "0100101011000",
	ga: "0100101011001",
	world: "010010101101000",
	ng: "010010101101001",
	build: "01001010110101000",
	blue: "01001010110101001",
	camp: "01001010110101010",
	business: "01001010110101011",
	bd: "01001010110101100",
	bar: "01001010110101101",
	bingo: "01001010110101110",
	bi: "01001010110101111",
	tf: "0100101011011",
	pl: "01001010111",
	za: "010010110000",
	so: "010010110001",
	pw: "010010110010",
	pro: "010010110011",
	ar: "01001011010",
	ml: "010010110110",
	am: "010010110111",
	today: "0100101110",
	lv: "01001011110000",
	coop: "010010111100010",
	video: "010010111100011",
	tl: "01001011110010",
	mp: "010010111100110",
	mobi: "010010111100111",
	haus: "010010111101",
	network: "0100101111100",
	tc: "010010111110100",
	plus: "010010111110101",
	website: "01001011111011",
	mx: "010010111111",
	gov: "010011",
	uk: "010100",
	edu: "0101010",
	gg: "0101011",
	in: "0101100000",
	br: "0101100001",
	fm: "010110001",
	de: "01011001",
	eu: "010110100",
	re: "010110101000",
	sx: "01011010100100",
	lol: "010110101001010",
	bike: "0101101010010110",
	aero: "0101101010010111",
	hk: "0101101010011",
	vn: "0101101010100",
	sexy: "01011010101010",
	agency: "01011010101011000",
	apple: "010110101010110010",
	africa: "010110101010110011",
	tips: "0101101010101101",
	tools: "010110101010111",
	cat: "0101101010110",
	chat: "0101101010111000",
	cards: "0101101010111001",
	cricket: "0101101010111010",
	codes: "0101101010111011",
	blog: "01011010101111",
	fi: "01011010110",
	pics: "0101101011100000",
	ink: "0101101011100001",
	studio: "0101101011100010",
	report: "0101101011100011",
	dj: "0101101011100100",
	design: "0101101011100101",
	help: "0101101011100110",
	farm: "0101101011100111",
	bg: "01011010111010",
	do: "010110101110110",
	academy: "0101101011101110",
	beer: "01011010111011110",
	art: "01011010111011111",
	guide: "0101101011110",
	site: "01011010111110",
	one: "01011010111111",
	ly: "010110110",
	cz: "010110111000",
	st: "0101101110010",
	cl: "01011011100110",
	gs: "010110111001110",
	bz: "010110111001111",
	no: "01011011101",
	live: "010110111100",
	link: "010110111101",
	cash: "010110111110",
	lb: "010110111111000",
	guru: "010110111111001",
	technology: "010110111111010",
	mn: "010110111111011",
	il: "0101101111111",
	ca: "0101110",
	io: "0101111",
	org: "011",
	com: "1"
}, m = {
	"cydia.saurik": "000000000000",
	"images.wikia": "000000000001",
	juicedb: "000000000010",
	imgflip: "000000000011",
	globalresearch: "0000000001000",
	csmonitor: "00000000010010",
	"bmw.com": "00000000010011",
	"images.app.goo": "000000000101",
	"docs.microsoft": "000000000110",
	"500px": "000000000111",
	radd: "0000000010",
	boardgamegeek: "0000000011",
	autosedlo: "0000000100",
	redditinvestigator: "00000001010",
	sciencedirect: "00000001011",
	downtown: "00000001100",
	"yugioh.wikia": "00000001101",
	"express.co": "0000000111000",
	"shop.nordstrom": "0000000111001",
	"battlelog.battlefield": "0000000111010",
	asus: "0000000111011",
	foodnetwork: "0000000111100",
	sfgate: "0000000111101",
	"developer.mozilla": "0000000111110",
	"9gag": "0000000111111",
	weeklysift: "0000001000000",
	rbeertrade: "0000001000001",
	"podcasts.apple": "000000100001",
	bitcoin: "0000001000100",
	"247sports": "0000001000101",
	zkillboard: "0000001000110",
	"i2.wp": "0000001000111",
	"amazon.co": "0000001001",
	latimes: "00000010100",
	"botrank.pastimes": "000000101010",
	"a.video.nfl": "000000101011",
	craigslist: "000000101100",
	ontheissues: "0000001011010",
	fimfiction: "0000001011011",
	"reddit.zendesk": "00000010111",
	edhrec: "00000011",
	slate: "00000100000",
	salon: "000001000010",
	seriouseats: "000001000011",
	goodreads: "0000010001",
	artstation: "0000010010",
	"bbc.co": "0000010011",
	adl: "00000101000000",
	atf: "00000101000001",
	"play.esea": "00000101000010",
	mugenmonkey: "00000101000011",
	w3schools: "00000101000100",
	radiolab: "00000101000101",
	harborfreight: "00000101000110",
	pitchfork: "00000101000111",
	"media-cache-ak0.pinimg": "00000101001000",
	"terraria.gamepedia": "00000101001001",
	"ftw.usatoday": "00000101001010",
	"forums.robertsspaceindustries": "00000101001011",
	"statcan.gc": "00000101001100",
	wabbitwiki: "00000101001101",
	"encrypted-tbn2.gstatic": "00000101001110",
	indianexpress: "00000101001111",
	examiner: "00000101010000",
	vatican: "00000101010001",
	techdirt: "00000101010010",
	wnd: "00000101010011",
	investigationbooks: "000001010101",
	marvel: "00000101011000",
	baltimoresun: "00000101011001",
	"huffingtonpost.co": "00000101011010",
	torontosun: "00000101011011",
	ea: "00000101011100",
	"theaustralian.com": "00000101011101",
	raspberrypi: "00000101011110",
	"travel.state": "00000101011111",
	lcfgeorgia: "00000101100000",
	kauffman: "00000101100001",
	"usff.navy": "00000101100010",
	"newsroom.latam.paypal-corp": "00000101100011",
	yearup: "00000101100100",
	cvent: "00000101100101",
	accenture: "00000101100110",
	switchboardta: "00000101100111",
	"doyok.kinja": "0000010110100",
	renews24: "0000010110101",
	yugipedia: "0000010110110",
	"r.go1dfish": "0000010110111",
	americanexpress: "00000101110000",
	"m.newegg": "00000101110001",
	feelthebern: "00000101110010",
	"alg.cubing": "00000101110011",
	corsair: "00000101110100",
	"content.time": "00000101110101",
	winlivestream: "00000101110110",
	"m.fanfiction": "00000101110111",
	p2016: "00000101111000",
	masterypoints: "00000101111001",
	liquipedia: "00000101111010",
	"help.steampowered": "00000101111011",
	"m.spankbang": "00000101111100",
	"p0ody-files": "00000101111101",
	"pm1.narvii": "00000101111110",
	watchnfllivetv: "00000101111111",
	"37.media.tumblr": "0000011000000",
	"services.runescape": "0000011000001",
	voat: "0000011000010",
	shopify: "0000011000011",
	"i.minus": "00000110001",
	mangaupdates: "0000011001",
	"drive.google": "000001101",
	businessinsider: "0000011100",
	freebase: "000001110100",
	"images-na.ssl-images-amazon": "000001110101",
	"docs.python": "0000011101100",
	worldofwarcraft: "00000111011010",
	disposerx: "00000111011011",
	"cdn.sesamestreetincommunities": "000001110111",
	"edition.cnn": "000001111000",
	"wiki.teamfortress": "000001111001",
	swappa: "000001111010",
	"basketball-reference": "000001111011",
	dailymotion: "00000111110",
	researchgate: "000001111110",
	washingtontimes: "000001111111",
	twitter: "00001",
	reddit: "00010",
	doi: "0001100000",
	"commons.wikimedia": "0001100001",
	sbnation: "0001100010000",
	nba: "0001100010001",
	"ec.europa": "0001100010010",
	yourlogicalfallacyis: "0001100010011",
	explosm: "0001100010100",
	dailykos: "0001100010101",
	theoatmeal: "0001100010110",
	epa: "0001100010111",
	disasterphilanthropy: "0001100011000",
	deltasigmatheta: "0001100011001",
	"goto.walmart": "000110001101",
	corgiorgy: "0001100011100",
	mythicspoiler: "0001100011101",
	"connect.ala": "0001100011110",
	"dynamics.microsoft": "0001100011111",
	"docs.google": "00011001",
	pixiv: "00011010",
	subtletv: "0001101100",
	"m.reddit": "000110110100",
	"img.pandawhale": "000110110101",
	mozilla: "000110110110",
	pewforum: "0001101101110",
	quran: "0001101101111",
	combodeck: "000110111",
	un: "000111000",
	"ca.pcpartpicker": "000111001",
	addtoany: "00011101",
	nerdwallet: "00011110000000",
	myfonts: "00011110000001",
	crutchfield: "00011110000010",
	cisco: "00011110000011",
	state: "00011110000100",
	windowsphone: "00011110000101",
	psnprofiles: "00011110000110",
	dwarffortresswiki: "00011110000111",
	femradebates: "00011110001000",
	shevibe: "00011110001001",
	foxsports: "00011110001010",
	hqhdtv: "00011110001011",
	talkingpointsmemo: "00011110001100",
	technologyreview: "00011110001101",
	kansascity: "00011110001110",
	"g1.globo": "00011110001111",
	"pediatrics.aappublications": "00011110010000",
	twitlonger: "00011110010001",
	pcworld: "00011110010010",
	"ru.wikipedia": "00011110010011",
	"help.ubuntu": "00011110010100",
	southparkstudios: "00011110010101",
	military: "00011110010110",
	taxfoundation: "00011110010111",
	ustream: "00011110011000",
	chron: "00011110011001",
	midwayusa: "00011110011010",
	android: "00011110011011",
	costco: "00011110011100",
	slashfilm: "00011110011101",
	hindustantimes: "00011110011110",
	mixcloud: "00011110011111",
	yahoo: "0001111010000",
	challonge: "0001111010001",
	"pics.me": "0001111010010",
	checkrepost: "0001111010011",
	"leagueoflegends.wikia": "0001111010100",
	crunchyroll: "0001111010101",
	"minecraft.gamepedia": "0001111010110",
	"m.soundcloud": "0001111010111",
	stevenaverycase: "00011110110000",
	getyarn: "00011110110001",
	ruadick: "00011110110010",
	"db.fowtcg": "00011110110011",
	fullhdtvstream: "00011110110100",
	"news.vice": "00011110110101",
	loadfst: "00011110110110",
	chewy: "00011110110111",
	plos: "0001111011100",
	"cse.google": "0001111011101",
	"4k-livefifa": "00011110111100",
	axios: "00011110111101",
	"sell.amazon": "00011110111110",
	grow: "00011110111111",
	muzemerch: "000111110",
	neopets: "000111111000",
	webmd: "000111111001",
	outline: "000111111010",
	"atomiks.github": "000111111011",
	"newsroom.paypal-corp": "00011111110",
	"bulbapedia.bulbagarden": "000111111110",
	scribd: "000111111111",
	youtube: "001",
	"hearthstone.gamepedia": "0100000000",
	"i.giphy": "010000000100",
	robertsspaceindustries: "010000000101",
	"online.wsj": "0100000001100",
	ssa: "01000000011010",
	childrenandfamiliesfirstnc: "01000000011011",
	lichess: "010000000111",
	perscholas: "010000001",
	archiveofourown: "01000001000",
	"music.apple": "01000001001",
	thefitness: "01000001010",
	"68.media.tumblr": "010000010110",
	"space.hatena.ne": "010000010111",
	"forums.spacebattles": "0100000110000",
	esrb: "0100000110001",
	"c1.staticflickr": "0100000110010",
	"static1.e621": "0100000110011",
	jstor: "0100000110100",
	spiegel: "0100000110101",
	marketwatch: "0100000110110",
	serebii: "0100000110111",
	"news.mongabay": "010000011100",
	"78.media.tumblr": "010000011101",
	"b5bznmg.tula": "0100000111100",
	"my.mixtape": "0100000111101",
	oceandecade: "0100000111110",
	morejpeg: "0100000111111",
	npr: "0100001000",
	"i.ytimg": "0100001001",
	ebay: "010000101",
	tomshardware: "010000110000",
	goodwillfinds: "010000110001",
	redditsearch: "01000011001",
	reverb: "010000110100",
	gov: "010000110101",
	pathofexile: "01000011011",
	"gist.github": "01000011100",
	newyorker: "010000111010",
	census: "0100001110110",
	alternet: "0100001110111",
	ibb: "01000011110",
	gelbooru: "01000011111",
	magiccards: "0100010",
	walmart: "0100011000",
	dell: "0100011001000",
	lolking: "0100011001001",
	suicidepreventionlifeline: "0100011001010",
	charitywatch: "0100011001011",
	"support.steampowered": "0100011001100",
	guru3d: "0100011001101",
	"skyrim.nexusmods": "0100011001110",
	vndb: "0100011001111",
	avclub: "01000110100000",
	"ocw.mit": "01000110100001",
	mlb: "01000110100010",
	"windows.microsoft": "01000110100011",
	fcc: "01000110100100",
	minecraftwiki: "01000110100101",
	"finalfantasy.wikia": "01000110100110",
	mtv: "01000110100111",
	"forums.na.leagueoflegends": "01000110101000",
	crowdrise: "01000110101001",
	"forums.xbox": "01000110101010",
	"cloud-4.steampowered": "01000110101011",
	"wiki.guildwars": "01000110101100",
	dafont: "01000110101101",
	mechanicalkeyboards: "01000110101110",
	fullfact: "01000110101111",
	"static.comicvine": "010001101100",
	rationalwiki: "010001101101",
	"marketplace.xbox": "01000110111000",
	"listen.grooveshark": "01000110111001",
	"assets.nydailynews": "01000110111010",
	nooooooooooooooo: "01000110111011",
	"stuff.co": "01000110111100",
	businessweek: "01000110111101",
	teamfortress: "01000110111110",
	skepticsannotatedbible: "01000110111111",
	therabody: "0100011100000",
	magaimg: "0100011100001",
	medseaalliance: "01000111000100",
	packard: "01000111000101",
	lnkd: "01000111000110",
	banquemondiale: "01000111000111",
	"magic.wizards": "0100011100100",
	memedad: "0100011100101",
	botsbyliam: "0100011100110",
	"chan.sankakucomplex": "0100011100111",
	"m.popkey": "01000111010000",
	novelupdates: "01000111010001",
	oculus: "01000111010010",
	"sos.ca": "01000111010011",
	fragrantica: "01000111010100",
	"health.harvard": "01000111010101",
	movie24k: "01000111010110",
	wanna: "01000111010111",
	"loderunner.github": "01000111011000",
	"amp.reddit": "01000111011001",
	kaporcenter: "01000111011010",
	calicocat: "01000111011011",
	"pcmrbot.eegras": "01000111011100",
	"i.makeagif": "01000111011101",
	"science.sciencemag": "01000111011110",
	thebalance: "01000111011111",
	"guardian.co": "010001111000",
	bitcointalk: "010001111001",
	furaffinity: "01000111101",
	livescience: "010001111100",
	ft: "0100011111010",
	myspace: "0100011111011",
	"new.reddit": "01000111111",
	"dailymail.co": "0100100000",
	modojo: "0100100001000",
	washington: "0100100001001",
	prnt: "0100100001010",
	"projects.fivethirtyeight": "0100100001011",
	spreadingsantorum: "0100100001100",
	allrecipes: "0100100001101",
	tehurn: "0100100001110",
	myfitnesspal: "0100100001111",
	uptogether: "010010001000",
	spankbang: "010010001001",
	"community.looker": "0100100010100",
	acceptbitcoin: "0100100010101",
	torrentfreak: "01001000101100",
	"impactchallenge.withgoogle": "01001000101101",
	"inspiredleaders.downtown": "0100100010111",
	investopedia: "010010001100",
	"i.imgflip": "010010001101",
	futhead: "01001000111",
	"m.youtube": "01001001",
	nationalgeographic: "010010100000",
	gifsound: "010010100001",
	prntscr: "01001010001",
	"corporate.walmart": "0100101001",
	nature: "01001010100",
	cato: "01001010101000",
	ajc: "01001010101001",
	food: "01001010101010",
	billboard: "01001010101011",
	snoopsnoo: "010010101011",
	reason: "0100101011000",
	"en.wikiquote": "0100101011001",
	lifehacker: "0100101011010",
	rawstory: "0100101011011",
	d20pfsrd: "01001010111",
	"pohudeniya-bistro": "0100101100000",
	"awoiaf.westeros": "0100101100001",
	"thumbs.gfycat": "0100101100010",
	shtrs: "0100101100011",
	dol: "0100101100100",
	jcrew: "0100101100101",
	nhl: "0100101100110",
	bricklink: "0100101100111",
	"oqmweghb.sochi": "01001011010000",
	dbz: "01001011010001",
	"fred.stlouisfed": "01001011010010",
	theothersreport: "01001011010011",
	citylab: "01001011010100",
	"fat.gfycat": "01001011010101",
	georgiymore: "01001011010110",
	"nurl.cafe24": "01001011010111",
	"r6fix.ubi": "0100101101100",
	"en.oxforddictionaries": "0100101101101",
	mirrorbot: "01001011011100",
	timee: "01001011011101",
	"workspace.google": "0100101101111",
	starcitygames: "01001011100000",
	memecrunch: "01001011100001",
	"news.nationalpost": "01001011100010",
	archives: "01001011100011",
	"news.google": "01001011100100",
	"head-fi": "01001011100101",
	nejm: "01001011100110",
	cpsc: "01001011100111",
	padherder: "01001011101000",
	academia: "01001011101001",
	"sensualhumiliation.tumblr": "01001011101010",
	letterboxd: "01001011101011",
	roblox: "01001011101100",
	grantland: "01001011101101",
	"standard.co": "01001011101110",
	"japantimes.co": "01001011101111",
	theanarchistlibrary: "010010111100",
	"secure.actblue": "010010111101",
	"yutubi.kinja": "010010111110",
	vocaroo: "010010111111",
	fivethirtyeight: "010011000000",
	tmz: "0100110000010",
	whitehouse: "0100110000011",
	eventbrite: "010011000010",
	chicagotribune: "010011000011",
	yourbrainonporn: "0100110001000",
	gifrific: "0100110001001",
	hearthstonetopdecks: "0100110001010",
	"mega.co": "0100110001011",
	haaretz: "0100110001100",
	foreignpolicy: "0100110001101",
	paizo: "0100110001110",
	"lh3.googleusercontent": "0100110001111",
	mtg: "010011001",
	goo: "010011010",
	xkcdref: "010011011000",
	"hydra-media.cursecdn": "010011011001",
	"xn--80aaqbi4ajie6m": "0100110110100",
	"kak-pohudet-za": "0100110110101",
	"farm4.static.flickr": "01001101101100",
	"shop-links": "01001101101101",
	"search.app.goo": "0100110110111",
	"media.tumblr": "01001101110",
	"snew.github": "01001101111",
	metacritic: "01001110000",
	gallup: "010011100010",
	breitbart: "010011100011",
	fanfiction: "0100111001",
	"security.googleblog": "0100111010",
	"scholar.google": "0100111011",
	"dota2.gamepedia": "01001111000",
	mangapanda: "01001111001000",
	tumblr: "01001111001001",
	newrepublic: "01001111001010",
	"what-if.xkcd": "01001111001011",
	gifsoup: "01001111001100",
	"cdn.bulbagarden": "01001111001101",
	independent: "01001111001110",
	voanews: "01001111001111",
	fao: "0100111101",
	"img1.wikia.nocookie": "0100111110000",
	"m.huffpost": "0100111110001",
	undercurrentnews: "0100111110010",
	dlinkes: "0100111110011",
	"sports.yahoo": "0100111110100",
	vanityfair: "0100111110101",
	"warframe.wikia": "0100111110110",
	bbb: "0100111110111",
	vgy: "01001111110000",
	fitbit: "01001111110001",
	smitegame: "01001111110010",
	syriancivilwararchive: "01001111110011",
	xnxx: "01001111110100",
	budgetbytes: "01001111110101",
	gbatemp: "01001111110110",
	taggedtanakh: "01001111110111",
	onlyfans: "01001111111000",
	ceoworks: "01001111111001",
	weddit: "01001111111010",
	milkbet: "01001111111011",
	mcmcse: "01001111111100",
	"45.media.tumblr": "01001111111101",
	"m.intl.taobao": "01001111111110",
	"gpu.userbenchmark": "01001111111111",
	"en.wikipedia": "0101",
	"de.pcpartpicker": "01100000000",
	"t-nation": "01100000001000",
	denverpost: "01100000001001",
	"ebay.com": "01100000001010",
	khanacademy: "01100000001011",
	"img.animebracket": "011000000011",
	louroe: "01100000010",
	economist: "011000000110",
	arxiv: "011000000111",
	changetip: "011000001000",
	stripe: "011000001001",
	"item.taobao": "01100000101",
	"dictionary.reference": "011000001100",
	behance: "0110000011010",
	microcenter: "0110000011011",
	blackrock: "0110000011100",
	livehdtv: "0110000011101",
	sesamestreet: "01100000111100",
	"mailback-msft.tes-amm": "01100000111101",
	earthday: "0110000011111",
	"web.archive": "01100001",
	"link.springer": "0110001000000",
	smithsonianmag: "0110001000001",
	"i0.wp": "0110001000010",
	fasttech: "0110001000011",
	upwardlyglobal: "01100010001",
	redditblog: "0110001001",
	"resi.ze-robot": "01100010100",
	politifact: "01100010101",
	pcgamer: "0110001011000",
	plannedparenthood: "01100010110010",
	esquire: "01100010110011",
	nationalreview: "0110001011010",
	eurogamer: "0110001011011",
	spire: "01100010111",
	worldbank: "01100011000",
	fastcompany: "01100011001000",
	"i.telegraph.co": "01100011001001",
	abload: "01100011001010",
	"science.howstuffworks": "01100011001011",
	ehow: "01100011001100",
	thinkgeek: "01100011001101",
	escapistmagazine: "01100011001110",
	"images2.wikia.nocookie": "01100011001111",
	"lists.linuxfoundation": "0110001101000",
	sprint: "0110001101001",
	"togiliatiliati.togliatti": "0110001101010",
	eroshare: "0110001101011",
	tripadvisor: "0110001101100",
	"cdn.memegenerator": "0110001101101",
	"applynow.chase": "0110001101110",
	indianapolis500live: "0110001101111",
	"taobaotools.github": "01100011100000",
	"reddit.app": "01100011100001",
	"blog.kaporcenter": "01100011100010",
	"developers.googleblog": "01100011100011",
	etonline: "01100011100100",
	"img2-ak.lst": "01100011100101",
	"lifeline.org": "01100011100110",
	"steamcdn-a.akamaihd": "01100011100111",
	mangadex: "0110001110100",
	reddittext: "0110001110101",
	overdeck: "01100011101100",
	"about.flipboard": "01100011101101",
	"news.microsoft": "0110001110111",
	"people-press": "01100011110000",
	fool: "01100011110001",
	mlive: "01100011110010",
	"nl.wikipedia": "01100011110011",
	"pt.wikipedia": "01100011110100",
	"nutritiondata.self": "01100011110101",
	"farm8.staticflickr": "01100011110110",
	curse: "01100011110111",
	"officialtvstream.com": "01100011111000",
	"motherboard.vice": "01100011111001",
	"zippy.gfycat": "01100011111010",
	"1drv": "01100011111011",
	dallasnews: "01100011111100",
	"hsph.harvard": "01100011111101",
	cell: "01100011111110",
	"answers.microsoft": "01100011111111",
	"s-media-cache-ak0.pinimg": "0110010000",
	aliexpress: "011001000100",
	gamespot: "0110010001010",
	"msnbc.msn": "01100100010110",
	"ja-jp.facebook": "01100100010111",
	"developers.google": "01100100011",
	tappedout: "01100100100",
	"3.bp.blogspot": "01100100101",
	tinyurl: "011001001100",
	"news.com": "0110010011010",
	"ecx.images-amazon": "0110010011011",
	"25.media.tumblr": "01100100111",
	bmw: "0110010100000",
	"aqnugtr.nov": "0110010100001",
	coursera: "011001010001",
	"powerlisting.wikia": "0110010100100",
	"mlb.mlb": "0110010100101",
	bato: "0110010100110",
	brookings: "0110010100111",
	"us.battle": "0110010101",
	opensecrets: "0110010110000",
	gizmodo: "0110010110001",
	instapaper: "0110010110010",
	"metro.co": "0110010110011",
	liveleak: "011001011010",
	dictionary: "011001011011",
	"smile.amazon": "01100101110",
	foxnews: "01100101111",
	"addons.mozilla": "0110011000",
	"merriam-webster": "01100110010",
	scientificamerican: "011001100110",
	"wh40k.lexicanum": "0110011001110",
	kotaku: "0110011001111",
	anilist: "011001101",
	"media.giphy": "011001110",
	"scholar.google.co": "01100111100",
	espncricinfo: "01100111101000",
	"en.reddit": "01100111101001",
	planetminecraft: "01100111101010",
	theblaze: "01100111101011",
	boston: "01100111101100",
	"aws.amazon": "01100111101101",
	"climate.nasa": "01100111101110",
	ipcc: "01100111101111",
	"hi-in.facebook": "01100111110000",
	"de-de.facebook": "01100111110001",
	c4ads: "0110011111001",
	"ar-ar.facebook": "01100111110100",
	"zh-cn.facebook": "01100111110101",
	"ko-kr.facebook": "01100111110110",
	"pt-br.facebook": "01100111110111",
	"pay.reddit": "0110011111100",
	uesp: "0110011111101",
	boostwit: "0110011111110",
	mapbox: "0110011111111",
	vklvl: "01101000000000",
	"memory-alpha.wikia": "01101000000001",
	hutdb: "01101000000010",
	"ucr.fbi": "01101000000011",
	archivesofnethys: "01101000000100",
	pandacoinpnd: "01101000000101",
	bethesda: "01101000000110",
	"api.imgur": "01101000000111",
	huridocs: "01101000001000",
	greenbiz: "01101000001001",
	coastguardnews: "01101000001010",
	walmartsustainabilityhub: "01101000001011",
	nicsgalleries: "01101000001100",
	"exvius.gamepedia": "01101000001101",
	bootyr4r: "01101000001110",
	democracy: "01101000001111",
	"metal-archives": "01101000010000",
	"marvel.wikia": "01101000010001",
	theweek: "01101000010010",
	walgreens: "01101000010011",
	"blogs.scientificamerican": "01101000010100",
	makeagif: "01101000010101",
	samsung: "01101000010110",
	setlist: "01101000010111",
	"a.pomf": "01101000011000",
	"us.reddit": "01101000011001",
	"forums.smitegame": "01101000011010",
	"minecraft.curseforge": "01101000011011",
	miamiherald: "01101000011100",
	ssbwiki: "01101000011101",
	"socialclub.rockstargames": "01101000011110",
	"es.pcpartpicker": "01101000011111",
	"66.media.tumblr": "011010001000",
	"art.hearthstonejson": "011010001001",
	"pathofexile.gamepedia": "011010001010",
	"i1.kym-cdn": "011010001011",
	"support.apple": "0110100011",
	forbes: "0110100100",
	"news.bbc.co": "011010010100",
	xboxdvr: "0110100101010",
	cbssports: "0110100101011",
	whatimade: "0110100101100",
	nicodb: "0110100101101",
	seattlefoundation: "0110100101110",
	bcg: "0110100101111",
	microsoft: "011010011",
	steamcommunity: "0110101",
	"uk.pcpartpicker": "011011000",
	"onlinelibrary.wiley": "011011001000",
	rei: "0110110010010",
	blogcdn: "01101100100110",
	"blogs.wsj": "01101100100111",
	wowhead: "01101100101",
	"books.google": "01101100110",
	kiwiirc: "011011001110",
	wikileaks: "011011001111",
	"24.media.tumblr": "01101101000",
	"xn--e1agvr0b.xn--j1aef": "01101101001",
	last: "0110110101",
	cc: "01101101100000",
	csgolounge: "01101101100001",
	"forums.ubi": "01101101100010",
	g2a: "01101101100011",
	"encrypted-tbn3.gstatic": "01101101100100",
	"games-workshop": "01101101100101",
	"legislation.gov": "01101101100110",
	digitaltrends: "01101101100111",
	doctorofcredit: "01101101101000",
	"es-la.facebook": "01101101101001",
	rocketr: "01101101101010",
	mediabiasfactcheck: "01101101101011",
	"en-americas-support.nintendo": "01101101101100",
	"wow.gamepedia": "01101101101101",
	oddshot: "01101101101110",
	drivethrurpg: "01101101101111",
	trello: "0110110111",
	statista: "0110111000000",
	"na.leagueoflegends": "0110111000001",
	congress: "0110111000010",
	"petitions.whitehouse": "0110111000011",
	fbi: "0110111000100",
	hulu: "0110111000101",
	"i.ebayimg": "0110111000110",
	techcrunch: "0110111000111",
	"kroger-stage.preprodhawkcommerce": "0110111001000",
	greenislandmj: "0110111001001",
	rawg: "01101110010100",
	"teamrv-mvp.sos.texas": "01101110010101",
	tent: "01101110010110",
	lew: "01101110010111",
	fuwa: "0110111001100",
	genius: "0110111001101",
	aka: "0110111001110",
	"sukipuki.msk": "0110111001111",
	cbsnews: "01101110100",
	"it-it.facebook": "01101110101000",
	thisamericanlife: "01101110101001",
	inquisitr: "01101110101010",
	jsfiddle: "01101110101011",
	erowid: "0110111010110",
	gutenberg: "01101110101110",
	"fr-fr.facebook": "01101110101111",
	etsy: "0110111011",
	heatware: "01101111000",
	"vignette3.wikia.nocookie": "011011110010",
	"33.media.tumblr": "011011110011",
	reactiongifs: "01101111010",
	"google.co": "01101111011",
	twitch: "011011111",
	"gatherer.wizards": "011100",
	hummingbird: "011101000000",
	isthereanydeal: "0111010000010",
	"img2.wikia.nocookie": "0111010000011",
	"accounts.google": "01110100001",
	abimon: "01110100010",
	thehill: "01110100011",
	"penzaza.penza": "0111010010000",
	watchonlinelivetv: "0111010010001",
	npafc: "0111010010010",
	"static-3.studiobebop": "0111010010011",
	"corporate.target": "01110100101",
	"supermariomakerbookmark.nintendo": "011101001100",
	"vignette1.wikia.nocookie": "011101001101",
	universalscammerlist: "011101001110",
	"www1.folha.uol.com": "011101001111",
	"open.spotify": "01110101",
	linkedin: "0111011",
	"store.steampowered": "011110000",
	"wiki.archlinux": "0111100010000",
	uscg: "01111000100010",
	jpost: "01111000100011",
	anandtech: "011110001001",
	bestbuy: "011110001010",
	engadget: "0111100010110",
	mises: "0111100010111",
	knowyourmeme: "01111000110",
	time: "01111000111",
	washingtonpost: "011110010",
	"ml.reddit": "01111001100000",
	globalb2bcontacts: "01111001100001",
	chromeenterprise: "01111001100010",
	suicideprevention: "01111001100011",
	"firebase.google": "01111001100100",
	awin1: "01111001100101",
	"data.tumblr": "01111001100110",
	epicgames: "01111001100111",
	harmonybuet: "0111100110100",
	songrium: "0111100110101",
	"fitness.apple": "01111001101100",
	"tm-tracking": "01111001101101",
	"docs.github": "0111100110111",
	nolo: "01111001110000",
	"media.wizards": "01111001110001",
	fertilityfriend: "01111001110010",
	"nz.pcpartpicker": "01111001110011",
	geekhack: "01111001110100",
	"images3.wikia.nocookie": "01111001110101",
	eonline: "01111001110110",
	jordanthebrobot: "01111001110111",
	winsipedia: "01111001111000",
	appsto: "01111001111001",
	"karelialia.karelia": "01111001111010",
	berniesanders: "01111001111011",
	muthead: "01111001111100",
	libgen: "01111001111101",
	chain: "01111001111110",
	"stats.nba": "01111001111111",
	"na.op": "011110100000",
	buzzfeed: "011110100001",
	"market.android": "01111010001000",
	airbnb: "01111010001001",
	fav: "01111010001010",
	oxforddictionaries: "01111010001011",
	gamasutra: "01111010001100",
	popularmechanics: "01111010001101",
	livestrong: "01111010001110",
	cnsnews: "01111010001111",
	stitcher: "0111101001000",
	aljazeera: "0111101001001",
	"4kmoviehub": "0111101001010",
	"36.media.tumblr": "0111101001011",
	"starwars.wikia": "011110100110",
	"goto.target": "011110100111",
	blog: "011110101000",
	bungie: "011110101001",
	"eu.battle": "011110101010",
	"msdn.microsoft": "0111101010110",
	justice: "0111101010111",
	gyazo: "0111101011",
	huffingtonpost: "0111101100",
	itcosmetics: "011110110100",
	"i3.kym-cdn": "011110110101",
	"mirror.co": "0111101101100",
	techpowerup: "0111101101101",
	"activity.mobilelegends": "0111101101110",
	"b.1339": "0111101101111",
	amzn: "011110111000",
	"marine-conservation": "011110111001",
	"vignette.wikia.nocookie": "01111011101",
	"s.metjm": "011110111100",
	"support.microsoft": "011110111101",
	nicovideo: "01111011111",
	instagram: "0111110",
	"i0.kym-cdn": "01111110000",
	"g.redditmedia": "011111100010",
	"hq.porygon": "011111100011",
	"cloud.google": "0111111001",
	ujyaaloonline: "01111110100000",
	href: "01111110100001",
	"ulta.ztk5": "01111110100010",
	waltonfamilyfoundation: "01111110100011",
	"journals.sagepub": "01111110100100",
	dailywire: "01111110100101",
	otranscribe: "01111110100110",
	macys: "01111110100111",
	"images4-b.ravelrycache": "0111111010100",
	"timesofindia.indiatimes": "0111111010101",
	"optc-db.github": "0111111010110",
	tradingview: "0111111010111",
	heritage: "01111110110000",
	"profootballtalk.nbcsports": "01111110110001",
	techspot: "01111110110010",
	kohls: "01111110110011",
	bash: "01111110110100",
	wikipedia: "01111110110101",
	"hyperboleandahalf.blogspot": "01111110110110",
	surveymonkey: "01111110110111",
	bjs: "01111110111000",
	"static.giantbomb": "01111110111001",
	"cpu.userbenchmark": "01111110111010",
	northantrim: "01111110111011",
	"i.huffpost": "01111110111100",
	zeit: "01111110111101",
	massdrop: "01111110111110",
	society6: "01111110111111",
	soundcloud: "01111111",
	"plus.google": "10000000000",
	rottentomatoes: "10000000001",
	ew: "100000000100",
	theonion: "100000000101",
	lds: "1000000001100",
	"groups.google": "10000000011010",
	oemdtc: "10000000011011",
	howl: "100000000111",
	steamrep: "1000000010000",
	sec: "1000000010001",
	unesco: "1000000010010",
	sanger: "1000000010011",
	shouters: "10000000101",
	"fiddle.jshell": "100000001100",
	nydailynews: "100000001101",
	donaldjtrump: "1000000011100",
	nicozon: "1000000011101",
	nordstrom: "1000000011110",
	tidal: "1000000011111",
	xvideos: "10000001000",
	ala: "100000010010",
	nypost: "100000010011",
	"dl.dropbox": "1000000101000",
	politicalcompass: "10000001010010",
	boingboing: "10000001010011",
	narffl: "100000010101",
	"azure.microsoft": "10000001011",
	timeanddate: "1000000110",
	nationalpost: "10000001110000",
	cancer: "10000001110001",
	att: "10000001110010",
	indiegala: "10000001110011",
	"secure.wikimedia": "10000001110100",
	gnu: "10000001110101",
	house: "10000001110110",
	mediamatters: "10000001110111",
	"reddit.applebyte": "10000001111000",
	"cards.eternalwarcry": "10000001111001",
	"l.facebook": "10000001111010",
	mailmygov: "10000001111011",
	huffpost: "10000001111100",
	onlinemarketplace24: "10000001111101",
	livepc2tv: "10000001111110",
	documentcloud: "10000001111111",
	theguardian: "100000100",
	explainxkcd: "100000101000",
	nfl: "100000101001",
	scrolller: "100000101010",
	"vignette2.wikia.nocookie": "100000101011",
	qkme: "1000001011000",
	bhphotovideo: "1000001011001",
	kaporcapital: "10000010110100",
	"my.hupu": "10000010110101",
	overclock: "1000001011011",
	saucenao: "10000010111",
	vimeo: "1000001100",
	nbcnews: "10000011010",
	washingtonexaminer: "1000001101100",
	"murmurmansk.murmansk": "1000001101101",
	"i.dailymail.co": "100000110111",
	pastebin: "100000111",
	amazon: "100001",
	redd: "1000100",
	cnn: "1000101000",
	"movies.netflix": "100010100100",
	duckduckgo: "1000101001010",
	minus: "1000101001011",
	"images.brickset": "10001010011",
	"4.bp.blogspot": "10001010100",
	"pohudet-na-kg": "100010101010",
	"money.cnn": "100010101011",
	watch24: "1000101011000",
	"forum.kerbalspaceprogram": "1000101011001",
	swarfarm: "1000101011010",
	gph: "1000101011011",
	"clips.twitch": "10001010111",
	giphy: "10001011000",
	pnas: "1000101100100",
	cia: "10001011001010",
	okcupid: "10001011001011",
	ceddit: "100010110011",
	"sslim.kinja": "10001011010000",
	"docs.unity3d": "10001011010001",
	"ps.w": "10001011010010",
	livslinien: "10001011010011",
	"dictionary.cambridge": "10001011010100",
	vocadb: "10001011010101",
	livestreamhdtv: "10001011010110",
	slatestarcodex: "10001011010111",
	erome: "1000101101100",
	"adsabs.harvard": "1000101101101",
	"uk.linkedin": "1000101101110",
	airtable: "1000101101111",
	newgrounds: "10001011100000",
	"i1.ytimg": "10001011100001",
	mercurynews: "10001011100010",
	bible: "10001011100011",
	redditloans: "100010111001",
	xbox: "10001011101000",
	pokecheck: "10001011101001",
	scmp: "10001011101010",
	sweetwater: "10001011101011",
	popsci: "10001011101100",
	bodybuilding: "10001011101101",
	"forum.paradoxplaza": "10001011101110",
	slickdeals: "10001011101111",
	kitsu: "1000101111",
	"apps.apple": "100011",
	imgur: "1001",
	github: "10100",
	notebookcheck: "1010100000000",
	katespade: "1010100000001",
	"xn--80adiba3abddchue7e4b": "101010000001",
	"go.microsoft": "101010000010",
	discogs: "101010000011",
	"webcache.googleusercontent": "1010100001000",
	"articles.latimes": "1010100001001",
	ipsnews: "1010100001010",
	ikea: "1010100001011",
	adf: "10101000011",
	nicofinder: "1010100010000",
	"media2.giphy": "1010100010001",
	decronym: "1010100010010",
	"i.redditmedia": "1010100010011",
	"cdn.shopify": "1010100010100",
	postimg: "1010100010101",
	omfgdogs: "1010100010110",
	polygon: "1010100010111",
	"law.cornell": "101010001100",
	ted: "101010001101",
	usatoday: "10101000111",
	cbc: "10101001000",
	"abcnews.go": "10101001001",
	redbubble: "1010100101000",
	"baseball-reference": "1010100101001",
	nhentai: "1010100101010",
	globalnews: "1010100101011",
	"goodbot-badbot.herokuapp": "10101001011",
	tesla: "101010011000000",
	"pics.onsizzle": "101010011000001",
	gwentdb: "101010011000010",
	"developer.microsoft": "101010011000011",
	wtop: "101010011000100",
	dreadnoughtforums: "101010011000101",
	"media.gettyimages": "101010011000110",
	"qwakamakaflo.in": "101010011000111",
	richardphotolab: "101010011001000",
	"dyn.keepa": "101010011001001",
	nereusprogram: "101010011001010",
	dotdashmeredith: "101010011001011",
	"cdn.vox-cdn": "101010011001100",
	"fi.google": "101010011001101",
	"i.postimg": "101010011001110",
	unitedstreams4all: "101010011001111",
	newsmax: "101010011010000",
	watchnflgame: "101010011010001",
	"en.m.wiktionary": "101010011010010",
	"support.plex": "101010011010011",
	feedingamerica: "101010011010100",
	fitbamob: "101010011010101",
	"trends-and-virals": "101010011010110",
	"business.financialpost": "101010011010111",
	msi: "101010011011000",
	sageadvice: "101010011011001",
	geoguessr: "101010011011010",
	"e-liquid-recipes": "101010011011011",
	"cloud-4.steamusercontent": "101010011011100",
	"uproxx.files.wordpress": "101010011011101",
	waitbutwhy: "101010011011110",
	arcgames: "101010011011111",
	eternalwarcry: "10101001110000",
	"forums.playbattlegrounds": "10101001110001",
	"b1.hoopchina.com": "10101001110010",
	"music.youtube": "10101001110011",
	"49.media.tumblr": "10101001110100",
	"lanacion.com": "10101001110101",
	"files.catbox": "10101001110110",
	"ehjmilredditop.in": "10101001110111",
	"events.withgoogle": "101010011110000",
	oceanographicmagazine: "101010011110001",
	adcouncil: "10101001111001",
	fortunesociety: "101010011110100",
	jbl: "101010011110101",
	latinospro: "101010011110110",
	thelastmile: "101010011110111",
	resourcewatch: "10101001111100",
	therosienetwork: "10101001111101",
	"cs.mak.ac": "10101001111110",
	"blog.code": "10101001111111",
	ftc: "101010100000000",
	"picasaweb.google": "101010100000001",
	makeuseof: "101010100000010",
	techradar: "101010100000011",
	indeed: "101010100000100",
	epicurious: "101010100000101",
	malwarebytes: "101010100000110",
	philpapers: "101010100000111",
	"sanders.senate": "101010100001000",
	businesswire: "101010100001001",
	mariowiki: "101010100001010",
	"simple.wikipedia": "101010100001011",
	camelcamelcamel: "101010100001100",
	"nlm.nih": "101010100001101",
	gigabyte: "101010100001110",
	"articles.chicagotribune": "101010100001111",
	"pislinkuredditza.in": "1010101000100",
	sli: "1010101000101",
	collegehumor: "101010100011000",
	scienceblogs: "101010100011001",
	"dx.doi": "101010100011010",
	damninteresting: "101010100011011",
	presstv: "101010100011100",
	lewrockwell: "101010100011101",
	slideshare: "101010100011110",
	cirp: "101010100011111",
	sketchtoy: "101010100100000",
	backcountry: "101010100100001",
	"99percentinvisible": "101010100100010",
	health: "101010100100011",
	giantitp: "101010100100100",
	chess: "101010100100101",
	hhs: "101010100100110",
	endclothing: "101010100100111",
	kijiji: "101010100101000",
	profootballfocus: "101010100101001",
	"images6.fanpop": "101010100101010",
	theroot: "101010100101011",
	lemonde: "101010100101100",
	moridb: "101010100101101",
	canadiancouchpotato: "101010100101110",
	androidauthority: "101010100101111",
	privateinternetaccess: "101010100110000",
	gao: "101010100110001",
	easports: "101010100110010",
	codecademy: "101010100110011",
	"static.tumblr": "101010100110100",
	"onepiece.wikia": "101010100110101",
	"fc03.deviantart": "101010100110110",
	dnaindia: "101010100110111",
	votetexas: "101010100111000",
	freakonomics: "101010100111001",
	asos: "101010100111010",
	jacobinmag: "101010100111011",
	pjmedia: "101010100111100",
	loc: "101010100111101",
	"iopscience.iop": "101010100111110",
	"borderlands.wikia": "101010100111111",
	thefreedictionary: "10101010100000",
	"img.photobucket": "10101010100001",
	redtube: "10101010100010",
	grooveshark: "10101010100011",
	thingiverse: "101010101001",
	familysearch: "10101010101000",
	"media-cache-ec0.pinimg": "10101010101001",
	samaritans: "10101010101010",
	matthieugrieger: "10101010101011",
	"docs.oracle": "10101010101100",
	beeradvocate: "10101010101101",
	eia: "10101010101110",
	neogaf: "10101010101111",
	puu: "1010101011",
	minderoo: "101010110000",
	"xn--b1actsqfc5b.xn--j1aef": "101010110001",
	"i.gyazo": "10101011001",
	"store.playstation": "101010110100",
	fantasypros: "1010101101010",
	nymag: "1010101101011",
	"video.google": "10101011011000",
	stimson: "10101011011001",
	"images4-e.ravelrycache": "1010101101101",
	"google.com": "101010110111",
	"scp-wiki": "1010101110",
	redditenhancementsuite: "1010101111",
	"tvvidzon.blogspot": "1010110000000",
	netrunnerdb: "1010110000001",
	bigkosmos: "1010110000010",
	"video.nfl": "1010110000011",
	seedsindia: "10101100001",
	greasyfork: "10101100010",
	speedtest: "1010110001100",
	redditgifts: "10101100011010",
	rateyourmusic: "10101100011011",
	homedepot: "101011000111",
	newegg: "1010110010",
	theatlantic: "10101100110",
	"wiki.guildwars2": "101011001110",
	creativecommons: "1010110011110",
	bing: "1010110011111",
	howtogeek: "1010110100000",
	"ebay.co": "1010110100001",
	moviehunterz: "1010110100010",
	"giant.gfycat": "1010110100011",
	"click.linksynergy": "10101101001",
	gameinformer: "10101101010000",
	"elderscrolls.wikia": "10101101010001",
	motorola: "10101101010010",
	random: "10101101010011",
	usa: "10101101010100",
	oregonlive: "10101101010101",
	readability: "10101101010110",
	irishtimes: "10101101010111",
	"jobs.target": "10101101011000",
	capitalone: "10101101011001",
	learnbitcoin: "10101101011010",
	veryfetch: "10101101011011",
	porygon: "10101101011100",
	ctvnews: "10101101011101",
	shters: "10101101011110",
	scriptogr: "10101101011111",
	"support.google": "1010110110",
	thedailybeast: "101011011100",
	netflix: "1010110111010",
	livestreamfails: "1010110111011",
	countle: "10101101111",
	gfycat: "10101110",
	medium: "101011110",
	megalodon: "101011111",
	usblackchambers: "101100000000",
	zerohedge: "1011000000010",
	motherjones: "1011000000011",
	tiktok: "10110000001",
	apple: "10110000010",
	opendota: "101100000110",
	theverge: "101100000111",
	"upload.wikimedia": "101100001",
	notehub: "1011000100000",
	"media0.giphy": "1011000100001",
	"i.magaimg": "1011000100010",
	"r34.tsumino": "1011000100011",
	"imgs.xkcd": "101100010010",
	e621: "101100010011",
	nexusmods: "1011000101",
	dotabuff: "1011000110",
	psychologytoday: "101100011100",
	"espn.go": "101100011101",
	t: "10110001111",
	"m.imgur": "101100100",
	snopes: "10110010100",
	ff2ebook: "10110010101",
	hearthpwn: "10110010110",
	brickset: "10110010111",
	"2.bp.blogspot": "10110011000",
	patheos: "10110011001000",
	venturebeat: "10110011001001",
	"data.whicdn": "10110011001010",
	tinypic: "10110011001011",
	zdnet: "10110011001100",
	"penny-arcade": "10110011001101",
	thenation: "10110011001110",
	tampabay: "10110011001111",
	bugguide: "10110011010",
	ravelry: "10110011011",
	thediplomat: "101100111000000",
	maggardrazors: "101100111000001",
	"keto-calculator.ankerl": "101100111000010",
	vg247: "101100111000011",
	datpiff: "101100111000100",
	"farm9.staticflickr": "101100111000101",
	thenextweb: "101100111000110",
	logicalincrements: "101100111000111",
	"support.rockstargames": "101100111001000",
	"thetimes.co": "101100111001001",
	"doc.rust-lang": "101100111001010",
	"t-mobile": "101100111001011",
	"youllot.nation2": "101100111001100",
	teespring: "101100111001101",
	"i.4cdn": "101100111001110",
	"support.activision": "101100111001111",
	musiciansfriend: "101100111010000",
	"gta.wikia": "101100111010001",
	eeoc: "101100111010010",
	"euw.leagueoflegends": "101100111010011",
	"lh5.googleusercontent": "101100111010100",
	artofmanliness: "101100111010101",
	washingtonsblog: "101100111010110",
	portforward: "101100111010111",
	digikey: "101100111011000",
	scarleteen: "101100111011001",
	"productforums.google": "101100111011010",
	cbs: "101100111011011",
	allenedmonds: "101100111011100",
	pewglobal: "101100111011101",
	charitynavigator: "101100111011110",
	themarysue: "101100111011111",
	vertigobutik: "101100111100000",
	cubers: "101100111100001",
	"event.mobilelegends": "101100111100010",
	"i.ibb": "101100111100011",
	"e-hentai": "101100111100100",
	"gttp.votinginfoproject": "101100111100101",
	buzzfeednews: "101100111100110",
	imgtc: "101100111100111",
	"community.c2cglobal": "101100111101000",
	allaboutcookies: "101100111101001",
	"getsupport.apple": "101100111101010",
	naacpimageawards: "101100111101011",
	pahilopost: "101100111101100",
	"gamepedia.cursecdn": "101100111101101",
	"applieddigitalskills.withgoogle": "101100111101110",
	jerkofftocelebs: "101100111101111",
	vslive: "101100111110000",
	accessories4less: "101100111110001",
	"wowwiki.wikia": "101100111110010",
	apkmirror: "101100111110011",
	"account.oneplus": "101100111110100",
	abc7news: "101100111110101",
	webtoons: "101100111110110",
	ohchr: "101100111110111",
	patch: "101100111111000",
	priberam: "101100111111001",
	sandiegouniontribune: "101100111111010",
	"heqreditmonis.in": "101100111111011",
	nowwatchtvlive: "101100111111100",
	"modlog.github": "101100111111101",
	sciencealert: "101100111111110",
	"go.berniesanders": "101100111111111",
	phish: "1011010000000",
	"m.xkcd": "1011010000001",
	"bzgnnbab.bzgnnbab": "1011010000010",
	"euw.op": "1011010000011",
	"pro-football-reference": "1011010000100",
	xhamster: "1011010000101",
	glassdoor: "1011010000110",
	dailycaller: "1011010000111",
	sciencebasedmedicine: "101101000100000",
	bankrate: "101101000100001",
	"browse.deviantart": "101101000100010",
	launchpad: "101101000100011",
	"dmv.ca": "101101000100100",
	norml: "101101000100101",
	gothamist: "101101000100110",
	"sales.starcitygames": "101101000100111",
	cbpp: "101101000101000",
	autoblog: "101101000101001",
	"fc08.deviantart": "101101000101010",
	oglaf: "101101000101011",
	"tardis.wikia": "101101000101100",
	payscale: "101101000101101",
	"inception.davepedu": "101101000101110",
	"27.media.tumblr": "101101000101111",
	thinkwithgoogle: "1011010001100",
	"photos.app.goo": "1011010001101",
	"26.media.tumblr": "101101000111000",
	"tools.ietf": "101101000111001",
	thestranger: "101101000111010",
	"store.apple": "101101000111011",
	sourcewatch: "101101000111100",
	"farm3.static.flickr": "101101000111101",
	stltoday: "101101000111110",
	"forum.bodybuilding": "101101000111111",
	camwhores: "10110100100000",
	matchstats: "10110100100001",
	jv: "10110100100010",
	swgoh: "10110100100011",
	ifixit: "10110100100100",
	"c-span": "10110100100101",
	hdmoviejunction: "10110100100110",
	steamdb: "10110100100111",
	"register.uso": "101101001010000",
	"developers.home.google": "101101001010001",
	"customers.microsoft": "10110100101001",
	storytoys: "101101001010100",
	fastdemocracy: "101101001010101",
	"documentation.spire": "101101001010110",
	iotc: "101101001010111",
	"mba.ac": "10110100101100",
	"services.google": "10110100101101",
	earthshotprize: "10110100101110",
	bavc: "10110100101111",
	"1.bp.blogspot": "10110100110",
	kickstarter: "101101001110",
	newsweek: "101101001111",
	globalfishingwatch: "1011010100",
	"uso.zoom": "101101010100",
	"shop.aclu": "101101010101",
	"code.google": "101101010110",
	"media.tenor": "1011010101110",
	deckbox: "1011010101111",
	cdc: "10110101100",
	ywca: "10110101101",
	"translate.google": "1011010111",
	bls: "1011011000000",
	uniqlo: "10110110000010",
	gamefaqs: "10110110000011",
	vera: "101101100001",
	politico: "10110110001",
	pbs: "101101100100",
	"maps.google": "101101100101",
	justinpaulin: "101101100110",
	gitlab: "101101100111",
	removeddit: "10110110100",
	zappos: "10110110101000",
	accesstoinsight: "10110110101001",
	skepticalscience: "10110110101010",
	donorschoose: "10110110101011",
	ssshorts: "101101101011",
	strava: "10110110110000",
	"cdn.meme": "10110110110001",
	wikiwand: "10110110110010",
	"c2.staticflickr": "10110110110011",
	"assets.sbnation": "10110110110100",
	"papers.ssrn": "10110110110101",
	indiegogo: "10110110110110",
	extremetech: "10110110110111",
	prf: "10110110111000",
	"news.gallup": "10110110111001",
	channel4: "101101101110100",
	"cdn.donorschoose": "101101101110101",
	refugees: "10110110111011",
	smash: "10110110111100",
	getpocket: "10110110111101",
	"img.buzzfeed": "10110110111110",
	"xn--e1akfklne0d.xn--j1aef": "10110110111111",
	imdb: "10110111",
	youtu: "10111",
	"blog.mozilla": "1100000000000",
	"smbc-comics": "1100000000001",
	vulpix: "1100000000010",
	"dl.dropboxusercontent": "1100000000011",
	sephora: "110000000010",
	"31.media.tumblr": "110000000011",
	"itunes.apple": "1100000001",
	para: "1100000010",
	hsreplay: "11000000110",
	wikihow: "110000001110",
	"wiki.teamliquid": "1100000011110",
	teamliquid: "1100000011111",
	"forum.xda-developers": "11000001000",
	"services.parliament": "1100000100100",
	weknowmemes: "1100000100101",
	getindiebill: "1100000100110",
	"hentai-foundry": "1100000100111",
	steamkiwi: "11000001010",
	"lastfm-img2.akamaized": "11000001011",
	"en.wiktionary": "110000011000",
	fangraphs: "1100000110010",
	flic: "1100000110011",
	"41.media.tumblr": "110000011010",
	"38.media.tumblr": "110000011011",
	bit: "1100000111",
	discord: "11000010",
	nytimes: "110000110",
	dndbeyond: "110000111000000",
	"3ds": "110000111000001",
	"support.discordapp": "110000111000010",
	yourporn: "110000111000011",
	"storage.googleapis": "110000111000100",
	"gxb.carolgames": "110000111000101",
	electrek: "110000111000110",
	dbr: "110000111000111",
	frameiteasy: "110000111001000",
	format: "110000111001001",
	"visualstudio.microsoft": "110000111001010",
	mobilize: "110000111001011",
	limraexim: "110000111001100",
	primealpha: "110000111001101",
	"qph.fs.quoracdn": "110000111001110",
	registertovoteflorida: "110000111001111",
	"dnd.wizards": "110000111010000",
	"media4.giphy": "110000111010001",
	indiewire: "110000111010010",
	minyoung: "110000111010011",
	"bendhur.tumblr": "110000111010100",
	dermstore: "110000111010101",
	gg: "110000111010110",
	"southpark.cc": "110000111010111",
	"vrsws.sos.ky": "110000111011000",
	tdeecalculator: "110000111011001",
	"pdfs.semanticscholar": "110000111011010",
	emojipedia: "110000111011011",
	"m.dhgate": "110000111011100",
	rtings: "110000111011101",
	"bugreport.apple": "110000111011110",
	oneplus: "110000111011111",
	"pc-kombo": "11000011110000",
	"amazon.com": "11000011110001",
	shortland: "11000011110010",
	snapchat: "11000011110011",
	codepen: "11000011110100",
	hobbyking: "11000011110101",
	dogechain: "11000011110110",
	"worldwidetvshowsnow.blogspot": "11000011110111",
	oceanpanel: "11000011111000",
	loanmanager: "11000011111001",
	wadhwaniai: "110000111110100",
	iibuffalo: "110000111110101",
	gub: "11000011111011",
	herbibot: "11000011111100",
	a: "11000011111101",
	"external-preview.redd": "11000011111110",
	"support.coinbase": "11000011111111",
	propublica: "110001000000000",
	drupal: "110001000000001",
	jsonline: "110001000000010",
	youporn: "110001000000011",
	"sports.espn.go": "110001000000100",
	eurekalert: "110001000000101",
	infoplease: "110001000000110",
	nybooks: "110001000000111",
	exrx: "110001000001000",
	io9: "110001000001001",
	urbanoutfitters: "110001000001010",
	oecd: "110001000001011",
	tf2b: "110001000001100",
	sparkfun: "110001000001101",
	freep: "110001000001110",
	"blogs.discovermagazine": "110001000001111",
	"cdn.discordapp": "11000100001",
	"help.ea": "110001000100000",
	"mwo.smurfy-net": "110001000100001",
	kff: "110001000100010",
	llbean: "110001000100011",
	dulfy: "110001000100100",
	welt: "110001000100101",
	"forums.warframe": "110001000100110",
	hbr: "110001000100111",
	mtgsalvation: "110001000101000",
	"f-droid": "110001000101001",
	npmjs: "110001000101010",
	"cdn.mediacru": "110001000101011",
	atlasobscura: "110001000101100",
	"bigstory.ap": "110001000101101",
	halopedia: "110001000101110",
	ideone: "110001000101111",
	pcgamingwiki: "110001000110000",
	"psycnet.apa": "110001000110001",
	phoronix: "110001000110010",
	"images5.fanpop": "110001000110011",
	polyvore: "110001000110100",
	observer: "110001000110101",
	"fc09.deviantart": "110001000110110",
	cabelas: "110001000110111",
	"fiber.google": "110001000111000",
	greenmangaming: "110001000111001",
	ndtv: "110001000111010",
	androidpolice: "110001000111011",
	d20srd: "110001000111100",
	bmj: "110001000111101",
	newstatesman: "110001000111110",
	about: "110001000111111",
	animenewsnetwork: "11000100100000",
	jalopnik: "11000100100001",
	chamorrobible: "11000100100010",
	tradingeconomics: "11000100100011",
	redditinc: "110001001001",
	"i.chzbgr": "11000100101000",
	mediaite: "11000100101001",
	theconversation: "11000100101010",
	gamestop: "11000100101011",
	nbc: "11000100101100",
	sciencemag: "11000100101101",
	rcfp: "11000100101110",
	deadspin: "11000100101111",
	canada: "1100010011000",
	space: "11000100110010",
	mines: "11000100110011",
	mega: "1100010011010",
	"static.api3.studiobebop": "1100010011011",
	wsj: "110001001110",
	"abc.net": "110001001111",
	"i.redd": "11000101",
	aclu: "11000110",
	myanimelist: "11000111",
	thehimalayantimes: "1100100000000",
	theintercept: "1100100000001",
	ripsave: "1100100000010",
	xx1: "1100100000011",
	"de.wikipedia": "110010000010",
	puzzledragonx: "1100100000110",
	thelocal: "11001000001110",
	sourceforge: "11001000001111",
	"i.pinimg": "11001000010",
	deviantart: "11001000011",
	yelp: "110010001000",
	nasa: "1100100010010",
	"images.google": "1100100010011",
	battle: "11001000101000",
	ibtimes: "11001000101001",
	"items.jellyneo": "11001000101010",
	tandfonline: "11001000101011",
	"sv.wikipedia": "11001000101100",
	"answers.yahoo": "11001000101101",
	"thumbs.dreamstime": "11001000101110",
	mentalfloss: "11001000101111",
	pornhub: "1100100011",
	discordapp: "11001001",
	"video.twimg": "11001010000000",
	ltstyt: "11001010000001",
	"photo.walgreens": "11001010000010",
	meme: "11001010000011",
	audible: "11001010000100",
	bostonglobe: "11001010000101",
	"media.discordapp": "11001010000110",
	etherscan: "11001010000111",
	rollingstone: "1100101000100",
	"fallout.wikia": "1100101000101",
	uso: "1100101000110",
	today: "1100101000111",
	mtgprice: "1100101001",
	govtrack: "1100101010000",
	youtubedoubler: "11001010100010",
	weather: "110010101000110",
	"forum.notebookreview": "110010101000111",
	"contact.dankmemesreddit": "110010101001",
	credo360: "11001010101",
	"s3.amazonaws": "110010101100",
	gog: "1100101011010",
	"es.wikipedia": "1100101011011",
	espn: "110010101110",
	grailed: "110010101111",
	"en.m.wikipedia": "11001011",
	google: "1100110",
	"i.reddituploads": "1100111000000",
	"journals.plos": "1100111000001",
	imo: "1100111000010",
	"myaccount.google": "1100111000011",
	swtor: "1100111000100",
	"reddit.honestbleeps": "1100111000101",
	"userserve-ak.last": "1100111000110",
	"runescape.wikia": "1100111000111",
	flickr: "1100111001",
	"chrome.google": "1100111010",
	futbin: "110011101100",
	"botmetric.pythonanywhere": "1100111011010",
	instructables: "1100111011011",
	strawpoll: "110011101110",
	irs: "110011101111",
	copymethat: "11001111000000",
	healthline: "11001111000001",
	"preview.redd": "11001111000010",
	stratz: "11001111000011",
	meshcenter: "11001111000100",
	"boards.na.leagueoflegends": "11001111000101",
	crisistextline: "11001111000110",
	"store.google": "11001111000111",
	diamondcarepetfood: "110011110010000",
	"images-wixmp-ed30a86b8c4ca887773594c2.wixmp": "110011110010001",
	"policies.google": "110011110010010",
	ratopati: "110011110010011",
	classicdb: "110011110010100",
	whoaremyrepresentatives: "110011110010101",
	"voterlookup.elections.state.ny": "110011110010110",
	setopati: "110011110010111",
	skillsoft: "11001111001100",
	"payneinstitute.mines": "11001111001101",
	"newsroom.ca.paypal-corp": "110011110011100",
	mpatlas: "110011110011101",
	"newsroom.uk.paypal-corp": "110011110011110",
	"newsroom.it.paypal-corp": "110011110011111",
	"tv.youtube": "110011110100",
	"m.facebook": "110011110101",
	dw: "11001111011000",
	"1d4chan": "11001111011001",
	steamcharts: "11001111011010",
	imagecomics: "11001111011011",
	nj: "11001111011100",
	mobygames: "11001111011101",
	myfigurecollection: "11001111011110",
	seattletimes: "11001111011111",
	mtgtop8: "110011111000000",
	smogon: "110011111000001",
	"en.numista": "110011111000010",
	"data.bls": "110011111000011",
	"s3-ec.buzzfed": "110011111000100",
	"iep.utm": "110011111000101",
	nap: "110011111000110",
	songkick: "110011111000111",
	texastribune: "110011111001000",
	"sphotos-a.xx.fbcdn": "110011111001001",
	"imperial-library": "110011111001010",
	"usatoday30.usatoday": "110011111001011",
	"no.wikipedia": "110011111001100",
	diablofans: "110011111001101",
	"g.e-hentai": "110011111001110",
	"forums.civfanatics": "110011111001111",
	jewishvirtuallibrary: "110011111010000",
	pbfcomics: "110011111010001",
	newadvent: "110011111010010",
	zazzle: "110011111010011",
	vredd: "1100111110101",
	listverse: "110011111011000",
	"images4.wikia.nocookie": "110011111011001",
	deathpenaltyinfo: "110011111011010",
	nola: "110011111011011",
	homebrewtalk: "110011111011100",
	"en.wikisource": "110011111011101",
	gq: "110011111011110",
	ontario: "110011111011111",
	"cfb.diydunce": "110011111100000",
	pajhwok: "110011111100001",
	"mnvotes.sos.state.mn": "110011111100010",
	dmsguild: "110011111100011",
	"cdn-images-1.medium": "110011111100100",
	periscope: "110011111100101",
	oodaloop: "110011111100110",
	"vfdvdfvdvf.deviantart": "110011111100111",
	"mtg.gamepedia": "110011111101000",
	resistbot: "110011111101001",
	"image.ibb": "110011111101010",
	"secure-dawn-77807.herokuapp": "110011111101011",
	jamanetwork: "110011111101100",
	nakilon: "110011111101101",
	unblockvideos: "110011111101110",
	"img.bricklink": "110011111101111",
	mrwgifs: "110011111110000",
	"ark.intel": "110011111110001",
	usmagazine: "110011111110010",
	gamersnexus: "110011111110011",
	bizjournals: "110011111110100",
	pokemon: "110011111110101",
	footballoutsiders: "110011111110110",
	probuilds: "110011111110111",
	windowscentral: "110011111111000",
	thefederalist: "110011111111001",
	imgrush: "110011111111010",
	vipleague: "110011111111011",
	virustotal: "110011111111100",
	"warhammer40k.wikia": "110011111111101",
	channelfireball: "110011111111110",
	"docs.aws.amazon": "110011111111111",
	"i.imgur": "1101",
	facebook: "11100000",
	"rover.ebay": "1110000100000",
	thinkprogress: "1110000100001",
	orcz: "1110000100010",
	variety: "1110000100011",
	tvtropes: "11100001001",
	"media1.tenor": "1110000101000",
	autistichoya: "1110000101001",
	"support.xbox": "111000010101",
	anidb: "111000010110",
	"i.kinja-img": "1110000101110",
	derpibooru: "1110000101111",
	msnbc: "11100001100000",
	vodlockershow: "11100001100001",
	"ncaaf.live-tvstreaming": "11100001100010",
	"impress.openneo": "11100001100011",
	mspaintadventures: "11100001100100",
	hrw: "11100001100101",
	"screenshot.freshphase": "11100001100110",
	"en.bitcoin": "11100001100111",
	"empleadoestatalbot.ddns": "11100001101000",
	"academic.oup": "11100001101001",
	talkorigins: "111000011010100",
	credobeauty: "111000011010101",
	pmc: "11100001101011",
	"pokegiveawaybot.tumblr": "11100001101100",
	poe: "11100001101101",
	vote: "11100001101110",
	livechart: "11100001101111",
	meritamerica: "111000011100",
	"smh.com": "1110000111010",
	"policy.medium": "1110000111011",
	target: "11100001111",
	sesamestreetincommunities: "11100010",
	wordpress: "1110001100000",
	cracked: "1110001100001",
	g: "1110001100010",
	minecraftforum: "1110001100011",
	"independent.co": "11100011001",
	locationbot: "111000110100",
	"plato.stanford": "1110001101010",
	votesmart: "1110001101011",
	"turkopticon.differenceengines": "11100011011000",
	zillow: "11100011011001",
	replygif: "11100011011010",
	"i.stack.imgur": "11100011011011",
	britannica: "11100011011100",
	memegenerator: "11100011011101",
	apa: "11100011011110",
	"boards.4chan": "11100011011111",
	"developer.valvesoftware": "111000111000000",
	townhall: "111000111000001",
	alibaba: "111000111000010",
	bgr: "111000111000011",
	"images1.wikia.nocookie": "111000111000100",
	gifbin: "111000111000101",
	dota2wiki: "111000111000110",
	"earthquake.usgs": "111000111000111",
	pugetsystems: "111000111001000",
	stathat: "111000111001001",
	livememe: "111000111001010",
	"m.wikihow": "111000111001011",
	"forum-en.guildwars2": "111000111001100",
	evga: "111000111001101",
	france24: "111000111001110",
	startribune: "111000111001111",
	"m.imdb": "1110001110100",
	"fr.wikipedia": "1110001110101",
	youjizz: "111000111011000",
	worldcat: "111000111011001",
	"e-cigarette-forum": "111000111011010",
	"fc04.deviantart": "111000111011011",
	islamqa: "111000111011100",
	encyclopediadramatica: "111000111011101",
	cbo: "111000111011110",
	ubuntu: "111000111011111",
	adessium: "111000111100000",
	thahakhabar: "111000111100001",
	"learn.microsoft": "111000111100010",
	waittfoundation: "111000111100011",
	milkcasino: "111000111100100",
	"richzhang.github": "111000111100101",
	"warframe.fandom": "111000111100110",
	"brasil.elpais": "111000111100111",
	orcid: "111000111101000",
	"mragasiapacific.com": "111000111101001",
	pntra: "111000111101010",
	"citation-needed.springer": "111000111101011",
	"newsroom.br.paypal-corp": "111000111101100",
	"tv.apple": "111000111101101",
	mccormickfoundation: "111000111101110",
	"newsroom.au.paypal-corp": "111000111101111",
	cubetutor: "111000111110000",
	"auto.leprosorium": "111000111110001",
	sportsnet: "111000111110010",
	"yt3.ggpht": "111000111110011",
	localbitcoins: "111000111110100",
	"icy-veins": "111000111110101",
	"images4-d.ravelrycache": "111000111110110",
	iflscience: "111000111110111",
	frinkiac: "111000111111000",
	bustle: "111000111111001",
	"ae01.alicdn": "111000111111010",
	"1piwup.spb": "111000111111011",
	tagpro: "111000111111100",
	"unfortunate-maps.jukejuice": "111000111111101",
	firstpost: "111000111111110",
	openload: "111000111111111",
	pcpartpicker: "111001",
	people: "11101",
	sportstainment: "11110000000000",
	"m.ebay": "11110000000001",
	detigenii: "11110000000010",
	because: "11110000000011",
	"na.finalfantasyxiv": "11110000000100",
	udemy: "11110000000101",
	"img3.wikia.nocookie": "11110000000110",
	edigitalplace: "11110000000111",
	"action.aclu": "11110000001000",
	yanginsondurmeistanbul: "11110000001001",
	"cebc.cnrs": "11110000001010",
	"sentinel.esa": "11110000001011",
	oload: "11110000001100",
	shortsss: "11110000001101",
	onmyojiarena: "11110000001110",
	"r-drrp.appspot": "11110000001111",
	"w.atch": "111100000100",
	"i.kym-cdn": "111100000101",
	paypal: "11110000011",
	"anime-planet": "1111000010",
	biblegateway: "11110000110",
	"telegraph.co": "11110000111",
	archive: "11110001",
	"img.scryfall": "11110010",
	scryfall: "11110011",
	memes: "111101000000",
	meetup: "1111010000010",
	thestar: "1111010000011",
	reuters: "11110100001",
	commondreams: "11110100010000",
	yanglinks: "11110100010001",
	fortune: "1111010001001",
	mayoclinic: "1111010001010",
	thepiratebay: "11110100010110",
	moddb: "11110100010111",
	livebuzztv: "111101000110",
	"danbooru.donmai": "111101000111",
	vshare: "11110100100000",
	shortwww: "11110100100001",
	"cdn11.bigcommerce": "11110100100010",
	"steamuserimages-a.akamaihd": "11110100100011",
	commonsensemedia: "11110100100100",
	"pets.webmd": "11110100100101",
	"res.cloudinary": "11110100100110",
	"m.mlb": "11110100100111",
	qz: "1111010010100",
	ulta: "1111010010101",
	goodwill: "1111010010110",
	"images.akamai.steamusercontent": "1111010010111",
	vox: "111101001100",
	vice: "1111010011010",
	wearegreenbay: "1111010011011",
	wikidata: "111101001110",
	"sites.google": "111101001111",
	wolframalpha: "1111010100",
	xkcd: "1111010101",
	yugiohprices: "111101011000",
	arstechnica: "111101011001",
	mtggoldfish: "1111010110100",
	blockchain: "1111010110101",
	movies: "1111010110110",
	vid: "1111010110111",
	lmgtfy: "11110101110",
	"au.pcpartpicker": "11110101111",
	"i.qkme": "11110110000",
	"news.nationalgeographic": "11110110001000",
	"developer.apple": "11110110001001",
	splcenter: "11110110001010",
	wizards: "11110110001011",
	"i.sli": "111101100011",
	philly: "111101100100000",
	nvidia: "111101100100001",
	"en.memory-alpha": "111101100100010",
	pcmag: "111101100100011",
	hackaday: "111101100100100",
	"dc.wikia": "111101100100101",
	"lh4.googleusercontent": "111101100100110",
	"xda-developers": "111101100100111",
	bandcamp: "111101100101000",
	tube8: "111101100101001",
	complex: "111101100101010",
	shroomery: "111101100101011",
	"fc02.deviantart": "111101100101100",
	directv: "111101100101101",
	"farm4.staticflickr": "111101100101110",
	"fc00.deviantart": "111101100101111",
	shopineer: "1111011001100",
	cnet: "1111011001101",
	nationmaster: "111101100111000",
	jezebel: "111101100111001",
	drugs: "111101100111010",
	superuser: "111101100111011",
	hillaryclinton: "111101100111100",
	"city-data": "111101100111101",
	sheldonbrown: "111101100111110",
	"en.wikibooks": "111101100111111",
	"help.twitch": "111101101000000",
	milb: "111101101000001",
	niceme: "111101101000010",
	metabattle: "111101101000011",
	nutritionfacts: "111101101000100",
	"chat.tripsit": "111101101000101",
	thegatewaypundit: "111101101000110",
	"play.spotify": "111101101000111",
	paste4btc: "111101101001000",
	plays: "111101101001001",
	streamendous: "111101101001010",
	"9gug": "111101101001011",
	playstation: "111101101001100",
	"uk.reuters": "111101101001101",
	coriolis: "111101101001110",
	offsided: "111101101001111",
	barnesandnoble: "111101101010000",
	rotoworld: "111101101010001",
	"dev.dota2": "111101101010010",
	"studentaid.ed": "111101101010011",
	torproject: "111101101010100",
	"in.reuters": "111101101010101",
	rainn: "111101101010110",
	"support.mozilla": "111101101010111",
	sunnah: "111101101011000",
	"forum.supercell": "111101101011001",
	"it.pcpartpicker": "111101101011010",
	"it.wikipedia": "111101101011011",
	al: "111101101011100",
	"en.cppreference": "111101101011101",
	op: "111101101011110",
	indiedb: "111101101011111",
	gaugepowered: "11110110110000",
	"media3.giphy": "11110110110001",
	sbtl: "11110110110010",
	clyp: "11110110110011",
	humblebundle: "11110110110100",
	factcheck: "11110110110101",
	lowes: "11110110110110",
	w3: "11110110110111",
	"s.reddit": "111101101110000",
	dis: "111101101110001",
	lokaantar: "111101101110010",
	vrddit: "111101101110011",
	heavy: "111101101110100",
	"support.oculus": "111101101110101",
	steemit: "111101101110110",
	thesilphroad: "111101101110111",
	postkodstiftelsen: "11110110111100",
	"piskihuiski.ivanovo": "11110110111101",
	"newsroom.fr.paypal-corp": "111101101111100",
	oakfnd: "111101101111101",
	bloomingdales: "111101101111110",
	"newsroom.apac.paypal-corp": "111101101111111",
	theglobeandmail: "1111011100000",
	"finance.yahoo": "1111011100001",
	lg: "1111011100010",
	change: "1111011100011",
	"friendsafaribot.tumblr": "11110111001",
	marxists: "11110111010",
	tineye: "11110111011",
	streamable: "111101111",
	wired: "111110000000",
	ign: "1111100000010",
	realclearpolitics: "1111100000011",
	pagesix: "1111100000100",
	geekwire: "1111100000101",
	shareasale: "1111100000110",
	"vignette4.wikia.nocookie": "1111100000111",
	vine: "1111100001000",
	"stream1.gifsoup": "1111100001001",
	anrdoezrs: "1111100001010",
	biblehub: "1111100001011",
	manyvids: "1111100001100",
	"events.jacksonville": "1111100001101",
	who: "1111100001110",
	"theregister.co": "11111000011110",
	newscientist: "11111000011111",
	"old.reddit": "111110001",
	cnbc: "111110010000",
	"qsniyg.github": "1111100100010",
	legaliq: "1111100100011",
	pinterest: "111110010010",
	mediafire: "111110010011",
	ow: "11111001010000",
	gawker: "11111001010001",
	timesofisrael: "11111001010010",
	"img4.wikia.nocookie": "11111001010011",
	nhs: "11111001010100",
	nps: "11111001010101",
	history: "11111001010110",
	bitbucket: "11111001010111",
	"news.un": "11111001011000",
	yangintupufirmasi: "11111001011001",
	"presidencia.go": "11111001011010",
	googlecloudcommunity: "11111001011011",
	beedogs: "11111001011100",
	cakedogg: "11111001011101",
	noteb: "11111001011110",
	grammarerrors: "11111001011111",
	watttime: "1111100110000",
	mercons: "1111100110001",
	hollywoodreporter: "1111100110010",
	thehindu: "11111001100110",
	eff: "11111001100111",
	dota2: "111110011010",
	quickmeme: "111110011011",
	"40.media.tumblr": "111110011100",
	redditlog: "111110011101",
	patreon: "11111001111",
	imageshack: "111110100000000",
	"pages.ebay": "111110100000001",
	"naruto.wikia": "111110100000010",
	"nintendo.co": "111110100000011",
	libcom: "111110100000100",
	lesswrong: "111110100000101",
	"nzherald.co": "111110100000110",
	giantbomb: "111110100000111",
	spotrac: "111110100001000",
	shapeways: "111110100001001",
	michigan: "111110100001010",
	iafd: "111110100001011",
	boxofficemojo: "111110100001100",
	numbeo: "111110100001101",
	cinemablend: "111110100001110",
	usccb: "111110100001111",
	apnews: "1111101000100",
	"encrypted-tbn0.gstatic": "1111101000101",
	gsmarena: "111110100011000",
	ynetnews: "111110100011001",
	"hackage.haskell": "111110100011010",
	"fsis.usda": "111110100011011",
	medicalnewstoday: "111110100011100",
	democracynow: "111110100011101",
	example: "111110100011110",
	counterpunch: "111110100011111",
	bigflixmovies: "111110100100000",
	"2kmtcentral": "111110100100001",
	"support.sprint": "111110100100010",
	"support.office": "111110100100011",
	eporner: "111110100100100",
	coinbase: "111110100100101",
	livestreamhdtv365: "111110100100110",
	"raw.githubusercontent": "111110100100111",
	trythatsoap: "111110100101000",
	"mods.factorio": "111110100101001",
	bitchute: "111110100101010",
	"7-eleven": "111110100101011",
	pin: "111110100101100",
	gilishe: "111110100101101",
	"sci-hub": "111110100101110",
	"shadowverse-portal": "111110100101111",
	vk: "111110100110000",
	banggood: "111110100110001",
	yl: "111110100110010",
	revzilla: "111110100110011",
	leafly: "111110100110100",
	screenrant: "111110100110101",
	code: "111110100110110",
	mlssoccer: "111110100110111",
	"forum.warthunder": "111110100111000",
	color: "111110100111001",
	"img.4plebs": "111110100111010",
	smashboards: "111110100111011",
	"sto.gamepedia": "111110100111100",
	obsproject: "111110100111101",
	"sbs.com": "111110100111110",
	cleantechnica: "111110100111111",
	opensource: "11111010100000",
	infobae: "11111010100001",
	"image.prntscr": "11111010100010",
	"67.media.tumblr": "11111010100011",
	"cdn.awwni": "11111010100100",
	ballotpedia: "11111010100101",
	msn: "11111010100110",
	"source.android": "11111010100111",
	ffa: "111110101010000",
	donabertarelli: "111110101010001",
	"faq.spire": "111110101010010",
	"newsroom.deatch.paypal-corp": "111110101010011",
	forms: "111110101010100",
	"repo.packix": "111110101010101",
	"en.unesco": "111110101010110",
	"assistant.google": "111110101010111",
	rnintendoswitch: "11111010101100",
	"md-akc.med.nhl": "11111010101101",
	"help.medium": "11111010101110",
	dupebot: "11111010101111",
	dailydot: "11111010110000",
	phys: "11111010110001",
	"i1.wp": "11111010110010",
	hiyo: "11111010110011",
	"i2.kym-cdn": "1111101011010",
	monoprice: "11111010110110",
	hiringourheroes: "11111010110111",
	"giftcards.kroger": "11111010111",
	"mobile.twitter": "11111011000",
	bloomberg: "11111011001",
	hearthhead: "111110110100",
	"mobile.nytimes": "1111101101010",
	usnews: "1111101101011",
	"media-hearth.cursecdn": "11111011011",
	karmadecay: "1111101110",
	quora: "111110111100",
	rt: "1111101111010",
	"developer.android": "1111101111011",
	bbc: "11111011111",
	"v.redd": "11111100000",
	"technet.microsoft": "11111100001000",
	senate: "11111100001001",
	etymonline: "11111100001010",
	"thesun.co": "11111100001011",
	stackoverflow: "111111000011",
	bogleheads: "11111100010000",
	si: "11111100010001",
	"data.worldbank": "11111100010010",
	nintendo: "11111100010011",
	bleacherreport: "11111100010100",
	mashable: "11111100010101",
	wayfair: "11111100010110",
	"static.fjcdn": "11111100010111",
	steamtrades: "11111100011000",
	battleforthenet: "11111100011001",
	"mediadownloads.mlb": "1111110001101",
	"forums.frontier.co": "11111100011100",
	coinmarketcap: "11111100011101",
	tenor: "11111100011110",
	"en.uesp": "11111100011111",
	"osu.ppy": "11111100100",
	monthlyreview: "1111110010100",
	pewresearch: "1111110010101",
	"news.yahoo": "11111100101100",
	"news.cnet": "111111001011010",
	kongregate: "111111001011011",
	yang2020: "1111110010111",
	hltv: "11111100110",
	"news.ycombinator": "111111001110",
	sciencedaily: "1111110011110",
	nber: "11111100111110",
	"discussions.apple": "11111100111111",
	"play.google": "111111010",
	dropbox: "11111101100",
	"consumer.ftc": "11111101101000",
	evike: "11111101101001",
	gofundme: "11111101101010",
	"media1.giphy": "11111101101011",
	deadline: "11111101101100",
	fda: "11111101101101",
	examine: "11111101101110",
	askubuntu: "11111101101111",
	mediacru: "111111011100000",
	"hockey-reference": "111111011100001",
	geforce: "111111011100010",
	prnewswire: "111111011100011",
	ask: "111111011100100",
	vulture: "111111011100101",
	"us.asos": "111111011100110",
	dhgate: "111111011100111",
	"orig00.deviantart": "111111011101000",
	"i.guim.co": "111111011101001",
	userbenchmark: "111111011101010",
	linkesloder: "111111011101011",
	tvwire: "111111011101100",
	coindesk: "111111011101101",
	icloud: "111111011101110",
	bitinfocharts: "111111011101111",
	"fc06.deviantart": "111111011110000",
	adafruit: "111111011110001",
	"parts-express": "111111011110010",
	funnyjunk: "111111011110011",
	sendspace: "111111011110100",
	"forums.steampowered": "111111011110101",
	uscis: "111111011110110",
	"bugzilla.mozilla": "111111011110111",
	"theage.com": "111111011111000",
	faa: "111111011111001",
	supremecourt: "111111011111010",
	"3dmark": "111111011111011",
	cleveland: "111111011111100",
	"cic.gc": "111111011111101",
	mrmoneymustache: "111111011111110",
	rockpapershotgun: "111111011111111",
	"ncbi.nlm.nih": "111111100",
	"pbs.twimg": "111111101",
	"api.scryfall": "111111110",
	"owo.bitz": "11111111100000",
	"dl.opensubtitles": "11111111100001",
	alkami: "11111111100010",
	fyens: "11111111100011",
	"static1.squarespace": "11111111100100",
	warcraftlogs: "11111111100101",
	"kalugaluga.kaluga": "11111111100110",
	videopriem: "11111111100111",
	"api.random": "111111111010000",
	"trends.google": "111111111010001",
	"phanes.feralhosting": "111111111010010",
	"d1u5p3l4wpay3k.cloudfront": "111111111010011",
	"aws.wariomissed": "111111111010100",
	"charts.camelcamelcamel": "111111111010101",
	"ishtar-collective": "111111111010110",
	ourworldindata: "111111111010111",
	blackentrepreneursday: "111111111011000",
	glotalent: "111111111011001",
	"libguides.ala": "111111111011010",
	kidsbeetv: "111111111011011",
	"blog.nationalgeographic": "111111111011100",
	lettercount: "111111111011101",
	"foundation.mozilla": "111111111011110",
	ushcc: "111111111011111",
	reddithelp: "11111111110",
	urbandictionary: "11111111111"
}, h = {
	0: "1100111000",
	1: "1100111100",
	2: "1100111101",
	3: "0010011100",
	4: "00100111101",
	5: "11001110010",
	6: "00100111011",
	7: "11001110011",
	8: "00100111010",
	9: "00100111100",
	l: "0000",
	c: "0001",
	v: "001000",
	"-": "0010010",
	x: "00100110",
	q: "0010011111",
	g: "00101",
	n: "0011",
	p: "01000",
	y: "010010",
	w: "010011",
	i: "0101",
	t: "0110",
	r: "0111",
	s: "1000",
	d: "10010",
	m: "10011",
	END: "1010",
	o: "1011",
	u: "11000",
	f: "110010",
	k: "1100110",
	z: "110011101",
	j: "110011111",
	a: "1101",
	e: "1110",
	".": "11110",
	h: "111110",
	b: "111111"
}, g = {
	0: "011011",
	1: "011001",
	2: "1111000",
	3: "1010011",
	4: "1010010",
	5: "1001011",
	6: "1001010",
	7: "1000101",
	8: "1000110",
	9: "0110001",
	o: "0000",
	"/": "0001",
	s: "0010",
	"&": "00110000",
	R: "00110001",
	"?": "0011001",
	k: "001101",
	d: "00111",
	t: "0100",
	i: "0101",
	",": "01100000000",
	"'": "0110000000100",
	"]": "0110000000101",
	"!": "011000000011",
	":": "0110000001",
	W: "011000001",
	q: "01100001",
	b: "011010",
	a: "0111",
	l: "10000",
	U: "100010000",
	L: "100010001",
	A: "10001001",
	".": "1000111",
	f: "100100",
	c: "10011",
	"=": "1010000",
	G: "101000100",
	E: "101000101",
	I: "101000110",
	F: "101000111",
	m: "10101",
	"-": "10110",
	w: "101110",
	X: "1011110000",
	"+": "1011110001",
	D: "101111001",
	Z: "1011110100",
	"*": "10111101010000",
	$: "1011110101000100",
	";": "1011110101000101",
	"@": "101111010100011",
	"[": "1011110101001",
	"(": "101111010101",
	")": "10111101011",
	P: "101111011",
	v: "1011111",
	e: "1100",
	j: "11010000",
	O: "110100010",
	Q: "1101000110",
	K: "1101000111",
	y: "1101001",
	g: "110101",
	h: "110110",
	u: "110111",
	n: "11100",
	V: "1110100000",
	Y: "1110100001",
	B: "111010001",
	M: "111010010",
	C: "111010011",
	x: "11101010",
	J: "1110101100",
	"#": "1110101101",
	S: "111010111",
	_: "111011",
	z: "111100100",
	"%": "111100101",
	T: "111100110",
	H: "1111001110",
	N: "1111001111",
	p: "111101",
	r: "11111"
}, _ = {};
for (let e in p) _[p[e]] = e;
var v = {};
for (let e in m) v[m[e]] = e;
var y = Object.keys(m).sort((e, t) => t.length - e.length), b = {};
for (let e in h) b[h[e]] = e;
var x = {};
for (let e in g) x[g[e]] = e;
function S(e, t) {
	let n = BigInt(t.length), r = T(t), i = "", a = (e) => {
		let n = t[e];
		if (r.variableLength && i && r.matchLast((i.slice(-r.maxSymbolLength) + n).slice(-r.maxSymbolLength)) !== e) {
			if (!r.separator) throw Error("Alphabet has an ambiguous boundary and no safe separator");
			i += r.separator;
		}
		i += n;
	};
	for (; e >= r.chunkOffset;) {
		let n = e - r.chunkOffset, i = Number(n % r.chunkBase);
		e = n / r.chunkBase;
		for (let e = 0; e < r.chunkDigits; e++) a(i % t.length), i = Math.floor(i / t.length);
	}
	for (; e > 0;) e--, a(Number(e % n)), e /= n;
	return i;
}
var C = /* @__PURE__ */ new WeakMap(), w = [
	".",
	"|",
	"^",
	"`"
];
function T(e) {
	let t = C.get(e);
	if (t) return t;
	let n = {
		children: /* @__PURE__ */ new Map(),
		index: -1
	};
	e.forEach((e, t) => {
		let r = n;
		for (let t of Array.from(e).reverse()) r.children.has(t) || r.children.set(t, {
			children: /* @__PURE__ */ new Map(),
			index: -1
		}), r = r.children.get(t);
		r.index < 0 && (r.index = t);
	});
	let r = (e, t = e.length) => {
		let r = n, i = -1;
		for (; t > 0;) {
			let n = t - 1, a = e.charCodeAt(n);
			if (a >= 56320 && a <= 57343 && n > 0) {
				let t = e.charCodeAt(n - 1);
				t >= 55296 && t <= 56319 && n--;
			}
			if (r = r.children.get(e.slice(n, t)), !r) break;
			r.index >= 0 && (i < 0 || r.index < i) && (i = r.index), t = n;
		}
		return i;
	}, i = e.some((e) => Array.from(e).length > 1), a = Math.max(...e.map((e) => e.length)), o = i && w.find((t) => e.every((e) => !e.includes(t))) || "", s = BigInt(e.length), c = BigInt(2 ** 53 - 1), l = 1n, u = 0n, d = 0;
	for (;;) {
		let e = u + l, t = l * s;
		if (s * e > c) break;
		u = e, l = t, d++;
	}
	return t = {
		matchLast: r,
		separator: o,
		variableLength: i,
		maxSymbolLength: a,
		chunkBase: l,
		chunkOffset: u,
		chunkDigits: d
	}, C.set(e, t), t;
}
function E(e, t, n) {
	let r = T(t), i = 0, a = e.length;
	for (; a > 0;) {
		if (r.separator && e.endsWith(r.separator, a)) throw Error("Invalid alphabet boundary separator");
		let o = r.matchLast(e, a);
		if (o < 0) throw Error(`Invalid character: "${e.slice(0, a).at(-1)}"`);
		if (n(o), i++, a -= t[o].length, r.separator && e.endsWith(r.separator, a) && (a -= r.separator.length, a <= 0 || e.endsWith(r.separator, a))) throw Error("Invalid alphabet boundary separator");
	}
	return i;
}
function D(e, t) {
	let n = BigInt(t.length), r = T(t), i = 0n, a = 0, o = 0, s = () => {
		o &&= (i *= n ** BigInt(o), i += BigInt(a), a = 0, 0);
	};
	return E(e, t, (e) => {
		a = a * t.length + e + 1, o++, o === r.chunkDigits && s();
	}), s(), i;
}
function O(e, t) {
	for (let n = t.length - 1; n >= 0; n--) e <<= 1n, t[n] === "1" && e++;
	return e;
}
function ee(e, t) {
	let n = "";
	do
		if (n += e & 1n, e >>= 1n, n.length > 20) throw `Huffman sequence too long: "${n}".`;
	while (!(n in t));
	return {
		newNumber: e,
		digit: t[n]
	};
}
function te(e) {
	let t = [];
	for (let n = 0; n < 8; n++) t.unshift((e & 65535n).toString(16)), e >>= 16n;
	let n = -1, r = 0, i = -1;
	for (let e = 0; e <= t.length; e++) if (e < t.length && t[e] === "0") i === -1 && (i = e);
	else if (i !== -1) {
		let t = e - i;
		t > r && t > 1 && (n = i, r = t), i = -1;
	}
	return n === -1 ? t.join(":") : `${t.slice(0, n).join(":")}::${t.slice(n + r).join(":")}`;
}
function ne(e) {
	let t = e.split("::"), n = t[0] ? t[0].split(":") : [], r = t[1] ? t[1].split(":") : [], i = 8 - n.length - r.length, a = [
		...n,
		...Array(i).fill("0"),
		...r
	], o = 0n;
	for (let e of a) o <<= 16n, o += BigInt(`0x${e || "0"}`);
	return o;
}
function re(e, t) {
	let n = 1n, r;
	r = URL.canParse(e) ? new URL(e) : new URL("http://" + e);
	let i = r.hostname.toLowerCase(), a = i.startsWith("[") && i.endsWith("]"), o = BigInt(r.port), s = !a && i.includes(".") && i.split(".").at(-1).toLowerCase();
	s in p && (i = i.split(".").slice(0, -1).join("."));
	let c = r.protocol === "https:", l = !a && r.hostname.toLowerCase().startsWith("www.");
	l && (i = i.slice(4));
	let u = a ? "" : y.find((e) => i.endsWith(e)) || "", d = i.slice(0, -u.length), _ = r.pathname, v = _.endsWith("/index.html"), b = _.endsWith("/index.php");
	v ? _ = _.slice(0, -11) : b && (_ = _.slice(0, -10));
	let x = _.split("/").filter((e) => e.length).map((e) => ({
		type: "path",
		value: e
	})), C = r.search ? r.search.slice(1).split("&").flatMap((e) => {
		let t = e.indexOf("=");
		return t === -1 ? [e, ""] : [e.slice(0, t), e.slice(t + 1)];
	}).map((e) => ({
		type: "query",
		value: e
	})) : [];
	x.push(...C), r.hash && r.hash.length > 1 && x.push({
		type: "hash",
		value: r.hash.slice(1)
	});
	let w = /(%(?:23|24|26|2B|2C|2F|3A|3B|3D|3F|40))/gi;
	for (let e of x) e.value = e.value.split(w).map((e, t) => t % 2 == 1 ? e : encodeURI(decodeURI(e))).join("");
	let T = x.at(-1)?.type, E = 0;
	for (let e = x.length - 1; e >= 0; e--) {
		let t = x[e], r = e === x.length - 1;
		!r && E % 2 != 1 && (n <<= 1n, T === "hash" && t.type === "query" ? n++ : T === "hash" && t.type === "path" ? (n++, n <<= 1n, n++) : T !== t.type && (n <<= 1n, n++), T = t.type), t.type === "query" && E++;
		let i = -1, a = null;
		for (let e = 0; e < f.length; e++) if (!Array.from(t.value).some((t) => !f[e].includes(t))) {
			a = f[e], i = e;
			break;
		}
		let o = r ? n : O(n, g["#"]);
		for (let e = t.value.length - 1; e >= 0; e--) if (t.value[e - 2] === "%") {
			let n = parseInt(t.value.slice(e - 1, e + 1), 16);
			o *= 256n, o += BigInt(n), o = O(o, g["%"]), e -= 2;
		} else t.value[e] === "~" ? (o *= 256n, o += BigInt(126), o = O(o, g["%"])) : o = O(o, g[t.value[e]]);
		if (o *= BigInt(f.length + 1), !a) {
			n = o;
			continue;
		}
		let s = BigInt(a.length + 1), c = r ? n : n * s;
		for (let e = t.value.length - 1; e >= 0; e--) c *= s, c += BigInt(a.indexOf(t.value[e]) + 1);
		c *= BigInt(f.length + 1), c += BigInt(i + 1), n = o < c ? o : c;
	}
	if (x.length > 0 && (n *= 3n, x[0].type === "query" ? n += 1n : x[0].type === "hash" && (n += 2n)), a) {
		let e = ne(i.slice(1, -1));
		n <<= 128n, n += e, n = O(n, h.END);
	} else if (u) {
		if (d) {
			x.length > 0 && (n = O(n, h.END));
			for (let e = d.length - 1; e >= 0; e--) n = O(n, h[d[e]]);
		}
		n = O(n, m[u]);
	} else {
		x.length > 0 && (n = O(n, h.END));
		for (let e = i.length - 1; e >= 0; e--) n = O(n, h[i[e]]);
	}
	u && (n <<= 1n, d && (n += 1n)), n <<= 1n, u && (n += 1n), n <<= 1n, b && (n += 1n), (v || b) && (n <<= 1n, n += 1n), n <<= 1n, c && (n += 1n), n <<= 1n, l && (n += 1n), n = O(n, p[s] || p[""]), o && (n *= 65536n, n += o), n <<= 1n, o && (n += 1n);
	for (let e = 0; e < 0; e++) n <<= 1n, n += 1n;
	return n <<= 1n, S(n, t);
}
function ie(e, t) {
	let n = D(e, t), r = 0;
	for (; n & 1n;) r++, n >>= 1n;
	n >>= 1n;
	let i = n & 1n;
	n >>= 1n;
	let a;
	i && (a = n % 65536n, n /= 65536n);
	let o = ee(n, _);
	n = o.newNumber;
	let s = o.digit, c = n & 1n;
	n >>= 1n;
	let l = n & 1n;
	n >>= 1n;
	let u = "";
	n & 1n && (n >>= 1n, u = n & 1n ? "/index.php" : "/index.html"), n >>= 1n;
	let d = n & 1n;
	n >>= 1n;
	let p = !1;
	d && (p = n & 1n, n >>= 1n);
	let m = "", h = "", g = "";
	if (d) {
		let e = ee(n, v);
		if (n = e.newNumber, m = e.digit, p) for (; n > 1n;) {
			let { newNumber: e, digit: t } = ee(n, b);
			if (n = e, t === "END") break;
			h += t;
		}
	} else {
		let { newNumber: e, digit: t } = ee(n, b);
		if (n = e, t === "END") {
			let e = n & (1n << 128n) - 1n;
			n >>= 128n, m = `[${te(e)}]`;
		} else for (m += t; n > 1n;) {
			let { newNumber: e, digit: t } = ee(n, b);
			if (n = e, t === "END") break;
			m += t;
		}
	}
	let y = n % 3n;
	n /= 3n;
	let S = [
		"path",
		"query",
		"hash"
	][y], C = 0;
	for (; n > 1n;) {
		S === "path" ? g += "/" : S === "hash" ? g += "#" : (C % 2 ? g += "=" : g += C === 0 ? "?" : "&", C++);
		let e = Number(n % BigInt(f.length + 1));
		if (n /= BigInt(f.length + 1), e === 0) for (; n > 1n;) {
			let { newNumber: e, digit: t } = ee(n, x);
			if (n = e, t === "#" && S !== "hash") break;
			if (g += t, t === "%") {
				let e = n % 256n;
				g += e.toString(16).padStart(2, "0"), n /= 256n;
			}
		}
		else {
			let t = f[e - 1], r = BigInt(t.length + 1);
			for (; n > 1n;) {
				let e = Number(n % r);
				if (n /= r, e === 0) break;
				g += t[e - 1];
			}
		}
		C % 2 || (n & 1n && (S === "path" ? (n >>= 1n, S = n & 1n ? "hash" : "query") : S = "hash"), n >>= 1n);
	}
	let w = g.search(/[?#]/), T = w === -1 ? g : g.slice(0, w), E = w === -1 ? "" : g.slice(w);
	return (l ? "https://" : "http://") + (c ? "www." : "") + h + m + (s ? "." + s : "") + (i ? ":" + a : "") + T + u + E;
}
Object.freeze({
	"r:": "javascript",
	"m:": "markdown",
	"h:": "html"
});
var ae = Object.freeze({
	javascript: "r:",
	markdown: "m:",
	html: "h:"
});
function oe(e) {
	return ae[e] || "";
}
var se = Object.freeze([
	["ss:", "super-source"],
	["sm:", "source-markdown"],
	["sj:", "source-javascript"],
	["sh:", "source-html"],
	["hs:", "source-live"],
	["media:", "media"],
	["pdf:", "pdf"],
	["lr:", "resolved"],
	["lf:", "framed"],
	["i:", "image"],
	["s:", "source"],
	["l:", "guarded"]
]), ce = [
	"javascript",
	"markdown",
	"html"
].map((e) => oe(e).slice(0, -1));
RegExp(`^#(?:${[...se.map(([e]) => e.slice(0, -1)), ...ce].join("|")}):\\S+$`, "i"), Object.freeze({
	md: "markdown",
	markdown: "markdown",
	mdown: "markdown",
	mkdn: "markdown",
	js: "javascript",
	mjs: "javascript",
	cjs: "javascript",
	jsx: "javascript",
	ts: "javascript",
	tsx: "javascript",
	css: "text",
	html: "html",
	htm: "html",
	xhtml: "html"
}), Object.freeze({
	"text/html": "html",
	"application/xhtml+xml": "html",
	"text/markdown": "markdown",
	"text/x-markdown": "markdown",
	"application/markdown": "markdown",
	"text/javascript": "javascript",
	"application/javascript": "javascript",
	"text/ecmascript": "javascript",
	"application/ecmascript": "javascript",
	"text/typescript": "javascript",
	"application/typescript": "javascript",
	"text/css": "text"
});
function le(e, { inferProtocol: t = !0 } = {}) {
	let n = String(e).trim();
	if (!n) throw Error("Enter a link first");
	let r = /^\w+:\/\//i.test(n), i = new URL(r || !t ? n : `http://${n}`);
	if (i.protocol !== "http:" && i.protocol !== "https:") throw Error(`Invalid protocol: ${i.protocol}. Only http and https are supported.`);
	if (i.username || i.password) throw Error("Credentials in URLs are not supported");
	return i.href;
}
function ue(e, t = d) {
	le(e);
	let n = re(String(e).trim(), t), r = ie(n, t);
	return le(r, { inferProtocol: !1 }), {
		payload: n,
		target: r
	};
}
function de(e) {
	let t = e.length;
	for (; --t >= 0;) e[t] = 0;
}
var fe = 0, pe = 1, me = 2, he = 3, ge = 258, _e = 29, ve = 256, ye = ve + 1 + _e, be = 30, xe = 19, Se = 2 * ye + 1, Ce = 15, we = 16, Te = 7, Ee = 256, De = 16, Oe = 17, ke = 18, Ae = new Uint8Array([
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	1,
	1,
	1,
	1,
	2,
	2,
	2,
	2,
	3,
	3,
	3,
	3,
	4,
	4,
	4,
	4,
	5,
	5,
	5,
	5,
	0
]), je = new Uint8Array([
	0,
	0,
	0,
	0,
	1,
	1,
	2,
	2,
	3,
	3,
	4,
	4,
	5,
	5,
	6,
	6,
	7,
	7,
	8,
	8,
	9,
	9,
	10,
	10,
	11,
	11,
	12,
	12,
	13,
	13
]), Me = new Uint8Array([
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	2,
	3,
	7
]), Ne = new Uint8Array([
	16,
	17,
	18,
	0,
	8,
	7,
	9,
	6,
	10,
	5,
	11,
	4,
	12,
	3,
	13,
	2,
	14,
	1,
	15
]), Pe = 512, Fe = Array((ye + 2) * 2);
de(Fe);
var Ie = Array(be * 2);
de(Ie);
var Le = Array(Pe);
de(Le);
var Re = Array(ge - he + 1);
de(Re);
var ze = Array(_e);
de(ze);
var Be = Array(be);
de(Be);
function Ve(e, t, n, r, i) {
	this.static_tree = e, this.extra_bits = t, this.extra_base = n, this.elems = r, this.max_length = i, this.has_stree = e && e.length;
}
var He, Ue, We;
function Ge(e, t) {
	this.dyn_tree = e, this.max_code = 0, this.stat_desc = t;
}
var Ke = (e) => e < 256 ? Le[e] : Le[256 + (e >>> 7)], qe = (e, t) => {
	e.pending_buf[e.pending++] = t & 255, e.pending_buf[e.pending++] = t >>> 8 & 255;
}, k = (e, t, n) => {
	e.bi_valid > we - n ? (e.bi_buf |= t << e.bi_valid & 65535, qe(e, e.bi_buf), e.bi_buf = t >> we - e.bi_valid, e.bi_valid += n - we) : (e.bi_buf |= t << e.bi_valid & 65535, e.bi_valid += n);
}, A = (e, t, n) => {
	k(e, n[t * 2], n[t * 2 + 1]);
}, Je = (e, t) => {
	let n = 0;
	do
		n |= e & 1, e >>>= 1, n <<= 1;
	while (--t > 0);
	return n >>> 1;
}, Ye = (e) => {
	e.bi_valid === 16 ? (qe(e, e.bi_buf), e.bi_buf = 0, e.bi_valid = 0) : e.bi_valid >= 8 && (e.pending_buf[e.pending++] = e.bi_buf & 255, e.bi_buf >>= 8, e.bi_valid -= 8);
}, Xe = (e, t) => {
	let { dyn_tree: n, max_code: r } = t, i = t.stat_desc.static_tree, a = t.stat_desc.has_stree, o = t.stat_desc.extra_bits, s = t.stat_desc.extra_base, c = t.stat_desc.max_length, l, u, d, f, p, m, h = 0;
	for (f = 0; f <= Ce; f++) e.bl_count[f] = 0;
	for (n[e.heap[e.heap_max] * 2 + 1] = 0, l = e.heap_max + 1; l < Se; l++) u = e.heap[l], f = n[n[u * 2 + 1] * 2 + 1] + 1, f > c && (f = c, h++), n[u * 2 + 1] = f, u > r || (e.bl_count[f]++, p = 0, u >= s && (p = o[u - s]), m = n[u * 2], e.opt_len += m * (f + p), a && (e.static_len += m * (i[u * 2 + 1] + p)));
	if (h !== 0) {
		do {
			for (f = c - 1; e.bl_count[f] === 0;) f--;
			e.bl_count[f]--, e.bl_count[f + 1] += 2, e.bl_count[c]--, h -= 2;
		} while (h > 0);
		for (f = c; f !== 0; f--) for (u = e.bl_count[f]; u !== 0;) d = e.heap[--l], d > r || (n[d * 2 + 1] !== f && (e.opt_len += (f - n[d * 2 + 1]) * n[d * 2], n[d * 2 + 1] = f), u--);
	}
}, Ze = (e, t, n) => {
	let r = Array(Ce + 1), i = 0, a, o;
	for (a = 1; a <= Ce; a++) i = i + n[a - 1] << 1, r[a] = i;
	for (o = 0; o <= t; o++) {
		let t = e[o * 2 + 1];
		t !== 0 && (e[o * 2] = Je(r[t]++, t));
	}
}, Qe = () => {
	let e, t, n, r, i, a = Array(Ce + 1);
	for (n = 0, r = 0; r < _e - 1; r++) for (ze[r] = n, e = 0; e < 1 << Ae[r]; e++) Re[n++] = r;
	for (Re[n - 1] = r, i = 0, r = 0; r < 16; r++) for (Be[r] = i, e = 0; e < 1 << je[r]; e++) Le[i++] = r;
	for (i >>= 7; r < be; r++) for (Be[r] = i << 7, e = 0; e < 1 << je[r] - 7; e++) Le[256 + i++] = r;
	for (t = 0; t <= Ce; t++) a[t] = 0;
	for (e = 0; e <= 143;) Fe[e * 2 + 1] = 8, e++, a[8]++;
	for (; e <= 255;) Fe[e * 2 + 1] = 9, e++, a[9]++;
	for (; e <= 279;) Fe[e * 2 + 1] = 7, e++, a[7]++;
	for (; e <= 287;) Fe[e * 2 + 1] = 8, e++, a[8]++;
	for (Ze(Fe, ye + 1, a), e = 0; e < be; e++) Ie[e * 2 + 1] = 5, Ie[e * 2] = Je(e, 5);
	He = new Ve(Fe, Ae, ve + 1, ye, Ce), Ue = new Ve(Ie, je, 0, be, Ce), We = new Ve([], Me, 0, xe, Te);
}, $e = (e) => {
	let t = 0;
	for (; t < ye; t++) e.dyn_ltree[t * 2] = 0;
	for (t = 0; t < be; t++) e.dyn_dtree[t * 2] = 0;
	for (t = 0; t < xe; t++) e.bl_tree[t * 2] = 0;
	e.dyn_ltree[Ee * 2] = 1, e.opt_len = e.static_len = 0, e.sym_next = e.matches = 0;
}, et = (e) => {
	e.bi_valid > 8 ? qe(e, e.bi_buf) : e.bi_valid > 0 && (e.pending_buf[e.pending++] = e.bi_buf), e.bi_buf = 0, e.bi_valid = 0;
}, tt = (e, t, n, r) => {
	let i = t * 2, a = n * 2;
	return e[i] < e[a] || e[i] === e[a] && r[t] <= r[n];
}, nt = (e, t, n) => {
	let r = e.heap[n], i = n << 1;
	for (; i <= e.heap_len && (i < e.heap_len && tt(t, e.heap[i + 1], e.heap[i], e.depth) && i++, !tt(t, r, e.heap[i], e.depth));) e.heap[n] = e.heap[i], n = i, i <<= 1;
	e.heap[n] = r;
}, rt = (e, t, n) => {
	let r, i, a = 0, o, s;
	if (e.sym_next !== 0) do
		r = e.pending_buf[e.sym_buf + a++] & 255, r += (e.pending_buf[e.sym_buf + a++] & 255) << 8, i = e.pending_buf[e.sym_buf + a++], r === 0 ? A(e, i, t) : (o = Re[i], A(e, o + ve + 1, t), s = Ae[o], s !== 0 && (i -= ze[o], k(e, i, s)), r--, o = Ke(r), A(e, o, n), s = je[o], s !== 0 && (r -= Be[o], k(e, r, s)));
	while (a < e.sym_next);
	A(e, Ee, t);
}, it = (e, t) => {
	let n = t.dyn_tree, r = t.stat_desc.static_tree, i = t.stat_desc.has_stree, a = t.stat_desc.elems, o, s, c = -1, l;
	for (e.heap_len = 0, e.heap_max = Se, o = 0; o < a; o++) n[o * 2] === 0 ? n[o * 2 + 1] = 0 : (e.heap[++e.heap_len] = c = o, e.depth[o] = 0);
	for (; e.heap_len < 2;) l = e.heap[++e.heap_len] = c < 2 ? ++c : 0, n[l * 2] = 1, e.depth[l] = 0, e.opt_len--, i && (e.static_len -= r[l * 2 + 1]);
	for (t.max_code = c, o = e.heap_len >> 1; o >= 1; o--) nt(e, n, o);
	l = a;
	do
		o = e.heap[1], e.heap[1] = e.heap[e.heap_len--], nt(e, n, 1), s = e.heap[1], e.heap[--e.heap_max] = o, e.heap[--e.heap_max] = s, n[l * 2] = n[o * 2] + n[s * 2], e.depth[l] = (e.depth[o] >= e.depth[s] ? e.depth[o] : e.depth[s]) + 1, n[o * 2 + 1] = n[s * 2 + 1] = l, e.heap[1] = l++, nt(e, n, 1);
	while (e.heap_len >= 2);
	e.heap[--e.heap_max] = e.heap[1], Xe(e, t), Ze(n, c, e.bl_count);
}, at = (e, t, n) => {
	let r, i = -1, a, o = t[1], s = 0, c = 7, l = 4;
	for (o === 0 && (c = 138, l = 3), t[(n + 1) * 2 + 1] = 65535, r = 0; r <= n; r++) a = o, o = t[(r + 1) * 2 + 1], ++s < c && a === o || (s < l ? e.bl_tree[a * 2] += s : a === 0 ? s <= 10 ? e.bl_tree[Oe * 2]++ : e.bl_tree[ke * 2]++ : (a !== i && e.bl_tree[a * 2]++, e.bl_tree[De * 2]++), s = 0, i = a, o === 0 ? (c = 138, l = 3) : a === o ? (c = 6, l = 3) : (c = 7, l = 4));
}, ot = (e, t, n) => {
	let r, i = -1, a, o = t[1], s = 0, c = 7, l = 4;
	for (o === 0 && (c = 138, l = 3), r = 0; r <= n; r++) if (a = o, o = t[(r + 1) * 2 + 1], !(++s < c && a === o)) {
		if (s < l) do
			A(e, a, e.bl_tree);
		while (--s !== 0);
		else a === 0 ? s <= 10 ? (A(e, Oe, e.bl_tree), k(e, s - 3, 3)) : (A(e, ke, e.bl_tree), k(e, s - 11, 7)) : (a !== i && (A(e, a, e.bl_tree), s--), A(e, De, e.bl_tree), k(e, s - 3, 2));
		s = 0, i = a, o === 0 ? (c = 138, l = 3) : a === o ? (c = 6, l = 3) : (c = 7, l = 4);
	}
}, st = (e) => {
	let t;
	for (at(e, e.dyn_ltree, e.l_desc.max_code), at(e, e.dyn_dtree, e.d_desc.max_code), it(e, e.bl_desc), t = xe - 1; t >= 3 && e.bl_tree[Ne[t] * 2 + 1] === 0; t--);
	return e.opt_len += 3 * (t + 1) + 5 + 5 + 4, t;
}, ct = (e, t, n, r) => {
	let i;
	for (k(e, t - 257, 5), k(e, n - 1, 5), k(e, r - 4, 4), i = 0; i < r; i++) k(e, e.bl_tree[Ne[i] * 2 + 1], 3);
	ot(e, e.dyn_ltree, t - 1), ot(e, e.dyn_dtree, n - 1);
}, lt = (e) => {
	let t = 4093624447, n = 0;
	for (; n <= 31; n++, t >>>= 1) if (t & 1 && e.dyn_ltree[n * 2] !== 0) return 0;
	if (e.dyn_ltree[18] !== 0 || e.dyn_ltree[20] !== 0 || e.dyn_ltree[26] !== 0) return 1;
	for (n = 32; n < ve; n++) if (e.dyn_ltree[n * 2] !== 0) return 1;
	return 0;
}, ut = !1, dt = (e) => {
	ut ||= (Qe(), !0), e.l_desc = new Ge(e.dyn_ltree, He), e.d_desc = new Ge(e.dyn_dtree, Ue), e.bl_desc = new Ge(e.bl_tree, We), e.bi_buf = 0, e.bi_valid = 0, $e(e);
}, ft = (e, t, n, r) => {
	k(e, (fe << 1) + +!!r, 3), et(e), qe(e, n), qe(e, ~n), n && e.pending_buf.set(e.window.subarray(t, t + n), e.pending), e.pending += n;
}, pt = {
	_tr_init: dt,
	_tr_stored_block: ft,
	_tr_flush_block: (e, t, n, r) => {
		let i, a, o = 0;
		e.level > 0 ? (e.strm.data_type === 2 && (e.strm.data_type = lt(e)), it(e, e.l_desc), it(e, e.d_desc), o = st(e), i = e.opt_len + 3 + 7 >>> 3, a = e.static_len + 3 + 7 >>> 3, a <= i && (i = a)) : i = a = n + 5, n + 4 <= i && t !== -1 ? ft(e, t, n, r) : e.strategy === 4 || a === i ? (k(e, (pe << 1) + +!!r, 3), rt(e, Fe, Ie)) : (k(e, (me << 1) + +!!r, 3), ct(e, e.l_desc.max_code + 1, e.d_desc.max_code + 1, o + 1), rt(e, e.dyn_ltree, e.dyn_dtree)), $e(e), r && et(e);
	},
	_tr_tally: (e, t, n) => (e.pending_buf[e.sym_buf + e.sym_next++] = t, e.pending_buf[e.sym_buf + e.sym_next++] = t >> 8, e.pending_buf[e.sym_buf + e.sym_next++] = n, t === 0 ? e.dyn_ltree[n * 2]++ : (e.matches++, t--, e.dyn_ltree[(Re[n] + ve + 1) * 2]++, e.dyn_dtree[Ke(t) * 2]++), e.sym_next === e.sym_end),
	_tr_align: (e) => {
		k(e, pe << 1, 3), A(e, Ee, Fe), Ye(e);
	}
}, mt = (e, t, n, r) => {
	let i = e & 65535, a = e >>> 16 & 65535, o = 0;
	for (; n !== 0;) {
		o = n > 2e3 ? 2e3 : n, n -= o;
		do
			i = i + t[r++] | 0, a = a + i | 0;
		while (--o);
		i %= 65521, a %= 65521;
	}
	return i | a << 16;
}, ht = new Uint32Array((() => {
	let e, t = [];
	for (var n = 0; n < 256; n++) {
		e = n;
		for (var r = 0; r < 8; r++) e = e & 1 ? 3988292384 ^ e >>> 1 : e >>> 1;
		t[n] = e;
	}
	return t;
})()), j = (e, t, n, r) => {
	let i = ht, a = r + n;
	e ^= -1;
	for (let n = r; n < a; n++) e = e >>> 8 ^ i[(e ^ t[n]) & 255];
	return e ^ -1;
}, gt = {
	2: "need dictionary",
	1: "stream end",
	0: "",
	"-1": "file error",
	"-2": "stream error",
	"-3": "data error",
	"-4": "insufficient memory",
	"-5": "buffer error",
	"-6": "incompatible version"
}, _t = {
	Z_NO_FLUSH: 0,
	Z_PARTIAL_FLUSH: 1,
	Z_SYNC_FLUSH: 2,
	Z_FULL_FLUSH: 3,
	Z_FINISH: 4,
	Z_BLOCK: 5,
	Z_TREES: 6,
	Z_OK: 0,
	Z_STREAM_END: 1,
	Z_NEED_DICT: 2,
	Z_ERRNO: -1,
	Z_STREAM_ERROR: -2,
	Z_DATA_ERROR: -3,
	Z_MEM_ERROR: -4,
	Z_BUF_ERROR: -5,
	Z_NO_COMPRESSION: 0,
	Z_BEST_SPEED: 1,
	Z_BEST_COMPRESSION: 9,
	Z_DEFAULT_COMPRESSION: -1,
	Z_FILTERED: 1,
	Z_HUFFMAN_ONLY: 2,
	Z_RLE: 3,
	Z_FIXED: 4,
	Z_DEFAULT_STRATEGY: 0,
	Z_BINARY: 0,
	Z_TEXT: 1,
	Z_UNKNOWN: 2,
	Z_DEFLATED: 8
}, { _tr_init: vt, _tr_stored_block: yt, _tr_flush_block: bt, _tr_tally: xt, _tr_align: St } = pt, { Z_NO_FLUSH: Ct, Z_PARTIAL_FLUSH: wt, Z_FULL_FLUSH: Tt, Z_FINISH: M, Z_BLOCK: Et, Z_OK: N, Z_STREAM_END: Dt, Z_STREAM_ERROR: P, Z_DATA_ERROR: Ot, Z_BUF_ERROR: kt, Z_DEFAULT_COMPRESSION: At, Z_FILTERED: jt, Z_HUFFMAN_ONLY: Mt, Z_RLE: Nt, Z_FIXED: Pt, Z_DEFAULT_STRATEGY: Ft, Z_UNKNOWN: It, Z_DEFLATED: Lt } = _t, Rt = 9, zt = 15, Bt = 8, Vt = 286, Ht = 30, Ut = 19, Wt = 2 * Vt + 1, Gt = 15, F = 3, Kt = 258, I = Kt + F + 1, qt = 32, Jt = 42, Yt = 57, Xt = 69, Zt = 73, Qt = 91, $t = 103, en = 113, tn = 666, L = 1, nn = 2, rn = 3, an = 4, on = 3, sn = (e, t) => (e.msg = gt[t], t), cn = (e) => e * 2 - (e > 4 ? 9 : 0), ln = (e) => {
	let t = e.length;
	for (; --t >= 0;) e[t] = 0;
}, un = (e) => {
	let t, n, r, i = e.w_size;
	t = e.hash_size, r = t;
	do
		n = e.head[--r], e.head[r] = n >= i ? n - i : 0;
	while (--t);
	t = i, r = t;
	do
		n = e.prev[--r], e.prev[r] = n >= i ? n - i : 0;
	while (--t);
}, dn = (e, t, n) => (t << e.hash_shift ^ n) & e.hash_mask, fn = (e, t) => {
	let n;
	if (e.legacy_hash) n = e.ins_h = dn(e, e.ins_h, e.window[t + F - 1]);
	else {
		let r = e.window, i = r[t] | r[t + 1] << 8 | r[t + 2] << 16 | r[t + 3] << 24;
		n = e.ins_h = Math.imul(i, 66521) + 66521 >>> 16 & e.hash_mask;
	}
	let r = e.prev[t & e.w_mask] = e.head[n];
	return e.head[n] = t, r;
}, R = (e) => {
	let t = e.state, n = t.pending;
	n > e.avail_out && (n = e.avail_out), n !== 0 && (e.output.set(t.pending_buf.subarray(t.pending_out, t.pending_out + n), e.next_out), e.next_out += n, t.pending_out += n, e.total_out += n, e.avail_out -= n, t.pending -= n, t.pending === 0 && (t.pending_out = 0));
}, z = (e, t) => {
	bt(e, e.block_start >= 0 ? e.block_start : -1, e.strstart - e.block_start, t), e.block_start = e.strstart, R(e.strm);
}, B = (e, t) => {
	e.pending_buf[e.pending++] = t;
}, pn = (e, t) => {
	e.pending_buf[e.pending++] = t >>> 8 & 255, e.pending_buf[e.pending++] = t & 255;
}, mn = (e, t, n, r) => {
	let i = e.avail_in;
	return i > r && (i = r), i === 0 ? 0 : (e.avail_in -= i, t.set(e.input.subarray(e.next_in, e.next_in + i), n), e.state.wrap === 1 ? e.adler = mt(e.adler, t, i, n) : e.state.wrap === 2 && (e.adler = j(e.adler, t, i, n)), e.next_in += i, e.total_in += i, i);
}, hn = (e, t) => {
	let { max_chain_length: n, strstart: r } = e, i, a, { prev_length: o, nice_match: s } = e, c = e.strstart > e.w_size - I ? e.strstart - (e.w_size - I) : 0, { window: l, w_mask: u, prev: d } = e, f = e.strstart + Kt, p = l[r + o - 1], m = l[r + o];
	e.prev_length >= e.good_match && (n >>= 2), s > e.lookahead && (s = e.lookahead);
	do
		if (i = t, l[i + o] === m && l[i + o - 1] === p && l[i] === l[r] && l[++i] === l[r + 1]) {
			r += 2, i++;
			do;
			while (l[++r] === l[++i] && l[++r] === l[++i] && l[++r] === l[++i] && l[++r] === l[++i] && l[++r] === l[++i] && l[++r] === l[++i] && l[++r] === l[++i] && l[++r] === l[++i] && r < f);
			if (a = Kt - (f - r), r = f - Kt, a > o) {
				if (e.match_start = t, o = a, a >= s) break;
				p = l[r + o - 1], m = l[r + o];
			}
		}
	while ((t = d[t & u]) > c && --n !== 0);
	return o <= e.lookahead ? o : e.lookahead;
}, gn = (e) => {
	let t = e.w_size, n, r, i;
	do {
		if (r = e.window_size - e.lookahead - e.strstart, e.strstart >= t + (t - I) && (e.window.set(e.window.subarray(t, t + t - r), 0), e.match_start -= t, e.strstart -= t, e.block_start -= t, e.insert > e.strstart && (e.insert = e.strstart), un(e), r += t), e.strm.avail_in === 0) break;
		if (n = mn(e.strm, e.window, e.strstart + e.lookahead, r), e.lookahead += n, !e.legacy_hash) {
			if (e.lookahead + e.insert > F) for (i = e.strstart - e.insert; e.insert && (fn(e, i), i++, e.insert--, !(e.lookahead + e.insert <= F)););
		} else if (e.lookahead + e.insert >= F) for (i = e.strstart - e.insert, e.ins_h = e.window[i], e.ins_h = dn(e, e.ins_h, e.window[i + 1]); e.insert && (fn(e, i), i++, e.insert--, !(e.lookahead + e.insert < F)););
	} while (e.lookahead < I && e.strm.avail_in !== 0);
}, _n = (e, t) => {
	let n = e.pending_buf_size - 5 > e.w_size ? e.w_size : e.pending_buf_size - 5, r, i, a, o = 0, s = e.strm.avail_in;
	do {
		if (r = 65535, a = e.bi_valid + 42 >> 3, e.strm.avail_out < a || (a = e.strm.avail_out - a, i = e.strstart - e.block_start, r > i + e.strm.avail_in && (r = i + e.strm.avail_in), r > a && (r = a), r < n && (r === 0 && t !== M || t === Ct || r !== i + e.strm.avail_in))) break;
		o = +(t === M && r === i + e.strm.avail_in), yt(e, 0, 0, o), e.pending_buf[e.pending - 4] = r, e.pending_buf[e.pending - 3] = r >> 8, e.pending_buf[e.pending - 2] = ~r, e.pending_buf[e.pending - 1] = ~r >> 8, R(e.strm), i && (i > r && (i = r), e.strm.output.set(e.window.subarray(e.block_start, e.block_start + i), e.strm.next_out), e.strm.next_out += i, e.strm.avail_out -= i, e.strm.total_out += i, e.block_start += i, r -= i), r && (mn(e.strm, e.strm.output, e.strm.next_out, r), e.strm.next_out += r, e.strm.avail_out -= r, e.strm.total_out += r);
	} while (o === 0);
	return s -= e.strm.avail_in, s && (s >= e.w_size ? (e.matches = 2, e.window.set(e.strm.input.subarray(e.strm.next_in - e.w_size, e.strm.next_in), 0), e.strstart = e.w_size, e.insert = e.strstart) : (e.window_size - e.strstart <= s && (e.strstart -= e.w_size, e.window.set(e.window.subarray(e.w_size, e.w_size + e.strstart), 0), e.matches < 2 && e.matches++, e.insert > e.strstart && (e.insert = e.strstart)), e.window.set(e.strm.input.subarray(e.strm.next_in - s, e.strm.next_in), e.strstart), e.strstart += s, e.insert += s > e.w_size - e.insert ? e.w_size - e.insert : s), e.block_start = e.strstart), e.high_water < e.strstart && (e.high_water = e.strstart), o ? an : t !== Ct && t !== M && e.strm.avail_in === 0 && e.strstart === e.block_start ? nn : (a = e.window_size - e.strstart, e.strm.avail_in > a && e.block_start >= e.w_size && (e.block_start -= e.w_size, e.strstart -= e.w_size, e.window.set(e.window.subarray(e.w_size, e.w_size + e.strstart), 0), e.matches < 2 && e.matches++, a += e.w_size, e.insert > e.strstart && (e.insert = e.strstart)), a > e.strm.avail_in && (a = e.strm.avail_in), a && (mn(e.strm, e.window, e.strstart, a), e.strstart += a, e.insert += a > e.w_size - e.insert ? e.w_size - e.insert : a), e.high_water < e.strstart && (e.high_water = e.strstart), a = e.bi_valid + 42 >> 3, a = e.pending_buf_size - a > 65535 ? 65535 : e.pending_buf_size - a, n = a > e.w_size ? e.w_size : a, i = e.strstart - e.block_start, (i >= n || (i || t === M) && t !== Ct && e.strm.avail_in === 0 && i <= a) && (r = i > a ? a : i, o = +(t === M && e.strm.avail_in === 0 && r === i), yt(e, e.block_start, r, o), e.block_start += r, R(e.strm)), o ? rn : L);
}, vn = (e, t) => {
	let n, r;
	for (;;) {
		if (e.lookahead < I) {
			if (gn(e), e.lookahead < I && t === Ct) return L;
			if (e.lookahead === 0) break;
		}
		if (n = 0, e.lookahead >= F && (n = fn(e, e.strstart)), n !== 0 && e.strstart - n <= e.w_size - I && (e.match_length = hn(e, n)), e.match_length >= F) {
			if (r = xt(e, e.strstart - e.match_start, e.match_length - F), e.lookahead -= e.match_length, e.match_length <= e.max_lazy_match && e.lookahead >= F) {
				e.match_length--;
				do
					e.strstart++, n = fn(e, e.strstart);
				while (--e.match_length !== 0);
				e.strstart++;
			} else e.strstart += e.match_length, e.match_length = 0, e.legacy_hash && (e.ins_h = e.window[e.strstart], e.ins_h = dn(e, e.ins_h, e.window[e.strstart + 1]));
		} else r = xt(e, 0, e.window[e.strstart]), e.lookahead--, e.strstart++;
		if (r && (z(e, !1), e.strm.avail_out === 0)) return L;
	}
	return e.insert = e.strstart < F - 1 ? e.strstart : F - 1, t === M ? (z(e, !0), e.strm.avail_out === 0 ? rn : an) : e.sym_next && (z(e, !1), e.strm.avail_out === 0) ? L : nn;
}, yn = (e, t) => {
	let n, r, i;
	for (;;) {
		if (e.lookahead < I) {
			if (gn(e), e.lookahead < I && t === Ct) return L;
			if (e.lookahead === 0) break;
		}
		if (n = 0, e.lookahead >= F && (n = fn(e, e.strstart)), e.prev_length = e.match_length, e.prev_match = e.match_start, e.match_length = F - 1, n !== 0 && e.prev_length < e.max_lazy_match && e.strstart - n <= e.w_size - I && (e.match_length = hn(e, n), e.match_length <= 5 && (e.strategy === jt || e.match_length === F && e.strstart - e.match_start > 4096) && (e.match_length = F - 1)), e.prev_length >= F && e.match_length <= e.prev_length) {
			i = e.strstart + e.lookahead - F, r = xt(e, e.strstart - 1 - e.prev_match, e.prev_length - F), e.lookahead -= e.prev_length - 1, e.prev_length -= 2;
			do
				++e.strstart <= i && (n = fn(e, e.strstart));
			while (--e.prev_length !== 0);
			if (e.match_available = 0, e.match_length = F - 1, e.strstart++, r && (z(e, !1), e.strm.avail_out === 0)) return L;
		} else if (e.match_available) {
			if (r = xt(e, 0, e.window[e.strstart - 1]), r && z(e, !1), e.strstart++, e.lookahead--, e.strm.avail_out === 0) return L;
		} else e.match_available = 1, e.strstart++, e.lookahead--;
	}
	return e.match_available &&= (r = xt(e, 0, e.window[e.strstart - 1]), 0), e.insert = e.strstart < F - 1 ? e.strstart : F - 1, t === M ? (z(e, !0), e.strm.avail_out === 0 ? rn : an) : e.sym_next && (z(e, !1), e.strm.avail_out === 0) ? L : nn;
}, bn = (e, t) => {
	let n, r, i, a, o = e.window;
	for (;;) {
		if (e.lookahead <= Kt) {
			if (gn(e), e.lookahead <= Kt && t === Ct) return L;
			if (e.lookahead === 0) break;
		}
		if (e.match_length = 0, e.lookahead >= F && e.strstart > 0 && (i = e.strstart - 1, r = o[i], r === o[++i] && r === o[++i] && r === o[++i])) {
			a = e.strstart + Kt;
			do;
			while (r === o[++i] && r === o[++i] && r === o[++i] && r === o[++i] && r === o[++i] && r === o[++i] && r === o[++i] && r === o[++i] && i < a);
			e.match_length = Kt - (a - i), e.match_length > e.lookahead && (e.match_length = e.lookahead);
		}
		if (e.match_length >= F ? (n = xt(e, 1, e.match_length - F), e.lookahead -= e.match_length, e.strstart += e.match_length, e.match_length = 0) : (n = xt(e, 0, e.window[e.strstart]), e.lookahead--, e.strstart++), n && (z(e, !1), e.strm.avail_out === 0)) return L;
	}
	return e.insert = 0, t === M ? (z(e, !0), e.strm.avail_out === 0 ? rn : an) : e.sym_next && (z(e, !1), e.strm.avail_out === 0) ? L : nn;
}, xn = (e, t) => {
	let n;
	for (;;) {
		if (e.lookahead === 0 && (gn(e), e.lookahead === 0)) {
			if (t === Ct) return L;
			break;
		}
		if (e.match_length = 0, n = xt(e, 0, e.window[e.strstart]), e.lookahead--, e.strstart++, n && (z(e, !1), e.strm.avail_out === 0)) return L;
	}
	return e.insert = 0, t === M ? (z(e, !0), e.strm.avail_out === 0 ? rn : an) : e.sym_next && (z(e, !1), e.strm.avail_out === 0) ? L : nn;
};
function V(e, t, n, r, i) {
	this.good_length = e, this.max_lazy = t, this.nice_length = n, this.max_chain = r, this.func = i;
}
var Sn = [
	new V(0, 0, 0, 0, _n),
	new V(4, 4, 8, 4, vn),
	new V(4, 5, 16, 8, vn),
	new V(4, 6, 32, 32, vn),
	new V(4, 4, 16, 16, yn),
	new V(8, 16, 32, 32, yn),
	new V(8, 16, 128, 128, yn),
	new V(8, 32, 128, 256, yn),
	new V(32, 128, 258, 1024, yn),
	new V(32, 258, 258, 4096, yn)
], Cn = (e) => {
	e.window_size = 2 * e.w_size, ln(e.head), e.max_lazy_match = Sn[e.level].max_lazy, e.good_match = Sn[e.level].good_length, e.nice_match = Sn[e.level].nice_length, e.max_chain_length = Sn[e.level].max_chain, e.strstart = 0, e.block_start = 0, e.lookahead = 0, e.insert = 0, e.match_length = e.prev_length = F - 1, e.match_available = 0, e.ins_h = 0;
};
function wn() {
	this.strm = null, this.status = 0, this.pending_buf = null, this.pending_buf_size = 0, this.pending_out = 0, this.pending = 0, this.wrap = 0, this.gzhead = null, this.gzindex = 0, this.method = Lt, this.last_flush = -1, this.w_size = 0, this.w_bits = 0, this.w_mask = 0, this.window = null, this.window_size = 0, this.prev = null, this.head = null, this.ins_h = 0, this.legacy_hash = 0, this.hash_size = 0, this.hash_bits = 0, this.hash_mask = 0, this.hash_shift = 0, this.block_start = 0, this.match_length = 0, this.prev_match = 0, this.match_available = 0, this.strstart = 0, this.match_start = 0, this.lookahead = 0, this.prev_length = 0, this.max_chain_length = 0, this.max_lazy_match = 0, this.level = 0, this.strategy = 0, this.good_match = 0, this.nice_match = 0, this.dyn_ltree = new Uint16Array(Wt * 2), this.dyn_dtree = new Uint16Array((2 * Ht + 1) * 2), this.bl_tree = new Uint16Array((2 * Ut + 1) * 2), ln(this.dyn_ltree), ln(this.dyn_dtree), ln(this.bl_tree), this.l_desc = null, this.d_desc = null, this.bl_desc = null, this.bl_count = new Uint16Array(Gt + 1), this.heap = new Uint16Array(2 * Vt + 1), ln(this.heap), this.heap_len = 0, this.heap_max = 0, this.depth = new Uint16Array(2 * Vt + 1), ln(this.depth), this.sym_buf = 0, this.lit_bufsize = 0, this.sym_next = 0, this.sym_end = 0, this.opt_len = 0, this.static_len = 0, this.matches = 0, this.insert = 0, this.bi_buf = 0, this.bi_valid = 0;
}
var Tn = (e) => {
	if (!e) return 1;
	let t = e.state;
	return +(!t || t.strm !== e || t.status !== Jt && t.status !== Yt && t.status !== Xt && t.status !== Zt && t.status !== Qt && t.status !== $t && t.status !== en && t.status !== tn);
}, En = (e) => {
	if (Tn(e)) return sn(e, P);
	e.total_in = e.total_out = 0, e.data_type = It;
	let t = e.state;
	return t.pending = 0, t.pending_out = 0, t.wrap < 0 && (t.wrap = -t.wrap), t.status = t.wrap === 2 ? Yt : t.wrap ? Jt : en, e.adler = t.wrap === 2 ? 0 : 1, t.last_flush = -2, vt(t), N;
}, Dn = (e) => {
	let t = En(e);
	return t === N && Cn(e.state), t;
}, On = (e, t) => Tn(e) || e.state.wrap !== 2 ? P : (e.state.gzhead = t, N), kn = (e, t, n, r, i, a, o) => {
	if (!e) return P;
	let s = 1;
	if (t === At && (t = 6), r < 0 ? (s = 0, r = -r) : r > 15 && (s = 2, r -= 16), i < 1 || i > Rt || n !== Lt || r < 8 || r > 15 || t < 0 || t > 9 || a < 0 || a > Pt || r === 8 && s !== 1) return sn(e, P);
	r === 8 && (r = 9);
	let c = new wn();
	return e.state = c, c.strm = e, c.status = Jt, c.wrap = s, c.gzhead = null, c.w_bits = r, c.w_size = 1 << c.w_bits, c.w_mask = c.w_size - 1, c.legacy_hash = +!!o, c.hash_bits = i + 7, !c.legacy_hash && c.hash_bits < 15 && (c.hash_bits = 15), c.hash_size = 1 << c.hash_bits, c.hash_mask = c.hash_size - 1, c.hash_shift = ~~((c.hash_bits + F - 1) / F), c.window = new Uint8Array(c.w_size * 2), c.head = new Uint16Array(c.hash_size), c.prev = new Uint16Array(c.w_size), c.lit_bufsize = 1 << i + 6, c.pending_buf_size = c.lit_bufsize * 4, c.pending_buf = new Uint8Array(c.pending_buf_size), c.sym_buf = c.lit_bufsize, c.sym_end = (c.lit_bufsize - 1) * 3, c.level = t, c.strategy = a, c.method = n, Dn(e);
}, An = {
	deflateInit: (e, t) => kn(e, t, Lt, zt, Bt, Ft),
	deflateInit2: kn,
	deflateReset: Dn,
	deflateResetKeep: En,
	deflateSetHeader: On,
	deflate: (e, t) => {
		if (Tn(e) || t > Et || t < 0) return e ? sn(e, P) : P;
		let n = e.state;
		if (!e.output || e.avail_in !== 0 && !e.input || n.status === tn && t !== M) return sn(e, e.avail_out === 0 ? kt : P);
		let r = n.last_flush;
		if (n.last_flush = t, n.pending !== 0) {
			if (R(e), e.avail_out === 0) return n.last_flush = -1, N;
		} else if (e.avail_in === 0 && cn(t) <= cn(r) && t !== M) return sn(e, kt);
		if (n.status === tn && e.avail_in !== 0) return sn(e, kt);
		if (n.status === Jt && n.wrap === 0 && (n.status = en), n.status === Jt) {
			let t = Lt + (n.w_bits - 8 << 4) << 8, r = -1;
			if (r = n.strategy >= Mt || n.level < 2 ? 0 : n.level < 6 ? 1 : n.level === 6 ? 2 : 3, t |= r << 6, n.strstart !== 0 && (t |= qt), t += 31 - t % 31, pn(n, t), n.strstart !== 0 && (pn(n, e.adler >>> 16), pn(n, e.adler & 65535)), e.adler = 1, n.status = en, R(e), n.pending !== 0) return n.last_flush = -1, N;
		}
		if (n.status === Yt) {
			if (e.adler = 0, B(n, 31), B(n, 139), B(n, 8), !n.gzhead) {
				if (B(n, 0), B(n, 0), B(n, 0), B(n, 0), B(n, 0), B(n, n.level === 9 ? 2 : n.strategy >= Mt || n.level < 2 ? 4 : 0), B(n, on), n.status = en, R(e), n.pending !== 0) return n.last_flush = -1, N;
			} else B(n, +!!n.gzhead.text + (n.gzhead.hcrc ? 2 : 0) + (n.gzhead.extra ? 4 : 0) + (n.gzhead.name ? 8 : 0) + (n.gzhead.comment ? 16 : 0)), B(n, n.gzhead.time & 255), B(n, n.gzhead.time >> 8 & 255), B(n, n.gzhead.time >> 16 & 255), B(n, n.gzhead.time >> 24 & 255), B(n, n.level === 9 ? 2 : n.strategy >= Mt || n.level < 2 ? 4 : 0), B(n, n.gzhead.os & 255), n.gzhead.extra && n.gzhead.extra.length && (B(n, n.gzhead.extra.length & 255), B(n, n.gzhead.extra.length >> 8 & 255)), n.gzhead.hcrc && (e.adler = j(e.adler, n.pending_buf, n.pending, 0)), n.gzindex = 0, n.status = Xt;
		}
		if (n.status === Xt) {
			if (n.gzhead.extra) {
				let t = n.pending, r = (n.gzhead.extra.length & 65535) - n.gzindex;
				for (; n.pending + r > n.pending_buf_size;) {
					let i = n.pending_buf_size - n.pending;
					if (n.pending_buf.set(n.gzhead.extra.subarray(n.gzindex, n.gzindex + i), n.pending), n.pending = n.pending_buf_size, n.gzhead.hcrc && n.pending > t && (e.adler = j(e.adler, n.pending_buf, n.pending - t, t)), n.gzindex += i, R(e), n.pending !== 0) return n.last_flush = -1, N;
					t = 0, r -= i;
				}
				let i = new Uint8Array(n.gzhead.extra);
				n.pending_buf.set(i.subarray(n.gzindex, n.gzindex + r), n.pending), n.pending += r, n.gzhead.hcrc && n.pending > t && (e.adler = j(e.adler, n.pending_buf, n.pending - t, t)), n.gzindex = 0;
			}
			n.status = Zt;
		}
		if (n.status === Zt) {
			if (n.gzhead.name) {
				let t = n.pending, r;
				do {
					if (n.pending === n.pending_buf_size) {
						if (n.gzhead.hcrc && n.pending > t && (e.adler = j(e.adler, n.pending_buf, n.pending - t, t)), R(e), n.pending !== 0) return n.last_flush = -1, N;
						t = 0;
					}
					r = n.gzindex < n.gzhead.name.length ? n.gzhead.name.charCodeAt(n.gzindex++) & 255 : 0, B(n, r);
				} while (r !== 0);
				n.gzhead.hcrc && n.pending > t && (e.adler = j(e.adler, n.pending_buf, n.pending - t, t)), n.gzindex = 0;
			}
			n.status = Qt;
		}
		if (n.status === Qt) {
			if (n.gzhead.comment) {
				let t = n.pending, r;
				do {
					if (n.pending === n.pending_buf_size) {
						if (n.gzhead.hcrc && n.pending > t && (e.adler = j(e.adler, n.pending_buf, n.pending - t, t)), R(e), n.pending !== 0) return n.last_flush = -1, N;
						t = 0;
					}
					r = n.gzindex < n.gzhead.comment.length ? n.gzhead.comment.charCodeAt(n.gzindex++) & 255 : 0, B(n, r);
				} while (r !== 0);
				n.gzhead.hcrc && n.pending > t && (e.adler = j(e.adler, n.pending_buf, n.pending - t, t));
			}
			n.status = $t;
		}
		if (n.status === $t) {
			if (n.gzhead.hcrc) {
				if (n.pending + 2 > n.pending_buf_size && (R(e), n.pending !== 0)) return n.last_flush = -1, N;
				B(n, e.adler & 255), B(n, e.adler >> 8 & 255), e.adler = 0;
			}
			if (n.status = en, R(e), n.pending !== 0) return n.last_flush = -1, N;
		}
		if (e.avail_in !== 0 || n.lookahead !== 0 || t !== Ct && n.status !== tn) {
			let r = n.level === 0 ? _n(n, t) : n.strategy === Mt ? xn(n, t) : n.strategy === Nt ? bn(n, t) : Sn[n.level].func(n, t);
			if ((r === rn || r === an) && (n.status = tn), r === L || r === rn) return e.avail_out === 0 && (n.last_flush = -1), N;
			if (r === nn && (t === wt ? St(n) : t !== Et && (yt(n, 0, 0, !1), t === Tt && (ln(n.head), n.lookahead === 0 && (n.strstart = 0, n.block_start = 0, n.insert = 0))), R(e), e.avail_out === 0)) return n.last_flush = -1, N;
		}
		return t === M ? n.wrap <= 0 ? Dt : (n.wrap === 2 ? (B(n, e.adler & 255), B(n, e.adler >> 8 & 255), B(n, e.adler >> 16 & 255), B(n, e.adler >> 24 & 255), B(n, e.total_in & 255), B(n, e.total_in >> 8 & 255), B(n, e.total_in >> 16 & 255), B(n, e.total_in >> 24 & 255)) : (pn(n, e.adler >>> 16), pn(n, e.adler & 65535)), R(e), n.wrap > 0 && (n.wrap = -n.wrap), n.pending === 0 ? Dt : N) : N;
	},
	deflateEnd: (e) => {
		if (Tn(e)) return P;
		let t = e.state.status;
		return e.state = null, t === en ? sn(e, Ot) : N;
	},
	deflateSetDictionary: (e, t) => {
		let n = t.length;
		if (Tn(e)) return P;
		let r = e.state, i = r.wrap;
		if (i === 2 || i === 1 && r.status !== Jt || r.lookahead) return P;
		if (i === 1 && (e.adler = mt(e.adler, t, n, 0)), r.wrap = 0, n >= r.w_size) {
			i === 0 && (ln(r.head), r.strstart = 0, r.block_start = 0, r.insert = 0);
			let e = new Uint8Array(r.w_size);
			e.set(t.subarray(n - r.w_size, n), 0), t = e, n = r.w_size;
		}
		let { avail_in: a, next_in: o, input: s } = e;
		for (e.avail_in = n, e.next_in = 0, e.input = t, gn(r); r.lookahead >= F;) {
			let e = r.strstart, t = r.lookahead - (F - 1);
			do
				fn(r, e), e++;
			while (--t);
			r.strstart = e, r.lookahead = F - 1, gn(r);
		}
		return r.strstart += r.lookahead, r.block_start = r.strstart, r.insert = r.lookahead, r.lookahead = 0, r.match_length = r.prev_length = F - 1, r.match_available = 0, e.next_in = o, e.input = s, e.avail_in = a, r.wrap = i, N;
	},
	deflateInfo: "pako deflate (from Nodeca project)"
}, jn = (e, t) => Object.prototype.hasOwnProperty.call(e, t), Mn = {
	assign: function(e) {
		let t = Array.prototype.slice.call(arguments, 1);
		for (; t.length;) {
			let n = t.shift();
			if (n) {
				if (typeof n != "object") throw TypeError(n + "must be non-object");
				for (let t in n) jn(n, t) && (e[t] = n[t]);
			}
		}
		return e;
	},
	flattenChunks: (e) => {
		let t = 0;
		for (let n = 0, r = e.length; n < r; n++) t += e[n].length;
		let n = new Uint8Array(t);
		for (let t = 0, r = 0, i = e.length; t < i; t++) {
			let i = e[t];
			n.set(i, r), r += i.length;
		}
		return n;
	}
}, Nn = !0;
try {
	String.fromCharCode.apply(null, /* @__PURE__ */ new Uint8Array(1));
} catch {
	Nn = !1;
}
var Pn = /* @__PURE__ */ new Uint8Array(256);
for (let e = 0; e < 256; e++) Pn[e] = e >= 252 ? 6 : e >= 248 ? 5 : e >= 240 ? 4 : e >= 224 ? 3 : e >= 192 ? 2 : 1;
Pn[254] = Pn[255] = 1;
var Fn = (e) => {
	if (typeof TextEncoder == "function" && TextEncoder.prototype.encode) return new TextEncoder().encode(e);
	let t, n, r, i, a, o = e.length, s = 0;
	for (i = 0; i < o; i++) n = e.charCodeAt(i), (n & 64512) == 55296 && i + 1 < o && (r = e.charCodeAt(i + 1), (r & 64512) == 56320 && (n = 65536 + (n - 55296 << 10) + (r - 56320), i++)), s += n < 128 ? 1 : n < 2048 ? 2 : n < 65536 ? 3 : 4;
	for (t = new Uint8Array(s), a = 0, i = 0; a < s; i++) n = e.charCodeAt(i), (n & 64512) == 55296 && i + 1 < o && (r = e.charCodeAt(i + 1), (r & 64512) == 56320 && (n = 65536 + (n - 55296 << 10) + (r - 56320), i++)), n < 128 ? t[a++] = n : n < 2048 ? (t[a++] = 192 | n >>> 6, t[a++] = 128 | n & 63) : n < 65536 ? (t[a++] = 224 | n >>> 12, t[a++] = 128 | n >>> 6 & 63, t[a++] = 128 | n & 63) : (t[a++] = 240 | n >>> 18, t[a++] = 128 | n >>> 12 & 63, t[a++] = 128 | n >>> 6 & 63, t[a++] = 128 | n & 63);
	return t;
}, In = (e, t) => {
	if (t < 65534 && e.subarray && Nn) return String.fromCharCode.apply(null, e.length === t ? e : e.subarray(0, t));
	let n = "";
	for (let r = 0; r < t; r++) n += String.fromCharCode(e[r]);
	return n;
}, Ln = {
	string2buf: Fn,
	buf2string: (e, t) => {
		let n = t || e.length;
		if (typeof TextDecoder == "function" && TextDecoder.prototype.decode) return new TextDecoder().decode(e.subarray(0, t));
		let r, i, a = Array(n * 2);
		for (i = 0, r = 0; r < n;) {
			let t = e[r++];
			if (t < 128) {
				a[i++] = t;
				continue;
			}
			let o = Pn[t];
			if (o > 4) a[i++] = 65533, r += o - 1;
			else {
				for (t &= o === 2 ? 31 : o === 3 ? 15 : 7; o > 1 && r < n;) t = t << 6 | e[r++] & 63, o--;
				o > 1 ? a[i++] = 65533 : t < 65536 ? a[i++] = t : (t -= 65536, a[i++] = 55296 | t >> 10 & 1023, a[i++] = 56320 | t & 1023);
			}
		}
		return In(a, i);
	},
	utf8border: (e, t) => {
		t ||= e.length, t > e.length && (t = e.length);
		let n = t - 1;
		for (; n >= 0 && (e[n] & 192) == 128;) n--;
		return n < 0 || n === 0 ? t : n + Pn[e[n]] > t ? n : t;
	}
};
function Rn() {
	this.input = null, this.next_in = 0, this.avail_in = 0, this.total_in = 0, this.output = null, this.next_out = 0, this.avail_out = 0, this.total_out = 0, this.msg = "", this.state = null, this.data_type = 2, this.adler = 0;
}
var zn = Rn, Bn = Object.prototype.toString, { Z_NO_FLUSH: Vn, Z_SYNC_FLUSH: Hn, Z_FULL_FLUSH: Un, Z_FINISH: Wn, Z_OK: Gn, Z_STREAM_END: Kn, Z_DEFAULT_COMPRESSION: qn, Z_DEFAULT_STRATEGY: Jn, Z_DEFLATED: Yn } = _t, Xn = {
	level: qn,
	method: Yn,
	chunkSize: 16384,
	windowBits: 15,
	memLevel: 8,
	strategy: Jn,
	legacyHash: !0
};
function Zn(e) {
	this.options = Mn.assign({}, Xn, e || {});
	let t = this.options;
	t.raw && t.windowBits > 0 ? t.windowBits = -t.windowBits : t.gzip && t.windowBits > 0 && t.windowBits < 16 && (t.windowBits += 16), this.err = 0, this.msg = "", this.ended = !1, this.chunks = [], this.strm = new zn(), this.strm.avail_out = 0;
	let n = An.deflateInit2(this.strm, t.level, t.method, t.windowBits, t.memLevel, t.strategy, t.legacyHash);
	if (n !== Gn) throw Error(gt[n]);
	if (t.header && An.deflateSetHeader(this.strm, t.header), t.dictionary) {
		let e;
		if (e = typeof t.dictionary == "string" ? Ln.string2buf(t.dictionary) : Bn.call(t.dictionary) === "[object ArrayBuffer]" ? new Uint8Array(t.dictionary) : t.dictionary, n = An.deflateSetDictionary(this.strm, e), n !== Gn) throw Error(gt[n]);
		this._dict_set = !0;
	}
}
Zn.prototype.push = function(e, t) {
	let n = this.strm, r = this.options.chunkSize, i, a;
	if (this.ended) return !1;
	for (a = t === ~~t ? t : t === !0 ? Wn : Vn, n.input = typeof e == "string" ? Ln.string2buf(e) : Bn.call(e) === "[object ArrayBuffer]" ? new Uint8Array(e) : e, n.next_in = 0, n.avail_in = n.input.length;;) if (n.avail_out === 0 && (n.output = new Uint8Array(r), n.next_out = 0, n.avail_out = r), (a === Hn || a === Un) && n.avail_out <= 6) this.onData(n.output.subarray(0, n.next_out)), n.avail_out = 0;
	else {
		if (i = An.deflate(n, a), i === Kn) return n.next_out > 0 && this.onData(n.output.subarray(0, n.next_out)), i = An.deflateEnd(this.strm), this.onEnd(i), this.ended = !0, i === Gn;
		if (n.avail_out === 0) this.onData(n.output);
		else if (a > 0 && n.next_out > 0) this.onData(n.output.subarray(0, n.next_out)), n.avail_out = 0;
		else if (n.avail_in === 0) break;
	}
	return !0;
}, Zn.prototype.onData = function(e) {
	this.chunks.push(e);
}, Zn.prototype.onEnd = function(e) {
	e === Gn && (this.result = Mn.flattenChunks(this.chunks)), this.chunks = [], this.err = e, this.msg = this.strm.msg;
};
function Qn(e, t) {
	let n = new Zn(t);
	if (n.push(e, !0), n.err) throw n.msg || gt[n.err];
	return n.result;
}
function $n(e, t) {
	return t ||= {}, t.raw = !0, Qn(e, t);
}
function er(e, t) {
	return t ||= {}, t.gzip = !0, Qn(e, t);
}
var tr = {
	Deflate: Zn,
	deflate: Qn,
	deflateRaw: $n,
	gzip: er,
	constants: _t
}, nr = 16209, rr = 16191, ir = function(e, t) {
	let n, r, i, a, o, s, c, l, u, d, f, p, m, h, g, _, v, y, b, x, S, C, w, T, E = e.state;
	n = e.next_in, w = e.input, r = n + (e.avail_in - 5), i = e.next_out, T = e.output, a = i - (t - e.avail_out), o = i + (e.avail_out - 257), s = E.dmax, c = E.wsize, l = E.whave, u = E.wnext, d = E.window, f = E.hold, p = E.bits, m = E.lencode, h = E.distcode, g = (1 << E.lenbits) - 1, _ = (1 << E.distbits) - 1;
	e: do {
		p < 15 && (f += w[n++] << p, p += 8, f += w[n++] << p, p += 8), v = m[f & g];
		t: for (;;) {
			if (y = v >>> 24, f >>>= y, p -= y, y = v >>> 16 & 255, y === 0) T[i++] = v & 65535;
			else if (y & 16) {
				b = v & 65535, y &= 15, y && (p < y && (f += w[n++] << p, p += 8), b += f & (1 << y) - 1, f >>>= y, p -= y), p < 15 && (f += w[n++] << p, p += 8, f += w[n++] << p, p += 8), v = h[f & _];
				n: for (;;) {
					if (y = v >>> 24, f >>>= y, p -= y, y = v >>> 16 & 255, y & 16) {
						if (x = v & 65535, y &= 15, p < y && (f += w[n++] << p, p += 8, p < y && (f += w[n++] << p, p += 8)), x += f & (1 << y) - 1, x > s) {
							e.msg = "invalid distance too far back", E.mode = nr;
							break e;
						}
						if (f >>>= y, p -= y, y = i - a, x > y) {
							if (y = x - y, y > l && E.sane) {
								e.msg = "invalid distance too far back", E.mode = nr;
								break e;
							}
							if (S = 0, C = d, u === 0) {
								if (S += c - y, y < b) {
									b -= y;
									do
										T[i++] = d[S++];
									while (--y);
									S = i - x, C = T;
								}
							} else if (u < y) {
								if (S += c + u - y, y -= u, y < b) {
									b -= y;
									do
										T[i++] = d[S++];
									while (--y);
									if (S = 0, u < b) {
										y = u, b -= y;
										do
											T[i++] = d[S++];
										while (--y);
										S = i - x, C = T;
									}
								}
							} else if (S += u - y, y < b) {
								b -= y;
								do
									T[i++] = d[S++];
								while (--y);
								S = i - x, C = T;
							}
							for (; b > 2;) T[i++] = C[S++], T[i++] = C[S++], T[i++] = C[S++], b -= 3;
							b && (T[i++] = C[S++], b > 1 && (T[i++] = C[S++]));
						} else {
							S = i - x;
							do
								T[i++] = T[S++], T[i++] = T[S++], T[i++] = T[S++], b -= 3;
							while (b > 2);
							b && (T[i++] = T[S++], b > 1 && (T[i++] = T[S++]));
						}
					} else if (y & 64) {
						e.msg = "invalid distance code", E.mode = nr;
						break e;
					} else {
						v = h[(v & 65535) + (f & (1 << y) - 1)];
						continue n;
					}
					break;
				}
			} else if (!(y & 64)) {
				v = m[(v & 65535) + (f & (1 << y) - 1)];
				continue t;
			} else if (y & 32) {
				E.mode = rr;
				break e;
			} else {
				e.msg = "invalid literal/length code", E.mode = nr;
				break e;
			}
			break;
		}
	} while (n < r && i < o);
	b = p >> 3, n -= b, p -= b << 3, f &= (1 << p) - 1, e.next_in = n, e.next_out = i, e.avail_in = n < r ? 5 + (r - n) : 5 - (n - r), e.avail_out = i < o ? 257 + (o - i) : 257 - (i - o), E.hold = f, E.bits = p;
}, ar = 15, or = 852, sr = 592, cr = 0, lr = 1, ur = 2, dr = new Uint16Array([
	3,
	4,
	5,
	6,
	7,
	8,
	9,
	10,
	11,
	13,
	15,
	17,
	19,
	23,
	27,
	31,
	35,
	43,
	51,
	59,
	67,
	83,
	99,
	115,
	131,
	163,
	195,
	227,
	258,
	0,
	0
]), fr = new Uint8Array([
	16,
	16,
	16,
	16,
	16,
	16,
	16,
	16,
	17,
	17,
	17,
	17,
	18,
	18,
	18,
	18,
	19,
	19,
	19,
	19,
	20,
	20,
	20,
	20,
	21,
	21,
	21,
	21,
	16,
	199,
	75
]), pr = new Uint16Array([
	1,
	2,
	3,
	4,
	5,
	7,
	9,
	13,
	17,
	25,
	33,
	49,
	65,
	97,
	129,
	193,
	257,
	385,
	513,
	769,
	1025,
	1537,
	2049,
	3073,
	4097,
	6145,
	8193,
	12289,
	16385,
	24577,
	0,
	0
]), mr = new Uint8Array([
	16,
	16,
	16,
	16,
	17,
	17,
	18,
	18,
	19,
	19,
	20,
	20,
	21,
	21,
	22,
	22,
	23,
	23,
	24,
	24,
	25,
	25,
	26,
	26,
	27,
	27,
	28,
	28,
	29,
	29,
	64,
	64
]), hr = (e, t, n, r, i, a, o, s) => {
	let c = s.bits, l = 0, u = 0, d = 0, f = 0, p = 0, m = 0, h = 0, g = 0, _ = 0, v = 0, y, b, x, S, C, w = null, T, E = new Uint16Array(ar + 1), D = new Uint16Array(ar + 1), O = null, ee, te, ne;
	for (l = 0; l <= ar; l++) E[l] = 0;
	for (u = 0; u < r; u++) E[t[n + u]]++;
	for (p = c, f = ar; f >= 1 && E[f] === 0; f--);
	if (p > f && (p = f), f === 0) return i[a++] = 20971520, i[a++] = 20971520, s.bits = 1, 0;
	for (d = 1; d < f && E[d] === 0; d++);
	for (p < d && (p = d), g = 1, l = 1; l <= ar; l++) if (g <<= 1, g -= E[l], g < 0) return -1;
	if (g > 0 && (e === cr || f !== 1)) return -1;
	for (D[1] = 0, l = 1; l < ar; l++) D[l + 1] = D[l] + E[l];
	for (u = 0; u < r; u++) t[n + u] !== 0 && (o[D[t[n + u]]++] = u);
	if (e === cr ? (w = O = o, T = 20) : e === lr ? (w = dr, O = fr, T = 257) : (w = pr, O = mr, T = 0), v = 0, u = 0, l = d, C = a, m = p, h = 0, x = -1, _ = 1 << p, S = _ - 1, e === lr && _ > or || e === ur && _ > sr) return 1;
	for (;;) {
		ee = l - h, o[u] + 1 < T ? (te = 0, ne = o[u]) : o[u] >= T ? (te = O[o[u] - T], ne = w[o[u] - T]) : (te = 96, ne = 0), y = 1 << l - h, b = 1 << m, d = b;
		do
			b -= y, i[C + (v >> h) + b] = ee << 24 | te << 16 | ne;
		while (b !== 0);
		for (y = 1 << l - 1; v & y;) y >>= 1;
		if (y === 0 ? v = 0 : (v &= y - 1, v += y), u++, --E[l] === 0) {
			if (l === f) break;
			l = t[n + o[u]];
		}
		if (l > p && (v & S) !== x) {
			for (h === 0 && (h = p), C += d, m = l - h, g = 1 << m; m + h < f && (g -= E[m + h], !(g <= 0));) m++, g <<= 1;
			if (_ += 1 << m, e === lr && _ > or || e === ur && _ > sr) return 1;
			x = v & S, i[x] = p << 24 | m << 16 | C - a;
		}
	}
	return v !== 0 && (i[C + v] = l - h << 24 | 4194304), s.bits = p, 0;
}, gr = 0, _r = 1, vr = 2, { Z_FINISH: yr, Z_BLOCK: br, Z_TREES: xr, Z_OK: Sr, Z_STREAM_END: Cr, Z_NEED_DICT: wr, Z_STREAM_ERROR: H, Z_DATA_ERROR: Tr, Z_MEM_ERROR: Er, Z_BUF_ERROR: Dr, Z_DEFLATED: Or } = _t, kr = 16180, Ar = 16181, jr = 16182, Mr = 16183, Nr = 16184, Pr = 16185, Fr = 16186, Ir = 16187, Lr = 16188, Rr = 16189, zr = 16190, U = 16191, Br = 16192, Vr = 16193, Hr = 16194, Ur = 16195, Wr = 16196, Gr = 16197, Kr = 16198, qr = 16199, Jr = 16200, Yr = 16201, Xr = 16202, Zr = 16203, Qr = 16204, $r = 16205, ei = 16206, ti = 16207, ni = 16208, W = 16209, ri = 16210, ii = 16211, ai = 852, oi = 592, si = 15, ci = (e) => (e >>> 24 & 255) + (e >>> 8 & 65280) + ((e & 65280) << 8) + ((e & 255) << 24);
function li() {
	this.strm = null, this.mode = 0, this.last = !1, this.wrap = 0, this.havedict = !1, this.flags = 0, this.dmax = 0, this.check = 0, this.total = 0, this.head = null, this.wbits = 0, this.wsize = 0, this.whave = 0, this.wnext = 0, this.window = null, this.hold = 0, this.bits = 0, this.length = 0, this.offset = 0, this.extra = 0, this.lencode = null, this.distcode = null, this.lenbits = 0, this.distbits = 0, this.ncode = 0, this.nlen = 0, this.ndist = 0, this.have = 0, this.next = null, this.lens = /* @__PURE__ */ new Uint16Array(320), this.work = /* @__PURE__ */ new Uint16Array(288), this.lendyn = null, this.distdyn = null, this.sane = 0, this.back = 0, this.was = 0;
}
var ui = (e) => {
	if (!e) return 1;
	let t = e.state;
	return +(!t || t.strm !== e || t.mode < kr || t.mode > ii);
}, di = (e) => {
	if (ui(e)) return H;
	let t = e.state;
	return e.total_in = e.total_out = t.total = 0, e.msg = "", t.wrap && (e.adler = t.wrap & 1), t.mode = kr, t.last = 0, t.havedict = 0, t.flags = -1, t.dmax = 32768, t.head = null, t.hold = 0, t.bits = 0, t.lencode = t.lendyn = new Int32Array(ai), t.distcode = t.distdyn = new Int32Array(oi), t.sane = 1, t.back = -1, Sr;
}, fi = (e) => {
	if (ui(e)) return H;
	let t = e.state;
	return t.wsize = 0, t.whave = 0, t.wnext = 0, di(e);
}, pi = (e, t) => {
	let n;
	if (ui(e)) return H;
	let r = e.state;
	return t < 0 ? (n = 0, t = -t) : (n = (t >> 4) + 5, t < 48 && (t &= 15)), t && (t < 8 || t > 15) ? H : (r.window !== null && r.wbits !== t && (r.window = null), r.wrap = n, r.wbits = t, fi(e));
}, mi = (e, t) => {
	if (!e) return H;
	let n = new li();
	e.state = n, n.strm = e, n.window = null, n.mode = kr;
	let r = pi(e, t);
	return r !== Sr && (e.state = null), r;
}, hi = (e) => mi(e, si), gi = !0, _i, vi, yi = (e) => {
	if (gi) {
		_i = /* @__PURE__ */ new Int32Array(512), vi = /* @__PURE__ */ new Int32Array(32);
		let t = 0;
		for (; t < 144;) e.lens[t++] = 8;
		for (; t < 256;) e.lens[t++] = 9;
		for (; t < 280;) e.lens[t++] = 7;
		for (; t < 288;) e.lens[t++] = 8;
		for (hr(_r, e.lens, 0, 288, _i, 0, e.work, { bits: 9 }), t = 0; t < 32;) e.lens[t++] = 5;
		hr(vr, e.lens, 0, 32, vi, 0, e.work, { bits: 5 }), gi = !1;
	}
	e.lencode = _i, e.lenbits = 9, e.distcode = vi, e.distbits = 5;
}, bi = (e, t, n, r) => {
	let i, a = e.state;
	return a.window === null && (a.window = new Uint8Array(1 << a.wbits)), a.wsize === 0 && (a.wsize = 1 << a.wbits, a.wnext = 0, a.whave = 0), r >= a.wsize ? (a.window.set(t.subarray(n - a.wsize, n), 0), a.wnext = 0, a.whave = a.wsize) : (i = a.wsize - a.wnext, i > r && (i = r), a.window.set(t.subarray(n - r, n - r + i), a.wnext), r -= i, r ? (a.window.set(t.subarray(n - r, n), 0), a.wnext = r, a.whave = a.wsize) : (a.wnext += i, a.wnext === a.wsize && (a.wnext = 0), a.whave < a.wsize && (a.whave += i))), 0;
}, G = {
	inflateReset: fi,
	inflateReset2: pi,
	inflateResetKeep: di,
	inflateInit: hi,
	inflateInit2: mi,
	inflate: (e, t) => {
		let n, r, i, a, o, s, c, l, u, d, f, p, m, h, g = 0, _, v, y, b, x, S, C, w, T = /* @__PURE__ */ new Uint8Array(4), E, D, O = new Uint8Array([
			16,
			17,
			18,
			0,
			8,
			7,
			9,
			6,
			10,
			5,
			11,
			4,
			12,
			3,
			13,
			2,
			14,
			1,
			15
		]);
		if (ui(e) || !e.output || !e.input && e.avail_in !== 0) return H;
		n = e.state, n.mode === U && (n.mode = Br), o = e.next_out, i = e.output, c = e.avail_out, a = e.next_in, r = e.input, s = e.avail_in, l = n.hold, u = n.bits, d = s, f = c, w = Sr;
		e: for (;;) switch (n.mode) {
			case kr:
				if (n.wrap === 0) {
					n.mode = Br;
					break;
				}
				for (; u < 16;) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				if (n.wrap & 2 && l === 35615) {
					n.wbits === 0 && (n.wbits = 15), n.check = 0, T[0] = l & 255, T[1] = l >>> 8 & 255, n.check = j(n.check, T, 2, 0), l = 0, u = 0, n.mode = Ar;
					break;
				}
				if (n.head && (n.head.done = !1), !(n.wrap & 1) || (((l & 255) << 8) + (l >> 8)) % 31) {
					e.msg = "incorrect header check", n.mode = W;
					break;
				}
				if ((l & 15) !== Or) {
					e.msg = "unknown compression method", n.mode = W;
					break;
				}
				if (l >>>= 4, u -= 4, C = (l & 15) + 8, n.wbits === 0 && (n.wbits = C), C > 15 || C > n.wbits) {
					e.msg = "invalid window size", n.mode = W;
					break;
				}
				n.dmax = 1 << n.wbits, n.flags = 0, e.adler = n.check = 1, n.mode = l & 512 ? Rr : U, l = 0, u = 0;
				break;
			case Ar:
				for (; u < 16;) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				if (n.flags = l, (n.flags & 255) !== Or) {
					e.msg = "unknown compression method", n.mode = W;
					break;
				}
				if (n.flags & 57344) {
					e.msg = "unknown header flags set", n.mode = W;
					break;
				}
				n.head && (n.head.text = l >> 8 & 1), n.flags & 512 && n.wrap & 4 && (T[0] = l & 255, T[1] = l >>> 8 & 255, n.check = j(n.check, T, 2, 0)), l = 0, u = 0, n.mode = jr;
			case jr:
				for (; u < 32;) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				n.head && (n.head.time = l), n.flags & 512 && n.wrap & 4 && (T[0] = l & 255, T[1] = l >>> 8 & 255, T[2] = l >>> 16 & 255, T[3] = l >>> 24 & 255, n.check = j(n.check, T, 4, 0)), l = 0, u = 0, n.mode = Mr;
			case Mr:
				for (; u < 16;) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				n.head && (n.head.xflags = l & 255, n.head.os = l >> 8), n.flags & 512 && n.wrap & 4 && (T[0] = l & 255, T[1] = l >>> 8 & 255, n.check = j(n.check, T, 2, 0)), l = 0, u = 0, n.mode = Nr;
			case Nr:
				if (n.flags & 1024) {
					for (; u < 16;) {
						if (s === 0) break e;
						s--, l += r[a++] << u, u += 8;
					}
					n.length = l, n.head && (n.head.extra_len = l), n.flags & 512 && n.wrap & 4 && (T[0] = l & 255, T[1] = l >>> 8 & 255, n.check = j(n.check, T, 2, 0)), l = 0, u = 0;
				} else n.head && (n.head.extra = null);
				n.mode = Pr;
			case Pr:
				if (n.flags & 1024 && (p = n.length, p > s && (p = s), p && (n.head && (C = n.head.extra_len - n.length, n.head.extra || (n.head.extra = new Uint8Array(n.head.extra_len)), n.head.extra.set(r.subarray(a, a + p), C)), n.flags & 512 && n.wrap & 4 && (n.check = j(n.check, r, p, a)), s -= p, a += p, n.length -= p), n.length)) break e;
				n.length = 0, n.mode = Fr;
			case Fr:
				if (n.flags & 2048) {
					if (s === 0) break e;
					p = 0;
					do
						C = r[a + p++], n.head && C && n.length < 65536 && (n.head.name += String.fromCharCode(C));
					while (C && p < s);
					if (n.flags & 512 && n.wrap & 4 && (n.check = j(n.check, r, p, a)), s -= p, a += p, C) break e;
				} else n.head && (n.head.name = null);
				n.length = 0, n.mode = Ir;
			case Ir:
				if (n.flags & 4096) {
					if (s === 0) break e;
					p = 0;
					do
						C = r[a + p++], n.head && C && n.length < 65536 && (n.head.comment += String.fromCharCode(C));
					while (C && p < s);
					if (n.flags & 512 && n.wrap & 4 && (n.check = j(n.check, r, p, a)), s -= p, a += p, C) break e;
				} else n.head && (n.head.comment = null);
				n.mode = Lr;
			case Lr:
				if (n.flags & 512) {
					for (; u < 16;) {
						if (s === 0) break e;
						s--, l += r[a++] << u, u += 8;
					}
					if (n.wrap & 4 && l !== (n.check & 65535)) {
						e.msg = "header crc mismatch", n.mode = W;
						break;
					}
					l = 0, u = 0;
				}
				n.head && (n.head.hcrc = n.flags >> 9 & 1, n.head.done = !0), e.adler = n.check = 0, n.mode = U;
				break;
			case Rr:
				for (; u < 32;) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				e.adler = n.check = ci(l), l = 0, u = 0, n.mode = zr;
			case zr:
				if (n.havedict === 0) return e.next_out = o, e.avail_out = c, e.next_in = a, e.avail_in = s, n.hold = l, n.bits = u, wr;
				e.adler = n.check = 1, n.mode = U;
			case U: if (t === br || t === xr) break e;
			case Br:
				if (n.last) {
					l >>>= u & 7, u -= u & 7, n.mode = ei;
					break;
				}
				for (; u < 3;) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				switch (n.last = l & 1, l >>>= 1, --u, l & 3) {
					case 0:
						n.mode = Vr;
						break;
					case 1:
						if (yi(n), n.mode = qr, t === xr) {
							l >>>= 2, u -= 2;
							break e;
						}
						break;
					case 2:
						n.mode = Wr;
						break;
					case 3: e.msg = "invalid block type", n.mode = W;
				}
				l >>>= 2, u -= 2;
				break;
			case Vr:
				for (l >>>= u & 7, u -= u & 7; u < 32;) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				if ((l & 65535) != (l >>> 16 ^ 65535)) {
					e.msg = "invalid stored block lengths", n.mode = W;
					break;
				}
				if (n.length = l & 65535, l = 0, u = 0, n.mode = Hr, t === xr) break e;
			case Hr: n.mode = Ur;
			case Ur:
				if (p = n.length, p) {
					if (p > s && (p = s), p > c && (p = c), p === 0) break e;
					i.set(r.subarray(a, a + p), o), s -= p, a += p, c -= p, o += p, n.length -= p;
					break;
				}
				n.mode = U;
				break;
			case Wr:
				for (; u < 14;) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				if (n.nlen = (l & 31) + 257, l >>>= 5, u -= 5, n.ndist = (l & 31) + 1, l >>>= 5, u -= 5, n.ncode = (l & 15) + 4, l >>>= 4, u -= 4, n.nlen > 286 || n.ndist > 30) {
					e.msg = "too many length or distance symbols", n.mode = W;
					break;
				}
				n.have = 0, n.mode = Gr;
			case Gr:
				for (; n.have < n.ncode;) {
					for (; u < 3;) {
						if (s === 0) break e;
						s--, l += r[a++] << u, u += 8;
					}
					n.lens[O[n.have++]] = l & 7, l >>>= 3, u -= 3;
				}
				for (; n.have < 19;) n.lens[O[n.have++]] = 0;
				if (n.lencode = n.lendyn, n.lenbits = 7, E = { bits: n.lenbits }, w = hr(gr, n.lens, 0, 19, n.lencode, 0, n.work, E), n.lenbits = E.bits, w) {
					e.msg = "invalid code lengths set", n.mode = W;
					break;
				}
				n.have = 0, n.mode = Kr;
			case Kr:
				for (; n.have < n.nlen + n.ndist;) {
					for (; g = n.lencode[l & (1 << n.lenbits) - 1], _ = g >>> 24, v = g >>> 16 & 255, y = g & 65535, !(_ <= u);) {
						if (s === 0) break e;
						s--, l += r[a++] << u, u += 8;
					}
					if (y < 16) l >>>= _, u -= _, n.lens[n.have++] = y;
					else {
						if (y === 16) {
							for (D = _ + 2; u < D;) {
								if (s === 0) break e;
								s--, l += r[a++] << u, u += 8;
							}
							if (l >>>= _, u -= _, n.have === 0) {
								e.msg = "invalid bit length repeat", n.mode = W;
								break;
							}
							C = n.lens[n.have - 1], p = 3 + (l & 3), l >>>= 2, u -= 2;
						} else if (y === 17) {
							for (D = _ + 3; u < D;) {
								if (s === 0) break e;
								s--, l += r[a++] << u, u += 8;
							}
							l >>>= _, u -= _, C = 0, p = 3 + (l & 7), l >>>= 3, u -= 3;
						} else {
							for (D = _ + 7; u < D;) {
								if (s === 0) break e;
								s--, l += r[a++] << u, u += 8;
							}
							l >>>= _, u -= _, C = 0, p = 11 + (l & 127), l >>>= 7, u -= 7;
						}
						if (n.have + p > n.nlen + n.ndist) {
							e.msg = "invalid bit length repeat", n.mode = W;
							break;
						}
						for (; p--;) n.lens[n.have++] = C;
					}
				}
				if (n.mode === W) break;
				if (n.lens[256] === 0) {
					e.msg = "invalid code -- missing end-of-block", n.mode = W;
					break;
				}
				if (n.lenbits = 9, E = { bits: n.lenbits }, w = hr(_r, n.lens, 0, n.nlen, n.lencode, 0, n.work, E), n.lenbits = E.bits, w) {
					e.msg = "invalid literal/lengths set", n.mode = W;
					break;
				}
				if (n.distbits = 6, n.distcode = n.distdyn, E = { bits: n.distbits }, w = hr(vr, n.lens, n.nlen, n.ndist, n.distcode, 0, n.work, E), n.distbits = E.bits, w) {
					e.msg = "invalid distances set", n.mode = W;
					break;
				}
				if (n.mode = qr, t === xr) break e;
			case qr: n.mode = Jr;
			case Jr:
				if (s >= 6 && c >= 258) {
					e.next_out = o, e.avail_out = c, e.next_in = a, e.avail_in = s, n.hold = l, n.bits = u, ir(e, f), o = e.next_out, i = e.output, c = e.avail_out, a = e.next_in, r = e.input, s = e.avail_in, l = n.hold, u = n.bits, n.mode === U && (n.back = -1);
					break;
				}
				for (n.back = 0; g = n.lencode[l & (1 << n.lenbits) - 1], _ = g >>> 24, v = g >>> 16 & 255, y = g & 65535, !(_ <= u);) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				if (v && !(v & 240)) {
					for (b = _, x = v, S = y; g = n.lencode[S + ((l & (1 << b + x) - 1) >> b)], _ = g >>> 24, v = g >>> 16 & 255, y = g & 65535, !(b + _ <= u);) {
						if (s === 0) break e;
						s--, l += r[a++] << u, u += 8;
					}
					l >>>= b, u -= b, n.back += b;
				}
				if (l >>>= _, u -= _, n.back += _, n.length = y, v === 0) {
					n.mode = $r;
					break;
				}
				if (v & 32) {
					n.back = -1, n.mode = U;
					break;
				}
				if (v & 64) {
					e.msg = "invalid literal/length code", n.mode = W;
					break;
				}
				n.extra = v & 15, n.mode = Yr;
			case Yr:
				if (n.extra) {
					for (D = n.extra; u < D;) {
						if (s === 0) break e;
						s--, l += r[a++] << u, u += 8;
					}
					n.length += l & (1 << n.extra) - 1, l >>>= n.extra, u -= n.extra, n.back += n.extra;
				}
				n.was = n.length, n.mode = Xr;
			case Xr:
				for (; g = n.distcode[l & (1 << n.distbits) - 1], _ = g >>> 24, v = g >>> 16 & 255, y = g & 65535, !(_ <= u);) {
					if (s === 0) break e;
					s--, l += r[a++] << u, u += 8;
				}
				if (!(v & 240)) {
					for (b = _, x = v, S = y; g = n.distcode[S + ((l & (1 << b + x) - 1) >> b)], _ = g >>> 24, v = g >>> 16 & 255, y = g & 65535, !(b + _ <= u);) {
						if (s === 0) break e;
						s--, l += r[a++] << u, u += 8;
					}
					l >>>= b, u -= b, n.back += b;
				}
				if (l >>>= _, u -= _, n.back += _, v & 64) {
					e.msg = "invalid distance code", n.mode = W;
					break;
				}
				n.offset = y, n.extra = v & 15, n.mode = Zr;
			case Zr:
				if (n.extra) {
					for (D = n.extra; u < D;) {
						if (s === 0) break e;
						s--, l += r[a++] << u, u += 8;
					}
					n.offset += l & (1 << n.extra) - 1, l >>>= n.extra, u -= n.extra, n.back += n.extra;
				}
				if (n.offset > n.dmax) {
					e.msg = "invalid distance too far back", n.mode = W;
					break;
				}
				n.mode = Qr;
			case Qr:
				if (c === 0) break e;
				if (p = f - c, n.offset > p) {
					if (p = n.offset - p, p > n.whave && n.sane) {
						e.msg = "invalid distance too far back", n.mode = W;
						break;
					}
					p > n.wnext ? (p -= n.wnext, m = n.wsize - p) : m = n.wnext - p, p > n.length && (p = n.length), h = n.window;
				} else h = i, m = o - n.offset, p = n.length;
				p > c && (p = c), c -= p, n.length -= p;
				do
					i[o++] = h[m++];
				while (--p);
				n.length === 0 && (n.mode = Jr);
				break;
			case $r:
				if (c === 0) break e;
				i[o++] = n.length, c--, n.mode = Jr;
				break;
			case ei:
				if (n.wrap) {
					for (; u < 32;) {
						if (s === 0) break e;
						s--, l |= r[a++] << u, u += 8;
					}
					if (f -= c, e.total_out += f, n.total += f, n.wrap & 4 && f && (e.adler = n.check = n.flags ? j(n.check, i, f, o - f) : mt(n.check, i, f, o - f)), f = c, n.wrap & 4 && (n.flags ? l : ci(l)) !== n.check) {
						e.msg = "incorrect data check", n.mode = W;
						break;
					}
					l = 0, u = 0;
				}
				n.mode = ti;
			case ti:
				if (n.wrap && n.flags) {
					for (; u < 32;) {
						if (s === 0) break e;
						s--, l += r[a++] << u, u += 8;
					}
					if (n.wrap & 4 && l !== (n.total | 0)) {
						e.msg = "incorrect length check", n.mode = W;
						break;
					}
					l = 0, u = 0;
				}
				n.mode = ni;
			case ni:
				w = Cr;
				break e;
			case W:
				w = Tr;
				break e;
			case ri: return Er;
			case ii:
			default: return H;
		}
		return e.next_out = o, e.avail_out = c, e.next_in = a, e.avail_in = s, n.hold = l, n.bits = u, (n.wsize || f !== e.avail_out && n.mode < W && (n.mode < ei || t !== yr)) && bi(e, e.output, e.next_out, f - e.avail_out), d -= e.avail_in, f -= e.avail_out, e.total_in += d, e.total_out += f, n.total += f, n.wrap & 4 && f && (e.adler = n.check = n.flags ? j(n.check, i, f, e.next_out - f) : mt(n.check, i, f, e.next_out - f)), e.data_type = n.bits + (n.last ? 64 : 0) + (n.mode === U ? 128 : 0) + (n.mode === qr || n.mode === Hr ? 256 : 0), (d === 0 && f === 0 || t === yr) && w === Sr && (w = Dr), w;
	},
	inflateEnd: (e) => {
		if (ui(e)) return H;
		let t = e.state;
		return t.window &&= null, e.state = null, Sr;
	},
	inflateGetHeader: (e, t) => {
		if (ui(e)) return H;
		let n = e.state;
		return n.wrap & 2 ? (n.head = t, t.done = !1, Sr) : H;
	},
	inflateSetDictionary: (e, t) => {
		let n = t.length, r, i, a;
		return ui(e) || (r = e.state, r.wrap !== 0 && r.mode !== zr) ? H : r.mode === zr && (i = 1, i = mt(i, t, n, 0), i !== r.check) ? Tr : (a = bi(e, t, n, n), a ? (r.mode = ri, Er) : (r.havedict = 1, Sr));
	},
	inflateInfo: "pako inflate (from Nodeca project)"
};
function xi() {
	this.text = 0, this.time = 0, this.xflags = 0, this.os = 0, this.extra = null, this.extra_len = 0, this.name = "", this.comment = "", this.hcrc = 0, this.done = !1;
}
var Si = xi, Ci = Object.prototype.toString, { Z_NO_FLUSH: wi, Z_FINISH: Ti, Z_OK: Ei, Z_STREAM_END: Di, Z_NEED_DICT: Oi, Z_STREAM_ERROR: ki, Z_DATA_ERROR: Ai, Z_MEM_ERROR: ji, Z_BUF_ERROR: Mi } = _t, Ni = {
	chunkSize: 65536,
	windowBits: 15,
	to: ""
};
function Pi(e) {
	this.options = Mn.assign({}, Ni, e || {});
	let t = this.options;
	t.raw && t.windowBits >= 0 && t.windowBits < 16 && (t.windowBits = -t.windowBits, t.windowBits === 0 && (t.windowBits = -15)), t.windowBits >= 0 && t.windowBits < 16 && !(e && e.windowBits) && (t.windowBits += 32), t.windowBits > 15 && t.windowBits < 48 && (t.windowBits & 15 || (t.windowBits |= 15)), this.err = 0, this.msg = "", this.ended = !1, this.chunks = [], this.strm = new zn(), this.strm.avail_out = 0;
	let n = G.inflateInit2(this.strm, t.windowBits);
	if (n !== Ei || (this.header = new Si(), G.inflateGetHeader(this.strm, this.header), t.dictionary && (typeof t.dictionary == "string" ? t.dictionary = Ln.string2buf(t.dictionary) : Ci.call(t.dictionary) === "[object ArrayBuffer]" && (t.dictionary = new Uint8Array(t.dictionary)), t.raw && (n = G.inflateSetDictionary(this.strm, t.dictionary), n !== Ei)))) throw Error(gt[n]);
}
Pi.prototype.push = function(e, t) {
	let n = this.strm, r = this.options.chunkSize, i = this.options.dictionary, a, o, s;
	if (this.ended) return !1;
	for (o = t === ~~t ? t : t === !0 ? Ti : wi, n.input = Ci.call(e) === "[object ArrayBuffer]" ? new Uint8Array(e) : e, n.next_in = 0, n.avail_in = n.input.length;;) {
		for (n.avail_out === 0 && (n.output = new Uint8Array(r), n.next_out = 0, n.avail_out = r), a = G.inflate(n, o), a === Oi && i && (a = G.inflateSetDictionary(n, i), a === Ei ? a = G.inflate(n, o) : a === Ai && (a = Oi)); n.avail_in > 0 && a === Di && n.state.wrap & 2 && n.state.flags !== 0 && n.input[n.next_in] !== 0;) G.inflateReset(n), a = G.inflate(n, o);
		switch (a) {
			case ki:
			case Ai:
			case Oi:
			case ji: return this.onEnd(a), this.ended = !0, !1;
		}
		if (s = n.avail_out, n.next_out && (n.avail_out === 0 || a === Di || o > 0)) {
			if (this.options.to === "string") {
				let e = Ln.utf8border(n.output, n.next_out), t = n.next_out - e, i = Ln.buf2string(n.output, e);
				n.next_out = t, n.avail_out = r - t, t && n.output.set(n.output.subarray(e, e + t), 0), this.onData(i);
			} else this.onData(n.output.length === n.next_out ? n.output : n.output.subarray(0, n.next_out)), n.avail_out = 0, n.next_out = 0;
		}
		if (a !== Ei && a !== Mi || s !== 0) {
			if (a === Di) return a = G.inflateEnd(this.strm), this.onEnd(a), this.ended = !0, !0;
			if (n.avail_in === 0) {
				if (o === Ti) return a = G.inflateEnd(this.strm), this.onEnd(a === Ei ? Mi : a), this.ended = !0, !1;
				break;
			}
		}
	}
	return !0;
}, Pi.prototype.onData = function(e) {
	this.chunks.push(e);
}, Pi.prototype.onEnd = function(e) {
	e === Ei && (this.result = this.options.to === "string" ? this.chunks.join("") : Mn.flattenChunks(this.chunks)), this.chunks = [], this.err = e, this.msg = this.strm.msg;
};
function Fi(e, t) {
	let n = new Pi(t);
	if (n.push(e, !0), n.err) throw n.msg || gt[n.err];
	return n.result;
}
function Ii(e, t) {
	return t ||= {}, t.raw = !0, Fi(e, t);
}
var Li = {
	Inflate: Pi,
	inflate: Fi,
	inflateRaw: Ii,
	ungzip: Fi,
	constants: _t
}, { Deflate: Ri, deflate: zi, deflateRaw: Bi, gzip: Vi } = tr, { Inflate: Hi, inflate: Ui, inflateRaw: Wi, ungzip: Gi } = Li;
Object.freeze([
	0,
	4,
	8,
	16,
	32,
	64,
	128,
	256,
	512,
	1024,
	2048
]), Object.freeze({
	text: 0,
	markdown: 1,
	javascript: 2,
	html: 3
}), Object.freeze([
	"text",
	"markdown",
	"javascript",
	"html"
]);
var Ki = Object.freeze([
	" ",
	"\n",
	"  ",
	"    ",
	"\r\n",
	"	",
	"\n\n",
	"```",
	"# ",
	"## ",
	"### ",
	"- ",
	"* ",
	"> ",
	"](",
	")\n",
	"const ",
	"let ",
	"function ",
	"return ",
	" => ",
	" = ",
	" === ",
	" !== ",
	"import ",
	"export ",
	" from ",
	"async ",
	"await ",
	"if (",
	"else ",
	"for (",
	"while (",
	"try {",
	"} catch (",
	"class ",
	"new ",
	"this.",
	"throw new ",
	"typeof ",
	"instanceof ",
	"true",
	"false",
	"null",
	"undefined",
	"switch (",
	"case ",
	"break;",
	"continue;",
	"document.",
	"window.",
	"querySelector(",
	"querySelectorAll(",
	"addEventListener(",
	"textContent",
	"console.log(",
	"console.error(",
	"JSON.stringify(",
	"JSON.parse(",
	"Object.",
	"Array.",
	"</",
	"<!--",
	"-->",
	"<!DOCTYPE html>",
	"<html",
	"<head>",
	"<body",
	"<div",
	"</div>",
	"<span",
	"</span>",
	"<button",
	"</button>",
	"<script",
	"<\/script>",
	"<style>",
	"</style>",
	" class=\"",
	" id=\"",
	" href=\"",
	" src=\"",
	" aria-",
	" data-",
	" role=\"",
	"display: ",
	"position: ",
	"color: ",
	"background: ",
	"border: ",
	"padding: ",
	"margin: ",
	"width: ",
	"height: ",
	"font-size: ",
	"font-family: ",
	"align-items: ",
	"justify-content: ",
	"```javascript",
	"```js",
	"```html",
	"```css",
	"```json",
	"```bash",
	"```text",
	"**",
	"__",
	"~~",
	"![",
	"https://",
	"http://",
	"www.",
	"README",
	"LICENSE",
	" the ",
	" and ",
	" that ",
	" with ",
	" this ",
	" for ",
	" are ",
	" not ",
	"The ",
	"This ",
	"There ",
	" can ",
	" will ",
	" into ",
	" when ",
	" then ",
	"ing ",
	"()",
	"[]",
	"{}",
	"();",
	");",
	", ",
	": ",
	";\n",
	" {\n",
	"}\n",
	"},\n",
	"\";",
	"?.",
	"??",
	"...",
	"${",
	"?.(",
	"?.[",
	"Promise",
	"resolve",
	"reject",
	"interface ",
	"type ",
	"extends ",
	"implements ",
	"public ",
	"private ",
	"readonly ",
	"def ",
	"self.",
	"None",
	"elif ",
	"except ",
	"finally:",
	"lambda ",
	"yield ",
	"fn ",
	"pub ",
	"mut ",
	"impl ",
	"struct ",
	"enum ",
	"match ",
	"Result<",
	"Option<",
	"package ",
	"func ",
	"defer ",
	"select {",
	"range ",
	"context.",
	"error",
	"SELECT ",
	"FROM ",
	"WHERE ",
	"INSERT ",
	"UPDATE ",
	"DELETE ",
	"CREATE ",
	"JOIN ",
	"{\n",
	"\n}",
	"\n  ",
	"\n    ",
	"\n      ",
	"\r\n  ",
	"\r\n    "
]), qi = new TextEncoder();
new TextDecoder("utf-8", { fatal: !0 });
var Ji = Ki.map((e) => qi.encode(e));
Array.from({ length: 256 }, (e, t) => t.toString(16).padStart(2, "0")), new Set(Ki);
function Yi(e = []) {
	let t = {
		children: /* @__PURE__ */ new Map(),
		index: -1
	};
	return Ji.forEach((e, n) => {
		let r = t;
		for (let t of e) r.children.has(t) || r.children.set(t, {
			children: /* @__PURE__ */ new Map(),
			index: -1
		}), r = r.children.get(t);
		r.index = n, r.type = "dictionary";
	}), e.forEach((e, n) => {
		let r = t;
		for (let t of e) r.children.has(t) || r.children.set(t, {
			children: /* @__PURE__ */ new Map(),
			index: -1
		}), r = r.children.get(t);
		r.index = n, r.type = "lexeme";
	}), t;
}
Yi();
function Xi(e, t = !1) {
	return "#" + (t ? "ss:" : "s:") + ue(le(e)).payload;
}
var K = (e) => document.getElementById(e), Zi = new URL(".", new URL("assets/app.js", globalThis.__vitalityEmbedded.root).href), q, J, Qi = !0, Y, $i = -1, ea = 0, ta, na, ra = 0, ia = !1, X, aa, oa, sa = 0, ca = !1, la, ua = !1, da, fa, pa, ma = /* @__PURE__ */ new Set(), ha = class {
	constructor(e) {
		this.worker = new Worker(new URL(e, Zi), { type: "module" }), this.pending = /* @__PURE__ */ new Map(), this.sequence = 0, this.worker.onmessage = ({ data: e }) => {
			let t = this.pending.get(e.id);
			t && (e.progress === void 0 ? (clearTimeout(t.timer), this.pending.delete(e.id), e.error ? t.reject(Object.assign(Error(e.error), { diagnostic: e.diagnostic })) : t.resolve(e.result)) : t.progress?.(e.progress));
		}, this.worker.onerror = (e) => {
			e.preventDefault(), this.close(Error(e.message || "Worker failed."));
		};
	}
	call(e, t, n = 3e4, r) {
		return new Promise((i, a) => {
			let o = ++this.sequence, s = n ? setTimeout(() => this.close(Error("Operation timed out. The worker was stopped; your source is preserved.")), n) : null;
			this.pending.set(o, {
				resolve: i,
				reject: a,
				timer: s,
				progress: r
			}), this.worker.postMessage({
				id: o,
				operation: e,
				input: t
			});
		});
	}
	close(e = Error("Cancelled.")) {
		this.worker.terminate(), this.dead = !0;
		for (let t of this.pending.values()) clearTimeout(t.timer), t.reject(e);
		this.pending.clear();
	}
};
function Z(e, t = !1) {
	K("messages").textContent = e, K("messages").classList.toggle("error", t);
}
function Q(e) {
	K("status").textContent = e;
}
function ga(e, t = X?.sampleRate || 48e3) {
	let n = e / t;
	return `${Math.floor(n / 60)}:${(n % 60).toFixed(1).padStart(4, "0")}`;
}
function _a(e) {
	let t = new URL(location.href);
	return t.search = "", t.hash = e, t.href;
}
function va(e) {
	try {
		history.replaceState(null, "", _a(e)), K("link-state").textContent = `${e.startsWith("#s") ? "Source link" : "Embedded project"} · ${e.length.toLocaleString()} chars`;
	} catch {
		K("link-state").textContent = "URL too large; download Project instead";
	}
}
function ya() {
	return (!pa || pa.dead) && (pa = new ha("./data-worker.js")), pa;
}
function ba() {
	return (!fa || fa.dead) && (fa = new ha("./engine-worker.js"), $i = -1), fa;
}
function xa() {
	let e = K("editor").value.split("\n").length;
	K("line-numbers").textContent = Array.from({ length: e }, (e, t) => t + 1).join("\n"), K("file-info").textContent = `${e} lines · UTF-8`;
}
function Sa() {
	K("file").replaceChildren(), K("entry").replaceChildren();
	for (let e of Object.keys(q.files)) K("file").add(new Option(e, e)), e.endsWith(".muz") && K("entry").add(new Option(e, e));
	for (let e of Object.keys(q.assets)) K("file").add(new Option(`${e} [asset]`, e));
	K("file").value = J, K("entry").value = q.entry, K("project-title").value = q.title;
	let e = !(J in q.files);
	K("editor").readOnly = e, K("editor").value = e ? `${J}

Binary asset · ${Math.floor(q.assets[J].length * .75).toLocaleString()} bytes
Included in saved projects and embedded links.` : q.files[J], xa();
}
async function Ca() {
	let e = await new Promise((e, t) => {
		let n = indexedDB.open("muzstatic", 1);
		n.onupgradeneeded = () => n.result.createObjectStore("draft"), n.onsuccess = () => e(n.result), n.onerror = () => t(n.error);
	});
	try {
		await new Promise((t, n) => {
			let r = e.transaction("draft", "readwrite");
			r.objectStore("draft").put(q, "current"), r.oncomplete = t, r.onerror = () => n(r.error);
		});
	} finally {
		e.close();
	}
}
async function wa() {
	let e = await new Promise((e, t) => {
		let n = indexedDB.open("muzstatic", 1);
		n.onupgradeneeded = () => n.result.createObjectStore("draft"), n.onsuccess = () => e(n.result), n.onerror = () => t(n.error);
	});
	try {
		return await new Promise((t, n) => {
			let r = e.transaction("draft").objectStore("draft").get("current");
			r.onsuccess = () => t(r.result), r.onerror = () => n(r.error);
		});
	} finally {
		e.close();
	}
}
function Ta() {
	ea++, Qi = !0, Q("Edited · compile to apply"), clearTimeout(na), na = setTimeout(() => Ca().catch(() => Q("Draft storage unavailable · use Project ↓")), 300), clearTimeout(ta);
	let e = ea;
	ta = setTimeout(async () => {
		try {
			let t = await ya().call("share", q);
			ea === e && va(t);
		} catch (t) {
			ea === e && (K("link-state").textContent = t.message);
		}
	}, 950);
}
async function Ea(e = !0) {
	sa++, ia = !1, ra = 0, K("position").textContent = ga(0), K("play").textContent = "▶ Play", aa?.port.postMessage({ type: "clear" }), e && Y && fa && !fa.dead && await fa.call("reset"), Pa();
}
async function Da(e, t) {
	await Ea(!1), q = s(e), J = q.entry, ea++, $i = -1, Y = void 0, Qi = !0, ma.clear(), K("tracks").replaceChildren(), K("empty-score").hidden = !1, K("score-info").textContent = "Not compiled", K("tempo").textContent = "— BPM", K("duration").textContent = "—", Sa(), await Ca().catch(() => {}), t ? va(t) : Ta(), Z("Project loaded. Compile or Play when ready."), Q("Local workspace");
}
async function Oa() {
	X || (X = new AudioContext({ sampleRate: 48e3 }), await X.audioWorklet.addModule(new URL(globalThis.__vitalityEmbedded.script("src/app/assets/player-worklet.js"))), aa = new AudioWorkletNode(X, "muzstatic-player", {
		numberOfInputs: 0,
		numberOfOutputs: 1,
		outputChannelCount: [2]
	}), oa = X.createGain(), oa.gain.value = Number(K("volume").value) / 100, aa.connect(oa).connect(X.destination), aa.port.onmessage = ({ data: e }) => {
		e.type === "need" && ka().catch(Ra), e.type === "position" && (ra = e.frame, K("position").textContent = ga(ra), Pa()), e.type === "ended" && (ia = !1, K("play").textContent = "▶ Replay", Q("Playback finished"));
	}), await X.resume();
}
async function ka() {
	if (ca || !Y) return;
	ca = !0;
	let e = sa;
	try {
		let t = await ba().call("pull", {
			frames: 16384,
			rate: X.sampleRate
		});
		e === sa && aa.port.postMessage({
			type: "chunk",
			pcm: t.pcm,
			done: t.done
		}, [t.pcm.buffer]);
	} finally {
		ca = !1, e !== sa && aa?.port.postMessage({ type: "retry" });
	}
}
async function Aa() {
	await Ea(!1);
	let e = ea;
	Z("Compiling with muz…"), Q("Compiling");
	let t = ba();
	da = () => t.close();
	let n = await t.call("compile", {
		project: q,
		rate: X?.sampleRate || 48e3
	});
	return e === ea ? (Y = n, $i = e, Qi = !1, ma.clear(), K("duration").textContent = ga(n.frames + (n.tail || 0) * (X?.sampleRate || 48e3)), K("tempo").textContent = `${n.bpm} BPM · ${n.meter.join("/")}`, K("score-info").textContent = `${n.tracks.length} tracks`, K("empty-score").hidden = !0, Ma(), Z([`Compiled ${n.title || q.entry}.`, ...n.diagnostics.map((e) => `${e.severity}: ${e.track} · ${e.message}`)].join("\n")), Q("Compiled · ready"), !0) : (Q("Edited during compilation · compile again"), !1);
}
async function ja() {
	if (ia) ia = !1, aa.port.postMessage({ type: "pause" }), K("play").textContent = "▶ Resume", Q("Paused");
	else {
		if (await Oa(), Qi || $i !== ea || fa?.dead) {
			if (!await Aa()) return;
		} else ra >= Y.frames + (Y.tail || 0) * X.sampleRate - 128 && await Ea();
		ra || await ka(), ia = !0, aa.port.postMessage({ type: "play" }), K("play").textContent = "Ⅱ Pause", Q("Playing");
	}
}
function Ma() {
	K("tracks").replaceChildren(), Y.tracks.forEach((e, t) => {
		let n = document.createElement("section");
		n.className = "track";
		let r = document.createElement("div");
		r.className = "track-head";
		let i = document.createElement("span");
		i.className = "track-id", i.textContent = e.name || e.id, i.style.color = Na[t % Na.length];
		let a = document.createElement("span");
		a.className = "note-count", a.textContent = `${e.notes.length} notes`;
		let o = document.createElement("button");
		o.textContent = "Solo", o.setAttribute("aria-pressed", "false"), o.onclick = () => $(async () => {
			ma.has(e.id) ? ma.delete(e.id) : ma.add(e.id), o.setAttribute("aria-pressed", String(ma.has(e.id))), await ba().call("solo", [...ma]);
		});
		let s = document.createElement("canvas");
		s.setAttribute("aria-label", `Score for ${e.id}`), s.setAttribute("role", "img"), r.append(i, a, o), n.append(r, s), K("tracks").append(n);
	}), Pa();
}
var Na = [
	"#89d6b4",
	"#94b8ed",
	"#d5acf0",
	"#edc28f",
	"#e894ad",
	"#85cbd2"
];
function Pa() {
	if (!Y) return;
	let e = Math.max(1, Y.frames);
	[...K("tracks").querySelectorAll("canvas")].forEach((t, n) => {
		let r = Math.max(1, t.clientWidth), i = window.devicePixelRatio || 1;
		t.width = r * i, t.height = 82 * i;
		let a = t.getContext("2d");
		a.scale(i, i), a.strokeStyle = "#22313e", a.lineWidth = .5;
		for (let e = 0; e < 17; e++) a.beginPath(), a.moveTo(e * r / 16, 0), a.lineTo(e * r / 16, 82), a.stroke();
		let o = Y.tracks[n].notes, s = Math.min(48, ...o.slice(0, 2e4).map((e) => e.pitch)), c = Math.max(72, ...o.slice(0, 2e4).map((e) => e.pitch));
		a.fillStyle = Na[n % Na.length];
		for (let t of o) a.globalAlpha = .35 + Math.max(0, Math.min(1, t.velocity)) * .65, a.fillRect(t.at / e * r, 6 + (c - t.pitch) / (c - s + 1) * 68, Math.max(2, t.dur / e * r - 1), 3);
		if (a.globalAlpha = 1, ra) {
			let e = Math.min(r, ra / Y.frames * r);
			a.strokeStyle = "#fff", a.beginPath(), a.moveTo(e, 0), a.lineTo(e, 82), a.stroke();
		}
	});
}
function Fa(e, t, n) {
	let r = URL.createObjectURL(new Blob([e], { type: n })), i = document.createElement("a");
	i.href = r, i.download = t, i.click(), setTimeout(() => URL.revokeObjectURL(r), 3e4);
}
function Ia(e) {
	return (q.title.replace(/[^\w .-]/g, "_") || "song") + e;
}
async function La(e) {
	K("share-status").textContent = "Preparing…";
	try {
		let t = e === "embedded" ? await ya().call("share", q) : Xi(K("source-input").value, e === "super"), n = _a(t);
		K("share-output").value = n, va(t);
		try {
			await navigator.clipboard.writeText(n), K("share-status").textContent = `Copied · ${n.length.toLocaleString()} characters`;
		} catch {
			K("share-output").select(), K("share-status").textContent = "Select and copy the URL below.";
		}
	} catch (e) {
		K("share-status").textContent = e.message;
	}
}
function Ra(e) {
	ia = !1, aa?.port.postMessage({ type: "pause" }), K("play").textContent = "▶ Play", Z(e.message, !0), Q("Stopped · source preserved");
}
async function $(e) {
	if (!ua) {
		ua = !0, K("cancel").hidden = !1;
		try {
			await e();
		} catch (e) {
			Ra(e);
		} finally {
			ua = !1, da = void 0, K("cancel").hidden = !0;
		}
	}
}
async function za(e) {
	let t = ya();
	if (da = () => t.close(), Z("Resolving project link…"), Q("Loading"), /^(?:https:\/\/gist\.github\.com\/[^/]+\/)?[a-f\d]{32,40}(?:\/|$)/i.test(e.trim())) await Da(await t.call("gist", e, 35e3));
	else {
		let n = await t.call("resolve", e, 35e3);
		await Da(n.project, n.fragment), Z(`Loaded ${q.entry}${n.sources.length ? "\n" + n.sources.join("\n") : " from embedded data"}.`);
	}
}
K("editor").addEventListener("input", () => {
	q.files[J] = K("editor").value, xa(), Ta();
}), K("editor").addEventListener("scroll", () => {
	K("line-numbers").scrollTop = K("editor").scrollTop;
}), K("editor").addEventListener("keydown", (e) => {
	if (e.key === "Tab" && !e.shiftKey) {
		e.preventDefault();
		let t = K("editor");
		t.setRangeText("  ", t.selectionStart, t.selectionEnd, "end"), t.dispatchEvent(new Event("input"));
	}
}), K("project-title").oninput = () => {
	q.title = K("project-title").value, Ta();
}, K("file").onchange = () => {
	J = K("file").value, Sa();
}, K("entry").onchange = () => {
	q.entry = K("entry").value, Ta();
}, K("add-file").onclick = () => {
	let e = prompt("Project-relative source path", "module.muz");
	if (e) try {
		let t = o(e);
		if (!/\.(muz|md)$/.test(t) || t in q.files || t in q.assets) throw Error("Choose a new .muz or .md path.");
		q.files[t] = "", J = t, Sa(), Ta();
	} catch (e) {
		Ra(e);
	}
}, K("remove-file").onclick = () => {
	if (J === q.entry) return Z("Choose a different entry before removing this file.");
	confirm(`Remove ${J} from this project?`) && (delete q.files[J], delete q.assets[J], J = q.entry, Sa(), Ta());
}, K("compile").onclick = () => $(Aa), K("play").onclick = () => ia ? ja().catch(Ra) : $(ja), K("stop").onclick = () => Ea().catch(Ra), K("volume").oninput = () => {
	oa && oa.gain.setTargetAtTime(Number(K("volume").value) / 100, X.currentTime, .02);
}, K("open-link").onclick = () => K("link-dialog").showModal(), K("link-form").onsubmit = (e) => {
	e.preventDefault();
	let t = K("link-input").value;
	K("link-dialog").close(), $(() => za(t));
}, K("open-files").onclick = () => K("file-input").click(), K("open-folder").onclick = () => K("folder-input").click();
for (let e of ["file-input", "folder-input"]) K(e).onchange = () => $(async () => {
	let t = await u(K(e).files);
	K(e).value = "", await Da(t);
});
K("share").onclick = () => K("share-dialog").showModal(), K("share-embedded").onclick = () => La("embedded"), K("share-source").onclick = () => La("source"), K("share-super").onclick = () => La("super"), K("save-project").onclick = () => Fa(JSON.stringify(s(q), null, 2), Ia(".muzproject.json"), "application/json"), K("export-midi").onclick = () => $(async () => {
	(!Qi && $i === ea || await Aa()) && (Fa(await ba().call("midi"), Ia(".mid"), "audio/midi"), Z("MIDI exported by the muz engine."));
}), K("export-wav").onclick = () => $(async () => {
	la = new ha("./engine-worker.js"), da = () => la.close();
	try {
		Fa(await la.call("wav", {
			project: q,
			rate: 48e3
		}, 0, (e) => {
			Q(`Exporting WAV · ${Math.floor(e * 100)}%`);
		}), Ia(".wav"), "audio/wav"), Z("WAV exported · 48 kHz · stereo · PCM24"), Q("Export complete");
	} finally {
		la.close(), la = void 0;
	}
}), K("cancel").onclick = () => da?.(), K("new").onclick = () => $(async () => {
	confirm("Start a new project? Download Project first to keep a separate copy.") && await Da(await Va());
}), document.querySelectorAll("dialog .close").forEach((e) => e.onclick = () => e.closest("dialog").close()), document.addEventListener("keydown", (e) => {
	!e.ctrlKey && !e.metaKey || e.key.toLowerCase() !== "s" && e.key !== "Enter" || document.querySelector("dialog[open]") || (e.preventDefault(), e.key === "Enter" && ia ? ja().catch(Ra) : $(e.key === "Enter" ? ja : Aa));
}), document.addEventListener("dragover", (e) => {
	e.preventDefault(), document.body.classList.add("dragging");
}), document.addEventListener("dragleave", (e) => {
	e.relatedTarget || document.body.classList.remove("dragging");
}), document.addEventListener("drop", (e) => {
	e.preventDefault(), document.body.classList.remove("dragging"), e.dataTransfer.files.length && $(async () => Da(await u(e.dataTransfer.files)));
}), window.addEventListener("resize", Pa), window.addEventListener("hashchange", () => {
	location.hash && $(() => za(location.hash));
});
var Ba;
K("reference").onclick = () => $(async () => {
	Ba || (Ba = await fetch(new URL(new URL("src/app/assets/library.json", globalThis.__vitalityEmbedded.root).href, Zi)).then((e) => e.json()), Ba.forEach((e, t) => K("library").add(new Option(e.name, t))), K("library-source").textContent = Ba[0]?.source || ""), K("reference-dialog").showModal();
}), K("library").onchange = () => {
	K("library-source").textContent = Ba[Number(K("library").value)].source;
};
async function Va() {
	return s({
		title: "Untitled",
		entry: "song.muz",
		files: { "song.muz": await fetch(new URL(globalThis.__vitalityEmbedded.asset("src/app/assets/template.muz"), Zi)).then((e) => {
			if (!e.ok) throw Error("Missing bundled template.");
			return e.text();
		}) }
	});
}
try {
	let e = await fetch(new URL(new URL("src/app/assets/engine.json", globalThis.__vitalityEmbedded.root).href, Zi)).then((e) => e.json());
	K("engine-version").textContent = e.revision.slice(0, 7), K("provenance").textContent = `Engine ${e.revision}${e.local ? " · local source" : " · pinned upstream"}${e.dirty ? " · includes local edits" : ""}. Built without desktop features. No runtime CDN or proxy.`;
	let t = location.hash, n = new URL(location.href).searchParams, r = await wa().catch(() => {});
	q = s(r || await Va()), J = q.entry, Sa();
	let i = n.get("source") || n.get("url") || (n.get("gist") ? "https://gist.github.com/unknown/" + n.get("gist") : t);
	i ? await $(() => za(i)) : (Z(r ? "Local draft restored." : "Ready. Edit the bundled muz template, or open a project."), Q("Local workspace"));
} catch (e) {
	Ra(e);
}""")
            ]
        ]
    ]

let render() =
    page |> Giraffe.ViewEngine.RenderView.AsString.htmlDocument
