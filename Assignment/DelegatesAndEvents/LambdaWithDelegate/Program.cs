public class Program
{
    public delegate int CheckOperation(int a, int b);
    public static void Main()
    {
        int a = 12;
        int b = 5;
        Execute(a,b);
    }
    public static void Execute(int a, int b)
    {
        CheckOperation check = (x,y) => x + y;
        Console.WriteLine(check(a,b));
    }

}