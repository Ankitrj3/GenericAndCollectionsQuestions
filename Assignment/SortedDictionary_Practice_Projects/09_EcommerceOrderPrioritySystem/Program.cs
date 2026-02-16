using System;
using Domain;
using Exceptions;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            try{
            while (true)
            {
                Console.WriteLine("1 → Display Orders");
                Console.WriteLine("2 → Update Order");
                Console.WriteLine("3 → Add Order");
                Console.WriteLine("4 → Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display Order
                        SortedDictionary<int, List<Order>> res = service.DisplayOrder();

                        foreach(var i in res)
                            {
                                foreach(var j in i.Value)
                                {
                                    Console.WriteLine($"{j.CustomerName} {j.OrderAmount} {j.OrderId}");
                                }
                            }
                        break;
                    case 2:
                        // TODO: Update Order
                        string val = Console.ReadLine();
                        string[] arr = val.Split(" ");
                        string uorderId = arr[0];
                        int uprice = int.Parse(arr[1]);
                        service.UpdateOrder(uorderId,uprice);
                        break;
                    case 3:
                        // TODO: Add Order
                        string val1 = Console.ReadLine();
                        string[] arr1 = val1.Split(" ");
                        string aorderid = arr1[0];
                        string acn = arr1[1];
                        int aprice = int.Parse(arr1[2]);
                        Order order = new Order(aorderid,acn,aprice);
                        service.AddOrder(order);
                        break;
                    case 4:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }catch(CustomBaseException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
