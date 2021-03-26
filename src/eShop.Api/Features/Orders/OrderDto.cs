using eShop.Api.Features.Orders;
using System;
using System.Collections.Generic;

namespace eShop.Api.Features
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public AddressDto BillingAddress { get; set; }
        public Guid CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
