using eShop.Api.Data;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
using static eShop.Api.Features.CreateCatalogItem;
using static eShop.Testing.Builders.CreateCatalogItemBuilder;

namespace eShop.UnitTests.Application
{
    public class CreateCatalogItemTests
    {        
        private IEShopDbContext _context;

        [Fact]
        public void Constructor()
        {
            Setup(nameof(Constructor));

            var sut = CreateSut();
        }

        [Fact]
        public async Task Create()
        {
            var request = new RequestBuilder()
                .WithName("Carpet")
                .Build();

            Setup(nameof(Create));

            var sut = CreateSut();

            var actual = await sut.Handle(request, default);

            Assert.NotEqual(default(Guid), actual.CatalogItem.CatalogItemId);
        }

        [Fact]
        public void Create_ValidationErrors()
        {
            var expected = 2;

            var request = new RequestBuilder()
                .Build();

            var validator = new Validator();

            var actual = validator.Validate(request);

            Assert.Equal(expected, actual.Errors.Count);
        }

        private void Setup(string databaseName)
        {
            _context = new EShopDbContext(new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName)
                .Options);
        }

        private Handler CreateSut()
            => new(_context);
    }
}
