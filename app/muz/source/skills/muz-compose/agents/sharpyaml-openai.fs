module Muz.Source.Skills.MuzCompose.Agents.OpenaiYaml

let file = """interface:
  display_name: "muz composition studio"
  short_description: "Compose native .muz with compiler and musical evidence"
  default_prompt: "Use $muz-compose to plan, compose, check and refine an editable native .muz piece."
"""

let render() = file
