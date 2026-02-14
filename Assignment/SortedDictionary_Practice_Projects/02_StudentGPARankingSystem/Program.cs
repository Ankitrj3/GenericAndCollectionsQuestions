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
            StudentUtility service = new StudentUtility();

            try{
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
                        SortedDictionary<double, List<Student>> res = service.DisplayRanking();
                        var v = res.OrderByDescending(s => s.Key).ToDictionary(s => s.Key , s => s.Value);
                        foreach(var i in v)
                            {
                                foreach(var j in i.Value)
                                {
                                    Console.WriteLine(j.Id+" "+j.Name+" "+j.GPA);
                                }
                            }
                        break;
                    case 2:
                        // TODO: Add entity
                        Console.WriteLine("Add the data");
                        string? val = Console.ReadLine();
                        string[] arr = val.Split(" ");
                        string? id = arr[0];
                        string? name = arr[1];
                        double gpa = double.Parse(arr[2]);
                        Student student = new Student(id,name,gpa);
                        service.AddStudent(id, student);
                        break;
                    case 3:
                        // TODO: Update entity
                        Console.WriteLine("Update the data");
                        string? id1 = Console.ReadLine();
                        double gpa1 = double.Parse(Console.ReadLine());

                        service.UpdateGPA(id1, gpa1);
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
