// Question 9: Car Rental Agency
// Scenario: A car rental company needs to manage its fleet and rentals.
// Requirements:
// csharp
// // In class RentalCar:
// // - string LicensePlate
// // - string Make
// // - string Model
// // - string CarType (Sedan/SUV/Van)
// // - bool IsAvailable
// // - double DailyRate

// // In class Rental:
// // - int RentalId
// // - string LicensePlate
// // - string CustomerName
// // - DateTime StartDate
// // - DateTime EndDate
// // - double TotalCost

// // In class RentalManager:
// public void AddCar(string license, string make, string model, 
//                    string type, double rate)

// public bool RentCar(string license, string customer, 
//                     DateTime start, int days)
// // Creates rental if car available

// public Dictionary<string, List<RentalCar>> GroupCarsByType()
// // Groups available cars by type

// public List<Rental> GetActiveRentals()
// // Returns current rentals

// public double CalculateTotalRentalRevenue()
// // Sum of all rental costs
// Use Cases:
// •	Add cars to inventory
// •	Process rentals
// •	Check car availability by type
// •	Track active rentals
// •	Calculate revenue

using System.Diagnostics.Metrics;

public class RentalCar
{
    public string? LicensePlate{get; set;}
    public string? Make{get; set;}
    public string Model{get; set;}
    public string CarType{get; set;}
    public bool IsAvailable{get; set;}
    public double DailyRate{get; set;}
    public RentalCar(){}
}
public class Rental
{
    public int RentalId{get; set;}
    public string LicensePlate{get; set;}
    public string CustomerName{get; set;}
    public DateTime StartTime{get; set;}
    public DateTime EndTime{get; set;}
    public double TotalCost{get; set;}
    public Rental(){}
}

public class RentalManager
{
    // // In class RentalManager:
    public static Dictionary<string, RentalCar> carDetails = new Dictionary<string, RentalCar>();
    public static List<Rental> rentals = new List<Rental>();
    public static int counter = 1;
    public void AddCar(string license, string make, string model, string type, double rate)
    {
        if (carDetails.ContainsKey(license))
        {
            Console.WriteLine("Car already exists");
            return;
        }

        RentalCar rentalCar = new RentalCar()
        {
            LicensePlate = license,
            Make = make,
            Model = model,
            CarType = type,
            IsAvailable = true,
            DailyRate = rate
        };
        carDetails.Add(license, rentalCar);
    }
    public bool RentCar(string license, string customer,DateTime start, int days)
    {
        if (!carDetails.ContainsKey(license))
        {
            Console.WriteLine("Car is not present");
            return false;
        }
        if (rentals.Any(r => r.LicensePlate == license))
        {
            Console.WriteLine("Car is Already Booked");
            return false;
        }
        RentalCar car = carDetails[license];
        Rental rental1 = new Rental()
        {
            RentalId = counter,
            LicensePlate = car.LicensePlate,
            CustomerName = customer,
            StartTime = start,
            EndTime = start.AddDays(days),
            TotalCost = car.DailyRate * days
        };
        rentals.Add(rental1);
        car.IsAvailable = false;
        Console.WriteLine("You Booked the Car");

        return true; 
    }
    public Dictionary<string, List<RentalCar>> GroupCarsByType()
    {
        Dictionary<string, List<RentalCar>> result = new Dictionary<string, List<RentalCar>>();
        foreach(var item in carDetails)
        {
            var car = item.Value;
            if (!result.ContainsKey(car.CarType))
            {
                result[car.CarType] = new List<RentalCar>();
            }
            result[car.CarType].Add(car);
        }
        return result;
    }

    public List<Rental> GetActiveRentals()
    {
        List<Rental> rent = new List<Rental>();
        foreach(var item in rentals)
        {
            var car = carDetails[item.LicensePlate];
            if (!car.IsAvailable)
            {
                rent.Add(item);
            }
        }
        return rent;
    }

    public double CalculateTotalRentalRevenue()
    {
        double TotalRevenue = 0;
        foreach(var item in rentals)
        {
             TotalRevenue += item.TotalCost;
        }
        return TotalRevenue;
    }
}

class Program
{
    static void Main(string[] args)
    {
    
    }
}
