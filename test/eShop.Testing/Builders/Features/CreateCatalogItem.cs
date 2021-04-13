namespace eShop.Testing.Builders
{
    using static eShop.Api.Features.CreateCatalogItem;

    public class CreateCatalogItemBuilder
    {
        public class RequestBuilder
        {
            private string _name;

            public RequestBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public Request Build()
            {
                return new Request
                {
                    CatalogItem = new Api.Features.CatalogItemDto
                    {
                        Name = _name
                    }
                };
            }
        }
    }
}
