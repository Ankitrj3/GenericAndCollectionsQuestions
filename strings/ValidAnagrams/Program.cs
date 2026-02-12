// bool IsAnagram(string s1, string s2)
// Input:  "listen", "silent"
// Output: true

// Input:  "hello", "bello"
// Output: false

public class Program
{
    public static bool IsAnagram(string s1, string s2)
    {
        if(s1.Length != s2.Length)
        {
            return false;
        }
        char [] ch1 = s1.ToCharArray();
        char [] ch2 = s2.ToCharArray();

        Array.Sort(ch1);
        Array.Sort(ch2);

        string str1 = new string(ch1);
        string str2 = new string(ch2);

        if(str1 == str2)
        {
            return true;
        }
        return false;
    }
    public static void Main()
    {
        Console.WriteLine("Enter the string1");
        string? str1 = Console.ReadLine();

        Console.WriteLine("Enter the string2");
        string? str2 = Console.ReadLine();

        Console.WriteLine(IsAnagram(str1,str2));
    }
}