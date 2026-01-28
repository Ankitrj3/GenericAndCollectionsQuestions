public class Program
{
    public static void Main()
    {
        Dictionary<string,int> StudentMarks = new Dictionary<string, int>();
        StudentMarks.Add("Ankit",90);
        StudentMarks.Add("Likhitha", 100);
        StudentMarks.Add("Suman",88);
        StudentMarks.Add("Aarya",89);

        foreach(var s in StudentMarks)
        {
            Console.WriteLine($"Student Name {s.Key} and Student Marks {s.Value}");
        }
        if (StudentMarks.ContainsKey("Ankit"))
        {
            Console.WriteLine($"Marks of Ankit is {StudentMarks["Ankit"]}");
        }
        else
        {
            Console.WriteLine("Student Not Found");
        }

    }
}