using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class CustomerBuilder
    {
        private Customer _customer;

        public static Customer WithDefaults()
        {
            return new Customer();
        }

        public CustomerBuilder()
        {
            _customer = WithDefaults();
        }

        public Customer Build()
        {
            return _customer;
        }
    }
}
