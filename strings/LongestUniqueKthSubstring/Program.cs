// int LongestSubstringKDistinct(string s, int k)
// Input:  s="eceba", k=2
// Output: 3   // "ece"

// Input:  s="aa", k=1
// Output: 2

public class Program
{
    public static int LongestSubstringKDistinct(string s, int k)
    {
        int left = 0;
        int max = 0;
        Dictionary<char, int> map = new Dictionary<char, int>();

        for(int right = 0; right < s.Length; right++)
        {
            char r = s[right];
            if (map.ContainsKey(r))
            {
                map[r]++;
            }
            else
            {
                map[r]=1;
            }
            while(map.Count > k)
            {
                char l = s[left];
                map[l]--;
                if (map[l] <= 0)
                {
                    map.Remove(l);
                }
                left++;
            }
            max = Math.Max(max, right - left + 1);
        }
        return max;
    }
    public static void Main()
    {
        Console.WriteLine("Enter the String");
        string? str = Console.ReadLine();

        Console.WriteLine("Enter the Kth Number");
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(LongestSubstringKDistinct(str, k));
    }
}