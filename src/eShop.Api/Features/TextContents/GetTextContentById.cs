using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class GetTextContentById
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
                return new () {
                    TextContent = (await _context.TextContents.SingleOrDefaultAsync(x => x.TextContentId == request.TextContentId)).ToDto()
                };
            }
            
        }
    }
}
