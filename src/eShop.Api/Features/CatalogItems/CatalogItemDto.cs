using System;
using System.Collections.Generic;

namespace eShop.Api.Features
{
    public class CatalogItemDto
    {
        public System.Guid? CatalogItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
        public int QuantityInStock { get; set; } = 0;
        public bool OnReOrder { get; set; } = false;
        public List<CatalogItemImageDto> CatalogItemImages { get; set; } = new List<CatalogItemImageDto>();
        public int InventoryCount { get; set; } = 0;
    }
}
