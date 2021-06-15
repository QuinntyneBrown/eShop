using System;

namespace eShop.Api.Features
{
    public class ThemePropertyDto
    {
        public Guid? ThemePropertyId { get; set; }
        public string CssCustomPropertyName { get; set; }
        public string Value { get; set; }

    }
}
