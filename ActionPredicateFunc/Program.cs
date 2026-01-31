using System;

namespace Operation
{
    public class Exam
    {
        // Event that accepts a string
        public event Action<string>? ExamRes;

        // Method to trigger the event
        public void PublishResult(string message)
        {
            ExamRes?.Invoke(message);   // safe invocation
        }

        // Actions
        public void PassCase(string msg)
        {
            Console.WriteLine("Pass!");
        }

        public void Fail(string msg)
        {
            Console.WriteLine("Fail!");
        }
    }

    public class Marks
    {
        // Predicate returns bool
        public Predicate<double> PassCheck = marks => marks >= 50;
    }

    public class Program
    {
        public static void Main()
        {
            Exam e = new Exam();
            Marks m = new Marks();

            Console.Write("Enter marks: ");
            double marks = double.Parse(Console.ReadLine()!);

            bool result = m.PassCheck(marks);

            if (result)
            {
                e.ExamRes += e.PassCase;   // subscribe
            }
            else
            {
                e.ExamRes += e.Fail;       // subscribe
            }

            // Fire the event
            e.PublishResult("Result Published");
        }
    }
}
