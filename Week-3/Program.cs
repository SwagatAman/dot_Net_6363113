// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Starting Lab 10: Eager, Lazy, and Explicit Loading...");

        using (var context = new AppDbContext())
        {
            Console.WriteLine("\n--- Eager Loading: Products with Categories ---");
            var productsEager = await context.Products
                .Include(p => p.Category)
                .ToListAsync();

            foreach (var p in productsEager)
            {
                Console.WriteLine($"Product: {p.Name}, Price: ₹{p.Price}, Category: {p.Category?.Name ?? "N/A"}");
            }
            Console.WriteLine("Eager loading completed.");


            Console.WriteLine("\n--- Explicit Loading: Single Product's Category ---");
            var firstProduct = await context.Products.FirstAsync();
            Console.WriteLine($"Product: {firstProduct.Name} (Category initially not loaded)");

            await context.Entry(firstProduct)
                         .Reference(p => p.Category)
                         .LoadAsync();

            Console.WriteLine($"Product: {firstProduct.Name}, Category: {firstProduct.Category?.Name ?? "N/A"} (Category explicitly loaded)");
            Console.WriteLine("Explicit loading completed.");


            Console.WriteLine("\n--- Lazy Loading (if enabled) ---");
            Console.WriteLine("Ensure you followed the Lazy Loading setup steps if you want to see this in action.");

            var lazyProduct = await context.Products.FirstOrDefaultAsync();

            if (lazyProduct != null)
            {
                Console.WriteLine($"Product: {lazyProduct.Name} (Category will be loaded on access)");
                Console.WriteLine($"Product: {lazyProduct.Name}, Category: {lazyProduct.Category?.Name ?? "N/A"} (Category accessed, lazy loaded)");
            }
            Console.WriteLine("Lazy loading attempt completed.");

        }

        Console.WriteLine("\nLab 10 Data Loading Strategies Finished.");
        Console.ReadKey();
    }
}