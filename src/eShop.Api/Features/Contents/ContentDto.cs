using System;

namespace eShop.Api.Features
{
    public class ContentDto
    {
        public Guid ContentId { get; set; }
        public string Title { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LogoUrl { get; set; }
        public string HeroImageUrl { get; set; }
        public string About { get; set; }
        public string TermsOfService { get; set; }
    }
}
