namespace PracticeM1
{
    public class CountVowelsInString
    {
        public void CountVowel(string str)
        {
            int count = 0;
            foreach (var i in str)
            {
                if ("aeiouAEIOU".Contains(i))
                {
                    count++;
                }
            }
            Console.WriteLine(count + " this much vowel is present in string");
        }
    }
}