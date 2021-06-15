using System;

namespace eShop.Api.Models
{
    public class ImageContent
    {
        public Guid ImageContentId { get; set; }
        public ImageContentType ImageContentType { get; set; } 
        public Guid DigitalAssetId { get; set; }
    }
}
