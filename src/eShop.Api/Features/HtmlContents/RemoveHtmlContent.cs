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
    public class RemoveHtmlContent
    {
        public class Request: IRequest<Response>
        {
            public Guid HtmlContentId { get; set; }
        }

        public class Response: ResponseBase
        {
            public HtmlContentDto HtmlContent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;
        
            public Handler(IEShopDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var htmlContent = await _context.HtmlContents.SingleAsync(x => x.HtmlContentId == request.HtmlContentId);
                
                _context.HtmlContents.Remove(htmlContent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    HtmlContent = htmlContent.ToDto()
                };
            }
            
        }
    }
}
