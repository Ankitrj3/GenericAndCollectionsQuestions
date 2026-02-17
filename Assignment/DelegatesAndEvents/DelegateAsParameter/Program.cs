namespace DelegateAsParameter
{
    public delegate int Operation(int a, int b);

    public class Program
    {
        public static void Main()
        {
            Operation op = Add;
            Excute(op,34,5);
        }
        private static void Excute(Operation op, int a, int b)
        {
            Console.WriteLine(op(a,b));
        }
        private static int Add(int a, int b)
        {
            return a+b;        
        }
        private static int Sub(int a, int b)
        {
            return a+b;        
        }
    }
}