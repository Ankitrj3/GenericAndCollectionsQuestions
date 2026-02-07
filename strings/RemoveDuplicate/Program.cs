// Input:  "programming"
// Output: "progamin"

// Input:  "aabbcc"
// Output: "abc"
// string RemoveDuplicates(string s)



using System;
using System.Text;
using System.Collections.Generic;
public class Program
{
    public static string RemoveDuplicates(string s){
        HashSet<char> set = new HashSet<char>(s);
        StringBuilder sb = new StringBuilder();
        foreach(var i in set){
            sb.Append(i);
        }
        return sb.ToString();
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String");
        string str= Console.ReadLine();
        Console.WriteLine(RemoveDuplicates(str));
    }
}