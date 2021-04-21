using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class TextContentExtensions
    {
        public static TextContentDto ToDto(this TextContent textContent)
        {
            return new ()
            {
                TextContentId = textContent.TextContentId
            };
        }
        
    }
}
