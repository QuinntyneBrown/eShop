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
    public class RemoveCustomization
    {
        public class Request : IRequest<Response>
        {
            public System.Guid CustomizationId { get; set; }
        }

        public class Response : ResponseBase
        {
            public CustomizationDto Customization { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var customization = await _context.Customizations.SingleAsync(x => x.CustomizationId == request.CustomizationId);

                _context.Customizations.Remove(customization);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Customization = customization.ToDto()
                };
            }

        }
    }
}
