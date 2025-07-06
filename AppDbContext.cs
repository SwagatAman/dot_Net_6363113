// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; // Make sure this using directive is present

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies().UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=RetailInventoryDb;Trusted_Connection=True;"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Always call the base method

        // Seed Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Groceries" }
        );

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Smartphone", Price = 25000M, CategoryId = 1, StockQuantity = 50 },
            new Product { Id = 2, Name = "Wheat Flour", Price = 800M, CategoryId = 2, StockQuantity = 100 }
        );

    }
    
}