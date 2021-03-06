using eShop.Api.Core;
using eShop.Api.Interfaces;
using eShop.Api.Models;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class CreateContent
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Content).NotNull();
                RuleFor(request => request.Content).SetValidator(new ContentValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ContentDto Content { get; set; }
        }

        public class Response : ResponseBase
        {
            public ContentDto Content { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var content = new Content(request.Content.Title);

                _context.Contents.Add(content);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Content = content.ToDto()
                };
            }

        }
    }
}
