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
            MedicalUtility service = new MedicalUtility();
            try
            {
                while (true)
                {
                    Console.WriteLine("1. Display");
                    Console.WriteLine("2. Add");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Exit");

                    // TODO: Read user choice

                    int choice = int.Parse(Console.ReadLine()); // TODO

                    switch (choice)
                    {
                        case 1:
                            // TODO: Display data
                            Dictionary<string, Medicine> res = service.GetAll();
                            foreach (var i in res)
                            {
                                Console.WriteLine(i.Key + " " + i.Value.Name + " " + i.Value.Price + " " + i.Value.ExpiryYear);
                            }
                            break;
                        case 2:
                            // TODO: Add entity
                            Console.WriteLine("Add Medicine");
                            string value = Console.ReadLine();
                            string[] arr = value.Split(" ");
                            string? id = arr[0];
                            string? name = arr[1];
                            double price = double.Parse(arr[2]);
                            int exp = int.Parse(arr[3]);

                            Medicine medicine = new Medicine(id, name, price, exp);
                            service.AddMedicine(medicine);
                            break;
                        case 3:
                            // TODO: Update entity
                            Console.WriteLine("Update Medicine");
                            string val = Console.ReadLine();
                            string[] arr1 = val.Split(" ");
                            string id1 = arr1[0];
                            double price1 = double.Parse(arr1[1]);
                            service.UpdateMedicine(id1, price1);
                            break;
                        case 4:
                            Console.WriteLine("Thank You");
                            return;
                        default:
                            // TODO: Handle invalid choice
                            break;
                    }
                }
            }
            catch (CustomBaseException e)
            {
                Console.WriteLine(e.Message);
            }
            {

            }
        }
    }
}
