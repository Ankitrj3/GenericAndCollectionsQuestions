namespace PracticeM1
{
    public class CheckPalindrome
    {
        public void Check(string str)
        {
            str = str.ToLower();
            string mainString = str;
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            string rev = new string(arr);
            if (mainString.Equals(rev))
            {

                Console.WriteLine("Palindrome");
            }
            else
            {
                Console.WriteLine("Not Palindrome");

            }
        }
    }
}