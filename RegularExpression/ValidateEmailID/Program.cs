using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string pattern = "^[A-Za-z0-9._]+@gmail\\.com$";
        string ank = "rockey12@gmail.com";
        bool mat = Regex.IsMatch(ank,pattern);
        Console.WriteLine(mat);
    }
}