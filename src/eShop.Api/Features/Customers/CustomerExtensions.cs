using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class CustomerExtensions
    {
        public static CustomerDto ToDto(this Customer customer)
        {
            return new()
            {
                CustomerId = customer.CustomerId
            };
        }

    }
}
