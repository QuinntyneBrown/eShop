using System;

namespace eShop.Api.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message = null)
            : base(message)
        {

        }
    }
}
