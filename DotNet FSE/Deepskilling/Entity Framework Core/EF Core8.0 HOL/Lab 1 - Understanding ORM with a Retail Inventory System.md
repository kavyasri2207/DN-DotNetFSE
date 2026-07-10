# Lab 1: Understanding ORM with a Retail Inventory System

## 1. What is ORM?
**ORM (Object-Relational Mapping)** is a technique that lets you query and manipulate data from a database using an object-oriented paradigm. 
- **How it works:** It maps C# classes (Models) directly to database tables, and maps class properties to table columns.
- **Benefits:**
  - **Productivity:** Developers write clean C# code instead of raw SQL strings.
  - **Maintainability:** Strongly typed code means errors are caught immediately at compile time.
  - **Abstraction:** It hides complex SQL syntax, allowing developers to switch underlying databases (e.g., from SQL Server to PostgreSQL) with minimal code changes.

## 2. EF Core vs EF Framework
- **EF Core (Entity Framework Core):** A modern, cross-platform, lightweight, and open-source version of EF. It runs on Windows, Mac, and Linux. It supports modern features like async queries, compiled queries, and LINQ.
- **EF Framework (EF6):** The legacy, older version of Entity Framework. It is mature and feature-rich but is strictly tied to Windows (.NET Framework) and is much heavier and less flexible.

## 3. EF Core 8.0 Features
- **JSON Column Mapping:** Allows mapping a C# object directly to a JSON column in SQL Server seamlessly.
- **Improved Performance:** Faster query translations and massively improved compiled models for speed.
- **Bulk Operations:** Better support for `ExecuteUpdate` and `ExecuteDelete` without needing to load entities into memory first.

## 4. Creating the .NET Console App
To initialize the project, run these commands in your terminal:
```bash
dotnet new console -n RetailInventory
cd RetailInventory
```

## 5. Installing EF Core Packages
To connect to SQL Server and use the Migration tools, install these packages via the terminal:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```
