using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class BasketBuilder
    {
        private Basket _basket;

        public static Basket WithDefaults()
        {
            return new Basket();
        }

        public BasketBuilder()
        {
            _basket = WithDefaults();
        }

        public Basket Build()
        {
            return _basket;
        }
    }
}
