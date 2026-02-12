// Input:  "aaabbc"
// Output: "a3b2c1"

// Input:  "abcd"
// Output: "a1b1c1d1"

using System.Runtime.CompilerServices;

public class Program
{
    public static string ToggleString(string str)
    {
        char [] ss = str.ToCharArray();

        for(int i = 0; i < ss.Length; i++)
        {
            if (char.IsUpper(ss[i]))
            {
                ss[i] = char.ToLower(ss[i]);
            }else if (char.IsLower(ss[i]))
            {
                ss[i] = char.ToUpper(ss[i]);
            }
        }
        return new string(ss);
    }
    public static void Main()
    {
        Console.WriteLine("Enter the string");
        string? str = Console.ReadLine();

        Console.WriteLine(ToggleString(str));
    }
}