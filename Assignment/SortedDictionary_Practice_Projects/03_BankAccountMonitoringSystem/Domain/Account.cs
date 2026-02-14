namespace Domain
{
    public class Account
    {
        public string? AccountNumber { get; set; }
        public string? AccountHolder { get; set; }
        public double Balance { get; set; }
        public Account(){}
        public Account(string AccountNumber, string AccountHolder, double Balance)
        {
            this.AccountNumber = AccountNumber;
            this.AccountHolder = AccountHolder;
            this.Balance = Balance;
        }
    }
}
