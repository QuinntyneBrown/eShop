namespace eShop.Api.Exceptions
{
    public class PaymentFailedException : DomainException
    {
        public PaymentFailedException()
            : base("Payment Failed")
        {

        }
    }
}
