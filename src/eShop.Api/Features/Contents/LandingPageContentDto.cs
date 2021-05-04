using System;
using System.Collections.Generic;

namespace eShop.Api.Features
{
    public class LandingPageContentDto
    {
        public Guid HeroImageDigitalAssetId { get; set; }
        public string Caption { get; set; }
        public List<CatalogItemDto> FeaturedCatalogItems { get; set; }
        public string About { get; set; }
    }
}
