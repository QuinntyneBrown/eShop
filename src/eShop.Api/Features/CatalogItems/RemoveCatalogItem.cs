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
    public class RemoveCatalogItem
    {
        public class Request: IRequest<Response>
        {
            public Guid CatalogItemId { get; set; }
        }

        public class Response: ResponseBase
        {
            public CatalogItemDto CatalogItem { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;
        
            public Handler(IEShopDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var catalogItem = await _context.CatalogItems.SingleAsync(x => x.CatalogItemId == request.CatalogItemId);
                
                _context.CatalogItems.Remove(catalogItem);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    CatalogItem = catalogItem.ToDto()
                };
            }
            
        }
    }
}
