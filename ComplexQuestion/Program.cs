public class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose:");
        Console.WriteLine("1. Rate Limiter");
        Console.WriteLine("2. Sales Aggregator");
        Console.WriteLine("3. Password Hasher");
        Console.WriteLine("4. LINQ Extensions");
        Console.WriteLine("5. Duplicate Detector");
        Console.WriteLine("6. Order System");
        Console.Write("Enter: ");
        string choice = Console.ReadLine();

        if(choice == "1")
        {
            TestRateLimiter();
        }
        else if(choice == "2")
        {
            TestSalesAggregator();
        }
        else if(choice == "3")
        {
            TestPasswordHasher();
        }
        else if(choice == "4")
        {
            TestLinqExtensions();
        }
        else if(choice == "5")
        {
            TestDuplicateDetector();
        }
        else if(choice == "6")
        {
            TestOrderSystem();
        }
    }

    public static void TestRateLimiter()
    {
        RateLimiter limiter = new RateLimiter();
        DateTime time = DateTime.Now;

        Console.WriteLine("Test 1: Client A - 7 requests");
        for(int i = 1; i <= 7; i++)
        {
            bool result = limiter.AllowRequest("ClientA", time);
            int rem = limiter.GetRemaining("ClientA", time);
            Console.WriteLine($"Req {i}: {(result ? "OK" : "BLOCKED")} | Left: {rem}");
            time = time.AddMilliseconds(500);
        }

        Console.WriteLine("Test 2: Wait 6 sec, try again");
        time = time.AddSeconds(6);
        for(int i = 1; i <= 3; i++)
        {
            bool result = limiter.AllowRequest("ClientA", time);
            Console.WriteLine($"Req {i}: {(result ? "OK" : "BLOCKED")}");
            time = time.AddMilliseconds(500);
        }

        Console.WriteLine("Test 3: Multiple clients");
        time = DateTime.Now;
        for(int i = 1; i <= 3; i++)
        {
            bool b = limiter.AllowRequest("ClientB", time);
            bool c = limiter.AllowRequest("ClientC", time);
            Console.WriteLine($"ClientB: {(b ? "OK" : "BLOCKED")} | ClientC: {(c ? "OK" : "BLOCKED")}");
            time = time.AddSeconds(1);
        }

        Console.WriteLine("Test 4: Sliding window check");
        time = DateTime.Now;
        for(int i = 1; i <= 5; i++)
        {
            limiter.AllowRequest("ClientD", time);
        }
        Console.WriteLine("Made 5 requests at t=0");

        time = time.AddSeconds(5);
        bool at5 = limiter.AllowRequest("ClientD", time);
        Console.WriteLine($"At t=5: {(at5 ? "OK" : "BLOCKED")}");

        time = time.AddSeconds(6);
        bool at11 = limiter.AllowRequest("ClientD", time);
        int left = limiter.GetRemaining("ClientD", time);
        Console.WriteLine($"At t=11: {(at11 ? "OK" : "BLOCKED")} | Left: {left}");
    }

    public static void TestSalesAggregator()
    {
        SalesAggregator agg = new SalesAggregator();

        agg.AddSale("North", "Electronics", 5000, new DateTime(2024, 1, 15));
        agg.AddSale("North", "Electronics", 3000, new DateTime(2024, 1, 16));
        agg.AddSale("North", "Clothing", 2000, new DateTime(2024, 1, 15));
        agg.AddSale("South", "Electronics", 4000, new DateTime(2024, 1, 15));
        agg.AddSale("South", "Clothing", 6000, new DateTime(2024, 1, 16));
        agg.AddSale("South", "Clothing", 3000, new DateTime(2024, 1, 17));
        agg.AddSale("East", "Food", 7000, new DateTime(2024, 1, 15));
        agg.AddSale("East", "Electronics", 2000, new DateTime(2024, 1, 16));
        agg.AddSale("West", "Clothing", 4500, new DateTime(2024, 1, 15));
        agg.AddSale("West", "Food", 3500, new DateTime(2024, 1, 16));

        Console.WriteLine("Total Sales by Region:");
        var totals = agg.GetTotalByRegion();
        foreach(var item in totals)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        Console.WriteLine("Top Category per Region:");
        var topCat = agg.GetTopCategoryPerRegion();
        foreach(var item in topCat)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        Console.WriteLine("Best Sales Day:");
        DateTime bestDay = agg.GetBestSalesDay();
        Console.WriteLine($"{bestDay.ToShortDateString()}");
    }

    public static void TestPasswordHasher()
    {
        PasswordHasher hasher = new PasswordHasher();

        Console.WriteLine("Test 1: Hash and verify correct password");
        string pass1 = "MySecure123!";
        string hash1 = hasher.HashPassword(pass1);
        Console.WriteLine($"Password: {pass1}");
        Console.WriteLine($"Hash: {hash1}");
        bool verify1 = hasher.VerifyPassword(pass1, hash1);
        Console.WriteLine($"Verify correct: {verify1}");

        Console.WriteLine("\nTest 2: Verify wrong password");
        bool verify2 = hasher.VerifyPassword("WrongPass", hash1);
        Console.WriteLine($"Verify wrong: {verify2}");

        Console.WriteLine("\nTest 3: Same password different hashes");
        string pass2 = "SamePassword";
        string hashA = hasher.HashPassword(pass2);
        string hashB = hasher.HashPassword(pass2);
        Console.WriteLine($"Hash A: {hashA}");
        Console.WriteLine($"Hash B: {hashB}");
        Console.WriteLine($"Hashes equal: {hashA == hashB}");
        Console.WriteLine($"Both verify: {hasher.VerifyPassword(pass2, hashA) && hasher.VerifyPassword(pass2, hashB)}");

        Console.WriteLine("\nTest 4: Multiple users");
        Dictionary<string, string> users = new Dictionary<string, string>();
        users["user1"] = hasher.HashPassword("pass123");
        users["user2"] = hasher.HashPassword("admin456");
        users["user3"] = hasher.HashPassword("test789");

        Console.WriteLine("Login user1 with pass123: " + hasher.VerifyPassword("pass123", users["user1"]));
        Console.WriteLine("Login user2 with wrong: " + hasher.VerifyPassword("wrong", users["user2"]));
        Console.WriteLine("Login user3 with test789: " + hasher.VerifyPassword("test789", users["user3"]));
    }

    public static void TestLinqExtensions()
    {
        int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 2, 3, 4};

        Console.WriteLine("Test 1: WhereEx - even numbers");
        var evens = nums.WhereEx(n => n % 2 == 0);
        foreach(var n in evens)
        {
            Console.Write(n + " ");
        }

        Console.WriteLine("\n\nTest 2: SelectEx - multiply by 2");
        var doubled = nums.WhereEx(n => n <= 5).SelectEx(n => n * 2);
        foreach(var n in doubled)
        {
            Console.Write(n + " ");
        }

        Console.WriteLine("\n\nTest 3: DistinctEx - remove duplicates");
        var distinct = nums.DistinctEx();
        foreach(var n in distinct)
        {
            Console.Write(n + " ");
        }

        Console.WriteLine("\n\nTest 4: GroupByEx - group by even/odd");
        var grouped = nums.GroupByEx(n => n % 2 == 0 ? "Even" : "Odd");
        foreach(var group in grouped)
        {
            Console.WriteLine($"{group.Key}:");
            foreach(var item in group)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nTest 5: Chain multiple operations");
        string[] words = {"apple", "banana", "apricot", "cherry", "avocado", "banana"};
        var result = words
            .WhereEx(w => w.StartsWith("a"))
            .DistinctEx()
            .SelectEx(w => w.ToUpper());
        
        Console.WriteLine("Words starting with 'a' (distinct, uppercase):");
        foreach(var w in result)
        {
            Console.WriteLine(w);
        }

        Console.WriteLine("\nTest 6: GroupByEx with objects");
        List<Person> people = new List<Person>
        {
            new Person { Name = "John", Age = 25 },
            new Person { Name = "Jane", Age = 30 },
            new Person { Name = "Bob", Age = 25 },
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Tom", Age = 35 }
        };

        var ageGroups = people.GroupByEx(p => p.Age);
        foreach(var group in ageGroups)
        {
            Console.WriteLine($"Age {group.Key}:");
            foreach(var person in group)
            {
                Console.WriteLine($"  {person.Name}");
            }
        }
    }

    public static void TestDuplicateDetector()
    {
        DuplicateDetector detector = new DuplicateDetector();
        List<Customer> customers = new List<Customer>();

        customers.Add(new Customer(1, "John Smith", "john@email.com", "1234567890"));
        customers.Add(new Customer(2, "Jon Smith", "jon@email.com", "1234567890"));
        customers.Add(new Customer(3, "Jane Doe", "jane@email.com", "9876543210"));
        customers.Add(new Customer(4, "Jane Doe", "jane2@email.com", "5555555555"));
        customers.Add(new Customer(5, "Bob Johnson", "bob@email.com", "1111111111"));
        customers.Add(new Customer(6, "Robert Johnson", "rob@email.com", "2222222222"));
        customers.Add(new Customer(7, "Alice Brown", "alice@email.com", "3333333333"));
        customers.Add(new Customer(8, "Alice Brown", "alice@email.com", "4444444444"));
        customers.Add(new Customer(9, "Mike Davis", "mike@email.com", "5555555555"));

        Console.WriteLine("All Customers:");
        foreach(var c in customers)
        {
            Console.WriteLine($"ID: {c.Id}, Name: {c.Name}, Email: {c.Email}, Phone: {c.Phone}");
        }

        Console.WriteLine("\nFinding Duplicates...\n");
        var duplicates = detector.FindDuplicates(customers);

        Console.WriteLine($"Found {duplicates.Count} duplicate groups:\n");

        int groupNum = 1;
        foreach(var group in duplicates)
        {
            Console.WriteLine($"Group {groupNum} - Reason: {group.Reason}");
            foreach(var customer in group.Customers)
            {
                Console.WriteLine($"  ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, Phone: {customer.Phone}");
            }
            Console.WriteLine();
            groupNum++;
        }
    }

    public static void TestOrderSystem()
    {
        OrderSystem.OrderManager manager = new OrderSystem.OrderManager();

        manager.AddProduct(new OrderSystem.Product(1, "Laptop", 1000, 5));
        manager.AddProduct(new OrderSystem.Product(2, "Mouse", 25, 10));
        manager.AddProduct(new OrderSystem.Product(3, "Keyboard", 75, 8));
        manager.AddProduct(new OrderSystem.Product(4, "Monitor", 300, 3));

        manager.AddCoupon(new OrderSystem.Coupon("SAVE10", 10, 100));
        manager.AddCoupon(new OrderSystem.Coupon("SAVE20", 20, 500));

        OrderSystem.OrderCustomer customer = new OrderSystem.OrderCustomer(1, "John Doe", "john@email.com");

        Console.WriteLine("Test 1: Successful Order");
        try
        {
            OrderSystem.Order cart1 = manager.CreateCart(customer);
            manager.AddToCart(cart1, 1, 1);
            manager.AddToCart(cart1, 2, 2);
            
            Console.WriteLine("Cart Items:");
            foreach(var item in cart1.Items)
            {
                Console.WriteLine($"  {item.Product.Name} x{item.Quantity} = ${item.GetTotal()}");
            }

            manager.ApplyCoupon(cart1, "SAVE10");
            Console.WriteLine($"Coupon Applied: SAVE10");
            
            OrderSystem.Payment payment1 = manager.PlaceOrder(cart1, "Credit Card");
            Console.WriteLine($"Order Placed!");
            Console.WriteLine($"Invoice: {cart1.InvoiceNumber}");
            Console.WriteLine($"Subtotal: ${cart1.Subtotal}");
            Console.WriteLine($"Discount: ${cart1.Discount}");
            Console.WriteLine($"Total: ${cart1.Total}");
            Console.WriteLine($"Payment ID: {payment1.PaymentId}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nTest 2: Insufficient Stock");
        try
        {
            OrderSystem.Order cart2 = manager.CreateCart(customer);
            manager.AddToCart(cart2, 1, 10);
        }
        catch(OrderSystem.InsufficientStockException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nTest 3: Invalid Coupon");
        try
        {
            OrderSystem.Order cart3 = manager.CreateCart(customer);
            manager.AddToCart(cart3, 2, 1);
            manager.ApplyCoupon(cart3, "INVALID");
        }
        catch(OrderSystem.InvalidCouponException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nTest 4: Coupon Min Amount Not Met");
        try
        {
            OrderSystem.Order cart4 = manager.CreateCart(customer);
            manager.AddToCart(cart4, 2, 1);
            manager.ApplyCoupon(cart4, "SAVE20");
        }
        catch(OrderSystem.InvalidCouponException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nTest 5: Empty Cart");
        try
        {
            OrderSystem.Order cart5 = manager.CreateCart(customer);
            manager.PlaceOrder(cart5, "Cash");
        }
        catch(OrderSystem.EmptyCartException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nTest 6: Stock Deduction Check");
        OrderSystem.Product laptop = manager.GetProduct(1);
        Console.WriteLine($"Laptop stock after orders: {laptop.Stock}");
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
