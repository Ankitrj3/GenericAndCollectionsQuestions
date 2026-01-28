using System.Text.RegularExpressions;

public class InvalidGadgetException : Exception
{
    public InvalidGadgetException(string message) : base(message)
    {
        
    }
}
public class ShopValidator
{
    public bool validateGadgetId(string gadgetId)
    {
        bool check = Regex.IsMatch(gadgetId,@"[A-Z]{1}\d{3}");
        if (!check)
        {
            throw new InvalidGadgetException("Invalid Gadget Id");
        }      
        return true;  
    }
    public bool ValidateWarranty(int period)
    {
        if(period < 6 || period > 36)
        {
            throw new InvalidGadgetException("Invalid Warranty Period");
        }
        return true;
    }
}
public class Program
{
    public static void Main()
    {
        ShopValidator sh = new ShopValidator();
        Console.WriteLine("Enter the number of gadget entries");
        string? N = Console.ReadLine();
        int n = int.Parse(N);

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter gadget {i+1} details");
            string? input = Console.ReadLine();
            string[] inputarr = input.Split(':');
            string? Id = inputarr[0];
            int warranty = int.Parse(inputarr[2]);

            try
            {
                sh.validateGadgetId(Id);
                sh.ValidateWarranty(warranty);
                
                Console.WriteLine($"Warranty accepted, stock updated");
            }catch(InvalidGadgetException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}