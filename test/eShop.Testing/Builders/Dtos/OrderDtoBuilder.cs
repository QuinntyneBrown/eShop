using eShop.Api.Features;
using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class OrderDtoBuilder
    {
        private OrderDto _orderDto;

        public static OrderDto WithDefaults()
        {
            return new OrderDto();
        }

        public OrderDtoBuilder()
        {
            _orderDto = WithDefaults();
        }

        public OrderDto Build()
        {
            return _orderDto;
        }
    }
}
