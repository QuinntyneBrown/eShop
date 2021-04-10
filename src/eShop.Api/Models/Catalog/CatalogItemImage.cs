using System;

namespace eShop.Api.Models
{
    public class CatalogItemImage
    {
        public Guid CatalogItemImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DigitalAssetId { get; set; }
    }
}
