using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class CatalogItemImageBuilder
    {
        private CatalogItemImage _catalogItemImage;

        public static CatalogItemImage WithDefaults()
        {
            return new CatalogItemImage();
        }

        public CatalogItemImageBuilder()
        {
            _catalogItemImage = WithDefaults();
        }

        public CatalogItemImage Build()
        {
            return _catalogItemImage;
        }
    }
}
