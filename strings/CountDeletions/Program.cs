public class Program
{
    public static int CountDelete(string s1, string s2)
    {
        char [] ch1 = s1.ToCharArray();
        char [] ch2 = s2.ToCharArray();
        int i = 0;
        int j = 0;
        int DeleteCount = 0;

        while(i < ch1.Length && j < ch2.Length)
        {
            if(ch1[i] == ch2[j])
            {
                i++;
                j++;
            }
            else
            {
                DeleteCount++;
                i++;
            }
            
        }
        DeleteCount += ch1.Length - i;
        return DeleteCount;
    }
    public static void Main()
    {
        Console.WriteLine("Enter String 1");
        string? s1 = Console.ReadLine();
        Console.WriteLine("Enter String 2");
        string? s2 = Console.ReadLine();
        Console.WriteLine("Deleted Element from string one "+CountDelete(s1,s2));
    }
}