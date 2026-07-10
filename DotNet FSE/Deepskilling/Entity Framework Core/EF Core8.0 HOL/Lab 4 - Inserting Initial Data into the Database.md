# Lab 4: Inserting Initial Data into the Database

This lab demonstrates how to add data to the database using EF Core instead of writing manual `INSERT INTO` SQL statements.

## 1. Insert Data in Program.cs
We instantiate our `AppDbContext`, create C# objects, and use `AddRangeAsync` to track them. Calling `SaveChangesAsync()` executes the transaction.

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // 1. Initialize Context
        using var context = new AppDbContext(); 
        
        // 2. Create Categories
        var electronics = new Category { Name = "Electronics" }; 
        var groceries = new Category { Name = "Groceries" }; 
        await context.Categories.AddRangeAsync(electronics, groceries); 
        
        // 3. Create Products and map them to the Categories
        var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics }; 
        var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries }; 
        await context.Products.AddRangeAsync(product1, product2); 
        
        // 4. Save to SQL Server Database
        await context.SaveChangesAsync(); 
        
        Console.WriteLine("Successfully inserted initial data into the database!");
    }
}
```

## 2. Run the App
To execute the C# code and insert the data into the live database, run:
```bash
dotnet run
```

## 3. Verification
If you query `SELECT * FROM Products` inside SQL Server Management Studio, you will see the `Laptop` and `Rice Bag` records successfully inserted with their respective `CategoryId` foreign keys!
