using System.Formats.Asn1;

public class Program
{
    public static async Task Main()
    {
        try
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine()); //enter zero

            double res = await DivideValue(a,b);
            Console.WriteLine("Result "+res);
        }catch(Exception e)
        {
            Console.WriteLine($"Error Happened : "+e.Message);
        }
    }
    public static async Task<double> DivideValue(double a, double b)
    {
        await Task.Delay(4000); // pretend the work
        return a/b;
    }
}