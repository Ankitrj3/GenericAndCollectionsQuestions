// 📘 Scenario
// A school wants to manage student details and group them based on class name.

// In Program class
// public static SortedDictionary<int, Student> studentDetails

// In class Student
// string Name
// string ClassName
// int Marks

// In class StudentUtility

// Method 1
// public void AddStudentDetails(string name, string className, int marks)

// Method 2
// public SortedDictionary<string, List<Student>> GroupStudentsByClass()

// Menu:
// 1. Add Student
// 2. Group Students By Class
// 3. Exit

public class Student
{
    public string? Name{get; set;}
    public string? ClassName{get; set;}
    public int Marks{get; set;}

    public Student(){}
}
public class StudentUtility
{
    public static SortedDictionary<int, Student> studentDetails = new SortedDictionary<int, Student>();
    public static int count = 1;

    public void AddStudentDetails(string name, string className, int marks)
    {
        Student student = new Student
        {
            Name = name,
            ClassName = className,
            Marks = marks  
        };
        studentDetails.Add(count, student);
        count++;
    }
    public SortedDictionary<string, List<Student>> GroupStudentsByClass()
    {
        SortedDictionary<string, List<Student>> result = new SortedDictionary<string, List<Student>>();
        foreach(var item in studentDetails)
        {
            Student student = item.Value;

            if (!result.ContainsKey(student.ClassName))
            {
                result[item.Value.ClassName] = new List<Student>();
            }
            result[student.ClassName].Add(student);
        }
        return result;
    }
}
public class Program
{
    public static void Main()
    {
        StudentUtility s = new StudentUtility();

        while (true)
        {
            Console.WriteLine("\n1. Add Student");
            Console.WriteLine("2. Group Students By Class");
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
                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine()!;

                    Console.Write("Enter Class Name: ");
                    string className = Console.ReadLine()!;

                    Console.Write("Enter Marks: ");
                    int marks = int.Parse(Console.ReadLine()!);

                    s.AddStudentDetails(name, className, marks);
                    Console.WriteLine("Student added successfully!");
                    break;

                case 2:
                    SortedDictionary<string, List<Student>> result =
                        s.GroupStudentsByClass();

                    foreach (var item in result)
                    {
                        Console.WriteLine($"\nClass: {item.Key}");
                        foreach (var student in item.Value)
                        {
                            Console.WriteLine($"Name: {student.Name}");
                            Console.WriteLine($"Marks: {student.Marks}");
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
