using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class ImageContentExtensions
    {
        public static ImageContentDto ToDto(this ImageContent imageContent)
        {
            return new()
            {
                ImageContentId = imageContent.ImageContentId
            };
        }

    }
}
