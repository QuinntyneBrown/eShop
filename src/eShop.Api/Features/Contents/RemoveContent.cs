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
    public class RemoveContent
    {
        public class Request : IRequest<Response>
        {
            public System.Guid ContentId { get; set; }
        }

        public class Response : ResponseBase
        {
            public ContentDto Content { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var content = await _context.Contents.SingleAsync(x => x.ContentId == request.ContentId);

                _context.Contents.Remove(content);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Content = content.ToDto()
                };
            }

        }
    }
}
