using FluentValidation;

namespace eShop.Api.Features
{
    public class BasketValidator : AbstractValidator<BasketDto>
    {
        public BasketValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().NotEmpty();
        }
    }
}
