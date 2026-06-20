module Imported.Posts.N20250901ShelSchemaDeepDiveMd

let file = """---
layout: post
title: "Deep Dive: sHEL's Schema System"
author: "sHEL Team"
date: 2025-09-01 14:00:00 +0000
tags: [technical, schema, deep-dive]
---

One of sHEL's most powerful features is its schema system. In this post, we'll explore how sHEL schemas work and why they're different from traditional approaches.

## Schema as Contract

In sHEL, a schema isn't just validation — it's a **contract** between producer and consumer. When you define a schema, you're specifying:

- The exact structure of the data
- Literal constraints (no injection possible)
- Transformation rules
- Pipeline compatibility

## Defining Schemas

sHEL schemas are written in sHEL's own schema definition language:

```shel
schema User {
  id: uuid,
  name: literal<string>,
  email: literal<string>,
  role: enum("admin", "user", "guest"),
  created_at: timestamp
}
```

Notice the `literal<>` wrapper — this is the key. Any data passing through this schema is guaranteed to be treated as a literal value, never as executable code.

## Validation Pipeline

Schemas integrate directly into pipelines:

```bash
# Validate incoming data against schema
cat users.json | shel validate --schema User | shel transform --to csv
```

If validation fails, sHEL provides detailed error messages with line numbers and context.

## Performance

Schema validation in sHEL is fast. Really fast. Our benchmarks show:

| Dataset Size | Validation Time | Memory Usage |
|-------------|----------------|--------------|
| 1K records  | 0.3ms          | 2MB          |
| 100K records| 12ms           | 8MB          |
| 10M records | 890ms          | 128MB        |

## Next Steps

Read the [full schema documentation]({{ site.docs_url }}/schema-reference/) for advanced features like conditional validation, custom types, and schema composition.

Have questions? Join us on [Slack](https://slack.shel.sh) or open a [GitHub discussion](https://github.com/CommanderTurtle/docs-pages/discussions).
"""

let render() = file
