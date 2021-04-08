using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class BasketExtensions
    {
        public static BasketDto ToDto(this Basket basket)
        {
            return new()
            {
                BasketId = basket.BasketId
            };
        }

    }
}
