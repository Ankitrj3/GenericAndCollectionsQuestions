// Question 4: Restaurant Menu Management
// Scenario: A restaurant needs to manage menu items and categorize them by course.
// Requirements:
// csharp
// // In class MenuItem:
// // - string ItemName
// // - string Category (Appetizer/Main Course/Dessert)
// // - double Price
// // - bool IsVegetarian

// // In class MenuManager:
// public void AddMenuItem(string name, string category, double price, bool isVeg)
// // Adds item with validation for price > 0

// public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
// // Groups items by category

// public List<MenuItem> GetVegetarianItems()
// // Returns all vegetarian items

// public double CalculateAveragePriceByCategory(string category)
// // Returns average price of items in category
// Sample Use Cases:
// 1.	Add appetizers, main courses, desserts
// 2.	Display menu categorized by course type
// 3.	Show vegetarian-only menu
// 4.	Calculate average prices per category

public class MenuItem
{
    public string ItemName{get; set;}
    public string Category{get; set;}
    public double Price{get; set;}
    public bool IsVegetarian{get; set;}

    public MenuItem(){}
}
public class MenuManager
{
    public static Dictionary<int, MenuItem> menuItems = new Dictionary<int, MenuItem>();
    public static int counter = 1;
    public void AddMenuItem(string name, string category, double price, bool isVeg)
    {
        MenuItem menu = new MenuItem()
        {
            ItemName = name,
            Category = category,
            Price = price,
            IsVegetarian = isVeg
        };
        menuItems.Add(counter,menu);
        counter++;
    }
    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        Dictionary<string, List<MenuItem>> result = new Dictionary<string, List<MenuItem>>();
        foreach(var item in menuItems)
        {
            MenuItem Menu = item.Value;
            if (!result.ContainsKey(Menu.Category))
            {
                result[Menu.Category] = new List<MenuItem>();
            }
            result[Menu.Category].Add(Menu);
        }
        return result;
    }
    public List<MenuItem> GetVegetarianItems()
    {
        List<MenuItem> result = new List<MenuItem>();
        foreach(var item in menuItems)
        {
            MenuItem menu = item.Value;
            if (menu.IsVegetarian)
            {
                result.Add(menu);
            }
        }
        return result;
    }
    public double CalculateAveragePriceByCategory(string category)
    {
        double totalAvg = 0;
        int count = 0;
        foreach(var item in menuItems)
        {
            MenuItem menu = item.Value;
            if(menu.Category == category)
            {
                count++;
                totalAvg += menu.Price;
            }
        }
        if(count == 0)
        {
            return 0;
        }
        return totalAvg/count;
    }
}
public class Program
{
    public static void Main()
    {
        MenuManager manager = new MenuManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Menu Item");
            Console.WriteLine("2. Display Menu Grouped By Category");
            Console.WriteLine("3. Display Vegetarian Items");
            Console.WriteLine("4. Calculate Average Price By Category");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 5)
            {
                Console.WriteLine("Exiting application...");
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Item Name: ");
                    string name = Console.ReadLine()!;

                    Console.Write("Enter Category (Appetizer/Main Course/Dessert): ");
                    string category = Console.ReadLine()!;

                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine()!);

                    Console.Write("Is Vegetarian (true/false): ");
                    bool isVeg = bool.Parse(Console.ReadLine()!);

                    manager.AddMenuItem(name, category, price, isVeg);
                    break;

                case 2:
                    var grouped = manager.GroupItemsByCategory();
                    foreach (var item in grouped)
                    {
                        Console.WriteLine($"\nCategory: {item.Key}");
                        foreach (var menu in item.Value)
                        {
                            Console.WriteLine(
                                $"{menu.ItemName} - ₹{menu.Price} - Veg: {menu.IsVegetarian}");
                        }
                    }
                    break;

                case 3:
                    List<MenuItem> vegItems = manager.GetVegetarianItems();

                    if (vegItems.Count == 0)
                    {
                        Console.WriteLine("No vegetarian items found.");
                        break;
                    }

                    foreach (var menu in vegItems)
                    {
                        Console.WriteLine(
                            $"{menu.ItemName} ({menu.Category}) - ₹{menu.Price}");
                    }
                    break;

                case 4:
                    Console.Write("Enter Category: ");
                    string cat = Console.ReadLine()!;

                    double avg = manager.CalculateAveragePriceByCategory(cat);

                    if (avg == 0)
                        Console.WriteLine("No items found in this category.");
                    else
                        Console.WriteLine($"Average Price: ₹{avg}");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
