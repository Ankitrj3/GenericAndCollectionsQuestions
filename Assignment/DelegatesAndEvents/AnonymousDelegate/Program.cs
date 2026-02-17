public class Program
{
    public delegate bool Check(int a);
    public static void Main()
    {
        Check ValCheck = delegate(int a)
        {
           return a % 2 == 0;  
        };
        int val = int.Parse(Console.ReadLine());
        Console.WriteLine(ValCheck(val));
    }
}