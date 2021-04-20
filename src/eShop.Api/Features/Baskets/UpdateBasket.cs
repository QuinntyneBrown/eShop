using eShop.Api.Core;
using eShop.Api.Interfaces;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class UpdateBasket
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Basket).NotNull();
                RuleFor(request => request.Basket).SetValidator(new BasketValidator());
            }
        }

        public class Request : IRequest<Response>
        {
            public BasketDto Basket { get; set; }
        }

        public class Response : ResponseBase
        {
            public BasketDto Basket { get; set; }
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

                var basket = await _context.Baskets.FindAsync(request.Basket.BasketId);


                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Basket = basket.ToDto()
                };
            }
        }
    }
}
