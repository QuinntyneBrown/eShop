using eShop.Api.Features;
using eShop.Api.Models;

namespace eShop.Testing.Builders
{
    public class UserDtoBuilder
    {
        private UserDto _userDto;

        public static UserDto WithDefaults()
        {
            return new UserDto();
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
