using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class ContactExtensions
    {
        public static ContactDto ToDto(this Contact contact)
        {
            return new()
            {
                ContactId = contact.ContactId,
                Email = contact.Email
            };
        }

    }
}
