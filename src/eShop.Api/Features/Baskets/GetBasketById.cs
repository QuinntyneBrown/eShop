using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class GetBasketById
    {
        public class Request : IRequest<Response>
        {
            public System.Guid BasketId { get; set; }
        }

        public class Response : ResponseBase
        {
            public BasketDto Basket { get; set; }
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
                    Basket = (await _context.Baskets.SingleOrDefaultAsync(x => x.BasketId == request.BasketId)).ToDto()
                };
            }

        }
    }
}
