using System;

namespace eShop.Api.Features
{
    public class CatalogItemImageDto
    {
        public System.Guid? CatalogItemImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.Guid DigitalAssetId { get; set; }
    }
}
