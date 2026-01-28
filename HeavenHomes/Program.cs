public class HeavenHomes
{
    private static Dictionary<string, double> apartmentDetailsMap = new Dictionary<string, double>();
    public void addApartmentDetails(string apartmentNumber, double rent)
    {
        apartmentDetailsMap[apartmentNumber] = rent;
    }
    public double findTotalRentOfApartmentInGivenRange(double minimumRent, double maximumRent)
    {
        double res = 0;
        foreach(var i in apartmentDetailsMap)
        {
            if(i.Value>=minimumRent && i.Value <= maximumRent)
            {
                res += i.Value;
            }
        }
        return res;
    }
}
public class Program
{
    public static void Main()
    {
        HeavenHomes h = new HeavenHomes();

        Console.WriteLine("Enter the Number of Details to Be Added");
        string? N = Console.ReadLine();
        int n = int.Parse(N);

        Console.WriteLine("Enter the Details ApartmentNumber:Rent");
        for(int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string [] arrinput = input.Split(':');
            string apNum = arrinput[0];
            double rent = double.Parse(arrinput[1]);

            h.addApartmentDetails(apNum,rent);
        }
        Console.WriteLine("Enter the Range to Filter the Details");
        string Min = Console.ReadLine();
        string Max = Console.ReadLine();

        double min = double.Parse(Min);
        double max = double.Parse(Max);

        double res = h.findTotalRentOfApartmentInGivenRange(min,max);
        if(res == 0)
        {
            Console.WriteLine("No Apartment Found in this Range");
        }
        else{
            Console.WriteLine($"Total Rent in the range {min} and {max} USD:{res}");
        }
    }
}