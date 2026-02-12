// Input:  "banana"
// Output: b=1, a=3, n=2

public class Program
{
    public static Dictionary<char,int> CharFrequency(string s)
    {
        s = s.ToLower();
        Dictionary<char, int> map = new Dictionary<char, int>();
        foreach(var i in s)
        {
            if (map.ContainsKey(i))
            {
                map[i]++;
            }
            else
            {
                map[i]=1;
            }
        }
        return map;
    }
    public static void Main()
    {
        Console.WriteLine("Enter the string");
        string? str = Console.ReadLine();

        Dictionary<char, int> map = CharFrequency(str);

        foreach(var item in map)
        {
            Console.WriteLine($"{item.Key}={item.Value}");
        }
    }
}