using System.Security.Principal;

public interface IExam
{
    public double calculateScore();
    public string evaluateResult(double percentage);
}
public class OnlineTest : IExam
{
    public string? studentName{get; set;}
    public int totalQuestion{get; set;}
    public int correctQuestion{get; set;}
    public int wrongQuestion{get; set;}
    public string? questionType{get; set;}

    public OnlineTest(){}

    public double calculateScore()
    {
        int marks = 0;
        if (questionType.Equals("MCQ"))
        {
            marks = 2;
        }
        else
        {
            marks = 5;
        }
        double totalScore = (correctQuestion * marks) - (wrongQuestion * marks * 0.10);
        double percentage = (totalScore/(totalQuestion * marks))*100;

        return percentage;
    }
    public string evaluateResult(double percentage)
    {
        string? res = "";
        if(percentage >= 85)
        {
            res = "Merit";
        }else if(percentage >=60 || percentage < 85)
        {
            res = "Pass";
        }
        else
        {
            res = "Fail";
        }
        return res;
    }
}
public class Program
{
    public static void Main()
    {
        
        
        Console.WriteLine("Enter Exam Details:");
        Console.WriteLine("Student Name:");
        string? StuName = Console.ReadLine();
        Console.WriteLine("Question Type (MCQ/Coding):");
        string? ExamType = Console.ReadLine();
        Console.WriteLine("Total Question:");
        string? TotalQuestion = Console.ReadLine();
        int totalQuestion1 = int.Parse(TotalQuestion);
        Console.WriteLine("Correct Question:");
        string? CorrectQuestion = Console.ReadLine();
        int correctQuestion1 = int.Parse(CorrectQuestion);
        Console.WriteLine("Wrong Question:");
        string? WrongQuestion = Console.ReadLine();
        int wrongQuestion1 = int.Parse(WrongQuestion);

        OnlineTest on = new OnlineTest()
        {
            studentName = StuName,
            questionType = ExamType,
            totalQuestion = totalQuestion1,
            correctQuestion = correctQuestion1,
            wrongQuestion = wrongQuestion1
        };
        double percentage = on.calculateScore();
        string res = on.evaluateResult(percentage);

        Console.WriteLine("Exam Summary:");
        Console.WriteLine($"{ExamType} Test: {StuName}, Total Score: {percentage}, Result: {res}");
    }
}