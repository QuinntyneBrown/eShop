using eShop.Api.Core;
using eShop.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class GetCustomerById
    {
        public class Request : IRequest<Response>
        {
            public Guid CustomerId { get; set; }
        }

        public class Response : ResponseBase
        {
            public CustomerDto Customer { get; set; }
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
                    Customer = (await _context.Customers.SingleOrDefaultAsync()).ToDto()
                };
            }
        }
    }
}
