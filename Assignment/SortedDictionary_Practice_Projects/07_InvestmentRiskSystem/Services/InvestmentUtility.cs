using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class InvestmentUtility
    {
        private SortedDictionary<int, List<Investment>> _data
            = new SortedDictionary<int, List<Investment>>();

        public void AddInvestment(Investment investment)
        {
            // TODO: Validate entity
            if(investment.RiskRating < 1 || investment.RiskRating > 5)
            {
                throw new CustomBaseException("InvalidRiskRatingException");
            }
            // TODO: Handle duplicate entries
            foreach(var i in _data)
            {
                foreach(var item in i.Value)
                {
                    if(investment.InvestmentId == item.InvestmentId)
                    {
                        throw new CustomBaseException("DuplicateInvestmentException");
                    }
                }
            }
            // TODO: Add entity to SortedDictionary
            if (!_data.ContainsKey(investment.RiskRating))
            {
                _data[investment.RiskRating] = new List<Investment>();
            }
            _data[investment.RiskRating].Add(investment);
        }

        public void UpdateRisk(string investmentId, int riskRating)
        {
            // TODO: Update entity logic
            Investment investment = null;
            int oldRiskRating = 0;

            foreach(var i in _data)
            {
                foreach(var item in i.Value)
                {
                    if(investmentId == item.InvestmentId)
                    {
                        investment = item;
                        oldRiskRating = item.RiskRating;
                        break;
                    }
                }
                if(investment != null)
                {
                    break;
                }
            }
            if(investment == null)
            {
                throw new CustomBaseException("Investment ID not found");
            }
            _data[oldRiskRating].Remove(investment);
            if(_data[oldRiskRating].Count() == 0)
            {
                _data.Remove(oldRiskRating);
            }
            investment.RiskRating = riskRating;
            if (!_data.ContainsKey(investment.RiskRating))
            {
                _data[investment.RiskRating] = new List<Investment>();
            }
            _data[investment.RiskRating].Add(investment);
        }
        public SortedDictionary<int, List<Investment>> GetAll()
        {
            // TODO: Return sorted entities
            return _data;
        }
    }
}
