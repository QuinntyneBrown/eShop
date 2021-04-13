using eShop.Api.Models;
using System.Linq;

namespace eShop.Api.Features
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this User user)
        {
            return new()
            {
                UserId = user.UserId,
                Username = user.Username,
                AvatarDigitalAssetId = user.AvatarDigitalAssetId,
                Roles = user.Roles.Select(x => x.ToDto()).ToList()
            };
        }
    }
}
