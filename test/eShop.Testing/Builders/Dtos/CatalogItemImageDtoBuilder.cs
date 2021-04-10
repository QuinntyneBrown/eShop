using eShop.Api.Features;
using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class CatalogItemImageDtoBuilder
    {
        private CatalogItemImageDto _catalogItemImageDto;

        public static CatalogItemImageDto WithDefaults()
        {
            return new CatalogItemImageDto();
        }

        public CatalogItemImageDtoBuilder()
        {
            _catalogItemImageDto = WithDefaults();
        }

        public CatalogItemImageDto Build()
        {
            return _catalogItemImageDto;
        }
    }
}
