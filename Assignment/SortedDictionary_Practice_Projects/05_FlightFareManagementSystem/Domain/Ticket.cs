namespace Domain
{
    public class Ticket
    {
        public string? TicketId {get; set;}
        public string? PassengerName{get; set;}
        public int Fare{get; set;}

        public Ticket(){}
        public Ticket(string TicketId, string PassengerName, int Fare)
        {
            this.TicketId = TicketId;
            this.PassengerName = PassengerName;
            this.Fare = Fare;
        }
    }
}
