using System;
using System.Collections.Generic;

public interface IStudent
{
    int Id{get; set;}
    string? Name{get; set;}
    string? Course{get; set;}
    int Marks{get; set;}
}
public interface ICourseSystem
{
    void AddStudent(IStudent student);
    void RemoveStudent(IStudent student);
    int CalculateTotalMarks();
    List<(string, int)> CourseTotalMarks();
    List<(string, int)> StudentInfo();
    List<(string, int)> CourseWiseStudentCount();
}
public class Student : IStudent
{
    public int Id{get; set;}
    public string? Name{get; set;}
    public string? Course{get; set;}
    public int Marks{get; set;}
    public Student(){}
}
public class CourseSystem : ICourseSystem
{
    private List<IStudent> _Student = new List<IStudent>();

    public void AddStudent(IStudent student)
    {
        if(_Student.Any(s => s.Id == student.Id))
        {
            Console.WriteLine("Student is present!");
            return;
        }
        else
        {
            _Student.Add(student);
        }
    }
    public void RemoveStudent(IStudent student)
    {
        var delete = _Student.FirstOrDefault(s => s.Id == student.Id);
        if(delete != null)
        {
            _Student.Remove(delete);
        }
        else
        {
            Console.WriteLine("Student is not Present");
        }
    }
    public int CalculateTotalMarks()
    {
        return _Student.Sum(s => s.Marks);
    }
    public List<(string, int)> StudentInfo() // these are returning tuples in list
    {
        return _Student.Select(s => (s.Name! , s.Marks))
                       .ToList();
    }

    public List<(string, int)> CourseTotalMarks() // these are returning tuples in list
    {
        return _Student.GroupBy(s => s.Course)
                       .Select(k => (k.Key!, k.Sum(x=> x.Marks)))
                       .ToList();
    }
    public List<(string, int)> CourseWiseStudentCount() // these are returning tuples in list
    {
        return _Student.GroupBy(s => s.Course)
                       .Select(k => (k.Key!, k.Count()))
                       .ToList();
    }
}

public class Program
{
    public static void Main()
    {
        ICourseSystem courseSystem = new CourseSystem();

        Console.Write("Enter number of students to add in course: ");
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"\nEnter details for Student {i}:");

            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Course: ");
            string course = Console.ReadLine()!;

            Console.Write("Marks: ");
            int marks = int.Parse(Console.ReadLine()!);

            IStudent student = new Student
            {
                Id = id,
                Name = name,
                Course = course,
                Marks = marks
            };

            courseSystem.AddStudent(student);
        }

        Console.WriteLine("\n--- Student Info ---");
        foreach (var s in courseSystem.StudentInfo())
        {
            Console.WriteLine($"Name: {s.Item1}, Marks: {s.Item2}");
        }

        Console.WriteLine("\n--- Course Total Marks ---");
        foreach (var c in courseSystem.CourseTotalMarks())
        {
            Console.WriteLine($"Course: {c.Item1}, Total Marks: {c.Item2}");
        }

        Console.WriteLine("\n--- Course-wise Student Count ---");
        foreach (var c in courseSystem.CourseWiseStudentCount())
        {
            Console.WriteLine($"Course: {c.Item1}, Student Count: {c.Item2}");
        }

        Console.WriteLine("\nTotal Marks of All Students: " +
                          courseSystem.CalculateTotalMarks());
    }
}
