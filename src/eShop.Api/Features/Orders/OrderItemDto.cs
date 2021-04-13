using System;

namespace eShop.Api.Features
{
    public class OrderItemDto
    {
        public Guid? OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid CatalogItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
