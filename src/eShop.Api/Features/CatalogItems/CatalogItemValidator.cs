using FluentValidation;

namespace eShop.Api.Features
{
    public class CatalogItemValidator : AbstractValidator<CatalogItemDto>
    {
        public CatalogItemValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
