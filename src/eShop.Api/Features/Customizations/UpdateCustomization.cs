using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class UpdateCustomization
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Customization).NotNull();
                RuleFor(request => request.Customization).SetValidator(new CustomizationValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public CustomizationDto Customization { get; set; }
        }

        public class Response : ResponseBase
        {
            public CustomizationDto Customization { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var customization = await _context.Customizations.SingleAsync(x => x.CustomizationId == request.Customization.CustomizationId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Customization = customization.ToDto()
                };
            }

        }
    }
}
