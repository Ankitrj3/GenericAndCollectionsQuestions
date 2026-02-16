using System;
using Domain;
using Exceptions;
using Services;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberUtility service = new MemberUtility();
            try{
            while (true)
            {
                Console.WriteLine("1 → Display Members by Fine");
                Console.WriteLine("2 → Pay Fine");
                Console.WriteLine("3 → Add Member");
                Console.WriteLine("4 → Exit");


                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        SortedDictionary<int,List<Member>> res = service.DisplayMemberByFine();
                        var dict = res.OrderByDescending(s => s.Key).ToDictionary(s => s.Key, s => s.Value);
                            foreach(var i in dict)
                            {
                                foreach(var item in i.Value)
                                {
                                    Console.WriteLine($"{item.Id} {item.Name} {item.Fine}"); 
                                }
                            }
                        break;
                    case 2:
                        Console.WriteLine("Pay Fine");
                        string str = Console.ReadLine();
                        string [] arr = str.Split(" ");
                        string id = arr[0]; 
                        int fine = int.Parse(arr[1]);
                        service.PayFine(id, fine);
                        break;
                    case 3:
                        Console.WriteLine("Enter the Member");
                        string addMem = Console.ReadLine();
                        string [] arr1 = addMem.Split(" ");
                        string addId = arr1[0];
                        string addName = arr1[1];
                        int addFine = int.Parse(arr1[2]);
                        Member member = new Member(addId,addName,addFine);
                        service.AddMember(member);
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
            }
            catch (CustomBaseException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
