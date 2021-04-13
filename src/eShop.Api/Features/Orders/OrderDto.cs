using eShop.Api.Models;
using System;
using System.Collections.Generic;

namespace eShop.Api.Features
{
    public class OrderDto
    {
        public System.Guid OrderId { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public AddressDto BillingAddress { get; set; }
        public System.Guid CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal Cost { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
