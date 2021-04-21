using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using eShop.Api.Models;
using eShop.Api.Core;
using eShop.Api.Interfaces;

namespace eShop.Api.Features
{
    public class RemoveTextContent
    {
        public class Request: IRequest<Response>
        {
            public Guid TextContentId { get; set; }
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
                var textContent = await _context.TextContents.SingleAsync(x => x.TextContentId == request.TextContentId);
                
                _context.TextContents.Remove(textContent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    TextContent = textContent.ToDto()
                };
            }
            
        }
    }
}
