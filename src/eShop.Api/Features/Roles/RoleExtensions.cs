using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class RoleExtensions
    {
        public static RoleDto ToDto(this Role role)
        {
            return new()
            {
                RoleId = role.RoleId
            };
        }

    }
}
