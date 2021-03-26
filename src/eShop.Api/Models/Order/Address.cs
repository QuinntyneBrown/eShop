using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace eShop.Api.Models
{
    [Owned]
    public class Address : ValueObject
    {
        [JsonProperty]
        public string Street { get; private set; }
        [JsonProperty]
        public string City { get; private set; }
        [JsonProperty]
        public string Province { get; private set; }
        [JsonProperty]
        public string PostalCode { get; private set; }

        protected Address() { }

        private Address(string street, string city, string province, string postalCode)
        {
            Street = street;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }

        public static Result<Address> Create(string street, string city, string province, string postalCode)
        {
            return Result.Success(new Address(street,city,province,postalCode));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Province;
            yield return PostalCode;
        }
    }
}
