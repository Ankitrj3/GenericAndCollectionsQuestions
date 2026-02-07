namespace OrderSystem
{
    public class Order
    {
        public string InvoiceNumber { get; set; }
        public OrderCustomer Customer { get; set; }
        public List<OrderItem> Items { get; set; }
        public double Subtotal { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public Order(OrderCustomer customer)
        {
            Customer = customer;
            Items = new List<OrderItem>();
            OrderDate = DateTime.Now;
            Status = "Pending";
            InvoiceNumber = "";
        }

        public void CalculateTotals()
        {
            Subtotal = 0;
            foreach(var item in Items)
            {
                Subtotal += item.GetTotal();
            }
            Total = Subtotal - Discount;
        }
    }
}
