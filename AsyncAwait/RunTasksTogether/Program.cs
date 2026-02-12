public class Program
{
    public static async Task Main()
    {
        Task<string> t1 = GetValueByAsync("A",7000);
        Task<string> t2 = GetValueByAsync("B",2000);
        Task<string> t3 = GetValueByAsync("C",10000);

        string [] res = await Task.WhenAll(t1,t2,t3);

        Console.WriteLine(string.Join(",",res));
    }

    public static async Task<string> GetValueByAsync(string name, int delayMs)
    {
        await Task.Delay(delayMs);
        return $"{name}-done";
    }
}