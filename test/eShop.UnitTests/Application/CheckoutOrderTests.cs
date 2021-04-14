using eShop.Api.Data;
using eShop.Api.Interfaces;
using eShop.Api.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using static eShop.Api.Features.CheckoutOrder;
using static eShop.Testing.Builders.CheckoutOrderBuilder;

namespace eShop.UnitTests.Application
{
    public class CheckoutOrderTests
    {
        private IEShopDbContext _context;
        private IStripeClient _client;

        [Fact]
        public void Constructor()
        {
            Setup($"{nameof(CheckoutOrderTests)}{nameof(Constructor)}");

            var actual = CreateHandler();

            Assert.NotNull(actual);
        }

        private void Setup(string databaseName)
        {
            _context = new EShopDbContext(new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName)
                .Options);

            var mockStripeClient = new Mock<IStripeClient>();

            _client = mockStripeClient.Object;
        }

        public Handler CreateHandler()
            => new(_context, _client);
    }
}
