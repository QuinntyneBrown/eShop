using eShop.Api.Features;

namespace eShop.Testing.Builders
{
    public class UserDtoBuilder
    {
        private UserDto _userDto;

        public static UserDto WithDefaults()
        {
            return new();
        }

        public UserDtoBuilder()
        {
            _userDto = WithDefaults();
        }

        public UserDto Build()
        {
            return _userDto;
        }
    }
}
