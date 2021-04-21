using System;
using System.Collections.Generic;

namespace eShop.Api.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public List<Privilege> Privileges { get; set; } = new ();
        public List<User> Users { get; private set; } = new ();
    }
}
