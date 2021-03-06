using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class UserBuilder
    {
        private User _user;

        public static User WithDefaults()
        {
            return new User();
        }

        public UserBuilder()
        {
            _user = WithDefaults();
        }

        public User Build()
        {
            return _user;
        }
    }
}
