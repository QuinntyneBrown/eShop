using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class HtmlContentExtensions
    {
        public static HtmlContentDto ToDto(this HtmlContent htmlContent)
        {
            return new()
            {
                HtmlContentId = htmlContent.HtmlContentId
            };
        }

    }
}
