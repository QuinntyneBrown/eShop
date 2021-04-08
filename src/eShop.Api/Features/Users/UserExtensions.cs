using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new()
            {
                UserId = user.UserId,
                Username = user.Username
            };
        }

    }
}
