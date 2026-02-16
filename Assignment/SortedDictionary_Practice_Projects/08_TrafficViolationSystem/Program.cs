using System;
using Domain;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementService service = new ManagementService();

            while (true)
            {
                Console.WriteLine("1 → Display Violations");
                Console.WriteLine("2 → Pay Fine");
                Console.WriteLine("3 → Add Violation");
                Console.WriteLine("4 → Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        SortedDictionary<int ,List<Violation>> res = service.GetAll();
                        foreach(var i in res)
                        {
                            foreach(var item in i.Value)
                            {
                                Console.WriteLine($"{item.VehicleNumber} {item.OwnerName} {item.FineAmount}");
                            }
                        }
                        break;
                    case 2:
                        // TODO: Pay Fine
                        Console.WriteLine("Pay Fine");
                        string val = Console.ReadLine();
                        string[] arr = val.Split(" ");
                        string pvn = arr[0];
                        int pfine = int.Parse(arr[1]);
                        service.PayFine(pvn,pfine);
                        break;
                    case 3:
                        // TODO: Add entity
                        Console.WriteLine("Add Violation");
                        string val1 = Console.ReadLine();
                        string[] arr1 = val1.Split(" ");
                        string avn = arr1[0];
                        string aon = arr1[1];
                        int afine = int.Parse(arr1[2]);
                        Violation violation = new Violation(avn,aon,afine);

                        service.AddViolation(violation);
                        break;
                    case 4:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Inavlid Choice");
                        break;
                }
            }
        }
    }
}
