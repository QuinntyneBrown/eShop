using eShop.Api.Models;
using System.Linq;

namespace eShop.Api.Features
{
    public static class OrderExtensions
    {
        public static OrderDto ToDto(this Order order)
        {
            return new()
            {
                OrderId = order.OrderId,
                ShippingAddress = order.ShippingAddress.ToDto(),
                BillingAddress = order.BillingAddress.ToDto(),
                CustomerId = order.CustomerId,
                Status = order.Status,
                OrderDate = order.OrderDate,
                Cost = order.Cost,
                OrderItems = order.OrderItems.Select(x => x.ToDto()).ToList()
            };
        }

        public static OrderItemDto ToDto(this OrderItem orderItem)
        {
            return new()
            {
                OrderItemId = orderItem.OrderItemId,
                CatalogItemId = orderItem.CatalogItemId,
                Price = orderItem.Price,
                Quantity = orderItem.Quantity,
                OrderId = orderItem.OrderId
            };
        }

        public static AddressDto ToDto(this Address address)
        {
            return new()
            {
                Street = address.Street,
                Province = address.Province,
                PostalCode = address.PostalCode,
                City = address.City
            };
        }

    }
}
