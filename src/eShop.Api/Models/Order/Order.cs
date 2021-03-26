using System;
using System.Collections.Generic;

namespace eShop.Api.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Cost { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Draft;
        public List<OrderItem> OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }

        public Order()
        {

        }

        public Order SetProcessingPaymentStatus()
        {
            if(Status == OrderStatus.ProcessingPayment || Status == OrderStatus.Paid)
            {
                throw new Exception();
            }

            Status = OrderStatus.ProcessingPayment;
            return this;
        }

        public Order SetPaidStatus()
        {
            Status = OrderStatus.Paid;
            return this;
        }

        public Order SetShippedStatus()
        {
            Status = OrderStatus.Shipped;
            return this;
        }

        public Order SetRejectedStatus()
        {
            Status = OrderStatus.Rejected;
            return this;
        }

        public Order SetCancelledStatus()
        {
            if(Status == OrderStatus.Paid || Status == OrderStatus.Shipped)
            {
                throw new Exception();
            }

            Status = OrderStatus.Cancelled;
            return this;
        }
    }
}
