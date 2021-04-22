using System;

namespace eShop.Api.Models
{
    public class Contact
    {
        public Guid ContactId { get; private set; }
        public string Email { get; private set; }
        public string Instagram { get; private set; }
        public Contact(string email, string instagram)
        {
            Email = email;
            Instagram = instagram;
        }

        private Contact()
        {

        }
    }
}
