using System;
using System.Linq;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class BasketExtensions
    {
        public static BasketDto ToDto(this Basket basket)
        {
            return new()
            {
                BasketId = basket.BasketId,
                CustomerId = basket.CustomerId,
                BasketItems = basket.BasketItems.Select(x => x.ToDto()).ToList()
            };
        }

        public static BasketItemDto ToDto(this BasketItem basketItem)
        {
            return new()
            {
                BasketId = basketItem.BasketId,
                CatalogItemId = basketItem.CatalogItemId,
                Quantity = basketItem.Quantity,
                Price = basketItem.Price
            };
        }
    }
}
