using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class ContentExtensions
    {
        public static ContentDto ToDto(this Content content)
        {
            return new ()
            {
                ContentId = content.ContentId
            };
        }
        
    }
}
