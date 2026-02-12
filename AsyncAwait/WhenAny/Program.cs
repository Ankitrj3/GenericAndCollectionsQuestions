using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Task<string> slow = GetValueAsync("slow", 900);
        Task<string> fast = GetValueAsync("fast", 300);

        Task<string> first = await Task.WhenAny(slow, fast);
        Console.WriteLine("First finished: " + await first);
    }

    static async Task<string> GetValueAsync(string name, int delayMs)
    {
        await Task.Delay(delayMs);
        return name;
    }
}