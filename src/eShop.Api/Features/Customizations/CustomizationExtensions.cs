using System;
using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class CustomizationExtensions
    {
        public static CustomizationDto ToDto(this Customization customization)
        {
            return new ()
            {
                CustomizationId = customization.CustomizationId
            };
        }
        
    }
}
