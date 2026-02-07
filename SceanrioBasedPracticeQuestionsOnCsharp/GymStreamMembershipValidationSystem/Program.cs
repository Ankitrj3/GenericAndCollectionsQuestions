public class InvalidTierException : Exception
{
    public InvalidTierException(string message) : base(message){}
}
public class Membership
{
    public string? Tier{get; set;}
    public int DurationInMonth{get; set;}
    public double BasePricePerMonth{get; set;}
    public Membership(){}
    public Membership(string tier, int durationInMonth, double basePricePerMonth)
    {
        Tier = tier;
        DurationInMonth = durationInMonth;
        BasePricePerMonth = basePricePerMonth;
    }
    public bool ValidateEnrollment()
    {
        if(Tier != "Basic" && Tier != "Premium" && Tier != "Elite")
        {
            throw new InvalidTierException("Invalid Tier Exception Occur");
        }
        if(DurationInMonth <= 0)
        {
            throw new Exception("Months Can not be Zero");
        }
        return true;
    }
    public double CalculateTotalBill()
    {
        double BillWithoutDiscount = DurationInMonth * BasePricePerMonth;
        int discount = 0;
        if(Tier == "Basic")
        {
            discount = 2;
        }else if(Tier == "Premium")
        {
            discount = 7;
        }
        else
        {
            discount = 12;
        }
        double FinalDiscountAmount = (BillWithoutDiscount * discount)/100;
        return BillWithoutDiscount - FinalDiscountAmount;
    }
}
public class Program
{
    public static void Main()
    {
        Membership m = new Membership();

        try
        {
            Console.WriteLine("Enter the Tier");
            m.Tier = Console.ReadLine();

            Console.WriteLine("Enter the Months");
            m.DurationInMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Price");
            m.BasePricePerMonth = double.Parse(Console.ReadLine());

            m.ValidateEnrollment();

            Console.WriteLine(m.CalculateTotalBill());
        }
        catch (InvalidTierException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number format");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
