using System;
using System.Collections.Generic;

namespace eShop.Api.Features
{
    public class UserDto
    {
        public static readonly UserDto Anonymous = new();
        public Guid? UserId { get; set; }
        public string Username { get; set; }
        public List<RoleDto> Roles { get; set; }
        = new List<RoleDto>();
    }
}
