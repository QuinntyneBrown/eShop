using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Models;
using eShop.Api.Core;
using eShop.Api.Interfaces;

namespace eShop.Api.Features
{
    public class CreateOrder
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Order).NotNull();
                RuleFor(request => request.Order).SetValidator(new OrderValidator());
            }
        }

        public class Request: IRequest<Response>
        {
            public OrderDto Order { get; set; }
        }

        public class Response: ResponseBase
        {
            public OrderDto Order { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;
        
            public Handler(IEShopDbContext context)
                => _context = context;
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var order = new Order();
                
                _context.Orders.Add(order);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Order = order.ToDto()
                };
            }
            
        }
    }
}
