public class NotificationSystem
{
    public void ProcessTask<T>(T item, Action<T> action)
    {
        Console.WriteLine("Intialize the Process...");
        action(item);
        Console.WriteLine("Completing Process...");
    }
}
public class Program
{
    public static void Main()
    {
        var notificationSystem = new NotificationSystem();
        notificationSystem.ProcessTask("Order Id#1289",msg => Console.WriteLine($"Send the Message to this {msg}"));
        notificationSystem.ProcessTask(2300.45,price => Console.WriteLine($"Price of this order is {price}"));
    }
}