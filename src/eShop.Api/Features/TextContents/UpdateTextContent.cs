using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class UpdateTextContent
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.TextContent).NotNull();
                RuleFor(request => request.TextContent).SetValidator(new TextContentValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public TextContentDto TextContent { get; set; }
        }

        public class Response : ResponseBase
        {
            public TextContentDto TextContent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var textContent = await _context.TextContents.SingleAsync(x => x.TextContentId == request.TextContent.TextContentId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    TextContent = textContent.ToDto()
                };
            }

        }
    }
}
