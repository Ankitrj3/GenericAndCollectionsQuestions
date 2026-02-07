namespace OrderSystem
{
    public class Coupon
    {
        public string Code { get; set; }
        public double DiscountPercent { get; set; }
        public double MinOrderAmount { get; set; }
        public bool IsActive { get; set; }

        public Coupon(string code, double discountPercent, double minOrderAmount)
        {
            Code = code;
            DiscountPercent = discountPercent;
            MinOrderAmount = minOrderAmount;
            IsActive = true;
        }

        public bool CanApply(double orderAmount)
        {
            return IsActive && orderAmount >= MinOrderAmount;
        }

        public double CalculateDiscount(double orderAmount)
        {
            if(!CanApply(orderAmount))
                return 0;
            return orderAmount * (DiscountPercent / 100);
        }
    }
}
