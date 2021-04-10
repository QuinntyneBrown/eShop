using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using eShop.Api.Extensions;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using eShop.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class GetCustomizationsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<CustomizationDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;
        
            public Handler(IEShopDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from customization in _context.Customizations
                    select customization;
                
                var length = await _context.Customizations.CountAsync();
                
                var customizations = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = customizations
                };
            }
            
        }
    }
}
