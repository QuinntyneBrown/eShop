using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using eShop.Api.Core;
using eShop.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Features
{
    public class GetBaskets
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<BasketDto> Baskets { get; set; }
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
                    Baskets = await _context.Baskets.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
