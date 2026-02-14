using System.Collections.Generic;
using Domain;
using Exceptions;
using System.Linq;

namespace Services
{
    public class MedicalUtility
    {
        private Dictionary<string, Medicine> _data
            = new Dictionary<string, Medicine>();

        public void AddMedicine(Medicine medicine)
        {
            // TODO: Validate entity
            if(medicine.Price <= 0)
            {
                throw new CustomBaseException("Invalid Price Exception");
            }
            
            if(medicine.ExpiryYear < 1000 || medicine.ExpiryYear > 9999 )
            {
                throw new CustomBaseException("Invalid Expiry Year Exception");
            }
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            if (_data.ContainsKey(medicine.Id))
            {
                throw new CustomBaseException("Duplicate Medicine Exception");
            }
            _data.Add(medicine.Id,medicine);
        }

        public void UpdateMedicine(string id, double newPrice)
        {
            // TODO: Update entity logic
            if (!_data.ContainsKey(id))
            {
                throw new CustomBaseException("Medicine Not Found Exception");
            }
            Medicine medicine = _data[id];
            medicine.Price = newPrice;
        }
        public Dictionary<string,Medicine> GetAll()
        {
            // TODO: Return sorted entities
            return _data.OrderBy(s => s.Value.ExpiryYear).ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
