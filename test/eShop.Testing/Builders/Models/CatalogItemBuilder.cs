using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class CatalogItemBuilder
    {
        private CatalogItem _catalogItem;

        public static CatalogItem WithDefaults()
        {
            return new CatalogItem();
        }

        public CatalogItemBuilder()
        {
            _catalogItem = WithDefaults();
        }

        public CatalogItem Build()
        {
            return _catalogItem;
        }
    }
}
