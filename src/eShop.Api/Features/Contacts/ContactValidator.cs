using FluentValidation;

namespace eShop.Api.Features
{
    public class ContactValidator : AbstractValidator<ContactDto> {
        public ContactValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
        }
    }
}
