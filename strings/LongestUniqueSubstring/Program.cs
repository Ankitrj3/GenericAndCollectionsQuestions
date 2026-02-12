namespace StringMan
{
    public class Program
    {
        public static string LongestUniqueSubstring(string s)
        {
            int left = 0;
            int max = 0;
            HashSet<char> set = new HashSet<char>();
            int curr = 0;
            int end = 0;

            for(int right = 0; right < s.Length; right++)
            {
                while (set.Contains(s[right]))
                {
                    set.Remove(s[left]);
                    left++;
                }
                set.Add(s[right]);
                max = Math.Max(max, right - left + 1);
                
                if(curr < max)
                {
                    curr = max;
                    end = left;
                }
            }
            return s.Substring(curr, end);
        }
        public static void Main()
        {
            Console.WriteLine("Enter String");
            string? s = Console.ReadLine();
            Console.WriteLine(LongestUniqueSubstring(s));
        }
    }
}