using eShop.Api.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class RemoveOrder
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {

            }
        }

        public class Request : IRequest<Response>
        {

        }

        public class Response
        {

        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                return new Response()
                {

                };
            }
        }
    }
}
