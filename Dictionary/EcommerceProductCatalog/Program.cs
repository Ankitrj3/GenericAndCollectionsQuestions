// Question 5: E-commerce Product Catalog
// Scenario: An e-commerce store needs to manage products and categorize them for customers.
// Requirements:
// csharp
// // In class Product:
// // - string ProductCode
// // - string ProductName
// // - string Category (Electronics/Clothing/Books)
// // - double Price
// // - int StockQuantity

// // In class InventoryManager:
// public void AddProduct(string name, string category, double price, int stock)
// // Auto-generate ProductCode (P001, P002...)

// public SortedDictionary<string, List<Product>> GroupProductsByCategory()
// // Groups products by category

// public bool UpdateStock(string productCode, int quantity)
// // Updates stock, returns false if insufficient stock

// public List<Product> GetProductsBelowPrice(double maxPrice)
// // Returns products below specified price
// public Dictionary<string, int> GetCategoryStockSummary()
// // Returns total stock quantity per category
// Sample Use Cases:
// 1.	Add products to different categories
// 2.	Display products grouped by category
// 3.	Update stock after sales
// 4.	Find products under budget
// 5.	Show inventory summary

using System.Diagnostics.Metrics;
using System.Net.Sockets;

public class Product
{
    public string ProductCode{get; set;}
    public string ProductName{get; set;}
    public string Category{get; set;}
    public double Price{get; set;}
    public int StockQuantity{get; set;}
    public Product(){}
}
public class InventoryManager
{
    public static SortedDictionary<string, Product> productDetails = new SortedDictionary<string, Product>();
    public static int counter = 1;
    public void AddProduct(string name, string category, double price, int stock)
    {
        Product product = new Product()
        {
            ProductCode = "P"+counter.ToString("D3"),
            ProductName = name,
            Category = category,
            Price = price,
            StockQuantity = stock
        };
        productDetails.Add(product.ProductCode, product);
        counter++;
    }
    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        SortedDictionary<string, List<Product>> result = new SortedDictionary<string, List<Product>>();
        foreach(var item in productDetails)
        {
            Product product = item.Value;
            if (!result.ContainsKey(product.Category))
            {
                result[product.Category] = new List<Product>(); 
            }
            result[product.Category].Add(product);
        }
        return result;
    }
    public bool UpdateStock(string productCode, int quantity)
    {
        if (!productDetails.ContainsKey(productCode))
        {
            return false;
        }
        Product product = productDetails[productCode];
        if(product.StockQuantity < quantity)
        {
            return false;
        }
        product.StockQuantity -= quantity;
        return true;
    }
    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        List<Product> result = new List<Product>();
        foreach(var item in productDetails)
        {
            Product product = item.Value;
            if(product.Price < maxPrice)
            {
                result.Add(product);
            }
        }
        return result;
    }
    public Dictionary<string, int> GetCategoryStockSummary()
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach(var item in productDetails)
        {
            Product product = item.Value;
            if (!result.ContainsKey(product.Category))
            {
                result[product.Category] = 0;
            }
            result[product.Category] += product.StockQuantity;
        }
        return result;
    }
}
class Program
{
    public static void Main()
    {
        InventoryManager inventory = new InventoryManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Product");
            Console.WriteLine("2. Display Products Grouped By Category");
            Console.WriteLine("3. Update Stock After Sale");
            Console.WriteLine("4. Find Products Below Price");
            Console.WriteLine("5. Show Category Stock Summary");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 6)
            {
                Console.WriteLine("Exiting application...");
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine()!;

                    Console.Write("Enter Category (Electronics/Clothing/Books): ");
                    string category = Console.ReadLine()!;

                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine()!);

                    Console.Write("Enter Stock Quantity: ");
                    int stock = int.Parse(Console.ReadLine()!);

                    inventory.AddProduct(name, category, price, stock);
                    Console.WriteLine("Product added successfully!");
                    break;

                case 2:
                    SortedDictionary<string, List<Product>> grouped =
                        inventory.GroupProductsByCategory();

                    foreach (var item in grouped)
                    {
                        Console.WriteLine($"\nCategory: {item.Key}");
                        foreach (var product in item.Value)
                        {
                            Console.WriteLine(
                                $"{product.ProductCode} - {product.ProductName} - ₹{product.Price} - Stock: {product.StockQuantity}");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Product Code: ");
                    string code = Console.ReadLine()!;

                    Console.Write("Enter Quantity Sold: ");
                    int qty = int.Parse(Console.ReadLine()!);

                    bool updated = inventory.UpdateStock(code, qty);

                    if (updated)
                        Console.WriteLine("Stock updated successfully!");
                    else
                        Console.WriteLine("Insufficient stock or invalid product code.");
                    break;

                case 4:
                    Console.Write("Enter Maximum Price: ");
                    double maxPrice = double.Parse(Console.ReadLine()!);

                    List<Product> products =
                        inventory.GetProductsBelowPrice(maxPrice);

                    if (products.Count == 0)
                    {
                        Console.WriteLine("No products found under this price.");
                        break;
                    }

                    foreach (var product in products)
                    {
                        Console.WriteLine(
                            $"{product.ProductCode} - {product.ProductName} - ₹{product.Price}");
                    }
                    break;

                case 5:
                    Dictionary<string, int> summary =
                        inventory.GetCategoryStockSummary();

                    Console.WriteLine("\nCategory Stock Summary:");
                    foreach (var item in summary)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
