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
