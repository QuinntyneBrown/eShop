﻿using eShop.Api;
using eShop.Api.Core;
using eShop.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace eShop.Testing
{
    public class TokenFactory
    {
        private static readonly ITokenProvider _tokenProvider;
        static TokenFactory()
        {
            _tokenProvider = new TokenProvider(ConfigurationFactory.Create());
        }

        public static string GetAdminUserToken()
        {
            string userName = "test@test.com";
            string[] roles = { "Admin" };

            return CreateToken(userName, roles);
        }

        public static string CreateToken(string userName, IEnumerable<string> roles)
        {
            var claims = roles.Select(x => new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", x))
                .ToList();

            return _tokenProvider.Get(userName, claims);
        }

        public static string CreateToken(User user, IEnumerable<Role> roles)
        {

            var claims = roles.Select(x => new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", x.Name))
                .ToList();

            claims.Add(new Claim(Constants.ClaimTypes.UserId, $"{user.UserId}"));

            return _tokenProvider.Get(user.Username, claims);
        }
    }
}
