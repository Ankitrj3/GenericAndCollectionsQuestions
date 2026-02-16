namespace Domain
{
    public class Violation
    {
        public string VehicleNumber { get; set; }
        public string OwnerName { get; set; }
        public int FineAmount { get; set; }
        public Violation(){}
        public Violation(string VehicleNumber, string OwnerName, int FineAmount)
        {
            this.VehicleNumber = VehicleNumber;
            this.OwnerName = OwnerName;
            this.FineAmount = FineAmount;
        }
    }
}
