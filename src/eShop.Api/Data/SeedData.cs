using eShop.Api.Core;
using eShop.Api.Models;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.Api.Data
{
    public static class SeedData
    {
        public static void Seed(EShopDbContext context)
        {
            RoleConfiguration.Seed(context);
            UserConfiguration.Seed(context);
            SocialShareConfiguration.Seed(context);
            DigitalAssetConfiguration.Seed(context);
            ImageContentConfiguration.Seed(context);
            CatalogConfiguration.Seed(context);
            HtmlContentConfiguration.Seed(context);
        }

        internal static class ImageContentConfiguration
        {
            internal static void Seed(EShopDbContext context)
            {
                var d = context.DigitalAssets.ToList();

                var heroImageContent = context.ImageContents.SingleOrDefault(x => x.ImageContentType == Models.ImageContentType.Hero);

                if (heroImageContent == null)
                {
                    var digitalAsset = context.DigitalAssets.SingleOrDefault(x => x.Name == "hero.png");

                    heroImageContent = new(ImageContentType.Hero, $"api/DigitalAsset/serve/{digitalAsset.DigitalAssetId}");

                    context.ImageContents.Add(heroImageContent);

                    context.SaveChanges();
                }

                var logoImageContent = context.ImageContents.SingleOrDefault(x => x.ImageContentType == Models.ImageContentType.Logo);

                if (logoImageContent == null)
                {
                    var digitalAsset = context.DigitalAssets.SingleOrDefault(x => x.Name == "logo.svg");

                    logoImageContent = new(ImageContentType.Logo, $"api/DigitalAsset/serve/{digitalAsset.DigitalAssetId}");

                    context.ImageContents.Add(logoImageContent);

                    context.SaveChanges();
                }

            }
        }

        internal static class HtmlContentConfiguration
        {
            internal static void Seed(EShopDbContext context)
            {
                foreach (var htmlContent in new List<HtmlContent>()
                {
                    new (HtmlContentType.About,"","<h1>About</h1>"),
                    new (HtmlContentType.FollowUs,"","<h1>Follow Us</h1>"),
                    new (HtmlContentType.Contact,"","<h1>Contact</h1>"),
                    new (HtmlContentType.ReturnPolicy,"","<h1>Return Policy</h1>")
                })
                {
                    AddIfDoesntExist(htmlContent);
                }

                context.SaveChanges();

                void AddIfDoesntExist(HtmlContent htmlContent)
                {
                    if (context.HtmlContents.FirstOrDefault(x => x.HtmlContentType == htmlContent.HtmlContentType) == null)
                    {
                        context.HtmlContents.Add(htmlContent);
                    }
                }
            }
        }

        internal static class DigitalAssetConfiguration
        {
            internal static void Seed(EShopDbContext context)
            {
                for (var i = 1; i <= 4; i++)
                {
                    Save($"macrame-{i}.jpg");
                }

                for (var i = 1; i <= 3; i++)
                {
                    Save($"vase-{i}.jpg");
                }

                for (var i = 1; i <= 1; i++)
                {
                    Save($"basket-{i}.jpg");
                }

                for (var i = 1; i <= 1; i++)
                {
                    Save($"candle-holder-{i}.jpg");
                }

                Save($"hero.png");

                Save($"hero_v2.png");

                Save($"logo.svg");

                context.SaveChanges();

                void Save(string filename)
                {
                    var provider = new FileExtensionContentTypeProvider();

                    provider.TryGetContentType(filename, out string contentType);

                    var digitalAsset = new DigitalAsset
                    {
                        Name = filename,
                        Bytes = StaticFileLocator.Get(filename),
                        ContentType = contentType
                    };

                    context.DigitalAssets.Add(digitalAsset);
                }
            }
        }
        internal static class CatalogConfiguration
        {
            internal static void Seed(EShopDbContext context)
            {
                for (var i = 1; i <= 4; i++)
                {
                    Save($"macrame-{i}.jpg");
                }

                for (var i = 1; i <= 3; i++)
                {
                    Save($"vase-{i}.jpg");
                }

                for (var i = 1; i <= 1; i++)
                {
                    Save($"basket-{i}.jpg");
                }

                for (var i = 1; i <= 1; i++)
                {
                    Save($"candle-holder-{i}.jpg");
                }

                void Save(string name)
                {
                    var catalogItem = context.CatalogItems.SingleOrDefault(x => x.Name == $"");

                    if (catalogItem == null)
                    {
                        catalogItem = new(default);

                        var digitalAsset = context.DigitalAssets.Single(x => x.Name == name);

                        catalogItem.CatalogItemImages.Add(new CatalogItemImage(name, default, digitalAsset.DigitalAssetId));

                        context.CatalogItems.Add(catalogItem);

                        context.SaveChanges();
                    }
                }
            }
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

                    if (role == null)
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
                        UserId = new Guid("4d757c4c-8a05-4db3-a872-0fdea0ddd421"),
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

        internal static class SocialShareConfiguration
        {
            internal static void Seed(EShopDbContext context)
            {
                foreach (var socialShare in new List<SocialShare> {
                    new (SocialShareType.Facebook,"https//www.facebook.com"),
                    new (SocialShareType.Twitter,"https//www.twitter.com"),
                    new (SocialShareType.Instagram,"https//www.instagram.com")
                })
                {
                    AddIfDoesntExist(socialShare);
                }

                context.SaveChanges();

                void AddIfDoesntExist(SocialShare socialShare)
                {
                    if (context.SocialShares.FirstOrDefault(x => x.ShareType == socialShare.ShareType) == null)
                    {
                        context.SocialShares.Add(socialShare);
                    }
                }
            }
        }
    }
}
