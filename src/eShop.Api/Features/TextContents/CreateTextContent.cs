using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Models;
using eShop.Api.Core;
using eShop.Api.Interfaces;

namespace eShop.Api.Features
{
    public class CreateTextContent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.TextContent).NotNull();
                RuleFor(request => request.TextContent).SetValidator(new TextContentValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public TextContentDto TextContent { get; set; }
        }

        public class Response: ResponseBase
        {
            public TextContentDto TextContent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;
        
            public Handler(IEShopDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var textContent = new TextContent();
                
                _context.TextContents.Add(textContent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    TextContent = textContent.ToDto()
                };
            }
            
        }
    }
}
