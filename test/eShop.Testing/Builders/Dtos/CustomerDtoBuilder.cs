using eShop.Api.Features;
using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class CustomerDtoBuilder
    {
        private CustomerDto _customerDto;

        public static CustomerDto WithDefaults()
        {
            return new CustomerDto();
        }

        public CustomerDtoBuilder()
        {
            _customerDto = WithDefaults();
        }

        public CustomerDto Build()
        {
            return _customerDto;
        }
    }
}
