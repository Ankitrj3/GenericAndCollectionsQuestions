// Question 3: Employee Management System
// Scenario: A company needs to manage employees and organize them by department.
// Requirements:
// csharp
// // In class Employee:
// // - int EmployeeId
// // - string Name
// // - string Department
// // - double Salary
// // - DateTime JoiningDate

// // In class HRManager:
// public void AddEmployee(string name, string dept, double salary)
// // Auto-generate EmployeeId (E001, E002...)

// public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
// // Groups employees by department

// public double CalculateDepartmentSalary(string department)
// // Returns total salary of a department

// public List<Employee> GetEmployeesJoinedAfter(DateTime date)
// // Returns employees joined after specific date
// Sample Use Cases:
// 1.	Add employees to HR/IT/Sales departments
// 2.	Display department-wise employee lists
// 3.	Calculate total salary expenditure per department
// 4.	Find employees who joined recently

public class Employee
{
    public int EmployeeId{get; set;}
    public string Name{get; set;}
    public string Department{get; set;}
    public double Salary{get; set;}
    public DateTime JoiningDate{get; set;}
    public Employee(){}
}
class HRManager
{
    public static SortedDictionary<int, Employee> employeeList = new SortedDictionary<int, Employee>();
    public static int counter = 1;
    public void AddEmployee(string name, string dept, double salary)
    {
        Employee employee = new Employee()
        {
            EmployeeId = counter,
            Name = name,
            Department = dept,
            Salary = salary,
            JoiningDate = DateTime.Now
        };
        employeeList.Add(counter,employee);
        counter++;
    }
    public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
    {
        SortedDictionary<string, List<Employee>> result = new SortedDictionary<string, List<Employee>>();
        foreach(var item in employeeList)
        {
            var emp = item.Value;
            if (!result.ContainsKey(emp.Department))
            {
                result[emp.Department] = new List<Employee>();
            }
            result[emp.Department].Add(emp);
        }
        return result;
    }
    public double CalculateDepartmentSalary(string department)
    {
        double totalSalary = 0;
        foreach(var item in employeeList)
        {
            var emp = item.Value;
            if(emp.Department == department)
            {
                totalSalary += emp.Salary;
            }
        }
        return totalSalary;
    }
    public List<Employee> GetEmployeesJoinedAfter(DateTime date)
    {
        List<Employee> result = new List<Employee>();
        foreach(var item in employeeList)
        {
            var emp = item.Value;
            if(emp.JoiningDate > date)
            {
                result.Add(emp);
            }
        }
        return result;
    }
}
class Program
{
    public static void Main()
    {
        HRManager hr = new HRManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Employee");
            Console.WriteLine("2. Display Employees Grouped By Department");
            Console.WriteLine("3. Calculate Department Salary");
            Console.WriteLine("4. Find Employees Joined After Date");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 5)
            {
                Console.WriteLine("Exiting application...");
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine()!;

                    Console.Write("Enter Department: ");
                    string dept = Console.ReadLine()!;

                    Console.Write("Enter Salary: ");
                    double salary = double.Parse(Console.ReadLine()!);

                    hr.AddEmployee(name, dept, salary);
                    Console.WriteLine("Employee added successfully!");
                    break;

                case 2:
                    SortedDictionary<string, List<Employee>> grouped =
                        hr.GroupEmployeesByDepartment();

                    foreach (var item in grouped)
                    {
                        Console.WriteLine($"\nDepartment: {item.Key}");
                        foreach (var emp in item.Value)
                        {
                            Console.WriteLine(
                                $"E{emp.EmployeeId:D3} - {emp.Name} - Salary: {emp.Salary}");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Department Name: ");
                    string department = Console.ReadLine()!;

                    double totalSalary =
                        hr.CalculateDepartmentSalary(department);

                    Console.WriteLine(
                        $"Total Salary for {department}: {totalSalary}");
                    break;

                case 4:
                    Console.Write("Enter Date (yyyy-MM-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine()!);

                    List<Employee> recentEmployees =
                        hr.GetEmployeesJoinedAfter(date);

                    if (recentEmployees.Count == 0)
                    {
                        Console.WriteLine("No employees found.");
                        break;
                    }

                    foreach (var emp in recentEmployees)
                    {
                        Console.WriteLine(
                            $"E{emp.EmployeeId:D3} - {emp.Name} - Joined: {emp.JoiningDate:yyyy-MM-dd}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
