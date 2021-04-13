using eShop.Api.Core;
using eShop.Api.Exceptions;
using eShop.Api.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eShop.Api.Features
{
    public class CheckoutOrder
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.OrderId).NotEqual(default(System.Guid));
                RuleFor(x => x.Number).NotNull().NotEmpty();
                RuleFor(x => x.ExpMonth).NotEqual(default(long));
                RuleFor(x => x.ExpYear).NotEqual(default(long));
                RuleFor(x => x.Cvc).NotNull().NotEmpty();
            }
        }

        public class Request : IRequest<Response>
        {
            public System.Guid OrderId { get; set; }
            public string Number { get; set; }
            public long ExpMonth { get; set; }
            public long ExpYear { get; set; }
            public string Cvc { get; set; }
        }

        public class Response : ResponseBase
        {
            public OrderDto Order { get; set; }
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

                var order = await _context.Orders.Include(x => x.OrderItems).SingleAsync(x => x.OrderId == request.OrderId);

                order.SetProcessingPaymentStatus();

                await _context.SaveChangesAsync(cancellationToken);

                var optionsToken = new TokenCreateOptions()
                {
                    Card = new AnyOf<string, TokenCardOptions>(new TokenCardOptions
                    {
                        Number = request.Number,
                        ExpYear = request.ExpYear,
                        ExpMonth = request.ExpMonth,
                        Cvc = request.Cvc
                    })
                };

                var serviceToken = new TokenService();

                var stripeToken = await serviceToken.CreateAsync(optionsToken, cancellationToken: cancellationToken);

                var options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt64(order.Cost),
                    Currency = Constants.Currency.CDN,
                    Description = "Order",
                    Source = stripeToken.Id
                };

                var service = new ChargeService();

                var charge = await service.CreateAsync(options, cancellationToken: cancellationToken);

                if (charge.Paid)
                {
                    order.SetPaidStatus();
                    await _context.SaveChangesAsync(cancellationToken);
                    return new();
                }

                throw new PaymentFailedException();

            }
        }
    }
}
