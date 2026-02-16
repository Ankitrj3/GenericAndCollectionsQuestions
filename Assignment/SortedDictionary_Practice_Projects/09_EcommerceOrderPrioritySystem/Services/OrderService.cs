using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class OrderService
    {
        private SortedDictionary<int, List<Order>> _data
            = new SortedDictionary<int, List<Order>>(
                Comparer<int>.Create((a,b) => b.CompareTo(a))
            );

        public void AddOrder(Order order)
        {
            // TODO: Validate entity
            if(order.OrderAmount < 0)
            {
                throw new CustomBaseException("Invalid Order Amount");
            }
            // TODO: Handle duplicate entries
            foreach(var i in _data)
            {
                foreach(var item in i.Value)
                {
                    if(order.OrderId == item.OrderId)
                    {
                        throw new CustomBaseException("OrderId Duplicated Exception");
                    }
                }
            }
            // TODO: Add entity to SortedDictionary
            if (!_data.ContainsKey(order.OrderAmount))
            {
                _data[order.OrderAmount] = new List<Order>();
            }
            _data[order.OrderAmount].Add(order);
        }

        public void UpdateOrder(string orderid, int price)
        {
            // TODO: Update entity logic
            Order found = null;
            int oldPrice = 0;

            foreach(var i in _data)
            {
                foreach(var j in i.Value)
                {
                    if(j.OrderId == orderid)
                    {
                        found = j;
                        oldPrice = j.OrderAmount;
                        break;
                    }
                }
                if(found != null)
                {
                    break;
                }
            }
            if(found == null) throw new CustomBaseException("Order Id not found");
            _data[oldPrice].Remove(found);
            if(_data.Count() == 0)
            {
                _data.Remove(oldPrice);
            }
            found.OrderAmount = price;
            if (!_data.ContainsKey(found.OrderAmount))
            {
                _data[found.OrderAmount] = new List<Order>();
            }
            _data[found.OrderAmount].Add(found);
        }

        public SortedDictionary<int, List<Order>> DisplayOrder()
        {
            // TODO: Return sorted entities
            return _data;
        }
    }
}
