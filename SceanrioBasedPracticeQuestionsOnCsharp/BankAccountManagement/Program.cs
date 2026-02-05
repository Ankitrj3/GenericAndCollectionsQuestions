// Question 13: Bank Account Management
// Scenario: A banking system needs to manage accounts, transactions, and customer data.
// Requirements:
// csharp
// // In class Account:
// // - string AccountNumber
// // - string AccountHolder
// // - string AccountType (Savings/Current/Fixed)
// // - double Balance
// // - List<Transaction> TransactionHistory

// // In class Transaction:
// // - string TransactionId
// // - DateTime TransactionDate
// // - string Type (Deposit/Withdrawal/Transfer)
// // - double Amount
// // - string Description

// // In class BankManager:
// public void CreateAccount(string holder, string type, double initialDeposit)
// public bool Deposit(string accountNumber, double amount)
// public bool Withdraw(string accountNumber, double amount)
// public Dictionary<string, List<Account>> GroupAccountsByType()
// public List<Transaction> GetAccountStatement(string accountNumber, 
//                                             DateTime from, DateTime to)
// Use Cases:
// •	Open different types of accounts
// •	Process deposits and withdrawals
// •	Group accounts by type
// •	Generate account statements
// •	Check account balances

public class Account
{
    public string? AccountNumber{get; set;}
    public string? AccountHolder{get; set;}
    public string? AccountType{get; set;}
    public double Balance{get; set;}
    public List<Transaction> TransactionHistory{get; set;}
    public Account()
    {
        TransactionHistory = new List<Transaction>();
    }
}
public class Transaction
{
    public string? TransactionId{get; set;}
    public DateTime TransactionDate{get; set;}
    public string? Type{get; set;}
    public double Amount{get; set;}
    public string? Description{get; set;}
    public Transaction(){}
}

public class BankManager
{
    public static Dictionary<string, Account> accountDetails = new Dictionary<string, Account>();
    public static int AccountCounter = 1;
    public static int TransactionCounter = 101;
    public void CreateAccount(string holder, string type, double initialDeposit)
    {
        Account account = new Account()
        {
            AccountHolder = holder,
            AccountNumber = AccountCounter.ToString("D3"),
            AccountType = type,
            Balance = initialDeposit
        };
        accountDetails.Add(account.AccountNumber, account);
        AccountCounter++;
    }
    public bool Deposit(string accountNumber, double amount)
    {
        if (!accountDetails.ContainsKey(accountNumber))
        {
            Console.WriteLine("Invalid Account Number");
            return false;
        }
        if(amount <= 0)
        {
            Console.WriteLine("Amount must be more then Zero");
            return false;
        }
        Transaction transaction = new Transaction()
        {
            TransactionId = TransactionCounter.ToString("D3"),
            TransactionDate = DateTime.Now,
            Type = "Deposit",
            Amount = amount,
            Description = "Amount is Deposited in your Bank Account"
        };
        Account account = accountDetails[accountNumber];
        account.TransactionHistory.Add(transaction);
        account.Balance+=amount;
        TransactionCounter++;
        return true;
    }
    public bool Withdraw(string accountNumber, double amount)
    {
        if (!accountDetails.ContainsKey(accountNumber))
        {
            Console.WriteLine("Invalid Account Number");
            return false;
        }
        if(amount <= 0)
        {
            Console.WriteLine("Amount must be more then Zero");
            return false;
        }
        Transaction transaction = new Transaction()
        {
            TransactionId = TransactionCounter.ToString("D3"),
            TransactionDate = DateTime.Now,
            Type = "Withdraw",
            Amount = amount,
            Description = "Amount is Withdraw in your Bank Account"
        };
        Account account = accountDetails[accountNumber];
        account.Balance -= amount;
        account.TransactionHistory.Add(transaction);
        TransactionCounter++;
        return true;
    }
    public Dictionary<string, List<Account>> GroupAccountsByType()
    {
        Dictionary<string, List<Account>> result = new Dictionary<string, List<Account>>();
        foreach(var item in accountDetails)
        {
            Account account = item.Value;
            if (!result.ContainsKey(account.AccountType))
            {
                result[account.AccountType] = new List<Account>();
            }
            result[account.AccountType].Add(account);
        }
        return result;
    }
    public List<Transaction> GetAccountStatement(string accountNumber, DateTime from, DateTime to)
    {
        List<Transaction> result = new List<Transaction>();
        if (!accountDetails.ContainsKey(accountNumber))
        {
            Console.WriteLine("Invalid Account Number");
            return result;
        }
        Account account = accountDetails[accountNumber];
        foreach(var item in account.TransactionHistory)
        {
            if(item.TransactionDate >= from && item.TransactionDate <= to)
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