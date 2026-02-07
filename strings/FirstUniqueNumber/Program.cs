// char FirstUniqueChar(string s)
// Input:  "swiss"
// Output: 'w'

// Input:  "aabbcc"
// Output: '\0'   // no unique char

using System;
using System.Collections.Generic;
public class Program
{
    public static char FirstUniqueChar(string s){
        Dictionary<char, int> dict = new Dictionary<char,int>();

        foreach(var i in s){
            if(dict.ContainsKey(i)){
                dict[i]++;
            }else{
                dict[i] = 1;
            }
        }
        foreach(var i in dict){
            Console.WriteLine($"{i.Key} and {i.Value}");
        }
        foreach(var i in s){
            if(dict[i] == 1){
                return i;
            }
        }
        return '\0';
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String");
        string str= Console.ReadLine();
        Console.WriteLine(FirstUniqueChar(str));
    }
}