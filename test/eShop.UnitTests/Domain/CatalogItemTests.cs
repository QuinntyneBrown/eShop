using eShop.Api.Models;
using Xunit;

namespace eShop.UnitTests.Domain
{
    public class CatalogItemTests
    {
        [Fact]
        public void Constructor()
        {
            var sut = new CatalogItem("Test");
        }
    }
}
