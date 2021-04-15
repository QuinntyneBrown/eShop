using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class OrderBuilder
    {
        private Order _order;


        public static OrderBuilder Create()
        {
            return new OrderBuilder();
        }

        public Order ToObject()
        {
            return _order;
        }
    }
}
