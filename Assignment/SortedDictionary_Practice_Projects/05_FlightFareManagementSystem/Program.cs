using System;
using Domain;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketUtility service = new TicketUtility();
            try{
            while (true)
            {
                Console.WriteLine("1 → Display Tickets");
                Console.WriteLine("2 → Add Ticket");
                Console.WriteLine("3 → Update Fare");
                Console.WriteLine("4 → Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        SortedDictionary<int, List<Ticket>> res = service.GetTicketByFare();
                        foreach(var i in res)
                            {
                                foreach(var item in i.Value)
                                {
                                    Console.WriteLine($"{item.TicketId} {item.PassengerName} {item.Fare}"); 
                                }
                            }
                        break;
                    case 2:
                        // TODO: Add entity
                        Console.WriteLine("Add Ticket");
                        string? val = Console.ReadLine();
                        string [] arr = val.Split(" ");
                        string? tid = arr[0];
                        string? tname = arr[1];
                        int fare = int.Parse(arr[2]);

                        Ticket ticket = new Ticket(tid,tname,fare);
                        service.AddTicket(ticket);
                        break;
                    case 3:
                        // TODO: Update entity
                        Console.WriteLine("Enter Fare to Update");
                        string? val1 = Console.ReadLine();
                        string [] arr1 = val1.Split(" ");
                        string uid = arr1[0]; 
                        int ufare = int.Parse(arr1[1]);

                        service.UpdateTicket(uid,ufare);
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
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
