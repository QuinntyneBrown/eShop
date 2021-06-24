using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Models;
using eShop.Api.Core;
using eShop.Api.Interfaces;

namespace eShop.Api.Features
{
    public class CreateThemeProperty
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ThemeProperty).NotNull();
                RuleFor(request => request.ThemeProperty).SetValidator(new ThemePropertyValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ThemePropertyDto ThemeProperty { get; set; }
        }

        public class Response : ResponseBase
        {
            public ThemePropertyDto ThemeProperty { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var themeProperty = new ThemeProperty(request.ThemeProperty.CssCustomPropertyName, request.ThemeProperty.Value);

                _context.ThemeProperties.Add(themeProperty);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    ThemeProperty = themeProperty.ToDto()
                };
            }

        }
    }
}
