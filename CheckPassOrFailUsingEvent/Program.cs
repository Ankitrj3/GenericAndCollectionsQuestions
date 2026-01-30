namespace Events
{
    public delegate void PrintResult(double res);

    public class Program
    {
        public static string? Message{get; set;}
        public static event PrintResult ResultEvent;
        public static void CheckResult(double res)
        {
            double result = (res / 500) * 100;
            if (result >= 50)
            {
                Message = $"You are Passed {result:F2}%";
            }
            else
            {
                Message = $"You Need Try Again {result:F2}%";
            }
            Console.WriteLine(Message);
        }
        public static void Print(double res)
        {
            ResultEvent?.Invoke(res);
        }

        public static void Main()
        {
            ResultEvent += CheckResult;
            while (true)
            {
                Console.WriteLine("Enter 1 To Check You Are Passed or Not And For Exit Press 2");
                string? N = Console.ReadLine();
                int num = int.Parse(N);

                if(num == 2)
                {
                    Console.WriteLine("Exiting....");
                    break;
                }
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Enter Marks marks of 5 Subjects like this -> maths:english:computer:it:science ");
                        string? Marks = Console.ReadLine();
                        string[] arrMarks = Marks.Split(':');
                        double marks1 = double.Parse(arrMarks[0]);
                        double marks2 = double.Parse(arrMarks[1]);
                        double marks3 = double.Parse(arrMarks[2]);
                        double marks4 = double.Parse(arrMarks[3]);
                        double marks5 = double.Parse(arrMarks[4]);
                        double finalMarks = marks1 + marks2 + marks3 + marks4 + marks5;
                        Print(finalMarks);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                
            }
        }
    }
}