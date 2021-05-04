namespace eShop.Api
{
    public static class Constants
    {
        public static class ClaimTypes
        {
            public static readonly string UserId = nameof(UserId);
            public static readonly string ProfileId = nameof(ProfileId);
            public static readonly string AccountId = nameof(AccountId);
            public static readonly string Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
        }

        public static class TextContents
        {
            public static readonly string LandingPageCaption = "Home Page Caption";
            public static readonly string About = nameof(About);
        }

        public static class ImageContents
        {
            public static readonly string Hero = nameof(Hero);
        }

        public static class Currency
        {
            public static readonly string CDN = "CAD";
        }
    }
}
