using System.Text.RegularExpressions;
public class InvalidEntryException : Exception
{
    public InvalidEntryException(string message) : base(message)
    {
    }
}
public interface IUser
{
    string? EmployeeID{get;set;}
    string? EntryType{get;set;}
    int Duration{get;set;}
}
public class UserCheck : IUser
{
    public string? EmployeeID{get;set;}
    public string? EntryType{get;set;}
    public int Duration{get;set;}
    public UserCheck(){}
    public UserCheck(string employeeId, string entryType, int duration)
    {
        EmployeeID = employeeId;
        EntryType = entryType;
        Duration = duration;
    }

    public bool ValidateEmployeeId(string Id)
    {
        bool Check = Regex.IsMatch(Id,@"^[A-Z]{5}/\d{4}$");
        if (!Check)
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        return true;
    }
    public bool ValidateDuration(int duration)
    {
        if(duration < 1 || duration > 5)
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        return true;
    }
}
public class Program
{
    public static void Main()
    {
        UserCheck user = new UserCheck();

        Console.WriteLine("Enter The Number of Entites");
        string? N = Console.ReadLine();
        int n = int.Parse(N);
        
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine($"Entet entry {i+1} details");
            string input = Console.ReadLine();
            string[] inputarr = input.Split(':');
            string Id = inputarr[0];
            int duration = int.Parse(inputarr[2]);

            try
            {
                user.ValidateEmployeeId(Id);
                user.ValidateDuration(duration);
                Console.WriteLine("Valid Entry");
                
            }catch(InvalidEntryException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}