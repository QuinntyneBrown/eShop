using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class OrderExtensions
    {
        public static OrderDto ToDto(this Order order)
        {
            return new()
            {
                OrderId = order.OrderId
            };
        }

    }
}
