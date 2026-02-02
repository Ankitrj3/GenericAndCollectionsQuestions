// 📘 Scenario
// A company wants to manage employee details and display them grouped by department.

// In Program class
// public static SortedDictionary<int, Employee> employeeDetails

// In class Employee
// string Name
// string Department
// int Salary

// In class EmployeeUtility

// Method 1
// public void AddEmployee(string name, string department, int salary)

// Method 2
// public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()

// Menu:
// 1. Add Employee
// 2. Group Employees By Department
// 3. Exit
public class Employee
{
    public string? Name{get; set;}
    public string? Department{get; set;}
    public int Salary{get; set;}
    public Employee(){}
}
public class EmployeeUtility
{
    public EmployeeUtility(){}
    public static SortedDictionary<int, Employee> employeeDetails = new SortedDictionary<int, Employee>();
    public static int count = 1;

    public void AddEmployee(string name, string department, int salary)
    {
        Employee employee = new Employee()
        {
            Name = name,
            Department = department,
            Salary = salary  
        };
        employeeDetails.Add(count, employee);
        count++;
    }
    public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
    {
        SortedDictionary<string, List<Employee>> result = new SortedDictionary<string, List<Employee>>();
        foreach(var item in employeeDetails)
        {
            Employee emp = item.Value;
            if (!result.ContainsKey(emp.Department))
            {
                result[emp.Department] = new List<Employee>();
            }
            result[emp.Department].Add(emp);
        }
        return result;
    }


}
public class Program
{
    public static void Main()
    {
        EmployeeUtility e = new EmployeeUtility();

        while (true)
        {
            Console.WriteLine("\n1. Add Employee");
            Console.WriteLine("2. Group Employees By Department");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            if (choice == 3)
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
                    string department = Console.ReadLine()!;

                    Console.Write("Enter Salary: ");
                    int salary = int.Parse(Console.ReadLine()!);

                    e.AddEmployee(name, department, salary);
                    Console.WriteLine("Employee added successfully!");
                    break;

                case 2:
                    SortedDictionary<string, List<Employee>> result =
                        e.GroupEmployeesByDepartment();

                    foreach (var item in result)
                    {
                        Console.WriteLine($"\nDepartment: {item.Key}");
                        foreach (var emp in item.Value)
                        {
                            Console.WriteLine($"Name: {emp.Name}");
                            Console.WriteLine($"Salary: {emp.Salary}");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
