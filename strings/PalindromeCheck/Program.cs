// Input:  "A man a plan a canal Panama"
// Output: true

// Input:  "Hello"
// Output: false


using System;

public class Program
{
    public static bool checkPalindrome(string str){
       string originalString = str.Trim().Replace(" ","").ToLower();
       str = str.ToLower().Trim();
       char [] an = str.ToCharArray();
       Array.Reverse(an);
       string reverse= new string(an);
       reverse = reverse.Replace(" ","");
       Console.WriteLine(reverse);
       Console.WriteLine(originalString);
       if(reverse == originalString){
           return true;
       }
       return false;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String");
        string str= Console.ReadLine();
        Console.WriteLine(checkPalindrome(str));
    }
}