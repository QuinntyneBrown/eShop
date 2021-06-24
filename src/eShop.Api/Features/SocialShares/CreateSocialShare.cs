using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using eShop.Api.Models;
using eShop.Api.Core;
using eShop.Api.Interfaces;

namespace eShop.Api.Features
{
    public class CreateSocialShare
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.SocialShare).NotNull();
                RuleFor(request => request.SocialShare).SetValidator(new SocialShareValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public SocialShareDto SocialShare { get; set; }
        }

        public class Response : ResponseBase
        {
            public SocialShareDto SocialShare { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IEShopDbContext _context;

            public Handler(IEShopDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var socialShare = new SocialShare(request.SocialShare.ShareType, request.SocialShare.Url);

                _context.SocialShares.Add(socialShare);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    SocialShare = socialShare.ToDto()
                };
            }

        }
    }
}
