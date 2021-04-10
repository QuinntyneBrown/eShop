using eShop.Api.Features;

namespace eShop.Testing.Builders
{
    public class ContactDtoBuilder
    {
        private ContactDto _contactDto;

        public static ContactDto WithDefaults()
        {
            return new ContactDto();
        }

        public ContactDtoBuilder()
        {
            _contactDto = WithDefaults();
        }

        public ContactDto Build()
        {
            return _contactDto;
        }
    }
}
