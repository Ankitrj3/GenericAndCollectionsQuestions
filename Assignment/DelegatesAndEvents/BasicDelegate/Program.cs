namespace Delegate
{
    public delegate int Report(int a, int b);
    public class Program
    {
        public static void Main()
        {
            int a = 12;
            int b = 4;

            Report report = Diff;
            Console.WriteLine(report(a,b));
        }
        public static int Diff(int a, int b)
        {
            return a - b;
        }
    }
}