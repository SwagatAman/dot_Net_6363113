// Category.cs
using System.Collections.Generic;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual List<Product> Products { get; set; } = new List<Product>();
}