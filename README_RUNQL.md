# RunQL Project

This project uses RunQL for SQL workflows and schema exploration.

## Setup

1. **Git Configuration**:
   The `RunQL/system/` directory contains generated system files and indices that usually do not need to be committed to version control.

   Recommended `.gitignore` entry:
   ```gitignore
   RunQL/system/
   ```

   *Note: `RunQL/queries/` and `RunQL/schemas/` SHOULD be committed as they contain your source artifacts.*

## Folder Structure

- **RunQL/queries/**: Saved SQL queries.
- **RunQL/queries/<connection>/**: Saved SQL queries grouped by connection. Queries may join across schemas.
- **RunQL/schemas/<connection>/manifest.json**: Lists schema bundles for a connection.
- **RunQL/schemas/<connection>/<schema>/**: Per-schema schema bundle including descriptions and ERD files.
- **RunQL/system/**: generated indexes, migration backups, and prompts (optional to commit).
