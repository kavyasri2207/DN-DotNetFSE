# Agent Guidance

This repo stores SQL, schemas, and ERD metadata in known locations. When a user asks for SQL, look for existing artifacts first, then use schema and documentation to build something new only if needed.

## Source Locations

- Existing queries: `RunQL/queries/` (may include subdirectories).
- Query index: `RunQL/system/queries/queryIndex.json` (this is auto updated when a query is saved)
- Connection-scoped queries: `RunQL/queries/<connection>/`
- Schema manifest: `RunQL/schemas/<connection>/manifest.json`
- Schema bundles: `RunQL/schemas/<connection>/<schema>/`

## Required Workflow (SQL Queries)

1. Search for existing queries first.
   - Check `RunQL/system/queries/queryIndex.json`, then `RunQL/queries/<connection>/` (including subdirectories).
2. If nothing relevant exists, read the schema and docs.
   - Use `RunQL/schemas/<connection>/manifest.json` to find available schemas.
   - Read only the relevant `RunQL/schemas/<connection>/<schema>/schema.json` and `description.json`.
   - For cross-schema SQL, read only the referenced schema folders.
   - Ignore `RunQL/schemas/deleted/` and `*_deleted` folders unless the user explicitly asks for archived or deleted content.
3. Only then should you create a new SQL query file (.sql)
   - Prefer to reuse or extend existing patterns when possible.
   - Put saved SQL under `RunQL/queries/<connection>/`, not under schema folders.

## Required Workflow (Documentation Requests)

1. SQL Query Documentation:
   - If a user asks you to document an SQL query, follow the prompt in `RunQL/system/prompts/markdownDoc.txt`.
   - Output the file in the exact same directory as the query with the same name but a different extension.
   - Example: `olympic_gold.sql` -> `olympic_gold.md`.
2. Schema Description:
   - If a user asks you to describe a schema, follow the prompt in `RunQL/system/prompts/describeSchema.txt`.
   - Output the results to the matching schema bundle folder inside `RunQL/schemas/<connection>/<schema>/`.
   - Example: `RunQL/schemas/Production/billing/description.json`.
3. Inline Comments:
   - If a user asks you to create inline comments on an SQL file, follow the prompt in `RunQL/system/prompts/inlineComments.txt`.

## Notes

- If an existing query partially answers the request, adapt it rather than starting from scratch.
- Keep outputs consistent with the repository's established conventions and naming.
