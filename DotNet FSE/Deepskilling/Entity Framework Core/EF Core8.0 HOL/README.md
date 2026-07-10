# Entity Framework Core 8.0 - Hands-On Labs (HOL)
 
This directory contains the completed theoretical and practical assignments for building an Object-Relational Mapping (ORM) Retail Inventory System.

## Project Structure
The assignment has been carefully separated into 5 distinct lab files for easy grading and review:

*   **Lab 1 - Understanding ORM with a Retail Inventory System.md**
    *   *Covers:* ORM definitions, EF Core vs EF6 Framework comparisons, EF Core 8.0 features, and `.NET CLI` package installation commands.
*   **Lab 2 - Setting Up the Database Context for a Retail Store.md**
    *   *Covers:* C# Entity Models (`Category` and `Product`), establishing 1-to-Many relationships, and creating the `AppDbContext` to connect to SQL Server.
*   **Lab 3 - Using EF Core CLI to Create and Apply Migrations.md**
    *   *Covers:* Installing the `dotnet-ef` global tool and executing Migrations to physically create the SQL Server database schema.
*   **Lab 4 - Inserting Initial Data into the Database.md**
    *   *Covers:* Instantiating the database context in C#, tracking objects with `AddRangeAsync`, and executing transactions via `SaveChangesAsync`.
*   **Lab 5 - Retrieving Data from the Database.md**
    *   *Covers:* Querying the database using standard C# LINQ methods such as `ToListAsync`, `FindAsync`, and `FirstOrDefaultAsync`.

## Technology Stack
*   **C# / .NET 8.0**
*   **Entity Framework Core 8.0**
*   **Microsoft SQL Server**
