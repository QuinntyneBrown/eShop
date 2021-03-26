using System;
using System.Security.Cryptography;

namespace eShop.Api.Models
{
    public class User
    {
        public User()
        {
            Salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(Salt);
            }
        }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; private set; }
        public string RefreshToken { get; private set; }

        public User AddRefreshToken(string token)
        {
            RefreshToken = token;
            return this;
        }
    }
}
