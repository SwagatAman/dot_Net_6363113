using System;
using System.Collections.Generic;

namespace EcommerceSearch
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
    }

    public class SearchAlgorithms
    {
        public static Product LinearSearch(Product[] products, int productId)
        {
            foreach (var product in products)
            {
                if (product.ProductId == productId)
                    return product;
            }
            return null;
        }

        public static Product BinarySearch(Product[] products, int productId)
        {
            int left = 0, right = products.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (products[mid].ProductId == productId)
                    return products[mid];
                else if (products[mid].ProductId < productId)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product { ProductId = 3, ProductName = "Laptop", Category = "Electronics" },
                new Product { ProductId = 1, ProductName = "Shirt", Category = "Clothing" },
                new Product { ProductId = 2, ProductName = "Book", Category = "Book" }
            };

            Array.Sort(products, (a, b) => a.ProductId.CompareTo(b.ProductId));

            var foundLinear = SearchAlgorithms.LinearSearch(products, 2);
            if (foundLinear != null)
                Console.WriteLine(foundLinear.ProductName);

            var foundBinary = SearchAlgorithms.BinarySearch(products, 2);
            if (foundBinary != null)
                Console.WriteLine(foundBinary.ProductName);
        }
    }
}
