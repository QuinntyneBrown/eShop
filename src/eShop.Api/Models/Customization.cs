using System;

namespace eShop.Api.Models
{
    public class Customization
    {
        public Guid CustomizationId { get; set; }
        public string BackgroundColor { get; private set; }
    }
}
