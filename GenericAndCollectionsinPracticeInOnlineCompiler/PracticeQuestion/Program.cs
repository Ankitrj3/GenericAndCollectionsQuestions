// C# Collections – Moderate Scenario-Based Coding Questions

// 1.
// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
// E-Commerce Cart Consolidation
// Focus:
// Dictionary, aggregation
// Dictionary<string,int>
// Scenario: A cart receives multiple scans of the same SKU. Consolidate quantities per SKU.

// Input
// List<(string sku, int qty)> scans
// Output
// Dictionary<string,int> skuQty
// If SKU repeats, sum quantities.
// Ignore scans where qty <= 0.
// Example:
// Input : [("A101",2),("B205",1),("A101",3),("C111",-1)]
// Output: { A101:5, B205:1 }

using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static Dictionary<string, int> SumUpValues(List<(string sku, int qty)> scans){
        // Dictionary<string, int> res = new Dictionary<string, int>();
        // foreach(var i in scans){
        //     if (i.qty <= 0) continue;
        //     if(res.ContainsKey(i.sku)){
        //         res[i.sku] += i.qty;
        //     }else{
        //         res[i.sku] = i.qty;
        //     }
        // }
        
        // return res;
        return scans.Where(s => s.qty > 0).GroupBy(s => s.sku)
                    .ToDictionary(s => s.Key, s => s.Sum(x => x.qty));
    }
    public static void Main(string[] args)
    {
        List<(string, int)> list = new List<(string, int)>();
        list.Add(("A101",2));
        list.Add(("B205",1));
        list.Add(("A101",3));
        list.Add(("C111",-1));
        
        Dictionary<string, int> res = SumUpValues(list);
        
        foreach(var i in res){
            Console.WriteLine(i.Key+" "+i.Value);
        }
    }
}


// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

// 2.
// Attendance – First Unique Entry
// Focus:
// HashSet + order preservation
// HashSet + List
// Scenario: Employee IDs are scanned at a gate. Duplicates occur when someone scans again.

// Input
// List<int> scans
// Output
// List<int> firstTime
// Return only the first occurrence of each ID.
// Maintain original order for first-time entries.
// Example:
// Input : [10, 20, 10, 30, 20, 40]
// Output: [10, 20, 30, 40]
using System;
using System.Linq;
using System.Collections.Generic;

public class HelloWorld
{
    public static List<int> DistinctVal(List<int> scans){
        return scans.Distinct().ToList();
    }
    public static void Main(string[] args)
    {
        List<int> list = new List<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(10);
        list.Add(20);
        list.Add(40);
        
        List<int> res = DistinctVal(list);
        foreach(var i in res){
            Console.Write(i+" ");
        }
    }
}

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

// 3.
// Leaderboard – Top K Scores
// Focus:
// Sorting + tie-breakers
// Sort / LINQ
// Scenario: A game leaderboard stores player scores.

// Input
// List<(string name, int score)> players, int k
// Output
// List<(string name, int score)> topK
// Sort by score (descending).
// If tie, sort by name (ascending).
// Return only top k entries.
// Example:
// Players: [("Raj",80),("Anu",95),("Vikram",95),("Meena",70)], k=3
// Output : [("Anu",95),("Vikram",95),("Raj",80)]
using System;
using System.Linq;
using System.Collections.Generic;

public class HelloWorld
{
    public static List<(string, int)> Leaderboard(List<(string name, int score)> players, int k){
        
        return players.OrderByDescending(s => s.score)
                    .ThenBy(s => s.name)
                    .Take(k)
                    .Select(s => (s.name, s.score))
                    .ToList();
    }
    public static void Main(string[] args)
    {
        List<(string, int)> list = new List<(string, int)>();
       
        list.Add(("Raj",80));
        list.Add(("Anu",95));
        list.Add(("Vikram",95));
        list.Add(("Meena",70));
        
        List<(string, int)> res = Leaderboard(list,3);
        foreach(var i in res){
            Console.WriteLine(i.Item1+" "+i.Item2);
        }
    }
}

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

// 5.
// Undo Feature – Text Editor
// Focus:
// Stack undo
// Stack
// Scenario: Text editor supports TYPE <word> and UNDO.

// Input
// List<string> ops
// Output
// string finalText
// TYPE word appends a word with a space.
// UNDO removes the last typed word.
// If nothing to undo, ignore UNDO.
// Example:
// Ops   : ["TYPE Hello","TYPE World","UNDO","TYPE CSharp"]
// Output: "Hello CSharp"

