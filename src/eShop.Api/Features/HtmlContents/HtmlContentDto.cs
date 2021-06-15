using eShop.Api.Models;
using System;

namespace eShop.Api.Features
{
    public class HtmlContentDto
    {
        public Guid? HtmlContentId { get; set; }
        public HtmlContentType HtmlContentType { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
    }
}
