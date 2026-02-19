
namespace  MultiCast
{
    public delegate void Operation(int a, int b);
    public class Program
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            BuildCal(a,b);

        }   
        public static void BuildCal(int a, int b)
        {
            Operation op = Add;
            op+=Multiply;

            op.Invoke(a,b);
        }
        public static void Add(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        public static void Multiply(int a, int b)
        {
            Console.WriteLine(a*b);
        }
    }
}