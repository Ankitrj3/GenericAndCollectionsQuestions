// Question 11: Online Food Delivery
// Scenario: A food delivery service needs to manage restaurants, menus, and orders.
// Requirements:
// csharp
// // In class Restaurant:
// // - int RestaurantId
// // - string Name
// // - string CuisineType
// // - string Location
// // - double DeliveryCharge

// // In class FoodItem:
// // - int ItemId
// // - string Name
// // - string Category
// // - double Price
// // - int RestaurantId

// // In class Order:
// // - int OrderId
// // - int CustomerId
// // - List<FoodItem> Items
// // - DateTime OrderTime
// // - string Status
// // - double TotalAmount

// // In class DeliveryManager:
// public void AddRestaurant(string name, string cuisine, 
//                          string location, double charge)
// public void AddFoodItem(int restaurantId, string name, 
//                        string category, double price)
// public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
// public bool PlaceOrder(int customerId, List<int> itemIds)
// public List<Order> GetPendingOrders()
// Use Cases:
// •	Add restaurants with different cuisines
// •	Manage restaurant menus
// •	Place food orders
// •	Group restaurants by cuisine type
// •	Track order status


public class Restaurant
{
    public int RestaurantId{get; set;}
    public string? Name{get; set;}
    public string? CuisineType{get; set;}
    public string? Location{get; set;}
    public double DeliveryCharge{get; set;}

    public Restaurant(){}
}
public class FoodItem
{
    public int ItemId{get; set;}
    public string? Name{get; set;}
    public string? Category{get; set;}
    public double Price{get; set;}
    public int RestaurantId{get; set;}
    public FoodItem(){}
}
public class Order
{
    public int OrderId{get; set;}
    public int CustomerId{get; set;}
    public List<FoodItem> Items{get; set;}
    public DateTime OrderTime{get; set;}
    public string? Status{get; set;}
    public double TotalAmount{get; set;}
    public Order()
    {
        Items = new List<FoodItem>();
    }
}

public class DeliveryManager
{
    public static Dictionary<int, Restaurant> restaurantDetails = new Dictionary<int, Restaurant>();
    public static Dictionary<int, FoodItem> foodDetails = new Dictionary<int, FoodItem>();
    public static List<Order> orderDetails = new List<Order>();
    public static int RestaurantCounter = 1;
    public static int FoodCounter = 1;
    public static int OrderCounter = 1;
    public void AddRestaurant(string name, string cuisine, string location, double charge)
    {
        Restaurant restaurant = new Restaurant()
        {
            RestaurantId = RestaurantCounter,
            Name = name,
            CuisineType = cuisine,
            Location = location,
            DeliveryCharge = charge
        };
        restaurantDetails.Add(RestaurantCounter, restaurant);
        RestaurantCounter++;
    }
    public void AddFoodItem(int restaurantId, string name, string category, double price)
    {
        FoodItem foodItem = new FoodItem()
        {
            ItemId = FoodCounter,
            Name = name,
            Category = category,
            Price = price,
            RestaurantId = restaurantId  
        };
        foodDetails.Add(FoodCounter, foodItem);
        FoodCounter++;
    }
    public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
    {
        Dictionary<string, List<Restaurant>> result = new Dictionary<string, List<Restaurant>>();
        foreach(var item in restaurantDetails)
        {
            var res = item.Value;
            if (!result.ContainsKey(res.CuisineType))
            {
                result[res.CuisineType] = new List<Restaurant>();
            }
            result[res.CuisineType].Add(res);
        }
        return result;
    }
    public bool PlaceOrder(int customerId, List<int> itemIds)
    {
        Order order = new Order()
        {
            OrderId = OrderCounter,
            CustomerId = customerId,
            OrderTime = DateTime.Now,
            Status = "Pending"
        };
        foreach(var item in itemIds)
        {
            var food = foodDetails[item];
            if (!foodDetails.ContainsKey(item))
            {
                Console.WriteLine("Food Is Not Present");
                return false;
            }
            order.Items.Add(food);
            order.TotalAmount += food.Price;
            
        }

        orderDetails.Add(order);
        Console.WriteLine("Order Created Successfully");
        return true;
    }
    public List<Order> GetPendingOrders()
    {
        List<Order> result = new List<Order>();
        foreach(var item in orderDetails)
        {
            if(item.Status == "Pending")
            {
                result.Add(item);
            }
        }
        return result;
    }
}
public class Program
{
    public static void Main()
    {
        
    }
}



