using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class PrivilegeExtensions
    {
        public static PrivilegeDto ToDto(this Privilege privilege)
        {
            return new ()
            {
                PrivilegeId = privilege.PrivilegeId
            };
        }
        
    }
}
