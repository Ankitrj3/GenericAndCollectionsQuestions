using ExtensionMethod;
public static class Program
{
    public static void Main()
    {
        Student s = new Student(){Id=1,Name="Ankit Ranjan",Marks=65};
        Console.WriteLine(s.IsPassed());
        Console.WriteLine(s.IsEligable());
    }
    public static bool IsPassed(this Student student)
    {
        return student.Marks >= 40;
    }
    public static bool IsEligable(this Student student)
    {
        return student.Marks >= 70;
    }
}