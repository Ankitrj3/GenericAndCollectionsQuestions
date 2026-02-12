using System.Threading.Tasks;

public class Program
{
    public static async Task<string> GetGreetingAsync(string? name)
    {
        await Task.Delay(3000); // 3 second delay - more noticeable
        return $"Hello, {name}!";
    }
    static async Task Main()
    {
        string? str = Console.ReadLine();
        Console.WriteLine("Fetching greeting...");
        string? val = await GetGreetingAsync(str);
        Console.WriteLine(val);
    }
}