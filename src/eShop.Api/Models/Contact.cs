using System;

namespace eShop.Api.Models
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public string Email { get; set; }
        public Contact(string email)
        {
            Email = email;
        }

        private Contact()
        {

        }
    }
}
