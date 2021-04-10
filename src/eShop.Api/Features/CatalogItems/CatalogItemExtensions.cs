using eShop.Api.Models;
using System.Linq;

namespace eShop.Api.Features
{
    public static class CatalogItemExtensions
    {
        public static CatalogItemDto ToDto(this CatalogItem catalogItem)
        {
            return new ()
            {
                CatalogItemId = catalogItem.CatalogItemId,
                Name = catalogItem.Name,
                Description = catalogItem.Description,
                Price = catalogItem.Price,
                QuantityInStock = catalogItem.QuantityInStock,
                OnReOrder = catalogItem.OnReOrder,
                InventoryCount = catalogItem.InventoryCount,
                CatalogItemImages = catalogItem.CatalogItemImages.Select(x => x.ToDto()).ToList()
            };
        }        
    }

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
