using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Department { get; set; }
    public double Salary { get; set; }

    public Employee(string department, double salary)
    {
        Department = department;
        Salary = salary;
    }
}

public class Program
{
    static Dictionary<string, double> GetAverageSalaryByDepartment(List<Employee> employees)
    {
        return employees.GroupBy(s => s.Department)
                        .ToDictionary(s => s.Key, s => s.Average(x => x.Salary));
    }

    public static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee("IT", 50000),
            new Employee("HR", 30000),
            new Employee("IT", 70000),
            new Employee("HR", 50000),
            new Employee("Admin", 40000)
        };

        var result = GetAverageSalaryByDepartment(employees);
        foreach (var kv in result)
            Console.WriteLine($"{kv.Key} = {kv.Value}");
    }
}
