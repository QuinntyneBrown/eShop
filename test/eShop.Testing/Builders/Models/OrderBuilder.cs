using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class OrderBuilder
    {
        private Order _order;

        public static Order WithDefaults()
        {
            return new Order();
        }

        public OrderBuilder()
        {
            _order = WithDefaults();
        }

        public Order Build()
        {
            return _order;
        }
    }
}
