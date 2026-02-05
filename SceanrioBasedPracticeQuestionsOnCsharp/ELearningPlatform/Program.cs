// Question 16: E-Learning Platform
// Scenario: An online learning platform needs to manage courses, students, and progress.
// Requirements:
// csharp
// // In class Course:
// // - string CourseCode
// // - string CourseName
// // - string Instructor
// // - int DurationWeeks
// // - double Price
// // - List<string> Modules

// // In class Enrollment:
// // - int EnrollmentId
// // - string StudentId
// // - string CourseCode
// // - DateTime EnrollmentDate
// // - double ProgressPercentage

// // In class StudentProgress:
// // - string StudentId
// // - string CourseCode
// // - Dictionary<string, double> ModuleScores // Module->Score
// // - DateTime LastAccessed

// // In class LearningManager:
// public void AddCourse(string code, string name, string instructor,
//                      int weeks, double price, List<string> modules)
// public bool EnrollStudent(string studentId, string courseCode)
// public bool UpdateProgress(string studentId, string courseCode, 
//                           string module, double score)
// public Dictionary<string, List<Course>> GroupCoursesByInstructor()
// public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
// Use Cases:
// •	Create courses with modules
// •	Enroll students
// •	Track learning progress
// •	Group courses by instructor
// •	Identify top performers

using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    public string? CourseCode { get; set; }
    public string? CourseName { get; set; }
    public string? Instructor { get; set; }
    public int DurationWeeks { get; set; }
    public double Price { get; set; }
    public List<string> Modules { get; set; } = new List<string>();
}

public class Enrollment
{
    public int EnrollmentId { get; set; }
    public string? StudentId { get; set; }
    public string? CourseCode { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public double ProgressPercentage { get; set; }
}

public class StudentProgress
{
    public string? StudentId { get; set; }
    public string? CourseCode { get; set; }
    public Dictionary<string, double> ModuleScores { get; set; } = new Dictionary<string, double>();
    public DateTime LastAccessed { get; set; }
}

public class LearningManager
{
    public static List<Course> courseDetails = new List<Course>();
    public static List<Enrollment> enrollDetails = new List<Enrollment>();
    public static List<StudentProgress> progressDetails = new List<StudentProgress>();
    public static int counter = 1;

    public void AddCourse(string code, string name, string instructor, int weeks, double price, List<string> modules)
    {
        Course course = new Course()
        {
            CourseCode = code,
            CourseName = name,
            Instructor = instructor,
            DurationWeeks = weeks,
            Price = price,
            Modules = modules
        };
        courseDetails.Add(course);
    }

    public bool EnrollStudent(string studentId, string courseCode)
    {
        bool courseExists = courseDetails.Any(c => c.CourseCode == courseCode);
        if (!courseExists)
        {
            Console.WriteLine("Invalid Course");
            return false;
        }

        Enrollment enrollment = new Enrollment()
        {
            EnrollmentId = counter++,
            StudentId = studentId,
            CourseCode = courseCode,
            EnrollmentDate = DateTime.Now,
            ProgressPercentage = 0
        };

        enrollDetails.Add(enrollment);
        return true;
    }

    public bool UpdateProgress(string studentId, string courseCode, string module, double score)
    {
        var enrollment = enrollDetails
            .FirstOrDefault(e => e.StudentId == studentId && e.CourseCode == courseCode);

        if (enrollment == null)
        {
            Console.WriteLine("Student is not enrolled in this course");
            return false;
        }

        var progress = progressDetails
            .FirstOrDefault(p => p.StudentId == studentId && p.CourseCode == courseCode);

        if (progress == null)
        {
            progress = new StudentProgress
            {
                StudentId = studentId,
                CourseCode = courseCode
            };
            progressDetails.Add(progress);
        }

        progress.ModuleScores[module] = score;
        progress.LastAccessed = DateTime.Now;

        enrollment.ProgressPercentage =
            (double)progress.ModuleScores.Count /
            courseDetails.First(c => c.CourseCode == courseCode).Modules.Count * 100;

        return true;
    }

    public Dictionary<string, List<Course>> GroupCoursesByInstructor()
    {
        Dictionary<string, List<Course>> result = new Dictionary<string, List<Course>>();

        foreach (var item in courseDetails)
        {
            if (!result.ContainsKey(item.Instructor))
            {
                result[item.Instructor] = new List<Course>();
            }
            result[item.Instructor].Add(item);
        }
        return result;
    }

    public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
    {
        return enrollDetails
            .Where(e => e.CourseCode == courseCode)
            .OrderByDescending(e => e.ProgressPercentage)
            .Take(count)
            .ToList();
    }
}
public class Program
{
    public static void Main()
    {
        
    }
}