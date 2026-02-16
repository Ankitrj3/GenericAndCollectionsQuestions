namespace Domain
{
    public class Investment
    {
        public string? InvestmentId { get; set; }
        public string? AssetName { get; set; }
        public int RiskRating { get; set; }
        public Investment(){}
        public Investment(string InvestmentId, string AssetName, int RiskRating)
        {
            this.InvestmentId = InvestmentId;
            this.AssetName = AssetName;
            this.RiskRating = RiskRating;
        }
    }
}
