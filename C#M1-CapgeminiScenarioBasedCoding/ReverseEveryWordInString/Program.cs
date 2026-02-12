// Input:  "hello world"
// Output: "olleh dlrow"

// Input:  "  hi   bro  "
// Output: "ih orb"

// Input:  "Capgemini M1 Test"
// Output: "inimegpaC 1M tseT"
using System;
using System.Collections.Generic;

public class Program
{
    public static string ReverseEveryWord(string str){
        if (string.IsNullOrWhiteSpace(str)) return "";

        string [] words = str.Split(' ');
        List<string> clean = new List<string>();
        for(int i=0;i<words.Length;i++){
            if (words[i].Length > 0) {
            char [] arr = words[i].ToCharArray();
            Array.Reverse(arr);
            clean.Add(new string(arr));
            }
        }
        return string.Join(" ",clean);
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String");
        string? str = Console.ReadLine();
        Console.WriteLine(ReverseEveryWord(str));
    }
}