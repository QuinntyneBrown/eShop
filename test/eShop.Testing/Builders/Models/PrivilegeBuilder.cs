using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class PrivilegeBuilder
    {
        private Privilege _privilege;

        public static Privilege WithDefaults()
        {
            return new Privilege();
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
