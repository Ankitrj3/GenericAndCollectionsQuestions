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
            InvestmentUtility service = new InvestmentUtility();
            try{
            while (true)
            {
                Console.WriteLine("1 → Display Investments");
                Console.WriteLine("2 → Update Risk");
                Console.WriteLine("3 → Add Investment");
                Console.WriteLine("4 → Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        SortedDictionary<int, List<Investment>> res = service.GetAll();
                        foreach(var i in res)
                        {
                            foreach(var item in i.Value)
                            {
                                Console.WriteLine($"{item.InvestmentId} {item.AssetName} {item.RiskRating}");
                            }        
                        }
                        break;
                    case 2:
                        // TODO: Update entity
                        Console.WriteLine("Update Risk");
                        string? val = Console.ReadLine();
                        string [] arr = val.Split(" ");
                        string? uid = arr[0];
                        int urisk = int.Parse(arr[1]);
                        service.UpdateRisk(uid, urisk);
                        break;
                    case 3:
                        // TODO: Add entity
                        Console.WriteLine("Add Investment");
                        string? val1 = Console.ReadLine();
                        string [] arr1 = val1.Split(" ");
                        string? aid = arr1[0];
                        string? aname = arr1[1];
                        int arisk = int.Parse(arr1[2]);
                        Investment investment = new Investment(aid,aname,arisk);
                        service.AddInvestment(investment);
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
