// Project Specification: Logistics Pro Shipment System
// 1. Overview
// Global Cargo Solutions is a logistics firm that requires a C# module to manage international shipping costs. The system must validate shipment identifiers and calculate costs based on transport mode, weight, and storage duration.

// 2. Functional Requirements
// 2.1 Data Models
// Implement the following class structure:
// Class: Shipment
// Property Name	Datatype	Access Modifier
// ShipmentCode	string	public
// TransportMode	string	public
// Weight	double	public
// StorageDays	int	public
// Class: ShipmentDetails
// •	Inheritance: Must inherit from the Shipment class.
// •	Method: ValidateShipmentCode()
// o	Return Type: bool
// o	Logic:
// 1.	Length must be exactly 7 characters.
// 2.	Prefix must be "GC#".
// 3.	Characters after the prefix must be digits.
// •	Method: CalculateTotalCost()
// o	Return Type: double (Return value rounded to 2 decimal places).
// o	Formula: $TotalCost = (Weight \times RatePerKg) + \sqrt{StorageDays}$

// 3. Business Rules
// Transport Mode	Rate per Kg (USD)
// Sea	15.00
// Air	50.00
// Land	25.00
// Note: The TransportMode input is case-sensitive.

// 4. Execution Logic (Program Class)
// 1.	Input Phase: Prompt the user for the ShipmentCode.
// 2.	Validation Phase: Call the validation method.
// o	If False: Display "Invalid shipment code" and terminate gracefully.
// o	If True: Proceed to collect TransportMode, Weight, and StorageDays.
// 3.	Calculation Phase: Invoke the cost calculation and display the result.

// 5. Sample Test Cases
// Test Case 1: Success
// •	Input ID: GC#1001
// •	Mode: Air
// •	Weight: 10
// •	Storage: 16
// •	Expected Output: The total shipping cost is 504.00
// Test Case 2: Validation Failure
// •	Input ID: BK#5555
// •	Expected Output: Invalid shipment code


using System.Text.RegularExpressions;

public class Shipment
{
    public string? ShipmentCode{get; set;}
    public string? TransportMode{get; set;}
    public double Weight{get; set;}
    public int StorageDays{get; set;}
    public Shipment(){}
    public Shipment(string shipmentCode, string transportMode, double weight, int storageDays)
    {
        ShipmentCode = shipmentCode;
        TransportMode = transportMode;
        Weight = weight;
        StorageDays = storageDays;
    }
}
public class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        string? pattern = "^GC#[0-9]{4}$";
        bool match = Regex.IsMatch(ShipmentCode,pattern);
        return match;
    }
    
    public double CalculateTotalCost()
    {
        double rate = 0;
        if (TransportMode.Equals("Sea"))
        {
            rate = 15;
        }else if (TransportMode.Equals("Air"))
        {
            rate = 50;
        }
        else
        {
            rate = 25;
        }
        double result = (Weight*rate) + Math.Sqrt(StorageDays);
        return Math.Round(result,2);
    }
}
public class Program
{
    public static void Main()
    {
        ShipmentDetails sd = new ShipmentDetails();

        Console.WriteLine("Enter Shipment Code:");
        sd.ShipmentCode = Console.ReadLine();

        if (!sd.ValidateShipmentCode())
        {
            Console.WriteLine("Invalid shipment code");
            return;
        }

        Console.WriteLine("Enter Transport Mode:");
        sd.TransportMode = Console.ReadLine();

        Console.WriteLine("Enter Weight:");
        sd.Weight = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Storage Days:");
        sd.StorageDays = int.Parse(Console.ReadLine());

        double totalCost = sd.CalculateTotalCost();
        Console.WriteLine($"The total shipping cost is {totalCost:0.00}");
    }
}
