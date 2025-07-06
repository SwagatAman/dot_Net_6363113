# Lab 1: Understanding ORM with a Retail Inventory System

## 1. What is ORM?

Object-Relational Mapping (ORM) is a technique that allows me to map C# classes to database tables. With ORM, each class in my application corresponds to a table in the database, and each property of the class maps to a column in that table. This abstraction lets me work with data as objects, rather than writing raw SQL queries.

**Benefits of ORM:**
- **Productivity:** I can focus on business logic instead of repetitive SQL code.
- **Maintainability:** Changes in the data model are easier to manage since they are reflected in the codebase.
- **Abstraction:** ORM shields me from database-specific SQL, making the code more portable and less error-prone.

## 2. EF Core vs EF Framework

Entity Framework (EF) is Microsoft's ORM for .NET. There are two main versions:

- **EF Core:**  
  - Cross-platform (works on Windows, Linux, macOS).
  - Lightweight and modular.
  - Supports modern features like LINQ, async queries, and compiled queries.
  - Actively developed with new features and performance improvements.

- **EF Framework (EF6):**  
  - Windows-only.
  - More mature and stable for legacy applications.
  - Less flexible and lacks some modern features found in EF Core.

For new projects, especially those targeting .NET 6+ or cross-platform environments, I prefer EF Core.

## 3. EF Core 8.0 Features

EF Core 8.0 introduces several enhancements:

- **JSON Column Mapping:**  
  I can now map C# objects directly to JSON columns in the database, making it easier to store and query semi-structured data.

- **Improved Performance with Compiled Models:**  
  EF Core 8.0 allows me to pre-compile the data model, reducing startup time and improving runtime performance.

- **Interceptors and Better Bulk Operations:**  
  Interceptors let me hook into EF Core's operations for logging, auditing, or custom logic. Bulk operations are now more efficient, making large data updates and inserts faster.

---

This lab helped me understand how ORM and EF Core simplify data access in a retail inventory system, making my codebase cleaner and more maintainable.
