// Q1. Employee Onboarding - Constructor + Validationa
// You are building an onboarding module that stores basic employee information.
// Requirements:
// •	Create class Employee with: Id, Name, Email, Salary.
// •	Use a constructor to initialize all values.
// •	If Salary <= 0, default it to 30000.
// •	If Email does not contain '@', set it to 'unknown@company.com'.
// Task: Create 3 employees with different invalid/valid inputs and print the final stored values.

public class Employee
{
    public int Id{get; set;}
    public string? Name{get; set;}
    public string? Email{get; set;}
    public double Salary{get; set;}

    public Employee(int id, string name, string email, double salary)
    {
        Id = id;
        Name = name;
        if (email.Contains("@"))
        {
            Email = email;
        }
        else
        {
            Email = "unknown@company.com";
        }
        if(salary <= 0)
        {
            Salary = 30000;
        }
        else
        {
            Salary = salary;
        }
    }
    public void Print()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Email: {Email}, Salary: {Salary}");
    }
}
public class Program
{
    public static void Main()
    {
        Employee e1 = new Employee(18,"Ankit Ranjan","ankitrobinranjan@gmail.com",0);
        Employee e2 = new Employee(2, "Amit", "amitgmail.com", -10000);
        Employee e3 = new Employee(3, "Neha", "neha@company.com", 100000);

        e1.Print();
        e2.Print();
        e3.Print();
    }
}