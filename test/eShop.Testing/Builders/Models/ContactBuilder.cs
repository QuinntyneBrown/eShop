using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class ContactBuilder
    {
        private Contact _contact;

        public static Contact WithDefaults()
        {
            return new Contact("DefaultName", "default@email.com");
        }

        public ContactBuilder()
        {
            _contact = WithDefaults();
        }

        public Contact Build()
        {
            return _contact;
        }
    }
}
