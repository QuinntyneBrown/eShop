using System;

namespace eShop.Api.Models
{
    public class CatalogItemImage
    {
        public Guid CatalogItemImageId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid DigitalAssetId { get; private set; }

        public CatalogItemImage(string name, string description, Guid digitalAssetId)
        {
            Name = name;
            Description = description;
            DigitalAssetId = digitalAssetId;
        }
        private CatalogItemImage()
        {

        }
    }
}
