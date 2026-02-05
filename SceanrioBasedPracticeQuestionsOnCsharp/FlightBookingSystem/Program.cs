// Question 14: Flight Booking System
// Scenario: An airline needs to manage flights, bookings, and passenger information.
// Requirements:
// csharp
// // In class Flight:
// // - string FlightNumber
// // - string Origin
// // - string Destination
// // - DateTime DepartureTime
// // - DateTime ArrivalTime
// // - int TotalSeats
// // - int AvailableSeats
// // - double TicketPrice

// // In class Booking:
// // - string BookingId
// // - string FlightNumber
// // - string PassengerName
// // - int SeatsBooked
// // - double TotalFare
// // - string SeatClass (Economy/Business)

// // In class AirlineManager:
// public void AddFlight(string number, string origin, string destination,
//                      DateTime depart, DateTime arrive, int seats, double price)
// public bool BookFlight(string flightNumber, string passenger, 
//                       int seats, string seatClass)
// public Dictionary<string, List<Flight>> GroupFlightsByDestination()
// public List<Flight> SearchFlights(string origin, string destination, 
//                                  DateTime date)
// public double CalculateTotalRevenue(string flightNumber)
// Use Cases:
// •	Schedule flights
// •	Book tickets
// •	Search flights by route
// •	Group flights by destination
// •	Calculate flight revenue

using System.Net.NetworkInformation;

public class Flight
{
    public string? FlightNumber{get; set;}
    public string? Origin{get; set;}
    public string? Destination{get; set;}
    public DateTime DepartureTime{get; set;}
    public DateTime ArrivalTime{get; set;}
    public int TotalSeats{get; set;}
    public int AvailableSeats{get; set;}
    public double TicketPrice{get; set;}
    public Flight(){}
}
public class Booking
{
    public string? BookingId{get; set;}
    public string? FlightNumber{get; set;}
    public string? PassengerName{get; set;}
    public int SeatsBooked{get; set;}
    public double TotalFare{get; set;}
    public string SeatClass{get; set;}
    public Booking(){}
}
public class AirlineManager
{
    public static Dictionary<string, Flight> flightDetails = new Dictionary<string, Flight>();
    public static int BookingCounter = 101;
    public static List<Booking> bookingDetails = new List<Booking>();
    public void AddFlight(string number, string origin, string destination, DateTime depart, DateTime arrive, int seats, double price)
    {
        Flight flight = new Flight()
        {
            FlightNumber = number,
            Origin = origin,
            Destination = destination,
            DepartureTime = depart,
            ArrivalTime = arrive,
            TotalSeats = seats,
            AvailableSeats = seats,
            TicketPrice = price
        };
        flightDetails.Add(number, flight);
    }
    public bool BookFlight(string flightNumber, string passenger, int seats, string seatClass)
    {
        if (!flightDetails.ContainsKey(flightNumber))
        {
            Console.WriteLine("Wrong Flight Number");
            return false;
        }
        Flight fli = flightDetails[flightNumber];
        if(fli.AvailableSeats < seats)
        {
            Console.WriteLine("Seats is Not Avilable");
            return false;
        }
        Booking booking = new Booking()
        {
            BookingId = BookingCounter.ToString("D3"),
            FlightNumber = flightNumber,
            PassengerName = passenger,
            SeatsBooked = seats,
            TotalFare = fli.TicketPrice * seats,
            SeatClass = seatClass  
        };
        bookingDetails.Add(booking);
        fli.AvailableSeats -= seats;
        BookingCounter++;
        return true;
    }
    public Dictionary<string, List<Flight>> GroupFlightsByDestination()
    {
        Dictionary<string, List<Flight>> result = new Dictionary<string, List<Flight>>();
        foreach(var item in flightDetails)
        {
            var fli = item.Value;
            if (!result.ContainsKey(fli.Destination))
            {
                result[fli.Destination] = new List<Flight>();
            }
            result[fli.Destination].Add(fli);
        }
        return result;
    }
    public List<Flight> SearchFlights(string origin, string destination, DateTime date)
    {
        List<Flight> flights = new List<Flight>();
        foreach(var item in flightDetails)
        {
            var fli = item.Value;
            if(fli.Destination == destination && fli.Origin == origin && fli.DepartureTime == date)
            {
                flights.Add(fli);
            }
        }
        return flights;
    }
    public double CalculateTotalRevenue(string flightNumber)
    {
        double TotalRevenue = 0;
        foreach(var item in bookingDetails)
        {
            if(item.FlightNumber == flightNumber)
            {
                TotalRevenue += item.TotalFare;
            }
        }
        return TotalRevenue;
    }
}
public class Program
{
    public static void Main()
    {
        
    }
}

