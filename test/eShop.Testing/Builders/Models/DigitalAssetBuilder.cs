using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class DigitalAssetBuilder
    {
        private DigitalAsset _digitalAsset;

        public static DigitalAsset WithDefaults()
        {
            return new DigitalAsset();
        }

        public DigitalAssetBuilder()
        {
            _digitalAsset = WithDefaults();
        }

        public DigitalAsset Build()
        {
            return _digitalAsset;
        }
    }
}
