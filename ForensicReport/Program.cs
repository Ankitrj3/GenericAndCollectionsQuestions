public class ForensicReport
{
    private static Dictionary<string, DateOnly> reportMap = new Dictionary<string, DateOnly>();
    public void addReportDetails(string reportingOfficerName, DateOnly date)
    {
        reportMap[reportingOfficerName] = date;
    }
    public List<string> getOfficersWhoFiledReportOnDate(DateOnly date)
    {
        List<string> officer = new List<string>();
        foreach(var i in reportMap)
        {
            if(i.Value  == date)
            {
                officer.Add(i.Key);
            }
        }
        return officer;
    }
}
public class Program
{
    public static void Main()
    {
        ForensicReport fc = new ForensicReport();

        Console.WriteLine("Enter Number of Report to Be Added : ");
        string? N = Console.ReadLine();
        int n = int.Parse(N);

        Console.WriteLine("Enter Forensic Report Reporting Officer:Report Filed Date");
        for(int i = 0; i < n; i++)
        {
            string? input = Console.ReadLine();
            string [] forensic = input.Split(':');
            string? name = forensic[0];
            DateOnly date = DateOnly.Parse(forensic[1]);

            fc.addReportDetails(name, date);
        }
        Console.WriteLine("Enter the Filled Date To identify the Reporting Officer");
        string? D = Console.ReadLine();
        DateOnly date1 = DateOnly.Parse(D);
        List<string> Officers = fc.getOfficersWhoFiledReportOnDate(date1);
        
        Console.WriteLine($"Reports filled on the {D} are by");
        if(Officers == null)
        {
            Console.WriteLine("No Reporting Officer Filled the Report\n");
        }
        else
        {
            foreach(var i in Officers)
            {
                Console.WriteLine(i);
            }
        }
    }
}