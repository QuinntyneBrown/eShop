using System;

namespace eShop.Api.Models
{
    public class Content
    {
        public Guid ContentId { get; set; }
        public string FacebookUrl { get; private set; }
        public string InstagramUrl { get; private set; }
        public string TwitterUrl { get; private set; }
        public string LogoUrl { get; private set; }
        public string HeroImageUrl { get; private set; }
        public string About { get; private set; }
        public string TermsOfService { get; private set; }
    }
}
