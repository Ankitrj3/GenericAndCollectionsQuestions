public interface IEmployee
{
    int EmpId { get; set; }
    string Name { get; set; }
    string Department { get; set; }
    int Salary { get; set; }
}
public interface IPayrollSystem
{
    void AddEmployee(IEmployee employee);
    void RemoveEmployee(IEmployee employee);

    int CalculateTotalSalary();

    List<(string, int)> DepartmentTotalSalary();
    List<(string, int)> EmployeeInfo();
    List<(string, int)> DepartmentWiseEmployeeCount();
}
public class Employee : IEmployee
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Salary { get; set; }
    public Employee(){}
}
public class PayRollSystem : IPayrollSystem
{
    private List<IEmployee> _emp = new List<IEmployee>();
    public void AddEmployee(IEmployee employee)
    {
        if(_emp.Any(e => e.EmpId == employee.EmpId))
        {
            Console.WriteLine("Employee is Already Present");
        }
        else
        {
            _emp.Add(employee);
        }
    }
    public void RemoveEmployee(IEmployee employee)
    {
        if(_emp.Any(e => e.EmpId == employee.EmpId))
        {
            var delete = _emp.FirstOrDefault(e => e.EmpId == employee.EmpId);
            _emp.Remove(delete);
        }
    }
    public int CalculateTotalSalary()
    {
        return _emp.Sum(e => e.Salary);
    }
    public List<(string, int)> EmployeeInfo()
    {
        return _emp.Select(e => (e.Name! , e.Salary))
                   .ToList();
    }
    public List<(string, int)> DepartmentTotalSalary()
    {
        return _emp.GroupBy(s => s.Department)
                   .Select(g => (g.Key!, g.Sum(x=> x.Salary)))
                   .ToList();
    }
    public List<(string, int)> DepartmentWiseEmployeeCount()
    {
        return _emp.GroupBy(s => s.Department)
                   .Select(g => (g.Key!, g.Count()))
                   .ToList();
    }
}
public class Program
{
    public static void Main()
    {
        IPayrollSystem payroll = new PayRollSystem();

        // Create Employees
        IEmployee e1 = new Employee
        {
            EmpId = 1,
            Name = "Ankit",
            Department = "IT",
            Salary = 50000
        };

        IEmployee e2 = new Employee
        {
            EmpId = 2,
            Name = "Rohit",
            Department = "IT",
            Salary = 60000
        };

        IEmployee e3 = new Employee
        {
            EmpId = 3,
            Name = "Priya",
            Department = "HR",
            Salary = 40000
        };

        IEmployee e4 = new Employee
        {
            EmpId = 4,
            Name = "Sneha",
            Department = "HR",
            Salary = 45000
        };

        // Add Employees
        payroll.AddEmployee(e1);
        payroll.AddEmployee(e2);
        payroll.AddEmployee(e3);
        payroll.AddEmployee(e4);

        // Employee Info
        Console.WriteLine("Employee Info:");
        foreach (var (name, salary) in payroll.EmployeeInfo())
        {
            Console.WriteLine($"Name:{name}, Salary:{salary}");
        }

        // Department Total Salary
        Console.WriteLine("\nDepartment Total Salary:");
        foreach (var (dept, totalSalary) in payroll.DepartmentTotalSalary())
        {
            Console.WriteLine($"Department:{dept}, Total Salary:{totalSalary}");
        }

        // Department Wise Employee Count
        Console.WriteLine("\nDepartment Wise Employee Count:");
        foreach (var (dept, count) in payroll.DepartmentWiseEmployeeCount())
        {
            Console.WriteLine($"Department:{dept}, Employee Count:{count}");
        }

        // Total Salary
        int total = payroll.CalculateTotalSalary();
        Console.WriteLine($"\nTotal Salary Paid: {total}");

        // Remove Employee test
        payroll.RemoveEmployee(e2);

        Console.WriteLine("\nAfter Removing Rohit:");
        foreach (var (name, salary) in payroll.EmployeeInfo())
        {
            Console.WriteLine($"Name:{name}, Salary:{salary}");
        }
    }
}
