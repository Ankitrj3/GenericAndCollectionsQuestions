namespace OrderSystem
{
    public class Payment
    {
        public string PaymentId { get; set; }
        public double Amount { get; set; }
        public string Method { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }

        public Payment(double amount, string method)
        {
            PaymentId = Guid.NewGuid().ToString().Substring(0, 8);
            Amount = amount;
            Method = method;
            PaymentDate = DateTime.Now;
            Status = "Completed";
        }
    }
}
