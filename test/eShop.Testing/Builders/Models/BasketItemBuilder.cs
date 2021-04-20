using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class BasketItemBuilder
    {
        private BasketItem _basketItem;

        public static BasketItem WithDefaults()
        {
            return new BasketItem(default, default, default);
        }

        public BasketItemBuilder()
        {
            _basketItem = WithDefaults();
        }

        public BasketItem Build()
        {
            return _basketItem;
        }
    }
}
