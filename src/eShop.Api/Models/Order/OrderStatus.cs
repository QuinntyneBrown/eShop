namespace eShop.Api.Models
{
    public enum OrderStatus
    {
        Draft,
        ProcessingPayment,
        Paid,
        Shipped,
        Cancelled,
        Rejected
    }
}
