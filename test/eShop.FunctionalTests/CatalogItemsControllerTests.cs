using eShop.Api.Features;
using eShop.Api.Models;
using eShop.Testing;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;
using eShop.Testing.Builders;
using static eShop.FunctionalTests.CatalogItemsControllerTests.Endpoints;

namespace eShop.FunctionalTests
{
    using Task = System.Threading.Tasks.Task;
    using Post = CatalogItemsControllerTests.Endpoints.Post;

    public class CatalogItemsControllerTests : IClassFixture<ApiTestFixture>
    {
        private readonly ApiTestFixture _fixture;
        public CatalogItemsControllerTests(ApiTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Should_CreateCatalogItem()
        {
            var catalogItem = CatalogItemDtoBuilder.WithDefaults();

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(new { catalogItem }), Encoding.UTF8, "application/json");

            using var client = _fixture.CreateAuthenticatedClient();

            var httpResponseMessage = await client.PostAsync(Post.CreateCatalogItem, stringContent);

            var response = JsonConvert.DeserializeObject<CreateCatalogItem.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            var actual = await _fixture.Context.CatalogItems.FindAsync(response.CatalogItem.CatalogItemId);

            Assert.NotEqual(default, actual);
        }

        [Fact]
        public async Task Should_RemoveCatalogItem()
        {
            var catalogItem = CatalogItemBuilder.WithDefaults();

            var client = _fixture.CreateAuthenticatedClient();

            _fixture.Context.Add(catalogItem);

            await _fixture.Context.SaveChangesAsync(default);

            var httpResponseMessage = await client.DeleteAsync(Delete.By(catalogItem.CatalogItemId));

            httpResponseMessage.EnsureSuccessStatusCode();

            _fixture.Context.ChangeTracker.Clear();

            var actual = await _fixture.Context.CatalogItems.FindAsync(catalogItem.CatalogItemId);

            Assert.Null(actual);

        }

        [Fact]
        public async Task Should_UpdateCatalogItem()
        {
            var catalogItem = CatalogItemBuilder.WithDefaults();

            var context = _fixture.Context;

            context.Add(catalogItem);

            await context.SaveChangesAsync(default);

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(new { catalogItem = catalogItem.ToDto() }), Encoding.UTF8, "application/json");

            var httpResponseMessage = await _fixture.CreateAuthenticatedClient().PutAsync(Put.Update, stringContent);

            httpResponseMessage.EnsureSuccessStatusCode();

            var actual = await context.FindAsync<CatalogItem>(catalogItem.CatalogItemId);

        }

        [Fact]
        public async Task Should_GetCatalogItems()
        {
            var catalogItem = CatalogItemBuilder.WithDefaults();

            var context = _fixture.Context;

            context.Add(catalogItem);

            await context.SaveChangesAsync(default);

            var httpResponseMessage = await _fixture.CreateAuthenticatedClient().GetAsync(Get.CatalogItems);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetCatalogItems.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.True(response.CatalogItems.Any());
        }

        [Fact]
        public async Task Should_GetCatalogItemById()
        {
            var catalogItem = CatalogItemBuilder.WithDefaults();

            var context = _fixture.Context;

            context.Add(catalogItem);

            await context.SaveChangesAsync(default);

            var httpResponseMessage = await _fixture.CreateAuthenticatedClient().GetAsync(Get.By(catalogItem.CatalogItemId));

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = JsonConvert.DeserializeObject<GetCatalogItemById.Response>(await httpResponseMessage.Content.ReadAsStringAsync());

            Assert.NotNull(response);

        }

        internal static class Endpoints
        {
            public static class Post
            {
                public static string CreateCatalogItem = "api/CatalogItem";
            }

            public static class Put
            {
                public static string Update = "api/CatalogItem";
            }

            public static class Delete
            {
                public static string By(Guid catalogItemId)
                {
                    return $"api/CatalogItem/{catalogItemId}";
                }
            }

            public static class Get
            {
                public static string CatalogItems = "api/CatalogItem";
                public static string By(Guid catalogItemId)
                {
                    return $"api/CatalogItem/{catalogItemId}";
                }

                public static string Page(int index, int pageSize)
                {
                    return $"api/CatalogItem/page/{index}/{pageSize}";
                }
            }
        }
    }
}
