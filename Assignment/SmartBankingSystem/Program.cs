public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message){}
}
public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message){}
}
public class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base(message){}
}
public abstract class BankAccount
{
    public string? AccountNumber{get; set;}
    public string? CustomerName{get; set;}
    public double Balance{get; set;}
    public BankAccount(){}
    public BankAccount(string accountNumber, string customerName, double balance)
    {
        AccountNumber = accountNumber;
        CustomerName = customerName;
        Balance = balance;
    }
    public virtual void Deposit(int amount)
    {
        if(amount < 0)
        {
            throw new InvalidTransactionException("Deposit Amount Can't be negative");
        }
        Balance += amount;
    }
    public virtual void Withdraw(int amount)
    {
        if(Balance < amount)
        {
            throw new InsufficientBalanceException("Insufficient Balance");
        }
        Balance -= amount;
    }
    public abstract double CalculateInterest();

}
public class SavingsAccount : BankAccount
{
    public SavingsAccount(string accountNumber, string customerName, double balance) : base(accountNumber,customerName,balance){}
    public readonly double MinimumBalance = 10000;
    public override void Deposit(int amount)
    {
        if(Balance < MinimumBalance)
        {
            throw new MinimumBalanceException("Minimum Balance is not present");
        }
        base.Deposit(amount);
    }
    public override double CalculateInterest()
    {
        return Balance * 0.4;
    }
}
public class CurrentAccount : BankAccount
{
    public CurrentAccount(string accountNumber, string customerName, double balance) : base(accountNumber,customerName,balance){}
    public readonly double OverDriftLimit = 11000;
    public override void Withdraw(int amount)
    {
        if(Balance + OverDriftLimit < amount)
        {
            throw new InsufficientBalanceException("Withdrawal cannot exceed balance");
        }
        base.Withdraw(amount);
    }
    public override double CalculateInterest()
    {
        return 0;
    }
}
public class LoanAccount : BankAccount
{
    public LoanAccount(string accountNumber, string customerName, double balance) : base(accountNumber,customerName,balance){}
    public override void Deposit(int amount)
    {
        throw new InvalidTransactionException("Loan Account can not deposit");
    }
    public override double CalculateInterest()
    {
        return Balance * 0.8;
    }
}
public class Program
{
    public static void Main()
    {
        List<BankAccount> bankAccounts = new List<BankAccount>()
        {
            new LoanAccount("1234","Ankit Ranjan",60000),
            new CurrentAccount("6785","KamalJeet",50000),
            new SavingsAccount("3493","Harsh",100000),
            new LoanAccount("123423","Likhitha",60000),
            new CurrentAccount("678532","Shashi",50000),
            new SavingsAccount("343493","Sumit",10000),
            new LoanAccount("124334","Aman",40000),
            new CurrentAccount("67835","Sonu",50000),
            new SavingsAccount("3492243","Shub",10000),
            new SavingsAccount("341143","Ram",10000),
            new SavingsAccount("349224was3","Rockey",10000)
        };
        try
        {
            bankAccounts[0].Deposit(9000);
        }catch(InvalidTransactionException e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            bankAccounts[1].Withdraw(62000);
        }catch(InsufficientBalanceException e)
        {
            Console.WriteLine(e.Message);
        }
        // o	Get accounts with balance > 50,000
        var AccoutMoreThenBalance = bankAccounts.Where(s => s.Balance > 50000);
        foreach(var i in AccoutMoreThenBalance)
        {
            Console.WriteLine(i.CustomerName);
        }
        // o	Get total bank balance
        var TotalBalance = bankAccounts.Sum(s => s.Balance);
        Console.WriteLine(TotalBalance);

        // o	Get top 3 highest balance accounts
        var Top3 = bankAccounts.OrderByDescending(s => s.Balance).Take(3).ToList();
        foreach(var i in Top3)
        {
            Console.WriteLine($"{i.AccountNumber} {i.Balance} {i.CustomerName}");
        }
        // o	Group accounts by account type
        var GroupByAccount = bankAccounts.GroupBy(s => s.GetType())
                                         .ToDictionary(s => s.Key, s => s.Count());
        foreach(var i in GroupByAccount)
        {
            Console.WriteLine($"{i.Key} {i.Value}");
        }
        // o	Find customers whose name starts with "R"
        var StartWithR = bankAccounts.Where(s => s.CustomerName.StartsWith('R'));
        foreach(var i in StartWithR)
        {
            Console.WriteLine($"{i.AccountNumber} {i.CustomerName} {i.Balance}");
        }
    }
}