using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class TicketUtility
    {
        private SortedDictionary<int, List<Ticket>> _data
            = new SortedDictionary<int, List<Ticket>>();

        public void AddTicket(Ticket ticket)
        {
            // TODO: Validate entity
            if(ticket.Fare < 0)
            {
                throw new CustomBaseException("InvalidFareException");
            }
            // TODO: Handle duplicate entries
            foreach(var i in _data)
            {
                foreach(var item in i.Value)
                {
                    if(ticket.TicketId == item.TicketId)
                    {
                        throw new CustomBaseException("DuplicateTicketException");
                    }
                }
            }
            // TODO: Add entity to SortedDictionary
            if (!_data.ContainsKey(ticket.Fare))
            {
                _data[ticket.Fare] = new List<Ticket>();
            }
            _data[ticket.Fare].Add(ticket);
        }

        public void UpdateTicket(string id, int Fare)
        {
            // TODO: Update entity logic
            if(Fare < 0)
            {
                throw new CustomBaseException("InvalidFareException");
            }
            Ticket found = null;
            int oldFare = 0;

            foreach(var i in _data)
            {
                foreach(var item in i.Value)
                {
                    if(item.TicketId == id)
                    {
                        found = item;
                        oldFare = item.Fare;
                        break;
                    }
                }
                if(found != null)
                {
                    break;
                }
            }
            if(found == null)
            {
                throw new CustomBaseException("TicketNotFoundException");
            }
            _data[oldFare].Remove(found);
            if(_data[oldFare].Count() == 0)
            {
                _data.Remove(oldFare);
            }
            found.Fare = Fare;
            if (!_data.ContainsKey(found.Fare))
            {
                _data[found.Fare] = new List<Ticket>();
            }
            _data[found.Fare].Add(found);
        }
        public SortedDictionary<int, List<Ticket>> GetTicketByFare()
        {
            // TODO: Return sorted entities
            return _data;
        }
    }
}
