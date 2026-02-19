namespace Delegates
{
    public delegate void Notifier(string message);

    public class Program
    {
        public static void Main()
        {
            string msg = Console.ReadLine();
            BuildPipeline(msg);
        }
        public static void BuildPipeline(string message)
        {
            Notifier notifier = SendEmail;
            notifier+=SendSms;
            notifier+=WriteLog;

            notifier(message);
        }
        public static void SendEmail(string message)
        {
            Console.WriteLine($"Sending EMAIL {message}");
        }
        public static void SendSms(string message)
        {
            Console.WriteLine($"Sending Sms {message}");
        }
        public static void WriteLog(string message)
        {
            Console.WriteLine($"Sending Log {message}");
        }
    }
}