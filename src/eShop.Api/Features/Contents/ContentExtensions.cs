using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class ContentExtensions
    {
        public static ContentDto ToDto(this Content content)
        {
            return new()
            {
                ContentId = content.ContentId,
                Title = content.Title,
                FacebookUrl = content.FacebookUrl,
                InstagramUrl = content.InstagramUrl,
                TwitterUrl = content.TwitterUrl,
                TermsOfService = content.TermsOfService,
                About = content.About,
                LogoUrl = content.LogoUrl,
                HeroImageUrl = content.HeroImageUrl
            };
        }
    }
}
