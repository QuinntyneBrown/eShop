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
    public class RemoveSocialShare
    {
        public class Request: IRequest<Response>
        {
            public Guid SocialShareId { get; set; }
        }

        public class Response: ResponseBase
        {
            public SocialShareDto SocialShare { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;
        
            public Handler(IEShopDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var socialShare = await _context.SocialShares.SingleAsync(x => x.SocialShareId == request.SocialShareId);
                
                _context.SocialShares.Remove(socialShare);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    SocialShare = socialShare.ToDto()
                };
            }
            
        }
    }
}
