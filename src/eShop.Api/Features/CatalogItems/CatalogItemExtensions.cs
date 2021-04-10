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
}
