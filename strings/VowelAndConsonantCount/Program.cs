// Input:  "Hello"
// Output: Vowels=2, Consonants=3

// Input:  "123@#a"
// Output: Vowels=1, Consonants=0

using System;

public class Program
{
    public static void VowelAndConsonantsCount(string str){
        int VowelCount = 0;
        int ConsonantCount = 0;
        str = str.Trim();
        foreach(var i in str){
            if("aeiou".Contains(i)){
                VowelCount++;
            }
            else{
                ConsonantCount++;
            }
            
            if(i == ' '){
                ConsonantCount--;
            }
        }
        Console.WriteLine(VowelCount+" "+ConsonantCount);
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String");
        string str= Console.ReadLine();
        VowelAndConsonantsCount(str);
    }
}