using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static string StackVal(string [] arr){
        Stack<string> stack = new Stack<string>();
        
        foreach(var item in arr){
            string[] arrItem = item.Split(" ");
            
            if(arrItem[0] == "TYPE"){
                stack.Push(arrItem[1]);
            }else if(arrItem[0] == "UNDO"){
                if(stack.Count > 0){
                    stack.Pop();
                }
            }
        }
        
         
        string res = string.Join(" ",stack);
        string [] sp = res.Split(" ");
        string res1 = "";
        for(int i=sp.Length - 1;i>=0;i--){
            res1+=sp[i]+" ";
        }
        return res1.Trim();
    }
    public static void Main(string[] args)
    {
        string[] arr = { "TYPE Hello", "TYPE World", "UNDO", "TYPE CSharp" };
        Console.WriteLine(StackVal(arr));
    }
}

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

// 6.
// Customer Support – Merge Two Ticket Streams
// Focus:
// Two-pointer merge
// List merge
// Scenario: Two systems generate ticket IDs already sorted (ascending). Merge them efficiently.

// Input
// List<int> a, List<int> b (sorted)
// Output
// List<int> merged
// Output must remain sorted ascending.
// Avoid full re-sort; target O(n+m).
// Example:
// a=[1,4,7], b=[2,3,8]
// merged=[1,2,3,4,7,8]

using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static List<int> MergePointer(List<int>a, List<int>b){
        List<int> res = new List<int>();
        foreach(var i in a){
            res.Add(i);
        }
        foreach(var i in b){
            res.Add(i);
        }
        res.Sort();
        return res;
    }
    public static void Main(string[] args)
    {
        List<int> a = new List<int> { 1, 4, 7 };
        List<int> b = new List<int> { 2, 3, 8 };
        
        List<int> res = MergePointer(a,b);
        foreach(var i in res){
            Console.WriteLine(i);
        }
    }
}

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

// 8.
// Inventory – Detect Duplicate Serials
// Focus:
// HashSet duplicates
// HashSet
// Scenario: Serial numbers may repeat; duplicates indicate issues. Return duplicates once, in detection order.

// Input
// List<string> serials
// Output
// List<string> duplicates
// Return each duplicate only once.
// Preserve the order they are first detected as duplicate.
// Example:
// Input : ["S1","S2","S1","S3","S2","S2"]
// Output: ["S1","S2"]

using System;
using System.Collections.Generic;
using System.Linq;

public class HelloWorld
{
    public static List<string> Duplicate(List<string> input){
        HashSet<string> set = new HashSet<string>();
        List<string> op = new List<string>();
        foreach(var i in input){
            if(set.Contains(i)){
                if(!op.Contains(i)){
                    op.Add(i);
                }
            }else{
                set.Add(i);
            }
        }
        return op;
    }
    public static void Main(string[] args)
    {
        List<string> input = new List<string>();
        
        input.Add("S1");
        input.Add("S2");
        input.Add("S1");
        input.Add("S3");
        input.Add("S2");
        input.Add("S2");
        List<string> res = Duplicate(input);
        foreach(var i in res){
            Console.WriteLine(i);
        }
    }
}

// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

// 4
// Metro Ticketing – Peak Hour Count
// Focus:
// Queue processing
// Queue
// Scenario: A metro counter processes passengers FIFO. Count “Regular” tickets sold during peak hours.

// Input
// Queue<(TimeSpan entryTime, string ticketType)> q
// Output
// int count
// Count where ticketType == "Regular".
// Peak window: 08:00 to 10:00 inclusive.
// Ignore invalid ticket types.

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static int QueueProcessing(Queue<(TimeSpan entryTime, string ticketType)> q){
        TimeSpan start = new TimeSpan(8,0,0);
        TimeSpan end = new TimeSpan(10,0,0);
        int count = 0;
        
        foreach(var i in q){
            if(i.entryTime >= start && i.entryTime <= end && i.ticketType.Equals("Regular")){
                count++;
            }
        }
        return count;
    }
    public static void Main(string[] args)
    {
        Queue<(TimeSpan entryTime, string ticketType)> q = new Queue<(TimeSpan entryTime, string ticketType)>();
        q.Enqueue(((new TimeSpan(8, 10, 0)),"Regular"));
        q.Enqueue(((new TimeSpan(9, 30, 0)),"Regular"));
        q.Enqueue(((new TimeSpan(10, 0, 0)),"VIP"));
        q.Enqueue(((new TimeSpan(10, 1, 0)),"Regular"));
        
        Console.WriteLine(QueueProcessing(q));
    }
}