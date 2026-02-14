namespace Domain
{
    public class Medicine
    {
        public string? Id{get; set;}
        public string? Name{get; set;}
        public double Price{get; set;}
        public int ExpiryYear{get; set;}
        public Medicine()
        {
            
        }
        public Medicine(string id, string name, double price, int expiryYear)
        {
            Id = id;
            Name = name;
            Price = price;
            ExpiryYear = expiryYear;
        }
    }
}
