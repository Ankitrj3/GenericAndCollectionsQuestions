// Question 17: Inventory Stock Management
// Scenario: A warehouse needs to manage product inventory and track stock movements.
// Requirements:
// csharp
// // In class Product:
// // - string ProductCode
// // - string ProductName
// // - string Category
// // - string Supplier
// // - double UnitPrice
// // - int CurrentStock
// // - int MinimumStockLevel

// // In class StockMovement:
// // - int MovementId
// // - string ProductCode
// // - DateTime MovementDate
// // - string MovementType (In/Out)
// // - int Quantity
// // - string Reason (Purchase/Sale/Return)

// // In class InventoryManager:
// public void AddProduct(string code, string name, string category,
//                       string supplier, double price, int stock, int minLevel)
// public bool UpdateStock(string productCode, string movementType,
//                        int quantity, string reason)
// public Dictionary<string, List<Product>> GroupProductsByCategory()
// public List<Product> GetLowStockProducts()
// public Dictionary<string, int> GetStockValueByCategory()
// Use Cases:
// •	Add products with stock levels
// •	Update stock (in/out movements)
// •	Group products by category
// •	Identify low-stock items
// •	Calculate inventory value
using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager
{
    public static Dictionary<string, Product> productDetails = new Dictionary<string, Product>();
    public static Dictionary<int, StockMovement> stockDetails = new Dictionary<int, StockMovement>();
    public static int counter = 1;

    public void AddProduct(string code, string name, string category, string supplier, double price, int stock, int minLevel)
    {
        Product product = new Product()
        {
            ProductCode = code,
            ProductName = name,
            Category = category,
            Supplier = supplier,
            UnitPrice = price,
            CurrentStock = stock,
            MinimumStockLevel = minLevel
        };
        productDetails.Add(product.ProductCode, product);
    }

    public bool UpdateStock(string productCode, string movementType, int quantity, string reason)
    {
        if (!productDetails.ContainsKey(productCode))
        {
            Console.WriteLine("Product Code is not Valid");
            return false;
        }

        Product product = productDetails[productCode];

        if (movementType == "In")
        {
            product.CurrentStock += quantity;
        }
        else if (movementType == "Out")
        {
            if (product.CurrentStock < quantity)
            {
                Console.WriteLine("Insufficient stock");
                return false;
            }
            product.CurrentStock -= quantity;
        }
        else
        {
            Console.WriteLine("Invalid Movement Type");
            return false;
        }

        StockMovement stockMovement = new StockMovement()
        {
            MovementId = counter++,
            ProductCode = productCode,
            MovementDate = DateTime.Now,
            MovementType = movementType,
            Quantity = quantity,
            Reason = reason
        };

        stockDetails.Add(stockMovement.MovementId, stockMovement);
        return true;
    }

    public Dictionary<string, List<Product>> GroupProductsByCategory()
    {
        Dictionary<string, List<Product>> result = new Dictionary<string, List<Product>>();

        foreach (var item in productDetails)
        {
            var pro = item.Value;
            if (!result.ContainsKey(pro.Category))
            {
                result[pro.Category] = new List<Product>();
            }
            result[pro.Category].Add(pro);
        }
        return result;
    }

    public List<Product> GetLowStockProducts()
    {
        return productDetails.Values
                             .Where(p => p.CurrentStock <= p.MinimumStockLevel)
                             .ToList();
    }

    public Dictionary<string, int> GetStockValueByCategory()
    {
        return productDetails.Values
                             .GroupBy(p => p.Category)
                             .ToDictionary(
                                 g => g.Key,
                                 g => g.Sum(p => (int)(p.UnitPrice * p.CurrentStock))
                             );
    }
}
