using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class CatalogItemExtensions
    {
        public static CatalogItemDto ToDto(this CatalogItem catalogItem)
        {
            return new()
            {
                CatalogItemId = catalogItem.CatalogItemId
            };
        }

    }
}
