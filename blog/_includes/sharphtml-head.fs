module Imported.Includes.HeadHtml

let file = """<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">

  {%- seo -%}

  <link rel="stylesheet" href="{{ '/assets/css/style.css' | relative_url }}">

  {%- feed_meta -%}

  {%- if jekyll.environment == 'production' and site.google_analytics -%}
    {%- include google-analytics.html -%}
  {%- endif -%}

  <!-- Favicon -->
  <link rel="icon" type="image/png" href="{{ '/assets/images/shel-turt-256.png' | relative_url }}">
  <link rel="apple-touch-icon" href="{{ '/assets/images/shel-turt-sq.png' | relative_url }}">

  <!-- Preconnect for external assets -->
  <link rel="preconnect" href="https://cdn.jsdelivr.net" crossorigin>

  {%- include custom-head.html -%}
</head>
"""

let render() = file
