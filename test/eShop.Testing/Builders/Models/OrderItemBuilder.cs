using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class OrderItemBuilder
    {
        private OrderItem _orderItem;

        public static OrderItem WithDefaults()
        {
            return new OrderItem();
        }

        public OrderItemBuilder()
        {
            _orderItem = WithDefaults();
        }

        public OrderItem Build()
        {
            return _orderItem;
        }
    }
}
