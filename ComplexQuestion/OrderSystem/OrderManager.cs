namespace OrderSystem
{
    public class OrderManager
    {
        private static int invoiceCounter = 1000;
        private Dictionary<int, Product> products;
        private Dictionary<string, Coupon> coupons;
        private List<Order> orders;

        public OrderManager()
        {
            products = new Dictionary<int, Product>();
            coupons = new Dictionary<string, Coupon>();
            orders = new List<Order>();
        }

        public void AddProduct(Product product)
        {
            products[product.Id] = product;
        }

        public void AddCoupon(Coupon coupon)
        {
            coupons[coupon.Code] = coupon;
        }

        public Order CreateCart(OrderCustomer customer)
        {
            return new Order(customer);
        }

        public void AddToCart(Order cart, int productId, int quantity)
        {
            if(!products.ContainsKey(productId))
            {
                throw new Exception("Product not found");
            }

            Product product = products[productId];
            
            if(product.Stock < quantity)
            {
                throw new InsufficientStockException($"Not enough stock for {product.Name}. Available: {product.Stock}");
            }

            OrderItem item = new OrderItem(product, quantity);
            cart.Items.Add(item);
        }

        public void ApplyCoupon(Order cart, string couponCode)
        {
            if(!coupons.ContainsKey(couponCode))
            {
                throw new InvalidCouponException("Coupon code not found");
            }

            Coupon coupon = coupons[couponCode];
            cart.CalculateTotals();

            if(!coupon.CanApply(cart.Subtotal))
            {
                throw new InvalidCouponException($"Minimum order amount is {coupon.MinOrderAmount}");
            }

            cart.Discount = coupon.CalculateDiscount(cart.Subtotal);
            cart.CalculateTotals();
        }

        public Payment PlaceOrder(Order cart, string paymentMethod)
        {
            if(cart.Items.Count == 0)
            {
                throw new EmptyCartException("Cannot place order with empty cart");
            }

            foreach(var item in cart.Items)
            {
                if(item.Product.Stock < item.Quantity)
                {
                    throw new InsufficientStockException($"Stock changed for {item.Product.Name}. Available: {item.Product.Stock}");
                }
            }

            foreach(var item in cart.Items)
            {
                item.Product.Stock -= item.Quantity;
            }

            cart.CalculateTotals();
            cart.InvoiceNumber = GenerateInvoiceNumber();
            cart.Status = "Confirmed";

            Payment payment = new Payment(cart.Total, paymentMethod);
            orders.Add(cart);

            return payment;
        }

        private string GenerateInvoiceNumber()
        {
            invoiceCounter++;
            return $"INV-{DateTime.Now.Year}-{invoiceCounter}";
        }

        public Product GetProduct(int id)
        {
            return products.ContainsKey(id) ? products[id] : null;
        }

        public List<Order> GetOrders()
        {
            return orders;
        }
    }
}
