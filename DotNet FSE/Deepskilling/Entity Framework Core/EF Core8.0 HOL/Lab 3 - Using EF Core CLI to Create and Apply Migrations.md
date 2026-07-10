# Lab 3: Using EF Core CLI to Create and Apply Migrations

Once the `AppDbContext` and Models are defined, we need to physically create the SQL Server database. We use **Migrations** to automatically generate the SQL based on our C# code.

## 1. Install EF Core CLI
If not already installed globally on your machine, run this command to install the Entity Framework Core CLI tools:
```bash
dotnet tool install --global dotnet-ef
```

## 2. Create Initial Migration
This command takes a snapshot of your `AppDbContext` and generates a `Migrations` folder containing the C# code necessary to build the database schema.
```bash
dotnet ef migrations add InitialCreate
```

## 3. Apply Migration to Create Database
This command translates the migration files into raw SQL and executes it against the SQL Server to physically create the database and tables.
```bash
dotnet ef database update
```

## 4. Verification
If you open **SQL Server Management Studio (SSMS)** or Azure Data Studio and refresh your Databases, you will now see `RetailInventoryDb` successfully created, containing the newly generated `Products` and `Categories` tables!
