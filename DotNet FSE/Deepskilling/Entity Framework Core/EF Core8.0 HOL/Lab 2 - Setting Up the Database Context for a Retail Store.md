# Lab 2: Setting Up the Database Context for a Retail Store

In this lab, we configure our C# Models and the `DbContext` which acts as the official bridge connecting our C# application to SQL Server.

## 1. Create Models
We define `Category` and `Product` classes. Notice the 1-to-Many relationship (One Category has many Products).

```csharp
using System.Collections.Generic;

public class Category 
{ 
    public int Id { get; set; } 
    public string Name { get; set; } 
    
    // Navigation property mapping to Products
    public List<Product> Products { get; set; } 
} 

public class Product 
{ 
    public int Id { get; set; } 
    public string Name { get; set; } 
    public decimal Price { get; set; } 
    
    // Foreign Key mapping
    public int CategoryId { get; set; } 
    
    // Navigation property mapping back to Category
    public Category Category { get; set; } 
}
```

## 2. Create AppDbContext
The `AppDbContext` inherits from Entity Framework's `DbContext` and exposes our tables via `DbSet`.

```csharp
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext 
{ 
    public DbSet<Product> Products { get; set; } 
    public DbSet<Category> Categories { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
        // We configure EF Core to use SQL Server with a standard connection string
        optionsBuilder.UseSqlServer("Server=localhost;Database=RetailInventoryDb;Trusted_Connection=True;TrustServerCertificate=True;"); 
    } 
}
```

## 3. Configuration Notes
While we hardcoded the connection string inside `OnConfiguring` for this simple console app, best practice for ASP.NET Core applications is to add the Connection String inside the `appsettings.json` file to keep secrets secure!
