// Backspace String Compare
// Task: '#' is backspace. Compare final strings.

// Input:  s = "ab#c", t = "ad#c"
// Output: true

// Input:  s = "ab##", t = "c#d#"
// Output: true

// Input:  s = "a#c", t = "b"
// Output: false


using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static bool StringComparsionAfterBackspace(string str1, string str2){
        return Build(str1) == Build(str2);
    }
    private static string Build(string str){
        Stack<char> stack = new Stack<char>();
        
        foreach(var item in str){
            if(item == '#'){
                if(stack.Count > 0){
                    stack.Pop();
                }
            }else{
                stack.Push(item);
            }
        }
        return new string(stack.Reverse().ToArray());
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String-1 for Comparsion");
        string str1 = Console.ReadLine();
        Console.WriteLine("Enter the String-2 for Comparsion");
        string str2 = Console.ReadLine();
        
        bool result = StringComparsionAfterBackspace(str1 ?? "", str2 ?? "");
        Console.WriteLine(result);
    }
}