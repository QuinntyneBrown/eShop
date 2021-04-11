using eShop.Api.Core;
using eShop.Api.Models;
using System;
using System.Linq;

namespace eShop.Api.Data
{
    public static class SeedData
    {
        public static void Seed(EShopDbContext context)
        {
            RoleConfiguration.Seed(context);
            UserConfiguration.Seed(context);
        }

        internal class RoleConfiguration
        {
            internal static void Seed(EShopDbContext context)
            {
                AddOrCreateRole("admin");
                AddOrCreateRole("system");

                context.SaveChanges();

                void AddOrCreateRole(string name)
                {
                    var role = context.Roles.SingleOrDefault(x => x.Name == name);

                    if(role == null)
                    {
                        context.Roles.Add(new Role
                        {
                            Name = name
                        });
                    }
                }
            }
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
                        UserId  = new Guid("4d757c4c-8a05-4db3-a872-0fdea0ddd421"),
                        Username = "admin"
                    };

                    user.Roles.Add(context.Roles.Single(x => x.Name == "admin"));

                    user.Password = new PasswordHasher().HashPassword(user.Salt, "admin");

                    context.Users.Add(user);
                    context.SaveChanges();
                }

                var system = context.Users.SingleOrDefault(x => x.Username == "system");

                if (user == null)
                {
                    system = new User
                    {
                        Username = "system",
                        UserId = new Guid("bbecac26-bd9a-41ca-805e-b00c6af48559")
                    };

                    system.Roles.Add(context.Roles.Single(x => x.Name == "system"));

                    system.Password = new PasswordHasher().HashPassword(user.Salt, "admin");

                    context.Users.Add(system);
                    context.SaveChanges();
                }
            }
        }
    }
}
