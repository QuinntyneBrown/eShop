using System;

namespace eShop.Api.Models
{
    public class HtmlContent
    {
        public Guid HtmlContentId { get; private set; }
        public HtmlContentType HtmlContentType { get; private set; }
        public string Name { get; private set; }
        public string Body { get; private set; }
    }
}
