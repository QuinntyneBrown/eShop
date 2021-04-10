using eShop.Api.Features;

namespace eShop.Testing.Builders
{
    public class BasketDtoBuilder
    {
        private BasketDto _basketDto;

        public static BasketDto WithDefaults()
        {
            return new BasketDto();
        }

        public BasketDtoBuilder()
        {
            _basketDto = WithDefaults();
        }

        public BasketDto Build()
        {
            return _basketDto;
        }
    }
}
