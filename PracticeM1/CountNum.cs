namespace ank
{
    public class CountDigitString
    {
        public void CountNums(string str)
        {
            int count = 0;
            foreach (char i in str)
            {
                if (i >= '0' && i <= '9')
                {
                    count++;
                }
            }
            Console.WriteLine($"In this string {str} number of Digit Present {count} ");
        }
    }
}
