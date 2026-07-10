# Lab 5: Retrieving Data from the Database

This lab demonstrates how to query the database using standard C# LINQ methods instead of raw `SELECT` queries.

## 1. Retrieve All Products
Using `ToListAsync()` fetches all records from the table into a C# List.

```csharp
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// Example inside Main method
var products = await context.Products.ToListAsync(); 
Console.WriteLine("--- All Products ---");
foreach (var p in products) 
{
    Console.WriteLine($"{p.Name} - ₹{p.Price}"); 
}
```

## 2. Find by ID
The `FindAsync()` method is the most efficient way to retrieve a single record by its Primary Key.

```csharp
var product = await context.Products.FindAsync(1); 
if (product != null)
{
    Console.WriteLine($"\n--- Found via ID ---");
    Console.WriteLine($"Found: {product.Name}"); 
}
```

## 3. FirstOrDefault with Condition
`FirstOrDefaultAsync()` is used when you need to find a specific record based on a custom LINQ condition (like checking the price).

```csharp
// Finds the first product in the database that costs more than 50,000
var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000); 
if (expensive != null)
{
    Console.WriteLine($"\n--- Expensive Product ---");
    Console.WriteLine($"Expensive: {expensive.Name}");
}
```
