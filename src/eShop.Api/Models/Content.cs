using System;

namespace eShop.Api.Models
{
    public class Content
    {
        public Guid ContentId { get; set; }
        public string Title { get; private set; }
        public string FacebookUrl { get; private set; }
        public string InstagramUrl { get; private set; }
        public string TwitterUrl { get; private set; }
        public string LogoUrl { get; private set; }
        public string HeroImageUrl { get; private set; }
        public string About { get; private set; }
        public string TermsOfService { get; private set; }

        public Content(string title, string facebookUrl = null, string instagramUrl = null, string twitterUrl = null, string logoUrl = null, string heroImageUrl = null, string about = null, string termsOfService = null)
        {
            Title = title;
            FacebookUrl = facebookUrl;
            InstagramUrl = instagramUrl;
            TwitterUrl = twitterUrl;
            LogoUrl = logoUrl;
            HeroImageUrl = heroImageUrl;
            About = about;
            TermsOfService = termsOfService;
        }

        private Content()
        {

        }

        public Content Update(string title, string facebookUrl = null, string instagramUrl = null, string twitterUrl = null, string logoUrl = null, string heroImageUrl = null, string about = null, string termsOfService = null)
        {
            Title = title;
            FacebookUrl = facebookUrl;
            InstagramUrl = instagramUrl;
            TwitterUrl = twitterUrl;
            LogoUrl = logoUrl;
            HeroImageUrl = heroImageUrl;
            About = about;
            TermsOfService = termsOfService;
            return this;
        }
    }
}
