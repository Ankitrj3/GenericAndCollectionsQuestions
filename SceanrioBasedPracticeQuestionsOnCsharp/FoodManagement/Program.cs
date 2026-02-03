// 📘 Scenario
// A food delivery service wants to store food items and group them by category.

// In Program class
// public static SortedDictionary<int, FoodItem> foodDetails

// In class FoodItem
// string Name
// string Category
// int Price

// In class FoodUtility

// Method 1
// public void AddFoodItem(string name, string category, int price)

// Method 2
// public SortedDictionary<string, List<FoodItem>> GroupFoodByCategory()

// Menu:
// 1. Add Food Item
// 2. Group Food By Category
// 3. Exit

public class FoodItem
{
    public string? Name{get; set;}
    public string? Category{get; set;}
    public int Price{get; set;}

    public FoodItem(){}
}
public class FoodUtility
{
    public FoodUtility(){}
    public static SortedDictionary<int, FoodItem> foodDetails = new SortedDictionary<int, FoodItem>();
    public static int count = 1;
    public void AddFoodItem(string name, string category, int price)
    {
        FoodItem foodItem = new FoodItem()
        {
            Name = name,
            Category = category,
            Price = price
        };
        foodDetails.Add(count,foodItem);
        count++;
    }
    public SortedDictionary<string, List<FoodItem>> GroupFoodByCategory()
    {
        SortedDictionary<string, List<FoodItem>> result = new SortedDictionary<string, List<FoodItem>>();

        foreach(var item in foodDetails)
        {
            FoodItem food = item.Value;
            if (!result.ContainsKey(food.Category))
            {
                result[food.Category] = new List<FoodItem>();
            }
            result[food.Category].Add(food);
        }
        return result;
    }
}
public class Program
{
    public static void Main()
    {
        FoodUtility f = new FoodUtility();

        while (true)
        {
            Console.WriteLine("\n1. Add Food Item");
            Console.WriteLine("2. Group Food By Category");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 3)
            {
                Console.WriteLine("Exiting application...");
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Food Name: ");
                    string name = Console.ReadLine()!;

                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine()!;

                    Console.Write("Enter Price: ");
                    int price = int.Parse(Console.ReadLine()!);

                    f.AddFoodItem(name, category, price);
                    Console.WriteLine("Food item added successfully!");
                    break;

                case 2:
                    SortedDictionary<string, List<FoodItem>> result =
                        f.GroupFoodByCategory();

                    foreach (var item in result)
                    {
                        Console.WriteLine($"\nCategory: {item.Key}");
                        foreach (var food in item.Value)
                        {
                            Console.WriteLine($"Name: {food.Name}");
                            Console.WriteLine($"Price: {food.Price}");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
