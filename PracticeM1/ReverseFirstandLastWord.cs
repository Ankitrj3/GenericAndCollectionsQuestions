// Input:
// "Welcome to Tekstac Platform"
// Output:
// "emocleW to Tekstac mroftalP"

namespace PracticeM1
{
    public class ReverseFirstandLastWord
    {
        public void ReverseStr(string str)
        {
            string[] words = str.Split(" ");

            char[] FirstIdx = words[0].ToCharArray();
            Array.Reverse(FirstIdx);
            words[0] = new string(FirstIdx);

            char[] LastIdx = words[^1].ToCharArray();
            Array.Reverse(LastIdx);
            words[^1] = new string(LastIdx);

            Console.WriteLine(string.Join(" ", words));
        }
    }
}