using eShop.Api.Models;
using System;

namespace eShop.Api.Features
{
    public class ImageContentDto
    {
        public Guid ImageContentId { get; set; }
        public string Url { get; set; }
        public ImageContentType ImageContentType { get; set; }
    }
}
