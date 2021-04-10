using eShop.Api.Features;


namespace eShop.Testing.Builders
{
    public class CatalogItemDtoBuilder
    {
        private CatalogItemDto _catalogItemDto;

        public static CatalogItemDto WithDefaults()
        {
            return new()
            {
                Name = "Default"
            };
        }

        public CatalogItemDtoBuilder()
        {
            _catalogItemDto = WithDefaults();
        }

        public CatalogItemDto Build()
        {
            return _catalogItemDto;
        }
    }
}
