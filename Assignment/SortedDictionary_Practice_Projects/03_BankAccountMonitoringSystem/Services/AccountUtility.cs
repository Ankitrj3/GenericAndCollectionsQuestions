using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class AccountUtility
    {
        private SortedDictionary<string, Account> _data
            = new SortedDictionary<string, Account>();

        public void AddBankAccount(Account account)
        {
            // TODO: Validate entity
            if(account.Balance < 0)
            {
                throw new CustomBaseException("NegativeBalanceException");
            }
            // TODO: Handle duplicate entries
            if (_data.ContainsKey(account.AccountNumber))
            {
                throw new CustomBaseException("Account is Already Present");
            }
            // TODO: Add entity to SortedDictionary
            _data.Add(account.AccountNumber,account);
        }

        public void Deposit(string accountNumber, double balance)
        {
            // TODO: Update entity logic
            if (!_data.ContainsKey(accountNumber))
            {
                throw new CustomBaseException("AccountNotFoundException");
            }
            Account account = _data[accountNumber];
            account.Balance += balance;
        }

        public void Withdraw(string accountNumber, double balance)
        {
            // TODO: Remove entity logic
            if (!_data.ContainsKey(accountNumber))
            {
                throw new CustomBaseException("AccountNotFoundException");
            }
            Account account = _data[accountNumber];
            if(account.Balance < balance)
            {
                throw new CustomBaseException("InsufficientFundsException");
            }
            account.Balance -= balance;
        }

        public SortedDictionary<double, List<Account>> GetAllAccount()
        {
            SortedDictionary<double, List<Account>> res = new SortedDictionary<double, List<Account>>();
            foreach(var i in _data)
            {
                var acc = i.Value;
                if (!res.ContainsKey(acc.Balance))
                {
                    res[acc.Balance] = new List<Account>();
                }
                res[acc.Balance].Add(acc);
            }
            return res;
        }
    }
}
