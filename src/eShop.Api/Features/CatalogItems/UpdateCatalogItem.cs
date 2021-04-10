using eShop.Api.Core;
using eShop.Api.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class UpdateCatalogItem
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CatalogItem).NotNull();
                RuleFor(request => request.CatalogItem).SetValidator(new CatalogItemValidator());
            }
        }

        public class Request: IRequest<Response>
        {
            public CatalogItemDto CatalogItem { get; set; }
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
                var catalogItem = await _context.CatalogItems.SingleAsync(x => x.CatalogItemId == request.CatalogItem.CatalogItemId);

                catalogItem.UpdateName(request.CatalogItem.Name);

                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    CatalogItem = catalogItem.ToDto()
                };
            }
            
        }
    }
}
