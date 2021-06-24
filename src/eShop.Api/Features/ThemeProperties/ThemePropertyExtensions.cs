using eShop.Api.Models;

namespace eShop.Api.Features
{
    public static class ThemePropertyExtensions
    {
        public static ThemePropertyDto ToDto(this ThemeProperty themeProperty)
        {
            return new()
            {
                ThemePropertyId = themeProperty.ThemePropertyId,
                CssCustomPropertyName = themeProperty.CssCustomPropertyName,
                Value = themeProperty.Value
            };
        }
    }
}
