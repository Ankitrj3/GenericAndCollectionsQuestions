namespace OrderSystem
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException(string message) : base(message) { }
    }

    public class InvalidCouponException : Exception
    {
        public InvalidCouponException(string message) : base(message) { }
    }

    public class EmptyCartException : Exception
    {
        public EmptyCartException(string message) : base(message) { }
    }

    public class PaymentFailedException : Exception
    {
        public PaymentFailedException(string message) : base(message) { }
    }
}
