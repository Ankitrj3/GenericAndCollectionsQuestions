using System;
using System.Linq;
using System.Collections.Generic;
public interface IProduct
{
    string Name { get; set; }
    string Category { get; set; }
    int Stock { get; set; }
    int Price { get; set; }
}
public interface IInventory
{
    void AddProduct(IProduct product);
    void RemoveProduct(IProduct product);
    int CalculateTotalValue();
    List<IProduct> GetProductsByCategory(string category);
    List<IProduct> SearchProductsByName(string name);
    List<(string, int)> GetProductsByCategoryWithCount();
    List<(string, List<IProduct>)> GetAllProductsByCategory();
}
public class Product : IProduct
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public Product(){}
}
public class Inventory : IInventory
{
    private List<IProduct> _product = new List<IProduct>();
    public void AddProduct(IProduct product)
    {
        _product.Add(product);
    }
    public void RemoveProduct(IProduct product)
    {
        var Delete = _product.FirstOrDefault(s => s.Name == product.Name);
        _product.Remove(Delete);
    }
    public int CalculateTotalValue()
    {
        return _product.Sum(s => s.Price * s.Stock);
    }
    public List<IProduct> GetProductsByCategory(string category)
    {
        return _product.Where(x => x.Category == category)
                       .ToList();
    }
    public List<IProduct> SearchProductsByName(string name)
    {
        return _product.Where(x => x.Name == name)
                       .ToList();
    }
    public List<(string, int)> GetProductsByCategoryWithCount()
    {
        return _product.GroupBy(x => x.Category)
                       .Select(x => (x.Key, x.Count()))
                       .ToList();
    }
    public List<(string, List<IProduct>)> GetAllProductsByCategory()
    {
        return _product.GroupBy(x => x.Category)
                       .Select(g => (g.Key, g.ToList()))
                       .ToList();
    }
}
public class Program
{
    public static void Main()
    {
        IInventory inventory = new Inventory();

        // Create products
        IProduct p1 = new Product
        {
            Name = "Computer",
            Category = "Technology",
            Stock = 2,
            Price = 272
        };

        IProduct p2 = new Product
        {
            Name = "Refrigerator",
            Category = "HomeAppliances",
            Stock = 3,
            Price = 204
        };

        IProduct p3 = new Product
        {
            Name = "WashingMachine",
            Category = "HomeAppliances",
            Stock = 5,
            Price = 390
        };

        // Add products
        inventory.AddProduct(p1);
        inventory.AddProduct(p2);
        inventory.AddProduct(p3);

        // Products by Category
        Console.WriteLine("HomeAppliances:");
        foreach (var p in inventory.GetProductsByCategory("HomeAppliances"))
        {
            Console.WriteLine($"Product Name:{p.Name} Category:{p.Category}");
        }

        // Calculate total value
        int totalValue = inventory.CalculateTotalValue();
        Console.WriteLine($"Total Value:{totalValue}");

        // Products count by category
        Console.WriteLine("\nCategory Count:");
        foreach (var (category, count) in inventory.GetProductsByCategoryWithCount())
        {
            Console.WriteLine($"{category}:{count}");
        }

        // All products grouped by category
        Console.WriteLine("\nAll Products By Category:");
        foreach (var (category, products) in inventory.GetAllProductsByCategory())
        {
            Console.WriteLine($"{category}:");
            foreach (var p in products)
            {
                Console.WriteLine($"Product Name:{p.Name} Price:{p.Price}");
            }
        }

        // Search product by name
        Console.WriteLine("\nSearch Result:");
        foreach (var p in inventory.SearchProductsByName("Computer"))
        {
            Console.WriteLine($"Product Name:{p.Name} Price:{p.Price}");
        }

        // Remove product
        inventory.RemoveProduct(p2);

        Console.WriteLine("\nAfter Removing Refrigerator:");
        foreach (var (category, products) in inventory.GetAllProductsByCategory())
        {
            Console.WriteLine($"{category}:");
            foreach (var p in products)
            {
                Console.WriteLine($"Product Name:{p.Name}");
            }
        }
    }
}
