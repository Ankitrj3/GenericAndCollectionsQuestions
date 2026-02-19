// SCENARIO 2: Vehicle Rental System (M1-Friendly)

// Problem Statement
// Design a Vehicle Rental System using OOP concepts.

// Business Requirements:

// Create an interface IVehicle

// Properties:

// RegNo

// Brand

// BaseRate

// Method:

// CalculateRate(int days, double kms)

// Create an abstract class VehicleBase implementing IVehicle

// Implement common properties

// Keep CalculateRate() abstract

// Create derived classes:

// Car

// Bike

// Rules:

// Renting days must be > 0

// Car:

// Bill = BaseRate × days

// If kms > 150 → apply extra charge per km

// Bike:

// Bill = BaseRate × days

// If kms > 100 → apply extra charge per km

// Cannot calculate bill for a vehicle that is not rented

// Create Custom Exceptions:

// VehicleNotFoundException

// InvalidRentalException

// VehicleNotRentedException

// Store vehicles in:

// List<IVehicle>

// Store active rentals in:

// Dictionary<string, int>

// 🔎 LINQ Tasks:

// Get vehicles with BaseRate > 2000

// Get total base rate of all vehicles

// Get top 3 highest base rate vehicles

// Group vehicles by type (Car/Bike)

// Find vehicles whose brand starts with "R"

// Sample Input (M1 Style – Simple)
// 3
// Car TN10AB1234 TataNexon 2499
// Bike KA05ZZ9090 RoyalEnfield 899
// Car DL8CAE7777 HyundaiI20 3199

// 2
// TN10AB1234 3 187.6
// KA05ZZ9090 2 90
public class VehicleNotFoundException : Exception
{
    public VehicleNotFoundException(string message) : base(message){}   
}
public class InvalidRentalException : Exception
{
    public InvalidRentalException(string message) : base(message){}
}

public class VehicleNotRentedException : Exception
{
    public VehicleNotRentedException(string message) : base(message){}
}
interface IVehicle
{
    string? RegNo{get;}
    string? Brand{get;}
    double BaseRate{get;}
    double CalculateRate(int days, double kms);
}
public abstract class VehicleBase : IVehicle
{
    public string? RegNo{get; set;}
    public string? Brand{get; set;}
    public double BaseRate{get; set;}
    public abstract double CalculateRate(int days, double kms);
}
public class Car : VehicleBase
{
    public override double CalculateRate(int days, double kms)
    {
        if(days < 0)
        {
            throw new InvalidRentalException("Days should More then 0");
        }
        double total = BaseRate * days;

        if(kms > 150)
        {
            total += (kms - 150) * 5;
        }
        return total;
    }
}
public class Bike : VehicleBase
{
    public override double CalculateRate(int days, double kms)
    {
        if(days < 0)
        {
            throw new InvalidRentalException("Days should More then 0");
        }
        double total = BaseRate * days;

        if(kms > 100)
        {
            total += (kms - 100) * 3;
        }
        return total;
    }
}
public class Program
{
    public static void Main()
    {
        // Sample Input (M1 Style – Simple)
        // 3
        // Car TN10AB1234 TataNexon 2499
        // Bike KA05ZZ9090 RoyalEnfield 899
        // Car DL8CAE7777 HyundaiI20 3199

        // 2
        // TN10AB1234 3 187.6
        // KA05ZZ9090 2 90
        List<IVehicle> vehicles = new List<IVehicle>();
        Console.WriteLine("Enter the Vehicle Details");
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            string? val = Console.ReadLine();
            string [] value = val.Split(" ");
            string type = value[0];
            string reg = value[1];
            string brand = value[2];
            double rate = double.Parse(value[3]);
            if (type == "Car")
            {
                vehicles.Add(new Car { RegNo = reg, Brand = brand, BaseRate = rate });
            }
            else if (type == "Bike")
            {
                vehicles.Add(new Bike { RegNo = reg, Brand = brand, BaseRate = rate });
            }

        }
        int r = int.Parse(Console.ReadLine());
        for (int i = 0; i < r; i++)
        {
            var parts = Console.ReadLine().Split(' ');

            string reg = parts[0];
            int days = int.Parse(parts[1]);
            double kms = double.Parse(parts[2]);

            var vehicle = vehicles.FirstOrDefault(v => v.RegNo == reg);

            if (vehicle == null)
            {
                Console.WriteLine("VehicleNotFound");
                continue;
            }

            try
            {
                double bill = vehicle.CalculateRate(days, kms);
                Console.WriteLine(bill);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }
        }
    }
}