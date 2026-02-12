// Input:  "A man, a plan, a canal: Panama"
// Output: true

// Input:  "race a car"
// Output: false

// Input:  " "
// Output: true

using System;

public class Program
{
    public static bool CheckPalindrome(string str){
        int left = 0;
        int right = str.Length - 1;
        while(left < right){
            while(left < right && !char.IsLetterOrDigit(str[left])) left ++;
            while(left < right && !char.IsLetterOrDigit(str[right])) right--;
            
            if(char.ToLower(str[left]) != char.ToLower(str[right])){
                return false;
            }

            left++;
            right--;
        }
        return true;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the Sentence To check the Palindrome");
        string? str = Console.ReadLine();
        Console.WriteLine(CheckPalindrome(str));
    }
}