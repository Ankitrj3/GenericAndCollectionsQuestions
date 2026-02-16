using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class MemberUtility
    {
        private SortedDictionary<int, List<Member>> _data
            = new SortedDictionary<int, List<Member>>();

        public void AddMember(Member member)
        {
            // TODO: Validate entity
            if(member.Fine < 0)
            {
                throw new CustomBaseException("Invalid Fine Exception");
            }
            // TODO: Handle duplicate entries
            foreach(var i in _data)
            {
                foreach(var j in i.Value)
                {
                    if(j.Id == member.Id)
                    {
                        throw new CustomBaseException("Duplicated Exception");
                    }
                }
            }
            if (!_data.ContainsKey(member.Fine))
            {
                _data[member.Fine] = new List<Member>();
            }
                _data[member.Fine].Add(member);
        
            // TODO: Add entity to SortedDictionary
        }

        public void PayFine(string id, int PayFine)
        {
            Member found = null;
            int oldFine = 0;
            // TODO: Update entity logic
            foreach(var i in _data)
            {
                foreach(var list in i.Value)
                {
                    if(list.Id == id)
                    {
                        found = list;
                        oldFine = list.Fine;
                    }
                    if(found != null)
                    {
                        break;
                    }
                }
            }
            if(found == null) throw new CustomBaseException("User Not Found");
            _data[oldFine].Remove(found);
            if (_data[oldFine].Count == 0)
                _data.Remove(oldFine);

            found.Fine -= PayFine;
            if (found.Fine < 0)
                found.Fine = 0;

            if (!_data.ContainsKey(found.Fine))
                _data[found.Fine] = new List<Member>();

            _data[found.Fine].Add(found);
        }

        public SortedDictionary<int, List<Member>> DisplayMemberByFine()
        {
            // TODO: Return sorted entities
            var dict = _data.OrderByDescending(s => s.Key)
                        .ToDictionary(s => s.Key , s => s.Value);
            SortedDictionary<int, List<Member>> res = new SortedDictionary<int, List<Member>>();
            foreach(var i in dict)
            {
                foreach(var item in i.Value)
                {
                    if (!res.ContainsKey(item.Fine))
                    {
                        res[item.Fine] = new List<Member>();
                    }
                    res[item.Fine].Add(item);
                }
            }
            return res;
        }
    }
}
