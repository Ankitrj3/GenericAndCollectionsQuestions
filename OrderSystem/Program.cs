public interface IOrder
{
    int OrderId { get; set; }
    string ProductName { get; set; }
    string Category { get; set; }
    int Price { get; set; }
}
public interface IOrderSystem
{
    void PlaceOrder(IOrder order, int quantity);
    void CancelOrder(IOrder order, int quantity);

    int CalculateTotalAmount();

    List<(string, int, int)> OrderInfo();
    List<(string, int)> CategoryTotalAmount();
    List<(string, int)> CategoryWiseOrderCount();
}
public class Order : IOrder
{
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public int Price { get; set; }
    public Order(){}
}
public class OrderSystem : IOrderSystem
{
    private Dictionary<IOrder,int> _order = new Dictionary<IOrder, int>();
    public void PlaceOrder(IOrder order, int quantity)
    {
        if (_order.ContainsKey(order))
        {
            _order[order] += quantity;
        }
        else
        {
            _order.Add(order,quantity);
        }
    }
    public void CancelOrder(IOrder order, int quantity)
    {
        if (!_order.ContainsKey(order))
        {
            Console.WriteLine("No order is There!!!");
            return;
        }
        _order[order] -= quantity;
        if(_order[order] <= 0)
        {
            _order.Remove(order);
        }
    }
    public int CalculateTotalAmount()
    {
        return _order.Sum(x => x.Key.Price * x.Value);
    }
    public List<(string, int, int)> OrderInfo()
    {
        return _order.Select(x => (x.Key.ProductName, x.Value, x.Key.Price))
                     .ToList();
    }
    public List<(string, int)> CategoryTotalAmount()
    {
        return _order.GroupBy(s => s.Key.Category)
                     .Select(g => (g.Key, g.Sum(x => x.Key.Price * x.Value)))
                     .ToList();
    }
    public List<(string, int)> CategoryWiseOrderCount()
    {
        return _order.GroupBy( s=> s.Key.Category)
                     .Select(g => (g.Key, g.Sum(x => x.Value)))
                     .ToList();
    }
}
public class Program
{
    public static void Main()
    {
        // Create OrderSystem
        IOrderSystem orderSystem = new OrderSystem();

        // Create Orders
        IOrder order1 = new Order
        {
            OrderId = 101,
            ProductName = "Laptop",
            Category = "Electronics",
            Price = 50000
        };

        IOrder order2 = new Order
        {
            OrderId = 102,
            ProductName = "Mobile",
            Category = "Electronics",
            Price = 20000
        };

        IOrder order3 = new Order
        {
            OrderId = 103,
            ProductName = "Chair",
            Category = "Furniture",
            Price = 3000
        };

        // Place Orders
        orderSystem.PlaceOrder(order1, 2);
        orderSystem.PlaceOrder(order2, 3);
        orderSystem.PlaceOrder(order3, 4);

        // ----- OUTPUT CHECK -----

        Console.WriteLine("Order Info:");
        foreach (var (product, quantity, price) in orderSystem.OrderInfo())
        {
            Console.WriteLine($"Product:{product}, Quantity:{quantity}, Price:{price}");
        }

        Console.WriteLine("\nCategory Total Amount:");
        foreach (var (category, totalAmount) in orderSystem.CategoryTotalAmount())
        {
            Console.WriteLine($"Category:{category}, Total Amount:{totalAmount}");
        }

        Console.WriteLine("\nCategory Wise Order Count:");
        foreach (var (category, count) in orderSystem.CategoryWiseOrderCount())
        {
            Console.WriteLine($"Category:{category}, Total Quantity:{count}");
        }

        int total = orderSystem.CalculateTotalAmount();
        Console.WriteLine($"\nTotal Order Amount: {total}");
    }
}
