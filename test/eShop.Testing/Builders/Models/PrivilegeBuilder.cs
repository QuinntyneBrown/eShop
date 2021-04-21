using eShop.Api.Models;
using System;

namespace eShop.Testing.Builders
{
    public class PrivilegeBuilder
    {
        private Privilege _privilege;

        public static Privilege WithDefaults()
        {
            throw new NotImplementedException();
        }

        public PrivilegeBuilder()
        {
            _privilege = WithDefaults();
        }

        public Privilege Build()
        {
            return _privilege;
        }
    }
}
