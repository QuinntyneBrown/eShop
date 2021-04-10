using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class AddressBuilder
    {
        private Address _address;

        public static Address WithDefaults()
        {
            return Address.Create(default, default, default, default).Value;
        }

        public AddressBuilder()
        {
            _address = WithDefaults();
        }

        public Address Build()
        {
            return _address;
        }
    }
}
