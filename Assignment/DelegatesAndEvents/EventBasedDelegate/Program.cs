using System.Net.NetworkInformation;

namespace Events
{
    public delegate void CustomOrder(string msg);
    public class OrderService
    {
        public event CustomOrder OrderEvent;
        public void TriggerEvent(string msg)
        {
            OrderEvent?.Invoke(msg);
        }

    }
    public class Program
    {
        public static void SendConfirmationEmail(string orderId)
        {
            Console.WriteLine($"{orderId} is order is placed");
        }
        public static void UpdateInventory(string orderId)
        {
            Console.WriteLine($"{orderId} is placed so Update inventory");
        }
        public static void Main()
        {
            OrderService s = new OrderService();
            s.OrderEvent += SendConfirmationEmail;
            s.OrderEvent += UpdateInventory;

            s.TriggerEvent("ORD7823");
        }
    }
}