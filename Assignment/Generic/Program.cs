// using System;                                   // TODO: needed for Console

// public class Program                              // Boilerplate: Program class
// {
//     public static void Main()                      // Entry point
//     {
//         int a = 10;                                // Example value
//         int b = 20;                                // Example value

//         Swap<int>(ref a, ref b);                   // Calling generic swap

//         Console.WriteLine($"a={a}, b={b}");         // Expected: a=20, b=10

//         string x = "Gopi";                          // Example string
//         string y = "Suresh";                        // Example string

//         Swap(ref x, ref y);                         // Generic type inference works too
//         Console.WriteLine($"x={x}, y={y}");         // Expected: x=Suresh, y=Gopi
//     }

//     // ✅ TODO: Students must implement only this function
//     public static void Swap<T>(ref T left, ref T right)
//     {
//         // TODO: Swap values using a temporary variable
//         T temp = left;
//         left = right;
//         right = temp;
//     }
// }

// using System;                                     // Console
// using System.Collections.Generic;                 // List<T>

// public class Program
// {
//     public static void Main()
//     {
//         var intRepo = new SimpleRepo<int>();       // Repo for int
//         intRepo.Add(10);
//         intRepo.Add(20);

//         Console.WriteLine(string.Join(",", intRepo.GetAll())); // Expected: 10,20

//         var nameRepo = new SimpleRepo<string>();   // Repo for string
//         nameRepo.Add("Asha");
//         nameRepo.Add("Vikram");

//         Console.WriteLine(string.Join(",", nameRepo.GetAll())); // Expected: Asha,Vikram
//     }
// }

// public class SimpleRepo<T>
// {
//     private readonly List<T> _items = new List<T>();       // In-memory storage

//     // ✅ TODO: Students implement this
//     public void Add(T item)
//     {
//         // TODO: Add item into _items
//         _items.Add(item);
//     }

//     // ✅ TODO: Students implement this
//     public IReadOnlyList<T> GetAll()
//     {
//         // TODO: Return all items as read-only list
//         return _items;
//     }
// }

// using System;

// public class Program
// {
//     public static void Main()
//     {
//         var cache = new RefCache<string>();         // ✅ Allowed (string is class)
//         cache.Set(null);                            // Store null
//         Console.WriteLine(cache.GetOrDefault("NA")); // Expected: NA

//         cache.Set("Hello");
//         Console.WriteLine(cache.GetOrDefault("NA")); // Expected: Hello

//         // var wrong = new RefCache<int>();          // ❌ Should not compile because int is a struct
//     }
// }

// public class RefCache<T> where T : class            // Constraint: only reference type
// {
//     private T? _value;                              // Nullable reference

//     public void Set(T? value)
//     {
//         _value = value;                             // Save value
//     }

//     // ✅ TODO: Students implement this
//     public T GetOrDefault(T defaultValue)
//     {
//         // TODO: if _value is null, return defaultValue, else return _value
//         if(_value == null)
//         {
//             return null;
//         }
//         return _value;
//     }
// }

// using System;

// public class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine(Apply(5, 3, (a, b) => a + b));    // Expected: 8
//         Console.WriteLine(Apply(5, 3, (a, b) => a * b));    // Expected: 15
//         Console.WriteLine(Apply("Hi", "Tech", (a, b) => a + " " + b)); // Expected: Hi Tech
//     }

//     // ✅ TODO: Students implement only this function
//     public static T Apply<T>(T x, T y, Func<T, T, T> op)
//     {
       
//         return op(x,y);

//     }
// }

// using System;
// using System.Collections.Generic;

// public class Program
// {
//     public static void Main()
//     {
//         var nums = new List<int> { 2, 5, 8, 11, 14 };

//         var evens = Filter(nums, n => n % 2 == 0);
//         Console.WriteLine(string.Join(",", evens));         // Expected: 2,8,14

//         var big = Filter(nums, n => n >= 10);
//         Console.WriteLine(string.Join(",", big));           // Expected: 11,14
//     }

//     // ✅ TODO: Students implement only this function
//     public static List<T> Filter<T>(List<T> items, Predicate<T> match)
//     {
//         // TODO: return a new list with matched items
//         List<T> res = new List<T>();
//         foreach (var i in items)
//         {
//             if (match(i))
//             {
//                 res.Add(i);
//             }
//         }
//         return res;
//     }
// }

// using System;

// public class Program
// {
//     // Custom delegate type (industry common in legacy code-bases)
//     public delegate void Notifier(string message);

//     public static void Main()
//     {
//         Notifier pipeline = BuildPipeline();        // Combine multiple methods
//         pipeline("Order Created");                  // Expected: prints 3 lines (Email/SMS/Log)
//     }

//     // ✅ TODO: Students implement only this function
//     public static Notifier BuildPipeline()
//     {
//         Notifier notifier = SendEmail;
//         notifier += SendSms;
//         notifier += WriteLog;

//         return notifier;
//     }

//     private static void SendEmail(string message)
//     {
//         Console.WriteLine($"Email: {message}");
//     }

//     private static void SendSms(string message)
//     {
//         Console.WriteLine($"SMS: {message}");
//     }

//     private static void WriteLog(string message)
//     {
//         Console.WriteLine($"Log: {message}");
//     }
// }

// using System;
// using System.Collections.Generic;

// public class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine(Sum(new List<int> { 1, 2, 3 }));      // Expected: 6
//         Console.WriteLine(Sum(new List<double> { 1.5, 2.6 }));  // Expected: 4.0

//         // Console.WriteLine(Sum(new List<string> { "a", "b" })); // ❌ Should not compile (string is not struct)
//     }

//     // ✅ TODO: Students implement only this function
//     public static T Sum<T>(IEnumerable<T> items) where T : struct
//     {
//         // TODO: Sum all items and return the sum
//         dynamic sum = 0;
//         foreach(var i in items)
//         {
//             sum += i;
//         }
//         return sum;
//     }
// }

