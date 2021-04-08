using eShop.Api.Core;
using System;

namespace eShop.Api.Models
{
    public class Customer : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public Customer()
        {

        }

    }
}
