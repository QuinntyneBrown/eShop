using eShop.Api.Core;
using eShop.Api.Interfaces;
using eShop.Api.Models;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class CreateHtmlContent
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.HtmlContent).NotNull();
                RuleFor(request => request.HtmlContent).SetValidator(new HtmlContentValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public HtmlContentDto HtmlContent { get; set; }
        }

        public class Response : ResponseBase
        {
            public HtmlContentDto HtmlContent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var htmlContent = new HtmlContent(request.HtmlContent.HtmlContentType, request.HtmlContent.Name, request.HtmlContent.Body);

                _context.HtmlContents.Add(htmlContent);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    HtmlContent = htmlContent.ToDto()
                };
            }

        }
    }
}
