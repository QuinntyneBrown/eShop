using System;

namespace eShop.Api.Models
{
    public class ThemeProperty
    {
        public Guid ThemePropertyId { get; private set; }
        public string CssCustomPropertyName { get; private set; }
        public string Value { get; private set; }

        public ThemeProperty(string cssCustomPropertyName, string value)
        {
            CssCustomPropertyName = cssCustomPropertyName;
            Value = value;
        }

        private ThemeProperty()
        {

        }
    }
}
