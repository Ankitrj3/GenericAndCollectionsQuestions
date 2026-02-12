public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Starting......");
        string? val = await GetResponseUsingDelay();
        Console.WriteLine($"Data Fetch {val}");
        Console.WriteLine("Done");
    }
    public static async Task<string> GetResponseUsingDelay()
    {
        await Task.Delay(5000);
        Console.WriteLine("Task Completed.....");
        return "ETCA400";
    }
}