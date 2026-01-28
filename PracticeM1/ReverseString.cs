namespace PracticeM1
{
    public class ReverseString
    {
        public void Reversestring(string rev)
        {
            char[] arr = rev.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(new string(arr));
        }
    }
}