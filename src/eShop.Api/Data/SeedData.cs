using eShop.Api.Core;
using eShop.Api.Models;
using System.Linq;

namespace eShop.Api.Data
{
    public static class SeedData
    {
        public static void Seed(EShopDbContext context)
        {
            UserConfiguration.Seed(context);
        }

        internal class UserConfiguration
        {
            internal static void Seed(EShopDbContext context)
            {
                var user = context.Users.SingleOrDefault(x => x.Username == "admin");

                if (user == null)
                {
                    user = new User
                    {
                        Username = "admin"
                    };

                    user.Password = new PasswordHasher().HashPassword(user.Salt, "admin");

                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }
    }
}
