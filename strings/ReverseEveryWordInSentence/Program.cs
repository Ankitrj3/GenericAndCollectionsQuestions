// Input:  "hello world"
// Output: "olleh dlrow"

// Input:  "  hi   bro  "
// Output: "ih orb"

namespace Strings
{
    public class Program
    {
        public static string ReverseEachWord(string input)
        {
            input = input.Trim();
            string [] array = input.Split(" ");
            for(int i = 0; i < array.Length; i++)
            {
                char [] chrs = array[i].ToCharArray();
                Array.Reverse(chrs);
                array[i] = new string(chrs);
            }
            return string.Join(" ",array);
        }
        public static void Main()
        {
            Console.Write("Enter Strings : ");
            string? str = Console.ReadLine();
            Console.WriteLine(ReverseEachWord(str));
        }
    }
}