using System;
using System.Collections.Generic;

namespace eShop.Api.Features
{
    public class BasketDto
    {
        public System.Guid BasketId { get; set; }
        public System.Guid CustomerId { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
            = new List<BasketItemDto>();
    }

    public class BasketItemDto
    {
        public System.Guid BasketId { get; set; }
        public System.Guid CatalogItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; init; }
    }
}
