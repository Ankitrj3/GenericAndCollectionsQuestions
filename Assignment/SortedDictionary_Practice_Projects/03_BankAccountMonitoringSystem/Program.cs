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
            AccountUtility service = new AccountUtility();
            try{
            while (true)
            {
                Console.WriteLine("1. Display Account");
                Console.WriteLine("2. Add Bank Account");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Exit");

                // TODO: Read user choice

                int choice = int.Parse(Console.ReadLine()); // TODO

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        SortedDictionary<double, List<Account>> res = service.GetAllAccount();
                        var v = res.OrderByDescending(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

                        foreach(var i in v)
                        {
                            foreach(var j in i.Value)
                            {
                                Console.WriteLine($"{j.AccountHolder} {j.Balance:F2}");
                            }
                        }
                        break;
                    case 2:
                        // TODO: Add entity
                        Console.WriteLine("Enter the Account Details");
                        string? val = Console.ReadLine();
                        string [] arr = val.Split(" ");
                        string accountNo = arr[0];
                        string accountHolder = arr[1];
                        double balance = double.Parse(arr[2]);
                        Account account = new Account(accountNo,accountHolder,balance);

                        service.AddBankAccount(account);
                        break;
                    case 3:
                        // TODO: Update entity
                        Console.WriteLine("For Deposit enter account no and amount");
                        string dval = Console.ReadLine();
                        string[] arr1 = dval.Split(" ");
                        string daccountNo = arr1[0];
                        double dbalance = double.Parse(arr1[1]);

                        service.Deposit(daccountNo,dbalance);
                        break;
                    case 4:
                        Console.WriteLine("For Withdraw enter account no and amount");
                        string wval = Console.ReadLine();
                        string[] arr2 = wval.Split(" ");
                        string waccountNo = arr2[0];
                        double wbalance = double.Parse(arr2[1]);

                        service.Withdraw(waccountNo,wbalance);
                        break;
                    case 5:
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
