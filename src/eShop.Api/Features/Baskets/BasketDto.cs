using System;
using System.Collections.Generic;

namespace eShop.Api.Features
{
    public class BasketDto
    {
        public Guid BasketId { get; set; }
        public Guid CustomerId { get; set; }
        public List<BasketItemDto> BasketItems { get; set; } 
            = new List<BasketItemDto>();
    }

    public class BasketItemDto
    {
        public Guid BasketId { get; set; }
        public Guid CatalogItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; init; }
    }
}
