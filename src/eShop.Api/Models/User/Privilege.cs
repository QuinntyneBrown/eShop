using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace eShop.Api.Models
{
    public class Privilege
    {
        public Guid PrivilegeId { get; set; }
        public AccessRight AccessRight { get; private set; }
        public string Aggregate { get; private set; }
        public List<Role> Roles { get; private set; } = new();
        public Privilege(AccessRight accessRight, string aggregate)
        {
            AccessRight = accessRight;
            Aggregate = aggregate;
        }

        private Privilege() { }
    }
}
