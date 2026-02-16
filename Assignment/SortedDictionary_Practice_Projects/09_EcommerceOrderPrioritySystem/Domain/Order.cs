namespace Domain
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public int OrderAmount { get; set; }
        public Order(){}
        public Order(string OrderId, string CustomerName, int OrderAmount)
        {
            this.OrderId = OrderId;
            this.CustomerName = CustomerName;
            this.OrderAmount = OrderAmount;
        }
    }
}
