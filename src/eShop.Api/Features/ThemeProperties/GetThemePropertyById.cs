using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class GetThemePropertyById
    {
        public class Request: IRequest<Response>
        {
            public Guid ThemePropertyId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ThemePropertyDto ThemeProperty { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;
        
            public Handler(IEShopDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    ThemeProperty = (await _context.ThemeProperties.SingleOrDefaultAsync(x => x.ThemePropertyId == request.ThemePropertyId)).ToDto()
                };
            }
            
        }
    }
}
