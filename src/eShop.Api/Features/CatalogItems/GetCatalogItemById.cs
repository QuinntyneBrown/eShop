using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class GetCatalogItemById
    {
        public class Request : IRequest<Response>
        {
            public Guid CatalogItemId { get; set; }
        }

        public class Response : ResponseBase
        {
            public CatalogItemDto CatalogItem { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    CatalogItem = (await _context.CatalogItems.SingleOrDefaultAsync()).ToDto()
                };
            }

        }
    }
}
