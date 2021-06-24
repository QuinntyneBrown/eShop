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
    public class RemoveThemeProperty
    {
        public class Request : IRequest<Response>
        {
            public Guid ThemePropertyId { get; set; }
        }

        public class Response : ResponseBase
        {
            public ThemePropertyDto ThemeProperty { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var themeProperty = await _context.ThemeProperties.SingleAsync(x => x.ThemePropertyId == request.ThemePropertyId);

                _context.ThemeProperties.Remove(themeProperty);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    ThemeProperty = themeProperty.ToDto()
                };
            }

        }
    }
}
