// Input:  "aaabbc"
// Output: "a3b2c1"

// Input:  "abcd"
// Output: "a1b1c1d1"

public class Program
{
    public static string CompressString(string str)
    {
        Dictionary<char,int> map = new Dictionary<char, int>();

        foreach(var i in str)
        {
            if (map.ContainsKey(i))
            {
                map[i]++;
            }
            else
            {
                map[i] = 1;
            }
        }
        string val = "";
        foreach(var i in map)
        {
            val+=i.Key;
            val+=i.Value.ToString();
        }
        return val;
    }
    public static void Main()
    {
        Console.WriteLine("Enter the string");
        string? str = Console.ReadLine();

        Console.WriteLine(CompressString(str));
    }
}