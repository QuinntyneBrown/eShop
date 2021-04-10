using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class CatalogItemImageExtensions
    {
        public static CatalogItemImageDto ToDto(this CatalogItemImage catalogItemImage)
        {
            return new()
            {
                CatalogItemImageId = catalogItemImage.CatalogItemImageId,                
                DigitalAssetId = catalogItemImage.DigitalAssetId,
                Name = catalogItemImage.Name,
                Description = catalogItemImage.Description
            };
        }
    }
}
