// Question 18: Event Management System
// Scenario: An event organizing company needs to manage events, tickets, and attendees.
// Requirements:
// csharp
// // In class Event:
// // - int EventId
// // - string EventName
// // - string EventType (Concert/Conference/Workshop)
// // - DateTime EventDate
// // - string Venue
// // - int TotalCapacity
// // - int TicketsSold
// // - double TicketPrice

// // In class Attendee:
// // - int AttendeeId
// // - string Name
// // - string Email
// // - string Phone
// // - List<int> RegisteredEvents

// // In class Ticket:
// // - string TicketNumber
// // - int EventId
// // - int AttendeeId
// // - DateTime PurchaseDate
// // - string SeatNumber

// // In class EventManager:
// public void CreateEvent(string name, string type, DateTime date,
//                        string venue, int capacity, double price)
// public bool BookTicket(int eventId, int attendeeId, string seatNumber)
// public Dictionary<string, List<Event>> GroupEventsByType()
// public List<Event> GetUpcomingEvents(int days)
// public double CalculateEventRevenue(int eventId)
// Use Cases:
// •	Create different types of events
// •	Book tickets for events
// •	Group events by type
// •	View upcoming events
// •	Calculate event revenue

public class Event
{
    public int EventId{get; set;}
    public string? EventName{get; set;}
    public string? EventType{get; set;}
    public DateTime EventDate{get; set;}
    public string Venue{get; set;}
    public int TotalCapacity{get; set;}
    public int TicketsSold{get; set;}
    public double TicketPrice{get; set;}
    public Event(){}
}
public class Attendee
{
    public int AttendeeId{get; set;}
    public string? Name{get; set;}
    public string? Email{get; set;}
    public string? Phone{get; set;}
    public List<int> RegisteredEvents{get; set;}
    public Attendee()
    {
        RegisteredEvents = new List<int>();
    }
}
public class Ticket
{
    public string? TicketNumber{get; set;}
    public int EventId{get; set;}
    public int AttendeeId{get; set;}
    public DateTime PurchaseDate{get; set;}
    public string? SeatNumber{get; set;}
    public Ticket(){}
}
public class EventManager
{
    public static int counter = 1;
    public static int attendeeCounter = 101;
    public static int TicketCounter = 201;

    public Dictionary<int, Event> eventDetails = new Dictionary<int, Event>();
    public Dictionary<string, Ticket> ticketDetails = new Dictionary<string, Ticket>();

    public void CreateEvent(string name, string type, DateTime date, string venue, int capacity, double price)
    {
        Event ev = new Event()
        {
            EventId = counter++,
            EventName = name,
            EventDate = date,
            EventType = type,
            Venue = venue,
            TotalCapacity = capacity,
            TicketsSold = 0,
            TicketPrice = price
        };
        eventDetails.Add(ev.EventId, ev);
    }

    public bool BookTicket(int eventId, int attendeeId, string seatNumber)
    {
        if (!eventDetails.ContainsKey(eventId))
        {
            Console.WriteLine("Invalid Event");
            return false;
        }
        Event ev = eventDetails[eventId];

        if (ev.TicketsSold >= ev.TotalCapacity)
        {
            Console.WriteLine("House Full");
            return false;
        }
        Ticket ticket = new Ticket()
        {
            TicketNumber = "TIC" + TicketCounter++.ToString("D3"),
            EventId = eventId,
            AttendeeId = attendeeId,
            PurchaseDate = DateTime.Now,
            SeatNumber = seatNumber
        };
        ticketDetails.Add(ticket.TicketNumber, ticket);
        ev.TicketsSold++;
        return true;
    }

    public Dictionary<string, List<Event>> GroupEventsByType()
    {
        Dictionary<string, List<Event>> result = new Dictionary<string, List<Event>>();

        foreach (var item in eventDetails)
        {
            Event ev = item.Value;

            if (!result.ContainsKey(ev.EventType))
            {
                result[ev.EventType] = new List<Event>();
            }

            result[ev.EventType].Add(ev);
        }

        return result;
    }

    public List<Event> GetUpcomingEvents(int days)
    {
        List<Event> result = new List<Event>();

        DateTime now = DateTime.Now;
        DateTime limit = now.AddDays(days);

        foreach (var item in eventDetails)
        {
            Event ev = item.Value;

            if (ev.EventDate >= now && ev.EventDate <= limit)
            {
                result.Add(ev);
            }
        }

        return result;
    }

    public double CalculateEventRevenue(int eventId)
    {
        if (!eventDetails.ContainsKey(eventId))
        {
            Console.WriteLine("Invalid Event");
            return 0;
        }

        Event ev = eventDetails[eventId];
        return ev.TicketsSold * ev.TicketPrice;
    }
}
