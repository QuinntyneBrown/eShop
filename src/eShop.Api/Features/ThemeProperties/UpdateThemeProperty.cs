using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class UpdateThemeProperty
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
                var themeProperty = await _context.ThemeProperties.SingleAsync(x => x.ThemePropertyId == request.ThemeProperty.ThemePropertyId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    ThemeProperty = themeProperty.ToDto()
                };
            }

        }
    }
}
