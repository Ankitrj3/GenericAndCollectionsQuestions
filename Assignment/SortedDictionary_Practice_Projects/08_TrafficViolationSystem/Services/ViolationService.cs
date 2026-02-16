using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private static SortedDictionary<int, List<Violation>> _data = new SortedDictionary<int, List<Violation>>(
            Comparer<int>.Create((a,b) => b.CompareTo(a))
        );

        public void AddViolation(Violation violation)
        {
            // TODO: Validate entity
            if(violation.FineAmount < 0)
            {
                throw new CustomBaseException("InvalidFineAmountException");
            }
            foreach(var i in _data)
            {
                foreach(var item in i.Value)
                {
                    if(violation.VehicleNumber == item.VehicleNumber)
                    {
                        throw new CustomBaseException("DuplicateViolationException");
                    }
                }
            }
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            if (!_data.ContainsKey(violation.FineAmount))
            {
                _data[violation.FineAmount] = new List<Violation>();
            }
            _data[violation.FineAmount].Add(violation);
        }

        public void PayFine(string VehicleNumber, int NewFine)
        {
            // TODO: Update entity logic
            Violation found = null;
            int oldFine = 0;

            foreach(var i in _data)
            {
                foreach(var item in i.Value)
                {
                    if(item.VehicleNumber == VehicleNumber)
                    {
                        found = item;
                        oldFine = item.FineAmount;
                        break;
                    }
                }
                if(found != null) break;
            }
            if(found == null) throw new CustomBaseException("Not Found Car Number");
            _data[oldFine].Remove(found);
            if(_data[oldFine].Count() == 0)
            {
                _data.Remove(oldFine);
            }
            found.FineAmount -= NewFine;
            if(found.FineAmount < 0)
            {
                found.FineAmount = 0;
            }
            if (!_data.ContainsKey(found.FineAmount))
            {
                _data[found.FineAmount] = new List<Violation>();
            }
            _data[found.FineAmount].Add(found);
        }

        public SortedDictionary<int, List<Violation>> GetAll()
        {
            // TODO: Return sorted entities
            return _data;
        }
    }
}
