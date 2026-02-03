// Question 7: Movie Theater Booking System
// Scenario: A cinema needs to manage movie screenings and seat bookings.
// Requirements:
// csharp
// // In class MovieScreening:
// // - string MovieTitle
// // - DateTime ShowTime
// // - string ScreenNumber
// // - int TotalSeats
// // - int BookedSeats
// // - double TicketPrice

// // In class TheaterManager:
// public void AddScreening(string title, DateTime time, string screen, 
//                          int seats, double price)
// // Adds new screening

// public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
// // Books tickets if available seats

// public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
// // Groups screenings by movie title

// public double CalculateTotalRevenue()
// // Calculates total revenue from all bookings

// public List<MovieScreening> GetAvailableScreenings(int minSeats)
// // Returns screenings with at least minSeats available
// Use Cases:
// •	Add multiple screenings for different movies
// •	Book tickets for specific show
// •	View all screenings of a particular movie
// •	Check available screenings for group booking
// •	Track revenue

using System.Diagnostics.Metrics;

public class MovieScreening
{
    public string? MovieTitle{get; set;}
    public DateTime ShowTime{get; set;}
    public string? ScreenNumber{get; set;}
    public int TotalSeats{get; set;}
    public int BookedSeats{get; set;}
    public double TicketPrice{get; set;}

    public MovieScreening(){}
}

public class TheaterManager
{
    public static List<MovieScreening> screenings = new List<MovieScreening>();
    public void AddScreening(string title, DateTime time, string screen, int seats, double price)
    {
        MovieScreening movie = new MovieScreening()
        {
            MovieTitle = title,
            ShowTime = time,
            ScreenNumber = screen,
            TotalSeats = seats,
            BookedSeats = 0,
            TicketPrice = price  
        };
        screenings.Add(movie);
    }
    public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
    {
        MovieScreening? movie = screenings.Find(m => m.MovieTitle == movieTitle && m.ShowTime == showTime);

        if (movie == null)
        {
            Console.WriteLine("Movie Screening is Not Present");
            return false;
        }
        int available = movie.TotalSeats - movie.BookedSeats;

        if(available < tickets)
        {
            Console.WriteLine("Ticket is Not present");
            return false;
        }
        movie.BookedSeats += tickets;
        return true;
    }
    public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
    {
        Dictionary<string, List<MovieScreening>> result = new Dictionary<string, List<MovieScreening>>();
        foreach(var item in screenings)
        {
            if (!result.ContainsKey(item.MovieTitle))
            {
                result[item.MovieTitle] = new List<MovieScreening>();
            }
            result[item.MovieTitle].Add(item);
        }
        return result;
    }
    public double CalculateTotalRevenue()
    {
        double Revenue = 0;
        foreach(var item in screenings)
        {
            Revenue += item.BookedSeats * item.TicketPrice;
        }
        return Revenue;
    }
    public List<MovieScreening> GetAvailableScreenings(int minSeats)
    {
        List<MovieScreening> result = new List<MovieScreening>();
        foreach(var item in screenings)
        {
            int available = item.TotalSeats - item.BookedSeats;
            if(available >= minSeats)
            {
                result.Add(item);
            }
        }
        return result;
    }
}
public class Program
{
    public static void Main()
    {
        
    }
}