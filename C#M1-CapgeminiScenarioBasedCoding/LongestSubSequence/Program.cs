// Input:  "abcabcbb"
// Output: 3

// Input:  "bbbbb"
// Output: 1

// Input:  "pwwkew"
// Output: 3

// Input:  ""
// Output: 0

using System;
using System.Collections.Generic;
public class Program
{
    public static int LongestSubSequence(string s){
        
        if(string.IsNullOrEmpty(s)){
            return 0;
        }
        int left = 0;
        int max = 0;
        HashSet<char> set = new HashSet<char>();
        
        for(int right = 0; right < s.Length; right++){
            while(set.Contains(s[right])){
                set.Remove(s[left]);
                left++;
            }
            set.Add(s[right]);
            max = Math.Max(max, right - left + 1);
        }
        return max;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the string");
        string? str = Console.ReadLine();
        
        Console.WriteLine(LongestSubSequence(str));
    }
}